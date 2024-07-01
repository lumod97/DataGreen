<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduccion_Movimientos_ActualizarDatosPallets
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
        Me.dgvCabeceraPallets = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtCodigoPallet = New System.Windows.Forms.TextBox()
        Me.txtEmpaque = New System.Windows.Forms.TextBox()
        Me.txtVariedad = New System.Windows.Forms.TextBox()
        Me.txtCultivo = New System.Windows.Forms.TextBox()
        Me.txtCampana = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxTodos = New System.Windows.Forms.CheckBox()
        Me.radEdicionMultiple = New System.Windows.Forms.RadioButton()
        Me.radEdicionIndependiente = New System.Windows.Forms.RadioButton()
        Me.dgvDetallePallets = New System.Windows.Forms.DataGridView()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblCoincidencias = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.tlpEdicion = New System.Windows.Forms.TableLayoutPanel()
        Me.cboCalibre = New System.Windows.Forms.ComboBox()
        Me.cboEtiqueta = New System.Windows.Forms.ComboBox()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbxCliente = New System.Windows.Forms.CheckBox()
        Me.cbxEtiqueta = New System.Windows.Forms.CheckBox()
        Me.cbxCalibre = New System.Windows.Forms.CheckBox()
        Me.cbxNroPlan = New System.Windows.Forms.CheckBox()
        Me.txtNro = New System.Windows.Forms.TextBox()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvCabeceraPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvDetallePallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tlpEdicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 6
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tlpPrincipal.Controls.Add(Me.dgvCabeceraPallets, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.GroupBox1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.cbxTodos, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.radEdicionMultiple, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.radEdicionIndependiente, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.dgvDetallePallets, 4, 4)
        Me.tlpPrincipal.Controls.Add(Me.btnEditar, 4, 2)
        Me.tlpPrincipal.Controls.Add(Me.FlowLayoutPanel1, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.tlpEdicion, 1, 6)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 8
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(943, 447)
        Me.tlpPrincipal.TabIndex = 1
        '
        'dgvCabeceraPallets
        '
        Me.dgvCabeceraPallets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvCabeceraPallets, 3)
        Me.dgvCabeceraPallets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCabeceraPallets.Location = New System.Drawing.Point(18, 141)
        Me.dgvCabeceraPallets.Name = "dgvCabeceraPallets"
        Me.dgvCabeceraPallets.Size = New System.Drawing.Size(599, 202)
        Me.dgvCabeceraPallets.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPrincipal.SetColumnSpan(Me.GroupBox1, 4)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(896, 71)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtCliente, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtIdCliente, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtFecha, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCodigoPallet, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtEmpaque, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtVariedad, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCultivo, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCampana, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(890, 52)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'txtCliente
        '
        Me.txtCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCliente.Location = New System.Drawing.Point(634, 29)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(253, 20)
        Me.txtCliente.TabIndex = 41
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdCliente.Location = New System.Drawing.Point(445, 29)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(122, 20)
        Me.txtIdCliente.TabIndex = 40
        '
        'txtFecha
        '
        Me.txtFecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFecha.Location = New System.Drawing.Point(257, 29)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(122, 20)
        Me.txtFecha.TabIndex = 39
        '
        'txtCodigoPallet
        '
        Me.txtCodigoPallet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodigoPallet.Location = New System.Drawing.Point(81, 29)
        Me.txtCodigoPallet.Name = "txtCodigoPallet"
        Me.txtCodigoPallet.Size = New System.Drawing.Size(122, 20)
        Me.txtCodigoPallet.TabIndex = 38
        '
        'txtEmpaque
        '
        Me.txtEmpaque.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmpaque.Location = New System.Drawing.Point(634, 3)
        Me.txtEmpaque.Name = "txtEmpaque"
        Me.txtEmpaque.Size = New System.Drawing.Size(253, 20)
        Me.txtEmpaque.TabIndex = 37
        '
        'txtVariedad
        '
        Me.txtVariedad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVariedad.Location = New System.Drawing.Point(445, 3)
        Me.txtVariedad.Name = "txtVariedad"
        Me.txtVariedad.Size = New System.Drawing.Size(122, 20)
        Me.txtVariedad.TabIndex = 36
        '
        'txtCultivo
        '
        Me.txtCultivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCultivo.Location = New System.Drawing.Point(257, 3)
        Me.txtCultivo.Name = "txtCultivo"
        Me.txtCultivo.Size = New System.Drawing.Size(122, 20)
        Me.txtCultivo.TabIndex = 35
        '
        'txtCampana
        '
        Me.txtCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCampana.Location = New System.Drawing.Point(81, 3)
        Me.txtCampana.Name = "txtCampana"
        Me.txtCampana.Size = New System.Drawing.Size(122, 20)
        Me.txtCampana.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(385, 32)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Id Cliente:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 6)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Campana:"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 32)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Codigo Pallet:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(209, 6)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Cultivo:"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(211, 32)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Fecha:"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(573, 6)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Empaque:"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(586, 32)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Cliente:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(387, 6)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Variedad:"
        '
        'cbxTodos
        '
        Me.cbxTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxTodos.AutoSize = True
        Me.cbxTodos.Location = New System.Drawing.Point(18, 118)
        Me.cbxTodos.Name = "cbxTodos"
        Me.cbxTodos.Size = New System.Drawing.Size(56, 17)
        Me.cbxTodos.TabIndex = 18
        Me.cbxTodos.Text = "Todos"
        Me.cbxTodos.UseVisualStyleBackColor = True
        '
        'radEdicionMultiple
        '
        Me.radEdicionMultiple.AutoSize = True
        Me.radEdicionMultiple.Checked = True
        Me.radEdicionMultiple.Location = New System.Drawing.Point(18, 95)
        Me.radEdicionMultiple.Name = "radEdicionMultiple"
        Me.radEdicionMultiple.Size = New System.Drawing.Size(99, 17)
        Me.radEdicionMultiple.TabIndex = 19
        Me.radEdicionMultiple.TabStop = True
        Me.radEdicionMultiple.Text = "Edicion Multiple"
        Me.radEdicionMultiple.UseVisualStyleBackColor = True
        '
        'radEdicionIndependiente
        '
        Me.radEdicionIndependiente.AutoSize = True
        Me.radEdicionIndependiente.Location = New System.Drawing.Point(123, 95)
        Me.radEdicionIndependiente.Name = "radEdicionIndependiente"
        Me.radEdicionIndependiente.Size = New System.Drawing.Size(131, 17)
        Me.radEdicionIndependiente.TabIndex = 20
        Me.radEdicionIndependiente.Text = "Edicion Independiente"
        Me.radEdicionIndependiente.UseVisualStyleBackColor = True
        '
        'dgvDetallePallets
        '
        Me.dgvDetallePallets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetallePallets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetallePallets.Location = New System.Drawing.Point(623, 141)
        Me.dgvDetallePallets.Name = "dgvDetallePallets"
        Me.dgvDetallePallets.Size = New System.Drawing.Size(291, 202)
        Me.dgvDetallePallets.TabIndex = 21
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Location = New System.Drawing.Point(814, 112)
        Me.btnEditar.Name = "btnEditar"
        Me.tlpPrincipal.SetRowSpan(Me.btnEditar, 2)
        Me.btnEditar.Size = New System.Drawing.Size(100, 23)
        Me.btnEditar.TabIndex = 22
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPrincipal.SetColumnSpan(Me.FlowLayoutPanel1, 4)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblCoincidencias)
        Me.FlowLayoutPanel1.Controls.Add(Me.Splitter1)
        Me.FlowLayoutPanel1.Controls.Add(Me.lblSeleccionados)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(18, 349)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(896, 19)
        Me.FlowLayoutPanel1.TabIndex = 23
        '
        'lblCoincidencias
        '
        Me.lblCoincidencias.AutoSize = True
        Me.lblCoincidencias.Location = New System.Drawing.Point(3, 3)
        Me.lblCoincidencias.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCoincidencias.Name = "lblCoincidencias"
        Me.lblCoincidencias.Size = New System.Drawing.Size(85, 13)
        Me.lblCoincidencias.TabIndex = 0
        Me.lblCoincidencias.Text = "Coincidencias: 0"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(94, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 13)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Location = New System.Drawing.Point(103, 3)
        Me.lblSeleccionados.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(89, 13)
        Me.lblSeleccionados.TabIndex = 2
        Me.lblSeleccionados.Text = "Seleccionados: 0"
        '
        'tlpEdicion
        '
        Me.tlpEdicion.AutoSize = True
        Me.tlpEdicion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpEdicion.ColumnCount = 5
        Me.tlpPrincipal.SetColumnSpan(Me.tlpEdicion, 4)
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.Controls.Add(Me.cboCalibre, 2, 1)
        Me.tlpEdicion.Controls.Add(Me.cboEtiqueta, 1, 1)
        Me.tlpEdicion.Controls.Add(Me.cboCliente, 0, 1)
        Me.tlpEdicion.Controls.Add(Me.btnGuardar, 4, 1)
        Me.tlpEdicion.Controls.Add(Me.btnCancelar, 3, 1)
        Me.tlpEdicion.Controls.Add(Me.cbxCliente, 0, 0)
        Me.tlpEdicion.Controls.Add(Me.cbxEtiqueta, 1, 0)
        Me.tlpEdicion.Controls.Add(Me.cbxCalibre, 2, 0)
        Me.tlpEdicion.Controls.Add(Me.cbxNroPlan, 3, 0)
        Me.tlpEdicion.Controls.Add(Me.txtNro, 4, 0)
        Me.tlpEdicion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpEdicion.Location = New System.Drawing.Point(18, 374)
        Me.tlpEdicion.Name = "tlpEdicion"
        Me.tlpEdicion.RowCount = 2
        Me.tlpEdicion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpEdicion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpEdicion.Size = New System.Drawing.Size(896, 55)
        Me.tlpEdicion.TabIndex = 24
        '
        'cboCalibre
        '
        Me.cboCalibre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCalibre.Enabled = False
        Me.cboCalibre.FormattingEnabled = True
        Me.cboCalibre.Location = New System.Drawing.Point(528, 29)
        Me.cboCalibre.Name = "cboCalibre"
        Me.cboCalibre.Size = New System.Drawing.Size(169, 21)
        Me.cboCalibre.TabIndex = 22
        '
        'cboEtiqueta
        '
        Me.cboEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboEtiqueta.Enabled = False
        Me.cboEtiqueta.FormattingEnabled = True
        Me.cboEtiqueta.Location = New System.Drawing.Point(318, 29)
        Me.cboEtiqueta.Name = "cboEtiqueta"
        Me.cboEtiqueta.Size = New System.Drawing.Size(204, 21)
        Me.cboEtiqueta.TabIndex = 21
        '
        'cboCliente
        '
        Me.cboCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCliente.Enabled = False
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(3, 29)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(309, 21)
        Me.cboCliente.TabIndex = 20
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(799, 29)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(90, 23)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(703, 29)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbxCliente
        '
        Me.cbxCliente.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxCliente.AutoSize = True
        Me.cbxCliente.Location = New System.Drawing.Point(3, 4)
        Me.cbxCliente.Name = "cbxCliente"
        Me.cbxCliente.Size = New System.Drawing.Size(58, 17)
        Me.cbxCliente.TabIndex = 23
        Me.cbxCliente.Text = "Cliente"
        Me.cbxCliente.UseVisualStyleBackColor = True
        '
        'cbxEtiqueta
        '
        Me.cbxEtiqueta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxEtiqueta.AutoSize = True
        Me.cbxEtiqueta.Location = New System.Drawing.Point(318, 4)
        Me.cbxEtiqueta.Name = "cbxEtiqueta"
        Me.cbxEtiqueta.Size = New System.Drawing.Size(65, 17)
        Me.cbxEtiqueta.TabIndex = 24
        Me.cbxEtiqueta.Text = "Etiqueta"
        Me.cbxEtiqueta.UseVisualStyleBackColor = True
        '
        'cbxCalibre
        '
        Me.cbxCalibre.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxCalibre.AutoSize = True
        Me.cbxCalibre.Location = New System.Drawing.Point(528, 4)
        Me.cbxCalibre.Name = "cbxCalibre"
        Me.cbxCalibre.Size = New System.Drawing.Size(58, 17)
        Me.cbxCalibre.TabIndex = 25
        Me.cbxCalibre.Text = "Calibre"
        Me.cbxCalibre.UseVisualStyleBackColor = True
        '
        'cbxNroPlan
        '
        Me.cbxNroPlan.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxNroPlan.AutoSize = True
        Me.cbxNroPlan.Location = New System.Drawing.Point(703, 4)
        Me.cbxNroPlan.Name = "cbxNroPlan"
        Me.cbxNroPlan.Size = New System.Drawing.Size(67, 17)
        Me.cbxNroPlan.TabIndex = 26
        Me.cbxNroPlan.Text = "Nro Plan"
        Me.cbxNroPlan.UseVisualStyleBackColor = True
        '
        'txtNro
        '
        Me.txtNro.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNro.Location = New System.Drawing.Point(799, 3)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(94, 20)
        Me.txtNro.TabIndex = 27
        '
        'frmProduccion_Movimientos_ActualizarDatosPallets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 447)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmProduccion_Movimientos_ActualizarDatosPallets"
        Me.Text = "[Produccion][Movimientos][Actualizar Datos de Pallets]"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvCabeceraPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.dgvDetallePallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.tlpEdicion.ResumeLayout(False)
        Me.tlpEdicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvCabeceraPallets As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents radEdicionMultiple As System.Windows.Forms.RadioButton
    Friend WithEvents radEdicionIndependiente As System.Windows.Forms.RadioButton
    Friend WithEvents dgvDetallePallets As System.Windows.Forms.DataGridView
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblCoincidencias As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lblSeleccionados As System.Windows.Forms.Label
    Friend WithEvents tlpEdicion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboCalibre As System.Windows.Forms.ComboBox
    Friend WithEvents cboEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents cboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cbxCliente As System.Windows.Forms.CheckBox
    Friend WithEvents cbxEtiqueta As System.Windows.Forms.CheckBox
    Friend WithEvents cbxCalibre As System.Windows.Forms.CheckBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoPallet As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpaque As System.Windows.Forms.TextBox
    Friend WithEvents txtVariedad As System.Windows.Forms.TextBox
    Friend WithEvents txtCultivo As System.Windows.Forms.TextBox
    Friend WithEvents txtCampana As System.Windows.Forms.TextBox
    Friend WithEvents cbxNroPlan As CheckBox
    Friend WithEvents txtNro As TextBox
End Class
