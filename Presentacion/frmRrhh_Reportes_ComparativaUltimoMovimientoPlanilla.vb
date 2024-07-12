Imports Datos.Conexion
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales

Public Class frmRrhh_Reportes_ComparativaUltimoMovimientoPlanilla
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim datosParaCombos As New Dictionary(Of String, DataTable)

    Private Sub FormularioTestX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, datosParaCombos("Planillas"), 0, 2)
        cargarCombo(cboDocumento, datosParaCombos("Documentos"), 0, 2)
        cargarCombo(cboPeriodo, datosParaCombos("Periodos"), 0, 1)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
    End Sub

    Private Sub obtenerDataParaCombos()
        datosParaCombos.Add("Planillas", doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        datosParaCombos.Add("Documentos", doItBaby("sp_ObtenerDocumentosPlanilla", Nothing, TipoQuery.DataTable))
        datosParaCombos.Add("Periodos", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub
    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
            p.Add("@IdDocumento", cboDocumento.SelectedValue)
            p.Add("@HastaPeriodo", cboPeriodo.SelectedValue)
            p.Add("@HastaSemana", IIf(cboPlanilla.SelectedValue = "PAS", cboSemana.SelectedValue, ""))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_ComparativoUltimosMovimientosPlanilla", p, TipoQuery.DataTable))
            tablaResultado = aux
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Sub obtenerDataParaComboPlanilla()
    '    Dim aux As New DataTable
    '    aux = doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable)
    '    datosParaCombos.Tables.Add(aux.Copy)

    'End Sub
    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell changed")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("Parsing error")
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
    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboPeriodo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPeriodo.SelectionChangeCommitted
        If datosParaCombos.ContainsKey("Semanas") Then
            datosParaCombos.Remove("Semanas")
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodo.SelectedValue)
        p.Add("@SeleccionMultiple", "0")
        datosParaCombos.Add("Semanas", doItBaby("sp_Dg_ObtenerSemanas", p, TipoQuery.DataTable))
        cargarCombo(cboSemana, datosParaCombos("Semanas"), 0, 1)
    End Sub
End Class