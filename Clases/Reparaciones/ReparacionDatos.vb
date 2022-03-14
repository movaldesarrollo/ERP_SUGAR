Public Class DatosReparacion

    Private precioTotalReparacion As Double
    Private numReparacion As Integer
    Private ReferenciaCliente As String
    Private idEstado As Integer
    Private idEstatus As Integer
    Private Fecha As Date
    Private FechaEntrega As Date
    Private idCliente As Integer
    Private idUbicacion As Integer
    Private idContacto As Integer
    Private codMoneda As String
    Private idTipoIVA As Integer
    Private idTipoRetencion As Integer
    Private RecargoEquivalencia As Boolean
    Private ProntoPago As Double
    Private SolicitadoVia As String
    Private Notas As String   'Se imprimen al final del documento
    Private Observaciones As String 'Sólo se ven en pantalla
    Private idPersona As Integer
    Private PrecioTransporte As Double
    Private Portes As Char
    Private idTipoValorado As Integer
    Private idEquipo As Long
    Private idEquipoHistorico As Long
    Private numSerie As String
    Private idArticulo As Integer
    Private Garantia As Boolean
    Private Descripcion As String
    Private Inspeccion As String
    Private idTransporte As Integer
    Private Transporte As String
    Private Caja As Boolean
    Private Celula As Boolean
    Private Sonda As Boolean
    Private Placa As Boolean
    Private Otros As Boolean
    Private OtrosTipos As String
    Private FechaFabricacionRep As Date 'Para el caso que no esté el equipo en la base de datos.
    Private codArticuloCli As String
    Private numPedido As Integer
    Private numOferta As Integer
    Private numProforma As Integer
    Private sRMA As String


    'Datos de otras tablas
    Private TipoRetencion As String
    Private TrabajoARealizar As String
    Private Estado As String
    Private Estatus As String
    Private Cliente As String
    Private Direccion As String
    Private Contacto As String
    Private Simbolo As String
    Private Divisa As String
    Private TipoIVA As Double
    Private TipoRecargoEq As Double
    Private TipoValorado As String
    Private NombreTipoIVA As String
    Private NombreTipoRetencion As String
    Private ObservacionesCli As String
    Private Persona As String
    Private numAlbaran As Integer
    Private numFactura As Integer
    Private codArticulo As String
    Private Articulo As String
    Private FechaFabricacion As Date
    Private FechaServido As Date
    Private FechaFactura As Date
    Private dtsEstado As DatosEstado

    'Calculadas
    Private Base As Double
    Private TotalIVA As Double
    Private TotalRE As Double
    Private Retencion As Double
    Private Total As Double
    Private ImportePP As Double 'Importe del descuento Pronto Pago
    Private ImporteDescuentos As Double

#Region "PROPIEDADES REPARACIONES"
    'Se definen las propiedades de reparaciones
    Public Property gnumReparacion() As Integer
        Get
            Return numReparacion
        End Get
        Set(ByVal value As Integer)
            numReparacion = value
        End Set
    End Property

    Public Property gPrecioTotalReparacion() As Double
        Get
            Return precioTotalReparacion
        End Get
        Set(value As Double)
            precioTotalReparacion = value
        End Set
    End Property

    Public Property gReferenciaCliente() As String
        Get
            Return UCase(ReferenciaCliente)
        End Get
        Set(ByVal value As String)
            ReferenciaCliente = UCase(value)
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

    Public Property gidEstatus() As Integer
        Get
            Return idEstatus
        End Get
        Set(ByVal value As Integer)
            idEstatus = value
        End Set
    End Property

    Public Property gFecha() As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
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

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
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


    Public Property gidContacto() As Integer
        Get
            Return idContacto
        End Get
        Set(ByVal value As Integer)
            idContacto = value
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

    Public Property gidTipoIVA() As Integer
        Get
            Return idTipoIVA
        End Get
        Set(ByVal value As Integer)
            idTipoIVA = value
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

    Public Property gNotas() As String
        Get
            Return Notas
        End Get
        Set(ByVal value As String)
            Notas = value
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

    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
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

    Public Property gPortes() As Char
        Get
            Return Portes
        End Get
        Set(ByVal value As Char)
            Portes = value
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

    Public Property gTotalRE() As Double
        Get
            Return TotalRE
        End Get
        Set(ByVal value As Double)
            TotalRE = value
        End Set
    End Property

    Public Property gidTipoRetencion() As Integer
        Get
            Return idTipoRetencion
        End Get
        Set(ByVal value As Integer)
            idTipoRetencion = value
        End Set
    End Property

    Public Property gRecargoEquivalencia() As Boolean
        Get
            Return RecargoEquivalencia
        End Get
        Set(ByVal value As Boolean)
            RecargoEquivalencia = value
        End Set
    End Property

    Public Property gProntoPago() As Double
        Get
            Return ProntoPago
        End Get
        Set(ByVal value As Double)
            ProntoPago = value
        End Set
    End Property

    Public Property gidEquipo() As Long
        Get
            Return idEquipo
        End Get
        Set(ByVal value As Long)
            idEquipo = value
        End Set
    End Property

    Public Property gidEquipoHistorico() As Long
        Get
            Return idEquipoHistorico
        End Get
        Set(ByVal value As Long)
            idEquipoHistorico = value
        End Set
    End Property

    Public Property gnumSerie() As String
        Get
            Return numSerie
        End Get
        Set(ByVal value As String)
            numSerie = value
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

    Public Property gGarantia() As Boolean
        Get
            Return Garantia
        End Get
        Set(ByVal value As Boolean)
            Garantia = value
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

    Public Property gInspeccion() As String
        Get
            Return Inspeccion
        End Get
        Set(ByVal value As String)
            Inspeccion = value
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

    Public Property gCaja() As Boolean
        Get
            Return Caja
        End Get
        Set(ByVal value As Boolean)
            Caja = value
        End Set
    End Property

    Public Property gCelula() As Boolean
        Get
            Return Celula
        End Get
        Set(ByVal value As Boolean)
            Celula = value
        End Set
    End Property

    Public Property gSonda() As Boolean
        Get
            Return Sonda
        End Get
        Set(ByVal value As Boolean)
            Sonda = value
        End Set
    End Property

    Public Property gPlaca() As Boolean
        Get
            Return Placa
        End Get
        Set(ByVal value As Boolean)
            Placa = value
        End Set
    End Property

    Public Property gOtros() As Boolean
        Get
            Return Otros
        End Get
        Set(ByVal value As Boolean)
            Otros = value
        End Set
    End Property

    Public Property gOtrosTipos() As String
        Get
            Return UCase(OtrosTipos)
        End Get
        Set(ByVal value As String)
            OtrosTipos = UCase(value)
        End Set
    End Property

    Public Property gFechaFabricacionRep() As Date
        Get
            Return FechaFabricacionRep
        End Get
        Set(ByVal value As Date)
            FechaFabricacionRep = value
        End Set
    End Property

    Public Property gcodArticuloCli() As String
        Get
            Return UCase(codArticuloCli)
        End Get
        Set(ByVal value As String)
            codArticuloCli = UCase(value)
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

    Public Property gnumProforma() As Integer
        Get
            Return numProforma
        End Get
        Set(ByVal value As Integer)
            numProforma = value
        End Set
    End Property

    Public Property gnumOferta() As Integer
        Get
            Return numOferta
        End Get
        Set(ByVal value As Integer)
            numOferta = value
        End Set
    End Property

    'Otras tablas

    Public Property gTrabajoARealizar() As String
        Get
            Return TrabajoARealizar
        End Get
        Set(ByVal value As String)
            TrabajoARealizar = value
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

    Public Property gEstatus() As String
        Get
            Return Estatus
        End Get
        Set(ByVal value As String)
            Estatus = value
        End Set
    End Property

    Public Property gCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
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

    Public Property gTipoRecargoEq() As Double
        Get
            Return TipoRecargoEq
        End Get
        Set(ByVal value As Double)
            TipoRecargoEq = value
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

    Public Property gTipoRetencion() As Double
        Get
            Return TipoRetencion
        End Get
        Set(ByVal value As Double)
            TipoRetencion = value
        End Set
    End Property

    Public Property gNombreTipoRetencion() As String
        Get
            Return NombreTipoRetencion
        End Get
        Set(ByVal value As String)
            NombreTipoRetencion = value
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

    Public Property gFechaFabricacion() As Date
        Get
            Return FechaFabricacion
        End Get
        Set(ByVal value As Date)
            FechaFabricacion = value
        End Set
    End Property

    Public Property gFechaServido() As Date
        Get
            Return FechaServido
        End Get
        Set(ByVal value As Date)
            FechaServido = value
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

    Public Property gdtsEstado() As DatosEstado
        Get
            Return dtsEstado
        End Get
        Set(ByVal value As DatosEstado)
            dtsEstado = value
        End Set
    End Property

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

    Public Property gImportePP() As Double
        Get
            Return ImportePP
        End Get
        Set(ByVal value As Double)
            ImportePP = value
        End Set
    End Property

    Public Property gImporteDescuentos() As Double
        Get
            Return gImporteDescuentos
        End Get
        Set(ByVal value As Double)
            ImporteDescuentos = value
        End Set
    End Property

    Public Property gObservacionesCli() As String
        Get
            Return ObservacionesCli
        End Get
        Set(ByVal value As String)
            ObservacionesCli = value
        End Set
    End Property

    Public Property gRMA As String
        Get
            Return sRMA
        End Get
        Set(value As String)
            sRMA = value
        End Set
    End Property

#End Region


End Class

