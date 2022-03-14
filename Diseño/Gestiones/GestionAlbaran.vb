Imports System.IO

Public Class GestionAlbaran

    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private G_AGeneral As Char
    Private Albaranes As List(Of Integer)
    Private indiceL As Integer
    Private indice As Integer
    Private funcMO As New FuncionesMoneda
    Private funcOF As New FuncionesAlbaranes
    Private funcCO As New FuncionesConceptosAlbaranes
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
    Private funcSV As New FuncionesSolicitadoVia
    Private funcRu As New FuncionesRutas
    Private funcAC As New funcionesArticuloCliente
    Private funcACP As New funcionesArticuloClientePrecios
    Private funcPR As New funcionesProveedores
    Private funcSK As New FuncionesStock
    Private funcCP As New FuncionesConceptosPedidos
    Private funcCR As New FuncionesConceptosProduccion
    Private funcPD As New FuncionesPedidos
    Private funcCB As New FuncionesCuentasBancarias
    Private DI As New DatosIniciales
    Private iidArticulo As Integer
    Private dtsOF As DatosAlbaran
    Private dtsCL As datoscliente
    Private dtsFA As datosfacturacion
    Private dtsCO As DatosConceptoAlbaran
    Private dtsAR As DatosArticulo
    Private dtsUB As datosUbicacion
    Private listaC As List(Of DatosConceptoAlbaran)
    Private semaforo As Boolean
    Private iidTipoArticulo As Integer
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private iidCliente As Integer
    Private localizacion As Point
    Private AvisadoCliente As Boolean
    Private ClienteSoloLectura As Boolean
    Private ConceptosEditables As Boolean

    Public Property pnumAlbaran() As Integer
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

    Property pAlbaranes() As List(Of Integer)
        Get
            Return Albaranes
        End Get
        Set(ByVal value As List(Of Integer))
            Albaranes = value
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

    Private Sub GestionAlbaran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            semaforo = True
            If localizacion.X <> 0 Then Me.Location = localizacion
            Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

            If desktopSize.Height < 1000 Then
                Me.Height = desktopSize.Height - 50
            Else
                Me.Height = 950
            End If
            AvisadoCliente = False
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.Icon = My.Resources.Resources.info
            bGuardar.Enabled = Not vSoloLectura
            bBorrar.Enabled = Not vSoloLectura
            dtpFechaPrevista.CustomFormat = "         " 'Para que no se vea la fecha prevista, se ha de ver en estado Servido
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
            Dim cmenu1 As New ContextMenu
            cmenu1.MenuItems.Add("Traspasar el concepto a otro albarán", New System.EventHandler(AddressOf Me.TraspasarConcepto_OnClickPress))
            lvConceptos.ContextMenu = cmenu1
            cbCodArticulo.AutoCompleteMode = AutoCompleteMode.Append
            cbCodArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
            cbArticulo.AutoCompleteMode = AutoCompleteMode.Append
            cbArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
            ClienteSoloLectura = False
            ConceptosEditables = True
            iidUsuario = Inicio.vIdUsuario
            Call introducirMediosPago()
            Call introducirMonedas()
            Call IntroducirTiposArticulo()
            Call introducirTiposIVA()
            Call introducirTiposPago()
            Call introducirTiposRetencion()
            'Call introducirClientes()

            Call introducirSolicitadoVia()
            Call introducirTransporte()
            Call introducirTiposValorado()

            Call InicializarGeneral()
            If numDoc.Text = "" Then numDoc.Text = 0
            If numDoc.Text = 0 Then
                Call introducirClientes()
                Call Nuevo()
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                Me.Text = "EDITAR ALBARÁN"
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
                'G_AGeneral = "A"
            End If

        Catch ex As Exception
            ex.Data.Add("numDoc.text", numDoc.Text)
            CorreoError(ex)
        End Try
    End Sub

    Private Sub GestionAlbaran_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If G_AGeneral = "G" Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub Nuevo()
        Me.Text = "NUEVO ALBARÁN"
        ClienteSoloLectura = False
        cbCliente.Enabled = True
        cbCodCliente.Enabled = True
        bBuscarCliente.Enabled = True
        dtsOF = New DatosAlbaran
        gbConceptos.Enabled = False
        numDoc.Text = funcMA.leernumAlbaran(Now.Year) + 1
        dtpFechaPrevista.Format = DateTimePickerFormat.Custom
        dtpFechaPrevista.Enabled = False
        If numDoc.Text = 0 Then
            funcMA.NuevoAño()
            numDoc.Text = funcMA.leernumAlbaran(Now.Year) + 1
            If numDoc.Text = 0 Then
                MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                Me.Close()
            End If
        End If
        G_AGeneral = "G"
        Dim dtsES As DatosEstado = funcES.EstadoCabecera("Albaran")
        cbEstado.Items.Clear()
        cbEstado.Items.Add(dtsES)
        cbEstado.Text = dtsES.ToString
        iidCliente = 0
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
        numDoc1.Text = ""
        numDoc2.Text = ""
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
        Volumen.Text = ""
        PesoBruto.Text = ""
        PesoNeto.Text = ""
        Medidas.Text = ""
        Bultos.Text = 0
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
        numsSerie.Text = "N/S:"
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

    Private Sub introducirTiposPago()
        Try
            cbTipoPago.Items.Clear()
            Dim lista As List(Of datosTipoPago) = funcTP.mostrar(True)
            Dim dts As datosTipoPago
            For Each dts In lista
                cbTipoPago.Items.Add(dts)
            Next
        Catch ex As Exception
            CorreoError(ex)
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

    Private Sub introducirTiposRetencion()
        Try
            cbRetencion.Items.Clear()
            Dim lista As List(Of DatosTipoRetencion) = funcTR.Mostrar(True)
            Dim dts As DatosTipoRetencion
            For Each dts In lista
                cbRetencion.Items.Add(dts)
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
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Albaran")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next

    End Sub

    Private Sub introducirSolicitadoVia()
        cbSolicitadoVia.Items.Clear()
        Dim lista As List(Of DatosSolicitadoVia) = funcSV.Mostrar
        For Each dts As DatosSolicitadoVia In lista
            cbSolicitadoVia.Items.Add(dts)
        Next
    End Sub

    Private Sub introducirTransporte()
        Try
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

    Private Sub introducirTiposValorado()
        Try
            cbValorado.Items.Clear()
            Dim funcVA As New FuncionesTiposValorado
            Dim lista As List(Of DatosTipoValorado) = funcVA.Mostrar()
            Dim dts As DatosTipoValorado
            For Each dts In lista
                cbValorado.Items.Add(dts)
            Next
        Catch ex As Exception
            CorreoError(ex)
        End Try
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

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarAlbaran()
        Try
            ep1.Clear()
            ep2.Clear()
            G_AGeneral = "A"
            dtsOF = funcOF.Mostrar1(numDoc.Text)
            iidCliente = dtsOF.gidCliente
            dtsCL = funcCL.mostrar1(dtsOF.gidCliente)

            Dim dtsES As DatosEstado = funcES.Mostrar1(dtsOF.gidEstado)
            If dtsES.gBloqueado Then
                cbCliente.Items.Clear()
                cbCodCliente.Items.Clear()
                cbCodCliente.Items.Add(New IDComboBox(dtsCL.gcodCli, dtsCL.gidCliente))
                cbCliente.Items.Add(New IDComboBox(dtsCL.gnombrecomercial, dtsCL.gidCliente))
                ClienteSoloLectura = True
                bBuscarCliente.Enabled = False
            Else
                Call introducirClientes()
                ClienteSoloLectura = False
                bBuscarCliente.Enabled = True
            End If

            cbCliente.Text = dtsOF.gCliente
            cbCodCliente.Text = dtsCL.gcodCli

            Call CargarDatosFacturacionCliente()
            Call CargarCombosCliente()
            Call PresentarAvisoCliente()

            RefCliente.Text = dtsOF.gReferenciaCliente
            RefCliente2.Text = dtsOF.gReferenciaCliente2
            cbPersona.Text = dtsOF.gPersona

            Select Case dtsOF.gnumSFactura.Count
                Case 0
                    numDoc1.Text = ""
                Case 1
                    numDoc1.Text = dtsOF.gnumSFactura(0)
                Case Else
                    numDoc1.Text = "VARIOS"
                    'Dim Facturas As String = ""
                    'For Each n As Integer In dtsOF.gnumSFactura
                    '    If Facturas <> "" Then Facturas = Facturas & ", "
                    '    Facturas = Facturas & n
                    'Next
                    'Dim tt As New ToolTip
                    'tt.InitialDelay = 0
                    'tt.SetToolTip(numDoc1, Facturas)

                    Dim cmNumDoc1 As New ContextMenu
                    For Each numero In dtsOF.gnumSFactura
                        cmNumDoc1.MenuItems.Add(numero, New System.EventHandler(AddressOf Me.OnClickNumDoc1))
                    Next
                    numDoc1.ContextMenu = cmNumDoc1

            End Select

            Select Case dtsOF.gnumSPedido.Count
                Case 0
                    numDoc2.Text = ""
                Case 1
                    numDoc2.Text = dtsOF.gnumSPedido(0)
                Case Else
                    numDoc2.Text = "VARIOS"
                    'Dim Pedidos As String = ""
                    'For Each n As Integer In dtsOF.gnumSPedido
                    '    If Pedidos <> "" Then Pedidos = Pedidos & ", "
                    '    Pedidos = Pedidos & n
                    'Next
                    'Dim tt As New ToolTip
                    'tt.InitialDelay = 0
                    'tt.SetToolTip(numDoc2, Pedidos)

                    Dim cmNumDoc2 As New ContextMenu
                    For Each numero In dtsOF.gnumSPedido
                        cmNumDoc2.MenuItems.Add(numero, New System.EventHandler(AddressOf Me.OnClickNumDoc2))
                    Next
                    numDoc2.ContextMenu = cmNumDoc2


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
            'cbTipoIVA.Text = dtsOF.gNombreTipoIVA & " " & dtsOF.gTipoIVA & "%"

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
            'cbRetencion.Text = dtsOF.gNombreTipoRetencion & " " & dtsOF.gTipoRetencion & "%"

            ProntoPago.Text = FormatNumber(dtsOF.gProntoPago, 2)
            If dtsOF.gidCuentaBanco > 0 Then
                Dim funcCB As New FuncionesCuentasBancarias
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

            If dtsOF.gidTransporte = 0 Then
                cbTransporte.Text = dtsOF.gTransporte
            Else
                cbTransporte.Text = dtsOF.gAgenciaTransporte
            End If

            RefCliente2.Text = dtsOF.gReferenciaCliente2
            Medidas.Text = dtsOF.gMedidas
            ckRecogido.Checked = dtsOF.gRecogido
            cbEstado.Items.Clear()
            'Cargar el estado que tenga y los que falten

            If dtsES.gCabecera Then
                cbEstado.Items.Add(funcES.EstadoCabecera("Albaran"))
                cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
                dtpFechaPrevista.Format = DateTimePickerFormat.Custom 'En Blanco
                dtpFechaPrevista.Enabled = False
            End If
            If dtsES.gAnulado Then
                cbEstado.Items.Add(funcES.EstadoEnCurso("Albaran"))
                cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
                dtpFechaPrevista.Format = DateTimePickerFormat.Short
                dtpFechaPrevista.Enabled = True
            End If
            If dtsES.gEnCurso Then 'PREPARADO
                cbEstado.Items.Add(funcES.EstadoEnCurso("Albaran"))
                cbEstado.Items.Add(funcES.EstadoEntregado("Albaran"))
                cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
                dtpFechaPrevista.Format = DateTimePickerFormat.Custom 'En Blanco
                dtpFechaPrevista.Enabled = False
            End If
            If dtsES.gEntregado Then 'SERVIDO
                cbEstado.Items.Add(funcES.EstadoEntregado("Albaran"))
                dtpFechaPrevista.Format = DateTimePickerFormat.Short
                dtpFechaPrevista.Enabled = True
            End If
            If dtsES.gTraspasado Then 'FACTURADO
                cbEstado.Items.Add(funcES.EstadoTraspasado("Albaran"))
                dtpFechaPrevista.Format = DateTimePickerFormat.Short
                dtpFechaPrevista.Enabled = True
            End If
            cbEstado.Text = dtsES.ToString
            If dtsES.gBloqueado Then
                'gbConceptos.Enabled = False
                ConceptosEditables = False
                bGuardar.Enabled = False
            Else
                'gbConceptos.Enabled = True
                ConceptosEditables = True
                bGuardar.Enabled = Not vSoloLectura
            End If

            Call CargarConceptos()
            SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
            BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
            TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
            TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
            Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
            Total.Text = FormatNumber(dtsOF.gTotal, 2)

            Volumen.Text = FormatNumber(If(dtsOF.gVolumen = 0, dtsOF.gsumaVolumen, dtsOF.gVolumen), 2)
            PesoBruto.Text = FormatNumber(If(dtsOF.gKilosBrutos = 0, dtsOF.gsumaKilosBrutos, dtsOF.gKilosBrutos), 2)
            PesoNeto.Text = FormatNumber(If(dtsOF.gKilosNetos = 0, dtsOF.gsumaKilosNetos, dtsOF.gKilosNetos), 2)
            Bultos.Text = If(dtsOF.gBultos = 0, dtsOF.gsumaBultos, dtsOF.gBultos)

            cambios = False
        Catch ex As Exception
            ex.Data.Add("numDoc.Text", numDoc.Text)
            CorreoError(ex)
        End Try
    End Sub

    Private Sub CargarConceptos()
        funcCO.RenumerarSiEsNecesario(numDoc.Text)
        listaC = funcCO.Mostrar(numDoc.Text)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoAlbaran In listaC
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
                    'dtsUB = funcUB.mostrar1(cbDireccion.Items(0).itemdata)
                    'If dtsUB.gPortes = "P" Then
                    '    cbPortes.Text = "PAGADOS"
                    'Else
                    '    cbPortes.Text = "DEBIDOS"
                    'End If
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

    Private Sub CargarArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
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

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoAlbaran)
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

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoAlbaran)
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
            Call Recalcular(True)
        End If
    End Sub


    Private Sub Recalcular(ByVal CambiaPesos As Boolean)
        'MIRAR LA SUMA DE KILOS *********** campo calculado o no??????????????????
        funcOF.DatosCalculados(dtsOF) 'Recargamos el dtsOF por referencia
        SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
        BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
        If CambiaPesos Then 'Hay que saber si recalculamos o no por si hemos puesto datos a mano
            Volumen.Text = FormatNumber(dtsOF.gsumaVolumen, 2)
            PesoBruto.Text = FormatNumber(dtsOF.gsumaKilosBrutos, 2)
            PesoNeto.Text = FormatNumber(dtsOF.gsumaKilosNetos, 2)
            Bultos.Text = dtsOF.gsumaBultos
        End If
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
                ep1.SetError(cbValorado, "Se ha de seleccionar como está valorado el albarán")
            End If
            If cbPersona.SelectedIndex = -1 Then
                ' validar = False
                ep2.SetError(cbPersona, "No se ha seleccionado un comercial")
            End If
            If validar Then
                dtsOF.gnumAlbaran = numDoc.Text
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

                dtsOF.gDescuento = 0 'If(Descuento.Text = "", 0, CDbl(Descuento.Text))
                dtsOF.gDescuento2 = 0 'If(Descuento2.Text = "", 0, CDbl(Descuento2.Text))
                dtsOF.gProntoPago = If(ProntoPago.Text = "", 0, CDbl(ProntoPago.Text))
                dtsOF.gSolicitadoVia = cbSolicitadoVia.Text
                dtsOF.gNotas = Nota.Text
                dtsOF.gObservaciones = Observaciones.Text
                dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
                dtsOF.gidTipoValorado = cbValorado.SelectedItem.gidTipoValorado
                dtsOF.gTipoValorado = cbValorado.Text
                dtsOF.gVolumen = If(Volumen.Text = "", 0, CDbl(Volumen.Text))
                dtsOF.gKilosBrutos = If(PesoBruto.Text = "", 0, CDbl(PesoBruto.Text))
                dtsOF.gKilosNetos = If(PesoNeto.Text = "", 0, CDbl(PesoNeto.Text))
                dtsOF.gBultos = If(Bultos.Text = "", 0, CInt(Bultos.Text))
                dtsOF.gidPersona = If(cbPersona.SelectedIndex = -1, 0, cbPersona.SelectedItem.itemdata)
                dtsOF.gPersona = cbPersona.Text
                dtsOF.gMedidas = Medidas.Text
                dtsOF.gidProveedor = 0
                dtsOF.gRecogido = ckRecogido.Checked

                Call AsignarDOCDatosClienteNoEditables()

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
                    dtsOF.gnumAlbaran = numDoc.Text
                    G_AGeneral = "A"
                    MsgBox("Creado el Albaran " & numDoc.Text & ". Ya puede introducir los conceptos.")
                    gbConceptos.Enabled = True
                    cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
                    'Debe seguir en estado cabecera
                Else
                    Dim EstadoServido As DatosEstado = funcES.EstadoEntregado("ALBARAN")
                    Dim EstadoPreparado As DatosEstado = funcES.EstadoEnCurso("ALBARAN")
                    If dtsOF.gRecogido AndAlso dtsOF.gidEstado = EstadoPreparado.gidEstado Then
                        'Al guardar el albarán con el check Recogido, si el estado es Preparado, lo pasamos a SERVIDO
                        dtsOF.gidEstado = EstadoServido.gidEstado
                        dtsOF.gEstado = EstadoServido.gEstado
                        If cbEstado.FindString(EstadoServido.gEstado) = -1 Then cbEstado.Items.Add(EstadoServido)
                        cbEstado.Text = EstadoServido.gEstado
                    ElseIf dtsOF.gRecogido = False AndAlso dtsOF.gidEstado = EstadoServido.gidEstado Then
                        'Y viceversa, si no está RECOGIDO pero el estado es SERVIDO, lo pasamos a PREPARADO
                        dtsOF.gidEstado = EstadoPreparado.gidEstado
                        dtsOF.gEstado = EstadoPreparado.gEstado
                        If cbEstado.FindString(EstadoPreparado.gEstado) = -1 Then cbEstado.Items.Add(EstadoPreparado)
                        cbEstado.Text = EstadoPreparado.gEstado
                    End If
                    funcOF.actualizar(dtsOF)
                    Call Recalcular(False)
                    If cbArticulo.Text = "" Then MsgBox("Albarán actualizado correctamente")

                End If
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


    Private Function GuardarConcepto() As Boolean
        Dim iidConcepto As Long = 0
        Try
            Dim validar As Boolean = True
            Dim SoloPrecioEditable As Boolean = False
            If indice <> -1 Then
                If funcCO.Traspasada(lvConceptos.Items(indice).SubItems(1).Text) Then
                    MsgBox("Esta linea ya ha sido traspasada. No se puede modificar.")
                    validar = False
                End If
            End If
            Dim dts As New DatosConceptoAlbaran
            If cbEstado.SelectedIndex = -1 Then
                ep1.SetError(cbEstado, "Estado no seleccionado")
                validar = False
            End If

            If validar Then
                'si existe, precargamos el concepto
                If indice <> -1 Then
                    iidConcepto = lvConceptos.Items(indice).SubItems(1).Text
                End If

                dts = CargardtsCO(iidConcepto) ' funcCO.Mostrar1(iidconcepto)

                Dim estado As DatosEstado = funcES.Mostrar1(cbEstado.SelectedItem.gidestado)

                ' If estado.gEntregado Or estado.gEnCurso Then 'Estado Servido o Preparado 
                If cbEstado.SelectedItem.gEntregado Or cbEstado.SelectedItem.gTraspasado Or cbEstado.SelectedItem.gBloqueado Then
                    If Not MismoArticulo(dts) Then
                        validar = False
                        MsgBox("En estado " & estado.gEstado & " no se puede cambiar el artículo.")
                    End If
                End If

            End If
            If cbArticulo.Text = "" Then
                validar = False
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
                    dtsAC.gtipoDoc = "ALBARAN"
                    dtsAC.gPrecioNetoUnitario = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
                End If
                Dim SoloReferenciaDoc As Boolean = False
                If indice = -1 Then
                    Call GuardarNuevoConcepto(dts, dtsAC, SoloReferenciaDoc)
                Else
                    Call ActualizarConcepto(dts, dtsAC, SoloReferenciaDoc)

                End If
                'Guardar el precio específico si ha cambiado y no guardamos sólo la referencia al documento

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

                Call Recalcular(True)
                Call LimpiarEdicion()
            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarConcepto")
            ex.Data.Add("numDoc.Text", numDoc.Text)
            ex.Data.Add("iidConcepto", iidConcepto)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
            Return False
        End Try
    End Function


    Private Sub GuardarNuevoConcepto(ByVal dts As DatosConceptoAlbaran, ByVal dtsAC As DatosArticuloCliente, ByVal SoloReferenciaDoc As Boolean)
        'Hemos de guardar un nuevo concepto
        dts.gTipoUnidad = If(iidArticulo = 0, lbUnidad.Text, dtsAR.gTipoUnidad)
        Dim estado As DatosEstado = funcES.EstadoEspera("C.ALBARAN")
        dts.gidEstado = estado.gidEstado
        dts.gEstado = estado.gEstado
        'Si ha habido cambio, hemos de guardar los cambios en ArticuloCliente
        Dim iidArtCli As Integer
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
        Call nuevaLineaLV(dts)
        'Ahora hemos de descontar del stock
        dtsCO = dts
        Call RevisarStock(dts.gidConcepto)
        If lvConceptos.Items.Count > 0 Then 'Si hay items, modificar el estado del albarán
            Me.Text = "EDITAR ALBARÁN"
            'cbEstado.Items.Clear()
            'cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
            cbEstado.SelectedIndex = -1
            cbEstado.Text = ""
            Dim x As Integer = cbEstado.FindString(funcES.EstadoCabecera("ALBARAN").gEstado)
            If x <> -1 Then cbEstado.Items.RemoveAt(x) 'Eliminar el estado cabecera


            Dim dtsES As DatosEstado = funcES.EstadoEnCurso("Albaran")
            If cbEstado.FindString(dtsES.gEstado) = -1 Then cbEstado.Items.Add(dtsES)
            cbEstado.Text = dtsES.ToString
            funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
        End If
    End Sub

    Private Sub ActualizarConcepto(ByVal dts As DatosConceptoAlbaran, ByVal dtsAC As DatosArticuloCliente, ByVal SoloReferenciaDoc As Boolean)
        Dim Validar As Boolean = True
        'Detectar si hay un cambio de cantidad respecto al pedido. En su caso preguntar qué hacer
        If dtsCO.gidConceptoPedido > 0 Then

            'Dim CantidadServidaAntes As Double = funcCP.CantidadServidaEnOtrosConceptosAlbaran(dtsCO.gidConceptoPedido, dtsCO.gidConcepto)
            'Dim CantidadPendienteServirAntes As Double = funcCP.Cantidad(dts.gidConceptoPedido) - CantidadServidaAntes
            'Comprobamos si hay diferencia entre la cantidad servida y la cantidad indicada servida en el pedido.
            Validar = True
            If Math.Abs(dtsCO.gCantidad - dts.gCantidad) > 0.00001 Then
                If MsgBox("La cantidad que se iba a servir de este concepto era " & dtsCO.gCantidad & dts.gTipoUnidad & vbCrLf & "¿Guardar la nueva cantidad y realizar los cambios correspondientes en el pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call ActualizarConceptoPedido(dts)
                Else
                    Validar = False
                End If
            End If
        End If
        Dim iidArtCli As Integer = 0
        If Validar Then
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
            Call ActualizarLineaLV(dts)
            'Ahora hemos de revisar stock (si ha cambiado la cantidad, generará un movimiento)
            If iidArticulo > 0 Then Call RevisarStock(dts.gidConcepto)
        End If
    End Sub



    Private Sub ActualizarConceptoPedido(ByVal dts As DatosConceptoAlbaran)
        Dim CantidadServidaAntes As Double = funcCP.CantidadServidaEnOtrosConceptosAlbaran(dtsCO.gidConceptoPedido, dtsCO.gidConcepto)
        Dim CantidadPendienteServirAntes As Double = funcCP.Cantidad(dts.gidConceptoPedido) - CantidadServidaAntes
        Dim CantidadConceptoPedido As Double = funcCP.Cantidad(dtsCO.gidConceptoPedido)
        Dim CantidadPreparadaAntes As Double
        Dim iidProduccion As Long = funcCR.ExisteProduccion(dts.gidConceptoPedido)
        If iidProduccion > 0 Then 'Artículo producible
            Dim EstadoProduccion As DatosEstado = funcES.Mostrar1(funcCR.idEstado(iidProduccion))
            If EstadoProduccion.gCompleto Then 'Todos producidos
                CantidadPreparadaAntes = CantidadConceptoPedido - CantidadServidaAntes
            Else
                Dim funcEQ As New FuncionesEquiposProduccion
                Dim EquiposCompletos As Integer = funcEQ.CuantosAcabados(iidProduccion)
                CantidadPreparadaAntes = EquiposCompletos - CantidadServidaAntes
            End If
        Else
            If funcAR.Escandallo(dts.gidArticulo) Then
                'Si tiene escandallo pero no tiene idProducción es que realmente no hay ninguno preparado
                CantidadPreparadaAntes = 0
            Else
                CantidadPreparadaAntes = CantidadConceptoPedido - CantidadServidaAntes
            End If
        End If
        Dim iidConceptoPedido As Long = dts.gidConceptoPedido
        Dim NuevaCantidadPreparada As Double
        Dim NuevaCantidadServida As Double
        If dts.gCantidad < CantidadPendienteServirAntes Then
            'Si la cantidad servida es menor que la pendiente de servir, la cambiamos y guardamos la diferencia como Preparado
            NuevaCantidadServida = dts.gCantidad + CantidadServidaAntes
            NuevaCantidadPreparada = CantidadPreparadaAntes - dts.gCantidad
        End If
        If dts.gCantidad > CantidadPendienteServirAntes Then
            NuevaCantidadServida = dts.gCantidad + CantidadServidaAntes
            NuevaCantidadPreparada = 0
            If NuevaCantidadServida > CantidadConceptoPedido Then
                'Estamos sirviendo más de la cantidad pedida, aumentamos la cantidad en el pedido
                If MsgBox("Se van a servir más unidades de las pedidas. ¿Aumentar la cantidad en el pedido?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    funcCP.CambiarCantidad(iidConceptoPedido, NuevaCantidadServida)
                End If
            End If
        End If

        If dts.gCantidad <> CantidadPendienteServirAntes Then
            funcCP.CambiarCantidadServida(iidConceptoPedido, NuevaCantidadServida)
            If NuevaCantidadPreparada < 0 Then NuevaCantidadPreparada = 0
            funcCP.CambiarCantidadPreparada(iidConceptoPedido, NuevaCantidadPreparada)
        End If
        'Volvemos a calcular la cantidad preparada
        funcCP.CambiarCantidadPreparada(iidConceptoPedido, funcCP.CantidadPreparadaRealmente(iidConceptoPedido))
        Call CalcularEstadosPedido(iidArticulo, iidConceptoPedido, iidProduccion)

    End Sub

    Private Sub CalcularEstadosPedido(ByVal iidArticulo As Integer, ByVal iidConceptoPedido As Long, ByVal iidProduccion As Long)
        'Revisar estados
        Dim dtsCP As DatosConceptoPedido = funcCP.Mostrar1(iidConceptoPedido)
        If dtsCP.gCantidadServida >= dtsCP.gCantidad Then
            'La linea está servida
            funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("SERVIDO").gidEstado)
        ElseIf dtsCP.gCantidadPreparada > 0 Then
            'La linea no está servida completamente pero no sabemos el estado, hay que deducirlo
            If funcAR.Escandallo(iidArticulo) Then
                If iidProduccion > 0 Then
                    'Si existe producción lo pondremos en estado 
                    funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("RECIBIDO PRODUCCION").gidEstado)
                Else
                    funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("CREADO").gidEstado)
                End If
            Else
                funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("ENVIADO PRODUCCION").gidEstado)
            End If
        Else
            If funcAR.Escandallo(iidArticulo) Then 'CantidadPreparada = 0
                If iidProduccion > 0 Then
                    'Si existe producción lo pondremos en estado 
                    funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("RECIBIDO PRODUCCION").gidEstado)
                Else
                    funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("CREADO").gidEstado)
                End If
            Else
                funcCP.CambiarEstado(iidConceptoPedido, funcES.EstadoCPedido("CREADO").gidEstado)
            End If
        End If
        If funcCP.CantidadServida(iidConceptoPedido) = 0 Then
            funcCP.CambiarNum(iidConceptoPedido, 0, "ALBARAN") 'Si el concepto de pedido queda con cantidad servida = 0, eliminar la referencia al albarán.
        End If
        'ESTADO DEL PEDIDO
        If funcCP.TodosTraspasados(dtsCO.gnumPedido) Then
            funcPD.actualizaEstado(dtsCO.gnumPedido, funcES.EstadoPedido("SERVIDO").gidEstado)
        ElseIf funcCP.AlgunoTraspasado(dtsCO.gnumPedido) Or funcCP.AlgunoPARCIAL(dtsCO.gnumPedido) Then
            funcPD.actualizaEstado(dtsCO.gnumPedido, funcES.EstadoPedido("PARCIAL").gidEstado)
        ElseIf funcCP.AlgoPreparado(dtsCO.gnumPedido) Then
            funcPD.actualizaEstado(dtsCO.gnumPedido, funcES.EstadoPedido("PREPARADO").gidEstado)
        ElseIf funcCP.AlgunoenProduccion(dtsCO.gnumPedido) Then
            funcPD.actualizaEstado(dtsCO.gnumPedido, funcES.EstadoPedido("PRODUCCIÓN").gidEstado)
        Else
            funcPD.actualizaEstado(dtsCO.gnumPedido, funcES.EstadoPedido("PENDIENTE").gidEstado)
        End If

    End Sub

    Private Function CargardtsCO(ByVal iidConcepto As Long) As DatosConceptoAlbaran
        Dim dts As DatosConceptoAlbaran
        If iidConcepto = 0 Then
            dts = New DatosConceptoAlbaran
            dts.gidConcepto = 0
            dts.gnumFactura = 0
        Else
            dts = funcCO.Mostrar1(iidConcepto)
        End If

        dts.gnumAlbaran = numDoc.Text

        dts.gnumPedido = If(numDoc2.Text = "" Or numDoc2.Text = "VARIOS", 0, CInt(numDoc2.Text))
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
        dts.gnumsSerie = numsSerie.Text
        If dts.gnumsSerie = "N/S:" Then dts.gnumsSerie = ""
        dts.gOrden = indice + 1
        dts.gidConceptoPedidoProv = 0
        dts.gidArticuloProv = 0
        dts.gidArticulo = iidArticulo
        Return dts
    End Function


    Private Function MismoArticuloYCantidad(ByVal dtsNuevo As DatosConceptoAlbaran) As Boolean
        Dim dtsORiginal As DatosConceptoAlbaran = funcCO.Mostrar1(dtsNuevo.gidConcepto)
        If dtsORiginal.gidArticulo = dtsNuevo.gidArticulo And dtsORiginal.gCantidad = dtsNuevo.gCantidad Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function MismoArticulo(ByVal dtsNuevo As DatosConceptoAlbaran) As Boolean
        Dim dtsORiginal As DatosConceptoAlbaran = funcCO.Mostrar1(dtsNuevo.gidConcepto)
        If dtsORiginal.gidArticulo = dtsNuevo.gidArticulo Then
            Return True
        Else
            Return False
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
            PVP.Text = FormatNumber(dtsCO.gPVPUnitario, 2)
            Cantidad.Text = dtsCO.gCantidad
            DescuentoC.Text = dtsCO.gDescuento
            PrecioNeto.Text = FormatNumber(dtsCO.gPrecioNetoUnitario, 2)
            subTotal.Text = FormatNumber(dtsCO.gSubTotal, 2)
            numsSerie.Text = dtsCO.gnumsSerie
            'numAlbaranC.Text = dtsCO.gnumAlbaran
            'numProformaC.Text = dtsCO.gnumProforma
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

    Private Sub TraspasarConcepto_OnClickPress(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvConceptos.SelectedItems.Count > 0 Then
            If cbEstado.SelectedItem.gtraspasado Then
                MsgBox("No es posible modificar un albarán " & cbEstado.Text)
            Else
                Dim dts As DatosConceptoAlbaran = funcCO.Mostrar1(lvConceptos.SelectedItems(0).SubItems(1).Text)
                Dim GG As New TraspasarConceptoAlbaran
                GG.SoloLectura = vSoloLectura
                GG.pDts = dts
                GG.pLocalizacion = Me.Location
                GG.ShowDialog()
                Call CargarAlbaran()
            End If

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
                    numDoc.Text = Albaranes(indiceL)
                    Call CargarAlbaran()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                numDoc.Text = Albaranes(indiceL)
                Call CargarAlbaran()
            End If


        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Albaranes.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    numDoc.Text = Albaranes(indiceL)
                    Call CargarAlbaran()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                numDoc.Text = Albaranes(indiceL)
                Call CargarAlbaran()
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

    'Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
    '    If cbCliente.SelectedIndex <> -1 Then
    '        Dim cliente As String = cbCliente.Text
    '        Dim codcli As Integer = cbCodCliente.Text
    '        Dim GG As New GestionClientes
    '        GG.SoloLectura = vSoloLectura
    '        GG.pidCliente = cbCliente.SelectedItem.itemdata
    '        GG.ShowDialog()
    '        Call introducirClientes()
    '        cbCliente.Text = cliente
    '        cbCodCliente.Text = codcli
    '        If cbCliente.SelectedIndex = -1 Then
    '            cbCliente.Text = ""
    '            cbCodCliente.Text = ""
    '        Else
    '            iidCliente = cbCodCliente.SelectedItem.itemdata
    '            Call CargarDatosCliente()
    '        End If
    '    End If

    'End Sub

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
            Call Recalcular(False)
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
            cbCliente.Text = dtsCL.gnombrecomercial
            iidCliente = GG.pidCliente
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True

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
            'Borrar Albaran
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Albaran, es como pulsar nuevo
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
                If MsgBox("No es posible borrar una Albaran existente. ¿Desea anularla?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim dtsES As DatosEstado = funcES.EstadoAnulado("Albaran")
                    cbEstado.Text = dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    bGuardar.Enabled = False
                    bBorrar.Enabled = False
                End If
            End If
        Else
            'Borrar concepto
            If ConceptosEditables Then
                Dim validar = True
                If cbEstado.SelectedIndex <> -1 Then
                    Dim estado As DatosEstado = funcES.Mostrar1(cbEstado.SelectedItem.gidestado)
                    If estado.gEntregado Then
                        MsgBox("Este albarán ya ha sido servido. No se pueden modificar los conceptos.")
                        validar = False
                    End If
                End If
                If validar Then
                    Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
                    If iidConcepto > 0 Then
                        If funcCO.Traspasada(iidConcepto) Then
                            MsgBox("La linea indicada ya ha sido traspasada. No se puede borrar.")
                        Else
                            Dim numPedidoLinea As Integer = funcCO.numPedido(iidConcepto)
                            If numPedidoLinea > 0 Then
                                If MsgBox("Esta linea de albarán corresponde al pedido " & numPedidoLinea & vbCrLf & "¿Desea borrarla y modificar la cantidad servida el la linea de pedido?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                                    Dim dtsCO As DatosConceptoAlbaran = funcCO.Mostrar1(iidConcepto)
                                    dtsCO.gCantidad = 0 'Estamos borrando la linea completa
                                    Call ActualizarConceptoPedido(dtsCO)
                                    Call BorrarConcepto(iidConcepto)
                                End If
                            Else
                                Call BorrarConcepto(iidConcepto)
                            End If

                        End If
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub BorrarConcepto(ByVal iidConcepto As Long)
        funcCO.borrar(iidConcepto, numDoc.Text)
        lvConceptos.Items.RemoveAt(indice)
        Call LimpiarEdicion()
        If lvConceptos.Items.Count = 0 Then
            cbEstado.Items.Clear()
            cbEstado.Items.Add(funcES.EstadoAnulado("Albaran"))
            Dim dtsES As DatosEstado = funcES.EstadoCabecera("Albaran")
            cbEstado.Items.Add(dtsES)
            cbEstado.Text = dtsES.ToString
            funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
        End If
        Call Recalcular(True)
    End Sub


    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If cbArticulo.Text <> "" Then
            Call LimpiarEdicion()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará un nuevo albarán. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call introducirClientes()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará una nuevo albarán. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
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
            If ConceptosEditables Then
                If cbArticulo.Text <> "" Then Call GuardarConcepto()
                Call PropagarIVAConceptos(iidTipoIVAAnterior)
            End If
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bTraspasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTraspasar.Click
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
            Else
                Dim GG As New FlujoSiguiente
                GG.SoloLectura = vSoloLectura
                GG.pDesde = "Albaran"
                GG.pHasta = "Factura"
                GG.pnumDesde = numDoc.Text
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
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            InformeAlbaran.verInforme(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion))
            InformeAlbaran.ShowDialog()
        End If
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Albaran SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeAlbaran.GeneraPDF(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), sfd.FileName, "")
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If
    End Sub



    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beMail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado el albarán")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Albaran SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()
            InformeAlbaran.GeneraPDF(numDoc.Text, funcUB.campoIdioma(dtsOF.gidUbicacion), fichero, camino)
            Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
            If cbContacto.SelectedIndex <> -1 Then
                Dim funcMOA As New FuncionesMails
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                Next
            End If

            CorreoOutlook("ALBARÁN CLIENTE", funcPE.campoCorreo(iidUsuario), Destinatario, camino & fichero, cbContacto.Text, numDoc.Text, dtpFecha.Value.Date, dtpFechaPrevista.Value.Date, funcUB.campoIdioma(dtsOF.gidUbicacion))

        End If
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
                    'indice = indiceInferior
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
                    'indice = indiceSuperior
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
            iidCliente = cbCodCliente.SelectedItem.itemdata
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCliente.Text = dtsCL.gnombrecomercial
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
            'AvisadoCliente = False
            Call PresentarAvisoCliente()
            Call CargarDatosFacturacionCliente()
            Call CargarDatosClienteNoEditables()
            Call CargarCombosCliente()
            cambios = True
        End If
    End Sub

    Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
        If semaforo AndAlso cbMedioPago.SelectedIndex <> -1 Then
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
            cambios = True
        End If

    End Sub

    Private Sub cbTipoPago_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoPago.SelectedIndexChanged
        If semaforo AndAlso cbTipoPago.SelectedIndex <> -1 Then
            If cbTipoPago.SelectedItem.gProntoPago Then
                ProntoPago.Enabled = True
                ProntoPago.Text = If(dtsFA Is Nothing, 0, dtsFA.gProntoPago)
            Else
                ProntoPago.Enabled = False
                ProntoPago.Text = 0
            End If
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
                If Not cbEstado.SelectedItem.gBloqueado Then
                    For Each item As ListViewItem In lvConceptos.Items
                        Call RevisarStock(item.SubItems(1).Text)
                    Next
                End If
            End If
            If cbEstado.SelectedItem.gEntregado Or cbEstado.SelectedItem.gTraspasado Then
                dtpFechaPrevista.Format = DateTimePickerFormat.Short
            Else
                dtpFechaPrevista.Format = DateTimePickerFormat.Custom
            End If

        End If
    End Sub

    Private Sub RevisarStock(ByVal iidConcepto As Integer)
        'Comprobamos si todas las cantidades de los conceptos están ya en el stock, si no es así, se crean los movimientos
        Dim CS As Double = funcSK.CantidadConceptoAlbaran(iidConcepto)
        Dim dtsCA As DatosConceptoAlbaran = funcCO.Mostrar1(iidConcepto)
        If dtsCO Is Nothing Then dtsCO = funcCO.Mostrar1(iidConcepto)
        If Math.Abs(dtsCA.gCantidad + CS) > 0.00001 Then 'A veces las cantidades tipo double pueden descuadrar un poco debido a redondeos
            Dim dtsSK As New DatosStock
            dtsSK.gidArticulo = dtsCA.gidArticulo
            dtsSK.gidAlmacen = 0
            dtsSK.gCantidad = -CS - CDbl(dtsCA.gCantidad)
            dtsSK.gidUnidad = dtsCO.gidUnidad
            dtsSK.gidLote = 0
            dtsSK.gidArticuloProv = 0
            dtsSK.gidPersona1 = iidUsuario
            dtsSK.gidPersona2 = 0
            dtsSK.gMovimiento = ""
            dtsSK.gFecha = Now
            dtsSK.gPrecio = dtsCO.gPrecioNetoUnitario
            dtsSK.gcodMoneda = dtsOF.gcodMoneda
            dtsSK.gidConceptoProv = 0
            dtsSK.gidConceptoAlbaran = dtsCO.gidConcepto
            dtsSK.gidProduccion = 0
            funcSK.insertar(dtsSK)
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
                        For Each dts As DatosConceptoAlbaran In listaC
                            funcCO.CambiarPrecio(dts.gidConcepto, funcMO.Cambio(dts.gPVPUnitario, codMonedaI, codMonedaActual, True, Now.Date), funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        Call CargarConceptos()
                        Call Recalcular(False)
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

    Private Sub ckRecargoEquivalencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckRecargoEquivalencia.Click, ckRecogido.Click
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

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DescuentoC.Click, ProntoPago.Click, PrecioNeto.Click, Bultos.Click, Volumen.Click, PesoBruto.Click, PesoNeto.Click, PrecioTransporte.Click, Medidas.Click
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

    Private Sub PesoBruto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PesoBruto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PesoBruto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PesoNeto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PesoNeto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PesoNeto.Text, ",") Then
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

    Private Sub ProntoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nota.TextChanged, Observaciones.TextChanged, ProntoPago.TextChanged, _
    dtpFecha.ValueChanged, dtpFechaPrevista.ValueChanged, RefCliente.TextChanged, cbRetencion.SelectedIndexChanged, cbTipoIVA.SelectedIndexChanged, cbCuenta.SelectedIndexChanged, _
    cbContacto.SelectedIndexChanged, cbSolicitadoVia.SelectedIndexChanged, Bultos.TextChanged, Volumen.TextChanged, cbTransporte.SelectedIndexChanged, PesoBruto.TextChanged, _
    PesoNeto.TextChanged, cbValorado.SelectedIndexChanged, RefCliente2.TextChanged, PrecioTransporte.TextChanged, ckRecargoEquivalencia.CheckedChanged, cbPersona.SelectionChangeCommitted, Medidas.TextChanged, ckRecogido.CheckedChanged
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

    Protected Sub OnClickNumDoc1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc1.DoubleClick
        If sender.text = "VARIOS" Then
            MsgBox("Hay varias facturas asociadas. Pulse botón derecho para acceder a ellas.")
        ElseIf IsNumeric(sender.Text) AndAlso sender.text <> 0 Then
            Dim GG As New GestionFactura1
            GG.SoloLectura = vSoloLectura
            GG.pnumFactura = sender.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If
    End Sub

    Protected Sub OnClickNumDoc2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc2.DoubleClick
        If sender.text = "VARIOS" Then
            MsgBox("Hay varios pedidos asociados. Pulse botón derecho para acceder a ellos.")
        ElseIf IsNumeric(sender.Text) AndAlso sender.text <> 0 Then
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = sender.Text
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

#End Region

End Class