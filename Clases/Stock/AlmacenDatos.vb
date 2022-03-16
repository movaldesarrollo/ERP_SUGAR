Public Class DatosAlmacen
    Private idAlmacen As Integer
    Private Almacen As String
    Private idUbicacion As Integer
    Private Descripcion As String
    Private FechaAlta As Date
    Private FechaBaja As Date
    Private Activo As Boolean
    Private idTipoAlmacen As Integer


    'Datos de otras tablas
    Private Ubicacion As String
    Private TipoAlmacen As String


    Public Property gidAlmacen() As Integer
        Get
            Return idAlmacen
        End Get
        Set(ByVal value As Integer)
            idAlmacen = value
        End Set
    End Property

    Public Property gAlmacen() As String
        Get
            Return UCase(Almacen)
        End Get
        Set(ByVal value As String)
            Almacen = UCase(value)
        End Set
    End Property

    Public Property gidUbicacion() As Integer
        Get
            Return idUbicacion
        End Get
        Set(ByVal value As Integer)
            idUbicacion = value
        End Set
    End Property

    Public Property gDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property



    Public Property gFechaAlta() As Date
        Get
            Return FechaAlta
        End Get
        Set(ByVal value As Date)
            FechaAlta = value
        End Set
    End Property

    Public Property gFechaBaja() As Date
        Get
            Return FechaBaja
        End Get
        Set(ByVal value As Date)
            FechaBaja = value
        End Set
    End Property


    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

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

    Public Property gUbicacion() As String
        Get
            Return Ubicacion
        End Get
        Set(ByVal value As String)
            Ubicacion = value
        End Set
    End Property


End Class
