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
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.scrollablePanel = New System.Windows.Forms.Panel()
        Me.tlpEditables = New System.Windows.Forms.TableLayoutPanel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1 = New DataGreen.ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblUsuarioAfecto = New System.Windows.Forms.Label()
        Me.tbUsuarioAfecto = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFormulario = New System.Windows.Forms.TextBox()
        Me.tlpPrivilegios.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scrollablePanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpPrivilegios
        '
        Me.tlpPrivilegios.ColumnCount = 2
        Me.tlpPrivilegios.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tlpPrivilegios.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tlpPrivilegios.Controls.Add(Me.dgvUsuarios, 0, 1)
        Me.tlpPrivilegios.Controls.Add(Me.scrollablePanel, 1, 1)
        Me.tlpPrivilegios.Controls.Add(Me.btnUpdate, 1, 2)
        Me.tlpPrivilegios.Controls.Add(Me.TableLayoutPanel1, 0, 0)
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
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Actualizar"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1
        '
        Me.Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1.ClearBeforeFill = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.tlpPrivilegios.SetColumnSpan(Me.TableLayoutPanel1, 2)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblUsuarioAfecto, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbUsuarioAfecto, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbUsuario, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAgregar, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFormulario, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(953, 34)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'lblUsuarioAfecto
        '
        Me.lblUsuarioAfecto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUsuarioAfecto.AutoSize = True
        Me.lblUsuarioAfecto.Location = New System.Drawing.Point(217, 10)
        Me.lblUsuarioAfecto.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.lblUsuarioAfecto.Name = "lblUsuarioAfecto"
        Me.lblUsuarioAfecto.Size = New System.Drawing.Size(77, 13)
        Me.lblUsuarioAfecto.TabIndex = 6
        Me.lblUsuarioAfecto.Text = "Usuario Afecto"
        '
        'tbUsuarioAfecto
        '
        Me.tbUsuarioAfecto.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbUsuarioAfecto.Location = New System.Drawing.Point(300, 7)
        Me.tbUsuarioAfecto.Name = "tbUsuarioAfecto"
        Me.tbUsuarioAfecto.Size = New System.Drawing.Size(172, 20)
        Me.tbUsuarioAfecto.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAgregar.Location = New System.Drawing.Point(711, 5)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Usuario"
        '
        'tbUsuario
        '
        Me.tbUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbUsuario.Location = New System.Drawing.Point(52, 7)
        Me.tbUsuario.Name = "tbUsuario"
        Me.tbUsuario.Size = New System.Drawing.Size(152, 20)
        Me.tbUsuario.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(485, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Formulario"
        '
        'tbFormulario
        '
        Me.tbFormulario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbFormulario.Location = New System.Drawing.Point(546, 7)
        Me.tbFormulario.Name = "tbFormulario"
        Me.tbFormulario.Size = New System.Drawing.Size(152, 20)
        Me.tbFormulario.TabIndex = 2
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
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scrollablePanel.ResumeLayout(False)
        Me.scrollablePanel.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpPrivilegios As TableLayoutPanel
    Friend WithEvents Sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter1 As ds_Dg_ReportesTableAdapters.sp_Dg_Exportaciones_Reportes_PackingList_T1TableAdapter
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents scrollablePanel As Panel
    Friend WithEvents tlpEditables As TableLayoutPanel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblUsuarioAfecto As Label
    Friend WithEvents tbUsuarioAfecto As TextBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tbUsuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbFormulario As TextBox
End Class
