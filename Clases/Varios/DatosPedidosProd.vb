Public Class DatosPedidosProd

    Dim numpedido As Integer
    Dim fechaEntrega As Date
    Dim fecha As Date
    Dim cliente As String
    Dim cantidad As Double
    Dim notaImpresa As String
    Dim recambio As String
    Dim prioridad As Integer
    Dim estado As String
    Dim celulas As Double
    Dim dRecambios As Double
    Dim dEquipos As Double
    Dim dDomestico As Double
    Dim dInsdustrial As Double
    Dim bReparacion As Boolean
    Dim fechaProduccion As Date
    Dim roturaStock As Boolean
    Dim pedidoAX As String
    Dim dDomesticos2 As Double 'RAMOS
    Dim dDomesticos2Acabados As Double
    Dim dDomesticosAcabados As Double
    Dim dIndustrialesAcabados As Double
    Dim dCelulasAcabadas As Double
    Dim fechaVolcado As String

    Public Property gPrioridad() As Integer
        Get
            Return prioridad
        End Get
        Set(ByVal value As Integer)
            prioridad = value
        End Set
    End Property

    Public Property gReparacion() As Boolean
        Get
            Return bReparacion
        End Get
        Set(ByVal value As Boolean)
            bReparacion = value
        End Set
    End Property

    Public Property gnumpedido() As Integer
        Get
            Return numpedido
        End Get
        Set(ByVal value As Integer)
            numpedido = value
        End Set
    End Property

    Public Property gcliente() As String
        Get
            Return UCase(cliente)
        End Get
        Set(ByVal value As String)
            cliente = UCase(value)
        End Set
    End Property

    Public Property gPedidoAX() As String
        Get
            Return UCase(pedidoAX)
        End Get
        Set(ByVal value As String)
            pedidoAX = UCase(value)
        End Set
    End Property

    Public Property gEstado() As String
        Get
            Return UCase(estado)
        End Get
        Set(ByVal value As String)
            estado = UCase(value)
        End Set
    End Property

    Public Property gcantidad() As Double
        Get
            Return cantidad

        End Get
        Set(ByVal value As Double)

            cantidad = value

        End Set
    End Property

    Public Property gRecambios() As Double
        Get
            Return dRecambios

        End Get
        Set(ByVal value As Double)

            dRecambios = value

        End Set
    End Property

    Public Property gIndustrial() As Double
        Get
            Return dInsdustrial

        End Get
        Set(ByVal value As Double)

            dInsdustrial = value

        End Set
    End Property

    Public Property gDomestico() As Double
        Get
            Return dDomestico

        End Get
        Set(ByVal value As Double)

            dDomestico = value

        End Set
    End Property

    Public Property gcantidadCelulas() As Double
        Get
            Return celulas

        End Get
        Set(ByVal value As Double)

            celulas = value

        End Set
    End Property

    Public Property gfechaEntrega() As Date
        Get
            Return fechaEntrega
        End Get
        Set(ByVal value As Date)
            fechaEntrega = value
        End Set
    End Property

    Public Property gfecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property

    Public Property gNotaImpresa() As String
        Get
            Return notaImpresa
        End Get
        Set(ByVal value As String)
            notaImpresa = value
        End Set
    End Property

    Public Property grecambio() As String
        Get
            Return recambio
        End Get
        Set(ByVal value As String)
            recambio = value
        End Set
    End Property

    Public Property gFechaProduccion() As Date
        Get
            Return fechaProduccion
        End Get
        Set(ByVal value As Date)
            fechaProduccion = value
        End Set
    End Property

    Public Property gRoturaStock() As Boolean
        Get
            Return roturaStock
        End Get
        Set(ByVal value As Boolean)
            roturaStock = value
        End Set
    End Property

    Public Property gDomesticos2 As Double 'RAMOS
        Get
            Return dDomesticos2
        End Get
        Set(value As Double)
            dDomesticos2 = value
        End Set
    End Property

    Public Property gDomesticos2Acabados As Double
        Get
            Return dDomesticos2Acabados
        End Get
        Set(value As Double)
            dDomesticos2Acabados = value
        End Set
    End Property

    Public Property gDomesticosAcabados As Double
        Get
            Return dDomesticosAcabados
        End Get
        Set(value As Double)
            dDomesticosAcabados = value
        End Set
    End Property

    Public Property gIndustrialesAcabados As Double
        Get
            Return dIndustrialesAcabados
        End Get
        Set(value As Double)
            dIndustrialesAcabados = value
        End Set
    End Property

    Public Property gCelulasAcabadas As Double
        Get
            Return dCelulasAcabadas
        End Get
        Set(value As Double)
            dCelulasAcabadas = value
        End Set
    End Property

    Public Property gFechaVolcado As String
        Get
            Return fechaVolcado
        End Get
        Set(value As String)
            fechaVolcado = value
        End Set
    End Property
End Class
