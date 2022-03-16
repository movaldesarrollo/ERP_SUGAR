Public Class RecepcionPedidoProv

    Dim funcP As New funcionesProveedores
    Dim funcPP As New FuncionesPedidosProv
    Dim funcCP As New FuncionesConceptosPedidosProv
    Dim funcM As New FuncionesMoneda
    Dim funcUM As New FuncionesTiposUnidad
    Dim funcUB As New funcionesUbicaciones
    Dim funcTC As New FuncionesTipoCompra
    Dim funcST As New FuncionesStock
    Dim funcCI As New FuncionesConceptosPedidosInternos
    Private funcAL As New FuncionesAlmacenes
    Private funcES As New FuncionesEstados
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
    Private estadoCEspera As DatosEstado
    Private nuevoEstado As Integer
    Private dtsPP As DatosPedidoProv
    Private cambios As Boolean
    Private Resultado As Boolean


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
        If cambios Then
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
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
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
        Call Inicializar()
        Call CargarPedido()
        Call CargarConceptos()
        Call IntroducirAlmacenes()

        semaforo = True
    End Sub



#Region "INICIALIZAR"

    Private Sub Inicializar()
        Proveedor.Text = ""
        Estado.Text = ""

        dtpFechaRecepcion.Value = Now.Date
        lbUnidades1.Text = "u."
        lbUnidades2.Text = lbUnidades2.Text

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
            Estado.Text = dtsPP.gEstado
            FechaPedido.Text = FormatDateTime(dtsPP.gFechaPedido, DateFormat.ShortDate)
            estadoInicial = funcES.Mostrar1(dtsPP.gidEstado)
        End If
    End Sub



    Private Sub CargarConceptos()
        'Todos los conceptos del pedido que no se hayan recibido antes totalmente.
        If numPedido.Text <> "" And numPedido.Text <> "0" Then
            Dim lista As List(Of DatosConceptoPedidoProv) = funcCP.mostrar(numPedido.Text)
            Dim dts As DatosConceptoPedidoProv
            Dim todos As Boolean = True
            Dim ninguno As Boolean = True
            Dim Stock As Boolean = True
            Dim StockParcial As Boolean = False
            For Each dts In lista
                If Math.Abs(dts.gCantidad - dts.gCantidadRecibida) > 0 Then

                    With lvConceptos.Items.Add("")

                        .SubItems.Add(dts.gidConcepto)
                        .SubItems.Add(dts.gcodArticulo)
                        .SubItems.Add(dts.gcodArticuloProv)
                        .SubItems.Add(dts.gArticuloProv)
                        .SubItems.Add(FormatNumber(dts.gCantidad - dts.gCantidadRecibida, 2))
                        'Precargamos la nueva cantidad recibida = cantidad pedida - cantidad recibida
                        If dts.gCantidadRecibida = 0 Then
                            .SubItems.Add(FormatNumber(dts.gCantidad, 2))
                        Else
                            If dts.gCantidadRecibida < dts.gCantidad Then
                                .SubItems.Add(FormatNumber(dts.gCantidad - dts.gCantidadRecibida, 2))
                            Else
                                'Si se ha recibido todo o más, ponemos 0
                                .SubItems.Add(FormatNumber(0, 2))
                            End If
                        End If
                        .SubItems.Add(dts.gTipoUnidad)
                        .SubItems.Add(dts.gFechaRecibido)
                        .SubItems.Add(dts.gAceptado)
                        .SubItems.Add(dts.gRecibido Or (dts.gCantidad > 0 And dts.gCantidadRecibida >= dts.gCantidad) Or dts.gCantidad < 0) 'bit de Recibido
                        'Variables Stock y StockParcial para acumular y saber al final si se ha recibido todo, algo o nada
                        Stock = Stock And (dts.gRecibido Or (dts.gCantidadRecibida >= dts.gCantidad))
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
        End If
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
            Cantidad.Text = FormatNumber(.SubItems(5).Text, 2)
            CantidadRecibida.Text = FormatNumber(.SubItems(6).Text, 2)
            lbUnidades1.Text = .SubItems(7).Text
            lbUnidades2.Text = lbUnidades1.Text
            dtpFechaRecepcion.Value = FormatDateTime(.SubItems(8).Text, DateFormat.ShortDate)
        End With

    End Sub



    Private Sub Estados()
        'Recalcular el estado del pedido revisando lo que se ha recibido
        Dim item As ListViewItem
        Dim Stock As Boolean = True
        Dim StockParcial As Boolean = False

        For Each item In lvConceptos.Items
            Stock = Stock And (item.SubItems(6).Text >= item.SubItems(5).Text)
            StockParcial = CDbl(item.SubItems(6).Text) > 0 And (StockParcial Or (CDbl(item.SubItems(6).Text) < CDbl(item.SubItems(5).Text)))
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

        If ckSeleccion.CheckState = CheckState.Unchecked Then
            validar = False
            MsgBox("Debe seleccionar alguna linea del pedido.")
        End If
        If cbAlmacen.SelectedIndex = -1 Then
            validar = False
            MsgBox("No se ha seleccionado un almacén")
        End If
        If validar Then
            'Guardar las recepciones 
            Dim item As ListViewItem
            Dim dts As New DatosConceptoPedidoProv

            Dim CantidadRecibidaYa As Double
            Dim respuesta As MsgBoxResult = MsgBoxResult.Cancel
            If lvConceptos.CheckedItems.Count > 1 Then
                'Si hay más de una linea seleccionada, preguntamos por la fecha de recepción
                respuesta = MsgBox("¿Asignar a todos los conceptos la fecha de recepción " & dtpFechaRecepcion.Value.Date & "? ", MsgBoxStyle.OkCancel)
            End If
            For Each item In lvConceptos.Items
                If item.Checked Then
                    'Recargamos todos los datos en el dts para crear la linea de stock
                    dts = funcCP.mostrar1(item.SubItems(1).Text)

                    CantidadRecibidaYa = dts.gCantidadRecibida

                    dts.gCantidadRecibida = CantidadRecibidaYa + item.SubItems(6).Text
                    If respuesta = MsgBoxResult.Ok Then
                        dts.gFechaRecibido = dtpFechaRecepcion.Value.Date
                    Else
                        dts.gFechaRecibido = CDate(item.SubItems(8).Text)
                    End If

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
                    funcCP.actualizarRecepcion(dts)
                    Call ActualizarPedidoInterno(dts)
                    Call ActualizarStock(dts, CantidadRecibidaYa)
                    gbConceptos.Enabled = False
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
        If indice > -1 Then
            With lvConceptos.Items(indice)
                .SubItems(6).Text = FormatNumber(CantidadRecibida.Text, 2)
                .SubItems(8).Text = FormatDateTime(dtpFechaRecepcion.Value.Date, DateFormat.ShortDate)
                .SubItems(9).Text = True  'Campo Aceptado
                .SubItems(10).Text = (CantidadRecibida.Text >= Cantidad.Text)  'Campo Recibido
                .Checked = (CantidadRecibida.Text > 0)
            End With

            Call InicializarConcepto()
            Call Estados()
            cambios = True
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Call MuestraConcepto()
        End If
    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvConceptos.ItemChecked
        If semaforo Then
            semaforo = False
            Dim todos As Boolean = True
            Dim ninguno As Boolean = True
            Dim item As ListViewItem
            For Each item In lvConceptos.Items
                If CBool(item.SubItems(10).Text) Then 'Si ya está recibida la linea no se puede marcar
                    item.Checked = False
                Else
                    If item.Checked Then
                        If item.SubItems(6).Text = 0 Then
                            item.SubItems(6).Text = item.SubItems(5).Text
                        End If
                    Else
                        item.SubItems(6).Text = 0
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

    Private Sub CantidadRecibida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CantidadRecibida.Click
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
            'Dim item As ListViewItem
            'For Each item In lvConceptos.Items
            '    If ckSeleccion.CheckState = CheckState.Checked Then
            '        item.Checked = True
            '        If item.SubItems(6).Text = 0 Then
            '            FormatNumber(item.SubItems(5).Text, 2)
            '        End If
            '    End If
            '    If ckSeleccion.CheckState = CheckState.Unchecked Then
            '        item.Checked = False
            '        item.SubItems(6).Text = 0
            '    End If
            'Next

            If ckSeleccion.CheckState = CheckState.Indeterminate Then
            Else
                semaforo = False
                For Each item As ListViewItem In lvConceptos.Items

                    If item.Checked Then
                        If item.SubItems(6).Text = item.SubItems(5).Text Then
                            item.SubItems(6).Text = 0
                        End If

                    Else
                        If item.SubItems(6).Text = 0 Then
                            item.SubItems(6).Text = item.SubItems(5).Text
                        End If

                    End If
                    item.Checked = ckSeleccion.Checked

                Next
                semaforo = True
            End If
        End If



    End Sub


#End Region




End Class