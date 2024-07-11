Imports Datos.Conexion
Imports Logica.Funciones
Imports Logica.Utiles
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class frmRrhh_Reportes_FormatoBoletas

    Dim dsMetaDatos As New DataSet
    Dim dtResultado As New DataTable
    Dim dsParaCombos As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim bsFiltro As New BindingSource()

    Private Sub frmRrhh_Reportes_FormatoBoletas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsParaCombos.Tables(0), 0, 2)
        cargarCombo(cboAnio, dsParaCombos.Tables(1), 0, 2)
        aplicarTema(Me)
        'txtAnioDesde.Enabled = False
        'txtAnioHasta.Enabled = False
        'txtMesDesde.Enabled = False
        'txtMesHasta.Enabled = False
        'txtSemanaDesde.Enabled = False
        'txtSemanaHasta.Enabled = False
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As New DataTable
        aux = doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable)
        dsParaCombos.Tables.Add(aux.Copy)
        aux = doItBaby("sp_ObtenerAniosGenerarBoletas", Nothing, TipoQuery.DataTable)
        dsParaCombos.Tables.Add(aux.Copy)
    End Sub

    Public Shared Sub cargarCombo(ByRef combo As ComboBox, tabla As DataTable, c As Integer, v As Integer) 'c=clave, v=valor
        'combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'combo.AutoCompleteSource = AutoCompleteSource.ListItems
        combo.DisplayMember = tabla.Columns(v).ColumnName
        combo.ValueMember = tabla.Columns(c).ColumnName
        combo.DataSource = tabla
        combo.SelectedIndex = 0
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        'Dim listaImp As List(Of String)
        'For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
        '    listaImp.Add(PrinterSettings.InstalledPrinters.Item)
        'Next
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()



        'dgvResultado.DataSource = Await dgv
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
            p.Add("@objCodigos", "[]")
            p.Add("@idPlanilla", cboPlanilla.SelectedValue)
            p.Add("@IdTipoPlanilla", "N")
            p.Add("@codigoDesde", txtCodigoDesde.Text)
            p.Add("@codigoHasta", txtCodigoHasta.Text)
            p.Add("@periodoDesde", cboPeriodoDesde.SelectedValue)
            p.Add("@semanaDesde", cboSemanaDesde.SelectedValue)
            p.Add("@periodoHasta", cboPeriodoHasta.SelectedValue)
            p.Add("@semanaHasta", cboSemanaHasta.SelectedValue)

            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_getDataDiasBoleta", p, TipoQuery.DataTable))

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
            'AxAcroPDF1.src = Nothing
            'AxAcroPDF1.Refresh()
            codigo = dgvResultado.Rows(e.RowIndex).Cells("CODIGO_GENERAL").Value
            movimientos.Add(codigo)
            generarPDF(movimientos)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function generarPDF(movimientos As List(Of String)) As Task
        ' URL del punto final de la API
        'Dim apiUrl As String = "http://192.168.30.23:8000/api/get_pdf"
        Dim apiUrl As String = "http://56.10.3.24:8000/api/get_pdf"

        ' Crear diccionario para los parámetros
        Dim parametros As New Dictionary(Of String, Object)()
        'Dim movimientos As New List(Of String)()
        'movimientos.Add(codigos)
        parametros.Add("template", "FORMATO_BOLETAS")
        parametros.Add("objCodigos", movimientos)
        parametros.Add("idPlanilla", cboPlanilla.SelectedValue)
        parametros.Add("IdTipoPlanilla", "N")
        parametros.Add("periodoDesde", cboPeriodoDesde.SelectedValue)
        parametros.Add("periodoHasta", cboPeriodoHasta.SelectedValue)

        If (cboPlanilla.SelectedValue.Equals("PAS")) Then
            parametros.Add("semanaDesde", cboSemanaDesde.SelectedValue)
            parametros.Add("semanaHasta", cboSemanaHasta.SelectedValue)
        End If


        parametros.Add("vista", "vista_pdf")

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

                    ''Console.WriteLine("PDF cargado desde la ruta: " & textResponse)
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
                codigo = fila.Item("CODIGO_GENERAL")
                movimientos.Add(codigo)
            Next

            generarPDF(movimientos)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedIndexChanged
        Dim aux As New DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Anio", cboAnio.SelectedValue)
        aux = doItBaby("sp_ObtenerPeriodosGenerarBoletas", p, TipoQuery.DataTable)
        cargarCombo(cboPeriodoDesde, aux.Copy, 0, 2)
        cargarCombo(cboPeriodoHasta, aux.Copy, 0, 2)
    End Sub

    Private Sub cboPeriodoDesde_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriodoDesde.SelectedIndexChanged
        Dim aux As New DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodoDesde.SelectedValue)
        aux = doItBaby("sp_ObtenerSemanasGenerarBoletas", p, TipoQuery.DataTable)
        cargarCombo(cboSemanaDesde, aux.Copy, 0, 2)
    End Sub

    Private Sub cboPeriodoHasta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriodoHasta.SelectedIndexChanged
        Dim aux As New DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodoHasta.SelectedValue)
        aux = doItBaby("sp_ObtenerSemanasGenerarBoletas", p, TipoQuery.DataTable)
        cargarCombo(cboSemanaHasta, aux.Copy, 0, 2)
    End Sub

    Private Sub txtCodigoDesde_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoDesde.KeyUp
        If (e.KeyValue = Keys.Enter) Then
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Codigo", txtCodigoDesde.Text)
            aux = doItBaby("sp_ObtenerTrabajadorGenerarBoletas", p, TipoQuery.DataTable)
            If (aux.Rows.Count > 0) Then
                txtTrabajadorDesde.Text = aux.Rows(0)(0)
            Else
                MessageBox.Show("Trabajador no Encontrado")
                txtTrabajadorDesde.Text = ""
            End If

        End If
    End Sub

    Private Sub txtCodigoHasta_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoHasta.KeyUp
        If (e.KeyValue = Keys.Enter) Then
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Codigo", txtCodigoHasta.Text)
            aux = doItBaby("sp_ObtenerTrabajadorGenerarBoletas", p, TipoQuery.DataTable)
            If (aux.Rows.Count > 0) Then
                txtTrabajadorHasta.Text = aux.Rows(0)(0)
            Else
                MessageBox.Show("Trabajador no Encontrado")
                txtTrabajadorHasta.Text = ""
            End If

        End If
    End Sub

    Private Sub cboPlanilla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPlanilla.SelectedIndexChanged
        Dim idPlanilla As String
        idPlanilla = cboPlanilla.SelectedValue

        If (idPlanilla.Equals("PAS")) Then
            cboSemanaDesde.Enabled = True
            cboSemanaHasta.Enabled = True
        Else
            cboSemanaDesde.Enabled = False
            cboSemanaHasta.Enabled = False
        End If

    End Sub

    Private Function convertToDateTable(data As DataGridViewSelectedRowCollection) As DataTable
        'Creating DataTable.
        Dim dt As New DataTable()

        dt.Columns.Add("CODIGO_GENERAL")
        dt.Columns.Add("DNI")
        dt.Columns.Add("TRABAJADOR")
        dt.Columns.Add("CARGO")
        dt.Columns.Add("FONDO PENSIONARIO")
        dt.Columns.Add("CODIGO FONDO")
        dt.Columns.Add("CUENTA BANCO")

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
End Class