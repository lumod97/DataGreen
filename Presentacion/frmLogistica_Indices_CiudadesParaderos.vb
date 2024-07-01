Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmLogistica_Indices_CiudadesParaderos
    Dim dsMetadatos As DataSet
    Dim dtResultado As DataTable
    Dim dtParaderos As DataTable
    Dim esNuevaCiudad As Boolean = True
    Dim esNuevoParadero As Boolean = True
    Dim observaciones As String = String.Empty
    Dim cadena As String = String.Empty

    Private Sub frmLogistica_Indices_CiudadesParaderos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
        cargarDataGridViewResultado()

        obtenerMetaDatos()
        usarMetadatos()
        'cargarCombo(cboClase, dsDataParaCombo.Tables(0), "", True)
        'cargarCombo(cboCategoria, dsDataParaCombo.Tables(1), "", False)
        'deseleccionarCombos()

        bloquearControles()
        ajustarBotones()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub cargarDataGridViewResultado()
        dtResultado = New DataTable
        dtResultado = doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_ObtenerCiudades", Nothing, TipoQuery.DataTable)
        'Dim dvConductores As New DataView(dtResultado)
        dgvResultado.DataSource = dtResultado
        formatearDataGridView(dgvResultado)
        dgvResultado.ClearSelection()
        'lblDin_Resultado.Text = "Registros: " & dgvResultado.Rows.Count.ToString
    End Sub

    Private Sub obtenerMetaDatos()
        'Dim aux As New DataSet
        dsMetadatos = doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_Load", Nothing, TipoQuery.DataSet)
        'dsDataParaCombo = New DataSet
        'dsDataParaCombo.Tables.Add(aux.Tables(0).Copy)
        'dsDataParaCombo.Tables.Add(aux.Tables(1).Copy)
    End Sub


    Private Sub usarMetadatos()
        cargarTxtDepartamentos()
    End Sub

    Public Sub bloquearControles()
        bloquearControl(btnOk_Ciudad)
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        bloquearControl(btnOk_Paradero)
        'bloquearControl(btnCancelar_Paradero)

        bloquearControl(btnNuevo_Paradero)
        bloquearControl(btnEditar_Paradero)
        bloquearControl(txtCiudad)
        bloquearControl(txtParadero)
        bloquearControl(dgvParaderos)
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

        btnNuevo_Paradero.Height = alto
        btnNuevo_Paradero.FlatAppearance.BorderSize = 0
        btnEditar_Paradero.Height = alto
        btnEditar_Paradero.FlatAppearance.BorderSize = 0
        btnOk_Paradero.Height = alto
        btnOk_Paradero.FlatAppearance.BorderSize = 0
        'btnEliminar_Paradero.Height = alto
        'btnEliminar_Paradero.FlatAppearance.BorderSize = 0
        'btnCancelar_Paradero.Height = alto
        'btnCancelar_Paradero.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub cargarTxtDepartamentos()
        Dim acsDepartamentos As New AutoCompleteStringCollection
        For Each fila As DataRow In dsMetadatos.Tables(0).Rows
            acsDepartamentos.Add(fila.Item(0).ToString)
        Next

        txtDepartamento.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDepartamento.AutoCompleteCustomSource = acsDepartamentos
        txtDepartamento.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        esNuevaCiudad = True
        limpiarControles()
        desbloquearControl(txtCiudad)
        'desbloquearControl(txtParadero)

        desbloquearControl(btnOk_Ciudad)
        desbloquearControl(btnGuardar)
        desbloquearControl(btnCancelar)
        bloquearControl(btnEditar)
        bloquearControl(btnNuevo)

        dgvParaderos.DataSource = Nothing

        txtCiudad.Focus()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvResultado.SelectedRows IsNot Nothing Then
            bloquearFilas(dgvResultado)
            esNuevaCiudad = False
            bloquearControl(btnNuevo)
            bloquearControl(btnEditar)
            desbloquearControl(btnGuardar)
            desbloquearControl(btnCancelar)
            desbloquearControl(btnOk_Ciudad)
            desbloquearControl(txtCiudad)
        Else
            MessageBox.Show("No ha seleccionado niguna fila.")
        End If
    End Sub


    Private Sub limpiarControles()
        txtCiudad.Text = ""
        txtDepartamento.Text = ""
        lblNombreCiudad.Text = ""
        txtParadero.Text = ""
        cbxActivo_Ciudad.Checked = True
        cbxActivo_Paradero.Checked = True
    End Sub

    Private Sub limpiarControles_Paraderos()
        lblNombreCiudad.Text = ""
        txtParadero.Text = ""
        cbxActivo_Paradero.Checked = True
    End Sub

    
    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 Then
            buscarParaderos(dgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString)
            'Dim idCiudad As String = dgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString
            'Dim p As New Dictionary(Of String, Object)
            'p.Add("@IdCiudad", idCiudad)
            'dtParaderos = doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_ObtenerParaderos", p, TipoQuery.DataTable)
            'dgvParaderos.DataSource = dtParaderos
            'formatearDataGridView(dgvParaderos)

            lblIdCiudad.Text = dgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString
            txtCiudad.Text = dgvResultado.Rows(e.RowIndex).Cells(1).Value.ToString
            txtDepartamento.Text = dgvResultado.Rows(e.RowIndex).Cells(2).Value.ToString
            cbxActivo_Ciudad.Checked = IIf(dgvResultado.Rows(e.RowIndex).Cells(3).Value.ToString = "AC", True, False)
            lblNombreCiudad.Text = txtCiudad.Text
        End If
    End Sub

    Public Sub buscarParaderos(idCiudad As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdCiudad", idCiudad)
        dtParaderos = doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_ObtenerParaderos", p, TipoQuery.DataTable)
        dgvParaderos.DataSource = dtParaderos
        formatearDataGridView(dgvParaderos)
        dgvParaderos.Columns("EsNuevo").Visible = False
        'lblIdCiudad.Text = dgvResultado.Rows(e.RowIndex).Cells(0).Value.ToString
        'txtCiudad.Text = dgvResultado.Rows(e.RowIndex).Cells(1).Value.ToString
        'txtDepartamento.Text = dgvResultado.Rows(e.RowIndex).Cells(2).Value.ToString
        'cbxActivo_Ciudad.Checked = IIf(dgvResultado.Rows(e.RowIndex).Cells(3).Value.ToString = "AC", True, False)
        'lblNombreCiudad.Text = txtCiudad.Text
    End Sub

    Private Sub dgvParaderos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParaderos.CellClick
        lblIdParadero.Text = dgvParaderos.Rows(e.RowIndex).Cells(0).Value.ToString
        txtParadero.Text = dgvParaderos.Rows(e.RowIndex).Cells(3).Value.ToString
        cbxActivo_Paradero.Checked = IIf(dgvParaderos.Rows(e.RowIndex).Cells(4).Value.ToString = "AC", True, False)
    End Sub

    Private Sub btnOk_Ciudad_Click(sender As Object, e As EventArgs) Handles btnOk_Ciudad.Click
        If esNuevaCiudad Then
            Dim fila As DataRow = dtResultado.NewRow
            fila.Item(0) = ""
            fila.Item(1) = txtCiudad.Text
            fila.Item(2) = txtDepartamento.Text
            fila.Item(3) = IIf(cbxActivo_Ciudad.Checked, "AC", "BA")
            'fila.Item(4) = ""
            dtResultado.Rows.Add(fila)
            formatearDataGridView(dgvResultado)
            bloquearControl(btnOk_Ciudad)
            dgvResultado.ClearSelection()
            dgvResultado.Rows(dgvResultado.Rows.Count - 1).Selected = True
            bloquearFilas(dgvResultado)
            dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(0, dgvResultado.Rows.Count - 1))

            desbloquearControl(txtParadero)
            bloquearControl(btnNuevo_Paradero)
            'desbloquearControl(btnNuevo_Paradero)
            bloquearControl(btnEditar_Paradero)
            desbloquearControl(btnOk_Paradero)
            txtParadero.Focus()
        Else
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(1) = txtCiudad.Text
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(2) = txtDepartamento.Text
            dtResultado.Rows(dgvResultado.CurrentRow.Index).Item(3) = IIf(cbxActivo_Ciudad.Checked, "AC", "BA")
            dgvResultado.DataSource = dtResultado
            bloquearControl(btnOk_Ciudad)
            'desbloquearControl(btnEditar)
            bloquearControl(txtCiudad)
            bloquearControl(txtParadero)
            txtParadero.Focus()
            desbloquearControl(btnNuevo_Paradero)
            desbloquearControl(btnEditar_Paradero)
            'txtCiudad.Text = ""
            'txtDepartamento.Text = ""
        End If
        desbloquearControl(dgvParaderos)
    End Sub


    Private Sub btnOk_Paradero_Click(sender As Object, e As EventArgs) Handles btnOk_Paradero.Click
        If esNuevoParadero Then
            Dim fila As DataRow = dtParaderos.NewRow
            fila.Item(0) = ""
            fila.Item(1) = lblIdCiudad.Text
            fila.Item(2) = lblNombreCiudad.Text
            fila.Item(3) = txtParadero.Text
            fila.Item(4) = "AC"
            'fila.Item(5) = "ACTIVO"
            fila.Item(10) = "TRUE"
            dtParaderos.Rows.Add(fila)
            dgvParaderos.CurrentCell = dgvParaderos.Rows(0).Cells(0)
        Else
            dtParaderos.Rows(dgvParaderos.CurrentRow.Index).Item(3) = txtParadero.Text
            dtParaderos.Rows(dgvParaderos.CurrentRow.Index).Item(4) = IIf(cbxActivo_Paradero.Checked, "AC", "BA")
            dtParaderos.Rows(dgvParaderos.CurrentRow.Index).Item(10) = "FALSE"
        End If

        formatearDataGridView(dgvParaderos)

        desbloquearFilas(dgvParaderos)
        desbloquearControl(btnNuevo_Paradero)
        desbloquearControl(btnEditar_Paradero)
        txtParadero.Text = ""
        txtParadero.Enabled = False
        bloquearControl(btnOk_Paradero)
        bloquearControl(txtParadero)
        bloquearControl(cbxActivo_Paradero)
    End Sub

    Private Sub btnNuevo_Paradero_Click(sender As Object, e As EventArgs) Handles btnNuevo_Paradero.Click
        esNuevoParadero = True
        desbloquearControl(btnOk_Paradero)
        desbloquearControl(txtParadero)
        desbloquearControl(cbxActivo_Paradero)
        bloquearControl(btnNuevo_Paradero)
        bloquearControl(btnEditar_Paradero)
        txtParadero.Text = ""
        txtParadero.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idCiudadGuardada As String = String.Empty
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
                encadenar(fila.Cells(2).Value.ToString)
                encadenar(fila.Cells(3).Value.ToString)
                encadenar(usuarioActual)
                Dim p As New Dictionary(Of String, Object)
                p.Add("@CadenaParametros", cadena)
                p.Add("@EsNuevo", esNuevaCiudad.ToString)

                idCiudadGuardada = doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_GuardarCiudad", p, TipoQuery.Scalar)

                If idCiudadGuardada.Substring(0, 2) = "Ok" Then
                    idCiudadGuardada = idCiudadGuardada.Substring(2, idCiudadGuardada.Length - 2)
                    For Each paradero As DataGridViewRow In dgvParaderos.Rows
                        cadena = String.Empty
                        p.Clear()
                        encadenar(paradero.Cells(0).Value.ToString)
                        encadenar(idCiudadGuardada)
                        'encadenar(paradero.Cells(2).Value.ToString)
                        encadenar(paradero.Cells(3).Value.ToString)
                        encadenar(paradero.Cells(4).Value.ToString)
                        encadenar(usuarioActual)
                        'encadenar(paradero.Cells(10).Value.ToString)
                        p.Add("@CadenaParametros", cadena)
                        p.Add("@EsNuevo", paradero.Cells(10).Value.ToString)
                        idParaderoGuardado = doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_GuardarParadero", p, TipoQuery.Scalar)
                        If idParaderoGuardado.Substring(0, 2) <> "Ok" Then
                            Throw New Exception("Error al guardar detalle." & idParaderoGuardado)
                        End If
                    Next
                    'dgvResultado_CellClick(sender, New DataGridViewCellEventArgs(0, dgvResultado.SelectedRows.Item(0).Index))
                    cargarDataGridViewResultado()
                    buscarParaderos(idCiudadGuardada)
                    MessageBox.Show("Registro guardado correctamente.")
                Else
                    Throw New Exception(idCiudadGuardada)
                End If

            End If
            desbloquearControl(dgvResultado)
            desbloquearControl(btnNuevo)
            desbloquearControl(btnEditar)
            bloquearControl(btnGuardar)
            bloquearControl(btnCancelar)
            bloquearControl(btnNuevo_Paradero)
            bloquearControl(btnEditar_Paradero)
            bloquearControles()
            'bloquearControl(txtDni)
            'bloquearControl(btnCancelar)
            'bloquearControl(btnGuardar)
            ''desbloquearControl(btnGuardar)
            'desbloquearControl(btnEditar)
            'desbloquearControl(btnNuevo)
        Catch ex As Exception
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdCiudad", idCiudadGuardada)
            doItBaby("sp_Dg_Logistica_Indices_CiudadesParaderos_RollBack", p, TipoQuery.Scalar)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        desbloquearFilas(dgvResultado)
        limpiarControles()
        cargarDataGridViewResultado()

        desbloquearControl(btnNuevo)
        desbloquearControl(btnEditar)
        bloquearControl(btnOk_Ciudad)
        bloquearControl(btnGuardar)
        bloquearControl(btnCancelar)
        bloquearControl(btnOk_Paradero)

        bloquearControl(btnNuevo_Paradero)
        bloquearControl(btnEditar_Paradero)
        bloquearControl(txtCiudad)
        bloquearControl(txtParadero)
        bloquearControl(cbxActivo_Paradero)
        dgvParaderos.DataSource = Nothing
        esNuevaCiudad = False
    End Sub

   
    Private Sub btnEditar_Paradero_Click(sender As Object, e As EventArgs) Handles btnEditar_Paradero.Click
        If dgvParaderos.CurrentRow IsNot Nothing Then
            esNuevoParadero = False
            bloquearFilas(dgvParaderos)
            bloquearControl(btnNuevo_Paradero)
            bloquearControl(btnEditar_Paradero)
            desbloquearControl(btnOk_Paradero)
            desbloquearControl(txtParadero)
            desbloquearControl(cbxActivo_Paradero)
            txtParadero.Focus()
        End If
    End Sub

    Private Function validarDatos() As String
        If txtCiudad.Text.Length < 1 Then 'Or txtDni.Text.Contains(" ") Then
            Return "Debe ingresar un nombre de ciudad valido."
        ElseIf txtDepartamento.Text.Length < 1 Then
            Return "Debe ingresar un nombre de departamento valido."
        ElseIf txtParadero.Enabled AndAlso txtParadero.Text.Length < 1 Then
            Return "Debe ingresar un nombre de paradero valido."
        End If
        Return "Ok"
    End Function

    Public Sub encadenar(parametro As String)
        If cadena.Length = 0 Then
            cadena = IIf(parametro.Length = 0, " ", parametro)
        Else
            cadena = cadena & "!" & parametro
        End If
    End Sub

    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs)
    '    Dim id As String = String.Empty
    '    id = dgvParaderos.SelectedRows(0).Cells(0).Value
    '    Dim aux As DataTable = dtParaderos.Copy
    '    For Each fila As DataRow In aux.Rows
    '        If fila.Item(0) = id Then
    '            dtParaderos.Rows.RemoveAt(aux.Rows.IndexOf(fila))
    '            Exit For
    '        End If
    '    Next
    'End Sub

End Class