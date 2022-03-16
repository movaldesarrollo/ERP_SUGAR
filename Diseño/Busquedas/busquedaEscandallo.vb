Imports Excel = Microsoft.Office.Interop.Excel
Imports office = Microsoft.Office.Core
Imports System.Reflection
Imports System
Imports System.IO
Imports System.Text

'FORMULARIO DE BUSQUEDA DE ESCANDALLOS
Public Class BusquedaEscandallo

#Region "VARIABLES"

    'Funciones
    Private funcAR As New FuncionesArticulos
    Private funcTE As New FuncionesTiposEscandallos
    Private funcES As New FuncionesEscandallos

    'Variables
    Public iidArticulo As Integer
    Public iidEscandallo As Integer
    Public codigoArticulo As String
    Public Escandallo As String
    Private vSoloLectura As Boolean
    Private sBusqueda As String
    Private lvwColumnSorter As OrdenarLV
    Private Orden As String = "Articulo"
    Private Direccion As String = "ASC"
    Private modo As String
    Private semaforo As Boolean
    Private colorInactivo As Color = Color.Gray
    Private Escandallos As List(Of Integer)
    Private desktopSize As Size

    'Listas
    Dim lista As List(Of DatosEscandallo)

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

#Region "CARGA"

    Private Sub BusquedaArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Ajustamos el formulario al formato de pantalla.
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize

        Me.Height = desktopSize.Height - 15

        Me.Location = New Point(Me.Location.X, 0)


        'Desactivamos el boton nuevo si tiene permisos solo lectura.
        bNuevo.Enabled = Not vSoloLectura

        cbArticuloC.Enabled = False

        lvEscandallos.CheckBoxes = False

        cbTipoEscandallo.Sorted = True

        lvwColumnSorter = New OrdenarLV()

        Me.lvEscandallos.ListViewItemSorter = lvwColumnSorter

        Escandallos = New List(Of Integer)

        'Llena los datos en los controles de parametros de busqueda.
        Call IntroducirVersiones()

        Call IntroducirTiposArticulo()

        Call IntroducirSubTiposArticulo()

        Call IntroducirTiposEscandallo()

        semaforo = True

    End Sub

#End Region
   
#Region "INICIAIZACIÓN"

    'Introduce los tipos de escandallos en el combobox.
    Private Sub IntroducirTiposEscandallo()

        cbTipoEscandallo.Items.Clear()

        cbTipoEscandallo.Text = ""

        Dim lista As List(Of DatosTipoEscandallo) = funcTE.Mostrar()

        Dim dts As DatosTipoEscandallo

        For Each dts In lista

            cbTipoEscandallo.Items.Add(New IDComboBox(dts.gTipoEscandallo, dts.gidTipoEscandallo))

        Next

    End Sub

    'Introduce los articulos y los codigos de articulos en el combobox.
    Private Sub CargarArticulosC()

        cbcodArticuloC.Items.Clear()

        cbcodArticuloC.Text = ""

        cbcodArticuloC.SelectedIndex = -1

        cbArticuloC.Items.Clear()

        cbArticuloC.Text = ""

        cbArticuloC.SelectedIndex = -1

        Dim lista As List(Of IDComboBox3) = funcAR.Listar("ESCANDALLO")

        For Each dts As IDComboBox3 In lista

            cbArticuloC.Items.Add(dts)

            If dts.Name1 <> "" Then cbcodArticuloC.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))

        Next

    End Sub

    'Introduce las versiones en el combobox.
    Private Sub IntroducirVersiones()

        cbVersion.Items.Clear()

        Dim lista As List(Of Integer) = funcES.ListaVersiones

        For Each v As Integer In lista

            cbVersion.Items.Add(v)

        Next

        cbVersion.Text = ""

        cbVersion.SelectedIndex = -1

    End Sub

    'Introduce los tipos de articulos en el combobox.
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

    'Introduce los subtipos de articulos en el combobox.
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

    'Formatea la cadena de busqueda.
    Private Sub Busqueda()

        If semaforo Then

            sBusqueda = ""

            'Texto articulo.
            If Articulo.Text <> "" Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " Articulos.Articulo like '%" & Articulo.Text & "%'"

            End If

            'Texto código de articulo.
            If codArticulo.Text <> "" Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " Articulos.codArticulo like '" & codArticulo.Text & "%'"

            End If

            'Item Version.
            If cbVersion.SelectedIndex <> -1 Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " ES.VersionEscandallo = " & cbVersion.Text

            End If

            'Item Tipo Escandallo.
            If cbTipoEscandallo.SelectedIndex <> -1 Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " ES.idTipoEscandallo = " & cbTipoEscandallo.SelectedItem.itemdata

            End If

            'Estado del Check Bajas.
            If ckBajas.Checked = False Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " ES.Activo = 1 and ES.codEscandallo <> '' "

            Else
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " ES.codEscandallo <> '' "

            End If

            'Item Tipo.
            If cbTipo.SelectedIndex <> -1 Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " (TipoArticulo = '" & cbTipo.Text & "' OR Familia = '" & cbTipo.Text & "') "

            End If

            'Item Subtipo.
            If cbSubTipo.SelectedIndex <> -1 Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " (SubTipoArticulo = '" & cbSubTipo.Text & "' or subFamilia = '" & cbSubTipo.Text & "') "

            End If

            'Texto codigo articulo o Item seleccionado.
            If cbcodArticuloC.Text <> "" Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " ES.idEscandallo in (Select distinct idEscandallo from ConceptosEscandallos left join Articulos ON Articulos.idArticulo = ConceptosEscandallos.idArticulo where codArticulo = '" & cbcodArticuloC.Text & "') "

            ElseIf cbArticuloC.SelectedIndex <> -1 Then

                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")

                sBusqueda = sBusqueda & " ES.idEscandallo in (Select distinct idEscandallo from ConceptosEscandallos where idArticulo = " & cbArticuloC.SelectedItem.itemdata & ") "

            End If

            'Llama a actualizar listview.
            Call actualiza_lvArticulos()

        End If

    End Sub

    'Revisa si la familia contiene tipo.
    Private Function cbTipoContiene(ByVal literal As String) As Boolean

        For Each item In cbTipo.Items

            If UCase(item.ToString) = UCase(literal) Then Return True

        Next

        Return False

    End Function

    'Actualiza el listview con los parametros de busqueda.
    Private Sub actualiza_lvArticulos()

        lvEscandallos.Enabled = True

        If semaforo Then

            Try
                'Vaciamos el contador
                Contador.Text = ""

                'Limpiamos los Items del listview.
                lvEscandallos.Items.Clear()

                'Vaciamos la lista de escandallos.
                Escandallos.Clear()

                'Ordenamos el listview
                lvwColumnSorter = New OrdenarLV()

                Me.lvEscandallos.ListViewItemSorter = lvwColumnSorter

                'Llenamos la lista
                lista = funcES.Busqueda(sBusqueda, Orden & If(Orden = "", "", " " & Direccion))

                Dim dts As DatosEscandallo

                Dim continuar As Boolean

                Dim numeroItemsLista As Integer = lista.Count

                If numeroItemsLista > 500 Then

                    If MsgBox("La búsqueda seleccionada contiene " & numeroItemsLista & " registros, por este motivo el programa puede tardar en responder, ¿desea continuar de todos modos?.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        continuar = True

                    Else

                        continuar = False

                    End If

                Else

                    continuar = True

                End If

                If continuar Then

                    'Iniciamos la barra de progreso.
                    pbCargando.Maximum = 1000

                    pbCargando.Value = 1

                    pbCargando.Step = 1

                    pbCargando.Visible = True

                    For Each dts In lista

                        Contador.Text = ""

                        If pbCargando.Value = pbCargando.Maximum Then

                            pbCargando.Value = 0

                        Else

                            pbCargando.Value = pbCargando.Value + 1

                        End If

                        Escandallos.Add(dts.gidEscandallo)

                        With lvEscandallos.Items.Add("")

                            .SubItems.Add(dts.gidEscandallo)

                            .SubItems.Add(dts.gidArticulo)

                            .SubItems.Add(dts.gcodEscandallo)

                            .SubItems.Add(dts.gEscandallo)

                            .SubItems.Add(FormatNumber(dts.gCoste, 4) & "€")

                            .SubItems.Add(dts.gnumComponentes)

                            .SubItems.Add(dts.gVersionEscandallo)

                            .SubItems.Add(dts.gVersionBase)

                            If dts.gActivo Then

                                .ForeColor = Color.Black

                            Else

                                .ForeColor = colorInactivo

                            End If

                        End With

                    Next

                End If

                pbCargando.Value = 1000

                Application.DoEvents()

                pbCargando.Visible = False

                Contador.Text = lvEscandallos.Items.Count

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

        End If

    End Sub

    'Actualiza la linea del listview
    Private Sub ActualizaLinealv(ByVal indice As Integer)

        iidArticulo = lvEscandallos.Items(indice).SubItems(1).Text

        Dim dts As DatosEscandallo

        dts = funcES.Mostrar1(iidArticulo)

        If ckBajas.Checked = False And dts.gActivo = False Then

            lvEscandallos.Items.RemoveAt(indice)

        Else

            With lvEscandallos.Items(indice)

                .SubItems(1).Text = dts.gidEscandallo

                .SubItems(2).Text = dts.gidArticulo

                .SubItems(3).Text = dts.gcodEscandallo

                .SubItems(4).Text = dts.gEscandallo

                .SubItems(5).Text = FormatNumber(dts.gCoste, 4) & "€"

                .SubItems(6).Text = dts.gnumComponentes

                .SubItems(7).Text = dts.gVersionEscandallo

                .SubItems(8).Text = dts.gVersionBase

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

    'Al presionar el boton limpiar.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        semaforo = False

        lvEscandallos.Items.Clear()

        Contador.Text = ""

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

        lvEscandallos.CheckBoxes = False

        semaforo = True

        codArticulo.Focus()

    End Sub

    'Al presionar el boton nuevo.
    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click

        Dim GE As New GestionEscandallos

        GE.pidEscandallo = 0

        GE.SoloLectura = vSoloLectura

        GE.ShowDialog()

        Call actualiza_lvArticulos()

    End Sub

    'Al presionar imprimir.
    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click

        imprimir()

    End Sub

    Private Sub imprimir()
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

                End If

            End If

        Else

            lvEscandallos.CheckBoxes = True

            ckTodos.Visible = True

            For Each item As ListViewItem In lvEscandallos.Items

                item.Checked = False

            Next

        End If
    End Sub

    'Al presionar imprimir.
    Private Sub Excel_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bExcel.Click

        informeExcel()

    End Sub

    Private Sub informeExcel()

        If lvEscandallos.CheckBoxes Then

            If lvEscandallos.CheckedItems.Count = 0 Then

                MsgBox("Seleccione los escandallos a exportar a excel", MsgBoxStyle.Information)

            Else

                Dim cantidadEscandallos As Integer = lvEscandallos.CheckedItems.Count

                Dim OEM As New opcionesEscandallosMasivos

                OEM.ShowDialog()

                Dim MP As Boolean = OEM.ckMateriasPrimas.Checked

                Dim COST As Boolean = OEM.ckCostes.Checked

                Dim ruta As String = OEM.txRuta.Text

                If ruta = "" And OEM.exportar = True Then
                    ExportarTodo()
                ElseIf ruta <> "" And OEM.exportar = True Then

                    Me.Cursor = Cursors.WaitCursor

                    For Each item As ListViewItem In lvEscandallos.CheckedItems 'Llenamos la lista con todos los escandallos a exportar a excel.

                        Dim EC As New escandallosCompletos

                        EC.idescandallo = item.SubItems(1).Text

                        EC.ckMateriasPrimas.Checked = MP

                        EC.coste = COST

                        EC.exportacionMasiva = True

                        EC.ruta = ruta

                        EC.txEscandallo.Text = item.SubItems(3).Text

                        EC.txIdEscandallo.Text = item.SubItems(1).Text

                        EC.txVersion.Text = item.SubItems(7).Text

                        EC.escandallosBucle()

                    Next

                    Me.Cursor = Cursors.Default

                    If cantidadEscandallos > 1 Then
                        If MsgBox("Se han exportados los escandallos en la carpeta " & ruta & ". ¿Abrir la carpeta?.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Process.Start("explorer.exe", ruta)
                        End If
                    Else
                        If MsgBox("Se ha exportado el escandallo en la carpeta " & ruta & ". ¿Abrir la carpeta?.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Process.Start("explorer.exe", ruta)
                        End If
                    End If

                Else


                End If


            End If

        Else

            lvEscandallos.CheckBoxes = True

            ckTodos.Visible = True

            For Each item As ListViewItem In lvEscandallos.Items

                item.Checked = False

            Next

        End If
    End Sub

    'Al presionar salir.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'Iniciar la búsqueda al presionar el boton Buscar. 
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        Call Busqueda()

    End Sub

#End Region

#Region "EVENTOS"

    'COMBOBOX
    'Al cambiar el indice en el combobox Tipo escandallo.
    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoEscandallo.SelectedIndexChanged

        If cbTipoEscandallo.SelectedIndex <> -1 Then

            iidEscandallo = cbTipoEscandallo.SelectedItem.itemdata

        End If

    End Sub

    'LISTVIEW
    'Al hacer dobleclick en el listview escandallos.
    Private Sub lvArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEscandallos.DoubleClick

        If lvEscandallos.Items.Count > 0 Then

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

                    codigoArticulo = lvEscandallos.Items(indice).SubItems(3).Text

                    Escandallo = lvEscandallos.Items(indice).SubItems(4).Text

                    Me.Close()

                Case Else

            End Select

        End If

    End Sub

    'Al desplegar el combobox codArticulo si no contiene items carga el combobox y activa el combobox descripción.
    Private Sub cbcodArticuloC_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcodArticuloC.DropDown, cbArticuloC.DropDown

        If cbcodArticuloC.Items.Count = 0 Then

            cbcodArticuloC.Text = "CARGANDO..."

            Call CargarArticulosC()

            cbcodArticuloC.SelectedIndex = -1

            cbcodArticuloC.DroppedDown = True

            cbArticuloC.Enabled = True

        End If

    End Sub

    '
    Private Sub cbCodArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticuloC.SelectionChangeCommitted, cbVersion.SelectionChangeCommitted

        If semaforo And cbcodArticuloC.SelectedIndex <> -1 Then

            semaforo = False

            cbArticuloC.Text = funcAR.Articulo(cbcodArticuloC.SelectedItem.itemdata)

            semaforo = True

        End If

    End Sub

    '
    Private Sub cbArticuloC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticuloC.SelectionChangeCommitted

        If semaforo And cbArticuloC.SelectedIndex <> -1 Then

            cbcodArticuloC.Text = funcAR.codArticulo(cbArticuloC.SelectedItem.itemdata)

        End If

    End Sub

    '
    Private Sub cbCodArticuloc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcodArticuloC.TextChanged, cbVersion.TextChanged

        If semaforo Then

            cbArticuloC.Text = funcAR.Articulo(cbcodArticuloC.Text)

        End If

    End Sub

    'Inicia la busqueda al pulsar intro sobre uno de los controles seleccionados.
    Private Sub Articulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Articulo.KeyDown, cbArticuloC.KeyDown, cbcodArticuloC.KeyDown, _
    cbSubTipo.KeyDown, cbTipo.KeyDown, cbTipoEscandallo.KeyDown, cbVersion.KeyDown, codArticulo.KeyDown

        If e.KeyCode = Keys.Enter Then

            Call Busqueda()

        End If

    End Sub

    'Orden de Columnas.
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

            End Select

            lvwColumnSorter.Order = SortOrder.Ascending

        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvEscandallos.Sort()

    End Sub

#End Region

    'Activa o desactiva todos los items del listview.
    Private Sub ckTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodos.CheckedChanged
        If lvEscandallos.Items.Count > 0 Then
            For Each item In lvEscandallos.Items
                item.checked = ckTodos.Checked
            Next
        End If
    End Sub

    Public Sub ExportarTodo()
        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Rows(1).Interior.Color = ColorTranslator.ToOle(Color.LightGray)
            shWorkSheet.Rows(1).Font.Color = ColorTranslator.ToOle(Color.Black)
            shWorkSheet.Range("A:A").ColumnWidth = 10
            shWorkSheet.Range("A1:C1").Font.Bold = True
            shWorkSheet.Range("A:A").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("B:B").ColumnWidth = 20
            shWorkSheet.Range("C:C").ColumnWidth = 20
            shWorkSheet.Range("C:C").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Cells(1, 1) = lvEscandallos.Columns(1).Text
            shWorkSheet.Cells(1, 2) = lvEscandallos.Columns(3).Text
            shWorkSheet.Cells(1, 3) = lvEscandallos.Columns(5).Text
            Dim ex As Integer = 1
            For i = 1 To lvEscandallos.Items.Count
                shWorkSheet.Rows.Range("A" & i + 1 & ":C" & i + 1).Interior.Color = ColorTranslator.ToOle(Color.White)
                shWorkSheet.Rows.Range("A" & i + 1 & ":C" & i + 1).Font.Color = ColorTranslator.ToOle(Color.Black)
                ex = ex + 1
                For j = 1 To lvEscandallos.Columns.Count - 1
                    If j = 1 Then
                        shWorkSheet.Cells(ex, j).Value = lvEscandallos.Items(i - 1).SubItems(j).Text
                    ElseIf j = 3 Then
                        shWorkSheet.Cells(ex, j - 1).Value = lvEscandallos.Items(i - 1).SubItems(j).Text
                    ElseIf j = 5 Then
                        shWorkSheet.Cells(ex, j - 2).Value = lvEscandallos.Items(i - 1).SubItems(j).Text
                    End If
                Next
            Next
            Dim selection As Excel.Range
            selection = objExcel.Range("A1:C1")
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("A2:C" & i)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThin
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            shWorkSheet.Range("A" & i + 1 & ":C" & i + 1).Font.Bold = True
            objExcel.UserControl = True
            bkWorkBook.SaveAs(Environ("UserProfile") & "\AppData\Local\Temp\Escandallos_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
            objExcel.Quit()
            Process.Start(Environ("UserProfile") & "\AppData\Local\Temp\Escandallos_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EXCEL" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class