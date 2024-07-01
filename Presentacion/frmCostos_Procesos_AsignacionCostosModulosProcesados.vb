Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Datos.Conexion

Public Class frmCostos_Procesos_AsignacionCostosModulosProcesados
    Dim tablaResultado As DataTable
    Dim dataSetParaControles As DataSet
    ' Dim ok As Boolean

    'PENDIENTE CREAR UNA TABLA DE RESULTADO PARA TODAS LAS DEMAS CONSULTAS, ESTA TABLA PERMITE USAR LA FUNCION
    '"CORREGITABLA", LA CUAL ELIMINA LOS SALTOS DE LINEA INNECESARIOS EN LOS REGISTROS QUE HACEN LOS USUARIOS Y QUE ALTERAN
    'LAS FILAS EN LA EXPORTACION A EXCEL

    Private Sub frmCostos_Procesos_AsignacionCostosModulosProcesados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        obtenerDataParaControles()
        cargarCombo(cboCultivo, dataSetParaControles.Tables(0))
        'btnActualizar_Click(sender, e)
        aplicarTema(Me)
    End Sub

    Private Sub obtenerDataParaControles()
        Dim aux As DataSet = New DataSet
        aux = doItBaby("sp_Dg_Packing_Movimientos_LecturaEficiencias_ObtenerDataParaControles", Nothing, TipoQuery.DataSet)
        'aux = execSp_Dg_Supervision_Movimientos_Tareos_CargarData()
        dataSetParaControles = New DataSet
        dataSetParaControles.Tables.Add(aux.Tables(1).Copy)
    End Sub
    Private Async Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        dgvResultado.DataSource = Nothing
        tablaResultado = Nothing
        dgvResultado.Columns.Clear()
        Dim dgv As Task(Of DataTable)
        encenderControlesDeEspera(barProgreso, lblDin_Resultado)
        dgv = actualizarAsync()
        'dgvResultado.DataSource = Await dgv
        tablaResultado = Await dgv
        corregirTabla(tablaResultado)
        dgvResultado.DataSource = tablaResultado
        apagarControlesDeEspera(barProgreso, lblDin_Resultado, dgvResultado.RowCount)
        corregirCeldas(dgvResultado)
        formatearDataGridView(dgvResultado)
    End Sub

    Private Async Function actualizarAsync() As Task(Of DataTable)
        Try
            Dim p As New Dictionary(Of String, Object)
            p.Add("@Fecha", pkrDia.Value.ToString("yyyy-MM-dd"))
            Dim aux As New DataTable
            aux = Await Task.Run(Function() doItBaby("Dg_Costos_Validacion_Productos", p, TipoQuery.DataTable))

            'Dim nota As String = String.Empty
            If aux.Rows.Count > 0 AndAlso aux.Compute("MAX(Nota)", "Código<>''") = "Revisar" Then
                btnActualizarCentrosCosto.Enabled = False
            Else
                btnActualizarCentrosCosto.Enabled = True
            End If
            Return aux
            'If nota = "Revisar" Then
            '    ok = False
            'Else
            '    ok = True
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvResultado.DataError
        'MessageBox.Show("Error happened " & e.Context.ToString())
        If (e.Context = DataGridViewDataErrorContexts.Commit) Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub

    
    Private Sub btnActualizarCentrosCosto_Click(sender As Object, e As EventArgs) Handles btnActualizarCentrosCosto.Click
        Try
            If cboCultivo.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar un cultivo")
            Else
                Dim p As New Dictionary(Of String, Object)
                p.Add("@Fecha_T", pkrDia.Value.ToString("dd/MM/yyyy"))
                p.Add("@CodCultivo", cboCultivo.SelectedValue)
                If doItBaby("Dg_Costos_Proceso_Actualizar_CCP", p, TipoQuery.NonQuery) Then
                    MessageBox.Show("Actualizacion exitosa, validar mediante revision en Nisira.")
                Else
                    MessageBox.Show("Hubo un error inesperado, consulte al area de sistemas.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class