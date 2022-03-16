Public Class DatosCampoEtiqueta

    Private idEtiqueta As Integer
    Private idCampo As Integer
    Private NombreCampo As String
    Private ValorxDefecto As String
    Private esContador As Boolean
    Private esCodigo As Boolean
    Private ParametroTop As Integer = 0
    Private ParametroLeft As Integer = 0
    Private ParametroWidth As Integer = 0
    Private ParametroHeight As Integer = 0
    Private Fuente As String = ""
    Private ParametroSize As Single = 0
    Private Negrita As Boolean = False
    Private Italica As Boolean = False
    Private Visible As Boolean = True


    Public Property gidEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(ByVal value As Integer)
            idEtiqueta = value
        End Set
    End Property

    Public Property gidCampo() As Integer
        Get
            Return idCampo
        End Get
        Set(ByVal value As Integer)
            idCampo = value
        End Set
    End Property

    Public Property gNombreCampo() As String
        Get
            Return UCase(NombreCampo)
        End Get
        Set(ByVal value As String)
            NombreCampo = UCase(value)
        End Set
    End Property

    Public Property gValorxDefecto() As String
        Get
            Return ValorxDefecto
        End Get
        Set(ByVal value As String)
            ValorxDefecto = value
        End Set
    End Property

    Public Property gesContador() As Boolean
        Get
            Return esContador
        End Get
        Set(ByVal value As Boolean)
            esContador = value
        End Set
    End Property

    Public Property gesCodigo() As Boolean
        Get
            Return esCodigo
        End Get
        Set(ByVal value As Boolean)
            esCodigo = value
        End Set
    End Property

    Public Property gParametroTop() As Integer
        Get
            Return ParametroTop
        End Get
        Set(ByVal value As Integer)
            ParametroTop = value
        End Set
    End Property

    Public Property gParametroLeft() As Integer
        Get
            Return ParametroLeft
        End Get
        Set(ByVal value As Integer)
            ParametroLeft = value
        End Set
    End Property

    Public Property gParametroWidth() As Integer
        Get
            Return ParametroWidth
        End Get
        Set(ByVal value As Integer)
            ParametroWidth = value
        End Set
    End Property

    Public Property gParametroHeight() As Integer
        Get
            Return ParametroHeight
        End Get
        Set(ByVal value As Integer)
            ParametroHeight = value
        End Set
    End Property

    Public Property gFuente() As String
        Get
            Return Fuente
        End Get
        Set(ByVal value As String)
            Fuente = value
        End Set
    End Property

    Public Property gParametroSize() As Single
        Get
            Return ParametroSize
        End Get
        Set(ByVal value As Single)
            ParametroSize = value
        End Set
    End Property

    Public Property gNegrita() As Boolean
        Get
            Return Negrita
        End Get
        Set(ByVal value As Boolean)
            Negrita = value
        End Set
    End Property

    Public Property gItalica() As Boolean
        Get
            Return Italica
        End Get
        Set(ByVal value As Boolean)
            Italica = value
        End Set
    End Property

    Public Property gVisible() As Boolean
        Get
            Return Visible
        End Get
        Set(ByVal value As Boolean)
            Visible = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return NombreCampo
    End Function

    Public Sub New()

    End Sub

    Public Sub New(ByVal idEtiqueta As Integer, ByVal idCampo As Integer, ByVal ValorxDefecto As String)
        gidEtiqueta = idEtiqueta
        gidCampo = idCampo
        gValorxDefecto = ValorxDefecto
    End Sub

End Class
