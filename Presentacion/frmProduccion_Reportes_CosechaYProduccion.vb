Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmProduccion_Reportes_CosechaYProduccion
    Dim dsResultado As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim dsDataParaCombo As DataSet

    Private Sub frmProduccion_Reportes_CosechaYProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombos()
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerCampanas", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerEtapasCampania", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("Sp_Dg_ObtenerCultivos_G", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cargarCombos()
        cargarCombo(cboCampana, dsDataParaCombo.Tables(0), "", False)
        cargarCombo(cboTipoCampana, dsDataParaCombo.Tables(1), "", True)
        cargarCombo(cboCutlivo, dsDataParaCombo.Tables(2), "", True)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResumen.DataSource = Nothing
        dgvResumen.Columns.Clear()
        dgvDetalle.DataSource = Nothing
        dgvDetalle.Columns.Clear()

        encenderControlesDeEspera(barProgreso, lblResultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())

        dgvResumen.DataSource = Await Task.FromResult(aux.Tables(0))
        dgvDetalle.DataSource = Await Task.FromResult(aux.Tables(1))

        apagarControlesDeEspera(barProgreso, lblResultado, -1)

        corregirCeldas(dgvResumen)
        corregirCeldas(dgvDetalle)

        formatearDataGridView(dgvResumen)
        formatearDataGridView(dgvDetalle)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            p.Add("@AnioCampana", cboCampana.SelectedValue)
            p.Add("@IdTipoCampana", cboTipoCampana.SelectedValue)
            p.Add("@IdCultivo", cboCutlivo.SelectedValue)
            p.Add("@Desde", dtpDesde.Value)
            p.Add("@Hasta", dtpHasta.Value)
            p.Add("@DetalleFecha", cbxDetalladoFecha.Checked)
            p.Add("@DetalleCategorias", cbxDetalladoCategoria.Checked)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Produccion_Reportes_CosechaYProduccion", p, TipoQuery.DataSet))
            dsResultado = r
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResumen.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Detalle", dgvDetalle)
        '    dDgvs.Add("Resumen", dgvResumen)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        Try
            If dgvResumen.RowCount < 1 Then
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

    Private Sub dgvResumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResumen.DataError
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

    Private Sub dgvDetalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetalle.DataError
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