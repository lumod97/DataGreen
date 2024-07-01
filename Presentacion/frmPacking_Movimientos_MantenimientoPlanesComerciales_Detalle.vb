Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion

Public Class frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle
    'Dim registroActual As Dictionary(Of String, Object)
    Dim registroActual As Registro
    Dim detalleActual As New Dictionary(Of String, Object)
    Dim dsDataParaControles As New Dictionary(Of String, DataTable)
    Dim dtDetalle As DataTable
    Dim indexFilaActual As Integer = -1
    Dim modoEdicion As Boolean

    Public Sub New(registro As Dictionary(Of String, Object))
        InitializeComponent()
        registroActual = registro
    End Sub

    Private Sub frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaControles()
        cargarControlesMaestros()
        actualizarControlesCabecera()
        detalleActual = convertirFilaADiccionario(dgvResultado, 0)
        actualizarDetalle()
        'obtenerData()
        'usarData()
        deshabilitarOrdenPorColumnas(dgvResultado)
        desactivarModoEdicion()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataParaControles()
        'dsDataParaControles = New DataSet
        Dim p As New Dictionary(Of String, Object)
        dsDataParaControles.Add("Cultivos", doItBaby("sp_Dg_ObtenerCultivos", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Add("Clientes", doItBaby("sp_Dg_ObtenerClientes", Nothing, TipoQuery.DataTable))
        'dsDataParaControles.Add("PuertosEmbarque", doItBaby("sp_Dg_ObtenerPuertosEmbarque", Nothing, TipoQuery.DataTable)) 
        dsDataParaControles.Add("PaisesEmbarque", doItBaby("sp_Dg_ObtenerPaisesEmbarque", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Add("Consignatarios", doItBaby("sp_Dg_ObtenerClientes", Nothing, TipoQuery.DataTable))
        p.Add("@MostrarOpcionTodos", 0)
        dsDataParaControles.Add("Campanas", doItBaby("sp_Dg_ObtenerCampanas", p, TipoQuery.DataTable))
        dsDataParaControles.Add("TiposPrecioExportacion", doItBaby("sp_Dg_ObtenerTiposPrecioExportacion", Nothing, TipoQuery.DataTable))
        'If registroActual.Count > 0 Then
        '    p.Clear()
        p.Add("IdCultivo", registroActual.obtener("IdCultivo"))
        'p.Add("IdCultivo", "0002")
        'Else
        'p.Add("IdCultivo", "0000")
        'End If
        dsDataParaControles.Add("Variedades", doItBaby("sp_Dg_ObtenerVariedades", p, TipoQuery.DataTable))
        dsDataParaControles.Add("Empaques", doItBaby("sp_Dg_ObtenerEmpaques", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Add("Etiquetas", doItBaby("sp_Dg_ObtenerEtiquetas", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Add("Embalajes", doItBaby("sp_Dg_ObtenerEmbalajes", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Add("Categorias", doItBaby("sp_Dg_ObtenerCategorias", Nothing, TipoQuery.DataTable))
        dsDataParaControles.Add("Calibres", doItBaby("sp_Dg_ObtenerCalibres", Nothing, TipoQuery.DataTable))

    End Sub

    Private Sub cargarControlesMaestros()
        cargarTextBox(txtIdCultivo, dsDataParaControles.Item("Cultivos"))
        cargarCombo(cboCultivo, dsDataParaControles.Item("Cultivos"), 0, 1)
        cargarTextBox(txtIdCliente, dsDataParaControles.Item("Clientes"))
        cargarCombo(cboCliente, dsDataParaControles.Item("Clientes"), 0, 2)
        cargarTextBox(txtIdPaisDestino, dsDataParaControles.Item("PaisesEmbarque"))
        cargarCombo(cboPaisDestino, dsDataParaControles.Item("PaisesEmbarque"), 0, 1)
        cargarTextBox(txtIdConsignatario, dsDataParaControles.Item("Consignatarios"))
        cargarCombo(cboConsignatario, dsDataParaControles.Item("Consignatarios"), 0, 1)
        'cargarTextBox(txtIdCultivo, dsDataParaControles.Tables(4))
        cargarCombo(cboAnioCampana, dsDataParaControles.Item("Campanas"), 0, 1)
        'cargarTextBox(txtIdCultivo, dsDataParaControles.Tables(0))
        cargarCombo(cboIncoterm, dsDataParaControles.Item("TiposPrecioExportacion"), 0, 1)

        cargarTextBox(txtIdVariedad, dsDataParaControles.Item("Variedades"))
        cargarCombo(cboVariedad, dsDataParaControles.Item("Variedades"), 0, 1)

        cargarTextBox(txtIdFormato, dsDataParaControles.Item("Empaques"))
        cargarCombo(cboFormato, dsDataParaControles.Item("Empaques"), 0, 1)

        cargarTextBox(txtIdEtiqueta, dsDataParaControles.Item("Etiquetas"))
        cargarCombo(cboEtiqueta, dsDataParaControles.Item("Etiquetas"), 0, 1)

        cargarTextBox(txtIdEmbalaje, dsDataParaControles.Item("Embalajes"))
        cargarCombo(cboEmbalaje, dsDataParaControles.Item("Embalajes"), 0, 1)

        cargarTextBox(txtIdCategoria, dsDataParaControles.Item("Categorias"))
        cargarCombo(cboCategoria, dsDataParaControles.Item("Categorias"), 0, 1)

        cargarTextBox(txtIdCalibre, dsDataParaControles.Item("Calibres"))
        cargarCombo(cboCalibre, dsDataParaControles.Item("Calibres"), 0, 1)

    End Sub

    Public Shared Sub cargarTextBox(ByRef textBox As TextBox, ByVal dataTable As DataTable)
        Dim Lista As New AutoCompleteStringCollection
        For Each fila As DataRow In dataTable.Rows
            Lista.Add(fila.Item(0).ToString)
        Next
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        textBox.AutoCompleteCustomSource = Lista
        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'sp_Packing_Movimientos_MantenimientoPlanesComerciales_Detalle
    End Sub

    Private Sub actualizarDetalle()
        obtenerDetalle()
        cargarDataGridView()
        limpiarControlesDetalle()
    End Sub

    Private Sub obtenerDetalle()
        Dim p As New Dictionary(Of String, Object)
        'If registroActual.Count > 0 Then
        p.Add("@CodPlanComercial", registroActual.obtener("Codigo"))
        'Else
        'p.Add("@CodPlanComercial", "")
        'End If
        dtDetalle = doItBaby("sp_Dg_Packing_Movimientos_MantenimientoPlanesComerciales_Detalle", p, TipoQuery.DataTable)
    End Sub

    Private Sub cargarDataGridView()
        corregirTabla(dtDetalle)
        dgvResultado.DataSource = dtDetalle
        formatearDataGridView(dgvResultado)
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
    End Sub

    Private Sub limpiarControlesDetalle()
        'Throw New NotImplementedException
    End Sub

    Private Sub actualizarControlesCabecera()
        Try
            txtCodigo.Text = registroActual.obtener("Codigo")
            txtIdCultivo.Text = registroActual.obtener("IdCultivo")
            cboCultivo.SelectedValue = registroActual.obtener("IdCultivo")
            txtIdCliente.Text = registroActual.obtener("IdCliente")
            cboCliente.SelectedValue = registroActual.obtener("IdCliente")
            txtNro.Text = registroActual.obtener("Numero")
            txtIdPaisDestino.Text = registroActual.obtener("IdPaisDestino")
            cboPaisDestino.SelectedValue = registroActual.obtener("IdPaisDestino")
            txtIdConsignatario.Text = registroActual.obtener("IdConsignatario")
            cboConsignatario.SelectedValue = registroActual.obtener("IdConsignatario")
            dtpDespacho.Text = registroActual.obtener("FechaDespacho")
            cboAnioCampana.SelectedValue = registroActual.obtener("AnioCampana")
            txtIdCampana.Text = registroActual.obtener("IdCampana")
            cboCampana.SelectedValue = registroActual.obtener("IdCampana")
            txtSemanaProceso.Text = registroActual.obtener("SemanaProceso")
            cboIncoterm.SelectedValue = registroActual.obtener("Incoterm")
            txtObservacion.Text = registroActual.obtener("Observacion")
            txtSemanaZarpe.Text = registroActual.obtener("SemanaZarpe")
            txtEstatus.Text = registroActual.obtener("Estado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub actualizarControlesDetalle(d As Dictionary(Of String, Object))
        txtIdVariedad.Text = d.Item("T_IdVariedad")
        cboVariedad.SelectedValue = d.Item("T_IdVariedad")
        txtIdFormato.Text = d.Item("T_IdFormato")
        cboFormato.SelectedValue = d.Item("T_IdFormato")
        txtIdEtiqueta.Text = d.Item("T_IdEtiqueta")
        cboEtiqueta.SelectedValue = d.Item("T_IdEtiqueta")
        txtIdEmbalaje.Text = d.Item("T_IdEmbalaje")
        cboEmbalaje.SelectedValue = d.Item("T_IdEmbalaje")
        txtIdCategoria.Text = d.Item("T_IdCategoria")
        cboCategoria.SelectedValue = d.Item("T_IdCategoria")
        txtIdCalibre.Text = d.Item("T_Calibre")
        cboCalibre.SelectedValue = d.Item("T_Calibre")
        txtCantidad.Text = d.Item("Cantidad")
        txtNroPallets.Text = d.Item("NroPallets")
    End Sub

    Private Sub driverTextBox(sender As Object, e As EventArgs) Handles txtIdCultivo.Leave, txtIdCliente.Leave, txtIdPaisDestino.Leave, txtIdConsignatario.Leave, txtIdCampana.Leave, txtIdVariedad.Leave, txtIdFormato.Leave, txtIdEtiqueta.Leave, txtIdEmbalaje.Leave, txtIdCategoria.Leave, txtIdCalibre.Leave, txtCantidad.Leave, txtNroPallets.Leave, txtNro.Leave, txtSemanaProceso.Leave, txtSemanaZarpe.Leave, txtObservacion.Leave, txtEstatus.Leave
        Select Case sender.name
            Case "txtIdCultivo"
                cboCultivo.SelectedValue = txtIdCultivo.Text
                If modoEdicion Then
                    registroActual.Item("IdCultivo") = txtIdCultivo.Text
                    registroActual.Item("Cultivo") = cboCultivo.Text
                End If
            Case "txtIdCliente"
                cboCliente.SelectedValue = txtIdCliente.Text
                If modoEdicion Then
                    registroActual.Item("IdCliente") = txtIdCliente.Text
                    registroActual.Item("Cliente") = cboCliente.Text
                End If
            Case "txtNro"
                'cboPuertoDestino.SelectedValue = txtIdPuertoDestino.Text
                If modoEdicion Then
                    registroActual.Item("Numero") = txtNro.Text
                    'registroActual.Item("Numero") = cboPuertoDestino.Text
                End If
            Case "txtIdPaisDestino"
                cboPaisDestino.SelectedValue = txtIdPaisDestino.Text
                If modoEdicion Then
                    registroActual.Item("IdPaisDestino") = txtIdPaisDestino.Text
                    registroActual.Item("PaisDestino") = cboPaisDestino.Text
                End If
            Case "txtIdConsignatario"
                cboConsignatario.SelectedValue = txtIdConsignatario.Text
                If modoEdicion Then
                    registroActual.Item("IdConsignatario") = txtIdConsignatario.Text
                    registroActual.Item("Consignatario") = cboConsignatario.Text
                End If
            Case "txtIdCampana"
                cboCampana.SelectedValue = txtIdCampana.Text
                If modoEdicion Then
                    registroActual.Item("IdCampana") = txtIdCampana.Text
                    registroActual.Item("Campana") = cboCampana.Text
                End If
            Case "txtSemanaProceso"
                'cboCampana.SelectedValue = txtIdCampana.Text
                If modoEdicion Then
                    registroActual.Item("SemanaProceso") = txtSemanaProceso.Text
                    'registroActual.Item("Campana") = cboCampana.'Text
                End If
            Case "txtSemanaZarpe"
                'cboCampana.SelectedValue = txtIdCampana.Text
                If modoEdicion Then
                    registroActual.Item("SemanaZarpe") = txtSemanaZarpe.Text
                    'registroActual.Item("Campana") = cboCampana.Text
                End If
            Case "txtEstatus"
                'cboCampana.SelectedValue = txtIdCampana.Text
                If modoEdicion Then
                    registroActual.Item("Estado") = txtEstatus.Text
                    'registroActual.Item("Campana") = cboCampana.Text
                End If
            Case "txtObservacion"
                'cboCampana.SelectedValue = txtIdCampana.Text
                If modoEdicion Then
                    registroActual.Item("Observacion") = txtObservacion.Text
                    'registroActual.Item("Campana") = cboCampana.Text
                End If
                'detalle
            Case "txtIdVariedad"
                cboVariedad.SelectedValue = txtIdVariedad.Text
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_IdVariedad") = txtIdVariedad.Text
                    dtDetalle.Rows(indexFilaActual).Item("T_Variedad") = cboVariedad.Text
                End If
            Case "txtIdFormato"
                cboFormato.SelectedValue = txtIdFormato.Text
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_IdFormato") = txtIdFormato.Text
                    dtDetalle.Rows(indexFilaActual).Item("T_Formato") = cboFormato.Text
                End If
            Case "txtIdEtiqueta"
                cboEtiqueta.SelectedValue = txtIdEtiqueta.Text
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_IdEtiqueta") = txtIdEtiqueta.Text
                    dtDetalle.Rows(indexFilaActual).Item("T_Etiqueta") = cboEtiqueta.Text
                End If
            Case "txtIdEmbalaje"
                cboEmbalaje.SelectedValue = txtIdEmbalaje.Text
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_IdEmbalaje") = txtIdEmbalaje.Text
                    dtDetalle.Rows(indexFilaActual).Item("T_Embalaje") = cboEmbalaje.Text
                End If
            Case "txtIdCategoria"
                cboCategoria.SelectedValue = txtIdCategoria.Text
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_IdCategoria") = txtIdCategoria.Text
                    dtDetalle.Rows(indexFilaActual).Item("T_Categoria") = cboCategoria.Text
                End If
            Case "txtIdCalibre"
                cboCalibre.SelectedValue = txtIdCalibre.Text
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_IdCalibre") = txtIdCalibre.Text
                    dtDetalle.Rows(indexFilaActual).Item("T_Calibre") = cboCalibre.Text
                End If
            Case "txtCantidad"
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("Cantidad") = txtCantidad.Text
                End If
            Case "txtNroPallets"
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("NroPallets") = txtNroPallets.Text
                End If
        End Select
        dgvResultado.AutoResizeColumns()
    End Sub

    Private Sub driverComboBox(sender As Object, e As EventArgs) Handles cboCultivo.SelectionChangeCommitted, cboCliente.SelectionChangeCommitted, cboPaisDestino.SelectionChangeCommitted, cboConsignatario.SelectionChangeCommitted, cboCampana.SelectionChangeCommitted, cboVariedad.SelectionChangeCommitted, cboFormato.SelectionChangeCommitted, cboEtiqueta.SelectionChangeCommitted, cboEmbalaje.SelectionChangeCommitted, cboCategoria.SelectionChangeCommitted, cboCalibre.SelectionChangeCommitted, cboIncoterm.SelectionChangeCommitted
        Select Case sender.name
            Case "cboCultivo"
                txtIdCultivo.Text = cboCultivo.SelectedValue
                If modoEdicion Then
                    registroActual.Item("Cultivo") = cboCultivo.SelectedItem.item(1)
                    registroActual.Item("IdCultivo") = cboCultivo.SelectedValue
                    cargarControlesDeVariedades()
                End If
            Case "cboCliente"
                txtIdCliente.Text = cboCliente.SelectedValue
                If modoEdicion Then
                    registroActual.Item("Cliente") = cboCliente.SelectedItem.item(1)
                    registroActual.Item("IdCliente") = cboCliente.SelectedValue
                End If
            Case "cboPaisDestino"
                txtIdPaisDestino.Text = cboPaisDestino.SelectedValue
                If modoEdicion Then
                    registroActual.Item("PaisDestino") = cboPaisDestino.SelectedItem.item(1)
                    registroActual.Item("IdPaisDestino") = cboPaisDestino.SelectedValue
                End If
            Case "cboConsignatario"
                txtIdConsignatario.Text = cboConsignatario.SelectedValue
                If modoEdicion Then
                    registroActual.Item("Consignatario") = cboConsignatario.SelectedItem.item(1)
                    registroActual.Item("IdConsignatario") = cboConsignatario.SelectedValue
                End If
            Case "cboCampana"
                txtIdCampana.Text = cboCampana.SelectedValue
                If modoEdicion Then
                    registroActual.Item("Campana") = cboCampana.SelectedItem.item(1)
                    registroActual.Item("IdCampana") = cboCampana.SelectedValue
                End If
            Case "cboIncoterm"
                'txtIdCampana.Text = cboCampana.SelectedValue
                If modoEdicion Then
                    registroActual.Item("Incoterm") = cboIncoterm.SelectedValue 'SelectedItem.item(1)
                    'registroActual.Item("IdCampana") = cboCampana.SelectedValue
                End If
                'Detalle
            Case "cboVariedad"
                txtIdVariedad.Text = cboVariedad.SelectedValue
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_Variedad") = cboVariedad.SelectedItem.item(1)
                    dtDetalle.Rows(indexFilaActual).Item("T_IdVariedad") = cboVariedad.SelectedValue
                End If
            Case "cboFormato"
                txtIdFormato.Text = cboFormato.SelectedValue
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_Formato") = cboFormato.SelectedItem.item(1)
                    dtDetalle.Rows(indexFilaActual).Item("T_IdFormato") = cboFormato.SelectedValue
                End If
            Case "cboEtiqueta"
                txtIdEtiqueta.Text = cboEtiqueta.SelectedValue
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_Etiqueta") = cboEtiqueta.SelectedItem.item(1)
                    dtDetalle.Rows(indexFilaActual).Item("T_IdEtiqueta") = cboEtiqueta.SelectedValue
                End If
            Case "cboEmbalaje"
                txtIdEmbalaje.Text = cboEmbalaje.SelectedValue
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_Embalaje") = cboEmbalaje.SelectedItem.item(1)
                    dtDetalle.Rows(indexFilaActual).Item("T_IdEmbalaje") = cboEmbalaje.SelectedValue
                End If
            Case "cboCategoria"
                txtIdCategoria.Text = cboCategoria.SelectedValue
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_Categoria") = cboCategoria.SelectedItem.item(1)
                    dtDetalle.Rows(indexFilaActual).Item("T_IdCategoria") = cboCategoria.SelectedValue
                End If
            Case "cboCalibre"
                txtIdCalibre.Text = cboCalibre.SelectedValue
                If modoEdicion And indexFilaActual >= 0 Then
                    dtDetalle.Rows(indexFilaActual).Item("T_Calibre") = cboCalibre.SelectedValue
                    'dtDetalle.Rows(filaActual).Item("T_IdCalibre") = cboCalibre.SelectedValue
                End If
        End Select
        dgvResultado.AutoResizeColumns()
    End Sub

    Private Sub cboAnioCampana_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAnioCampana.SelectionChangeCommitted
        cargarControlesDeCampana()
        If modoEdicion Then
            registroActual.Item("AnioCampana") = cboAnioCampana.SelectedValue
            'egistroActual.Item("IdCampana") = cboCampana.SelectedValue
        End If
    End Sub


    Private Sub cargarControlesDeCampana()
        If dsDataParaControles.Keys.Contains("CampanasPacking") Then
            dsDataParaControles.Remove("CampanasPacking")
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@AnioCampana", cboAnioCampana.SelectedValue)
        dsDataParaControles.Add("CampanasPacking", doItBaby("sp_Dg_ObtenerCampanaPackingXAnio", p, TipoQuery.DataTable))
        cargarCombo(cboCampana, dsDataParaControles.Item("CampanasPacking"), 0, 1)
        cargarTextBox(txtIdCampana, dsDataParaControles.Item("CampanasPacking"))
    End Sub

    Private Sub cargarControlesDeVariedades()
        If dsDataParaControles.Keys.Contains("Variedades") Then
            dsDataParaControles.Remove("Variedades")
        End If
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCultivo", cboCultivo.SelectedValue)
        dsDataParaControles.Add("Variedades", doItBaby("sp_Dg_ObtenerVariedades", p, TipoQuery.DataTable))
        cargarCombo(cboVariedad, dsDataParaControles.Item("Variedades"), 0, 1)
        cargarTextBox(txtIdVariedad, dsDataParaControles.Item("Variedades"))
    End Sub

    'Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
    '    If e.RowIndex >= 0 Then
    '        filaActual = e.RowIndex
    '        detalleActual = convertirFilaADiccionario(dgvResultado, filaActual)
    '        actualizarControlesDetalle(detalleActual)
    '    End If
    '    MessageBox.Show("CELLCLICK")
    'End Sub


    Private Sub btnMas_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        Dim i As Integer = dgvResultado.Rows.Count
        Dim f As DataRow = dtDetalle.NewRow()
        Dim d As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        d = convertirFilaADiccionario(f)
        actualizarValoresEnDiccionario(d)
        actualizarItem(d, i + 1)
        f = convertirDicionarioEnFila(d, dtDetalle)
        dtDetalle.Rows.Add(f)
        dgvResultado.ClearSelection()
        'dgvResultado.Rows(i).Selected = True
        indexFilaActual = i 'e.RowIndex
        detalleActual = convertirFilaADiccionario(dgvResultado, indexFilaActual)
        'actualizarControlesDetalle(detalleActual)
        formatearDataGridView(dgvResultado)
        indexFilaActual = -1
    End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        dtDetalle.Rows.RemoveAt(indexFilaActual)
        actualizarItemsId(dtDetalle, 0, "N")
        indexFilaActual = -1
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        activarModoEdicion()
    End Sub

    Private Sub desactivarModoEdicion()
        modoEdicion = False
        tlpCabecera.Enabled = False
        tlpDetalle1.Enabled = False
        tlpDetalle2.Enabled = False
        btnEditar.Enabled = True
        'btnEditar.BackColor = blancoPuro_
        'btnEditar.ForeColor = grisNoventa
        tlpEdicion.BackColor = blancoPuro_
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        'If registroActual.obtener("IdRegistro").ToString.Length > 0 Then
        '    txtlblCodigo.Enabled = False
        'Else
        '    txtlblCodigo.Enabled = True
        'End If
        txtCodigo.Enabled = False
    End Sub

    Private Sub activarModoEdicion()
        modoEdicion = True
        tlpCabecera.Enabled = True
        tlpDetalle1.Enabled = True
        tlpDetalle2.Enabled = True
        btnEditar.Enabled = False
        'btnEditar.BackColor = rosaBlanco_
        'btnEditar.ForeColor = blancoPuro_
        tlpEdicion.BackColor = rojoCandy__
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        If registroActual.obtener("IdRegistro") = "" Then
            txtCodigo.Enabled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        desactivarModoEdicion()
        actualizarControlesCabecera()
        actualizarDetalle()
        'ACTUALIZAR DETALLE
    End Sub

    'ANOTACION: ESTE SUB ES EL CORRECTO PARA HACER ACTUALIZAR UN REGISTRO EN EVENTO DE CLICK DEN DATAGRIDVIEW
    Private Sub dgvResultado_Click(sender As Object, e As EventArgs) Handles dgvResultado.Click
        'MessageBox.Show("CLICK")
        Dim i = dgvResultado.CurrentRow.Index
        If i >= 0 Then
            indexFilaActual = i 'e.RowIndex
            detalleActual = convertirFilaADiccionario(dgvResultado, indexFilaActual)
            actualizarControlesDetalle(detalleActual)
        End If
    End Sub

    Private Sub actualizarValoresEnDiccionario(d As Dictionary(Of String, Object))
        'Dim r As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        d.Item("T_IdVariedad") = cboVariedad.SelectedValue
        d.Item("T_Variedad") = cboVariedad.Text
        d.Item("T_IdFormato") = cboFormato.SelectedValue
        d.Item("T_Formato") = cboFormato.Text
        d.Item("T_IdEtiqueta") = cboEtiqueta.SelectedValue
        d.Item("T_Etiqueta") = cboEtiqueta.Text
        d.Item("T_IdEmbalaje") = cboEmbalaje.SelectedValue
        d.Item("T_Embalaje") = cboEmbalaje.Text
        d.Item("T_IdCategoria") = cboCategoria.SelectedValue
        d.Item("T_Categoria") = cboCategoria.Text
        d.Item("T_Calibre") = cboCalibre.SelectedValue
        'r.Item("T_Calibre") = txtIdVariedad.Text
        d.Item("Cantidad") = txtCantidad.Text
        d.Item("NroPallets") = txtNroPallets.Text
        'Return r
    End Sub

    Private Sub cargarValoresEnFila(f As DataRow)
        Throw New NotImplementedException
    End Sub

    'Private Sub actualizarValoresEnDiccionario(d As Dictionary(Of String, Object))
    '    Throw New NotImplementedException
    'End Sub

    Private Sub actualizarItem(d As Dictionary(Of String, Object), i As Integer)
        d.Item("T_Item") = generarCorrelativo(i, 2)
    End Sub

    Private Sub actualizarItemsId(dt As DataTable, col As Integer, tipo As Char)
        If tipo = "N" Then
            Dim i As Integer = 1
            For Each f As DataRow In dt.Rows
                f.Item(col) = generarCorrelativo(i, 2)
                i += 1
            Next
        End If
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtRes As DataTable
        Dim dtGuardarCabecera As DataTable = convertirRegistroATabla(registroActual) 'convertirDicionarioATabla(registroActual)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@dtCabecera", obtenerTablaParaSP(dtGuardarCabecera))
        p.Add("@dtDetalle", obtenerTablaParaSP(dtDetalle))
        p.Add("@IdUsuario", usuarioActual)
        dtRes = doItBaby("sp_Dg_Packing_Movimientos_MantenimientoPlanesComerciales_Guardar", p, TipoQuery.DataTable)
        If dtRes.Rows(0).Item(0).ToString.Equals("1") Then
            MessageBox.Show("Registro gardado con exito.")
            registroActual.Item("Codigo") = dtRes.Rows(0).Item(1).ToString
        Else
            MessageBox.Show("No se pudo guardar el registro" & dtRes.Rows(0).Item(1).ToString)
        End If
        actualizarControlesCabecera()
        actualizarDetalle()
        'dgvResultado.DataSource = dtRes
        formatearDataGridView(dgvResultado)
        desactivarModoEdicion()

    End Sub

    Private Sub dtpDespacho_ValueChanged(sender As Object, e As EventArgs) Handles dtpDespacho.ValueChanged
        registroActual.Item("FechaDespacho") = dtpDespacho.Value.ToString("yyyy-MM-dd")
    End Sub

    'Private Sub cboConsignatario_Leave(sender As Object, e As EventArgs) Handles cboConsignatario.Leave
    '    cboConsignatario.SelectedValue = txtIdConsignatario.Text
    '    If modoEdicion Then
    '        registroActual.Item("IdConsignatario") = txtIdConsignatario.Text
    '        registroActual.Item("Consignatario") = cboConsignatario.Text
    '    End If
    'End Sub

    'Private Sub cboIncoterm_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboIncoterm.SelectionChangeCommitted

    'End Sub
End Class 'CONTINUAR VIENDO EL CULTIVO                                                                 