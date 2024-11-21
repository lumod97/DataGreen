Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports Datos.Conexion
Imports Logica.Utiles

Imports Logica
Imports Newtonsoft.Json

Public Class frmMantenimiento_PrivilegiosUsuariosFormularios
    Dim listaPrivilegiosActualizar As New List(Of Dictionary(Of String, String))()
    Dim json As String = ""

    'Private Sub tbDNI_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    ' Permitir solo números (0-9) y las teclas de control como Backspace y Delete
    '    If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ChrW(Keys.Delete)) Then
    '        e.Handled = True  ' Bloquear la tecla presionada si no es un número ni Backspace ni Delete
    '    End If

    '    ' Limitar la longitud a 8 caracteres
    '    If tbDNI.Text.Length >= 8 AndAlso Not (e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ChrW(Keys.Delete)) Then
    '        e.Handled = True  ' Bloquear la tecla presionada si ya hay 8 caracteres
    '    End If
    'End Sub

    Private Sub tbUsuario_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub CargarCheckBoxes(selectedUser As String)
        tlpEditables.SuspendLayout()

        Dim p As New Dictionary(Of String, Object)
        p.Add("@idUsuario", selectedUser)

        Dim privilegiosTable As DataTable = doItBaby("sp_obtener_privilegios_formularios_usuario", p, TipoQuery.DataTable)

        Dim row As DataRow = privilegiosTable.Rows(0)

        Dim usuario As String = row.Item(0).ToString()

        RenderizarPermisos(privilegiosTable, tlpEditables, scrollablePanel)

        tlpEditables.ResumeLayout()
    End Sub


    Public Sub cargarDataGridView()
        Dim resultados As DataTable = doItBaby("SP_OBTENER_USUARIOS_PARA_PRIVILEGIOS", Nothing, TipoQuery.DataTable)
        dgvUsuarios.DataSource = resultados
    End Sub

    Public Sub RenderizarPermisos(table As DataTable, layoutPanel As TableLayoutPanel, scrollablePanel As Panel)

        ' Inicializa un contador
        Dim contador As Integer = 0

        ' Itera sobre las columnas del DataTable
        For Each column As DataColumn In table.Columns
            ' Verifica si el nombre de la columna empieza con "PRIV_"
            If column.ColumnName.StartsWith("PRIV_") Then
                ' Incrementa el contador si la columna tiene el prefijo PRIV_
                contador += 1
            End If
        Next

        ' Configurar el Panel contenedor para el desplazamiento
        scrollablePanel.AutoScroll = True  ' Habilita el scroll en el Panel

        ' Limpiar el scrollablePanel antes de agregar el nuevo layoutPanel
        scrollablePanel.Controls.Clear()

        ' Crear un nuevo TableLayoutPanel
        Dim nuevoLayoutPanel As New TableLayoutPanel()
        nuevoLayoutPanel.BorderStyle = BorderStyle.FixedSingle

        nuevoLayoutPanel.RowCount = table.Rows.Count
        nuevoLayoutPanel.ColumnCount = 2 + contador ' Definimos 6 columnas: Formulario, IdUsuarioAfecto, Crear, Editar, Aprobar, Eliminar

        ' Configurar el ancho de cada columna si es necesario
        nuevoLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Columna 0
        nuevoLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' Columna 1
        For i As Integer = 0 To contador
            nuevoLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.6)) ' Agrega las columas
            ' de acuerdo a las columnas con prefijo PRIV_
        Next

        ' Ajustar el nuevoLayoutPanel al tamaño del contenido
        nuevoLayoutPanel.AutoSize = True
        nuevoLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        nuevoLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single


        ' Recorre cada fila del DataTable
        For i As Integer = 0 To table.Rows.Count - 1
            Dim row = table.Rows(i)
            Dim nombreConcatenado As String = row("Formulario") + "_" + row("IdUsuario") + "_" + row("IdUsuarioAfecto")

            ' Crear y agregar Label para Formulario
            Dim lblFormulario As New Label()
            lblFormulario.Text = row("Formulario").ToString()
            lblFormulario.Anchor = AnchorStyles.Left
            nuevoLayoutPanel.Controls.Add(lblFormulario, 0, i)

            ' Crear y agregar Label para IdUsuarioAfecto
            Dim lblIdUsuarioAfecto As New Label()
            lblIdUsuarioAfecto.Text = row("IdUsuarioAfecto").ToString()
            lblIdUsuarioAfecto.Anchor = AnchorStyles.Left
            nuevoLayoutPanel.Controls.Add(lblIdUsuarioAfecto, 1, i)
            ' Itera sobre las columnas del DataRow
            Dim j As Integer = 0
            For Each column As DataColumn In row.Table.Columns
                ' Verifica si el nombre de la columna empieza con "PRIV_"
                If column.ColumnName.StartsWith("PRIV_") Then
                    ' Extrae el nombre de la acción (sin el prefijo PRIV_)
                    Dim accion As String = column.ColumnName.Substring(5)

                    ' Crear un nuevo CheckBox
                    Dim chk As New CheckBox()
                    chk.Checked = CBool(row(column)) ' Asignar el valor de la columna a la propiedad Checked
                    chk.Name = nombreConcatenado + "_" + accion
                    chk.Text = accion ' El texto del CheckBox será el nombre de la acción
                    chk.Anchor = AnchorStyles.None

                    ' Asignar el evento CheckedChanged
                    AddHandler chk.CheckedChanged, AddressOf CheckBox_CheckedChanged

                    ' Determinar la columna en la que agregar el CheckBox (esto depende de tu layout)
                    ' Aquí se asume que la columna se va a agregar de manera secuencial.
                    nuevoLayoutPanel.Controls.Add(chk, 2 + j, i)
                    j += 1
                End If
            Next

        Next

        ' Agregar el nuevo TableLayoutPanel al Panel si no está ya agregado
        scrollablePanel.Controls.Add(nuevoLayoutPanel)
    End Sub


    ' Manejar el evento CellClick para cuando se hace clic en una celda de la fila
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuarios.CellClick
        If e.RowIndex >= 0 Then ' Verifica que la fila no sea el encabezado
            ' Obtén la fila clickeada
            Dim row As DataGridViewRow = dgvUsuarios.Rows(e.RowIndex)
            Dim usuarioSeleccionado As String = row.Cells("USUARIO").Value.ToString()

            tbUsuario.Text = usuarioSeleccionado
            ' Mostrar el valor de la columna "USUARIO" de la fila clickeada
            'MessageBox.Show(row.Cells("USUARIO").Value.ToString())
            CargarCheckBoxes(usuarioSeleccionado)
        End If
    End Sub


    ' Manejador del evento CheckedChanged para los CheckBox
    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        If listaPrivilegiosActualizar.Count > 0 Then
            btnUpdate.Enabled = True
        End If
        Dim chkBox As CheckBox = CType(sender, CheckBox)
        ' Puedes acceder al nombre del CheckBox o hacer alguna lógica aquí
        Dim nombre As String = chkBox.Name
        Dim estado As Boolean = chkBox.Checked

        ' Dividir el nombre del CheckBox usando "_" como separador
        Dim partes As String() = nombre.Split("_"c) ' Usamos "_" como separador

        ' Concatenar el estado del CheckBox (1 si está marcado, 0 si no lo está)
        partes = partes.Concat(New String() {If(chkBox.Checked, "1", "0")}).ToArray()

        ' Mostrar las partes resultantes
        Dim privilegiosActualizar As New Dictionary(Of String, String)
        Dim itemRemover As New Dictionary(Of String, String)


        privilegiosActualizar.Add("Formulario", partes(0))
        privilegiosActualizar.Add("IdUsuario", partes(1))
        privilegiosActualizar.Add("IdUsuarioAfecto", partes(2))
        privilegiosActualizar.Add("Accion", partes(3))
        privilegiosActualizar.Add("Estado", partes(4))

        For Each item In listaPrivilegiosActualizar
            If item("Formulario") = partes(0) AndAlso
                item("IdUsuario") = partes(1) AndAlso
                item("IdUsuarioAfecto") = partes(2) AndAlso
                item("Accion") = partes(3) Then
                itemRemover = item
                'listaPrivilegiosActualizar.Remove(item)
                item("Estado") = partes(4)
                privilegiosActualizar = item
            End If
        Next

        If itemRemover.Count > 1 Then
            listaPrivilegiosActualizar.Remove(itemRemover)
        End If

        'Next
        listaPrivilegiosActualizar.Add(privilegiosActualizar)
        ' Crear un diccionario principal con la clave "privilegios"
        Dim jsonData As New Dictionary(Of String, Object)
        jsonData.Add("privilegios", listaPrivilegiosActualizar)

        ' Convertir a JSON usando Newtonsoft.Json (asegúrate de agregar la referencia a Json.NET)
        json = JsonConvert.SerializeObject(jsonData)
        Clipboard.SetText(json)

        ' Aquí puedes realizar lo que necesites con el evento
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim params As New Dictionary(Of String, Object)
        params.Add("@json", json)
        Dim privilegiosTable As DataTable = Await doItBaby("SP_ACTUALIZAR_PRIVILEGIOS_FORMULARIOS", params, TipoQuery.DataTable)
        Dim estado As DataRow = privilegiosTable.Rows(0)
        'If estado.Item("codigo").Equals("200") Then
        MessageBox.Show(estado.Item("mensaje"))
        listaPrivilegiosActualizar = New List(Of Dictionary(Of String, String))
        json = ""
        CargarCheckBoxes(dgvUsuarios.SelectedRows.Item(0).Cells(0).Value.ToString)
        btnUpdate.Enabled = False
        'End If
    End Sub


    Private Sub frmMantenimiento_PrivilegiosUsuariosFormularios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aplicarTema(Me)
        Me.WindowState = FormWindowState.Maximized
        'scrollablePanel.AutoScroll = True
        btnUpdate.Enabled = False
        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        cargarDataGridView()
        'CargarCheckBoxes()
        tbUsuario.Focus()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If String.IsNullOrWhiteSpace(tbUsuario.Text) AndAlso String.IsNullOrWhiteSpace(tbUsuarioAfecto.Text) AndAlso String.IsNullOrWhiteSpace(tbFormulario.Text) Then
            MessageBox.Show("Rellene todos los campos!")
        Else
            Dim params As New Dictionary(Of String, Object)
            params.Add("@idUsuario", tbUsuario.Text.ToString)
            params.Add("@idUsuarioAfecto", tbUsuarioAfecto.Text.ToString)
            params.Add("@formulario", tbFormulario.Text.ToString)
            Dim privilegiosTable As DataTable = doItBaby("SP_INSERTAR_USUARIOS_PARA_PRIVILEGIOS", params, TipoQuery.DataTable)
            Dim estado As DataRow = privilegiosTable.Rows(0)
            'If estado.Item("codigo").Equals("200") Then
            MessageBox.Show(estado.Item("mensaje"))
            CargarCheckBoxes(tbUsuario.Text.ToString)
        End If
    End Sub
End Class