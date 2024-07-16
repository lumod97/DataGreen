<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRrhh_Reportes_CheckListCalculoPlanilla
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.cboTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.cboPlanilla = New System.Windows.Forms.ComboBox()
        Me.cboPeriodo = New System.Windows.Forms.ComboBox()
        Me.cboSemanaDesde = New System.Windows.Forms.ComboBox()
        Me.cboSemanaHasta = New System.Windows.Forms.ComboBox()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 15
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
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label4, 7, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label5, 9, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.cboTipoMovimiento, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPlanilla, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboPeriodo, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboSemanaDesde, 8, 1)
        Me.tlpPrincipal.Controls.Add(Me.cboSemanaHasta, 10, 1)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.btnConsultar, 12, 1)
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(1169, 498)
        Me.tlpPrincipal.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Movimiento:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Planilla:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Periodo:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(594, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Semana Desde:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(810, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Semana Hasta:"
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 470)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(215, 13)
        Me.lblDin_Resultado.TabIndex = 5
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 13)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 444)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(1133, 23)
        Me.barProgreso.TabIndex = 6
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTipoMovimiento.FormattingEnabled = True
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(112, 19)
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoMovimiento.TabIndex = 7
        '
        'cboPlanilla
        '
        Me.cboPlanilla.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPlanilla.FormattingEnabled = True
        Me.cboPlanilla.Location = New System.Drawing.Point(288, 19)
        Me.cboPlanilla.Name = "cboPlanilla"
        Me.cboPlanilla.Size = New System.Drawing.Size(121, 21)
        Me.cboPlanilla.TabIndex = 8
        '
        'cboPeriodo
        '
        Me.cboPeriodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPeriodo.FormattingEnabled = True
        Me.cboPeriodo.Location = New System.Drawing.Point(467, 19)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        Me.cboPeriodo.TabIndex = 9
        '
        'cboSemanaDesde
        '
        Me.cboSemanaDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSemanaDesde.FormattingEnabled = True
        Me.cboSemanaDesde.Location = New System.Drawing.Point(683, 19)
        Me.cboSemanaDesde.Name = "cboSemanaDesde"
        Me.cboSemanaDesde.Size = New System.Drawing.Size(121, 21)
        Me.cboSemanaDesde.TabIndex = 10
        '
        'cboSemanaHasta
        '
        Me.cboSemanaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSemanaHasta.FormattingEnabled = True
        Me.cboSemanaHasta.Location = New System.Drawing.Point(896, 19)
        Me.cboSemanaHasta.Name = "cboSemanaHasta"
        Me.cboSemanaHasta.Size = New System.Drawing.Size(121, 21)
        Me.cboSemanaHasta.TabIndex = 11
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 13)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 47)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(1133, 391)
        Me.dgvResultado.TabIndex = 12
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Location = New System.Drawing.Point(1049, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 13
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'frmRrhh_Reportes_CheckListCalculoPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 498)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Reportes_CheckListCalculoPlanilla"
        Me.Text = "Rrhh / Reportes / Check List de Calculo Planilla"
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
    Friend WithEvents Label5 As Label
    Friend WithEvents lblDin_Resultado As Label
    Friend WithEvents barProgreso As ProgressBar
    Friend WithEvents cboTipoMovimiento As ComboBox
    Friend WithEvents cboPlanilla As ComboBox
    Friend WithEvents cboPeriodo As ComboBox
    Friend WithEvents cboSemanaDesde As ComboBox
    Friend WithEvents cboSemanaHasta As ComboBox
    Friend WithEvents dgvResultado As DataGridView
    Friend WithEvents btnConsultar As Button
End Class
