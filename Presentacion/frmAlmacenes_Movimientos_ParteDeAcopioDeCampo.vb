Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion
Public Class frmAlmacenes_Movimientos_ParteDeAcopioDeCampo

    Dim dtTablaExcel As New DataTable
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dtPersonasSeleccionadas As DataTable

    Private Sub frmAlmacenes_Movimientos_ParteDeAcopioDeCampo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaExcel.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        dtTablaExcel = cargarExcel(txtRutaExcel.Text)
        'AGREGADO
        barProgreso.Value = 0
        barProgreso.Maximum = dtTablaExcel.Rows.Count
        ''arProgreso.Style = ProgressBarStyle.Continuous
        'FIN AGREGADO
        'dgvResultado.Columns.Clear()
        'dgvResultado.Rows.Clear()
        dgvResultado.DataSource = dtTablaExcel
        'cargarTablaValidada()
        formatearDataGridView(dgvResultado)
        'dgvResultado.Rows(2).Cells(0).Style.BackColor = rojoAmarath  dgvResultado
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvResultado.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para exportar")
        Else
            encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
            Dim l As String
            l = "Reporte"
            Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
            apagarControlesDeEspera(barProgreso, lblResultado, -1)
        End If
    End Sub

    Private Async Function ProcesarAsync() As Task(Of DataTable)

        Try
            Dim p As New Dictionary(Of String, Object)
            Dim t As DataTable = obtenerTablaParaSP(dtTablaExcel)
            p.Add("@IdUsuario", usuarioActual)
            p.Add("@dtTabla", t)
            Dim r As New DataTable
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Almacenes_Reportes_ParteDeAcopioDeCampo", p, TipoQuery.DataTable))
            If Len(r.Rows(0).Item(0)) > 0 Then
                MessageBox.Show("Registro(s) guardado(s) con exito")
            ElseIf r.Rows(0).Item(0) = 0 Then
                Throw New Exception(r.Rows(0).Item(1))
            End If
            Return r

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function
    Private Function obtenerTablaParaSP(dtAux As DataTable) As DataTable
        Dim aux As New DataTable
        For i As Integer = 1 To 20 Step 1
            'If dtAux.Columns(i).ColumnName.Substring(0, 2) = "F_" Then
            '    aux.Columns.Add("C" & i.ToString, dtAux.Columns(i).DataType)
            'Else
            '    aux.Columns.Add("C" & i.ToString)
            'End If
            If i <= dtAux.Columns.Count - 1 Then
                aux.Columns.Add("C" & i.ToString, dtAux.Columns(i - 1).DataType)
            Else
                aux.Columns.Add("C" & i.ToString)
            End If
            'aux.Columns.Add("C" & i.ToString, dtAux.Columns(i).DataType)
        Next
        For i As Integer = 0 To dtAux.Rows.Count - 1 Step 1
            Dim fAux As DataRow = aux.NewRow
            For j As Integer = 0 To dtAux.Columns.Count - 1 Step 1
                'If dtAux.Columns(j).ColumnName.Substring(0, 2) = "F_" Then
                '    fAux.Item(j) = dtAux.Rows(i).Item(j).ToString("yyyy-MM-dd")
                'Else
                '    fAux.Item(j) = dtAux.Rows(i).Item(j)
                'End If
                fAux.Item(j) = dtAux.Rows(i).Item(j)
            Next
            aux.Rows.Add(fAux)
        Next
        Return aux
    End Function
    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            dgvResultado.DataSource = Nothing
            'tablaResultado = Nothing
            'dgvResultado.Columns.Clear()
            Dim dgv As Task(Of DataTable)
            encenderControlesDeEspera(barProgreso, lblResultado)
            dgv = ProcesarAsync()
            'dgvResultado.DataSource = Await dgv
            tablaResultado = Await dgv
            ''corregirTabla(tablaResultado)
            dgvResultado.DataSource = tablaResultado
            apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
            'corregirCeldas(dgvResultado)
            formatearDataGridView(dgvResultado)

            '----------------------------

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class