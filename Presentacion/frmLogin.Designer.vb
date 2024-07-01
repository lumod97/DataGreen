<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtPasword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.cboBaseLocal = New System.Windows.Forms.ComboBox()
        Me.cboBaseERP = New System.Windows.Forms.ComboBox()
        Me.lblPasword = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblBaseLocal = New System.Windows.Forms.Label()
        Me.lblBaseERP = New System.Windows.Forms.Label()
        Me.imgLogoLogin = New System.Windows.Forms.PictureBox()
        Me.cbxRecordarCredenciales = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.imgLogoLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalir, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUsuario, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPasword, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogin, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBaseLocal, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboBaseERP, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPasword, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUsuario, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBaseLocal, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBaseERP, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.imgLogoLogin, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxRecordarCredenciales, 3, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(534, 201)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.SpringGreen
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSalir.Location = New System.Drawing.Point(189, 161)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(154, 23)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtUsuario.Location = New System.Drawing.Point(349, 45)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(154, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'txtPasword
        '
        Me.txtPasword.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtPasword.Location = New System.Drawing.Point(349, 105)
        Me.txtPasword.Name = "txtPasword"
        Me.txtPasword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9608)
        Me.txtPasword.Size = New System.Drawing.Size(154, 20)
        Me.txtPasword.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.SpringGreen
        Me.btnLogin.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogin.Location = New System.Drawing.Point(349, 161)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(154, 23)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'cboBaseLocal
        '
        Me.cboBaseLocal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboBaseLocal.FormattingEnabled = True
        Me.cboBaseLocal.Location = New System.Drawing.Point(189, 44)
        Me.cboBaseLocal.Name = "cboBaseLocal"
        Me.cboBaseLocal.Size = New System.Drawing.Size(154, 21)
        Me.cboBaseLocal.TabIndex = 5
        '
        'cboBaseERP
        '
        Me.cboBaseERP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cboBaseERP.FormattingEnabled = True
        Me.cboBaseERP.Location = New System.Drawing.Point(189, 104)
        Me.cboBaseERP.Name = "cboBaseERP"
        Me.cboBaseERP.Size = New System.Drawing.Size(154, 21)
        Me.cboBaseERP.TabIndex = 6
        '
        'lblPasword
        '
        Me.lblPasword.AutoSize = True
        Me.lblPasword.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblPasword.Location = New System.Drawing.Point(349, 85)
        Me.lblPasword.Name = "lblPasword"
        Me.lblPasword.Size = New System.Drawing.Size(154, 13)
        Me.lblPasword.TabIndex = 6
        Me.lblPasword.Text = "Password:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblUsuario.Location = New System.Drawing.Point(349, 25)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(154, 13)
        Me.lblUsuario.TabIndex = 7
        Me.lblUsuario.Text = "Usuario:"
        '
        'lblBaseLocal
        '
        Me.lblBaseLocal.AutoSize = True
        Me.lblBaseLocal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBaseLocal.Location = New System.Drawing.Point(189, 25)
        Me.lblBaseLocal.Name = "lblBaseLocal"
        Me.lblBaseLocal.Size = New System.Drawing.Size(154, 13)
        Me.lblBaseLocal.TabIndex = 8
        Me.lblBaseLocal.Text = "Base Local:"
        '
        'lblBaseERP
        '
        Me.lblBaseERP.AutoSize = True
        Me.lblBaseERP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBaseERP.Location = New System.Drawing.Point(189, 85)
        Me.lblBaseERP.Name = "lblBaseERP"
        Me.lblBaseERP.Size = New System.Drawing.Size(154, 13)
        Me.lblBaseERP.TabIndex = 9
        Me.lblBaseERP.Text = "Base ERP:"
        '
        'imgLogoLogin
        '
        Me.imgLogoLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgLogoLogin.Image = CType(resources.GetObject("imgLogoLogin.Image"), System.Drawing.Image)
        Me.imgLogoLogin.Location = New System.Drawing.Point(29, 11)
        Me.imgLogoLogin.Name = "imgLogoLogin"
        Me.TableLayoutPanel1.SetRowSpan(Me.imgLogoLogin, 6)
        Me.imgLogoLogin.Size = New System.Drawing.Size(154, 173)
        Me.imgLogoLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.imgLogoLogin.TabIndex = 10
        Me.imgLogoLogin.TabStop = False
        '
        'cbxRecordarCredenciales
        '
        Me.cbxRecordarCredenciales.AutoSize = True
        Me.cbxRecordarCredenciales.Location = New System.Drawing.Point(349, 131)
        Me.cbxRecordarCredenciales.Name = "cbxRecordarCredenciales"
        Me.cbxRecordarCredenciales.Size = New System.Drawing.Size(134, 17)
        Me.cbxRecordarCredenciales.TabIndex = 3
        Me.cbxRecordarCredenciales.Text = "Recordar Credenciales"
        Me.cbxRecordarCredenciales.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 201)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GreenData - Login"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.imgLogoLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtPasword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents cboBaseLocal As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaseERP As System.Windows.Forms.ComboBox
    Friend WithEvents lblPasword As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblBaseLocal As System.Windows.Forms.Label
    Friend WithEvents lblBaseERP As System.Windows.Forms.Label
    Friend WithEvents imgLogoLogin As System.Windows.Forms.PictureBox
    Friend WithEvents cbxRecordarCredenciales As System.Windows.Forms.CheckBox
End Class
