Public Class datosPais
    Private idPais As Integer
    Private Pais As String
    Private codMoneda As String
    Private NIFObligatorio As Boolean
    Private codPais As String
    Private Exportacion As Boolean

    Private Divisa As String


    Public Property gNIFObligatorio() As Boolean
        Get
            Return NIFObligatorio
        End Get
        Set(ByVal value As Boolean)
            NIFObligatorio = value
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
            Return Trim(UCase(Pais))
        End Get
        Set(ByVal value As String)
            Pais = Trim(UCase(value))
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

    Public Property gcodPais() As String
        Get
            Return codPais
        End Get
        Set(ByVal value As String)
            codPais = value
        End Set
    End Property

    Public Property gExportacion() As Boolean
        Get
            Return Exportacion
        End Get
        Set(ByVal value As Boolean)
            Exportacion = value
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


    Public Sub New(ByVal idPais As Integer, ByVal Pais As String, ByVal codMoneda As String, ByVal NIFObligatorio As Boolean, ByVal codPais As String, ByVal Exportacion As Boolean, ByVal Divisa As String)
        gidPais = idPais
        gPais = Pais
        gcodMoneda = codMoneda
        gNIFObligatorio = NIFObligatorio
        gcodPais = codPais
        gExportacion = Exportacion
        gDivisa = Divisa
    End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return Pais
    End Function

End Class
