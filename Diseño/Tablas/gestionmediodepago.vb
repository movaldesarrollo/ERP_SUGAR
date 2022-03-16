
Public Class gestionmediodepago
    Dim iidMedioPago As Integer
    Dim vSoloLectura As Boolean
    Dim sDescripcion As String
    Dim funcMP As New funcionesMediosPago

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub gestionmediodepago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call cargardatoslistview()
        guardar.Enabled = False

    End Sub

    Private Sub borrarcampos()
        descripcion.Text = ""
        borrar.Enabled = False
        guardar.Enabled = False
        rbSinCuenta.Checked = True
        guardar.Text = "GUARDAR"
    End Sub



    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Try
            Dim dts = New datosMedioPago
            dts.gMedioPago = UCase(descripcion.Text)
            dts.gidMedioPago = iidMedioPago
            dts.gSinCuenta = rbSinCuenta.Checked
            dts.gGiro = rbGiro.Checked
            dts.gTransferencia = rbTransferencia.Checked
            If guardar.Text = "ACTUALIZAR" Then

                If descripcion.Text <> sDescripcion Then
                    Dim dt As DataTable = funcMP.EstaEnUso(sDescripcion)
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
                        If MsgBox("Se han encontrado: " & vbCrLf & texto & vbCrLf & "No se puede modificar el medio de pago. ¿Crear un medio nuevo?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then


                            funcMP.insertar(dts)
                            guardar.Text = "ACTUALIZAR"

                        Else

                        End If
                    Else
                        funcMP.actualizar(dts)
                    End If

                    'Call cargardatoslistview()
                    nuevo.Enabled = True

                Else
                    funcMP.actualizar(dts)
                    'Call cargardatoslistview()
                    nuevo.Enabled = True
                End If

            Else


                funcMP.insertar(dts)
                'Call cargardatoslistview()
                nuevo.Enabled = True

                guardar.Text = "ACTUALIZAR"

            End If
            Call borrarcampos()
            Call cargardatoslistview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub





    Private Sub cargardatoslistview()

        Try

            Dim lista As List(Of datosMedioPago) = funcMP.mostrar()

            lvMediosPago.Items.Clear()

            For Each dts As datosMedioPago In lista
                With lvMediosPago.Items.Add(dts.gidMedioPago)
                    .SubItems.Add(UCase(dts.gMedioPago))
                    If dts.gSinCuenta Then
                        .subitems.Add("SIN CUENTA")
                    ElseIf dts.gTransferencia Then
                        .subitems.Add("TRANSFERENCIA")
                    ElseIf dts.gGiro Then
                        .subitems.Add("GIRO")
                    End If

                End With
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles borrar.Click
        Dim dts As datosMedioPago

        Dim mensaje As String

        mensaje = MsgBox("¿Desea borrar el medio de pago?", vbYesNo)
        If mensaje = vbYes Then
            Try
                Dim dt As DataTable = funcMP.EstaEnUso(sDescripcion)
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
                    MsgBox("Se han encontrado: " & vbCrLf & texto & vbCrLf & "No se puede borrar el medio de pago.")
                Else
                    dts = New datosMedioPago
                    funcMP.borrar(iidMedioPago)
                    cargardatoslistview()
                    Call borrarcampos()
                    guardar.Text = "GUARDAR"
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMediosPago.Click, lvMediosPago.SelectedIndexChanged
        If lvMediosPago.SelectedItems.Count > 0 Then
            iidMedioPago = lvMediosPago.SelectedItems.Item(0).Text
            Call borrarcampos()
            Try
                Dim dts As datosMedioPago = funcMP.mostrar1(iidMedioPago)
                descripcion.Text = dts.gMedioPago
                rbSinCuenta.Checked = dts.gSinCuenta
                rbGiro.Checked = dts.gGiro
                rbTransferencia.Checked = dts.gTransferencia
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            borrar.Enabled = Not vSoloLectura
            nuevo.Enabled = True
            guardar.Enabled = Not vSoloLectura
            guardar.Text = "ACTUALIZAR"
        End If
    End Sub

   

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        Call borrarcampos()
        guardar.Text = "GUARDAR"
        borrar.Enabled = False
    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        Me.Width = 579
        Me.Height = If(Me.Height < 510, 510, Me.Height)

    End Sub


    'Private Sub descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles descripcion.TextChanged
    '    guardar.Enabled = Not vSoloLectura
    '    rbGiro.Enabled = False
    '    rbTransferencia.Enabled = False
    '    rbGiro.Checked = False
    '    rbTransferencia.Checked = False
    'End Sub

End Class