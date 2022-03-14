Public Class DatosMail

    Private idProveedor As Integer
    Private idUbicacion As Integer
    Private idContacto As Integer
    Private idCliente As Integer
    Private idTipoCompra As Integer
    Private mail As String
    Private Orden As Integer


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

    Public Property gidTipoCompra() As Integer
        Get
            Return idTipoCompra
        End Get
        Set(ByVal value As Integer)
            idTipoCompra = value
        End Set
    End Property

    Public Property gmail()
        Get
            Return LCase(mail)
        End Get
        Set(ByVal value)
            mail = LCase(value)
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

    Public Sub New(ByVal idProveedor As Integer, ByVal idCliente As Integer, ByVal idUbicacion As Integer, ByVal idContacto As Integer, ByVal idTipoCompra As Integer, ByVal Mail As String, ByVal Orden As Integer)
        gidProveedor = idProveedor
        gidCliente = idCliente
        gidUbicacion = idUbicacion
        gidContacto = idContacto
        gidTipoCompra = idTipoCompra
        gmail = Mail
        gOrden = Orden

    End Sub

    Public Sub New()

    End Sub

End Class
