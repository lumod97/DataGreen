Imports Logica.Utiles
Imports Logica.Funciones
Imports Datos.Conexion
Imports Entidades.Temporales

Public Class frmContabilidad_Reportes_BalanceComprobacion
    Dim dsDataParaControles As New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable

    Private Sub frmContabilidad_Reportes_BalanceComprobacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaControles()
        cargarTextBox(txtPeriodoInicial, dsDataParaControles.Tables(0))
        cargarTextBox(txtPeriodoFinal, dsDataParaControles.Tables(0))
        cargarCombo(cboTipoMoneda, dsDataParaControles.Tables(1))
        cargarCombo(cboNroDigitos, dsDataParaControles.Tables(2))
        'CARGAR TXTBOX PERIODOS
        'CARGAR CBOX MONEDA
        'CARGAR CBOX NRO DIGITOS
        aplicarTema(Me)
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
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        Try
            If txtPeriodoInicial.Text = "" Or txtPeriodoFinal.Text = "" Or cboTipoMoneda.SelectedIndex < 0 Or cboNroDigitos.SelectedIndex < 0 Then
                MessageBox.Show("Los parametros de consulta no son validos. seleccionar parametros correctos.")
            Else
                Dim aux As New DataTable
                Dim p As New Dictionary(Of String, Object)
                p.Add("@CodEmpresa", "001")
                p.Add("@Periodo_A", txtPeriodoInicial.Text)
                p.Add("@Periodo_Z", txtPeriodoInicial.Text)
                p.Add("@TipoMoneda", cboTipoMoneda.SelectedValue)
                p.Add("@NDigitos_C", cboNroDigitos.SelectedValue)
                p.Add("@PCierre", IIf(radIncluirAsiento.Checked, 1, 0))
                p.Add("@Codigo", "")
                p.Add("@Base_N", "AgricolaSanJuan_2020")
                arrayDeParametros = obtenerCadenaParametros(p)
                aux = Await Task.Run(Function() doItBaby("sp_Dg_Contabilidad_Reportes_BalanceComprobacion", p, TipoQuery.DataTable))
                Return aux
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '     MessageBox.Show("Error, no hay registros para exportar")
        ' Else
        '     'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '     Dim dDgvs As New Dictionary(Of String, DataGridView)
        '     dDgvs.Add("Reporte", dgvResultado)
        '     excelling(dDgvs, Me.Text, arrayDeParametros)
        '     dgvResultado.ClearSelection()
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

    Private Sub obtenerDataParaControles()
        dsDataParaControles = New DataSet
        Dim p As New Dictionary(Of String, Object)
        'Dim dia As Date = CType(Now.ToString("YYYY") + "01-01", Date)
        p.Add("@Desde", CType(Year(Now).ToString + "-01-01", Date))
        p.Add("@Hasta", CType(Year(Now).ToString + "-12-31", Date))
        dsDataParaControles.Tables.Add(doItBaby("sp_ObtenerPeriodos", p, TipoQuery.DataTable))
        dsDataParaControles.Tables.Add(doItBaby("sp_ObtenerTiposMoneda", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Tables.Add(doItBaby("sp_ObtenerNrosDigitosContables", Nothing, TipoQuery.DataTable))

    End Sub

    Public Shared Sub cargarTextBox(ByRef textBox As TextBox, ByVal dataTable As DataTable)
        Dim Lista As New AutoCompleteStringCollection
        For Each fila As DataRow In dataTable.Rows
            Lista.Add(fila.Item(0).ToString)
        Next
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        textBox.AutoCompleteCustomSource = Lista
        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    'Private Sub txtPeriodoInicial_Leave(sender As Object, e As EventArgs) Handles txtPeriodoInicial.Leave
    '    'Dim p As New Dictionary(Of String, Object)
    '    ''Dim dia As Date = CType(Now.ToString("YYYY") + "01-01", Date)
    '    'p.Add("@Desde", CType(Year(Now).ToString + "-01-01", Date))
    '    'p.Add("@Hasta", CType(Year(Now).ToString + "-12-31", Date))
    '    'dsDataParaControles.Tables.Add(doItBaby("sp_ObtenerPeriodos", p, TipoQuery.DataTable))
    'End Sub
End Class