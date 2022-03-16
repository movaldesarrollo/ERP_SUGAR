Public Class DatosAgrupacionArticulo

    Private idAgrupacion As Integer
    Private Agrupacion As String
    Private Descripcion As String



    Public Property gidAgrupacion()
        Get
            Return idAgrupacion
        End Get
        Set(ByVal value)
            idAgrupacion = value
        End Set
    End Property

    Public Property gAgrupacion()
        Get
            Return UCase(Agrupacion)
        End Get
        Set(ByVal value)
            Agrupacion = UCase(value)
        End Set
    End Property

    Public Property gDescripcion()
        Get
            Return Descripcion
        End Get
        Set(ByVal value)
            Descripcion = value
        End Set
    End Property

   

    Public Overrides Function ToString() As String
        Return Agrupacion
    End Function

End Class
