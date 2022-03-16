Imports System.IO

Public Class GestionAlbaranDeProv

#Region "VARIABLES"

    Private cambios As Boolean = False
    Private iidconcepto As Integer
    Private lvIndice As Integer
    Private vCantidad As Double
    Private vPrecio As Double
    Private Semaforo As Boolean
    Private iidProveedor As Integer
    Private vfecha As Date
    'Private vRecibido As String
    Private vidUsuario As Integer
    Private TipoMP As Boolean
    'Private ValidaPed As Boolean
    Private vEstado As String
    'Private bRequiereValidar As Boolean
    Private esNuevo As Boolean
    Private EnvioCorreo As Boolean = False
    Private funcP As New funcionesProveedores
    Private funcALP As New FuncionesAlbaranesProv
    Private funcCAP As New FuncionesConceptosAlbaranesProv
    Private funcMO As New FuncionesMoneda
    Private funcUM As New FuncionesTiposUnidad
    Private funcUB As New funcionesUbicaciones
    Private funcTC As New FuncionesTipoCompra
    Private funcAR As New FuncionesArticulos
    Private funcAP As New FuncionesArticulosProv
    Private funcAE As New FuncionesArticuloPrecio
    Private funcFA As New FuncionesFamilias
    Private funcSF As New FuncionessubFamilias
    Private funcTI As New FuncionesTiposIVA
    Private funcFF As New funcionesFacturacion
    Private funcPE As New FuncionesPersonal
    Private funcMOA As New FuncionesMails
    Private funcCT As New funcionesContactos
    Private funcES As New FuncionesEstados
    Private funcST As New FuncionesStock
    Private funcCP As New FuncionesConceptosPedidosProv
    Private funcPP As New FuncionesPedidosProv
    Private DI As New DatosIniciales
    Private dtsPR As datosProveedor
    Private dtsALP As DatosAlbaranProv
    Private dtsUB As datosUbicacion
    Private dtsFA As datosfacturacion
    Private iidArticulo As Integer
    Private iidArticuloProv As Integer
    Private iidUbicacion As Integer
    Private iidTipoCompra As Integer
    Private G_AGeneral As Char
    Private iidFamilia As Integer
    Private iidsubFamilia As Integer
    Private vMoneda As String
    Private CambioMoneda As Boolean  'Nos dice si ha habido un cambio de moneda y por tanto hay que guardar los conceptos
    Private AvisoCambio As Boolean  'Nos dice si ya se ha avisado de un cambio
    Private EnvioCorreoVal As Boolean = False  'Indica que se ha de enviar un mail informando que se ha validado un pedido
    Private EstadoOriginal As String ' El estado que tenía un pedido al abrirlo
    Private iidPersona As Integer  'Persona que dió de alta o modificó por última vez el pedido
    Private Recibido As Boolean
    Private CantidadRecibida As Double
    Private vSoloLectura As Boolean
    Private Albaranes As List(Of Integer)
    'Dim Transporte.text As Double
    Private indiceL As Integer
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private ep3 As New ErrorProvider
    Private estadoCabecera As DatosEstado
    Private estadoRecibido As DatosEstado
    Private estadoRecibidoParcial As DatosEstado
    Private estadoRechazado As DatosEstado
    Private estadoFacturado As DatosEstado
    Private estadoCRecibido As DatosEstado
    Private estadoCRechazado As DatosEstado
    Private estadoCRTraspasado As DatosEstado
    Private estadoCPEspera As DatosEstado
    Private estadoCPRecibido As DatosEstado
    Private estadoCPRecibidoParcial As DatosEstado
    Private estadoPEStock As DatosEstado
    Private estadoPEStockParcial As DatosEstado
    Private estadoCP
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private AvisadoProveedor As Boolean
    Private ProveedorSoloLectura As Boolean
    Private ConceptosEditables As Boolean
    Public iidAlbaran As Integer
    Private inumPedido As Integer
    Private ListaConceptos As List(Of DatosConceptoAlbaranProv)
    Private AvisoNuevoAlbaran As Boolean
    Private LineasDesplazamiento As Integer = 0
    Public sconceptos As String = ""

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

    Property pidAlbaran() As Integer
        Get
            Return iidAlbaran
        End Get
        Set(ByVal value As Integer)
            iidAlbaran = value
        End Set
    End Property

    Property pAlbaranes() As List(Of Integer)
        Get
            Return Albaranes
        End Get
        Set(ByVal value As List(Of Integer))
            Albaranes = value
        End Set
    End Property

    Property pindice() As Integer
        Get
            Return indiceL
        End Get
        Set(ByVal value As Integer)
            indiceL = value
        End Set
    End Property

    Property pnumPedido() As Integer
        Get
            Return inumPedido
        End Get
        Set(ByVal value As Integer)
            inumPedido = value
        End Set
    End Property

#End Region

#Region "CARGA Y CIERRE"

    Private Sub GestionAlbaranDeProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Si le hemos pasado por Property que es sólo lectura, tiene prioridad, sino lo mira según el usuario
        Try

            Semaforo = False
            Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
            If desktopSize.Height < 950 Then
                Me.Height = desktopSize.Height - 50
            Else
                Me.Height = 900
            End If
            AvisadoProveedor = False
            vidUsuario = Inicio.vIdUsuario
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.Icon = My.Resources.Resources.info
            ep3.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep3.Icon = My.Resources.eventlogWarn

            'ValidaPed = funcPE.campoValidaPedidosProv(vidUsuario)
            bGuardar.Enabled = Not vSoloLectura
            bBorrar.Enabled = Not vSoloLectura
            Call inicializar()
            'Call inicializaConcepto()
            ProveedorSoloLectura = False
            ConceptosEditables = True
            If inumPedido = 0 Then
                If iidAlbaran = 0 Then
                    Call Nuevo()
                    bSubir.Visible = False
                    bBajar.Visible = False
                Else
                    gbConceptos.Enabled = True
                    If Albaranes Is Nothing Then
                        bSubir.Visible = False
                        bBajar.Visible = False
                    Else
                        If Albaranes.Count > 0 Then
                            bSubir.Visible = True
                            bBajar.Visible = True
                        Else
                            bSubir.Visible = False
                            bBajar.Visible = False
                        End If
                    End If
                    Call CargarAlbaran()
                    G_AGeneral = "A"
                End If
                AvisoNuevoAlbaran = False
            Else
                bSubirC.Enabled = False
                bBajarC.Enabled = False
                'Modo Recepción
                If iidAlbaran = 0 Then
                    Call CargarPropuestaAlbaran()
                    AvisoNuevoAlbaran = True
                Else
                    Call CargarAlbaran()
                    Me.Text = "AÑADIR RECEPCIÓN DE PEDIDO DE PROVEEDOR " & inumPedido

                    AvisoNuevoAlbaran = False
                End If
                Call CargarListaConceptosPropuesta()
                Call CargarConceptosPropuesta()
            End If

            EstadoOriginal = cbEstado.Text
            Semaforo = True
        Catch ex As Exception
            ex.Data.Add("inumPedido", inumPedido)
            CorreoError(ex)
        End Try

    End Sub

    Private Sub GestionAlbaranProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not e.Cancel Then
            If AvisoNuevoAlbaran Then
                Select Case MsgBox("No se ha generado el albarán. ¿Desea generarlo?", MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Call GuardarRecepcion()
                        e.Cancel = True
                    Case MsgBoxResult.No
                        e.Cancel = False
                    Case Else
                        e.Cancel = True
                End Select

            ElseIf VerificarQuedanLineasPropuestas() Then
                Select Case MsgBox("No se han añadido las lineas propuestas al albarán. ¿Desea añadirlas?", MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        GuardarConceptosLista()
                        bSubirC.Enabled = True
                        bBajarC.Enabled = True
                        e.Cancel = True
                    Case MsgBoxResult.No
                        e.Cancel = False
                    Case Else
                        e.Cancel = True
                End Select

            ElseIf cambios Then
                If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            Else
                e.Cancel = False
            End If

        End If

    End Sub

#End Region

#Region "INICIALIZACIÓN"

    Public Sub inicializar()
        Try
            Call introducirProveedores()
            Call introducirSolicitadoVia()
            Call introducirTiposIVA()
            'Call introducirUnidades()
            Call introducirFamilias()
            Call CargarResponsables()
            Call introducirTransporte()
            Call introducirTiposValorado()
            Call introducirMonedas()
            Call CargarEstados()

            Dim tt As New ToolTip
            tt.SetToolTip(BBuscarArticulo, "Búsqueda de Producto")
            tt.SetToolTip(bBuscarProveedor, "Búsqueda de Proveedor")
            tt.SetToolTip(bLimpiar, "Limpiar zona de edición")
            tt.SetToolTip(bArticuloProveedor, "Gestión Artículo-Proveedor")
            tt.SetToolTip(bVerArticulo, "Ver ficha del artículo")
            tt.SetToolTip(BBuscarArticulo, "Búsqueda del artículo")
            tt.SetToolTip(bMoneda, "Abrir Gestión de monedas")

            With lvConceptos
                .View = View.Details
                .FullRowSelect = True
                .GridLines = True
                .MultiSelect = False
                .HideSelection = False
            End With

            cambios = False

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub CargarEstados()
        'Estado AlbaranProv
        estadoCabecera = funcES.EstadoAlbaranProv("CABECERA")
        estadoRecibido = funcES.EstadoAlbaranProv("RECIBIDO")
        estadoRechazado = funcES.EstadoAlbaranProv("RECHAZADO")
        estadoFacturado = funcES.EstadoAlbaranProv("FACTURADO")
        estadoRecibidoParcial = funcES.EstadoAlbaranProv("RECIBIDO PARCIAL")
        'Estados conceptos albaran prov
        estadoCRecibido = funcES.EstadoEntregado("C.ALBARANPROV")
        estadoCRechazado = funcES.EstadoAutomatico("C.ALBARANPROV")
        estadoCRTraspasado = funcES.EstadoTraspasado("C.ALBARANPROV")

        'Estados Conceptos Pedido PRov

        estadoCPEspera = funcES.EstadoCPedidoProv("ESPERA")
        estadoCPRecibido = funcES.EstadoCPedidoProv("RECIBIDO")
        estadoCPRecibidoParcial = funcES.EstadoCPedidoProv("RECIBIDO PARCIAL")

        'Estados Pedido Prov
        estadoPEStock = funcES.EstadoPedidoProv("STOCK")
        estadoPEStockParcial = funcES.EstadoPedidoProv("STOCK PARCIAL")
    End Sub

    Private Sub InicializarGeneral()
        ep1.Clear()
        ep2.Clear()
        ckSeleccion.Checked = False
        ckSeleccion.Visible = True
        lvConceptos.Items.Clear()
        lvConceptos.CheckBoxes = True

        Call CargarResponsables()
        Call LimpiarCabecera()
        Nota.Text = ""
        Observaciones.Text = ""

        BaseImponible.Text = 0
        TotalIVA.Text = 0
        TotalRE.Text = 0
        Retencion.Text = 0
        Total.Text = 0
        Bultos.Text = 0
        Call LimpiarEdicion()
        cambios = False
    End Sub

    Private Sub LimpiarCabecera()
        numAlbaran.Text = ""
        Referencia.Text = ""
        numDoc1.Text = ""
        numDoc2.Text = ""
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        cbCodProveedor.Text = ""
        cbCodProveedor.SelectedIndex = -1
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1

        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbDireccion.Items.Clear()

        dtpFecha.Value = Now.Date

        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbsolicitadoVia.Text = ""
        cbsolicitadoVia.SelectedIndex = -1

        cbMoneda.Text = funcMO.CampoDivisa("EU")
        codMonedaI = "EU"
        'cbTipoIVA.Text = DI.TipoIVA.ToString

        cbPortes.Text = ""
        PrecioTransporte.Text = 0
        PrecioTransporte.Enabled = False
        Observaciones.Text = ""
        Nota.Text = ""
    End Sub

    Private Sub LimpiarEdicion()
        cbcodArticulo.Text = ""
        cbcodArticuloProv.Text = ""
        Cantidad.Text = 0
        cbArticulo.Text = ""
        Precio.Text = 0
        totalConcepto.Text = 0
        iidconcepto = 0
        lvIndice = -1
        vCantidad = 0
        vPrecio = 0
        iidArticulo = 0
        Recibido = False
        CantidadRecibida = 0
        lbUnidad.Text = "U."
        iidFamilia = 0
        iidsubFamilia = 0
        cbFamilia.Text = ""
        cbFamilia.SelectedIndex = -1
        cbSubFamilia.Items.Clear()
        cbSubFamilia.Text = ""
        cbSubFamilia.SelectedIndex = -1
        cbcodArticulo.Items.Clear()
        cbcodArticulo.SelectedIndex = -1
        cbcodArticuloProv.Items.Clear()
        cbcodArticuloProv.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.SelectedIndex = -1
        DescuentoC.Text = 0
        If cbProveedor.SelectedIndex = -1 Then
            cbTipoIVA.Text = DI.TipoIVA.ToString
        Else
            If dtsFA Is Nothing Then dtsFA = funcFF.mostrarProv(dtsPR.gidProveedor)
            cbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
        End If
        ObservacionesC.Text = ""
        ckRechazado.Checked = False
    End Sub

    Private Sub introducirMonedas()
        Try
            cbMoneda.Items.Clear()
            Dim lista As List(Of DatosMoneda) = funcMO.Mostrar()
            For Each dts As DatosMoneda In lista
                cbMoneda.Items.Add(dts)
            Next
            cbMoneda.Text = funcMO.CampoDivisa("EU")
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirTransporte()
        Try
            cbTransporte.Items.Clear()
            cbTransporte.Items.Add(New IDComboBox("SUS MEDIOS", -1))
            cbTransporte.Items.Add(New IDComboBox("NUESTROS MEDIOS", -2))
            Dim lista As List(Of IDComboBox) = funcP.Transportes
            For Each t As IDComboBox In lista
                cbTransporte.Items.Add(t)
            Next
            cbPortes.Items.Clear()
            cbPortes.Items.Add("DEBIDOS")
            cbPortes.Items.Add("INC.FRA.")
            cbPortes.Items.Add("PAGADOS")
            cbPortes.Text = ""
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirTiposValorado()
        Try
            cbValorado.Items.Clear()
            Dim funcVA As New FuncionesTiposValorado
            Dim lista As List(Of DatosTipoValorado) = funcVA.Mostrar()
            Dim dts As DatosTipoValorado
            For Each dts In lista
                cbValorado.Items.Add(dts)
            Next
            cbValorado.Text = "NO VALORADO"
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub inicializaConcepto()
        Dim semaforo0 As Boolean = Semaforo
        Semaforo = False
        Call LimpiarEdicion()
        Call IntroducirArticulos()
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
        Semaforo = semaforo0
    End Sub

    Private Sub IntroducirArticulos()
        cbcodArticulo.Items.Clear()
        cbcodArticulo.Text = ""
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbcodArticuloProv.Items.Clear()
        cbcodArticuloProv.Text = ""
        iidArticulo = 0

        Dim lista As List(Of DatosArticuloProveedor) = funcAP.Mostrar(iidProveedor, 0, iidFamilia, iidsubFamilia, "Articulo", True)
        Dim dts As DatosArticuloProveedor
        For Each dts In lista
            If dts.gcodArticulo <> "" Then cbcodArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticulo, dts.gidArticuloProv))
            If dts.gNombre <> "" Then cbArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gNombre, dts.gidArticuloProv))
            If dts.gcodArticuloProv <> "" Then cbcodArticuloProv.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticuloProv, dts.gidArticuloProv))
        Next

    End Sub

    Private Sub introducirTiposIVA()
        Try
            cbTipoIVA.Items.Clear()
            Dim lista As List(Of DatosTipoIVA) = funcTI.Mostrar(True)
            Dim dts As DatosTipoIVA
            For Each dts In lista
                cbTipoIVA.Items.Add(dts)
            Next
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()
            cbProveedor.Text = ""

            Dim lista As List(Of datosProveedor) = funcP.mostrar(True)
            Dim dts As datosProveedor
            For Each dts In lista
                cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
            Next

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirFamilias()
        Try
            cbFamilia.Items.Clear()
            iidFamilia = 0
            Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
            Dim dts As DatosFamilia
            For Each dts In lista
                cbFamilia.Items.Add(New IDComboBox(dts.gFamilia, dts.gidFamilia))
            Next
            iidFamilia = 0
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirSubFamilias()
        Try
            cbSubFamilia.Items.Clear()
            cbSubFamilia.Text = ""
            iidsubFamilia = 0
            If iidFamilia > 0 Then
                Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, True)
                Dim dts As DatosSubFamilia
                For Each dts In lista
                    cbSubFamilia.Items.Add(New IDComboBox(dts.gSubFamilia, dts.gidSubFamilia))
                Next
                iidsubFamilia = 0
            End If
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirSolicitadoVia()
        Dim funcSV As New FuncionesSolicitadoVia
        cbsolicitadoVia.Items.Clear()
        Dim lista As List(Of DatosSolicitadoVia) = funcSV.Mostrar
        For Each dts As DatosSolicitadoVia In lista
            cbsolicitadoVia.Items.Add(dts)
        Next
    End Sub

    Private Sub CargarResponsables()
        Try
            cbSolicitadoPor.Items.Clear()
            Dim lista As List(Of IDComboBox) = funcPE.Listar
            For Each item As IDComboBox In lista
                cbSolicitadoPor.Items.Add(item)
            Next
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarPropuestaAlbaran()
        Me.Text = "RECEPCIÓN DE PEDIDO DE PROVEEDOR " & inumPedido

        If numAlbaran.Text = "" Then
            ep3.SetError(numAlbaran, "Se ha de indicar el número de albarán")
        End If
        Dim dts As DatosPedidoProv = funcPP.Mostrar1(inumPedido)
        dtsPR = funcP.mostrar1(dts.gidProveedor)
        dtsFA = funcFF.mostrarProv(dts.gidProveedor)
        Call ClonarCabeceras(dts)

        Call CargarDatosAlbaran()
        cbEstado.Items.Clear()
        cbEstado.Items.Add(New DatosEstado("PROPUESTA", "", False))
        cbEstado.Text = "PROPUESTA"
        G_AGeneral = "G"
    End Sub

    Private Sub CargarListaConceptosPropuesta()
        Dim lista As List(Of DatosConceptoPedidoProv) = funcCP.mostrar(inumPedido, sconceptos)
        Dim orden As Integer = 1
        ListaConceptos = New List(Of DatosConceptoAlbaranProv)
        For Each dtsCP As DatosConceptoPedidoProv In lista
            If Math.Abs(dtsCP.gCantidad - dtsCP.gCantidadRecibida) > 0 Then
                Call CargarConceptoRecibidoDelPedido(dtsCP, orden)
                orden = orden + 1
            End If
        Next
        Call Recalcular()
    End Sub

    Private Sub ClonarCabeceras(ByVal dts As DatosPedidoProv)
        dtsALP = New DatosAlbaranProv
        dtsALP.gAgenciaTransporte = dts.gAgenciaTransporte
        dtsALP.gBase = 0
        dtsALP.gBultos = 1
        dtsALP.gcodMoneda = dts.gcodMoneda
        dtsALP.gContacto = dts.gContacto
        dtsALP.gDireccion = dts.gDireccion
        dtsALP.gDivisa = dts.gDivisa
        dtsALP.gEstado = estadoCabecera.gEstado
        dtsALP.gFacturas = New List(Of IDComboBox)
        dtsALP.gFecha = Now.Date
        dtsALP.gidAlbaran = 0
        dtsALP.gidContacto = dts.gidContacto
        dtsALP.gidEstado = estadoCabecera.gidEstado
        dtsALP.gidFactura = 0
        dtsALP.gidPersona = Inicio.vIdUsuario
        dtsALP.gidProveedor = dts.gidProveedor
        dtsALP.gidTipoRetencion = dts.gidTipoRetencion
        dtsALP.gidTipoValorado = dts.gidTipoValorado
        dtsALP.gidTransporte = dts.gidTransporte
        dtsALP.gidUbicacion = dts.gidUbicacion
        dtsALP.gImportePP = 0
        dtsALP.gNotas = dts.gNotas
        dtsALP.gnumAlbaran = ""
        dtsALP.gnumSPedido = New List(Of Integer)
        dtsALP.gnumSPedido.Add(inumPedido)
        dtsALP.gObservaciones = dts.gObservaciones
        dtsALP.gObservacionesProv = dts.gObservacionesProv
        dtsALP.gPersona = funcPE.campoNombreyApellidos(Inicio.vIdUsuario)
        dtsALP.gPortes = dts.gPortes
        dtsALP.gPrecioTransporte = dts.gPrecioTransporte
        dtsALP.gProntoPago = dtsFA.gProntoPago
        dtsALP.gProveedor = dts.gProveedor
        dtsALP.gRecargoEquivalencia = False
        dtsALP.gReferencia = dts.gPedidoProveedor
        dtsALP.gRetencion = 0
        dtsALP.gSimbolo = dts.gSimbolo
        dtsALP.gSolicitadoVia = dts.gSolicitadoVia
        dtsALP.gTipoRetencion = dts.gTipoRetencion
        dtsALP.gTipoValorado = dts.gTipoValorado
        dtsALP.gTotal = 0
        dtsALP.gTotalIVA = 0
        dtsALP.gTotalRE = 0
        dtsALP.gTransporte = dts.gTransporte
    End Sub

    Private Sub CargarConceptoRecibidoDelPedido(ByVal dts As DatosConceptoPedidoProv, ByVal Orden As Integer)
        Dim dtsCA As New DatosConceptoAlbaranProv
        dtsCA.gArticulo = dts.gArticulo
        dtsCA.gArticuloProv = dts.gArticuloProv
        dtsCA.gCantidad = dts.gCantidad
        If dts.gCantidadRecibida = 0 Then
            dtsCA.gCantidad = dts.gCantidad
        Else
            If dts.gCantidadRecibida < dts.gCantidad Then
                dtsCA.gCantidad = dts.gCantidad - dts.gCantidadRecibida
            Else
                'Si se ha recibido todo o más, ponemos 0
                dtsCA.gCantidad = 0
            End If
        End If
        dtsCA.gcodArticulo = dts.gcodArticulo
        dtsCA.gcodArticuloProv = dts.gcodArticuloProv
        dtsCA.gcodMoneda = dts.gcodMoneda
        dtsCA.gDescuento = dts.gDescuento
        dtsCA.gEstado = estadoCRecibido.gEstado
        dtsCA.gFamilia = dts.gFamilia
        dtsCA.gFechaRecibido = Now.Date
        dtsCA.gidAlbaran = dtsALP.gidAlbaran
        dtsCA.gidArticulo = dts.gidArticulo
        dtsCA.gidArticuloProv = dts.gidArticuloProv
        dtsCA.gidConcepto = 0
        dtsCA.gidConceptoPedidoProv = dts.gidConcepto
        dtsCA.gidEstado = estadoCRecibido.gidEstado
        dtsCA.gidFactura = 0
        If dts.gidArticulo > 0 Then
            Dim dtsAR As DatosArticulo = funcAR.Mostrar1(dts.gidArticulo)
            dtsCA.gidFamilia = dtsAR.gidFamilia
            dtsCA.gidSubFamilia = dtsAR.gidSubFamilia
        Else
            dtsCA.gidFamilia = 0
            dtsCA.gSubFamilia = 0
        End If
        dtsCA.gidTipoIVA = dts.gidTipoIVA
        dtsCA.gidUnidad = dts.gidUnidad
        dtsCA.gNombreTipoIVA = dtsFA.gNombreTipoIVA
        dtsCA.gnumAlbaran = dtsALP.gnumAlbaran
        dtsCA.gnumPedido = dts.gnumPedido
        dtsCA.gObservaciones = ""
        dtsCA.gOrden = Orden
        dtsCA.gPrecioNetoUnitario = dts.gPrecioNetoUnitario
        dtsCA.gPVPUnitario = dts.gPVPUnitario
        dtsCA.gSimbolo = dtsALP.gSimbolo
        dtsCA.gSubFamilia = dts.gsubFamilia
        dtsCA.gTipoIVA = dts.gTipoIVA
        dtsCA.gTipoRecargoEq = dtsFA.gTipoRecargoEq
        dtsCA.gTipoUnidad = dts.gTipoUnidad
        dtsCA.gTotalConcepto = dtsCA.gPrecioNetoUnitario * dtsCA.gCantidad * (1 - (dtsCA.gDescuento / 100))
        ListaConceptos.Add(dtsCA)

    End Sub

    Private Sub CargarContactos()
        If cbProveedor.SelectedIndex <> -1 Then
            Dim contacto As String = cbContacto.Text
            cbContacto.Text = ""
            cbContacto.Items.Clear()
            Dim lista As List(Of datosContacto) = funcCT.mostrarProv(cbProveedor.SelectedItem.itemdata)
            For Each dts As datosContacto In lista
                cbContacto.Items.Add(New IDComboBox(dts.gnombre + " " + dts.gapellidos, dts.gidContacto))
            Next
            If contacto <> "" Then cbContacto.Text = contacto
            If cbContacto.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbContacto.SelectedIndex = 0
                Else
                    cbContacto.Text = ""
                End If
            End If

        End If
    End Sub


    Private Sub Nuevo()
        Try
            esNuevo = True
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
            Me.Text = "NUEVO ALBARÁN DE PROVEEDOR"
            codMonedaI = "EU"
            cbProveedor.Text = ""
            cbProveedor.SelectedIndex = -1
            cbCodProveedor.Text = ""
            cbCodProveedor.SelectedIndex = -1
            cbDireccion.Text = ""
            cbDireccion.SelectedIndex = -1
            G_AGeneral = "G"
            gbConceptos.Enabled = False  'Se desactiva la zona de conceptos hasta que se haya guardado una EN CURSO válida

            'Inicializar valores
            dtpFecha.Value = Date.Today

            vfecha = dtpFecha.Value
            'observacionesProv.Text = ""
            Observaciones.Text = ""
            Referencia.Text = ""
            Nota.Text = ""

            cbTransporte.Text = ""
            cbTransporte.SelectedIndex = -1
            If DI.Portes = "P" Then cbPortes.Text = "PAGADOS"
            If DI.Portes = "D" Then cbPortes.Text = "DEBIDOS"
            If DI.Portes = "I" Then cbPortes.Text = "INC.FRA."
            'If DI.Portes = "P" Then
            '    cbPortes.Text = "PAGADOS"
            'Else
            '    cbPortes.Text = "DEBIDOS"
            'End If
            cbValorado.Text = "NO VALORADO"
            vMoneda = "EU"
            vEstado = cbEstado.Text
            EstadoOriginal = vEstado
            cbsolicitadoVia.Text = ""

            cbSolicitadoPor.Text = funcPE.campoNombreyApellidos(vidUsuario)
            lvConceptos.Items.Clear()
            iidPersona = vidUsuario
            'Cargar datos de Master
            'Dim funcMOA As New Master()
            'numAlbaran.Text = funcMOA.leernumPedidoProv(dtpFecha.Value.Year) + 1  'Este número puede no ser el definitivo, se cargará de forma efectiva desde la función correspondiente de funcionesFraProveedor
            'If numAlbaran.Text = 0 Then
            '    funcMOA.NuevoAño()
            '    numAlbaran.Text = funcMOA.leernumPedido(Now.Year) + 1
            '    If numAlbaran.Text = 0 Then
            '        MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
            '        Me.Close()
            '    End If
            'End If

            cbEstado.Items.Clear()
            cbEstado.Items.Add(funcES.EstadoAlbaranProv("CABECERA"))
            cbEstado.SelectedIndex = 0

            dtsALP = New DatosAlbaranProv
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub



    Private Sub CargarAlbaran()
        Try
            ep1.Clear()
            ep2.Clear()

            esNuevo = False
            G_AGeneral = "A"
            Dim Semaforo0 As Boolean = Semaforo
            dtsALP = funcALP.Mostrar1(iidAlbaran)
            If dtsALP.gidPersona = 0 Then
                dtsALP.gidPersona = Inicio.vIdUsuario
                dtsALP.gPersona = funcPE.campoNombreyApellidos(Inicio.vIdUsuario)
            End If
            iidProveedor = dtsALP.gidProveedor
            dtsPR = funcP.mostrar1(iidProveedor)
            Me.Text = "EDITAR ALBARÁN DE PROVEEDOR" & " " & dtsPR.gTipoCompra
            Call CargarDatosAlbaran()
            'ListaConceptos = funcCAP.mostrar(iidAlbaran)
            LineasDesplazamiento = CargarConceptosExistentes()
            ckSeleccion.Checked = False

        Catch ex As Exception
            CorreoError(ex)
        End Try

    End Sub

    Private Sub CargarDatosAlbaran()

        numAlbaran.Text = dtsALP.gnumAlbaran
        Dim tt As New ToolTip
        tt.SetToolTip(numAlbaran, dtsALP.gnumAlbaran)

        Dim dtsES As DatosEstado = funcES.Mostrar1(dtsALP.gidEstado)

        If dtsES.gBloqueado Then
            cbProveedor.Items.Clear()
            cbCodProveedor.Items.Clear()
            cbCodProveedor.Items.Add(New IDComboBox(dtsPR.gcodProveedor, dtsPR.gidProveedor))
            cbProveedor.Items.Add(New IDComboBox(dtsPR.gnombrecomercial, dtsPR.gidProveedor))
            ProveedorSoloLectura = True
            bBuscarProveedor.Enabled = False
        Else
            Call introducirProveedores()
            ProveedorSoloLectura = False
            bBuscarProveedor.Enabled = True
        End If

        codMonedaI = dtsALP.gcodMoneda
        vfecha = dtsALP.gFecha.Date
        Referencia.Text = dtsALP.gReferencia
        tt = New ToolTip
        tt.SetToolTip(Referencia, dtsALP.gReferencia)
        dtpFecha.Value = dtsALP.gFecha

        cbSolicitadoPor.Text = dtsALP.gPersona
        cbContacto.Text = dtsALP.gContacto
        cbsolicitadoVia.Text = dtsALP.gSolicitadoVia

        cbProveedor.Text = dtsALP.gProveedor
        cbCodProveedor.Text = dtsPR.gcodProveedor
        iidUbicacion = dtsALP.gidUbicacion
        Call CargarDirecciones()
        cbDireccion.Text = dtsALP.gDireccion
        If cbDireccion.SelectedIndex = -1 Then
            ep2.SetError(cbDireccion, "Dirección no válida")
        Else
            dtsUB = funcUB.mostrar1(dtsALP.gidUbicacion)
        End If
        Bultos.Text = dtsALP.gBultos
        vEstado = dtsALP.gEstado
        cbEstado.Items.Clear()
        cbEstado.Items.Add(dtsES)
        cbEstado.Text = dtsALP.gEstado

        BaseImponible.Text = FormatNumber(dtsALP.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsALP.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsALP.gTotalRE, 2)
        Total.Text = FormatNumber(dtsALP.gTotal, 2)
        Retencion.Text = FormatNumber(dtsALP.gRetencion, 2)
        Observaciones.Text = dtsALP.gObservaciones
        Nota.Text = dtsALP.gNotas

        vMoneda = dtsALP.gcodMoneda
        cbMoneda.Text = dtsALP.gDivisa
        cbValorado.Text = dtsALP.gTipoValorado
        Descuento.Text = FormatNumber(dtsALP.gProntoPago, 2)
        PrecioTransporte.Text = FormatNumber(dtsALP.gPrecioTransporte, 2)
        If dtsALP.gPortes = "P" Then
            cbPortes.Text = "PAGADOS"
            PrecioTransporte.Text = 0
        End If
        If dtsALP.gPortes = "D" Then
            cbPortes.Text = "DEBIDOS"
            PrecioTransporte.Text = 0
        End If
        If dtsALP.gPortes = "I" Then
            cbPortes.Text = "INC.FRA."
            PrecioTransporte.Text = FormatNumber(dtsALP.gPrecioTransporte, 2)
        End If
        If dtsALP.gidTransporte > 0 Then
            cbTransporte.Text = dtsALP.gAgenciaTransporte
        Else
            cbTransporte.Text = dtsALP.gTransporte
        End If

        Select Case dtsALP.gFacturas.Count
            Case 0
                numDoc1.Text = ""
            Case 1
                numDoc1.Text = dtsALP.gFacturas(0).ToString
            Case Else
                numDoc1.Text = "VARIOS"
        End Select

        tt.SetToolTip(numDoc1, numDoc1.Text)

        Select Case dtsALP.gnumSPedido.Count
            Case 0
                numDoc2.Text = ""
            Case 1
                numDoc2.Text = dtsALP.gnumSPedido(0)
            Case Else
                numDoc2.Text = "VARIOS"
        End Select
        tt.SetToolTip(numDoc2, numDoc2.Text)

        cbcodArticulo.Items.Clear()
        lbUnidad.Text = "U."
        iidPersona = dtsALP.gidPersona
        lbMoneda1.Text = dtsALP.gSimbolo
        lbMoneda2.Text = lbMoneda1.Text
        lbMoneda3.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text
        lbMoneda4.Text = lbMoneda1.Text
        lbMoneda5.Text = lbMoneda1.Text
        lbMoneda6.Text = lbMoneda1.Text
        lbMoneda7.Text = lbMoneda1.Text
        Call IntroducirArticulos()

        cambios = False

    End Sub

    Function CargarConceptosExistentes() As Integer
        lvConceptos.Items.Clear()
        funcCAP.RenumerarSiEsNecesario(iidAlbaran)
        Return CargarDatosConceptos(funcCAP.mostrar(iidAlbaran))
    End Function

    Function CargarConceptosPropuesta() As Integer
        Return CargarDatosConceptos(ListaConceptos)
    End Function

    Function CargarDatosConceptos(ByVal lista As List(Of DatosConceptoAlbaranProv)) As Integer
        Dim contador As Integer = 0
        Try
            Semaforo = False
            Dim dts As DatosConceptoAlbaranProv
            For Each dts In lista
                lvConceptosNuevaLinea(dts)
                Semaforo = False
                lvConceptos.Refresh()
                contador = contador + 1
            Next
            Call inicializaConcepto()
            If lista.Count > 0 Then lvConceptos.CheckBoxes = True
            Semaforo = True

            Return contador

        Catch ex As Exception
            CorreoError(ex)
            Return Nothing
        End Try

    End Function




#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub actualizaPrecioTotal()
        ' Recalcula el precio total
        Dim vTotal As Double

        vTotal = vCantidad * vPrecio

        totalConcepto.Text = FormatNumber(vTotal, 2)
    End Sub

    Private Sub lvConceptosNuevaLinea(ByVal dts As DatosConceptoAlbaranProv)
        'Añade una linea al ListView lvConceptos
        With lvConceptos.Items.Add("")
            .SubItems.Add(dts.gidConcepto)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gcodArticuloProv)
            .SubItems.Add(dts.gArticuloProv)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(FormatNumber(dts.gPrecioNetoUnitario, If(dts.gPrecioNetoUnitario >= 5, 4, 6)) & dts.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gDescuento, 2) & "%")
            .SubItems.Add(FormatNumber(dts.gTotalConcepto, 2) & dts.gSimbolo)
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(dts.gidEstado)
            .SubItems.Add(dts.gNombreTipoIVA & " " & dts.gTipoIVA & "%")

            If dts.gidEstado = estadoCRechazado.gidEstado Then .ForeColor = Color.Red
            If dts.gidConcepto = 0 Then
                .BackColor = Color.LightYellow
                lbPropuestos.Visible = True
            End If
        End With


    End Sub



    Private Sub Recalcular()

        funcALP.DatosCalculados(dtsALP) 'Recargamos el dtsOF por referencia
        Dim dRetencion As Double = dtsALP.gRetencion
        Dim dBase As Double = dtsALP.gBase
        Dim dTotalIVA As Double = dtsALP.gTotalIVA
        Dim dTotalRE As Double = dtsALP.gTotalRE
        Dim dTotal As Double = dtsALP.gTotal
        If Descuento.Text = "" Or Descuento.Text = "-" Or Descuento.Text = "." Or Descuento.Text = "," Then Descuento.Text = 0
        If ListaConceptos Is Nothing OrElse ListaConceptos.Count = 0 Then
        Else
            Dim dPP As Double = CDbl(Descuento.Text) / 100
            Dim dsubTotal As Double = 0
            For Each dts As DatosConceptoAlbaranProv In ListaConceptos
                dsubTotal = dts.gCantidad * dts.gPrecioNetoUnitario * (1 - (dts.gDescuento / 100)) * (1 - dPP)
                dBase = dBase + dsubTotal
                dTotalIVA = dTotalIVA + dsubTotal * (dts.gTipoIVA / 100)
                If dtsALP.gRecargoEquivalencia Then
                    dTotalRE = dTotalRE + dsubTotal * (dts.gTipoRecargoEq / 100)
                End If
                dRetencion = dRetencion + dsubTotal * (dtsALP.gTipoRetencion / 100)
            Next
            dTotal = dBase + dTotalIVA + dTotalRE - dRetencion
        End If
        Retencion.Text = FormatNumber(dRetencion, 2)
        BaseImponible.Text = FormatNumber(dBase, 2)
        TotalIVA.Text = FormatNumber(dTotalIVA, 2)
        TotalRE.Text = FormatNumber(dTotalRE, 2)
        Total.Text = FormatNumber(dTotal, 2)

    End Sub


    Private Function cargaConcepto() As DatosConceptoAlbaranProv
        'Carga los datos de la zona de edición en un dts de Concepto

        Dim dts As New DatosConceptoAlbaranProv
        If Cantidad.Text = "" Then Cantidad.Text = 0
        If DescuentoC.Text = "" Then DescuentoC.Text = 0
        dts.gidConcepto = iidconcepto
        dts.gidAlbaran = iidAlbaran
        dts.gnumAlbaran = numAlbaran.Text
        dts.gCantidad = Cantidad.Text
        dts.gDescuento = DescuentoC.Text
        dts.gArticuloProv = cbArticulo.Text
        dts.gidArticuloProv = If(cbArticulo.SelectedIndex = -1, 0, cbArticulo.SelectedItem.itemdata)
        dts.gidArticulo = iidArticulo
        dts.gcodArticulo = cbcodArticulo.Text
        dts.gcodArticuloProv = cbcodArticuloProv.Text
        dts.gObservaciones = ObservacionesC.Text
        If ckRechazado.Checked Then
            dts.gidEstado = estadoCRechazado.gidEstado
        Else
            dts.gidEstado = estadoCRecibido.gidEstado
        End If
        If Precio.Text = "" Or Precio.Text = "-" Or Precio.Text = "," Or Precio.Text = "." Then Precio.Text = 0
        dts.gPrecioNetoUnitario = Precio.Text
        dts.gTotalConcepto = totalConcepto.Text
        dts.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
        dts.gTipoIVA = cbTipoIVA.SelectedItem.gtipoIVA
        dts.gNombreTipoIVA = cbTipoIVA.SelectedItem.gNombre
        dts.gFechaRecibido = dtpFecha.Value.Date
        dts.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
        dts.gSimbolo = dtsALP.gSimbolo
        If iidArticulo = 0 Then
            dts.gTipoUnidad = lbUnidad.Text
        Else
            dts.gTipoUnidad = funcAR.TipoUnidad(iidArticulo)
        End If
        If iidconcepto = 0 Then
            If lvIndice <> -1 Then
                dts.gidConceptoPedidoProv = ListaConceptos(lvIndice - LineasDesplazamiento).gidConceptoPedidoProv
            End If
        Else
            dts.gidConceptoPedidoProv = funcCAP.idConceptoPedido(iidconcepto)
        End If

        Return dts

    End Function


    Private Sub PreGuardarConcepto()
        If cbArticulo.Text <> "" And Cantidad.Text <> "" Then
            Dim dts As DatosConceptoAlbaranProv = cargaConcepto()
            Dim indice As Integer = lvIndice - LineasDesplazamiento 'Desplazamiento()
            If indice = -1 Then
                ListaConceptos.Add(dts)
                lvConceptosNuevaLinea(dts)
            Else
                ListaConceptos(indice) = dts
                ActualizarLineaLV(dts)
            End If
            Call Recalcular()
            Call LimpiarEdicion()
        End If
    End Sub

    Private Sub GuardarConcepto()
        'Guarda o actualiza los datos de un concepto
        Try
            If cbArticulo.Text <> "" And Cantidad.Text <> "" Then   'solo actua si hay alguna información en la zona de edición
                EnvioCorreo = Not vSoloLectura
                Dim iidConcepto As Integer
                Try
                    Dim dts As DatosConceptoAlbaranProv
                    dts = cargaConcepto()
                    If lvIndice = -1 Then 'Nuevo concepto
                        iidConcepto = funcCAP.insertar(dts)
                        dts.gidConcepto = iidConcepto
                        lvConceptosNuevaLinea(dts)
                        Call ActualizarStock(dts, dts.gCantidad)
                    Else   'Actualizar concepto
                        Dim cantidadAnterior As Double = 0
                        If dts.gidConcepto = 0 Then
                            dts.gidConcepto = funcCAP.insertar(dts)
                        Else
                            cantidadAnterior = funcCAP.Cantidad(dts.gidConcepto)
                            funcCAP.actualizar(dts)
                        End If
                        iidConcepto = dts.gidConcepto
                        Call CambiosEnConceptoPedido(dts.gidConceptoPedidoProv)

                        Call cambiosEnPedido(funcCP.numPedido(dts.gidConceptoPedidoProv))
                        Call ActualizarStock(dts, dts.gCantidad - cantidadAnterior)
                        Call ActualizarLineaLV(dts)
                        ''que pasa si modificamos una linea amarilla no consecutiva????
                        'If VerificarQuedanLineasPropuestas() Then
                        '    ListaConceptos.RemoveAt(lvIndice - LineasDesplazamiento)
                        '    LineasDesplazamiento = Desplazamiento()
                        'ElseIf Not ListaConceptos Is Nothing Then
                        '    ListaConceptos.Clear()
                        'End If
                        'If Not ListaConceptos Is Nothing Then ListaConceptos.Clear()
                    End If
                    Call Recalcular()
                    If iidArticulo > 0 Then
                        'Articulo-Proveedor
                        Dim dtsAP As New DatosArticuloProveedor
                        dtsAP.gActivo = True
                        dtsAP.gidArticuloProv = dts.gidArticuloProv
                        dtsAP.gidArticulo = iidArticulo
                        dtsAP.gidProveedor = iidProveedor
                        dtsAP.gNombre = dts.gArticuloProv
                        dtsAP.gPrecio = dts.gPrecioNetoUnitario
                        dtsAP.gcodMoneda = dtsALP.gcodMoneda
                        dtsAP.gFechaPrecio = dtsALP.gFecha
                        dtsAP.gcodArticuloProv = cbcodArticuloProv.Text
                        dtsAP.gPrecioUnitario = 0

                        If dts.gidArticuloProv = 0 Then
                            dts.gidArticuloProv = funcAP.Guardar(dtsAP)
                        Else
                            funcAP.actualizar(dtsAP)
                        End If

                        If funcAR.idProveedor(iidArticulo) = 0 Then
                            If MsgBox("¿Desea establecer " & cbProveedor.Text & " como proveedor habitual de " & funcAR.Articulo(iidArticulo) & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                funcAR.actualizarProveedor(iidArticulo, iidProveedor)
                            End If
                        End If
                        'Actualizar el precio del artículo
                        'Guardamos los datos que identifican el precio como "Procedente del último pedido"
                        Dim dtsAE As New DatosArticuloPrecio
                        dtsAE.gidArticulo = dts.gidArticulo
                        dtsAE.gFechaPrecio = dtpFecha.Value.Date

                        dtsAE.gcodMoneda = dtsALP.gcodMoneda
                        dtsAE.gidProveedorPrecio = dtsALP.gidProveedor
                        dtsAE.gidConcepto = dts.gidConcepto
                        dtsAE.gPrecio = funcAP.Precio(dts.gidArticuloProv)
                        dtsAE.gTipoPrecio = "C"
                        dtsAE.gActivo = True
                        dtsAE.gDescuento = 0
                        dtsAE.gidClientePrecio = 0
                        funcAE.ActualizarH(dtsAE)
                    End If
                    Call VerificarQuedanLineasPropuestas()
                    Call LimpiarEdicion()
                Catch ex As Exception
                    CorreoError(ex)
                End Try

            End If
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarConcepto")
            ex.Data.Add("numAlbaran.Text", numAlbaran.Text)
            ex.Data.Add("iidConcepto", iidconcepto)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
        End Try
    End Sub

    Private Function VerificarQuedanLineasPropuestas() As Boolean
        Dim AlgunasPropuestas As Boolean = False
        For Each item As ListViewItem In lvConceptos.Items
            If item.BackColor = Color.LightYellow Then
                AlgunasPropuestas = True
            End If
        Next
        If AlgunasPropuestas = False And cbEstado.Text <> "CABECERA" Then
            lbPropuestos.Visible = False
            Me.Text = "EDITAR ALBARÁN DE PROVEEDOR" & " " & dtsPR.gTipoCompra
        End If
        Return AlgunasPropuestas
    End Function


    Private Sub CambiosEnConceptoPedido(ByVal iidconceptoPedidoProv As Long)
        If iidconceptoPedidoProv > 0 Then
            Dim CantidadRecibida As Double = funcCAP.CantidarRecibidaAlb(iidconceptoPedidoProv)
            Dim dts As DatosConceptoPedidoProv = funcCP.mostrar1(iidconceptoPedidoProv)
            If CantidadRecibida > dts.gCantidad Then
                If MsgBox("Se han recibido " & CantidadRecibida & dts.gTipoUnidad & " de " & Microsoft.VisualBasic.Left(dts.gArticulo, 50) & vbCrLf _
                          & "La cantidad pedida es " & dts.gCantidad & dts.gTipoUnidad & vbCrLf _
                          & "¿Desea cambiar la cantidad en el pedido " & dts.gnumPedido & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    funcCP.CambiarCantidad(iidconceptoPedidoProv, CantidadRecibida)
                    dts.gCantidad = CantidadRecibida
                End If
            End If
            If Math.Abs(dts.gCantidadRecibida - CantidadRecibida) > 0.001 Then
                dts.gCantidadRecibida = CantidadRecibida
                If CantidadRecibida = 0 Then
                    dts.gidEstado = estadoCPEspera.gidEstado
                    dts.gRecibido = False
                ElseIf (dts.gCantidad - CantidadRecibida) > 0.001 Then
                    dts.gidEstado = estadoCPRecibidoParcial.gidEstado
                    dts.gFechaRecibido = dtsALP.gFecha
                    dts.gRecibido = False
                Else
                    dts.gidEstado = estadoCPRecibido.gidEstado
                    dts.gFechaRecibido = dtsALP.gFecha
                    dts.gRecibido = True
                End If
                funcCP.actualizarRecepcion(dts)
            End If
        End If
    End Sub



    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoAlbaranProv)
        With lvConceptos.Items(lvIndice)
            .SubItems(1).Text = dts.gidConcepto
            .SubItems(2).Text = dts.gcodArticulo
            .SubItems(3).Text = dts.gcodArticuloProv
            .SubItems(4).Text = dts.gArticuloProv
            .SubItems(5).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
            .SubItems(6).Text = FormatNumber(dts.gPrecioNetoUnitario, If(dts.gPrecioNetoUnitario >= 5, 4, 6)) & dts.gSimbolo
            .SubItems(7).Text = FormatNumber(dts.gDescuento, 2) & "%"
            .SubItems(8).Text = FormatNumber(dts.gTotalConcepto, 2) & dts.gSimbolo
            .SubItems(9).Text = dts.gidArticulo
            .SubItems(10).Text = dts.gidEstado
            .SubItems(11).Text = dts.gNombreTipoIVA & " " & dts.gTipoIVA & "%"
            If dts.gidEstado = estadoCRechazado.gidEstado Then
                .ForeColor = Color.Red
            Else
                .ForeColor = Color.Black
            End If

            If dts.gidConcepto = 0 Then
                .BackColor = Color.LightYellow
            Else
                .BackColor = Color.White
            End If

        End With

    End Sub




    Private Sub CalculaEstado()

        If lvConceptos.Items.Count = 0 Then
            'Si no hay conceptos --> CABECERA
            cbEstado.Items.Clear()
            cbEstado.Items.Add(estadoCabecera)
            funcALP.actualizaEstado(numAlbaran.Text, estadoCabecera.gidEstado)
            cbEstado.Text = estadoCabecera.gEstado
            gbConceptos.Enabled = False
            ConceptosEditables = False
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
        Else
            cbCodProveedor.Enabled = False
            cbProveedor.Enabled = False
            bBuscarProveedor.Enabled = False

            Dim AlgoRecibido As Boolean = False
            Dim TodoRecibido As Boolean = True
            Dim TodoRechazado As Boolean = False
            For Each item As ListViewItem In lvConceptos.Items
                Select Case item.SubItems(10).Text
                    Case estadoCRechazado.gidEstado
                        TodoRecibido = False
                    Case estadoCRecibido.gidEstado
                        AlgoRecibido = True
                        TodoRecibido = TodoRecibido And True
                    Case Else
                        TodoRecibido = False
                End Select
            Next

            If TodoRecibido Then
                'Todo Recibido --> Recibido
                cbEstado.Items.Clear()
                cbEstado.Items.Add(estadoRecibido)
                cbEstado.SelectedIndex = 0
                funcALP.actualizaEstado(numAlbaran.Text, estadoRecibido.gidEstado)
            ElseIf AlgoRecibido Then
                'Algo recibido --> Recibido parcial
                cbEstado.Items.Clear()
                cbEstado.Items.Add(estadoRecibidoParcial)
                cbEstado.SelectedIndex = 0
                funcALP.actualizaEstado(numAlbaran.Text, estadoRecibidoParcial.gidEstado)
            ElseIf TodoRechazado Then
                cbEstado.Items.Clear()
                cbEstado.Items.Add(estadoRechazado)
                cbEstado.SelectedIndex = 0
                funcALP.actualizaEstado(numAlbaran.Text, estadoRechazado.gidEstado)
            Else
                'En otro caso, no tocamos
            End If
        End If

    End Sub



#End Region

#Region "BOTONES GENERALES"

    '**************BOTONES EN CURSO

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        If inumPedido > 0 And iidAlbaran = 0 Then 'Modo Recepción pedido
            If cbArticulo.Text <> "" Then
                Call PreGuardarConcepto()
            Else
                If MsgBox("¿Generar el nuevo albarán con los datos introducidos y todas las lineas propuestas?" & vbCrLf & "Pulse CANCELAR para eliminar o modificar cantidades en lineas propuestas", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call GuardarRecepcion()
                    bSubirC.Enabled = True
                    bBajarC.Enabled = True
                End If
            End If
        ElseIf GuardarGeneral() Then
            If ConceptosEditables Then
                If cbArticulo.Text <> "" Then
                    If inumPedido = 0 Then 'no estamos recepcionando lineas
                        Call GuardarConcepto()
                    ElseIf iidconcepto = 0 Then
                        Call PreGuardarConcepto()
                    Else 'estamos recepcionando lineas pero esta no
                        Call GuardarConcepto()
                    End If
                ElseIf lvConceptos.Items.Count > 0 AndAlso VerificarQuedanLineasPropuestas() Then
                    If MsgBox("¿Añadir las lineas propuestas al albarán?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        GuardarConceptosLista()
                        bSubirC.Enabled = True
                        bBajarC.Enabled = True
                    End If
                End If
            End If
            Call CalcularEstado()
            cambios = False
        End If

    End Sub

    Private Sub GuardarRecepcion()
        If GuardarGeneral() Then
            Call GuardarConceptosLista()
            If Not ListaConceptos Is Nothing Then ListaConceptos.Clear()
            Call CalcularEstado()
            Call cambiosEnPedido(inumPedido)
            Call Recalcular()
            cambios = False
            AvisoNuevoAlbaran = False
        End If
    End Sub

    Private Sub GuardarConceptosLista()
        lvIndice = LineasDesplazamiento 'Desplazamiento()
        Dim indicelista As Integer = 0
        For Each dts As DatosConceptoAlbaranProv In ListaConceptos
            dts.gidAlbaran = dtsALP.gidAlbaran
            dts.gnumAlbaran = dtsALP.gnumAlbaran
            dts.gidConcepto = funcCAP.insertar(dts)
            ActualizarLineaLV(dts)
            Call CambiosEnConceptoPedido(ListaConceptos(indicelista).gidConceptoPedidoProv)
            ActualizarStock(dts, dts.gCantidad)
            indicelista = indicelista + 1
            lvIndice = lvIndice + 1
            Call cambiosEnPedido(dts.gnumPedido)
        Next
        If Not ListaConceptos Is Nothing Then ListaConceptos.Clear()
        lbPropuestos.Visible = False
        Call LimpiarEdicion()
    End Sub

    Private Sub cambiosEnPedido(ByVal inumPedido As Integer)
        If inumPedido > 0 Then
            Dim Stock As Boolean = True
            Dim StockParcial As Boolean = False
            Dim lista As List(Of DatosConceptoPedidoProv) = funcCP.mostrar(inumPedido)
            'Dim CantidadPendiente As Double = 0
            For Each dts As DatosConceptoPedidoProv In lista
                'CantidadPendiente = dts.gCantidad - dts.gCantidadRecibida
                Stock = Stock And (dts.gCantidadRecibida >= dts.gCantidad)
                StockParcial = StockParcial Or (dts.gCantidadRecibida < dts.gCantidad)
            Next
            If StockParcial Then
                funcPP.actualizaEstado(inumPedido, estadoPEStockParcial.gidEstado)

            ElseIf Stock Then
                funcPP.actualizaEstado(inumPedido, estadoPEStock.gidEstado)
            Else
                'Lo dejamos como está
            End If
        End If
    End Sub

    Private Function GuardarGeneral() As Boolean
        Try

            Dim Texto As String = ""
            ep1.Clear()
            ep2.Clear()
            ep3.Clear()
            'Dim AnulaPedidoRecibido As Boolean = False
            'Dim Remitente As String = funcPE.campoNombreyApellidos(vidUsuario)
            Dim validar As Boolean = True

            If cbProveedor.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbProveedor, "Se ha de especificar el proveedor")
            End If
            If numAlbaran.Text = "" Then
                validar = False
                ep1.SetError(numAlbaran, "Se ha de especificar el número de albarán del proveedor")
            Else
                If validar And iidAlbaran = 0 Then
                    iidProveedor = cbProveedor.SelectedItem.itemdata
                    If funcALP.ExisteAlbaran(numAlbaran.Text, iidProveedor) Then
                        validar = False
                        ep1.SetError(numAlbaran, "Número de albarán ya utilizado. ")
                    End If
                End If

            End If
            If cbProveedor.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbProveedor, "Se ha de seleccionar un proveedor")
            End If
            If cbSolicitadoPor.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbSolicitadoPor, "Se ha de especificar la persona")
            End If

            If cbDireccion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbDireccion, "Debe seleccionar una dirección")
            End If
            If cbMoneda.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMoneda, "Debe seleccionar una moneda")
            End If
            If cbEstado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
            ElseIf cbEstado.SelectedItem.gBloqueado Then
                validar = False
                MsgBox("El albarán no es modificable porque está facturado")
            End If
            If cbValorado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbValorado, "Se ha de seleccionar cómo está valorado el albarán")
            End If

            If validar Then
                If dtsPR Is Nothing Then
                    'Si no hemos cargado antes los datos del proveedor, lo hacemos ahora
                    dtsPR = funcP.mostrar1(cbProveedor.SelectedItem.itemdata)
                    iidProveedor = dtsPR.gidProveedor
                    dtsFA = funcFF.mostrarProv(iidProveedor)
                End If
                If lvConceptos.Items.Count = 0 Then
                    cbEstado.Items.Clear()
                    cbEstado.Items.Add(estadoCabecera)
                    cbEstado.Text = estadoCabecera.gEstado
                End If
                dtsALP.gnumAlbaran = numAlbaran.Text
                dtsALP.gidProveedor = cbProveedor.SelectedItem.ItemData
                dtsALP.gReferencia = Referencia.Text
                dtsALP.gSolicitadoVia = cbsolicitadoVia.Text
                dtsALP.gidUbicacion = cbDireccion.SelectedItem.itemdata
                dtsALP.gObservaciones = Observaciones.Text
                dtsALP.gFecha = dtpFecha.Value
                dtsALP.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda
                dtsALP.gidPersona = cbSolicitadoPor.SelectedItem.itemdata
                dtsALP.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
                dtsALP.gPersona = cbSolicitadoPor.Text
                dtsALP.gBultos = If(IsNumeric(Bultos.Text), CInt(Bultos.Text), 0)
                If cbPortes.Text = "PAGADOS" Then
                    dtsALP.gPortes = "P"
                ElseIf cbPortes.Text = "DEBIDOS" Then
                    dtsALP.gPortes = "D"
                Else
                    dtsALP.gPortes = "I"
                End If
                If cbTransporte.SelectedIndex = -1 Then
                    dtsALP.gidTransporte = 0
                    dtsALP.gTransporte = cbTransporte.Text
                Else
                    If cbTransporte.SelectedItem.itemdata < 1 Then
                        dtsALP.gidTransporte = 0
                        dtsALP.gTransporte = cbTransporte.Text
                    Else
                        dtsALP.gidTransporte = cbTransporte.SelectedItem.itemData
                        dtsALP.gTransporte = ""
                    End If
                End If
                If Descuento.Text = "" Then Descuento.Text = 0
                dtsALP.gProntoPago = Descuento.Text

                dtsALP.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
                dtsALP.gNotas = Nota.Text
                dtsALP.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsALP.gEstado = cbEstado.Text
                dtsALP.gidTipoRetencion = dtsFA.gidTipoRetencion
                dtsALP.gTipoRetencion = dtsFA.gTipoRetencion

                If PrecioTransporte.Text = "" Then PrecioTransporte.Text = 0
                dtsALP.gPrecioTransporte = PrecioTransporte.Text

                If G_AGeneral = "G" Then
                    iidAlbaran = funcALP.insertar(dtsALP)
                    dtsALP.gidAlbaran = iidAlbaran
                    If iidAlbaran > 0 Then
                        Dim titulo As String = funcTC.Tipo(dtsPR.gIdTipoCompra)
                        Me.Text = "EDITAR ALBARÁN DE PROVEEDOR " & UCase(titulo)
                        G_AGeneral = "A"
                        Dim Aviso As String = "Creado el albarán " & numAlbaran.Text
                        If lvConceptos.Items.Count = 0 Then
                            Aviso = Aviso & ". Ya puede introducir los conceptos."
                        End If
                        MsgBox(Aviso)
                        gbConceptos.Enabled = True

                        vfecha = dtpFecha.Value
                    End If
                    cambios = False

                    Call IntroducirArticulos()
                ElseIf G_AGeneral = "A" Then
                    If cambios Then
                        If funcALP.actualizar(dtsALP) Then
                            Call Recalcular()
                            If cbArticulo.Text = "" Then MsgBox("Albaran actualizado correctamente")
                        End If
                        cambios = False
                    End If
                End If
            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarGeneral")
            ex.Data.Add("numAlbaran.Text", numAlbaran.Text)
            CorreoError(ex)
            Return False
        End Try
    End Function

    Private Sub CalcularEstado()

        cbEstado.Items.Clear()
        If cbEstado.SelectedIndex <> -1 AndAlso cbEstado.SelectedItem.gidestado = estadoFacturado.gidEstado Then
        ElseIf lvConceptos.Items.Count = 0 Then
            cbEstado.Items.Add(estadoCabecera)
            cbEstado.Text = estadoCabecera.gEstado
            funcALP.actualizaEstado(dtsALP.gidAlbaran, estadoCabecera.gidEstado)
        Else
            Dim algunoRechazado As Boolean = False
            Dim TodosRechazados As Boolean = True
            For Each item As ListViewItem In lvConceptos.Items
                If item.ForeColor = Color.Red Then
                    algunoRechazado = True
                Else
                    TodosRechazados = False
                End If
            Next
            If TodosRechazados Then
                cbEstado.Items.Add(estadoRechazado)
                cbEstado.Text = estadoRechazado.gEstado
                funcALP.actualizaEstado(dtsALP.gidAlbaran, estadoRechazado.gidEstado)
            ElseIf algunoRechazado Then
                cbEstado.Items.Add(estadoRecibidoParcial)
                cbEstado.Text = estadoRecibidoParcial.gEstado
                funcALP.actualizaEstado(dtsALP.gidAlbaran, estadoRecibidoParcial.gidEstado)
            Else
                cbEstado.Items.Add(estadoRecibido)
                cbEstado.Text = estadoRecibido.gEstado
                funcALP.actualizaEstado(dtsALP.gidAlbaran, estadoRecibido.gidEstado)
            End If
        End If
    End Sub

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            InformeAlbaranDeProv.verInforme(iidAlbaran)
            InformeAlbaranDeProv.ShowDialog()

        End If
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click

        If cbArticulo.Text <> "" Then
            Call inicializaConcepto()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará un nuev pedido. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará un nuevo pedido. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call Nuevo()
                End If
            End If
        End If
    End Sub

    Private Sub bEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEmail.Click

        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        ElseIf cbDireccion.SelectedIndex = -1 Then
            MsgBox("No hay una dirección seleccionada válida")
        Else
            Dim fichero As String = "AlbaranDeProv SV " & Trim(numAlbaran.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            fichero.Replace("/", "_")
            fichero.Replace("\", "_")

            Dim camino As String = Path.GetTempPath()
            InformeAlbaranDeProv.GeneraPDF(iidAlbaran, fichero, camino)
            Dim destinatario As String = funcUB.campoCorreo(cbDireccion.SelectedItem.itemdata)
            If cbContacto.SelectedIndex <> -1 Then
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    destinatario = If(destinatario = "", dts.gmail, destinatario & "; " & dts.gmail)
                Next
            End If

            'Dim texto As String = " Estimados Señores,<br><br>"
            'texto = texto & "A continuación adjuntamos NUEVO albarán de compra nº " & numAlbaran.Text

            'Se envía un correo outlook a la dirección de la ubicación

            CorreoOutlook("ALBARÁN DE PROVEEDOR", funcPE.campoCorreo(Inicio.vIdUsuario), destinatario, camino & fichero, cbContacto.Text, numAlbaran.Text, dtpFecha.Value.Date, dtpFecha.Value.Date, funcUB.campoIdioma(cbDireccion.SelectedItem.itemData))
            'CorreoOutlook("Nuevo Albarán SUGAR VALLEY", texto, funcPE.campoCorreo(Inicio.vIdUsuario), destinatario, camino & fichero)
        End If
    End Sub

    Private Sub bNuevoCProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim GG As New GestionProveedores
        GG.SoloLectura = vSoloLectura
        GG.pidProveedor = 0
        GG.ShowDialog()
        If iidProveedor > 0 Then
            iidProveedor = GG.pidProveedor
            Call introducirProveedores()
            cbProveedor.Text = funcP.campoProveedor(iidProveedor)
            CargarDatosProv()
        End If
    End Sub

    Private Sub bBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarProveedor.Click
        Dim GG As New busquedaproveedor
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidproveedor > 0 Then
            iidProveedor = GG.pidproveedor
            cbProveedor.Text = funcP.campoProveedor(iidProveedor)
            CargarDatosProv()
        End If

    End Sub

    Private Sub bVerProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerProveedor.Click
        If iidProveedor > 0 Then

            Dim GG As New GestionProveedores
            GG.SoloLectura = vSoloLectura
            GG.pidProveedor = iidProveedor
            GG.ShowDialog()
            Dim dtsFAN As datosfacturacion = funcFF.mostrarProv(iidProveedor)
            If ProveedorSoloLectura Then
                cbProveedor.Items.Clear()
                cbCodProveedor.Items.Add(New IDComboBox(dtsPR.gcodProveedor, dtsPR.gidProveedor))
                cbProveedor.Items.Add(New IDComboBox(dtsPR.gnombrefiscal, dtsPR.gidProveedor))
                cbProveedor.SelectedIndex = 0
            Else
                Call introducirProveedores()
                cbProveedor.Text = dtsPR.gnombrefiscal
                cbCodProveedor.Text = dtsPR.gcodProveedor
                If cbProveedor.SelectedIndex = -1 Then
                    cbProveedor.Text = ""
                    cbCodProveedor.Text = ""
                End If
            End If
            If cbEstado.SelectedIndex <> -1 AndAlso cbEstado.SelectedItem.gBloqueado = False Then
                If dtsFA.gidTipoIVA <> dtsFAN.gidTipoIVA Or dtsFA.gTipoIVA <> dtsFAN.gTipoIVA Or dtsFA.gTipoRecargoEq <> dtsFAN.gTipoRecargoEq _
                Or dtsALP.gRecargoEquivalencia <> dtsFAN.gRecargoEquivalencia Or dtsALP.gidTipoRetencion <> dtsFAN.gidTipoRetencion Or dtsALP.gTipoRetencion <> dtsFAN.gTipoRetencion Then
                    If MsgBox("¿Propagar y guardar los cambios de facturación del proveedor al albarán?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Call CargarDatosProv()
                        dtsALP.gidTipoRetencion = dtsFA.gidTipoRetencion
                        dtsALP.gTipoRetencion = dtsFA.gTipoRetencion
                        dtsALP.gRecargoEquivalencia = dtsFA.gRecargoEquivalencia
                        Call GuardarGeneral()
                    End If
                End If
            Else
                MsgBox("El albarán no es modificable en estado " & cbEstado.Text)
            End If
            cambios = True
        End If
    End Sub

    Private Sub bConvertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bConvertir.Click
        If iidAlbaran = 0 Then
            MsgBox("Aún no se ha generado el albarán")
        Else
            Dim N As Integer = lvConceptos.CheckedItems.Count
            If ckSeleccion.Visible And N > 0 Then
                Dim Conceptos As New List(Of Long)

                Dim iidConcepto As Integer
                For Each item As ListViewItem In lvConceptos.CheckedItems
                    iidConcepto = item.SubItems(1).Text
                    'Verificamos que la linea no haya sido ya traspasada

                    If funcCAP.Traspasada(iidConcepto) Then
                        item.Checked = False
                    Else
                        Conceptos.Add(iidConcepto)
                    End If
                Next
                N = N - lvConceptos.CheckedItems.Count
                If N = 1 Then
                    MsgBox("Se ha desactivado un concepto que ya ha sido convertido previamente.")
                End If
                If N > 1 Then
                    MsgBox("Se han desactivado " & N & " conceptos que ya han sido convertidos previamente.")
                End If
                If Conceptos.Count = 0 Then
                    If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
                Else
                    Dim GG As New FlujoSiguiente
                    GG.SoloLectura = vSoloLectura
                    GG.pDesde = "ALBARAN PROVEEDOR"
                    GG.pHasta = "FACTURA PROVEEDOR"
                    GG.pnumDesde = iidAlbaran
                    GG.pConceptos = Conceptos
                    GG.pLocalizacion = Me.Location
                    GG.ShowDialog()
                    Call CargarAlbaran()

                End If
            Else
                If MsgBox("Seleccione los conceptos que se han de convertir en Factura ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    ckSeleccion.Visible = True
                    lvConceptos.CheckBoxes = True
                End If
            End If
        End If
    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call inicializar()
                    indiceL = indiceL - 1
                    iidAlbaran = Albaranes(indiceL)
                    Call CargarAlbaran()
                End If

            Else
                Call inicializar()
                indiceL = indiceL - 1
                iidAlbaran = Albaranes(indiceL)
                Call CargarAlbaran()
            End If


        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Albaranes.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    indiceL = indiceL + 1
                    iidAlbaran = Albaranes(indiceL)
                    Call CargarAlbaran()
                End If
            Else

                indiceL = indiceL + 1
                iidAlbaran = Albaranes(indiceL)
                Call CargarAlbaran()
            End If


        End If
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else

            Dim fichero As String = "AlbaranDeProv SV " & Trim(numAlbaran.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeAlbaranDeProv.GeneraPDF(iidAlbaran, sfd.FileName, "")
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If

    End Sub

#End Region

#Region "BOTONES Conceptos"

    ''**************BOTONES Conceptos




    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        'Hay que detectar si borramos el documento o la linea
        If lvIndice = -1 Then
            'Borrar Albaran
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Albaran, es como pulsar nuevo
                Call BorrarNuevo()
            Else
                If dtsALP.gidEstado = estadoCabecera.gidEstado Then
                    Call BorrarNuevo()
                Else
                    MsgBox("No es posible borrar una Albaran con conceptos. Puede eliminar los conceptos hasta dejar el albarán en estado CABECERA")
                End If
            End If
        Else
            'Borrar concepto
            If ConceptosEditables Then
                Dim validar = True
                If cbEstado.SelectedIndex = -1 Then
                Else
                    If cbEstado.SelectedItem.gtraspasado Then
                        MsgBox("Este albarán ya ha sido facturado. No se pueden modificar los conceptos.")
                        validar = False
                    End If
                End If
                If validar Then
                    Dim iidConcepto As Integer = lvConceptos.Items(lvIndice).SubItems(1).Text
                    If iidConcepto > 0 Then
                        Dim iidEstado As Integer = lvConceptos.Items(lvIndice).SubItems(10).Text
                        Select Case iidEstado
                            Case estadoCRTraspasado.gidEstado
                                MsgBox("La linea indicada ya ha sido traspasada. No se puede borrar.")
                            Case estadoCRechazado.gidEstado
                                If MsgBox("Se borrara la linea seleccionada, se descontará de stock pero en el pedido relacionado seguirá apareciendo como recibida. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                    Dim dts As DatosConceptoAlbaranProv = funcCAP.mostrar1(iidConcepto)
                                    dts.gFechaRecibido = Now
                                    If funcCAP.borrar(iidConcepto, iidAlbaran) Then ActualizarStock(dts, -dts.gCantidad)
                                    lvConceptos.Items.RemoveAt(lvIndice)
                                    Call LimpiarEdicion()
                                    If lvConceptos.Items.Count = 0 Then
                                        cbEstado.Items.Clear()
                                        cbEstado.Items.Add(estadoCabecera)
                                        cbEstado.Text = estadoCabecera.gEstado
                                        funcALP.actualizaEstado(iidAlbaran, estadoCabecera.gidEstado)
                                    End If
                                    Call Recalcular()
                                    LineasDesplazamiento = Desplazamiento()
                                End If

                            Case estadoCRecibido.gidEstado
                                If MsgBox("Se borrara la linea seleccionada, se descontará de stock pero en el pedido relacionado seguirá apareciendo como recibida. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                    Dim dts As DatosConceptoAlbaranProv = funcCAP.mostrar1(iidConcepto)
                                    dts.gFechaRecibido = Now
                                    If funcCAP.borrar(iidConcepto, iidAlbaran) Then ActualizarStock(dts, -dts.gCantidad)
                                    lvConceptos.Items.RemoveAt(lvIndice)
                                    Call LimpiarEdicion()
                                    If lvConceptos.Items.Count = 0 Then
                                        cbEstado.Items.Clear()
                                        cbEstado.Items.Add(estadoCabecera)
                                        cbEstado.Text = estadoCabecera.gEstado
                                        funcALP.actualizaEstado(iidAlbaran, estadoCabecera.gidEstado)
                                    End If
                                    Call Recalcular()
                                    LineasDesplazamiento = Desplazamiento()
                                End If
                        End Select
                    Else
                        ListaConceptos.RemoveAt(lvIndice - LineasDesplazamiento) 'Desplazamiento())
                        lvConceptos.Items.RemoveAt(lvIndice)
                        Call LimpiarEdicion()
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub BorrarNuevo()
        If cambios Then
            If MsgBox("Borrar nuevo albarán: se perderán los los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Call InicializarGeneral()
                Call Nuevo()
            End If
        Else
            Call InicializarGeneral()
            Call Nuevo()
        End If
    End Sub

    Private Sub ActualizarStock(ByVal dts As DatosConceptoAlbaranProv, ByVal CantidadMovimiento As Double)
        'Solo podemos añadir al stock si es un artículo existente y hemos recibido cantidad adicional
        If dts.gidArticulo > 0 Then
            Dim dtsS As New DatosStock
            dtsS.gCantidad = CantidadMovimiento
            dtsS.gcodMoneda = dts.gcodMoneda
            dtsS.gFecha = dts.gFechaRecibido
            dtsS.gidAlmacen = 0
            dtsS.gidArticulo = dts.gidArticulo
            dtsS.gidArticuloProv = dts.gidArticuloProv
            dtsS.gidConceptoProv = dts.gidConceptoPedidoProv
            dtsS.gidConceptoAlbaran = 0
            dtsS.gidConceptoPedido = 0
            dtsS.gidProduccion = 0
            dtsS.gidLote = 0
            dtsS.gidUnidad = dts.gidUnidad
            dtsS.gnumPedidoProv = dts.gnumPedido
            dtsS.gPrecio = dts.gPrecioNetoUnitario
            dtsS.gMovimiento = ""
            dtsS.gidPersona1 = Inicio.vIdUsuario
            dtsS.gidPersona2 = 0
            funcST.insertar(dtsS)
        End If
    End Sub




    Private Sub bNuevoConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        inicializaConcepto()

    End Sub




    Private Sub BBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscarArticulo.Click

        Try
            Dim BA As New lbBusquedaArticulo
            BA.SoloLectura = vSoloLectura
            BA.pModo = "COMPRABLE"
            BA.pidProveedor = iidProveedor
            BA.ShowDialog()
            iidArticulo = BA.pidArticulo
            If BA.pidArticuloProv > 0 Then
                Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(BA.pidArticuloProv)
                cbcodArticuloProv.Text = dts.gcodArticuloProv
                Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia
                cbArticulo.Text = dts.gNombre
                If cbArticulo.Text <> dts.gNombre Then
                    cbArticulo.Items.Add(New IDComboBox3(iidArticulo, dts.gNombre, BA.pidArticuloProv))
                    cbArticulo.Text = dts.gNombre
                End If
                cbcodArticulo.Text = dts.gcodArticulo
                lbUnidad.Text = dts.gTipoUnidad
            Else
                Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                cbcodArticuloProv.Text = dts.gcodArticuloProv
                Precio.Text = FormatNumber(dts.gPrecioUnitarioC, If(dts.gPrecioUnitarioC >= 5, 4, 6))
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia
                cbArticulo.Text = dts.gArticulo

                If cbArticulo.Text <> dts.gArticulo Then
                    cbArticulo.Items.Add(New IDComboBox3(iidArticulo, dts.gArticulo, 0))
                    cbArticulo.Text = dts.gArticulo
                End If
                cbcodArticulo.Text = dts.gcodArticulo
                lbUnidad.Text = dts.gTipoUnidad
            End If

        Catch ex As Exception
            CorreoError(ex)
        End Try

    End Sub



    Private Sub bArticuloProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bArticuloProveedor.Click
        Dim GG As New GestionArticulosProv
        GG.SoloLectura = vSoloLectura
        GG.pidProveedor = iidProveedor
        GG.ShowDialog()

        Call IntroducirArticulos()
        If GG.pidArticuloProv > 0 Then
            iidArticulo = GG.pidArticulo
            Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(GG.pidArticuloProv)
            cbcodArticuloProv.Text = dts.gcodArticuloProv
            cbcodArticulo.Text = dts.gcodArticulo
            cbArticulo.Text = dts.gArticulo
            Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
            cbFamilia.Text = dts.gFamilia
            cbSubFamilia.Text = dts.gSubFamilia
            lbUnidad.Text = dts.gTipoUnidad

        End If

    End Sub

    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticulo.Click
        Dim GG As New GestionArticulo
        GG.SoloLectura = vSoloLectura
        GG.pidArticulo = iidArticulo
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            iidArticulo = GG.pidArticulo
            Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticulo, iidProveedor)
            cbcodArticuloProv.Text = dts.gcodArticuloProv
            cbcodArticulo.Text = dts.gcodArticulo
            cbArticulo.Text = dts.gArticulo
            Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
            cbFamilia.Text = dts.gFamilia
            cbSubFamilia.Text = dts.gSubFamilia
            lbUnidad.Text = dts.gTipoUnidad


        End If
    End Sub



    Private Sub bfAMILIAS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bFamilias.Click
        Dim Familia As String = cbFamilia.Text
        Dim subFamilia As String = cbSubFamilia.Text
        Dim GF As New GestionFamilias
        GF.SoloLectura = vSoloLectura
        GF.ShowDialog()
        Call introducirFamilias()
        cbFamilia.Text = Familia
        If cbFamilia.SelectedIndex = -1 Then
            cbFamilia.Text = ""
        Else
            cbSubFamilia.Text = subFamilia
            If cbSubFamilia.SelectedIndex = -1 Then cbSubFamilia.Text = ""
        End If

    End Sub

    Private Sub bLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call inicializaConcepto()
    End Sub


    Private Sub bBajarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajarC.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            If indice < lvConceptos.Items.Count - 1 Then
                Dim indiceActual As Integer = indice
                Dim indiceInferior As Integer = indice + 1
                Call LimpiarEdicion()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(1).Text
                Dim iidConceptoInferior As Long = lvConceptos.Items(indiceInferior).SubItems(1).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemInferior As ListViewItem = lvConceptos.Items(indiceInferior).Clone
                If funcCAP.MoverConceptos(iidConceptoInferior, iidConceptoActual) Then
                    lvConceptos.Items(indiceActual) = itemInferior
                    lvConceptos.Items(indiceInferior) = itemActual
                    lvConceptos.SelectedItems.Clear()
                    lvConceptos.Items(indiceInferior).Selected = True
                    lvConceptos.EnsureVisible(indiceInferior)
                End If
            End If
        End If
    End Sub


    Private Sub bSubirC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubirC.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvConceptos.SelectedIndices(0)
            If indice > 0 Then
                Dim indiceActual As Integer = indice
                Dim indiceSuperior As Integer = indice - 1
                Call LimpiarEdicion()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(1).Text
                Dim iidConceptoSuperior As Long = lvConceptos.Items(indiceSuperior).SubItems(1).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemSuperior As ListViewItem = lvConceptos.Items(indiceSuperior).Clone
                If funcCAP.MoverConceptos(iidConceptoActual, iidConceptoSuperior) Then
                    lvConceptos.Items(indiceActual) = itemSuperior
                    lvConceptos.Items(indiceSuperior) = itemActual
                    lvConceptos.SelectedItems.Clear()
                    lvConceptos.Items(indiceSuperior).Selected = True
                    lvConceptos.EnsureVisible(indiceSuperior)
                End If
            End If
        End If
    End Sub



#End Region

#Region "EVENTOS"


    Private Sub Precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Precio.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Precio.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PrecioTransporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioTransporte.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioTransporte.Text, ",") Then
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

    Private Sub Cantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Bultos.TextChanged, Cantidad.Click, Precio.Click, PrecioTransporte.Click, DescuentoC.Click, Descuento.Click
        sender.SelectAll()
    End Sub



    Private Sub cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Cantidad.Text = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Cantidad.Text = "" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(Cantidad.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            Call GuardarConcepto()
        End If
    End Sub




    Private Sub lvConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        'si marcamos algún concepto se copia en la zona de edición, nos guardamos el índice dentro del listview y el valor del idConcepto

        If lvConceptos.SelectedItems.Count > 0 Then
            lvIndice = lvConceptos.SelectedIndices(0)
            iidconcepto = lvConceptos.Items(lvIndice).SubItems(1).Text
            iidArticulo = lvConceptos.Items(lvIndice).SubItems(9).Text
            Try
                Dim dts As DatosConceptoAlbaranProv
                If iidconcepto = 0 Then

                    If iidAlbaran = 0 Then
                        'En el listview sólo hay elementos de la lista
                        dts = ListaConceptos(lvIndice)
                    Else
                        dts = ListaConceptos(lvIndice - LineasDesplazamiento) 'Desplazamiento())
                    End If
                Else
                    dts = funcCAP.mostrar1(iidconcepto)
                End If

                Dim vMonedaC As String = vMoneda
                CantidadRecibida = dts.gCantidad
                vMonedaC = dtsALP.gcodMoneda
                cbcodArticulo.Text = dts.gcodArticulo
                cbcodArticuloProv.Text = dts.gcodArticuloProv
                Cantidad.Text = FormatNumber(dts.gCantidad, 2)
                lbUnidad.Text = dts.gTipoUnidad
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia
                cbArticulo.Text = dts.gArticuloProv
                'Si no está en los combos, lo añadimos
                ' If cbArticulo.Text <> dts.gArticuloProv Or cbcodArticuloProv.Text <> dts.gcodArticuloProv Or cbcodArticulo.Text <> dts.gcodArticulo Then
                If cbArticulo.SelectedIndex = -1 Then
                    cbArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gArticuloProv, dts.gidArticuloProv))
                    cbArticulo.Text = dts.gArticuloProv
                    cbcodArticuloProv.Items.Add(New IDComboBox3(dts.gcodArticuloProv, dts.gidArticulo, dts.gidArticuloProv))
                    cbcodArticuloProv.Text = dts.gcodArticuloProv
                    cbcodArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticulo, dts.gidArticuloProv))
                    cbcodArticulo.Text = dts.gcodArticulo
                End If

                If vMonedaC = vMoneda Then
                    Precio.Text = FormatNumber(dts.gPrecioNetoUnitario, If(dts.gPrecioNetoUnitario >= 5, 4, 6))
                    totalConcepto.Text = FormatNumber(dts.gTotalConcepto, 2)
                Else
                    Dim aviso As Boolean
                    Dim FEchaCambio As Date
                    Dim precioC As Double = funcMO.Cambio(dts.gPrecioNetoUnitario, vMonedaC, vMoneda, aviso, FEchaCambio)
                    Precio.Text = FormatNumber(precioC, If(precioC >= 5, 4, 6))
                    totalConcepto.Text = FormatNumber(funcMO.Cambio(dts.gTotalConcepto, vMonedaC, vMoneda, aviso, FEchaCambio), 2)
                    If aviso Then
                        ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FEchaCambio)
                    End If
                End If
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia

                Dim dtsTI As DatosTipoIVA = funcTI.Mostrar1(dts.gidTipoIVA)
                If dtsTI.gTipoIVA <> dts.gTipoIVA Then
                    dtsTI.gTipoIVA = dts.gTipoIVA
                    cbTipoIVA.Items.Add(dtsTI)
                End If
                cbTipoIVA.Text = dtsTI.ToString
                ObservacionesC.Text = dts.gObservaciones
                ckRechazado.Checked = (dts.gidEstado = estadoCRechazado.gidEstado)

            Catch ex As Exception
                CorreoError(ex)
            End Try
        End If
    End Sub

    Private Function Desplazamiento() As Integer
        Desplazamiento = 0
        For Each item As ListViewItem In lvConceptos.Items
            If item.SubItems(1).Text > 0 Then Desplazamiento = Desplazamiento + 1
        Next
    End Function

    Private Sub detectaCambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAlbaran.TextChanged, Referencia.TextChanged, _
    cbsolicitadoVia.TextChanged, cbSolicitadoPor.TextChanged, dtpFecha.ValueChanged, Observaciones.TextChanged, cbEstado.SelectionChangeCommitted, _
     cbTipoIVA.SelectedIndexChanged, cbsolicitadoVia.SelectedIndexChanged, cbSolicitadoPor.SelectedIndexChanged, PrecioTransporte.TextChanged, _
      cbContacto.SelectedIndexChanged, Nota.TextChanged, Descuento.TextChanged, cbTransporte.SelectedIndexChanged, cbValorado.SelectedIndexChanged
        If numAlbaran.Text = "" Then
            ep3.SetError(numAlbaran, "Se ha de indicar el número de albarán")
        Else
            ep3.Clear()
        End If
        cambios = Semaforo
    End Sub





    Private Sub cbPortes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPortes.SelectedIndexChanged
        If cbPortes.Text = "PAGADOS" Or cbPortes.Text = "DEBIDOS" Then
            PrecioTransporte.Enabled = False
            PrecioTransporte.Text = 0
        Else
            PrecioTransporte.Enabled = True
        End If
        cambios = True
    End Sub

    Private Sub cbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged
        If Semaforo Then
            'If G_AGeneral = "A" Then
            '    'detectamos cambios en la EN CURSO para poder avisar si se sale sin guardar
            '    If ValidaPed Then
            '        gbConceptos.Enabled = cbEstado.SelectedItem.gidEstado <> estadoAnulado.gidEstado
            '        If cbEstado.SelectedIndex <> -1 Then
            '            If cbEstado.Text <> EstadoOriginal And cbEstado.SelectedItem.ganulado Then
            '                bGuardar.Enabled = Not vSoloLectura
            '            End If
            '        End If
            '    Else
            '        'gbConceptos.Enabled = (cbEstado.Text <> "STOCK" And cbEstado.Text <> "ANULADO" And cbEstado.Text <> "FINALIZADO" And (cbEstado.Text <> "VALIDADO")) 'Or ValidaPed))
            '        gbConceptos.Enabled = cbEstado.SelectedItem.gidEstado <> estadoStock.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoAnulado.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoValidado.gidEstado


            '    End If

            'End If
        End If

    End Sub





    Private Sub detectaCambioFecha(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged

        If Semaforo Then
            'detectamos cambios en la EN CURSO para poder avisar si se sale sin guardar
            'bGuardar.Enabled = Not vSoloLectura
            gbConceptos.Enabled = G_AGeneral = "A" And (cbEstado.Text <> "STOCK" And cbEstado.Text <> "ANULADO" And cbEstado.Text <> "FINALIZADO" And (cbEstado.Text <> "VALIDADO")) 'Or ValidaPed))

            cambios = True
            'detectamos cambios en la EN CURSO para poder avisar si se sale sin guardar
            'bGuardar.Enabled = Not vSoloLectura
            cambios = True
            'detectamos si ha habido un cambio de año y ya hemos guardado el documento
            If G_AGeneral = "A" Then
                If dtpFecha.Value.Year <> vfecha.Year Then
                    MsgBox("Año no válido", MsgBoxStyle.OkOnly)
                    dtpFecha.Value = vfecha
                End If
            End If
        End If
    End Sub





    Private Sub Precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Precio.TextChanged, Cantidad.TextChanged, DescuentoC.TextChanged
        If Semaforo Then
            Semaforo = False
            If Precio.Text = "" Or Precio.Text = "-" Or Precio.Text = "." Or Precio.Text = "," Then Precio.Text = 0
            If DescuentoC.Text = "" Or DescuentoC.Text = "-" Or DescuentoC.Text = "." Or DescuentoC.Text = "," Then DescuentoC.Text = 0
            If IsNumeric(Cantidad.Text) Then
                If Cantidad.Text = "" Then Cantidad.Text = 0
                totalConcepto.Text = FormatNumber(CDbl(Precio.Text) * CDbl(Cantidad.Text) * (1 - (CDbl(DescuentoC.Text) / 100)), 2)
            Else
                totalConcepto.Text = 0
            End If
            Semaforo = True
        End If
    End Sub



    Private Sub cbUnidadMedida_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Semaforo Then
            'lbUnidadMedida.Text = cbUnidadMedida.Text
            Call actualizaPrecioTotal()
            'If cbNombre.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura

        End If
    End Sub


    Private Sub codArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticulo.SelectedIndexChanged
        If Semaforo Then
            Semaforo = False
            If cbcodArticulo.SelectedIndex > -1 Then
                iidArticuloProv = cbcodArticulo.SelectedItem.itemdata
                iidArticulo = cbcodArticulo.SelectedItem.name1
                If iidArticuloProv > 0 Then
                    Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticuloProv)
                    cbcodArticuloProv.Text = dts.gcodArticuloProv
                    cbArticulo.Text = dts.gNombre
                    Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    lbUnidad.Text = dts.gTipoUnidad
                Else
                    Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                    cbArticulo.Text = dts.gArticulo
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    If dts.gidProveedor = iidProveedor Then
                        cbcodArticuloProv.Text = dts.gcodArticuloProv
                    End If
                    Precio.Text = FormatNumber(dts.gPrecioUnitarioC, If(dts.gPrecioUnitarioC >= 5, 4, 6))
                    lbUnidad.Text = dts.gTipoUnidad
                End If
            End If

            Semaforo = True
        End If
    End Sub


    Private Sub codArticuloProv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticuloProv.SelectedIndexChanged
        If Semaforo Then
            Semaforo = False
            If cbcodArticuloProv.SelectedIndex > -1 Then
                iidArticuloProv = cbcodArticuloProv.SelectedItem.itemdata
                iidArticulo = cbcodArticuloProv.SelectedItem.name1
                If iidArticuloProv > 0 Then
                    Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticuloProv)
                    cbcodArticulo.Text = dts.gcodArticulo
                    cbArticulo.Text = dts.gNombre
                    Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    lbUnidad.Text = dts.gTipoUnidad
                Else
                    Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                    cbArticulo.Text = dts.gArticulo
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    If dts.gidProveedor = iidProveedor Then
                        cbcodArticuloProv.Text = dts.gcodArticuloProv
                    End If
                    Precio.Text = FormatNumber(dts.gPrecioUnitarioC, If(dts.gPrecioUnitarioC >= 5, 4, 6))
                    lbUnidad.Text = dts.gTipoUnidad
                End If

            End If
            Semaforo = True
        End If
    End Sub


    Private Sub cbNombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If Semaforo Then
            Semaforo = False
            If cbArticulo.SelectedIndex > -1 Then
                iidArticuloProv = cbArticulo.SelectedItem.itemdata
                iidArticulo = cbArticulo.SelectedItem.name1
                If iidArticuloProv > 0 Then
                    Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(cbArticulo.SelectedItem.itemdata)
                    cbcodArticuloProv.Text = dts.gcodArticuloProv
                    cbcodArticulo.Text = dts.gcodArticulo
                    lbUnidad.Text = dts.gTipoUnidad
                    Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                Else
                    Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                    cbcodArticulo.Text = dts.gcodArticulo
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    If dts.gidProveedor = iidProveedor Then
                        cbcodArticuloProv.Text = dts.gcodArticuloProv
                    End If
                    Precio.Text = FormatNumber(dts.gPrecioUnitarioC, If(dts.gPrecioUnitarioC >= 5, 4, 6))
                    lbUnidad.Text = dts.gTipoUnidad
                End If
            End If
            Semaforo = True
        End If
    End Sub



    'Private Sub cbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectedIndexChanged
    '    'Al modificar el proveedor cargamos el cbCodigo_C solo si es un tipo de materias primas.
    '    If semaforo Then
    '        Call CargarDatosProv()
    '        Call IntroducirArticulos()
    '        cambios = True
    '    End If
    'End Sub



    Private Sub cbCodProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodProveedor.SelectionChangeCommitted
        If cbCodProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbCodProveedor.SelectedItem.itemdata
            ' dtsP = funcP.mostrar1(iidProveedor)
            cbProveedor.Text = funcP.campoProveedor(iidProveedor)
            Call CargarDatosProv()
            cambios = True
        End If
    End Sub


    Private Sub cbProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectionChangeCommitted
        If cbProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbProveedor.SelectedItem.itemdata
            ' dtsALP = funcP.mostrar1(iidProveedor)
            cbCodProveedor.Text = funcP.campocodProveedor(iidProveedor)
            Call CargarDatosProv()
            cambios = True
        End If
    End Sub


    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            Semaforo = False
            For Each item As ListViewItem In lvConceptos.Items
                item.Checked = ckSeleccion.Checked
            Next
            Semaforo = True
        End If

    End Sub



    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvConceptos.ItemChecked
        If Semaforo Then
            Dim cont As Integer = lvConceptos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvConceptos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub


    Private Sub PresentarAvisoProveedor()
        If Trim(dtsPR.gobservaciones).Length > 0 And Not AvisadoProveedor Then
            MsgBox(dtsPR.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsPR.gnombrecomercial)
            AvisadoProveedor = True
        End If
    End Sub

    Private Sub CargarDatosProv()

        If cbProveedor.SelectedIndex <> -1 Then
            ep1.Clear()
            ep2.Clear()
            iidProveedor = cbProveedor.SelectedItem.itemdata
            dtsPR = funcP.mostrar1(iidProveedor)
            dtsFA = funcFF.mostrarProv(iidProveedor)
            Call PresentarAvisoProveedor()
            iidTipoCompra = dtsPR.gIdTipoCompra

            Call CargarDirecciones()
            If cbDireccion.Items.Count = 0 Then
                MsgBox("Este Proveedor no tiene una dirección de recogida introducida. Por favor, añada una dirección desde la Ficha del proveedor.")
            Else

                vMoneda = funcP.campoMoneda(iidProveedor)
                lbMoneda1.Text = funcMO.CampoSimbolo(vMoneda)

                'Transporte.Text = funcFF.campoTransporte(iidProveedor)
                cbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
                Descuento.Text = FormatNumber(dtsFA.gDescuento, 2)
                Dim titulo As String = funcP.TipoCompra(iidProveedor)
                If G_AGeneral = "G" Then
                    Me.Text = "NUEVO ALBARÁN DE PROVEEDOR " & UCase(titulo)
                Else
                    Me.Text = "EDITAR ALBARÁN DE PROVEEDOR " & UCase(titulo)
                End If
            End If
            If cbDireccion.SelectedIndex <> -1 Then
                Call DatosDireccion()
            End If
        End If
    End Sub

    Private Sub CargarDirecciones()
        If cbProveedor.SelectedIndex <> -1 Then
            Dim direccion As String = cbDireccion.Text
            cbDireccion.Items.Clear()
            Dim lista As List(Of datosUbicacion) = funcUB.mostrarProv(cbProveedor.SelectedItem.itemdata, True, 0, 0, 1, 0, 0, 1)
            For Each dts As datosUbicacion In lista
                cbDireccion.Items.Add(New IDComboBox(dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
            Next
            If direccion.Length > 0 Then
                cbDireccion.Text = direccion
            End If
            If cbDireccion.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbDireccion.SelectedIndex = 0
                    CargarContactos()
                    Call DatosDireccion()
                Else
                    cbDireccion.Text = ""
                End If

            End If


        End If
    End Sub

    Private Sub DatosDireccion()
        dtsUB = funcUB.mostrar1(cbDireccion.SelectedItem.itemdata)
        If dtsUB.gPortes = "P" Then cbPortes.Text = "PAGADOS"
        If dtsUB.gPortes = "D" Then cbPortes.Text = "DEBIDOS"
        If dtsUB.gPortes = "I" Then
            cbPortes.Text = "INC.FRA."
            PrecioTransporte.Text = 0 'FormatNumber(funcALP.UltimoPrecioTransporte(iidProveedor), 2)
        End If

        If dtsUB.gidTransporte = 0 Then
            cbTransporte.Text = dtsUB.gTransporte
        Else
            cbTransporte.Text = dtsUB.gAgenciaTransporte
        End If
        Call CargarContactos()
    End Sub



    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Semaforo Then
            Me.Width = 1288
            Me.Height = If(Me.Height < 510, 510, Me.Height)


        End If
    End Sub

    Private Sub cbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted
        If Semaforo Then
            If cbFamilia.SelectedIndex > -1 Then
                iidFamilia = cbFamilia.SelectedItem.itemdata

                Call introducirSubFamilias()
                Call IntroducirArticulos()
            End If
        End If
    End Sub

    Private Sub cbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If cbSubFamilia.SelectedIndex > -1 Then
            iidsubFamilia = cbSubFamilia.SelectedItem.itemdata
            Call IntroducirArticulos()

        End If
    End Sub



    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            Call DatosDireccion()
            cambios = True
        End If
    End Sub

    Private Sub cbMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectionChangeCommitted
        If cbMoneda.SelectedIndex <> -1 Then
            lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            'Cambiar moneda en todo el documento
            Dim moneda As String = cbMoneda.Text
            If codMonedaI <> cbMoneda.SelectedItem.gcodMoneda Then
                Dim FechaCambio As Date = funcMO.CampoFecha(cbMoneda.SelectedItem.gcodMoneda)
                If FechaCambio <> dtpFecha.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)

                End If
                Dim codMonedaActual = cbMoneda.SelectedItem.gcodMoneda
                If G_AGeneral = "A" Then
                    'Si es un doc que ya existente
                    If MsgBox("El cambio de moneda quedará guardado en la base de datos. ¿Proceder con el cambio?", MsgBoxStyle.OkCancel) Then
                        funcALP.actualizaMoneda(numAlbaran.Text, codMonedaActual)
                        dtsALP.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
                        dtsALP.gDivisa = cbMoneda.SelectedItem.gdivisa
                        dtsALP.gSimbolo = cbMoneda.SelectedItem.gsimbolo
                        Dim listaC As List(Of DatosConceptoAlbaranProv) = funcCAP.mostrar(iidAlbaran)
                        For Each dts As DatosConceptoAlbaranProv In listaC
                            funcCAP.CambiarPrecio(dts.gidConcepto, 0, funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        If iidAlbaran > 0 Then Call CargarConceptosExistentes()
                        If inumPedido > 0 Then
                            ListaConceptos = funcCAP.mostrar(iidAlbaran)
                            Call CargarConceptosPropuesta()
                        End If

                        Call Recalcular()
                    End If
                Else
                    cbMoneda.Text = moneda
                End If
            End If
            cambios = True
        End If
    End Sub


    Private Sub lbMoneda1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMoneda1.TextChanged
        lbMoneda2.Text = lbMoneda1.Text
        lbMoneda3.Text = lbMoneda1.Text
        lbMoneda4.Text = lbMoneda1.Text
        lbMoneda5.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text
        lbMoneda6.Text = lbMoneda1.Text
    End Sub

    Private Sub numDoc1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDoc1.DoubleClick
        If numDoc1.Text <> "VARIOS" Then
            Dim GG As New GestionFacturaProv
            GG.SoloLectura = vSoloLectura
            GG.pidFactura = If(dtsALP.gFacturas Is Nothing OrElse dtsALP.gFacturas.Count = 0, 0, CInt(dtsALP.gFacturas(0).ItemData))
            GG.ShowDialog()
        End If
    End Sub


    Private Sub numDoc2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDoc2.DoubleClick
        If numDoc2.Text <> "VARIOS" Then
            Dim GG As New GestionPedidoProveedor
            GG.SoloLectura = vSoloLectura
            GG.pNumPedido = numDoc2.Text
            GG.ShowDialog()
        End If
    End Sub

    Private Sub CambiosEnCabecera(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsolicitadoVia.SelectedIndexChanged, numAlbaran.TextChanged _
     , Referencia.TextChanged, cbSolicitadoPor.SelectedIndexChanged, cbDireccion.SelectedIndexChanged, cbMoneda.SelectedIndexChanged _
     , Observaciones.TextChanged, Nota.TextChanged, cbContacto.SelectedIndexChanged, Bultos.TextChanged
        cambios = True
    End Sub

#End Region

    Private Sub ckSeleccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckSeleccion.CheckedChanged

    End Sub
End Class

  
   
 
