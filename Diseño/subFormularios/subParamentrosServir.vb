Public Class subParamentrosServir

    Private Conceptos As New List(Of Long)
    Private funcCP As New FuncionesConceptosPedidos
    Private funcAR As New FuncionesArticulos
    Private funcPS As New FuncionesParametrosServir
    Private dts As DatosParametrosServir

    Public Property pCliente() As String
        Get
            Return Cliente.Text
        End Get
        Set(ByVal value As String)
            Cliente.Text = value
        End Set
    End Property


    Public Property pnumPedido() As Integer
        Get
            Return numPedido.Text
        End Get
        Set(ByVal value As Integer)
            numPedido.Text = value
        End Set
    End Property

    Public Property pConceptos() As List(Of Long)
        Get
            Return Conceptos
        End Get
        Set(ByVal value As List(Of Long))
            Conceptos = value
        End Set
    End Property



    Private Sub subParamentrosServir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If numPedido.Text <> "" And numPedido.Text <> "0" Then
            dts = funcPS.Mostrar(numPedido.Text)
            If dts Is Nothing Then
                Call PrecargarDatos()
            End If
            Bultos.Text = dts.gBultos
            PesoBruto.Text = dts.gKilosBrutos
            PesoNeto.Text = dts.gKilosNetos
            Medidas.Text = dts.gMedidas
            Volumen.Text = dts.gVolumen
        End If
    End Sub



    Private Sub PrecargarDatos()
        Dim iidArticulo As Integer
        Dim CantidadPreparada As Double
        Dim dtsAR As DatosArticulo
        Dim sumaKilosBrutos As Double
        Dim sumaKilosNetos As Double
        Dim sumaBultos As Double
        Dim sumaVolumen As Double
        For Each iidConcepto As Long In Conceptos
            iidArticulo = funcCP.idArticulo(iidConcepto)
            CantidadPreparada = funcCP.CantidadPreparada(iidConcepto)
            dtsAR = funcAR.Mostrar1(iidArticulo)
            sumaKilosBrutos = sumaKilosBrutos + CantidadPreparada * dtsAR.gKilosBrutos
            sumaKilosNetos = sumaKilosNetos + CantidadPreparada * dtsAR.gKilosNetos
            sumaBultos = sumaBultos + CantidadPreparada * dtsAR.gBultos
            sumaVolumen = sumaVolumen + CantidadPreparada * dtsAR.gVolumen
        Next
        Bultos.Text = sumaBultos
        PesoBruto.Text = sumaKilosBrutos
        PesoNeto.Text = sumaKilosNetos
        Volumen.Text = sumaVolumen
        Medidas.Text = ""
    End Sub



    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        dts = New DatosParametrosServir
        dts.gnumPedido = If(numPedido.Text = "", 0, CInt(numPedido.Text))
        dts.gBultos = If(Bultos.Text = "", 0, CInt(Bultos.Text))
        dts.gKilosBrutos = If(PesoBruto.Text = "", 0, CDbl(PesoBruto.Text))
        dts.gKilosNetos = If(PesoNeto.Text = "", 0, CDbl(PesoNeto.Text))
        dts.gVolumen = If(Volumen.Text = "", 0, CInt(Volumen.Text))
        dts.gMedidas = Medidas.Text
        If dts.gBultos = 0 And dts.gKilosNetos = 0 And dts.gKilosBrutos = 0 And dts.gMedidas = "" And dts.gVolumen = 0 Then
            MsgBox("Debe indicar algún parámetro válido.")
            DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            If MsgBox("Guardar los datos introducidos para servir el pedido " & numPedido.Text & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcPS.borrar(numPedido.Text)
                funcPS.insertar(dts)
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
        Me.Close()


    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bultos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Bultos.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub PesoBruto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PesoBruto.Click, PesoNeto.Click, Volumen.Click, Bultos.Click
        sender.selectall()
    End Sub

    Private Sub PesoBruto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PesoBruto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PesoBruto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub PesoNeto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PesoNeto.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(PesoNeto.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Volumen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Volumen.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If InStr(Volumen.Text, ",") Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


End Class