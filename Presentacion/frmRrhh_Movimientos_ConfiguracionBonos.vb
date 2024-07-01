Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_ConfiguracionBonos

    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    Dim tbDataParaTextBoxes As DataTable
    Dim filaActual As DataRow
    Dim bsFiltro As New BindingSource()
    Dim tablaDeCambios As DataTable

    Private Sub frmRrhh_Movimientos_ConfiguracionBonos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaCombos()
        cargarCombo(cboPlanilla, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboGrupoLabor, dsDataParaCombo.Tables(1), "", True)
        cargarCombo(cboConcepto, dsDataParaCombo.Tables(2), "", True)
        obtenerDataParaTextBoxes()
        cargarTextBoxes()
        obtenerDataResultado()
        cargarDataResultado()
        inicializarTablaDeCambios()
        manejarControles("StandBy")
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerGruposLabor", Nothing, TipoQuery.DataTable))
        dsDataParaCombo.Tables.Add(doItBaby("sp_ObtenerConceptosRemunerativos", Nothing, TipoQuery.DataTable))
        'dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerModulosCampo", Nothing, TipoQuery.DataTable))
    End Sub


    Private Sub obtenerDataParaTextBoxes()
        tbDataParaTextBoxes = New DataTable
        tbDataParaTextBoxes = doItBaby("sp_Dg_Rrhh_Movimientos_ConfigurarBonos_DataParaTextboxes", Nothing, TipoQuery.DataTable)
    End Sub


    Private Sub cargarTextBoxes()

        Dim lsDnis As New AutoCompleteStringCollection
        Dim lsCodigos As New AutoCompleteStringCollection
        Dim lsNombres As New AutoCompleteStringCollection

        For Each fila As DataRow In tbDataParaTextBoxes.Rows
            lsDnis.Add(fila.Item(0).ToString)
            lsCodigos.Add(fila.Item(1).ToString)
            lsNombres.Add(fila.Item(2).ToString)
        Next

        txtDni.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDni.AutoCompleteCustomSource = lsDnis
        txtDni.AutoCompleteMode = AutoCompleteMode.Suggest


        txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCodigo.AutoCompleteCustomSource = lsCodigos
        txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest

        txtNombres.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtNombres.AutoCompleteCustomSource = lsNombres
        txtNombres.AutoCompleteMode = AutoCompleteMode.Suggest

    End Sub
    Private Sub obtenerDataResultado()
        tablaResultado = New DataTable
        tablaResultado = doItBaby("sp_Dg_Rrhh_Movimientos_ConfigurarBonos_ObtenerResultado", Nothing, TipoQuery.DataTable)
    End Sub

    Private Sub cargarDataResultado()
        corregirTabla(tablaResultado)
        Dim dvFiltro As New DataView(tablaResultado)
        bsFiltro.DataSource = dvFiltro
        dgvResultado.DataSource = bsFiltro
        'dgvResultado.DataSource = tablaResultado
        formatearDataGridView(dgvResultado)
        cboPlanilla.SelectedIndex = -1
        cboGrupoLabor.SelectedIndex = -1
        cboConcepto.SelectedIndex = -1
        dgvResultado.Columns("T_TipoModificacion").Visible = False
        lblResultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            filaActual = buscarFila(dgvResultado.Rows(e.RowIndex).Cells(0).Value, tablaResultado)
            cargarControles(filaActual)
        End If
    End Sub

    Private Function buscarFila(id As String, tabla As DataTable) As DataRow
        Dim filtro As String = "T_Id = '" & id & "'"
        Return tabla.Select(filtro)(0)
    End Function

    Private Sub cargarControles(filaActual As DataRow)
        lblIdRegistro.Text = filaActual.Item(0)
        txtDni.Text = filaActual.Item(1)
        txtCodigo.Text = filaActual.Item(2)
        txtNombres.Text = filaActual.Item(3)
        cboPlanilla.SelectedValue = filaActual.Item(4)
        cboGrupoLabor.SelectedValue = filaActual.Item(5)
        cboConcepto.SelectedValue = filaActual.Item(7)
        txtBono.Text = filaActual.Item(9)
    End Sub

    'Private Sub txtDni_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDni.KeyUp
    '    actualizarFiltro()
    'End Sub

    'Private Sub txtCodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyUp
    '    actualizarFiltro()
    'End Sub

    'Private Sub txtNombres_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombres.KeyUp
    '    actualizarFiltro()
    'End Sub

    'Private Sub cboPlanilla_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPlanilla.SelectionChangeCommitted
    '    actualizarFiltro()
    'End Sub

    'Private Sub cboGrupoLabor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboGrupoLabor.SelectionChangeCommitted
    '    actualizarFiltro()
    'End Sub

    'Private Sub cboConcepto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboConcepto.SelectionChangeCommitted
    '    actualizarFiltro()
    'End Sub

    Private Sub actualizarFiltro()
        bsFiltro.Filter = String.Format("T_Dni like '%{0}%' Or " +
                                              "T_Codigo like '%{1}%' Or " +
                                              "T_Nombres like '%{2}%' Or " +
                                              "T_IdPlanilla like '%{3}%' Or " +
                                              "T_GrupoLabor like '%{4}%' Or " +
                                              "T_Concepto like '%{5}%'",
                                              txtFiltro.Text,
                                              txtFiltro.Text,
                                              txtFiltro.Text,
                                              txtFiltro.Text,
                                              txtFiltro.Text,
                                              txtFiltro.Text
                                              )
        formatearDataGridView(dgvResultado)
        lblResultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
        'If dgvResultado.Rows.Count < 1 Then
        '    lblIdRegistro.Text = "Nuevo"
        'Else
        '    lblIdRegistro.Text = dgvResultado.Rows(0).Cells(0).Value
        'End If
        'lblIdRegistro.Text = dgvResultado.Rows(0).Cells(0).Value
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        manejarControles("StandBy")
        limpiarControles()
        'cargarDataResultado()
        actualizarFiltro()
        'bloquearControl(btnAgregar)
    End Sub

    Private Sub limpiarControles()
        txtDni.Text = ""
        txtCodigo.Text = ""
        txtNombres.Text = ""
        cboPlanilla.SelectedIndex = -1
        cboGrupoLabor.SelectedIndex = -1
        cboConcepto.SelectedIndex = -1
        txtBono.Text = ""
        txtFiltro.Text = ""
    End Sub

    Private Sub inicializarTablaDeCambios()
        tablaDeCambios = tablaResultado.Clone
        tablaDeCambios.Rows.Clear()
        'tablaDeCambios.Columns.Add("TipoModificacion")
    End Sub

    Private Sub bloquearControles()
        btnEditar.Enabled = False
        btnGuardar.Enabled = False
        btnAgregar.Enabled = False
        btnEliminar.Enabled = False
        bloquearFilas(dgvResultado)
    End Sub

    Private Sub desbloquearControles()
        btnEditar.Enabled = True
        btnGuardar.Enabled = True
        btnAgregar.Enabled = True
        btnEliminar.Enabled = True
        desbloquearFilas(dgvResultado)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        manejarControles("Editar")
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim i As Integer = encontrarIndice(lblIdRegistro.Text)
        If i < 0 Then
            Dim filaNueva As DataRow = tablaDeCambios.NewRow()
            Dim filaPresentada As DataRow = tablaResultado.NewRow()
            filaNueva = convertirAFila("N")
            copiarFilas(filaNueva, filaPresentada)
            'filaPresentada = convertirAFila("N")
            tablaResultado.Rows.Add(filaPresentada)
            tablaDeCambios.Rows.Add(filaNueva)
        Else
            Dim filaNueva As DataRow = tablaDeCambios.NewRow()
            filaNueva = convertirAFila("M")
            For c As Integer = 0 To tablaResultado.Columns.Count - 1 Step 1
                tablaResultado.Rows(i).Item(c) = filaNueva.Item(c)
            Next
            tablaDeCambios.Rows.Add(filaNueva)
        End If
    End Sub

    Private Function encontrarIndice(s As String) As Integer
        For i As Integer = 0 To tablaResultado.Rows.Count - 1 Step 1
            If tablaResultado.Rows(i).Item(0) = s Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim i As Integer = encontrarIndice(lblIdRegistro.Text)
        If i < 0 Then
            MessageBox.Show("Debe de seleccionar 1 fila para eliminar.")
        Else
            Dim filaNueva As DataRow = tablaDeCambios.NewRow()
            filaNueva = convertirAFila("E")
            tablaDeCambios.Rows.Add(filaNueva)
            tablaResultado.Rows.RemoveAt(i)
        End If
    End Sub

    Private Function convertirAFila(tipo As String) As DataRow
        Dim r As DataRow = tablaDeCambios.NewRow()
        r.Item(0) = lblIdRegistro.Text
        r.Item(1) = txtDni.Text
        r.Item(2) = txtCodigo.Text
        r.Item(3) = txtNombres.Text
        r.Item(4) = cboPlanilla.SelectedValue
        r.Item(5) = cboGrupoLabor.SelectedValue
        r.Item(6) = Split(cboGrupoLabor.Text, " | ")(1)
        r.Item(7) = cboConcepto.SelectedValue
        r.Item(8) = Split(cboConcepto.Text, " | ")(1)
        r.Item(9) = txtBono.Text
        r.Item(10) = tipo
        Return r
    End Function

    Private Sub copiarFilas(fila1 As DataRow, ByRef fila2 As DataRow)
        For i As Integer = 0 To fila1.ItemArray.Count - 1 Step 1
            fila2.Item(i) = fila1.Item(i)
        Next
    End Sub

    Private Sub txtNombres_Leave(sender As Object, e As EventArgs) Handles txtNombres.Leave
        Dim s As String()
        s = Split(txtNombres.Text, " | ")
        txtNombres.Text = s(0)
        If s.Length > 1 Then
            cboPlanilla.SelectedValue = s(1)
            txtDni.Text = s(2)
            txtCodigo.Text = s(3)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If tablaDeCambios.Rows.Count > 0 Then
            Dim r As DialogResult = MessageBox.Show("¿Desa guardar los cambios realizados?", "Guardar", MessageBoxButtons.YesNo)
            If r = Windows.Forms.DialogResult.Yes Then
                Dim p As New Dictionary(Of String, Object)
                For Each f As DataRow In tablaDeCambios.Rows
                    p.Clear()
                    p.Add("@Parametros", filaACadena(f))
                    p.Add("@Usuario", usuarioActual)
                    doItBaby("sp_Dg_Rrhh_Movimientos_ConfigurarBonos_Guardar", p, TipoQuery.NonQuery)
                Next
                obtenerDataResultado()
                cargarDataResultado()
                MessageBox.Show("Registros guardados correctamente.")
            End If
        End If
        limpiarControles()
        actualizarFiltro()
        manejarControles("StandBy")
    End Sub

    Private Function filaACadena(fila As DataRow) As String
        Dim r As String = String.Empty
        For Each i In fila.ItemArray
            r = r & IIf(r.Length = 0, "", "!") & i.ToString
        Next
        Return r
    End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        manejarControles("Nuevo")
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        actualizarFiltro()
    End Sub

    Private Sub manejarControles(modo As String)
        Select modo
            Case "StandBy"
                limpiarControles()
                btnNuevo.Enabled = True
                btnEditar.Enabled = True
                btnCancelar.Enabled = True
                btnGuardar.Enabled = False
                btnAgregar.Enabled = False
                btnEliminar.Enabled = False
                desbloquearFilas(dgvResultado)
            Case "Nuevo"
                lblIdRegistro.Text = "Nuevo"
                limpiarControles()
                btnNuevo.Enabled = False
                btnEditar.Enabled = False
                btnCancelar.Enabled = True
                btnGuardar.Enabled = True
                btnAgregar.Enabled = True
                btnEliminar.Enabled = False
                bloquearFilas(dgvResultado)
            Case "Editar"
                btnNuevo.Enabled = False
                btnEditar.Enabled = False
                btnCancelar.Enabled = True
                btnGuardar.Enabled = True
                btnAgregar.Enabled = True
                btnEliminar.Enabled = True
                bloquearFilas(dgvResultado)
        End Select
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '     MessageBox.Show("Error, no hay registros para exportar")
        ' Else
        '     'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '     Dim dDgvs As New Dictionary(Of String, DataGridView)
        '     dDgvs.Add("Reporte", dgvResultado)
        '     excelling(dDgvs, Me.Text, arrayDeParametros)
        ' End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                'encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                'apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
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
End Class