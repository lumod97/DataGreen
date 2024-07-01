Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPresupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResumen As DataSet
    Dim tablaDetalle As DataTable
    Dim dsDataParaCombo As DataSet
    Dim idGrupo, idSubGrupo As String

    Private Sub frmPresupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboAnio, dsDataParaCombo.Tables(0), "", False)
        cargarCombo(cboMoneda, dsDataParaCombo.Tables(1), "", False)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerAniosPresupuestos", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Gen_ObtenerMonedas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        If dsDataParaCombo.Tables.Count = 3 Then
            dsDataParaCombo.Tables.RemoveAt(2)
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Anio", cboAnio.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerPresupuestos", p, TipoQuery.DataTable))
        cargarCombo(cboPresupuesto, dsDataParaCombo.Tables(2), False)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResumen.DataSource = Nothing
        dgvTotal.DataSource = Nothing
        dgvDetalle.DataSource = Nothing

        tablaResumen = Nothing
        tablaDetalle = Nothing
        dgvResumen.Columns.Clear()
        dgvTotal.Columns.Clear()
        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        tablaResumen = Await dgv
        corregirTabla(tablaResumen.Tables(0))
        dgvResumen.DataSource = tablaResumen.Tables(0)
        dgvTotal.DataSource = tablaResumen.Tables(1)
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResumen.RowCount)
        corregirCeldas(dgvResumen)
        corregirCeldas(dgvTotal)
        formatearDataGridView(dgvResumen)
        formatearDataGridView(dgvTotal)
        dgvResumen.Columns("T_IdGrupo").Visible = False
        dgvResumen.Columns("T_IdSubGrupo").Visible = False
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet) 'Task(Of DataTable)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@CodigoPresupuesto", cboPresupuesto.SelectedValue)
            p.Add("@IdMoneda", cboMoneda.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo", p, TipoQuery.DataSet))
            Return aux
            'Dim aux As New DataTable
            'Dim p As New Dictionary(Of String, Object)
            'p.Add("@CodigoPresupuesto", cboPresupuesto.SelectedValue)
            'p.Add("@IdMoneda", cboMoneda.SelectedValue)
            'arrayDeParametros = obtenerCadenaParametros(p)
            'aux = doItBaby("sp_Dg_Presupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo", p, TipoQuery.DataTable)
            'Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub dgvResumen_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvResumen.CellMouseClick
        If e.RowIndex >= 0 Then
            idGrupo = dgvResumen.Rows(e.RowIndex).Cells("T_IdGrupo").Value.ToString
            idSubGrupo = dgvResumen.Rows(e.RowIndex).Cells("T_IdSubGrupo").Value.ToString
            dgvDetalle.DataSource = Nothing
            tablaDetalle = Nothing
            dgvDetalle.Columns.Clear()
            Dim dgv As Task(Of DataTable)
            encenderControlesDeEspera(barProgreso, lblResultado)
            dgv = consultarDetalleAsync()
            tablaDetalle = Await dgv
            corregirTabla(tablaDetalle)
            dgvDetalle.DataSource = tablaDetalle
            apagarControlesDeEspera(barProgreso, lblResultado, dgvDetalle.RowCount)
            corregirCeldas(dgvDetalle)
            formatearDataGridView(dgvDetalle)
        End If
    End Sub

    Private Async Function consultarDetalleAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@CodigoPresupuesto", cboPresupuesto.SelectedValue)
            p.Add("@IdMoneda", cboMoneda.SelectedValue)
            p.Add("@IdGrupo ", idGrupo)
            p.Add("@IdSubGrupo", idSubGrupo)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Presupuestos_Reportes_ResumenPresupuestoGrupoSubgrupo_Detalle", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
    '    If dgvResultado.RowCount < 1 Then
    '        MessageBox.Show("Error, no hay registros para exportar")
    '    Else
    '        exportarExcel(dgvResultado, Me.Text, arrayDeParametros, 6)
    '        dgvResultado.ClearSelection()
    '    End If
    'End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
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

End Class