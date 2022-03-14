Public Class DatosCuentaBancaria

    Private idCuentaBanco As Integer
    Private idFacturacion As Integer
    Private idBanco As Integer
    Private CodigoEU As String
    Private CodigoBanco As String
    Private CodigoOficina As String
    Private CodigoDC As String
    Private CodigoCuenta As String
    Private IBAN As String
    Private SWIFT_BIC As String
    Private Orden As Integer
    Private Activo As Boolean
    Private Nombre As String = ""
    'Datos otras tablas
    Private Banco As String
    Private idPais As Integer
    Private Pais As String

    Public Property gidCuentaBanco() As Integer
        Get
            Return idCuentaBanco
        End Get
        Set(ByVal value As Integer)
            idCuentaBanco = value
        End Set
    End Property

    Public Property gidFacturacion() As Integer
        Get
            Return idFacturacion

        End Get
        Set(ByVal value As Integer)
            idFacturacion = value
        End Set
    End Property

    Public Property gidBanco() As Integer
        Get
            Return idBanco
        End Get
        Set(ByVal value As Integer)
            idBanco = value
        End Set
    End Property

    Public Property gCodigoEU() As String
        Get
            Return CodigoEU
        End Get
        Set(ByVal value As String)
            CodigoEU = value
        End Set
    End Property

    Public Property gCodigoBanco() As String
        Get
            Return CodigoBanco
        End Get
        Set(ByVal value As String)
            CodigoBanco = value
        End Set
    End Property

    Public Property gCodigoOficina() As String
        Get
            Return CodigoOficina
        End Get
        Set(ByVal value As String)
            CodigoOficina = value
        End Set
    End Property

    Public Property gCodigoDC() As String
        Get
            Return CodigoDC
        End Get
        Set(ByVal value As String)
            CodigoDC = value
        End Set
    End Property

    Public Property gCodigoCuenta() As String
        Get
            Return CodigoCuenta
        End Get
        Set(ByVal value As String)
            CodigoCuenta = value
        End Set
    End Property

    Public Property gIBAN() As String
        Get
            Return UCase(IBAN)
        End Get
        Set(ByVal value As String)
            IBAN = UCase(value)
        End Set
    End Property

    Public Property gSWIFT_BIC() As String
        Get
            Return UCase(SWIFT_BIC)
        End Get
        Set(ByVal value As String)
            SWIFT_BIC = UCase(value)
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

    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property gBanco() As String
        Get
            Return UCase(Banco)
        End Get
        Set(ByVal value As String)
            Banco = UCase(value)
        End Set
    End Property

    Public Property gidPais() As Integer
        Get
            Return idPais
        End Get
        Set(ByVal value As Integer)
            idPais = value
        End Set
    End Property

    Public Property gPais() As String
        Get
            Return Pais
        End Get
        Set(ByVal value As String)
            Pais = value
        End Set
    End Property

    Public Property gNombre() As String
        Get
            Return UCase(Nombre)
        End Get
        Set(ByVal value As String)
            Nombre = UCase(value)
        End Set
    End Property

    Public Property gNombreCompleto() As String
        Get
            If Nombre = "" Then
                Return IBAN
            Else
                Return UCase(Nombre) & ": " & IBAN
            End If
        End Get
        Set(ByVal value As String)

        End Set
    End Property

End Class
