Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion


Public Class frmFitosanidad_Movimientos_CrearProgramasSemanales_CargarNuevosProgramas
    Dim dsMetaDatos As New DataSet
    Dim dtTablaExcel As New DataTable
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable

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
        dgvResultado.DataSource = dtTablaExcel
        'cargarTablaValidada()
        formatearDataGridView(dgvResultado)
        'dgvResultado.Rows(2).Cells(0).Style.BackColor = rojoAmarath
    End Sub


    'Private Sub cargarTablaValidada()
    '    Dim datoValido As Boolean
    '    Dim observaciones As String = String.Empty
    '    'esta lista continen las columnas del excel que se van a evaluar
    '    Dim listaColumnasAValidar As New Dictionary(Of Integer, Integer)
    '    listaColumnasAValidar.Add(10, 1)
    '    listaColumnasAValidar.Add(18, 2)
    '    listaColumnasAValidar.Add(22, 3)
    '    listaColumnasAValidar.Add(26, 4)
    '    listaColumnasAValidar.Add(28, 5)
    '    listaColumnasAValidar.Add(31, 6)
    '    listaColumnasAValidar.Add(38, 7)
    '    listaColumnasAValidar.Add(42, 8)
    '    listaColumnasAValidar.Add(45, 9)
    '    dgvResultado.DataSource = dtTablaExcel
    '    For i As Integer = 0 To dgvResultado.RowCount - 1 Step 1
    '        datoValido = False
    '        For j As Integer = 0 To dgvResultado.ColumnCount - 1 Step 1
    '            If listaColumnasAValidar.ContainsKey(j + 1) Then
    '                For k As Integer = 0 To dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows.Count - 1 Step 1
    '                    Try
    '                        If dtTablaExcel.Rows(i).Item(j) = dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows(k).Item(0) Then
    '                            datoValido = True
    '                            Exit For
    '                        End If
    '                    Catch ex As Exception
    '                        Throw New Exception(ex.Message & "-" & dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Rows(0).Item(1))
    '                    End Try
    '                Next
    '                If Not datoValido Then
    '                    dgvResultado.Rows(i).Cells(j).Style.BackColor = rosaBlanco_
    '                    observaciones = "Corregir"
    '                Else
    '                    dgvResultado.Rows(i).Cells(j + 1).Value = dsMetaDatos.Tables(listaColumnasAValidar(j + 1)).Compute("MAX(Descripcion)", "T_Id = '" + dtTablaExcel.Rows(i).Item(j) + "'")
    '                End If
    '                datoValido = False
    '            End If
    '        Next
    '        If observaciones = "Corregir" Then
    '            dgvResultado.Rows(i).Cells(46).Style.BackColor = rosaBlanco_
    '            dgvResultado.Rows(i).Cells(46).Value = observaciones
    '        Else
    '            dgvResultado.Rows(i).Cells(46).Style.BackColor = verderCian_
    '            dgvResultado.Rows(i).Cells(46).Value = "Listo!"
    '        End If
    '        observaciones = String.Empty
    '    Next
    '    dgvResultado.ClearSelection()
    'End Sub


    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
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

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text,arrayDeParametros)
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
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try
            'dgvResultado.DataSource = Nothing
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

    'Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
    '    dgvResultado.DataSource = Nothing
    '    tablaResultado = Nothing
    '    dgvResultado.Columns.Clear()
    '    Dim dgv As Task(Of DataTable)
    '    encenderControlesDeEspera(barProgreso, lblResultado)
    '    dgv = ProcesarAsync()
    '    'dgvResultado.DataSource = Await dgv
    '    tablaResultado = Await dgv
    '    corregirTabla(tablaResultado)
    '    dgvResultado.DataSource = tablaResultado
    '    apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
    '    corregirCeldas(dgvResultado)
    '    formatearDataGridView(dgvResultado)
    'End Sub

    Private Async Function ProcesarAsync() As Task(Of DataTable)
        Try
            Dim p As New Dictionary(Of String, Object)
            Dim t As DataTable = obtenerTablaParaSP(dtTablaExcel)
            p.Add("@dtTabla", t)
            Dim r As New DataTable
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Fitosanidad_Movimientos_CrearProgramasSemanales", p, TipoQuery.DataTable))
            If Len(r.Rows(0).Item(0)) > 0 Then
                MessageBox.Show("Programa(s) guardado(s) con exito.")
            ElseIf r.Rows(0).Item(0) = 0 Then
                Throw New Exception(r.Rows(0).Item(1))
            End If
            Return r

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Private Function obtenerTablaParaSP(dtAux As DataTable, columnas As String) As DataTable
    '    Dim aux As New DataTable
    '    For i As Integer = 1 To 20 Step 1
    '        aux.Columns.Add("C" & i.ToString)
    '    Next
    '    Dim cols As New List(Of Integer)
    '    Dim colsS As New List(Of String)
    '    colsS = columnas.Split(",").ToList
    '    For Each s As String In colsS
    '        cols.Add(CType(s, Integer))
    '    Next
    '    For Each f1 As DataRow In dtAux.Rows
    '        Dim fA As DataRow = aux.NewRow
    '        Dim v As Integer = IIf(cols.Count >= 20, 20, cols.Count) - 1
    '        'For iA As Integer = 0 To aux.Columns.Count - 1 Step 1
    '        For iA As Integer = 0 To v Step 1
    '            fA.Item(iA) = f1.Item(cols.Item(iA))
    '            '    For i1 As Integer = 0 To dtConsolidados.Columns.Count Step 1
    '            '        If cols.Contains(i1) And iA = i1 Then
    '            '            fA.Item(iA) = f1.Item(i1)
    '            '        End If
    '            '    Next
    '        Next
    '        aux.Rows.Add(fA)
    '    Next
    '    Return aux
    'End Function

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


    Private Sub frmFitosanidad_Movimientos_CrearProgramasSemanales_CargarNuevosProgramas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aplicarTema(Me)
    End Sub
End Class