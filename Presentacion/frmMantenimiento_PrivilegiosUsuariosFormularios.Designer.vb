<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMantenimiento_PrivilegiosUsuariosFormularios
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
        Me.tlpPrivilegios = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpPrincipal = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDNI = New System.Windows.Forms.Label()
        Me.tbDNI = New System.Windows.Forms.TextBox()
        Me.tbUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.scrollablePanel = New System.Windows.Forms.Panel()
        Me.tlpEditables = New System.Windows.Forms.TableLayoutPanel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1 = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter()
        Me.tlpPrivilegios.SuspendLayout()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scrollablePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrivilegios
        '
        Me.tlpPrivilegios.ColumnCount = 2
        Me.tlpPrivilegios.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpPrivilegios.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpPrivilegios.Controls.Add(Me.tlpPrincipal, 0, 0)
        Me.tlpPrivilegios.Controls.Add(Me.dgvUsuarios, 0, 1)
        Me.tlpPrivilegios.Controls.Add(Me.scrollablePanel, 1, 1)
        Me.tlpPrivilegios.Controls.Add(Me.btnUpdate, 1, 2)
        Me.tlpPrivilegios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrivilegios.Location = New System.Drawing.Point(10, 10)
        Me.tlpPrivilegios.Name = "tlpPrivilegios"
        Me.tlpPrivilegios.RowCount = 3
        Me.tlpPrivilegios.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpPrivilegios.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrivilegios.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrivilegios.Size = New System.Drawing.Size(959, 452)
        Me.tlpPrivilegios.TabIndex = 0
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 5
        Me.tlpPrivilegios.SetColumnSpan(Me.tlpPrincipal, 2)
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.Controls.Add(Me.lblDNI, 0, 0)
        Me.tlpPrincipal.Controls.Add(Me.tbDNI, 1, 0)
        Me.tlpPrincipal.Controls.Add(Me.tbUsuario, 3, 0)
        Me.tlpPrincipal.Controls.Add(Me.Label1, 2, 0)
        Me.tlpPrincipal.Controls.Add(Me.btnBuscar, 4, 0)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(3, 3)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 1
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(953, 34)
        Me.tlpPrincipal.TabIndex = 0
        Me.tlpPrincipal.Visible = False
        '
        'lblDNI
        '
        Me.lblDNI.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDNI.AutoSize = True
        Me.lblDNI.Location = New System.Drawing.Point(3, 10)
        Me.lblDNI.Name = "lblDNI"
        Me.lblDNI.Size = New System.Drawing.Size(26, 13)
        Me.lblDNI.TabIndex = 0
        Me.lblDNI.Text = "DNI"
        '
        'tbDNI
        '
        Me.tbDNI.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbDNI.Location = New System.Drawing.Point(35, 7)
        Me.tbDNI.Name = "tbDNI"
        Me.tbDNI.Size = New System.Drawing.Size(180, 20)
        Me.tbDNI.TabIndex = 2
        '
        'tbUsuario
        '
        Me.tbUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbUsuario.Location = New System.Drawing.Point(270, 7)
        Me.tbUsuario.Name = "tbUsuario"
        Me.tbUsuario.Size = New System.Drawing.Size(180, 20)
        Me.tbUsuario.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(221, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario"
        '
        'btnBuscar
        '
        Me.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBuscar.Location = New System.Drawing.Point(456, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 28)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AllowUserToResizeColumns = False
        Me.dgvUsuarios.AllowUserToResizeRows = False
        Me.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarios.Location = New System.Drawing.Point(3, 43)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.RowHeadersVisible = False
        Me.tlpPrivilegios.SetRowSpan(Me.dgvUsuarios, 2)
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(329, 406)
        Me.dgvUsuarios.TabIndex = 1
        '
        'scrollablePanel
        '
        Me.scrollablePanel.Controls.Add(Me.tlpEditables)
        Me.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scrollablePanel.Location = New System.Drawing.Point(338, 43)
        Me.scrollablePanel.Name = "scrollablePanel"
        Me.scrollablePanel.Size = New System.Drawing.Size(618, 377)
        Me.scrollablePanel.TabIndex = 2
        '
        'tlpEditables
        '
        Me.tlpEditables.AutoSize = True
        Me.tlpEditables.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlpEditables.ColumnCount = 1
        Me.tlpEditables.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpEditables.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpEditables.Location = New System.Drawing.Point(0, 0)
        Me.tlpEditables.Name = "tlpEditables"
        Me.tlpEditables.RowCount = 1
        Me.tlpEditables.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpEditables.Size = New System.Drawing.Size(618, 2)
        Me.tlpEditables.TabIndex = 3
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnUpdate.Location = New System.Drawing.Point(881, 426)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Actualizar"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1
        '
        Me.Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1.ClearBeforeFill = True
        '
        'frmMantenimiento_PrivilegiosUsuariosFormularios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 472)
        Me.Controls.Add(Me.tlpPrivilegios)
        Me.Name = "frmMantenimiento_PrivilegiosUsuariosFormularios"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "frmMantenimiento_PrivilegiosUsuariosFormularios"
        Me.tlpPrivilegios.ResumeLayout(False)
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scrollablePanel.ResumeLayout(False)
        Me.scrollablePanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrivilegios As TableLayoutPanel
    Friend WithEvents tlpPrincipal As TableLayoutPanel
    Friend WithEvents lblDNI As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbDNI As TextBox
    Friend WithEvents tbUsuario As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1 As ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents scrollablePanel As Panel
    Friend WithEvents tlpEditables As TableLayoutPanel
    Friend WithEvents btnUpdate As Button
End Class
