Public Class DatosTipoValorado

    Private idTipoValorado As Integer

    Private TipoValorado As String



    Public Property gidTipoValorado() As Integer
        Get
            Return idTipoValorado
        End Get
        Set(ByVal value As Integer)
            idTipoValorado = value
        End Set
    End Property

    Public Property gTipoValorado() As String
        Get
            Return TipoValorado
        End Get
        Set(ByVal value As String)
            TipoValorado = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return TipoValorado
    End Function


End Class
