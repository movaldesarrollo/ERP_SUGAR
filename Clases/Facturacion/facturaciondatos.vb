Public Class datosfacturacion
    Private idFacturacion As Integer
    Private idProveedor As Integer
    Private idCliente As Integer
    Private idMedioPago As Integer
    Private idTipoPago As Integer
    Private DiaPago1 As Integer
    Private DiaPago2 As Integer
    'Private AlbaranValorado As Boolean
    Private ExentoPagosAgosto As Boolean
    Private Observaciones As String
    Private envioCorreo As Boolean
    Private medioEntrega As String
    Private Transporte As Double
    Private codMoneda As String
    Private Descuento As Double
    Private Descuento2 As Double
    Private ProntoPago As Double
    Private idTipoIVA As Double
    Private idTipoRetencion As Double
    Private RecargoEquivalencia As Boolean
    Private idTipoValorado As Integer
    Private Cuentas As List(Of DatosCuentaBancaria)
    'Campos de otras tablas
    Private TipoPago As String
    Private MedioPago As String
    Private Divisa As String
    Private Simbolo As String
    Private TipoIVA As Double
    Private NombreTipoIVA As String
    Private TipoRecargoEq As Double
    Private TipoRetencion As Double
    Private NombreTipoRet As String
    Private TipoValorado As String

    Public Property gidFacturacion() As Integer
        Get
            Return idFacturacion
        End Get
        Set(ByVal value As Integer)
            idFacturacion = value
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

    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
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

    Public Property gDiaPago1() As Integer
        Get
            Return DiaPago1
        End Get
        Set(ByVal value As Integer)
            DiaPago1 = value
        End Set
    End Property

    Public Property gDiaPago2() As Integer
        Get
            Return DiaPago2
        End Get
        Set(ByVal value As Integer)
            DiaPago2 = value
        End Set
    End Property

    'Public Property gAlbaranValorado() As Boolean
    '    Get
    '        Return AlbaranValorado
    '    End Get
    '    Set(ByVal value As Boolean)
    '        AlbaranValorado = value
    '    End Set
    'End Property

    Public Property gExentoPagosAgosto() As Boolean
        Get
            Return ExentoPagosAgosto
        End Get
        Set(ByVal value As Boolean)
            ExentoPagosAgosto = value
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

    Public Property genvioCorreo() As Boolean
        Get
            Return envioCorreo
        End Get
        Set(ByVal value As Boolean)
            envioCorreo = value
        End Set
    End Property

    Public Property gmedioEntrega() As String
        Get
            Return UCase(medioEntrega)
        End Get
        Set(ByVal value As String)
            medioEntrega = UCase(value)
        End Set
    End Property

    Public Property gTransporte() As Double
        Get
            Return Transporte
        End Get
        Set(ByVal value As Double)
            Transporte = value
        End Set
    End Property

    Public Property gcodMoneda() As String
        Get
            Return UCase(codMoneda)
        End Get
        Set(ByVal value As String)
            codMoneda = UCase(value)
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

    Public Property gidTipoValorado() As Integer
        Get
            Return idTipoValorado
        End Get
        Set(ByVal value As Integer)
            idTipoValorado = value
        End Set
    End Property

    Public Property gCuentas() As List(Of DatosCuentaBancaria)
        Get
            Return Cuentas
        End Get
        Set(ByVal value As List(Of DatosCuentaBancaria))
            Cuentas = value
        End Set
    End Property

    Public Property gTipoPago() As String
        Get
            Return UCase(TipoPago)
        End Get
        Set(ByVal value As String)
            TipoPago = UCase(value)
        End Set
    End Property

    Public Property gMedioPago() As String
        Get
            Return UCase(MedioPago)
        End Get
        Set(ByVal value As String)
            MedioPago = UCase(value)
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
            Return UCase(NombreTipoIVA)
        End Get
        Set(ByVal value As String)
            NombreTipoIVA = UCase(value)
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

    Public Property gNombreTipoRet() As String
        Get
            Return UCase(NombreTipoRet)
        End Get
        Set(ByVal value As String)
            NombreTipoRet = UCase(value)
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

    Public Sub New()
        If codMoneda = "" Then codMoneda = "EU"
        If Simbolo = "" Then Simbolo = "€"
        If Divisa = "" Then Divisa = "EURO"
        If NombreTipoRet = "" Then NombreTipoRet = "EXENTO"
    End Sub

End Class
