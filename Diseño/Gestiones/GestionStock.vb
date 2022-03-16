Public Class GestionStock

    Dim funcUM As New FuncionesTiposUnidad
    Dim funcAR As New FuncionesArticulos
    Dim funcFA As New FuncionesFamilias
    Dim funcSF As New FuncionessubFamilias
    Dim funcST As New FuncionesStock
    Dim funcAL As New FuncionesAlmacenes
    Private funcALB As New FuncionesAlbaranes
    Dim dtsAR As DatosArticulo
    Dim vSoloLectura As Boolean
    Dim iidArticulo As Integer
    Dim iidUsuario As Integer
    Dim iidUnidad As Integer
    Dim scodMoneda As String
    Dim semaforo As Boolean
    Dim iidStock As Integer

    Dim OrdenA As String = ""
    Dim DireccionA As String
    Dim OrdenF As String = ""
    Dim DireccionF As String
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private sBusqueda As String
    Private sOrden As String

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property




    Private Sub GestionStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 950 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 900
        End If
        rbArticulo.Checked = True
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        Call InicializarGeneral()
        Call Cambiogb()
        bGuardarConcepto.Enabled = Not vSoloLectura

        semaforo = True
    End Sub


#Region "INICIALIZACIÓN"

    Private Sub InicializarGeneral()
        iidUsuario = Inicio.vIdUsuario
        DireccionA = "DESC"
        DireccionF = "DESC"
        OrdenA = " idStock "
        OrdenF = " idStock "
        Call CargarMovimientos()
        Call limpiaEdicion()
        Call IntroducirArticulos()
        Call IntroducirAlmacenes()
        Call introducirProveedores()
    End Sub


    Private Sub limpiaEdicion()

        ep1.Clear()
        ep2.Clear()
        dtpFecha.Value = Now.Date
        Cantidad.Text = 0
        PrecioUnitario.Text = 0
        dtpFecha.Value = Now.Date
        Movimiento.Text = ""
        dtpDesde.Value = Now.Date
        dtpHasta.Value = Now.Date
        rbMovimiento.Checked = True
        rbRegularizacion.Checked = False
        cbMovimientoF.Text = ""
        'cbMovimientoF.SelectedIndex = -1
        cbMovimientoF.Text = "TODOS"
        cbPRoveedor.SelectedIndex = -1
    End Sub

    Private Sub LimpiarBusqueda()
        ep1.Clear()
        ep2.Clear()
        cbMovimientoA.Text = "TODOS"
        'cbMovimientoA.SelectedIndex = -1
        cbcodArticulo.Text = ""
        cbcodArticulo.SelectedIndex = -1
        cbNombre.Text = ""
        cbNombre.SelectedIndex = -1
        cbProveedorA.Text = ""
        cbProveedorA.SelectedIndex = -1
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

    Private Sub IntroducirArticulos()
        'Cargar los combobox de códigos y nombres
        cbcodArticulo.Items.Clear()
        cbNombre.Items.Clear()
        cbNombre.Text = ""
        cbcodArticulo.Text = ""
      
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("TODOS")
        Dim dts As IDComboBox3
        For Each dts In lista
            If dts.Name1 <> "" Then cbcodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
            cbNombre.Items.Add(New IDComboBox(dts.Name2, dts.ItemData))
        Next
      
    End Sub


    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()
            cbProveedor.Text = ""

            cbProveedorA.Items.Clear()
            cbProveedorA.Text = ""

            Dim funcP As New funcionesProveedores
            Dim lista As List(Of datosProveedor) = funcP.mostrar(True)
            Dim dts As datosProveedor
            Dim dato As IDComboBox
            For Each dts In lista
                dato = New IDComboBox(dts.gnombrecomercial, dts.gidProveedor)
                cbPRoveedor.Items.Add(dato)
                cbProveedorA.Items.Add(dato)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarMovimientos()

        cbMovimientoF.Items.Clear()
        cbMovimientoF.Items.Add("TODOS")
        cbMovimientoF.Items.Add("IMPORTACIÓN")
        cbMovimientoF.Items.Add("REGULARIZACIÓN")
        cbMovimientoF.Items.Add("BAJA")
        cbMovimientoF.Items.Add("RECEPCIÓN")
        cbMovimientoF.Items.Add("ENTREGA")
        cbMovimientoF.Items.Add("PRODUCCIÓN")
        cbMovimientoF.Text = "TODOS"

        cbMovimientoA.Items.Clear()
        cbMovimientoA.Items.Add("TODOS")
        cbMovimientoA.Items.Add("IMPORTACIÓN")
        cbMovimientoA.Items.Add("REGULARIZACIÓN")
        cbMovimientoA.Items.Add("BAJA")
        cbMovimientoA.Items.Add("RECEPCIÓN")
        cbMovimientoA.Items.Add("ENTREGA")
        cbMovimientoA.Items.Add("PRODUCCIÓN")
        cbMovimientoA.Text = "TODOS"
    End Sub


#End Region


#Region "CARGAR DATOS"


    Private Sub CargarArticulo()
        'Presentar los datos del artículo
        dtsAR = funcAR.Mostrar1(iidArticulo)
        cbNombre.Text = dtsAR.gArticulo
        iidArticulo = dtsAR.gidArticulo
        cbNombre.Text = dtsAR.gArticulo
        cbcodArticulo.Text = dtsAR.gcodArticulo
        iidUnidad = dtsAR.gidUnidad
        scodMoneda = dtsAR.gcodMonedaC
        If cbNombre.SelectedIndex = -1 Then 'Si el artículo no está en la lista
            Call IntroducirArticulos()
            cbNombre.Text = dtsAR.gArticulo
            cbcodArticulo.Text = dtsAR.gcodArticulo
        End If
      
        If cbMovimientoA.Text = "RECEPCIÓN" Then
            lbPrecio.Text = "COSTE"
            lbMonedaC.Text = dtsAR.gSimboloC
            PrecioUnitario.Text = dtsAR.gPrecioUnitarioC
        Else
            lbPrecio.Text = "PVP"
            lbMonedaC.Text = dtsAR.gSimboloV
            PrecioUnitario.Text = dtsAR.gPrecioUnitarioV
        End If
        lbUnidades.Text = dtsAR.gTipoUnidad
        lbUnidad2.Text = lbUnidades.Text
        lbUnidad3.Text = lbUnidades.Text
        Call CargarMovimientosArticulo()
        CantidadTotal.Text = FormatNumber(dtsAR.gCantidadStock, 2)
        StockMinimo.Text = FormatNumber(dtsAR.gStockMinimo, 2)
    End Sub


    Private Sub CargarMovimientosArticulo()
        lvMovimientosArticulo.Items.Clear()
        
        If iidArticulo > 0 Then
            Dim sel As String = " Stock.idArticulo = " & iidArticulo
            Select Case cbMovimientoA.Text
                Case "TODOS"
                Case ""
                Case "RECEPCIÓN"
                    sel = sel & " AND idConceptoProv > 0 "
                Case "ENTREGA"
                    sel = sel & " AND idConceptoAlbaran > 0 "
                Case "PRODUCCIÓN"
                    sel = sel & " AND (CR.idProduccion > 0  or CR.idConceptoPedido > 0) "
                Case "REGULARIZACIÓN"
                    sel = sel & " AND Movimiento like 'REGULARIZACIÓN%'"
                Case Else
                    sel = sel & " AND Movimiento like '%" & cbMovimientoA.Text & "%' "
            End Select
            If cbProveedorA.SelectedIndex <> -1 Then
                sel = sel & If(sel = "", "", " AND ")
                sel = sel & " PRoveedores.idProveedor = " & cbProveedorA.SelectedItem.itemData
            End If
            Dim lista As List(Of DatosStock) = funcST.Busqueda(sel, OrdenA & " " & DireccionA)
            Dim dts As DatosStock
            For Each dts In lista
                Call lvConceptosNuevaLineaArticulo(dts)
            Next
            sBusqueda = sel
            sOrden = OrdenA & " " & DireccionA
        End If
    End Sub


    Private Sub CargarMovimientosFecha()
        lvMovimientosFecha.Items.Clear()
       
        Dim sel As String = " CONVERT(datetime,CONVERT(Char(10), fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), fecha,103))  <= '" & dtpHasta.Value.Date & "' "
        Select Case cbMovimientoF.Text
            Case "TODOS"
            Case ""
            Case "RECEPCIÓN"
                sel = sel & " AND idConceptoProv > 0 "
            Case "ENTREGA"
                sel = sel & " AND idConceptoAlbaran > 0 "
            Case "PRODUCCIÓN"
                sel = sel & " AND (CR.idProduccion > 0 OR CR.idConceptoPedido > 0) "
            Case "REGULARIZACIÓN"
                sel = sel & " AND Movimiento like 'REGULARIZACIÓN%'"
            Case Else
                sel = sel & " AND Movimiento like '%" & cbMovimientoF.Text & "%' "
        End Select
        If cbPRoveedor.SelectedIndex <> -1 Then
            sel = sel & If(sel = "", "", " AND ")
            sel = sel & " PRoveedores.idProveedor = " & cbPRoveedor.SelectedItem.itemData
        End If

        Dim lista As List(Of DatosStock) = funcST.Busqueda(sel, OrdenF & " " & DireccionF)
        Dim dts As DatosStock
        For Each dts In lista
            Call lvConceptosNuevaLineaFecha(dts)
        Next
        sBusqueda = sel
        sOrden = OrdenF & " " & DireccionF
        Contador.Text = lista.Count
    End Sub

#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub lvConceptosNuevaLineaArticulo(ByVal dts As DatosStock)
        'Añade una linea al ListView lvConceptos
        With lvMovimientosArticulo.Items.Add(dts.gidStock)
            .SubItems.Add(dts.gFecha)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(UCase(dts.gMovimiento))
            .SubItems.Add(dts.gnumPedidoProv)
            .SubItems.Add(dts.gnumAlbaran)
            .SubItems.Add(dts.gnumPedido)
            .SubItems.Add(dts.gCantidad)
            .SubItems.Add(dts.gProveedor)
        End With

    End Sub

    Private Sub lvConceptosNuevaLineaFecha(ByVal dts As DatosStock)
        'Añade una linea al ListView lvConceptos
        With lvMovimientosFecha.Items.Add(dts.gidStock)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(dts.gFecha)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(UCase(dts.gMovimiento))
            .SubItems.Add(dts.gnumPedidoProv)
            .SubItems.Add(dts.gnumAlbaran)
            .SubItems.Add(dts.gnumPedido)
            .SubItems.Add(dts.gCantidad)
            .SubItems.Add(dts.gProveedor)
        End With

    End Sub

    Private Sub CalculaTotal()
        Dim item As ListViewItem
        Dim total As Double = 0
        For Each item In lvMovimientosArticulo.Items
            total = total + item.SubItems(7).Text
        Next
        CantidadTotal.Text = FormatNumber(total, 2)

    End Sub

    Private Sub Cambiogb()
        Dim sdp As System.Drawing.Point
        sdp.X = 6
        Dim sds As System.Drawing.Size
        sds.Width = 921 '834 'Anchura de los groupBox
        If rbArticulo.Checked Then
            bGuardarConcepto.Visible = True
            gbFecha1.Visible = False
            gbFecha2.Visible = False
            sdp.Y = 165
            gbArticulo1.Location = sdp
            'sds.Height = 74
            'gbArticulo1.Size = sds
            sdp.Y = 260 '243
            gbArticulo2.Location = sdp
            sds.Height = Me.Height - 295 - 17
            gbArticulo2.Size = sds
            gbArticulo1.Visible = True
            gbArticulo2.Visible = True
            Call CargarMovimientosArticulo()
        Else
            bGuardarConcepto.Visible = False
            gbArticulo1.Visible = False
            gbArticulo2.Visible = False
            sdp.Y = 165
            gbFecha1.Location = sdp
            sds.Height = 47
            gbFecha1.Size = sds
            sdp.Y = 215
            gbFecha2.Location = sdp
            sds.Height = Me.Height - 261
            gbFecha2.Size = sds
            gbFecha1.Visible = True
            gbFecha2.Visible = True
            Call CargarMovimientosFecha()
        End If

    End Sub

#End Region

#Region "BOTONES "

    Private Sub BBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticulo.Click
        Dim BA As New BusquedaSimpleArticulo
        BA.SoloLectura = vSoloLectura
        BA.pidProveedor = 0
        BA.pModo = "P"
        BA.ShowDialog()
        iidArticulo = BA.pidArticulo
        Call CargarArticulo()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bGuardarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarConcepto.Click
        ep1.Clear()
        ep2.Clear()
        Dim validar As Boolean = True
        If Cantidad.Text = "" Then Cantidad.Text = 0
        If rbRegularizacion.Checked Then
            If Cantidad.Text - CantidadTotal.Text = 0 Then
                validar = False
                ep1.SetIconAlignment(Cantidad, ErrorIconAlignment.MiddleLeft)
                ep1.SetError(Cantidad, "La cantidad resultante no cambiaría")
            End If

        Else
            If Cantidad.Text = 0 Then
                validar = False
                ep1.SetIconAlignment(Cantidad, ErrorIconAlignment.MiddleLeft)
                ep1.SetError(Cantidad, "La cantidad no puede ser 0")
            End If
            If Movimiento.Text = "" Then
                validar = False
                ep1.SetError(Movimiento, "Se ha de anotar la descripción del movimiento manual.")
            End If
        End If

        If iidArticulo = 0 Then
            validar = False
            ep1.SetError(cbNombre, "Se ha de seleccionar un artículo.")
        End If

        If cbAlmacen.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbAlmacen, "Se ha de indicar el almacén.")
        End If

        If validar Then
            Dim dts As New DatosStock
            dts.gidArticulo = iidArticulo
            dts.gidStock = 0
            dts.gidAlmacen = cbAlmacen.SelectedItem.itemData
            dts.gidPersona1 = iidUsuario
            dts.gidPersona2 = 0
            dts.gidConceptoProv = 0
            dts.gidConceptoAlbaran = 0
            dts.gidConceptoPedido = 0
            dts.gidProduccion = 0

            dts.gTipoUnidad = lbUnidades.Text
            dts.gMovimiento = Movimiento.Text
            dts.gnumAlbaran = 0
            dts.gnumPedido = 0
            dts.gnumPedidoProv = 0
            dts.gFecha = dtpFecha.Value.Date
            dts.gidUnidad = iidUnidad
            dts.gcodMoneda = scodMoneda
            dts.gPrecio = funcAR.PrecioCoste(iidArticulo)
            If rbRegularizacion.Checked Then
                'Si hacemos una regularización, restamos el stock actual y añadimos el nuevo
                dts.gCantidad = Cantidad.Text - CantidadTotal.Text
                dts.gMovimiento = Microsoft.VisualBasic.Left("REGULARIZACIÓN " & dts.gMovimiento, 50)
                If dts.gCantidad <> 0 Then
                    Call NuevoMovimiento(dts)
                End If
            Else
                dts.gCantidad = Cantidad.Text
                Call NuevoMovimiento(dts)
            End If

            Call limpiaEdicion()

            Call CalculaTotal()
        End If
    End Sub

    Private Sub NuevoMovimiento(ByVal dts As DatosStock)
        dts.gidStock = funcST.insertar(dts)
        
        With lvMovimientosArticulo.Items.Insert(0, dts.gidStock) 'Insertar al principio del listview
            .SubItems.Add(dts.gFecha)
            .SubItems.Add(FormatNumber(dts.gCantidad, 2) & dts.gTipoUnidad)
            .SubItems.Add(UCase(dts.gMovimiento))
            .SubItems.Add(dts.gnumPedidoProv)
            .SubItems.Add(dts.gnumAlbaran)
            .SubItems.Add(dts.gnumPedido)
            .SubItems.Add(dts.gCantidad)
        End With


    End Sub

    Private Sub bNuevoConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiaEdicion()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If rbArticulo.Checked Then
            If lvMovimientosArticulo.Items.Count > 0 Then
                InformeListadoStock.verInformeArticulo(sBusqueda, sOrden)
                InformeListadoStock.ShowDialog()
            End If
        Else
            If lvMovimientosFecha.Items.Count > 0 Then
                InformeListadoStock.verInformeFecha(sBusqueda, sOrden, "DESDE " & dtpDesde.Value.Date & " HASTA " & dtpHasta.Value.Date)
                InformeListadoStock.ShowDialog()
            End If

        End If

    End Sub

    Private Sub bAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAlmacen.Click
        Dim almacen1 As String = cbAlmacen.Text
        Dim GG As New gestionAlmacenes
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call IntroducirAlmacenes()
        cbAlmacen.Text = almacen1
    End Sub

#End Region


#Region "EVENTOS"

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, PrecioUnitario.Click
        sender.SelectAll()
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc("-") And Len(Cantidad.Text) = 1 And Cantidad.Text <> "-" Then
        Else
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
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioUnitario.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc("-") And Len(PrecioUnitario.Text) = 1 And PrecioUnitario.Text <> "-" Then
        Else
            If KeyAscii = Asc(".") Then
                e.KeyChar = ","
            End If
            If PrecioUnitario.Text = "-" Then
                KeyAscii = CShort(SoloNumeros(KeyAscii))
            Else
                If PrecioUnitario.Text = "" Then
                    KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
                Else
                    If InStr(PrecioUnitario.Text, ",") Then
                        KeyAscii = CShort(SoloNumeros(KeyAscii))
                    Else
                        KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                    End If
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub codArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticulo.SelectedIndexChanged

        If cbcodArticulo.SelectedIndex > -1 Then
            iidArticulo = cbcodArticulo.SelectedItem.itemdata
            Call CargarArticulo()
        End If

    End Sub

    Private Sub cbNombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNombre.SelectedIndexChanged
        If cbNombre.SelectedIndex > -1 Then
            iidArticulo = cbNombre.SelectedItem.itemdata
            Call CargarArticulo()
        End If
    End Sub

    Private Sub lvConceptosA_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMovimientosArticulo.DoubleClick
        If lvMovimientosArticulo.SelectedItems.Count > 0 Then
            Dim inumDoc As Integer = lvMovimientosArticulo.SelectedItems(0).SubItems(4).Text 'numPedidoProv
            If inumDoc > 0 Then
                Dim GP As New GestionPedidoProveedor
                GP.SoloLectura = vSoloLectura
                GP.pNumPedido = inumDoc
                GP.ShowDialog()
            End If
            inumDoc = lvMovimientosArticulo.SelectedItems(0).SubItems(5).Text 'numAlbaran
            If inumDoc > 0 Then
                If funcALB.idCliente(inumDoc) > 0 Then
                    Dim GP As New GestionAlbaran
                    GP.SoloLectura = vSoloLectura
                    GP.pnumAlbaran = inumDoc
                    GP.ShowDialog()
                Else
                    Dim GP As New GestionAlbaranAProv
                    GP.SoloLectura = vSoloLectura
                    GP.pnumAlbaran = inumDoc
                    GP.ShowDialog()
                End If

            End If
            inumDoc = lvMovimientosArticulo.SelectedItems(0).SubItems(6).Text 'numPedido
            If inumDoc > 0 Then
                Dim GP As New GestionPedido
                GP.SoloLectura = vSoloLectura
                GP.pnumPedido = inumDoc
                GP.ShowDialog()
            End If
        End If
    End Sub

    Private Sub lvConceptosF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMovimientosFecha.DoubleClick
        'Al hacer doble click, se abre el documento relacionado
        If lvMovimientosFecha.SelectedItems.Count > 0 Then
            Dim inumDoc As Integer = lvMovimientosFecha.SelectedItems(0).SubItems(6).Text 'numPedidoProv
            If inumDoc > 0 Then
                Dim GP As New GestionPedidoProveedor
                GP.SoloLectura = vSoloLectura
                GP.pNumPedido = inumDoc
                GP.ShowDialog()
            End If
            inumDoc = lvMovimientosFecha.SelectedItems(0).SubItems(7).Text 'numAlbaran
            If inumDoc > 0 Then
                If funcALB.idCliente(inumDoc) > 0 Then
                    Dim GP As New GestionAlbaran
                    GP.SoloLectura = vSoloLectura
                    GP.pnumAlbaran = inumDoc
                    GP.ShowDialog()
                Else
                    Dim GP As New GestionAlbaranAProv
                    GP.SoloLectura = vSoloLectura
                    GP.pnumAlbaran = inumDoc
                    GP.ShowDialog()
                End If
            End If
            inumDoc = lvMovimientosFecha.SelectedItems(0).SubItems(8).Text 'numPedido
            If inumDoc > 0 Then
                Dim GP As New GestionPedido
                GP.SoloLectura = vSoloLectura
                GP.pnumPedido = inumDoc
                GP.ShowDialog()
            End If
        End If
    End Sub

    Private Sub rvFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rvFecha.CheckedChanged
        If semaforo Then
            Call Cambiogb()
        End If

    End Sub

    Private Sub dtpFechaAlta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.DropDown 'dtpDesde.ValueChanged, dtpHasta.ValueChanged
        If semaforo Then
            Call CargarMovimientosFecha()
        End If
    End Sub

    Private Sub cbMovimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles cbMovimiento.SelectedIndexChanged
        If semaforo Then
            Call CargarMovimientosFecha()
        End If
    End Sub

    Private Sub cbMovimientoF_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMovimientoF.TextChanged, cbPRoveedor.TextChanged
        If semaforo Then
            Call CargarMovimientosFecha()
        End If
    End Sub

    Private Sub cbMovimientoA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMovimientoA.TextChanged, cbProveedorA.TextChanged
        If semaforo Then
            Call CargarMovimientosArticulo()
            If iidArticulo > 0 Then
                If cbMovimientoA.Text = "RECEPCIÓN" Then
                    lbPrecio.Text = "COSTE"
                    lbMonedaC.Text = dtsAR.gSimboloC
                    PrecioUnitario.Text = dtsAR.gPrecioUnitarioC
                Else
                    lbPrecio.Text = "PVP"
                    lbMonedaC.Text = dtsAR.gSimboloV
                    PrecioUnitario.Text = dtsAR.gPrecioUnitarioV
                End If
            End If
        End If
    End Sub

    Private Sub lvMovimientosA_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovimientosArticulo.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If DireccionA = "DESC" Then ' Revertir la dirección de ordenación actual de esta columna. 
            If DireccionA = "ASC" Then
                DireccionA = "DESC"
            Else
                DireccionA = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 

            Select Case e.Column
                Case 0
                    OrdenA = "idStock"
                Case 1
                    OrdenA = "Fecha"
                Case 2
                    OrdenA = "Cantidad"
                Case 3
                    OrdenA = "Movimiento"
                Case 4
                    OrdenA = "numPedidoProv"
                Case 5
                    OrdenA = "numAlbaran"
                Case 6
                    OrdenA = "numPedido"
            End Select

        End If
        Call CargarMovimientosArticulo()
    End Sub

    Private Sub lvMovimientosF_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMovimientosFecha.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If DireccionF = "DESC" Then ' Revertir la dirección de ordenación actual de esta columna. 
            If DireccionF = "ASC" Then
                DireccionF = "DESC"
            Else
                DireccionF = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 

            Select Case e.Column
                Case 0
                    OrdenF = "idStock"
                Case 1
                    OrdenF = "codArticulo"
                Case 2
                    OrdenF = "Articulo"
                Case 3
                    OrdenF = "Fecha"
                Case 4
                    OrdenF = "Cantidad"
                Case 5
                    OrdenF = "Movimiento"
                Case 6
                    OrdenF = "numPedidoProv"
                Case 6
                    OrdenF = "numAlbaran"
                Case Else
                    OrdenF = "numPedido"
            End Select
        End If
        Call CargarMovimientosFecha()
        ' Realizar la ordenación con estas nuevas opciones de ordenación. 

    End Sub

    Private Sub bLimpiarBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiarBusqueda.Click
        Call LimpiarBusqueda()
        iidArticulo = 0
        Call CargarMovimientosArticulo()
    End Sub

    Private Sub bLimpiarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiarTodo.Click
        If rbArticulo.Checked Then
            Call LimpiarBusqueda()
            iidArticulo = 0
            Call limpiaEdicion()
            Call CargarMovimientosArticulo()
        Else
            Call limpiaEdicion()
            Call CargarMovimientosFecha()
        End If
    End Sub

#End Region









    Private Sub rbMovimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMovimiento.CheckedChanged
        'If semaforo Then
        '    If rbRegularizacion.Checked Then
        '        Movimiento.Text = "REGULARIZACIÓN"

        '    Else
        '        Movimiento.Text = ""
        '    End If
        'End If
    End Sub


   
   

   



End Class