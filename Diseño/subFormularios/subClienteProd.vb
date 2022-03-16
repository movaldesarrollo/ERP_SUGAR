Public Class subClienteProd




    Public Property pObservaciones() As String
        Get
            Return Observaciones.Text
        End Get
        Set(ByVal value As String)
            Observaciones.Text = value
        End Set
    End Property

    Public Property pCliente() As String
        Get
            Return Cliente.Text
        End Get
        Set(ByVal value As String)
            Cliente.Text = value
        End Set
    End Property

    Private Sub subClienteProd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class