Public Class FlujoSiguiente

    Private vSoloLectura As Boolean
    Private Desde As String
    Private Hasta As String
    Private numDesde As String 'Numero del documento DESDE
    Public Conceptos As List(Of Long) 'Lista de conceptos a traspasar
    Public ListaConceptosPedidosProv As List(Of Integer)
    Private GeneroDesde As Char
    Private GeneroHasta As Char
    Private funcES As New FuncionesEstados
    Private listaC As Object
    Private numHasta As String
    Private funcD As Object 'Funciones Desde
    Private funcCD As Object 'Funciones ConceptosDesde
    Private funcH As Object 'Funciones Hasta
    Private funcCH As Object 'Funciones ConceptosHasta
    Private funcAR As New FuncionesArticulos
    Private funcFA As New funcionesFacturacion
    Private funcUB As New funcionesUbicaciones
    Private funcTP As New funcionesTiposPago
    Private funcCL As New funcionesclientes
    Private funcPA As New funcionesPaises
    Private funcAC As New funcionesArticuloCliente
    Private funcPS As New FuncionesParametrosServir
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcST As New FuncionesStock
    Private funcPR As New funcionesProveedores
    Private funcTI As New FuncionesTiposIVA
    Private funcAP As New FuncionesArticulosProv
    Private funaAPP As New funcionesArticuloProvPrecios
    Private funcCM As New funcionesComisiones
    Private funcEC As New FuncionesEscandallos
    Private dtsD As Object
    Private localizacion As Point
    Private dtsRR As DatosConceptoReparacion
    'Private idHasta As Integer
    'Private idDesde As Integer
    Private HastaPP As String

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property pDesde() As String
        Get
            Return UCase(Desde)
        End Get
        Set(ByVal value As String)
            Desde = UCase(value)
        End Set
    End Property

    Public Property pHasta() As String
        Get
            Return UCase(Hasta)
        End Get
        Set(ByVal value As String)
            Hasta = UCase(value)
        End Set
    End Property

    Public Property pnumDesde() As Integer
        Get
            Return numDesde
        End Get
        Set(ByVal value As Integer)
            numDesde = value
        End Set
    End Property

    Public Property pnumHasta() As Integer
        Get
            Return numHasta
        End Get
        Set(ByVal value As Integer)
            numHasta = value
        End Set
    End Property

    Public Property pConceptos() As List(Of Long)
        Get
            Return Conceptos

        End Get
        Set(ByVal value As List(Of Long))
            Conceptos = value
        End Set
    End Property

    Public Property pdtsRResumen() As DatosConceptoReparacion
        Get
            Return dtsRR
        End Get
        Set(ByVal value As DatosConceptoReparacion)
            dtsRR = value
        End Set
    End Property

    Public Property pLocalizacion() As Point
        Get
            Return localizacion
        End Get
        Set(ByVal value As Point)
            localizacion = value
        End Set
    End Property

    Private Sub FlujoSiguiente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HastaPP = PrimeraPalabra(Hasta)
        Me.Text = Desde & " A " & HastaPP
        'Me.Size = New Size(Me.Width, 111)
        bNuevo.Enabled = Not vSoloLectura
        bAnadir.Enabled = Not vSoloLectura
        gbNuevo.Text = If(Femenino(HastaPP), "NUEVA ", "NUEVO ") & HastaPP
        gbAgregar.Text = "AÑADIR A " & Hasta
        bNuevo.Text = If(Femenino(HastaPP), "NUEVA ", "NUEVO ") & HastaPP
        bAnadir.Text = "AÑADIR A " & HastaPP
        If HastaPP.Length > 12 Then
            lbFecha.Text = "FECHA "
        Else
            lbFecha.Text = "FECHA " & HastaPP
        End If

        lvConceptos.Columns(0).Text = HastaPP
        RefCliente2.Visible = False
        lbRefCliente2.Visible = False
        Select Case Desde
            Case "OFERTA"
                funcD = New FuncionesOfertas
                funcCD = New FuncionesConceptosOfertas
            Case "PROFORMA"
                funcD = New FuncionesProformas
                funcCD = New FuncionesConceptosProformas
            Case "PEDIDO"
                funcD = New FuncionesPedidos
                funcCD = New FuncionesConceptosPedidos
            Case "ALBARAN"
                funcD = New FuncionesAlbaranes
                funcCD = New FuncionesConceptosAlbaranes
            Case "REPARACION", "RESUMEN REPARACIÓN"
                funcD = New FuncionesReparaciones
                funcCD = New FuncionesConceptosReparaciones
            Case "PEDIDO PROVEEDOR"
                funcD = New FuncionesPedidosProv
                'funcCD = New FuncionesConceptosPedidosProv
            Case "ALBARAN PROVEEDOR"
                funcD = New FuncionesAlbaranesProv
                funcCD = New FuncionesConceptosAlbaranesProv
        End Select

        dtsD = funcD.Mostrar1(numDesde)
        If Desde.Contains("PROVEEDOR") Then
            Me.Text = Me.Text & " - " & dtsD.gProveedor
        Else
            Me.Text = Me.Text & " - " & dtsD.gCliente
            ReferenciaCliente.Text = dtsD.gReferenciaCliente 'funcD.ReferenciaCliente(numDesde)
        End If

        If Desde = "PEDIDO" Or Desde = "ALBARAN" Then
            RefCliente2.Text = dtsD.gReferenciaCliente2
        End If
        Select Case Hasta
            Case "OFERTA"
                funcH = New FuncionesOfertas
                funcCH = New FuncionesConceptosOfertas
            Case "PROFORMA"
                funcH = New FuncionesProformas
                funcCH = New FuncionesConceptosProformas
            Case "PEDIDO"
                RefCliente2.Visible = True
                lbRefCliente2.Visible = True
                funcH = New FuncionesPedidos
                funcCH = New FuncionesConceptosPedidos
            Case "ALBARAN"
                RefCliente2.Visible = False 'True
                lbRefCliente2.Visible = False 'True
                funcH = New FuncionesAlbaranes
                funcCH = New FuncionesConceptosAlbaranes
            Case "FACTURA"
                funcH = New FuncionesFacturas
                funcCH = New FuncionesConceptosFacturas
                lbFechaEntrega.Visible = False
                dtpFechaEntrega.Visible = False
            Case "ALBARAN PROVEEDOR"
                funcH = New FuncionesAlbaranesProv
                funcCH = New FuncionesConceptosAlbaranesProv
                lbFechaEntrega.Visible = False
                dtpFechaEntrega.Visible = False
                lbRefCliente.Visible = False
                ReferenciaCliente.Visible = False
                lbRefCliente2.Visible = False
                RefCliente2.Visible = False
                dtpFecha.Visible = False
                lbFecha.Visible = False
                gbNuevo.Visible = False
                gbAgregar.Location = gbNuevo.Location
                gbAgregar.Size = New Size(gbAgregar.Width, gbAgregar.Height + gbNuevo.Height)
            Case "FACTURA PROVEEDOR"
                funcH = New FuncionesFacturasProv
                funcCH = New FuncionesConceptosFacturasProv
                lbRefCliente.Text = "NUM.FACTURA"
                lbRefCliente.Visible = True
                ReferenciaCliente.Visible = True
                lbRefCliente2.Text = "REF.PROVEEDOR"
                lbRefCliente2.Visible = True
                RefCliente2.Visible = True
                lbFechaEntrega.Visible = False
                dtpFechaEntrega.Visible = False
        End Select
        dtpFecha.Value = Now.Date
        dtpFechaEntrega.Value = Now.Date

        Call CargarHastas()

    End Sub

    Private Function PrimeraPalabra(ByVal texto As String) As String
        texto = UCase(Trim(texto))
        If texto.Contains(" ") Then
            Dim i As Integer = Text.IndexOf(" ") + 1
            Return Microsoft.VisualBasic.Left(texto, i)
        Else
            Return texto
        End If
    End Function

#Region "INICIALIZACIÓN"



#End Region

#Region "CARGAR DATOS"


    Private Sub CargarHastas()
        'Cargar los documentos en estado adecuado
        Dim lista As Object
        lvConceptos.Items.Clear()
        Select Case Hasta
            Case "OFERTA"
                lista = funcH.Busqueda(" Bloqueado=0 AND Clientes.idCliente = " & dtsD.gidCliente, " numOferta ASC ", True)
                For Each dtsH As DatosOferta In lista
                    With lvConceptos.Items.Add(dtsH.gnumOferta)
                        .SubItems.Add(dtsH.gReferenciaCliente)
                        .SubItems.Add(dtsH.gFecha)
                        .SubItems.Add(dtsH.gEstado)
                        .SubItems.Add(0)
                    End With
                Next
            Case "PROFORMA"
                lista = funcH.Busqueda(" Bloqueado=0 AND Clientes.idCliente = " & dtsD.gidCliente, " numProforma ASC ", True)
                For Each dtsH As DatosProforma In lista
                    With lvConceptos.Items.Add(dtsH.gnumProforma)
                        .SubItems.Add(dtsH.gReferenciaCliente)
                        .SubItems.Add(dtsH.gFecha)
                        .SubItems.Add(dtsH.gEstado)
                        .SubItems.Add(0)
                    End With
                Next

            Case "PEDIDO"
                lista = funcH.Busqueda(" Bloqueado=0 AND Clientes.idCliente = " & dtsD.gidCliente, " numPedido ASC ", True)
                For Each dtsH As DatosPedido In lista
                    With lvConceptos.Items.Add(dtsH.gnumPedido)
                        .SubItems.Add(dtsH.gReferenciaCliente)
                        .SubItems.Add(dtsH.gFecha)
                        .SubItems.Add(dtsH.gEstado)
                        .SubItems.Add(0)
                    End With
                Next
            Case "ALBARAN"
                lista = funcH.Busqueda(" Bloqueado=0 AND Clientes.idCliente = " & dtsD.gidCliente, " numAlbaran ASC ", True)
                For Each dtsH As DatosAlbaran In lista
                    With lvConceptos.Items.Add(dtsH.gnumAlbaran)
                        .SubItems.Add(dtsH.gReferenciaCliente)
                        .SubItems.Add(dtsH.gFecha)
                        .SubItems.Add(dtsH.gEstado)
                        .SubItems.Add(0)
                    End With
                Next

            Case "ALBARAN PROVEEDOR"
                Try
                    lista = funcH.Busqueda(" Bloqueado=0 AND PR.idProveedor = " & dtsD.gidProveedor, " numAlbaran ASC ")
                    For Each dtsH As DatosAlbaranProv In lista
                        With lvConceptos.Items.Add(dtsH.gnumAlbaran)
                            .SubItems.Add(dtsH.gReferencia)
                            .SubItems.Add(dtsH.gFecha)
                            .SubItems.Add(dtsH.gEstado)
                            .SubItems.Add(dtsH.gidAlbaran)
                        End With
                    Next

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Case "FACTURA"

                lista = funcH.Busqueda(" Bloqueado=0 AND Clientes.idCliente = " & dtsD.gidCliente, " numFactura ASC ", True)
                For Each dtsH As DatosFactura In lista
                    With lvConceptos.Items.Add(dtsH.gnumFactura)
                        .SubItems.Add(dtsH.gReferenciaCliente)
                        .SubItems.Add(dtsH.gFecha)
                        .SubItems.Add(dtsH.gEstado)
                        .SubItems.Add(0)
                    End With
                Next

            Case "FACTURA PROVEEDOR"

                lista = funcH.Busqueda(" Bloqueado=0 AND PR.idProveedor = " & dtsD.gidProveedor, " numFactura ASC ")
                For Each dtsH As DatosFacturaProv In lista
                    With lvConceptos.Items.Add(dtsH.gnumFactura)
                        .SubItems.Add(dtsH.gReferencia)
                        .SubItems.Add(dtsH.gFecha)
                        .SubItems.Add(dtsH.gEstado)
                        .SubItems.Add(dtsH.gidFactura)
                    End With
                Next



            Case Else
                lista = New List(Of Integer)
        End Select


    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub CopiaCabecera(ByVal dtsD As Object, ByRef dtsH As Object)
        dtsH.gidCliente = dtsD.gidCliente
        'dtsH.gReferenciaCliente = dtsD.gReferenciaCliente
        dtsH.gidUbicacion = dtsD.gidUbicacion
        dtsH.gidContacto = dtsD.gidContacto
        dtsH.gcodMoneda = dtsD.gcodMoneda
        dtsH.gidTipoIVA = dtsD.gidTipoIVA
        dtsH.gidTipoRetencion = dtsD.gidTipoRetencion
        dtsH.gRecargoEquivalencia = dtsD.gRecargoEquivalencia
        dtsH.gProntoPago = dtsD.gProntoPago
        dtsH.gSolicitadoVia = dtsD.gSolicitadoVia
        dtsH.gNotas = dtsD.gNotas
        dtsH.gObservaciones = dtsD.gObservaciones
        dtsH.gidPersona = dtsD.gidPersona
        dtsH.gPrecioTransporte = dtsD.gPrecioTransporte
    End Sub

    Private Sub CopiaCabeceraFacturacion(ByVal dtsD As Object, ByRef dtsH As Object)
        dtsH.gidMedioPago = dtsD.gidMedioPago
        dtsH.gidTipoPago = dtsD.gidTipoPago
        dtsH.gidCuentaBanco = dtsD.gidCuentaBanco
        dtsH.gDescuento = dtsD.gDescuento
        dtsH.gDescuento2 = dtsD.gDescuento2
    End Sub

    Private Sub CopiaCabeceraFacturacionCliente(ByVal dtsD As Object, ByRef dtsH As Object)
        Dim dtsFA As datosfacturacion = funcFA.mostrarCli(dtsD.gidCliente)
        dtsH.gidMedioPago = dtsFA.gidMedioPago
        dtsH.gidTipoPago = dtsFA.gidTipoPago
        dtsH.gidCuentaBanco = 0
        dtsH.gDescuento = dtsFA.gDescuento
        dtsH.gDescuento2 = dtsFA.gDescuento2
    End Sub

    Private Sub CopiaCabeceraFacturacionProveedor(ByVal dtsD As Object, ByRef dtsH As Object)
        Dim dtsFA As datosfacturacion = funcFA.mostrarProv(dtsD.gidProveedor)
        dtsH.gidMedioPago = dtsFA.gidMedioPago
        dtsH.gidTipoPago = dtsFA.gidTipoPago
        dtsH.gidCuentaBanco = 0
        dtsH.gProntoPago = dtsFA.gProntoPago
        dtsH.gidTipoIVATransporte = dtsFA.gidTipoIVA
        dtsH.gTipoIVATransporte = dtsFA.gTipoIVA
        dtsH.gTipoRecargoEqTransporte = dtsFA.gTipoRecargoEq
    End Sub

    Private Sub CamposAlbaran(ByVal dtsD As DatosPedido, ByRef dtsH As DatosAlbaran)
        'Campos específicos del albarán que se tomarán del pedido
        dtsH.gidTipoValorado = funcFA.campoidTipoValorado(dtsH.gidCliente) 'Este no lo heredeamos del pedido sino del cliente.
        dtsH.gPortes = dtsD.gPortes 'funcUB.campoPortes(dtsH.gidUbicacion)
        dtsH.gidTransporte = dtsD.gidTransporte 'funcUB.campoidTransporte(dtsH.gidUbicacion)
        dtsH.gTransporte = dtsD.gTransporte 'funcUB.campoTransporte(dtsH.gidUbicacion)
        dtsH.gidProveedor = 0
        'Parámetros introducidos en logística
        Dim dtsPS As DatosParametrosServir = funcPS.Mostrar(dtsD.gnumPedido)
        dtsH.gBultos = dtsPS.gBultos
        dtsH.gKilosBrutos = dtsPS.gKilosBrutos
        dtsH.gKilosNetos = dtsPS.gKilosNetos
        dtsH.gVolumen = dtsPS.gVolumen
        dtsH.gMedidas = dtsPS.gMedidas
    End Sub

    Private Sub CamposPedido(ByVal dtsD As Object, ByVal dtsH As DatosPedido)
        'Campos específicos del pedido que se tomarán de los prefijados para el cliente o de la Oferta o Proforma
        dtsH.gidTipoValorado = funcFA.campoidTipoValorado(dtsH.gidCliente) 'Este no lo heredeamos del pedido sino del cliente.
        dtsH.gPortes = dtsD.gPortes 'funcUB.campoPortes(dtsH.gidUbicacion)
        dtsH.gidTransporte = funcUB.campoidTransporte(dtsH.gidUbicacion)
        dtsH.gTransporte = funcUB.campoTransporte(dtsH.gidUbicacion)
        dtsH.gPrioridad = 3
    End Sub

    Private Sub CopiaConcepto(ByVal dtsD As Object, ByRef dtsH As Object)

        If dtsD.gcodArticuloCli = "" Then
            If dtsD.gidArtCli = 0 Then
                dtsH.gcodArticuloCli = funcAR.codArticulo(dtsD.gidArticulo)

            Else
                dtsH.gcodArticuloCli = dtsD.gcodArticuloCli
            End If
        Else
            dtsH.gcodArticuloCli = dtsD.gcodArticuloCli
        End If
        'If dtsD.gidArticulo = 0 Then dtsH.gcodArticulo = dtsD.gcodArticulo
        dtsH.gcodArticulo = dtsD.gcodArticulo
        dtsH.gArticuloCli = dtsD.gArticuloCli
        dtsH.gRefCliente = dtsD.gRefCliente
        dtsH.gidArticulo = dtsD.gidArticulo
        dtsH.gCantidad = dtsD.gCantidad
        dtsH.gPVPUnitario = dtsD.gPVPUnitario
        dtsH.gidTipoIVA = dtsD.gidTipoIVA
        dtsH.gDescuento = dtsD.gDescuento
        dtsH.gPrecioNetoUnitario = dtsD.gPrecioNetoUnitario
        'dtsH.gOrden = dtsD.gOrden
        'dtsH.gidEstado = dtsD.gidEstado
        dtsH.gidArtCli = dtsD.gidArtCli
    End Sub

    Private Sub CopiaConceptoProv(ByVal dtsD As Object, ByRef dtsH As Object)

        If dtsD.gcodArticuloProv = "" Then
            If dtsD.gidArticuloProv = 0 Then
                dtsH.gcodArticuloProv = funcAR.codArticulo(dtsD.gidArticulo)
            Else
                dtsH.gcodArticuloProv = dtsD.gcodArticuloProv
            End If
        Else
            dtsH.gcodArticuloProv = dtsD.gcodArticuloProv
        End If
        dtsH.gcodArticulo = dtsD.gcodArticulo
        dtsH.gArticuloProv = dtsD.gArticuloProv
        dtsH.gidArticulo = dtsD.gidArticulo
        dtsH.gCantidad = dtsD.gCantidad
        dtsH.gPVPUnitario = dtsD.gPVPUnitario
        dtsH.gidTipoIVA = dtsD.gidTipoIVA
        dtsH.gDescuento = dtsD.gDescuento
        dtsH.gPrecioNetoUnitario = dtsD.gPrecioNetoUnitario
        dtsH.gidArticuloProv = dtsD.gidArticuloProv
    End Sub



    Private Function ActualizarArtCli(ByVal dtsCH As Object, ByVal dtsH As Object) As Long
        'Actualiza la relación Artículo-Cliente con el nuevo documento (si no existe la crea, aunque ese caso no es posible)
        Dim iidArtCli As Long = 0
        If dtsCH.gidArticulo > 0 Then 'Si se trata de una linea manual, no podemos actualizar ArtCli
            Dim dts As DatosArticuloCliente = funcAC.mostrar1(dtsCH.gidArtCli)
            dts.gArticuloCli = dtsCH.gArticuloCli
            dts.gcodArticuloCli = dtsCH.gcodArticuloCli
            dts.gDescuento = dtsCH.gDescuento
            dts.gActivo = True
            dts.gtipoDoc = Hasta
            Select Case Hasta
                Case "PROFORMA"
                    dts.gnumDoc = dtsH.gnumProforma
                Case "PEDIDO"
                    dts.gnumDoc = dtsH.gnumPedido
                Case "ALBARAN"
                    dts.gnumDoc = dtsH.gnumAlbaran
                Case "FACTURA"
                    dts.gnumDoc = dtsH.gnumFactura
            End Select
            If dts.gIdArtCli = 0 Then
                dts.gidArticulo = dtsCH.gidArticulo
                dts.gidCliente = dtsH.gidCliente
                dts.gFechaAlta = Now.Date
                dts.gFechaBaja = Now.Date
                iidArtCli = funcAC.insertar(dts)
            Else
                funcAC.actualizar(dts, True)
                iidArtCli = dts.gIdArtCli
            End If
        End If
        Return iidArtCli

    End Function




    Private Function Femenino(ByVal Doc As String) As Boolean
        Return UCase(Microsoft.VisualBasic.Right(Doc, 1)) = "A"
    End Function


    Private Sub CambiosDesde()

        Dim iidEstado As Integer
        'Cambiar el estado del documento Desde. Depende del flujo en concreto
        Select Case Desde & Hasta
            Case "OFERTAPEDIDO"
                'Cambia los estados de los conceptos del documento original
                iidEstado = funcES.EstadoTraspasado("C." & Desde).gidEstado
                For Each idConcepto As Integer In Conceptos
                    funcCD.cambiarEstado(idConcepto, iidEstado)
                    funcCD.cambiarNum(idConcepto, numHasta, Hasta)
                Next
                'Si todos los conceptos se han traspasado
                If funcCD.TodosTraspasados(numDesde) And Conceptos.Count > 0 Then
                    'Pasamos el documento original al estado traspasado
                    iidEstado = funcES.EstadoTraspasado(Desde).gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                Else
                    iidEstado = funcES.EstadoEnCurso(Desde).gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                End If

                'iidEstado = funcES.EstadoTraspasado(Desde).gidEstado
                'funcD.actualizaEstado(numDesde, iidEstado)
                'For Each dtsCD In listaC
                '    funcCD.CambiarNum(dtsCD.gidConcepto, numHasta, Hasta)
                'Next
            Case "OFERTAPROFORMA"
                'Queda en espera
                iidEstado = funcES.EstadoEnCurso(Desde).gidEstado
                funcD.actualizaEstado(numDesde, iidEstado)
                For Each dtsCD In listaC
                    funcCD.CambiarNum(dtsCD.gidConcepto, numHasta, Hasta)
                Next

            Case "PROFORMAPEDIDO"
                'Cambia los estados de los conceptos del documento original
                iidEstado = funcES.EstadoTraspasado("C." & Desde).gidEstado
                Dim iidEstadoCO As Integer = funcES.EstadoTraspasado("C.OFERTA").gidEstado
                Dim funcCO As New FuncionesConceptosOfertas
                For Each dtsCD As DatosConceptoProforma In listaC
                    funcCD.cambiarEstado(dtsCD.gidConcepto, iidEstado)
                    funcCD.cambiarNum(dtsCD.gidConcepto, numHasta, Hasta)
                    If dtsCD.gidConceptoOferta > 0 Then 'Si afecta a una oferta, también cambiamos el estado
                        funcCO.CambiarEstado(dtsCD.gidConceptoOferta, iidEstadoCO)
                        If funcCO.TodosTraspasados(dtsCD.gnumOferta) Then 'Hemos de verificar la oferta u ofertas afectadas
                            Dim funcOF As New FuncionesOfertas
                            funcOF.actualizaEstado(dtsCD.gnumOferta, funcES.EstadoTraspasado("OFERTA").gidEstado)
                        End If
                    End If
                Next

                'Si todos los conceptos se han traspasado
                If funcCD.TodosTraspasados(numDesde) And Conceptos.Count > 0 Then
                    'Pasamos el documento original al estado traspasado
                    iidEstado = funcES.EstadoTraspasado(Desde).gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                Else
                    iidEstado = funcES.EstadoEnCurso(Desde).gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                End If


            Case "REPARACIONPROFORMA", "REPARACIONPEDIDO", "REPARACIONOFERTA", "RESUMEN REPARACIÓNPROFORMA", "RESUMEN REPARACIÓNPEDIDO", "RESUMEN REPARACIÓNOFERTA"

                iidEstado = funcES.EstadoTraspasado("C.REPARACION").gidEstado

                If Not Conceptos Is Nothing Then
                    For Each idConcepto As Integer In Conceptos
                        funcCD.cambiarEstado(idConcepto, iidEstado)
                        funcCD.cambiarNum(idConcepto, numHasta, Hasta)
                    Next
                End If
                If Desde = "RESUMEN REPARACIÓN" Then
                    iidEstado = funcES.EstadoReparacion("TRASPASADO").gidEstado
                ElseIf funcCD.TodosTraspasados(numDesde) Then
                    iidEstado = funcES.EstadoReparacion("TRASPASADO").gidEstado
                Else
                    iidEstado = funcES.EstadoReparacion("PARCIAL").gidEstado
                End If
                funcD.actualizaEstado(numDesde, iidEstado)

                Select Case Hasta
                    Case "OFERTA"
                        funcD.actualizanumOferta(numDesde, numHasta)
                    Case "PROFORMA"
                        funcD.actualizanumProforma(numDesde, numHasta)
                    Case "PEDIDO"
                        funcD.actualizanumPedido(numDesde, numHasta)

                End Select


            Case "PEDIDOALBARAN"

                'Cambia los estados de los conceptos del documento original
                iidEstado = funcES.EstadoCPedido("SERVIDO").gidEstado
                Dim CantidadServida As Double = 0
                Dim CantidadPreparada As Double = 0
                Dim Cantidad As Double = 0
                Dim inumReparacion As Integer = 0
                Dim funcRE As New FuncionesReparaciones
                Dim funcSTA As New FuncionesEstatusReparacion
                Dim iidEstatusEnviada As Integer = funcSTA.idEstatus("ENVIADA")
                For Each idConcepto As Integer In Conceptos
                    'En el conceptos de pedido, añadimos la cantidad servida
                    CantidadServida = funcCD.CantidadServida(idConcepto)
                    CantidadPreparada = funcCD.CantidadPreparada(idConcepto)
                    Cantidad = funcCD.Cantidad(idConcepto)
                    If CantidadPreparada = 0 Then
                        'Si no habiamos puesto la Cantidad Preparada, habremos servido la totalidad
                        funcCD.CambiarCantidadServida(idConcepto, Cantidad)
                        funcCD.cambiarEstado(idConcepto, iidEstado)
                    Else
                        'Añadimos a lo servido antes si había
                        funcCD.CambiarCantidadServida(idConcepto, CantidadServida + CantidadPreparada)
                        If CantidadServida + CantidadPreparada >= Cantidad Then
                            'Si está todo la linea servida cambiamos el estado
                            funcCD.cambiarEstado(idConcepto, iidEstado)
                        End If
                        'Dejamos a 0 la cantidad preparada porque la hemos servido 
                        funcCD.CambiarCantidadPreparada(idConcepto, 0)
                    End If
                    funcCD.cambiarNum(idConcepto, numHasta, Hasta)
                    'Si el pedido corresponde a una reparación, la damos por ENVIADA
                    inumReparacion = funcCD.numReparacion(numDesde)
                    If inumReparacion > 0 Then
                        funcRE.actualizaEstatus(inumReparacion, iidEstatusEnviada)
                    End If
                Next
                inumReparacion = funcRE.numReparacionPedido(numDesde)
                If inumReparacion > 0 Then
                    funcRE.actualizaEstatus(inumReparacion, iidEstatusEnviada)
                End If
                'Si todos los conceptos se han traspasado
                If funcCD.TodosTraspasados(numDesde) And Conceptos.Count > 0 Then
                    'Pasamos el documento original al estado traspasado
                    If funcCD.AlgunoPARCIAL(numDesde) Then
                        iidEstado = funcES.EstadoPedido("PARCIAL").gidEstado
                    Else
                        iidEstado = funcES.EstadoPedido("SERVIDO").gidEstado
                    End If
                ElseIf Conceptos.Count > 0 AndAlso (funcCD.AlgunoTraspasado(numDesde) Or funcCD.AlgunoParcial(numDesde)) Then
                    'Pasamos el documento original al estado servido parcial
                    iidEstado = funcES.EstadoPedido("PARCIAL").gidEstado
                Else
                    'Si no hay Conceptos o no se ha servido ninguno, queda Pendiente
                    iidEstado = funcES.EstadoPedido("PENDIENTE").gidEstado
                End If
                If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)


            Case "ALBARANFACTURA"
                'Cambia los estados de los conceptos del documento original
                iidEstado = funcES.EstadoTraspasado("C." & Desde).gidEstado
                For Each idConcepto As Integer In Conceptos
                    funcCD.cambiarEstado(idConcepto, iidEstado)
                    funcCD.cambiarNum(idConcepto, numHasta, Hasta)
                Next
                'Si todos los conceptos se han traspasado
                If funcCD.TodosTraspasados(numDesde) And Conceptos.Count > 0 Then
                    iidEstado = funcES.EstadoTraspasado(Desde).gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                Else
                    iidEstado = funcES.EstadoEnCurso(Desde).gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                End If
            Case "ALBARAN PROVEEDORFACTURA PROVEEDOR"
                iidEstado = funcES.EstadoTraspasado("C.ALBARANPROV").gidEstado
                If Not Conceptos Is Nothing Then
                    For Each idConcepto As Integer In Conceptos
                        funcCD.cambiarEstado(idConcepto, iidEstado)
                        funcCD.cambiaridFactura(idConcepto, numHasta)
                    Next
                End If
                If funcCD.TodosTraspasados(numDesde) And Conceptos.Count > 0 Then
                    iidEstado = funcES.EstadoTraspasado("ALBARANPROV").gidEstado
                    If iidEstado > 0 Then funcD.actualizaEstado(numDesde, iidEstado)
                End If

        End Select

    End Sub


    Private Sub CambiosHasta()
        'Cambios en el estado del documento de destino

        ' si el estado es cabecera pasará a En Curso
        If Hasta = "FACTURA PROVEEDOR" Then
            If funcH.idEstado(numHasta) = funcES.EstadoCabecera("FACTURAPROV").gidEstado Then funcH.actualizaEstado(numHasta, funcES.EstadoEspera(Hasta).gidEstado)
        Else
            If funcH.idEstado(numHasta) = funcES.EstadoCabecera(Hasta).gidEstado Then funcH.actualizaEstado(numHasta, funcES.EstadoEnCurso(Hasta).gidEstado)
        End If


    End Sub


    Private Sub CalcularVencimientos(ByRef dtsF As DatosFactura)
        'Calcula los vencimientos y devuelve dtsF por referencia
        If dtsF.gidTipoPago > 0 And dtsF.gidCliente > 0 Then
            Dim fecha As Date = dtpFecha.Value
            Dim dias As Integer = 0
            Dim Vencimiento As Date = dtpFecha.Value
            Dim dtsTP As datosTipoPago = funcTP.mostrar1(dtsF.gidTipoPago)
            Dim dtsFA As datosfacturacion = funcFA.mostrarCli(dtsF.gidCliente)
            'Dim numPagos As Integer = cbTipoPago.SelectedItem.gnumPagos
            If dtsTP.gnumPagos > 0 Then
                Dim importe As Double = dtsF.gTotal / dtsTP.gnumPagos
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
                Dim lista As New List(Of DatosVencimiento)
                Dim dts As DatosVencimiento
                For p = 1 To dtsTP.gnumPagos
                    If p = 1 And dtsTP.gnumPagos > 1 Then
                        dias = dtsTP.gCarencia
                    Else
                        dias = dias + dtsTP.gContadorDias
                    End If
                    Vencimiento = CalculaVencimiento(fecha, dtsFA.gDiaPago1, dtsFA.gDiaPago2, dias, FechaI, FechaF)
                    dts = New DatosVencimiento
                    dts.gnumFactura = dtsF.gnumFactura
                    dts.gVencimiento = Vencimiento
                    dts.gImporte = importe
                    dts.gCobrado = False
                    lista.Add(dts)
                Next
                dtsF.gVencimientos = lista
            End If
        End If
    End Sub



    Private Sub CalcularVencimientosProv(ByRef dtsF As DatosFacturaProv)
        'Calcula los vencimientos y devuelve dtsF por referencia
        If dtsF.gidTipoPago > 0 And dtsF.gidProveedor > 0 Then
            Dim fecha As Date = dtpFecha.Value
            Dim dias As Integer = 0
            Dim Vencimiento As Date = dtpFecha.Value
            Dim dtsTP As datosTipoPago = funcTP.mostrar1(dtsF.gidTipoPago)
            Dim dtsFA As datosfacturacion = funcFA.mostrarProv(dtsF.gidProveedor)
            'Dim numPagos As Integer = cbTipoPago.SelectedItem.gnumPagos
            If dtsTP.gnumPagos > 0 Then
                Dim importe As Double = dtsF.gTotal / dtsTP.gnumPagos
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
                For p = 1 To dtsTP.gnumPagos
                    If p = 1 And dtsTP.gnumPagos > 1 Then
                        dias = dtsTP.gCarencia
                    Else
                        dias = dias + dtsTP.gContadorDias
                    End If
                    Vencimiento = CalculaVencimiento(fecha, dtsFA.gDiaPago1, dtsFA.gDiaPago2, dias, FechaI, FechaF)
                    dts = New DatosVencimientoProv
                    dts.gidFactura = dtsF.gidFactura
                    dts.gnumFactura = dtsF.gnumFactura
                    dts.gVencimiento = Vencimiento
                    dts.gImporte = importe
                    dts.gPagado = False
                    lista.Add(dts)
                Next
                dtsF.gVencimientos = lista
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
        'Devuelve el dia efectivo de pago. Para meses com menos dias que el dia de pago
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

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click

        Dim pregunta As String
        If Desde = "ALBARAN PROVEEDOR" Then
            pregunta = " ¿Traspasar los conceptos del ALBARÁN DE PROVEEDOR a una nueva FACTURA?"
        Else
            pregunta = " ¿Traspasar los conceptos " & If(Femenino(PrimeraPalabra(Desde)), "de la ", "del ") & Desde & " " & numDesde & " a " & If(Femenino(HastaPP), "una nueva ", "un nuevo ") & HastaPP & "?"
        End If

        If MsgBox(pregunta, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Call Nueva()
        End If
    End Sub


    Private Sub Nueva()
        Try
            Dim dtsH As Object
            Dim dtsCD As Object
            Dim dtsCH As Object
            Dim SeguirProceso As Boolean = True
            Dim cargarConceptos As Boolean = True
            Select Case Desde
                Case "OFERTA"
                    listaC = New List(Of DatosConceptoOferta)
                Case "PROFORMA"
                    listaC = New List(Of DatosConceptoProforma)
                Case "PEDIDO"
                    listaC = New List(Of DatosConceptoPedido)
                Case "ALBARAN"
                    listaC = New List(Of DatosConceptoAlbaran)
                Case "REPARACION"
                    listaC = New List(Of DatosConceptoReparacion)
                Case "RESUMEN REPARACIÓN"
                    listaC = New List(Of DatosConceptoReparacion)
                    listaC.add(dtsRR)
                    cargarConceptos = False
                Case "PEDIDO PROVEEDOR"
                    cargarConceptos = False
                Case "ALBARAN PROVEEDOR"
                    listaC = New List(Of DatosConceptoAlbaranProv)
            End Select
            If cargarConceptos Then
                For Each iidConcepto As Integer In Conceptos
                    dtsCD = funcCD.Mostrar1(iidConcepto)
                    listaC.add(dtsCD)
                Next
            End If

            Select Case Hasta
                Case "OFERTA"
                    dtsH = New DatosOferta
                    dtsH.gidEstado = funcES.EstadoEnCurso(Hasta).gidEstado
                    dtsH.gFecha = dtpFecha.Value.Date
                    dtsH.gFechaEntrega = dtpFechaEntrega.Value.Date
                    dtsH.gReferenciaCliente = ReferenciaCliente.Text
                    Call CopiaCabecera(dtsD, dtsH)
                    If Desde = "REPARACION" Or Desde = "RESUMEN REPARACIÓN" Then
                        Call CopiaCabeceraFacturacionCliente(dtsD, dtsH)
                    Else
                        Call CopiaCabeceraFacturacion(dtsD, dtsH)
                    End If

                    dtsH.gPortes = dtsD.gPortes


                    numHasta = funcH.insertar(dtsH)
                    dtsH.gnumOferta = numHasta
                    Dim Orden As Integer = 1
                    Dim idestadoC As Integer = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                    For Each dtsCD In listaC
                        dtsCH = New DatosConceptoOferta
                        CopiaConcepto(dtsCD, dtsCH)
                        dtsCH.gnumOferta = numHasta
                        dtsCH.gnumPedido = 0
                        dtsCH.gnumProforma = 0
                        dtsCH.gnumReparacion = dtsCD.gnumReparacion
                        dtsCH.gOrden = Orden
                        dtsCH.gidEstado = idestadoC

                        dtsCH.gidArtCli = ActualizarArtCli(dtsCH, dtsH)
                        dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                        Orden = Orden + 1
                    Next


                Case "PROFORMA"
                    dtsH = New DatosProforma
                    dtsH.gidEstado = funcES.EstadoEnCurso(Hasta).gidEstado
                    dtsH.gFecha = dtpFecha.Value.Date
                    dtsH.gFechaEntrega = dtpFechaEntrega.Value.Date
                    dtsH.gReferenciaCliente = ReferenciaCliente.Text
                    Call CopiaCabecera(dtsD, dtsH)
                    If Desde = "REPARACION" Or Desde = "RESUMEN REPARACIÓN" Then
                        Call CopiaCabeceraFacturacionCliente(dtsD, dtsH)
                    Else
                        Call CopiaCabeceraFacturacion(dtsD, dtsH)
                    End If

                    dtsH.gPortes = dtsD.gPortes
                    Dim idUbicacion As Integer = funcUB.DireccionFiscal(dtsH.gidCliente, 0)
                    If idUbicacion = 0 Then
                        MsgBox("No se ha encontrado la dirección fiscal del cliente")
                        Me.Close()
                    Else
                        dtsH.gidUbicacion = idUbicacion
                    End If
                    Dim Aviso As String = ""
                    If idUbicacion = 0 Then
                        Aviso = "No se ha encontrado la dirección fiscal del cliente"
                    Else
                        dtsH.gidUbicacion = idUbicacion
                    End If
                    If funcUB.campoidPais(idUbicacion) = 1 Then
                        'Si es una factura a un cliente español, hemos de comprobar que tenga NIF
                        If funcCL.campoNIF(dtsH.gidCliente) = "" Then
                            Aviso = Aviso & vbCrLf & vbCrLf & "El cliente no tiene NIF"
                        End If
                    End If
                    If Aviso = "" Then

                        numHasta = funcH.insertar(dtsH)
                        dtsH.gnumProforma = numHasta
                        Dim Orden As Integer = 1
                        Dim idestadoC As Integer = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                        For Each dtsCD In listaC
                            dtsCH = New DatosConceptoProforma
                            CopiaConcepto(dtsCD, dtsCH)
                            dtsCH.gnumProforma = numHasta
                            dtsCH.gnumPedido = 0
                            dtsCH.gOrden = Orden
                            dtsCH.gidEstado = idestadoC
                            dtsCH.gidConceptoOferta = dtsCD.gidConcepto
                            dtsCH.gidArtCli = ActualizarArtCli(dtsCH, dtsH)
                            dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                            Orden = Orden + 1

                        Next
                    Else
                        MsgBox(Aviso)
                    End If
                Case "PEDIDO"
                    dtsH = New DatosPedido
                    dtsH.gidEstado = funcES.EstadoPedido("PENDIENTE").gidEstado
                    dtsH.gFecha = dtpFecha.Value.Date
                    dtsH.gFechaEntrega = dtpFechaEntrega.Value.Date
                    dtsH.gReferenciaCliente = ReferenciaCliente.Text
                    dtsH.gReferenciaCliente2 = RefCliente2.Text
                    Call CopiaCabecera(dtsD, dtsH)
                    If Desde = "REPARACION" Or Desde = "RESUMEN REPARACIÓN" Then
                        Call CopiaCabeceraFacturacionCliente(dtsD, dtsH)
                    Else
                        Call CopiaCabeceraFacturacion(dtsD, dtsH)
                    End If
                    Call CamposPedido(dtsD, dtsH)
                    numHasta = funcH.insertar(dtsH)
                    dtsH.gnumPedido = numHasta
                    Dim Orden As Integer = 1
                    Dim idestadoC As Integer = funcES.EstadoCPedido("CREADO").gidEstado  'Estado activo del concepto de lo que sea
                    For Each dtsCD In listaC
                        dtsCH = New DatosConceptoPedido
                        CopiaConcepto(dtsCD, dtsCH)
                        dtsCH.gnumPedido = numHasta
                        dtsCH.gOrden = Orden
                        dtsCH.gidEstado = idestadoC
                        dtsCH.gnumOferta = 0
                        dtsCH.gnumProforma = 0
                        dtsCH.gVersion = VersionArticulo(dtsCD.gidArticulo)
                        If Desde = "OFERTA" Then  'Un pedi
                            dtsCH.gidConceptoOferta = dtsCD.gidConcepto
                            dtsCH.gidConceptoProforma = 0
                        End If
                        If Desde = "PROFORMA" Then
                            dtsCH.gidConceptoOferta = 0
                            dtsCH.gidConceptoProforma = dtsCD.gidConcepto
                        End If
                        dtsCH.gCantidadServida = 0
                        dtsCH.gidArtCli = ActualizarArtCli(dtsCH, dtsH)
                        dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                        Orden = Orden + 1
                    Next
                Case "ALBARAN"
                    dtsH = New DatosAlbaran
                    dtsH.gidEstado = funcES.EstadoEnCurso(Hasta).gidEstado
                    dtsH.gFecha = dtpFecha.Value.Date
                    dtsH.gFechaEntrega = dtpFechaEntrega.Value.Date
                    dtsH.gReferenciaCliente = ReferenciaCliente.Text
                    dtsH.gReferenciaCliente2 = "" 'RefCliente2.Text
                    Call CopiaCabecera(dtsD, dtsH)
                    Call CopiaCabeceraFacturacion(dtsD, dtsH)
                    Call CamposAlbaran(dtsD, dtsH)
                    numHasta = funcH.insertar(dtsH)
                    funcPS.borrar(dtsD.gnumPedido)
                    dtsH.gnumAlbaran = numHasta
                    Dim Orden As Integer = 1
                    Dim idestadoC As Integer = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                    Dim avisoPreparado As Boolean = False
                    For Each dtsCD In listaC
                        dtsCH = New DatosConceptoAlbaran
                        CopiaConcepto(dtsCD, dtsCH)
                        If dtsCD.gCantidadPreparada = 0 Then
                            'Si no indica cantidadPreparada servimos todo lo no servido ya
                            avisoPreparado = True
                            dtsCH.gCantidad = dtsCD.gCantidad - dtsCD.gCantidadServida
                        Else
                            'Si tenemos la CantidadPreparada, la ponemos como cantidad en el albarán
                            dtsCH.gCantidad = dtsCD.gCantidadPreparada
                        End If
                        dtsCH.gnumAlbaran = numHasta
                        dtsCH.gOrden = Orden
                        dtsCH.gidEstado = idestadoC
                        dtsCH.gidConceptoPedido = dtsCD.gidConcepto
                        dtsCH.gnumFactura = 0
                        dtsCH.gnumsSerie = ""
                        dtsCH.gidArtCli = ActualizarArtCli(dtsCH, dtsH)
                        dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                        If funcAR.conNumSerie(dtsCH.gidArticulo) Then
                            If funcEQ.AsignarAlbaranPedido(dtsCD.gidConcepto, dtsCH.gidConcepto) Then   'Asignamos los equipos al concepto del albarán
                                dtsCH.gnumsSerie = funcEQ.numsSerieAlbaran(dtsCH.gidConcepto) 'Obtenemos el literal con los números de serie
                            End If
                        End If
                        dtsCH.gidConceptoPedidoProv = 0

                        funcCH.CambiarNumsSerie(dtsCH.gidConcepto, dtsCH.gnumsSerie) 'Cargamos el literal en el concepto de albarán
                        'Ahora descontamos del stock las cantidades servidas
                        If dtsCH.gidArticulo > 0 Then
                            Dim dtsST As New DatosStock
                            dtsST.gidStock = 0
                            dtsST.gidArticulo = dtsCH.gidArticulo
                            dtsST.gidAlmacen = 0
                            dtsST.gCantidad = -dtsCH.gCantidad
                            dtsST.gidUnidad = funcAR.idTipoUnidad(dtsCH.gidArticulo)
                            dtsST.gidLote = 0
                            dtsST.gidArticuloProv = 0
                            dtsST.gFecha = Now
                            dtsST.gPrecio = dtsCH.gPrecioNetoUnitario
                            dtsST.gcodMoneda = dtsH.gcodMoneda
                            dtsST.gidConceptoProv = 0
                            dtsST.gidConceptoPedido = 0
                            dtsST.gidConceptoAlbaran = dtsCH.gidConcepto
                            dtsST.gidProduccion = 0
                            dtsST.gMovimiento = ""
                            dtsST.gidPersona1 = Inicio.vIdUsuario
                            dtsST.gidPersona2 = 0
                            funcST.insertar(dtsST)
                        End If
                        Orden = Orden + 1
                    Next

                Case "FACTURA"

                    dtsH = New DatosFactura
                    dtsH.gidEstado = funcES.EstadoFactura("PENDIENTE").gidEstado  'Queda a la espera de cobrar
                    dtsH.gFecha = dtpFecha.Value.Date
                    dtsH.gFechaEntrega = dtpFechaEntrega.Value.Date
                    dtsH.gReferenciaCliente = ReferenciaCliente.Text
                    'Datos de liquidación de comisión, solo se añaden al insertar
                    dtsH.gLiquidadaComision = False
                    dtsH.gFechaLiquidacion = Now.Date
                    Call CopiaCabecera(dtsD, dtsH)
                    Dim NotasRTF As New RichTextBox
                    NotasRTF.Text = dtsD.gNotas
                    dtsH.gNotas = NotasRTF.Rtf
                    Call CopiaCabeceraFacturacion(dtsD, dtsH)
                    dtsH.gTipoIVAFac = dtsD.gtipoIVA
                    dtsH.gTipoRecargoEqFac = dtsD.gTipoRecargoEq
                    dtsH.gTipoRetencionFac = dtsD.gTipoRetencion
                    Dim idUbicacion As Integer = funcUB.DireccionFiscal(dtsH.gidCliente, 0)
                    Dim Aviso As String = ""
                    If idUbicacion = 0 Then
                        Aviso = "No se ha encontrado la dirección fiscal del cliente"
                    Else
                        dtsH.gidUbicacion = idUbicacion
                    End If
                    Dim iidPais As Integer = funcUB.campoidPais(idUbicacion)
                    Dim sNIF = funcCL.campoNIF(dtsH.gidCliente)
                    If iidPais = 1 Then
                        'Si es una factura a un cliente español, hemos de comprobar que tenga NIF
                        If ValidateCif(sNIF) Or ValidateNif(sNIF) Then
                        Else
                            Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "NIF no válido."
                        End If
                    ElseIf funcPA.NIFObligatorio(iidPais) Then
                        'Comprobamos que haya algo en el NIF si el pais tiene marcado obligatorio NIF.
                        If sNIF = "" Then
                            Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "No se ha especificado el NIF obligatorio."
                        End If

                    End If
                    If dtsH.gidTipoPago = 0 Then
                        Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "No se ha indicado el Tipo de Pago"
                    End If
                    If dtsH.gidMedioPago = 0 Then
                        Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "No se ha indicado el Medio de Pago"
                    End If
                    If Aviso = "" Then
                        Dim PorcentajeComision As Double = funcCM.Porcentaje(dtsH.gidCliente, dtsH.gidPersona)
                        numHasta = funcH.insertar(dtsH)
                        dtsH.gnumFactura = numHasta
                        Dim Orden As Integer = 1
                        Dim idestadoC As Integer = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                        For Each dtsCD In listaC
                            dtsCH = New DatosConceptoFactura
                            CopiaConcepto(dtsCD, dtsCH)
                            dtsCH.gnumFactura = numHasta
                            dtsCH.gOrden = Orden
                            dtsCH.gidEstado = idestadoC
                            dtsCH.gidConceptoAlbaran = dtsCD.gidConcepto
                            dtsCH.gnumsSerie = dtsCD.gnumsSerie
                            dtsCH.gnumAbono = 0
                            dtsCH.gTipoIVAFac = dtsH.gTipoIVAFac
                            dtsCH.gTipoRecargoEqFac = dtsH.gTipoRecargoEqFac
                            dtsCH.gidArtCli = ActualizarArtCli(dtsCH, dtsH)
                            dtsCH.gPorcentajeComision = PorcentajeComision
                            dtsCH.gImporteComision = dtsCH.gCantidad * dtsCH.gPrecioNetoUnitario * dtsCH.gPorcentajeComision / 100

                            dtsCH.gidConcepto = funcCH.insertar(dtsCH)

                            Orden = Orden + 1
                        Next
                        funcH.DatosCalculados(dtsH)
                        Call CalcularVencimientos(dtsH)
                        funcH.actualizar(dtsH)
                    ElseIf MsgBox(Aviso & vbCrLf & vbCrLf & " ¿Abrir la ficha del cliente? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Dim GG As New GestionClientes
                        GG.pidCliente = dtsH.gidCliente
                        GG.SoloLectura = vSoloLectura
                        GG.pAbrirTab = 2 'Pestaña DATOS FACTURACIÓN
                        GG.ShowDialog()
                        Call Nueva()
                        SeguirProceso = False
                    Else
                        Me.Close()
                    End If
                Case "ALBARAN PROVEEDOR"
                    numHasta = 0

                    Call MostrarDocumentoCreado()
                Case "FACTURA PROVEEDOR"
                    Dim ep1 As New ErrorProvider
                    ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
                    ep1.SetIconAlignment(ReferenciaCliente, ErrorIconAlignment.MiddleLeft)
                    Dim validar As Boolean = True
                    If ReferenciaCliente.Text = "" Then
                        validar = False

                        ep1.SetError(ReferenciaCliente, "Se ha de especificar el número de factura del proveedor")
                    Else
                        If validar Then
                            Dim funcFP As New FuncionesFacturasProv
                            If funcFP.ExisteFactura(ReferenciaCliente.Text, dtsD.gidProveedor, 0) Then
                                validar = False
                                ep1.SetError(ReferenciaCliente, "Número de factura ya utilizado")
                            End If
                        End If
                    End If
                    If validar Then

                        dtsH = New DatosFacturaProv
                        dtsH.gidEstado = funcES.EstadoFacturaProv("PENDIENTE").gidEstado  'Queda a la espera de cobrar
                        dtsH.gFecha = dtpFecha.Value.Date
                        dtsH.gReferencia = RefCliente2.Text
                        'Call CopiaCabecera(dtsD, dtsH)
                        dtsH.gidProveedor = dtsD.gidProveedor
                        dtsH.gidUbicacion = dtsD.gidUbicacion
                        dtsH.gnumFactura = ReferenciaCliente.Text
                        dtsH.gObservaciones = dtsD.gObservaciones
                        dtsH.gNotas = dtsD.gNotas
                        dtsH.gidContacto = dtsD.gidContacto

                        dtsH.gcodMoneda = dtsD.gcodMoneda

                        dtsH.gidTipoRetencion = dtsD.gidTipoRetencion
                        dtsH.gRecargoEquivalencia = dtsD.gRecargoEquivalencia
                        dtsH.gProntoPago = dtsD.gProntoPago
                        dtsH.gSolicitadoVia = dtsD.gSolicitadoVia
                        dtsH.gidPersona = dtsD.gidPersona
                        dtsH.gPrecioTransporte = dtsD.gPrecioTransporte
                        dtsH.gcodFactura = ""

                        Call CopiaCabeceraFacturacionProveedor(dtsD, dtsH)
                        dtsH.gTipoRetencionFac = dtsD.gTipoRetencion

                        Dim idUbicacion As Integer = funcUB.DireccionFiscal(0, dtsH.gidProveedor)
                        Dim Aviso As String = ""

                        If idUbicacion = 0 Then
                            Aviso = "No se ha encontrado la dirección fiscal del proveedor"
                            validar = False
                        Else
                            dtsH.gidUbicacion = idUbicacion
                        End If

                        Dim iidPais As Integer = funcUB.campoidPais(idUbicacion)
                        Dim sNIF = funcPR.campoNIF(dtsH.gidProveedor)
                        If iidPais = 1 Then
                            'Si es una factura de un proveedor español, hemos de comprobar que tenga NIF
                            If ValidateCif(sNIF) Or ValidateNif(sNIF) Then
                            Else
                                Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "NIF no válido."
                            End If
                        ElseIf funcPA.NIFObligatorio(iidPais) Then
                            'Comprobamos que haya algo en el NIF si el pais tiene marcado obligatorio NIF.
                            If sNIF = "" Then
                                Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "No se ha especificado el NIF obligatorio."
                                validar = False
                            End If

                        End If
                        If dtsH.gidTipoPago = 0 Then
                            Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "No se ha indicado el Tipo de Pago"
                            validar = False
                        End If
                        If dtsH.gidMedioPago = 0 Then
                            Aviso = If(Aviso = "", "", Aviso & vbCrLf & vbCrLf) & "No se ha indicado el Medio de Pago"
                            validar = False
                        End If

                        If validar Then ' Aviso = "" Then
                            If Aviso <> "" Then
                                If MsgBox(Aviso & vbCrLf & "¿Continuar la conversión?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                                    validar = False
                                    SeguirProceso = False
                                End If

                            End If
                            If validar Then
                                numHasta = funcH.insertar(dtsH)
                                dtsH.gidFactura = numHasta
                                Dim Orden As Integer = 1
                                Dim idestadoC As Integer = funcES.EstadoEspera("C.FACTURAPROV").gidEstado  'Estado activo del concepto de lo que sea
                                For Each dtsCD In listaC
                                    dtsCH = New DatosConceptoFacturaProv
                                    CopiaConceptoProv(dtsCD, dtsCH)
                                    dtsCH.gidFactura = numHasta
                                    dtsCH.gOrden = Orden
                                    dtsCH.gidEstado = idestadoC
                                    dtsCH.gidconceptoAlbaranProv = dtsCD.gidConcepto
                                    dtsCH.gObservaciones = dtsCD.gObservaciones
                                    dtsCH.gTipoIVAFac = funcTI.TipoIVA(dtsCD.gidTipoIVA)
                                    If dtsH.gRecargoEquivalencia Then
                                        dtsCH.gTipoRecargoEqFac = funcTI.TipoRecargoEq(dtsCD.gidtipoIVA)
                                    Else
                                        dtsCH.gTipoRecargoEqFac = 0
                                    End If

                                    dtsCH.gidArticuloProv = dtsCD.gidArticuloProv
                                    dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                    Orden = Orden + 1
                                Next
                                funcH.DatosCalculados(dtsH)
                                Call CalcularVencimientosProv(dtsH)
                                funcH.actualizar(dtsH)
                            End If

                        ElseIf MsgBox(Aviso & vbCrLf & vbCrLf & " ¿Abrir la ficha del proveedor? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                            Dim GG As New GestionProveedores
                            GG.pidProveedor = dtsH.gidProveedor
                            GG.SoloLectura = vSoloLectura
                            GG.pAbrirTab = 2 'Pestaña DATOS FACTURACIÓN
                            GG.ShowDialog()
                            Call Nueva()
                            SeguirProceso = False
                        Else
                            Me.Close()
                        End If
                    End If
                    ep1.Clear()
            End Select
            If SeguirProceso And numHasta > 0 Then
                Call CambiosDesde()
                If Hasta = "FACTURA PROVEEDOR" Then
                    MsgBox("NUEVA FACTURA PROVEEDOR CREADA CON EL NÚMERO " & ReferenciaCliente.Text)
                Else
                    MsgBox(If(Femenino(HastaPP), "NUEVA ", "NUEVO ") & Hasta & If(Femenino(HastaPP), " CREADA ", " CREADO ") & " CON EL NÚMERO " & numHasta)
                End If

                Call MostrarDocumentoCreado()
                bNuevo.Enabled = False
                bAnadir.Enabled = False
            End If
        Catch ex As Exception
            ex.Data.Add("DESDE", Desde)
            ex.Data.Add("numDesde", numDesde)
            ex.Data.Add("HASTA", Hasta)
            ex.Data.Add("numHasta", numHasta)
            CorreoError(ex)
        End Try

    End Sub

    Private Function VersionArticulo(ByVal iidArticulo) As Integer
        If iidArticulo > 0 Then
            If funcAR.conVersiones(iidArticulo) Then
                Dim iidArticuloBase As Integer = funcEC.idArticuloBaseArticulo(iidArticulo)
                Dim lista As List(Of Integer)
                If iidArticuloBase > 0 Then
                    lista = funcAR.Versiones(iidArticuloBase)
                Else
                    lista = funcAR.Versiones(iidArticulo)
                End If
                If lista.Count = 0 Then
                    Return 0
                Else
                    Return lista.Max
                End If
            Else
                Return 0
            End If
        End If
    End Function



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAnadir.Click
        Try
            Dim validar As Boolean = True
            Dim contador As Integer = 0

            Select Case Desde
                Case "OFERTA", "PROFORMA", "PEDIDO", "ALBARAN", "REPARACION", "ALBARAN PROVEEDOR"
                    If Conceptos.Count = 0 Then
                        validar = False
                        MsgBox("No se han seleccionado conceptos para convertir")
                    End If
                Case "RESUMEN REPARACIÓN"
                    If dtsRR Is Nothing Then
                        validar = False
                        MsgBox("No se ha cargado el resumen para convertir")
                    End If
                Case "PEDIDO PROVEEDOR"

            End Select

            If lvConceptos.SelectedItems.Count = 0 Then
                validar = False
                MsgBox("No se ha seleccionado " & If(Femenino(HastaPP), " una ", " un ") & HastaPP & " para agregar los conceptos")

            End If
            If validar Then
                numHasta = lvConceptos.SelectedItems(0).Text

                Dim pregunta As String = " ¿Añadir los conceptos " & If(Femenino(PrimeraPalabra(Desde)), "de la ", "del ") & Desde & " " & numDesde & vbCrLf & If(Femenino(HastaPP), " a la ", " al ") & HastaPP & " " & numHasta & "?"
                If MsgBox(pregunta, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    Dim dtsCD As Object
                    Dim dtsCH As Object
                    Select Case Desde
                        Case "OFERTA"
                            listaC = New List(Of DatosConceptoOferta)
                        Case "PROFORMA"
                            listaC = New List(Of DatosConceptoProforma)
                        Case "PEDIDO"
                            listaC = New List(Of DatosConceptoPedido)
                        Case "ALBARAN"
                            listaC = New List(Of DatosConceptoAlbaran)
                        Case "REPARACION"
                            listaC = New List(Of DatosConceptoReparacion)
                        Case "RESUMEN REPARACIÓN"
                            listaC = New List(Of DatosConceptoReparacion)
                            listaC.add(dtsRR)
                        Case "ALBARAN PROVEEDOR"
                            listaC = New List(Of DatosConceptoAlbaranProv)
                            numHasta = lvConceptos.SelectedItems(0).SubItems(4).Text
                    End Select
                    Select Case Desde
                        Case "OFERTA", "PROFORMA", "PEDIDO", "ALBARAN", "REPARACION", "ALBARAN PROVEEDOR"
                            For Each iidConcepto As Integer In Conceptos
                                dtsCD = funcCD.Mostrar1(iidConcepto)
                                listaC.add(dtsCD)
                            Next
                        Case "RESUMEN REPARACIÓN"

                        Case "PEDIDO PROVEEDOR"

                    End Select

                    Select Case Hasta
                        Case "OFERTA"
                            dtsCH = New DatosConceptoOferta
                            Dim Orden As Integer = funcCH.UltimoOrden(numHasta) + 1
                            For Each dtsCD In listaC
                                CopiaConcepto(dtsCD, dtsCH)
                                dtsCH.gnumOferta = numHasta
                                dtsCH.gnumProforma = 0
                                dtsCH.gnumReparacion = dtsCD.gnumReparacion

                                dtsCH.gOrden = Orden
                                dtsCH.gidEstado = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea

                                dtsCH.gidArtCli = ActualizarArtCli(dtsCH, funcH.Mostrar1(numHasta))
                                dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                Orden = Orden + 1
                                If dtsCH.gidConcepto > 0 Then contador = contador + 1
                            Next

                        Case "PROFORMA"
                            dtsCH = New DatosConceptoProforma
                            Dim Orden As Integer = funcCH.UltimoOrden(numHasta) + 1
                            For Each dtsCD In listaC
                                CopiaConcepto(dtsCD, dtsCH)
                                dtsCH.gnumProforma = numHasta
                                dtsCH.gOrden = Orden
                                'dtsCH.gidEstado = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                                dtsCH.gidConceptoOferta = dtsCD.gidConcepto
                                dtsCH.gidArtCli = ActualizarArtCli(dtsCH, funcH.Mostrar1(numHasta))
                                dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                Orden = Orden + 1
                                If dtsCH.gidConcepto > 0 Then contador = contador + 1
                            Next
                        Case "PEDIDO"
                            dtsCH = New DatosConceptoPedido
                            Dim Orden As Integer = funcCH.UltimoOrden(numHasta) + 1
                            For Each dtsCD In listaC
                                CopiaConcepto(dtsCD, dtsCH)
                                dtsCH.gnumPedido = numHasta
                                dtsCH.gOrden = Orden
                                dtsCH.gidEstado = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                                dtsCH.gVersion = VersionArticulo(dtsCD.gidArticulo)
                                If Desde = "OFERTA" Then
                                    dtsCH.gidConceptoOferta = dtsCD.gidConcepto
                                    dtsCH.gidConceptoProforma = 0
                                End If
                                If Desde = "PROFORMA" Then
                                    dtsCH.gidConceptoOferta = 0
                                    dtsCH.gidConceptoProforma = dtsCD.gidConcepto
                                End If
                                dtsCH.gidArtCli = ActualizarArtCli(dtsCH, funcH.Mostrar1(numHasta))
                                dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                Orden = Orden + 1
                                If dtsCH.gidConcepto > 0 Then contador = contador + 1
                            Next
                        Case "ALBARAN"
                            dtsCH = New DatosConceptoAlbaran
                            Dim Orden As Integer = funcCH.UltimoOrden(numHasta) + 1
                            For Each dtsCD In listaC
                                CopiaConcepto(dtsCD, dtsCH)
                                If dtsCD.gCantidadPreparada > 0 Then
                                    'Si tenemos la CantidadPreparada, la ponemos como cantidad en el albarán
                                    dtsCH.gCantidad = dtsCD.gCantidadPreparada
                                End If
                                dtsCH.gnumAlbaran = numHasta
                                dtsCH.gOrden = Orden
                                dtsCH.gidEstado = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                                dtsCH.gidConceptoPedido = dtsCD.gidConcepto
                                dtsCH.gidArtCli = ActualizarArtCli(dtsCH, funcH.Mostrar1(numHasta))
                                dtsCH.gnumsSerie = ""
                                dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                funcEQ.AsignarAlbaranPedido(dtsCD.gidConcepto, dtsCH.gidConcepto) 'Asignamos los equipos al concepto del albarán
                                If funcAR.conNumSerie(dtsCH.gidArticulo) Then
                                    dtsCH.gnumsSerie = funcEQ.numsSerieAlbaran(dtsCH.gidConcepto) 'Obtenemos el literal con los números de serie
                                Else
                                    dtsCH.gnumsSerie = ""
                                End If
                                funcCH.CambiarNumsSerie(dtsCH.gidConcepto, dtsCH.gnumsSerie) 'Cargamos el literal en el concepto de albarán
                                'Ahora descontamos del stock las cantidades servidas
                                Dim dtsST As New DatosStock
                                dtsST.gidStock = 0
                                dtsST.gidArticulo = dtsCH.gidArticulo
                                dtsST.gidAlmacen = 0
                                dtsST.gCantidad = -dtsCH.gCantidad
                                dtsST.gidUnidad = funcAR.idTipoUnidad(dtsCH.gidArticulo)
                                dtsST.gidLote = 0
                                dtsST.gidArticuloProv = 0
                                dtsST.gFecha = Now
                                dtsST.gPrecio = dtsCH.gPrecioNetoUnitario
                                dtsST.gcodMoneda = dtsD.gcodMoneda
                                dtsST.gidConceptoProv = 0
                                dtsST.gidConceptoPedido = 0
                                dtsST.gidConceptoAlbaran = dtsCH.gidConcepto
                                dtsST.gidProduccion = 0
                                dtsST.gMovimiento = ""
                                dtsST.gidPersona1 = Inicio.vIdUsuario
                                dtsST.gidPersona2 = 0
                                funcST.insertar(dtsST)
                                Orden = Orden + 1
                                If dtsCH.gidConcepto > 0 Then contador = contador + 1
                            Next

                        Case "FACTURA"
                            'En la factura los tipos de iva, recEq y Retención se guardan con su valor
                            Dim dtsF As DatosFactura = funcH.mostrar1(numHasta)
                            Dim PorcentajeComision As Double = funcCM.Porcentaje(dtsF.gidCliente, dtsF.gidPersona)
                            dtsCH = New DatosConceptoFactura
                            Dim Orden As Integer = funcCH.UltimoOrden(numHasta) + 1
                            For Each dtsCD In listaC
                                CopiaConcepto(dtsCD, dtsCH)
                                dtsCH.gnumFactura = numHasta
                                dtsCH.gOrden = Orden
                                dtsCH.gidEstado = funcES.EstadoEspera("C." & Hasta).gidEstado  'Estado activo del concepto de lo que sea
                                dtsCH.gidConceptoAlbaran = dtsCD.gidConcepto
                                dtsCH.gnumsSerie = dtsCD.gnumsSerie
                                dtsCH.gidArtCli = ActualizarArtCli(dtsCH, funcH.Mostrar1(numHasta))
                                dtsCH.gtipoIVA = dtsF.gTipoIVA
                                dtsCH.gTipoIVAFac = dtsF.gTipoIVAFac
                                dtsCH.gTipoRecargoEqFac = dtsF.gTipoRecargoEqFac
                                dtsCH.gtipoRecargoEq = dtsF.gTipoRecargoEq
                                dtsCH.gPorcentajeComision = PorcentajeComision
                                dtsCH.gImporteComision = dtsCH.gCantidad * dtsCH.gPrecioNetoUnitario * dtsCH.gPorcentajeComision / 100
                                dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                Orden = Orden + 1
                                If dtsCH.gidConcepto > 0 Then contador = contador + 1
                            Next
                            funcH.DatosCalculados(dtsF)
                            Call CalcularVencimientos(dtsF)
                            funcH.actualizar(dtsF)
                        Case "ALBARAN PROVEEDOR"
                            numHasta = lvConceptos.SelectedItems(0).SubItems(4).Text
                            Call MostrarDocumentoCreado()

                        Case "FACTURA PROVEEDOR"
                            Dim dtsF As DatosFacturaProv = funcH.mostrar1(numHasta)
                            Dim Orden As Integer = funcCH.UltimoOrden(numHasta) + 1
                            Dim idestadoC As Integer = funcES.EstadoEspera("C.FACTURAPROV").gidEstado  'Estado activo del concepto de lo que sea
                            For Each dtsCD In listaC
                                dtsCH = New DatosConceptoFacturaProv
                                CopiaConceptoProv(dtsCD, dtsCH)
                                dtsCH.gidFactura = numHasta
                                dtsCH.gOrden = Orden
                                dtsCH.gidEstado = idestadoC
                                dtsCH.gidconceptoAlbaranProv = dtsCD.gidConcepto
                                dtsCH.gObservaciones = dtsCD.gObservaciones
                                dtsCH.gTipoIVAFac = funcTI.TipoIVA(dtsCD.gidTipoIVA)
                                If dtsF.gRecargoEquivalencia Then
                                    dtsCH.gTipoRecargoEqFac = funcTI.TipoRecargoEq(dtsCD.gidtipoIVA)
                                Else
                                    dtsCH.gTipoRecargoEqFac = 0
                                End If

                                dtsCH.gidArticuloProv = dtsCD.gidArticuloProv
                                dtsCH.gidConcepto = funcCH.insertar(dtsCH)
                                Orden = Orden + 1
                                If dtsCH.gidConcepto > 0 Then contador = contador + 1
                            Next
                            funcH.DatosCalculados(dtsF)
                            Call CalcularVencimientosProv(dtsF)

                    End Select
                    If contador > 0 Then
                        Call CambiosDesde()
                        Call CambiosHasta()
                        MsgBox("Añadidos " & contador & " Conceptos " & If(Femenino(HastaPP), "a la ", "al ") & HastaPP & " " & numHasta)
                        Call MostrarDocumentoCreado()
                        bNuevo.Enabled = False
                        bAnadir.Enabled = False
                    End If

                End If

            End If
        Catch ex As Exception
            ex.Data.Add("DESDE", Desde)
            ex.Data.Add("numDesde", numDesde)
            ex.Data.Add("HASTA", Hasta)
            ex.Data.Add("numHasta", numHasta)
            CorreoError(ex)
        End Try
    End Sub


    Private Sub MostrarDocumentoCreado()
        Select Case Hasta
            Case "OFERTA"
                Dim GG As New GestionOferta
                GG.SoloLectura = vSoloLectura
                GG.pLocation = New Point(localizacion.X + 15, localizacion.Y + 15)
                GG.pnumOferta = numHasta
                GG.ShowDialog()
            Case "PROFORMA"
                Dim GG As New GestionProforma
                GG.SoloLectura = vSoloLectura
                GG.pLocation = New Point(localizacion.X + 15, localizacion.Y + 15)
                GG.pnumProforma = numHasta
                GG.ShowDialog()
            Case "PEDIDO"
                Dim GG As New GestionPedido
                GG.SoloLectura = vSoloLectura
                GG.pLocation = New Point(localizacion.X + 15, localizacion.Y + 15)
                GG.pnumPedido = numHasta
                GG.ShowDialog()
            Case "ALBARAN"
                Dim GG As New GestionAlbaran
                GG.SoloLectura = vSoloLectura
                GG.pLocation = New Point(localizacion.X + 15, localizacion.Y + 15)
                GG.pnumAlbaran = numHasta
                GG.ShowDialog()
            Case "FACTURA"
                Dim GG As New GestionFactura1
                GG.SoloLectura = vSoloLectura
                GG.pLocation = New Point(localizacion.X + 15, localizacion.Y + 15)
                GG.pnumFactura = numHasta
                GG.ShowDialog()
            Case "ALBARAN PROVEEDOR"
                Dim sconceptos As String = ""

                If ListaConceptosPedidosProv.Count Then

                    For Each item In ListaConceptosPedidosProv

                        If sconceptos = "" Then

                            sconceptos = item

                        Else

                            sconceptos = sconceptos & "," & item

                        End If

                    Next

                    sconceptos = " and CP.idConcepto in (" & sconceptos & ")"

                End If
                Dim GG As New GestionAlbaranDeProv
                GG.SoloLectura = vSoloLectura
                GG.pnumPedido = dtsD.gnumPedido
                GG.pidAlbaran = numHasta
                GG.sconceptos = sconceptos
                GG.ShowDialog()
            Case "FACTURA PROVEEDOR"
                Dim GG As New GestionFacturaProv
                GG.SoloLectura = vSoloLectura
                GG.pidFactura = numHasta
                GG.ShowDialog()

        End Select
        Me.Close()
    End Sub


#End Region


#Region "EVENTOS"



#End Region

End Class