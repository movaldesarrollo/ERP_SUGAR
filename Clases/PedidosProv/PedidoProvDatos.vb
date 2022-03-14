Public Class DatosPedidoProv

    Private numPedido As Integer
    Private idProveedor As Integer
    Private PedidoProveedor As String
    Private SolicitadoVia As String
    Private idUbicacion As Integer
    Private idTipoIVA As Double
    Private Observaciones As String
    Private FechaPedido As Date
    Private FechaEntrega As Date
    Private idTipoCompra As Integer
    Private HorarioEntrega As String
    Private codMoneda As String
    Private idPersona As Integer
    Private idContacto As Integer
    Private idTransporte As Integer
    Private Transporte As String
    Private Portes As Char
    Private Descuento As Double
    Private Pagado As Boolean
    Private idTipoValorado As Integer
    Private Notas As String
    Private idEstado As Integer
    Private TipoIVAFac As Double  'El tipo de iva efectivo se guarda
    Private PrecioTransporte As Double
    Private idTipoRetencion As Double
    Private TipoRetencionFac As Double 'Datos que se guardan en la factura aunque cambien en la tabla.

    'Datos de otras tablas
    Private Proveedor As String
    Private codProveedor As String
    Private TipoIVA As Double
    Private TipoRetencion As Double
    Private NombreTipoIVA As String
    Private Simbolo As String
    Private Divisa As String
    Private Estado As String
    Private TipoValorado As String
    Private Direccion As String
    Private Contacto As String
    Private ObservacionesProv As String
    Private AgenciaTransporte As String
    Private Persona As String

    'Campos calculados
    Private Base As Double
    Private TotalIVA As Double
    Private Retencion As Double
    Private Total As Double
    Private ImporteDescuentoGeneral As Double
    Private ImporteDescuentos As Double

    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
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

    Public Property gPedidoProveedor() As String
        Get
            Return PedidoProveedor
        End Get
        Set(ByVal value As String)
            PedidoProveedor = value
        End Set
    End Property

    Public Property gSolicitadoVia() As String
        Get
            Return SolicitadoVia
        End Get
        Set(ByVal value As String)
            SolicitadoVia = value
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

    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
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


    Public Property gFechaPedido() As Date
        Get
            Return FechaPedido
        End Get
        Set(ByVal value As Date)
            FechaPedido = value
        End Set
    End Property


    Public Property gFechaEntrega() As Date
        Get
            Return FechaEntrega
        End Get
        Set(ByVal value As Date)
            FechaEntrega = value
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

    Public Property gHorarioEntrega() As String
        Get
            Return HorarioEntrega
        End Get
        Set(ByVal value As String)
            HorarioEntrega = value
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


    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
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

    Public Property gidTransporte() As Integer
        Get
            Return idTransporte
        End Get
        Set(ByVal value As Integer)
            idTransporte = value
        End Set
    End Property

    Public Property gTransporte() As String
        Get
            Return Transporte
        End Get
        Set(ByVal value As String)
            Transporte = value
        End Set
    End Property


    Public Property gPortes() As Char
        Get
            Return Portes
        End Get
        Set(ByVal value As Char)
            Portes = value
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

    Public Property gPagado() As Boolean
        Get
            Return Pagado
        End Get
        Set(ByVal value As Boolean)
            Pagado = value
        End Set
    End Property

    Public Property gidTipoValorado() As Integer
        Get
            Return idTipoValorado
        End Get
        Set(ByVal value As Integer)
            idTipoValorado = value
        End Set
    End Property

    Public Property gNotas() As String
        Get
            Return Notas
        End Get
        Set(ByVal value As String)
            Notas = value
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

    Public Property gTipoIVAFac() As Double
        Get
            Return TipoIVAFac
        End Get
        Set(ByVal value As Double)
            TipoIVAFac = value
        End Set
    End Property

    Public Property gPrecioTransporte() As Double
        Get
            Return PrecioTransporte
        End Get
        Set(ByVal value As Double)
            PrecioTransporte = value
        End Set
    End Property


    Public Property gidTipoRetencion() As Double
        Get
            Return idTipoRetencion
        End Get
        Set(ByVal value As Double)
            idTipoRetencion = value
        End Set
    End Property

    Public Property gTipoRetencionFac() As Double
        Get
            Return TipoRetencionFac
        End Get
        Set(ByVal value As Double)
            TipoRetencionFac = value
        End Set
    End Property


    'Otras tablas

    Public Property gProveedor() As String
        Get
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
        End Set
    End Property

    Public Property gcodProveedor() As String
        Get
            Return codProveedor
        End Get
        Set(ByVal value As String)
            codProveedor = value
        End Set
    End Property

    Public Property gTipoRetencion() As Double
        Get
            Return TipoRetencion
        End Get
        Set(ByVal value As Double)
            TipoRetencion = value
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

    Public Property gNombreTipoIVA() As String
        Get
            Return NombreTipoIVA
        End Get
        Set(ByVal value As String)
            NombreTipoIVA = value
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

    Public Property gDivisa() As String
        Get
            Return Divisa
        End Get
        Set(ByVal value As String)
            Divisa = value
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

    Public Property gTipoValorado() As String
        Get
            Return TipoValorado
        End Get
        Set(ByVal value As String)
            TipoValorado = value
        End Set
    End Property

    Public Property gDireccion() As String
        Get
            Return Direccion
        End Get
        Set(ByVal value As String)
            Direccion = value
        End Set
    End Property


    Public Property gContacto() As String
        Get
            Return Contacto
        End Get
        Set(ByVal value As String)
            Contacto = value
        End Set
    End Property

    Public Property gObservacionesProv() As String
        Get
            Return ObservacionesProv
        End Get
        Set(ByVal value As String)
            ObservacionesProv = value
        End Set
    End Property

    Public Property gAgenciaTransporte() As String
        Get
            Return AgenciaTransporte
        End Get
        Set(ByVal value As String)
            AgenciaTransporte = value
        End Set
    End Property

    Public Property gPersona() As String
        Get
            Return Persona
        End Get
        Set(ByVal value As String)
            Persona = value
        End Set
    End Property

    'Campos Calculados

    Public Property gBase() As Double
        Get
            Return Base
        End Get
        Set(ByVal value As Double)
            Base = value
        End Set
    End Property

    Public Property gTotalIVA() As Double
        Get
            Return TotalIVA
        End Get
        Set(ByVal value As Double)
            TotalIVA = value
        End Set
    End Property

    Public Property gRetencion() As Double
        Get
            Return Retencion
        End Get
        Set(ByVal value As Double)
            Retencion = value
        End Set
    End Property

    Public Property gTotal() As Double
        Get
            Return Total
        End Get
        Set(ByVal value As Double)
            Total = value
        End Set
    End Property

    Public Property gImporteDescuentoGeneral() As Double
        Get
            Return ImporteDescuentoGeneral
        End Get
        Set(ByVal value As Double)
            ImporteDescuentoGeneral = value
        End Set
    End Property

    Public Property gImporteDescuentos() As Double
        Get
            Return ImporteDescuentos
        End Get
        Set(ByVal value As Double)
            ImporteDescuentos = value
        End Set
    End Property


End Class

