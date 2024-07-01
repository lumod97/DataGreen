Imports Logica.Utiles
Imports Datos.Conexion
Imports Logica.Funciones
Imports Entidades.Temporales

Public Class frmPacking_Movimientos_GenerarCodigosPacking_ListaCodigosExportables
    Dim dtCodigosExportables As DataTable

    Private Sub frmPacking_Movimientos_GenerarCodigosPacking_ListaCodigosExportables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aplicarTema(Me)
        dtCodigosExportables = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_ExportarCodigos", Nothing, TipoQuery.DataTable)
        dgvResultado.DataSource = dtCodigosExportables
        'corregirTabla(dtCodigosExportables)
        formatearDataGridView(dgvResultado)
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
                encenderControlesDeEspera(barProgreso, lbl_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(dtCodigosExportables, l, Me.Text, Nothing))
                apagarControlesDeEspera(barProgreso, lbl_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmPacking_Movimientos_GenerarCodigosPacking_ListaCodigosExportables_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim respuesta As DialogResult
        respuesta = MessageBox.Show("Esta seguro de cerrar la ventana?", "Cerrar Ventana", MessageBoxButtons.YesNo)
        If respuesta = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub


End Class