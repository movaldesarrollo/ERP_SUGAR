Public Class DatosFacturaProv

    Private idFactura As Integer
    Private numFactura As String = ""
    Private idProveedor As Integer = 0
    Private idUbicacion As Integer = 0
    Private Referencia As String = ""
    Private idEstado As Integer = 0
    Private Fecha As Date
    Private Observaciones As String = ""
    Private Notas As String = ""
    Private idContacto As Integer = 0
    Private idMedioPago As Integer = 0
    Private idTipoPago As Integer = 0
    Private idCuentaBanco As Integer = 0
    Private codMoneda As String = "EU"

    Private idTipoRetencion As Integer
    Private RecargoEquivalencia As Boolean
    Private ProntoPago As Double
    Private TipoRetencionFac As Double
 
    Private PrecioTransporte As Double
    Private solicitadoVia As String
    Private codFactura As String
    Private idPersona As Integer
    Private idTipoIVATransporte As Integer
    Private TipoIVATransporte As Double
    Private TipoRecargoEqTransporte As Double

    'Datos de otras tablas
    Private Estado As String = ""
    Private Proveedor As String = ""
    Private Contacto As String = ""
    Private ObservacionesProv As String = ""
    Private MedioPago As String
    Private TipoPago As String
    Private Banco As String
    Private IBAN As String
    Private Divisa As String
    Private Simbolo As String
    Private Direccion As String
    Private Persona As String
  
    Private TipoRetencion As Double
    Private NombreTipoRetencion As String
    Private Albaranes As List(Of IDComboBox)
    Private Vencimientos As List(Of DatosVencimientoProv)
    Private ImportesIVA As List(Of DatosImportesIVAProv)

    'Datos calculados
    Private ImportePP As Double
    Private Base As Double
    Private TotalIVA As Double
    Private TotalRE As Double
    Private Retencion As Double
    Private Total As Double
    Private Pendiente As Double 'Importe pendiente de pago (calculado desde los vencimientos)
    Private PrimerVencimientoNoPagado As Date



    Public Property gidFactura() As Integer
        Get
            Return idFactura
        End Get
        Set(ByVal value As Integer)
            idFactura = value
        End Set
    End Property

    Public Property gnumFactura() As String
        Get
            Return UCase(numFactura)
        End Get
        Set(ByVal value As String)
            numFactura = UCase(value)
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

    Public Property gReferencia() As String
        Get
            Return Referencia
        End Get
        Set(ByVal value As String)
            Referencia = value
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

    'Public Property gidTipoIVA() As Integer
    '    Get
    '        Return idTipoIVA
    '    End Get
    '    Set(ByVal value As Integer)
    '        idTipoIVA = value
    '    End Set
    'End Property

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

    Public Property gTipoRetencionFac() As Double
        Get
            Return TipoRetencionFac
        End Get
        Set(ByVal value As Double)
            TipoRetencionFac = value
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

    Public Property gSolicitadoVia() As String
        Get
            Return solicitadoVia
        End Get
        Set(ByVal value As String)
            solicitadoVia = value
        End Set
    End Property

    Public Property gcodFactura() As String
        Get
            Return codFactura
        End Get
        Set(ByVal value As String)
            codFactura = value
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

    Public Property gidTipoIVATransporte() As Integer
        Get
            Return idTipoIVATransporte
        End Get
        Set(ByVal value As Integer)
            idTipoIVATransporte = value
        End Set
    End Property


    Public Property gTipoIVATransporte() As Double
        Get
            Return TipoIVATransporte
        End Get
        Set(ByVal value As Double)
            TipoIVATransporte = value
        End Set
    End Property

    Public Property gTipoRecargoEqTransporte() As Double
        Get
            Return TipoRecargoEqTransporte
        End Get
        Set(ByVal value As Double)
            TipoRecargoEqTransporte = value
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
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
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

    Public Property gDireccion() As String
        Get
            Return Direccion
        End Get
        Set(ByVal value As String)
            Direccion = value
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

    'Public Property gTipoIVA() As Double
    '    Get
    '        Return TipoIVA
    '    End Get
    '    Set(ByVal value As Double)
    '        TipoIVA = value
    '    End Set
    'End Property

    'Public Property gNombreTipoIVA() As String
    '    Get
    '        Return NombreTipoIVA
    '    End Get
    '    Set(ByVal value As String)
    '        NombreTipoIVA = value
    '    End Set
    'End Property

    'Public Property gTipoRecargoEq() As Double
    '    Get
    '        Return TipoRecargoEq
    '    End Get
    '    Set(ByVal value As Double)
    '        TipoRecargoEq = value
    '    End Set
    'End Property

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

    Public Property gAlbaranes() As List(Of IDComboBox)
        Get
            Return Albaranes
        End Get
        Set(ByVal value As List(Of IDComboBox))
            Albaranes = value
        End Set
    End Property

    Public Property gVencimientos() As List(Of DatosVencimientoProv)
        Get
            Return Vencimientos
        End Get
        Set(ByVal value As List(Of DatosVencimientoProv))
            Vencimientos = value
        End Set
    End Property

    Public Property gImportesIVA() As List(Of DatosImportesIVAProv)
        Get
            Return ImportesIVA
        End Get
        Set(ByVal value As List(Of DatosImportesIVAProv))
            ImportesIVA = value
        End Set
    End Property

    'Datos calculados

    Public Property gImportePP() As Double
        Get
            Return ImportePP
        End Get
        Set(ByVal value As Double)
            ImportePP = value
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

    Public Property gPendiente() As Double
        Get
            Return Pendiente
        End Get
        Set(ByVal value As Double)
            Pendiente = value
        End Set
    End Property

    Public Property gPrimerVencimientoNoPagado() As Date
        Get
            Return PrimerVencimientoNoPagado
        End Get
        Set(ByVal value As Date)
            PrimerVencimientoNoPagado = value
        End Set
    End Property
   

End Class

