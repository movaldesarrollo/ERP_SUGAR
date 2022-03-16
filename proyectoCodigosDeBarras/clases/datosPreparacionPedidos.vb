Public Class datosPreparacionPedidos

#Region "VARIABLES"

    Dim idEquipo As Integer
    Dim articulo As String
    Dim idArticulo As Integer
    Dim numSerie As Integer
    Dim numSerieSubProducto As String
    Dim subTipoArticulo As String
    Dim idConceptoEquipoProduccion As Integer
    Dim totalConceptosEquiposProduccion As Integer
    Dim conceptosEquiposProduccionAsignados As Integer
    Dim etiquetaImpresa As Boolean
    Dim etiquetaFinalImpresa As Boolean

#End Region

#Region "PROPIEDADES"

    Public Property pEtiquetaImpresa() As Boolean
        Get
            Return etiquetaImpresa
        End Get
        Set(value As Boolean)
            etiquetaImpresa = value
        End Set
    End Property

    Public Property pEtiquetaFinalImpresa() As Boolean
        Get
            Return etiquetaFinalImpresa
        End Get
        Set(value As Boolean)
            etiquetaFinalImpresa = value
        End Set
    End Property

    Public Property pTotalConceptosEquiposProduccion() As Integer
        Get
            Return totalConceptosEquiposProduccion
        End Get
        Set(value As Integer)
            totalConceptosEquiposProduccion = value
        End Set
    End Property

    Public Property pConceptosEquiposProduccionAsignados() As Integer
        Get
            Return ConceptosEquiposProduccionAsignados
        End Get
        Set(value As Integer)
            ConceptosEquiposProduccionAsignados = value
        End Set
    End Property

    Public Property pIdEquipo() As Integer
        Get
            Return idEquipo
        End Get
        Set(value As Integer)
            idEquipo = value
        End Set
    End Property

    Public Property pIdConceptoEquipoProduccion() As Integer
        Get
            Return idConceptoEquipoProduccion
        End Get
        Set(value As Integer)
            idConceptoEquipoProduccion = value
        End Set
    End Property

    Public Property pNumSerie() As Integer
        Get
            Return numSerie
        End Get
        Set(value As Integer)
            numSerie = value
        End Set
    End Property

    Public Property pIdArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(value As Integer)
            idArticulo = value
        End Set
    End Property

    Public Property pArticulo() As String
        Get
            Return articulo
        End Get
        Set(value As String)
            articulo = value
        End Set
    End Property

    Public Property pSubTipoArticulo() As String
        Get
            Return subTipoArticulo
        End Get
        Set(value As String)
            subTipoArticulo = value
        End Set
    End Property

    Public Property pNumSerieSubProducto() As String
        Get
            Return numSerieSubProducto
        End Get
        Set(value As String)
            numSerieSubProducto = value
        End Set
    End Property

#End Region

End Class
