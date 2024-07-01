<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRrhhAsisRpteFaltas
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.grpPersonas = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.radPersonasCodigo = New System.Windows.Forms.RadioButton()
        Me.radPersonasTodos = New System.Windows.Forms.RadioButton()
        Me.radPersonasPlanillas = New System.Windows.Forms.RadioButton()
        Me.txtPersonasCodigo = New System.Windows.Forms.TextBox()
        Me.cbxSoloActivos = New System.Windows.Forms.CheckBox()
        Me.cbxExcluirJustificaciones = New System.Windows.Forms.CheckBox()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.radRpteConsecutivas = New System.Windows.Forms.RadioButton()
        Me.floRpteRango = New System.Windows.Forms.FlowLayoutPanel()
        Me.pkrRpteHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pkrRpteDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.floRpteConsecutivas = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRpteFaltasConsecutivas = New System.Windows.Forms.TextBox()
        Me.radRpteRango = New System.Windows.Forms.RadioButton()
        Me.radRpteTodasFaltas = New System.Windows.Forms.RadioButton()
        Me.grpTipoReporte = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPersonas.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.floRpteRango.SuspendLayout()
        Me.floRpteConsecutivas.SuspendLayout()
        Me.grpTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpTipoReporte, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConsultar, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExportar, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvResultado, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.grpPersonas, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.barProgreso, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDin_Resultado, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 5, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(954, 440)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnConsultar
        '
        Me.btnConsultar.AutoSize = True
        Me.btnConsultar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnConsultar.Location = New System.Drawing.Point(812, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(61, 23)
        Me.btnConsultar.TabIndex = 3
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.AutoSize = True
        Me.btnExportar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExportar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExportar.Location = New System.Drawing.Point(879, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(56, 23)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvResultado, 6)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 95)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(917, 287)
        Me.dgvResultado.TabIndex = 6
        '
        'grpPersonas
        '
        Me.grpPersonas.AutoSize = True
        Me.grpPersonas.Controls.Add(Me.TableLayoutPanel3)
        Me.grpPersonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPersonas.Location = New System.Drawing.Point(393, 18)
        Me.grpPersonas.Name = "grpPersonas"
        Me.grpPersonas.Size = New System.Drawing.Size(377, 71)
        Me.grpPersonas.TabIndex = 7
        Me.grpPersonas.TabStop = False
        Me.grpPersonas.Text = "Personas"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.radPersonasCodigo, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.radPersonasTodos, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.radPersonasPlanillas, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtPersonasCodigo, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxSoloActivos, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxExcluirJustificaciones, 3, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(371, 52)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'radPersonasCodigo
        '
        Me.radPersonasCodigo.AutoSize = True
        Me.radPersonasCodigo.Location = New System.Drawing.Point(3, 29)
        Me.radPersonasCodigo.Name = "radPersonasCodigo"
        Me.radPersonasCodigo.Size = New System.Drawing.Size(61, 17)
        Me.radPersonasCodigo.TabIndex = 0
        Me.radPersonasCodigo.TabStop = True
        Me.radPersonasCodigo.Text = "Codigo:"
        Me.radPersonasCodigo.UseVisualStyleBackColor = True
        '
        'radPersonasTodos
        '
        Me.radPersonasTodos.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.radPersonasTodos, 2)
        Me.radPersonasTodos.Location = New System.Drawing.Point(3, 3)
        Me.radPersonasTodos.Name = "radPersonasTodos"
        Me.radPersonasTodos.Size = New System.Drawing.Size(55, 17)
        Me.radPersonasTodos.TabIndex = 0
        Me.radPersonasTodos.TabStop = True
        Me.radPersonasTodos.Text = "Todos"
        Me.radPersonasTodos.UseVisualStyleBackColor = True
        '
        'radPersonasPlanillas
        '
        Me.radPersonasPlanillas.AutoSize = True
        Me.radPersonasPlanillas.Location = New System.Drawing.Point(156, 3)
        Me.radPersonasPlanillas.Name = "radPersonasPlanillas"
        Me.radPersonasPlanillas.Size = New System.Drawing.Size(63, 17)
        Me.radPersonasPlanillas.TabIndex = 0
        Me.radPersonasPlanillas.TabStop = True
        Me.radPersonasPlanillas.Text = "Planillas"
        Me.radPersonasPlanillas.UseVisualStyleBackColor = True
        '
        'txtPersonasCodigo
        '
        Me.txtPersonasCodigo.Location = New System.Drawing.Point(70, 29)
        Me.txtPersonasCodigo.Name = "txtPersonasCodigo"
        Me.txtPersonasCodigo.Size = New System.Drawing.Size(80, 20)
        Me.txtPersonasCodigo.TabIndex = 1
        '
        'cbxSoloActivos
        '
        Me.cbxSoloActivos.AutoSize = True
        Me.cbxSoloActivos.Checked = True
        Me.cbxSoloActivos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxSoloActivos.Enabled = False
        Me.cbxSoloActivos.Location = New System.Drawing.Point(225, 6)
        Me.cbxSoloActivos.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.cbxSoloActivos.Name = "cbxSoloActivos"
        Me.cbxSoloActivos.Size = New System.Drawing.Size(85, 17)
        Me.cbxSoloActivos.TabIndex = 6
        Me.cbxSoloActivos.Text = "Solo Activos"
        Me.cbxSoloActivos.UseVisualStyleBackColor = True
        '
        'cbxExcluirJustificaciones
        '
        Me.cbxExcluirJustificaciones.AutoSize = True
        Me.cbxExcluirJustificaciones.Location = New System.Drawing.Point(225, 32)
        Me.cbxExcluirJustificaciones.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
        Me.cbxExcluirJustificaciones.Name = "cbxExcluirJustificaciones"
        Me.cbxExcluirJustificaciones.Size = New System.Drawing.Size(143, 17)
        Me.cbxExcluirJustificaciones.TabIndex = 4
        Me.cbxExcluirJustificaciones.Text = "Incluir Faltas Justificadas"
        Me.cbxExcluirJustificaciones.UseVisualStyleBackColor = True
        '
        'barProgreso
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.barProgreso, 6)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 388)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(917, 14)
        Me.barProgreso.TabIndex = 8
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 408)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(58, 13)
        Me.lblDin_Resultado.TabIndex = 9
        Me.lblDin_Resultado.Text = "Resultado:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.radRpteTodasFaltas, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.radRpteRango, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.floRpteConsecutivas, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.floRpteRango, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.radRpteConsecutivas, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(328, 52)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'radRpteConsecutivas
        '
        Me.radRpteConsecutivas.AutoSize = True
        Me.radRpteConsecutivas.Location = New System.Drawing.Point(108, 3)
        Me.radRpteConsecutivas.Name = "radRpteConsecutivas"
        Me.radRpteConsecutivas.Size = New System.Drawing.Size(89, 17)
        Me.radRpteConsecutivas.TabIndex = 6
        Me.radRpteConsecutivas.TabStop = True
        Me.radRpteConsecutivas.Text = "Consecutivas"
        Me.radRpteConsecutivas.UseVisualStyleBackColor = True
        '
        'floRpteRango
        '
        Me.floRpteRango.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.floRpteRango, 3)
        Me.floRpteRango.Controls.Add(Me.Label3)
        Me.floRpteRango.Controls.Add(Me.pkrRpteDesde)
        Me.floRpteRango.Controls.Add(Me.Label4)
        Me.floRpteRango.Controls.Add(Me.pkrRpteHasta)
        Me.floRpteRango.Location = New System.Drawing.Point(63, 26)
        Me.floRpteRango.Margin = New System.Windows.Forms.Padding(0)
        Me.floRpteRango.Name = "floRpteRango"
        Me.floRpteRango.Size = New System.Drawing.Size(263, 26)
        Me.floRpteRango.TabIndex = 8
        '
        'pkrRpteHasta
        '
        Me.pkrRpteHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrRpteHasta.Location = New System.Drawing.Point(180, 3)
        Me.pkrRpteHasta.Name = "pkrRpteHasta"
        Me.pkrRpteHasta.Size = New System.Drawing.Size(80, 20)
        Me.pkrRpteHasta.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 7)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta:"
        '
        'pkrRpteDesde
        '
        Me.pkrRpteDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.pkrRpteDesde.Location = New System.Drawing.Point(50, 3)
        Me.pkrRpteDesde.Name = "pkrRpteDesde"
        Me.pkrRpteDesde.Size = New System.Drawing.Size(80, 20)
        Me.pkrRpteDesde.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Desde:"
        '
        'floRpteConsecutivas
        '
        Me.floRpteConsecutivas.AutoSize = True
        Me.floRpteConsecutivas.Controls.Add(Me.txtRpteFaltasConsecutivas)
        Me.floRpteConsecutivas.Controls.Add(Me.Label1)
        Me.floRpteConsecutivas.Location = New System.Drawing.Point(200, 0)
        Me.floRpteConsecutivas.Margin = New System.Windows.Forms.Padding(0)
        Me.floRpteConsecutivas.Name = "floRpteConsecutivas"
        Me.floRpteConsecutivas.Size = New System.Drawing.Size(128, 26)
        Me.floRpteConsecutivas.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Faltas o más"
        '
        'txtRpteFaltasConsecutivas
        '
        Me.txtRpteFaltasConsecutivas.Location = New System.Drawing.Point(3, 3)
        Me.txtRpteFaltasConsecutivas.Name = "txtRpteFaltasConsecutivas"
        Me.txtRpteFaltasConsecutivas.Size = New System.Drawing.Size(50, 20)
        Me.txtRpteFaltasConsecutivas.TabIndex = 0
        Me.txtRpteFaltasConsecutivas.Text = "3"
        '
        'radRpteRango
        '
        Me.radRpteRango.AutoSize = True
        Me.radRpteRango.Location = New System.Drawing.Point(3, 29)
        Me.radRpteRango.Name = "radRpteRango"
        Me.radRpteRango.Size = New System.Drawing.Size(57, 17)
        Me.radRpteRango.TabIndex = 4
        Me.radRpteRango.TabStop = True
        Me.radRpteRango.Text = "Rango"
        Me.radRpteRango.UseVisualStyleBackColor = True
        '
        'radRpteTodasFaltas
        '
        Me.radRpteTodasFaltas.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.radRpteTodasFaltas, 2)
        Me.radRpteTodasFaltas.Location = New System.Drawing.Point(3, 3)
        Me.radRpteTodasFaltas.Name = "radRpteTodasFaltas"
        Me.radRpteTodasFaltas.Size = New System.Drawing.Size(99, 17)
        Me.radRpteTodasFaltas.TabIndex = 3
        Me.radRpteTodasFaltas.TabStop = True
        Me.radRpteTodasFaltas.Text = "Todas las faltas"
        Me.radRpteTodasFaltas.UseVisualStyleBackColor = True
        '
        'grpTipoReporte
        '
        Me.grpTipoReporte.AutoSize = True
        Me.grpTipoReporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grpTipoReporte.Controls.Add(Me.TableLayoutPanel2)
        Me.grpTipoReporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTipoReporte.Location = New System.Drawing.Point(53, 18)
        Me.grpTipoReporte.Name = "grpTipoReporte"
        Me.grpTipoReporte.Size = New System.Drawing.Size(334, 71)
        Me.grpTipoReporte.TabIndex = 0
        Me.grpTipoReporte.TabStop = False
        Me.grpTipoReporte.Text = "Tipo de Reporte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Location = New System.Drawing.Point(812, 408)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Listo"
        '
        'frmRrhhAsisRpteFaltas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(954, 440)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmRrhhAsisRpteFaltas"
        Me.Text = "Rrhh / Reportes / Reporte de Faltas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPersonas.ResumeLayout(False)
        Me.grpPersonas.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.floRpteRango.ResumeLayout(False)
        Me.floRpteRango.PerformLayout()
        Me.floRpteConsecutivas.ResumeLayout(False)
        Me.floRpteConsecutivas.PerformLayout()
        Me.grpTipoReporte.ResumeLayout(False)
        Me.grpTipoReporte.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents grpPersonas As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents radPersonasTodos As System.Windows.Forms.RadioButton
    Friend WithEvents radPersonasCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents txtPersonasCodigo As System.Windows.Forms.TextBox
    Friend WithEvents radPersonasPlanillas As System.Windows.Forms.RadioButton
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents cbxSoloActivos As System.Windows.Forms.CheckBox
    Friend WithEvents cbxExcluirJustificaciones As System.Windows.Forms.CheckBox
    Friend WithEvents grpTipoReporte As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents radRpteTodasFaltas As System.Windows.Forms.RadioButton
    Friend WithEvents radRpteRango As System.Windows.Forms.RadioButton
    Friend WithEvents floRpteConsecutivas As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtRpteFaltasConsecutivas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents floRpteRango As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pkrRpteDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pkrRpteHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents radRpteConsecutivas As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
