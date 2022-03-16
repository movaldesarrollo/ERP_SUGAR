'Este formulario tiene la función de buscar los pedidos de proveedor.

Public Class BusquedaPedidoProveedor

#Region "VARIABLES"

    'FUNCIONES

    Dim funcMO As New FuncionesMoneda 'Funciones de moneda.

    Dim funcES As New FuncionesEstados 'Funciones de estados.

    Dim funcAR As New FuncionesArticulos 'Funciones de artículos.

    Dim funcPR As New funcionesProveedores 'Funciones de proveedores.

    Dim funcPP As New FuncionesPedidosProv 'Funciones de pedidos de proveedor.

    'VARIABLES GENERALES

    Dim sCodProveedor As String 'Almacena el código de proveedor.

    Dim vNumFactura As Integer 'Almacena el número de factura.

    Dim vNumPedido As Integer 'Almacena el número de pedido.

    Dim vEstado As String 'Almacena el estado del pedido.

    Public cambioFechas As Boolean 'Almacena la variable booleana de cambio de fechas.

    Dim cambioFechasE As Boolean 'Almacena la variable booleana de cambio de fechas Entrega.

    Dim sel As String 'Almacena las cadenas de consulta.

    Dim vTotal As Double 'Almacena el total de importe de pedidos. '

    Dim semaforo As Boolean 'Variable que controla la carga.

    Dim Orden As String = "numPedido" 'Variable que almacena el orden de la busqueda.

    Dim Direccion As String = "DESC" 'Dirección de la busqueda.

    Dim Pedidos As List(Of Integer) 'Almacena una lista de pedidos.

    Dim vSoloLectura As Boolean 'Comprueba el permiso solo lectura.

    Dim indice As Integer 'Almacena el indice del listview.

    Dim retardo As New Timer 'Creamos un timer.

    Dim BuscarAhora As Boolean 'Variable booleana que permite la busqueda de pedidos.

    Dim inumPedido As Integer 'Almacena el número de pedido.

    Dim modo As String 'Almacena el modo de pedido.

    Dim iidProveedor As Integer 'Almacena la id de proveedor.

    'DATOS DE PEDIDOS

    Dim estadoCabecera As DatosEstado 'Datos de pedidos en cabecera.

    Dim estadoFinalizado As DatosEstado 'Datos de pedidos en Finalizado.

    Dim estadoEnCurso As DatosEstado 'Datos de pedidos en curso.

    Dim estadoValidado As DatosEstado 'Datos de pedidos en Validado.

    Dim estadoStock As DatosEstado 'Datos de pedidos stock.

    Dim estadoStockParcial As DatosEstado 'Datos de pedidos en parcial.

    Dim estadoAnulado As DatosEstado 'Datos de pedidos en anulado.

    Dim estadoRealizado As DatosEstado 'Datos de pedidos en realizado.

    'VARIABLES DEL FORMULARIO ARTICULOS COMPRADOS

    Public sProveedor As String

    Public sAños As String

    Public bFormArticulosComprados As Boolean

    Public dFechaDesde As Date

    Public dFechaHasta As Date

    Public sCodArticulo As String

    Public sArticulo As String

    Public bEntreFechas As String

#End Region
    
#Region "PROPIEDADES"

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property pnumPedido() As Integer
        Get
            Return inumPedido
        End Get
        Set(ByVal value As Integer)
            inumPedido = value
        End Set
    End Property

    Public Property pModo() As String
        Get
            Return modo
        End Get
        Set(ByVal value As String)
            modo = value
        End Set
    End Property

    Public Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property

#End Region

    'Carga de formulario.
    Private Sub BusquedaPedidoProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Formatear el formulario al tamaño de pantalla.
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize 'Almacena las medidas de la pantalla actual.

        Me.Height = desktopSize.Height - 15 'Cambia la altura del formulario a la medida de la pantalla menos la barra de tareas.

        Me.Location = New Point(Me.Location.X, 0) 'Posiciona el formulario en la parte superior de la pantalla.

        BuscarAhora = False 'Evita que se realice la busqueda inicial.

        'Iniciamos el Timer Retardo
        AddHandler retardo.Tick, AddressOf BusquedaRetardada

        retardo.Interval = 500 'Medida en milisegundos

        retardo.Enabled = False 'Desactivamos el timer.

        estadoCabecera = funcES.EstadoPedidoProv("CABECERA") 'Llenamos los datos de pedidos cabecera.

        estadoFinalizado = funcES.EstadoPedidoProv("FINALIZADO") 'Llenamos los datos de pedidos finalizado.

        estadoEnCurso = funcES.EstadoPedidoProv("EN CURSO") 'Llenamos los datos de pedidos en curso.

        estadoValidado = funcES.EstadoPedidoProv("VALIDADO") 'Llenamos los datos de pedidos validado.

        estadoStock = funcES.EstadoPedidoProv("STOCK") 'Llenamos los datos de pedidos stock.

        estadoStockParcial = funcES.EstadoPedidoProv("STOCK PARCIAL") 'Llenamos los datos de pedidos stock parcial.

        estadoAnulado = funcES.EstadoPedidoProv("ANULADO") 'Llenamos los datos de pedidos anulado.

        estadoRealizado = funcES.EstadoPedidoProv("REALIZADO") 'Llenamos los datos de pedidos realizado.

        Call Inicializar() 'Inicializamos los parametros.

        If iidProveedor > 0 Then cbProveedores.Text = funcPR.campoProveedor(iidProveedor)

        'SI SE ABRE DESDE ARTICULOS COMPRADOS
        If bFormArticulosComprados Then
            cbAño.Text = sAños
            cbProveedores.Text = sProveedor
            cbCodArticulo.Text = sCodArticulo
            cbArticulo.Text = sArticulo
            dtpDesdePedido.Value = dFechaDesde
            dtpHastaPedido.Value = dFechaHasta
            cambioFechas = bEntreFechas
        End If

        Call Busqueda() 'Iniciamos la búsqueda.

    End Sub

    'Inicializamos los parametros.
    Private Sub Inicializar()

        Try

            semaforo = False 'Activa el semáforo.

            sCodProveedor = 0 'Vacia el campo de código de proveedor.

            vEstado = "TODOS" 'Formatea el estado a Todos.
            
            vNumPedido = 0 'Vacia el campo de número pedido a 0.

            numPedido.Text = "" 'Vacia el campo de texto número de pedido.

            vTotal = 0 'Vacia el campo de total a 0.
            
            Orden = "numPedido" 'Establece el orden.

            Direccion = "ASC" 'Establece la dirección.

            sel = "" 'Vacia la cadena de consulta.

            cbCodArticulo.Text = "" 'Vacia el texto del combobox.

            cbCodArticulo.SelectedIndex = -1 'Elimina el indice.

            'cbArticulo.Text = "" 'Vacia el texto del combobox.

            'cbArticulo.SelectedIndex = -1 'Elimina el indice.

            cambioFechas = False 'Inhabilitamos la búsqueda de fechas.

            cambioFechasE = False 'Inhabilitamos la búsqueda de fechas.

            dtpDesdePedido.Value = Now.Date 'Formateamos la fecha a la fecha actual.

            dtpHastaPedido.Value = Now.Date 'Formateamos la fecha a la fecha actual.

            dtpDesdeEntrega.Value = Now.Date 'Formateamos la fecha a la fecha actual.

            dtpHastaEntrega.Value = Now.Date 'Formateamos la fecha a la fecha actual.

            'Formatea los parametros del listview.
            With lvPedidos
                .View = View.Details 'Activa los detalles.
                .FullRowSelect = True 'Activa la selección de toda la linea.
                .GridLines = True 'Muestra las lineas de la cuadrícula.
                .MultiSelect = False 'Desactiva la multiselección.
                .HideSelection = False 'Oculta la selección.
            End With

            semaforo = False 'Activa el semáforo.

            Call IntroducirTipos() 'Introduce los tipos.

            Call introducirProveedores() 'Introduce los proveedores.

            Call IntroducirEstados() 'Introduce los Estados.

            Call IntroducirPagados() 'Introduce los pagados.

            Call IntroducirAños() 'Introduce los años.

            semaforo = True 'Desactiva el semáforo.

        Catch ex As Exception

            CorreoError(ex)

        End Try

    End Sub

    Private Sub limpiaBusqueda()
        'Limpia la parte superior de las búsquedas
        semaforo = False
        sCodProveedor = 0
        vEstado = "TODOS"
        cbProveedores.Text = ""
        'cbEstado.Text = "TODOS"
        lbEstados.SelectedItems.Clear()
        Orden = "numPedido"
        Direccion = "DESC"
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbPAGADO.Text = "TODOS"
        cambioFechas = False
        cambioFechasE = False
        dtpDesdePedido.Value = Now.Date
        dtpHastaPedido.Value = Now.Date
        dtpDesdeEntrega.Value = Now.Date
        dtpHastaEntrega.Value = Now.Date
        cbAño.Text = Now.Year
        indice = -1
        semaforo = True
    End Sub

    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = funcPP.buscaPrimerDia(0).Year To Now.Year
            cbAño.Items.Add(Año)
        Next
        cbAño.Text = Now.Year
    End Sub

    Private Sub introducirProveedores()
        Try
            cbProveedores.Items.Clear()
            cbProveedores.Text = ""
            Dim dt As DataTable
            If cbTipo.Text = "TODOS" Then
                dt = funcPP.listaProveedores()
            Else
                dt = funcPP.listaProveedores(cbTipo.SelectedItem.itemdata)
            End If
            For Each row In dt.Rows
                cbProveedores.Items.Add(New IDComboBox(row("nombreComercial"), row("idProveedor")))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub IntroducirTipos()

        Dim func As New FuncionesTipoCompra
        Dim lista As List(Of DatosTipoCompra) = func.Mostrar()
        Dim dts As DatosTipoCompra
        cbTipo.Items.Clear()
        cbTipo.Items.Add(New IDComboBox("TODOS", -1))
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoCompra, dts.gIdTipoCompra))
        Next
        cbTipo.Text = "TODOS"
        cbTipo.SelectedIndex = 0
    End Sub

    Private Sub introducirPedidoProveedor()

        Try
            cbPedidoProveedor.Items.Clear()
            cbPedidoProveedor.Text = ""
            Dim dt As DataTable = funcPP.listaPedidoProveedor(cbTipo.SelectedItem.itemdata)

            For Each row In dt.Rows
                If row("PedidoProveedor") Is DBNull.Value Then
                Else
                    If row("PedidoProveedor") <> "" Then
                        cbPedidoProveedor.Items.Add(row("PedidoProveedor"))
                    End If
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub IntroducirEstados()

        lbEstados.Items.Clear()

        Dim lista As List(Of DatosEstado) = funcPP.ListaEstados

        For Each dts As DatosEstado In lista

            lbEstados.Items.Add(dts)

        Next

    End Sub

    Private Sub IntroducirPagados()

        cbPAGADO.Items.Clear()

        cbPAGADO.Items.Add("TODOS")

        cbPAGADO.Items.Add("PAGADO")

        cbPAGADO.Items.Add("NO PAGADO")

        cbPAGADO.Text = "TODOS"

    End Sub

    Private Sub IntroducirArticulos()

        cbCodArticulo.Items.Clear()

        cbCodArticulo.Text = ""

        cbCodArticulo.SelectedIndex = -1

        cbArticulo.Items.Clear()

        cbArticulo.Text = ""

        cbArticulo.SelectedIndex = -1

        Dim lista As List(Of IDComboBox3) = funcAR.Listar("COMPRABLE")

        For Each dts As IDComboBox3 In lista

            cbArticulo.Items.Add(dts)

            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))

        Next

    End Sub

    Private Sub actualiza_lvPedidos()
        Try
            lvPedidos.Items.Clear()

            vTotal = 0

            Pedidos = New List(Of Integer)
            Dim PrecioE As Double
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date

            Dim lista As List(Of DatosPedidoProv) = funcPP.Busqueda(sel, Orden & " " & Direccion, True)

            For Each dts As DatosPedidoProv In lista
                Pedidos.Add(dts.gnumPedido)
                With lvPedidos.Items.Add(dts.gnumPedido)
                    .SubItems.Add(dts.gPedidoProveedor)
                    .SubItems.Add(dts.gFechaPedido)
                    .SubItems.Add(dts.gFechaEntrega)
                    .SubItems.Add(dts.gProveedor)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
                    .SubItems.Add(dts.gidProveedor) 'IDPROV LUIS-----------------------------------------------------
                    If dts.gcodMoneda = "EU" Then

                        vTotal = vTotal + dts.gTotal
                    Else
                        PrecioE = funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)

                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                        vTotal = vTotal + PrecioE
                    End If
                    Select Case dts.gidEstado
                        Case estadoStockParcial.gidEstado
                            .ForeColor = Color.Red
                        Case estadoAnulado.gidEstado
                            .ForeColor = Color.Gray
                        Case estadoFinalizado.gidEstado
                            .ForeColor = Color.Green
                        Case estadoValidado.gidEstado
                            .ForeColor = Color.DarkGreen
                        Case estadoRealizado.gidEstado
                            .ForeColor = Color.Blue
                        Case Else
                            .ForeColor = Color.Black
                    End Select
                End With

            Next
            Total.Text = FormatNumber(vTotal, 2)
            Contador.Text = lvPedidos.Items.Count
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ActualizaLinea()
        Try
            If indice <> -1 Then
                vTotal = 0
                Dim sCodMoneda As String = "EU"

                With lvPedidos.Items(indice)
                    Dim dts As DatosPedidoProv = funcPP.Mostrar1(.SubItems(0).Text)
                    .SubItems(1).Text = dts.gPedidoProveedor
                    .SubItems(2).Text = FormatDateTime(dts.gFechaPedido, DateFormat.ShortDate)
                    .SubItems(3).Text = FormatDateTime(dts.gFechaEntrega, DateFormat.ShortDate)
                    .SubItems(4).Text = dts.gProveedor
                    .SubItems(5).Text = dts.gEstado
                    .SubItems(6).Text = FormatNumber(dts.gTotal, 2) & dts.gSimbolo
                    .SubItems(7).Text = dts.gidProveedor
                    Select Case dts.gidEstado
                        Case estadoStockParcial.gidEstado
                            .ForeColor = Color.Red
                        Case estadoAnulado.gidEstado
                            .ForeColor = Color.Gray
                        Case estadoFinalizado.gidEstado
                            .ForeColor = Color.Green
                        Case estadoValidado.gidEstado
                            .ForeColor = Color.DarkGreen
                        Case estadoRealizado.gidEstado
                            .ForeColor = Color.Blue
                        Case Else
                            .ForeColor = Color.Black
                    End Select
                    Call CalculaTotal()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CalculaTotal()
        Dim vTotal As Double
        Dim PrecioE As Double
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambioG As Date = Now.Date
        Dim FechaCambio As Date = Now.Date
        Dim lista As List(Of DatosPedidoProv) = funcPP.Busqueda(sel, Orden & " " & Direccion, True)
        For Each dts As DatosPedidoProv In lista
            If dts.gcodMoneda = "EU" Then
                vTotal = vTotal + dts.gTotal
            Else
                PrecioE = funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)

                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
                vTotal = vTotal + PrecioE
            End If
        Next
        Total.Text = FormatCurrency(vTotal)
    End Sub

    Private Sub cbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEstados.SelectedIndexChanged, cbPAGADO.SelectedIndexChanged, cbAño.SelectedIndexChanged
        If semaforo Then Call Busqueda()
    End Sub

    Private Sub cbProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProveedores.SelectedIndexChanged
        If semaforo Then
            If cbProveedores.SelectedIndex <> -1 Then
                sCodProveedor = cbProveedores.SelectedItem.ItemData()
                Call Busqueda()

            End If
        End If
    End Sub

    Private Sub lvPedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPedidos.DoubleClick

        'Dim inumPedido As Integer
        If lvPedidos.SelectedItems.Count > 0 Then
            semaforo = False
            indice = lvPedidos.SelectedIndices(0)
            inumPedido = lvPedidos.Items(indice).Text
            If modo = "B" Then
                Me.Close()
            Else
                Dim GPP As New GestionPedidoProveedor
                GPP.pNumPedido = inumPedido
                GPP.pPedidos = Pedidos
                GPP.iidProveedor = lvPedidos.Items(indice).SubItems(7).Text
                GPP.ShowDialog()
                GPP.Close()
                ActualizaLinea()
            End If
            semaforo = True
        End If

    End Sub

    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call Busqueda()
        End If
    End Sub

    Private Sub Busqueda()
        sel = ""

        If cbTipo.Text <> "TODOS" And cbTipo.SelectedIndex > 0 Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " DOC.idTipoCompra = " & cbTipo.SelectedItem.itemdata
        End If
        If cbProveedores.Text <> "" Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " Proveedores.NombreComercial like '%" & cbProveedores.Text & "%' "
        End If
        If numPedido.Text <> "" Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " DOC.numPedido like '" & Replace(numPedido.Text, "'", "''") & "%' "
        End If

        If cbPedidoProveedor.Text <> "" Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " DOC.PedidoProveedor like '" & Replace(cbPedidoProveedor.Text, "'", "''") & "%'"
        End If
        'If cbEstado.SelectedIndex <> -1 And cbEstado.Text <> "TODOS" Then
        '    sel = sel & IIf(sel = "", "", " AND ")
        '    sel = sel & " DOC.idestado = " & cbEstado.SelectedItem.gidEstado
        'End If
        If lbEstados.SelectedItems.Count > 0 Then
            sel = sel & If(sel = "", "", " AND ")
            Dim rango As String = ""
            For Each item As DatosEstado In lbEstados.SelectedItems
                rango = If(rango = "", "", rango & ", ") & item.gidEstado
            Next
            sel = sel & " DOC.idEstado in (" & rango & ") "
        End If
        If cbArticulo.Text <> "" Or cbCodArticulo.Text <> "" Then
            If cbArticulo.SelectedIndex <> -1 Then
                sel = sel & If(sel = "", "", " AND ")
                sel = sel & " DOC.numPedido in (select numPedido from ConceptosPedidosProv where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
            Else
                sel = sel & If(sel = "", "", " AND ")
                sel = sel & " DOC.numPedido in (select distinct CPP.numPedido  from ConceptosPedidosProv as CPP left join Articulos as AR on AR.idArticulo = CPP.idArticulo" _
                & " where  AR.Articulo  like '%" & cbArticulo.Text & "%') "
            End If
        End If

        If cambioFechas And Not cambioFechasE Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " CONVERT(datetime,CONVERT(Char(10), DOC.fechapedido,103))  >= '" & dtpDesdePedido.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fechapedido,103))  <= '" & dtpHastaPedido.Value.Date & "' "
        End If

        If cambioFechasE And Not cambioFechas Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " CONVERT(datetime,CONVERT(Char(10), DOC.fechaEntrega,103))  >= '" & dtpDesdeEntrega.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fechaEntrega,103))  <= '" & dtpHastaEntrega.Value.Date & "' "
        End If

        If cbAño.SelectedIndex <> -1 And Not cambioFechas And Not cambioFechasE And cbAño.Text <> "" Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " year(DOC.FechaPedido) = " & cbAño.Text
        End If

        If cbPAGADO.Text <> "TODOS" And cbPAGADO.SelectedIndex <> -1 Then
            sel = sel & If(sel = "", "", " AND ")
            If cbPAGADO.Text = "PAGADO" Then
                sel = sel & " DOC.Pagado = 1 "
            Else
                sel = sel & " DOC.Pagado = 0 "
            End If
        End If
        Call actualiza_lvPedidos()

    End Sub

    'BOTONES
    'Cierra el formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        MyBase.Close()

    End Sub

    'Limpia el formulario.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        Call Inicializar()

        Call Busqueda()

    End Sub

    Private Sub lvPedidos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPedidos.ColumnClick

        If Direccion = "ASC" Then

            Direccion = "DESC"

        Else

            Direccion = "ASC"

        End If

        Select Case e.Column

            Case 0
                Orden = "DOC.NumPedido"

            Case 1
                Orden = "PedidoProveedor"

            Case 2
                Orden = "DOC.FechaPedido"

            Case 3
                Orden = "DOC.fechaEntrega"

            Case 4
                Orden = "Proveedor"

            Case 5
                Orden = "Estado"

            Case 6
                Orden = "Base"

        End Select

        Call actualiza_lvPedidos()

    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Height = If(Me.Height < 300, 300, Me.Height)

    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click

        Dim GG As New InformeListadoPedidosProv1

        GG.pBusqueda = sel

        GG.pOrden = Orden

        GG.pTotalEU = Total.Text

        GG.ShowDialog()

    End Sub

    Private Sub cbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged

        If semaforo AndAlso cbTipo.SelectedIndex <> -1 Then

            Call limpiaBusqueda()

            Call introducirProveedores()

            Call introducirPedidoProveedor()

            Call Busqueda()

        End If

    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click

        Dim PP As New GestionPedidoProveedor

        PP.SoloLectura = vSoloLectura

        PP.pNumPedido = 0

        PP.ShowDialog()

        If PP.pNumPedido > 0 Then

            Call Busqueda()

        End If

    End Sub

    Private Sub cbProveedores_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If semaforo AndAlso cbProveedores.Text = "" Then

            cbProveedores.SelectedIndex = -1

            Call Busqueda()

        End If

    End Sub

    Private Sub cbTipo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipo.TextChanged

        If semaforo AndAlso cbTipo.Text = "" Then

            cbTipo.SelectedIndex = -1

            Call Busqueda()

        End If

    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPedidoProveedor.TextChanged, numPedido.TextChanged, cbProveedores.TextChanged

        If semaforo Then

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted

        If semaforo And cbCodArticulo.SelectedIndex <> -1 Then

            semaforo = False

            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.SelectedItem.itemdata)

            Call Busqueda()

            semaforo = True

        End If

    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted

        If semaforo And cbArticulo.SelectedIndex <> -1 Then

            semaforo = False

            cbCodArticulo.Text = funcAR.codArticulo(cbArticulo.SelectedItem.itemdata)

            Call Busqueda()

            semaforo = True

        End If

    End Sub

    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged

        If semaforo Then

            semaforo = False

            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.Text)

            Call Busqueda()

            semaforo = True

        End If

    End Sub

    Private Sub cbArticuloC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.TextChanged

        If semaforo Then

            semaforo = False

            Call Busqueda()

            semaforo = True

        End If

    End Sub

#Region "CAMBIO DE FECHAS"

    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHastaPedido.KeyUp

        If semaforo Then

            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpDesde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDesdePedido.KeyUp

        If semaforo Then

            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesdePedido.CloseUp

        If semaforo Then

            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpHasta_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHastaPedido.CloseUp

        If semaforo Then

            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpHastaEntrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHastaEntrega.KeyUp

        If semaforo Then

            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpDesdeEntrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDesdeEntrega.KeyUp

        If semaforo Then

            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpDesdeEntrega_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesdeEntrega.CloseUp

        If semaforo Then

            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

    Private Sub dtpHastaEntrega_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHastaEntrega.CloseUp

        If semaforo Then

            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value

            cambioFechas = True

            BuscarAhora = True

            retardo.Enabled = True

        End If

    End Sub

#End Region

    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.DropDown, cbArticulo.DropDown

        If cbCodArticulo.Items.Count = 0 Then

            Call IntroducirArticulos() 'Introduce los artículos.

        End If


    End Sub

    Private Sub cbPedidoProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPedidoProveedor.DropDown

        If cbPedidoProveedor.Items.Count = 0 Then

            Call introducirPedidoProveedor() 'Introduce los pedidos de proveedor.

        End If

    End Sub

End Class
