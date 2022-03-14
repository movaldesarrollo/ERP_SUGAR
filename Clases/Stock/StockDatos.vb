Public Class DatosStock


    Private idStock As Long
    Private idArticulo As Integer
    Private idAlmacen As Integer  'Almacén dónde está ubicado el artículo
    Private Cantidad As Double
    Private idUnidad As Integer
    Private idLote As Integer
    Private idArticuloProv As Integer
    Private Fecha As DateTime
    Private Precio As Double
    Private codMoneda As String
    Private idConceptoProv As Long
    Private idConceptoAlbaran As Long
    Private idProduccion As Long
    Private Movimiento As String
    Private idPersona1 As Integer
    Private idPersona2 As Integer
    Private idConceptoPedido As Long


    Private Persona1 As String
    Private Persona2 As String
    Private TipoUnidad As String
    'Private idMateriaPrima As Integer
    Private codArticulo As String
    Private Articulo As String
    Private numPedidoProv As Integer
    Private numAlbaran As Integer
    Private simbolo As String
    Private numPedido As Integer
    Private Almacen As String
    Private Proveedor As String

    Public Property gidStock() As Long
        Get
            Return idStock
        End Get
        Set(ByVal value As Long)
            idStock = value
        End Set
    End Property

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property


    Public Property gidAlmacen() As Integer
        Get
            Return idAlmacen
        End Get
        Set(ByVal value As Integer)
            idAlmacen = value
        End Set
    End Property



    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property

    Public Property gidUnidad() As Integer
        Get
            Return idUnidad
        End Get
        Set(ByVal value As Integer)
            idUnidad = value
        End Set
    End Property

    Public Property gidLote() As Integer
        Get
            Return idLote
        End Get
        Set(ByVal value As Integer)
            idLote = value
        End Set
    End Property

    Public Property gidArticuloProv() As Integer
        Get
            Return idArticuloProv
        End Get
        Set(ByVal value As Integer)
            idArticuloProv = value
        End Set
    End Property

    Public Property gFecha() As DateTime
        Get
            Return Fecha
        End Get
        Set(ByVal value As DateTime)
            Fecha = value
        End Set
    End Property

    Public Property gPrecio() As Double
        Get
            Return Precio
        End Get
        Set(ByVal value As Double)
            Precio = value
        End Set
    End Property

    Public Property gcodMoneda() As String
        Get
            Return codMoneda
        End Get
        Set(ByVal value As String)
            codMoneda = value
        End Set
    End Property


    Public Property gidConceptoProv() As Long
        Get
            Return idConceptoProv
        End Get
        Set(ByVal value As Long)
            idConceptoProv = value
        End Set
    End Property

    Public Property gidConceptoAlbaran() As Long
        Get
            Return idConceptoAlbaran
        End Get
        Set(ByVal value As Long)
            idConceptoAlbaran = value
        End Set
    End Property

    Public Property gidProduccion() As Long
        Get
            Return idProduccion
        End Get
        Set(ByVal value As Long)
            idProduccion = value
        End Set
    End Property

    Public Property gMovimiento() As String
        Get
            Return UCase(Movimiento)
        End Get
        Set(ByVal value As String)
            Movimiento = UCase(value)
        End Set
    End Property

    Public Property gidPersona1() As Integer
        Get
            Return idPersona1
        End Get
        Set(ByVal value As Integer)
            idPersona1 = value
        End Set
    End Property

    Public Property gidPersona2() As Integer
        Get
            Return idPersona2
        End Get
        Set(ByVal value As Integer)
            idPersona2 = value
        End Set
    End Property

    Public Property gidConceptoPedido() As Long
        Get
            Return idConceptoPedido
        End Get
        Set(ByVal value As Long)
            idConceptoPedido = value
        End Set
    End Property


    'Otras tablas
    Public Property gPersona1() As String
        Get
            Return UCase(Persona1)
        End Get
        Set(ByVal value As String)
            Persona1 = UCase(value)
        End Set
    End Property


    Public Property gPersona2() As String
        Get
            Return UCase(Persona2)
        End Get
        Set(ByVal value As String)
            Persona2 = UCase(value)
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


    Public Property gcodArticulo() As String
        Get
            Return UCase(codArticulo)
        End Get
        Set(ByVal value As String)
            codArticulo = UCase(value)
        End Set
    End Property


    Public Property gArticulo() As String
        Get
            Return UCase(Articulo)
        End Get
        Set(ByVal value As String)
            Articulo = UCase(value)
        End Set
    End Property


    Public Property gnumPedidoProv()
        Get
            Return numPedidoProv
        End Get
        Set(ByVal value)
            numPedidoProv = value
        End Set
    End Property


    Public Property gnumAlbaran() As Integer
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As Integer)
            numAlbaran = value
        End Set
    End Property

    Public Property gSimbolo() As String
        Get
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property

    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
        End Set
    End Property

    Public Property gAlmacen() As String
        Get
            Return Almacen
        End Get
        Set(ByVal value As String)
            Almacen = value
        End Set
    End Property

    Public Property gProveedor() As String
        Get
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
        End Set
    End Property

End Class
