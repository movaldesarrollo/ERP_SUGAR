Public Class DatosAlbaranProv

    Private idAlbaran As Integer
    Private numAlbaran As String = ""
    Private idProveedor As Integer = 0
    Private idUbicacion As Integer = 0
    Private idFactura As Integer = 0
    Private Fecha As Date
    Private Referencia As String = ""
    Private SolicitadoVia As String = ""
    Private idContacto As Integer = 0
    Private Observaciones As String = ""
    Private Notas As String = ""
    Private idTipoValorado As Integer = 0
    Private idEstado As Integer = 0
    Private idTipoRetencion As Integer = 0
    Private RecargoEquivalencia As Boolean = False
    Private ProntoPago As Double
    Private codMoneda As String
    Private idPersona As Integer
    Private PrecioTransporte As Double
    Private Portes As Char
    Private Bultos As Integer
    Private idTransporte As Integer
    Private Transporte As String

    'Datos de otras tablas
    Private Estado As String = ""
    Private Proveedor As String = ""
    Private Contacto As String = ""
    Private ObservacionesProv As String = ""
    Private Simbolo As String
    Private Divisa As String
    Private Persona As String
    Private Direccion As String
    Private TipoValorado As String
    Private AgenciaTransporte As String


    'Datos calculados
    Private Base As Double
    Private TotalIVA As Double
    Private TotalRE As Double
    Private TipoRetencion As Double
    Private Retencion As Double
    Private Total As Double
    Private ImportePP As Double 'Importe del descuento Pronto Pago
    Private Facturas As List(Of IDComboBox)
    Private numSPedido As List(Of Integer)

    Public Property gidAlbaran() As Integer
        Get
            Return idAlbaran
        End Get
        Set(ByVal value As Integer)
            idAlbaran = value
        End Set
    End Property

    Public Property gnumAlbaran() As String
        Get
            Return UCase(numAlbaran)
        End Get
        Set(ByVal value As String)
            numAlbaran = UCase(value)
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

    Public Property gidUbicacion() As Integer
        Get
            Return idUbicacion
        End Get
        Set(ByVal value As Integer)
            idUbicacion = value
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

    Public Property gFecha() As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property

    Public Property gReferencia() As String
        Get
            Return Referencia
        End Get
        Set(ByVal value As String)
            Referencia = value
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

    Public Property gidContacto() As Integer
        Get
            Return idContacto
        End Get
        Set(ByVal value As Integer)
            idContacto = value
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


    Public Property gNotas() As String
        Get
            Return Notas
        End Get
        Set(ByVal value As String)
            Notas = value
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

    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
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


    Public Property gBultos() As Integer
        Get
            Return Bultos
        End Get
        Set(ByVal value As Integer)
            Bultos = value
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
            Return UCase(Transporte)
        End Get
        Set(ByVal value As String)
            Transporte = UCase(value)
        End Set
    End Property

    'Otras tablas

    Public Property gEstado() As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set
    End Property


    Public Property gProveedor() As String
        Get
            Return UCase(Proveedor)
        End Get
        Set(ByVal value As String)
            Proveedor = UCase(value)
        End Set
    End Property


    Public Property gContacto() As String
        Get
            Return UCase(Contacto)
        End Get
        Set(ByVal value As String)
            Contacto = UCase(value)
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

    Public Property gSimbolo() As String
        Get
            Return UCase(Simbolo)
        End Get
        Set(ByVal value As String)
            Simbolo = UCase(value)
        End Set
    End Property

    Public Property gDivisa() As String
        Get
            Return UCase(Divisa)
        End Get
        Set(ByVal value As String)
            Divisa = UCase(value)
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

    Public Property gDireccion() As String
        Get
            Return Direccion
        End Get
        Set(ByVal value As String)
            Direccion = value
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


    Public Property gAgenciaTransporte() As String
        Get
            Return AgenciaTransporte
        End Get
        Set(ByVal value As String)
            AgenciaTransporte = value
        End Set
    End Property



    'Datos  calculados

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

    Public Property gTipoRetencion() As Double
        Get
            Return TipoRetencion
        End Get
        Set(ByVal value As Double)
            TipoRetencion = value
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

    Public Property gImportePP() As Double
        Get
            Return ImportePP
        End Get
        Set(ByVal value As Double)
            ImportePP = value
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

    Public Property gFacturas() As List(Of IDComboBox)
        Get
            Return Facturas
        End Get
        Set(ByVal value As List(Of IDComboBox))
            Facturas = value
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

End Class

