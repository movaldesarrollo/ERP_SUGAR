Public Class datosCuadreStock

#Region "VARIABLES"
    Dim equipoDomestico As Boolean
    Dim celulaDomestico As Boolean
    Dim equipoIndustrial As Boolean
    Dim celulaIndustrial As Boolean
    Dim fecha As Date
    Dim hora As String
    Dim idArticulo As Integer
#End Region

#Region "Propiedades"
    Public Property pEquipoDomestico As Boolean
        Get
            Return equipoDomestico
        End Get
        Set(value As Boolean)
            equipoDomestico = value
        End Set
    End Property

    Public Property pCelulaDomestico As Boolean
        Get
            Return celulaDomestico
        End Get
        Set(value As Boolean)
            celulaDomestico = value
        End Set
    End Property

    Public Property pEquipoIndustrial As Boolean
        Get
            Return equipoIndustrial
        End Get
        Set(value As Boolean)
            equipoIndustrial = value
        End Set
    End Property

    Public Property pCelulaIndustrial As Boolean
        Get
            Return celulaIndustrial
        End Get
        Set(value As Boolean)
            celulaIndustrial = value
        End Set
    End Property

    Public Property pFecha As Date
        Get
            Return fecha
        End Get
        Set(value As Date)
            fecha = value
        End Set
    End Property

    Public Property pHora As String
        Get
            Return hora
        End Get
        Set(value As String)
            hora = value
        End Set
    End Property

    Public Property pIdArticulo As Integer
        Get
            Return idArticulo
        End Get
        Set(value As Integer)
            idArticulo = value
        End Set
    End Property
#End Region

End Class
