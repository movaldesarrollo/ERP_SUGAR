Public Class GestionLogistica

    'Visualizamos todas las lineas de pedido en estado apropiado

    Private vSoloLectura As Boolean
    Private iidUsuario As Integer
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstados
    Private funcCR As New FuncionesConceptosProduccion
    Private funcCP As New FuncionesConceptosPedidos
    Private funcCL As New funcionesclientes
    Private funcPE As New FuncionesPedidos
    Private funcSK As New FuncionesStock
    Private funcEQ As New FuncionesEquiposProduccion
    Private sBusqueda As String
    Private sBusquedaL As String ' Esta búsqueda afecta sólo a Conceptos Pedidos, no a producción
    Private cambioFechasPrevistas As Boolean
    Private cambioFechasPedido As Boolean
    Private OrdenD As String
    Private DireccionD As String
    Private semanaActual As Byte
    Private colorInactivo As Color = Color.Gray
    Private columnaD As Integer
    Private semaforo As Boolean
    Private cambios As Boolean
    Private iidArticulo As Integer
    Private iidCliente As Integer
    Private indice As Integer
    Private iidProduccion As Long
    Private iidConcepto As Long
    Public inumPedido As Integer
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private EstadoCPPreparado As DatosEstado
    Private EstadoCPCreado As DatosEstado
    Private EstadoCPServido As DatosEstado
    Private EstadoCPLogistica As DatosEstado
    Private EstadoCPRecibido As DatosEstado
    Private EstadoCPProducido As DatosEstado

    Private EstadoCRTraspasado As DatosEstado
    Private EstadoPEPreparado As DatosEstado
    Private EstadoPEParcial As DatosEstado
    Private EstadoEQAcabado As DatosEstado
    'Identificadores de estado de Conceptos de Producción
    Private idEstadoCPRecibido As Integer
    Private idEstadoCPParcial As Integer
    Private idEstadoCPAcabado As Integer
    Private idEstadoCPEnCurso As Integer
    Private idEstadoCPEspera As Integer



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
            Return inumPedido
        End Get
        Set(ByVal value As Integer)
            inumPedido = value
        End Set
    End Property

    Private Sub GestionLogistica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        bServir.Enabled = Not vSoloLectura
        Dim funcP As New FuncionesPersonal
        bVerCliente.Enabled = funcP.Permiso(Inicio.vIdUsuario, "ConsultaCliente")
        bVerArticulo.Enabled = funcP.Permiso(Inicio.vIdUsuario, "BusquedaSimpleArticulo") Or funcP.Permiso(Inicio.vIdUsuario, "BusquedaArticulo")

        semanaActual = DatePart(DateInterval.WeekOfYear, Now.Date)
        If semanaActual = 53 And DatePart(DateInterval.Weekday, Now.Date) < 7 Then semanaActual = 1
        DireccionD = "DESC"
        columnaD = 0
        OrdenD = "Estado DESC, IdProduccion "
        cambios = False
        semaforo = False

        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        ckSeleccion.Checked = False
        ckSeleccion.Visible = True
        Call introducirClientes()
        Call limpiarFiltro()
        If inumPedido > 0 Then
            'Si hemos pasado por parámetro en número de pedido, lo cargamos en el campo de búsqueda junto con el cliente e inhabilitamos estos campos.
            cbnumPedido.Enabled = False
            cbnumPedido.Text = inumPedido
            Dim dtsPE As DatosPedido = funcPE.Mostrar1(inumPedido)
            cbCliente.Text = dtsPE.gCliente
            cbCodCliente.SelectedIndex = cbCliente.SelectedIndex
            cbCliente.Enabled = False
            cbCodCliente.Enabled = False
            bBuscarCliente.Enabled = False
        Else
            cbnumPedido.Enabled = True
            'Si no hemos indicado un pedido por parámetro, cargamos la lista de numPedido
            Call IntroducirPedidos()
            cbnumPedido.AutoCompleteMode = AutoCompleteMode.Append
            cbnumPedido.AutoCompleteSource = AutoCompleteSource.ListItems
        End If
        Call IntroducirArticulos()

        Call IntroducirEstados()
        EstadoCPPreparado = funcES.EstadoCPedido("PREPARADO")
        EstadoCPCreado = funcES.EstadoCPedido("CREADO")
        EstadoCPServido = funcES.EstadoCPedido("SERVIDO")
        EstadoCPLogistica = funcES.EstadoCPedido("ENVIADO PRODUCCION")
        EstadoCPRecibido = funcES.EstadoCPedido("RECIBIDO PRODUCCION")
        EstadoCPProducido = funcES.EstadoCPedido("PRODUCIDO")
        EstadoCRTraspasado = funcES.EstadoTraspasado("PRODUCCION")
        EstadoPEPreparado = funcES.EstadoPedido("PREPARADO")
        EstadoEQAcabado = funcES.EstadoCompleto("EQUIPO")
        EstadoPEParcial = funcES.EstadoPedido("PARCIAL")
        'Estados de Concepto de producción
        idEstadoCPRecibido = funcES.EstadoEntregado("PRODUCCION").gidEstado
        idEstadoCPParcial = funcES.EstadoAutomatico("PRODUCCION").gidEstado
        idEstadoCPAcabado = funcES.EstadoCompleto("PRODUCCION").gidEstado
        idEstadoCPEnCurso = funcES.EstadoEnCurso("PRODUCCION").gidEstado
        idEstadoCPEspera = funcES.EstadoEspera("PRODUCCION").gidEstado
        semaforo = True
        Call busqueda()
    End Sub

    Private Sub GestionLogistica_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub


#Region "INICIALIZACIÓN"

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCodCliente.Items.Add(New IDComboBox(dts.gcodCli, dts.gidCliente))
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub IntroducirArticulos()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3)
        lista = funcAR.Listar("ESCANDALLO")
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub

    Private Sub IntroducirEstados()
        cbEstado.Items.Clear()
        'Aqui debería haber estados de producción y pedidos??
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("PRODUCCION")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub


    Private Sub IntroducirPedidos()
        cbnumPedido.Items.Clear()
        Dim lista As List(Of Integer) = funcPE.listaNum(0)
        For Each item As Integer In lista
            cbnumPedido.Items.Add(item)
        Next
    End Sub

    Private Sub limpiarFiltro()
        'Si hemos pasado por parámetro el número de pedido, estárá inabilitado numPedido, el codCliente y el Cliente y no se tocarán al limpiar.
        If cbCliente.Enabled Then
            cbCliente.SelectedIndex = -1
            cbCliente.Text = ""
        End If
        If cbCodCliente.Enabled Then
            cbCodCliente.SelectedIndex = -1
            cbCodCliente.Text = ""
        End If
        If cbCodArticulo.Enabled Then
            cbCodArticulo.Text = ""
            cbCodArticulo.SelectedIndex = -1
        End If
        If cbArticulo.Enabled Then
            cbArticulo.Text = ""
            cbArticulo.SelectedIndex = -1
        End If
        If cbnumPedido.Enabled Then
            cbnumPedido.Text = ""
            cbnumPedido.SelectedIndex = -1
        End If

        ckVerAcabados.Checked = True
        rbTodos.Checked = True
        rbFiltro1.Checked = False
        rbFiltro2.Checked = False
        rbFiltro3.Checked = False
        dtpFechaPedidoDesde.Value = funcPE.buscaPrimerDia
        dtpFechaPedidoHasta.Value = funcPE.buscaUltimoDia
        dtpFechaPrevistaDesde.Value = funcCR.buscaPrimerDia
        dtpFechaPrevistaHasta.Value = funcCR.buscaUltimoDia
        cambioFechasPedido = False
        cambioFechasPrevistas = False
    End Sub

    Private Sub LimpiarEdicion()
        codArticulo.Text = ""
        Articulo.Text = ""
        Preparados.Text = 0
        numSerieDesde.Text = ""
        NumSerieHasta.Text = ""
        indice = -1
        iidConcepto = 0
        iidProduccion = 0
        inumPedido = 0
    End Sub
#End Region

#Region "CARGAR DATOS"

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub busqueda()

        sBusqueda = "" 'Búsqueda para los conceptos de producción
        sBusquedaL = ""  'Búsqueda para los conceptos de pedido
        If cbCliente.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PE.idCliente = " & cbCliente.SelectedItem.itemdata
        End If
        If cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.idArticulo = " & cbArticulo.SelectedItem.itemdata
        ElseIf cbArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.Articulo like '%" & cbArticulo.Text & "%' "
        End If

        If cbCodArticulo.Text <> "" And cbCodArticulo.SelectedIndex = -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.codArticulo like '" & cbCodArticulo.Text & "%' "
        End If
        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If

        If cambioFechasPedido Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), PE.fecha,103))  >= '" & dtpFechaPedidoDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PE.fecha,103))  <= '" & dtpFechaPedidoHasta.Value.Date & "' "
        End If

        If cbnumPedido.Text <> "" And IsNumeric(cbnumPedido.Text) Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PE.numPedido = " & cbnumPedido.Text
        End If

        If ckVerAcabados.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Estados.Bloqueado = 0 " 'Para ver los que no están traspasados (no se han servido)
        End If
        sBusquedaL = sBusqueda
        If cambioFechasPrevistas Then
            'En pedidos tenemos el campo FechaEntrega para todo el pedido. En Conceptos de Producción es FechaPrevista y es una para cada linea. Pueden ser diferentes.
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusquedaL = sBusquedaL & IIf(sBusquedaL = "", "", " AND ")
            sBusqueda = sBusqueda & " ((PE.numPedido is null AND CONVERT(datetime,CONVERT(Char(10), PE.fechaEntrega,103))  >= '" & dtpFechaPrevistaDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PE.fechaEntrega,103))  <= '" & dtpFechaPrevistaHasta.Value.Date & "') OR "
            sBusqueda = sBusqueda & " (PE.numPedido>0 AND CONVERT(datetime,CONVERT(Char(10), CP.fechaPrevista,103))  >= '" & dtpFechaPrevistaDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), CP.fechaPrevista,103))  <= '" & dtpFechaPrevistaHasta.Value.Date & "'))  "
            sBusquedaL = sBusquedaL & " (PE.numPedido is null AND CONVERT(datetime,CONVERT(Char(10), PE.fechaEntrega,103))  >= '" & dtpFechaPrevistaDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), PE.fechaEntrega,103))  <= '" & dtpFechaPrevistaHasta.Value.Date & "')  "
        End If
        If rbFiltro1.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusquedaL = sBusquedaL & IIf(sBusquedaL = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.Prioridad = 1 "
            sBusquedaL = sBusquedaL & " PE.Prioridad = 1 "

        End If
        If rbFiltro2.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusquedaL = sBusquedaL & IIf(sBusquedaL = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.Prioridad = 2 "
            sBusquedaL = sBusquedaL & " PE.Prioridad = 2 "
        End If
        If rbFiltro3.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusquedaL = sBusquedaL & IIf(sBusquedaL = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.Prioridad = 3 "
            sBusquedaL = sBusquedaL & " PE.Prioridad = 3 "
        End If
        Call ActualizarLV()


    End Sub

    Private Sub ActualizarLV()
        Try
            lvConceptos.Items.Clear()
            'lvwColumnSorter = New OrdenarLV()
            'lvconceptos.ListViewItemSorter = lvwColumnSorter
            Dim lista As List(Of DatosConceptoProduccion)

            lista = funcCR.MostrarLogistica(sBusqueda, sBusquedaL, OrdenD & " " & DireccionD)

            For Each dts As DatosConceptoProduccion In lista
                NuevaLineaLV(dts)
            Next
            Call CalculaTotal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CalculaTotal()
        Dim suma As Double = 0
        Dim sumaEstaSemana As Double = 0
        Dim sumaSemanaProxima As Double = 0
        Dim suma2Semanas As Double = 0
        Dim sumaMasSemanas As Double = 0
        'Dim semanaActual As Byte = DatePart(DateInterval.WeekOfYear, Now.Date)
        Dim semanaPrevista As Byte = 0
        For Each item As ListViewItem In lvConceptos.Items
            suma = suma + item.SubItems(5).Text
            'Dim kk As Date = CDate(item.SubItems(10).Text)
            semanaPrevista = DatePart(DateInterval.WeekOfYear, CDate(item.SubItems(12).Text))
            If CDate(item.SubItems(12).Text) < Now.Date Or semanaPrevista = semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                sumaEstaSemana = sumaEstaSemana + item.SubItems(5).Text
            ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                sumaSemanaProxima = sumaSemanaProxima + item.SubItems(5).Text
            ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                suma2Semanas = suma2Semanas + item.SubItems(5).Text
            Else
                sumaMasSemanas = sumaMasSemanas + item.SubItems(5).Text
            End If
        Next
        EstaSemana.Text = sumaEstaSemana
        SemanaProxima.Text = sumaSemanaProxima
        En2Semanas.Text = suma2Semanas
        EnMasSemanas.Text = sumaMasSemanas
        Total.Text = suma
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosConceptoProduccion)
        With lvConceptos.Items.Add(" ") '0
            .SubItems.Add(dts.gidProduccion) '1
            .SubItems.Add(dts.gidArticulo) '2
            .SubItems.Add(dts.gcodArticulo) '3
            .SubItems.Add(dts.gArticulo) '4
            .SubItems.Add(dts.gCantidad) '5
            .SubItems.Add(dts.gAcabados) '6
            .SubItems.Add(funcCP.CantidadPreparada(dts.gidConceptoPedido)) '7
            Select Case dts.gidEstado
                Case idEstadoCPAcabado, EstadoCPLogistica.gidEstado, EstadoCPProducido.gidEstado, EstadoCPPreparado.gidEstado
                    .ForeColor = Color.Green
                    .SubItems.Add("PRODUCIDO")
                Case idEstadoCPParcial
                    .ForeColor = Color.Orange
                    .SubItems.Add("PRODUCCIÓN")
                Case idEstadoCPEspera, EstadoCPRecibido.gidEstado
                    .ForeColor = Color.Black
                    .SubItems.Add("PRODUCCIÓN")
                Case idEstadoCPEnCurso
                    .ForeColor = Color.Orange
                    .SubItems.Add("PRODUCCIÓN")
                Case EstadoCPCreado.gidEstado
                    .SubItems.Add(dts.gEstado) '8
                    .ForeColor = Color.Gray
                Case EstadoCPServido.gidEstado
                    .SubItems.Add("SERVIDO")
                    .ForeColor = Color.Gray
                Case Else
                    .SubItems.Add("")
            End Select
            If dts.gPrioridad = 1 Then
                .BackColor = Color.LightPink
            End If



            .SubItems.Add(dts.gCliente) '9
            .SubItems.Add(If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido))) '10
            .SubItems.Add(If(dts.gnumPedido = 0, "", CStr(dts.gFechaPedido))) '11
            .SubItems.Add(If(dts.gnumPedido = 0, dts.gFechaPrevista, dts.gFechaEntrega)) '12
            .SubItems.Add(dts.gPrioridad) '13
            .SubItems.Add(funcSK.CantidadStock(dts.gidArticulo)) '1
            .SubItems.Add(dts.gidConceptoPedido)
            .SubItems.Add(funcCP.CantidadServida(dts.gidConceptoPedido))
            .SubItems.Add(dts.gVersion)

        End With
    End Sub


#End Region

#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bLimpiaFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiaFiltro.Click
        Call limpiarFiltro()
    End Sub

    Private Sub bServir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bServir.Click
        'Si hay algo preparado lo pone en el estado apropiado para servir
        Dim N As Integer = lvConceptos.CheckedItems.Count
        If ckSeleccion.Visible And N > 0 Then
            Dim Conceptos As New List(Of Long)
            Dim iidConcepto As Integer
            For Each item As ListViewItem In lvConceptos.CheckedItems
                iidConcepto = item.SubItems(15).Text
                'Verificamos que la linea no haya sido ya traspasada
                If item.SubItems(7).Text = 0 Then
                    item.Checked = False
                Else
                    Conceptos.Add(iidConcepto)
                End If
            Next
            N = N - lvConceptos.CheckedItems.Count
            If N = 1 Then
                MsgBox("Se ha desactivado un concepto sin elementos preparados.")
            End If
            If N > 1 Then
                MsgBox("Se han desactivado " & N & " conceptos sin elementos preparados.")
            End If
            If Conceptos.Count = 0 Then
                If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
            Else
                If MsgBox("¿Hacer que el pedido quede PREPARADO con las lineas marcadas?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Modificaremos el campo CANTIDAD PREPARADA del concepto de pedido
                    Dim CantidadPreparada As Double = 0
                    Dim Cantidad As Double = 0
                    Dim numeroPedido As Integer = 0
                    For Each item As ListViewItem In lvConceptos.CheckedItems
                        iidConcepto = item.SubItems(15).Text
                        If iidConcepto <> 0 Then
                            CantidadPreparada = item.SubItems(7).Text
                            Cantidad = item.SubItems(5).Text
                            If numeroPedido <> item.SubItems(10).Text Then
                                numeroPedido = item.SubItems(10).Text
                                'Si estamos aqui es que hay algo preparado del pedido
                                If funcPE.idEstado(numeroPedido) <> EstadoPEParcial.gidEstado Then
                                    'Ponemos el pedido en estado Preparado si no está parcial
                                    funcPE.actualizaEstado(numeroPedido, EstadoPEPreparado.gidEstado)
                                    'Si lo estamos dando por preparado, pondremos el RECOGIDO = False (podríamos haber servido algo antes)
                                    funcPE.CambiaRecogido(numeroPedido, False)
                                End If

                            End If
                            funcCP.CambiarCantidadPreparada(iidConcepto, CantidadPreparada)

                            If CantidadPreparada >= Cantidad - funcCP.CantidadServida(iidConcepto) Then
                                'Si está todo preparado cambiamos a estado preparado
                                funcCP.CambiarEstado(iidConcepto, EstadoCPPreparado.gidEstado)
                            End If
                        End If
                    Next

                    If numeroPedido > 0 Then
                        Dim GG As New subParamentrosServir
                        GG.pnumPedido = inumPedido
                        GG.pCliente = cbCliente.Text
                        GG.ShowDialog()
                        If GG.DialogResult = Windows.Forms.DialogResult.OK Then
                            MsgBox("Asignaciones realizadas.")
                            Call ActualizarLV()
                        End If

                    End If

                End If

            End If
        Else
            MsgBox("No hay ningun concepto seleccionado.")
        End If


    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call LimpiarEdicion()
    End Sub

    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim cliente As String = cbCliente.Text
            Dim codcli As Integer = cbCodCliente.Text
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            iidCliente = cbCodCliente.SelectedItem.itemdata
            GG.pidCliente = iidCliente
            GG.ShowDialog()
            If cbCliente.Enabled Then 'Si no está habilitado el cliente, no hacemos nada
                'Si está habilitado recargamos la lista por si ha cambiado algo
                Call introducirClientes()
                'Volvemos a introducir el nombre y código original
                cbCliente.Text = cliente
                cbCodCliente.Text = codcli
                If cbCliente.SelectedIndex = -1 Then 'Si no los encuentra es que han cambiado, en ese caso los dejamos en blanco
                    cbCliente.Text = ""
                    cbCodCliente.Text = ""
                    iidCliente = 0
                End If
            End If
        End If
    End Sub

    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticulo.Click
        If cbArticulo.SelectedIndex <> -1 Then
            iidArticulo = cbArticulo.SelectedItem.itemdata
            Dim scodArticulo As String = cbCodArticulo.Text
            Dim sArticulo As String = cbArticulo.Text
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.pModo = "DOC"
            GG.ShowDialog()
            If cbArticulo.Enabled Then 'Si no está habilitado el artículo, no hacemos nada
                'Si está habilitado recargamos la lista por si ha cambiado algo
                Call IntroducirArticulos()
                'Volvemos a introducir el nombre y código original
                cbCodArticulo.Text = scodArticulo
                cbArticulo.Text = sArticulo
                If cbArticulo.SelectedIndex = -1 Then 'Si no los encuentra es que han cambiado, en ese caso los dejamos en blanco
                    cbArticulo.Text = ""
                    cbCodArticulo.Text = ""
                    iidArticulo = 0
                End If
            End If

        End If
    End Sub

    Private Sub bBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarCliente.Click
        If cbCliente.Enabled Then
            Dim GG As New busquedaCliente
            GG.SoloLectura = vSoloLectura
            GG.pModo = "B"
            GG.ShowDialog()
            If GG.pidCliente > 0 Then
                Dim dtsCL As datoscliente = funcCL.mostrar1(GG.pidCliente)
                cbCodCliente.Text = dtsCL.gcodCli
                cbCliente.Text = dtsCL.gnombrecomercial
                iidCliente = GG.pidCliente
                cambios = True
            End If
        End If
    End Sub

    Private Sub bBuscarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticulo.Click
        If cbArticulo.Enabled Then
            Dim GG As New BusquedaSimpleArticulo
            GG.SoloLectura = vSoloLectura
            GG.pModo = "CONCEPTO"
            GG.ShowDialog()
            If GG.pidArticulo > 0 Then
                iidArticulo = GG.pidArticulo
                Dim dtsAR As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                cbArticulo.Text = dtsAR.gArticulo
                cbCodArticulo.Text = dtsAR.gcodArticulo
            End If
        End If

    End Sub
#End Region

#Region "EVENTOS"

    Private Sub lvConceptos_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptos.ColumnClick
        If e.Column = columnaD Then
            If DireccionD = "ASC" Then
                DireccionD = "DESC"
            Else
                DireccionD = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 
        Select Case e.Column
            Case 0
                OrdenD = "idProduccion"
            Case 1
                OrdenD = "idArticulo"
            Case 2
                OrdenD = "codArticulo"
            Case 3
                OrdenD = "Articulo"
            Case 4
                OrdenD = "Cantidad"
            Case 5
                OrdenD = "Cantidad" 'La columna Acabados se calcula por programa, no se puede incluir en la sentencia sql
            Case 6
                OrdenD = "Cantidad" 'La columna Preparados se calcula por programa, no se puede incluir en la sentencia sql
            Case 7
                OrdenD = "Estado"
            Case 8
                OrdenD = "Cliente"
            Case 9
                OrdenD = "numPedido"
            Case 10
                OrdenD = "PE.Fecha"
            Case 11
                OrdenD = "FechaPrevista" '"case when PE.numPedido is null then FechaPrevista else FechaEntrega end"
            Case 12
                OrdenD = "Prioridad"
            Case Else
                OrdenD = "codArticulo"
        End Select
        columnaD = e.Column
        Call ActualizarLV()

    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedIndexChanged
        If semaforo Then
            If cbCodArticulo.SelectedIndex <> -1 Then
                semaforo = False
                If Trim(cbCodArticulo.Text).Length > 0 Then
                    iidArticulo = cbCodArticulo.SelectedItem.itemdata
                    ' cbArticulo.Text = funcAR.Articulo(iidArticulo)
                    cbArticulo.SelectedIndex = cbCodArticulo.SelectedIndex
                End If
                semaforo = True
                Call busqueda()
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedIndexChanged
        If semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                'cbCodArticulo.Text = funcAR.codArticulo(iidArticulo)
                cbCodArticulo.SelectedIndex = cbArticulo.SelectedIndex
                semaforo = True
                Call busqueda()
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbArticulo.TextChanged
        If semaforo Then
            If cbArticulo.SelectedIndex = -1 Then busqueda()
        End If

    End Sub


    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged
        If semaforo Then
            If cbCodArticulo.SelectedIndex = -1 Then busqueda()
        End If
    End Sub

    Private Sub cbCodCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodCliente.SelectedIndexChanged
        If semaforo Then
            If cbCodCliente.SelectedIndex <> -1 Then
                semaforo = False
                If Trim(cbCodCliente.Text).Length > 0 Then
                    iidCliente = cbCodCliente.SelectedItem.itemdata
                    cbCliente.SelectedIndex = cbCodCliente.SelectedIndex
                End If
                semaforo = True
                Call busqueda()
            End If
            cambios = True
        End If
    End Sub

    Private Sub cbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedIndexChanged
        If semaforo Then
            If cbCliente.SelectedIndex <> -1 Then
                semaforo = False
                iidCliente = cbCliente.SelectedItem.itemdata
                cbCodCliente.SelectedIndex = cbCliente.SelectedIndex
                semaforo = True
                Call busqueda()
            End If
            cambios = True
        End If
    End Sub




    Private Sub dtpFechaPedido_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaPedidoDesde.ValueChanged, dtpFechaPedidoHasta.ValueChanged
        If semaforo Then
            cambioFechasPedido = True
            Call busqueda()
        End If
    End Sub


    Private Sub dtpFechaPrevista_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaPrevistaDesde.ValueChanged, dtpFechaPrevistaHasta.ValueChanged
        If semaforo Then
            cambioFechasPrevistas = True
            Call busqueda()
        End If
    End Sub

    Private Sub rbFiltro1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFiltro1.CheckedChanged, rbFiltro2.CheckedChanged, rbFiltro2.CheckedChanged, rbTodos.CheckedChanged
        If semaforo Then Call busqueda()
    End Sub

    Private Sub cbnumPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbnumPedido.SelectedIndexChanged
        If semaforo Then Call busqueda()
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Preparados.KeyPress, numSerieDesde.KeyPress, NumSerieHasta.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles lvConceptos.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            With lvConceptos.Items(indice)
                iidProduccion = .SubItems(1).Text
                iidConcepto = .SubItems(15).Text
                codArticulo.Text = .SubItems(3).Text
                Articulo.Text = .SubItems(4).Text
                Preparados.Text = .SubItems(6).Text - .SubItems(7).Text

                'Preasignar nº Serie
                If Preparados.Text = "" Then Preparados.Text = 0
                If iidProduccion > 0 Then 'Sólo los que vienen de una producción llevan nº de serie
                    numSerieDesde.Text = CInt(funcEQ.nuevoNumSerie)
                    NumSerieHasta.Text = CInt(numSerieDesde.Text) + CInt(Preparados.Text)
                Else
                    numSerieDesde.Text = ""
                    NumSerieHasta.Text = ""
                End If
            End With
        End If
    End Sub

    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Dim Acabados As Integer = If(lvConceptos.Items(indice).SubItems(6).Text = "" Or lvConceptos.Items(indice).SubItems(6).Text = "0", 0, CInt(lvConceptos.Items(indice).SubItems(6).Text))
            iidProduccion = lvConceptos.Items(indice).SubItems(1).Text
            iidConcepto = lvConceptos.Items(indice).SubItems(15).Text
            Dim iidEstado As Integer = funcCP.idEstado(iidConcepto)
            iidArticulo = funcCP.idArticulo(iidConcepto)
            'If lvConceptos.Items(indice).SubItems(2).Text <> iidArticulo Then
            '    'Estamos ante una producción de un artículo diferente del pedido (posiblemente procede de una asignación de stock
            '    If MsgBox("El artículo indicado no se corresponde exactamente con el pedido. " & vbCrLf & "¿Desea convertirlo en el artículo exacto? " & vbCrLf & "(En esta fase se confirma la adaptación del artículo)", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            '        Call CambiarArticuloProduccion(iidProduccion, iidArticulo)

            '    End If
            'End If
            If iidEstado = EstadoCPCreado.gidEstado Then
                MsgBox("La linea de pedido aún no se ha enviado a Producción.")
            ElseIf iidEstado = EstadoCPServido.gidEstado Then
                MsgBox("La linea de pedido ya ha sido servida.")
            ElseIf iidProduccion = 0 Then
                'Si se trata de una linea de pedido que no se ha de producir
                Call AsignarLineaNoProducible(iidConcepto)
                'LUIS--------------------------------------------------------------------------------------------------------------------------------------------
                'ElseIf Acabados = 0 Then
                '    MsgBox("No hay equipos producidos en esta linea")
            Else
                Dim listaEquipos As List(Of DatosEquipoProduccion) = funcEQ.Busqueda(" EP.idProduccion = " & iidProduccion, " idEquipo ", 0)
                If EquiposSinAsignar(listaEquipos) = 0 Then
                    Dim CantidadYaPreparada = lvConceptos.Items(indice).SubItems(7).Text
                    Dim CantidadPosible = lvConceptos.Items(indice).SubItems(5).Text
                    Dim GG As New AsignarServir
                    GG.sololectura = vSoloLectura
                    GG.pidConcepto = iidConcepto
                    GG.pCantidadPreparada = CantidadYaPreparada
                    GG.pCantidadPosible = CantidadPosible
                    GG.ShowDialog()
                    If GG.pCantidadPreparada > 0 Then 'Solo actualizamos si no es 0 (significaría salir sin guardar)
                        If GG.pCantidadPreparada + CantidadYaPreparada > CantidadPosible Then
                            lvConceptos.Items(indice).SubItems(7).Text = CantidadPosible
                        Else
                            lvConceptos.Items(indice).SubItems(7).Text = GG.pCantidadPreparada + CantidadYaPreparada
                        End If
                    End If
                Else
                    'Dim GG As New AsignarNS
                    'Dim CantidadYaPreparada = lvConceptos.Items(indice).SubItems(7).Text
                    'GG.pCantidadPreparada = CantidadYaPreparada
                    'GG.soloLectura = vSoloLectura
                    'GG.plistaEquipos = listaEquipos
                    'GG.ShowDialog()
                    'Dim CantidadNoServida As Double = lvConceptos.Items(indice).SubItems(5).Text - lvConceptos.Items(indice).SubItems(16).Text
                    'If GG.pCantidadPreparada > CantidadNoServida Then
                    '    lvConceptos.Items(indice).SubItems(7).Text = CantidadNoServida  'La cantidad preparada no puede ser mayor que la pedida - servida
                    'ElseIf GG.pCantidadPreparada > CantidadYaPreparada Then 'Solo actualizamos si no es 0 (significaría salir sin guardar)
                    '    lvConceptos.Items(indice).SubItems(7).Text = GG.pCantidadPreparada
                    'End If
                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub CambiarArticuloProduccion(ByVal iidProduccion As Long, ByVal iidArticulo As Integer)
        'Cambiar el artículo y hacer cambios de stock correspondientes
        Dim dts As DatosConceptoProduccion = funcCR.Mostrar1(iidProduccion)
    End Sub

    Private Sub AsignarLineaNoProducible(ByVal iidConcepto As Long)
        If iidConcepto > 0 Then
            Dim Pedidos As Double = lvConceptos.Items(indice).SubItems(5).Text
            Dim Servidos As Double = lvConceptos.Items(indice).SubItems(16).Text
            Dim CantidadYaPreparada = lvConceptos.Items(indice).SubItems(7).Text
            If CantidadYaPreparada >= Pedidos - Servidos Then
                MsgBox("No quedan unidades pendientes de preparar.")
            Else
                'Si está en estado CREADO o SERVIDO, avisa y no hace nada
                Dim GG As New AsignarServir

                GG.sololectura = vSoloLectura
                GG.pidConcepto = iidConcepto
                GG.pCantidadPreparada = CantidadYaPreparada
                GG.ShowDialog()
                If GG.pCantidadPreparada > 0 Then 'Solo actualizamos si no es 0 (significaría salir sin guardar)
                    lvConceptos.Items(indice).SubItems(7).Text = GG.pCantidadPreparada + CantidadYaPreparada
                End If
            End If
        End If
    End Sub

    Private Function EquiposSinAsignar(ByVal listaEquipos As List(Of DatosEquipoProduccion)) As Integer
        Dim Contador As Integer = 0
        For Each dts As DatosEquipoProduccion In listaEquipos
            If dts.gnumSerie = 0 And dts.gAsignado = False Then Contador = Contador + 1
        Next
        Return Contador
    End Function

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

    Private Sub lvConceptos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvConceptos.MouseClick

        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            Dim Acabados As Integer = If(lvConceptos.Items(indice).SubItems(6).Text = "" Or lvConceptos.Items(indice).SubItems(6).Text = "0", 0, CInt(lvConceptos.Items(indice).SubItems(6).Text))
            iidProduccion = lvConceptos.Items(indice).SubItems(1).Text
            iidConcepto = lvConceptos.Items(indice).SubItems(15).Text
            Dim iidEstado As Integer = funcCP.idEstado(iidConcepto)
            iidArticulo = funcCP.idArticulo(iidConcepto)
            Dim listaEquipos As List(Of DatosEquipoProduccion) = funcEQ.Busqueda(" EP.idProduccion = " & iidProduccion, " idEquipo ", 0)

            If e.Button = Windows.Forms.MouseButtons.Right And listaEquipos.Count > 0 Then
                Dim GG As New AsignarNS
                Dim CantidadYaPreparada = lvConceptos.Items(indice).SubItems(7).Text
                GG.pCantidadPreparada = CantidadYaPreparada
                GG.soloLectura = vSoloLectura
                GG.plistaEquipos = listaEquipos
                GG.ShowDialog()
                Dim CantidadNoServida As Double = lvConceptos.Items(indice).SubItems(5).Text - lvConceptos.Items(indice).SubItems(16).Text
                If GG.pCantidadPreparada > CantidadNoServida Then
                    lvConceptos.Items(indice).SubItems(7).Text = CantidadNoServida  'La cantidad preparada no puede ser mayor que la pedida - servida
                ElseIf GG.pCantidadPreparada > CantidadYaPreparada Then 'Solo actualizamos si no es 0 (significaría salir sin guardar)
                    lvConceptos.Items(indice).SubItems(7).Text = GG.pCantidadPreparada
                End If
            End If
        End If
    End Sub

End Class