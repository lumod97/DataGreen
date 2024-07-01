Imports Logica.Utiles
Imports Logica.Funciones
Imports Datos.Conexion
Imports Entidades.Temporales

Public Class frmPacking_Movimientos_HorasADistribuir
    Dim dtTablaExcel As DataTable
    Dim TablaResultado As DataTable
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmPacking_Movimientos_HorasADistribuir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", dtpDia.Value.ToString("yyyy-MM-dd"))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Packing_Movimientos_HorasADsitribuir_ConsultarDia", p, TipoQuery.DataTable))
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
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(TablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
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

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaExcel.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub


    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            dtTablaExcel = Nothing
            dgvResultado.DataSource = Nothing
            dtTablaExcel = cargarExcel(txtRutaExcel.Text)
            'AGREGADO
            'barProgreso.Value = 0
            'barProgreso.Maximum = dtTablaExcel.Rows.Count
            'barProgreso.Style = ProgressBarStyle.Marquee
            barProgreso.MarqueeAnimationSpeed = 5
            'barProgreso.
            'FIN AGREGADO
            'dgvResultado.Columns.Clear()
            'dgvResultado.Rows.Clear()
            dgvResultado.DataSource = dtTablaExcel
            'cargarTablaValidada()
            formatearDataGridView(dgvResultado)
            'dgvResultado.Rows(2).Cells(0).Style.BackColor = rojoAmarath
            Dim totalHoras As Double = dtTablaExcel.Compute("SUM(D2Horas)", String.Empty)
            lblTotalHoras.Text = totalHoras.ToString("F2")
            lblResultado.Text = "Registros: " & dgvResultado.RowCount
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("La tabla no esta cargada correctamente.")
                Exit Sub
            End If
            barProgreso.Value = 0
            barProgreso.Maximum = dgvResultado.RowCount
            barProgreso.Style = ProgressBarStyle.Continuous
            Dim nOks As Integer = 0, nErrores As Integer = 0
            nOks = dgvResultado.RowCount

            Dim respuesta As DialogResult = MessageBox.Show("Seguro que desea procesar " + nOks.ToString + " registros totales?", "Confirmar", MessageBoxButtons.YesNo)
            If respuesta = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            nOks = 0
            nErrores = 0
            Dim resultadoQuery As String = String.Empty
            Dim cadenaParametros As String = String.Empty
            Dim p As New Dictionary(Of String, Object)
            CheckForIllegalCrossThreadCalls = False
            For Each fila As DataGridViewRow In dgvResultado.Rows
                cadenaParametros = CType(fila.Cells(0).Value, Date).ToString("yyyy-MM-dd") & "|"
                For i As Integer = 1 To dgvResultado.ColumnCount - 1 Step 1
                    cadenaParametros = cadenaParametros & fila.Cells(i).Value & "|"
                Next
                p.Add("@CadenaParametros", cadenaParametros)
                p.Add("@IdUsuario", usuarioActual)
                resultadoQuery = doItBaby("sp_Dg_Packing_Movimientos_HorasADsitribuir_CargarHoras", p, TipoQuery.Scalar)
                barProgreso.Value += 1
                barProgreso.Refresh()
                fila.Cells(3).Value = resultadoQuery
                If resultadoQuery = "Ok" Then
                    nOks += 1
                Else
                    nErrores += 1
                End If
                p.Clear()
                cadenaParametros = String.Empty
            Next
            MessageBox.Show(nOks.ToString + " Registros procesados correctamente, " + vbNewLine + nErrores.ToString + " Registros con errores.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class