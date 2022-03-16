Public Class DatosLiquidacion


    Private idLiquidacion As Integer
    Private idComercial As Integer
    Private FechaLiquidacion As Date
    Private Comercial As String
    Private importe As Double

    Public Property gidLiquidacion() As Integer
        Get
            Return idLiquidacion
        End Get
        Set(ByVal value As Integer)
            idLiquidacion = value
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

    Public Property gFechaLiquidacion() As Date
        Get
            Return FechaLiquidacion
        End Get
        Set(ByVal value As Date)
            FechaLiquidacion = value
        End Set
    End Property

    Public Property gComercial() As String
        Get
            Return Comercial
        End Get
        Set(ByVal value As String)
            Comercial = value
        End Set
    End Property

    Public Property gImporte() As Double
        Get
            Return importe
        End Get
        Set(ByVal value As Double)
            importe = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal FechaLiquidacion As Date, ByVal idComercial As Integer, ByVal Importe As Double)
        gFechaLiquidacion = FechaLiquidacion
        gidComercial = idComercial
        gImporte = Importe
    End Sub

End Class