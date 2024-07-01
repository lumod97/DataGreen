Public Class PedidoServicioTransportes
    Private Id_ As String
    Private Fecha_ As Date
    Private IdDocumento_ As String
    Private Serie_ As String
    Private Numero_ As String
    Private IdEstado_ As String
    Private Estado_ As String
    Private Ruc_ As String
    Private RazonSocial_ As String
    Private Responsable_ As String
    Private IdSucursal_ As String
    Private Sucursal_ As String
    Private IdAlmacen_ As String
    Private Almacen_ As String
    Private IdArea_ As String
    Private Area_ As String
    Private IdMoneda_ As String
    Private Moneda_ As String
    Private Total_ As Double
    Private Nota_ As String
    Private Servicios_ As List(Of String)
    Private NroFactura_ As String

    Public Property Id() As String
        Get
            Return Id_
        End Get
        Set(ByVal value As String)
            Id_ = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return Fecha_
        End Get
        Set(ByVal value As Date)
            Fecha_ = value
        End Set
    End Property

    Public Property IdDocumento() As String
        Get
            Return IdDocumento_
        End Get
        Set(ByVal value As String)
            IdDocumento_ = value
        End Set
    End Property

    Public Property Serie() As String
        Get
            Return Serie_
        End Get
        Set(ByVal value As String)
            Serie_ = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return Numero_
        End Get
        Set(ByVal value As String)
            Numero_ = value
        End Set
    End Property

    Public Property IdEstado() As String
        Get
            Return IdEstado_
        End Get
        Set(ByVal value As String)
            IdEstado_ = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return Estado_
        End Get
        Set(ByVal value As String)
            Estado_ = value
        End Set
    End Property

    Public Property Ruc() As String
        Get
            Return Ruc_
        End Get
        Set(ByVal value As String)
            Ruc_ = value
        End Set
    End Property

    Public Property RazonSocial() As String
        Get
            Return RazonSocial_
        End Get
        Set(ByVal value As String)
            RazonSocial_ = value
        End Set
    End Property

    Public Property Responsable() As String
        Get
            Return Responsable_
        End Get
        Set(ByVal value As String)
            Responsable_ = value
        End Set
    End Property

    Public Property IdSucursal() As String
        Get
            Return IdSucursal_
        End Get
        Set(ByVal value As String)
            IdSucursal_ = value
        End Set
    End Property

    Public Property Sucursal() As String
        Get
            Return Sucursal_
        End Get
        Set(ByVal value As String)
            Sucursal_ = value
        End Set
    End Property

    Public Property IdAlmacen() As String
        Get
            Return IdAlmacen_
        End Get
        Set(ByVal value As String)
            IdAlmacen_ = value
        End Set
    End Property

    Public Property Almacen() As String
        Get
            Return Almacen_
        End Get
        Set(ByVal value As String)
            Almacen_ = value
        End Set
    End Property

    Public Property IdArea() As String
        Get
            Return IdArea_
        End Get
        Set(ByVal value As String)
            IdArea_ = value
        End Set
    End Property

    Public Property Area() As String
        Get
            Return Area_
        End Get
        Set(ByVal value As String)
            Area_ = value
        End Set
    End Property

    Public Property IdMoneda() As String
        Get
            Return IdMoneda_
        End Get
        Set(ByVal value As String)
            IdMoneda_ = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return Moneda_
        End Get
        Set(ByVal value As String)
            Moneda_ = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return Total_
        End Get
        Set(ByVal value As Double)
            Total_ = value
        End Set
    End Property

    Public Property Nota() As String
        Get
            Return Nota_
        End Get
        Set(ByVal value As String)
            Nota_ = value
        End Set
    End Property

    Public Property Servicios() As List(Of String)
        Get
            Return Servicios_
        End Get
        Set(ByVal value As List(Of String))
            Servicios_ = value
        End Set
    End Property

    Public Property NroFactura() As String
        Get
            Return NroFactura_
        End Get
        Set(ByVal value As String)
            NroFactura_ = value
        End Set
    End Property

    'Public Property Id() As String
    '    Get
    '        Return Id_
    '    End Get
    '    Set(ByVal value As String)
    '        Id_ = value
    '    End Set
    'End Property
    Public Sub New()
        Me.Id = ""
        Me.IdDocumento = ""
        Me.Serie = ""
        Me.Numero = ""
        Me.IdEstado = ""
        Me.Estado = ""
        Me.Fecha = Now
        Me.Ruc = ""
        Me.RazonSocial = ""
        Me.Responsable = ""
        Me.IdSucursal = ""
        Me.Sucursal = ""
        Me.IdAlmacen = ""
        Me.Almacen = ""
        Me.IdArea = ""
        Me.Area = ""
        Me.IdMoneda = ""
        Me.Moneda = ""
        Me.Total = 0
        Me.Nota = ""
        Me.Servicios = New List(Of String)
        Me.NroFactura = ""
    End Sub

End Class
