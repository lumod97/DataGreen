Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmPacking_Movimientos_FusionarCajasBifurcadas
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    Dim filas As List(Of DataGridViewRow) = New List(Of DataGridViewRow)
    Dim ultimaFilaSeleccionada As Char = "B"

    Private Sub frmPacking_Movimientos_FusionarCajasBifurcadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        tlpMatch.Visible = False
        Me.WindowState = FormWindowState.Maximized
        'obtenerDataParaCombos()
        'cargarCombo(cboTipoEvaluacion, dsDataParaCombo.Tables(0), "", True)
        'cargarCombo(cboLote, dsDataParaCombo.Tables(1), "", True)
        aplicarTema(Me)
        btnFusionar.Enabled = False
        limpiarTlpMatch()
        tlpPrincipal.Visible = True
        tlpMatch.Visible = True
        'tlpMatch.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        'Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub limpiarTlpMatch()
        lblLineaA.Text = ""
        lblIdPalletA.Text = ""
        lblNroCajaA.Text = ""
        lblSeleccionA.Text = ""
        lblPesadoA.Text = ""
        lblEmpaqueA.Text = ""
        lblCultivoA.Text = ""
        lblVariedadA.Text = ""
        lblFormatoA.Text = ""
        lblLineaB.Text = ""
        lblIdPalletB.Text = ""
        lblNroCajaB.Text = ""
        lblSeleccionB.Text = ""
        lblPesadoB.Text = ""
        lblEmpaqueB.Text = ""
        lblCultivoB.Text = ""
        lblVariedadB.Text = ""
        lblFormatoB.Text = ""
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
        limpiarTlpMatch()
        colorearEtiquetasFactibilidad()
        dgvResultado.ClearSelection()
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", dtpFecha.Value.ToString("yyyy-MM-dd"))
            p.Add("@SoloCajasBifurcadas", cbxSoloCajasBifurcadas.Checked)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_FusionarCajasBifurcadas_ObtenerCajas", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If
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

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 Then
            filas.Add(dgvResultado.Rows(e.RowIndex))
            If filas.Count > 2 Then
                filas.RemoveAt(0)
            End If
            resaltarFilasSeleccionadas()
            ultimaFilaSeleccionada = IIf(ultimaFilaSeleccionada = "" Or ultimaFilaSeleccionada = "B", "A", "B")
            actualizarTlpMatch(dgvResultado.Rows(e.RowIndex))
            validarSiEsFusionable()
            colorearEtiquetasFactibilidad()
            gestionarBotonFusionar()
            'filaA = dgvResultado.Rows(e.RowIndex)
            'dgvResultado.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvResultado.DefaultCellStyle.BackColor
            'MessageBox.Show(dgvResultado.Rows(e.RowIndex))
        End If
    End Sub

    Private Sub resaltarFilasSeleccionadas()
        Try
            'Dim i As Integer = 0
            'For i = 0 To dgvResultado.Rows.Count - 1 Step 1
            '    If dgvResultado.Rows(i).Equals(filas(0)) Or dgvResultado.Rows(i).Equals(filas(1)) Then
            '        dgvResultado.Rows(i).DefaultCellStyle.BackColor = dgvResultado.DefaultCellStyle.SelectionBackColor
            '        Exit Sub
            '    End If
            'Next
            For Each f As DataGridViewRow In dgvResultado.Rows
                If f.Equals(filas(0)) OrElse f.Equals(filas(1)) Then
                    f.DefaultCellStyle.BackColor = dgvResultado.DefaultCellStyle.SelectionBackColor
                    'MessageBox.Show("Encontrada")
                Else
                    f.DefaultCellStyle.BackColor = dgvResultado.DefaultCellStyle.BackColor
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub actualizarTlpMatch(fila As DataGridViewRow)
        If ultimaFilaSeleccionada = "A" Then
            lblLineaA.Text = fila.Cells(1).Value.ToString
            lblIdPalletA.Text = fila.Cells(2).Value.ToString
            lblNroCajaA.Text = fila.Cells(3).Value.ToString
            lblSeleccionA.Text = fila.Cells(4).Value.ToString
            lblPesadoA.Text = fila.Cells(5).Value.ToString
            lblEmpaqueA.Text = fila.Cells(6).Value.ToString
            lblCultivoA.Text = fila.Cells(7).Value.ToString & " - " & fila.Cells(8).Value.ToString
            lblVariedadA.Text = fila.Cells(9).Value.ToString & " - " & fila.Cells(10).Value.ToString
            lblFormatoA.Text = fila.Cells(11).Value.ToString & " - " & fila.Cells(12).Value.ToString
        ElseIf ultimaFilaSeleccionada = "B" Then
            lblLineaB.Text = fila.Cells(1).Value.ToString
            lblIdPalletB.Text = fila.Cells(2).Value.ToString
            lblNroCajaB.Text = fila.Cells(3).Value.ToString
            lblSeleccionB.Text = fila.Cells(4).Value.ToString
            lblPesadoB.Text = fila.Cells(5).Value.ToString
            lblEmpaqueB.Text = fila.Cells(6).Value.ToString
            lblCultivoB.Text = fila.Cells(7).Value.ToString & " - " & fila.Cells(8).Value.ToString
            lblVariedadB.Text = fila.Cells(9).Value.ToString & " - " & fila.Cells(10).Value.ToString
            lblFormatoB.Text = fila.Cells(11).Value.ToString & " - " & fila.Cells(12).Value.ToString
        End If
    End Sub

    Private Sub validarSiEsFusionable()
        lblFactLinea.Text = IIf(lblLineaA.Text = lblLineaB.Text, "Ok", "Error")
        lblFactIdPallet.Text = "Ok" 'IIf(lblLineaA.Text = lblLineaB.Text, "Ok", "Er")
        lblFactNroCaja.Text = "Ok" 'IIf(lblLineaA.Text = lblLineaB.Text, "Ok", "Er")
        lblFactSeleccion.Text = IIf(String.Concat(lblSeleccionA.Text, lblSeleccionB.Text).Length <= 10, "Ok", "Error")
        lblFactPesado.Text = IIf(String.Concat(lblPesadoA.Text, lblPesadoB.Text).Length <= 10, "Ok", "Error")
        lblFactEmpaque.Text = IIf(String.Concat(lblEmpaqueA.Text, lblEmpaqueB.Text).Length <= 10, "Ok", "Error")
        lblFactCultivo.Text = IIf(lblCultivoA.Text = lblCultivoB.Text, "Ok", "Error")
        lblFactVariedad.Text = IIf(lblVariedadA.Text = lblVariedadB.Text, "Ok", "Error")
        lblFactFormato.Text = IIf(lblFormatoA.Text = lblFormatoB.Text, "Ok", "Error")
    End Sub

    Private Sub colorearEtiquetasFactibilidad()
        lblFactLinea.BackColor = IIf(lblFactLinea.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactIdPallet.BackColor = IIf(lblFactIdPallet.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactNroCaja.BackColor = IIf(lblFactNroCaja.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactSeleccion.BackColor = IIf(lblFactSeleccion.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactPesado.BackColor = IIf(lblFactPesado.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactEmpaque.BackColor = IIf(lblFactEmpaque.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactCultivo.BackColor = IIf(lblFactCultivo.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactVariedad.BackColor = IIf(lblFactVariedad.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
        lblFactFormato.BackColor = IIf(lblFactFormato.Text = "Ok", lblCultivoA.BackColor, rojoAmarath)
    End Sub

    Private Sub gestionarBotonFusionar()
        If lblFactLinea.Text = "Ok" And _
            lblFactIdPallet.Text = "Ok" And _
            lblFactNroCaja.Text = "Ok" And _
            lblFactSeleccion.Text = "Ok" And _
            lblFactPesado.Text = "Ok" And _
            lblFactEmpaque.Text = "Ok" And _
            lblFactCultivo.Text = "Ok" And _
            lblFactVariedad.Text = "Ok" And _
            lblFactFormato.Text = "Ok" Then
            btnFusionar.Enabled = True
        Else
            btnFusionar.Enabled = False
        End If
    End Sub

    Private Sub btnFusionar_Click(sender As Object, e As EventArgs) Handles btnFusionar.Click
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdPallet1", lblIdPalletA.Text)
            p.Add("@NroCaja1", lblNroCajaA.Text)
            p.Add("@IdPallet2", lblIdPalletB.Text)
            p.Add("@NroCaja2", lblNroCajaB.Text)
            p.Add("@IdUsuario", usuarioActual)
            arrayDeParametros = obtenerCadenaParametros(p)
            Dim r As String = doItBaby("sp_Dg_Packing_Movimientos_FusionarCajasBifurcadas_FusionarCajas", p, TipoQuery.Scalar)
            If r = "OK" Then
                MessageBox.Show("Cajas fusionadas correctamente.")
            Else
                'MessageBox.Show(r)
                Throw New Exception(r)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            btnConsultar_Click(New Object, New EventArgs)
        End Try
    End Sub


End Class