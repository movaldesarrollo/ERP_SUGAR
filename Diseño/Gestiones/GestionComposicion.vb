

Public Class GestionComposicion

    'Private funcES As New FuncionesEscandallos
    'Private funcCE As New FuncionesConceptosComp
    Private funcES As New FuncionesEscandallos
    Private funcCE As New FuncionesConceptosEscandallos
    Private funcAR As New FuncionesArticulos
    Private funcMO As New FuncionesMoneda
    Private funcTE As New FuncionesTiposEscandallos
    Private funcPE As New FuncionesPersonal
    Private iidArticuloBase As Integer 'Es el artículo base sobre el que se añaden las opciones
    Private iidArticulo As Integer 'es la id del Articulo compuesto
    Private iidArticuloC As Integer 'Es la id de un artículo Opción
    Private indice As Integer
    Private iidConcepto As Integer
    Private ep1 As New ErrorProvider
    Private G_AGeneral As Char
    Private NuevoCodigo As String
    Private NuevoNombre As String
    Private NuevoNombreEN As String
    Private NuevaDescripcion As String
    Private NuevaDescripcionEN As String
    Private NuevoPrecio As Double
    Private NuevoCoste As Double
    Private dtsAR As DatosArticulo    'Articulo compuesto
    Private dtsARB As DatosArticulo  'Artículo base
    Private dtsAC As DatosArticulo  'Artículo opción
    Private dtsES As DatosEscandallo
    Private iidEscandallo As Integer
    Private DI As New DatosIniciales
    Private listaC As List(Of DatosConceptoEscandallo)
    Private vSoloLectura As Boolean
    Private desktopsize As Size
    Private Cambios As Boolean
    Private VersionEscandallo As Integer


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Public Property pidEscandallo() As Integer
        Get
            Return iidEscandallo
        End Get
        Set(ByVal value As Integer)
            iidEscandallo = value
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

    Private Sub GestionComposicion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bGuardar.Enabled Then
            If Cambios Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If
    End Sub



    Private Sub Escandallo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bGuardar.Enabled = Not vSoloLectura
        desktopsize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopsize.Height < 800 Then
            Me.Height = desktopsize.Height - 50
        Else
            Me.Height = 750
        End If

        'Aplicación del permiso de cambio de PVP, para que no se pueda cambiar el PVP del artículo compuesto
        If funcPE.Parametro(Inicio.vIdUsuario, "BusquedaArticulo", "CAMBIAR PVP") Then
            PVPComp.ReadOnly = False
        Else
            PVPComp.ReadOnly = True
        End If

        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        Call CargarArticulosC()
        Call InicializarGeneral()
        Call LimpiarEdicion()

        If iidArticulo > 0 Or iidEscandallo > 0 Then
            G_AGeneral = "A"
            If iidEscandallo = 0 Then
                iidEscandallo = funcES.ExisteEscandallo(iidArticulo)
            End If
            'Si hemos abierto un escandallo de opciones, no podemos cambiar la composición
            bMasOpcion.Enabled = False
            bMenosOpcion.Enabled = False
            Call CargarEscandallo()

        ElseIf iidArticuloBase > 0 Then 'Nueva composición
            G_AGeneral = "G"
            Call CargaArticuloBase()
            iidArticuloC = DI.idArticuloOpcionBase
            dtsAR = funcAR.Mostrar1(iidArticuloC) 'Articulo opción que indica opción base
            cbCodArticuloC.Text = dtsAR.gcodArticulo
            cbArticuloC.Text = dtsAR.gArticulo
            lbUnidad.Text = dtsAR.gTipoUnidad
            If Cantidad.Text = "0" Then Cantidad.Text = 1
            listaC = New List(Of DatosConceptoEscandallo)
            dtsES = New DatosEscandallo
        End If

    End Sub


#Region "INICIALIZACIÓN"

    Private Sub InicializarGeneral()
        ArticuloComp.Text = ""
        ArticuloEN.Text = ""
        Descripcion.Text = ""
        DescripcionEN.Text = ""
        codArticuloComp.Text = ""
        PVP.Text = 0
        PVPComp.Text = 0
        iidArticulo = 0
        'Crearemos la opción con la última versión del artículo base
        Dim idEscandalloUltimaVersionArticuloBase As Integer = funcES.ExisteEscandalloVersionUltima(iidArticuloBase, Now.Year)
        VersionEscandallo = funcES.VersionEscandallo(idEscandalloUltimaVersionArticuloBase)
        Version.Text = VersionEscandallo
        If VersionEscandallo < Now.Year Then
            If MsgBox("La última versión del artículo base es la " & VersionEscandallo & "." & vbCrLf & "Si desea la versión " & Now.Year & " , debe crearla previamente para el artículo base." & vbCrLf & "Si continúa, se creará el nuevo artículo con la versión " & VersionEscandallo, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                Cambios = False
                Me.Close()
            End If
        End If
        lvConceptos.Items.Clear()
        listaC = New List(Of DatosConceptoEscandallo)
    End Sub

    Private Sub LimpiarEdicion()
        ep1.Clear()

        cbArticuloC.Text = ""
        cbArticuloC.SelectedIndex = -1
        cbCodArticuloC.Text = ""
        cbCodArticuloC.SelectedIndex = -1
        Cantidad.Text = 0
        lbUnidad.Text = "U."
        iidArticuloC = 0
        indice = -1
        iidConcepto = 0
        dtsAC = New DatosArticulo
        'Orden.Text = lvConceptos.Items.Count + 1
    End Sub

    Private Sub CargarArticulosC()
        cbCodArticuloC.Items.Clear()
        cbCodArticuloC.Text = ""
        cbCodArticuloC.SelectedIndex = -1
        cbArticuloC.Items.Clear()
        cbArticuloC.Text = ""
        cbArticuloC.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("OPCION")
        For Each dts As IDComboBox3 In lista
            cbArticuloC.Items.Add(dts)
            cbCodArticuloC.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub

#End Region


#Region "CARGAR DATOS"

    Private Sub CargaArticuloBase()
        If iidArticuloBase > 0 Then
            dtsARB = funcAR.Mostrar1(iidArticuloBase)
            codArticuloBase.Text = dtsARB.gcodArticulo
            ArticuloBase.Text = dtsARB.gArticulo
            codArticuloComp.Text = dtsARB.gcodArticulo
            ArticuloComp.Text = dtsARB.gArticulo
            ArticuloEN.Text = dtsARB.gArticuloEN
            Descripcion.Text = dtsARB.gDescripcion
            DescripcionEN.Text = dtsARB.gDescripcionEN
            PVP.Text = FormatNumber(dtsARB.gPrecioUnitarioV, 2)
            lbMoneda.Text = dtsARB.gSimboloV
            lbMonedaComp.Text = dtsARB.gSimboloV
            PVPComp.Text = PVP.Text
            Cambios = False
        End If
    End Sub

    Private Sub CargarEscandallo()
        dtsES = funcES.Mostrar1(iidEscandallo)
        iidArticuloBase = dtsES.gidArticuloBase
        iidArticulo = dtsES.gidArticulo
        dtsAR = funcAR.Mostrar1(iidArticulo)
        codArticuloComp.Text = dtsES.gcodArticulo
        ArticuloComp.Text = dtsES.gArticulo
        ArticuloEN.Text = dtsAR.gArticuloEN
        Descripcion.Text = dtsAR.gDescripcion
        DescripcionEN.Text = dtsAR.gDescripcionEN
        PVPComp.Text = FormatNumber(dtsAR.gPrecioUnitarioV, 2) '& dtsAR.gSimboloV
        lbMoneda.Text = dtsAR.gSimboloV
        dtsARB = funcAR.Mostrar1(iidArticuloBase)
        codArticuloBase.Text = dtsARB.gcodArticulo
        ArticuloBase.Text = dtsARB.gArticulo
        PVP.Text = FormatNumber(dtsARB.gPrecioUnitarioV, 2) '& dtsARB.gSimboloV
        lbMonedaComp.Text = dtsARB.gSimboloV
        VersionEscandallo = dtsES.gVersionEscandallo
        Call CargarOpciones()
        Cambios = False
    End Sub

    Private Sub CargarOpciones()
        lvConceptos.Items.Clear()
        NuevoCodigo = dtsAR.gcodArticulo
        NuevoNombre = dtsAR.gArticulo
        NuevoNombreEN = dtsAR.gArticuloEN
        NuevaDescripcion = dtsAR.gDescripcion
        NuevaDescripcionEN = dtsAR.gDescripcionEN
        listaC = funcCE.Mostrar(iidEscandallo, True, iidArticuloBase)
        For Each dts As DatosConceptoEscandallo In listaC
            Call nuevalineaLV(dts)
        Next
    End Sub

    Private Sub nuevalineaLV(ByVal dts As DatosConceptoEscandallo)
        With lvConceptos.Items.Add(dts.gidConcepto)
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(dts.gCantidad & dts.gTipoUnidad)
            '.SubItems.Add(dts.gOrden)
            .SubItems.Add(FormatNumber(dts.gPrecioOpcion, 2) & dts.gSimboloV)
            .SubItems.Add(dts.gCantidad)
            .EnsureVisible()
        End With


    End Sub

    Private Sub actualizarLV()
        'Actualiza LV en el INDICE y con los datos de listaC(indice)
        If indice <> -1 Then
            With lvConceptos.Items(indice)
                .SubItems(1).Text = listaC(indice).gidArticulo
                .SubItems(2).Text = listaC(indice).gcodArticulo
                .SubItems(3).Text = listaC(indice).gArticulo
                .SubItems(4).Text = listaC(indice).gCantidad & listaC(indice).gTipoUnidad
                .SubItems(5).Text = FormatNumber(listaC(indice).gPrecioOpcion, 2) & listaC(indice).gSimboloV
                .SubItems(6).Text = listaC(indice).gCantidad
            End With
        End If

    End Sub

    Private Sub Reescribir()
        NuevoCodigo = dtsARB.gcodArticulo
        NuevoNombre = dtsARB.gArticulo
        NuevoNombreEN = dtsARB.gArticuloEN
        NuevaDescripcion = dtsARB.gDescripcion
        NuevaDescripcionEN = dtsARB.gDescripcionEN
        NuevoPrecio = dtsARB.gPrecioUnitarioV
        NuevoCoste = dtsARB.gPrecioUnitarioC

        For Each dts As DatosConceptoEscandallo In listaC
            NuevoCodigo = NuevoCodigo & dts.gcodArticulo
            NuevoNombre = NuevoNombre & " " & dts.gArticulo
            NuevoNombreEN = NuevoNombreEN & " " & dts.gArticuloEN
            NuevaDescripcion = NuevaDescripcion & " " & dts.gDescripcion
            NuevaDescripcionEN = NuevaDescripcionEN & " " & dts.gDescripcionEN
            Dim AvisoM As Boolean

            NuevoPrecio = NuevoPrecio + dts.gCantidad * If(dts.gCodMonedaV = dtsARB.gcodMonedaV, dts.gPrecioOpcion, funcMO.Cambio(dts.gPrecioOpcion, dts.gCodMonedaV, dtsARB.gcodMonedaV, AvisoM, Now.Date))
            NuevoCoste = NuevoCoste + dts.gCantidad * If(dts.gcodMoneda = dtsARB.gcodMonedaC, dts.gCoste, funcMO.Cambio(dts.gCoste, dts.gcodMoneda, dtsARB.gcodMonedaC, AvisoM, Now.Date))

        Next
        Dim aviso As String
        aviso = If(NuevoCodigo.Length > 30, "El código es demasiado largo, se truncará", "")
        aviso = aviso & If(NuevoNombre.Length > 300, If(aviso = "", "", vbCrLf) & "El nombre es demasiado largo, se truncará", "")
        aviso = aviso & If(NuevoNombreEN.Length > 300, If(aviso = "", "", vbCrLf) & "El nombre inglés es demasiado largo, se truncará", "")
        aviso = aviso & If(NuevaDescripcion.Length > 400, If(aviso = "", "", vbCrLf) & "La descripción es demasiado larga, se truncará", "")
        aviso = aviso & If(NuevaDescripcionEN.Length > 400, If(aviso = "", "", vbCrLf) & "La descripción en ingés es demasiado larga, se truncará", "")
        If aviso.Length > 0 Then MsgBox(aviso)
        codArticuloComp.Text = Microsoft.VisualBasic.Left(NuevoCodigo, 30)
        ArticuloComp.Text = Microsoft.VisualBasic.Left(NuevoNombre, 300)
        ArticuloEN.Text = Microsoft.VisualBasic.Left(NuevoNombreEN, 300)
        Descripcion.Text = Microsoft.VisualBasic.Left(NuevaDescripcion, 400)
        DescripcionEN.Text = Microsoft.VisualBasic.Left(NuevaDescripcionEN, 400)
        PVPComp.Text = FormatNumber(NuevoPrecio, 2)

    End Sub


#End Region


#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Function GuardarEscandallo() As Boolean
        Dim validar As Boolean = True
        If lvConceptos.Items.Count = 0 Then
            validar = False
            ep1.SetError(lbOpciones, "Ha de existir alguna opción")
        Else
            Dim lista As New List(Of Integer) 'lista de idArticulos opciones
            Dim listaCantidades As New List(Of Int16) 'lista de la cantidad de cada artículo. Ha de ser paralela a la otra lista
            For Each item As ListViewItem In lvConceptos.Items
                lista.Add(item.SubItems(1).Text)
                listaCantidades.Add(item.SubItems(6).Text)
            Next
            Dim iidEscandallox As Integer = funcES.Comprobar(iidArticuloBase, lista, listaCantidades)
            If iidEscandallox > 0 And iidEscandallox <> iidEscandallo Then
                Dim dts As DatosEscandallo = funcES.Mostrar1(iidEscandallox)
                validar = False
                MsgBox("Existe un artículo (" & dts.gcodArticulo & ")  con la misma composición")
            End If

        End If
        If funcAR.codArticuloExiste(iidArticulo, codArticuloComp.Text) Then
            validar = False
            ep1.SetError(codArticuloComp, "Ya existe un artículo con este código")
        End If
        If codArticuloComp.Text.Length = 0 Then
            validar = False
            ep1.SetError(codArticuloComp, "Se ha de indicar el código del artículo")
        End If
        If ArticuloComp.Text.Length = 0 Then
            validar = False
            ep1.SetError(ArticuloComp, "Se ha de indicar un nombre para el artículo")
        End If
        If validar Then

            dtsES.gidEscandallo = iidEscandallo
            dtsES.gidArticulo = iidArticulo
            dtsES.gidArticuloBase = iidArticuloBase
            dtsES.gcodEscandallo = codArticuloComp.Text
            dtsES.gEscandallo = ArticuloComp.Text
            dtsES.gidArticuloBase = iidArticuloBase
            dtsES.gVersionEscandallo = VersionEscandallo
            dtsAR = funcAR.Clonar(dtsARB) 'Inicializamos el artículo con el artículo base
            dtsAR.gidArticulo = iidArticulo
            dtsAR.gArticulo = ArticuloComp.Text
            dtsAR.gcodArticulo = codArticuloComp.Text
            dtsAR.gArticuloEN = ArticuloEN.Text
            dtsAR.gDescripcion = Descripcion.Text
            dtsAR.gDescripcionEN = DescripcionEN.Text
            dtsAR.gPrecioUnitarioV = PVPComp.Text 'NuevoPrecio
            dtsAR.gFechaPrecioV = Now.Date
            dtsAR.gPrecioUnitarioC = NuevoCoste
            dtsAR.gFechaPrecioC = Now.Date
            dtsAR.gEscandallo = True

            'Otros datos del artículo vienen del artículo base
            If G_AGeneral = "G" Then
                dtsES.gFechaAlta = Now.Date
                dtsES.gFechaBaja = Now.Date
                dtsES.gActivo = dtsAR.gActivo
                dtsES.gidTipoEscandallo = funcTE.idTipoComposicion
                dtsES.gObservaciones = ""

                dtsAR.gFechaAlta = Now.Date
                dtsAR.gFechaBaja = Now.Date


                iidArticulo = funcAR.insertar(dtsAR) 'Insertamos el nuevo artículo
                dtsAR.gidArticulo = iidArticulo
                dtsES.gidArticulo = iidArticulo
                iidEscandallo = funcES.insertar(dtsES) 'Pasamos el dts por referencia, nos lo devuelve con el idArticulo y el idEscandallo nuevos
                dtsES.gidEscandallo = iidEscandallo

                G_AGeneral = "A"

            Else

                funcES.actualizar(dtsES)
                funcAR.actualizar(dtsAR)
                funcCE.BorrarEscandallo(iidEscandallo)

            End If
            'cargar la composición

            'Primero el artículo base
            Dim orden As Integer = 1
            Dim dtsCEB As New DatosConceptoEscandallo
            dtsCEB.gidEscandallo = iidEscandallo
            dtsCEB.gidArticulo = iidArticuloBase
            dtsCEB.gcodConcepto = dtsARB.gcodArticulo
            dtsCEB.gConcepto = dtsARB.gArticulo
            dtsCEB.gCantidad = 1
            dtsCEB.gidSeccion = dtsARB.gidSeccion
            dtsCEB.gObservaciones = ""
            dtsCEB.gOrden = orden
            dtsCEB.gActivo = True
            dtsCEB.gidConcepto = funcCE.insertar(dtsCEB)
            'A continuación las opciones
            For Each dts As DatosConceptoEscandallo In listaC
                orden = orden + 1
                dts.gidEscandallo = iidEscandallo
                dts.gOrden = orden
                dts.gidConcepto = funcCE.insertar(dts)
            Next
            funcES.actualizar(dtsES)
            MsgBox("Composición guardada correctamente")
            bGuardar.Enabled = False
            'Me.Close()
            Cambios = False
        End If

        Return validar

    End Function

    Private Function GuardarConcepto() As Boolean
        'Guarda el concepto y modifica código y nombre
        Dim validar As Boolean = True

        If iidArticuloC = 0 Then
            validar = False
            ep1.SetError(cbArticuloC, "Se ha de seleccionar un artículo")
        Else
            For Each item As ListViewItem In lvConceptos.Items
                If item.Index <> indice And item.SubItems(1).Text = iidArticuloC Then
                    validar = False
                    ep1.SetError(cbArticuloC, "La opción ya está en la lista")
                End If
            Next
        End If


        If validar Then


            'Dim iidConcepto As Integer = If(indice = -1, 0, CInt(lvConceptos.Items(indice).Text))
            Dim dts As New DatosConceptoEscandallo
            dts.gidConcepto = iidConcepto
            dts.gArticulo = cbArticuloC.Text
            dts.gCantidad = Cantidad.Text
            dts.gcodArticulo = cbCodArticuloC.Text
            dts.gidArticulo = iidArticuloC
            dts.gidEscandallo = iidEscandallo
            dts.gActivo = True
            'dts.gOrden = Orden.Text
            dts.gTipoUnidad = funcAR.TipoUnidad(iidArticuloC)
            If iidConcepto = 0 Then
                iidConcepto = funcCE.insertar(dts)
            Else
                funcCE.actualizar(dts)
            End If

            Call CargarOpciones()
        End If

    End Function



#End Region




#Region "BOTONES "



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        Call LimpiarEdicion()
        Call InicializarGeneral()

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If bMasOpcion.Enabled = False Then
            NuevoCoste = dtsARB.gPrecioUnitarioC

            Dim AvisoM As Boolean
            For Each dts As DatosConceptoEscandallo In listaC
                NuevoCoste = NuevoCoste + dts.gCantidad * If(dts.gcodMoneda = dtsARB.gcodMonedaC, dts.gCoste, funcMO.Cambio(dts.gCoste, dts.gcodMoneda, dtsARB.gcodMonedaC, AvisoM, Now.Date))
            Next

        End If

        Call GuardarEscandallo()

    End Sub

    Private Sub bVerArticuloBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticuloBase.Click
        Dim GG As New GestionArticulo
        GG.SoloLectura = vSoloLectura
        GG.pidArticulo = iidArticuloBase
        GG.ShowDialog()
        If iidArticuloBase > 0 Then
            dtsARB = funcAR.Mostrar1(iidArticuloBase)
            codArticuloBase.Text = dtsARB.gcodArticulo
            ArticuloBase.Text = dtsARB.gArticulo
            PVP.Text = FormatNumber(dtsARB.gPrecioUnitarioV, 2)
            lbMoneda.Text = dtsARB.gSimboloV
            lbMonedaComp.Text = dtsARB.gSimboloV
        End If


    End Sub


    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticulo.Click
        If iidArticulo > 0 Then
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.ShowDialog()

        End If
    End Sub


    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call LimpiarEdicion()
    End Sub

    Private Sub bMasOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMasOpcion.Click
        ep1.Clear()
        Dim validar As Boolean = True

        If iidArticuloC = 0 Then
            validar = False
            ep1.SetError(cbArticuloC, "Se ha de seleccionar un artículo")
        Else
            For Each item As ListViewItem In lvConceptos.Items
                If item.Index <> indice And item.SubItems(1).Text = iidArticuloC Then
                    validar = False
                    ep1.SetError(cbArticuloC, "La opción ya está en la lista")
                End If
            Next
        End If

        If validar Then


            Dim dts As New DatosConceptoEscandallo
            dts.gArticulo = cbArticuloC.Text
            dts.gCantidad = Cantidad.Text
            dts.gcodArticulo = cbCodArticuloC.Text
            dts.gidArticulo = iidArticuloC
            dts.gidEscandallo = iidEscandallo
            dts.gTipoUnidad = lbUnidad.Text
            dts.gArticuloEN = dtsAC.gArticuloEN
            dts.gDescripcion = dtsAC.gDescripcion
            dts.gDescripcionEN = dtsAC.gDescripcionEN
            dts.gPrecioOpcion = dtsAC.gPrecioOpcion
            dts.gCodMonedaV = dtsAC.gcodMonedaV
            dts.gSimboloV = dtsAC.gSimboloV
            dts.gCoste = dtsAC.gPrecioUnitarioC
            dts.gcodMoneda = dtsAC.gcodMonedaC
            dts.gsimbolo = dtsAC.gSimboloC
            dts.gcodConcepto = dts.gcodArticulo
            dts.gConcepto = dts.gArticulo
            dts.gObservaciones = ""
            dts.gSeccion = dtsAC.gidSeccion
            dts.gActivo = True
            If indice = -1 Then
                'Nueva opción
                dts.gidConcepto = 0
                dts.gOrden = lvConceptos.Items.Count + 1
                listaC.Add(dts)
                Call nuevalineaLV(dts)
            Else
                'Verificar que no está ya la opcíón

                dts.gidConcepto = listaC(indice).gidConcepto
                dts.gOrden = listaC(indice).gOrden
                listaC(indice) = dts
                Call actualizarLV()

            End If
            Call Reescribir()
            Cambios = True
        End If

        Call LimpiarEdicion()





        'Call GuardarConcepto()
        'codArticuloComp.Text = NuevoCodigo
        'ArticuloComp.Text = NuevoNombre
        'ArticuloEN.Text = NuevoNombreEN
        'Descripcion.Text = NuevaDescripcion
        'DescripcionEN.Text = NuevaDescripcionEN
        'Call GuardarEscandallo()
        'Call CargarEscandallo()
        'Call LimpiarEdicion()
    End Sub


    Private Sub bMenosOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMenosOpcion.Click
        If indice <> -1 Then
            ep1.Clear()
            listaC.RemoveAt(indice)
            lvConceptos.Items.RemoveAt(indice)
            Call LimpiarEdicion()
            Call Reescribir()
            Cambios = True
        End If
    End Sub


    Private Sub bLimpiaOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiaOpcion.Click
        Call LimpiarEdicion()
    End Sub




    Private Sub bBuscarOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscarOpcion.Click
        Dim GG As New BusquedaSimpleArticulo
        GG.SoloLectura = vSoloLectura
        GG.pModo = "OPCIONES"
        GG.pidArticulo = 0
        GG.ShowDialog()
        If GG.pidArticulo > 0 Then
            iidArticuloC = GG.pidArticulo
            dtsAC = funcAR.Mostrar1(iidArticuloC)
            cbCodArticuloC.Text = dtsAC.gcodArticulo
            cbArticuloC.Text = dtsAC.gArticulo
            lbUnidad.Text = dtsAC.gTipoUnidad
            If Cantidad.Text = "0" Then Cantidad.Text = 1
        End If
    End Sub


    Private Sub bVerArticuloOpcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticuloOpcion.Click
        If cbArticuloC.SelectedIndex <> -1 Then
            iidArticuloC = cbArticuloC.SelectedItem.itemdata
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidarticuloC
            GG.ShowDialog()
            Call CargarArticulosC()
            Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticuloC)
            If GG.pidArticulo > 0 Then
                iidArticuloC = GG.pidArticulo
                dtsAC = funcAR.Mostrar1(iidArticuloC)
                cbArticuloC.Text = dtsAC.gArticulo
                lbUnidad.Text = dtsAC.gTipoUnidad
                If Cantidad.Text = "0" Then Cantidad.Text = 1
            End If
        End If
    End Sub

#End Region


#Region "EVENTOS"

    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticuloC.SelectionChangeCommitted
        If cbCodArticuloC.SelectedIndex <> -1 Then
            iidArticuloC = cbCodArticuloC.SelectedItem.itemdata
            dtsAC = funcAR.Mostrar1(iidArticuloC)
            cbArticuloC.Text = dtsAC.gArticulo
            lbUnidad.Text = dtsAC.gTipoUnidad
            If Cantidad.Text = "0" Then Cantidad.Text = 1
        End If

    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticuloC.SelectionChangeCommitted
        If cbArticuloC.SelectedIndex <> -1 Then
            iidArticuloC = cbArticuloC.SelectedItem.itemdata
            dtsAC = funcAR.Mostrar1(iidArticuloC)
            cbCodArticuloC.Text = dtsAC.gcodArticulo
            lbUnidad.Text = dtsAC.gTipoUnidad
            If Cantidad.Text = "0" Then Cantidad.Text = 1
        End If

    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click, lvConceptos.SelectedIndexChanged
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            iidArticuloC = lvConceptos.Items(indice).SubItems(1).Text
            'Dim iidConcepto As Integer = lvConceptos.Items(indice).Text
            'If iidConcepto > 0 Then
            '    Dim dts As DatosConceptoEscandallo = funcCE.Mostrar1(iidConcepto)
            'End If
            lbUnidad.Text = listaC(indice).gTipoUnidad
            'iidConcepto = listaC(indice).gidConcepto
            cbCodArticuloC.Text = listaC(indice).gcodArticulo
            cbArticuloC.Text = listaC(indice).gArticulo
            Cantidad.Text = listaC(indice).gCantidad
            dtsAC = funcAR.Mostrar1(iidArticuloC)
        End If

    End Sub

    Private Sub Cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cantidad.Click
        sender.selectAll()
    End Sub

    Private Sub PVPComp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PVPComp.TextChanged, DescripcionEN.TextChanged, Descripcion.TextChanged, ArticuloEN.TextChanged, ArticuloComp.TextChanged, codArticuloComp.TextChanged
        Cambios = True
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

#End Region







End Class