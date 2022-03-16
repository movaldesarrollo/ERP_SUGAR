Public Class GestionPaises
    Private iidPais As Integer
    Private indice As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcTE As New funcionesPaises
    Private ep1 As New ErrorProvider
    Dim colorInactivo As Color
    Private funcMO As New FuncionesMoneda



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
        Call introducirMonedas()
        Call borrarcampos()
        Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()
        ep1.Clear()
        Nombre.Text = ""
        cbMoneda.Text = ""
        cbMoneda.SelectedIndex = -1
        iidPais = 0
        codPais.Text = ""
        ckExportacion.Checked = False
        ckNIFObligatorio.Checked = False
        guardar.Text = "GUARDAR"
        indice = -1
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click

        Try
            ep1.Clear()
            Dim validar As Boolean = True
            If Nombre.TextLength < 2 Then
                validar = False
                ep1.SetError(Nombre, "Se ha de especificar el nombre del país")
            End If
            If Repetido() Then
                validar = False
                ep1.SetError(Nombre, "Ya existe el Pais")
            End If
            If cbMoneda.SelectedIndex = -1 Then
                validar = False
                ep1.SetError(cbMoneda, "Se ha de seleccionar la moneda")
            End If
            If validar Then
                Dim dts As New datosPais
                dts.gidPais = iidPais
                dts.gPais = Nombre.Text
                dts.gcodPais = codPais.Text
                dts.gcodMoneda = cbMoneda.SelectedItem.itemdata
                dts.gExportacion = ckExportacion.Checked
                dts.gNIFObligatorio = ckNIFObligatorio.Checked
                If iidPais = 0 Then 'Guardar
                    iidPais = funcTE.insertar(dts)
                    Call cargardatoslistview()
                Else 'Actualizar
                    funcTE.actualizar(dts)
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
            If item.Index <> indice And item.SubItems(2).Text = Nombre.Text Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub cargardatoslistview()
        Try
            Dim lista As List(Of datosPais) = funcTE.mostrar()

            Dim dts As datosPais
            lvPaises.Items.Clear()

            For Each dts In lista
                With lvPaises.Items.Add(dts.gidPais)
                    .SubItems.Add(dts.gcodPais)
                    .SubItems.Add(dts.gPais)
                    .SubItems.Add(dts.gDivisa)
                    .SubItems.Add(If(dts.gExportacion, "SI", "NO"))
                    .SubItems.Add(If(dts.gNIFObligatorio, "SI", "NO"))
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub ActualizarLinealv(ByVal dts As datosPais)
        If indice <> -1 Then
            With lvPaises.Items(indice)
                .SubItems(1).Text = dts.gcodPais
                .SubItems(2).Text = dts.gPais
                .SubItems(3).Text = dts.gDivisa
                .SubItems(4).Text = If(dts.gExportacion, "SI", "NO")
                .SubItems(5).Text = If(dts.gNIFObligatorio, "SI", "NO")

            End With
        End If

    End Sub




    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidPais > 1 And indice > -1 Then
            Try
                If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Dim funcU As New funcionesUbicaciones
                    If funcU.ExistePais(iidPais) Then
                        MsgBox("Esta Pais está en uso, no se puede eliminar.")
                    Else
                        funcTE.borrar(iidPais)
                        lvPaises.Items.RemoveAt(indice)
                    End If
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
            iidPais = lvPaises.Items(indice).Text
            Try
                Dim dts As datosPais = funcTE.mostrar1(iidPais)
                Nombre.Text = dts.gPais
                codPais.Text = dts.gcodPais
                cbMoneda.Text = dts.gDivisa
                ckExportacion.Checked = dts.gExportacion
                ckNIFObligatorio.Checked = dts.gNIFObligatorio
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'borrar.Enabled = Not vSoloLectura
            'nuevo.Enabled = True
            'guardar.Text = "ACTUALIZAR"
        End If
    End Sub

    Private Sub introducirMonedas()
        Try
            cbMoneda.Items.Clear()
            Dim lista As List(Of DatosMoneda) = funcMO.Mostrar()
            For Each dts As DatosMoneda In lista
                cbMoneda.Items.Add(New IDComboBox(dts.gDIVISA, dts.gcodMoneda))
            Next
            cbMoneda.Text = funcMO.CampoDivisa("EU")
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



    Private Sub bMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMoneda.Click
        Dim GG As New GestionCambioMoneda
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Dim moneda As String = cbMoneda.Text
        Call introducirMonedas()
        cbMoneda.Text = moneda
        If cbMoneda.SelectedIndex = -1 Then cbMoneda.Text = ""
    End Sub
End Class