<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacking_Movimientos_LecturaEficiencias
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
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.dgvPalletActual = New System.Windows.Forms.DataGridView()
        Me.tlpCajaActual = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPallet_CajAct = New System.Windows.Forms.Label()
        Me.lblNroCaja_CajAct = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSel_CajAct = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPes_CajAct = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblEmp_CajAct = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblResumen = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTGCodigosFaltantes = New System.Windows.Forms.Label()
        Me.lblTGPallets = New System.Windows.Forms.Label()
        Me.lblTGCodigosValidos = New System.Windows.Forms.Label()
        Me.lblTotalPallets = New System.Windows.Forms.Label()
        Me.lblTGCajas = New System.Windows.Forms.Label()
        Me.lblTotalCajas = New System.Windows.Forms.Label()
        Me.lblTotalCodigosValidos = New System.Windows.Forms.Label()
        Me.lblTotalCodigosFaltantes = New System.Windows.Forms.Label()
        Me.pkrDia = New System.Windows.Forms.DateTimePicker()
        Me.btnSincronizar = New System.Windows.Forms.Button()
        Me.btnCerrarPallet = New System.Windows.Forms.Button()
        Me.btnNuevoPallet = New System.Windows.Forms.Button()
        Me.lblDescripcionPalletActual = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tlpCajaAnterior = New System.Windows.Forms.TableLayoutPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblPallet_CajAnt = New System.Windows.Forms.Label()
        Me.lblNroCaja_CajAnt = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblSel_CajAnt = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblPes_CajAnt = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblEmp_CajAnt = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvPalletsPendientes = New System.Windows.Forms.DataGridView()
        Me.dgvPalletsCerrados = New System.Windows.Forms.DataGridView()
        Me.bgwSincronizaLecturas = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPalletActual = New System.Windows.Forms.Label()
        Me.btnLimpiarVariables = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPalletActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpCajaActual.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tlpCajaAnterior.SuspendLayout()
        CType(Me.dgvPalletsPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPalletsCerrados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 6
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.tlpPrincipal.Controls.Add(Me.txtCodigo, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResumen, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.dgvPalletActual, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.tlpCajaActual, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label14, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblResumen, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.Label15, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel1, 1, 8)
        Me.tlpPrincipal.Controls.Add(Me.lblDescripcionPalletActual, 1, 0)
        Me.tlpPrincipal.Controls.Add(Me.Label16, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.tlpCajaAnterior, 4, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 3, 4)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 4, 4)
        Me.tlpPrincipal.Controls.Add(Me.dgvPalletsPendientes, 3, 5)
        Me.tlpPrincipal.Controls.Add(Me.dgvPalletsCerrados, 4, 5)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 9
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.Size = New System.Drawing.Size(978, 513)
        Me.tlpPrincipal.TabIndex = 0
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(54, 22)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(232, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'dgvResumen
        '
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResumen, 4)
        Me.dgvResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResumen.Location = New System.Drawing.Point(5, 362)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.Size = New System.Drawing.Size(959, 118)
        Me.dgvResumen.TabIndex = 2
        '
        'dgvPalletActual
        '
        Me.dgvPalletActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvPalletActual, 2)
        Me.dgvPalletActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPalletActual.Location = New System.Drawing.Point(5, 83)
        Me.dgvPalletActual.Name = "dgvPalletActual"
        Me.tlpPrincipal.SetRowSpan(Me.dgvPalletActual, 3)
        Me.dgvPalletActual.Size = New System.Drawing.Size(281, 254)
        Me.dgvPalletActual.TabIndex = 4
        '
        'tlpCajaActual
        '
        Me.tlpCajaActual.AutoSize = True
        Me.tlpCajaActual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpCajaActual.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpCajaActual.ColumnCount = 5
        Me.tlpCajaActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCajaActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaActual.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaActual.Controls.Add(Me.Label13, 1, 0)
        Me.tlpCajaActual.Controls.Add(Me.Label1, 0, 0)
        Me.tlpCajaActual.Controls.Add(Me.lblPallet_CajAct, 0, 1)
        Me.tlpCajaActual.Controls.Add(Me.lblNroCaja_CajAct, 1, 1)
        Me.tlpCajaActual.Controls.Add(Me.Label7, 2, 0)
        Me.tlpCajaActual.Controls.Add(Me.lblSel_CajAct, 2, 1)
        Me.tlpCajaActual.Controls.Add(Me.Label9, 3, 0)
        Me.tlpCajaActual.Controls.Add(Me.lblPes_CajAct, 3, 1)
        Me.tlpCajaActual.Controls.Add(Me.Label11, 4, 0)
        Me.tlpCajaActual.Controls.Add(Me.lblEmp_CajAct, 4, 1)
        Me.tlpCajaActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCajaActual.Location = New System.Drawing.Point(292, 48)
        Me.tlpCajaActual.Name = "tlpCajaActual"
        Me.tlpCajaActual.RowCount = 2
        Me.tlpPrincipal.SetRowSpan(Me.tlpCajaActual, 2)
        Me.tlpCajaActual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCajaActual.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCajaActual.Size = New System.Drawing.Size(333, 38)
        Me.tlpCajaActual.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(81, 3)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "#"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pallet"
        '
        'lblPallet_CajAct
        '
        Me.lblPallet_CajAct.AutoSize = True
        Me.lblPallet_CajAct.Location = New System.Drawing.Point(3, 22)
        Me.lblPallet_CajAct.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPallet_CajAct.Name = "lblPallet_CajAct"
        Me.lblPallet_CajAct.Size = New System.Drawing.Size(61, 13)
        Me.lblPallet_CajAct.TabIndex = 1
        Me.lblPallet_CajAct.Text = "000000000"
        '
        'lblNroCaja_CajAct
        '
        Me.lblNroCaja_CajAct.AutoSize = True
        Me.lblNroCaja_CajAct.Location = New System.Drawing.Point(81, 22)
        Me.lblNroCaja_CajAct.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNroCaja_CajAct.Name = "lblNroCaja_CajAct"
        Me.lblNroCaja_CajAct.Size = New System.Drawing.Size(13, 13)
        Me.lblNroCaja_CajAct.TabIndex = 2
        Me.lblNroCaja_CajAct.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(101, 3)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Seleccion"
        '
        'lblSel_CajAct
        '
        Me.lblSel_CajAct.AutoSize = True
        Me.lblSel_CajAct.Location = New System.Drawing.Point(101, 22)
        Me.lblSel_CajAct.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSel_CajAct.Name = "lblSel_CajAct"
        Me.lblSel_CajAct.Size = New System.Drawing.Size(67, 13)
        Me.lblSel_CajAct.TabIndex = 4
        Me.lblSel_CajAct.Text = "0000000000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(179, 3)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Pesado"
        '
        'lblPes_CajAct
        '
        Me.lblPes_CajAct.AutoSize = True
        Me.lblPes_CajAct.Location = New System.Drawing.Point(179, 22)
        Me.lblPes_CajAct.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPes_CajAct.Name = "lblPes_CajAct"
        Me.lblPes_CajAct.Size = New System.Drawing.Size(67, 13)
        Me.lblPes_CajAct.TabIndex = 6
        Me.lblPes_CajAct.Text = "0000000000"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(257, 3)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Empaque"
        '
        'lblEmp_CajAct
        '
        Me.lblEmp_CajAct.AutoSize = True
        Me.lblEmp_CajAct.Location = New System.Drawing.Point(257, 22)
        Me.lblEmp_CajAct.Margin = New System.Windows.Forms.Padding(3)
        Me.lblEmp_CajAct.Name = "lblEmp_CajAct"
        Me.lblEmp_CajAct.Size = New System.Drawing.Size(67, 13)
        Me.lblEmp_CajAct.TabIndex = 8
        Me.lblEmp_CajAct.Text = "0000000000"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 29)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Código:"
        '
        'lblResumen
        '
        Me.lblResumen.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblResumen, 2)
        Me.lblResumen.Location = New System.Drawing.Point(5, 343)
        Me.lblResumen.Margin = New System.Windows.Forms.Padding(3)
        Me.lblResumen.Name = "lblResumen"
        Me.lblResumen.Size = New System.Drawing.Size(94, 13)
        Me.lblResumen.TabIndex = 18
        Me.lblResumen.Text = "Resumen X Linea:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(292, 29)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Caja Actual:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 12
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel1, 4)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblTGCodigosFaltantes, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTGPallets, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTGCodigosValidos, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalPallets, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTGCajas, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalCajas, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalCodigosValidos, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalCodigosFaltantes, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pkrDia, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSincronizar, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCerrarPallet, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNuevoPallet, 11, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 483)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(965, 30)
        Me.TableLayoutPanel1.TabIndex = 21
        '
        'lblTGCodigosFaltantes
        '
        Me.lblTGCodigosFaltantes.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTGCodigosFaltantes.AutoSize = True
        Me.lblTGCodigosFaltantes.Location = New System.Drawing.Point(552, 8)
        Me.lblTGCodigosFaltantes.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTGCodigosFaltantes.Name = "lblTGCodigosFaltantes"
        Me.lblTGCodigosFaltantes.Size = New System.Drawing.Size(13, 13)
        Me.lblTGCodigosFaltantes.TabIndex = 7
        Me.lblTGCodigosFaltantes.Text = "0"
        '
        'lblTGPallets
        '
        Me.lblTGPallets.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTGPallets.AutoSize = True
        Me.lblTGPallets.Location = New System.Drawing.Point(53, 8)
        Me.lblTGPallets.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTGPallets.Name = "lblTGPallets"
        Me.lblTGPallets.Size = New System.Drawing.Size(13, 13)
        Me.lblTGPallets.TabIndex = 8
        Me.lblTGPallets.Text = "0"
        '
        'lblTGCodigosValidos
        '
        Me.lblTGCodigosValidos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTGCodigosValidos.AutoSize = True
        Me.lblTGCodigosValidos.Location = New System.Drawing.Point(375, 8)
        Me.lblTGCodigosValidos.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTGCodigosValidos.Name = "lblTGCodigosValidos"
        Me.lblTGCodigosValidos.Size = New System.Drawing.Size(13, 13)
        Me.lblTGCodigosValidos.TabIndex = 6
        Me.lblTGCodigosValidos.Text = "0"
        '
        'lblTotalPallets
        '
        Me.lblTotalPallets.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPallets.AutoSize = True
        Me.lblTotalPallets.Location = New System.Drawing.Point(3, 8)
        Me.lblTotalPallets.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotalPallets.Name = "lblTotalPallets"
        Me.lblTotalPallets.Size = New System.Drawing.Size(44, 13)
        Me.lblTotalPallets.TabIndex = 0
        Me.lblTotalPallets.Text = "Tot Pal:"
        Me.lblTotalPallets.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTGCajas
        '
        Me.lblTGCajas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTGCajas.AutoSize = True
        Me.lblTGCajas.Location = New System.Drawing.Point(200, 8)
        Me.lblTGCajas.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTGCajas.Name = "lblTGCajas"
        Me.lblTGCajas.Size = New System.Drawing.Size(13, 13)
        Me.lblTGCajas.TabIndex = 5
        Me.lblTGCajas.Text = "0"
        '
        'lblTotalCajas
        '
        Me.lblTotalCajas.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCajas.AutoSize = True
        Me.lblTotalCajas.Location = New System.Drawing.Point(156, 8)
        Me.lblTotalCajas.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotalCajas.Name = "lblTotalCajas"
        Me.lblTotalCajas.Size = New System.Drawing.Size(38, 13)
        Me.lblTotalCajas.TabIndex = 1
        Me.lblTotalCajas.Text = "Tot Cj:"
        Me.lblTotalCajas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCodigosValidos
        '
        Me.lblTotalCodigosValidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCodigosValidos.AutoSize = True
        Me.lblTotalCodigosValidos.Location = New System.Drawing.Point(303, 8)
        Me.lblTotalCodigosValidos.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotalCodigosValidos.Name = "lblTotalCodigosValidos"
        Me.lblTotalCodigosValidos.Size = New System.Drawing.Size(66, 13)
        Me.lblTotalCodigosValidos.TabIndex = 3
        Me.lblTotalCodigosValidos.Text = "Tot Cod Vál:"
        Me.lblTotalCodigosValidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCodigosFaltantes
        '
        Me.lblTotalCodigosFaltantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCodigosFaltantes.AutoSize = True
        Me.lblTotalCodigosFaltantes.Location = New System.Drawing.Point(478, 8)
        Me.lblTotalCodigosFaltantes.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotalCodigosFaltantes.Name = "lblTotalCodigosFaltantes"
        Me.lblTotalCodigosFaltantes.Size = New System.Drawing.Size(68, 13)
        Me.lblTotalCodigosFaltantes.TabIndex = 2
        Me.lblTotalCodigosFaltantes.Text = "Tot Cod Falt:"
        Me.lblTotalCodigosFaltantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pkrDia
        '
        Me.pkrDia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pkrDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pkrDia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDia.Location = New System.Drawing.Point(655, 7)
        Me.pkrDia.Name = "pkrDia"
        Me.pkrDia.Size = New System.Drawing.Size(89, 20)
        Me.pkrDia.TabIndex = 25
        '
        'btnSincronizar
        '
        Me.btnSincronizar.Location = New System.Drawing.Point(750, 3)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(60, 23)
        Me.btnSincronizar.TabIndex = 23
        Me.btnSincronizar.Text = "Sinc."
        Me.btnSincronizar.UseVisualStyleBackColor = True
        '
        'btnCerrarPallet
        '
        Me.btnCerrarPallet.Location = New System.Drawing.Point(816, 3)
        Me.btnCerrarPallet.Name = "btnCerrarPallet"
        Me.btnCerrarPallet.Size = New System.Drawing.Size(70, 23)
        Me.btnCerrarPallet.TabIndex = 24
        Me.btnCerrarPallet.Text = "Cerrar"
        Me.btnCerrarPallet.UseVisualStyleBackColor = True
        '
        'btnNuevoPallet
        '
        Me.btnNuevoPallet.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNuevoPallet.Location = New System.Drawing.Point(892, 3)
        Me.btnNuevoPallet.Name = "btnNuevoPallet"
        Me.btnNuevoPallet.Size = New System.Drawing.Size(70, 23)
        Me.btnNuevoPallet.TabIndex = 10
        Me.btnNuevoPallet.Text = "Nuevo"
        Me.btnNuevoPallet.UseVisualStyleBackColor = True
        '
        'lblDescripcionPalletActual
        '
        Me.lblDescripcionPalletActual.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDescripcionPalletActual, 4)
        Me.lblDescripcionPalletActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDescripcionPalletActual.Location = New System.Drawing.Point(5, 3)
        Me.lblDescripcionPalletActual.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDescripcionPalletActual.Name = "lblDescripcionPalletActual"
        Me.lblDescripcionPalletActual.Size = New System.Drawing.Size(959, 13)
        Me.lblDescripcionPalletActual.TabIndex = 22
        Me.lblDescripcionPalletActual.Text = "Pal. Act.:"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(631, 29)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Caja Anterior:"
        '
        'tlpCajaAnterior
        '
        Me.tlpCajaAnterior.AutoSize = True
        Me.tlpCajaAnterior.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpCajaAnterior.BackColor = System.Drawing.Color.Gainsboro
        Me.tlpCajaAnterior.ColumnCount = 5
        Me.tlpCajaAnterior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaAnterior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCajaAnterior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaAnterior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaAnterior.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCajaAnterior.Controls.Add(Me.Label17, 1, 0)
        Me.tlpCajaAnterior.Controls.Add(Me.Label18, 0, 0)
        Me.tlpCajaAnterior.Controls.Add(Me.lblPallet_CajAnt, 0, 1)
        Me.tlpCajaAnterior.Controls.Add(Me.lblNroCaja_CajAnt, 1, 1)
        Me.tlpCajaAnterior.Controls.Add(Me.Label21, 2, 0)
        Me.tlpCajaAnterior.Controls.Add(Me.lblSel_CajAnt, 2, 1)
        Me.tlpCajaAnterior.Controls.Add(Me.Label23, 3, 0)
        Me.tlpCajaAnterior.Controls.Add(Me.lblPes_CajAnt, 3, 1)
        Me.tlpCajaAnterior.Controls.Add(Me.Label25, 4, 0)
        Me.tlpCajaAnterior.Controls.Add(Me.lblEmp_CajAnt, 4, 1)
        Me.tlpCajaAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCajaAnterior.Location = New System.Drawing.Point(631, 48)
        Me.tlpCajaAnterior.Name = "tlpCajaAnterior"
        Me.tlpCajaAnterior.RowCount = 2
        Me.tlpPrincipal.SetRowSpan(Me.tlpCajaAnterior, 2)
        Me.tlpCajaAnterior.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCajaAnterior.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCajaAnterior.Size = New System.Drawing.Size(333, 38)
        Me.tlpCajaAnterior.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(81, 3)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(14, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "#"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 3)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Pallet"
        '
        'lblPallet_CajAnt
        '
        Me.lblPallet_CajAnt.AutoSize = True
        Me.lblPallet_CajAnt.Location = New System.Drawing.Point(3, 22)
        Me.lblPallet_CajAnt.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPallet_CajAnt.Name = "lblPallet_CajAnt"
        Me.lblPallet_CajAnt.Size = New System.Drawing.Size(61, 13)
        Me.lblPallet_CajAnt.TabIndex = 1
        Me.lblPallet_CajAnt.Text = "000000000"
        '
        'lblNroCaja_CajAnt
        '
        Me.lblNroCaja_CajAnt.AutoSize = True
        Me.lblNroCaja_CajAnt.Location = New System.Drawing.Point(81, 22)
        Me.lblNroCaja_CajAnt.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNroCaja_CajAnt.Name = "lblNroCaja_CajAnt"
        Me.lblNroCaja_CajAnt.Size = New System.Drawing.Size(13, 13)
        Me.lblNroCaja_CajAnt.TabIndex = 2
        Me.lblNroCaja_CajAnt.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(101, 3)
        Me.Label21.Margin = New System.Windows.Forms.Padding(3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Seleccion"
        '
        'lblSel_CajAnt
        '
        Me.lblSel_CajAnt.AutoSize = True
        Me.lblSel_CajAnt.Location = New System.Drawing.Point(101, 22)
        Me.lblSel_CajAnt.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSel_CajAnt.Name = "lblSel_CajAnt"
        Me.lblSel_CajAnt.Size = New System.Drawing.Size(67, 13)
        Me.lblSel_CajAnt.TabIndex = 4
        Me.lblSel_CajAnt.Text = "0000000000"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(179, 3)
        Me.Label23.Margin = New System.Windows.Forms.Padding(3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Pesado"
        '
        'lblPes_CajAnt
        '
        Me.lblPes_CajAnt.AutoSize = True
        Me.lblPes_CajAnt.Location = New System.Drawing.Point(179, 22)
        Me.lblPes_CajAnt.Margin = New System.Windows.Forms.Padding(3)
        Me.lblPes_CajAnt.Name = "lblPes_CajAnt"
        Me.lblPes_CajAnt.Size = New System.Drawing.Size(67, 13)
        Me.lblPes_CajAnt.TabIndex = 6
        Me.lblPes_CajAnt.Text = "0000000000"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(257, 3)
        Me.Label25.Margin = New System.Windows.Forms.Padding(3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 13)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Empaque"
        '
        'lblEmp_CajAnt
        '
        Me.lblEmp_CajAnt.AutoSize = True
        Me.lblEmp_CajAnt.Location = New System.Drawing.Point(257, 22)
        Me.lblEmp_CajAnt.Margin = New System.Windows.Forms.Padding(3)
        Me.lblEmp_CajAnt.Name = "lblEmp_CajAnt"
        Me.lblEmp_CajAnt.Size = New System.Drawing.Size(67, 13)
        Me.lblEmp_CajAnt.TabIndex = 8
        Me.lblEmp_CajAnt.Text = "0000000000"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 92)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Pallets Pendientes:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(631, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Pallets Cerrados:"
        '
        'dgvPalletsPendientes
        '
        Me.dgvPalletsPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPalletsPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPalletsPendientes.Location = New System.Drawing.Point(292, 111)
        Me.dgvPalletsPendientes.Name = "dgvPalletsPendientes"
        Me.dgvPalletsPendientes.Size = New System.Drawing.Size(333, 226)
        Me.dgvPalletsPendientes.TabIndex = 5
        '
        'dgvPalletsCerrados
        '
        Me.dgvPalletsCerrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPalletsCerrados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPalletsCerrados.Location = New System.Drawing.Point(631, 111)
        Me.dgvPalletsCerrados.Name = "dgvPalletsCerrados"
        Me.dgvPalletsCerrados.Size = New System.Drawing.Size(333, 226)
        Me.dgvPalletsCerrados.TabIndex = 13
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.lblPalletActual, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnLimpiarVariables, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 48)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(281, 29)
        Me.TableLayoutPanel2.TabIndex = 23
        '
        'lblPalletActual
        '
        Me.lblPalletActual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPalletActual.AutoSize = True
        Me.lblPalletActual.Location = New System.Drawing.Point(3, 8)
        Me.lblPalletActual.Name = "lblPalletActual"
        Me.lblPalletActual.Size = New System.Drawing.Size(69, 13)
        Me.lblPalletActual.TabIndex = 0
        Me.lblPalletActual.Text = "Pallet Actual:"
        '
        'btnLimpiarVariables
        '
        Me.btnLimpiarVariables.Location = New System.Drawing.Point(203, 3)
        Me.btnLimpiarVariables.Name = "btnLimpiarVariables"
        Me.btnLimpiarVariables.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiarVariables.TabIndex = 1
        Me.btnLimpiarVariables.Text = "Limpiar"
        Me.btnLimpiarVariables.UseVisualStyleBackColor = True
        '
        'frmPacking_Movimientos_LecturaEficiencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 513)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPacking_Movimientos_LecturaEficiencias"
        Me.Text = "[Packing][Movimientos] - Lectura de Eficiencias"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPalletActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpCajaActual.ResumeLayout(False)
        Me.tlpCajaActual.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tlpCajaAnterior.ResumeLayout(False)
        Me.tlpCajaAnterior.PerformLayout()
        CType(Me.dgvPalletsPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPalletsCerrados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents dgvResumen As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPalletActual As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPalletsPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNuevoPallet As System.Windows.Forms.Button
    Friend WithEvents tlpCajaActual As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPallet_CajAct As System.Windows.Forms.Label
    Friend WithEvents lblNroCaja_CajAct As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSel_CajAct As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPes_CajAct As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblEmp_CajAct As System.Windows.Forms.Label
    Friend WithEvents dgvPalletsCerrados As System.Windows.Forms.DataGridView
    Friend WithEvents tlpCajaAnterior As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblPallet_CajAnt As System.Windows.Forms.Label
    Friend WithEvents lblNroCaja_CajAnt As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblSel_CajAnt As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblPes_CajAnt As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblEmp_CajAnt As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblResumen As System.Windows.Forms.Label
    Friend WithEvents lblTGCodigosFaltantes As System.Windows.Forms.Label
    Friend WithEvents lblTGCodigosValidos As System.Windows.Forms.Label
    Friend WithEvents lblTGCajas As System.Windows.Forms.Label
    Friend WithEvents lblTotalPallets As System.Windows.Forms.Label
    Friend WithEvents lblTotalCajas As System.Windows.Forms.Label
    Friend WithEvents lblTotalCodigosValidos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCodigosFaltantes As System.Windows.Forms.Label
    Friend WithEvents lblTGPallets As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDescripcionPalletActual As System.Windows.Forms.Label
    Friend WithEvents bgwSincronizaLecturas As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnSincronizar As System.Windows.Forms.Button
    Friend WithEvents btnCerrarPallet As System.Windows.Forms.Button
    Friend WithEvents pkrDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblPalletActual As Label
    Friend WithEvents btnLimpiarVariables As Button
End Class
