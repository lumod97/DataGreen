<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSupervision_Movimientos_TareosDetalle
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
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.gboFiltrar = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtConsumidor = New System.Windows.Forms.TextBox()
        Me.txtLabor = New System.Windows.Forms.TextBox()
        Me.txtNombresApellidos = New System.Windows.Forms.TextBox()
        Me.txtActividad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gboDetalle = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDin_IdTareo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDin_Item = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboConsumidor = New System.Windows.Forms.ComboBox()
        Me.cboVariedad = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblDin_IdTransferencia = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblDin_Estado = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboActividad = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboLabor = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboMmFin = New System.Windows.Forms.ComboBox()
        Me.cboHhInicio = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboHhFin = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.pkrFin = New System.Windows.Forms.DateTimePicker()
        Me.cboMmInicio = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.txtHoras = New System.Windows.Forms.TextBox()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.radRango = New System.Windows.Forms.RadioButton()
        Me.radHorasFijas = New System.Windows.Forms.RadioButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtRendimiento = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblDin_FechaInicio = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.lblDin_Campana = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnTransferir = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnPuntitos = New System.Windows.Forms.Button()
        Me.txtRutaExcel = New System.Windows.Forms.TextBox()
        Me.btnFormato = New System.Windows.Forms.Button()
        Me.cbxDistribucionAutomatica = New System.Windows.Forms.CheckBox()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.gboFiltrar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gboDetalle.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 3
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.tlpPrincipal.Controls.Add(Me.gboFiltrar, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.gboDetalle, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 6)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Margin = New System.Windows.Forms.Padding(2)
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(1211, 538)
        Me.tlpPrincipal.TabIndex = 0
        '
        'gboFiltrar
        '
        Me.gboFiltrar.AutoSize = True
        Me.gboFiltrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gboFiltrar.Controls.Add(Me.TableLayoutPanel1)
        Me.gboFiltrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboFiltrar.Location = New System.Drawing.Point(21, 194)
        Me.gboFiltrar.Margin = New System.Windows.Forms.Padding(2)
        Me.gboFiltrar.Name = "gboFiltrar"
        Me.gboFiltrar.Padding = New System.Windows.Forms.Padding(2)
        Me.gboFiltrar.Size = New System.Drawing.Size(1169, 43)
        Me.gboFiltrar.TabIndex = 2
        Me.gboFiltrar.TabStop = False
        Me.gboFiltrar.Text = "Filtrar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtConsumidor, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLabor, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNombresApellidos, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtActividad, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 6, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 15)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1165, 26)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtConsumidor
        '
        Me.txtConsumidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConsumidor.Location = New System.Drawing.Point(752, 3)
        Me.txtConsumidor.Name = "txtConsumidor"
        Me.txtConsumidor.Size = New System.Drawing.Size(150, 20)
        Me.txtConsumidor.TabIndex = 3
        '
        'txtLabor
        '
        Me.txtLabor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLabor.Location = New System.Drawing.Point(547, 3)
        Me.txtLabor.Name = "txtLabor"
        Me.txtLabor.Size = New System.Drawing.Size(130, 20)
        Me.txtLabor.TabIndex = 2
        '
        'txtNombresApellidos
        '
        Me.txtNombresApellidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNombresApellidos.Location = New System.Drawing.Point(106, 3)
        Me.txtNombresApellidos.Name = "txtNombresApellidos"
        Me.txtNombresApellidos.Size = New System.Drawing.Size(200, 20)
        Me.txtNombresApellidos.TabIndex = 0
        '
        'txtActividad
        '
        Me.txtActividad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtActividad.Location = New System.Drawing.Point(370, 3)
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(130, 20)
        Me.txtActividad.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(505, 6)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Labor:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(311, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Actividad:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(2, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Nombres/Apellidos:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(682, 6)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Consumidor:"
        '
        'gboDetalle
        '
        Me.gboDetalle.AutoSize = True
        Me.gboDetalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gboDetalle.Controls.Add(Me.TableLayoutPanel3)
        Me.gboDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboDetalle.Location = New System.Drawing.Point(21, 62)
        Me.gboDetalle.Margin = New System.Windows.Forms.Padding(2)
        Me.gboDetalle.Name = "gboDetalle"
        Me.gboDetalle.Padding = New System.Windows.Forms.Padding(2)
        Me.gboDetalle.Size = New System.Drawing.Size(1169, 128)
        Me.gboDetalle.TabIndex = 1
        Me.gboDetalle.TabStop = False
        Me.gboDetalle.Text = "Detalle"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 13
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.90196!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.09804!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_IdTareo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Item, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label16, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboConsumidor, 11, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboVariedad, 5, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_IdTransferencia, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Estado, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label17, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboCultivo, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboActividad, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label20, 6, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboLabor, 7, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnAgregar, 12, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizar, 10, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Campana, 11, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 10, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 10, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 15)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1165, 111)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'lblDin_IdTareo
        '
        Me.lblDin_IdTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_IdTareo.AutoSize = True
        Me.lblDin_IdTareo.ForeColor = System.Drawing.Color.Teal
        Me.lblDin_IdTareo.Location = New System.Drawing.Point(45, 8)
        Me.lblDin_IdTareo.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_IdTareo.Name = "lblDin_IdTareo"
        Me.lblDin_IdTareo.Size = New System.Drawing.Size(79, 13)
        Me.lblDin_IdTareo.TabIndex = 100
        Me.lblDin_IdTareo.Text = "000000000000"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(26, 8)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Id:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(141, 8)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Item:"
        '
        'lblDin_Item
        '
        Me.lblDin_Item.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Item.AutoSize = True
        Me.lblDin_Item.ForeColor = System.Drawing.Color.Teal
        Me.lblDin_Item.Location = New System.Drawing.Point(171, 8)
        Me.lblDin_Item.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_Item.Name = "lblDin_Item"
        Me.lblDin_Item.Size = New System.Drawing.Size(13, 13)
        Me.lblDin_Item.TabIndex = 100
        Me.lblDin_Item.Text = "0"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(230, 37)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Variedad:"
        '
        'cboConsumidor
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.cboConsumidor, 2)
        Me.cboConsumidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboConsumidor.FormattingEnabled = True
        Me.cboConsumidor.Location = New System.Drawing.Point(954, 4)
        Me.cboConsumidor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboConsumidor.Name = "cboConsumidor"
        Me.cboConsumidor.Size = New System.Drawing.Size(208, 21)
        Me.cboConsumidor.TabIndex = 4
        '
        'cboVariedad
        '
        Me.cboVariedad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboVariedad.FormattingEnabled = True
        Me.cboVariedad.Location = New System.Drawing.Point(285, 33)
        Me.cboVariedad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboVariedad.Name = "cboVariedad"
        Me.cboVariedad.Size = New System.Drawing.Size(130, 21)
        Me.cboVariedad.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(2, 37)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 100
        Me.Label13.Text = "Transf.:"
        '
        'lblDin_IdTransferencia
        '
        Me.lblDin_IdTransferencia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_IdTransferencia.AutoSize = True
        Me.lblDin_IdTransferencia.ForeColor = System.Drawing.Color.Teal
        Me.lblDin_IdTransferencia.Location = New System.Drawing.Point(45, 37)
        Me.lblDin_IdTransferencia.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_IdTransferencia.Name = "lblDin_IdTransferencia"
        Me.lblDin_IdTransferencia.Size = New System.Drawing.Size(0, 13)
        Me.lblDin_IdTransferencia.TabIndex = 100
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(128, 37)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Estado:"
        '
        'lblDin_Estado
        '
        Me.lblDin_Estado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Estado.AutoSize = True
        Me.lblDin_Estado.ForeColor = System.Drawing.Color.Crimson
        Me.lblDin_Estado.Location = New System.Drawing.Point(171, 37)
        Me.lblDin_Estado.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_Estado.Name = "lblDin_Estado"
        Me.lblDin_Estado.Size = New System.Drawing.Size(55, 13)
        Me.lblDin_Estado.TabIndex = 100
        Me.lblDin_Estado.Text = "Pendiente"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(240, 8)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "Cultivo:"
        '
        'cboCultivo
        '
        Me.cboCultivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(285, 4)
        Me.cboCultivo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(130, 21)
        Me.cboCultivo.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(420, 8)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "Actividad:"
        '
        'cboActividad
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.cboActividad, 3)
        Me.cboActividad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboActividad.FormattingEnabled = True
        Me.cboActividad.Location = New System.Drawing.Point(477, 4)
        Me.cboActividad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboActividad.Name = "cboActividad"
        Me.cboActividad.Size = New System.Drawing.Size(404, 21)
        Me.cboActividad.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(437, 37)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 100
        Me.Label20.Text = "Labor:"
        '
        'cboLabor
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.cboLabor, 3)
        Me.cboLabor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLabor.FormattingEnabled = True
        Me.cboLabor.Location = New System.Drawing.Point(477, 33)
        Me.cboLabor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboLabor.Name = "cboLabor"
        Me.cboLabor.Size = New System.Drawing.Size(404, 21)
        Me.cboLabor.TabIndex = 3
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Location = New System.Drawing.Point(1082, 72)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(81, 37)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.ColumnCount = 13
        Me.TableLayoutPanel3.SetColumnSpan(Me.TableLayoutPanel4, 10)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.cboMmFin, 11, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cboHhInicio, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label27, 10, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label25, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cboHhFin, 9, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label26, 8, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.pkrFin, 7, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cboMmInicio, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label23, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label21, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtDni, 7, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.txtHoras, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblHoras, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.radRango, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.radHorasFijas, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label29, 4, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.txtRendimiento, 5, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label28, 6, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblDin_FechaInicio, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 58)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(884, 53)
        Me.TableLayoutPanel4.TabIndex = 5
        '
        'cboMmFin
        '
        Me.cboMmFin.FormattingEnabled = True
        Me.cboMmFin.Location = New System.Drawing.Point(658, 3)
        Me.cboMmFin.Name = "cboMmFin"
        Me.cboMmFin.Size = New System.Drawing.Size(60, 21)
        Me.cboMmFin.TabIndex = 6
        '
        'cboHhInicio
        '
        Me.cboHhInicio.FormattingEnabled = True
        Me.cboHhInicio.Location = New System.Drawing.Point(163, 3)
        Me.cboHhInicio.Name = "cboHhInicio"
        Me.cboHhInicio.Size = New System.Drawing.Size(60, 21)
        Me.cboHhInicio.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(628, 7)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(27, 13)
        Me.Label27.TabIndex = 100
        Me.Label27.Text = "Mm:"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(402, 7)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(24, 13)
        Me.Label25.TabIndex = 100
        Me.Label25.Text = "Fin:"
        '
        'cboHhFin
        '
        Me.cboHhFin.FormattingEnabled = True
        Me.cboHhFin.Location = New System.Drawing.Point(563, 3)
        Me.cboHhFin.Name = "cboHhFin"
        Me.cboHhFin.Size = New System.Drawing.Size(60, 21)
        Me.cboHhFin.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(536, 7)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(24, 13)
        Me.Label26.TabIndex = 100
        Me.Label26.Text = "Hh:"
        '
        'pkrFin
        '
        Me.pkrFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrFin.Location = New System.Drawing.Point(429, 3)
        Me.pkrFin.Name = "pkrFin"
        Me.pkrFin.Size = New System.Drawing.Size(102, 20)
        Me.pkrFin.TabIndex = 4
        '
        'cboMmInicio
        '
        Me.cboMmInicio.FormattingEnabled = True
        Me.cboMmInicio.Location = New System.Drawing.Point(300, 3)
        Me.cboMmInicio.Name = "cboMmInicio"
        Me.cboMmInicio.Size = New System.Drawing.Size(60, 21)
        Me.cboMmInicio.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(270, 7)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 13)
        Me.Label23.TabIndex = 100
        Me.Label23.Text = "Mm:"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(136, 7)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 13)
        Me.Label21.TabIndex = 100
        Me.Label21.Text = "Hh:"
        '
        'txtDni
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.txtDni, 6)
        Me.txtDni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDni.Location = New System.Drawing.Point(429, 30)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(452, 20)
        Me.txtDni.TabIndex = 9
        '
        'txtHoras
        '
        Me.txtHoras.Location = New System.Drawing.Point(163, 30)
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.Size = New System.Drawing.Size(60, 20)
        Me.txtHoras.TabIndex = 7
        '
        'lblHoras
        '
        Me.lblHoras.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblHoras.AutoSize = True
        Me.lblHoras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.lblHoras.Location = New System.Drawing.Point(122, 33)
        Me.lblHoras.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(38, 13)
        Me.lblHoras.TabIndex = 100
        Me.lblHoras.Text = "Horas:"
        '
        'radRango
        '
        Me.radRango.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.radRango.AutoSize = True
        Me.radRango.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.radRango.Location = New System.Drawing.Point(3, 5)
        Me.radRango.Name = "radRango"
        Me.radRango.Size = New System.Drawing.Size(57, 17)
        Me.radRango.TabIndex = 0
        Me.radRango.Text = "Rango"
        Me.radRango.UseVisualStyleBackColor = True
        '
        'radHorasFijas
        '
        Me.radHorasFijas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.radHorasFijas.AutoSize = True
        Me.radHorasFijas.Checked = True
        Me.radHorasFijas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.radHorasFijas.Location = New System.Drawing.Point(3, 31)
        Me.radHorasFijas.Name = "radHorasFijas"
        Me.radHorasFijas.Size = New System.Drawing.Size(77, 17)
        Me.radHorasFijas.TabIndex = 1
        Me.radHorasFijas.TabStop = True
        Me.radHorasFijas.Text = "Horas Fijas"
        Me.radHorasFijas.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(228, 33)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 13)
        Me.Label29.TabIndex = 100
        Me.Label29.Text = "Rendimiento:"
        '
        'txtRendimiento
        '
        Me.txtRendimiento.Location = New System.Drawing.Point(300, 30)
        Me.txtRendimiento.Name = "txtRendimiento"
        Me.txtRendimiento.Size = New System.Drawing.Size(60, 20)
        Me.txtRendimiento.TabIndex = 8
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(365, 33)
        Me.Label28.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 13)
        Me.Label28.TabIndex = 100
        Me.Label28.Text = "Trabajador:"
        '
        'lblDin_FechaInicio
        '
        Me.lblDin_FechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDin_FechaInicio.AutoSize = True
        Me.lblDin_FechaInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.lblDin_FechaInicio.Location = New System.Drawing.Point(85, 7)
        Me.lblDin_FechaInicio.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.lblDin_FechaInicio.Name = "lblDin_FechaInicio"
        Me.lblDin_FechaInicio.Size = New System.Drawing.Size(35, 13)
        Me.lblDin_FechaInicio.TabIndex = 100
        Me.lblDin_FechaInicio.Text = "Inicio:"
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.btnActualizar, 2)
        Me.btnActualizar.Location = New System.Drawing.Point(887, 85)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(189, 23)
        Me.btnActualizar.TabIndex = 7
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'lblDin_Campana
        '
        Me.lblDin_Campana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Campana.AutoSize = True
        Me.lblDin_Campana.ForeColor = System.Drawing.Color.Teal
        Me.lblDin_Campana.Location = New System.Drawing.Point(953, 37)
        Me.lblDin_Campana.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDin_Campana.Name = "lblDin_Campana"
        Me.lblDin_Campana.Size = New System.Drawing.Size(31, 13)
        Me.lblDin_Campana.TabIndex = 100
        Me.lblDin_Campana.Text = "2020"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(896, 37)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Campaña:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(886, 8)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Consumidor:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 11
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.btnGuardar, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEliminar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEditar, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnTransferir, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnImportar, 10, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPuntitos, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtRutaExcel, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnFormato, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxDistribucionAutomatica, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAprobar, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnCancelar, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(21, 17)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1169, 41)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(180, 2)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 37)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(91, 2)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(85, 37)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(2, 2)
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(85, 37)
        Me.btnEditar.TabIndex = 0
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnTransferir
        '
        Me.btnTransferir.Enabled = False
        Me.btnTransferir.Location = New System.Drawing.Point(269, 2)
        Me.btnTransferir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(85, 37)
        Me.btnTransferir.TabIndex = 3
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Enabled = False
        Me.btnImportar.Location = New System.Drawing.Point(1089, 15)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(77, 23)
        Me.btnImportar.TabIndex = 4
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnPuntitos
        '
        Me.btnPuntitos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPuntitos.Enabled = False
        Me.btnPuntitos.Location = New System.Drawing.Point(570, 15)
        Me.btnPuntitos.Name = "btnPuntitos"
        Me.btnPuntitos.Size = New System.Drawing.Size(35, 23)
        Me.btnPuntitos.TabIndex = 5
        Me.btnPuntitos.Text = "..."
        Me.btnPuntitos.UseVisualStyleBackColor = True
        '
        'txtRutaExcel
        '
        Me.txtRutaExcel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRutaExcel.Enabled = False
        Me.txtRutaExcel.Location = New System.Drawing.Point(611, 18)
        Me.txtRutaExcel.Name = "txtRutaExcel"
        Me.txtRutaExcel.Size = New System.Drawing.Size(329, 20)
        Me.txtRutaExcel.TabIndex = 6
        '
        'btnFormato
        '
        Me.btnFormato.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFormato.Location = New System.Drawing.Point(529, 9)
        Me.btnFormato.Name = "btnFormato"
        Me.btnFormato.Size = New System.Drawing.Size(35, 23)
        Me.btnFormato.TabIndex = 7
        Me.btnFormato.Text = "?"
        Me.btnFormato.UseVisualStyleBackColor = True
        '
        'cbxDistribucionAutomatica
        '
        Me.cbxDistribucionAutomatica.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxDistribucionAutomatica.AutoSize = True
        Me.cbxDistribucionAutomatica.Location = New System.Drawing.Point(946, 12)
        Me.cbxDistribucionAutomatica.Name = "cbxDistribucionAutomatica"
        Me.cbxDistribucionAutomatica.Size = New System.Drawing.Size(137, 17)
        Me.cbxDistribucionAutomatica.TabIndex = 8
        Me.cbxDistribucionAutomatica.Text = "Distribucion Automatica"
        Me.cbxDistribucionAutomatica.UseVisualStyleBackColor = True
        '
        'btnAprobar
        '
        Me.btnAprobar.Location = New System.Drawing.Point(448, 3)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(75, 23)
        Me.btnAprobar.TabIndex = 10
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(358, 2)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 23)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(21, 241)
        Me.dgvResultado.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1169, 222)
        Me.dgvResultado.TabIndex = 100
        '
        'barProgreso
        '
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(21, 467)
        Me.barProgreso.Margin = New System.Windows.Forms.Padding(2)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1169, 37)
        Me.barProgreso.TabIndex = 100
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.lblDin_Resultado.Location = New System.Drawing.Point(21, 508)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(45, 13)
        Me.lblDin_Resultado.TabIndex = 100
        Me.lblDin_Resultado.Text = "Label19"
        '
        'frmSupervision_Movimientos_TareosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 538)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmSupervision_Movimientos_TareosDetalle"
        Me.Text = "[Supervision / Movimientos / Tareos / Detalle.]"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.gboFiltrar.ResumeLayout(False)
        Me.gboFiltrar.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gboDetalle.ResumeLayout(False)
        Me.gboDetalle.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gboFiltrar As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtConsumidor As System.Windows.Forms.TextBox
    Friend WithEvents txtLabor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombresApellidos As System.Windows.Forms.TextBox
    Friend WithEvents txtActividad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gboDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtDni As System.Windows.Forms.TextBox
    Friend WithEvents lblHoras As System.Windows.Forms.Label
    Friend WithEvents txtHoras As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblDin_IdTareo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Item As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboConsumidor As System.Windows.Forms.ComboBox
    Friend WithEvents cboVariedad As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblDin_IdTransferencia As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Estado As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboActividad As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboLabor As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Campana As System.Windows.Forms.Label
    Friend WithEvents lblDin_FechaInicio As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboHhInicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboMmInicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents pkrFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboHhFin As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboMmFin As System.Windows.Forms.ComboBox
    Friend WithEvents radRango As System.Windows.Forms.RadioButton
    Friend WithEvents radHorasFijas As System.Windows.Forms.RadioButton
    Friend WithEvents txtRendimiento As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnPuntitos As System.Windows.Forms.Button
    Friend WithEvents txtRutaExcel As System.Windows.Forms.TextBox
    Friend WithEvents btnFormato As System.Windows.Forms.Button
    Friend WithEvents cbxDistribucionAutomatica As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As Button
End Class
