Public Class DatosSubTipoArticulo

    Dim idSubTipoArticulo As Integer
    Dim idTipoArticulo As Integer
    Dim SubTipoArticulo As String
    Dim Descripcion As String
    Dim Activo As Boolean
    Dim Validacion As Boolean
    Private idAgrupacion As Integer

    Private Agrupacion As String


    Public Property gidSubTipoArticulo()
        Get
            Return idSubTipoArticulo
        End Get
        Set(ByVal value)
            idSubTipoArticulo = value
        End Set
    End Property

    Public Property gidTipoArticulo()
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gSubTipoArticulo()
        Get
            Return UCase(SubTipoArticulo)
        End Get
        Set(ByVal value)
            SubTipoArticulo = UCase(value)
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

    Public Property gValidacion()
        Get
            Return Validacion
        End Get
        Set(ByVal value)
            Validacion = value
        End Set
    End Property

    Public Property gidAgrupacion() As Integer
        Get
            Return idAgrupacion
        End Get
        Set(ByVal value As Integer)
            idAgrupacion = value
        End Set
    End Property

    Public Property gAgrupacion() As String
        Get
            Return Agrupacion
        End Get
        Set(ByVal value As String)
            Agrupacion = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return SubTipoArticulo
    End Function

End Class
