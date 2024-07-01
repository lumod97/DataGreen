Imports Logica.Funciones
Imports Datos.Conexion
Imports Logica.Utiles

Public Class frmRrhh_Reportes_ReporteMarcacionesChronos

    Dim dsParaCombos As DataSet = New DataSet
    Dim dtResultado As DataTable
    Dim arrayDeParametros As String

    Private Sub frmRrhh_Reportes_ReporteMarcacionesChronos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsParaCombos.Tables(0), 0, 2)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As New DataTable
        aux = doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable)
        dsParaCombos.Tables.Add(aux.Copy)
    End Sub

    Private Async Sub cboConsultar_Click(sender As Object, e As EventArgs) Handles cboConsultar.Click
        dgvResultado.DataSource = Nothing
        dtResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dtResultado = Await dgv
        corregirTabla(dtResultado)
        dgvResultado.DataSource = dtResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", CType(pkrDesde.Value.ToString("yyyyMMdd"), String))
            p.Add("@Hasta", CType(pkrHasta.Value.ToString("yyyyMMdd"), String))
            p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
            p.Add("@DesdeCodigo", txtCodigoDesde.Text)
            p.Add("@HastaCodigo", txtCodigoHasta.Text)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_ReporteMarcacionesChronos", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub cboExportar_Click(sender As Object, e As EventArgs) Handles cboExportar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(dtResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
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

    'Private Sub txtCodigoDesde_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoDesde.KeyUp
    '    If (e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Tab) Then
    '        Dim aux As New DataTable
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Codigo", txtCodigoDesde.Text)
    '        aux = doItBaby("sp_ObtenerTrabajadorGenerarBoletas", p, TipoQuery.DataTable)
    '        If (aux.Rows.Count > 0) Then
    '            txtTrabajadorDesde.Text = aux.Rows(0)(0)
    '        Else
    '            MessageBox.Show("Trabajador no Encontrado")
    '            txtTrabajadorDesde.Text = ""
    '        End If

    '    End If
    'End Sub

    'Private Sub txtCodigoHasta_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigoHasta.KeyUp
    '    If (e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Tab) Then
    '        Dim aux As New DataTable
    '        Dim p As New Dictionary(Of String, Object)
    '        p.Add("@Codigo", txtCodigoHasta.Text)
    '        aux = doItBaby("sp_ObtenerTrabajadorGenerarBoletas", p, TipoQuery.DataTable)
    '        If (aux.Rows.Count > 0) Then
    '            txtTrabajadorHasta.Text = aux.Rows(0)(0)
    '        Else
    '            MessageBox.Show("Trabajador no Encontrado")
    '            txtTrabajadorHasta.Text = ""
    '        End If

    '    End If
    'End Sub

    Private Sub txtCodigoDesde_Leave(sender As Object, e As EventArgs) Handles txtCodigoDesde.Leave
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
    End Sub

    Private Sub txtCodigoHasta_Leave(sender As Object, e As EventArgs) Handles txtCodigoHasta.Leave
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
    End Sub
End Class