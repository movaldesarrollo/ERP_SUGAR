Public Class BusquedaSimpleArticulo

#Region "VARIABLES"

    Private funcAR As New FuncionesArticulos
    Private funcTI As New FuncionesTiposArticulo
    Private funcSP As New FuncionessubTiposArticulo
    Private funcTC As New FuncionesTipoCompra
    Private funcAP As New FuncionesArticulosProv
    Private funcPR As New funcionesProveedores
    Private funcAL As New FuncionesAlmacenes
    Private funcFA As New FuncionesFamilias
    Private funcSF As New FuncionessubFamilias
    Private funcSE As New FuncionesSecciones
    Private iidTipoArticulo As Integer
    Private iidsubTipoArticulo As Integer
    Private iidFamilia As Integer
    Private iidTipoCompra As Integer
    Public iidArticulo As Integer
    Private vSoloLectura As Boolean
    Private sBusqueda As String
    Private Orden As String = ""
    Private Direccion As String
    Private modo As String
    Private iidArticuloProv As Integer
    Private iidProveedor As Integer
    Public sCodArticulo As String
    Private semaforo As Boolean
    Private colorInactivo As Color
    Private columna As Integer
    Private Articulos As List(Of Integer)
    Private VerCostes As Boolean
    Dim retardo As New Timer
    Dim BuscarAhora As Boolean

#End Region

#Region "PROPIEDADES"

    Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property

    Property pidArticuloProv() As Integer
        Get
            Return iidArticuloProv
        End Get
        Set(ByVal value As Integer)
            iidArticuloProv = value
        End Set
    End Property

    Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
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

    Property pCodArticulo() As String
        Get
            Return sCodArticulo
        End Get
        Set(ByVal value As String)
            sCodArticulo = value
        End Set
    End Property

#End Region

#Region "CARGA Y CIERRE"

    'Carga del formulario.
    Private Sub BusquedaArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dimensiona el formulario.
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        'Revisa los permisos
        Dim funcPE As New FuncionesPersonal
        VerCostes = funcPE.Parametro(Inicio.vIdUsuario, "BusquedaArticulo", "VER COSTES")

        Articulos = New List(Of Integer)

        If iidProveedor > 0 Then
            Me.Text = Me.Text & " DE " & UCase(funcPR.campoProveedor(iidProveedor))
        End If

        'BuscarAhora = False

        'AddHandler retardo.Tick, AddressOf BusquedaRetardada
        'retardo.Interval = 500 'en milisegundos
        'retardo.Enabled = False

        colorInactivo = Color.Gray 'Color de los articulos inactivos

        cbTipo.Sorted = True 'Orden automatico en combobox tipo.
        cbSubTipo.Sorted = True 'Orden automatico en combobox subtipo.

        semaforo = True 'Se activa el semaforo

        'Desactivamos los check
        ckComprable.Checked = False
        ckVendible.Checked = False
        ckSubEnsamblado.Checked = False
        ckEscandallo.Checked = False
        ckOpcion.Checked = False

        'Si entra en modo materia prima.
        If modo = "MP" Then
            ckMateriaPrima.Checked = True 'Activamos el check Materia prima.
            ckMateriaPrima.Enabled = False 'Desactivamos el check.
            Me.Text = "BÚSQUEDA DE MATERIAS PRIMAS" 'Cambiamos el titulo.
        Else
            ckMateriaPrima.Checked = False 'Desactivamos el check.
        End If

        'Si entra en modo escandallo.
        If modo = "ESCANDALLO" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS CON ESCANDALLO" 'Cambiamos el titulo.
            ckEscandallo.Checked = True 'Activamos el check escandallo.
            ckEscandallo.Enabled = False 'Desactivamos el check.
        End If

        'Si entra en modo concepto.
        If modo = "CONCEPTO" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS VENDIBLES" 'Cambiamos el titulo.
            ckVendible.Checked = True 'Activamos el check concepto.
            ckVendible.Enabled = False 'Desactivamos el check.
        End If

        If modo = "COMPRABLE" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS COMPRABLES" 'Cambiamos el titulo.
            ckComprable.Checked = True 'Activamos el check comprable.
            ckComprable.Enabled = False 'Desactivamos el check.
        End If

        If modo = "MPCOMPRABLE" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS COMPRABLES" 'Cambiamos el titulo.
            ckComprable.Checked = True 'Activamos el check mpcomprable.
            ckComprable.Enabled = False 'Desactivamos el check.
            ckMateriaPrima.Checked = True
        End If

        If modo = "OPCIONES" Then
            Me.Text = "BÚSQUEDA DE ARTÍCULOS OPCIONES" 'Cambiamos el titulo.
            ckOpcion.Checked = True 'Activamos el check opciones.
            ckOpcion.Enabled = False 'Desactivamos el check.
        End If

        'Estado boton segun permiso sololectura.
        bNuevo.Enabled = Not vSoloLectura

        'Orden y direccion inicial de busqueda SQL
        Orden = "Articulo"
        Direccion = "ASC"


        If ckMateriaPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
            lbTipo.Text = "FAMILIA"
            lbSubTipo.Text = "SUBFAMILIA"
            lvArticulos.Columns(4).Text = "FAMILIA"
            lvArticulos.Columns(5).Text = "SUBFAMILIA"
            Call IntroducirFamilias()
            Call IntroducirSubFamilias()
        Else
            lbTipo.Text = "TIPO"
            lbSubTipo.Text = "SUBTIPO"
            lvArticulos.Columns(4).Text = "TIPO"
            lvArticulos.Columns(5).Text = "SUBTIPO"
            Call IntroducirTiposArticulo()
            Call IntroducirSubTiposArticulo()
        End If

        'Cargamos los almacenes.
        Call IntroducirAlmacenes()
        'Cargamos las secciones.
        Call IntroducirSecciones()

    End Sub

#End Region

#Region "INICIAIZACIÓN"

    Private Sub IntroducirTiposArticulo()
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
    End Sub

    Private Sub IntroducirSubTiposArticulo()
        Dim funcT As New FuncionessubTiposArticulo
        cbSubTipo.Items.Clear()
        Dim lista As List(Of String) = funcT.Listar(True)
        For Each item In lista
            cbSubTipo.Items.Add(item)
        Next
    End Sub

    Private Sub IntroducirFamilias()
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
        Dim dts As DatosFamilia
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gFamilia, dts.gidFamilia))
        Next
    End Sub

    Private Sub IntroducirSubFamilias()

        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbSubTipo.Items.Clear()
        Dim lista As List(Of String) = funcSF.Listar(True)
        For Each item In lista
            cbSubTipo.Items.Add(item)
        Next

    End Sub

    Private Sub IntroducirSecciones()
        cbSeccion.Items.Clear()
        Dim lista As List(Of DatosSeccion) = funcSE.Mostrar(True)
        Dim dts As DatosSeccion
        For Each dts In lista
            cbSeccion.Items.Add(New IDComboBox(dts.gSeccion, dts.gidSeccion))
        Next
    End Sub

    Private Sub IntroducirAlmacenes()

        cbAlmacen.Items.Clear()
        Dim lista As List(Of DatosAlmacen) = funcAL.Mostrar(True)
        Dim dts As DatosAlmacen
        For Each dts In lista
            cbAlmacen.Items.Add(New IDComboBox(dts.gAlmacen, dts.gidAlmacen))
        Next

    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Busqueda()

        Contador.Text = ""

        sBusqueda = ""
        If Articulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Articulo like '%" & Replace(Articulo.Text, "'", "''") & "%'"
        End If
        If cbTipo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            If ckMateriaPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                sBusqueda = sBusqueda & " Articulos.idFamilia = " & cbTipo.SelectedItem.itemdata
            Else
                sBusqueda = sBusqueda & " Articulos.idTipoArticulo = " & cbTipo.SelectedItem.itemdata
            End If
        End If
        If cbSubTipo.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            If ckMateriaPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                sBusqueda = sBusqueda & " SubFamilia = '" & cbSubTipo.Text & "' "
            Else
                sBusqueda = sBusqueda & " SubTipoArticulo = '" & cbSubTipo.Text & "' "
            End If
        End If
        If cbAlmacen.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.idAlmacen = " & cbAlmacen.SelectedItem.itemdata
        End If
        If codArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " replace(Articulos.codArticulo,' ','') like '" & Replace(codArticulo.Text, " ", "") & "%'"
        End If
        If cbSeccion.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.idseccion = " & cbSeccion.SelectedItem.itemdata
        End If
        If ckMateriaPrima.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.MateriaPrima = 1 "
        End If
        If ckEscandallo.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Escandallo = 1 "
        End If
        If ckOpcion.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Opcion = 1 "
        End If
        If ckSubEnsamblado.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.subEnsamblado = 1 "
        End If

        If ckComprable.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Comprable = 1 "
        End If
        If ckVendible.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Vendible = 1 "
        End If
        If Observaciones.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Observaciones like '%" & Observaciones.Text & "%' "
        End If
        If Descripcion.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Descripcion like '%" & Descripcion.Text & "%' "
        End If
        If ckInactivos.Checked Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Activo = 0 "  'En esta búsqueda sólo encontramos artículos activos
        Else
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Articulos.Activo = 1 "  'En esta búsqueda sólo encontramos artículos activos
        End If
        

        Call actualiza_lvArticulos()
    End Sub

    Private Sub actualiza_lvArticulos()

        If semaforo Then

            'Mostramos la etiqueta de buscando.
            lbBuscando.Visible = True
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Try
                lvArticulos.Items.Clear()
                Articulos.Clear()
                'lvwColumnSorter = New OrdenarLV()
                'Me.lvArticulos.ListViewItemSorter = lvwColumnSorter

                Dim lista As List(Of DatosArticulo)
                'If iidProveedor = 0 Then
                lista = funcAR.Busqueda(sBusqueda, Orden & If(Orden = "", "", " " & Direccion))
                'Else
                '    lista = funcAP.Busqueda(sBusqueda, Orden & If(Orden = "", "", " " & Direccion))
                'End If
                Dim dts As DatosArticulo
                For Each dts In lista
                    If dts.gidArticulo > 0 Then
                        'If ckStockMinimo.Checked = False Or (ckStockMinimo.Checked And (dts.gCantidadStock < dts.gStockMinimo)) Then
                        Articulos.Add(dts.gidArticulo)
                        With lvArticulos.Items.Add(dts.gidArticulo) '0
                            .SubItems.Add(dts.gcodArticulo) '1
                            .SubItems.Add(dts.gSeccion) '2
                            .SubItems.Add(dts.gTipoCompra) '3
                            .SubItems.Add(dts.gTipoArticulo) '4
                            .SubItems.Add(dts.gSubTipoArticulo) '5
                            'If ckMateriaPrima.Checked Then
                            '    .SubItems.Add(dts.gFamilia)  '4
                            '    .SubItems.Add(dts.gSubFamilia) '5
                            'Else
                            '    .SubItems.Add(dts.gTipoArticulo)  '4
                            '    .SubItems.Add(dts.gSubTipoArticulo) '5
                            'End If
                            .SubItems.Add(dts.gArticulo)  '6
                            '.SubItems.Add(FormatNumber(dts.gPrecioUnitarioC, 4) & dts.gSimboloC) '7
                            .SubItems.Add(FormatNumber(dts.gPrecioUnitarioV, 2) & dts.gSimboloV) '8
                            .SubItems.Add(FormatNumber(dts.gCantidadStock, 2) & dts.gTipoUnidad) '8

                            .SubItems.Add(dts.gidArticuloProv) '9
                            .SubItems.Add(dts.gcodArticuloProv) '10
                            .SubItems.Add(dts.gObservaciones)
                            .SubItems.Add(dts.gFamilia) '11
                            .SubItems.Add(dts.gSubFamilia) '12
                            If dts.gActivo Then
                                If dts.gCantidadStock < dts.gStockMinimo Then
                                    .ForeColor = Color.Red
                                Else
                                    .ForeColor = Color.Black
                                End If
                            Else
                                .ForeColor = colorInactivo
                            End If
                        End With
                        'End If

                    End If
                Next

                'Ocultamos la etiqueta de buscando.
                lbBuscando.Visible = False
                Me.Cursor = Cursors.Default

                Contador.Text = lvArticulos.Items.Count

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ActualizaLinealv(ByVal indice As Integer)
        iidArticulo = lvArticulos.Items(indice).Text
        Dim dts As DatosArticulo

        dts = funcAR.Mostrar1(iidArticulo)

        'If ckBajas.Checked = False And dts.gActivo = False Then
        '    lvArticulos.Items.RemoveAt(indice)
        'Else
        With lvArticulos.Items(indice)
            .SubItems(1).Text = dts.gcodArticulo
            .SubItems(2).Text = dts.gSeccion
            .SubItems(3).Text = dts.gTipoCompra
            .SubItems(4).Text = dts.gTipoArticulo
            .SubItems(5).Text = dts.gSubTipoArticulo
            'If dts.gMateriaPrima Then
            '    .SubItems(4).Text = dts.gFamilia
            '    .SubItems(5).Text = dts.gSubFamilia
            'Else
            '    .SubItems(4).Text = dts.gTipoArticulo
            '    .SubItems(5).Text = dts.gSubTipoArticulo
            'End If
            .SubItems(6).Text = dts.gArticulo
            '.SubItems(7).Text = FormatNumber(dts.gPrecioUnitarioC, 4) & dts.gSimboloC
            .SubItems(7).Text = FormatNumber(dts.gPrecioUnitarioV, 2) & dts.gSimboloV
            .SubItems(8).Text = FormatNumber(dts.gCantidadStock, 2) & dts.gTipoUnidad

            '.SubItems(10).Text = FormatNumber(dts.gStockMinimo, 2) & dts.gTipoUnidad

            .SubItems(9).Text = dts.gidArticuloProv
            .SubItems(10).Text = dts.gcodArticuloProv
            .SubItems(11).Text = dts.gObservaciones
            .SubItems(12).Text = dts.gFamilia
            .SubItems(13).Text = dts.gSubFamilia
            If dts.gActivo Then
                If dts.gCantidadStock < dts.gStockMinimo Then
                    .ForeColor = Color.Red
                Else
                    .ForeColor = Color.Black
                End If
            Else
                .ForeColor = colorInactivo
            End If

        End With

        ' End If

    End Sub

    'Limpiar
    Public Sub limpiar()

        iidArticulo = 0
        Articulo.Text = ""
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        cbAlmacen.Text = ""
        cbAlmacen.SelectedIndex = -1
        cbSeccion.Text = ""
        cbSeccion.SelectedIndex = -1
        Observaciones.Text = ""
        Descripcion.Text = ""
        iidTipoArticulo = 0
        iidFamilia = 0
        iidProveedor = 0
        codArticulo.Text = ""
        Contador.Text = ""

        'Deschequeamos todo excepto lo que esté desabilitado porque hemos entrado en un modo especial
        If ckMateriaPrima.Enabled Then ckMateriaPrima.Checked = False
        If ckEscandallo.Enabled Then ckEscandallo.Checked = False
        'If ckBajas.Enabled Then ckBajas.Checked = False
        If ckComprable.Enabled Then ckComprable.Checked = False
        If ckVendible.Enabled Then ckVendible.Checked = False
        If ckSubEnsamblado.Enabled Then ckSubEnsamblado.Checked = False
        If ckOpcion.Enabled Then ckOpcion.Checked = False
        If modo = "MPCOMPRABLE" Then ckMateriaPrima.Checked = True

        Orden = " Articulo"
        lvArticulos.Items.Clear()

    End Sub

#End Region

#Region "BOTONES"

    'Limpiamos el formulario
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    'Crear nuevo articulo.
    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click

        Dim GP As New GestionArticulo
        GP.pidArticulo = 0
        GP.SoloLectura = vSoloLectura
        GP.Show()

    End Sub

    'Salir.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'Boton buscar
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        Busqueda()

    End Sub

#End Region

#Region "EVENTOS"

    'Seleccionamos un tipo de articulo.
    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged

        If cbTipo.SelectedIndex <> -1 Then

            If ckMateriaPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                iidFamilia = cbTipo.SelectedItem.itemdata
                Call IntroducirSubFamilias()
            Else
                iidTipoArticulo = cbTipo.SelectedItem.itemdata
                Call IntroducirSubTiposArticulo()
            End If

        End If

    End Sub

    'Doble clic en el listview.
    Private Sub lvArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulos.DoubleClick
        If lvArticulos.SelectedItems.Count > 0 Then

            Select Case modo
                Case "A"
                    If lvArticulos.SelectedItems.Count > 0 Then
                        Dim indice As Integer = lvArticulos.SelectedIndices(0)
                        iidArticulo = lvArticulos.Items(indice).Text
                        Dim CA As New GestionArticulo
                        CA.pidArticulo = iidArticulo
                        CA.SoloLectura = vSoloLectura
                        CA.pArticulos = Articulos
                        CA.pIndice = indice
                        CA.pVerCostes = VerCostes
                        CA.ShowDialog()
                        'Call Busqueda()
                        Dim lista As List(Of DatosArticulo)
                        Dim sBusquedaX As String = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                        sBusquedaX = sBusquedaX & " Articulos.idArticulo = " & iidArticulo

                        lista = funcAR.Busqueda(sBusquedaX, Orden & If(Orden = "", "", " " & Direccion))

                        If lista.Count > 0 Then
                            'Si el artículo sigue respondiendo a la búsqueda, lo actualizamos
                            Call ActualizaLinealv(indice)
                            lvArticulos.EnsureVisible(indice)
                        Else
                            'Si no lo borramos
                            lvArticulos.Items.RemoveAt(indice)
                        End If

                    End If

                Case "P", "MP", "ESCANDALLO", "CONCEPTO", "OPCIONES", "COMPRABLE", "MPCOMPRABLE"

                    iidArticulo = lvArticulos.SelectedItems(0).Text
                    iidArticuloProv = lvArticulos.SelectedItems(0).SubItems(9).Text
                    Me.Close()

                Case "Etiquetas"

                    pidArticulo = lvArticulos.SelectedItems(0).Text
                    pCodArticulo = lvArticulos.SelectedItems(0).SubItems(1).Text
                    Me.Close()

            End Select

        End If

    End Sub

    'Si pulsamos enter en los controles
    Private Sub codArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles codArticulo.KeyDown, Descripcion.KeyDown, Observaciones.KeyDown, Articulo.KeyDown, _
    cbSubTipo.KeyDown, cbTipo.KeyDown, cbAlmacen.KeyDown, cbSeccion.KeyDown, ckOpcion.KeyDown, ckSubEnsamblado.KeyDown, ckVendible.KeyDown, ckComprable.KeyDown, ckMateriaPrima.KeyDown, ckEscandallo.KeyDown

        If e.KeyCode = Keys.Enter Then

            Busqueda()

        End If

    End Sub

    'Orden de columnas
    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvArticulos.ColumnClick

        If e.Column = columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                Orden = "idArticulo"
            Case 1
                Orden = "codArticulo"
            Case 2
                Orden = "Seccion"
            Case 3
                Orden = "TipoCompra"
            Case 4
                Orden = "TipoArticulo"
            Case 5
                Orden = "SubTipoArticulo"
            Case 6
                Orden = "Articulo"
            Case 8
                Orden = "Stock"
            Case 10
                Orden = " StockMinimo"
            Case 11
                Orden = "Articulos.observaciones"
            Case 12
                Orden = "familia"
            Case 13
                Orden = "subfamilia"
            Case Else
                Orden = "Articulo"
        End Select

        columna = e.Column

        Call actualiza_lvArticulos()

    End Sub

    'Materia prima cambio de texto.
    Private Sub ckMateriasPrima_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckMateriaPrima.CheckedChanged, ckEscandallo.CheckedChanged, ckOpcion.CheckedChanged
        If semaforo Then

            If ckMateriaPrima.Checked And Not ckEscandallo.Checked And Not ckOpcion.Checked Then
                lbTipo.Text = "FAMILIA"
                lbSubTipo.Text = "SUBFAMILIA"
                'lvArticulos.Columns(4).Text = "FAMILIA"
                'lvArticulos.Columns(5).Text = "SUBFAMILIA"
                Call IntroducirFamilias()
                Call IntroducirSubFamilias()
            Else
                lbTipo.Text = "TIPO"
                lbSubTipo.Text = "SUBTIPO"
                'lvArticulos.Columns(4).Text = "TIPO"
                'lvArticulos.Columns(5).Text = "SUBTIPO"
                Call IntroducirTiposArticulo()
                Call IntroducirSubTiposArticulo()
            End If
        End If
    End Sub

#End Region

End Class





























'CODIGO SOBRANTE


'Private Sub IntroducirSubFamilias()
'    If iidFamilia > 0 Then
'        cbSubTipo.Text = ""
'        cbSubTipo.SelectedIndex = -1
'        cbSubTipo.Items.Clear()
'        Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, True)
'        Dim dts As DatosSubFamilia
'        For Each dts In lista
'            cbSubTipo.Items.Add(New IDComboBox(dts.gSubFamilia, dts.gidSubFamilia))
'        Next
'    End If
'End Sub

'Private Sub lvArticulos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulos.Click
'    Copia la linea en la zona superior
'    If lvArticulos.SelectedItems.Count > 0 Then
'        semaforo = False
'        iidArticulo = lvArticulos.SelectedItems(0).Text
'        Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
'        Articulo.Text = dts.gArticulo
'        cbTipoArticulo.Text = dts.gTipoArticulo
'        cbSubTipoArticulo.Text = dts.gSubTipoArticulo
'        codArticulo.Text = dts.gcodArticulo
'        semaforo = True
'    End If
'End Sub

'Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
'    InformeListadoArticulos.verInforme(sBusqueda, Orden & If(Orden = "", "", " " & Direccion), ckStockMinimo.Checked)
'    InformeListadoArticulos.ShowDialog()
'End Sub


'Private Sub introducirProveedores()
'    Try
'        cbProveedor.Items.Clear()

'        Dim lista As List(Of datosProveedor) = funcPR.mostrar(True)
'        Dim dts As datosProveedor
'        For Each dts In lista
'            cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
'        Next
'    Catch ex As Exception
'        MsgBox(ex.Message)
'    End Try
'End Sub

'Private Sub IntroducirSubTiposArticulo()
'    If iidTipoArticulo > 0 Then
'        cbSubTipo.Text = ""
'        cbSubTipo.SelectedIndex = -1
'        cbSubTipo.Items.Clear()
'        Dim lista As List(Of DatosSubTipoArticulo) = funcSP.Mostrar(iidTipoArticulo, 0, True)
'        Dim dts As DatosSubTipoArticulo
'        For Each dts In lista
'            cbSubTipo.Items.Add(New IDComboBox(dts.gSubTipoArticulo, dts.gidSubTipoArticulo))
'        Next
'    End If
'End Sub

'Private Sub BusquedaRetardada(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
'    If BuscarAhora Then
'        BuscarAhora = False
'        retardo.Enabled = False
'        Call Busqueda()
'    End If
'End Sub
