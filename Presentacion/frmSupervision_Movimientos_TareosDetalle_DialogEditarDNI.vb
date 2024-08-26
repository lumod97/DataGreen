Imports System.Windows.Input
Imports Datos.Conexion

Public Class frmSupervision_Movimientos_TareosDetalle_DialogEditarDNI
    Private dniSeleccionado As String
    Private nombreSeleccionado As String

    Dim dtDataPersonas As DataTable

    'Public Sub New()

    '    ' Esta llamada es exigida por el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub
    Public Sub New(dniSeleccionado As String, nombreSeleccionado As String)
        InitializeComponent()
        Me.txtDni.Text = dniSeleccionado
        Me.txtTrabajador.Text = nombreSeleccionado
        dtDataPersonas = doItBaby("sp_Dg_Packing_Movimientos_GenerarCodigosPacking_ListarPersonas", Nothing, TipoQuery.DataTable)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Function buscarNombre(dni As String) As String
        For Each fila As DataRow In dtDataPersonas.Rows
            If fila.Item(0) = dni Then
                Return fila.Item(4)
            End If
        Next
        Return "DNI DESCONOCIDO"
    End Function

    Private Sub txtDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDni.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtTrabajador.Text = buscarNombre(txtDni.Text)
            e.Handled = True
        End If
        ' Verificar si la tecla presionada es un número o una tecla de control (como la tecla de retroceso)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Si no es un número o una tecla de control, cancela la entrada
            e.Handled = True
        End If

    End Sub
End Class