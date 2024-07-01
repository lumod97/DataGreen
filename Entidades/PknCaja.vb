Public Class PknCaja
    Private IdPallet_ As String
    Private NroCaja_ As String
    Private Items_ As Integer
    Private CodSel_ As PknCodigo
    Private CodPes_ As PknCodigo
    Private CodEmp_ As PknCodigo
    Private IdLinea_ As Char
    Private Usuario_ As String

    Public Property IdPallet() As String
        Get
            Return IdPallet_
        End Get
        Set(ByVal value As String)
            IdPallet_ = value
        End Set
    End Property

    Public Property NroCaja() As String
        Get
            Return NroCaja_
        End Get
        Set(ByVal value As String)
            NroCaja_ = value
        End Set
    End Property

    Public Property Items() As Integer
        Get
            Return Items_
        End Get
        Set(ByVal value As Integer)
            Items_ = value
        End Set
    End Property

    Public Property CodSel() As PknCodigo
        Get
            Return CodSel_
        End Get
        Set(ByVal value As PknCodigo)
            CodSel_ = value
        End Set
    End Property

    Public Property CodPes() As PknCodigo
        Get
            Return CodPes_
        End Get
        Set(ByVal value As PknCodigo)
            CodPes_ = value
        End Set
    End Property

    Public Property CodEmp() As PknCodigo
        Get
            Return CodEmp_
        End Get
        Set(ByVal value As PknCodigo)
            CodEmp_ = value
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

    Public Property Usuario() As String
        Get
            Return Usuario_
        End Get
        Set(ByVal value As String)
            Usuario_ = value
        End Set
    End Property

    'Public Sub New(IdPallet As String, NroCaja As String, CodSel As PknCodigo, CodPes As PknCodigo, CodEmp As PknCodigo, IdLinea As Char, Usuario As String)
    '    Me.IdPallet_ = IdPallet
    '    Me.NroCaja_ = NroCaja
    '    Me.Items_ = 0
    '    Me.CodSel_ = CodSel
    '    Me.CodPes_ = CodPes
    '    Me.CodEmp_ = CodEmp
    '    Me.IdLinea_ = IdLinea
    '    Me.Usuario_ = Usuario
    'End Sub
End Class
