Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion
Imports System.IO

Public Class frmCostos_Procesos_ActualizarDataCosteo
    Dim tablaResultado As New DataTable
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmCostos_Procesos_ActualizarDataCosteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        tlpPrincipal.Visible = True
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
        Try
            Dim dtTablaExcel As New DataTable
            dtTablaExcel = cargarExcel(txtRutaExcel.Text)
            corregirTabla(dtTablaExcel)
            'barProgreso.Value = 0
            'barProgreso.Maximum = dtTablaExcel.Rows.Count
            'barProgreso.Style = ProgressBarStyle.Continuous
            tablaResultado = dtTablaExcel
            dgvResultado.DataSource = tablaResultado
            verificarObservaciones()
            verificarDisponibilidadDeDias()
            colorearObservaciones()
            formatearDataGridView(dgvResultado)
            lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
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

    Private Sub verificarObservaciones()
        Dim listo As Boolean
        For Each fila As DataGridViewRow In dgvResultado.Rows
            listo = True
            If fila.Cells(0).Value.ToString = "MAQ" Then
                For Each item As DataGridViewCell In fila.Cells
                    If item.Value.ToString = "" Then
                        If item.ColumnIndex <> 11 And item.ColumnIndex <> 4 And item.ColumnIndex <> 5 And item.ColumnIndex <> 6 Then
                            fila.Cells(11).Value = "Error! Valor en blanco en columna " & (item.ColumnIndex + 1).ToString
                            listo = False
                            Exit For
                        End If
                    End If
                Next
                If Not IsDate(fila.Cells(1).Value.ToString) Then
                    fila.Cells(11).Value = "Error! Formato de fecha."
                    listo = False
                    Exit For
                End If
                If listo Then
                    fila.Cells(11).Value = "Listo!"
                End If
            ElseIf fila.Cells(0).Value.ToString = "OBR" Then
                For Each item As DataGridViewCell In fila.Cells
                    If item.Value.ToString = "" Then
                        If item.ColumnIndex <> 6 And item.ColumnIndex <> 7 And item.ColumnIndex <> 11 And item.ColumnIndex <> 4 And item.ColumnIndex <> 5 And item.ColumnIndex <> 6 Then
                            fila.Cells(11).Value = "Error! Valor en blanco en columna " & (item.ColumnIndex + 1).ToString
                            listo = False
                            Exit For
                        End If
                    End If
                Next
                If Not IsDate(fila.Cells(1).Value.ToString) Then
                    fila.Cells(11).Value = "Error! Formato de fecha."
                    listo = False
                    Exit For
                End If
                If listo Then
                    fila.Cells(11).Value = "Listo!"
                End If
            ElseIf fila.Cells(0).Value.ToString = "INS" Then
                For Each item As DataGridViewCell In fila.Cells
                    If item.Value.ToString = "" Then
                        If item.ColumnIndex <> 7 And item.ColumnIndex <> 11 And item.ColumnIndex <> 4 And item.ColumnIndex <> 5 And item.ColumnIndex <> 6 Then
                            fila.Cells(11).Value = "Error! valor en blanco en columna " & (item.ColumnIndex + 1).ToString
                            listo = False
                            Exit For
                        End If
                    End If
                Next
                If Not IsDate(fila.Cells(1).Value.ToString) Then
                    fila.Cells(11).Value = "Error! Formato de fecha."
                    listo = False
                    Exit For
                End If
                If listo Then
                    fila.Cells(11).Value = "Listo!"
                End If
            End If
        Next
    End Sub

    Private Sub colorearObservaciones()
        For Each fila As DataGridViewRow In dgvResultado.Rows
            If InStr(fila.Cells(11).Value.ToString, "Listo!") > 0 Or InStr(fila.Cells(11).Value.ToString, "Ok!") > 0 Then
                fila.Cells(11).Style.BackColor = verderCian_
            ElseIf InStr(fila.Cells(11).Value.ToString, "Error!") > 0 Then
                fila.Cells(11).Style.BackColor = rosaBlanco_
            End If
        Next
    End Sub

    'MANEJAR A NIVEL SQL EL RETORNO DEL ID DE OPERACION DE CADA PROCESO Y ENVIARLO A LA COLUMNA OBSERVACION => DONE!
    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If dgvResultado.RowCount < 1 Or dgvResultado.ColumnCount <> 12 Then
            MessageBox.Show("La tabla no esta cargada correctamente.")
            Exit Sub
        End If
        barProgreso.Value = 0
        barProgreso.Maximum = dgvResultado.RowCount
        barProgreso.Style = ProgressBarStyle.Continuous
        Dim n As Integer = 0, m As Integer = 0
        n = dgvResultado.RowCount
        For Each fila As DataGridViewRow In dgvResultado.Rows
            If fila.Cells(11).Value = "Listo!" Then
                m += 1
            End If
        Next
        Dim respuesta As DialogResult = MessageBox.Show("Seguro que desea procesar " + m.ToString + " registros validos de " + n.ToString + " Registros totales?", "Confirmar", MessageBoxButtons.YesNo)
        If respuesta = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        n = 0
        m = 0
        Dim resultadoQuery As String = String.Empty
        Dim cadenaParametros As String = String.Empty
        Dim p As New Dictionary(Of String, Object)
        For Each fila As DataGridViewRow In dgvResultado.Rows
            If fila.Cells("Observacion").Value = "Listo!" Then
                For i As Integer = 0 To dgvResultado.ColumnCount - 2 Step 1
                    If i = 1 Then
                        cadenaParametros = cadenaParametros & CType(fila.Cells(i).Value.ToString, Date).ToString("yyyy-MM-dd") & "!"
                    Else
                        cadenaParametros = cadenaParametros & fila.Cells(i).Value & "!"
                    End If
                Next
                cadenaParametros = cadenaParametros & usuarioActual
                p.Add("@CadenaParametros", cadenaParametros)
                arrayDeParametros = obtenerCadenaParametros(p)
                resultadoQuery = doItBaby("sp_Dg_Costos_Procesos_ActualizarDataCosteo", p, TipoQuery.Scalar)
                fila.Cells(11).Value = resultadoQuery
                If resultadoQuery.Substring(0, 3) = "Ok!" Then
                    'fila.Cells(1).Value = resultadoQuery.Substring(2)
                    'fila.Cells(11).Value = resultadoQuery.Substring(3, resultadoQuery.Length - 3)
                    n += 1
                Else
                    'fila.Cells(1).Value = resultadoQuery.Substring(0, 5)
                    'fila.Cells(11).Value = resultadoQuery
                    m += 1
                End If
                p.Clear()
                cadenaParametros = String.Empty
                CheckForIllegalCrossThreadCalls = False
                barProgreso.Value += 1
                barProgreso.Refresh()
            End If
        Next
        MessageBox.Show(n.ToString + " Registros procesados correctamente, " + vbNewLine + m.ToString + " Registros con errores.")
    End Sub


    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '     MessageBox.Show("Error, no hay registros para exportar")
        ' Else
        '     'exportarExcel(dgvResultado, Me.Text, txtRutaExcel.Text)
        '     Dim dDgvs As New Dictionary(Of String, DataGridView)
        '     dDgvs.Add("Reporte", dgvResultado)
        '     excelling(dDgvs, Me.Text, txtRutaExcel.Text)
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

    Private Sub verificarDisponibilidadDeDias()
        Dim dia As Date
        Dim p As New Dictionary(Of String, Object)
        For Each fila As DataGridViewRow In dgvResultado.Rows
            dia = CType(fila.Cells(1).Value, Date)
            p.Add("@Modulo", "Costos")
            p.Add("@Dia", dia.ToString("yyyy-MM-dd"))
            If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
                fila.Cells(11).Value = "Error! Dia cerrado."
            End If
            p.Clear()
        Next
    End Sub

End Class