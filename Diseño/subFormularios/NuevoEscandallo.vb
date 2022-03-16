Public Class NuevoEscandallo

    Private Nuevo As Boolean = False
    Private Copiar As Boolean = False

    Public Property pNuevo() As Boolean
        Get
            Return Nuevo
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property pCopiar() As Boolean
        Get
            Return Copiar
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property


    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub
    Private Sub bCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCopiar.Click
        Copiar = True
        Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Nuevo = True
        Me.Close()
    End Sub

End Class