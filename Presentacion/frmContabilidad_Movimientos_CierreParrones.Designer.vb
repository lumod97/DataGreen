<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilidad_Movimientos_CierreParrones
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboInputDatos_Campana = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboInputDatos_Cultivo = New System.Windows.Forms.ComboBox()
        Me.cboInputDatos_Consumidor = New System.Windows.Forms.ComboBox()
        Me.pkrInputDatos_FechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvInputDatos_ConsumidoresPendientes = New System.Windows.Forms.DataGridView()
        Me.dgvInputDatos_ConsumidoresGuardados = New System.Windows.Forms.DataGridView()
        Me.btnInputDatos_Eliminar = New System.Windows.Forms.Button()
        Me.btnInputDatos_Guardar = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboReportes_Campana = New System.Windows.Forms.ComboBox()
        Me.cboReportes_Cultivo = New System.Windows.Forms.ComboBox()
        Me.cboReportes_Codigo = New System.Windows.Forms.ComboBox()
        Me.cboReportes_Periodo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReportes_Consultar = New System.Windows.Forms.Button()
        Me.btnReportes_Exportar = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvReportes_CostosGenerales = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvReportes_DetalleIndirectos = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblInputDatos_Codigo = New System.Windows.Forms.Label()
        Me.tlpPrincipal.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvInputDatos_ConsumidoresPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInputDatos_ConsumidoresGuardados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvReportes_CostosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvReportes_DetalleIndirectos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 3
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.TabControl1, 1, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 3
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1142, 513)
        Me.tlpPrincipal.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(18, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1106, 477)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1098, 451)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Input de Datos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 14
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboInputDatos_Campana, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboInputDatos_Cultivo, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cboInputDatos_Consumidor, 8, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.pkrInputDatos_FechaCierre, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dgvInputDatos_ConsumidoresPendientes, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.dgvInputDatos_ConsumidoresGuardados, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnInputDatos_Eliminar, 12, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.btnInputDatos_Guardar, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 9, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblInputDatos_Codigo, 10, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1092, 445)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Campana:"
        '
        'cboInputDatos_Campana
        '
        Me.cboInputDatos_Campana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboInputDatos_Campana.FormattingEnabled = True
        Me.cboInputDatos_Campana.Location = New System.Drawing.Point(79, 18)
        Me.cboInputDatos_Campana.Name = "cboInputDatos_Campana"
        Me.cboInputDatos_Campana.Size = New System.Drawing.Size(70, 21)
        Me.cboInputDatos_Campana.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(155, 22)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cultivo:"
        '
        'cboInputDatos_Cultivo
        '
        Me.cboInputDatos_Cultivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboInputDatos_Cultivo.FormattingEnabled = True
        Me.cboInputDatos_Cultivo.Location = New System.Drawing.Point(203, 18)
        Me.cboInputDatos_Cultivo.Name = "cboInputDatos_Cultivo"
        Me.cboInputDatos_Cultivo.Size = New System.Drawing.Size(150, 21)
        Me.cboInputDatos_Cultivo.TabIndex = 12
        '
        'cboInputDatos_Consumidor
        '
        Me.cboInputDatos_Consumidor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboInputDatos_Consumidor.FormattingEnabled = True
        Me.cboInputDatos_Consumidor.Location = New System.Drawing.Point(599, 18)
        Me.cboInputDatos_Consumidor.Name = "cboInputDatos_Consumidor"
        Me.cboInputDatos_Consumidor.Size = New System.Drawing.Size(240, 21)
        Me.cboInputDatos_Consumidor.TabIndex = 13
        '
        'pkrInputDatos_FechaCierre
        '
        Me.pkrInputDatos_FechaCierre.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrInputDatos_FechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrInputDatos_FechaCierre.Location = New System.Drawing.Point(450, 18)
        Me.pkrInputDatos_FechaCierre.Name = "pkrInputDatos_FechaCierre"
        Me.pkrInputDatos_FechaCierre.Size = New System.Drawing.Size(90, 20)
        Me.pkrInputDatos_FechaCierre.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(359, 22)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Fecha de Cierre:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(546, 22)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Agregar:"
        '
        'dgvInputDatos_ConsumidoresPendientes
        '
        Me.dgvInputDatos_ConsumidoresPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.dgvInputDatos_ConsumidoresPendientes, 4)
        Me.dgvInputDatos_ConsumidoresPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInputDatos_ConsumidoresPendientes.Location = New System.Drawing.Point(18, 45)
        Me.dgvInputDatos_ConsumidoresPendientes.Name = "dgvInputDatos_ConsumidoresPendientes"
        Me.dgvInputDatos_ConsumidoresPendientes.Size = New System.Drawing.Size(335, 353)
        Me.dgvInputDatos_ConsumidoresPendientes.TabIndex = 20
        '
        'dgvInputDatos_ConsumidoresGuardados
        '
        Me.dgvInputDatos_ConsumidoresGuardados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.dgvInputDatos_ConsumidoresGuardados, 8)
        Me.dgvInputDatos_ConsumidoresGuardados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInputDatos_ConsumidoresGuardados.Location = New System.Drawing.Point(359, 45)
        Me.dgvInputDatos_ConsumidoresGuardados.Name = "dgvInputDatos_ConsumidoresGuardados"
        Me.dgvInputDatos_ConsumidoresGuardados.Size = New System.Drawing.Size(715, 353)
        Me.dgvInputDatos_ConsumidoresGuardados.TabIndex = 21
        '
        'btnInputDatos_Eliminar
        '
        Me.btnInputDatos_Eliminar.Location = New System.Drawing.Point(999, 404)
        Me.btnInputDatos_Eliminar.Name = "btnInputDatos_Eliminar"
        Me.btnInputDatos_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnInputDatos_Eliminar.TabIndex = 22
        Me.btnInputDatos_Eliminar.Text = "Eliminar"
        Me.btnInputDatos_Eliminar.UseVisualStyleBackColor = True
        '
        'btnInputDatos_Guardar
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.btnInputDatos_Guardar, 2)
        Me.btnInputDatos_Guardar.Location = New System.Drawing.Point(18, 404)
        Me.btnInputDatos_Guardar.Name = "btnInputDatos_Guardar"
        Me.btnInputDatos_Guardar.Size = New System.Drawing.Size(75, 23)
        Me.btnInputDatos_Guardar.TabIndex = 19
        Me.btnInputDatos_Guardar.Text = "Guardar"
        Me.btnInputDatos_Guardar.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1098, 451)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reportes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboReportes_Campana, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboReportes_Cultivo, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboReportes_Codigo, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboReportes_Periodo, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnReportes_Consultar, 10, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnReportes_Exportar, 11, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl2, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDin_Resultado, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1092, 445)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Campana:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cultivo:"
        '
        'cboReportes_Campana
        '
        Me.cboReportes_Campana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboReportes_Campana.FormattingEnabled = True
        Me.cboReportes_Campana.Location = New System.Drawing.Point(79, 19)
        Me.cboReportes_Campana.Name = "cboReportes_Campana"
        Me.cboReportes_Campana.Size = New System.Drawing.Size(70, 21)
        Me.cboReportes_Campana.TabIndex = 2
        '
        'cboReportes_Cultivo
        '
        Me.cboReportes_Cultivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboReportes_Cultivo.FormattingEnabled = True
        Me.cboReportes_Cultivo.Location = New System.Drawing.Point(203, 19)
        Me.cboReportes_Cultivo.Name = "cboReportes_Cultivo"
        Me.cboReportes_Cultivo.Size = New System.Drawing.Size(150, 21)
        Me.cboReportes_Cultivo.TabIndex = 3
        '
        'cboReportes_Codigo
        '
        Me.cboReportes_Codigo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboReportes_Codigo.FormattingEnabled = True
        Me.cboReportes_Codigo.Location = New System.Drawing.Point(408, 19)
        Me.cboReportes_Codigo.Name = "cboReportes_Codigo"
        Me.cboReportes_Codigo.Size = New System.Drawing.Size(78, 21)
        Me.cboReportes_Codigo.TabIndex = 4
        '
        'cboReportes_Periodo
        '
        Me.cboReportes_Periodo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboReportes_Periodo.FormattingEnabled = True
        Me.cboReportes_Periodo.Location = New System.Drawing.Point(544, 19)
        Me.cboReportes_Periodo.Name = "cboReportes_Periodo"
        Me.cboReportes_Periodo.Size = New System.Drawing.Size(120, 21)
        Me.cboReportes_Periodo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(359, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Codigo:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(492, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Periodo:"
        '
        'btnReportes_Consultar
        '
        Me.btnReportes_Consultar.Location = New System.Drawing.Point(918, 18)
        Me.btnReportes_Consultar.Name = "btnReportes_Consultar"
        Me.btnReportes_Consultar.Size = New System.Drawing.Size(75, 23)
        Me.btnReportes_Consultar.TabIndex = 8
        Me.btnReportes_Consultar.Text = "Consultar"
        Me.btnReportes_Consultar.UseVisualStyleBackColor = True
        '
        'btnReportes_Exportar
        '
        Me.btnReportes_Exportar.Location = New System.Drawing.Point(999, 18)
        Me.btnReportes_Exportar.Name = "btnReportes_Exportar"
        Me.btnReportes_Exportar.Size = New System.Drawing.Size(75, 23)
        Me.btnReportes_Exportar.TabIndex = 9
        Me.btnReportes_Exportar.Text = "Exportar"
        Me.btnReportes_Exportar.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TabControl2, 11)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(18, 47)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1056, 332)
        Me.TabControl2.TabIndex = 10
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvReportes_CostosGenerales)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1048, 306)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Costos Generales"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvReportes_CostosGenerales
        '
        Me.dgvReportes_CostosGenerales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportes_CostosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportes_CostosGenerales.Location = New System.Drawing.Point(3, 3)
        Me.dgvReportes_CostosGenerales.Name = "dgvReportes_CostosGenerales"
        Me.dgvReportes_CostosGenerales.Size = New System.Drawing.Size(1042, 300)
        Me.dgvReportes_CostosGenerales.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvReportes_DetalleIndirectos)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1048, 306)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Detalle de Inidirectos"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvReportes_DetalleIndirectos
        '
        Me.dgvReportes_DetalleIndirectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportes_DetalleIndirectos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportes_DetalleIndirectos.Location = New System.Drawing.Point(3, 3)
        Me.dgvReportes_DetalleIndirectos.Name = "dgvReportes_DetalleIndirectos"
        Me.dgvReportes_DetalleIndirectos.Size = New System.Drawing.Size(1042, 300)
        Me.dgvReportes_DetalleIndirectos.TabIndex = 0
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 11)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 385)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1056, 23)
        Me.barProgreso.TabIndex = 11
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 414)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 12
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(845, 22)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Codigo:"
        '
        'lblInputDatos_Codigo
        '
        Me.lblInputDatos_Codigo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblInputDatos_Codigo.AutoSize = True
        Me.lblInputDatos_Codigo.Location = New System.Drawing.Point(894, 22)
        Me.lblInputDatos_Codigo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblInputDatos_Codigo.Name = "lblInputDatos_Codigo"
        Me.lblInputDatos_Codigo.Size = New System.Drawing.Size(25, 13)
        Me.lblInputDatos_Codigo.TabIndex = 24
        Me.lblInputDatos_Codigo.Text = "000"
        '
        'frmContabilidad_Movimientos_CierreParrones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 513)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmContabilidad_Movimientos_CierreParrones"
        Me.Text = "Contabilidad / Movimientos - Cierre de Parrones"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.dgvInputDatos_ConsumidoresPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInputDatos_ConsumidoresGuardados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvReportes_CostosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvReportes_DetalleIndirectos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboInputDatos_Campana As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboInputDatos_Cultivo As System.Windows.Forms.ComboBox
    Friend WithEvents cboInputDatos_Consumidor As System.Windows.Forms.ComboBox
    Friend WithEvents pkrInputDatos_FechaCierre As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnInputDatos_Guardar As System.Windows.Forms.Button
    Friend WithEvents dgvInputDatos_ConsumidoresPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvInputDatos_ConsumidoresGuardados As System.Windows.Forms.DataGridView
    Friend WithEvents btnInputDatos_Eliminar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboReportes_Campana As System.Windows.Forms.ComboBox
    Friend WithEvents cboReportes_Cultivo As System.Windows.Forms.ComboBox
    Friend WithEvents cboReportes_Codigo As System.Windows.Forms.ComboBox
    Friend WithEvents cboReportes_Periodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnReportes_Consultar As System.Windows.Forms.Button
    Friend WithEvents btnReportes_Exportar As System.Windows.Forms.Button
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvReportes_CostosGenerales As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvReportes_DetalleIndirectos As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblInputDatos_Codigo As System.Windows.Forms.Label
End Class
