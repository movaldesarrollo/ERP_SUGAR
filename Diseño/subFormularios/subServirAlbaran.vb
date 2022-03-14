Public Class subServirAlbaran

    Private funcAL As New FuncionesAlbaranes
    Private funcES As New FuncionesEstados
    Private funcPR As New funcionesProveedores
    Private vsoloLectura As Boolean
    Private Titulo As String

    Public Property pnumAlbaran() As Integer
        Get
            Return numDoc.Text
        End Get
        Set(ByVal value As Integer)
            numDoc.Text = value
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

  
    Private Sub subServirAlbaran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bGuardar.Enabled = Not vsoloLectura
        If numDoc.Text = "" Then numDoc.Text = 0
        If numDoc.Text > 0 Then
            Call introducirTransporte()
            Dim dts As DatosAlbaran = funcAL.Mostrar1(numDoc.Text)
            Cliente.Text = dts.gCliente
            dtpFechaPrevista.Value = Now.Date
            RefCliente2.Text = dts.gReferenciaCliente2
            If dts.gidTransporte = 0 Then
                cbTransporte.Text = dts.gTransporte
            Else
                cbTransporte.Text = dts.gAgenciaTransporte
            End If
        End If

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If MsgBox("¿Confirmar los datos introducidos y servir el albarán?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim iidTransporte As Integer = 0
            Dim sTransporte As String = ""
            If cbTransporte.SelectedIndex = -1 Then
                iidTransporte = 0
                sTransporte = cbTransporte.Text
            Else
                If cbTransporte.SelectedItem.itemdata < 1 Then
                    iidTransporte = 0
                    sTransporte = cbTransporte.Text
                Else
                    iidTransporte = cbTransporte.SelectedItem.itemData
                    sTransporte = ""
                End If
            End If
            Dim iidEstado As Integer = funcAL.idEstado(numDoc.Text)
            Dim EstadoFacturado As DatosEstado = funcES.EstadoTraspasado("ALBARAN")
            Dim EstadoServido As DatosEstado = funcES.EstadoEntregado("ALBARAN")
            'Al hacer el SERVIR ALBARÁN se pasará al estado SERVIDO si estaba PREPARADO, si estaba FACTURADO no se cambia el estado. En los dos casos se activa el bit RECOGIDO.
            If iidEstado <> EstadoFacturado.gidEstado Then iidEstado = EstadoServido.gidEstado
            funcAL.ServirAlbaran(numDoc.Text, RefCliente2.Text, dtpFechaPrevista.Value.Date, iidEstado, iidTransporte, sTransporte)
            Me.Close()
        End If


    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()
    End Sub

    Private Sub introducirTransporte()
        Try
            cbTransporte.Items.Clear()
            cbTransporte.Items.Add(New IDComboBox("SUS MEDIOS", -1))
            cbTransporte.Items.Add(New IDComboBox("NUESTROS MEDIOS", -2))
            Dim lista As List(Of IDComboBox) = funcPR.Transportes
            For Each t As IDComboBox In lista
                cbTransporte.Items.Add(t)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class