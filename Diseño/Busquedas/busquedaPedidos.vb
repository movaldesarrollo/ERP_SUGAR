Public Class busquedaPedidos

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private inumPedido As Integer
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesPedidos
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstados
    Private funcMO As New FuncionesMoneda
    Private funcCP As New FuncionesConceptosPedidos
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Pedidos As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private cambioFechasE As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean
    Private verBAnulado As Boolean
    Private soloBAnulado As Boolean
    Private retardo As New Timer
    Private BuscarAhora As Boolean
    Private cmSubMenu As ContextMenu
    Private iidCliente As Integer
    Public Vvercostes As Boolean

    Property pVerClientesPropios() As Boolean
        Get
            Return VerClientesPropios
        End Get
        Set(ByVal value As Boolean)
            VerClientesPropios = value
        End Set
    End Property

    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
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

    Property pModo() As String
        Get
            Return modo
        End Get
        Set(ByVal value As String)
            modo = value
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

    Private Sub busquedaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        colorInactivo = Color.Gray
        colorCabecera = Color.Red
        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        Vvercostes = funcPE.vercostes(iidUsuario) 'luis vercoste
        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False

        cmSubMenu = New ContextMenu
        cmSubMenu.MenuItems.Add("Ver detalles de Producción", New System.EventHandler(AddressOf Me.OnClicksubMenu))
        lvDocumentos.ContextMenu = cmSubMenu

        Call limpiar()
        direccion = "ASC"
        semaforo = False
        Pedidos = New List(Of Integer)
        Call IntroducirResponsables()
        Call IntroducirArticulosC()
        Call introducirClientes()
        Call IntroducirAños()
        Call introducirEstados()
        If iidCliente > 0 Then cbCliente.Text = funcCL.campoCliente(iidCliente)
        Call busqueda()
        semaforo = True

    End Sub

    Protected Sub OnClicksubMenu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            Select Case sender.text
                Case "Ver detalles de Producción"
                    Dim GG As New subPonerEnPruebas
                    GG.SoloLectura = True
                    GG.pnumPedido = lvDocumentos.Items(indice).SubItems(0).Text
                    GG.ShowDialog()
            End Select
        End If

    End Sub

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        numDoc.Text = ""
        cbResponsable.Text = ""
        cbResponsable.SelectedIndex = -1
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        dtpDesdePedido.Value = Now.Date
        dtpHastaPedido.Value = Now.Date
        dtpDesdeEntrega.Value = Now.Date
        dtpHastaEntrega.Value = Now.Date
        'DesdePedido.Text = ""
        'HastaPedido.Text = ""
        lbEstados.SelectedItems.Clear()
        cbAño.Text = Now.Year
        RefCliente.Text = ""
        cambioFechas = False
        cambioFechasE = False
        Orden = ""
        direccion = "ASC"
        verBAnulado = False
        soloBAnulado = False
        semaforo = True
    End Sub

    Private Sub IntroducirResponsables()
        Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(If(VerClientesPropios, Inicio.vIdUsuario, 0))

        For Each item As IDComboBox In lista
            cbResponsable.Items.Add(item)
        Next
        If VerClientesPropios Then
            cbResponsable.Enabled = False
            If lista.Count = 0 Then
                MsgBox("No está autorizado para visualizar clientes")
                Me.Close()
            Else
                cbResponsable.SelectedIndex = 0
            End If
        Else
            cbResponsable.SelectedIndex = -1
        End If

    End Sub

    Private Sub IntroducirArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("VENDIBLE")
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next

    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = funcOF.buscaPrimerDia().Year To Now.Year
            cbAño.Items.Add(Año)
        Next
        cbAño.Text = Now.Year
    End Sub

    Private Sub introducirEstados()
        lbEstados.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Pedido")
        For Each dts As DatosEstado In lista
            lbEstados.Items.Add(dts)
        Next
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        If BuscarAhora Then
            BuscarAhora = False
            retardo.Enabled = False
            Call busqueda()
        End If
    End Sub

    Private Sub busqueda()

        'instrucciones para búsqueda de Cliente
        sBusqueda = ""

        If numDoc.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numPedido like '" & numDoc.Text & "%' "
        End If

        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CLientes.NombreComercial like '%" & cbCliente.Text & "%' "
        End If

        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numPedido in (select numPedido from ConceptosPedidos left join Articulos ON Articulos.idArticulo = ConceptosPedidos.idArticulo where codArticulo = '" & cbCodArticulo.Text & "') "
        ElseIf cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numPedido in (select numPedido from ConceptosPedidos where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
        End If


        If cbResponsable.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.idResponsableCuenta = " & cbResponsable.SelectedItem.itemdata
        End If

        If soloBAnulado Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.bAnulado = 1 "
        ElseIf lbEstados.SelectedItems.Count > 0 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            Dim rango As String = ""
            For Each item As DatosEstado In lbEstados.SelectedItems
                rango = If(rango = "", "", rango & ", ") & item.gidEstado
            Next
            sBusqueda = sBusqueda & " DOC.idEstado in (" & rango & ") "
        End If
        If cambioFechas And Not cambioFechasE Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpDesdePedido.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpHastaPedido.Value.Date & "' "
            'If IsDate(DesdePedido.Text) And IsDate(HastaPedido.Text) Then
            '    sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & DesdePedido.Text & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & HastaPedido.Text & "' "
            'End If
        End If
        If cambioFechasE And Not cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fechaEntrega,103))  >= '" & dtpDesdeEntrega.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fechaEntrega,103))  <= '" & dtpHastaEntrega.Value.Date & "' "
        End If

        If RefCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.ReferenciaCliente like '" & RefCliente.Text & "%' "
        End If

        If cbAño.SelectedIndex <> -1 And Not cambioFechas And Not cambioFechasE Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " year(DOC.Fecha) = " & cbAño.Text
        End If

        If Not verBAnulado And Not soloBAnulado Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.bAnulado = 0 "
        End If
        Call ActualizarLV()

    End Sub

    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Pedidos.Clear()
            'lvwColumnSorter = New OrdenarLV()
            'lvDocumentos.ListViewItemSorter = lvwColumnSorter
            Dim Suma As Double = 0
            Dim Portes As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim Servido As Double = 0
            Dim lista As List(Of DatosPedido) = funcOF.Busqueda(sBusqueda, Orden, True)
            For Each dts As DatosPedido In lista
                Pedidos.Add(dts.gnumPedido)
                With lvDocumentos.Items.Add(dts.gnumPedido)
                    .SubItems.Add(dts.gCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gFechaEntrega)
                    .SubItems.Add(dts.gEstado)

                    'Si no tiene permisos para ver costes saldrán los campos vacios.
                    If Vvercostes = True Then
                        .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
                        .SubItems.Add(FormatNumber(dts.gPrecioTransporte, 2) & dts.gSimbolo)
                        .SubItems.Add(dts.gReferenciaCliente)
                        .SubItems.Add(FormatNumber(dts.gPendienteServir, 2) & dts.gSimbolo)
                        .SubItems.Add(FormatNumber(dts.gServido, 2) & dts.gSimbolo)
                    End If
                    Select Case dts.gEstado
                        Case "PENDIENTE" 'Letra color rojo fondo blanco.
                            .ForeColor = Color.White
                            .BackColor = Color.Red
                        Case "PRODUCCIÓN" 'Letra color naranja.
                            .ForeColor = Color.OrangeRed
                        Case "PRODUCIDO" 'Letra color negro fondo color naranja.
                            .ForeColor = Color.Black
                            .BackColor = Color.Orange
                        Case "PARCIAL" 'Letra color azul.
                            .ForeColor = Color.Blue
                        Case "PREPARADO"
                            If funcCP.TodoPreparado(dts.gnumPedido) Then
                                .ForeColor = Color.Green  'Letra color verde.
                            Else
                                .ForeColor = Color.Black 'Letra color negra.
                            End If
                        Case "SERVIDO" 'Letra color negro fondo color verde
                            .BackColor = Color.LightGreen
                            .ForeColor = Color.Black
                        Case "ANULADO" 'Letra color gris.
                            .ForeColor = Color.Gray
                    End Select

                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase '- dts.gPrecioTransporte
                        Portes = Portes + dts.gPrecioTransporte
                        Servido = Servido + dts.gServido
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                        Portes = Portes + funcMO.Cambio(dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        Servido = Servido + funcMO.Cambio(dts.gServido, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    End If
                End With
            Next
            Contador.Text = lvDocumentos.Items.Count
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG

            'Si no tiene permisos para ver costes saldrán los campos vacios.
            If Vvercostes = True Then
                Total.Text = FormatNumber(Suma, 2)
                TotalPortes.Text = FormatNumber(Portes, 2)
                TotalServido.Text = FormatNumber(Servido, 2)
                TotalPendiente.Text = FormatNumber(Suma - Servido, 2)
            Else
                Total.Text = ("")
                TotalPortes.Text = ("")
                TotalServido.Text = ("")
                TotalPendiente.Text = ("")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            inumPedido = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosPedido = funcOF.Mostrar1(inumPedido)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dtsOF.gCliente
                .SubItems(2).Text = dtsOF.gFecha
                .SubItems(3).Text = dtsOF.gFechaEntrega
                .SubItems(4).Text = dtsOF.gEstado
                If Vvercostes = True Then
                    .SubItems(5).Text = FormatNumber(dtsOF.gBase, 2) & dtsOF.gSimbolo
                    .SubItems(6).Text = FormatNumber(dtsOF.gPrecioTransporte, 2) & dtsOF.gSimbolo
                    .SubItems(7).Text = dtsOF.gReferenciaCliente
                    .SubItems(8).Text = FormatNumber(dtsOF.gPendienteServir, 2) & dtsOF.gSimbolo
                    .SubItems(9).Text = FormatNumber(dtsOF.gServido, 2) & dtsOF.gSimbolo
                End If
                Select Case dtsOF.gEstado
                    Case "PENDIENTE" 'Letra color blanco fondo rojo.
                        .ForeColor = Color.White
                        .BackColor = Color.Red
                    Case "PRODUCCIÓN" 'Letra color naranja.
                        .ForeColor = Color.OrangeRed
                    Case "PRODUCIDO" 'Letra color negro fondo color naranja.
                        .ForeColor = Color.Black
                        .BackColor = Color.Orange
                    Case "PARCIAL" 'Letra color azul.
                        .ForeColor = Color.Blue
                    Case "PREPARADO" 'Letra color verde.
                        If funcCP.TodoPreparado(dtsOF.gnumPedido) Then
                            .ForeColor = Color.Green  'Letra color verde.
                        Else
                            .ForeColor = Color.Black 'Letra color negra.
                        End If
                    Case "SERVIDO" 'Letra color negro fondo color verde
                        .BackColor = Color.LightGreen
                        .ForeColor = Color.Black
                    Case "ANULADO" 'Letra color gris.
                        .ForeColor = Color.Gray
                End Select
                'If funcES.Cabecera(dtsOF.gidEstado) Then
                '    .ForeColor = colorCabecera
                'Else
                '    .ForeColor = Color.Black
                'End If
                'If funcES.Bloqueado(dtsOF.gidEstado) Then
                '    .ForeColor = colorInactivo
                'Else
                '    .ForeColor = Color.Black
                'End If
                'If dtsOF.gbAnulado Then
                '    .ForeColor = Color.DarkRed
                'End If
            End With
        End If
    End Sub

    Private Sub RecalcularTotalizadores()
        Dim Suma As Double = 0
        Dim Portes As Double = 0
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambioG As Date = Now.Date
        Dim FechaCambio As Date = Now.Date
        Dim Servido As Double = 0
        Dim lista As List(Of DatosPedido) = funcOF.Busqueda(sBusqueda, Orden, True)
        For Each dts As DatosPedido In lista
            If dts.gcodMoneda = "EU" Then
                Suma = Suma + dts.gBase '- dts.gPrecioTransporte
                Portes = Portes + dts.gPrecioTransporte
                Servido = Servido + dts.gServido
            Else
                Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
                Portes = Portes + funcMO.Cambio(dts.gPrecioTransporte, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                Servido = Servido + funcMO.Cambio(dts.gServido, dts.gcodMoneda, "EU", Aviso, FechaCambio)
            End If
        Next
        Contador.Text = lvDocumentos.Items.Count
        lbCambio.Text = "CAMBIO " & FechaCambioG
        lbCambio.Visible = AvisoG
        If Vvercostes = True Then
            Total.Text = FormatNumber(Suma, 2)
            TotalServido.Text = FormatNumber(Servido, 2)
            TotalPendiente.Text = FormatNumber(Suma - Servido, 2)
            TotalPortes.Text = FormatNumber(Portes, 2)
        Else
            Total.Text = ("")
            TotalPortes.Text = ("")
            TotalServido.Text = ("")
            TotalPendiente.Text = ("")
        End If
    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
        Call busqueda()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionPedido
        GG.SoloLectura = vsoloLectura
        GG.pnumPedido = 0
        GG.ShowDialog()
        If GG.pnumPedido > 0 Then
            Call busqueda()
        End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoPedidos
        GG.pBusqueda = sBusqueda
        GG.pOrden = Orden
        If Vvercostes = True Then
            GG.pTotalEU = Total.Text
            GG.pTotalPortes = TotalPortes.Text
            GG.pTotalServido = TotalServido.Text
            GG.pTotalPendientes = TotalPendiente.Text
        Else
            GG.pTotalEU = "0"
            GG.pTotalPortes = "0"
            GG.pTotalServido = "0"
            GG.pTotalPendientes = "0"
            GG.bTotales.Visible = False
            GG.bDetalle.Visible = False
        End If
        GG.ShowDialog()
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numPedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick

        Try
            If lvDocumentos.SelectedItems.Count > 0 Then

                indice = lvDocumentos.SelectedIndices(0)

                If modo = "B" Then
                    inumPedido = lvDocumentos.Items(indice).Text
                    Me.Close()
                Else
                    Dim GP As New GestionPedido
                    GP.pnumPedido = lvDocumentos.SelectedItems(0).Text

                    GP.pPedidos = Pedidos
                    GP.SoloLectura = vsoloLectura
                    GP.pIndice = indice
                    Try
                        GP.ShowDialog()
                    Catch ex As Exception

                    End Try

                    Call ActualizarLineaLV()
                    Call RecalcularTotalizadores()
                End If

            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'Me.Width = 952
        Me.Height = If(Me.Height < 300, 300, Me.Height)
    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbResponsable.SelectedIndexChanged, cbAño.SelectedIndexChanged
        If semaforo Then Call busqueda()
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbCliente.TextChanged, RefCliente.TextChanged
        If semaforo Then
            BuscarAhora = True

            retardo.Enabled = True

            'If sender.Name = "DesdePedido" AndAlso IsDate(DesdePedido.Text) Then

            '    dtpDesdePedido.Value = CDate(DesdePedido.Text)
            '    HastaPedido.Text = dtpHastaPedido.Value.Date
            '    cambioFechas = True
            '    BuscarAhora = True
            '    retardo.Enabled = True
            'End If

            'If sender.Name = "HastaPedido" AndAlso IsDate(HastaPedido.Text) Then
            '    dtpHastaPedido.Value = CDate(HastaPedido.Text)
            '    DesdePedido.Text = dtpDesdePedido.Value.Date
            '    cambioFechas = True
            '    BuscarAhora = True
            '    retardo.Enabled = True
            'End If

        End If

    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        If semaforo And cbCodArticulo.SelectedIndex <> -1 Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.SelectedItem.itemdata)
            Call busqueda()
            semaforo = True
        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If semaforo And cbArticulo.SelectedIndex <> -1 Then
            semaforo = False
            cbCodArticulo.Text = funcAR.codArticulo(cbArticulo.SelectedItem.itemdata)
            Call busqueda()
            semaforo = True
        End If
    End Sub

    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged
        If semaforo Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.Text)
            Call busqueda()
            semaforo = True
        End If

    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If direccion = "ASC" Then
                direccion = "DESC"
            Else
                direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                Orden = "numPedido"
            Case 1
                Orden = "Cliente"
            Case 2
                Orden = "Fecha"
            Case 3
                Orden = "FechaEntrega"
            Case 4
                Orden = "Estado"
            Case 5
                Orden = "Base"
            Case 6
                Orden = "PrecioTransporte"
            Case 7
                Orden = "ReferenciaCliente"
            Case 8
                Orden = "PendienteServir"
            Case 9
                Orden = "Servido"

        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

#Region "CAMBIO DE FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHastaPedido.KeyUp, dtpDesdePedido.KeyUp
        If semaforo Then
            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesdePedido.CloseUp, dtpHastaPedido.CloseUp
        If semaforo Then
            If dtpHastaPedido.Value < dtpDesdePedido.Value Then dtpHastaPedido.Value = dtpDesdePedido.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub dtpHastaEntrega_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHastaEntrega.KeyUp, dtpDesdeEntrega.KeyUp
        If semaforo Then
            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value
            cambioFechasE = True
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub dtpDesdeEntrega_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesdeEntrega.CloseUp, dtpHastaEntrega.CloseUp
        If semaforo Then
            If dtpHastaEntrega.Value < dtpDesdeEntrega.Value Then dtpHastaEntrega.Value = dtpDesdeEntrega.Value
            cambioFechasE = True
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

#End Region

    Private Sub lbEstados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEstados.SelectedIndexChanged
        If semaforo Then Call busqueda()
    End Sub

    Private Sub numFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numDoc.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub bGuardar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvDocumentos.KeyDown, TotalPortes.KeyDown, numDoc.KeyDown, bLimpiar.KeyDown, cbCliente.KeyDown, cbResponsable.KeyDown, cbArticulo.KeyDown, cbCodArticulo.KeyDown, dtpDesdeEntrega.KeyDown, dtpDesdePedido.KeyDown, dtpHastaEntrega.KeyDown, dtpHastaPedido.KeyDown, RefCliente.KeyDown, lbEstados.KeyDown, bListado.KeyDown, TotalServido.KeyDown, TotalPendiente.KeyDown
        If e.Control And e.Alt And (e.KeyValue = Asc("n") Or e.KeyValue = Asc("N")) Then
            verBAnulado = Not verBAnulado
            Call busqueda()
        End If
        If e.Control And e.Alt And (e.KeyValue = Asc("m") Or e.KeyValue = Asc("M")) Then
            soloBAnulado = Not soloBAnulado
            Call busqueda()
        End If
    End Sub

    Private Sub cbResponsable_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbResponsable.TextChanged
        If semaforo And cbResponsable.Text = "" Then Call busqueda()
    End Sub

#End Region

    Private Sub dtpHastaEntrega_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHastaEntrega.ValueChanged

    End Sub
End Class