Imports System.IO
Imports Microsoft.Office.Interop

Public Class GestionPedido
    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private G_AGeneral As Char
    Private Pedidos As List(Of Integer)
    Private indiceL As Integer
    Private indice As Integer
    Private funcMO As New FuncionesMoneda
    Private funcOF As New FuncionesPedidos
    Private funcCO As New FuncionesConceptosPedidos
    Private funcTP As New funcionesTiposPago
    Private funcMP As New funcionesMediosPago
    Private funcTR As New FuncionesTiposRetencion
    Private funcTI As New FuncionesTiposIVA
    Private funcAR As New FuncionesArticulos
    Private funcTA As New FuncionesTiposArticulo
    Private funcST As New FuncionessubTiposArticulo
    Private funcCL As New funcionesclientes
    Private funcUB As New funcionesUbicaciones
    Private funcFA As New funcionesFacturacion
    Private funcCT As New funcionesContactos
    Private funcES As New FuncionesEstados
    Private funcMA As New Master
    Private funcSV As New FuncionesSolicitadoVia
    Private funcRu As New FuncionesRutas
    Private funcAC As New funcionesArticuloCliente
    Private funcACP As New funcionesArticuloClientePrecios
    Private funcPE As New FuncionesPersonal
    Private funcSK As New FuncionesStock
    Private funcCR As New FuncionesConceptosProduccion
    Private funcEC As New FuncionesEscandallos
    Private funcCE As New FuncionesConceptosEscandallos
    Private funcAP As New FuncionesArticuloPrecio
    Private funcCB As New FuncionesCuentasBancarias
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcCEQ As FuncionesConceptosEquiposProduccion
    Private DI As New DatosIniciales
    Private iidArticulo As Integer
    Private dtsOF As DatosPedido
    Private dtsCL As datoscliente
    Private dtsFA As datosfacturacion
    Private dtsCO As DatosConceptoPedido
    Private dtsAR As DatosArticulo
    Private dtsUB As datosUbicacion
    Private listaC As List(Of DatosConceptoPedido)
    Private semaforo As Boolean
    Private iidTipoArticulo As Integer
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private iidCliente As Integer
    Private localizacion As Point
    Private cmConceptos As New ContextMenu
    Private avisadoCliente As Boolean
    Private estadoPECabecera As DatosEstado
    Private estadoPEPendiente As DatosEstado
    Private estadoPEAnulado As DatosEstado
    Private estadoPEProduccion As DatosEstado
    Private estadoPEProducido As DatosEstado
    Private estadoPEPreparado As DatosEstado
    Private estadoPEServido As DatosEstado
    Private estadoPEParcial As DatosEstado
    Private EstadoCPLogistica As DatosEstado
    Private EstadoCPCreado As DatosEstado
    Private EstadoCPProduccion As DatosEstado
    Private EstadoCPEnProduccion As DatosEstado
    Private EstadoCPPreparado As DatosEstado
    Private EstadoCPServido As DatosEstado
    Private EstadoCPProducido As DatosEstado
    Private ClienteSoloLectura As Boolean
    Private ConceptosEditables As Boolean
    Private PreciosConceptosEditables As Boolean
    Private CantidadEditable As Boolean

    'Identificadores de estado de Conceptos de Producción
    Private idEstadoCPrRecibido As Integer
    Private idEstadoCPrEspera As Integer
    Private idEstadoCPrEnCurso As Integer
    Private idEstadoCPrAcabado As Integer
    Private idEstadoCPrTraspasado As Integer
    Private idEstadoCPrParcial As Integer
    Private EnviarAvisoFechaEntrega As Boolean
    Private SeHaDePropagarCambioPrioridad As Boolean
    Public vvercostes As Boolean

    Public Property pnumPedido() As Integer
        Get
            Return numDoc.Text
        End Get
        Set(ByVal value As Integer)
            numDoc.Text = value
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

    Property pPedidos() As List(Of Integer)
        Get
            Return Pedidos
        End Get
        Set(ByVal value As List(Of Integer))
            Pedidos = value
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

    Property pLocation() As Point
        Get
            Return localizacion
        End Get
        Set(ByVal value As Point)
            localizacion = value
        End Set
    End Property

    Private Sub GestionPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        vvercostes = funcPE.vercostes(iidUsuario) 'luis vercoste
        If localizacion.X <> 0 Then Me.Location = localizacion
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 950 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 900
        End If
        EnviarAvisoFechaEntrega = False
        avisadoCliente = False
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        Dim tt As New ToolTip
        tt.InitialDelay = 0
        tt.SetToolTip(bLimpiar, "Limpiar zona de edición")
        tt.SetToolTip(bArticuloCliente, "Gestión Artículo-Cliente")
        tt.SetToolTip(bVerArticuloC, "Ver ficha del artículo")
        tt.SetToolTip(bVerCliente, "Ver ficha del cliente")
        tt.SetToolTip(bBuscarArticuloC, "Búsqueda del artículo")
        tt.SetToolTip(bBuscarCliente, "Búsqueda del cliente")
        tt.SetToolTip(bNuevoCliente, "Dar de alta un nuevo cliente")
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        rbPedidoCompleto.Checked = True
        cbCodArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbCodArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        cbArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        ClienteSoloLectura = False
        ConceptosEditables = True
        PreciosConceptosEditables = True
        CantidadEditable = True
    End Sub

    Private Sub GestionPedido1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        semaforo = False
        estadoPECabecera = funcES.EstadoPedido("CABECERA")
        estadoPEPendiente = funcES.EstadoPedido("PENDIENTE")
        estadoPEAnulado = funcES.EstadoPedido("ANULADO")
        estadoPEProduccion = funcES.EstadoPedido("PRODUCCION")
        estadoPEProducido = funcES.EstadoPedido("PRODUCIDO")
        estadoPEPreparado = funcES.EstadoPedido("PREPARADO")
        estadoPEServido = funcES.EstadoPedido("SERVIDO")
        estadoPEParcial = funcES.EstadoPedido("PARCIAL")
        EstadoCPLogistica = funcES.EstadoCPedido("ENVIADO PRODUCCION")
        EstadoCPCreado = funcES.EstadoCPedido("CREADO")
        EstadoCPProduccion = funcES.EstadoCPedido("RECIBIDO PRODUCCION")
        EstadoCPEnProduccion = funcES.EstadoCPedido("EN PRODUCCION")
        EstadoCPPreparado = funcES.EstadoCPedido("PREPARADO")
        EstadoCPServido = funcES.EstadoCPedido("SERVIDO")
        EstadoCPProducido = funcES.EstadoCPedido("PRODUCIDO")

        iidUsuario = Inicio.vIdUsuario
        Call introducirMediosPago()
        Call introducirMonedas()
        Call IntroducirTiposArticulo()
        Call introducirTiposIVA()
        Call introducirTiposPago()
        Call introducirTiposRetencion()
        'Call introducirClientes()
        Call introducirTransporte()
        Call introducirTiposValorado()
        Call introducirSolicitadoVia()
        Call InicializarGeneral()
        If numDoc.Text = "" Then numDoc.Text = 0
        If numDoc.Text = 0 Then
            Call introducirClientes()
            Call Nuevo()
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            Me.Text = "EDITAR PEDIDO CLIENTE"
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
            ' G_AGeneral = "A"
        End If
        semaforo = True

    End Sub

    Private Sub GestionPedido_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If G_AGeneral = "G" Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
        If e.Cancel = False And EnviarAvisoFechaEntrega And Not dtsOF Is Nothing AndAlso (dtsOF.gidUbicacion > 0 And dtsOF.gidEstado <> estadoPEAnulado.gidEstado And dtsOF.gidEstado <> estadoPECabecera.gidEstado) Then
            If MsgBox("¿Generar un e-Mail de aviso al cliente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
                If cbContacto.SelectedIndex <> -1 Then
                    Dim funcMOA As New FuncionesMails
                    Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                    For Each dts As DatosMail In lista
                        Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                    Next
                End If
                'Se envía un correo outlook a la dirección de la ubicación
                CorreoOutlook("PEDIDO (FECHA_PREVISTA)", funcPE.campoCorreo(iidUsuario), Destinatario, "", cbContacto.Text, numDoc.Text, dtpFecha.Value.Date, dtpFechaPrevista.Value.Date, funcUB.campoIdioma(dtsOF.gidUbicacion))
            End If

        End If
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub Nuevo()
        Me.Text = "NUEVO PEDIDO CLIENTE"
        ClienteSoloLectura = False
        cbCliente.Enabled = True
        cbCodCliente.Enabled = True
        bBuscarCliente.Enabled = True
        dtsOF = New DatosPedido
        gbConceptos.Enabled = False
        numDoc.Text = funcMA.leernumPedido(Now.Year) + 1
        If numDoc.Text = 0 Then
            funcMA.NuevoAño()
            numDoc.Text = funcMA.leernumPedido(Now.Year) + 1
            If numDoc.Text = 0 Then
                MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                Me.Close()
            End If
        End If
        G_AGeneral = "G"
        Dim dtsES As DatosEstado = funcES.EstadoCabecera("Pedido")
        cbEstado.Items.Clear()
        cbEstado.Items.Add(dtsES)
        cbEstado.Text = dtsES.ToString
        iidCliente = 0
        rbPri1.Checked = False
        rbPri2.Checked = True
        'dtpFechaPrevista.Value = funcCR.FechaInicioTrabajo(3)
        dtpFechaPrevista.Value = Now()
        EnviarAvisoFechaEntrega = True
    End Sub

    Private Sub InicializarGeneral()
        ep1.Clear()
        ep2.Clear()
        ckSeleccion.Checked = False
        ckSeleccion.Visible = True
        lvConceptos.Items.Clear()
        lvConceptos.CheckBoxes = True
        RefCliente.Text = ""
        RefCliente2.Text = ""
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbCodCliente.Text = ""
        cbCodCliente.SelectedIndex = -1
        rbPri1.Checked = False
        rbPri2.Checked = True
        cbValorado.Text = "NO VALORADO" 'No depende del cliente. Por defecto es no valorado
        Call introducirComerciales()
        Call LimpiarCabecera()
        Nota.Text = ""
        Observaciones.Text = ""
        SumaDescuentos.Text = 0
        BaseImponible.Text = 0
        TotalIVA.Text = 0
        TotalRE.Text = 0
        Retencion.Text = 0
        Total.Text = 0
        Call LimpiarEdicion()
        cambios = False

    End Sub

    Private Sub LimpiarCabecera()
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbDireccion.Items.Clear()
        dtpFecha.Value = Now.Date
        rbPri2.Checked = True
        'dtpFechaPrevista.Value = funcCR.FechaInicioTrabajo(3)
        numDoc1.Text = ""
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbSolicitadoVia.Text = ""
        cbSolicitadoVia.SelectedIndex = -1
        cbMedioPago.Text = ""
        cbMedioPago.SelectedIndex = -1
        cbTipoPago.Text = ""
        cbTipoPago.SelectedIndex = -1
        cbCuenta.Text = ""
        cbCuenta.SelectedIndex = -1
        cbCuenta.Items.Clear()
        cbMoneda.Text = funcMO.CampoDivisa("EU")
        codMonedaI = "EU"
        cbTipoIVA.Text = DI.TipoIVA.ToString
        cbRetencion.SelectedItem = DI.TipoRetencion
        cbPortes.Text = ""
        PrecioTransporte.Text = 0
        PrecioTransporte.Enabled = False

    End Sub

    Private Sub LimpiarEdicion()
        Dim semaforo0 As Boolean = semaforo
        semaforo = False
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        PVP.Text = 0
        PrecioNeto.Text = 0
        DescuentoC.Text = 0
        Cantidad.Text = 0
        codArticuloCli.Text = ""
        subTotal.Text = 0
        indice = -1
        iidArticulo = 0
        iidTipoArticulo = 0

        cbArticulo.Items.Clear()
        cbCodArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        Stock.Text = 0
        cbVersion.Items.Clear()
        cbVersion.Text = ""
        cbVersion.SelectedIndex = -1
        cbVersion.Enabled = False
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
        semaforo = semaforo0
    End Sub

    Private Sub IntroducirTiposArticulo()
        cbTipo.Items.Clear()
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosTipoArticulo) = funcTA.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(dts)
        Next
    End Sub

    Private Sub IntroducirSubTiposArticulo()
        If iidTipoArticulo > 0 Then
            cbSubTipo.Text = ""
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Items.Clear()
            Dim lista As List(Of DatosSubTipoArticulo) = funcST.Mostrar(iidTipoArticulo, 0, True)
            Dim dts As DatosSubTipoArticulo
            For Each dts In lista
                cbSubTipo.Items.Add(New IDComboBox(dts.gSubTipoArticulo, dts.gidSubTipoArticulo))
            Next
        End If
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

    Private Sub introducirTiposPago()
        Try
            cbTipoPago.Items.Clear()
            Dim lista As List(Of datosTipoPago) = funcTP.mostrar(True)
            Dim dts As datosTipoPago
            For Each dts In lista
                cbTipoPago.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirMediosPago()
        Try
            cbMedioPago.Items.Clear()
            Dim lista As List(Of datosMedioPago) = funcMP.mostrar
            Dim dts As datosMedioPago
            For Each dts In lista
                cbMedioPago.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub introducirTiposRetencion()
        Try
            cbRetencion.Items.Clear()
            Dim lista As List(Of DatosTipoRetencion) = funcTR.Mostrar(True)
            Dim dts As DatosTipoRetencion
            For Each dts In lista
                cbRetencion.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        cbCodCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Pedido")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
        'Identificadores de estado de Conceptos de Producción
        idEstadoCPrRecibido = funcES.EstadoEntregado("PRODUCCION").gidEstado
        idEstadoCPrEspera = funcES.EstadoEspera("PRODUCCION").gidEstado
        idEstadoCPrEnCurso = funcES.EstadoEnCurso("PRODUCCION").gidEstado
        idEstadoCPrAcabado = funcES.EstadoCompleto("PRODUCCION").gidEstado
        idEstadoCPrTraspasado = funcES.EstadoTraspasado("PRODUCCION").gidEstado
        idEstadoCPrParcial = funcES.EstadoAutomatico("PRODUCCION").gidEstado
    End Sub

    Private Sub introducirSolicitadoVia()
        cbSolicitadoVia.Items.Clear()
        Dim lista As List(Of DatosSolicitadoVia) = funcSV.Mostrar
        For Each dts As DatosSolicitadoVia In lista
            cbSolicitadoVia.Items.Add(dts)
        Next
    End Sub

    Private Sub introducirComerciales()
        cbPersona.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(0)
        For Each item As IDComboBox In lista
            cbPersona.Items.Add(item)
        Next
        'Cargamos el usuario que ha hecho login, si no está en la lista lo deja en blanco.
        cbPersona.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbPersona.SelectedIndex = -1 Then cbPersona.Text = ""
    End Sub

    Private Sub introducirTransporte()
        Try
            Dim funcPR As New funcionesProveedores
            cbTransporte.Items.Clear()
            cbTransporte.Items.Add(New IDComboBox("SUS MEDIOS", -1))
            cbTransporte.Items.Add(New IDComboBox("NUESTROS MEDIOS", -2))
            Dim lista As List(Of IDComboBox) = funcPR.Transportes
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

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarPedido()
        Try
            ep1.Clear()
            ep2.Clear()
            G_AGeneral = "A"
            dtsOF = funcOF.Mostrar1(numDoc.Text)
            iidCliente = dtsOF.gidCliente
            dtsCL = funcCL.mostrar1(dtsOF.gidCliente)

            Dim dtsES As DatosEstado = funcES.Mostrar1(dtsOF.gidEstado)

            If dtsES.gCabecera Or dtsES.gEnCurso Or dtsES.gEspera Or dtsES.gCompleto Then
                Call introducirClientes()
                ClienteSoloLectura = False
                bBuscarCliente.Enabled = True
            Else
                cbCliente.Items.Clear()
                cbCodCliente.Items.Clear()
                cbCodCliente.Items.Add(New IDComboBox(dtsCL.gcodCli, dtsCL.gidCliente))
                cbCliente.Items.Add(New IDComboBox(dtsCL.gnombrecomercial, dtsCL.gidCliente))
                ClienteSoloLectura = True
                bBuscarCliente.Enabled = False
            End If

            cbCliente.Text = dtsOF.gCliente
            cbCodCliente.Text = dtsCL.gcodCli

            Call CargarDatosFacturacionCliente()
            Call CargarCombosCliente()
            Call PresentarAvisoCliente()

            RefCliente.Text = dtsOF.gReferenciaCliente
            RefCliente2.Text = dtsOF.gReferenciaCliente2
            cbPersona.Text = dtsOF.gPersona

            Select Case dtsOF.gnumSAlbaran.Count
                Case 0
                    numDoc1.Text = ""
                Case 1
                    numDoc1.Text = dtsOF.gnumSAlbaran(0)
                Case Else
                    numDoc1.Text = "VARIOS"
                    'Dim Albaranes As String = ""
                    'For Each n As Integer In dtsOF.gnumSAlbaran
                    '    If Albaranes <> "" Then Albaranes = Albaranes & ", "
                    '    Albaranes = Albaranes & n
                    'Next
                    'Dim tt As New ToolTip
                    'tt.InitialDelay = 0
                    'tt.SetToolTip(numDoc1, Albaranes)

                    Dim cmNumDoc1 As New ContextMenu
                    For Each numero In dtsOF.gnumSAlbaran
                        cmNumDoc1.MenuItems.Add(numero, New System.EventHandler(AddressOf Me.OnClickNumDoc1))
                    Next
                    numDoc1.ContextMenu = cmNumDoc1

            End Select

            cbMoneda.Text = dtsOF.gDivisa
            lbMoneda1.Text = dtsOF.gSimbolo
            codMonedaI = dtsOF.gcodMoneda
            dtpFecha.Value = dtsOF.gFecha
            dtpFechaPrevista.Value = dtsOF.gFechaEntrega


            cbDireccion.Text = dtsOF.gDireccion
            If cbDireccion.SelectedIndex = -1 Then
                ep2.SetError(cbDireccion, "Dirección no válida")
            Else
                dtsUB = funcUB.mostrar1(dtsOF.gidUbicacion)
            End If


            If dtsOF.gidTransporte = 0 Then
                cbTransporte.Text = dtsOF.gTransporte
            Else
                cbTransporte.Text = dtsOF.gAgenciaTransporte
            End If


            cbContacto.Text = dtsOF.gContacto
            cbMedioPago.Text = dtsOF.gMedioPago
            cbTipoPago.Text = dtsOF.gTipoPago

            cbTipoIVA.Items.Clear()
            cbTipoIVA.Items.Add(funcTI.Mostrar1(dtsOF.gidTipoIVA))
            cbTipoIVA.SelectedIndex = 0

            ckRecargoEquivalencia.Checked = dtsOF.gRecargoEquivalencia
            If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
                TipoRecargoEq.Enabled = True
                TipoRecargoEq.Text = dtsOF.gTipoRecargoEq
            Else
                TipoRecargoEq.Enabled = False
                TipoRecargoEq.Text = 0
            End If

            cbRetencion.Items.Clear()
            cbRetencion.Items.Add(funcTR.Mostrar1(dtsOF.gidTipoRetencion))
            cbRetencion.SelectedIndex = 0

            If dtsOF.gidCuentaBanco > 0 Then
                'Dim funcCB As New FuncionesCuentasBancarias
                cbCuenta.Text = funcCB.NombreCompleto(dtsOF.gidCuentaBanco)
            Else
                cbCuenta.Text = ""
            End If
            Observaciones.Text = dtsOF.gObservaciones
            Nota.Text = dtsOF.gNotas
            cbSolicitadoVia.Text = dtsOF.gSolicitadoVia
            cbValorado.Text = dtsOF.gTipoValorado
            If dtsOF.gPortes = "P" Then
                cbPortes.Text = "PAGADOS"
                PrecioTransporte.Text = 0
            End If
            If dtsOF.gPortes = "D" Then
                cbPortes.Text = "DEBIDOS"
                PrecioTransporte.Text = 0
            End If
            If dtsOF.gPortes = "I" Then
                cbPortes.Text = "INC.FRA."
                PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
            End If
            ProntoPago.Text = FormatNumber(dtsOF.gProntoPago, 2)
            If dtsOF.gPrioridad = 2 Then rbPri2.Checked = True
            If dtsOF.gPrioridad = 1 Then rbPri1.Checked = True

            If dtsOF.gidTransporte = 0 Then
                cbTransporte.Text = dtsOF.gTransporte
            Else
                cbTransporte.Text = dtsOF.gAgenciaTransporte
            End If

            cbEstado.Items.Clear()
            'Cargar el estado que tenga y los que falten


            If dtsES.gCabecera Then
                cbEstado.Items.Add(estadoPECabecera)
                cbEstado.Items.Add(estadoPEAnulado)
                EnviarAvisoFechaEntrega = True
            ElseIf dtsES.gAnulado Then
                If Not dtsOF.gbAnulado Then cbEstado.Items.Add(estadoPEPendiente)
                cbEstado.Items.Add(estadoPEAnulado)
            ElseIf dtsES.gEnCurso And dtsES.gEspera Then 'Producción
                cbEstado.Items.Add(estadoPEProduccion)
                cbEstado.Items.Add(estadoPEAnulado)
            ElseIf dtsES.gEnCurso And Not dtsES.gEspera Then 'Pendiente
                cbEstado.Items.Add(estadoPEPendiente)
                cbEstado.Items.Add(estadoPEAnulado)
            ElseIf dtsES.gEspera And Not dtsES.gEnCurso Then 'Producido
                cbEstado.Items.Add(estadoPEProducido)
                cbEstado.Items.Add(estadoPEAnulado)
            ElseIf dtsES.gCompleto And Not dtsES.gTraspasado Then 'Preparado
                cbEstado.Items.Add(estadoPEPreparado)
                cbEstado.Items.Add(estadoPEAnulado)
            ElseIf dtsES.gEntregado Then 'PARCIAL
                cbEstado.Items.Add(estadoPEParcial)
            End If

            If dtsES.gTraspasado Then 'Servido
                cbEstado.Items.Add(estadoPEServido)
            End If
            cbEstado.Text = dtsES.ToString

            If dtsES.gAnulado And Not dtsOF.gbAnulado Then 'Anulado normal
                ConceptosEditables = False
                PreciosConceptosEditables = False
                CantidadEditable = False
                bGuardar.Enabled = True 'Podremos cambiar el estado
                bBorrar.Enabled = False
                bTraspasar.Enabled = False
            ElseIf dtsES.gTraspasado Or (dtsOF.gbAnulado) Then ' Servido, bAnulado
                ConceptosEditables = False
                PreciosConceptosEditables = False
                CantidadEditable = False
                bGuardar.Enabled = False
                bBorrar.Enabled = False
                bTraspasar.Enabled = False

            ElseIf (dtsES.gEspera And Not dtsES.gEnCurso) Or dtsES.gCompleto Then 'Producido, Preparado
                bGuardar.Enabled = Not vSoloLectura
                bBorrar.Enabled = True
                ConceptosEditables = True 'False
                PreciosConceptosEditables = True
                CantidadEditable = True
            Else 'Cabecera, Pendiente, Parcial, Producción
                bBorrar.Enabled = Not vSoloLectura
                bGuardar.Enabled = Not vSoloLectura
                ConceptosEditables = True
                PreciosConceptosEditables = True
                CantidadEditable = True
            End If
            ckSinAlbaran.Checked = dtsOF.gSinAlbaran
            ckRecogido.Checked = dtsOF.gRecogido
            If dtsOF.gidEstado = estadoPEServido.gidEstado Or dtsOF.gidEstado = estadoPEParcial.gidEstado Then
                'Si está "Sin Albaran" y en estado SERVIDO o PARCIAL, forzamos el cambio directo SinAlbaran = Falso
                If dtsOF.gSinAlbaran Then funcOF.CambiaSinAlbaran(numDoc.Text, False)
                If dtsOF.gRecogido Then funcOF.CambiaRecogido(numDoc.Text, False)
                ckSinAlbaran.Checked = False
                ckSinAlbaran.Enabled = False
                ckRecogido.Enabled = False
                ckRecogido.Enabled = False
            Else
                ckSinAlbaran.Enabled = True
                ckRecogido.Enabled = dtsOF.gSinAlbaran
            End If

            Call CargarConceptos()
            If vvercostes = True Then
                SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
                BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
                TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
                TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
                Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
                Total.Text = FormatNumber(dtsOF.gTotal, 2)
            Else
                SumaDescuentos.Text = ""
                BaseImponible.Text = ""
                TotalIVA.Text = ""
                TotalRE.Text = ""
                Retencion.Text = ""
                Total.Text = ""
            End If

            cambios = False
        Catch ex As Exception
            ex.Data.Add("numDoc.Text", numDoc.Text)
            CorreoError(ex)
        End Try
    End Sub

    Private Sub CargarConceptos()
        funcCO.RenumerarSiEsNecesario(numDoc.Text)
        If rbPedidoCompleto.Checked Then
            listaC = funcCO.Mostrar(numDoc.Text)
        Else
            listaC = funcCO.MostrarPendientes(numDoc.Text)
        End If
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoPedido In listaC
            nuevaLineaLV(dts)
        Next
        Dim cmConceptos As New ContextMenu
        cbArticulo.Focus()
    End Sub

    Private Sub CargarContactos()
        If cbCliente.SelectedIndex <> -1 Then
            Dim Contacto As String = cbContacto.Text
            cbContacto.Text = ""
            cbContacto.Items.Clear()
            Dim lista As List(Of datosContacto) = funcCT.mostrarCli(cbCliente.SelectedItem.itemdata)
            For Each dts As datosContacto In lista
                cbContacto.Items.Add(New IDComboBox(dts.gnombre + " " + dts.gapellidos, dts.gidContacto))
            Next
            If Contacto.Length > 0 Then
                cbContacto.Text = Contacto
            End If
            If cbContacto.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbContacto.SelectedIndex = 0
                Else
                    cbContacto.Text = ""
                End If
            End If
        End If

    End Sub

    Private Sub CargarArticuloC()

        Try
            'Carga los datos de un artículo en la zona de edición
            If iidArticulo > 0 And cbCliente.SelectedIndex <> -1 Then
                semaforo = False
                ep2.Clear()
                dtsAR = funcAR.Mostrar1V(iidArticulo, cbCliente.SelectedItem.itemdata, dtsUB.gidIdioma)
                cbTipo.Text = dtsAR.gTipoArticulo
                Call IntroducirSubTiposArticulo()
                cbSubTipo.Text = dtsAR.gSubTipoArticulo
                Call CargarArticulosC()
                cbCodArticulo.Text = dtsAR.gcodArticulo
                cbArticulo.Text = dtsAR.gArticuloCli
                codArticuloCli.Text = dtsAR.gCodArticuloCli
                lbUnidad.Text = dtsAR.gTipoUnidad

                If dtsAR.gPrecioArtCli = -1 Then
                    'Si no hay precio neto específico, puede haber descuento
                    PrecioNeto.Text = 0
                    If dtsAR.gDescuento > 0 Then
                        'Si hay descuento específico
                        DescuentoC.Text = FormatNumber(dtsAR.gDescuento, 2)
                    Else
                        'Si no, tomamos el descuento del cliente doméstico o industrial según el tipo de artículo
                        DescuentoC.Text = FormatNumber(If(dtsAR.gDescuento1, dtsFA.gDescuento, dtsFA.gDescuento2))
                    End If
                Else
                    'Si hay precio neto específico, lo ponemos, comprobando que la moneda sea la seleccionada en el documento
                    If cbMoneda.SelectedItem.gcodMoneda = dtsAR.gcodMonedaV Then
                        PrecioNeto.Text = FormatNumber(dtsAR.gPrecioArtCli, 2)
                    Else
                        Dim aviso As Boolean
                        Dim FechaCambio As Date
                        PrecioNeto.Text = FormatNumber(funcMO.Cambio(dtsAR.gPrecioArtCli, dtsAR.gcodMonedaV, cbMoneda.SelectedItem.gcodMoneda, aviso, FechaCambio), 2)
                        If aviso Then ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                        'lbCambio.Text = "CAMBIO " & FechaCambio
                        'lbCambio.Visible = aviso
                    End If
                    DescuentoC.Text = 0
                End If


                If cbMoneda.SelectedIndex = -1 Then
                    PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
                Else
                    If cbMoneda.SelectedItem.gcodMoneda = dtsAR.gcodMonedaV Then
                        PVP.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2)
                    Else
                        Dim aviso As Boolean
                        Dim FechaCambio As Date
                        PVP.Text = FormatNumber(funcMO.Cambio(dtsAR.gPrecioUnitarioV, dtsAR.gcodMonedaV, cbMoneda.SelectedItem.gcodMoneda, aviso, FechaCambio), 2)
                        If aviso Then ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                        'lbCambio.Text = "CAMBIO " & FechaCambio
                        'lbCambio.Visible = aviso
                    End If

                End If
                If Cantidad.Text = "" Then Cantidad.Text = 0
                If DescuentoC.Text = "" Then DescuentoC.Text = 0
                If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
                If PVP.Text = "" Then PVP.Text = 0
                If Cantidad.Text = 0 Then Cantidad.Text = 1
                If DescuentoC.Text <> 0 Then  'Si hay descuento, ignoramos el precio neto
                    PrecioNeto.Text = FormatNumber((1 - DescuentoC.Text / 100) * PVP.Text, 2)
                Else
                    If PrecioNeto.Text = 0 Then PrecioNeto.Text = PVP.Text 'Si el precio neto=0, ponemos el PVP
                End If
                subTotal.Text = FormatNumber(Cantidad.Text * PrecioNeto.Text, 2)
                Stock.Text = dtsAR.gCantidadStock
                semaforo = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CargarDirecciones()
        If cbCliente.SelectedIndex <> -1 Then
            Dim direccion As String = cbDireccion.Text
            cbDireccion.Items.Clear()
            Dim lista As List(Of datosUbicacion) = funcUB.mostrarCli(cbCliente.SelectedItem.itemdata, True, 0, 1, 0, 0, 1, 0)
            For Each dts As datosUbicacion In lista
                cbDireccion.Items.Add(New IDComboBox(If(dts.gSubCliente = "", "", dts.gSubCliente & ": ") & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
            Next
            If direccion.Length > 0 Then
                cbDireccion.Text = direccion
            End If
            If cbDireccion.SelectedIndex = -1 Then
                If lista.Count = 1 Then
                    cbDireccion.SelectedIndex = 0
                    Call DatosDireccion()
                Else
                    cbDireccion.Text = ""
                End If

            End If

        End If
    End Sub

    Private Sub CargarCuentas()
        If Not dtsFA.gCuentas Is Nothing Then
            Dim cuentaActual As String = cbCuenta.Text
            cbCuenta.Items.Clear()
            If dtsFA.gCuentas.Count > 0 Then
                For Each dts As DatosCuentaBancaria In dtsFA.gCuentas
                    cbCuenta.Items.Add(New IDComboBox(dts.gNombreCompleto, dts.gidCuentaBanco))
                Next
            End If
            If cuentaActual.Length > 0 Then
                'Si habiamos guardado la cuenta, la volvemos a poner
                cbCuenta.Text = cuentaActual
                'Si no coincide con ninguna, la borramos
                If cbCuenta.SelectedIndex = -1 Then
                    cbCuenta.Text = ""
                End If
            End If
            'Si solo hay una y no es válido lo escrito, la ponemos directamente
            If cbCuenta.Text = "" And dtsFA.gCuentas.Count = 1 Then
                cbCuenta.Text = dtsFA.gCuentas(0).gNombreCompleto
            End If
        End If
    End Sub

    Private Sub CargarDatosFacturacionCliente()
        Dim semaforo0 As Boolean = semaforo
        dtsFA = funcFA.mostrarCli(iidCliente)
        If G_AGeneral = "G" Then
            semaforo = False
            Call LimpiarCabecera()
            semaforo = semaforo0
            If dtsFA.gcodMoneda = "" Then
                cbMoneda.Text = funcMO.CampoDivisa("EU")
                lbMoneda1.Text = funcMO.CampoSimbolo("EU")
            Else
                cbMoneda.Text = dtsFA.gDivisa
                codMonedaI = dtsFA.gcodMoneda
                lbMoneda1.Text = dtsFA.gSimbolo
            End If
            cbMedioPago.Text = dtsFA.gMedioPago
            cbTipoPago.Text = dtsFA.gTipoPago
            cbPersona.Text = dtsCL.gResponsableCuenta
            cbValorado.Text = dtsFA.gTipoValorado
            ProntoPago.Text = FormatNumber(dtsFA.gProntoPago, 2)
        End If

    End Sub

    Private Sub PresentarAvisoCliente()
        If Trim(dtsCL.gobservaciones).Length > 0 And Not avisadoCliente Then
            MsgBox(dtsCL.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsCL.gnombrecomercial)
            avisadoCliente = True
        End If
    End Sub

    Private Sub CargarDatosClienteNoEditables()
        If Not dtsFA Is Nothing Then
            cbTipoIVA.Items.Clear()
            cbTipoIVA.Items.Add(funcTI.Mostrar1(dtsFA.gidTipoIVA))
            cbTipoIVA.SelectedIndex = 0

            ckRecargoEquivalencia.Checked = dtsFA.gRecargoEquivalencia

            If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
                TipoRecargoEq.Enabled = True
                TipoRecargoEq.Text = dtsFA.gTipoRecargoEq
            Else
                TipoRecargoEq.Enabled = False
                TipoRecargoEq.Text = 0
            End If

            cbRetencion.Items.Clear()
            cbRetencion.Items.Add(funcTR.Mostrar1(dtsFA.gidTipoRetencion))
            cbRetencion.SelectedIndex = 0
        End If

    End Sub

    Private Sub AsignarDOCDatosClienteNoEditables()
        dtsOF.gTipoIVA = dtsFA.gTipoIVA
        dtsOF.gidTipoIVA = dtsFA.gidTipoIVA
        dtsOF.gRecargoEquivalencia = dtsFA.gRecargoEquivalencia
        dtsOF.gTipoRecargoEq = dtsFA.gRecargoEquivalencia
        dtsOF.gTipoRetencion = dtsFA.gTipoRetencion
        dtsOF.gidTipoRetencion = dtsFA.gidTipoRetencion
    End Sub

    Private Sub CargarCombosCliente()
        Call CargarContactos()
        Call CargarDirecciones()
        Call CargarCuentas()
    End Sub

    Private Sub CambioCliente()
        avisadoCliente = False
        Call PresentarAvisoCliente()
        Call CargarDatosFacturacionCliente()
        Call CargarDatosClienteNoEditables()
        Call CargarCombosCliente()
        cambios = True
    End Sub

    Private Sub CargarArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3)
        If cbCliente.SelectedIndex = -1 Then
            'Si no hay cliente seleccionado, buscamos en Articulos directamente
            lista = funcAR.Buscar(" AND Vendible = 1 " & If(cbTipo.SelectedIndex = -1, "", " AND idTipoArticulo = " & cbTipo.SelectedItem.gidTipoArticulo) _
                                                & If(cbSubTipo.SelectedIndex = -1, "", " AND idsubTipoArticulo = " & cbSubTipo.SelectedItem.itemdata), "")
        Else
            'Si tenemos el cliente, el nombre del artículo será el específico si existe
            lista = funcAR.BuscarAC(" AND Vendible = 1 " & If(cbTipo.SelectedIndex = -1, "", " AND idTipoArticulo = " & cbTipo.SelectedItem.gidTipoArticulo) _
                                                & If(cbSubTipo.SelectedIndex = -1, "", " AND idsubTipoArticulo = " & cbSubTipo.SelectedItem.itemdata), cbCliente.SelectedItem.itemdata, "", dtsUB.gidIdioma)
        End If
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next

    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoPedido)
        With lvConceptos.Items.Add(" ")
            .SubItems.Add(dts.gidConcepto)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gcodArticuloCli)
            .SubItems.Add(dts.gArticuloCli)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            If vvercostes = True Then
                .SubItems.Add(FormatNumber(dts.gPVPUnitario, 2) & dtsOF.gSimbolo)
                .SubItems.Add(FormatNumber(dts.gDescuento, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsOF.gSimbolo)
                .SubItems.Add(FormatNumber(dts.gSubTotal, 2) & dtsOF.gSimbolo)
            Else
                .SubItems.Add("")
                .SubItems.Add("")
                .SubItems.Add("")
                .SubItems.Add("")
            End If
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(dts.gCantidadStock & dts.gTipoUnidad)
            If rbPedidoCompleto.Checked Then
                .SubItems.Add(FormatNumber(dts.gCantidadServida, 2) & dts.gTipoUnidad)
            Else
                .SubItems.Add("")
            End If
            .SubItems.Add(FormatNumber(dts.gCantidadPreparada, 2) & dts.gTipoUnidad)
            .SubItems.Add(If(dts.gVersion = 0, "", CStr(dts.gVersion)))
            If rbPedidoCompleto.Checked Then
                .SubItems.Add(FormatNumber(If(rbPedidoCompleto.Checked, dts.gCantidad - dts.gCantidadServida, 0), 2) & dts.gTipoUnidad) 'Pendiente
            Else
                .SubItems.Add("")
            End If
            ' en naranja las que se han empezado a servir, en verde las servidas y negro que no se ha servido nada. 
            If dts.gCantidadServida > 0 Then
                If dts.gCantidadServida >= dts.gCantidad Then
                    .ForeColor = Color.Green
                Else
                    .ForeColor = Color.Orange
                End If
            Else
                .ForeColor = Color.Black
            End If
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoPedido)
        'Actualizar a partir del índice actual
        If indice <> -1 Then
            With lvConceptos.Items(indice)
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gcodArticuloCli
                .SubItems(4).Text = dts.gArticuloCli
                .SubItems(5).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
                If vvercostes = True Then
                    .SubItems(6).Text = FormatNumber(dts.gPVPUnitario, 2) & dtsOF.gSimbolo
                    .SubItems(7).Text = FormatNumber(dts.gDescuento, 2) & "%"
                    .SubItems(8).Text = FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsOF.gSimbolo
                    .SubItems(9).Text = FormatNumber(dts.gSubTotal, 2) & dtsOF.gSimbolo
                Else
                    .SubItems(6).Text = ""
                    .SubItems(7).Text = ""
                    .SubItems(8).Text = ""
                    .SubItems(9).Text = ""
                End If
                .SubItems(10).Text = dts.gEstado
                .SubItems(11).Text = dts.gCantidadStock & dts.gTipoUnidad
                If rbPedidoCompleto.Checked Then
                    .SubItems(12).Text = FormatNumber(dts.gCantidadServida, 2) & dts.gTipoUnidad
                Else
                    .SubItems(12).Text = ""
                End If

                .SubItems(13).Text = FormatNumber(dts.gCantidadPreparada, 2) & dts.gTipoUnidad
                .SubItems(14).Text = If(dts.gVersion = 0, "", CStr(dts.gVersion))
                If rbPedidoCompleto.Checked Then
                    .SubItems(15).Text = FormatNumber(dts.gCantidad - dts.gCantidadServida, 2) & dts.gTipoUnidad 'PEndiente
                Else
                    .SubItems(15).Text = "" 'PEndiente
                End If

            End With
            Call Recalcular()
        End If
    End Sub

    Private Sub Recalcular()
        semaforo = False
        funcOF.DatosCalculados(dtsOF, rbPedidoPendiente.Checked) 'Recargamos el dtsOF por referencia

        If vvercostes = True Then
            SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
            BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
            TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
            TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
            Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
            Total.Text = FormatNumber(dtsOF.gTotal, 2)
            PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
        Else
            SumaDescuentos.Text = ""
            BaseImponible.Text = ""
            TotalIVA.Text = ""
            TotalRE.Text = ""
            Retencion.Text = ""
            Total.Text = ""
            PrecioTransporte.Text = ""
        End If

        semaforo = True
    End Sub

    Private Function GuardarGeneral()
        Try
            Dim validar As Boolean = True
            If cbCliente.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbCliente, "Debe seleccionar un cliente")
            End If
            If cbDireccion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbDireccion, "Debe seleccionar una dirección")
            End If
            If cbMoneda.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMoneda, "Debe seleccionar una moneda")
            End If
            If cbMedioPago.SelectedIndex = -1 Then
                ep2.SetError(cbMedioPago, "No ha seleccionado un medio de pago")
            Else
                If cbCuenta.Enabled Then
                    If cbCuenta.SelectedIndex = -1 Then
                        ep2.SetError(cbCuenta, "No ha seleccinado una cuenta bancaria")
                    End If
                End If
            End If
            If cbTipoPago.SelectedIndex = -1 Then
                ep2.SetError(cbTipoPago, "No ha seleccionaado un tipo de pago")
            End If
            If cbTipoIVA.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbTipoIVA, "Se ha de seleccionar un tipo de IVA")
            End If
            If cbRetencion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbRetencion, "Se ha de seleccionar un tipo de Retención")
            End If
            If cbEstado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
            End If
            If cbValorado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbValorado, "Se ha de seleccionar como está valorado el pedido")
            End If
            If Not rbPri1.Checked And Not rbPri2.Checked Then
                rbPri2.Checked = True
            End If
            If cbPersona.SelectedIndex = -1 Then
                ep2.SetError(cbPersona, "No se ha seleccionado un comercial")
            End If
            If validar Then
                dtsOF.gnumPedido = numDoc.Text
                dtsOF.gReferenciaCliente = RefCliente.Text
                dtsOF.gReferenciaCliente2 = RefCliente2.Text
                dtsOF.gEstado = cbEstado.Text
                dtsOF.gFecha = dtpFecha.Value.Date
                dtsOF.gFechaEntrega = dtpFechaPrevista.Value
                dtsOF.gidCliente = cbCliente.SelectedItem.itemdata
                dtsOF.gidUbicacion = cbDireccion.SelectedItem.itemdata
                dtsOF.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
                dtsOF.gidMedioPago = If(cbMedioPago.SelectedIndex = -1, 0, cbMedioPago.SelectedItem.gidMEdioPago)
                dtsOF.gidTipoPago = If(cbTipoPago.SelectedIndex = -1, 0, cbTipoPago.SelectedItem.gidTipoPago)
                dtsOF.gidCuentaBanco = If(cbCuenta.SelectedIndex = -1, 0, cbCuenta.SelectedItem.itemdata)
                dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda
                dtsOF.gDescuento = 0
                dtsOF.gDescuento2 = 0
                dtsOF.gProntoPago = If(ProntoPago.Text = "", 0, CDbl(ProntoPago.Text))
                dtsOF.gSolicitadoVia = cbSolicitadoVia.Text
                dtsOF.gNotas = Nota.Text
                dtsOF.gObservaciones = Observaciones.Text
                dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsOF.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
                dtsOF.gTipoValorado = cbValorado.Text
                dtsOF.gidPersona = If(cbPersona.SelectedIndex = -1, 0, cbPersona.SelectedItem.itemdata)
                dtsOF.gPersona = cbPersona.Text
                'Deshabilitar ckSinAlbaran si ya tiene algún albarán (estados SERVIDO, PARCIAL). 
                If dtsOF.gidEstado = estadoPEServido.gidEstado Or dtsOF.gidEstado = estadoPEParcial.gidEstado Then
                    dtsOF.gSinAlbaran = False
                    ckSinAlbaran.Checked = False
                    ckSinAlbaran.Enabled = False
                    ckRecogido.Checked = False
                    ckRecogido.Enabled = False
                Else
                    dtsOF.gSinAlbaran = ckSinAlbaran.Checked
                    dtsOF.gRecogido = ckSinAlbaran.Checked And ckRecogido.Checked
                End If
                Call AsignarDOCDatosClienteNoEditables()

                Dim nuevaPrioridad As Byte = 3
                If rbPri1.Checked Then nuevaPrioridad = 1
                If rbPri2.Checked Then nuevaPrioridad = 2
                If dtsOF.gnumPedido > 0 AndAlso nuevaPrioridad <> dtsOF.gPrioridad Then
                    'Estamos actualizando un pedido y hemos cambiado la prioridad
                    SeHaDePropagarCambioPrioridad = True
                End If
                dtsOF.gPrioridad = nuevaPrioridad
                If PrecioTransporte.Text = "" Then PrecioTransporte.Text = 0
                If cbPortes.Text = "PAGADOS" Then
                    dtsOF.gPortes = "P"
                    dtsOF.gPrecioTransporte = 0
                ElseIf cbPortes.Text = "DEBIDOS" Then
                    dtsOF.gPortes = "D"
                    dtsOF.gPrecioTransporte = 0
                Else
                    dtsOF.gPortes = "I"
                    dtsOF.gPrecioTransporte = PrecioTransporte.Text
                End If
                If cbTransporte.SelectedIndex = -1 Then
                    dtsOF.gidTransporte = 0
                    dtsOF.gTransporte = cbTransporte.Text
                Else
                    If cbTransporte.SelectedItem.itemdata < 1 Then
                        dtsOF.gidTransporte = 0
                        dtsOF.gTransporte = cbTransporte.Text
                    Else
                        dtsOF.gidTransporte = cbTransporte.SelectedItem.itemData
                        dtsOF.gTransporte = ""
                    End If
                End If
                If G_AGeneral = "G" Then
                    numDoc.Text = funcOF.insertar(dtsOF)
                    dtsOF.gnumPedido = numDoc.Text
                    G_AGeneral = "A"
                    MsgBox("Creado el Pedido " & numDoc.Text & ". Ya puede introducir los conceptos.")
                    gbConceptos.Enabled = True
                    cbEstado.Items.Add(estadoPEAnulado)
                    'Debe seguir en estado cabecera
                    '**** AL ANULAR, debe retirar de producción equipos y si están acabados forzar que se liberen
                    SeHaDePropagarCambioPrioridad = False
                ElseIf cbEstado.SelectedItem.gidEstado = estadoPEAnulado.gidEstado Then
                    'Si el estado es Anulado hemos de revisar
                    Dim IDEstadoAnterior As Integer = funcOF.idEstado(numDoc.Text)
                    If IDEstadoAnterior <> estadoPEAnulado.gidEstado AndAlso Not funcOF.bAnulado(numDoc.Text) Then
                        If MsgBox("¿Desea anular el pedido y eliminar de producción todos sus conceptos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            If funcCO.AlgoSERVIDO(numDoc.Text) Then
                                MsgBox("No es posible anular el pedido porque está servido total o parcialmente")
                                cbEstado.Text = funcES.Estado(IDEstadoAnterior)
                                dtsOF.gidEstado = IDEstadoAnterior
                                funcOF.actualizar(dtsOF)
                                Call Recalcular()
                            Else
                                If LiberarConceptos() Then
                                    funcOF.actualizar(dtsOF)
                                    Call Recalcular()
                                    Call CargarConceptos()
                                    ConceptosEditables = False
                                    PreciosConceptosEditables = False
                                    CantidadEditable = False
                                    MsgBox("El pedido queda anulado")
                                End If
                            End If
                        End If
                    Else
                        funcOF.actualizar(dtsOF)
                        Call Recalcular()
                    End If

                Else
                    funcOF.actualizar(dtsOF)
                    Call Recalcular()
                End If
                cambios = False
                ep1.Clear()
                ep2.Clear()
            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarGeneral")
            ex.Data.Add("numdoc.text", numDoc.Text)
            CorreoError(ex)
            Return False
        End Try
    End Function

    Private Function LiberarConceptos() As Boolean
        Dim lista As List(Of DatosConceptoPedido) = funcCO.Mostrar(numDoc.Text)
        Dim PasarEstadoCreado As Boolean = True
        For Each dts As DatosConceptoPedido In lista
            Select Case dts.gidEstado
                Case EstadoCPCreado.gidEstado
                    PasarEstadoCreado = False
                Case EstadoCPProduccion.gidEstado
                    'Borrar de produccion
                    Call BorrarProduccionDeConcepto(dts.gidConcepto)
                Case EstadoCPLogistica.gidEstado
                    'Cambiar a Creado
                Case EstadoCPServido.gidEstado
                    'No se puede
                    PasarEstadoCreado = False
                Case Else 'EstadoCPEnProduccion.gidEstado,EstadoCPProducido.gidEstadoEstadoCPPreparado.gidEstado
                    'Si hay algo acabado, liberar
                    Dim listaIdEQ As List(Of Long) = funcEQ.BusquedaLista(" Estados.Completo = 1 and C1.idConcepto = " & dts.gidConcepto, "") 'Lista de equipos acabados
                    If listaIdEQ.Count = 0 Then 'Si no hay equipos acabados, se eliminan de producción
                        Call BorrarProduccionDeConcepto(dts.gidConcepto)
                    Else
                        Dim iidProduccionAnterior As Integer = funcCR.IdProduccion(dts.gidConcepto)
                        If LiberarAStock(listaIdEQ) Then
                            'Borramos lo restante
                            Call BorrarConceptoProduccion(iidProduccionAnterior)
                        End If
                    End If
            End Select
            If PasarEstadoCreado Then
                funcCO.CambiarEstado(dts.gidConcepto, EstadoCPCreado.gidEstado)
            End If
        Next
        Return lista.Count > 0

    End Function

    Private Function LiberarAStock(ByVal listaidEQ As List(Of Long)) As Boolean
        Try
            'Se crea un concepto de producción para recoger los equipos liberados
            Dim dtsEQ0 As DatosEquipoProduccion = funcEQ.Mostrar1(listaidEQ(0))
            Dim dtsCR As New DatosConceptoProduccion
            dtsCR.gnumAlbaran = 0
            dtsCR.gidArticulo = dtsEQ0.gidArticulo
            dtsCR.gCantidad = listaidEQ.Count
            dtsCR.gidEstado = funcES.EstadoCompleto("PRODUCCION").gidEstado 'Sólo liberamos equipos acabados 
            dtsCR.gidArtCli = 0
            dtsCR.gidConceptoPedido = 0
            dtsCR.gPrioridad = 3
            dtsCR.gFechaPrevista = dtsEQ0.gFechaPrevista
            dtsCR.gFechaFin = dtsEQ0.gFechaPrevista
            dtsCR.gObservaciones = ""
            dtsCR.gidPersona = Inicio.vIdUsuario
            dtsCR.gidProduccion = funcCR.insertar(dtsCR)
            'Dim idSproduccion As New List(Of Long)
            'Dim iidProduccion As Long
            For Each iidEquipo As Long In listaidEQ
                'iidProduccion = funcEQ.idProduccion(iidEquipo)
                'If Not idSproduccion.Contains(iidProduccion) Then 'Guardamos la lista de conceptos de producción afectados
                '    idSproduccion.Add(iidProduccion)
                'End If
                funcEQ.CambiarIdProduccion(iidEquipo, dtsCR.gidProduccion)
            Next
            'Añadir al stock
            Dim dtsAR As DatosArticulo = funcAR.Mostrar1(dtsEQ0.gidArticulo)
            Dim dtsSK As New DatosStock
            dtsSK.gidArticulo = dtsEQ0.gidArticulo
            dtsSK.gidAlmacen = 1
            dtsSK.gCantidad = dtsCR.gCantidad
            dtsSK.gidUnidad = dtsAR.gidUnidad
            dtsSK.gidLote = 0
            dtsSK.gidArticuloProv = 0
            dtsSK.gFecha = Now
            dtsSK.gPrecio = dtsAR.gPrecioUnitarioC
            dtsSK.gcodMoneda = dtsAR.gcodMonedaC
            dtsSK.gidConceptoProv = 0
            dtsSK.gidConceptoAlbaran = 0
            dtsSK.gidProduccion = dtsCR.gidProduccion
            dtsSK.gMovimiento = ""
            dtsSK.gidPersona1 = Inicio.vIdUsuario
            dtsSK.gidPersona2 = 0
            dtsSK.gidConceptoPedido = 0
            Return funcSK.insertar(dtsSK)

            'For Each iidProduccion In idSproduccion
            '    'Modificar el concepto de producción afectado
            '    Dim cantidad As Integer = funcEQ.Contador(iidProduccion)
            '    Dim iidConceptoPedido As Integer = funcCR.IdConceptoPedido(iidProduccion)
            '    If cantidad = 0 Then
            '        'Tendremos que eliminar la producción
            '        funcCR.borrar(iidProduccion)
            '    Else
            '        funcCR.CambiarCantidad(iidProduccion, cantidad)
            '        ActualizarEstadosProduccion(iidProduccion)
            '    End If
            'Next
        Catch ex As Exception
            ex.Data.Add("Función", "LiberarAStock")

            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
        End Try
    End Function

    Private Sub PropagarIVAConceptos(ByVal iidTipoIVAAnterior As Integer)
        If iidTipoIVAAnterior <> dtsOF.gidTipoIVA Then
            funcCO.CambiarTipoIVA(numDoc.Text, dtsOF.gidTipoIVA)
        End If
    End Sub

    Private Function GuardarConcepto() As Boolean
        Dim iidconcepto As Long = 0
        Try
            Dim validar As Boolean = True
            If cbArticulo.Text = "" Then
                validar = False
            End If
            Dim dts As DatosConceptoPedido = CargardtsCO(0)
            If indice <> -1 Then
                iidconcepto = lvConceptos.Items(indice).SubItems(1).Text
            End If

            Dim dtsOriginal As DatosConceptoPedido
            Dim iidProduccion As Long = 0
            Dim Diferencia As Integer = 0
            If iidconcepto > 0 Then
                dtsOriginal = funcCO.Mostrar1(iidconcepto)
                Diferencia = dtsOriginal.gCantidad - dts.gCantidad
            Else
                dtsOriginal = New DatosConceptoPedido
            End If

            If validar And indice <> -1 Then
                'si existe, precargamos el concepto

                dts = CargardtsCO(iidconcepto) ' funcCO.Mostrar1(iidconcepto)
                Dim EstadoCo As DatosEstado = funcES.Mostrar1(funcCO.idEstado(iidconcepto))

                If ConceptosEditables Then
                    iidProduccion = funcCR.IdProduccion(iidconcepto)
                    If EstadoCo.gEspera And Not EstadoCo.gEnCurso Then 'Logistica, Creado


                    ElseIf EstadoCo.gEspera And EstadoCo.gEnCurso Then 'Enviado a Producción
                        If dts.gidArticulo <> dtsOriginal.gidArticulo Then
                            validar = False
                            MsgBox("En estado " & dts.gEstado & " no se puede cambiar el artículo.")
                        ElseIf dts.gCantidad > dtsOriginal.gCantidad Then
                            MsgBox("No se puede especificar una cantidad mayor en estado " & EstadoCo.gEstado)
                            validar = False
                        Else
                            'Será editable la Cantidad, precio o descuento
                        End If
                    ElseIf Not EstadoCo.gEspera And EstadoCo.gEnCurso Then 'Producción

                        If dts.gCantidad > dtsOriginal.gCantidad Then
                            MsgBox("No se puede especificar una cantidad mayor en estado " & EstadoCo.gEstado)
                            validar = False
                        Else

                            Dim Pendientes As Integer = dtsOriginal.gCantidad - funcEQ.CuantosAcabados(iidProduccion)
                            If Diferencia > Pendientes Then
                                MsgBox("Sólo quedan " & Pendientes & " Equipos pendientes para completar. No puede reducir la cantidad en " & Diferencia & " unidades.")
                                validar = False
                            Else
                                'Será editable la Cantidad, precio o descuento
                            End If
                        End If

                    ElseIf EstadoCo.gCompleto Then 'Preparado o Producido
                        If MismoArticuloYCantidad(dts) Then
                            'Será editable precio o descuento
                        Else
                            If dts.gCantidad > dtsOriginal.gCantidad Then
                                validar = False
                                MsgBox("En estado " & dts.gEstado & " sólo se puede cambiar el precio o el descuento." & vbCrLf & "Para una cantidad mayor, puede añadir una linea con la cantidad restante.")
                            Else
                                validar = False
                                If funcAR.Escandallo(dts.gidArticulo) Then
                                    If MsgBox("Todas las unidades están producidas." & vbCrLf & "¿Desea liberar unidades de este pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                        Dim GG As New ReasignarEquipos
                                        GG.pnumPedidoActual = numDoc.Text
                                        GG.pidArticulo = dts.gidArticulo
                                        GG.ShowDialog()
                                        If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                                            Call CargarPedido()
                                        End If
                                    End If
                                Else
                                    validar = False
                                    MsgBox("En estado " & dts.gEstado & " sólo se puede cambiar el precio o el descuento.")
                                End If

                            End If
                        End If

                    Else  'Servido
                        validar = False
                        MsgBox("En estado " & dts.gEstado & " no se puede modificar.")
                    End If

                Else
                    'Estamos en el caso de Precios Editables, ahora comprobamos que el concepto no esté ya servido
                    If EstadoCo.gEntregado Then
                        validar = False
                        MsgBox("No se puede modificar una linea de pedido en estado " & EstadoCo.gEstado)
                    ElseIf Not MismoArticuloYCantidad(dts) Then
                        validar = False
                        MsgBox("En estado " & dts.gEstado & " sólo se puede cambiar el precio o el descuento.")
                    End If
                End If
            End If

            If Not IsNumeric(Cantidad.Text) Then Cantidad.Text = 0
            If validar And Cantidad.Text = 0 And Not bBorrar.Enabled And iidconcepto > 0 And ConceptosEditables Then
                If MsgBox("¿Desea borrar la linea con cantidad 0?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    'Borrar concepto
                    Dim EstadoCo As DatosEstado = funcES.Mostrar1(funcCO.idEstado(iidconcepto))
                    Call BorrarConcepto(iidconcepto, EstadoCo)
                    validar = False
                End If
            End If

            If validar Then


                Dim iidArtCli As Integer = 0
                Dim dtsAC As New DatosArticuloCliente
                Dim dtsACP As DatosArticuloClientePrecio


                If iidArticulo = 0 Then
                    dts.gidArticulo = 0
                    iidArticulo = 0
                Else

                    dts.gidArticulo = iidArticulo
                    dtsAC = New DatosArticuloCliente
                    dtsAC.gidArticulo = iidArticulo
                    dtsAC.gidCliente = cbCliente.SelectedItem.itemdata
                    dtsAC.gArticuloCli = dts.gArticuloCli
                    dtsAC.gcodArticulo = dts.gcodArticulo
                    dtsAC.gcodArticuloCli = dts.gcodArticuloCli
                    dtsAC.gDescuento = dts.gDescuento
                    dtsAC.gFechaAlta = Now.Date
                    dtsAC.gFechaBaja = Now.Date
                    dtsAC.gActivo = True
                    dtsAC.gnumDoc = numDoc.Text
                    dtsAC.gtipoDoc = "PEDIDO"
                    dtsAC.gPrecioNetoUnitario = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
                End If

                Dim SoloReferenciaDoc As Boolean = False
                If indice = -1 Then
                    'Hemos de guardar un nuevo concepto
                    dts.gTipoUnidad = If(iidArticulo = 0, lbUnidad.Text, dtsAR.gTipoUnidad)
                    ' Dim estado As DatosEstado = funcES.EstadoCPedido("CREADO")
                    dts.gidEstado = EstadoCPCreado.gidEstado 'estado.gidEstado
                    dts.gEstado = EstadoCPCreado.gEstado 'estado.gEstado
                    'Si ha habido cambio, hemos de guardar los cambios en ArticuloCliente
                    If dts.gidArticulo > 0 Then 'Siempre que hayamos seleccionado un artículo
                        iidArtCli = funcAC.Existe(iidArticulo, iidCliente)
                        If iidArtCli > 0 Then
                            dtsAC.gIdArtCli = iidArtCli
                            SoloReferenciaDoc = CompruebaACCambio(dtsAC)
                            funcAC.actualizar(dtsAC, SoloReferenciaDoc)
                        Else
                            If CompruebaACigual() Then
                                iidArtCli = funcAC.insertar(dtsAC)

                            End If
                        End If
                    End If
                    dts.gidArtCli = iidArtCli
                    dts.gidConceptoOferta = 0
                    dts.gidConceptoProforma = 0
                    dts.gCantidadServida = 0
                    dts.gidConcepto = funcCO.insertar(dts)
                    Call nuevaLineaLV(dts)
                    If lvConceptos.Items.Count > 0 Then 'Si hay items, modificar el estado del pedido

                        Me.Text = "EDITAR PEDIDO CLIENTE"
                        'cbEstado.SelectedIndex = -1
                        'cbEstado.Text = ""

                        If cbEstado.SelectedItem.gidEstado = estadoPECabecera.gidEstado Then 'Si estaba en Cabecera, lo ponemos en pendiente, en otro caso no cambiamos el estado
                            If cbEstado.FindString(estadoPEPendiente.gEstado) = -1 Then cbEstado.Items.Add(estadoPEPendiente)
                            cbEstado.Text = estadoPEPendiente.ToString
                            funcOF.actualizaEstado(numDoc.Text, estadoPEPendiente.gidEstado)
                        End If
                        Dim x As Integer = cbEstado.FindString(estadoPECabecera.gEstado)
                        If x <> -1 Then cbEstado.Items.RemoveAt(x) 'Eliminar el estado cabecera
                        ConceptosEditables = True
                    End If
                Else
                    If Diferencia > 0 And iidProduccion > 0 Then
                        MsgBox("Se va a actualizar la cantidad y realizar las modificaciones correspondientes en la producción y el stock si procede.")
                    End If
                    'actualizar concepto
                    dts.gTipoUnidad = dtsCO.gTipoUnidad
                    dts.gidConcepto = lvConceptos.Items(indice).SubItems(1).Text
                    iidArtCli = funcAC.Existe(iidArticulo, iidCliente)
                    If dts.gidArticulo = 0 Then
                        iidArtCli = 0
                    Else
                        If iidArtCli > 0 Then
                            dtsAC.gIdArtCli = iidArtCli
                            SoloReferenciaDoc = CompruebaACCambio(dtsAC)
                            funcAC.actualizar(dtsAC, SoloReferenciaDoc)
                        Else
                            If CompruebaACigual() Then
                                iidArtCli = funcAC.insertar(dtsAC)
                            End If
                        End If
                    End If
                    dts.gidArtCli = iidArtCli
                    funcCO.actualizar(dts)
                    'Dim Diferencia As Integer = dtsOriginal.gCantidad - dts.gCantidad
                    If Diferencia > 0 Then
                        'Se ha de propagar el cambio en producción y stock
                        For n = 1 To Diferencia
                            funcCO.EliminarItem(iidProduccion)
                        Next
                        funcSK.EliminarItemDelStock(iidconcepto, iidProduccion, dtsOriginal.gCantidad, Diferencia)

                    End If
                    Call ActualizarLineaLV(dts)

                End If
                'Guardar el precio específico si ha cambiado
                If Not SoloReferenciaDoc And iidArtCli > 0 Then
                    dtsACP = funcACP.mostrarArtCli(iidArtCli)
                    Dim precioNetoUnitario As Double = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
                    If dtsACP.gidArtCli = iidArtCli And dtsACP.gPrecioNetoUnitario = precioNetoUnitario And dtsACP.gcodMoneda = dtsOF.gcodMoneda Then
                    Else

                        dtsACP.gidArtCli = iidArtCli
                        dtsACP.gPrecioNetoUnitario = precioNetoUnitario
                        dtsACP.gActivo = True
                        dtsACP.gcodMoneda = dtsOF.gcodMoneda

                        funcACP.Desactivar(iidArtCli)
                        If precioNetoUnitario <> 0 Then
                            'Si el precio es 0 no lo guardamos
                            funcACP.insertar(dtsACP)
                        End If

                    End If
                End If

                Call Recalcular()
                Call CalculoFechaEntrega()
                funcOF.actualizaFechaEntrega(numDoc.Text, dtpFechaPrevista.Value.Date)
                Call LimpiarEdicion()

            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarConcepto")
            ex.Data.Add("numdoc.text", numDoc.Text)
            ex.Data.Add("iidConcepto", iidconcepto)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
            Return False
        End Try
    End Function

    Private Function MismoArticuloYCantidad(ByVal dtsNuevo As DatosConceptoPedido) As Boolean
        Dim dtsORiginal As DatosConceptoPedido = funcCO.Mostrar1(dtsNuevo.gidConcepto)
        If dtsORiginal.gidArticulo = dtsNuevo.gidArticulo And dtsORiginal.gCantidad = dtsNuevo.gCantidad Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function MismoArticulo(ByVal dtsNuevo As DatosConceptoPedido) As Boolean
        Dim dtsORiginal As DatosConceptoPedido = funcCO.Mostrar1(dtsNuevo.gidConcepto)
        If dtsORiginal.gidArticulo = dtsNuevo.gidArticulo Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CargardtsCO(ByVal iidConcepto As Long) As DatosConceptoPedido
        Dim dts As DatosConceptoPedido
        If iidConcepto = 0 Then
            dts = New DatosConceptoPedido
            dts.gidConcepto = 0
            dts.gnumAlbaran = 0
            dts.gnumProduccion = 0
        Else
            dts = funcCO.Mostrar1(iidConcepto)
        End If

        dts.gnumPedido = numDoc.Text
        If indice = -1 And codArticuloCli.Text = "" And cbCodArticulo.Text <> "" Then
            dts.gcodArticuloCli = cbCodArticulo.Text 'Asignar el codArticuloCli como el codArticulo
        Else
            dts.gcodArticuloCli = codArticuloCli.Text
        End If
        dts.gcodArticulo = cbCodArticulo.Text
        dts.gArticuloCli = cbArticulo.Text
        dts.gRefCliente = ""
        If Cantidad.Text = "" Or Cantidad.Text = "-" Or Cantidad.Text = "," Or Cantidad.Text = "." Then Cantidad.Text = 0
        dts.gCantidad = Cantidad.Text
        dts.gPVPUnitario = If(PVP.Text = "", 0, CDbl(PVP.Text))
        dts.gidTipoIVA = dtsOF.gidTipoIVA
        dts.gDescuento = If(DescuentoC.Text = "", 0, CDbl(DescuentoC.Text))
        dts.gPrecioNetoUnitario = PrecioNeto.Text
        dts.gOrden = indice + 1
        dts.gCantidadStock = Stock.Text
        dts.gidArticulo = iidArticulo
        dts.gVersion = If(cbVersion.SelectedIndex = -1 Or Not IsNumeric(cbVersion.Text), 0, CInt(cbVersion.Text))
        Return dts
    End Function

    Private Function CompruebaACCambio(ByVal dts As DatosArticuloCliente) As Boolean
        Dim SoloReferenciaDoc As Boolean = False
        Dim dtsAC As DatosArticuloCliente = funcAC.mostrar1(dts.gIdArtCli)
        Dim texto As String = ""
        If dts.gDescuento <> dtsAC.gDescuento Then texto = "Descuento"
        If dts.gPrecioNetoUnitario <> dtsAC.gPrecioNetoUnitario Then texto = texto & If(texto = "", "", ", ") & "Precio Neto"
        If dts.gcodArticuloCli <> dtsAC.gcodArticuloCli Then texto = texto & If(texto = "", "", ", ") & "Código Artículo/Cliente"
        If dts.gArticuloCli <> dtsAC.gArticuloCli Then texto = texto & If(texto = "", "", ", ") & "Descripción"
        If texto = "" Then
            SoloReferenciaDoc = True
        Else
            texto = "Se han detectado cambios de las especificaciones del artículo para el cliente en los campos: " & texto & "." & vbCrLf & "¿Desea guardar los cambios en Artículo-Cliente?"
            If MsgBox(texto, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SoloReferenciaDoc = False
            Else
                SoloReferenciaDoc = True
            End If
        End If
        Return SoloReferenciaDoc
    End Function

    Private Function CompruebaACigual() As Boolean
        'Comprobamos si los datos de personalización del artículo para el cliente son identicos a los del artículo genérico
        'Devuelve True cuando los datos son diferentes y se ha de guardar
        If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
        If PrecioNeto.Text > 0 Then
            Return True
        Else
            If dtsAR Is Nothing OrElse dtsAR.gidArticulo <> iidArticulo Then dtsAR = funcAR.Mostrar1(iidArticulo)

            If codArticuloCli.Text = dtsAR.gcodArticulo And cbArticulo.Text = dtsAR.gArticulo Then
                If (dtsAR.gDescuento1 And DescuentoC.Text = dtsFA.gDescuento) Or (dtsAR.gDescuento2 And DescuentoC.Text = dtsFA.gDescuento2) Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If

        End If

    End Function

    Private Sub CargarEdicion()
        'Carga el concepto en la zona de edición
        If indice <> -1 Then
            semaforo = False
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            dtsCO = funcCO.Mostrar1(iidConcepto)
            iidArticulo = dtsCO.gidArticulo
            cbTipo.Text = dtsCO.gTipoArticulo
            Call IntroducirSubTiposArticulo()
            cbSubTipo.Text = dtsCO.gSubTipoArticulo
            Call CargarArticulosC()
            cbCodArticulo.Text = dtsCO.gcodArticulo
            cbArticulo.Text = dtsCO.gArticuloCli
            codArticuloCli.Text = dtsCO.gcodArticuloCli
            lbUnidad.Text = dtsCO.gTipoUnidad
            Stock.Text = dtsCO.gCantidadStock
            Call CargarVersiones(iidArticulo)
            cbVersion.Text = If(dtsCO.gVersion = 0, "", CStr(dtsCO.gVersion))
            cbVersion.Enabled = funcAR.conVersiones(iidArticulo) 'funcAR.Escandallo(iidArticulo)
            Cantidad.Text = dtsCO.gCantidad
            If vvercostes = True Then
                PVP.Text = FormatNumber(dtsCO.gPVPUnitario, 2)
                PrecioNeto.Text = FormatNumber(dtsCO.gPrecioNetoUnitario, 2)
                subTotal.Text = FormatNumber(dtsCO.gSubTotal, 2)
                DescuentoC.Text = dtsCO.gDescuento
            Else
                PVP.Text = ""
                PrecioNeto.Text = ""
                subTotal.Text = ""
                DescuentoC.Text = ""
            End If
            semaforo = True
        End If
    End Sub

    Private Sub CargarVersiones(ByVal iidArticulo)
        cbVersion.Items.Clear()
        If iidArticulo > 0 Then
            If funcAR.conVersiones(iidArticulo) Then 'funcAR.Escandallo(iidArticulo) Then
                cbVersion.Enabled = True
                Dim iidArticuloBase As Integer = funcEC.idArticuloBaseArticulo(iidArticulo)
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
            Else
                cbVersion.Enabled = False
            End If
        End If
    End Sub

    Private Sub GenerarProducciones()
        Dim dts As DatosConceptoPedido
        For Each item As ListViewItem In lvConceptos.CheckedItems
            Dim iidConcepto As Long = item.SubItems(1).Text
            dts = funcCO.Mostrar1(iidConcepto)
            If dts.gCantidadStock = 0 Then
            Else

            End If

        Next
    End Sub

    Private Sub CalculoFechaEntrega()
        Dim prioridad As Byte = 3
        If rbPri1.Checked Then
            prioridad = 1
        ElseIf rbPri2.Checked Then
            prioridad = 2
        End If
        If G_AGeneral = "G" Then
            dtpFechaPrevista.Value = funcCR.FechaInicioTrabajo(prioridad)
        Else
            dtpFechaPrevista.Value = funcCR.FechaFinTrabajo(prioridad, funcCO.CargaTrabajo(numDoc.Text))
        End If

    End Sub

    Private Sub DatosDireccion()
        dtsUB = funcUB.mostrar1(cbDireccion.SelectedItem.itemdata)
        PrecioTransporte.Enabled = False
        If dtsUB.gPortes = "P" Then cbPortes.Text = "PAGADOS"
        If dtsUB.gPortes = "D" Then cbPortes.Text = "DEBIDOS"
        If dtsUB.gPortes = "I" Then
            cbPortes.Text = "INC.FRA."
            'Cargar el importe del último documento
            'PrecioTransporte.Text = FormatNumber(funcOF.UltimoPrecioTransporte(iidCliente), 2)
            PrecioTransporte.Enabled = True
        End If
        If dtsUB.gidTransporte = 0 Then
            cbTransporte.Text = dtsUB.gTransporte
        Else
            cbTransporte.Text = dtsUB.gAgenciaTransporte
        End If
    End Sub

    Public Sub DescuentaStock(ByVal Cant As Integer, ByVal iidEscandallo As Integer, ByVal iidConceptoPedido As Long)
        'Descuenta del stock los componentes del equipo, actúa de forma recursiva con los artículos que tienen escandallo
        Dim lista As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(iidEscandallo, True, 0)
        Dim dtsSK As DatosStock
        Dim dtsAP As DatosArticuloPrecio
        For Each dts As DatosConceptoEscandallo In lista
            If dts.gExisteEscandallo > 0 Then
                DescuentaStock(Cant * dts.gCantidad, dts.gExisteEscandallo, iidConceptoPedido)
            Else
                dtsAP = funcAP.Precio(dts.gidArticulo, "C")
                dtsSK = New DatosStock
                dtsSK.gCantidad = -dts.gCantidad * Cant
                dtsSK.gcodMoneda = dtsAP.gcodMoneda 'sCodMonedaC
                dtsSK.gFecha = Now
                dtsSK.gidAlmacen = 0
                dtsSK.gidArticulo = dts.gidArticulo
                dtsSK.gidArticuloProv = 0
                dtsSK.gidConceptoAlbaran = 0
                dtsSK.gidConceptoPedido = iidConceptoPedido
                dtsSK.gidConceptoProv = 0
                dtsSK.gidLote = 0
                dtsSK.gidPersona1 = Inicio.vIdUsuario
                dtsSK.gidPersona2 = 0
                dtsSK.gidProduccion = 0
                dtsSK.gidUnidad = dts.gidTipoUnidad
                dtsSK.gMovimiento = ""
                dtsSK.gPrecio = dtsAP.gPrecio 'dPrecioUnitarioC
                dtsSK.gSimbolo = dtsAP.gSimbolo

                dtsSK.gidStock = funcSK.insertar(dtsSK)
            End If

        Next
    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL - 1
                    numDoc.Text = Pedidos(indiceL)
                    Call CargarPedido()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                numDoc.Text = Pedidos(indiceL)
                Call CargarPedido()
            End If


        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Pedidos.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    numDoc.Text = Pedidos(indiceL)
                    Call CargarPedido()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                numDoc.Text = Pedidos(indiceL)
                Call CargarPedido()
            End If


        End If
    End Sub

    Private Sub bMediosPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMediosPago.Click
        Dim valor As String = cbMedioPago.Text
        Dim GG As New gestionmediodepago
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirMediosPago()
        cbMedioPago.Text = valor
        If cbMedioPago.SelectedIndex = -1 Then cbMedioPago.Text = ""
    End Sub

    Private Sub bTiposIVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim valor As String = cbTipoIVA.Text
        Dim GG As New GestionTiposIVA
        GG.SoloLectura = True
        GG.ShowDialog()
        Call introducirTiposIVA()
        cbMedioPago.Text = valor
        If cbMedioPago.SelectedIndex = -1 Then cbMedioPago.Text = ""
    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            iidCliente = cbCliente.SelectedItem.itemdata
            Dim cliente As String = cbCliente.Text
            Dim codcli As Integer = cbCodCliente.Text
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = iidCliente
            GG.ShowDialog()
            If GG.pidCliente = iidCliente Then
                dtsCL = funcCL.mostrar1(iidCliente)
            End If
            If ClienteSoloLectura Then
                cbCliente.Items.Clear()
                cbCodCliente.Items.Clear()
                cbCodCliente.Items.Add(New IDComboBox(dtsCL.gcodCli, dtsCL.gidCliente))
                cbCliente.Items.Add(New IDComboBox(dtsCL.gnombrecomercial, dtsCL.gidCliente))
                cbCliente.SelectedIndex = 0
            Else
                Call introducirClientes()
                cbCliente.Text = dtsCL.gnombrecomercial
                cbCodCliente.Text = dtsCL.gcodCli
                If cbCliente.SelectedIndex = -1 Then
                    cbCliente.Text = ""
                    cbCodCliente.Text = ""
                End If
            End If

            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call AsignarDOCDatosClienteNoEditables()
            Call PropagarIVAConceptos(funcOF.idTipoIVA(numDoc.Text))
            Call Recalcular()
            Call CargarCombosCliente()

        End If

    End Sub

    Private Sub bBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarCliente.Click
        Dim GG As New busquedaCliente
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidCliente > 0 Then
            iidCliente = GG.pidCliente
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            cbCliente.Text = dtsCL.gnombrecomercial
            Call CambioCliente()
        End If
    End Sub

    Private Sub bTiposPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposPago.Click
        Dim tipopago As String = cbTipoPago.Text
        Dim GG As New gestiontipopago
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirTiposPago()
        cbTipoPago.Text = tipopago
        If cbTipoPago.SelectedIndex = -1 Then cbTipoPago.Text = ""
    End Sub

    Private Sub bTiposRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim retencion As String = cbRetencion.Text
        Dim GG As New GestionTiposRetencion
        GG.SoloLectura = True
        GG.ShowDialog()
        Call introducirTiposRetencion()
        cbRetencion.Text = retencion
        If cbRetencion.SelectedIndex = -1 Then cbRetencion.Text = ""
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        'Hay que detectar si borramos el documento o la linea
        If indice = -1 Then
            'Borrar Pedido
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Pedido, es como pulsar nuevo
                If cambios Then
                    If MsgBox("Se perderán los los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Call InicializarGeneral()
                        Call Nuevo()
                    End If
                Else
                    Call InicializarGeneral()
                    Call Nuevo()
                End If
            Else
                If MsgBox("No es posible borrar una Pedido existente. ¿Desea anularla?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    'Dim dtsES As DatosEstado = funcES.EstadoAnulado("Pedido")
                    cbEstado.Text = estadoPEAnulado.gEstado 'dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, estadoPEAnulado.gidEstado) 'dtsES.gidEstado)
                    bGuardar.Enabled = False
                    'bBorrar.Enabled = False
                End If
            End If
        Else
            'Borrar concepto
            If ConceptosEditables Then
                Dim iidConcepto As Long = lvConceptos.Items(indice).SubItems(1).Text
                If lvConceptos.Items(indice).SubItems(10).Text = "CREADO" Or lvConceptos.Items(indice).SubItems(10).Text = "LOGISTICA" Then
                    If MsgBox("¿Está seguro que quiere borrar este concepto del pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If iidConcepto > 0 Then
                            Dim EstadoCo As DatosEstado = funcES.Mostrar1(funcCO.idEstado(iidConcepto))
                            Call BorrarConcepto(iidConcepto, EstadoCo)
                            Call CalculoFechaEntrega()
                            funcOF.actualizaFechaEntrega(numDoc.Text, dtpFechaPrevista.Value.Date)
                        End If
                    End If
                Else
                    MsgBox("Solo se pueden borrar conceptos en estado 'CREADO' y 'LOGÍSTICA'.", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub BorrarConcepto(ByVal iidConcepto As Long, ByVal EstadoCo As DatosEstado)

        If EstadoCo.gEspera Or (funcCO.Cantidad(iidConcepto) = 0 And iidConcepto > 0) Then
            Dim Borrar As Boolean = True
            If EstadoCo.gEnCurso Then
                Borrar = BorrarProduccion(iidConcepto)
            End If
            If Borrar Then
                funcCO.borrar(iidConcepto, numDoc.Text)
                lvConceptos.Items.RemoveAt(indice)
                Call LimpiarEdicion()
                If lvConceptos.Items.Count = 0 Then
                    'Si no hay ningún concepto, pasamos al estado CABECERA y sólo puede hacer ese estado y el ANULADO
                    cbEstado.Items.Clear()
                    cbEstado.Items.Add(estadoPEAnulado) 'funcES.EstadoAnulado("Pedido"))
                    'Dim dtsES As DatosEstado = funcES.EstadoCabecera("Pedido")
                    cbEstado.Items.Add(estadoPECabecera) 'dtsES)
                    cbEstado.Text = estadoPECabecera.gEstado ' dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, estadoPECabecera.gidEstado) 'dtsES.gidEstado)
                ElseIf cbEstado.SelectedItem.gidestado = estadoPEParcial.gidEstado Then
                    If funcCO.TodosTraspasados(numDoc.Text) Then
                        cbEstado.Items.Clear()
                        cbEstado.Items.Add(estadoPEServido)
                        cbEstado.Text = estadoPEServido.gEstado
                        funcOF.actualizaEstado(numDoc.Text, estadoPEServido.gidEstado)
                    End If
                End If
                Call Recalcular()
            End If
        Else
            MsgBox("No se puede borrar la linea en estado " & EstadoCo.gEstado)
        End If
    End Sub

    Private Function BorrarProduccion(ByVal iidConcepto As Long) As Boolean
        'Estado PRODUCCIÓN. Significa que se ha creado el Concepto de Producción, los equipos y sus componentes y se han sacado del stock los componentes.
        If MsgBox("Este concepto de pedido se ha enviado a producción. ¿Desea retirarlo de producción y borrarlo?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Return BorrarProduccionDeConcepto(iidConcepto)
        Else
            Return False
        End If
    End Function

    Private Function BorrarProduccionDeConcepto(ByVal iidConcepto As Long) As Boolean
        Dim iidProduccion As Integer = funcCR.IdProduccion(iidConcepto)
        Return BorrarConceptoProduccion(iidProduccion)
    End Function

    Private Function BorrarConceptoProduccion(ByVal iidProduccion As Long) As Boolean
        If iidProduccion > 0 Then
            funcSK.borrarProduccion(iidProduccion)
            If funcCEQ Is Nothing Then funcCEQ = New FuncionesConceptosEquiposProduccion
            Dim listaEQ As List(Of Long) = funcEQ.Listar(iidProduccion)
            For Each iidEquipo As Long In listaEQ
                funcCEQ.borrarEquipo(iidEquipo)
                funcEQ.borrar(iidEquipo)
            Next
            Return funcCR.borrar(iidProduccion)
        Else
            Return False
        End If
    End Function

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If cbArticulo.Text <> "" Then
            Call LimpiarEdicion()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará un nuev pedido. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará un nuevo pedido. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            End If
        End If
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        SeHaDePropagarCambioPrioridad = False
        Dim iidTipoIVAAnterior As Integer = 0
        If G_AGeneral = "A" Then
            iidTipoIVAAnterior = funcOF.idTipoIVA(numDoc.Text)
        End If
        If cambios Then GuardarGeneral()
        If ConceptosEditables Or PreciosConceptosEditables Or CantidadEditable Then
            If cbArticulo.Text <> "" Then Call GuardarConcepto()
            Call PropagarIVAConceptos(iidTipoIVAAnterior)
        ElseIf PreciosConceptosEditables Then
        End If
        If SeHaDePropagarCambioPrioridad AndAlso funcCO.AlgunoProducible(numDoc.Text) Then Call PropagarCambiosPrioridad()
    End Sub

    Private Sub PropagarCambiosPrioridad()
        If MsgBox("¿Propagar el cambio de prioridad a las producciones de equipos?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If Not dtsOF Is Nothing Then
                For Each item As ListViewItem In lvConceptos.Items
                    funcCR.CambiarPrioridad(item.SubItems(1).Text, dtsOF.gPrioridad)
                Next
            End If
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bTraspasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTraspasar.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el pedido")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            If cambios Then
                'MsgBox("Hay cambios pendientes de guardar")
                Call GuardarGeneral()
            End If
            Dim N As Integer = lvConceptos.CheckedItems.Count
            If ckSeleccion.Visible And N > 0 Then
                Dim Conceptos As New List(Of Long)
                Dim iidConcepto As Integer
                Dim AbrirSubProduccion As Boolean = False
                Dim AlgunoLogistica As Boolean = False
                For Each item As ListViewItem In lvConceptos.CheckedItems
                    iidConcepto = item.SubItems(1).Text
                    'Verificamos que la linea no haya sido ya servida

                    If funcCO.Entregado(iidConcepto) Then 'En el caso de pedido verificamos que no se haya servido 
                        item.Checked = False
                    Else
                        Conceptos.Add(iidConcepto)
                    End If
                Next
                N = N - lvConceptos.CheckedItems.Count
                If N = 1 Then
                    MsgBox("Se ha desactivado un concepto que ya ha sido servido previamente.")
                End If
                If N > 1 Then
                    MsgBox("Se han desactivado " & N & " conceptos que ya han sido servidos previamente.")
                End If
                If Conceptos.Count = 0 Then
                    If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
                Else
                    Dim SC As New SeleccionConvertirP
                    SC.pAlbaran = Not ckSinAlbaran.Checked
                    SC.pProduccion = funcCO.AlgunoCREADO(numDoc.Text)
                    If SC.pAlbaran Or SC.pProduccion Then
                        SC.vGestionPedidos = True
                        SC.vVistaSimple = False
                        SC.ShowDialog()
                    Else
                        MsgBox("Pedido sin albarán y ya producido")
                    End If

                    If SC.pProduccion Then
                        Conceptos.Clear()
                        N = lvConceptos.CheckedItems.Count
                        Dim Texto As String = ""
                        'Eliminamos de la lista los que y estén en alguna fase de producción (o sea, dejamos sólo los CREADOS)
                        For Each item As ListViewItem In lvConceptos.CheckedItems
                            iidConcepto = item.SubItems(1).Text
                            If funcCO.Creado(iidConcepto) Then
                                Conceptos.Add(iidConcepto)
                            Else
                                item.Checked = False
                            End If
                        Next
                        N = N - lvConceptos.CheckedItems.Count
                        If N = 1 Then
                            MsgBox("Se ha desactivado un concepto que ya ha sido enviado a producción previamente.")
                        End If
                        If N > 1 Then
                            MsgBox("Se han desactivado " & N & " conceptos que ya han sido enviados a producción previamente.")
                        End If
                        If Conceptos.Count = 0 Then
                            If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
                        Else
                            N = Conceptos.Count
                            'Verificamos que tengan escandallo para poder ser producidos
                            For Each item As ListViewItem In lvConceptos.CheckedItems
                                iidArticulo = funcCO.idArticulo(item.SubItems(1).Text)
                                If funcAR.Escandallo(iidArticulo) Then 'Artículo marcado como Escandallo
                                    If funcCO.Escandallo(item.SubItems(1).Text) Then 'Existe entrada del artículo en la tabla Escandallos
                                        'Ahora verificaremos si tiene articulo base y en ese caso si este tiene escandallo
                                        Dim iidArticuloBase As Integer = funcEC.idArticuloBaseArticulo(iidArticulo)
                                        If iidArticuloBase > 0 Then
                                            If funcEC.ExisteEscandalloRealmente(iidArticuloBase) Then
                                                AbrirSubProduccion = True
                                            Else
                                                'Tiene artículo base pero este no tiene escandallo
                                                Texto = " el artículo base no dispone de escandallo"
                                                item.Checked = False
                                                Conceptos.Remove(item.SubItems(1).Text)
                                            End If
                                        Else
                                            If funcEC.ExisteEscandalloRealmente(iidArticulo) Then
                                                'Si tiene escandallo pero no tiene nada en las vistas ELECTRÓNICA ni TALLER, lo tratamos como si no tuviera escandallo y lo enviamos a logística
                                                If funcEC.VistaTaller(iidArticulo) = False And funcEC.VistaElectronica(iidArticulo) = False Then
                                                    'AbrirSubProduccion = False
                                                    Conceptos.Remove(item.SubItems(1).Text)
                                                    funcCO.CambiarEstado(item.SubItems(1).Text, EstadoCPLogistica.gidEstado) 'funcES.EstadoCPedido("ENVIADO PRODUCCION").gidEstado)
                                                    'El pedido queda en estado PRODUCCIÓN
                                                    funcOF.actualizaEstado(numDoc.Text, estadoPEProduccion.gidEstado)
                                                    'Descontamos del stock los componentes del desglose
                                                    Dim dtsCO As DatosConceptoPedido = funcCO.Mostrar1(item.SubItems(1).Text)
                                                    Call DescuentaStock(dtsCO.gCantidad - dtsCO.gCantidadServida, funcEC.ExisteEscandallo(iidArticulo), item.SubItems(1).Text)
                                                    AlgunoLogistica = True
                                                Else
                                                    AbrirSubProduccion = True
                                                End If

                                            Else
                                                'No existe el escandallo o no tiene componentes
                                                Texto = "No dispone de Escandallo"
                                                item.Checked = False
                                                Conceptos.Remove(item.SubItems(1).Text)
                                            End If

                                        End If

                                    Else
                                        'No existe el escandallo o no tiene componentes
                                        Texto = "No dispone de Escandallo"
                                        item.Checked = False
                                        Conceptos.Remove(item.SubItems(1).Text)

                                    End If
                                Else
                                    'Si el artículo no está marcado como escandallo
                                    'Lo quitamos de la lista y lo enviamos a Logística
                                    Conceptos.Remove(item.SubItems(1).Text)
                                    funcCO.CambiarEstado(item.SubItems(1).Text, EstadoCPLogistica.gidEstado) 'funcES.EstadoCPedido("ENVIADO PRODUCCION").gidEstado)
                                    'El pedido queda en estado PRODUCCIÓN
                                    funcOF.actualizaEstado(numDoc.Text, estadoPEProduccion.gidEstado)
                                    AlgunoLogistica = True
                                End If
                            Next
                            N = N - lvConceptos.CheckedItems.Count
                            If N = 1 Then
                                MsgBox("Se ha desactivado un concepto que no se puede producir por no disponer de escandallo del artículo o de su artículo base.")
                            End If
                            If N > 1 Then
                                MsgBox("Se han desactivado " & N & " conceptos que no se pueden producir por no disponer de escandallo del artículo o de su artículo base.")
                            End If
                            If Conceptos.Count = 0 Then
                                If Not AlgunoLogistica Then If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
                            ElseIf AbrirSubProduccion Then
                                Dim GG As New subPedidoStock1
                                GG.pConceptos = Conceptos
                                GG.SoloLectura = vSoloLectura
                                'GG.pPrioridad = dtsOF.gPrioridad
                                GG.pDtsPE = dtsOF
                                GG.ShowDialog()
                            End If
                        End If
                    End If
                    If SC.pAlbaran Then
                        Dim avisoNoPreparadas As Boolean = False
                        For Each item As ListViewItem In lvConceptos.CheckedItems
                            If funcCO.CantidadPreparada(item.SubItems(1).Text) = 0 And funcCO.idArticulo(item.SubItems(1).Text) <> 0 Then
                                avisoNoPreparadas = True
                            End If
                        Next
                        Dim validar As Boolean = True
                        If avisoNoPreparadas Then
                            validar = MsgBox("Existen conceptos no preparados, que se servirán completos. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok
                        End If
                        If validar Then
                            Dim GG As New FlujoSiguiente
                            GG.SoloLectura = vSoloLectura
                            GG.pDesde = "PEDIDO"
                            GG.pHasta = "ALBARAN"
                            GG.pnumDesde = numDoc.Text
                            GG.pConceptos = Conceptos
                            GG.pLocalizacion = Me.Location
                            GG.ShowDialog()
                        End If

                    End If

                    Call CargarPedido()

                End If
            Else
                If MsgBox("Seleccione los conceptos que se han de convertir en Albarán o Producción ") Then
                    ckSeleccion.Visible = True
                    lvConceptos.CheckBoxes = True
                End If
            End If
        End If
    End Sub

    Private Sub bProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ckSeleccion.Visible Then
            Dim Conceptos As New List(Of Long)
            For Each item As ListViewItem In lvConceptos.CheckedItems
                Conceptos.Add(item.SubItems(1).Text)
            Next
            If Conceptos.Count > 0 Then
                Dim GG As New FlujoSiguiente
                GG.SoloLectura = vSoloLectura
                GG.pDesde = "Pedido"
                GG.pHasta = "PROFORMA"
                GG.pConceptos = Conceptos
                GG.ShowDialog()
            End If

        Else
            If MsgBox("Seleccione las lineas de la Pedido que se traspasan a una Proforma", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                ckSeleccion.Visible = True

            End If
        End If

    End Sub

    Private Sub bMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMoneda.Click
        Dim moneda As String = cbMoneda.Text
        Dim GG As New GestionCambioMoneda
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirMonedas()
        cbMoneda.Text = moneda
        If cbMoneda.SelectedIndex = -1 Then
            cbMoneda.Text = funcMO.CampoDivisa("EU")
            lbMoneda1.Text = funcMO.CampoSimbolo("EU")
        End If
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Dim GG As New SeleccionImprimirP
        If vvercostes = False Then
            GG.bCliente.Enabled = False
        End If
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el pedido")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No hay conceptos")
        Else
            GG.ShowDialog()
            If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                InformePedido.verInforme(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), False, rbPedidoPendiente.Checked, GG.pInterno)
                InformePedido.ShowDialog()
            End If
        End If
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        Dim GG As New SeleccionImprimirP
        If vvercostes = False Then
            GG.bCliente.Enabled = False
        End If
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el pedido")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else

            GG.ShowDialog()
            If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim fichero As String = "Pedido SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
                Dim sfd As New SaveFileDialog
                sfd.FileName = fichero
                sfd.ShowDialog()
                InformePedido.GeneraPDF(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), sfd.FileName, "", rbPedidoPendiente.Checked, GG.pInterno)
                If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                    Process.Start(sfd.FileName)
                End If
            End If
        End If
    End Sub

    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beMail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el pedido")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Pedido SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()
            InformePedido.GeneraPDF(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), fichero, camino, rbPedidoPendiente.Checked, False)
            Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
            If cbContacto.SelectedIndex <> -1 Then
                Dim funcMOA As New FuncionesMails
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                Next
            End If
            Dim texto As String = " Buenos días,"
            texto = texto & "<br/><br/> Adjuntamos el pedido " & numDoc.Text & ". "
            'Se envía un correo outlook a la dirección de la ubicación
            CorreoOutlook("PEDIDO CLIENTE", funcPE.campoCorreo(iidUsuario), Destinatario, camino & fichero, cbContacto.Text, numDoc.Text, dtpFecha.Value.Date, dtpFechaPrevista.Value.Date, funcUB.campoIdioma(dtsOF.gidUbicacion))
            ' CorreoOutlook("Nuevo Pedido SUGAR VALLEY", texto, funcPE.campoCorreo(iidUsuario), Destinatario, camino & fichero)

        End If
    End Sub

    'Private Sub bNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoCliente.Click
    '    Dim cliente As String = cbCliente.Text
    '    Dim GG As New GestionClientes
    '    GG.pidCliente = 0
    '    GG.SoloLectura = vSoloLectura
    '    GG.ShowDialog()
    '    Call introducirClientes()
    '    If GG.pidCliente > 0 Then
    '        If GG.pidCliente > 0 Then
    '            dtsCL = funcCL.mostrar1(GG.pidCliente)
    '            cbCodCliente.Text = dtsCL.gcodCli
    '            cbCliente.Text = dtsCL.gnombrecomercial
    '            Call CargarDatosCliente()
    '            cambios = True
    '        End If
    '    Else
    '        cbCliente.Text = cliente
    '    End If



    'End Sub
#End Region

#Region "BOTONES CONCEPTOS"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call LimpiarEdicion()
    End Sub


    Private Sub bArticuloCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bArticuloCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim GG As New GestionArticuloCliente
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = cbCliente.SelectedItem.itemdata
            GG.pidArticulo = iidArticulo
            GG.pcodArticuloCli = codArticuloCli.Text
            GG.pArticuloCli = cbArticulo.Text
            GG.pModo = "DOC"
            GG.ShowDialog()

            If GG.pidArticulo > 0 Then
                iidArticulo = GG.pidArticulo
                Call CargarArticuloC()
            ElseIf iidArticulo > 0 Then
                Call CargarArticuloC()
            End If
            Call CargarVersiones(iidArticulo)
        End If


    End Sub

    Private Sub bTiposArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTiposArticulo.Click
        Dim tipo As String = cbTipo.Text
        Dim subtipo As String = cbSubTipo.Text
        Dim GG As New GestionTiposArticulo
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call IntroducirTiposArticulo()
        cbTipo.Text = tipo
        If cbTipo.SelectedIndex = -1 Then
            cbTipo.Text = ""
        Else
            Call IntroducirSubTiposArticulo()
            cbSubTipo.Text = subtipo
            If cbSubTipo.SelectedIndex = -1 Then cbSubTipo.Text = ""
        End If
    End Sub

    Private Sub bBuscarArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticuloC.Click

        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "CONCEPTO"
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            iidArticulo = GG.pidArticulo
            'Call CargarArticulosC()
            Call CargarArticuloC()
            Call CargarVersiones(iidArticulo)
        End If

    End Sub


    Private Sub bVerArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticuloC.Click
        If iidArticulo > 0 Then
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.pModo = "DOC"
            GG.ShowDialog()
            If GG.pidArticulo <> iidArticulo Then
                iidArticulo = GG.pidArticulo
                Call CargarArticulosC()
            End If
            Call CargarArticuloC()
        Else
            If cbArticulo.Text <> "" Then
                MsgBox("El concepto no se corresponde con un artículo existente.")
            End If
        End If

    End Sub

    Private Sub bBajarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajarC.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            If indice < lvConceptos.Items.Count - 1 Then
                Dim indiceActual As Integer = indice
                Dim indiceInferior As Integer = indice + 1
                Call LimpiarEdicion()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(1).Text
                Dim iidConceptoInferior As Long = lvConceptos.Items(indiceInferior).SubItems(1).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemInferior As ListViewItem = lvConceptos.Items(indiceInferior).Clone
                If funcCO.MoverConceptos(iidConceptoInferior, iidConceptoActual) Then
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
            indice = lvConceptos.SelectedIndices(0)
            If indice > 0 Then
                Dim indiceActual As Integer = indice
                Dim indiceSuperior As Integer = indice - 1
                Call LimpiarEdicion()
                Dim iidConceptoActual As Long = lvConceptos.Items(indiceActual).SubItems(1).Text
                Dim iidConceptoSuperior As Long = lvConceptos.Items(indiceSuperior).SubItems(1).Text
                Dim itemActual As ListViewItem = lvConceptos.Items(indiceActual).Clone
                Dim itemSuperior As ListViewItem = lvConceptos.Items(indiceSuperior).Clone
                If funcCO.MoverConceptos(iidConceptoActual, iidConceptoSuperior) Then
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

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            'iidArticulo = lvConceptos.Items(indice).SubItems(1).Text
            Call CargarEdicion()
        End If
    End Sub

    Private Sub cbCodCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodCliente.SelectionChangeCommitted
        If cbCodCliente.SelectedIndex <> -1 Then
            If dtsCL Is Nothing Or iidCliente <> cbCodCliente.SelectedItem.itemdata Then
                iidCliente = cbCodCliente.SelectedItem.itemdata
                dtsCL = funcCL.mostrar1(iidCliente)
                cbCliente.Text = dtsCL.gnombrecomercial
                Call CambioCliente()
            End If
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True
        End If
    End Sub

    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectionChangeCommitted
        If cbCliente.SelectedIndex <> -1 Then
            If dtsCL Is Nothing Or iidCliente <> cbCliente.SelectedItem.itemdata Then
                iidCliente = cbCliente.SelectedItem.itemdata
                dtsCL = funcCL.mostrar1(iidCliente)
                cbCodCliente.Text = dtsCL.gcodCli
                Call CambioCliente()
            End If

        End If
    End Sub

    Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
        If semaforo Then
            If cbMedioPago.SelectedIndex <> -1 Then
                If cbMedioPago.SelectedItem.gBanco Then
                    cbCuenta.Enabled = True
                    If Not dtsFA Is Nothing Then
                        If cbMedioPago.SelectedItem.gTransferencia Then
                            dtsFA.gCuentas = funcCB.Mostrar(0, True) 'Cuentas propias
                        ElseIf cbMedioPago.SelectedItem.gGiro Then
                            dtsFA.gCuentas = funcCB.Mostrar(dtsFA.gidFacturacion, True, " and CuentasBancarias.activo=1 ") 'Cuentas del cliente
                        End If
                        Call CargarCuentas()
                    End If

                Else
                    cbCuenta.Enabled = False
                    cbCuenta.Items.Clear()
                    cbCuenta.Text = ""
                    cbCuenta.SelectedIndex = -1
                End If
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbTipoPago_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoPago.SelectedIndexChanged
        If semaforo Then
            If cbTipoPago.SelectedIndex <> -1 Then
                If cbTipoPago.SelectedItem.gProntoPago Then
                    ProntoPago.Enabled = True
                    ProntoPago.Text = If(dtsFA Is Nothing, 0, dtsFA.gProntoPago)
                Else
                    ProntoPago.Enabled = False
                    ProntoPago.Text = 0
                End If
                cambios = True
            End If
        End If
    End Sub

    Private Sub cbEstado_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.SelectionChangeCommitted
        If cbEstado.SelectedIndex <> -1 Then
            If cbEstado.SelectedItem.gAutomatico Then
                MsgBox("El estado " & cbEstado.Text & " es automático, no se puede seleccionar manualmente.")
                cbEstado.Text = dtsOF.gEstado
            Else
                dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsOF.gEstado = cbEstado.SelectedItem.gEstado
                cambios = True
            End If
        End If
    End Sub

    Private Sub lbMoneda1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMoneda1.TextChanged
        lbMoneda2.Text = lbMoneda1.Text
        lbMoneda3.Text = lbMoneda1.Text
        lbMoneda4.Text = lbMoneda1.Text
        lbMoneda5.Text = lbMoneda1.Text
        lbMoneda6.Text = lbMoneda1.Text
        lbmonedaC.Text = lbMoneda1.Text
        lbMonedaS.Text = lbMoneda1.Text
        lbMonedaN.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text
    End Sub

    Private Sub cbMoneda_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectionChangeCommitted
        If cbMoneda.SelectedIndex <> -1 Then
            'lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            'Cambiar moneda en todo el documento
            Dim moneda As String = cbMoneda.SelectedItem.ToString
            If codMonedaI <> cbMoneda.SelectedItem.gcodMoneda Then
                Dim FechaCambio As Date = funcMO.CampoFecha(cbMoneda.SelectedItem.gcodMoneda)
                If FechaCambio <> dtpFecha.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                    'lbCambio.Text = "CAMBIO " & FechaCambio
                    'lbCambio.Visible = True
                End If
                Dim codMonedaActual = cbMoneda.SelectedItem.gcodMoneda
                If G_AGeneral = "A" Then
                    'Si es un doc ya existente
                    If MsgBox("El cambio de moneda quedará guardado en la base de datos. ¿Proceder con el cambio?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        funcOF.actualizaMoneda(numDoc.Text, codMonedaActual)
                        dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
                        dtsOF.gDivisa = cbMoneda.SelectedItem.gdivisa
                        dtsOF.gSimbolo = cbMoneda.SelectedItem.gsimbolo
                        listaC = funcCO.Mostrar(numDoc.Text)
                        For Each dts As DatosConceptoPedido In listaC
                            funcCO.CambiarPrecio(dts.gidConcepto, funcMO.Cambio(dts.gPVPUnitario, codMonedaI, codMonedaActual, True, Now.Date), funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        Call CargarConceptos()
                        Call Recalcular()
                    Else
                        cbMoneda.Text = dtsOF.gDivisa
                        ep2.Clear()
                    End If

                Else
                    cbMoneda.Text = moneda
                End If
            End If
            lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            cambios = True
        End If
    End Sub

    Private Sub ckRecargoEquivalencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckRecargoEquivalencia.Click
        If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
            TipoRecargoEq.Enabled = True
            TipoRecargoEq.Text = cbTipoIVA.SelectedItem.gTipoRecargoEq
        Else
            TipoRecargoEq.Enabled = False
            TipoRecargoEq.Text = 0
        End If
        cambios = True
    End Sub

    Private Sub cbTipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipo.SelectionChangeCommitted
        If cbTipo.SelectedIndex <> -1 Then
            iidTipoArticulo = cbTipo.SelectedItem.gidTipoArticulo
            DescuentoC.Text = FormatNumber(If(cbTipo.SelectedItem.gDescuento1, dtsFA.gDescuento, dtsFA.gDescuento2))
            Call IntroducirSubTiposArticulo()
            Call CargarArticulosC()
        End If
    End Sub

    Private Sub cbSubTipo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubTipo.SelectionChangeCommitted
        If cbSubTipo.SelectedIndex <> -1 And iidTipoArticulo > 0 Then
            Call CargarArticulosC()
        End If
    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedValueChanged 'cbCodArticulo.SelectionChangeCommitted

        Try
            If semaforo Then

                If cbCodArticulo.SelectedIndex <> -1 Then

                    semaforo = False

                    iidArticulo = cbCodArticulo.SelectedItem.itemdata

                    Call CargarArticuloC()

                    Call CargarVersiones(iidArticulo)

                    If Cantidad.Text = "0" Then Cantidad.Text = 1

                    semaforo = True

                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Information)

        End Try

    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedValueChanged 'cbArticulo.SelectionChangeCommitted
        If semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                Call CargarArticuloC()
                Call CargarVersiones(iidArticulo)
                If Cantidad.Text = "0" Then Cantidad.Text = 1
                semaforo = True
            End If
        End If
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DescuentoC.Click, ProntoPago.Click, PrecioNeto.Click, Stock.Click, PrecioTransporte.Click
        sender.selectall()
    End Sub

    Private Sub Cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.TextChanged, DescuentoC.TextChanged, PrecioNeto.TextChanged, PVP.TextChanged, Stock.TextChanged
        If semaforo Then
            If Cantidad.Text = "-" Then
            Else
                semaforo = False
                If Cantidad.Text = "" Or Cantidad.Text = "," Or Cantidad.Text = "." Then Cantidad.Text = 0
                If DescuentoC.Text = "" Then DescuentoC.Text = 0
                If PrecioNeto.Text = "" Then PrecioNeto.Text = 0
                If PVP.Text = "" Then PVP.Text = 0
                If DescuentoC.Text <> 0 Then  'Si hay descuento, ignoramos el precio neto
                    PrecioNeto.Text = FormatNumber((1 - DescuentoC.Text / 100) * PVP.Text, 2)
                Else
                    If PrecioNeto.Text = 0 Then PrecioNeto.Text = PVP.Text 'Si el precio neto=0, ponemos el PVP
                End If
                subTotal.Text = FormatNumber(Cantidad.Text * PrecioNeto.Text, 2)
                semaforo = True
            End If
        End If
    End Sub

    Private Sub DescuentoC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DescuentoC.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(DescuentoC.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            If ConceptosEditables Then Call GuardarConcepto()
        End If
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(Cantidad.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Cantidad.Text = "" Or Cantidad.Text = "0" Then
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
            If ConceptosEditables Then Call GuardarConcepto()
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

    Private Sub PrecioNeto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioNeto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioNeto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            If ConceptosEditables Then Call GuardarConcepto()
        End If
    End Sub

    Private Sub ProntoPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ProntoPago.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(ProntoPago.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvConceptos.Items
                item.Checked = ckSeleccion.Checked
            Next
            semaforo = True
        End If

    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvConceptos.ItemChecked
        If semaforo Then
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

    Private Sub cbTipoIVA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTipoIVA.KeyPress, cbRetencion.KeyPress
        'emula el READ ONLY
        e.Handled = True
    End Sub

    Private Sub cbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCliente.KeyPress, cbCodCliente.KeyPress
        'emula el READ ONLY
        If ClienteSoloLectura Then e.Handled = True
    End Sub

    Private Sub ProntoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nota.TextChanged, Observaciones.TextChanged, _
    ProntoPago.TextChanged, dtpFecha.ValueChanged, dtpFechaPrevista.ValueChanged, RefCliente.TextChanged, cbRetencion.SelectedIndexChanged, _
    cbTipoIVA.SelectedIndexChanged, cbCuenta.SelectedIndexChanged, cbContacto.SelectedIndexChanged, cbSolicitadoVia.SelectedIndexChanged, _
    RefCliente2.TextChanged, cbTransporte.TextChanged, cbPersona.TextChanged, PrecioTransporte.TextChanged, ckRecargoEquivalencia.CheckedChanged, cbValorado.SelectedIndexChanged, ckRecogido.CheckedChanged
        cambios = semaforo
    End Sub

    Private Sub cbPortes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPortes.SelectedIndexChanged
        If semaforo Then
            If cbPortes.Text = "PAGADOS" Or cbPortes.Text = "DEBIDOS" Then
                PrecioTransporte.Enabled = False
                PrecioTransporte.Text = 0
            Else
                PrecioTransporte.Enabled = True
            End If
            cambios = True
        End If
    End Sub

    'Private Sub numDoc1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numDoc1.DoubleClick
    '    If IsNumeric(numDoc1.Text) Then
    '        Dim GG As New GestionAlbaran
    '        GG.SoloLectura = vSoloLectura
    '        GG.pnumAlbaran = numDoc1.Text
    '        GG.ShowDialog()
    '        Dim punto As Point = Me.Location
    '        punto = New Point(punto.X + 15, punto.Y + 15)
    '        GG.pLocation = punto
    '    End If
    'End Sub

    Protected Sub OnClickNumDoc1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc1.DoubleClick
        If sender.text = "VARIOS" Then
            MsgBox("Hay varios albaranes asociados. Pulse botón derecho para acceder a ellos.")
        ElseIf IsNumeric(sender.Text) Then
            Dim GG As New GestionAlbaran
            GG.SoloLectura = vSoloLectura
            GG.pnumAlbaran = sender.Text
            GG.ShowDialog()
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
        End If
    End Sub

    Private Sub rbPri1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPri1.CheckedChanged, rbPri2.CheckedChanged
        'Cambia la prioridad, recalcular Fecha Entrega
        If semaforo Then
            Call CalculoFechaEntrega()
            cambios = True
        End If
    End Sub

    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            Call DatosDireccion()
            cambios = True
        End If
    End Sub

    Private Sub bGuardar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles bGuardar.KeyDown, cbPersona.KeyDown, cbEstado.KeyDown, bBajar.KeyDown, bSubir.KeyDown, cbCodCliente.KeyDown, cbCliente.KeyDown, cbArticulo.KeyDown
        'Después de guardar, será sensible a esto
        If ckSinAlbaran.Checked AndAlso e.Control And e.Alt And (e.KeyValue = Asc("n") Or e.KeyValue = Asc("N")) Then
            If MsgBox("¿Proceder a la anulación del pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                'Hacemos una triple comprobación, que el estado no sea SERVIDO ni PARCIAL y que ninguna linea esté servida ni con referencia a albarán.
                If cambios Then
                    MsgBox("Hay cambios pendientes de guardar")
                ElseIf cbEstado.SelectedItem.gTraspasado Or cbEstado.SelectedItem.gEntregado Then
                    MsgBox("No es posible anular el pedido porque ha sido traspasado total o parcialmente")
                ElseIf funcOF.bAnulado(numDoc.Text) Then
                    MsgBox("El pedido ya ha sido anulado previamente")
                ElseIf funcCO.AlgoSERVIDO(numDoc.Text) Then
                    MsgBox("No es posible anular el pedido porque ha sido traspasado total o parcialmente")
                Else
                    Call PedidoSinAlbaran()
                End If
            End If
        End If
    End Sub

    Private Sub PedidoSinAlbaran()
        Dim fichero As String = "\\Srvsugar\gestion\archivo.xlsx"
        If File.Exists(fichero) Then
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            xlApp = New Excel.Application
            xlWorkSheet = xlWorkBook.Worksheets("Hoja1")
            'Encontrar la primera linea vacía
            Dim x As Integer = 1
            Do While CStr(xlWorkSheet.Cells(x, 7).value) <> ""
                x = x + 1
            Loop
            'Detectar si ya existe el pedido 
            Dim xx As Integer = x
            Do While CStr(xlWorkSheet.Cells(xx, 2).value) <> numDoc.Text And xx > 1
                xx = xx - 1
            Loop
            If xx > 1 Then
                MsgBox("Este pedido ya ha sido procesado anteriormente.")
            Else
                xlWorkSheet.Cells(x, 1) = dtpFecha.Value.Date
                xlWorkSheet.Cells(x, 2) = numDoc.Text
                xlWorkSheet.Cells(x, 3) = cbCliente.Text
                xlWorkSheet.Cells(x, 4) = cbDireccion.Text
                Dim lista As List(Of DatosConceptoPedido) = funcCO.Mostrar(numDoc.Text)
                For Each dts As DatosConceptoPedido In lista
                    xlWorkSheet.Cells(x, 5) = dts.gcodArticulo & " - " & dts.gArticulo
                    xlWorkSheet.Cells(x, 6) = funcEQ.numsSeriePedido(dts.gidConcepto)
                    xlWorkSheet.Cells(x, 7) = dts.gCantidad '& dts.gTipoUnidad
                    xlWorkSheet.Cells(x, 8) = If(dts.gDescuento, dts.gPVPUnitario * (1 - (dts.gDescuento / 100)), dts.gPrecioNetoUnitario) & lbMoneda1.Text
                    xlWorkSheet.Cells(x, 9) = FormatNumber(dts.gDescuento, 2) & "%"
                    xlWorkSheet.Cells(x, 10) = dts.gCantidad * If(dts.gDescuento, dts.gPVPUnitario * ((1 - dts.gDescuento / 100)), dts.gPrecioNetoUnitario) & lbMoneda1.Text
                    x = x + 1
                    funcCO.CambiarCantidadServida(dts.gidConcepto, dts.gCantidad)
                    funcCO.CambiarCantidadPreparada(dts.gidConcepto, 0)
                Next
            End If
            xlWorkBook.Save()
            xlWorkBook.Close()
            xlApp.Quit()
            xlApp.Application.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            ' Dim Anulado As DatosEstado = funcES.EstadoAnulado("PEDIDO")
            'Servir conceptos
            Dim ConceptoServido As DatosEstado = funcES.EstadoEntregado("C.PEDIDO")
            Dim iidConcepto As Long
            For Each item As ListViewItem In lvConceptos.Items
                iidConcepto = item.SubItems(1).Text
                If iidConcepto > 0 Then
                    funcCO.CambiarCantidadServida(iidConcepto, funcCO.Cantidad(iidConcepto))
                    funcCO.CambiarCantidadPreparada(iidConcepto, 0)
                    funcCO.CambiarEstado(iidConcepto, ConceptoServido.gidEstado)
                End If
            Next
            funcOF.actualizaEstado(numDoc.Text, estadoPEAnulado.gidEstado) 'Anulado.gidEstado)
            funcOF.BAnular(numDoc.Text)

            Call CargarPedido()
        Else
            MsgBox("No existe fichero.")
        End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub rbPedidoCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPedidoCompleto.CheckedChanged
        If semaforo Then
            Call CargarConceptos()
            Call Recalcular()
            Call LimpiarEdicion()
        End If
    End Sub

    Private Sub ckSinAlbaran_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckSinAlbaran.CheckedChanged
        If semaforo Then
            cambios = True
            If ckSinAlbaran.Checked Then
                ckRecogido.Enabled = True
            Else
                ckRecogido.Enabled = False
                ckRecogido.Checked = False
            End If
        End If
    End Sub

#End Region


    Private Sub btnBoton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvConceptos.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If lvConceptos.SelectedItems.Count = 1 Then
                AddContextMenuAndItems()
            End If
        End If
    End Sub

    Public Sub AddContextMenuAndItems()
        Dim mnuContextMenu As New ContextMenu()
        Dim mnuItemNew As New MenuItem()
        Dim mnuItemNew1 As New MenuItem()
        Me.ContextMenu = mnuContextMenu
        mnuContextMenu.MenuItems.Add("&PROFORMA", New System.EventHandler(AddressOf Me.OnClicksubMenu))
    End Sub
    Public Sub OnClicksubMenu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Select Case sender.text
                Case "&PROFORMA"
                    funcCO.numProforma(lvConceptos.Items(indice).SubItems(1).Text)
            End Select
        End If
    End Sub

    Private Sub bFechaPrevista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bFechaPrevista.Click
        Call CalculoFechaEntrega()
        funcOF.actualizaFechaEntrega(numDoc.Text, dtpFechaPrevista.Value.Date)
    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCodArticulo.SelectedIndexChanged

    End Sub
End Class