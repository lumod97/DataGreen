Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmLogistica_Indices_Conductores
    Dim dtResultado As DataTable
    Dim dsDataParaCombo As DataSet
    'Dim dtProveedores As DataTable
    Dim esNuevo As Boolean = True
    Dim observaciones As String = String.Empty
    Dim bsConductores As New BindingSource()
    Dim cadena As String = String.Empty
    Dim conductorActual As New Conductor

    Public Structure Conductor
        Public dni As String
        Public nombres As String
        Public aPaterno As String
        Public aMaterno As String
        Public fNacimiento As Date
        Public direccion As String
        Public telefono As String
        Public celular As String
        Public email As String
        Public nroBrevete As String
        Public clase As String
        Public categoria As String
        Public fExpedicion As Date
        Public fRevalidacion As Date
        Public idEstado As String
        'Public UsuarioCrea As String
    End Structure

    Private Sub frmLogistica_Indices_Conductores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
        cargarDataGridViewResultado()

        obtenerDataParaCombos()
        cargarCombo(cboClase, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboCategoria, dsDataParaCombo.Tables(1), "", False)
        deseleccionarCombos()

        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        bloquearControl(txtDni)
        ajustarBotones()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub cargarDataGridViewResultado()
        txtFiltro.Text = ""
        dtResultado = New DataTable
        dtResultado = doItBaby("sp_Dg_Logistica_Indices_Conductores_ObtenerConductores", Nothing, TipoQuery.DataTable)
        Dim dvConductores As New DataView(dtResultado)
        bsConductores.DataSource = dvConductores
        dgvResultado.DataSource = bsConductores
        formatearDataGridView(dgvResultado)
        lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub obtenerDataParaCombos()
        Dim aux As New DataSet
        aux = doItBaby("sp_Dg_Logistica_Indices_Conductores_Load", Nothing, TipoQuery.DataSet)
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(aux.Tables(0).Copy)
        dsDataParaCombo.Tables.Add(aux.Tables(1).Copy)
    End Sub

    Private Sub deseleccionarCombos()
        cboClase.SelectedIndex = -1
        cboCategoria.SelectedIndex = -1
        'cboModelo.DataSource = Nothing
    End Sub

    Private Sub ajustarBotones()
        Dim alto As Integer = 28
        btnNuevo.Height = alto
        btnNuevo.FlatAppearance.BorderSize = 0
        btnEditar.Height = alto
        btnEditar.FlatAppearance.BorderSize = 0
        btnGuardar.Height = alto
        btnGuardar.FlatAppearance.BorderSize = 0
        btnCancelar.Height = alto
        btnCancelar.FlatAppearance.BorderSize = 0
        btnExportar.Height = alto
        btnExportar.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub txtDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDni.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombres.KeyPress
        If e.KeyChar = "!" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAPaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAPaterno.KeyPress
        If e.KeyChar = "!" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAMaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAMaterno.KeyPress
        If e.KeyChar = "!" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = "!" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = "-" AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCelular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCelular.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = "#" AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = "!" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroBrevete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroBrevete.KeyPress
        If e.KeyChar = "!" Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        esNuevo = True
        limpiarControles()
        desbloquearControl(txtDni)
        desbloquearControl(btnGuardar)
        desbloquearControl(btnCancelar)
        bloquearControl(btnEditar)
        bloquearControl(btnNuevo)
        txtDni.Focus()
    End Sub

    Private Sub limpiarControles()
        txtDni.Text = ""
        txtNombres.Text = ""
        txtAPaterno.Text = ""
        txtAMaterno.Text = ""
        dtpNacimiento.Value = Now
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        txtCelular.Text = ""
        txtEmail.Text = ""
        txtNroBrevete.Text = ""
        cboClase.SelectedIndex = -1
        cboCategoria.SelectedIndex = -1
        dtpExpedicion.Value = Now
        dtpRevalidacion.Value = Now
        cbxActivo.Checked = True
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        esNuevo = False
        desbloquearControl(txtDni)
        desbloquearControl(btnGuardar)
        desbloquearControl(btnCancelar)
        bloquearControl(btnNuevo)
        bloquearControl(btnEditar)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            observaciones = validarDatos()
            If observaciones <> "Ok" Then
                MessageBox.Show(observaciones)
                Exit Sub
            Else
                cadena = String.Empty
                encadenar(txtDni.Text)
                encadenar(txtNombres.Text)
                encadenar(txtAPaterno.Text)
                encadenar(txtAMaterno.Text)
                encadenar(dtpNacimiento.Value.ToString("yyyy-MM-dd"))
                encadenar(txtDireccion.Text)
                encadenar(txtTelefono.Text)
                encadenar(txtCelular.Text)
                encadenar(txtEmail.Text)
                encadenar(txtNroBrevete.Text)
                encadenar(cboClase.SelectedValue)
                encadenar(cboCategoria.SelectedValue)
                encadenar(dtpExpedicion.Value.ToString("yyyy-MM-dd"))
                encadenar(dtpRevalidacion.Value.ToString("yyyy-MM-dd"))
                encadenar(cbxActivo.Checked.ToString)
                encadenar(usuarioActual)

                'cadena = txtDni.Text & "!" & txtNombres.Text & "!" & txtNombres.Text & "!" & cboMarca.SelectedValue & "!" & cboModelo.SelectedValue & "!" & cboColor.SelectedValue & "!" & txtCapacidad.Text & "!" & dtpVtoSoat.Value.ToString("yyyy-MM-dd") & "!" & dtpVtoRevTecnica.Value.ToString("yyyy-MM-dd") & "!" & txtAnioModelo.Text & "!" & txtAnioFabrica.Text & "!" & cbxActivo.Checked.ToString & "!" & usuarioActual

                'MessageBox.Show(cadena)

                Dim p As New Dictionary(Of String, Object)
                p.Add("@CadenaParametros", cadena)
                p.Add("@EsNuevo", esNuevo.ToString)
                If doItBaby("sp_Dg_Logistica_Indices_Conductor_GuardarConductor", p, TipoQuery.Scalar).ToString.Length > 0 Then
                    cargarDataGridViewResultado()
                    MessageBox.Show("Registro guardado correctamente.")
                End If
                bloquearControl(txtDni)
                bloquearControl(btnCancelar)
                bloquearControl(btnGuardar)
                'desbloquearControl(btnGuardar)
                desbloquearControl(btnEditar)
                desbloquearControl(btnNuevo)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function validarDatos() As String
        If txtDni.Text.Length <> 8 Or txtDni.Text.Contains(" ") Then
            Return "Debe ingresar un dni valido."
        ElseIf txtNombres.Text.Length < 2 Or txtAPaterno.Text.Length < 2 Or txtAMaterno.Text.Length < 2 Then
            Return "Debe ingresar un nombre valido."
        ElseIf CType(dtpNacimiento.Value, Date) = CType(Now, Date) Then
            Return "Debe ingresar una fecha de nacimiento correcta."
        ElseIf txtDireccion.Text.Length < 2 Then
            Return "Debe ingresar una direccion valida."
        ElseIf txtTelefono.Text.Length < 8 And txtCelular.Text.Length <> 9 Then
            Return "Debe ingresar numeros de telefonos validos. Al menos 1 de ellos."
            'ElseIf txtEmail.Text.Length < 6 Or Not (txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".")) Then
            '    Return "Debe ingresar una direccion email valido"
        ElseIf txtNroBrevete.Text.Length < 8 Then
            Return "Debe ingresar un numero de brevete valido."
        ElseIf cboClase.SelectedIndex < 0 Then
            Return "Debe seleccionar una clase de brevete."
        ElseIf cboCategoria.SelectedIndex < 0 Then
            Return "Debe seleccionar una categoria de brevete."
        ElseIf CType(dtpExpedicion.Value, Date) > CType(Now, Date) Then
            Return "La fecha de expedicion no puede ser mayor al dia de hoy."
        ElseIf CType(dtpRevalidacion.Value, Date) <= CType(Now, Date) Then
            Return "No puede registrar un conductor con brevete vencido."
        End If
        Return "Ok"
    End Function

    Public Sub encadenar(parametro As String)
        If cadena.Length = 0 Then
            cadena = parametro
        Else
            cadena = cadena & "!" & parametro
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiarControles()
        dgvResultado.ClearSelection()
        bloquearControl(txtDni)
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        desbloquearControl(btnNuevo)
        desbloquearControl(btnEditar)
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsConductores.Filter = String.Format("T_Dni like '%{0}%' Or " +
                                                "T_Nombres like '%{1}%' Or " +
                                                "T_APaterno like '%{2}%' Or " +
                                                "T_AMaterno like '%{3}%' Or " +
                                                "UsuarioCrea like '%{4}%'",
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text
                                                )
        lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 Then
            'Dim conductorActual As New Conductor
            conductorActual = New Conductor
            capturarDatos(dgvResultado.CurrentRow)
            volcarDatos(conductorActual)
        End If
    End Sub

    Private Sub capturarDatos(fila As DataGridViewRow)
        conductorActual.dni = fila.Cells(0).Value.ToString
        conductorActual.nombres = fila.Cells(1).Value.ToString
        conductorActual.aPaterno = fila.Cells(2).Value.ToString
        conductorActual.aMaterno = fila.Cells(3).Value.ToString
        Dim fn As Date = IIf(fila.Cells(9).Value.ToString.Length > 0, fila.Cells(9).Value.ToString, Now)
        conductorActual.fNacimiento = fn 'fila.Cells(9).Value.ToString
        conductorActual.direccion = fila.Cells(10).Value.ToString
        conductorActual.telefono = fila.Cells(11).Value.ToString
        conductorActual.celular = fila.Cells(12).Value.ToString
        conductorActual.email = fila.Cells(13).Value.ToString
        conductorActual.nroBrevete = fila.Cells(4).Value.ToString
        conductorActual.clase = fila.Cells(5).Value.ToString
        conductorActual.categoria = fila.Cells(6).Value.ToString
        conductorActual.fExpedicion = fila.Cells(7).Value.ToString
        conductorActual.fRevalidacion = fila.Cells(8).Value.ToString
        conductorActual.idEstado = fila.Cells(14).Value.ToString
        'conductorActual.UsuarioCrea = fila.Cells(14).Value.ToString
    End Sub

    Private Sub volcarDatos(conductorActual As Conductor)
        txtDni.Text = conductorActual.dni
        txtNombres.Text = conductorActual.nombres
        txtAPaterno.Text = conductorActual.aPaterno
        txtAMaterno.Text = conductorActual.aMaterno
        dtpNacimiento.Value = conductorActual.fNacimiento
        txtDireccion.Text = conductorActual.direccion
        txtTelefono.Text = conductorActual.telefono
        txtCelular.Text = conductorActual.celular
        txtEmail.Text = conductorActual.email
        txtNroBrevete.Text = conductorActual.nroBrevete
        cboClase.SelectedValue = conductorActual.clase
        cboCategoria.SelectedValue = conductorActual.categoria
        dtpExpedicion.Value = conductorActual.fExpedicion
        dtpRevalidacion.Value = conductorActual.fRevalidacion
        cbxActivo.Checked = IIf(conductorActual.idEstado = "AC", True, False)
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

    End Sub
End Class