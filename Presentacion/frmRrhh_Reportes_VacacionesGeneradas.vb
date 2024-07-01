Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Diagnostics

Public Class frmRrhh_Reportes_VacacionesGeneradas
    Dim dsResultado As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim dsDataParaCombo As DataSet

    Private Sub frmRrhh_Reportes_VacacionesGeneradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaCombos()
        cargarCombo(cboPeriodo, dsDataParaCombo.Tables(0), 0, 2)
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(1), 0, 2)
        radPlanilla.Checked = True
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerPeriodosAnuales", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        CheckForIllegalCrossThreadCalls = False
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        dgvDetalle.DataSource = Nothing
        dgvDetalle.Columns.Clear()
        encenderControlesDeEspera(barProgreso, lblResultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())
        dgvResultado.DataSource = Await Task.FromResult(aux.Tables(0))
        dgvDetalle.DataSource = Await Task.FromResult(aux.Tables(1))
        apagarControlesDeEspera(barProgreso, lblResultado, -1)
        corregirCeldas(dgvResultado)
        corregirCeldas(dgvDetalle)
        formatearDataGridView(dgvResultado)
        formatearDataGridView(dgvDetalle)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo", cboPeriodo.SelectedValue)
            p.Add("@IdPlanilla", cboPlanilla.SelectedValue)
            p.Add("@IdCodigoGeneral", txtCodigo.Text)
            p.Add("@DevuelveTabla", 1)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_VacacionesGeneradas", p, TipoQuery.DataSet))
            dsResultado = r
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("Resumen")
                l.Add("Detalle")
                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub dgvDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
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

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetalle.DataError
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

    Private Sub radPlanilla_CheckedChanged(sender As Object, e As EventArgs) Handles radPlanilla.CheckedChanged
        If radPlanilla.Checked Then
            cboPlanilla.Enabled = True
            txtCodigo.Enabled = False
            txtCodigo.Text = "********"
        Else
            cboPlanilla.Enabled = False
            txtCodigo.Text = ""
            txtCodigo.Enabled = True
        End If
    End Sub

    Private Sub radCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles radCodigo.CheckedChanged
        If radCodigo.Checked Then
            cboPlanilla.Enabled = False
            txtCodigo.Text = ""
            txtCodigo.Enabled = True
        Else
            cboPlanilla.Enabled = True
            txtCodigo.Enabled = False
            txtCodigo.Text = "********"
        End If
    End Sub


End Class