Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmLogistica_Reportes_TransportePersonalXConsumidor

    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultados As DataTable


    Private Sub frmLogistica_Reportes_TransportePersonalXConsumidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        tlpPrincipal.Visible = True

    End Sub

    Private Async Function ConsultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", CType(dtpDesde.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@Hasta", CType(dtpHasta.Value.ToString("dd/MM/yyyy"), DateTime))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Logistica_Reportes_Transporte_Personal_Consumidor", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultados = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = ConsultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultados = Await dgv
        corregirTabla(tablaResultados)
        dgvResultado.DataSource = tablaResultados
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        formatearDataGridView(dgvResultado)

    End Sub
    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultados, l, Me.Text, arrayDeParametros))
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
End Class

