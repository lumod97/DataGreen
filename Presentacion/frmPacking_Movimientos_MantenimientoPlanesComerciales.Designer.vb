<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacking_Movimientos_MantenimientoPlanesComerciales
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnPuntitos = New System.Windows.Forms.Button()
        Me.btnInterrogacion = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtlblCodigo = New System.Windows.Forms.TextBox()
        Me.txtlblIdCliente = New System.Windows.Forms.TextBox()
        Me.txtlblCliente = New System.Windows.Forms.TextBox()
        Me.txtlblNro = New System.Windows.Forms.TextBox()
        Me.txtlblCampana = New System.Windows.Forms.TextBox()
        Me.txtlblSemanaProduccion = New System.Windows.Forms.TextBox()
        Me.txtlblFechaDespacho = New System.Windows.Forms.TextBox()
        Me.txtlblEstatus = New System.Windows.Forms.TextBox()
        Me.txtlblIdConsignatario = New System.Windows.Forms.TextBox()
        Me.txtlblIdCampana = New System.Windows.Forms.TextBox()
        Me.txtlblSemanaZarpe = New System.Windows.Forms.TextBox()
        Me.txtlblPaisDestino = New System.Windows.Forms.TextBox()
        Me.txtlblConsignatario = New System.Windows.Forms.TextBox()
        Me.txtlblObservacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtlblNombreCampana = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtlblIncoterm = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.tlpPrincipal.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 3
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel2, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel3, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.TableLayoutPanel1, 1, 1)
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(1041, 491)
        Me.tlpPrincipal.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.btnNuevo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnEliminar, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAbrir, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnProcesar, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPuntitos, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnInterrogacion, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtRuta, 6, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(18, 50)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1005, 29)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(3, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(165, 3)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 0
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(84, 3)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(75, 23)
        Me.btnAbrir.TabIndex = 1
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = True
        Me.btnAbrir.Visible = False
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Location = New System.Drawing.Point(926, 3)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 2
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        Me.btnProcesar.Visible = False
        '
        'btnPuntitos
        '
        Me.btnPuntitos.Enabled = False
        Me.btnPuntitos.Location = New System.Drawing.Point(686, 3)
        Me.btnPuntitos.Name = "btnPuntitos"
        Me.btnPuntitos.Size = New System.Drawing.Size(35, 23)
        Me.btnPuntitos.TabIndex = 3
        Me.btnPuntitos.Text = "..."
        Me.btnPuntitos.UseVisualStyleBackColor = True
        Me.btnPuntitos.Visible = False
        '
        'btnInterrogacion
        '
        Me.btnInterrogacion.Enabled = False
        Me.btnInterrogacion.Location = New System.Drawing.Point(645, 3)
        Me.btnInterrogacion.Name = "btnInterrogacion"
        Me.btnInterrogacion.Size = New System.Drawing.Size(35, 23)
        Me.btnInterrogacion.TabIndex = 4
        Me.btnInterrogacion.Text = "?"
        Me.btnInterrogacion.UseVisualStyleBackColor = True
        Me.btnInterrogacion.Visible = False
        '
        'txtRuta
        '
        Me.txtRuta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRuta.Enabled = False
        Me.txtRuta.Location = New System.Drawing.Point(727, 3)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(193, 20)
        Me.txtRuta.TabIndex = 6
        Me.txtRuta.Visible = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label18, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblCodigo, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblIdCliente, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblCliente, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblNro, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblCampana, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblSemanaProduccion, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblFechaDespacho, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblEstatus, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblIdConsignatario, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblIdCampana, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblSemanaZarpe, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblPaisDestino, 3, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblConsignatario, 5, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblObservacion, 5, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label16, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblNombreCampana, 5, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.txtlblIncoterm, 3, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 4, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label17, 2, 5)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(18, 85)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1005, 156)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(66, 3)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Codigo:"
        '
        'txtlblCodigo
        '
        Me.txtlblCodigo.Location = New System.Drawing.Point(115, 3)
        Me.txtlblCodigo.Name = "txtlblCodigo"
        Me.txtlblCodigo.Size = New System.Drawing.Size(99, 20)
        Me.txtlblCodigo.TabIndex = 18
        '
        'txtlblIdCliente
        '
        Me.txtlblIdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblIdCliente.Location = New System.Drawing.Point(312, 3)
        Me.txtlblIdCliente.Name = "txtlblIdCliente"
        Me.txtlblIdCliente.Size = New System.Drawing.Size(169, 20)
        Me.txtlblIdCliente.TabIndex = 19
        '
        'txtlblCliente
        '
        Me.txtlblCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblCliente.Location = New System.Drawing.Point(588, 3)
        Me.txtlblCliente.Name = "txtlblCliente"
        Me.txtlblCliente.Size = New System.Drawing.Size(414, 20)
        Me.txtlblCliente.TabIndex = 20
        '
        'txtlblNro
        '
        Me.txtlblNro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblNro.Location = New System.Drawing.Point(115, 29)
        Me.txtlblNro.Name = "txtlblNro"
        Me.txtlblNro.Size = New System.Drawing.Size(99, 20)
        Me.txtlblNro.TabIndex = 21
        '
        'txtlblCampana
        '
        Me.txtlblCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblCampana.Location = New System.Drawing.Point(115, 55)
        Me.txtlblCampana.Name = "txtlblCampana"
        Me.txtlblCampana.Size = New System.Drawing.Size(99, 20)
        Me.txtlblCampana.TabIndex = 22
        '
        'txtlblSemanaProduccion
        '
        Me.txtlblSemanaProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblSemanaProduccion.Location = New System.Drawing.Point(115, 81)
        Me.txtlblSemanaProduccion.Name = "txtlblSemanaProduccion"
        Me.txtlblSemanaProduccion.Size = New System.Drawing.Size(99, 20)
        Me.txtlblSemanaProduccion.TabIndex = 23
        '
        'txtlblFechaDespacho
        '
        Me.txtlblFechaDespacho.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblFechaDespacho.Location = New System.Drawing.Point(115, 107)
        Me.txtlblFechaDespacho.Name = "txtlblFechaDespacho"
        Me.txtlblFechaDespacho.Size = New System.Drawing.Size(99, 20)
        Me.txtlblFechaDespacho.TabIndex = 24
        '
        'txtlblEstatus
        '
        Me.txtlblEstatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblEstatus.Location = New System.Drawing.Point(115, 133)
        Me.txtlblEstatus.Name = "txtlblEstatus"
        Me.txtlblEstatus.Size = New System.Drawing.Size(99, 20)
        Me.txtlblEstatus.TabIndex = 25
        '
        'txtlblIdConsignatario
        '
        Me.txtlblIdConsignatario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblIdConsignatario.Location = New System.Drawing.Point(312, 29)
        Me.txtlblIdConsignatario.Name = "txtlblIdConsignatario"
        Me.txtlblIdConsignatario.Size = New System.Drawing.Size(169, 20)
        Me.txtlblIdConsignatario.TabIndex = 26
        '
        'txtlblIdCampana
        '
        Me.txtlblIdCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblIdCampana.Location = New System.Drawing.Point(312, 55)
        Me.txtlblIdCampana.Name = "txtlblIdCampana"
        Me.txtlblIdCampana.Size = New System.Drawing.Size(169, 20)
        Me.txtlblIdCampana.TabIndex = 27
        '
        'txtlblSemanaZarpe
        '
        Me.txtlblSemanaZarpe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblSemanaZarpe.Location = New System.Drawing.Point(312, 81)
        Me.txtlblSemanaZarpe.Name = "txtlblSemanaZarpe"
        Me.txtlblSemanaZarpe.Size = New System.Drawing.Size(169, 20)
        Me.txtlblSemanaZarpe.TabIndex = 28
        '
        'txtlblPaisDestino
        '
        Me.txtlblPaisDestino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblPaisDestino.Location = New System.Drawing.Point(312, 107)
        Me.txtlblPaisDestino.Name = "txtlblPaisDestino"
        Me.txtlblPaisDestino.Size = New System.Drawing.Size(169, 20)
        Me.txtlblPaisDestino.TabIndex = 29
        '
        'txtlblConsignatario
        '
        Me.txtlblConsignatario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblConsignatario.Location = New System.Drawing.Point(588, 29)
        Me.txtlblConsignatario.Name = "txtlblConsignatario"
        Me.txtlblConsignatario.Size = New System.Drawing.Size(414, 20)
        Me.txtlblConsignatario.TabIndex = 31
        '
        'txtlblObservacion
        '
        Me.txtlblObservacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblObservacion.Location = New System.Drawing.Point(588, 81)
        Me.txtlblObservacion.Multiline = True
        Me.txtlblObservacion.Name = "txtlblObservacion"
        Me.TableLayoutPanel3.SetRowSpan(Me.txtlblObservacion, 3)
        Me.txtlblObservacion.Size = New System.Drawing.Size(414, 72)
        Me.txtlblObservacion.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(540, 3)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Cliente:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(508, 29)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Consignatario:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(252, 3)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Id Cliente:"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(220, 29)
        Me.Label16.Margin = New System.Windows.Forms.Padding(3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Id Consignatario:"
        '
        'txtlblNombreCampana
        '
        Me.txtlblNombreCampana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblNombreCampana.Location = New System.Drawing.Point(588, 55)
        Me.txtlblNombreCampana.Name = "txtlblNombreCampana"
        Me.txtlblNombreCampana.Size = New System.Drawing.Size(414, 20)
        Me.txtlblNombreCampana.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(82, 29)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Nro:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 107)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Despacho:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(64, 133)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Estatus:"
        '
        'txtlblIncoterm
        '
        Me.txtlblIncoterm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlblIncoterm.Location = New System.Drawing.Point(312, 133)
        Me.txtlblIncoterm.Name = "txtlblIncoterm"
        Me.txtlblIncoterm.Size = New System.Drawing.Size(169, 20)
        Me.txtlblIncoterm.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(487, 55)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Nombre Campana:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(512, 81)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Observacion:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Id Campana:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(54, 55)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Campana:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 81)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Semana Produccion:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 81)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Semana Zarpe:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(237, 107)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Pais Destino:"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(255, 133)
        Me.Label17.Margin = New System.Windows.Forms.Padding(3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Incoterm:"
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 247)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1005, 184)
        Me.dgvResultado.TabIndex = 2
        '
        'barProgreso
        '
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 437)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1005, 23)
        Me.barProgreso.TabIndex = 3
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(18, 463)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(32, 13)
        Me.lblResultado.TabIndex = 4
        Me.lblResultado.Text = "Listo!"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpDesde, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpHasta, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1005, 26)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Desde:"
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(50, 3)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(100, 20)
        Me.dtpDesde.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(156, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Hasta:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(200, 3)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(100, 20)
        Me.dtpHasta.TabIndex = 10
        '
        'frmPacking_Movimientos_MantenimientoPlanesComerciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 491)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmPacking_Movimientos_MantenimientoPlanesComerciales"
        Me.Text = "Packing / Movimientos / Mantenimiento De Planes Comerciales"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnPuntitos As System.Windows.Forms.Button
    Friend WithEvents btnInterrogacion As System.Windows.Forms.Button
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtlblCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtlblIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtlblCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtlblNro As System.Windows.Forms.TextBox
    Friend WithEvents txtlblCampana As System.Windows.Forms.TextBox
    Friend WithEvents txtlblSemanaProduccion As System.Windows.Forms.TextBox
    Friend WithEvents txtlblFechaDespacho As System.Windows.Forms.TextBox
    Friend WithEvents txtlblEstatus As System.Windows.Forms.TextBox
    Friend WithEvents txtlblIdConsignatario As System.Windows.Forms.TextBox
    Friend WithEvents txtlblIdCampana As System.Windows.Forms.TextBox
    Friend WithEvents txtlblSemanaZarpe As System.Windows.Forms.TextBox
    Friend WithEvents txtlblPaisDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtlblConsignatario As System.Windows.Forms.TextBox
    Friend WithEvents txtlblIncoterm As System.Windows.Forms.TextBox
    Friend WithEvents txtlblObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtlblNombreCampana As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
