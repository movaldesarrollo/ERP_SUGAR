Public Class DatosArticulo

    Private idArticulo As Integer
    Private codArticulo As String
    Private Articulo As String
    Private ArticuloEN As String
    Private Descripcion As String
    Private DescripcionEN As String
    Private FechaAlta As Date
    Private FechaBaja As Date
    Private Activo As Boolean
    Private idTipoArticulo As Integer
    Private idSubTipoArticulo As Integer
    Private idFamilia As Integer
    Private idSubFamilia As Integer
    Private idTipoCompra As Integer
    Private idUnidad As Integer
    Private Observaciones As String
    Private StockMinimo As Double
    Private Comprable As Boolean
    Private Domesticos2 As Boolean ' RAMOS
    Private Vendible As Boolean
    Private MateriaPrima As Boolean
    Private subEnsamblado As Boolean
    Private Opcion As Boolean
    Private Escandallo As Boolean
    Private idSeccion As Integer
    Private idAlmamcen As Integer
    Private idProveedor As Integer   'Proveedor por defecto
    Private KilosBrutos As Double
    Private KilosNetos As Double
    Private Bultos As Integer
    Private Alto As Double
    Private Ancho As Double
    Private Fondo As Double
    Private Volumen As Double
    Private ProduccionSeparada As Boolean 'Sólo válido si es una materia prima con escandallo. Significa que al producir se ha de ver por separado
    Private ConNumSerie As Boolean 'Indica si el artículo lleva número de serie si se produce y se vende de forma independiente
    Private ConNumSerie2 As Boolean 'Indica si el artículo lleva número de serie si se produce y se vende de forma independiente con numeración de repuesto
    Private ConVersiones As Boolean 'Indica si el artículo (siempre que tenga escandallo) tiene versiones o no

    'Datos de otras tablas
    Private PrecioUnitarioC As Double  'Precio de compra válido (último)
    Private codMonedaC As String
    Private FechaPrecioC As Date
    Private Descuento As Double 'Descuento de ArticuloCliente
    Private idProveedorPrecio As Integer 'Proveedor del precio de compra indicado
    Private idConceptoPedidoProv As Long  'Concepto de pedido de proveedor con ese precio
    Private PrecioUnitarioV As Double 'Precio de venta válido
    Private PrecioOpcion As Double 'Precio de venta como opción dentro de un conjunto
    Private codMonedaV As String
    Private FechaPrecioV As Date

    Private simboloC As String
    Private simboloV As String
    Private TipoArticulo As String
    Private SubTipoArticulo As String
    Private Familia As String
    Private subFamilia As String
    Private Seccion As String
    Private TipoCompra As String
    Private idArticuloProv As Integer 'id de articulo para el proveedor por defecto
    Private codArticuloProv As String
    Private CantidadStock As Double
    Private TipoUnidad As String = "u."
    Private Almacen As String
    Private Proveedor As String
    Private PrecioArtCli As Double
    Private idArtCli As Integer  'Sólo lo usamos para traspasar el dato  en las aplicaciones de facturación
    Private codArticuloCli As String
    Private ArticuloCli As String
    Private Descuento1 As Boolean
    Private Descuento2 As Boolean
    Private recambio As Boolean

    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
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

    Public Property gArticuloEN() As String
        Get
            Return UCase(ArticuloEN)
        End Get
        Set(ByVal value As String)
            ArticuloEN = UCase(value)
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

    Public Property gDescripcionEN() As String
        Get
            Return DescripcionEN
        End Get
        Set(ByVal value As String)
            DescripcionEN = value
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

    Public Property gRecambio() As Boolean
        Get
            Return recambio
        End Get
        Set(ByVal value As Boolean)
            recambio = value
        End Set
    End Property

    Public Property gidTipoArticulo() As Integer
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gidSubTipoArticulo() As Integer
        Get
            Return idSubTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idSubTipoArticulo = value
        End Set
    End Property

    Public Property gidFamilia() As Integer
        Get
            Return idFamilia
        End Get
        Set(ByVal value As Integer)
            idFamilia = value
        End Set
    End Property


    Public Property gidSubFamilia() As Integer
        Get
            Return idSubFamilia
        End Get
        Set(ByVal value As Integer)
            idSubFamilia = value
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


    Public Property gidUnidad() As Integer
        Get
            Return idUnidad
        End Get
        Set(ByVal value As Integer)
            idUnidad = value
        End Set
    End Property


    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
        End Set
    End Property


    Public Property gStockMinimo() As Double
        Get
            Return StockMinimo
        End Get
        Set(ByVal value As Double)
            StockMinimo = value
        End Set
    End Property

    Public Property gsubEnsamblado() As Boolean
        Get
            Return subEnsamblado
        End Get
        Set(ByVal value As Boolean)
            subEnsamblado = value
        End Set
    End Property

    Public Property gOpcion() As Boolean
        Get
            Return Opcion
        End Get
        Set(ByVal value As Boolean)
            Opcion = value
        End Set
    End Property

    Public Property gEscandallo() As Boolean
        Get
            Return Escandallo
        End Get
        Set(ByVal value As Boolean)
            Escandallo = value
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

    Public Property gidAlmacen() As Integer
        Get
            Return idAlmamcen
        End Get
        Set(ByVal value As Integer)
            idAlmamcen = value
        End Set
    End Property

    Public Property gComprable() As Boolean
        Get
            Return Comprable
        End Get
        Set(ByVal value As Boolean)
            Comprable = value
        End Set
    End Property

    Public Property gVendible() As Boolean
        Get
            Return Vendible
        End Get
        Set(ByVal value As Boolean)
            Vendible = value
        End Set
    End Property

    Public Property gMateriaPrima() As Boolean
        Get
            Return MateriaPrima
        End Get
        Set(ByVal value As Boolean)
            MateriaPrima = value
        End Set
    End Property



    Public Property gPrecioUnitarioC() As Double
        Get
            Return PrecioUnitarioC
        End Get
        Set(ByVal value As Double)
            PrecioUnitarioC = value
        End Set
    End Property

    Public Property gDescuento() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property


    Public Property gcodMonedaC() As String
        Get
            Return codMonedaC
        End Get
        Set(ByVal value As String)
            codMonedaC = value
        End Set
    End Property


    Public Property gFechaPrecioC() As Date
        Get
            Return FechaPrecioC
        End Get
        Set(ByVal value As Date)
            FechaPrecioC = value
        End Set
    End Property



    Public Property gidProveedorPrecio() As Integer
        Get
            Return idProveedorPrecio
        End Get
        Set(ByVal value As Integer)
            idProveedorPrecio = value
        End Set
    End Property


    Public Property gidConceptoPedidoProv() As Long
        Get
            Return idConceptoPedidoProv
        End Get
        Set(ByVal value As Long)
            idConceptoPedidoProv = value
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


    Public Property gKilosBrutos() As Double
        Get
            Return KilosBrutos
        End Get
        Set(ByVal value As Double)
            KilosBrutos = value
        End Set
    End Property


    Public Property gKilosNetos() As Double
        Get
            Return KilosNetos
        End Get
        Set(ByVal value As Double)
            KilosNetos = value
        End Set
    End Property

    Public Property gBultos() As Integer
        Get
            Return Bultos
        End Get
        Set(ByVal value As Integer)
            Bultos = value
        End Set
    End Property


    Public Property gAlto() As Double
        Get
            Return Alto
        End Get
        Set(ByVal value As Double)
            Alto = value
        End Set
    End Property


    Public Property gAncho() As Double
        Get
            Return Fondo
        End Get
        Set(ByVal value As Double)
            Fondo = value
        End Set
    End Property


    Public Property gFondo() As Double
        Get
            Return Fondo
        End Get
        Set(ByVal value As Double)
            Fondo = value
        End Set
    End Property


    Public Property gVolumen() As Double
        Get
            Return Volumen
        End Get
        Set(ByVal value As Double)
            Volumen = value
        End Set
    End Property

    Public Property gProduccionSeparada() As Boolean
        Get
            Return ProduccionSeparada
        End Get
        Set(ByVal value As Boolean)
            ProduccionSeparada = value
        End Set
    End Property

    Public Property gConNumSerie() As Boolean
        Get
            Return ConNumSerie
        End Get
        Set(ByVal value As Boolean)
            ConNumSerie = value
        End Set
    End Property


    Public Property gConNumSerie2() As Boolean
        Get
            Return ConNumSerie2
        End Get
        Set(ByVal value As Boolean)
            ConNumSerie2 = value
        End Set
    End Property

    Public Property gConVersiones() As Boolean
        Get
            Return ConVersiones
        End Get
        Set(ByVal value As Boolean)
            ConVersiones = value
        End Set
    End Property


    Public Property gPrecioUnitarioV() As Double
        Get
            Return PrecioUnitarioV
        End Get
        Set(ByVal value As Double)
            PrecioUnitarioV = value
        End Set
    End Property

    Public Property gPrecioOpcion() As Double
        Get
            Return PrecioOpcion
        End Get
        Set(ByVal value As Double)
            PrecioOpcion = value
        End Set
    End Property

    Public Property gcodMonedaV() As String
        Get
            Return codMonedaV
        End Get
        Set(ByVal value As String)
            codMonedaV = value
        End Set
    End Property


    Public Property gFechaPrecioV() As Date
        Get
            Return FechaPrecioV
        End Get
        Set(ByVal value As Date)
            FechaPrecioV = value
        End Set
    End Property





    'Datos de otras tablas

    Public Property gSimboloC() As String
        Get
            Return simboloC
        End Get
        Set(ByVal value As String)
            simboloC = value
        End Set
    End Property

    Public Property gSimboloV() As String
        Get
            Return simboloV
        End Get
        Set(ByVal value As String)
            simboloV = value
        End Set
    End Property

    Public Property gTipoArticulo() As String
        Get
            Return UCase(TipoArticulo)
        End Get
        Set(ByVal value As String)
            TipoArticulo = UCase(value)
        End Set
    End Property


    Public Property gSubTipoArticulo() As String
        Get
            Return UCase(SubTipoArticulo)
        End Get
        Set(ByVal value As String)
            SubTipoArticulo = UCase(value)
        End Set
    End Property

    Public Property gFamilia() As String
        Get
            Return UCase(Familia)
        End Get
        Set(ByVal value As String)
            Familia = UCase(value)
        End Set
    End Property


    Public Property gSubFamilia() As String
        Get
            Return UCase(subFamilia)
        End Get
        Set(ByVal value As String)
            subFamilia = UCase(value)
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

    Public Property gTipoCompra() As String
        Get
            Return UCase(TipoCompra)
        End Get
        Set(ByVal value As String)
            TipoCompra = UCase(value)
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

    Public Property gcodArticuloProv() As String
        Get
            Return UCase(codArticuloProv)
        End Get
        Set(ByVal value As String)
            codArticuloProv = UCase(value)
        End Set
    End Property

    Public Property gCantidadStock() As Double
        Get
            Return CantidadStock
        End Get
        Set(ByVal value As Double)
            CantidadStock = value
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

    Public Property gPrecioArtCli() As Double
        Get
            Return PrecioArtCli
        End Get
        Set(ByVal value As Double)
            PrecioArtCli = value
        End Set
    End Property


    Public Property gidArtCli() As Long
        Get
            Return idArtCli
        End Get
        Set(ByVal value As Long)
            idArtCli = value
        End Set
    End Property

    Public Property gCodArticuloCli() As String
        Get
            Return codArticuloCli
        End Get
        Set(ByVal value As String)
            codArticuloCli = value
        End Set
    End Property

    Public Property gArticuloCli() As String
        Get
            Return ArticuloCli
        End Get
        Set(ByVal value As String)
            ArticuloCli = value
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

    Public Property gDomesticos2 As Boolean
        Get
            Return Domesticos2
        End Get
        Set(value As Boolean)
            Domesticos2 = value
        End Set
    End Property
End Class
