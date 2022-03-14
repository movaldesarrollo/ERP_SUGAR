Public Class RecepcionPedidoProv1

    Dim funcP As New funcionesProveedores
    Dim funcPP As New FuncionesPedidosProv
    Dim funcCP As New FuncionesConceptosPedidosProv
    Dim funcM As New FuncionesMoneda
    Dim funcUM As New FuncionesTiposUnidad
    Dim funcUB As New funcionesUbicaciones
    Dim funcTC As New FuncionesTipoCompra
    Dim funcST As New FuncionesStock
    Dim funcCI As New FuncionesConceptosPedidosInternos
    Private funcAP As New FuncionesAlbaranesProv
    Private funcAL As New FuncionesAlmacenes
    Private funcES As New FuncionesEstados
    Private funcCA As New FuncionesConceptosAlbaranesProv
    Dim iidConcepto As Integer
    Dim indice As Integer
    Dim vSoloLectura As Boolean
    Dim semaforo As Boolean
    Dim estadoInicial As DatosEstado
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
    Private estadoAlbaranProvRecibido As DatosEstado
    Private estadoCEspera As DatosEstado
    Private estadoCARecibido As DatosEstado
    Private nuevoEstado As Integer
    Private dtsPP As DatosPedidoProv
    Private cambios As Boolean
    Private Resultado As Boolean
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private iidProveedor As Integer
    Private dtsAP As New DatosAlbaranProv
    Private listaCP As List(Of DatosConceptoPedidoProv)
    Private scodMoneda As String
    Private VerDetalle As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Property pnumPedido() As Integer
        Get
            Return numPedido.Text
        End Get
        Set(ByVal value As Integer)
            numPedido.Text = value
        End Set
    End Property

    Property pOK() As Boolean
        Get
            Return Resultado
        End Get
        Set(ByVal value As Boolean)
            Resultado = value
        End Set
    End Property

    Private Sub RecepcionPedidoProv_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios And bRecepcion.Enabled Then
            If MsgBox("No se aplicarán las recepciones realizadas. ¿Salir de todos modos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If

    End Sub

    Private Sub RecepcionPedidoProv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        bRecepcion.Enabled = Not vSoloLectura
        Resultado = False
        cambios = False
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

        Call Inicializar()
        Call CargarPedido()
        listaCP = funcCP.mostrar(numPedido.Text)
        If VerDetalle Then
            Call CargarConceptosDetalle()
        Else
            Call CargarConceptos()
        End If

        Call IntroducirAlmacenes()

        semaforo = True
    End Sub



#Region "INICIALIZAR"

    Private Sub Inicializar()
        Proveedor.Text = ""
        Estado.Text = ""
        numAlbaran.Text = ""
        dtpFechaRecepcion.Value = Now.Date
        lbUnidades1.Text = "u."
        lbUnidades2.Text = lbUnidades2.Text
        Call CargarEstados()
    End Sub

    Private Sub CargarEstados()

        'Estados de pedido
        estadoCabecera = funcES.EstadoPedidoProv("CABECERA")
        estadoFinalizado = funcES.EstadoPedidoProv("FINALIZADO")
        estadoEnCurso = funcES.EstadoPedidoProv("EN CURSO")
        estadoValidado = funcES.EstadoPedidoProv("VALIDADO")
        estadoStock = funcES.EstadoPedidoProv("STOCK")
        estadoStockParcial = funcES.EstadoPedidoProv("STOCK PARCIAL")
        estadoAnulado = funcES.EstadoPedidoProv("ANULADO")
        'Estados de conceptos de pedido
        estadoCRecibido = funcES.EstadoCPedidoProv("RECIBIDO")
        estadoCRecibidoParcial = funcES.EstadoCPedidoProv("RECIBIDO PARCIAL")
        estadoCEspera = funcES.EstadoCPedidoProv("ESPERA")
        'Estado de Albaran
        estadoAlbaranProvRecibido = funcES.EstadoEntregado("ALBARANPROV")
        estadoCARecibido = funcES.EstadoEntregado("C.ALBARANPROV")
    End Sub

    Private Sub InicializarConcepto()
        codArticulo.Text = ""
        codArticuloProv.Text = ""
        Nombre.Text = ""
        Cantidad.Text = 0
        CantidadRecibida.Text = 0
        dtpFechaRecepcion.Value = Now.Date
    End Sub

    Private Sub IntroducirAlmacenes()
        cbAlmacen.Items.Clear()
        Dim lista As List(Of DatosAlmacen) = funcAL.Mostrar(True)
        Dim dts As DatosAlmacen
        For Each dts In lista
            cbAlmacen.Items.Add(New IDComboBox(dts.gAlmacen, dts.gidAlmacen))
        Next
        cbAlmacen.SelectedIndex = 0
    End Sub

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarPedido()
        'Datos generales de la cabecera del pedido
        If numPedido.Text <> "" And numPedido.Text <> "0" Then
            dtsPP = funcPP.Mostrar1(numPedido.Text)
            Proveedor.Text = dtsPP.gProveedor
            iidProveedor = dtsPP.gidProveedor
            Estado.Text = dtsPP.gEstado
            FechaPedido.Text = FormatDateTime(dtsPP.gFechaPedido, DateFormat.ShortDate)
            estadoInicial = funcES.Mostrar1(dtsPP.gidEstado)
            If estadoInicial.gBloqueado Then
                bRecepcion.Enabled = False
                bGuardarConcepto.Enabled = False
                VerDetalle = True
                bDetalle.Enabled = False
                bDetalle.Text = "VER RECEPCIÓN"
            Else
                VerDetalle = False
                bDetalle.Text = "VER DETALLE RECEPCIONES"
            End If
        End If
    End Sub


   


    Private Sub CargarConceptos()
        'Todos los conceptos del pedido que no se hayan recibido antes totalmente.
        If numPedido.Text <> "" And numPedido.Text <> "0" Then
            semaforo = False
            lvConceptos.Items.Clear()
            lvConceptos.CheckBoxes = Not VerDetalle
            ckSeleccion.Visible = Not VerDetalle
            Dim dts As DatosConceptoPedidoProv
            Dim todos As Boolean = True
            Dim ninguno As Boolean = True
            Dim Stock As Boolean = True
            Dim StockParcial As Boolean = False
            For Each dts In listaCP
                If Math.Abs(dts.gCantidad - dts.gCantidadRecibida) > 0 Then
                    With lvConceptos.Items.Add("")
                        .SubItems.Add(dts.gidConcepto)  '1
                        .SubItems.Add(dts.gcodArticulo)  '2
                        .SubItems.Add(dts.gcodArticuloProv)  '3
                        .SubItems.Add(dts.gArticuloProv)  '4
                        .SubItems.Add(FormatNumber(dts.gCantidad, 2))   '5, Cantidad pedida
                        .SubItems.Add(FormatNumber(dts.gCantidad - dts.gCantidadRecibida, 2)) '6, Cantidad Pendiente
                        'Precargamos la nueva cantidad recibida = cantidad pedida - cantidad recibida

                        If dts.gCantidadRecibida = 0 Then  '7
                            .SubItems.Add(FormatNumber(dts.gCantidad, 2))
                        Else
                            If dts.gCantidadRecibida < dts.gCantidad Then
                                .SubItems.Add(FormatNumber(dts.gCantidad - dts.gCantidadRecibida, 2))
                            Else
                                'Si se ha recibido todo o más, ponemos 0
                                .SubItems.Add(FormatNumber(0, 2))
                            End If
                        End If
                        .SubItems.Add(dts.gTipoUnidad)  '8
                        .SubItems.Add(dts.gFechaRecibido)  '9

                        .SubItems.Add(dts.gAceptado)  '10
                        .SubItems.Add(dts.gRecibido Or (dts.gCantidad > 0 And dts.gCantidadRecibida >= dts.gCantidad) Or dts.gCantidad < 0) '11 bit de Recibido
                        .SubItems.Add("")     '12
                        .SubItems.Add(dts.gcodMoneda) '13
                        'Variables Stock y StockParcial para acumular y saber al final si se ha recibido todo, algo o nada
                        Stock = Stock And (dts.gCantidad < 0 Or dts.gRecibido Or (dts.gCantidadRecibida >= dts.gCantidad))
                        StockParcial = StockParcial Or (dts.gRecibido > 0 And dts.gRecibido < dts.gCantidad) '(dts.gRecibido Or (dts.gCantidadRecibida >= dts.gCantidad))
                        .Checked = False
                        If dts.gRecibido Or (dts.gCantidad > 0 And dts.gCantidadRecibida >= dts.gCantidad) Or dts.gCantidad < 0 Then
                            'Lo que está recibido completo en verde
                            .ForeColor = Color.Green
                            .Checked = False
                        End If
                        If dts.gCantidadRecibida > 0 And dts.gCantidad > dts.gCantidadRecibida Then
                            'Lo que está recibido parcialmente en rojo
                            .ForeColor = Color.Red
                        End If

                        todos = todos And .Checked
                        ninguno = ninguno And Not .Checked

                        If todos Then
                            ckSeleccion.CheckState = CheckState.Checked
                        ElseIf ninguno Then
                            ckSeleccion.CheckState = CheckState.Unchecked
                        Else
                            ckSeleccion.CheckState = CheckState.Indeterminate
                        End If

                    End With

                End If
            Next
            If StockParcial Then Estado.Text = estadoStockParcial.gEstado '"STOCK PARCIAL"
            If Stock Then Estado.Text = estadoStock.gEstado '"STOCK"
            semaforo = True
        End If
    End Sub


    Private Sub CargarConceptosDetalle()
        'Todos los conceptos del pedido que no se hayan recibido antes totalmente.
        If numPedido.Text <> "" And numPedido.Text <> "0" Then
            semaforo = False
            lvConceptos.Items.Clear()
            lvConceptos.CheckBoxes = Not VerDetalle
            ckSeleccion.Visible = Not VerDetalle
            Dim dts As DatosConceptoPedidoProv
            Dim todos As Boolean = True
            Dim ninguno As Boolean = True
            Dim Stock As Boolean = True
            Dim StockParcial As Boolean = False
            For Each dts In listaCP
                With lvConceptos.Items.Add("")
                    .SubItems.Add(dts.gidConcepto)  '1
                    .SubItems.Add(dts.gcodArticulo)  '2
                    .SubItems.Add(dts.gcodArticuloProv)  '3
                    .SubItems.Add(dts.gArticuloProv)  '4
                    .SubItems.Add(FormatNumber(dts.gCantidad, 2))   '5, Cantidad pedida
                    .SubItems.Add(FormatNumber(dts.gCantidad - dts.gCantidadRecibida, 2)) '6, Cantidad Pendiente
                    'Precargamos la nueva cantidad recibida = cantidad pedida - cantidad recibida

                    .SubItems.Add(FormatNumber(dts.gCantidadRecibida, 2))
                    .SubItems.Add(dts.gTipoUnidad)  '8
                    .SubItems.Add("")  '9


                    .SubItems.Add(dts.gAceptado)  '10
                    .SubItems.Add(dts.gRecibido Or (dts.gCantidad > 0 And dts.gCantidadRecibida >= dts.gCantidad) Or dts.gCantidad < 0) '11 bit de Recibido
                    .SubItems.Add("")     '12
                    .SubItems.Add(dts.gcodMoneda) '13
                    'Variables Stock y StockParcial para acumular y saber al final si se ha recibido todo, algo o nada
                    Stock = Stock And (dts.gCantidad < 0 Or dts.gRecibido Or (dts.gCantidadRecibida >= dts.gCantidad))
                    StockParcial = StockParcial Or (dts.gRecibido > 0 And dts.gRecibido < dts.gCantidad) '(dts.gRecibido Or (dts.gCantidadRecibida >= dts.gCantidad))
                    .Checked = False
                    If dts.gRecibido Or (dts.gCantidad > 0 And dts.gCantidadRecibida >= dts.gCantidad) Or dts.gCantidad < 0 Then
                        'Lo que está recibido completo en verde
                        .ForeColor = Color.Green
                        .Checked = False
                    End If
                    If dts.gCantidadRecibida > 0 And dts.gCantidad > dts.gCantidadRecibida Then
                        'Lo que está recibido parcialmente en rojo
                        .ForeColor = Color.Red
                    End If

                    todos = todos And .Checked
                    ninguno = ninguno And Not .Checked

                    If todos Then
                        ckSeleccion.CheckState = CheckState.Checked
                    ElseIf ninguno Then
                        ckSeleccion.CheckState = CheckState.Unchecked
                    Else
                        ckSeleccion.CheckState = CheckState.Indeterminate
                    End If

                    Call CargarLineasConceptosAlbaranProv(dts.gidConcepto, .Index, .ForeColor)
                End With


            Next
            If StockParcial Then Estado.Text = estadoStockParcial.gEstado '"STOCK PARCIAL"
            If Stock Then Estado.Text = estadoStock.gEstado '"STOCK"
            semaforo = True
        End If
    End Sub




    Private Sub CargarLineasConceptosAlbaranProv(ByVal iidConceptoPedidoProv As Long, ByVal indice As Integer, ByVal col As Color)
        Dim listaCA As List(Of DatosConceptoAlbaranProv) = funcCA.mostrarCP(iidConceptoPedidoProv)
        Dim primera As Boolean = True
        For Each dts As DatosConceptoAlbaranProv In listaCA
            If primera Then
                With lvConceptos.Items(indice)
                    .SubItems(7).Text = FormatNumber(dts.gCantidad, 2)
                    .SubItems(9).Text = dts.gFechaRecibido
                    .SubItems(12).Text = dts.gnumAlbaran
                    .ForeColor = col
                End With
                primera = False
            Else
                With lvConceptos.Items.Add("")
                    .SubItems.Add(dts.gidConcepto) '1
                    .SubItems.Add("")   '2
                    .SubItems.Add("")   '3
                    .SubItems.Add("")   '4
                    .SubItems.Add("")   '5
                    .SubItems.Add("")   '6
                    .SubItems.Add(FormatNumber(dts.gCantidad, 2)) '7
                    .SubItems.Add(dts.gTipoUnidad) '8
                    .SubItems.Add(dts.gFechaRecibido) '9
                    .SubItems.Add(True)    '10
                    .SubItems.Add(True)    '11
                    .SubItems.Add(dts.gnumAlbaran) '12
                    .SubItems.Add(dts.gcodMoneda)  '13
                    .ForeColor = col
                End With
            End If

        Next
    End Sub



#End Region

#Region "PROCEDIMIENTO Y FUNCIONES"

    Private Sub MuestraConcepto()
        'Muestra el concepto marcado por el índice
        With lvConceptos.Items(indice)
            iidConcepto = .SubItems(1).Text
            codArticulo.Text = .SubItems(2).Text
            codArticuloProv.Text = .SubItems(3).Text
            Nombre.Text = .SubItems(4).Text
            Cantidad.Text = FormatNumber(.SubItems(6).Text, 2)
            CantidadRecibida.Text = FormatNumber(.SubItems(7).Text, 2)
            lbUnidades1.Text = .SubItems(8).Text
            lbUnidades2.Text = lbUnidades1.Text
            dtpFechaRecepcion.Value = FormatDateTime(.SubItems(9).Text, DateFormat.ShortDate)
            If .SubItems(12).Text <> "" Then
                Dim iidAlbaran As Integer = funcCP.idAlbaran(iidConcepto)
                If iidAlbaran > 0 Then
                    dtsAP = funcAP.Mostrar1(iidAlbaran)
                    numAlbaran.Text = dtsAP.gnumAlbaran
                End If
            End If
            scodMoneda = .SubItems(13).Text
            If scodMoneda = "" Then scodMoneda = "EU"
        End With

    End Sub



    Private Sub Estados()
        'Recalcular el estado del pedido revisando lo que se ha recibido
        Dim item As ListViewItem
        Dim Stock As Boolean = True
        Dim StockParcial As Boolean = False

        For Each item In lvConceptos.Items
            Stock = Stock And (item.SubItems(7).Text >= item.SubItems(6).Text)
            StockParcial = CDbl(item.SubItems(7).Text) > 0 And (StockParcial Or (CDbl(item.SubItems(7).Text) < CDbl(item.SubItems(6).Text)))
        Next
        If StockParcial Then
            Estado.Text = estadoStockParcial.gEstado
            dtsPP.gEstado = estadoStockParcial.gEstado
            dtsPP.gidEstado = estadoStockParcial.gidEstado
        ElseIf Stock Then
            Estado.Text = estadoStock.gEstado
            dtsPP.gEstado = estadoStock.gEstado
            dtsPP.gidEstado = estadoStock.gidEstado
        Else
            Estado.Text = estadoInicial.gEstado
            dtsPP.gEstado = estadoInicial.gEstado
            dtsPP.gidEstado = estadoInicial.gidEstado
        End If

    End Sub

#End Region

#Region "BOTONES"

    Private Sub bRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bRecepcion.Click
        'Se guardan todos los cambios que se hayan hecho en el listview (y el cambio de estado)
        Dim validar As Boolean = True
        Dim iidAlbaran As Integer = 0
        If ckSeleccion.CheckState = CheckState.Unchecked Then
            validar = False
            MsgBox("Debe seleccionar alguna linea del pedido.")
        End If
        If cbAlmacen.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbAlmacen, "No se ha seleccionado un almacén")
        End If
        If numAlbaran.Text = "" Then
            validar = False
            ep1.SetError(numAlbaran, "Se ha de indicar el albarán del proveedor")
        Else
            numAlbaran.Text = Trim(numAlbaran.Text)
            iidAlbaran = funcAP.idAlbaran(numAlbaran.Text, iidProveedor)
            If iidAlbaran > 0 Then
                If MsgBox("Ya se ha utilizado este albarán de este proveedor. ¿Es correcto?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    validar = False
                End If
            End If
        End If
        If validar Then
            'Guardar las recepciones 
            Dim item As ListViewItem
            Dim dts As New DatosConceptoPedidoProv

            Dim CantidadRecibidaYa As Double
            'Dim respuesta As MsgBoxResult = MsgBoxResult.Cancel
            'If lvConceptos.CheckedItems.Count > 1 Then
            '    'Si hay más de una linea seleccionada, preguntamos por la fecha de recepción
            '    respuesta = MsgBox("¿Asignar a todos los conceptos la fecha de recepción " & dtpFechaRecepcion.Value.Date & "? ", MsgBoxStyle.OkCancel)
            'End If

            'Crear el albaranProv

            dtsAP.gidAlbaran = iidAlbaran
            dtsAP.gnumAlbaran = numAlbaran.Text
            dtsAP.gidProveedor = iidProveedor
            dtsAP.gidFactura = 0
            dtsAP.gFecha = dtpFechaRecepcion.Value.Date
            dtsAP.gidEstado = funcES.EstadoEntregado("ALBARANPROV").gidEstado
            dtsAP.gcodMoneda = dtsPP.gcodMoneda
            If iidAlbaran = 0 Then
                iidAlbaran = funcAP.insertar(dtsAP)
                dtsAP.gidAlbaran = iidAlbaran
            Else
                funcAP.actualizar(dtsAP)
            End If
            Dim CantidadRecibidaAhora As Double = 0
            For Each item In lvConceptos.Items
                If item.Checked Then
                    'Recargamos todos los datos en el dts para crear la linea de stock
                    dts = funcCP.mostrar1(item.SubItems(1).Text)

                    CantidadRecibidaYa = dts.gCantidadRecibida
                    CantidadRecibidaAhora = item.SubItems(7).Text
                    dts.gCantidadRecibida = CantidadRecibidaYa + CantidadRecibidaAhora
                    'If respuesta = MsgBoxResult.Ok Then
                    dts.gFechaRecibido = dtpFechaRecepcion.Value.Date
                    'Else
                    'dts.gFechaRecibido = CDate(item.SubItems(8).Text)
                    'End If

                    'dts.gRecibido = CBool(item.SubItems(10).Text)
                    dts.gAceptado = True
                    If dts.gCantidadRecibida = 0 Then
                        dts.gidEstado = estadoCEspera.gidEstado
                    ElseIf dts.gCantidadRecibida >= dts.gCantidad Then
                        dts.gRecibido = True
                        dts.gidEstado = estadoCRecibido.gidEstado
                    Else
                        dts.gRecibido = False
                        dts.gidEstado = estadoCRecibidoParcial.gidEstado
                    End If

                    'dts.gidAlbaran = iidAlbaran
                    funcCP.actualizarRecepcion(dts)
                    Call CrearConceptoAlbaranProv(iidAlbaran, dts, CantidadRecibidaAhora)
                    Call ActualizarPedidoInterno(dts)
                    Call ActualizarStock(dts, CantidadRecibidaYa)
                    gbConceptos.Enabled = False
                    item.SubItems(12).Text = numAlbaran.Text
                End If
            Next
            'y el estado
            Call Estados()
            funcPP.actualizaEstado(numPedido.Text, dtsPP.gidEstado)

            MsgBox("Pedido recepcionado correctamente.")
            cambios = False
            Resultado = True
            Me.Close()
        End If
    End Sub

    Private Sub CrearConceptoAlbaranProv(ByVal iidAlbaran As Integer, ByVal dtsCP As DatosConceptoPedidoProv, ByVal CantidadRecibidaAhora As Double)
        Dim dts As New DatosConceptoAlbaranProv
        dts.gidAlbaran = iidAlbaran
        dts.gCantidad = CantidadRecibidaAhora
        dts.gidConceptoPedidoProv = dtsCP.gidConcepto
        dts.gDescuento = dtsCP.gDescuento
        dts.gPrecioNetoUnitario = dtsCP.gPrecioNetoUnitario
        dts.gArticuloProv = dtsCP.gArticuloProv
        dts.gcodArticuloProv = dtsCP.gcodArticuloProv
        dts.gidArticulo = dtsCP.gidArticulo
        dts.gidArticuloProv = dtsCP.gidArticuloProv
        dts.gidEstado = estadoCARecibido.gidEstado
        dts.gidFactura = 0
        dts.gidTipoIVA = 0
        dts.gidConcepto = funcCA.insertar(dts)
    End Sub

    Private Sub ActualizarStock(ByVal dts As DatosConceptoPedidoProv, ByVal CantidadRecibidaYa As Double)
        'Solo podemos añadir al stock si es un artículo existente y hemos recibido cantidad adicional
        If dts.gidArticulo > 0 And dts.gCantidadRecibida > CantidadRecibidaYa Then
            Dim dtsS As New DatosStock
            dtsS.gCantidad = dts.gCantidadRecibida - CantidadRecibidaYa
            dtsS.gcodMoneda = dts.gcodMoneda
            dtsS.gFecha = dts.gFechaRecibido
            dtsS.gidAlmacen = cbAlmacen.SelectedItem.itemdata
            dtsS.gidArticulo = dts.gidArticulo
            dtsS.gidArticuloProv = dts.gidArticuloProv
            dtsS.gidConceptoProv = dts.gidConcepto
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

    Private Sub ActualizarPedidoInterno(ByVal dts As DatosConceptoPedidoProv)
        Dim iidConcepto As Long = funcCI.ExisteidConceptoPedidoProv(dts.gidConcepto)
        If iidConcepto > 0 And dts.gCantidadRecibida > 0 Then
            Dim dtsCI As DatosConceptoPedidoInterno = funcCI.mostrar1(iidConcepto)
            If dts.gCantidadRecibida >= dtsCI.gCantidad Then
                funcCI.actualizarEstado(iidConcepto, funcES.EstadoCPedidoINT("RECIBIDO").gidEstado)
            Else
                funcCI.actualizarEstado(iidConcepto, funcES.EstadoCPedidoINT("PARCIAL").gidEstado)
            End If

        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub bGuardarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarConcepto.Click
        'Actualiza concepto en el listview
        If indice > -1 And lvConceptos.Items(indice).Checked Then
            If Cantidad.Text = "" Then Cantidad.Text = 0
            If CantidadRecibida.Text = "" Or CantidadRecibida.Text = "," Or CantidadRecibida.Text = "." Or CantidadRecibida.Text = "-" Then CantidadRecibida.Text = 0
            With lvConceptos.Items(indice)
                .SubItems(7).Text = FormatNumber(CantidadRecibida.Text, 2)
                .SubItems(9).Text = FormatDateTime(dtpFechaRecepcion.Value.Date, DateFormat.ShortDate)
                .SubItems(10).Text = True  'Campo Aceptado
                .SubItems(11).Text = (CDbl(CantidadRecibida.Text) >= CDbl(Cantidad.Text))  'Campo Recibido
                .Checked = (CantidadRecibida.Text > 0)
            End With

            Call InicializarConcepto()
            Call Estados()
            cambios = True
        End If
    End Sub

    Private Sub bVerAlbaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerAlbaran.Click
        'If numAlbaran.Text <> "" Then
        If dtsAP.gidAlbaran = 0 Then
            dtsAP.gidProveedor = dtsPP.gidProveedor
            dtsAP.gProveedor = dtsPP.gProveedor
            dtsAP.gidEstado = estadoAlbaranProvRecibido.gidEstado
            dtsAP.gEstado = estadoAlbaranProvRecibido.gEstado
        End If
        dtsAP.gnumAlbaran = numAlbaran.Text
        dtsAP.gFecha = dtpFechaRecepcion.Value.Date
        Dim GG As New subAlbaranProv
        GG.pdts = dtsAP
        GG.ShowDialog()
        If GG.DialogResult = Windows.Forms.DialogResult.OK Then
            numAlbaran.Text = dtsAP.gnumAlbaran
            dtpFechaRecepcion.Value = dtsAP.gFecha
        End If
        cambios = True
        'End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 And Not VerDetalle Then
            indice = lvConceptos.SelectedIndices(0)
            Call MuestraConcepto()
        End If
    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvConceptos.ItemChecked
        If semaforo And Not VerDetalle Then
            semaforo = False
            Dim todos As Boolean = True
            Dim ninguno As Boolean = True
            Dim item As ListViewItem
            For Each item In lvConceptos.Items
                If CBool(item.SubItems(11).Text) Then 'Si ya está recibida la linea no se puede marcar

                    item.Checked = False
                Else
                    If item.Checked Then
                        If item.SubItems(7).Text = 0 Then
                            item.SubItems(7).Text = item.SubItems(6).Text
                        End If
                    Else
                        item.SubItems(7).Text = 0
                    End If
                End If


                todos = todos And item.Checked
                ninguno = ninguno And Not item.Checked
            Next
            If todos Then
                ckSeleccion.CheckState = CheckState.Checked
            ElseIf ninguno Then
                ckSeleccion.CheckState = CheckState.Unchecked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
            Call Estados()
            semaforo = True
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
    End Sub

    Private Sub CantidadRecibida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CantidadRecibida.Click, numAlbaran.Click
        sender.selectall()
    End Sub


    Private Sub CantidadRecibida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CantidadRecibida.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(CantidadRecibida.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ckConceptos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckSeleccion.CheckedChanged

        If semaforo Then

            If ckSeleccion.CheckState = CheckState.Indeterminate Then
            Else
                semaforo = False
                For Each item As ListViewItem In lvConceptos.Items

                    If item.Checked Then
                        If item.SubItems(7).Text = item.SubItems(6).Text Then
                            item.SubItems(7).Text = 0
                        End If

                    Else
                        If item.SubItems(7).Text = 0 Then
                            item.SubItems(7).Text = item.SubItems(6).Text
                        End If

                    End If
                    item.Checked = ckSeleccion.Checked

                Next
                semaforo = True
            End If
        End If

    End Sub


#End Region

    Private Sub bDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDetalle.Click
        If estadoInicial.gBloqueado Then
        Else
            If VerDetalle Then
                bGuardarConcepto.Enabled = True
                bRecepcion.Enabled = True
                bDetalle.Text = "VER DETALLE RECEPCIONES"
                VerDetalle = False
                Call CargarConceptos()
            Else
                bGuardarConcepto.Enabled = False
                bRecepcion.Enabled = False
                bDetalle.Text = "VER RECEPCIÓN"
                VerDetalle = True
                Call CargarConceptosDetalle()
            End If
        End If
    End Sub
End Class