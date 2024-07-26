Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion
Imports ClosedXML.Excel.XLPredefinedFormat
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports System.Drawing.Printing
Imports DocumentFormat.OpenXml.Office2010.ExcelAc
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports DocumentFormat.OpenXml.Drawing

Public Class frmRrhh_Reportes_ImpresionFormatos
    Dim dsMetaDatos As New DataSet
    Dim dtResultado As New DataTable
    Dim dsParaCombos As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim bsFiltro As New BindingSource()

    Private Sub frmRrhh_Reportes_ImpresionFormatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerMetaDatos()
        obtenerDataParaCombos()
        cargarCombo(cboTablas, dsMetaDatos.Tables(0), "", False)
        cargarCombo(cboPlanilla, dsParaCombos.Tables(0), 0, 2)
        aplicarTema(Me)
    End Sub

    Private Sub obtenerMetaDatos()
        dsMetaDatos = doItBaby("sp_Dg_Rrhh_Reportes_ImpresionFormatos_ObtenerMetaDatos", Nothing, TipoQuery.DataSet)
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As New DataTable
        aux = doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable)
        dsParaCombos.Tables.Add(aux.Copy)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        dtResultado = Await dgv
        Dim dvResultado As New DataView(dtResultado)
        bsFiltro.DataSource = dvResultado
        corregirTabla(dtResultado)
        dgvResultado.DataSource = bsFiltro
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@vista", "vista_dg")
            p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
            p.Add("@fechaDesde", CType(pkrDesde.Value.ToString("yyyy/MM/dd"), String))
            p.Add("@fechaHasta", CType(pkrHasta.Value.ToString("yyyy/MM/dd"), String))
            arrayDeParametros = obtenerCadenaParametros(p)

            'segun el tipo de formato
            Select Case cboTablas.SelectedValue
                Case "FORMATO_DE_VACACIONES"
                    aux = Await Task.Run(Function() doItBaby("sp_obtenerVacacionesParaFormatoPDF", p, TipoQuery.DataTable))
                Case "FORMATO_COMPENSACION_HORAS_EXTRA"
                    aux = Await Task.Run(Function() doItBaby("sp_obtenerCompensacionHorasExtraParaFormatoPDF", p, TipoQuery.DataTable))
                Case "FORMATO_CERTIFICADO_TRABAJO"
                    MessageBox.Show("Falta SP")
                Case Else
                    MessageBox.Show("Debe elegir un formato")
            End Select

            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellDoubleClick
        Try
            Dim codigo As String
            Dim movimientos As New List(Of String)()
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Select Case cboTablas.SelectedValue
                    Case "FORMATO_DE_VACACIONES"
                        codigo = dgvResultado.Rows(e.RowIndex).Cells("T_MOVIMIENTO").Value
                    Case "FORMATO_COMPENSACION_HORAS_EXTRA"
                        codigo = dgvResultado.Rows(e.RowIndex).Cells("T_MOVIMIENTO").Value
                    Case "FORMATO_CERTIFICADO_TRABAJO"
                        MessageBox.Show("Falta SP")
                    Case Else
                        MessageBox.Show("Debe elegir un formato")
                End Select

                movimientos.Add(codigo)
                generarPDF(movimientos, cboTablas.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Async Function generarPDF(movimientos As List(Of String), formato As String) As Task
        ' URL del punto final de la API
        'Dim apiUrl As String = "http://192.168.30.23:8000/api/get_pdf"
        'Dim apiUrl As String = "http://56.10.3.24:8000/api/get_pdf"
        Dim apiUrl As String = "http://192.168.30.94:8080/api/get_pdf"

        ' Crear diccionario para los parámetros
        Dim parametros As New Dictionary(Of String, Object)()
        parametros.Add("template", formato)
        parametros.Add("movimientos", movimientos)
        parametros.Add("modo", "PDF")

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
        Catch ex As WebException
            MessageBox.Show(ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblDin_Resultado)
        End Try
    End Function

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            encenderControlesDeEspera(barProgreso, lblDin_Resultado)

            Dim seleccionados As New DataTable()

            seleccionados = convertToDateTable(dgvResultado.SelectedRows)
            Dim movimientos As New List(Of String)()
            'obtenemos los codigos
            For Each fila As DataRow In seleccionados.Rows
                Dim codigo As String
                codigo = fila.Item("MOVIMIENTO")
                movimientos.Add(codigo)
            Next

            generarPDF(movimientos, cboTablas.SelectedValue)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function convertToDateTable(data As DataGridViewSelectedRowCollection) As DataTable
        'Creating DataTable.
        Dim dt As New DataTable()

        'segun el tipo de formato
        Select Case cboTablas.SelectedValue
            Case "FORMATO_DE_VACACIONES"
                dt.Columns.Add("MOVIMIENTO")
                dt.Columns.Add("CODIGO_GENERAL")
                dt.Columns.Add("TRABAJADOR")
                dt.Columns.Add("DNI")
                dt.Columns.Add("JUSTIFICACION")
                dt.Columns.Add("DIAS_SOLICITADOS")
                dt.Columns.Add("INICIO_VACACIONES")
                dt.Columns.Add("FINAL_VACACIONES")
                dt.Columns.Add("FECHA_RETORNO")

            Case "FORMATO_COMPENSACION_HORAS_EXTRA"
                dt.Columns.Add("MOVIMIENTO")
                dt.Columns.Add("CODIGO GENERAL")
                dt.Columns.Add("TRABAJADOR")
                dt.Columns.Add("NOMBRE AREA")
                dt.Columns.Add("RANGO DE FECHAS")
                dt.Columns.Add("OBSERVACIONES")
            Case "FORMATO_CERTIFICADO_TRABAJO"
                MessageBox.Show("Falta SP")

            Case Else
                MessageBox.Show("Debe elegir un formato")
        End Select

        Try
            Dim filaNueva As DataRow
            Dim numCols As Integer

            numCols = dt.Columns.Count

            ' Rellenamos los valores del DataTable nuevo con los valores de las celdas del DataGridView
            For Each filaDatos As DataGridViewRow In data
                filaNueva = dt.NewRow()
                For i As Integer = 0 To numCols - 1
                    filaNueva(i) = filaDatos.Cells(i).Value
                Next
                dt.Rows.Add(filaNueva)
            Next

            Return dt

        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        Try

            Select Case cboTablas.SelectedValue
                Case "FORMATO_DE_VACACIONES"
                    bsFiltro.Filter = String.Format("T_MOVIMIENTO like '%{0}%' Or " +
                                                "T_CODIGO_GENERAL like '%{1}%' Or " +
                                                "T_TRABAJADOR like '%{2}%' Or " +
                                                "T_DNI like '%{3}%' Or " +
                                                "T_JUSTIFICACION like '%{4}%'",
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text)
                    lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString

                Case "FORMATO_COMPENSACION_HORAS_EXTRA"

                Case Else
                    MessageBox.Show("Debe elegir un formato")
            End Select
        Catch ex As Exception
            MessageBox.Show("Error en la busqueda")
        End Try

    End Sub

    Private Sub cboPlanilla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPlanilla.SelectedIndexChanged

    End Sub
End Class