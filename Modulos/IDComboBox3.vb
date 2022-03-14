Public Class IDComboBox3
    Private StrNombre1 As String
    Private StrNombre2 As String
    Private IntCodigo As String



    Public Sub New()

        StrNombre1 = ""
        StrNombre2 = ""
        IntCodigo = 0

    End Sub



    Public Sub New(ByVal Name1 As String, ByVal Name2 As String, ByVal ID As String)

        StrNombre1 = Name1
        StrNombre2 = Name2
        IntCodigo = ID

    End Sub



    Public Property Name1() As String
        Get
            Return StrNombre1
        End Get

        Set(ByVal sValue As String)
            StrNombre1 = sValue
        End Set

    End Property


    Public Property Name2() As String
        Get
            Return StrNombre2
        End Get

        Set(ByVal sValue As String)
            StrNombre2 = sValue
        End Set

    End Property

    Public Property ItemData() As String
        Get
            Return IntCodigo
        End Get

        Set(ByVal iValue As String)
            IntCodigo = iValue
        End Set

    End Property


    Public Overrides Function ToString() As String

        Return StrNombre2

    End Function


End Class
