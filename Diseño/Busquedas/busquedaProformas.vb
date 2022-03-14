Public Class busquedaProformas

    Private desktopSize As Size
    Private vcodCli As String
    Private f As Integer
    Private inumProforma As Integer
    Private vsoloLectura As Boolean
    Private funcOF As New FuncionesProformas
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
    Private Proformas As List(Of Integer)
    Private indice As Integer
    Private modo As String
    Private cambioFechas As Boolean
    Private semaforo As Boolean
    Private VerClientesPropios As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean
    Private iidCliente As Integer

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

    Property pnumProforma() As Integer
        Get
            Return inumProforma
        End Get
        Set(ByVal value As Integer)
            inumProforma = value

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

        BuscarAhora = False
        AddHandler retardo.Tick, AddressOf BusquedaRetardada
        retardo.Interval = 500 'en milisegundos
        retardo.Enabled = False

        Call limpiar()
        direccion = "ASC"
        Proformas = New List(Of Integer)
        semaforo = False
        Call IntroducirResponsables()
        Call IntroducirArticulosC()
        Call introducirClientes()
        Call introducirEstados()
        Call IntroducirAños()
        If iidCliente > 0 Then cbCliente.Text = funcCL.campoCliente(iidCliente)
        Call busqueda()
        semaforo = True
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
        cbEstado.Text = ""
        cbEstado.SelectedIndex = -1
        dtpDesde.Value = "1-1-" & Now.Date.Year
        dtpHasta.Value = Now.Date
        cambioFechas = False
        cbAño.Text = Now.Year
        Orden = ""
        direccion = "ASC"
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



    Private Sub introducirEstados()
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Proforma")
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
            sBusqueda = sBusqueda & " DOC.numProforma like '" & numDoc.Text & "%' "
        End If

        If cbCliente.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CLientes.NombreComercial like '%" & cbCliente.Text & "%' "
        End If

        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numProforma in (select numProforma from ConceptosProformas left join Articulos ON Articulos.idArticulo = ConceptosProformas.idArticulo where codArticulo = '" & cbCodArticulo.Text & "') "
        ElseIf cbArticulo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " DOC.numProforma in (select numProforma from ConceptosProformas where idArticulo = " & cbArticulo.SelectedItem.itemdata & ") "
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
        End If

        If cbAño.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " year(DOC.Fecha) = " & cbAño.Text
        End If

        Call ActualizarLV()

    End Sub


    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Proformas.Clear()
            Dim Suma As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim lista As List(Of DatosProforma) = funcOF.Busqueda(sBusqueda, Orden, True)
            For Each dts As DatosProforma In lista
                Proformas.Add(dts.gnumProforma)
                With lvDocumentos.Items.Add(dts.gnumProforma)
                    .SubItems.Add(dts.gCliente)
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
            inumProforma = lvDocumentos.Items(indice).Text
            Dim dtsOF As DatosProforma = funcOF.Mostrar1(inumProforma)
            With lvDocumentos.Items(indice)
                .SubItems(1).Text = dtsOF.gCliente
                .SubItems(2).Text = dtsOF.gFecha
                .SubItems(3).Text = dtsOF.gEstado
                .SubItems(4).Text = FormatNumber(dtsOF.gBase, 2) & dtsOF.gSimbolo
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
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambioG As Date = Now.Date
        Dim FechaCambio As Date = Now.Date
        Dim lista As List(Of DatosProforma) = funcOF.Busqueda(sBusqueda, Orden, True)
        For Each dts As DatosProforma In lista
            If dts.gcodMoneda = "EU" Then
                Suma = Suma + dts.gBase
            Else
                Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
            End If
        Next
        Contador.Text = lvDocumentos.Items.Count
        Total.Text = FormatNumber(Suma, 2)
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
        Dim GG As New GestionProforma
        GG.SoloLectura = vsoloLectura
        GG.pnumProforma = 0
        GG.ShowDialog()
        If GG.pnumProforma > 0 Then
            Call busqueda()
        End If
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        Dim GG As New InformeListadoProformas
        GG.verInforme(sBusqueda, Orden, Total.Text)
        GG.ShowDialog()

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub numProforma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If lvDocumentos.SelectedItems.Count > 0 Then

            indice = lvDocumentos.SelectedIndices(0)

            If modo = "B" Then
                inumProforma = lvDocumentos.Items(indice).Text
                Me.Close()
            Else
                Dim GP As New GestionProforma
                GP.pnumProforma = lvDocumentos.SelectedItems(0).Text

                GP.pProformas = Proformas
                GP.SoloLectura = vsoloLectura
                GP.pIndice = indice
                GP.ShowDialog()
                Call ActualizarLineaLV()
                Call RecalcularTotalizadores()

            End If
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 684
        Me.Height = If(Me.Height < 300, 300, Me.Height)

    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbResponsable.SelectedIndexChanged, cbCliente.SelectedIndexChanged, cbEstado.SelectedIndexChanged, cbAño.SelectedIndexChanged
        If semaforo Then Call busqueda()
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
                Orden = "DOC.numProforma"
            Case 1
                Orden = "Cliente"
            Case 2
                Orden = "DOC.Fecha"
            Case 3
                Orden = "Estado"
            Case 4
                Orden = "Base"

        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub cbEstado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEstado.TextChanged
        If semaforo And cbEstado.Text = "" Then Call busqueda()
    End Sub

    Private Sub cbResponsable_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbResponsable.TextChanged
        If semaforo And cbResponsable.Text = "" Then Call busqueda()
    End Sub

    Private Sub BusquedasRetardadas(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numDoc.TextChanged, cbCliente.TextChanged
        If semaforo Then
            BuscarAhora = True
            retardo.Enabled = True
        End If
    End Sub

#Region "CAMBIAR FECHAS"
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