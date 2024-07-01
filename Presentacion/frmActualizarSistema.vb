Imports Entidades.Temporales
Imports Logica.Utiles
Imports Datos.Conexion
Public Class frmActualizarSistema

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim Instaleitor As New ProcessStartInfo
        Dim rutaInstaleitor As String
        rutaInstaleitor = doItBaby("sp_ObtenerRutaInstaleitor", Nothing, TipoQuery.Scalar)
        Instaleitor.FileName = rutaInstaleitor
        'Instaleitor.FileName = "\\192.168.30.92\All\InstalablesSanJuan\Instaleitor"
        'Instaleitor.FileName = "\\192.168.30.95\Xsolution\InstalablesSanJuan\InstaLeitor\InstaLeitor.exe"
        'Instaleitor.Arguments = "C:\g.inp"
        Instaleitor.Verb = "runas"
        Process.Start(Instaleitor)
    End Sub

    Private Sub frmActualizarSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersionActual.Text = lblVersionActual.Text + versionActual
        lblVersionDisponible.Text = lblVersionDisponible.Text + versionDisponible
        'AplicarTema
        aplicarTema(Me)
        'For Each c As Control In Me.Controls
        '    aplicarTema(c)
        'Next
        'FinAplicarTema
        'Me.WindowState = FormWindowState.Maximized
        'lbl1.Font = New Font("mononoki", 8)
    End Sub
End Class