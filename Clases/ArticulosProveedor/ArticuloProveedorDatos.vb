Public Class DatosArticuloProveedor

    Private idArticuloProv As Integer
    Private idArticulo As Integer
    Private idProveedor As Integer
    Private Nombre As String
    Private Precio As Double
    Private codMoneda As String
    Private FechaPrecio As Date
    Private Activo As Boolean
    Private codArticuloProv As String
    Private simbolo As String
    Private Articulo As String
    Private codArticulo As String
    Private Proveedor As String
    Private Familia As String
    Private SubFamilia As String
    Private PrecioUnitario As Double
    Private TipoUnidad As String
    Private UltimoPedido As Integer
    Private idSeccion As Integer
    Private Seccion As String
    Private CantidadPedida As Integer
    Private CantidadRecibida As Integer


    Public Property gPrecioUnitario()
        Get
            Return PrecioUnitario
        End Get
        Set(ByVal value)
            PrecioUnitario = value
        End Set
    End Property


    Public Property gFamilia()
        Get
            Return UCase(Familia)
        End Get
        Set(ByVal value)
            Familia = UCase(value)
        End Set
    End Property


    Public Property gSubFamilia()
        Get
            Return UCase(SubFamilia)
        End Get
        Set(ByVal value)
            SubFamilia = UCase(value)
        End Set
    End Property

  


    Public Property gProveedor()
        Get
            Return UCase(Proveedor)
        End Get
        Set(ByVal value)
            Proveedor = UCase(value)
        End Set
    End Property

    Public Property gcodArticuloProv()
        Get
            Return UCase(codArticuloProv)
        End Get
        Set(ByVal value)
            codArticuloProv = UCase(value)
        End Set
    End Property

    Public Property gidArticuloProv()
        Get
            Return idArticuloProv
        End Get
        Set(ByVal value)
            idArticuloProv = value
        End Set
    End Property


    Public Property gSimbolo()
        Get
            Return simbolo
        End Get
        Set(ByVal value)
            simbolo = value
        End Set
    End Property

    Public Property gidArticulo()
        Get
            Return idArticulo
        End Get
        Set(ByVal value)
            idArticulo = value
        End Set
    End Property

    Public Property gcodArticulo()
        Get
            Return UCase(codArticulo)
        End Get
        Set(ByVal value)
            codArticulo = UCase(value)
        End Set
    End Property

    Public Property gArticulo()
        Get
            Return UCase(Articulo)
        End Get
        Set(ByVal value)
            Articulo = UCase(value)
        End Set
    End Property

    Public Property gFechaPrecio()
        Get
            Return FechaPrecio
        End Get
        Set(ByVal value)
            FechaPrecio = value
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

   

    Public Property gNombre()
        Get
            Return UCase(Nombre)
        End Get
        Set(ByVal value)
            Nombre = UCase(value)
        End Set
    End Property

    

    Public Property gPrecio()
        Get
            Return Precio
        End Get
        Set(ByVal value)
            Precio = value
        End Set
    End Property

    Public Property gcodMoneda()
        Get
            Return codMoneda
        End Get
        Set(ByVal value)
            codMoneda = value
        End Set
    End Property

    Public Property gidProveedor()
        Get
            Return idProveedor
        End Get
        Set(ByVal value)
            idProveedor = value
        End Set
    End Property

    Public Property gTipoUnidad() As String
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value As String)
            TipoUnidad = value
        End Set
    End Property

    Public Property gUltimoPedido() As Integer
        Get
            Return UltimoPedido
        End Get
        Set(ByVal value As Integer)
            UltimoPedido = value
        End Set
    End Property

    Public Property gidSeccion() As Integer
        Get
            Return idSeccion
        End Get
        Set(ByVal value As Integer)
            idSeccion = value
        End Set
    End Property

    Public Property gSeccion() As String
        Get
            Return Seccion
        End Get
        Set(ByVal value As String)
            Seccion = value
        End Set
    End Property

    Public Property gCantidadPedida() As Integer
        Get
            Return CantidadPedida
        End Get
        Set(ByVal value As Integer)
            CantidadPedida = value
        End Set
    End Property

    Public Property gCantidadRecibida() As Integer
        Get
            Return CantidadRecibida
        End Get
        Set(ByVal value As Integer)
            CantidadRecibida = value
        End Set
    End Property


End Class
