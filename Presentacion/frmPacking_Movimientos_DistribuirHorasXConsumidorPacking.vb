Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPacking_Movimientos_DistribuirHorasXConsumidorPacking
    Dim dtResultado As DataTable
    Dim dtResultadoMes As DataTable
    Dim dsDataParaCombos As DataSet
    Dim consumidorSeleccionado As DataRow = Nothing

    Private Sub frmPacking_Movimientos_DistribuirHorasXConsumidorPacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaControles()
        cargarCombo(cboCultivo, dsDataParaCombos.Tables(0))
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub pkrDia_ValueChanged(sender As Object, e As EventArgs) Handles pkrDia.ValueChanged
        consultarDia()
        consultarMes()
        actualizarEtiquetas()
    End Sub

    Private Sub consultarDia()
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        'Dim dgv As Task(Of DataTable)
        'encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        'dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        'dtResultado = Await dgv
        dtResultado = subConsultarDia()
        corregirTabla(dtResultado)
        'apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        'corregirCeldas(dgvResultado)
        dgvResultado.DataSource = dtResultado
        formatearDataGridView(dgvResultado)
    End Sub

    Private Function subConsultarDia() As DataTable
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", CType(pkrDia.Value.ToString("yyyy-MM-dd"), DateTime))
            aux = doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking", p, TipoQuery.DataTable)
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub consultarMes()
        dgvResultadoMes.DataSource = Nothing
        dtResultadoMes = Nothing
        dgvResultadoMes.Columns.Clear()
        'Dim dgv As Task(Of DataTable)
        'encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        'dgv = consultarMesAsync()
        ''dgvResultado.DataSource = Await dgv
        dtResultadoMes = consultarMesAsync()
        corregirTabla(dtResultadoMes)
        dgvResultadoMes.DataSource = dtResultadoMes
        'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -2)
        'corregirCeldas(dgvResultadoMes)
        formatearDataGridView(dgvResultadoMes)
    End Sub

    Private Function consultarMesAsync() As DataTable
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", CType(pkrDia.Value.ToString("yyyy-MM-dd"), DateTime))
            aux = doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_ObtenerMes", p, TipoQuery.DataTable)
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Async Sub consultarResultadoProcesado()
    '    dgvResultado.DataSource = Nothing
    '    dtResultado = Nothing
    '    dgvResultado.Columns.Clear()
    '    Dim dgv As Task(Of DataTable)
    '    encenderControlesDeEspera(barProgreso, lblDin_Resultado)
    '    dgv = consultarResultadoProcesadoAsync()
    '    'dgvResultado.DataSource = Await dgv
    '    dtResultado = Await dgv
    '    corregirTabla(dtResultado)
    '    dgvResultado.DataSource = dtResultado
    '    apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    '    corregirCeldas(dgvResultado)
    '    formatearDataGridView(dgvResultado)
    'End Sub

    'Private Async Function consultarResultadoProcesadoAsync() As Task(Of DataTable)
    '    Try
    '        Dim aux As DataTable
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Dia", CType(pkrDia.Value, Date))
    '        'aux = doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_DistribuirHoras", p, TipoQuery.DataTable)
    '        aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_DistribuirHoras", p, TipoQuery.DataTable))
    '        Return aux
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
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

    Private Sub obtenerDataParaControles()
        dsDataParaCombos = New DataSet
        Dim aux As DataTable
        aux = doItBaby("sp_Gen_ObtenerCultivosPacking", Nothing, TipoQuery.DataTable)
        dsDataParaCombos.Tables.Add(aux.Copy)
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@TipoId", "N")
        aux = doItBaby("sp_Gen_ObtenerVariedadesPacking", p, TipoQuery.DataTable)
        cargarCombo(cboVariedad, aux.Copy)
    End Sub

    Private Sub cboVariedad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboVariedad.SelectionChangeCommitted
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@IdVariedad", cboVariedad.SelectedValue)
        aux = doItBaby("sp_Gen_ObtenerModulosPacking", p, TipoQuery.DataTable)
        cargarCombo(cboModulo, aux.Copy)
    End Sub

    Private Sub cboModulo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboModulo.SelectionChangeCommitted
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@IdVariedad", cboVariedad.SelectedValue)
        p.Add("@IdModulo", cboModulo.SelectedValue)
        aux = doItBaby("sp_Gen_ObtenerEmpaquesXConsumidorPacking", p, TipoQuery.DataTable)
        cargarCombo(cboEmpaque, aux.Copy)
    End Sub

    Private Sub cboEmpaque_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboEmpaque.SelectionChangeCommitted
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        p.Add("@IdVariedad", cboVariedad.SelectedValue)
        p.Add("@IdModulo", cboModulo.SelectedValue)
        p.Add("@IdEmpaque", cboEmpaque.SelectedValue)
        aux = doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_ObtenerConsumidor", p, TipoQuery.DataTable)
        consumidorSeleccionado = aux.NewRow()
        consumidorSeleccionado = aux.Rows(0)
        actualizarEtiquetas()
    End Sub

    Private Sub actualizarEtiquetas()
        If consumidorSeleccionado IsNot Nothing Then
            lblDin_IdConsumidor.Text = consumidorSeleccionado.Item(0)
            lblDin_DescripcionConsumidor.Text = consumidorSeleccionado.Item(1)
            lblDin_CajasXPallet.Text = consumidorSeleccionado.Item(2)
        End If
        If dgvResultado.ColumnCount > 7 Then
            Try
                Dim totCajas As Integer = dtResultado.Compute("Sum(Cajas)", "IdConsumidor <> ''")
                lblDin_Resultado.Text = "Total Cajas X Dia: " + totCajas.ToString
            Catch
            End Try
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dia", CType(pkrDia.Value, Date))
        p.Add("@IdConsumidor", consumidorSeleccionado.Item(0))
        p.Add("@CajasProducidas", txtCajasProducidas.Text)
        p.Add("@Usuario", usuarioActual)
        doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_Insertar", p, TipoQuery.NonQuery)
        consultarDia()
        consultarMes()
        actualizarEtiquetas()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dia", CType(pkrDia.Value, Date))
        p.Add("@IdConsumidor", consumidorSeleccionado.Item(0))
        doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_Borrar", p, TipoQuery.NonQuery)
        consultarDia()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        Dim aux As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dia", pkrDia.Value.ToString("yyyy-MM-dd"))
        aux = doItBaby("sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_DistribuirHoras", p, TipoQuery.DataTable)
        'dgvResultado.DataSource = aux
        'consultarResultadoProcesado()
        dtResultado = aux
        corregirTabla(dtResultado)
        dgvResultado.DataSource = dtResultado
        formatearDataGridView(dgvResultado)
        consultarMes()
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, "")
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, "")
        'End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(dtResultado, l, Me.Text, Nothing))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub ConsultarMes()

    '    sp_Dg_Packing_Movimientos_DistribuirHorasXConsumidorPacking_ObtenerMes()
    'End Sub

End Class