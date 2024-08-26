Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmProduccion_Movimientos_ActualizarDatosPallets
    Public tablasParaCombos As DataSet
    Dim bsCabeceraPallets As New BindingSource()
    Dim filasSeleccionadas As Integer = 0

    Private Sub frmProduccion_Movimientos_ActualizarDatosPallets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerMultitablaParaCombos()
        cargarDgvCabeceraPallets()
        'dgvResultado.AllowUserToResizeRows = False
        tlpPrincipal.Visible = True
        tlpEdicion.Enabled = False
        tlpEdicion.Visible = False
        dgvCabeceraPallets.Focus()
        'INHABILITACION TEMPORAL POR ERROR DE USUARIO,
        'PENDIENTE: MEJORAR TODA LA INTERFAZ
        cbxCalibre.Enabled = False
        txtNro.Enabled = False
    End Sub

    Private Sub obtenerMultitablaParaCombos()
        Dim aux As DataSet = New DataSet
        'aux = execSp_Dg_Produccion_Movimientos_ActualizarDatosPallets_CargarData()
        aux = doItBaby("sp_Dg_Produccion_Movimientos_ActualizarDatosPallets_CargarData", Nothing, TipoQuery.DataSet)
        tablasParaCombos = New DataSet
        tablasParaCombos.Tables.Add(aux.Tables(0).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(1).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(2).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(3).Copy)
    End Sub

    Private Function buscarDetallePallet(idRegistroPallet As String) As DataTable
        Try
            Dim aux As DataTable = New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdRegistroPallet", idRegistroPallet)
            'aux = execSp_Dg_Produccion_Movimientos_ActualizarDatosPallets_DetallePallet(idRegistroPallet)
            aux = doItBaby("sp_Dg_Produccion_Movimientos_ActualizarDatosPallets_DetallePallet", p, TipoQuery.DataTable)
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "")
        comboBox.DataSource = Nothing
        Dim i As Integer = 0
        If dataTable.Columns.Count = 3 Then
            comboBox.DataSource = dataTable
            comboBox.ValueMember = "Clave"
            If dataTable.Rows.Count < 10 Then
                comboBox.DisplayMember = "Valor"
            Else
                comboBox.DisplayMember = "Concatenado"
            End If
        Else
            For Each fila As DataRow In dataTable.Rows
                If fila.Item(0).ToString = condicion Then
                    Dim dt As DataTable = dataTable
                    Dim dataView As DataView = dt.DefaultView
                    dataView.RowFilter = "Condicion = '" & condicion & "'"
                    comboBox.DataSource = dataView
                    comboBox.ValueMember = "Clave"
                    If dataView.Count < 10 Then
                        comboBox.DisplayMember = "Valor"
                    Else
                        comboBox.DisplayMember = "Concatenado"
                    End If
                End If
                i = i + 1
            Next
        End If
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub cargarDgvCabeceraPallets()
        dgvCabeceraPallets.Columns.Clear()
        dgvCabeceraPallets.DataSource = Nothing
        Dim dvCabeceraPallets As New DataView(tablasParaCombos.Tables(0))
        bsCabeceraPallets.DataSource = dvCabeceraPallets
        dgvCabeceraPallets.DataSource = bsCabeceraPallets

        Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        dgvColumnCheck = New DataGridViewCheckBoxColumn()
        dgvColumnCheck.Name = "CheckEditar"
        dgvColumnCheck.HeaderText = "Editar"
        dgvCabeceraPallets.Columns.Insert(0, dgvColumnCheck)

        corregirCeldas(dgvCabeceraPallets)
        formatearDataGridView(dgvCabeceraPallets)
        'dgvCabeceraPallets.AutoResizeColumns()
        'dgvCabeceraPallets.AutoResizeRows()

        dgvCabeceraPallets.Columns(1).Visible = False
        
        Dim filas As Integer = dgvCabeceraPallets.RowCount
        lblCoincidencias.Text = "Coincidencias: " + filas.ToString
    End Sub

    Private Sub dgvCabeceraPallets_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvCabeceraPallets.DataError
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

    'Private Sub dgvCabeceraPallets_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCabeceraPallets.CellFormatting
    '    'FORMATEAR COLUMNAS SEGUN NOMBRE DE CABECERA
    '    Dim col As Integer = dgvCabeceraPallets.ColumnCount - 1, tipo As String
    '    For i As Integer = 0 To col Step 1
    '        tipo = dgvCabeceraPallets.Columns(i).Name.ToString.Substring(0, 2)
    '        If tipo = "F_" Then
    '            dgvCabeceraPallets.Columns(i).DefaultCellStyle.Format = "yyyy-MM-dd"
    '            'ElseIf tipo = "T" Then
    '            '    dgvResultado.Columns(i).DefaultCellStyle.Format = "@"
    '            'ElseIf tipo = "N" Then
    '            '    dgvResultado.Columns(i).DefaultCellStyle.Format = "#"
    '        ElseIf tipo = "H1" Then
    '            dgvCabeceraPallets.Columns(i).DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss"
    '        ElseIf tipo.Substring(0, 1) = "D" And tipo.Substring(1, 1) >= "0" And tipo.Substring(1, 1) <= "9" Then
    '            Dim ceros As Integer = CInt(tipo.Substring(1, 1))
    '            dgvCabeceraPallets.Columns(i).DefaultCellStyle.Format = "#,##0." + StrDup(ceros, "0")
    '            '    dgvResultado.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '        End If
    '    Next
    'End Sub

    Private Sub actualizarFiltro()
        bsCabeceraPallets.Filter = String.Format("Campana like '%{0}%' And " +
                                                 "CodigoPallet like '%{1}%' And " +
                                                 "Fecha like '%{2}%' And " +
                                                 "Cultivo like '%{3}%' And " +
                                                 "Variedad like '%{4}%' And " +
                                                 "IdCliente like '%{5}%' And " +
                                                 "Cliente like '%{6}%' And " +
                                                 "Empaque like '%{7}%'",
                                                 txtCampana.Text,
                                                 txtCodigoPallet.Text,
                                                 txtFecha.Text,
                                                 txtCultivo.Text,
                                                 txtVariedad.Text,
                                                 txtIdCliente.Text,
                                                 txtCliente.Text,
                                                 txtEmpaque.Text)
        lblCoincidencias.Text = "Coincicidencias: " + bsCabeceraPallets.Count.ToString
        filasSeleccionadas = 0
        lblSeleccionados.Text = "Seleccionadas: 0"
        'dgvDetallePallets.DataSource = Nothing
        If radEdicionIndependiente.Checked Then
            dgvDetallePallets.Columns.Clear()
        End If

    End Sub

    Private Sub txtCampana_TextChanged(sender As Object, e As EventArgs) Handles txtCampana.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtCultivo_TextChanged(sender As Object, e As EventArgs) Handles txtCultivo.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtVariedad_TextChanged(sender As Object, e As EventArgs) Handles txtVariedad.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtEmpaque_TextChanged(sender As Object, e As EventArgs) Handles txtEmpaque.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtCodigoPallet_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoPallet.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtFecha_TextChanged(sender As Object, e As EventArgs) Handles txtFecha.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtIdCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIdCliente.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        actualizarFiltro()
    End Sub

    Private Sub dgvCabeceraPallets_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCabeceraPallets.CellClick
        If radEdicionMultiple.Checked Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = True Then
                    dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = False
                    dgvCabeceraPallets.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.BackColor
                    dgvCabeceraPallets.CurrentCell = Nothing
                    filasSeleccionadas = filasSeleccionadas - 1
                ElseIf dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = False Then
                    dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = True
                    dgvCabeceraPallets.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.SelectionBackColor
                    'modificacion a pedido de madeleine
                    detalleManual(dgvCabeceraPallets.Rows(e.RowIndex).Cells(1).Value.ToString, dgvCabeceraPallets.Rows(e.RowIndex).Cells(3).Value.ToString)
                    'fin modificacion
                    filasSeleccionadas = filasSeleccionadas + 1
                End If
            End If
        ElseIf radEdicionIndependiente.Checked Then
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                If dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = True Then
                    dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = False
                    dgvCabeceraPallets.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.BackColor
                    dgvCabeceraPallets.CurrentCell = Nothing
                    filasSeleccionadas = 0
                ElseIf dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = False Then
                    For Each f As DataGridViewRow In dgvCabeceraPallets.Rows
                        f.Cells(0).Value = False
                        dgvCabeceraPallets.Rows(f.Index).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.BackColor
                    Next
                    dgvCabeceraPallets.Rows(e.RowIndex).Cells(0).Value = True
                    dgvCabeceraPallets.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.SelectionBackColor
                    cargarDgvDetallePallet(dgvCabeceraPallets.Rows(e.RowIndex).Cells(1).Value.ToString)
                    filasSeleccionadas = 1
                End If
            End If
        End If
        lblSeleccionados.Text = "Seleccionadas: " + filasSeleccionadas.ToString
    End Sub

    Private Sub cargarDgvDetallePallet(idRegistroPallet As String)
        dgvDetallePallets.Columns.Clear()
        dgvDetallePallets.DataSource = Nothing
        dgvDetallePallets.DataSource = buscarDetallePallet(idRegistroPallet)
        Dim dgvColumnCheck As DataGridViewCheckBoxColumn
        dgvColumnCheck = New DataGridViewCheckBoxColumn()
        dgvColumnCheck.Name = "CheckEditar"
        dgvColumnCheck.HeaderText = "Editar"
        dgvDetallePallets.Columns.Insert(0, dgvColumnCheck)
        corregirCeldas(dgvDetallePallets)
        dgvDetallePallets.AutoResizeColumns()
        dgvDetallePallets.AutoResizeRows()
        'dgvDetallePallets.Columns(1).Visible = False
    End Sub

    Private Sub cbxTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodos.CheckedChanged
        For Each f As DataGridViewRow In dgvCabeceraPallets.Rows
            If Not cbxTodos.Checked Then
                f.Cells(0).Value = False
                dgvCabeceraPallets.Rows(f.Index).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.BackColor
                dgvCabeceraPallets.CurrentCell = Nothing
            Else
                f.Cells(0).Value = True
                dgvCabeceraPallets.Rows(f.Index).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.SelectionBackColor
            End If
        Next
        If Not cbxTodos.Checked Then
            filasSeleccionadas = 0
        Else
            filasSeleccionadas = bsCabeceraPallets.Count
        End If
        lblSeleccionados.Text = "Seleccionados: " + filasSeleccionadas.ToString
    End Sub

    Private Sub radEdicionIndependiente_CheckedChanged(sender As Object, e As EventArgs) Handles radEdicionIndependiente.CheckedChanged
        If radEdicionIndependiente.Checked = True Then
            'dgvDetallePallets.Enabled = True
            dgvDetallePallets.Columns.Clear()
            'dgvDetallePallets.Visible = True
            For Each f As DataGridViewRow In dgvCabeceraPallets.Rows
                f.Cells(0).Value = False
                dgvCabeceraPallets.Rows(f.Index).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.BackColor
            Next
            cbxCliente.Enabled = False
            cbxCliente.Checked = False
            cbxTodos.Checked = False
            cbxTodos.Enabled = False
            filasSeleccionadas = 0
        End If
    End Sub

    Private Sub radEdicionMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles radEdicionMultiple.CheckedChanged
        If radEdicionMultiple.Checked Then
            'dgvDetallePallets.Enabled = False
            dgvDetallePallets.DataSource = Nothing
            dgvDetallePallets.Columns.Clear()
            Dim dgvColumnCheck As DataGridViewCheckBoxColumn
            dgvColumnCheck = New DataGridViewCheckBoxColumn()
            dgvColumnCheck.Name = "CheckEditar"
            dgvColumnCheck.HeaderText = "Editar"
            dgvDetallePallets.Columns.Insert(0, dgvColumnCheck)
            dgvDetallePallets.Columns.Add("idRegistroPallet", "Id")
            dgvDetallePallets.Columns.Add("NroPlan", "Nro Pallet")
            dgvDetallePallets.Columns(0).Visible = False
            'dgvDetallePallets.Visible = False
            For Each f As DataGridViewRow In dgvCabeceraPallets.Rows
                f.Cells(0).Value = False
                dgvCabeceraPallets.Rows(f.Index).DefaultCellStyle.BackColor = dgvCabeceraPallets.DefaultCellStyle.BackColor
            Next
            cbxCliente.Enabled = True
            cbxTodos.Enabled = True
            filasSeleccionadas = 0
        End If
    End Sub

    Private Sub dgvDetallePallets_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetallePallets.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If radEdicionMultiple.Checked Then
                'dgvDetallePallets.Rows.Clear()
                'dgvDetallePallets.DataSource = Nothing
                detalleManual(dgvDetallePallets.Rows(e.RowIndex).Cells(1).Value.ToString, "")
            Else
                If dgvDetallePallets.Rows(e.RowIndex).Cells(0).Value = True Then
                    dgvDetallePallets.Rows(e.RowIndex).Cells(0).Value = False
                    dgvDetallePallets.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvDetallePallets.DefaultCellStyle.BackColor
                    dgvDetallePallets.CurrentCell = Nothing
                ElseIf dgvDetallePallets.Rows(e.RowIndex).Cells(0).Value = False Then
                    dgvDetallePallets.Rows(e.RowIndex).Cells(0).Value = True
                    dgvDetallePallets.Rows(e.RowIndex).DefaultCellStyle.BackColor = dgvDetallePallets.DefaultCellStyle.SelectionBackColor

                End If
            End If
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If cboCliente.Items.Count = 0 Then
            llenarCombo(cboCliente, tablasParaCombos.Tables(1))
            llenarCombo(cboEtiqueta, tablasParaCombos.Tables(2))
            llenarCombo(cboCalibre, tablasParaCombos.Tables(3))
        End If
        tlpEdicion.Enabled = True
        tlpEdicion.Visible = True
    End Sub

    Private Sub cbxCliente_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCliente.CheckedChanged
        If cbxCliente.Checked Then
            cboCliente.Enabled = True
        Else
            cboCliente.Enabled = False
        End If

    End Sub

    Private Sub cbxEtiqueta_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEtiqueta.CheckedChanged
        If cbxEtiqueta.Checked Then
            cboEtiqueta.Enabled = True
        Else
            cboEtiqueta.Enabled = False
        End If
    End Sub

    Private Sub cbxCalibre_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCalibre.CheckedChanged
        If cbxCalibre.Checked Then
            cboCalibre.Enabled = True
        Else
            cboCalibre.Enabled = False
        End If
    End Sub

    Private Sub cbxCliente_EnabledChanged(sender As Object, e As EventArgs) Handles cbxCliente.EnabledChanged
        If cbxCliente.Enabled And cbxCliente.Checked Then
            cboCliente.Enabled = True
        Else
            cboCliente.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cbxCliente.Checked = False
        cbxEtiqueta.Checked = False
        cbxCalibre.Checked = False
        tlpEdicion.Enabled = False
        tlpEdicion.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If dgvDetallePallets.RowCount = 0 Then
            MessageBox.Show("Debe agregar regitros al panel de edicion.")
            Exit Sub
        ElseIf Not cbxCliente.Checked And Not cbxEtiqueta.Checked And Not cbxCalibre.Checked And Not cbxNroPlan.Checked Then
            MessageBox.Show("Debe seleccionar al menos un nuevo valor de edicion (Cliente, etiqueta o calibre).")
            Exit Sub
        End If
        Dim idRegistroPallet As String = ""
        Dim item As String = ""
        Dim idCliente As String = ""
        Dim idEtiqueta As String = ""
        Dim idCalibre As String = ""
        Dim NroPlan As String = ""
        'SI ES SELECCION INDEPENDIENTE
        'If dgvDetallePallets.Enabled = True Then
        If radEdicionIndependiente.Checked Then
            idRegistroPallet = dgvDetallePallets.Rows(0).Cells(1).Value.ToString
            For Each f As DataGridViewRow In dgvDetallePallets.Rows
                If f.Cells(0).Value = True Then
                    item = f.Cells(2).Value.ToString + "," + item
                End If
            Next
            If item = "" Then
                MessageBox.Show("Debe seleccionar al menos un item para editar.")
                Exit Sub
            End If
            idCliente = ""
            If cbxEtiqueta.Checked Then
                idEtiqueta = cboEtiqueta.SelectedValue
            Else
                idEtiqueta = ""
            End If
            If cbxCalibre.Checked Then
                idCalibre = cboCalibre.SelectedValue
            Else
                idCalibre = ""
            End If
            If cbxNroPlan.Checked Then
                NroPlan = txtNro.Text
            Else
                NroPlan = ""
            End If
            'SI ES SELECCION MULTIPLE
            'ElseIf dgvDetallePallets.Enabled = False Then
        ElseIf radEdicionMultiple.Checked Then
            For Each f As DataGridViewRow In dgvDetallePallets.Rows
                'If f.Cells(0).Value = True Then
                idRegistroPallet = f.Cells(1).Value.ToString + "," + idRegistroPallet
                'End If
            Next
            item = ""
            If cbxCliente.Checked Then
                idCliente = cboCliente.SelectedValue
            Else
                idCliente = ""
            End If
            If cbxEtiqueta.Checked Then
                idEtiqueta = cboEtiqueta.SelectedValue
            Else
                idEtiqueta = ""
            End If
            If cbxCalibre.Checked Then
                idCalibre = cboCalibre.SelectedValue
            Else
                idCalibre = ""
            End If
            If cbxNroPlan.Checked Then
                NroPlan = txtNro.Text
            Else
                NroPlan = ""
            End If
        End If
        If actualizarDatosPallets(idRegistroPallet, item, idCliente, idEtiqueta, idCalibre, NroPlan) Then
            cbxCliente.Checked = False
            cbxEtiqueta.Checked = False
            cbxCalibre.Checked = False
            txtNro.Text = ""
            tlpEdicion.Enabled = False
            tlpEdicion.Visible = False
            txtCampana.Text = ""
            txtCodigoPallet.Text = ""
            txtFecha.Text = ""
            txtCultivo.Text = ""
            txtVariedad.Text = ""
            txtEmpaque.Text = ""
            txtIdCliente.Text = ""
            txtCliente.Text = ""
            obtenerMultitablaParaCombos()
            If radEdicionMultiple.Checked Then
                cargarDgvCabeceraPallets()
            End If
            cbxTodos.Checked = False
            dgvDetallePallets.Rows.Clear()
            dgvDetallePallets.DataSource = Nothing
            'cargarDgvDetallePallet(idRegistroPallet)
            MessageBox.Show("Registros guardados correctamente.")
        Else
            MessageBox.Show("Error al intentar guardar los cambios.")
        End If
    End Sub

    Public Shared Function actualizarDatosPallets(idRegistroPallet As String, item As String, idCliente As String, idEtiqueta As String, idCalibre As String, NroPlan As String) As Boolean
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdRegistroPallet", idRegistroPallet)
            p.Add("@Items", item)
            p.Add("@IdCliente", idCliente)
            p.Add("@IdEtiqueta", idEtiqueta)
            p.Add("@IdCalibre", idCalibre)
            p.Add("@NroPlan", NroPlan)
            Return doItBaby("sp_Dg_Produccion_Movimientos_ActualizarDatosPallets", p, TipoQuery.NonQuery)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        'Dim parametros(4) As SqlParameter
        'parametros(0) = New SqlClient.SqlParameter("@IdRegistroPallet", SqlDbType.VarChar)
        'parametros(0).Value = CType(idRegistroPallet, String)
        'parametros(1) = New SqlClient.SqlParameter("@Items", SqlDbType.VarChar)
        'parametros(1).Value = CType(item, String)
        'parametros(2) = New SqlClient.SqlParameter("@IdCliente", SqlDbType.VarChar)
        'parametros(2).Value = CType(idCliente, String)
        'parametros(3) = New SqlClient.SqlParameter("@IdEtiqueta", SqlDbType.VarChar)
        'parametros(3).Value = CType(idEtiqueta, String)
        'parametros(4) = New SqlClient.SqlParameter("@IdCalibre", SqlDbType.VarChar)
        'parametros(4).Value = CType(idCalibre, String)
        'Try
        '    EjecutarProcedure(credenciales("BLNomCon"),
        '                                  "sp_Dg_Produccion_Movimientos_ActualizarDatosPallets",
        '                                  parametros,
        '                                  Datos.TipoProcesamiento.NonQuery,
        '                                  False)
        '    Return True
        'Catch
        '    Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
        'End Try
        'Return Nothing
    End Function

    Private Sub detalleManual(idRegistroPallet As String, NroPlan As String)
        'Dim fila As DataGridViewRow
        'fila = New DataGridViewRow()
        'fila.Cells.Add()
        'dgvDetallePallets.Columns.Add("idRegistroPallet", "Id")
        'dgvDetallePallets.Columns.Add("NroPlan", "Nro Pallet")
        Dim existe As Boolean = False
        If NroPlan <> "" Then
            For Each f As DataGridViewRow In dgvDetallePallets.Rows
                If idRegistroPallet = f.Cells(1).Value Then
                    existe = True
                    Exit For
                End If
            Next
            If Not existe Then
                dgvDetallePallets.Rows.Add(False, idRegistroPallet, NroPlan)
                dgvDetallePallets.AutoResizeColumns()
                dgvDetallePallets.AutoResizeRows()
            End If
        Else
            For Each f As DataGridViewRow In dgvDetallePallets.Rows
                If idRegistroPallet = f.Cells(1).Value Then
                    dgvDetallePallets.Rows.RemoveAt(f.Cells(0).RowIndex)

                End If
            Next
        End If


    End Sub

    Private Sub cbxNroPlan_CheckStateChanged(sender As Object, e As EventArgs) Handles cbxNroPlan.CheckStateChanged
        If cbxNroPlan.Checked Then
            txtNro.Enabled = True
        Else
            txtNro.Enabled = False
        End If
    End Sub

End Class