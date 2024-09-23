<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSupervision_Movimientos_Tareos
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
        Me.cbxEscritorio = New System.Windows.Forms.CheckBox()
        Me.cbxMoviles = New System.Windows.Forms.CheckBox()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.gbxTareo = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDin_NroTareo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDin_Anio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDin_IdTareo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblDin_Responsable = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTurno = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pkrDia = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblDin_Periodo = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblDin_Semana = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbVistaSimplificada = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTransferir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.btnDesaprobar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.gbxFiltrar.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbxTareo.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(1265, 719)
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
        Me.gbxFiltrar.Location = New System.Drawing.Point(18, 129)
        Me.gbxFiltrar.Margin = New System.Windows.Forms.Padding(2)
        Me.gbxFiltrar.Name = "gbxFiltrar"
        Me.gbxFiltrar.Padding = New System.Windows.Forms.Padding(2)
        Me.gbxFiltrar.Size = New System.Drawing.Size(1229, 52)
        Me.gbxFiltrar.TabIndex = 0
        Me.gbxFiltrar.TabStop = False
        Me.gbxFiltrar.Text = "Filtrar"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 11
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
        Me.TableLayoutPanel1.Controls.Add(Me.cbxEscritorio, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbxMoviles, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnConsultar, 10, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 19)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1225, 31)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboEstado
        '
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(689, 2)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(2)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(142, 24)
        Me.cboEstado.TabIndex = 9
        '
        'pkrHasta
        '
        Me.pkrHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrHasta.Location = New System.Drawing.Point(232, 2)
        Me.pkrHasta.Margin = New System.Windows.Forms.Padding(2)
        Me.pkrHasta.Name = "pkrHasta"
        Me.pkrHasta.Size = New System.Drawing.Size(116, 24)
        Me.pkrHasta.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(352, 7)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Responsable:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(629, 7)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Estado:"
        '
        'pkrDesde
        '
        Me.pkrDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDesde.Location = New System.Drawing.Point(58, 2)
        Me.pkrDesde.Margin = New System.Windows.Forms.Padding(2)
        Me.pkrDesde.Name = "pkrDesde"
        Me.pkrDesde.Size = New System.Drawing.Size(116, 24)
        Me.pkrDesde.TabIndex = 6
        '
        'cboResponsable
        '
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(451, 2)
        Me.cboResponsable.Margin = New System.Windows.Forms.Padding(2)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(174, 24)
        Me.cboResponsable.TabIndex = 8
        '
        'cbxEscritorio
        '
        Me.cbxEscritorio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxEscritorio.AutoSize = True
        Me.cbxEscritorio.Location = New System.Drawing.Point(836, 5)
        Me.cbxEscritorio.Name = "cbxEscritorio"
        Me.cbxEscritorio.Size = New System.Drawing.Size(88, 20)
        Me.cbxEscritorio.TabIndex = 10
        Me.cbxEscritorio.Text = "Escritorio"
        Me.cbxEscritorio.UseVisualStyleBackColor = True
        '
        'cbxMoviles
        '
        Me.cbxMoviles.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxMoviles.AutoSize = True
        Me.cbxMoviles.Location = New System.Drawing.Point(930, 5)
        Me.cbxMoviles.Name = "cbxMoviles"
        Me.cbxMoviles.Size = New System.Drawing.Size(78, 20)
        Me.cbxMoviles.TabIndex = 11
        Me.cbxMoviles.Text = "Moviles"
        Me.cbxMoviles.UseVisualStyleBackColor = True
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Location = New System.Drawing.Point(1014, 3)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(104, 25)
        Me.BtnConsultar.TabIndex = 12
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'gbxTareo
        '
        Me.gbxTareo.AutoSize = True
        Me.gbxTareo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gbxTareo.Controls.Add(Me.TableLayoutPanel3)
        Me.gbxTareo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxTareo.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.gbxTareo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.gbxTareo.Location = New System.Drawing.Point(18, 50)
        Me.gbxTareo.Margin = New System.Windows.Forms.Padding(2)
        Me.gbxTareo.Name = "gbxTareo"
        Me.gbxTareo.Padding = New System.Windows.Forms.Padding(2)
        Me.gbxTareo.Size = New System.Drawing.Size(1229, 75)
        Me.gbxTareo.TabIndex = 1
        Me.gbxTareo.TabStop = False
        Me.gbxTareo.Text = "Tareo"
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
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_NroTareo, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Anio, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_IdTareo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnGuardar, 11, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Responsable, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cboTurno, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.pkrDia, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 6, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Periodo, 7, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label17, 8, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDin_Semana, 9, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancelar, 10, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cbVistaSimplificada, 12, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 19)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1225, 54)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'lblDin_NroTareo
        '
        Me.lblDin_NroTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_NroTareo.AutoSize = True
        Me.lblDin_NroTareo.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_NroTareo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_NroTareo.Location = New System.Drawing.Point(314, 2)
        Me.lblDin_NroTareo.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_NroTareo.Name = "lblDin_NroTareo"
        Me.lblDin_NroTareo.Size = New System.Drawing.Size(53, 16)
        Me.lblDin_NroTareo.TabIndex = 5
        Me.lblDin_NroTareo.Text = "00000"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(279, 2)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Nro:"
        '
        'lblDin_Anio
        '
        Me.lblDin_Anio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Anio.AutoSize = True
        Me.lblDin_Anio.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_Anio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_Anio.Location = New System.Drawing.Point(231, 2)
        Me.lblDin_Anio.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_Anio.Name = "lblDin_Anio"
        Me.lblDin_Anio.Size = New System.Drawing.Size(44, 16)
        Me.lblDin_Anio.TabIndex = 3
        Me.lblDin_Anio.Text = "0000"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(194, 2)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Año:"
        '
        'lblDin_IdTareo
        '
        Me.lblDin_IdTareo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_IdTareo.AutoSize = True
        Me.lblDin_IdTareo.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_IdTareo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_IdTareo.Location = New System.Drawing.Point(49, 2)
        Me.lblDin_IdTareo.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_IdTareo.Name = "lblDin_IdTareo"
        Me.lblDin_IdTareo.Size = New System.Drawing.Size(116, 16)
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
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Id:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnGuardar.Location = New System.Drawing.Point(973, 22)
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
        Me.TableLayoutPanel3.SetColumnSpan(Me.lblDin_Responsable, 3)
        Me.lblDin_Responsable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDin_Responsable.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_Responsable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_Responsable.Location = New System.Drawing.Point(473, 2)
        Me.lblDin_Responsable.Margin = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.lblDin_Responsable.Name = "lblDin_Responsable"
        Me.lblDin_Responsable.Size = New System.Drawing.Size(160, 16)
        Me.lblDin_Responsable.TabIndex = 12
        Me.lblDin_Responsable.Text = "00000"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(378, 2)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 16)
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
        Me.Label11.Size = New System.Drawing.Size(47, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Turno:"
        '
        'cboTurno
        '
        Me.cboTurno.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTurno.FormattingEnabled = True
        Me.cboTurno.Location = New System.Drawing.Point(51, 26)
        Me.cboTurno.Margin = New System.Windows.Forms.Padding(2)
        Me.cboTurno.Name = "cboTurno"
        Me.cboTurno.Size = New System.Drawing.Size(139, 24)
        Me.cboTurno.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(198, 29)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Dia:"
        '
        'pkrDia
        '
        Me.pkrDia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TableLayoutPanel3.SetColumnSpan(Me.pkrDia, 3)
        Me.pkrDia.Font = New System.Drawing.Font("Flexo Light", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.pkrDia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDia.Location = New System.Drawing.Point(233, 25)
        Me.pkrDia.Margin = New System.Windows.Forms.Padding(2)
        Me.pkrDia.Name = "pkrDia"
        Me.pkrDia.Size = New System.Drawing.Size(141, 23)
        Me.pkrDia.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(411, 29)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 16)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Periodo:"
        '
        'lblDin_Periodo
        '
        Me.lblDin_Periodo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Periodo.AutoSize = True
        Me.lblDin_Periodo.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_Periodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_Periodo.Location = New System.Drawing.Point(475, 29)
        Me.lblDin_Periodo.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDin_Periodo.Name = "lblDin_Periodo"
        Me.lblDin_Periodo.Size = New System.Drawing.Size(62, 16)
        Me.lblDin_Periodo.TabIndex = 14
        Me.lblDin_Periodo.Text = "000000"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(541, 29)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 16)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Semana:"
        '
        'lblDin_Semana
        '
        Me.lblDin_Semana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Semana.AutoSize = True
        Me.lblDin_Semana.Font = New System.Drawing.Font("Flexo Light", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDin_Semana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.lblDin_Semana.Location = New System.Drawing.Point(607, 29)
        Me.lblDin_Semana.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDin_Semana.Name = "lblDin_Semana"
        Me.lblDin_Semana.Size = New System.Drawing.Size(26, 16)
        Me.lblDin_Semana.TabIndex = 16
        Me.lblDin_Semana.Text = "00"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancelar.Location = New System.Drawing.Point(869, 22)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbVistaSimplificada
        '
        Me.cbVistaSimplificada.AutoSize = True
        Me.cbVistaSimplificada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbVistaSimplificada.Location = New System.Drawing.Point(1078, 23)
        Me.cbVistaSimplificada.Name = "cbVistaSimplificada"
        Me.cbVistaSimplificada.Size = New System.Drawing.Size(144, 28)
        Me.cbVistaSimplificada.TabIndex = 18
        Me.cbVistaSimplificada.Text = "Vista Simplificada"
        Me.cbVistaSimplificada.UseVisualStyleBackColor = True
        Me.cbVistaSimplificada.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnTransferir, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEliminar, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEditar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnNuevo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAprobar, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnDesaprobar, 5, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(18, 17)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1229, 29)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnTransferir
        '
        Me.btnTransferir.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnTransferir.AutoSize = True
        Me.btnTransferir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnTransferir.Location = New System.Drawing.Point(160, 3)
        Me.btnTransferir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(61, 23)
        Me.btnTransferir.TabIndex = 3
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEliminar.AutoSize = True
        Me.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEliminar.Location = New System.Drawing.Point(103, 3)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(53, 23)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditar.AutoSize = True
        Me.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnEditar.Location = New System.Drawing.Point(55, 3)
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(44, 23)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNuevo.AutoSize = True
        Me.btnNuevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnNuevo.Location = New System.Drawing.Point(2, 3)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(49, 23)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAprobar
        '
        Me.btnAprobar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAprobar.AutoSize = True
        Me.btnAprobar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAprobar.Location = New System.Drawing.Point(226, 3)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(54, 23)
        Me.btnAprobar.TabIndex = 4
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'btnDesaprobar
        '
        Me.btnDesaprobar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDesaprobar.AutoSize = True
        Me.btnDesaprobar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDesaprobar.Location = New System.Drawing.Point(286, 3)
        Me.btnDesaprobar.Name = "btnDesaprobar"
        Me.btnDesaprobar.Size = New System.Drawing.Size(72, 23)
        Me.btnDesaprobar.TabIndex = 5
        Me.btnDesaprobar.Text = "Desaprobar"
        Me.btnDesaprobar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 185)
        Me.dgvResultado.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1229, 466)
        Me.dgvResultado.TabIndex = 3
        '
        'barProgreso
        '
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 655)
        Me.barProgreso.Margin = New System.Windows.Forms.Padding(2)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1229, 30)
        Me.barProgreso.TabIndex = 4
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 689)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(45, 13)
        Me.lblDin_Resultado.TabIndex = 5
        Me.lblDin_Resultado.Text = "Label19"
        '
        'frmSupervision_Movimientos_Tareos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1265, 719)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmSupervision_Movimientos_Tareos"
        Me.Text = "[Supervision / Movimientos / Tareos.]"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.gbxFiltrar.ResumeLayout(False)
        Me.gbxFiltrar.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbxTareo.ResumeLayout(False)
        Me.gbxTareo.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
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
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDin_NroTareo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Anio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDin_IdTareo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pkrDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Responsable As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Periodo As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblDin_Semana As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cbxEscritorio As CheckBox
    Friend WithEvents cbxMoviles As CheckBox
    Friend WithEvents btnAprobar As Button
    Friend WithEvents btnDesaprobar As Button
    Friend WithEvents BtnConsultar As Button
    Friend WithEvents cbVistaSimplificada As CheckBox
End Class
