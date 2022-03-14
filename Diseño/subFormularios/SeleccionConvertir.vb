Public Class SeleccionConvertir

    Private Pedido As Boolean = False
    Private Proforma As Boolean = False

    Public Property pPedido() As Boolean
        Get
            Return Pedido
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property pProforma() As Boolean
        Get
            Return Proforma
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property pTitulo() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub
    Private Sub bPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPedido.Click
        Pedido = True
        Me.Close()
    End Sub

    Private Sub bProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bProforma.Click
        Proforma = True
        Me.Close()
    End Sub

End Class