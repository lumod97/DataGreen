Public Class Registro
    Inherits Dictionary(Of String, Object)

    Public Sub New(c As String())
        For Each i As String In c
            If Not Me.ContainsKey(i) Then
                Me.Add(i, "")
            End If
        Next
    End Sub

    Public Sub addix(c As String) 'addix-> pseudonombre para la funcion que agrega y/o actualiza una clave o valor
        If Not Me.ContainsKey(c) Then
            Me.Add(c, "")
        End If
        'Me.Add(c, "")
    End Sub

    Public Sub addix(c As String, v As String)
        If Not Me.ContainsKey(c) Then
            Me.Add(c, v)
        Else
            Me.Item(c) = v
        End If
    End Sub

    Public Sub addix(c As String())
        For Each i As String In c
            If Not Me.ContainsKey(i) Then
                Me.Add(i, "")
            End If
        Next
    End Sub

    Public Sub addix(c As String(), v As String())
        If c.Count = v.Count Then
            For Each i As String In c
                If Not Me.ContainsKey(i) Then
                    Me.Add(i, v)
                Else
                    Me.Item(i) = v
                End If
            Next
        Else
            Throw New Exception("Los arrays ingresados son de diferentes dimensiones.")
        End If
    End Sub

    Public Function obtener(s As String)
        If Me.ContainsKey(s) Then
            Return Me.Item(s)
        Else
            Return ""
        End If
    End Function

End Class
