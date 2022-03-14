Public Class BusquedaPeticionInternaMaterial

    Private funcCI As New FuncionesConceptosPedidosInternos
    Private funcAR As New FuncionesArticulos
    Private funcFA As New FuncionesFamilias
    Private funcSF As New FuncionessubFamilias
    Private funcES As New FuncionesEstados
    Private vSoloLectura As Boolean
    Private dtsAR As DatosArticulo
    Private Orden As String
    Private Direccion As String
    Private iidFamilia As Integer
    Private Columna As Integer
    Private sBusquedaArticulos As String
    Private sBusquedaConceptos As String
    Private semaforo As Boolean
    Private AtiendePeticiones As Boolean
    Private cmConceptos As ContextMenu
    Private EstadoNuevo As DatosEstado
    Private EstadoLeido As DatosEstado
    Private EstadoProcesado As DatosEstado
    Private EstadoAnulado As DatosEstado
    Private EstadoRecibido As DatosEstado
    Private EstadoParcial As DatosEstado
    Private ep1 As New ErrorProvider
    Private IDsConceptos As List(Of Long)




    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub PeticionInternaMaterial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 50
        Me.Location = New Point(Me.Location.X, 20)
        'PERMISOS
        Dim funcPE As New FuncionesPersonal
        AtiendePeticiones = funcPE.Parametro(Inicio.vIdUsuario, "PeticionesInternasMaterial", "ATENDER PETICION")
        If AtiendePeticiones Then
            cmConceptos = New ContextMenu
            cmConceptos.MenuItems.Add("Marcar como leido", New System.EventHandler(AddressOf Me.OnClickcm_MarcarLeido))
            cmConceptos.MenuItems.Add("Marcar como recibido", New System.EventHandler(AddressOf Me.OnClickcm_MarcarRecibido))
            cmConceptos.MenuItems.Add("Pedido a Proveedor", New System.EventHandler(AddressOf Me.OnClickcm_PedidoProveedor))
            cmConceptos.MenuItems.Add("Borrar linea", New System.EventHandler(AddressOf Me.OnClickcm_Borrar))

            lvConceptos.ContextMenu = cmConceptos
        End If
        semaforo = False

        Direccion = "ASC"
        Orden = " idConcepto "
        Columna = 0
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        EstadoNuevo = funcES.EstadoEspera("C.PEDIDO_INT")
        EstadoLeido = funcES.EstadoEnCurso("C.PEDIDO_INT")
        EstadoProcesado = funcES.EstadoTraspasado("C.PEDIDO_INT")
        EstadoAnulado = funcES.EstadoAnulado("C.PEDIDO_INT")
        EstadoRecibido = funcES.EstadoCPedidoINT("RECIBIDO")
        EstadoParcial = funcES.EstadoCPedidoINT("PARCIAL")
        Call introducirEstados()
        Call LimpiarEdicion()
        Call introducirFamilias()
        Call IntroducirSubFamilias()
        Call BusquedaConceptos()
        semaforo = True
    End Sub

    Protected Sub OnClickcm_MarcarLeido(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            funcCI.actualizarEstado(iidConcepto, EstadoLeido.gidEstado)
            lvConceptos.Items(indice).SubItems(7).Text = EstadoLeido.gEstado
        End If
    End Sub

    Protected Sub OnClickcm_MarcarRecibido(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            Dim iidArticulo As Integer = funcCI.CampoidArticulo(iidConcepto)
            If iidArticulo = 0 Then
                funcCI.actualizarEstado(iidConcepto, EstadoRecibido.gidEstado)
                lvConceptos.Items(indice).SubItems(7).Text = EstadoRecibido.gEstado
            Else
                MsgBox("No se puede marcar com recibido, se marcará automáticamente al recibir el pedido del proveedor")
            End If

        End If
    End Sub



    Protected Sub OnClickcm_PedidoProveedor(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            Dim dts As DatosConceptoPedidoInterno = funcCI.mostrar1(iidConcepto)
            If dts.gidArticulo = 0 Then
                MsgBox("Artículo no definido")
            Else
                Dim EstadoProcesado As DatosEstado = funcES.EstadoTraspasado("C.PEDIDO_INT")
                Dim GG As New subPedidoProvDirecto
                GG.pidArticulo = dts.gidArticulo
                GG.pidProveedor = 0
                GG.SoloLectura = vSoloLectura
                GG.pCantidad = dts.gCantidad
                GG.ShowDialog()
                If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                    funcCI.actualizaidConceptoPedidoProv(iidConcepto, GG.pidConceptoPedidoProv)
                    funcCI.actualizarEstado(iidConcepto, EstadoProcesado.gidEstado)
                    lvConceptos.Items(indice).SubItems(7).Text = EstadoProcesado.gEstado
                End If

            End If
        End If
    End Sub

    Protected Sub OnClickcm_Borrar(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            Call BorrarConcepto(indice)
        End If
    End Sub


#Region "INICIALIZACIÓN"

    Public Sub LimpiarEdicion()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        dtsAR = New DatosArticulo
        Observaciones.Text = ""
        sBusquedaArticulos = ""
        sBusquedaConceptos = ""
        cbFamilia.Text = ""
        cbFamilia.SelectedIndex = -1
        cbSubFamilia.Text = ""
        cbSubFamilia.SelectedIndex = -1
        cbEstado.Text = EstadoNuevo.gEstado
        lvConceptos.SelectedItems.Clear()
        ep1.Clear()
    End Sub

    Private Sub introducirFamilias()
        Try
            cbFamilia.Items.Clear()
            iidFamilia = 0
            Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
            Dim dts As DatosFamilia
            For Each dts In lista
                cbFamilia.Items.Add(dts)
            Next
            iidFamilia = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IntroducirSubFamilias()

        cbSubFamilia.Text = ""
        cbSubFamilia.SelectedIndex = -1
        cbSubFamilia.Items.Clear()
        Dim lista As List(Of String) = funcSF.Listar(True)
        For Each item In lista
            cbSubFamilia.Items.Add(item)
        Next

    End Sub

   

    Private Sub introducirEstados()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("C.PEDIDO_INT")
        cbEstado.Items.Clear()
        cbEstado.Items.Add("TODOS NO RECIBIDOS")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub


#End Region


#Region "CARGAR DATOS"


    Private Sub IntroducirArticulos()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        Dim lista As List(Of IDComboBox3) = funcAR.Buscar(sBusquedaArticulos, Orden & Direccion)
        For Each dts In lista
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
            cbArticulo.Items.Add(dts)
        Next
    End Sub



#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub BusquedaArticulos()

        sBusquedaArticulos = " AND Comprable = 1 "

        If cbSubFamilia.Text <> "" Then
            sBusquedaArticulos = sBusquedaArticulos & IIf(sBusquedaArticulos = "", "", " AND ")
            sBusquedaArticulos = sBusquedaArticulos & " subFamilia = '" & cbSubFamilia.Text & "' "
        ElseIf cbFamilia.SelectedIndex <> -1 Then
            sBusquedaArticulos = sBusquedaArticulos & IIf(sBusquedaArticulos = "", "", " AND ")
            sBusquedaArticulos = sBusquedaArticulos & " Articulos.idFamilia = " & cbFamilia.SelectedItem.gidFamilia
        End If

        Call IntroducirArticulos()
    End Sub

    Private Sub BusquedaConceptos()
        sBusquedaConceptos = ""
        If cbSubFamilia.Text <> "" Then
            sBusquedaConceptos = sBusquedaConceptos & IIf(sBusquedaConceptos = "", "", " AND ")
            sBusquedaConceptos = sBusquedaConceptos & " subFamilia = '" & cbSubFamilia.Text & "' "
        ElseIf cbFamilia.SelectedIndex <> -1 Then
            sBusquedaConceptos = sBusquedaConceptos & IIf(sBusquedaConceptos = "", "", " AND ")
            sBusquedaConceptos = sBusquedaConceptos & " AR.idFamilia = " & cbFamilia.SelectedItem.gidFamilia
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusquedaConceptos = sBusquedaConceptos & IIf(sBusquedaConceptos = "", "", " AND ")
            If cbEstado.Text = "TODOS NO RECIBIDOS" Then
                sBusquedaConceptos = sBusquedaConceptos & " (CP.idEstado = " & EstadoNuevo.gidEstado & " OR CP.idEstado = " & EstadoLeido.gidEstado & " OR CP.idEstado = " & EstadoProcesado.gidEstado & ") "
            Else
                sBusquedaConceptos = sBusquedaConceptos & " CP.idEstado = " & cbEstado.SelectedItem.gidEstado
            End If
        End If
        If cbArticulo.Text <> "" Then
            sBusquedaConceptos = sBusquedaConceptos & IIf(sBusquedaConceptos = "", "", " AND ")
            sBusquedaConceptos = sBusquedaConceptos & " CP.Articulo like '%" & Replace(cbArticulo.Text, "'", "''") & "%' "
        End If
        If cbCodArticulo.Text <> "" Then
            sBusquedaConceptos = sBusquedaConceptos & IIf(sBusquedaConceptos = "", "", " AND ")
            sBusquedaConceptos = sBusquedaConceptos & " CP.codArticulo like '%" & Replace(cbCodArticulo.Text, "'", "''") & "%' "
        End If


        If Observaciones.Text <> "" Then
            sBusquedaConceptos = sBusquedaConceptos & IIf(sBusquedaConceptos = "", "", " AND ")
            sBusquedaConceptos = sBusquedaConceptos & " CP.Observaciones like '%" & Replace(Observaciones.Text, "'", "''") & "%' "
        End If

        Call ActualizarLV()
    End Sub

   
    Private Sub ActualizarLV()
        lvConceptos.Items.Clear()
        Dim lista As List(Of DatosConceptoPedidoInterno) = funcCI.Busqueda(sBusquedaConceptos, Orden)
        IDsConceptos = New List(Of Long)
        For Each dts As DatosConceptoPedidoInterno In lista
            Call NuevaLineaLV(dts)
            IDsConceptos.Add(dts.gidConcepto)
        Next
        Contador.Text = lvConceptos.Items.Count
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosConceptoPedidoInterno)
        With lvConceptos.Items.Add(" ")
            .SubItems.Add(dts.gidConcepto)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(dts.gCreacion.Date)
            .SubItems.Add(dts.gCreador)
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(dts.gObservaciones)
        End With
    End Sub


    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoPedidoInterno)
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            With lvConceptos.Items(indice)
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gArticulo
                .SubItems(4).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
                .SubItems(5).Text = dts.gCreacion.Date
                .SubItems(6).Text = dts.gCreador
                .SubItems(7).Text = dts.gEstado
                .SubItems(8).Text = dts.gObservaciones
            End With
        End If

    End Sub



#End Region



#Region "BOTONES GENERALES"

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionPeticionInternaMaterial
        GG.SoloLectura = vSoloLectura
        GG.pIDsConceptos = New List(Of Long)
        GG.ShowDialog()
        Call BusquedaConceptos()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        semaforo = False
        Call LimpiarEdicion()
        semaforo = True
        Call BusquedaConceptos()
    End Sub




    Private Sub bBorrarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim iidConcepto As Long = lvConceptos.SelectedItems(0).SubItems(1).Text
            Call BorrarConcepto(iidConcepto)
        End If
    End Sub

    Private Sub BorrarConcepto(ByVal indice As Integer)
        Dim iidConcepto As Long = lvConceptos.Items(indice).SubItems(1).Text
        Dim iidEstado As Integer = funcCI.CampoidEstado(iidConcepto)
        If AtiendePeticiones Then
            If iidEstado = EstadoRecibido.gidEstado Or iidEstado = EstadoParcial.gidEstado Then
                MsgBox("No se puede borrar una petición ya recibida")
            Else
                funcCI.borrar(iidConcepto)
                lvConceptos.Items.RemoveAt(indice)
                Contador.Text = lvConceptos.Items.Count
            End If
        Else
            If iidEstado <> EstadoNuevo.gidEstado Then
                MsgBox("No se puede borrar una petición ya atendida")
            Else
                funcCI.borrar(iidConcepto)
                lvConceptos.Items.RemoveAt(indice)
                Contador.Text = lvConceptos.Items.Count
            End If
        End If

    End Sub


#End Region


#Region "EVENTOS"


    Private Sub lvConceptos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = Columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column

            Case 1
                Orden = "idArticulo"
            Case 2
                Orden = "codArticulo"
            Case 3
                Orden = "Articulo"
            Case 4
                Orden = "Cantidad"
            Case 5
                Orden = "Creacion"
            Case 6
                Orden = "Creador"
            Case 7
                Orden = "Estado"
            Case 8
                Orden = "Observaciones"

        End Select


        Columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & Direccion
        End If
        Call BusquedaConceptos()
    End Sub

    Private Sub cbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted

        If cbFamilia.SelectedIndex > -1 Then
            iidFamilia = cbFamilia.SelectedItem.gidFamilia
            ' Call introducirSubFamilias()
            Call BusquedaArticulos()
        End If

    End Sub

    Private Sub cbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If cbSubFamilia.SelectedIndex > -1 Then
            Call BusquedaArticulos()
        End If
    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        If cbCodArticulo.SelectedIndex <> -1 Then
            dtsAR = funcAR.Mostrar1(cbCodArticulo.SelectedItem.itemdata)
            Call PresentarArticulo()
        End If
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If cbArticulo.SelectedIndex <> -1 Then
            dtsAR = funcAR.Mostrar1(cbArticulo.SelectedItem.itemdata)
            Call PresentarArticulo()
        End If
    End Sub

    Private Sub PresentarArticulo()
        cbFamilia.Text = dtsAR.gFamilia
        iidFamilia = dtsAR.gidFamilia
        Call introducirSubFamilias()
        Call BusquedaArticulos()
        cbSubFamilia.Text = dtsAR.gSubFamilia
        cbCodArticulo.Text = dtsAR.gcodArticulo
        cbArticulo.Text = dtsAR.gArticulo
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.selectall()
    End Sub


    'Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
    '    If lvConceptos.SelectedItems.Count > 0 Then
    '        semaforo = False
    '        Dim iidConcepto As Long = lvConceptos.SelectedItems(0).SubItems(1).Text
    '        Dim dts As DatosConceptoPedidoInterno = funcCI.mostrar1(iidConcepto)
    '        cbFamilia.Text = dts.gFamilia
    '        cbSubFamilia.Text = dts.gsubFamilia
    '        cbCodArticulo.Text = dts.gcodArticulo
    '        cbArticulo.Text = dts.gArticulo
    '        Cantidad.Text = FormatNumber(dts.gCantidad, 2)
    '        Observaciones.Text = dts.gObservaciones
    '        semaforo = True
    '    End If
    'End Sub

    Private Sub cbSubFamilia_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged, cbCodArticulo.TextChanged, cbArticulo.TextChanged, cbSubFamilia.SelectedIndexChanged, cbFamilia.SelectedIndexChanged, Observaciones.TextChanged
        If semaforo Then Call BusquedaConceptos()
    End Sub


    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim GG As New GestionPeticionInternaMaterial
            GG.SoloLectura = vSoloLectura
            'GG.pidConcepto = lvConceptos.SelectedItems(0).SubItems(1).Text
            GG.pIDsConceptos = IDsConceptos
            GG.pIndice = lvConceptos.SelectedIndices(0)
            GG.ShowDialog()

            If GG.DialogResult = Windows.Forms.DialogResult.Abort Then
                Call ActualizarLV()
            Else
                Dim dts As DatosConceptoPedidoInterno = funcCI.mostrar1(GG.pidConcepto)
                Call ActualizarLineaLV(dts)
            End If

        End If
    End Sub


#End Region










End Class