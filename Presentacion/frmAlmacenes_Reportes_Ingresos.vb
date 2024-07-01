Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
'PENDIENTE: CREAR LA FUNCION LLENAR COMBO EN LA CLASE FUNCIONES PARA USO GENERAL

Public Class frmAlmacenes_Reportes_Ingresos
    Public tablasParaCombos As DataSet
    Dim tablaResultado As DataTable
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmAlmacenes_Reportes_Ingresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        obtenerMultitablaParaCombos()
        llenarCombo(cboSucursal, tablasParaCombos.Tables(0))
        llenarCombo(cboMotivo, tablasParaCombos.Tables(2))
        'dgvResultado.AllowUserToResizeRows = False
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerMultitablaParaCombos()
        tablasParaCombos = New DataSet
        tablasParaCombos = doItBaby("Sp_Dg_Almacenes_Reportes_Ingresos_DataParaCombos", Nothing, TipoQuery.DataSet)
    End Sub

    Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "")
        comboBox.DataSource = Nothing
        Dim i As Integer = 0
        If dataTable.Columns.Count = 3 Then
            comboBox.DataSource = dataTable
            comboBox.ValueMember = "Clave"
            If dataTable.Rows.Count < 10 Then
                comboBox.DisplayMember = "Valor"
            Else
                comboBox.DisplayMember = "Concatenado"
            End If
            'For Each fila As DataRow In dataTable.Rows
            '    comboBox.Items.Add(String.Concat(dataTable.Rows(i).Item(0).ToString, " | ", dataTable.Rows(i).Item(1).ToString))
            '    i = i + 1
            'Next
            'ElseIf dataTable.Columns.Count = 3 And dataTable.Rows.Count >= 10 Then
            '    comboBox.DataSource = dataTable
            '    comboBox.ValueMember = "Clave"
            '    comboBox.DisplayMember = "Concatenado"
        Else
            For Each fila As DataRow In dataTable.Rows
                If fila.Item(0).ToString = condicion Then
                    Dim dt As DataTable = dataTable
                    Dim dataView As DataView = dt.DefaultView
                    dataView.RowFilter = "Condicion = '" & condicion & "'"
                    comboBox.DataSource = dataView
                    comboBox.ValueMember = "Clave"
                    'dataTable.Rows.Count
                    If dataView.Count < 10 Then
                        comboBox.DisplayMember = "Valor"
                    Else
                        comboBox.DisplayMember = "Concatenado"
                    End If
                    'comboBox.Items.Add(String.Concat(dataTable.Rows(i).Item(1).ToString, " | ", dataTable.Rows(i).Item(2).ToString))
                End If
        i = i + 1
            Next
        End If
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        comboBox.SelectedValue = ""
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim almacen As String = cboAlmacen.SelectedValue
            If almacen = "XXX" Then
                almacen = String.Empty
                For Each item As DataRowView In cboAlmacen.Items
                    If item.Row("Clave") <> "XXX" Then
                        almacen = almacen + item.Row("Clave") + ","
                    End If
                Next
            End If
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdEmp", "001")
            p.Add("@IdSuc", cboSucursal.SelectedValue)
            p.Add("@IdAlm", almacen)
            p.Add("@Desde", pkrDesde.Value.ToString("yyyyMMdd"))
            p.Add("@Hasta", pkrHasta.Value.ToString("yyyyMMdd"))
            p.Add("@Motivo", cboMotivo.SelectedValue)
            p.Add("@IdProducto", "")
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("Sp_Dg_Almacenes_Reportes_Ingresos", p, TipoQuery.DataTable))
            tablaResultado = aux
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = _
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        '    dgvResultado.ClearSelection()
        'End If
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

    Private Sub cboSucursal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSucursal.SelectionChangeCommitted
        llenarCombo(cboAlmacen, tablasParaCombos.Tables(1), cboSucursal.SelectedValue.ToString)
    End Sub
End Class