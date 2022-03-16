Imports System.IO

Public Class subCambioFechaEntrega

    Private inumPedido As Integer
    Private ep1 As New ErrorProvider
    Private funcPE As New FuncionesPedidos
    Private funcCR As New FuncionesConceptosProduccion
    Private funcAV As New funcionesAvisos
    Private funcP As New FuncionesPersonal
    Private FechaEntrega As Date

    Public Property pnumPedido() As Integer
        Get
            Return inumPedido
        End Get
        Set(ByVal value As Integer)
            inumPedido = value
        End Set
    End Property


    Private Sub subCambioFechaEntrega_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        If inumPedido = 0 Then
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            Me.Text = "PROPUESTA DE CAMBIO FECHA ENTREGA PEDIDO " & inumPedido
            FechaEntrega = funcPE.FechaEntrega(inumPedido)
            dtpFechaPrevista.Value = FechaEntrega
        End If

    End Sub

    Private Sub bEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEnviar.Click
        Dim validar As Boolean = True
        If Explicacion.TextLength = 0 Then
            ep1.SetError(Explicacion, "Se ha de explicar el motivo del cambio de fecha")
            validar = False
        End If
        If funcPE.FechaEntrega(inumPedido) = dtpFechaPrevista.Value.Date Then
            ep1.SetError(dtpFechaPrevista, "La fecha indicada ya es la fecha de entrega del pedido")
            validar = False
        End If
        If validar Then
            Dim dts As New datosAviso
            dts.gAplicacion = "PEDIDO"
            dts.gTipoAviso = "PROPUESTA CAMBIO FECHA ENTREGA"
            dts.gnumDoc = inumPedido
            dts.gFechaPropuesta = dtpFechaPrevista.Value.Date
            dts.gExplicacion = Explicacion.Text
            dts.gEnviado = False
            dts.gidAviso = funcAV.insertar(dts)
            dts = funcAV.mostrar1(dts.gidAviso)
            Dim Texto As String = dts.gCreador & " solicita un cambio en la fecha de entrega del pedido " & dts.gnumDoc & vbCrLf & vbCrLf
            Texto = Texto & "FECHA PROPUESTA: " & dts.gFechaPropuesta & vbCrLf & vbCrLf
            Texto = Texto & "EXPLICACIÓN: " & dts.gExplicacion
            Dim dtsPE As DatosPedido = funcPE.Mostrar1(inumPedido)
            Dim remitente As String = funcP.campoCorreo(dts.gidCreador)
            Dim fichero As String = "Pedido SV " & inumPedido & " " & Microsoft.VisualBasic.Left(dtsPE.gCliente, 40) & ".pdf"
            Dim camino As String = Path.GetTempPath()
            Dim funcUB As New funcionesUbicaciones
            InformePedido.GeneraPDF(inumPedido, funcUB.campoIdioma(dtsPE.gidUbicacion), fichero, camino, False, False)
            If correo(dts.ToString, Texto, remitente, funcP.CorreoAvisos, camino & fichero) Then
                MsgBox("Se ha enviado un aviso con la solicitud de cambio de fecha.")
                funcAV.Enviar(dts.gidAviso)
                DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("No ha sido posible enviar el aviso")
                DialogResult = Windows.Forms.DialogResult.Cancel
            End If
            Me.Close()
        End If
    End Sub

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class