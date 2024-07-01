<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRrhh_Movimientos_DefinicionHorarios
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
        Me.txtAccion = New System.Windows.Forms.TextBox()
        Me.dgvResultado = New System.Windows.Forms.DataGridView()
        Me.cboHorarios = New System.Windows.Forms.ComboBox()
        Me.txtNombreHorario = New System.Windows.Forms.TextBox()
        Me.btnAgregarAccion = New System.Windows.Forms.Button()
        Me.btnCopiarDiaAnterior = New System.Windows.Forms.Button()
        Me.btnLimpiarDia = New System.Windows.Forms.Button()
        Me.btnEliminarAccion = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalHorasSemana = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblHorarioSeleccionado = New System.Windows.Forms.Label()
        Me.btnNuevoHorario = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEditarHorario = New System.Windows.Forms.Button()
        Me.btnGuardarHorario = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.tlpPrincipal.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpPrincipal
        '
        Me.tlpPrincipal.ColumnCount = 9
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.Controls.Add(Me.txtAccion, 4, 2)
        Me.tlpPrincipal.Controls.Add(Me.dgvResultado, 1, 4)
        Me.tlpPrincipal.Controls.Add(Me.cboHorarios, 2, 2)
        Me.tlpPrincipal.Controls.Add(Me.txtNombreHorario, 2, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnAgregarAccion, 5, 2)
        Me.tlpPrincipal.Controls.Add(Me.btnCopiarDiaAnterior, 1, 6)
        Me.tlpPrincipal.Controls.Add(Me.btnLimpiarDia, 2, 6)
        Me.tlpPrincipal.Controls.Add(Me.btnEliminarAccion, 6, 2)
        Me.tlpPrincipal.Controls.Add(Me.Label2, 1, 5)
        Me.tlpPrincipal.Controls.Add(Me.lblTotalHorasSemana, 2, 5)
        Me.tlpPrincipal.Controls.Add(Me.Label3, 1, 3)
        Me.tlpPrincipal.Controls.Add(Me.lblHorarioSeleccionado, 2, 3)
        Me.tlpPrincipal.Controls.Add(Me.btnNuevoHorario, 1, 1)
        Me.tlpPrincipal.Controls.Add(Me.Label1, 1, 2)
        Me.tlpPrincipal.Controls.Add(Me.btnEditarHorario, 3, 2)
        Me.tlpPrincipal.Controls.Add(Me.btnGuardarHorario, 3, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnCancelar, 5, 1)
        Me.tlpPrincipal.Controls.Add(Me.btnEliminar, 4, 1)
        Me.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tlpPrincipal.Name = "tlpPrincipal"
        Me.tlpPrincipal.RowCount = 8
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpPrincipal.Size = New System.Drawing.Size(979, 299)
        Me.tlpPrincipal.TabIndex = 0
        '
        'txtAccion
        '
        Me.txtAccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAccion.Location = New System.Drawing.Point(506, 47)
        Me.txtAccion.Name = "txtAccion"
        Me.txtAccion.Size = New System.Drawing.Size(150, 20)
        Me.txtAccion.TabIndex = 9
        '
        'dgvResultado
        '
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpPrincipal.SetColumnSpan(Me.dgvResultado, 7)
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(18, 96)
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.Size = New System.Drawing.Size(943, 136)
        Me.dgvResultado.TabIndex = 0
        '
        'cboHorarios
        '
        Me.cboHorarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboHorarios.FormattingEnabled = True
        Me.cboHorarios.Location = New System.Drawing.Point(174, 47)
        Me.cboHorarios.Name = "cboHorarios"
        Me.cboHorarios.Size = New System.Drawing.Size(200, 21)
        Me.cboHorarios.TabIndex = 4
        '
        'txtNombreHorario
        '
        Me.txtNombreHorario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNombreHorario.Location = New System.Drawing.Point(174, 18)
        Me.txtNombreHorario.Name = "txtNombreHorario"
        Me.txtNombreHorario.Size = New System.Drawing.Size(200, 20)
        Me.txtNombreHorario.TabIndex = 5
        '
        'btnAgregarAccion
        '
        Me.btnAgregarAccion.Location = New System.Drawing.Point(662, 47)
        Me.btnAgregarAccion.Name = "btnAgregarAccion"
        Me.btnAgregarAccion.Size = New System.Drawing.Size(120, 23)
        Me.btnAgregarAccion.TabIndex = 10
        Me.btnAgregarAccion.Text = "Agregar Accion"
        Me.btnAgregarAccion.UseVisualStyleBackColor = True
        '
        'btnCopiarDiaAnterior
        '
        Me.btnCopiarDiaAnterior.Location = New System.Drawing.Point(18, 258)
        Me.btnCopiarDiaAnterior.Name = "btnCopiarDiaAnterior"
        Me.btnCopiarDiaAnterior.Size = New System.Drawing.Size(150, 23)
        Me.btnCopiarDiaAnterior.TabIndex = 6
        Me.btnCopiarDiaAnterior.Text = "Copiar Dia Anterior"
        Me.btnCopiarDiaAnterior.UseVisualStyleBackColor = True
        '
        'btnLimpiarDia
        '
        Me.btnLimpiarDia.Location = New System.Drawing.Point(174, 258)
        Me.btnLimpiarDia.Name = "btnLimpiarDia"
        Me.btnLimpiarDia.Size = New System.Drawing.Size(120, 23)
        Me.btnLimpiarDia.TabIndex = 7
        Me.btnLimpiarDia.Text = "Limpiar Dia"
        Me.btnLimpiarDia.UseVisualStyleBackColor = True
        '
        'btnEliminarAccion
        '
        Me.btnEliminarAccion.Location = New System.Drawing.Point(788, 47)
        Me.btnEliminarAccion.Name = "btnEliminarAccion"
        Me.btnEliminarAccion.Size = New System.Drawing.Size(120, 23)
        Me.btnEliminarAccion.TabIndex = 11
        Me.btnEliminarAccion.Text = "Eliminar Accion"
        Me.btnEliminarAccion.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 238)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Total Horas Semana:"
        '
        'lblTotalHorasSemana
        '
        Me.lblTotalHorasSemana.AutoSize = True
        Me.lblTotalHorasSemana.Location = New System.Drawing.Point(174, 238)
        Me.lblTotalHorasSemana.Margin = New System.Windows.Forms.Padding(3)
        Me.lblTotalHorasSemana.Name = "lblTotalHorasSemana"
        Me.lblTotalHorasSemana.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalHorasSemana.TabIndex = 13
        Me.lblTotalHorasSemana.Text = "0"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 76)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Horario Seleccionado:"
        '
        'lblHorarioSeleccionado
        '
        Me.lblHorarioSeleccionado.AutoSize = True
        Me.tlpPrincipal.SetColumnSpan(Me.lblHorarioSeleccionado, 2)
        Me.lblHorarioSeleccionado.Location = New System.Drawing.Point(174, 76)
        Me.lblHorarioSeleccionado.Margin = New System.Windows.Forms.Padding(3)
        Me.lblHorarioSeleccionado.Name = "lblHorarioSeleccionado"
        Me.lblHorarioSeleccionado.Size = New System.Drawing.Size(0, 13)
        Me.lblHorarioSeleccionado.TabIndex = 15
        '
        'btnNuevoHorario
        '
        Me.btnNuevoHorario.Location = New System.Drawing.Point(18, 18)
        Me.btnNuevoHorario.Name = "btnNuevoHorario"
        Me.btnNuevoHorario.Size = New System.Drawing.Size(150, 23)
        Me.btnNuevoHorario.TabIndex = 1
        Me.btnNuevoHorario.Text = "Nuevo Horario"
        Me.btnNuevoHorario.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Seleccionar Horario:"
        '
        'btnEditarHorario
        '
        Me.btnEditarHorario.Location = New System.Drawing.Point(380, 47)
        Me.btnEditarHorario.Name = "btnEditarHorario"
        Me.btnEditarHorario.Size = New System.Drawing.Size(120, 23)
        Me.btnEditarHorario.TabIndex = 2
        Me.btnEditarHorario.Text = "Editar Horario"
        Me.btnEditarHorario.UseVisualStyleBackColor = True
        '
        'btnGuardarHorario
        '
        Me.btnGuardarHorario.Location = New System.Drawing.Point(380, 18)
        Me.btnGuardarHorario.Name = "btnGuardarHorario"
        Me.btnGuardarHorario.Size = New System.Drawing.Size(120, 23)
        Me.btnGuardarHorario.TabIndex = 3
        Me.btnGuardarHorario.Text = "Guardar Horario"
        Me.btnGuardarHorario.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(662, 18)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 23)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Location = New System.Drawing.Point(506, 18)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(150, 23)
        Me.btnEliminar.TabIndex = 17
        Me.btnEliminar.Text = "Eliminar Horario"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmRrhh_Movimientos_DefinicionHorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 299)
        Me.Controls.Add(Me.tlpPrincipal)
        Me.Name = "frmRrhh_Movimientos_DefinicionHorarios"
        Me.Text = "Rrhh/Movimientos | Definicion de Horarios"
        Me.tlpPrincipal.ResumeLayout(False)
        Me.tlpPrincipal.PerformLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpPrincipal As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents btnEditarHorario As System.Windows.Forms.Button
    Friend WithEvents cboHorarios As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardarHorario As System.Windows.Forms.Button
    Friend WithEvents txtNombreHorario As System.Windows.Forms.TextBox
    Friend WithEvents btnNuevoHorario As System.Windows.Forms.Button
    Friend WithEvents btnCopiarDiaAnterior As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarDia As System.Windows.Forms.Button
    Friend WithEvents txtAccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarAccion As System.Windows.Forms.Button
    Friend WithEvents btnEliminarAccion As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalHorasSemana As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHorarioSeleccionado As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
End Class
