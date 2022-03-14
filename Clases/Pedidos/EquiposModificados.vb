Public Class EquiposModificados
    Private idArticuloOriginal As Integer
    Private idARticuloNuevo As Integer
    Private codArticuloOriginal As String
    Private codArticuloNuevo As String
    Private Cantidad As Double
    Private idEscandalloOriginal As Integer
    Private idEscandalloNuevo As Integer
    Private idProduccionNuevo As Long


    Public Property gIdArticuloOriginal() As Integer
        Get
            Return idArticuloOriginal
        End Get
        Set(ByVal value As Integer)
            idArticuloOriginal = value
        End Set
    End Property

    Public Property gidArticuloNuevo() As Integer
        Get
            Return idARticuloNuevo
        End Get
        Set(ByVal value As Integer)
            idARticuloNuevo = value
        End Set
    End Property

    Public Property gcodArticuloOriginal() As String
        Get
            Return codArticuloOriginal
        End Get
        Set(ByVal value As String)
            codArticuloOriginal = value
        End Set
    End Property

    Public Property gcodArticuloNuevo() As String
        Get
            Return codArticuloNuevo
        End Get
        Set(ByVal value As String)
            codArticuloNuevo = value
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

    Public Property gidEscandalloNuevo() As Integer
        Get
            Return idEscandalloNuevo
        End Get
        Set(ByVal value As Integer)
            idEscandalloNuevo = value
        End Set
    End Property


    Public Property gidEscandalloOriginal() As Integer
        Get
            Return idEscandalloOriginal
        End Get
        Set(ByVal value As Integer)
            idEscandalloOriginal = value
        End Set
    End Property

    Public Property gidProduccionNuevo() As Long
        Get
            Return idProduccionNuevo
        End Get
        Set(ByVal value As Long)
            idProduccionNuevo = value
        End Set
    End Property

    Public Sub New()

    End Sub


    Public Sub New(ByVal IdArticuloOriginal As Integer, ByVal codArticuloOriginal As String, ByVal idEscandalloOriginal As Integer, ByVal idArticuloNuevo As Integer, ByVal codArticuloNuevo As String, ByVal idEscandalloNuevo As Integer, ByVal idproduccionNuevo As Long, ByVal Cantidad As Double)
        gidArticuloNuevo = idArticuloNuevo
        gcodArticuloNuevo = codArticuloNuevo
        gIdArticuloOriginal = IdArticuloOriginal
        gcodArticuloOriginal = codArticuloOriginal
        gCantidad = Cantidad
        gidEscandalloNuevo = idEscandalloNuevo
        gidEscandalloOriginal = idEscandalloOriginal
        gidProduccionNuevo = idproduccionNuevo
    End Sub

    Public Overrides Function ToString() As String
        Return gCantidad & " - " & gcodArticuloOriginal
    End Function

End Class
