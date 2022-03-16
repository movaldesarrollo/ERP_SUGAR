Public Class DatosEquipoProduccion

    Private idEquipo As Long
    Private idProduccion As Long
    Private numSerie As String
    Private idArticulo As Integer
    Private idEscandallo As Integer
    Private FechaInicio As Date
    Private FechaFin As Date
    Private idPersona As Integer
    Private idEstado As Integer
    Private idEstadoTaller As Integer
    Private idEstadoElectronica As Integer
    Private Observaciones As String
    Private idEtiqueta As Integer
    Private idConceptoAlbaran As Long
    Private Creacion As Date
    Private Version As Integer
    Private Asignado As Boolean
    Private FechaEntrega As Date
    'Datos de otras tablas
    Private codArticulo As String
    Private Articulo As String
    Private Estado As String
    Private EstadoTaller As String
    Private EstadoElectronica As String
    Private FechaPrevista As Date 'Si hay pedido entonces FechaEntrega del pedido sino hay pedido es la del conceptoProducción 
    Private Prioridad As Byte
    Private numPedido As Integer
    Public cliente_old As String
    Private FechaPedido As Date
    Private idCliente As Integer
    Private codCli As String
    Private Cliente As String
    Private Etiqueta As String
    Private numAlbaran As String
    Private numFactura As Integer
    Private FechaAlbaran As Date
    Private FechaFactura As Date
    Private idTipoArticulo As Integer
    Private idsubTipoArticulo As Integer
    Private TipoArticulo As String
    Private subTipoArticulo As String
    Private idConceptoPedido As Long
    Private Cantidad As Double 'Cantidad del concepto de producción (nos sirve para la vista)
    Private conNunSerie As Boolean
    Private conNunSerie2 As Boolean
    Private Agrupacion As String
    Private idEquipoHistorico As Long = 0
    Private EstadoBusqueda As String 'Es un estado simplificado SERVIDO, PRODUCION, PRODUCCIÓN
    Private conVersiones As Boolean

    Public Property gfechaentrega() As Date
        Get
            Return FechaEntrega
        End Get
        Set(ByVal value As DateTime)
            FechaEntrega = value
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


    Public Property gidArticulo() As Integer
        Get
            Return idArticulo
        End Get
        Set(ByVal value As Integer)
            idArticulo = value
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
  
    Public Property gFechaInicio() As Date
        Get
            Return FechaInicio
        End Get
        Set(ByVal value As Date)
            FechaInicio = value
        End Set
    End Property

    Public Property gFechaFin() As Date
        Get
            Return FechaFin
        End Get
        Set(ByVal value As Date)
            FechaFin = value
        End Set
    End Property

    Public Property gidPersona() As Integer
        Get
            Return idPersona
        End Get
        Set(ByVal value As Integer)
            idPersona = value
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


    Public Property gObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
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

    Public Property gidConceptoAlbaran() As Long
        Get
            Return idConceptoAlbaran
        End Get
        Set(ByVal value As Long)
            idConceptoAlbaran = value
        End Set
    End Property

    Public Property gCreacion() As Date
        Get
            Return Creacion
        End Get
        Set(ByVal value As Date)
            Creacion = value
        End Set
    End Property

    Public Property gAsignado() As Boolean
        Get
            Return Asignado Or (IsNumeric(numSerie) AndAlso numSerie > 0)
        End Get
        Set(ByVal value As Boolean)
            Asignado = value
        End Set
    End Property

    'Otras tablas

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

    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
        End Set
    End Property
    Public Property gcliente_old() As String
        Get
            Return cliente_old
        End Get
        Set(ByVal value As String)
            cliente_old = value
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


    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
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

    Public Property gCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
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

    Public Property gnumAlbaran() As String
        Get
            Return numAlbaran
        End Get
        Set(ByVal value As String)
            numAlbaran = value
        End Set
    End Property

    Public Property gnumFactura() As Integer
        Get
            Return numFactura
        End Get
        Set(ByVal value As Integer)
            numFactura = value
        End Set
    End Property

    Public Property gFechaAlbaran() As Date
        Get
            Return FechaAlbaran
        End Get
        Set(ByVal value As Date)
            FechaAlbaran = value
        End Set
    End Property

    Public Property gFechaFactura() As Date
        Get
            Return FechaFactura
        End Get
        Set(ByVal value As Date)
            FechaFactura = value
        End Set
    End Property

    Public Property gidTipoArticulo() As Integer
        Get
            Return idTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idTipoArticulo = value
        End Set
    End Property

    Public Property gidsubTipoArticulo() As Integer
        Get
            Return idsubTipoArticulo
        End Get
        Set(ByVal value As Integer)
            idsubTipoArticulo = value
        End Set
    End Property


    Public Property gTipoArticulo() As String
        Get
            Return TipoArticulo
        End Get
        Set(ByVal value As String)
            TipoArticulo = value
        End Set
    End Property


    Public Property gSubTipoArticulo() As String
        Get
            Return subTipoArticulo
        End Get
        Set(ByVal value As String)
            subTipoArticulo = value
        End Set
    End Property

    Public Property gidConceptoPedido() As Long
        Get
            Return idConceptoPedido
        End Get
        Set(ByVal value As Long)
            idConceptoPedido = value
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

    Public Property gconNumSerie() As Boolean
        Get
            Return conNunSerie
        End Get
        Set(ByVal value As Boolean)
            conNunSerie = value
        End Set
    End Property

    Public Property gconNumSerie2() As Boolean
        Get
            Return conNunSerie2
        End Get
        Set(ByVal value As Boolean)
            conNunSerie2 = value
        End Set
    End Property

    Public Property gAgrupacion() As String
        Get
            Return Agrupacion
        End Get
        Set(ByVal value As String)
            Agrupacion = value
        End Set
    End Property

    Public Property gidEquipoHistorico() As Long
        Get
            Return idEquipoHistorico
        End Get
        Set(ByVal value As Long)
            idEquipoHistorico = value
        End Set
    End Property

    Public Property gEstadoBusqueda() As String
        Get
            Return EstadoBusqueda
        End Get
        Set(ByVal value As String)
            EstadoBusqueda = value
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

    Public Property gConVersiones() As Boolean
        Get
            Return conVersiones
        End Get
        Set(ByVal value As Boolean)
            conVersiones = value
        End Set
    End Property

End Class


