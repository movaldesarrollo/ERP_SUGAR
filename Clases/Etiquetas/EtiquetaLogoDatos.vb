Public Class DatosEtiquetaLogo

    Private idEtiqueta As Integer
    Private idLogo As Integer
    Private NombreCampo As String
    Private Logo As Image
    Private ParametroTop As Integer
    Private ParametroLeft As Integer
    Private ParametroWidth As Integer
    Private ParametroHeight As Integer
    Private Visible As Boolean = True



    Public Property gidEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(ByVal value As Integer)
            idEtiqueta = value
        End Set
    End Property


    Public Property gidLogo() As Integer
        Get
            Return idLogo
        End Get
        Set(ByVal value As Integer)
            idLogo = value
        End Set
    End Property

    Public Property gNombreCampo() As String
        Get
            Return NombreCampo
        End Get
        Set(ByVal value As String)
            NombreCampo = value
        End Set
    End Property


    Public Property gLogo() As Image
        Get
            Return Logo
        End Get
        Set(ByVal value As Image)
            Logo = value
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

    Public Property gVisible() As Boolean
        Get
            Return Visible
        End Get
        Set(ByVal value As Boolean)
            Visible = value
        End Set
    End Property
   


End Class
