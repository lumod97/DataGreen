Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmSupervision_Reportes_ContrasteAsistencias
    Dim dsResultado As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmSupervision_Reportes_ContrasteAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        'pkrDia.Value = DateTime.Today.AddDays(-1)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado_Resumen.DataSource = Nothing
        dgvResultado_Resumen.Columns.Clear()
        dgvResultado_Detalle.DataSource = Nothing
        dgvResultado_Detalle.Columns.Clear()

        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        'Dim aux As DataSet
        dsResultado = Await Task.Run(Function() consultarAsync())
        'dsResultado = aux
        dgvResultado_Resumen.DataSource = dsResultado.Tables(0) 'Await Task.FromResult(aux.Tables(0))
        dgvResultado_Detalle.DataSource = dsResultado.Tables(1) 'Await Task.FromResult(aux.Tables(1))
        'dsResultado.Tables.Add(Await Task.FromResult(aux.Tables(0).Copy))
        'dsResultado.Tables.Add(Await Task.FromResult(aux.Tables(1).Copy))

        apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)

        corregirCeldas(dgvResultado_Resumen)
        corregirCeldas(dgvResultado_Detalle)
        'corregirTabla(dsResultado.Tables(0))
        'corregirTabla(dsResultado.Tables(1))

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
            r = Await Task.Run(Function() doItBaby("sp_Dg_Supervision_Reportes_ContrasteAsistencias", p, TipoQuery.DataSet))
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvResultado_Resumen.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para exportar")
        Else
            'Dim dDgvs As New Dictionary(Of String, DataGridView)
            'dDgvs.Add("Detalle", dgvResultado_Detalle)
            'dDgvs.Add("Resumen", dgvResultado_Resumen)
            ''exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
            'excelling(dDgvs, Me.Text, arrayDeParametros)
            encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
            Dim l As New List(Of String)
            l.Add("Resumen")
            l.Add("Detalle")
            Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
            'aExcel(dsResultado, l, Me.Text, arrayDeParametros)
            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        End If
    End Sub

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