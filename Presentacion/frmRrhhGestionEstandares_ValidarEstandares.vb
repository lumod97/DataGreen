Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhhGestionEstandares_ValidarEstandares
    Dim miDataSet As DataSet = New DataSet

    Private Sub frmRrhhGestionEstandares_ValidarEstandares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            dgvResultado1.DataSource = Nothing
            dgvResultado1.Columns.Clear()
            dgvResultado2.DataSource = Nothing
            dgvResultado2.Columns.Clear()
            dgvResultado3.DataSource = Nothing
            dgvResultado3.Columns.Clear()

            encenderControlesDeEspera(barProgreso, lblResultado)
            Dim aux As DataSet
            aux = Await Task.Run(Function() consultarAsync())
            dgvResultado1.DataSource = Await Task.FromResult(aux.Tables(0))
            dgvResultado2.DataSource = Await Task.FromResult(aux.Tables(1))
            dgvResultado3.DataSource = Await Task.FromResult(aux.Tables(2))
            apagarControlesDeEspera(barProgreso, lblResultado, -1)

            corregirCeldas(dgvResultado1)
            corregirCeldas(dgvResultado2)
            corregirCeldas(dgvResultado3)
            formatearDataGridView(dgvResultado1)
            formatearDataGridView(dgvResultado2)
            formatearDataGridView(dgvResultado3)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Periodo", txtPeriodo.Text)
            p.Add("@Semana", txtSemana.Text)
            p.Add("@Planilla", txtPlanilla.Text)
            r = Await Task.Run(Function() doItBaby("sp_DG_Rrhh_ValidarEstandares", p, TipoQuery.DataSet))
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado1.DataError
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

    Private Sub dgvResultado2_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado2.DataError
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

    Private Sub dgvResultado3_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado3.DataError
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