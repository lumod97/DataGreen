<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogistica_Movimientos_ServiciosTransporte_Detalle
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
        Me.radDetallePersona = New System.Windows.Forms.RadioButton()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnFormato = New System.Windows.Forms.Button()
        Me.btnPuntitos = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnDistribuirCostos = New System.Windows.Forms.Button()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblRedondeo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTarifa = New System.Windows.Forms.TextBox()
        Me.txtDscto = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblTotalPasajeros = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMenos = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboConsumidor = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantidadPasajeros = New System.Windows.Forms.TextBox()
        Me.btnMas = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.btnActualizarFila = New System.Windows.Forms.Button()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblId = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblOrdenServicio = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNroFactura = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpHoraPartida = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraRetorno = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboRuc = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboRazonSocial = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cboDniConductor = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cboConductor = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboPlaca = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvResultadoConsumidor = New System.Windows.Forms.DataGridView()
        Me.dgvResultadoPersonas = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.radDetalleConsumidor = New System.Windows.Forms.RadioButton()
        Me.cbxLeerFotochecks = New System.Windows.Forms.CheckBox()
        Me.tlpPrincipal.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.dgvResultadoConsumidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResultadoPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 4
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.radDetallePersona, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.Label35, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 10)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 11)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtObs, 2, 6)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel3, 1, 8)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel4, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel5, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel6, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel7, 1, 9)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel8, 2, 7)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 13
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(1076, 567)
        Me.tlpPrincipal.TabIndex = 0
        '
        'radDetallePersona
        '
        Me.radDetallePersona.AutoSize = True
        Me.radDetallePersona.Checked = True
        Me.radDetallePersona.Location = New System.Drawing.Point(15, 206)
        Me.radDetallePersona.Name = "radDetallePersona"
        Me.radDetallePersona.Size = New System.Drawing.Size(110, 17)
        Me.radDetallePersona.TabIndex = 47
        Me.radDetallePersona.TabStop = True
        Me.radDetallePersona.Text = "Detalle X Persona"
        Me.radDetallePersona.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(55, 183)
        Me.Label35.Margin = New System.Windows.Forms.Padding(3)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "Observacion:"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 2)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(15, 507)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1043, 23)
        Me.barProgreso.TabIndex = 45
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(15, 536)
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
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel1, 2)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.btnEditar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnGuardar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnFormato, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPuntitos, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnImportar, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRuta, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportar, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDistribuirCostos, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1043, 31)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(3, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(65, 23)
        Me.btnEditar.TabIndex = 0
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(74, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(65, 23)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(145, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(65, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnFormato
        '
        Me.btnFormato.Location = New System.Drawing.Point(425, 3)
        Me.btnFormato.Name = "btnFormato"
        Me.btnFormato.Size = New System.Drawing.Size(50, 23)
        Me.btnFormato.TabIndex = 3
        Me.btnFormato.Text = "?"
        Me.btnFormato.UseVisualStyleBackColor = True
        '
        'btnPuntitos
        '
        Me.btnPuntitos.Location = New System.Drawing.Point(481, 3)
        Me.btnPuntitos.Name = "btnPuntitos"
        Me.btnPuntitos.Size = New System.Drawing.Size(50, 23)
        Me.btnPuntitos.TabIndex = 4
        Me.btnPuntitos.Text = "..."
        Me.btnPuntitos.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(883, 3)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 5
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRuta.Location = New System.Drawing.Point(537, 3)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(340, 20)
        Me.txtRuta.TabIndex = 6
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(964, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnDistribuirCostos
        '
        Me.btnDistribuirCostos.Location = New System.Drawing.Point(216, 3)
        Me.btnDistribuirCostos.Name = "btnDistribuirCostos"
        Me.btnDistribuirCostos.Size = New System.Drawing.Size(117, 25)
        Me.btnDistribuirCostos.TabIndex = 51
        Me.btnDistribuirCostos.Text = "Distribuir Costos"
        Me.btnDistribuirCostos.UseVisualStyleBackColor = True
        '
        'txtObs
        '
        Me.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObs.Location = New System.Drawing.Point(131, 180)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(927, 20)
        Me.txtObs.TabIndex = 5
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 13
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label40, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblRedondeo, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSubTotal, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTarifa, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDscto, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label26, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotalPasajeros, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotal, 12, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label27, 11, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(15, 148)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1043, 26)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Label40
        '
        Me.Label40.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(319, 6)
        Me.Label40.Margin = New System.Windows.Forms.Padding(3)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(83, 13)
        Me.Label40.TabIndex = 40
        Me.Label40.Text = "Total Pasajeros:"
        '
        'lblRedondeo
        '
        Me.lblRedondeo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblRedondeo.AutoSize = True
        Me.lblRedondeo.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblRedondeo.Location = New System.Drawing.Point(709, 6)
        Me.lblRedondeo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblRedondeo.Name = "lblRedondeo"
        Me.lblRedondeo.Size = New System.Drawing.Size(28, 13)
        Me.lblRedondeo.TabIndex = 43
        Me.lblRedondeo.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(478, 6)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "SubTotal:"
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblSubTotal.Location = New System.Drawing.Point(573, 6)
        Me.lblSubTotal.Margin = New System.Windows.Forms.Padding(3)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(28, 13)
        Me.lblSubTotal.TabIndex = 42
        Me.lblSubTotal.Text = "0.00"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(607, 6)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Redondeo:"
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 6)
        Me.Label25.Margin = New System.Windows.Forms.Padding(3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(78, 13)
        Me.Label25.TabIndex = 24
        Me.Label25.Text = "Tarifa Servicio:"
        '
        'txtTarifa
        '
        Me.txtTarifa.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTarifa.Location = New System.Drawing.Point(87, 3)
        Me.txtTarifa.Name = "txtTarifa"
        Me.txtTarifa.Size = New System.Drawing.Size(88, 20)
        Me.txtTarifa.TabIndex = 0
        Me.txtTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDscto
        '
        Me.txtDscto.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDscto.Location = New System.Drawing.Point(225, 3)
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.Size = New System.Drawing.Size(88, 20)
        Me.txtDscto.TabIndex = 1
        Me.txtDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(181, 6)
        Me.Label26.Margin = New System.Windows.Forms.Padding(3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 13)
        Me.Label26.TabIndex = 25
        Me.Label26.Text = "Dscto:"
        '
        'lblTotalPasajeros
        '
        Me.lblTotalPasajeros.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTotalPasajeros.AutoSize = True
        Me.lblTotalPasajeros.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblTotalPasajeros.Location = New System.Drawing.Point(459, 6)
        Me.lblTotalPasajeros.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotalPasajeros.Name = "lblTotalPasajeros"
        Me.lblTotalPasajeros.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalPasajeros.TabIndex = 45
        Me.lblTotalPasajeros.Text = "0"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(1006, 6)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(34, 13)
        Me.lblTotal.TabIndex = 29
        Me.lblTotal.Text = "0.000"
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(966, 6)
        Me.Label27.Margin = New System.Windows.Forms.Padding(3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "Total:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 13
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.btnMenos, 12, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cboConsumidor, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 8, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtCantidadPasajeros, 9, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnMas, 10, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblItem, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnActualizarFila, 11, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDni, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtNombres, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 4, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(15, 235)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1043, 29)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'btnMenos
        '
        Me.btnMenos.Location = New System.Drawing.Point(989, 3)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Size = New System.Drawing.Size(50, 23)
        Me.btnMenos.TabIndex = 6
        Me.btnMenos.Text = "-"
        Me.btnMenos.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(477, 8)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Consumidor:"
        '
        'cboConsumidor
        '
        Me.cboConsumidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboConsumidor.FormattingEnabled = True
        Me.cboConsumidor.Location = New System.Drawing.Point(548, 3)
        Me.cboConsumidor.Name = "cboConsumidor"
        Me.cboConsumidor.Size = New System.Drawing.Size(205, 21)
        Me.cboConsumidor.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(759, 8)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Pasajeros:"
        '
        'txtCantidadPasajeros
        '
        Me.txtCantidadPasajeros.Enabled = False
        Me.txtCantidadPasajeros.Location = New System.Drawing.Point(821, 3)
        Me.txtCantidadPasajeros.Name = "txtCantidadPasajeros"
        Me.txtCantidadPasajeros.Size = New System.Drawing.Size(50, 20)
        Me.txtCantidadPasajeros.TabIndex = 3
        '
        'btnMas
        '
        Me.btnMas.Location = New System.Drawing.Point(877, 3)
        Me.btnMas.Name = "btnMas"
        Me.btnMas.Size = New System.Drawing.Size(50, 23)
        Me.btnMas.TabIndex = 4
        Me.btnMas.Text = "+" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMas.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 8)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Item:"
        '
        'lblItem
        '
        Me.lblItem.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblItem.AutoSize = True
        Me.lblItem.Location = New System.Drawing.Point(39, 8)
        Me.lblItem.Margin = New System.Windows.Forms.Padding(3)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(25, 13)
        Me.lblItem.TabIndex = 80
        Me.lblItem.Text = "000"
        '
        'btnActualizarFila
        '
        Me.btnActualizarFila.Location = New System.Drawing.Point(933, 3)
        Me.btnActualizarFila.Name = "btnActualizarFila"
        Me.btnActualizarFila.Size = New System.Drawing.Size(50, 23)
        Me.btnActualizarFila.TabIndex = 5
        Me.btnActualizarFila.Text = "Act"
        Me.btnActualizarFila.UseVisualStyleBackColor = True
        '
        'txtDni
        '
        Me.txtDni.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDni.Location = New System.Drawing.Point(102, 4)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(100, 20)
        Me.txtDni.TabIndex = 0
        '
        'txtNombres
        '
        Me.txtNombres.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Location = New System.Drawing.Point(266, 4)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(205, 20)
        Me.txtNombres.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(70, 8)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Dni:"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(208, 8)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Nombres:"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 17
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel4, 2)
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
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.lblId, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dtpFecha, 12, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label7, 11, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblOrdenServicio, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label38, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblResponsable, 9, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 8, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblEstado, 7, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblNroFactura, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 13, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label17, 15, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dtpHoraPartida, 14, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dtpHoraRetorno, 16, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(15, 50)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1043, 26)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblId.AutoSize = True
        Me.lblId.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblId.Location = New System.Drawing.Point(28, 6)
        Me.lblId.Margin = New System.Windows.Forms.Padding(3)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(10, 13)
        Me.lblId.TabIndex = 3
        Me.lblId.Text = "."
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(625, 3)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(579, 6)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pedido Servicio:"
        '
        'lblOrdenServicio
        '
        Me.lblOrdenServicio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblOrdenServicio.AutoSize = True
        Me.lblOrdenServicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblOrdenServicio.Location = New System.Drawing.Point(134, 6)
        Me.lblOrdenServicio.Margin = New System.Windows.Forms.Padding(3)
        Me.lblOrdenServicio.Name = "lblOrdenServicio"
        Me.lblOrdenServicio.Size = New System.Drawing.Size(10, 13)
        Me.lblOrdenServicio.TabIndex = 35
        Me.lblOrdenServicio.Text = "."
        '
        'Label38
        '
        Me.Label38.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(150, 6)
        Me.Label38.Margin = New System.Windows.Forms.Padding(3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(69, 13)
        Me.Label38.TabIndex = 38
        Me.Label38.Text = "Nro. Factura:"
        '
        'lblResponsable
        '
        Me.lblResponsable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblResponsable.Location = New System.Drawing.Point(384, 6)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(10, 13)
        Me.lblResponsable.TabIndex = 73
        Me.lblResponsable.Text = "."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(306, 6)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Responsable:"
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(290, 6)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(10, 13)
        Me.lblEstado.TabIndex = 74
        Me.lblEstado.Text = "."
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Estado:"
        '
        'lblNroFactura
        '
        Me.lblNroFactura.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblNroFactura.AutoSize = True
        Me.lblNroFactura.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblNroFactura.Location = New System.Drawing.Point(225, 6)
        Me.lblNroFactura.Margin = New System.Windows.Forms.Padding(3)
        Me.lblNroFactura.Name = "lblNroFactura"
        Me.lblNroFactura.Size = New System.Drawing.Size(10, 13)
        Me.lblNroFactura.TabIndex = 39
        Me.lblNroFactura.Text = "."
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(731, 6)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Partida:"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(886, 6)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "Retorno:"
        '
        'dtpHoraPartida
        '
        Me.dtpHoraPartida.CustomFormat = "hh:mm"
        Me.dtpHoraPartida.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraPartida.Location = New System.Drawing.Point(780, 3)
        Me.dtpHoraPartida.Name = "dtpHoraPartida"
        Me.dtpHoraPartida.ShowUpDown = True
        Me.dtpHoraPartida.Size = New System.Drawing.Size(100, 20)
        Me.dtpHoraPartida.TabIndex = 77
        '
        'dtpHoraRetorno
        '
        Me.dtpHoraRetorno.CustomFormat = "hh:mm"
        Me.dtpHoraRetorno.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraRetorno.Location = New System.Drawing.Point(940, 3)
        Me.dtpHoraRetorno.Name = "dtpHoraRetorno"
        Me.dtpHoraRetorno.ShowUpDown = True
        Me.dtpHoraRetorno.Size = New System.Drawing.Size(100, 20)
        Me.dtpHoraRetorno.TabIndex = 78
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel5.ColumnCount = 10
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel5, 2)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboRuc, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label14, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboRazonSocial, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label31, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboDniConductor, 5, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label33, 6, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboConductor, 7, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label15, 8, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cboRuta, 9, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(15, 82)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1043, 27)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 7)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Ruc:"
        '
        'cboRuc
        '
        Me.cboRuc.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRuc.FormattingEnabled = True
        Me.cboRuc.Location = New System.Drawing.Point(39, 3)
        Me.cboRuc.Name = "cboRuc"
        Me.cboRuc.Size = New System.Drawing.Size(100, 21)
        Me.cboRuc.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(145, 7)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Razon Social:"
        '
        'cboRazonSocial
        '
        Me.cboRazonSocial.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRazonSocial.FormattingEnabled = True
        Me.cboRazonSocial.Location = New System.Drawing.Point(224, 3)
        Me.cboRazonSocial.Name = "cboRazonSocial"
        Me.cboRazonSocial.Size = New System.Drawing.Size(185, 21)
        Me.cboRazonSocial.TabIndex = 1
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(415, 7)
        Me.Label31.Margin = New System.Windows.Forms.Padding(3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(78, 13)
        Me.Label31.TabIndex = 30
        Me.Label31.Text = "Dni Conductor:"
        '
        'cboDniConductor
        '
        Me.cboDniConductor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDniConductor.FormattingEnabled = True
        Me.cboDniConductor.Location = New System.Drawing.Point(499, 3)
        Me.cboDniConductor.Name = "cboDniConductor"
        Me.cboDniConductor.Size = New System.Drawing.Size(80, 21)
        Me.cboDniConductor.TabIndex = 2
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(585, 7)
        Me.Label33.Margin = New System.Windows.Forms.Padding(3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(59, 13)
        Me.Label33.TabIndex = 32
        Me.Label33.Text = "Conductor:"
        '
        'cboConductor
        '
        Me.cboConductor.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboConductor.FormattingEnabled = True
        Me.cboConductor.Location = New System.Drawing.Point(650, 3)
        Me.cboConductor.Name = "cboConductor"
        Me.cboConductor.Size = New System.Drawing.Size(185, 21)
        Me.cboConductor.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(841, 7)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Ruta:"
        '
        'cboRuta
        '
        Me.cboRuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRuta.FormattingEnabled = True
        Me.cboRuta.Location = New System.Drawing.Point(880, 3)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(160, 21)
        Me.cboRuta.TabIndex = 4
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.AutoSize = True
        Me.TableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel6.ColumnCount = 8
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel6, 2)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cboPlaca, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label19, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblMarca, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label21, 4, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblModelo, 5, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label23, 6, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.lblColor, 7, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(15, 115)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1043, 27)
        Me.TableLayoutPanel6.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 7)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Placa:"
        '
        'cboPlaca
        '
        Me.cboPlaca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPlaca.FormattingEnabled = True
        Me.cboPlaca.Location = New System.Drawing.Point(46, 3)
        Me.cboPlaca.Name = "cboPlaca"
        Me.cboPlaca.Size = New System.Drawing.Size(339, 21)
        Me.cboPlaca.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(391, 7)
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
        Me.lblMarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblMarca.Location = New System.Drawing.Point(437, 7)
        Me.lblMarca.Margin = New System.Windows.Forms.Padding(3)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(10, 13)
        Me.lblMarca.TabIndex = 19
        Me.lblMarca.Text = "."
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(609, 7)
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
        Me.lblModelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblModelo.Location = New System.Drawing.Point(660, 7)
        Me.lblModelo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(10, 13)
        Me.lblModelo.TabIndex = 21
        Me.lblModelo.Text = "."
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(832, 7)
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
        Me.lblColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.lblColor.Location = New System.Drawing.Point(872, 7)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(3)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(10, 13)
        Me.lblColor.TabIndex = 23
        Me.lblColor.Text = "."
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel7, 2)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.dgvResultadoConsumidor, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.dgvResultadoPersonas, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(15, 270)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1043, 231)
        Me.TableLayoutPanel7.TabIndex = 49
        '
        'dgvResultadoConsumidor
        '
        Me.dgvResultadoConsumidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultadoConsumidor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultadoConsumidor.Location = New System.Drawing.Point(524, 3)
        Me.dgvResultadoConsumidor.Name = "dgvResultadoConsumidor"
        Me.dgvResultadoConsumidor.RowHeadersWidth = 51
        Me.dgvResultadoConsumidor.Size = New System.Drawing.Size(516, 225)
        Me.dgvResultadoConsumidor.TabIndex = 7
        '
        'dgvResultadoPersonas
        '
        Me.dgvResultadoPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultadoPersonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultadoPersonas.Location = New System.Drawing.Point(3, 3)
        Me.dgvResultadoPersonas.Name = "dgvResultadoPersonas"
        Me.dgvResultadoPersonas.RowHeadersWidth = 51
        Me.dgvResultadoPersonas.Size = New System.Drawing.Size(515, 225)
        Me.dgvResultadoPersonas.TabIndex = 8
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.AutoSize = True
        Me.TableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel8.ColumnCount = 4
        Me.tlpPrincipal.SetColumnSpan(Me.TableLayoutPanel8, 2)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.radDetalleConsumidor, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.cbxLeerFotochecks, 2, 0)
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(131, 206)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(264, 23)
        Me.TableLayoutPanel8.TabIndex = 50
        '
        'radDetalleConsumidor
        '
        Me.radDetalleConsumidor.AutoSize = True
        Me.radDetalleConsumidor.Location = New System.Drawing.Point(3, 3)
        Me.radDetalleConsumidor.Name = "radDetalleConsumidor"
        Me.radDetalleConsumidor.Size = New System.Drawing.Size(126, 17)
        Me.radDetalleConsumidor.TabIndex = 48
        Me.radDetalleConsumidor.Text = "Detalle X Consumidor"
        Me.radDetalleConsumidor.UseVisualStyleBackColor = True
        '
        'cbxLeerFotochecks
        '
        Me.cbxLeerFotochecks.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxLeerFotochecks.AutoSize = True
        Me.cbxLeerFotochecks.Location = New System.Drawing.Point(135, 3)
        Me.cbxLeerFotochecks.Name = "cbxLeerFotochecks"
        Me.cbxLeerFotochecks.Size = New System.Drawing.Size(106, 17)
        Me.cbxLeerFotochecks.TabIndex = 49
        Me.cbxLeerFotochecks.Text = "Leer Fotochecks"
        Me.cbxLeerFotochecks.UseVisualStyleBackColor = True
        '
        'frmLogistica_Movimientos_ServiciosTransporte_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 567)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmLogistica_Movimientos_ServiciosTransporte_Detalle"
        Me.Text = "Logistica / Movimientos / Servicios de Transporte - Detalle"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        CType(Me.dgvResultadoConsumidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResultadoPersonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
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
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblNroFactura As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblOrdenServicio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents dgvResultadoConsumidor As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtTarifa As System.Windows.Forms.TextBox
    Friend WithEvents txtDscto As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents cboPlaca As System.Windows.Forms.ComboBox
    Friend WithEvents cboRuc As System.Windows.Forms.ComboBox
    Friend WithEvents cboDniConductor As System.Windows.Forms.ComboBox
    Friend WithEvents cboRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents cboConductor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnMas As System.Windows.Forms.Button
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPasajeros As System.Windows.Forms.TextBox
    Friend WithEvents cboConsumidor As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblRedondeo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPasajeros As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMenos As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents btnActualizarFila As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtObs As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFormato As System.Windows.Forms.Button
    Friend WithEvents btnPuntitos As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents radDetallePersona As System.Windows.Forms.RadioButton
    Friend WithEvents radDetalleConsumidor As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvResultadoPersonas As System.Windows.Forms.DataGridView
    Friend WithEvents txtDni As System.Windows.Forms.TextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpHoraPartida As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHoraRetorno As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbxLeerFotochecks As System.Windows.Forms.CheckBox
    Friend WithEvents btnDistribuirCostos As Button
End Class
