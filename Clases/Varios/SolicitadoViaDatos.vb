Public Class DatosSolicitadoVia

    Private idSolicitadoVia As Integer
    Private SolicitadoVia As String
    



    Public Property gidSolicitadoVia() As Integer
        Get
            Return idSolicitadoVia
        End Get
        Set(ByVal value As Integer)
            idSolicitadoVia = value
        End Set
    End Property



    Public Property gSolicitadoVia() As String
        Get
            Return UCase(SolicitadoVia)
        End Get
        Set(ByVal value As String)
            SolicitadoVia = UCase(value)
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return UCase(SolicitadoVia)
    End Function



   

End Class
