Public Class GestionCuentasPropias

    Private funcCB As New FuncionesCuentasBancarias
    Private funcBA As New FuncionesBancos
    Private vSoloLectura As Boolean
    Private indice As Integer
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private colorInactivo As New Color
    Private espUbic As Boolean

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionCuentasPropias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        colorInactivo = Color.Gray
        Call introducirBancos()
        Call LimpiarBanco()
        Call ActualizarLV()
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub introducirBancos()
        Try
            cbBanco.Items.Clear()
            Dim lista As List(Of DatosBanco) = funcBA.Mostrar(True)
            Dim dts As DatosBanco
            For Each dts In lista
                cbBanco.Items.Add(New IDComboBox(dts.gBanco, dts.gidBanco))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarBanco()
        ep1.Clear()
        codigoEU.Text = "ES"
        cbBanco.Text = ""
        cbBanco.SelectedIndex = -1
        codigobanco.Text = ""
        codigooficina.Text = ""
        codigodc.Text = ""
        codigocuenta.Text = ""
        IBAN.Text = ""
        SWIFT_BIC.Text = ""
        Nombre.Text = ""
        indice = -1
        ckActivoB.Checked = True
        ep1.Clear()
        ep2.Clear()
        espUbic = True
    End Sub

#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub ActualizarLV()
        Dim lista As List(Of DatosCuentaBancaria) = funcCB.Mostrar(0, False) 'Recargamos los bancos para que aparezcan los inactivos
        lvBancos.Items.Clear()
        For Each dtsB As DatosCuentaBancaria In lista
            Call nuevaLineaBanco(dtsB)
        Next
    End Sub

    Private Sub nuevaLineaBanco(ByVal dtsB As DatosCuentaBancaria)

        With lvBancos.Items.Add(dtsB.gidCuentaBanco)
            .SubItems.Add(dtsB.gBanco)
            .SubItems.Add(dtsB.gIBAN)
            .SubItems.Add(dtsB.gNombre)
            If dtsB.gActivo Then
                .ForeColor = Color.Black
            Else
                .ForeColor = colorInactivo
            End If
        End With
    End Sub

    Private Sub ActualizarLineaBanco(ByVal dtsB As DatosCuentaBancaria)
        If indice > -1 Then
            With lvBancos.Items(indice)
                .SubItems(0).Text = dtsB.gidCuentaBanco
                .SubItems(1).Text = dtsB.gBanco
                .SubItems(2).Text = dtsB.gIBAN
                .SubItems(3).Text = dtsB.gNombre
                If dtsB.gActivo Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = colorInactivo
                End If
            End With
        End If

    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Dim validar As Boolean = True

        codigoEU.Text = codigoEU.Text.PadRight(4, "0")
        codigobanco.Text = codigobanco.Text.PadLeft(4, "0")
        codigooficina.Text = codigooficina.Text.PadLeft(4, "0")
        codigodc.Text = codigodc.Text.PadLeft(2, "0")
        codigocuenta.Text = codigocuenta.Text.PadLeft(10, "0")
        Dim iidCuentaBanco As Integer = 0
        If indice <> -1 Then
            iidCuentaBanco = lvBancos.Items(indice).Text
        End If
        If IBAN.Text.Length = 0 And Microsoft.VisualBasic.Left(codigoEU.Text, 2) = "ES" And codigoEU.TextLength = 4 Then
            IBAN.Text = codigoEU.Text & codigobanco.Text & codigooficina.Text & codigodc.Text & codigocuenta.Text
        End If
        If cbBanco.SelectedIndex = -1 Then
            ep1.SetError(cbBanco, "Debe seleccionar un banco")
            validar = False
        End If
        If Nombre.Text = "" Then
            ep1.SetError(Nombre, "Debe escribir un nombre que identifique la cuenta")
            validar = False
        ElseIf funcCB.ExisteNombreCuenta(0, Nombre.Text, iidCuentaBanco) Then
            ep1.SetError(Nombre, "El nombre ya está asignado a otra cuenta")
            validar = False
        End If
        If IBAN.Text.Length < 2 Then
            validar = False
            ep1.SetError(IBAN, "Debe introducir el IBAN")
        ElseIf Not IBANValidacion(IBAN.Text) Then
            validar = False
            ep1.SetError(IBAN, "IBAN incorrecto")
        End If

        If validar Then
            Dim dts As New DatosCuentaBancaria
            dts.gidCuentaBanco = iidCuentaBanco
            dts.gidFacturacion = 0
            dts.gidBanco = cbBanco.SelectedItem.itemdata
            dts.gCodigoEU = codigoEU.Text
            dts.gCodigoBanco = codigobanco.Text
            dts.gCodigoOficina = codigooficina.Text
            dts.gCodigoDC = codigodc.Text
            dts.gCodigoCuenta = codigocuenta.Text
            dts.gIBAN = IBAN.Text
            dts.gSWIFT_BIC = SWIFT_BIC.Text
            dts.gOrden = If(indice = -1, lvBancos.Items.Count + 1, indice + 1)
            dts.gActivo = ckActivoB.Checked
            dts.gBanco = cbBanco.Text
            dts.gNombre = Nombre.Text
            If iidCuentaBanco = 0 Then
                dts.gidCuentaBanco = funcCB.insertar(dts)
                Call nuevaLineaBanco(dts)
            Else
                funcCB.actualizar(dts)
                Call ActualizarLineaBanco(dts)
            End If
            Call LimpiarBanco()

        ElseIf codigooficina.Text <> "" Or codigocuenta.Text <> "" Then
            IBAN.Text = ""
        End If
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If lvBancos.SelectedItems.Count > 0 Then
            If MsgBox("¿Desea borrar la cuenta seleccionada?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                indice = lvBancos.SelectedIndices(0)
                Dim iidCuentaBanco As Integer = lvBancos.Items(indice).Text
                If funcCB.borrar(iidCuentaBanco, 1279) Then
                    lvBancos.Items.RemoveAt(indice)
                End If
            End If
        End If
    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call LimpiarBanco()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBancos.Click
        Dim Banco As String = cbBanco.Text
        Dim GG As New GestionBancos
        GG.SoloLectura = vSoloLectura
        GG.ShowDialog()
        Call introducirBancos()
        cbBanco.Text = Banco
        If cbBanco.SelectedIndex = -1 Then cbBanco.Text = ""
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub lvBancos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBancos.Click
        If lvBancos.SelectedItems.Count > 0 Then
            indice = lvBancos.SelectedIndices(0)
            Dim iidCuentaBanco As Integer = lvBancos.Items(indice).Text
            Dim dts As DatosCuentaBancaria = funcCB.Mostrar1(iidCuentaBanco)
            cbBanco.Text = dts.gBanco
            Nombre.Text = dts.gNombre
            ckActivoB.Checked = dts.gActivo
            SWIFT_BIC.Text = dts.gSWIFT_BIC
            IBAN.Text = dts.gIBAN
            codigoEU.Text = dts.gCodigoEU
            codigodc.Text = dts.gCodigoDC
            codigobanco.Text = dts.gCodigoBanco
            codigocuenta.Text = dts.gCodigoCuenta
            codigooficina.Text = dts.gCodigoOficina
            If cbBanco.SelectedIndex <> -1 Then
                espUbic = funcBA.Espanyol(cbBanco.SelectedItem.itemdata)
            End If
        End If

    End Sub

    Private Sub codigodc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codigobanco.KeyPress, codigooficina.KeyPress, codigodc.KeyPress, codigocuenta.KeyPress
        If espUbic Then
            Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
            KeyAscii = CShort(SoloNumeros(KeyAscii))
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbBanco_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBanco.SelectionChangeCommitted
        If cbBanco.SelectedIndex <> -1 Then
            espUbic = funcBA.Espanyol(cbBanco.SelectedItem.itemdata)
            Dim dts As DatosBanco = funcBA.Mostrar1(cbBanco.SelectedItem.itemdata)
            SWIFT_BIC.Text = dts.gSWIFT_BIC
            codigobanco.Text = dts.gcodigoBanco
            If dts.gidPais = 1 Then
                codigoEU.Enabled = True
                codigobanco.Enabled = True
                codigooficina.Enabled = True
                codigodc.Enabled = True
                codigocuenta.Enabled = True
            Else
                codigoEU.Enabled = False
                codigobanco.Enabled = False
                codigooficina.Enabled = False
                codigodc.Enabled = False
                codigocuenta.Enabled = False
            End If
        End If
    End Sub

#End Region

End Class