<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoUsuarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnCambiarClave = New System.Windows.Forms.Button()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.txtAMaterno = New System.Windows.Forms.TextBox()
        Me.txtAPaterno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.lblERP = New System.Windows.Forms.Label()
        Me.lblDataGreen = New System.Windows.Forms.Label()
        Me.cbxActivo = New System.Windows.Forms.CheckBox()
        Me.lblInfoClave = New System.Windows.Forms.Label()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.tviModulosPermitidos = New System.Windows.Forms.TreeView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbxActivoMG = New System.Windows.Forms.CheckBox()
        Me.lblMiniGreen = New System.Windows.Forms.Label()
        Me.cbxDataGreen = New System.Windows.Forms.CheckBox()
        Me.cbxMiniGreen = New System.Windows.Forms.CheckBox()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 11
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.82353!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.17647!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpPrincipal.Controls.Add(Me.txtFiltro, 5, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnCambiarClave, 3, 3)
        Me.tlpPrincipal.Controls.Add(Me.txtNombres, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtAMaterno, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtAPaterno, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label6, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblERP, 4, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblDataGreen, 4, 2)
        Me.tlpPrincipal.Controls.Add(Me.cbxActivo, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblInfoClave, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtDni, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtUsuario, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtClave, 2, 3)
        Me.tlpPrincipal.Controls.Add(Me.tviModulosPermitidos, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnGuardar, 9, 6)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 5, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblFiltrar, 5, 3)
        Me.tlpPrincipal.Controls.Add(Me.btnCancelar, 7, 6)
        Me.tlpPrincipal.Controls.Add(Me.cbxActivoMG, 5, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblMiniGreen, 6, 2)
        Me.tlpPrincipal.Controls.Add(Me.cbxDataGreen, 8, 2)
        Me.tlpPrincipal.Controls.Add(Me.cbxMiniGreen, 9, 2)
        Me.tlpPrincipal.Controls.Add(Me.btnNuevo, 8, 3)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 8
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(930, 482)
        Me.tlpPrincipal.TabIndex = 0
        '
        'txtFiltro
        '
        Me.tlpPrincipal.SetColumnSpan(Me.txtFiltro, 5)
        Me.txtFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFiltro.Location = New System.Drawing.Point(360, 97)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(539, 20)
        Me.txtFiltro.TabIndex = 25
        '
        'btnCambiarClave
        '
        Me.btnCambiarClave.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCambiarClave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCambiarClave.Enabled = False
        Me.btnCambiarClave.Location = New System.Drawing.Point(135, 69)
        Me.btnCambiarClave.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCambiarClave.Name = "btnCambiarClave"
        Me.btnCambiarClave.Size = New System.Drawing.Size(126, 23)
        Me.btnCambiarClave.TabIndex = 13
        Me.btnCambiarClave.Text = "Cambiar Clave"
        Me.btnCambiarClave.UseVisualStyleBackColor = True
        '
        'txtNombres
        '
        Me.txtNombres.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNombres.Enabled = False
        Me.txtNombres.Location = New System.Drawing.Point(360, 18)
        Me.txtNombres.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(125, 20)
        Me.txtNombres.TabIndex = 10
        '
        'txtAMaterno
        '
        Me.txtAMaterno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAMaterno.Enabled = False
        Me.txtAMaterno.Location = New System.Drawing.Point(786, 18)
        Me.txtAMaterno.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.txtAMaterno.Name = "txtAMaterno"
        Me.txtAMaterno.Size = New System.Drawing.Size(113, 20)
        Me.txtAMaterno.TabIndex = 9
        '
        'txtAPaterno
        '
        Me.txtAPaterno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAPaterno.Enabled = False
        Me.txtAPaterno.Location = New System.Drawing.Point(584, 18)
        Me.txtAPaterno.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.txtAPaterno.Name = "txtAPaterno"
        Me.txtAPaterno.Size = New System.Drawing.Size(101, 20)
        Me.txtAPaterno.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 74)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Clave:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 47)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Usuario:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(302, 21)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nombres:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(691, 21)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Apellido Materno:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(491, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apellido Paterno:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dni:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnConsultar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnConsultar.Location = New System.Drawing.Point(135, 16)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(126, 23)
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lblERP
        '
        Me.lblERP.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblERP.AutoSize = True
        Me.lblERP.Location = New System.Drawing.Point(307, 74)
        Me.lblERP.Margin = New System.Windows.Forms.Padding(3)
        Me.lblERP.Name = "lblERP"
        Me.lblERP.Size = New System.Drawing.Size(47, 13)
        Me.lblERP.TabIndex = 14
        Me.lblERP.Text = "ERP: __"
        Me.lblERP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDataGreen
        '
        Me.lblDataGreen.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDataGreen.AutoSize = True
        Me.lblDataGreen.Location = New System.Drawing.Point(277, 47)
        Me.lblDataGreen.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDataGreen.Name = "lblDataGreen"
        Me.lblDataGreen.Size = New System.Drawing.Size(77, 13)
        Me.lblDataGreen.TabIndex = 15
        Me.lblDataGreen.Text = "DataGreen: __"
        Me.lblDataGreen.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbxActivo
        '
        Me.cbxActivo.AutoSize = True
        Me.cbxActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxActivo.Location = New System.Drawing.Point(138, 44)
        Me.cbxActivo.Name = "cbxActivo"
        Me.cbxActivo.Size = New System.Drawing.Size(126, 20)
        Me.cbxActivo.TabIndex = 19
        Me.cbxActivo.Text = "Activo en DataGreen"
        Me.cbxActivo.UseVisualStyleBackColor = True
        '
        'lblInfoClave
        '
        Me.lblInfoClave.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblInfoClave.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblInfoClave, 4)
        Me.lblInfoClave.Location = New System.Drawing.Point(18, 99)
        Me.lblInfoClave.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInfoClave.Name = "lblInfoClave"
        Me.lblInfoClave.Size = New System.Drawing.Size(0, 13)
        Me.lblInfoClave.TabIndex = 20
        '
        'txtDni
        '
        Me.txtDni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDni.Location = New System.Drawing.Point(70, 18)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(62, 20)
        Me.txtDni.TabIndex = 21
        '
        'txtUsuario
        '
        Me.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsuario.Location = New System.Drawing.Point(70, 44)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(62, 20)
        Me.txtUsuario.TabIndex = 22
        '
        'txtClave
        '
        Me.txtClave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtClave.Location = New System.Drawing.Point(70, 70)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(62, 20)
        Me.txtClave.TabIndex = 23
        '
        'tviModulosPermitidos
        '
        Me.tviModulosPermitidos.CheckBoxes = True
        Me.tlpPrincipal.SetColumnSpan(Me.tviModulosPermitidos, 4)
        Me.tviModulosPermitidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tviModulosPermitidos.Location = New System.Drawing.Point(18, 120)
        Me.tviModulosPermitidos.Name = "tviModulosPermitidos"
        Me.tviModulosPermitidos.Size = New System.Drawing.Size(336, 315)
        Me.tviModulosPermitidos.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(786, 441)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(113, 23)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 5)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(360, 120)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(539, 315)
        Me.dgvResultado.TabIndex = 24
        '
        'lblFiltrar
        '
        Me.lblFiltrar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.Location = New System.Drawing.Point(360, 74)
        Me.lblFiltrar.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(35, 13)
        Me.lblFiltrar.TabIndex = 26
        Me.lblFiltrar.Text = "Filtrar:"
        Me.lblFiltrar.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(584, 441)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(101, 23)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbxActivoMG
        '
        Me.cbxActivoMG.AutoSize = True
        Me.cbxActivoMG.Location = New System.Drawing.Point(360, 44)
        Me.cbxActivoMG.Name = "cbxActivoMG"
        Me.cbxActivoMG.Size = New System.Drawing.Size(122, 17)
        Me.cbxActivoMG.TabIndex = 27
        Me.cbxActivoMG.Text = "Activo en MiniGreen"
        Me.cbxActivoMG.UseVisualStyleBackColor = True
        '
        'lblMiniGreen
        '
        Me.lblMiniGreen.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblMiniGreen.AutoSize = True
        Me.lblMiniGreen.Location = New System.Drawing.Point(505, 47)
        Me.lblMiniGreen.Margin = New System.Windows.Forms.Padding(3)
        Me.lblMiniGreen.Name = "lblMiniGreen"
        Me.lblMiniGreen.Size = New System.Drawing.Size(73, 13)
        Me.lblMiniGreen.TabIndex = 28
        Me.lblMiniGreen.Text = "MiniGreen: __"
        Me.lblMiniGreen.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbxDataGreen
        '
        Me.cbxDataGreen.AutoSize = True
        Me.cbxDataGreen.Location = New System.Drawing.Point(691, 44)
        Me.cbxDataGreen.Name = "cbxDataGreen"
        Me.cbxDataGreen.Size = New System.Drawing.Size(78, 17)
        Me.cbxDataGreen.TabIndex = 29
        Me.cbxDataGreen.Text = "DataGreen"
        Me.cbxDataGreen.UseVisualStyleBackColor = True
        '
        'cbxMiniGreen
        '
        Me.cbxMiniGreen.AutoSize = True
        Me.cbxMiniGreen.Location = New System.Drawing.Point(786, 44)
        Me.cbxMiniGreen.Name = "cbxMiniGreen"
        Me.cbxMiniGreen.Size = New System.Drawing.Size(74, 17)
        Me.cbxMiniGreen.TabIndex = 30
        Me.cbxMiniGreen.Text = "MiniGreen"
        Me.cbxMiniGreen.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(691, 70)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 21)
        Me.btnNuevo.TabIndex = 31
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmMantenimientoUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 482)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmMantenimientoUsuarios"
        Me.Text = "Mantenimiento de Usuarios"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCambiarClave As System.Windows.Forms.Button
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents txtAMaterno As System.Windows.Forms.TextBox
    Friend WithEvents txtAPaterno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents lblERP As System.Windows.Forms.Label
    Friend WithEvents lblDataGreen As System.Windows.Forms.Label
    Friend WithEvents cbxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblInfoClave As System.Windows.Forms.Label
    Friend WithEvents tviModulosPermitidos As System.Windows.Forms.TreeView
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents txtDni As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents lblFiltrar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cbxActivoMG As CheckBox
    Friend WithEvents lblMiniGreen As Label
    Friend WithEvents cbxDataGreen As CheckBox
    Friend WithEvents cbxMiniGreen As CheckBox
    Friend WithEvents btnNuevo As Button
End Class
