Public Class PknCodigo
    Private Codigo_ As String
    Private IdLabor_ As Char
    Private IdLinea_ As Char
    Private IdLineaOri_ As Char
    Private FechaHoraLectura_ As String
    Private Usuario_ As String

    Public Property Codigo() As String
        Get
            Return Codigo_
        End Get
        Set(ByVal Value As String)
            Codigo_ = Value
        End Set
    End Property

    Public Property IdLabor() As String
        Get
            Return IdLabor_
        End Get
        Set(ByVal Value As String)
            IdLabor_ = Value
        End Set
    End Property

    Public Property IdLinea() As String
        Get
            Return IdLinea_
        End Get
        Set(ByVal Value As String)
            IdLinea_ = Value
        End Set
    End Property

    Public Property IdLineaOri() As String
        Get
            Return IdLineaOri_
        End Get
        Set(ByVal Value As String)
            IdLineaOri_ = Value
        End Set
    End Property

    Public Property FechaHoraLectura() As String
        Get
            Return FechaHoraLectura_
        End Get
        Set(ByVal Value As String)
            FechaHoraLectura_ = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return Usuario_
        End Get
        Set(ByVal Value As String)
            Usuario_ = Value
        End Set
    End Property

    Public Sub New(Codigo As String, IdLabor As String, IdLinea As Char, IdLineaOri As Char, FechaHoraLectura As String, Usuario As String)
        Me.Codigo_ = Codigo
        Me.IdLabor_ = IdLabor
        Me.IdLinea = IdLinea
        Me.IdLineaOri_ = IdLineaOri
        Me.FechaHoraLectura_ = FechaHoraLectura
        Me.Usuario_ = Usuario
    End Sub

End Class
