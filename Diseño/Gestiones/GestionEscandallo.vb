'FORMULARIO DE GESTIÓN ESCANDALLOS.

Public Class GestionEscandallos

#Region "VARIABLES"

    'LLAMADAS A FUNCIONES.
    Private funcES As New FuncionesEscandallos 'funciones escandallos.

    Private funcCE As New FuncionesConceptosEscandallos 'funciones de conceptos de escandallos.

    Private funcTE As New FuncionesTiposEscandallos 'funciones de tipos de escandallos.

    Private funcAR As New FuncionesArticulos 'funciones de articulos.

    Private funcFA As New FuncionesFamilias 'funciones de familias.

    Private funcSF As New FuncionessubFamilias 'funciones de subfamilias.

    Private funcSE As New FuncionesSecciones 'funciones de secciones.

    Private funcTU As New FuncionesTiposUnidad 'funciones de tipos de unidad.

    Private funcAP As New FuncionesArticuloPrecio 'funciones de precios de articulos.

    Private funcTI As New FuncionesTiemposEscandallos 'funciones de tiempos de escandallos.

    'CREAMOS FUNCIONES.

    Private vSoloLectura As Boolean = False 'Variable de solo lectura.

    Private ep1 As New ErrorProvider 'Advertiencia falta campo 1.

    Private ep2 As New ErrorProvider 'Advertiencia falta campo 2.

    Private iidArticulo As Integer 'Almacena la ID de artículo.

    Private G_AGeneral As Char '

    Private iidUsuario As Integer 'Almacena la ID del usuario.

    Private cambios As Boolean 'Almacena el valor si se han producio cambios.

    Private iidArticuloC As Integer 'Almacena la ID de artículo C.

    Private iidFamilia As Integer 'Almacena la ID de la familia.

    Private indice As Integer 'Almacena el indice del listview.

    Private indiceT As Integer 'Almacena el indice del listview tiempos.

    Private dtsES As DatosEscandallo 'Almacena los datos de escandallos.

    Private colorInactivo As Color = Color.Gray 'Color de Item inactivo.

    Private IndiceL As Integer 'Almacena el indiceL

    Private desktopsize As Size 'Almacena medidas de pantalla.

    Private Semaforo As Boolean 'Variable de carga.

    Private lvwColumnSorter As OrdenarLV 'Almacena el orden de columna.

    Private ucopiar As Point 'Almacena un punto de la pantalla.

    Private Modo As String 'Almacena la cadena de modo.

    Dim orden As String = "concepto" 'Almacena la cadena de orden de columna.

    Dim direccion As String = " asc" 'Almacena la cadena de dirección de búsqueda.

    Dim colorLinea As String

    Dim codigoArticulo As String ' Almacena la variable de codigo del articulo.

    Dim articulo As String ' Almacena la variable de campo articulo.

    'LISTAS
    Private listaC As List(Of DatosConceptoEscandallo) 'Almacena lista de datos de conceptos escandallos.

    Private listaS As List(Of DatosConceptoEscandallo) 'Almacena lista de datos de conceptos Subescandallos.

    Private listaT As List(Of DatosTiempoEscandallo) 'Almacena lista de datos de tiempos escandallos.

    Private Escandallos As List(Of Integer)

    Private ListaEscandallos As List(Of List(Of DatosConceptoEscandallo)) 'Sólo se usa en caso de crear versión masivamente

    Private EscandalloOriginal As List(Of DatosConceptoEscandallo) 'Almacena lista de datos de conceptos Subescandallos.

    Private EscandalloActual As List(Of DatosConceptoEscandallo) 'Almacena lista de datos de conceptos Subescandallos.

    Private ListaCambios As List(Of DatosCambioEscandallo) 'Almacena lista de datos de cambios Subescandallos.

    Public cambiosEnConceptos As Boolean 'True es si se han hecho cambios en los conceptos.

#End Region

#Region "PROPIEDADES"

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Property pidEscandallo() As Integer
        Get
            Return idEscandallo.Text
        End Get
        Set(ByVal value As Integer)
            idEscandallo.Text = value
        End Set
    End Property

    Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property

    Property pEscandallos() As List(Of Integer)
        Get
            Return Escandallos
        End Get
        Set(ByVal value As List(Of Integer))
            Escandallos = value
        End Set
    End Property

    Property pIndice() As Integer
        Get
            Return IndiceL
        End Get
        Set(ByVal value As Integer)
            IndiceL = value
        End Set
    End Property

    Property pModo() As String
        Get
            Return Modo
        End Get
        Set(ByVal value As String)
            Modo = value
        End Set
    End Property

#End Region

    'Carga el formulario
    Private Sub GestionEscandallo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Activa el semaforo false es rojo y true es verde
            Semaforo = False

            '
            ucopiar = bCopiar.Location

            'Formatea el formulario segun las medidas de la pantalla.
            desktopsize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize

            Me.Height = desktopsize.Height - 60
            Me.Location = New Point(Me.Location.X, 5)

            'Oculta la barra de proceso.
            pbCarga.Visible = False

            'Llena la variables de advertencia.
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink

            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink

            ep2.Icon = My.Resources.Resources.info

            'Desactiva el botón propagar
            bPropagar.Visible = False

            'Si el permiso es de sololectura.
            bGuardar.Enabled = Not vSoloLectura

            'Si el permiso es de sololectura.
            bBorrar.Enabled = Not vSoloLectura

            'Inserta la ID de usuario.
            iidUsuario = Inicio.vIdUsuario

            'Vaciamos los indices.
            indice = -1
            indiceT = -1


        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'Se ejecuta cuando el formulario ya es visible.
    Private Sub GestionEscandallo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'Barra de proceso de cargar
        pbCarga.Maximum = 100
        pbCarga.Visible = True
        pbCarga.Focus()
        pbCarga.Increment(10)

        Semaforo = False

        'Introducimos los escandallos.
        Call introducirTiposEscandallos()

        pbCarga.Increment(10)

        'Introducimos las secciones.
        Call IntroducirSecciones()

        pbCarga.Increment(40)

        'Si id escandallo está vacia, entonces será igual a 0.
        If idEscandallo.Text = "" Or idEscandallo.Text = 0 Then

            Call Nuevo()

            lbActualizacion.Text = ""

            If iidArticulo > 0 Then

                bBuscarArticulo.Enabled = False

                Dim iidescandallo As Integer = funcES.ExisteEscandallo(iidArticulo)

                If iidescandallo > 0 Then

                    idEscandallo.Text = iidescandallo

                    Call Editar()

                End If

            End If

        Else

            If Modo = "CambioMasivo" Then

                bCopiar.Visible = False

                Dim punto As Point = bSubir.Location

                punto.X = punto.X - (bCopiar.Size.Width - bSubir.Size.Width)

                bPropagar.Location = punto

                bPropagar.Visible = True

                If pEscandallos.Count > 1 Then

                    MsgBox("Va a editar el primer escandallo seleccionado." & vbCrLf & "Una vez realizados todos los cambios, pulsando PROPAGAR CAMBIOS, propagará esos mismos cambios a los " & pEscandallos.Count - 1 & "  escandallos seleccionados restantes.")

                End If

                Call CargarEscandalloOriginal()

                pbCarga.Increment(20)

                Call CrearVersion()

                pbCarga.Increment(20)

            Else

                Call Editar()

                pbCarga.Increment(20)

            End If

        End If

        pbCarga.Visible = False

        Semaforo = True

    End Sub

    'Carga la lista de escandallos.
    Private Sub CargarListaEscandallos()

        Dim listaConceptos As List(Of DatosConceptoEscandallo)

        ListaEscandallos = New List(Of List(Of DatosConceptoEscandallo))

        For Each iidEscandallo As Integer In pEscandallos

            If iidEscandallo <> idEscandallo.Text Then

                listaConceptos = funcCE.Mostrar(iidEscandallo, True, 0)

                ListaEscandallos.Add(listaConceptos)

            End If

            pbCarga.Increment(2)

        Next

    End Sub

    '
    Private Sub CargarEscandalloOriginal()

        If Not EscandalloOriginal Is Nothing Then EscandalloOriginal.Clear()

        EscandalloOriginal = funcCE.Mostrar(idEscandallo.Text, True, 0)

    End Sub

    'Cierra el formulario de gestion de  escandallos.
    Private Sub GestionEscandallo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If cambios Then

            If G_AGeneral = "G" Then

                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)

            ElseIf Not bPropagar.Visible Then

                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)

            End If

        End If

        If bPropagar.Enabled And bPropagar.Visible And (Not pEscandallos Is Nothing AndAlso pEscandallos.Count > 1) Then

            e.Cancel = (MsgBox("No ha propagado los cambios a los " & pEscandallos.Count - 1 & " escandallos seleccionados restantes." & vbCrLf & "Confirme que desea salir.", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)

        End If

    End Sub

#Region "INICIALIZACIÓN"

    'Inicializamos los campos.
    Private Sub Inicializar()

        'Campos del propio escandallo.

        cbTipoEscandallo.Text = ""

        cbTipoEscandallo.SelectedIndex = -1

        dtpFechaAlta.Value = Now.Date

        dtpFechaBaja.Value = Now.Date

        CosteTotal.Text = 0

        CosteTotalMaterial.Text = 0

        CosteTotalTiempo.Text = 0

        ckActivo.Checked = True

        dtpFechaBaja.Visible = False

        lbFechaBaja.Visible = False

        observaciones.Text = ""

        lbActualizacion.Text = ""

        Version.Text = Now.Year

        Call LimpiarEdicion()

        Call LimpiarEdicionT()

        cambios = False

    End Sub

    'Limpia los campos de añadir conceptos.
    Private Sub LimpiarEdicion()

        indice = -1

        iidArticuloC = 0

        ckActivoC.Checked = True

        Cantidad.Text = 0

        Coste.Text = 0

        ObservacionesC.Text = ""

        lbMonedaC.Text = "€"

        lbUnidad.Text = "u."

        txCodMateriaPrima.Text = ""

        txFamilia.Text = ""

        txMateriaPrima.Text = ""

        txSeccion.Text = ""

        txSubFamila.Text = ""

    End Sub

    'Limpiar los campos de añadir tiempos
    Private Sub LimpiarEdicionT()

        indiceT = -1

        cbSeccionT.Text = ""

        cbSeccionT.SelectedIndex = -1

        ObservacionesT.Text = ""

        PrecioHora.Text = 0

        Horas.Text = 0

        lvTiempos.SelectedItems.Clear()

    End Sub

    'Creamos un escandallo nuevo.
    Private Sub Nuevo()

        'Cambiamos el texto del formulario a ,
        Me.Text = "NUEVO ESCANDALLO"

        ckActivo.Checked = True

        dtpFechaAlta.Value = Now

        Version.Text = Year(Now)

        idEscandallo.Text = funcES.NuevoidEscandallo

        tbdatos.Enabled = False

        bBuscarArticulo.Enabled = True

        G_AGeneral = "G"

        dtsES = New DatosEscandallo

        bSubir.Visible = False

        bBajar.Visible = False

        Dim punto As Point = bSubir.Location

        punto.X = punto.X - (bCopiar.Size.Width - bSubir.Size.Width)

        bCopiar.Location = punto

        bCopiar.Visible = True

    End Sub

    'Editamos un escandallo.
    Private Sub Editar()

        Me.Text = "EDITAR ESCANDALLO"

        bCopiar.Visible = False

        If Escandallos Is Nothing Then

            bSubir.Visible = False

            bBajar.Visible = False

        Else

            bSubir.Visible = True

            bBajar.Visible = True

        End If

        tbdatos.Enabled = True

        bBuscarArticulo.Enabled = False

        Call CargarEscandallo()

        If bSubir.Visible Then

            bCopiar.Location = ucopiar

        Else

            Dim punto As Point = bSubir.Location

            punto.X = punto.X - (bCopiar.Size.Width - bSubir.Size.Width)

            bCopiar.Location = punto

        End If

        If dtsES.gnumComponentes = 0 Then

            bCopiar.Visible = True

        Else

            bCopiar.Visible = False

        End If

        G_AGeneral = "A"

    End Sub

    'Crear version.
    Private Sub CrearVersion()

        Me.Text = "EDITAR ESCANDALLO PARA CAMBIO MASIVO"

        bCopiar.Visible = False

        bSubir.Visible = False

        bBajar.Visible = False

        tbdatos.Enabled = True

        bBuscarArticulo.Enabled = False

        Call CargarEscandallo()

        G_AGeneral = "A"

    End Sub

    'Instroduce en el combobox los tipos de escandallos.
    Private Sub introducirTiposEscandallos()

        cbTipoEscandallo.Items.Clear()

        Dim lista As List(Of DatosTipoEscandallo) = funcTE.Mostrar

        For Each dts As DatosTipoEscandallo In lista

            cbTipoEscandallo.Items.Add(New IDComboBox(dts.gTipoEscandallo, dts.gidTipoEscandallo))

        Next

    End Sub

#End Region

#Region "CARGAR DATOS"

    'Carga el escandallo.
    Private Sub CargarEscandallo()

        Application.DoEvents()

        ep1.Clear()

        ep2.Clear()

        dtsES = funcES.Mostrar1(idEscandallo.Text) 'Llenamos los datoss de escandallo.

        iidArticulo = dtsES.gidArticulo

        idEscandallo.Text = dtsES.gidEscandallo

        txEscandallo.Text = dtsES.gArticulo

        cbTipoEscandallo.Text = dtsES.gTipoEscandallo

        Dim lista As List(Of IDComboBox3) = funcAR.Listar(iidArticulo)

        dtpFechaAlta.Value = dtsES.gFechaAlta

        dtpFechaBaja.Value = dtsES.gFechaBaja

        ckActivo.Checked = dtsES.gActivo

        observaciones.Text = dtsES.gObservaciones

        Version.Text = dtsES.gVersionEscandallo

        lbActualizacion.Text = "ÚLTIMA ACTUALIZACIÓN " & FormatDateTime(funcES.FechaActualizacion(idEscandallo.Text), DateFormat.ShortDate)

        Call CargarConceptos()

        Call CargarTiempos()

        cambios = False

    End Sub

    'Carga los conceptos de escandallos.
    Private Sub CargarConceptos()

        lvConceptos.Items.Clear()

        listaC = funcCE.Mostrar(idEscandallo.Text, False, 0)

        lvwColumnSorter = New OrdenarLV()

        Me.lvConceptos.ListViewItemSorter = lvwColumnSorter

        For Each dts As DatosConceptoEscandallo In listaC

            dts.gColorSubEscandallos = False

            Call NuevaLinealv(dts)

            pbCarga.Increment(1)

            If ckSubEscandallos.Checked Then

                listaS = funcCE.Mostrar(dts.gExisteEscandallo, False, 0)

                For Each dtsS As DatosConceptoEscandallo In listaS

                    dtsS.gColorSubEscandallos = True

                    Call NuevaLinealv(dtsS)

                    Dim listaS1 As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(dtsS.gExisteEscandallo, False, 0)

                    For Each dtsS1 As DatosConceptoEscandallo In listaS1

                        dtsS.gColorSubEscandallos = False

                        Call NuevaLinealv(dtsS1)

                    Next

                Next

            End If

        Next

        Call CalculaTotal()

        CosteTotal.Text = FormatNumber(CDbl(CosteTotalTiempo.Text) + CDbl(CosteTotalMaterial.Text), 4)

    End Sub

    'Carga los tiempos de escandallos.
    Private Sub CargarTiempos()

        lvTiempos.Items.Clear()

        listaT = funcTI.Mostrar(idEscandallo.Text, False)

        For Each dts As DatosTiempoEscandallo In listaT

            Call NuevaLinealvT(dts)

        Next

        CosteTotalTiempo.Text = FormatNumber(funcTI.TotalCoste(idEscandallo.Text, True), 4)

        CosteTotal.Text = FormatNumber(CDbl(CosteTotalTiempo.Text) + CDbl(CosteTotalMaterial.Text), 4)

    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    'Carga nueva linea en listview conceptos.
    Private Sub NuevaLinealv(ByVal dts As DatosConceptoEscandallo)

        With lvConceptos.Items.Add(dts.gidConcepto)

            .SubItems.Add(dts.gSeccion)

            .SubItems.Add(dts.gcodArticulo)

            .SubItems.Add(dts.gFamilia)

            .SubItems.Add(dts.gsubFamilia)

            .SubItems.Add(dts.gArticulo)

            .SubItems.Add(dts.gCantidad & dts.gTipoUnidad)

            .SubItems.Add(FormatNumber(dts.gCoste, 4) & dts.gsimbolo)

            .SubItems.Add(FormatNumber(dts.gCoste * dts.gCantidad, 4) & dts.gsimbolo)

            .SubItems.Add(dts.gObservaciones)

            If dts.gColorSubEscandallos Then

                .ForeColor = Color.Black

                .BackColor = Color.LightBlue

            Else

                If dts.gActivo Then

                    If dts.gExisteEscandallo Then

                        .ForeColor = Color.DarkGreen

                    Else

                        .ForeColor = Color.Black

                    End If

                Else
                    .ForeColor = colorInactivo

                End If

            End If

        End With

        If lvConceptos.Items.Count > 0 Then lvConceptos.EnsureVisible(lvConceptos.Items.Count - 1)

    End Sub

    'Actualiza la linea seleccionada en el listview conceptos.
    Private Sub ActualizaLineaLV(ByVal dts As DatosConceptoEscandallo)

        If indice > -1 Then

            lvwColumnSorter = New OrdenarLV()

            Me.lvConceptos.ListViewItemSorter = lvwColumnSorter

            With lvConceptos.Items(indice)

                .SubItems(1).Text = dts.gSeccion

                .SubItems(2).Text = dts.gcodArticulo

                .SubItems(3).Text = dts.gFamilia

                .SubItems(4).Text = dts.gsubFamilia

                .SubItems(5).Text = dts.gArticulo

                .SubItems(6).Text = dts.gCantidad & dts.gTipoUnidad

                .SubItems(7).Text = FormatNumber(dts.gCoste, 4) & dts.gsimbolo

                .SubItems(8).Text = FormatNumber(dts.gCoste * dts.gCantidad, 4) & dts.gsimbolo

                .SubItems(9).Text = dts.gObservaciones

                If dts.gActivo Then

                    If dts.gExisteEscandallo Then

                        .ForeColor = Color.DarkGreen

                    Else

                        .ForeColor = Color.Black

                    End If

                Else

                    .ForeColor = colorInactivo

                End If

            End With

        End If

    End Sub

    'Carga nueva linea en listview tiempos.
    Private Sub NuevaLinealvT(ByVal dts As DatosTiempoEscandallo)

        With lvTiempos.Items.Add(dts.gidTiempo)

            .SubItems.Add(dts.gSeccion)

            .SubItems.Add(FormatNumber(dts.gHoras, 2))

            .SubItems.Add(FormatNumber((dts.gHoras * dts.gPrecioHora), 4) & dts.gsimbolo)

            .SubItems.Add(dts.gObservaciones)

            If dts.gActivo Then

                .ForeColor = Color.Black

            Else

                .ForeColor = colorInactivo

            End If

        End With

        If lvTiempos.Items.Count > 0 Then lvTiempos.EnsureVisible(lvTiempos.Items.Count - 1)

    End Sub

    'Actualiza la linea seleccionada en el listview tiempos.
    Private Sub ActualizaLineaLVT(ByVal dts As DatosTiempoEscandallo)
        If indiceT > -1 Then
            With lvTiempos.Items(indiceT)
                .SubItems(1).Text = dts.gSeccion
                .SubItems(2).Text = FormatNumber(dts.gHoras, 2)
                .SubItems(3).Text = FormatNumber((dts.gHoras * dts.gPrecioHora), 4) & dts.gsimbolo
                .SubItems(4).Text = dts.gObservaciones
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If
    End Sub

    'Guardar General.
    Private Function GuardarGeneral() As Boolean

        ep1.Clear()

        ep2.Clear()

        'Validamos los campos.
        Dim validar As Boolean = True

        If cbTipoEscandallo.SelectedIndex = -1 Then

            validar = False

            ep1.SetError(cbTipoEscandallo, "Se ha de seleccionar el tipo de Escandallo.")

        End If

        If Version.Text = "" Then

            validar = False

            ep1.SetError(Version, "Se ha de rellenar este campo.")

        End If

        If txEscandallo.Text = "" Then

            validar = False

            ep1.SetError(txEscandallo, "Se ha de rellenar este campo.")

        End If

        'Si todo está validado.
        If validar Then

            dtsES.gcodEscandallo = If(dtsES.gcodEscandallo = "", codigoArticulo, dtsES.gcodEscandallo)

            dtsES.gidArticulo = If(dtsES.gidArticulo = 0, iidArticulo, dtsES.gidArticulo)

            dtsES.gidEscandallo = idEscandallo.Text

            dtsES.gidTipoEscandallo = cbTipoEscandallo.SelectedItem.itemdata

            dtsES.gEscandallo = txEscandallo.Text

            dtsES.gActivo = ckActivo.Checked

            dtsES.gObservaciones = observaciones.Text

            dtsES.gFechaAlta = dtpFechaAlta.Value.Date

            dtsES.gFechaBaja = dtpFechaBaja.Value.Date

            dtsES.gVersionEscandallo = If(Version.Text = "", Format(Year(Now)), Version.Text) 'AÑADIDO POR LUIS

            'dtsES.gVersionBase = 2017 'ELIMINADO POR LUIS

            If G_AGeneral = "G" Then

                idEscandallo.Text = funcES.insertar(dtsES)

                G_AGeneral = "A"

                Me.Text = "EDITAR ESCANDALLO"

                tbdatos.Enabled = True

                If bCopiar.Visible Then

                    'Si hemos copiado, a cantinuación se cargarán los componentes del otro escandallo

                Else

                    MsgBox("Guardados los datos generales. Ya puede introducir el desglose.")

                End If

            Else

                funcES.actualizar(dtsES)

            End If

            cambios = False

        End If

        Return validar

    End Function

    'Guardar Concepto.
    Private Function GuardarConcepto() As Boolean

        ep1.Clear()

        ep2.Clear()

        Dim validar = True

        If txMateriaPrima.Text = "" And iidArticuloC > 0 Then

            ep1.SetError(txMateriaPrima, "No se ha seleccionado ningún artículo.")

            validar = False

        End If

        If validar Then

            bCopiar.Visible = False

            Dim dts As New DatosConceptoEscandallo

            dts.gidEscandallo = dtsES.gidEscandallo

            dts.gCantidad = Cantidad.Text

            dts.gObservaciones = ObservacionesC.Text

            dts.gOrden = lvConceptos.Items.Count + 1

            dts.gActivo = ckActivoC.Checked

            dts.gcodEscandallo = If(dtsES.gcodEscandallo Is Nothing, "", dtsES.gcodEscandallo)

            dts.gEscandallo = dtsES.gEscandallo

            dts.gidArticulo = iidArticuloC

            Dim dtsAR As DatosArticulo = funcAR.Mostrar1(iidArticuloC)

            dts.gArticulo = dtsAR.gArticulo

            dts.gcodArticulo = dtsAR.gcodArticulo

            dts.gidFamilia = dtsAR.gidFamilia

            dts.gidsubFamilia = dtsAR.gidSubFamilia

            dts.gFamilia = dtsAR.gFamilia

            dts.gsubFamilia = dtsAR.gSubFamilia

            dts.gidSeccion = dtsAR.gidSeccion

            dts.gSeccion = dtsAR.gSeccion

            dts.gTipoUnidad = dtsAR.gTipoUnidad

            dts.gidTipoUnidad = dtsAR.gidUnidad

            dts.gCoste = dtsAR.gPrecioUnitarioC

            dts.gcodMoneda = dtsAR.gcodMonedaC

            dts.gsimbolo = dtsAR.gSimboloC

            dts.gcodConcepto = txCodMateriaPrima.Text

            dts.gConcepto = txMateriaPrima.Text

            If indice = -1 Then

                'Si el concepto es nuevo

                dts.gidConcepto = funcCE.insertar(dts)

                lvwColumnSorter = New OrdenarLV()

                Me.lvConceptos.ListViewItemSorter = lvwColumnSorter

                Call NuevaLinealv(dts)

            Else
                dts.gidConcepto = lvConceptos.Items(indice).Text
                If funcCE.actualizar(dts) Then Call ActualizaLineaLV(dts)
            End If
            Call CalculaTotal()


            bGuardar.Enabled = False

            lbActualizandoPrecios.Visible = True

            Application.DoEvents()

            Call ActualizaPrecioAR(iidArticulo, CosteTotal.Text, If(IsNumeric(Version.Text), CInt(Version.Text), 0))

            lbActualizandoPrecios.Visible = False

            bGuardar.Enabled = True

            Call LimpiarEdicion()

        End If

    End Function

    'Actualiza el precio del escandallo y el de los escandallos a los que pertenece.
    Private Sub ActualizaPrecioAR(ByVal iidArticulo As Integer, ByVal CosteTotal As Double, ByVal Version As Integer)

        'Actualizar el precio de coste del producto
        Dim dtsPR As DatosArticuloPrecio = funcAP.Precio(iidArticulo, "C", Version)

        If dtsPR.gidArticuloPrecio = 0 Then 'Si no hay un precio relacionado con la versión, tomamos el último activo

            dtsPR = funcAP.Precio(iidArticulo, "C")

        End If

        If dtsPR.gPrecio <> CosteTotal Or dtsPR.gcodMoneda <> "EU" Then

            funcAP.Inactiva(dtsPR.gidArticuloPrecio)

            dtsPR.gcodMoneda = "EU"

            dtsPR.gPrecio = CosteTotal

            dtsPR.gFechaPrecio = Now.Date

            dtsPR.gidArticulo = iidArticulo

            dtsPR.gTipoPrecio = "C"

            dtsPR.gidProveedorPrecio = 0

            dtsPR.gidConcepto = 0

            dtsPR.gidClientePrecio = 0

            dtsPR.gDescuento = 0

            dtsPR.gActivo = True

            dtsPR.gVersion = Version

            funcAP.insertar(dtsPR)

        End If

        Dim listaArticulosQueContienen As List(Of IDComboBox3) = funcAR.ListarArticulosQueContienen(iidArticulo)

        Dim CosteTotalMaterial As Double

        Dim CosteTotalTiempo As Double

        Dim aviso As Boolean = False

        Dim FechaCambio As Date

        Dim iidEscandallo As Integer

        For Each dts As IDComboBox3 In listaArticulosQueContienen

            iidEscandallo = funcES.ExisteEscandallo(dts.ItemData)

            If iidEscandallo > 0 Then

                CosteTotalMaterial = funcES.CosteEU(iidEscandallo, aviso, FechaCambio)

                CosteTotalTiempo = funcTI.TotalCoste(iidEscandallo, True)

                ActualizaPrecioAR(dts.ItemData, CosteTotalMaterial + CosteTotalTiempo, 0) 'Los artículos compuestos no tienen versión (la tomarán de su artículo Base)

            End If

        Next

    End Sub

    'Guarda el concepto de tiempo.
    Private Sub GuardarTiempo()
        Dim validar As Boolean = True
        If cbSeccionT.SelectedIndex = -1 Then
            validar = False
            ep1.SetError(cbSeccionT, "Se ha de seleccionar una sección")
        End If

        If Horas.Text = "" Then Horas.Text = 0
        If PrecioHora.Text = "" Then PrecioHora.Text = 0
        If validar Then
            Dim dts As New DatosTiempoEscandallo
            dts.gidTiempo = 0
            dts.gidEscandallo = dtsES.gidEscandallo
            dts.gidSeccion = cbSeccionT.SelectedItem.gidSeccion
            dts.gHoras = Horas.Text
            dts.gPrecioHora = PrecioHora.Text
            dts.gObservaciones = ObservacionesT.Text
            dts.gSeccion = cbSeccionT.Text
            dts.gcodMoneda = "EU"
            dts.gsimbolo = "€"
            dts.gActivo = True
            If indiceT = -1 Then
                'Nuevo tiempo
                dts.gidTiempo = funcTI.insertar(dts)
                dts.gcodMoneda = "EU"
                dts.gsimbolo = "€"
            Else
                'Modificar tiempo existente
                dts.gidTiempo = lvTiempos.Items(indiceT).Text
                funcTI.actualizar(dts)
            End If
            CosteTotalTiempo.Text = FormatNumber(funcTI.TotalCoste(idEscandallo.Text, True), 4)
            CosteTotal.Text = FormatNumber(CDbl(CosteTotalTiempo.Text) + CDbl(CosteTotalMaterial.Text), 4)
            'Actualizar el precio de coste del producto
            Dim dtsPR As DatosArticuloPrecio = funcAP.Precio(iidArticulo, "C")
            If dtsPR.gPrecio <> CosteTotal.Text Or dtsPR.gcodMoneda <> "EU" Then
                funcAP.Inactiva(dtsPR.gidArticuloPrecio)
                dtsPR.gcodMoneda = "EU"
                dtsPR.gPrecio = CosteTotal.Text
                dtsPR.gFechaPrecio = Now.Date
                dtsPR.gidArticulo = iidArticulo
                dtsPR.gTipoPrecio = "C"
                dtsPR.gidProveedorPrecio = 0
                dtsPR.gidConcepto = 0
                dtsPR.gidClientePrecio = 0
                dtsPR.gDescuento = 0
                dtsPR.gActivo = True
                dtsPR.gVersion = If(IsNumeric(Version.Text), CInt(Version.Text), 0)
                funcAP.insertar(dtsPR)
            End If
            Call CargarTiempos()
            Call LimpiarEdicionT()
        End If
    End Sub

    'Calcula los totales del escandallo.
    Public Sub CalculaTotal()

        Dim aviso As Boolean = False

        Dim FechaCambio As Date

        CosteTotalMaterial.Text = FormatNumber(funcES.CosteEU(idEscandallo.Text, aviso, FechaCambio), 4)

        CosteTotal.Text = FormatNumber(CDbl(CosteTotalTiempo.Text) + CDbl(CosteTotalMaterial.Text), 4)

        lbCambio.Text = "CAMBIO " & FechaCambio

        lbCambio.Visible = aviso

    End Sub

    Private Sub MostrarArticuloC()

        'Llamar a la Gestión de Artículos. Al volver, actualizar los datos
        If iidArticuloC > 0 Then

            Dim GA As New GestionArticulo

            GA.SoloLectura = vSoloLectura

            GA.pidArticulo = iidArticuloC

            GA.ShowDialog()

            Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticuloC)

            txSeccion.Text = dts.gSeccion

            txFamilia.Text = dts.gFamilia

            txSubFamila.Text = dts.gSubFamilia

            Coste.Text = FormatNumber(dts.gPrecioUnitarioC, 4)

            lbMonedaC.Text = dts.gSimboloC

            lbUnidad.Text = dts.gTipoUnidad

            If Cantidad.Text = "0" Then Cantidad.Text = 1

            If indice <> -1 Then

                Call ActualizaLineaLV(funcCE.Mostrar1(lvConceptos.Items(indice).Text))

            End If

        End If

    End Sub

#End Region

#Region "BOTONES GENERALES"

    'Al presionar el boton guardar.
    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        If GuardarGeneral() Then

            Select Case tbdatos.SelectedTab.Name

                Case tbDesglose.Name

                    If txMateriaPrima.Text.Length > 0 Then

                        cambiosEnConceptos = True

                        Call GuardarConcepto()

                    Else

                        If cambiosEnConceptos Then

                            Call ActualizaPrecioAR(iidArticulo, CosteTotal.Text, If(IsNumeric(Version.Text), CInt(Version.Text), 0))

                            cambiosEnConceptos = False

                        End If

                    End If

                Case tbTiempos.Name

                    If cbSeccionT.SelectedIndex <> -1 Then

                        Call GuardarTiempo()

                    End If

            End Select

            lbActualizacion.Text = "ÚLTIMA ACTUALIZACIÓN " & FormatDateTime(funcES.FechaActualizacion(idEscandallo.Text), DateFormat.ShortDate)

            cambios = False

            CargarConceptos()

        End If

    End Sub

    'Al presionar el boton copiar.
    Private Sub bCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCopiar.Click

        'Copiar los componentes de otro escandallo
        ep1.Clear()
        ep2.Clear()

        Dim GG As New BusquedaEscandallo

        GG.SoloLectura = vSoloLectura

        GG.pModo = "B"

        GG.ShowDialog()

        codigoArticulo = GG.codigoArticulo

        iidArticulo = GG.iidarticulo

        articulo = GG.Escandallo

        txEscandallo.Text = articulo

        If GG.pidEscandallo > 0 Then

            'Si es un escandallo con componentes
            'Guardamos la cabecera

            If GuardarGeneral() Then

                tbdatos.Enabled = True

                bBuscarArticulo.Enabled = False

                G_AGeneral = "A"

                lvConceptos.Items.Clear()

                listaC = funcCE.Mostrar(GG.pidEscandallo, False, 0)

                lvwColumnSorter = New OrdenarLV()

                Me.lvConceptos.ListViewItemSorter = lvwColumnSorter

                For Each dts As DatosConceptoEscandallo In listaC

                    dts.gidEscandallo = dtsES.gidEscandallo

                    dts.gidConcepto = funcCE.insertar(dts)

                    Call NuevaLinealv(dts)

                Next

                Call CalculaTotal()

                bCopiar.Visible = False

            End If

        End If

    End Sub

    '
    Private Sub bSeccionesT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSeccionesT.Click

        Dim seccion As String = cbSeccionT.Text

        Dim GS As New gestionSecciones

        GS.SoloLectura = vSoloLectura

        GS.ShowDialog()

        Call IntroducirSecciones()

        cbSeccionT.Text = seccion

        If cbSeccionT.SelectedIndex = -1 Then

            cbSeccionT.Text = ""

        Else

            PrecioHora.Text = FormatNumber(cbSeccionT.SelectedItem.gpreciohora, 4)

        End If

    End Sub

    'Llena el combobox de secciones.
    Private Sub IntroducirSecciones()

        cbSeccionT.Items.Clear()

        Dim lista As List(Of DatosSeccion) = funcSE.Mostrar(True)

        Dim dts As DatosSeccion

        For Each dts In lista

            cbSeccionT.Items.Add(dts)

        Next

    End Sub

    'Buscar materia prima.
    Private Sub bBuscarMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarMP.Click

        Dim BA As New lbBusquedaArticulo

        BA.SoloLectura = vSoloLectura

        BA.pModo = "MP"

        BA.SoloLectura = vSoloLectura

        BA.ShowDialog()

        If BA.iidArticulo > 0 Then

            Dim listaAR As New List(Of DatosArticulo)

            listaAR = funcAR.Mostrar(True, BA.iidArticulo)

            Dim dtsAR As DatosArticulo

            For Each dtsAR In listaAR

                txFamilia.Text = dtsAR.gFamilia

                txSubFamila.Text = dtsAR.gSubFamilia

                txSeccion.Text = dtsAR.gSeccion

                iidArticuloC = dtsAR.gidArticulo

                Coste.Text = dtsAR.gPrecioUnitarioC

                Cantidad.Text = 1

                txCodMateriaPrima.Text = dtsAR.gcodArticulo

                txMateriaPrima.Text = dtsAR.gArticulo

            Next

        End If

    End Sub

    'Al presionar el boton salir.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'Al presionar el boton borrar.
    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If indice = -1 And indiceT = -1 Then
            If G_AGeneral = "G" Then
                If cambios Then
                    If MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Call Inicializar()
                        iidArticulo = 0
                    End If
                Else
                    Call Inicializar()
                    iidArticulo = 0
                End If
            Else
                If MsgBox("¿Desea borrar este escandallo?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If funcCE.PerteneceEscandallo(idEscandallo.Text) Then

                        If funcES.Borrar(idEscandallo.Text) Then

                            Call Inicializar()

                            iidArticulo = 0

                            Me.Text = "NUEVO ESCANDALLO"

                            tbdatos.Enabled = False

                            idEscandallo.Text = funcES.NuevoidEscandallo

                            G_AGeneral = "G"

                            dtsES = New DatosEscandallo

                        End If

                    Else

                        MsgBox("Este escandallo no se puede borrar por que pertenece a otro artículo.", MsgBoxStyle.Information)

                    End If

                End If

            End If
        Else

            Select Case tbdatos.SelectedTab.Name
                Case tbDesglose.Name
                    'Si hay una linea seleccionada, la borramos
                    If indice <> -1 Then
                        If MsgBox("¿Desea borrar este concepto de escandallo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            funcCE.Borrar(lvConceptos.Items(indice).Text)
                            lvConceptos.Items.RemoveAt(indice)
                            lvwColumnSorter = New OrdenarLV()
                            Me.lvConceptos.ListViewItemSorter = lvwColumnSorter
                            Call LimpiarEdicion()
                        End If

                    End If
                Case tbTiempos.Name
                    If MsgBox("¿Desea borrar este concepto de tiempo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If indiceT <> -1 Then
                            funcTI.Borrar(lvTiempos.Items(indiceT).Text)
                            lvTiempos.Items.RemoveAt(indiceT)
                            Call LimpiarEdicionT()
                        End If
                    End If

            End Select
        End If

    End Sub

    'Al presionar el boton imprimir.
    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click

        Dim GG As New SeleccionImprimirEscandallos

        GG.ShowDialog()

        If GG.DialogResult = Windows.Forms.DialogResult.OK Then

            Dim IE As New InformeEscandallo

            IE.verInforme(idEscandallo.Text, True, True, True, orden, GG.pInterno)

            IE.ShowDialog()

        End If

    End Sub

    'Al presionar el boton nuevo.
    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click

        If cambios Then

            If MsgBox("Se perderán los los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                Call Inicializar()

                iidArticulo = 0

                Call Nuevo()

            End If

        Else

            Call Inicializar()

            iidArticulo = 0

            Call Nuevo()

        End If

    End Sub

    'Cuando buscamos en la lupa nos carga el articulo en el campo de texto.
    Private Sub bBuscarArtiulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarArticulo.Click

        Dim BA As New lbBusquedaArticulo 'Formulario de busqueda de articulo.

        BA.pModo = "ESCANDALLO"

        BA.SoloLectura = vSoloLectura

        BA.ShowDialog()

        If BA.pidArticulo > 0 Then

            iidArticulo = BA.pidArticulo 'Llena la id del articulo seleccionado,

            codigoArticulo = funcAR.codArticulo(iidArticulo)

            articulo = funcAR.Articulo(iidArticulo)

            txEscandallo.Text = articulo

            Dim iidescandallo As Integer = funcES.ExisteEscandallo(iidArticulo, Year(Now))

            If iidescandallo > 0 Then

                If MsgBox("Ya exite la version " & Year(Now) & ", ¿Desea cargar esta versión?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    idEscandallo.Text = iidescandallo

                    Call Editar()

                Else


                End If

            End If

        End If

    End Sub

    'Se desplaza por los escandallos ascendente.
    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click

        If IndiceL > 0 Then

            Call LimpiarEdicion()

            Call LimpiarEdicionT()

            IndiceL = IndiceL - 1

            idEscandallo.Text = Escandallos(IndiceL)

            Call CargarEscandallo()

        End If

    End Sub

    'Se desplaza por los escandallos descendente.
    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click

        If IndiceL < Escandallos.Count - 1 Then

            Call LimpiarEdicion()

            Call LimpiarEdicionT()

            IndiceL = IndiceL + 1

            idEscandallo.Text = Escandallos(IndiceL)

            Call CargarEscandallo()

        End If

    End Sub

    'Muetra la tabla de tipos de escandallo.
    Private Sub bTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTipo.Click

        Dim TipoEscandallo As String = cbTipoEscandallo.Text

        Dim GTE As New gestionTiposEscandallo

        GTE.SoloLectura = vSoloLectura

        GTE.ShowDialog()

        Call introducirTiposEscandallos()

        cbTipoEscandallo.Text = TipoEscandallo

        If cbTipoEscandallo.SelectedIndex = -1 Then cbTipoEscandallo.Text = ""

    End Sub

    'Abre el mostrar articulos.
    Private Sub bArticuloC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bArticuloC.Click

        If iidArticuloC > 0 Then

            Call MostrarArticuloC()

            Call CalculaTotal()

        End If

    End Sub

    'limpia el indice de conceptos.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        Call LimpiarEdicion()

    End Sub

    'limpia el indice de tiempos.
    Private Sub bLimpiarTiempo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiarTiempo.Click

        Call LimpiarEdicionT()

    End Sub

#End Region

#Region "CAMBIOS MASIVOS"

    Private Sub bPropagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPropagar.Click

        pbCarga.Visible = True

        pbCarga.Value = 0

        pbCarga.Maximum = 8 * pEscandallos.Count

        Call CargarListaEscandallos()

        Call ExtraerCambios()

        If ListaCambios.Count = 0 Then

            MsgBox("No se han detectado cambios en el escandallo")

        Else

            Dim texto As String = "CAMBIOS DETECTADOS" & vbCrLf & vbCrLf

            For Each cambio As DatosCambioEscandallo In ListaCambios

                If cambio.gDescripcion = "Cambio de cantidad" Then

                    texto = texto & cambio.gDescripcion & If(cambio.gDiferencia > 0, "+" & CStr(cambio.gDiferencia), CStr(cambio.gDiferencia)) & ": " & cambio.gArticulo & " (" & cambio.gcodArticulo & ") " & vbCrLf

                Else

                    texto = texto & cambio.gDescripcion & ": " & cambio.gArticulo & " (" & cambio.gcodArticulo & ") " & vbCrLf

                End If

            Next

            If ListaEscandallos.Count > 0 AndAlso MsgBox(texto & vbCrLf & vbCrLf & "¿Aplicar los cambios al resto de escandallos seleccionados?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                If VerificarCambiosPosibles() Then

                    Call PropagarCambioVersion()

                    MsgBox("Cambios realizados en todos los escandallos")

                    bPropagar.Enabled = False

                End If

            End If

            bPropagar.Enabled = False

        End If

        pbCarga.Visible = False

    End Sub

    Private Function VerificarCambiosPosibles() As Boolean
        Dim Texto As String
        For i = 0 To ListaEscandallos.Count - 1
            Texto = VerificarCambiosPosibles1(i)
            If Texto <> "" Then
                Dim iidEscandallo As Integer = ListaEscandallos(i)(0).gidEscandallo
                Texto = "ESCANDALLO DE " & funcES.Articulo(iidEscandallo) & vbCrLf & vbCrLf & Texto
                Texto = Texto & vbCrLf & vbCrLf & "¿Continuar con el proceso?"
                If MsgBox(Texto, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    Return False
                End If
            End If
            pbCarga.Increment(2)
        Next
        Return True
    End Function

    Private Function VerificarCambiosPosibles1(ByVal indice As Integer) As String
        Dim cantidad As Double
        Dim Texto As String = ""
        For Each cambio As DatosCambioEscandallo In ListaCambios
            cantidad = CantidadEnEscandallo(cambio.gidArticulo, indice)
            Select Case cambio.gDescripcion
                Case "Componente eliminado"
                    If cantidad = 0 Then
                        Texto = Texto & "No se puede eliminar " & cambio.gArticulo & " porque no está en el escandallo"
                    End If
                Case "Cambio de cantidad"
                    If cantidad = 0 Then
                        Texto = Texto & "No se puede cambiar la cantidad de " & cambio.gArticulo & " porque no está en el escandallo"
                    ElseIf cantidad + cambio.gDiferencia < 0 Then
                        Texto = Texto & "No se puede cambiar la cantidad de " & cambio.gArticulo & " porque la diferencia es mayor que la cantidad"
                    End If
                Case "Nuevo componente"

            End Select
        Next
        Return Texto
    End Function

    Private Sub PropagarCambioVersion()
        Dim CosteTotalMaterial As Double
        Dim CosteTotalTiempo As Double
        Dim iidEscandallo As Integer
        Dim aviso As Boolean = False
        Dim FechaCambio As Date
        For i = 0 To ListaEscandallos.Count - 1
            Call PropagarCambio1(i)
            iidEscandallo = ListaEscandallos(i)(0).gidEscandallo
            CosteTotalMaterial = funcES.CosteEU(iidEscandallo, aviso, FechaCambio)
            CosteTotalTiempo = funcTI.TotalCoste(iidEscandallo, True)
            ActualizaPrecioAR(funcES.idArticulo(iidEscandallo), CosteTotalMaterial + CosteTotalTiempo, funcES.VersionEscandallo(iidEscandallo))
            pbCarga.Increment(5)
        Next
    End Sub

    Private Sub PropagarCambio1(ByVal indice As Integer)
        'Dim listaConceptos As List(Of DatosConceptoEscandallo) = ListaEscandallos(indice)
        Dim iidEscandallo As Integer = ListaEscandallos(indice)(0).gidEscandallo
        Dim cantidad As Double
        For Each cambio As DatosCambioEscandallo In ListaCambios
            cantidad = CantidadEnEscandallo(cambio.gidArticulo, indice)
            Select Case cambio.gDescripcion
                Case "Componente eliminado"
                    If cantidad > 0 Then
                        funcCE.BorrarComponente(iidEscandallo, cambio.gidArticulo)
                    End If
                Case "Cambio de cantidad"
                    If cantidad + cambio.gDiferencia < 0 Then
                        'Si no hay cantidad suficiente, eliminamos el componente
                        funcCE.BorrarComponente(iidEscandallo, cambio.gidArticulo)
                    Else
                        funcCE.CambiarCantidad(iidEscandallo, cambio.gidArticulo, cambio.gDiferencia)
                    End If
                Case "Nuevo componente"
                    Dim nuevoConcepto As DatosConceptoEscandallo = funcCE.Mostrar1(cambio.gidConceptoOrigen)
                    nuevoConcepto.gidEscandallo = iidEscandallo
                    funcCE.insertar(nuevoConcepto)
            End Select
        Next
    End Sub

    Private Sub ExtraerCambios()
        EscandalloActual = funcCE.Mostrar(idEscandallo.Text, True, 0)
        ListaCambios = New List(Of DatosCambioEscandallo)
        Dim Cantidad As Double = 0
        Dim dtsActual As DatosConceptoEscandallo
        For Each dts As DatosConceptoEscandallo In EscandalloOriginal
            Cantidad = CantidadEnEscandalloActual(dts.gidArticulo)
            dtsActual = dtsEnEscandalloOriginal(dts.gidArticulo, dts.gCantidad)
            If Cantidad = -1 Then
                ListaCambios.Add(New DatosCambioEscandallo(dts.gidArticulo, dts.gCantidad, Cantidad, "Componente eliminado", dts.gcodArticulo, dts.gArticulo, dts.gidConcepto))
            ElseIf dts.gCantidad <> Cantidad Then

                ListaCambios.Add(New DatosCambioEscandallo(dts.gidArticulo, dts.gCantidad, Cantidad, "Cambio de cantidad", dts.gcodArticulo, dts.gArticulo, dts.gidConcepto))
            End If
        Next
        For Each dts As DatosConceptoEscandallo In EscandalloActual
            Cantidad = CantidadEnEscandalloOriginal(dts.gidArticulo)
            If Cantidad = -1 Then
                ListaCambios.Add(New DatosCambioEscandallo(dts.gidArticulo, Cantidad, dts.gCantidad, "Nuevo componente", dts.gcodArticulo, dts.gArticulo, dts.gidConcepto))
            End If
        Next

    End Sub

    Private Function CantidadEnEscandalloOriginal(ByVal iidArticulo As Integer) As Double
        Dim Cantidad As Double = -1
        For Each dts As DatosConceptoEscandallo In EscandalloOriginal
            If dts.gidArticulo = iidArticulo Then
                If Cantidad = -1 Then Cantidad = 0
                Cantidad = Cantidad + dts.gCantidad
            End If
        Next
        Return Cantidad
    End Function

    Private Function dtsEnEscandalloOriginal(ByVal iidArticulo As Integer, ByVal Cantidad As Integer) As DatosConceptoEscandallo
        For Each dts As DatosConceptoEscandallo In EscandalloOriginal
            If dts.gidArticulo = iidArticulo And dts.gCantidad = Cantidad Then
                Return dts
            End If
        Next
        Return Nothing
    End Function

    Private Function CantidadEnEscandalloActual(ByVal iidArticulo As Integer) As Double
        Dim Cantidad As Double = -1
        For Each dts As DatosConceptoEscandallo In EscandalloActual
            If dts.gidArticulo = iidArticulo Then
                If Cantidad = -1 Then Cantidad = 0
                Cantidad = Cantidad + dts.gCantidad
            End If
        Next
        Return Cantidad
    End Function

    Private Function LineasEnEscandalloActual(ByVal iidArticulo As Integer) As Integer
        Dim Contador As Double = 0
        For Each dts As DatosConceptoEscandallo In EscandalloActual
            If dts.gidArticulo = iidArticulo Then
                Contador = Contador + 1
            End If
        Next
        Return Contador
    End Function

    Private Function CantidadEnEscandallo(ByVal iidArticulo As Integer, ByVal indice As Integer) As Double
        Dim Cantidad As Double = -1
        For Each dts As DatosConceptoEscandallo In ListaEscandallos(indice)
            If dts.gidArticulo = iidArticulo Then
                If Cantidad = -1 Then Cantidad = 0
                Cantidad = Cantidad + dts.gCantidad
            End If
        Next
        Return Cantidad
    End Function

#End Region

#Region "EVENTOS"

    Private Sub lvConceptos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptos.ColumnClick
        direccion = "ASC"
        If (lvwColumnSorter.Order = SortOrder.Ascending) Then
            lvwColumnSorter.Order = SortOrder.Descending
            direccion = "DESC"
        Else
            lvwColumnSorter.Order = SortOrder.Ascending
            direccion = "ASC"
        End If
        'Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
        lvwColumnSorter.SortColumn = e.Column
        Select Case e.Column
            Case 1
                orden = "seccion " & direccion
            Case 2
                orden = "codArticulo " & direccion
            Case 3
                orden = "familia " & direccion
            Case 4
                orden = "subfamilia " & direccion
            Case 5
                orden = "concepto " & direccion
        End Select

        Me.lvConceptos.Sort()
    End Sub

    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick, lvTiempos.DoubleClick
        If indice <> -1 Then
            Call MostrarArticuloC()
            Call CalculaTotal()
        End If
    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click, lvConceptos.SelectedIndexChanged
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            llenarCampos(lvConceptos.Items(indice).Text)
        End If
    End Sub

    Public Function llenarCampos(ByVal iidarticulo As Integer) As Boolean

        Try

            indice = lvConceptos.SelectedIndices(0)

            Dim dts As DatosConceptoEscandallo = funcCE.Mostrar1(iidarticulo)

            iidArticuloC = dts.gidArticulo

            txSeccion.Text = dts.gSeccion

            txFamilia.Text = dts.gFamilia

            txCodMateriaPrima.Text = dts.gcodArticulo

            txMateriaPrima.Text = dts.gArticulo

            txSubFamila.Text = dts.gsubFamilia

            lbUnidad.Text = dts.gTipoUnidad

            Cantidad.Text = dts.gCantidad

            ObservacionesC.Text = dts.gObservaciones

            ckActivoC.Checked = dts.gActivo

            Coste.Text = FormatNumber(dts.gCoste, 4)

            lbMonedaC.Text = dts.gsimbolo

        Catch ex As Exception

            MsgBox("Error al llenar campos" & ex.Message, MsgBoxStyle.Critical)

            Return False

        End Try

    End Function

    Private Sub lvTiempos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTiempos.SelectedIndexChanged, lvTiempos.Click
        If lvTiempos.SelectedItems.Count > 0 Then
            indiceT = lvTiempos.SelectedIndices(0)
            Dim dts As DatosTiempoEscandallo = funcTI.Mostrar1(lvTiempos.Items(indiceT).Text)
            cbSeccionT.Text = dts.gSeccion
            ObservacionesT.Text = dts.gObservaciones
            PrecioHora.Text = FormatNumber(dts.gPrecioHora, 4)
            Horas.Text = FormatNumber(dts.gHoras, 2)
        End If
    End Sub

    Private Sub ckActivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckActivo.CheckedChanged

        cambios = True

        'dtpFechaBaja.Value = If(Not IsDate(dtsES.gFechaBaja), Now, dtsES.gFechaBaja)
        dtpFechaBaja.Value = Now

        dtpFechaBaja.Visible = (Not ckActivo.Checked)

        lbFechaBaja.Visible = (Not ckActivo.Checked)


    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        If e.KeyChar = vbCr Then
            Call GuardarConcepto()
        End If
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Cantidad.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Horas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Horas.KeyPress
        If e.KeyChar = vbCr Then
            Call GuardarConcepto()
        End If
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Horas.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click, Coste.Click, Horas.Click
        sender.SelectAll()
    End Sub

    Private Sub cbCodArticulo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaBaja.ValueChanged, dtpFechaAlta.ValueChanged, cbTipoEscandallo.SelectedIndexChanged, observaciones.TextChanged
        cambios = True
    End Sub

    Private Sub lbCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCambio.Click
        Dim GG As New GestionCambioMoneda
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call CalculaTotal()
    End Sub

    Private Sub cbSeccionT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeccionT.SelectionChangeCommitted
        If cbSeccionT.SelectedIndex <> -1 Then
            PrecioHora.Text = FormatNumber(cbSeccionT.SelectedItem.gprecioHora, 2)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckSubEscandallos.CheckedChanged
        CargarConceptos()
    End Sub

    Private Sub bEscandalloCompleto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEscandalloCompleto.Click

        Dim gg As New escandallosCompletos

        gg.idescandallo = idEscandallo.Text

        gg.txEscandallo.Text = txEscandallo.Text

        gg.txVersion.Text = Version.Text

        gg.ShowDialog()

    End Sub

#End Region

End Class



















































