Public Class datosConceptoFacturaComision


    Private idConceptoFactura As Long
    Private idComercial As Integer
    Private idComision As Integer
    Private Porcentaje As Double
    Private Importe As Double
    Private Liquidada As Boolean
    Private FechaLiquidacion As Date

    Private idCliente As Integer
    Private numFactura As Integer
    Private FechaFactura As Date
    Private Cliente As String
    Private Comercial As String
    Private codArticulo As String
    Private Articulo As String
    Private Cantidad As Double
    Private subTotal As Double

    Private codMoneda As String
    Private Simbolo As String
    Private TipoUnidad As String
   


    Public Property gidConceptoFactura() As Long
        Get
            Return idConceptoFactura
        End Get
        Set(ByVal value As Long)
            idConceptoFactura = value
        End Set
    End Property

    Public Property gidComercial() As Integer
        Get
            Return idComercial
        End Get
        Set(ByVal value As Integer)
            idComercial = value
        End Set
    End Property

    Public Property gidComision() As Integer
        Get
            Return idComision
        End Get
        Set(ByVal value As Integer)
            idComision = value
        End Set
    End Property

    Public Property gPorcentaje() As Double
        Get
            Return Porcentaje
        End Get
        Set(ByVal value As Double)
            Porcentaje = value
        End Set
    End Property

    Public Property gImporte() As Double
        Get
            Return Importe
        End Get
        Set(ByVal value As Double)
            Importe = value
        End Set
    End Property

    Public Property gLiquidada() As Boolean
        Get
            Return Liquidada
        End Get
        Set(ByVal value As Boolean)
            Liquidada = value
        End Set
    End Property

    Public Property gFechaLiquidacion() As Date
        Get
            Return FechaLiquidacion
        End Get
        Set(ByVal value As Date)
            FechaLiquidacion = value
        End Set
    End Property


    'Datos de otras tablas




    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
        End Set
    End Property


    Public Property gCliente() As String
        Get
            Return UCase(Cliente)
        End Get
        Set(ByVal value As String)
            Cliente = UCase(value)
        End Set
    End Property


    Public Property gComercial() As String
        Get
            Return UCase(Comercial)
        End Get
        Set(ByVal value As String)
            Comercial = UCase(value)
        End Set
    End Property

    Public Property gnumFactura() As Integer
        Get
            Return numFactura
        End Get
        Set(ByVal value As Integer)
            numFactura = value
        End Set
    End Property

    Public Property gFechaFactura() As Date
        Get
            Return FechaFactura
        End Get
        Set(ByVal value As Date)
            FechaFactura = value
        End Set
    End Property

    Public Property gCodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property

    Public Property gArticulo() As String
        Get
            Return Articulo
        End Get
        Set(ByVal value As String)
            Articulo = value
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

    Public Property gsubTotal() As Double
        Get
            Return subTotal
        End Get
        Set(ByVal value As Double)
            subTotal = value
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

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
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

End Class
