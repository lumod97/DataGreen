Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Reportes_CorrespondenciaVacacional
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    Dim dsResultado As DataSet
    Private Sub frmRrhh_Reportes_CorrespondenciaVacacional_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        removerFila(dsDataParaCombo.Tables(0), "TODAS")
        removerFila(dsDataParaCombo.Tables(1), "TODOS")
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboPeriodo, dsDataParaCombo.Tables(1), "", False)
        tlpPrincipal.Visible = True
        radPlanilla.Checked = True
        aplicarTema(Me)
    End Sub
    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvDuplicados.DataSource = Nothing
        dgvResumen.DataSource = Nothing

        dsResultado = Nothing

        dgvDuplicados.Columns.Clear()
        dgvResumen.Columns.Clear()

        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dsResultado = Await dgv

        corregirTabla(dsResultado.Tables(0))
        corregirTabla(dsResultado.Tables(1))


        dgvResumen.DataSource = dsResultado.Tables(0)
        dgvDuplicados.DataSource = dsResultado.Tables(1)

        apagarControlesDeEspera(barProgreso, lblResultado, dgvResumen.RowCount)
        corregirCeldas(dgvResumen)
        corregirCeldas(dgvDuplicados)

        formatearDataGridView(dgvResumen)
        formatearDataGridView(dgvDuplicados)


    End Sub
    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerPeriodosAnuales", Nothing, TipoQuery.DataTable))
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdPlanilla", IIf(radPlanilla.Checked, cboPlanilla.SelectedValue, ""))
            p.Add("@IdCodigoGeneral", IIf(radCodigoDni.Checked, txtCodigoDni.Text, ""))
            p.Add("@PeriodoDesde", cboPeriodo.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_CorrespondenciaVacacional", p, TipoQuery.DataSet))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
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


    Private Async Sub btnExportar_Click_1(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResumen.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("PlanillaResumen")
                l.Add("RegistrosDuplicados")

                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub radPlanilla_CheckedChanged_1(sender As Object, e As EventArgs) Handles radPlanilla.CheckedChanged
        If radPlanilla.Checked Then
            cboPlanilla.Enabled = True
            txtCodigoDni.Enabled = False
        End If
    End Sub

    Private Sub radCodigoDni_CheckedChanged_1(sender As Object, e As EventArgs) Handles radCodigoDni.CheckedChanged
        If radCodigoDni.Checked Then
            cboPlanilla.Enabled = False
            txtCodigoDni.Enabled = True
            txtCodigoDni.Focus()
        End If
    End Sub
End Class