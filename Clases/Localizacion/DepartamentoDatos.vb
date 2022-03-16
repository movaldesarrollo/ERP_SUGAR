Public Class datosDepartamento

    Dim idDepartamento As String
    Dim Departamento As String

    Public Property gidDepartamento()
        Get
            Return idDepartamento
        End Get
        Set(ByVal value)
            idDepartamento = value
        End Set
    End Property

    Public Property gDepartamento()
        Get
            Return UCase(Departamento)
        End Get
        Set(ByVal value)
            Departamento = UCase(value)
        End Set
    End Property

    Public Sub New(ByVal Departamento As String)
        gDepartamento = Departamento
    End Sub

    Public Sub New()

    End Sub

End Class
