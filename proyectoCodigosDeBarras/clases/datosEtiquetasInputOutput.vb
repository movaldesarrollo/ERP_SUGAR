Public Class datosEtiquetasInputOutput

#Region "VARIABLES"

    Dim idArticulo As Integer
    Dim inputText As String
    Dim outputText As String
    Dim web As String
    Dim pieEtiqueta As String

#End Region

#Region "PROPIEDADES"

    Property pIdArticulo As Integer
        Get
            Return idArticulo
        End Get
        Set(value As Integer)
            idArticulo = value
        End Set
    End Property

    Property pInputText() String
        Get
            Return inputText
        End Get
        Set(value)
            inputText = value
        End Set
    End Property

    Property pOutputText() String
        Get
            Return outputText
        End Get
        Set(value)
            outputText = value
        End Set
    End Property

    Property pPieEtiqueta() String
        Get
            Return pieEtiqueta
        End Get
        Set(value)
            pieEtiqueta = value
        End Set
    End Property

    Property pWeb() String
        Get
            Return web
        End Get
        Set(value)
            web = value
        End Set
    End Property

#End Region

End Class
