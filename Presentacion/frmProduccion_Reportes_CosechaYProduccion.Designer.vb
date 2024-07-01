<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduccion_Reportes_CosechaYProduccion
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
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.cboCampana = New System.Windows.Forms.ComboBox()
        Me.cboTipoCampana = New System.Windows.Forms.ComboBox()
        Me.dgvResumen = New System.Windows.Forms.DataGridView()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblResultado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.cboCutlivo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxDetalladoFecha = New System.Windows.Forms.CheckBox()
        Me.cbxDetalladoCategoria = New System.Windows.Forms.CheckBox()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 12
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
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
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboCampana, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboTipoCampana, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResumen, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.dgvDetalle, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblResultado, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.dtpDesde, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 5, 2)
        Me.tlpPrincipal.Controls.Add(Me.dtpHasta, 6, 2)
        Me.tlpPrincipal.Controls.Add(Me.cboCutlivo, 4, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.cbxDetalladoFecha, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.cbxDetalladoCategoria, 7, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 8
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1024, 504)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Campaña:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo de Campana:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(850, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(931, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 8
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'cboCampana
        '
        Me.cboCampana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCampana.FormattingEnabled = True
        Me.cboCampana.Location = New System.Drawing.Point(79, 19)
        Me.cboCampana.Name = "cboCampana"
        Me.cboCampana.Size = New System.Drawing.Size(65, 21)
        Me.cboCampana.TabIndex = 9
        '
        'cboTipoCampana
        '
        Me.cboTipoCampana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboTipoCampana.FormattingEnabled = True
        Me.cboTipoCampana.Location = New System.Drawing.Point(250, 19)
        Me.cboTipoCampana.Name = "cboTipoCampana"
        Me.cboTipoCampana.Size = New System.Drawing.Size(200, 21)
        Me.cboTipoCampana.TabIndex = 10
        '
        'dgvResumen
        '
        Me.dgvResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResumen, 10)
        Me.dgvResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResumen.Location = New System.Drawing.Point(18, 74)
        Me.dgvResumen.Name = "dgvResumen"
        Me.dgvResumen.Size = New System.Drawing.Size(988, 179)
        Me.dgvResumen.TabIndex = 16
        '
        'dgvDetalle
        '
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvDetalle, 10)
        Me.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalle.Location = New System.Drawing.Point(18, 259)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(988, 179)
        Me.dgvDetalle.TabIndex = 17
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 10)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 444)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(988, 23)
        Me.barProgreso.TabIndex = 18
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblResultado, 2)
        Me.lblResultado.Location = New System.Drawing.Point(18, 473)
        Me.lblResultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(32, 13)
        Me.lblResultado.TabIndex = 19
        Me.lblResultado.Text = "Listo!"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(456, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Desde:"
        '
        'dtpDesde
        '
        Me.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(503, 19)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(100, 20)
        Me.dtpDesde.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(459, 51)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Hasta:"
        '
        'dtpHasta
        '
        Me.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(503, 47)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(100, 20)
        Me.dtpHasta.TabIndex = 13
        '
        'cboCutlivo
        '
        Me.cboCutlivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboCutlivo.FormattingEnabled = True
        Me.cboCutlivo.Location = New System.Drawing.Point(250, 47)
        Me.cboCutlivo.Name = "cboCutlivo"
        Me.cboCutlivo.Size = New System.Drawing.Size(200, 21)
        Me.cboCutlivo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cultivo:"
        '
        'cbxDetalladoFecha
        '
        Me.cbxDetalladoFecha.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxDetalladoFecha.AutoSize = True
        Me.cbxDetalladoFecha.Location = New System.Drawing.Point(609, 21)
        Me.cbxDetalladoFecha.Name = "cbxDetalladoFecha"
        Me.cbxDetalladoFecha.Size = New System.Drawing.Size(123, 17)
        Me.cbxDetalladoFecha.TabIndex = 14
        Me.cbxDetalladoFecha.Text = "Detallado Por Fecha"
        Me.cbxDetalladoFecha.UseVisualStyleBackColor = True
        '
        'cbxDetalladoCategoria
        '
        Me.cbxDetalladoCategoria.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cbxDetalladoCategoria.AutoSize = True
        Me.cbxDetalladoCategoria.Location = New System.Drawing.Point(609, 49)
        Me.cbxDetalladoCategoria.Name = "cbxDetalladoCategoria"
        Me.cbxDetalladoCategoria.Size = New System.Drawing.Size(138, 17)
        Me.cbxDetalladoCategoria.TabIndex = 15
        Me.cbxDetalladoCategoria.Text = "Detallado Por Categoria"
        Me.cbxDetalladoCategoria.UseVisualStyleBackColor = True
        '
        'frmProduccion_Reportes_CosechaYProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 504)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmProduccion_Reportes_CosechaYProduccion"
        Me.Text = "Produccion / Reportes / Cosecha Y Produccion"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCutlivo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvResumen As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents cboCampana As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoCampana As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxDetalladoFecha As System.Windows.Forms.CheckBox
    Friend WithEvents cbxDetalladoCategoria As System.Windows.Forms.CheckBox
End Class
