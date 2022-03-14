Public Class DatosEtiquetaLinea


    Private idEtiqueta As Integer
    Private idCampo As Integer
    Private NombreCampo As String
    Private ParametroTop As Integer = 0
    Private ParametroLeft As Integer = 0
    Private ParametroRight As Integer = 0
    Private ParametroThickness As Integer = 0
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
            Return NombreCampo
        End Get
        Set(ByVal value As String)
            NombreCampo = value
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


    Public Property gParametroRight() As Integer
        Get
            Return ParametroRight
        End Get
        Set(ByVal value As Integer)
            ParametroRight = value
        End Set
    End Property

    Public Property gParametroThickness() As Integer
        Get
            Return ParametroThickness
        End Get
        Set(ByVal value As Integer)
            ParametroThickness = value
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

   

End Class
