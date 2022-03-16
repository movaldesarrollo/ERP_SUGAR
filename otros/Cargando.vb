Public Class Cargando

    Dim funcGI As gestionInventarios
    Public fin As Boolean
    Public tipo As String

    Private Sub Cargando_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()

        Label1.Text = tipo & Label1.Text

        Timer1.Interval = 1000

        Timer1.Start()

        Application.DoEvents()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If fin = True Then

            Me.Close()

        End If

    End Sub

End Class