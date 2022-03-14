Public Class DatosConceptoAlbaranProv

    Private idConcepto As Long
    Private idAlbaran As Integer
    Private idFactura As Integer
    Private codArticuloProv As String
    Private ArticuloProv As String
    Private idArticulo As Integer

    Private Cantidad As Double
    Private PVPUnitario As Double
    Private idTipoIVA As Integer
    Private Descuento As Double
    Private PrecioNetoUnitario As Double
    Private Orden As Integer
    Private idEstado As Integer
    Private idArticuloProv As Integer
    Private idConceptoPedidoProv As Long
    Private Observaciones As String

    Private numPedido As Integer
    Private Articulo As String
    Private codArticulo As String
    Private idUnidad As Integer
    Private TipoUnidad As String
    Private codMoneda As String
    Private numAlbaran As String
    Private FechaRecibido As Date
    Private Simbolo As String
    Private Estado As String
    Private idFamilia As Integer = 0
    Private Familia As String = ""
    Private idsubFamilia As Integer = 0
    Private subFamilia As String = ""
    Private TipoIVA As Double
    Private TipoRecargoEq As Double
    Private NombreTipoIVA As String

    Private TotalConcepto As Double


    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
        End Set
    End Property

    Public Property gidAlbaran() As Integer
        Get
            Return idAlbaran
        End Get
        Set(ByVal value As Integer)
            idAlbaran = value
        End Set
    End Property

    Public Property gidFactura() As Integer
        Get
            Return idFactura
        End Get
        Set(ByVal value As Integer)
            idFactura = value
        End Set
    End Property

    Public Property gcodArticuloProv() As String
        Get
            Return codArticuloProv
        End Get
        Set(ByVal value As String)
            codArticuloProv = value
        End Set
    End Property

    Public Property gArticuloProv() As String
        Get
            Return ArticuloProv
        End Get
        Set(ByVal value As String)
            ArticuloProv = value
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

    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property

    Public Property gPVPUnitario() As Double
        Get
            Return PVPUnitario
        End Get
        Set(ByVal value As Double)
            PVPUnitario = value
        End Set
    End Property

    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
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

    Public Property gPrecioNetoUnitario() As Double
        Get
            Return PrecioNetoUnitario
        End Get
        Set(ByVal value As Double)
            PrecioNetoUnitario = value
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

    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
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

    Public Property gidConceptoPedidoProv() As Long
        Get
            Return idConceptoPedidoProv
        End Get
        Set(ByVal value As Long)
            idConceptoPedidoProv = value
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






    'Otras tablas


    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
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


    Public Property gcodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
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

    Public Property gTipoUnidad() As String
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value As String)
            TipoUnidad = value
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

    Public Property gnumAlbaran() As String
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As String)
            numAlbaran = value
        End Set
    End Property

    Public Property gFechaRecibido() As Date
        Get
            Return FechaRecibido
        End Get
        Set(ByVal value As Date)
            FechaRecibido = value
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

    Public Property gEstado() As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
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

    Public Property gFamilia() As String
        Get
            Return Familia
        End Get
        Set(ByVal value As String)
            Familia = value
        End Set
    End Property


    Public Property gidSubFamilia() As Integer
        Get
            Return idsubFamilia
        End Get
        Set(ByVal value As Integer)
            idsubFamilia = value
        End Set
    End Property

    Public Property gSubFamilia() As String
        Get
            Return subFamilia
        End Get
        Set(ByVal value As String)
            subFamilia = value
        End Set
    End Property

    Public Property gTipoIVA() As Double
        Get
            Return TipoIVA
        End Get
        Set(ByVal value As Double)
            TipoIVA = value
        End Set
    End Property

    Public Property gTipoRecargoEq() As Double
        Get
            Return TipoRecargoEq
        End Get
        Set(ByVal value As Double)
            TipoRecargoEq = value
        End Set
    End Property


    Public Property gNombreTipoIVA() As String
        Get
            Return NombreTipoIVA
        End Get
        Set(ByVal value As String)
            NombreTipoIVA = value
        End Set
    End Property

    Public Property gTotalConcepto() As Double
        Get
            Return TotalConcepto
        End Get
        Set(ByVal value As Double)
            TotalConcepto = value
        End Set
    End Property





End Class
