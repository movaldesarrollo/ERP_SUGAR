Public Class DatosTiempoEscandallo

    Private idTiempo As Long
    Private idEscandallo As Integer
    Private idSeccion As Integer
    Private Horas As Double
    Private PrecioHora As Double
    Private Observaciones As String
    Private Orden As Integer
    Private Activo As Boolean

    'Datos de otras tablas
   
    Private Seccion As String
    Private codMoneda As String
    Private simbolo As String
   

    Public Property gidTiempo() As Long
        Get
            Return idTiempo
        End Get
        Set(ByVal value As Long)
            idTiempo = value
        End Set
    End Property


    Public Property gidEscandallo() As Integer
        Get
            Return idEscandallo
        End Get
        Set(ByVal value As Integer)
            idEscandallo = value
        End Set
    End Property


    Public Property gidSeccion() As Integer
        Get
            Return idSeccion
        End Get
        Set(ByVal value As Integer)
            idSeccion = value
        End Set
    End Property



    Public Property gHoras() As Double
        Get
            Return Horas
        End Get
        Set(ByVal value As Double)
            Horas = value
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



    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
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



   
   



    Public Property gSeccion() As String
        Get
            Return Seccion
        End Get
        Set(ByVal value As String)
            Seccion = value
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

    Public Property gsimbolo() As String
        Get
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property

    

   

End Class
