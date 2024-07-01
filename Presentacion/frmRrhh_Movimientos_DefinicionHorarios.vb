Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion


Public Class frmRrhh_Movimientos_DefinicionHorarios
    Private WithEvents txtNumeric As DataGridViewTextBoxEditingControl
    Dim dtHorarios As DataTable
    Dim dsResultado As DataSet
    Dim nFilaFinal As Integer = 0
    Dim idHorario As String = ""

    Private Sub frmRrhh_Movimientos_DefinicionHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
        obtenerHorarios()
        cargarCombo(cboHorarios, dtHorarios, "", False)

        bloquearControl(txtNombreHorario)
        bloquearControl(btnGuardarHorario)
        bloquearControl(btnCopiarDiaAnterior)
        bloquearControl(btnLimpiarDia)
        bloquearControl(txtAccion)
        bloquearControl(btnAgregarAccion)
        bloquearControl(btnEliminarAccion)
        bloquearControl(dgvResultado)
        bloquearControl(btnCancelar)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub cargarGrillaDeHorarios()
        If dgvResultado.Columns.Count > 0 Then
            dgvResultado.Columns.Clear()
            dgvResultado.Rows.Clear()
        End If
        

        dgvResultado.RowHeadersVisible = True
        dgvResultado.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvResultado.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        'dgvResultado.RowTemplate.Height = 20
        dgvResultado.RowHeadersDefaultCellStyle.BackColor = grisWindows
        dgvResultado.RowHeadersDefaultCellStyle.ForeColor = blancoPuro_
        'dgvResultado.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
        dgvResultado.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        dgvResultado.EditMode = DataGridViewEditMode.EditProgrammatically

        'formatearDataGridView(dgvResultado)
        dgvResultado.ColumnCount = 7
        'dgvResultado.Columns(0).Name = "Accion"
        dgvResultado.Columns(0).Name = "Lunes"
        dgvResultado.Columns(1).Name = "Martes"
        dgvResultado.Columns(2).Name = "Miercoles"
        dgvResultado.Columns(3).Name = "Jueves"
        dgvResultado.Columns(4).Name = "Viernes"
        dgvResultado.Columns(5).Name = "Sabado"
        dgvResultado.Columns(6).Name = "Domingo"

        Dim row As String() = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        dgvResultado.Rows.Add(row)
        dgvResultado.Rows(0).HeaderCell.Value = "Ingreso"
        'row = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        'dgvResultado.Rows.Add(row)
        'dgvResultado.Rows(1).HeaderCell.Value = "Refrigerio 1"
        'row = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        'dgvResultado.Rows.Add(row)
        'dgvResultado.Rows(2).HeaderCell.Value = "Fin Refrigerio 1"
        'row = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        'dgvResultado.Rows.Add(row)
        'dgvResultado.Rows(3).HeaderCell.Value = "Refrigerio 2"
        'row = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        'dgvResultado.Rows.Add(row)
        'dgvResultado.Rows(4).HeaderCell.Value = "Fin Refrigerio 2"
        row = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        dgvResultado.Rows.Add(row)
        dgvResultado.Rows(1).HeaderCell.Value = "Salida"
        row = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
        dgvResultado.Rows.Add(row)
        dgvResultado.Rows(2).HeaderCell.Value = "Horas X Dia"
        nFilaFinal = 2
    End Sub

    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        dgvResultado.BeginEdit(False)
        CType(dgvResultado.EditingControl, TextBox).SelectionStart = 0 'CType(dgvResultado.EditingControl, TextBox)
    End Sub

    'Private Sub dgvResultado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvResultado.KeyPress
    '    MessageBox.Show("dsd")
    '    dgvResultado.CurrentCell.Value = "00"
    '    CType(dgvResultado.EditingControl, TextBox).Text = "00"
    '    If e.KeyChar = vbBack Then
    '        CType(dgvResultado.EditingControl, TextBox).Text = CType(dgvResultado.EditingControl, TextBox).Text.Substring(0, CType(dgvResultado.EditingControl, TextBox).SelectionStart) + "0" + CType(dgvResultado.EditingControl, TextBox).Text.Substring(CType(dgvResultado.EditingControl, TextBox).SelectionStart + 1, 5)
    '    Else
    '        CType(dgvResultado.EditingControl, TextBox).Text = "00"
    '    End If

    'End Sub




    Private Sub dgvResultado_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvResultado.EditingControlShowing
        txtNumeric = CType(e.Control, DataGridViewTextBoxEditingControl)
    End Sub

    Private Sub txtNumeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeric.KeyPress
        Dim pos As Integer = txtNumeric.SelectionStart
        If IsNumeric(e.KeyChar) And txtNumeric.SelectionStart < 5 And dgvResultado.CurrentRow.Index < nFilaFinal Then
            If pos = 0 And Char.GetNumericValue(e.KeyChar) < 3 Then
                txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart, 1).Insert(txtNumeric.SelectionStart, e.KeyChar)
                txtNumeric.SelectionStart = IIf(pos = 1, pos + 2, pos + 1)
            ElseIf pos = 1 AndAlso CType(txtNumeric.Text.Substring(0, 1), Integer) < 2 Then
                txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart, 1).Insert(txtNumeric.SelectionStart, e.KeyChar)
                txtNumeric.SelectionStart = IIf(pos = 1, pos + 2, pos + 1)
            ElseIf pos = 1 AndAlso CType(txtNumeric.Text.Substring(0, 1), Integer) = 2 AndAlso Char.GetNumericValue(e.KeyChar) < 4 Then
                txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart, 1).Insert(txtNumeric.SelectionStart, e.KeyChar)
                txtNumeric.SelectionStart = IIf(pos = 1, pos + 2, pos + 1)
            ElseIf pos = 3 AndAlso Char.GetNumericValue(e.KeyChar) < 6 Then
                txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart, 1).Insert(txtNumeric.SelectionStart, e.KeyChar)
                txtNumeric.SelectionStart = IIf(pos = 1, pos + 2, pos + 1)
            ElseIf pos = 4 Then
                txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart, 1).Insert(txtNumeric.SelectionStart, e.KeyChar)
                txtNumeric.SelectionStart = IIf(pos = 1, pos + 2, pos + 1)
            End If

        ElseIf e.KeyChar = vbBack AndAlso txtNumeric.SelectionStart > 0 Then
            If pos <> 3 Then
                txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart - 1, 1).Insert(txtNumeric.SelectionStart - 1, "_")
            End If
            txtNumeric.SelectionStart = pos - 1
        End If
        e.Handled = True


    End Sub
    'Private Sub txtNumeric_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeric.KeyDown
    '    'MessageBox.Show(Chr(e.KeyData))
    '    e.SuppressKeyPress = True
    '    txtNumeric.Text = txtNumeric.Text.Remove(txtNumeric.SelectionStart, 1).Insert(txtNumeric.SelectionStart, Chr(e.KeyData))  'Chr(e.KeyData) & txtNumeric.Text & "2"
    '    'If (e.KeyData >= Keys.A And e.KeyData <= Keys.Z) Then
    '    '    e.SuppressKeyPress = True
    '    'End If
    'End Sub

    'Private Sub txtNumeric_keypress(sender As Object, e As KeyPressEventArgs) Handles txtNumeric.KeyPress
    '    MessageBox.Show("mm")
    '    CType(dgvResultado.EditingControl, TextBox).Text = "00"
    '    If (e.KeyData >= Keys.A And e.KeyData <= Keys.Z) Then
    '        e.SuppressKeyPress = True
    '    End If
    '    'If e.KeyChar = vbCr Then
    '    '    dgvResultado.Rows.Add()
    '    '    Exit Sub
    '    'End If
    '    'If e.KeyChar = vbBack Then
    '    '    Exit Sub
    '    'End If
    '    'If InStr("0123456789.,", e.KeyChar) = 0 Then
    '    '    e.KeyChar = ""
    '    'End If
    'End Sub

    'Private Sub dgvResultado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvResultado.KeyPress
    '    MessageBox.Show("333")
    'End Sub

    Private Sub dgvResultado_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellEnter
        dgvResultado.BeginEdit(False)
        CType(dgvResultado.EditingControl, TextBox).SelectionStart = 0
    End Sub

    Private Sub dgvResultado_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellLeave
        'MessageBox.Show(e.RowIndex & "." & e.ColumnIndex)
        Dim hora As String = dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue
        If hora <> "__:__" Then
            If IsNumeric(hora.Substring(0, 2)) And IsNumeric(hora.Substring(3, 2)) Then
                dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = blancoPuro_
            ElseIf Not (IsNumeric(hora.Substring(0, 2)) And IsNumeric(hora.Substring(3, 2))) Then
                dgvResultado.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = rosaBlanco_
            End If
            If dgvResultado.Rows(0).Cells(e.ColumnIndex).Style.BackColor = blancoPuro_ _
                And dgvResultado.Rows(nFilaFinal - 1).Cells(e.ColumnIndex).Style.BackColor = blancoPuro_ Then
                calcularHoras(e.ColumnIndex)
                calcularHorasSemana()
                'Dim difHoras As String = restarHoras(dgvResultado.Rows(0).Cells(e.ColumnIndex).EditedFormattedValue, dgvResultado.Rows(nFilaFinal - 1).Cells(e.ColumnIndex).EditedFormattedValue)
                'dgvResultado.Rows(nFilaFinal).Cells(e.ColumnIndex).Value = difHoras
                'dgvResultado.Rows(nFilaFinal).Cells(e.ColumnIndex).Style.BackColor = verderCian_
            End If
        End If
    End Sub

    Private Sub btnLimpiarDia_Click(sender As Object, e As EventArgs) Handles btnLimpiarDia.Click
        For Each fila As DataGridViewRow In dgvResultado.Rows
            fila.Cells(dgvResultado.CurrentCell.ColumnIndex).Value = "__:__"
            fila.Cells(dgvResultado.CurrentCell.ColumnIndex).Style.BackColor = blancoPuro_
        Next
    End Sub

    Private Sub btnCopiarDiaAnterior_Click(sender As Object, e As EventArgs) Handles btnCopiarDiaAnterior.Click
        For Each fila As DataGridViewRow In dgvResultado.Rows
            'NO PERMITE EL CALCULO DE HORAS
            fila.Cells(dgvResultado.CurrentCell.ColumnIndex).Value = fila.Cells(dgvResultado.CurrentCell.ColumnIndex - 1).Value
        Next
    End Sub

    Private Sub btnNuevoHorario_Click(sender As Object, e As EventArgs) Handles btnNuevoHorario.Click
        cargarGrillaDeHorarios()
        desbloquearControl(txtNombreHorario)
        desbloquearControl(btnGuardarHorario)
        desbloquearControl(btnCopiarDiaAnterior)
        desbloquearControl(btnLimpiarDia)
        desbloquearControl(btnCancelar)
        desbloquearControl(btnAgregarAccion)
        desbloquearControl(btnEliminarAccion)
        desbloquearControl(txtAccion)
        desbloquearControl(dgvResultado)
        bloquearControl(btnEditarHorario)
        bloquearControl(cboHorarios)
        cboHorarios.SelectedIndex = -1
        lblHorarioSeleccionado.Text = ""
        idHorario = ""
        txtNombreHorario.Focus()
    End Sub

    Private Sub obtenerHorarios()
        dtHorarios = doItBaby("sp_Dg_Rrhh_Movimientos_DefinicionHorarios_ObtenerDataParaCombos", Nothing, TipoQuery.DataTable)
    End Sub

    Private Sub cboHorarios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboHorarios.SelectionChangeCommitted
        If cboHorarios.SelectedValue = "00" Then
            MessageBox.Show("El horario seleccionado no permite edicion.")
        Else
            dgvResultado.Visible = False
            Dim p As New Dictionary(Of String, Object)
            p.Add("@IdHorario", cboHorarios.SelectedValue)
            dsResultado = doItBaby("sp_Dg_Rrhh_Movimientos_DefinicionHorarios_ObtenerHorario", p, TipoQuery.DataSet)
            cargarHorarioEnDataGridView()
            idHorario = cboHorarios.SelectedItem.item(0)
            lblHorarioSeleccionado.Text = idHorario & " - " & cboHorarios.SelectedItem.item(1)
        End If
    End Sub

    Private Function restarHoras(hora1 As String, hora2 As String) As String
        Dim ts As TimeSpan = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, CType(hora1, DateTime), CType(hora2, DateTime)))
        Return String.Format("{0:00}:{1:00}", Math.Floor(ts.TotalHours), ts.Minutes)
    End Function

    Private Sub btnAgregarAccion_Click(sender As Object, e As EventArgs) Handles btnAgregarAccion.Click
        Dim nFilaActual As Integer = dgvResultado.CurrentRow.Index
        If nFilaActual > 0 And nFilaActual < nFilaFinal Then
            Dim fila As String() = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
            dgvResultado.Rows.Insert(nFilaActual, fila)
            dgvResultado.Rows(nFilaActual).HeaderCell.Value = txtAccion.Text
            fila = New String() {"__:__", "__:__", "__:__", "__:__", "__:__", "__:__", "__:__"}
            dgvResultado.Rows.Insert(nFilaActual + 1, fila)
            dgvResultado.Rows(nFilaActual + 1).HeaderCell.Value = "Fin" + txtAccion.Text
            nFilaFinal += 2
            txtAccion.Text = ""
        Else
            MessageBox.Show("La posicion de la fila actual no permite inserta acciones, sitúese en otra fila.")
        End If
    End Sub

    Private Sub calcularHoras(col As Integer)
        Try
            Dim horas As New TimeSpan
            Dim hora1 As String = "", hora2 As String = ""
            Dim j As Integer = 0
            For i As Integer = 0 To nFilaFinal - 2 Step 1
                hora1 = dgvResultado.Rows(i).Cells(col).EditedFormattedValue
                For j = i + 1 To nFilaFinal - 1 Step 1
                    If validarHora(dgvResultado.Rows(j).Cells(col).EditedFormattedValue) Then
                        hora2 = dgvResultado.Rows(j).Cells(col).EditedFormattedValue
                        Exit For
                    End If
                Next
                'hora2 = dgvResultado.Rows(i + 1).Cells(col).EditedFormattedValue
                If validarHora(hora1) And validarHora(hora2) Then
                    If hora2 >= hora1 Then
                        Dim lapso As TimeSpan = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, CType(hora1, DateTime), CType(hora2, DateTime)))
                        horas = horas.Add(lapso)
                        i += 1
                    Else
                        Dim lapso1 As TimeSpan = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, CType(hora1, DateTime), CType("23:59", DateTime)) + 1)
                        Dim lapso2 As TimeSpan = TimeSpan.FromMinutes(DateDiff(DateInterval.Minute, CType("00:00", DateTime), CType(hora2, DateTime)))
                        horas = horas.Add(lapso1 + lapso2)
                        i += 1
                    End If
                    
                End If
            Next
            String.Format("{0:00}:{1:00}", Math.Floor(horas.TotalHours), horas.Minutes)
            'Dim difHoras As String = restarHoras(dgvResultado.Rows(0).Cells(col).EditedFormattedValue, dgvResultado.Rows(nFilaFinal - 1).Cells(col).EditedFormattedValue)
            dgvResultado.Rows(nFilaFinal).Cells(col).Value = String.Format("{0:00}:{1:00}", Math.Floor(horas.TotalHours), horas.Minutes)
            dgvResultado.Rows(nFilaFinal).Cells(col).Style.BackColor = verderCian_
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function validarHora(hora As String) As Boolean
        If hora.Length >= 5 AndAlso IsNumeric(hora.Substring(0, 2)) AndAlso IsNumeric(hora.Substring(3, 2)) Then
            Return True
        Else 'If Not (IsNumeric(hora.Substring(0, 2)) And IsNumeric(hora.Substring(3, 2))) Then
            Return False
        End If
    End Function

    Private Sub calcularHorasSemana()
        Dim horas As Double = 0
        Dim minutos As Integer = 0
        Dim hora As TimeSpan
        For Each col As DataGridViewColumn In dgvResultado.Columns
            Try
                hora = TimeSpan.FromMinutes(CDate(dgvResultado.Rows(nFilaFinal).Cells(col.Index).EditedFormattedValue).TimeOfDay.TotalMinutes)
                minutos = hora.TotalMinutes
            Catch
                minutos = 0
            End Try
            horas += minutos
        Next
        horas = horas / 60
        lblTotalHorasSemana.Text = Math.Round(horas, 2).ToString
    End Sub

    Private Sub btnEliminarAccion_Click(sender As Object, e As EventArgs) Handles btnEliminarAccion.Click
        If dgvResultado.CurrentCell.RowIndex > 0 And dgvResultado.CurrentCell.RowIndex < nFilaFinal - 1 Then
            Dim tituloCabecera As String = dgvResultado.CurrentRow.HeaderCell.Value
            If tituloCabecera.Substring(0, 3) = "Fin" Then
                dgvResultado.Rows.RemoveAt(dgvResultado.CurrentRow.Index - 1)
            Else
                dgvResultado.Rows.RemoveAt(dgvResultado.CurrentRow.Index + 1)
            End If
            dgvResultado.Rows.RemoveAt(dgvResultado.CurrentRow.Index)
        End If
    End Sub

    Private Sub cargarHorarioEnDataGridView()
        dgvResultado.RowHeadersVisible = True
        dgvResultado.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvResultado.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvResultado.RowHeadersDefaultCellStyle.BackColor = grisWindows
        dgvResultado.RowHeadersDefaultCellStyle.ForeColor = blancoPuro_
        dgvResultado.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        dgvResultado.EditMode = DataGridViewEditMode.EditProgrammatically

        dgvResultado.Rows.Clear()
        dgvResultado.Columns.Clear()

        dgvResultado.ColumnCount = 7
        dgvResultado.Columns(0).Name = "Lunes"
        dgvResultado.Columns(1).Name = "Martes"
        dgvResultado.Columns(2).Name = "Miercoles"
        dgvResultado.Columns(3).Name = "Jueves"
        dgvResultado.Columns(4).Name = "Viernes"
        dgvResultado.Columns(5).Name = "Sabado"
        dgvResultado.Columns(6).Name = "Domingo"

        Dim cadenaFila(6) As String
        For j As Integer = 0 To dsResultado.Tables(1).Rows.Count - 1 Step 1
            For i As Integer = 1 To dsResultado.Tables(1).Columns.Count - 1 Step 1
                cadenaFila(i - 1) = IIf(IsDBNull(dsResultado.Tables(1).Rows(j).Item(i)), "__:__", dsResultado.Tables(1).Rows(j).Item(i))
            Next
            dgvResultado.Rows.Add(cadenaFila)
            dgvResultado.Rows(j).HeaderCell.Value = dsResultado.Tables(1).Rows(j).Item(0)
        Next
        nFilaFinal = dgvResultado.Rows.Count - 1
        For i As Integer = 0 To dgvResultado.ColumnCount - 1 Step 1
            calcularHoras(i)
        Next
        calcularHorasSemana()
        dgvResultado.Visible = True
    End Sub

    Private Sub btnEditarHorario_Click(sender As Object, e As EventArgs) Handles btnEditarHorario.Click
        If cboHorarios.SelectedIndex < 0 Then
            MessageBox.Show("No ha seleccionado ningun horario.")
        Else
            bloquearControl(cboHorarios)
            bloquearControl(btnEditarHorario)
            bloquearControl(btnNuevoHorario)
            desbloquearControl(txtNombreHorario)
            desbloquearControl(btnGuardarHorario)
            desbloquearControl(txtAccion)
            desbloquearControl(btnAgregarAccion)
            desbloquearControl(btnEliminarAccion)
            desbloquearControl(dgvResultado)
            desbloquearControl(btnCopiarDiaAnterior)
            desbloquearControl(btnLimpiarDia)
            desbloquearControl(btnCancelar)
            'desbloquearControl(txtNombreHorario)
            txtNombreHorario.Text = cboHorarios.SelectedItem.item(1)
            txtNombreHorario.Focus()
        End If
    End Sub

    Private Sub btnGuardarHorario_Click(sender As Object, e As EventArgs) Handles btnGuardarHorario.Click
        Dim p As New Dictionary(Of String, Object)
        Dim cadena As String = String.Empty
        cadena = idHorario & ";" & txtNombreHorario.Text & ";" & lblTotalHorasSemana.Text & ";" & usuarioActual
        p.Add("@Cadena", cadena)

        idHorario = doItBaby("sp_Dg_Rrhh_Movimientos_DefinicionHorarios_GuardarHorario", p, TipoQuery.Scalar)

        If idHorario.Length > 0 Then
            For i As Integer = 0 To nFilaFinal - 1 Step 1
                cadena = String.Empty
                cadena = idHorario & ";" & (i + 1).ToString & ";" & dgvResultado.Rows(i).HeaderCell.Value
                For j As Integer = 0 To 6 Step 1
                    cadena = cadena & ";" & dgvResultado.Rows(i).Cells(j).FormattedValue
                Next
                p.Clear()
                p.Add("@Cadena", cadena)
                doItBaby("sp_Dg_Rrhh_Movimientos_DefinicionHorarios_GuardarHorario", p, TipoQuery.NonQuery)
            Next
            cadena = String.Empty
            cadena = idHorario & ";" & "100" & ";" & "TotalHorasXDia"
            For j As Integer = 0 To 6 Step 1
                cadena = cadena & ";" & dgvResultado.Rows(nFilaFinal).Cells(j).FormattedValue
            Next
            p.Clear()
            p.Add("@Cadena", cadena)
            doItBaby("sp_Dg_Rrhh_Movimientos_DefinicionHorarios_GuardarHorario", p, TipoQuery.NonQuery)
            bloquearControl(txtNombreHorario)
            bloquearControl(btnGuardarHorario)
            bloquearControl(btnCopiarDiaAnterior)
            bloquearControl(btnLimpiarDia)
            bloquearControl(btnCancelar)
            bloquearControl(btnAgregarAccion)
            bloquearControl(btnEliminarAccion)
            bloquearControl(txtAccion)
            bloquearControl(dgvResultado)
            desbloquearControl(btnEditarHorario)
            desbloquearControl(cboHorarios)
            obtenerHorarios()
            cargarCombo(cboHorarios, dtHorarios, "", False)
            MessageBox.Show("Horario guardado correctamente.")
        Else
            MessageBox.Show("Error al intentar guardar el horario.")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtNombreHorario.Text = ""
        bloquearControl(txtNombreHorario)
        bloquearControl(btnAgregarAccion)
        bloquearControl(txtAccion)
        bloquearControl(btnEliminarAccion)
        bloquearControl(btnGuardarHorario)
        bloquearControl(btnCancelar)
        desbloquearControl(btnEditarHorario)
        desbloquearControl(btnNuevoHorario)
        desbloquearControl(cboHorarios)
        dgvResultado.Columns.Clear()
        dgvResultado.Rows.Clear()
        bloquearControl(dgvResultado)
        'bloquearControl(btnEditarHorario)
        idHorario = ""
        lblTotalHorasSemana.Text = "0.00"
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim p As New Dictionary(Of String, Object)
        p.Add("@IdHorario", idHorario)
        Dim res As String = doItBaby("sp_Dg_Rrhh_Movimientos_DefinicionHorarios_EliminarHorarios", p, TipoQuery.Scalar)
        If res = "Ok" Then
            obtenerHorarios()
            cargarCombo(cboHorarios, dtHorarios, "", False)
            dgvResultado.Columns.Clear()
            dgvResultado.Rows.Clear()
            lblHorarioSeleccionado.Text = ""
            MessageBox.Show("Horario eliminado correctamente.")
        Else
            MessageBox.Show("No se ha podido eliminar el horario correctamente." + vbNewLine + res)
        End If
    End Sub
End Class