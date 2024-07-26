Imports Datos.Conexion
Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Public Class frmRrhh_Reportes_CheckListCalculoPlanilla
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim datosParaCombos As New Dictionary(Of String, DataTable)
    Private Sub frmCheckListCalculoPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        'cargarCombo(cboTipoMovimiento, datosParaCombos("Documentos"), 0, 2)
        cargarCombo(cboPlanilla, datosParaCombos("Planillas"), 0, 2)
        cargarCombo(cboPeriodo, datosParaCombos("Periodos"), 0, 1)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
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
            'Insertar codigo


            aux = Await Task.Run(Function() doItBaby("", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub obtenerDataParaCombos()
        ' datosParaCombos.Add("TipoMovimiento", doItBaby("sp_ObtenerDocumentosPlanilla", Nothing, TipoQuery.DataTable))
        datosParaCombos.Add("Planillas", doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        datosParaCombos.Add("Periodos", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
        'datosParaCombos.Add("SemanaDesde", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
        'datosParaCombos.Add("SemanaHasta", doItBaby("sp_ObtenerPeriodos", Nothing, TipoQuery.DataTable))
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

    Private Sub cboPeriodo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPeriodo.SelectionChangeCommitted
        If datosParaCombos.ContainsKey("Semanas") Then
            datosParaCombos.Remove("Semanas")
        End If
        If datosParaCombos.ContainsKey("SemanasHasta") Then
            datosParaCombos.Remove("SemanasHasta")
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Periodo", cboPeriodo.SelectedValue)
        p.Add("@SeleccionMultiple", "0")

        datosParaCombos.Add("Semanas", doItBaby("sp_Dg_ObtenerSemanas", p, TipoQuery.DataTable))
        datosParaCombos.Add("SemanasHasta", doItBaby("sp_Dg_ObtenerSemanas", p, TipoQuery.DataTable))

        cargarCombo(cboSemanaDesde, datosParaCombos("Semanas"), 0, 1)
        cargarCombo(cboSemanaHasta, datosParaCombos("SemanasHasta"), 0, 1)
    End Sub
End Class