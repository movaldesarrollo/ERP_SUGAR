Public Class ReasignarEquipos

    Private vSoloLectura As Boolean
    Private vEstadoStock As Boolean
    Private funcPE As New FuncionesPedidos
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcCP As New FuncionesConceptosPedidos
    Private funcCR As New FuncionesConceptosProduccion
    Private funcES As New FuncionesEstados
    Private funcAR As New FuncionesArticulos
    Private funcSK As New FuncionesStock
    Private funcEC As New FuncionesEscandallos
    Private funcCEQ As New FuncionesConceptosEquiposProduccion
    Private iidEquipo As Long
    Private iidEquipos As List(Of Long)
    Private sBusqueda As String
    Private indice As Integer
    Private dtsEQ As DatosEquipoProduccion
    Private semaforo As Boolean
    Private iidArticuloBase As Integer
    Private iidArticulo As Integer

    'Identificadores de estado de equipos
    Private idEstadoEQEspera As Integer
    Private idEstadoEQEnCurso As Integer
    Private idEstadoEQAcabado As Integer
    Private idEstadoEQAnulado As Integer


    Private idEstadoCPCreado As Integer
    Private idEstadoCPEnviado As Integer
    Private idEstadoCPRecibido As Integer
    Private idEstadoCPProduccion As Integer
    Private idEstadoCPProducido As Integer
    Private ideEstadoCPPreparado As Integer
    Private idEstadoCPServido As Integer
    'Identificadores de estado de Conceptos de Producción
    Private idEstadoCPrRecibido As Integer
    Private idEstadoCPrEspera As Integer
    Private idEstadoCPrEnCurso As Integer
    Private idEstadoCPrAcabado As Integer
    Private idEstadoCPrTraspasado As Integer
    Private idEstadoCPrParcial As Integer
    'Identificadores de estado de Pedido
    Private idEstadoPECabecera As Integer
    Private idEstadoPEPendiente As Integer
    Private idEstadoPEAnulado As Integer
    Private idEstadoPEProduccion As Integer
    Private idEstadoPEProducido As Integer
    Private idEstadoPEPreparado As Integer
    Private idEstadoPEServido As Integer
    Private idEstadoPEParcial As Integer


    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property
    Public Property estadoStock() As Boolean
        Get
            Return vEstadoStock
        End Get
        Set(ByVal value As Boolean)
            vEstadoStock = value
        End Set
    End Property


    Public Property pnumPedidoActual() As Integer
        Get
            Return cbPedidoActual.Text
        End Get
        Set(ByVal value As Integer)
            cbPedidoActual.Text = value
        End Set
    End Property

    Public Property pidEquipos() As List(Of Long)
        Get
            Return iidEquipos
        End Get
        Set(ByVal value As List(Of Long))
            iidEquipos = value
        End Set
    End Property

    Public Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property


    Private Sub ReasignarEquipos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'PERMISOS
        semaforo = True
        If vEstadoStock = True Then
            rbStock.Enabled = False
        End If
        Dim funcP As New FuncionesPersonal
        vSoloLectura = vSoloLectura Or funcP.Parametro(Inicio.vIdUsuario, "ReasignarEquipos", "SOLO LECTURA")
        bverPedidoActual.Enabled = funcP.Permiso(Inicio.vIdUsuario, "BusquedaPedidos")
        bVerPedidoNuevo.Enabled = bverPedidoActual.Enabled
        bGuardar.Enabled = Not vSoloLectura
        rbPedido.Checked = True
        ckSeleccion.Location = New Point(lvEquipos.Location.X + 6, lvEquipos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        'Identificadores de estado de equipos
        idEstadoEQEspera = funcES.EstadoEspera("EQUIPO").gidEstado
        idEstadoEQEnCurso = funcES.EstadoEnCurso("EQUIPO").gidEstado
        idEstadoEQAcabado = funcES.EstadoCompleto("EQUIPO").gidEstado
        idEstadoEQAnulado = funcES.EstadoAnulado("EQUIPO").gidEstado
        'Identificadores de estado de Conceptos de Pedido
        idEstadoCPCreado = funcES.EstadoCPedido("CREADO").gidEstado
        idEstadoCPEnviado = funcES.EstadoCPedido("ENVIADO PRODUCCION").gidEstado
        idEstadoCPRecibido = funcES.EstadoCPedido("RECIBIDO PRODUCCION").gidEstado
        idEstadoCPProduccion = funcES.EstadoCPedido("EN PRODUCCION").gidEstado
        idEstadoCPProducido = funcES.EstadoCPedido("PRODUCIDO").gidEstado
        ideEstadoCPPreparado = funcES.EstadoCPedido("PREPARADO").gidEstado
        idEstadoCPServido = funcES.EstadoCPedido("SERVIDO").gidEstado
        'Identificadores de estado de Conceptos de Producción
        idEstadoCPrRecibido = funcES.EstadoEntregado("PRODUCCION").gidEstado
        idEstadoCPrEspera = funcES.EstadoEspera("PRODUCCION").gidEstado
        idEstadoCPrEnCurso = funcES.EstadoEnCurso("PRODUCCION").gidEstado
        idEstadoCPrAcabado = funcES.EstadoCompleto("PRODUCCION").gidEstado
        idEstadoCPrTraspasado = funcES.EstadoTraspasado("PRODUCCION").gidEstado
        idEstadoCPrParcial = funcES.EstadoAutomatico("PRODUCCION").gidEstado
        'Identificadores de estado de Pedido
        idEstadoPECabecera = funcES.EstadoPedido("CABECERA").gidEstado
        idEstadoPEPendiente = funcES.EstadoPedido("PENDIENTE").gidEstado
        idEstadoPEAnulado = funcES.EstadoPedido("ANULADO").gidEstado
        idEstadoPEProduccion = funcES.EstadoPedido("PRODUCCION").gidEstado
        idEstadoPEProducido = funcES.EstadoPedido("PRODUCIDO").gidEstado
        idEstadoPEPreparado = funcES.EstadoPedido("PREPARADO").gidEstado
        idEstadoPEServido = funcES.EstadoPedido("SERVIDO").gidEstado
        idEstadoPEParcial = funcES.EstadoPedido("PARCIAL").gidEstado

        indice = -1
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        If Not iidEquipos Is Nothing Then
            If iidEquipos.Count > 0 Then
                'Si hemos llamado al formulario indicando equipos
                For Each iidEquipo As Integer In iidEquipos
                    dtsEQ = funcEQ.Mostrar1(iidEquipo)
                    nuevaLineaLV(dtsEQ)
                Next
                'Todos los equipos han de pertenecer al mismo pedido y artículo
                Me.Text = "REASIGNACIÓN DE EQUIPOS " & dtsEQ.gcodArticulo
                cbPedidoActual.Text = dtsEQ.gnumPedido
                iidArticuloBase = funcEC.idArticuloBaseArticulo(dtsEQ.gidArticulo)
                Call introducirNuevosPedidos()
                lvEquipos.Items(0).Checked = True
                ckSeleccion.Checked = True
                Encontrados.Text = lvEquipos.Items.Count
            End If
        End If
        If cbPedidoActual.Text <> "" And cbPedidoActual.Text <> "0" Then
            'Si hemos llamado al formulario especificando el pedido o es el pedido del equipo indicado
            Dim dtsPE As DatosPedido = funcPE.Mostrar1(cbPedidoActual.Text)
            ClienteActual.Text = dtsPE.gCliente
            cbPedidoActual.Enabled = False
            If iidArticulo = 0 Then

            Else
                Dim lista As List(Of DatosEquipoProduccion) = funcEQ.MostrarP(cbPedidoActual.Text, iidArticulo, 0)
                For Each Me.dtsEQ In lista
                    nuevaLineaLV(dtsEQ)
                Next
            End If
        Else
            Call introducirPedidosActuales()
        End If


    End Sub


   


#Region "INICIALIZACIÓN"



#End Region


#Region "CARGAR DATOS"

    Private Sub introducirNuevosPedidos()
        'Seleccionamos los pedidos posibles:
        'Que tenga un concepto del artículo seleccionado (o uno que tenga la misma base o sea la base) y que el concepto no esté en estado  CREADO  (o sea que esté en estado , ENVIADO, RECIBIDO, EN PRODUCCIÓN, PRODUCIDO, PREPARADO, SERVIDO)
        ' Y si está servido, que el albarán no esté servido ni facturado
        If Not dtsEQ Is Nothing Then
            Dim sel As String = ""
            sel = sel & " (select count(idConcepto) from ConceptosPedidos as CP left join Estados as EPE ON EPE.idEstado = CP.idEstado "
            sel = sel & " left join Escandallos ON Escandallos.idArticulo = CP.idArticulo "
            sel = sel & " left join Albaranes ON Albaranes.numAlbaran = CP.numAlbaran left join Estados as EA ON EA.idEstado = Albaranes.idEstado"
            If iidArticuloBase = 0 Then
                sel = sel & " where CP.Cantidad >= " & lvEquipos.Items.Count & " AND CP.idArticulo = " & dtsEQ.gidArticulo
            Else
                sel = sel & " where (CP.idArticulo in (" & dtsEQ.gidArticulo & ", " & iidArticuloBase & ") OR idArticuloBase = " & iidArticuloBase & ")  "
            End If
            sel = sel & " AND (select count(idEstado) from  Estados where Estados.idEstado = Pedidos.idEstado AND Estados.idEstado = Pedidos.idEstado AND Cabecera = 0 and Anulado = 0 )>0 "
            sel = sel & " AND numPedido = Pedidos.numPedido and (EPE.Traspasado = 1 or EPE.Completo = 1  or (EPE.Entregado = 1 and EA.Entregado = 0 and EA.Traspasado = 0  )))>0 "
            Dim lista As List(Of Integer) = funcPE.listaNum(sel)
            For Each numPedido As Integer In lista
                If numPedido <> cbPedidoActual.Text Then cbNuevoPedido.Items.Add(numPedido)
            Next
        End If

    End Sub

    Private Sub introducirPedidosActuales()
        'Seleccionamos los pedidos posibles:
        'Que no estén en estado CABECERA, ANULADO
        Dim lista As List(Of Integer)
        lista = funcPE.listaNum(" (select count(idEstado) from  Estados where Estados.idEstado = Pedidos.idEstado AND Estados.idEstado = Pedidos.idEstado AND Cabecera = 0 and Anulado = 0 )>0 ")
        For Each numPedido As Integer In lista
            cbPedidoActual.Items.Add(numPedido)
        Next
    End Sub


#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"


    'Private Sub ActualizarLV()
    '    If cbPedidoActual.Text <> "" Then

    '        lvEquipos.Items.Clear()
    '        Dim lista As List(Of DatosEquipoProduccion) = funcEQ.MostrarP(cbPedidoActual.Text)
    '        For Each dts As DatosEquipoProduccion In lista
    '            Call nuevaLineaLV(dts)
    '        Next
    '        Encontrados.Text = lvEquipos.Items.Count
    '    End If



    'End Sub

    Private Sub nuevaLineaLV(ByVal dts As DatosEquipoProduccion)
        With lvEquipos.Items.Add(" ")
            .SubItems.Add(dts.gidEquipo)
            .SubItems.Add(dts.gnumSerie)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            Select Case dts.gidEstado
                Case idEstadoEQEnCurso
                    .SubItems.Add("PRODUCCIÓN")
                    .ForeColor = Color.Orange
                Case idEstadoEQEspera
                    .SubItems.Add("PRODUCCIÓN")
                    .ForeColor = Color.Black
                Case idEstadoEQAcabado
                    If funcCP.idEstado(dts.gidConceptoPedido) = idEstadoCPServido Then
                        .SubItems.Add("SERVIDO")
                        .ForeColor = Color.Green
                    Else
                        .SubItems.Add("PRODUCIDO")
                        .ForeColor = Color.Green
                    End If
            End Select
            .Checked = True
        End With
    End Sub







#End Region




#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Try
            Dim validar As Boolean = True
            If validar And lvEquipos.CheckedItems.Count = 0 Then
                validar = False
                MsgBox("Se han de seleccionar los equipos a reasignar.")
            End If
            If rbPedido.Checked Then
                If cbNuevoPedido.SelectedIndex = -1 Then
                    validar = False
                    ep1.SetError(cbNuevoPedido, "Se ha de seleccionar el pedido al que asignar el equipo.")
                ElseIf cbNuevoPedido.Text = cbPedidoActual.Text Then
                    validar = False
                    ep1.SetError(cbNuevoPedido, "Se ha de seleccionar un pedido diferente al que asignar el equipo.")
                End If
            End If
            If validar Then
                Dim resultado As Boolean = True
                If rbPedido.Checked Then
                    For Each item As ListViewItem In lvEquipos.CheckedItems
                        iidEquipo = item.SubItems(1).Text
                        resultado = ReasignarEquipo()
                    Next
                    If resultado And lvEquipos.CheckedItems.Count = 1 Then
                        MsgBox("Equipo liberado y asignado al pedido indicado.")
                    End If
                    If resultado And lvEquipos.CheckedItems.Count > 1 Then
                        MsgBox(lvEquipos.CheckedItems.Count & " equipos liberados y asignados al pedido indicado.")
                    End If
                Else
                    Call LiberarAStock()
                    If lvEquipos.CheckedItems.Count = 1 Then
                        MsgBox("Equipo liberado.")
                    End If
                    If lvEquipos.CheckedItems.Count > 1 Then
                        MsgBox(lvEquipos.CheckedItems.Count & " equipos liberados.")
                    End If
                End If
                If resultado Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ex.Data.Add("Función", "ASIGNAR")
            ex.Data.Add("cbPedidoActual.text", cbPedidoActual.Text)
            ex.Data.Add("cbNuevoPedido.text", cbNuevoPedido.Text)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
        End Try
    End Sub

    Private Sub LiberarAStock()
        Try
            'Se crea un concepto de producción para recoger los equipos liberados
            Dim dtsCR As New DatosConceptoProduccion
            dtsCR.gnumAlbaran = 0
            dtsCR.gidArticulo = dtsEQ.gidArticulo
            dtsCR.gCantidad = lvEquipos.CheckedItems.Count
            dtsCR.gidEstado = funcES.EstadoCompleto("PRODUCCION").gidEstado 'Sólo liberamos equipos acabados 
            dtsCR.gidArtCli = 0
            dtsCR.gidConceptoPedido = 0
            dtsCR.gPrioridad = 3
            dtsCR.gFechaPrevista = dtsEQ.gFechaPrevista
            dtsCR.gFechaFin = dtsEQ.gFechaPrevista
            dtsCR.gObservaciones = ""
            dtsCR.gidPersona = Inicio.vIdUsuario
            dtsCR.gidProduccion = funcCR.insertar(dtsCR)
            Dim idSproduccion As New List(Of Long)
            Dim iidProduccion As Long = 0
            For Each item As ListViewItem In lvEquipos.CheckedItems
                iidEquipo = item.SubItems(1).Text

                iidProduccion = funcEQ.idProduccion(iidEquipo)
                If Not idSproduccion.Contains(iidProduccion) Then
                    idSproduccion.Add(iidProduccion)
                End If
                funcEQ.CambiarIdProduccion(iidEquipo, dtsCR.gidProduccion)

            Next
            'Añadir al stock
            Dim dtsSK As New DatosStock
            Dim dtsAR As DatosArticulo = funcAR.Mostrar1(dtsEQ.gidArticulo)
            dtsSK.gidArticulo = dtsEQ.gidArticulo
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
            funcSK.insertar(dtsSK)

            For Each iidProduccion In idSproduccion
                'Modificar el concepto de producción afectado
                Dim cantidad As Integer = funcEQ.Contador(iidProduccion)
                Dim iidConceptoPedido As Integer = funcCR.IdConceptoPedido(iidProduccion)
                If cantidad = 0 Then
                    'Tendremos que eliminar la producción
                    funcCR.borrar(iidProduccion)
                    'En este caso, el concepto de pedido relacionado sólo puede pasar al estado CREADO 
                    funcCP.CambiarEstado(iidConceptoPedido, idEstadoCPCreado)
                    'y hay que recalcular el estado del Pedido.
                    Call CalcularEstadoPedido(funcCP.numPedido(iidConceptoPedido))
                Else
                    'Modificar la producción
                    funcCR.CambiarCantidad(iidProduccion, cantidad)
                    'A continuación modificamos la cantidad del concepto original
                    funcCP.CambiarCantidad(iidConceptoPedido, cantidad)
                    'Actualizar estados referidos a la asignación anterior del equipo
                    ActualizarEstados(0, iidProduccion)
                End If
            Next
        Catch ex As Exception
            ex.Data.Add("Función", "LiberarAStock")
            ex.Data.Add("cbPedidoActual.text", cbPedidoActual.Text)
            ex.Data.Add("cbNuevoPedido.text", cbNuevoPedido.Text)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
        End Try
    End Sub

  


    Private Function ReasignarEquipo() As Boolean
        Try
            Dim resultado As Boolean = False
            If cbPedidoActual.Text <> "" And cbNuevoPedido.SelectedIndex <> -1 Then
                'Un equipo está asociado a un Pedido a través de un Concepto de Producción
                'Para hacer la reasignación, el equipo destino ha de existir. 
                'Como sólo especificamos el pedido destino, habría que seleccionar el primer equipo destino que no se haya empezado a producir.
                Dim lista As List(Of DatosEquipoProduccion) = funcEQ.MostrarP(cbNuevoPedido.Text, dtsEQ.gidArticulo, iidArticuloBase)
                If lista.Count > 0 Then
                    resultado = True
                    Dim i As Integer = 0
                    Dim iidEstado As Integer = lista(0).gidEstado
                    While i < lista.Count And iidEstado <> idEstadoEQEspera
                        i = i + 1
                        If i < lista.Count Then iidEstado = lista(i).gidEstado
                    End While
                    If i >= lista.Count Then
                        'Si no hay ninguno, pero hay alguno empezado coger el primero.
                        i = 0
                        iidEstado = lista(0).gidEstado
                        While i < lista.Count And iidEstado <> idEstadoEQEnCurso
                            i = i + 1
                            If i < lista.Count Then iidEstado = lista(i).gidEstado
                        End While
                        If i >= lista.Count Then
                            MsgBox("No se ha encontrado un equipo no producido en el pedido a asignar.")
                            resultado = False
                        End If
                    End If

                    Dim iidEquipoNuevo As Long = 0

                    If i < lista.Count Then
                        iidEquipoNuevo = lista(i).gidEquipo
                        Dim validar As Boolean = True
                        If dtsEQ.gidArticulo <> lista(i).gidArticulo Then
                            If MsgBox("Se reasigna un " & dtsEQ.gcodArticulo & " en el lugar de un  " & lista(i).gcodArticulo, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                                validar = False
                            End If
                        End If
                        If validar Then
                            'Intercambiaremos los idProducción entre el equipo origen y destino
                            Dim dtsEQNuevo As DatosEquipoProduccion = funcEQ.Mostrar1(iidEquipoNuevo)
                            If funcEQ.IntercambiarIdProduccion(iidEquipo, iidEquipoNuevo) Then
                                'Si se ha realizado el intercambio, hay que revisar los estados afectados en ConceptosProducción, ConceptosPedido y Pedidos



                                'Si hemos cambiado un equipo por otro diferente, con la misma base, hemos de itercambiar sus componentes
                                If dtsEQNuevo.gidArticulo <> dtsEQ.gidArticulo Then
                                    Call IntercambioArticuloyEscandallo(dtsEQNuevo)
                                    Call IntercambioConceptosEquipos(iidEquipoNuevo, iidEquipo)
                                End If
                                'Si el equipo está preparado (tiene numSerie), hemos de recalcular la cantidad preparada en el concepto de pedido
                                If dtsEQ.gnumSerie <> 0 Then
                                    Call RecalculoCantidadPreparada(dtsEQNuevo.gidProduccion)
                                End If
                                'Si tenía albarán ha que hacer cambios específicos
                                If dtsEQ.gnumAlbaran <> 0 Then
                                    Call CambiosAlbaran(dtsEQNuevo)
                                End If
                                Call ActualizarEstados(iidEquipo, 0)
                                Call ActualizarEstados(iidEquipoNuevo, 0)
                            End If
                        Else
                            resultado = False
                        End If
                        'MsgBox("Equipo liberado y asignado al pedido indicado.")
                    End If
                Else
                    MsgBox("No se han encontrado equipos a producir en el pedido a asignar")
                    resultado = False
                End If
            End If
            Return resultado
        Catch ex As Exception
            ex.Data.Add("Función", "ReasignarAEquipo")
            ex.Data.Add("cbPedidoActual.text", cbPedidoActual.Text)
            ex.Data.Add("cbNuevoPedido.text", cbNuevoPedido.Text)
            ex.Data.Add("iidArticulo", iidArticulo)
            CorreoError(ex)
        End Try
    End Function

    Private Sub IntercambioArticuloyEscandallo(ByVal dtsEQ2 As DatosEquipoProduccion)
        funcEQ.CambiarIdArticulo(dtsEQ.gidArticulo, dtsEQ2.gidArticulo, dtsEQ2.gidEscandallo)
        funcEQ.CambiarIdArticulo(dtsEQ2.gidArticulo, dtsEQ.gidArticulo, dtsEQ.gidEscandallo)
    End Sub

    Private Sub IntercambioConceptosEquipos(ByVal iidEquipo1 As Long, ByVal iidEquipo2 As Long)
        Dim ListaConceptosEquipo1 As List(Of DatosConceptoEquipoProduccion) = funcCEQ.Mostrar(iidEquipo1)
        Dim ListaConceptosEquipo2 As List(Of DatosConceptoEquipoProduccion) = funcCEQ.Mostrar(iidEquipo2)
        For Each dts As DatosConceptoEquipoProduccion In ListaConceptosEquipo1
            funcCEQ.CambiaridEquipo(dts.gidConcepto, iidEquipo2)
        Next
        For Each dts As DatosConceptoEquipoProduccion In ListaConceptosEquipo2
            funcCEQ.CambiaridEquipo(dts.gidConcepto, iidEquipo1)
        Next
    End Sub


    Private Sub RecalculoCantidadPreparada(ByVal iidProduccion2 As Long)


        Dim iidConceptoPedido1 As Long = funcCR.IdConceptoPedido(dtsEQ.gidProduccion)
        Dim iidConceptoPedido2 As Long = funcCR.IdConceptoPedido(iidProduccion2)

        'Dim CantidadPreparada1 As Double = funcCP.CantidadPreparada(iidConceptoPedido1)
        'Dim CantidadPReparada2 As Double = funcCP.CantidadPreparada(iidConceptoPedido2)
        'If CantidadPreparada1 > 0 Then
        '    CantidadPreparada1 = CantidadPreparada1 - 1
        '    funcCP.CambiarCantidadPreparada(iidConceptoPedido1, CantidadPreparada1)
        'End If
        'CantidadPReparada2 = CantidadPReparada2 + 1

        'funcCP.CambiarCantidadPreparada(iidConceptoPedido2, CantidadPReparada2)

        funcCP.CambiarCantidadPreparada(iidConceptoPedido1, funcCP.CantidadPreparadaRealmente(iidConceptoPedido1))
        funcCP.CambiarCantidadPreparada(iidConceptoPedido2, funcCP.CantidadPreparadaRealmente(iidConceptoPedido2))

    End Sub


    Private Sub CambiosAlbaran(ByVal dtsEQ2 As DatosEquipoProduccion)
        funcEQ.CambiaridConceptoAlbaran(dtsEQ.gidEquipo, dtsEQ2.gidConceptoAlbaran)
        funcEQ.CambiaridConceptoAlbaran(dtsEQ2.gidEquipo, dtsEQ.gidConceptoAlbaran)
        funcCR.CambiarNumAlbaran(dtsEQ.gidProduccion, dtsEQ.gnumAlbaran)
        funcCR.CambiarNumAlbaran(dtsEQ2.gidProduccion, dtsEQ2.gnumAlbaran)
        Dim funcCA As New FuncionesConceptosAlbaranes
        Dim funcAL As New FuncionesAlbaranes
        If dtsEQ.gidConceptoAlbaran > 0 Then 'Devolver el equipo al stock
            Dim dtsCA As DatosConceptoAlbaran = funcCA.Mostrar1(dtsEQ.gidConceptoAlbaran)
            Dim dtsST As New DatosStock
            dtsST.gidStock = 0
            dtsST.gidArticulo = dtsEQ.gidArticulo
            dtsST.gidAlmacen = 0
            dtsST.gCantidad = 1
            dtsST.gidUnidad = dtsCA.gidUnidad
            dtsST.gidLote = 0
            dtsST.gidArticuloProv = 0
            dtsST.gFecha = Now
            dtsST.gPrecio = dtsCA.gPrecioNetoUnitario
            dtsST.gcodMoneda = funcAL.codMoneda(dtsCA.gnumAlbaran)
            dtsST.gidConceptoProv = 0
            dtsST.gidConceptoPedido = 0
            dtsST.gidConceptoAlbaran = dtsCA.gidConcepto
            dtsST.gidProduccion = 0
            dtsST.gMovimiento = ""
            dtsST.gidPersona1 = Inicio.vIdUsuario
            dtsST.gidPersona2 = 0
            funcSK.insertar(dtsST)
        End If


    End Sub

    Private Sub CalcularEstadoPedido(ByVal inumPedido As Integer)
        'Si hemos borrado el concepto de producción y puesto un conceptoPedido en estado CREADO, 
        Dim iidEstado As Integer = funcPE.idEstado(inumPedido)
        Select Case iidEstado
            Case idEstadoPEAnulado
                'Lo dejamos como está
            Case idEstadoPECabecera
                'no es posible
            Case idEstadoPEPendiente
                'No es posible
            Case Else
                If funcCP.AlgunoTraspasado(inumPedido) Or funcCP.AlgunoPARCIAL(inumPedido) Then
                    funcPE.actualizaEstado(inumPedido, idEstadoPEParcial)
                ElseIf funcCP.AlgoPreparado(inumPedido) Then
                    funcPE.actualizaEstado(inumPedido, idEstadoPEPreparado)
                ElseIf funcCP.AlgunoenProduccion(inumPedido) Then
                    funcPE.actualizaEstado(inumPedido, idEstadoPEProduccion)
                Else
                    funcPE.actualizaEstado(inumPedido, idEstadoPEPendiente)
                End If
        End Select

    End Sub


    Private Sub ActualizarEstados(ByVal iidEquipo As Long, ByVal iidProduccion As Long)

        Dim inumPedido As Integer = 0
        Dim iidConcepto As Long = 0
        If iidProduccion = 0 Then
            Dim dtsEQ As DatosEquipoProduccion = funcEQ.Mostrar1(iidEquipo)
            iidProduccion = dtsEQ.gidProduccion
            inumPedido = dtsEQ.gnumPedido
            iidConcepto = dtsEQ.gidConceptoPedido
        Else
            Dim dtsCR As DatosConceptoProduccion = funcCR.Mostrar1(iidProduccion)
            inumPedido = dtsCR.gnumPedido
            iidConcepto = dtsCR.gidConceptoPedido
        End If

        Dim iidEstadoCP = funcCP.idEstado(iidConcepto)
        Dim iidEstadoPE As Integer = funcPE.idEstado(inumPedido)
        If funcEQ.TodosAcabados(iidProduccion) Then
            funcCR.CambiarEstado(iidProduccion, idEstadoCPrAcabado)
            If iidEstadoCP <> idEstadoCPServido Then
                funcCP.CambiarEstado(iidConcepto, idEstadoCPProducido)
            End If
            If iidEstadoPE <> idEstadoPECabecera And iidEstadoPE <> idEstadoPEParcial And iidEstadoPE <> idEstadoPEServido And iidEstadoPE <> idEstadoPEPreparado Then
                If funcCP.TodosCompletos(inumPedido) Then
                    funcPE.actualizaEstado(inumPedido, idEstadoPEProducido)
                Else
                    funcPE.actualizaEstado(inumPedido, idEstadoPEProduccion)
                End If
            End If
        ElseIf funcEQ.AlgunoAcabado(iidProduccion) Then
            funcCR.CambiarEstado(iidProduccion, idEstadoCPrParcial)
            If iidEstadoCP <> idEstadoCPServido Then
                funcCP.CambiarEstado(iidConcepto, idEstadoCPProduccion)
            End If
            If iidEstadoPE <> idEstadoPECabecera And iidEstadoPE <> idEstadoPEParcial And iidEstadoPE <> idEstadoPEServido And iidEstadoPE <> idEstadoPEPreparado Then
                funcPE.actualizaEstado(inumPedido, idEstadoPEProduccion)
            End If
        ElseIf funcEQ.AlgunoEnCurso(iidProduccion) Then
            funcCR.CambiarEstado(iidProduccion, idEstadoCPrEnCurso)
            If iidEstadoCP <> idEstadoCPServido Then
                funcCP.CambiarEstado(iidConcepto, idEstadoCPProduccion)
            End If
            If iidEstadoPE <> idEstadoPECabecera And iidEstadoPE <> idEstadoPEParcial And iidEstadoPE <> idEstadoPEServido And iidEstadoPE <> idEstadoPEPreparado Then
                funcPE.actualizaEstado(inumPedido, idEstadoPEProduccion)
            End If
        Else
            funcCR.CambiarEstado(iidProduccion, idEstadoCPrEspera)
            If iidEstadoCP <> idEstadoCPServido Then
                funcCP.CambiarEstado(iidConcepto, idEstadoCPRecibido)
            End If

            If iidEstadoPE <> idEstadoPECabecera And iidEstadoPE <> idEstadoPEParcial And iidEstadoPE <> idEstadoPEServido Then
                If funcCP.AlgunoenProduccion(inumPedido) Then
                    funcPE.actualizaEstado(inumPedido, idEstadoPEProduccion)
                ElseIf funcCP.AlgoPreparado(inumPedido) Then
                    funcPE.actualizaEstado(inumPedido, idEstadoPEPreparado)
                Else
                    funcPE.actualizaEstado(inumPedido, idEstadoPEPendiente)
                End If
            End If
        End If

    End Sub


    Private Sub bverPedidoActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bverPedidoActual.Click
        If cbPedidoActual.Text <> "" And cbPedidoActual.Text <> "0" Then
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = cbPedidoActual.Text
            GG.ShowDialog()
        End If
    End Sub


    Private Sub bVerPedidoNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerPedidoNuevo.Click
        If cbNuevoPedido.SelectedIndex <> -1 Then
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = cbNuevoPedido.Text
            GG.ShowDialog()
        End If
    End Sub


#End Region


#Region "EVENTOS"

    Private Sub cbPedidoActual_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPedidoActual.SelectedIndexChanged
        'Call ActualizarLV()
    End Sub

    Private Sub cbNuevoPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNuevoPedido.TextChanged, cbNuevoPedido.SelectedValueChanged
        If cbNuevoPedido.SelectedIndex <> -1 Then
            nuevoCliente.Text = funcPE.Cliente(cbNuevoPedido.Text)
            ep1.Clear()
        End If
    End Sub

    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        semaforo = False
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            For Each item As ListViewItem In lvEquipos.Items
                item.Checked = ckSeleccion.Checked
            Next
        End If
        semaforo = True
    End Sub

    Private Sub lvEquipos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvEquipos.ItemChecked
        'Al checkar una linea,cambiamos el estado de ckseleccion 
        If semaforo Then
            Dim cont As Integer = lvEquipos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvEquipos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub

    Private Sub rbPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPedido.CheckedChanged
        gbAsignarPedido.Enabled = rbPedido.Checked
    End Sub

#End Region








End Class