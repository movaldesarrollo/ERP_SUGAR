Public Class DatosConceptoFactura


    Private idConcepto As Long
    Private numFactura As Integer
    'Private numProduccion As Integer
    Private numAbono As Integer
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
    Private TipoIVAFac As Double 'el tipo real de la factura
    Private TipoRecargoEqFac As Double
    Private idConceptoAlbaran As Long
    Private NumsSerie As String
    Private PorcentajeComision As Double
    Private ImporteComision As Double
    
    'Campo calculado
    Private subTotal As Double

    'Datos de otras tablas
    Private codArticulo As String
    Private Articulo As String
    Private idTipoArticulo As Integer
    Private TipoArticulo As String
    Private idSubTipoArticulo As Integer
    Private subTipoArticulo As String
    Private idUnidad As Integer
    Private TipoUnidad As String
    Private TipoIVA As Double 'El tipo correspondiente actualmente en la tabla de tipos de iva
    Private TipoRecargoEq As Double
    Private Estado As String
    Private numAlbaran As Integer


    Public Property gidConcepto() As Integer
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Integer)
            idConcepto = value
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


    Public Property gnumAbono() As Integer
        Get
            Return numAbono
        End Get
        Set(ByVal value As Integer)
            numAbono = value
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

    Public Property gTipoIVAFac() As Double
        Get
            Return TipoIVAFac
        End Get
        Set(ByVal value As Double)
            TipoIVAFac = value
        End Set
    End Property


    Public Property gTipoRecargoEqFac() As Double
        Get
            Return TipoRecargoEqFac
        End Get
        Set(ByVal value As Double)
            TipoRecargoEqFac = value
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

    Public Property gNumsSerie() As String
        Get
            Return NumsSerie
        End Get
        Set(ByVal value As String)
            NumsSerie = value
        End Set
    End Property

    

    Public Property gPorcentajeComision() As Double
        Get
            Return PorcentajeComision
        End Get
        Set(ByVal value As Double)
            PorcentajeComision = value
        End Set
    End Property

    Public Property gImporteComision() As Double
        Get
            Return ImporteComision
        End Get
        Set(ByVal value As Double)
            ImporteComision = value
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

    Public Property gnumAlbaran() As Integer
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As Integer)
            numAlbaran = value
        End Set
    End Property

   

End Class

