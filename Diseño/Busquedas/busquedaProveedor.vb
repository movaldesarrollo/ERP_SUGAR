Public Class busquedaproveedor

    Private desktopSize As Size
    Private vCodProveedor As String
    Private vNombre As String = ""
    Private iidProveedor As Integer
    Private vsoloLectura As Boolean
    Private funcPR As New funcionesProveedores
    Private Orden As String
    'Private lvwColumnSorter As OrdenarLV
    Private Proveedores As List(Of Integer)
    Private sBusqueda As String
    Private Modo As Char
    Private colorInactivo As Color
    Private direccion As String
    Private columna As Integer

    Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Property pidproveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value

        End Set
    End Property

    Property pCodProveedor() As Integer
        Get
            Return vCodProveedor
        End Get
        Set(ByVal value As Integer)
            vCodProveedor = value

        End Set
    End Property

    Property pNombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Property pModo() As Char
        Get
            Return Modo
        End Get
        Set(ByVal value As Char)
            Modo = value
        End Set
    End Property

    Private Sub busquedaproveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        If Modo = "B" Then
            ckBajas.Checked = False
            ckBajas.Enabled = False
        End If
        direccion = "ASC"
        colorInactivo = Color.Gray
        Proveedores = New List(Of Integer)
        codproveedor.Focus()
        Call IntroducirTipos()
        Call busqueda()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call cerrarformulario()
    End Sub

    Private Sub cerrarformulario()
        lvProveedores.Items.Clear()
        codproveedor.Text = ""
        nombrecomercial.Text = ""
        nombrefiscal.Text = ""
        nif.Text = ""
        Orden = ""
        Me.Close()
    End Sub

    Private Sub IntroducirTipos()

        Dim func As New FuncionesTipoCompra
        Dim lista As List(Of DatosTipoCompra) = func.Mostrar()
        Dim dts As DatosTipoCompra
        cbTipo.Items.Add(New IDComboBox("TODOS", 0))
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoCompra, dts.gIdTipoCompra))
        Next
        cbTipo.SelectedIndex = 0
    End Sub

    Private Sub busqueda()

        'instrucciones para búsqueda de proveedor
        sBusqueda = ""

        If codproveedor.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " codproveedor like '" & codproveedor.Text & "%'"
        End If

        If nif.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nif like '" & nif.Text & "%'"
        End If

        If nombrecomercial.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nombrecomercial like '%" & Replace(nombrecomercial.Text, "'", "''") & "%'"
        End If
        If nombrefiscal.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " nombrefiscal like '%" & Replace(nombrefiscal.Text, "'", "''") & "%'"
        End If
        If cbTipo.SelectedIndex <> -1 And cbTipo.Text <> "TODOS" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Proveedores.idTipoCompra = " & cbTipo.SelectedItem.itemdata
        End If
        If ckBajas.Checked = False Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Proveedores.Activo = 1 "
        End If
        If codContable.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " codContable like '" & codContable.Text & "%'"
        End If

        sBusqueda = If(sBusqueda = "", "", " WHERE " & sBusqueda)
        'búsqueda del proveedor
        Call ActualizarLV()

    End Sub

    Private Sub ActualizarLV()
        Try
            lvProveedores.Items.Clear()
            Proveedores.Clear()
            Dim lista As List(Of datosProveedor) = funcPR.Busqueda(sBusqueda, Orden)
            For Each dts As datosProveedor In lista
                Proveedores.Add(dts.gidProveedor)
                With lvProveedores.Items.Add(dts.gidProveedor)
                    .SubItems.Add(dts.gcodProveedor)
                    .SubItems.Add(dts.gcodContable)
                    .SubItems.Add(dts.gnombrecomercial)
                    .SubItems.Add(dts.gnombrefiscal)
                    .SubItems.Add(dts.gnif)

                    If dts.gActivo Then
                        .ForeColor = Color.Black
                    Else
                        .ForeColor = colorInactivo
                    End If
                End With

            Next
            Contador.Text = lvProveedores.Items.Count
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ActualizarLineaLV()
        Dim indice As Integer = -1
        If lvProveedores.SelectedItems.Count > 0 Then
            indice = lvProveedores.SelectedIndices(0)
        End If
        If indice <> -1 Then
            iidProveedor = lvProveedores.Items(indice).Text
            Dim dtsPR As datosProveedor = funcPR.mostrar1(iidProveedor)
            With lvProveedores.Items(indice)
                .SubItems(1).Text = dtsPR.gcodProveedor
                .SubItems(2).Text = dtsPR.gcodContable
                .SubItems(3).Text = dtsPR.gnombrecomercial
                .SubItems(4).Text = dtsPR.gnombrefiscal
                .SubItems(5).Text = dtsPR.gnif
                If dtsPR.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub

    Private Sub RecalcularTotalizadores()

        Contador.Text = lvProveedores.Items.Count

    End Sub

    Private Sub codproveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codproveedor.KeyPress, codContable.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub nif_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nif.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub nombrecomercial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nombrecomercial.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub nombrefiscal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nombrefiscal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = 13 Then
            Call busqueda()
        End If
    End Sub

    Private Sub lvProveedores_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProveedores.DoubleClick
        If lvProveedores.SelectedItems.Count > 0 Then
            Dim indice As Integer = lvProveedores.SelectedIndices(0)
            iidProveedor = lvProveedores.Items(indice).Text
            vCodProveedor = lvProveedores.Items(indice).SubItems(1).Text
            vNombre = lvProveedores.Items(indice).SubItems(3).Text
            If Modo = "B" Then
                Me.Close()
            Else
                Dim GP As New GestionProveedores
                GP.pidProveedor = iidProveedor
                GP.SoloLectura = vsoloLectura
                GP.pindice = indice
                GP.pProveedores = Proveedores
                GP.ShowDialog()
                'Call ActualizarLV()
                Call ActualizarLineaLV()
                Call RecalcularTotalizadores()
            End If

        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 684
        Me.Height = If(Me.Height < 300, 300, Me.Height)
        'lvProveedores.Height = Me.Height - 224
    End Sub

    Private Sub nombrefiscal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged, codproveedor.TextChanged, nif.TextChanged, nombrecomercial.TextChanged, nombrefiscal.TextChanged, ckBajas.CheckedChanged, codContable.TextChanged
        Call busqueda()
    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        cbTipo.Text = "TODOS"
        nombrefiscal.Text = ""
        nif.Text = ""
        codproveedor.Text = ""
        nombrecomercial.Text = ""
        codContable.Text = ""
        ckBajas.Checked = False
        Call busqueda()
    End Sub

    Private Sub lvArticulos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvProveedores.ColumnClick

        '' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        'If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
        '    'Direccion = "ASC"
        '    If (lvwColumnSorter.Order = SortOrder.Ascending) Then
        '        lvwColumnSorter.Order = SortOrder.Descending
        '        'Direccion = "DESC"
        '    Else
        '        lvwColumnSorter.Order = SortOrder.Ascending
        '        ' Direccion = "ASC"
        '    End If
        'Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
        '    lvwColumnSorter.SortColumn = e.Column
        '    'Select Case e.Column
        '    '    Case 0
        '    '        Orden = "idArticulo"
        '    '    Case 1
        '    '        Orden = "codArticulo"
        '    '    Case 2
        '    '        Orden = "TipoCompra"
        '    '    Case 3
        '    '        Orden = "Familia"
        '    '    Case 4
        '    '        Orden = "SubFamilia"
        '    '    Case 5
        '    '        Orden = "Articulo"
        '    '    Case 6
        '    '        Orden = "Precio"
        '    '    Case 7
        '    '        Orden = "CantidadStock"
        '    '    Case 8
        '    '        Orden = " StockMinimo"
        '    'End Select

        '    lvwColumnSorter.Order = SortOrder.Ascending
        'End If

        '' Realizar la ordenación con estas nuevas opciones de ordenación. 
        'lvProveedores.Sort()

        If e.Column = columna Then
            If direccion = "ASC" Then
                direccion = "DESC"
            Else
                direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                Orden = "idProveedor"
            Case 1
                Orden = "codProveedor"
            Case 2
                Orden = "codContable"
            Case 3
                Orden = "NombreComercial"
            Case 4
                Orden = "NombreFiscal"
            Case 5
                Orden = "NIF"

        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Dim GG As New GestionProveedores
        GG.pidProveedor = 0
        GG.SoloLectura = vsoloLectura
        GG.ShowDialog()
        Call ActualizarLV()

    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        InformeListadoProveedores.verInforme(sBusqueda, Orden)
        InformeListadoProveedores.ShowDialog()
    End Sub

End Class