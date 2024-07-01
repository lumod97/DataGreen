
Imports Logica.Utiles
Imports Logica.Funciones
Imports Datos.Conexion
Imports Entidades
Imports Entidades.Temporales


Public Class frmPacking_Reportes_UsabilidadCodigos

    Dim dtDataParaCombo As DataTable
    Dim dtPedidos, dtPedidosDetalle As DataTable
    Dim tablaResultado As DataTable
    Dim tablaResultadoDetalle As DataTable
    Dim miPedido As PedidoServicioTransportes
    Dim arrayDeParametros As String = String.Empty
    Dim cadena As String = String.Empty
    Public servicioActual As New ServicioTransporte
    Dim observaciones As String = String.Empty

    Private Sub frmFitosanidad_RepAplicaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpDesde.Value = Date.Now.AddDays(-Now.Day + 1)
        dtpHasta.Value = Date.Now.AddDays(-Now.Day + 1).AddMonths(1).AddDays(-1)
        aplicarTema(Me)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)

        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", CType(dtpDesde.Value.ToString("dd/MM/yyyy"), DateTime))
            p.Add("@Hasta", CType(dtpHasta.Value.ToString("dd/MM/yyyy"), DateTime))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Reportes_UsabilidadCodigos", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try


    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '     MessageBox.Show("Error, no hay registros para exportar")
        ' Else
        '     'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '     Dim dDgvs As New Dictionary(Of String, DataGridView)
        '     dDgvs.Add("Reporte", dgvResultado)
        '     excelling(dDgvs, Me.Text, arrayDeParametros)
        ' End If
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