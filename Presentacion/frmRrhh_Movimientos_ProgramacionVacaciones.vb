Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmRrhh_Movimientos_ProgramacionVacaciones

    Dim dtTablaExcel As New DataTable

    Dim arrayDeParametros As String = String.Empty

    Private Sub frmRrhh_Movimientos_ProgramacionVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tlpPrincipal.Visible = False
        Me.WindowState = FormWindowState.Maximized
        Me.btnProcesar.Enabled = False
        Me.btnImportar.Enabled = True
        aplicarTema(Me)
        tlpPrincipal.Visible = True
    End Sub

    Private Sub btnFormato_Click(sender As Object, e As EventArgs) Handles btnFormato.Click
        Dim ventana As New frmGenericos_ObtenerFormatoImportacion(Me.Name)
        ventana.Show()
    End Sub

    Private Sub btnPuntos_Click(sender As Object, e As EventArgs) Handles btnPuntos.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            txtRutaExcel.Text = dialog.FileName
        End Using
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            dgvResultado.Columns.Clear()
            dtTablaExcel = cargarExcel(txtRutaExcel.Text) 'PENDIENTE CAMBIAR LA FUNCION CARGAREXCEL POR UN PROCESO EN MOTOR SQL
            corregirTabla(dtTablaExcel)
            dtTablaExcel.Columns.Add("Estado")
            barProgreso.Value = 0
            barProgreso.Maximum = dtTablaExcel.Rows.Count
            barProgreso.Style = ProgressBarStyle.Continuous

            'Preparar para llenado


            For Each fila As DataRow In dtTablaExcel.Rows()

                fila("Estado") = "Pendiente de Procesar"

                barProgreso.Value += 1
                barProgreso.Refresh()

            Next

            dgvResultado.AutoGenerateColumns = True

            dgvResultado.DataSource = dtTablaExcel
            dgvResultado.Show()
            Me.btnProcesar.Enabled = True

            lblDin_Resultado.Text = "Registros: " + dtTablaExcel.Rows.Count().ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            formatearDataGridView(dgvResultado)

        End Try
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Try

            Dim contOK As Integer = 0
            Dim contErr As Integer = 0
            'AGREGADO
            barProgreso.Value = 0
            barProgreso.Maximum = dgvResultado.RowCount
            barProgreso.Style = ProgressBarStyle.Continuous
            'FIN AGREGADO


            If dtTablaExcel.Rows.Count() > 0 Then

                If guardarDetalle() Then
                    'listarDetalle()
                    'desbloquearControl(btnEditar)
                    'bloquearControl(btnGuardar)
                    'bloquearControl(btnPuntitos)
                    'bloquearControl(txtRutaExcel)
                    'bloquearControl(btnImportar)
                    'bloquearControl(btnEliminar)
                    'bloquearControl(btnAgregar)
                    lblDin_Resultado.Text = "Registros: " + dtTablaExcel.Rows.Count().ToString

                End If

                dgvResultado.DataSource = dtTablaExcel

                For Each fila As DataGridViewRow In dgvResultado.Rows
                    If fila.Cells("Estado").Value.ToString <> ("Registro actualizado exitosamente.") Then
                        fila.Cells("Estado").Style.BackColor = rojoAmarath
                        contErr = contErr + 1
                    Else
                        contOK = contOK + 1
                    End If
                Next

                MessageBox.Show("Detalle guardado correctamente. Correctos: " + contOK.ToString() + ". Incorrectos: " + contErr.ToString())


            Else
                MessageBox.Show("No se puede guardar un archivo vacio")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function guardarDetalle() As Boolean
        Dim result As DataTable

        'recorrer la lista y actualizar registros
        For Each fila As DataRow In dtTablaExcel.Rows()
            Dim p As New Dictionary(Of String, Object)
            p.Add("@CodigoGeneral", fila(0))
            p.Add("@FechaInicio", fila(3))
            p.Add("@FechaFin", fila(3))
            p.Add("@CantidadDias", fila(5))
            Try


                result = doItBaby("sp_Dg_Rrhh_Movimientos_ProgramacionVacaciones", p, Datos.Conexion.TipoQuery.DataTable)
                fila(6) = result.Rows(0)(2).ToString()


                CheckForIllegalCrossThreadCalls = False
                barProgreso.Value += 1
                barProgreso.Refresh()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try
        Next

        Return True

    End Function

    Private Async Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            If dgvResultado.RowCount < 1 Then
                MessageBox.Show("Error, no hay registros para exportar")
            Else
                encenderControlesDeEspera(barProgreso, lblDin_Resultado, "Exportando...")
                Dim l As String
                l = "Reporte"
                Await Task.Run(Sub() aExcel(dtTablaExcel, l, Me.Text, Nothing))
                apagarControlesDeEspera(barProgreso, lblDin_Resultado, -1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class