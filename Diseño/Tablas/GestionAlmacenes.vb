

Public Class gestionAlmacenes
    Private iidAlmacen As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcAL As New FuncionesAlmacenes
    Private funcU As New funcionesUbicaciones
    Private funcTA As New FuncionesTiposAlmacenes
    Private ep1 As New ErrorProvider
    Dim colorInactivo As Color


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub gestionAlmacenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        colorInactivo = Color.Gray
        guardar.Enabled = Not vSoloLectura
        borrar.Enabled = Not vSoloLectura
        Call borrarcampos()
        Call CargarTipos()
        Call CargarDirecciones()
        Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()
        descripcion.Text = ""
        Almacen.Text = ""
        ckActivo.Checked = True
        iidAlmacen = 0
        cbTipoAlmacen.Text = ""
        cbTipoAlmacen.SelectedIndex = -1
        If cbDirecciones.Items.Count = 1 Then
            cbDirecciones.SelectedIndex = 0
            cbDirecciones.Text = cbDirecciones.Items(0).ToString
        Else
            cbDirecciones.Text = ""
        End If
        indice = -1
    End Sub

    Private Sub CargarDirecciones()
        cbDirecciones.Items.Clear()
        Dim Lista As List(Of datosUbicacion) = funcU.mostrarPropias(1, 0, 0, 0, 0)
        For Each dts As datosUbicacion In Lista
            cbDirecciones.Items.Add(New IDComboBox(dts.glocalidad & " - " & dts.gdireccion, dts.gidUbicacion))
        Next
        If Lista.Count = 1 Then cbDirecciones.SelectedIndex = 0 'Si solo hay uno, lo ponemos
    End Sub


    Private Sub CargarTipos()
        cbTipoAlmacen.Items.Clear()
        Dim Lista As List(Of DatosTipoAlmacen) = funcTA.Mostrar
        For Each dts As DatosTipoAlmacen In Lista
            cbTipoAlmacen.Items.Add(New IDComboBox(dts.gTipoAlmacen, dts.gidTipoAlmacen))
        Next
        If Lista.Count = 1 Then cbTipoAlmacen.SelectedIndex = 0 'Si solo hay uno, lo ponemos
    End Sub


    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            Dim validar As Boolean = True
            If Repetido() Then
                validar = False
                ep1.SetError(Almacen, "Ya existe el nombre de almacén")
            End If
            If cbDirecciones.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbDirecciones, "Se ha de seleecionar una dirección")
            End If
            If cbTipoAlmacen.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbTipoAlmacen, "Se ha de seleccionar un tipo de almacén")
            End If
            If validar Then
                Dim dts As New DatosAlmacen
                dts.gidAlmacen = iidAlmacen
                dts.gAlmacen = UCase(Almacen.Text)
                dts.gActivo = ckActivo.Checked
                dts.gDescripcion = descripcion.Text
                dts.gidUbicacion = cbDirecciones.SelectedItem.itemdata
                dts.gFechaAlta = Now.Date
                dts.gFechaBaja = Now.Date
                dts.gidTipoAlmacen = cbTipoAlmacen.SelectedItem.itemdata
                dts.gTipoAlmacen = cbTipoAlmacen.Text
                If iidAlmacen = 0 Then 'Guardar
                    iidAlmacen = funcAL.insertar(dts)
                    Call cargardatoslistview()
                Else 'Actualizar
                    funcAL.actualizar(dts)
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
        For Each item As ListViewItem In lvAlmacenes.Items
            If item.Index <> indice And item.SubItems(1).Text = UCase(Almacen.Text) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosAlmacen) = funcAL.Mostrar(False)

            Dim dts As DatosAlmacen
            lvAlmacenes.Items.Clear()
            For Each dts In lista
                With lvAlmacenes.Items.Add(dts.gidAlmacen)
                    .SubItems.Add(dts.gAlmacen)
                    .SubItems.Add(dts.gTipoAlmacen)
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


    Private Sub ActualizarLinealv(ByVal dts As DatosAlmacen)
        If indice <> -1 Then
            With lvAlmacenes.Items(indice)
                .SubItems(1).Text = dts.gAlmacen
                .SubItems(2).Text = dts.gTipoAlmacen
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub


    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidAlmacen > 0 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If funcAL.EstaEnUso(iidAlmacen) > 0 Then
                        MsgBox("Este almacén está en uso, no se puede eliminar. Alternativamente puede desactivarlo.")
                    Else
                        funcAL.Borrar(iidAlmacen)
                        lvAlmacenes.Items.RemoveAt(indice)
                    End If
                    Call borrarcampos()
                    guardar.Text = "GUARDAR"
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub lvAlmacenes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAlmacenes.Click, lvAlmacenes.SelectedIndexChanged

        If lvAlmacenes.SelectedItems.Count > 0 Then
            indice = lvAlmacenes.SelectedIndices(0)
            iidAlmacen = lvAlmacenes.Items(indice).Text
            Try
                Dim dts As DatosAlmacen = funcAL.Mostrar1(iidAlmacen)
                Almacen.Text = dts.gAlmacen
                descripcion.Text = dts.gDescripcion
                sDescripcion = descripcion.Text
                cbDirecciones.Text = dts.gUbicacion
                ckActivo.Checked = dts.gActivo
                cbTipoAlmacen.Text = dts.gTipoAlmacen
                'guardar.Enabled = Not vSoloLectura
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'borrar.Enabled = Not vSoloLectura
            'nuevo.Enabled = True
            'guardar.Text = "ACTUALIZAR"
        End If
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

End Class