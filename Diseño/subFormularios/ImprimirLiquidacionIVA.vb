Public Class ImprimirLiquidacionIVA

    Private Validar As Boolean

    Public Property pSoportado() As Boolean
        Get
            Return ckSoportado.Checked
        End Get
        Set(ByVal value As Boolean)
            ckSoportado.CheckState = value
        End Set
    End Property

    Public Property pRepercutido() As Boolean
        Get
            Return ckRepercutido.Checked
        End Get
        Set(ByVal value As Boolean)
            ckRepercutido.Checked = value
        End Set
    End Property

    Public Property pLiquidacion() As Boolean
        Get
            Return ckLiquidacion.Checked
        End Get
        Set(ByVal value As Boolean)
            ckLiquidacion.Checked = value
        End Set
    End Property

    Public Property pValidar() As Boolean
        Get
            Return Validar
        End Get
        Set(ByVal value As Boolean)
            Validar = value
        End Set
    End Property

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Validar = False
        Me.Close()
    End Sub


    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Validar = True
        Me.Close()
    End Sub

End Class