Imports Entidades.Temporales
Imports Logica.Funciones
Imports Logica
Imports Datos.Conexion

Public Class frmCambiarClave
    Public dniParaCambio As String

    Public Sub New(ByRef dni As String)
        InitializeComponent()
        dniParaCambio = dni
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNuevaClave.Text <> txtConfirmarClave.Text Then
            MessageBox.Show("Error, las claves no coinciden")
        ElseIf txtConfirmarClave.Text.Length < 8 Then
            MessageBox.Show("Error, la clave debe ser al menos de 8 digitos")
        ElseIf execCambiarClave() = True Then
            MessageBox.Show("Clave cambiada con exito")
            Me.Close()
        Else
            MessageBox.Show("Error al intentar cambiar la clave.")
        End If
    End Sub

    Private Function execCambiarClave()
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Dni", dniParaCambio)
        p.Add("@Clave", hashMd5(txtNuevaClave.Text))
        Return doItBaby("spCambiarClave", p, TipoQuery.NonQuery)
    End Function
    'Private Sub txtNuevaClave_Keyup(sender As Object, e As KeyPressEventArgs) Handles txtNuevaClave.KeyUp
    '    If txtNuevaClave.Text = txtConfirmarClave.Text Then
    '        lblPasswordMatch.ForeColor = Color.Green
    '        lblPasswordMatch.Text = "Las claves coinciden"
    '    Else
    '        lblPasswordMatch.Text = ""
    '    End If
    'End Sub

    'Private Sub txtConfirmarClave_Keyup(sender As Object, e As KeyPressEventArgs) Handles txtConfirmarClave.KeyPress
    '    If txtConfirmarClave.Text = txtNuevaClave.Text Then
    '        lblPasswordMatch.ForeColor = Color.Green
    '        lblPasswordMatch.Text = "Las claves coinciden"
    '    Else
    '        lblPasswordMatch.Text = ""
    '    End If
    'End Sub

    Private Sub txtConfirmarClave_KeyUp(sender As Object, e As KeyEventArgs) Handles txtConfirmarClave.KeyUp
        If txtConfirmarClave.Text = txtNuevaClave.Text Then
            lblPasswordMatch.ForeColor = Color.Green
            lblPasswordMatch.Text = "Las claves coinciden"
        Else
            lblPasswordMatch.Text = ""
        End If
    End Sub

    Private Sub txtNuevaClave_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNuevaClave.KeyUp
        If txtNuevaClave.Text = txtConfirmarClave.Text Then
            lblPasswordMatch.ForeColor = Color.Green
            lblPasswordMatch.Text = "Las claves coinciden"
        Else
            lblPasswordMatch.Text = ""
        End If
    End Sub

    Private Sub frmCambiarClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Normal
        Utiles.aplicarTema(Me)
    End Sub
End Class