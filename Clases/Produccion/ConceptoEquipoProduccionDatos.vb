Public Class DatosConceptoEquipoProduccion

    Private idConcepto As Long
    Private idEquipo As Long
    Private idArticulo As Integer
    Private Cantidad As Double
    Private idEstadoTaller As Integer
    Private idEstadoElectronica As Integer
    Private idEstado As Integer
    Private idEtiqueta As Integer
    Private idEscandallo As Integer
    Private Version As Integer

    'Datos de otras tablas

    Private Observaciones As String
    Private idProduccion As Long
    Private numSerie As String
    Private codArticulo As String
    Private Articulo As String
    Private Estado As String
    Private EstadoTaller As String
    Private EstadoElectronica As String
    Private Etiqueta As String
    Private codCli As String
    Private numPedido As Integer
    Private FechaPedido As Date
    Private FechaPrevista As Date
    Private Prioridad As Byte
    Private idEstadoEquipo As Integer
    Private idEscandalloEquipo As Integer



    Public Property gidConcepto() As Long
        Get
            Return idConcepto
        End Get
        Set(ByVal value As Long)
            idConcepto = value
        End Set
    End Property


    Public Property gidEquipo() As Long
        Get
            Return idEquipo
        End Get
        Set(ByVal value As Long)
            idEquipo = value
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

    Public Property gidEstadoTaller() As Integer
        Get
            Return idEstadoTaller
        End Get
        Set(ByVal value As Integer)
            idEstadoTaller = value
        End Set
    End Property

    Public Property gidEstadoElectronica() As Integer
        Get
            Return idEstadoElectronica
        End Get
        Set(ByVal value As Integer)
            idEstadoElectronica = value
        End Set
    End Property

    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
        End Set
    End Property


    Public Property gidEtiqueta() As Integer
        Get
            Return idEtiqueta
        End Get
        Set(ByVal value As Integer)
            idEtiqueta = value
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

    Public Property gVersion() As Integer
        Get
            Return Version
        End Get
        Set(ByVal value As Integer)
            Version = value
        End Set
    End Property

    'Otras tablas

    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
        End Set
    End Property

    Public Property gidProduccion() As Integer
        Get
            Return idProduccion
        End Get
        Set(ByVal value As Integer)
            idProduccion = value
        End Set
    End Property

    Public Property gnumSerie() As String
        Get
            Return numSerie
        End Get
        Set(ByVal value As String)
            numSerie = value
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

    Public Property gEstado() As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set
    End Property

    Public Property gEstadoTaller() As String
        Get
            Return EstadoTaller
        End Get
        Set(ByVal value As String)
            EstadoTaller = value
        End Set
    End Property

    Public Property gEstadoElectronica() As String
        Get
            Return EstadoElectronica
        End Get
        Set(ByVal value As String)
            EstadoElectronica = value
        End Set
    End Property


    Public Property gEtiqueta() As String
        Get
            Return Etiqueta
        End Get
        Set(ByVal value As String)
            Etiqueta = value
        End Set
    End Property

    Public Property gcodCli() As String
        Get
            Return codCli
        End Get
        Set(ByVal value As String)
            codCli = value
        End Set
    End Property




    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
        End Set
    End Property

    Public Property gFechaPedido() As Date
        Get
            Return FechaPedido
        End Get
        Set(ByVal value As Date)
            FechaPedido = value
        End Set
    End Property


    Public Property gFechaPrevista() As Date
        Get
            Return FechaPrevista
        End Get
        Set(ByVal value As Date)
            FechaPrevista = value
        End Set
    End Property

    Public Property gPrioridad() As Byte
        Get
            Return Prioridad
        End Get
        Set(ByVal value As Byte)
            Prioridad = value
        End Set
    End Property

    Public Property gidEstadoEquipo() As Integer
        Get
            Return idEstadoEquipo
        End Get
        Set(ByVal value As Integer)
            idEstadoEquipo = value
        End Set
    End Property

    Public Property gidEscandalloEquipo() As Integer
        Get
            Return idEscandalloEquipo
        End Get
        Set(ByVal value As Integer)
            idEscandalloEquipo = value
        End Set
    End Property

End Class


