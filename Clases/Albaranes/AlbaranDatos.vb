Public Class DatosAlbaran

    Private numAlbaran As Integer
    Private ReferenciaCliente As String
    Private idEstado As Integer
    Private Fecha As Date
    Private FechaEntrega As Date
    Private idCliente As Integer
    Private idUbicacion As Integer
    Private idContacto As Integer
    Private idMedioPago As Integer
    Private idTipoPago As Integer
    Private idCuentaBanco As Integer
    Private codMoneda As String
    Private idTipoIVA As Integer
    Private idTipoRetencion As Integer
    Private RecargoEquivalencia As Boolean
    Private Descuento As Double
    Private Descuento2 As Double
    Private ProntoPago As Double
    Private SolicitadoVia As String
    Private Notas As String   'Se imprimen al final del documento
    Private Observaciones As String 'Sólo se ven en pantalla
    Private idTipoValorado As Integer
    Private Portes As Char
    Private Bultos As Integer
    Private KilosBrutos As Double
    Private KilosNetos As Double
    Private Volumen As Double
    Private idTransporte As Integer
    Private Transporte As String
    Private ReferenciaCliente2 As String
    Private idPersona As Integer
    Private PrecioTransporte As Double
    Private Medidas As String
    Private idProveedor As Integer
    Private Recogido As Boolean = False
    Private Creacion As Date
    'Private FechaPreparado As Date = Now.Date

    'Datos de otras tablas
    Private Estado As String
    Private numSFactura As List(Of Integer) 'En lo que se ha convertido
    Private numSDevolucion As List(Of Integer) 'En lo que se ha convertido
    Private Cliente As String
    Private Direccion As String
    Private Contacto As String
    Private MedioPago As String
    Private TipoPago As String
    Private Banco As String
    Private IBAN As String
    Private Divisa As String
    Private Simbolo As String
    Private TipoIVA As Double
    Private NombreTipoIVA As String
    Private TipoRecargoEq As Double
    Private TipoRetencion As Double
    Private NombreTipoRetencion As String
    Private ObservacionesCli As String
    Private numSPedido As List(Of Integer)
    Private AgenciaTransporte As String
    Private TipoValorado As String
    Private Persona As String
    Private Proveedor As String

    'Calculadas
    Private Base As Double
    Private TotalIVA As Double
    Private TotalRE As Double
    Private Retencion As Double
    Private Total As Double
    Private ImportePP As Double 'Importe del descuento Pronto Pago
    Private ImporteDescuentos As Double
    Private sumaKilosNetos As Double
    Private sumaKilosBrutos As Double
    Private sumaVolumen As Double
    Private sumaBultos As Integer


    Public Property gnumAlbaran() As Integer
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As Integer)
            numAlbaran = value
        End Set
    End Property

    Public Property gReferenciaCliente() As String
        Get
            Return ReferenciaCliente
        End Get
        Set(ByVal value As String)
            ReferenciaCliente = value
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

    Public Property gidMedioPago() As Integer
        Get
            Return idMedioPago
        End Get
        Set(ByVal value As Integer)
            idMedioPago = value
        End Set
    End Property

    Public Property gidTipoPago() As Integer
        Get
            Return idTipoPago
        End Get
        Set(ByVal value As Integer)
            idTipoPago = value
        End Set
    End Property

    Public Property gidCuentaBanco() As Integer
        Get
            Return idCuentaBanco
        End Get
        Set(ByVal value As Integer)
            idCuentaBanco = value
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

    Public Property gDescuento() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property

    Public Property gDescuento2() As Double
        Get
            Return Descuento2
        End Get
        Set(ByVal value As Double)
            Descuento2 = value
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

    Public Property gidTipoValorado() As Integer
        Get
            Return idTipoValorado
        End Get
        Set(ByVal value As Integer)
            idTipoValorado = value
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


    Public Property gBultos() As Integer
        Get
            Return Bultos
        End Get
        Set(ByVal value As Integer)
            Bultos = value
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

    Public Property gVolumen() As Double
        Get
            Return Volumen
        End Get
        Set(ByVal value As Double)
            Volumen = value
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


    Public Property gReferenciaCliente2() As String
        Get
            Return ReferenciaCliente2
        End Get
        Set(ByVal value As String)
            ReferenciaCliente2 = value
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

    Public Property gMedidas() As String
        Get
            Return Medidas
        End Get
        Set(ByVal value As String)
            Medidas = value
        End Set
    End Property


    Public Property gidProveedor() As String
        Get
            Return idProveedor
        End Get
        Set(ByVal value As String)
            idProveedor = value
        End Set
    End Property

    Public Property gRecogido() As Boolean
        Get
            Return Recogido
        End Get
        Set(ByVal value As Boolean)
            Recogido = value
        End Set
    End Property

    Public Property gCreacion() As Date
        Get
            Return Creacion
        End Get
        Set(ByVal value As Date)
            Creacion = value
        End Set
    End Property

    'Public Property gFechaPreparado() As Date
    '    Get
    '        Return FechaPreparado
    '    End Get
    '    Set(ByVal value As Date)
    '        FechaPreparado = value
    '    End Set
    'End Property


    'Otras tablas

    Public Property gEstado() As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set
    End Property

    Public Property gnumSFactura() As List(Of Integer)
        Get
            Return numSFactura
        End Get
        Set(ByVal value As List(Of Integer))
            numSFactura = value
        End Set
    End Property

    Public Property gnumSDevolucion() As List(Of Integer)
        Get
            Return numSDevolucion
        End Get
        Set(ByVal value As List(Of Integer))
            numSDevolucion = value
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


    Public Property gMedioPago() As String
        Get
            Return MedioPago
        End Get
        Set(ByVal value As String)
            MedioPago = value
        End Set
    End Property

    Public Property gTipoPago() As String
        Get
            Return TipoPago
        End Get
        Set(ByVal value As String)
            TipoPago = value
        End Set
    End Property

    Public Property gBanco() As String
        Get
            Return Banco
        End Get
        Set(ByVal value As String)
            Banco = value
        End Set
    End Property

    Public Property gIBAN() As String
        Get
            Return IBAN
        End Get
        Set(ByVal value As String)
            IBAN = value
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

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
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

    Public Property gObservacionesCli() As String
        Get
            Return ObservacionesCli
        End Get
        Set(ByVal value As String)
            ObservacionesCli = value
        End Set
    End Property

    Public Property gnumSPedido() As List(Of Integer)
        Get
            Return numSPedido
        End Get
        Set(ByVal value As List(Of Integer))
            numSPedido = value
        End Set
    End Property


    Public Property gAgenciaTransporte() As String
        Get
            Return UCase(AgenciaTransporte)
        End Get
        Set(ByVal value As String)
            AgenciaTransporte = value
        End Set
    End Property


    Public Property gTipoValorado() As String
        Get
            Return UCase(TipoValorado)
        End Get
        Set(ByVal value As String)
            TipoValorado = value
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

    Public Property gProveedor() As String
        Get
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
        End Set
    End Property


    'Calculadas

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

    Public Property gTotalRE() As Double
        Get
            Return TotalRE
        End Get
        Set(ByVal value As Double)
            TotalRE = value
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
            Return ImporteDescuentos
        End Get
        Set(ByVal value As Double)
            ImporteDescuentos = value
        End Set
    End Property

    Public Property gsumaKilosBrutos() As Double
        Get
            Return sumaKilosBrutos
        End Get
        Set(ByVal value As Double)
            sumaKilosBrutos = value
        End Set
    End Property

    Public Property gsumaKilosNetos() As Double
        Get
            Return sumaKilosNetos
        End Get
        Set(ByVal value As Double)
            sumaKilosNetos = value
        End Set
    End Property

    Public Property gsumaVolumen() As Double
        Get
            Return sumaVolumen
        End Get
        Set(ByVal value As Double)
            sumaVolumen = value
        End Set
    End Property

    Public Property gsumaBultos() As Integer
        Get
            Return sumaBultos
        End Get
        Set(ByVal value As Integer)
            sumaBultos = value
        End Set
    End Property

    Public Function Clonar() As DatosAlbaran
        Dim dtsN As New DatosAlbaran
        dtsN.gAgenciaTransporte = AgenciaTransporte
        dtsN.gBanco = Banco
        dtsN.gBase = Base
        dtsN.gBultos = Bultos
        dtsN.gCliente = Cliente
        dtsN.gcodMoneda = codMoneda
        dtsN.gContacto = Contacto
        dtsN.gDescuento = Descuento
        dtsN.gDescuento2 = Descuento2
        dtsN.gDireccion = Direccion
        dtsN.gDivisa = Divisa
        dtsN.gEstado = Estado
        dtsN.gFecha = Fecha
        dtsN.gFechaEntrega = FechaEntrega
        'dtsN.gFechaPreparado = FechaPreparado
        dtsN.gIBAN = IBAN
        dtsN.gidCliente = idCliente
        dtsN.gidContacto = idContacto
        dtsN.gidCuentaBanco = idCuentaBanco
        dtsN.gidEstado = idEstado
        dtsN.gidMedioPago = idMedioPago
        dtsN.gidPersona = idPersona
        dtsN.gidProveedor = idProveedor
        dtsN.gidTipoIVA = idTipoIVA
        dtsN.gidTipoPago = idTipoPago
        dtsN.gidTipoRetencion = idTipoRetencion
        dtsN.gidTipoValorado = idTipoValorado
        dtsN.gidTransporte = idTransporte
        dtsN.gidUbicacion = idUbicacion
        dtsN.gImporteDescuentos = ImporteDescuentos
        dtsN.gImportePP = ImportePP
        dtsN.gKilosBrutos = KilosBrutos
        dtsN.gKilosNetos = KilosNetos
        dtsN.gMedidas = Medidas
        dtsN.gMedioPago = MedioPago
        dtsN.gNombreTipoIVA = NombreTipoIVA
        dtsN.gNombreTipoRetencion = NombreTipoRetencion
        dtsN.gNotas = Notas
        dtsN.gnumAlbaran = numAlbaran
        dtsN.gnumSDevolucion = numSDevolucion
        dtsN.gnumSFactura = numSFactura
        dtsN.gnumSPedido = numSPedido
        dtsN.gObservaciones = Observaciones
        dtsN.gObservacionesCli = ObservacionesCli
        dtsN.gPersona = Persona
        dtsN.gPortes = Portes
        dtsN.gPrecioTransporte = PrecioTransporte
        dtsN.gProntoPago = ProntoPago
        dtsN.gProveedor = Proveedor
        dtsN.gRecargoEquivalencia = RecargoEquivalencia
        dtsN.gRecogido = Recogido
        dtsN.gReferenciaCliente = ReferenciaCliente
        dtsN.gReferenciaCliente2 = ReferenciaCliente2
        dtsN.gRetencion = Retencion
        dtsN.gSimbolo = Simbolo
        dtsN.gSolicitadoVia = SolicitadoVia
        dtsN.gsumaBultos = sumaBultos
        dtsN.gsumaKilosBrutos = sumaKilosBrutos
        dtsN.gsumaKilosNetos = sumaKilosNetos
        dtsN.gsumaVolumen = sumaVolumen
        dtsN.gTipoIVA = TipoIVA
        dtsN.gTipoPago = TipoPago
        dtsN.gTipoRecargoEq = TipoRecargoEq
        dtsN.gTipoRetencion = TipoRetencion
        dtsN.gTipoValorado = TipoValorado
        dtsN.gTotal = Total
        dtsN.gTotalIVA = TotalIVA
        dtsN.gTotalRE = TotalRE
        dtsN.gTransporte = Transporte
        dtsN.gVolumen = Volumen

        Return dtsN
    End Function

    Public Sub New()
        numSFactura = New List(Of Integer)
        numSPedido = New List(Of Integer)
    End Sub

End Class

