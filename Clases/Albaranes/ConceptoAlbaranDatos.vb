Public Class DatosConceptoAlbaran


    Private idConcepto As Long
    Private numAlbaran As Integer
    Private numFactura As Integer
    Private numDevolucion As Integer
    Private codArticuloCli As String
    Private ArticuloCli As String
    Private RefCliente As String
    Private idArticulo As Integer
    Private Cantidad As Double
    Private PVPUnitario As Double
    Private idTipoIVA As Integer
    Private Descuento As Double
    Private PrecioNetoUnitario As Double
    Private Orden As Integer
    Private idEstado As Integer
    Private idArtCli As Long
    Private idConceptoPedido As Long
    Private numsSerie As String
    Private idConceptoPedidoProv As Long
    Private idArticuloProv As Long

    'Campo calculado
    Private subTotal As Double

    'Datos de otras tablas
    Private codArticulo As String = ""
    Private Articulo As String = ""
    Private idTipoArticulo As Integer = 0
    Private TipoArticulo As String = ""
    Private idSubTipoArticulo As Integer = 0
    Private subTipoArticulo As String = ""
    Private idUnidad As Integer = 0
    Private TipoUnidad As String = ""
    Private TipoIVA As Double = 0
    Private TipoRecargoEq As Double = 0
    Private Estado As String = ""
    Private numPedido As Integer = 0
    Private idFamilia As Integer = 0
    Private Familia As String = ""
    Private idsubFamilia As Integer = 0
    Private subFamilia As String = ""


    Public Property gidConcepto() As Integer
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Integer)
            idConcepto = value
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

    Public Property gnumFactura() As Integer
        Get
            Return numFactura
        End Get
        Set(ByVal value As Integer)
            numFactura = value
        End Set
    End Property

    Public Property gnumDevolucion() As Integer
        Get
            Return numDevolucion
        End Get
        Set(ByVal value As Integer)
            numDevolucion = value
        End Set
    End Property

    Public Property gcodArticuloCli() As String
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

    Public Property gRefCliente() As String
        Get
            Return RefCliente
        End Get
        Set(ByVal value As String)
            RefCliente = value
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

    Public Property gidArtCli() As Long
        Get
            Return idArtCli
        End Get
        Set(ByVal value As Long)
            idArtCli = value
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

    Public Property gnumsSerie() As String
        Get
            Return numsSerie
        End Get
        Set(ByVal value As String)
            numsSerie = value
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

    Public Property gidArticuloProv() As Long
        Get
            Return idArticuloProv
        End Get
        Set(ByVal value As Long)
            idArticuloProv = value
        End Set
    End Property

    'Calculado
    Public Property gSubTotal() As Double
        Get
            If PrecioNetoUnitario = 0 Then
                Return Cantidad * (PVPUnitario * (1 - Descuento / 100))
            Else
                Return Cantidad * PrecioNetoUnitario
            End If
        End Get
        Set(ByVal value As Double)

        End Set
    End Property

    'Otras tablas

    Public Property gcodArticulo() As String
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

    Public Property gidTipoArticulo() As Integer
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gTipoArticulo() As String
        Get
            Return TipoArticulo
        End Get
        Set(ByVal value As String)
            TipoArticulo = value
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

    Public Property gSubTipoArticulo() As String
        Get
            Return subTipoArticulo
        End Get
        Set(ByVal value As String)
            subTipoArticulo = value
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

    Public Property gEstado() As String
        Get
            Return UCase(Estado)
        End Get
        Set(ByVal value As String)
            Estado = UCase(value)
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

    Public Function Clonar() As DatosConceptoAlbaran
        Dim dts As New DatosConceptoAlbaran
        dts.gidConcepto = idConcepto
        dts.gnumAlbaran = numAlbaran
        dts.gnumFactura = numFactura
        dts.gnumDevolucion = numDevolucion
        dts.gcodArticuloCli = codArticuloCli
        dts.gArticuloCli = ArticuloCli
        dts.gRefCliente = RefCliente
        dts.gidArticulo = idArticulo
        dts.gCantidad = Cantidad
        dts.gPVPUnitario = PVPUnitario
        dts.gidTipoIVA = idTipoIVA
        dts.gDescuento = Descuento
        dts.gPrecioNetoUnitario = PrecioNetoUnitario
        dts.gOrden = Orden
        dts.gidEstado = idEstado
        dts.gidArtCli = idArtCli
        dts.gidConceptoPedido = idConceptoPedido
        dts.gnumsSerie = numsSerie
        dts.gidConceptoPedidoProv = idConceptoPedidoProv
        dts.gidArticuloProv = idArticuloProv
        dts.gSubTotal = subTotal
        dts.gcodArticulo = codArticulo
        dts.gArticulo = Articulo
        dts.gidTipoArticulo = idTipoArticulo
        dts.gTipoArticulo = TipoArticulo
        dts.gidSubTipoArticulo = idSubTipoArticulo
        dts.gSubTipoArticulo = subTipoArticulo
        dts.gidUnidad = idUnidad
        dts.gTipoUnidad = TipoUnidad
        dts.gTipoIVA = TipoIVA
        dts.gTipoRecargoEq = TipoRecargoEq
        dts.gEstado = Estado
        dts.gnumPedido = numPedido
        dts.gidFamilia = idFamilia
        dts.gFamilia = Familia
        dts.gidSubFamilia = idsubFamilia
        dts.gSubFamilia = subFamilia
        Return dts
    End Function

End Class

