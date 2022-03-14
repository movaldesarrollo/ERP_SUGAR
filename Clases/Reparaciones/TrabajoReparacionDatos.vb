Public Class DatosTrabajoReparacion

    Private idTrabajo As Long
    Private numReparacion As Integer  'Documento en que se convierte
    Private Trabajo As String
    Private Horas As Double
    Private idPersona As Integer
    Private FechaTrabajo As Date
    Private Orden As Integer

    'Datos de otras tablas
    Private Persona As String
   


    Public Property gidTrabajo() As Integer
        Get
            Return idTrabajo
        End Get
        Set(ByVal value As Integer)
            idTrabajo = value
        End Set
    End Property


    Public Property gnumReparacion() As Integer
        Get
            Return numReparacion
        End Get
        Set(ByVal value As Integer)
            numReparacion = value
        End Set
    End Property



    Public Property gTrabajo() As String
        Get
            Return Trabajo
        End Get
        Set(ByVal value As String)
            Trabajo = value
        End Set
    End Property



    Public Property gHoras() As Double
        Get
            Return Horas
        End Get
        Set(ByVal value As Double)
            Horas = value
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

  
    Public Property gFechaTrabajo() As Date
        Get
            Return FechaTrabajo
        End Get
        Set(ByVal value As Date)
            FechaTrabajo = value
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
  

    'Otras tablas

    Public Property gPersona() As String
        Get
            Return Persona
        End Get
        Set(ByVal value As String)
            Persona = value
        End Set
    End Property

  


End Class

