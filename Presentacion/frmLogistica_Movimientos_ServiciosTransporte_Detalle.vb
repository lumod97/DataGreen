Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion
Imports Entidades

Public Class frmLogistica_Movimientos_ServiciosTransporte_Detalle

    Public servicioActual As New ServicioTransporte
    'Dim aux As New ServicioTransporte
    Dim dtDetallePersona As DataTable
    Dim dtDetalleConsumidor As DataTable
    Dim dtTablaExcel As DataTable
    Dim dsMetadatos As DataSet
    'Dim esNuevo As Boolean = True
    Dim observaciones As String = String.Empty
    'Dim bsResultado As New BindingSource()
    'Dim cadena As String = String.Empty
    Dim controles As New List(Of Object)


    Public Sub New(servicio As ServicioTransporte) ', ds As DataSet, listaControles As List(Of Object))
        InitializeComponent()
        servicioActual = servicio
        'aux = servicio
        'dsMetadatos = ds
        'controles = listaControles
        'cboRuc = controles.Item(0)
        'cboDniConductor = controles.Item(1)
        'cboRazonSocial = controles.Item(2)
        'cboConductor = controles.Item(3)
        'cboRuta = controles.Item(4)
        'cboPlaca = controles.Item(5)
    End Sub

    Private Sub frmLogistica_Movimientos_ServiciosTransporte_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerMetadatos()
        usarMetadatos()
        actualizaCabecera()
        obtenerDetalle()
        cargarDetalle()
        bloquearControles()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerMetadatos()
        Try
            dsMetadatos = New DataSet
            dsMetadatos = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransporte_Detalle_Metadatos", Nothing, TipoQuery.DataSet)
            'dsMetadatos.Tables(
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub usarMetadatos()
        cargarCombo(cboPlaca, dsMetadatos.Tables(0).Copy, 0, 2)
        cargarCombo(cboRuc, dsMetadatos.Tables(1).Copy, 0, 0)
        cargarCombo(cboRazonSocial, dsMetadatos.Tables(1).Copy, 0, 1)
        cargarCombo(cboDniConductor, dsMetadatos.Tables(2).Copy, 0, 0)
        cargarCombo(cboConductor, dsMetadatos.Tables(2).Copy, 0, 1)
        cargarCombo(cboRuta, dsMetadatos.Tables(3).Copy, 0, 2)
        cargarCombo(cboConsumidor, dsMetadatos.Tables(4).Copy, 0, 2)

        Dim dnis As New AutoCompleteStringCollection
        For Each fila As DataRow In dsMetadatos.Tables(5).Rows
            dnis.Add(fila.Item(0).ToString)
        Next
        txtDni.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDni.AutoCompleteCustomSource = dnis
        txtDni.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        Dim nombres As New AutoCompleteStringCollection
        For Each fila As DataRow In dsMetadatos.Tables(5).Rows
            nombres.Add(fila.Item(1).ToString)
        Next
        txtNombres.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtNombres.AutoCompleteCustomSource = nombres
        txtNombres.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub actualizaCabecera()
        lblId.Text = servicioActual.Id
        dtpFecha.Value = servicioActual.Fecha
        'cboEstado.SelectedValue = servicioActual.IdEstado
        lblEstado.Text = servicioActual.Estado
        lblResponsable.Text = servicioActual.UsuarioCrea
        txtObs.Text = servicioActual.Obs
        lblNroFactura.Text = servicioActual.NroFactura
        'lblIdRuta.Text = servicioActual.IdRuta
        lblOrdenServicio.Text = servicioActual.IdPedidoServicio
        lblMarca.Text = servicioActual.Marca
        lblModelo.Text = servicioActual.Modelo
        lblColor.Text = servicioActual.Color
        'lblTotalPasajeros.Text = servicioActual.Pasajeros.ToString
        lblTotalPasajeros.Text = servicioActual.Pasajeros.ToString("F2")
        txtTarifa.Text = servicioActual.Tarifa.ToString("F2")
        txtDscto.Text = servicioActual.Dscto.ToString("F2")
        lblSubTotal.Text = servicioActual.SubTotal.ToString("F2")
        lblRedondeo.Text = servicioActual.Redondeo.ToString("F2")
        lblTotal.Text = servicioActual.Total.ToString("F2")
        If servicioActual.Id.Length > 0 Then
            cboRuc.SelectedValue = servicioActual.RucProveedor
            cboDniConductor.SelectedValue = servicioActual.DniConductor
            cboRazonSocial.SelectedValue = servicioActual.RucProveedor
            cboConductor.SelectedValue = servicioActual.DniConductor
            cboRuta.SelectedValue = servicioActual.IdRuta
            cboPlaca.SelectedValue = servicioActual.Placa
            dtpHoraPartida.Value = New DateTime(Now.Year, Now.Month, Now.Day, servicioActual.HoraPartida.Hour, servicioActual.HoraPartida.Minute, 0) ' 
            dtpHoraRetorno.Value = New DateTime(Now.Year, Now.Month, Now.Day, servicioActual.HoraRetorno.Hour, servicioActual.HoraRetorno.Minute, 0) '
        End If
    End Sub

    Private Sub bloquearControles()
        If servicioActual.Id.Length > 0 Then
            dtpFecha.Enabled = False
            'cboEstado.Enabled = False
            cboRuc.Enabled = False
            cboDniConductor.Enabled = False
            cboRazonSocial.Enabled = False
            cboConductor.Enabled = False
            cboRuta.Enabled = False
            cboPlaca.Enabled = False
            'cbxCalcularPasajeros.Enabled = False
            'lblTotalPasajeros.Enabled = False
            txtTarifa.Enabled = False
            txtDscto.Enabled = False
            txtObs.Enabled = False
            btnGuardar.Enabled = False
            btnCancelar.Enabled = False
            'dgvResultado.Enabled = False
            btnEditar.Enabled = True
            cboConsumidor.Enabled = False
            txtCantidadPasajeros.Enabled = False
            btnMas.Enabled = False
            btnActualizarFila.Enabled = False
            btnMenos.Enabled = False
            btnFormato.Enabled = False
            btnPuntitos.Enabled = False
            btnImportar.Enabled = False
            txtRuta.Enabled = False
            radDetallePersona.Enabled = False
            radDetalleConsumidor.Enabled = False
            txtDni.Enabled = False
            txtNombres.Enabled = False
            dtpHoraPartida.Enabled = False
            dtpHoraRetorno.Enabled = False
            cbxLeerFotochecks.Enabled = False
        End If
        'txtDni.Enabled = False
        'txtNombre.Enabled = False

    End Sub

    Private Sub desbloquearControles()
        dtpFecha.Enabled = True
        'cboEstado.Enabled = True
        cboRuc.Enabled = True
        cboDniConductor.Enabled = True
        cboRazonSocial.Enabled = True
        cboConductor.Enabled = True
        cboRuta.Enabled = True
        cboPlaca.Enabled = True
        'cbxCalcularPasajeros.Enabled = True
        'txtPasajeros.Enabled = True
        txtTarifa.Enabled = True
        txtDscto.Enabled = True
        txtObs.Enabled = True
        'txtDni.Enabled = True
        'txtNombre.Enabled = True
        'btnMas.Enabled = True
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        'dgvResultado.Enabled = True
        btnEditar.Enabled = False

        cboConsumidor.Enabled = True
        txtCantidadPasajeros.Enabled = True
        btnMas.Enabled = True
        btnActualizarFila.Enabled = True
        btnMenos.Enabled = True
        btnFormato.Enabled = True
        btnPuntitos.Enabled = True
        btnImportar.Enabled = True
        txtRuta.Enabled = True
        radDetallePersona.Enabled = True
        radDetalleConsumidor.Enabled = True
        txtDni.Enabled = True
        txtNombres.Enabled = True
        dtpHoraPartida.Enabled = True
        dtpHoraRetorno.Enabled = True
        cbxLeerFotochecks.Enabled = True
    End Sub

    Private Sub obtenerDetalle()
        Try
            Dim p As New Dictionary(Of String, Object)
            Dim ds As New DataSet
            p.Add("@IdServicioTransporte", servicioActual.Id)
            ds = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransporte_Detalle_ObtenerDetalle", p, TipoQuery.DataSet)
            dtDetallePersona = ds.Tables(0)
            dtDetalleConsumidor = ds.Tables(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarDetalle()
        dgvResultadoPersonas.DataSource = dtDetallePersona
        formatearDataGridView(dgvResultadoPersonas)

        dgvResultadoConsumidor.DataSource = dtDetalleConsumidor
        formatearDataGridView(dgvResultadoConsumidor)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Logistica")
        p.Add("@Dia", servicioActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede editar el Servicio porque el dia se encuentra cerrado.")
            Exit Sub
        End If
        desbloquearControles()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Modulo", "Logistica")
        p.Add("@Dia", servicioActual.Fecha)
        'DESHACER
        If doItBaby("sp_Dg_ConsultarEstadoDia", p, TipoQuery.Scalar) = 0 Then
            MessageBox.Show("No se puede guardar el Servicio porque el dia se encuentra cerrado.")
            Exit Sub
        End If
        Dim idGuardado As String = String.Empty
        Dim idDetalleGuardado As String = String.Empty
        Try
            observaciones = validarDatos()
            If observaciones <> "Ok" Then
                MessageBox.Show(observaciones)
                Exit Sub
            Else
                Dim cadenaParametros = String.Empty
                'Dim fila As DataGridViewRow = dgvResultado.SelectedRows.Item(0)
                encadenar(cadenaParametros, servicioActual.Id)
                encadenar(cadenaParametros, servicioActual.IdPedidoServicio)
                encadenar(cadenaParametros, servicioActual.Fecha.ToString("yyyy-MM-dd"))
                encadenar(cadenaParametros, servicioActual.Placa)
                encadenar(cadenaParametros, servicioActual.RucProveedor)
                encadenar(cadenaParametros, servicioActual.NroFactura)
                encadenar(cadenaParametros, servicioActual.DniConductor)
                encadenar(cadenaParametros, servicioActual.IdRuta)
                encadenar(cadenaParametros, servicioActual.Pasajeros.ToString)
                encadenar(cadenaParametros, servicioActual.Tarifa.ToString("F2"))
                encadenar(cadenaParametros, servicioActual.Dscto.ToString("F2"))
                encadenar(cadenaParametros, servicioActual.SubTotal.ToString("F2"))
                encadenar(cadenaParametros, servicioActual.Redondeo.ToString("F2"))
                encadenar(cadenaParametros, servicioActual.Total.ToString("F2"))
                encadenar(cadenaParametros, servicioActual.Obs)
                encadenar(cadenaParametros, servicioActual.IdEstado)
                encadenar(cadenaParametros, servicioActual.UsuarioCrea)
                encadenar(cadenaParametros, usuarioActual)
                encadenar(cadenaParametros, dtpHoraPartida.Value.ToString("hh:mm"))
                encadenar(cadenaParametros, dtpHoraRetorno.Value.ToString("hh:mm"))

                'Dim p As New Dictionary(Of String, Object)
                p.Clear()
                p.Add("@CadenaParametros", cadenaParametros)
                idGuardado = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransportes_GuardarCabecera", p, TipoQuery.Scalar)
                If idGuardado.Substring(0, 2) = "Ok" Then
                    servicioActual.Id = idGuardado.Substring(2, idGuardado.Length - 2)
                    'PRIMERO GUARDA CONSUMIDORES:
                    If dgvResultadoConsumidor.Rows.Count > 0 Then
                        For Each d As DataRow In dtDetalleConsumidor.Rows
                            cadenaParametros = String.Empty
                            p.Clear()
                            encadenar(cadenaParametros, servicioActual.Id)
                            For i As Integer = 1 To d.ItemArray.Count - 1
                                encadenar(cadenaParametros, d.Item(i).ToString)
                            Next
                            p.Add("@TipoRegistro", "C")
                            p.Add("@CadenaParametros", cadenaParametros)
                            idDetalleGuardado = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransportes_GuardarDetalle", p, TipoQuery.Scalar)
                            If idDetalleGuardado.Substring(0, 2) <> "Ok" Then
                                Throw New Exception("Error al guardar detalle. " & idDetalleGuardado)
                            End If
                        Next
                        'obtenerDetalle()
                        'cargarDetalle()
                        'MessageBox.Show("Registro guardado correctamente.")
                    End If
                    'LUEGO GUARDA PERSONAS:
                    If dgvResultadoPersonas.Rows.Count > 0 Then
                        For Each d As DataRow In dtDetallePersona.Rows
                            cadenaParametros = String.Empty
                            p.Clear()
                            encadenar(cadenaParametros, servicioActual.Id)
                            For i As Integer = 1 To d.ItemArray.Count - 1
                                encadenar(cadenaParametros, d.Item(i).ToString)
                            Next
                            p.Add("@TipoRegistro", "P")
                            p.Add("@CadenaParametros", cadenaParametros)
                            idDetalleGuardado = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransportes_GuardarDetalle", p, TipoQuery.Scalar)
                            If idDetalleGuardado.Substring(0, 2) <> "Ok" Then
                                Throw New Exception("Error al guardar detalle. " & idDetalleGuardado)
                            End If
                        Next
                        actualizaCabecera()
                        obtenerDetalle()
                        cargarDetalle()

                    End If
                    MessageBox.Show("Registro guardado correctamente.")
                    'If radDetallePersona.Checked Then
                    '    If dgvResultadoPersonas.Rows.Count > 0 Then
                    '        For Each d As DataRow In dtDetallePersona.Rows
                    '            cadenaParametros = String.Empty
                    '            p.Clear()
                    '            encadenar(cadenaParametros, servicioActual.Id)
                    '            For i As Integer = 1 To d.ItemArray.Count - 1
                    '                encadenar(cadenaParametros, d.Item(i).ToString)
                    '            Next
                    '            p.Add("@TipoRegistro", "P")
                    '            p.Add("@CadenaParametros", cadenaParametros)
                    '            idDetalleGuardado = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransportes_GuardarDetalle", p, TipoQuery.Scalar)
                    '            If idDetalleGuardado.Substring(0, 2) <> "Ok" Then
                    '                Throw New Exception("Error al guardar detalle. " & idDetalleGuardado)
                    '            End If
                    '        Next
                    '        obtenerDetalle()
                    '        cargarDetalle()
                    '        MessageBox.Show("Registro guardado correctamente.")
                    '    End If
                    'ElseIf radDetalleConsumidor.Checked Then
                    'If dgvResultadoConsumidor.Rows.Count > 0 Then
                    '    For Each d As DataRow In dtDetalleConsumidor.Rows
                    '        cadenaParametros = String.Empty
                    '        p.Clear()
                    '        encadenar(cadenaParametros, servicioActual.Id)
                    '        For i As Integer = 1 To d.ItemArray.Count - 1
                    '            encadenar(cadenaParametros, d.Item(i).ToString)
                    '        Next
                    '        p.Add("@TipoRegistro", "C")
                    '        p.Add("@CadenaParametros", cadenaParametros)
                    '        idDetalleGuardado = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransportes_GuardarDetalle", p, TipoQuery.Scalar)
                    '        If idDetalleGuardado.Substring(0, 2) <> "Ok" Then
                    '            Throw New Exception("Error al guardar detalle. " & idDetalleGuardado)
                    '        End If
                    '    Next
                    '    obtenerDetalle()
                    '    cargarDetalle()
                    '    MessageBox.Show("Registro guardado correctamente.")
                    'End If
                    'End If
                Else
                    Throw New Exception(idGuardado & " " & " " & idDetalleGuardado)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            bloquearControles()
        End Try
    End Sub

    Private Function validarDatos() As String
        If txtObs.Text.Contains("!") Then 'Or txtDni.Text.Contains(" ") Then
            Return "No puede usar el siguiente caracter especial '!'"
            'ElseIf cboEstado.SelectedIndex < 0 Then
            '    Return "Debe seleccionar un estado."
            'ElseIf Not cbxCalcularPasajeros.Checked And CType(txtPasajeros.Text, Integer) <= 0 Then
            '    Return "No se puede guardar con 0 PASAJEROS"
        ElseIf txtTarifa.Text.Length < 1 OrElse CType(txtTarifa.Text, Double) <= 0 Then
            Return "No se puede guardar una TARIFA en 0"
        ElseIf cboRuc.SelectedIndex < 0 Then
            Return "Debe seleccionar un Ruc valido."
        ElseIf cboDniConductor.SelectedIndex < 0 Then
            Return "Debe seleccionar un Dni de conductor valido."
        ElseIf cboRazonSocial.SelectedIndex < 0 Then
            Return "Debe seleccionar una razon social."
        ElseIf cboConductor.SelectedIndex < 0 Then
            Return "Debe seleccionar un conductor."
        ElseIf cboRuta.SelectedIndex < 0 Then
            Return "Debe seleccionar una ruta."
        ElseIf cboPlaca.SelectedIndex < 0 Then
            Return "Debe seleccionar una placa de vehiculo."
            'ElseIf Not cbxCalcularPasajeros.Checked AndAlso CType(txtPasajeros.Text, Double) <> Math.Floor(CType(txtPasajeros.Text, Double)) Then
            '    Return "Debe ingresar un numero de pasajeros valido."
        End If
        Return "Ok"
    End Function

    Private Sub txtPasajeros_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTarifa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarifa.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDscto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDscto.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Public Sub encadenar(ByRef cadena As String, parametro As String)
        parametro = parametro.Replace("|", "")
        If cadena.Length = 0 Then
            cadena = IIf(parametro.Length = 0, " ", parametro)
        Else
            cadena = cadena & "|" & parametro
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        servicioActual.Fecha = dtpFecha.Value
    End Sub

    'Private Sub cboEstado_SelectionChangeCommitted(sender As Object, e As EventArgs)
    '    servicioActual.IdEstado = cboEstado.SelectedValue
    '    servicioActual.Estado = cboEstado.Text
    'End Sub

    Private Sub txtObs_Leave(sender As Object, e As EventArgs) Handles txtObs.Leave
        servicioActual.Obs = txtObs.Text
    End Sub

    Private Sub cboRuc_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRuc.SelectionChangeCommitted
        servicioActual.RucProveedor = cboRuc.SelectedValue
        cboRazonSocial.SelectedValue = servicioActual.RucProveedor
        'PENDIENTE AGREGAR CAMBIOS
    End Sub

    Private Sub cboDniConductor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDniConductor.SelectionChangeCommitted
        servicioActual.DniConductor = cboDniConductor.SelectedValue
        cboConductor.SelectedValue = servicioActual.DniConductor
    End Sub

    Private Sub cboRazonSocial_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRazonSocial.SelectionChangeCommitted
        servicioActual.RucProveedor = cboRazonSocial.SelectedValue
        cboRuc.SelectedValue = servicioActual.RucProveedor
    End Sub

    Private Sub cboConductor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboConductor.SelectionChangeCommitted
        servicioActual.Conductor = cboConductor.Text
        servicioActual.DniConductor = cboConductor.SelectedValue
        cboDniConductor.SelectedValue = servicioActual.DniConductor
    End Sub

    Private Sub cboRuta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboRuta.SelectionChangeCommitted
        servicioActual.IdRuta = cboRuta.SelectedValue
        servicioActual.Ruta = cboRuta.Text
        'lblIdRuta.Text = cboRuta.SelectedValue
    End Sub

    Private Sub cboPlaca_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPlaca.SelectionChangeCommitted
        servicioActual.Placa = cboPlaca.SelectedValue
        'CONTINUAR AQUI
        Dim datosVehiculo As String = dsMetadatos.Tables(0).Compute("MAX(Concatenado)", "Clave='" & servicioActual.Placa & "'")
        lblMarca.Text = datosVehiculo.Split("|")(1) 'datosVehiculo.Substring(0,datosVehiculo.Split("!")
        lblModelo.Text = datosVehiculo.Split("|")(2)
        lblColor.Text = datosVehiculo.Split("|")(3)
    End Sub

    'Private Sub txtPasajeros_Leave(sender As Object, e As EventArgs)
    '    servicioActual.Pasajeros = CType(txtPasajeros.Text, Integer)
    'End Sub

    Private Sub txtTarifa_Leave(sender As Object, e As EventArgs) Handles txtTarifa.Leave
        servicioActual.Tarifa = CType(txtTarifa.Text, Double)
        'servicioActual.Total = servicioActual.Tarifa - servicioActual.Dscto
        'txtTarifa.Text = servicioActual.Tarifa.ToString("F2")
        'lblTotal.Text = servicioActual.Total.ToString("F2")
        servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
        actualizaCabecera()
    End Sub

    Private Sub txtDscto_Leave(sender As Object, e As EventArgs) Handles txtDscto.Leave
        servicioActual.Dscto = CType(txtDscto.Text, Double)
        'servicioActual.Total = servicioActual.Tarifa - servicioActual.Dscto
        'actualizarPasajeros()
        servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
        actualizaCabecera()
        'txtDscto.Text = servicioActual.Dscto.ToString("F2")
        'lblTotal.Text = servicioActual.Total.ToString("F2")

    End Sub

    'Private Sub cbxCalcularPasajeros_CheckStateChanged(sender As Object, e As EventArgs)
    '    If cbxCalcularPasajeros.Checked Then
    '        txtPasajeros.Enabled = False
    '        txtDni.Enabled = True
    '        txtNombre.Enabled = True
    '        btnMas.Enabled = True
    '        servicioActual.Pasajeros = dgvResultado.Rows.Count
    '    Else
    '        txtPasajeros.Enabled = True
    '        txtDni.Enabled = False
    '        txtNombre.Enabled = False
    '        btnMas.Enabled = False
    '    End If
    'End Sub

    Private Sub btnMas_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        'PERSONAS
        'T_Id	T_Item	T_Planilla	T_Dni	T_Codigo	T_Nombre	T_IdArea	T_Area	T_IdCargo	T_Cargo	T_IdConsumidor	T_Consumidor
        '000000000001	001	EMP	02896753	02896753	MANUEL SEGUNDO MONTERO LIZANO	0035      	SISTEMAS	035	JEFE DE SISTEMAS	SIST	SISTEMAS

        'CONSUMIDORES
        ' T_Id	T_Item	T_IdConsumidor	T_Consumidor	Pasajeros	D2TarifaInd	D2SubTotSinDscto	D2DsctoInd	D2SubTotDscto	D2SubTotal
        ' 000000000001	001	SIST	SISTEMAS	1	33.33	33.33	3.33	3.33	30.00
        If radDetallePersona.Checked Then
            agregarPersona(txtDni.Text, txtNombres.Text, cboConsumidor.SelectedValue)
        ElseIf radDetalleConsumidor.Checked Then
            Dim idConsumidor, nombreConsumidor As String
            Dim pasajeros As Integer
            idConsumidor = cboConsumidor.SelectedValue
            nombreConsumidor = cboConsumidor.DataSource.Compute("MAX (Valor)", "Clave='" & cboConsumidor.SelectedValue & "'") 'cboConsumidor.SelectedValue 'continuar aqui
            pasajeros = IIf(IsNumeric(txtCantidadPasajeros.Text), Integer.Parse(txtCantidadPasajeros.Text), 0)
            agregarConsumidor(idConsumidor, nombreConsumidor, pasajeros)
        End If
        servicioActual.SumarizarPersonas(dtDetallePersona, dtDetalleConsumidor)
        servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
        formatearDataGridView(dgvResultadoPersonas)
        formatearDataGridView(dgvResultadoConsumidor)
        actualizaCabecera()
        txtDni.Text = ""
        txtNombres.Text = ""
        cboConsumidor.SelectedIndex = -1
        txtCantidadPasajeros.Text = ""
        dgvResultadoConsumidor.ClearSelection()
        dgvResultadoPersonas.ClearSelection()
        If radDetallePersona.Checked Then
            txtDni.Focus()
        Else
            cboConsumidor.Focus()
        End If
    End Sub

    'Private Sub frmLogistica_Movimientos_ServiciosTransporte_Detalle_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
    '    transcribirCabecera()
    '    obtenerDetalle()
    '    cargarDetalle()
    'End Sub

    'Private Sub txtDni_Leave(sender As Object, e As EventArgs)
    '    Try
    '        txtNombre.Text = Split(txtDni.Text, "|")(1)
    '        txtDni.Text = Split(txtDni.Text, "|")(0)
    '    Catch
    '    End Try
    'End Sub

    'Private Sub txtNombre_Leave(sender As Object, e As EventArgs)
    '    Try
    '        txtDni.Text = Split(txtNombre.Text, "|")(1)
    '        txtNombre.Text = Split(txtNombre.Text, "|")(0)
    '    Catch
    '    End Try
    'End Sub

    'Private Sub actualizarDetalle()
    '    ' T_Id	T_Item	T_IdConsumidor	T_Consumidor	Pasajeros	D2TarifaInd	D2SubTotSinDscto	D2DsctoInd	D2SubTotDscto	D2SubTotal
    '    ' 000000000001	001	SIST	SISTEMAS	1	33.33	33.33	3.33	3.33	30.00
    '    'servicioActual.Pasajeros = dtDetalle.Compute("SUM(Pasajeros)", String.Empty)
    '    'For Each fila As DataRow In dtDetalle.Rows
    '    '    fila.Item(5) = servicioActual.TarifaIndividual
    '    '    fila.Item(6) = fila.Item(9) * servicioActual.TarifaIndividual
    '    '    fila.Item(7) = servicioActual.DsctoIndividual
    '    '    fila.Item(8) = fila.Item(9) * servicioActual.DsctoIndividual
    '    '    fila.Item(9) = fila.Item(6) - fila.Item(8)
    '    'Next

    'End Sub

    'Private Sub txtPasajeros_Enter(sender As Object, e As EventArgs) Handles txtPasajeros.Enter
    '    'txtPasajeros.SelectionStart = 0
    '    'txtPasajeros.SelectionLength = txtPasajeros.Text.Length
    '    txtPasajeros.SelectAll()
    'End Sub

    'Private Sub txtPasajeros_MouseClick(sender As Object, e As MouseEventArgs)
    '    txtPasajeros.SelectAll()
    'End Sub

    Private Sub txtTarifa_MouseClick(sender As Object, e As MouseEventArgs) Handles txtTarifa.MouseClick
        txtTarifa.SelectAll()
    End Sub

    Private Sub txtDscto_MouseClick(sender As Object, e As MouseEventArgs) Handles txtDscto.MouseClick
        txtDscto.SelectAll()
    End Sub


    Private Sub txtObs_MouseClick(sender As Object, e As MouseEventArgs) Handles txtObs.MouseClick
        txtObs.SelectAll()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'servicioActual = aux
        actualizaCabecera()
        obtenerDetalle()
        cargarDetalle()
        bloquearControles()
    End Sub

    Private Function calcularNuevoItem(tabla As DataTable) As String
        Dim max As String = IIf(TypeOf (tabla.Compute("MAX (T_Item)", String.Empty)) Is DBNull, "0", tabla.Compute("MAX (T_Item)", String.Empty))
        Dim i_max As Integer = CType(max, Integer) + 1
        max = String.Concat("00", i_max.ToString)
        Return max.Substring(max.Length - 3, 3)
    End Function

    'Private Sub actualizaCabecera()
    '    Throw New NotImplementedException
    'End Sub

    'Private Sub actualizarPasajeros()
    '    servicioActual.Pasajeros = dtDetalle.Compute("SUM(Pasajeros)", String.Empty)
    'End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        'MessageBox.Show(dgvResultadoPersonas.CurrentRow.Cells("T_Item").Value.ToString)
        If radDetalleConsumidor.Checked AndAlso dgvResultadoConsumidor.SelectedRows.Count = 1 Then
            'dtDetalleConsumidor.Rows.RemoveAt(obtenerIndex(dtDetalleConsumidor, "Item", dgvResultadoConsumidor.CurrentRow.Cells("Item").Value.ToString))
            dtDetalleConsumidor.Rows.RemoveAt(dgvResultadoConsumidor.CurrentRow.Index)
            servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
            actualizaCabecera()
            cboConsumidor.SelectedIndex = -1
            dgvResultadoConsumidor.ClearSelection()
            txtCantidadPasajeros.Text = ""
            txtDni.Text = ""
            txtNombres.Text = ""
            cboConsumidor.Focus()
        ElseIf radDetallePersona.Checked AndAlso dgvResultadoPersonas.SelectedRows.Count = 1 Then
            dtDetallePersona.Rows.RemoveAt(obtenerIndex(dtDetallePersona, "T_Item", dgvResultadoPersonas.CurrentRow.Cells("T_Item").Value.ToString))
            'dtDetallePersona.Rows.RemoveAt(dgvResultadoPersonas.CurrentRow.Index)
            servicioActual.SumarizarPersonas(dtDetallePersona, dtDetalleConsumidor)
            servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
            actualizaCabecera()
            cboConsumidor.SelectedIndex = -1
            dgvResultadoPersonas.ClearSelection()
            txtCantidadPasajeros.Text = ""
            txtDni.Text = ""
            txtNombres.Text = ""
            txtDni.Focus()
        Else
            MessageBox.Show("Debe seleccionar una fila para poder eliminarla.")
        End If
    End Sub

    Private Sub btnActualizarFila_Click(sender As Object, e As EventArgs) Handles btnActualizarFila.Click
        If radDetalleConsumidor.Checked AndAlso dgvResultadoConsumidor.SelectedRows.Count = 1 Then
            With dtDetalleConsumidor.Rows(dgvResultadoConsumidor.CurrentRow.Index)
                .Item(2) = cboConsumidor.SelectedValue
                .Item(3) = cboConsumidor.DataSource.Compute("MAX (Valor)", "Clave='" & cboConsumidor.SelectedValue & "'") 'cboConsumidor.SelectedItem
                .Item(4) = IIf(IsNumeric(txtCantidadPasajeros.Text), Integer.Parse(txtCantidadPasajeros.Text), 0)
            End With
            servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
            formatearDataGridView(dgvResultadoConsumidor)
            actualizaCabecera()
            cboConsumidor.SelectedIndex = -1
            txtCantidadPasajeros.Text = ""
            dgvResultadoConsumidor.ClearSelection()
            cboConsumidor.Focus()
        ElseIf radDetallePersona.Checked AndAlso dgvResultadoPersonas.SelectedRows.Count = 1 Then
            With dtDetallePersona.Rows(dgvResultadoPersonas.CurrentRow.Index)
                .Item("T_IdConsumidor") = cboConsumidor.SelectedValue
                .Item("T_Consumidor") = cboConsumidor.DataSource.Compute("MAX (Valor)", "Clave='" & cboConsumidor.SelectedValue & "'") 'cboConsumidor.SelectedItem
                '.Item(4) = IIf(IsNumeric(txtCantidadPasajeros.Text), Integer.Parse(txtCantidadPasajeros.Text), 0)
            End With
            servicioActual.SumarizarPersonas(dtDetallePersona, dtDetalleConsumidor)
            servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
            formatearDataGridView(dgvResultadoPersonas)
            actualizaCabecera()
            cboConsumidor.SelectedIndex = -1
            txtCantidadPasajeros.Text = ""
            dgvResultadoConsumidor.ClearSelection()
            dgvResultadoPersonas.ClearSelection()
            txtDni.Focus()
        Else
            MessageBox.Show("Debe seleccionar una fila para poder eliminarla.")
        End If
    End Sub


    'Private Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick
    '    If e.RowIndex >= 0 Then
    '        lblItem.Text = dtDetalle.Rows(e.RowIndex).Item(1)
    '        cboConsumidor.SelectedValue = dtDetalle.Rows(e.RowIndex).Item(2)
    '        txtCantidadPasajeros.Text = dtDetalle.Rows(e.RowIndex).Item(4)
    '    End If

    'End Sub

    Private Sub txtCantidadPasajeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadPasajeros.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvResultado_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvResultadoConsumidor.CellMouseClick
        If e.RowIndex >= 0 Then
            lblItem.Text = dtDetalleConsumidor.Rows(e.RowIndex).Item(1)
            cboConsumidor.SelectedValue = dtDetalleConsumidor.Rows(e.RowIndex).Item(2)
            txtCantidadPasajeros.Text = dtDetalleConsumidor.Rows(e.RowIndex).Item(4)
        End If
    End Sub

    'Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
    '    If e.RowIndex >= 0 Then
    '        lblItem.Text = dtDetalle.Rows(e.RowIndex).Item(1)
    '        cboConsumidor.SelectedValue = dtDetalle.Rows(e.RowIndex).Item(2)
    '        txtCantidadPasajeros.Text = dtDetalle.Rows(e.RowIndex).Item(4)
    '    End If
    'End Sub

    Private Sub radDetalleConsumidor_CheckedChanged(sender As Object, e As EventArgs) Handles radDetalleConsumidor.CheckedChanged
        If radDetalleConsumidor.Checked Then
            txtCantidadPasajeros.Enabled = True
            txtDni.Enabled = False
            txtNombres.Enabled = False
        Else
            txtCantidadPasajeros.Enabled = True
            txtDni.Enabled = True
            txtNombres.Enabled = True
        End If
    End Sub

    Private Sub txtDni_Leave(sender As Object, e As EventArgs) Handles txtDni.Leave
        Dim s As String = buscarRegistro(txtDni.Text, dsMetadatos.Tables(5), 0, 1)
        txtNombres.Text = IIf(s.Length > 0, s, txtNombres.Text)
    End Sub

    Private Sub txtNombres_Leave(sender As Object, e As EventArgs) Handles txtNombres.Leave
        Dim s As String = buscarRegistro(txtNombres.Text, dsMetadatos.Tables(5), 1, 0)
        txtDni.Text = IIf(s.Length > 0, s, txtDni.Text)
    End Sub

    'Public Function buscarRegistro(texto As String, tabla As DataTable, columnaClave As Integer, columnaValor As Integer)
    '    For Each f As DataRow In tabla.Rows
    '        If f.Item(columnaClave).ToString = texto Then
    '            Return f.Item(columnaValor).ToString()
    '        End If
    '    Next
    '    Return ""
    'End Function

    Private Sub txtDni_MouseClick(sender As Object, e As EventArgs) Handles txtDni.MouseClick
        txtDni.SelectAll()
    End Sub

    Private Sub txtNombres_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNombres.MouseClick
        txtNombres.SelectAll()
    End Sub

    Private Sub txtDni_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDni.KeyDown
        If e.KeyCode = Keys.Enter And Not cbxLeerFotochecks.Checked Then
            txtNombres.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            agregarPersona(txtDni.Text, txtNombres.Text, "CFUNDO")
            servicioActual.SumarizarPersonas(dtDetallePersona, dtDetalleConsumidor)
            servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
            formatearDataGridView(dgvResultadoPersonas)
            formatearDataGridView(dgvResultadoConsumidor)
            actualizaCabecera()
            txtDni.Text = ""
            'txtNombres.Text = ""
            'cboConsumidor.SelectedIndex = -1
            'txtCantidadPasajeros.Text = ""
            'dgvResultadoConsumidor.ClearSelection()
            'dgvResultadoPersonas.ClearSelection()
        End If
    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboConsumidor.Focus()
        End If
    End Sub

    Private Sub agregarPersona(dni As String, nombres As String, consumidor As Object)
        'PERSONAS
        'T_Id	T_Item	T_Planilla	T_Dni	T_Codigo	T_Nombre	T_IdArea	T_Area	T_IdCargo	T_Cargo	T_IdConsumidor	T_Consumidor
        '000000000001	001	EMP	02896753	02896753	MANUEL SEGUNDO MONTERO LIZANO	0035      	SISTEMAS	035	JEFE DE SISTEMAS	SIST	SISTEMAS

        'PENDIENTE: ACTUALIZAR DATOS ADICIONALES AL FINALIZAR LA CARGA
        Dim fila As DataRow = dtDetallePersona.NewRow
        fila.Item("T_Id") = servicioActual.Id
        fila.Item("T_Item") = calcularNuevoItem(dtDetallePersona)
        fila.Item("T_Dni") = dni
        fila.Item("T_Nombre") = nombres
        fila.Item("T_IdConsumidor") = consumidor
        dtDetallePersona.Rows.Add(fila)
    End Sub

    Private Sub agregarConsumidor(idConsumidor As String, nombreConsumidor As String, pasajeros As Integer)
        Dim fila As DataRow = dtDetalleConsumidor.NewRow
        fila.Item(0) = servicioActual.Id
        fila.Item(1) = calcularNuevoItem(dtDetalleConsumidor)
        fila.Item(2) = idConsumidor
        fila.Item(3) = nombreConsumidor
        fila.Item(4) = pasajeros
        fila.Item(5) = 0.0
        fila.Item(6) = 0.0
        fila.Item(7) = 0.0
        fila.Item(8) = 0.0
        fila.Item(9) = 0.0
        dtDetalleConsumidor.Rows.Add(fila)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            Dim r As DialogResult
            r = MessageBox.Show("La importacion de datos puede agregar registros al final de los ya existentes o puede reemplazarlos completamente." & vbNewLine & "Desea agregar registros al final?" & vbNewLine & "Si selecciona 'NO' se ELIMINARAN los registros ya agregados.", "Agregar o Reemplazar?", MessageBoxButtons.YesNo)
            If r = Windows.Forms.DialogResult.No Then
                dtDetallePersona.Rows.Clear()
            End If
            dtTablaExcel = Nothing
            'dgvResultado.DataSource = Nothing
            dtTablaExcel = cargarExcel(txtRuta.Text)
            If radDetallePersona.Checked Then
                For Each f As DataRow In dtTablaExcel.Rows
                    agregarPersona(f.Item(0).ToString, f.Item(1).ToString, f.Item(2).ToString)
                    servicioActual.SumarizarPersonas(dtDetallePersona, dtDetalleConsumidor)
                Next
                servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
                formatearDataGridView(dgvResultadoPersonas)
                formatearDataGridView(dgvResultadoConsumidor)
                actualizaCabecera()
            ElseIf radDetalleConsumidor.Checked Then
                For Each f As DataRow In dtTablaExcel.Rows
                    agregarConsumidor(f.Item(0).ToString, f.Item(1).ToString, f.Item(2).ToString)
                    'agregarPersona(f.Item(0).ToString, f.Item(1).ToString, f.Item(2).ToString)
                    'servicioActual.SumarizarPersonas(dtDetallePersona, dtDetalleConsumidor)
                Next
                servicioActual.SumarizarConsumidores(dtDetalleConsumidor)
                'formatearDataGridView(dgvResultadoPersonas)
                formatearDataGridView(dgvResultadoConsumidor)
                actualizaCabecera()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRuta.Text = dialog.FileName
        End Using
    End Sub

    'PENDIENTE CORREGIR ESTE LEAVE
    Private Sub cboRazonSocial_Leave(sender As Object, e As EventArgs) Handles cboRazonSocial.Leave
        Try
            If Len(cboRazonSocial.Text) > 0 Then
                cboRazonSocial.SelectedValue = buscarRegistro(UCase(cboRazonSocial.Text), dsMetadatos.Tables(1), 1, 0)
                servicioActual.RucProveedor = cboRazonSocial.SelectedValue
                cboRuc.SelectedValue = servicioActual.RucProveedor
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'Try
        '    If dgvResultadoPersonas.RowCount < 1 And dgvResultadoConsumidor.RowCount < 1 Then
        '        MessageBox.Show("Error, no hay registros para exportar")
        '    Else
        '        Dim dDgvs As New Dictionary(Of String, DataGridView)
        '        dDgvs.Add("Consumidores", dgvResultadoConsumidor)
        '        dDgvs.Add("Personas", dgvResultadoPersonas)
        '        'exportarVariosExcels(dDgvs, Me.Text, servicioActual.Id)
        '        excelling(dDgvs, Me.Text, servicioActual.Id)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Try
            Dim dsresultado As DataSet = New DataSet
            dsresultado.Tables.Add(dtDetalleConsumidor.Copy)
            dsresultado.Tables.Add(dtDetallePersona.Copy)
            If dgvResultadoConsumidor.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As List(Of String) = New List(Of String)
                l.Add("DetalleConsumidor")
                l.Add("DetallePersona")
                Await Task.Run(Sub() aExcel(dsresultado, l, Me.Text, Nothing))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboConductor_Leave(sender As Object, e As EventArgs) Handles cboConductor.Leave
        Try
            cboConductor.SelectedValue = buscarRegistro(UCase(cboConductor.Text), dsMetadatos.Tables(2), 1, 0)
            servicioActual.DniConductor = cboConductor.SelectedValue
            cboDniConductor.SelectedValue = servicioActual.DniConductor
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboRuc_Leave(sender As Object, e As EventArgs) Handles cboRuc.Leave
        Try
            If Len(cboRuc.Text) > 0 Then
                cboRuc.SelectedValue = buscarRegistro(cboRuc.Text, dsMetadatos.Tables(1), 0, 0)
                cboRazonSocial.SelectedValue = buscarRegistro(cboRuc.Text, dsMetadatos.Tables(1), 0, 0)
                servicioActual.RucProveedor = cboRuc.SelectedValue
                servicioActual.RazonSocial = buscarRegistro(cboRuc.Text, dsMetadatos.Tables(1), 0, 0)
                'cboRuc.SelectedValue = servicioActual.RucProveedor
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboConsumidor_KeyDown(sender As Object, e As KeyEventArgs) Handles cboConsumidor.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnMas.Focus()
        End If
    End Sub

    Private Sub dgvResultadoPersonas_Click(sender As Object, e As EventArgs) Handles dgvResultadoPersonas.Click
        Try
            txtDni.Text = dgvResultadoPersonas.Rows(dgvResultadoPersonas.CurrentRow.Index).Cells("T_Dni").Value
            txtNombres.Text = dgvResultadoPersonas.Rows(dgvResultadoPersonas.CurrentRow.Index).Cells("T_Nombre").Value
            cboConsumidor.SelectedValue = dgvResultadoPersonas.Rows(dgvResultadoPersonas.CurrentRow.Index).Cells("T_IdConsumidor").Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbxLeerFotochecks_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLeerFotochecks.CheckedChanged
        Try
            If cbxLeerFotochecks.Checked Then
                txtNombres.Text = "NOMBRE POR VALIDAR"
                cboConsumidor.SelectedIndex = -1
                txtNombres.Enabled = False
                cboConsumidor.Enabled = False
                'txtCantidadPasajeros.Enabled = False
                btnMas.Enabled = False
                btnActualizarFila.Enabled = False
                btnMenos.Enabled = False
            Else
                txtNombres.Enabled = True
                cboConsumidor.Enabled = True
                'txtCantidadPasajeros.Enabled = True
                btnMas.Enabled = True
                btnActualizarFila.Enabled = True
                btnMenos.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Function obtenerIndice(item As String) As Integer
    '    dtDetallePersona()
    'End Function

    Private Function obtenerIndex(dtSource As DataTable, nombreCelda As String, valorBuscado As String) As Integer
        Dim i As Integer = dtSource.Rows.IndexOf(dtSource.Select(nombreCelda & " = " & valorBuscado)(0))
        Return i
    End Function

    Private Sub btnDistribuirCostos_Click(sender As Object, e As EventArgs) Handles btnDistribuirCostos.Click

        If dgvResultadoPersonas.RowCount < 1 Then
            MessageBox.Show("Error, no hay registros para Distribuir Costos")
        Else
            Dim rpta As DialogResult
            Dim s As String = "Desea convertir la Distribución de Costos del dia " & dtpFecha.Value.ToString("yyyy-MM-dd")
            rpta = MessageBox.Show(s, "Distribuir Costos", MessageBoxButtons.YesNo)
            If rpta = DialogResult.Yes Then
                Dim p As New Dictionary(Of String, Object)
                Dim r As DataTable
                Try
                    ' p.Add("@Idserviciotransporte", fila.Cells(1).Value)
                    p.Add("@Idserviciotransporte", lblId.Text)
                    r = doItBaby("sp_Dg_Logistica_Movimientos_ServiciosTransporte_DistribuirCosto", p, TipoQuery.DataTable)
                    If r.Rows(0).Item(0).ToString.Equals("1") Then
                        obtenerMetadatos()
                        usarMetadatos()
                        actualizaCabecera()
                        obtenerDetalle()
                        cargarDetalle()
                        'MessageBox.Show(r.Rows(0).Item(1).ToString)
                        MessageBox.Show("Registros actualizados correctamente.")
                    Else
                        'MessageBox.Show(r.Rows(0).Item(1).ToString)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub dgvResultadoPersonas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultadoPersonas.CellContentClick

    End Sub
End Class