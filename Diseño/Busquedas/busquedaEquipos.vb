Public Class BusquedaEquipos

    Private desktopSize As Size
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcFA As New FuncionesFacturas
    Private funcAL As New FuncionesAlbaranes
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcPE As New FuncionesPedidos
    Private funcES As New FuncionesEstados
    Private funcCP As New FuncionesConceptosPedidos
    Private funcEH As New FuncionesEquiposHistorico
    Private iidArticulo As Integer
    Private iidCliente As Integer
    Private iidEquipo As Integer
    Private vSoloLectura As Boolean
    Private sBusqueda As String
    Private sOrden As String
    Private Direccion As String
    Private indice As Integer
    Private semaforo As Boolean
    Private cambioFechas As Boolean
    Private columna As Integer
    Private idEstadoEQEspera As Integer
    Private idEstadoEQEnCurso As Integer
    Private idEstadoEQAcabado As Integer
    Private idEstadoCPServido As Integer
    Private cmEquipo As ContextMenu
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean
    Private ParametroNumSerie As String
    Private Modo As String
    Private sBusquedaH As String
    Private iidEquipoHistorico As Long
    Private listaEquipos As New List(Of Long)
    Private iidArticuloBase As Integer
    Private CantidadEquipos As Integer = 0
    Private listaEquiposYaSeleccionados As List(Of Long) 'Aqui le pasamos los equipos que ya se han seleccionado para otros conceptos
    Private soloBAnulado As Boolean
#Region "propiedades"

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
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

    Public Property pidCliente() As Integer
        Get
            Return iidCliente
        End Get
        Set(ByVal value As Integer)
            iidCliente = value
        End Set
    End Property

    Public Property pNumSerie() As String
        Get
            Return ParametroNumSerie
        End Get
        Set(ByVal value As String)
            ParametroNumSerie = value
        End Set
    End Property

    Public Property pModo() As String
        Get
            Return Modo
        End Get
        Set(ByVal value As String)
            Modo = value
        End Set
    End Property

    Public Property pidEquipo() As Integer
        Get
            Return iidEquipo
        End Get
        Set(ByVal value As Integer)
            iidEquipo = value
        End Set
    End Property

    Public Property pidEquipoHistorico() As Integer
        Get
            Return iidEquipoHistorico
        End Get
        Set(ByVal value As Integer)
            iidEquipoHistorico = value
        End Set
    End Property

    Public Property pListaEquipos() As List(Of Long)
        Get
            Return listaEquipos
        End Get
        Set(ByVal value As List(Of Long))
            listaEquipos = value
        End Set
    End Property

    Public WriteOnly Property pListaEquiposYaSeleccionados() As List(Of Long)
        Set(ByVal value As List(Of Long))
            listaEquiposYaSeleccionados = value
        End Set
    End Property

    Public WriteOnly Property pCantidadEquipos() As Integer
        Set(ByVal value As Integer)
            CantidadEquipos = value
        End Set
    End Property
#End Region

#Region "Metodos y funciones"

    Private Sub BusquedaEquipos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        'PERMISOS
        Dim funcP As New FuncionesPersonal
        bVerAlbaran.Enabled = funcP.Permiso(Inicio.vIdUsuario, "BusquedaAlbaranes")
        bVerFactura.Enabled = funcP.Permiso(Inicio.vIdUsuario, "BusquedaFacturas")
        bverPedido.Enabled = funcP.Permiso(Inicio.vIdUsuario, "BusquedaPedidos")
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 700 'en milisegundos
        retardo.Enabled = False

    End Sub

    Private Sub BusquedaEquipos1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call IntroducirArticulos()
        If Modo = "LIBERADOS" Then
            cbCliente.Text = "EQUIPOS EN STOCK"
            cbCliente.Enabled = False
            cbCodCliente.Enabled = False
            iidArticuloBase = iidArticulo
            ckSeleccion.Location = New Point(lvEquipos.Location.X + 6, lvEquipos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
            ckSeleccion.Visible = True
            lvEquipos.CheckBoxes = True
            bSeleccionar.Visible = True
        Else
            Call introducirClientes()
            iidArticuloBase = 0
            ckSeleccion.Visible = False
            lvEquipos.CheckBoxes = False
            bSeleccionar.Visible = False
        End If
        Call IntroducirSubTipos()
        Call IntroducirTipos()
        idEstadoEQEspera = funcES.EstadoEspera("EQUIPO").gidEstado
        idEstadoEQEnCurso = funcES.EstadoEnCurso("EQUIPO").gidEstado
        idEstadoEQAcabado = funcES.EstadoCompleto("EQUIPO").gidEstado
        idEstadoCPServido = funcES.EstadoCPedido("SERVIDO").gidEstado
        semaforo = True
        Call InicializarGeneral()
        semaforo = False
        If iidCliente <> 0 Then
            Dim dts As datoscliente = funcCL.mostrar1(iidCliente)
            cbCodCliente.Text = dts.gcodCli
            cbCliente.Text = dts.gnombrecomercial
            cbCliente.Enabled = (Modo = "REPARACIÓN")
            cbCodCliente.Enabled = (Modo = "REPARACIÓN")
        End If
        If iidArticulo <> 0 Then
            Dim dtsA As DatosArticulo = funcAR.Mostrar1(iidArticulo)
            cbCodArticulo.Text = dtsA.gcodArticulo
            cbArticulo.Text = dtsA.gArticulo
            cbCodArticulo.Enabled = (Modo = "REPARACIÓN")
            cbArticulo.Enabled = (Modo = "REPARACIÓN")
        End If
        If ParametroNumSerie <> "" Then
            numSerie.Text = ParametroNumSerie
        End If
        cmEquipo = New ContextMenu
        cmEquipo.MenuItems.Add("Liberar equipo", New System.EventHandler(AddressOf Me.OnClickEquipo))
        lvEquipos.ContextMenu = cmEquipo
        semaforo = True
        Call Busqueda()
    End Sub
#End Region
    Private Sub LlenarListboxEstados()
        lbEstadosEq.Items.Add("PRODUCCIÓN")
        lbEstadosEq.Items.Add("PRODUCIDO")
        lbEstadosEq.Items.Add("SERVIDO")
        lbEstadosEq.Items.Add("SIN ESTADO")
        lbEstadosEq.Items.Add("STOCK")
    End Sub

#Region "INICIALIZACIÓN"
    Private Sub InicializarGeneral()
        semaforo = False
        Albaran.Text = ""
        LlenarListboxEstados()
        If cbArticulo.Enabled Then
            cbArticulo.Text = ""
            cbArticulo.SelectedIndex = -1
        End If
        If cbCliente.Enabled Then
            cbCliente.Text = ""
            cbCliente.SelectedIndex = -1
        End If
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbCodCliente.Text = ""
        cbCodCliente.SelectedIndex = -1
        If Modo = "LIBERADOS" Then
            Me.Text = "BÚSQUEDA DE EQUIPOS LIBERADOS EN STOCK"
            cbCodCliente.Enabled = False
            cbCliente.Enabled = False
        Else
        End If
        Factura.Text = ""
        Pedido.Text = ""
        Version.Text = ""
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        numSerie.Text = ""
        numSerie2.Enabled = False
        numSerie2.Text = ""
        Observaciones.Text = ""
        dtpDesde.Value = DateAdd(DateInterval.Day, -1, Now.Date) 'funcEH.buscaPrimerDia(0)
        dtpHasta.Value = Now.Date
        cambioFechas = True
        sOrden = "numSerieNumerico DESC, idArticulo" '"case when isnumeric(numserie)=1 then cast(numSerie as int) else 0 end DESC, EP.idArticulo"
        Direccion = "DESC"
        'If Not listaEquipos Is Nothing Then listaEquipos.Clear()
        semaforo = True
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        cbCodCliente.Items.Add(New IDComboBox(0, 0))
        cbCliente.Items.Add(New IDComboBox("EQUIPOS EN STOCK", 0))
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
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub

    Private Sub IntroducirTipos()
        Dim funcT As New FuncionesTiposArticulo
        cbTipo.Items.Clear()
        Dim lista As List(Of DatosTipoArticulo) = funcT.Mostrar(0, True)
        For Each item As DatosTipoArticulo In lista
            cbTipo.Items.Add(item)
        Next
    End Sub

    Private Sub IntroducirSubTipos()
        Dim funcT As New FuncionessubTiposArticulo
        cbSubTipo.Items.Clear()
        Dim lista As List(Of String) = funcT.Listar(True)
        For Each item In lista
            cbSubTipo.Items.Add(item)
        Next
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"
    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call Busqueda()
        End If
    End Sub
    'Realiza la busqueda en la base de datos teniendo en cuenta los campos.
    Private Sub Busqueda()
        sBusqueda = ""
        sBusquedaH = ""
        'Revisa el combobox cbcliente y realiza la busqueda o por nombre cliente o por idconcepto si está en stock
        If cbCliente.Text = "EQUIPOS EN STOCK" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CP.idConceptoPedido = 0 "
            cambioFechas = False
        ElseIf cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " (CLientes.NombreComercial like '%" & Replace(cbCliente.Text, "'", "''") & "%' OR  CL.NombreComercial like '" & Replace(cbCliente.Text, "'", "''") & "%' ) "
        End If

        'Realiza la busqueda por código de cliente.
        If cbCodCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " (CLientes.codCli like '" & cbCodCliente.Text & "%' OR  CL.codCli like '" & cbCodCliente.Text & "%' ) "
        End If

        'Realiza la busqueda por código de articulo
        If iidArticuloBase = 0 Then
            If cbCodArticulo.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " AR.codArticulo like '" & cbCodArticulo.Text & "%'"
            End If

            If cbArticulo.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " AR.Articulo like '" & Replace(cbArticulo.Text, "'", "''") & "%' "
            End If
        Else
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " EP.idArticulo in(select idArticulo from Escandallos where idArticulo = " & iidArticuloBase & " OR idArticuloBase = " & iidArticuloBase & " ) "
        End If

        'Realiza la busqueda por subtipo y tipo
        If cbSubTipo.Text <> "" Then
            If cbSubTipo.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " subTipoArticulo = '" & cbSubTipo.Text & "' "
            End If
        End If
        If cbTipo.Text <> "" Then
            If cbTipo.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " AR.idTipoArticulo = " & cbTipo.SelectedItem.gidTipoArticulo
            End If
        End If

        ' Si la busqueda se realiza entre fechas no se ejecuta la busqueda por numero de serie.
        If cambioFechas = False Then
            If numSerie.Text <> "" And numSerie2.Text = "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " numSerie like '" & numSerie.Text & "'"
            Else
                If numSerie.Text <> "" And numSerie2.Text <> "" Then
                    Dim n As String = numSerie.Text
                    Dim MyChar() As Char = {"%"}
                    n = n.Trim(MyChar)
                    Console.WriteLine(n)
                    sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                    sBusqueda = sBusqueda & " (numSerie between " & n & " AND " & numSerie2.Text & ")"
                Else
                    cambioFechas = True
                End If
            End If
        End If

        'Realiza la busqueda por número de albarán.
        If Albaran.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CA.numAlbaran like '" & Albaran.Text & "%' "
        End If

        'Realiza la busqueda por número de serie.
        If IsNumeric(Version.Text) Then
            If Version.Text > 1000 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " EP.VersionEscandallo = " & Version.Text
            End If
        End If

        'Realiza la busqueda por número de pedido
        If Pedido.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PE.numPedido like '" & Pedido.Text & "%' "
        End If

        'Realiza la busqueda por número de factura
        If Factura.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CA.numFactura like '" & Factura.Text & "%' "
        End If

        'Si el datepicker desde o hasta cambian se realiza una busqueda entre fechas sin tener en cuenta los campos de número de serie.
        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CASE WHEN CP.Creacion is null then EP.fechafin else CONVERT(datetime,CONVERT(Char(10), CP.Creacion,103)) end  >= '" & dtpDesde.Value.Date & "' AND  CASE WHEN CP.Creacion is null then EP.fechafin else CONVERT(datetime,CONVERT(Char(10), CP.Creacion,103)) end   <= '" & dtpHasta.Value.Date & "' "
        End If
        If Observaciones.Text <> "" Then
            Dim texto As String = Replace(Observaciones.Text, "'", "''")
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = " EP.Observaciones like '%" & texto & "%' "
        End If

        'Realiza la busqueda dependieno de los items seleccionados en el listbox de estados.
        If lbEstadosEq.SelectedItems.Count > 0 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            Dim rango As String = ""
            For Each item In lbEstadosEq.SelectedItems
                If item = "PRODUCCIÓN" Then
                    rango = If(rango = "", "", rango & " or ") & " Estados.Completo = 0 and (select Entregado from Estados where idEstado = C1.idEstado) = 0" '" estados.idestado in (41,42) and" 
                End If
                If item = "PRODUCIDO" Then
                    rango = If(rango = "", "", rango & " or ") & " Estados.Completo = 1 and (select Entregado from Estados where idEstado = C1.idEstado) = 0"
                End If
                If item = "SERVIDO" Then
                    rango = If(rango = "", "", rango & " or ") & " (select Entregado from Estados where idEstado = C1.idEstado) = 1"
                End If
                If item = "SIN ESTADO" Then
                    rango = If(rango = "", "", rango & " or ") & " EP.Cliente_old is not null"
                End If
                If item = "STOCK" Then
                    rango = If(rango = "", "", rango & " or ") & " Clientes.NombreComercial is null and EP.Cliente_old is null"
                End If
            Next
            If rango <> "" Then
                rango = "(" & rango & ")"
            End If
            sBusqueda = sBusqueda & rango
        End If
        Call ActualizarLV()
    End Sub
    'Actualiza el listview
    Private Sub ActualizarLV()
        lvEquipos.Items.Clear()
        Dim lista As List(Of DatosEquipoProduccion)
        Dim Orden As String = sOrden & " " & Direccion
        'Dim Orden As String = sOrden & " " & Direccion & If(sOrden.Contains("numSerieNumerico"), "", ", numSerieNumerico " & Direccion) & If(sOrden.Contains("idEquipo"), "", ", idEquipo " & Direccion)
        lista = funcEQ.Busqueda(sBusqueda, Orden, 0)
        If Not lista Is Nothing Then
            pbCarga.Value = 0
            pbCarga.Maximum = lista.Count
            Encontrados.Text = ""
            PedidosEncontrados.Text = ""
            pbCarga.Visible = True
            For Each dts As DatosEquipoProduccion In lista
                If Modo = "LIBERADOS" AndAlso listaEquiposYaSeleccionados.Contains(dts.gidEquipo) Then
                    'No presentaremos los equipos ya seleccionados por otros conceptos
                Else
                    Call NuevaLineaLV(dts)
                End If
                pbCarga.Increment(1)
            Next
            Encontrados.Text = lista.Count
            PedidosEncontrados.Text = funcEQ.ContadorPedidosBusqueda(sBusqueda, 0)
            pbCarga.Visible = False
        End If
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosEquipoProduccion)
        With lvEquipos.Items.Add(" ")
            .SubItems.Add(If(dts.gidEquipo = 0, "", CStr(dts.gidEquipo)))
            .SubItems.Add(dts.gnumSerie)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            If dts.gnumPedido = 0 And dts.gidEquipo > 0 Then
                If dts.gcliente_old <> "" Then
                    .SubItems.Add(dts.cliente_old)
                End If
            Else
                .SubItems.Add(dts.gCliente)
            End If
            If dts.gnumPedido = 0 Then
                .SubItems.Add("")
            Else
                .SubItems.Add(dts.gnumPedido)
            End If
            If dts.gnumAlbaran = "0" Then
                .SubItems.Add("")
            Else
                .SubItems.Add(dts.gnumAlbaran)
            End If
            If dts.gfechaentrega <= Now.Date Then
                .SubItems.Add(dts.gfechaentrega)

            Else
                If dts.gfechaentrega > Now.Date Then
                    .SubItems.Add("")
                Else
                    .SubItems.Add(CDate("1-1-1900"))
                End If

            End If
            If dts.gnumFactura = 0 Then
                .SubItems.Add("")
                .SubItems.Add("")
            Else
                .SubItems.Add(dts.gnumFactura)
                .SubItems.Add(dts.gFechaFactura)
            End If
            If dts.gCliente = "" And dts.gcliente_old = "0" Then
                .SubItems.Add("STOCK")
            Else
                .SubItems.Add(dts.gEstadoBusqueda)
            End If
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(dts.gidEquipoHistorico)
            .SubItems.Add(If(dts.gVersion = 0, "", CStr(dts.gVersion)))
            .SubItems.Add(Format(dts.gFechaFin, "dd/MM/yyyy"))
            Select Case dts.gEstadoBusqueda
                Case "SERVIDO"
                    .ForeColor = Color.Green
                Case "PRODUCIDO"
                    .ForeColor = Color.Orange
                Case "PRODUCCIÓN"
                    'If dts.gidEstado = idEstadoEQEnCurso Then
                    '    .ForeColor = Color.Blue
                    'Else
                    .ForeColor = Color.Black
                    'End If
                Case "SIN ESTADO"
                    .ForeColor = Color.Blue
            End Select
            If listaEquipos.Contains(dts.gidEquipo) Then .Checked = True
        End With
    End Sub

    Private Sub ActualizaLineaLV()
        If indice > -1 Then
            Dim dts As DatosEquipoProduccion
            If lvEquipos.Items(indice).SubItems(1).Text = "" Then
                iidEquipo = 0
                dts = funcEH.Mostrar1Produccion(lvEquipos.Items(indice).SubItems(13).Text)
            Else
                iidEquipo = lvEquipos.Items(indice).SubItems(1).Text
                dts = funcEQ.Mostrar1(iidEquipo)
            End If
            With lvEquipos.Items(indice)
                .SubItems(2).Text = dts.gnumSerie
                .SubItems(3).Text = dts.gcodArticulo
                .SubItems(4).Text = dts.gArticulo
                If dts.gnumPedido = 0 And dts.gidEquipo > 0 Then
                    .SubItems(5).Text = "STOCK"
                Else
                    .SubItems(5).Text = dts.gCliente
                End If
                If dts.gnumPedido = 0 Then
                    .SubItems(6).Text = ""
                Else
                    .SubItems(6).Text = dts.gnumPedido
                End If

                If dts.gnumAlbaran = "0" Then
                    .SubItems(7).Text = ""
                Else
                    .SubItems(7).Text = dts.gnumAlbaran
                    If dts.gFechaAlbaran = Now.Date And dts.gidEquipoHistorico > 0 Then
                        If dts.gFechaPrevista = CDate("1-1-1900") Then
                            .SubItems(8).Text = ""
                        Else
                            .SubItems(8).Text = dts.gFechaPrevista
                        End If
                    Else
                        If dts.gnumAlbaran = "" Or dts.gnumAlbaran = "0" Then
                            .SubItems(8).Text = ""
                        Else
                            .SubItems(8).Text = dts.gFechaAlbaran
                        End If

                    End If

                End If

                If dts.gnumFactura = 0 Then
                    .SubItems(9).Text = ""
                    .SubItems(10).Text = ""
                Else
                    .SubItems(9).Text = dts.gnumFactura
                    .SubItems(10).Text = dts.gFechaFactura
                End If
                .SubItems(11).Text = dts.gEstadoBusqueda
                .SubItems(12).Text = dts.gidArticulo
                .SubItems(13).Text = dts.gidEquipoHistorico
                .SubItems(14).Text = If(dts.gVersion = 0, "", CStr(dts.gVersion))
                .SubItems(15).Text = Format(dts.gFechaFin, "dd/MM/yyyy")

                Select Case dts.gEstadoBusqueda
                    Case "SERVIDO"
                        .ForeColor = Color.Green
                    Case "PRODUCIDO"
                        .ForeColor = Color.Orange
                    Case "PRODUCCIÓN"
                        'If dts.gidEstado = idEstadoEQEnCurso Then
                        '    .ForeColor = Color.Blue
                        'Else
                        .ForeColor = Color.Black
                        'End If
                    Case "SIN ESTADO"
                        .ForeColor = Color.Blue
                End Select
            End With
        End If
    End Sub

#End Region

#Region "BOTONES GENERALES"
    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click, bimprimirresumen.Click
        If Not IsNumeric(Encontrados.Text) Then Encontrados.Text = 0
        If Not IsNumeric(PedidosEncontrados.Text) Then PedidosEncontrados.Text = 0
        Dim GG As New InformeListadoEquipos
        Dim Orden As String = sOrden & " " & Direccion & If(sOrden.Contains("numSerieNumerico"), "", ", numSerieNumerico " & Direccion) & If(sOrden.Contains("idEquipo"), "", ", idEquipo " & Direccion)
        GG.verInforme(sBusqueda, sBusquedaH, Orden, Encontrados.Text, PedidosEncontrados.Text)
        GG.ShowDialog()

    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        lbEstadosEq.Items.Clear()
        Call InicializarGeneral()
        listaEquipos = New List(Of Long)
        Call Busqueda()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSeleccionar.Click
        If lvEquipos.CheckedItems.Count = 0 And listaEquipos.Count = 0 Then
            MsgBox("No se ha seleccionado ningún equipo")
        ElseIf lvEquipos.CheckedItems.Count > CantidadEquipos Then
            If CantidadEquipos = 1 Then
                MsgBox("Sólo necesita seleccionar un equipo")
            Else
                MsgBox("Sólo necesita seleccionar " & CantidadEquipos & " equipos")
            End If
        Else
            listaEquipos = New List(Of Long)
            For Each item As ListViewItem In lvEquipos.CheckedItems
                If item.SubItems(1).Text <> 0 Then listaEquipos.Add(item.SubItems(1).Text)
            Next
            Me.Close()
        End If
    End Sub

    Private Sub bVerAlbaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerAlbaran.Click
        If Albaran.Text <> "" And Albaran.Text <> "0" And IsNumeric(Albaran.Text) Then
            Dim GG As New GestionAlbaran
            GG.SoloLectura = vSoloLectura
            GG.pnumAlbaran = Albaran.Text
            GG.ShowDialog()
        End If
    End Sub

    Private Sub bVerPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bverPedido.Click
        If Pedido.Text <> "" And Pedido.Text <> "0" Then
            Dim GG As New GestionPedido
            GG.SoloLectura = vSoloLectura
            GG.pnumPedido = Pedido.Text
            GG.ShowDialog()
        End If
    End Sub

    Private Sub bVerFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerFactura.Click
        If Factura.Text <> "" And Factura.Text <> "0" Then
            Dim gg As New GestionFactura1
            gg.SoloLectura = vSoloLectura
            gg.pnumFactura = Factura.Text
            gg.ShowDialog()

        End If
    End Sub
#End Region

#Region "EVENTOS"
    Protected Sub OnClickEquipo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvEquipos.SelectedItems.Count > 0 Then
            indice = lvEquipos.SelectedIndices(0)
            Select Case sender.text
                Case "Liberar equipo"
                    Call LiberarEquiposSeleccionados()
            End Select
        End If
    End Sub
    Private Sub LiberarEquiposSeleccionados()
        If IsNumeric(lvEquipos.Items(indice).SubItems(1).Text) Then
            iidEquipo = lvEquipos.Items(indice).SubItems(1).Text
            Dim idEquipos As New List(Of Long)
            Dim dts As DatosEquipoProduccion = funcEQ.Mostrar1(iidEquipo)
            Dim iidArticulo As Integer = dts.gidArticulo
            Dim inumPedido As Integer = dts.gnumPedido
            Dim Variosid As Boolean = False
            Dim NoAcabados As Boolean = False
            Dim ConNumSerie As Boolean = False
            Dim sinNumPedido As Boolean = False
            Dim Facturado As Boolean = False
            Dim Servido As Boolean = False
            For Each item As ListViewItem In lvEquipos.SelectedItems
                iidEquipo = item.SubItems(1).Text
                dts = funcEQ.Mostrar1(iidEquipo)
                idEquipos.Add(iidEquipo)
                If dts.gidArticulo <> iidArticulo Or dts.gnumPedido <> inumPedido Then
                    Variosid = True
                End If
                If dts.gnumSerie <> 0 Then ConNumSerie = True
                If dts.gidEstado <> idEstadoEQAcabado Then NoAcabados = True
                If dts.gnumPedido = 0 Then sinNumPedido = True
                If item.SubItems(9).Text <> "" And item.SubItems(9).Text <> "0" Then
                    Facturado = True
                ElseIf item.SubItems(8).Text <> "" And item.SubItems(8).Text <> "0" Then
                    Dim idEstado As Integer = funcAL.idEstado(dts.gnumAlbaran)
                    If idEstado = funcES.EstadoTraspasado("ALBARAN").gidEstado Or idEstado = funcES.EstadoEntregado("ALBARAN").gidEstado Then
                        Servido = True
                    End If
                End If
            Next

            If Variosid Or Facturado Or Servido Then
                Dim texto As String = ""
                If Variosid Then texto = "Se han de seleccionar equipos del mismo artículo y asignados al mismo pedido."
                'If ConNumSerie Then texto = If(texto = "", "", texto & vbCrLf) & "Sólo se pueden liberar equipos antes de asignar el número de serie."
                If Servido Then texto = If(texto = "", "", texto & vbCrLf) & "Sólo se pueden liberar equipos no servidos."
                If Facturado Then texto = If(texto = "", "", texto & vbCrLf) & "Sólo se pueden liberar equipos no facturados."
                'If sinNumPedido Then texto = If(texto = "", "", texto & vbCrLf) & "No se pueden liberar equipos ya liberados."
                'If NoAcabados Then texto = If(texto = "", "", texto & vbCrLf) & "Sólo se pueden liberar equipos acabados."
                MsgBox(texto)
            ElseIf NoAcabados Or sinNumPedido Then
                Dim texto As String = ""
                Dim GG As New ReasignarEquipos
                GG.SoloLectura = vSoloLectura
                GG.pidEquipos = idEquipos
                GG.estadoStock = True
                GG.ShowDialog()
                Call ActualizarLV()
            Else
                Dim GG As New ReasignarEquipos
                GG.SoloLectura = vSoloLectura
                GG.pidEquipos = idEquipos
                GG.ShowDialog()
                Call ActualizarLV()
            End If
        Else
            MsgBox("No se puede liberar un equipo histórico")
        End If
    End Sub

    Private Sub lvEquipos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEquipos.DoubleClick
        If lvEquipos.SelectedItems.Count > 0 Then
            If Modo = "REPARACIÓN" Then
                If lvEquipos.SelectedItems(0).SubItems(1).Text = "" Then
                    iidEquipo = 0
                    iidEquipoHistorico = lvEquipos.SelectedItems(0).SubItems(13).Text
                Else
                    iidEquipo = lvEquipos.SelectedItems(0).SubItems(1).Text
                    iidEquipoHistorico = 0
                End If
                Me.Close()
            ElseIf Modo = "LIBERADOS" Then
                'No hace nada
            Else
                PresentarDatosEquipo()
            End If
        End If
    End Sub

    Private Sub PresentarDatosEquipo()
        semaforo = False
        indice = lvEquipos.SelectedIndices(0)

        Dim dts As DatosEquipoProduccion
        If lvEquipos.Items(indice).SubItems(1).Text = "" Then
            iidEquipo = 0
            dts = funcEH.Mostrar1Produccion(lvEquipos.Items(indice).SubItems(13).Text)
        Else
            iidEquipo = lvEquipos.Items(indice).SubItems(1).Text
            dts = funcEQ.Mostrar1(iidEquipo)
        End If
        Albaran.Text = dts.gnumAlbaran
        cbArticulo.Text = dts.gArticulo
        cbCodArticulo.Text = dts.gcodArticulo
        cbCliente.Text = dts.gCliente
        cbCodCliente.Text = dts.gcodCli
        Factura.Text = dts.gnumFactura
        ' cbSeccion.Text = dts.gSeccion
        cbSubTipo.Text = dts.gSubTipoArticulo
        cbTipo.Text = dts.gTipoArticulo
        numSerie.Text = dts.gnumSerie
        Pedido.Text = dts.gnumPedido
        Observaciones.Text = dts.gObservaciones
        semaforo = True
    End Sub

    Private Sub cbCodCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodCliente.SelectedIndexChanged
        If semaforo Then
            BuscarAhora = False
            semaforo = False
            If cbCodCliente.SelectedIndex <> -1 Then
                If Trim(cbCodCliente.Text).Length > 0 Then
                    iidCliente = cbCodCliente.SelectedItem.itemdata
                    cbCliente.Text = funcCL.campoCliente(iidCliente)
                End If
            Else
                cbCliente.Text = ""
                cbCodCliente.SelectedIndex = -1
            End If
            Call Busqueda()
            semaforo = True
        End If
    End Sub

    Private Sub cbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCliente.SelectedIndexChanged
        If semaforo Then
            BuscarAhora = False
            semaforo = False
            If cbCliente.Text <> "" Then
                If cbCliente.SelectedIndex <> -1 Then
                    iidCliente = cbCliente.SelectedItem.itemdata
                    cbCodCliente.Text = funcCL.campoCodCli(iidCliente)
                Else
                    cbCodCliente.Text = ""
                    cbCodCliente.SelectedIndex = -1
                End If
            End If
            Call Busqueda()
            semaforo = True
        End If
    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedIndexChanged
        If semaforo Then
            If cbCodArticulo.SelectedIndex <> -1 Then
                semaforo = False
                If Trim(cbCodArticulo.Text).Length > 0 Then
                    iidArticulo = cbCodArticulo.SelectedItem.itemdata
                    cbArticulo.Text = funcAR.Articulo(iidArticulo)
                End If
                Call Busqueda()
                semaforo = True
            End If
        End If
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedIndexChanged
        If semaforo Then
            If cbArticulo.SelectedIndex <> -1 Then
                semaforo = False
                iidArticulo = cbArticulo.SelectedItem.itemdata
                cbCodArticulo.Text = funcAR.codArticulo(iidArticulo)
                Call Busqueda()
                semaforo = True
            End If
        End If
    End Sub

    Private Sub numSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged, cbSubTipo.SelectedIndexChanged
        If semaforo Then Call Busqueda()
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.TextChanged, cbCodArticulo.TextChanged, numSerie.TextChanged, numSerie2.TextChanged, Pedido.TextChanged, Albaran.TextChanged, Factura.TextChanged, cbCliente.TextChanged, cbCodCliente.TextChanged, Observaciones.TextChanged, Version.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
            If numSerie.Text <> "" Then
                numSerie2.Enabled = True
            Else
                numSerie2.Enabled = False
                numSerie2.Text = ""
            End If
        End If
    End Sub

    Private Sub bloqueoFechas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numSerie.TextChanged, numSerie2.TextChanged
        cambioFechas = False 'inicializamos la variable a false para que no ejecute la consulta de la fecha
    End Sub
    'Orden del listview por columna seleccionada
    Private Sub lvEquipos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEquipos.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column

            Case 1
                sOrden = "EP.idEquipo"
            Case 2
                sOrden = "cast(numSerie as int)" '"numSerieNumerico " '"case when isnumeric(numserie)=1 then cast(numSerie as int) else 0 end "
            Case 3
                sOrden = "codArticulo"
            Case 4
                sOrden = "Articulo"
            Case 5
                sOrden = "cliente" '"Clientes.NombreComercial, cliente_old"
            Case 6
                sOrden = "numPedido"
            Case 7
                sOrden = "numAlbaran"
            Case 8
                sOrden = "PE.FechaEntrega"
            Case 9
                sOrden = "Facturas.numFactura"
            Case 10
                sOrden = "Facturas.Fecha"
            Case 11
                sOrden = "EstadoBusqueda"
            Case 12
                sOrden = "numPedido"
            Case 15
                sOrden = "FechaFin"
        End Select
        columna = e.Column
        Call ActualizarLV()
    End Sub

    Private Sub numAlbaran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Albaran.KeyPress, Pedido.KeyPress, Factura.KeyPress, Version.KeyPress
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
            For Each item As ListViewItem In lvEquipos.Items
                item.Checked = ckSeleccion.Checked
            Next
            semaforo = True
        End If
    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvEquipos.ItemChecked
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
#End Region

#Region "DTP FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp
        If semaforo Then    ''''RAUL
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
            'Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDesde.KeyUp
        If semaforo Then    ''''RAUL
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
            'Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp
        If semaforo Then    ''''RAUL
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
            'Call Busqueda()
        End If
    End Sub

    Private Sub dtpHasta_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHasta.CloseUp
        If semaforo Then    ''''RAUL
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
            'Call Busqueda()
        End If
    End Sub
#End Region

    Private Sub lbEstados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEstadosEq.SelectedIndexChanged
        Call Busqueda()
    End Sub

    Private Sub solonumeros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numSerie.KeyPress, numSerie2.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "%"c Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub bCliente_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCliente.Click
        'If cbCodCliente.Text <> "" And cbCodCliente.SelectedIndex > -1 Then
        '    Dim GG As New GestionClientes
        '    GG.SoloLectura = vSoloLectura
        '    GG.iidCliente = funcEQ.idcliente(cbCodCliente.Text)
        '    GG.ShowDialog()
        'End If
        Dim sIDEquipo As String = iidEquipo
        If sIDEquipo <> 0 Then
            If MsgBox("¿Desea actualizar las observaciones del equipo " & sIDEquipo & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                funcEQ.actualizarObservaciones(sIDEquipo, Observaciones.Text)
            End If
        End If
    End Sub
End Class