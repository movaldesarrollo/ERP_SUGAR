Public Class GestionBancos
    Private iidBanco As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sTipoAviso As String
    Private funcBA As New FuncionesBancos
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider  'Para los avisos
    Dim colorInactivo As Color
    Private funcCB As New FuncionesCuentasBancarias
    Private lvwColumnSorter As OrdenarLV



    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub gestionSecciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        lvwColumnSorter = New OrdenarLV()
        lvBancos.ListViewItemSorter = lvwColumnSorter
        colorInactivo = Color.Gray
        guardar.Enabled = Not vSoloLectura
        borrar.Enabled = Not vSoloLectura
        Call introducirPaises()
        Call borrarcampos()
        Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()
        ep1.Clear()
        Nombre.Text = ""
        cbPais.Text = ""
        cbPais.SelectedIndex = -1
        iidBanco = 0
        codBanco.Text = ""
        guardar.Text = "GUARDAR"
        ckActivo.Checked = True
        Swift.Text = ""
        indice = -1
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            ep1.Clear()
            Dim validar As Boolean = True
            If Nombre.TextLength < 2 Then
                validar = False
                ep1.SetError(Nombre, "Se ha de especificar el nombre del banco")
            End If
            If Repetido() Then
                validar = False
                ep1.SetError(Nombre, "Ya existe el banco")
            End If
            If cbPais.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbPais, "Se ha de seleccionar un país")
            End If
            If Swift.TextLength < 4 Then
                ep2.SetError(Swift, "No se ha especificado el valor SWIFT.")
            End If
            If validar Then
                Dim dts As New DatosBanco
                dts.gidBanco = iidBanco
                dts.gBanco = Nombre.Text
                dts.gcodigoBanco = codBanco.Text
                dts.gidPais = cbPais.SelectedItem.gidpais
                dts.gActivo = ckActivo.Checked
                dts.gSWIFT_BIC = Swift.Text
                If iidBanco = 0 Then 'Guardar
                    iidBanco = funcBA.insertar(dts)
                    Call cargardatoslistview()
                    For Each item As ListViewItem In lvBancos.Items
                        If item.Text = iidBanco Then
                            lvBancos.EnsureVisible(item.Index)
                        End If
                    Next

                Else 'Actualizar
                    funcBA.actualizar(dts)
                    Call ActualizarLinealv(dts)
                End If
                'nuevo.Enabled = True
                Call borrarcampos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Function Repetido() As Boolean
        For Each item As ListViewItem In lvBancos.Items
            If item.Index <> indice And item.SubItems(2).Text = Nombre.Text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosBanco) = funcBA.Mostrar(False)

            Dim dts As DatosBanco
            lvBancos.Items.Clear()
            lvwColumnSorter = New OrdenarLV()
            lvBancos.ListViewItemSorter = lvwColumnSorter
            For Each dts In lista
                With lvBancos.Items.Add(dts.gidBanco)
                    .SubItems.Add(dts.gcodigoBanco)
                    .SubItems.Add(dts.gBanco)
                    .SubItems.Add(dts.gPais)
                    If dts.gActivo Then
                        .ForeColor = Color.Black
                    Else
                        .ForeColor = colorInactivo
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub ActualizarLinealv(ByVal dts As DatosBanco)
        If indice <> -1 Then
            lvwColumnSorter = New OrdenarLV()
            lvBancos.ListViewItemSorter = lvwColumnSorter
            With lvBancos.Items(indice)
                .SubItems(1).Text = dts.gcodigoBanco
                .SubItems(2).Text = dts.gBanco
                .SubItems(3).Text = dts.gPais
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub




    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidBanco > 1 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    If funcCB.ExisteBanco(iidBanco) Then
                        MsgBox("Esta Banco está asignado a alguna cuenta, no se puede eliminar.")
                    Else
                        funcBA.borrar(iidBanco)
                        lvBancos.Items.RemoveAt(indice)
                        lvwColumnSorter = New OrdenarLV()
                        lvBancos.ListViewItemSorter = lvwColumnSorter
                    End If
                    Call borrarcampos()
                    guardar.Text = "GUARDAR"
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub lvBancos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBancos.Click, lvBancos.SelectedIndexChanged

        If lvBancos.SelectedItems.Count > 0 Then
            indice = lvBancos.SelectedIndices(0)
            iidBanco = lvBancos.Items(indice).Text
            Try
                Dim dts As DatosBanco = funcBA.Mostrar1(iidBanco)
                Nombre.Text = dts.gBanco
                codBanco.Text = dts.gcodigoBanco
                cbPais.Text = dts.gPais
                Swift.Text = dts.gSWIFT_BIC
                ckActivo.Checked = dts.gActivo

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'borrar.Enabled = Not vSoloLectura
            'nuevo.Enabled = True
            'guardar.Text = "ACTUALIZAR"
        End If
    End Sub

    Private Sub introducirPaises()
        Try
            Dim funcPA As New funcionesPaises
            cbPais.Items.Clear()
            Dim lista As List(Of datosPais) = funcPA.mostrar()
            For Each dts As datosPais In lista
                cbPais.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        Call borrarcampos()
    End Sub



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 623
        Me.Height = If(Me.Height < 510, 510, Me.Height)
    End Sub

    Private Sub lvBancos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvBancos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If (e.Column = lvwColumnSorter.SortColumn) Then ' Revertir la dirección de ordenación actual de esta columna. 
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else ' Establecer el número de columna que se va a ordenar; de forma predeterminada, en orden ascendente. 
            lvwColumnSorter.SortColumn = e.Column

            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Realizar la ordenación con estas nuevas opciones de ordenación. 
        lvBancos.Sort()

    End Sub

    Private Sub bPais_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bPais.Click
        Dim pais As String = cbPais.Text
        Dim GG As New GestionPaises
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirPaises()
        cbPais.Text = pais
    End Sub


End Class