Public Class DatosEstatusReparacion

    Private idEstatus As Integer
    Private Estatus As String
    Private Descripcion As String
    Private Activo As Boolean




    Public Property gidEstatus()
        Get
            Return idEstatus
        End Get
        Set(ByVal value)
            idEstatus = value
        End Set
    End Property

    Public Property gEstatus()
        Get
            Return UCase(Estatus)
        End Get
        Set(ByVal value)
            Estatus = UCase(value)
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
        Return Estatus
    End Function

End Class
