Public Class busquedaAlbaranesDeProv

#Region "VARIABLES"

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private snumAlbaran As String
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesAlbaranesProv
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
    Private Albaranes As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private semaforo As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean
    Dim iidProveedor As Integer

#End Region
   
#Region "PROPIEDADES"

    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Property pnumAlbaran() As String
        Get
            Return snumAlbaran
        End Get
        Set(ByVal value As String)
            snumAlbaran = value

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

    Private Sub busquedaAlbaranesProv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        colorInactivo = Color.Gray
        colorCabecera = Color.Red

        'PERMISOS 
        Dim iidUsuario As Integer = Inicio.vIdUsuario
        Dim funcPE As New FuncionesPersonal
        'VerClientesPropios = VerClientesPropios Or funcPE.Parametro(iidUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")

        BuscarAhora = False
        'AddHandler retardo.Tick, AddressOf BusquedaRetardada
        'retardo.Interval = 500 'en milisegundos
        'retardo.Enabled = False

        Call limpiar()
        direccion = "ASC"
        Albaranes = New List(Of Integer)
        semaforo = False
        Call IntroducirArticulosC()
        Call introducirProveedores()
        Call IntroducirAños()
        Call introducirEstados()
        If iidProveedor <> 0 Then cbProveedor.Text = funcPR.campoProveedor(iidProveedor)
        semaforo = True

    End Sub

#End Region

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        sBusqueda = ""
        Contador.Text = ""
        Total.Text = ""
        lvDocumentos.Items.Clear()
        numDoc.Text = ""
        cbProveedor.Text = ""
        cbProveedor.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = "1-1-" & Now.Date.Year
        dtpHasta.Value = Now.Date
        cbAño.Text = Now.Year
        cambioFechas = False
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
            cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
        Next
    End Sub

    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("ALBARANPROV")
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

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub busqueda()

        lbBuscando.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        sBusqueda = " DOC.idProveedor > 0 " 'Para que no presente albaranes de cliente

        If numDoc.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numAlbaran like '" & numDoc.Text & "%' "
        End If

        If Referencia.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.Referencia like '%" & Referencia.Text & "%' "
        End If

        If numPedido.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " idAlbaran in (Select idAlbaran from ConceptosPedidosProv where numPedido like '" & numPedido.Text & "' )"
        End If

        If cbProveedor.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PR.NombreComercial like '%" & cbProveedor.Text & "%' "
        End If

        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idAlbaran in (select idAlbaran from ConceptosAlbaranesProv AS CP left join Articulos ON Articulos.idArticulo = CP.idArticulo where codArticulo = '" & cbCodArticulo.Text & "') "
        ElseIf cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idAlbaran in (select idAlbaran from ConceptosAlbaranesProv AS CP  where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
        End If

        If cbEstado.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.idEstado = " & cbEstado.SelectedItem.gidEstado
        End If

        If cambioFechas Then
        Else
            If cbAño.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " year(DOC.Fecha) = " & cbAño.Text
            End If
        End If

        If cambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), DOC.fecha,103))  <= '" & dtpHasta.Value.Date & "' "
        End If

        Call ActualizarLV()

        lbBuscando.Visible = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Albaranes.Clear()
            Dim Suma As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosAlbaranProv) = funcOF.Busqueda(sBusqueda, Orden)
            For Each dts As DatosAlbaranProv In lista
                Albaranes.Add(dts.gidAlbaran)
                With lvDocumentos.Items.Add(dts.gidAlbaran)
                    .SubItems.Add(dts.gnumAlbaran)
                    .SubItems.Add(dts.gProveedor)
                    .SubItems.Add(dts.gFecha)
                    .SubItems.Add(dts.gEstado)
                    .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
                    If funcES.Cabecera(dts.gidEstado) Then
                        .ForeColor = colorCabecera
                    Else
                        .ForeColor = Color.Black
                    End If
                    If funcES.Bloqueado(dts.gidEstado) Then
                        .ForeColor = colorInactivo
                    Else
                        .ForeColor = Color.Black
                    End If
                    If dts.gcodMoneda = "EU" Then
                        Suma = Suma + dts.gBase
                    Else
                        Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                        AvisoG = AvisoG Or Aviso
                        If Aviso Then FechaCambioG = FechaCambio
                    End If
                End With
            Next
            Contador.Text = lvDocumentos.Items.Count
            Total.Text = FormatNumber(Suma, 2)
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarLineaLV()
        If indice <> -1 Then
            Dim iidAlbaran = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosAlbaranProv = funcOF.Mostrar1(iidAlbaran)
            With lvDocumentos.Items(indice)
                .SubItems(2).Text = dtsOF.gProveedor
                .SubItems(3).Text = dtsOF.gFecha
                .SubItems(4).Text = dtsOF.gEstado
                .SubItems(5).Text = FormatNumber(dtsOF.gBase, 2) & dtsOF.gSimbolo
                If funcES.Cabecera(dtsOF.gidEstado) Then
                    .ForeColor = colorCabecera
                Else
                    .ForeColor = Color.Black
                End If
                If funcES.Bloqueado(dtsOF.gidEstado) Then
                    .ForeColor = colorInactivo
                Else
                    .ForeColor = Color.Black
                End If
            End With
        End If

    End Sub

    Private Sub RecalcularTotalizadores()
        Dim Suma As Double = 0
        For Each item In lvDocumentos.Items

            Suma = Suma + item.SubItems(5).Text

        Next
        'Dim Aviso As Boolean = False
        'Dim AvisoG As Boolean = False
        'Dim FechaCambioG As Date = Now.Date
        'Dim FechaCambio As Date = Now.Date
        'Dim lista As List(Of DatosAlbaranProv) = funcOF.Busqueda(sBusqueda, Orden)
        'For Each dts As DatosAlbaranProv In lista
        '    If dts.gcodMoneda = "EU" Then
        '        Suma = Suma + dts.gBase
        '    Else
        '        Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
        '        AvisoG = AvisoG Or Aviso
        '        If Aviso Then FechaCambioG = FechaCambio
        '    End If
        'Next
        Contador.Text = lvDocumentos.Items.Count
        Total.Text = FormatNumber(Suma, 2)
    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click
        busqueda()
    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionAlbaranDeProv
        GG.SoloLectura = vsoloLectura
        GG.pidAlbaran = 0

        GG.ShowDialog()
        'If GG.pidAlbaran > 0 Then
        '    Call busqueda()
        'End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        If sBusqueda <> "" Then
            Dim GG As New InformeListadoAlbaranes
            GG.verInforme(sBusqueda, Orden, Total.Text)
            GG.ShowDialog()
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numDoc.KeyDown, _
    cbProveedor.KeyDown, Referencia.KeyDown, numPedido.KeyDown, cbEstado.KeyDown, cbAño.KeyDown, cbArticulo.KeyDown, cbCodArticulo.KeyDown, _
    dtpDesde.KeyDown, dtpHasta.KeyDown

        If e.KeyCode = Keys.Enter Then

            busqueda()

        End If

    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then

            indice = lvDocumentos.SelectedIndices(0)

            If modo = "B" Then
                snumAlbaran = lvDocumentos.Items(indice).SubItems(1).Text
                Me.Close()
            Else
                Dim GP As New GestionAlbaranDeProv
                'Dim dts As DatosAlbaranProv = funcOF.Mostrar1(lvDocumentos.SelectedItems(0).Text)
                'GP.pdts = dts
                GP.pAlbaranes = Albaranes
                GP.pindice = indice
                GP.pidAlbaran = lvDocumentos.Items(indice).Text
                GP.ShowDialog()
                'If GP.DialogResult = Windows.Forms.DialogResult.OK Then
                'funcOF.actualizar(dts)
                'End If
                Call ActualizarLineaLV()
                Call RecalcularTotalizadores()
            End If

        End If
    End Sub

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectionChangeCommitted
        If semaforo And cbCodArticulo.SelectedIndex <> -1 Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.SelectedItem.itemdata)
            semaforo = True
        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If semaforo And cbArticulo.SelectedIndex <> -1 Then
            semaforo = False
            cbCodArticulo.Text = funcAR.codArticulo(cbArticulo.SelectedItem.itemdata)
            semaforo = True
        End If
    End Sub

    Private Sub cbCodArticulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCodArticulo.TextChanged
        If semaforo Then
            semaforo = False
            cbArticulo.Text = funcAR.Articulo(cbCodArticulo.Text)
            semaforo = True
        End If
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
                    Orden = "DOC.numAlbaran"
                Case 2
                    Orden = "Proveedor"
                Case 3
                    Orden = "DOC.Fecha"
                Case 4
                    Orden = "Estado"
                Case 5
                    Orden = "Base"

            End Select
            columna = e.Column
            If Orden <> "" Then
                Orden = Orden & " " & direccion
            End If
            Call ActualizarLV()
        End If
        

    End Sub

#Region "CAMBIAR DE FECHA"

    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            cambioFechas = True
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

#End Region

#End Region

End Class


'Private Sub cbEstado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.TextChanged
'    If semaforo And cbEstado.Text = "" Then Call busqueda()
'End Sub

'Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
'    If BuscarAhora Then
'        BuscarAhora = False
'        retardo.Enabled = False
'        Call busqueda()
'    End If
'End Sub

'Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
'    Me.Width = 730
'    Me.Height = If(Me.Height < 300, 300, Me.Height)
'End Sub

'Private Sub numAlbaran_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
'    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'    KeyAscii = CShort(SoloNumeros(KeyAscii))
'    If KeyAscii = 0 Then
'        e.Handled = True
'    End If
'    If KeyAscii = 13 Then
'        Call busqueda()
'    End If
'End Sub

'Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbProveedor.TextChanged, Referencia.TextChanged, numPedido.TextChanged
'    If semaforo Then
'        BuscarAhora = True
'        retardo.Enabled = True
'    End If

'End Sub
'Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEstado.SelectedIndexChanged, cbAño.SelectedIndexChanged
'    If semaforo Then Call busqueda()
'End Sub