Public Class DatosConceptoPedidoProv

    Private idConcepto As Long
    Private numPedido As Integer
    Private idArticulo As Integer
    Private idArticuloProv As Integer
    Private ArticuloProv As String
    Private Cantidad As Double
    Private Descuento As Double
    Private PrecioNetoUnitario As Double
    Private Recibido As Boolean
    Private Aceptado As Boolean
    Private FechaRecibido As Date
    Private codArticuloProv As String
    Private CantidadRecibida As Double
    Private FechaPrevista As Date
    Private idEstado As Integer
    Private idTipoIVA As Integer
    Private TipoIVAFac As Double
    Private PVPUnitario As Double
    Private idSeccion As Integer
    Private Orden As Integer

    Private Familia As String
    Private SubFamilia As String
    Private Articulo As String
    Private codArticulo As String
    Private idUnidad As Integer
    Private TipoUnidad As String
    Private TipoIVA As Double 'El tipo correspondiente actualmente en la tabla de tipos de iva
    Private Estado As String
    Private codMoneda As String
    Private numAlbaranProv As String
    Private Seccion As String

    Private TotalConcepto As Double
    Private Pendiente As Double



    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
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


    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
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


    Public Property gArticuloProv() As String
        Get
            Return ArticuloProv
        End Get
        Set(ByVal value As String)
            ArticuloProv = value
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

    Public Property gRecibido() As Boolean
        Get
            Return Recibido
        End Get
        Set(ByVal value As Boolean)
            Recibido = value
        End Set
    End Property


    Public Property gAceptado() As Boolean
        Get
            Return Aceptado
        End Get
        Set(ByVal value As Boolean)
            Aceptado = value
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

    Public Property gcodArticuloProv() As String
        Get
            Return codArticuloProv
        End Get
        Set(ByVal value As String)
            codArticuloProv = value
        End Set
    End Property

    Public Property gCantidadRecibida() As Double
        Get
            Return CantidadRecibida
        End Get
        Set(ByVal value As Double)
            CantidadRecibida = value
        End Set
    End Property


    Public Property gFechaPrevista() As Date
        Get
            Return FechaPrevista
        End Get
        Set(ByVal value As Date)
            FechaPrevista = value
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


    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
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

    Public Property gPVPUnitario() As Double
        Get
            Return PVPUnitario
        End Get
        Set(ByVal value As Double)
            PVPUnitario = value
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

    Public Property gOrden() As Integer
        Get
            Return Orden
        End Get
        Set(ByVal value As Integer)
            Orden = value
        End Set
    End Property


    'Otras tablas


    Public Property gFamilia() As String
        Get
            Return Familia
        End Get
        Set(ByVal value As String)
            Familia = value
        End Set
    End Property


    Public Property gsubFamilia() As String
        Get
            Return SubFamilia
        End Get
        Set(ByVal value As String)
            SubFamilia = value
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

    Public Property gTipoIVA() As Double
        Get
            Return TipoIVA
        End Get
        Set(ByVal value As Double)
            TipoIVA = value
        End Set
    End Property


    Public Property gEstado() As String
        Get
            Return UCase(Estado)
        End Get
        Set(ByVal value As String)
            Estado = value
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

    Public Property gSeccion() As String
        Get
            Return UCase(Seccion)
        End Get
        Set(ByVal value As String)
            Seccion = value
        End Set
    End Property


    'Campos Calculados

    Public Property gTotalConcepto() As Double
        Get
            Return TotalConcepto
        End Get
        Set(ByVal value As Double)
            TotalConcepto = value
        End Set
    End Property



    Public ReadOnly Property gPendiente() As Double
        Get
            ' If Cantidad > CantidadRecibida Then
            Return Cantidad - CantidadRecibida
            'Else
            'Return 0
            'End If

        End Get
    End Property
End Class
