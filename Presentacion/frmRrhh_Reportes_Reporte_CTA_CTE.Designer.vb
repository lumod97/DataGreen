<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_Reporte_CTA_CTE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.cboPresentacion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboAmbito = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.txtTrabajador = New System.Windows.Forms.TextBox()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPeriodoDesde = New System.Windows.Forms.TextBox()
        Me.txtPeriodoHasta = New System.Windows.Forms.TextBox()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 14
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 12, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPresentacion, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboAmbito, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboMoneda, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label1, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label6, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPlanilla, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.txtTrabajador, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label7, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtPeriodoDesde, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtPeriodoHasta, 4, 2)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 7
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1343, 588)
        Me.tlpPrincipal.TabIndex = 0
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Location = New System.Drawing.Point(1250, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cboPresentacion
        '
        Me.cboPresentacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPresentacion.FormattingEnabled = True
        Me.cboPresentacion.Location = New System.Drawing.Point(1047, 19)
        Me.cboPresentacion.Name = "cboPresentacion"
        Me.cboPresentacion.Size = New System.Drawing.Size(136, 21)
        Me.cboPresentacion.TabIndex = 6
        Me.cboPresentacion.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(966, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Presentacion: "
        Me.Label4.Visible = False
        '
        'cboAmbito
        '
        Me.cboAmbito.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAmbito.FormattingEnabled = True
        Me.cboAmbito.Location = New System.Drawing.Point(781, 19)
        Me.cboAmbito.Name = "cboAmbito"
        Me.cboAmbito.Size = New System.Drawing.Size(179, 21)
        Me.cboAmbito.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(730, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Ambito: "
        '
        'cboMoneda
        '
        Me.cboMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(554, 19)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(170, 21)
        Me.cboMoneda.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(496, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Moneda: "
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(299, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Trabajador: "
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Planilla"
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(102, 19)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(191, 21)
        Me.cboPlanilla.TabIndex = 10
        '
        'txtTrabajador
        '
        Me.txtTrabajador.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTrabajador.Location = New System.Drawing.Point(380, 19)
        Me.txtTrabajador.Name = "txtTrabajador"
        Me.txtTrabajador.Size = New System.Drawing.Size(110, 20)
        Me.txtTrabajador.TabIndex = 27
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDin_Resultado.AutoSize = True
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 557)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 30
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 12)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 528)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1307, 23)
        Me.barProgreso.TabIndex = 31
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 12)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 73)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1307, 449)
        Me.dgvResultado.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Periodo desde:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(299, 50)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Periodo hasta:"
        '
        'txtPeriodoDesde
        '
        Me.txtPeriodoDesde.Location = New System.Drawing.Point(102, 47)
        Me.txtPeriodoDesde.Name = "txtPeriodoDesde"
        Me.txtPeriodoDesde.Size = New System.Drawing.Size(100, 20)
        Me.txtPeriodoDesde.TabIndex = 35
        '
        'txtPeriodoHasta
        '
        Me.txtPeriodoHasta.Location = New System.Drawing.Point(380, 47)
        Me.txtPeriodoHasta.Name = "txtPeriodoHasta"
        Me.txtPeriodoHasta.Size = New System.Drawing.Size(100, 20)
        Me.txtPeriodoHasta.TabIndex = 36
        '
        'frmRrhh_Reportes_Reporte_CTA_CTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1343, 588)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_Reporte_CTA_CTE"
        Me.Text = "fmrRRHH_Reportes_CTA_CTE"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboMoneda As ComboBox
    Friend WithEvents cboAmbito As ComboBox
    Friend WithEvents cboPresentacion As ComboBox
    Friend WithEvents btnConsultar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents txtTrabajador As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents txtPeriodoDesde As TextBox
    Friend WithEvents txtPeriodoHasta As TextBox
End Class
