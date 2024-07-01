<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogistica_Indices_CiudadesParaderos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogistica_Indices_CiudadesParaderos))
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdCiudad = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCiudad = New System.Windows.Forms.TextBox()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIdParadero = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombreCiudad = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvParaderos = New System.Windows.Forms.DataGridView()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtParadero = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cbxActivo_Ciudad = New System.Windows.Forms.CheckBox()
        Me.cbxActivo_Paradero = New System.Windows.Forms.CheckBox()
        Me.btnNuevo_Paradero = New System.Windows.Forms.Button()
        Me.btnOk_Ciudad = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnOk_Paradero = New System.Windows.Forms.Button()
        Me.btnEditar_Paradero = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParaderos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 14
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblIdCiudad, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtCiudad, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.lblIdParadero, 2, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label7, 3, 4)
        Me.tlpPrincipal.Controls.Add(Me.lblNombreCiudad, 4, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label9, 5, 4)
        Me.tlpPrincipal.Controls.Add(Me.dgvParaderos, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.txtDepartamento, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtParadero, 6, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnCancelar, 12, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnGuardar, 11, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnNuevo, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.cbxActivo_Ciudad, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.cbxActivo_Paradero, 7, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnOk_Ciudad, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnEditar, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnOk_Paradero, 12, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnEditar_Paradero, 11, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnNuevo_Paradero, 10, 4)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 7
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(932, 502)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'lblIdCiudad
        '
        Me.lblIdCiudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblIdCiudad.AutoSize = True
        Me.lblIdCiudad.Location = New System.Drawing.Point(43, 28)
        Me.lblIdCiudad.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIdCiudad.Name = "lblIdCiudad"
        Me.lblIdCiudad.Size = New System.Drawing.Size(19, 13)
        Me.lblIdCiudad.TabIndex = 1
        Me.lblIdCiudad.Text = "00"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ciudad:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(346, 28)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Departamento:"
        '
        'txtCiudad
        '
        Me.txtCiudad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCiudad.Location = New System.Drawing.Point(123, 21)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(217, 20)
        Me.txtCiudad.TabIndex = 4
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 12)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 47)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(895, 191)
        Me.dgvResultado.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 274)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Id:"
        '
        'lblIdParadero
        '
        Me.lblIdParadero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblIdParadero.AutoSize = True
        Me.lblIdParadero.Location = New System.Drawing.Point(43, 274)
        Me.lblIdParadero.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIdParadero.Name = "lblIdParadero"
        Me.lblIdParadero.Size = New System.Drawing.Size(25, 13)
        Me.lblIdParadero.TabIndex = 8
        Me.lblIdParadero.Text = "000"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(74, 274)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Ciudad:"
        '
        'lblNombreCiudad
        '
        Me.lblNombreCiudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNombreCiudad.AutoSize = True
        Me.lblNombreCiudad.Location = New System.Drawing.Point(123, 274)
        Me.lblNombreCiudad.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNombreCiudad.Name = "lblNombreCiudad"
        Me.lblNombreCiudad.Size = New System.Drawing.Size(16, 13)
        Me.lblNombreCiudad.TabIndex = 10
        Me.lblNombreCiudad.Text = "..."
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(346, 274)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Paradero:"
        '
        'dgvParaderos
        '
        Me.dgvParaderos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvParaderos, 12)
        Me.dgvParaderos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvParaderos.Location = New System.Drawing.Point(18, 293)
        Me.dgvParaderos.Name = "dgvParaderos"
        Me.dgvParaderos.Size = New System.Drawing.Size(895, 191)
        Me.dgvParaderos.TabIndex = 13
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartamento.Location = New System.Drawing.Point(429, 21)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(217, 20)
        Me.txtDepartamento.TabIndex = 5
        '
        'txtParadero
        '
        Me.txtParadero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtParadero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtParadero.Location = New System.Drawing.Point(429, 267)
        Me.txtParadero.Name = "txtParadero"
        Me.txtParadero.Size = New System.Drawing.Size(217, 20)
        Me.txtParadero.TabIndex = 12
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(878, 18)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(35, 23)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(837, 18)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(35, 23)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(714, 18)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(35, 23)
        Me.btnNuevo.TabIndex = 17
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cbxActivo_Ciudad
        '
        Me.cbxActivo_Ciudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxActivo_Ciudad.AutoSize = True
        Me.cbxActivo_Ciudad.Location = New System.Drawing.Point(652, 24)
        Me.cbxActivo_Ciudad.Name = "cbxActivo_Ciudad"
        Me.cbxActivo_Ciudad.Size = New System.Drawing.Size(56, 17)
        Me.cbxActivo_Ciudad.TabIndex = 23
        Me.cbxActivo_Ciudad.Text = "Activo"
        Me.cbxActivo_Ciudad.UseVisualStyleBackColor = True
        '
        'cbxActivo_Paradero
        '
        Me.cbxActivo_Paradero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxActivo_Paradero.AutoSize = True
        Me.cbxActivo_Paradero.Location = New System.Drawing.Point(652, 270)
        Me.cbxActivo_Paradero.Name = "cbxActivo_Paradero"
        Me.cbxActivo_Paradero.Size = New System.Drawing.Size(56, 17)
        Me.cbxActivo_Paradero.TabIndex = 24
        Me.cbxActivo_Paradero.Text = "Activo"
        Me.cbxActivo_Paradero.UseVisualStyleBackColor = True
        '
        'btnNuevo_Paradero
        '
        Me.btnNuevo_Paradero.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNuevo_Paradero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNuevo_Paradero.Image = CType(resources.GetObject("btnNuevo_Paradero.Image"), System.Drawing.Image)
        Me.btnNuevo_Paradero.Location = New System.Drawing.Point(796, 264)
        Me.btnNuevo_Paradero.Name = "btnNuevo_Paradero"
        Me.btnNuevo_Paradero.Size = New System.Drawing.Size(35, 23)
        Me.btnNuevo_Paradero.TabIndex = 19
        Me.btnNuevo_Paradero.UseVisualStyleBackColor = True
        '
        'btnOk_Ciudad
        '
        Me.btnOk_Ciudad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnOk_Ciudad.Image = CType(resources.GetObject("btnOk_Ciudad.Image"), System.Drawing.Image)
        Me.btnOk_Ciudad.Location = New System.Drawing.Point(796, 18)
        Me.btnOk_Ciudad.Name = "btnOk_Ciudad"
        Me.btnOk_Ciudad.Size = New System.Drawing.Size(35, 23)
        Me.btnOk_Ciudad.TabIndex = 25
        Me.btnOk_Ciudad.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(755, 18)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(35, 23)
        Me.btnEditar.TabIndex = 16
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnOk_Paradero
        '
        Me.btnOk_Paradero.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnOk_Paradero.Image = CType(resources.GetObject("btnOk_Paradero.Image"), System.Drawing.Image)
        Me.btnOk_Paradero.Location = New System.Drawing.Point(878, 264)
        Me.btnOk_Paradero.Name = "btnOk_Paradero"
        Me.btnOk_Paradero.Size = New System.Drawing.Size(35, 23)
        Me.btnOk_Paradero.TabIndex = 21
        Me.btnOk_Paradero.UseVisualStyleBackColor = True
        '
        'btnEditar_Paradero
        '
        Me.btnEditar_Paradero.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditar_Paradero.Image = CType(resources.GetObject("btnEditar_Paradero.Image"), System.Drawing.Image)
        Me.btnEditar_Paradero.Location = New System.Drawing.Point(837, 264)
        Me.btnEditar_Paradero.Name = "btnEditar_Paradero"
        Me.btnEditar_Paradero.Size = New System.Drawing.Size(35, 23)
        Me.btnEditar_Paradero.TabIndex = 20
        Me.btnEditar_Paradero.UseVisualStyleBackColor = True
        '
        'frmLogistica_Indices_CiudadesParaderos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 502)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmLogistica_Indices_CiudadesParaderos"
        Me.Text = "Logistica / Indices - Ciudades/Paraderos"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParaderos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIdCiudad As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIdParadero As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNombreCiudad As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtParadero As System.Windows.Forms.TextBox
    Friend WithEvents dgvParaderos As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo_Paradero As System.Windows.Forms.Button
    Friend WithEvents btnEditar_Paradero As System.Windows.Forms.Button
    Friend WithEvents btnOk_Paradero As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cbxActivo_Ciudad As System.Windows.Forms.CheckBox
    Friend WithEvents cbxActivo_Paradero As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk_Ciudad As System.Windows.Forms.Button
End Class
