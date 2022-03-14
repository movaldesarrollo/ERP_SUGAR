Public Class GestionArticulosProv


    Dim funcP As New funcionesProveedores
    Dim funcPP As New FuncionesPedidosProv
    Dim funcCP As New FuncionesConceptosPedidosProv
    Dim funcM As New FuncionesMoneda
    Dim funcUM As New FuncionesTiposUnidad
    Dim funcUB As New funcionesUbicaciones
    Dim funcTC As New FuncionesTipoCompra
    Dim funcAR As New FuncionesArticulos
    Dim funcAP As New FuncionesArticulosProv
    Dim funcFA As New FuncionesFamilias
    Dim funcSF As New FuncionessubFamilias
    Dim vSoloLectura As Boolean
    Dim G_AConcepto As Char
    Dim iidFamilia As Integer
    Dim iidsubFamilia As Integer
    Dim iidArticulo As Integer
    Dim piidArticulo As Integer
    Dim iidArticuloProv As Integer
    'Dim dPrecio As Double
    Dim scodMoneda As String
    Dim indice As Integer
    Dim iidProveedor As Integer
    Private lvwColumnSorter As OrdenarLV
    Dim Orden As String = ""
    Dim Direccion As String
    Dim semaforo As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
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

    Property pidArticulo() As Integer
        Get
            Return piidArticulo
        End Get
        Set(ByVal value As Integer)
            piidArticulo = value
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

    Private Sub GestionArticulosProv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        bGuardarConcepto.Enabled = False
        txAño.Text = Year(Now)
        lbAño.Visible = False
        txAño.Visible = False
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 850 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 800
        End If
        Call introducirProveedores()
        Call InicializarEdicion()
        If iidProveedor > 0 Then
            cbProveedor.Text = funcP.campoProveedor(iidProveedor)
            cbProveedor.Enabled = False
            Call CargarConceptos()
            gbConceptos.Enabled = True
            If piidArticulo > 0 Then
                iidArticulo = piidArticulo
                cbProveedor.Enabled = True

                indice = BuscaidArticulo(iidArticulo)
                If indice = -1 Then
                    G_AConcepto = "G"
                    Call cargarEdicionA()
                Else
                    G_AConcepto = "A"
                    iidArticuloProv = lvConceptos.Items(indice).Text
                    Call cargarEdicionAP()
                End If
                bGuardarConcepto.Enabled = Not vSoloLectura
            End If
        Else
            gbConceptos.Enabled = False
            If piidArticulo > 0 Then
                Call cargarEdicionA()
                bGuardarConcepto.Enabled = Not vSoloLectura
            End If
        End If
        Call introducirFamilias()



        semaforo = True
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub InicializarEdicion()
        cbFamilia.Text = ""
        cbFamilia.SelectedIndex = -1
        cbSubFamilia.Items.Clear()
        cbSubFamilia.Text = ""
        cbcodArticulo.Items.Clear()
        cbcodArticulo.Text = ""
        cbNombre.Items.Clear()
        cbNombre.Text = ""
        codArticuloProv.Text = ""
        NombreProv.Text = ""
        iidFamilia = 0
        iidsubFamilia = 0
        iidArticulo = 0
        iidArticuloProv = 0
        'dPrecio = 0
        Precio.Text = 0
        'PrecioUnitario.Text = 0
        indice = -1
        scodMoneda = "EU"
        G_AConcepto = "G"
        bBorrarConcepto.Enabled = False

    End Sub

    Private Sub introducirProveedores()
        Try
            cbProveedor.Items.Clear()
            Dim lista As List(Of datosProveedor) = funcP.mostrar(True)
            Dim dts As datosProveedor
            cbProveedor.Items.Add("TODOS")
            For Each dts In lista
                cbProveedor.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidProveedor))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirFamilias()
        Try
            cbFamilia.Items.Clear()

            Dim lista As List(Of DatosFamilia) = funcFA.Mostrar(0, True)
            Dim dts As DatosFamilia
            For Each dts In lista
                cbFamilia.Items.Add(New IDComboBox(dts.gFamilia, dts.gidFamilia))
            Next
            iidFamilia = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirSubFamilias()
        Try
            cbSubFamilia.Items.Clear()
            cbSubFamilia.Text = ""
            If iidFamilia > 0 Then
                Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, True)
                Dim dts As DatosSubFamilia
                For Each dts In lista
                    cbSubFamilia.Items.Add(New IDComboBox(dts.gSubFamilia, dts.gidSubFamilia))
                Next
                iidsubFamilia = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IntroducirArticulos()
        cbcodArticulo.Items.Clear()
        cbNombre.Items.Clear()
        cbNombre.Text = ""
        cbcodArticulo.Text = ""
        NombreProv.Text = ""
        codArticuloProv.Text = ""
        Dim lista As List(Of DatosArticulo) = funcAR.Mostrar(iidFamilia, iidsubFamilia, True)
        Dim dts As DatosArticulo
        For Each dts In lista
            If dts.gcodArticulo <> "" Then cbcodArticulo.Items.Add(New IDComboBox(dts.gcodArticulo, dts.gidArticulo))
            If dts.gArticulo <> "" Then cbNombre.Items.Add(New IDComboBox(dts.gArticulo, dts.gidArticulo))
        Next
    End Sub

#End Region

#Region "CARGAR DATOS"
    Private Sub CargarConceptos()
        lvConceptos.Items.Clear()
        indice = -1
        iidArticuloProv = 0
        G_AConcepto = "G"
        lvwColumnSorter = New OrdenarLV()
        Me.lvConceptos.ListViewItemSorter = lvwColumnSorter
        Dim lista As List(Of DatosArticuloProveedor) = funcAP.Mostrar(iidProveedor, 0, 0, 0, Orden, True)
        Dim dts As DatosArticuloProveedor
        For Each dts In lista
            'With lvConceptos.Items.Add(dts.gidArticuloProv)
            '    .subitems.add(dts.gFamilia)
            '    .subitems.add(dts.gsubFamilia)
            '    .subitems.add(dts.gcodArticulo)
            '    .subitems.add(dts.gArticulo)
            '    .subitems.add(dts.gcodArticuloProv)
            '    .subitems.add(dts.gNombre)
            '    .subitems.add(dts.gidArticulo)
            'End With
            Call lvConceptosNuevaLinea(dts)
        Next
    End Sub
#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"



    Private Function lvConceptosNuevaLinea(ByVal dts As DatosArticuloProveedor) As Integer
        'Añade una linea al ListView lvConceptos
        lvwColumnSorter = New OrdenarLV()
        Me.lvConceptos.ListViewItemSorter = lvwColumnSorter
        Dim item As New ListViewItem

        With item 'lvConceptos.Items.Add(dts.gidArticuloProv)
            .Text = dts.gidArticuloProv
            .SubItems.Add(dts.gFamilia)
            .SubItems.Add(dts.gSubFamilia)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(dts.gcodArticuloProv)
            .SubItems.Add(dts.gNombre)
            .SubItems.Add(dts.gidArticulo)
            .SubItems.Add(FormatNumber(dts.gPrecio, 4))

        End With

        Return lvConceptos.Items.Add(item).Index

    End Function



    Private Sub lvConceptosActualizaLinea(ByVal dts As DatosArticuloProveedor)
        'Actualiza una linea del ListView lvConceptos
        With lvConceptos.Items(indice)
            .SubItems(1).Text = dts.gFamilia
            .SubItems(2).Text = dts.gSubFamilia
            .SubItems(3).Text = dts.gcodArticulo
            .SubItems(4).Text = dts.gArticulo
            .SubItems(5).Text = dts.gcodArticuloProv
            .SubItems(6).Text = dts.gNombre
            .SubItems(7).Text = dts.gidArticulo
            .SubItems(8).Text = FormatNumber(dts.gPrecio, 4)


        End With
    End Sub



    Private Function BuscaidArticulo(ByVal vidArticulo As Integer) As Integer
        'Busca un idArtículo en el listview y devuelve el índice
        Dim item As ListViewItem
        For Each item In lvConceptos.Items
            If item.SubItems(7).Text = vidArticulo Then Return item.Index
        Next
        Return -1

    End Function

    Private Sub cargarEdicionAP()
        'Datos del Artículo-Proveedor
        semaforo = False
        Try
            Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticuloProv)
            iidArticulo = dts.gidArticulo
            cbFamilia.Text = dts.gFamilia
            iidFamilia = If(cbFamilia.SelectedIndex = -1, 0, cbFamilia.SelectedItem.itemdata)
            Call introducirSubFamilias()
            Call IntroducirArticulos()
            cbSubFamilia.Text = dts.gSubFamilia
            iidsubFamilia = If(cbSubFamilia.SelectedIndex = -1, 0, cbSubFamilia.SelectedItem.itemdata)
            cbcodArticulo.Text = dts.gcodArticulo
            cbNombre.Text = dts.gArticulo
            codArticuloProv.Text = dts.gcodArticuloProv
            NombreProv.Text = dts.gNombre
            'dPrecio = dts.gPrecio
            Precio.Text = FormatNumber(dts.gPrecio, 4)
            'PrecioUnitario.Text = FormatNumber(dts.gPrecioUnitario, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        semaforo = True
    End Sub

    Private Sub cargarEdicionA()
        'Datos del artículo
        semaforo = False
        Try
            Dim dts As DatosArticulo = funcAR.Mostrar1(iidArticulo)
            Call InicializarEdicion()
            iidArticulo = dts.gidArticulo
            cbFamilia.Text = dts.gFamilia
            iidFamilia = If(cbFamilia.SelectedIndex = -1, 0, cbFamilia.SelectedItem.itemdata)
            Call introducirSubFamilias()
            Call IntroducirArticulos()
            cbSubFamilia.Text = dts.gSubFamilia
            iidsubFamilia = If(cbSubFamilia.SelectedIndex = -1, 0, cbSubFamilia.SelectedItem.itemdata)
            cbcodArticulo.Text = dts.gcodArticulo
            cbNombre.Text = dts.gArticulo
            codArticuloProv.Text = dts.gcodArticuloProv
            NombreProv.Text = dts.gArticulo
            'dPrecio = dts.gPrecio
            Precio.Text = FormatNumber(dts.gPrecioUnitarioC, 4)
            'PrecioUnitario.Text = FormatNumber(dts.gPrecioUnitarioC, 2)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        semaforo = True
    End Sub


#End Region

#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        pidArticulo = iidArticulo
        Me.Close()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If cbProveedor.SelectedIndex > -1 Then
            If cbProveedor.SelectedIndex = 0 Then
                InformeListadoArticulosProv.verInforme("AP.idProveedor > 0", Orden & If(Orden = "", "", " " & Direccion), txAño.Text)
                InformeListadoArticulosProv.ShowDialog()
            Else
                InformeListadoArticulosProv.verInforme(" AP.idProveedor = " & iidProveedor, Orden & If(Orden = "", "", " " & Direccion), 0)
                InformeListadoArticulosProv.ShowDialog()
            End If
        End If
    End Sub
#End Region

#Region "BOTONES CONCEPTOS"

    Private Sub bNuevoConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoConcepto.Click
        Call InicializarEdicion()
    End Sub

    Private Sub bGuardarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarConcepto.Click
        If cbProveedor.SelectedIndex = 0 Then

        Else
            Dim dts As New DatosArticuloProveedor
            dts.gidArticuloProv = iidArticuloProv
            dts.gidArticulo = iidArticulo
            dts.gidProveedor = iidProveedor
            dts.gNombre = NombreProv.Text
            dts.gArticulo = cbNombre.Text
            dts.gcodArticulo = cbcodArticulo.Text
            dts.gPrecio = Precio.Text 'dPrecio
            dts.gcodMoneda = scodMoneda
            dts.gFechaPrecio = Now.Date
            dts.gActivo = True
            dts.gcodArticuloProv = codArticuloProv.Text
            dts.gFamilia = cbFamilia.Text
            dts.gSubFamilia = cbSubFamilia.Text
            dts.gPrecioUnitario = 0 'PrecioUnitario.Text
            If G_AConcepto = "G" Then
                ' Dim indiceDuplicado = BuscaidArticulo(iidArticulo)

                If funcAP.Contador(" idProveedor = " & iidProveedor & " AND idArticulo = " & iidArticulo) > 0 Then
                    If MsgBox("El artículo ya está en la lista. ¿Desea crear otra versión del artículo para este proveedor?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                        If funcAP.Contador(" idProveedor = " & iidProveedor & " AND idArticulo = " & iidArticulo & " AND codArticuloProv = '" & codArticuloProv.Text & "' ") > 0 Then 'lvConceptos.Items(indiceDuplicado).SubItems(5).Text = codArticuloProv.Text Then
                            MsgBox("El COD.PROVEEDOR ha de ser diferente")
                        Else
                            iidArticuloProv = funcAP.Guardar(dts)
                            dts.gidArticuloProv = iidArticuloProv
                            Dim indicenuevo As Integer = lvConceptosNuevaLinea(dts)
                            lvConceptos.SelectedItems.Clear()
                            lvConceptos.Items(indicenuevo).Selected = True
                            Call Ordenar(4)
                            lvConceptos.EnsureVisible(lvConceptos.SelectedIndices(0))

                            Call InicializarEdicion()
                        End If
                    End If
                Else
                    iidArticuloProv = funcAP.Guardar(dts)
                    dts.gidArticuloProv = iidArticuloProv
                    Dim indicenuevo As Integer = lvConceptosNuevaLinea(dts)
                    lvConceptos.SelectedItems.Clear()
                    lvConceptos.Items(indicenuevo).Selected = True
                    Call Ordenar(4)
                    lvConceptos.EnsureVisible(lvConceptos.SelectedIndices(0))

                    Call InicializarEdicion()
                End If
                'If indiceDuplicado > -1 Then

                'Else

                ' End If
            Else
                If funcAP.Contador(" idProveedor = " & iidProveedor & " AND idArticuloProv <> " & iidArticuloProv & "  AND codArticuloProv = '" & codArticuloProv.Text & "' ") > 0 Then
                    'Si existe otro producto del mismo proveedor con el mismo código avisamos y no guardamos
                    MsgBox("El COD.PROVEEDOR ha de ser diferente")
                Else
                    funcAP.actualizar(dts)
                    Call lvConceptosActualizaLinea(dts)
                    Call InicializarEdicion()
                End If

            End If
        End If
       

    End Sub

    Private Sub bBorrarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrarConcepto.Click
        If indice > 0 And iidArticuloProv > 0 Then
            If MsgBox("¿Borrar la linea seleccionada?", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                funcAP.Borrar(iidArticuloProv)
                lvConceptos.Items.RemoveAt(indice)
                InicializarEdicion()
            End If
        End If
    End Sub

    Private Sub BBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscarProducto.Click
        Dim BA As New lbBusquedaArticulo
        BA.SoloLectura = vSoloLectura
        BA.pidProveedor = 0
        BA.pModo = "COMPRABLE"
        BA.ShowDialog()
        iidArticulo = BA.pidArticulo
        Call cargarEdicionA()
        bGuardarConcepto.Enabled = Not vSoloLectura
    End Sub



#End Region

#Region "EVENTOS"

    Private Sub cbFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFamilia.SelectionChangeCommitted
        If semaforo Then
            If cbFamilia.SelectedIndex > -1 Then
                iidFamilia = cbFamilia.SelectedItem.itemdata
                Call introducirSubFamilias()
                Call IntroducirArticulos()
                bNuevoConcepto.Enabled = True
                If cbNombre.Text <> "" And NombreProv.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura
            End If
        End If
    End Sub

    Private Sub cbsubFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSubFamilia.SelectionChangeCommitted
        If semaforo Then
            If cbSubFamilia.SelectedIndex > -1 Then
                iidsubFamilia = cbSubFamilia.SelectedItem.itemdata
                Call IntroducirArticulos()
                bNuevoConcepto.Enabled = True
                If cbNombre.Text <> "" And NombreProv.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura
            End If
        End If
    End Sub

    Private Sub codArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcodArticulo.SelectionChangeCommitted
        If semaforo Then
            If cbcodArticulo.SelectedIndex > -1 Then
                iidArticulo = cbcodArticulo.SelectedItem.itemdata
                Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticulo)
                If dts.gidArticulo = 0 Then 'Si no lo ha encontrado en ArticulosProveedor
                    Dim dtsA As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                    cbNombre.Text = dtsA.gArticulo
                    cbFamilia.Text = dtsA.gFamilia
                    cbSubFamilia.Text = dtsA.gSubFamilia
                Else
                    codArticuloProv.Text = dts.gcodArticuloProv
                    NombreProv.Text = dts.gNombre
                    cbNombre.Text = dts.gArticulo
                    cbFamilia.Text = dts.gFamilia
                    cbSubFamilia.Text = dts.gSubFamilia
                End If
                If cbNombre.Text <> "" And NombreProv.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura
                bNuevoConcepto.Enabled = True
            End If
        End If
    End Sub

    Private Sub cbNombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNombre.SelectionChangeCommitted
        If cbNombre.SelectedIndex > -1 Then

            iidArticulo = cbNombre.SelectedItem.itemdata
            Dim dts As DatosArticuloProveedor = funcAP.Mostrar1(iidArticulo)
            If dts.gidArticulo = 0 Then 'Si no lo ha encontrado en ArticulosProveedor
                Dim dtsA As DatosArticulo = funcAR.Mostrar1(iidArticulo)
                cbcodArticulo.Text = dtsA.gcodArticulo
                cbFamilia.Text = dtsA.gFamilia
                cbSubFamilia.Text = dtsA.gSubFamilia
            Else
                codArticuloProv.Text = dts.gcodArticuloProv
                NombreProv.Text = dts.gNombre
                cbcodArticulo.Text = dts.gcodArticulo
                cbFamilia.Text = dts.gFamilia
                cbSubFamilia.Text = dts.gSubFamilia
            End If
            If cbNombre.Text <> "" And NombreProv.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura
            bNuevoConcepto.Enabled = True
        End If
    End Sub

    Private Sub lvConceptos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.DoubleClick
        If lvConceptos.SelectedItems.Count > 0 Then
            Dim GA As New GestionArticulo
            GA.pidArticulo = lvConceptos.SelectedItems(0).SubItems(7).Text
            GA.ShowDialog()
        End If
    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click, lvConceptos.SelectedIndexChanged
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
            iidArticuloProv = lvConceptos.Items(indice).Text
            Call cargarEdicionAP()
            bNuevoConcepto.Enabled = True
            bGuardarConcepto.Enabled = False
            bBorrarConcepto.Enabled = Not vSoloLectura
            G_AConcepto = "A"
        End If
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectedIndexChanged
        If cbProveedor.SelectedIndex > -1 Then
            If cbProveedor.SelectedIndex = 0 Then
                observacionesProv.Text = "Pulse IMPRIMIR para obtener un listado de todos los articulos de todos los proveedores."
                bGuardarConcepto.Enabled = False
                lbAño.Visible = True
                txAño.Visible = True
            Else
                iidProveedor = cbProveedor.SelectedItem.itemdata
                observacionesProv.Text = funcP.campoObservaciones(iidProveedor)
                BusquedaLibre.Text = ""
                codArticuloProv.Text = ""
                Call CargarConceptos()
                gbConceptos.Enabled = True
                lbAño.Visible = False
                txAño.Visible = False
                If piidArticulo > 0 Then
                    iidArticulo = piidArticulo
                    Call cargarEdicionA()
                    bGuardarConcepto.Enabled = Not vSoloLectura
                End If
            End If
            
        End If

    End Sub

    Private Sub lvConceptos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptos.ColumnClick
        Call Ordenar(e.Column)

    End Sub

    Private Sub Ordenar(ByVal Columna As Integer)

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (Columna = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            Direccion = "ASC"
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
                Direccion = "DESC"
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
                Direccion = "ASC"
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorter.SortColumn = Columna
            Select Case Columna
                Case 0
                    Orden = "idArticuloProv"
                Case 1
                    Orden = "Familia"
                Case 2
                    Orden = "subFamilia"
                Case 3
                    Orden = "codArticulo"
                Case 4
                    Orden = "Articulo"
                Case 5
                    Orden = "codArticuloProv"
                Case 6
                    Orden = "Nombre"

            End Select

            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        Me.lvConceptos.Sort()
        If lvConceptos.SelectedItems.Count > 0 Then
            indice = lvConceptos.SelectedIndices(0)
        End If

    End Sub

    Private Sub Precio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Precio.Click, codArticuloProv.Click
        sender.SelectAll()
    End Sub

    Private Sub codArticuloProv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codArticuloProv.TextChanged, NombreProv.TextChanged, Precio.TextChanged
        If semaforo Then
            If cbNombre.Text <> "" And NombreProv.Text <> "" Then bGuardarConcepto.Enabled = Not vSoloLectura
        End If
    End Sub

    Private Sub Precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Precio.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Precio.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    'Private Sub PrecioUnitario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
    '    If KeyAscii = Asc(".") Then
    '        e.KeyChar = ","
    '    End If
    '    If InStr(PrecioUnitario.Text, ",") Then
    '        KeyAscii = CShort(SoloNumeros(KeyAscii))
    '    Else
    '        KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
    '    End If
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub BusquedaLibre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BusquedaLibre.TextChanged
        If iidProveedor > 0 Then
            lvConceptos.Items.Clear()
            indice = -1
            iidArticuloProv = 0
            G_AConcepto = "G"
            lvwColumnSorter = New OrdenarLV()
            Me.lvConceptos.ListViewItemSorter = lvwColumnSorter
            Dim lista As List(Of DatosArticuloProveedor) = funcAP.Mostrar(iidProveedor, BusquedaLibre.Text, Orden, True)
            Dim dts As DatosArticuloProveedor
            For Each dts In lista
                Call lvConceptosNuevaLinea(dts)
            Next
        End If
    End Sub

    Private Sub bverArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bverArticulo.Click
        If iidArticulo > 0 Then
            Dim GA As New GestionArticulo
            GA.pidArticulo = iidArticulo
            GA.ShowDialog()
        End If

    End Sub

#End Region

End Class