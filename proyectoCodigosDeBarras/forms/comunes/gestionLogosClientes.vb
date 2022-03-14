Public Class gestionLogosClientes

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Public iIdCliente As Integer
    Public iIdArticulo As Integer
    Public iIdLogoCliente As Integer
    Public iIdLogoIzquierdo As Integer
    Public iIdLogoDerecho As Integer

#End Region

#Region "CARGA Y CIERRE"

    Private Sub gestionLogosClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        funcCB.llenarCbClientes(cbCliente)

        If iIdCliente > 0 Then

            cbCliente.SelectedValue = iIdCliente

        End If

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    Private Sub cbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCliente.SelectedIndexChanged

        If cbCliente.SelectedIndex <> -1 And IsNumeric(cbCliente.SelectedValue) Then

            iIdCliente = cbCliente.SelectedValue

            funcCB.llenarPb(Me)

        End If

    End Sub

    Private Sub pbLogoCliente_Click(sender As Object, e As EventArgs) Handles pbLogoCliente.DoubleClick

        Dim gg As New imagenesRegistradas

        gg.ShowDialog()

        If gg.idImagen > 0 Then

            funcCB.llenarPb(pbLogoCliente, gg.idImagen)

            iIdLogoCliente = gg.idImagen

        End If

    End Sub

    Private Sub pbIzquierdo_Click(sender As Object, e As EventArgs) Handles pbIzquierdo.DoubleClick

        Dim gg As New imagenesRegistradas

        gg.ShowDialog()

        If gg.idImagen > 0 Then

            funcCB.llenarPb(pbIzquierdo, gg.idImagen)

            iIdLogoIzquierdo = gg.idImagen

        End If

    End Sub

    Private Sub pbDerecho_Click(sender As Object, e As EventArgs) Handles pbDerecho.DoubleClick
        Dim gg As New imagenesRegistradas
        gg.ShowDialog()
        If gg.idImagen > 0 Then
            funcCB.llenarPb(pbDerecho, gg.idImagen)
            iIdLogoDerecho = gg.idImagen
        End If
    End Sub

    Private Sub bGuardar_Click(sender As Object, e As EventArgs) Handles bGuardar.Click
        If iIdLogoCliente = 0 Or iIdLogoIzquierdo = 0 Or iIdLogoDerecho = 0 Then
            MsgBox("Por favor seleccione todos los logos de la etiqueta.", MsgBoxStyle.Information)
        Else
            funcCB.guardarLogosClientes(iIdLogoCliente, iIdLogoIzquierdo, iIdLogoDerecho, If(cbCliente.SelectedValue = -1, 0, cbCliente.SelectedValue), iIdArticulo)
        End If
    End Sub
#End Region
End Class