Public Class DatosBanco

    
    Private idBanco As Integer
    Private codigoBanco As String
    Private Banco As String
    Private SWIFT_BIC As String
    Private Activo As Boolean
    Private idPais As Integer

    'Datos de otras tablas
    Private Pais As String


    Public Property gidBanco() As Integer
        Get
            Return idBanco
        End Get
        Set(ByVal value As Integer)
            idBanco = value
        End Set
    End Property

    Public Property gcodigoBanco() As String
        Get
            Return codigoBanco
        End Get
        Set(ByVal value As String)
            codigoBanco = value
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

    Public Property gSWIFT_BIC() As String
        Get
            Return UCase(SWIFT_BIC)
        End Get
        Set(ByVal value As String)
            SWIFT_BIC = UCase(value)
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

    Public Sub New(ByVal idBanco As Integer, ByVal codigoBanco As Integer, ByVal Banco As String, ByVal SWIFT_BIC As String, ByVal idPais As Integer, ByVal Activo As Boolean)

        gidBanco = idBanco
        gcodigoBanco = codigoBanco
        gBanco = Banco
        gSWIFT_BIC = SWIFT_BIC
        gidPais = idPais
        gActivo = Activo

    End Sub

    Public Sub New()

    End Sub

End Class
