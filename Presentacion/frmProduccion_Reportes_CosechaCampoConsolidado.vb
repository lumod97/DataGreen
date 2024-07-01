Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmProduccion_Reportes_CosechaCampoConsolidado
    Public tablasParaCombos As DataSet
    Dim tablaResultado As DataTable
    Dim arrayDeParametros As String = String.Empty

    Private Sub frm_Produccion_Reportes_CosechaCampoConsolidado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaCombos()
        llenarCombo(cboCultivo, tablasParaCombos.Tables(0))
        cboCultivo.SelectedIndex = 2
        'dgvResultado.AllowUserToResizeRows = False
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As DataSet = New DataSet
        'aux = execSp_Dg_Produccion_Reportes_CosechaCampoConsolidado_DataParaCombos()
        aux = doItBaby("sp_Dg_Produccion_Reportes_CosechaCampoConsolidado_DataParaCombos", Nothing, TipoQuery.DataSet)
        tablasParaCombos = New DataSet
        tablasParaCombos.Tables.Add(aux.Tables(0).Copy)
    End Sub

    Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "")
        comboBox.DataSource = Nothing
        Dim i As Integer = 0
        If dataTable.Columns.Count = 3 Then
            comboBox.DataSource = dataTable
            comboBox.ValueMember = "Clave"
            If dataTable.Rows.Count < 15 Then
                comboBox.DisplayMember = "Valor"
            Else
                comboBox.DisplayMember = "Concatenado"
            End If
        Else
            For Each fila As DataRow In dataTable.Rows
                If fila.Item(0).ToString = condicion Then
                    Dim dt As DataTable = dataTable
                    Dim dataView As DataView = dt.DefaultView
                    dataView.RowFilter = "Condicion = '" & condicion & "'"
                    comboBox.DataSource = dataView
                    comboBox.ValueMember = "Clave"
                    If dataView.Count < 10 Then
                        comboBox.DisplayMember = "Valor"
                    Else
                        comboBox.DisplayMember = "Concatenado"
                    End If
                End If
                i = i + 1
            Next
        End If
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
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
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", pkrDesde.Value.ToString("yyyy-MM-dd"))
            p.Add("@Hasta", pkrHasta.Value.ToString("yyyy-MM-dd"))
            p.Add("@Cultivo", "0010")
            p.Add("@Detalle", cbxDetalle.Checked)
            p.Add("@DetalleCategorias", cbxDetalleCategorias.Checked)
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Produccion_Reportes_CosechaCampoConsolidado_Juana", p, TipoQuery.DataTable))
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

    Private Sub cbxDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDetalle.CheckedChanged
        If cbxDetalle.Checked Then
            cbxDetalleCategorias.Checked = False
            cbxDetalleCategorias.Enabled = False
        Else
            'cbxDetalleCategorias.Checked = 
            cbxDetalleCategorias.Enabled = True
        End If
    End Sub
End Class