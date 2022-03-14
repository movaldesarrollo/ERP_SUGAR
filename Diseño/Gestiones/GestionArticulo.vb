Public Class GestionArticulo

#Region "VARIABLES"

    Private funcAR As New FuncionesArticulos
    Private funcSE As New FuncionesSecciones
    Private funcTC As New FuncionesTipoCompra
    Private funcTU As New FuncionesTiposUnidad
    Private funcST As New FuncionesStock
    Private funcAP As New FuncionesArticulosProv
    Private funcPR As New funcionesProveedores
    Private funcAL As New FuncionesAlmacenes
    Private funcTI As New FuncionesTiposArticulo
    Private funcSP As New FuncionessubTiposArticulo
    Private funcFA As New FuncionesFamilias
    Private funcSF As New FuncionessubFamilias
    Private funcMO As New FuncionesMoneda
    Private funcES As New FuncionesEscandallos
    Private funcAPR As New FuncionesArticuloPrecio
    Private funcCE As New FuncionesConceptosEscandallos
    Private funcPX As New FuncionesPreciosPorCantidad
    Private funcCL As New funcionesclientes
    Private iidTipoArticulo As Integer
    Private iidFamilia As Integer
    Private iidStock As Long
    Private G_AGeneral As Char
    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private dPrecio As Double
    Private codMonedaC As String
    Private codMonedaV As String
    Private iidUnidad As Integer
    Private dtsAR As DatosArticulo
    Private semaforo As Boolean
    Private GuardarPrecio As Boolean
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private Articulos As List(Of Integer)
    Private indiceL As Integer
    Private iidEscandallo As Integer
    Private colorInactivo As Color = Color.Gray
    Private Modo As String
    Private VerCostes As Boolean
    Private HacePedidosProv As Boolean
    Private indicePxC As Integer
    Private lvwColumnSorter As OrdenarLV
    Private lvwColumnSorterAV As OrdenarLV
    Private verClientesPropios As Boolean
    Private verFacturas As Boolean
    Dim id_articulo As Integer
    Dim id_proveedor As Integer

#End Region

#Region "PROPIEDADES"

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Property pidArticulo() As Integer
        Get
            Return idArticulo.Text
        End Get
        Set(ByVal value As Integer)
            idArticulo.Text = value
        End Set
    End Property

    Property pArticulos() As List(Of Integer)
        Get
            Return Articulos
        End Get
        Set(ByVal value As List(Of Integer))
            Articulos = value
        End Set
    End Property

    Property pIndice() As Integer
        Get
            Return indiceL
        End Get
        Set(ByVal value As Integer)
            indiceL = value
        End Set
    End Property

    Property pModo() As String
        Get
            Return Modo
        End Get
        Set(ByVal value As String)
            Modo = value
        End Set
    End Property

    Property pVerCostes() As Boolean
        Get
            Return VerCostes
        End Get
        Set(ByVal value As Boolean)
            VerCostes = value
        End Set
    End Property

#End Region

#Region "CARGA Y CIERRE"

    'Carga.
    Private Sub GestionArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            semaforo = False

            'Dimensionamos el form.
            Dim desktopSize As Size
            desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
            Me.Height = desktopSize.Height - 15
            Me.Location = New Point(Me.Location.X, 0)


            'Permisos de usuario
            iidUsuario = Inicio.vIdUsuario
            Dim funcPE As New FuncionesPersonal

            'Ver clientes propios
            verClientesPropios = funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
            'Ver facturas
            verFacturas = funcPE.Permiso(iidUsuario, "BusquedaFacturas")
            If Not verFacturas Then
                tpVentas.Parent = Nothing
            End If
            'Ver proveedor
            bVerProveedor.Enabled = funcPE.Permiso(iidUsuario, "ConsultaProveedor")
            'Activar unidades.
            bUnidades.Enabled = funcPE.Permiso(iidUsuario, "GestionUnidades")
            'Activar secciones
            bSecciones.Enabled = funcPE.Permiso(iidUsuario, "GestionSecciones")
            'Activar tipos
            bTipos.Enabled = funcPE.Permiso(iidUsuario, "GestionTiposArticulos") Or funcPE.Permiso(iidUsuario, "GestionFamilias")
            'Activar almacenes
            bAlmacen.Enabled = funcPE.Permiso(iidUsuario, "GestionAlmacenes")
            'Solo lectura.
            vSoloLectura = vSoloLectura Or funcPE.Parametro(Inicio.vIdUsuario, "BusquedaArticulo", "SOLO LECTURA") Or funcPE.Parametro(Inicio.vIdUsuario, "BusquedaSimpleArticulo", "SOLO LECTURA")
            'Hacer pedidos.
            HacePedidosProv = funcPE.Permiso(iidUsuario, "NuevoPedidoProv")
            If idArticulo.Text = "" Then idArticulo.Text = 0
            If idArticulo.Text = 0 Then
                VerCostes = VerCostes Or funcPE.Parametro(iidUsuario, "AltaArticulo", "VER COSTES")
            Else
                VerCostes = VerCostes Or funcPE.Parametro(iidUsuario, "BusquedaArticulo", "VER COSTES")
            End If
            If funcPE.Parametro(iidUsuario, "BusquedaArticulo", "CAMBIAR PVP") Then
                PrecioUnitarioV.ReadOnly = False
                PrecioOpcion.ReadOnly = False
            Else
                PrecioUnitarioV.ReadOnly = True
                PrecioOpcion.ReadOnly = True
            End If
            If VerCostes Then
                lvConceptos.Columns(5).Width = 89 'Coste U.
                lvConceptos.Columns(6).Width = 202 'Observaciones
                gbCoste.Visible = True
                tpProveedores.Parent = tbdatos
                tpPreciosXcantidad.Parent = tbdatos
                bVerEscandallo.Visible = True
            Else
                lvConceptos.Columns(5).Width = 0
                lvConceptos.Columns(6).Width = 291
                gbCoste.Visible = False
                tpProveedores.Parent = Nothing
                tpPreciosXcantidad.Parent = Nothing
                bVerEscandallo.Visible = False
            End If

            ckComprable.Enabled = VerCostes
            bGuardar.Enabled = Not vSoloLectura
            bBorrar.Enabled = Not vSoloLectura

            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.Icon = My.Resources.Resources.info

            GuardarPrecio = False

            Dim tt As New ToolTip
            tt.InitialDelay = 0
            tt.SetToolTip(bVerEscandallo, "Gestionar el escandallo del artículo")
            tt.SetToolTip(bTipos, "Gestionar tipos de Artículo")
            tt.SetToolTip(bSecciones, "Gestionar secciones de materia prima")
            tt.SetToolTip(bUnidades, "Gestionar unidades de medida")
            tt.SetToolTip(bAlmacen, "Gestionar almacenes")
            tt.SetToolTip(bBuscarProveedor, "Buscar proveedor")
            tt.SetToolTip(bNuevaComposicion, "Nuevo artículo con opciones basado en el artículo actual")

            'Cargar datos
            Call IntroducirUnidades()
            Call IntroducirAlmacenes()
            Call introducirProveedores()
            Call IntroducirSecciones()

            Call Inicializar()


            If idArticulo.Text = 0 Then
                Call IntroducirTiposArticulo()
                Call Nuevo()
                bSubir.Visible = False
                bBajar.Visible = False
                lbStockInicial.Visible = True
                StockInicial.Visible = True
                lbUnidadMedida2.Visible = True
                bNuevaComposicion.Visible = False
            Else
                Me.Text = "EDITAR ARTÍCULO"
                bNuevaComposicion.Visible = True
                If Articulos Is Nothing Then
                    bSubir.Visible = False
                    bBajar.Visible = False
                Else

                    If Articulos.Count > 0 Then
                        bSubir.Visible = True
                        bBajar.Visible = True
                    Else
                        bSubir.Visible = False
                        bBajar.Visible = False
                    End If
                End If

                lbStockInicial.Visible = False
                StockInicial.Visible = False
                lbUnidadMedida2.Visible = False
                Call CargarArticulo()
                G_AGeneral = "A"
            End If

            Dim cmArticuloProv As New ContextMenu
            cmArticuloProv.MenuItems.Add("Artículos de este Proveedor", New System.EventHandler(AddressOf Me.OnClickArticuloProv))
            cmArticuloProv.MenuItems.Add("Asignación del Artículo a Proveedor", New System.EventHandler(AddressOf Me.OnClickArticuloProv))
            cmArticuloProv.MenuItems.Add("Establecer como proveedor habitual", New System.EventHandler(AddressOf Me.OnClickArticuloProv))
            cmArticuloProv.MenuItems.Add("Asignar el precio de este proveedor como precio del artículo", New System.EventHandler(AddressOf Me.OnClickArticuloProv))
            If HacePedidosProv Then cmArticuloProv.MenuItems.Add("Pedido a proveedor del artículo", New System.EventHandler(AddressOf Me.OnClickPedidoProv))

            lvArticuloProv.ContextMenu = cmArticuloProv

            semaforo = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Cerrar formulario
    Private Sub GestionArticulo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If G_AGeneral = "G" Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
    End Sub

#End Region

    Protected Sub OnClickArticuloProv(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvArticuloProv.Click
        For Each item In lvArticuloProv.SelectedItems
            id_articulo = idArticulo.Text
            id_proveedor = lvArticuloProv.Items(0).SubItems(1).Text
        Next
        If lvArticuloProv.SelectedItems.Count > 0 Then
            Select Case sender.text
                Case "Artículos de este Proveedor"
                    Dim AAP As New GestionArticulosProv
                    AAP.pidProveedor = lvArticuloProv.SelectedItems(0).SubItems(1).Text
                    AAP.ShowDialog()
                Case "Establecer como proveedor habitual"
                    semaforo = False
                    dtsAR.gidProveedor = lvArticuloProv.SelectedItems(0).SubItems(1).Text
                    dtsAR.gProveedor = lvArticuloProv.SelectedItems(0).SubItems(2).Text
                    dtsAR.gFechaPrecioC = Now.Date
                    dtsAR.gidProveedorPrecio = lvArticuloProv.SelectedItems(0).Text
                    dtsAR.gidConceptoPedidoProv = 0
                    cbProveedor.Text = dtsAR.gProveedor
                    dtsAR.gPrecioUnitarioC = funcAP.Precio(lvArticuloProv.SelectedItems(0).Text)
                    PrecioUnitarioC.Text = FormatNumber(dtsAR.gPrecioUnitarioC, If(dtsAR.gPrecioUnitarioC >= 5, 4, 6))
                    semaforo = True
                Case "Asignación del Artículo a Proveedor"
                    'Dim AAP As New GestionArticulosProv
                    'AAP.pidProveedor = lvArticuloProv.SelectedItems(0).SubItems(4).Text
                    'AAP.pidArticulo = idArticulo.Text
                    'AAP.ShowDialog()
                Case "Asignar el precio de este proveedor como precio del artículo"
                    'Guardamos los datos que identifican el precio como "Precio de proveedor"
                    semaforo = False
                    dtsAR.gFechaPrecioC = Now.Date
                    dtsAR.gidProveedorPrecio = lvArticuloProv.SelectedItems(0).Text
                    dtsAR.gidConceptoPedidoProv = 0
                    'Precio.Text = FormatNumber(lvArticuloProv.SelectedItems(0).SubItems(3).Text, 2)
                    dtsAR.gPrecioUnitarioC = funcAP.Precio(lvArticuloProv.SelectedItems(0).Text)
                    PrecioUnitarioC.Text = FormatNumber(dtsAR.gPrecioUnitarioC, 2)
                    'PrecioUnitarioC.Text = FormatNumber(dtsAR.gPrecioUnitarioC, If(dtsAR.gPrecioUnitarioC >= 5, 4, 6))
                    GuardarPrecio = True
                    semaforo = True
            End Select
            Call CargarArticuloProv()
        End If
    End Sub

    Protected Sub OnClickPedidoProv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iidPoveedor As Integer = 0
        If lvArticuloProv.SelectedItems.Count <> 0 Then
            Dim indice As Integer = lvArticuloProv.SelectedIndices(0)
            iidPoveedor = lvArticuloProv.Items(indice).SubItems(1).Text
        End If
        Dim GG As New subUltimoPedidoArticulo

        GG.pidArticulo = idArticulo.Text
        GG.pidProveedor = iidPoveedor
        GG.SoloLectura = vSoloLectura
        GG.VerBotonPedido = True
        GG.ShowDialog()
        If GG.DialogResult = Windows.Forms.DialogResult.OK Then
            Call CargarArticuloProv()
        End If
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub Nuevo()
        Me.Text = "NUEVO ARTÍCULO"
        tpDesglose.Parent = Nothing

        idArticulo.Text = funcAR.NuevoidArticulo
        dtsAR = New DatosArticulo
        lbStockInicial.Visible = True
        StockInicial.Visible = True
        lbUnidadMedida2.Visible = True

        G_AGeneral = "G"
    End Sub

    Private Sub Inicializar()
        Articulo.Text = ""
        ArticuloEN.Text = ""
        Descripcion.Text = ""
        DescripcionEN.Text = ""
        codArticulo.Text = ""
        observaciones.Text = ""
        KilosBrutos.Text = 0
        KilosNetos.Text = 0
        Bultos.Text = 0
        Alto.Text = 0
        Ancho.Text = 0
        Fondo.Text = 0
        Volumen.Text = 0
        cbUnidadMedida.Text = "u."
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbSeccion.Text = ""
        cbSeccion.SelectedIndex = -1
        iidTipoArticulo = 0
        iidFamilia = 0
        dtpFechaAlta.Value = Now.Date
        dtpFechaBaja.Value = Now.Date
        dtpFechaPrecioC.Value = Now.Date
        dtpFechaPrecioV.Value = Now.Date
        ckActivo.Checked = True
        'rbMateriaPrima.Checked = False
        'rbArticulo.Checked = True
        ckMateriaPrima.Checked = False
        ckComprable.Checked = False
        ckVendible.Checked = True
        ckOpcion.Checked = False
        ckSubEnsamblado.Checked = False
        ckEscandallo.Checked = False
        ckVersiones.Checked = False
        gbCoste.Enabled = ckComprable.Checked
        gbVenta.Enabled = ckVendible.Checked
        cbSeccion.Enabled = ckMateriaPrima.Checked Or ckEscandallo.Enabled
        bSecciones.Enabled = ckMateriaPrima.Checked Or ckEscandallo.Enabled
        dtpFechaBaja.Visible = False
        lbFechaBaja.Visible = False
        StockMinimo.Text = 0
        StockInicial.Text = 0
        StockAlmacen.Text = 0
        PrecioUnitarioC.Text = 0
        PrecioUnitarioV.Text = 0
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        PrecioOpcion.Text = 0
        lbMonedaC.Text = "€"
        lbMonedaV.Text = "€"
        lbMonedaO = lbMonedaV
        iidStock = 0
        G_AGeneral = "G"
        Me.Text = "NUEVO ARTÍCULO"
        iidUnidad = 0
        codMonedaC = "EU"
        codMonedaV = "EU"
        dPrecio = 0
        cambios = False
        lvArticuloProv.Items.Clear()
        lvEscandallos.Items.Clear()
        lvPreciosXCantidad.Items.Clear()
        Call LimpiarEdicionPxC()
        lvStock.Items.Clear()

    End Sub

    Private Sub IntroducirTiposArticulo()
        cbTipo.Items.Clear()
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosTipoArticulo) = funcTI.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoArticulo, dts.gidTipoArticulo))
        Next
    End Sub

    Private Sub IntroducirSubTiposArticulo()
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
    End Sub

    Private Sub IntroducirFamilias()
        cbTipo.Items.Clear()
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
        Dim dts As DatosFamilia
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gFamilia, dts.gidFamilia))
        Next
    End Sub

    Private Sub IntroducirSubFamilias()
        If iidFamilia > 0 Then
            cbSubTipo.Text = ""
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Items.Clear()
            Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, True)
            Dim dts As DatosSubFamilia
            For Each dts In lista
                cbSubTipo.Items.Add(New IDComboBox(dts.gSubFamilia, dts.gidSubFamilia))
            Next
        End If
    End Sub

    Private Sub IntroducirUnidades()
        cbUnidadMedida.Items.Clear()
        Dim lista As List(Of DatosTipoUnidad) = funcTU.Mostrar()
        Dim dts As DatosTipoUnidad
        For Each dts In lista
            cbUnidadMedida.Items.Add(New IDComboBox(dts.gTipoUnidad, dts.gidTipoUnidad))
        Next
    End Sub

    Private Sub IntroducirAlmacenes()
        cbAlmacen.Items.Clear()
        Dim lista As List(Of DatosAlmacen) = funcAL.Mostrar(True)
        Dim dts As DatosAlmacen
        For Each dts In lista
            cbAlmacen.Items.Add(New IDComboBox(dts.gAlmacen, dts.gidAlmacen))
        Next

    End Sub

    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()
            cbProveedorPC.Items.Clear()
            Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
            Dim dts As datosProveedor
            For Each dts In lista
                cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
                cbProveedorPC.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IntroducirSecciones()
        cbSeccion.Items.Clear()
        Dim lista As List(Of DatosSeccion) = funcSE.Mostrar(True)
        Dim dts As DatosSeccion
        For Each dts In lista
            cbSeccion.Items.Add(New IDComboBox(dts.gSeccion, dts.gidSeccion))
        Next
    End Sub

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarArticulo()
        If idArticulo.Text <> "" And idArticulo.Text <> "0" Then
            semaforo = False

            dtsAR = funcAR.Mostrar1(idArticulo.Text)
            ckMateriaPrima.Checked = dtsAR.gMateriaPrima
            codArticulo.Text = dtsAR.gcodArticulo
            Articulo.Text = dtsAR.gArticulo
            ArticuloEN.Text = dtsAR.gArticuloEN
            Descripcion.Text = dtsAR.gDescripcion
            DescripcionEN.Text = dtsAR.gDescripcionEN
            dtpFechaAlta.Value = dtsAR.gFechaAlta.Date
            dtpFechaBaja.Value = dtsAR.gFechaBaja.Date
            KilosBrutos.Text = FormatNumber(dtsAR.gKilosBrutos, 2)
            KilosNetos.Text = FormatNumber(dtsAR.gKilosNetos, 2)
            Bultos.Text = dtsAR.gBultos
            Alto.Text = FormatNumber(dtsAR.gAlto, 2)
            Ancho.Text = FormatNumber(dtsAR.gAncho, 2)
            Fondo.Text = FormatNumber(dtsAR.gFondo, 2)
            Volumen.Text = FormatNumber(dtsAR.gVolumen, 4)
            ckRecambio.Checked = dtsAR.gRecambio

            If ckMateriaPrima.Checked Then
                Call IntroducirFamilias()
                cbTipo.Text = dtsAR.gFamilia
                Call IntroducirSubFamilias()
                cbSubTipo.Text = dtsAR.gSubFamilia

            Else
                Call IntroducirTiposArticulo()
                cbTipo.Text = dtsAR.gTipoArticulo
                Call IntroducirSubTiposArticulo()
                cbSubTipo.Text = dtsAR.gSubTipoArticulo
                'cbSeccion.Text = ""
            End If
            cbSeccion.Text = dtsAR.gSeccion
            cbUnidadMedida.Text = dtsAR.gTipoUnidad
            cbAlmacen.Text = dtsAR.gAlmacen
            StockAlmacen.Text = FormatNumber(dtsAR.gCantidadStock, 2)
            PrecioUnitarioC.Text = FormatNumber(dtsAR.gPrecioUnitarioC, If(dtsAR.gPrecioUnitarioC >= 5, 4, 6))
            lbMonedaC.Text = dtsAR.gSimboloC
            dtpFechaPrecioC.Value = dtsAR.gFechaPrecioC.Date
            PrecioUnitarioV.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
            PrecioOpcion.Text = FormatNumber(dtsAR.gPrecioOpcion, 2)
            lbMonedaV.Text = dtsAR.gSimboloV
            lbMonedaO.Text = lbMonedaV.Text
            dtpFechaPrecioV.Value = dtsAR.gFechaPrecioV.Date
            cbProveedor.Text = dtsAR.gProveedor
            observaciones.Text = dtsAR.gObservaciones
            iidUnidad = dtsAR.gidUnidad
            dPrecio = dtsAR.gPrecioUnitarioC
            ckActivo.Checked = dtsAR.gActivo
            If ckActivo.Checked = False Then
                dtpFechaBaja.Visible = (Not ckActivo.Checked)
                lbFechaBaja.Visible = (Not ckActivo.Checked)
            End If
            ckComprable.Checked = dtsAR.gComprable
            ckVendible.Checked = dtsAR.gVendible
            ckDomesticos2.Checked = dtsAR.gDomesticos2
            ckOpcion.Checked = dtsAR.gOpcion
            ckSubEnsamblado.Checked = dtsAR.gsubEnsamblado
            ckEscandallo.Checked = dtsAR.gEscandallo
            ckVersiones.Checked = dtsAR.gConVersiones
            ckProduccionSeparada.Checked = dtsAR.gProduccionSeparada
            ckProduccionSeparada.Enabled = (ckMateriaPrima.Checked And ckEscandallo.Checked)
            ckConNumSerie.Checked = dtsAR.gConNumSerie
            ckConNumSerie2.Checked = dtsAR.gConNumSerie2
            ckConNumSerie.Enabled = ckEscandallo.Checked
            ckConNumSerie2.Enabled = ckEscandallo.Checked
            lbVentaIndependiente.Enabled = ckEscandallo.Checked
            If ckEscandallo.Checked Then
                tpDesglose.Parent = tbdatos
                bNuevaComposicion.Enabled = True
            Else
                tpDesglose.Parent = Nothing
                bNuevaComposicion.Enabled = False
            End If
            'gbCoste.Enabled = ckComprable.Checked
            gbVenta.Enabled = ckVendible.Checked

            tpVentas.Enabled = ckVendible.Checked

            If ckComprable.Checked Then
                gbCoste.Enabled = True
                'tpProveedores.Parent = tbdatos
                'tpPreciosXcantidad.Parent = tbdatos
                tpProveedores.Enabled = True
                tpPreciosXcantidad.Enabled = True
            Else
                gbCoste.Enabled = False
                tpProveedores.Enabled = False
                tpPreciosXcantidad.Enabled = False
                'tpProveedores.Parent = Nothing
                'tpPreciosXcantidad.Parent = Nothing
            End If


            StockMinimo.Text = FormatNumber(dtsAR.gStockMinimo, 2)

            Call CargarEscandallos()
            iidEscandallo = funcES.ExisteEscandallo(dtsAR.gidArticulo)
            If iidEscandallo = 0 Then
                lvConceptos.Items.Clear()
            Else
                Call CargarVersiones(dtsAR.gidArticulo)
                If cbVersion.SelectedIndex <> -1 Then
                    If IsNumeric(cbVersion.Text) Then iidEscandallo = funcES.ExisteEscandalloVersionUltima(dtsAR.gidArticulo, cbVersion.Text)
                End If

                Call CargarDesglose(iidEscandallo)
            End If
            Call CargarStock()
            Call CargarArticuloProv()
            Call LimpiarEdicionPxC()
            Call CargarLVPreciosXCantidad()
            If verFacturas Then
                Call LimpiarBusquedaArticulo()
                Call CargarlvArtVendidos()
            End If
            calcularPrecioC()
            cambios = False
            semaforo = True
        End If
    End Sub

    Private Sub CargarEscandallos()

        'Mostrar los escandallos de los que el producto forma parte
        Dim lista As List(Of DatosEscandallo) = funcES.MostraEscandallosGestionArticulo(idArticulo.Text, True)

        lvEscandallos.Items.Clear()

        For Each dts As DatosEscandallo In lista

            With lvEscandallos.Items.Add(dts.gidEscandallo)

                .SubItems.Add(dts.gcodArticulo)

                .SubItems.Add(dts.gArticulo)

                .SubItems.Add(dts.gCantidad)

            End With

        Next

    End Sub

    Private Sub CargarStock()
        lvStock.Items.Clear()
        'Muestra los últimos movimientos del artículo
        Dim lista As List(Of DatosAlmacen) = funcAL.Mostrar(True)
        Dim Cantidad As Double = 0
        Cantidad = funcST.Cantidad(0, idArticulo.Text, -1)
        If Cantidad <> 0 Then
            With lvStock.Items.Add(0)
                .SubItems.Add("NO ESPECIFICADO")
                .SubItems.Add(FormatNumber(Cantidad, 2) & cbUnidadMedida.Text)
            End With
        End If
        For Each dtsAL As DatosAlmacen In lista
            Cantidad = funcST.Cantidad(0, idArticulo.Text, dtsAL.gidAlmacen)
            If Cantidad <> 0 Then
                With lvStock.Items.Add(dtsAL.gidAlmacen)
                    .SubItems.Add(dtsAL.gAlmacen)
                    .SubItems.Add(FormatNumber(Cantidad, 2) & cbUnidadMedida.Text)
                End With
            End If
        Next
    End Sub

    Private Sub CargarVersiones(ByVal iidArticulo)
        cbVersion.Items.Clear()
        If iidArticulo > 0 Then
            If funcAR.Escandallo(iidArticulo) Then
                semaforo = False
                cbVersion.Enabled = True
                Dim iidArticuloBase As Integer = funcES.idArticuloBaseArticulo(iidArticulo)
                Dim lista As List(Of Integer)
                If iidArticuloBase > 0 Then
                    lista = funcAR.Versiones(iidArticuloBase)
                Else
                    lista = funcAR.Versiones(iidArticulo)
                End If


                For Each v As Integer In lista
                    If v > 0 Then cbVersion.Items.Add(v)
                Next
                If cbVersion.Items.Count > 0 Then
                    If cbVersion.Items.Count = 1 Then
                        cbVersion.Text = lista(0)
                    Else
                        cbVersion.Text = lista.Max()
                    End If
                End If
                semaforo = True
            Else
                cbVersion.Enabled = False
            End If
        End If
    End Sub

    Private Sub CargarDesglose(ByVal iidEscandallo As Integer)
        Dim vPrecio As Double
        Dim lista As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(iidEscandallo, False, 0)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoEscandallo In lista
            With lvConceptos.Items.Add(dts.gidConcepto)
                .SubItems.Add(dts.gSeccion)
                .SubItems.Add(dts.gcodConcepto)
                .SubItems.Add(dts.gConcepto)
                .SubItems.Add(dts.gCantidad & dts.gTipoUnidad)
                If VerCostes Then
                    .SubItems.Add(FormatNumber(dts.gCoste, 4) & dts.gsimbolo)
                Else
                    .SubItems.Add("")
                End If
                .SubItems.Add(dts.gObservaciones)
                .SubItems.Add(dts.gidArticulo)
                If dts.gActivo Then
                    If dts.gExisteEscandallo Then
                        .ForeColor = Color.DarkGreen
                    Else
                        .ForeColor = Color.Black
                    End If

                Else
                    .ForeColor = colorInactivo
                End If
            End With
            vPrecio = vPrecio + (dts.gCantidad * FormatNumber(dts.gCoste, 4))
        Next
        'PrecioUnitarioC.Text = vPrecio
    End Sub

    Private Sub CargarArticuloProv()
        lvArticuloProv.Items.Clear()
        Dim lista As List(Of DatosArticuloProveedor) = funcAP.Mostrar(0, idArticulo.Text, 0, 0, "FechaPrecio DESC", True)
        Dim dts As DatosArticuloProveedor
        For Each dts In lista
            With lvArticuloProv.Items.Add(dts.gidArticuloProv)
                .subitems.add(dts.gidProveedor)
                .subitems.add(dts.gProveedor)
                .subitems.add(dts.gFechaPrecio)
                .subitems.add(dts.gcodArticuloProv)
                .subitems.add(dts.gNombre)
                .subitems.add(FormatNumber(dts.gPrecio, 2) & dts.gSimbolo)

                'If dts.gPrecio = dtsAR.gPrecioMinimo Then .backcolor = Color.PaleGoldenrod
                If dts.gidProveedor = dtsAR.gidProveedor Then .backcolor = Color.PaleTurquoise
            End With
        Next

        'LUIS, Calcula los totales Pedidos, recibidos y pendientes.
        listaProv.Items.Clear()
        If lvArticuloProv.Items.Count > 0 Then
            Dim añadido As Boolean
            For i = 0 To lvArticuloProv.Items.Count - 1
                If listaProv.Items.Count = 0 Then
                    listaProv.Items.Add(lvArticuloProv.Items(i).SubItems(1).Text)
                Else
                    For Each registro In listaProv.Items

                        If lvArticuloProv.Items(i).SubItems(1).Text = registro And añadido = False Then

                        Else
                            añadido = True
                        End If
                    Next
                    If añadido = True Then
                        listaProv.Items.Add(lvArticuloProv.Items(i).SubItems(1).Text)
                        añadido = False
                    End If
                End If
            Next
        End If
        Dim dTotalCantPedida As Double
        Dim dTotalCantRecibida As Double
        If listaProv.Items.Count > 0 Then
            For Each item In listaProv.Items
                Dim lista1 As List(Of DatosArticuloProveedor) = funcAP.totalesCantidadesPedidosProv(item, idArticulo.Text)
                Dim dts1 As DatosArticuloProveedor
                For Each dts1 In lista1
                    dTotalCantPedida = dts1.gCantidadPedida + dTotalCantPedida
                    dTotalCantRecibida = dts1.gCantidadRecibida + dTotalCantRecibida
                Next
            Next
        End If
        txCantidadTotalPedida.Text = dTotalCantPedida
        txCantidadTotalRecibida.Text = dTotalCantRecibida
        txCantidadPendiente.Text = dTotalCantPedida - dTotalCantRecibida
        'LUIS, Fin

    End Sub

#End Region

#Region "BOTONES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If G_AGeneral = "G" Then
            If cambios Then
                If MsgBox("Borrar los datos introducidos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call Inicializar()
                End If
            Else
                Call Inicializar()
            End If
        Else
            If tbdatos.SelectedTab.Name = "tpPreciosXcantidad" And IsNumeric(PrecioPC.Text) Then
                Call BorrarPxC()
            Else
                Call BorrarArticulo()
            End If
        End If
    End Sub

    Private Sub BorrarArticulo()
        Dim Mensaje As String
        If funcAR.EnUso(idArticulo.Text) Then
            Mensaje = "Este artículo no se puede borrar porque está en uso. ¿Desea derlo de baja?" & If(StockAlmacen.Text > 0, ". El stock quedará con valor 0", "")
            If MsgBox(Mensaje, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim dtsS As New DatosStock
                'Creamos un movimiento restando todo el stock aunque sea 0 para que quede constancia de la baja
                dtsS.gidStock = iidStock
                dtsS.gidArticulo = idArticulo.Text
                'dtsS.gArticulo = Articulo.Text
                dtsS.gCantidad = -CDbl(StockAlmacen.Text)
                dtsS.gcodMoneda = "EU"
                dtsS.gFecha = Now.Date
                dtsS.gidAlmacen = dtsAR.gidAlmacen
                dtsS.gidArticuloProv = 0
                dtsS.gidLote = 0
                dtsS.gidUnidad = iidUnidad
                dtsS.gPrecio = dPrecio
                dtsS.gidPersona1 = iidUsuario
                dtsS.gidPersona2 = 0
                dtsS.gMovimiento = "BAJA DE ARTÍCULO"
                funcST.insertar(dtsS)
                funcAP.Baja(idArticulo.Text)  'Se inactiva en Articulo_Proveedor
                funcAR.Baja(idArticulo.Text)  'Finalmente, se inactiva el artículo
                Call Inicializar()
            End If
        Else
            If MsgBox("¿Desea borrar el artículo?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcST.borrarArticulo(idArticulo.Text)
                funcAPR.borrarArticulo(idArticulo.Text)
                funcAR.Borrar(idArticulo.Text)
                Call Inicializar()
            End If

        End If

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        If cambios Then

            PrecioUnitarioC.Text = If(PrecioUnitarioC.Text = "", "0", PrecioUnitarioC.Text) 'Soluciona el error de campo vacio.

            If GuardarGeneral() Then

                If tbdatos.SelectedTab.Name = "tpPreciosXcantidad" Then

                    Call GuardarPxC()

                End If

            End If

        ElseIf tbdatos.SelectedTab.Name = "tpPreciosXcantidad" And IsNumeric(PrecioPC.Text) Then

            Call GuardarPxC()

        End If

    End Sub

    Private Function GuardarGeneral() As Boolean

        Dim Aviso As String = ""

        Dim validar As Boolean = True

        Dim idProv As Integer

        Dim dtsS As New DatosStock

        ep1.Clear()

        ep2.Clear()


        If Articulo.Text.Length = 0 Then
            validar = False
            ep1.SetError(Articulo, "Se ha de indicar el nombre del artículo")
        End If

        If codArticulo.Text.Length = 0 Then
            ep2.SetError(codArticulo, "Indique un código para el artículo")
            Aviso = Aviso & vbCrLf & "No se ha indicado un código para el artículo."
        Else
            If funcAR.codArticuloExiste(idArticulo.Text, codArticulo.Text) Then
                validar = False
                ep1.SetError(codArticulo, "El código ya está en uso por otro artículo")
            End If
        End If

        If cbTipo.SelectedIndex = -1 Then
            validar = False
            If ckMateriaPrima.Checked Then
                ep1.SetError(cbTipo, "Se ha de seleccionar una familia")
            Else
                ep1.SetError(cbTipo, "Se ha de seleccionar un tipo de artículo")
            End If
        End If

        If (ckMateriaPrima.Checked Or ckEscandallo.Checked) And cbSeccion.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbSeccion, "Se ha de seleccionar una sección")
        End If

        If cbUnidadMedida.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbUnidadMedida, "Seleccione una unidad de medida")
        End If

        'If cbAlmacen.SelectedIndex = -1 Then
        '    ep1.SetError(cbAlmacen, "Se ha de seleccionar un almacén habitual")
        '    validar = False
        'End If

        If ckComprable.Checked And cbProveedor.SelectedIndex = -1 Then
            ep2.SetError(cbProveedor, "Seleccione un proveedor habitual")
            Aviso = Aviso & vbCrLf & "No se ha seleccionado un proveedor habitual."
        End If

        If validar Then
            idProv = If(cbProveedor.SelectedIndex = -1, 0, cbProveedor.SelectedItem.itemdata)
            dtsAR.gidArticulo = idArticulo.Text
            dtsAR.gcodArticulo = codArticulo.Text
            dtsAR.gArticulo = Articulo.Text
            dtsAR.gArticuloEN = ArticuloEN.Text
            dtsAR.gDescripcion = Descripcion.Text
            dtsAR.gDescripcionEN = DescripcionEN.Text
            dtsAR.gFechaAlta = dtpFechaAlta.Value.Date
            dtsAR.gFechaBaja = dtpFechaBaja.Value.Date
            dtsAR.gActivo = ckActivo.Checked
            dtsAR.gRecambio = ckRecambio.Checked 'Si es un recambio
            dtsAR.gidTipoCompra = If(ckComprable.Checked And idProv <> 0, funcPR.campoTipo(idProv), 0)
            If ckMateriaPrima.Checked Then
                dtsAR.gidTipoArticulo = 0
                dtsAR.gidSubTipoArticulo = 0
                dtsAR.gidFamilia = cbTipo.SelectedItem.itemdata
                dtsAR.gidSubFamilia = If(cbSubTipo.SelectedIndex = -1, 0, cbSubTipo.SelectedItem.itemdata)
                dtsAR.gidSeccion = If(cbSeccion.SelectedIndex = -1, 0, cbSeccion.SelectedItem.itemdata)
            Else
                dtsAR.gidTipoArticulo = cbTipo.SelectedItem.itemdata
                dtsAR.gidSubTipoArticulo = If(cbSubTipo.SelectedIndex = -1, 0, cbSubTipo.SelectedItem.itemdata)
                dtsAR.gidFamilia = 0
                dtsAR.gidSubFamilia = 0
                If ckEscandallo.Checked Then
                    dtsAR.gidSeccion = If(cbSeccion.SelectedIndex = -1, 0, cbSeccion.SelectedItem.itemdata)
                Else
                    dtsAR.gidSeccion = 0
                End If
            End If
            dtsAR.gidUnidad = cbUnidadMedida.SelectedItem.itemdata
            dtsAR.gObservaciones = observaciones.Text
            dtsAR.gStockMinimo = StockMinimo.Text
            dtsAR.gComprable = ckComprable.Checked
            dtsAR.gDomesticos2 = ckDomesticos2.Checked
            dtsAR.gVendible = ckVendible.Checked
            dtsAR.gMateriaPrima = ckMateriaPrima.Checked
            dtsAR.gOpcion = ckOpcion.Checked
            dtsAR.gsubEnsamblado = ckSubEnsamblado.Checked
            dtsAR.gEscandallo = ckEscandallo.Checked
            If ckEscandallo.Checked Then
                dtsAR.gConVersiones = ckVersiones.Checked
            Else
                dtsAR.gConVersiones = False
            End If
            dtsAR.gConVersiones = ckVersiones.Checked
            'dtsAR.gidAlmacen = If(cbAlmacen.SelectedIndex = -1, 0, cbAlmacen.SelectedItem.itemdata)
            dtsAR.gidAlmacen = 1
            dtsAR.gPrecioUnitarioC = PrecioUnitarioC.Text
            dtsAR.gcodMonedaC = codMonedaC
            dtsAR.gcodMonedaV = codMonedaV
            dtsAR.gFechaPrecioC = dtpFechaPrecioC.Value.Date
            dtsAR.gidProveedorPrecio = 0
            dtsAR.gidConceptoPedidoProv = 0
            dtsAR.gidProveedor = idProv
            dtsAR.gPrecioUnitarioV = PrecioUnitarioV.Text
            If PrecioOpcion.Text = "" Then PrecioOpcion.Text = 0
            If ckOpcion.Checked And PrecioOpcion.Text = 0 Then PrecioOpcion.Text = PrecioUnitarioV.Text
            dtsAR.gPrecioOpcion = PrecioOpcion.Text
            dtsAR.gFechaPrecioV = dtpFechaPrecioV.Value.Date
            dtsAR.gKilosBrutos = If(KilosBrutos.Text = "", 0, CDbl(KilosBrutos.Text))
            dtsAR.gKilosNetos = If(KilosNetos.Text = "", 0, CDbl(KilosNetos.Text))
            dtsAR.gBultos = If(Bultos.Text = "", 0, CDbl(Bultos.Text))
            dtsAR.gAlto = If(Alto.Text = "", 0, CDbl(Alto.Text))
            dtsAR.gAncho = If(Ancho.Text = "", 0, CDbl(Ancho.Text))
            dtsAR.gFondo = If(Fondo.Text = "", 0, CDbl(Fondo.Text))
            dtsAR.gVolumen = If(Volumen.Text = "", 0, CDbl(Volumen.Text))
            dtsAR.gProduccionSeparada = ckProduccionSeparada.Checked
            dtsAR.gConNumSerie = ckConNumSerie.Checked
            dtsAR.gConNumSerie2 = ckConNumSerie2.Checked
            If G_AGeneral = "G" Then
                idArticulo.Text = funcAR.insertar(dtsAR)
                dtsS.gidStock = 0
                dtsS.gidArticulo = idArticulo.Text
                dtsS.gCantidad = StockInicial.Text
                dtsS.gcodMoneda = codMonedaC
                dtsS.gFecha = dtpFechaPrecioC.Value.Date
                'dtsS.gidAlmacen = If(cbAlmacen.SelectedIndex = -1, 0, cbAlmacen.SelectedItem.itemdata)
                dtsS.gidAlmacen = 1 'SIEMPRE ES EL ALMACEN GENERAL
                dtsS.gidArticuloProv = 0
                dtsS.gidLote = 0
                dtsS.gidUnidad = dtsAR.gidUnidad
                dtsS.gPrecio = PrecioUnitarioC.Text
                dtsS.gidPersona1 = iidUsuario
                dtsS.gidPersona2 = 0
                dtsS.gMovimiento = "ALTA DE ARTÍCULO"
                G_AGeneral = "A"
                Me.Text = "EDITAR ARTÍCULO"
                iidStock = funcST.insertar(dtsS)
                Aviso = "Artículo guardado correctamente." & If(Aviso.Length > 0, vbCrLf & vbCrLf & Aviso, "")
                bNuevaComposicion.Visible = ckEscandallo.Checked
            Else
                funcAR.actualizar(dtsAR)
                Aviso = "Artículo actualizado correctamente." & If(Aviso.Length > 0, vbCrLf & vbCrLf & Aviso, "")
            End If
            'Si el artículo es una materia prima, se ha de actualizar el precio de los artículos que lo contienen

            Dim listaES As List(Of DatosEscandallo) = funcES.MostraEscandallosGestionArticulo(dtsAR.gidArticulo, False) 'Lista de escandallos que contienen el artículo
            'Dim listaES As List(Of DatosEscandallo) = funcES.MostraEscandallos(dtsAR.gidArticulo, False) 'Lista de escandallos que contienen el artículo
            If listaES.Count > 50 Then

                MsgBox("Se van actualizar los precios de una gran cantidad de escandallos, el proceso puede demorarse varios minutos.", MsgBoxStyle.Information)

            End If

            Dim dtsAPR As DatosArticuloPrecio
            For Each dtsES As DatosEscandallo In listaES
                dtsAPR = New DatosArticuloPrecio
                dtsAPR.gidArticulo = dtsES.gidArticulo
                dtsAPR.gFechaPrecio = Now.Date
                dtsAPR.gPrecio = funcES.CosteEU(dtsES.gidEscandallo, False, Now.Date)
                dtsAPR.gcodMoneda = "EU"
                dtsAPR.gidProveedorPrecio = 0
                dtsAPR.gidArticuloPrecio = 0
                dtsAPR.gActivo = True
                dtsAPR.gDescuento = 0
                dtsAPR.gTipoPrecio = "C"
                dtsAPR.gidConcepto = 0
                funcAPR.ActualizarH(dtsAPR)
            Next
            If Aviso.Length > 0 Then MsgBox(Aviso, MsgBoxStyle.Information)
            ep1.Clear()
            ep2.Clear()
            cambios = False
        End If
        Return validar
    End Function

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If G_AGeneral = "G" Then
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call Inicializar()
                    Call Nuevo()
                End If
            Else
                Call Inicializar()
                Call Nuevo()
            End If
        ElseIf tbdatos.SelectedTab.Name = "tpPreciosXcantidad" And IsNumeric(PrecioPC.Text) Then
            Call LimpiarEdicionPxC()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call Inicializar()
                    Call Nuevo()
                End If
            Else
                Call Inicializar()
                Call Nuevo()
            End If
        End If

    End Sub

    Private Sub bTiposArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTipos.Click
        Dim TipoArticulo As String = cbTipo.Text
        Dim subTipoArticulo As String = cbSubTipo.Text
        If ckMateriaPrima.Checked Then
            Dim GF As New GestionFamilias
            GF.SoloLectura = vSoloLectura
            GF.ShowDialog()
            Call IntroducirFamilias()
        Else
            Dim GF As New GestionTiposArticulo
            GF.SoloLectura = vSoloLectura
            GF.ShowDialog()
            Call IntroducirTiposArticulo()
        End If
        cbTipo.Text = TipoArticulo
        If cbTipo.SelectedIndex = -1 Then
            cbTipo.Text = ""
        Else
            cbSubTipo.Text = subTipoArticulo
            If cbSubTipo.SelectedIndex = -1 Then cbSubTipo.Text = ""
        End If
    End Sub

    Private Sub bAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAlmacen.Click
        Dim Almacen As String = cbAlmacen.Text
        Dim GS As New gestionAlmacenes
        GS.SoloLectura = vSoloLectura
        GS.ShowDialog()
        Call IntroducirAlmacenes()
        cbAlmacen.Text = Almacen
        If cbAlmacen.SelectedIndex = -1 Then cbAlmacen.Text = ""
    End Sub

    Private Sub bBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarProveedor.Click
        Dim BP As New busquedaproveedor
        BP.SoloLectura = vSoloLectura
        BP.pModo = "B"
        BP.ShowDialog()
        cbProveedor.Text = BP.pNombre
    End Sub

    Private Sub bSecciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSecciones.Click
        Dim seccion As String = cbSeccion.Text
        Dim GS As New gestionSecciones
        GS.SoloLectura = vSoloLectura
        GS.ShowDialog()
        Call IntroducirSecciones()
        cbSeccion.Text = seccion
        If cbSeccion.SelectedIndex = -1 Then cbSeccion.Text = ""
    End Sub

    Private Sub bUnidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUnidades.Click
        Dim unidades As String = cbUnidadMedida.Text
        Dim GU As New gestionUnidades
        GU.SoloLectura = vSoloLectura
        GU.ShowDialog()
        Call IntroducirUnidades()
        cbUnidadMedida.Text = unidades
        If cbUnidadMedida.SelectedIndex = -1 Then cbUnidadMedida.Text = ""
    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            G_AGeneral = "A"
            indiceL = indiceL - 1
            idArticulo.Text = Articulos(indiceL)
            Call CargarArticulo()
        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Articulos.Count - 1 Then
            G_AGeneral = "A"
            indiceL = indiceL + 1
            idArticulo.Text = Articulos(indiceL)
            Call CargarArticulo()
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged
        If cbTipo.SelectedIndex <> -1 Then
            'serán familias o tipos según sea materia prima o artículo
            If ckMateriaPrima.Checked Then
                iidFamilia = cbTipo.SelectedItem.itemdata
                Call IntroducirSubFamilias()
            Else
                iidTipoArticulo = cbTipo.SelectedItem.itemdata
                Call IntroducirSubTiposArticulo()
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbUnidadMedida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUnidadMedida.SelectedIndexChanged
        lbUnidadMedida1.Text = cbUnidadMedida.Text
        lbUnidadMedida2.Text = cbUnidadMedida.Text
        lbUnidadMedida.Text = cbUnidadMedida.Text
        lbUnidadMedida3.Text = cbUnidadMedida.Text
        lbUnidadMedida4.Text = cbUnidadMedida.Text
    End Sub

    Private Sub PrecioUnitarioC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioUnitarioC.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioUnitarioC.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub PrecioUnitarioV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioUnitarioV.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioUnitarioV.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PrecioOpcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioOpcion.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioOpcion.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub StockMinimo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StockMinimo.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(StockMinimo.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub StockInicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StockInicial.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(StockInicial.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub StockAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles StockAlmacen.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(StockAlmacen.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub KilosBrutos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles KilosBrutos.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(KilosBrutos.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub KilosNetos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles KilosNetos.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(KilosNetos.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Alto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Alto.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Alto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Ancho_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Ancho.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Ancho.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Fondo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Fondo.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Fondo.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Volumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Volumen.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Volumen.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Bultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Bultos.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub codArticulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles codArticulo.Click, StockAlmacen.Click, StockMinimo.Click, _
    PrecioUnitarioC.Click, StockInicial.Click, PrecioUnitarioV.Click, PrecioOpcion.Click, Volumen.Click, KilosNetos.Click, Ancho.Click, Alto.Click, _
    KilosBrutos.Click, Bultos.Click, Fondo.Click, Desde.Click, Hasta.Click, PrecioPC.Click
        sender.SelectAll()
    End Sub

    Private Sub Precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrecioUnitarioC.TextChanged, PrecioUnitarioV.TextChanged, PrecioOpcion.TextChanged
        If semaforo Then
            'Guardamos los datos que identifican el precio como "puesto a mano"
            dtsAR.gFechaPrecioC = Now.Date
            dtsAR.gidProveedorPrecio = 0
            dtsAR.gidConceptoPedidoProv = 0
            GuardarPrecio = True
            cambios = True
        End If
    End Sub

    Private Sub ckActivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckActivo.CheckedChanged
        If semaforo Then
            cambios = True
            dtpFechaBaja.Visible = (Not ckActivo.Checked)
            lbFechaBaja.Visible = (Not ckActivo.Checked)
        End If
    End Sub

    Private Sub codArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codArticulo.TextChanged, cbAlmacen.SelectedIndexChanged, cbProveedor.SelectedIndexChanged,
           dtpFechaPrecioC.ValueChanged, StockInicial.TextChanged, StockMinimo.TextChanged, observaciones.TextChanged, cbSubTipo.SelectedIndexChanged, ArticuloEN.TextChanged,
           Articulo.TextChanged, dtpFechaAlta.ValueChanged, dtpFechaBaja.ValueChanged, DescripcionEN.TextChanged, Descripcion.TextChanged, dtpFechaPrecioV.ValueChanged, PrecioUnitarioV.TextChanged,
           ckSubEnsamblado.CheckedChanged, cbSeccion.SelectedIndexChanged, KilosNetos.TextChanged, KilosBrutos.TextChanged, Volumen.TextChanged, ckDomesticos2.CheckedChanged, ckProduccionSeparada.CheckedChanged, dtpFechaPC.ValueChanged, ckVersiones.CheckedChanged, ckRecambio.CheckedChanged
        cambios = semaforo
    End Sub

    Private Sub Fondo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bultos.TextChanged, Alto.TextChanged, Ancho.TextChanged, Fondo.TextChanged
        cambios = True
        If Bultos.Text = "" Then Bultos.Text = 0
        If Alto.Text = "" Then Alto.Text = 0
        If Ancho.Text = "" Then Ancho.Text = 0
        If Fondo.Text = "" Then Fondo.Text = 0
        Dim vol As Double = 0
        If Alto.Text > 0 And Ancho.Text > 0 And Fondo.Text > 0 Then
            vol = Alto.Text * Ancho.Text * Fondo.Text / 1000000 'metros cúbicos
        End If
        Volumen.Text = FormatNumber(vol * Bultos.Text, 4)

    End Sub

    Private Sub ckVendible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckVendible.CheckedChanged
        cambios = True
        gbVenta.Enabled = ckVendible.Checked
        tpVentas.Enabled = ckVendible.Checked
    End Sub

    Private Sub ckEscandallo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckEscandallo.CheckedChanged
        cambios = True
        If ckEscandallo.Checked Then
            tpDesglose.Parent = tbdatos
            bNuevaComposicion.Visible = True
        Else
            tpDesglose.Parent = Nothing
            bNuevaComposicion.Visible = False
        End If
        ckProduccionSeparada.Enabled = (ckMateriaPrima.Checked And ckEscandallo.Checked)
        ckConNumSerie.Enabled = (ckEscandallo.Checked)
        ckConNumSerie2.Enabled = (ckEscandallo.Checked)
        lbVentaIndependiente.Enabled = (ckEscandallo.Checked)
        ckVersiones.Enabled = ckEscandallo.Checked
    End Sub

    Private Sub ckOpcion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckOpcion.CheckedChanged
        cambios = True
        PrecioOpcion.Enabled = ckOpcion.Checked
    End Sub

    Private Sub ckComprable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckComprable.CheckedChanged
        cambios = True
        'gbCoste.Enabled = ckComprable.Checked

        If ckComprable.Checked And VerCostes Then
            gbCoste.Enabled = True
            If VerCostes Then
                'tpProveedores.Parent = tbdatos
                'tpPreciosXcantidad.Parent = tbdatos
                tpProveedores.Enabled = True
                tpPreciosXcantidad.Enabled = True
            End If
        Else
            gbCoste.Enabled = False
            'tpProveedores.Parent = Nothing
            ' tpPreciosXcantidad.Parent = Nothing
            tpProveedores.Enabled = False
            tpPreciosXcantidad.Enabled = False
        End If

    End Sub

    Private Sub cbProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectionChangeCommitted
        If cbProveedor.SelectedIndex <> -1 Then
            codMonedaC = funcPR.campoMoneda(cbProveedor.SelectedItem.itemdata)
            lbMonedaC.Text = funcMO.CampoSimbolo(codMonedaC)
        End If
    End Sub

    Private Sub rbArticulo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckMateriaPrima.CheckedChanged 'rbArticulo.CheckedChanged, rbMateriaPrima.CheckedChanged
        cbTipo.Text = ""
        cambios = True
        cbTipo.SelectedIndex = -1
        If ckMateriaPrima.Checked Then
            cbSeccion.Enabled = True
            bSecciones.Enabled = True
            lbTipo.Text = "FAMILIA"
            lbSubTipo.Text = "SUBFAMILIA"
            Call IntroducirFamilias()
            If G_AGeneral = "G" Then
                ckComprable.Checked = True
                ckVendible.Checked = False
            End If
        Else
            cbSeccion.Enabled = ckEscandallo.Enabled
            bSecciones.Enabled = ckEscandallo.Enabled
            lbTipo.Text = "TIPO"
            lbSubTipo.Text = "SUBTIPO"
            Call IntroducirTiposArticulo()
            If G_AGeneral = "G" Then
                ckComprable.Checked = False
                ckVendible.Checked = True
            End If
        End If
        ckProduccionSeparada.Enabled = (ckMateriaPrima.Checked And ckEscandallo.Checked)
    End Sub

    Private Sub lvEscandallos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEscandallos.DoubleClick
        If lvEscandallos.SelectedItems.Count > 0 And VerCostes Then
            Dim iidEscandallo As Integer = lvEscandallos.SelectedItems(0).Text
            Dim GG As New GestionEscandallos
            GG.SoloLectura = vSoloLectura
            GG.pidEscandallo = iidEscandallo
            GG.ShowDialog()
            Call CargarEscandallos()
        End If
    End Sub

    Private Sub lvConceptos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim iidArticulo As Integer = lvConceptos.SelectedItems(0).SubItems(7).Text
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.ShowDialog()
            Call CargarArticulo()
            'recalcular el coste del artículo y el escandallo del artículo y los artículos de los que es componente
        End If
    End Sub

    Private Sub cbVersion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVersion.SelectedIndexChanged
        If semaforo Then
            If cbVersion.SelectedIndex <> -1 And IsNumeric(cbVersion.Text) Then
                iidEscandallo = funcES.ExisteEscandalloVersionUltima(idArticulo.Text, cbVersion.Text)
                Call CargarDesglose(iidEscandallo)
            End If

        End If
    End Sub

#End Region

    Private Sub bVerEscandallo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerEscandallo.Click
        'Abrimos Gestión de Escandallos o Gestión de Composición según el tipo
        bVerEscandallo.Enabled = False
        If iidEscandallo > 0 Then
            Dim dts As DatosEscandallo = funcES.Mostrar1(iidEscandallo)
            If dts.gComposicion Then
                Dim GG As New GestionComposicion
                GG.SoloLectura = vSoloLectura
                GG.pidEscandallo = iidEscandallo
                GG.ShowDialog()
            Else
                Dim GG As New GestionEscandallos
                GG.SoloLectura = vSoloLectura
                GG.pidEscandallo = iidEscandallo
                GG.ShowDialog()
            End If

            Call CargarArticulo()
        Else
            'Si no hay escandallo definido proponemos crear uno nuevo
            If lvConceptos.Items.Count = 0 Then
                If MsgBox("Aún no se ha creado el escandallo de componentes de este artículo. ¿Desea crearlo ahora?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim gg As New GestionEscandallos
                    gg.SoloLectura = vSoloLectura
                    gg.pidArticulo = idArticulo.Text
                    gg.pidEscandallo = 0
                    gg.ShowDialog()
                    If gg.pidEscandallo > 0 Then
                        iidEscandallo = gg.pidEscandallo
                        Call CargarDesglose(iidEscandallo)
                    Else
                        PrecioUnitarioC.Text = funcAR.PrecioCoste(idArticulo.Text)
                    End If
                End If

            End If
        End If
        bVerEscandallo.Enabled = True
    End Sub

    Private Sub bNuevoEscandallo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevaComposicion.Click
        'Abrimos Gestión de Escandallos o Gestión de Composición según el tipo
        Dim iidArticuloBase = funcES.idArticuloBaseArticulo(idArticulo.Text)
        If iidArticuloBase > 0 Then
            Select Case MsgBox("Este artículo ya es una composición del artículo base " & funcAR.codArticulo(iidArticuloBase) & " . Crear la opción a partir de esta base (SI) o a partir de " & codArticulo.Text & " ? (NO) ", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Call NuevoEscandallo(iidArticuloBase)
                Case MsgBoxResult.No
                    Call NuevoEscandallo(idArticulo.Text)
                Case MsgBoxResult.Cancel

            End Select
        Else
            Call NuevoEscandallo(idArticulo.Text)
        End If
    End Sub

    Private Sub NuevoEscandallo(ByVal iidArticuloBase As Integer)
        Dim GG As New GestionComposicion
        GG.SoloLectura = vSoloLectura
        GG.pidArticuloBase = iidArticuloBase
        GG.pidEscandallo = 0
        GG.ShowDialog()
        If GG.pidArticulo > 0 And Modo = "DOC" Then
            idArticulo.Text = GG.pidArticulo
            Me.Close()
        End If
        Call CargarArticulo()
    End Sub

    Private Sub bVerProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerProveedor.Click
        If cbProveedor.SelectedIndex <> -1 Then
            Dim proveedor As String = cbProveedor.Text
            Dim GG As New GestionProveedores
            GG.pidProveedor = cbProveedor.SelectedItem.itemdata
            GG.pAbrirTab = 3
            GG.pidArticulo = idArticulo.Text
            GG.ShowDialog()
            Call introducirProveedores()
            cbProveedor.Text = proveedor
            If cbProveedor.SelectedIndex = -1 Then
                cbProveedor.Text = ""
            End If
        End If

    End Sub

    Private Sub bImprimir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Select Case tbdatos.SelectedTab.Name
            Case tpVentas.Name
                Dim GG As New InformeListadoClientesArticulo
                GG.verInforme(0, idArticulo.Text, dtpArticulosVendidosDesde.Value.Date, dtpArticulosVendidosHasta.Value.Date, If(verClientesPropios, iidUsuario, 0))
                GG.ShowDialog()
            Case tpEsacandallos.Name
                MsgBox("IMPRIMIR ESCANDALLOS")
            Case tpProveedores.Name
                MsgBox("IMPRIMIR PROVEEDORES")
            Case tpPreciosXcantidad.Name
                MsgBox("IMPRIMIR PRECIOS")
            Case tpStock.Name
                Dim sBusqueda As String = " articulos.idarticulo = " & idArticulo.Text
                Dim sOrden As String = " articulos.idarticulo desc"
                InformeListadoStock.verInformeArticulo(sBusqueda, sOrden)
                InformeListadoStock.ShowDialog()
            Case tpTraducciones.Name
                If cambios Then
                    MsgBox("Debe guardar antes los cambios.", MsgBoxStyle.Information)
                Else
                    Dim GG As New InformeArticulos
                    GG.verInforme(idArticulo.Text, codArticulo.Text, dtpFechaAlta.Value.Date, dtpFechaBaja.Value.Date, ckActivo.Checked, Articulo.Text, Descripcion.Text, cbUnidadMedida.Text, ckSubEnsamblado.Checked, ckVendible.Checked, StockMinimo.Text, cbProveedor.Text, cbTipo.Text, cbSubTipo.Text, cbAlmacen.Text, cbSeccion.Text, observaciones.Text)
                    GG.ShowDialog()
                End If
        End Select
    End Sub

    'Private Sub GestionArticulo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    Me.Width = 972
    'End Sub

    Private Sub ckConNumSerie2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckConNumSerie2.CheckedChanged, ckConNumSerie.CheckedChanged
        If sender.name = "ckConNumSerie" Then
            If ckConNumSerie2.Checked Then ckConNumSerie2.Checked = Not ckConNumSerie.Checked
        Else
            If ckConNumSerie.Checked Then ckConNumSerie.Checked = Not ckConNumSerie2.Checked
        End If
        cambios = semaforo
    End Sub

#Region "PRECIOS POR CANTIDAD"

    Private Sub LimpiarEdicionPxC()
        cbProveedorPC.Text = cbProveedor.Text
        Desde.Text = ""
        Hasta.Text = ""
        PrecioPC.Text = ""
        lbMonedaPC.Text = lbMonedaC.Text
        dtpFechaPC.Value = Now.Date
        indicePxC = -1
        ep1.Clear()
        ep2.Clear()
    End Sub

    Private Sub CargarLVPreciosXCantidad()
        lvPreciosXCantidad.Items.Clear()
        lvwColumnSorter = New OrdenarLV()
        Me.lvPreciosXCantidad.ListViewItemSorter = lvwColumnSorter
        Dim lista As List(Of DatosPrecioPorCantidad) = funcPX.Mostrar(idArticulo.Text, 0)
        For Each dts As DatosPrecioPorCantidad In lista
            Call NuevaLineaLVPxC(dts)
        Next
    End Sub

    Private Sub NuevaLineaLVPxC(ByVal dts As DatosPrecioPorCantidad)
        With lvPreciosXCantidad.Items.Add(dts.gidRangoPrecio)
            .Subitems.add(dts.gProveedor)
            .subitems.add(dts.gRango)
            .subItems.add(FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6)) & dts.gSimbolo)
            .subItems.add(dts.gFecha)
        End With
    End Sub

    Private Sub ActualizarLineaLVPxC(ByVal dts As DatosPrecioPorCantidad)
        If lvPreciosXCantidad.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvPreciosXCantidad.SelectedIndices(0)
            With lvPreciosXCantidad.Items(indice)
                .SubItems(1).Text = dts.gProveedor
                .SubItems(2).Text = dts.gRango
                .SubItems(3).Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6)) & dts.gSimbolo
                .SubItems(4).Text = dts.gFecha
            End With
        End If
    End Sub

    Private Sub lvPreciosXCantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPreciosXCantidad.Click, lvPreciosXCantidad.SelectedIndexChanged
        If lvPreciosXCantidad.SelectedItems.Count > 0 Then
            ep1.Clear()
            ep2.Clear()
            indicePxC = lvPreciosXCantidad.SelectedIndices(0)
            Dim iidRangoPrecio As Integer = lvPreciosXCantidad.Items(indicePxC).Text
            Dim dts As DatosPrecioPorCantidad = funcPX.Mostrar1(iidRangoPrecio)
            PresentarPrecioxCantidad(dts)
        End If
    End Sub

    Private Sub PresentarPrecioxCantidad(ByVal dts As DatosPrecioPorCantidad)
        cbProveedorPC.Text = dts.gProveedor
        Desde.Text = FormatNumber(dts.gDesde, 2)
        Hasta.Text = If(dts.gHasta = 9999999, "", FormatNumber(dts.gHasta, 2))
        PrecioPC.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
        lbMonedaPC.Text = dts.gSimbolo
        dtpFechaPC.Value = dts.gFecha
    End Sub

    Private Sub GuardarPxC()
        ep1.Clear()
        ep2.Clear()
        Dim validar As Boolean = True
        If cbProveedor.SelectedIndex = -1 Then
            ep2.SetError(cbProveedor, "No se ha seleccionado un proveedor")
        End If

        Dim dts As New DatosPrecioPorCantidad

        If indicePxC = -1 Then
            dts.gidRangoPrecio = 0
        Else
            dts = funcPX.Mostrar1(lvPreciosXCantidad.Items(indicePxC).Text)
        End If
        dts.gidArticulo = idArticulo.Text
        dts.gidProveedor = If(cbProveedorPC.SelectedIndex = -1, 0, cbProveedorPC.SelectedItem.itemdata)
        If IsNumeric(Desde.Text) Then
            dts.gDesde = Desde.Text
        Else
            Desde.Text = 0
            dts.gDesde = 0
        End If
        If IsNumeric(Hasta.Text) Then
            dts.gHasta = Hasta.Text
        Else
            dts.gHasta = 9999999
        End If
        If dts.gDesde > dts.gHasta Then
            validar = False
            ep1.SetError(Desde, "El valor desde ha de ser menor que hasta")
        End If
        dts.gFecha = dtpFechaPC.Value.Date
        If IsNumeric(PrecioPC.Text) Then
            dts.gPrecio = PrecioPC.Text
        Else
            dts.gPrecio = 0
        End If
        If funcPX.ExisteRangoPrecio(dts) Then
            ep1.SetError(Desde, "El rango indicado se solapa con otro existente")
            validar = False
        End If
        If validar Then
            If dts.gidRangoPrecio = 0 Then
                dts.gidRangoPrecio = funcPX.insertar(dts)
                Call CargarLVPreciosXCantidad()
            Else
                funcPX.actualizar(dts)
                Call ActualizarLineaLVPxC(dts)
            End If
            Call LimpiarEdicionPxC()
        End If

    End Sub

    Private Sub lvPreciosXCantidad_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPreciosXCantidad.ColumnClick
        If (e.Column = lvwColumnSorter.SortColumn) Then
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        Me.lvPreciosXCantidad.Sort()
    End Sub

    Private Sub BorrarPxC()
        If lvPreciosXCantidad.SelectedItems.Count > 0 Then
            indicePxC = lvPreciosXCantidad.SelectedIndices(0)
            If MsgBox("¿Desea borrar el precio seleccionado?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                If funcPX.borrar(lvPreciosXCantidad.Items(indicePxC).Text) Then
                    lvwColumnSorter = New OrdenarLV()
                    Me.lvPreciosXCantidad.ListViewItemSorter = lvwColumnSorter
                    lvPreciosXCantidad.Items.RemoveAt(indicePxC)
                    Call LimpiarEdicionPxC()
                End If
            End If
        End If

    End Sub

    Private Sub Desde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Desde.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Desde.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Hasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Hasta.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Hasta.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PrecioPC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioPC.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioPC.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            Call GuardarPxC()
        End If
    End Sub

#End Region

#Region "VENTAS"
    Private Sub LimpiarBusquedaArticulo()
        semaforo = False
        dtpArticulosVendidosDesde.Value = CDate("1-1-" & Now.Year)
        dtpArticulosVendidosHasta.Value = Now.Date
        semaforo = True
    End Sub

    Private Sub CargarlvArtVendidos()
        lvArticulosVendidos.Items.Clear()
        Dim FiltroVerClientesPropios As String = ""
        If verClientesPropios Then
            FiltroVerClientesPropios = " AND Facturas.idPersona = " & iidUsuario
        End If
        Dim sel As String
        sel = "select distinct PP.idCliente, CP.idArticulo, ArticuloCli, codArticuloCli, PP.codMoneda,NombreComercial as Cliente, "
        sel = sel & "(select TOP 1 PrecioNetoUnitario from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura where idArticulo<>0 and idArticulo = CP.idArticulo and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli   and Facturas.idCliente = PP.idCliente  " & FiltroVerClientesPropios & "  order by Facturas.numFactura DESC,idConcepto DESC) as UltimoPrecioNeto,   "
        sel = sel & "(select TOP 1 Facturas.numFactura from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura where idArticulo<>0 and idArticulo = CP.idArticulo  and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli  and Facturas.idCliente = PP.idCliente " & FiltroVerClientesPropios & " order by Facturas.numFactura DESC) as UltimaFactura, "
        sel = sel & "(select TOP 1 Facturas.Fecha from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura where idArticulo<>0 and idArticulo = CP.idArticulo  and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli  and Facturas.idCliente = PP.idCliente " & FiltroVerClientesPropios & " order by Facturas.numFactura DESC) as UltimaFecha, "

        sel = sel & "(select Top 1 Simbolo from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura left join Monedas ON Monedas.codMoneda = Facturas.codMoneda where Facturas.numFactura = CP.numFactura) as Simbolo,  "
        sel = sel & "(select sum(Cantidad) from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura  where idArticulo<>0 and idArticulo = CP.idArticulo  and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli  and Facturas.idCliente = PP.idCliente "
        sel = sel & " AND CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  >= '" & dtpArticulosVendidosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  <= '" & dtpArticulosVendidosHasta.Value.Date & "' " & FiltroVerClientesPropios & " ) as CantidadTotal,  "
        sel = sel & "(select sum(Cantidad*PrecioNetoUnitario) from ConceptosFacturas left join Facturas ON Facturas.numFactura = ConceptosFacturas.numFactura  where idArticulo<>0 and idArticulo = CP.idArticulo and codArticuloCli = CP.codArticuloCli and ArticuloCli = CP.ArticuloCli   and Facturas.idCliente = PP.idCliente "
        sel = sel & " AND CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  >= '" & dtpArticulosVendidosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Facturas.fecha,103))  <= '" & dtpArticulosVendidosHasta.Value.Date & "' " & FiltroVerClientesPropios & " ) as ImporteTotal  "
        sel = sel & " from ConceptosFacturas as CP"
        sel = sel & " left Join Facturas as PP ON PP.numFactura = CP.numFactura "
        sel = sel & " left join Articulos as AR ON AR.idArticulo = CP.idArticulo "
        sel = sel & " left join Clientes as CL ON CL.idCliente = PP.idCliente "
        If verClientesPropios Then
            FiltroVerClientesPropios = " AND PP.idPersona = " & iidUsuario
        End If
        sel = sel & " Where CP.idArticulo = " & idArticulo.Text & " AND CONVERT(datetime,CONVERT(Char(10), PP.fecha,103))  >= '" & dtpArticulosVendidosDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PP.fecha,103))  <= '" & dtpArticulosVendidosHasta.Value.Date & "'  " & FiltroVerClientesPropios

        sel = sel & " Order by Cliente ASC"

        Dim dt As DataTable = funcCL.BusquedaSQL(sel)
        lvwColumnSorterAV = New OrdenarLV()
        lvArticulosVendidos.ListViewItemSorter = lvwColumnSorterAV
        Dim SumaCantidad As Double = 0
        Dim SumaImporte As Double = 0
        Dim codMoneda As String
        Dim ImporteTotal As Double
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        Dim simbolo As String
        For Each linea As DataRow In dt.Rows
            If linea("idCliente") Is DBNull.Value Then
            Else
                With lvArticulosVendidos.Items.Add(linea("idCliente"))
                    .subitems.add(If(linea("Cliente") Is DBNull.Value, "", linea("Cliente")))
                    .subitems.add(If(linea("codArticuloCli") Is DBNull.Value, "", linea("codArticuloCli")))
                    .subitems.add(If(linea("ArticuloCli") Is DBNull.Value, "", linea("ArticuloCli")))
                    .subitems.add(FormatNumber(If(linea("CantidadTotal") Is DBNull.Value, 0, linea("CantidadTotal")), 2))
                    simbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
                    .subitems.add(FormatNumber(If(linea("UltimoPrecioNeto") Is DBNull.Value, 0, linea("UltimoPrecioNeto")), 2) & simbolo)
                    .subitems.add(If(linea("UltimaFactura") Is DBNull.Value, "", linea("UltimaFactura")))
                    .subitems.add(If(linea("UltimaFecha") Is DBNull.Value, "", linea("UltimaFecha")))

                    codMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))

                    ImporteTotal = If(linea("ImporteTotal") Is DBNull.Value, 0, linea("ImporteTotal"))
                    .subitems.add(FormatNumber(ImporteTotal, 2) & simbolo)

                    SumaCantidad = SumaCantidad + If(linea("CantidadTotal") Is DBNull.Value, 0, linea("CantidadTotal"))
                    If codMoneda = "EU" Then
                        SumaImporte = SumaImporte + If(linea("ImporteTotal") Is DBNull.Value, 0, linea("ImporteTotal"))
                    Else
                        SumaImporte = SumaImporte + funcMO.Cambio(If(linea("ImporteTotal") Is DBNull.Value, 0, linea("ImporteTotal")), codMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                End With
            End If
        Next
        lbCambioVendidos.Text = "CAMBIO " & FechaCambioG
        lbCambioVendidos.Visible = AvisoG
        ContadorVendidos.Text = lvArticulosVendidos.Items.Count
        CantidadVendidos.Text = FormatNumber(SumaCantidad, 2)
        TotalVendidos.Text = FormatNumber(SumaImporte, 2)
    End Sub

    Private Sub lvArticulosVendidos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvArticulosVendidos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorterAV.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorterAV.Order = SortOrder.Ascending) Then
                lvwColumnSorterAV.Order = SortOrder.Descending
            Else
                lvwColumnSorterAV.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorterAV.SortColumn = e.Column

            lvwColumnSorterAV.Order = SortOrder.Ascending
        End If
        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        lvArticulosVendidos.Sort()

    End Sub

    Private Sub dtpArticulosVendidosHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpArticulosVendidosHasta.ValueChanged, dtpArticulosVendidosDesde.ValueChanged
        If semaforo Then Call CargarlvArtVendidos()
    End Sub

    Private Sub lvArticulosVendidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulosVendidos.DoubleClick
        'Al hacer doble click, abrimos una vista de la factura
        If lvArticulosVendidos.SelectedItems.Count > 0 Then
            Dim iidCliente As Integer = lvArticulosVendidos.SelectedItems(0).Text
            If iidCliente = 0 Then
                MsgBox("La linea seleccionada no se corresponde con un cliente válido")
            Else
                Dim GG As New InformeListadoClientesArticulo
                GG.verInforme(iidCliente, idArticulo.Text, dtpArticulosVendidosDesde.Value.Date, dtpArticulosVendidosHasta.Value.Date, If(verClientesPropios, iidUsuario, 0))
                GG.ShowDialog()
            End If
        End If

    End Sub

    Private Sub tbArticulosVendidos_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpVentas.Enter
        bImprimir.Enabled = True
    End Sub

    Private Sub gbCabecera_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbCabecera.Enter, tpDesglose.Enter, tpEsacandallos.Enter, tpProveedores.Enter, tpPreciosXcantidad.Enter, tpStock.Enter, tpTraducciones.Enter
        bImprimir.Enabled = True
    End Sub
#End Region

    Private Sub lvArticuloProv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticuloProv.DoubleClick
        Dim sel As String = " Proveedores.idProveedor = " & id_proveedor & "  AND  CP.idArticulo =  " & id_articulo
        Dim GG As New InformeListadoPedidosProv1
        GG.pBusqueda = sel
        GG.pOrden = "numPedido"
        GG.pTotalEU = 0
        GG.ShowDialog()
    End Sub

    Public Sub calcularPrecioC()

        Dim funES As New escandallosCompletos

        Dim precio As Double = 0

        If IsNumeric(Trim(idArticulo.Text)) Then

            funES.calcularCosteArticulo(Trim(idArticulo.Text))

            precio = funES.totalCoste

            If precio = 0 And ckComprable.Checked Then

                PrecioUnitarioC.Text = FormatNumber(dtsAR.gPrecioUnitarioC, If(dtsAR.gPrecioUnitarioC >= 5, 4, 6))

            Else

                PrecioUnitarioC.Text = precio

            End If

        End If

    End Sub

End Class