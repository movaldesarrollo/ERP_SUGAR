Public Class DatosSeccion

    Private idSeccion As Integer
    Private Seccion As String
    Private Descripcion As String
    Private Activo As Boolean
    Private PrecioHora As Double
    Private Orden As Integer
    Private Vista As String



    Public Property gidSeccion() As Integer
        Get
            Return idSeccion
        End Get
        Set(ByVal value As Integer)
            idSeccion = value
        End Set
    End Property

    Public Property gSeccion() As String
        Get
            Return UCase(Seccion)
        End Get
        Set(ByVal value As String)
            Seccion = UCase(value)
        End Set
    End Property

    Public Property gDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
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


    Public Property gPrecioHora() As Double
        Get
            Return PrecioHora
        End Get
        Set(ByVal value As Double)
            PrecioHora = value
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


    Public Property gVista() As String
        Get
            Return Vista
        End Get
        Set(ByVal value As String)
            Vista = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal Seccion As String, ByVal Descripcion As String, ByVal PrecioHora As Double, ByVal Orden As Integer, ByVal Vista As String, ByVal Activo As Boolean)
        gSeccion = Seccion
        gDescripcion = Descripcion
        gActivo = Activo
        gPrecioHora = PrecioHora
        gVista = Vista
        gOrden = Orden
    End Sub

    Public Overrides Function ToString() As String
        Return Seccion
    End Function

End Class
