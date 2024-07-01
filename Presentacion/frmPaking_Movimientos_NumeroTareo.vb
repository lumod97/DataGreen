Imports Logica.Utiles
Imports Logica.Funciones
Imports Entidades.Temporales
Imports Entidades
Imports Datos.Conexion

Public Class frmSupervision_Movimientos_NuevoTareoPaking

    Dim tareoActual As New Tareo
    Dim detalleTareoActual As DetalleTareo
    Dim dataSetParaControles As DataSet
    Dim dataSetParaControlesDetalle As DataSet
    Dim onLine As Boolean = True
    'Dim laborPackingActual As String
    'Dim lineaActual As String
    'Dim detalleTareoActual As New Dictionary(Of String, String)
    'Dim dataParaControles As New DataSet
    Dim tablaParaDgvResultado As New DataTable

    'AGREGADO PARA ACTIVIDADES PACKING
    Dim actividadPackingActual As New DataTable ' Char() = {"", ""}
    Dim actividadPackingActualDetalle As DataRow


    Private Sub frmSupervision_Movimientos_NumeroTareo_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        'lblDin_IdTareo.Text = detalleTareoActual.Id
        ''tlpPrincipal.Visible = False
        aplicarTema(Me)
        detalleTareoActual = New DetalleTareo(tareoActual.Id)
        tlpPrincipal.Visible = False
        inicializarDataParaDgvResultado()
        listarDetalle()

        'cargarControles()
        llenarCombo(cboTurno, dataSetParaControles.Tables(0))
        'llenarCombo(cboPuntoControl, dataSetParaControles.Tables(1))
        'llenarCombo(cboEstado, dataSetParaControles.Tables(2))

        actualizarCabeceraDeDetalle()
        tlpPrincipal.Visible = True
        dgvResultado.ClearSelection()
        dgvResultado.CurrentCell = Nothing
    End Sub
    Private Function guardarDetalle() As Boolean
        Dim p As New Dictionary(Of String, Object)
        p.Add("@Id", tareoActual.Id)
        'modificacion
        doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_EliminarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        Dim cadena As String = String.Empty
        'Dim p As New Dictionary(Of String, Object)
        p = New Dictionary(Of String, Object)
        p.Add("@CadenaParametros", String.Empty)
        Dim formato As String = "yyyy-MM-dd HH:mm:ss.fff"
        Dim i As Integer = 0
        For Each d As DetalleTareo In tareoActual.Detalle
            cadena = cadena + d.Id + ","
            cadena = cadena + d.Item.ToString + ","
            cadena = cadena + d.Dni + ","
            cadena = cadena + d.Planilla + ","
            cadena = cadena + d.Consumidor + ","
            cadena = cadena + d.Campana + ","
            'cadena = cadena + d.Cultivo + ","
            'cadena = cadena + d.Variedad + ","
            cadena = cadena + d.Actividad + ","
            cadena = cadena + d.Labor + ","
            'cadena = cadena + d.Inicio.ToString(formato) + ","
            'cadena = cadena + d.Fin.ToString(formato) + ","
            cadena = cadena + d.SubTotalHoras.ToString + ","
            cadena = cadena + d.SubTotalRendimiento.ToString + ","
            'CONCATENAR EN LA CADENA LA LINEA Y LA LABOR
            'cadena = cadena + cboLaborPacking.SelectedValue.ToString
            'cadena = cadena + cboLinea.SelectedValue.ToString
            'MessageBox.Show(cadena)
            cadena = cadena + actividadPackingActual.Rows(i).Item(0) + ","
            cadena = cadena + actividadPackingActual.Rows(i).Item(1)
            i += 1
            p("@CadenaParametros") = cadena
            Try
                If tareoActual.Estado = "D" Then
                    doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
                Else
                    'PENDIENTE EJECUATAR GUARDADO EN SQLITE
                End If
            Catch
                Return False
            End Try
            cadena = String.Empty
        Next
        Return True
        'If tareoActual.Estado = "D" Or tareoActual.Estado = "M" Then
        '    exec("sp_Dg_Supervision_Movimientos_Tareos_InsertarDetalle", p, Datos.Conexion.TipoQuery.Scalar)
        'ElseIf tareoActual.Estado = "L" Then
        '    'PENDIENTE GUARDAR EN SQLITE
        'End If
    End Function
    Private Sub actualizarCabeceraDeDetalle()
        lblDin_IdTareo.Text = detalleTareoActual.Id
        'lblDin_Estado.Text = detalleTareoActual.Estado ' "Pendiente"

        'cboCultivo.SelectedValue = detalleTareoActual.Cultivo
        'cboEstado.SelectedValue = detalleTareoActual.Estado
        cboTurno.SelectedValue = detalleTareoActual.Turno
        cboPuntoControl.SelectedValue = detalleTareoActual.PuntoControl

    End Sub
    Private Sub inicializarDataParaDgvResultado()
        If tablaParaDgvResultado.Columns.Count = 0 Then
            tablaParaDgvResultado.Columns.Add("PuntoControl")
            tablaParaDgvResultado.Columns.Add("DNI")
            tablaParaDgvResultado.Columns.Add("Nombre")
            ' tablaParaDgvResultado.Columns.Add("Estado")
            'AGREGADO PARA ACTIVIDADES PACKING
            tablaParaDgvResultado.Columns.Add("H_Inicio", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("F_Fin", Type.GetType("System.DateTime"))

            tablaParaDgvResultado.Columns.Add("H_Refrigerio", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("H_Padadas", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("H_Netas", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("Observacion")
            tablaParaDgvResultado.Columns.Add("H_Ingreso", Type.GetType("System.DateTime"))
            tablaParaDgvResultado.Columns.Add("H_Salida", Type.GetType("System.DateTime"))

        End If
    End Sub



    Private Sub dgvResultado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultado.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            tareoActual.Id = dgvResultado.Rows(e.RowIndex).Cells("IdTareo").Value
            'tareoActual.PuntoControl = dgvResultado.Rows(e.RowIndex).Cells("PuntoControl").Value
            tareoActual.NroTareo = dgvResultado.Rows(e.RowIndex).Cells("NroTareo").Value
            tareoActual.Estado = dgvResultado.Rows(e.RowIndex).Cells("Estado").Value
            tareoActual.DniResponsable = dgvResultado.Rows(e.RowIndex).Cells("T_DniResponsable").Value
            tareoActual.IdResponsable = dgvResultado.Rows(e.RowIndex).Cells("T_IdResponsable").Value
            tareoActual.Turno = dgvResultado.Rows(e.RowIndex).Cells("Turno").Value
            tareoActual.Fecha = dgvResultado.Rows(e.RowIndex).Cells("F_Dia").Value
            tareoActual.Periodo = dgvResultado.Rows(e.RowIndex).Cells("Periodo").Value
            tareoActual.Semana = dgvResultado.Rows(e.RowIndex).Cells("Semana").Value
            'ACTUALIZAR CONTROLES
            '  actualizarControles(tareoActual)

        End If
    End Sub

    Private Function obtenerDetalleDesdeFila(fila As DataRow) As DetalleTareo
        Dim aux As New DetalleTareo
        'Dim f As Integer = dgvResultado.CurrentRow.Index
        aux.Id = tareoActual.Id
        aux.Item = fila.Item(1) 'dgvResultado.Rows(f).Cells(1).Value
        'aux.Estado = "M"
        aux.Dni = fila.Item(6) 'dgvResultado.Rows(f).Cells(4).Value
        aux.Trabajador = fila.Item(7) 'dgvResultado.Rows(f).Cells(5).Value
        aux.Planilla = fila.Item(8) 'dgvResultado.Rows(f).Cells(6).Value
        aux.Consumidor = fila.Item(9) 'dgvResultado.Rows(f).Cells(7).Value
        aux.Campana = fila.Item(10) 'dgvResultado.Rows(f).Cells(8).Value
        'aux.Cultivo = fila.Item(11) 'dgvResultado.Rows(f).Cells(9).Value
        'aux.Variedad = fila.Item(12) 'dgvResultado.Rows(f).Cells(10).Value
        aux.Actividad = fila.Item(13) 'dgvResultado.Rows(f).Cells(11).Value
        aux.Labor = fila.Item(14) 'dgvResultado.Rows(f).Cells(12).Value
        'aux.Inicio = fila.Item(15) 'dgvResultado.Rows(f).Cells(13).Value
        'aux.Fin = fila.Item(16) 'dgvResultado.Rows(f).Cells(14).Value
        aux.SubTotalHoras = fila.Item(17) 'dgvResultado.Rows(f).Cells(15).Value
        aux.SubTotalRendimiento = fila.Item(18) 'dgvResultado.Rows(f).Cells(16).Value
        Return aux
    End Function

    Private Sub obtenerDataParaControles()
        Dim aux As DataSet = New DataSet
        If onLine Then
            aux = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_CargarData", Nothing, TipoQuery.DataSet)
            'aux = execSp_Dg_Supervision_Movimientos_Tareos_CargarData()
            dataSetParaControles = New DataSet
            dataSetParaControles.Tables.Add(aux.Tables(0).Copy)
            dataSetParaControles.Tables.Add(aux.Tables(1).Copy)
            dataSetParaControles.Tables.Add(aux.Tables(2).Copy)
            dataSetParaControlesDetalle = New DataSet
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(3).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(4).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(5).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(6).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(7).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(8).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(9).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(10).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(11).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(12).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(13).Copy)
            dataSetParaControlesDetalle.Tables.Add(aux.Tables(14).Copy)
            'dataSetParaControles.Tables.Add(aux.Tables(3).Copy) 'DATA PARA DGVRESULTADO
        Else
            'PENDIENTEcargarDatasetdesdesqlite
        End If
        'obtener data sqlite
    End Sub


    Private Sub cargarControles()
        'LLENAR TODOS LOS CONTROLES
        cargarCombo(cboTurno, dataSetParaControles.Tables(0))
        cargarCombo(cboCultivo, dataSetParaControles.Tables(4))

        cargarCombo(cboPuntoControl, dataSetParaControles.Tables(2))
        cargarCombo(cboEstado, dataSetParaControles.Tables(3))
        'textboxTrabajadores
        Dim listaTrabajadores As New AutoCompleteStringCollection
        For Each fila As DataRow In dataSetParaControles.Tables(8).Rows
            listaTrabajadores.Add(fila.Item(2).ToString)
        Next

    End Sub

    Private Sub llenarCombo(ByRef comboBox As ComboBox, dataTable As DataTable, Optional condicion As String = "")
        comboBox.DataSource = Nothing
        Dim i As Integer = 0
        If dataTable.Columns.Count = 3 Then
            comboBox.DataSource = dataTable
            comboBox.ValueMember = "Clave"
            If dataTable.Rows.Count < 10 Then
                comboBox.DisplayMember = "Valor"
            Else
                comboBox.DisplayMember = "Concatenado"
            End If
        Else
            For Each fila As DataRow In dataTable.Rows
                If fila.Item(0).ToString = condicion Then
                    Dim dt As DataTable = dataTable
                    Dim dataView As DataView = dt.DefaultView
                    dataView.RowFilter = "Condicion = '" & condicion & "'"
                    comboBox.DataSource = dataView
                    comboBox.ValueMember = "Clave"
                    If dataView.Count < 10 Then
                        comboBox.DisplayMember = "Valor"
                    Else
                        comboBox.DisplayMember = "Concatenado"
                    End If
                End If
                i = i + 1
            Next
        End If
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub listarDetalle()
        'Dim dicObjetos As Dictionary(Of String, Object)

        'Dim resultado As DataSet = New DataSet
        'dataSetGeneral = execSP("sp_Dg_Supervision_Movimientos_Tareos_Detalle_CargarData", Nothing)
        ''dataSetGeneral.Tables.Add(resultado.Tables(0).Copy)
        'obtenerDataParaControles()
        dgvResultado.DataSource = Nothing
        If tareoActual.Estado = "D" Then
            'OBTENER DATOS DEL DETALLE
            Dim p = New Dictionary(Of String, Object)
            p.Add("@IdTareo", tareoActual.Id)
            Dim aux As DataTable
            aux = doItBaby("sp_Dg_Packing_Movimientos_TareosPacking_ListarDetalle", p, Datos.Conexion.TipoQuery.DataTable)
            If aux IsNot Nothing Then
                tablaParaDgvResultado = aux.Copy
            End If
        ElseIf tareoActual.Estado = "L" Then
            'PENDIENTE DESDE SQLITE
        End If


        'obtener data sqlite
        'Dim auxSqlite As DataSet = New DataSet
        'auxSqlite = execSqlitePorNombre("selectSqliteTareos", Nothing, 3)
        'dataSetInicial.Tables(3).Merge(auxSqlite.Tables(0), True, MissingSchemaAction.Ignore)

        dgvResultado.DataSource = tablaParaDgvResultado
        formatearDataGridView(dgvResultado)
        dgvResultado.Columns(0).Visible = False
        dgvResultado.Columns(2).Visible = False

        corregirCeldas(dgvResultado)
        dgvResultado.AutoResizeColumns()
        dgvResultado.AutoResizeRows()
    End Sub

    Private Sub dgvResultado_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        'MessageBox.Show("Error happened " & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            'MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context =
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub


End Class