Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_RegistrarAltasMasivas
    Dim dsMetaDatos As New DataSet
    Dim dtTablaExcel As New DataTable
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmRrhh_Movimientos_RegistrarAltasMasivas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerMetaDatos()
        cargarCombo(cboTablas, dsMetaDatos.Tables(0), "", False)
        aplicarTema(Me)
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
        barProgreso.Style = ProgressBarStyle.Continuous
        'FIN AGREGADO
        'dgvResultado.Columns.Clear()
        'dgvResultado.Rows.Clear()
        dgvResultado.DataSource = Nothing
        cargarTablaValidada()
        formatearDataGridView(dgvResultado)
        'dgvResultado.Rows(2).Cells(0).Style.BackColor = rojoAmarath
    End Sub

    Private Sub obtenerMetaDatos()
        dsMetaDatos = doItBaby("DataGreenTest..sp_Dg_Rrhh_Movimientos_AltasMasivas_ObtenerMetaDatos", Nothing, TipoQuery.DataSet)
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        'arrayDeParametros = obtenerCadenaParametros(p)
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        dgvResultado.DataSource = dsMetaDatos.Tables(cboTablas.SelectedValue)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, cboTablas.DisplayMember)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, cboTablas.DisplayMember)
        'End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(dtTablaExcel, l, Me.Text, arrayDeParametros))
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

    Private Sub cargarTablaValidada()
        Dim datoValido As Boolean
        Dim observaciones As String = String.Empty
        'esta lista continen las columnas del excel que se van a evaluar
        Dim listaColumnasAValidar As New Dictionary(Of Integer, Integer)
        listaColumnasAValidar.Add(10, 1)
        listaColumnasAValidar.Add(18, 2)
        listaColumnasAValidar.Add(22, 3)
        listaColumnasAValidar.Add(26, 4)
        listaColumnasAValidar.Add(28, 5)
        listaColumnasAValidar.Add(31, 6)
        listaColumnasAValidar.Add(38, 7)
        listaColumnasAValidar.Add(42, 8)
        listaColumnasAValidar.Add(45, 9)
        dgvResultado.DataSource = dtTablaExcel
        For i As Integer = 0 To dgvResultado.RowCount - 1 Step 1
            datoValido = False
            For j As Integer = 0 To dgvResultado.ColumnCount - 1 Step 1
                If listaColumnasAValidar.ContainsKey(j + 1) Then
                    For k As Integer = 0 To dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows.Count - 1 Step 1
                        Try
                            If dtTablaExcel.Rows(i).Item(j) = dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows(k).Item(0) Then
                                datoValido = True
                                Exit For
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message & "-" & dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows(0).Item(1))
                        End Try
                    Next
                    If Not datoValido Then
                        dgvResultado.Rows(i).Cells(j).Style.BackColor = rosaBlanco_
                        observaciones = "Corregir"
                    Else
                        dgvResultado.Rows(i).Cells(j + 1).Value = dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Compute("MAX(Descripcion)", "T_Id = '" + dtTablaExcel.Rows(i).Item(j) + "'")
                    End If
                    datoValido = False
                End If
            Next
            If observaciones = "Corregir" Then
                dgvResultado.Rows(i).Cells(54).Style.BackColor = rosaBlanco_
                dgvResultado.Rows(i).Cells(54).Value = observaciones
            Else
                dgvResultado.Rows(i).Cells(54).Style.BackColor = verderCian_
                dgvResultado.Rows(i).Cells(54).Value = "Listo!"
            End If
            observaciones = String.Empty
        Next
        dgvResultado.ClearSelection()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If dgvResultado.RowCount < 1 Or dgvResultado.ColumnCount <> 55 Then
            MessageBox.Show("La tabla no esta cargada correctamente.")
            Exit Sub
        End If
        barProgreso.Value = 0
        barProgreso.Maximum = dgvResultado.RowCount
        barProgreso.Style = ProgressBarStyle.Continuous
        Dim n As Integer = 0, m As Integer = 0
        n = dgvResultado.RowCount
        For Each fila As DataGridViewRow In dgvResultado.Rows
            If fila.Cells(54).Value = "Listo!" Then
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
            If fila.Cells(54).Value = "Listo!" Then
                For i As Integer = 0 To dgvResultado.ColumnCount - 1 Step 1
                    cadenaParametros = cadenaParametros & fila.Cells(i).Value & "█"
                Next
                p.Add("@Cadena", cadenaParametros)
                resultadoQuery = doItBaby("sp_Dg_Rrhh_Movimientos_RegistrarAltasMasivas", p, TipoQuery.Scalar)
                CheckForIllegalCrossThreadCalls = False
                barProgreso.Value += 1
                barProgreso.Refresh()
                If resultadoQuery.Substring(0, 2) = "Ok" Then
                    fila.Cells(1).Value = resultadoQuery.Substring(2)
                    fila.Cells(54).Value = "Procesado!"
                    n += 1
                Else
                    'fila.Cells(1).Value = resultadoQuery.Substring(0, 5)
                    fila.Cells(54).Value = resultadoQuery
                    m += 1
                End If
                p.Clear()
                cadenaParametros = String.Empty
            End If
        Next
        MessageBox.Show(n.ToString + " Trabajadores procesados correctamente, " + vbNewLine + m.ToString + " Trabajadores con errores.")
    End Sub

End Class
