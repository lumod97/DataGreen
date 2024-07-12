<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_ComparativaUltimoMovimientoPlanilla
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
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Semana = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.cboDocumento = New System.Windows.Forms.ComboBox()
        Me.cboPeriodo = New System.Windows.Forms.ComboBox()
        Me.cboSemana = New System.Windows.Forms.ComboBox()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 13
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
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
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPlanilla, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.Semana, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 11, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.cboDocumento, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPeriodo, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboSemana, 8, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 6
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(1061, 541)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Planilla: "
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(70, 19)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(200, 21)
        Me.cboPlanilla.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Documento:"
        '
        'Semana
        '
        Me.Semana.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Semana.AutoSize = True
        Me.Semana.Location = New System.Drawing.Point(711, 23)
        Me.Semana.Name = "Semana"
        Me.Semana.Size = New System.Drawing.Size(49, 13)
        Me.Semana.TabIndex = 6
        Me.Semana.Text = "Semana:"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.AutoSize = True
        Me.btnConsultar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnConsultar.Location = New System.Drawing.Point(920, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(61, 23)
        Me.btnConsultar.TabIndex = 8
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.AutoSize = True
        Me.btnExportar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExportar.Location = New System.Drawing.Point(987, 18)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(56, 23)
        Me.btnExportar.TabIndex = 9
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(553, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Periodo:"
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 513)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(252, 13)
        Me.lblDin_Resultado.TabIndex = 10
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 11)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 487)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1025, 23)
        Me.barProgreso.TabIndex = 11
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 11)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 47)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1025, 434)
        Me.dgvResultado.TabIndex = 12
        '
        'cboDocumento
        '
        Me.cboDocumento.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboDocumento.FormattingEnabled = True
        Me.cboDocumento.Location = New System.Drawing.Point(347, 19)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(200, 21)
        Me.cboDocumento.TabIndex = 13
        '
        'cboPeriodo
        '
        Me.cboPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboPeriodo.FormattingEnabled = True
        Me.cboPeriodo.Location = New System.Drawing.Point(605, 19)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(100, 21)
        Me.cboPeriodo.TabIndex = 14
        '
        'cboSemana
        '
        Me.cboSemana.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSemana.FormattingEnabled = True
        Me.cboSemana.Location = New System.Drawing.Point(766, 19)
        Me.cboSemana.Name = "cboSemana"
        Me.cboSemana.Size = New System.Drawing.Size(80, 21)
        Me.cboSemana.TabIndex = 15
        '
        'frmRrhh_Reportes_ComparativaUltimoMovimientoPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 541)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_ComparativaUltimoMovimientoPlanilla"
        Me.Text = "Rrhh / Reportes / Comparativo de Ultimos Movimientos de Planilla"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Semana As Label
    Friend WithEvents btnConsultar As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents cboDocumento As ComboBox
    Friend WithEvents cboPeriodo As ComboBox
    Friend WithEvents cboSemana As ComboBox
End Class
