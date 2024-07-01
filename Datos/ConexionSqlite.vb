Imports Finisar.SQLite
'Imports System.IO
'Imports SQLITEgrijalvaRomero.Conexion
Imports System.Data.SqlClient
Imports Entidades.Temporales
Imports Datos.Conexion
Public Class ConexionSqlite

    Public Enum tipoProceso
        NonQuery = 1
        Scalar = 2
        DataTable = 3
    End Enum

    Public Shared Function crearBD(resetear As Boolean) As SByte
        Dim objCon As SQLiteConnection
        'objCon = New SQLiteConnection(cadenaConexionSqlite & "New=True;")
        objCon = New SQLiteConnection(cadenaConexionSqlite & "New=True;")
        Dim objCoomand As SQLiteCommand
        If Not My.Computer.FileSystem.FileExists(bdSqlite) Or resetear Then
            Try
                objCon.Open()
                objCoomand = objCon.CreateCommand()
                Return 1
                'Return "Base de datos Sqlite creada correctamente"
                'MessageBox.Show("Base de datos local creada correctamente")
            Catch
                Return 0
                'Return "Error al intentar crear la base de datos Sqlite"
                'MessageBox.Show("Error al crear base de datos local")
            Finally
                If Not IsNothing(objCon) Then
                    objCon.Close()
                End If
            End Try
        Else
            Return -1
            'Return "La base de datos Sqlite ya existe"
            'MessageBox.Show("La base de datos ya existe")
        End If
    End Function

    'Public Shared Function ejecutarComandoSqlite(query As String) As Boolean
    '    Try
    '        Dim objCon As SQLiteConnection
    '        Dim objCoomand As SQLiteCommand
    '        objCon = New SQLiteConnection(cadenaConexionSqlite & "New=False;")
    '        objCon.Open()
    '        objCoomand = objCon.CreateCommand()
    '        objCoomand.CommandText = query
    '        objCoomand.ExecuteNonQuery()
    '        objCon.Close()
    '        Return True
    '    Catch
    '        Return False
    '    End Try
    'End Function


    'Public Shared Function ejecutarSqlite(query As String) As SQLiteDataAdapter
    '    Dim objConn As SQLiteConnection
    '    Dim da As SQLiteDataAdapter
    '    objConn = New SQLiteConnection(cadenaConexionSqlite)
    '    Dim objcommand As SQLiteCommand
    '    Dim objReader As SQLiteDataReader
    '    Try
    '        objConn.Open()
    '        objcommand = objConn.CreateCommand()
    '        objcommand.CommandText = "SELECT * from Usuarios"
    '        objReader = objcommand.ExecuteReader()
    '        ListBox1.Items.Clear()
    '        While (objReader.Read())
    '            ListBox1.Items.Add(objReader(1))
    '        End While
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '        If Not IsNothing(objConn) Then
    '            objConn.Close()
    '        End If
    '    End Try
    'End Function

    Public Shared Function ejecutarSqlite(query As String, tipo As tipoProceso, Optional parametros As List(Of Object) = Nothing) As Object
        Dim dataAdapterSqlite As New SQLiteDataAdapter
        Dim dataSetSqlite As New DataTable
        Dim conexionSqlite As SQLiteConnection
        conexionSqlite = New SQLiteConnection(cadenaConexionSqlite)
        Dim comandoSqlite As SQLiteCommand
        Try
            conexionSqlite.Open()
            comandoSqlite = conexionSqlite.CreateCommand()
            Select Case tipo
                Case tipoProceso.NonQuery
                    comandoSqlite.CommandText = query
                    If parametros IsNot Nothing Then
                        insertarParametrosSqlite(comandoSqlite, parametros)
                    End If
                    comandoSqlite.ExecuteNonQuery()
                    Return True
                Case tipoProceso.Scalar
                    comandoSqlite.CommandText = query
                    If parametros IsNot Nothing Then
                        insertarParametrosSqlite(comandoSqlite, parametros)
                    End If
                    Return comandoSqlite.ExecuteScalar
                Case tipoProceso.DataTable
                    'dataAdapterSqlite = New SQLiteDataAdapter(query, conexionSqlite)
                    comandoSqlite.CommandText = query
                    If parametros IsNot Nothing Then
                        insertarParametrosSqlite(comandoSqlite, parametros)
                    End If
                    dataAdapterSqlite = New SQLiteDataAdapter(comandoSqlite)
                    dataSetSqlite.Reset()
                    dataAdapterSqlite.Fill(dataSetSqlite)
                    Return dataSetSqlite
            End Select
            Return Nothing
        Catch ex As Exception
            'Throw ex
            If tipo = tipoProceso.NonQuery Then
                Return False
            ElseIf tipo = tipoProceso.Scalar Then
                Return ""
            Else
                Return Nothing
            End If
            'Return False
        Finally
            conexionSqlite.Close()
        End Try
    End Function

    Public Shared Function probarConexion() As Boolean
        Dim dataAdapterSqlite As New SQLiteDataAdapter
        Dim dataSetSqlite As New DataSet
        Dim conexionSqlite As SQLiteConnection
        conexionSqlite = New SQLiteConnection(cadenaConexionSqlite)
        Try
            conexionSqlite.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexionSqlite.Close()
        End Try
    End Function

    Public Shared Function ejecutarSqlite(nombreConsulta As String, Optional parametros As List(Of Object) = Nothing) As Object
        Dim aux As DataTable = New DataTable
        Dim queryAux As String = String.Empty
        Dim tipo As TipoProcesamiento
        queryAux = "SELECT TipoConsulta FROM SqliteConsultas WHERE NombreConsulta='" + nombreConsulta + "'"
        tipo = obtenerTipoProcesamientoSqlite(queryAux)
        queryAux = "SELECT CodigoConsulta FROM SqliteConsultas WHERE NombreConsulta='" + nombreConsulta + "'"
        aux = ejecutarSqlite(queryAux, tipoProceso.DataTable)
        queryAux = aux.Rows(0).Item(0).ToString
        ' AND Objetivo='" + objetivo + "') OR (Objetivo='" + objetivo + "' AND Uso='" + uso + "')"

        Return ejecutarSqlite(queryAux, tipo, parametros)
        'Dim aux As DataTable = New DataTable
        'Dim P As New Dictionary(Of String, Object)
        'P.Add("@NombreConsulta", nombreConsulta)
        'P.Add("@Objetivo", objetivo)
        'P.Add("@Uso", Uso)
        'aux = doItBaby("sp_ObtenerConsultasSQLite", P, TipoQuery.DataTable)
        ''        aux = execSp_ObtenerConsultasSQLite(nombreConsulta, objetivo, Uso)
        'Return aux
    End Function

    Public Shared Sub insertarParametrosSqlite(ByRef comando As SQLiteCommand, parametros As List(Of Object))
        Dim par As SQLiteParameter
        For Each p As Object In parametros
            'comando.CreateAndAddUnnamedParameters()
            par = New SQLiteParameter()
            par.Value = p.ToString
            comando.Parameters.Add(par)
            'comando.Parameters.Item(0).Value = p.ToString
        Next
    End Sub

    Public Shared Function obtenerTipoProcesamientoSqlite(consulta As String) As tipoProceso
        Dim aux As DataTable = New DataTable
        aux = ejecutarSqlite(consulta, tipoProceso.DataTable)
        Try
            Select Case aux.Rows(0).Item(0).ToString
                Case "NonQuery"
                    Return tipoProceso.NonQuery
                Case "DataTable"
                    Return tipoProceso.DataTable
                Case "Scalar"
                    Return tipoProceso.Scalar
                Case Else
                    Throw New Exception("Error, Tipo de Proceso Sqlite incompatible")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function descargarDataSqlite(tablasObjetivo As String) As DataTable
        'Dim dataSqlite As DataTable = New DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@TablasObjetivo", tablasObjetivo)
        Return doItBaby("sp_Dg_DescargarDataSqlite", p, TipoQuery.DataTable)
    End Function

    Public Shared Function cargarTablaSqliteDesdeBd(nombreTabla As String, borraDataPrevia As Boolean)
        Try
            Dim dataSqlite As DataTable = New DataTable
            dataSqlite = descargarDataSqlite(nombreTabla)
            Dim comandoSqlite As String = String.Empty
            Dim valoresFila As String = String.Empty
            Dim valor As String = String.Empty
            If borraDataPrevia Then
                comandoSqlite = "DELETE FROM " + nombreTabla
                ejecutarSqlite(comandoSqlite, tipoProceso.NonQuery)
                comandoSqlite = String.Empty
            End If
            For Each f As DataRow In dataSqlite.Rows
                For i As Integer = 0 To f.Item(1) - 1 Step 1
                    valor = f.Item(i + 2).ToString.Replace("'", "''")
                    valoresFila = valoresFila + IIf(valoresFila.Length = 0, "'", ",'") + valor + "'"
                Next
                comandoSqlite = "INSERT INTO " + f.Item(0).ToString + " VALUES (" + valoresFila + ")"
                ejecutarSqlite(comandoSqlite, tipoProceso.NonQuery)
                valoresFila = String.Empty
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub cargarTablaSqlite(dataParaInsertar As DataTable, tablaSqlite As String, borraDataPrevia As Boolean)
        Try
            Dim comandoSqlite As String = String.Empty
            Dim valoresFila As String = String.Empty
            Dim valor As String = String.Empty
            If borraDataPrevia Then
                comandoSqlite = "DELETE FROM " + tablaSqlite
                ejecutarSqlite(comandoSqlite, tipoProceso.NonQuery)
                comandoSqlite = String.Empty
            End If
            For Each fila As DataRow In dataParaInsertar.Rows
                For Each item In fila.ItemArray
                    valoresFila = valoresFila + IIf(valoresFila.Length = 0, "'", ",'") + item.ToString + "'"
                Next
                comandoSqlite = "INSERT INTO " + tablaSqlite + " VALUES (" + valoresFila + ")"
                ejecutarSqlite(comandoSqlite, tipoProceso.NonQuery)
                valoresFila = String.Empty
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function existeTablaSqlite(nombreTabla As String) As Boolean
        Dim i As Integer = 0
        i = ejecutarSqlite("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='" + nombreTabla + "'", tipoProceso.Scalar)
        If i = 0 Then
            Return False
        End If
        Return True
    End Function

End Class
