Public Class datosFacturaComision

    Private numFactura As Integer
    Private FechaFactura As Date
    Private idComercial As Integer
    Private Base As Double
    Private ImporteComision As Double
    Private Liquidada As Boolean
    Private FechaLiquidacion As Date
    Private Porcentajes As String
    Private idCliente As Integer
    Private Comercial As String
    Private Cliente As String
    Private codMoneda As String
    Private Simbolo As String
    Private idEstado As Integer
    Private Estado As String
    Private Comisiones As String
    Private idLiquidacion As Integer



    Public Property gnumFactura() As Integer
        Get
            Return numFactura
        End Get
        Set(ByVal value As Integer)
            numFactura = value
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

    Public Property gidComercial() As Integer
        Get
            Return idComercial
        End Get
        Set(ByVal value As Integer)
            idComercial = value
        End Set
    End Property

    Public Property gBase() As Double
        Get
            Return Base
        End Get
        Set(ByVal value As Double)
            Base = value
        End Set
    End Property


    Public Property gImporteComision() As Double
        Get
            Return ImporteComision
        End Get
        Set(ByVal value As Double)
            ImporteComision = value
        End Set
    End Property



    Public Property gLiquidada() As Boolean
        Get
            Return Liquidada
        End Get
        Set(ByVal value As Boolean)
            Liquidada = value
        End Set
    End Property


    Public Property gFechaLiquidacion() As Date
        Get
            Return FechaLiquidacion
        End Get
        Set(ByVal value As Date)
            FechaLiquidacion = value
        End Set
    End Property


    Public Property gPorcentajes() As String
        Get
            Return Porcentajes
        End Get
        Set(ByVal value As String)
            Porcentajes = value
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


    Public Property gComercial() As String
        Get
            Return UCase(Comercial)
        End Get
        Set(ByVal value As String)
            Comercial = UCase(value)
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


    Public Property gcodMoneda() As String
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

    Public Property gidEstado() As Integer
        Get
            Return idEstado
        End Get
        Set(ByVal value As Integer)
            idEstado = value
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

    Public Property gComisiones() As String
        Get
            Return Comisiones
        End Get
        Set(ByVal value As String)
            Comisiones = value
        End Set
    End Property

    Public Property gidLiquidacion() As Integer
        Get
            Return idLiquidacion
        End Get
        Set(ByVal value As Integer)
            idLiquidacion = value
        End Set
    End Property

End Class
