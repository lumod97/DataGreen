Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_ConfiguracionGruposLabores

    Dim arrayDeParametros As String = String.Empty
    Dim dsResultado As DataSet
    Dim dsDataParaCombo As DataSet
    Public Structure Grupo
        Dim id As String
        Dim descripcion As String
        Dim conBono As Boolean
    End Structure
    Dim grupoActual As New Grupo

    Private Sub frmRrhh_Movimientos_ConfiguracionGruposLabores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        setearControles("Listo")
        obtenerDataParaCombos()
        cargarCombo(cboActividad, dsDataParaCombo.Tables(0), "", True)
        obtenerCabecera()
        cargarCabecera()
        tlpPrincipal.Visible = True
    End Sub

    Private Sub setearControles(estado As String)
        If estado = "Listo" Then
            btnNuevo.Enabled = True
            btnEditar.Enabled = True
            btnCancelar.Enabled = False
            btnGuardar.Enabled = False
            txtDescripcion.Enabled = False
            cbxConBono.Enabled = False
            dgvCabecera.Enabled = True
            cboActividad.Enabled = False
            cboLabor.Enabled = False
            btnAgregar.Enabled = False
            btnEliminar.Enabled = False
            dgvDetalle.Enabled = False
            dgvCabecera.ClearSelection()
            dgvDetalle.ClearSelection()
            txtDescripcion.Text = ""
            cbxConBono.Checked = False
        ElseIf estado = "Edicion" Then
            btnNuevo.Enabled = False
            btnEditar.Enabled = False
            btnCancelar.Enabled = True
            btnGuardar.Enabled = True
            txtDescripcion.Enabled = True
            cbxConBono.Enabled = True
            dgvCabecera.Enabled = True
            cboActividad.Enabled = True
            cboLabor.Enabled = True
            btnAgregar.Enabled = True
            btnEliminar.Enabled = True
            dgvDetalle.Enabled = True
            txtDescripcion.Focus()
        End If

    End Sub

    Private Sub obtenerDataParaCombos()
        dsDataParaCombo = New DataSet
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerActividades", Nothing, TipoQuery.DataTable))
        soloClavesUnicas(dsDataParaCombo.Tables(0))
        'sDataParaCombo.Tables.Add(doItBaby("sp_ObtenerPlanillas", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub obtenerCabecera()
        dsResultado = New DataSet
        dsResultado.Tables.Add(doItBaby("sp_Dg_Rrhh_Movimientos_ConfiguracionGruposLabores_ObtenerGrupos", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub cargarCabecera()
        corregirTabla(dsResultado.Tables(0))
        dgvCabecera.DataSource = dsResultado.Tables(0)
        formatearDataGridView(dgvCabecera)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grupoActual = New Grupo ' .id = ""
        'g.descripcion = ""
        setearControles("Edicion")
        dgvCabecera.ClearSelection()
        txtDescripcion.Text = ""
        obtenerDetalle("")
        cargarDetalle()
        cboActividad.SelectedIndex = -1
        cboLabor.SelectedIndex = -1
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvCabecera.SelectedRows.Count < 1 Then
            MessageBox.Show("Ninguna fila ha sido seleccionada.")
        Else
            setearControles("Edicion")
            bloquearFilas(dgvCabecera)
            cboActividad.SelectedIndex = -1
            cboLabor.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        setearControles("Listo")
        desbloquearFilas(dgvCabecera)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtDescripcion.Text.Length < 1 Then
                MessageBox.Show("Debe darle una descripcion al grupo.")
            Else
                Dim p As New Dictionary(Of String, Object)
                p.Add("@IdGrupo", grupoActual.id)
                p.Add("@Descripcion", grupoActual.descripcion)
                p.Add("@ConBono", grupoActual.conBono.ToString)
                grupoActual.id = doItBaby("sp_Dg_Rrhh_Movimientos_ConfiguracionGruposLabores_GuardarCabecera", p, TipoQuery.Scalar)
                If grupoActual.id > 0 Then
                    For Each f As DataRow In dsResultado.Tables(1).Rows
                        p.Clear()
                        p.Add("@IdGrupo", grupoActual.id)
                        p.Add("@IdActividad", f.Item(0))
                        p.Add("@IdLabor", f.Item(2))
                        If Not doItBaby("sp_Dg_Rrhh_Movimientos_ConfiguracionGruposLabores_GuardarDetalle", p, TipoQuery.NonQuery) Then
                            Throw New Exception("Error, al registrar el detalle.")
                        End If
                    Next
                End If
                setearControles("Listo")
                desbloquearFilas(dgvCabecera)
                MessageBox.Show("Registro guardado correctamente.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub dgvCabecera_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCabecera.CellContentClick
    '    If e.RowIndex >= 0 Then
    '        '            MessageBox.Show(dgvCabecera.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
    '        txtDescripcion.Text = dgvCabecera.Rows(e.RowIndex).Cells(1).Value.ToString
    '        cbxConBono.Checked = IIf(dgvCabecera.Rows(e.RowIndex).Cells(1).Value.ToString = "1", True, False)
    '        obtenerDetalle(dgvCabecera.Rows(e.RowIndex).Cells(0).Value.ToString)
    '        cargarDetalle()
    '    End If
    'End Sub

    Private Sub dgvCabecera_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCabecera.CellClick
        If e.RowIndex >= 0 Then
            '            MessageBox.Show(dgvCabecera.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString)
            grupoActual.id = dgvCabecera.Rows(e.RowIndex).Cells(0).Value.ToString
            grupoActual.descripcion = dgvCabecera.Rows(e.RowIndex).Cells(1).Value.ToString
            grupoActual.conBono = IIf(dgvCabecera.Rows(e.RowIndex).Cells(2).Value.ToString = "1", True, False)

            txtDescripcion.Text = grupoActual.descripcion
            cbxConBono.Checked = grupoActual.conBono
            'cbxConBono.Checked = IIf(dgvCabecera.Rows(e.RowIndex).Cells(1).Value.ToString = "1", True, False)
            obtenerDetalle(grupoActual.id)
            cargarDetalle()
        End If
    End Sub

    Private Sub obtenerDetalle(idGrupo As String)
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdGrupo", idGrupo)
        If dsResultado.Tables.Count > 1 Then
            dsResultado.Tables.RemoveAt(1)
        End If
        dsResultado.Tables.Add(doItBaby("sp_Dg_Rrhh_Movimientos_ConfiguracionGruposLabores_ObtenerDetalle", p, TipoQuery.DataTable))
    End Sub

    Private Sub cargarDetalle()
        corregirTabla(dsResultado.Tables(1))
        dgvDetalle.DataSource = dsResultado.Tables(1)
        formatearDataGridView(dgvDetalle)
    End Sub

    Private Sub cboActividad_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActividad.SelectionChangeCommitted
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdActividad", cboActividad.SelectedValue)
        If dsDataParaCombo.Tables.Count > 1 Then
            dsDataParaCombo.Tables.RemoveAt(1)
        End If
        dsDataParaCombo.Tables.Add(doItBaby("sp_Dg_ObtenerLabores", p, TipoQuery.DataTable))
        cargarCombo(cboLabor, dsDataParaCombo.Tables(1), "", True)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim f As DataRow = dsResultado.Tables(1).NewRow
        Dim s As String()
        f.Item(0) = cboActividad.SelectedValue
        s = Split(cboActividad.Text, " | ")
        f.Item(1) = s(1)
        f.Item(2) = cboLabor.SelectedValue
        s = Split(cboLabor.Text, " | ")
        f.Item(3) = s(1)
        dsResultado.Tables(1).Rows.Add(f)
        formatearDataGridView(dgvDetalle)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        'PENDIENTE: MEJORAR PARA ELIMINAR VARIAS FILAS A LA VEZ
        If dgvDetalle.SelectedRows.Count < 1 Then
            MessageBox.Show("Ninguna fila ha sido seleccionada.")
        ElseIf dgvDetalle.SelectedRows.Count > 1 Then
            MessageBox.Show("Seleccione solo 1 fila.")
        Else
            dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index)
        End If
    End Sub

End Class