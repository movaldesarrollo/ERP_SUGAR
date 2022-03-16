Public Class subPedidoStock1

    Private lista As List(Of DatosConceptoPedido)
    Private cambios As Boolean
    Private indice As Integer
    Private funcCP As New FuncionesConceptosPedidos
    Private funcCR As New FuncionesConceptosProduccion
    Private funcES As New FuncionesEstados
    Private funcPE As New FuncionesPedidos
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcCEQ As New FuncionesConceptosEquiposProduccion
    Private funcCE As New FuncionesConceptosEscandallos
    Private funcEC As New FuncionesEscandallos
    Private funcAR As New FuncionesArticulos
    Private funcSK As New FuncionesStock
    Private funcCL As New funcionesclientes
    Private funcAP As New FuncionesArticuloPrecio
    Private vsoloLectura As Boolean
    Private Conceptos As List(Of Long)
    Private inumPedido As Integer
    'Private Prioridad As Byte
    Private idEstadoAnulado As Integer
    Private idEstadoEnCurso As Integer
    Private idEstadoEspera As Integer
    Private idEstadoCompleto As Integer
    Private ArrayDeListas() As List(Of DatosEquipoProduccion)
    Private ListaEquiposStock As List(Of DatosEquipoProduccion)
    Private dtsPE As DatosPedido
    Private CambiosEnEquipos As String
    Private listaEquiposYaSeleccioandos As List(Of Long) 'Acumulamos los equipos de stock seleccionados para no repetirlos en otro concepto.
    Private listaArticulosModificados As List(Of EquiposModificados) 'IDComboBox)

    Dim iidEstadoPR As Integer = 0
    Dim iidEstadoCP As Integer = 0
    Dim iidEstadoCL As Integer = 0

    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
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

   

    Public WriteOnly Property pDtsPE() As DatosPedido
        Set(ByVal value As DatosPedido)
            dtsPE = value
        End Set
    End Property


    Private Sub subPedidoStock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios Then
            If MsgBox("Se perderán los valores introducidos. ¿Salir?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub


    Private Sub subPedidoStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bProduccion.Enabled = Not vsoloLectura
        cambios = False
        Call Limpiar()
        If dtsPE.gPrioridad = 2 Then rbProd2.Checked = True Else rbProd2.Checked = False
        If dtsPE.gPrioridad = 1 Then rbProd1.Checked = True Else rbProd1.Checked = False
        lista = New List(Of DatosConceptoPedido)
        For Each iidConcepto As Long In Conceptos
            lista.Add(funcCP.Mostrar1(iidConcepto))
        Next
        ReDim ArrayDeListas(Conceptos.Count - 1)
        For i = 0 To ArrayDeListas.Count - 1
            ArrayDeListas(i) = New List(Of DatosEquipoProduccion)
        Next
        inumPedido = lista(0).gnumPedido
        Me.Text = "ASIGNACIÓN DE CONCEPTOS DEL PEDIDO " & inumPedido & " A FABRICACIÓN"
        idEstadoAnulado = funcES.EstadoAnulado("EQUIPO").gidEstado
        idEstadoEnCurso = funcES.EstadoEnCurso("EQUIPO").gidEstado
        idEstadoEspera = funcES.EstadoEspera("EQUIPO").gidEstado
        idEstadoCompleto = funcES.EstadoCompleto("EQUIPO").gidEstado
        Call CargarConceptos()
    End Sub

    Private Sub Limpiar()
        Cantidad.Text = 0
        DeStock.Text = 0
        If dtsPE.gPrioridad = 2 Then rbProd2.Checked = True Else rbProd2.Checked = False
        If dtsPE.gPrioridad = 1 Then rbProd1.Checked = True Else rbProd1.Checked = False
        indice = -1
        bUsarStock.Enabled = False
        codArticulo.Text = ""
    End Sub

    Private Sub CargarConceptos()
        Dim iidArticuloBase As Integer = 0

        For Each dts As DatosConceptoPedido In lista
            iidArticuloBase = funcEC.idArticuloBaseArticulo(dts.gidArticulo)
            If iidArticuloBase = 0 Then iidArticuloBase = dts.gidArticulo
            With lvConceptos.Items.Add(dts.gidConcepto)
                .SubItems.Add(dts.gcodArticulo)
                .SubItems.Add(dts.gArticulo)
                .SubItems.Add(dts.gCantidadStock)
                .SubItems.Add(If(iidArticuloBase = dts.gidArticulo, dts.gCantidadStock, funcEQ.StockBase(iidArticuloBase)))
                .SubItems.Add(dts.gCantidad)
                .SubItems.Add("0")
                .SubItems.Add(dts.gCantidad)
                .SubItems.Add(dts.gTipoUnidad)
                .SubItems.Add(dtsPE.gPrioridad)
                .SubItems.Add(iidArticuloBase)
                Select Case dtsPE.gPrioridad
                    Case 1
                        .ForeColor = Color.Red
                    Case 2
                        .ForeColor = Color.Orange
                    Case 3
                        .ForeColor = Color.Green
                End Select

            End With
        Next
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosConceptoPedido)
        If indice <> -1 Then
            With lvConceptos.Items(indice)
                .SubItems(3).Text = dts.gCantidad & dts.gTipoUnidad
                .SubItems(5).Text = dts.gCantidadStock & dts.gTipoUnidad
                If dts.gCantidad > dts.gCantidadStock Then
                    .SubItems(6).Text = (dts.gCantidad - dts.gCantidadStock)
                Else
                    .SubItems(6).Text = "0"
                End If
            End With
        End If
    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        'Guarda en el listview, no en la base de datos
        If indice <> -1 Then
            If DeStock.Text = "" Then DeStock.Text = 0
            If Cantidad.Text = "" Then Cantidad.Text = 0
            cambios = True
            With lvConceptos.Items(indice)
                If CDbl(DeStock.Text) > CDbl(.SubItems(4).Text) Then DeStock.Text = .SubItems(4).Text
                .SubItems(6).Text = DeStock.Text
                If CDbl(Cantidad.Text) > CDbl(.SubItems(5).Text) Then Cantidad.Text = .SubItems(5).Text
                .SubItems(7).Text = Cantidad.Text
                If CDbl(DeStock.Text) + CDbl(Cantidad.Text) > .SubItems(5).Text Then
                    DeStock.Text = CDbl(.SubItems(5).Text) - CDbl(Cantidad.Text)
                    .SubItems(6).Text = DeStock.Text
                End If
                If rbProd1.Checked Then
                    .SubItems(9).Text = 1
                    .ForeColor = Color.Red
                End If
                If rbProd2.Checked Then
                    .SubItems(9).Text = 2
                    .ForeColor = Color.Orange
                End If
            End With
            'preguardar, si existen, los equipos tomados del stock
            ArrayDeListas(indice) = ListaEquiposStock
            Call Limpiar()
        End If

    End Sub

    Private Sub pProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bProduccion.Click

        bProduccion.Enabled = False

        Me.Cursor = Cursors.WaitCursor

        bProduccion.Enabled = lanzarAProduccion()

        Me.Cursor = Cursors.Default

    End Sub

    Public Function lanzarAProduccion() As Boolean

        Try
            'Análisis de las cantidades: verificar si hay unidades que no están en stock ni se producen: esto generará lineas adicionales en el pedido
            Dim dts As DatosConceptoPedido
            Dim Producir As Double = 0
            Dim DelStock As Double = 0
            Dim Prioridad As Byte = 3
            iidEstadoPR = funcES.EstadoEspera("PRODUCCION").gidEstado
            iidEstadoCP = funcES.EstadoCPedido("RECIBIDO PRODUCCION").gidEstado
            iidEstadoCL = funcES.EstadoCPedido("ENVIADO PRODUCCION").gidEstado
            Dim respuesta As MsgBoxResult = MsgBoxResult.Ok
            ' If listaProducciones Is Nothing Then listaProducciones = New List(Of Long)
            For Each item As ListViewItem In lvConceptos.Items
                If Not IsNumeric(item.SubItems(6).Text) Then item.SubItems(6).Text = 0
                If Not IsNumeric(item.SubItems(6).Text) Then item.SubItems(7).Text = 0
                If Not IsNumeric(item.SubItems(9).Text) Then item.SubItems(9).Text = 3
                Producir = item.SubItems(7).Text
                DelStock = item.SubItems(6).Text
                Prioridad = item.SubItems(9).Text
                If respuesta <> MsgBoxResult.Cancel Then
                    dts = funcCP.Mostrar1(item.Text)
                    item.SubItems(3).Text = dts.gCantidadStock 'Recargamos el stock por si ha cambiado

                    If DelStock < 0 Then DelStock = 0 'No tratamos el caso de stock negativo

                    If Producir < (dts.gCantidad - DelStock) Then
                        respuesta = MsgBox("Quedarían " & dts.gCantidad - DelStock - Producir & dts.gTipoUnidad & " pendientes de " & dts.gcodArticulo & ". " & vbCrLf & "¿Crear una nueva linea de pedido con estas unidades?", MsgBoxStyle.OkCancel)
                        If respuesta = MsgBoxResult.Ok Then
                            Call DuplicarLineaPedido(item.Text, Producir + DelStock, dts.gCantidad - DelStock - Producir)
                            item.SubItems(5).Text = Producir + DelStock
                        End If
                    End If
                End If
            Next
            'Crear las producciones
            If respuesta <> MsgBoxResult.Cancel Then
                Dim contador As Integer = 0
                Dim CantidadEquipos As Integer = 0
                For Each item As ListViewItem In lvConceptos.Items
                    Producir = item.SubItems(7).Text
                    DelStock = item.SubItems(6).Text
                    CantidadEquipos = CantidadEquipos + Producir + DelStock
                Next
                pbCarga.Maximum = CantidadEquipos + 2
                pbCarga.Value = 2
                pbCarga.Visible = True
                Dim iidConceptoPedido As Long = 0
                For Each item As ListViewItem In lvConceptos.Items
                    iidConceptoPedido = item.Text
                    Dim dtsCP As DatosConceptoPedido = funcCP.Mostrar1(iidConceptoPedido)

                    Producir = item.SubItems(7).Text
                    DelStock = item.SubItems(6).Text
                    Prioridad = item.SubItems(9).Text
                    If Producir > 0 Then
                        Dim dtsPR As DatosConceptoProduccion = NuevaProduccion(dtsCP, Producir, Prioridad)

                        If Not funcAR.conVersiones(dtsPR.gidArticulo) Then dtsPR.gVersion = 0
                        dtsPR.gidEscandallo = funcEC.ExisteEscandalloVersionUltima(dtsCP.gidArticulo, dtsCP.gVersion)

                        If dtsPR.gidEscandallo = 0 Then
                            MsgBox("No existe escandallo válido para la versión " & dtsCP.gVersion & " de " & If(dtsCP.gcodArticulo = "", dtsCP.gArticulo, dtsCP.gcodArticulo) & vbCrLf & "Se debe crear la nueva versión para poder enviar a producción.")
                        Else
                            dtsPR.gidProduccion = funcCR.insertar(dtsPR)
                            dtsPR = funcCR.Mostrar1(dtsPR.gidProduccion)
                            'Crear los equipos
                            contador = contador + CrearEquipos(dtsPR, Producir)
                            'Cambiar el estado del concepto de pedido sólo si realmente se han creado equipos
                            If contador > 0 Then
                                funcCP.CambiarEstado(dtsCP.gidConcepto, iidEstadoCP)
                                dtsCP.gidEstado = iidEstadoCP
                            End If

                        End If
                    End If
                    If DelStock > 0 Then 'Del stock
                        If ArrayDeListas(item.Index).Count > 0 Then
                            If ProcesarEquipos(item.Index, dtsCP) Then
                                'Si cogemos algo del stock enviaremos directamente a logística
                                If dtsCP.gidEstado <> iidEstadoCP Then funcCP.CambiarEstado(item.Text, iidEstadoCL)
                            End If
                        End If
                    End If
                Next
                Dim ContadorEQStock As Integer = 0
                Dim Texto As String = ""
                If ArrayDeListas.Count > 0 Then
                    For Each lista As List(Of DatosEquipoProduccion) In ArrayDeListas
                        If Not lista Is Nothing Then ContadorEQStock = ContadorEQStock + lista.Count
                    Next
                    If ContadorEQStock > 0 Then
                        If ContadorEQStock = 1 Then
                            Texto = "Se ha utilizado un equipo del stock."
                        ElseIf ContadorEQStock > 1 Then
                            Texto = "Se han utilizado " & ContadorEQStock & " equipos del stock."
                        End If
                        If Not listaArticulosModificados Is Nothing AndAlso listaArticulosModificados.Count > 0 Then
                            For Each EQModificados As EquiposModificados In listaArticulosModificados
                                Call ActualizarStockEquiposCambiados(EQModificados)
                                Texto = Texto & vbCrLf & EQModificados.ToString
                            Next
                        End If
                        funcPE.actualizaEstado(inumPedido, funcES.EstadoPedido("PRODUCCION").gidEstado)
                    End If
                End If
                If contador > 0 Then
                    funcPE.actualizaEstado(inumPedido, funcES.EstadoPedido("PRODUCCION").gidEstado)
                    If Texto <> "" Then Texto = Texto & vbCrLf & vbCrLf
                    If contador = 1 Then
                        Texto = Texto & "Se ha creado un equipo nuevo para producir."
                    Else
                        Texto = Texto & "Se han creado " & contador & " equipos nuevos para producir."
                    End If
                End If
                If Texto <> "" Then MsgBox(Texto)

                pbCarga.Visible = False
                cambios = False
                Me.Close()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try



    End Function

    Private Sub ActualizarStockEquiposCambiados(ByVal EQModificados As EquiposModificados)
        Dim listaConceptosEQOriginal As New List(Of DatosConceptoEscandallo)
        Dim listaConceptosEQNuevo As New List(Of DatosConceptoEscandallo)
        If funcEC.idArticuloBaseArticulo(EQModificados.gIdArticuloOriginal) = 0 Then
            Dim dts As New DatosConceptoEscandallo
            dts.gidArticulo = EQModificados.gIdArticuloOriginal
            dts.gCantidad = EQModificados.gCantidad
            listaConceptosEQOriginal.Add(dts)
        Else
            listaConceptosEQOriginal = funcCE.Mostrar(EQModificados.gidEscandalloOriginal, True, 0)
        End If
        If funcEC.idArticuloBaseArticulo(EQModificados.gidArticuloNuevo) = 0 Then
            Dim dts As New DatosConceptoEscandallo
            dts.gidArticulo = EQModificados.gidArticuloNuevo
            dts.gCantidad = EQModificados.gCantidad
            listaConceptosEQNuevo.Add(dts)
        Else
            listaConceptosEQNuevo = funcCE.Mostrar(EQModificados.gidEscandalloNuevo, True, 0)
        End If
        For Each dts As DatosConceptoEscandallo In listaConceptosEQOriginal
            If dts.gCantidad > 0 Then
                Dim cantidad As Double = CantidadComponenteEquipoLista(dts.gidArticulo, listaConceptosEQNuevo)
                If cantidad <> dts.gCantidad Then
                    Call InsertarMovimientoStock(dts.gidArticulo, EQModificados.gCantidad * (dts.gCantidad - cantidad), dts.gidTipoUnidad, EQModificados.gidProduccionNuevo, 0, "EU", "Cambio Equipo")
                    dts.gCantidad = cantidad 'De esta forma en el siguiente bucle no hacemos otro movimiento de stock
                End If
            End If
        Next

        For Each dts As DatosConceptoEscandallo In listaConceptosEQNuevo
            If dts.gCantidad > 0 Then
                Dim cantidad As Double = CantidadComponenteEquipoLista(dts.gidArticulo, listaConceptosEQOriginal)
                If cantidad <> dts.gCantidad Then
                    Call InsertarMovimientoStock(dts.gidArticulo, EQModificados.gCantidad * (cantidad - dts.gCantidad), dts.gidTipoUnidad, EQModificados.gidProduccionNuevo, 0, "EU", "Cambio Equipo")
                End If
            End If
        Next
    End Sub

    Private Sub InsertarMovimientoStock(ByVal iidArticulo As Integer, ByVal Cantidad As Double, ByVal iidTipoUnidad As Integer, ByVal iidProduccion As Integer, ByVal Precio As Double, ByVal codMoneda As String, ByVal Movimiento As String)
        Dim dtsSK As New DatosStock
        dtsSK.gidArticulo = iidArticulo
        dtsSK.gCantidad = Cantidad
        dtsSK.gcodMoneda = codMoneda
        dtsSK.gFecha = Now
        dtsSK.gidAlmacen = 0
        dtsSK.gidArticuloProv = 0
        dtsSK.gidConceptoAlbaran = 0
        dtsSK.gidConceptoPedido = 0
        dtsSK.gidConceptoProv = 0
        dtsSK.gidLote = 0
        dtsSK.gidPersona1 = Inicio.vIdUsuario
        dtsSK.gidPersona2 = 0
        dtsSK.gidProduccion = iidProduccion
        dtsSK.gidUnidad = iidTipoUnidad
        dtsSK.gMovimiento = Movimiento
        dtsSK.gPrecio = Precio
        funcSK.insertar(dtsSK)
    End Sub

    Private Function CantidadComponenteEquipoLista(ByVal iidArticulo As Integer, ByVal listaConceptosEQ As List(Of DatosConceptoEscandallo)) As Double
        For i = 0 To listaConceptosEQ.Count - 1
            If listaConceptosEQ(i).gidArticulo = iidArticulo Then Return listaConceptosEQ(i).gCantidad
        Next
        Return 0
    End Function

    Private Function NuevaProduccion(ByVal dtsCP As DatosConceptoPedido, ByVal Cantidad As Double, ByVal Prioridad As Byte) As DatosConceptoProduccion
        Dim dtsPR As New DatosConceptoProduccion
        dtsPR.gidProduccion = 0
        dtsPR.gnumAlbaran = 0
        dtsPR.gidArticulo = dtsCP.gidArticulo
        dtsPR.gCantidad = Cantidad
        dtsPR.gidEstado = iidEstadoPR
        dtsPR.gidArtCli = dtsCP.gidArtCli
        dtsPR.gidConceptoPedido = dtsCP.gidConcepto
        dtsPR.gPrioridad = Prioridad
        dtsPR.gFechaPrevista = dtsPE.gFechaEntrega ' funcPE.FechaEntrega(dtsCP.gnumPedido)
        dtsPR.gFechaFin = dtsPR.gFechaPrevista
        dtsPR.gObservaciones = funcCL.ObservacionesProd(funcPE.idCliente(dtsCP.gnumPedido))
        dtsPR.gidPersona = Inicio.vIdUsuario
        dtsPR.gVersion = dtsCP.gVersion
        Return dtsPR
    End Function

    Private Function ProcesarEquipos(ByVal indiceArray As Integer, ByVal dtsCP As DatosConceptoPedido) As Boolean
        'Una vez por conceptoPedido
        Dim listaEQ As List(Of DatosEquipoProduccion) = ArrayDeListas(indiceArray)
        'listaProducciones = New List(Of Long)
        Dim item As ListViewItem = lvConceptos.Items(indiceArray)
        Dim Producir As Double = item.SubItems(7).Text
        Dim DelStock As Double = item.SubItems(6).Text
        Dim Prioridad As Byte = item.SubItems(9).Text
        Dim iidEscandallo As Integer = funcEC.ExisteEscandalloVersionUltima(dtsCP.gidArticulo, dtsCP.gVersion)
        'Tomamos la idProduccion si se han enviado a producción algunas unidades
        Dim iidProduccion As Integer = funcCR.IdProduccion(dtsCP.gidConcepto)


        If iidProduccion = 0 Then
            'En otro caso,creamos una produccion nueva
            iidProduccion = funcCR.insertar(NuevaProduccion(dtsCP, DelStock, Prioridad))

        Else
            If funcCR.Cantidad(iidProduccion) <> DelStock + Producir Then
                funcCR.CambiarCantidad(iidProduccion, DelStock + Producir)
            End If
        End If

        Dim CantidadEquiposProduccion = 0
        If listaArticulosModificados Is Nothing Then listaArticulosModificados = New List(Of EquiposModificados) 'Esta lista es única, solo sirve para informar al final
        Dim iidProduccionEquipo As Integer = 0
        For Each dtsEQ As DatosEquipoProduccion In listaEQ
            iidProduccionEquipo = dtsEQ.gidProduccion
            If iidProduccionEquipo <> iidProduccion Then
                CantidadEquiposProduccion = funcCR.Cantidad(iidProduccionEquipo)
                Call CambiosArticuloProduccion(dtsEQ, dtsCP, iidProduccion, iidEscandallo)
                If CantidadEquiposProduccion = 1 Then
                    funcCR.borrar(iidProduccionEquipo)
                Else
                    funcCR.CambiarCantidad(iidProduccionEquipo, CantidadEquiposProduccion - 1)
                End If
            End If
            pbCarga.Increment(1)
            Application.DoEvents()
        Next
        Return iidProduccion > 0
    End Function

    Private Function CambiosArticuloProduccion(ByRef dtsEQ As DatosEquipoProduccion, ByVal dtsCP As DatosConceptoPedido, ByVal iidProduccion As Integer, ByVal iidEscandallo As Integer) As Boolean
        Dim HayCambios As Boolean = False
        If dtsEQ.gidProduccion <> iidProduccion Then
            dtsEQ.gidProduccion = iidProduccion
            HayCambios = True
        End If
        If dtsEQ.gidArticulo <> dtsCP.gidArticulo Then
            dtsEQ.gObservaciones = "Equipo original: " & dtsEQ.gcodArticulo & vbCrLf & dtsEQ.gObservaciones
            dtsEQ.gObservaciones = Microsoft.VisualBasic.Left(dtsEQ.gObservaciones, 200)
            dtsEQ.gidArticulo = dtsCP.gidArticulo
            HayCambios = True
            Dim indiceModificados As Integer = IndexOfListaArticulosModificados(dtsEQ.gcodArticulo, dtsCP.gcodArticulo)
            If indiceModificados = -1 Then
                Dim iidEscandalloNuevo = funcEC.ExisteEscandalloVersionUltima(dtsCP.gidArticulo, dtsCP.gVersion)
                listaArticulosModificados.Add(New EquiposModificados(dtsEQ.gidArticulo, dtsEQ.gcodArticulo, dtsEQ.gidEscandallo, dtsCP.gidArticulo, dtsCP.gcodArticulo, iidEscandalloNuevo, iidProduccion, 1))
            Else
                listaArticulosModificados(indiceModificados).gCantidad = 1 + CInt(listaArticulosModificados(indiceModificados).gCantidad)
            End If
        End If
        If dtsEQ.gVersion <> dtsCP.gVersion Then
            dtsEQ.gVersion = dtsCP.gVersion
            HayCambios = True
        End If
        If dtsEQ.gidEscandallo <> iidEscandallo Then
            dtsEQ.gidEscandallo = iidEscandallo
            HayCambios = True
        End If
        If HayCambios Then funcEQ.actualizar(dtsEQ)
        If dtsEQ.gidConceptoAlbaran <> 0 Then
            funcEQ.CambiaridConceptoAlbaran(dtsEQ.gidEquipo, 0)
        End If
        Return HayCambios
    End Function

    Private Function CambiosProduccion(ByRef dtsPR As DatosConceptoProduccion, ByVal dtsCP As DatosConceptoPedido, ByVal iidEscandallo As Integer) As Boolean
        Dim HayCambios As Boolean = False
        If dtsPR.gCantidad <> dtsCP.gCantidad Then

            dtsPR.gCantidad = dtsCP.gCantidad
            HayCambios = True
        End If
        If dtsPR.gidConceptoPedido <> dtsCP.gidConcepto Then
            dtsPR.gidConceptoPedido = dtsCP.gidConcepto
            HayCambios = True
        End If
        If dtsPR.gidArticulo <> dtsCP.gidArticulo Then
            dtsPR.gObservaciones = "Equipo original: " & dtsPR.gcodArticulo & vbCrLf & dtsPR.gObservaciones
            dtsPR.gObservaciones = Microsoft.VisualBasic.Left(dtsPR.gObservaciones, 200)
            dtsPR.gidArticulo = dtsCP.gidArticulo
            HayCambios = True
        End If
        If dtsPR.gVersion <> dtsCP.gVersion Then
            dtsPR.gVersion = dtsCP.gVersion
            HayCambios = True
        End If
        If dtsPR.gidEscandallo <> iidEscandallo Then
            dtsPR.gidEscandallo = iidEscandallo
            HayCambios = True
        End If
        If dtsPR.gidArtCli <> dtsCP.gidArtCli Then
            dtsPR.gidArtCli = dtsCP.gidArtCli
            HayCambios = True
        End If
        If HayCambios Then funcCR.actualizar(dtsPR)
        Return HayCambios
    End Function

    Private Function IndexOfListaArticulosModificados(ByVal codArticuloOriginal As String, ByVal codArticuloNuevo As String) As Integer
        If listaArticulosModificados Is Nothing OrElse listaArticulosModificados.Count = 0 Then Return -1
        For i = 0 To listaArticulosModificados.Count - 1
            With listaArticulosModificados(i)
                If .gcodArticuloOriginal = codArticuloOriginal And .gcodArticuloNuevo = codArticuloNuevo Then Return i
            End With
        Next
        Return -1
    End Function

    Private Sub AsignarIdProduccionEquiposNoUtilizados(ByVal indiceArray As Integer, ByVal iidProduccionAnterior As Integer, ByVal iidProduccionCreada As Integer)
        Dim listaEQUtilizados As New List(Of Long)
        For Each dts As DatosEquipoProduccion In ArrayDeListas(indiceArray)
            If dts.gidProduccion = iidProduccionAnterior Then listaEQUtilizados.Add(dts.gidEquipo)
        Next
        'Obtenemos la lista de equipos de la producción no utilizados 
        Dim listaEQIdPRoduccion As List(Of Long) = funcEQ.Listar(iidProduccionAnterior)

        Dim listaEQRestantes As List(Of Long) = listaEQIdPRoduccion.Except(listaEQUtilizados).ToList
        For Each iidEquipo As Long In listaEQRestantes
            funcEQ.CambiarIdProduccion(iidEquipo, iidProduccionCreada)
        Next
    End Sub

    Private Function CrearEquipos(ByVal dtsCP As DatosConceptoProduccion, ByVal iCantidad As Integer) As Integer

        Dim dtsEQ As DatosEquipoProduccion
        Dim CantidadEquipos As Integer = funcEQ.Contador(dtsCP.gidProduccion)
        Dim dtsAR As DatosArticulo = funcAR.Mostrar1(dtsCP.gidArticulo)
        Dim VistaTaller As Boolean
        Dim VistaElectronica As Boolean
        Dim iidArticuloBase As Integer = funcEC.idArticuloBase(dtsCP.gidEscandallo)
        If iidArticuloBase = 0 Then
            VistaTaller = funcEC.VistaTaller(dtsCP.gidArticulo)
            VistaElectronica = funcEC.VistaElectronica(dtsCP.gidArticulo)
        Else
            'Si el artículo tiene artículo base, lo usaremos para determinar las vistas
            VistaTaller = funcEC.VistaTaller(iidArticuloBase)
            VistaElectronica = funcEC.VistaElectronica(iidArticuloBase)
        End If

        Dim vista As String
        'hemos de buscar los componentes con producción separada

        Dim listaPS As List(Of DatosConceptoEquipoProduccion) = funcEQ.MostrarProduccionSeparada(dtsCP.gidArticulo, dtsCP.gVersion)
        Dim texto As String = ""
        If dtsAR.gProduccionSeparada Then
            'En el caso de que el propio artículo ya sea de producción separada, lo añadimos a la lista para tratarlo como a los demás, incluida la generación de concepto 
            Dim dtsPS As New DatosConceptoEquipoProduccion
            dtsPS.gidConcepto = 0
            dtsPS.gidEquipo = 0
            dtsPS.gCantidad = 1
            dtsPS.gidEstadoTaller = 0
            dtsPS.gidEstadoElectronica = 0
            dtsPS.gidEstado = 0
            dtsPS.gidEtiqueta = 0
            'Datos de otras tablas
            dtsPS.gObservaciones = ""
            dtsPS.gidProduccion = 0
            dtsPS.gnumSerie = ""
            dtsPS.gidArticulo = dtsCP.gidArticulo
            dtsPS.gidEscandallo = dtsCP.gidEscandallo
            dtsPS.gcodArticulo = dtsAR.gcodArticulo
            dtsPS.gArticulo = dtsAR.gArticulo
            dtsPS.gEstado = ""
            dtsPS.gEstadoTaller = ""
            dtsPS.gEstadoElectronica = ""
            dtsPS.gEtiqueta = ""
            dtsPS.gVersion = dtsCP.gVersion
            listaPS.Add(dtsPS)
        Else
            texto = "El artículo ni ninguno de sus componentes está marcado como PRODUCCIÓN SEPARADA."
        End If
        If listaPS.Count = 0 Then
            'Si no tenemos ningún componente en la lista, verificaremos que tiene escandallo y lo añadiremos como equipo a producir y como concepto de Equipo
            If iidArticuloBase = 0 Then
                If funcEC.ExisteEscandalloRealmente(dtsAR.gidArticulo) Then
                    Dim dtsPS As New DatosConceptoEquipoProduccion
                    dtsPS.gidConcepto = 0
                    dtsPS.gidEquipo = 0
                    dtsPS.gCantidad = 1
                    dtsPS.gidEstadoTaller = 0
                    dtsPS.gidEstadoElectronica = 0
                    dtsPS.gidEstado = 0
                    dtsPS.gidEtiqueta = 0
                    'Datos de otras tablas
                    dtsPS.gObservaciones = ""
                    dtsPS.gidProduccion = 0
                    dtsPS.gnumSerie = ""
                    dtsPS.gidArticulo = dtsCP.gidArticulo
                    dtsPS.gidEscandallo = dtsCP.gidEscandallo
                    dtsPS.gcodArticulo = dtsAR.gcodArticulo
                    dtsPS.gArticulo = dtsAR.gArticulo
                    dtsPS.gEstado = ""
                    dtsPS.gEstadoTaller = ""
                    dtsPS.gEstadoElectronica = ""
                    dtsPS.gEtiqueta = ""
                    dtsPS.gVersion = dtsCP.gVersion
                    listaPS.Add(dtsPS)
                Else
                    texto = If(texto = "", "", vbCrLf) & "El artículo no dispone de desglose de escandallo."
                End If
            ElseIf funcEC.ExisteEscandalloRealmente(iidArticuloBase) Then
                'Si tiene artículo base y este tiene escandallo, lo añadimos a la lista
                Dim dtsPS As New DatosConceptoEquipoProduccion
                dtsPS.gidConcepto = 0
                dtsPS.gidEquipo = 0
                dtsPS.gCantidad = 1
                dtsPS.gidEstadoTaller = 0
                dtsPS.gidEstadoElectronica = 0
                dtsPS.gidEstado = 0
                dtsPS.gidEtiqueta = 0
                'Datos de otras tablas
                dtsPS.gObservaciones = ""
                dtsPS.gidProduccion = 0
                dtsPS.gnumSerie = ""
                dtsPS.gidArticulo = dtsCP.gidArticulo
                dtsPS.gidEscandallo = dtsCP.gidEscandallo
                dtsPS.gcodArticulo = dtsAR.gcodArticulo
                dtsPS.gArticulo = dtsAR.gArticulo
                dtsPS.gEstado = ""
                dtsPS.gEstadoTaller = ""
                dtsPS.gEstadoElectronica = ""
                dtsPS.gEtiqueta = ""
                dtsPS.gVersion = dtsCP.gVersion
                listaPS.Add(dtsPS)
            Else
                texto = If(texto = "", "", vbCrLf) & "El artículo base no dispone de desglose de escandallo."
            End If
        End If

        If listaPS.Count = 0 Then
            MsgBox("El artículo " & dtsAR.gcodArticulo & " - " & dtsAR.gArticulo & vbCrLf & "No se puede producir porque: " & vbCrLf & texto)
        Else
            'Creamos los equipos
            Dim CantidadEquiposAProducir = iCantidad - CantidadEquipos
            For x As Int16 = 1 To CantidadEquiposAProducir
                dtsEQ = New DatosEquipoProduccion
                dtsEQ.gidProduccion = dtsCP.gidProduccion
                dtsEQ.gnumSerie = 0 ' funcEQ.nuevoNumSerie
                dtsEQ.gidArticulo = dtsCP.gidArticulo
                dtsEQ.gidEscandallo = dtsCP.gidEscandallo
                dtsEQ.gFechaInicio = Now.Date
                dtsEQ.gFechaFin = dtsCP.gFechaPrevista
                dtsEQ.gidPersona = 0 'cbResponsable.SelectedItem.itemData
                dtsEQ.gObservaciones = dtsCP.gObservaciones
                dtsEQ.gVersion = dtsCP.gVersion
                If VistaElectronica Then
                    dtsEQ.gidEstadoElectronica = idEstadoEspera
                Else
                    dtsEQ.gidEstadoElectronica = idEstadoAnulado
                End If
                If VistaTaller Then
                    dtsEQ.gidEstadoTaller = idEstadoEspera
                Else
                    dtsEQ.gidEstadoTaller = idEstadoAnulado
                End If
                If VistaElectronica Or VistaTaller Then
                    dtsEQ.gidEstado = idEstadoEspera
                Else
                    dtsEQ.gidEstado = idEstadoAnulado
                End If
                dtsEQ.gidEquipo = funcEQ.insertar(dtsEQ)
                pbCarga.Increment(1)
                Application.DoEvents()
                'Ahora creamos los componentes de producción separada
                For Each dtsPS As DatosConceptoEquipoProduccion In listaPS
                    vista = funcAR.Vista(dtsPS.gidArticulo)
                    If vista = "ELECTRÓNICA" Then
                        dtsPS.gidEstadoElectronica = idEstadoEspera
                    Else
                        dtsPS.gidEstadoElectronica = idEstadoAnulado
                    End If
                    If vista = "TALLER" Then
                        dtsPS.gidEstadoTaller = idEstadoEspera
                    Else
                        dtsPS.gidEstadoTaller = idEstadoAnulado
                    End If
                    If vista = "ELECTRÓNICA" Or vista = "TALLER" Then
                        dtsPS.gidEstado = idEstadoEspera
                    Else
                        dtsPS.gidEstado = idEstadoAnulado
                    End If
                    dtsPS.gidEquipo = dtsEQ.gidEquipo

                    dtsPS.gidEtiqueta = dtsEQ.gidEtiqueta  'Esto no debería ser, las etiquetas deberían venir del escandallo del artículo
                    For Cant = 1 To dtsPS.gCantidad 'Guardamos un concepto por cada unidad (aunque existe un campo Cantidad, lo ignoramos)
                        dtsPS.gidConcepto = funcCEQ.insertar(dtsPS)

                    Next
                    Dim dtsAP As DatosArticuloPrecio = funcAP.Precio(dtsPS.gidArticulo, "C")
                    If x = CantidadEquiposAProducir Then 'Al creae el ultimo equipo, descontamos el stock de todos
                        Call DescuentaStock(CantidadEquiposAProducir * dtsPS.gCantidad, dtsPS.gidEscandallo, dtsCP.gidProduccion, dtsAP.gcodMoneda, dtsAP.gPrecio)
                    End If

                Next
            Next
            If dtsCP.gidEstado = funcES.EstadoEntregado("PRODUCCION").gidEstado Then
                'Se la producción está sólo recibida y hemos creado algún equipo, pasamos al estado Espera (Preparado para producir)
                dtsCP.gidEstado = funcES.EstadoEspera("PRODUCCION").gidEstado
                dtsCP.gEstado = funcES.Estado(dtsCP.gidEstado)
                funcCP.CambiarEstado(dtsCP.gidProduccion, dtsCP.gidEstado)
            End If
            Return iCantidad - CantidadEquipos
        End If
    End Function

    Public Sub DescuentaStock(ByVal Cant As Integer, ByVal iidEscandallo As Integer, ByVal iidProduccion As Integer, ByVal sCodMonedaC As String, ByVal dPrecioUnitarioC As Double)
        'Descuenta del stock los componentes del equipo, actúa de forma recursiva con los artículos que tienen escandallo
        Dim listaSK As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(iidEscandallo, True, 0)
        'Dim dtsSK As DatosStock
        For Each dts As DatosConceptoEscandallo In listaSK
            If dts.gExisteEscandallo > 0 Then
                DescuentaStock(Cant * dts.gCantidad, dts.gExisteEscandallo, iidProduccion, sCodMonedaC, dPrecioUnitarioC)
            Else
                Call InsertarMovimientoStock(dts.gidArticulo, dts.gCantidad * Cant, dts.gidTipoUnidad, iidProduccion, dPrecioUnitarioC, sCodMonedaC, "")
                'dtsSK = New DatosStock
                'dtsSK.gCantidad = -dts.gCantidad * Cant
                'dtsSK.gcodMoneda = sCodMonedaC
                'dtsSK.gFecha = Now
                'dtsSK.gidAlmacen = 0
                'dtsSK.gidArticulo = dts.gidArticulo
                'dtsSK.gidArticuloProv = 0
                'dtsSK.gidConceptoAlbaran = 0
                'dtsSK.gidConceptoPedido = 0
                'dtsSK.gidConceptoProv = 0
                'dtsSK.gidLote = 0
                'dtsSK.gidPersona1 = Inicio.vIdUsuario
                'dtsSK.gidPersona2 = 0
                'dtsSK.gidProduccion = iidProduccion
                'dtsSK.gidUnidad = dts.gidTipoUnidad
                'dtsSK.gMovimiento = ""
                'dtsSK.gPrecio = dPrecioUnitarioC
                'dtsSK.gidStock = funcSK.insertar(dtsSK)
            End If

        Next

    End Sub

    Private Sub DuplicarLineaPedido(ByVal iidConcepto As Long, ByVal CantidadProducir As Double, ByVal CantidadRestante As Double)
        'Cambiar la cantidad de la linea original
        'Duplicar una linea de pedido: Con la cantidad restante y el estado original
        Dim dts As DatosConceptoPedido = funcCP.Mostrar1(iidConcepto)
        'Primero modificamos la cantidad del concepto original
        dts.gCantidad = CantidadProducir
        funcCP.actualizar(dts)
        'A continuación creamos la nueva linea de pedido
        dts.gCantidad = CantidadRestante
        funcCP.insertar(dts)
        'Finalmente, renumeramos los conceptos
        funcCP.Renumerar(dts.gnumPedido)

    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click, lvConceptos.SelectedIndexChanged
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            With lvConceptos.Items(indice)
                lbUnidad.Text = .SubItems(8).Text
                lbUnidad2.Text = lbUnidad.Text
                Cantidad.Text = .SubItems(7).Text
                DeStock.Text = .SubItems(6).Text
                codArticulo.Text = .SubItems(1).Text
            End With
            bUsarStock.Enabled = True
        End If
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DeStock.Click, codArticulo.Click
        sender.selectall()
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress, DeStock.KeyPress, codArticulo.KeyPress
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

    Private Sub DeStock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(DeStock.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub


    Private Sub bUsarStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUsarStock.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Dim GG As New BusquedaEquipos
            GG.pModo = "LIBERADOS"
            GG.pidArticulo = lvConceptos.Items(indice).SubItems(10).Text
            GG.pCantidadEquipos = lvConceptos.Items(indice).SubItems(5).Text
            GG.pListaEquipos = CargarListasEQSeleccionados(indice)
            GG.pListaEquiposYaSeleccionados = listaEquiposYaSeleccioandos
            GG.ShowDialog()
            DeStock.Text = GG.pListaEquipos.Count
            Cantidad.Text = CInt(lvConceptos.Items(indice).SubItems(5).Text) - DeStock.Text
            ListaEquiposStock = New List(Of DatosEquipoProduccion)
            If GG.pListaEquipos.Count > 0 Then
                For Each iidEquipo As Integer In GG.pListaEquipos
                    ListaEquiposStock.Add(funcEQ.Mostrar1(iidEquipo))
                Next
            End If
        End If

    End Sub


    Private Function CargarListasEQSeleccionados(ByVal indice As Integer) As List(Of Long)
        'Cargar listaEquiposYaSeleccionados con todos los equipos excepto los del índice indicado
        'Devuelve la lista de equipos seleccionados en el índice (para que aparezcan ya seleccionados si volvemos a entrar en la búsqueda
        listaEquiposYaSeleccioandos = New List(Of Long)
        Dim listaEQ As New List(Of Long)
        For i = 0 To ArrayDeListas.Count - 1
            If i = indice Then
                For Each dts As DatosEquipoProduccion In ArrayDeListas(i)
                    listaEQ.Add(dts.gidEquipo)
                Next
            Else
                For Each dts As DatosEquipoProduccion In ArrayDeListas(i)
                    listaEquiposYaSeleccioandos.Add(dts.gidEquipo)
                Next
            End If
        Next
        Return listaEQ
    End Function

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call Limpiar()
    End Sub


End Class