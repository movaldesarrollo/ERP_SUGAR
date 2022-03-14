Public Class CambiarFechaPrevista

    Public numpedido As String
    Public sinCambio As Boolean
    Public fechaInicial As String

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click
        If fechaInicial <> dtpFecha.Value Then
            If MsgBox("Se va a actualizar la fecha del pedido " & numpedido & " a la fecha " & dtpFecha.Value & ", ¿está seguro que quiere realizar esta operación?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                sinCambio = True
                Close()
            End If
        End If
    End Sub

    Private Sub CambiarFechaPrevista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Text = "CAMBIAR FECHA DEL PEDIDO " & numpedido
    End Sub
End Class