Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmSupervision_Reportes_ContrasteAsistencias
    Dim dsResultado As DataSet = New DataSet
    Dim arrayDeParametros As String = String.Empty
    Dim codigoGeneralSeleccionado As String = ""
    Dim dataTrabajador As DataTable
    Dim dataFiltrada As DataTable
    Dim texto As String = ""

    Private Sub frmSupervision_Reportes_ContrasteAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        'pkrDia.Value = DateTime.Today.AddDays(-1)
        aplicarTema(Me)
        tlpPrincipal.Visible = True
        dataTrabajador = doItBaby("sp_Dg_ObtenerPersonalActivoParaCombo", Nothing, Datos.Conexion.TipoQuery.DataTable)
        dataFiltrada = dataTrabajador
        cargarCombo(cboTrabajador, dataTrabajador, 0, 2)
        codigoGeneralSeleccionado = cboTrabajador.SelectedText.ToString
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado_Resumen.DataSource = Nothing
        dgvResultado_Resumen.Columns.Clear()
        dgvResultado_Detalle.DataSource = Nothing
        dgvResultado_Detalle.Columns.Clear()

        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        'Dim aux As DataSet
        dsResultado = Await Task.Run(Function() consultarAsync())
        'dsResultado = aux
         dgvResultado_Resumen.DataSource = dsResultado.Tables(0) 'Await Task.FromResult(aux.Tables(0))
        dgvResultado_Detalle.DataSource = dsResultado.Tables(1) 'Await Task.FromResult(aux.Tables(1))
        'dsResultado.Tables.Add(Await Task.FromResult(aux.Tables(0).Copy))
        'dsResultado.Tables.Add(Await Task.FromResult(aux.Tables(1).Copy))

        apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)

        corregirCeldas(dgvResultado_Resumen)
        corregirCeldas(dgvResultado_Detalle)
        'corregirTabla(dsResultado.Tables(0))
        'corregirTabla(dsResultado.Tables(1))

        formatearDataGridView(dgvResultado_Resumen)
        formatearDataGridView(dgvResultado_Detalle)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataSet)
        Try
            Dim r As New DataSet
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Desde", dtpDesde.Value)
            p.Add("@Hasta", dtpHasta.Value)
            p.Add("@Dni", codigoGeneralSeleccionado)
            arrayDeParametros = obtenerCadenaParametros(p)
            r = Await Task.Run(Function() doItBaby("sp_Dg_Supervision_Reportes_ContrasteAsistencias", p, TipoQuery.DataSet))
            Return r
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If dgvResultado_Resumen.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para exportar")
        Else
            'Dim dDgvs As New Dictionary(Of String, DataGridView)
            'dDgvs.Add("Detalle", dgvResultado_Detalle)
            'dDgvs.Add("Resumen", dgvResultado_Resumen)
            ''exportarVariosExcels(dDgvs, Me.Text, arrayDeParametros)
            'excelling(dDgvs, Me.Text, arrayDeParametros)
            encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
            Dim l As New List(Of String)
            l.Add("Resumen")
            l.Add("Detalle")
            Await Task.Run(Sub() aExcel(dsResultado, l, Me.Text, arrayDeParametros))
            'aExcel(dsResultado, l, Me.Text, arrayDeParametros)
            apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
        End If
    End Sub

    Private Sub dgvResultado_Resumen_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Resumen.DataError
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

    Private Sub dgvResultado_Detalle_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado_Detalle.DataError
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

    'Private Sub txtTrabajador_KeyDown(sender As Object, e As KeyEventArgs)
    '    ' Verificar si la tecla presionada es F2
    '    If e.KeyCode = Keys.F2 Then
    '        Dim dialogo As New dlgBuscarPersona
    '        dialogo.StartPosition = FormStartPosition.CenterScreen
    '        If dialogo.ShowDialog() = DialogResult.OK Then
    '            txtTrabajador.Text = dialogo.obtenerNombre()
    '            codigoGeneralSeleccionado = dialogo.obtenerCodigoGeneral()
    '        End If
    '        ' Acción a realizar cuando se presiona F2
    '        'MessageBox.Show("Tecla F2 presionada.")
    '    End If
    'End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboTrabajador.Text = ""
        codigoGeneralSeleccionado = ""
    End Sub

    Private Sub cboTrabajador_KeyUp(sender As Object, e As KeyEventArgs) Handles cboTrabajador.KeyUp
        If e.KeyCode = Keys.Enter Then
            cboTrabajador.Text = cboTrabajador.SelectedText
            cboTrabajador.DroppedDown = False
        ElseIf (e.KeyCode >= Keys.A AndAlso e.KeyCode <= Keys.Z) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) OrElse (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then
            ' Filtrar los datos del DataTable
            texto = cboTrabajador.Text
            Dim filasFiltradas As DataRow() = dataTrabajador.Select("Concatenado LIKE '%" + texto + "%'")
            '' Crear un DataTable temporal para almacenar los resultados filtrados
            Dim dtFiltrado As DataTable = dataTrabajador.Clone()
            For Each fila As DataRow In filasFiltradas
                dtFiltrado.ImportRow(fila)
            Next
            '' Actualizar el DataSource del ComboBox

            If dtFiltrado.Rows.Count = 0 Then
                filasFiltradas = dataTrabajador.Select("Concatenado LIKE '%***%'")
                dtFiltrado.ImportRow(filasFiltradas(0))
                cboTrabajador.DataSource = dtFiltrado
            End If
            cboTrabajador.DataSource = dtFiltrado

            '' Actualizar AutoCompleteCustomSource
            ActualizarAutoCompleteCustomSource()
            cboTrabajador.Text = texto
            If texto.Length > 0 Then
                cboTrabajador.Select(texto.Length, 0)
            End If
        End If
        Cursor.Show()
    End Sub

    Private Sub ActualizarAutoCompleteCustomSource()
        ' Actualizar la lista de autocompletado con los elementos actuales del ComboBox
        Dim listaAutoCompletar As New AutoCompleteStringCollection()
        For Each item As DataRowView In cboTrabajador.Items
            listaAutoCompletar.Add(item("Concatenado").ToString())
        Next
        cboTrabajador.AutoCompleteCustomSource = listaAutoCompletar
        cboTrabajador.DroppedDown = True

    End Sub

    Private Sub cboTrabajador_DropDown(sender As Object, e As EventArgs) Handles cboTrabajador.DropDown
        Cursor.Show()
        'If cboTrabajador. = True Then
        '    codigoGeneralSeleccionado = ""
        'End If
        If cboTrabajador.Text = "" Then
            dataTrabajador = doItBaby("sp_Dg_ObtenerPersonalActivoParaCombo", Nothing, Datos.Conexion.TipoQuery.DataTable)
            dataFiltrada = dataTrabajador
            cargarCombo(cboTrabajador, dataTrabajador, 0, 2)
        End If
    End Sub

    Private Sub cboTrabajador_Click(sender As Object, e As EventArgs) Handles cboTrabajador.Click
        cboTrabajador.DroppedDown = True
    End Sub

    Private Sub cboTrabajador_TextChanged(sender As Object, e As EventArgs) Handles cboTrabajador.TextChanged
        codigoGeneralSeleccionado = cboTrabajador.Text.ToString().Split("|")(0).Trim

    End Sub
End Class