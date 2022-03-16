Public Class DatosFestivo

    Private Fecha As Date
    Private Festividad As String
    Private Repetir As Boolean




    Public Property gFecha() As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property
  

    Public Property gFestividad() As String
        Get
            Return UCase(Festividad)
        End Get
        Set(ByVal value As String)
            Festividad = UCase(value)
        End Set
    End Property


    Public Property gRepetir() As Boolean
        Get
            Return Repetir
        End Get
        Set(ByVal value As Boolean)
            Repetir = value
        End Set
    End Property


    Public Sub New()

    End Sub


    Public Sub New(ByVal Fecha As Date, ByVal Festividad As String, ByVal Repetir As Boolean)
        gFecha = Fecha
        gFestividad = Festividad
        gRepetir = Repetir
    End Sub


    Public Overrides Function ToString() As String
        Return CStr(Fecha)
    End Function


End Class
