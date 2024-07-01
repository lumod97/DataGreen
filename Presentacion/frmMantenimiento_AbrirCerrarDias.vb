Imports Logica.Utiles
Imports Datos.Conexion

Public Class frmMantenimiento_AbrirCerrarDias

    Dim dtModulos As DataTable
    Dim dtResultado As DataTable
    Dim bsResultado As New BindingSource()
    Dim anio As String = String.Empty
    Dim mes As String = String.Empty
    Dim semana As String = String.Empty

    Private Sub frmMantenimiento_AbrirCerrarDias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        ObtenerModulos()
        cargarCombo(CboModulo, dtModulos, 1, 1)
        CboModulo.SelectedIndex = -1
        'ObtenerDias()
        'cargarDgvConFiltro()
        'cargarComboManualmente(cboAnio, dgvResultado, 1)
        'cargarComboManualmente(cboMes, dgvResultado, 3)
        'cargarComboManualmente(cboSemana, dgvResultado, 5)
        'dgvResultado.AllowUserToResizeRows = False
        tlpPrincipal.Visible = True


    End Sub

    Private Sub ObtenerDias(modulo As String)
        'Dim aux As DataSet = New DataSet
        dtResultado = Nothing
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", modulo)
        dtResultado = doItBaby("sp_Dg_Mantenimientos_AbrirCerrarDias_ListarDias", p, TipoQuery.DataTable)
    End Sub

    Private Sub cargarDgvConFiltro()
        dgvResultado.ReadOnly = False
        dgvResultado.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        dgvResultado.Columns.Clear()
        dgvResultado.DataSource = Nothing
        Dim dvCabeceraPallets As New DataView(dtResultado)
        bsResultado.DataSource = dvCabeceraPallets
        dgvResultado.DataSource = bsResultado

        'Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        'dgvColumnCheck = New DataGridViewCheckBoxColumn()
        'dgvColumnCheck.Name = "AbrirAnio"
        'dgvColumnCheck.HeaderText = "Abrir Año"
        'dgvResultado.Columns.Insert(3, dgvColumnCheck)

        'dgvColumnCheck = New DataGridViewCheckBoxColumn()
        'dgvColumnCheck.Name = "AbrirMes"
        'dgvColumnCheck.HeaderText = "Abrir Mes"
        'dgvResultado.Columns.Insert(6, dgvColumnCheck)

        'dgvColumnCheck = New DataGridViewCheckBoxColumn()
        'dgvColumnCheck.Name = "AbrirSemana"
        'dgvColumnCheck.HeaderText = "Abrir Semana"
        'dgvResultado.Columns.Insert(9, dgvColumnCheck)

        'dgvColumnCheck = New DataGridViewCheckBoxColumn()
        'dgvColumnCheck.Name = "AbrirDia"
        'dgvColumnCheck.HeaderText = "Abrir Dia"
        'dgvResultado.Columns.Insert(13, dgvColumnCheck)

        'corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)

        dgvResultado.Columns(0).Visible = False
        'dgvResultado.Columns(2).Visible = False
        'dgvResultado.Columns(5).Visible = False
        'dgvResultado.Columns(8).Visible = False
        'dgvResultado.Columns(12).Visible = False

        'For Each col As DataGridViewColumn In dgvResultado.Columns
        '    MessageBox.Show(col.Name + "." + col.HeaderText + "." + col.Index.ToString + "." + col.DisplayIndex.ToString)
        'Next
        'Dim filas As Integer = dgvResultado.RowCount
        'lblCoincidencias.Text = "Coincidencias: " + filas.ToString
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

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        'Dim lsValores As New List(Of String)
        'For i As Integer = 0 To e.ColumnIndex Step 1
        '    Select i
        '        Case 0
        '            lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(5).Value.ToString)
        '        Case 1
        '            lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(7).Value.ToString)
        '        Case 2
        '            lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(9).Value.ToString)
        '        Case 3
        '            lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(12).Value.ToString)
        '    End Select
        'Next
        'MessageBox.Show(dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "-" & e.ColumnIndex.ToString)
        'MessageBox.Show(dgvResultado.Item(e.ColumnIndex, e.RowIndex).Value)
        'cambiarValoresDeCheck(lsValores, True)
        'dgvResultado.Item(1, e.RowIndex) = True
        'MessageBox.Show(lsValores.Item(0) + "." + lsValores.Item(1) + "." + lsValores.Item(2) + "." + lsValores.Item(3))
    End Sub

    Private Sub cambiarValoresDeCheck(lista As List(Of String), valor As Boolean)
        If valor Then
            If lista.Count > 0 Then
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If lista.Item(0) = fila.Cells("Año").Value.ToString Then
                        fila.Cells("Abrir Año").Value = True
                    End If
                Next
            End If
            If lista.Count > 1 Then
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If lista.Item(0) = fila.Cells("Año").Value.ToString _
                        And lista.Item(1) = fila.Cells("Mes").Value.ToString Then
                        fila.Cells("Abrir Mes").Value = True
                    End If
                Next
            End If
            If lista.Count > 2 Then
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If lista.Item(0) = fila.Cells("Año").Value.ToString _
                        And lista.Item(1) = fila.Cells("Mes").Value.ToString _
                        And lista.Item(2) = fila.Cells("Semana").Value.ToString Then
                        fila.Cells("Abrir Semana").Value = True
                    End If
                Next
            End If
            'If lista.Count > 3 Then
            '    For Each fila As DataGridViewRow In dgvResultado.Rows
            '        If lista.Item(0) = fila.Cells("Año").Value.ToString _
            '            And lista.Item(1) = fila.Cells("Mes").Value.ToString _
            '            And lista.Item(2) = fila.Cells("Semana").Value.ToString _
            '            And lista.Item(3) = fila.Cells("Dia").Value.ToString Then
            '            fila.Cells(3).Value = True
            '        End If
            '    Next
            'End If
        Else
            If lista.Count = 3 Then
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If lista.Item(0) = fila.Cells("Año").Value.ToString _
                        And lista.Item(1) = fila.Cells("Mes").Value.ToString _
                        And lista.Item(2) = fila.Cells("Semana").Value.ToString Then
                        fila.Cells("Abrir Semana").Value = False
                        fila.Cells("Abrir Dia").Value = False
                    End If
                Next
            End If
            If lista.Count = 2 Then
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If lista.Item(0) = fila.Cells("Año").Value.ToString _
                        And lista.Item(1) = fila.Cells("Mes").Value.ToString Then
                        'And lista.Item(2) = fila.Cells("Semana").Value.ToString Then
                        fila.Cells("Abrir Mes").Value = False
                        fila.Cells("Abrir Semana").Value = False
                        fila.Cells("Abrir Dia").Value = False
                    End If
                Next
            End If
            If lista.Count = 1 Then
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If lista.Item(0) = fila.Cells("Año").Value.ToString Then
                        'And lista.Item(1) = fila.Cells("Mes").Value.ToString Then
                        'And lista.Item(2) = fila.Cells("Semana").Value.ToString Then
                        fila.Cells("Abrir Año").Value = False
                        fila.Cells("Abrir Mes").Value = False
                        fila.Cells("Abrir Semana").Value = False
                        fila.Cells("Abrir Dia").Value = False
                    End If
                Next
            End If
        End If
    End Sub


    'Private Sub dgvResultado_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellValueChanged
    '    MessageBox.Show(dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "-" & e.ColumnIndex.ToString)
    'End Sub

    Private Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick
        Dim lsValores As New List(Of String)
        For i As Integer = 0 To e.ColumnIndex Step 1
            Select Case i
                Case 2
                    lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(1).Value.ToString)
                Case 4
                    lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(3).Value.ToString)
                Case 6
                    lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(5).Value.ToString)
                Case 9
                    lsValores.Add(dgvResultado.Rows(e.RowIndex).Cells(8).Value.ToString)
            End Select
        Next
        Select Case e.ColumnIndex
            Case 2, 4, 6, 9
                'EditedFormattedValue DEVUELVE EL VALOR QUE OBTIENE EL CHECKBOX DESPUES DEL CLICK
                cambiarValoresDeCheck(lsValores, dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue)
                dgvResultado.Rows(e.RowIndex).Cells(0).Value = 1
        End Select
        '---------------
        'MessageBox.Show(e.RowIndex.ToString & "-" & e.ColumnIndex.ToString)
        'Dim _ColumnIndex As Integer = e.ColumnIndex
        'Dim _RowIndex As Integer = e.RowIndex
        'MessageBox.Show(dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue)
        'If dgvResultado.Rows(_RowIndex).Cells("EstadoAnio").Value = False Then 'And
        '    MessageBox.Show(dgvResultado.Rows(_RowIndex).Cells("EstadoAnio").Value)
        '    'dgvResultado.Rows(_RowIndex).Cells("Column3").Value = True Then
        '    dgvResultado.Rows(_RowIndex).Cells("EstadoAnio").Value = False
        'End If

        'If dgvResultado.Rows(_RowIndex).Cells("EstadoAnio").Value = False Then 'And
        '    MessageBox.Show(dgvResultado.Rows(_RowIndex).Cells("EstadoAnio").Value)
        '    'dgvResultado.Rows(_RowIndex).Cells("Column2").Value = True Then
        '    dgvResultado.Rows(_RowIndex).Cells("EstadoAnio").Value = False
        'End If

    End Sub

    Private Sub cargarComboManualmente(ByRef combo As ComboBox, tabla As DataGridView, columna As Integer)
        combo.Items.Clear()
        combo.Items.Add("-Mostrar Todo-")
        For Each fila As DataGridViewRow In tabla.Rows
            If Not combo.Items.Contains(fila.Cells(columna).Value) Then
                combo.Items.Add(fila.Cells(columna).Value)
            End If
        Next
    End Sub

    Private Sub cboAnio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnio.SelectionChangeCommitted
        If cboAnio.SelectedItem = "-Mostrar Todo-" Then
            bsResultado.RemoveFilter()
            anio = ""
            mes = ""
            semana = ""
            cboMes.SelectedIndex = 0
            cboSemana.SelectedIndex = 0
        Else
            anio = cboAnio.SelectedItem
            bsResultado.Filter = String.Format("Año like '%{0}%' And Mes like '%{1}%' And Semana like '%{2}%'", anio, mes, semana)
        End If
        cargarComboManualmente(cboMes, dgvResultado, 3)
        cargarComboManualmente(cboSemana, dgvResultado, 5)
    End Sub

    Private Sub actualizarFiltro()
        bsResultado.Filter = String.Format("Año like '%{0}%' And " +
                                                 "Mes like '%{1}%' And " +
                                                 "Semana like '%{2}%'",
                                                 cboAnio.SelectedItem,
                                                 cboMes.SelectedItem,
                                                 cboSemana.SelectedItem)
    End Sub

    Private Sub cboMes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboMes.SelectionChangeCommitted
        If cboMes.SelectedItem = "-Mostrar Todo-" Then
            mes = ""
            semana = ""
            cboSemana.SelectedIndex = 0
        Else
            mes = cboMes.SelectedItem
        End If
        bsResultado.Filter = String.Format("Año like '%{0}%' And Mes like '%{1}%' And Semana like '%{2}%'", anio, mes, semana)
        cargarComboManualmente(cboSemana, dgvResultado, 5)
    End Sub

    Private Sub cboSemana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSemana.SelectionChangeCommitted
        If cboSemana.SelectedItem = "-Mostrar Todo-" Then
            semana = ""
        Else
            semana = cboSemana.SelectedItem
        End If
        bsResultado.Filter = String.Format("Año like '%{0}%' And Mes like '%{1}%' And Semana like '%{2}%'", anio, mes, semana)
    End Sub

    Private Sub cbxAbierto_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAbierto.CheckedChanged
        cbxAbierto.Checked = True
    End Sub

    Private Sub cbxCerrado_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCerrado.CheckedChanged
        cbxCerrado.Checked = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cadenaParametros As String = String.Empty
        Dim p As New Dictionary(Of String, Object)
        For Each fila As DataGridViewRow In dgvResultado.Rows
            If fila.Cells(0).Value = "1" Then
                cadenaParametros = fila.Cells(1).Value & ","
                cadenaParametros = cadenaParametros & fila.Cells(2).Value & ","
                cadenaParametros = cadenaParametros & fila.Cells(3).Value & ","
                cadenaParametros = cadenaParametros & fila.Cells(4).Value & ","
                cadenaParametros = cadenaParametros & fila.Cells(5).Value & ","
                cadenaParametros = cadenaParametros & fila.Cells(6).Value & ","
                cadenaParametros = cadenaParametros & CType(fila.Cells(8).Value, Date).ToString("yyyy-MM-dd") & ","
                cadenaParametros = cadenaParametros & fila.Cells(9).Value
                p.Add("@Modulo", CboModulo.SelectedValue)
                p.Add("@CadenaParametros", cadenaParametros)
                doItBaby("sp_Dg_Mantenimientos_AbrirCerrarDias_GuardarDias", p, TipoQuery.NonQuery)
                cadenaParametros = String.Empty
                p.Clear()
                fila.Cells(0).Value = "0"
            End If
        Next
        ObtenerDias(CboModulo.SelectedValue)
        cargarDgvConFiltro()
        MessageBox.Show("Estados de dias guardados correctamente.")
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ObtenerDias(CboModulo.SelectedValue)
        cargarDgvConFiltro()
        cargarComboManualmente(cboAnio, dgvResultado, 1)
        cargarComboManualmente(cboMes, dgvResultado, 3)
        cargarComboManualmente(cboSemana, dgvResultado, 5)
        MessageBox.Show("Los cambios se han cancelado.")
    End Sub

    Private Sub CboModulo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CboModulo.SelectionChangeCommitted
        ObtenerDias(CboModulo.SelectedValue)
        cargarDgvConFiltro()
        cargarComboManualmente(cboAnio, dgvResultado, 1)
        cargarComboManualmente(cboMes, dgvResultado, 3)
        cargarComboManualmente(cboSemana, dgvResultado, 5)
    End Sub

    Private Sub ObtenerModulos()
        dtModulos = New DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@SeleccionMultiple", 0)
        dtModulos = doItBaby("sp_Gen_ObtenerModulosDataGreen", p, TipoQuery.DataTable)
    End Sub

End Class