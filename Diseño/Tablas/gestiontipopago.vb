

Public Class gestiontipopago
    Private iidTipoPago As Integer
    Private vSoloLectura As Boolean
    Private sDescripcion As String
    Private funcTP As New funcionesTiposPago
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private colorInactivo As Color
    Private G_AGeneral As Char
    Private indice As Integer

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub gestionmediodepago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        guardar.Enabled = Not vSoloLectura
        borrar.Enabled = Not vSoloLectura
        nuevo.Enabled = True
        guardar.Text = "GUARDAR"
        colorInactivo = Color.Gray
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        Call borrarcampos()
        Call cargardatoslistview()
    End Sub

    Private Sub borrarcampos()
        descripcion.Text = ""
        ckDias.Checked = False
        ckProntoPago.Checked = False
        Dias.Text = ""
        iidTipoPago = 0
        numPagos.Text = 1
        Carencia.Text = ""
        ckActivo.Checked = True
        'borrar.Enabled = False
        'guardar.Enabled = False
        G_AGeneral = "G"
        indice = -1
        ep1.Clear()
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Try
            Dim validar As Boolean = True
            If descripcion.Text.Length = 0 Then
                ep1.SetError(descripcion, "Se ha de indicar la denomimación del tipo de pago")
                validar = False
            Else
                For Each item As ListViewItem In lvTiposPago.Items
                    Dim encontrado As Boolean = False
                    If Trim(descripcion.Text) = Trim(item.SubItems(1).Text) And item.Index <> indice Then
                        encontrado = True
                    End If
                    If encontrado Then
                        validar = False
                        ep1.SetError(descripcion, "Ya existe un tipo de pago con esta descripcion")
                    End If
                Next
            End If
            If numPagos.Text = "" Or numPagos.Text = "0" Then
                ep1.SetError(numPagos, "Ha de haber al menos 1 pago")
                validar = False
            End If
            If ckDias.Checked And (Dias.Text = "" Or Dias.Text = "0") Then
                ep1.SetError(Dias, "Ha de indicar un número de días")
                validar = False
            End If


            If validar Then
                Dim dts As New datosTipoPago
                dts.gidTipoPago = iidTipoPago
                dts.gTipoPago = UCase(descripcion.Text)
                dts.gdiapactado = ckDias.Checked
                dts.gProntoPago = ckProntoPago.Checked
                dts.gContadorDias = If(Dias.Text = "", 0, CInt(Dias.Text))
                dts.gnumPagos = If(numPagos.Text = "", 1, CInt(numPagos.Text))
                dts.gCarencia = If(Carencia.Text = "", 0, CInt(Carencia.Text))
                dts.gActivo = ckActivo.Checked
                'If ckDias.CheckState = CheckState.Unchecked Then dts.gContadorDias = 0
                If G_AGeneral = "G" Then
                    funcTP.insertar(dts)

                    'nuevo.Enabled = True
                    G_AGeneral = "A"
                Else

                    funcTP.actualizar(dts)
                    'Call cargardatoslistview()
                    'nuevo.Enabled = True

                End If
                Call borrarcampos()
                Call cargardatoslistview()
                ep1.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cargardatoslistview()

        Try

            Dim lista As List(Of datosTipoPago) = funcTP.mostrar(False)

            Dim dts As datosTipoPago
            lvTiposPago.Items.Clear()

            For Each dts In lista
                With lvTiposPago.Items.Add(dts.gidTipoPago)
                    .SubItems.Add(UCase(dts.gTipoPago))
                    .subitems.add(dts.gnumPagos)
                    .subitems.add(If(dts.gnumPagos > 1, CStr(dts.gCarencia), ""))
                    .SubItems.Add(If(dts.gdiapactado, CStr(dts.gContadorDias), ""))
                    .subitems.add(If(dts.gProntoPago, "SI", "NO"))
                    If dts.gActivo Then
                        .forecolor = Color.Black
                    Else
                        .forecolor = colorInactivo
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        If iidTipoPago > 0 Then

            If MsgBox("¿Desea borrar el registro?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Try
                    Dim dt As DataTable = funcTP.EstaEnUso(iidTipoPago)
                    Dim linea As DataRow
                    Dim texto As String = ""
                    Dim Contador As Integer = 0
                    For Each linea In dt.Rows
                        Contador = linea("Contador")
                        If Contador > 0 Then
                            texto = Contador & " " & linea("Tipo") & vbCrLf & texto
                        End If
                    Next
                    If texto <> "" Then
                        MsgBox("Se han encontrado: " & vbCrLf & texto & vbCrLf & "No se puede borrar el tipo de pago.")
                    Else
                        funcTP.borrar(iidTipoPago)
                        cargardatoslistview()
                        Call borrarcampos()
                        G_AGeneral = "G"
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTiposPago.Click, lvTiposPago.SelectedIndexChanged

        If lvTiposPago.SelectedItems.Count > 0 Then
            ep1.Clear()
            indice = lvTiposPago.SelectedIndices(0)
            iidTipoPago = lvTiposPago.Items(indice).Text
            Dim dts As datosTipoPago = funcTP.mostrar1(iidTipoPago)
            descripcion.Text = UCase(dts.gTipoPago)
            sDescripcion = descripcion.Text
            ckDias.Checked = dts.gdiapactado
            ckProntoPago.Checked = dts.gProntoPago
            Dias.Text = If(dts.gdiapactado, CStr(dts.gContadorDias), "")
            Carencia.Text = If(dts.gnumPagos > 1, CStr(dts.gCarencia), "")
            numPagos.Text = dts.gnumPagos
            ckActivo.Checked = dts.gActivo
            'guardar.Enabled = Not vSoloLectura

            'borrar.Enabled = Not vSoloLectura
            'nuevo.Enabled = True
            G_AGeneral = "A"
        End If
    End Sub

  

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        Call borrarcampos()
        G_AGeneral = "G"
        'borrar.Enabled = False
    End Sub

    Private Sub numPagos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles numPagos.Click, Dias.Click, Carencia.Click
        sender.selectall()
    End Sub

    Private Sub dias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dias.KeyPress, numPagos.KeyPress, Carencia.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 759
        Me.Height = If(Me.Height < 510, 510, Me.Height)
      

    End Sub


    
    Private Sub descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles descripcion.TextChanged, Dias.TextChanged, ckProntoPago.CheckedChanged, Carencia.TextChanged, ckActivo.CheckedChanged

        'guardar.Enabled = Not vSoloLectura
    End Sub
   
    Private Sub numPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPagos.TextChanged
        If numPagos.Text = 1 Then
            Carencia.Text = ""
            Carencia.ReadOnly = True
        Else
            Carencia.ReadOnly = False
            ckDias.Checked = True
        End If
        'guardar.Enabled = Not vSoloLectura
    End Sub




    Private Sub ckDias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDias.CheckedChanged
        If ckDias.Checked Then
            Dias.ReadOnly = False
        Else
            Dias.Text = ""
            Dias.ReadOnly = True
        End If
    End Sub


End Class