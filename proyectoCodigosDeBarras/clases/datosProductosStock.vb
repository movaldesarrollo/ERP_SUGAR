Public Class datosProductosStock

#Region "VARIABLES"

    Dim idProducto As Integer
    Dim idArticulo As Integer
    Dim producto As String
    Dim codProducto As String
    Dim fecha As DateTime
    Dim numserie As String

#End Region

#Region "PROPIEDADES"

    Property pIdProducto As Integer
        Get
            Return idProducto
        End Get
        Set(value As Integer)
            idProducto = value
        End Set
    End Property

    Property pIdArticulo As Integer
        Get
            Return idArticulo
        End Get
        Set(value As Integer)
            idArticulo = value
        End Set
    End Property

    Property pProducto As String
        Get
            Return producto
        End Get
        Set(value As String)
            producto = value
        End Set
    End Property

    Property pCodProducto As String
        Get
            Return codProducto
        End Get
        Set(value As String)
            codProducto = value
        End Set
    End Property

    Property pFecha As DateTime
        Get
            Return fecha
        End Get
        Set(value As DateTime)
            fecha = value
        End Set
    End Property

    Property pnumserie As String
        Get
            Return numserie
        End Get
        Set(value As String)
            numserie = value
        End Set
    End Property


#End Region

End Class
