Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmLogistica_Indices_Rutas
    Dim dsMetadatos As DataSet
    Dim dtResultado As DataTable
    Dim dtDetalleIda As DataTable
    Dim dtDetalleVuelta As DataTable
    Dim esNuevaRuta As Boolean = True
    'Dim esNuevoParadero As Boolean = True
    Dim observaciones As String = String.Empty
    Dim cadena As String = String.Empty

    Private Sub frmLogistica_Indices_Rutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        cargarDataGridViewResultado()
        obtenerMetaDatos()
        usarMetadatos()
        bloquearControles()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub cargarDataGridViewResultado()
        dtResultado = New DataTable
        dtResultado = doItBaby("sp_Dg_Logistica_Indices_Rutas_ObtenerRutas", Nothing, TipoQuery.DataTable)
        'Dim dvConductores As New DataView(dtResultado)
        dgvResultado.DataSource = dtResultado
        formatearDataGridView(dgvResultado)
        dgvResultado.ClearSelection()
        'lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub obtenerMetaDatos()
        dsMetadatos = doItBaby("sp_Dg_Logistica_Indices_Rutas_Metadatos", Nothing, TipoQuery.DataSet)
    End Sub

    Private Sub usarMetadatos()
        cargarCombo(cboCiudadOrigen, dsMetadatos.Tables(0).Copy, "", True)
        cargarCombo(cboCiudadDestino, dsMetadatos.Tables(0).Copy, "", True)
        cargarCombo(cboCiudadIda, dsMetadatos.Tables(0).Copy, "", True)
        cargarCombo(cboCiudadVuelta, dsMetadatos.Tables(0).Copy, "", True)

        cboCiudadOrigen.SelectedIndex = -1
        cboCiudadDestino.SelectedIndex = -1
        cboCiudadIda.SelectedIndex = -1
        cboCiudadVuelta.SelectedIndex = -1
    End Sub

    Public Sub bloquearControles()
        bloquearControl(btnOk)
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        bloquearControl(tlpCabecera)
        bloquearControl(tlpIda)
        bloquearControl(tlpVuelta)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        esNuevaRuta = True
        limpiarControles()

        desbloquearControl(btnOk)
        desbloquearControl(btnGuardar)
        desbloquearControl(btnCancelar)
        bloquearControl(btnEditar)
        bloquearControl(btnNuevo)
        bloquearControl(btnGuardar)

        desbloquearControl(tlpCabecera)
        'cbxIda.Checked = True
        'cbxVuelta.Checked = True
        'cbxEstado.Checked = True
        txtDescripcion.Focus()
    End Sub

    Private Sub limpiarControles()
        lblIdRuta.Text = "XXX"
        txtDescripcion.Text = ""
        cboCiudadOrigen.SelectedIndex = -1
        cboParaderoOrigen.SelectedIndex = -1
        cboCiudadDestino.SelectedIndex = -1
        cboParaderoDestino.SelectedIndex = -1
        cbxEstado.Checked = True
        cbxIda.Checked = True
        cbxVuelta.Checked = True

        cboCiudadIda.SelectedIndex = -1
        cboParaderoIda.SelectedIndex = -1
        cboCiudadVuelta.SelectedIndex = -1
        cboParaderoVuelta.SelectedIndex = -1

        dgvIda.DataSource = Nothing
        dgvVuelta.DataSource = Nothing

        'txtCiudad.Text = ""
        'txtDepartamento.Text = ""
        'lblNombreCiudad.Text = ""
        'txtParadero.Text = ""
        'cbxActivo_Ciudad.Checked = True
        'cbxActivo_Paradero.Checked = True
        'dgvIda.DataSource = Nothing
        'dgvVuelta.DataSource = Nothing
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvResultado.SelectedRows.Count = 1 Then
            bloquearFilas(dgvResultado)
            esNuevaRuta = False
            bloquearControl(btnNuevo)
            bloquearControl(btnEditar)
            bloquearControl(btnGuardar)
            desbloquearControl(btnCancelar)
            desbloquearControl(btnOk)
            desbloquearControl(tlpCabecera)
        Else
            MessageBox.Show("No ha seleccionado niguna fila.")
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        '0:      Id()
        '1:      NombreRuta()
        '2:      DepPartida()
        '3:      IdCiudad()
        '4:      CiudadPartida()
        '5:      IdParaderoPartida()
        '6:      ParaderoPartida()
        '7:      DepDestino()
        '8:      IdCiudad()
        '9:      CiudadDestino()
        '10:     IdParaderoDestino()
        '11:     ParaderoDestino()
        '12:     Ida()
        '13:     Venida()
        '14:     IdEstado()
        '15:     Estado()
        '16:     UsuarioCrea()
        '17:     FechaHoraCrea()

        If esNuevaRuta Then
            'Dim nFilas As Integer = dtResultado.Rows.Count
            Dim fila As DataRow = dtResultado.NewRow
            fila.Item(0) = generarCorrelativo(CInt(dtResultado.Rows.Count + 1), 3)
            fila.Item(1) = txtDescripcion.Text
            fila.Item(3) = cboCiudadOrigen.SelectedValue
            fila.Item(4) = cboCiudadOrigen.SelectedItem.row.itemarray(1).ToString
            fila.Item(5) = cboParaderoOrigen.SelectedValue
            fila.Item(6) = cboParaderoOrigen.SelectedItem.row.itemarray(1).ToString
            fila.Item(8) = cboCiudadDestino.SelectedValue
            fila.Item(9) = cboCiudadDestino.SelectedItem.row.itemarray(1).ToString
            fila.Item(10) = cboParaderoDestino.SelectedValue
            fila.Item(11) = cboParaderoDestino.SelectedItem.row.itemarray(1).ToString
            fila.Item(12) = IIf(cbxIda.Checked, "Si", "No")
            fila.Item(13) = IIf(cbxVuelta.Checked, "Si", "No")
            fila.Item(14) = IIf(cbxEstado.Checked, "AC", "BA")
            fila.Item(15) = IIf(cbxEstado.Checked, "ACTIVO", "DE BAJA")
            fila.Item(16) = usuarioActual

            dtResultado.Rows.Add(fila)
            dgvResultado.DataSource = dtResultado
            'formatearDataGridView(dgvResultado)
            'bloquearControl(btnOk)

            dgvResultado.ClearSelection()
            dgvResultado.Rows(dgvResultado.Rows.Count - 1).Selected = True
            'bloquearFilas(dgvResultado)

            dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(0, dgvResultado.Rows.Count - 1))
            'desbloquearControl(tlpIda)
            'desbloquearControl(tlpVuelta)

        Else
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(1) = txtDescripcion.Text
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(3) = cboCiudadOrigen.SelectedValue
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(4) = cboCiudadOrigen.SelectedItem.Item(1)
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(5) = cboParaderoOrigen.SelectedValue
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(6) = cboParaderoOrigen.SelectedItem.item(2)
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(8) = cboCiudadDestino.SelectedValue
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(9) = cboCiudadDestino.SelectedItem.item(1)
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(10) = cboParaderoDestino.SelectedValue
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(11) = cboParaderoDestino.SelectedItem.item(2)
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(12) = IIf(cbxIda.Checked, "Si", "No")
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(13) = IIf(cbxVuelta.Checked, "Si", "No")
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(14) = IIf(cbxEstado.Checked, "AC", "BA")
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(15) = IIf(cbxEstado.Checked, "ACTIVO", "DE BAJA")

            dgvResultado.DataSource = dtResultado
            'bloquearControl(btnOk_Ciudad)
            'bloquearControl(txtCiudad)
            'bloquearControl(txtParadero)

            'desbloquearControl(btnNuevo_Paradero)
            'desbloquearControl(btnEditar_Paradero)
        End If
        formatearDataGridView(dgvResultado)
        bloquearControl(btnOk)
        bloquearFilas(dgvResultado)
        desbloquearControl(tlpIda)
        desbloquearControl(tlpVuelta)
        desbloquearControl(btnGuardar)

        'cboCiudadIda.SelectedValue = cboCiudadOrigen.SelectedValue
        'cboCiudadIda_SelectionChangeCommitted(New Object, New System.EventArgs)
        'If cboParaderoOrigen.SelectedValue IsNot Nothing Then cboParaderoIda.SelectedValue = cboParaderoOrigen.SelectedValue
        ''cboParaderoIda.SelectedValue = cboParaderoOrigen.SelectedValue

        'cboCiudadVuelta.SelectedValue = cboCiudadDestino.SelectedValue
        'cboCiudadVuelta_SelectionChangeCommitted(New Object, New System.EventArgs)
        'If cboParaderoDestino.SelectedValue IsNot Nothing Then cboParaderoVuelta.SelectedValue = cboParaderoDestino.SelectedValue
        'cboParaderoVuelta.SelectedValue = cboParaderoDestino.SelectedValue

        'If esNuevaRuta Then
        '    btnMasIda_Click(sender, e)
        '    btnMasVuelta_Click(sender, e)
        'End If
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 Then
            ObtenerDetalleRutas(dgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString)
            deFilaACabecera(e.RowIndex)
        End If
    End Sub


    Private Sub deFilaACabecera(index As Integer)
        lblIdRuta.Text = dgvResultado.Rows(index).Cells(0).Value.ToString
        txtDescripcion.Text = dgvResultado.Rows(index).Cells(1).Value.ToString
        cboCiudadOrigen.SelectedValue = dgvResultado.Rows(index).Cells(3).Value.ToString
        cboCiudadOrigen_SelectionChangeCommitted(New Object, New System.EventArgs)
        cboParaderoOrigen.SelectedValue = dgvResultado.Rows(index).Cells(5).Value.ToString
        cbxIda.Checked = IIf(dgvResultado.Rows(index).Cells(12).Value.ToString = "Si", True, False)
        cbxVuelta.Checked = IIf(dgvResultado.Rows(index).Cells(13).Value.ToString = "Si", True, False)
        cboCiudadDestino.SelectedValue = dgvResultado.Rows(index).Cells(8).Value.ToString
        cboCiudadDestino_SelectionChangeCommitted(New Object, New System.EventArgs)
        cboParaderoDestino.SelectedValue = dgvResultado.Rows(index).Cells(10).Value.ToString
        cbxEstado.Checked = IIf(dgvResultado.Rows(index).Cells(14).Value.ToString = "AC", True, False)
    End Sub

    Public Sub ObtenerDetalleRutas(idRuta As String)
        Dim aux As New DataSet
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdRuta", idRuta)
        aux = doItBaby("sp_Dg_Logistica_Indices_Rutas_ObtenerDetalleRutas", p, TipoQuery.DataSet)
        dtDetalleIda = aux.Tables(0).Copy
        dtDetalleVuelta = aux.Tables(1).Copy

        dgvIda.DataSource = dtDetalleIda
        formatearDataGridView(dgvIda)

        dgvVuelta.DataSource = dtDetalleVuelta
        formatearDataGridView(dgvVuelta)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        '0:      Id()
        '1:      NombreRuta()
        '2:      DepPartida()
        '3:      IdCiudad()
        '4:      CiudadPartida()
        '5:      IdParaderoPartida()
        '6:      ParaderoPartida()
        '7:      DepDestino()
        '8:      IdCiudad()
        '9:      CiudadDestino()
        '10:     IdParaderoDestino()
        '11:     ParaderoDestino()
        '12:     Ida()
        '13:     Venida()
        '14:     IdEstado()
        '15:     Estado()
        '16:     UsuarioCrea()
        '17:     FechaHoraCrea()
        Dim idRutaGuardada As String = String.Empty
        Dim idParaderoGuardado As String = String.Empty
        Try
            observaciones = validarDatos()
            If observaciones <> "Ok" Then
                MessageBox.Show(observaciones)
                Exit Sub
            Else
                cadena = String.Empty
                Dim fila As DataGridViewRow = dgvResultado.SelectedRows.Item(0)
                encadenar(fila.Cells(0).Value.ToString)
                encadenar(fila.Cells(1).Value.ToString)
                encadenar(fila.Cells(5).Value.ToString)
                encadenar(fila.Cells(10).Value.ToString)
                encadenar(IIf(fila.Cells(12).Value.ToString = "Si", "1", "0"))
                encadenar(IIf(fila.Cells(13).Value.ToString = "Si", "1", "0"))
                encadenar(fila.Cells(14).Value.ToString)
                encadenar(usuarioActual)


                'encadenar(usuarioActual)
                Dim p As New Dictionary(Of String, Object)
                p.Add("@CadenaParametros", cadena)
                p.Add("@EsNuevo", esNuevaRuta.ToString)

                idRutaGuardada = doItBaby("sp_Dg_Logistica_Indices_Rutas_GuardarRuta", p, TipoQuery.Scalar)

                If idRutaGuardada.Substring(0, 2) = "Ok" Then
                    '0:                  Item()
                    '1:                  IdParadero()
                    '2:                  Paradero()
                    '3:                  Hora()
                    '4:                  Departamento()
                    '5:                  Ciudad()

                    idRutaGuardada = idRutaGuardada.Substring(2, idRutaGuardada.Length - 2)
                    If cbxIda.Checked Then
                        For Each RutaDetalle As DataGridViewRow In dgvIda.Rows
                            cadena = String.Empty
                            p.Clear()
                            encadenar(idRutaGuardada)
                            encadenar("I")
                            encadenar(RutaDetalle.Cells(0).Value.ToString)
                            encadenar(RutaDetalle.Cells(1).Value.ToString)
                            encadenar(RutaDetalle.Cells(3).Value.ToString)
                            encadenar(usuarioActual)
                            p.Add("@CadenaParametros", cadena)
                            'p.Add("@EsNuevo", RutaDetalle.Cells(10).Value.ToString)
                            idParaderoGuardado = doItBaby("sp_Dg_Logistica_Indices_Rutas_GuardarDetalle", p, TipoQuery.Scalar)
                            If idParaderoGuardado.Substring(0, 2) <> "Ok" Then
                                Throw New Exception("Error al guardar detalle." & idParaderoGuardado)
                            End If
                        Next
                    End If
                    If cbxVuelta.Checked Then
                        For Each RutaDetalle As DataGridViewRow In dgvVuelta.Rows
                            cadena = String.Empty
                            p.Clear()
                            encadenar(idRutaGuardada)
                            encadenar("V")
                            encadenar(RutaDetalle.Cells(0).Value.ToString)
                            encadenar(RutaDetalle.Cells(1).Value.ToString)
                            encadenar(RutaDetalle.Cells(3).Value.ToString)
                            encadenar(usuarioActual)
                            p.Add("@CadenaParametros", cadena)
                            'p.Add("@EsNuevo", RutaDetalle.Cells(10).Value.ToString)
                            idParaderoGuardado = doItBaby("sp_Dg_Logistica_Indices_Rutas_GuardarDetalle", p, TipoQuery.Scalar)
                            If idParaderoGuardado.Substring(0, 2) <> "Ok" Then
                                Throw New Exception("Error al guardar detalle." & idParaderoGuardado)
                            End If
                        Next
                    End If

                    'dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(0, dgvResultado.SelectedRows.Item(0).Index))
                    cargarDataGridViewResultado()
                    ObtenerDetalleRutas(idRutaGuardada)
                    MessageBox.Show("Registro guardado correctamente.")
                Else
                    Throw New Exception(idRutaGuardada)
                End If

                End If
            desbloquearControl(dgvResultado)
            desbloquearControl(btnNuevo)
            desbloquearControl(btnEditar)
            bloquearControl(btnGuardar)
            bloquearControl(btnCancelar)
            'bloquearControl(btnNuevo_Paradero)
            'bloquearControl(btnEditar_Paradero)
            bloquearControl(tlpCabecera)
            bloquearControl(tlpIda)
            bloquearControl(tlpVuelta)
        Catch ex As Exception
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdRuta", idRutaGuardada)
            'doItBaby("sp_Dg_Logistica_Indices_Rutas_RollBack", p, TipoQuery.Scalar)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function validarDatos() As String
        If txtDescripcion.Text.Contains("!") Then 'Or txtDni.Text.Contains(" ") Then
            Return "No puede usar caracteres especiales."
        ElseIf btnMasIda.Focused AndAlso tlpIda.Enabled = True AndAlso cboCiudadIda.SelectedIndex < 0 Then
            Return "Debe seleccionar una ciudad de ida."
        ElseIf btnMasIda.Focused AndAlso tlpIda.Enabled = True AndAlso cboParaderoIda.SelectedIndex < 0 Then
            Return "Debe seleccionar un paradero de ida."
        

        ElseIf btnMasVuelta.Focused AndAlso tlpVuelta.Enabled = True AndAlso cboCiudadVuelta.SelectedIndex < 0 Then
            Return "Debe seleccionar una ciudad de vuelta."
        ElseIf btnMasVuelta.Focused AndAlso tlpVuelta.Enabled = True AndAlso cboParaderoVuelta.SelectedIndex < 0 Then
            Return "Debe seleccionar una paradero de vuelta."
        End If
        Return "Ok"
    End Function


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        desbloquearFilas(dgvResultado)
        limpiarControles()
        cargarDataGridViewResultado()

        desbloquearControl(btnNuevo)
        desbloquearControl(btnEditar)
        'bloquearControl(btnOk_Ciudad)
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        'bloquearControl(btnOk_Paradero)
        bloquearControl(tlpIda)
        bloquearControl(tlpVuelta)
        bloquearControl(tlpCabecera)
        'bloquearControl(btnNuevo_Paradero)
        'bloquearControl(btnEditar_Paradero)
        'bloquearControl(txtCiudad)
        'bloquearControl(txtParadero)
        dgvIda.DataSource = Nothing
        dgvVuelta.DataSource = Nothing
        esNuevaRuta = False
    End Sub

    Public Sub encadenar(parametro As String)
        If cadena.Length = 0 Then
            cadena = IIf(parametro.Length = 0, " ", parametro)
        Else
            cadena = cadena & "!" & parametro
        End If
    End Sub

    
    Private Sub btnMasIda_Click(sender As Object, e As EventArgs) Handles btnMasIda.Click
        '0:                  Item()
        '1:                  IdParadero()
        '2:                  Paradero()
        '3:                  Hora()
        '4:                  Departamento()
        '5:                  Ciudad()
        observaciones = validarDatos()
        If observaciones <> "Ok" Then
            MessageBox.Show(observaciones)
            Exit Sub
        Else
            Dim fila As DataRow = dtDetalleIda.NewRow
            Dim i As Integer = dtDetalleIda.Rows.Count + 1
            fila.Item(0) = IIf(i.ToString.Length = 1, "0" & i, i)
            'fila.Item(0) = ""
            fila.Item(1) = cboParaderoIda.SelectedValue
            fila.Item(2) = cboParaderoIda.SelectedItem.row.itemarray(2).ToString
            fila.Item(3) = dtpIda.Value.ToString("HH:mm:ss")
            fila.Item(4) = ""
            fila.Item(5) = cboCiudadIda.SelectedValue

            dtDetalleIda.Rows.Add(fila)
            dgvIda.DataSource = dtDetalleIda
        End If
    End Sub

    Private Sub btnMasVuelta_Click(sender As Object, e As EventArgs) Handles btnMasVuelta.Click
        observaciones = validarDatos()
        If observaciones <> "Ok" Then
            MessageBox.Show(observaciones)
            Exit Sub
        Else
            Dim fila As DataRow = dtDetalleVuelta.NewRow
            Dim i As Integer = dtDetalleVuelta.Rows.Count + 1
            fila.Item(0) = IIf(i.ToString.Length = 1, "0" & i, i) ' IIf(i.ToString.Length = 1, "00" & i, IIf(i.ToString.Length = 2, "0" & i, i))
            'fila.Item(0) = ""
            fila.Item(1) = cboParaderoVuelta.SelectedValue
            fila.Item(2) = cboParaderoVuelta.SelectedItem.row.itemarray(2).ToString
            fila.Item(3) = dtpVuelta.Value.ToString("HH:mm:ss")
            fila.Item(4) = ""
            fila.Item(5) = cboCiudadVuelta.SelectedValue

            dtDetalleVuelta.Rows.Add(fila)
            dgvVuelta.DataSource = dtDetalleVuelta
        End If
    End Sub

    Private Sub btnMenosIda_Click(sender As Object, e As EventArgs) Handles btnMenosIda.Click
        Dim fila As DataGridViewRow = dgvIda.SelectedRows.Item(0)
        Dim val As String = fila.Cells(0).Value.ToString
        'val = IIf(val(0) = "0" And val(1) = "0", val(2), IIf(val(0) = "0", val.Substring(1, 2), val))
        Dim index As Integer = CType(val, Integer) - 1
        For i As Integer = 0 To dtDetalleIda.Rows.Count - 1 Step 1
            If dtDetalleIda.Rows(i).Item(0) = val Then
                dtDetalleIda.Rows.RemoveAt(i)
                i = i + 1
            Else
                dtDetalleIda.Rows(i).Item(0) = generarCorrelativo(i + 1, 2)
            End If
        Next
        dgvIda.DataSource = dtDetalleIda
    End Sub

    Private Sub btnMenosVuelta_Click(sender As Object, e As EventArgs) Handles btnMenosVuelta.Click
        Dim fila As DataGridViewRow = dgvVuelta.SelectedRows.Item(0)
        Dim val As String = fila.Cells(0).Value.ToString
        'val = IIf(val(0) = "0" And val(1) = "0", val(2), IIf(val(0) = "0", val.Substring(1, 2), val))
        Dim index As Integer = CType(val, Integer) - 1
        For i As Integer = 0 To dtDetalleVuelta.Rows.Count - 1 Step 1
            If dtDetalleVuelta.Rows(i).Item(0) = val Then
                dtDetalleVuelta.Rows.RemoveAt(i)
                i = i + 1
            Else
                dtDetalleVuelta.Rows(i).Item(0) = generarCorrelativo(i + 1, 3)
            End If
        Next
        dgvVuelta.DataSource = dtDetalleVuelta
    End Sub

    Private Function generarCorrelativo(valor As Integer, nCarateres As Integer) As String
        Return StrDup(nCarateres - valor.ToString.Length, "0") & valor.ToString
    End Function


    Private Sub cboCiudadOrigen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCiudadOrigen.SelectionChangeCommitted
        cargarCombo(cboParaderoOrigen, dsMetadatos.Tables(1).Copy, cboCiudadOrigen.SelectedValue, True)
    End Sub

    Private Sub cboCiudadDestino_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCiudadDestino.SelectionChangeCommitted
        cargarCombo(cboParaderoDestino, dsMetadatos.Tables(1).Copy, cboCiudadDestino.SelectedValue, True)
    End Sub

    Private Sub cboCiudadIda_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCiudadIda.SelectionChangeCommitted
        cargarCombo(cboParaderoIda, dsMetadatos.Tables(1).Copy, cboCiudadIda.SelectedValue, True)
    End Sub

    Private Sub cboCiudadVuelta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCiudadVuelta.SelectionChangeCommitted
        cargarCombo(cboParaderoVuelta, dsMetadatos.Tables(1).Copy, cboCiudadVuelta.SelectedValue, True)
    End Sub

    Private Sub dgvResultado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellContentClick

    End Sub
End Class