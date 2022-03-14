Public Class GestionTiposReparacion
    Private iidTipoReparacion As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcTR As New FuncionesTiposReparacion
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
        TipoReparacion.Text = ""
        descripcion.Text = ""
        iidTipoReparacion = 0
        ckActivo.Checked = True
        indice = -1
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            Dim validar As Boolean = True
            If Repetido() Then
                validar = False
                ep1.SetError(TipoReparacion, "Ya existe el tipo de reparación")
            End If
            If validar Then
                Dim dts As New DatosTipoReparacion
                dts.gidTipoReparacion = iidTipoReparacion
                dts.gTipoReparacion = TipoReparacion.Text
                dts.gDescripcion = descripcion.Text
                dts.gActivo = ckActivo.Checked
                If iidTipoReparacion = 0 Then 'Guardar
                    iidTipoReparacion = funcTR.insertar(dts)
                    Call cargardatoslistview()
                Else 'Actualizar
                    funcTR.actualizar(dts)
                    Call ActualizarLinealv(dts)
                End If

                Call borrarcampos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Function Repetido() As Boolean
        For Each item As ListViewItem In lvSecciones.Items
            If item.Index <> indice And item.SubItems(1).Text = TipoReparacion.Text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosTipoReparacion) = funcTR.Mostrar(False)

            Dim dts As DatosTipoReparacion
            lvSecciones.Items.Clear()

            For Each dts In lista
                With lvSecciones.Items.Add(dts.gidTipoReparacion)
                    .SubItems.Add(dts.gTipoReparacion)
                    .SubItems.Add(dts.gDescripcion)
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


    Private Sub ActualizarLinealv(ByVal dts As DatosTipoReparacion)
        If indice <> -1 Then
            With lvSecciones.Items(indice)
                .SubItems(1).Text = dts.gTipoReparacion
                .SubItems(2).Text = dts.gDescripcion
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub




    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidTipoReparacion > 0 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If funcTR.EnUso(iidTipoReparacion) > 0 Then
                        MsgBox("Esta tipo está en uso, no se puede eliminar.")
                    Else
                        funcTR.borrar(iidTipoReparacion)
                        lvSecciones.Items.RemoveAt(indice)
                    End If
                    Call borrarcampos()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub lvSecciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSecciones.Click, lvSecciones.SelectedIndexChanged

        If lvSecciones.SelectedItems.Count > 0 Then
            indice = lvSecciones.SelectedIndices(0)
            iidTipoReparacion = lvSecciones.Items(indice).Text
            Try
                Dim dts As DatosTipoReparacion = funcTR.Mostrar1(iidTipoReparacion)
                TipoReparacion.Text = dts.gTipoReparacion
                descripcion.Text = dts.gDescripcion
                ckActivo.Checked = dts.gActivo
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

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