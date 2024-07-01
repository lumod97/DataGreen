<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRrhh_Reportes_ReporteMarcacionesChronos
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pkrDesde = New System.Windows.Forms.DateTimePicker()
        Me.pkrHasta = New System.Windows.Forms.DateTimePicker()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.cboConsultar = New System.Windows.Forms.Button()
        Me.cboExportar = New System.Windows.Forms.Button()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCodigoDesde = New System.Windows.Forms.TextBox()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.txtCodigoHasta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTrabajadorDesde = New System.Windows.Forms.TextBox()
        Me.txtTrabajadorHasta = New System.Windows.Forms.TextBox()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 11
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.pkrDesde, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.pkrHasta, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPlanilla, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboConsultar, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboExportar, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtCodigoDesde, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtCodigoHasta, 2, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label7, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.txtTrabajadorDesde, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtTrabajadorHasta, 3, 3)
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(925, 490)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(368, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Planilla:"
        '
        'pkrDesde
        '
        Me.pkrDesde.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDesde.Location = New System.Drawing.Point(112, 19)
        Me.pkrDesde.Name = "pkrDesde"
        Me.pkrDesde.Size = New System.Drawing.Size(100, 20)
        Me.pkrDesde.TabIndex = 0
        '
        'pkrHasta
        '
        Me.pkrHasta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.pkrHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrHasta.Location = New System.Drawing.Point(262, 19)
        Me.pkrHasta.Name = "pkrHasta"
        Me.pkrHasta.Size = New System.Drawing.Size(100, 20)
        Me.pkrHasta.TabIndex = 1
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(417, 19)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(200, 21)
        Me.cboPlanilla.TabIndex = 2
        '
        'cboConsultar
        '
        Me.cboConsultar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboConsultar.Location = New System.Drawing.Point(751, 18)
        Me.cboConsultar.Name = "cboConsultar"
        Me.cboConsultar.Size = New System.Drawing.Size(75, 23)
        Me.cboConsultar.TabIndex = 5
        Me.cboConsultar.Text = "Consultar"
        Me.cboConsultar.UseVisualStyleBackColor = True
        '
        'cboExportar
        '
        Me.cboExportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboExportar.Location = New System.Drawing.Point(832, 18)
        Me.cboExportar.Name = "cboExportar"
        Me.cboExportar.Size = New System.Drawing.Size(75, 23)
        Me.cboExportar.TabIndex = 6
        Me.cboExportar.Text = "Exportar"
        Me.cboExportar.UseVisualStyleBackColor = True
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Resultado.AutoSize = True
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 462)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(39, 13)
        Me.lblDin_Resultado.TabIndex = 9
        Me.lblDin_Resultado.Text = "Label4"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 9)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 436)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(889, 23)
        Me.barProgreso.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Desde el Codigo:"
        '
        'txtCodigoDesde
        '
        Me.txtCodigoDesde.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCodigoDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoDesde.Location = New System.Drawing.Point(112, 47)
        Me.txtCodigoDesde.Name = "txtCodigoDesde"
        Me.txtCodigoDesde.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoDesde.TabIndex = 3
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 9)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 99)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(889, 331)
        Me.dgvResultado.TabIndex = 7
        '
        'txtCodigoHasta
        '
        Me.txtCodigoHasta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCodigoHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoHasta.Location = New System.Drawing.Point(112, 73)
        Me.txtCodigoHasta.Name = "txtCodigoHasta"
        Me.txtCodigoHasta.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigoHasta.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Hasta el Codigo:"
        '
        'txtTrabajadorDesde
        '
        Me.tlpPrincipal.SetColumnSpan(Me.txtTrabajadorDesde, 4)
        Me.txtTrabajadorDesde.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTrabajadorDesde.Enabled = False
        Me.txtTrabajadorDesde.Location = New System.Drawing.Point(218, 47)
        Me.txtTrabajadorDesde.Name = "txtTrabajadorDesde"
        Me.txtTrabajadorDesde.Size = New System.Drawing.Size(399, 20)
        Me.txtTrabajadorDesde.TabIndex = 17
        '
        'txtTrabajadorHasta
        '
        Me.tlpPrincipal.SetColumnSpan(Me.txtTrabajadorHasta, 4)
        Me.txtTrabajadorHasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTrabajadorHasta.Enabled = False
        Me.txtTrabajadorHasta.Location = New System.Drawing.Point(218, 73)
        Me.txtTrabajadorHasta.Name = "txtTrabajadorHasta"
        Me.txtTrabajadorHasta.Size = New System.Drawing.Size(399, 20)
        Me.txtTrabajadorHasta.TabIndex = 18
        '
        'frmRrhh_Reportes_ReporteMarcacionesChronos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 490)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_ReporteMarcacionesChronos"
        Me.Text = "Rrhh / Reportes / Reporte de Marcaciones Chronos"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pkrDesde As DateTimePicker
    Friend WithEvents pkrHasta As DateTimePicker
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents cboConsultar As Button
    Friend WithEvents cboExportar As Button
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCodigoDesde As TextBox
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents txtCodigoHasta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTrabajadorDesde As TextBox
    Friend WithEvents txtTrabajadorHasta As TextBox
End Class
