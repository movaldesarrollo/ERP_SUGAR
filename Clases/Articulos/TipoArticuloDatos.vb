Public Class DatosTipoArticulo

    Private idTipoArticulo As Integer
    Private TipoArticulo As String
    Private Descripcion As String
    Private Activo As Boolean
    Private Validacion As Boolean
    Private Descuento1 As Boolean
    Private Descuento2 As Boolean

    Public Property gidTipoArticulo()
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gTipoArticulo()
        Get
            Return UCase(TipoArticulo)
        End Get
        Set(ByVal value)
            TipoArticulo = UCase(value)
        End Set
    End Property

    Public Property gDescripcion()
        Get
            Return Descripcion
        End Get
        Set(ByVal value)
            Descripcion = value
        End Set
    End Property

    Public Property gActivo()
        Get
            Return Activo
        End Get
        Set(ByVal value)
            Activo = value
        End Set
    End Property

    Public Property gValidacion()
        Get
            Return Validacion
        End Get
        Set(ByVal value)
            Validacion = value
        End Set
    End Property

    Public Property gDescuento1() As Boolean
        Get
            Return Descuento1
        End Get
        Set(ByVal value As Boolean)
            Descuento1 = value
        End Set
    End Property

    Public Property gDescuento2() As Boolean
        Get
            Return Descuento2
        End Get
        Set(ByVal value As Boolean)
            Descuento2 = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return TipoArticulo
    End Function

End Class
