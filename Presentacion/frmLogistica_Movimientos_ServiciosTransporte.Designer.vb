<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogistica_Movimientos_ServiciosTransporte
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblTarifa = New System.Windows.Forms.Label()
        Me.lblDscto = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblPlaca = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblConductor = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblNroFactura = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblIdRuta = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblDniConductor = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRuc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblOrdenServicio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblPasajeros = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.txtRazonSocial = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnMoviles = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 12
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.44444!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.77778!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.44444!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblId, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblTarifa, 10, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblDscto, 10, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label25, 9, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label26, 9, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label27, 9, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblTotal, 10, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label23, 7, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblColor, 8, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label21, 7, 4)
        Me.tlpPrincipal.Controls.Add(Me.lblModelo, 8, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label19, 7, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblMarca, 8, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblPlaca, 8, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label13, 7, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label35, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.Label15, 5, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblRuta, 6, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label33, 5, 4)
        Me.tlpPrincipal.Controls.Add(Me.lblConductor, 6, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label14, 5, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblNroFactura, 4, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label38, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label9, 3, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblIdRuta, 4, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label31, 3, 4)
        Me.tlpPrincipal.Controls.Add(Me.lblDniConductor, 4, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label8, 3, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblRuc, 4, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 5, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblOrdenServicio, 6, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label7, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblFecha, 2, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.lblEstado, 2, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblUsuario, 2, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblPasajeros, 10, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label40, 9, 2)
        Me.tlpPrincipal.Controls.Add(Me.lblObservaciones, 2, 6)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 8)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 9)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 10)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label44, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.txtFiltro, 2, 7)
        Me.tlpPrincipal.Controls.Add(Me.txtRazonSocial, 6, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label10, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label6, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpDesde, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpHasta, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnMoviles, 9, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 12
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1015, 519)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(71, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'lblId
        '
        Me.lblId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblId.AutoSize = True
        Me.lblId.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblId.Location = New System.Drawing.Point(96, 53)
        Me.lblId.Margin = New System.Windows.Forms.Padding(3)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(10, 13)
        Me.lblId.TabIndex = 3
        Me.lblId.Text = "."
        '
        'lblTarifa
        '
        Me.lblTarifa.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTarifa.AutoSize = True
        Me.lblTarifa.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTarifa.Location = New System.Drawing.Point(969, 72)
        Me.lblTarifa.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTarifa.Name = "lblTarifa"
        Me.lblTarifa.Size = New System.Drawing.Size(10, 13)
        Me.lblTarifa.TabIndex = 27
        Me.lblTarifa.Text = "."
        '
        'lblDscto
        '
        Me.lblDscto.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblDscto.AutoSize = True
        Me.lblDscto.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblDscto.Location = New System.Drawing.Point(969, 91)
        Me.lblDscto.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDscto.Name = "lblDscto"
        Me.lblDscto.Size = New System.Drawing.Size(10, 13)
        Me.lblDscto.TabIndex = 28
        Me.lblDscto.Text = "."
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(856, 72)
        Me.Label25.Margin = New System.Windows.Forms.Padding(3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 13)
        Me.Label25.TabIndex = 24
        Me.Label25.Text = "Tarifa:"
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(855, 91)
        Me.Label26.Margin = New System.Windows.Forms.Padding(3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 13)
        Me.Label26.TabIndex = 25
        Me.Label26.Text = "Dscto:"
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(859, 110)
        Me.Label27.Margin = New System.Windows.Forms.Padding(3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "Total:"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(969, 110)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(10, 13)
        Me.lblTotal.TabIndex = 29
        Me.lblTotal.Text = "."
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(646, 110)
        Me.Label23.Margin = New System.Windows.Forms.Padding(3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 22
        Me.Label23.Text = "Color:"
        '
        'lblColor
        '
        Me.lblColor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblColor.AutoSize = True
        Me.lblColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblColor.Location = New System.Drawing.Point(686, 110)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(3)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(10, 13)
        Me.lblColor.TabIndex = 23
        Me.lblColor.Text = "."
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(635, 91)
        Me.Label21.Margin = New System.Windows.Forms.Padding(3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 13)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Modelo:"
        '
        'lblModelo
        '
        Me.lblModelo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblModelo.AutoSize = True
        Me.lblModelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblModelo.Location = New System.Drawing.Point(686, 91)
        Me.lblModelo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(10, 13)
        Me.lblModelo.TabIndex = 21
        Me.lblModelo.Text = "."
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(640, 72)
        Me.Label19.Margin = New System.Windows.Forms.Padding(3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 13)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Marca:"
        '
        'lblMarca
        '
        Me.lblMarca.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblMarca.AutoSize = True
        Me.lblMarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMarca.Location = New System.Drawing.Point(686, 72)
        Me.lblMarca.Margin = New System.Windows.Forms.Padding(3)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(10, 13)
        Me.lblMarca.TabIndex = 19
        Me.lblMarca.Text = "."
        '
        'lblPlaca
        '
        Me.lblPlaca.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPlaca.AutoSize = True
        Me.lblPlaca.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblPlaca.Location = New System.Drawing.Point(686, 53)
        Me.lblPlaca.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPlaca.Name = "lblPlaca"
        Me.lblPlaca.Size = New System.Drawing.Size(10, 13)
        Me.lblPlaca.TabIndex = 15
        Me.lblPlaca.Text = "."
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(643, 53)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Placa:"
        '
        'Label35
        '
        Me.Label35.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(20, 129)
        Me.Label35.Margin = New System.Windows.Forms.Padding(3)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "Observacion:"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(343, 110)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Ruta:"
        '
        'lblRuta
        '
        Me.lblRuta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRuta.AutoSize = True
        Me.lblRuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblRuta.Location = New System.Drawing.Point(382, 110)
        Me.lblRuta.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(10, 13)
        Me.lblRuta.TabIndex = 17
        Me.lblRuta.Text = "."
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(317, 91)
        Me.Label33.Margin = New System.Windows.Forms.Padding(3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(59, 13)
        Me.Label33.TabIndex = 32
        Me.Label33.Text = "Conductor:"
        '
        'lblConductor
        '
        Me.lblConductor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblConductor.AutoSize = True
        Me.lblConductor.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblConductor.Location = New System.Drawing.Point(382, 91)
        Me.lblConductor.Margin = New System.Windows.Forms.Padding(3)
        Me.lblConductor.Name = "lblConductor"
        Me.lblConductor.Size = New System.Drawing.Size(10, 13)
        Me.lblConductor.TabIndex = 33
        Me.lblConductor.Text = "."
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(319, 72)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Raz. Soc.:"
        '
        'lblNroFactura
        '
        Me.lblNroFactura.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNroFactura.AutoSize = True
        Me.lblNroFactura.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblNroFactura.Location = New System.Drawing.Point(247, 53)
        Me.lblNroFactura.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNroFactura.Name = "lblNroFactura"
        Me.lblNroFactura.Size = New System.Drawing.Size(10, 13)
        Me.lblNroFactura.TabIndex = 39
        Me.lblNroFactura.Text = "."
        '
        'Label38
        '
        Me.Label38.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(172, 53)
        Me.Label38.Margin = New System.Windows.Forms.Padding(3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(69, 13)
        Me.Label38.TabIndex = 38
        Me.Label38.Text = "Nro. Factura:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(196, 110)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Id Ruta:"
        '
        'lblIdRuta
        '
        Me.lblIdRuta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIdRuta.AutoSize = True
        Me.lblIdRuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblIdRuta.Location = New System.Drawing.Point(247, 110)
        Me.lblIdRuta.Margin = New System.Windows.Forms.Padding(3)
        Me.lblIdRuta.Name = "lblIdRuta"
        Me.lblIdRuta.Size = New System.Drawing.Size(10, 13)
        Me.lblIdRuta.TabIndex = 11
        Me.lblIdRuta.Text = "."
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(184, 91)
        Me.Label31.Margin = New System.Windows.Forms.Padding(3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 13)
        Me.Label31.TabIndex = 30
        Me.Label31.Text = "Dni Cond.:"
        '
        'lblDniConductor
        '
        Me.lblDniConductor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDniConductor.AutoSize = True
        Me.lblDniConductor.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblDniConductor.Location = New System.Drawing.Point(247, 91)
        Me.lblDniConductor.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDniConductor.Name = "lblDniConductor"
        Me.lblDniConductor.Size = New System.Drawing.Size(10, 13)
        Me.lblDniConductor.TabIndex = 31
        Me.lblDniConductor.Text = "."
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(211, 72)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Ruc:"
        '
        'lblRuc
        '
        Me.lblRuc.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblRuc.AutoSize = True
        Me.lblRuc.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblRuc.Location = New System.Drawing.Point(247, 72)
        Me.lblRuc.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRuc.Name = "lblRuc"
        Me.lblRuc.Size = New System.Drawing.Size(10, 13)
        Me.lblRuc.TabIndex = 10
        Me.lblRuc.Text = "."
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(351, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "OS:"
        '
        'lblOrdenServicio
        '
        Me.lblOrdenServicio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrdenServicio.AutoSize = True
        Me.lblOrdenServicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblOrdenServicio.Location = New System.Drawing.Point(382, 53)
        Me.lblOrdenServicio.Margin = New System.Windows.Forms.Padding(3)
        Me.lblOrdenServicio.Name = "lblOrdenServicio"
        Me.lblOrdenServicio.Size = New System.Drawing.Size(10, 13)
        Me.lblOrdenServicio.TabIndex = 35
        Me.lblOrdenServicio.Text = "."
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(50, 72)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha:"
        '
        'lblFecha
        '
        Me.lblFecha.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(96, 72)
        Me.lblFecha.Margin = New System.Windows.Forms.Padding(3)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(10, 13)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.Text = "."
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(47, 91)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Estado:"
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(96, 91)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(10, 13)
        Me.lblEstado.TabIndex = 5
        Me.lblEstado.Text = "."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(18, 110)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Responsable:"
        '
        'lblUsuario
        '
        Me.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblUsuario.Location = New System.Drawing.Point(96, 110)
        Me.lblUsuario.Margin = New System.Windows.Forms.Padding(3)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(10, 13)
        Me.lblUsuario.TabIndex = 37
        Me.lblUsuario.Text = "."
        '
        'lblPasajeros
        '
        Me.lblPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblPasajeros.AutoSize = True
        Me.lblPasajeros.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblPasajeros.Location = New System.Drawing.Point(969, 53)
        Me.lblPasajeros.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPasajeros.Name = "lblPasajeros"
        Me.lblPasajeros.Size = New System.Drawing.Size(10, 13)
        Me.lblPasajeros.TabIndex = 41
        Me.lblPasajeros.Text = "."
        '
        'Label40
        '
        Me.Label40.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(837, 53)
        Me.Label40.Margin = New System.Windows.Forms.Padding(3)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(56, 13)
        Me.Label40.TabIndex = 40
        Me.Label40.Text = "Pasajeros:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.tlpPrincipal.SetColumnSpan(Me.lblObservaciones, 9)
        Me.lblObservaciones.Location = New System.Drawing.Point(96, 129)
        Me.lblObservaciones.Margin = New System.Windows.Forms.Padding(3)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(10, 13)
        Me.lblObservaciones.TabIndex = 42
        Me.lblObservaciones.Text = "."
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 10)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 174)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(961, 279)
        Me.dgvResultado.TabIndex = 44
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 10)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 459)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(961, 23)
        Me.barProgreso.TabIndex = 45
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 488)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 46
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel1, 3)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnNuevo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAbrir, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEliminar, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(223, 29)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(65, 23)
        Me.btnNuevo.TabIndex = 43
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(74, 3)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(65, 23)
        Me.btnAbrir.TabIndex = 44
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(145, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(65, 23)
        Me.btnEliminar.TabIndex = 45
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(58, 151)
        Me.Label44.Margin = New System.Windows.Forms.Padding(3)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(32, 13)
        Me.Label44.TabIndex = 48
        Me.Label44.Text = "Filtro:"
        '
        'txtFiltro
        '
        Me.tlpPrincipal.SetColumnSpan(Me.txtFiltro, 9)
        Me.txtFiltro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFiltro.Location = New System.Drawing.Point(96, 148)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(883, 20)
        Me.txtFiltro.TabIndex = 49
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRazonSocial.AutoSize = True
        Me.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtRazonSocial.Location = New System.Drawing.Point(382, 72)
        Me.txtRazonSocial.Margin = New System.Windows.Forms.Padding(3)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(10, 13)
        Me.txtRazonSocial.TabIndex = 51
        Me.txtRazonSocial.Text = "."
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(635, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Hasta:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(899, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(80, 23)
        Me.btnConsultar.TabIndex = 55
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(317, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Desde:"
        '
        'dtpDesde
        '
        Me.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(382, 22)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(123, 20)
        Me.dtpDesde.TabIndex = 56
        '
        'dtpHasta
        '
        Me.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(686, 22)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(117, 20)
        Me.dtpHasta.TabIndex = 57
        '
        'btnMoviles
        '
        Me.btnMoviles.Location = New System.Drawing.Point(815, 18)
        Me.btnMoviles.Name = "btnMoviles"
        Me.btnMoviles.Size = New System.Drawing.Size(78, 23)
        Me.btnMoviles.TabIndex = 58
        Me.btnMoviles.Text = "Moviles"
        Me.btnMoviles.UseVisualStyleBackColor = True
        '
        'frmLogistica_Movimientos_ServiciosTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 519)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmLogistica_Movimientos_ServiciosTransporte"
        Me.Text = "Logistica / Movimientos - Servicios de Transporte"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblTarifa As System.Windows.Forms.Label
    Friend WithEvents lblDscto As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblModelo As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblPlaca As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblConductor As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNroFactura As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblIdRuta As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblDniConductor As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblRuc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblOrdenServicio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblPasajeros As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnMoviles As Button
    Friend WithEvents dtpDesde As DateTimePicker
End Class
