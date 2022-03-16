Public Class GestionTiposCompra



    Dim iidTipoCompra As Integer
    Dim semaforo As Boolean = False ' semáforo para detectar los cambios no iniciales
    Dim vSoloLectura As Boolean
    Dim funcTC As New FuncionesTipoCompra
    Dim funcM As New FuncionesMails
    Dim iIndice As Integer
    Dim G_AGeneral As Char = "G"


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
        Call IntroducirTipos()

    End Sub




    Private Sub IntroducirTipos()
        lvTiposCompra.Items.Clear()
        Dim lista As List(Of DatosTipoCompra) = funcTC.Mostrar
        Dim dts As DatosTipoCompra
        For Each dts In lista
            Call NuevaLinea(dts)
        Next
    End Sub



    Private Sub inicializar()
        semaforo = False
        bGuardar.Text = "GUARDAR"
        G_AGeneral = "G"
        bGuardar.Enabled = False
        bNuevo.Enabled = False
        bBorrar.Enabled = False
        TipoCompra.Text = ""
        Observaciones.Text = ""
        ckValidacion.Checked = True
        ckTransporte.Checked = False
        Mail.Text = ""
        lbMails.Items.Clear()
        semaforo = True
    End Sub




    Private Sub NuevaLinea(ByVal dts As DatosTipoCompra)
        With lvTiposCompra.Items.Add(dts.gIdTipoCompra)
            .SubItems.Add(dts.gTipoCompra)
            .SubItems.Add(If(dts.gTransporte, "SI", "NO"))
            .SubItems.Add(If(dts.gValidacion, "SI", "NO"))
            .SubItems.Add(funcM.MostrarTipoCompraStr(dts.gIdTipoCompra))
        End With
    End Sub

    Private Sub ActualizaLinea(ByVal dts As DatosTipoCompra)
        'Actualizar la linea del indice global iIndiceF
        With lvTiposCompra.Items(iIndice)
            .SubItems(0).Text = dts.gIdTipoCompra
            .SubItems(1).Text = dts.gTipoCompra
            .SubItems(2).Text = If(dts.gTransporte, "SI", "NO")
            .SubItems(3).Text = If(dts.gValidacion, "SI", "NO")
            .SubItems(4).Text = funcM.MostrarTipoCompraStr(dts.gIdTipoCompra)

        End With
    End Sub


    Private Sub lvTiposCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTiposCompra.Click
        ' Si hacemos click sobre una subfamilia se copia en la zona de edición 
        If lvTiposCompra.SelectedItems.Count > 0 Then
            semaforo = False
            iIndice = lvTiposCompra.SelectedIndices(0)
            iidTipoCompra = lvTiposCompra.SelectedItems.Item(0).Text
            Dim dts As DatosTipoCompra = funcTC.Mostrar1(iidTipoCompra)
            TipoCompra.Text = dts.gTipoCompra
            ckValidacion.Checked = dts.gValidacion
            ckTransporte.Checked = dts.gTransporte
            Observaciones.Text = dts.gObservaciones
            Call CargarMails()
            bGuardar.Enabled = False
            bNuevo.Enabled = True
            bBorrar.Enabled = Not vSoloLectura
            G_AGeneral = "A"
            semaforo = True
        End If

    End Sub

    Private Sub CargarMails()
        lbMails.Items.Clear()
        Dim lista As List(Of DatosMail) = funcM.MostrarTipoCompra(iidTipoCompra)
        Dim dts As DatosMail
        For Each dts In lista
            lbMails.Items.Add(dts.gmail)
        Next
    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Dim dts As New DatosTipoCompra
        dts.gIdTipoCompra = iidTipoCompra
        dts.gTipoCompra = UCase(TipoCompra.Text)
        dts.gValidacion = ckValidacion.Checked
        dts.gTransporte = ckTransporte.Checked
        dts.gObservaciones = Observaciones.Text
        If G_AGeneral = "G" Then
            iidTipoCompra = funcTC.insertar(dts)
            dts.gIdTipoCompra = iidTipoCompra
        Else
            funcTC.actualizar(dts)
        End If
        'Ahora se introduce la lista de mails (borrando y volviendo a introducir)
        funcM.borrarTipoCompra(iidTipoCompra)
        Dim x As Integer = 1
        For Each Correo As String In lbMails.Items
            funcM.insertar(New DatosMail(0, 0, 0, 0, iidTipoCompra, Correo, x))
            x = x + 1
        Next
        If G_AGeneral = "G" Then
            Call NuevaLinea(dts)
        Else
            Call ActualizaLinea(dts)
        End If
        Call inicializar()

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        iidTipoCompra = -1
        Call inicializar()
    End Sub

   
    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click


        If MsgBox("¿Borrar el tipo " & TipoCompra.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            If funcTC.borrar(iidTipoCompra) Then
                funcM.borrarTipoCompra(iidTipoCompra)
                lvTiposCompra.Items.RemoveAt(iIndice)
                Call inicializar()
            End If

        End If

    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        'If bGuardar.Enabled Then
        'If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        'Me.Close()
        'End If
        'Else
        Me.Close()
        'End If
    End Sub


    Private Sub Cambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoCompra.TextChanged, ckValidacion.CheckedChanged, Observaciones.TextChanged, Mail.TextChanged, ckTransporte.CheckedChanged
        bGuardar.Enabled = semaforo And Not vSoloLectura And TipoCompra.Text <> ""
        If ckValidacion.Checked = True Then
            Grvalidacion.Enabled = True

        Else
            Grvalidacion.Enabled = False
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If semaforo Then
            Me.Width = 801
            Me.Height = If(Me.Height < 510, 510, Me.Height)
          

        End If
    End Sub

    Private Sub bNuevoMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoMail.Click
        If Mail.Text <> "" Then
            If funcM.Valida(Mail.Text) Then
                If lbMails.FindStringExact(Mail.Text) = -1 Then
                    lbMails.Items.Add(Mail.Text)
                End If
                Mail.Text = ""
            Else
                MsgBox("Dirección de mail no válida.")
            End If
        End If
    End Sub



    Private Sub bBorrarMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrarMail.Click
        If Mail.Text <> "" Then
            lbMails.Items.Remove(Mail.Text)
            Mail.Text = ""
        End If
    End Sub



    Private Sub lbMails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMails.Click
        If lbMails.SelectedIndex > -1 Then
            Mail.Text = lbMails.SelectedItem
        End If
    End Sub


End Class