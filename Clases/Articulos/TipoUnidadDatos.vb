Public Class DatosTipoUnidad


    Dim idTipoUnidad As Integer
    Dim TipoUnidad As String
  




    Public Property gidTipoUnidad()
        Get
            Return idTipoUnidad
        End Get
        Set(ByVal value)
            idTipoUnidad = value
        End Set
    End Property

    Public Property gTipoUnidad()
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value)
            TipoUnidad = value
        End Set
    End Property






    Public Sub New(ByVal idTipoUnidad As Integer, ByVal TipoUnidad As Integer)

        gidTipoUnidad = idTipoUnidad
        gTipoUnidad = TipoUnidad


    End Sub

    Public Sub New()

    End Sub

End Class
