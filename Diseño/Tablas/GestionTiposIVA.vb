Public Class GestionTiposIVA
    Private iidTipoIVA As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcTE As New FuncionesTiposIVA
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

        NombreTipoIVA.Text = ""
        descripcion.Text = ""
        iidTipoIVA = 0
        TipoIVA.Text = 0
        TipoRecargoEq.Text = 0
        ckActivo.Checked = True
        guardar.Text = "GUARDAR"
        indice = -1
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            Dim validar As Boolean = True
            If Repetido() Then
                validar = False
                ep1.SetError(NombreTipoIVA, "Ya existe el tipo de IVA")
            End If
            If NombreTipoIVA.Text = "" Then
                validar = False
                ep1.SetError(NombreTipoIVA, "Se ha especificar un mombre")
            End If
            If TipoIVA.Text = "" Then
                validar = False
                ep1.SetError(TipoIVA, "Se ha de especificar el tipo de IVA")
            End If
            If TipoRecargoEq.Text = "" Then
                validar = False
                ep1.SetError(TipoRecargoEq, "Se ha de especificar el tipo de recargo de equivalencia")
            End If
            If validar Then
                Dim dts As New DatosTipoIVA
                dts.gidTipoIVA = iidTipoIVA
                dts.gNombre = NombreTipoIVA.Text
                dts.gTipoIVA = TipoIVA.Text
                dts.gTipoRecargoEq = TipoRecargoEq.Text
                dts.gDescripcion = descripcion.Text
                dts.gActivo = ckActivo.Checked
                If iidTipoIVA = 0 Then 'Guardar
                    iidTipoIVA = funcTE.insertar(dts)
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
            If item.Index <> indice And item.SubItems(1).Text = NombreTipoIVA.Text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosTipoIVA) = funcTE.Mostrar(False)

            Dim dts As DatosTipoIVA
            lvSecciones.Items.Clear()

            For Each dts In lista
                With lvSecciones.Items.Add(dts.gidTipoIVA)
                    .SubItems.Add(dts.gNombre)
                    .SubItems.Add(dts.gTipoIVA & "%")
                    .SubItems.Add(dts.gTipoRecargoEq & "%")
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


    Private Sub ActualizarLinealv(ByVal dts As DatosTipoIVA)
        If indice <> -1 Then
            With lvSecciones.Items(indice)
                .SubItems(1).Text = dts.gNombre
                .SubItems(2).Text = dts.gTipoIVA & "%"
                .SubItems(3).Text = dts.gTipoRecargoEq & "%"
                .SubItems(4).Text = dts.gDescripcion
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub




    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidTipoIVA > 0 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If funcTE.EnUso(iidTipoIVA) > 0 Then
                        MsgBox("Esta tipo está en uso, no se puede eliminar.")

                    Else
                        funcTE.borrar(iidTipoIVA)
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
            iidTipoIVA = lvSecciones.Items(indice).Text
            Try
                Dim dts As DatosTipoIVA = funcTE.Mostrar1(iidTipoIVA)
                NombreTipoIVA.Text = dts.gNombre
                TipoIVA.Text = dts.gTipoIVA
                TipoRecargoEq.Text = dts.gTipoRecargoEq
                descripcion.Text = dts.gDescripcion
                ckActivo.Checked = dts.gActivo
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