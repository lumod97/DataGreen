Imports Logica
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Logica.Funciones
Imports Datos.Conexion

Public Class frmLogin
    Public recordarUsuario As Boolean
    Public usuarioRecordado As String
    Public passwordRecordada As String

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargarExcel("D:\carga.xlsx")
        aplicarTema(Me)

        cargarMenus()
        If existeBDSqlite() Then
            cargarPreferenciasDeInicio(recordarUsuario, usuarioRecordado, passwordRecordada)
        Else
            MessageBox.Show("Parametros de configuracion sin valores. Configure en [Mantenimientos/Configuracion de Bases]")
            recordarUsuario = False
        End If
        cargarCredenciales()
        cboBaseLocal.Items.Add(credenciales("BLNomCon"))
        cboBaseERP.Items.Add((credenciales("BENomCon")))
        cboBaseLocal.SelectedIndex = 0
        cboBaseERP.SelectedIndex = 0
        txtPasword.PasswordChar = pwc
        actualizarPreferenciasLogin()
        If Not validarHora() Then
            MessageBox.Show("Hora de dispositivo incorrecta, actualice hora para poder iniciar.")
            Application.Exit()
        End If

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsuario.Text = "" Then
            MessageBox.Show("Ingresar Usuario")
            txtUsuario.Focus()
            Return
        End If
        If txtPasword.Text = "" Then
            MessageBox.Show("Ingresar Contraseña")
            txtPasword.Focus()
            Return
        End If
        Dim usuarioValidado As Boolean
        usuarioValidado = validarUsuario(cboBaseLocal.SelectedItem, txtUsuario.Text, hashMd5(txtPasword.Text))
        If usuarioValidado = True Then
            guardarPreferenciasDeInicio(cbxRecordarCredenciales.Checked, txtUsuario.Text, txtPasword.Text)
            usuarioActual = txtUsuario.Text
            Me.Hide()
            Dim ventanaPrincipal As New mdiPrincipal
            ventanaPrincipal.Show()
        Else
            MessageBox.Show("Usuario o contraseña incorrectos, vuelva a intentar por favor")
            txtPasword.SelectAll()
            txtPasword.Focus()
        End If

    End Sub

    Private Function validarUsuario(ByVal Base, ByVal Usuario, ByVal Clave) As Boolean
        If Usuario = "" And Clave = "" Then
            'setearPermisos(permisosUsuario)
            Return True
        Else
            Dim p As New Dictionary(Of String, Object)
            Dim r As New DataTable
            p.Add("@Usuario", Usuario)
            p.Add("@Clave", Clave)
            r = doItBaby("spValidarUsuario", p, Datos.Conexion.TipoQuery.DataTable)
            If r.Rows.Count = 1 Then
                permisosUsuario = r.Rows(0).Item(0).ToString
                Return setearPermisos(permisosUsuario)
            End If
            Return False
        End If
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub txtPasword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPasword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub actualizarPreferenciasLogin()
        cbxRecordarCredenciales.Checked = recordarUsuario
        txtUsuario.Text = IIf(recordarUsuario, usuarioRecordado, "")
        txtPasword.Text = IIf(recordarUsuario, passwordRecordada, "")
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If recordarUsuario Then
            btnLogin.Focus()
        Else
            lblUsuario.Focus()
        End If
    End Sub

    Private Function validarHora() As Boolean
        Dim fechaHoraServidor As DateTime
        fechaHoraServidor = doItBaby("sp_ObtenerFechaHoraActual", Nothing, TipoQuery.Scalar)
        Dim dif As Integer = DateDiff(DateInterval.Minute, fechaHoraServidor, Now())
        If dif < 5 And dif > -5 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
