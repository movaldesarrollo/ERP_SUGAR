Public Class DatosTipoUbicaciones

    Dim idTipoUbicacion As Integer
    Dim TipoUbicacion As String
    Dim Descripcion As String
    Dim Fiscal As Boolean
    Dim Cliente As Boolean
    Dim Proveedor As Boolean
    Dim Postal As Boolean
    Dim Recogida As Boolean
    Dim Entrega As Boolean
    Dim Interna As Boolean


    Public Property gRecogida()
        Get
            Return Recogida
        End Get
        Set(ByVal value)
            Recogida = value
        End Set
    End Property

    Public Property gEntrega()
        Get
            Return Entrega
        End Get
        Set(ByVal value)
            Entrega = value
        End Set
    End Property

    Public Property gCliente()
        Get
            Return Cliente
        End Get
        Set(ByVal value)
            Cliente = value
        End Set
    End Property

    Public Property gPostal()
        Get
            Return Postal
        End Get
        Set(ByVal value)
            Postal = value
        End Set
    End Property

    Public Property gProveedor()
        Get
            Return Proveedor
        End Get
        Set(ByVal value)
            Proveedor = value
        End Set
    End Property

    Public Property gFiscal()
        Get
            Return Fiscal
        End Get
        Set(ByVal value)
            Fiscal = value
        End Set
    End Property

    Public Property gidTipoUbicacion()
        Get
            Return idTipoUbicacion
        End Get
        Set(ByVal value)
            idTipoUbicacion = value
        End Set
    End Property

    Public Property gTipoUbicacion()
        Get
            Return UCase(TipoUbicacion)
        End Get
        Set(ByVal value)
            TipoUbicacion = UCase(value)
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

    Public Property gInterna() As Boolean
        Get
            Return Interna
        End Get
        Set(ByVal value As Boolean)
            Interna = value
        End Set
    End Property


    Public Sub New(ByVal idTipoUbicacion As Integer, ByVal TipoUbicacion As Integer, ByVal Descripcion As String)
        gidTipoUbicacion = idTipoUbicacion
        gTipoUbicacion = TipoUbicacion
        gDescripcion = Descripcion

    End Sub

    Public Sub New()

    End Sub

End Class
