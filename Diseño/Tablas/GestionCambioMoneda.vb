Public Class GestionCambioMoneda




    Dim semaforo As Boolean = False ' semáforo para detectar los cambios no iniciales
    Dim vSoloLectura As Boolean

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Private Sub GestionTiposMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializar
        Call inicializar()


    End Sub

    Private Sub inicializar()
        semaforo = False
        Call IntroducirCambios()
        bGuardar.Text = "GUARDAR"
        bGuardar.Enabled = False
        bNuevo.Enabled = False
        bBorrar.Enabled = False
        Divisa.Text = ""
        Moneda.Text = ""
        Cambio.Text = 0
        dtpFechaCambio.Value = Now.Date
        Simbolo.Text = ""
        semaforo = True
    End Sub





    Private Sub IntroducirCambios()
        lvCambiosMoneda.Items.Clear()
        Dim func As New FuncionesMoneda
        Dim dt As DataTable = func.Mostrar("")
        Dim linea As DataRow
        For Each linea In dt.Rows
            If linea("codMoneda") Is DBNull.Value Then
            Else
                With lvCambiosMoneda.Items.Add(linea("codMoneda"))
                    If linea("DIVISA") Is DBNull.Value Then
                        .subitems.add("")
                    Else
                        .subitems.add(linea("DIVISA"))
                    End If
                    If linea("CAMBIO") Is DBNull.Value Then
                        .subitems.add("")
                    Else
                        .subitems.add(linea("CAMBIO"))
                    End If
                    If linea("FechaCambio") Is DBNull.Value Then
                        .subitems.add(CDate("1-1-1900"))
                    Else
                        .subitems.add(linea("FechaCambio"))
                    End If
                    If linea("Simbolo") Is DBNull.Value Then
                        .subitems.add("")
                    Else
                        .subitems.add(linea("Simbolo"))
                    End If
                End With
            End If
        Next

    End Sub





    Private Sub lvTiposMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCambiosMoneda.Click
        ' Si hacemos click sobre un tipo de caducidad se copia en la zona de edición 

        With lvCambiosMoneda.SelectedItems.Item(0)

            Moneda.Text = .SubItems(0).Text
            Divisa.Text = .SubItems(1).Text
            Cambio.Text = .SubItems(2).Text
            'dtpFechaCambio.Value = CDate(.SubItems(3).Text)
            dtpFechaCambio.Value = Now.Date
            Simbolo.Text = .SubItems(4).Text

        End With
        bGuardar.Enabled = False
        bNuevo.Enabled = True
        bBorrar.Enabled = Not vSoloLectura
        bGuardar.Text = "ACTUALIZAR"

    End Sub



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        If bGuardar.Enabled Then
            If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub


    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If Moneda.Text <> "" Then
            Dim func As New FuncionesMoneda
            If MsgBox("¿Borrar el cambio de " & Divisa.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                If func.EnUso(Moneda.Text) Then
                    MsgBox("La divisa " & Divisa.Text & ", está en uso. No se puede borrar.")
                Else
                    func.borrar(Moneda.Text)
                    Call inicializar()
                End If
            End If
        End If



    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If Moneda.Text <> "" And Cambio.Text <> "" Then
            If Cambio.Text <> 0 Then
                Dim dts As New DatosMoneda
                dts.gcodMoneda = UCase(Moneda.Text)
                dts.gDIVISA = Divisa.Text
                dts.gFechaCambio = dtpFechaCambio.Value.Date
                dts.gCAMBIO = Cambio.Text
                dts.gSimbolo = Simbolo.Text
                Dim func As New FuncionesMoneda
                If bGuardar.Text = "GUARDAR" Then
                    If func.Existe(Moneda.Text) Then
                        MsgBox("Ya existe la moneda '" & Moneda.Text & "'. ")
                    Else
                        func.insertar(dts)
                        bGuardar.Text = "ACTUALIZAR"
                    End If
                Else
                    func.actualizar(dts)
                End If
                Call inicializar()
            End If
        End If


    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call inicializar()
    End Sub


    Private Sub Cambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Moneda.TextChanged, Divisa.TextChanged, Cambio.TextChanged, dtpFechaCambio.ValueChanged, Simbolo.TextChanged
        bGuardar.Enabled = semaforo And Not vSoloLectura And Moneda.Text <> "" And Cambio.Text <> "" And Cambio.Text <> "0"
        lbMoneda.Text = "      "
        lbMoneda.Text = Simbolo.Text

    End Sub

    Private Sub Cambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cambio.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Cambio.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If semaforo Then
            Me.Width = 746
            Me.Height = If(Me.Height < 510, 510, Me.Height)
            lvCambiosMoneda.Height = Me.Height - 210
            GroupBox1.Height = Me.Height - 85

        End If
    End Sub

End Class