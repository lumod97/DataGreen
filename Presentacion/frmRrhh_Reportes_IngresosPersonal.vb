Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports ClosedXML.Excel

Public Class frmRrhh_Reportes_IngresosPersonal
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    Private Sub frmRrhh_Reportes_IngresosPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
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
            arrayDeParametros = obtenerCadenaParametros(p)
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Rrhh_Reportes_IngresosPersonal", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, arrayDeParametros, 6)
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, arrayDeParametros, 6)
        'End If
        'expo()
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

    '    Private Sub Export()
    '        Dim file As System.IO.StreamWriter
    '        file = My.Computer.FileSystem.OpenTextFileWriter("C:\DataGreen\Prueba.xlsx", True)
    '        If dgvResultado.Rows.Count = 0 Then GoTo loopend

    '        ' collect the header's names 
    '        Dim Headerline As String = ""
    '        For k = 0 To dgvResultado.Columns.Count - 1
    '            If k = dgvResultado.Columns.Count - 1 Then ' last column dont put , separate 
    '                Headerline = Headerline & dgvResultado.Columns(k).HeaderText
    '            Else
    '                Headerline = Headerline & dgvResultado.Columns(k).HeaderText & vbTab
    '            End If
    '        Next
    '        file.WriteLine(Headerline)  ' this will write header names at the first line 
    '        ' collect the data 

    '        For i = 0 To dgvResultado.Rows.Count - 1
    '            Dim DataRow As String = Nothing
    '            For k = 0 To dgvResultado.Columns.Count - 1
    '                If k = dgvResultado.Columns.Count - 1 Then
    '                    DataRow = DataRow & dgvResultado.Rows(i).Cells(k).Value ' last column dont put , separate 
    '                End If
    '                DataRow = DataRow & dgvResultado.Rows(i).Cells(k).Value & vbTab
    '            Next

    '            file.WriteLine(DataRow)
    '            DataRow = ""
    '        Next
    'loopend:
    '        file.Close()
    '    End Sub




End Class