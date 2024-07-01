Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports Datos.ConexionSqlite
Imports System.IO
Public Class frmConfigBases

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarConfSqlite(txtBLNombreConexion.Text,
                    txtBLServidor.Text,
                    txtBLUsuario.Text,
                    txtBLPassword.Text,
                    txtBLNombreBase.Text,
                    txtBENombreConexion.Text,
                    txtBEServidor.Text,
                    txtBEUsuario.Text,
                    txtBEPassword.Text,
                    txtBENombreBase.Text)
        'cargarCredenciales()
        MessageBox.Show("Configuracion guardada correctamente")
    End Sub

    Private Sub frmConfigBases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        'validarConfiguracion()
        'If cargarConfig() Then
        txtBLNombreConexion.Text = IIf(credenciales("BLNomCon") <> "", credenciales("BLNomCon"), txtBLNombreConexion.Text)
        txtBLServidor.Text = IIf(credenciales("BLServid") <> "", credenciales("BLServid"), txtBLServidor.Text)
        txtBLUsuario.Text = IIf(credenciales("BLUsuari") <> "", credenciales("BLUsuari"), txtBLUsuario.Text)
        txtBLPassword.Text = IIf(credenciales("BLPasswo") <> "", credenciales("BLPasswo"), txtBLPassword.Text)
        txtBLNombreBase.Text = IIf(credenciales("BLNomBas") <> "", credenciales("BLNomBas"), txtBLNombreBase.Text)
        txtBENombreConexion.Text = IIf(credenciales("BENomCon") <> "", credenciales("BENomCon"), txtBENombreConexion.Text)
        txtBEServidor.Text = IIf(credenciales("BEServid") <> "", credenciales("BEServid"), txtBEServidor.Text)
        txtBEUsuario.Text = IIf(credenciales("BEUsuari") <> "", credenciales("BEUsuari"), txtBEUsuario.Text)
        txtBEPassword.Text = IIf(credenciales("BEPasswo") <> "", credenciales("BEPasswo"), txtBEPassword.Text)
        txtBENombreBase.Text = IIf(credenciales("BENomBas") <> "", credenciales("BENomBas"), txtBENombreBase.Text)
        txtBSQLiteRuta.Text = rutaGeneral + rutaSqlite
        txtBSQLiteNombreBase.Text = "SqliteDataGreen.db"
        'Else
        'MessageBox.Show("No se pudo cargar la configuracion.")
        'End If
        tlpPrincipal.Visible = True
    End Sub

    Private Sub btnBLProbarConexion_Click(sender As Object, e As EventArgs) Handles btnBLProbarConexion.Click
        credenciales("BLNomCon") = txtBLNombreConexion.Text
        credenciales("BLServid") = txtBLServidor.Text
        credenciales("BLUsuari") = txtBLUsuario.Text
        credenciales("BLPasswo") = txtBLPassword.Text
        credenciales("BLNomBas") = txtBLNombreBase.Text
        If Not conectarBD(credenciales("BLNomCon")) Is Nothing Then
            MessageBox.Show("Conexion realizada correctamente.")
        Else
            MessageBox.Show("Conexion fallida.")
        End If
    End Sub

    Private Sub btnBEProbarConexion_Click(sender As Object, e As EventArgs) Handles btnBEProbarConexion.Click
        credenciales("BENomCon") = txtBENombreConexion.Text
        credenciales("BEServid") = txtBEServidor.Text
        credenciales("BEUsuari") = txtBEUsuario.Text
        credenciales("BEPasswo") = txtBEPassword.Text
        credenciales("BENomBas") = txtBENombreBase.Text
        If Not conectarBD(credenciales("BENomCon")) Is Nothing Then
            MessageBox.Show("Conexion realizada correctamente.")
        Else
            MessageBox.Show("Conexion fallida.")
        End If
    End Sub

    Private Sub btnBSQLiteCrearBD_Click(sender As Object, e As EventArgs) Handles btnBSQLiteCrearBD.Click
        'bdSqlite = txtBSQLiteRuta.Text + txtBSQLiteNombreBase.Text
        If Not Directory.Exists(rutaGeneral + rutaSqlite) Then
            Directory.CreateDirectory(rutaGeneral + rutaSqlite)
        End If
        Dim i As SByte = crearBD(False)
        If i > 0 Then
            MessageBox.Show("Base de datos SQLite creada correctamente.")
        ElseIf i < 0 Then
            MessageBox.Show("La base de datos SQLite ya existe.")
        Else
            MessageBox.Show("Error al intentar crear la base de datos SQLite.")
        End If
    End Sub

    Private Sub btnBSQLiteCrearTablas_Click(sender As Object, e As EventArgs) Handles btnBSQLiteCrearTablas.Click
        Try
            Dim tablaConsultas As DataTable = New DataTable
            Dim tablaTablasSqlite As DataTable = New DataTable
            tablaConsultas = obtenerConsultasSQLite("", "DataGreen", "CrearTabla")
            If Not tablaConsultas Is Nothing Then
                For Each fila As DataRow In tablaConsultas.Rows
                    If Not existeTablaSqlite(fila.Item(2).ToString) Then
                        If Not ejecutarSqlite(fila.Item(1).ToString, tipoProceso.NonQuery) Then
                            MessageBox.Show("Error al crear la tabla: " + fila.Item(0).ToString)
                        End If
                    End If
                Next
                tablaConsultas = obtenerConsultasSQLite("poblarTablaSqliteConfiguracion", "DataGreen", "")
                If Not tablaConsultas Is Nothing Then
                    For Each fila As DataRow In tablaConsultas.Rows
                        If Not ejecutarSqlite(fila.Item(1).ToString, tipoProceso.NonQuery) Then
                            MessageBox.Show("Error al ejecutar: " + fila.Item(0).ToString)
                        End If
                    Next
                End If
                tablaTablasSqlite = ejecutarSqlite("SELECT name Clave, name Valor, name Concatenado FROM sqlite_master WHERE type='table'", tipoProceso.DataTable)
                Dim nuevaFila As DataRow = tablaTablasSqlite.NewRow()
                nuevaFila.Item(0) = "Todas"
                nuevaFila.Item(1) = "Todas"
                nuevaFila.Item(2) = "Todas las Tablas"
                tablaTablasSqlite.Rows.InsertAt(nuevaFila, 0)
                cargarCombo(cboTablasSqlite, tablaTablasSqlite)
                MessageBox.Show("Tablas creadas correctamente.")
            Else
                MessageBox.Show("Error al cargar la tabla de consultas.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function obtenerConsultasSQLite(nombreConsulta As String, objetivo As String, Uso As String) As DataTable
        Dim aux As DataTable = New DataTable
        Dim P As New Dictionary(Of String, Object)
        P.Add("@NombreConsulta", nombreConsulta)
        P.Add("@Objetivo", objetivo)
        P.Add("@Uso", Uso)
        aux = doItBaby("sp_ObtenerConsultasSQLite", P, TipoQuery.DataTable)
        '        aux = execSp_ObtenerConsultasSQLite(nombreConsulta, objetivo, Uso)
        Return aux
    End Function

    'Public Shared Function execSp_ObtenerConsultasSQLite(nombreConsulta As String, objetivo As String, Uso As String) As DataTable
    '    Dim parametros(2) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@NombreConsulta", SqlDbType.VarChar)
    '    parametros(0).Value = CType(nombreConsulta, String)
    '    parametros(1) = New SqlClient.SqlParameter("@Objetivo", SqlDbType.VarChar)
    '    parametros(1).Value = CType(objetivo, String)
    '    parametros(2) = New SqlClient.SqlParameter("@Uso", SqlDbType.VarChar)
    '    parametros(2).Value = CType(Uso, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_ObtenerConsultasSQLite",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '        Return Nothing 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return Nothing
    'End Function

    Private Sub btnBSQLiteProbarConexion_Click(sender As Object, e As EventArgs) Handles btnBSQLiteProbarConexion.Click
        If probarConexion() Then
            MessageBox.Show("Conexion a base de datos SQLITE correcta.")
        Else
            MessageBox.Show("No se puede conectar a la base de datos SQLITE.")
        End If
    End Sub

    Private Async Sub btnBSQLiteDescargarData_Click(sender As Object, e As EventArgs) Handles btnBSQLiteDescargarData.Click
        If cboTablasSqlite.SelectedIndex >= 0 Then
            Dim dataSqlite As DataTable = New DataTable
            'dataSqlite = execSp_Dg_DescargarDataSqlite()
            Dim p As New Dictionary(Of String, Object)
            p.Add("@TablasObjetivo", cboTablasSqlite.SelectedValue)
            dataSqlite = doItBaby("sp_Dg_DescargarDataSqlite", p, TipoQuery.DataTable)
            barProgreso.Maximum = dataSqlite.Rows.Count
            barProgreso.Style = ProgressBarStyle.Continuous
            barProgreso.Value = 0
            Dim ok As Boolean
            ok = Await poblarTablasSqlite(dataSqlite)
            If ok Then
                MessageBox.Show("Data SQLITE descargada correctamente.")
            Else
                MessageBox.Show("Error al intentar descargar Data SQLITE.")
            End If
        Else
            MessageBox.Show("Seleccione una tabla para poder descargar data")
        End If
    End Sub

    Private Sub btnBSQLiteResetearBD_Click(sender As Object, e As EventArgs) Handles btnBSQLiteResetearBD.Click
        Dim i As SByte = crearBD(True)
        If i > 0 Then
            MessageBox.Show("Base de datos SQLite reseteada correctamente.")
        ElseIf i < 0 Then
            MessageBox.Show("La base de datos SQLite ya existe.")
        Else
            MessageBox.Show("Error al intentar crear la base de datos SQLite.")
        End If
    End Sub

    Private Async Function poblarTablasSqlite(dataSqlite As DataTable) As Task(Of Boolean)
        Try
            'Await poblarSQLITE(dataSqlite)
            Dim comandoSqlite As String = String.Empty
            Dim valoresFila As String = String.Empty
            Dim valor As String = String.Empty
            For Each f As DataRow In dataSqlite.Rows
                For i As Integer = 0 To f.Item(1) - 1 Step 1
                    valor = f.Item(i + 2).ToString.Replace("'", "''")
                    valoresFila = valoresFila + IIf(valoresFila.Length = 0, "'", ",'") + valor + "'"
                Next
                comandoSqlite = "INSERT INTO " + f.Item(0).ToString + " VALUES (" + valoresFila + ")"
                CheckForIllegalCrossThreadCalls = False
                Await Task.Run(Sub() lblResultado.Text = f.Item(0).ToString + "->" + comandoSqlite)
                ejecutarSqlite(comandoSqlite, tipoProceso.NonQuery)
                valoresFila = String.Empty
                CheckForIllegalCrossThreadCalls = False
                Await Task.Run(Sub() barProgreso.Value = barProgreso.Value + 1)
            Next
            Return True
        Catch ex As Exception
            'Throw ex
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    'Public Async Function poblarSQLITE(tabla As DataTable) As Task(Of Boolean)
    '    Dim dataAdapterSqlite As New SQLiteDataAdapter
    '    Dim dataSetSqlite As New DataSet
    '    Dim conexionSqlite As SQLiteConnection
    '    conexionSqlite = New SQLiteConnection(cadenaConexionSqlite)
    '    Dim comandoSqlite As SQLiteCommand
    '    Try
    '        conexionSqlite.Open()
    '        comandoSqlite = conexionSqlite.CreateCommand()
    '        'Dim query As String = String.Empty
    '        '---------
    '        Dim lineaSqlite As String = String.Empty
    '        Dim valoresFila As String = String.Empty
    '        Dim valor As String = String.Empty
    '        For Each f As DataRow In tabla.Rows
    '            For i As Integer = 0 To f.Item(1) - 1 Step 1
    '                valor = f.Item(i + 2).ToString.Replace("'", "''")
    '                valoresFila = valoresFila + IIf(valoresFila.Length = 0, "'", ",'") + valor + "'"
    '            Next
    '            lineaSqlite = "INSERT INTO " + f.Item(0).ToString + " VALUES (" + valoresFila + ")"
    '            CheckForIllegalCrossThreadCalls = False
    '            Await Task.Run(Sub() lblResultado.Text = f.Item(0).ToString + "->" + comandoSqlite)
    '            comandoSqlite.CommandText = lineaSqlite
    '            comandoSqlite.ExecuteNonQuery()
    '            valoresFila = String.Empty
    '            CheckForIllegalCrossThreadCalls = False
    '            Await Task.Run(Sub() barProgreso.Value = barProgreso.Value + 1)
    '        Next
    '        Return True
    '    Catch ex As Exception
    '        Throw ex
    '        Return False
    '    Finally
    '        conexionSqlite.Close()
    '    End Try
    'End Function

End Class