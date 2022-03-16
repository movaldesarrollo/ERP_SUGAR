Public Class GestionPermisos

    Dim funcME As New funcionesMenu_Entradas
    Dim funcPF As New funcionesPerfiles
    Dim funcPE As New FuncionesPersonal
    Dim funcMP As New funcionesMenu_Parametros
    Dim funcMPU As New funcionesMenu_ParametrosUsuario
    Dim funcMPP As New funcionesMenu_ParametrosPerfil
    Dim funcMEU As New funcionesMenu_EntradasUsuario
    Dim funcMEP As New funcionesMenu_EntradasPerfil
    'Dim listaMenuPerfil As List(Of datosMenu_EntradasPerfil) 'Nos guardamos los datos del perfil para comparar al guardar y propagar los cambios a los usuarios
    'Dim listaParametrosPerfil As List(Of datosMenu_ParametrosPerfil)
    Dim listaCambiosPerfil As List(Of IDComboBox)
    Dim listaCambiosPerfilParam As List(Of IDComboBox3)
    'Dim listaMenUsuario As List(Of datosMenu_EntradasUsuario)
    Dim listaMenu As List(Of datosMenu_Entrada)
    Dim vSoloLectura As Boolean
    Dim iidUsuario As Integer
    Dim iidMenu As Integer
    Dim indice As Integer
    Dim iidPerfil As Integer
    Dim iidPErsona As Integer  'Se trata de la persona que hace los cambios
    Dim semaforo As Boolean
    Dim cambios As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Property pidUsuario() As Integer
        Get
            Return iidUsuario
        End Get
        Set(ByVal value As Integer)
            iidUsuario = value
        End Set
    End Property

    Property pidPerfil() As Integer
        Get
            Return iidPerfil
        End Get
        Set(ByVal value As Integer)
            iidPerfil = value
        End Set
    End Property

    Private Sub GestionPermisos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 900 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 850
        End If
        iidPErsona = Inicio.vIdUsuario
        semaforo = True
        lbInforma.Text = ""
        Call InicializarGeneral()
        If iidPerfil = 0 Then
            gbUsuario.Enabled = False
        Else
            'Si hemos pasado un idPerfil, seleccionamos el perfil, e introducimos el personal
            Call CargarArbolPerfil()
            gbUsuario.Enabled = True
            lvPerfiles.SelectedIndices.Add(lvPerfiles.Items.Find(iidPerfil, False)(0).Index)
            'Call CargarItems(0, New TreeNode)
            gbUsuario.Enabled = True
            If iidUsuario = 0 Then
            Else
                'Si hemos pasado un usuario, seleccionamos el usuario
                lvPersonal.SelectedIndices.Add(lvPersonal.Items.Find(iidUsuario, False)(0).Index)
                Call CargarArbolUsuario()

            End If

        End If
    End Sub

    Private Sub GestionPermisos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False

            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False

        End If
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub InicializarGeneral()

        Call IntroducirPerfiles()
        listaMenu = funcME.mostrar
        Call CargarItems(0, New TreeNode, "P")
        'Call CargarItems(0, New TreeNode, "U")
        tvMenuPerfil.ExpandAll()
        tvMenuPerfil.TopNode = tvMenuPerfil.Nodes(0)
        bGuardarUsuario.Enabled = False
        bGuardarPerfil.Enabled = False
        bCopiarPerfil.Enabled = False
        cambios = False
        'Call CargarItemsUsuario(0, New TreeNode)
        'tvMenUsuario.ExpandAll()
        'tvMenUsuario.TopNode = tvMenUsuario.Nodes(0)
    End Sub

    Private Sub IntroducirPerfiles()
        iidPerfil = 0
        lvPerfiles.Items.Clear()
        Dim lista As List(Of datosPerfiles) = funcPF.mostrar()
        For Each dts As datosPerfiles In lista
            With lvPerfiles.Items.Add(dts.gidPerfil)
                .SubItems.Add(dts.gPerfil)
                .SubItems.Add(dts.gdescripcion)
            End With
        Next

    End Sub

    Private Sub IntroducirPersonal()
        lbInforma.Text = ""
        iidUsuario = 0
        lvPersonal.Items.Clear()
        Dim lista As List(Of DatosPersonal) = funcPE.Busqueda("Personal.idPerfil = " & iidPerfil, "")
        For Each dts As DatosPersonal In lista
            With lvPersonal.Items.Add(dts.gidPersona)
                .SubItems.Add(dts.gPersona)
                .SubItems.Add(dts.gDepartamento)
            End With
        Next
    End Sub

    Private Sub CargarItems(ByVal iidPadre As Integer, ByVal NodoPadre As TreeNode, ByVal P_U As String)
        'Función recursiva que carga el treeview de perfiles o usuarios según el parámetro P_U
        Dim dts As New datosMenu_Entrada
        Dim listaParametros As List(Of datosMenu_Parametro)
        Dim dtsP As datosMenu_Parametro
        Dim nodoParametro As TreeNode
        Dim NodoHijo As TreeNode
        Dim Fuente0 As Font = New Font(tvMenuPerfil.Font.FontFamily, tvMenuPerfil.Font.Size, FontStyle.Bold)
        Dim Fuente1 As Font = tvMenuPerfil.Font
        For Each dts In listaMenu
            If dts.gidMenuPadre = iidPadre Then
                listaParametros = funcMP.mostrar(dts.gidMenu)
                NodoHijo = New TreeNode(dts.gNombre)
                NodoHijo.Name = dts.gidMenu
                If dts.gNivel = 0 Then
                    NodoHijo.NodeFont = Fuente0
                End If
                If dts.gNivel = 1 Then
                    'NodoHijo.NodeFont = Fuente1
                End If
                If dts.gNivel > 1 Then
                    'NodoHijo.NodeFont = Fuente1
                    NodoHijo.ForeColor = Color.DarkGray
                End If
                If dts.gNivel > 250 Then
                    'NodoHijo.NodeFont = Fuente1
                    NodoHijo.ForeColor = Color.Red
                End If
                If iidPadre = 0 Then
                    If P_U = "P" Then
                        tvMenuPerfil.Nodes.Add(NodoHijo)
                    Else
                        tvMenUsuario.Nodes.Add(NodoHijo)
                    End If
                Else
                    For Each dtsP In listaParametros
                        nodoParametro = New TreeNode(dtsP.gParametro)
                        nodoParametro.Checked = dtsP.gValor
                        nodoParametro.Name = 0
                        nodoParametro.ForeColor = Color.DarkOrange
                        NodoHijo.Nodes.Add(nodoParametro)
                    Next
                    NodoPadre.Nodes.Add(NodoHijo)
                End If
                Call CargarItems(dts.gidMenu, NodoHijo, P_U)
            End If
        Next
    End Sub

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarArbolPerfil()
        Dim lista As List(Of datosMenu_EntradasPerfil) = funcMEP.mostrar(iidPerfil)
        Dim dts As datosMenu_EntradasPerfil
        Dim dtsP As datosMenu_ParametrosPerfil
        Dim listaP As List(Of datosMenu_ParametrosPerfil)
        Dim nodo As TreeNode
        Dim nodoP As TreeNode
        For Each nodo In tvMenuPerfil.Nodes
            nodo.Checked = False
        Next

        For Each nodo In tvMenuPerfil.Nodes 'Primero quitamos el check a todo
            quitarCheck(nodo)
        Next
        lvPersonal.Items.Clear()
        
        For Each dts In lista
            nodo = tvMenuPerfil.Nodes.Find(dts.gidMenu, True)(0)
            If nodo Is Nothing Then
            Else
                nodo.Expand()
                nodo.Checked = True 'Si el nodo está en la lista lo marcamos
                listaP = funcMPP.mostrar(dts.gidMenu, dts.gidPerfil) 'Buscamos que parámetros tiene
                For Each dtsP In listaP
                    For Each nodoP In nodo.Nodes
                        If nodoP.Text = dtsP.gParametro Then nodoP.Checked = dtsP.gValor
                    Next
                Next
            End If
        Next
    End Sub

    Private Sub CargarArbolPerfilUsuario()
        Dim lista As List(Of datosMenu_EntradasPerfil) = funcMEP.mostrar(iidPerfil)

        Dim dts As datosMenu_EntradasPerfil
        Dim dtsP As datosMenu_ParametrosPerfil
        Dim listaP As List(Of datosMenu_ParametrosPerfil)
        Dim nodo As TreeNode
        Dim nodoP As TreeNode
        For Each nodo In tvMenUsuario.Nodes
            nodo.Checked = False
        Next

        For Each nodo In tvMenUsuario.Nodes 'Primero quitamos el check a todo
            quitarCheck(nodo)
        Next

       
        For Each dts In lista
            nodo = tvMenUsuario.Nodes.Find(dts.gidMenu, True)(0)
            If nodo Is Nothing Then
            Else
                nodo.Expand()
                nodo.Checked = True 'Si el nodo está en la lista lo marcamos
                listaP = funcMPP.mostrar(dts.gidMenu, dts.gidPerfil) 'Buscamos que parámetros tiene
                For Each dtsP In listaP
                    For Each nodoP In nodo.Nodes
                        If nodoP.Text = dtsP.gParametro Then nodoP.Checked = dtsP.gValor
                    Next
                Next
            End If
        Next
    End Sub

    Private Function CargarArbolUsuario() As Boolean
        If tvMenUsuario.Nodes.Count = 0 Then Call CargarItems(0, New TreeNode, "U")
        Dim lista As List(Of datosMenu_EntradasUsuario) = funcMEU.mostrar(iidUsuario)
        Dim dts As datosMenu_EntradasUsuario
        Dim dtsP As datosMenu_ParametrosUsuario
        Dim listaP As List(Of datosMenu_ParametrosUsuario)
        Dim nodo As TreeNode
        Dim nodoP As TreeNode
        
        For Each nodo In tvMenUsuario.Nodes 'Primero quitamos el check a todo
            quitarCheck(nodo) ' nodo.Checked = False
        Next
        If lista.Count > 0 Then
            lbInforma.Text = "PERMISOS DE USUARIO"
            For Each dts In lista
                nodo = tvMenUsuario.Nodes.Find(dts.gidMenu, True)(0)
                If nodo Is Nothing Then
                Else
                    nodo.Expand()
                    nodo.Checked = True 'Si el nodo está en la lista lo marcamos
                    listaP = funcMPU.mostrar(dts.gidMenu, dts.gidUsuario) 'Buscamos que parámetros tiene
                    For Each dtsP In listaP
                        For Each nodoP In nodo.Nodes
                            If nodoP.Text = dtsP.gParametro Then nodoP.Checked = dtsP.gValor
                        Next
                    Next
                End If
            Next
        Else
            'Si no estaba definido el usuario, copiamos los datos del perfil
            lbInforma.Text = "PERMISOS DE PERFIL"
           
            Call CargarArbolPerfilUsuario()
        End If

        tvMenUsuario.ExpandAll()
        tvMenUsuario.TopNode = tvMenUsuario.Nodes(0)
    End Function

    Private Sub quitarCheck(ByVal Nodo As TreeNode)
        Nodo.Checked = False
        For Each nodohijo As TreeNode In Nodo.Nodes
            quitarCheck(nodohijo)
        Next
    End Sub

    Private Sub CopiaNodo(ByVal NodoP As TreeNode)
        Dim nodoU As TreeNode
        nodoU = tvMenUsuario.Nodes.Find(NodoP.Name, True)(0)
        nodoU.Checked = NodoP.Checked
        For Each nodoU In NodoP.Nodes
            Call CopiaNodo(nodoU)
        Next
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub RutuinaGuardarPerfil(ByVal nodo As TreeNode)
        Dim dts As datosMenu_EntradasPerfil
        Dim dtsP As datosMenu_ParametrosPerfil
        Dim nodoP As TreeNode
        If nodo.Checked And nodo.Name <> "" Then
            dts = New datosMenu_EntradasPerfil
            dts.gidPerfil = iidPerfil
            dts.gidMenu = nodo.Name
            dts.gidPersona = iidPErsona
            funcMEP.insertar(dts)
            For Each nodoP In nodo.Nodes
                If nodoP.Name = "0" Then
                    'Se trata de un parametro
                    If nodoP.Checked Then
                        dtsP = New datosMenu_ParametrosPerfil
                        dtsP.gidMenu = nodoP.Parent.Name
                        dtsP.gidPerfil = iidPerfil
                        dtsP.gidPersona = iidPErsona
                        dtsP.gParametro = nodoP.Text
                        dtsP.gValor = nodoP.Checked
                        funcMPP.insertar(dtsP)
                    End If
                Else
                    Call RutuinaGuardarPerfil(nodoP)
                End If
            Next
        End If
    End Sub

    Private Sub RutuinaGuardarUsuario(ByVal nodo As TreeNode)
        Dim dts As datosMenu_EntradasUsuario
        Dim dtsP As datosMenu_ParametrosUsuario
        Dim nodoP As TreeNode
        If nodo.Checked And nodo.Name <> "" Then
            dts = New datosMenu_EntradasUsuario
            dts.gidUsuario = iidUsuario
            dts.gidMenu = nodo.Name
            dts.gidPersona = iidPErsona
            funcMEU.insertar(dts)
            For Each nodoP In nodo.Nodes
                If nodoP.Name = "0" Then
                    'Se trata de un parametro
                    'If nodoP.Checked Then
                    dtsP = New datosMenu_ParametrosUsuario
                    dtsP.gidMenu = nodoP.Parent.Name
                    dtsP.gidUsuario = iidUsuario
                    dtsP.gidPersona = iidPErsona
                    dtsP.gParametro = nodoP.Text
                    dtsP.gValor = nodoP.Checked
                    funcMPU.insertar(dtsP)
                    'End If
                Else
                Call RutuinaGuardarUsuario(nodoP)
                End If
            Next

        End If
    End Sub

    Private Sub PropagaPerfil()
        ' comparar al guardar y propagar los cambios a los usuarios
        Dim iidUsuarioP As Integer
        Dim dtsEU As datosMenu_EntradasUsuario
        Dim dtsPU As datosMenu_ParametrosUsuario
        For Each item As ListViewItem In lvPersonal.Items
            iidUsuarioP = item.Text
            If funcMEU.ExisteUsuario(iidUsuarioP) Then
                If MsgBox("¿Propagar los cambios realizados a " & item.SubItems(1).Text & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    For Each par As IDComboBox In listaCambiosPerfil
                        dtsEU = New datosMenu_EntradasUsuario
                        dtsEU.gidUsuario = iidUsuarioP
                        dtsEU.gidMenu = par.Name
                        dtsEU.gidPersona = iidPErsona
                        dtsEU.gCuando = Now
                        funcMEU.Refrescar(dtsEU, par.ItemData)
                    Next
                    For Each trio As IDComboBox3 In listaCambiosPerfilParam
                        dtsPU = New datosMenu_ParametrosUsuario
                        dtsPU.gidUsuario = iidUsuarioP
                        dtsPU.gidMenu = trio.Name1
                        dtsPU.gParametro = trio.Name2
                        dtsPU.gValor = trio.ItemData
                        dtsPU.gidPersona = iidPErsona
                        dtsPU.gCuando = Now
                        funcMPU.Refrescar(dtsPU)
                    Next
                End If
            End If
        Next

    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bGuardarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarPerfil.Click
        If iidPerfil > 0 Then
            'Borramos los parámetros del perfil
            funcMPP.borrar(iidPerfil)
            'Borramos las entradas de menu del perfil
            funcMEP.borrar(iidPerfil)
            'Volvemos a crear todas las entradas
            Dim nodo As TreeNode
            For Each nodo In tvMenuPerfil.Nodes
                Call RutuinaGuardarPerfil(nodo)
            Next
            Call PropagaPerfil()
            lbInforma.Text = ""
            lvPersonal.SelectedItems.Clear()
            tvMenUsuario.Nodes.Clear()
            iidUsuario = 0
            cambios = False
            MsgBox("Estructura y PERMISOS DE PERFIL guardados correctamente")
        End If
    End Sub

    Private Sub bGuardarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarUsuario.Click
        If iidUsuario > 0 Then
            'Borramos los parámetros del usuario
            funcMPU.borrar(iidUsuario)
            'Borramos las entradas de menu del perfil
            funcMEU.borrarUsuario(iidUsuario)
            'Volvemos a crear todas las entradas
            Dim nodo As TreeNode
            For Each nodo In tvMenUsuario.Nodes
                Call RutuinaGuardarUsuario(nodo)
            Next
            cambios = False
            MsgBox("Estructura y PERMISOS DE USUARIO guardados correctamente")
            lbInforma.Text = "PERMISOS DE USUARIO"
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call PantallaGeneral.CargarMenus()
        Me.Close()
    End Sub

    Private Sub bCopiarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCopiarPerfil.Click
        If lvPersonal.SelectedItems.Count > 0 And lvPerfiles.SelectedItems.Count > 0 And iidUsuario > 0 Then
            If lbInforma.Text = "PERMISOS DE USUARIO" Then
                If MsgBox("¿Eliminar los permisos personalizados y asignar los del perfil " & lvPerfiles.SelectedItems(0).SubItems(1).Text & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    funcMEU.borrarUsuario(iidUsuario)
                    funcMPU.borrar(iidUsuario)
                    Call CargarArbolUsuario()
                End If

            End If
         
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub lvPerfiles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPerfiles.Click
        'Al pulsar en un perfil, se muestran los permisos correspondientes al perfil estándar y se cargan los usuarios que corresponden al perfil.
        If lvPerfiles.SelectedItems.Count > 0 Then
            semaforo = False

            tvMenuPerfil.Enabled = True
            bGuardarPerfil.Enabled = True
            iidPerfil = lvPerfiles.SelectedItems(0).Text
            Call CargarArbolPerfil()
            bGuardarPerfil.Enabled = True
            gbUsuario.Enabled = True
            Call IntroducirPersonal()
            tvMenUsuario.Nodes.Clear()
            bGuardarUsuario.Enabled = False
            bCopiarPerfil.Enabled = False
            listaCambiosPerfil = New List(Of IDComboBox)
            listaCambiosPerfilParam = New List(Of IDComboBox3)
            cambios = False
            semaforo = True
        End If

    End Sub




    Private Sub lvPersonal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPersonal.Click

        If lvPersonal.SelectedItems.Count > 0 Then
            tvMenuPerfil.Enabled = False
            bGuardarPerfil.Enabled = False
            iidUsuario = lvPersonal.SelectedItems(0).Text
            Call CargarArbolUsuario()
            bGuardarUsuario.Enabled = True
            bCopiarPerfil.Enabled = True
            cambios = False

        End If
    End Sub


    Private Sub tvMenuPerfil_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenuPerfil.AfterCheck
        If semaforo Then
            If lvPerfiles.SelectedItems.Count > 0 Then
                If e.Node.Checked Then
                    If e.Node.Level > 0 Then
                        e.Node.Parent.Checked = True
                        If e.Node.Name = "0" Then
                            listaCambiosPerfilParam.Add(New IDComboBox3(e.Node.Parent.Name, e.Node.Text, True))
                        Else
                            listaCambiosPerfil.Add(New IDComboBox(e.Node.Name, True))
                        End If
                        listaCambiosPerfil.Add(New IDComboBox(e.Node.Parent.Name, True))
                    End If
                Else
                    If e.Node.Name = "0" Then
                        listaCambiosPerfilParam.Add(New IDComboBox3(e.Node.Parent.Name, e.Node.Text, False))
                    Else
                        listaCambiosPerfil.Add(New IDComboBox(e.Node.Name, False))
                    End If
                    For Each nodo As TreeNode In e.Node.Nodes
                        nodo.Checked = False
                        If nodo.Name = "0" Then
                            listaCambiosPerfilParam.Add(New IDComboBox3(nodo.Parent.Name, nodo.Text, False))
                        Else
                            listaCambiosPerfil.Add(New IDComboBox(nodo.Name, False))
                        End If

                    Next
                End If
                cambios = True
            End If
        End If
    End Sub



    Private Sub tvMenuUsuario_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMenUsuario.AfterCheck
        If semaforo Then
            If lvPersonal.SelectedItems.Count > 0 Then
                If e.Node.Checked Then
                    If e.Node.Level > 0 Then
                        e.Node.Parent.Checked = True
                    End If
                Else
                    For Each nodo As TreeNode In e.Node.Nodes
                        nodo.Checked = False
                    Next
                End If
                cambios = True
            End If
        End If
    End Sub


    Private Sub tvMenUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMenUsuario.Click
        If iidUsuario > 0 Then
            'Borramos los parámetros del usuario
            funcMPU.borrar(iidUsuario)
            'Borramos las entradas de menu del perfil
            funcMEU.borrarUsuario(iidUsuario)
            'Volvemos a crear todas las entradas
            Dim nodo As TreeNode
            For Each nodo In tvMenUsuario.Nodes
                Call RutuinaGuardarUsuario(nodo)
            Next
            cambios = False
            ' MsgBox("Estructura y PERMISOS DE USUARIO guardados correctamente")
            lbInforma.Text = "PERMISOS DE USUARIO"
        End If
    End Sub





    Private Sub tvMenuPerfil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMenuPerfil.Click
        If iidPerfil > 0 Then
            'Borramos los parámetros del perfil
            funcMPP.borrar(iidPerfil)
            'Borramos las entradas de menu del perfil
            funcMEP.borrar(iidPerfil)
            'Volvemos a crear todas las entradas
            Dim nodo As TreeNode
            For Each nodo In tvMenuPerfil.Nodes
                Call RutuinaGuardarPerfil(nodo)
            Next
            Call PropagaPerfil()
            lbInforma.Text = ""
            lvPersonal.SelectedItems.Clear()
            tvMenUsuario.Nodes.Clear()
            iidUsuario = 0
            cambios = False
            'MsgBox("Estructura y PERMISOS DE PERFIL guardados correctamente")
        End If
    End Sub
#End Region

End Class

