Public Class DatosMovimientoEquiposAcabados

    Private idMovimiento As Long
    Private idArticulo As Integer
    Private Cantidad As Double
    ' Private Traspasado As Integer
    Private Finalizacion As Date
    Private idFinalizador As Integer

    Private Finalizador As String
    Private codArticulo As String
    Private Articulo As String





    Public Property gidMovimiento() As Long
        Get
            Return idMovimiento
        End Get
        Set(ByVal value As Long)
            idMovimiento = value
        End Set
    End Property



    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
        End Set
    End Property


    Public Property gCantidad() As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property


    'Public Property gTraspasado() As Boolean
    '    Get
    '        Return Traspasado
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Traspasado = value
    '    End Set
    'End Property

    Public Property gFinalizacion() As Date
        Get
            Return Finalizacion
        End Get
        Set(ByVal value As Date)
            Finalizacion = value
        End Set
    End Property

    Public Property gidFinalizador() As Integer
        Get
            Return idFinalizador
        End Get
        Set(ByVal value As Integer)
            idFinalizador = value
        End Set
    End Property

    Public Property gFinalizador() As String
        Get
            Return Finalizador
        End Get
        Set(ByVal value As String)
            Finalizador = value
        End Set
    End Property


    Public Property gcodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property


    Public Property gArticulo() As String
        Get
            Return Articulo
        End Get
        Set(ByVal value As String)
            Articulo = value
        End Set
    End Property


End Class
