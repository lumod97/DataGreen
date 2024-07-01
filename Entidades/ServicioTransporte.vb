Imports System.Windows.Forms
Imports Entidades.Temporales

Public Class ServicioTransporte
    Public Id_ As String
    Public IdPedidoServicio_ As String
    Public NroFactura_ As String
    Public Fecha_ As Date
    Public IdRuta_ As String
    Public Ruta_ As String
    Public Pasajeros_ As Integer
    Public Tarifa_ As Double
    Public TarifaIndividual_ As Double
    Public Dscto_ As Double
    Public DsctoIndividual_ As Double
    Public SubTotal_ As Double
    Public Redondeo_ As Double
    Public Total_ As Double
    Public RucProveedor_ As String
    Public RazonSocial_ As String
    Public Placa_ As String
    Public Marca_ As String
    Public Modelo_ As String
    Public Color_ As String
    Public DniConductor_ As String
    Public Conductor_ As String
    Public Obs_ As String
    Public IdEstado_ As String
    Public Estado_ As String
    Public UsuarioCrea_ As String
    Public Creacion_ As Date
    Public UsuarioActualiza_ As String
    Public Actualizacion_ As Date

    Public HoraPartida_ As DateTime
    Public HoraRetorno_ As DateTime
    'Public Detalle_ As List(Of DetalleTareo) ' DetalleTareo

    Public Property Id() As String
        Get
            Return Id_
        End Get
        Set(ByVal value As String)
            Id_ = value
        End Set
    End Property

    Public Property IdPedidoServicio() As String
        Get
            Return IdPedidoServicio_
        End Get
        Set(value As String)
            IdPedidoServicio_ = value
        End Set
    End Property

    Public Property NroFactura() As String
        Get
            Return NroFactura_
        End Get
        Set(value As String)
            NroFactura_ = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return Fecha_
        End Get
        Set(value As Date)
            Fecha_ = value
        End Set
    End Property

    Public Property IdRuta() As String
        Get
            Return IdRuta_
        End Get
        Set(value As String)
            IdRuta_ = value
        End Set
    End Property

    Public Property Ruta() As String
        Get
            Return Ruta_
        End Get
        Set(value As String)
            Ruta_ = value
        End Set
    End Property

    Public Property Pasajeros() As Integer
        Get
            Return Pasajeros_
        End Get
        Set(value As Integer)
            Pasajeros_ = value
        End Set
    End Property

    Public Property Tarifa() As Double
        Get
            Return Tarifa_
        End Get
        Set(value As Double)
            Tarifa_ = value
        End Set
    End Property

    Public Property TarifaIndividual() As Double
        Get
            Return TarifaIndividual_
        End Get
        Set(value As Double)
            TarifaIndividual_ = value
        End Set
    End Property

    Public Property Dscto() As Double
        Get
            Return Dscto_
        End Get
        Set(value As Double)
            Dscto_ = value
        End Set
    End Property

    Public Property DsctoIndividual() As Double
        Get
            Return DsctoIndividual_
        End Get
        Set(value As Double)
            DsctoIndividual_ = value
        End Set
    End Property

    Public Property SubTotal() As Double
        Get
            Return SubTotal_
        End Get
        Set(value As Double)
            SubTotal_ = value
        End Set
    End Property


    Public Property Redondeo() As Double
        Get
            Return Redondeo_
        End Get
        Set(value As Double)
            Redondeo_ = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return Total_
        End Get
        Set(value As Double)
            Total_ = value
        End Set
    End Property

    Public Property RucProveedor() As String
        Get
            Return RucProveedor_
        End Get
        Set(value As String)
            RucProveedor_ = value
        End Set
    End Property

    Public Property RazonSocial() As String
        Get
            Return RazonSocial_
        End Get
        Set(value As String)
            RazonSocial_ = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return Placa_
        End Get
        Set(value As String)
            Placa_ = value
        End Set
    End Property

    Public Property Marca() As String
        Get
            Return Marca_
        End Get
        Set(value As String)
            Marca_ = value
        End Set
    End Property

    Public Property Modelo() As String
        Get
            Return Modelo_
        End Get
        Set(value As String)
            Modelo_ = value
        End Set
    End Property

    Public Property Color() As String
        Get
            Return Color_
        End Get
        Set(value As String)
            Color_ = value
        End Set
    End Property

    Public Property DniConductor() As String
        Get
            Return DniConductor_
        End Get
        Set(value As String)
            DniConductor_ = value
        End Set
    End Property

    Public Property Conductor() As String
        Get
            Return Conductor_
        End Get
        Set(value As String)
            Conductor_ = value
        End Set
    End Property

    Public Property Obs() As String
        Get
            Return Obs_
        End Get
        Set(value As String)
            Obs_ = value
        End Set
    End Property

    Public Property IdEstado() As String
        Get
            Return IdEstado_
        End Get
        Set(value As String)
            IdEstado_ = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return Estado_
        End Get
        Set(value As String)
            Estado_ = value
        End Set
    End Property

    Public Property UsuarioCrea() As String
        Get
            Return UsuarioCrea_
        End Get
        Set(value As String)
            UsuarioCrea_ = value
        End Set
    End Property

    Public Property Creacion() As Date
        Get
            Return Creacion_
        End Get
        Set(value As Date)
            Creacion_ = value
        End Set
    End Property

    Public Property UsuarioActualiza() As String
        Get
            Return UsuarioActualiza_
        End Get
        Set(value As String)
            UsuarioActualiza_ = value
        End Set
    End Property

    Public Property Actualizacion() As Date
        Get
            Return Actualizacion_
        End Get
        Set(value As Date)
            Actualizacion_ = value
        End Set
    End Property

    Public Property HoraPartida() As DateTime
        Get
            Return HoraPartida_
        End Get
        Set(value As DateTime)
            HoraPartida_ = value
        End Set
    End Property

    Public Property HoraRetorno() As DateTime
        Get
            Return HoraRetorno_
        End Get
        Set(value As DateTime)
            HoraRetorno_ = value
        End Set
    End Property

    'Public Property Detalle(index As Integer) As DetalleTareo
    '    Get
    '        Return Detalle_(index)
    '    End Get
    '    Set(value As DetalleTareo)
    '        Detalle_(index) = value
    '    End Set
    'End Property

    Public Property Valor() As DataGridViewRow
        Get
            Return New DataGridViewRow
        End Get
        Set(value As DataGridViewRow)
            'If value.Cells.Count = 25 Then
            'Id_ = value.Cells(0).Value.ToString
            'IdOrdenServicio_ = value.Cells(1).Value.ToString
            'NroFactura_ = value.Cells(2).Value.ToString
            'Fecha_ = value.Cells(3).Value.ToString
            'IdRuta_ = value.Cells(4).Value.ToString
            'Ruta_ = value.Cells(5).Value.ToString
            'Pasajeros_ = value.Cells(6).Value.ToString
            'Tarifa_ = value.Cells(7).Value.ToString
            'Dscto_ = value.Cells(8).Value.ToString
            'SubTot = value.Cells("D2SubTot").Value
            'Redondeo = value.Cells("D2Redondeo").Value
            'Total_ = value.Cells(9).Value.ToString
            'RucProveedor_ = value.Cells(10).Value.ToString
            'RazonSocial_ = value.Cells(11).Value.ToString
            'Placa_ = value.Cells(12).Value.ToString
            'Marca_ = value.Cells(13).Value.ToString
            'Modelo_ = value.Cells(14).Value.ToString
            'Color_ = value.Cells(15).Value.ToString
            'DniConductor_ = value.Cells(16).Value.ToString
            'Conductor_ = value.Cells(17).Value.ToString
            'Obs_ = value.Cells(18).Value.ToString
            'IdEstado_ = value.Cells(19).Value.ToString
            'Estado_ = value.Cells(20).Value.ToString
            'UsuarioCrea_ = value.Cells(21).Value.ToString
            'Creacion_ = value.Cells(22).Value.ToString
            'UsuarioActualiza_ = value.Cells(23).Value.ToString
            'Actualizacion_ = value.Cells(24).Value.ToString
            'End If
            Id = value.Cells("T_Id").Value 'Id_ = value.Cells(0).Value.ToString
            IdPedidoServicio = IIf(TypeOf (value.Cells("T_IdPedidoServicio").Value) Is DBNull, "", value.Cells("T_IdPedidoServicio").Value) 'IdOrdenServicio_ = value.Cells(1).Value.ToString
            NroFactura = IIf(TypeOf (value.Cells("T_NroFactura").Value) Is DBNull, "", value.Cells("T_NroFactura").Value) 'NroFactura_ = value.Cells(2).Value.ToString
            Fecha = value.Cells("F_Fecha").Value 'Fecha_ = value.Cells(3).Value.ToString
            IdRuta = value.Cells("T_IdRuta").Value 'IdRuta_ = value.Cells(4).Value.ToString
            Ruta = value.Cells("T_Ruta").Value 'Ruta_ = value.Cells(5).Value.ToString
            Pasajeros = value.Cells("Pasajeros").Value 'Pasajeros_ = value.Cells(6).Value.ToString
            Tarifa = value.Cells("D2Tarifa").Value 'Tarifa_ = value.Cells(7).Value.ToString
            Dscto = value.Cells("D2Dscto").Value 'Dscto_ = value.Cells(8).Value.ToString
            SubTotal = value.Cells("D2SubTotal").Value 'SubTot = value.Cells("D2SubTot").Value
            Redondeo = value.Cells("D2Redondeo").Value
            Total = value.Cells("D2Total").Value 'Total_ = value.Cells(9).Value.ToString
            RucProveedor = value.Cells("T_RucProveedor").Value 'RucProveedor_ = value.Cells(10).Value.ToString
            RazonSocial = value.Cells("T_RazonSocial").Value 'RazonSocial_ = value.Cells(11).Value.ToString
            Placa = value.Cells("T_Placa").Value 'Placa_ = value.Cells(12).Value.ToString
            Marca = value.Cells("T_Marca").Value 'Marca_ = value.Cells(13).Value.ToString
            Modelo = value.Cells("T_Modelo").Value 'Modelo_ = value.Cells(14).Value.ToString
            Color = value.Cells("T_Color").Value 'Color_ = value.Cells(15).Value.ToString
            DniConductor = value.Cells("T_DniConductor").Value 'DniConductor_ = value.Cells(16).Value.ToString
            Conductor = value.Cells("T_Conductor").Value 'Conductor_ = value.Cells(17).Value.ToString
            Obs = value.Cells("T_Observacion").Value 'Obs_ = value.Cells(18).Value.ToString
            IdEstado = value.Cells("T_IdEstado").Value 'IdEstado_ = value.Cells(19).Value.ToString
            Estado = value.Cells("T_Estado").Value 'Estado_ = value.Cells(20).Value.ToString
            UsuarioCrea = value.Cells("T_UsuarioCrea").Value 'UsuarioCrea_ = value.Cells(21).Value.ToString
            Creacion = value.Cells("H1Creacion").Value 'Creacion_ = value.Cells(22).Value.ToString
            UsuarioActualiza = value.Cells("T_UsuarioActualiza").Value 'UsuarioActualiza_ = value.Cells(23).Value.ToString
            Actualizacion = value.Cells("H1Actualizacion").Value 'Actualizacion_ = value.Cells(24).Value.ToString
            HoraPartida = value.Cells("H1HoraPartida").Value
            HoraRetorno = value.Cells("H1HoraRetorno").Value
        End Set
    End Property

    Public Sub New()
        Me.Id = ""
        Me.Estado = "PENDIENTE"
        Me.IdEstado = "PE"
        Me.UsuarioCrea = usuarioActual
        Me.Fecha = Now
        Me.RucProveedor = ""
        Me.DniConductor = ""
        Me.RazonSocial = ""
        Me.Conductor = ""
        Me.Placa = 0
        Me.Pasajeros = 0
        Me.IdPedidoServicio = ""
        Me.NroFactura = ""
        Me.IdRuta = ""
        Me.Ruta = ""
        Me.Tarifa = 0
        Me.TarifaIndividual = 0
        Me.Dscto = 0
        Me.DsctoIndividual = 0
        Me.SubTotal = 0
        Me.Redondeo = 0
        Me.Total = 0
        Me.Marca = ""
        Me.Modelo = ""
        Me.Color = ""
        Me.Obs = ""
        Me.Creacion = Now
        Me.UsuarioActualiza = ""
        Me.Actualizacion = Now
    End Sub

    'Function Contar() As Integer
    '    Try
    '        Return Detalle_.Count
    '    Catch
    '        Return 0
    '    End Try
    'End Function

    Public Sub SumarizarPersonas(ByRef personas As DataTable, ByRef consumidores As DataTable)
        Me.Pasajeros = 0
        Dim aux As New DataTable
        Dim encontrado As Boolean
        aux.Columns.Add("T_IdConsumidor", Type.GetType("System.String"))
        aux.Columns.Add("Pasajeros", Type.GetType("System.Int32"))
        For i As Integer = 0 To personas.Rows.Count - 1 Step 1
            encontrado = False
            For j As Integer = 0 To aux.Rows.Count - 1 Step 1
                If aux.Rows(j).Item("T_IdConsumidor") = personas.Rows(i).Item("T_IdConsumidor") Then
                    aux.Rows(j).Item("Pasajeros") = aux.Rows(j).Item("Pasajeros") + 1
                    encontrado = True
                End If
            Next
            If Not encontrado Then
                Dim f As DataRow = aux.NewRow
                f.Item("T_IdConsumidor") = personas.Rows(i).Item("T_IdConsumidor")
                f.Item("Pasajeros") = 1
                aux.Rows.Add(f)
            End If
        Next

        consumidores.Rows.Clear()
        For i As Integer = 0 To aux.Rows.Count - 1 Step 1
            encontrado = False
            'For j As Integer = 0 To consumidores.Rows.Count - 1 Step 1
            '    If consumidores.Rows(j).Item("T_IdConsumidor") = aux.Rows(i).Item("T_IdConsumidor") Then
            '        consumidores.Rows(j).Item("Pasajeros") = aux.Rows(i).Item("Pasajeros")
            '        encontrado = True
            '    End If
            'Next
            'If Not encontrado Then
            '    Dim f As DataRow = consumidores.NewRow
            '    f.Item("T_IdConsumidor") = aux.Rows(i).Item("T_IdConsumidor")
            '    f.Item("Pasajeros") = 1
            '    consumidores.Rows.Add(f)
            'End If

            Dim f As DataRow = consumidores.NewRow
            f.Item("T_IdConsumidor") = aux.Rows(i).Item("T_IdConsumidor")
            f.Item("Pasajeros") = aux.Rows(i).Item("Pasajeros")
            consumidores.Rows.Add(f)
            
        Next
    End Sub

    Public Sub SumarizarConsumidores(ByRef dt As DataTable)
        'D2TarifaInd	D2SubTotSinDscto	D2DsctoInd	D2SubTotDscto	D2SubTotal

        Me.Pasajeros = IIf(dt.Rows.Count > 0, dt.Compute("SUM(Pasajeros)", String.Empty), 0)

        Me.TarifaIndividual = Math.Round(Me.Tarifa / Me.Pasajeros, 2)
        Me.DsctoIndividual = Math.Round(Me.Dscto / Me.Pasajeros, 2)

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1 'Each fila As DataRow In dt.Rows
            dt.Rows(i).Item("D2TarifaInd") = Me.TarifaIndividual
            dt.Rows(i).Item("D2SubTotSinDscto") = dt.Rows(i).Item("Pasajeros") * Me.TarifaIndividual
            dt.Rows(i).Item("D2DsctoInd") = Me.DsctoIndividual
            dt.Rows(i).Item("D2SubTotDscto") = dt.Rows(i).Item("Pasajeros") * Me.DsctoIndividual
            dt.Rows(i).Item("D2SubTotal") = dt.Rows(i).Item("D2SubTotSinDscto") - dt.Rows(i).Item("D2SubTotDscto")
        Next
        Me.SubTotal = IIf(dt.Rows.Count > 0, dt.Compute("SUM(D2SubTotal)", String.Empty), 0) '(Me.TarifaIndividual * Me.Pasajeros) - (Me.DsctoIndividual * Me.Pasajeros)
        Me.Redondeo = Me.Tarifa - Me.Dscto - Me.SubTotal
        Me.Total = Me.SubTotal + Me.Redondeo
    End Sub


End Class
