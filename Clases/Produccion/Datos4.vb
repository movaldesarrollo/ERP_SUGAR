Public Class Datos4

    Private id As Integer
    Private Dato1 As String
    Private Dato2 As String
    Private Dato3 As String

    Public Property gid() As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property


    Public Property gDato1() As String
        Get
            Return Dato1
        End Get
        Set(ByVal value As String)
            Dato1 = value
        End Set
    End Property

    Public Property gDato2() As String
        Get
            Return Dato2
        End Get
        Set(ByVal value As String)
            Dato2 = value
        End Set
    End Property

    Public Property gDato3() As String
        Get
            Return Dato3
        End Get
        Set(ByVal value As String)
            Dato3 = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Dato1
    End Function

    Public Sub New()

    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Dato1 As String, ByVal Dato2 As String, ByVal Dato3 As String)
        gid = ID
        gDato1 = Dato1
        gDato2 = Dato2
        gDato3 = Dato3
    End Sub

End Class
