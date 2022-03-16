Public Class PantallaGeneral

#Region "VARIABLES"

    Dim funcME As New funcionesMenu_Entradas
    Dim funcMEU As New funcionesMenu_EntradasUsuario
    Dim funcU As New FuncionesPersonal
    Dim funcMPU As New funcionesMenu_ParametrosUsuario
    Dim funcMPP As New funcionesMenu_ParametrosPerfil
    Private funcPE As New FuncionesPedidos
    Private funcAL As New FuncionesAlbaranes
    Private funcES As New FuncionesEstados
    Private funcFE As New FuncionesFestivos
    Dim listaMenu As List(Of datosMenu_Entrada) '= funcME.mostrar
    Private funcSE As New FuncionesSecciones
    Public Shared myTimer As New System.Windows.Forms.Timer()
    Private Shared TimerMenus As New System.Windows.Forms.Timer()
    Private vSoloLectura As Boolean
    Private vidUsuario As Integer
    Dim lvPantalla As String
    Private iidPerfil As Integer
    Private colorInactivo As Color = Color.Gray
    Private colorCabecera As Color = Color.Red
    Private lvwColumnSorter As OrdenarLV
    Private lvwColumnSorterC As OrdenarLV
    Private lvwColumnSorterFP As OrdenarLV
    Private funcCO As New funcionesComunicaciones
    Private dtsF As datosFichero
    Private dtsR As datosReferencia
    Private funcFI As New funcionesFicheros
    Private funcRE As New funcionesReferencias
    Private EstadoRecibido As DatosEstado
    Private EstadoRespondido As DatosEstado
    Private EstadoArchivado As DatosEstado
    Private DiasAvisoRojo As Integer
    Private DiasAvisoNaranja As Integer
    Private DiasAvisoNegro As Integer

#End Region

#Region "PROPIEDADES"
    Property pSoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value

        End Set
    End Property

#End Region

#Region "CARGA Y CIERRE"

    Private Sub pantallaprincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        vidUsuario = Inicio.vIdUsuario

        Text = Text & " " & UCase(funcU.campoNombreyApellidos(vidUsuario))

        iidPerfil = 0

        Call CargarMenus()

        gbPedidosPreparados.Visible = False

        gbAlbaranes.Visible = False

        gbComunicaciones.Visible = False

        gbPedidosFechaPrevista.Visible = False

        lbVersion.Text = Inicio.vversion

        AddHandler myTimer.Tick, AddressOf ActualizaTabla

        myTimer.Enabled = False

        Dim func As New FuncionesPersonal

        vSoloLectura = func.EsSoloLectura(vidUsuario)

        Call CargarlvPantalla()

    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'Cerramos la apalicación, para cerrar el formulario de inicio
        Application.Exit()

    End Sub

    Private Sub PantallaGeneral_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Dim Ubicacion As Point = New Point(gbPedidosPreparados.Location.X, Logotipo.Location.Y + Logotipo.Size.Height + 20)

        If gbPedidosPreparados.Visible Then

            gbPedidosPreparados.Location = Ubicacion

            Call CargarPedidosPreparados()

        End If

        If gbPedidosFechaPrevista.Visible Then

            gbPedidosFechaPrevista.Location = gbComunicaciones.Location

            Call CargarPedidosFechaPrevista()

        End If

        If gbAlbaranes.Visible Then

            gbAlbaranes.Location = Ubicacion

            Call CargarAlbaranes()

        End If

        If gbComunicaciones.Visible Then

            Call CargarComunicaciones()

        End If

    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Public Sub CargarMenus()
        listaMenu = funcMEU.mostrarME(vidUsuario)
        If listaMenu.Count = 0 Then
            iidPerfil = funcU.campoidPerfil(vidUsuario)
            'Si  no hay un menú específico del usuario, carga el del perfil
            Dim funcMEP As New funcionesMenu_EntradasPerfil
            listaMenu = funcMEP.mostrarME(iidPerfil)
        End If
        msGeneral.Items.Clear()
        Call CargarItems(0, New ToolStripMenuItem)

    End Sub

    Private Sub PantallaPrincipal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        If gbAlbaranes.Visible Then Call CargarAlbaranes()

        If gbPedidosPreparados.Visible Then Call CargarPedidosPreparados()

        If gbComunicaciones.Visible Then Call CargarComunicaciones()

        If gbPedidosFechaPrevista.Visible Then Call CargarPedidosFechaPrevista()

        Call CargarMenus()

    End Sub

    Private Sub CargarlvPantalla()

        Try

            Dim dts As New datosMenu_Entrada

            gbPedidosPreparados.Visible = False

            gbAlbaranes.Visible = False

            gbComunicaciones.Visible = False

            gbPedidosFechaPrevista.Visible = False

            For Each dts In listaMenu

                If dts.gNivel > 250 Then  'Marcamos con un nivel >250 las entradas que son en realizad listview en la pantalla principal

                    lvPantalla = dts.gEjecutar

                    Dim Ubicacion As Point = New Point(gbPedidosPreparados.Location.X, Logotipo.Location.Y + Logotipo.Size.Height + 20)

                    Select Case lvPantalla

                        Case "lvPedidosServir"

                            lvwColumnSorter = New OrdenarLV()

                            lvPedidosPreparados.ListViewItemSorter = lvwColumnSorter

                            gbPedidosPreparados.Location = Ubicacion

                            gbPedidosPreparados.Visible = True

                            myTimer.Interval = 2 * 60000 'en milisegundos

                            myTimer.Enabled = True

                            Call CargarPedidosPreparados()

                        Case "lvPedidosFechaPrevista"

                            gbComunicaciones.Visible = False

                            lvwColumnSorterFP = New OrdenarLV()

                            lvPedidosFechaPrevista.ListViewItemSorter = lvwColumnSorterFP

                            gbPedidosFechaPrevista.Location = gbComunicaciones.Location

                            gbPedidosFechaPrevista.Visible = True

                            Dim cmSubMenu As New ContextMenu

                            cmSubMenu.MenuItems.Add("Ver detalles de Producción", New System.EventHandler(AddressOf Me.OnClicksubMenu))

                            lvPedidosFechaPrevista.ContextMenu = cmSubMenu

                            myTimer.Interval = 2 * 60000 'en milisegundos

                            myTimer.Enabled = True

                            Call ActualizarlbDiasPedidos()

                            Call CargarPedidosFechaPrevista()

                        Case "lvAlbaranesServir"

                            gbAlbaranes.Location = Ubicacion

                            lvwColumnSorter = New OrdenarLV()

                            lvAlbaranes.ListViewItemSorter = lvwColumnSorter

                            gbAlbaranes.Visible = True

                            myTimer.Interval = 2 * 60000 'en milisegundos

                            myTimer.Enabled = True

                            Dim cmAlbaranes As New ContextMenu

                            If funcU.Permiso(vidUsuario, "BusquedaPedidos") Or funcU.Permiso(vidUsuario, "BusquedaAlbaranes") Then

                                cmAlbaranes.MenuItems.Add("ABRIR", New System.EventHandler(AddressOf Me.OnClickAlbaran))

                            End If

                            cmAlbaranes.MenuItems.Add("SERVIR", New System.EventHandler(AddressOf Me.OnClickAlbaran))

                            cmAlbaranes.MenuItems.Add("VISTA PREVIA", New System.EventHandler(AddressOf Me.OnClickAlbaran))

                            lvAlbaranes.ContextMenu = cmAlbaranes

                            Call CargarAlbaranes()

                        Case "lvComunicaciones"

                            If Not gbPedidosFechaPrevista.Visible Then

                                Call CargarIconos()

                                EstadoArchivado = funcES.EstadoTraspasado("COMUNICACION")

                                EstadoRecibido = funcES.EstadoEspera("COMUNICACION")

                                EstadoRespondido = funcES.EstadoEnCurso("COMUNICACION")

                                gbComunicaciones.Visible = True

                                myTimer.Interval = 2 * 60000 'en milisegundos

                                myTimer.Enabled = True

                                Call CargarComunicaciones()

                            End If

                    End Select

                Else

                    lvPantalla = ""

                End If

            Next

        Catch ex As Exception

            ex.Data.Add("lvPantalla", lvPantalla)

            CorreoError(ex)

        End Try

    End Sub

    Private Sub ActualizarlbDiasPedidos()

        Dim DI As New DatosIniciales

        DiasAvisoRojo = DI.DiasAviso1

        DiasAvisoNaranja = DI.DiasAviso2

        DiasAvisoNegro = DI.DiasAviso3

        If DiasAvisoRojo = 0 Then

            lbDias1.Text = "DESDE HOY"

        ElseIf DiasAvisoRojo = 1 Then

            lbDias1.Text = DiasAvisoRojo & " DÍA LABORABLE ANTES"

        ElseIf DiasAvisoRojo = -1 Then

            lbDias1.Text = DiasAvisoRojo & " DÍA LABORABLE DESPUÉS"

        ElseIf DiasAvisoRojo > 0 Then

            lbDias1.Text = DiasAvisoRojo & " DÍAS LABORABLES ANTES"

        Else

            lbDias1.Text = -DiasAvisoRojo & " DÍAS LABORABLES DESPUÉS"

        End If

        If DiasAvisoNaranja = 0 Then

            lbDias2.Text = "DESDE HOY"

        ElseIf DiasAvisoNaranja = 1 Then

            lbDias2.Text = DiasAvisoNaranja & " DÍA LABORABLE ANTES"

        ElseIf DiasAvisoNaranja = -1 Then

            lbDias2.Text = DiasAvisoNaranja & " DÍA LABORABLE DESPUÉS"

        ElseIf DiasAvisoNaranja > 0 Then

            lbDias2.Text = DiasAvisoNaranja & " DÍAS LABORABLES ANTES"

        Else

            lbDias2.Text = -DiasAvisoNaranja & " DÍAS LABORABLES DESPUÉS"

        End If

        If DiasAvisoNegro = 0 Then

            lbDias3.Text = "DESDE HOY"

        ElseIf DiasAvisoNegro = 1 Then

            lbDias3.Text = DiasAvisoNegro & " DÍA ANTES"

        ElseIf DiasAvisoNegro = -1 Then

            lbDias3.Text = DiasAvisoNegro & " DÍA DESPUÉS"

        ElseIf DiasAvisoNegro >= 0 Then

            lbDias3.Text = DiasAvisoNegro & " DÍAS ANTES"

        Else

            lbDias3.Text = -DiasAvisoNegro & " DÍAS DESPUÉS"

        End If

    End Sub

    Private Sub ActualizaTabla(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        If Me.Focused Then

            Try

                If gbAlbaranes.Visible Then Call CargarAlbaranes()

                If gbPedidosPreparados.Visible Then Call CargarPedidosPreparados()

                If gbComunicaciones.Visible Then Call CargarComunicaciones()

                If gbPedidosFechaPrevista.Visible Then CargarPedidosFechaPrevista()

            Catch ex As Exception

                ex.Data.Add("lvPantalla", lvPantalla)

                CorreoError(ex)

            End Try

        End If

    End Sub

    Private Sub ActualizaMenus(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        If Me.Focused Then Call CargarMenus()

    End Sub

    Protected Sub Item_OnClickEjecutar(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            vSoloLectura = Parametro(sender.name, "SOLO LECTURA")

            Select Case sender.name

                Case "GestionArticuloCliente"

                    Dim PC As New GestionArticuloCliente

                    PC.SoloLectura = vSoloLectura

                    PC.pidArticulo = 0

                    PC.pidCliente = 0

                    PC.Show()

                Case "NuevoCliente"

                    Dim GC As New GestionClientes

                    GC.SoloLectura = vSoloLectura

                    GC.pidCliente = 0

                    GC.Show()

                Case "ConsultaCliente"

                    Dim BC As New busquedaCliente

                    BC.SoloLectura = vSoloLectura

                    BC.Show()

                Case "NuevoProveedor"

                    Dim AP As New GestionProveedores 'AltaProveedor

                    AP.SoloLectura = vSoloLectura

                    AP.pidProveedor = 0

                    AP.Show()

                Case "ConsultaProveedor"

                    Dim BP As New busquedaproveedor

                    BP.SoloLectura = vSoloLectura

                    BP.Show()

                Case "GestionMaster"

                    Dim GM As New GestionMaster

                    GM.SoloLectura = vSoloLectura

                    GM.ShowDialog()

                    If gbPedidosFechaPrevista.Visible Then Call ActualizarlbDiasPedidos()

                Case "NuevoEscandallo"

                    Dim GE As New GestionEscandallos

                    GE.SoloLectura = vSoloLectura

                    GE.pidEscandallo = 0

                    GE.Show()

                Case "BusquedaEscandallo"

                    Dim BE As New BusquedaEscandallo

                    BE.SoloLectura = vSoloLectura

                    BE.Show()

                Case "GestionUnidades"

                    Dim GU As New gestionUnidades

                    GU.SoloLectura = vSoloLectura

                    GU.Show()

                Case "GestionFamilias"

                    Dim GF As New GestionFamilias

                    GF.SoloLectura = vSoloLectura

                    GF.Show()

                Case "GestionTiposArticulo"

                    Dim GA As New GestionTiposArticulo

                    GA.SoloLectura = vSoloLectura

                    GA.Show()

                Case "GestionMediosPago"

                    Dim GMP As New gestionmediodepago

                    GMP.SoloLectura = vSoloLectura

                    GMP.Show()

                Case "GestionTiposPago"

                    Dim GTP As New gestiontipopago

                    GTP.SoloLectura = vSoloLectura

                    GTP.Show()

                Case "GestionSecciones"

                    Dim GS As New gestionSecciones

                    GS.SoloLectura = vSoloLectura

                    GS.Show()

                Case "GestionPersonal"

                    Dim GP As New GestionPersonal

                    GP.SoloLectura = vSoloLectura

                    GP.Show()

                Case "GestionPerfiles"

                    Dim GP As New GestionPerfiles

                    GP.SoloLectura = vSoloLectura

                    GP.Show()

                Case "GestionAlmacenes"

                    Dim GM As New gestionAlmacenes

                    GM.SoloLectura = vSoloLectura

                    GM.Show()

                Case "GestionTiposCompra"

                    Dim GTC As New GestionTiposCompra

                    GTC.SoloLectura = vSoloLectura

                    GTC.Show()

                Case "CambioMoneda"

                    Dim CM As New GestionCambioMoneda

                    CM.SoloLectura = vSoloLectura

                    CM.Show()

                Case "NuevoPedidoProv"

                    Dim GPP As New GestionPedidoProveedor

                    GPP.SoloLectura = vSoloLectura

                    GPP.pNumPedido = 0

                    GPP.Show()

                Case "BusquedaPedidoProveedor"

                    Dim GPP As New BusquedaPedidoProveedor

                    GPP.Show()

                Case "AltaArticulo"

                    Dim GP As New GestionArticulo

                    GP.pidArticulo = 0

                    GP.SoloLectura = vSoloLectura

                    GP.Show()

                Case "BusquedaArticulo"

                    Dim bp As New lbBusquedaArticulo

                    bp.pModo = "A"

                    bp.Show()

                Case "GestionPermisos"

                    Dim GP As New GestionPermisos

                    GP.Show()

                Case "GestionStock"

                    Dim GR As New GestionStock

                    GR.SoloLectura = vSoloLectura

                    GR.Show()

                Case "GestionTiposEscandallo"

                    Dim GT As New gestionTiposEscandallo

                    GT.SoloLectura = vSoloLectura

                    GT.Show()

                Case "GestionTiposIVA"

                    Dim GG As New GestionTiposIVA

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "GestionTiposRetencion"

                    Dim GG As New GestionTiposRetencion

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedaOfertas"

                    Dim GG As New busquedaOfertas

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "NuevaOferta"

                    Dim GG As New GestionOferta

                    GG.SoloLectura = vSoloLectura

                    GG.pnumOferta = 0

                    GG.Show()

                Case "BusquedaProformas"

                    Dim GG As New busquedaProformas

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "NuevaProforma"

                    Dim GG As New GestionProforma

                    GG.SoloLectura = vSoloLectura

                    GG.pnumProforma = 0

                    GG.Show()

                Case "BusquedaPedidos"

                    Dim GG As New busquedaPedidos

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "NuevoPedido"

                    Dim GG As New GestionPedido

                    GG.SoloLectura = vSoloLectura

                    GG.pnumPedido = 0

                    GG.Show()

                Case "BusquedaAlbaranes"

                    Dim GG As New busquedaAlbaranes

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "NuevoAlbaran"

                    Dim GG As New GestionAlbaran

                    GG.SoloLectura = vSoloLectura

                    GG.pnumAlbaran = 0

                    GG.Show()

                Case "BusquedaFacturas"

                    Dim GG As New busquedaFacturas

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "NuevaFactura"

                    Dim GG As New GestionFactura1

                    GG.SoloLectura = vSoloLectura

                    GG.pnumFactura = 0

                    GG.Show()

                Case "GestionEtiquetas"

                    Dim GG As New GestionEtiquetas

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "GestionProduccion"

                    Dim GG As New GestionProduccion

                    GG.SoloLectura = vSoloLectura

                    GG.ShowDialog()

                Case "VistaElectronica"

                    Dim GG As New DibujarVistaCompleta

                    GG.pVista = "ELECTRÓNICA"

                    GG.pTitulo = "VISTA ELECTRÓNICA"

                    GG.pColumnasFijasIzquierda = 3

                    GG.pFilasFijasArriba = 4

                    GG.pFilasFijasAbajo = 2

                    GG.pVerAgrupaciones = True

                    GG.pMaximizar = True

                    GG.Show()

                Case "VistaLogistica"

                    Dim GG As New busquedaPedidosProduccion

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "VistaTaller"

                    Dim GG As New DibujarVistaCompleta

                    GG.pVista = "TALLER"

                    GG.pTitulo = "VISTA TALLER"

                    GG.pColumnasFijasIzquierda = 4

                    GG.pFilasFijasArriba = 4

                    GG.pFilasFijasAbajo = 2

                    GG.pVerAgrupaciones = True

                    GG.pMaximizar = True

                    GG.Show()

                Case "GestionArticulosProv"

                    Dim GG As New GestionArticulosProv

                    GG.SoloLectura = vSoloLectura

                    GG.pidArticulo = 0

                    GG.pidProveedor = 0

                    GG.ShowDialog()

                Case "BusquedaEquipos"

                    Dim GG As New BusquedaEquipos

                    GG.SoloLectura = vSoloLectura

                    GG.pidArticulo = 0

                    GG.pidCliente = 0

                    GG.ShowDialog()

                Case "BusquedaSimpleArticulo"

                    Dim GG As New BusquedaSimpleArticulo

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = "A"

                    GG.ShowDialog()

                Case "GestionPaises"

                    Dim gg As New GestionPaises

                    gg.SoloLectura = vSoloLectura

                    gg.Show()

                Case "GestionBancos"

                    Dim gg As New GestionBancos

                    gg.SoloLectura = vSoloLectura

                    gg.Show()

                Case "GestionFestivos"

                    Dim GG As New GestionFestivos

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedaVencimientos"

                    Dim GG As New busquedaVencimientos

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "EstadisticaProduccion"

                    Dim GG As New EstadisticaProduccion

                    GG.ShowDialog()

                Case "InformeResumenFacturacion"

                    Dim GG As New InformeResumenFacturacion

                    GG.Show()

                Case "GestionSubTiposProduccion"

                    Dim GG As New GestionSubTiposProduccion

                    GG.soloLectura = vSoloLectura

                    GG.Show()

                Case "NuevoAlbaranProv"

                    Dim GG As New GestionAlbaranAProv

                    GG.SoloLectura = vSoloLectura

                    GG.pnumAlbaran = 0

                    GG.Show()

                Case "BusquedaAlbaranProv"

                    Dim GG As New busquedaAlbaranesAProv

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "PeticionesInternasMaterial"

                    Dim GG As New BusquedaPeticionInternaMaterial

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "NuevaPeticionInterna"

                    Dim GG As New GestionPeticionInternaMaterial

                    GG.SoloLectura = vSoloLectura

                    GG.pIDsConceptos = New List(Of Long)

                    GG.Show()

                Case "VistaTallerAbreviada"

                    Dim GG As New DibujarVistaCompleta

                    GG.pVista = "VistaTallerAbreviada"

                    GG.pTitulo = "VISTA TALLER ABREVIADA"

                    GG.pFilasFijasAbajo = 0

                    GG.pFilasFijasArriba = 1

                    GG.pColumnasFijasIzquierda = 5

                    GG.pVerAgrupaciones = False

                    GG.pMaximizar = False

                    GG.Show()

                Case "NuevaReparacion"

                    Dim GG As New GestionReparacion

                    GG.SoloLectura = vSoloLectura

                    GG.pnumReparacion = 0

                    GG.Show()

                Case "BusquedaReparacion"

                    Dim GG As New busquedaReparaciones

                    GG.pModo = ""

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "NuevoAlbaranDeProv"

                    Dim GG As New GestionAlbaranDeProv

                    GG.pidAlbaran = 0

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "busquedaAlbaranesDeProv"

                    Dim GG As New busquedaAlbaranesDeProv

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "GestionFacturasDeProv"

                    Dim GG As New GestionFacturaProv

                    GG.pidFactura = 0

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "busquedaFacturasDeProv"

                    Dim GG As New busquedaFacturasProv

                    GG.SoloLectura = vSoloLectura

                    GG.pModo = ""

                    GG.Show()

                Case "VencimientosFacturasDeProv"

                    Dim GG As New busquedaVencimientosProv

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedaFacturasProvPendientes"

                    Dim GG As New busquedaFacturasProvPendientes

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedaFacturasPendientes"

                    Dim GG As New busquedaFacturasPendientes

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedaEtiquetas"

                    Dim GG As New busquedaEtiquetas

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "NuevaEtiqueta"

                    Dim GG As New EditorEtiquetas

                    GG.pidEtiqueta = 0

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "GestionIVAS"

                    Dim GG As New GestionIVAs

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "GestionVersionesEscandallo"

                    Dim GG As New GestionVersionesEscandallo

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "MiniCRM"

                    Dim GG As New MiniCRM

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "GestionTextosMail"

                    Dim GG As New GestionTextosMail

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "AsignacionComisiones"

                    Dim GG As New AsignacionComisiones

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "LiquidacionComisiones"

                    Dim GG As New LiquidacionComisiones

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedaLiquidaciones"

                    Dim GG As New BusquedaLiquidaciones

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "EstadisticasVentas"

                    Dim GG As New EstadisticasVentas

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "GestionCuentasPropias"

                    Dim GG As New GestionCuentasPropias

                    GG.SoloLectura = vSoloLectura

                    GG.Show()

                Case "BusquedalibreArticulos"

                    Dim GG As New busquedalibreArticulos

                    GG.Show()

                Case "gestionInventarios"

                    Dim GG As New gestionInventarios

                    GG.Show()

                Case "vistaSimple"

                    Dim GG As New vistaSimple

                    GG.Show()

                Case "BusquedaAticulosComprados"

                    Dim GG As New BusquedaArticulosComprados

                    GG.Show()

                Case "menu_produccion"

                    Dim GG As New menuProduccion

                    GG.Show()

                Case "Editor_Etiqueta_Offline"

                    Dim GG As New EditorEtiqueta

                    GG.ShowDialog()

                Case "EtiquetasCelulas"

                    MsgBox("Etiquetas Celulas")

                Case "EtiquetasEquipos"

                    MsgBox("Etiquetas Equipos")

                Case "Cambios S/N entre pedidos"

                    Dim gg As New CambioEquipos

                    gg.ShowDialog()

                Case Else

            End Select

        Catch ex As Exception

            ex.Data.Add("Ejecutar", sender.name)

            CorreoError(ex)

        End Try

    End Sub

    Private Sub CargarItems(ByVal iidPadre As Integer, ByVal tsmiPadre As ToolStripMenuItem)

        Dim dts As New datosMenu_Entrada

        Dim tsmiHijo As ToolStripMenuItem

        For Each dts In listaMenu

            If dts.gNivel < 250 Then

                If dts.gidMenuPadre = iidPadre Then

                    tsmiHijo = New ToolStripMenuItem(dts.gNombre, Nothing, New System.EventHandler(AddressOf Me.Item_OnClickEjecutar), dts.gEjecutar)

                    If iidPadre = 0 Then

                        msGeneral.Items.Add(tsmiHijo)

                    Else

                        tsmiPadre.DropDownItems.Add(tsmiHijo)

                    End If

                    Call CargarItems(dts.gidMenu, tsmiHijo)

                End If

            End If

        Next

    End Sub

    Private Function Parametro(ByVal sEjecutar As String, ByVal sParametro As String) As Boolean

        Dim iidmenu As Integer = funcME.iidMenu(sEjecutar)

        If iidPerfil = 0 Then

            Return funcMPU.Parametro(vidUsuario, iidmenu, sParametro)

        Else

            Return funcMPP.Parametro(iidPerfil, sEjecutar, sParametro)

        End If

    End Function

#End Region

#Region "lvAlbaranes"

    Private Sub CargarAlbaranes()
        Try
            lvAlbaranes.Items.Clear()

            lvwColumnSorter = New OrdenarLV()
            lvAlbaranes.ListViewItemSorter = lvwColumnSorter
            Dim sBusqueda As String = " Estados.EnCurso = 1 OR (Estados.Traspasado = 1 AND DOC.Recogido = 0) " 'Albaranes preparados o ya facturados pero no recogidos 
            Dim lista As List(Of DatosAlbaran) = funcAL.Busqueda(sBusqueda, "", True)
            sBusqueda = " DOC.numPedido in (select distinct numPedido from ConceptosPedidos where numPedido = DOC.numPedido and CantidadPreparada>0) And SinAlbaran = 1 And Recogido = 0 and bAnulado=0 "
            Dim listaP As List(Of DatosPedido) = funcPE.Busqueda(sBusqueda, "", True)
            Dim dtsA As DatosAlbaran
            For Each dtsP As DatosPedido In listaP
                dtsA = New DatosAlbaran
                dtsA.gnumAlbaran = 0
                dtsA.gnumSPedido.Add(dtsP.gnumPedido)
                dtsA.gidCliente = dtsP.gidCliente
                dtsA.gCliente = dtsP.gCliente
                dtsA.gFecha = dtsP.gFecha
                dtsA.gAgenciaTransporte = ""
                dtsA.gFechaEntrega = dtsP.gFechaEntrega
                lista.Add(dtsA)
            Next

            Dim item As ListViewItem
            For Each dts As DatosAlbaran In lista
                item = New ListViewItem
                If dts.gnumAlbaran > 0 Then
                    item.Text = "ALBARÁN"
                    item.SubItems.Add(dts.gnumAlbaran)
                    Select Case DiasLaborableEntre(dts.gCreacion, Now.Date)
                        Case Is <= 1
                            item.ForeColor = Color.Black
                        Case 2
                            item.ForeColor = Color.DarkOrange
                        Case Is >= 3
                            item.ForeColor = Color.Red
                    End Select
                ElseIf Not dts.gnumSPedido Is Nothing AndAlso dts.gnumSPedido.Count > 0 Then
                    item.Text = "PEDIDO"
                    item.SubItems.Add(dts.gnumSPedido(0))
                    Select Case DiasLaborableEntre(Now.Date, dts.gFechaEntrega)
                        Case Is <= 0
                            item.ForeColor = Color.Red
                        Case 1
                            item.ForeColor = Color.DarkOrange
                        Case Is >= 2
                            item.ForeColor = Color.Black
                    End Select

                Else
                    item.Text = ""
                    item.SubItems.Add("")
                End If
                item.SubItems.Add(If(dts.gidCliente > 0, dts.gCliente, dts.gProveedor))
                item.SubItems.Add(dts.gFecha)
                item.SubItems.Add(dts.gAgenciaTransporte)

                lvAlbaranes.Items.Add(item)
            Next

            lvwColumnSorter.SortColumn = 3
            lvwColumnSorter.Order = SortOrder.Ascending
            Me.lvAlbaranes.Sort()

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub


    Private Function DiasLaborableEntre(ByVal Fecha1 As Date, ByVal Fecha2 As Date) As Integer
        Dim Resultado As Integer = 0
        If Fecha1 > Fecha2 Then
            Resultado = -1
        ElseIf Fecha1 = Fecha2 Then
            Resultado = 0
        Else
            Do While Fecha1 < Fecha2
                If Not funcFE.EsFestivo(Fecha1) Then Resultado = Resultado + 1
                Fecha1 = Fecha1.AddDays(1)
            Loop
        End If
        Return Resultado
    End Function


    Private Sub lvAlbaranes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles lvAlbaranes.DoubleClick
        'Si hacemos doble click, se abre el formulario de gestión de Albaranes con el Albaran correspondiente
        If lvAlbaranes.SelectedItems.Count > 0 Then
            Dim GG As New subServirAlbaran
            GG.pnumAlbaran = lvAlbaranes.SelectedItems(1).Text
            GG.SoloLectura = vSoloLectura
            GG.ShowDialog()
            Call CargarAlbaranes()
        End If
    End Sub


    Private Sub lvAlbaranes_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvAlbaranes.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorter.SortColumn = e.Column

            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvAlbaranes.Sort()

    End Sub


    Protected Sub OnClickAlbaran(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If lvAlbaranes.SelectedItems.Count > 0 Then

            Dim indice As Integer = lvAlbaranes.SelectedIndices(0)
            Dim item As ListViewItem = lvAlbaranes.Items(indice)
            If sender.text = "VISTA PREVIA" And item.Text = "PEDIDO" Then
                Dim GG As New InformePedido
                GG.verInforme(item.SubItems(1).Text, 1, True, False, True)
                GG.ShowDialog()
            ElseIf sender.text = "VISTA PREVIA" And item.Text = "ALBARÁN" Then
                Dim GG As New InformeAlbaran
                GG.verInforme(item.SubItems(1).Text, 1)
                GG.ShowDialog()
            ElseIf sender.text = "SERVIR" And item.Text = "PEDIDO" Then
                If MsgBox("¿SERVIR EL PEDIDO " & item.SubItems(1).Text & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    funcPE.CambiaRecogido(item.SubItems(1).Text, True)
                    lvAlbaranes.Items.RemoveAt(indice)
                End If
            ElseIf sender.text = "SERVIR" And item.Text = "ALBARÁN" Then
                Dim GG As New subServirAlbaran
                GG.pnumAlbaran = item.SubItems(1).Text
                GG.SoloLectura = vSoloLectura
                GG.ShowDialog()
            ElseIf sender.text = "ABRIR" And item.Text = "PEDIDO" Then
                If funcU.Permiso(vidUsuario, "BusquedaPedidos") Then
                    Dim GG As New GestionPedido
                    GG.SoloLectura = vSoloLectura
                    GG.pnumPedido = item.SubItems(1).Text
                    GG.ShowDialog()
                End If
            ElseIf sender.text = "ABRIR" And item.Text = "ALBARÁN" Then
                If funcU.Permiso(vidUsuario, "BusquedaAlbaranes") Then
                    Dim GG As New GestionAlbaran
                    GG.SoloLectura = vSoloLectura
                    GG.pnumAlbaran = item.SubItems(1).Text
                    GG.ShowDialog()
                End If
            End If
        End If
    End Sub


#End Region

#Region "lvPedidosPreparados"


    Private Sub CargarPedidosPreparados()
        Try
            lvPedidosPreparados.Items.Clear()

            lvwColumnSorter = New OrdenarLV()
            lvPedidosPreparados.ListViewItemSorter = lvwColumnSorter
            Dim sBusqueda As String = " Estados.Bloqueado = 0  AND (Select count(idConcepto) from ConceptosPedidos where CantidadPreparada>0 and numPedido = DOC.numPedido)>0 " '" (Estados.Completo = 1 or Estados.Entregado = 1 )"

            Dim lista As List(Of DatosPedido) = funcPE.Busqueda(sBusqueda, "", True)
            For Each dts As DatosPedido In lista

                With lvPedidosPreparados.Items.Add(dts.gnumPedido)
                    .SubItems.Add(dts.gCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gFechaEntrega)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gPrecioTransporte, 2) & dts.gSimbolo)
                    .SubItems.Add(dts.gReferenciaCliente)
                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If

                End With
            Next

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub



    Private Sub lvPedidosPreparados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPedidosPreparados.DoubleClick
        'Si hacemos doble click, se abre el formulario de gestión de pedidos con el pedido correspondiente
        If lvPedidosPreparados.SelectedItems.Count > 0 Then
            Dim GG As New GestionPedido
            GG.pnumPedido = lvPedidosPreparados.SelectedItems(0).Text
            GG.SoloLectura = vSoloLectura
            GG.ShowDialog()
            Call CargarPedidosPreparados()
        End If
    End Sub


    Private Sub lvPedidos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPedidosPreparados.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorter.SortColumn = e.Column

            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvPedidosPreparados.Sort()


    End Sub



#End Region

#Region "Pedidos FechaPrevista"

    Private Sub CargarPedidosFechaPrevista()
        Try
            lvPedidosFechaPrevista.Items.Clear()

            lvwColumnSorterFP = New OrdenarLV()
            lvPedidosFechaPrevista.ListViewItemSorter = lvwColumnSorterFP
            Dim sBusqueda As String = " ((sinAlbaran = 1 AND Recogido = 0) OR sinAlbaran = 0) AND  Estados.Bloqueado = 0  AND BAnulado<>1 and datediff(day, GetDate(),DOC.FechaEntrega )<= " & DiasAvisoNegro

            Dim lista As List(Of DatosPedido) = funcPE.Busqueda(sBusqueda, " FechaEntrega ASC ", True)
            For Each dts As DatosPedido In lista

                With lvPedidosFechaPrevista.Items.Add(dts.gnumPedido)
                    .SubItems.Add(dts.gReferenciaCliente)
                    .SubItems.Add(dts.gCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gFechaEntrega)
                    .SubItems.Add(dts.gEstado)
                    Select Case DiasPrevistos(dts.gFechaEntrega)
                        Case Is <= DiasAvisoRojo
                            .ForeColor = Color.Red
                        Case Is <= DiasAvisoNaranja
                            .ForeColor = Color.DarkOrange
                        Case Else
                            .ForeColor = Color.Black
                    End Select

                End With
            Next

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Function DiasPrevistos(ByVal Fecha As Date) As Integer
        'Devuelve los dias laborables previstos desde hoy a la fecha prevista
        Dim dia As Date = Now.Date
        Dim contador As Integer = 0
        Do While dia < Fecha
            If funcFE.EsFestivo(dia) Then
            Else
                contador = contador + 1
            End If
            dia = dia.AddDays(1)
        Loop
        If contador = 0 Then
            dia = Now.Date
            Do While dia > Fecha
                If funcFE.EsFestivo(dia) Then
                Else
                    contador = contador - 1
                End If
                dia = dia.AddDays(-1)
            Loop
        End If
        Return contador
    End Function

    Private Sub lvPedidosFechaPrevista_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPedidosFechaPrevista.DoubleClick
        'Si hacemos doble click, se abre el formulario de gestión de pedidos con el pedido correspondiente
        If lvPedidosFechaPrevista.SelectedItems.Count > 0 Then
            Dim GG As New GestionPedido
            GG.pnumPedido = lvPedidosFechaPrevista.SelectedItems(0).Text
            GG.SoloLectura = vSoloLectura
            GG.ShowDialog()
            Call CargarPedidosFechaPrevista()
        End If
    End Sub

    Private Sub lvPedidosFechaPrevista_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPedidosFechaPrevista.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorterFP.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorterFP.Order = SortOrder.Ascending) Then
                lvwColumnSorterFP.Order = SortOrder.Descending
            Else
                lvwColumnSorterFP.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorterFP.SortColumn = e.Column

            lvwColumnSorterFP.Order = SortOrder.Ascending
        End If
        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvPedidosFechaPrevista.Sort()
    End Sub

    Protected Sub OnClicksubMenu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvPedidosFechaPrevista.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvPedidosFechaPrevista.SelectedIndices(0)
            Select Case sender.text
                Case "Ver detalles de Producción"
                    Dim GG As New subPonerEnPruebas
                    GG.SoloLectura = True
                    GG.pnumPedido = lvPedidosFechaPrevista.Items(indice).SubItems(0).Text
                    GG.ShowDialog()
            End Select
        End If
    End Sub

#End Region

#Region "COMUNICACIONES"

    Public Sub CargarComunicaciones()
        lvComunicaciones.Items.Clear()
        lvwColumnSorterC = New OrdenarLV()
        lvComunicaciones.ListViewItemSorter = lvwColumnSorterC
        Dim lista As List(Of datosComunicacion) = funcCO.Busqueda(" Estados.Traspasado = 0 AND CO.idDestinatario = " & vidUsuario, "")
        For Each dts As datosComunicacion In lista
            With lvComunicaciones.Items.Add("")
                .SubItems.Add(dts.gidComunicacion)
                .SubItems.Add(Format(dts.gFechaHora, "dd/MM/yyyy HH:mm"))
                .SubItems.Add(If(dts.gidCliente = 0, dts.gProveedor, dts.gCliente))
                .SubItems.Add(dts.gContacto)
                .SubItems.Add(dts.gComentario)
                dtsF = funcFI.mostrar(dts.gidComunicacion).FirstOrDefault
                If dtsF Is Nothing Then dtsF = New datosFichero
                dtsR = funcRE.mostrar(dts.gidComunicacion).FirstOrDefault
                If dtsR Is Nothing Then dtsR = New datosReferencia
                If (Not dtsF Is Nothing AndAlso dtsF.gidFichero > 0) Or (Not dtsR Is Nothing AndAlso dtsR.gidReferencia > 0) Then
                    .ImageIndex = 0
                Else
                    .ImageIndex = -1
                End If
                If dts.gDestacado Then
                    .ForeColor = Color.Red
                Else
                    .ForeColor = SystemColors.WindowText
                End If
                Select Case dts.gidEstado
                    Case EstadoArchivado.gidEstado
                        .ForeColor = Color.Gray
                    Case EstadoRespondido.gidEstado
                        .ForeColor = Color.Orange
                End Select
            End With
        Next

    End Sub

    Private Sub lvComunicaciones_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvComunicaciones.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorterC.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 

            If (lvwColumnSorterC.Order = SortOrder.Ascending) Then

                lvwColumnSorterC.Order = SortOrder.Descending

            Else

                lvwColumnSorterC.Order = SortOrder.Ascending

            End If

        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 

            lvwColumnSorterC.SortColumn = e.Column

            lvwColumnSorterC.Order = SortOrder.Ascending

        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvComunicaciones.Sort()

    End Sub

    Private Sub lvComunicaciones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvComunicaciones.DoubleClick

        'Si hacemos doble click, se abre el formulario de gestión de Albaranes con el Albaran correspondiente
        If lvComunicaciones.SelectedItems.Count > 0 Then

            Dim GG As New GestionMensaje

            GG.pidComunicacion = lvComunicaciones.SelectedItems(0).SubItems(1).Text

            GG.SoloLectura = vSoloLectura

            GG.ShowDialog()

            Call CargarComunicaciones()

        End If
    End Sub

    Private Sub CargarIconos()

        Dim listaIconos As New ImageList

        listaIconos.Images.Add(My.Resources.Resources.AttachmentHS)

        lvComunicaciones.SmallImageList = listaIconos

    End Sub

#End Region

End Class