Imports System.IO

Public Class GestionOferta


    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private cambios As Boolean
    Private G_AGeneral As Char
    Private Ofertas As List(Of Integer)
    Private indiceL As Integer
    Private indice As Integer
    Private funcMO As New FuncionesMoneda
    Private funcOF As New FuncionesOfertas
    Private funcCO As New FuncionesConceptosOfertas
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
    Private DI As New DatosIniciales
    Private iidArticulo As Integer
    Private dtsOF As DatosOferta
    Private dtsCL As datoscliente
    Private dtsFA As datosfacturacion
    Private dtsCO As DatosConceptoOferta
    Private dtsAR As DatosArticulo
    Private listaC As List(Of DatosConceptoOferta)
    Private semaforo As Boolean
    Private iidTipoArticulo As Integer
    Private codMonedaI As String 'Moneda de inicio, para poder hacer el cambio
    Private iidCliente As Integer
    Private localizacion As Point
    Private iidIdioma As Byte
    Private AvisadoCliente As Boolean

    Public Property pnumOferta() As Integer
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


    Property pOfertas() As List(Of Integer)
        Get
            Return Ofertas
        End Get
        Set(ByVal value As List(Of Integer))
            Ofertas = value
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

    Private Sub GestionOferta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = True
        iidIdioma = 1
        If localizacion.X <> 0 Then Me.Location = localizacion
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 950 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 900
        End If
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
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

        cbCodArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbCodArticulo.AutoCompleteSource = AutoCompleteSource.ListItems
        cbArticulo.AutoCompleteMode = AutoCompleteMode.Append
        cbArticulo.AutoCompleteSource = AutoCompleteSource.ListItems

        iidUsuario = Inicio.vIdUsuario
        Call introducirMediosPago()
        Call introducirMonedas()
        Call IntroducirTiposArticulo()
        'Call introducirTiposIVA()
        Call introducirTiposPago()
        'Call introducirTiposRetencion()
        Call introducirClientes()
        'Call introducirEstados()
        Call introducirSolicitadoVia()
        'Call introducirComerciales()
        Call introducirTransporte()
        Call InicializarGeneral()
        If numDoc.Text = "" Then numDoc.Text = 0
        If numDoc.Text = 0 Then
            Call Nuevo()
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            Me.Text = "EDITAR OFERTA"
            gbConceptos.Enabled = True
            If Ofertas Is Nothing Then
                bSubir.Visible = False
                bBajar.Visible = False
            Else
                If Ofertas.Count > 0 Then
                    bSubir.Visible = True
                    bBajar.Visible = True
                Else
                    bSubir.Visible = False
                    bBajar.Visible = False
                End If
            End If

            Call CargarOferta()
            'G_AGeneral = "A"
        End If
        cbCliente.Focus()

    End Sub


    Private Sub GestionOferta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        Me.Text = "NUEVA OFERTA"
        cbCliente.Enabled = True
        cbCodCliente.Enabled = True
        bBuscarCliente.Enabled = True
        dtsOF = New DatosOferta
        gbConceptos.Enabled = False
        numDoc.Text = funcMA.leernumOferta(Now.Year) + 1
        If numDoc.Text = 0 Then
            funcMA.NuevoAño()
            numDoc.Text = funcMA.leernumPedido(Now.Year) + 1
            If numDoc.Text = 0 Then
                MsgBox("Ha habido un error en la creación de la nueva numeración." & vbCrLf & "Póngase en contacto con el servicio técnico.")
                Me.Close()
            End If
        End If
        G_AGeneral = "G"
        Dim dtsES As DatosEstado = funcES.EstadoCabecera("OFERTA")
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
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbCodCliente.Text = ""
        cbCodCliente.SelectedIndex = -1
        OfertaCliente.Text = ""
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
        Call LimpiarEdicion()
        cambios = False
    End Sub

    Private Sub LimpiarCabecera()
        'Limpiar datos de cliente y pago
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbDireccion.Items.Clear()
        'ObservacionesCli.Text = ""
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
        tbTipoIVA.Text = DI.TipoIVA.ToString
        tbRetencion.Text = DI.TipoRetencion.ToString
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
        'numPedidoC.Text = ""
        'numProformaC.Text = ""
        'EstadoC.Text = ""
        cbArticulo.Items.Clear()
        cbCodArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
        'Call CargarArticulos
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

    'Private Sub introducirTiposIVA()
    '    Try
    '        cbTipoIVA.Items.Clear()
    '        Dim lista As List(Of DatosTipoIVA) = funcTI.Mostrar(True)
    '        Dim dts As DatosTipoIVA
    '        For Each dts In lista
    '            cbTipoIVA.Items.Add(dts)
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub introducirTiposRetencion()
    '    Try
    '        cbRetencion.Items.Clear()
    '        Dim lista As List(Of DatosTipoRetencion) = funcTR.Mostrar(True)
    '        Dim dts As DatosTipoRetencion
    '        For Each dts In lista
    '            cbRetencion.Items.Add(New IDComboBox(dts.gNombre & " " & dts.gTipoRetencion & "%", dts.gidTipoRetencion))
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("OFERTA")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next

    End Sub


    Private Sub introducirTransporte()
        Try
            cbPortes.Items.Clear()
            cbPortes.Items.Add("DEBIDOS")
            cbPortes.Items.Add("INC.FRA.")
            cbPortes.Items.Add("PAGADOS")
            cbPortes.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

#End Region


#Region "CARGAR DATOS"

    Private Sub CargarOferta()
        ep1.Clear()
        ep2.Clear()
        G_AGeneral = "A"
        dtsOF = funcOF.Mostrar1(numDoc.Text)
        cbCliente.Text = dtsOF.gCliente
        dtsCL = funcCL.mostrar1(dtsOF.gidCliente)
        cbCodCliente.Text = dtsCL.gcodCli
        iidCliente = dtsOF.gidCliente
        Call CargarDatosCliente()
        OfertaCliente.Text = dtsOF.gReferenciaCliente
        cbPersona.Text = dtsOF.gPersona
        Select Case dtsOF.gnumSPedido.Count
            Case 0
                numDoc1.Text = ""
            Case 1
                numDoc1.Text = dtsOF.gnumSPedido(0)
            Case Else
                numDoc1.Text = "VARIOS"
        End Select
        Select Case dtsOF.gnumSProforma.Count
            Case 0
                numDoc2.Text = ""
            Case 1
                numDoc2.Text = dtsOF.gnumSProforma(0)
            Case Else
                numDoc2.Text = "VARIOS"
        End Select
        'cbEstado.Items.Clear()
        cbMoneda.Text = dtsOF.gDivisa
        lbMoneda1.Text = dtsOF.gSimbolo
        codMonedaI = dtsOF.gcodMoneda
        dtpFecha.Value = dtsOF.gFecha
        dtpFechaPrevista.Value = dtsOF.gFechaEntrega
        cbDireccion.Text = dtsOF.gDireccion
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
        'If dtsOF.gPortes = "P" Then
        '    cbPortes.Text = "PAGADOS"
        '    PrecioTransporte.Text = 0
        'End If
        'If dtsOF.gPortes = "D" Then
        '    cbPortes.Text = "DEBIDOS"
        '    PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
        'End If
        iidIdioma = funcUB.campoIdioma(dtsOF.gidUbicacion)
        'ObservacionesCli.Text = dtsOF.gObservacionesCli
        'If Trim(dtsOF.gObservacionesCli).Length > 0 Then
        '    MsgBox(dtsOF.gObservacionesCli, MsgBoxStyle.OkOnly, "AVISO " & dtsOF.gCliente)
        'End If
        cbContacto.Text = dtsOF.gContacto
        cbMedioPago.Text = dtsOF.gMedioPago
        cbTipoPago.Text = dtsOF.gTipoPago
        tbTipoIVA.Text = dtsOF.gNombreTipoIVA & " " & dtsOF.gTipoIVA & "%"
        'ckRecargoEquivalencia.Checked = 
        If dtsOF.gRecargoEquivalencia Then
            '  TipoRecargoEq.Enabled = True
            TipoRecargoEq.Text = dtsOF.gTipoRecargoEq
        Else
            ' TipoRecargoEq.Enabled = False
            TipoRecargoEq.Text = 0
        End If
        ProntoPago.Text = FormatNumber(dtsOF.gProntoPago, 2)
        tbRetencion.Text = dtsOF.gNombreTipoRetencion & " " & dtsOF.gTipoRetencion & "%"
        'Descuento.Text = dtsOF.gDescuento
        'Descuento2.Text = dtsOF.gDescuento2
        cbCuenta.Text = dtsOF.gIBAN
        Observaciones.Text = dtsOF.gObservaciones
        Nota.Text = dtsOF.gNotas
        cbSolicitadoVia.Text = dtsOF.gSolicitadoVia
        cbEstado.Items.Clear()
        'Cargar el estado que tenga y los que falten
        Dim dtsES As DatosEstado = funcES.Mostrar1(dtsOF.gidEstado)
        If dtsES.gCabecera Then
            cbEstado.Items.Add(funcES.EstadoCabecera("OFERTA"))
            cbEstado.Items.Add(funcES.EstadoAnulado("OFERTA"))
        End If
        If dtsES.gEnCurso And dtsES.gEspera Then 'Activa
            cbEstado.Items.Add(funcES.EstadoOferta("ACTIVA"))
            cbEstado.Items.Add(funcES.EstadoAnulado("OFERTA"))
        End If
        If dtsES.gBloqueado And Not dtsES.gEspera And Not dtsES.gTraspasado Then  'Rechazada
            cbEstado.Items.Add(funcES.EstadoOferta("RECHAZADA"))
        End If
        If dtsES.gTraspasado Then
            cbEstado.Items.Add(funcES.EstadoOferta("ACEPTADA"))
        End If
        If dtsES.gAnulado Then
            cbEstado.Items.Add(funcES.EstadoOferta("ACTIVA"))
            cbEstado.Items.Add(funcES.EstadoAnulado("OFERTA"))
        End If

        cbEstado.Text = dtsES.ToString
        If dtsES.gBloqueado Then
            gbConceptos.Enabled = False
            bGuardar.Enabled = False
        Else
            gbConceptos.Enabled = True
            bGuardar.Enabled = Not vSoloLectura
        End If
        If dtsES.gCabecera Then
            cbCliente.Enabled = True
            cbCodCliente.Enabled = True
        Else
            cbCliente.Enabled = False
            cbCodCliente.Enabled = False
            bBuscarCliente.Enabled = False
        End If
        Call CargarConceptos()
        SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
        BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        cambios = False
    End Sub

    Private Sub CargarConceptos()
        listaC = funcCO.Mostrar(numDoc.Text)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoOferta In listaC
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
                    'Si solo hay una dirección, hay que cargar los datos propios de la dirección: idioma y portes
                    cbDireccion.SelectedIndex = 0
                    iidIdioma = funcUB.campoIdioma(dtsOF.gidUbicacion)
                    Dim Portes As Char = funcUB.campoPortes(cbDireccion.SelectedItem.itemdata)
                    PrecioTransporte.Enabled = False
                    If Portes = "P" Then cbPortes.Text = "PAGADOS"
                    If Portes = "D" Then cbPortes.Text = "DEBIDOS"
                    If Portes = "I" Then
                        cbPortes.Text = "INC.FRA."
                        'Cargar el importe del último documento
                        'PrecioTransporte.Text = FormatNumber(funcOF.UltimoPrecioTransporte(iidCliente), 2)
                        PrecioTransporte.Enabled = True
                    End If
                Else
                    cbDireccion.Text = ""
                End If
            Else
                iidIdioma = funcUB.campoIdioma(dtsOF.gidUbicacion)
            End If


        End If
    End Sub

    Private Sub CargarCuentas()
        If Not dtsFA.gCuentas Is Nothing Then
            cbCuenta.Items.Clear()
            If dtsFA.gCuentas.Count > 0 Then
                For Each dts As DatosCuentaBancaria In dtsFA.gCuentas
                    cbCuenta.Items.Add(New IDComboBox(dts.gIBAN, dts.gidCuentaBanco))
                Next
            End If
        End If

    End Sub

    Private Sub CargarDatosCliente()
        Dim semaforo0 As Boolean = semaforo
        semaforo = False
        Call LimpiarCabecera()
        semaforo = semaforo0
        Call CargarContactos()
        Call CargarDirecciones()

        'ObservacionesCli.Text = dtsCL.gobservaciones
        If Trim(dtsCL.gobservaciones).Length > 0 And Not AvisadoCliente Then
            MsgBox(dtsCL.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsCL.gnombrecomercial)
            AvisadoCliente = True
        End If
        dtsFA = funcFA.mostrarCli(iidCliente)
        If dtsFA.gcodMoneda = "" Then
            cbMoneda.Text = funcMO.CampoDivisa("EU")
            lbMoneda1.Text = funcMO.CampoSimbolo("EU")
        Else
            cbMoneda.Text = dtsFA.gDivisa
            codMonedaI = dtsFA.gcodMoneda
            lbMoneda1.Text = dtsFA.gSimbolo
        End If
        'cbMedioPago.SelectedIndex = -1
        cbMedioPago.Text = dtsFA.gMedioPago
        'cbTipoPago.SelectedIndex = -1
        cbTipoPago.Text = dtsFA.gTipoPago
        If dtsFA.gNombreTipoIVA = "" Then

        Else
            'cbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
            tbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
        End If
        'ckRecargoEquivalencia.Checked = dtsFA.gRecargoEquivalencia
        'If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
        '    TipoRecargoEq.Enabled = True
        '    TipoRecargoEq.Text = dtsFA.gTipoRecargoEq
        'Else
        '    TipoRecargoEq.Enabled = False
        '    TipoRecargoEq.Text = 0
        'End If
        If dtsFA.gRecargoEquivalencia Then
            TipoRecargoEq.Text = dtsFA.gTipoRecargoEq
        Else
            TipoRecargoEq.Text = 0
        End If



        'cbRetencion.Text = dtsFA.gNombreTipoRet & " " & dtsFA.gTipoRetencion & "%"
        tbRetencion.Text = dtsFA.gNombreTipoRet & " " & dtsFA.gTipoRetencion & "%"

        cbPersona.Text = dtsCL.gResponsableCuenta
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
                                                & If(cbSubTipo.SelectedIndex = -1, "", " AND idsubTipoArticulo = " & cbSubTipo.SelectedItem.itemdata), cbCliente.SelectedItem.itemdata, "", iidIdioma)

        End If
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next

    End Sub

#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoOferta)
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

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoOferta)
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
        SumaDescuentos.Text = FormatNumber(dtsOF.gImporteDescuentos + dtsOF.gImportePP, 2)
        BaseImponible.Text = FormatNumber(dtsOF.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsOF.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsOF.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsOF.gRetencion, 2)
        Total.Text = FormatNumber(dtsOF.gTotal, 2)
        PrecioTransporte.Text = FormatNumber(dtsOF.gPrecioTransporte, 2)
    End Sub


    Private Function GuardarGeneral()
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
        'If cbTipoIVA.SelectedIndex = -1 Then
        '    validar = False
        '    ep1.SetError(cbTipoIVA, "Se ha de seleccionar un tipo de IVA")
        'End If
        If cbEstado.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
        End If
        If cbPersona.SelectedIndex = -1 Then
            'validar = False
            ep2.SetError(cbPersona, "No se ha seleccionado un comercial")
        End If
        If validar Then
            dtsOF.gnumOferta = numDoc.Text
            dtsOF.gReferenciaCliente = OfertaCliente.Text
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
            'dtsOF.gidTipoRetencion = If(cbRetencion.SelectedIndex = -1, 0, cbRetencion.SelectedItem.itemdata)
            'dtsOF.gRecargoEquivalencia = ckRecargoEquivalencia.Checked
            dtsOF.gDescuento = 0 'If(Descuento.Text = "", 0, CDbl(Descuento.Text))
            dtsOF.gDescuento2 = 0 'If(Descuento2.Text = "", 0, CDbl(Descuento2.Text))
            dtsOF.gProntoPago = If(ProntoPago.Text = "", 0, CDbl(ProntoPago.Text))
            dtsOF.gSolicitadoVia = cbSolicitadoVia.Text
            dtsOF.gNotas = Nota.Text
            dtsOF.gObservaciones = Observaciones.Text
            dtsOF.gidEstado = cbEstado.SelectedItem.gidEstado
            dtsOF.gidPersona = If(cbPersona.SelectedIndex = -1, 0, cbPersona.SelectedItem.itemdata)
            dtsOF.gPersona = cbPersona.Text
            dtsOF.gTipoRetencion = funcTR.TipoRetencion(dtsOF.gidTipoRetencion)
            If PrecioTransporte.Text = "" Then PrecioTransporte.Text = 0
            'If cbPortes.Text = "PAGADOS" Then
            '    dtsOF.gPortes = "P"
            '    dtsOF.gPrecioTransporte = 0
            'Else
            '    dtsOF.gPortes = "D"
            '    dtsOF.gPrecioTransporte = PrecioTransporte.Text
            'End If
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
            If G_AGeneral = "G" Then
                dtsOF.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
                numDoc.Text = funcOF.insertar(dtsOF)
                dtsOF.gnumOferta = numDoc.Text
                G_AGeneral = "A"
                MsgBox("Creada la oferta " & numDoc.Text & ". Ya puede introducir los conceptos.")
                gbConceptos.Enabled = True
                cbEstado.Items.Add(funcES.EstadoAnulado("OFERTA"))
                'Debe seguir en estado cabecera
            Else
                If dtsOF.gidTipoIVA <> cbTipoIVA.SelectedItem.gidTipoIVA Then
                    'Si ha cambiado el tipo IVA hay que propagar el cambio a los conceptos
                    dtsOF.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
                    funcCO.CambiarTipoIVA(numDoc.Text, dtsOF.gidTipoIVA)
                End If
                funcOF.actualizar(dtsOF)
                Call Recalcular()
                If cbArticulo.Text = "" Then MsgBox("Oferta actualizada correctamente")
            End If
            cambios = False
            ep1.Clear()
            ep2.Clear()
        End If
        Return validar
    End Function

    Private Function GuardarConcepto() As Boolean
        Dim validar As Boolean = False

        'If cbArticulo.SelectedIndex <> -1 Then
        If cbArticulo.Text <> "" Then
            validar = True
            Dim dts As New DatosConceptoOferta
            dts.gidConcepto = 0
            dts.gnumPedido = 0
            dts.gnumProforma = 0
            If indice <> -1 Then
                'si existe, precargamos el concepto
                Dim iidconcepto As Long = lvConceptos.Items(indice).SubItems(1).Text
                If iidconcepto > 0 Then
                    dts = funcCO.Mostrar1(iidconcepto)
                End If
            End If
            dts.gnumOferta = numDoc.Text
         
            If indice = -1 And codArticuloCli.Text = "" And cbCodArticulo.Text <> "" Then
                dts.gcodArticuloCli = cbCodArticulo.Text 'Asignar el codArticuloCli como el codArticulo
            Else
                dts.gcodArticuloCli = codArticuloCli.Text
            End If
            dts.gcodArticulo = cbCodArticulo.Text
            dts.gArticuloCli = cbArticulo.Text
            dts.gRefCliente = ""

            dts.gCantidad = If(Cantidad.Text = "", 0, CDbl(Cantidad.Text))
            dts.gPVPUnitario = If(PVP.Text = "", 0, CDbl(PVP.Text))
            dts.gidTipoIVA = dtsOF.gidTipoIVA
            dts.gDescuento = If(DescuentoC.Text = "", 0, CDbl(DescuentoC.Text))
            dts.gPrecioNetoUnitario = PrecioNeto.Text
            dts.gOrden = indice + 1
            Dim iidArtCli As Integer = 0

            Dim dtsAC As New DatosArticuloCliente
            Dim dtsACP As DatosArticuloClientePrecio
            If cbArticulo.SelectedIndex = -1 Then
                dts.gidArticulo = 0
                iidArticulo = 0
            Else
                iidArticulo = cbArticulo.SelectedItem.itemdata
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
                dtsAC.gtipoDoc = "OFERTA"
                dtsAC.gPrecioNetoUnitario = If(dts.gDescuento > 0, 0, dts.gPrecioNetoUnitario) 'Si hay descuento, el precioneto=0
            End If
            Dim SoloReferenciaDoc As Boolean = False
            If indice = -1 Then
                'Hemos de guardar un nuevo concepto
                dts.gTipoUnidad = If(iidArticulo = 0, lbUnidad.Text, dtsAR.gTipoUnidad)
                Dim estado As DatosEstado = funcES.EstadoEspera("C.OFERTA")
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
                Call nuevaLineaLV(dts)
                If lvConceptos.Items.Count > 0 Then 'Si hay items, modificar el estado de la oferta
                    Me.Text = "EDITAR OFERTA"
                    'cbEstado.Items.Clear()
                    'cbEstado.Items.Add(funcES.EstadoAnulado("OFERTA"))
                    cbEstado.SelectedIndex = -1
                    cbEstado.Text = ""
                    Dim x As Integer = cbEstado.FindString(funcES.EstadoCabecera("OFERTA").gEstado)
                    If x <> -1 Then cbEstado.Items.RemoveAt(x) 'Eliminar el estado cabecera
                    Dim dtsES As DatosEstado = funcES.EstadoOferta("ACTIVA")
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
            If dtsAR.gidArticulo <> iidArticulo Then dtsAR = funcAR.Mostrar1(iidArticulo)

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
            'numPedidoC.Text = dtsCO.gnumPedido
            'numProformaC.Text = dtsCO.gnumProforma
            semaforo = True
        End If
    End Sub


    Private Sub CargarArticuloC()
        'Carga los datos de un artículo en la zona de edición
        If iidArticulo > 0 And cbCliente.SelectedIndex <> -1 Then
            semaforo = False
            dtsAR = funcAR.Mostrar1V(iidArticulo, cbCliente.SelectedItem.itemdata, iidIdioma)
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




#End Region




#Region "BOTONES GENERALES"



    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL - 1
                    numDoc.Text = Ofertas(indiceL)
                    Call CargarOferta()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                numDoc.Text = Ofertas(indiceL)
                Call CargarOferta()
            End If


        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Ofertas.Count - 1 Then
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    numDoc.Text = Ofertas(indiceL)
                    Call CargarOferta()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                numDoc.Text = Ofertas(indiceL)
                Call CargarOferta()
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
            Dim cliente As String = cbCliente.Text
            Dim codcli As Integer = cbCodCliente.Text
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = cbCliente.SelectedItem.itemdata
            GG.ShowDialog()
            Call introducirClientes()
            cbCliente.Text = cliente
            cbCodCliente.Text = codcli
            If cbCliente.SelectedIndex = -1 Then
                cbCliente.Text = ""
                cbCodCliente.Text = ""
            Else
                iidCliente = cbCodCliente.SelectedItem.itemdata
                Call CargarDatosCliente()
            End If
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
            Call CargarDatosCliente()
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
            'Borrar oferta
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la oferta, es como pulsar nuevo
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
                If MsgBox("No es posible borrar una oferta existente. ¿Desea anularla?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim dtsES As DatosEstado = funcES.EstadoAnulado("OFERTA")
                    cbEstado.Text = dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                    bGuardar.Enabled = False
                End If
            End If
        Else
            'Borrar concepto
            Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
            If iidConcepto > 0 Then
                funcCO.borrar(iidConcepto)
                lvConceptos.Items.RemoveAt(indice)
                Call LimpiarEdicion()
                If lvConceptos.Items.Count = 0 Then
                    cbEstado.Items.Clear()
                    cbEstado.Items.Add(funcES.EstadoAnulado("OFERTA"))
                    Dim dtsES As DatosEstado = funcES.EstadoCabecera("OFERTA")
                    cbEstado.Items.Add(dtsES)
                    cbEstado.Text = dtsES.ToString
                    funcOF.actualizaEstado(numDoc.Text, dtsES.gidEstado)
                End If
                Call Recalcular()
            End If

        End If

    End Sub



    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If cbArticulo.Text <> "" Then
            Call LimpiarEdicion()
        Else
            If cambios Then
                If MsgBox("Se perderán los los datos introducidos y se creará una nueva oferta. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call Nuevo()
                End If
            Else
                If MsgBox("Se creará una nueva oferta. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    Call Nuevo()
                End If
            End If
        End If


    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If GuardarGeneral() Then
            Call GuardarConcepto()
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
                Dim SC As New SeleccionConvertir
                SC.ShowDialog()
                If SC.pPedido Then
                    Dim GG As New FlujoSiguiente
                    GG.SoloLectura = vSoloLectura
                    GG.pDesde = "OFERTA"
                    GG.pHasta = "PEDIDO"
                    GG.pnumDesde = numDoc.Text
                    GG.pConceptos = Conceptos
                    GG.pLocalizacion = Me.Location
                    GG.ShowDialog()
                End If
                If SC.pProforma Then
                    Dim GG As New FlujoSiguiente
                    GG.SoloLectura = vSoloLectura
                    GG.pDesde = "OFERTA"
                    GG.pHasta = "PROFORMA"
                    GG.pnumDesde = numDoc.Text
                    GG.pConceptos = Conceptos
                    GG.pLocalizacion = Me.Location
                    GG.ShowDialog()
                End If
                Call CargarOferta()

            End If
        Else
            If MsgBox("Seleccione los conceptos que se han de convertir en Pedido o Proforma ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
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
            MsgBox("Aún no se ha guardado la oferta")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            InformeOferta.verInforme(numDoc.Text, iidIdioma)
            InformeOferta.ShowDialog()
        End If
    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la oferta")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Oferta SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeOferta.GeneraPDF(numDoc.Text, iidIdioma, sfd.FileName, "")
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If
    End Sub


    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles beMail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la oferta")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else
            Dim fichero As String = "Oferta SV " & Trim(numDoc.Text) & " " & Microsoft.VisualBasic.Left(cbCliente.Text, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()

            InformeOferta.GeneraPDF(numDoc.Text, iidIdioma, fichero, camino)
            Dim Destinatario As String = funcUB.campoCorreo(dtsOF.gidUbicacion)
            If cbContacto.SelectedIndex <> -1 Then
                Dim funcMOA As New FuncionesMails
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    Destinatario = If(Destinatario = "", dts.gmail, Destinatario & "; " & dts.gmail)
                Next
            End If
            Dim texto As String = " Buenos días,"
            texto = texto & "<br/><br/> Adjuntamos la oferta " & numDoc.Text & ". "
            'Se envía un correo outlook a la dirección de la ubicación
            CorreoOutlook("Nueva Oferta SUGAR VALLEY", texto, funcPE.campoCorreo(iidUsuario), Destinatario, camino & fichero)
        End If
    End Sub



    Private Sub bNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoCliente.Click
        Dim cliente As String = cbCliente.Text
        Dim GG As New GestionClientes
        GG.pidCliente = 0
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirClientes()
        If GG.pidCliente > 0 Then
            If GG.pidCliente > 0 Then
                dtsCL = funcCL.mostrar1(GG.pidCliente)
                cbCodCliente.Text = dtsCL.gcodCli
                cbCliente.Text = dtsCL.gnombrecomercial
                Call CargarDatosCliente()
                cambios = True
            End If
        Else
            cbCliente.Text = cliente
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
            Call CargarDatosCliente()
            cambios = True
        End If
    End Sub


    Private Sub cbCliente_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCliente.SelectionChangeCommitted
        If cbCliente.SelectedIndex <> -1 Then
            iidCliente = cbCliente.SelectedItem.itemdata
            dtsCL = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dtsCL.gcodCli
            AvisadoCliente = False
            Call CargarDatosCliente()
            cambios = True
        End If
    End Sub

    Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
        If cbMedioPago.SelectedIndex <> -1 Then
            cbCuenta.Enabled = cbMedioPago.SelectedItem.gBanco
        End If
        cambios = True
    End Sub

    Private Sub cbTipoPago_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoPago.SelectedIndexChanged
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
            lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            'Cambiar moneda en todo el documento
            Dim moneda As String = cbMoneda.Text
            If codMonedaI <> cbMoneda.SelectedItem.gcodMoneda Then
                Dim FechaCambio As Date = funcMO.CampoFecha(cbMoneda.SelectedItem.gcodMoneda)
                If FechaCambio <> dtpFecha.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)
                    'lbCambio.Text = "CAMBIO " & FechaCambio
                    'lbCambio.Visible = True
                End If
                Dim codMonedaActual = cbMoneda.SelectedItem.gcodMoneda
                If G_AGeneral = "A" Then
                    'Si es un doc que ya existente
                    If MsgBox("El cambio de moneda quedará guardado en la base de datos. ¿Proceder con el cambio?", MsgBoxStyle.OkCancel) Then
                        funcOF.actualizaMoneda(numDoc.Text, codMonedaActual)
                        dtsOF.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
                        dtsOF.gDivisa = cbMoneda.SelectedItem.gdivisa
                        dtsOF.gSimbolo = cbMoneda.SelectedItem.gsimbolo
                        listaC = funcCO.Mostrar(numDoc.Text)
                        For Each dts As DatosConceptoOferta In listaC
                            funcCO.CambiarPrecio(dts.gidConcepto, funcMO.Cambio(dts.gPVPUnitario, codMonedaI, codMonedaActual, True, Now.Date), funcMO.Cambio(dts.gPrecioNetoUnitario, codMonedaI, codMonedaActual, True, Now.Date))
                        Next
                        codMonedaI = codMonedaActual
                        Call CargarConceptos()
                        Call Recalcular()
                    End If
                Else
                    cbMoneda.Text = moneda
                End If
            End If
            cambios = True
        End If
    End Sub


    'Private Sub ckRecargoEquivalencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckRecargoEquivalencia.Click
    '    If ckRecargoEquivalencia.Checked And cbTipoIVA.SelectedIndex <> -1 Then
    '        TipoRecargoEq.Enabled = True
    '        TipoRecargoEq.Text = cbTipoIVA.SelectedItem.gTipoRecargoEq
    '    Else
    '        TipoRecargoEq.Enabled = False
    '        TipoRecargoEq.Text = 0
    '    End If
    '    cambios = True
    'End Sub


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







    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DescuentoC.Click, ProntoPago.Click, PrecioNeto.Click, PrecioTransporte.Click
        sender.selectall()
    End Sub


    Private Sub Cantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cantidad.TextChanged, DescuentoC.TextChanged, PrecioNeto.TextChanged, PVP.TextChanged
        If semaforo Then
            semaforo = False
            If Cantidad.Text = "" Then Cantidad.Text = 0
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
    End Sub


    'Private Sub Descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = Asc(".") Then
    '        e.KeyChar = ","
    '    End If
    '    If InStr(Descuento.Text, ",") Then
    '        KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    Else
    '        KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
    '    End If
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub


    'Private Sub Descuento2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = Asc(".") Then
    '        e.KeyChar = ","
    '    End If
    '    If InStr(Descuento2.Text, ",") Then
    '        KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    Else
    '        KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
    '    End If
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub


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

    End Sub


    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Cantidad.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            Call GuardarConcepto()
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
        If KeyAscii = Keys.Enter Then
            Call GuardarConcepto()
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
            Call GuardarConcepto()
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

    

    Private Sub ProntoPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nota.TextChanged, Observaciones.TextChanged, ProntoPago.TextChanged, dtpFecha.ValueChanged, dtpFechaPrevista.ValueChanged, OfertaCliente.TextChanged, cbCuenta.SelectedIndexChanged, cbContacto.SelectedIndexChanged, cbSolicitadoVia.SelectedIndexChanged, PrecioTransporte.TextChanged
        cambios = True
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

    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            iidIdioma = funcUB.campoIdioma(cbDireccion.SelectedItem.itemdata)
            Dim Portes As Char = funcUB.campoPortes(cbDireccion.SelectedItem.itemdata)
            PrecioTransporte.Enabled = False
            If Portes = "P" Then cbPortes.Text = "PAGADOS"
            If Portes = "D" Then cbPortes.Text = "DEBIDOS"
            If Portes = "I" Then
                cbPortes.Text = "INC.FRA."
                'Cargar el importe del último documento
                'PrecioTransporte.Text = FormatNumber(funcOF.UltimoPrecioTransporte(iidCliente), 2)
                PrecioTransporte.Enabled = True
            End If
        End If

    End Sub

    Private Sub numDoc1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDoc1.DoubleClick
        If numDoc1.Text <> "" And numDoc1.Text <> "VARIOS" Then
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = numDoc1.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If

    End Sub

    Private Sub numDoc2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDoc2.DoubleClick
        If numDoc2.Text <> "" And numDoc2.Text <> "VARIOS" Then
            Dim GG As New GestionProforma
            GG.SoloLectura = vSoloLectura
            GG.pnumProforma = numDoc2.Text
            Dim punto As Point = Me.Location
            punto = New Point(punto.X + 15, punto.Y + 15)
            GG.pLocation = punto
            GG.ShowDialog()
        End If

    End Sub

#End Region



   
    
End Class