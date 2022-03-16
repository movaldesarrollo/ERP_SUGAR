Public Class subPedidoProvDirecto

    Private iidArticulo As Integer
    Private iidProveedor As Integer
    Private funcPP As New FuncionesPedidosProv
    Private funcCP As New FuncionesConceptosPedidosProv
    Private funcP As New funcionesProveedores
    Private funcES As New FuncionesEstados
    Private funcAP As New FuncionesArticulosProv
    Private funcAR As New FuncionesArticulos
    Private sBusqueda As String
    Private ep1 As New ErrorProvider
    Private dtsP As datosProveedor
    Private dtsPP As DatosPedidoProv
    Private dtsCP As DatosConceptoPedidoProv
    Private dtsAP As DatosArticuloProveedor
    Private dtsAR As DatosArticulo
    Private vSoloLectura As Boolean
    Private iidConceptoPedidoProv As Long
    Private semaforo As Boolean

    Public Property SoloLectura() As Boolean
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


    Public Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property


    Public Property pCantidad() As Double
        Get
            Return Cantidad.Text
        End Get
        Set(ByVal value As Double)
            Cantidad.Text = value
        End Set
    End Property


    Public Property pidConceptoPedidoProv() As Long
        Get
            Return iidConceptoPedidoProv
        End Get
        Set(ByVal value As Long)
            iidConceptoPedidoProv = value
        End Set
    End Property


    Private Sub subPedidoProvDirecto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If iidArticulo = 0 Then
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            semaforo = False

            dtsAR = funcAR.Mostrar1(iidArticulo)
            lbUnidad.Text = dtsAR.gTipoUnidad
            Call inicializar()

            If iidProveedor = 0 Then
                Call introducirProveedores()
                iidProveedor = dtsAR.gidProveedor
                Call CargarProveedor()
            ElseIf iidProveedor <> dtsAR.gidProveedor Then
                Call introducirProveedores()
                dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
                Call CargarProveedor()
            Else
                dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
                Call introducir1Proveedor()
                Call PonerPrecioArticulo()
            End If


            Call Busqueda()
            semaforo = True
        End If


    End Sub


    Private Sub inicializar()
        Me.Text = "PEDIDO " & dtsAR.gArticulo
        iidConceptoPedidoProv = 0
        bNuevo.Enabled = Not vSoloLectura
        bAnadir.Enabled = Not vSoloLectura
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        dtpFecha.Value = Now.Date
        dtpFechaEntrega.Value = Now.Date
    End Sub



    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()
            cbProveedor.Text = ""

            Dim lista As List(Of datosProveedor) = funcP.mostrar(True)
            Dim dts As datosProveedor
            For Each dts In lista
                cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
                If dts.gcodProveedor <> "" Then cbCodProveedor.Items.Add(New IDComboBox(dts.gcodProveedor, dts.gidProveedor))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducir1Proveedor()
        cbCodProveedor.Items.Clear()
        cbProveedor.Items.Clear()
        dtsP = funcP.mostrar1(iidProveedor)
        cbCodProveedor.Items.Add(New IDComboBox(dtsP.gcodProveedor, dtsP.gidProveedor))
        cbProveedor.Items.Add(New IDComboBox(dtsP.gnombrecomercial, dtsP.gidProveedor))
        cbCodProveedor.SelectedIndex = 0
        cbProveedor.SelectedIndex = 0
    End Sub


    Private Sub Busqueda()
        ' sBusqueda = " ((DOC.numPedido in (select numPedido from ConceptosPedidosProv as CPP left join Estados ON Estados.idEstado= CPP.idEstado where Espera = 1 AND idArticulo = " & iidArticulo & ")) "

        sBusqueda = " ((Estados.Cabecera = 1 OR Estados.Espera = 1 OR Estados.EnCurso = 1)  "

        If cbProveedor.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & " AND  DOC.idProveedor = " & cbProveedor.SelectedItem.itemData
        ElseIf cbProveedor.Text <> "" Then
            sBusqueda = sBusqueda & " AND  Proveedores.NombreComercial like '%" & cbProveedor.Text & "%' "
        ElseIf cbCodProveedor.Text <> "" Then
            sBusqueda = sBusqueda & " AND  Proveedores.codProveedor like '" & cbCodProveedor.Text & "%' "
        End If

        sBusqueda = sBusqueda & ") OR (DOC.numPedido in (select numPedido from ConceptosPedidosProv as CPP left join Estados ON Estados.idEstado= CPP.idEstado where Espera = 1 AND idArticulo = " & iidArticulo & ")) "
        Call ActualizarLV()
       
    End Sub


    Private Sub ActualizarLV()
        lvConceptos.Items.Clear()
        Dim lista As List(Of DatosPedidoProv) = funcPP.Busqueda(sBusqueda, " numPedido DESC ", True)
        For Each dts As DatosPedidoProv In lista
            Call NuevaLineaLV(dts)
        Next
    End Sub


    Private Sub NuevaLineaLV(ByVal dts As DatosPedidoProv)
        With lvConceptos.Items.Add(dts.gProveedor)
            .SubItems.Add(dts.gnumPedido)
            .SubItems.Add(dts.gPedidoProveedor)
            .SubItems.Add(dts.gFechaPedido)
            .SubItems.Add(dts.gEstado)
            If funcCP.ContieneArticuloNoServido(dts.gnumPedido, iidArticulo) Then
                .BackColor = Color.PaleTurquoise
            End If
        End With
    End Sub



    Private Sub AbrirPedidoProv()
        Dim GG As New GestionPedidoProveedor
        GG.pNumPedido = dtsPP.gnumPedido
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
    End Sub





    Private Function Validacion() As Boolean
        Validacion = True
        If cbProveedor.SelectedIndex = -1 Then
            Validacion = False
            ep1.SetError(cbProveedor, "Se ha de seleccionar un proveedor")
        End If
        If Cantidad.Text = "" Or Cantidad.Text = "." Or Cantidad.Text = "," Or Cantidad.Text = "-" Then Cantidad.Text = 0
        If Cantidad.Text = 0 Then
            Validacion = False
            ep1.SetError(Cantidad, "Se ha de indicar la cantidad")
        End If
        If dtpFechaEntrega.Value < dtpFecha.Value Then
            Validacion = False
            ep1.SetError(dtpFechaEntrega, "La fecha de entrega no puede ser anterior a la fecha del pedido")
        End If
    End Function


    Private Sub NuevaCabeceraPedido()
        dtsPP = New DatosPedidoProv
        dtsPP.gPedidoProveedor = RefProveedor.Text
        dtsPP.gSolicitadoVia = ""
        dtsPP.gObservaciones = ""
        dtsPP.gFechaPedido = dtpFecha.Value.Date
        dtsPP.gFechaEntrega = dtpFechaEntrega.Value.Date
        dtsPP.gidPersona = Inicio.vIdUsuario
        dtsPP.gidContacto = 0
        dtsPP.gPagado = False
        dtsPP.gNotas = ""
        dtsPP.gidEstado = funcES.EstadoPedidoProv("CABECERA").gidEstado
        dtsPP.gPrecioTransporte = funcPP.UltimoPrecioTransporte(iidProveedor)
        Call CargarDatosProveedor()
        Call CargarDatosUbicacion()
        Call CargarDatosFacturacion()
        dtsPP.gnumPedido = funcPP.insertar(dtsPP)
    End Sub

    Private Sub CargarDatosProveedor()
        dtsPP.gidProveedor = dtsP.gidProveedor
        dtsPP.gidTipoCompra = dtsP.gIdTipoCompra
        dtsPP.gHorarioEntrega = dtsP.ghorario
    End Sub

    Private Sub CargarDatosUbicacion()
        Dim funcU As New funcionesUbicaciones
        Dim dtsU As datosUbicacion = funcU.mostrar1ProvR(iidProveedor)
        dtsPP.gidUbicacion = dtsU.gidUbicacion
        dtsPP.gPortes = dtsU.gPortes
        dtsPP.gTransporte = dtsU.gTransporte
        dtsPP.gidTransporte = dtsU.gidTransporte
    End Sub

    Private Sub CargarDatosFacturacion()
        Dim funcFA As New funcionesFacturacion
        Dim dtsFA As datosfacturacion = funcFA.mostrarProv(iidProveedor)
        dtsPP.gcodMoneda = dtsFA.gcodMoneda
        dtsPP.gDescuento = dtsFA.gDescuento
        dtsPP.gidTipoValorado = dtsFA.gidTipoValorado
        dtsPP.gTipoIVAFac = dtsFA.gTipoIVA
        dtsPP.gidTipoRetencion = dtsFA.gidTipoRetencion
        dtsPP.gTipoRetencionFac = dtsFA.gTipoRetencion
        dtsPP.gidTipoIVA = dtsFA.gidTipoIVA
    End Sub

    Private Sub CargarProveedor()
        If iidProveedor > 0 Then
            dtsP = funcP.mostrar1(iidProveedor)
            cbProveedor.Text = dtsP.gnombrecomercial
            cbCodProveedor.Text = dtsP.gcodProveedor
            Call PonerPrecioArticulo()
        End If
    End Sub

    Private Sub NuevoConceptoPedido()
        If Precio.Text = "" Or Precio.Text = "-" Or Precio.Text = "." Or Precio.Text = "," Then Precio.Text = 0
        dtsCP = New DatosConceptoPedidoProv
        dtsCP.gidArticuloProv = dtsAP.gidArticuloProv
        dtsCP.gArticuloProv = dtsAP.gNombre
        dtsCP.gPrecioNetoUnitario = Precio.Text 'dtsAP.gPrecioUnitario
        dtsCP.gcodArticuloProv = dtsAP.gcodArticuloProv
        dtsCP.gPVPUnitario = 0
        dtsCP.gnumPedido = dtsPP.gnumPedido
        dtsCP.gidArticulo = iidArticulo
        dtsCP.gCantidad = Cantidad.Text
        dtsCP.gDescuento = 0
        dtsCP.gRecibido = False
        dtsCP.gAceptado = False
        dtsCP.gFechaRecibido = Now.Date
        dtsCP.gCantidadRecibida = 0
        dtsCP.gFechaPrevista = dtpFechaEntrega.Value.Date
        dtsCP.gidEstado = funcES.EstadoEspera("C.PEDIDOPROV").gidEstado
        dtsCP.gidTipoIVA = dtsPP.gidTipoIVA
        dtsCP.gTipoIVA = dtsPP.gTipoIVA
        'dtsCP.gidAlbaran = 0
        iidConceptoPedidoProv = funcCP.insertar(dtsCP)
    End Sub

    Private Sub CargarOCrearArticuloProveedor()
        If funcAP.ArticuloExiste(iidArticulo, iidProveedor) Then
            dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
        Else
            Call NuevoArticuloProveedor()
        End If
    End Sub

    Private Sub NuevoArticuloProveedor()
        If iidArticulo > 0 And iidProveedor > 0 Then
            If Precio.Text = "" Or Precio.Text = "-" Or Precio.Text = "." Or Precio.Text = "," Then Precio.Text = 0
            dtsAP = New DatosArticuloProveedor
            dtsAP.gidArticulo = iidArticulo
            dtsAP.gidProveedor = iidProveedor
            dtsAP.gNombre = dtsAR.gArticulo
            dtsAP.gPrecio = Precio.Text
            dtsAP.gPrecioUnitario = dtsAR.gPrecioUnitarioC
            dtsAP.gcodMoneda = dtsAR.gcodMonedaC
            dtsAP.gFechaPrecio = dtsAR.gFechaPrecioC
            dtsAP.gActivo = True
            dtsAP.gcodArticuloProv = dtsAR.gcodArticulo
            dtsAP.gidArticuloProv = funcAP.Guardar(dtsAP)
        End If

    End Sub

    Private Sub PonerPrecioArticulo()
        If iidProveedor = 0 Then
            Precio.Text = FormatNumber(dtsAR.gPrecioUnitarioC, If(dtsAR.gPrecioUnitarioC >= 5, 4, 6))
            lbMoneda1.Text = dtsAR.gSimboloC
        Else
            Precio.Text = FormatNumber(dtsAP.gPrecio, If(dtsAP.gPrecio >= 5, 4, 6))
            lbMoneda1.Text = dtsAP.gSimbolo
        End If

    End Sub


#Region "BOTONES"

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If Validacion() Then
            If MsgBox("¿Crear un nuevo pedido al proveedor con el artículo, cantidad y precio indicados?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                iidProveedor = cbProveedor.SelectedItem.itemdata
                Call CargarOCrearArticuloProveedor()
                dtsP = funcP.mostrar1(iidProveedor)
                dtsPP = New DatosPedidoProv
                Call NuevaCabeceraPedido()
                Call NuevoConceptoPedido()
                funcPP.actualizaEstado(dtsPP.gnumPedido, funcES.EstadoPedidoProv("FINALIZADO").gidEstado)
                Call AbrirPedidoProv()
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub bAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAnadir.Click
        Dim validar As Boolean = True
        If lvConceptos.Items.Count = 0 Then
            validar = False
            MsgBox("No hay pedidos asignables de este proveedor")
        ElseIf lvConceptos.SelectedItems.Count = 0 Then
            validar = False
            MsgBox("Ha de seleccionar alguno de los pedidos")
        End If

        If validar Then
            If lvConceptos.SelectedItems.Count = 0 Then
                validar = False
                MsgBox("Se ha de seleccionar un pedido")
            End If
            If validar Then
                dtsPP = funcPP.Mostrar1(lvConceptos.SelectedItems(0).SubItems(1).Text)
                If iidProveedor <> dtsPP.gidProveedor Then
                    dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
                    Call PonerPrecioArticulo()
                    Call CargarProveedor()
                End If

            End If
            validar = validar And Validacion()
            If validar Then
                If MsgBox("¿Añadir un concepto al pedido seleccionado con el artículo, cantidad y precio indicados?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call NuevoConceptoPedido()
                    Call AbrirPedidoProv()
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub bBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarProveedor.Click
        Dim GG As New busquedaproveedor
        GG.SoloLectura = vSoloLectura
        If GG.pidproveedor > 0 Then
            iidProveedor = GG.pidproveedor
            dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
            Call CargarProveedor()
            Call Busqueda()
        End If
    End Sub

#End Region






#Region "EVENTOS"

    Private Sub Precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Precio.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Precio.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Cantidad.Text = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Cantidad.Text = "" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(Cantidad.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub cbProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectionChangeCommitted
        If cbProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbProveedor.SelectedItem.itemdata
            cbCodProveedor.Text = funcP.campocodProveedor(iidProveedor)
            dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
            Call PonerPrecioArticulo()
            Call Busqueda()
        End If
    End Sub

    Private Sub cbcodProveedor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodProveedor.SelectionChangeCommitted
        If cbCodProveedor.SelectedIndex <> -1 Then
            iidProveedor = cbCodProveedor.SelectedItem.itemdata
            cbProveedor.Text = funcP.campoProveedor(iidProveedor)
            dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
            Call PonerPrecioArticulo()
            Call Busqueda()
        End If
    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, Precio.Click
        sender.selectall()
    End Sub

    Private Sub cbCodProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodProveedor.TextChanged, cbProveedor.TextChanged
        If semaforo Then Call Busqueda()
    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click
        If lvConceptos.SelectedItems.Count > 0 Then
            dtsPP = funcPP.Mostrar1(lvConceptos.SelectedItems(0).SubItems(1).Text)
            iidProveedor = dtsPP.gidProveedor
            dtsAP = funcAP.Mostrar1(iidArticulo, iidProveedor)
            Call PonerPrecioArticulo()
            Call CargarProveedor()
        End If
    End Sub


#End Region

End Class