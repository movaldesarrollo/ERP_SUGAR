Public Class subAlbaranProv

    Private funcCT As New funcionesContactos
    Private dts As DatosAlbaranProv
    Private ep1 As New ErrorProvider

    Public Property pdts() As DatosAlbaranProv
        Get
            Return dts
        End Get
        Set(ByVal value As DatosAlbaranProv)
            dts = value
        End Set
    End Property


    Private Sub subAlbaranProv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        If dts.gidProveedor > 0 Then Call IntroducirContactos()
        Call CargarAlbaran()
    End Sub


    Private Sub IntroducirContactos()
        cbContacto.Items.Clear()
        Dim lista As List(Of datosContacto) = funcCT.mostrarProv(dts.gidProveedor)
        For Each dts As datosContacto In lista
            cbContacto.Items.Add(dts)
        Next
    End Sub

    Private Sub CargarAlbaran()
        numAlbaran.Text = dts.gnumAlbaran
        Referencia.Text = dts.gReferencia
        cbContacto.Text = dts.gContacto
        Observaciones.Text = dts.gObservaciones
        Estado.Text = dts.gEstado
        dtpFecha.Value = dts.gFecha
        Me.Text = "ALBARÁN PROVEEDOR " & dts.gProveedor

    End Sub



    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CantidadRecibida_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles numAlbaran.Click
        sender.selectall()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Dim validar As Boolean = True
        If numAlbaran.Text = "" Then
            ep1.SetError(numAlbaran, "Se ha de anotar el número de albarán")
            validar = False
        End If
        If cbContacto.Text <> "" And cbContacto.SelectedIndex = -1 Then
            ep1.SetError(cbContacto, "Se ha de seleccionar un contacto existente")
            validar = False
        End If
        If validar Then
            dts.gnumAlbaran = numAlbaran.Text
            dts.gReferencia = Referencia.Text
            dts.gidContacto = If(cbContacto.SelectedIndex = -1, 0, cbContacto.SelectedItem.gidContacto)
            dts.gObservaciones = Observaciones.Text
            dts.gFecha = dtpFecha.Value.Date
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub


End Class