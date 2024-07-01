<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizarSistema
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
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblVersionActual = New System.Windows.Forms.Label()
        Me.lblVersionDisponible = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnActualizar
        '
        Me.btnActualizar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnActualizar.Location = New System.Drawing.Point(258, 135)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(123, 23)
        Me.btnActualizar.TabIndex = 0
        Me.btnActualizar.Text = "Si, Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancelar.Location = New System.Drawing.Point(3, 135)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbl1, 2)
        Me.lbl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl1.Location = New System.Drawing.Point(130, 3)
        Me.lbl1.Margin = New System.Windows.Forms.Padding(3)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(251, 27)
        Me.lbl1.TabIndex = 2
        Me.lbl1.Text = "Se ha detectado una nueva version del sistema."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnActualizar, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancelar, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblVersionActual, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblVersionDisponible, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl2, 1, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 161)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'lblVersionActual
        '
        Me.lblVersionActual.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblVersionActual, 2)
        Me.lblVersionActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblVersionActual.Location = New System.Drawing.Point(130, 36)
        Me.lblVersionActual.Margin = New System.Windows.Forms.Padding(3)
        Me.lblVersionActual.Name = "lblVersionActual"
        Me.lblVersionActual.Size = New System.Drawing.Size(251, 27)
        Me.lblVersionActual.TabIndex = 3
        Me.lblVersionActual.Text = "Version Actual: "
        '
        'lblVersionDisponible
        '
        Me.lblVersionDisponible.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblVersionDisponible, 2)
        Me.lblVersionDisponible.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblVersionDisponible.Location = New System.Drawing.Point(130, 69)
        Me.lblVersionDisponible.Margin = New System.Windows.Forms.Padding(3)
        Me.lblVersionDisponible.Name = "lblVersionDisponible"
        Me.lblVersionDisponible.Size = New System.Drawing.Size(251, 27)
        Me.lblVersionDisponible.TabIndex = 4
        Me.lblVersionDisponible.Text = "Version Disponible: "
        '
        'lbl2
        '
        Me.lbl2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbl2, 2)
        Me.lbl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl2.Location = New System.Drawing.Point(130, 102)
        Me.lbl2.Margin = New System.Windows.Forms.Padding(3)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(251, 27)
        Me.lbl2.TabIndex = 5
        Me.lbl2.Text = "¿Desea Actualizar el sistema ahora?"
        '
        'frmActualizarSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 161)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActualizarSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizacion de Sistema"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblVersionActual As System.Windows.Forms.Label
    Friend WithEvents lblVersionDisponible As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
End Class
