

Public Class gestionSecciones
    Private iidSeccion As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcSE As New FuncionesSecciones
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
        Call IntroducirVistas()
        Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()
        descripcion.Text = ""
        Seccion.Text = ""
        ckActivo.Checked = True
        iidSeccion = 0
        PrecioHora.Text = 0
        cbVista.Text = ""
        Orden.Text = lvSecciones.Items.Count + 1
        ' borrar.Enabled = False
        'guardar.Enabled = False
        guardar.Text = "GUARDAR"
        indice = -1
        ep1.Clear()
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            Dim validar As Boolean = True
            If Repetido() Then
                validar = False
                ep1.SetError(Seccion, "Ya existe el nombre de sección")
            End If
            If Seccion.Text = "" Then
                validar = False
                ep1.SetError(Seccion, "Ha de indicar el nombre de la sección")
            End If
            If cbVista.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbVista, "Se ha de seleccionar la vista")
            End If
            If validar Then
                Dim dts As New DatosSeccion
                dts.gidSeccion = iidSeccion
                dts.gSeccion = UCase(Seccion.Text)
                dts.gActivo = ckActivo.Checked
                dts.gDescripcion = descripcion.Text
                dts.gPrecioHora = PrecioHora.Text
                dts.gOrden = Orden.Text
                dts.gVista = cbVista.Text
                If iidSeccion = 0 Then 'Guardar
                    iidSeccion = funcSE.insertar(dts)

                Else 'Actualizar
                    funcSE.actualizar(dts)
                    ' Call ActualizarLinealv(dts)
                End If
                funcSE.Renumerar()
                Call cargardatoslistview()
                'nuevo.Enabled = True
                Call borrarcampos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      
    End Sub


    Private Function Repetido() As Boolean
        For Each item As ListViewItem In lvSecciones.Items
            If item.Index <> indice And item.SubItems(1).Text = UCase(Seccion.Text) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of DatosSeccion) = funcSE.Mostrar(False)

            Dim dts As DatosSeccion
            lvSecciones.Items.Clear()

            For Each dts In lista
                With lvSecciones.Items.Add(dts.gidSeccion)
                    .SubItems.Add(dts.gSeccion)
                    .SubItems.Add(FormatCurrency(dts.gPrecioHora))
                    .SubItems.Add(dts.gDescripcion)
                    .SubItems.Add(dts.gOrden)
                    .SubItems.Add(dts.gVista)
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


    Private Sub ActualizarLinealv(ByVal dts As DatosSeccion)
        If indice <> -1 Then
            With lvSecciones.Items(indice)
                .SubItems(1).Text = dts.gSeccion
                .SubItems(2).Text = FormatCurrency(dts.gPrecioHora)
                .SubItems(3).Text = dts.gDescripcion
                .SubItems(4).Text = dts.gOrden
                .SubItems(5).Text = dts.gVista
                If dts.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub


    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidSeccion > 0 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                    If funcSE.EstaEnUso(iidSeccion) > 0 Then
                        MsgBox("Esta sección está en uso, no se puede eliminar. Alternativamente puede desactivarla.")

                    Else
                        funcSE.borrar(iidSeccion)
                        funcSE.Renumerar()
                        Call cargardatoslistview()
                        'lvSecciones.Items.RemoveAt(indice)

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
            iidSeccion = lvSecciones.Items(indice).Text
            Try
                Dim dts As DatosSeccion = funcSE.Mostrar1(iidSeccion)
                Seccion.Text = dts.gSeccion
                descripcion.Text = dts.gDescripcion
                sDescripcion = descripcion.Text
                ckActivo.Checked = dts.gActivo
                PrecioHora.Text = FormatNumber(dts.gPrecioHora, 2)
                Orden.Text = dts.gOrden
                cbVista.Text = dts.gVista
                'guardar.Enabled = Not vSoloLectura
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'borrar.Enabled = Not vSoloLectura
            'nuevo.Enabled = True
            'guardar.Text = "ACTUALIZAR"
        End If
    End Sub

    Private Sub IntroducirVistas()
        cbVista.Items.Clear()
        cbVista.Items.Add("TALLER")
        cbVista.Items.Add("ELECTRÓNICA")
        cbVista.Items.Add("LOGÍSTICA")
    End Sub


    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        Call borrarcampos()
    End Sub

   

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 769
        Me.Height = If(Me.Height < 510, 510, Me.Height)
    End Sub

    Private Sub PrecioHora_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrecioHora.Click, Orden.Click
        sender.selectall()
    End Sub

    Private Sub PrecioHora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PrecioHora.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PrecioHora.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub


    Private Sub Orden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Orden.KeyPress
        'Solo dejamos escribir un nº de orden posible
        Dim n As Integer = 1
        Dim numerosPosibles As String = ""
        If n > 9 Then
            numerosPosibles = "1234567890"
        Else
            For Each item As ListViewItem In lvSecciones.Items
                numerosPosibles = numerosPosibles & CStr(n)
                n = n + 1
            Next
        End If
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If InStr(numerosPosibles, Chr(KeyAscii)) = 0 Then
            KeyAscii = 0
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub




End Class