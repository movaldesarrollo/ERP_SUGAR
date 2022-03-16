Public Class lbBusquedaArticulo

#Region "VARIABLES"

    Dim funcAR As New FuncionesArticulos
    Dim funcTI As New FuncionesTiposArticulo
    Dim funcSP As New FuncionessubTiposArticulo
    Dim funcTC As New FuncionesTipoCompra
    Dim funcAP As New FuncionesArticulosProv
    Dim funcPR As New funcionesProveedores
    Dim funcAL As New FuncionesAlmacenes
    Dim funcFA As New FuncionesFamilias
    Dim funcSF As New FuncionessubFamilias
    Dim funcSE As New FuncionesSecciones
    Dim funcES As New FuncionesEscandallos
    Dim funcCE As New FuncionesConceptosEscandallos
    Dim iidTipoArticulo As Integer
    Dim iidsubTipoArticulo As Integer
    Dim iidFamilia As Integer
    Dim iidTipoCompra As Integer
    Public iidArticulo As String
    Dim vSoloLectura As Boolean
    Dim sBusqueda As String
    Dim Orden As String = ""
    Dim Direccion As String
    Dim modo As String
    Dim iidArticuloProv As Integer
    Dim iidProveedor As Integer
    Dim semaforo As Boolean
    Dim colorInactivo As Color
    Private columna As Integer
    Dim Articulos As List(Of Integer)
    Dim VerCostes As Boolean
    Dim aviso As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean

#End Region

#Region "PROPIEDADES"

    Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property

    Property pidArticuloProv() As Integer
        Get
            Return iidArticuloProv
        End Get
        Set(ByVal value As Integer)
            iidArticuloProv = value
        End Set
    End Property

    Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
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


#End Region

#Region "EVENTOS"

    Private Sub BusquedaArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbBuscando.Visible = False

        'Configuramos la pantalla.
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        'Comprobamos permisos
        Dim funcPE As New FuncionesPersonal
        VerCostes = funcPE.Parametro(Inicio.vIdUsuario, "BusquedaArticulo", "VER COSTES")
        aviso = False
        Articulos = New List(Of Integer)

        BuscarAhora = False
        'AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False
        Dim tt As New ToolTip
        tt.InitialDelay = 0
        tt.SetToolTip(busquedaLibre, "Busca en Articulo-Cliente y Articulo-Proveedor")
        colorInactivo = Color.Gray
        cbTipo.Sorted = True
        cbSubTipo.Sorted = True
        semaforo = True
        ckComprable.Checked = False
        ckVendible.Checked = False
        ckSubEnsamblado.Checked = False
        ckEscandallo.Checked = False
        ckProduccionSeparada.Checked = False
        ckConNumSerie.Checked = False
        ckOpcion.Checked = False
        ckBajas.Checked = False
        If modo = "MP" Then
            ckMateriasPrima.Checked = True
            ckMateriasPrima.Enabled = False
            Me.Text = "BÚSQUEDA DE MATERIAS PRIMAS"
        Else
            ckMateriasPrima.Checked = False
        End If

        If modo = "ESCANDALLO" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS CON ESCANDALLO"
            ckEscandallo.Checked = True
            ckEscandallo.Enabled = False
        End If
        If modo = "CONCEPTO" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS VENDIBLES"
            ckVendible.Checked = True
            ckBajas.Checked = False
            ckBajas.Enabled = False
            ckVendible.Enabled = False
        End If
        If modo = "COMPRABLE" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS COMPRABLES"
            ckComprable.Checked = True
            ckBajas.Checked = False
            ckBajas.Enabled = False
            ckComprable.Enabled = False
        End If
        If modo = "ALB.PROVEEDOR" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS COMPRABLES"
            ckComprable.Checked = True
            ckBajas.Checked = False
            ckBajas.Enabled = False
            ckComprable.Enabled = False
        End If
        If modo = "OPCIONES" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS OPCIONES"
            ckBajas.Checked = False
            ckBajas.Enabled = False
            ckOpcion.Checked = True
            ckOpcion.Enabled = False
        End If

        If iidProveedor > 0 Then
            Me.Text = Me.Text & " DE " & UCase(funcPR.campoProveedor(iidProveedor))
            cbProveedor.Text = funcPR.campoProveedor(iidProveedor)
            cbProveedor.Enabled = (modo = "ALB.PROVEEDOR")  'En caso de llamar la búsqueda desde gestión Alb.Proveedor, preasignamos el proveedor pero permitimos cambiarlo
        End If
        bNuevo.Enabled = Not vSoloLectura
        Orden = "Articulo"
        Direccion = "ASC"

        If ckMateriasPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
            lbTipo.Text = "FAMILIA"
            lbSubTipo.Text = "SUBFAMILIA"
            lvArticulos.Columns(4).Text = "FAMILIA"
            lvArticulos.Columns(5).Text = "SUBFAMILIA"
            Call IntroducirFamilias()
            Call IntroducirSubFamilias()
        Else
            lbTipo.Text = "TIPO"
            lbSubTipo.Text = "SUBTIPO"
            lvArticulos.Columns(4).Text = "TIPO"
            lvArticulos.Columns(5).Text = "SUBTIPO"
            Call IntroducirTiposArticulo()
            Call IntroducirSubTiposArticulo()
        End If

        Call introducirProveedores()

        Call IntroducirAlmacenes()

        Call IntroducirSecciones()

        If iidProveedor > 0 Then

            cbProveedor.Text = funcPR.campoProveedor(iidProveedor)

        End If

    End Sub

#End Region

#Region "INICIAIZACIÓN"

    'Carga los tipos de articulos.
    Private Sub IntroducirTiposArticulo()
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosTipoArticulo) = funcTI.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoArticulo, dts.gidTipoArticulo))
        Next
    End Sub

    'Carga las familias
    Private Sub IntroducirFamilias()
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
        Dim dts As DatosFamilia
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gFamilia, dts.gidFamilia))
        Next
    End Sub

    'Carga las subfamilias.
    Private Sub IntroducirSubFamilias()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbSubTipo.Items.Clear()
        Dim lista As List(Of String) = funcSF.Listar(True)
        For Each item In lista
            cbSubTipo.Items.Add(item)
        Next
    End Sub

    'Carga las secciones.
    Private Sub IntroducirSecciones()
        cbSeccion.Items.Clear()
        Dim lista As List(Of DatosSeccion) = funcSE.Mostrar(True)
        Dim dts As DatosSeccion
        For Each dts In lista
            cbSeccion.Items.Add(New IDComboBox(dts.gSeccion, dts.gidSeccion))
        Next
    End Sub

    'Carga los proveedores.
    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()

            Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
            Dim dts As datosProveedor
            For Each dts In lista
                cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Carga los almacenes.
    Private Sub IntroducirAlmacenes()
        cbAlmacen.Items.Clear()
        Dim lista As List(Of DatosAlmacen) = funcAL.Mostrar(True)
        Dim dts As DatosAlmacen
        For Each dts In lista
            cbAlmacen.Items.Add(New IDComboBox(dts.gAlmacen, dts.gidAlmacen))
        Next
    End Sub

#End Region

#Region "METODOS Y FUNCIONES"

    'Parametros de busqueda
    Private Sub Busqueda()

        lbBuscando.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        sBusqueda = ""

        'ID proveedor
        If iidProveedor <> 0 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            If codArticuloProv.Text = "" Then
                sBusqueda = sBusqueda & " (Articulos.idProveedor = " & iidProveedor & " OR Articulos.idArticulo in (select idArticulo from Articulos_Proveedor where Activo = 1 and idProveedor = " & iidProveedor & ")) "
            Else
                sBusqueda = sBusqueda & " Articulos.idArticulo in (select idArticulo from Articulos_Proveedor where Activo = 1 and idProveedor = " & iidProveedor & " and codArticuloProv like '" & codArticuloProv.Text & "%' )"
            End If
        End If



        'Articulo
        If Articulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Articulo like '%" & Replace(Articulo.Text, "'", "''") & "%'"
        End If

        'Tipo Seleccionado
        If cbTipo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            If ckMateriasPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                sBusqueda = sBusqueda & " Articulos.idFamilia = " & cbTipo.SelectedItem.itemdata
            Else
                sBusqueda = sBusqueda & " Articulos.idTipoArticulo = " & cbTipo.SelectedItem.itemdata
            End If
        End If

        'Subtipo Seleccionado
        If cbSubTipo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            If ckMateriasPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                sBusqueda = sBusqueda & " SubFamilia = '" & cbSubTipo.Text & "' "
            Else
                sBusqueda = sBusqueda & " SubTipoArticulo = '" & cbSubTipo.Text & "' "
            End If
        End If

        'Almacen Seleccionado
        If cbAlmacen.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.idAlmacen = " & cbAlmacen.SelectedItem.itemdata
        End If

        'codigo articulo seleccionado.
        If codArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " replace(Articulos.codArticulo,' ','') like '" & Replace(codArticulo.Text, " ", "") & "%'"
        End If

        'seccion seleccionada
        If cbSeccion.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.idseccion = " & cbSeccion.SelectedItem.itemdata
        End If

        'Check materia prima marcado
        If ckMateriasPrima.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.MateriaPrima = 1 "
        End If

        'Check escandallo  marcado
        If ckEscandallo.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Escandallo = 1 "
        End If

        'Check produccion separada  marcado
        If ckProduccionSeparada.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.ProduccionSeparada = 1 "
        End If

        'Check con numero de serie  marcado
        If ckConNumSerie.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.conNumSerie = 1 "
        End If

        'Check opcion marcado
        If ckOpcion.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Opcion = 1 "
        End If

        'Check ensamblado marcado
        If ckSubEnsamblado.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.subEnsamblado = 1 "
        End If

        'Check baja marcado
        If ckBajas.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Activo = 1 "
        End If

        'Check comprable  marcado
        If ckComprable.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Comprable = 1 "
        End If

        'Check vendible  marcado
        If ckVendible.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Vendible = 1 "
        End If

        'observaciones 
        If Observaciones.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Observaciones like '%" & Replace(Observaciones.Text, "'", "''") & "%' "
        End If

        'descripcion
        If Descripcion.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Descripcion like '%" & Replace(Descripcion.Text, "'", "''") & "%' "
        End If

        'Proveedor
        If cbProveedor.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Proveedores.nombrecomercial = '" & Trim(cbProveedor.Text) & "' "
        End If

        'CODProveedor
        If codArticuloProv.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Proveedores.codproveedor = '" & Trim(codArticuloProv.Text) & "' "
        End If

        'Busqueda libre en articulos, codigo articulo, articulos proveedor y codigo articulo proveedor.
        If busquedaLibre.Text <> "" Then
            Dim SinApostrofe = Replace(busquedaLibre.Text, "'", "''")
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " (Articulos.idArticulo in(select idArticulo from ArticuloCliente where ArticuloCli like '%" & SinApostrofe & "%' OR codArticuloCli like '" & SinApostrofe & "%' ) "
            sBusqueda = sBusqueda & " OR  Articulos.idArticulo in ( select idArticulo from Articulos_Proveedor where nombre like '%" & SinApostrofe & "%' OR codArticuloProv like '" & SinApostrofe & "%' ))"
        End If

        Call actualiza_lvArticulos()

        lbBuscando.Visible = False
        Me.Cursor = Cursors.Default

    End Sub

    'Actualiza los articulos
    Private Sub actualiza_lvArticulos()
        If semaforo Then
            Try
                lvArticulos.Items.Clear()
                Articulos.Clear()

                lbAviso.Visible = False
                aviso = False
                Dim lista As List(Of DatosArticulo)
                lista = funcAR.Busqueda(sBusqueda, Orden & If(Orden = "", "", " " & Direccion))
                Dim dts As DatosArticulo
                For Each dts In lista
                    If dts.gidArticulo > 0 Then
                        If ckStockMinimo.Checked = False Or (ckStockMinimo.Checked And (dts.gCantidadStock < dts.gStockMinimo)) Then
                            Articulos.Add(dts.gidArticulo)
                            With lvArticulos.Items.Add(dts.gidArticulo)
                                .SubItems.Add(dts.gcodArticulo)
                                .SubItems.Add(dts.gSeccion)
                                .SubItems.Add(dts.gTipoCompra)
                                If ckMateriasPrima.Checked Then
                                    .SubItems.Add(dts.gFamilia)  '4
                                    .SubItems.Add(dts.gSubFamilia) '5
                                Else
                                    .SubItems.Add(dts.gTipoArticulo)  '4
                                    .SubItems.Add(dts.gSubTipoArticulo) '5
                                End If
                                .SubItems.Add(dts.gArticulo)  '6
                                If VerCostes Then
                                    .SubItems.Add(FormatNumber(dts.gPrecioUnitarioC, 4) & dts.gSimboloC) '7
                                Else
                                    .SubItems.Add("") '7
                                End If

                                .SubItems.Add(FormatNumber(dts.gPrecioUnitarioV, 2) & dts.gSimboloV) '8
                                .SubItems.Add(FormatNumber(dts.gCantidadStock, 2) & dts.gTipoUnidad) '9
                                .SubItems.Add(FormatNumber(dts.gStockMinimo, 2) & dts.gTipoUnidad) '10
                                .SubItems.Add(dts.gidArticuloProv) '11
                                .SubItems.Add(dts.gcodArticuloProv) '12
                                .SubItems.Add(dts.gObservaciones)
                                If dts.gActivo Then
                                    If dts.gCantidadStock < dts.gStockMinimo Then
                                        .ForeColor = Color.Red
                                    Else
                                        .ForeColor = Color.Black
                                    End If
                                Else
                                    .ForeColor = colorInactivo
                                End If
                                If dts.gEscandallo Then
                                    If Not funcES.ExisteEscandalloRealmente(dts.gidArticulo) Then
                                        .BackColor = Color.LightPink
                                        aviso = True
                                    End If
                                End If
                            End With
                        End If
                    End If
                Next
                Contador.Text = lvArticulos.Items.Count
                If aviso Then
                    lbAviso.BackColor = Color.LightPink
                    lbAviso.Visible = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    'Actualizar linea.
    Private Sub ActualizaLinealv(ByVal indice As Integer)
        iidArticulo = lvArticulos.Items(indice).Text
        Dim aviso As Boolean = False
        Dim dts As DatosArticulo
        dts = funcAR.Mostrar1(iidArticulo)
        If ckBajas.Checked = False And dts.gActivo = False Then
            lvArticulos.Items.RemoveAt(indice)
        Else
            With lvArticulos.Items(indice)
                .SubItems(1).Text = dts.gcodArticulo
                .SubItems(2).Text = dts.gSeccion
                .SubItems(3).Text = dts.gTipoCompra
                If dts.gMateriaPrima Then
                    .SubItems(4).Text = dts.gFamilia
                    .SubItems(5).Text = dts.gSubFamilia
                Else
                    .SubItems(4).Text = dts.gTipoArticulo
                    .SubItems(5).Text = dts.gSubTipoArticulo
                End If
                .SubItems(6).Text = dts.gArticulo
                If VerCostes Then
                    .SubItems(7).Text = FormatNumber(dts.gPrecioUnitarioC, 4) & dts.gSimboloC
                Else
                    .SubItems(7).Text = ""
                End If
                .SubItems(8).Text = FormatNumber(dts.gPrecioUnitarioV, 2) & dts.gSimboloV
                .SubItems(9).Text = FormatNumber(dts.gCantidadStock, 2) & dts.gTipoUnidad
                .SubItems(10).Text = FormatNumber(dts.gStockMinimo, 2) & dts.gTipoUnidad
                .SubItems(11).Text = dts.gidArticuloProv
                .SubItems(12).Text = dts.gcodArticuloProv
                .SubItems(13).Text = dts.gObservaciones
                If dts.gActivo Then
                    If dts.gCantidadStock < dts.gStockMinimo Then
                        .ForeColor = Color.Red
                    Else
                        .ForeColor = Color.Black
                    End If
                Else
                    .ForeColor = colorInactivo
                End If
                If dts.gEscandallo Then
                    If Not funcES.ExisteEscandalloRealmente(dts.gidArticulo) Then
                        .BackColor = Color.LightPink
                        aviso = True
                    Else
                        .BackColor = lvArticulos.BackColor
                    End If
                End If
            End With
        End If
        If aviso Then
            lbAviso.BackColor = Color.LightPink
            lbAviso.Visible = True
        End If
    End Sub

    'Metodo que carga los subtipos de articulo.
    Private Sub IntroducirSubTiposArticulo()
        Try
            If cbTipo.Text <> "" Then
                iidTipoArticulo = cbTipo.SelectedItem.itemdata
            End If

            If iidTipoArticulo > 0 Then
                cbSubTipo.Text = ""
                cbSubTipo.SelectedIndex = -1
                cbSubTipo.Items.Clear()
                Dim lista As List(Of DatosSubTipoArticulo) = funcSP.Mostrar(iidTipoArticulo, 0, True)
                Dim dts As DatosSubTipoArticulo
                For Each dts In lista
                    cbSubTipo.Items.Add(New IDComboBox(dts.gSubTipoArticulo, dts.gidSubTipoArticulo))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Limpoa el formulario
    Public Sub limpiar()

        semaforo = False
        lvArticulos.Items.Clear()
        iidArticulo = 0
        Articulo.Text = ""
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbAlmacen.Text = ""
        cbAlmacen.SelectedIndex = -1
        cbSeccion.Text = ""
        cbSeccion.SelectedIndex = -1
        Observaciones.Text = ""
        Descripcion.Text = ""
        iidTipoArticulo = 0
        iidFamilia = 0
        codArticulo.Text = ""
        codArticuloProv.Text = ""
        busquedaLibre.Text = ""
        'Deschequeamos todo excepto lo que esté desabilitado porque hemos entrado en un modo especial
        If ckMateriasPrima.Enabled Then ckMateriasPrima.Checked = False
        If ckEscandallo.Enabled Then ckEscandallo.Checked = False
        If ckBajas.Enabled Then ckBajas.Checked = False
        If ckComprable.Enabled Then ckComprable.Checked = False
        If ckVendible.Enabled Then ckVendible.Checked = False
        If ckSubEnsamblado.Enabled Then ckSubEnsamblado.Checked = False
        If ckOpcion.Enabled Then ckOpcion.Checked = False
        If ckStockMinimo.Enabled Then ckStockMinimo.Checked = False
        If ckProduccionSeparada.Enabled Then ckProduccionSeparada.Checked = False
        If ckConNumSerie.Enabled Then ckConNumSerie.Checked = False
        If cbProveedor.Enabled Then
            cbProveedor.Text = ""
            cbProveedor.SelectedIndex = -1
            iidProveedor = 0
        End If
        Orden = " Articulo"
        semaforo = True
        lvArticulos.Items.Clear()

    End Sub

#End Region

#Region "BOTONES"

    'Muestra el inventario.
    Private Sub bInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim gg As New gestionInventarios

        gg.ShowDialog()

    End Sub

    'Boton limpiar.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    'Realiza la busqueda al pulsar el boton buscar.
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        Busqueda()

    End Sub

    'Nuevo artículo.
    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GP As New GestionArticulo
        GP.pidArticulo = 0
        GP.SoloLectura = vSoloLectura
        GP.Show()
    End Sub

    'Imprimir informe.
    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        InformeListadoArticulos.verInforme(sBusqueda, Orden & If(Orden = "", "", " " & Direccion), ckStockMinimo.Checked, VerCostes)
        InformeListadoArticulos.ShowDialog()
    End Sub

    'Salir del formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "EVENTOS"

    'Abre el articulo
    Private Sub lvArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulos.DoubleClick
        Select Case modo
            Case "A"
                If lvArticulos.SelectedItems.Count > 0 Then
                    Dim indice As Integer = lvArticulos.SelectedIndices(0)
                    iidArticulo = lvArticulos.Items(indice).Text
                    Dim CA As New GestionArticulo
                    CA.pidArticulo = iidArticulo
                    CA.SoloLectura = vSoloLectura
                    CA.pArticulos = Articulos
                    CA.pIndice = indice
                    CA.pVerCostes = VerCostes
                    CA.ShowDialog()

                    Dim lista As List(Of DatosArticulo)
                    Dim sBusquedaX As String = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                    sBusquedaX = sBusquedaX & " Articulos.idArticulo = " & iidArticulo


                    lista = funcAR.Busqueda(sBusquedaX, Orden & If(Orden = "", "", " " & Direccion))

                    If lista.Count > 0 Then
                        'Si el artículo sigue respondiendo a la búsqueda, lo actualizamos
                        Call ActualizaLinealv(indice)
                        lvArticulos.EnsureVisible(indice)
                    Else
                        'Si no lo borramos
                        lvArticulos.Items.RemoveAt(indice)
                    End If

                End If
            Case "P", "MP", "ESCANDALLO", "CONCEPTO", "COMPRABLE", "ALB.PROVEEDOR"

                If lvArticulos.SelectedItems.Count > 0 Then
                    iidArticulo = lvArticulos.SelectedItems(0).Text
                    iidArticuloProv = lvArticulos.SelectedItems(0).SubItems(11).Text
                    If cbProveedor.SelectedIndex <> -1 Then
                        iidArticuloProv = funcAP.ArticuloExiste(iidArticulo, iidProveedor)
                    End If
                    Me.Close()
                End If
        End Select
    End Sub

    'Si es un enter inicia la busqueda.
    Private Sub Articulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Descripcion.KeyDown, Observaciones.KeyDown, codArticulo.KeyDown, _
    Articulo.KeyDown, Descripcion.KeyDown, busquedaLibre.KeyDown, ckBajas.KeyDown, cbAlmacen.KeyDown, cbProveedor.KeyDown, cbSeccion.KeyDown, cbSubTipo.KeyDown, _
    cbTipo.KeyDown, ckComprable.KeyDown, ckConNumSerie.KeyDown, ckEscandallo.KeyDown, ckMateriasPrima.KeyDown, ckOpcion.KeyDown, ckProduccionSeparada.KeyDown, ckStockMinimo.KeyDown, _
    ckSubEnsamblado.KeyDown, ckVendible.KeyDown, codArticuloProv.KeyDown

        If e.KeyCode = Keys.Enter Then

            Busqueda()

        End If

    End Sub

    'Orden de columnas
    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvArticulos.ColumnClick
        If e.Column = columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 


        Select Case e.Column
            Case 0
                Orden = "idArticulo"
            Case 1
                Orden = "codArticulo"
            Case 2
                Orden = "Seccion"
            Case 3
                Orden = "TipoCompra"
            Case 4
                If ckMateriasPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                    Orden = "Familia"
                Else
                    Orden = "TipoArticulo"
                End If
            Case 5
                If ckMateriasPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                    Orden = "subFamilia"
                Else
                    Orden = "SubTipoArticulo"
                End If
            Case 6
                Orden = "Articulo"
                'Case 7
                '    Orden = "PrecioC"
                'Case 8
                '    Orden = "PrecioV"
            Case 9
                Orden = "CantidadStock"
            Case 10
                Orden = " StockMinimo"
            Case 13
                Orden = " Articulos.Observaciones"
            Case Else
                Orden = "Articulo"
        End Select


        columna = e.Column

        Call actualiza_lvArticulos()

    End Sub

    'Cambio materias primas check
    Private Sub ckMateriasPrima_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckMateriasPrima.CheckedChanged, ckEscandallo.CheckedChanged, ckOpcion.CheckedChanged
        If semaforo Then

            If ckMateriasPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                lbTipo.Text = "FAMILIA"
                lbSubTipo.Text = "SUBFAMILIA"
                lvArticulos.Columns(4).Text = "FAMILIA"
                lvArticulos.Columns(5).Text = "SUBFAMILIA"
                Call IntroducirFamilias()
                Call IntroducirSubFamilias()
            Else
                lbTipo.Text = "TIPO"
                lbSubTipo.Text = "SUBTIPO"
                lvArticulos.Columns(4).Text = "TIPO"
                lvArticulos.Columns(5).Text = "SUBTIPO"
                Call IntroducirTiposArticulo()
            End If
        End If
    End Sub

    'Al cambiar el tipo de articulo carga los subtipos.
    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged
        If cbTipo.SelectedIndex <> -1 Then
            iidTipoArticulo = cbTipo.SelectedItem.itemdata
            Call IntroducirSubTiposArticulo()
        End If
    End Sub

#End Region

End Class





'Private Sub IntroducirSubTiposArticulo()
'    Dim funcT As New FuncionessubTiposArticulo
'    cbSubTipo.Items.Clear()
'    Dim lista As List(Of String) = funcT.Listar(True)
'    For Each item In lista
'        cbSubTipo.Items.Add(item)
'    Next
'End Sub

'Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
'    If BuscarAhora Then
'        BuscarAhora = False
'        retardo.Enabled = False
'        Call Busqueda()
'    End If
'End Sub

'Private Sub idArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubTipo.SelectedIndexChanged, cbAlmacen.SelectedIndexChanged, cbSeccion.SelectedIndexChanged
'    If semaforo Then Call Busqueda()
'End Sub

'Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Descripcion.TextChanged, Observaciones.TextChanged, codArticulo.TextChanged, Articulo.TextChanged, Descripcion.TextChanged, busquedaLibre.TextChanged
'    If semaforo Then
'        BuscarAhora = True
'        retardo.Enabled = True
'    End If

'End Sub

'Private Sub codArticuloProv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codArticuloProv.TextChanged
'    If semaforo And iidProveedor <> 0 Then
'        BuscarAhora = True
'        retardo.Enabled = True
'    End If
'End Sub

'Private Sub cbProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectionChangeCommitted
'    iidProveedor = If(cbProveedor.SelectedIndex = -1, 0, cbProveedor.SelectedItem.itemdata)
'    Call Busqueda()
'End Sub

'Private Sub ckStockMinimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckStockMinimo.CheckedChanged, ckBajas.CheckedChanged, ckOpcion.CheckedChanged, ckConNumSerie.CheckedChanged, ckProduccionSeparada.CheckStateChanged

'    Call Busqueda()

'End Sub

'Private Sub ckComprable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged, ckSubEnsamblado.CheckedChanged, ckVendible.CheckedChanged, ckComprable.CheckedChanged
'    If semaforo Then Call Busqueda()
'End Sub
