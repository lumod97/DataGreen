Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Public Class frmSupervision_Reportes_DetalleDiarioXSupuervisorGMO
    Dim dsResultado As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmSupervision_Reportes_DetalleDiarioXSupuervisorGMO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'pkrDia.Value = DateTime.Today.AddDays(-1)
        aplicarTema(Me)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado_Resumen.DataSource = Nothing
        dgvResultado_Resumen.Columns.Clear()
        dgvResultado_Detalle.DataSource = Nothing
        dgvResultado_Detalle.Columns.Clear()

        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())

        dgvResultado_Resumen.DataSource = Await Task.FromResult(aux.Tables(0))
        dgvResultado_Detalle.DataSource = Await Task.FromResult(aux.Tables(1))

        apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)

        corregirCeldas(dgvResultado_Resumen)
        corregirCeldas(dgvResultado_Detalle)
        
        formatearDataGridView(dgvResultado_Resumen)
        formatearDataGridView(dgvResultado_Detalle)
        
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", dtpDesde.Value)
            p.Add("@Hasta", dtpHasta.Value)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Supervision_Reportes_DetalleDiarioXSupuervisorGMO", p, TipoQuery.DataSet))
            dsResultado = r
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResultado_Resumen.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("Resumen")
                l.Add("Detalle")
                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'If dgvResultado_Resumen.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Detalle", dgvResultado_Detalle)
        '    dDgvs.Add("Resumen", dgvResultado_Resumen)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        'MODIFICACIONEXPORTAREXCEL()
        'Dim titulo As String = "", subtitulo As String = ""
        'titulo = Me.Text + ": Usuario[" + usuarioActual + "] Fecha[" + DateTime.Now.ToString("G") + "]"
        'subtitulo = arrayDeParametros
        'If dgvResultado_Resumen.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dGVs As New List(Of DataGridView)
        '    dGVs.Add(dgvResultado_Resumen)
        '    dGVs.Add(dgvResultado_Detalle)
        '    exportarExcel(dGVs, titulo, subtitulo)
        '    'dgvResultado_Resumen.ClearSelection()
        'End If


        'Dim tab As String = tabResultado.SelectedTab.Text
        'Dim titulo As String = "", subtitulo As String = ""
        'titulo = Me.Text + ": Usuario[" + usuarioActual + "] Fecha[" + DateTime.Now.ToString("G") + "]"
        'subtitulo = arrayDeParametros
        'Select Case tab
        '    Case "Insumos"
        '        If dgvInsumos.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvInsumos, titulo, subtitulo)
        '            dgvInsumos.ClearSelection()
        '        End If
        '    Case "Mano de Obra"
        '        If dgvManoObra.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvManoObra, titulo, subtitulo)
        '            dgvManoObra.ClearSelection()
        '        End If
        '    Case "Gastos"
        '        If dgvGastos.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvGastos, titulo, subtitulo)
        '            dgvGastos.ClearSelection()
        '        End If
        '    Case "Maquinaria"
        '        If dgvMaquinaria.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvMaquinaria, titulo, subtitulo)
        '            dgvMaquinaria.ClearSelection()
        '        End If
        '    Case "Otros"
        '        If dgvOtros.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvOtros, titulo, subtitulo)
        '            dgvOtros.ClearSelection()
        '        End If
        'End Select
    End Sub

    'Private Sub dgvEstadoDias_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvEstadoDias.DataError
    '    If (e.Context = DataGridViewDataErrorContexts.Commit) Then
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
    '        MessageBox.Show("Cell change")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
    '        MessageBox.Show("parsing error")
    '    End If
    '    If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
    '        MessageBox.Show("leave control error")
    '    End If
    '    If (TypeOf (e.Exception) Is ConstraintException) Then
    '        Dim view As DataGridView = CType(sender, DataGridView)
    '        view.Rows(e.RowIndex).ErrorText = "an error"
    '        view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
    '        e.ThrowException = False
    '    End If
    'End Sub


    Private Sub dgvResultado_Resumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Resumen.DataError
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

    Private Sub dgvResultado_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Detalle.DataError
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
End Class