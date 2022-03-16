Public Class subPedidoStock

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
    Private Prioridad As Byte
    Private idEstadoAnulado As Integer
    Private idEstadoEnCurso As Integer
    Private idEstadoEspera As Integer
    Private idEstadoCompleto As Integer


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
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

    Public Property pPrioridad() As Byte
        Get
            Return Prioridad
        End Get
        Set(ByVal value As Byte)
            Prioridad = value
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
        If Prioridad = 3 Then rbProd3.Checked = True Else rbProd3.Checked = False
        If Prioridad = 2 Then rbProd2.Checked = True Else rbProd2.Checked = False
        If Prioridad = 1 Then rbProd1.Checked = True Else rbProd1.Checked = False
        lista = New List(Of DatosConceptoPedido)
        For Each iidConcepto As Long In Conceptos
            lista.Add(funcCP.Mostrar1(iidConcepto))
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
        If Prioridad = 3 Then rbProd3.Checked = True Else rbProd3.Checked = False
        If Prioridad = 2 Then rbProd2.Checked = True Else rbProd2.Checked = False
        If Prioridad = 1 Then rbProd1.Checked = True Else rbProd1.Checked = False
        indice = -1
    End Sub

    Private Sub CargarConceptos()
        For Each dts As DatosConceptoPedido In lista
            With lvConceptos.Items.Add(dts.gidConcepto)
                .SubItems.Add(dts.gcodArticulo)
                .SubItems.Add(dts.gArticulo)
                .SubItems.Add(dts.gCantidadStock)
                .SubItems.Add(dts.gCantidad)
                .SubItems.Add("0")
                .SubItems.Add(dts.gCantidad)
                
                .SubItems.Add(dts.gTipoUnidad)
                .SubItems.Add(Prioridad)
                Select Case Prioridad
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
                .SubItems(4).Text = dts.gCantidadStock & dts.gTipoUnidad
                If dts.gCantidad > dts.gCantidadStock Then
                    .SubItems(5).Text = (dts.gCantidad - dts.gCantidadStock)
                Else
                    .SubItems(5).Text = "0"
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

                If CDbl(DeStock.Text) > CDbl(.SubItems(3).Text) Then DeStock.Text = .SubItems(3).Text
                .SubItems(5).Text = DeStock.Text
                If CDbl(Cantidad.Text) > CDbl(.SubItems(4).Text) Then Cantidad.Text = .SubItems(4).Text
                .SubItems(6).Text = Cantidad.Text
                If CDbl(DeStock.Text) + CDbl(Cantidad.Text) > .SubItems(4).Text Then
                    DeStock.Text = CDbl(.SubItems(4).Text) - CDbl(Cantidad.Text)
                    .SubItems(5).Text = DeStock.Text
                End If
                If rbProd1.Checked Then
                    .SubItems(8).Text = 1
                    .ForeColor = Color.Red
                End If
                If rbProd2.Checked Then
                    .SubItems(8).Text = 2
                    .ForeColor = Color.Orange
                End If
                If rbProd3.Checked Then
                    .SubItems(8).Text = 3
                    .ForeColor = Color.Green
                End If
            End With
            Call Limpiar()
        End If

    End Sub


    Private Sub pProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bProduccion.Click
        'Análisis de las cantidades: verificar si hay unidades que no están en stock ni se producen: esto generará lineas adicionales en el pedido
        Dim dts As DatosConceptoPedido
        Dim Producir As Double = 0
        Dim DelStock As Double = 0
        Dim respuesta As MsgBoxResult = MsgBoxResult.Ok
        For Each item As ListViewItem In lvConceptos.Items
            If respuesta <> MsgBoxResult.Cancel Then
                dts = funcCP.Mostrar1(item.Text)
                item.SubItems(3).Text = dts.gCantidadStock 'Recargamos el stock por si ha cambiado

                Producir = item.SubItems(6).Text
                DelStock = item.SubItems(5).Text
                If DelStock < 0 Then DelStock = 0 'No tratamos el caso de stock negativo
                If DelStock > dts.gCantidadStock Then DelStock = dts.gCantidadStock
                If DelStock < 0 Then DelStock = 0 'No tratamos el caso de stock negativo
                If Producir < (dts.gCantidad - DelStock) Then
                    respuesta = MsgBox("Quedarían " & dts.gCantidad - DelStock - Producir & dts.gTipoUnidad & " pendientes de " & dts.gcodArticulo & ". " & vbCrLf & "¿Crear una nueva linea de pedido con estas unidades?", MsgBoxStyle.OkCancel)
                    If respuesta = MsgBoxResult.Ok Then
                        Call DuplicarLineaPedido(item.Text, Producir + DelStock, dts.gCantidad - DelStock - Producir)
                        item.SubItems(4).Text = Producir + DelStock
                    End If

                End If

            End If
        Next
        'Crear las producciones
        If respuesta <> MsgBoxResult.Cancel Then
            Dim contador As Integer = 0

            Dim iidEstadoPR As Integer = funcES.EstadoEspera("PRODUCCION").gidEstado
            Dim iidEstadoCP As Integer = funcES.EstadoCPedido("RECIBIDO PRODUCCION").gidEstado
            Dim iidEstadoCL As Integer = funcES.EstadoCPedido("ENVIADO PRODUCCION").gidEstado
            Dim CantidadEquipos As Integer = 0
            For Each item As ListViewItem In lvConceptos.Items
                CantidadEquipos = CantidadEquipos + item.SubItems(6).Text
            Next
            pbCarga.Maximum = CantidadEquipos
            pbCarga.Value = 0
            pbCarga.Visible = True
            For Each item As ListViewItem In lvConceptos.Items
                If item.SubItems(5).Text = "" Then item.SubItems(5).Text = 0
                If item.SubItems(5).Text > 0 Then
                    'Si cogemos algo del stock enviaremos directamente a logística
                    funcCP.CambiarEstado(item.Text, iidEstadoCL)

                    'Modificamos la cantida producida del concepto de pedido
                    funcPE.actualizaEstado(inumPedido, funcES.EstadoPedido("PRODUCCION").gidEstado)
                End If

                If item.SubItems(6).Text = "" Then item.SubItems(6).Text = 0
                If item.SubItems(6).Text > 0 Then
                    Dim dtsCP As DatosConceptoPedido = funcCP.Mostrar1(item.Text)
                    Dim dtsPR As New DatosConceptoProduccion
                    dtsPR.gidProduccion = 0
                    dtsPR.gnumAlbaran = 0
                    dtsPR.gidArticulo = dtsCP.gidArticulo
                    dtsPR.gCantidad = item.SubItems(6).Text
                    dtsPR.gidEstado = iidEstadoPR
                    dtsPR.gidArtCli = dtsCP.gidArtCli
                    dtsPR.gidConceptoPedido = dtsCP.gidConcepto
                    dtsPR.gPrioridad = item.SubItems(8).Text
                    dtsPR.gFechaPrevista = funcPE.FechaEntrega(dtsCP.gnumPedido)
                    dtsPR.gFechaFin = dtsPR.gFechaPrevista
                    dtsPR.gObservaciones = funcCL.ObservacionesProd(funcPE.idCliente(dtsCP.gnumPedido))
                    dtsPR.gidPersona = Inicio.vIdUsuario
                    dtsPR.gVersion = dtsCP.gVersion
                    If Not funcAR.conVersiones(dtsPR.gidArticulo) Then dtsPR.gVersion = 0
                    dtsPR.gidEscandallo = funcEC.ExisteEscandalloVersionUltima(dtsCP.gidArticulo, dtsCP.gVersion)

                    If dtsPR.gidEscandallo = 0 Then
                        MsgBox("No existe escandallo válido para la versión " & dtsCP.gVersion & " de " & If(dtsCP.gcodArticulo = "", dtsCP.gArticulo, dtsCP.gcodArticulo) & vbCrLf & "Se debe crear la nueva versión para poder enviar a producción.")

                    Else
                        dtsPR.gidProduccion = funcCR.insertar(dtsPR)

                        dtsPR = funcCR.Mostrar1(dtsPR.gidProduccion)

                        'Crear los equipos
                        contador = contador + CrearEquipos(dtsPR, item.SubItems(6).Text)
                        'Cambiar el estado del concepto de pedido
                        funcCP.CambiarEstado(dtsCP.gidConcepto, iidEstadoCP)
                    End If

                End If

            Next
            If contador > 0 Then
                funcPE.actualizaEstado(inumPedido, funcES.EstadoPedido("PRODUCCION").gidEstado)
                pbCarga.Visible = False
                If contador = 1 Then
                    MsgBox("Se ha creado un equipo nuevo para producir.")
                Else
                    MsgBox("Se han creado " & contador & " equipos nuevos para producir.")
                End If

            End If
            cambios = False
            Me.Close()
        End If
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
            For x As Int16 = 1 To iCantidad - CantidadEquipos
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
                'dtsEQ.gidSeccion = dtsCP.gidSeccion

                dtsEQ.gidEquipo = funcEQ.insertar(dtsEQ)
                pbCarga.Increment(1)
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
                    Call DescuentaStock(dtsPS.gCantidad, dtsPS.gidEscandallo, dtsCP.gidProduccion, dtsAP.gcodMoneda, dtsAP.gPrecio)
                Next
            Next
            'Call DescuentaStock(iCantidad - CantidadEquipos, dtsCP.gidEscandallo, dtsCP.gidProduccion, dtsAR.gcodMonedaC, dtsAR.gPrecioUnitarioC)
            If dtsCP.gidEstado = funcES.EstadoEntregado("PRODUCCION").gidEstado Then
                'Se la producción está sólo recibida y hemos creado algún equipo, pasamos al estado Espera (Preparado para producir)
                dtsCP.gidEstado = funcES.EstadoEspera("PRODUCCION").gidEstado
                dtsCP.gEstado = funcES.Estado(dtsCP.gidEstado)
                funcCP.CambiarEstado(dtsCP.gidProduccion, dtsCP.gidEstado)
            End If

            Return iCantidad - CantidadEquipos
            'End If
        End If

    End Function

    Public Sub DescuentaStock(ByVal Cant As Integer, ByVal iidEscandallo As Integer, ByVal iidProduccion As Integer, ByVal sCodMonedaC As String, ByVal dPrecioUnitarioC As Double)
        'Descuenta del stock los componentes del equipo, actúa de forma recursiva con los artículos que tienen escandallo
        Dim lista As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(iidEscandallo, True, 0)
        Dim dtsSK As DatosStock
        For Each dts As DatosConceptoEscandallo In lista
            If dts.gExisteEscandallo > 0 Then
                DescuentaStock(Cant * dts.gCantidad, dts.gExisteEscandallo, iidProduccion, sCodMonedaC, dPrecioUnitarioC)
            Else
                dtsSK = New DatosStock
                dtsSK.gCantidad = -dts.gCantidad * Cant
                dtsSK.gcodMoneda = sCodMonedaC
                dtsSK.gFecha = Now
                dtsSK.gidAlmacen = 0
                dtsSK.gidArticulo = dts.gidArticulo
                dtsSK.gidArticuloProv = 0
                dtsSK.gidConceptoAlbaran = 0
                dtsSK.gidConceptoPedido = 0
                dtsSK.gidConceptoProv = 0
                dtsSK.gidLote = 0
                dtsSK.gidPersona1 = Inicio.vIdUsuario
                dtsSK.gidPersona2 = 0
                dtsSK.gidProduccion = iidProduccion
                dtsSK.gidUnidad = dts.gidTipoUnidad
                dtsSK.gMovimiento = ""
                dtsSK.gPrecio = dPrecioUnitarioC
                dtsSK.gidStock = funcSK.insertar(dtsSK)
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
                lbUnidad.Text = .SubItems(7).Text
                lbUnidad2.Text = lbUnidad.Text
                Cantidad.Text = .SubItems(6).Text
                DeStock.Text = .SubItems(5).Text
            End With
        End If
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, DeStock.Click
        sender.selectall()
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress, DeStock.KeyPress
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


End Class