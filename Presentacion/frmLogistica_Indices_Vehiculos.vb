Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmLogistica_Indices_Vehiculos
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dsDataParaCombo As DataSet
    Dim dtProveedores As DataTable
    Dim esNuevo As Boolean = True
    Dim observaciones As String = String.Empty

    Dim bsVehiculos As New BindingSource()

    Public Structure Vehiculo
        Public placa As String
        Public IdProveedor As String
        Public Proveedor As String
        Public IdMarca As String
        Public IdModelo As String
        Public IdColor As String
        Public Capacidad As Integer
        Public VtoSoat As Date
        Public VtoRevTecnica As Date
        Public AnioModelo As String
        Public AnioFabrica As Long
        Public IdEstado As String
        Public UsuarioCrea As String
    End Structure

    Private Sub frmLogistica_Indices_Vehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
        obtenerDataGeneral()
        cargarDataGridViewResultado()
        cargarCombo(cboMarca, dsDataParaCombo.Tables(0), "", True)
        cargarCombo(cboColor, dsDataParaCombo.Tables(2), "", False)
        cargarTextBoxProveedor()
        deseleccionarCombos()
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        bloquearControl(txtPlaca)
        ajustarBotones()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerDataGeneral()
        Dim aux As New DataSet
        aux = doItBaby("sp_Dg_Logistica_Indices_Vehiculos_Load", Nothing, TipoQuery.DataSet)
        'dtResultado = New DataTable
        'dtResultado = aux.Tables(0).Copy
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(aux.Tables(1).Copy)
        dsDataParaCombo.Tables.Add(aux.Tables(2).Copy)
        dsDataParaCombo.Tables.Add(aux.Tables(3).Copy)
        dtProveedores = New DataTable
        dtProveedores = aux.Tables(4).Copy
    End Sub

    Private Sub cboMarca_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboMarca.SelectionChangeCommitted
        cargarCombo(cboModelo, dsDataParaCombo.Tables(1), cboMarca.SelectedValue, True)
    End Sub

    Private Sub deseleccionarCombos()
        cboMarca.SelectedIndex = -1
        cboColor.SelectedIndex = -1
        cboModelo.DataSource = Nothing

    End Sub

    Private Sub cargarTextBoxProveedor()
        Dim acsRucsProveedores As New AutoCompleteStringCollection
        For Each fila As DataRow In dtProveedores.Rows
            acsRucsProveedores.Add(fila.Item(3).ToString)
        Next
        txtRuc.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtRuc.AutoCompleteCustomSource = acsRucsProveedores
        txtRuc.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        Dim acsProveedores As New AutoCompleteStringCollection
        For Each fila As DataRow In dtProveedores.Rows
            acsProveedores.Add(fila.Item(2).ToString)
        Next
        txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtProveedor.AutoCompleteCustomSource = acsProveedores
        txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub txtRuc_Leave(sender As Object, e As EventArgs) Handles txtRuc.Leave
        Try
            txtProveedor.Text = dividirCadena(txtRuc.Text, " | ", True)
            txtRuc.Text = dividirCadena(txtRuc.Text, " | ", False)
        Catch
        End Try
    End Sub

    Private Sub txtProveedor_Leave(sender As Object, e As EventArgs) Handles txtProveedor.Leave
        Try
            txtRuc.Text = dividirCadena(txtProveedor.Text, " | ", True)
            txtProveedor.Text = dividirCadena(txtProveedor.Text, " | ", False)
        Catch
        End Try
    End Sub

    Public Function dividirCadena(cadena As String, pivote As String, orientacion As Boolean) '0=IZQUIERDA, 1=DERECHA
        Dim r() As String = Split(cadena, pivote)
        If orientacion Then
            Return r(1)
        Else
            Return r(0)
        End If
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            observaciones = validarDatos()
            If observaciones <> "Ok" Then
                MessageBox.Show(observaciones)
                Exit Sub
            Else
                Dim cadena As String = String.Empty
                cadena = txtPlaca.Text & "!" & txtRuc.Text & "!" & cboMarca.SelectedValue & "!" & cboModelo.SelectedValue & "!" & cboColor.SelectedValue & "!" & txtCapacidad.Text & "!" & dtpVtoSoat.Value.ToString("yyyy-MM-dd") & "!" & dtpVtoRevTecnica.Value.ToString("yyyy-MM-dd") & "!" & txtAnioModelo.Text & "!" & txtAnioFabrica.Text & "!" & cbxActivo.Checked.ToString & "!" & usuarioActual
                'MessageBox.Show(cadena)

                Dim p As New Dictionary(Of String, Object)
                p.Add("@CadenaParametros", cadena)
                p.Add("@EsNuevo", esNuevo.ToString)
                If doItBaby("sp_Dg_Logistica_Indices_Vehiculos_GuardarVehiculo", p, TipoQuery.Scalar).ToString.Length > 0 Then
                    cargarDataGridViewResultado()
                    MessageBox.Show("Registro guardado correctamente.")
                End If
                bloquearControl(txtPlaca)
                bloquearControl(btnCancelar)
                bloquearControl(btnGuardar)
                'desbloquearControl(btnGuardar)
                desbloquearControl(btnEditar)
                desbloquearControl(btnNuevo)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        desbloquearFilas(dgvResultado)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        esNuevo = True
        limpiarControles()
        desbloquearControl(txtPlaca)
        desbloquearControl(btnGuardar)
        desbloquearControl(btnCancelar)
        bloquearControl(btnEditar)
        bloquearControl(btnNuevo)
        txtPlaca.Focus()
    End Sub

    Private Sub limpiarControles()
        txtPlaca.Text = ""
        txtRuc.Text = ""
        txtCapacidad.Text = ""
        cboMarca.SelectedIndex = -1
        cboModelo.DataSource = Nothing
        cbxActivo.Checked = True
        txtProveedor.Text = ""
        txtAnioModelo.Text = ""
        txtAnioFabrica.Text = ""
        dtpVtoSoat.Value = Now
        cboColor.SelectedIndex = -1
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        esNuevo = False
        desbloquearControl(txtPlaca)
        desbloquearControl(btnGuardar)
        desbloquearControl(btnCancelar)
        bloquearControl(btnNuevo)
        bloquearControl(btnEditar)
        bloquearFilas(dgvResultado)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        limpiarControles()
        dgvResultado.ClearSelection()
        bloquearControl(txtPlaca)
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        desbloquearControl(btnNuevo)
        desbloquearControl(btnEditar)
        desbloquearFilas(dgvResultado)
    End Sub

    Private Function validarDatos() As String
        If txtPlaca.Text.Length < 3 Or txtPlaca.Text.Contains(" ") Then
            Return "Debe ingresar una placa valido."
        ElseIf txtRuc.Text.Length <> 11 Or txtRuc.Text.ToUpper <> txtRuc.Text.ToLower Then
            Return "Debe ingresar un Ruc valido."
        ElseIf txtCapacidad.Text.ToUpper <> txtCapacidad.Text.ToLower Or txtCapacidad.Text.Length < 1 Then
            Return "Debe ingresar una capacidad de vehiculo valida."
        ElseIf CType(dtpVtoSoat.Value, Date) = CType(Now, Date) Then
            Return "Debe ingresar una fecha correcta, el SOAT vence hoy"
        ElseIf CType(dtpVtoRevTecnica.Value, Date) = CType(Now, Date) Then
            Return "Debe ingresar una fecha correcta, la Revision Tecnica vence hoy"
        ElseIf txtAnioModelo.Text.ToUpper <> txtAnioModelo.Text.ToLower Or Not IsDate("01/01/" & txtAnioModelo.Text) Or txtAnioModelo.Text.Length <> 4 Then
            Return "Debe ingresar un año de modelo valido."
        ElseIf txtAnioFabrica.Text.ToUpper <> txtAnioFabrica.Text.ToLower Or Not IsDate("01/01/" & txtAnioFabrica.Text) Or txtAnioFabrica.Text.Length <> 4 Then
            Return "Debe ingresar un año de fabrica valido."
        End If
        Return "Ok"
    End Function


    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '    MessageBox.Show("Error, no hay registros para exportar")
        'Else
        '    'exportarExcel(dgvResultado, Me.Text, "")
        '    Dim dDgvs As New Dictionary(Of String, DataGridView)
        '    dDgvs.Add("Reporte", dgvResultado)
        '    excelling(dDgvs, Me.Text, "")
        'End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, Nothing))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarDataGridViewResultado()
        txtFiltro.Text = ""
        tablaResultado = New DataTable
        tablaResultado = doItBaby("sp_Dg_Logistica_Indices_Vehiculos_ObtenerVehiculos", Nothing, TipoQuery.DataTable)
        Dim dvVehiculos As New DataView(tablaResultado)
        bsVehiculos.DataSource = dvVehiculos
        dgvResultado.DataSource = bsVehiculos
        formatearDataGridView(dgvResultado)
        lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString

        dgvResultado.Columns("IdMarca").Visible = False
        dgvResultado.Columns("IdModelo").Visible = False
        dgvResultado.Columns("IdColor").Visible = False
        dgvResultado.Columns("IdEstado").Visible = False
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsVehiculos.Filter = String.Format("T_Placa like '%{0}%' Or " +
                                                "T_IdProveedor like '%{1}%' Or " +
                                                "T_Proveedor like '%{2}%' Or " +
                                                "T_Marca like '%{3}%' Or " +
                                                "T_Modelo like '%{4}%' Or " +
                                                "T_Color like '%{5}%' Or " +
                                                "UsuarioCrea like '%{6}%'",
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text,
                                                txtFiltro.Text)
        lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 Then
            Dim vehiculoActual As New Vehiculo
            capturarDatos(vehiculoActual, dgvResultado.CurrentRow)
            volcarDatos(vehiculoActual)
        End If
    End Sub

    Private Sub capturarDatos(ByRef vehiculoActual As Vehiculo, fila As DataGridViewRow)
        vehiculoActual.placa = fila.Cells(0).Value.ToString
        vehiculoActual.IdProveedor = fila.Cells(1).Value.ToString
        vehiculoActual.Proveedor = fila.Cells(2).Value.ToString
        vehiculoActual.IdMarca = fila.Cells(3).Value.ToString
        vehiculoActual.IdModelo = fila.Cells(5).Value.ToString
        vehiculoActual.IdColor = fila.Cells(7).Value.ToString
        vehiculoActual.Capacidad = fila.Cells(9).Value.ToString
        vehiculoActual.VtoSoat = fila.Cells(10).Value.ToString
        vehiculoActual.VtoRevTecnica = fila.Cells(11).Value.ToString
        vehiculoActual.AnioModelo = fila.Cells(12).Value.ToString
        vehiculoActual.AnioFabrica = fila.Cells(13).Value.ToString
        vehiculoActual.IdEstado = fila.Cells(14).Value.ToString
    End Sub

    Private Sub volcarDatos(vehiculoActual As Vehiculo)
        txtPlaca.Text = vehiculoActual.placa
        txtRuc.Text = vehiculoActual.IdProveedor
        txtProveedor.Text = vehiculoActual.Proveedor
        cboMarca.SelectedValue = vehiculoActual.IdMarca
        cargarCombo(cboModelo, dsDataParaCombo.Tables(1), cboMarca.SelectedValue, True)
        cboModelo.SelectedValue = vehiculoActual.IdModelo
        cboColor.SelectedValue = vehiculoActual.IdColor
        txtCapacidad.Text = vehiculoActual.Capacidad
        dtpVtoSoat.Value = vehiculoActual.VtoSoat
        dtpVtoRevTecnica.Value = vehiculoActual.VtoRevTecnica
        txtAnioModelo.Text = vehiculoActual.AnioModelo
        txtAnioFabrica.Text = vehiculoActual.AnioFabrica
        cbxActivo.Checked = IIf(vehiculoActual.IdEstado = "AC", True, False)
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

    Private Sub tlpPrincipal_Paint(sender As Object, e As PaintEventArgs) Handles tlpPrincipal.Paint

    End Sub

    Private Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick

    End Sub
End Class