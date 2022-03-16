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
    Private funcMA As New FuncionesMovimientosEquiposAcabados
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
    'Private estadoAcabado As DatosEstado
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private columna As Byte
    Private Direccion As String
    Private Orden As String
    Private lvwColumnSorter As OrdenarLV
    Private lvwColumnSorterT As OrdenarLV
    Private lvwColumnSorterE As OrdenarLV
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
    Private listaEquiposAcabados As List(Of IDComboBox)
    Private Semaforo0 As Boolean = False
    Private CargaInicial As Boolean = True


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
            Semaforo0 = False
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

            'PBCarga.Visible = True


            Cambios = False
            Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
            Me.Height = desktopSize.Height - 50
            If desktopSize.Height < 1000 Then
                Me.Height = desktopSize.Height - 50
            Else
                Me.Height = 950
            End If
            semaforo = False
            semanaActual = DatePart(DateInterval.WeekOfYear, Now.Date)
            If semanaActual = 53 And DatePart(DateInterval.Weekday, Now.Date) < 7 Then semanaActual = 1
            EstadoAnulado = funcES.EstadoAnulado("EQUIPO")
            EstadoEnCurso = funcES.EstadoEnCurso("EQUIPO")
            EstadoEspera = funcES.EstadoEspera("EQUIPO")
            EstadoCompleto = funcES.EstadoCompleto("EQUIPO")
            ckSeleccion.Location = New Point(bAcabadoElectronica.Location.X + 6, bAcabadoElectronica.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
            ckSeleccion.Location = New Point(lvEquipos.Location.X + 6, lvEquipos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

            semaforo = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub GestionEquiposProduccion_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Call CargarListaDatos()
       
        PBCarga.Visible = True
        If Vista = "TALLER" Then
            PBCarga.Maximum = listaEP.Count * 2
            Call cargarLV()
            Call cargarLVTaller()
            TabControl1.SelectedTab = tpTaller
            bAcabadoElectronica.Enabled = False
            bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
        ElseIf Vista = "ELECTRÓNICA" Then
            PBCarga.Maximum = listaEP.Count * 2
            Call cargarLV()
            Call cargarLVElectronica()
            TabControl1.SelectedTab = tpElectronica
            bAcabadoTaller.Enabled = False
            bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
        Else
            PBCarga.Maximum = listaEP.Count
            Call cargarLV()
          
            TabControl1.SelectedTab = tpGlobal
            bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
            bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
        End If
        CargaInicial = False

        PBCarga.Visible = False
    End Sub

#Region "INICIALIZACIÓN"


    Private Sub limpiarEdicion()
        indice = -1
        Observaciones.Text = ""
        'numSerie.Text = ""
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
                listaEP = funcEP.Busqueda("E1.Entregado = 0 and EPE.Anulado = 0 and EP.idEstado <> " & EstadoCompleto.gidEstado & " AND CP.idArticulo = " & iidArticulo, " EP.idEquipo ASC ", 0)
               
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
                listaEP = funcEP.Busqueda(" EP.idEstado <> " & EstadoCompleto.gidEstado & " AND CP.idProduccion in (" & sIDsProduccion & ") ", "EP.idEquipo ASC ", 0)
             
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
            lvEquipos.Items.Clear()
            lvwColumnSorter = New OrdenarLV()
            lvEquipos.ListViewItemSorter = lvwColumnSorter
            For Each dts As DatosEquipoProduccion In listaEP
                PBCarga.Increment(1)
                With lvEquipos.Items.Add("")
                    semaforo = False
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
                    .SubItems.Add(False) 'Seleccionado
                    .SubItems.Add(If(dts.gConVersiones, CStr(dts.gVersion), ""))
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
            If Vista <> "TALLER" And Vista <> "ELECTRÓNICA" Then semaforo = True

            'Call CalculaTotal()
        End If
    End Sub

    Private Sub cargarLVTaller()
        If lvTaller.Items.Count = 0 Then
            If Not listaEP Is Nothing Then
                Try
                    semaforo = False
                    ckSeleccionTaller.Checked = False
                    lvTaller.Items.Clear()
                    lvwColumnSorterT = New OrdenarLV()
                    lvTaller.ListViewItemSorter = lvwColumnSorterT
                    For Each dts As DatosEquipoProduccion In listaEP
                        PBCarga.Increment(1)
                        Dim lista As List(Of DatosConceptoEquipoProduccion) = funcCE.Mostrar(dts.gidEquipo)
                        For Each dtsCE As DatosConceptoEquipoProduccion In lista
                            If dtsCE.gidEstadoTaller <> EstadoAnulado.gidEstado Then
                                semaforo = False
                                With lvTaller.Items.Add("")
                                    .SubItems.Add(dtsCE.gidConcepto)
                                    .SubItems.Add(dtsCE.gidEquipo)
                                    .SubItems.Add(dtsCE.gcodArticulo)
                                    .SubItems.Add(dtsCE.gArticulo)
                                    .SubItems.Add(dtsCE.gEstadoTaller)
                                    .SubItems.Add(dts.gcodCli)
                                    .SubItems.Add(If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido)))
                                    .SubItems.Add(dts.gFechaPedido)
                                    .SubItems.Add(dts.gFechaPrevista)
                                    .SubItems.Add(DiasPrevistos(dts.gFechaPrevista))
                                    .SubItems.Add(dts.gPrioridad)
                                    .SubItems.Add(dts.gEtiqueta)
                                    .SubItems.Add(dtsCE.gidEstadoTaller)
                                    .SubItems.Add(If(dts.gConVersiones, CStr(dtsCE.gVersion), ""))
                                    Select Case dtsCE.gidEstadoTaller
                                        Case EstadoAnulado.gidEstado
                                            .ForeColor = Color.Gray
                                        Case EstadoCompleto.gidEstado
                                            .ForeColor = Color.Green
                                            '.Font = New Font(.Font, FontStyle.Bold)
                                        Case EstadoEspera.gidEstado
                                            If dts.gidEstado = EstadoEnCurso.gidEstado Then
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

                            End If
                        Next

                    Next
                    semaforo = True
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub cargarLVElectronica()
        If lvElectronica.Items.Count = 0 Then
            If Not listaEP Is Nothing Then
                semaforo = False
                ckSeleccionElectronica.Checked = False
                lvElectronica.Items.Clear()
                lvwColumnSorterE = New OrdenarLV()
                lvElectronica.ListViewItemSorter = lvwColumnSorterE
                For Each dts As DatosEquipoProduccion In listaEP
                    PBCarga.Increment(1)
                    Dim lista As List(Of DatosConceptoEquipoProduccion) = funcCE.Mostrar(dts.gidEquipo)
                    For Each dtsCE As DatosConceptoEquipoProduccion In lista
                        If dtsCE.gidEstadoElectronica <> EstadoAnulado.gidEstado Then
                            With lvElectronica.Items.Add("")
                                semaforo = False
                                .SubItems.Add(dtsCE.gidConcepto)
                                .SubItems.Add(dtsCE.gidEquipo)
                                .SubItems.Add(dtsCE.gcodArticulo)
                                .SubItems.Add(dtsCE.gArticulo)
                                .SubItems.Add(dtsCE.gEstadoElectronica)
                                .SubItems.Add(dts.gcodCli)
                                .SubItems.Add(If(dts.gnumPedido = 0, "MANUAL", CStr(dts.gnumPedido)))
                                .SubItems.Add(dts.gFechaPedido)
                                .SubItems.Add(dts.gFechaPrevista)
                                .SubItems.Add(DiasPrevistos(dts.gFechaPrevista))
                                .SubItems.Add(dts.gPrioridad)
                                .SubItems.Add(dts.gEtiqueta)
                                .SubItems.Add(dtsCE.gidEstadoElectronica)
                                ' .SubItems.Add(False) 'Seleccionado
                                .SubItems.Add(If(dts.gConVersiones, CStr(dtsCE.gVersion), ""))
                                Select Case dtsCE.gidEstadoElectronica
                                    Case EstadoAnulado.gidEstado
                                        .ForeColor = Color.Gray
                                    Case EstadoCompleto.gidEstado
                                        .ForeColor = Color.Green
                                        '.Font = New Font(.Font, FontStyle.Bold)
                                    Case EstadoEspera.gidEstado
                                        If dts.gidEstado = EstadoEnCurso.gidEstado Then
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

                        End If

                    Next

                Next
                semaforo = True
            End If
        End If
    End Sub


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

        'Dim validar As Boolean = True
        Dim contador As Integer = 0
        Dim AcabadosAhora As Double = 0
        'Dim AlgunoEspera As Boolean
        listaidProduccion = New List(Of Long)
        listanumPedido = New List(Of Integer)
       
        Cambios = True
        Select Case TabControl1.SelectedTab.Name
            Case tpElectronica.Name
                Call AcabadosTabElectronica(sender.name)
            Case tpTaller.Name
                Call AcabadosTabTaller(sender.name)
            Case tpGlobal.Name
                Call AcabadosTabGlobal(sender.name)
        End Select

    End Sub


    Private Sub AcabadosTabTaller(ByVal BotonPulsado As String)
        Dim contador As Integer = 0
        Dim AcabadosAhora As Double = 0
        Dim AlgunoEspera As Boolean
        listaidProduccion = New List(Of Long)
        listanumPedido = New List(Of Integer)
        semaforo = False
        For Each item As ListViewItem In lvTaller.CheckedItems 'Detectamos equipos ya acabados y si están marcados los desmarcamos

            If item.ForeColor = Color.Green Then
                item.Checked = False
                contador = contador + 1
            End If

        Next
        If contador > 0 Then MsgBox("Se han deseleccionado " & contador & " equipos ya acabados")
        If lvTaller.CheckedItems.Count = 0 Then
            'validar = False
            If contador = 0 Then MsgBox("No hay equipos seleccionados")
        End If

        If BotonPulsado = "bAcabadoTaller" Then
            For Each item As ListViewItem In lvTaller.CheckedItems

                item.SubItems(5).Text = EstadoCompleto.gEstado
                item.SubItems(13).Text = EstadoCompleto.gidEstado
                item.ForeColor = Color.Green
            Next

            For Each item As ListViewItem In lvTaller.CheckedItems

                item.Checked = False
                'item.Font = New Font(item.Font, FontStyle.Bold)
                iidEquipo = item.SubItems(2).Text
                'Ahora hay que comprobar el estado de los componentes de TALLER, puede haber alguno acabado y otro no
                AlgunoEspera = False
                For Each itemint As ListViewItem In lvTaller.Items
                    If itemint.Index <> item.Index And CInt(itemint.SubItems(2).Text) = iidEquipo Then

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
                    Else
                        itemE.SubItems(5).Text = EstadoCompleto.gEstado
                        itemE.SubItems(15).Text = EstadoCompleto.gidEstado
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
        semaforo = True
        lvTaller.SelectedItems.Clear()
    End Sub

    Private Sub AcabadosTabElectronica(ByVal BotonPulsado As String)
        Dim contador As Integer = 0
        Dim AcabadosAhora As Double = 0
        Dim AlgunoEspera As Boolean
        listaidProduccion = New List(Of Long)
        listanumPedido = New List(Of Integer)
        semaforo = False
        For Each item As ListViewItem In lvElectronica.CheckedItems 'Detectamos equipos ya acabados y si están marcados los desmarcamos
            If item.ForeColor = Color.Green Then
                item.Checked = False
                contador = contador + 1
            End If
        Next
        If contador > 0 Then MsgBox("Se han deseleccionado " & contador & " equipos ya acabados")
        If lvElectronica.CheckedItems.Count = 0 Then
            'validar = False
            If contador = 0 Then MsgBox("No hay equipos seleccionados")
        End If
        If BotonPulsado = "bAcabadoElectronica" Then
            For Each item As ListViewItem In lvElectronica.CheckedItems

                item.SubItems(5).Text = EstadoCompleto.gEstado
                item.SubItems(13).Text = EstadoCompleto.gidEstado
                item.ForeColor = Color.Green
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
                    Else
                        itemE.SubItems(6).Text = EstadoCompleto.gEstado
                        itemE.SubItems(16).Text = EstadoCompleto.gidEstado
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
        semaforo = True
        lvElectronica.SelectedItems.Clear()
    End Sub

    Private Sub AcabadosTabGlobal(ByVal BotonPulsado As String)
        Dim contador As Integer = 0
        Dim AcabadosAhora As Double = 0
        'Dim AlgunoEspera As Boolean
        listaidProduccion = New List(Of Long)
        listanumPedido = New List(Of Integer)
        semaforo = False
        For Each item As ListViewItem In lvEquipos.CheckedItems 'Detectamos equipos ya acabados y si están marcados los desmarcamos
            If item.ForeColor = Color.Green Then
                item.Checked = False
                contador = contador + 1
            End If
        Next
        If contador > 0 Then MsgBox("Se han deseleccionado " & contador & " equipos ya acabados")
        If lvEquipos.CheckedItems.Count = 0 Then
            'validar = False
            If contador = 0 Then MsgBox("No hay equipos seleccionados")
        End If

        For Each item As ListViewItem In lvEquipos.CheckedItems
            If BotonPulsado = "bAcabadoElectronica" Then
                item.SubItems(6).Text = EstadoCompleto.gEstado
                item.SubItems(16).Text = EstadoCompleto.gidEstado
                iidEquipo = item.SubItems(1).Text
                'Hemos de actualizar el lv Electronica
                For Each itemL As ListViewItem In lvElectronica.Items
                    If itemL.SubItems(2).Text = iidEquipo Then
                        itemL.SubItems(5).Text = EstadoCompleto.gEstado
                        itemL.SubItems(13).Text = EstadoCompleto.gidEstado
                        itemL.ForeColor = Color.Green
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

            If BotonPulsado = "bAcabadoTaller" Then
                item.SubItems(5).Text = EstadoCompleto.gEstado
                item.SubItems(15).Text = EstadoCompleto.gidEstado
                iidEquipo = item.SubItems(1).Text

                'Hemos de actualizar el lv Taller
                For Each itemT As ListViewItem In lvTaller.Items
                    If itemT.SubItems(2).Text = iidEquipo Then
                        itemT.SubItems(5).Text = EstadoCompleto.gEstado
                        itemT.SubItems(13).Text = EstadoCompleto.gidEstado
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


            End If
            Call estadoGlobal(item)
        Next
        semaforo = True
        lvEquipos.SelectedItems.Clear()


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
            item.ForeColor = Color.Green
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoCompleto.gidEstado And iidEstadoT = EstadoAnulado.gidEstado Then 'Solo Electronica
            If item.ForeColor <> Color.Green Then AcabadosAhora = AcabadosAhora + 1 'Si antes no estaba acabado y ahora si
            item.SubItems(14).Text = EstadoCompleto.gidEstado
            item.ForeColor = Color.Green
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoCompleto.gidEstado And iidEstadoT = EstadoCompleto.gidEstado Then 'Todo acabado
            If item.ForeColor <> Color.Green Then AcabadosAhora = AcabadosAhora + 1 'Si antes no estaba acabado y ahora si
            item.SubItems(14).Text = EstadoCompleto.gidEstado
            item.ForeColor = Color.Green
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoCompleto.gidEstado And iidEstadoT = EstadoEspera.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoEnCurso.gidEstado And iidEstadoT = EstadoEspera.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            'item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoEspera.gidEstado And iidEstadoT = EstadoCompleto.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            ' item.Font = New Font(item.Font, FontStyle.Bold)
        End If

        If iidEstadoE = EstadoEspera.gidEstado And iidEstadoT = EstadoEnCurso.gidEstado Then
            item.SubItems(14).Text = EstadoEnCurso.gidEstado
            item.ForeColor = Color.Orange
            ' item.Font = New Font(item.Font, FontStyle.Bold)
        End If
        If iidEstadoE = EstadoEspera.gidEstado And iidEstadoT = EstadoEspera.gidEstado Then 'Todo en espera
            item.SubItems(14).Text = EstadoEspera.gidEstado
            item.ForeColor = Color.Black
        End If
        If iidEstadoE = EstadoAnulado.gidEstado And iidEstadoT = EstadoAnulado.gidEstado Then 'Todo anulado
            item.SubItems(14).Text = EstadoAnulado.gidEstado
            item.ForeColor = Color.Gray

        End If

    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        'Guardar los cambios aplicados
        listaEquiposAcabados = New List(Of IDComboBox)
        If MsgBox("¿Guardar los cambios realizados?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim iidEquipo As Integer
            Dim iidEstado As Integer
            Dim iidEstadoAnterior As Integer
            semaforo = False
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

            Dim iidArticulo As Integer
            Dim i As Integer = -1
            For Each item As ListViewItem In lvTaller.Items
                iidConcepto = item.SubItems(1).Text
                iidEstadoAnterior = funcCE.idEstadoTaller(iidConcepto)
                iidEstado = item.SubItems(13).Text
                If iidEstado <> iidEstadoAnterior Then
                    funcCE.CambiarEstadoTaller(iidConcepto, iidEstado)
                    If iidEstado = EstadoCompleto.gidEstado Then
                        funcCE.Finalizar(iidConcepto) 'Marcaremos el concepto de equipo como finalizado (se guardará quien y cuando)
                        iidArticulo = funcCE.idArticulo(iidConcepto)
                        i = ArticuloEn(iidArticulo)
                        'Cargar la lista de equiposAcabados
                        If i > -1 Then
                            listaEquiposAcabados(i).ItemData = listaEquiposAcabados(i).ItemData + 1
                        Else
                            listaEquiposAcabados.Add(New IDComboBox(iidArticulo, 1))
                        End If
                    End If
                End If
                item.Checked = False
            Next
            Call RestarMovimientosEquiposAcabados()
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
            Dim iidEstadoParcialPE As Integer = funcES.EstadoPedido("PARCIAL").gidEstado
            Dim iidEstadoServidoPE As Integer = funcES.EstadoPedido("SERVIDO").gidEstado
            Dim iidEstadoParcialPR As Integer = funcES.EstadoAutomatico("PRODUCCION").gidEstado


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

                Next
            End If
            'Por último actualizamos el estado de los pedidos 
            If Not listanumPedido Is Nothing Then
                Dim idEstadoActual As Integer
                For Each np As Integer In listanumPedido
                    idEstadoActual = funcPE.idEstado(np)

                    If funcCP.AlgoSERVIDO(np) Then 'Los estados PARCIAL y SERVIDO se respetan
                        If funcCP.TodosTraspasados(np) Then
                            If idEstadoActual <> iidEstadoServidoPE Then funcPE.actualizaEstado(np, iidEstadoServidoPE)
                        Else
                            If idEstadoActual <> iidEstadoParcialPE Then funcPE.actualizaEstado(np, iidEstadoParcialPE)
                        End If
                    Else
                        If funcCP.TodosCompletos(np) Then
                            If idEstadoActual <> iidEstadoProducidoPE Then funcPE.actualizaEstado(np, iidEstadoProducidoPE)
                        Else
                            If idEstadoActual <> iidEstadoEnCursoPE Then funcPE.actualizaEstado(np, iidEstadoEnCursoPE)
                        End If
                    End If
                Next
            End If
            MsgBox("Cambios guardados correctamente.")
            Cambios = False
            semaforo = True
        End If



    End Sub


    Private Function ArticuloEn(ByVal iidArticulo As Integer) As Integer
        If listaEquiposAcabados.Count = 0 Then
            Return -1
        Else
            Dim i As Integer = 0
            While i < listaEquiposAcabados.Count
                If listaEquiposAcabados(i).Name = iidArticulo Then Return i
                i = i + 1
            End While
            Return -1
        End If
    End Function


    Private Sub RestarMovimientosEquiposAcabados()
        For Each item As IDComboBox In listaEquiposAcabados
            Dim dts As New DatosMovimientoEquiposAcabados
            dts.gidArticulo = item.Name
            dts.gCantidad = -item.ItemData
            funcMA.insertar(dts)
        Next


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
            For Each item As ListViewItem In lvEquipos.Items
                item.Selected = ckSeleccion.Checked
            Next
            semaforo = False
            If ckSeleccion.CheckState = CheckState.Checked Then
                lbSeleccionados.Text = lvEquipos.Items.Count & If(lvEquipos.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
            lvEquipos.Focus()
        End If
    End Sub

    Private Sub ckSeleccionTaller_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccionTaller.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccionTaller.CheckState = CheckState.Indeterminate Then
        Else
            For Each item As ListViewItem In lvTaller.Items
                item.Selected = ckSeleccionTaller.Checked
            Next
            semaforo = False
            If ckSeleccionTaller.CheckState = CheckState.Checked Then
                lbSeleccionados.Text = lvTaller.Items.Count & If(lvTaller.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
            lvTaller.Focus()
        End If
    End Sub

    Private Sub ckSeleccionElectronica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccionElectronica.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccionElectronica.CheckState = CheckState.Indeterminate Then
        Else
            For Each item As ListViewItem In lvElectronica.Items
                item.Selected = ckSeleccionElectronica.Checked
            Next
            semaforo = False
            If ckSeleccionElectronica.CheckState = CheckState.Checked Then
                lbSeleccionados.Text = lvElectronica.Items.Count & If(lvElectronica.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
            semaforo = True
            lvElectronica.Focus()
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
        End If

    End Sub



    Private Sub lvEquipos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEquipos.ColumnClick
        If (e.Column = lvwColumnSorter.SortColumn) Then
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If
        lvEquipos.Sort()
    End Sub

    Private Sub lvTaller_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvTaller.ColumnClick
        If (e.Column = lvwColumnSorterT.SortColumn) Then
            If (lvwColumnSorterT.Order = SortOrder.Ascending) Then
                lvwColumnSorterT.Order = SortOrder.Descending
            Else
                lvwColumnSorterT.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorterT.SortColumn = e.Column
            lvwColumnSorterT.Order = SortOrder.Ascending
        End If
        lvTaller.Sort()
    End Sub

    Private Sub lvElectronica_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvElectronica.ColumnClick
        If (e.Column = lvwColumnSorterE.SortColumn) Then
            If (lvwColumnSorterE.Order = SortOrder.Ascending) Then
                lvwColumnSorterE.Order = SortOrder.Descending
            Else
                lvwColumnSorterE.Order = SortOrder.Ascending
            End If
        Else
            lvwColumnSorterE.SortColumn = e.Column

            lvwColumnSorterE.Order = SortOrder.Ascending
        End If
        lvElectronica.Sort()
    End Sub




    Private Sub tpElectronica_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpElectronica.Enter
        If lvElectronica.Items.Count = 0 Then
            PBCarga.Value = 0
            PBCarga.Maximum = listaEP.Count
            PBCarga.Visible = True
            Call cargarLVElectronica()
            PBCarga.Visible = False
        End If
        semaforo = False
        bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
        bAcabadoTaller.Enabled = False
        If lvElectronica.CheckedItems.Count > 0 Then

            lbSeleccionados.Text = lvElectronica.SelectedIndices.Count & If(lvElectronica.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
            lbSeleccionados.Visible = True
            For Each item As ListViewItem In lvElectronica.CheckedItems
                item.Selected = True
            Next

        Else
            lbSeleccionados.Visible = False
        End If
        semaforo = True
    End Sub


    Private Sub tpTaller_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpTaller.Enter
        If lvTaller.Items.Count = 0 Then
            PBCarga.Value = 0
            PBCarga.Maximum = listaEP.Count
            PBCarga.Visible = True
            Call cargarLVTaller()
            PBCarga.Visible = False
        End If
        semaforo = False
        bAcabadoElectronica.Enabled = False
        bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
        If lvTaller.CheckedItems.Count > 0 Then

            lbSeleccionados.Text = lvTaller.SelectedIndices.Count & If(lvTaller.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
            lbSeleccionados.Visible = True
            For Each item As ListViewItem In lvTaller.CheckedItems
                item.Selected = True
            Next

        Else
            lbSeleccionados.Visible = False
        End If
        semaforo = True
    End Sub

    Private Sub tpGlobal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpGlobal.Enter
        bAcabadoElectronica.Enabled = lvElectronica.Items.Count > 0
        bAcabadoTaller.Enabled = lvTaller.Items.Count > 0
        semaforo = False
        If lvEquipos.CheckedItems.Count > 0 Then

            lbSeleccionados.Text = lvEquipos.SelectedIndices.Count & If(lvEquipos.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
            lbSeleccionados.Visible = True
            For Each item As ListViewItem In lvEquipos.SelectedItems
                item.Selected = True
            Next

        Else
            lbSeleccionados.Visible = False
        End If
        semaforo = True
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
        If semaforo And Not CargaInicial Then
            semaforo = False
            If e.Item.Checked Then
                e.Item.Selected = True
            Else
                e.Item.Selected = False
            End If

            Dim cont As Integer = lvElectronica.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccionElectronica.CheckState = CheckState.Unchecked
            ElseIf cont = lvElectronica.Items.Count Then
                ckSeleccionElectronica.CheckState = CheckState.Checked
            Else
                ckSeleccionElectronica.CheckState = CheckState.Indeterminate
            End If
            semaforo = True
        End If
    End Sub


    Private Sub lvTaller_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvTaller.ItemChecked
        'Al checkar una linea,cambiamos el estado de ckseleccion 
        If semaforo And Not CargaInicial Then
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



    Private Sub lvElectronica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEquipos.SelectedIndexChanged, lvElectronica.SelectedIndexChanged, lvTaller.SelectedIndexChanged
        If semaforo Then
            If sender.SelectedItems.Count > 0 Then
                lbSeleccionados.Text = sender.SelectedIndices.Count & If(sender.SelectedIndices.Count = 1, " SELECCIONADO ", " SELECCIONADOS")
                lbSeleccionados.Visible = True
            Else
                lbSeleccionados.Visible = False
            End If
        End If
    End Sub


    Private Sub YourListView_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles lvElectronica.ItemCheck, lvTaller.ItemCheck, lvEquipos.ItemCheck

        'If (sender.SelectedItems.Count > 1) Then e.NewValue = e.CurrentValue
        If semaforo Then
            semaforo = False
            e.NewValue = sender.items(e.Index).selected
            semaforo = True
        End If



    End Sub



#End Region



End Class