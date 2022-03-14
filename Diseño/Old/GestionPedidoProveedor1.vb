
Imports System.IO

Public Class GestionPedidoProveedor1

    Private cambios As Boolean = False
    Private vidConcepto As Integer
    Private lvIndice As Integer
    Private vCantidad As Double
    Private vPrecio As Double
    Private Semaforo As Boolean
    Private activarAlbaran As Boolean
    Private iidProveedor As Integer
    Private vfecha As Date
    'Private vRecibido As String
    Private vidUsuario As Integer
    Private TipoMP As Boolean
    Private ValidaPed As Boolean
    Private vEstado As String
    Private bRequiereValidar As Boolean
    Private esNuevo As Boolean
    Private EnvioCorreo As Boolean = False
    Private funcP As New funcionesProveedores
    Private funcPP As New FuncionesPedidosProv
    Private funcCP As New FuncionesConceptosPedidosProv
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
    Private DI As New DatosIniciales
    Private dtsPR As datosProveedor
    Private dtsPP As DatosPedidoProv
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
    Private Pedidos As List(Of Integer)
    'Dim Transporte.text As Double
    Private indiceL As Integer
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private estadoCabecera As DatosEstado
    Private estadoFinalizado As DatosEstado
    Private estadoEnCurso As DatosEstado
    Private estadoValidado As DatosEstado
    Private estadoStock As DatosEstado
    Private estadoStockParcial As DatosEstado
    Private estadoAnulado As DatosEstado
    Private estadoRealizado As DatosEstado
    Private estadoCRecibido As DatosEstado
    Private estadoCRecibidoParcial As DatosEstado
    Private estadoCEspera As DatosEstado
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private AvisadoProveedor As Boolean
    Private iidArticuloAvisado As Integer



    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Property pNumPedido() As Integer
        Get
            Return numPedido.Text
        End Get
        Set(ByVal value As Integer)
            numPedido.Text = value
        End Set
    End Property

    Property pPedidos() As List(Of Integer)
        Get
            Return Pedidos
        End Get
        Set(ByVal value As List(Of Integer))
            Pedidos = value
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


    Private Sub GestionPedidoProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Si le hemos pasado por Property que es sólo lectura, tiene prioridad, sino lo mira según el usuario
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
        ValidaPed = funcPE.campoValidaPedidosProv(vidUsuario)
        bGuardar.Enabled = Not vSoloLectura
        bBorrarConcepto.Enabled = Not vSoloLectura
        Call inicializar()
        Call inicializaConcepto()
        If numPedido.Text = "" Then numPedido.Text = 0
        If numPedido.Text = 0 Then
            Call Nuevo()
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            Me.Text = "EDITAR PEDIDO"
            gbConceptos.Enabled = True
            If Pedidos Is Nothing Then
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                If Pedidos.Count > 0 Then
                    bSubir.Visible = True
                    bBajar.Visible = True
                Else
                    bSubir.Visible = False
                    bBajar.Visible = False
                End If
            End If

            Call CargarPedido()

            G_AGeneral = "A"
        End If
        EstadoOriginal = cbEstado.Text
        Semaforo = True
    End Sub

    Private Sub GestionPedidoProveedor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If cbEstado.Text = estadoEnCurso.gEstado Then
            If MsgBox("El pedido no está FINALIZADO. ¿Desea salir?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else

            If Not e.Cancel Then
                If cambios Then
                    If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        e.Cancel = False
                        Call AvisoCorreo()
                    Else
                        e.Cancel = True
                    End If
                Else
                    e.Cancel = False
                    Call AvisoCorreo()
                End If
            End If
        End If
    End Sub





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
            'Estado PedidoProv
            estadoCabecera = funcES.EstadoPedidoProv("CABECERA")
            estadoFinalizado = funcES.EstadoPedidoProv("FINALIZADO")
            estadoEnCurso = funcES.EstadoPedidoProv("EN CURSO")
            estadoValidado = funcES.EstadoPedidoProv("VALIDADO")
            estadoStock = funcES.EstadoPedidoProv("STOCK")
            estadoStockParcial = funcES.EstadoPedidoProv("STOCK PARCIAL")
            estadoAnulado = funcES.EstadoPedidoProv("ANULADO")
            estadoRealizado = funcES.EstadoPedidoProv("REALIZADO")
            'Estados conceptos
            estadoCRecibido = funcES.EstadoCPedidoProv("RECIBIDO")
            estadoCRecibidoParcial = funcES.EstadoCPedidoProv("RECIBIDO PARCIAL")
            estadoCEspera = funcES.EstadoCPedidoProv("ESPERA")
            Dim tip As New ToolTip
            tip.SetToolTip(BBuscarProducto, "Búsqueda de Producto")

            'bGuardarConcepto.Text = "GUARDAR"

            With lvConceptos
                .View = View.Details
                ' al seleccionar un elemento, seleccionar la línea completa
                .FullRowSelect = True
                ' Mostrar las líneas de la cuadrícula
                .GridLines = True
                ' No permitir múltiple selección
                .MultiSelect = False
                ' Para que al perder el foco,
                ' se siga viendo el que está seleccionado
                .HideSelection = False
            End With
            ' inicializaConcepto()
            cambios = False
            'semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub inicializaConcepto()
        Dim semaforo0 As Boolean = Semaforo
        Semaforo = False
        cbcodArticulo.Text = ""
        cbcodArticuloProv.Text = ""

        Cantidad.Text = 0
        cbNombre.Text = ""

        Precio.Text = 0
        totalConcepto.Text = 0

        vidConcepto = 0
        lvIndice = -1
        vCantidad = 0
        vPrecio = 0
        iidArticulo = 0
        Recibido = False
        CantidadRecibida = 0
        lbUnidad.Text = "u."
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
        cbNombre.Items.Clear()
        cbNombre.SelectedIndex = -1
        DescuentoC.Text = 0
        dtpFechaPrevistaC.Value = dtpFechaEntrega.Value
        Call IntroducirArticulos()
       
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
        iidArticuloAvisado = 0
        Semaforo = semaforo0


    End Sub




    Private Sub IntroducirArticulos()
        cbcodArticulo.Items.Clear()
        cbcodArticulo.Text = ""
        cbNombre.Items.Clear()
        cbNombre.Text = ""
        cbcodArticuloProv.Items.Clear()
        cbcodArticuloProv.Text = ""
        iidArticulo = 0

        Dim lista As List(Of DatosArticuloProveedor) = funcAP.Mostrar(iidProveedor, 0, iidFamilia, iidsubFamilia, "Articulo", True)
        Dim dts As DatosArticuloProveedor
        For Each dts In lista
            If dts.gcodArticulo <> "" Then cbcodArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticulo, dts.gidArticuloProv))
            If dts.gNombre <> "" Then cbNombre.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gNombre, dts.gidArticuloProv))
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
        End Try
    End Sub



#End Region


#Region "CARGAR DATOS"

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
            Me.Text = "NUEVO PEDIDO PROVEEDOR"
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
            dtpFechaPedido.Value = Date.Today
            dtpFechaEntrega.Value = Date.Today
            vfecha = dtpFechaPedido.Value
            'observacionesProv.Text = ""
            Observaciones.Text = ""
            pedidoProveedor.Text = ""
            Nota.Text = ""
            HorarioEntrega.Text = ""
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
            Dim funcMOA As New Master()
            numPedido.Text = funcMOA.leernumPedidoProv(dtpFechaPedido.Value.Year) + 1  'Este número puede no ser el definitivo, se cargará de forma efectiva desde la función correspondiente de funcionesFraProveedor
            If numPedido.Text = 0 Then
                funcMOA.NuevoAño()
                numPedido.Text = funcMOA.leernumPedido(Now.Year) + 1
                If numPedido.Text = 0 Then
                    MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                    Me.Close()
                End If
            End If
            cbTipoIVA.Text = DI.TipoIVA.ToString
            cbEstado.Items.Clear()
            cbEstado.Items.Add(funcES.EstadoPedidoProv("CABECERA"))
            cbEstado.SelectedIndex = 0

            dtsPP = New DatosPedidoProv
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarPedido()
        esNuevo = False
        Me.Text = "EDITAR PEDIDO PROVEEDOR"

        G_AGeneral = "A"
        Dim Semaforo0 As Boolean = Semaforo
        Call CargarDatosPedidoProv(numPedido.Text)
        Semaforo = False
        'Call CargarDatosProv()
        codMonedaI = dtsPP.gcodMoneda
        Semaforo = Semaforo0
        Call inicializaConcepto()
        vfecha = dtpFechaPedido.Value


        If CargarDatosConceptos(numPedido.Text) > 0 Then
            '  bNuevoConcepto.Enabled = True
        Else
            ' bNuevoConcepto.Enabled = False
        End If
        Dim dtsES As DatosEstado = funcES.Mostrar1(dtsPP.gidEstado)
        If dtsES.gCabecera Then
            cbEstado.Items.Add(estadoCabecera)
            cbEstado.Items.Add(estadoAnulado)
            gbConceptos.Enabled = False
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
        Else
            cbCodProveedor.Enabled = False
            cbProveedor.Enabled = False
            bBuscarProveedor.Enabled = False
        End If
        If dtsES.gEnCurso And Not dtsES.gEspera Then 'En CURSO
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
            cbEstado.Items.Add(estadoEnCurso)
            cbEstado.Items.Add(estadoFinalizado)
            If ValidaPed Then
                cbEstado.Items.Add(estadoValidado)
            End If
            cbEstado.Items.Add(estadoAnulado)
        End If
        If dtsES.gEspera And Not dtsES.gEnCurso Then 'FINALIZADO
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
            cbEstado.Items.Add(estadoFinalizado)
            If ValidaPed Then
                cbEstado.Items.Add(estadoValidado)
            End If
            cbEstado.Items.Add(estadoAnulado)
        End If
        If dtsES.gEspera And dtsES.gEnCurso Then 'VALIDADO
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
            cbEstado.Items.Add(estadoValidado)
            cbEstado.Items.Add(estadoRealizado)
            If ValidaPed Then
                cbEstado.Items.Add(estadoEnCurso)
                cbEstado.Items.Add(estadoAnulado)
                gbConceptos.Enabled = False
            Else
                gbConceptos.Enabled = False
            End If

        End If
        If dtsES.gTraspasado Then 'REALIZADO
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
            cbEstado.Items.Add(estadoRealizado)
            If ValidaPed Then
                cbEstado.Items.Add(estadoAnulado)
            End If
            gbConceptos.Enabled = False
        End If
        If dtsES.gEntregado And dtsES.gCompleto And dtsES.gBloqueado Then 'STOCK
            cbEstado.Items.Add(estadoStock)
            If ValidaPed Then
                cbEstado.Items.Add(estadoAnulado)
            End If
            gbConceptos.Enabled = False
            bGuardar.Enabled = Not vSoloLectura 'Para poder guardar cambios en Observaciones
            bRecepcion.Enabled = True
            bBorrarConcepto.Enabled = False

        End If
        If dtsES.gEntregado And Not dtsES.gCompleto And Not dtsES.gBloqueado Then 'STOCK PARCIAL
            cbEstado.Items.Add(estadoStockParcial)
            If ValidaPed Then
                cbEstado.Items.Add(estadoAnulado)
            End If
        End If
        If dtsES.gBloqueado And dtsES.gAnulado Then 'ANULADO
            cbEstado.Items.Add(estadoAnulado)
            If ValidaPed Then
                cbEstado.Items.Add(estadoValidado)
            End If
        End If
        cbEstado.Text = dtsES.gEstado

        cambios = False
    End Sub


    Private Sub CargarDatosPedidoProv(ByVal vNumPedido As Integer)
        ' Carga de datos de la linea del pedido a proveedor desde la tabla
        Try
            ep1.Clear()
            ep2.Clear()
            dtsPP = funcPP.Mostrar1(vNumPedido)

            codMonedaI = dtsPP.gcodMoneda
            vfecha = dtsPP.gFechaPedido.Date
            pedidoProveedor.Text = dtsPP.gPedidoProveedor
            dtpFechaPedido.Value = dtsPP.gFechaPedido
            dtpFechaEntrega.Value = dtsPP.gFechaEntrega
            cbSolicitadoPor.Text = dtsPP.gPersona
            cbContacto.Text = dtsPP.gContacto
            cbsolicitadoVia.Text = dtsPP.gSolicitadoVia
            Dim vcp As String = ""
            iidProveedor = dtsPP.gidProveedor
            cbProveedor.Text = dtsPP.gProveedor
            cbCodProveedor.Text = dtsPP.gcodProveedor
            iidUbicacion = dtsPP.gidUbicacion
            Call CargarDirecciones()
            cbDireccion.Text = dtsPP.gDireccion
            If cbDireccion.SelectedIndex = -1 Then
                ep2.SetError(cbDireccion, "Dirección no válida")
            Else
                dtsUB = funcUB.mostrar1(dtsPP.gidUbicacion)
            End If
            cbTipoIVA.Text = dtsPP.gNombreTipoIVA & " " & dtsPP.gTipoIVA & "%"
            vEstado = dtsPP.gEstado
            cbEstado.Text = dtsPP.gEstado

            ckPagado.Checked = dtsPP.gPagado
            BaseImponible.Text = FormatNumber(dtsPP.gBase, 2)
            TotalIVA.Text = FormatNumber(dtsPP.gTotalIVA, 2)
            TotalPedido.Text = FormatNumber(dtsPP.gTotal, 2)
            Retencion.Text = FormatNumber(dtsPP.gRetencion, 2)
            Observaciones.Text = dtsPP.gObservaciones
            Nota.Text = dtsPP.gNotas
            HorarioEntrega.Text = dtsPP.gHorarioEntrega
            vMoneda = dtsPP.gcodMoneda
            cbMoneda.Text = dtsPP.gDivisa
            cbValorado.Text = dtsPP.gTipoValorado
            Descuento.Text = FormatNumber(dtsPP.gDescuento, 2)
            'PrecioTransporte.Text = FormatNumber(dtsPP.gPrecioTransporte, 2)
            If dtsPP.gPortes = "P" Then
                cbPortes.Text = "PAGADOS"
                PrecioTransporte.Text = 0
            End If
            If dtsPP.gPortes = "D" Then
                cbPortes.Text = "DEBIDOS"
                PrecioTransporte.Text = 0
            End If
            If dtsPP.gPortes = "I" Then
                cbPortes.Text = "INC.FRA."
                PrecioTransporte.Text = FormatNumber(dtsPP.gPrecioTransporte, 2)
            End If
            If dtsPP.gidTransporte > 0 Then
                cbTransporte.Text = dtsPP.gAgenciaTransporte
            Else
                cbTransporte.Text = dtsPP.gTransporte
            End If

            'TipoMP = False 'funcP.campoMP(iidProveedor)

            cbcodArticulo.Items.Clear()
            lbUnidad.Text = "U."
            iidPersona = dtsPP.gidPersona
            lbMoneda1.Text = dtsPP.gSimbolo 'funcMO.CampoSimbolo(vMoneda)
            'lbMoneda2.Text = lbMoneda1.Text
            'lbMoneda3.Text = lbMoneda1.Text
            'lbmonedaT.Text = lbMoneda1.Text
            'lbMoneda4.Text = lbMoneda1.Text
            'lbMoneda5.Text = lbMoneda1.Text
            Call IntroducirArticulos()
            cambios = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub




    Function CargarDatosConceptos(ByVal vNumPedido As Integer) As Integer
        ' Carga de datos de conceptos correspondientes al Pedido
        Dim contador As Integer = 0
        Try
            Semaforo = False

            lvConceptos.Items.Clear()
            funcCP.RenumerarSiEsNecesario(vNumPedido)
            Dim lista As List(Of DatosConceptoPedidoProv) = funcCP.mostrar(vNumPedido)
            Dim dts As DatosConceptoPedidoProv
            For Each dts In lista
                lvConceptosNuevaLinea(dts)
                Semaforo = False
                lvConceptos.Refresh()
                contador = contador + 1
            Next

            If contador > 0 Then
                'bNuevoConcepto.Enabled = True

                ' Recalcular()
            Else
                ' bNuevoConcepto.Enabled = False

            End If

            Call inicializaConcepto()
            Semaforo = True

            Return contador

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub guardar()

        ' Guarda todos los datos del Pedido cuando es nuevo
        Try

            Dim resultado As Integer = funcPP.insertar(dtsPP)
            If resultado = -1 Then
                'no se ha insertado
                MsgBox("Año no válido", MsgBoxStyle.OkOnly)
                dtpFechaPedido.Value = Date.Now
            Else

                MsgBox("Pedido a proveedor guardado con el número " & resultado)
                numPedido.Text = resultado
                'A partir de este punto es como si editaramos un Pedido existente
                Dim titulo As String = funcTC.Tipo(iidTipoCompra)
                Me.Text = "EDITAR PEDIDO PROVEEDOR " & UCase(titulo)
                'bGuardar.Text = "ACTUALIZAR"
                G_AGeneral = "A"
                vfecha = dtpFechaPedido.Value
            End If

            cambios = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub actualizar()
        'Actualiza los datos de la EN CURSO del Pedido
        Try

            funcCP.CambiarIVA(dtsPP)
            If funcPP.actualizar(dtsPP) Then
                If cbNombre.Text = "" Then MsgBox("Pedido actualizado correctamente")
            End If
            cambios = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub actualizaPrecioTotal()
        ' Recalcula el precio total
        Dim vTotal As Double

        vTotal = vCantidad * vPrecio

        totalConcepto.Text = FormatNumber(vTotal, 2)
    End Sub




    Private Sub lvConceptosNuevaLinea(ByVal dts As DatosConceptoPedidoProv)
        'Añade una linea al ListView lvConceptos
        With lvConceptos.Items.Add(dts.gidConcepto)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gcodArticuloProv)
            .SubItems.Add(dts.gArticuloProv)
            .SubItems.Add(dts.gFechaPrevista)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(FormatNumber(dts.gCantidadRecibida, 2) & dts.gTipoUnidad)
            .SubItems.Add(FormatNumber(dts.gPrecioNetoUnitario, If(dts.gPrecioNetoUnitario >= 5, 4, 6)))
            .SubItems.Add(FormatNumber(dts.gDescuento, 2) & "%")
            .SubItems.Add(FormatNumber(dts.gTotalConcepto, 2))
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(dts.gidEstado)
            If dts.gidEstado = estadoCRecibido.gidEstado Then 'dts.gRecibido Or dts.gCantidad <= dts.gCantidadRecibida Then
                .ForeColor = Color.Green
            Else
                If dts.gidEstado = estadoCRecibidoParcial.gidEstado Then 'dts.gCantidadRecibida > 0 And dts.gCantidad > dts.gCantidadRecibida Then
                    .ForeColor = Color.Red
                Else
                    .ForeColor = Color.Black
                End If

            End If

        End With
        'inicializaConcepto()

    End Sub



    Private Sub Recalcular()
        funcPP.DatosCalculados(dtsPP) 'Recargamos el dtsOF por referencia
        Retencion.Text = FormatNumber(dtsPP.gRetencion, 2)
        BaseImponible.Text = FormatNumber(dtsPP.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsPP.gTotalIVA, 2)
        TotalPedido.Text = FormatNumber(dtsPP.gTotal, 2)
    End Sub


    Private Function cargaConcepto() As DatosConceptoPedidoProv
        'Carga los datos de la zona de edición en un dts de ConceptoPedidoProv

        Dim dts As New DatosConceptoPedidoProv
        If Cantidad.Text = "" Then Cantidad.Text = 0
        If DescuentoC.Text = "" Then DescuentoC.Text = 0
        dts.gidConcepto = vidConcepto
        dts.gnumPedido = numPedido.Text
        dts.gCantidad = Cantidad.Text
        dts.gDescuento = DescuentoC.Text
        dts.gArticuloProv = cbNombre.Text
        dts.gidArticuloProv = If(cbNombre.SelectedIndex = -1, 0, cbNombre.SelectedItem.itemdata)
        dts.gidArticulo = iidArticulo
        dts.gcodArticulo = cbcodArticulo.Text
        dts.gcodArticuloProv = cbcodArticuloProv.Text
        dts.gRecibido = Recibido
        dts.gCantidadRecibida = CantidadRecibida
        dts.gAceptado = True 'Not ckRechazado.Checked
        dts.gFechaPrevista = dtpFechaPrevistaC.Value.Date
        dts.gFechaRecibido = Now.Date 'dtpFechaRecepConcepto.Value
        dts.gPrecioNetoUnitario = Precio.Text
        dts.gTotalConcepto = totalConcepto.Text
        dts.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
        dts.gTipoIVA = cbTipoIVA.SelectedItem.gtipoIVA
        Return dts

    End Function


    Private Sub GuardarConcepto()
        'Guarda o actualiza los datos de un concepto

        If cbNombre.Text <> "" And Cantidad.Text <> "" Then   'solo actua si hay alguna información en la zona de edición
            EnvioCorreo = Not vSoloLectura
            Dim resultado As Integer
            Try
                Dim dts As DatosConceptoPedidoProv
                dts = cargaConcepto()

                If lvIndice = -1 Then
                    dts.gidEstado = estadoCEspera.gidEstado
                    dts.gEstado = estadoCEspera.gEstado

                    resultado = funcCP.insertar(dts)
                    dts.gidConcepto = resultado

                    lvConceptosNuevaLinea(dts)
                Else   'Si el botón dice ACTUALIZAR
                    'Primero detectamos si la cantidad recibida es menor que la pedida (con la zona de recepción activada)

                    If dts.gCantidad <= dts.gCantidadRecibida Then
                        dts.gidEstado = estadoCRecibido.gidEstado
                        dts.gEstado = estadoCRecibido.gidEstado
                        dts.gRecibido = True
                    Else
                        If dts.gCantidadRecibida > 0 And dts.gCantidad > dts.gCantidadRecibida Then
                            dts.gidEstado = estadoCRecibidoParcial.gidEstado
                            dts.gEstado = estadoCRecibidoParcial.gEstado
                        Else
                            dts.gidEstado = estadoCEspera.gidEstado
                            dts.gEstado = estadoCEspera.gidEstado
                        End If
                        dts.gRecibido = False
                    End If
                    funcCP.actualizar(dts)
                    Call ActualizarLineaLV(dts)

                End If
                If iidArticulo > 0 Then
                    'Articulo-Proveedor
                    Dim dtsAP As New DatosArticuloProveedor
                    dtsAP.gActivo = True
                    dtsAP.gidArticuloProv = dts.gidArticuloProv
                    dtsAP.gidArticulo = iidArticulo
                    dtsAP.gidProveedor = iidProveedor
                    dtsAP.gNombre = dts.gArticuloProv
                    dtsAP.gPrecio = dts.gPrecioNetoUnitario
                    dtsAP.gcodMoneda = dtsPP.gcodMoneda
                    dtsAP.gFechaPrecio = dtsPP.gFechaPedido
                    dtsAP.gcodArticuloProv = cbcodArticuloProv.Text
                    dtsAP.gPrecioUnitario = 0

                    If dts.gidArticuloProv = 0 Then
                        dts.gidArticuloProv = funcAP.Guardar(dtsAP)
                    Else
                        funcAP.actualizar(dtsAP)
                    End If

                    If funcAR.idProveedor(iidArticulo) = 0 Then
                        If MsgBox("¿Desea establecer " & cbProveedor.Text & " como proveedor habitual de " & funcAR.Articulo(iidArticulo) & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            funcAR.actualizarProveedor(iidArticulo, iidProveedor)
                        End If
                    End If
                    'Actualizar el precio del artículo
                    'Guardamos los datos que identifican el precio como "Procedente del último pedido"
                    Dim dtsAE As New DatosArticuloPrecio
                    dtsAE.gidArticulo = dts.gidArticulo
                    dtsAE.gFechaPrecio = dtpFechaPedido.Value.Date

                    dtsAE.gcodMoneda = dtsPP.gcodMoneda
                    dtsAE.gidProveedorPrecio = dtsPP.gidProveedor
                    dtsAE.gidConcepto = dts.gidConcepto
                    dtsAE.gPrecio = funcAP.Precio(dts.gidArticuloProv)
                    dtsAE.gTipoPrecio = "C"
                    dtsAE.gActivo = True
                    dtsAE.gDescuento = 0
                    dtsAE.gidClientePrecio = 0
                    funcAE.ActualizarH(dtsAE)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoPedidoProv)
        With lvConceptos.Items(lvIndice)
            .SubItems(1).Text = dts.gcodArticulo
            .SubItems(2).Text = dts.gcodArticuloProv
            .SubItems(3).Text = dts.gArticuloProv
            .SubItems(4).Text = dts.gFechaPrevista
            .SubItems(5).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
            .SubItems(6).Text = FormatNumber(dts.gCantidadRecibida, 2) & dts.gTipoUnidad
            .SubItems(7).Text = FormatNumber(dts.gPrecioNetoUnitario, If(dts.gPrecioNetoUnitario >= 5, 4, 6))
            .SubItems(8).Text = FormatNumber(dts.gDescuento, 2) & "%"
            .SubItems(9).Text = FormatNumber(dts.gTotalConcepto, 2)

            .SubItems(10).Text = dts.gidArticulo
            .SubItems(11).Text = dts.gidEstado
            If dts.gRecibido Or dts.gCantidad <= dts.gCantidadRecibida Then
                .ForeColor = Color.Green
            Else
                If dts.gCantidadRecibida > 0 And dts.gCantidad > dts.gCantidadRecibida Then
                    .ForeColor = Color.Red
                Else
                    .ForeColor = Color.Black
                End If
            End If
        End With

    End Sub




    Private Sub CalculaEstado()

        If lvConceptos.Items.Count = 0 Then
            'Si no hay conceptos --> CABECERA
            'Dim x As Integer = cbEstado.FindString(estadoCabecera.gEstado)
            cbEstado.Items.Clear()
            cbEstado.Items.Add(estadoCabecera)
            cbEstado.Items.Add(estadoAnulado)
            funcPP.actualizaEstado(numPedido.Text, estadoCabecera.gidEstado)
            cbEstado.Text = estadoCabecera.gEstado
            gbConceptos.Enabled = False
            cbCodProveedor.Enabled = True
            cbProveedor.Enabled = True
            bBuscarProveedor.Enabled = True
        Else
            cbCodProveedor.Enabled = False
            cbProveedor.Enabled = False
            bBuscarProveedor.Enabled = False
            Dim AlgoRecibido As Boolean = False
            Dim TodoRecibido As Boolean = True
            For Each item As ListViewItem In lvConceptos.Items
                Select Case item.SubItems(11).Text
                    Case estadoCEspera.gidEstado
                        TodoRecibido = False
                    Case estadoCRecibido.gidEstado
                        AlgoRecibido = True
                        TodoRecibido = TodoRecibido And True
                    Case estadoCRecibidoParcial.gidEstado
                        AlgoRecibido = True
                        TodoRecibido = False
                    Case Else
                        TodoRecibido = False
                End Select
            Next

            If TodoRecibido Then
                'Todo Recibido --> STOCK
                cbEstado.Items.Clear()
                cbEstado.Items.Add(estadoStock)
                cbEstado.SelectedIndex = 0
                funcPP.actualizaEstado(numPedido.Text, estadoStock.gidEstado)
            ElseIf AlgoRecibido Then
                'Algo recibido --> STOCK PARCIAL
                cbEstado.Items.Clear()
                cbEstado.Items.Add(estadoStockParcial)
                cbEstado.SelectedIndex = 0
                funcPP.actualizaEstado(numPedido.Text, estadoStockParcial.gidEstado)
            Else
                cbCodProveedor.Enabled = True
                cbProveedor.Enabled = True
                bBuscarProveedor.Enabled = True
                If cbEstado.SelectedItem.gidEstado = estadoCabecera.gidEstado Then
                    'Si estaba en estado Cabecera --> EN CURSO
                    cbEstado.Items.Clear()
                    cbEstado.Items.Add(estadoEnCurso)
                    cbEstado.Items.Add(estadoAnulado)
                    cbEstado.Items.Add(estadoFinalizado)
                    If ValidaPed Then
                        cbEstado.Items.Add(estadoValidado)
                    End If
                    cbEstado.Text = estadoEnCurso.gEstado
                    funcPP.actualizaEstado(numPedido.Text, estadoEnCurso.gidEstado)
                Else
                    'En otro caso, no tocamos
                End If
            End If

        End If


    End Sub



    Private Sub AvisoCorreo()
        If EnvioCorreo And cbEstado.SelectedIndex <> -1 Then
            If cbEstado.SelectedItem.gidEstado = estadoFinalizado.gidEstado And bRequiereValidar Then  'Si es un proveedor de materias primas no requiere validación
                Dim Texto As String = ""
                'Dim funcU As New FuncionesPersonal
                Dim Remitente As String = funcPE.campoNombreyApellidos(vidUsuario)
                'Dim funcP As New funcionesProveedores
                If esNuevo Then
                    Texto = "El usuario " & Remitente & " ha creado el pedido " & numPedido.Text & " al proveedor " & cbProveedor.Text & ". " & vbCrLf & "El pedido se encuentra a la espera de validación." & vbCrLf & vbCrLf
                Else
                    Texto = "El usuario " & Remitente & " ha modificado el pedido " & numPedido.Text & " al proveedor " & cbProveedor.Text & ". " & vbCrLf & "El pedido se encuentra a la espera de validación." & vbCrLf & vbCrLf
                End If
                MsgBox("El pedido queda a la espera de validación")
                If ValidaPed Then
                Else
                    Dim funcMOL As New FuncionesMails
                    Dim destinatario As String = funcMOL.MostrarTipoCompraStr(iidTipoCompra)
                    If destinatario <> "" Then
                        correo("Pedido a proveedor pendiente de validación.", Texto, Remitente, destinatario, "")
                    Else
                        MsgBox("No hay destinatario de correo definido para validación")
                    End If
                End If
            End If
        End If
        If EnvioCorreoVal Then
            'Si el pedido ha cambiado de estado
            Dim Texto As String = ""
            'Dim funcU As New FuncionesPersonal
            Dim Remitente As String = funcPE.campoNombreyApellidos(vidUsuario)
            'Dim funcP As New funcionproveedor
            'If esNuevo Then
            'Else
            Texto = "El usuario " & Remitente & " ha cambiado el estado a " & cbEstado.Text & " del pedido " & numPedido.Text & " del proveedor " & cbProveedor.Text & "." & vbCrLf & vbCrLf

            'End If

            If ValidaPed And iidPersona <> vidUsuario Then
                'Dim funcPer As New FuncionesPersonal
                Dim destinatario As String = funcMOA.MostrarContactoStr(funcPE.campoidContacto(iidPersona)) 'funcPE.campoCorreo(iidPersona)
                If destinatario <> "" Then
                    If correo("Cambio a " & cbEstado.Text & " del Pedido " & numPedido.Text & " del proveedor " & cbProveedor.Text & ".", Texto, Remitente, destinatario, "") Then
                        MsgBox("Se ha enviado un mensaje a " & funcPE.campoNombreyApellidos(iidPersona) & " informando del cambio de estado.")
                    End If
                End If

            End If

        End If


    End Sub





#End Region




#Region "BOTONES GENERALES"

    '**************BOTONES EN CURSO


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Dim Texto As String = ""
        ep1.Clear()
        ep2.Clear()
        Dim AnulaPedidoRecibido As Boolean = False
        Dim Remitente As String = funcPE.campoNombreyApellidos(vidUsuario)
        Dim validar As Boolean = True
        If cbProveedor.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbProveedor, "Se ha de seleccionar un proveedor")
        End If
        If cbSolicitadoPor.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbSolicitadoPor, "Se ha de especificar la persona")
        End If
        If cbTipoIVA.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbTipoIVA, "Se ha de seleccionar el tipo de IVA")
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
        Else
            If cbEstado.SelectedItem.gidEstado = estadoAnulado.gidEstado And (EstadoOriginal = estadoStock.gEstado Or EstadoOriginal = estadoStockParcial.gEstado) Then
                If ValidaPed Then
                    If MsgBox("¿Desea anular el pedido recibido y retirar del stock las cantidades recibidas?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        AnulaPedidoRecibido = True
                    End If
                Else
                    ep1.SetError(cbEstado, "No se puede anular un pedido recibido")
                    validar = False
                End If
            End If
        End If
        If cbValorado.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbValorado, "Se ha de seleccionar cómo está valorado el pedido")
        End If

        If validar Then
            If dtsPR Is Nothing Then
                'Si no hemos cargado antes los datos del proveedor, lo hacemos ahora
                dtsPR = funcP.mostrar1(cbProveedor.SelectedItem.itemdata)
                iidProveedor = dtsPR.gidProveedor
                dtsFA = funcFF.mostrarProv(iidProveedor)
            End If
            If lvConceptos.Items.Count = 0 And cbEstado.SelectedItem.gidestado <> estadoAnulado.gidEstado Then
                cbEstado.Items.Clear()
                cbEstado.Items.Add(estadoCabecera)
                cbEstado.Items.Add(estadoAnulado)
                cbEstado.Text = estadoCabecera.gEstado
            End If
            If numPedido.Text = "" Then
                dtsPP.gnumPedido = 0
            Else
                dtsPP.gnumPedido = numPedido.Text
            End If
            dtsPP.gidProveedor = cbProveedor.SelectedItem.ItemData
            dtsPP.gPedidoProveedor = pedidoProveedor.Text
            dtsPP.gSolicitadoVia = cbsolicitadoVia.Text
            dtsPP.gidUbicacion = cbDireccion.SelectedItem.itemdata
            dtsPP.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
            dtsPP.gObservaciones = Observaciones.Text
            dtsPP.gFechaPedido = dtpFechaPedido.Value
            dtsPP.gFechaEntrega = dtpFechaEntrega.Value
            dtsPP.gidTipoCompra = dtsPR.gIdTipoCompra
            dtsPP.gHorarioEntrega = HorarioEntrega.Text
            dtsPP.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda
            dtsPP.gidPersona = cbSolicitadoPor.SelectedItem.itemdata
            dtsPP.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
            dtsPP.gPersona = cbSolicitadoPor.Text
            If cbPortes.Text = "PAGADOS" Then
                dtsPP.gPortes = "P"
            ElseIf cbPortes.Text = "DEBIDOS" Then
                dtsPP.gPortes = "D"
            Else
                dtsPP.gPortes = "I"
            End If
            If cbTransporte.SelectedIndex = -1 Then
                dtsPP.gidTransporte = 0
                dtsPP.gTransporte = cbTransporte.Text
            Else
                If cbTransporte.SelectedItem.itemdata < 1 Then
                    dtsPP.gidTransporte = 0
                    dtsPP.gTransporte = cbTransporte.Text
                Else
                    dtsPP.gidTransporte = cbTransporte.SelectedItem.itemData
                    dtsPP.gTransporte = ""
                End If
            End If
            If Descuento.Text = "" Then Descuento.Text = 0
            dtsPP.gDescuento = Descuento.Text
            dtsPP.gPagado = ckPagado.Checked
            dtsPP.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
            dtsPP.gNotas = Nota.Text
            dtsPP.gidEstado = cbEstado.SelectedItem.gidEstado
            dtsPP.gEstado = cbEstado.Text

            dtsPP.gTipoIVAFac = cbTipoIVA.SelectedItem.gtipoIVA
            dtsPP.gTipoIVA = cbTipoIVA.SelectedItem.gtipoIVA
            dtsPP.gidTipoRetencion = dtsFA.gidTipoRetencion
            dtsPP.gTipoRetencion = dtsFA.gTipoRetencion
            dtsPP.gTipoRetencionFac = dtsFA.gTipoRetencion
            If PrecioTransporte.Text = "" Then PrecioTransporte.Text = 0
            dtsPP.gPrecioTransporte = PrecioTransporte.Text

            If G_AGeneral = "G" Then
                Call guardar()
                EnvioCorreo = Not vSoloLectura
                EnvioCorreoVal = False
                Call IntroducirArticulos()
            ElseIf G_AGeneral = "A" Then
                If cambios Then
                    Call actualizar()
                    EnvioCorreo = Not vSoloLectura
                    EnvioCorreoVal = (cbEstado.Text <> EstadoOriginal)
                End If
            End If

            If cbNombre.Text <> "" Then

                If ValidaPed Then
                    'Si es validador puede añadir o modificar lineas si no está en stock
                    If dtsPP.gidEstado <> estadoStock.gidEstado Then
                        Call GuardarConcepto()
                    Else
                        MsgBox("No se puede modifcar un pedido totalmente recibido")
                    End If
                Else
                    'Si no es validador sólo puede añadir o modificar lineas en estado CABECERA, EN CURSO y FINALIZADO
                    If dtsPP.gidEstado = estadoCabecera.gidEstado Or dtsPP.gidEstado = estadoEnCurso.gidEstado Or dtsPP.gidEstado = estadoFinalizado.gidEstado Then
                        Call GuardarConcepto()
                    Else
                        MsgBox("No dispone de permisos para modificar este pedido")
                    End If

                End If



            End If
            If AnulaPedidoRecibido Then
                'Hemos guardado un pedido en estado anulado que estaba en STOCK o STOCK PARCIAL
                'Vamos a descontar el stock recibido
                Dim listaC As List(Of DatosConceptoPedidoProv) = funcCP.mostrar(numPedido.Text)
                Dim dtsS As DatosStock
                For Each dtsC As DatosConceptoPedidoProv In listaC
                    If dtsC.gCantidadRecibida <> 0 Then
                        dtsS = New DatosStock
                        dtsS.gCantidad = -dtsC.gCantidadRecibida
                        dtsS.gcodMoneda = dtsC.gcodMoneda
                        dtsS.gFecha = Now
                        dtsS.gidAlmacen = 0
                        dtsS.gidArticulo = dtsC.gidArticulo
                        dtsS.gidArticuloProv = dtsC.gidArticuloProv
                        dtsS.gidConceptoProv = dtsC.gidConcepto
                        dtsS.gidConceptoAlbaran = 0
                        dtsS.gidConceptoPedido = 0
                        dtsS.gidProduccion = 0
                        dtsS.gidLote = 0
                        dtsS.gidUnidad = dtsC.gidUnidad
                        dtsS.gnumPedidoProv = dtsC.gnumPedido
                        dtsS.gPrecio = dtsC.gPrecioNetoUnitario
                        dtsS.gMovimiento = "Anulación pedido Proveedor " & dtsC.gnumPedido
                        dtsS.gidPersona1 = Inicio.vIdUsuario
                        dtsS.gidPersona2 = 0
                        funcST.insertar(dtsS)
                        'Y borrar la cantidad recibida
                        dtsC.gCantidadRecibida = 0
                        dtsC.gRecibido = False
                        dtsC.gidEstado = estadoCEspera.gidEstado
                        funcCP.actualizarRecepcion(dtsC)
                    End If
                Next


            End If

            Call Recalcular()
            If dtsPP.gidEstado <> estadoAnulado.gidEstado Then
                Call CalculaEstado()
            End If
            Call inicializaConcepto()
            gbConceptos.Enabled = G_AGeneral = "A" And cbEstado.SelectedItem.gidEstado <> estadoStock.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoAnulado.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoValidado.gidEstado

        End If


        'gbConceptos.Enabled = G_AGeneral = "A" And (cbEstado.Text <> "STOCK" And cbEstado.Text <> "ANULADO" And cbEstado.Text <> "FINALIZADO" And (cbEstado.Text <> "VALIDADO")) ' Or ValidaPed))

    End Sub




    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If MsgBox("¿Desea borrar el pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            If funcCP.borrarPedidoProv(numPedido.Text) Then

                If funcPP.borrar(numPedido.Text) = 1 Then
                    'Ha borrado correctamente. Ahora se reinicia como un nuevo Pedido

                    Call inicializar()
                Else
                    MsgBox("Error al borrar el Pedido. Consulte al administrador")
                End If
            Else
                MsgBox("Error al borrar el Pedido. Consulte al administrador")
            End If
        End If

    End Sub



    'Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
    '    If G_AGeneral = "G" Then
    '        MsgBox("Aún no se ha guardado el pedido")
    '    ElseIf lvConceptos.Items.Count = 0 Then
    '        MsgBox("No se han introducido conceptos")
    '    Else
    '        InformePedidoProv.verInforme(numPedido.Text, GestionPedidoProveedor.parcialactivado, GestionPedidoProveedor.parcialtext, funcUB.campoIdioma(iidUbicacion), False)
    '        InformePedidoProv.ShowDialog()

    '    End If
    'End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click

        If cbNombre.Text <> "" Then
            Call inicializaConcepto()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará un nuev pedido. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    'Call InicializaGeneral()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará un nuevo pedido. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    'Call InicializarGeneral()
                    Call Nuevo()
                End If
            End If
        End If
    End Sub


    Private Sub bEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEmail.Click

        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el pedido")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        ElseIf cbDireccion.SelectedIndex = -1 Then
            MsgBox("No hay una dirección seleccionada válida")
        Else
            Dim fichero As String = "PedidoProv SV " & Trim(numPedido.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()

            If cbEstado.SelectedIndex <> -1 Then
                If cbEstado.SelectedItem.gidEstado = estadoEnCurso.gidEstado Then
                    If MsgBox("¿Finalizar el pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        If cbEstado.FindString(estadoFinalizado.gEstado) = -1 Then
                            cbEstado.Items.Add(estadoFinalizado)
                        End If
                        cbEstado.SelectedItem = estadoFinalizado
                        funcPP.actualizaEstado(numPedido.Text, estadoFinalizado.gidEstado)
                    End If

                End If
            End If

            InformePedidoProv.GeneraPDF(numPedido.Text, funcUB.campoIdioma(iidUbicacion), GestionPedidoProveedor.rbPedidoPendiente.Checked, fichero, camino)
            Dim destinatario As String = funcUB.campoCorreo(cbDireccion.SelectedItem.itemdata)
            If cbContacto.SelectedIndex <> -1 Then
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    destinatario = If(destinatario = "", dts.gmail, destinatario & "; " & dts.gmail)
                Next
            End If


            'Dim texto As String = " Estimados Señores,<br><br>"
            'texto = texto & "A continuación adjuntamos NUEVO pedido de compra nº " & numPedido.Text & " que rogamos sirvan según las indicaciones del mismo.<br><br>"
            'texto = texto & "Para cualquier aclaración, póngase en contacto con el correo electrónico ventas@sugar-valley.net, o bien llamen al teléfono que aparece en el pedido adjunto.<br><br>"
            'texto = texto & "Esperando su confirmación de recepción y plazo de entrega, aprovechamos la presente para saludarles atentamente,<br><br> "

            'Se envía un correo outlook a la dirección de la ubicación
            CorreoOutlook("PEDIDO PROVEEDOR", funcPE.campoCorreo(Inicio.vIdUsuario), destinatario, camino & fichero, cbContacto.Text, numPedido.Text, dtpFechaPedido.Value.Date, dtpFechaEntrega.Value.Date, funcUB.campoIdioma(cbDireccion.SelectedItem.itemdata))
            'CorreoOutlook("Nuevo Pedido SUGAR VALLEY", texto, funcPE.campoCorreo(Inicio.vIdUsuario), destinatario, camino & fichero)

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
            Call CargarDatosProv()
            cambios = True
        End If
    End Sub


    Private Sub bRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bRecepcion.Click
        Dim validar As Boolean = True
        If cbEstado.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbEstado, "No hay un estado válido seleccionado")
        End If
        If validar Then
            'If cbEstado.SelectedItem.gidEstado = estadoStock.gidEstado Then
            '    MsgBox("Este pedido ya está recibido")
            '    validar = False
            'End If
            If lvConceptos.Items.Count = 0 Then
                MsgBox("No existen conceptos en el pedido")
                validar = False
            End If
            If cbEstado.SelectedItem.gidEstado = estadoAnulado.gidEstado Then
                MsgBox("El pedido está anulado")
                validar = False
            End If
            If cbEstado.SelectedItem.gidEstado = estadoStock.gidEstado Then
                MsgBox("El pedido ya está completamente recibido")
                validar = False
            End If

            If Not ValidaPed And bRequiereValidar And cbEstado.SelectedItem.gidEstado <> estadoValidado.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoStockParcial.gidEstado Then
                MsgBox("El pedido se ha de validar")
                validar = False
            End If

        End If
        If validar Then

            Dim GG As New FlujoSiguiente
            GG.pDesde = "PEDIDO PROVEEDOR"
            GG.pHasta = "ALBARAN PROVEEDOR"
            GG.pnumDesde = numPedido.Text
            GG.pnumHasta = 0
            GG.ShowDialog()

            Semaforo = True
            Call CargarPedido()
           
        End If
    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call inicializar()
                    indiceL = indiceL - 1
                    numPedido.Text = Pedidos(indiceL)
                    Call CargarPedido()
                End If

            Else
                Call inicializar()
                indiceL = indiceL - 1
                numPedido.Text = Pedidos(indiceL)
                Call CargarPedido()
            End If


        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Pedidos.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    indiceL = indiceL + 1
                    numPedido.Text = Pedidos(indiceL)
                    Call CargarPedido()
                End If
            Else

                indiceL = indiceL + 1
                numPedido.Text = Pedidos(indiceL)
                Call CargarPedido()
            End If


        End If
    End Sub


    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el pedido")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            If cbEstado.SelectedIndex <> -1 Then
                If cbEstado.SelectedItem.gidEstado = estadoEnCurso.gidEstado Then
                    If MsgBox("¿Finalizar el pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        If cbEstado.FindString(estadoFinalizado.gEstado) = -1 Then
                            cbEstado.Items.Add(estadoFinalizado)
                        End If
                        cbEstado.SelectedItem = estadoFinalizado
                        funcPP.actualizaEstado(numPedido.Text, estadoFinalizado.gidEstado)
                    End If

                End If
            End If
            Dim fichero As String = "PedidoProv SV " & Trim(numPedido.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformePedidoProv.GeneraPDF(numPedido.Text, funcUB.campoIdioma(iidUbicacion), GestionPedidoProveedor.rbPedidoPendiente.Checked, sfd.FileName, "")
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If

    End Sub



#End Region


#Region "BOTONES Conceptos"

    ''**************BOTONES Conceptos


    Private Sub bGuardarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub






    Private Sub bBorrarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrarConcepto.Click
        Try
            Dim validar As Boolean = True
            If lvIndice = -1 Or vidConcepto = 0 Then

            Else
                If MsgBox("¿Desea borrar el concepto indicado?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If lvConceptos.Items(lvIndice).SubItems(6).Text <> "" Then
                        Dim dts As DatosConceptoPedidoProv = funcCP.mostrar1(vidConcepto)
                        If dts.gCantidadRecibida > 0 Then
                            MsgBox("Esta linea indica que se ha recibido alguna cantidad, por tanto no se puede borrar")
                            validar = False
                        End If

                    End If
                    If validar Then
                        funcCP.borrar(vidConcepto)
                        lvConceptos.Items.RemoveAt(lvIndice)
                        'CargarDatosConceptos(numPedido.Text)
                        Semaforo = True
                        inicializaConcepto()
                        Call Recalcular()
                        Call CalculaEstado()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub bNuevoConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        inicializaConcepto()

    End Sub




    Private Sub BBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscarProducto.Click

        Try
            Dim BA As New lbBusquedaArticulo
            BA.SoloLectura = vSoloLectura
            BA.pModo = "COMPRABLE"
            BA.pidProveedor = iidProveedor
            BA.ShowDialog()
            iidArticulo = BA.pidArticulo
            Call AvisoPedidoArticulo()
            If BA.pidArticuloProv > 0 Then
                Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(BA.pidArticuloProv)
                cbcodArticuloProv.Text = dts.gcodArticuloProv
                Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia
                cbNombre.Text = dts.gNombre
                If cbNombre.Text <> dts.gNombre Then
                    cbNombre.Items.Add(New IDComboBox3(iidArticulo, dts.gNombre, BA.pidArticuloProv))
                    cbNombre.Text = dts.gNombre
                End If
                cbcodArticulo.Text = dts.gcodArticulo
                lbUnidad.Text = dts.gTipoUnidad
            Else
                Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                cbcodArticuloProv.Text = dts.gcodArticuloProv
                Precio.Text = FormatNumber(dts.gPrecioUnitarioC, If(dts.gPrecioUnitarioC >= 5, 4, 6))
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia
                cbNombre.Text = dts.gArticulo

                If cbNombre.Text <> dts.gArticulo Then
                    cbNombre.Items.Add(New IDComboBox3(iidArticulo, dts.gArticulo, 0))
                    cbNombre.Text = dts.gArticulo
                End If
                cbcodArticulo.Text = dts.gcodArticulo
                lbUnidad.Text = dts.gTipoUnidad
            End If


            'Al volver, pasamos al modo GUARDAR
            'If Cantidad.Text <> "" And Precio.Text <> "" Then
            '    If Cantidad.Text > 0 And Precio.Text > 0 Then
            '        'bGuardarConcepto.Enabled = Not vSoloLectura
            '    End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AvisoPedidoArticulo()
        If iidArticulo > 0 And lvIndice = -1 And iidArticulo <> iidArticuloAvisado AndAlso funcCP.ExisteAlgunPedidoArticulo(iidArticulo) Then
            Dim GG As New subUltimoPedidoArticulo
            GG.pidArticulo = iidArticulo
            GG.pidProveedor = 0
            GG.VerBotonPedido = False
            GG.ShowDialog()
            iidArticuloAvisado = iidArticulo
        End If


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
            cbNombre.Text = dts.gArticulo
            Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
            cbFamilia.Text = dts.gFamilia
            cbSubFamilia.Text = dts.gSubFamilia
            lbUnidad.Text = dts.gTipoUnidad
            Call AvisoPedidoArticulo()
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
            cbNombre.Text = dts.gArticulo
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
                Call inicializaConcepto()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(0).Text
                Dim iidConceptoInferior As Long = lvConceptos.Items(indiceInferior).SubItems(0).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemInferior As ListViewItem = lvConceptos.Items(indiceInferior).Clone
                If funcCP.MoverConceptos(iidConceptoInferior, iidConceptoActual) Then
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
                Call inicializaConcepto()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(0).Text
                Dim iidConceptoSuperior As Long = lvConceptos.Items(indiceSuperior).SubItems(0).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemSuperior As ListViewItem = lvConceptos.Items(indiceSuperior).Clone
                If funcCP.MoverConceptos(iidConceptoActual, iidConceptoSuperior) Then
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


    Private Sub Cantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, Precio.Click, PrecioTransporte.Click, DescuentoC.Click, Descuento.Click
        sender.SelectAll()
    End Sub


    'Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
    '    'Admite números negativos y decimales
    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = Asc(".") Then
    '        e.KeyChar = ","
    '    End If
    '    If Microsoft.VisualBasic.Left(Cantidad.Text, 1) = "-" Then
    '        KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    Else
    '        If Cantidad.Text = "" Or Cantidad.Text = "0" Then
    '            KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
    '        Else
    '            If InStr(Cantidad.Text, ",") Then
    '                KeyAscii = CShort(SoloNumeros(KeyAscii))
    '            Else
    '                KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
    '            End If
    '        End If
    '    End If
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If

    '    If KeyAscii = Keys.Enter Then
    '        Call GuardarConcepto()
    '    End If
    'End Sub


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
            Call Recalcular()
            If Not dtsPP Is Nothing AndAlso dtsPP.gidEstado <> estadoAnulado.gidEstado Then
                Call CalculaEstado()
            End If
            Call inicializaConcepto()
            gbConceptos.Enabled = G_AGeneral = "A" And cbEstado.SelectedItem.gidEstado <> estadoStock.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoAnulado.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoValidado.gidEstado

        End If

    End Sub




    Private Sub lvConceptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        'si marcamos algún concepto se copia en la zona de edición, nos guardamos el índice dentro del listview y el valor del idConcepto

        If lvConceptos.SelectedItems.Count > 0 Then
            lvIndice = lvConceptos.SelectedIndices(0)
            vidConcepto = lvConceptos.Items(lvIndice).Text
            iidArticulo = lvConceptos.Items(lvIndice).SubItems(10).Text
            Try
                Dim dts As DatosConceptoPedidoProv = funcCP.mostrar1(vidConcepto)
                Dim vMonedaC As String = vMoneda
                Recibido = dts.gRecibido
                CantidadRecibida = dts.gCantidadRecibida
                vMonedaC = dtsPP.gcodMoneda
                cbcodArticulo.Text = dts.gcodArticulo
                cbcodArticuloProv.Text = dts.gcodArticuloProv
                Cantidad.Text = FormatNumber(dts.gCantidad, 2)
                lbUnidad.Text = dts.gTipoUnidad
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gsubFamilia
                cbNombre.Text = dts.gArticuloProv
                'Si no está en los combos, lo añadimos
                If cbNombre.Text <> dts.gArticuloProv Or cbcodArticuloProv.Text <> dts.gcodArticuloProv Or cbcodArticulo.Text <> dts.gcodArticulo Then
                    cbNombre.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gArticuloProv, dts.gidArticuloProv))
                    cbNombre.Text = dts.gArticuloProv
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
                cbSubFamilia.Text = dts.gsubFamilia
                If dts.gCantidadRecibida >= dts.gCantidad Then
                    'Si se ha recibido el concepto, presentamos la fecha de recepción efectiva
                    dtpFechaPrevistaC.Value = dts.gFechaRecibido
                Else
                    dtpFechaPrevistaC.Value = dts.gFechaPrevista
                End If
                Dim dtsTI As DatosTipoIVA = funcTI.Mostrar1(dts.gidTipoIVA)
                If dtsTI.gTipoIVA <> dts.gTipoIVA Then
                    dtsTI.gTipoIVA = dts.gTipoIVA
                    cbTipoIVA.Items.Add(dtsTI)
                End If
                cbTipoIVA.Text = dtsTI.ToString


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub




    Private Sub detectaCambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPedido.TextChanged, pedidoProveedor.TextChanged, _
    cbsolicitadoVia.TextChanged, cbSolicitadoPor.TextChanged, dtpFechaPedido.ValueChanged, Observaciones.TextChanged, cbEstado.SelectionChangeCommitted, _
    HorarioEntrega.TextChanged, cbTipoIVA.SelectedIndexChanged, cbsolicitadoVia.SelectedIndexChanged, cbSolicitadoPor.SelectedIndexChanged, PrecioTransporte.TextChanged, _
     ckPagado.CheckedChanged, cbContacto.SelectedIndexChanged, cbValorado.SelectedIndexChanged, Nota.TextChanged, Descuento.TextChanged, cbTransporte.SelectedIndexChanged
        cambios = Semaforo
    End Sub



    Private Sub dtpFechaEntrega_valueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaEntrega.ValueChanged
        If Semaforo Then
            dtpFechaPrevistaC.Value = dtpFechaEntrega.Value
        End If
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
            If G_AGeneral = "A" Then
                'detectamos cambios en la EN CURSO para poder avisar si se sale sin guardar
                If ValidaPed Then
                    gbConceptos.Enabled = cbEstado.SelectedItem.gidEstado <> estadoAnulado.gidEstado
                    If cbEstado.SelectedIndex <> -1 Then
                        If cbEstado.Text <> EstadoOriginal And cbEstado.SelectedItem.ganulado Then
                            bGuardar.Enabled = Not vSoloLectura
                        End If
                    End If
                Else
                    'gbConceptos.Enabled = (cbEstado.Text <> "STOCK" And cbEstado.Text <> "ANULADO" And cbEstado.Text <> "FINALIZADO" And (cbEstado.Text <> "VALIDADO")) 'Or ValidaPed))
                    gbConceptos.Enabled = cbEstado.SelectedItem.gidEstado <> estadoStock.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoAnulado.gidEstado And cbEstado.SelectedItem.gidEstado <> estadoValidado.gidEstado


                End If

            End If
        End If

    End Sub





    Private Sub detectaCambioFecha(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaPedido.ValueChanged

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
                If dtpFechaPedido.Value.Year <> vfecha.Year Then
                    MsgBox("Año no válido", MsgBoxStyle.OkOnly)
                    dtpFechaPedido.Value = vfecha
                End If
            End If
        End If
    End Sub





    Private Sub Precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Precio.TextChanged, Cantidad.TextChanged, DescuentoC.TextChanged
        If Semaforo Then
            Semaforo = False
            If Precio.Text = "" Then Precio.Text = 0
            If DescuentoC.Text = "" Then DescuentoC.Text = 0
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
                Call AvisoPedidoArticulo()
                If iidArticuloProv > 0 Then
                    Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticuloProv)
                    cbcodArticuloProv.Text = dts.gcodArticuloProv
                    cbNombre.Text = dts.gNombre
                    Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    lbUnidad.Text = dts.gTipoUnidad
                Else
                    Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                    cbNombre.Text = dts.gArticulo
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
                Call AvisoPedidoArticulo()
                If iidArticuloProv > 0 Then
                    Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticuloProv)
                    cbcodArticulo.Text = dts.gcodArticulo
                    cbNombre.Text = dts.gNombre
                    Precio.Text = FormatNumber(dts.gPrecio, If(dts.gPrecio >= 5, 4, 6))
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                    lbUnidad.Text = dts.gTipoUnidad
                Else
                    Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                    cbNombre.Text = dts.gArticulo
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


    Private Sub cbNombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNombre.SelectionChangeCommitted
        If Semaforo Then
            Semaforo = False
            If cbNombre.SelectedIndex > -1 Then
                iidArticuloProv = cbNombre.SelectedItem.itemdata
                iidArticulo = cbNombre.SelectedItem.name1
                Call AvisoPedidoArticulo()
                If iidArticuloProv > 0 Then
                    Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(cbNombre.SelectedItem.itemdata)
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
            ' dtsPP = funcP.mostrar1(iidProveedor)
            cbCodProveedor.Text = funcP.campocodProveedor(iidProveedor)
            Call CargarDatosProv()
            cambios = True
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
            'bGuardar.Enabled = Not vSoloLectura
            iidProveedor = cbProveedor.SelectedItem.itemdata
            'iidUbicacion = funcUB.mostrar1ProvF(iidProveedor).gidUbicacion
            'iidTipoCompra = funcP.campoTipo(iidProveedor)
            dtsPR = funcP.mostrar1(iidProveedor)
            dtsFA = funcFF.mostrarProv(iidProveedor)
            Call PresentarAvisoProveedor()
            iidTipoCompra = dtsPR.gIdTipoCompra
            'observacionesProv.Text = dts.gobservaciones
            bRequiereValidar = funcTC.RequiereValidar(iidTipoCompra)
            'Call IntroducirArticulos()
            Call CargarDirecciones()
            If cbDireccion.Items.Count = 0 Then
                MsgBox("Este Proveedor no tiene una dirección de recogida introducida. Por favor, añada una dirección desde la Ficha del proveedor.")
            Else
                ' TipoMP = False 'funcP.campoMP(iidProveedor)
                'lbUnidad.Text = "u."
                vMoneda = funcP.campoMoneda(iidProveedor)
                lbMoneda1.Text = funcMO.CampoSimbolo(vMoneda)
                'lbMoneda2.Text = lbMoneda1.Text
                'lbMoneda3.Text = lbMoneda1.Text
                'lbmonedaT.Text = lbMoneda1.Text
                'lbMoneda4.Text = lbMoneda1.Text
                'lbMoneda5.Text = lbMoneda1.Text
                'Transporte.Text = funcFF.campoTransporte(iidProveedor)
                cbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
                Descuento.Text = FormatNumber(dtsFA.gDescuento, 2)
                Dim titulo As String = funcP.TipoCompra(iidProveedor)
                If G_AGeneral = "G" Then
                    Me.Text = "NUEVO PEDIDO PROVEEDOR " & UCase(titulo)
                Else
                    Me.Text = "EDITAR PEDIDO PROVEEDOR " & UCase(titulo)
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
            PrecioTransporte.Text = FormatNumber(funcPP.UltimoPrecioTransporte(iidProveedor), 2)
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
            'lvConceptos.Height = Me.Height - 484
            ' gbConceptos.Height = Me.Height - 324

        End If
    End Sub

    Private Sub cbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted
        If Semaforo Then
            If cbFamilia.SelectedIndex > -1 Then
                iidFamilia = cbFamilia.SelectedItem.itemdata

                Call introducirSubFamilias()
                Call IntroducirArticulos()
                'bNuevoConcepto.Enabled = True
                'If cbNombre.Text <> "" And CDbl(Cantidad.Text) <> 0 Then bGuardarConcepto.Enabled = Not vSoloLectura
            End If
        End If
    End Sub

    Private Sub cbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If cbSubFamilia.SelectedIndex > -1 Then
            iidsubFamilia = cbSubFamilia.SelectedItem.itemdata
            Call IntroducirArticulos()
            'bNuevoConcepto.Enabled = True
            'If cbNombre.Text <> "" And CDbl(Cantidad.Text) <> 0 Then bGuardarConcepto.Enabled = Not vSoloLectura
        End If
    End Sub

    Private Sub cbNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNombre.TextChanged
        'If cbNombre.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura
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
                If FechaCambio <> dtpFechaPedido.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                    'lbCambio.Text = "CAMBIO " & FechaCambio
                    'lbCambio.Visible = True
                End If
                Dim codMonedaActual = cbMoneda.SelectedItem.gcodMoneda
                If G_AGeneral = "A" Then
                    'Si es un doc que ya existente
                    If MsgBox("El cambio de moneda quedará guardado en la base de datos. ¿Proceder con el cambio?", MsgBoxStyle.OkCancel) Then
                        funcPP.actualizaMoneda(numPedido.Text, codMonedaActual)
                        dtsPP.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
                        dtsPP.gDivisa = cbMoneda.SelectedItem.gdivisa
                        dtsPP.gSimbolo = cbMoneda.SelectedItem.gsimbolo
                        Dim listaC As List(Of DatosConceptoPedidoProv) = funcCP.mostrar(numPedido.Text)
                        For Each dts As DatosConceptoPedidoProv In listaC
                            funcCP.CambiarPrecio(dts.gidConcepto, 0, funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        Call CargarDatosConceptos(numPedido.Text)
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

#End Region

End Class

  
   
 
