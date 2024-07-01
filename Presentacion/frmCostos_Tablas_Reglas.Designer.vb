<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostos_Tablas_Reglas
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
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.grpBuscar = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoCosto_Buscar = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCultivo_Buscar = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grpGestionar = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.grpEditar = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboCuenta = New System.Windows.Forms.ComboBox()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.cboCCFijo = New System.Windows.Forms.ComboBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboCGI = New System.Windows.Forms.ComboBox()
        Me.lblCGI = New System.Windows.Forms.Label()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel13 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cboActividad = New System.Windows.Forms.ComboBox()
        Me.cboCultivo_Editar = New System.Windows.Forms.ComboBox()
        Me.lblCultivo = New System.Windows.Forms.Label()
        Me.cboTipoCampana = New System.Windows.Forms.ComboBox()
        Me.lblTipoCampana = New System.Windows.Forms.Label()
        Me.cboTipoCosto_Editar = New System.Windows.Forms.ComboBox()
        Me.lblTipoCosto = New System.Windows.Forms.Label()
        Me.lblActividad = New System.Windows.Forms.Label()
        Me.lblCCFijo = New System.Windows.Forms.Label()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout
        CType(Me.dgvResultado,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpBuscar.SuspendLayout
        Me.FlowLayoutPanel1.SuspendLayout
        Me.grpGestionar.SuspendLayout
        Me.FlowLayoutPanel2.SuspendLayout
        Me.grpEditar.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.FlowLayoutPanel13.SuspendLayout
        Me.SuspendLayout
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 4
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16!))
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.grpBuscar, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.grpGestionar, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.grpEditar, 1, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Font = New System.Drawing.Font("mononoki", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 7
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1015, 500)
        Me.tlpPrincipal.TabIndex = 0
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 2)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 185)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResultado.Size = New System.Drawing.Size(978, 258)
        Me.dgvResultado.TabIndex = 19
        '
        'grpBuscar
        '
        Me.grpBuscar.AutoSize = True
        Me.grpBuscar.Controls.Add(Me.FlowLayoutPanel1)
        Me.grpBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpBuscar.Location = New System.Drawing.Point(18, 23)
        Me.grpBuscar.Name = "grpBuscar"
        Me.grpBuscar.Size = New System.Drawing.Size(486, 48)
        Me.grpBuscar.TabIndex = 1
        Me.grpBuscar.TabStop = False
        Me.grpBuscar.Text = "Buscar"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboTipoCosto_Buscar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboCultivo_Buscar)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnBuscar)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(480, 29)
        Me.FlowLayoutPanel1.TabIndex = 0
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Costo:"
        '
        'cboTipoCosto_Buscar
        '
        Me.cboTipoCosto_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTipoCosto_Buscar.FormattingEnabled = True
        Me.cboTipoCosto_Buscar.Location = New System.Drawing.Point(100, 4)
        Me.cboTipoCosto_Buscar.Name = "cboTipoCosto_Buscar"
        Me.cboTipoCosto_Buscar.Size = New System.Drawing.Size(118, 21)
        Me.cboTipoCosto_Buscar.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(224, 8)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cultivo:"
        '
        'cboCultivo_Buscar
        '
        Me.cboCultivo_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCultivo_Buscar.FormattingEnabled = True
        Me.cboCultivo_Buscar.Location = New System.Drawing.Point(285, 4)
        Me.cboCultivo_Buscar.Name = "cboCultivo_Buscar"
        Me.cboCultivo_Buscar.Size = New System.Drawing.Size(150, 21)
        Me.cboCultivo_Buscar.TabIndex = 2
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(441, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'grpGestionar
        '
        Me.grpGestionar.AutoSize = True
        Me.grpGestionar.Controls.Add(Me.FlowLayoutPanel2)
        Me.grpGestionar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpGestionar.Location = New System.Drawing.Point(510, 23)
        Me.grpGestionar.Name = "grpGestionar"
        Me.grpGestionar.Size = New System.Drawing.Size(486, 48)
        Me.grpGestionar.TabIndex = 3
        Me.grpGestionar.TabStop = False
        Me.grpGestionar.Text = "Gestionar"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.Controls.Add(Me.btnNuevo)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnEditar)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnEliminar)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(480, 29)
        Me.FlowLayoutPanel2.TabIndex = 0
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(84, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 5
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(165, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 2)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 468)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(978, 14)
        Me.barProgreso.TabIndex = 6
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(18, 449)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(43, 13)
        Me.lblResultado.TabIndex = 7
        Me.lblResultado.Text = "Listo!"
        '
        'grpEditar
        '
        Me.grpEditar.AutoSize = True
        Me.grpEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpPrincipal.SetColumnSpan(Me.grpEditar, 2)
        Me.grpEditar.Controls.Add(Me.TableLayoutPanel1)
        Me.grpEditar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpEditar.Enabled = False
        Me.grpEditar.Location = New System.Drawing.Point(18, 77)
        Me.grpEditar.Name = "grpEditar"
        Me.grpEditar.Size = New System.Drawing.Size(978, 102)
        Me.grpEditar.TabIndex = 8
        Me.grpEditar.TabStop = False
        Me.grpEditar.Text = "Editar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboCuenta, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCuenta, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCCFijo, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboGrupo, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipo, 12, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTipo, 11, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCGI, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCGI, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboDivision, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel13, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDivision, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboActividad, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCultivo_Editar, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCultivo, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoCampana, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTipoCampana, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoCosto_Editar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTipoCosto, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblActividad, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCCFijo, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGrupo, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(972, 83)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboCuenta
        '
        Me.cboCuenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCuenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboCuenta, 5)
        Me.cboCuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCuenta.Enabled = False
        Me.cboCuenta.FormattingEnabled = True
        Me.cboCuenta.Location = New System.Drawing.Point(112, 57)
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.Size = New System.Drawing.Size(488, 21)
        Me.cboCuenta.TabIndex = 16
        '
        'lblCuenta
        '
        Me.lblCuenta.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(57, 62)
        Me.lblCuenta.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(49, 13)
        Me.lblCuenta.TabIndex = 0
        Me.lblCuenta.Text = "Cuenta:"
        '
        'cboCCFijo
        '
        Me.cboCCFijo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCCFijo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboCCFijo, 6)
        Me.cboCCFijo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCCFijo.FormattingEnabled = True
        Me.cboCCFijo.Location = New System.Drawing.Point(679, 30)
        Me.cboCCFijo.Name = "cboCCFijo"
        Me.cboCCFijo.Size = New System.Drawing.Size(290, 21)
        Me.cboCCFijo.TabIndex = 15
        '
        'cboGrupo
        '
        Me.cboGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboGrupo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboGrupo.Enabled = False
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(428, 30)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(172, 21)
        Me.cboGrupo.TabIndex = 14
        '
        'cboTipo
        '
        Me.cboTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(937, 3)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(32, 21)
        Me.cboTipo.TabIndex = 12
        '
        'lblTipo
        '
        Me.lblTipo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(894, 7)
        Me.lblTipo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(37, 13)
        Me.lblTipo.TabIndex = 0
        Me.lblTipo.Text = "Tipo:"
        '
        'cboCGI
        '
        Me.cboCGI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCGI.FormattingEnabled = True
        Me.cboCGI.Location = New System.Drawing.Point(859, 3)
        Me.cboCGI.Name = "cboCGI"
        Me.cboCGI.Size = New System.Drawing.Size(29, 21)
        Me.cboCGI.TabIndex = 11
        '
        'lblCGI
        '
        Me.lblCGI.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCGI.AutoSize = True
        Me.lblCGI.Location = New System.Drawing.Point(822, 7)
        Me.lblCGI.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCGI.Name = "lblCGI"
        Me.lblCGI.Size = New System.Drawing.Size(31, 13)
        Me.lblCGI.TabIndex = 0
        Me.lblCGI.Text = "CGI:"
        '
        'cboDivision
        '
        Me.cboDivision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(746, 3)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(70, 21)
        Me.cboDivision.TabIndex = 10
        '
        'FlowLayoutPanel13
        '
        Me.FlowLayoutPanel13.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.FlowLayoutPanel13, 6)
        Me.FlowLayoutPanel13.Controls.Add(Me.btnCancelar)
        Me.FlowLayoutPanel13.Controls.Add(Me.btnGuardar)
        Me.FlowLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel13.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel13.Location = New System.Drawing.Point(679, 54)
        Me.FlowLayoutPanel13.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.FlowLayoutPanel13.Name = "FlowLayoutPanel13"
        Me.FlowLayoutPanel13.Size = New System.Drawing.Size(290, 29)
        Me.FlowLayoutPanel13.TabIndex = 20
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelar.Location = New System.Drawing.Point(212, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Location = New System.Drawing.Point(131, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblDivision
        '
        Me.lblDivision.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(679, 7)
        Me.lblDivision.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(61, 13)
        Me.lblDivision.TabIndex = 0
        Me.lblDivision.Text = "Division:"
        '
        'cboActividad
        '
        Me.cboActividad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboActividad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboActividad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboActividad.FormattingEnabled = True
        Me.cboActividad.Location = New System.Drawing.Point(428, 3)
        Me.cboActividad.Name = "cboActividad"
        Me.cboActividad.Size = New System.Drawing.Size(172, 21)
        Me.cboActividad.TabIndex = 9
        '
        'cboCultivo_Editar
        '
        Me.cboCultivo_Editar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCultivo_Editar.FormattingEnabled = True
        Me.cboCultivo_Editar.Location = New System.Drawing.Point(254, 3)
        Me.cboCultivo_Editar.Name = "cboCultivo_Editar"
        Me.cboCultivo_Editar.Size = New System.Drawing.Size(95, 21)
        Me.cboCultivo_Editar.TabIndex = 8
        '
        'lblCultivo
        '
        Me.lblCultivo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCultivo.AutoSize = True
        Me.lblCultivo.Location = New System.Drawing.Point(193, 7)
        Me.lblCultivo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCultivo.Name = "lblCultivo"
        Me.lblCultivo.Size = New System.Drawing.Size(55, 13)
        Me.lblCultivo.TabIndex = 0
        Me.lblCultivo.Text = "Cultivo:"
        '
        'cboTipoCampana
        '
        Me.cboTipoCampana.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTipoCampana.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTipoCampana, 3)
        Me.cboTipoCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTipoCampana.FormattingEnabled = True
        Me.cboTipoCampana.Location = New System.Drawing.Point(112, 30)
        Me.cboTipoCampana.Name = "cboTipoCampana"
        Me.cboTipoCampana.Size = New System.Drawing.Size(237, 21)
        Me.cboTipoCampana.TabIndex = 13
        '
        'lblTipoCampana
        '
        Me.lblTipoCampana.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTipoCampana.AutoSize = True
        Me.lblTipoCampana.Location = New System.Drawing.Point(3, 34)
        Me.lblTipoCampana.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTipoCampana.Name = "lblTipoCampana"
        Me.lblTipoCampana.Size = New System.Drawing.Size(103, 13)
        Me.lblTipoCampana.TabIndex = 0
        Me.lblTipoCampana.Text = "Tipo de Campaña:"
        '
        'cboTipoCosto_Editar
        '
        Me.cboTipoCosto_Editar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTipoCosto_Editar.FormattingEnabled = True
        Me.cboTipoCosto_Editar.Location = New System.Drawing.Point(112, 3)
        Me.cboTipoCosto_Editar.Name = "cboTipoCosto_Editar"
        Me.cboTipoCosto_Editar.Size = New System.Drawing.Size(75, 21)
        Me.cboTipoCosto_Editar.TabIndex = 7
        '
        'lblTipoCosto
        '
        Me.lblTipoCosto.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTipoCosto.AutoSize = True
        Me.lblTipoCosto.Location = New System.Drawing.Point(15, 7)
        Me.lblTipoCosto.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTipoCosto.Name = "lblTipoCosto"
        Me.lblTipoCosto.Size = New System.Drawing.Size(91, 13)
        Me.lblTipoCosto.TabIndex = 0
        Me.lblTipoCosto.Text = "Tipo de Costo:"
        '
        'lblActividad
        '
        Me.lblActividad.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblActividad.AutoSize = True
        Me.lblActividad.Location = New System.Drawing.Point(355, 7)
        Me.lblActividad.Margin = New System.Windows.Forms.Padding(3)
        Me.lblActividad.Name = "lblActividad"
        Me.lblActividad.Size = New System.Drawing.Size(67, 13)
        Me.lblActividad.TabIndex = 0
        Me.lblActividad.Text = "Actividad:"
        '
        'lblCCFijo
        '
        Me.lblCCFijo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCCFijo.AutoSize = True
        Me.lblCCFijo.Location = New System.Drawing.Point(606, 34)
        Me.lblCCFijo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCCFijo.Name = "lblCCFijo"
        Me.lblCCFijo.Size = New System.Drawing.Size(67, 13)
        Me.lblCCFijo.TabIndex = 0
        Me.lblCCFijo.Text = "C.C. Fijo:"
        '
        'lblGrupo
        '
        Me.lblGrupo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(379, 34)
        Me.lblGrupo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(43, 13)
        Me.lblGrupo.TabIndex = 0
        Me.lblGrupo.Text = "Grupo:"
        '
        'frmCostos_Tablas_Reglas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 500)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmCostos_Tablas_Reglas"
        Me.Text = "Costos / Tablas - Reglas"
        Me.tlpPrincipal.ResumeLayout(false)
        Me.tlpPrincipal.PerformLayout
        CType(Me.dgvResultado,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpBuscar.ResumeLayout(false)
        Me.grpBuscar.PerformLayout
        Me.FlowLayoutPanel1.ResumeLayout(false)
        Me.FlowLayoutPanel1.PerformLayout
        Me.grpGestionar.ResumeLayout(false)
        Me.grpGestionar.PerformLayout
        Me.FlowLayoutPanel2.ResumeLayout(false)
        Me.grpEditar.ResumeLayout(false)
        Me.grpEditar.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.FlowLayoutPanel13.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents lblTipoCosto As System.Windows.Forms.Label
    Friend WithEvents cboTipoCosto_Editar As System.Windows.Forms.ComboBox
    Friend WithEvents lblCultivo As System.Windows.Forms.Label
    Friend WithEvents cboCultivo_Editar As System.Windows.Forms.ComboBox
    Friend WithEvents lblActividad As System.Windows.Forms.Label
    Friend WithEvents cboActividad As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents cboDivision As System.Windows.Forms.ComboBox
    Friend WithEvents lblCGI As System.Windows.Forms.Label
    Friend WithEvents cboCGI As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoCampana As System.Windows.Forms.Label
    Friend WithEvents cboTipoCampana As System.Windows.Forms.ComboBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCCFijo As System.Windows.Forms.Label
    Friend WithEvents cboCCFijo As System.Windows.Forms.ComboBox
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel13 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grpEditar As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grpBuscar As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCosto_Buscar As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCultivo_Buscar As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grpGestionar As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents cboCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
End Class
