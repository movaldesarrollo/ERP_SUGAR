Public Class datosAviso

    Private idAviso As Integer
    Private TipoAviso As String
    Private Aplicacion As String
    Private numDoc As Integer
    Private FechaPropuesta As Date
    Private Explicacion As String
    Private Enviado As Boolean
    Private idCreador As Integer

    Private Creador As String



    Public Property gidAviso() As Integer
        Get
            Return idAviso
        End Get
        Set(ByVal value As Integer)
            idAviso = value
        End Set
    End Property


    Public Property gTipoAviso() As String
        Get
            Return TipoAviso
        End Get
        Set(ByVal value As String)
            TipoAviso = value
        End Set
    End Property

    Public Property gAplicacion() As String
        Get
            Return Aplicacion
        End Get
        Set(ByVal value As String)
            Aplicacion = value
        End Set
    End Property


    Public Property gnumDoc() As Integer
        Get
            Return numDoc
        End Get
        Set(ByVal value As Integer)
            numDoc = value
        End Set
    End Property

    Public Property gFechaPropuesta() As Date
        Get
            Return FechaPropuesta
        End Get
        Set(ByVal value As Date)
            FechaPropuesta = value
        End Set
    End Property

    Public Property gExplicacion() As String
        Get
            Return Explicacion
        End Get
        Set(ByVal value As String)
            Explicacion = value
        End Set
    End Property

    Public Property gEnviado() As Boolean
        Get
            Return Enviado
        End Get
        Set(ByVal value As Boolean)
            Enviado = value
        End Set
    End Property

    Public Property gidCreador() As Integer
        Get
            Return idCreador
        End Get
        Set(ByVal value As Integer)
            idCreador = value
        End Set
    End Property

    Public Property gCreador() As String
        Get
            Return UCase(Creador)
        End Get
        Set(ByVal value As String)
            Creador = UCase(value)
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return TipoAviso & " " & Aplicacion & " " & numDoc
    End Function


End Class
