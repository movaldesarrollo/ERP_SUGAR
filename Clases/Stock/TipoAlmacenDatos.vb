Public Class DatosTipoAlmacen
   
    Private idTipoAlmacen As Integer

    Private TipoAlmacen As String


   
    Public Property gidTipoAlmacen() As Integer
        Get
            Return idTipoAlmacen
        End Get
        Set(ByVal value As Integer)
            idTipoAlmacen = value
        End Set
    End Property

    Public Property gTipoAlmacen() As String
        Get
            Return TipoAlmacen
        End Get
        Set(ByVal value As String)
            TipoAlmacen = value
        End Set
    End Property

   


End Class
