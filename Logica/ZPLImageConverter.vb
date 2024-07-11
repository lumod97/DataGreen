''Imports System.Drawing
'Imports System.Drawing.Printing
''Imports System.Windows.Forms

'Public Class Form1
'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        Dim p As PrintDocument = New PrintDocument
'        Try
'            AddHandler p.PrintPage, AddressOf Me.PrintImage
'            p.Print()
'        Catch ex As Exception
'            MsgBox(ex, MsgBoxStyle.Critical, "Error during Print")
'        Finally
'            RemoveHandler p.PrintPage, AddressOf Me.PrintImage
'        End Try
'    End Sub

'    Private Sub PrintImage(ByVal sender As Object, ByVal ppea As PrintPageEventArgs)
'        ppea.Graphics.DrawImage(Image.FromFile("D:\HolaMundo.png"), ppea.Graphics.VisibleClipBounds)
'        ppea.HasMorePages = False
'    End Sub
'End Class