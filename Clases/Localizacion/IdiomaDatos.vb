Public Class datosIdioma

    Private idIdioma As Integer
    Private Idioma As String



    Public Property gidIdioma() As Integer
        Get
            Return idIdioma
        End Get
        Set(ByVal value As Integer)
            idIdioma = value
        End Set
    End Property

    Public Property gIdioma() As String
        Get
            Return Trim(UCase(Idioma))
        End Get
        Set(ByVal value As String)
            Idioma = Trim(UCase(value))
        End Set
    End Property


    Public Sub New(ByVal idIdioma As Integer, ByVal Idioma As String)
        gidIdioma = idIdioma
        gIdioma = Idioma

    End Sub

    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return Idioma
    End Function

End Class
