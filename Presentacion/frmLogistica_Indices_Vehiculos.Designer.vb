<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogistica_Indices_Vehiculos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogistica_Indices_Vehiculos))
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboModelo = New System.Windows.Forms.ComboBox()
        Me.cbxActivo = New System.Windows.Forms.CheckBox()
        Me.cboColor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpVtoRevTecnica = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpVtoSoat = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAnioModelo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAnioFabrica = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 19
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.12339!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.46915!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.46915!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.37532!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.56298!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 8)
        Me.tlpPrincipal.Controls.Add(Me.txtPlaca, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.txtFiltro, 2, 5)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.Label10, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnGuardar, 16, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnEditar, 15, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnNuevo, 14, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnCancelar, 17, 5)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 17, 8)
        Me.tlpPrincipal.Controls.Add(Me.Label9, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtRuc, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtProveedor, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.cboModelo, 2, 3)
        Me.tlpPrincipal.Controls.Add(Me.cbxActivo, 14, 4)
        Me.tlpPrincipal.Controls.Add(Me.cboColor, 7, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label7, 6, 3)
        Me.tlpPrincipal.Controls.Add(Me.txtCapacidad, 11, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 10, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 12, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboMarca, 13, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label12, 3, 4)
        Me.tlpPrincipal.Controls.Add(Me.dtpVtoRevTecnica, 5, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label11, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.dtpVtoSoat, 2, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label8, 6, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtAnioModelo, 7, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label6, 8, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtAnioFabrica, 9, 4)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 10
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1041, 521)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Placa:"
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 480)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 32
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'txtPlaca
        '
        Me.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlaca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPlaca.Location = New System.Drawing.Point(85, 18)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(90, 20)
        Me.txtPlaca.TabIndex = 1
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 17)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 127)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(956, 318)
        Me.dgvResultado.TabIndex = 18
        '
        'txtFiltro
        '
        Me.txtFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpPrincipal.SetColumnSpan(Me.txtFiltro, 12)
        Me.txtFiltro.Location = New System.Drawing.Point(85, 101)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(725, 20)
        Me.txtFiltro.TabIndex = 0
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 17)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 451)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(956, 23)
        Me.barProgreso.TabIndex = 31
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(47, 108)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Filtro:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(898, 98)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(35, 23)
        Me.btnGuardar.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar")
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(857, 98)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(35, 23)
        Me.btnEditar.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.btnEditar, "Editar")
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(816, 98)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(35, 23)
        Me.btnNuevo.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnNuevo, "Nuevo")
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(939, 98)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(35, 23)
        Me.btnCancelar.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(939, 480)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(35, 23)
        Me.btnExportar.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.btnExportar, "Exportar")
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(181, 22)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Ruc:"
        '
        'txtRuc
        '
        Me.tlpPrincipal.SetColumnSpan(Me.txtRuc, 2)
        Me.txtRuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRuc.Location = New System.Drawing.Point(217, 18)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(134, 20)
        Me.txtRuc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Proveeedor:"
        '
        'txtProveedor
        '
        Me.tlpPrincipal.SetColumnSpan(Me.txtProveedor, 5)
        Me.txtProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProveedor.Location = New System.Drawing.Point(430, 18)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(274, 20)
        Me.txtProveedor.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Modelo:"
        '
        'cboModelo
        '
        Me.tlpPrincipal.SetColumnSpan(Me.cboModelo, 4)
        Me.cboModelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboModelo.FormattingEnabled = True
        Me.cboModelo.Location = New System.Drawing.Point(85, 45)
        Me.cboModelo.Name = "cboModelo"
        Me.cboModelo.Size = New System.Drawing.Size(266, 21)
        Me.cboModelo.TabIndex = 5
        '
        'cbxActivo
        '
        Me.cbxActivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxActivo.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.cbxActivo, 4)
        Me.cbxActivo.Location = New System.Drawing.Point(816, 73)
        Me.cbxActivo.Name = "cbxActivo"
        Me.cbxActivo.Size = New System.Drawing.Size(56, 17)
        Me.cbxActivo.TabIndex = 12
        Me.cbxActivo.Text = "Activo"
        Me.cbxActivo.UseVisualStyleBackColor = True
        '
        'cboColor
        '
        Me.tlpPrincipal.SetColumnSpan(Me.cboColor, 3)
        Me.cboColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboColor.FormattingEnabled = True
        Me.cboColor.Location = New System.Drawing.Point(430, 45)
        Me.cboColor.Name = "cboColor"
        Me.cboColor.Size = New System.Drawing.Size(167, 21)
        Me.cboColor.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(390, 49)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Color:"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCapacidad.Location = New System.Drawing.Point(670, 45)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(34, 20)
        Me.txtCapacidad.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(603, 49)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Capacidad:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(710, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Marca:"
        '
        'cboMarca
        '
        Me.tlpPrincipal.SetColumnSpan(Me.cboMarca, 5)
        Me.cboMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboMarca.FormattingEnabled = True
        Me.cboMarca.Location = New System.Drawing.Point(756, 18)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(218, 21)
        Me.cboMarca.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.Label12, 2)
        Me.Label12.Location = New System.Drawing.Point(181, 75)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Vto Rev. Tec:"
        '
        'dtpVtoRevTecnica
        '
        Me.dtpVtoRevTecnica.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVtoRevTecnica.Location = New System.Drawing.Point(261, 72)
        Me.dtpVtoRevTecnica.Name = "dtpVtoRevTecnica"
        Me.dtpVtoRevTecnica.Size = New System.Drawing.Size(90, 20)
        Me.dtpVtoRevTecnica.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 75)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Vto. SOAT:"
        '
        'dtpVtoSoat
        '
        Me.dtpVtoSoat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVtoSoat.Location = New System.Drawing.Point(85, 72)
        Me.dtpVtoSoat.Name = "dtpVtoSoat"
        Me.dtpVtoSoat.Size = New System.Drawing.Size(90, 20)
        Me.dtpVtoSoat.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(357, 75)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Año Modelo:"
        '
        'txtAnioModelo
        '
        Me.txtAnioModelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAnioModelo.Location = New System.Drawing.Point(430, 72)
        Me.txtAnioModelo.Name = "txtAnioModelo"
        Me.txtAnioModelo.Size = New System.Drawing.Size(44, 20)
        Me.txtAnioModelo.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(480, 75)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Año Fabrica:"
        '
        'txtAnioFabrica
        '
        Me.txtAnioFabrica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAnioFabrica.Location = New System.Drawing.Point(553, 72)
        Me.txtAnioFabrica.Name = "txtAnioFabrica"
        Me.txtAnioFabrica.Size = New System.Drawing.Size(44, 20)
        Me.txtAnioFabrica.TabIndex = 11
        '
        'frmLogistica_Indices_Vehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 521)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmLogistica_Indices_Vehiculos"
        Me.Text = "Logistica - Indices / Vehiculos"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents txtAnioFabrica As System.Windows.Forms.TextBox
    Friend WithEvents txtAnioModelo As System.Windows.Forms.TextBox
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cbxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpVtoSoat As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cboModelo As System.Windows.Forms.ComboBox
    Friend WithEvents cboColor As System.Windows.Forms.ComboBox
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpVtoRevTecnica As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
