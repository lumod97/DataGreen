
Public Class Tareo
    Public Id As String
    Public Anio As String
    Public NroTareo As String
    Public Estado As String
    Public DniResponsable As String
    Public IdResponsable As String
    Public Turno As String
    Public Periodo As String
    Public Semana As String
    Public Fecha As Date
    Public FechaCreacion As DateTime
    Public FechaTransfNisira As DateTime
    Public TotalHoras As Double
    Public TotalRendimientos As Double
    Public TotalDetalles As Integer
    Public IdCultivo As String
    Public IdEstado As String
    Public Detalle As List(Of DetalleTareo) ' DetalleTareo

    Public Sub New()
        TotalDetalles = 0
        TotalHoras = 0
        TotalRendimientos = 0
        'Detalle(0) = New DetalleTareo(Id)
        Detalle = New List(Of DetalleTareo)
    End Sub

    Function ContarTareos() As Integer
        Try
            Return Detalle.Count
        Catch
            Return 0
        End Try
    End Function

    Sub AgregarDetalle(detalleTareoActual As DetalleTareo)
        Detalle.Add(detalleTareoActual)
        'Detalle(TotalDetalles) = New DetalleTareo(Id)
        'Detalle(TotalDetalles) = detalleTareoActual
        TotalDetalles += 1
    End Sub

    'Sub GuardarDetalle()

    'End Sub

    

End Class
