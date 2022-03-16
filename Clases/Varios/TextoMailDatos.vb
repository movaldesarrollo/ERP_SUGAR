Public Class DatosTextoMail


    Private idTexto As Integer
    Private Documento As String
    Private idIdioma As Integer
    Private Texto As String
    Private Asunto As String

    Private Idioma As String


    Public Property gidTexto() As Integer
        Get
            Return idTexto
        End Get
        Set(ByVal value As Integer)
            idTexto = value
        End Set
    End Property

    Public Property gDocumento() As String
        Get
            Return UCase(Documento)
        End Get
        Set(ByVal value As String)
            Documento = UCase(value)
        End Set
    End Property

    Public Property gidIdioma() As Integer
        Get
            Return idIdioma
        End Get
        Set(ByVal value As Integer)
            idIdioma = value
        End Set
    End Property


    Public Property gTexto() As String
        Get
            Return Texto
        End Get
        Set(ByVal value As String)
            Texto = value
        End Set
    End Property

    Public Property gAsunto() As String
        Get
            Return Asunto
        End Get
        Set(ByVal value As String)
            Asunto = value
        End Set
    End Property

    Public Property gIdioma() As String
        Get
            Return UCase(Idioma)
        End Get
        Set(ByVal value As String)
            Idioma = UCase(value)
        End Set
    End Property

    Public Overrides Function ToString() As String

        Return Texto

    End Function

   

End Class
