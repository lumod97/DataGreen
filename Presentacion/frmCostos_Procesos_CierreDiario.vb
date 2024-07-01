'CODIGO QUE SATISFACE ORDEN Y EFICIENCIA EN CONSULTAS ASINCRONAS PARA DATASET,
'REPLICAR ESTRUCTURA EN LOS DEMAS FORMS (JORGE MERA 04092020)

Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmCostos_Procesos_CierreDiario

    Dim dsResultado As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty

    Private Sub frmCostos_Procesos_CierreDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        pkrDia.Value = DateTime.Today.AddDays(-1)
        aplicarTema(Me)
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvEstadoDias.DataSource = Nothing
        dgvEstadoDias.Columns.Clear()
        dgvGastos.DataSource = Nothing
        dgvGastos.Columns.Clear()
        dgvInsumos.DataSource = Nothing
        dgvInsumos.Columns.Clear()
        dgvManoObra.DataSource = Nothing
        dgvManoObra.Columns.Clear()
        dgvMaquinaria.DataSource = Nothing
        dgvMaquinaria.Columns.Clear()
        dgvOtros.DataSource = Nothing
        dgvOtros.Columns.Clear()

        encenderControlesDeEspera(barProgreso, lblDinResultado)
        Dim aux As DataSet
        aux = Await Task.Run(Function() consultarAsync())
        dgvEstadoDias.DataSource = Await Task.FromResult(aux.Tables(0))
        dgvInsumos.DataSource = Await Task.FromResult(aux.Tables(1))
        dgvManoObra.DataSource = Await Task.FromResult(aux.Tables(2))
        dgvGastos.DataSource = Await Task.FromResult(aux.Tables(3))
        dgvMaquinaria.DataSource = Await Task.FromResult(aux.Tables(4))
        dgvOtros.DataSource = Await Task.FromResult(aux.Tables(5))
        apagarControlesDeEspera(barProgreso, lblDinResultado, -1)

        corregirCeldas(dgvEstadoDias)
        corregirCeldas(dgvInsumos)
        corregirCeldas(dgvManoObra)
        corregirCeldas(dgvGastos)
        corregirCeldas(dgvOtros)
        corregirCeldas(dgvMaquinaria)
        formatearDataGridView(dgvEstadoDias)
        formatearDataGridView(dgvInsumos)
        formatearDataGridView(dgvManoObra)
        formatearDataGridView(dgvGastos)
        formatearDataGridView(dgvOtros)
        formatearDataGridView(dgvMaquinaria)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", pkrDia.Value)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Costos_ValidacionParaCierreDiario", p, TipoQuery.DataSet))
            dsResultado = r
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnCerrarDia_Click(sender As Object, e As EventArgs) Handles btnCerrarDia.Click
        If dgvManoObra.DataSource Is Nothing Then
            MessageBox.Show("Para cerrar el dia debe de analizar el resultado de la busqueda.")
        Else
            Dim dia As Date = pkrDia.Value
            Dim eleccion As DialogResult = MessageBox.Show("Esta seguro de cerrar el dia " + dia.ToShortDateString + "?",
                                                           "Cerrar dia", MessageBoxButtons.YesNo)
            If eleccion = Windows.Forms.DialogResult.Yes Then
                If cerrarDia(dia, usuarioActual) Then
                    MessageBox.Show("El dia " + dia.ToShortDateString + " se ha cerrado correctamente")
                    btnConsultar_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Public Function cerrarDia(dia As Date, usuario As String) As Boolean
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Dia", pkrDia.Value)
            p.Add("@Usuario", usuarioActual)
            If doItBaby("sp_Dg_Costos_CerrarDia", p, TipoQuery.NonQuery) Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvInsumos.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Insumos", dgvInsumos)
        '    dDgvs.Add("ManoObra", dgvManoObra)
        '    dDgvs.Add("Gastos", dgvGastos)
        '    dDgvs.Add("Maquinaria", dgvMaquinaria)
        '    dDgvs.Add("Otros", dgvOtros)
        '    'exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
        '    excelling(dDgvs, Me.Text, arrayDeParametros)
        'End If

        Try
            If dgvInsumos.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDinResultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("Insumos")
                l.Add("ManoObra")
                l.Add("Gastos")
                l.Add("Maquinaria")
                l.Add("Otros")
                Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblDinResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Dim tab As String = tabResultado.SelectedTab.Text
        'Select Case tab
        '    Case "Insumos"
        '        If dgvInsumos.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvInsumos, Me.Text, arrayDeParametros)
        '            dgvInsumos.ClearSelection()
        '        End If
        '    Case "Mano de Obra"
        '        If dgvManoObra.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvManoObra, Me.Text, arrayDeParametros)
        '            dgvManoObra.ClearSelection()
        '        End If
        '    Case "Gastos"
        '        If dgvGastos.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvGastos, Me.Text, arrayDeParametros)
        '            dgvGastos.ClearSelection()
        '        End If
        '    Case "Maquinaria"
        '        If dgvMaquinaria.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvMaquinaria, Me.Text, arrayDeParametros)
        '            dgvMaquinaria.ClearSelection()
        '        End If
        '    Case "Otros"
        '        If dgvOtros.RowCount < 1 Then
        '            MessageBox.Show("Error, no hay registros para exportar")
        '        Else
        '            exportarExcel(dgvOtros, Me.Text, arrayDeParametros)
        '            dgvOtros.ClearSelection()
        '        End If
        'End Select
    End Sub

    Private Sub dgvEstadoDias_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvEstadoDias.DataError
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
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

    Private Sub dgvGastos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvGastos.DataError
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

    Private Sub dgvInsumos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvInsumos.DataError
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

    Private Sub dgvManoObra_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvManoObra.DataError
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

    Private Sub dgvMaquinaria_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMaquinaria.DataError
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

    Private Sub dgvOtros_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvOtros.DataError
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

    Private Sub dgvEstadoDias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEstadoDias.CellClick
        Dim nuevaFecha As String = String.Empty
        nuevaFecha = pkrDia.Value.ToString("yyyy-MM-")
        nuevaFecha = String.Concat(nuevaFecha, dgvEstadoDias.Rows(e.RowIndex).Cells(0).Value)
        'MessageBox.Show(nuevaFecha)
        pkrDia.Value = CType(nuevaFecha, Date)
        btnConsultar_Click(sender, e)
    End Sub
End Class