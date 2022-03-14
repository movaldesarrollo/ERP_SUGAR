Public Class GestionFestivos

    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcFE As New FuncionesFestivos
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Dim colorInactivo As Color




    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionFestivos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim fechaMuestra As Object = funcFE.PrimerFestivoRepetido(dtpFecha.Value.Year + 1)
        If fechaMuestra.date.year = 1 Then
            If MsgBox("¿Crear los festivos repetidos para el año próximo?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim lista As List(Of DatosFestivo) = funcFE.Busqueda(" year(Fecha) = " & dtpFecha.Value.Date.Year & " AND Repetir = 1 ")
                For Each dts As DatosFestivo In lista
                    dts.gFecha = CDate(dts.gFecha.Day & "-" & dts.gFecha.Month & "-" & dts.gFecha.Year + 1)
                    ' If Not funcFE.EsFestividad(dts.gFecha) Then
                    funcFE.insertar(dts)
                    ' End If
                Next
            End If
        End If

    End Sub

    Private Sub gestionSecciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        colorInactivo = Color.Gray
        guardar.Enabled = Not vSoloLectura
        borrar.Enabled = Not vSoloLectura

        Call borrarcampos()
        ' Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()
        ep1.Clear()
        Nombre.Text = ""
        dtpFecha.Value = Now.Date
        ckRepetir.Checked = False

        guardar.Text = "GUARDAR"
        indice = -1
    End Sub




    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Try
            ep1.Clear()
            Dim validar As Boolean = True
            If Nombre.TextLength < 2 Then
                validar = False
                ep1.SetError(Nombre, "Se ha de especificar el nombre de la festividad")
            End If
            If Repetido() Then
                validar = False
                ep1.SetError(dtpFecha, "La fecha indicada ya está en la lista")
            End If
            If (dtpFecha.Value.DayOfWeek = DayOfWeek.Sunday Or dtpFecha.Value.DayOfWeek = DayOfWeek.Saturday) And Not ckRepetir.Checked Then
                validar = False
                ep1.SetError(dtpFecha, "La fecha indicada corresponde a fin de semana")
            End If
            If validar Then
                Dim dts As New DatosFestivo
                dts.gFecha = dtpFecha.Value.Date
                dts.gFestividad = Nombre.Text
                dts.gRepetir = ckRepetir.Checked

                If indice = -1 Then 'Guardar
                    funcFE.insertar(dts)
                    Call cargardatoslistview()
                Else 'Actualizar
                    funcFE.actualizar(dts)
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
        For Each item As ListViewItem In lvPaises.Items
            If item.Index <> indice And CDate(item.SubItems(0).Text) = dtpFecha.Value.Date Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosFestivo) = funcFE.Mostrar(dtpFecha.Value.Year)

            Dim dts As DatosFestivo
            lvPaises.Items.Clear()

            For Each dts In lista
                With lvPaises.Items.Add(dts.gFecha)
                    .SubItems.Add(dts.gFestividad)
                    .SubItems.Add(If(dts.gRepetir, "SI", "NO"))
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub ActualizarLinealv(ByVal dts As DatosFestivo)
        If indice <> -1 Then
            With lvPaises.Items(indice)
                .SubItems(0).Text = dts.gFecha
                .SubItems(1).Text = dts.gFestividad
                .SubItems(2).Text = If(dts.gRepetir, "SI", "NO")


            End With
        End If

    End Sub




    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim funcU As New funcionesUbicaciones
                   
                    funcFE.Borrar(dtpFecha.Value.Date)
                    lvPaises.Items.RemoveAt(indice)
                    Call borrarcampos()
                    guardar.Text = "GUARDAR"
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub lvPaises_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPaises.Click, lvPaises.SelectedIndexChanged

        If lvPaises.SelectedItems.Count > 0 Then
            indice = lvPaises.SelectedIndices(0)
            Try
                Dim dts As DatosFestivo = funcFE.Mostrar1(CDate(lvPaises.Items(indice).Text))
                dtpFecha.Value = dts.gFecha
                Nombre.Text = dts.gFestividad
                ckRepetir.Checked = dts.gRepetir

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


    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Call cargardatoslistview()
    End Sub

End Class