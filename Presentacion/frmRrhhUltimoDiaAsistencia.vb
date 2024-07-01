Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhhUltimoDiaAsistencia
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable

    Private Sub frmUltimoDiaAsistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        aplicarTema(Me)
    End Sub

    Private Sub radTodos_CheckedChanged(sender As Object, e As EventArgs) Handles radTodos.CheckedChanged
        If radTodos.Checked Then
            txtCodigo.Text = ""
            txtCodigo.Enabled = False
            cbxEma.Checked = False
            cbxEmp.Checked = False
            cbxFma.Checked = False
            cbxObm.Checked = False
            cbxPas.Checked = False
            cbxPra.Checked = False
            cbxEma.Enabled = False
            cbxEmp.Enabled = False
            cbxFma.Enabled = False
            cbxObm.Enabled = False
            cbxPas.Enabled = False
            cbxPra.Enabled = False
        End If
    End Sub


    Private Sub lblTodos_Click(sender As Object, e As EventArgs) Handles lblTodos.Click
        radTodos.Checked = True
    End Sub

    Private Sub radCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles radCodigo.CheckedChanged
        If radCodigo.Checked Then
            txtCodigo.Text = ""
            txtCodigo.Enabled = True
            txtCodigo.Focus()
            cbxEma.Checked = False
            cbxEmp.Checked = False
            cbxFma.Checked = False
            cbxObm.Checked = False
            cbxPas.Checked = False
            cbxPra.Checked = False
            cbxEma.Enabled = False
            cbxEmp.Enabled = False
            cbxFma.Enabled = False
            cbxObm.Enabled = False
            cbxPas.Enabled = False
            cbxPra.Enabled = False
        End If
    End Sub

    Private Sub lblCodigo_Click(sender As Object, e As EventArgs) Handles lblCodigo.Click
        radCodigo.Checked = True
    End Sub

    Private Sub radPlanilla_CheckedChanged(sender As Object, e As EventArgs) Handles radPlanilla.CheckedChanged
        If radPlanilla.Checked Then
            txtCodigo.Text = ""
            txtCodigo.Enabled = False
            cbxEma.Checked = False
            cbxEmp.Checked = False
            cbxFma.Checked = False
            cbxObm.Checked = False
            cbxPas.Checked = False
            cbxPra.Checked = False
            cbxEma.Enabled = True
            cbxEmp.Enabled = True
            cbxFma.Enabled = True
            cbxObm.Enabled = True
            cbxPas.Enabled = True
            cbxPra.Enabled = True
            cbxEma.Focus()
        End If
    End Sub

    Private Sub lblPlanilla_Click(sender As Object, e As EventArgs) Handles lblPlanilla.Click
        radPlanilla.Checked = True
    End Sub

    Private Async Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        dgvResultado.DataSource = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblResultado)
        dgv = consultarAsync()
        dgvResultado.DataSource = Await dgv
        apagarControlesDeEspera(barProgreso, lblResultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function consultarAsync() As Task(Of DataTable)
        'dgvResultado.DataSource = Nothing
        Dim p As New Dictionary(Of String, Object)
        Dim r As New DataTable
        If radTodos.Checked Then
            'Personas_G = "TODOS"
            p.Add("@CodDni", "")
            p.Add("@Planillas", "")
            'dgvResultado2 = Await Task.Run(Function() execUltimoDiaAsistencia("", ""))
        ElseIf radCodigo.Checked Then
            If txtCodigo.Text.Length < 5 Or txtCodigo.Text.Length > 8 Then
                MessageBox.Show("Debe escribir un codigo o dni validos")
            Else
                'Personas_G = txtCodigo.Text
                p.Add("@CodDni", txtCodigo.Text)
                p.Add("@Planillas", "")
                'dgvResultado2 = Await Task.Run(Function() execUltimoDiaAsistencia(txtCodigo.Text, ""))
            End If
        ElseIf radPlanilla.Checked Then
            Dim planillas As String = ""
            planillas = planillas + If(cbxEma.Checked, "EMA", "")
            planillas = planillas + If(cbxEmp.Checked, If(planillas.Length > 0, ",EMP", "EMP"), "")
            planillas = planillas + If(cbxFma.Checked, If(planillas.Length > 0, ",FMA", "FMA"), "")
            planillas = planillas + If(cbxObm.Checked, If(planillas.Length > 0, ",OBM", "OBM"), "")
            planillas = planillas + If(cbxPas.Checked, If(planillas.Length > 0, ",PAS", "PAS"), "")
            planillas = planillas + If(cbxPra.Checked, If(planillas.Length > 0, ",PRA", "PRA"), "")
            If String.IsNullOrEmpty(planillas) Then
                MessageBox.Show("Debe seleccionar al menos una planilla")
            Else
                'Personas_G = planillas
                p.Add("@CodDni", "")
                p.Add("@Planillas", planillas)
                'dgvResultado2 = Await Task.Run(Function() execUltimoDiaAsistencia("", planillas))
            End If
        End If
        r = Await Task.Run(Function() doItBaby("spUltimoDiaAsistencia", p, TipoQuery.DataTable))
        tablaResultado = r
        Return r
    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'If dgvResultado.RowCount < 1 Then
        '     MessageBox.Show("Error, no hay registros para exportar")
        ' Else
        '     'exportarExcel(dgvResultado, Me.Text, arrayDeParametros)
        '     Dim dDgvs As New Dictionary(Of String, DataGridView)
        '     dDgvs.Add("Reporte", dgvResultado)
        '     excelling(dDgvs, Me.Text, arrayDeParametros)
        ' End If
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblResultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(tablaResultado, l, Me.Text, arrayDeParametros))
                apagarControlesDeEspera(barProgreso, lblResultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class