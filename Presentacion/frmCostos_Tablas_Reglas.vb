Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmCostos_Tablas_Reglas
    Public filaParaInsertar() As String
    Public filaParaEliminar() As String
    Public filaParaEditar() As String
    Public tablasParaCombos As DataSet
    Public filaObjetivo As Integer

    Private Sub frmCostos_Tablas_Reglas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerMultitablaParaCombos()
        llenarCombo(cboTipoCosto_Buscar, tablasParaCombos.Tables(0), 1)
        llenarCombo(cboCultivo_Buscar, tablasParaCombos.Tables(1), 1)
        limpiarFila(filaParaInsertar)
        limpiarFila(filaParaEditar)
        limpiarFila(filaParaEliminar)
        filaObjetivo = 0
        dgvResultado.AllowUserToResizeRows = False
        tlpPrincipal.Visible = True
    End Sub

    Private Sub obtenerMultitablaParaCombos()
        Dim aux As DataSet = New DataSet
        aux = doItBaby("sp_Dg_Costos_Reglas_DataParaCombos", Nothing, TipoQuery.DataSet)
        tablasParaCombos = New DataSet
        tablasParaCombos.Tables.Add(aux.Tables(0).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(1).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(2).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(3).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(4).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(5).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(6).Copy)
        tablasParaCombos.Tables.Add(aux.Tables(7).Copy)
    End Sub

    'Public Shared Function execSp_Dg_Costos_Reglas_DataParaCombos()
    '     Dim Resultado As DataSet
    '    Try
    '        Resultado = EjecutarProcedureMultiResultado(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_DataParaCombos",
    '                                      Nothing,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '    End Try
    '    Return True
    'End Function
    Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, col As Integer)
        If comboBox.Name = "cboCGI" Then
            comboBox.Items.Add("C")
            comboBox.Items.Add("G")
            comboBox.Items.Add("I")
        ElseIf comboBox.Name = "cboTipo" Then
            comboBox.Items.Add("D")
            comboBox.Items.Add("I")
        Else
            Dim i As Integer = 0
            For Each fila As DataRow In dataTable.Rows
                comboBox.Items.Add(String.Concat(dataTable.Rows(i).Item(0).ToString, " | ", dataTable.Rows(i).Item(1).ToString))
                i = i + 1
            Next
        End If
    End Sub

    'Private Async Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
    '    barProgreso.MarqueeAnimationSpeed = 1
    '    barProgreso.Style = ProgressBarStyle.Marquee
    '    barProgreso.Value = 0
    '    Await Task.Run(Sub() gestionarBarraAsync(barProgreso))
    '    Await Task.Run(Sub() cambiarEtiquetaAsync(lblResultado))
    '    buscarAsync(extraerIdDeCampo(cboTipoCosto_Buscar.Text), extraerIdDeCampo(cboCultivo_Buscar.Text))
    'End Sub

    Private Async Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = buscarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function buscarAsync() As Task(Of DataTable)
        Try
            Dim aux As New DataTable
            Dim p As New Dictionary(Of String, Object)
            p.Add("@TipoCosto", extraerIdDeCampo(cboTipoCosto_Buscar.Text))
            p.Add("@CodCultivo", extraerIdDeCampo(cboCultivo_Buscar.Text))
            aux = Await Task.Run(Function() doItBaby("sp_Dg_Costos_Reglas_Buscar", p, TipoQuery.DataTable))
            Return aux
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    'Public Shared Function execsp_Dg_Costos_Reglas_Buscar(tipoCosto As String, codCultivo As String)
    '    Dim parametros(1) As SqlParameter
    '    parametros(0) = New SqlClient.SqlParameter("@TipoCosto", SqlDbType.VarChar)
    '    parametros(0).Value = CType(tipoCosto, String)
    '    parametros(1) = New SqlClient.SqlParameter("@CodCultivo", SqlDbType.VarChar)
    '    parametros(1).Value = CType(codCultivo, String)
    '    Dim Resultado As DataTable
    '    Try
    '        Resultado = EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_Buscar",
    '                                      parametros,
    '                                      3,
    '                                      False)
    '        Return Resultado
    '    Catch
    '    End Try
    '    Return True
    'End Function

    Public Function extraerIdDeCampo(campo As String) As String
        If campo.Length > 0 Then
            Dim resultado As String = ""
            resultado = Trim(campo.Substring(0, InStr(campo, "|", CompareMethod.Text) - 1))
            Return resultado
        Else
            Return ""
        End If
    End Function

    'Private Async Sub buscarAsync(tipoCosto As String, codCultivo As String)
    '    'dgvResultado.DataSource = Nothing
    '    Dim dataTableTask As Task(Of DataTable)
    '    barProgreso.MarqueeAnimationSpeed = 1
    '    barProgreso.Style = ProgressBarStyle.Marquee
    '    barProgreso.Value = 0
    '    Await Task.Run(Sub() gestionarBarraAsync(barProgreso))
    '    Await Task.Run(Sub() cambiarEtiquetaAsync(lblResultado))
    '    dataTableTask = preQueryBuscar(tipoCosto, codCultivo)
    '    dgvResultado.DataSource = Await dataTableTask
    '    dgvResultado.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    '    dgvResultado.AllowUserToAddRows = False
    '    dgvResultado.RowHeadersVisible = False
    '    barProgreso.MarqueeAnimationSpeed = 0
    '    barProgreso.Style = ProgressBarStyle.Continuous
    '    resetearEtiqueta(lblResultado)
    '    Dim filas As Integer = dgvResultado.RowCount
    '    lblResultado.Text = "Resultado: " + filas.ToString
    '    corregirCeldas(dgvResultado)
    '    dgvResultado.AutoResizeColumns()
    '    dgvResultado.AutoResizeRows()
    'End Sub

    'Private Async Function preQueryBuscar(tipoCosto As String, CodCultivo As String) As Task(Of DataTable)
    '    Dim auxDataTable As New DataTable
    '    auxDataTable = Await Task.Run(Function() execsp_Dg_Costos_Reglas_Buscar(tipoCosto, codCultivo))
    '    Return auxDataTable
    'End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If filaParaEditar(0) = String.Empty And filaParaEliminar(0) = String.Empty Then
            If cboTipoCosto_Editar.Items.Count < 1 Then
                llenarCombo(cboTipoCosto_Editar, tablasParaCombos.Tables(0), 1)
                llenarCombo(cboCultivo_Editar, tablasParaCombos.Tables(1), 1)
                llenarCombo(cboActividad, tablasParaCombos.Tables(2), 1)
                llenarCombo(cboDivision, tablasParaCombos.Tables(3), 1)
                llenarCombo(cboTipoCampana, tablasParaCombos.Tables(4), 1)
                llenarCombo(cboGrupo, tablasParaCombos.Tables(5), 1)
                llenarCombo(cboCCFijo, tablasParaCombos.Tables(6), 1)
                llenarCombo(cboCuenta, tablasParaCombos.Tables(7), 1)
                llenarCombo(cboCGI, Nothing, 1)
                llenarCombo(cboTipo, Nothing, 1)
            End If
            limpiarFila(filaParaInsertar)
            grpEditar.Enabled = True
        Else
            MessageBox.Show("Hay una fila seleccionada en modo edicion.")
        End If
    End Sub

    Private Async Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            validarSeleccion()
            llenarFila(filaParaInsertar, "Insertar")
            Dim guardadoOk As Boolean
            guardadoOk = Await preQueryGuardar(filaParaInsertar)
            If guardadoOk Then
                If Not filaParaEditar(0) = String.Empty Then
                    Await preQueryEliminar(filaParaEditar)
                    'CONSIDERAR MOVER LA SIGUIENTE LINEA AL SUB PREQUERIELIMINAR()
                    limpiarFila(filaParaEditar)
                    desbloquearFila()
                End If
            End If
            limpiarFila(filaParaInsertar)
            btnBuscar_Click(sender, e)
            grpEditar.Enabled = False
            MessageBox.Show("Registro guardado satisfactoriamente.")
        Catch
            MessageBox.Show("Error al intentar guardar registro.")
        End Try
    End Sub

    Private Sub validarSeleccion()
        If cboTipoCosto_Editar.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Tipo de Costo valido.")
            Exit Sub
        ElseIf cboCultivo_Editar.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Cultivo valido.")
            Exit Sub
        ElseIf cboActividad.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar una Actividad valida.")
            Exit Sub
        ElseIf cboDivision.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar una Division valida.")
            Exit Sub
        ElseIf cboCGI.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un CGI valido.")
            Exit Sub
        ElseIf cboTipo.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Tipo valido.")
            Exit Sub
        ElseIf cboTipoCampana.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Tipo Campaña valido.")
            Exit Sub
        ElseIf cboGrupo.Enabled And cboGrupo.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un Grupo valido.")
            Exit Sub
        ElseIf cboCCFijo.SelectedIndex < 0 Then
            MessageBox.Show("Error, Debe seleccionar un CCFijo valido.")
            Exit Sub
        End If
    End Sub

    Public Sub llenarFila(ByRef fila() As String, accion As String)
        fila = {"", "", "", "", "", "", "", "", "", ""}
        If accion = "Insertar" Then
            fila(0) = extraerIdDeCampo(cboTipoCosto_Editar.Text)
            fila(1) = extraerIdDeCampo(cboCultivo_Editar.Text)
            fila(2) = extraerIdDeCampo(cboActividad.Text)
            fila(3) = extraerIdDeCampo(cboDivision.Text)
            fila(4) = cboCGI.Text
            fila(5) = cboTipo.Text
            fila(6) = extraerIdDeCampo(cboTipoCampana.Text)
            If cboGrupo.Enabled Then
                fila(7) = extraerIdDeCampo(cboGrupo.Text)
            Else
                fila(7) = ""
            End If
            If cboCCFijo.Enabled Then
                fila(8) = extraerIdDeCampo(cboCCFijo.Text)
            Else
                fila(8) = ""
            End If
            If cboCuenta.Enabled Then
                fila(9) = extraerIdDeCampo(cboCuenta.Text)
            Else
                fila(9) = ""
            End If
        ElseIf accion = "Eliminar" Or accion = "Editar" Then
            fila(0) = dgvResultado.CurrentRow.Cells(0).Value
            fila(1) = dgvResultado.CurrentRow.Cells(2).Value
            fila(2) = dgvResultado.CurrentRow.Cells(4).Value
            fila(3) = dgvResultado.CurrentRow.Cells(6).Value
            fila(4) = dgvResultado.CurrentRow.Cells(8).Value
            fila(5) = dgvResultado.CurrentRow.Cells(9).Value
            fila(6) = dgvResultado.CurrentRow.Cells(10).Value
            fila(7) = dgvResultado.CurrentRow.Cells(12).Value
            fila(8) = dgvResultado.CurrentRow.Cells(14).Value
            fila(9) = dgvResultado.CurrentRow.Cells(16).Value
        End If
    End Sub

    Private Async Function preQueryGuardar(fila() As String) As Task(Of Boolean)
        Dim resultado As New Boolean
        Dim p As New Dictionary(Of String, Object)
        p.Add("@TipoCosto", fila(0))
        p.Add("@CodCultivo", fila(1))
        p.Add("@CodActividad", fila(2))
        p.Add("@Division", fila(3))
        p.Add("@CGI", fila(4))
        p.Add("@Tipo", fila(5))
        p.Add("@CodTipoCampana", fila(6))
        p.Add("@CodGrupo", fila(7))
        p.Add("@CCFijo", fila(8))
        p.Add("@CodCuenta", fila(9))
        'resultado = Await Task.Run(Function() execSp_Dg_Costos_Reglas_Insertar(fila))
        resultado = Await Task.Run(Function() doItBaby("sp_Dg_Costos_Reglas_Insertar", p, TipoQuery.NonQuery))
        Return resultado
    End Function

    'Public Shared Function execSp_Dg_Costos_Reglas_Insertar(arrayParametros() As String)
    '    Dim parametros(9) As SqlParameter
    '    Dim nombresParametros() As String = {"@TipoCosto", "@CodCultivo", "@CodActividad", "@Division", "@CGI", "@Tipo", "@CodTipoCampana", "@CodGrupo", "@CCFijo", "@CodCuenta"}
    '    Dim i As Integer = 0
    '    For Each p As String In arrayParametros
    '        parametros(i) = New SqlClient.SqlParameter(nombresParametros(i), SqlDbType.VarChar)
    '        parametros(i).Value = CType(arrayParametros(i), String)
    '        i = i + 1
    '    Next
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_Insertar",
    '                                      parametros,
    '                                      1,
    '                                      True)
    '        Return True
    '    Catch
    '        Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    Private Async Function preQueryEliminar(fila() As String) As Task(Of Boolean)
        Dim resultado As New Boolean
        Dim p As New Dictionary(Of String, Object)
        p.Add("@TipoCosto", fila(0))
        p.Add("@CodCultivo", fila(1))
        p.Add("@CodActividad", fila(2))
        p.Add("@Division", fila(3))
        p.Add("@CGI", fila(4))
        p.Add("@Tipo", fila(5))
        p.Add("@CodTipoCampana", fila(6))
        p.Add("@CodGrupo", fila(7))
        p.Add("@CCFijo", fila(8))
        p.Add("@CodCuenta", fila(9))
        'resultado = Await Task.Run(Function() execSp_Dg_Costos_Reglas_Eliminar(fila))
        resultado = Await Task.Run(Function() doItBaby("sp_Dg_Costos_Reglas_Eliminar", p, TipoQuery.NonQuery))
        Return resultado
    End Function

    'Public Shared Function execSp_Dg_Costos_Reglas_Eliminar(arrayParametros() As String)
    '    Dim parametros(9) As SqlParameter
    '    Dim nombresParametros() As String = {"@TipoCosto", "@CodCultivo", "@CodActividad", "@Division", "@CGI", "@Tipo", "@CodTipoCampana", "@CodGrupo", "@CCFijo", "@CodCuenta"}
    '    Dim i As Integer = 0
    '    For Each p As String In arrayParametros
    '        parametros(i) = New SqlClient.SqlParameter(nombresParametros(i), SqlDbType.VarChar)
    '        parametros(i).Value = CType(arrayParametros(i), String)
    '        i = i + 1
    '    Next
    '    Try
    '        EjecutarProcedure(credenciales("BLNomCon"),
    '                                      "sp_Dg_Costos_Reglas_Eliminar",
    '                                      parametros,
    '                                      1,
    '                                      True)
    '        Return True
    '    Catch
    '        Return False 'AQUI PODRIA HABER ERROR POR INCOMPATIBILIDAD CON EL TIPO DE DATO DEL RECEPTOR
    '    End Try
    '    Return True
    'End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        grpEditar.Enabled = False
        limpiarFila(filaParaInsertar)
        limpiarFila(filaParaEditar)
        limpiarFila(filaParaEliminar)
        desbloquearFila()
    End Sub

    Private Async Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvResultado.SelectedRows.Count = 1 Then
            bloquearFila()
            Dim eleccion As DialogResult = MessageBox.Show("Esta seguro de eliminar esta fila?", "Eliminar Fila", MessageBoxButtons.YesNo)
            If eleccion = Windows.Forms.DialogResult.Yes Then
                llenarFila(filaParaEliminar, "Eliminar")
                Dim eliminadoOk As Boolean
                eliminadoOk = Await preQueryEliminar(filaParaEliminar)
                limpiarFila(filaParaEliminar)
                'buscarAsync(extraerIdDeCampo(cboTipoCosto_Buscar.Text), extraerIdDeCampo(cboCultivo_Buscar.Text))
                btnBuscar_Click(sender, e)
                If eliminadoOk Then
                    MessageBox.Show("Fila eliminada satisfactoriamente.")
                Else
                    MessageBox.Show("Error al intentar borrar fila seleccionada.")
                End If
            End If
            desbloquearFila()
        Else
            MessageBox.Show("Debe seleccionar UNA fila para eliminar")
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvResultado.SelectedRows.Count = 1 Then
            If cboTipoCosto_Editar.Items.Count < 1 Then
                llenarCombo(cboTipoCosto_Editar, tablasParaCombos.Tables(0), 1)
                llenarCombo(cboCultivo_Editar, tablasParaCombos.Tables(1), 1)
                llenarCombo(cboActividad, tablasParaCombos.Tables(2), 1)
                llenarCombo(cboDivision, tablasParaCombos.Tables(3), 1)
                llenarCombo(cboTipoCampana, tablasParaCombos.Tables(4), 1)
                llenarCombo(cboGrupo, tablasParaCombos.Tables(5), 1)
                llenarCombo(cboCCFijo, tablasParaCombos.Tables(6), 1)
                llenarCombo(cboCuenta, tablasParaCombos.Tables(7), 1)
                llenarCombo(cboCGI, Nothing, 1)
                llenarCombo(cboTipo, Nothing, 1)
            End If
            bloquearFila()
            llenarFila(filaParaEditar, "Editar")
            pasarDeFilaACombo()
            grpEditar.Enabled = True
        Else
            MessageBox.Show("Debe seleccionar una fila para editar.")
        End If
    End Sub

    Private Sub pasarDeFilaACombo()
        cboTipoCosto_Editar.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(0).Value, " | ", dgvResultado.CurrentRow.Cells.Item(1).Value)
        cboCultivo_Editar.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(2).Value, " | ", dgvResultado.CurrentRow.Cells.Item(3).Value)
        cboActividad.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(4).Value, " | ", dgvResultado.CurrentRow.Cells.Item(5).Value)
        cboDivision.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(6).Value, " | ", dgvResultado.CurrentRow.Cells.Item(7).Value)
        cboCGI.Text = dgvResultado.CurrentRow.Cells.Item(8).Value
        cboTipo.Text = dgvResultado.CurrentRow.Cells.Item(9).Value
        cboTipoCampana.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(10).Value, " | ", dgvResultado.CurrentRow.Cells.Item(11).Value)
        If dgvResultado.CurrentRow.Cells.Item(12).Value.ToString = "" Then
            cboGrupo.SelectedIndex = -1
        Else
            cboGrupo.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(12).Value, " | ", dgvResultado.CurrentRow.Cells.Item(13).Value)
        End If
        If dgvResultado.CurrentRow.Cells.Item(14).Value.ToString = "" Then
            cboCCFijo.SelectedIndex = -1
        Else
            cboCCFijo.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(14).Value, " | ", dgvResultado.CurrentRow.Cells.Item(15).Value)
        End If
        If Trim(dgvResultado.CurrentRow.Cells.Item(16).Value.ToString) = "" Then
            cboCuenta.SelectedIndex = -1
        Else
            cboCuenta.Text = String.Concat(dgvResultado.CurrentRow.Cells.Item(16).Value, " | ", dgvResultado.CurrentRow.Cells.Item(17).Value)
        End If

    End Sub

    Private Sub dgvResultado_SelectionChanged(sender As Object, e As EventArgs) Handles dgvResultado.SelectionChanged
        If Not filaParaEditar(0) = String.Empty Or Not filaParaEliminar(0) = String.Empty Then
            dgvResultado.CurrentRow.Selected = False
            dgvResultado.Rows(filaObjetivo).Selected = True
        End If
    End Sub

    Private Sub bloquearFila()
        filaObjetivo = dgvResultado.CurrentRow.Index
        dgvResultado.DefaultCellStyle.SelectionBackColor = rojoAmarath
        dgvResultado.DefaultCellStyle.SelectionForeColor = rosaBlanco_
    End Sub

    Private Sub desbloquearFila()
        filaObjetivo = 0
        dgvResultado.DefaultCellStyle.SelectionBackColor = verderCian_
        dgvResultado.DefaultCellStyle.SelectionForeColor = negroMate__
    End Sub

    Private Sub cboTipoCosto_Editar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCosto_Editar.SelectedIndexChanged
        If InStr(cboTipoCosto_Editar.Text, "Insumos", CompareMethod.Text) > 0 Then
            lblGrupo.Visible = True
            cboGrupo.Visible = True
            cboGrupo.Enabled = True
            Exit Sub
        End If
        If InStr(cboTipoCosto_Editar.Text, "Insumos", CompareMethod.Text) = 0 Then
            lblGrupo.Visible = False
            cboGrupo.Visible = False
            cboGrupo.Enabled = False
        End If
        If InStr(cboTipoCosto_Editar.Text, "Gastos", CompareMethod.Text) > 0 Or InStr(cboTipoCosto_Editar.Text, "Otros", CompareMethod.Text) > 0 Then
            lblCuenta.Visible = True
            cboCuenta.Visible = True
            cboCuenta.Enabled = True
            Exit Sub
        End If
        If InStr(cboTipoCosto_Editar.Text, "Gastos", CompareMethod.Text) = 0 Or InStr(cboTipoCosto_Editar.Text, "Otros", CompareMethod.Text) = 0 Then
            lblCuenta.Visible = False
            cboCuenta.Visible = False
            cboCuenta.Enabled = False
        End If
    End Sub

    Private Sub limpiarFila(ByRef fila() As String)
        fila = {"", "", "", "", "", "", "", "", ""}
        Dim i As Integer = 0
        For Each e As String In fila
            fila(i) = String.Empty
            i = i + 1
        Next
    End Sub
End Class