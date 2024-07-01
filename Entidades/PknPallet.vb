Public Class PknPallet
    Private IdPallet_ As String
    Private Annio_ As String
    Private IdCultivoVariedadPacking_ As String
    Private IdEmpaquePacking_ As String
    Private Correlativo_ As String
    Private IdLinea_ As Char
    Private Usuario_ As String
    Private NroCajas_ As Integer
    Private NroCajasMax_ As Integer
    Private Cajas_ As List(Of PknCaja)
    Private CajaActual_ As PknCaja

    Public Property CajaActual() As PknCaja
        Get
            Return CajaActual_
        End Get
        Set(ByVal value As PknCaja)
            CajaActual_ = value
        End Set
    End Property


    Public Property Cajas() As List(Of PknCaja)
        Get
            Return Cajas_
        End Get
        Set(ByVal value As List(Of PknCaja))
            Cajas_ = value
        End Set
    End Property

    Public Property NroCajasMax() As String
        Get
            Return NroCajasMax_
        End Get
        Set(ByVal value As String)
            NroCajasMax_ = value
        End Set
    End Property

    Public Property NroCajas() As String
        Get
            Return NroCajas_
        End Get
        Set(ByVal value As String)
            NroCajas_ = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return Usuario_
        End Get
        Set(ByVal value As String)
            Usuario_ = value
        End Set
    End Property


    Public Property IdLinea() As Char
        Get
            Return IdLinea_
        End Get
        Set(ByVal value As Char)
            IdLinea_ = value
        End Set
    End Property


    Public Property Correlativo() As String
        Get
            Return Correlativo_
        End Get
        Set(ByVal value As String)
            Correlativo_ = value
        End Set
    End Property

    Public Property IdEmpaquePacking() As String
        Get
            Return IdEmpaquePacking_
        End Get
        Set(ByVal value As String)
            IdEmpaquePacking_ = value
        End Set
    End Property

    Public Property IdCultivoVariedadPacking() As String
        Get
            Return IdCultivoVariedadPacking_
        End Get
        Set(ByVal value As String)
            IdCultivoVariedadPacking_ = value
        End Set
    End Property

    Public Property Annio() As String
        Get
            Return Annio_
        End Get
        Set(ByVal value As String)
            Annio_ = value
        End Set
    End Property

    Public Property IdPallet() As String
        Get
            Return IdPallet_
        End Get
        Set(ByVal value As String)
            IdPallet_ = value
        End Set
    End Property

    Public Sub New(Annio As String, IdCultivoVariedadPacking As String, IdEmpaquePacking As String, Correlativo As String, IdLinea As Char, Usuario As String)
        Me.IdPallet_ = String.Concat(Annio, IdCultivoVariedadPacking, IdEmpaquePacking, Correlativo)
        Me.Annio_ = Annio
        Me.IdCultivoVariedadPacking_ = IdCultivoVariedadPacking
        Me.IdEmpaquePacking_ = IdEmpaquePacking
        Me.Correlativo_ = Correlativo
        Me.IdLinea_ = IdLinea
        Me.Usuario_ = Usuario
        Me.Cajas_ = New List(Of PknCaja)
    End Sub

    Public Sub cambiarPallet(fila As DataRow)

    End Sub

End Class
