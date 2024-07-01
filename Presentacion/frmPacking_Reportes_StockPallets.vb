Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPacking_Reportes_StockPallets
    Dim arrayDeParametros As String = String.Empty
    Dim dsResultado As DataSet
    Dim dsDataParaCombo As DataSet

    Private Sub frmPacking_Reportes_SeguimientoPlanComercial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboCultivo, dsDataParaCombo.Tables(0), "", True)
        aplicarTema(Me)
        'dgvResultado_Detalle.EditMode = DataGridViewEditMode.EditOnEnter
        'dgvResultado_Detalle.AllowUserToAddRows = True
        'dgvResultado_Detalle.SelectionMode = DataGridViewSelectionMode.CellSelect
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_Gen_ObtenerCultivosCampanasPacking", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cboCultivo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted
        For i As Integer = 1 To dsDataParaCombo.Tables.Count - 1 Step 1
            dsDataParaCombo.Tables.RemoveAt(i)
        Next
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_Gen_ObtenerCampanasPackingXCultivo", p, TipoQuery.DataTable))
        cargarCombo(cboCampanaPacking, dsDataParaCombo.Tables(1), "", True)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado_Resumen.DataSource = Nothing
        dgvResultado_Detalle.DataSource = Nothing
        dsResultado = Nothing
        dgvResultado_Resumen.Columns.Clear()
        dgvResultado_Detalle.Columns.Clear()
        Dim dgv As Task(Of DataSet)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        dsResultado = Await dgv
        corregirTabla(dsResultado.Tables(0))
        corregirTabla(dsResultado.Tables(1))
        dgvResultado_Resumen.DataSource = dsResultado.Tables(0)
        dgvResultado_Detalle.DataSource = dsResultado.Tables(1)
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado_Resumen.RowCount)
        corregirCeldas(dgvResultado_Resumen)
        corregirCeldas(dgvResultado_Detalle)
        formatearDataGridView(dgvResultado_Resumen, True)
        formatearDataGridView(dgvResultado_Detalle, True)

    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim aux As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", dtpFecha.Value)
            p.Add("@CodCampana", cboCampanaPacking.SelectedValue)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Reportes_StockPallets", p, TipoQuery.DataSet))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado_Resumen.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Detalle", dgvResultado_Detalle)
        '    dDgvs.Add("Resumen", dgvResultado_Resumen)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    'exportarExcel(dgvResultado_Resumen, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
        Try
            If dgvResultado_Detalle.RowCount < 1 Then
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

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Resumen.DataError
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