Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPresupuestos_Reportes_PresupuestoGeneral
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResumen As DataSet
    Dim dsDataParaCombo As DataSet

    Private Sub frmPresupuestos_Reportes_PresupuestoGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboPeriodo, dsDataParaCombo.Tables(0), 0, 2)
        cargarCombo(cboArea, dsDataParaCombo.Tables(1), 0, 2)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub


    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerAniosPresupuestos", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerAreas_S", Nothing, TipoQuery.DataTable))
        'dsDataParaCombo.Tables.Add(doItBaby("sp_Gen_ObtenerMonedas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cboArea_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboArea.SelectionChangeCommitted
        If dsDataParaCombo.Tables.Count = 3 Then
            dsDataParaCombo.Tables.RemoveAt(2)
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@CodArea", cboArea.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerSubareas_S", p, TipoQuery.DataTable))
        cargarCombo(cboSubArea, dsDataParaCombo.Tables(2), 0, 2)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResumen = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        tablaResumen = Await dgv
        corregirTabla(tablaResumen.Tables(0))
        dgvResultado.DataSource = tablaResumen.Tables(0)
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
        formatearLineasDataGridView(dgvResultado, 1)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet) 'Task(Of DataTable)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo", cboPeriodo.SelectedValue)
            p.Add("@CodArea", cboArea.SelectedValue)
            p.Add("@CodSubarea", cboSubArea.SelectedValue)
            p.Add("@Base_N", "AgricolaSanJuan_2020")
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("Sp_Dg_Presupuestos_Reportes_PresupuestoGeneral_P", p, TipoQuery.DataSet))
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


    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("Reporte")
                Await Task.Run(Sub() aExcel(tablaResumen, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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


End Class