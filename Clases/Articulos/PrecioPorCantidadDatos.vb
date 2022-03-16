Public Class DatosPrecioPorCantidad

    Private idRangoPrecio As Integer
    Private idArticulo As Integer
    Private idProveedor As Integer
    Private Desde As Double = 0
    Private Hasta As Double = 0
    Private Precio As Double
    Private Fecha As Date

    Private Proveedor As String
    Private codMoneda As String
    Private Simbolo As String
    Private TipoUnidad As String = "u."
    Private codArticulo As String
    Private Articulo As String

    Dim Rango As String

    Public Property gidRangoPrecio()
        Get
            Return idRangoPrecio
        End Get
        Set(ByVal value)
            idRangoPrecio = value
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

    Public Property gidProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property gDesde() As Double
        Get
            Return Desde
        End Get
        Set(ByVal value As Double)
            Desde = value
        End Set
    End Property


    Public Property gHasta() As Double
        Get
            Return Hasta
        End Get
        Set(ByVal value As Double)
            Hasta = value
        End Set
    End Property


    Public Property gPrecio() As Double
        Get
            Return Precio
        End Get
        Set(ByVal value As Double)
            Precio = value
        End Set
    End Property

    Public Property gFecha() As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property


    Public Property gProveedor() As String
        Get
            Return Proveedor
        End Get
        Set(ByVal value As String)
            Proveedor = value
        End Set
    End Property


    Public Property gCodMoneda() As String
        Get
            Return codMoneda
        End Get
        Set(ByVal value As String)
            codMoneda = value
        End Set
    End Property

    Public Property gSimbolo() As String
        Get
            Return Simbolo
        End Get
        Set(ByVal value As String)
            Simbolo = value
        End Set
    End Property

    Public Property gTipoUnidad() As String
        Get
            Return TipoUnidad
        End Get
        Set(ByVal value As String)
            TipoUnidad = value
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

    Public Property gRango() As String
        Get
            If Desde = Hasta Then
                If Desde = 0 Then
                    Return "TODOS"
                Else
                    Return Desde & TipoUnidad
                End If
            End If
            If Hasta = 9999999 Then
                Return "DESDE " & Desde & TipoUnidad
            Else
                Return Desde & If(Hasta = 0, "", " A " & Hasta & TipoUnidad)
            End If

        End Get
        Set(ByVal value As String)
            Rango = value
        End Set
    End Property

  

    Public Overrides Function ToString() As String
        If Desde = Hasta Then
            If Desde = 0 Then
                Return "TODOS"
            Else
                Return Desde & TipoUnidad
            End If
        End If
        If Hasta = 9999999 Then
            Return "DESDE " & Desde & TipoUnidad
        Else
            Return Desde & If(Hasta = 0, "", " A " & Hasta & TipoUnidad)
        End If

    End Function


End Class
