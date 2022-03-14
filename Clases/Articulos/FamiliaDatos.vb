Public Class DatosFamilia

    Dim idFamilia As Integer
    Dim Familia As String
    Dim Descripcion As String
    Dim Activo As Boolean
    Dim Validacion As Boolean



    Public Property gidFamilia()
        Get
            Return idFamilia
        End Get
        Set(ByVal value)
            idFamilia = value
        End Set
    End Property

    Public Property gFamilia()
        Get
            Return UCase(Familia)
        End Get
        Set(ByVal value)
            Familia = UCase(value)
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
        Return Familia
    End Function


End Class
