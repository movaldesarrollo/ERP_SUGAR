Public Class EstadisticasVentas1

#Region "VARIABLES"
    Private funcCF As New FuncionesConceptosFacturas
    Private funcSP As New FuncionessubTiposArticulo
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcMO As New FuncionesMoneda
    Private funcPA As New funcionesPaises
    Private funcFA As New FuncionesFacturas
    Private iidTipoArticulo As Integer
    Private CambioFechas As Boolean
    Private Orden As String
    Private Direccion As String
    Private Columna As Integer
    Private sBusqueda As String
    Private Semaforo As Boolean
    Private vSoloLectura As Boolean
    Private VerClientesPropios As Boolean
    Private PaisPorDefecto As datosPais
    Dim bloqueoSubTipos As Boolean
    Dim checkActivado As Boolean
    Public dtsP As New DatosRaices
    Public dtsS As New datosSecundarios
#End Region

#Region "PROPIEDADES"
    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property
#End Region

#Region "CARGA Y CIERRE"

    'Cargamos el formulario con los valores iniciales.
    Private Sub EstadisticasVentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Semaforo = False
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        Call Inicializar()
        Call Limpiar()
        Semaforo = False
        lvEstadisticas()
        Call introducirClientes()
        Call IntroducirAños()
        Call IntroducirTrimestres()
        Call IntroducirMeses()
        Call IntroducirResponsables()
        Call introducirEstados()
        Call IntroducirTiposArticulo()
        Call IntroducirArticulosC()
        Call introducirPaises()
        Call Busqueda()
        Semaforo = True
    End Sub

#End Region

#Region "INICIALIZACIÓN"
    'Validamos permisos.
    Private Sub Inicializar()
        'PERMISOS 
        VerClientesPropios = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        PaisPorDefecto = funcPA.mostrar1(1)
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    'Realiza la busqueda con los valores relativos a clientes.
    Private Sub Busqueda()
        'Si el combobox Año es igual a todos deja en blanco la variable.
        Dim vAño As String = cbAño.Text
        If vAño = "TODOS" Then
            vAño = ""
        Else
            vAño = cbAño.Text
        End If
        'Si el combobox Cliente es igual a todos deja en blanco la variable.
        Dim vClientes As String = cbCliente.Text
        If vClientes = "TODOS" Then
            vClientes = ""
        Else
            vClientes = cbCliente.Text
        End If

        'Vacia la variable busqueda.
        sBusqueda = ""

        'Si está vacio el campo busca todos los clientes.
        If vClientes <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CL.NombreComercial like '%" & Replace(vClientes, "'", "''") & "%' "
        End If

        If cbComercial.SelectedIndex <> -1 And cbComercial.Text <> "TODOS" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idPersona = " & cbComercial.SelectedItem.itemdata
        End If
        If cbEstado.SelectedIndex <> -1 And cbEstado.Text <> "TODOS" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idEstado = " & cbEstado.SelectedItem.gidestado
        End If

        If cbPais.SelectedIndex <> -1 Then
            Dim st As String = ""
            If cbPais.SelectedItem.ToString = "TODOS" Or cbPais.SelectedItem.ToString = "" Then
                st = "FA.idUbicacion is not null"
            Else
                st = " UB.idPais = " & cbPais.SelectedItem.gidPais
            End If
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & st
        End If
        If cbProvincia.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PR.Provincia like '" & cbProvincia.Text & "%' "
        End If

        If cbAutonomia.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AU.idAutonomia = " & cbAutonomia.SelectedItem.gidAutonomia
        End If

        If CambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & "  CONVERT(datetime,CONVERT(Char(10), FA.Fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), FA.Fecha,103))  <= '" & dtpHasta.Value.Date & "' "
            CambioFechas = False
        Else

            If IsNumeric(cbAño.Text) Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & "  Year(FA.Fecha)= " & vAño
            End If
            If cbMes.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & "  Month(FA.Fecha)= " & cbMes.SelectedIndex + 1
            End If

            If cbTrimestre.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & "  Month(FA.Fecha)in "
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
        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.codArticulo like '" & cbCodArticulo.Text & "%' "
        End If

        If cbArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.Articulo like '" & cbArticulo.Text & "%' "
        End If

        If cbTipo.SelectedIndex <> -1 Then
            If cbTipo.Text = "TODOS" Then
                If sBusqueda <> "" Then
                    sBusqueda = sBusqueda & " and AR.idTipoArticulo > -1"
                Else
                    sBusqueda = sBusqueda & " AR.idTipoArticulo > -1"
                End If

            Else
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " AR.idTipoArticulo = " & cbTipo.SelectedItem.itemData
            End If
        End If

        If cbSubTipo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " SubTipoArticulo = '" & cbSubTipo.Text & "' "
        End If
        Call ActualizarLV()

    End Sub

    'Actualiza el listview.
    Private Sub ActualizarLV()
        Try
            lvDocumentos.Items.Clear()
            Dim Suma As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim SumaCantidad As Double = 0
            Dim lista As List(Of DatosEstadisticaVentas)
            Dim vSeleccion As String
            If ckInformeComerciales.Checked = True Or ckInformeTipos.Checked = True Then
                If ckInformeComerciales.Checked = True Then
                    Orden = "usuario"
                    vSeleccion = "idpersona"
                Else
                    Orden = "tipoarticulo"
                    vSeleccion = "idtipoarticulo"
                End If
            Else
                If cbPais.Text = "TODOS" Then
                    Orden = "pais"
                    vSeleccion = "idpais"
                Else
                    Orden = "cliente"
                    vSeleccion = "idcliente"
                End If
            End If
            lvEstadisticas()
            lista = funcCF.BusquedaLibre(sBusqueda, Orden & " " & Direccion, vSeleccion)
            For Each dts As DatosEstadisticaVentas In lista
                Call NuevaLineaLV(dts)
                SumaCantidad = SumaCantidad + dts.gCantidad
                If dts.gcodMoneda = "EU" Then
                    Suma = Suma + dts.gBase
                Else
                    Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    AvisoG = AvisoG Or Aviso
                    If Aviso Then FechaCambioG = FechaCambio
                End If
            Next
            Total.Text = FormatNumber(Suma, 2)
            Cantidad.Text = FormatNumber(SumaCantidad, 2)
            Contador.Text = lvDocumentos.Items.Count
            lbCambio.Text = "CAMBIO " & FechaCambioG
            lbCambio.Visible = AvisoG
            comprobarListviewItems()
        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosEstadisticaVentas)
        With lvDocumentos.Items.Add(dts.gColumna_0)
            .SubItems.Add(dts.gColumna_1)
            .SubItems.Add(FormatNumber(dts.gCantidad, 0))
            .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
        End With
    End Sub


    'Limpiamos formulario.
    Private Sub Limpiar()
        Semaforo = False
        cbAutonomia.Text = ""
        cbAutonomia.SelectedIndex = -1
        cbProvincia.Text = ""
        cbProvincia.SelectedIndex = -1
        cbCliente.Text = "TODOS"
        'cbCliente.SelectedIndex = -1
        cbPais.Text = ""
        cbPais.SelectedIndex = -1
        cbTipo.SelectedIndex = -1
        cbTipo.Text = "TODOS"
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        cbEstado.SelectedIndex = -1
        cbEstado.Text = "TODOS"
        cbAño.Text = Now.Year
        cbMes.Text = ""
        cbMes.SelectedIndex = -1
        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1
        CambioFechas = False
        dtpDesde.Value = CDate("1-1-" & Now.Year)
        dtpHasta.Value = Now.Date
        If cbPais.SelectedIndex = -1 OrElse (cbPais.Text <> PaisPorDefecto.gPais) Then
            'Si el pais no es España, recargamos
            'cbPais.Text = PaisPorDefecto.gPais
            cbAutonomia.Items.Clear()
            Call introducirAutonomias()
            cbProvincia.Items.Clear()
            Call introducirProvincias()
        End If
        If Not VerClientesPropios Then
            cbComercial.SelectedIndex = -1
            cbComercial.Text = "TODOS"
        End If
        CambioFechas = False
        Orden = "Cliente"
        Direccion = "ASC"
        Columna = 0
        ckInformeComerciales.Checked = False
        ckInformeTipos.Checked = False
        Semaforo = True
    End Sub

#End Region

#Region "BOTONES GENERALES"

    'Al pulsar el boton salir cierra el formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    'Al pulsar el boton de limpiar, primero limpia y luego realiza la busqueda con los valores inicales.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call Limpiar()
        Call Busqueda()
    End Sub

    'Abre la previsualizacion del informe.
    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        If ckInformeComerciales.Checked = True Or ckInformeTipos.Checked = True Then
            If ckInformeComerciales.Checked Then
                Dim GG As New InformeEstadisticaVentasComerciales
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            Else
                Dim GG As New InformeEstadisticaVentasTipo
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            End If
        Else
            If cbPais.SelectedIndex <> 0 Then
                Dim GG As New InformeEstadisticaVentas
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            ElseIf cbPais.SelectedItem.ToString = "TODOS" Then
                Dim GG As New InformeEstadisticaVentasPaises
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            End If
        End If
    End Sub

    'Formatea la cadena que se muestra en el titulo del informe.
    Private Function PonerTitulo(ByVal ConCliente As Boolean) As String
        Dim Titulo As String = ""
        Dim ponerCRLF As Boolean = False
        If ConCliente Then
            If cbCliente.Text <> "" Then
                Titulo = "CLIENTE: " & cbCliente.Text & "  "
                ponerCRLF = True
            End If
            If ponerCRLF Then Titulo = Titulo & vbCrLf
        End If
        ponerCRLF = False
        If cbPais.SelectedIndex <> -1 Then
            Titulo = "PAIS: " & cbPais.Text & "  "
            ponerCRLF = True
        End If
        If cbAutonomia.SelectedIndex <> -1 Then
            Titulo = Titulo & "C.AUTONOMA: " & cbAutonomia.Text & "  "
            ponerCRLF = True
        End If
        If cbProvincia.SelectedIndex <> -1 Then
            Titulo = Titulo & "PROVINCIA: " & cbProvincia.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & vbCrLf
        ponerCRLF = False
        If cbTipo.SelectedIndex <> -1 Then
            Titulo = Titulo & "TIPO: " & cbTipo.Text & "  "
            ponerCRLF = True
        End If
        If cbSubTipo.SelectedIndex <> -1 Then
            Titulo = Titulo & "SUBTIPO: " & cbSubTipo.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & vbCrLf
        ponerCRLF = False
        If cbCodArticulo.Text <> "" Or cbArticulo.Text <> "" Then
            Titulo = Titulo & "ARTÍCULO: " & cbCodArticulo.Text & " - " & cbArticulo.Text
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & vbCrLf
        ponerCRLF = False
        If cbEstado.SelectedIndex <> -1 Then
            Titulo = Titulo & "ESTADO: " & cbEstado.Text & "  "
            ponerCRLF = True
        End If
        If cbComercial.SelectedIndex <> -1 Then
            Titulo = Titulo & Chr(13) & "COMERCIAL: " & cbComercial.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & vbCrLf
        ponerCRLF = False
        If cbAño.SelectedIndex <> -1 Then
            Titulo = Titulo & "AÑO: " & cbAño.Text & "  "
            ponerCRLF = True
        End If
        If cbTrimestre.SelectedIndex <> -1 Then
            Titulo = Titulo & cbTrimestre.Text & "  "
            ponerCRLF = True
        End If
        If cbMes.SelectedIndex <> -1 Then
            Titulo = Titulo & "MES: " & cbMes.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & vbCrLf
        ponerCRLF = False
        If CambioFechas Then
            Titulo = Titulo & "ENTRE: " & dtpDesde.Value.Date & " Y " & dtpHasta.Value.Date
            ponerCRLF = True
        End If
        Return UCase(Titulo)
    End Function

    'Muestra la ficha del cliente seleccionado en el comobobox.
    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim iidCliente As Integer = cbCliente.SelectedItem.itemdata
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = iidCliente
            GG.ShowDialog()
        End If
    End Sub

    'Muestra la ficha del articulo seleccionado en el combobox.
    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticulo.Click
        If cbArticulo.SelectedIndex <> -1 Then
            Dim iidArticulo As Integer = cbArticulo.SelectedItem.itemdata
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.pModo = "DOC"
            GG.ShowDialog()
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Public Sub cambiosControles()
        If Semaforo Then
            Call Busqueda()
        End If

        If cbTipo.SelectedIndex <> -1 And cbTipo.Text <> "TODOS" Then
            cbSubTipo.Enabled = True
            If bloqueoSubTipos = True Then
                iidTipoArticulo = cbTipo.SelectedItem.itemdata
                Call IntroducirSubTiposArticulo()
                bloqueoSubTipos = False
            End If
        Else
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Enabled = False
        End If

        If cbAño.Text = "TODOS" Then
            cbMes.SelectedIndex = -1
            cbTrimestre.SelectedIndex = -1
            cbTrimestre.Enabled = False
            cbMes.Enabled = False
        Else
            cbTrimestre.Enabled = True
            cbMes.Enabled = True
        End If
        comprobarListviewItems()

    End Sub

    Public Sub comprobarListviewItems()
        If lvDocumentos.Items.Count <> 0 Then
            bListado.Enabled = True
        Else
            bListado.Enabled = False
        End If

    End Sub

#Region "SELECCION COMBOBOX"

    'Al seleccionar un articulo en el combobox
    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedIndexChanged
        If cbArticulo.SelectedIndex <> -1 Then
            Semaforo = False
            Dim iidArticulo As Integer = cbArticulo.SelectedItem.itemdata
            cbCodArticulo.Text = funcAR.codArticulo(iidArticulo)
            Semaforo = True
            Call Busqueda()
        End If
    End Sub

    'Al seleccionar un codigo de articulo en el combobox
    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedIndexChanged
        If cbCodArticulo.SelectedIndex <> -1 Then
            Semaforo = False
            Dim iidArticulo As Integer = cbCodArticulo.SelectedItem.itemdata
            cbArticulo.Text = funcAR.Articulo(iidArticulo)
            Semaforo = True
            Call Busqueda()
        End If
    End Sub

    'Al seleccionar un mes en el combox elimina el indice de TRIMESTRE
    Private Sub cambio_cbMes(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMes.SelectedIndexChanged
        If cbMes.SelectedIndex <> -1 Then
            cbTrimestre.SelectedIndex = -1
        End If
        cambiosControles()
    End Sub

    'Al seleccionar un trimestre en el combox elimina el indice de MES
    Private Sub cambio_cbTrimestre(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTrimestre.SelectedIndexChanged
        If cbTrimestre.SelectedIndex <> -1 Then
            cbMes.SelectedIndex = -1
        End If
        cambiosControles()
    End Sub

    'Si el combobox de tipo articulo tiene indice se desbloquea el combobox de subtipoarticulo.
    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.TextChanged, cbSubTipo.TextChanged
        Dim vTipo As String = Trim(cbTipo.Text)
        Dim vSubTipo As String = Trim(cbSubTipo.Text)
        If vTipo = "" Then
            cbTipo.SelectedIndex = -1
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Enabled = False
        End If
        If vSubTipo = "" Then
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Text = ""
        End If
    End Sub

    Private Sub cambioIndices_o_Texto_subTipo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged
        bloqueoSubTipos = True
        cambiosControles()
    End Sub

    Private Sub cambioIndices(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    cbPais.SelectedIndexChanged, _
    cbAño.SelectedIndexChanged, cbComercial.SelectedIndexChanged, _
    cbEstado.SelectedIndexChanged, cbArticulo.SelectedIndexChanged, _
    cbCodArticulo.SelectedIndexChanged, cbSubTipo.SelectedIndexChanged, _
    cbCliente.SelectedIndexChanged, cbProvincia.SelectedIndexChanged, _
    cbAutonomia.SelectedIndexChanged
        cambiosControles()
    End Sub

    Private Sub cambioIndices2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
cbPais.TextChanged, cbAutonomia.TextChanged, cbProvincia.TextChanged
        If Me.ActiveControl.Text = "" Then
            cambiosControles()
        End If
    End Sub

    Private Sub cb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    cbPais.KeyPress, cbComercial.KeyPress, _
    cbEstado.KeyPress, cbCodArticulo.KeyPress, _
    cbSubTipo.KeyPress, cbCliente.KeyPress, _
    cbProvincia.KeyPress, cbAutonomia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

#End Region

#Region "SELECCION LISTVIEW"

    'Cuando hacemos doble clic en el listview.
    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        If lvDocumentos.SelectedItems.Count > 0 Then
            Dim iidCliente As Integer = lvDocumentos.SelectedItems(0).Text
            Dim GG As New InformeEstadisticaVentas
            GG.verInforme(sBusqueda, Orden, iidCliente, PonerTitulo(False))
            GG.ShowDialog()
        End If
    End Sub
    'Cuando hacemos clic en la cabecera columna se ordena la columna seleccionada
    Private Sub Orden_columnas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick

        If e.Column = Columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If
        Select Case e.Column
            Case 0
                If cbPais.Text = "TODOS" Then
                    Orden = "idpais"
                Else
                    Orden = "idcliente"
                End If
            Case 1
                If cbPais.Text = "TODOS" Then
                    Orden = "pais"
                Else
                    Orden = "cliente"
                End If
            Case 2
                Orden = "Cantidad"
            Case 3
                Orden = "Base"

        End Select

        Columna = e.Column

        Call ActualizarLV()

    End Sub
    'Formatea las columnas del listview.
    Public Sub lvEstadisticas()
        With lvDocumentos
            .GridLines = True
            .Columns.Clear()
            If ckInformeComerciales.Checked Then
                .Columns.Add("ID COMERCIAL")
                .Columns.Add("COMERCIAL")
            End If
            If ckInformeTipos.Checked Then
                .Columns.Add("ID TIPO")
                .Columns.Add("TIPO DE ARTÍCULO")
            End If
            If ckInformeComerciales.Checked = False And ckInformeTipos.Checked = False Then
                If cbPais.Text = "TODOS" Then
                    .Columns.Add("ID PAÍS")
                    .Columns.Add("PAÍS")
                Else
                    .Columns.Add("ID CLIENTE")
                    .Columns.Add("CLIENTE")
                End If
            End If
            .Columns.Add("CANTIDAD")
            .Columns.Add("TOTAL BASE")
            .Columns(0).Width = 0
            .Columns(1).Width = 350
            .Columns(2).Width = 116
            .Columns(3).Width = 124
        End With
    End Sub

#End Region

#Region "CAMBIO DE FECHAS"

    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If Semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If Semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub

#End Region

#End Region

#Region "LLENAR COMBOBOX"
    'Introducimos comerciales en el combobox.
    Private Sub IntroducirResponsables()
        Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(If(VerClientesPropios, Inicio.vIdUsuario, 0))
        For Each item As IDComboBox In lista
            cbComercial.Items.Add(item)
        Next
        cbComercial.Items.Add("TODOS")
        If VerClientesPropios Then
            cbComercial.Enabled = False
            If lista.Count = 0 Then
                MsgBox("No está autorizado para visualizar clientes")
                Me.Close()
            Else
                cbComercial.SelectedIndex = 0
            End If
        Else
            cbComercial.SelectedIndex = -1
        End If
        cbComercial.Text = "TODOS"
    End Sub

    'Introducimos años en el combobox.
    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = funcFA.buscaPrimerDia(0).Year To Now.Year
            cbAño.Items.Add(Año)
        Next
        cbAño.Items.Add("TODOS")
        cbAño.Text = Now.Year
    End Sub

    'Introducimos los trimestres en el combobox.
    Private Sub IntroducirTrimestres()
        cbTrimestre.Items.Clear()
        cbTrimestre.Items.Add("TRIMESTRE 1")
        cbTrimestre.Items.Add("TRIMESTRE 2")
        cbTrimestre.Items.Add("TRIMESTRE 3")
        cbTrimestre.Items.Add("TRIMESTRE 4")
        cbTrimestre.SelectedIndex = -1
    End Sub

    'Introducimos los meses en el combobox.
    Private Sub IntroducirMeses()
        cbMes.Items.Clear()
        For Mes = 1 To 12
            cbMes.Items.Add(UCase(MonthName(Mes)))
        Next
        cbMes.SelectedIndex = -1
    End Sub

    'Introducimos los clientes en el combobox.
    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidCliente))
        Next
        cbCliente.Items.Add("TODOS")
        cbCliente.Items.Add("")
    End Sub

    'Introducimos los estados en el combobox.
    Private Sub introducirEstados()
        Dim funcES As New FuncionesEstados
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Factura")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
        cbEstado.Items.Add("TODOS")
        cbEstado.Text = "TODOS"
    End Sub

    'Introducimos los articulos en el combobox.
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

    'Introducimos los tipo de articulos en el combobox.
    Private Sub IntroducirTiposArticulo()
        Dim funcTI As New FuncionesTiposArticulo
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosTipoArticulo) = funcTI.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoArticulo, dts.gidTipoArticulo))
        Next
        cbTipo.Text = "TODOS"
    End Sub

    'Introducimos los paises en el combobox.
    Private Sub introducirPaises()
        Try
            Dim lista As List(Of datosPais) = funcPA.mostrar
            Dim dts As datosPais
            cbPais.Items.Add("TODOS")
            For Each dts In lista
                cbPais.Items.Add(dts)
            Next
            cbPais.Items.Add("")
            cbPais.Text = ""
            cbPais.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Introducimos las provincias en el combobox.
    Private Sub introducirProvincias()
        Try
            cbProvincia.Items.Clear()
            Dim iidPais As Integer = If(cbPais.SelectedIndex = -1, 1, cbPais.SelectedItem.gidPais)
            Dim func As New funcionesProvincia
            Dim lista As List(Of datosProvincia) = func.mostrar(iidPais)
            Dim dts As datosProvincia
            For Each dts In lista
                cbProvincia.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Introducimos las autonomias en el combobox.
    Private Sub introducirAutonomias()
        cbAutonomia.Items.Clear()
        Dim iidPais As Integer = If(cbPais.SelectedIndex = -1, 1, cbPais.SelectedItem.gidPais)
        Dim funcAU As New funcionesAutonomias
        Dim lista As List(Of datosAutonomia) = funcAU.mostrar(iidPais)
        For Each dts As datosAutonomia In lista
            cbAutonomia.Items.Add(dts)
        Next
    End Sub

    'Llena el combobox de subtiposarticulos
    Private Sub IntroducirSubTiposArticulo()
        iidTipoArticulo = cbTipo.SelectedItem.itemdata
        If iidTipoArticulo > 0 Then
            cbSubTipo.Text = ""
            cbSubTipo.Items.Clear()
            Dim lista As List(Of DatosSubTipoArticulo) = funcSP.Mostrar(iidTipoArticulo, 0, True)
            Dim dts As DatosSubTipoArticulo
            For Each dts In lista
                cbSubTipo.Items.Add(New IDComboBox(dts.gSubTipoArticulo, dts.gidSubTipoArticulo))
            Next
        End If
    End Sub
#End Region

    'Abre el formulario provisional
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ArcticulosPersonalizado.Show()
    End Sub

    Private Sub ckInformeComerciales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckInformeComerciales.CheckedChanged
        If checkActivado = False Then
            If ckInformeComerciales.Checked = True Then
                checkActivado = True
                ckInformeTipos.Checked = False
                checkActivado = False
                cbComercial.Text = "TODOS"
                cambiosControles()
            Else
                ckInformeTipos.Enabled = True
                cambiosControles()
            End If
        End If
    End Sub

    Private Sub ckInformeTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckInformeTipos.CheckedChanged
        If checkActivado = False Then
            If ckInformeTipos.Checked = True Then
                checkActivado = True
                ckInformeComerciales.Checked = False
                checkActivado = False
                cbTipo.Text = "TODOS"
                cambiosControles()
            Else
                ckInformeComerciales.Enabled = True
                cambiosControles()
            End If
        End If
    End Sub
    'Muestra una ayuda de busqueda.
    Private Sub ayudaBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ayudaBusqueda.Click
        MsgBox("Para realizar una busqueda de todos los clientes tiene que estar vacio el campo país y inactivos los check de informe por tipos y por comerciales." _
                & vbLf & vbLf & "Para realizar una busqueda de todos los paises tiene que seleccionar TODOS en el campo país y inactivos los check de informe por tipos y por comerciales. " _
                & vbLf & vbLf & "Para realizar una busqueda por comercial tiene que estar activo el check informe por comerciales." _
                & vbLf & vbLf & "Para realizar una busqueda por tipo tiene que estar activo el check informe por tipos.", MsgBoxStyle.Information)
    End Sub

End Class