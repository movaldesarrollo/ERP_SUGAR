Public Class busquedaFacturasProv

#Region "VARIABLES"

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private iidFactura As Integer
    Private snumFactura As String
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesFacturasProv
    Private funcPE As New FuncionesPersonal
    Private funcPR As New funcionesProveedores
    Private funcAR As New FuncionesArticulos
    Private funcES As New FuncionesEstados
    Private funcMO As New FuncionesMoneda
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private colorInactivo As Color
    Private colorCabecera As Color
    Private direccion As String
    Private sBusqueda As String
    Private columna As Integer
    Private Facturas As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean
    Private sumaRE As Double = 0
    Private sumaRetencion As Double = 0
    Private iidProveedor As Integer

#End Region

#Region "PROPIEDADES"

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

    Property pidFactura() As Integer
        Get
            Return iidFactura
        End Get
        Set(ByVal value As Integer)
            iidFactura = value

        End Set
    End Property

    Property pnumFactura() As String
        Get
            Return snumFactura
        End Get
        Set(ByVal value As String)
            snumFactura = value

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

    Public Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property

#End Region
   
#Region "CARGA Y CIERRE"

    Private Sub busquedaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dimensionar form
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        colorInactivo = Color.Gray
        colorCabecera = Color.Black

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        'VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")

        Call limpiar()
        direccion = "ASC"
        Facturas = New List(Of Integer)
        Call IntroducirArticulosC()
        Call introducirProveedores()
        Call introducirEstados()
        If iidProveedor > 0 Then cbProveedor.Text = funcPR.campoProveedor(iidProveedor)
        Call IntroducirAños()
        Call IntroducirTrimestres()

        'busqueda()

    End Sub

#End Region

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        lvDocumentos.Items.Clear()
        Contador.Text = ""
        Total.Text = ""
        IVA.Text = ""
        Base.Text = ""
        numDoc.Text = ""
        numPedido.Text = ""
        Referencia.Text = ""
        numAlbaran.Text = ""
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        cbArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = "1-1-" & Now.Date.Year
        dtpHasta.Value = Now.Date
        cambioFechas = False
        cbAño.Text = Now.Year
        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1
        Orden = ""
        direccion = "ASC"
        semaforo = True
    End Sub

    Private Sub IntroducirArticulosC()
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

    Private Sub introducirProveedores()
        cbProveedor.Items.Clear()
        Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
        For Each dts As datosProveedor In lista
            cbProveedor.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidProveedor))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("FACTURAPROV")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub

    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = funcOF.buscaPrimerDia().Year To Now.Year
            cbAño.Items.Add(Año)
        Next
        cbAño.Text = Now.Year
    End Sub

    Private Sub IntroducirTrimestres()
        cbTrimestre.Items.Clear()
        cbTrimestre.Items.Add("TRIMESTRE 1")
        cbTrimestre.Items.Add("TRIMESTRE 2")
        cbTrimestre.Items.Add("TRIMESTRE 3")
        cbTrimestre.Items.Add("TRIMESTRE 4")
        cbTrimestre.SelectedIndex = -1
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub busqueda()

        lbBuscando.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        sBusqueda = ""

        If numDoc.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numFactura like '" & numDoc.Text & "%' "
        End If

        If cbProveedor.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PR.NombreFiscal like '%" & cbProveedor.Text & "%' "
        End If

        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in (select idFactura from ConceptosFacturasProv AS CP left join Articulos ON Articulos.idArticulo = CP.idArticulo where codArticulo = '" & cbCodArticulo.Text & "') "
        ElseIf cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in (select idFactura from ConceptosFacturasProv AS CP  where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
        End If

        If Referencia.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & "DOC.Referencia like '%" & Referencia.Text & "%' "
        End If

        If numAlbaran.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in (select idFactura from AlbaranesProv where numAlbaran like '" & numAlbaran.Text & "%') "
        End If

        If numPedido.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idFactura in (select idFactura from AlbaranesProv as AP left join ConceptosAlbaranesProv AS CA ON CA.idAlbaran = AP.idAlbaran "
            sBusqueda = sBusqueda & " left join  ConceptosPedidosProv as CP ON  CP.idConcepto = CA.idConceptoPedidoPRov where CP.numPedido like '" & numPedido.Text & "%') "
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If

        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpHasta.Value.Date & "' "
        Else
            If cbAño.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " year(DOC.Fecha) = " & cbAño.Text
            End If

            If cbTrimestre.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & "  Month(DOC.Fecha)in "
                Select Case cbTrimestre.SelectedIndex
                    Case 0 '1T
                        sBusqueda = sBusqueda & " (1,2,3) "
                    Case 1 '2T
                        sBusqueda = sBusqueda & " (4,5,6) "
                    Case 2 '3T
                        sBusqueda = sBusqueda & " (7,8,9) "
                    Case 3 '4T
                        sBusqueda = sBusqueda & " (10,11,12) "
                End Select
            End If
        End If

        Call ActualizarLV()

        lbBuscando.Visible = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Facturas.Clear()
            Dim Suma As Double = 0
            Dim SumaIVA As Double = 0
            Dim SumaBase As Double = 0
            sumaRE = 0
            sumaRetencion = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambio As Date = Now.Date
            Dim FechaCambioG As Date = Now.Date
            Dim lista As List(Of DatosFacturaProv) = funcOF.Busqueda(sBusqueda, Orden)
            For Each dts As DatosFacturaProv In lista
                Facturas.Add(dts.gidFactura)
                With lvDocumentos.Items.Add(dts.gidFactura)
                    .SubItems.Add(dts.gnumFactura)
                    .SubItems.Add(dts.gProveedor)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)

                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    ElseIf funcES.EnCurso(dts.gidEstado) Then 'PARCIAL
                        .ForeColor = Color.Orange
                    ElseIf funcES.Espera(dts.gidEstado) Or funcES.Automatico(dts.gidEstado) Then
                        .ForeColor = Color.Red
                    Else
                        .ForeColor = Color.Black
                    End If

                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gTotal
                        SumaIVA = SumaIVA + dts.gTotalIVA
                        sumaRE = sumaRE + If(dts.gRecargoEquivalencia, dts.gTotalRE, 0)
                        sumaRetencion = sumaRetencion + dts.gRetencion
                        SumaBase = SumaBase + dts.gBase

                    Else
                        Suma = Suma + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        sumaRE = sumaRE + If(dts.gRecargoEquivalencia, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio), 0)
                        sumaRetencion = sumaRetencion + funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaBase = SumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                End With
            Next
            Contador.Text = lvDocumentos.Items.Count
            Base.Text = FormatNumber(SumaBase, 2)
            IVA.Text = FormatNumber(SumaIVA, 2)
            Total.Text = FormatNumber(Suma, 2)
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            iidFactura = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosFacturaProv = funcOF.Mostrar1(iidFactura)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dtsOF.gnumFactura
                .SubItems(2).Text = dtsOF.gProveedor
                .SubItems(3).Text = dtsOF.gFecha
                .SubItems(4).Text = dtsOF.gEstado
                .SubItems(5).Text = FormatNumber(dtsOF.gTotal, 2) & dtsOF.gSimbolo
                .SubItems(6).Text = FormatNumber(dtsOF.gTotalIVA, 2) & dtsOF.gSimbolo
                .SubItems(7).Text = FormatNumber(dtsOF.gBase, 2) & dtsOF.gSimbolo
                If funcES.Cabecera(dtsOF.gidEstado) Then
                    .ForeColor = colorCabecera
                ElseIf funcES.EnCurso(dtsOF.gidEstado) Then 'PARCIAL
                    .ForeColor = Color.Orange
                ElseIf funcES.Espera(dtsOF.gidEstado) Or funcES.Automatico(dtsOF.gidEstado) Then
                    .ForeColor = Color.Red
                Else
                    .ForeColor = Color.Black
                End If
            End With
        End If

    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionFacturaProv
        GG.SoloLectura = vsoloLectura
        GG.pidFactura = 0
        GG.ShowDialog()
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        If lvDocumentos.Items.Count > 0 Then
            Dim dts As DatosFacturaProv
            For Each idFacturaLista In Facturas 'Esta rutina recalcula los totales que se almacenan en la tabla de FacturasProv para evitar discrepancias con los conceptos
                dts = New DatosFacturaProv
                dts.gidFactura = idFacturaLista
                funcOF.DatosCalculados(dts)
                funcOF.actualizarTotales(dts)
            Next
            Dim GG As New InformeListadoFacturasProv
            GG.verInforme(sBusqueda, Orden, Total.Text, Base.Text, IVA.Text, sumaRE, sumaRetencion)
            GG.ShowDialog()
        End If
    End Sub

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        busqueda()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numPedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numPedido.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)

            If modo = "B" Then
                iidFactura = lvDocumentos.Items(indice).Text
                snumFactura = lvDocumentos.Items(indice).SubItems(1).Text
                Me.Close()
            Else
                Dim GP As New GestionFacturaProv
                GP.pidFactura = lvDocumentos.SelectedItems(0).Text
                GP.pFacturas = Facturas
                GP.SoloLectura = vsoloLectura
                GP.pIndice = indice
                GP.ShowDialog()
                Call ActualizarLineaLV()
            End If
        End If
    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        cbArticulo.Text = funcAR.Articulo(cbCodArticulo.SelectedItem.itemdata)
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        cbCodArticulo.Text = funcAR.codArticulo(cbArticulo.SelectedItem.itemdata)
    End Sub

    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged
        cbArticulo.Text = funcAR.Articulo(cbCodArticulo.Text)
    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick
        If lvDocumentos.Items.Count > 0 Then
            ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
            If e.Column = columna Then
                If direccion = "ASC" Then
                    direccion = "DESC"
                Else
                    direccion = "ASC"
                End If
            End If ' Establecer el número de columna que se va a ordenar; 

            Select Case e.Column
                Case 0, 1
                    Orden = "DOC.numFactura"
                Case 2
                    Orden = "Proveedor"
                Case 3
                    Orden = "DOC.Fecha"
                Case 4
                    Orden = "Estados.Estado"
                Case 5
                    Orden = "Total " '*(1+(DOC.TipoIVA/100))"
                Case 6
                    Orden = "TotalIVA " '* (DOC.TipoIVA/100)"
                Case 7
                    Orden = "Base "

            End Select

            columna = e.Column
            If Orden <> "" Then
                Orden = Orden & " " & direccion
            End If
            Call ActualizarLV()
        End If
    End Sub

    Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
        cambioFechas = True
    End Sub

    Private Sub cbCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.TextChanged
        If cbEstado.Text = "" Then Call busqueda()
    End Sub

    Private Sub cbAño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbAño.KeyDown, cbArticulo.KeyDown, _
    cbCodArticulo.KeyDown, cbEstado.KeyDown, cbProveedor.KeyDown, cbTrimestre.KeyDown, dtpDesde.KeyDown, dtpHasta.KeyDown, numAlbaran.KeyDown, _
    numDoc.KeyDown, numPedido.KeyDown, Referencia.KeyDown

        If e.KeyCode = Keys.Enter Then

            busqueda()

        End If

    End Sub

#End Region

End Class


'Call RecalcularTotalizadores()

'Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
'    If BuscarAhora Then
'        BuscarAhora = False
'        retardo.Enabled = False
'        Call busqueda()
'    End If
'End Sub

'Private Sub RecalcularTotalizadores()
'    Dim Suma As Double = 0
'    Dim SumaIVA As Double = 0
'    Dim SumaBase As Double = 0
'    Dim Aviso As Boolean = False
'    Dim AvisoG As Boolean = False
'    Dim FechaCambio As Date = Now.Date
'    Dim FechaCambioG As Date = Now.Date
'    Dim lista As List(Of DatosFacturaProv) = funcOF.Busqueda(sBusqueda, Orden)
'    For Each dts As DatosFacturaProv In lista
'        Facturas.Add(dts.gidFactura)
'        If dts.gcodMoneda = "EU" Then
'            Suma = Suma + dts.gTotal
'            SumaIVA = SumaIVA + dts.gTotalIVA
'            SumaBase = SumaBase + dts.gBase
'        Else
'            Suma = Suma + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
'            SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
'            SumaBase = SumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
'            AvisoG = AvisoG Or Aviso
'            If Aviso Then FechaCambioG = FechaCambio
'        End If
'    Next
'    Contador.Text = lvDocumentos.Items.Count
'    Base.Text = FormatNumber(SumaBase, 2)
'    IVA.Text = FormatNumber(SumaIVA, 2)
'    Total.Text = FormatNumber(Suma, 2)
'    lbCambio.Text = "CAMBIO " & FechaCambioG
'    lbCambio.Visible = AvisoG
'End Sub


'Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbProveedor.TextChanged, Referencia.TextChanged, numPedido.TextChanged, numAlbaran.TextChanged
'    If semaforo Then
'        BuscarAhora = True
'        retardo.Enabled = True
'    End If

'End Sub



'Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged, cbAño.SelectedIndexChanged, cbTrimestre.SelectedIndexChanged
'    If semaforo Then Call busqueda()
'End Sub


'Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
'    Me.Width = 833
'    Me.Height = If(Me.Height < 300, 300, Me.Height)
'End Sub