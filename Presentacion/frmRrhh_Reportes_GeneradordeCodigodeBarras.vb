Imports Logica.Funciones
Imports Logica.Utiles
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Reportes_GeneradordeCodigodeBarras

    Dim dtTablaExcel As New DataTable
    Dim arrayDeParametros As String = String.Empty
    Dim tablaResultado As DataTable
    Dim dtPersonasSeleccionadas As DataTable

    Private Sub frmRrhh_Reportes_GeneradordeCodigodeBarras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        'dtpDesde.Value = Date.Now.AddDays(-Now.Day + 1)
        'dtpHasta.Value = Date.Now.AddDays(-Now.Day + 1).AddMonths(1).AddDays(-1)
        aplicarTema(Me)
        tlpPrincipal.Visible = True

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtDni.Text = "" Then
            MessageBox.Show("Ingresar Nro.DNI")
            txtDni.Focus()
            Return
        End If






    End Sub

    Private Sub txtDni_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDni.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnAgregar.Focus()
        End If

    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        dtTablaExcel = cargarExcel(txtRutaExcel.Text)
        'AGREGADO
        barProgreso.Value = 0
        barProgreso.Maximum = dtTablaExcel.Rows.Count
        ''arProgreso.Style = ProgressBarStyle.Continuous
        'FIN AGREGADO
        'dgvResultado.Columns.Clear()
        'dgvResultado.Rows.Clear()
        dgvResultado.DataSource = dtTablaExcel
        'cargarTablaValidada()
        formatearDataGridView(dgvResultado)
        'dgvResultado.Rows(2).Cells(0).Style.BackColor = rojoAmarath  dgvResultado


    End Sub
End Class