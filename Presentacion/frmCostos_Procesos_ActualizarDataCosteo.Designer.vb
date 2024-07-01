<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostos_Procesos_ActualizarDataCosteo
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
        Me.btnFormato = New System.Windows.Forms.Button()
        Me.btnPuntitos = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.txtRutaExcel = New System.Windows.Forms.TextBox()
        Me.lblDin_Resultado = New System.Windows.Forms.Label()
        Me.barProgreso = New System.Windows.Forms.ProgressBar()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 8
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.btnFormato, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnPuntitos, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnImportar, 4, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnProcesar, 6, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnExportar, 6, 4)
        Me.tlpPrincipal.Controls.Add(Me.txtRutaExcel, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.lblDin_Resultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.barProgreso, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 2)
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
        Me.tlpPrincipal.Size = New System.Drawing.Size(1019, 498)
        Me.tlpPrincipal.TabIndex = 0
        '
        'btnFormato
        '
        Me.btnFormato.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnFormato.Location = New System.Drawing.Point(18, 18)
        Me.btnFormato.Name = "btnFormato"
        Me.btnFormato.Size = New System.Drawing.Size(35, 23)
        Me.btnFormato.TabIndex = 0
        Me.btnFormato.Text = "?"
        Me.btnFormato.UseVisualStyleBackColor = True
        '
        'btnPuntitos
        '
        Me.btnPuntitos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnPuntitos.Location = New System.Drawing.Point(59, 18)
        Me.btnPuntitos.Name = "btnPuntitos"
        Me.btnPuntitos.Size = New System.Drawing.Size(35, 23)
        Me.btnPuntitos.TabIndex = 1
        Me.btnPuntitos.Text = "..."
        Me.btnPuntitos.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnImportar.Location = New System.Drawing.Point(322, 18)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 2
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnProcesar.Location = New System.Drawing.Point(921, 18)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 3
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(921, 457)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'txtRutaExcel
        '
        Me.txtRutaExcel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRutaExcel.Location = New System.Drawing.Point(100, 18)
        Me.txtRutaExcel.Name = "txtRutaExcel"
        Me.txtRutaExcel.Size = New System.Drawing.Size(216, 20)
        Me.txtRutaExcel.TabIndex = 5
        '
        'lblDin_Resultado
        '
        Me.lblDin_Resultado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblDin_Resultado, 2)
        Me.lblDin_Resultado.Location = New System.Drawing.Point(18, 457)
        Me.lblDin_Resultado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblDin_Resultado.Name = "lblDin_Resultado"
        Me.lblDin_Resultado.Size = New System.Drawing.Size(32, 13)
        Me.lblDin_Resultado.TabIndex = 6
        Me.lblDin_Resultado.Text = "Listo!"
        '
        'barProgreso
        '
        Me.tlpPrincipal.SetColumnSpan(Me.barProgreso, 6)
        Me.barProgreso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.barProgreso.Location = New System.Drawing.Point(18, 428)
        Me.barProgreso.Name = "barProgreso"
        Me.barProgreso.Size = New System.Drawing.Size(978, 23)
        Me.barProgreso.TabIndex = 7
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 6)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 47)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(978, 375)
        Me.dgvResultado.TabIndex = 8
        '
        'frmCostos_Procesos_ActualizarDataCosteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 498)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmCostos_Procesos_ActualizarDataCosteo"
        Me.Text = " Costos / Procesos / Actualizar Data de Costeo"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnFormato As System.Windows.Forms.Button
    Friend WithEvents btnPuntitos As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents txtRutaExcel As System.Windows.Forms.TextBox
    Friend WithEvents lblDin_Resultado As System.Windows.Forms.Label
    Friend WithEvents barProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
End Class
