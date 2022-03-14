Public Class SeleccionImprimirP

    Private Interno As Boolean = False
    Private Cliente As Boolean = False

    Public Property pInterno() As Boolean
        Get
            Return Interno
        End Get
        Set(ByVal value As Boolean)
            Interno = value
        End Set
    End Property

    Public Property pCliente() As Boolean
        Get
            Return Cliente
        End Get
        Set(ByVal value As Boolean)
            Cliente = value
        End Set
    End Property

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Interno = False
        Cliente = False
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub bInterno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bInterno.Click
        Interno = True
        Cliente = False
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCliente.Click
        Cliente = True
        Interno = False
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


End Class