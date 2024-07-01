Imports Datos.Conexion
Imports Logica.Funciones
Imports Logica.Utiles
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports AxAcroPDFLib
Imports System.CodeDom
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Web

Public Class frmRrhh_Reportes_GenerarFotocheck

    Dim dtResultado As New DataTable
    Dim dtSeleccionados As New DataTable
    Dim dvResultado, dvSeleccionados As DataView
    Dim arrayDeParametros As String = String.Empty
    Dim bsFiltro As New BindingSource()
    Dim bsFiltroSeleccionados As New BindingSource()
    Dim filasAfectasResultadoGeneral, filasAfectasCodigosSeleccionado As List(Of Integer)
    Dim dtTablaExcel As New DataTable

    Private Sub frmRrhh_Reportes_GenerarFotocheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerDataGeneral()
        aplicarTema(Me)
    End Sub

    Private Sub cargarDataGeneral()
        dvResultado = New DataView(dtResultado)
        bsFiltro.DataSource = dvResultado
        dgvResultado.DataSource = bsFiltro
        dvSeleccionados = New DataView(dtSeleccionados)
        bsFiltroSeleccionados.DataSource = dvSeleccionados
        dgvSeleccionados.DataSource = bsFiltroSeleccionados
    End Sub

    Private Async Sub obtenerDataGeneral()
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        dgv = consultarAsync()
        dtResultado = Await dgv
        dtSeleccionados = dtResultado.Clone
        cargarDataGeneral()
        formatearDataGridView(dgvResultado)
        formatearDataGridView(dgvSeleccionados)
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    End Sub

    Private Async Sub obtenerDataRefresh()
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        dgv = consultarAsync()
        dtResultado = Await dgv
        dvResultado = New DataView(dtResultado)
        bsFiltro.DataSource = dvResultado
        dgvResultado.DataSource = bsFiltro
        formatearDataGridView(dgvResultado)
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            arrayDeParametros = obtenerCadenaParametros(Nothing)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_GenerarFotochecks_ObtenerDataGeneral", Nothing, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            encenderControlesDeEspera(barProgreso, lblDin_Resultado)
            Dim seleccionados As New DataTable()
            Dim codigos As New List(Of Object)
            'obtenemos los codigos
            For Each fila As DataRow In dtSeleccionados.Rows
                Dim codigo As String
                Dim dni As String
                codigo = fila.Item("T_IdCodigoGeneral")
                dni = fila.Item("T_Dni")
                Dim movimientos As New Dictionary(Of String, String)()
                movimientos.Add("codigo", codigo)
                movimientos.Add("encriptado", EncriptarCodigo(dni))
                codigos.Add(movimientos)
            Next

            generarPDF(codigos)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvResultado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        If e.RowIndex >= 0 Then
            filasAfectasResultadoGeneral = New List(Of Integer)
            For Each f As DataGridViewRow In dgvResultado.SelectedRows
                filasAfectasResultadoGeneral.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasResultadoGeneral
                dtSeleccionados.ImportRow(dtResultado.Rows(i - 1))
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Async Function generarPDF(codigos As List(Of Object)) As Task
        Dim apiUrl As String
        Dim parametros As New Dictionary(Of String, Object)()

        parametros.Add("codigos", codigos)
        parametros.Add("vista", "vista_pdf")
        If cbTipoEmpleado.Checked Then

            apiUrl = "http://192.168.30.94:8080/api/get_pdf_test"
            ' Crear diccionario para los parámetros
            parametros.Item("vista") += "_emp"
            Dim prueba As String = parametros.Item("vista")
            MessageBox.Show(prueba)
        Else

            ' URL del punto final de la API
            apiUrl = "http://192.168.30.94:8080/api/get_pdf_barras_cu"
            'Dim apiUrl As String = "http://192.168.30.23:8000/api/get_pdf_barras_cu"


        End If



        ' Convertir el diccionario a JSON
        Dim jsonData As String = JsonConvert.SerializeObject(parametros)

        ' Crear la solicitud HTTP
        Dim request As HttpWebRequest = WebRequest.Create(apiUrl)
        request.Method = "POST"

        ' Datos a enviar en la solicitud (JSON)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(jsonData)
        request.ContentType = "application/json"
        request.ContentLength = byteArray.Length

        ' Escribir los datos en el cuerpo de la solicitud
        Using dataStream As Stream = Await request.GetRequestStreamAsync()
            Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
        End Using

        ' Obtener la respuesta
        Try
            Dim response As WebResponse = Await request.GetResponseAsync()
            Using responseStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(responseStream)
                    Dim textResponse As String = Await reader.ReadToEndAsync()
                    wbrImprimible.Navigate(textResponse)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblDin_Resultado)
        End Try
    End Function

    Private Function EncriptarCodigo(cadenaACifrar As String) As String
        'PASO 0: CREACION DE VARIABLES

        Dim logintudOriginal As Integer = cadenaACifrar.Length - 1
        If logintudOriginal <> 7 Then
            Throw New Exception("La cadena no tiene la longitud necesario (8)")
        End If
        'PASO 1: INDIZAR CADENA, SE PASA A ARRAY DE CHAR
        Dim aCadena(logintudOriginal) As Integer
        For i As Integer = 0 To logintudOriginal Step 1
            aCadena(i) = Integer.Parse(cadenaACifrar(i))
        Next
        Dim sumaA As Integer = 0
        'PASO 2: OBTENER SUMA DE DIGITOS
        For Each c As Integer In aCadena
            sumaA += c
        Next
        'PASO 3: OBTENER CLAVE A (ULTIMO DIGITO DE LA SUMA)
        Dim claveA As Integer = sumaA Mod 10
        'PASO 4: DETERMINAR SI LA CLAVE A ES PAR 
        Dim claveAEsPar As Boolean = IIf(claveA Mod 2 <> 0, False, True)
        'PASO 5: OPERAR SUMA DE LA CLAVE A SOBRE ALGUNOS DIGITOS, SI LA CLAVE A ES PAR SOBRE LOS DIGITOS PARES, Y VICEVERSA
        For i As Integer = 1 To logintudOriginal Step 1
            If claveAEsPar And i Mod 2 = 0 Then
                aCadena(i) = aCadena(i) + claveA
            ElseIf Not claveAEsPar And i Mod 2 <> 0 Then
                aCadena(i) = aCadena(i) + claveA
            End If
        Next
        'PASO 6: SI ALGUN DIGITO RESULTANTE ES MAYOR O IGUAL QUE 10 SE REDUCE A 1 DIGITO RESTANDOLE 10
        For i As Integer = 0 To logintudOriginal Step 1
            If aCadena(i) > 9 Then
                aCadena(i) = aCadena(i) - 10
            End If
        Next
        'PASO 7: HALLAR EL COMPLEMENTO A DECENA DE CADA DIGITO Y REEMPLAZAR LOS DIGITOS ORIGINALES POR LOS COMPLEMENTOS
        For i As Integer = 0 To logintudOriginal Step 1
            If aCadena(i) <> 0 Then
                aCadena(i) = 10 - aCadena(i)
            End If
        Next
        'PASO 8: OBTENER 2 SUBCADENAS USANDO COMO PIVOTE EL DIGITO EN LA POSICION N DONDE N ES LA CLAVE A SIEMPRE QUE CLAVE A SEA MENOR O IGUAL QUE
        'LA LONGITUD DE LA CADENA ORIGINAL -1, DE LO CONTRARIO N ES CLAVE A - LONGITUD DE LA CADENA ORIGINAL - 1
        Dim pivote As Integer = IIf(claveA <= logintudOriginal, claveA, claveA - logintudOriginal)
        Dim cadenaIzquierda As String = String.Empty, cadenaDerecha As String = String.Empty
        For i As Integer = 0 To logintudOriginal Step 1
            If i < pivote Then
                cadenaIzquierda &= aCadena(i).ToString
            Else
                cadenaDerecha &= aCadena(i).ToString
            End If
        Next
        Dim cadenaFinal As String = cadenaDerecha & cadenaIzquierda
        Dim sumaB As Integer = 0
        For Each c As Char In cadenaFinal.ToCharArray
            sumaB += Integer.Parse(c)
        Next
        Dim claveB As Integer = sumaB Mod 10
        cadenaFinal &= claveA.ToString & claveB.ToString
        Return cadenaFinal
    End Function


    'Private Function DesencriptarCodigo(cadenaCifrada As String) As String
    '    ' PASO 0: CREACIÓN DE VARIABLES
    '    Dim longitudCifrada As Integer = cadenaCifrada.Length - 1
    '    If longitudCifrada <> 9 Then
    '        Throw New Exception("La cadena cifrada no tiene la longitud necesaria (10)")
    '    End If

    '    ' Extraer claveA y claveB del final de la cadena cifrada
    '    Dim claveA As Integer = Integer.Parse(cadenaCifrada(longitudCifrada - 1).ToString())
    '    Dim claveB As Integer = Integer.Parse(cadenaCifrada(longitudCifrada).ToString())

    '    ' Obtener la cadena final sin las claves
    '    Dim cadenaFinal As String = cadenaCifrada.Substring(0, longitudCifrada - 1)

    '    ' PASO 1: Hallar el pivote
    '    Dim logintudOriginal As Integer = longitudCifrada - 2
    '    Dim pivote As Integer = If(claveA <= logintudOriginal, claveA, claveA - logintudOriginal)

    '    ' Dividir la cadena en dos partes según el pivote
    '    Dim cadenaDerecha As String = cadenaFinal.Substring(0, pivote)
    '    Dim cadenaIzquierda As String = cadenaFinal.Substring(pivote)

    '    ' Concatenar las partes en el orden inverso al cifrado
    '    Dim cadenaDescifrada As String = cadenaIzquierda & cadenaDerecha

    '    ' Convertir la cadena descifrada a un array de dígitos
    '    Dim aCadena(logintudOriginal) As Integer
    '    For i As Integer = 0 To logintudOriginal Step 1
    '        aCadena(i) = Integer.Parse(cadenaDescifrada(i).ToString())
    '    Next

    '    ' PASO 2: Hallar el complemento a decena y revertir
    '    For i As Integer = 0 To logintudOriginal Step 1
    '        If aCadena(i) <> 0 Then
    '            aCadena(i) = 10 - aCadena(i)
    '        End If
    '    Next

    '    ' PASO 3: Revertir las operaciones sobre los dígitos según claveAEsPar
    '    Dim claveAEsPar As Boolean = (claveA Mod 2 = 0)

    '    For i As Integer = 1 To logintudOriginal Step 1
    '        If claveAEsPar And i Mod 2 = 0 Then
    '            aCadena(i) = aCadena(i) - claveA
    '        ElseIf Not claveAEsPar And i Mod 2 <> 0 Then
    '            aCadena(i) = aCadena(i) - claveA
    '        End If

    '        ' Asegurarse de que los dígitos están en el rango [0,9]
    '        If aCadena(i) < 0 Then
    '            aCadena(i) += 10
    '        End If
    '    Next

    '    ' Convertir los dígitos a caracteres y concatenar
    '    Dim cadenaDescifradaFinal As String = String.Empty
    '    For i As Integer = 0 To logintudOriginal Step 1
    '        cadenaDescifradaFinal &= aCadena(i).ToString()
    '    Next

    '    Return cadenaDescifradaFinal
    'End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If dgvResultado.SelectedRows.Count > 0 Then
            filasAfectasCodigosSeleccionado = New List(Of Integer)
            For Each f As DataGridViewRow In dgvResultado.SelectedRows
                filasAfectasCodigosSeleccionado.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasCodigosSeleccionado
                dtSeleccionados.ImportRow(dtResultado.Rows(i - 1))
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvSeleccionados.SelectedRows.Count > 0 Then
            filasAfectasCodigosSeleccionado = New List(Of Integer)
            For Each f As DataGridViewRow In dgvSeleccionados.SelectedRows
                filasAfectasCodigosSeleccionado.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasCodigosSeleccionado
                For j As Integer = 0 To dtSeleccionados.Rows.Count - 1 Step 1
                    If dtSeleccionados.Rows(j).Item(0).ToString.Equals(i.ToString) Then
                        dtSeleccionados.Rows.RemoveAt(j)
                    End If
                    If j >= dtSeleccionados.Rows.Count - 1 Then
                        Exit For
                    End If
                Next
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        obtenerDataRefresh()
    End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaArchivo.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnCargarArchivo_Click(sender As Object, e As EventArgs) Handles btnCargarArchivo.Click
        Try
            dtTablaExcel = cargarExcel(txtRutaArchivo.Text) 'PENDIENTE CAMBIAR LA FUNCION CARGAREXCEL POR UN PROCESO EN MOTOR SQL
            corregirTabla(dtTablaExcel)
            barProgreso.Value = 0
            barProgreso.Maximum = dtTablaExcel.Rows.Count
            barProgreso.Style = ProgressBarStyle.Continuous

            'armando el dt con los dni de dtTablaExcel
            Dim listaDNI = New List(Of Integer)
            If dtTablaExcel.Rows.Count > 0 Then
                listaDNI = New List(Of Integer)
                For Each f As DataRow In dtTablaExcel.Rows
                    listaDNI.Add(f("T_Dni").ToString())
                Next
                For Each i As Integer In listaDNI
                    For Each j As DataRow In dtResultado.Rows
                        If (j("T_Dni").Equals(i.ToString())) Then
                            dtSeleccionados.ImportRow(dtResultado.Rows(j("T_Fila") - 1))
                        End If
                    Next

                    'dtSeleccionados.ImportRow(dtResultado.Rows())
                Next
                formatearDataGridView(dgvSeleccionados)
            End If

            lblDin_Resultado.Text = "Registros: " + dtTablaExcel.Rows.Count().ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            formatearDataGridView(dgvResultado)

        End Try
    End Sub

    Private Sub dgvSeleccionados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeleccionados.CellDoubleClick
        If e.RowIndex >= 0 Then
            filasAfectasCodigosSeleccionado = New List(Of Integer)
            For Each f As DataGridViewRow In dgvSeleccionados.SelectedRows
                filasAfectasCodigosSeleccionado.Add(f.Cells(0).Value)
            Next
            For Each i As Integer In filasAfectasCodigosSeleccionado
                For j As Integer = 0 To dtSeleccionados.Rows.Count - 1 Step 1
                    If dtSeleccionados.Rows(j).Item(0).ToString.Equals(i.ToString) Then
                        dtSeleccionados.Rows.RemoveAt(j)
                    End If
                    If j >= dtSeleccionados.Rows.Count - 1 Then
                        Exit For
                    End If
                Next
            Next
            formatearDataGridView(dgvSeleccionados)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsFiltro.Filter = String.Format(
                                        "T_IdPlanilla like '%{0}%' Or " +
                                        "T_IdCodigoGeneral like '%{1}%' Or " +
                                        "T_Dni like '%{2}%' Or " +
                                        "T_Trabajador like '%{3}%' Or " +
                                        "T_IdCargo like '%{4}%' Or " +
                                        "T_Cargo like '%{5}%' Or " +
                                        "T_IdArea like '%{6}%' Or " +
                                        "T_Area like '%{7}%'",
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text,
                                        txtFiltro.Text)
    End Sub

End Class