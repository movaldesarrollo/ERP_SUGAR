Public Class datosProvincia
    Dim idProvincia As Integer
    Dim provincia As String

    Public Property gidProvincia()
        Get
            Return idProvincia
        End Get
        Set(ByVal value)
            idProvincia = value
        End Set
    End Property

    Public Property gProvincia()
        Get
            Return UCase(provincia)
        End Get
        Set(ByVal value)
            provincia = UCase(value)
        End Set
    End Property
    Public Sub New(ByVal idProvincia As Integer, ByVal provincia As String)
        gidProvincia = idProvincia
        gProvincia = provincia

    End Sub
    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return UCase(provincia)
    End Function

End Class
