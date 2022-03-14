
Imports System.IO

Public Class GestionFacturaProv


    Private funcFP As New FuncionesFacturasProv
    Private funcPR As New funcionesProveedores
    Private funcMO As New FuncionesMoneda
    Private funcTP As New funcionesTiposPago
    Private funcMP As New funcionesMediosPago
    Private funcTR As New FuncionesTiposRetencion
    Private funcTI As New FuncionesTiposIVA
    Private funcFA As New funcionesFacturacion
    Private funcCT As New funcionesContactos
    Private funcES As New FuncionesEstados
    Private funcMA As New Master
    Private funcPE As New FuncionesPersonal
    Private funcVE As New FuncionesVencimientosProv
    Private funcAP As New FuncionesAlbaranesProv
    Private funcCO As New FuncionesConceptosFacturasProv
    Private funcII As New FuncionesImportesIVAProv
    Private funcARP As New FuncionesArticulosProv
    Private funcAE As New FuncionesArticuloPrecio
    Private funcAR As New FuncionesArticulos
    Private funcFAM As New FuncionesFamilias
    Private funcSF As New FuncionessubFamilias
    Private funcUB As New funcionesUbicaciones
    Private funcPA As New funcionesPaises
    Private funcSV As New FuncionesSolicitadoVia
    Private funcMOA As New FuncionesMails
    Private funcCB As New FuncionesCuentasBancarias
    Private DI As New DatosIniciales
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private vSoloLectura As Boolean
    Private dtsFP As DatosFacturaProv
    Private dtsFA As datosfacturacion
    Private dtsPR As datosProveedor
    Private dtsUB As datosUbicacion
    Private iidFactura As Integer
    Private Facturas As List(Of Integer)
    Private indiceL As Integer
    Private EstadoInicial As DatosEstado
    Private ProveedorSoloLectura As Boolean
    Private cambios As Boolean
    Private AvisadoProveedor As Boolean
    Private ProveedorAvisado As Integer
    Private AvisadoFacturacion As Boolean

    Private EstadoPendiente As DatosEstado
    Private EstadoParcial As DatosEstado
    Private EstadoPagada As DatosEstado
    Private EstadoAnulada As DatosEstado
    Private EstadoDevuelta As DatosEstado
    Private EstadoCabecera As DatosEstado
    Private EstadoCEspera As DatosEstado
    Private listaC As List(Of DatosConceptoFacturaProv)
    Private indice As Integer
    Private ConceptosEditables As Boolean
    Private iidProveedor As Integer
    Private iidArticulo As Integer
    Private semaforo As Boolean
    Private iidFamilia As Integer
    Private iidSubFamilia As Integer
    Private G_AGeneral As Char
    Dim retardo As New Timer
    Private BuscarAhora As Boolean
    Private idConceptoAlbaran As Long
    Private numAlbaran As String


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Property pidFactura() As Integer
        Get
            Return iidFactura
        End Get
        Set(ByVal value As Integer)
            iidFactura = value
        End Set
    End Property

    Property pFacturas() As List(Of Integer)
        Get
            Return Facturas
        End Get
        Set(ByVal value As List(Of Integer))
            Facturas = value
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



    Private Sub GestionFacturaProv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        If Facturas Is Nothing OrElse Facturas.Count = 0 Then
            bSubir.Visible = False
            bBajar.Visible = False
        Else
            bSubir.Visible = True
            bBajar.Visible = True
        End If
        Call CargarVariablesEstado()
        Dim tt As New ToolTip
        tt.InitialDelay = 0
        tt.SetToolTip(bVerProveedor, "Ver ficha del proveedor")
        tt.SetToolTip(bVencimientos, "Editar vencimientos")
        tt.SetToolTip(bBuscarProveedor, "Búsqueda del proveedor")
        tt.SetToolTip(bVerIVAs, "Visualizar desglose de bases e importes de IVA y R.E.")
        tt.SetToolTip(bVencimientos, "Edición de vencimientos")
        semaforo = False
        Call introducirMediosPago()
        Call introducirMonedas()
        Call introducirTiposIVA()
        Call introducirTiposPago()
        Call introducirTiposRetencion()
        Call introducirSolicitadoVia()
        Call CargarResponsables()
        Call InicializarGeneral()

        If iidFactura = 0 Then
            Call Nuevo()
        Else
            G_AGeneral = "A"
            Call CargarFacturaExistente()
        End If
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 1000 'en milisegundos
        retardo.Enabled = False
        semaforo = True
    End Sub



#Region "INICIALIZACIÓN"

    Private Sub InicializarGeneral()
        ep1.Clear()
        ep2.Clear()

        BaseImponible.Text = 0
        TotalIVA.Text = 0
        TotalRE.Text = 0
        Retencion.Text = 0
        Total.Text = 0
        lvConceptos.Items.Clear()
        lvVencimientos.Items.Clear()
        Call LimpiarCabecera()
        AvisadoProveedor = False
        AvisadoFacturacion = False
        'ProveedorAvisado = 0
        Call inicializaConcepto()
    End Sub


    Private Sub CargarVariablesEstado()
        EstadoPendiente = funcES.EstadoFacturaProv("PENDIENTE")
        EstadoParcial = funcES.EstadoFacturaProv("PARCIAL")
        EstadoPagada = funcES.EstadoFacturaProv("PAGADA")
        EstadoAnulada = funcES.EstadoFacturaProv("ANULADA")
        EstadoDevuelta = funcES.EstadoFacturaProv("DEVUELTA")
        EstadoCabecera = funcES.EstadoFacturaProv("CABECERA")
        EstadoCEspera = funcES.EstadoEspera("C.FACTURAPROV")
    End Sub



    Private Sub LimpiarCabecera()
        numFactura.Text = ""
        codFactura.Text = ""
        Referencia.Text = ""
        numDoc1.Text = ""
        cbSolicitadoPor.Text = funcPE.campoNombreyApellidos(Inicio.vIdUsuario)
        cbProveedor.Text = ""
        dtpFecha.Value = Now.Date
        cbCodProveedor.Text = ""
        cbCodProveedor.SelectedIndex = -1
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        cbDireccion.Text = ""
        cbDireccion.SelectedIndex = -1
        cbsolicitadoVia.Text = ""
        cbContacto.Text = ""
        cbContacto.SelectedIndex = -1
        cbContacto.Items.Clear()
        cbMedioPago.Text = ""
        cbMedioPago.SelectedIndex = -1
        cbTipoPago.Text = ""
        cbTipoPago.SelectedIndex = -1
        cbCuenta.Text = ""
        cbCuenta.SelectedIndex = -1
        cbCuenta.Items.Clear()
        cbMoneda.Text = funcMO.CampoDivisa("EU")
        cbRetencion.SelectedItem = DI.TipoRetencion
        PrecioTransporte.Text = 0
        ckRecargoEquivalencia.Checked = False
        Descuento.Text = ""
        Observaciones.Text = ""
        Nota.Text = ""
    End Sub


    Private Sub Nuevo()
        G_AGeneral = "G"
        Me.Text = "NUEVA FACTURA DE PROVEEDOR"
        cbEstado.Items.Clear()
        cbEstado.Items.Add(funcES.EstadoFacturaProv("CABECERA"))
        cbEstado.SelectedIndex = 0
        EstadoInicial = funcES.Clonar(EstadoCabecera)
        Call introducirProveedores()
        ProveedorSoloLectura = False
        bBuscarProveedor.Enabled = True
        dtsFP = New DatosFacturaProv

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

    Private Sub introducirSolicitadoVia()
        cbsolicitadoVia.Items.Clear()
        Dim lista As List(Of DatosSolicitadoVia) = funcSV.Mostrar
        For Each dts As DatosSolicitadoVia In lista
            cbsolicitadoVia.Items.Add(dts)
        Next
    End Sub

    Private Sub introducirProveedores()
        cbProveedor.Items.Clear()
        cbCodProveedor.Items.Clear()
        Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
        For Each dts As datosProveedor In lista
            cbCodProveedor.Items.Add(New IDComboBox(dts.gcodProveedor, dts.gidProveedor))
            cbProveedor.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidProveedor))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("FACTURAPROV")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub

    Private Sub CargarContactos()

        Dim Contacto As String = cbContacto.Text
        cbContacto.Text = ""
        cbContacto.Items.Clear()
        Dim lista As List(Of datosContacto) = funcCT.mostrarProv(dtsPR.gidProveedor)
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


    End Sub

    Private Sub CargarDirecciones()

        Dim direccion As String = cbDireccion.Text
        cbDireccion.Items.Clear()
        Dim lista As List(Of datosUbicacion) = funcUB.mostrarProv(dtsPR.gidProveedor, True, True, False, True, False, False, False)
        For Each dts As datosUbicacion In lista
            cbDireccion.Items.Add(New IDComboBox(If(dts.gSubCliente = "", "", dts.gSubCliente & ": ") & dts.glocalidad & ", " & dts.gdireccion, dts.gidUbicacion))
        Next
        If direccion.Length > 0 Then
            cbDireccion.Text = direccion
        End If
        If cbDireccion.SelectedIndex = -1 Then
            If lista.Count = 1 Then
                dtsUB = lista(0)
                cbDireccion.SelectedIndex = 0

                'Cargar el importe del último documento
                'PrecioTransporte.Text = FormatNumber(funcOF.UltimoPrecioTransporte(iidCliente), 2)

                'iidIdioma = funcUB.campoIdioma(dtsOF.gidUbicacion)
                'Exportacion = dtsUB.gExportacion Or dtsUB.gidPais = 1 And dtsOF.gTipoIVA = 0 'Extracomunitario o IVA =0 en España
            Else
                cbDireccion.Text = ""
            End If
        Else

            'iidIdioma = funcUB.campoIdioma(dtsOF.gidUbicacion)
            'Exportacion = funcUB.campoExportacion(dtsOF.gidUbicacion)

        End If



    End Sub

    'Private Sub CargarCuentas()
    '    If Not dtsFA.gCuentas Is Nothing Then
    '        Dim cuentaActual As String = cbCuenta.Text
    '        cbCuenta.Items.Clear()
    '        If dtsFA.gCuentas.Count > 0 Then
    '            For Each dts As DatosCuentaBancaria In dtsFA.gCuentas
    '                cbCuenta.Items.Add(New IDComboBox(dts.gIBAN, dts.gidCuentaBanco))
    '            Next
    '        End If
    '        If cuentaActual.Length > 0 Then
    '            'Si habiamos guardado la cuenta, la volvemos a poner
    '            cbCuenta.Text = cuentaActual
    '            'Si no coincide con ninguna, la añadimos (por si ya no está pero la factura es antigua)
    '            If cbCuenta.SelectedIndex = -1 Then
    '                cbCuenta.Items.Add(cuentaActual)
    '                cbCuenta.Text = cuentaActual
    '            End If
    '        End If
    '    End If

    'End Sub


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





    Private Sub CargarCombosProveedor()
        Call CargarContactos()
        Call CargarCuentas()
        Call CargarDirecciones()
    End Sub

    Private Sub introducirFamilias()
        Try
            cbFamilia.Items.Clear()
            iidFamilia = 0
            Dim lista As List(Of DatosFamilia) = funcFAM.Mostrar(0, True)
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
            iidSubFamilia = 0
            If iidFamilia > 0 Then
                Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, True)
                Dim dts As DatosSubFamilia
                For Each dts In lista
                    cbSubFamilia.Items.Add(New IDComboBox(dts.gSubFamilia, dts.gidSubFamilia))
                Next
                iidSubFamilia = 0
            End If
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub inicializaConcepto()
        Dim semaforo0 As Boolean = semaforo
        semaforo = False
        Call LimpiarEdicion()

        BuscarAhora = True
        retardo.Enabled = True
        For Each item As ListViewItem In lvConceptos.Items
            item.Checked = False
        Next
        lvConceptos.SelectedIndices.Clear() 'para que no veamos conceptos seleccionados
        semaforo = semaforo0
    End Sub

    Private Sub LimpiarEdicion()
        cbcodArticulo.Text = ""
        cbcodArticuloProv.Text = ""
        Cantidad.Text = 0
        cbArticulo.Text = ""
        Precio.Text = 0
        subTotal.Text = 0
        'iidconcepto = 0
        indice = -1
        'vCantidad = 0
        'vPrecio = 0
        iidArticulo = 0

        lbUnidad.Text = "U."
        iidFamilia = 0
        iidSubFamilia = 0
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
            If dtsFA Is Nothing Then dtsFA = funcFA.mostrarProv(dtsPR.gidProveedor)
            cbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
        End If
        ObservacionesC.Text = ""
        idConceptoAlbaran = 0
        numAlbaran = ""
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



    Private Sub CargarFacturaExistente()
        ep1.Clear()
        ep2.Clear()

        'Call InicializarGeneral()
        Call CargarDTSs()
        EstadoInicial = funcES.Mostrar1(dtsFP.gidEstado)
        If EstadoInicial.gBloqueado Then
            cbProveedor.Items.Clear()
            cbCodProveedor.Items.Clear()
            cbCodProveedor.Items.Add(New IDComboBox(dtsPR.gcodProveedor, dtsPR.gidProveedor))
            cbProveedor.Items.Add(New IDComboBox(dtsPR.gnombrefiscal, dtsPR.gidProveedor))
            ProveedorSoloLectura = True
            bBuscarProveedor.Enabled = False
        Else
            Call introducirProveedores()
            ProveedorSoloLectura = False
            bBuscarProveedor.Enabled = True
        End If
        Call CargarCombosProveedor()
        Call CargarDatosFactura()
        Call CargarlvVencimientos()
        Call CargarConceptos()
        ckSeleccion.Checked = False
        Call PresentarTotales()
        cambios = False
    End Sub

    Private Sub CargarDTSs()
        dtsFP = funcFP.Mostrar1(iidFactura)
        dtsPR = funcPR.mostrar1(dtsFP.gidProveedor)
        dtsFA = funcFA.mostrarProv(dtsFP.gidProveedor)
    End Sub

    Private Sub CargarDatosFactura()
        Try


            semaforo = False
            cbCodProveedor.Text = dtsPR.gcodProveedor
            cbProveedor.Text = dtsFP.gProveedor
            cbDireccion.Text = dtsFP.gDireccion
            dtsUB = funcUB.mostrar1(dtsFP.gidUbicacion)
            numFactura.Text = dtsFP.gnumFactura
            codFactura.Text = dtsFP.gcodFactura
            cbEstado.Text = dtsFP.gEstado
            dtpFecha.Value = dtsFP.gFecha
            Referencia.Text = dtsFP.gReferencia
            cbTipoPago.Text = dtsFP.gTipoPago
            cbMedioPago.Text = dtsFP.gMedioPago
            cbRetencion.Text = dtsFA.gNombreTipoRet & " " & dtsFA.gTipoRetencion & "%"
            If cbRetencion.SelectedIndex = -1 Then
                'Si es un valor de tipo retención diferente al actual, lo añadimos.
                Dim dtsR As New DatosTipoRetencion
                dtsR.gidTipoRetencion = dtsFP.gidTipoRetencion
                dtsR.gNombre = dtsFP.gNombreTipoRetencion
                dtsR.gTipoRetencion = dtsFP.gTipoRetencionFac
                cbRetencion.Items.Add(dtsR)
                cbRetencion.Text = dtsR.gNombre & " " & dtsR.gTipoRetencion & "%"
            End If
            Descuento.Text = FormatNumber(dtsFP.gProntoPago, 2)
            PrecioTransporte.Text = FormatNumber(dtsFP.gPrecioTransporte, 2)
            cbMoneda.Text = dtsFP.gDivisa
            Observaciones.Text = dtsFP.gObservaciones
            ckRecargoEquivalencia.Checked = dtsFP.gRecargoEquivalencia

            If dtsFP.gidCuentaBanco > 0 Then
                Dim funcCB As New FuncionesCuentasBancarias
                cbCuenta.Text = funcCB.NombreCompleto(dtsFP.gidCuentaBanco)
            Else
                cbCuenta.Text = ""
            End If
            cbContacto.Text = dtsFP.gContacto
            cbsolicitadoVia.Text = dtsFP.gSolicitadoVia
            iidProveedor = dtsFP.gidProveedor
            Select Case dtsFP.gAlbaranes.Count
                Case 0
                    numDoc1.Text = ""
                Case 1
                    numDoc1.Text = dtsFP.gAlbaranes(0).ToString
                Case Else
                    numDoc1.Text = "VARIOS"
            End Select
            dtsPR = funcPR.mostrar1(dtsFP.gidProveedor)
            Call PresentarAvisoProveedor()
            Call CargarEstados()
            cambios = False
            semaforo = True
        Catch ex As Exception
            ex.Data.Add("numFactura.Text", numFactura.Text)
            CorreoError(ex)
        End Try
    End Sub

    Private Sub CargarEstados()
        cbEstado.Items.Clear()
        Select Case dtsFP.gidEstado
            Case EstadoAnulada.gidEstado
                cbEstado.Items.Add(EstadoAnulada)
            Case EstadoDevuelta.gidEstado
                cbEstado.Items.Add(EstadoDevuelta)
            Case EstadoPagada.gidEstado
                cbEstado.Items.Add(EstadoPagada)
            Case EstadoParcial.gidEstado
                cbEstado.Items.Add(EstadoParcial)
            Case EstadoPendiente.gidEstado
                cbEstado.Items.Add(EstadoPendiente)
        End Select
        cbEstado.Text = dtsFP.gEstado

    End Sub


    Private Sub PresentarAvisoProveedor()
        If Trim(dtsPR.gobservaciones).Length > 0 And Not AvisadoProveedor And dtsPR.gidProveedor <> ProveedorAvisado Then
            MsgBox(dtsPR.gobservaciones, MsgBoxStyle.OkOnly, "AVISO " & dtsPR.gnombrefiscal)
            Call PresentarAvisoFacturacion()
            ProveedorAvisado = dtsPR.gidProveedor
            AvisadoProveedor = True
        End If
    End Sub

    Private Sub PresentarAvisoFacturacion()
        If Not dtsFA Is Nothing AndAlso (Trim(dtsFA.gObservaciones).Length > 0 And Not AvisadoFacturacion And dtsFA.gidProveedor <> ProveedorAvisado) Then
            MsgBox(dtsFA.gObservaciones, MsgBoxStyle.OkOnly, "AVISO FACTURACIÓN " & dtsPR.gnombrefiscal)
            AvisadoFacturacion = True
        End If
    End Sub




    Private Sub CargarDatosProv()

        If cbProveedor.SelectedIndex <> -1 Then
            ep1.Clear()
            ep2.Clear()
            iidProveedor = cbProveedor.SelectedItem.itemdata
            dtsPR = funcPR.mostrar1(iidProveedor)
            'dtsFA = funcFA.mostrarProv(iidProveedor)
            Call CargarDatosFacturacionProveedor()
            Call PresentarAvisoProveedor()
            'iidTipoCompra = dtsPR.gIdTipoCompra

            Call CargarDirecciones()
            If cbDireccion.Items.Count = 0 Then
                MsgBox("Este Proveedor no tiene una dirección de recogida introducida. Por favor, añada una dirección desde la Ficha del proveedor.")
            Else

                Dim vMoneda As String = funcPR.campoMoneda(iidProveedor)
                lbMoneda1.Text = funcMO.CampoSimbolo(vMoneda)

                'Transporte.Text = funcFF.campoTransporte(iidProveedor)
                cbTipoIVA.Text = dtsFA.gNombreTipoIVA & " " & dtsFA.gTipoIVA & "%"
                Descuento.Text = FormatNumber(dtsFA.gDescuento, 2)
                Dim titulo As String = funcPR.TipoCompra(iidProveedor)
                If G_AGeneral = "G" Then
                    Me.Text = "NUEVA FACTURA DE PROVEEDOR " & UCase(titulo)
                Else
                    Me.Text = "EDITAR FACTURA DE PROVEEDOR " & UCase(titulo)
                End If
            End If
            If cbDireccion.SelectedIndex <> -1 Then
                Call CargarContactos()
            End If
        End If
    End Sub

    Private Sub CargarDatosFacturacionProveedor()
        dtsFA = funcFA.mostrarProv(dtsPR.gidProveedor)
        Call PresentarAvisoFacturacion()
        cbTipoPago.Text = dtsFA.gTipoPago
        cbMedioPago.Text = dtsFA.gMedioPago
        cbRetencion.Text = dtsFA.gNombreTipoRet & " " & dtsFA.gTipoRetencion & "%"
        Descuento.Text = FormatNumber(dtsFA.gProntoPago, 2)
        PrecioTransporte.Text = FormatNumber(dtsFA.gTransporte, 2)
        cbMoneda.Text = dtsFA.gDivisa
        cbCuenta.Text = ""
        ckRecargoEquivalencia.Checked = dtsFA.gRecargoEquivalencia
    End Sub

    Private Sub CargarlvVencimientos()
        lvVencimientos.Items.Clear()
        Dim Pagados As Integer = 0
        Dim Devueltos As Integer = 0

        If Not dtsFP.gVencimientos Is Nothing Then
            For Each dts As DatosVencimientoProv In dtsFP.gVencimientos
                With lvVencimientos.Items.Add(dts.gVencimiento)
                    .SubItems.Add(FormatNumber(dts.gImporte, 2) & dts.gSimbolo)

                    If dts.gDevuelto Then
                        .ForeColor = Color.Red
                        Devueltos = Devueltos + 1
                        .SubItems.Add("DEVUELTO")
                    ElseIf dts.gPagado Then
                        .ForeColor = Color.Green
                        Pagados = Pagados + 1
                        .SubItems.Add("PAGADO")
                    Else
                        .ForeColor = Color.Black
                        .SubItems.Add("PENDIENTE")
                    End If
                End With
            Next
        End If


        If Devueltos > 0 Then
            dtsFP.gidEstado = EstadoDevuelta.gidEstado
        Else
            If Pagados = 0 Then
                If cbEstado.SelectedIndex = -1 Then
                    dtsFP.gidEstado = EstadoPendiente.gidEstado
                Else
                    If cbEstado.SelectedItem.gAnulado Then
                    Else
                        dtsFP.gidEstado = EstadoPendiente.gidEstado
                    End If
                End If

            ElseIf Pagados = dtsFP.gVencimientos.Count Then
                dtsFP.gidEstado = EstadoPagada.gidEstado
            Else
                dtsFP.gidEstado = EstadoParcial.gidEstado
            End If

        End If
        Call CargarEstados()
    End Sub


    Private Sub CargarConceptos()
        funcCO.RenumerarSiEsNecesario(iidFactura)
        listaC = funcCO.mostrar(iidFactura)
        lvConceptos.Items.Clear()
        For Each dts As DatosConceptoFacturaProv In listaC
            nuevaLineaLV(dts)
        Next
        cbArticulo.Focus()
    End Sub

    Private Sub IntroducirArticulos()
        cbcodArticulo.Items.Clear()
        cbcodArticulo.Text = ""
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbcodArticuloProv.Items.Clear()
        cbcodArticuloProv.Text = ""
        iidArticulo = 0

        Dim lista As List(Of DatosArticuloProveedor) = funcARP.Mostrar(iidProveedor, 0, iidFamilia, iidSubFamilia, "Articulo", True)
        Dim dts As DatosArticuloProveedor
        For Each dts In lista
            If dts.gcodArticulo <> "" Then cbcodArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticulo, dts.gidArticuloProv))
            If dts.gNombre <> "" Then cbArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gNombre, dts.gidArticuloProv))
            If dts.gcodArticuloProv <> "" Then cbcodArticuloProv.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticuloProv, dts.gidArticuloProv))
        Next

    End Sub


#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub nuevaLineaLV(ByVal dts As DatosConceptoFacturaProv)
        With lvConceptos.Items.Add(" ")
            .SubItems.Add(dts.gidConcepto) '1
            .SubItems.Add(dts.gcodArticulo) '2
            .SubItems.Add(dts.gcodArticuloProv) '3
            .SubItems.Add(dts.gArticuloProv) '4
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad) '5
            .SubItems.Add(FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsFP.gSimbolo) '6
            .SubItems.Add(FormatNumber(dts.gDescuento, 2) & "%") '7 
            .SubItems.Add(FormatNumber(dts.gsubTotal, 2) & dtsFP.gSimbolo) '8
            .SubItems.Add(dts.gidArticulo) '9
            .SubItems.Add(dts.gidEstado) '10
            .SubItems.Add(dts.gNombreTipoIVA & " " & dts.gTipoIVAFac & "%") '11
            .SubItems.Add(dts.gnumAlbaran) '12
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoFacturaProv)
        'Actualizar a partir del índice actual
        If indice <> -1 Then
            With lvConceptos.Items(indice)
                .SubItems(2).Text = dts.gcodArticulo
                .SubItems(3).Text = dts.gcodArticuloProv
                .SubItems(4).Text = dts.gArticuloProv
                .SubItems(5).Text = FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad
                .SubItems(6).Text = FormatNumber(dts.gPrecioNetoUnitario, 2) & dtsFP.gSimbolo
                .SubItems(7).Text = FormatNumber(dts.gDescuento, 2) & "%"
                .SubItems(8).Text = FormatNumber(dts.gsubTotal, 2) & dtsFP.gSimbolo
                .SubItems(9).Text = dts.gidArticulo
                .SubItems(10).Text = dts.gidEstado
                .SubItems(11).Text = dts.gNombreTipoIVA & " " & dts.gTipoIVAFac & "%"
                .SubItems(12).Text = dts.gnumAlbaran

            End With
            'Call Recalcular()
            'Call CalcularVencimientos()
        End If
    End Sub


    Private Sub Recalcular()

        funcFP.DatosCalculados(dtsFP) 'Recargamos el dtsFP por referencia
        Call PresentarTotales()
    End Sub

    Private Sub PresentarTotales()
        BaseImponible.Text = FormatNumber(dtsFP.gBase, 2)
        TotalIVA.Text = FormatNumber(dtsFP.gTotalIVA, 2)
        TotalRE.Text = FormatNumber(dtsFP.gTotalRE, 2)
        Retencion.Text = FormatNumber(dtsFP.gRetencion, 2)
        Total.Text = FormatNumber(dtsFP.gTotal, 2)
        PrecioTransporte.Text = FormatNumber(dtsFP.gPrecioTransporte, 2)

    End Sub


    Private Sub CargarlvVencimientos(ByVal Vtos As List(Of DatosVencimientoProv))
        lvVencimientos.Items.Clear()
        Dim Cobrados As Integer = 0
        Dim Devueltos As Integer = 0
        'Dim funcVE As New FuncionesVencimientos
        'Dim Vtos As List(Of DatosVencimiento) = funcVE.Mostrar(numDoc.Text)

        If Not Vtos Is Nothing Then
            For Each dts As DatosVencimientoProv In Vtos
                With lvVencimientos.Items.Add(dts.gVencimiento)
                    .SubItems.Add(FormatNumber(dts.gImporte, 2) & dtsFP.gSimbolo)

                    If dts.gDevuelto Then
                        .ForeColor = Color.Red
                        Devueltos = Devueltos + 1
                    ElseIf dts.gPagado Then
                        .ForeColor = Color.Green
                        Cobrados = Cobrados + 1
                    Else
                        .ForeColor = Color.Black
                    End If
                End With
            Next
        End If

        If lvConceptos.Items.Count > 0 Then
            If Devueltos > 0 Then
                If cbEstado.FindString(EstadoDevuelta.gEstado) = -1 Then
                    cbEstado.Items.Add(EstadoDevuelta)
                End If
                cbEstado.Text = EstadoDevuelta.gEstado
                ConceptosEditables = True
            Else
                If Cobrados = 0 Then
                    If cbEstado.SelectedIndex = -1 Then
                        If cbEstado.FindString(EstadoPendiente.gEstado) = -1 Then
                            cbEstado.Items.Add(EstadoPendiente)
                        End If
                        cbEstado.Text = EstadoPendiente.gEstado
                        ConceptosEditables = True
                    Else
                        If cbEstado.SelectedItem.gAnulado Then
                        Else
                            If cbEstado.FindString(EstadoPendiente.gEstado) = -1 Then
                                cbEstado.Items.Add(EstadoPendiente)
                            End If
                            cbEstado.Text = EstadoPendiente.gEstado
                        End If
                    End If
                ElseIf Cobrados = dtsFP.gVencimientos.Count Then
                    If cbEstado.FindString(EstadoPagada.gEstado) = -1 Then
                        cbEstado.Items.Add(EstadoPagada)
                    End If
                    cbEstado.Text = EstadoPagada.gEstado
                    ConceptosEditables = False
                Else
                    Dim dtsES As DatosEstado = funcES.EstadoFactura("PARCIAL")
                    If cbEstado.FindString(EstadoParcial.gEstado) = -1 Then
                        cbEstado.Items.Add(EstadoParcial)
                    End If
                    cbEstado.Text = EstadoParcial.gEstado
                    ConceptosEditables = False
                End If

            End If
        End If
    End Sub


    Private Sub MostrarLinea(ByVal dts As DatosConceptoFacturaProv)

        cbcodArticulo.Text = dts.gcodArticulo
        cbcodArticuloProv.Text = dts.gcodArticuloProv
        Cantidad.Text = FormatNumber(dts.gCantidad, 2)
        lbUnidad.Text = dts.gTipoUnidad
        cbFamilia.Text = dts.gFamilia
        cbSubFamilia.Text = dts.gSubFamilia
        cbArticulo.Text = dts.gArticuloProv
        'Si no está en los combos, lo añadimos
        If cbArticulo.SelectedIndex = -1 Then
            cbArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gArticuloProv, dts.gidArticuloProv))
            cbArticulo.Text = dts.gArticuloProv
            cbcodArticuloProv.Items.Add(New IDComboBox3(dts.gcodArticuloProv, dts.gidArticulo, dts.gidArticuloProv))
            cbcodArticuloProv.Text = dts.gcodArticuloProv
            cbcodArticulo.Items.Add(New IDComboBox3(dts.gidArticulo, dts.gcodArticulo, dts.gidArticuloProv))
            cbcodArticulo.Text = dts.gcodArticulo
        End If

        Precio.Text = FormatNumber(dts.gPrecioNetoUnitario, If(dts.gPrecioNetoUnitario >= 5, 4, 6))
        subTotal.Text = FormatNumber(dts.gsubTotal, 2)

        cbFamilia.Text = dts.gFamilia
        cbSubFamilia.Text = dts.gSubFamilia

        Dim dtsTI As DatosTipoIVA = funcTI.Mostrar1(dts.gidTipoIVA)
        If dtsTI.gTipoIVA <> dts.gTipoIVAFac Then
            dtsTI.gTipoIVA = dts.gTipoIVAFac
            cbTipoIVA.Items.Add(dtsTI)
        End If
        cbTipoIVA.Text = dtsTI.ToString
        ObservacionesC.Text = dts.gObservaciones
        idConceptoAlbaran = dts.gidconceptoAlbaranProv
        numAlbaran = dts.gnumAlbaran
    End Sub


    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call IntroducirArticulos()
        End If
    End Sub

    Private Sub CalcularVencimientos()
        If Total.Text = "" Then Total.Text = 0
        If cbTipoPago.SelectedIndex <> -1 AndAlso cbProveedor.SelectedIndex <> -1 AndAlso Not EstadoInicial.gBloqueado And Not (EstadoInicial.gEspera And EstadoInicial.gEnCurso) Then
            If Total.Text = 0 Then
                dtsFP.gVencimientos = Nothing
            Else
                Dim fecha As Date = dtpFecha.Value
                Dim dias As Integer = 0
                Dim Vencimiento As Date = dtpFecha.Value
                Dim numPagos As Integer = cbTipoPago.SelectedItem.gnumPagos
                If numPagos > 0 Then
                    Dim importe As Double = Total.Text / numPagos
                    Dim FechaI As Date
                    Dim FechaF As Date
                    If dtsFA.gExentoPagosAgosto Then
                        FechaI = CDate("1-8-" & Year(fecha))
                        FechaF = CDate("31-8-" & Year(fecha))
                    Else
                        'Si no está exento de pago ponemos una franja qua acaba antes de empezar
                        FechaI = Now.Date.AddDays(1)
                        FechaF = Now.Date
                    End If
                    Dim lista As New List(Of DatosVencimientoProv)
                    Dim dts As DatosVencimientoProv
                    For p = 1 To numPagos
                        If p = 1 And numPagos > 1 Then
                            dias = cbTipoPago.SelectedItem.gCarencia
                        Else
                            dias = dias + cbTipoPago.SelectedItem.gContadorDias
                        End If
                        Vencimiento = CalculaVencimiento(fecha, dtsFA.gDiaPago1, dtsFA.gDiaPago2, dias, FechaI, FechaF)
                        dts = New DatosVencimientoProv
                        dts.gidFactura = iidFactura
                        dts.gVencimiento = Vencimiento
                        dts.gImporte = importe
                        dts.gPagado = False
                        lista.Add(dts)
                    Next
                    lista.Sort(Function(y, x) x.gVencimiento.CompareTo(y.gVencimiento))
                    dtsFP.gVencimientos = lista
                End If
                Call CargarlvVencimientos(dtsFP.gVencimientos)
            End If

        End If

    End Sub


    Private Function CalculaVencimiento(ByVal FechaFactura As Date, ByVal DiaPago1 As Byte, ByVal DiaPago2 As Byte, ByVal Dias As Integer, ByVal VacacionesI As Date, ByVal VacacionesF As Date) As Date
        'Ver  http://comunidadnexus.com/2009/09/30/el-calculo-de-vencimientos-en-nexus/
        Dim Vencimiento As Date
        If Dias Mod 30 = 0 Then
            'Si es múltiplo de 30 añadimos meses
            Vencimiento = FechaFactura.AddMonths(Dias \ 30)
        Else
            'Si no es multiplo de 30 añadimos diás
            Vencimiento = FechaFactura.AddDays(Dias)
        End If


        'While FechaFactura.Day <> Vencimiento.Day
        'Vencimiento = Vencimiento.AddDays(1)
        'End While
        Dim Vencimiento2 As Date = Vencimiento
        'Aplicar los dias de pago
        Dim diaPagoMes As Integer
        If DiaPago1 > 0 Then
            diaPagoMes = CalculaDiaPagoMes(DiaPago1, Vencimiento)
            While Vencimiento.Day <> diaPagoMes
                Vencimiento = Vencimiento.AddDays(1)
            End While
            While Vencimiento >= VacacionesI And Vencimiento <= VacacionesF 'Si cae dentro de las vacaciones
                Vencimiento = Vencimiento.AddDays(1)
            End While
            diaPagoMes = CalculaDiaPagoMes(DiaPago1, Vencimiento)
            While Vencimiento.Day <> diaPagoMes
                Vencimiento = Vencimiento.AddDays(1)
            End While

        End If

        If DiaPago2 > 0 Then
            diaPagoMes = CalculaDiaPagoMes(DiaPago2, Vencimiento2)
            While Vencimiento2.Day <> diaPagoMes
                Vencimiento2 = Vencimiento2.AddDays(1)
            End While
            While Vencimiento2 >= VacacionesI And Vencimiento2 <= VacacionesF 'Si cae dentro de las vacaciones
                Vencimiento2 = Vencimiento2.AddDays(1)
            End While
            diaPagoMes = CalculaDiaPagoMes(DiaPago2, Vencimiento2)
            While Vencimiento2.Day <> diaPagoMes
                Vencimiento2 = Vencimiento2.AddDays(1)
            End While

        End If
        'Seleccionar el vencimiento más próximo
        If DiaPago2 = 0 Then
            Return Vencimiento
        ElseIf DiaPago1 = 0 Then
            Return Vencimiento2
        Else
            If Date.Compare(Vencimiento, Vencimiento2) > 0 Then
                Return Vencimiento2
            Else
                Return Vencimiento
            End If
        End If
    End Function


    Private Function CalculaDiaPagoMes(ByVal dia As Byte, ByVal Vencimiento As Date) As Byte
        Dim fecha As Date = CDate("28-" & Vencimiento.Month & "-" & Vencimiento.Year)
        Select Case dia
            Case Is <= 28
                Return dia
            Case 29
                If Vencimiento.Month <> fecha.AddDays(1).Month Then
                    Return 28
                Else
                    Return 29
                End If
            Case 30
                If Vencimiento.Month <> fecha.AddDays(1).Month Then
                    Return 28
                ElseIf Vencimiento.Month <> fecha.AddDays(2).Month Then
                    Return 29
                Else
                    Return 30
                End If
            Case 31
                If Vencimiento.Month <> fecha.AddDays(1).Month Then
                    Return 28
                ElseIf Vencimiento.Month <> fecha.AddDays(2).Month Then
                    Return 29
                ElseIf Vencimiento.Month <> fecha.AddDays(3).Month Then
                    Return 30
                Else
                    Return 31
                End If
        End Select
    End Function

#End Region


#Region "BOTONES GENERALES"

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If indiceL > 0 Then
            Dim idProveedorAnterior As Integer = 0
            If Not dtsFP Is Nothing Then idProveedorAnterior = dtsFP.gidProveedor
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL - 1
                    iidFactura = Facturas(indiceL)
                    Call CargarFacturaExistente()
                   
                    Call PresentarAvisoFacturacion()
                End If

            Else
                Call InicializarGeneral()
                indiceL = indiceL - 1
                iidFactura = Facturas(indiceL)

                Call CargarFacturaExistente()
               
                Call PresentarAvisoFacturacion()
            End If


        End If
    End Sub


    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If indiceL < Facturas.Count - 1 Then
            Dim idProveedorAnterior As Integer = 0
            If Not dtsFP Is Nothing Then idProveedorAnterior = dtsFP.gidProveedor
            If cambios Then
                If MsgBox("Se perderán los datos no guardados", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call InicializarGeneral()
                    indiceL = indiceL + 1
                    iidFactura = Facturas(indiceL)
                    Call CargarFacturaExistente()
                    AvisadoProveedor = (dtsFP.gidProveedor = idProveedorAnterior)
                    AvisadoFacturacion = (dtsFP.gidProveedor = idProveedorAnterior)
                    Call PresentarAvisoFacturacion()
                End If
            Else
                Call InicializarGeneral()
                indiceL = indiceL + 1
                iidFactura = Facturas(indiceL)
                Call CargarFacturaExistente()
                AvisadoProveedor = (dtsFP.gidProveedor = idProveedorAnterior)
                AvisadoFacturacion = (dtsFP.gidProveedor = idProveedorAnterior)
                Call PresentarAvisoFacturacion()
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




    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerProveedor.Click
        If cbProveedor.SelectedIndex <> -1 Then
            Dim GG As New GestionProveedores
            GG.SoloLectura = vSoloLectura
            GG.pidProveedor = dtsPR.gidProveedor
            GG.ShowDialog()
            If GG.pidProveedor = dtsPR.gidProveedor Then
                iidProveedor = dtsPR.gidProveedor
                dtsPR = funcPR.mostrar1(iidProveedor)
                Dim dtsFAN As datosfacturacion = funcFA.mostrarProv(iidProveedor)
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
                    If dtsFP.gidTipoIVATransporte <> dtsFAN.gidTipoIVA Or dtsFP.gTipoIVATransporte <> dtsFAN.gTipoIVA Or dtsFP.gTipoRecargoEqTransporte <> dtsFAN.gTipoRecargoEq _
                    Or dtsFP.gRecargoEquivalencia <> dtsFAN.gRecargoEquivalencia Or dtsFP.gidTipoRetencion <> dtsFAN.gidTipoRetencion Or dtsFP.gTipoRetencionFac <> dtsFAN.gTipoRetencion Then
                        If MsgBox("¿Propagar y guardar los cambios de facturación del proveedor a la factura?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            Call CargarDatosFacturacionProveedor()
                            Call GuardarGeneral()
                            'Call Recalcular()
                            'Call CalcularVencimientos()

                        End If
                    End If
                Else
                    MsgBox("La factura no es modificable en estado " & cbEstado.Text)
                End If

                'If dtsFP.gidFactura = 0 Then 'Si estamos editando la factura no cambiamos nada

                'End If

            End If

            '    Call Recalcular()
            '    Call CalcularVencimientos()
            Call CargarCombosProveedor()

        End If

    End Sub

    Private Sub bBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarProveedor.Click
        Dim GG As New busquedaproveedor
        GG.SoloLectura = vSoloLectura
        GG.pModo = "B"
        GG.ShowDialog()
        If GG.pidproveedor > 0 Then
            dtsPR = funcPR.mostrar1(GG.pidproveedor)
            cbCodProveedor.Text = dtsPR.gcodProveedor
            cbProveedor.Text = dtsPR.gnombrefiscal
            'iidproveedor = GG.pidproveedor
            Call PresentarAvisoProveedor()
            Call CargarDatosFacturacionProveedor()
            'Call CargarDatosClienteNoEditables()
            'Call CargarCombosCliente()
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
            'Borrar Factura
            If G_AGeneral = "G" Then  'Si aún no hemos guardado la Factura, es como pulsar nuevo
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
                MsgBox("No es posible borrar una Factura existente.")
            End If
        Else
            If dtsFP.gidEstado = EstadoPagada.gidEstado Then
                ConceptosEditables = False
            Else
                ConceptosEditables = True
            End If
            Call BorrarConcepto()

        End If
    End Sub

    Private Sub BorrarConcepto()
        If cbArticulo.Text <> "" Then
            If ConceptosEditables Then
                If MsgBox("¿Desea borrar el concepto seleccionado? (No se puede deshacer)", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim iidConcepto As Integer = lvConceptos.Items(indice).SubItems(1).Text
                    If iidConcepto > 0 Then
                        funcCO.borrar(iidConcepto)
                        lvConceptos.Items.RemoveAt(indice)
                        Call LimpiarEdicion()
                        If lvConceptos.Items.Count = 0 Then
                            cbEstado.Items.Clear()
                            'cbEstado.Items.Add(funcES.EstadoAnulado("Factura"))
                            Dim dtsES As DatosEstado = funcES.EstadoCabecera("Factura")
                            cbEstado.Items.Add(dtsES)
                            cbEstado.Text = dtsES.ToString
                            funcFP.actualizaEstado(iidFactura, dtsES.gidEstado)
                        End If
                        Call Recalcular()
                        Call CalcularVencimientos()
                    End If
                End If
            Else
                MsgBox("Conceptos no editables en estado " & cbEstado.Text)
            End If
        End If
    End Sub



    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click

        If cambios Then
            If MsgBox("Se perderán los los datos introducidos y se creará una nueva factura. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                ProveedorAvisado = 0
                Call InicializarGeneral()
                Call introducirProveedores()
                Call Nuevo()
            End If
        Else
            If MsgBox("Se creará una nueva factura. ¿Continuar?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                ProveedorAvisado = 0
                Call InicializarGeneral()
                Call introducirProveedores()
                Call Nuevo()
            End If
        End If


    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Dim iidTipoIVAAnterior As Integer = 0
        Dim dTipoIVAAnterior As Double = 0
        Dim dTipoRecargoEqAnterior As Double = 0
        'If iidFactura > 0 Then
        '    iidTipoIVAAnterior = funcFP.idTipoIVA(idFactura)
        '    dTipoIVAAnterior = funcOF.TipoIVA(numDoc.Text)
        '    dTipoRecargoEqAnterior = funcOF.TipoRecargoEq(numDoc.Text)
        'End If
        If GuardarGeneral() Then
            If dtsFP.gidEstado = EstadoPagada.gidEstado Then
                ConceptosEditables = False
            Else
                ConceptosEditables = True
            End If
            If cbArticulo.Text <> "" Then
                If ConceptosEditables Then
                    Call GuardarConcepto()
                    'Call PropagarIVAConceptos(iidTipoIVAAnterior, dTipoIVAAnterior, dTipoRecargoEqAnterior)
                Else
                    MsgBox("Conceptos no editables en estado " & cbEstado.Text)
                End If
            End If
        End If
    End Sub

    Private Function GuardarGeneral()
        Try
            Dim validar As Boolean = True
            ep1.Clear()
            ep2.Clear()
            Dim soloEstado As Boolean = False
            If cbEstado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
            End If
            If cbProveedor.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbProveedor, "Debe seleccionar un proveedor")
            End If
            If cbDireccion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbDireccion, "Debe seleccionar una dirección")
            Else
                Dim iidPais As Integer = funcUB.campoidPais(cbDireccion.SelectedItem.itemData)
                Dim sNIF As String = dtsPR.gnif
                If iidPais = 1 Then
                    'Si es español, verifcamos el NIF
                    If ValidateCif(sNIF) Or ValidateNif(sNIF) Then
                    Else
                        'validar = False
                        ep2.SetError(bVerProveedor, "NIF no válido. Debe corregirlo en la ficha de proveedor.")
                    End If
                ElseIf funcPA.NIFObligatorio(iidPais) Then
                    If sNIF = "" Then
                        'validar = False
                        ep1.SetError(bVerProveedor, "No se ha especificado el NIF. Debe corregirlo en la ficha del proveedor.")
                    End If


                End If
            End If
            If cbMoneda.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMoneda, "Debe seleccionar una moneda")
            End If
            If cbMedioPago.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMedioPago, "Se ha de seleccionar un medio de pago")
            Else
                If cbCuenta.Enabled Then
                    If cbCuenta.SelectedIndex = -1 Then
                        ep2.SetError(cbCuenta, "No ha seleccinado una cuenta bancaria")
                    End If
                End If
            End If
            If cbTipoPago.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbTipoPago, "Se ha de seleccionar un tipo de pago")
            End If

            If cbRetencion.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbRetencion, "Se ha de seleccionar un tipo de Retención")
            End If
            If cbEstado.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbEstado, "Se ha de seleccionar un estado")
            ElseIf EstadoInicial.gBloqueado And Not cbEstado.SelectedItem.gAutomatico Then 'Estaba pagada y no pasa a devuelta
                validar = False
                MsgBox("Esta factura no se puede modificar porque está en estado " & EstadoInicial.gEstado)
                cambios = False

            End If
            If cbSolicitadoPor.SelectedIndex = -1 Then
                'validar = False
                ep2.SetError(cbSolicitadoPor, "No se ha seleccionado quien solicita")
            End If
            If numFactura.Text = "" Then
                validar = False
                ep1.SetError(numFactura, "Se ha de especificar el número de factura del proveedor")
            Else
                If validar Then
                    iidProveedor = cbProveedor.SelectedItem.itemdata
                    If funcFP.ExisteFactura(numFactura.Text, iidProveedor, iidFactura) Then
                        validar = False
                        ep1.SetError(numFactura, "Número de factura ya utilizado")
                    End If
                End If
            End If
            If codFactura.Text <> "" Then
                If funcFP.ExistecodFactura(codFactura.Text, iidFactura) Then
                    validar = False
                    ep1.SetError(codFactura, "Código de factura ya utilizado")
                End If
            End If


            If validar Then
                dtsFP.gidFactura = iidFactura
                dtsFP.gnumFactura = numFactura.Text
                dtsFP.gidProveedor = cbProveedor.SelectedItem.itemdata
                dtsFP.gidUbicacion = cbDireccion.SelectedItem.itemdata
                dtsFP.gFecha = dtpFecha.Value.Date
                dtsFP.gReferencia = Referencia.Text
                dtsFP.gObservaciones = Observaciones.Text
                dtsFP.gNotas = Nota.Text
                dtsFP.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.itemdata)
                dtsFP.gidMedioPago = If(cbMedioPago.SelectedIndex = -1, 0, cbMedioPago.SelectedItem.gidMEdioPago)
                dtsFP.gidTipoPago = If(cbTipoPago.SelectedIndex = -1, 0, cbTipoPago.SelectedItem.gidTipoPago)
                dtsFP.gidCuentaBanco = If(cbCuenta.SelectedIndex = -1, 0, cbCuenta.SelectedItem.itemdata)
                dtsFP.gcodMoneda = cbMoneda.SelectedItem.gcodMoneda
                dtsFP.gidTipoRetencion = If(cbRetencion.SelectedIndex = -1, 0, cbRetencion.SelectedItem.gidTipoRetencion)
                dtsFP.gRecargoEquivalencia = ckRecargoEquivalencia.Checked
                dtsFP.gidTipoIVATransporte = dtsFA.gidTipoIVA
                dtsFP.gTipoIVATransporte = dtsFA.gTipoIVA
                dtsFP.gTipoRecargoEqTransporte = dtsFA.gTipoRecargoEq
                dtsFP.gcodFactura = codFactura.Text
                If IsNumeric(Descuento.Text) Then
                    dtsFP.gProntoPago = Descuento.Text
                Else
                    dtsFP.gProntoPago = 0
                End If
                dtsFP.gSolicitadoVia = cbsolicitadoVia.Text
                dtsFP.gTipoRetencionFac = cbRetencion.SelectedItem.gtipoRetencion
                dtsFP.gidEstado = cbEstado.SelectedItem.gidEstado
                If IsNumeric(PrecioTransporte.Text) Then
                    dtsFP.gPrecioTransporte = PrecioTransporte.Text
                Else
                    dtsFP.gPrecioTransporte = 0
                End If


                dtsFP.gEstado = cbEstado.Text
                dtsFP.gidPersona = If(cbSolicitadoPor.SelectedIndex = -1, 0, cbSolicitadoPor.SelectedItem.itemdata)
                dtsFP.gPersona = cbSolicitadoPor.Text

                'Call AsignarDOCDatosClienteNoEditables()


                If G_AGeneral = "G" Then

                    'Call CargarTiposNoEditables()


                    iidFactura = funcFP.insertar(dtsFP)
                    Call Recalcular()
                    funcFP.actualizarTotales(dtsFP)
                    G_AGeneral = "A"
                    MsgBox("Creada la Factura " & numFactura.Text & ". Ya puede introducir los conceptos.")
                    gbConceptos.Enabled = True
                    'cbEstado.Items.Add(funcES.EstadoAnulado("Factura"))
                    'Debe seguir en estado cabecera
                Else


                    funcFP.actualizar(dtsFP)

                    If Total.Text = "" Then Total.Text = 0
                    Dim totalFactura As Double = Total.Text
                    Dim totalVencimientos As Double = 0
                    If Not dtsFP.gVencimientos Is Nothing Then
                        For Each dtsV As DatosVencimientoProv In dtsFP.gVencimientos
                            totalVencimientos = totalVencimientos + dtsV.gImporte
                        Next
                    End If
                    Call Recalcular()
                    funcFP.actualizarTotales(dtsFP)
                    Dim diferencia As Double = Math.Abs(Total.Text - totalVencimientos)

                    If diferencia > 0.01 Then Call CalcularVencimientos()

                    funcFP.actualizarVencimientos(dtsFP)
                    Call CargarlvVencimientos(dtsFP.gVencimientos)
                    EstadoInicial = cbEstado.SelectedItem
                    Dim texto As String = ""


                    If cbArticulo.Text = "" Then MsgBox("Factura actualizada correctamente")

                End If
                cambios = False
            End If
            Return validar
        Catch ex As Exception
            ex.Data.Add("Función", "GuardarGeneral")
            ex.Data.Add("numFactura.Text", numFactura.Text)
            CorreoError(ex)
            Return False
        End Try
    End Function




    Private Sub GuardarConcepto()
        'Guarda o actualiza los datos de un concepto

        If cbArticulo.Text <> "" And Cantidad.Text <> "" Then   'solo actua si hay alguna información en la zona de edición
            Dim iidConcepto As Long = 0
            Try
                Dim dts As DatosConceptoFacturaProv
                dts = cargaConcepto()
                iidConcepto = dts.gidConcepto
                If indice = -1 Then
                    dts.gidConcepto = funcCO.insertar(dts)
                    iidConcepto = dts.gidConcepto
                    nuevaLineaLV(dts)
                Else   'Si el botón dice ACTUALIZAR

                    funcCO.actualizar(dts)
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
                    dtsAP.gcodMoneda = dtsFP.gcodMoneda
                    dtsAP.gFechaPrecio = dtsFP.gFecha
                    dtsAP.gcodArticuloProv = cbcodArticuloProv.Text
                    dtsAP.gPrecioUnitario = 0

                    If dts.gidArticuloProv = 0 Then
                        dts.gidArticuloProv = funcARP.Guardar(dtsAP)
                    Else
                        funcARP.actualizar(dtsAP)
                    End If

                    If funcAR.idProveedor(iidArticulo) = 0 Then
                        If MsgBox("¿Desea establecer " & cbProveedor.Text & " como proveedor habitual de " & funcAR.Articulo(iidArticulo) & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                            funcAR.actualizarProveedor(iidArticulo, iidProveedor)
                        End If
                    End If
                    'Actualizar el precio del artículo

                    Dim dtsAE As New DatosArticuloPrecio
                    dtsAE.gidArticulo = dts.gidArticulo
                    dtsAE.gFechaPrecio = dtpFecha.Value.Date

                    dtsAE.gcodMoneda = dtsFP.gcodMoneda
                    dtsAE.gidProveedorPrecio = dtsFP.gidProveedor
                    dtsAE.gidConcepto = dts.gidConcepto
                    dtsAE.gPrecio = funcARP.Precio(dts.gidArticuloProv)
                    dtsAE.gTipoPrecio = "C"
                    dtsAE.gActivo = True
                    dtsAE.gDescuento = 0
                    dtsAE.gidClientePrecio = 0
                    funcAE.ActualizarH(dtsAE)
                End If
                Call Recalcular()
                Call CalcularVencimientos()
                Call LimpiarEdicion()
                funcFP.actualizarVencimientos(dtsFP)
            Catch ex As Exception
                ex.Data.Add("Función", "GuardarConcepto")
                ex.Data.Add("numFactura.Text", numFactura.Text)
                ex.Data.Add("iidConcepto", iidConcepto)
                ex.Data.Add("iidArticulo", iidArticulo)
                CorreoError(ex)

            End Try

        End If


    End Sub

    Private Function cargaConcepto() As DatosConceptoFacturaProv
        'Carga los datos de la zona de edición en un dts de ConceptoPedidoProv

        Dim dts As New DatosConceptoFacturaProv
        dts.gidFactura = iidFactura
        If indice = -1 Then
            dts.gidConcepto = 0
        Else
            dts.gidConcepto = lvConceptos.Items(indice).SubItems(1).Text
        End If

        If indice = -1 And cbcodArticuloProv.Text = "" And cbcodArticulo.Text <> "" Then
            dts.gcodArticuloProv = cbcodArticulo.Text 'Asignar el codArticuloProv como el codArticulo
        Else
            dts.gcodArticuloProv = cbcodArticuloProv.Text
        End If
        If cbArticulo.SelectedIndex = -1 Then
            dts.gidArticulo = 0
        Else
            dts.gidArticulo = cbArticulo.SelectedItem.itemdata
        End If
        dts.gcodArticulo = cbcodArticulo.Text
        dts.gArticuloProv = cbArticulo.Text
        dts.gCantidad = If(IsNumeric(Cantidad.Text), CDbl(Cantidad.Text), 0)

        dts.gPVPUnitario = 0
        dts.gidTipoIVA = cbTipoIVA.SelectedItem.gidTipoIVA
        dts.gDescuento = If(IsNumeric(DescuentoC.Text), CDbl(DescuentoC.Text), 0)
        dts.gPrecioNetoUnitario = If(IsNumeric(Precio.Text), CDbl(Precio.Text), 0)

        dts.gOrden = indice + 1
        dts.gTipoIVAFac = cbTipoIVA.SelectedItem.gTipoIVA

        dts.gTipoRecargoEqFac = cbTipoIVA.SelectedItem.gTipoRecargoEq
       
        dts.gTipoIVA = dts.gTipoIVAFac
        dts.gTipoRecargoEq = dts.gTipoRecargoEqFac
        dts.gObservaciones = ObservacionesC.Text
        dts.gidEstado = EstadoCEspera.gidEstado
        dts.gEstado = EstadoCEspera.gEstado
        dts.gNombreTipoIVA = cbTipoIVA.SelectedItem.gNombre
        dts.gidconceptoAlbaranProv = idConceptoAlbaran
        dts.gnumAlbaran = numAlbaran
        Return dts

    End Function


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
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
        If iidFactura = 0 Then
            MsgBox("Aún no se ha guardado la factura")

        ElseIf cambios Then
            MsgBox("Hay cambios pendientes de guardar")
        Else
            InformeFacturaProv.verInforme(iidFactura)
            InformeFacturaProv.ShowDialog()
        End If

    End Sub

    Private Sub bPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPDF.Click
        If iidFactura = 0 Then
            MsgBox("Aún no se ha guardado la factura")
        End If

        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la factura")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        Else

            Dim fichero As String = "FacturaProv SV " & Trim(numFactura.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            Dim sfd As New SaveFileDialog
            sfd.FileName = fichero
            sfd.ShowDialog()
            InformeFacturaProv.GeneraPDF(iidFactura, sfd.FileName, "")
            If My.Computer.FileSystem.FileExists(sfd.FileName) Then
                Process.Start(sfd.FileName)
            End If
        End If


    End Sub



    Private Sub beMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEmail.Click
        If G_AGeneral = "G" Then
            MsgBox("Aún no se ha guardado la factura")
        ElseIf lvConceptos.Items.Count = 0 Then
            MsgBox("No se han introducido conceptos")
        ElseIf cbDireccion.SelectedIndex = -1 Then
            MsgBox("No hay una dirección seleccionada válida")
        Else
            Dim fichero As String = "FacturaProv SV " & Trim(numFactura.Text) & " " & Microsoft.VisualBasic.Left(cbProveedor.Text, 40) & ".pdf"
            fichero.Replace("/", "_")
            fichero.Replace("\", "_")

            Dim camino As String = Path.GetTempPath()
            InformeFacturaProv.GeneraPDF(iidFactura, fichero, camino)
            Dim destinatario As String = funcUB.campoCorreo(cbDireccion.SelectedItem.itemdata)
            If cbContacto.SelectedIndex <> -1 Then
                Dim lista As List(Of DatosMail) = funcMOA.MostrarContacto(cbContacto.SelectedItem.itemdata)
                For Each dts As DatosMail In lista
                    destinatario = If(destinatario = "", dts.gmail, destinatario & "; " & dts.gmail)
                Next
            End If

            'Se envía un correo outlook a la dirección de la ubicación
            CorreoOutlook("FACTURA PROVEEDOR", funcPE.campoCorreo(Inicio.vIdUsuario), destinatario, camino & fichero, cbContacto.Text, numFactura.Text, dtpFecha.Value.Date, dtpFecha.Value.Date, funcUB.campoIdioma(cbDireccion.SelectedItem.itemData))

        End If
    End Sub





    Private Sub bVencimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVencimientos.Click
        If iidFactura > 0 Then
            If EstadoInicial.gCompleto Then
                MsgBox("Factura en estado PAGADA")
            End If
            Dim GG As New subVencimientosProv
            GG.SoloLectura = vSoloLectura
            GG.pVencimientos = dtsFP.gVencimientos
            GG.pSimbolo = lbMoneda1.Text
            GG.pidFactura = iidFactura
            GG.pTotal = Total.Text
            GG.ShowDialog()
            If Not GG.pCancelado Then
                dtsFP.gVencimientos = GG.pVencimientos
                Call CargarlvVencimientos(dtsFP.gVencimientos)
                cambios = True
            End If
        End If
    End Sub

    Private Sub bVerIVAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerIVAs.Click
        If G_AGeneral = "A" And Not dtsFP Is Nothing Then
            Dim GG As New subVerIVAs
            GG.pListaIVA = dtsFP.gImportesIVA
            GG.pRecargoEquivalencia = dtsFP.gRecargoEquivalencia
            GG.ShowDialog()
        End If
    End Sub

#End Region

#Region "BOTONES CONCEPTOS"

    Private Sub BBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscarArticulo.Click

        Try
            Dim BA As New lbBusquedaArticulo
            BA.SoloLectura = vSoloLectura
            BA.pModo = "COMPRABLE"
            BA.pidProveedor = dtsFP.gidProveedor
            BA.ShowDialog()
            iidArticulo = BA.pidArticulo
            If BA.pidArticuloProv > 0 Then
                Dim dts As DatosArticuloProveedor = funcARP.Mostrar1(BA.pidArticuloProv)
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
            Dim dts As DatosArticuloProveedor = funcARP.Mostrar1(GG.pidArticuloProv)
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
            Dim dts As DatosArticuloProveedor = funcARP.Mostrar1(iidArticulo, iidProveedor)
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
                End If
            End If
        End If
    End Sub



#End Region


#Region "EVENTOS"



    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged, Descuento.TextChanged, PrecioTransporte.TextChanged
        If semaforo Then
            Call CalcularVencimientos()
            cambios = True
        End If
    End Sub


    'Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
    '    If cbMedioPago.SelectedIndex <> -1 Then
    '        cbCuenta.Enabled = cbMedioPago.SelectedItem.gBanco
    '    End If
    '    cambios = True
    'End Sub

    Private Sub cbMedioPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMedioPago.SelectedIndexChanged
        If cbMedioPago.SelectedIndex <> -1 Then
            If cbMedioPago.SelectedItem.gBanco Then
                cbCuenta.Enabled = True
                If Not dtsFA Is Nothing Then
                    If cbMedioPago.SelectedItem.gTransferencia Then
                        dtsFA.gCuentas = funcCB.Mostrar(dtsFA.gidFacturacion, True) 'Cuentas del proveedor
                    ElseIf cbMedioPago.SelectedItem.gGiro Then
                        dtsFA.gCuentas = funcCB.Mostrar(0, True) 'Cuentas propias
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
    End Sub


    Private Sub cbTipoPago_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoPago.SelectedIndexChanged
        If cbTipoPago.SelectedIndex <> -1 Then
            If cbTipoPago.SelectedItem.gProntoPago Then
                'Descuento.Enabled = True
                Descuento.Text = If(dtsFA Is Nothing, 0, dtsFA.gProntoPago)
            Else
                'Descuento.Enabled = False
                'Descuento.Text = 0
            End If
            If cbTipoPago.SelectedItem.gnumPagos = 1 Then
                ' bVencimiento.Enabled = True
            Else

                ' bVencimiento.Enabled = False
            End If
            If semaforo Then Call CalcularVencimientos()
            cambios = True
        End If
    End Sub

    Private Sub lbMoneda1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMoneda1.TextChanged
        lbMoneda2.Text = lbMoneda1.Text
        lbMoneda3.Text = lbMoneda1.Text
        lbMoneda4.Text = lbMoneda1.Text
        lbMoneda5.Text = lbMoneda1.Text
        lbMoneda6.Text = lbMoneda1.Text
        lbMoneda7.Text = lbMoneda1.Text
        lbmonedaT.Text = lbMoneda1.Text
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, Precio.Click, PrecioTransporte.Click, Descuento.Click, DescuentoC.Click
        sender.selectall()
    End Sub


    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress, Precio.KeyPress, PrecioTransporte.KeyPress, Descuento.KeyPress
        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(sender.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If sender.Text = "" Or sender.Text = "0" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(sender.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Dim iidConcepto As Long = lvConceptos.Items(indice).SubItems(1).Text
            Dim dts As DatosConceptoFacturaProv = funcCO.mostrar1(iidConcepto)
            Call MostrarLinea(dts)
        End If
    End Sub

    Private Sub cbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted
        If semaforo Then
            If cbFamilia.SelectedIndex > -1 Then
                iidFamilia = cbFamilia.SelectedItem.itemdata

                Call introducirSubFamilias()
                Call IntroducirArticulos()
            End If
        End If
    End Sub

    Private Sub cbSubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If cbSubFamilia.SelectedIndex > -1 Then
            iidSubFamilia = cbSubFamilia.SelectedItem.itemdata
            Call IntroducirArticulos()

        End If
    End Sub



    Private Sub cbDireccion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDireccion.SelectionChangeCommitted
        If cbDireccion.SelectedIndex <> -1 Then
            dtsUB = funcUB.mostrar1(cbDireccion.SelectedItem.itemdata)
            cambios = True
        End If
    End Sub

    Private Sub cbMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMoneda.SelectionChangeCommitted
        If cbMoneda.SelectedIndex <> -1 Then
            lbMoneda1.Text = cbMoneda.SelectedItem.gsimbolo
            'Cambiar moneda en todo el documento
            Dim moneda As String = cbMoneda.Text
            If dtsFP.gcodMoneda <> cbMoneda.SelectedItem.gcodMoneda Then
                Dim FechaCambio As Date = funcMO.CampoFecha(cbMoneda.SelectedItem.gcodMoneda)
                If FechaCambio <> dtpFecha.Value.Date Then
                    ep2.SetError(cbMoneda, "FECHA DEL CAMBIO " & FechaCambio)

                End If
                Dim codMonedaActual = cbMoneda.SelectedItem.gcodMoneda
                If G_AGeneral = "A" Then
                    'Si es un doc que ya existente
                    If MsgBox("El cambio de moneda quedará guardado en la base de datos. ¿Proceder con el cambio?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        funcFP.actualizaMoneda(iidFactura, codMonedaActual)
                        'dtsFP.gcodMoneda = cbMoneda.SelectedItem.gcodmoneda
                        dtsFP.gDivisa = cbMoneda.SelectedItem.gdivisa
                        dtsFP.gSimbolo = cbMoneda.SelectedItem.gsimbolo
                        Dim listaC As List(Of DatosConceptoFacturaProv) = funcCO.mostrar(iidFactura)
                        For Each dts As DatosConceptoFacturaProv In listaC
                            funcCO.CambiarPrecio(dts.gidConcepto, 0, funcMO.Cambio(dts.gPrecioNetoUnitario, dtsFP.gcodMoneda, codMonedaActual, True, Now.Date))
                        Next
                        dtsFP.gcodMoneda = codMonedaActual
                        Call CargarConceptos()
                        Call Recalcular()
                    Else
                        cbMoneda.Text = dtsFP.gDivisa
                        ep2.Clear()
                    End If
                Else
                    cbMoneda.Text = moneda
                End If
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbCodProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodProveedor.SelectionChangeCommitted
        If cbCodProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbCodProveedor.SelectedItem.itemdata
            'dtsFP = funcFP.Mostrar1(iidProveedor)
            cbCodProveedor.Text = funcPR.campocodProveedor(iidProveedor)
            Call CargarDatosProv()
            'Call CargarDatosFacturacionProveedor()
            Call CargarCombosProveedor()

            cambios = True
        End If
    End Sub


    Private Sub cbProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectionChangeCommitted
        If cbProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbProveedor.SelectedItem.itemdata
            'dtsFP = funcFP.Mostrar1(iidProveedor)
            cbCodProveedor.Text = funcPR.campocodProveedor(iidProveedor)
            Call CargarDatosProv()
            'Call CargarDatosFacturacionProveedor()
            Call CargarCombosProveedor()

            cambios = True
        End If
    End Sub



    Private Sub numDoc1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles numDoc1.DoubleClick
        If numDoc1.Text <> "VARIOS" Then
            Dim GG As New GestionAlbaranDeProv
            GG.SoloLectura = vSoloLectura
            GG.pidAlbaran = dtsFP.gAlbaranes(0).ItemData
            GG.ShowDialog()
        End If
    End Sub

    Private Sub Precio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Precio.TextChanged, Cantidad.TextChanged, DescuentoC.TextChanged
        If semaforo Then
            semaforo = False
            If Precio.Text = "" Or Precio.Text = "-" Or Precio.Text = "." Or Precio.Text = "," Then Precio.Text = 0
            If DescuentoC.Text = "" Or DescuentoC.Text = "-" Or DescuentoC.Text = "." Or DescuentoC.Text = "," Then DescuentoC.Text = 0
            If IsNumeric(Cantidad.Text) Then
                If Cantidad.Text = "" Then Cantidad.Text = 0
                subTotal.Text = FormatNumber(CDbl(Precio.Text) * CDbl(Cantidad.Text) * (1 - (CDbl(DescuentoC.Text) / 100)), 2)
            Else
                subTotal.Text = 0
            End If
            semaforo = True
        End If
    End Sub

    Private Sub CambiosEnCabecera(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsolicitadoVia.SelectedIndexChanged, numFactura.TextChanged _
      , codFactura.TextChanged, Referencia.TextChanged, cbSolicitadoPor.SelectedIndexChanged, cbDireccion.SelectedIndexChanged, cbMoneda.SelectedIndexChanged _
      , Observaciones.TextChanged, Nota.TextChanged, cbCuenta.SelectedIndexChanged, cbRetencion.SelectedIndexChanged, cbContacto.SelectedIndexChanged
        cambios = True
    End Sub

#End Region









End Class

  
   
 
