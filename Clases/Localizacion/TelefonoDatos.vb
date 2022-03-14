Public Class DatosTelefono

    Private idProveedor As Integer
    Private idUbicacion As Integer
    Private idContacto As Integer
    Private idCliente As Integer
    Private idTipoTelefono As Integer
    Private Telefono As String
    Private Orden As Integer
    Private TipoTelefono As String

    Public Property gTipoTelefono()
        Get
            Return TipoTelefono
        End Get
        Set(ByVal value)
            TipoTelefono = value
        End Set
    End Property

    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
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

    Public Property gidContacto() As Integer
        Get
            Return idContacto
        End Get
        Set(ByVal value As Integer)
            idContacto = value
        End Set
    End Property

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property

    Public Property gidTipoTelefono() As Integer
        Get
            Return idTipoTelefono
        End Get
        Set(ByVal value As Integer)
            idTipoTelefono = value
        End Set
    End Property

    Public Property gTelefono()
        Get
            Return Telefono
        End Get
        Set(ByVal value)
            Telefono = value
        End Set
    End Property

    Public Property gOrden() As Integer
        Get
            Return Orden
        End Get
        Set(ByVal value As Integer)
            Orden = value
        End Set
    End Property

    Public Sub New(ByVal idProveedor As Integer, ByVal idCliente As Integer, ByVal idUbicacion As Integer, ByVal idContacto As Integer, ByVal idTipoTelefono As Integer, ByVal Telefono As String, ByVal Orden As Integer)
        gidProveedor = idProveedor
        gidUbicacion = idUbicacion
        gidContacto = idContacto
        gidCliente = idCliente
        gidTipoTelefono = idTipoTelefono
        gTelefono = Telefono
        gOrden = Orden

    End Sub

    Public Sub New()

    End Sub

End Class
