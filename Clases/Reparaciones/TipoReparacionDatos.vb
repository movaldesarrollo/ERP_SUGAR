Public Class DatosTipoReparacion

    Private idTipoReparacion As Integer
    Private TipoReparacion As String
    Private Descripcion As String
    Private Activo As Boolean




    Public Property gidTipoReparacion()
        Get
            Return idTipoReparacion
        End Get
        Set(ByVal value)
            idTipoReparacion = value
        End Set
    End Property

    Public Property gTipoReparacion()
        Get
            Return UCase(TipoReparacion)
        End Get
        Set(ByVal value)
            TipoReparacion = UCase(value)
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

    Public Property gActivo()
        Get
            Return Activo
        End Get
        Set(ByVal value)
            Activo = value
        End Set
    End Property

  

    Public Overrides Function ToString() As String
        Return TipoReparacion
    End Function

End Class
