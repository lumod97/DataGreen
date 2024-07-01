Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports ClosedXML.Excel

Public Class frmContabilidad_Reportes_CostosAcumulados
    'Dim miDataSet As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim dsDataParaCombos As DataSet
    Dim dsResultado As DataSet
    'Dim dsInput As DataSet
    'Dim dsResultado As DataSet
    'Dim dtConsumidoresPendientes As DataTable
    'Dim dtDetalle_Input As DataTable

    Private Sub frmContabilidad_Reportes_CostosAcumulados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        obtenerDataParaCombos()
        removerFilasInecesarias()
        cargarCombo(cboCampana, dsDataParaCombos.Tables(0), "", False)
        cargarCombo(cboCultivo, dsDataParaCombos.Tables(1), "", False)
        cargarCombo(cboEtapa, dsDataParaCombos.Tables(2), "", False)
        setearDTP()
        Me.WindowState = FormWindowState.Maximized
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombos = New DataSet
        dsDataParaCombos.Tables.Add(doItBaby("sp_Dg_ObtenerCampanas", Nothing, TipoQuery.DataTable))
        dsDataParaCombos.Tables.Add(doItBaby("sp_Dg_ObtenerCultivos", Nothing, TipoQuery.DataTable))
        dsDataParaCombos.Tables.Add(doItBaby("sp_Dg_ObtenerEtapasCampania", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub setearDTP()
        Dim dia As Date
        dia = Now()
        While (dia.DayOfWeek <> DayOfWeek.Sunday)
            dia = dia.AddDays(-1)
        End While
        dtpFecha.Value = dia
    End Sub

    Private Sub removerFilasInecesarias()
        'For i As Integer = 0 To dsDataParaCombos.Tables(0).Rows.Count Step 1
        '    If dsDataParaCombos.Tables(0).Rows(i).Item(0) = "****" Then
        '        dsDataParaCombos.Tables(0).Rows.RemoveAt(i)
        '        i -= 1
        '    End If
        'Next
        'For i As Integer = 0 To dsDataParaCombos.Tables(1).Rows.Count Step 1
        '    If dsDataParaCombos.Tables(1).Rows(i).Item(0) = "****" Then
        '        dsDataParaCombos.Tables(1).Rows.RemoveAt(i)
        '        i -= 1
        '    End If
        'Next
        Dim n As Integer = dsDataParaCombos.Tables(2).Rows.Count - 1
        For i As Integer = 0 To n Step 1
            If dsDataParaCombos.Tables(2).Rows(i).Item(0) = "***" Or dsDataParaCombos.Tables(2).Rows(i).Item(0) = "003" Or _
                dsDataParaCombos.Tables(2).Rows(i).Item(0) = "008" Or dsDataParaCombos.Tables(2).Rows(i).Item(0) = "036" Or _
                dsDataParaCombos.Tables(2).Rows(i).Item(0) = "037" Then
                dsDataParaCombos.Tables(2).Rows.RemoveAt(i)
                i -= 1
                n -= 1
                If i = n Then
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub cboCampana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCampana.SelectionChangeCommitted
        Dim p As New Dictionary(Of String, Object)
        p.Add("@AnioCampana", cboCampana.SelectedValue)
        cargarCombo(cboPeriodo, doItBaby("sp_Dg_ObtenerPeriodosXAnioCampana", p, TipoQuery.DataTable), "", False)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        'dgvCostosGenerales.DataSource = Nothing
        'dgvCostosGenerales.Columns.Clear()

        'tablaResultado = Nothing

        'Dim dgv As Task(Of DataTable)
        'encenderControlesDeEspera(barProgreso, lblResultado)
        'dgv = consultarAsync()
        'tablaResultado = Await dgv
        'corregirTabla(tablaResultado)
        'dgvCostosGenerales.DataSource = tablaResultado
        'apagarControlesDeEspera(barProgreso, lblResultado, dgvCostosGenerales.RowCount)
        'corregirCeldas(dgvCostosGenerales)
        'formatearDataGridView(dgvCostosGenerales)
        '------------------------
        dgvCostosGenerales.DataSource = Nothing
        dgvCostosGenerales.Columns.Clear()
        ' dgvCostosIndirectos.DataSource = Nothing
        ' dgvCostosIndirectos.Columns.Clear()
        CheckForIllegalCrossThreadCalls = False
        encenderControlesDeEspera(barProgreso, lblResultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())

        dgvCostosGenerales.DataSource = Await Task.FromResult(aux.Tables(0))
        'dgvCostosIndirectos.DataSource = Await Task.FromResult(aux.Tables(1))

        apagarControlesDeEspera(barProgreso, lblResultado, -1)

        corregirCeldas(dgvCostosGenerales)
        ' corregirCeldas(dgvCostosIndirectos)

        formatearDataGridView(dgvCostosGenerales)
        'formatearDataGridView(dgvCostosIndirectos)
        lblResultado.Text = dsResultado.Tables(0).Rows.Count.ToString + " Registros"
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)

            p.Add("@AnioCampana", cboCampana.SelectedValue)
            p.Add("@Hasta", CType(dtpFecha.Value.ToString("dd/MM/yyyy"), Date))
            p.Add("@IdCultivo", cboCultivo.SelectedValue)
            ' p.Add("@Tipo", IIf(cboEtapa.SelectedValue = "002" Or cboEtapa.SelectedValue = "004", "N", "I"))
            ' p.Add("@Periodo_D", cboPeriodo.SelectedValue)

            '@Periodo_C CHAR(4), --= '2021' --Parámetro 1 : Campaña
            '@Fecha_ZT CHAR(10), --= '02/05/2021' --Parámetro 2 : Fecha final
            '@CodCultivo CHAR(4), --= '0002' --Parámetro 3 : Cultivo
            '@Tipo CHAR(1), --= 'N' --Parámetro 4 : Tipo de campaña (N = Producción y Renovación / I = Inversión)
            '@Periodo_D CHAR(6) --= '202104' --Parámetro 5 : Período
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Contabilidad_Reportes_CostosAcumulados_2023_2", p, TipoQuery.DataSet))
            dsResultado = r
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvCostosGenerales.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("CostosGenerales", dgvCostosGenerales)
        '    dDgvs.Add("CostosIndirectos", dgvCostosIndirectos)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        ''MODIFICACIONEXPORTAREXCEL()
        ''Dim titulo As String = "", subtitulo As String = ""
        ''titulo = Me.Text + ": Usuario[" + usuarioActual + "] Fecha[" + DateTime.Now.ToString("G") + "]"
        ''subtitulo = arrayDeParametros
        ''If dgvCostosGenerales.RowCount < 1 And dgvCostosGenerales.RowCount < 1 Then
        ''    MessageBox.Show("Error, no hay registros para exportar")
        ''Else
        ''    Dim dGVs As New List(Of DataGridView)
        ''    dGVs.Add(dgvCostosGenerales)
        ''    dGVs.Add(dgvCostosIndirectos)
        ''    exportarExcel(dGVs, titulo, subtitulo)
        ''    'dgvResultado_Resumen.ClearSelection()
        ''End If

        'Try
        '    If dgvCostosGenerales.RowCount < 1 Then
        '        MessageBox.Show("Error, no hay registros para exportar")
        '    Else
        '        'encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
        '        'Dim l As List(Of String) = New List(Of String)
        '        'l.Add("CostosGenerales")
        '        'l.Add("CostosIndirectos")
        '        'Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
        '        'apagarControlesDeEspera(barProgreso, lblResultado, -1)
        '        '----------------------
        '        Using libro As XLWorkbook = New XLWorkbook
        '            Dim hoja As IXLWorksheet
        '            Dim l As List(Of String) = New List(Of String)
        '            l.Add("CostosGenerales")
        '            l.Add("CostosIndirectos")
        '            For i As Integer = 0 To dsResultado.Tables.Count - 2 Step 1
        '                Dim nombreHoja As String = IIf(l Is Nothing, "Hoja" + i.ToString, l(i))
        '                hoja = libro.Worksheets.Add(nombreHoja)
        '                hoja.FirstCell().InsertTable(dsResultado.Tables(i)).Theme = XLTableTheme.None
        '                hoja.Tables.FirstOrDefault().SetShowAutoFilter(False)

        '            Next

        '            Dim nombreArchivo As String = rutaReportes + "Dg" + Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"

        '            libro.SaveAs(nombreArchivo)
        '            Dim inicio As Date = Date.Now

        '            Dim fin As Date = Date.Now
        '            Dim procesos() As Process = Process.GetProcessesByName("EXCEL")
        '            For Each proceso As Process In procesos
        '                If proceso.StartTime >= inicio And proceso.StartTime <= fin Then
        '                    'proceso.Close()
        '                    'proceso.Dispose()
        '                    proceso.Kill()
        '                    Exit For
        '                End If
        '            Next
        '            MessageBox.Show("Exportacion correcta.")
        '        End Using
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try


        'expo()


        If dgvCostosGenerales.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para exportar")
        Else
            encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
            'Dim l As New List(Of String)
            'l.Add("Resumen")
            'l.Add("Detalle")
            Await Task.Run(Sub() aExcel(dsResultado.Tables(0), Nothing, Me.Text, arrayDeParametros))
            'aExcel(dsResultado, l, Me.Text, arrayDeParametros)
            apagarControlesDeEspera(barProgreso, lblResultado, -1)
        End If
    End Sub

    Public Sub expo()
        Using workbook As XLWorkbook = New XLWorkbook
            'workbook.Worksheets.Add(tablaResultado, "Resultado")
            Dim ws = workbook.Worksheets.Add("sheet1")
            'workbook.Worksheets(0).FirstCell().InsertTable(tablaResultado).Theme = XLTableTheme.None
            ws.FirstCell().InsertTable(dsResultado.Tables(0)).Theme = XLTableTheme.None
            workbook.SaveAs("C:\DataGreen\Pruebita.xlsx")
            'FileOpen(1, "C:\DataGreen\Pruebita.xlsx", OpenMode.Input, OpenAccess.Read)
        End Using
    End Sub

    Private Sub dgvCostosGenerales_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvCostosGenerales.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    Private Sub dgvCostosIndirectos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvCostosIndirectos.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    Private Sub dgvCostosGenerales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostosGenerales.CellClick
        lblResultado.Text = "Registros: " & dgvCostosGenerales.Rows.Count
    End Sub

    Private Sub dgvCostosIndirectos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCostosIndirectos.CellClick
        lblResultado.Text = "Registros: " & dgvCostosIndirectos.Rows.Count
    End Sub
End Class