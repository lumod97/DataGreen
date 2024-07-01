Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_CalculoConceptosRemunerativos

    Dim arrayDeParametros As String = String.Empty
    Dim dsResultado As DataSet
    Dim dsDataParaCombo As Dictionary(Of String, DataTable)

    Private Sub frmRrhh_Movimientos_CalculoConceptosRemunerativos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboIdPlanilla, dsDataParaCombo("Planillas"), 0, 2)
        cargarCombo(cboPeriodoDesde, dsDataParaCombo("PeriodosDesde"), 0, 1)
        cargarCombo(cboPeriodoHasta, dsDataParaCombo("PeriodosHasta"), 0, 1)
        setearControlesConValoresIniciales()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New Dictionary(Of String, DataTable)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@SeleccionMultiple", 0)
        dsDataParaCombo.Add("Planillas", doItBaby("sp_ObtenerPlanillas", p, TipoQuery.DataTable))
        dsDataParaCombo.Add("PeriodosDesde", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Add("PeriodosHasta", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Add("SemanasDesde", Nothing)
        dsDataParaCombo.Add("SemanasHasta", Nothing)
    End Sub

    Private Sub setearControlesConValoresIniciales()

        'cboIdPlanilla.SelectedIndex = 0
        'cboPeriodoDesde.SelectedIndex = 0
        'cboPeriodoHasta.SelectedIndex = 0
        radXPorcentaje.Checked = True
        txtDiasXaCalculoPromedioStandar.Text = "7"
        txtMargenPromedio.Text = "30"
    End Sub

    Private Sub cboPeriodoDesde_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPeriodoDesde.SelectionChangeCommitted
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodoDesde.SelectedValue)
        p.Add("@SeleccionMultiple", 0)
        dsDataParaCombo("SemanasDesde") = doItBaby("sp_Dg_ObtenerSemanas", p, TipoQuery.DataTable)
        cargarCombo(cboSemanaDesde, dsDataParaCombo("SemanasDesde"), 0, 1)
    End Sub

    Private Sub cboPeriodoHasta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPeriodoHasta.SelectionChangeCommitted
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodoHasta.SelectedValue)
        p.Add("@SeleccionMultiple", 0)
        dsDataParaCombo("SemanasHasta") = doItBaby("sp_Dg_ObtenerSemanas", p, TipoQuery.DataTable)
        cargarCombo(cboSemanaHasta, dsDataParaCombo("SemanasHasta"), 0, 1)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            dsResultado = New DataSet()
            Dim ds As Task(Of DataSet)
            encenderControlesDeEspera(barProgreso, lblResultado)
            ds = consultarAsync()
            dsResultado = Await ds

            dgvObservaciones.DataSource = dsResultado.Tables(1)
            dgvResultado.DataSource = dsResultado.Tables(2)
            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
            corregirCeldas(dgvObservaciones)
            formatearDataGridView(dgvObservaciones)
            corregirCeldas(dgvResultado)
            formatearDataGridView(dgvResultado)
            'MessageBox.Show(dsResultado.Tables(0).Rows(0).Item("Imprimible"))
            If dsResultado.Tables(0).Rows(0).Item("Imprimible") Then
                MessageBox.Show(dsResultado.Tables(0).Rows(0).Item("Detalle").ToString)
                'Throw New Exception(dsResultado.Tables(0).Rows(0).Item(2).ToString)
            End If
        Catch ex As Exception
            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
            MessageBox.Show(ex.Message)
        Finally
            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        End Try
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdPlanilla", cboIdPlanilla.SelectedValue)
            p.Add("@PeriodoDesde", cboPeriodoDesde.SelectedValue)
            p.Add("@SemanaDesde", cboSemanaDesde.SelectedValue)
            p.Add("@PeriodoHasta", cboPeriodoHasta.SelectedValue)
            p.Add("@SemanaHasta", cboSemanaHasta.SelectedValue)
            p.Add("@UsarAlgoritmoPorHoras", radXHoras.Checked)
            p.Add("@OmitirObservaciones", cbxOmitirObservaciones.Checked)
            p.Add("@DiasXaCalculoPromedioStandar", txtDiasXaCalculoPromedioStandar.Text)
            p.Add("@MargenPromedio", txtMargenPromedio.Text)
            p.Add("@EnviarAMovimientoPlanilla", cbxEnviarAMovimientoDePlanillas.Checked)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Movimientos_CalculoConceptosRemunerativos", p, TipoQuery.DataSet))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub txtDiasXaCalculoPromedioStandar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasXaCalculoPromedioStandar.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMargenPromedio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMargenPromedio.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgv_Enter(sender As Object, e As EventArgs) Handles dgvObservaciones.Enter, dgvResultado.Enter
        Dim dgvSeleccionado As DataGridView = sender
        lblResultado.Text = dgvSeleccionado.Name & ": " & dgvSeleccionado.RowCount & " filas."
    End Sub


    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As New List(Of String)
                l.Add("Observaciones")
                l.Add("Resultado")
                Dim ds As DataSet = New DataSet
                ds.Tables.Add(dsResultado.Tables(1).Clone)
                ds.Tables.Add(dsResultado.Tables(2).Clone)
                Await Task.Run(Sub() aExcel(ds, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            apagarControlesDeEspera(barProgreso, lblResultado, -1)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvObservaciones.DataError, dgvResultado.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
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

    Private Sub cbxEnviarAMovimientoDePlanillas_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEnviarAMovimientoDePlanillas.CheckedChanged
        If cbxEnviarAMovimientoDePlanillas.Checked Then
            Dim r As DialogResult = MessageBox.Show("Al activar esta opcion se insertaran los bonos como conceptos en los movimientos" +
                                                "de planillas. Dichos movimientos deben estar generados previamente." +
                                                " ¿Esta seguro de proceder?", "Atencion!", MessageBoxButtons.YesNo)
            If r <> Windows.Forms.DialogResult.Yes Then
                Dim cbx As CheckBox = sender 'CType(sender, CheckBox)
                RemoveHandler cbx.CheckedChanged, AddressOf cbxEnviarAMovimientoDePlanillas_CheckedChanged
                cbx.Checked = Not cbx.Checked
                AddHandler cbx.CheckedChanged, AddressOf cbxEnviarAMovimientoDePlanillas_CheckedChanged
            Else
                btnConsultar.Text = "Procesar"
                btnConsultar.FlatAppearance.BorderColor = rojoAmarath
                btnConsultar.BackColor = rojoAmarath
                btnConsultar.ForeColor = blancoPuro_
                btnConsultar.FlatAppearance.MouseOverBackColor = rojoCandy__
            End If
        Else
            btnConsultar.Text = "Consultar"
            btnConsultar.FlatAppearance.BorderColor = azulCielo__
            btnConsultar.BackColor = blancoPuro_
            btnConsultar.ForeColor = grisNoventa
            btnConsultar.FlatAppearance.MouseOverBackColor = verderCian_
        End If
    End Sub

    Private Sub cbxOmitirObservaciones_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOmitirObservaciones.CheckedChanged
        If cbxOmitirObservaciones.Checked Then
            Dim r As DialogResult = MessageBox.Show("Activar esta opcion implica ignorar todas las observaciones detectadas, " +
                                                "Active esta opcion si y solo si esta seguro que las observaciones no son relevantes." +
                                                " ¿Esta seguro de proceder?", "Atencion!", MessageBoxButtons.YesNo)
            If r <> Windows.Forms.DialogResult.Yes Then
                Dim cbx As CheckBox = sender 'CType(sender, CheckBox)
                RemoveHandler cbx.CheckedChanged, AddressOf cbxOmitirObservaciones_CheckedChanged
                cbx.Checked = Not cbx.Checked
                AddHandler cbx.CheckedChanged, AddressOf cbxOmitirObservaciones_CheckedChanged
            End If
        End If
    End Sub

    Private Sub cboSemanaDesde_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSemanaDesde.SelectionChangeCommitted
        Dim filtro As String = "Clave = " & cboSemanaDesde.SelectedValue
        lblDesdeDia.Text = dsDataParaCombo("SemanasDesde").Select(filtro)(0).Item(2).ToString
    End Sub

    Private Sub cboSemanaHasta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSemanaHasta.SelectionChangeCommitted
        Dim filtro As String = "Clave = " & cboSemanaHasta.SelectedValue
        lblHastaDia.Text = dsDataParaCombo("SemanasHasta").Select(filtro)(0).Item(2).ToString
    End Sub
End Class