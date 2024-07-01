'CODIGO QUE SATISFACE ORDEN Y EFICIENCIA EN CONSULTAS ASINCRONAS, REPLICAR ESTRUCTURA EN LOS DEMAS FORMS (JORGE MERA 04092020)

Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmSupervision_Reportes_FormatoTransferencia
    Public tablasParaCombos As DataSet
    Dim tablaResultado As DataTable
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmSupervision_Reportes_FormatoTransferencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaCombos()
        llenarCombo(cboPlanilla, tablasParaCombos.Tables(0))
        llenarCombo(cboTurno, tablasParaCombos.Tables(1))
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        tablasParaCombos = doItBaby("sp_DG_Supervision_Reportes_FormatoTransferencia_CargarData", Nothing, Datos.Conexion.TipoQuery.DataSet)
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
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p = New Dictionary(Of String, Object)
            p = New Dictionary(Of String, Object)
            p.Add("@Dia", pkrDia.Value)
            p.Add("@Planilla", cboPlanilla.SelectedValue)
            p.Add("@Turno", cboTurno.SelectedValue)
            p.Add("@DistribuirXConsumidorProductoTreminado", cbxDistribuirXConsumidorProductoTreminado.Checked)
            p.Add("@TipoTareo", IIf(cbxMoviles.Checked, "M", "E"))
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_DG_Supervision_Reportes_FormatoTransferencia", p, TipoQuery.DataTable))
            tablaResultado = aux
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
            'dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
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
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        '    dgvResultado.ClearSelection()
        'End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "RegistrosDuplicados"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class