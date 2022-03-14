Public Class datosMenu_Entrada

    Dim idMenu As Integer
    Dim Nivel As Integer
    Dim Nombre As String
    Dim idMenuPadre As Integer
    Dim Ejecutar As String
   
  



    Public Property gidMenu()
        Get
            Return idMenu
        End Get
        Set(ByVal value)
            idMenu = value
        End Set
    End Property

    Public Property gNivel()
        Get
            Return Nivel
        End Get
        Set(ByVal value)
            Nivel = value
        End Set
    End Property

    Public Property gNombre()
        Get
            Return Nombre
        End Get
        Set(ByVal value)
            Nombre = value
        End Set
    End Property

    Public Property gidMenuPadre()
        Get
            Return idMenuPadre
        End Get
        Set(ByVal value)
            idMenuPadre = value
        End Set
    End Property

    Public Property gEjecutar() As String
        Get
            Return Ejecutar
        End Get
        Set(ByVal value As String)
            Ejecutar = value
        End Set
    End Property


End Class
