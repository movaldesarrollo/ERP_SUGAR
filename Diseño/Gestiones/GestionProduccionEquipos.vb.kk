Public Class GestionEquiposProduccion

    Private funcCR As New FuncionesConceptosProduccion
    Private funcEP As New FuncionesEquiposProduccion
    Private funcES As New FuncionesEstados
    Private funcFE As New FuncionesFestivos
    Private funcAR As New FuncionesArticulos
    Private funcEC As New FuncionesEscandallos
    Private funcCP As New FuncionesConceptosPedidos
    Private funcPE As New FuncionesPedidos
    Private funcSK As New FuncionesStock
    Private funcCE As New FuncionesConceptosEquiposProduccion
    Private dtsAR As New DatosArticulo
    Private idSEquipo As List(Of Long)
    Private iidArticulo As Integer 'presentaremos los equipos del Artículo concreto
    Private iidArticuloBase As Integer 'presentaremos los equipos con este artículo base (y él mismo)
    Private iidProduccion As Long 'presentaremos los equipos de un concepto de producción
    Private iidEquipo As Integer 'Equipo seleccionado
    Private indice As Integer
    Private inumPedido As Integer 'Presentamos los equipos de un pedido
    Private indiceL As Integer
    Private listaEP As List(Of DatosEquipoProduccion)
    Private listaElectronica As List(Of DatosConceptoEquipoProduccion)
    Private listaTaller As List(Of DatosConceptoEquipoProduccion)
    'Private estadoAcabado As DatosEstado
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private columna As Byte
    Private Direccion As String
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    'Private lvwColumnSorterT As OrdenarLV
    'Private lvwColumnSorterE As OrdenarLV
    Private semanaActual As Byte
    Private semaforo As Boolean
    Private vsoloLectura As Boolean
    Private EstadoAnulado As DatosEstado
    Private EstadoEnCurso As DatosEstado
    Private EstadoEspera As DatosEstado
    Private EstadoCompleto As DatosEstado
    Private Vista As String
    Private AcabadosAhora As Integer
    Private Cambios As Boolean
    Private listaidProduccion As List(Of Long)
    Private listanumPedido As List(Of Integer)
    Private sIDsProduccion As String
    Private ColumnaElectronica As Integer
    Private OrdenElectronica As String
    Private DireccionElectronica As String
    Private ColumnaTaller As Integer
    Private OrdenTaller As String
    Private DireccionTaller As String
    Private ColumnaEquipos As Integer
    Private OrdenEquipos As String
    Private DireccionEquipos As String


    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property


    Public Property pidSEquipo() As List(Of Long)
        Get
            Return idSEquipo
        End Get
        Set(ByVal value As List(Of Long))
            idSEquipo = value
        End Set
    End Property


    Public Property pIndice() As Integer
        Get
            Return indiceL
        End Get
        Set(ByVal value As Integer)
            indiceL = value
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


    Public Property pidArticuloBase() As Integer
        Get
            Return iidArticuloBase
        End Get
        Set(ByVal value As Integer)
            iidArticuloBase = value
        End Set
    End Property

    Public Property pidProduccion() As Long
        Get
            Return iidProduccion
        End Get
        Set(ByVal value As Long)
            iidProduccion = value
        End Set
    End Property

    Public Property pidSProduccion() As String
        Get
            Return sIDsProduccion
        End Get
        Set(ByVal value As String)
            sIDsProduccion = value
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

    Public Property pVista() As String
        Get
            Return Vista
        End Get
        Set(ByVal value As String)
            Vista = value
        End Set
    End Property

    Private Sub GestionEquiposProduccion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Cambios Then
            If MsgBox("¿Salir sin guardar los cambios?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub



    Private Sub GestionEquiposProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            bGuardar.Enabled = Not vsoloLectura
            'Permisos. Ocultamos los tabs según los permisos
            Dim funcP As New FuncionesPersonal
            If funcP.Parametro(Inicio.vIdUsuario, "GestionProduccion", "SOLO TALLER") Then
                tpGlobal.Parent = Nothing
                tpElectronica.Parent = Nothing
                Vista = "TALLER"
            End If
            If funcP.Parametro(Inicio.vIdUsuario, "GestionProduccion", "SOLO ELECTRONICA") Then
                tpGlobal.Parent = Nothing
                tpTaller.Parent = Nothing
                Vista = "ELECTRÓNICA"
            End If

            Cambios = False
            Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
            Me.Height = desktopSize.Height - 50
            If desktopSize.Height < 1000 Then
                Me.Height = desktopSize.Height - 50
            Else
                Me.Height = 950
            End If
            'Me.Location = New Point(Me.Location.X, 5)
            semaforo = False
            Call Inicializar()
            'idestadoAcabado = funcES.EstadoCompleto("EQUIPO")
            semanaActual = DatePart(DateInterval.WeekOfYear, Now.Date)
            If semanaActual = 53 And DatePart(DateInterval.Weekday, Now.Date) < 7 Then semanaActual = 1
            EstadoAnulado = funcES.EstadoAnulado("EQUIPO")
            EstadoEnCurso = funcES.EstadoEnCurso("EQUIPO")
            EstadoEspera = funcES.EstadoEspera("EQUIPO")
            EstadoCompleto = funcES.EstadoCompleto("EQUIPO")
            ckSeleccion.Location = New Point(bAcabadoElectronica.Location.X + 6, bAcabadoElectronica.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
            ckSeleccion.Location = New Point(lvEquipos.Location.X + 6, lvEquipos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
            ' Call IntroducirSecciones()


            'If Vista = "TALLER" Then
            '    TabControl1.SelectedTab = tpTaller
            '    bAcabadoElectronica.Enabled = False
            '    bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
            'ElseIf Vista = "ELECTRÓNICA" Then
            '    TabControl1.SelectedTab = tpElectronica
            '    bAcabadoTaller.Enabled = False
            '    bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
            'Else
            '    TabControl1.SelectedTab = tpGlobal
            'End If
            semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub GestionEquiposProduccion_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call CargarListaDatos()
        Call CargarListasConceptos()
        PBCarga.Maximum = listaEP.Count + listaElectronica.Count + listaTaller.Count
        PBCarga.Visible = True

        Call cargarLV()
        Call CargarLVElectronica()
        Call CargarLVTaller()

        If Vista = "TALLER" Then
            TabControl1.SelectedTab = tpTaller
            bAcabadoElectronica.Enabled = False
            bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
        ElseIf Vista = "ELECTRÓNICA" Then
            TabControl1.SelectedTab = tpElectronica
            bAcabadoTaller.Enabled = False
            bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
        Else
            TabControl1.SelectedTab = tpGlobal
            bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
            bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
        End If

    End Sub

#Region "INICIALIZACIÓN"


    Private Sub Inicializar()
        ColumnaEquipos = 1
        OrdenEquipos = "idEquipo"
        DireccionEquipos = "ASC"
        ColumnaElectronica = 1
        OrdenElectronica = "idEquipo"
        DireccionElectronica = "ASC"
        ColumnaTaller = 1
        OrdenTaller = "idEquipo"
        DireccionTaller = "ASC"

    End Sub

    Private Sub limpiarEdicion()
        indice = -1
        Observaciones.Text = ""
        If iidArticuloBase > 0 Then
            lbArticulo.Text = "ARTÍCULO BASE"
            codArticulo.Text = dtsAR.gcodArticulo
            Articulo.Text = dtsAR.gArticulo
        End If
    End Sub



#End Region


#Region "CARGAR DATOS"

    Private Sub CargarListaDatos()
        If idSEquipo Is Nothing Then
            If iidArticuloBase <> 0 Then
                lbArticulo.Text = "ARTÍCULO BASE"
                dtsAR = funcAR.Mostrar1(iidArticuloBase)
                codArticulo.Text = dtsAR.gcodArticulo
                Articulo.Text = dtsAR.gArticulo
                Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN BASADOS EN " & dtsAR.gcodArticulo
                listaEP = funcEP.Busqueda("EP.idEstado <> " & EstadoCompleto.gidEstado & " AND (Escandallos.idArticuloBase = " & iidArticuloBase & " OR CP.idArticulo = " & iidArticuloBase & ") ", "numSerie ASC ", 0)

            ElseIf iidArticulo <> 0 Then
                lbArticulo.Text = "ARTÍCULO"
                dtsAR = funcAR.Mostrar1(iidArticulo)
                codArticulo.Text = dtsAR.gcodArticulo
                Articulo.Text = dtsAR.gArticulo
                Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN DEL MODELO " & dtsAR.gcodArticulo
                listaEP = funcEP.Busqueda("EP.idEstado <> " & EstadoCompleto.gidEstado & " AND CP.idArticulo = " & iidArticulo, " EP.idEquipo ASC ", 0)
             
                If Vista = "" Then
                    bAcabadoElectronica.Enabled = funcEC.VistaElectronica(iidArticulo)
                    bAcabadoTaller.Enabled = funcEC.VistaTaller(iidArticulo)
                End If
            ElseIf sIDsProduccion <> "0" And sIDsProduccion <> "" Then
                Dim l As Integer = InStr(sIDsProduccion, ",")
                If l = 0 Then
                    iidProduccion = sIDsProduccion
                Else
                    iidProduccion = Microsoft.VisualBasic.Left(sIDsProduccion, l)
                End If
                lbArticulo.Text = "ARTÍCULO"
                Dim dtsCP As DatosConceptoProduccion = funcCR.Mostrar1(iidProduccion)
                codArticulo.Text = dtsCP.gcodArticulo
                Articulo.Text = dtsCP.gArticulo
                Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN DEL MODELO " & dtsCP.gcodArticulo
                listaEP = funcEP.Busqueda("EP.idEstado <> " & EstadoCompleto.gidEstado & " AND CP.idProduccion in (" & sIDsProduccion & ") ", "EP.idEquipo ASC ", 0)
               
                If Vista = "" Then
                    bAcabadoElectronica.Enabled = funcEC.VistaElectronica(dtsCP.gidArticulo)
                    bAcabadoTaller.Enabled = funcEC.VistaTaller(dtsCP.gidArticulo)
                End If

                If listaEP.Count > 0 Then Observaciones.Text = listaEP(0).gObservaciones
            ElseIf iidProduccion <> 0 Then
                lbArticulo.Text = "ARTÍCULO"
                Dim dtsCP As DatosConceptoProduccion = funcCR.Mostrar1(iidProduccion)
                codArticulo.Text = dtsCP.gcodArticulo
                Articulo.Text = dtsCP.gArticulo
                Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN DEL MODELO " & dtsCP.gcodArticulo
                listaEP = funcEP.Busqueda("EP.idEstado <> " & EstadoCompleto.gidEstado & " AND CP.idProduccion = " & iidProduccion, "EP.idEquipo ASC ", 0)
                
                If Vista = "" Then
                    bAcabadoElectronica.Enabled = funcEC.VistaElectronica(dtsCP.gidArticulo)
                    bAcabadoTaller.Enabled = funcEC.VistaTaller(dtsCP.gidArticulo)
                End If
                If listaEP.Count > 0 Then Observaciones.Text = listaEP(0).gObservaciones
            ElseIf inumPedido <> 0 Then
                Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN DEL PEDIDO " & inumPedido
                listaEP = funcEP.Busqueda("EP.idEstado <> " & EstadoCompleto.gidEstado & " AND PE.numPedido = " & inumPedido, "EP.idEquipo ASC ", 0)
            End If
        Else
            'Hemos recibido una lista de equipos
            listaEP = New List(Of DatosEquipoProduccion)
            For Each iidEquipo As Long In idSEquipo
                listaEP.Add(funcEP.Mostrar1(iidEquipo))
            Next
            If iidArticulo > 0 Then
                lbArticulo.Text = "ARTÍCULO"
                dtsAR = funcAR.Mostrar1(iidArticulo)
                codArticulo.Text = dtsAR.gcodArticulo
                Articulo.Text = dtsAR.gArticulo
                Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN QUE INCLUYEN " & dtsAR.gcodArticulo
            End If
        End If

    End Sub

    Private Sub cargarLV()
        If Not listaEP Is Nothing Then
            semaforo = False
            lvEquipos.Items.Clear()
            PBCarga.Visible = True
            For Each dts As DatosEquipoProduccion In listaEP
                PBCarga.Increment(1)
                With lvEquipos.Items.Add("")
                    .SubItems.Add(dts.gidEquipo)
                    .SubItems.Add(dts.gnumSerie)
                    .SubItems.Add(dts.gcodArticulo)
                    .SubItems.Add(dts.gArticulo)
                    .SubItems.Add(dts.gEstadoTaller)
                    .SubItems.Add(dts.gEstadoElectronica)
                    .SubItems.Add(dts.gcodCli)
                    .SubItems.Add(If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido)))
                    .SubItems.Add(dts.gFechaPedido)
                    .SubItems.Add(dts.gFechaPrevista)
                    .SubItems.Add(DiasPrevistos(dts.gFechaPrevista))
                    .SubItems.Add(dts.gPrioridad)
                    .SubItems.Add(dts.gEtiqueta)
                    .SubItems.Add(dts.gidEstado)
                    .SubItems.Add(dts.gidEstadoTaller)
                    .SubItems.Add(dts.gidEstadoElectronica)
                    Select Case dts.gidEstado
                        Case EstadoAnulado.gidEstado
                            .ForeColor = Color.Gray
                        Case EstadoCompleto.gidEstado
                            .ForeColor = Color.Green
                            '.Font = New Font(.Font, FontStyle.Bold)
                        Case EstadoEspera.gidEstado
                            .ForeColor = Color.Black
                        Case EstadoEnCurso.gidEstado
                            .ForeColor = Color.Orange
                            '.Font = New Font(.Font, FontStyle.Bold)
                        Case Else
                            .ForeColor = Color.Cyan
                    End Select

                End With
            Next
            Call CalculaTotal()
            PBCarga.Visible = False
            semaforo = True
        End If
    End Sub

   


    Private Sub CargarListasConceptos()
        If Not listaEP Is Nothing Then
            listaElectronica = New List(Of DatosConceptoEquipoProduccion)
            listaTaller = New List(Of DatosConceptoEquipoProduccion)
            Dim lista As List(Of DatosConceptoEquipoProduccion)
            For Each dts As DatosEquipoProduccion In listaEP
                lista = funcCE.Mostrar(dts.gidEquipo)
                For Each dtsCE As DatosConceptoEquipoProduccion In lista
                    dtsCE.gcodCli = dts.gcodCli
                    dtsCE.gnumPedido = dts.gnumPedido
                    dtsCE.gFechaPedido = dts.gFechaPedido
                    dtsCE.gFechaPrevista = dts.gFechaPrevista
                    dtsCE.gPrioridad = dts.gPrioridad
                    dtsCE.gidEstadoEquipo = dts.gidEstado
                    If dtsCE.gidEstadoTaller <> EstadoAnulado.gidEstado Then
                        listaTaller.Add(dtsCE)
                    End If
                    If dtsCE.gidEstadoElectronica <> EstadoAnulado.gidEstado Then
                        listaElectronica.Add(dtsCE)
                    End If
                Next
            Next
        End If
    End Sub


    Private Sub CargarLVElectronica()
        semaforo = False
        lvElectronica.Items.Clear()
        PBCarga.Visible = True
        For Each dtsCE As DatosConceptoEquipoProduccion In listaElectronica
            PBCarga.Increment(1)
            With lvElectronica.Items.Add("")
                .SubItems.Add(dtsCE.gidConcepto)
                .SubItems.Add(dtsCE.gidEquipo)
                .SubItems.Add(dtsCE.gcodArticulo)
                .SubItems.Add(dtsCE.gArticulo)
                '.SubItems.Add(dtsCE.gEstadoTaller)
                .SubItems.Add(dtsCE.gEstadoElectronica)
                .SubItems.Add(dtsCE.gcodCli)
                .SubItems.Add(If(dtsCE.gnumPedido = 0, "MANUAL", CStr(dtsCE.gnumPedido)))
                .SubItems.Add(dtsCE.gFechaPedido)
                .SubItems.Add(dtsCE.gFechaPrevista)
                .SubItems.Add(DiasPrevistos(dtsCE.gFechaPrevista))
                .SubItems.Add(dtsCE.gPrioridad)
                .SubItems.Add(dtsCE.gEtiqueta)
                .SubItems.Add(dtsCE.gidEstadoElectronica)
                Select Case dtsCE.gidEstadoElectronica
                    Case EstadoAnulado.gidEstado
                        .ForeColor = Color.Gray
                    Case EstadoCompleto.gidEstado
                        .ForeColor = Color.Green
                        '.Font = New Font(.Font, FontStyle.Bold)
                    Case EstadoEspera.gidEstado
                        If dtsCE.gidEstadoEquipo = EstadoEnCurso.gidEstado Then
                            .ForeColor = Color.Orange
                            ' .Font = New Font(.Font, FontStyle.Bold)
                        Else
                            .ForeColor = Color.Black
                        End If

                    Case EstadoEnCurso.gidEstado
                        .ForeColor = Color.Orange
                    Case Else
                        .ForeColor = Color.Cyan
                End Select
            End With
        Next
        ' CalculaTotalE()
        PBCarga.Visible = False
        semaforo = True
    End Sub

    Private Sub CargarLVTaller()
        semaforo = False
        lvTaller.Items.Clear()
        PBCarga.Visible = True
        For Each dtsCE As DatosConceptoEquipoProduccion In listaTaller
            PBCarga.Increment(1)
            With lvTaller.Items.Add("")
                .SubItems.Add(dtsCE.gidConcepto)
                .SubItems.Add(dtsCE.gidEquipo)
                .SubItems.Add(dtsCE.gcodArticulo)
                .SubItems.Add(dtsCE.gArticulo)
                .SubItems.Add(dtsCE.gEstadoTaller)
                '.SubItems.Add(dtsCE.gEstadoElectronica)
                .SubItems.Add(dtsCE.gcodCli)
                .SubItems.Add(If(dtsCE.gnumPedido = 0, "MANUAL", CStr(dtsCE.gnumPedido)))
                .SubItems.Add(dtsCE.gFechaPedido)
                .SubItems.Add(dtsCE.gFechaPrevista)
                .SubItems.Add(DiasPrevistos(dtsCE.gFechaPrevista))
                .SubItems.Add(dtsCE.gPrioridad)
                .SubItems.Add(dtsCE.gEtiqueta)
                .SubItems.Add(dtsCE.gidEstadoTaller)
                Select Case dtsCE.gidEstadoTaller
                    Case EstadoAnulado.gidEstado
                        .ForeColor = Color.Gray
                    Case EstadoCompleto.gidEstado
                        .ForeColor = Color.Green
                        '.Font = New Font(.Font, FontStyle.Bold)
                    Case EstadoEspera.gidEstado
                        If dtsCE.gidEstadoEquipo = EstadoEnCurso.gidEstado Then
                            .ForeColor = Color.Orange
                            ' .Font = New Font(.Font, FontStyle.Bold)
                        Else
                            .ForeColor = Color.Black
                        End If

                    Case EstadoEnCurso.gidEstado
                        .ForeColor = Color.Orange
                    Case Else
                        .ForeColor = Color.Cyan
                End Select

            End With
        Next
        'CalculaTotalT()
        PBCarga.Visible = False
        semaforo = True
    End Sub



    'Private Sub cargarLVSeparados()
    '    If Not listaEP Is Nothing Then
    '        lvTaller.Items.Clear()
    '        lvElectronica.Items.Clear()

    '        'Cargar lvTaller
    '        'lvwColumnSorterT = New OrdenarLV()
    '        'lvTaller.ListViewItemSorter = lvwColumnSorterT
    '        For Each dts As DatosEquipoProduccion In listaEP
    '            PBCarga.Increment(2)
    '            Dim lista As List(Of DatosConceptoEquipoProduccion) = funcCE.Mostrar(dts.gidEquipo)

    '            For Each dtsCE As DatosConceptoEquipoProduccion In lista
    '                If dtsCE.gidEstadoTaller <> EstadoAnulado.gidEstado Then
    '                    With lvTaller.Items.Add("")
    '                        .SubItems.Add(dtsCE.gidConcepto)
    '                        .SubItems.Add(dtsCE.gidEquipo)
    '                        .SubItems.Add(dtsCE.gcodArticulo)
    '                        .SubItems.Add(dtsCE.gArticulo)
    '                        .SubItems.Add(dtsCE.gEstadoTaller)
    '                        '.SubItems.Add(dtsCE.gEstadoElectronica)
    '                        .SubItems.Add(dts.gcodCli)
    '                        .SubItems.Add(If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido)))
    '                        .SubItems.Add(dts.gFechaPedido)
    '                        .SubItems.Add(dts.gFechaPrevista)
    '                        .SubItems.Add(DiasPrevistos(dts.gFechaPrevista))
    '                        .SubItems.Add(dts.gPrioridad)
    '                        .SubItems.Add(dts.gEtiqueta)
    '                        .SubItems.Add(dtsCE.gidEstadoTaller)
    '                        Select Case dtsCE.gidEstadoTaller
    '                            Case EstadoAnulado.gidEstado
    '                                .ForeColor = Color.Gray
    '                            Case EstadoCompleto.gidEstado
    '                                .ForeColor = Color.Green
    '                                '.Font = New Font(.Font, FontStyle.Bold)
    '                            Case EstadoEspera.gidEstado
    '                                If dts.gidEstado = EstadoEnCurso.gidEstado Then
    '                                    .ForeColor = Color.Orange
    '                                    ' .Font = New Font(.Font, FontStyle.Bold)
    '                                Else
    '                                    .ForeColor = Color.Black
    '                                End If

    '                            Case EstadoEnCurso.gidEstado
    '                                .ForeColor = Color.Orange
    '                            Case Else
    '                                .ForeColor = Color.Cyan
    '                        End Select

    '                    End With
    '                End If

    '                'Cargar lvElectronica
    '                'lvwColumnSorterE = New OrdenarLV()
    '                'lvElectronica.ListViewItemSorter = lvwColumnSorterE
    '                If dtsCE.gidEstadoElectronica <> EstadoAnulado.gidEstado Then




    '                End If

    '            Next
    '        Next
    '        Call CalculaTotalE()
    '        Call CalculaTotalT()
    '    End If
    'End Sub



#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Function DiasPrevistos(ByVal Fecha As Date) As Integer
        'Devuelve los dias laborables previstos desde hoy a la fecha prevista
        Dim dia As Date = Now.Date
        Dim contador As Integer = 0
        Do While dia < Fecha
            If funcFE.EsFestivo(dia) Then
            Else
                contador = contador + 1
            End If
            dia = dia.AddDays(1)
        Loop
        Return contador
    End Function


    Private Sub CalculaTotal()
        Dim suma As Double = 0
        Dim sumaEstaSemana As Double = 0
        Dim sumaSemanaProxima As Double = 0
        Dim suma2Semanas As Double = 0
        Dim sumaMasSemanas As Double = 0
        'Dim semanaActual As Byte = DatePart(DateInterval.WeekOfYear, Now.Date)
        Dim semanaPrevista As Byte = 0
        For Each item As ListViewItem In lvEquipos.Items
            suma = suma + 1
            semanaPrevista = DatePart(DateInterval.WeekOfYear, CDate(item.SubItems(10).Text))

            If CDate(item.SubItems(10).Text) < Now.Date Or semanaPrevista = semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                sumaEstaSemana = sumaEstaSemana + 1
            ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                sumaSemanaProxima = sumaSemanaProxima + 1
            ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                suma2Semanas = suma2Semanas + 1
            Else
                sumaMasSemanas = sumaMasSemanas + 1
            End If
        Next
        EstaSemana.Text = sumaEstaSemana
        SemanaProxima.Text = sumaSemanaProxima
        En2Semanas.Text = suma2Semanas
        EnMasSemanas.Text = sumaMasSemanas
        Total.Text = suma
    End Sub

    Private Sub CalculaTotalE()
        Dim suma As Double = 0
        Dim sumaEstaSemana As Double = 0
        Dim sumaSemanaProxima As Double = 0
        Dim suma2Semanas As Double = 0
        Dim sumaMasSemanas As Double = 0
        'Dim semanaActual As Byte = DatePart(DateInterval.WeekOfYear, Now.Date)
        Dim semanaPrevista As Byte = 0
        For Each item As ListViewItem In lvElectronica.Items
            suma = suma + 1
            semanaPrevista = DatePart(DateInterval.WeekOfYear, CDate(item.SubItems(8).Text))

            If CDate(item.SubItems(8).Text) < Now.Date Or semanaPrevista = semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                sumaEstaSemana = sumaEstaSemana + 1
            ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                sumaSemanaProxima = sumaSemanaProxima + 1
            ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                suma2Semanas = suma2Semanas + 1
            Else
                sumaMasSemanas = sumaMasSemanas + 1
            End If
        Next
        EstaSemanaE.Text = sumaEstaSemana
        SemanaProximaE.Text = sumaSemanaProxima
        En2SemanasE.Text = suma2Semanas
        EnMasSemanasE.Text = sumaMasSemanas
        TotalE.Text = suma
    End Sub


    Private Sub CalculaTotalT()
        Dim suma As Double = 0
        Dim sumaEstaSemana As Double = 0
        Dim sumaSemanaProxima As Double = 0
        Dim suma2Semanas As Double = 0
        Dim sumaMasSemanas As Double = 0
        'Dim semanaActual As Byte = DatePart(DateInterval.WeekOfYear, Now.Date)
        Dim semanaPrevista As Byte = 0
        For Each item As ListViewItem In lvTaller.Items
            suma = suma + 1
            semanaPrevista = DatePart(DateInterval.WeekOfYear, CDate(item.SubItems(8).Text))

            If CDate(item.SubItems(8).Text) < Now.Date Or semanaPrevista = semanaActual Or (semanaActual = 53 And semanaPrevista = 1) Then
                sumaEstaSemana = sumaEstaSemana + 1
            ElseIf semanaPrevista = semanaActual + 1 Or (semanaActual = 52 And semanaPrevista = 1) Then
                sumaSemanaProxima = sumaSemanaProxima + 1
            ElseIf semanaPrevista = semanaActual + 2 Or (semanaActual = 51 And semanaPrevista = 1) Then
                suma2Semanas = suma2Semanas + 1
            Else
                sumaMasSemanas = sumaMasSemanas + 1
            End If
        Next
        EstaSemanaT.Text = sumaEstaSemana
        SemanaProximaT.Text = sumaSemanaProxima
        En2SemanasT.Text = suma2Semanas
        EnMasSemanasT.Text = sumaMasSemanas
        TotalT.Text = suma
    End Sub


#End Region




#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub bAcabados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAcabadoElectronica.Click, bAcabadoTaller.Click
        'Utilizamos la misma subrutina para los dos botones, distinguiendo uno de otro por el sender.Name

        Dim validar As Boolean = True
        Dim contador As Integer = 0
        'Dim AcabadosAntes As Double = 0
        Dim AcabadosAhora As Double = 0
        Dim AlgunoEspera As Boolean
        listaidProduccion = New List(Of Long)
        listanumPedido = New List(Of Integer)
        'Dim listaCantidadAnterior As New List(Of Double)
        'Dim iidEstado As Integer
        If validar Then
            Cambios = True
            Select Case TabControl1.SelectedTab.Name
                Case tpElectronica.Name
                    For Each item As ListViewItem In lvElectronica.CheckedItems 'Detectamos equipos ya acabados y si están marcados los desmarcamos
                        If item.ForeColor = Color.Green Then
                            item.Checked = False
                            contador = contador + 1
                        End If
                    Next
                    If contador > 0 Then MsgBox("Se han deseleccionado " & contador & " equipos ya acabados")
                    If lvElectronica.CheckedItems.Count = 0 Then
                        validar = False
                        If contador = 0 Then MsgBox("No hay equipos seleccionados")
                    End If
                    If sender.name = "bAcabadoElectronica" Then
                        For Each item As ListViewItem In lvElectronica.CheckedItems

                            item.SubItems(5).Text = EstadoCompleto.gEstado
                            item.SubItems(13).Text = EstadoCompleto.gidEstado
                            item.ForeColor = Color.Green
                            listaElectronica(item.Index).gEstadoElectronica = EstadoCompleto.gEstado
                            listaElectronica(item.Index).gidEstadoElectronica = EstadoCompleto.gidEstado
                        Next

                        For Each item As ListViewItem In lvElectronica.CheckedItems
                            item.Checked = False
                            iidEquipo = item.SubItems(2).Text
                            'Ahora hay que comprobar el estado de los componentes de ELECTRONICA, puede haber alguno acabado y otro no
                            AlgunoEspera = False
                            For Each itemint As ListViewItem In lvElectronica.Items
                                If itemint.Index <> item.Index And CInt(itemint.SubItems(2).Text) = iidEquipo Then
                                    If itemint.SubItems(13).Text = EstadoEspera.gidEstado Then
                                        AlgunoEspera = True
                                    End If
                                End If
                            Next

                            'Hemos de actualizar el lv global
                            'Si hay alguno en ESPERA, el estado de Electrónica del equipo será EN CURSO, si no es que están todos acabados
                            Dim itemE As ListViewItem = lvEquipos.Items(0)
                            Dim i As Integer = 0
                            While itemE.SubItems(1).Text <> iidEquipo And i < lvEquipos.Items.Count - 1 'Encontrar el equipo concreto en el lvGlobal
                                i = i + 1
                                itemE = lvEquipos.Items(i)
                            End While
                            If itemE.SubItems(1).Text = iidEquipo Then
                                If AlgunoEspera Then
                                    itemE.SubItems(6).Text = EstadoEnCurso.gEstado
                                    itemE.SubItems(16).Text = EstadoEnCurso.gidEstado
                                    listaEP(itemE.Index).gEstadoElectronica = EstadoEnCurso.gEstado
                                    listaEP(itemE.Index).gidEstadoElectronica = EstadoEnCurso.gidEstado
                                Else
                                    itemE.SubItems(6).Text = EstadoCompleto.gEstado
                                    itemE.SubItems(16).Text = EstadoCompleto.gidEstado
                                    listaEP(itemE.Index).gEstadoElectronica = EstadoCompleto.gEstado
                                    listaEP(itemE.Index).gidEstadoElectronica = EstadoCompleto.gidEstado
                                End If
                                Call estadoGlobal(itemE)
                                'Guardamos, si no se ha guardado ya, el idPRoducción  como candidato a cambiar de estado
                                If Not listaidProduccion.Contains(listaEP(itemE.Index).gidProduccion) Then
                                    listaidProduccion.Add(listaEP(itemE.Index).gidProduccion)
                                End If
                            End If
                            'Hemos de actualizar los colores el lvTaller
                            For Each itemT As ListViewItem In lvTaller.Items
                                If itemT.SubItems(2).Text = iidEquipo Then
                                    'Si encontramos el mismo id Equipo en lvTaller sin acabar, lo coloreamos Naranja
                                    If itemT.ForeColor <> Color.Green Then
                                        itemT.ForeColor = Color.Orange
                                        'itemT.Font = New Font(itemT.Font, FontStyle.Bold)
                                    End If

                                End If
                            Next

                        Next
                    End If

                Case tpTaller.Name
                    For Each item As ListViewItem In lvTaller.CheckedItems 'Detectamos equipos ya acabados y si están marcados los desmarcamos
                        If item.ForeColor = Color.Green Then
                            item.Checked = False
                            contador = contador + 1
                        End If
                    Next
                    If contador > 0 Then MsgBox("Se han deseleccionado " & contador & " equipos ya acabados")
                    If lvTaller.CheckedItems.Count = 0 Then
                        validar = False
                        If contador = 0 Then MsgBox("No hay equipos seleccionados")
                    End If

                    If sender.name = "bAcabadoTaller" Then
                        For Each item As ListViewItem In lvTaller.CheckedItems

                            item.SubItems(5).Text = EstadoCompleto.gEstado
                            item.SubItems(13).Text = EstadoCompleto.gidEstado
                            item.ForeColor = Color.Green
                            listaTaller(item.Index).gEstadoTaller = EstadoCompleto.gEstado
                            listaTaller(item.Index).gidEstadoTaller = EstadoCompleto.gidEstado
                        Next

                        For Each item As ListViewItem In lvTaller.CheckedItems
                            item.Checked = False
                            'item.Font = New Font(item.Font, FontStyle.Bold)
                            iidEquipo = item.SubItems(2).Text
                            'Ahora hay que comprobar el estado de los componentes de TALLER, puede haber alguno acabado y otro no
                            AlgunoEspera = False
                            For Each itemint As ListViewItem In lvTaller.Items
                                If itemint.Index <> item.Index And CInt(itemint.SubItems(2).Text) = iidEquipo Then
                                    Dim kk As Integer = itemint.SubItems(13).Text
                                    If itemint.SubItems(13).Text = EstadoEspera.gidEstado Or itemint.SubItems(13).Text = EstadoEnCurso.gidEstado Then
                                        AlgunoEspera = True
                                    End If
                                End If
                            Next
                            'Si hay alguno en ESPERA, el estado de Taller del equipo será EN CURSO, si no es que están todos acabados

                            'Hemos de actualizar el lv global
                            Dim itemE As ListViewItem = lvEquipos.Items(0)
                            Dim i As Integer = 0
                            While itemE.SubItems(1).Text <> iidEquipo And i < lvEquipos.Items.Count - 1 'Encontrar el equipo concreto en el lvGlobal
                                i = i + 1
                                itemE = lvEquipos.Items(i)
                            End While
                            If itemE.SubItems(1).Text = iidEquipo Then
                                If AlgunoEspera Then
                                    itemE.SubItems(5).Text = EstadoEnCurso.gEstado
                                    itemE.SubItems(15).Text = EstadoEnCurso.gidEstado
                                    listaEP(itemE.Index).gEstadoTaller = EstadoEnCurso.gEstado
                                    listaEP(itemE.Index).gidEstadoTaller = EstadoEnCurso.gidEstado
                                Else
                                    itemE.SubItems(5).Text = EstadoCompleto.gEstado
                                    itemE.SubItems(15).Text = EstadoCompleto.gidEstado
                                    listaEP(itemE.Index).gEstadoTaller = EstadoCompleto.gEstado
                                    listaEP(itemE.Index).gidEstadoTaller = EstadoCompleto.gidEstado
                                End If
                                Call estadoGlobal(itemE)
                                'Guardamos, si no se ha guardado ya, el idPRoducción  como candidato a cambiar de estado
                                If Not listaidProduccion.Contains(listaEP(itemE.Index).gidProduccion) Then
                                    listaidProduccion.Add(listaEP(itemE.Index).gidProduccion)
                                End If
                            End If
                            'Hemos de actualizar los colores el lvElectronica
                            For Each itemL As ListViewItem In lvElectronica.Items
                                If itemL.SubItems(2).Text = iidEquipo Then
                                    'Si encontramos el mismo id Equipo en lvTaller sin acabar, lo coloreamos Naranja
                                    If itemL.ForeColor <> Color.Green Then
                                        itemL.ForeColor = Color.Orange
                                        'itemL.Font = New Font(itemL.Font, FontStyle.Bold)
                                    End If

                                End If
                            Next

                        Next
                    End If


                Case tpGlobal.Name
                    For Each item As ListViewItem In lvEquipos.CheckedItems 'Detectamos equipos ya acabados y si están marcados los desmarcamos
                        If item.ForeColor = Color.Green Then
                            item.Checked = False
                            contador = contador + 1
                        End If
                    Next
                    If contador > 0 Then MsgBox("Se han deseleccionado " & contador & " equipos ya acabados")
                    If lvEquipos.CheckedItems.Count = 0 Then
                        validar = False
                        If contador = 0 Then MsgBox("No hay equipos seleccionados")
                    End If

                    For Each item As ListViewItem In lvEquipos.CheckedItems
                        If sender.name = "bAcabadoElectronica" Then
                            item.SubItems(6).Text = EstadoCompleto.gEstado
                            item.SubItems(16).Text = EstadoCompleto.gidEstado
                            listaEP(item.Index).gEstadoElectronica = EstadoCompleto.gEstado
                            listaEP(item.Index).gidEstadoElectronica = EstadoCompleto.gidEstado
                            iidEquipo = item.SubItems(1).Text
                            'Hemos de actualizar el lv Electronica
                            For Each itemL As ListViewItem In lvElectronica.Items
                                If itemL.SubItems(2).Text = iidEquipo Then
                                    itemL.SubItems(5).Text = EstadoCompleto.gEstado
                                    itemL.SubItems(13).Text = EstadoCompleto.gidEstado
                                    itemL.ForeColor = Color.Green
                                    listaElectronica(itemL.Index).gEstadoElectronica = EstadoCompleto.gEstado
                                    listaElectronica(itemL.Index).gidEstadoElectronica = EstadoCompleto.gidEstado
                                    'itemL.Font = New Font(itemL.Font, FontStyle.Bold)
                                End If
                            Next
                            'Y actualzar colores en lvTaller
                            For Each itemT As ListViewItem In lvTaller.Items
                                If itemT.SubItems(2).Text = iidEquipo Then
                                    If itemT.ForeColor <> Color.Green Then
                                        itemT.ForeColor = Color.Orange
                                        'itemT.Font = New Font(itemT.Font, FontStyle.Bold)
                                    End If

                                End If
                            Next
                            If Not listaidProduccion.Contains(listaEP(item.Index).gidProduccion) Then
                                listaidProduccion.Add(listaEP(item.Index).gidProduccion)
                            End If

                        End If

                        If sender.name = "bAcabadoTaller" Then
                            item.SubItems(5).Text = EstadoCompleto.gEstado
                            item.SubItems(15).Text = EstadoCompleto.gidEstado
                            listaEP(item.Index).gEstadoTaller = EstadoCompleto.gEstado
                            listaEP(item.Index).gidEstadoTaller = EstadoCompleto.gidEstado
                            iidEquipo = item.SubItems(1).Text

                            'Hemos de actualizar el lv Taller
                            For Each itemT As ListViewItem In lvTaller.Items
                                If itemT.SubItems(2).Text = iidEquipo Then
                                    itemT.SubItems(5).Text = EstadoCompleto.gEstado
                                    itemT.SubItems(13).Text = EstadoCompleto.gidEstado
                                    listaTaller(itemT.Index).gEstadoElectronica = EstadoCompleto.gEstado
                                    listaTaller(itemT.Index).gidEstadoElectronica = EstadoCompleto.gidEstado
                                    itemT.ForeColor = Color.Green
                                    'itemT.Font = New Font(itemT.Font, FontStyle.Bold)
                                End If
                            Next
                            'Y actualzar colores en lvElectronica
                            For Each itemL As ListViewItem In lvElectronica.Items
                                If itemL.SubItems(2).Text = iidEquipo Then
                                    If itemL.ForeColor <> Color.Green Then
                                        itemL.ForeColor = Color.Orange
                                        'itemL.Font = New Font(itemL.Font, FontStyle.Bold)
                                    End If

                                End If
                            Next
                            If Not listaidProduccion.Contains(listaEP(item.Index).gidProduccion) Then
                                listaidProduccion.Add(listaEP(item.Index).gidProduccion)
                            End If

                            'If lvTaller.Items.Count > 0 Then
                            '    Dim itemT As ListViewItem = lvTaller.Items(0)
                            '    Dim i As Integer = 0
                            '    While itemT.SubItems(2).Text <> item.SubItems(1).Text And i < lvTaller.Items.Count - 1
                            '        i = i + 1
                            '        itemT = lvTaller.Items(i)
                            '    End While
                            '    If item.SubItems(1).Text = itemT.SubItems(2).Text Then
                            '        itemT.SubItems(5).Text = item.SubItems(5).Text
                            '        If itemT.SubItems(5).Text = EstadoCompleto.gEstado Then
                            '            itemT.ForeColor = Color.Green
                            '        Else
                            '            itemT.ForeColor = Color.Black
                            '        End If
                            '    End If
                            'End If

                        End If
                        Call estadoGlobal(item)
                    Next

            End Select


        End If
    End Sub

    Public Sub estadoGlobal(ByVal item As ListViewItem)
        'Calculamos el estado general del equipo a partir del estado de taller y el de electrónica
        'Detectamos los Acabados ahora
        'Coloreamos en consecuencia
        Dim iidEstadoE As Integer = item.SubItems(16).Text
        Dim iidEstadoT As Integer = item.SubItems(15).Text
        If iidEstadoE = EstadoAnulado.gidEstado And iidEstadoT = EstadoCompleto.gidEstado Then  'Solo TALLER
            If item.ForeColor <> Color.Green Then AcabadosAhora = AcabadosAhora + 1 'Si antes no estaba acabado y ahora si
            item.SubItems(14).Text = EstadoCompleto.gidEstado
            listaEP(item.Index).gidEstado = EstadoCompleto.gidEstado
            item.ForeColor = Color.Green
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoCompleto.gidEstado And iidEstadoT = EstadoAnulado.gidEstado Then 'Solo Electronica
            If item.ForeColor <> Color.Green Then AcabadosAhora = AcabadosAhora + 1 'Si antes no estaba acabado y ahora si
            item.SubItems(14).Text = EstadoCompleto.gidEstado
            listaEP(item.Index).gidEstado = EstadoCompleto.gidEstado
            item.ForeColor = Color.Green
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoCompleto.gidEstado And iidEstadoT = EstadoCompleto.gidEstado Then 'Todo acabado
            If item.ForeColor <> Color.Green Then AcabadosAhora = AcabadosAhora + 1 'Si antes no estaba acabado y ahora si
            item.SubItems(14).Text = EstadoCompleto.gidEstado
            listaEP(item.Index).gidEstado = EstadoCompleto.gidEstado
            item.ForeColor = Color.Green
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoCompleto.gidEstado And iidEstadoT = EstadoEspera.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            listaEP(item.Index).gidEstado = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoEnCurso.gidEstado And iidEstadoT = EstadoEspera.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            listaEP(item.Index).gidEstado = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoEspera.gidEstado And iidEstadoT = EstadoCompleto.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            listaEP(item.Index).gidEstado = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            ' item.Font = New Font(item.Font, FontStyle.Bold)
        End If

        If iidEstadoE = EstadoEspera.gidEstado And iidEstadoT = EstadoEnCurso.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            listaEP(item.Index).gidEstado = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            ' item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoEspera.gidEstado And iidEstadoT = EstadoEspera.gidEstado Then 'Todo en espera
            item.SubItems(14).Text = EstadoEspera.gidEstado
            listaEP(item.Index).gidEstado = EstadoEspera.gidEstado
            item.ForeColor = Color.Black
        End If
        If iidEstadoE = EstadoAnulado.gidEstado And iidEstadoT = EstadoAnulado.gidEstado Then 'Todo anulado
            item.SubItems(14).Text = EstadoAnulado.gidEstado
            listaEP(item.Index).gidEstado = EstadoAnulado.gidEstado
            item.ForeColor = Color.Gray

        End If

    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        'Guardar los cambios aplicados
        If MsgBox("¿Guardar los cambios realizados?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim iidEquipo As Integer
            Dim iidEstado As Integer
            Dim iidEstadoAnterior As Integer
            For Each item As ListViewItem In lvEquipos.Items
                iidEquipo = item.SubItems(1).Text
                funcEP.CambiarEstadoTaller(iidEquipo, item.SubItems(15).Text)
                funcEP.CambiarEstadoElectronica(iidEquipo, item.SubItems(16).Text)
                If funcEP.idEstado(iidEquipo) <> EstadoCompleto.gidEstado And item.SubItems(14).Text = EstadoCompleto.gidEstado Then
                    'Si el estado anterior no era completo y ahora si, ponemos la fecha fin
                    funcEP.CambiarFechaFin(iidEquipo, Now)
                End If
                funcEP.CambiarEstado(iidEquipo, item.SubItems(14).Text)
                item.Checked = False
            Next

            Dim iidConcepto As Long
            'Ahora cambiamos el estado de las partes separadas que están en ConceptosEquiposProduccion
            'De taller
            For Each item As ListViewItem In lvTaller.Items
                iidConcepto = item.SubItems(1).Text
                iidEstadoAnterior = funcCE.idEstadoTaller(iidConcepto)
                iidEstado = item.SubItems(13).Text
                If iidEstado <> iidEstadoAnterior Then
                    funcCE.CambiarEstadoTaller(iidConcepto, iidEstado)
                    If iidEstado = EstadoCompleto.gidEstado Then
                        funcCE.Finalizar(iidConcepto) 'Marcaremos el concepto de equipo como finalizado (se guardará quien y cuando)
                    End If
                End If
                item.Checked = False
            Next
            'Y de Electronica
            For Each item As ListViewItem In lvElectronica.Items
                iidConcepto = item.SubItems(1).Text
                iidEstadoAnterior = funcCE.idEstadoElectronica(iidConcepto)
                iidEstado = item.SubItems(13).Text
                If iidEstado <> iidEstadoAnterior Then
                    funcCE.CambiarEstadoElectronica(iidConcepto, iidEstado)
                    If iidEstado = EstadoCompleto.gidEstado Then
                        funcCE.Finalizar(iidConcepto) 'Marcaremos el concepto de equipo como finalizado (se guardará quien y cuando)
                    End If
                End If
                item.Checked = False
            Next

            'Ahora propagaremos el cambio de estado Conceptos de Producción y Conceptos de Pedido
            'Para ello hay que verificar si están acabados todos los del concepto
            Dim dtsCR As DatosConceptoProduccion
            Dim iidEstadoEnCursoPR As Integer = funcES.EstadoEnCurso("PRODUCCION").gidEstado
            Dim iidEstadoCompletoPR As Integer = funcES.EstadoCompleto("PRODUCCION").gidEstado
            Dim iidEstadoEnCursoCP As Integer = funcES.EstadoCPedido("EN PRODUCCION").gidEstado
            Dim iidEstadoCompletoCP As Integer = funcES.EstadoCPedido("PRODUCIDO").gidEstado
            Dim iidEstadoEnCursoPE As Integer = funcES.EstadoPedido("PRODUCCION").gidEstado
            Dim iidEstadoProducidoPE As Integer = funcES.EstadoPedido("PRODUCIDO").gidEstado
            Dim iidEstadoParcialPR As Integer = funcES.EstadoAutomatico("PRODUCCION").gidEstado

            'Dim dtsSK As DatosStock
            'Dim dtsAR As DatosArticulo
            If Not listaidProduccion Is Nothing Then
                For Each iid As Long In listaidProduccion
                    dtsCR = funcCR.Mostrar1(iid)
                    If dtsCR.gAcabados >= dtsCR.gCantidad Then
                        funcCR.CambiarEstado(iid, iidEstadoCompletoPR)
                    Else
                        If dtsCR.gidEstado = iidEstadoParcialPR Then 'Si el concepto de producción está en estado parcial, lo dejamos
                        Else
                            funcCR.CambiarEstado(iid, iidEstadoEnCursoPR)
                        End If
                    End If
                    If dtsCR.gidConceptoPedido > 0 Then
                        If funcCP.Cantidad(dtsCR.gidConceptoPedido) <= dtsCR.gAcabados Then
                            funcCP.CambiarEstado(dtsCR.gidConceptoPedido, iidEstadoCompletoCP)
                        Else
                            funcCP.CambiarEstado(dtsCR.gidConceptoPedido, iidEstadoEnCursoCP)
                        End If
                        'Creamos una lista de pedidos afectados
                        If Not listanumPedido.Contains(dtsCR.gnumPedido) Then listanumPedido.Add(dtsCR.gnumPedido)
                    End If
                    'Pasar los equipos acabados al stock
                    'Esto no toca hacerlo aquí sino en Gestión Logística
                    'If AcabadosAhora > 0 Then
                    '    dtsSK = New DatosStock
                    '    dtsSK.gidArticulo = dtsCR.gidArticulo
                    '    dtsSK.gidAlmacen = 0
                    '    dtsSK.gCantidad = AcabadosAhora
                    '    dtsSK.gidUnidad = dtsCR.gidUnidad
                    '    dtsSK.gMovimiento = ""
                    '    dtsSK.gidProduccion = dtsCR.gidProduccion
                    '    dtsSK.gidConceptoAlbaran = 0
                    '    dtsSK.gidConceptoProv = 0
                    '    dtsSK.gidLote = 0
                    '    dtsSK.gidPersona1 = Inicio.vIdUsuario
                    '    dtsSK.gPersona2 = 0
                    '    dtsAR = funcAR.Mostrar1(dtsCR.gidArticulo)
                    '    dtsSK.gPrecio = dtsAR.gPrecioUnitarioC
                    '    dtsSK.gcodMoneda = dtsAR.gcodMonedaC
                    '    dtsSK.gidArticuloProv = 0
                    '    dtsSK.gFecha = Now
                    '    funcSK.insertar(dtsSK)
                    'End If
                Next
            End If
            'Por último actualizamos el estado de los pedidos 
            If Not listanumPedido Is Nothing Then
                For Each np As Integer In listanumPedido
                    If funcCP.TodosCompletos(np) Then
                        funcPE.actualizaEstado(np, iidEstadoProducidoPE)
                    Else
                        funcPE.actualizaEstado(np, iidEstadoEnCursoPE)
                    End If
                Next
            End If

            'For Each item As ListViewItem In lvElectronica.Items
            '    item.Checked = False
            'Next
            'For Each item As ListViewItem In lvTaller.Items
            '    item.Checked = False
            'Next
            MsgBox("Cambios guardados correctamente.")
            Cambios = False
            'Call cargarLV()
            'Call cargarLVSeparados()
        End If



    End Sub


    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiarEdicion()
    End Sub

#End Region


#Region "EVENTOS"



    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvEquipos.Items
                item.Checked = ckSeleccion.Checked
            Next
            If ckSeleccion.CheckState = CheckState.Checked Then
                lbSeleccionados.Text = lvEquipos.Items.Count & " SELECCIONADOS"
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
        End If
    End Sub

    Private Sub ckSeleccionTaller_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccionTaller.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccionTaller.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvTaller.Items
                item.Checked = ckSeleccionTaller.Checked
            Next
            If ckSeleccionTaller.CheckState = CheckState.Checked Then
                lbSeleccionados.Text = lvTaller.Items.Count & " SELECCIONADOS"
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
        End If
    End Sub

    Private Sub ckSeleccionElectronica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccionElectronica.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccionElectronica.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvElectronica.Items
                item.Checked = ckSeleccionElectronica.Checked
            Next
            If ckSeleccionElectronica.CheckState = CheckState.Checked Then
                lbSeleccionados.Text = lvElectronica.Items.Count & " SELECCIONADOS"
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
        End If
    End Sub

    Private Sub lvEquipos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEquipos.Click
        If lvEquipos.SelectedItems.Count > 0 Then
            indice = lvEquipos.SelectedIndices(0)
            iidEquipo = lvEquipos.Items(indice).SubItems(1).Text
            Dim dts As DatosEquipoProduccion = funcEP.Mostrar1(iidEquipo)
            lbArticulo.Text = "ARTICULO"
            codArticulo.Text = dts.gcodArticulo
            Articulo.Text = dts.gArticulo
            Observaciones.Text = dts.gObservaciones
            'numSerie.Text = dts.gnumSerie
        End If

    End Sub


    Private Sub lvEquipos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvEquipos.ItemChecked
        'Al checkar una linea,cambiamos el estado de ckseleccion 
        If semaforo Then
            semaforo = False
            If e.Item.Checked Then
                e.Item.Selected = True
            Else
                e.Item.Selected = False
            End If
            semaforo = True
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


    Private Sub lvElectronica_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvElectronica.ItemChecked
        'Al checkar una linea,cambiamos el estado de ckseleccion 
        If semaforo Then
            semaforo = False
            If e.Item.Checked Then
                e.Item.Selected = True
            Else
                e.Item.Selected = False
            End If
            semaforo = True
            Dim cont As Integer = lvElectronica.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccionElectronica.CheckState = CheckState.Unchecked
            ElseIf cont = lvElectronica.Items.Count Then
                ckSeleccionElectronica.CheckState = CheckState.Checked
            Else
                ckSeleccionElectronica.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub


    Private Sub lvTaller_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvTaller.ItemChecked
        'Al checkar una linea,cambiamos el estado de ckseleccion 
        If semaforo Then
            semaforo = False
            If e.Item.Checked Then
                e.Item.Selected = True
            Else
                e.Item.Selected = False
            End If
            semaforo = True
            Dim cont As Integer = lvTaller.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccionTaller.CheckState = CheckState.Unchecked
            ElseIf cont = lvTaller.Items.Count Then
                ckSeleccionTaller.CheckState = CheckState.Checked
            Else
                ckSeleccionTaller.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub






    'Private Sub lvEquipos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEquipos.ColumnClick
    '    ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
    '    If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
    '        If (lvwColumnSorter.Order = SortOrder.Ascending) Then
    '            lvwColumnSorter.Order = SortOrder.Descending
    '        Else
    '            lvwColumnSorter.Order = SortOrder.Ascending
    '        End If
    '    Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
    '        lvwColumnSorter.SortColumn = e.Column

    '        lvwColumnSorter.Order = SortOrder.Ascending
    '    End If
    '    ' Realizar la ordenación con estas nuevas opciones de ordenación. 
    '    lvEquipos.Sort()
    'End Sub


    Private Sub lvEquipos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEquipos.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = ColumnaEquipos) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If DireccionEquipos = "ASC" Then
                DireccionEquipos = "DESC"
            Else
                DireccionEquipos = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            ColumnaEquipos = e.Column

            DireccionEquipos = "ASC"
        End If
        Select Case e.Column
            Case 1
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gidEquipo.CompareTo(y.gidEquipo))
                Else
                    listaEP.Sort(Function(x, y) y.gidEquipo.CompareTo(x.gidEquipo))
                End If
            Case 2
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gnumSerie.CompareTo(y.gnumSerie))
                Else
                    listaEP.Sort(Function(x, y) y.gnumSerie.CompareTo(x.gnumSerie))
                End If
            Case 3
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gcodArticulo.CompareTo(y.gcodArticulo))
                Else
                    listaEP.Sort(Function(x, y) y.gcodArticulo.CompareTo(x.gcodArticulo))
                End If
            Case 4
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gArticulo.CompareTo(y.gArticulo))
                Else
                    listaEP.Sort(Function(x, y) y.gArticulo.CompareTo(x.gArticulo))
                End If
            Case 5
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gEstadoTaller.CompareTo(y.gEstadoTaller))
                Else
                    listaEP.Sort(Function(x, y) y.gEstadoTaller.CompareTo(x.gEstadoTaller))
                End If
            Case 6
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gEstadoElectronica.CompareTo(y.gEstadoElectronica))
                Else
                    listaEP.Sort(Function(x, y) y.gEstadoElectronica.CompareTo(x.gEstadoElectronica))
                End If
            Case 7
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gCliente.CompareTo(y.gCliente))
                Else
                    listaEP.Sort(Function(x, y) y.gCliente.CompareTo(x.gCliente))
                End If
            Case 8
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gnumPedido.CompareTo(y.gnumPedido))
                Else
                    listaEP.Sort(Function(x, y) y.gnumPedido.CompareTo(x.gnumPedido))
                End If
            Case 9
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gFechaPedido.CompareTo(y.gFechaPedido))
                Else
                    listaEP.Sort(Function(x, y) y.gFechaPedido.CompareTo(x.gFechaPedido))
                End If
            Case 10
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gFechaPrevista.CompareTo(y.gFechaPrevista))
                Else
                    listaEP.Sort(Function(x, y) y.gFechaPrevista.CompareTo(x.gFechaPrevista))
                End If
            Case 11
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gFechaPrevista.CompareTo(y.gFechaPrevista))
                Else
                    listaEP.Sort(Function(x, y) y.gFechaPrevista.CompareTo(x.gFechaPrevista))
                End If
            Case 12
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gPrioridad.CompareTo(y.gPrioridad))
                Else
                    listaEP.Sort(Function(x, y) y.gPrioridad.CompareTo(x.gPrioridad))
                End If

            Case 13
                If DireccionEquipos = "ASC" Then
                    listaEP.Sort(Function(x, y) x.gEtiqueta.CompareTo(y.gEtiqueta))
                Else
                    listaEP.Sort(Function(x, y) y.gEtiqueta.CompareTo(x.gEtiqueta))
                End If

            Case Else
        End Select

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        PBCarga.Visible = 0
        PBCarga.Maximum = listaEP.Count
        Call cargarLV()

    End Sub





    Private Sub lvTaller_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvTaller.ColumnClick
        If (e.Column = ColumnaTaller) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If DireccionTaller = "ASC" Then
                DireccionTaller = "DESC"
            Else
                DireccionTaller = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            ColumnaTaller = e.Column

            DireccionTaller = "ASC"
        End If
        Select Case e.Column
            Case 2
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gidEquipo.CompareTo(y.gidEquipo))
                Else
                    listaTaller.Sort(Function(x, y) y.gidEquipo.CompareTo(x.gidEquipo))
                End If
            Case 3
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gcodArticulo.CompareTo(y.gcodArticulo))
                Else
                    listaTaller.Sort(Function(x, y) y.gcodArticulo.CompareTo(x.gcodArticulo))
                End If
            Case 4
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gArticulo.CompareTo(y.gArticulo))
                Else
                    listaTaller.Sort(Function(x, y) y.gArticulo.CompareTo(x.gArticulo))
                End If
            Case 5
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gEstadoTaller.CompareTo(y.gEstadoTaller))
                Else
                    listaTaller.Sort(Function(x, y) y.gEstadoTaller.CompareTo(x.gEstadoTaller))
                End If
            Case 6
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gcodCli.CompareTo(y.gcodCli))
                Else
                    listaTaller.Sort(Function(x, y) y.gcodCli.CompareTo(x.gcodCli))
                End If
            Case 7
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gnumPedido.CompareTo(y.gnumPedido))
                Else
                    listaTaller.Sort(Function(x, y) y.gnumPedido.CompareTo(x.gnumPedido))
                End If
            Case 8
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gFechaPedido.CompareTo(y.gFechaPedido))
                Else
                    listaTaller.Sort(Function(x, y) y.gFechaPedido.CompareTo(x.gFechaPedido))
                End If
            Case 9
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gFechaPrevista.CompareTo(y.gFechaPrevista))
                Else
                    listaTaller.Sort(Function(x, y) y.gFechaPrevista.CompareTo(x.gFechaPrevista))
                End If
            Case 10
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gFechaPrevista.CompareTo(y.gFechaPrevista))
                Else
                    listaTaller.Sort(Function(x, y) y.gFechaPrevista.CompareTo(x.gFechaPrevista))
                End If
            Case 11
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gPrioridad.CompareTo(y.gPrioridad))
                Else
                    listaTaller.Sort(Function(x, y) y.gPrioridad.CompareTo(x.gPrioridad))
                End If

            Case 12
                If DireccionTaller = "ASC" Then
                    listaTaller.Sort(Function(x, y) x.gEtiqueta.CompareTo(y.gEtiqueta))
                Else
                    listaTaller.Sort(Function(x, y) y.gEtiqueta.CompareTo(x.gEtiqueta))
                End If

            Case Else
        End Select

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        PBCarga.Value = 0
        PBCarga.Maximum = listaTaller.Count
        Call CargarLVTaller()

    End Sub


    Private Sub lvElectronica_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvElectronica.ColumnClick
        If (e.Column = ColumnaElectronica) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If DireccionElectronica = "ASC" Then
                DireccionElectronica = "DESC"
            Else
                DireccionElectronica = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            ColumnaElectronica = e.Column

            DireccionElectronica = "ASC"
        End If
        Select Case e.Column
            Case 2
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gidEquipo.CompareTo(y.gidEquipo))
                Else
                    listaElectronica.Sort(Function(x, y) y.gidEquipo.CompareTo(x.gidEquipo))
                End If
            Case 3
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gcodArticulo.CompareTo(y.gcodArticulo))
                Else
                    listaElectronica.Sort(Function(x, y) y.gcodArticulo.CompareTo(x.gcodArticulo))
                End If
            Case 4
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gArticulo.CompareTo(y.gArticulo))
                Else
                    listaElectronica.Sort(Function(x, y) y.gArticulo.CompareTo(x.gArticulo))
                End If
            Case 5
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gEstadoElectronica.CompareTo(y.gEstadoElectronica))
                Else
                    listaElectronica.Sort(Function(x, y) y.gEstadoElectronica.CompareTo(x.gEstadoElectronica))
                End If
            Case 6
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gcodCli.CompareTo(y.gcodCli))
                Else
                    listaElectronica.Sort(Function(x, y) y.gcodCli.CompareTo(x.gcodCli))
                End If
            Case 7
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gnumPedido.CompareTo(y.gnumPedido))
                Else
                    listaElectronica.Sort(Function(x, y) y.gnumPedido.CompareTo(x.gnumPedido))
                End If
            Case 8
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gFechaPedido.CompareTo(y.gFechaPedido))
                Else
                    listaElectronica.Sort(Function(x, y) y.gFechaPedido.CompareTo(x.gFechaPedido))
                End If
            Case 9
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gFechaPrevista.CompareTo(y.gFechaPrevista))
                Else
                    listaElectronica.Sort(Function(x, y) y.gFechaPrevista.CompareTo(x.gFechaPrevista))
                End If
            Case 10
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gFechaPrevista.CompareTo(y.gFechaPrevista))
                Else
                    listaElectronica.Sort(Function(x, y) y.gFechaPrevista.CompareTo(x.gFechaPrevista))
                End If
            Case 11
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gPrioridad.CompareTo(y.gPrioridad))
                Else
                    listaElectronica.Sort(Function(x, y) y.gPrioridad.CompareTo(x.gPrioridad))
                End If

            Case 12
                If DireccionElectronica = "ASC" Then
                    listaElectronica.Sort(Function(x, y) x.gEtiqueta.CompareTo(y.gEtiqueta))
                Else
                    listaElectronica.Sort(Function(x, y) y.gEtiqueta.CompareTo(x.gEtiqueta))
                End If

            Case Else
        End Select
        PBCarga.Value = 0
        PBCarga.Maximum = listaElectronica.Count
        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Call CargarLVElectronica()

    End Sub

    'Private Sub lvElectronica_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvElectronica.ColumnClick
    '    ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
    '    If (e.Column = lvwColumnSorterE.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
    '        If (lvwColumnSorterE.Order = SortOrder.Ascending) Then
    '            lvwColumnSorterE.Order = SortOrder.Descending
    '        Else
    '            lvwColumnSorterE.Order = SortOrder.Ascending
    '        End If
    '    Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
    '        lvwColumnSorterE.SortColumn = e.Column

    '        lvwColumnSorterE.Order = SortOrder.Ascending
    '    End If
    '    ' Realizar la ordenación con estas nuevas opciones de ordenación. 
    '    lvElectronica.Sort()
    'End Sub



    Private Sub lvEquipos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEquipos.DoubleClick
        'If lvEquipos.SelectedItems.Count > 0 Then
        '    iidEquipo = lvEquipos.SelectedItems(0).SubItems(1).Text
        '    Dim GG As New ProduccionSeparada
        '    GG.soloLectura = vsoloLectura
        '    GG.pidEquipo = iidEquipo

        '    GG.ShowDialog()
        'End If
    End Sub


    Private Sub tpElectronica_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpElectronica.Enter
        If semaforo Then
            semaforo = False
            bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
            bAcabadoTaller.Enabled = False
            If lvElectronica.CheckedItems.Count > 0 Then
                lbSeleccionados.Text = lvElectronica.SelectedIndices.Count & " SELECCIONADOS"
                lbSeleccionados.Visible = True
                For Each item As ListViewItem In lvElectronica.CheckedItems
                    item.Selected = True
                Next
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
        End If
    End Sub


    Private Sub tpTaller_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpTaller.Enter

        If semaforo Then
            semaforo = False
            bAcabadoElectronica.Enabled = False
            bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
            If lvTaller.CheckedItems.Count > 0 Then
                lbSeleccionados.Text = lvTaller.SelectedIndices.Count & " SELECCIONADOS"
                lbSeleccionados.Visible = True
                For Each item As ListViewItem In lvTaller.CheckedItems
                    item.Selected = True
                Next
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
        End If

    End Sub

    Private Sub tpGlobal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpGlobal.Enter
        If semaforo Then
            semaforo = False
            bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
            bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
            If lvEquipos.CheckedItems.Count > 0 Then
                lbSeleccionados.Text = lvEquipos.SelectedIndices.Count & " SELECCIONADOS"
                lbSeleccionados.Visible = True
                For Each item As ListViewItem In lvEquipos.SelectedItems
                    item.Selected = True
                Next
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
        End If
    End Sub

    Private Sub lvEquipos_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvEquipos.ItemSelectionChanged, lvElectronica.ItemSelectionChanged, lvTaller.ItemSelectionChanged
        If semaforo Then
            semaforo = False
            If e.Item.Selected Then
                e.Item.Checked = True
            Else
                e.Item.Checked = False
            End If
            semaforo = True
        End If
    End Sub




    Private Sub lvEquipos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEquipos.SelectedIndexChanged
        If lvEquipos.SelectedItems.Count > 0 Then
            lbSeleccionados.Text = lvEquipos.SelectedIndices.Count & " SELECCIONADOS"
            lbSeleccionados.Visible = True
        Else
            lbSeleccionados.Visible = False
        End If
    End Sub

    Private Sub lvTaller_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTaller.SelectedIndexChanged
        If lvTaller.SelectedItems.Count > 0 Then
            lbSeleccionados.Text = lvTaller.SelectedIndices.Count & " SELECCIONADOS"
            lbSeleccionados.Visible = True
        Else
            lbSeleccionados.Visible = False
        End If
    End Sub




    Private Sub lvElectronica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvElectronica.SelectedIndexChanged
        If lvElectronica.SelectedItems.Count > 0 Then
            lbSeleccionados.Text = lvElectronica.SelectedIndices.Count & " SELECCIONADOS"
            lbSeleccionados.Visible = True
        Else
            lbSeleccionados.Visible = False
        End If
    End Sub



#End Region



End Class