

Public Class gestionTiposEscandallo
    Private iidTipoEscandallo As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcTE As New FuncionesTiposEscandallos
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

    Private Sub gestionSecciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        colorInactivo = Color.Gray
        guardar.Enabled = Not vSoloLectura
        borrar.Enabled = Not vSoloLectura
        Call borrarcampos()
        Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()

        TipoEscandallo.Text = ""
        descripcion.Text = ""
        ckComposicion.Checked = False
        iidTipoEscandallo = 0
        ' borrar.Enabled = False
        'guardar.Enabled = False
        guardar.Text = "GUARDAR"
        indice = -1
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            Dim validar As Boolean = True
            If Repetido() Then
                validar = False
                ep1.SetError(TipoEscandallo, "Ya existe el tipo de escandallo")
            End If
            If validar Then
                Dim dts As New DatosTipoEscandallo
                dts.gidTipoEscandallo = iidTipoEscandallo
                dts.gTipoEscandallo = TipoEscandallo.Text
                dts.gDescripcion = descripcion.Text
                If iidTipoEscandallo = 0 Then 'Guardar
                    iidTipoEscandallo = funcTE.insertar(dts)
                    Call cargardatoslistview()
                Else 'Actualizar
                    funcTE.Actualizar(dts)
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
        For Each item As ListViewItem In lvSecciones.Items
            If item.Index <> indice And item.SubItems(1).Text = TipoEscandallo.Text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosTipoEscandallo) = funcTE.Mostrar()

            Dim dts As DatosTipoEscandallo
            lvSecciones.Items.Clear()

            For Each dts In lista
                With lvSecciones.Items.Add(dts.gidTipoEscandallo)
                    .SubItems.Add(dts.gTipoEscandallo)
                    .SubItems.Add(dts.gDescripcion)
                    .SubItems.Add(If(dts.gComposicion, "SI", "NO"))
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub ActualizarLinealv(ByVal dts As DatosTipoEscandallo)
        If indice <> -1 Then
            With lvSecciones.Items(indice)
                .SubItems(1).Text = dts.gTipoEscandallo
                .SubItems(2).Text = dts.gDescripcion
                .SubItems(3).Text = If(dts.gComposicion, "SI", "NO")
            End With
        End If

    End Sub




    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidTipoEscandallo > 0 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If funcTE.EnUso(iidTipoEscandallo) > 0 Then
                        MsgBox("Esta unidad está en uso, no se puede eliminar.")

                    Else
                        funcTE.borrar(iidTipoEscandallo)
                        lvSecciones.Items.RemoveAt(indice)
                    End If
                    Call borrarcampos()
                    guardar.Text = "GUARDAR"
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub lvSecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSecciones.Click, lvSecciones.SelectedIndexChanged

        If lvSecciones.SelectedItems.Count > 0 Then
            indice = lvSecciones.SelectedIndices(0)
            iidTipoEscandallo = lvSecciones.Items(indice).Text
            Try
                Dim dts As DatosTipoEscandallo = funcTE.Mostrar1(iidTipoEscandallo)
                TipoEscandallo.Text = dts.gTipoEscandallo
                descripcion.Text = dts.gDescripcion
                'guardar.Enabled = Not vSoloLectura
                ckComposicion.Checked = dts.gComposicion
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