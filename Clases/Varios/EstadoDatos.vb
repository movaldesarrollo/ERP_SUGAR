Public Class DatosEstado


    Private idEstado As Integer
    Private Estado As String
    Private Aplicacion As String
    Private Descripcion As String
    Private Orden As Integer
    Private Cabecera As Boolean 'No tiene conceptos
    Private Espera As Boolean  'Espera respuesta, validación, recepción, etc
    Private EnCurso As Boolean  'Sigue su curso (pero no espera)
    Private Bloqueado As Boolean  'No se puede modificar
    Private Traspasado As Boolean 'Se ha pasado al siguiente documento del flujo
    Private Anulado As Boolean
    Private Automatico As Boolean
    Private Entregado As Boolean 'Se ha servido o se ha recibido la mercancia
    Private Completo As Boolean  'no parcial

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
            Return UCase(Estado)
        End Get
        Set(ByVal value As String)
            Estado = UCase(value)
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

    Public Property gAplicacion() As String
        Get
            Return UCase(Aplicacion)
        End Get
        Set(ByVal value As String)
            Aplicacion = UCase(value)
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


    Public Property gCabecera() As Boolean
        Get
            Return Cabecera
        End Get
        Set(ByVal value As Boolean)
            Cabecera = value
        End Set
    End Property

    Public Property gBloqueado() As Boolean
        Get
            Return Bloqueado
        End Get
        Set(ByVal value As Boolean)
            Bloqueado = value
        End Set
    End Property

    Public Property gEnCurso() As Boolean
        Get
            Return EnCurso
        End Get
        Set(ByVal value As Boolean)
            EnCurso = value
        End Set
    End Property

    Public Property gEspera() As Boolean
        Get
            Return Espera
        End Get
        Set(ByVal value As Boolean)
            Espera = value
        End Set
    End Property

    Public Property gTraspasado() As Boolean
        Get
            Return Traspasado
        End Get
        Set(ByVal value As Boolean)
            Traspasado = value
        End Set
    End Property

    Public Property gAnulado() As Boolean
        Get
            Return Anulado
        End Get
        Set(ByVal value As Boolean)
            Anulado = value
        End Set
    End Property

    Public Property gAutomatico() As Boolean
        Get
            Return Automatico
        End Get
        Set(ByVal value As Boolean)
            Automatico = value
        End Set
    End Property

    Public Property gEntregado() As Boolean
        Get
            Return Entregado
        End Get
        Set(ByVal value As Boolean)
            Entregado = value
        End Set
    End Property

    Public Property gCompleto() As Boolean
        Get
            Return Completo
        End Get
        Set(ByVal value As Boolean)
            Completo = value
        End Set
    End Property

    Public Overrides Function ToString() As String

        Return Estado

    End Function

    Public Sub New(ByVal Estado As String, ByVal Aplicacion As String, ByVal Bloqueado As Boolean)
        gEstado = Estado
        gAplicacion = Aplicacion
        gBloqueado = Bloqueado
    End Sub


    Public Sub New()

    End Sub

End Class
