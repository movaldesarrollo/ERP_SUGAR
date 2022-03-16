Public Class textListadoPedidosAX
    Private Sub bCopiar_Click(sender As Object, e As EventArgs) Handles bCopiar.Click

        Clipboard.SetText(txListado.Text)

    End Sub

End Class