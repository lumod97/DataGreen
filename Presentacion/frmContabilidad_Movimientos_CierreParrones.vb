Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmContabilidad_Movimientos_CierreParrones
    Dim miDataSet As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim dsDataParaCombos_Input As DataSet
    Dim dsDataParaCombos_Reportes As DataSet
    Dim dsInput As DataSet
    Dim dsReportes As DataSet
    Dim dtConsumidoresPendientes As DataTable
    Dim dtDetalle_Input As DataTable


    Private Sub frmContabilidad_Movimientos_CierreParrones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        obtenerDataParaCombos()
        cargarCombo(cboInputDatos_Campana, dsDataParaCombos_Input.Tables(0), "", False)
        cargarCombo(cboReportes_Campana, dsDataParaCombos_Reportes.Tables(0), "", False)
        cargarCombo(cboReportes_Codigo, dsDataParaCombos_Reportes.Tables(1), "", False)
        iniciarDataGridViewPendientes()
        obtenerDetalle_Input()
        Me.WindowState = FormWindowState.Maximized
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombos_Input = New DataSet
        dsDataParaCombos_Input.Tables.Add(doItBaby("sp_Dg_ObtenerCampanas", Nothing, TipoQuery.DataTable))
        dsDataParaCombos_Reportes = New DataSet
        dsDataParaCombos_Reportes.Tables.Add(dsDataParaCombos_Input.Tables(0).Copy)
        dsDataParaCombos_Reportes.Tables.Add(doItBaby("sp_Dg_ObtenerCodigosCierreParrones", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub obtenerCodigos()
        dsDataParaCombos_Reportes.Tables.RemoveAt(1)
        'dsDataParaCombos_Reportes.Tables.Add(dsDataParaCombos_Input.Tables(0).Copy)
        dsDataParaCombos_Reportes.Tables.Add(doItBaby("sp_Dg_ObtenerCodigosCierreParrones", Nothing, TipoQuery.DataTable))
    End Sub

    'Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
    '    dgvResultado_Resumen.DataSource = Nothing
    '    dgvResultado_Resumen.Columns.Clear()
    '    dgvResultado_Detalle.DataSource = Nothing
    '    dgvResultado_Detalle.Columns.Clear()

    '    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
    '    Dim aux As DataSet
    '    aux = Await Task.Run(Function() consultarAsync())

    '    dgvResultado_Resumen.DataSource = Await Task.FromResult(aux.Tables(0))
    '    dgvResultado_Detalle.DataSource = Await Task.FromResult(aux.Tables(1))

    '    apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)

    '    corregirCeldas(dgvResultado_Resumen)
    '    corregirCeldas(dgvResultado_Detalle)

    '    formatearDataGridView(dgvResultado_Resumen)
    '    formatearDataGridView(dgvResultado_Detalle)

    'End Sub

    'Private Async Function consultarAsync() As Task(Of DataSet)
    '    Try
    '        Dim r As New DataSet
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Desde", dtpDesde.Value)
    '        p.Add("@Hasta", dtpHasta.Value)
    '        arrayDeParametros = obtenerCadenaParametros(p)
    '        r = Await Task.Run(Function() doItBaby("sp_Dg_Supervision_Reportes_DetalleDiarioXSupuervisorGMO", p, TipoQuery.DataSet))
    '        Return r
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    'Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
    '    Dim titulo As String = "", subtitulo As String = ""
    '    titulo = Me.Text + ": Usuario[" + usuarioActual + "] Fecha[" + DateTime.Now.ToString("G") + "]"
    '    subtitulo = arrayDeParametros
    '    If dgvResultado_Resumen.RowCount < 1 Then
    '        MessageBox.Show("Error, no hay registros para exportar")
    '    Else
    '        Dim dGVs As New List(Of DataGridView)
    '        dGVs.Add(dgvResultado_Resumen)
    '        dGVs.Add(dgvResultado_Detalle)
    '        exportarExcel(dGVs, titulo, subtitulo)
    '    End If
    'End Sub


    'Private Sub dgvResultado_Resumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Resumen.DataError
    '    If (e.Context = DataGridViewDataErrorContexts.Commit) Then
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
    '        MessageBox.Show("Cell change")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
    '        MessageBox.Show("parsing error")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
    '        MessageBox.Show("leave control error")
    '    End If
    '    If (TypeOf (e.Exception) Is ConstraintException) Then
    '        Dim view As DataGridView = CType(sender, DataGridView)
    '        view.Rows(e.RowIndex).ErrorText = "an error"
    '        view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
    '        e.ThrowException = False
    '    End If
    'End Sub

    'Private Sub dgvResultado_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Detalle.DataError
    '    If (e.Context = DataGridViewDataErrorContexts.Commit) Then
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
    '        MessageBox.Show("Cell change")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
    '        MessageBox.Show("parsing error")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
    '        MessageBox.Show("leave control error")
    '    End If
    '    If (TypeOf (e.Exception) Is ConstraintException) Then
    '        Dim view As DataGridView = CType(sender, DataGridView)
    '        view.Rows(e.RowIndex).ErrorText = "an error"
    '        view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
    '        e.ThrowException = False
    '    End If
    'End Sub

    Private Sub cboInputDatos_Campana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboInputDatos_Campana.SelectionChangeCommitted
        For i As Integer = 1 To dsDataParaCombos_Input.Tables.Count - 1 Step 1 'MODIFICAR PARA ELIMINAR DE ATRAS ADELANTE
            dsDataParaCombos_Input.Tables.RemoveAt(1)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@AnioCampana", cboInputDatos_Campana.SelectedValue)
        dsDataParaCombos_Input.Tables.Add(doItBaby("sp_Dg_ObtenerCultivosXAnioCampana", p, TipoQuery.DataTable))
        cargarCombo(cboInputDatos_Cultivo, dsDataParaCombos_Input.Tables(1), "", True)
    End Sub

    Private Sub cboInputDatos_Cultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboInputDatos_Cultivo.SelectionChangeCommitted
        For i As Integer = 2 To dsDataParaCombos_Input.Tables.Count - 1 Step 1 'MODIFICAR PARA ELIMINAR DE ATRAS ADELANTE
            dsDataParaCombos_Input.Tables.RemoveAt(2)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@AnioCampana", cboInputDatos_Campana.SelectedValue)
        p.Add("@IdCultivo", cboInputDatos_Cultivo.SelectedValue)
        dsDataParaCombos_Input.Tables.Add(doItBaby("sp_Dg_ObtenerConsumidorXAnioCampanaYCultivo", p, TipoQuery.DataTable))
        cargarCombo(cboInputDatos_Consumidor, dsDataParaCombos_Input.Tables(2), "", True)

        lblInputDatos_Codigo.Text = doItBaby("sp_Dg_ObtenerCodigoCierreParronesXAnioCampanaYCultivo", p, TipoQuery.Scalar)

    End Sub

    Private Sub cboReportes_Campana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboReportes_Campana.SelectionChangeCommitted
        'CULTIVOS
        For i As Integer = 2 To dsDataParaCombos_Reportes.Tables.Count - 1 Step 1 'MODIFICAR PARA ELIMINAR DE ATRAS ADELANTE
            dsDataParaCombos_Reportes.Tables.RemoveAt(2)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@AnioCampana", cboReportes_Campana.SelectedValue)
        dsDataParaCombos_Reportes.Tables.Add(doItBaby("sp_Dg_ObtenerCultivosXAnioCampana", p, TipoQuery.DataTable))
        cargarCombo(cboReportes_Cultivo, dsDataParaCombos_Reportes.Tables(2), "", True)
        'PERIODOS
        dsDataParaCombos_Reportes.Tables.Add(doItBaby("sp_Dg_ObtenerPeriodosXAnioCampana", p, TipoQuery.DataTable))
        cargarCombo(cboReportes_Periodo, dsDataParaCombos_Reportes.Tables(3), "", False)
    End Sub

    Private Sub obtenerDetalle_Input()
        dtDetalle_Input = doItBaby("sp_Dg_Contabilidad_Movimientos_CierreParrones_ObtenerDetalle", Nothing, TipoQuery.DataTable)
        dgvInputDatos_ConsumidoresGuardados.DataSource = dtDetalle_Input
        formatearDataGridView(dgvInputDatos_ConsumidoresGuardados)
    End Sub

    Private Sub iniciarDataGridViewPendientes()
        dtConsumidoresPendientes = New DataTable
        dtConsumidoresPendientes.Columns.Add("Campana")
        dtConsumidoresPendientes.Columns.Add("Cultivo")
        dtConsumidoresPendientes.Columns.Add("Codigo")
        dtConsumidoresPendientes.Columns.Add("Consumidor")
        dtConsumidoresPendientes.Columns.Add("FechaCierre")
        dgvInputDatos_ConsumidoresPendientes.DataSource = dtConsumidoresPendientes
    End Sub

    Private Sub cboInputDatos_Consumidor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboInputDatos_Consumidor.SelectionChangeCommitted
        Dim nuevaFila As DataRow = dtConsumidoresPendientes.NewRow
        nuevaFila.Item(0) = cboInputDatos_Campana.SelectedValue
        nuevaFila.Item(1) = cboInputDatos_Cultivo.SelectedValue
        nuevaFila.Item(2) = lblInputDatos_Codigo.Text
        nuevaFila.Item(3) = cboInputDatos_Consumidor.SelectedValue
        nuevaFila.Item(4) = pkrInputDatos_FechaCierre.Value.ToString("yyyy-MM-dd")
        dtConsumidoresPendientes.Rows.Add(nuevaFila)
        formatearDataGridView(dgvInputDatos_ConsumidoresPendientes)
    End Sub

    Private Sub btnInputDatos_Guardar_Click(sender As Object, e As EventArgs) Handles btnInputDatos_Guardar.Click
        Dim p As New Dictionary(Of String, Object)
        Try
            For Each fila As DataRow In dtConsumidoresPendientes.Rows
                'corregir misma clave

                p.Add("@AnioCampana", fila.Item(0))
                p.Add("@IdCultivo", fila.Item(1))
                p.Add("@Codigo", fila.Item(2))
                p.Add("@IdConsumidor", fila.Item(3))
                p.Add("@Fecha", fila.Item(4))
                p.Add("@Usuario", usuarioActual)
                doItBaby("sp_Dg_Contabilidad_Movimientos_CierreParrones_GuardarFechasCierre", p, TipoQuery.NonQuery)
                p.Clear()
            Next
            obtenerDetalle_Input()
            dtConsumidoresPendientes.Rows.Clear()
            obtenerCodigos()
            cargarCombo(cboReportes_Codigo, dsDataParaCombos_Reportes.Tables(1), "", False)
            MessageBox.Show("Registros guardados correctamente.")
        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & p.Item("@AnioCampana") & "-" & p.Item("@IdCultivo") & "-" & p.Item("@Codigo"))
        End Try
    End Sub

    Private Sub dgvInputDatos_ConsumidoresPendientes_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvInputDatos_ConsumidoresPendientes.CellMouseDoubleClick
        dtConsumidoresPendientes.Rows(e.RowIndex).Delete()
    End Sub

    Private Sub btnInputDatos_Eliminar_Click(sender As Object, e As EventArgs) Handles btnInputDatos_Eliminar.Click
        Dim r As DialogResult
        r = MessageBox.Show("Eliminar registros seleccionados?", "Eliminar", MessageBoxButtons.YesNo)
        If r = Windows.Forms.DialogResult.Yes Then
            Dim p As New Dictionary(Of String, Object)
            For Each fila As DataGridViewRow In dgvInputDatos_ConsumidoresGuardados.SelectedRows
                p.Add("@AnioCampana", fila.Cells(0).Value)
                p.Add("@IdCultivo", fila.Cells(1).Value)
                p.Add("@Codigo", fila.Cells(2).Value)
                p.Add("@IdConsumidor", fila.Cells(3).Value)
                doItBaby("sp_Dg_Contabilidad_Movimientos_CierreParrones_EliminarFechaCierre", p, TipoQuery.NonQuery)
                p.Clear()
            Next
            obtenerDetalle_Input()
            MessageBox.Show("Registros eliminados correctamente.")
        End If
    End Sub

    Private Sub btnReportes_Consultar_Click(sender As Object, e As EventArgs) Handles btnReportes_Consultar.Click
        If cboReportes_Campana.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar una campana.")
        ElseIf cboReportes_Cultivo.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar un cultivo.")
        ElseIf cboReportes_Codigo.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar un codigo.")
        ElseIf cboReportes_Periodo.SelectedIndex < 0 Then
            MessageBox.Show("Debe seleccionar un periodo.")
        Else
            preConsulta(sender, e)
        End If
    End Sub

    Private Async Sub preConsulta(sender As Object, e As EventArgs)
        dgvReportes_CostosGenerales.DataSource = Nothing
        dgvReportes_CostosGenerales.Columns.Clear()
        dgvReportes_DetalleIndirectos.DataSource = Nothing
        dgvReportes_DetalleIndirectos.Columns.Clear()
        CheckForIllegalCrossThreadCalls = False
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())

        dgvReportes_CostosGenerales.DataSource = Await Task.FromResult(aux.Tables(0))
        dgvReportes_DetalleIndirectos.DataSource = Await Task.FromResult(aux.Tables(1))

        apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)

        corregirCeldas(dgvReportes_CostosGenerales)
        corregirCeldas(dgvReportes_DetalleIndirectos)

        formatearDataGridView(dgvReportes_CostosGenerales)
        formatearDataGridView(dgvReportes_DetalleIndirectos)

    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@AnioCampana", cboReportes_Campana.SelectedValue)
            p.Add("@IdCultivo", cboReportes_Cultivo.SelectedValue)
            p.Add("@Codigo", cboReportes_Codigo.SelectedValue)
            p.Add("@Periodo", cboReportes_Periodo.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Contabilidad_Movimientos_CierreParrones_ProcesarReporte", p, TipoQuery.DataSet))
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnReportes_Exportar_Click(sender As Object, e As EventArgs) Handles btnReportes_Exportar.Click
        'If dgvReportes_CostosGenerales.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("CostosGenerales", dgvReportes_CostosGenerales)
        '    dDgvs.Add("DetalleIndirectos", dgvReportes_DetalleIndirectos)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If

        'MODIFICACIONEXPORTAREXCEL()
        'Dim titulo As String = "", subtitulo As String = ""
        'titulo = Me.Text + ": Usuario[" + usuarioActual + "] Fecha[" + DateTime.Now.ToString("G") + "]"
        'subtitulo = arrayDeParametros
        'If dgvReportes_CostosGenerales.RowCount < 1 And dgvReportes_DetalleIndirectos.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dGVs As New List(Of DataGridView)
        '    dGVs.Add(dgvReportes_CostosGenerales)
        '    dGVs.Add(dgvReportes_DetalleIndirectos)
        '    exportarExcel(dGVs, titulo, subtitulo)
        '    'dgvResultado_Resumen.ClearSelection()

        'End If

        Try
            If dgvInputDatos_ConsumidoresGuardados.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("CostosGenerales")
                l.Add("DetalleIndirectos")
                Await Task.Run(Sub() aExcel(dsReportes, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class