Public Class ImprimirEscandallos

    Private Validar As Boolean

    Public Property pPaginado() As Boolean
        Get
            Return ckPaginado.Checked
        End Get
        Set(ByVal value As Boolean)
            ckPaginado.CheckState = value
        End Set
    End Property

    Public Property pCostes() As Boolean
        Get
            Return ckCoste.Checked
        End Get
        Set(ByVal value As Boolean)
            ckCoste.Checked = value
        End Set
    End Property

    Public Property pTiempos() As Boolean
        Get
            Return ckTiempos.Checked
        End Get
        Set(ByVal value As Boolean)
            ckTiempos.Checked = value
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
    

    Private Sub bProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Validar = True
        Me.Close()
    End Sub

End Class