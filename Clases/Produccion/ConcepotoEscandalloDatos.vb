Public Class DatosConceptoEscandallo

    Private idConcepto As Long
    Private idEscandallo As Integer
    Private idArticulo As Integer
    Private codConcepto As String
    Private Concepto As String
    Private Cantidad As Double
    Private idSeccion As Integer
    Private Observaciones As String
    Private Orden As Integer
    Private idTipoUnidad As Integer
    Private Activo As Boolean

    'Datos de otras tablas
    Private codEscandallo As String
    Private Escandallo As String
    Private codArticulo As String
    Private Articulo As String
    Private idFamilia As Integer
    Private idsubFamilia As Integer
    Private Familia As String
    Private subFamilia As String
    Private Seccion As String
    Private TipoUnidad As String
    Private Coste As Double
    Private codMoneda As String
    Private simbolo As String
    Private FechaCoste As Date
    Private ExisteEscandallo As Integer
    Private ArticuloEN As String
    Private Descripcion As String
    Private DescripcionEN As String
    Private PrecioOpcion As Double
    Private codMonedaV As String
    Private simboloV As String
    Private colorSubEscandallos As Boolean


    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
        End Set
    End Property


    Public Property gidEscandallo() As Integer
        Get
            Return idEscandallo
        End Get
        Set(ByVal value As Integer)
            idEscandallo = value
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

    Public Property gcodConcepto() As String
        Get
            Return codConcepto
        End Get
        Set(ByVal value As String)
            codConcepto = value
        End Set
    End Property

    Public Property gConcepto() As String
        Get
            Return Concepto
        End Get
        Set(ByVal value As String)
            Concepto = value
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


    Public Property gidSeccion() As Integer
        Get
            Return idSeccion
        End Get
        Set(ByVal value As Integer)
            idSeccion = value
        End Set
    End Property


    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
        End Set
    End Property

    Public Property gOrden() As Integer
        Get
            Return Orden
        End Get
        Set(ByVal value As Integer)
            Orden = value
        End Set
    End Property

    Public Property gidTipoUnidad() As Integer
        Get
            Return idTipoUnidad
        End Get
        Set(ByVal value As Integer)
            idTipoUnidad = value
        End Set
    End Property

    Public Property gActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property gColorSubEscandallos() As Boolean 'LUISSSS
        Get
            Return colorSubEscandallos
        End Get
        Set(ByVal value As Boolean)
            colorSubEscandallos = value
        End Set
    End Property

    Public Property gcodEscandallo() As String
        Get
            Return UCase(codEscandallo)
        End Get
        Set(ByVal value As String)
            codEscandallo = UCase(value)
        End Set
    End Property


    Public Property gEscandallo() As String
        Get
            Return Escandallo
        End Get
        Set(ByVal value As String)
            Escandallo = value
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


    Public Property gArticulo()
        Get
            Return UCase(Articulo)
        End Get
        Set(ByVal value)
            Articulo = UCase(value)
        End Set
    End Property

    Public Property gidFamilia() As Integer
        Get
            Return idFamilia
        End Get
        Set(ByVal value As Integer)
            idFamilia = value
        End Set
    End Property

    Public Property gFamilia() As String
        Get
            Return Familia
        End Get
        Set(ByVal value As String)
            Familia = value
        End Set
    End Property

    Public Property gidsubFamilia() As Integer
        Get
            Return idsubFamilia
        End Get
        Set(ByVal value As Integer)
            idsubFamilia = value
        End Set
    End Property

    Public Property gsubFamilia() As String
        Get
            Return subFamilia
        End Get
        Set(ByVal value As String)
            subFamilia = value
        End Set
    End Property



    Public Property gSeccion() As String
        Get
            Return Seccion
        End Get
        Set(ByVal value As String)
            Seccion = value
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


    Public Property gCoste() As Double
        Get
            Return Coste
        End Get
        Set(ByVal value As Double)
            Coste = value
        End Set
    End Property


    Public Property gcodMoneda() As String
        Get
            Return codMoneda
        End Get
        Set(ByVal value As String)
            codMoneda = value
        End Set
    End Property

    Public Property gsimbolo() As String
        Get
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property

    Public Property gFechaCoste() As Date
        Get
            Return FechaCoste
        End Get
        Set(ByVal value As Date)
            FechaCoste = value
        End Set
    End Property

    Public Property gExisteEscandallo() As Integer
        Get
            Return ExisteEscandallo
        End Get
        Set(ByVal value As Integer)
            ExisteEscandallo = value
        End Set
    End Property

    Public Property gArticuloEN() As String
        Get
            Return ArticuloEN
        End Get
        Set(ByVal value As String)
            ArticuloEN = value
        End Set
    End Property

    Public Property gDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property

    Public Property gDescripcionEN() As String
        Get
            Return DescripcionEN
        End Get
        Set(ByVal value As String)
            DescripcionEN = value
        End Set
    End Property

    Public Property gPrecioOpcion() As Double
        Get
            Return PrecioOpcion
        End Get
        Set(ByVal value As Double)
            PrecioOpcion = value
        End Set
    End Property

    Public Property gCodMonedaV() As String
        Get
            Return codMonedaV
        End Get
        Set(ByVal value As String)
            codMonedaV = value
        End Set
    End Property

    Public Property gSimboloV() As String
        Get
            Return simboloV
        End Get
        Set(ByVal value As String)
            simboloV = value
        End Set
    End Property

End Class
