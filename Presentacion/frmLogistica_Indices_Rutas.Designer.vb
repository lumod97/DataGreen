<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogistica_Indices_Rutas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogistica_Indices_Rutas))
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpVuelta = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMasVuelta = New System.Windows.Forms.Button()
        Me.btnMenosVuelta = New System.Windows.Forms.Button()
        Me.cboCiudadVuelta = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboParaderoVuelta = New System.Windows.Forms.ComboBox()
        Me.dtpVuelta = New System.Windows.Forms.DateTimePicker()
        Me.dgvVuelta = New System.Windows.Forms.DataGridView()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.tlpCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.cbxEstado = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboParaderoDestino = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboCiudadDestino = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxIda = New System.Windows.Forms.CheckBox()
        Me.cboParaderoOrigen = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdRuta = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cboCiudadOrigen = New System.Windows.Forms.ComboBox()
        Me.cbxVuelta = New System.Windows.Forms.CheckBox()
        Me.tlpIda = New System.Windows.Forms.TableLayoutPanel()
        Me.cboCiudadIda = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboParaderoIda = New System.Windows.Forms.ComboBox()
        Me.dtpIda = New System.Windows.Forms.DateTimePicker()
        Me.dgvIda = New System.Windows.Forms.DataGridView()
        Me.btnMasIda = New System.Windows.Forms.Button()
        Me.btnMenosIda = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        Me.tlpVuelta.SuspendLayout()
        CType(Me.dgvVuelta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpCabecera.SuspendLayout()
        Me.tlpIda.SuspendLayout()
        CType(Me.dgvIda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 4
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpPrincipal.Controls.Add(Me.tlpVuelta, 2, 5)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.tlpCabecera, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.tlpIda, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label14, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label15, 2, 4)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel1, 1, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 7
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(955, 520)
        Me.tlpPrincipal.TabIndex = 0
        '
        'tlpVuelta
        '
        Me.tlpVuelta.AutoSize = True
        Me.tlpVuelta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpVuelta.ColumnCount = 6
        Me.tlpVuelta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpVuelta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpVuelta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpVuelta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpVuelta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpVuelta.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpVuelta.Controls.Add(Me.btnMasVuelta, 0, 1)
        Me.tlpVuelta.Controls.Add(Me.btnMenosVuelta, 1, 1)
        Me.tlpVuelta.Controls.Add(Me.cboCiudadVuelta, 1, 0)
        Me.tlpVuelta.Controls.Add(Me.Label11, 0, 0)
        Me.tlpVuelta.Controls.Add(Me.Label12, 2, 0)
        Me.tlpVuelta.Controls.Add(Me.Label13, 4, 0)
        Me.tlpVuelta.Controls.Add(Me.cboParaderoVuelta, 3, 0)
        Me.tlpVuelta.Controls.Add(Me.dtpVuelta, 5, 0)
        Me.tlpVuelta.Controls.Add(Me.dgvVuelta, 0, 2)
        Me.tlpVuelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpVuelta.Location = New System.Drawing.Point(477, 314)
        Me.tlpVuelta.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpVuelta.Name = "tlpVuelta"
        Me.tlpVuelta.RowCount = 3
        Me.tlpVuelta.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpVuelta.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpVuelta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpVuelta.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpVuelta.Size = New System.Drawing.Size(462, 190)
        Me.tlpVuelta.TabIndex = 20
        '
        'btnMasVuelta
        '
        Me.btnMasVuelta.Location = New System.Drawing.Point(3, 30)
        Me.btnMasVuelta.Name = "btnMasVuelta"
        Me.btnMasVuelta.Size = New System.Drawing.Size(35, 23)
        Me.btnMasVuelta.TabIndex = 23
        Me.btnMasVuelta.Text = "+"
        Me.btnMasVuelta.UseVisualStyleBackColor = True
        '
        'btnMenosVuelta
        '
        Me.btnMenosVuelta.Location = New System.Drawing.Point(52, 30)
        Me.btnMenosVuelta.Name = "btnMenosVuelta"
        Me.btnMenosVuelta.Size = New System.Drawing.Size(35, 23)
        Me.btnMenosVuelta.TabIndex = 22
        Me.btnMenosVuelta.Text = "-"
        Me.btnMenosVuelta.UseVisualStyleBackColor = True
        '
        'cboCiudadVuelta
        '
        Me.cboCiudadVuelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCiudadVuelta.FormattingEnabled = True
        Me.cboCiudadVuelta.Location = New System.Drawing.Point(52, 3)
        Me.cboCiudadVuelta.Name = "cboCiudadVuelta"
        Me.cboCiudadVuelta.Size = New System.Drawing.Size(99, 21)
        Me.cboCiudadVuelta.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 7)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ciudad:"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(157, 7)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Paradero:"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(321, 7)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Hora:"
        '
        'cboParaderoVuelta
        '
        Me.cboParaderoVuelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboParaderoVuelta.FormattingEnabled = True
        Me.cboParaderoVuelta.Location = New System.Drawing.Point(216, 3)
        Me.cboParaderoVuelta.Name = "cboParaderoVuelta"
        Me.cboParaderoVuelta.Size = New System.Drawing.Size(99, 21)
        Me.cboParaderoVuelta.TabIndex = 17
        '
        'dtpVuelta
        '
        Me.dtpVuelta.CustomFormat = "hh:mm"
        Me.dtpVuelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpVuelta.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpVuelta.Location = New System.Drawing.Point(360, 3)
        Me.dtpVuelta.Name = "dtpVuelta"
        Me.dtpVuelta.ShowUpDown = True
        Me.dtpVuelta.Size = New System.Drawing.Size(99, 20)
        Me.dtpVuelta.TabIndex = 18
        '
        'dgvVuelta
        '
        Me.dgvVuelta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpVuelta.SetColumnSpan(Me.dgvVuelta, 6)
        Me.dgvVuelta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVuelta.Location = New System.Drawing.Point(3, 59)
        Me.dgvVuelta.Name = "dgvVuelta"
        Me.dgvVuelta.RowHeadersWidth = 51
        Me.dgvVuelta.Size = New System.Drawing.Size(456, 128)
        Me.dgvVuelta.TabIndex = 19
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 2)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 107)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.RowHeadersWidth = 51
        Me.dgvResultado.Size = New System.Drawing.Size(918, 184)
        Me.dgvResultado.TabIndex = 11
        '
        'tlpCabecera
        '
        Me.tlpCabecera.AutoSize = True
        Me.tlpCabecera.ColumnCount = 9
        Me.tlpPrincipal.SetColumnSpan(Me.tlpCabecera, 2)
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCabecera.Controls.Add(Me.cbxEstado, 8, 1)
        Me.tlpCabecera.Controls.Add(Me.Label3, 4, 0)
        Me.tlpCabecera.Controls.Add(Me.Label2, 2, 0)
        Me.tlpCabecera.Controls.Add(Me.cboParaderoDestino, 7, 1)
        Me.tlpCabecera.Controls.Add(Me.Label7, 6, 1)
        Me.tlpCabecera.Controls.Add(Me.cboCiudadDestino, 5, 1)
        Me.tlpCabecera.Controls.Add(Me.Label6, 4, 1)
        Me.tlpCabecera.Controls.Add(Me.cbxIda, 0, 1)
        Me.tlpCabecera.Controls.Add(Me.cboParaderoOrigen, 7, 0)
        Me.tlpCabecera.Controls.Add(Me.Label4, 6, 0)
        Me.tlpCabecera.Controls.Add(Me.Label1, 0, 0)
        Me.tlpCabecera.Controls.Add(Me.lblIdRuta, 1, 0)
        Me.tlpCabecera.Controls.Add(Me.txtDescripcion, 3, 0)
        Me.tlpCabecera.Controls.Add(Me.cboCiudadOrigen, 5, 0)
        Me.tlpCabecera.Controls.Add(Me.cbxVuelta, 1, 1)
        Me.tlpCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCabecera.Location = New System.Drawing.Point(15, 50)
        Me.tlpCabecera.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpCabecera.Name = "tlpCabecera"
        Me.tlpCabecera.RowCount = 2
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001!))
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCabecera.Size = New System.Drawing.Size(924, 54)
        Me.tlpCabecera.TabIndex = 16
        '
        'cbxEstado
        '
        Me.cbxEstado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxEstado.AutoSize = True
        Me.cbxEstado.Location = New System.Drawing.Point(865, 31)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(56, 17)
        Me.cbxEstado.TabIndex = 6
        Me.cbxEstado.Text = "Activo"
        Me.cbxEstado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(366, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Origen:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripcion:"
        '
        'cboParaderoDestino
        '
        Me.cboParaderoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboParaderoDestino.FormattingEnabled = True
        Me.cboParaderoDestino.Location = New System.Drawing.Point(688, 29)
        Me.cboParaderoDestino.Name = "cboParaderoDestino"
        Me.cboParaderoDestino.Size = New System.Drawing.Size(171, 21)
        Me.cboParaderoDestino.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(590, 33)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Paradero Destino:"
        '
        'cboCiudadDestino
        '
        Me.cboCiudadDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCiudadDestino.FormattingEnabled = True
        Me.cboCiudadDestino.Location = New System.Drawing.Point(413, 29)
        Me.cboCiudadDestino.Name = "cboCiudadDestino"
        Me.cboCiudadDestino.Size = New System.Drawing.Size(171, 21)
        Me.cboCiudadDestino.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(361, 33)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Destino:"
        '
        'cbxIda
        '
        Me.cbxIda.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxIda.AutoSize = True
        Me.cbxIda.Location = New System.Drawing.Point(3, 31)
        Me.cbxIda.Name = "cbxIda"
        Me.cbxIda.Size = New System.Drawing.Size(41, 17)
        Me.cbxIda.TabIndex = 4
        Me.cbxIda.Text = "Ida"
        Me.cbxIda.UseVisualStyleBackColor = True
        '
        'cboParaderoOrigen
        '
        Me.cboParaderoOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboParaderoOrigen.FormattingEnabled = True
        Me.cboParaderoOrigen.Location = New System.Drawing.Point(688, 3)
        Me.cboParaderoOrigen.Name = "cboParaderoOrigen"
        Me.cboParaderoOrigen.Size = New System.Drawing.Size(171, 21)
        Me.cboParaderoOrigen.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(595, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Paradero Origen:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'lblIdRuta
        '
        Me.lblIdRuta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIdRuta.AutoSize = True
        Me.lblIdRuta.Location = New System.Drawing.Point(50, 6)
        Me.lblIdRuta.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIdRuta.Name = "lblIdRuta"
        Me.lblIdRuta.Size = New System.Drawing.Size(25, 13)
        Me.lblIdRuta.TabIndex = 7
        Me.lblIdRuta.Text = "000"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(184, 3)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(171, 20)
        Me.txtDescripcion.TabIndex = 8
        '
        'cboCiudadOrigen
        '
        Me.cboCiudadOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCiudadOrigen.FormattingEnabled = True
        Me.cboCiudadOrigen.Location = New System.Drawing.Point(413, 3)
        Me.cboCiudadOrigen.Name = "cboCiudadOrigen"
        Me.cboCiudadOrigen.Size = New System.Drawing.Size(171, 21)
        Me.cboCiudadOrigen.TabIndex = 9
        '
        'cbxVuelta
        '
        Me.cbxVuelta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxVuelta.AutoSize = True
        Me.cbxVuelta.Location = New System.Drawing.Point(50, 31)
        Me.cbxVuelta.Name = "cbxVuelta"
        Me.cbxVuelta.Size = New System.Drawing.Size(56, 17)
        Me.cbxVuelta.TabIndex = 5
        Me.cbxVuelta.Text = "Vuelta"
        Me.cbxVuelta.UseVisualStyleBackColor = True
        '
        'tlpIda
        '
        Me.tlpIda.AutoSize = True
        Me.tlpIda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpIda.ColumnCount = 6
        Me.tlpIda.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpIda.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpIda.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpIda.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpIda.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpIda.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpIda.Controls.Add(Me.cboCiudadIda, 1, 0)
        Me.tlpIda.Controls.Add(Me.Label8, 0, 0)
        Me.tlpIda.Controls.Add(Me.Label9, 2, 0)
        Me.tlpIda.Controls.Add(Me.Label10, 4, 0)
        Me.tlpIda.Controls.Add(Me.cboParaderoIda, 3, 0)
        Me.tlpIda.Controls.Add(Me.dtpIda, 5, 0)
        Me.tlpIda.Controls.Add(Me.dgvIda, 0, 2)
        Me.tlpIda.Controls.Add(Me.btnMasIda, 0, 1)
        Me.tlpIda.Controls.Add(Me.btnMenosIda, 1, 1)
        Me.tlpIda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpIda.Location = New System.Drawing.Point(15, 314)
        Me.tlpIda.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpIda.Name = "tlpIda"
        Me.tlpIda.RowCount = 3
        Me.tlpIda.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpIda.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpIda.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpIda.Size = New System.Drawing.Size(462, 190)
        Me.tlpIda.TabIndex = 19
        '
        'cboCiudadIda
        '
        Me.cboCiudadIda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCiudadIda.FormattingEnabled = True
        Me.cboCiudadIda.Location = New System.Drawing.Point(52, 3)
        Me.cboCiudadIda.Name = "cboCiudadIda"
        Me.cboCiudadIda.Size = New System.Drawing.Size(99, 21)
        Me.cboCiudadIda.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 7)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Ciudad:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(157, 7)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Paradero:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(321, 7)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Hora:"
        '
        'cboParaderoIda
        '
        Me.cboParaderoIda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboParaderoIda.FormattingEnabled = True
        Me.cboParaderoIda.Location = New System.Drawing.Point(216, 3)
        Me.cboParaderoIda.Name = "cboParaderoIda"
        Me.cboParaderoIda.Size = New System.Drawing.Size(99, 21)
        Me.cboParaderoIda.TabIndex = 17
        '
        'dtpIda
        '
        Me.dtpIda.CustomFormat = "hh:mm"
        Me.dtpIda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpIda.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpIda.Location = New System.Drawing.Point(360, 3)
        Me.dtpIda.Name = "dtpIda"
        Me.dtpIda.ShowUpDown = True
        Me.dtpIda.Size = New System.Drawing.Size(99, 20)
        Me.dtpIda.TabIndex = 18
        '
        'dgvIda
        '
        Me.dgvIda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpIda.SetColumnSpan(Me.dgvIda, 6)
        Me.dgvIda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIda.Location = New System.Drawing.Point(3, 59)
        Me.dgvIda.Name = "dgvIda"
        Me.dgvIda.RowHeadersWidth = 51
        Me.dgvIda.Size = New System.Drawing.Size(456, 128)
        Me.dgvIda.TabIndex = 19
        '
        'btnMasIda
        '
        Me.btnMasIda.Location = New System.Drawing.Point(3, 30)
        Me.btnMasIda.Name = "btnMasIda"
        Me.btnMasIda.Size = New System.Drawing.Size(35, 23)
        Me.btnMasIda.TabIndex = 20
        Me.btnMasIda.Text = "+"
        Me.btnMasIda.UseVisualStyleBackColor = True
        '
        'btnMenosIda
        '
        Me.btnMenosIda.Location = New System.Drawing.Point(52, 30)
        Me.btnMenosIda.Name = "btnMenosIda"
        Me.btnMenosIda.Size = New System.Drawing.Size(35, 23)
        Me.btnMenosIda.TabIndex = 21
        Me.btnMenosIda.Text = "-"
        Me.btnMenosIda.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 297)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(25, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Ida:"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(480, 297)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Vuelta:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnNuevo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEditar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGuardar, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(456, 29)
        Me.TableLayoutPanel1.TabIndex = 23
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(35, 23)
        Me.btnNuevo.TabIndex = 29
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(44, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(35, 23)
        Me.btnEditar.TabIndex = 19
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.Location = New System.Drawing.Point(85, 3)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(35, 23)
        Me.btnOk.TabIndex = 26
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(126, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(35, 23)
        Me.btnGuardar.TabIndex = 27
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(167, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(35, 23)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmLogistica_Indices_Rutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 520)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmLogistica_Indices_Rutas"
        Me.Text = "Logistica / Indices - Rutas"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.tlpVuelta.ResumeLayout(False)
        Me.tlpVuelta.PerformLayout()
        CType(Me.dgvVuelta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpCabecera.ResumeLayout(False)
        Me.tlpCabecera.PerformLayout()
        Me.tlpIda.ResumeLayout(False)
        Me.tlpIda.PerformLayout()
        CType(Me.dgvIda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIdRuta As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.CheckBox
    Friend WithEvents cbxIda As System.Windows.Forms.CheckBox
    Friend WithEvents cbxVuelta As System.Windows.Forms.CheckBox
    Friend WithEvents cboCiudadOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents cboParaderoOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents tlpCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboParaderoDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCiudadDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tlpIda As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboCiudadIda As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboParaderoIda As System.Windows.Forms.ComboBox
    Friend WithEvents dtpIda As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvIda As System.Windows.Forms.DataGridView
    Friend WithEvents tlpVuelta As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboCiudadVuelta As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboParaderoVuelta As System.Windows.Forms.ComboBox
    Friend WithEvents dtpVuelta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvVuelta As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnMasVuelta As System.Windows.Forms.Button
    Friend WithEvents btnMenosVuelta As System.Windows.Forms.Button
    Friend WithEvents btnMasIda As System.Windows.Forms.Button
    Friend WithEvents btnMenosIda As System.Windows.Forms.Button
End Class
