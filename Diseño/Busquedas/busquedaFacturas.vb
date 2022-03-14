Public Class busquedaFacturas

#Region "VARIABLES"

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private inumFactura As Integer
    Private vsoloLectura As Boolean
    Private funcFA As New FuncionesFacturas
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
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
    Private VerClientesPropios As Boolean
    Dim BuscarAhora As Boolean
    Dim SumaRE As Double = 0
    Dim SumaRetencion As Double = 0
    Private iidCliente As Integer
    Public Vvercostes As Boolean

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

    Property pnumFactura() As Integer
        Get
            Return inumFactura
        End Get
        Set(ByVal value As Integer)
            inumFactura = value

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


#End Region

#Region "CARGA Y CIERRE"

    Private Sub busquedaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dimensiona el formulario
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        'Asigna colores a las variables
        colorInactivo = Color.Gray
        colorCabecera = Color.Black

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        Vvercostes = funcPE.vercostes(iidUsuario)
        BuscarAhora = False

    End Sub

    Private Sub busquedaFacturas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Call limpiar()
        direccion = "ASC"
        Facturas = New List(Of Integer)
        Call IntroducirResponsables()
        Call IntroducirArticulosC()
        Call introducirClientes()
        Call IntroducirAños()
        Call IntroducirTrimestres()
        Call introducirEstados()
        If iidCliente > 0 Then cbCliente.Text = funcCL.campoCliente(iidCliente)
        'busqueda()

    End Sub

#End Region

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        lvDocumentos.Items.Clear()
        Contador.Text = ""
        Total.Text = ""
        Base.Text = ""
        IVA.Text = ""
        numDoc.Text = ""
        numAlbaran.Text = ""
        RefCliente.Text = ""
        cbResponsable.Text = ""
        cbResponsable.SelectedIndex = -1
        cbCliente.Text = ""
        cbCliente.SelectedIndex = -1
        cbArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        numPedido.Text = ""
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
            cbCliente.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidCliente))
        Next
    End Sub

    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = funcFA.buscaPrimerDia(0).Year To Now.Year
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

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Factura")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub busqueda()

        lbBuscando.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        'instrucciones para búsqueda de Cliente
        sBusqueda = ""

        If numDoc.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numFactura like '" & numDoc.Text & "%' "
        End If

        If numAlbaran.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numFactura in (select distinct numFactura from ConceptosAlbaranes where numAlbaran like '" & numAlbaran.Text & "%' )"
        End If

        If numPedido.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numFactura in (select distinct numFactura from ConceptosAlbaranes left Join ConceptosPedidos  ON ConceptosPedidos.idConcepto = ConceptosAlbaranes.idConceptoPedido where numPedido like '" & numPedido.Text & "%' )"
        End If
        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CLientes.NombreFiscal like '%" & cbCliente.Text & "%' "
        End If

        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numFactura in (select distinct numFactura from ConceptosFacturas left join Articulos ON Articulos.idArticulo = ConceptosFacturas.idArticulo where codArticulo = '" & cbCodArticulo.Text & "') "
        ElseIf cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numFactura in (select distinct numFactura from ConceptosFacturas where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
        End If

        If cbResponsable.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Clientes.idResponsableCuenta = " & cbResponsable.SelectedItem.itemdata
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If
        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpHasta.Value.Date & "' "
            cambioFechas = False
        Else
            If cbAño.SelectedIndex <> -1 And numDoc.Text = "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " year(DOC.Fecha) = " & cbAño.Text
            End If

            If cbTrimestre.SelectedIndex <> -1 And numDoc.Text = "" Then
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

        If RefCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.ReferenciaCliente like '%" & Replace(RefCliente.Text, "'", "''") & "%' "
        End If

        If sBusqueda = "" Then

            sBusqueda = 0

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
            SumaRE = 0
            SumaRetencion = 0

            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambio As Date = Now.Date
            Dim FechaCambioG As Date = Now.Date
            Dim lista As List(Of DatosFactura) = funcFA.Busqueda(sBusqueda, Orden, True, False)
            For Each dts As DatosFactura In lista
                Facturas.Add(dts.gnumFactura)
                With lvDocumentos.Items.Add(dts.gnumFactura)
                    .SubItems.Add(dts.gCliente)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)

                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    ElseIf funcES.EnCurso(dts.gidEstado) Then 'PARCIAL
                        .ForeColor = Color.DarkOrange
                    ElseIf funcES.Espera(dts.gidEstado) Or funcES.Automatico(dts.gidEstado) Then
                        .ForeColor = Color.Red
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gTotal
                        SumaIVA = SumaIVA + dts.gTotalIVA
                        SumaRE = SumaRE + If(dts.gRecargoEquivalencia, dts.gTotalRE, 0)
                        SumaRetencion = SumaRetencion + dts.gRetencion
                        SumaBase = SumaBase + dts.gBase
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaBase = SumaBase + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        SumaRE = SumaRE + If(dts.gRecargoEquivalencia, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio), 0)
                        SumaRetencion = SumaRetencion + funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio)
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
            inumFactura = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosFactura = funcFA.Mostrar1(inumFactura)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dtsOF.gCliente
                .SubItems(2).Text = dtsOF.gFecha
                .SubItems(3).Text = dtsOF.gEstado
                .SubItems(4).Text = FormatNumber(dtsOF.gTotal, 2) & dtsOF.gSimbolo
                .SubItems(5).Text = FormatNumber(dtsOF.gTotalIVA, 2) & dtsOF.gSimbolo
                .SubItems(6).Text = FormatNumber(dtsOF.gBase, 2) & dtsOF.gSimbolo
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
        Dim GG As New GestionFactura1
        GG.SoloLectura = vsoloLectura
        GG.pnumFactura = 0
        GG.ShowDialog()
        'If GG.pnumFactura > 0 Then
        '    Call busqueda()
        'End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click

        If lvDocumentos.Items.Count > 0 Then

            Dim GG As New InformeListadoFacturas
            'GG.verInforme(sBusqueda, Orden, Total.Text, Base.Text, IVA.Text, SumaRE, SumaRetencion)
            GG.verInforme()
            GG.pBusqueda = sBusqueda
            GG.pOrden = Orden
            If Vvercostes = True Then
                GG.pTotalEU = Total.Text
                GG.pBaseEU = Base.Text
                GG.pIVAEU = IVA.Text
                GG.pReEU = SumaRE
                GG.pRetencionEU = SumaRetencion
            Else
                GG.pTotalEU = "0"
                GG.pBaseEU = "0"
                GG.pIVAEU = "0"
                GG.pReEU = "0"
                GG.pRetencionEU = "0"
                GG.bTotales.Visible = False
                GG.bDetalle.Visible = False
            End If
            GG.ShowDialog()

        End If

    End Sub

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        busqueda()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDoc.KeyDown, cbAño.KeyDown, cbArticulo.KeyDown, _
        cbCliente.KeyDown, cbCodArticulo.KeyDown, cbEstado.KeyDown, cbResponsable.KeyDown, cbTrimestre.KeyDown, dtpDesde.KeyDown, dtpHasta.KeyDown, _
        RefCliente.KeyDown, numPedido.KeyDown, numAlbaran.KeyDown

        If e.KeyCode = Keys.Enter Then

            busqueda()

        End If

    End Sub

    Private Sub numFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numDoc.KeyPress, numAlbaran.KeyPress, numPedido.KeyPress
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
                inumFactura = lvDocumentos.Items(indice).Text
                Me.Close()
            Else
                Dim GP As New GestionFactura1
                GP.pnumFactura = lvDocumentos.SelectedItems(0).Text

                GP.pFacturas = Facturas
                GP.SoloLectura = vsoloLectura
                GP.pIndice = indice
                GP.ShowDialog()
                Call ActualizarLineaLV()
                'Call RecalcularTotalizadores()
            End If
        End If
    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        If cbCodArticulo.SelectedIndex <> -1 Then
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.SelectedItem.itemdata)
        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If cbArticulo.SelectedIndex <> -1 Then
            cbCodArticulo.Text = funcAR.codArticulo(cbArticulo.SelectedItem.itemdata)
        End If
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
                Case 0
                    Orden = "DOC.numFactura"
                Case 1
                    Orden = "Cliente"
                Case 2
                    Orden = "DOC.Fecha"
                Case 3
                    Orden = "Estado"
                Case 4
                    Orden = "Base " '*(1+(DOC.TipoIVA/100))"
                Case 5
                    Orden = "Base " '* (DOC.TipoIVA/100)"
                Case 6
                    Orden = "Base "

            End Select

            columna = e.Column
            If Orden <> "" Then
                Orden = Orden & " " & direccion
            End If
            Call ActualizarLV()
        End If
    End Sub

#Region "CAMBIAR FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
        cambioFechas = True
        BuscarAhora = True
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
        cambioFechas = True
        BuscarAhora = True

    End Sub
#End Region

#End Region

End Class


'Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
'    If BuscarAhora Then
'        BuscarAhora = False
'        retardo.Enabled = False
'        Call busqueda()
'    End If
'End Sub

'Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
'    Me.Width = 833
'    Me.Height = If(Me.Height < 300, 300, Me.Height)
'End Sub

'Private Sub cbEstado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.TextChanged
'    If semaforo And cbEstado.Text = "" Then Call busqueda()
'End Sub

'Private Sub cbResponsable_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbResponsable.TextChanged
'    If semaforo And cbResponsable.Text = "" Then Call busqueda()
'End Sub

'Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbResponsable.SelectedIndexChanged, cbEstado.SelectedIndexChanged
'    If semaforo Then Call busqueda()
'End Sub

'Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbCliente.TextChanged, numAlbaran.TextChanged, numPedido.TextChanged, RefCliente.TextChanged, cbAño.SelectedIndexChanged, cbTrimestre.SelectedIndexChanged
'    If semaforo Then
'        BuscarAhora = True
'        retardo.Enabled = True
'    End If
'End Sub

'Private Sub bBusquedaLibre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    Dim gg As New busquedalibreArticulos
'    gg.Show()
'End Sub

'Private Sub RecalcularTotalizadores()
'    Dim Suma As Double = 0
'    Dim SumaIVA As Double = 0
'    Dim SumaBase As Double = 0
'    SumaRE = 0
'    SumaRetencion = 0
'    Dim Aviso As Boolean = False
'    Dim AvisoG As Boolean = False
'    Dim FechaCambio As Date = Now.Date
'    Dim FechaCambioG As Date = Now.Date
'    Dim lista As List(Of DatosFactura) = funcFA.Busqueda(sBusqueda, Orden, False)
'    For Each dts As DatosFactura In lista
'        Facturas.Add(dts.gnumFactura)
'        If dts.gcodMoneda = "EU" Then
'            Suma = Suma + dts.gTotal
'            SumaIVA = SumaIVA + dts.gTotalIVA
'            SumaRE = SumaRE + If(dts.gRecargoEquivalencia, dts.gTotalRE, 0)
'            SumaBase = SumaBase + dts.gBase
'        Else
'            Suma = Suma + funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio)
'            SumaIVA = SumaIVA + funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio)
'            SumaRE = SumaRE + If(dts.gRecargoEquivalencia, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio), 0)
'            SumaRetencion = SumaRetencion + funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio)
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

'AddHandler retardo.Tick, AddressOf BusquedaRetardada
'retardo.Interval = 500 'en milisegundos
'retardo.Enabled = False