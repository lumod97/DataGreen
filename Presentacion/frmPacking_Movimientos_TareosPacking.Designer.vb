<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacking_Movimientos_TareosPacking
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
        Me.gbxFiltrar = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.pkrHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pkrDesde = New System.Windows.Forms.DateTimePicker()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.gbxTareo = New System.Windows.Forms.GroupBox()
        Me.tlpNuevoTareo = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDin_IdTareo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblDin_Responsable = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pkrDia = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGenerarTareo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lbl_Resultado = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.gbxFiltrar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbxTareo.SuspendLayout()
        Me.tlpNuevoTareo.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 3
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.tlpPrincipal.Controls.Add(Me.gbxFiltrar, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.gbxTareo, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lbl_Resultado, 1, 6)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Margin = New System.Windows.Forms.Padding(2)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 8
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1102, 473)
        Me.tlpPrincipal.TabIndex = 1
        '
        'gbxFiltrar
        '
        Me.gbxFiltrar.AutoSize = True
        Me.gbxFiltrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbxFiltrar.Controls.Add(Me.TableLayoutPanel1)
        Me.gbxFiltrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxFiltrar.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbxFiltrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.gbxFiltrar.Location = New System.Drawing.Point(18, 137)
        Me.gbxFiltrar.Margin = New System.Windows.Forms.Padding(2)
        Me.gbxFiltrar.Name = "gbxFiltrar"
        Me.gbxFiltrar.Padding = New System.Windows.Forms.Padding(2)
        Me.gbxFiltrar.Size = New System.Drawing.Size(1066, 49)
        Me.gbxFiltrar.TabIndex = 0
        Me.gbxFiltrar.TabStop = False
        Me.gbxFiltrar.Text = "Filtrar"
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
        Me.TableLayoutPanel1.Controls.Add(Me.cboEstado, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pkrHasta, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pkrDesde, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboResponsable, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 19)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1062, 28)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboEstado
        '
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(685, 2)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(142, 24)
        Me.cboEstado.TabIndex = 9
        '
        'pkrHasta
        '
        Me.pkrHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrHasta.Location = New System.Drawing.Point(230, 2)
        Me.pkrHasta.Margin = New System.Windows.Forms.Padding(2)
        Me.pkrHasta.Name = "pkrHasta"
        Me.pkrHasta.Size = New System.Drawing.Size(116, 24)
        Me.pkrHasta.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(350, 6)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Responsable:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(177, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(626, 6)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Estado:"
        '
        'pkrDesde
        '
        Me.pkrDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDesde.Location = New System.Drawing.Point(57, 2)
        Me.pkrDesde.Margin = New System.Windows.Forms.Padding(2)
        Me.pkrDesde.Name = "pkrDesde"
        Me.pkrDesde.Size = New System.Drawing.Size(116, 24)
        Me.pkrDesde.TabIndex = 6
        '
        'cboResponsable
        '
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(448, 2)
        Me.cboResponsable.Margin = New System.Windows.Forms.Padding(2)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(174, 24)
        Me.cboResponsable.TabIndex = 8
        '
        'gbxTareo
        '
        Me.gbxTareo.AutoSize = True
        Me.gbxTareo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbxTareo.Controls.Add(Me.tlpNuevoTareo)
        Me.gbxTareo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxTareo.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbxTareo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.gbxTareo.Location = New System.Drawing.Point(18, 58)
        Me.gbxTareo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbxTareo.Name = "gbxTareo"
        Me.gbxTareo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbxTareo.Size = New System.Drawing.Size(1066, 75)
        Me.gbxTareo.TabIndex = 1
        Me.gbxTareo.TabStop = False
        Me.gbxTareo.Text = "Tareo"
        '
        'tlpNuevoTareo
        '
        Me.tlpNuevoTareo.AutoSize = True
        Me.tlpNuevoTareo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpNuevoTareo.ColumnCount = 9
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpNuevoTareo.Controls.Add(Me.lblDin_IdTareo, 1, 0)
        Me.tlpNuevoTareo.Controls.Add(Me.Label2, 0, 0)
        Me.tlpNuevoTareo.Controls.Add(Me.btnGuardar, 8, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.lblDin_Responsable, 5, 0)
        Me.tlpNuevoTareo.Controls.Add(Me.Label13, 4, 0)
        Me.tlpNuevoTareo.Controls.Add(Me.Label11, 0, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.cboTurno, 1, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.Label12, 2, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.pkrDia, 3, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.btnCancelar, 7, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.Label4, 4, 1)
        Me.tlpNuevoTareo.Controls.Add(Me.cboCultivo, 5, 1)
        Me.tlpNuevoTareo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpNuevoTareo.Location = New System.Drawing.Point(2, 19)
        Me.tlpNuevoTareo.Margin = New System.Windows.Forms.Padding(2)
        Me.tlpNuevoTareo.Name = "tlpNuevoTareo"
        Me.tlpNuevoTareo.RowCount = 2
        Me.tlpNuevoTareo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpNuevoTareo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpNuevoTareo.Size = New System.Drawing.Size(1062, 54)
        Me.tlpNuevoTareo.TabIndex = 0
        '
        'lblDin_IdTareo
        '
        Me.lblDin_IdTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_IdTareo.AutoSize = True
        Me.lblDin_IdTareo.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_IdTareo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_IdTareo.Location = New System.Drawing.Point(48, 2)
        Me.lblDin_IdTareo.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_IdTareo.Name = "lblDin_IdTareo"
        Me.lblDin_IdTareo.Size = New System.Drawing.Size(115, 16)
        Me.lblDin_IdTareo.TabIndex = 1
        Me.lblDin_IdTareo.Text = "000000000000"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(25, 2)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Id:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Location = New System.Drawing.Point(960, 22)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(100, 30)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblDin_Responsable
        '
        Me.lblDin_Responsable.AutoSize = True
        Me.lblDin_Responsable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDin_Responsable.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_Responsable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_Responsable.Location = New System.Drawing.Point(412, 2)
        Me.lblDin_Responsable.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_Responsable.Name = "lblDin_Responsable"
        Me.lblDin_Responsable.Size = New System.Drawing.Size(154, 16)
        Me.lblDin_Responsable.TabIndex = 12
        Me.lblDin_Responsable.Text = "00000"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(318, 2)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Responsable:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(2, 29)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Turno:"
        '
        'cboTurno
        '
        Me.cboTurno.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Location = New System.Drawing.Point(50, 26)
        Me.cboTurno.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(113, 24)
        Me.cboTurno.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(167, 29)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Dia:"
        '
        'pkrDia
        '
        Me.pkrDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrDia.Font = New System.Drawing.Font("Flexo Light", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.pkrDia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDia.Location = New System.Drawing.Point(201, 25)
        Me.pkrDia.Margin = New System.Windows.Forms.Padding(2)
        Me.pkrDia.Name = "pkrDia"
        Me.pkrDia.Size = New System.Drawing.Size(113, 23)
        Me.pkrDia.TabIndex = 10
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancelar.Location = New System.Drawing.Point(856, 22)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(353, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Cultivo:"
        '
        'cboCultivo
        '
        Me.cboCultivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(415, 26)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(150, 24)
        Me.cboCultivo.TabIndex = 19
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnGenerarTareo, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEliminar, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEditar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnNuevo, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(18, 20)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1066, 34)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnGenerarTareo
        '
        Me.btnGenerarTareo.Location = New System.Drawing.Point(272, 2)
        Me.btnGenerarTareo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGenerarTareo.Name = "btnGenerarTareo"
        Me.btnGenerarTareo.Size = New System.Drawing.Size(86, 30)
        Me.btnGenerarTareo.TabIndex = 3
        Me.btnGenerarTareo.Text = "Generar Tareo"
        Me.btnGenerarTareo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(182, 2)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 30)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(92, 2)
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(86, 30)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(86, 30)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 190)
        Me.dgvResultado.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1066, 212)
        Me.dgvResultado.TabIndex = 3
        '
        'barProgreso
        '
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 406)
        Me.barProgreso.Margin = New System.Windows.Forms.Padding(2)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1066, 30)
        Me.barProgreso.TabIndex = 4
        '
        'lbl_Resultado
        '
        Me.lbl_Resultado.AutoSize = True
        Me.lbl_Resultado.Location = New System.Drawing.Point(18, 440)
        Me.lbl_Resultado.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl_Resultado.Name = "lbl_Resultado"
        Me.lbl_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lbl_Resultado.TabIndex = 5
        Me.lbl_Resultado.Text = "Listo!"
        '
        'frmPacking_Movimientos_TareosPacking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 473)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPacking_Movimientos_TareosPacking"
        Me.Text = "[Packing/Movimientos]-Tareos Packing"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.gbxFiltrar.ResumeLayout(False)
        Me.gbxFiltrar.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbxTareo.ResumeLayout(False)
        Me.gbxTareo.PerformLayout()
        Me.tlpNuevoTareo.ResumeLayout(False)
        Me.tlpNuevoTareo.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbxFiltrar As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents pkrHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pkrDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents gbxTareo As System.Windows.Forms.GroupBox
    Friend WithEvents tlpNuevoTareo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDin_IdTareo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pkrDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Responsable As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGenerarTareo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_Resultado As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cboCultivo As ComboBox
End Class
