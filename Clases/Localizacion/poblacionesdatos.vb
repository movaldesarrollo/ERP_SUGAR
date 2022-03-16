Public Class datospoblacion

    Dim idPoblacion As Integer
    Dim idProvincia As Integer
    Dim poblacion As String
    Dim postal As Integer

    Public Property gidPoblacion()
        Get
            Return idPoblacion
        End Get
        Set(ByVal value)
            idPoblacion = value
        End Set
    End Property
    Public Property gidProvincia()
        Get
            Return idProvincia
        End Get
        Set(ByVal value)
            idProvincia = value
        End Set
    End Property
    Public Property gPostal()
        Get
            Return postal
        End Get
        Set(ByVal value)
            postal = value
        End Set
    End Property
    Public Property gPoblacion()
        Get
            Return UCase(poblacion)
        End Get
        Set(ByVal value)
            poblacion = UCase(value)
        End Set
    End Property
    Public Sub New(ByVal idPoblacion As Integer, ByVal idProvincia As Integer, ByVal poblacion As String, ByVal postal As Integer)
        gidPoblacion = idPoblacion
        gidProvincia = idProvincia
        gPoblacion = poblacion
        gPostal = postal

    End Sub
    Public Sub New()

    End Sub
End Class
