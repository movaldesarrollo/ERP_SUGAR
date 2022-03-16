Public Class DatosSubFamilia

    Dim idSubFamilia As Integer
    Dim idFamilia As Integer
    Dim SubFamilia As String
    Dim Descripcion As String
    Dim Activo As Boolean
    Dim Validacion As Boolean


    Public Property gidSubFamilia()
        Get
            Return idSubFamilia
        End Get
        Set(ByVal value)
            idSubFamilia = value
        End Set
    End Property

    Public Property gidFamilia()
        Get
            Return idFamilia
        End Get
        Set(ByVal value)
            idFamilia = value
        End Set
    End Property

    Public Property gSubFamilia()
        Get
            Return UCase(SubFamilia)
        End Get
        Set(ByVal value)
            SubFamilia = UCase(value)
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

    Public Overrides Function ToString() As String
        Return SubFamilia
    End Function



End Class
