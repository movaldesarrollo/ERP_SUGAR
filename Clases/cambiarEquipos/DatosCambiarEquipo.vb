Public Class DatosCambiarEquipo

    Dim pIdArticulo As Integer
    Dim pCodArticulo As String
    Dim pNumSerie As String
    Dim pEtiquetaImpresa As Boolean
    Dim pEtiquetaImpresaFinal As Boolean


    Public Sub New()
    End Sub

    Public Sub New(idArticulo As Integer, codArticulo As String, numSerie As String)
        Me.pIdArticulo = idArticulo
        Me.pCodArticulo = codArticulo
        Me.pNumSerie = numSerie
    End Sub

    Public Sub New(idArticulo As Integer, codArticulo As String, numSerie As String, etiquetaImpresa As Boolean, etiquetaFinalImpresa As Boolean)
        Me.pIdArticulo = idArticulo
        Me.pCodArticulo = codArticulo
        Me.pNumSerie = numSerie
        Me.pEtiquetaImpresa = etiquetaImpresa
        Me.pEtiquetaImpresaFinal = etiquetaFinalImpresa
    End Sub

    Public Property IdArticulo As Integer
        Get
            Return pIdArticulo
        End Get
        Set(value As Integer)
            pIdArticulo = value
        End Set
    End Property

    Public Property CodArticulo As String
        Get
            Return pCodArticulo
        End Get
        Set(value As String)
            pCodArticulo = value
        End Set
    End Property

    Public Property NumSerie As String
        Get
            Return pNumSerie
        End Get
        Set(value As String)
            pNumSerie = value
        End Set
    End Property

    Public Property EtiquetaImpresa As Boolean
        Get
            Return pEtiquetaImpresa
        End Get
        Set(value As Boolean)
            pEtiquetaImpresa = value
        End Set
    End Property

    Public Property EtiquetaImpresaFinal As Boolean
        Get
            Return pEtiquetaImpresaFinal
        End Get
        Set(value As Boolean)
            pEtiquetaImpresaFinal = value
        End Set
    End Property
End Class

