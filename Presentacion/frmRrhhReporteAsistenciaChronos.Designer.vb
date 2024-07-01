<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhhReporteAsistenciaChronos
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.radRefrigerio = New System.Windows.Forms.RadioButton()
        Me.pkrDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.radRepStandard = New System.Windows.Forms.RadioButton()
        Me.radRepExtendido = New System.Windows.Forms.RadioButton()
        Me.radPaking = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTerminales = New System.Windows.Forms.ComboBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvResultado, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDin_Resultado, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.radRefrigerio, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pkrDesde, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateTimePicker1, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPlanilla, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodigo, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radRepStandard, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radRepExtendido, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radPaking, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTerminales, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConsultar, 10, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportar, 11, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1548, 524)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inicio:"
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvResultado, 11)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 76)
        Me.dgvResultado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 0)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1527, 385)
        Me.dgvResultado.TabIndex = 6
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 492)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(67, 13)
        Me.lblDin_Resultado.TabIndex = 7
        Me.lblDin_Resultado.Text = "Resultado: 0"
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 11)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 461)
        Me.barProgreso.Margin = New System.Windows.Forms.Padding(3, 0, 3, 4)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1527, 23)
        Me.barProgreso.TabIndex = 8
        '
        'radRefrigerio
        '
        Me.radRefrigerio.AutoSize = True
        Me.radRefrigerio.Dock = System.Windows.Forms.DockStyle.Left
        Me.radRefrigerio.Location = New System.Drawing.Point(357, 48)
        Me.radRefrigerio.Name = "radRefrigerio"
        Me.radRefrigerio.Size = New System.Drawing.Size(131, 21)
        Me.radRefrigerio.TabIndex = 15
        Me.radRefrigerio.TabStop = True
        Me.radRefrigerio.Text = "Refrigerio del Personal"
        Me.radRefrigerio.UseVisualStyleBackColor = True
        '
        'pkrDesde
        '
        Me.pkrDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pkrDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrDesde.Location = New System.Drawing.Point(133, 20)
        Me.pkrDesde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pkrDesde.Name = "pkrDesde"
        Me.pkrDesde.Size = New System.Drawing.Size(113, 20)
        Me.pkrDesde.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Fin:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(357, 20)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(131, 20)
        Me.DateTimePicker1.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(497, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Planilla:"
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(556, 19)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(248, 21)
        Me.cboPlanilla.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(813, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Trabajador"
        '
        'txtCodigo
        '
        Me.txtCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigo.Location = New System.Drawing.Point(880, 20)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(93, 20)
        Me.txtCodigo.TabIndex = 21
        '
        'radRepStandard
        '
        Me.radRepStandard.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radRepStandard.AutoSize = True
        Me.radRepStandard.Location = New System.Drawing.Point(18, 50)
        Me.radRepStandard.Name = "radRepStandard"
        Me.radRepStandard.Size = New System.Drawing.Size(109, 17)
        Me.radRepStandard.TabIndex = 0
        Me.radRepStandard.Text = "Reporte Standard"
        Me.radRepStandard.UseVisualStyleBackColor = True
        '
        'radRepExtendido
        '
        Me.radRepExtendido.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radRepExtendido.AutoSize = True
        Me.radRepExtendido.Checked = True
        Me.radRepExtendido.Location = New System.Drawing.Point(133, 50)
        Me.radRepExtendido.Name = "radRepExtendido"
        Me.radRepExtendido.Size = New System.Drawing.Size(113, 17)
        Me.radRepExtendido.TabIndex = 1
        Me.radRepExtendido.TabStop = True
        Me.radRepExtendido.Text = "Reporte Extendido"
        Me.radRepExtendido.UseVisualStyleBackColor = True
        '
        'radPaking
        '
        Me.radPaking.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radPaking.AutoSize = True
        Me.radPaking.Checked = True
        Me.radPaking.Location = New System.Drawing.Point(252, 50)
        Me.radPaking.Name = "radPaking"
        Me.radPaking.Size = New System.Drawing.Size(99, 17)
        Me.radPaking.TabIndex = 10
        Me.radPaking.TabStop = True
        Me.radPaking.Text = "Reporte Paking"
        Me.radPaking.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(497, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Terminal:"
        '
        'cboTerminales
        '
        Me.cboTerminales.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTerminales.FormattingEnabled = True
        Me.cboTerminales.Location = New System.Drawing.Point(556, 48)
        Me.cboTerminales.Name = "cboTerminales"
        Me.cboTerminales.Size = New System.Drawing.Size(248, 21)
        Me.cboTerminales.TabIndex = 13
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnConsultar.Location = New System.Drawing.Point(1369, 19)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 22)
        Me.btnConsultar.TabIndex = 4
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Location = New System.Drawing.Point(1450, 19)
        Me.btnExportar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(80, 22)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmRrhhReporteAsistenciaChronos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1548, 524)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmRrhhReporteAsistenciaChronos"
        Me.Text = "Rrhh / Reportes / Reporte De Asistencia Chronos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pkrDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents radRepStandard As System.Windows.Forms.RadioButton
    Friend WithEvents radRepExtendido As System.Windows.Forms.RadioButton
    Friend WithEvents radPaking As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents cboTerminales As ComboBox
    Friend WithEvents radRefrigerio As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents txtCodigo As TextBox
End Class
