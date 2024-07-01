Imports Logica.Utiles
Imports Datos.Conexion
Imports Entidades.Temporales
Imports Logica.Funciones

Public Class frmPacking_Movimientos_GenerarCodigosPacking
    Dim dsDataParaCombos As DataSet
    Dim bsResultado As New BindingSource()
    Dim dtPersonasSeleccionadas As DataTable
    Dim dtDataPersonas As DataTable
    Dim dvResultado As DataView 'New DataView(tablaParaDgv)
    Dim vieneDeDgv As Boolean = False

    Private Sub frmPacking_Movimientos_GenerarCodigosPacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerDataParaCombos()
        cargarCombo(cboLaborPacking, dsDataParaCombos.Tables(0))
        cargarCombo(cboLinea, dsDataParaCombos.Tables(1))
        listarPersonas()
        listarPersonasSeleccionadas()
        'listarTrabajadores()
        tlpPrincipal.Visible = True
    End Sub

    Public Sub obtenerDataParaCombos()
        dsDataParaCombos = New DataSet
        dsDataParaCombos.Tables.Add(doItBaby("sp_ObtenerLaboresPacking", Nothing, TipoQuery.DataTable))
        dsDataParaCombos.Tables.Add(doItBaby("sp_ObtenerLineasPacking", Nothing, TipoQuery.DataTable))
    End Sub

    Private Sub listarPersonas()
        dtDataPersonas = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_ListarPersonas", Nothing, TipoQuery.DataTable)
        corregirTabla(dtDataPersonas)
        dvResultado = New DataView(dtDataPersonas)
        bsResultado.DataSource = dvResultado
        dgvPersonas.DataSource = bsResultado
        formatearDataGridView(dgvPersonas, True)
        'dgvPersonas.Columns(2).Visible = False
        'dgvPersonas.Columns(3).Visible = False
        lblDin_Resultado.Text = "Coincidencias: " + dgvPersonas.RowCount.ToString
    End Sub

    Private Sub listarPersonasSeleccionadas()
        dtPersonasSeleccionadas = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_ListarPersonasSeleccionadas", Nothing, TipoQuery.DataTable)
        corregirTabla(dtPersonasSeleccionadas)
        dgvResultado.DataSource = dtPersonasSeleccionadas
        formatearDataGridView(dgvResultado, True)
      actualizarSumatorias()
    End Sub

    Public Sub actualizarSumatorias()
        If dgvResultado.RowCount > 0 Then
            lblDin_Resultado2.Text = "Personas: " + dgvResultado.RowCount.ToString +
                " Codigos Hoy: " + dtPersonasSeleccionadas.Compute("Sum(D0CodigosHoy)", "T_Dni <> ''").ToString +
                " Codigos Requeridos: " + dtPersonasSeleccionadas.Compute("Sum(D0CodigosNuevos)", "T_Dni <> ''").ToString
        End If
    End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
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

    Private Async Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim disponible As String = String.Empty
        disponible = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigos_ValidarDisponibilidad", Nothing, TipoQuery.Scalar)
        If disponible = "Si" Then
            Try
                Dim nOperaciones As Integer = 0, totalCodigos As Integer = 0
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If fila.Cells(7).Value <> 0 Then
                        nOperaciones += 1
                        totalCodigos = totalCodigos + fila.Cells(7).Value
                    End If
                Next
                CheckForIllegalCrossThreadCalls = False
                barProgreso.Value = 0
                barProgreso.Maximum = nOperaciones
                Dim p As New Dictionary(Of String, Object)
                Dim codigosReciclables As Integer = 0
                Dim cantidadCodigosAGenerar As Integer = 0
                Dim cantidadCodigosALiberar As Integer = 0
                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If fila.Cells(7).Value <> 0 Then
                        cantidadCodigosAGenerar = CType(fila.Cells(7).Value, Integer)
                        p.Add("@Dni", fila.Cells(0).Value.ToString)
                        p.Add("@IdLaborPacking", fila.Cells(3).Value.ToString)
                        p.Add("@IdLinea", fila.Cells(4).Value.ToString)
                        p.Add("@TipoResultado", "N")
                        codigosReciclables = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_ConsultarCodigosLibres", p, TipoQuery.Scalar)
                        If codigosReciclables > 0 Then
                            If cantidadCodigosAGenerar >= codigosReciclables Then
                                cantidadCodigosAGenerar = cantidadCodigosAGenerar - codigosReciclables
                                cantidadCodigosALiberar = codigosReciclables
                            ElseIf cantidadCodigosAGenerar < codigosReciclables Then
                                cantidadCodigosALiberar = cantidadCodigosAGenerar
                                cantidadCodigosAGenerar = 0
                            End If
                            p.Add("@Cantidad", cantidadCodigosALiberar)
                            doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_LiberarCodigosReciclables", p, TipoQuery.NonQuery)
                        End If

                        'p = New Dictionary(Of String, Object)
                        p.Clear()
                        p.Add("@IdTareo", "SIN TAREO") ' fila.Cells(0).Value.ToString)
                        p.Add("@Dni", fila.Cells(0).Value.ToString)
                        p.Add("@IdLaborPacking", fila.Cells(3).Value.ToString)
                        p.Add("@IdLinea", fila.Cells(4).Value.ToString)
                        'p.Add("@Cantidad", fila.Cells(8).Value.ToString)
                        p.Add("@Cantidad", cantidadCodigosAGenerar)
                        If Not doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_GenerarCodigos", p, TipoQuery.NonQuery) Then
                            MessageBox.Show("Ocurrió un error al intentar generar los codigos.")
                        End If
                        p.Clear()
                        Await Task.Run(Sub() barProgreso.Value = barProgreso.Value + 1)
                        'barProgreso.Value = barProgreso.Value + 1
                        'Await Task.Delay(1)
                    End If
                Next
                doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigos_LiberarDisponibilidad", Nothing, TipoQuery.NonQuery)
                MessageBox.Show(totalCodigos.ToString + " Codigos Generados Correctamente.")
                listarPersonasSeleccionadas()
                actualizarSumatorias()
                Dim VenActual As New frmPacking_Movimientos_GenerarCodigosPacking_ListaCodigosExportables
                'VenActual.Parent = Me
                VenActual.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                CheckForIllegalCrossThreadCalls = True
                'listarTrabajadores()
            End Try
        Else
            MessageBox.Show("Ya hay alguien generando codigos en este momento, vuelva pronto.")
        End If
    End Sub

    Private Sub frmPacking_Movimientos_GenerarCodigosPacking_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigos_LiberarDisponibilidad", Nothing, TipoQuery.NonQuery)
    End Sub

    Private Sub agregarDniParaCodigo(dni As String, filaRaiz As DataGridViewRow)
        Try
            Dim disponible As String = String.Empty
            disponible = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigos_ValidarDisponibilidad", Nothing, TipoQuery.Scalar)
            If disponible = "Si" Then
                'If disponible = "Si" Then

                'If dgvResultado.SelectedRows.Count <= 0 And usuarioActual = "JMERA" Then
                If filaRaiz Is Nothing And (usuarioActual = "JMERA" Or usuarioActual = "RENDIMIENTOS") Then
                    Dim r As DialogResult
                    r = MessageBox.Show("El trabajador no existe. Desea generar los codigos de todas formas?", "Atencion!", MessageBoxButtons.YesNo)
                    If r = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                ElseIf filaRaiz Is Nothing And usuarioActual <> "JMERA" Then
                    MessageBox.Show("Usted no tiene permitido generar codigos a personal desconocido.")
                    Exit Sub
                End If
                If cboLaborPacking.SelectedIndex < 0 Then
                    MessageBox.Show("Debede selecionar una labor valida")
                ElseIf cboLinea.SelectedIndex < 0 Then
                    MessageBox.Show("Debede selecionar una linea valida")
                ElseIf txtCantidad.Text = "" Then
                    MessageBox.Show("Debede solicitar una cantidad de codigos valida")
                ElseIf CType(txtCantidad.Text, Integer) > 2000 Then
                    MessageBox.Show("La cantidad de codigos solicitada excede el limite permitido por operacion <Máximo 2000>")
                Else

                    Dim codigo As String '= IIf(filaRaiz Is Nothing, "S/C", filaRaiz.Cells(1).Value.ToString)
                    If filaRaiz Is Nothing Then
                        codigo = "S/C"
                    Else
                        codigo = filaRaiz.Cells(1).Value.ToString
                    End If
                    Dim trabajador As String '= IIf(filaRaiz Is Nothing, "DNI DESCONOCIDO", filaRaiz.Cells(4).Value.ToString)
                    If filaRaiz Is Nothing Then
                        trabajador = "DNI DESCONOCIDO"
                    Else
                        trabajador = filaRaiz.Cells(4).Value.ToString
                    End If
                    Dim labor As String = cboLaborPacking.SelectedValue
                    Dim linea As String = cboLinea.SelectedValue
                    Dim cantidad As Integer = CType(txtCantidad.Text, Integer)
                    Dim indice As Integer = buscarIndiceTrabajador(dni, labor, linea)

                    If indice >= 0 Then
                        dtPersonasSeleccionadas.Rows(indice).Item(7) = CType(dtPersonasSeleccionadas.Rows(indice).Item(7), Integer) + CType(cantidad, Integer)
                    Else
                        Dim nuevaFila As DataRow = dtPersonasSeleccionadas.NewRow()
                        nuevaFila.Item(0) = dni
                        nuevaFila.Item(1) = codigo
                        nuevaFila.Item(2) = trabajador
                        nuevaFila.Item(3) = labor
                        nuevaFila.Item(4) = linea
                        nuevaFila.Item(5) = 0
                        nuevaFila.Item(6) = 0
                        nuevaFila.Item(7) = cantidad
                        dtPersonasSeleccionadas.Rows.Add(nuevaFila)
                        formatearDataGridView(dgvResultado)
                    End If
                End If
                'End If

                'If dgvResultado.SelectedRows.Count <= 0 Then
                '    MessageBox.Show("No hay filas seleccionadas.")
                'ElseIf cboLaborPacking.SelectedIndex < 0 Then
                '    MessageBox.Show("Debede selecionar una labor valida")
                'ElseIf cboLinea.SelectedIndex < 0 Then
                '    MessageBox.Show("Debede selecionar una linea valida")
                'ElseIf txtCantidad.Text = "" Then
                '    MessageBox.Show("Debede solicitar una cantidad de codigos valida")
                'ElseIf CType(txtCantidad.Text, Integer) > 2000 Then
                '    MessageBox.Show("La cantidad de codigos solicitada excede el limite permitido por operacion <Máximo 2000>")
                'Else
                '    Dim codigo As String = IIf(filaRaiz Is Nothing, "S/C", filaRaiz.Cells(1).Value)
                '    Dim trabajador As String = IIf(filaRaiz Is Nothing, "DNI DESCONOCIDO", filaRaiz.Cells(4).Value)
                '    Dim labor As String = cboLaborPacking.SelectedValue
                '    Dim linea As String = cboLinea.SelectedValue
                '    Dim cantidad As Integer = CType(txtCantidad.Text, Integer)
                '    Dim indice As Integer = buscarIndiceTrabajador(dni, labor, linea)

                '    If indice >= 0 Then
                '        dtPersonasSeleccionadas.Rows(indice).Item(7) = CType(dtPersonasSeleccionadas.Rows(indice).Item(7), Integer) + CType(cantidad, Integer)
                '    Else
                '        Dim nuevaFila As DataRow = dtPersonasSeleccionadas.NewRow()
                '        nuevaFila.Item(0) = dni
                '        nuevaFila.Item(1) = codigo
                '        nuevaFila.Item(2) = trabajador
                '        nuevaFila.Item(3) = labor
                '        nuevaFila.Item(4) = linea
                '        nuevaFila.Item(5) = 0
                '        nuevaFila.Item(6) = 0
                '        nuevaFila.Item(7) = cantidad
                '        dtPersonasSeleccionadas.Rows.Add(nuevaFila)
                '        formatearDataGridView(dgvResultado)
                '    End If
                'End If
            Else
                MessageBox.Show("Ya hay alguien generando codigos en este momento, vuelva pronto.")
            End If
            txtFiltro.Focus()
            txtFiltro.SelectAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvPersonas_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPersonas.CellContentDoubleClick
        'agregarDniParaCodigo(dgvPersonas.Rows(e.RowIndex).Cells(0).Value.ToString)
        agregarDniParaCodigo(dgvPersonas.Rows(dgvPersonas.CurrentRow.Index).Cells(0).Value, dgvPersonas.CurrentRow)
        actualizarSumatorias()
    End Sub

    Private Sub dgvPersonas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPersonas.KeyDown
        If e.KeyCode = Keys.Enter Then
            agregarDniParaCodigo(dgvPersonas.Rows(dgvPersonas.CurrentRow.Index).Cells(0).Value, dgvPersonas.CurrentRow) 'dgvPersonas.CurrentRow.Cells(0).Value)
            actualizarSumatorias()
            e.Handled = True
            vieneDeDgv = True
        ElseIf e.KeyCode = Keys.Back Then
            txtFiltro.Focus()
        End If
    End Sub

    Private Sub txtFiltro_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltro.KeyUp
        If vieneDeDgv Then
            vieneDeDgv = False
            Exit Sub
        End If
        If (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up) And dgvPersonas.RowCount > 0 Then
            dgvPersonas.Focus()
        ElseIf e.KeyCode = Keys.Down And dgvPersonas.RowCount <= 0 Then
            txtFiltro.SelectAll()
        ElseIf e.KeyCode = Keys.Enter And dgvPersonas.RowCount <= 0 Then
            agregarDniParaCodigo(txtFiltro.Text, Nothing)
            actualizarSumatorias()
            txtFiltro.Text = ""
            e.SuppressKeyPress = True
            Exit Sub
        Else
            bsResultado.Filter = String.Format("T_Dni like '%{0}%' Or " +
                                            "T_Codigo like '%{1}%' Or " +
                                            "T_Trabajador like '%{2}%'",
                                                 txtFiltro.Text,
                                                 txtFiltro.Text,
                                                 txtFiltro.Text)
            lblDin_Resultado.Text = "Coincicidencias: " + bsResultado.Count.ToString
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If dgvPersonas.SelectedRows.Count = 1 Then
            agregarDniParaCodigo(dgvPersonas.CurrentRow.Cells(0).Value, dgvPersonas.CurrentRow)
        ElseIf dgvPersonas.SelectedRows.Count > 1 Then
            agregarDniParaCodigo(txtFiltro.Text, dgvPersonas.CurrentRow)
        ElseIf dgvPersonas.RowCount <= 0 Then
            agregarDniParaCodigo(txtFiltro.Text, Nothing)
            txtFiltro.Text = ""
        End If
        actualizarSumatorias()
        txtFiltro.Text = ""
        txtFiltro.Focus()
    End Sub

    Private Sub btnPuntitos_Click(sender As Object, e As EventArgs) Handles btnPuntitos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaExcel.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            If txtRutaExcel.Text <> "" Then
                Dim dtTablaExcel As New DataTable
                dtTablaExcel = cargarExcel(txtRutaExcel.Text)
                Dim aux As DataRow = dtPersonasSeleccionadas.NewRow()
                For Each fila As DataRow In dtTablaExcel.Rows()
                    aux = dtPersonasSeleccionadas.NewRow()
                    aux.Item(0) = fila.Item(0)
                    aux.Item(1) = buscarCodigo(fila.Item(0))
                    aux.Item(2) = buscarNombre(fila.Item(0))
                    aux.Item(3) = fila.Item(1)
                    aux.Item(4) = fila.Item(2)
                    aux.Item(5) = 0
                    aux.Item(6) = 0
                    aux.Item(7) = fila.Item(3)
                    dtPersonasSeleccionadas.Rows.Add(aux)
                Next
                actualizarSumatorias()
            Else
                MessageBox.Show("Debe elegir una ruta de archivo valida.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function buscarNombre(dni As String) As String
        For Each fila As DataRow In dtDataPersonas.Rows
            If fila.Item(0) = dni Then
                Return fila.Item(4)
            End If
        Next
        Return "DNI DESCONOCIDO"
    End Function

    Public Function buscarCodigo(dni As String) As String
        For Each fila As DataRow In dtDataPersonas.Rows
            If fila.Item(0) = dni Then
                Return fila.Item(1)
            End If
        Next
        Return "S/C"
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        dtPersonasSeleccionadas.Rows.RemoveAt(dgvResultado.CurrentRow.Index)
        actualizarSumatorias()
    End Sub

    Private Sub cboLinea_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboLinea.SelectionChangeCommitted
        If cboLinea.SelectedValue = 5 Then
            cboLaborPacking.SelectedIndex = 2
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Function buscarIndiceTrabajador(dni As String, labor As String, linea As String) As Integer
        Dim f As Integer = 0
        For f = 0 To dtPersonasSeleccionadas.Rows.Count - 1 Step 1
            If dtPersonasSeleccionadas.Rows(f).Item(0) = dni AndAlso dtPersonasSeleccionadas.Rows(f).Item(3) = labor AndAlso dtPersonasSeleccionadas.Rows(f).Item(4) = linea Then
                Return f
                Exit For
            End If
        Next
        Return -1
    End Function

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    Private Sub txtFiltro_Enter(sender As Object, e As EventArgs) Handles txtFiltro.Enter
        'If dgvPersonas.SelectedRows.Count = 1 Then
        '    agregarDniParaCodigo(dgvPersonas.CurrentRow.Cells(0).Value, dgvPersonas.CurrentRow)
        'ElseIf dgvPersonas.SelectedRows.Count > 1 Then
        '    agregarDniParaCodigo(txtFiltro.Text, dgvPersonas.CurrentRow)
        'ElseIf dgvPersonas.RowCount <= 0 Then
        '    agregarDniParaCodigo(txtFiltro.Text, Nothing)
        '    txtFiltro.Text = ""
        'End If
        'actualizarSumatorias()
        'txtFiltro.Text = ""
    End Sub

    Private Sub dgvPersonas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPersonas.CellContentClick

    End Sub
End Class