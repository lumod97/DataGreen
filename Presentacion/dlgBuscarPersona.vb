Imports Datos.Conexion
Imports Logica.Utiles
Imports Entidades

Public Class dlgBuscarPersona
    Public Shared nombreSeleccionado = ""
    Public Shared codigoGeneralSeleccionado = ""
    Private Function dtPersonas(parametro As String) As DataTable
        Dim p As New Dictionary(Of String, Object)
        p.Add("@parametro", parametro)
        Return doItBaby("dg_obtener_personal_activo", p, TipoQuery.DataTable)
    End Function

    Public Shared Function obtenerNombre() As String
        Return nombreSeleccionado
    End Function

    Public Shared Function obtenerCodigoGeneral() As String
        Return codigoGeneralSeleccionado
    End Function

    Private Sub inicializarDataGridView(datos As DataTable)
        dgvPersonas.DataSource = datos
        formatearDataGridView(dgvPersonas)
        dgvPersonas.AutoResizeColumns()
        dgvPersonas.AutoResizeRows()
    End Sub
    Private Sub dlgBuscarPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarDataGridView(dtPersonas(""))
    End Sub

    Private Sub txtBusqueda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBusqueda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            inicializarDataGridView(dtPersonas(txtBusqueda.Text.ToString))
        End If
    End Sub

    Private Sub dgvPersonas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPersonas.CellDoubleClick
        Dim fila As DataGridViewRow = dgvPersonas.SelectedRows.Item(0)

        nombreSeleccionado = fila.Cells(2).Value.ToString
        codigoGeneralSeleccionado = fila.Cells(1).Value.ToString
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class