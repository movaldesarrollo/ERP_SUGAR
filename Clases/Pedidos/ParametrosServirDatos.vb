Public Class DatosParametrosServir

    Private numPedido As Integer
    Private Bultos As Integer
    Private KilosBrutos As Double
    Private KilosNetos As Double
    Private Volumen As Double
    Private Medidas As String = ""


   

  


    Public Property gnumPedido() As Integer
        Get
            Return numPedido
        End Get
        Set(ByVal value As Integer)
            numPedido = value
        End Set
    End Property

 



    Public Property gBultos() As Integer
        Get
            Return Bultos
        End Get
        Set(ByVal value As Integer)
            Bultos = value
        End Set
    End Property

    Public Property gKilosBrutos() As Double
        Get
            Return KilosBrutos
        End Get
        Set(ByVal value As Double)
            KilosBrutos = value
        End Set
    End Property

    Public Property gKilosNetos() As Double
        Get
            Return KilosNetos
        End Get
        Set(ByVal value As Double)
            KilosNetos = value
        End Set
    End Property

    Public Property gVolumen() As Double
        Get
            Return Volumen
        End Get
        Set(ByVal value As Double)
            Volumen = value
        End Set
    End Property

   
    Public Property gMedidas() As String
        Get
            Return Medidas
        End Get
        Set(ByVal value As String)
            Medidas = value
        End Set
    End Property

   


End Class

