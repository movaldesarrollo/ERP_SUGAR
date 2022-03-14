Public Class ClienteSeleccion
    Dim idCliente As Integer
    Dim Cliente As String
    Dim Seleccionado As Boolean
    Dim CargadoAhora As Boolean 'Sirve para saber si lo tenemos que dejar o borrar


    Public Property gidCliente() As Integer
        Get
            Return idCliente
        End Get
        Set(ByVal value As Integer)
            idCliente = value
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

    Public Property gSeleccionado() As Boolean
        Get
            Return Seleccionado
        End Get
        Set(ByVal value As Boolean)
            Seleccionado = value
        End Set
    End Property

    Public Property gCargadoAhora() As Boolean
        Get
            Return CargadoAhora
        End Get
        Set(ByVal value As Boolean)
            CargadoAhora = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Cliente
    End Function



    Public Sub New()

    End Sub

    Public Sub New(ByVal idCliente As Integer, ByVal Cliente As String, ByVal Seleccionado As Boolean)
        gidCliente = idCliente
        gCliente = Cliente
        gSeleccionado = Seleccionado
        gCargadoAhora = True
    End Sub
    Public Sub New(ByVal idCliente As Integer, ByVal Cliente As String)
        gidCliente = idCliente
        gCliente = Cliente
        gSeleccionado = False
        gCargadoAhora = True
    End Sub


End Class
