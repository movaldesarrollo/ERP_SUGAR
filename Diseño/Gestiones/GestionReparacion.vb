Imports System.IO

Public Class GestionReparacion

#Region "VARIABLES"

    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private G_AGeneral As Char
    Private Reparaciones As List(Of Integer)
    Private indiceL As Integer
    Private indice As Integer
    Private funcMO As New FuncionesMoneda
    Private funcOF As New FuncionesReparaciones
    Private funcCO As New FuncionesConceptosReparaciones
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
    Private funcPE As New FuncionesPersonal
    Private funcRu As New FuncionesRutas
    Private funcAC As New funcionesArticuloCliente
    Private funcACP As New funcionesArticuloClientePrecios
    Private funcUM As New FuncionesTiposUnidad
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcTRR As New FuncionesTrabajosReparaciones
    Private funcTRE As New FuncionesTiposReparacion
    Private funcER As New FuncionesEstatusReparacion
    Private funcEH As New FuncionesEquiposHistorico

    Private DI As New DatosIniciales
    Private iidArticulo As Integer
    Private iidArticuloR As Integer
    Private dtsOF As DatosReparacion
    Private dtsCL As datoscliente
    Private dtsFA As datosfacturacion
    Private dtsCO As DatosConceptoReparacion
    Private dtsAR As DatosArticulo
    Private dtsTRR As DatosTrabajoReparacion
    Private dtsUB As datosUbicacion
    Private listaC As List(Of DatosConceptoReparacion)
    Private semaforo As Boolean
    Private iidTipoArticulo As Integer
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private iidCliente As Integer
    Private localizacion As Point
    Private AvisadoCliente As Boolean
    Private ClienteSoloLectura As Boolean
    Private ConceptosEditables As Boolean
    Private dtsEQ As DatosEquipoProduccion
    Private ArticuloSoloLectura As Boolean
    Private iidEquipo As Integer
    Private HaCargadoEquipo As Boolean

#End Region

#Region "PROPIEDADES"

    Public Property pnumReparacion() As Integer
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

    Property pReparaciones() As List(Of Integer)
        Get
            Return Reparaciones
        End Get
        Set(ByVal value As List(Of Integer))
            Reparaciones = value
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

#End Region

#Region "CARGA Y CIERRE"

    Private Sub GestionReparacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = True
        If localizacion.X <> 0 Then Me.Location = localizacion
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 950 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 900
        End If
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        AvisadoCliente = False
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
        ClienteSoloLectura = False
        ArticuloSoloLectura = False
        ConceptosEditables = True
        iidUsuario = Inicio.vIdUsuario

        Call introducirMonedas()
        Call IntroducirTiposArticulo()
        Call introducirTiposIVA()
        Call introducirTransporte()
        Call introducirEstatus()
        Call CargarArticulosR()
        Call introducirTiposValorado()
        Call InicializarGeneral()
        If numDoc.Text = "" Then numDoc.Text = 0
        If numDoc.Text = 0 Then
            Call introducirClientes()
            Call Nuevo()
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            Me.Text = "EDITAR REPARACIÓN"
            tpProceso.Enabled = True
            If Reparaciones Is Nothing Then
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                If Reparaciones.Count > 0 Then
                    bSubir.Visible = True
                    bBajar.Visible = True
                Else
                    bSubir.Visible = False
                    bBajar.Visible = False
                End If
            End If
            Call CargarReparacion()
        End If
    End Sub

    Private Sub GestionReparacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If G_AGeneral = "G" Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
    End Sub

#End Region

#Region "FUNCIONES"

    Private Sub Nuevo()
        Me.Text = "NUEVA REPARACIÓN"
        ClienteSoloLectura = False
        ArticuloSoloLectura = False
        cbCliente.Enabled = True
        cbCodCliente.Enabled = True
        bBuscarCliente.Enabled = True
        dtsOF = New DatosReparacion
        tpProceso.Enabled = False
        numDoc.Text = funcMA.leernumReparacion(Now.Year) + 1
        If numDoc.Text = 0 Then
            funcMA.NuevoAño()
            numDoc.Text = funcMA.leernumReparacion(Now.Year) + 1
            If numDoc.Text = 0 Then
                MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                Me.Close()
            End If
        End If
        G_AGeneral = "G"
        Dim dtsES As DatosEstado = funcES.EstadoEspera("REPARACION")
        cbEstado.Items.Clear()
        cbEstado.Items.Add(dtsES)
        cbEstado.Text = dtsES.ToString
        iidCliente = 0
        Dim dtsER As DatosEstatusReparacion = funcER.Mostrar1(1)
        cbEstatus.Text = dtsER.gEstatus
        cbPersona.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbPersona.SelectedIndex = -1 Then cbPersona.Text = ""
        OtrosTipos.Enabled = False
        bBuscarArticuloR.Enabled = True

    End Sub

    Private Sub InicializarGeneral()
        ep1.Clear()
        ep2.Clear()
        'ckSeleccion.Checked = False
        'ckSeleccion.Visible = True
        lvConceptos.Items.Clear()
        lvConceptos.CheckBoxes = True
        RefCliente.Text = ""
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbCodCliente.Text = ""
        cbCodCliente.SelectedIndex = -1
        numPedido.Text = ""
        Call introducirPersonal()
        Call introducirPersonalTecnico()
        Call LimpiarCabecera()
        Call LimpiarDatosReparacion()
        Nota.Text = ""
        Observaciones.Text = ""
        cbValorado.Text = "VALORADO CON TOTALES"
        'SumaDescuentos.Text = 0
        'BaseImponible.Text = 0
        'TotalIVA.Text = 0
        'TotalRE.Text = 0
        'Retencion.Text = 0
        Total.Text = 0
        Call LimpiarEdicion()
        cambios = False
    End Sub

    Private Sub LimpiarCabecera()
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbDireccion.Items.Clear()
        dtpFecha.Value = Now.Date
        dtpFechaPrevista.Value = Now.Date
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbContacto.Items.Clear()
        txPrecioTotalReparacion.Text = ""
        cbMoneda.Text = funcMO.CampoDivisa("EU")
        codMonedaI = "EU"
        cbTipoIVA.Text = DI.TipoIVA.ToString
        cbPortes.Text = ""
        PrecioTransporte.Text = 0
        PrecioTransporte.Enabled = False
    End Sub

    Private Sub LimpiarDatosReparacion()
        cbcodArticuloR.Text = ""
        cbcodArticuloR.SelectedIndex = -1
        cbArticuloR.Text = ""
        cbArticuloR.SelectedIndex = -1
        ckCaja.Checked = False
        ckCelula.Checked = False
        ckSonda.Checked = False
        ckPlaca.Checked = False
        ckOtros.Checked = False
        OtrosTipos.Text = "OTROS"
        numSerie.Text = ""
        FechaServido.Text = ""
        dtpFechaFabricacion.Value = Now.Date
        ckGarantia.Checked = False
        Descripcion.Text = ""
        Inspeccion.Text = ""
        TrabajoARealizar.Text = ""
        dtpFechaTrabajo.Value = Now.Date
        cbRealizadoPor.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbRealizadoPor.SelectedIndex = -1 Then cbRealizadoPor.Text = ""
        Horas.Text = ""
        TrabajoRealizado.Text = ""
    End Sub

    Private Sub LimpiarEdicion()
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
        'ckSeleccion.Checked = False
        cbCodArticulo.SelectedIndex = -1
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
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
            CorreoError(ex)
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
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        cbCodCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("REPARACION")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub

    Private Sub introducirEstatus()
        cbEstatus.Items.Clear()
        Dim lista As List(Of DatosEstatusReparacion) = funcER.Mostrar(True)
        For Each dts As DatosEstatusReparacion In lista
            cbEstatus.Items.Add(dts)
        Next
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
            CorreoError(ex)
        End Try
    End Sub

    Private Sub introducirPersonal()
        cbPersona.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.Listar
        For Each item As IDComboBox In lista
            cbPersona.Items.Add(item)
        Next
        'Cargamos el usuario que ha hecho login, si no está en la lista lo deja en blanco.
        cbPersona.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbPersona.SelectedIndex = -1 Then cbPersona.Text = ""
    End Sub

    Private Sub introducirPersonalTecnico()
        cbRealizadoPor.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.ListarTecnicos
        For Each item As IDComboBox In lista
            cbRealizadoPor.Items.Add(item)
        Next
        'Cargamos el usuario que ha hecho login, si no está en la lista lo deja en blanco.
        cbRealizadoPor.Text = funcPE.campoNombreyApellidos(iidUsuario)
        If cbRealizadoPor.SelectedIndex = -1 Then cbRealizadoPor.Text = ""
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
            cbValorado.Text = "VALORADO CON TOTALES"
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

#End Region

#Region "CARGAR DATOS"
    Private Sub CargarReparacion()
        ep1.Clear()
        ep2.Clear()
        G_AGeneral = "A"
        dtsOF = funcOF.Mostrar1(numDoc.Text)
        iidCliente = dtsOF.gidCliente
        dtsCL = funcCL.mostrar1(iidCliente)
        Dim dtsES As DatosEstado = funcES.Mostrar1(dtsOF.gidEstado)
        If dtsES.gEspera Or dtsES.gEnCurso Or dtsCL.gnombrecomercial = "SUGAR VALLEY" Then
            Call introducirClientes()
            ClienteSoloLectura = False
            bBuscarCliente.Enabled = True
            Call CargarArticulosR()
            ArticuloSoloLectura = False
            bBuscarArticuloR.Enabled = True
            bBuscarEquipo.Enabled = True
        Else
            'Sólo carga el cliente y el artículo en cuestión (porque no se va a poder cambiar)
            cbCliente.Items.Clear()
            cbCodCliente.Items.Clear()
            cbCodCliente.Items.Add(New IDComboBox(dtsCL.gcodCli, dtsCL.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dtsCL.gnombrecomercial, dtsCL.gidCliente))
            ClienteSoloLectura = True
            bBuscarCliente.Enabled = False
            cbcodArticuloR.Items.Clear()
            cbArticuloR.Items.Clear()
            cbcodArticuloR.Items.Add(New IDComboBox(dtsOF.gcodArticulo, dtsOF.gidArticulo))
            cbArticuloR.Items.Add(New IDComboBox3(dtsOF.gcodArticulo, dtsOF.gArticulo, dtsOF.gidArticulo))
            ArticuloSoloLectura = True
            bBuscarArticuloR.Enabled = False
            bBuscarEquipo.Enabled = False
        End If
        txRMA.Text = dtsOF.gRMA
        cbCliente.Text = dtsOF.gCliente
        cbCodCliente.Text = dtsCL.gcodCli
        Call CargarDatosFacturacionCliente()
        Call CargarCombosCliente()
        Call PresentarAvisoCliente()
        RefCliente.Text = dtsOF.gReferenciaCliente
        cbPersona.Text = dtsOF.gPersona
        If dtsOF.gnumPedido > 0 Then
            numPedido.Text = dtsOF.gnumPedido
        Else
            numPedido.Text = ""
        End If
        If dtsOF.gPrecioTotalReparacion = -1 Then
            txPrecioTotalReparacion.Text = ""
        Else
            txPrecioTotalReparacion.Text = dtsOF.gPrecioTotalReparacion
        End If
        If dtsOF.gnumOferta > 0 Then
            numOferta.Text = dtsOF.gnumOferta
        Else
            numOferta.Text = ""
        End If
        If dtsOF.gnumProforma > 0 Then
            numProforma.Text = dtsOF.gnumProforma
        Else
            numProforma.Text = ""
        End If
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
        cbContacto.Text = dtsOF.gContacto
        cbTipoIVA.Items.Clear()
        cbTipoIVA.Items.Add(funcTI.Mostrar1(dtsOF.gidTipoIVA))
        cbTipoIVA.SelectedIndex = 0
        ProntoPago.Text = FormatNumber(dtsOF.gProntoPago, 2)
        Observaciones.Text = dtsOF.gObservaciones
        Nota.Text = dtsOF.gNotas
        cbValorado.Text = dtsOF.gTipoValorado
        cbEstado.Items.Clear()
        'Cargar el estado que tenga y los que falten
        If dtsES.gEspera Then
            cbEstado.Items.Add(funcES.EstadoEspera("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoCompleto("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoAnulado("REPARACION"))
        ElseIf dtsES.gEnCurso Then
            cbEstado.Items.Add(funcES.EstadoEnCurso("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoCompleto("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoAnulado("REPARACION"))
        ElseIf dtsES.gAnulado Then
            cbEstado.Items.Add(funcES.EstadoEspera("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoAnulado("REPARACION"))
        ElseIf dtsES.gCompleto Then
            cbEstado.Items.Add(funcES.EstadoEspera("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoCompleto("REPARACION"))
            cbEstado.Items.Add(funcES.EstadoAnulado("REPARACION"))
        ElseIf dtsES.gTraspasado And dtsES.gBloqueado Then
            cbEstado.Items.Add(funcES.EstadoReparacion("TRASPASADO"))
        ElseIf dtsES.gTraspasado And Not dtsES.gBloqueado Then 'PARCIAL
            cbEstado.Items.Add(funcES.EstadoReparacion("PARCIAL"))
            cbEstado.Items.Add(funcES.EstadoReparacion("TRASPASADO"))
        End If
        cbEstado.Text = dtsES.ToString
        If dtsES.gBloqueado Then
            ConceptosEditables = False
            bBorrar.Enabled = False
            bTraspasar.Enabled = False
        Else
            ConceptosEditables = True
            bGuardar.Enabled = Not vSoloLectura
            bBorrar.Enabled = Not vSoloLectura
            bTraspasar.Enabled = Not vSoloLectura
        End If
        Call CargarDatosPropiosReparacion()
        Call CargarTrabajoRealizado()
        Call CargarConceptos()
        BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        cambios = False
    End Sub


    Private Sub CargarDatosPropiosReparacion()
        If dtsOF.gidEquipo > 0 Then
            dtsEQ = funcEQ.Mostrar1(dtsOF.gidEquipo)
            FechaServido.Text = dtsEQ.gFechaAlbaran
        Else
            FechaServido.Text = ""
        End If
        'cbTipoReparacion.Text = dtsOF.gTipoReparacion
        ckCaja.Checked = dtsOF.gCaja
        ckCelula.Checked = dtsOF.gCelula
        ckSonda.Checked = dtsOF.gSonda
        ckPlaca.Checked = dtsOF.gPlaca
        ckOtros.Checked = dtsOF.gOtros
        If ckOtros.Checked Then
            OtrosTipos.Text = dtsOF.gOtrosTipos
            OtrosTipos.Enabled = True
        Else
            OtrosTipos.Text = "OTROS"
            OtrosTipos.Enabled = False
        End If
        If dtsOF.gidArticulo = 0 Then
            cbcodArticuloR.Text = dtsOF.gcodArticuloCli
        Else
            cbcodArticuloR.Text = dtsOF.gcodArticulo
        End If
        cbArticuloR.Text = dtsOF.gArticulo
        ckGarantia.Checked = dtsOF.gGarantia
        dtpFechaFabricacion.Value = dtsOF.gFechaFabricacion
        numSerie.Text = dtsOF.gnumSerie
        cbEstatus.Text = dtsOF.gEstatus
        Descripcion.Text = dtsOF.gDescripcion
        Inspeccion.Text = dtsOF.gInspeccion
        TrabajoARealizar.Text = dtsOF.gTrabajoARealizar
    End Sub


    Private Sub CargarTrabajoRealizado()
        Dim lista As List(Of DatosTrabajoReparacion) = funcTRR.MostrarRealizados(numDoc.Text)
        If lista.Count > 0 Then
            dtsTRR = lista(0)
            dtpFechaTrabajo.Value = dtsTRR.gFechaTrabajo.Date
            Horas.Text = dtsTRR.gHoras
            cbRealizadoPor.Text = dtsTRR.gPersona
            TrabajoRealizado.Text = dtsTRR.gTrabajo
        End If
    End Sub


    Private Sub CargarConceptos()
        listaC = funcCO.Mostrar(numDoc.Text)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoReparacion In listaC
            nuevaLineaLV(dts)
        Next
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
            cbValorado.Text = dtsFA.gTipoValorado
            cbPersona.Text = dtsCL.gResponsableCuenta
            ProntoPago.Text = FormatNumber(dtsFA.gProntoPago, 2)
        End If

    End Sub


    Private Sub PresentarAvisoCliente()
        If Trim(dtsCL.gobservaciones).Length > 0 And Not AvisadoCliente Then
            MsgBox(dtsCL.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsCL.gnombrecomercial)
            AvisadoCliente = True
        End If
    End Sub

    Private Sub CargarDatosClienteNoEditables()
        If Not dtsFA Is Nothing Then
            cbTipoIVA.Items.Clear()
            cbTipoIVA.Items.Add(funcTI.Mostrar1(dtsFA.gidTipoIVA))
            cbTipoIVA.SelectedIndex = 0
        End If

    End Sub



    Private Sub AsignarDatosPropiosReparacion()
        'dtsOF.gTipoReparacion = cbTipoReparacion.Text
        'dtsOF.gidTipoReparacion = cbTipoReparacion.SelectedItem.gidTipoReparacion
        dtsOF.gCaja = ckCaja.Checked
        dtsOF.gCelula = ckCelula.Checked
        dtsOF.gSonda = ckSonda.Checked
        dtsOF.gPlaca = ckPlaca.Checked
        dtsOF.gOtros = ckOtros.Checked
        If ckOtros.Checked Then
            dtsOF.gOtrosTipos = OtrosTipos.Text
        Else
            dtsOF.gOtrosTipos = ""
        End If
        dtsOF.gcodArticuloCli = cbcodArticuloR.Text
        dtsOF.gcodArticulo = cbcodArticuloR.Text
        dtsOF.gArticulo = cbArticuloR.Text
        dtsOF.gidArticulo = If(cbArticuloR.SelectedIndex = -1, 0, cbArticuloR.SelectedItem.itemdata)
        If dtsOF.gidArticulo = 0 And dtsOF.gcodArticuloCli = "" Then dtsOF.gcodArticuloCli = cbArticuloR.Text
        dtsOF.gGarantia = ckGarantia.Checked
        dtsOF.gnumSerie = numSerie.Text
        dtsOF.gDescripcion = Descripcion.Text
        dtsOF.gInspeccion = Inspeccion.Text
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

    End Sub



    Private Sub CargarArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        If dtsUB Is Nothing Then
            If cbDireccion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una dirección")
                Return
            Else
                Call DatosDireccion()
            End If

        End If
        Dim lista As List(Of IDComboBox3)
        If cbCliente.SelectedIndex = -1 Then
            'Si no hay cliente seleccionado, buscamos en Articulis directamente
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

    Private Sub CargarArticulosR()
        cbcodArticuloR.Items.Clear()
        cbcodArticuloR.Text = ""
        cbcodArticuloR.SelectedIndex = -1
        cbArticuloR.Items.Clear()
        cbArticuloR.Text = ""
        cbArticuloR.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("VENDIBLE")
        For Each dts As IDComboBox3 In lista
            cbArticuloR.Items.Add(dts)
            If dts.Name1 <> "" Then cbcodArticuloR.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub


#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoReparacion)
        With lvConceptos.Items.Add(" ")
            .SubItems.Add(dts.gidConcepto)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gcodArticuloCli)
            .SubItems.Add(dts.gArticuloCli)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(FormatNumber(dts.gPVPUnitario, 2) & dtsOF.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gDescuento, 2) & "%")
            .SubItems.Add(FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsOF.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gSubTotal, 2) & dtsOF.gSimbolo)
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoReparacion)
        'Actualizar a partir del índice actual
        If indice <> -1 Then
            With lvConceptos.Items(indice)
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gcodArticuloCli
                .SubItems(4).Text = dts.gArticuloCli
                .SubItems(5).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
                .SubItems(6).Text = FormatNumber(dts.gPVPUnitario, 2) & dtsOF.gSimbolo
                .SubItems(7).Text = FormatNumber(dts.gDescuento, 2) & "%"
                .SubItems(8).Text = FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsOF.gSimbolo
                .SubItems(9).Text = FormatNumber(dts.gSubTotal, 2) & dtsOF.gSimbolo
            End With
            Call Recalcular()
        End If
    End Sub

    Private Sub Recalcular()
        funcOF.DatosCalculados(dtsOF) 'Recargamos el dtsOF por referencia
        'SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
        BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
    End Sub

    Private Function GuardarGeneral()

        Try

            ep1.Clear()

            ep2.Clear()

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

            If cbTipoIVA.SelectedIndex = -1 Then

                validar = False

                ep1.SetError(cbTipoIVA, "Se ha de seleccionar un tipo de IVA")

            End If

            If cbEstado.SelectedIndex = -1 Then

                validar = False

                ep1.SetError(cbEstado, "Se ha de seleccionar un estado")

            End If

            If cbPersona.SelectedIndex = -1 Then

                ep2.SetError(cbPersona, "No se ha seleccionado una persona")

            End If

            If G_AGeneral = "G" Then

                If cbArticuloR.Text = "" Then

                    validar = False

                    ep1.SetError(cbArticuloR, "Se ha de indicar el artículo objeto de la reparación")

                End If

            End If

            If cbEstatus.SelectedIndex = -1 Then

                validar = False

                ep1.SetError(cbEstatus, "Se ha de seleccionar un estatus")

            End If

            If cbValorado.SelectedIndex = -1 Then

                validar = False

                ep1.SetError(cbValorado, "Se ha de seleccionar como está valorada la reparación")

            End If

            If validar Then

                dtsOF.gRMA = txRMA.Text
                dtsOF.gPrecioTotalReparacion = If(txPrecioTotalReparacion.Text = "", -1, txPrecioTotalReparacion.Text)
                dtsOF.gnumReparacion = numDoc.Text
                dtsOF.gReferenciaCliente = RefCliente.Text
                dtsOF.gEstado = cbEstado.Text
                dtsOF.gFecha = dtpFecha.Value.Date
                dtsOF.gFechaEntrega = dtpFechaPrevista.Value
                dtsOF.gidCliente = cbCliente.SelectedItem.itemdata
                dtsOF.gidUbicacion = cbDireccion.SelectedItem.itemdata
                dtsOF.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
                dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda
                dtsOF.gProntoPago = If(ProntoPago.Text = "", 0, CDbl(ProntoPago.Text))
                dtsOF.gSolicitadoVia = "" 'cbSolicitadoVia.Text
                dtsOF.gNotas = Nota.Text
                dtsOF.gObservaciones = Observaciones.Text
                dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsOF.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
                dtsOF.gTipoValorado = cbValorado.Text
                dtsOF.gidPersona = If(cbPersona.SelectedIndex = -1, 0, cbPersona.SelectedItem.itemdata)
                dtsOF.gPersona = cbPersona.Text
                dtsOF.gidEstatus = cbEstatus.SelectedItem.gidEstatus
                dtsOF.gFechaFabricacion = dtpFechaFabricacion.Value.Date
                If dtpFecha.Value.Date = CDate("1/1/1900") Then
                    dtsOF.gFechaFabricacionRep = ""
                Else
                    dtsOF.gFechaFabricacionRep = dtpFechaFabricacion.Value.Date
                End If
                Call AsignarDOCDatosClienteNoEditables()
                Call AsignarDatosPropiosReparacion()
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

                    dtsOF.gnumReparacion = numDoc.Text

                    funcOF.InsertarLog(dtsOF)

                    G_AGeneral = "A"

                    MsgBox("Creada la Reparacion " & numDoc.Text & ". Ya puede introducir los datos y conceptos.")

                    tpProceso.Enabled = True

                    cbEstado.Items.Add(funcES.EstadoAnulado("REPARACION"))

                    'Debe seguir en estado cabecera
                Else

                    If funcOF.verEstatusReparacion(dtsOF.gnumReparacion) <> dtsOF.gidEstatus Then

                        funcOF.InsertarLog(dtsOF)

                    End If

                    funcOF.actualizar(dtsOF)

                    Call Recalcular()

                End If

                If TabControl1.SelectedTab.Name = "tpProceso" Then Call GuardarTrabajoARealizar()

                cambios = False

                ep1.Clear()

                ep2.Clear()

            End If

            Return validar

        Catch ex As Exception

            ex.Data.Add("Función", "GuardarGeneral")

            ex.Data.Add("numDoc.Text", numDoc.Text)

            CorreoError(ex)

            Return False

        End Try

    End Function

    Private Sub PropagarIVAConceptos(ByVal iidTipoIVAAnterior As Integer)
        If iidTipoIVAAnterior <> dtsOF.gidTipoIVA Then
            funcCO.CambiarTipoIVA(numDoc.Text, dtsOF.gidTipoIVA)
        End If
    End Sub

    Private Sub GuardarTrabajoARealizar()
        Dim dts As New DatosTrabajoReparacion
        dts.gTrabajo = TrabajoARealizar.Text
        dts.gnumReparacion = numDoc.Text
        dts.gHoras = 0
        dts.gidPersona = Inicio.vIdUsuario
        dts.gFechaTrabajo = dtpFecha.Value.Date
        dts.gOrden = 0
        dts.gidTrabajo = funcTRR.ExisteTrabajoARealizar(numDoc.Text)
        If dts.gidTrabajo = 0 Then
            dts.gidTrabajo = funcTRR.insertar(dts)
        Else
            funcTRR.actualizar(dts)
        End If
    End Sub

    Private Function GuardarTrabajoRealizado() As Boolean
        Dim validar As Boolean = True
        If cbRealizadoPor.SelectedIndex = -1 Then
            ep1.SetError(cbRealizadoPor, "Se ha de seleccionar quien realiza el trabajo")
            validar = False
        End If
        If Horas.Text = "" Or Horas.Text = "-" Or Horas.Text = "." Or Horas.Text = "," Then Horas.Text = 0
        If Horas.Text = 0 Then
            ep2.SetError(Horas, "No se ha indicado el tiempo dedicado")
        End If
        If validar Then
            If dtsTRR Is Nothing Then
                dtsTRR = New DatosTrabajoReparacion
            End If
            dtsTRR.gnumReparacion = numDoc.Text
            dtsTRR.gFechaTrabajo = dtpFechaTrabajo.Value.Date
            dtsTRR.gHoras = Horas.Text
            dtsTRR.gOrden = funcTRR.UltimoOrden(numDoc.Text) + 1
            If dtsTRR.gOrden > 1 Then dtsTRR.gOrden = 1
            dtsTRR.gidPersona = cbRealizadoPor.SelectedItem.itemdata
            dtsTRR.gPersona = cbRealizadoPor.Text
            dtsTRR.gTrabajo = TrabajoRealizado.Text
            If dtsTRR.gidTrabajo = 0 Then
                dtsTRR.gidTrabajo = funcTRR.insertar(dtsTRR)
            Else
                funcTRR.actualizar(dtsTRR)
            End If
        End If
    End Function

    Private Function GuardarConcepto() As Boolean
        Dim iidconcepto As Long = 0
        Try
            Dim validar As Boolean = False
            If cbArticulo.Text <> "" Then
                validar = True
                Dim dts As New DatosConceptoReparacion
                dts.gidConcepto = 0
                dts.gnumPedido = 0
                If indice <> -1 Then
                    'si existe, precargamos el concepto
                    iidconcepto = lvConceptos.Items(indice).SubItems(1).Text()
                    If iidconcepto > 0 Then
                        dts = funcCO.Mostrar1(iidconcepto)
                    End If
                End If
                dts.gnumReparacion = numDoc.Text

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

                Dim iidArtCli As Integer = 0
                Dim dtsAC As New DatosArticuloCliente
                Dim dtsACP As DatosArticuloClientePrecio

                If iidArticulo = 0 Then
                    dts.gidArticulo = 0
                    iidArticulo = 0
                Else
                    'iidArticulo = cbArticulo.SelectedItem.itemdata
                    dts.gidArticulo = iidArticulo

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
                    dtsAC.gtipoDoc = "REPARACION"
                    dtsAC.gPrecioNetoUnitario = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
                End If

                Dim SoloReferenciaDoc As Boolean = False
                If indice = -1 Then
                    'Hemos de guardar un nuevo concepto
                    dts.gTipoUnidad = If(iidArticulo = 0, lbUnidad.Text, dtsAR.gTipoUnidad)
                    Dim estado As DatosEstado = funcES.EstadoEspera("C.Reparacion")
                    dts.gidEstado = estado.gidEstado
                    dts.gEstado = estado.gEstado
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
                    dts.gidConcepto = funcCO.insertar(dts)
                    iidconcepto = dts.gidConcepto
                    Call nuevaLineaLV(dts)
                    If lvConceptos.Items.Count > 0 Then 'Si hay items, modificar los estados de la Reparacion
                        Me.Text = "EDITAR REPARACIÓN"

                        cbEstado.SelectedIndex = -1
                        cbEstado.Text = ""
                        Dim x As Integer = cbEstado.FindString(funcES.EstadoCabecera("REPARACION").gEstado)
                        If x <> -1 Then cbEstado.Items.RemoveAt(x) 'Eliminar el estado cabecera

                        Dim dtsES As DatosEstado = funcES.EstadoEnCurso("REPARACION")
                        If cbEstado.FindString(dtsES.gEstado) = -1 Then cbEstado.Items.Add(dtsES)
                        cbEstado.Text = dtsES.ToString
                        funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    End If
                Else
                    'actualizar concepto
                    dts.gTipoUnidad = dtsCO.gTipoUnidad
                    dts.gidConcepto = lvConceptos.Items(indice).SubItems(1).Text
                    If dts.gidArticulo = 0 Then
                        iidArtCli = 0
                    Else
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
                    funcCO.actualizar(dts)
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
                Call LimpiarEdicion()
            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarConcepto")
            ex.Data.Add("numDoc.Text", numDoc.Text)
            ex.Data.Add("iidConcepto", iidconcepto)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
            Return False
        End Try
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
            PVP.Text = FormatNumber(dtsCO.gPVPUnitario, 2)
            Cantidad.Text = dtsCO.gCantidad
            DescuentoC.Text = dtsCO.gDescuento
            PrecioNeto.Text = FormatNumber(dtsCO.gPrecioNetoUnitario, 2)
            subTotal.Text = FormatNumber(dtsCO.gSubTotal, 2)
            'numPedidoC.Text = dtsCO.gnumPedido
            'numReparacionC.Text = dtsCO.gnumReparacion
            semaforo = True
        End If
    End Sub

    Private Sub CargarArticuloC()
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
            semaforo = True
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
#End Region

#Region "BOTONES GENERALES"

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL - 1
                    numDoc.Text = Reparaciones(indiceL)
                    Call CargarReparacion()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                numDoc.Text = Reparaciones(indiceL)
                Call CargarReparacion()
            End If


        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Reparaciones.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    numDoc.Text = Reparaciones(indiceL)
                    Call CargarReparacion()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                numDoc.Text = Reparaciones(indiceL)
                Call CargarReparacion()
            End If


        End If
    End Sub

    Private Sub bTiposIVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim valor As String = cbTipoIVA.Text
        Dim GG As New GestionTiposIVA
        GG.SoloLectura = True
        GG.ShowDialog()
        Call introducirTiposIVA()
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
            dtsCL = funcCL.mostrar1(GG.pidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            cbCliente.Text = dtsCL.gnombrefiscal
            iidCliente = GG.pidCliente
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()

            cambios = True

        End If

    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        'Hay que detectar si borramos el documento o la linea
        If indice = -1 Then
            'Borrar Reparacion
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Reparacion, es como pulsar nuevo
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
                If MsgBox("No es posible borrar una Reparacion existente. ¿Desea anularla?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim dtsES As DatosEstado = funcES.EstadoAnulado("REPARACION")
                    cbEstado.Text = dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    bGuardar.Enabled = False
                    bBorrar.Enabled = False
                End If
            End If
        Else
            'Borrar concepto
            If ConceptosEditables Then
                Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
                If iidConcepto > 0 Then
                    funcCO.borrar(iidConcepto)
                    lvConceptos.Items.RemoveAt(indice)
                    Call LimpiarEdicion()
                    If lvConceptos.Items.Count = 0 Then
                        cbEstado.Items.Clear()
                        cbEstado.Items.Add(funcES.EstadoAnulado("REPARACION"))
                        Dim dtsES As DatosEstado = funcES.EstadoCabecera("REPARACION")
                        cbEstado.Items.Add(dtsES)
                        cbEstado.Text = dtsES.ToString
                        funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    End If
                    Call Recalcular()
                End If
            End If
        End If

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If cbArticulo.Text <> "" Then
            Call LimpiarEdicion()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará una nueva Reparacion. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará una nueva Reparacion. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            End If
        End If

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Dim iidTipoIVAAnterior As Integer = 0

        If G_AGeneral = "A" Then

            iidTipoIVAAnterior = funcOF.idTipoIVA(numDoc.Text)

        End If

        If GuardarGeneral() Then

            Select Case TabControl1.SelectedTab.Name

                Case "tpDatos"

                    Call GuardarTrabajoARealizar()

                Case "tpProceso"

                    Call GuardarTrabajoRealizado()

                    If ConceptosEditables Then

                        If cbArticulo.Text <> "" Then Call GuardarConcepto()

                        Call PropagarIVAConceptos(iidTipoIVAAnterior)

                    Else

                        If cbEstado.SelectedIndex <> -1 AndAlso cbEstado.SelectedItem.gtraspasado Then MsgBox("Conceptos no editables en estado " & cbEstado.Text)

                    End If

            End Select

        End If

    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bTraspasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTraspasar.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la Reparación")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        Else
            Dim validar As Boolean = True
            If cbCliente.SelectedIndex = -1 Then
                ep2.Clear()
                ep1.SetError(cbCliente, "Se ha de seleccionar un cliente")
                validar = False
            Else
                If dtsCL Is Nothing OrElse dtsCL.gnombrecomercial = "" Then dtsCL = funcCL.mostrar1(cbCliente.SelectedItem.itemdata)
            End If

            If cbDireccion.SelectedIndex = -1 Then
                ep2.Clear()
                ep1.SetError(cbDireccion, "Se ha de seleccionar una dirección")
                validar = False
            Else
                If dtsUB Is Nothing OrElse dtsUB.gdireccion = "" Then dtsUB = funcUB.mostrar1(cbDireccion.SelectedItem.itemdata)
            End If
            If validar Then
                Dim RR As New subResumenReparacion
                RR.pnumReparacion = numDoc.Text
                If dtsUB.gidIdioma = 1 Then
                    RR.pResumenFijo = dtsOF.gcodArticuloCli & " SERIE " & dtsOF.gnumSerie & " FABRICACIÓN " & dtsOF.gFechaFabricacion
                    RR.pCodigo = "REPARACIÓN " & numDoc.Text
                Else
                    RR.pResumenFijo = dtsOF.gcodArticuloCli & " SERIAL " & dtsOF.gnumSerie & " MANUFACTURED " & dtsOF.gFechaFabricacion
                    RR.pCodigo = "REPAIR " & numDoc.Text
                End If
                RR.pResumenEditable = ""
                RR.pImporte = Total.Text
                RR.ShowDialog()
                Select Case RR.DialogResult
                    Case Windows.Forms.DialogResult.Cancel
                    Case Windows.Forms.DialogResult.OK
                        Dim dts As New DatosConceptoReparacion
                        dts.gcodArticuloCli = RR.pCodigo
                        dts.gcodArticulo = RR.pCodigo
                        dts.gArticuloCli = RR.pResumenEditable & RR.pResumenFijo
                        dts.gPrecioNetoUnitario = RR.pImporte
                        dts.gPVPUnitario = RR.pImporte
                        Call ConvertirResumen(dts)
                    Case Windows.Forms.DialogResult.Yes
                        Call ConvertirConceptos()
                End Select
            End If

        End If

    End Sub

    Private Sub ConvertirConceptos()
        Dim validar As Boolean = True
        Dim N As Integer = lvConceptos.CheckedItems.Count
        If ckSeleccion.Visible And N > 0 Then
            Dim Conceptos As New List(Of Long)
            Dim iidConcepto As Integer
            For Each item As ListViewItem In lvConceptos.CheckedItems
                iidConcepto = item.SubItems(1).Text
                'Verificamos que la linea no haya sido ya traspasada
                If funcCO.Traspasada(iidConcepto) Then
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
                validar = False
            End If

            If validar Then
                Call LlamarFlujoSiguiente(Conceptos, Nothing, "REPARACION")
            End If
        Else
            If MsgBox("Seleccione los conceptos que se han de convertir en Oferta, Pedido o Proforma ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                ckSeleccion.Visible = True
                lvConceptos.CheckBoxes = True
            End If
        End If

    End Sub

    Private Sub ConvertirResumen(ByVal dts As DatosConceptoReparacion)
        dts.gCantidad = 1
        dts.gidTipoIVA = dtsOF.gidTipoIVA
        dts.gidUnidad = 1
        dts.gidEstado = 0
        Call LlamarFlujoSiguiente(Nothing, dts, "RESUMEN REPARACIÓN")

    End Sub

    Private Sub LlamarFlujoSiguiente(ByVal Conceptos As List(Of Long), ByVal dtsRR As DatosConceptoReparacion, ByVal Desde As String)
        Dim GG As New FlujoSiguiente
        GG.pDesde = Desde
        GG.SoloLectura = vSoloLectura
        GG.pnumDesde = numDoc.Text
        GG.pConceptos = Conceptos
        GG.pdtsRResumen = dtsRR
        GG.pLocalizacion = Me.Location

        Dim SC As New SeleccionConvertirR
        SC.pTitulo = "CONVERTIR REPARACIÓN"
        SC.ShowDialog()
        If SC.pPedido Then
            GG.pHasta = "PEDIDO"
            GG.ShowDialog()
        End If
        If SC.pProforma Then
            GG.pHasta = "PROFORMA"
            GG.ShowDialog()
        End If
        If SC.pOferta Then
            GG.pHasta = "OFERTA"
            GG.ShowDialog()
        End If
        Call CargarReparacion()

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
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la Reparación")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        Else
            InformeReparacion.verInforme(numDoc.Text, dtsUB.gidIdioma, cbcodArticuloR.Text)
            InformeReparacion.ShowDialog()
        End If
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la Reparación")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        Else
            Dim fichero As String = "Reparación SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeReparacion.GeneraPDF(numDoc.Text, dtsUB.gidIdioma, sfd.FileName, "", cbcodArticuloR.Text)
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If
    End Sub

    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beMail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la Reparación")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
       
        Else
            Dim fichero As String = "Reparación SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()
            InformeReparacion.GeneraPDF(numDoc.Text, dtsUB.gidIdioma, fichero, camino, cbcodArticuloR.Text)
            Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
            If cbContacto.SelectedIndex <> -1 Then
                Dim funcMOA As New FuncionesMails
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                Next
            End If
            CorreoOutlook("REPARACIÓN", funcPE.campoCorreo(Inicio.vIdUsuario), Destinatario, camino & fichero, cbContacto.Text, numDoc.Text, dtpFecha.Value.Date, dtpFechaPrevista.Value.Date, funcUB.campoIdioma(cbDireccion.SelectedItem.itemData))
        End If
    End Sub

    Private Sub bEstatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEstatus.Click
        Dim estatus As String = cbEstatus.Text
        Dim GG As New GestionEstatusReparacion
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirEstatus()
        cbEstatus.Text = estatus
        If cbEstatus.SelectedIndex = -1 Then cbEstatus.Text = ""
    End Sub

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
            Call CargarArticulosC()
            Call CargarArticuloC()
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





    Private Sub bVerArticuloR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticuloR.Click

        If cbArticuloR.SelectedIndex <> -1 And cbArticuloR.Text <> "" Then

            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = cbArticuloR.SelectedItem.itemdata
            GG.pModo = "DOC"
            GG.ShowDialog()
            If GG.pidArticulo > 0 Then
                semaforo = False
                cbcodArticuloR.Text = funcAR.codArticulo(GG.pidArticulo)
                cbArticuloR.Text = funcAR.Articulo(GG.pidArticulo)
                semaforo = True
            End If
        Else
            If cbArticuloR.Text <> "" Then
                MsgBox("El concepto no se corresponde con un artículo existente.")
            End If
        End If
    End Sub


    Private Sub bBuscarArticuloR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticuloR.Click
        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "CONCEPTO"
        GG.ShowDialog()
        iidArticuloR = GG.pidArticulo
        If GG.pidArticulo > 0 Then
            semaforo = False
            cbcodArticuloR.Text = funcAR.codArticulo(GG.pidArticulo)
            cbArticuloR.Text = funcAR.Articulo(GG.pidArticulo)
            semaforo = True
        End If
    End Sub


    Private Sub bBuscarEquipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarEquipo.Click
        Dim GG As New BusquedaEquipos
        GG.SoloLectura = vSoloLectura
        GG.pNumSerie = numSerie.Text
        If IsNumeric(numSerie.Text) Then
            GG.pidCliente = 0
            GG.pidArticulo = 0
        Else
            GG.pidCliente = If(cbCliente.SelectedIndex = -1, 0, cbCliente.SelectedItem.itemdata)
            GG.pidArticulo = If(cbArticuloR.SelectedIndex = -1, 0, cbArticuloR.SelectedItem.itemdata)
        End If

        GG.pModo = "REPARACIÓN"
       
        GG.ShowDialog()
        If GG.pidEquipo > 0 Then
            semaforo = False
            Call cargarEquipo(GG.pidEquipo)
            semaforo = True
        ElseIf GG.pidEquipoHistorico > 0 Then
            semaforo = False
            Call cargarEquipoHistorico(GG.pidEquipoHistorico)
            semaforo = True
        End If

    End Sub

    Private Sub cargarEquipo(ByVal iidEquipo As Integer)
        dtsEQ = funcEQ.Mostrar1(iidEquipo)
        FechaServido.Text = dtsEQ.gFechaAlbaran
        cbcodArticuloR.Text = dtsEQ.gcodArticulo
        cbArticuloR.Text = dtsEQ.gArticulo
        numSerie.Text = dtsEQ.gnumSerie
        dtpFechaFabricacion.Value = dtsEQ.gFechaFin
        iidArticuloR = dtsEQ.gidArticulo
    End Sub

    Private Sub cargarEquipoHistorico(ByVal iidEquipoHistorico As Integer)
        dtsEQ = funcEH.Mostrar1Produccion(iidEquipoHistorico)
        FechaServido.Text = dtsEQ.gFechaAlbaran
        numSerie.Text = dtsEQ.gnumSerie
        dtpFechaFabricacion.Value = dtsEQ.gFechaFin
        iidArticuloR = dtsEQ.gidArticulo
        If iidArticuloR = 0 Then
            cbcodArticuloR.SelectedIndex = -1
            cbArticuloR.SelectedIndex = -1
        End If
        cbcodArticuloR.Text = dtsEQ.gcodArticulo
        cbArticuloR.Text = dtsEQ.gArticulo
    End Sub



#End Region

#Region "EVENTOS"

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Call CargarEdicion()
        End If
    End Sub

    Private Sub cbCodCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodCliente.SelectionChangeCommitted
        If cbCodCliente.SelectedIndex <> -1 Then
            iidCliente = cbCodCliente.SelectedItem.itemdata
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCliente.Text = dtsCL.gnombrefiscal
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True
        End If
    End Sub

    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectionChangeCommitted
        If cbCliente.SelectedIndex <> -1 Then
            iidCliente = cbCliente.SelectedItem.itemdata
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True
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

        lbmonedaC.Text = lbMoneda1.Text
        lbMonedaS.Text = lbMoneda1.Text
        lbMonedaN.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text

    End Sub

    Private Sub cbMoneda_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectionChangeCommitted
        If cbMoneda.SelectedIndex <> -1 Then

            'Cambiar moneda en todo el documento
            Dim moneda As String = cbMoneda.SelectedItem.ToString
            If codMonedaI <> cbMoneda.SelectedItem.gcodMoneda Then
                Dim FechaCambio As Date = funcMO.CampoFecha(cbMoneda.SelectedItem.gcodMoneda)
                If FechaCambio <> dtpFecha.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)

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
                        For Each dts As DatosConceptoReparacion In listaC
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
        If semaforo Then
            If cbCodArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbCodArticulo.SelectedItem.itemdata
                Call CargarArticuloC()
                If Cantidad.Text = "0" Then Cantidad.Text = 1
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedValueChanged 'cbArticulo.SelectionChangeCommitted
        If semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                Call CargarArticuloC()
                If Cantidad.Text = "0" Then Cantidad.Text = 1
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbCodArticuloR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticuloR.SelectedValueChanged
        If semaforo Then
            If cbcodArticuloR.SelectedIndex <> -1 Then
                semaforo = False
                cbArticuloR.Text = funcAR.Articulo(CInt(cbcodArticuloR.SelectedItem.itemdata))
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbArticuloR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticuloR.SelectedValueChanged
        If semaforo Then
            If cbArticuloR.SelectedIndex <> -1 Then
                semaforo = False
                cbcodArticuloR.Text = funcAR.codArticulo(cbArticuloR.SelectedItem.itemdata)
                semaforo = True
            End If
        End If
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DescuentoC.Click, ProntoPago.Click, PrecioNeto.Click, PrecioTransporte.Click, numSerie.Click, Horas.Click, FechaServido.Click, OtrosTipos.Click
        sender.selectall()
    End Sub

    Private Sub Cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.TextChanged, DescuentoC.TextChanged, PrecioNeto.TextChanged, PVP.TextChanged
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

    Private Sub PrecioTotalReparacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txPrecioTotalReparacion.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))

        If KeyAscii = Asc(".") Then

            e.KeyChar = ","

        End If

        If InStr(sender.Text, ",") Then

            KeyAscii = CShort(SoloNumeros(KeyAscii))

        Else

            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))

        End If

        If KeyAscii = 0 Then

            e.Handled = True

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

    Private Sub PrecioTransporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioTransporte.KeyPress, numSerie.KeyPress, Horas.KeyPress
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

    Private Sub cbTipoIVA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTipoIVA.KeyPress
        'emula el READ ONLY
        e.Handled = True
    End Sub

    Private Sub cbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCliente.KeyPress, cbCodCliente.KeyPress
        'emula el READ ONLY
        If ClienteSoloLectura Then e.Handled = True
    End Sub

    Private Sub ProntoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nota.TextChanged, Observaciones.TextChanged, ProntoPago.TextChanged,
    dtpFecha.ValueChanged, dtpFechaPrevista.ValueChanged, RefCliente.TextChanged, cbTipoIVA.SelectedIndexChanged, cbContacto.SelectedIndexChanged,
    PrecioTransporte.TextChanged, ckGarantia.CheckedChanged, dtpFechaTrabajo.ValueChanged, Horas.TextChanged, FechaServido.TextChanged, ckCaja.CheckedChanged,
    ckCelula.CheckedChanged, ckSonda.CheckedChanged, OtrosTipos.TextChanged, ckPlaca.CheckedChanged, dtpFechaFabricacion.ValueChanged, txPrecioTotalReparacion.TextChanged
        cambios = True
    End Sub

    Private Sub ckotros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckOtros.CheckedChanged
        cambios = True
        OtrosTipos.Enabled = ckOtros.Checked
    End Sub

    Private Sub numSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSerie.TextChanged
        If semaforo Then
            cambios = True
            iidEquipo = 0
            If IsNumeric(numSerie.Text) Then
                iidEquipo = funcEQ.idEquipo(numSerie.Text)
                If iidEquipo > 0 Then
                    Call cargarEquipo(iidEquipo)
                    HaCargadoEquipo = True
                End If
            End If
            If HaCargadoEquipo And iidEquipo = 0 Then
                FechaServido.Text = ""
                dtpFechaFabricacion.Value = Now.Date
                cbcodArticuloR.Text = ""
                cbArticuloR.Text = ""
                HaCargadoEquipo = False
            End If
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

    Private Sub numPedido_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numPedido.DoubleClick
        If numPedido.Text <> "" And numPedido.Text <> "VARIOS" Then
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = numPedido.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If
    End Sub

    Private Sub numProforma_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numProforma.DoubleClick
        If numProforma.Text <> "" And numProforma.Text <> "VARIOS" Then
            Dim GG As New GestionProforma
            GG.SoloLectura = vSoloLectura
            GG.pnumProforma = numProforma.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If
    End Sub

    Private Sub numOferta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numOferta.DoubleClick
        If numOferta.Text <> "" And numOferta.Text <> "VARIOS" Then
            Dim GG As New GestionOferta
            GG.SoloLectura = vSoloLectura
            GG.pnumOferta = numOferta.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If
    End Sub

    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            Call DatosDireccion()
            cambios = True
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


#End Region

End Class