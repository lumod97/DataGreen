<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle
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
        Me.tlpEdicion = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnPuntitos = New System.Windows.Forms.Button()
        Me.btnInterrogacion = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.tlpCabecera = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtIdConsignatario = New System.Windows.Forms.TextBox()
        Me.cboConsignatario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdCampana = New System.Windows.Forms.TextBox()
        Me.cboCampana = New System.Windows.Forms.ComboBox()
        Me.cboAnioCampana = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSemanaZarpe = New System.Windows.Forms.TextBox()
        Me.txtSemanaProceso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDespacho = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIdCultivo = New System.Windows.Forms.TextBox()
        Me.cboCultivo = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIdPaisDestino = New System.Windows.Forms.TextBox()
        Me.cboPaisDestino = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtEstatus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboIncoterm = New System.Windows.Forms.ComboBox()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.tlpDetalle1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtIdVariedad = New System.Windows.Forms.TextBox()
        Me.txtIdFormato = New System.Windows.Forms.TextBox()
        Me.cboFormato = New System.Windows.Forms.ComboBox()
        Me.txtIdEtiqueta = New System.Windows.Forms.TextBox()
        Me.cboVariedad = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboEtiqueta = New System.Windows.Forms.ComboBox()
        Me.tlpDetalle2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIdEmbalaje = New System.Windows.Forms.TextBox()
        Me.cboEmbalaje = New System.Windows.Forms.ComboBox()
        Me.txtIdCategoria = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtIdCalibre = New System.Windows.Forms.TextBox()
        Me.cboCalibre = New System.Windows.Forms.ComboBox()
        Me.txtNroPallets = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.btnMas = New System.Windows.Forms.Button()
        Me.btnMenos = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        Me.tlpEdicion.SuspendLayout()
        Me.tlpCabecera.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpDetalle1.SuspendLayout()
        Me.tlpDetalle2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 3
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.tlpEdicion, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.tlpCabecera, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 7)
        Me.tlpPrincipal.Controls.Add(Me.tlpDetalle1, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.tlpDetalle2, 1, 4)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 9
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1008, 515)
        Me.tlpPrincipal.TabIndex = 0
        '
        'tlpEdicion
        '
        Me.tlpEdicion.AutoSize = True
        Me.tlpEdicion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpEdicion.ColumnCount = 8
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpEdicion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpEdicion.Controls.Add(Me.btnEditar, 0, 0)
        Me.tlpEdicion.Controls.Add(Me.btnCancelar, 2, 0)
        Me.tlpEdicion.Controls.Add(Me.btnGuardar, 1, 0)
        Me.tlpEdicion.Controls.Add(Me.btnProcesar, 7, 0)
        Me.tlpEdicion.Controls.Add(Me.btnPuntitos, 5, 0)
        Me.tlpEdicion.Controls.Add(Me.btnInterrogacion, 4, 0)
        Me.tlpEdicion.Controls.Add(Me.txtRuta, 6, 0)
        Me.tlpEdicion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpEdicion.Location = New System.Drawing.Point(18, 18)
        Me.tlpEdicion.Name = "tlpEdicion"
        Me.tlpEdicion.RowCount = 1
        Me.tlpEdicion.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpEdicion.Size = New System.Drawing.Size(972, 29)
        Me.tlpEdicion.TabIndex = 0
        '
        'btnEditar
        '
        Me.btnEditar.Location = New System.Drawing.Point(3, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 0
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(165, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(84, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Location = New System.Drawing.Point(894, 3)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 6
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        Me.btnProcesar.Visible = False
        '
        'btnPuntitos
        '
        Me.btnPuntitos.Enabled = False
        Me.btnPuntitos.Location = New System.Drawing.Point(570, 3)
        Me.btnPuntitos.Name = "btnPuntitos"
        Me.btnPuntitos.Size = New System.Drawing.Size(35, 23)
        Me.btnPuntitos.TabIndex = 4
        Me.btnPuntitos.Text = "..."
        Me.btnPuntitos.UseVisualStyleBackColor = True
        Me.btnPuntitos.Visible = False
        '
        'btnInterrogacion
        '
        Me.btnInterrogacion.Enabled = False
        Me.btnInterrogacion.Location = New System.Drawing.Point(529, 3)
        Me.btnInterrogacion.Name = "btnInterrogacion"
        Me.btnInterrogacion.Size = New System.Drawing.Size(35, 23)
        Me.btnInterrogacion.TabIndex = 3
        Me.btnInterrogacion.Text = "?"
        Me.btnInterrogacion.UseVisualStyleBackColor = True
        Me.btnInterrogacion.Visible = False
        '
        'txtRuta
        '
        Me.txtRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRuta.Enabled = False
        Me.txtRuta.Location = New System.Drawing.Point(611, 3)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(277, 20)
        Me.txtRuta.TabIndex = 5
        Me.txtRuta.Visible = False
        '
        'tlpCabecera
        '
        Me.tlpCabecera.AutoSize = True
        Me.tlpCabecera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpCabecera.ColumnCount = 8
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpCabecera.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpCabecera.Controls.Add(Me.Label18, 0, 0)
        Me.tlpCabecera.Controls.Add(Me.txtCodigo, 1, 0)
        Me.tlpCabecera.Controls.Add(Me.Label9, 5, 0)
        Me.tlpCabecera.Controls.Add(Me.txtIdCliente, 6, 0)
        Me.tlpCabecera.Controls.Add(Me.cboCliente, 7, 0)
        Me.tlpCabecera.Controls.Add(Me.Label16, 5, 1)
        Me.tlpCabecera.Controls.Add(Me.txtIdConsignatario, 6, 1)
        Me.tlpCabecera.Controls.Add(Me.cboConsignatario, 7, 1)
        Me.tlpCabecera.Controls.Add(Me.Label2, 5, 2)
        Me.tlpCabecera.Controls.Add(Me.txtIdCampana, 6, 2)
        Me.tlpCabecera.Controls.Add(Me.cboCampana, 7, 2)
        Me.tlpCabecera.Controls.Add(Me.cboAnioCampana, 3, 2)
        Me.tlpCabecera.Controls.Add(Me.Label15, 5, 3)
        Me.tlpCabecera.Controls.Add(Me.txtObservacion, 6, 3)
        Me.tlpCabecera.Controls.Add(Me.Label3, 0, 4)
        Me.tlpCabecera.Controls.Add(Me.Label4, 0, 3)
        Me.tlpCabecera.Controls.Add(Me.txtSemanaZarpe, 1, 4)
        Me.tlpCabecera.Controls.Add(Me.txtSemanaProceso, 1, 3)
        Me.tlpCabecera.Controls.Add(Me.Label1, 0, 2)
        Me.tlpCabecera.Controls.Add(Me.dtpDespacho, 1, 2)
        Me.tlpCabecera.Controls.Add(Me.Label5, 0, 1)
        Me.tlpCabecera.Controls.Add(Me.txtNro, 1, 1)
        Me.tlpCabecera.Controls.Add(Me.Label14, 2, 0)
        Me.tlpCabecera.Controls.Add(Me.Label11, 2, 2)
        Me.tlpCabecera.Controls.Add(Me.txtIdCultivo, 3, 0)
        Me.tlpCabecera.Controls.Add(Me.cboCultivo, 4, 0)
        Me.tlpCabecera.Controls.Add(Me.Label19, 2, 1)
        Me.tlpCabecera.Controls.Add(Me.txtIdPaisDestino, 3, 1)
        Me.tlpCabecera.Controls.Add(Me.cboPaisDestino, 4, 1)
        Me.tlpCabecera.Controls.Add(Me.Label17, 2, 3)
        Me.tlpCabecera.Controls.Add(Me.txtEstatus, 3, 4)
        Me.tlpCabecera.Controls.Add(Me.Label12, 2, 4)
        Me.tlpCabecera.Controls.Add(Me.cboIncoterm, 3, 3)
        Me.tlpCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCabecera.Location = New System.Drawing.Point(18, 53)
        Me.tlpCabecera.Name = "tlpCabecera"
        Me.tlpCabecera.RowCount = 5
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCabecera.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpCabecera.Size = New System.Drawing.Size(972, 134)
        Me.tlpCabecera.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(25, 3)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Codigo:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodigo.Location = New System.Drawing.Point(74, 3)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(569, 3)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Cliente:"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdCliente.Location = New System.Drawing.Point(617, 3)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCliente.TabIndex = 3
        '
        'cboCliente
        '
        Me.cboCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(723, 3)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(246, 21)
        Me.cboCliente.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(537, 30)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Consignatario:"
        '
        'txtIdConsignatario
        '
        Me.txtIdConsignatario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdConsignatario.Location = New System.Drawing.Point(617, 30)
        Me.txtIdConsignatario.Name = "txtIdConsignatario"
        Me.txtIdConsignatario.Size = New System.Drawing.Size(100, 20)
        Me.txtIdConsignatario.TabIndex = 8
        '
        'cboConsignatario
        '
        Me.cboConsignatario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboConsignatario.FormattingEnabled = True
        Me.cboConsignatario.Location = New System.Drawing.Point(723, 30)
        Me.cboConsignatario.Name = "cboConsignatario"
        Me.cboConsignatario.Size = New System.Drawing.Size(246, 21)
        Me.cboConsignatario.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(556, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Campaña:"
        '
        'txtIdCampana
        '
        Me.txtIdCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdCampana.Location = New System.Drawing.Point(617, 57)
        Me.txtIdCampana.Name = "txtIdCampana"
        Me.txtIdCampana.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCampana.TabIndex = 12
        '
        'cboCampana
        '
        Me.cboCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCampana.FormattingEnabled = True
        Me.cboCampana.Location = New System.Drawing.Point(723, 57)
        Me.cboCampana.Name = "cboCampana"
        Me.cboCampana.Size = New System.Drawing.Size(246, 21)
        Me.cboCampana.TabIndex = 13
        '
        'cboAnioCampana
        '
        Me.cboAnioCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboAnioCampana.FormattingEnabled = True
        Me.cboAnioCampana.Location = New System.Drawing.Point(263, 57)
        Me.cboAnioCampana.Name = "cboAnioCampana"
        Me.cboAnioCampana.Size = New System.Drawing.Size(100, 21)
        Me.cboAnioCampana.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(541, 84)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Observacion:"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tlpCabecera.SetColumnSpan(Me.txtObservacion, 2)
        Me.txtObservacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObservacion.Location = New System.Drawing.Point(617, 84)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.tlpCabecera.SetRowSpan(Me.txtObservacion, 2)
        Me.txtObservacion.Size = New System.Drawing.Size(352, 47)
        Me.txtObservacion.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 111)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sem. Zarpe:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 84)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Sem. Proc.:"
        '
        'txtSemanaZarpe
        '
        Me.txtSemanaZarpe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSemanaZarpe.Location = New System.Drawing.Point(74, 111)
        Me.txtSemanaZarpe.Name = "txtSemanaZarpe"
        Me.txtSemanaZarpe.Size = New System.Drawing.Size(100, 20)
        Me.txtSemanaZarpe.TabIndex = 16
        '
        'txtSemanaProceso
        '
        Me.txtSemanaProceso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSemanaProceso.Location = New System.Drawing.Point(74, 84)
        Me.txtSemanaProceso.Name = "txtSemanaProceso"
        Me.txtSemanaProceso.Size = New System.Drawing.Size(100, 20)
        Me.txtSemanaProceso.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 57)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Despacho:"
        '
        'dtpDespacho
        '
        Me.dtpDespacho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpDespacho.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDespacho.Location = New System.Drawing.Point(74, 57)
        Me.dtpDespacho.Name = "dtpDespacho"
        Me.dtpDespacho.Size = New System.Drawing.Size(100, 20)
        Me.dtpDespacho.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 30)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nro:"
        '
        'txtNro
        '
        Me.txtNro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNro.Location = New System.Drawing.Point(74, 30)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(100, 20)
        Me.txtNro.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(215, 3)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Cultivo:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(180, 57)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Año Campana:"
        '
        'txtIdCultivo
        '
        Me.txtIdCultivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdCultivo.Location = New System.Drawing.Point(263, 3)
        Me.txtIdCultivo.Name = "txtIdCultivo"
        Me.txtIdCultivo.Size = New System.Drawing.Size(100, 20)
        Me.txtIdCultivo.TabIndex = 1
        '
        'cboCultivo
        '
        Me.cboCultivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCultivo.FormattingEnabled = True
        Me.cboCultivo.Location = New System.Drawing.Point(369, 3)
        Me.cboCultivo.Name = "cboCultivo"
        Me.cboCultivo.Size = New System.Drawing.Size(162, 21)
        Me.cboCultivo.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(188, 30)
        Me.Label19.Margin = New System.Windows.Forms.Padding(3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Pais Destino:"
        '
        'txtIdPaisDestino
        '
        Me.txtIdPaisDestino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdPaisDestino.Location = New System.Drawing.Point(263, 30)
        Me.txtIdPaisDestino.Name = "txtIdPaisDestino"
        Me.txtIdPaisDestino.Size = New System.Drawing.Size(100, 20)
        Me.txtIdPaisDestino.TabIndex = 6
        '
        'cboPaisDestino
        '
        Me.cboPaisDestino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboPaisDestino.FormattingEnabled = True
        Me.cboPaisDestino.Location = New System.Drawing.Point(369, 30)
        Me.cboPaisDestino.Name = "cboPaisDestino"
        Me.cboPaisDestino.Size = New System.Drawing.Size(162, 21)
        Me.cboPaisDestino.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(206, 84)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Incoterm:"
        '
        'txtEstatus
        '
        Me.txtEstatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEstatus.Location = New System.Drawing.Point(263, 111)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.Size = New System.Drawing.Size(100, 20)
        Me.txtEstatus.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(212, 111)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Estatus:"
        '
        'cboIncoterm
        '
        Me.tlpCabecera.SetColumnSpan(Me.cboIncoterm, 2)
        Me.cboIncoterm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboIncoterm.FormattingEnabled = True
        Me.cboIncoterm.Location = New System.Drawing.Point(263, 84)
        Me.cboIncoterm.Name = "cboIncoterm"
        Me.cboIncoterm.Size = New System.Drawing.Size(268, 21)
        Me.cboIncoterm.TabIndex = 15
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 261)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(972, 194)
        Me.dgvResultado.TabIndex = 2
        '
        'barProgreso
        '
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 461)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(972, 23)
        Me.barProgreso.TabIndex = 3
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(18, 487)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(32, 13)
        Me.lblResultado.TabIndex = 4
        Me.lblResultado.Text = "Listo!"
        '
        'tlpDetalle1
        '
        Me.tlpDetalle1.AutoSize = True
        Me.tlpDetalle1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDetalle1.ColumnCount = 9
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpDetalle1.Controls.Add(Me.txtIdVariedad, 1, 0)
        Me.tlpDetalle1.Controls.Add(Me.txtIdFormato, 4, 0)
        Me.tlpDetalle1.Controls.Add(Me.cboFormato, 5, 0)
        Me.tlpDetalle1.Controls.Add(Me.txtIdEtiqueta, 7, 0)
        Me.tlpDetalle1.Controls.Add(Me.cboVariedad, 2, 0)
        Me.tlpDetalle1.Controls.Add(Me.Label8, 3, 0)
        Me.tlpDetalle1.Controls.Add(Me.Label10, 6, 0)
        Me.tlpDetalle1.Controls.Add(Me.Label21, 0, 0)
        Me.tlpDetalle1.Controls.Add(Me.cboEtiqueta, 8, 0)
        Me.tlpDetalle1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDetalle1.Location = New System.Drawing.Point(18, 193)
        Me.tlpDetalle1.Name = "tlpDetalle1"
        Me.tlpDetalle1.RowCount = 1
        Me.tlpDetalle1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetalle1.Size = New System.Drawing.Size(972, 27)
        Me.tlpDetalle1.TabIndex = 5
        '
        'txtIdVariedad
        '
        Me.txtIdVariedad.Location = New System.Drawing.Point(61, 3)
        Me.txtIdVariedad.Name = "txtIdVariedad"
        Me.txtIdVariedad.Size = New System.Drawing.Size(60, 20)
        Me.txtIdVariedad.TabIndex = 2
        '
        'txtIdFormato
        '
        Me.txtIdFormato.Location = New System.Drawing.Point(383, 3)
        Me.txtIdFormato.Name = "txtIdFormato"
        Me.txtIdFormato.Size = New System.Drawing.Size(60, 20)
        Me.txtIdFormato.TabIndex = 4
        '
        'cboFormato
        '
        Me.cboFormato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboFormato.FormattingEnabled = True
        Me.cboFormato.Location = New System.Drawing.Point(449, 3)
        Me.cboFormato.Name = "cboFormato"
        Me.cboFormato.Size = New System.Drawing.Size(196, 21)
        Me.cboFormato.TabIndex = 9
        '
        'txtIdEtiqueta
        '
        Me.txtIdEtiqueta.Location = New System.Drawing.Point(706, 3)
        Me.txtIdEtiqueta.Name = "txtIdEtiqueta"
        Me.txtIdEtiqueta.Size = New System.Drawing.Size(60, 20)
        Me.txtIdEtiqueta.TabIndex = 7
        '
        'cboVariedad
        '
        Me.cboVariedad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboVariedad.FormattingEnabled = True
        Me.cboVariedad.Location = New System.Drawing.Point(127, 3)
        Me.cboVariedad.Name = "cboVariedad"
        Me.cboVariedad.Size = New System.Drawing.Size(196, 21)
        Me.cboVariedad.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(329, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Formato:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(651, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Etiqueta:"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "Variedad:"
        '
        'cboEtiqueta
        '
        Me.cboEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboEtiqueta.FormattingEnabled = True
        Me.cboEtiqueta.Location = New System.Drawing.Point(772, 3)
        Me.cboEtiqueta.Name = "cboEtiqueta"
        Me.cboEtiqueta.Size = New System.Drawing.Size(197, 21)
        Me.cboEtiqueta.TabIndex = 11
        '
        'tlpDetalle2
        '
        Me.tlpDetalle2.AutoSize = True
        Me.tlpDetalle2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpDetalle2.ColumnCount = 15
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpDetalle2.Controls.Add(Me.Label7, 0, 0)
        Me.tlpDetalle2.Controls.Add(Me.txtIdEmbalaje, 1, 0)
        Me.tlpDetalle2.Controls.Add(Me.cboEmbalaje, 2, 0)
        Me.tlpDetalle2.Controls.Add(Me.txtIdCategoria, 4, 0)
        Me.tlpDetalle2.Controls.Add(Me.Label6, 3, 0)
        Me.tlpDetalle2.Controls.Add(Me.cboCategoria, 5, 0)
        Me.tlpDetalle2.Controls.Add(Me.Label13, 6, 0)
        Me.tlpDetalle2.Controls.Add(Me.txtIdCalibre, 7, 0)
        Me.tlpDetalle2.Controls.Add(Me.cboCalibre, 8, 0)
        Me.tlpDetalle2.Controls.Add(Me.txtNroPallets, 12, 0)
        Me.tlpDetalle2.Controls.Add(Me.Label22, 11, 0)
        Me.tlpDetalle2.Controls.Add(Me.Label20, 9, 0)
        Me.tlpDetalle2.Controls.Add(Me.txtCantidad, 10, 0)
        Me.tlpDetalle2.Controls.Add(Me.btnMas, 13, 0)
        Me.tlpDetalle2.Controls.Add(Me.btnMenos, 14, 0)
        Me.tlpDetalle2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDetalle2.Location = New System.Drawing.Point(18, 226)
        Me.tlpDetalle2.Name = "tlpDetalle2"
        Me.tlpDetalle2.RowCount = 1
        Me.tlpDetalle2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpDetalle2.Size = New System.Drawing.Size(972, 29)
        Me.tlpDetalle2.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Embalaje:"
        '
        'txtIdEmbalaje
        '
        Me.txtIdEmbalaje.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtIdEmbalaje.Location = New System.Drawing.Point(62, 4)
        Me.txtIdEmbalaje.Name = "txtIdEmbalaje"
        Me.txtIdEmbalaje.Size = New System.Drawing.Size(60, 20)
        Me.txtIdEmbalaje.TabIndex = 3
        '
        'cboEmbalaje
        '
        Me.cboEmbalaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboEmbalaje.FormattingEnabled = True
        Me.cboEmbalaje.Location = New System.Drawing.Point(128, 3)
        Me.cboEmbalaje.Name = "cboEmbalaje"
        Me.cboEmbalaje.Size = New System.Drawing.Size(150, 21)
        Me.cboEmbalaje.TabIndex = 8
        '
        'txtIdCategoria
        '
        Me.txtIdCategoria.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtIdCategoria.Location = New System.Drawing.Point(345, 4)
        Me.txtIdCategoria.Name = "txtIdCategoria"
        Me.txtIdCategoria.Size = New System.Drawing.Size(60, 20)
        Me.txtIdCategoria.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(284, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Categoria:"
        '
        'cboCategoria
        '
        Me.cboCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(411, 3)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(33, 21)
        Me.cboCategoria.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(450, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Calibre:"
        '
        'txtIdCalibre
        '
        Me.txtIdCalibre.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtIdCalibre.Location = New System.Drawing.Point(498, 4)
        Me.txtIdCalibre.Name = "txtIdCalibre"
        Me.txtIdCalibre.Size = New System.Drawing.Size(60, 20)
        Me.txtIdCalibre.TabIndex = 5
        '
        'cboCalibre
        '
        Me.cboCalibre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboCalibre.FormattingEnabled = True
        Me.cboCalibre.Location = New System.Drawing.Point(564, 3)
        Me.cboCalibre.Name = "cboCalibre"
        Me.cboCalibre.Size = New System.Drawing.Size(59, 21)
        Me.cboCalibre.TabIndex = 19
        '
        'txtNroPallets
        '
        Me.txtNroPallets.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtNroPallets.Location = New System.Drawing.Point(820, 4)
        Me.txtNroPallets.Name = "txtNroPallets"
        Me.txtNroPallets.Size = New System.Drawing.Size(60, 20)
        Me.txtNroPallets.TabIndex = 20
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(753, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Nro Pallets:"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(629, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtCantidad.Location = New System.Drawing.Point(687, 4)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(60, 20)
        Me.txtCantidad.TabIndex = 21
        '
        'btnMas
        '
        Me.btnMas.Location = New System.Drawing.Point(886, 3)
        Me.btnMas.Name = "btnMas"
        Me.btnMas.Size = New System.Drawing.Size(37, 23)
        Me.btnMas.TabIndex = 22
        Me.btnMas.Text = "+"
        Me.btnMas.UseVisualStyleBackColor = True
        '
        'btnMenos
        '
        Me.btnMenos.Location = New System.Drawing.Point(929, 3)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Size = New System.Drawing.Size(39, 23)
        Me.btnMenos.TabIndex = 23
        Me.btnMenos.Text = "-"
        Me.btnMenos.UseVisualStyleBackColor = True
        '
        'frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 515)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPacking_Movimientos_MantenimientoPlanesComerciales_Detalle"
        Me.Text = "Packing / Movimientos / Mantenimiento De Planes Comerciales - Detalle"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.tlpEdicion.ResumeLayout(False)
        Me.tlpEdicion.PerformLayout()
        Me.tlpCabecera.ResumeLayout(False)
        Me.tlpCabecera.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpDetalle1.ResumeLayout(False)
        Me.tlpDetalle1.PerformLayout()
        Me.tlpDetalle2.ResumeLayout(False)
        Me.tlpDetalle2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpEdicion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnPuntitos As System.Windows.Forms.Button
    Friend WithEvents btnInterrogacion As System.Windows.Forms.Button
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents tlpCabecera As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNro As System.Windows.Forms.TextBox
    Friend WithEvents txtSemanaProceso As System.Windows.Forms.TextBox
    Friend WithEvents txtEstatus As System.Windows.Forms.TextBox
    Friend WithEvents txtIdConsignatario As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCampana As System.Windows.Forms.TextBox
    Friend WithEvents txtSemanaZarpe As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents cboCultivo As System.Windows.Forms.ComboBox
    Friend WithEvents txtIdCultivo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpDespacho As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtIdPaisDestino As System.Windows.Forms.TextBox
    Friend WithEvents cboPaisDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cboAnioCampana As System.Windows.Forms.ComboBox
    Friend WithEvents cboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cboCampana As System.Windows.Forms.ComboBox
    Friend WithEvents cboConsignatario As System.Windows.Forms.ComboBox
    Friend WithEvents cboIncoterm As System.Windows.Forms.ComboBox
    Friend WithEvents tlpDetalle1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIdVariedad As System.Windows.Forms.TextBox
    Friend WithEvents txtIdEmbalaje As System.Windows.Forms.TextBox
    Friend WithEvents txtIdFormato As System.Windows.Forms.TextBox
    Friend WithEvents cboFormato As System.Windows.Forms.ComboBox
    Friend WithEvents txtIdCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtIdEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents cboVariedad As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboEmbalaje As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboEtiqueta As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtIdCalibre As System.Windows.Forms.TextBox
    Friend WithEvents cboCalibre As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtNroPallets As System.Windows.Forms.TextBox
    Friend WithEvents tlpDetalle2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMas As System.Windows.Forms.Button
    Friend WithEvents btnMenos As System.Windows.Forms.Button
End Class
