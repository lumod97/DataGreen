Public Class DetalleTareo
    Public Id As String
    Public Item As Integer
    'Private IdTransferencia As String
    Public Estado As Char
    Public Dni As String
    Public Trabajador As String
    Public Planilla As String
    Public Consumidor As String
    Public Campana As String
    Public Cultivo As String
    Public Variedad As String
    Public IdActividad As String
    Public Actividad As String
    Public IdLabor As String
    Public Labor As String
    Public Turno As String
    Public PuntoControl As String
    Public Inicio As DateTime
    Public Fin As DateTime
    'Private Creacion As DateTime
    'Private Modificacion As DateTime
    Public SubTotalHoras As Double
    Public SubTotalRendimiento As Double
    Public Observacion As String

    'MODIFICACION 2024-05-11 HATCH
    Public Ingreso As String
    Public Salida As String

    Public IdCultivo As String
    Public IdVariedad As String


    Public Sub New()

    End Sub

    Public Sub New(id As String)
        Me.Id = id
        Me.Item = 0
    End Sub


End Class
