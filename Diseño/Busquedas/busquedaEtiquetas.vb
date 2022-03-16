
Public Class busquedaEtiquetas

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private iidEtiqueta As Integer
    Private vsoloLectura As Boolean
    Private funcE As New FuncionesEtiquetas
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer

    Private indice As Integer
    Private modo As String

    Private semaforo As Boolean

    Dim retardo As New Timer
    Dim BuscarAhora As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Property pidEtiqueta() As Integer
        Get
            Return iidEtiqueta
        End Get
        Set(ByVal value As Integer)
            iidEtiqueta = value

        End Set
    End Property


    Property pModo() As String
        Get
            Return modo
        End Get
        Set(ByVal value As String)
            modo = value
        End Set
    End Property


    Private Sub busquedaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        Dim cmenu1 As New ContextMenu

        cmenu1.MenuItems.Add("Abrir GESTIÓN/IMPRIMIR", New System.EventHandler(AddressOf Me.LV_OnClickPress))
        cmenu1.MenuItems.Add("Abrir EDICIÓN", New System.EventHandler(AddressOf Me.LV_OnClickPress))
        cmenu1.MenuItems.Add("Activar/Desactivar", New System.EventHandler(AddressOf Me.LV_OnClickPress))
        cmenu1.MenuItems.Add("Asignar CLIENTE", New System.EventHandler(AddressOf Me.LV_OnClickPress))
        lvDocumentos.ContextMenu = cmenu1

        colorInactivo = Color.Gray
        colorCabecera = Color.Red

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
     
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False

        Call limpiar()
        direccion = "ASC"

       
        Call introducirClientes()
      
        Call busqueda()
    End Sub




#Region "INICIALIZACIÓN"



    Private Sub limpiar()
        semaforo = False
        numDoc.Text = ""
       
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        Observaciones.Text = ""
        Orden = ""
        direccion = "ASC"
        semaforo = True
    End Sub


  



  

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub



   


#End Region



#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call Busqueda()
        End If
    End Sub

    Private Sub busqueda()

        'instrucciones para búsqueda de Cliente
        sBusqueda = ""

        If numDoc.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ET.Nombre like '%" & numDoc.Text & "%' "
        End If

        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CLientes.NombreComercial like '%" & cbCliente.Text & "%' "
        End If
       
        If Observaciones.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " ET.Observaciones like '%" & Observaciones.Text & "%' "
        End If

        If Not ckVerInactivas.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " (ET.Activo = 1 or ET.Activo is null) "
        End If

        Call ActualizarLV()

    End Sub


    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()

           
            Dim lista As List(Of DatosEtiqueta) = funcE.Busqueda(sBusqueda, Orden)
            For Each dts As DatosEtiqueta In lista

                With lvDocumentos.Items.Add(dts.gidEtiqueta)
                    .SubItems.Add(dts.gNombre)
                    .SubItems.Add(If(dts.gidCliente = 0 And dts.gEtiquetaEditada, "GENÉRICO", dts.gCliente))
                    .SubItems.Add(dts.gObservaciones)
                    .SubItems.Add(dts.gEtiquetaEditada)
                    If dts.gEtiquetaEditada Then
                        .ForeColor = Color.Black
                    Else
                        .ForeColor = Color.DimGray
                    End If
                    If Not dts.gActivo Then .ForeColor = Color.DarkGray
                End With
            Next
            Contador.Text = lvDocumentos.Items.Count
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            iidEtiqueta = lvDocumentos.Items(indice).Text
            Dim dts As DatosEtiqueta = funcE.Mostrar1(iidEtiqueta)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dts.gNombre
                .SubItems(2).Text = If(dts.gidCliente = 0 And dts.gEtiquetaEditada, "GENÉRICO", dts.gCliente)
                .SubItems(3).Text = dts.gObservaciones
                .SubItems(4).Text = dts.gEtiquetaEditada
                If dts.gEtiquetaEditada Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = Color.DimGray
                End If
                If Not dts.gActivo Then .ForeColor = Color.DarkGray
            End With
        End If

    End Sub

    Private Sub RecalcularTotalizadores()
       
        Dim lista As List(Of DatosEtiqueta) = funcE.Busqueda(sBusqueda, Orden)
       
        Contador.Text = lvDocumentos.Items.Count

    End Sub





#End Region




#Region "BOTONES GENERALES"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
        Call busqueda()
    End Sub

    

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New EditorEtiquetas
        GG.SoloLectura = vsoloLectura
        GG.pidEtiqueta = 0
        GG.ShowDialog()
        If GG.pidEtiqueta > 0 Then
            Call busqueda()
        End If
    End Sub


#End Region


#Region "EVENTOS"

    Private Sub LV_OnClickPress(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            Select Case sender.text
                Case "Abrir GESTIÓN/IMPRIMIR"
                    Call AbrirGestion()
                Case "Abrir EDICIÓN"
                    Call AbrirEdicion()
                Case "Activar/Desactivar"
                    funcE.CambiarActiva(lvDocumentos.SelectedItems(0).Text)
                    Call ActualizarLineaLV()
                Case "Asignar CLIENTE"
                    Call AsignarCliente()
            End Select
        End If
    End Sub

    Private Sub AsignarCliente()
        Dim GG As New subElegirCliente
        GG.ShowDialog()
        If GG.DialogResult = Windows.Forms.DialogResult.OK Then
            funcE.CambiaridCliente(lvDocumentos.SelectedItems(0).Text, GG.pidCliente)
        End If
        Call ActualizarLineaLV()
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            If modo = "B" Then
                Me.Close()
            Else
                Call AbrirEdicion()
            End If

        End If
    End Sub

    Private Sub AbrirEdicion()
        If lvDocumentos.Items(indice).SubItems(4).Text = False Then
            MsgBox("Etiqueta no editable")
        Else
            Dim GG As New EditorEtiquetas
            GG.pidEtiqueta = lvDocumentos.SelectedItems(0).Text
            GG.SoloLectura = vsoloLectura
            GG.ShowDialog()
            Call ActualizarLineaLV()
            Call RecalcularTotalizadores()
        End If

    End Sub

    Private Sub AbrirGestion()
       
        Dim GG As New GestionEtiquetas
        GG.pidEtiqueta = lvDocumentos.SelectedItems(0).Text
        GG.SoloLectura = vsoloLectura
        GG.ShowDialog()

    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 684
        Me.Height = If(Me.Height < 300, 300, Me.Height)
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbCliente.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
        End If

    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If direccion = "ASC" Then
                direccion = "DESC"
            Else
                direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 1
                Orden = " ET.Nombre"
            Case 2
                Orden = "Cliente"
            Case 3
                Orden = "ET.Observaciones"
        End Select

        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub cbCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckVerInactivas.CheckStateChanged, cbCliente.TextChanged, numDoc.TextChanged, Observaciones.TextChanged
        Call busqueda()
    End Sub

#End Region

End Class