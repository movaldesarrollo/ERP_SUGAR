Public Class ParEtiquetaImagen
    Private StrNombre As String
    Private iImagen As Image



    Public Sub New()

        StrNombre = ""

        iImagen = Nothing

    End Sub



    Public Sub New(ByVal Etiqueta As String, ByVal imagen As Image)

        StrNombre = Etiqueta

        iImagen = imagen

    End Sub



    Public Property Etiqueta() As String

        Get

            Return StrNombre

        End Get



        Set(ByVal sValue As String)

            StrNombre = sValue

        End Set

    End Property



    Public Property Imagen() As Image

        Get

            Return iImagen

        End Get



        Set(ByVal iValue As Image)

            iImagen = iValue

        End Set

    End Property



    Public Overrides Function ToString() As String

        Return StrNombre

    End Function



End Class
