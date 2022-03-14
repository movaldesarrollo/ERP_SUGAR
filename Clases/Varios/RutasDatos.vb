Public Class DatosRuta

    Private IdAplicacion As Integer
    Private Aplicacion As String
    Private Observaciones As String
    Private Ruta As String




    Public Property gIdAplicacion() As Integer
        Get
            Return IdAplicacion
        End Get
        Set(ByVal value As Integer)
            IdAplicacion = value
        End Set
    End Property


    Public Property gAplicacion() As String
        Get
            Return UCase(Aplicacion)
        End Get
        Set(ByVal value As String)
            Aplicacion = Ucase(value)
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

    Public Property gRuta() As String
        Get
            Return UCase(Ruta)
        End Get
        Set(ByVal value As String)
            Ruta = UCase(value)
        End Set
    End Property

    Public Sub New()

    End Sub


    Public Sub New(ByVal Aplicacion As String, ByVal Ruta As String, ByVal Observaciones As String)
        gAplicacion = Aplicacion
        gRuta = Ruta
        gObservaciones = Observaciones
    End Sub


    Public Overrides Function ToString() As String
        Return UCase(Ruta)
    End Function


End Class
