Public Class GestionVersionesEscandallo

#Region "VARIABLES"

    Private funcAR As New FuncionesArticulos
    Private funcTE As New FuncionesTiposEscandallos
    Private funcES As New FuncionesEscandallos
    Private funcCE As New FuncionesConceptosEscandallos
    Private funcTI As New FuncionesTiemposEscandallos
    Private funcAP As New FuncionesArticuloPrecio
    Private iidArticulo As Integer
    Private iidEscandallo As Integer
    Private vSoloLectura As Boolean
    Private sBusqueda As String
    Private lvwColumnSorter As OrdenarLV
    Private Orden As String = ""
    Private Direccion As String
    Private modo As String
    Private semaforo As Boolean
    Private colorInactivo As Color
    Private Escandallos As List(Of Integer)
    Private desktopSize As Size

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

    Property pidEscandallo() As Integer

        Get

            Return iidEscandallo

        End Get

        Set(ByVal value As Integer)

            iidEscandallo = value

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

#End Region

    Private Sub BusquedaArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Articulo.Focus()

        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize

        Me.Height = desktopSize.Height - 15

        Me.Location = New Point(Me.Location.X, 0)

        ckSeleccion.Location = New Point(lvEscandallos.Location.X + 6, lvEscandallos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview

        ckSeleccion.Checked = False

        lvEscandallos.CheckBoxes = True

        colorInactivo = Color.Gray

        cbTipoEscandallo.Sorted = True

        semaforo = True

        Escandallos = New List(Of Integer)

        bNuevo.Enabled = Not vSoloLectura

        bCrearVersion.Enabled = Not vSoloLectura

        bCambioMasivo.Enabled = Not vSoloLectura

        lvwColumnSorter = New OrdenarLV()

        Me.lvEscandallos.ListViewItemSorter = lvwColumnSorter

        Orden = "Articulo"

        Direccion = "ASC"

        NuevaVersion.Text = Now.Year

        cbTipoEscandallo.Text = ""

        Call CargarArticulosC()

        Call IntroducirTiposEscandallo()

        Call IntroducirVersiones()

        Call IntroducirTiposArticulo()

        Call IntroducirSubTiposArticulo()

        Call Busqueda()

    End Sub


#Region "INICIAIZACIÓN"

    Private Sub IntroducirTiposEscandallo()
        cbTipoEscandallo.Items.Clear()
        cbTipoEscandallo.Text = ""
        Dim lista As List(Of DatosTipoEscandallo) = funcTE.Mostrar()
        Dim dts As DatosTipoEscandallo
        For Each dts In lista
            cbTipoEscandallo.Items.Add(New IDComboBox(dts.gTipoEscandallo, dts.gidTipoEscandallo))
        Next
    End Sub

    Private Sub CargarArticulosC()

        cbCodArticuloC.Items.Clear()
        cbCodArticuloC.Text = ""
        cbCodArticuloC.SelectedIndex = -1
        cbArticuloC.Items.Clear()
        cbArticuloC.Text = ""
        cbArticuloC.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("MATERIAPRIMA")
        For Each dts As IDComboBox3 In lista
            cbArticuloC.Items.Add(dts)
            If dts.Name1 <> "" Then cbcodArticuloC.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next

    End Sub

    Private Sub IntroducirVersiones()
        cbVersion.Items.Clear()
        Dim lista As List(Of Integer) = funcES.ListaVersiones
        For Each v As Integer In lista
            cbVersion.Items.Add(v)
        Next
        cbVersion.Text = ""
        cbVersion.SelectedIndex = -1
    End Sub

    Private Sub IntroducirTiposArticulo()
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim funcTI As New FuncionesTiposArticulo
        Dim lista As List(Of DatosTipoArticulo) = funcTI.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoArticulo, dts.gidTipoArticulo))
        Next
        Dim funcFA As New FuncionesFamilias
        Dim listaFA As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
        For Each dtsFA As DatosFamilia In listaFA
            If cbTipoContiene(dtsFA.gFamilia) Then
            Else
                cbTipo.Items.Add(New IDComboBox(dtsFA.gFamilia, 0))
            End If
        Next

    End Sub

    Private Function cbTipoContiene(ByVal literal As String) As Boolean
        For Each item In cbTipo.Items
            If UCase(item.ToString) = UCase(literal) Then Return True
        Next
        Return False
    End Function


    Private Sub IntroducirSubTiposArticulo()
        Dim funcT As New FuncionessubTiposArticulo
        cbSubTipo.Items.Clear()
        Dim lista As List(Of String) = funcT.Listar(True)
        For Each item In lista
            cbSubTipo.Items.Add(item)
        Next
        Dim funcSF As New FuncionessubFamilias
        Dim listaSF As List(Of String) = funcSF.Listar(True)
        For Each item In listaSF
            If cbSubTipo.Items.Contains(item) Then
            Else
                cbSubTipo.Items.Add(item)
            End If
        Next


    End Sub




#End Region



#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Busqueda()
        If semaforo Then
            sBusqueda = " Articulos.ConVersiones = 1 AND ES.idArticuloBase = 0 "

            If Articulo.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " Articulos.Articulo like '%" & Articulo.Text & "%'"
            End If
            If codArticulo.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " Articulos.codArticulo like '" & codArticulo.Text & "%'"
            End If

            If cbVersion.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " ES.VersionEscandallo = " & cbVersion.Text
            End If


            If cbTipoEscandallo.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " ES.idTipoEscandallo = " & cbTipoEscandallo.SelectedItem.itemdata
            End If
            If ckBajas.Checked = False Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " ES.Activo = 1 "
            End If

            If cbcodArticuloC.Text <> "" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " idEscandallo in (Select distinct idEscandallo from ConceptosEscandallos left join Articulos ON Articulos.idArticulo = ConceptosEscandallos.idArticulo where codArticulo = '" & cbcodArticuloC.Text & "') "
            ElseIf cbArticuloC.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " idEscandallo in (Select distinct idEscandallo from ConceptosEscandallos where idArticulo = " & cbArticuloC.SelectedItem.itemdata & ") "
            End If

            If cbTipo.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " (TipoArticulo = '" & cbTipo.Text & "' OR Familia = '" & cbTipo.Text & "') "
            End If
            If cbSubTipo.SelectedIndex <> -1 Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " (SubTipoArticulo = '" & cbSubTipo.Text & "' or subFamilia = '" & cbSubTipo.Text & "') "
            End If

            Call actualiza_lvArticulos()
        End If

    End Sub

    Private Sub actualiza_lvArticulos()
        If semaforo Then
            Try
                lvEscandallos.Items.Clear()
                Escandallos.Clear()
                lvwColumnSorter = New OrdenarLV()
                Me.lvEscandallos.ListViewItemSorter = lvwColumnSorter
                Dim lista As List(Of DatosEscandallo)
                lista = funcES.Busqueda(sBusqueda, Orden & If(Orden = "", "", " " & Direccion))
                Dim dts As DatosEscandallo
                For Each dts In lista
                    Escandallos.Add(dts.gidEscandallo)
                    Call NuevaLineaLv(dts)
                Next
                Contador.Text = lvEscandallos.Items.Count
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Function NuevaLineaLv(ByVal dts As DatosEscandallo) As Integer
        With lvEscandallos.Items.Add("")
            .SubItems.Add(dts.gidEscandallo)
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(dts.gcodEscandallo)
            .SubItems.Add(dts.gEscandallo)
            .SubItems.Add(FormatNumber(dts.gCoste, 4) & "€")
            .SubItems.Add(dts.gnumComponentes)
            .SubItems.Add(dts.gVersionEscandallo)
            If dts.gActivo Then
                .ForeColor = Color.Black
            Else
                .ForeColor = colorInactivo
            End If
            Return .Index
        End With
        Return -1
    End Function


    Private Sub ActualizaLinealv(ByVal indice As Integer)
        iidArticulo = lvEscandallos.Items(indice).SubItems(1).Text
        Dim dts As DatosEscandallo
        dts = funcES.Mostrar1(iidArticulo)
        If ckBajas.Checked = False And dts.gActivo = False Then
            lvEscandallos.Items.RemoveAt(indice)
        Else
            With lvEscandallos.Items(indice)
                .SubItems(2).Text = dts.gidArticulo
                .SubItems(3).Text = dts.gcodEscandallo
                .SubItems(4).Text = dts.gEscandallo
                .SubItems(5).Text = FormatNumber(dts.gCoste, 4) & "€"
                .SubItems(6).Text = dts.gnumComponentes
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If
    End Sub


#End Region


#Region "BOTONES"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        semaforo = False
        iidArticulo = 0
        Articulo.Text = ""
        cbTipoEscandallo.Text = ""
        cbTipoEscandallo.SelectedIndex = -1
        codArticulo.Text = ""
        ckBajas.Checked = False
        cbArticuloC.Text = ""
        cbArticuloC.SelectedIndex = -1
        cbcodArticuloC.Text = ""
        cbcodArticuloC.Text = ""
        cbVersion.Text = ""
        cbVersion.SelectedIndex = -1
        cbTipo.Text = ""
        cbTipo.SelectedIndex = -1
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        'lvEscandallos.CheckBoxes = False
        semaforo = True
        Call Busqueda()
    End Sub


    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GE As New GestionEscandallos
        GE.pidEscandallo = 0
        GE.SoloLectura = vSoloLectura
        GE.ShowDialog()
        Call actualiza_lvArticulos()
    End Sub


    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lvEscandallos.CheckBoxes Then
            If lvEscandallos.CheckedItems.Count = 0 Then
                MsgBox("Seleccione los escandallos a imprimir")
            Else
                Dim GG As New ImprimirEscandallos
                GG.pCostes = False
                GG.pPaginado = False
                GG.ShowDialog()
                If GG.pValidar Then
                    Dim IDSescandallo As String = ""
                    For Each item As ListViewItem In lvEscandallos.CheckedItems
                        IDSescandallo = IDSescandallo & If(IDSescandallo = "", "", ", ") & item.SubItems(1).Text
                    Next
                    InformeEscandallo.verInforme(IDSescandallo, GG.pCostes, GG.pPaginado, GG.pTiempos, If(Orden = "Coste" Or Orden = "Contador", "Articulo", Orden) & " " & Direccion, False)
                    InformeEscandallo.ShowDialog()
                    ' lvEscandallos.CheckBoxes = False
                End If

            End If

        Else
            lvEscandallos.CheckBoxes = True
            For Each item As ListViewItem In lvEscandallos.Items
                item.Checked = False
            Next
            'MsgBox("Selecciones los escandallos a imprimir")
        End If


    End Sub

    Private Sub bCrearVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCrearVersion.Click
        Dim Seleccionados As Integer = lvEscandallos.CheckedItems.Count
        If Seleccionados = 0 Then
            MsgBox("Seleccione los escandallos a crear")
        Else

            For Each item As ListViewItem In lvEscandallos.CheckedItems
                If item.SubItems(7).Text = NuevaVersion.Text Then
                    item.Checked = False
                ElseIf funcES.ExisteEscandallo(item.SubItems(2).Text, NuevaVersion.Text) > 0 Then
                    item.Checked = False
                End If


            Next
            If lvEscandallos.CheckedItems.Count = 0 Then
                MsgBox("Se han deseleccionado todos los escandallos porque ya tienen la nueva versión")
            ElseIf Seleccionados > lvEscandallos.CheckedItems.Count Then
                MsgBox("Se han deseleccionado " & Seleccionados - lvEscandallos.CheckedItems.Count & " escandallos que ya tienen la nueva versión")
            End If
            If lvEscandallos.CheckedItems.Count > 0 Then
                If MsgBox("¿Desea crear nuevas versiones clonando todos los escandallos seleccionados e inactivar la versión actual?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call CrearNuevaVersion()

                End If
            End If
        End If
    End Sub



    Private Sub bCambioMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCambioMasivo.Click
        Dim Seleccionados As Integer = lvEscandallos.CheckedItems.Count
        If Seleccionados = 0 Then
            MsgBox("Seleccione los escandallos para hacer los cambios")
        Else
            If MsgBox("¿Desea realizar cambios masivos en todos los escandallos seleccionados?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Call CambioMasivo()
            End If

        End If
    End Sub



    Private Sub CrearNuevaVersion()
        Dim iidEscandallo As Integer = 0
        Dim iidArticulo As Integer = 0
        Dim NuevoIndice As Integer = 0
        Dim aviso As Boolean = False
        Dim FechaCambio As Date
        Dim listaMaterial As List(Of DatosConceptoEscandallo)
        Dim listaTiempo As List(Of DatosTiempoEscandallo)
        For Each item As ListViewItem In lvEscandallos.CheckedItems
            iidEscandallo = item.SubItems(1).Text
            iidArticulo = item.SubItems(2).Text
            Dim dtsES As DatosEscandallo = funcES.Mostrar1(iidEscandallo)
            dtsES.gVersionEscandallo = NuevaVersion.Text
            Dim NuevoIdEscandallo As Integer = funcES.insertar(dtsES)
            Dim indice As Integer
            If NuevoIdEscandallo <> -1 Then
                listaMaterial = funcCE.Mostrar(iidEscandallo, True, 0)
                For Each dts As DatosConceptoEscandallo In listaMaterial
                    indice = EncuentraItem(dts.gidEscandallo)
                    dts.gidEscandallo = NuevoIdEscandallo
                    funcCE.insertar(dts)
                Next
                funcES.Baja(iidEscandallo)
                listaTiempo = funcTI.Mostrar(iidEscandallo, True)
                For Each dts As DatosTiempoEscandallo In listaTiempo
                    indice = EncuentraItem(dts.gidEscandallo)
                    dts.gidEscandallo = NuevoIdEscandallo
                    funcTI.insertar(dts)
                Next
                Call ActualizaPrecioAR(iidArticulo, funcES.CosteEU(iidEscandallo, aviso, FechaCambio) + funcTI.TotalCoste(iidEscandallo, True), NuevaVersion.Text)
            End If
            item.Checked = False
            NuevoIndice = NuevaLineaLv(dtsES)
            lvEscandallos.Items(NuevoIndice).Checked = True
            lvEscandallos.EnsureVisible(NuevoIndice)
        Next
        Call IntroducirVersiones()

    End Sub


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
            dtsPR.gVersion = Version 'If(IsNumeric(Version.Text), CInt(Version.Text), 0)
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


    Private Sub CambioMasivo()
        Dim iidEscandallo As Integer = 0
        Dim listaId As New List(Of Integer)
        For Each item As ListViewItem In lvEscandallos.CheckedItems
            listaId.Add(item.SubItems(1).Text)
        Next
        If listaId.Count > 0 Then
            'Abre la Gestión de Escandallos en el modo CambioMasivo, le pasa también la lista de todos los escandallos seleccionados.
            Dim GG As New GestionEscandallos
            GG.pidEscandallo = listaId(0)
            GG.pEscandallos = listaId
            GG.pIndice = 0
            GG.pModo = "CambioMasivo"

            GG.ShowDialog()
        End If
    End Sub


    Private Function EncuentraItem(ByVal iidEscandallo As Integer) As Integer
        If iidEscandallo = 0 Then Return -1
        For Each item As ListViewItem In lvEscandallos.Items
            If item.SubItems(1).Text = iidEscandallo Then Return item.Index
        Next
        Return -1
    End Function

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoEscandallo.SelectedIndexChanged
        If cbTipoEscandallo.SelectedIndex <> -1 Then
            iidEscandallo = cbTipoEscandallo.SelectedItem.itemdata
            Call Busqueda()
        End If

    End Sub



    Private Sub lvArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEscandallos.DoubleClick

        Select Case modo
            Case ""
                If lvEscandallos.SelectedItems.Count > 0 Then
                    Dim indice As Integer = lvEscandallos.SelectedIndices(0)
                    iidEscandallo = lvEscandallos.Items(indice).SubItems(1).Text
                    iidArticulo = lvEscandallos.Items(indice).SubItems(2).Text
                    Dim GE As New GestionEscandallos
                    GE.SoloLectura = vSoloLectura
                    GE.pidEscandallo = iidEscandallo
                    GE.pEscandallos = Escandallos
                    GE.pIndice = indice
                    GE.ShowDialog()

                    Call ActualizaLinealv(indice)
                End If

            Case "B"
                Dim indice As Integer = lvEscandallos.SelectedIndices(0)
                iidEscandallo = lvEscandallos.Items(indice).SubItems(1).Text
                iidArticulo = lvEscandallos.Items(indice).SubItems(2).Text
                Me.Close()

            Case Else


        End Select

    End Sub

    Private Sub idArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVersion.SelectedIndexChanged, Articulo.TextChanged, codArticulo.TextChanged, ckBajas.CheckedChanged, cbTipo.SelectedIndexChanged, cbSubTipo.SelectedIndexChanged
        If semaforo Then Call Busqueda()

    End Sub




    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEscandallos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            Direccion = "ASC"
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
                Direccion = "DESC"
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
                Direccion = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorter.SortColumn = e.Column
            Select Case e.Column
                Case 1
                    Orden = "idEscandallo"
                Case 2
                    Orden = "idArticulo"
                Case 3
                    Orden = "codArticulo"
                Case 4
                    Orden = "Articulo"
                Case 5
                    Orden = "Coste"
                Case 6
                    Orden = "Contador"
                Case 7
                    Orden = "VersionEscandallo"

            End Select

            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvEscandallos.Sort()

    End Sub



    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticuloC.SelectionChangeCommitted, cbVersion.SelectionChangeCommitted
        If semaforo And cbcodArticuloC.SelectedIndex <> -1 Then
            semaforo = False
            cbArticuloC.Text = funcAR.Articulo(cbcodArticuloC.SelectedItem.itemdata)
            semaforo = True
            Call Busqueda()

        End If
    End Sub

    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticuloC.SelectionChangeCommitted
        If semaforo And cbArticuloC.SelectedIndex <> -1 Then
            semaforo = False
            cbcodArticuloC.Text = funcAR.codArticulo(cbArticuloC.SelectedItem.itemdata)
            semaforo = True
            Call Busqueda()

        End If
    End Sub

    Private Sub cbCodArticuloc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcodArticuloC.TextChanged, cbVersion.TextChanged
        If semaforo Then
            semaforo = False
            cbArticuloC.Text = funcAR.Articulo(cbcodArticuloC.Text)
            semaforo = True
            Call Busqueda()

        End If

    End Sub



    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvEscandallos.Items
                item.Checked = ckSeleccion.Checked
            Next
            semaforo = True
        End If

    End Sub

    Private Sub lvEscandallos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvEscandallos.ItemChecked
        If semaforo Then
            Dim cont As Integer = lvEscandallos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvEscandallos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub


#End Region



End Class