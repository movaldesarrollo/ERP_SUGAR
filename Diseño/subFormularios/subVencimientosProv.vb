Public Class subVencimientosProv

    Private Vencimientos As List(Of DatosVencimientoProv)
    Private NuevosVencimientos As List(Of DatosVencimientoProv)
    Private vSoloLectura As Boolean
    Private simbolo As String
    Private indice As Integer
    Private Total As Double
    Private iidVencimiento As Long
    Private iidFactura As Integer
    Private cancelado As Boolean
    Private funcVE As New FuncionesVencimientosProv
    Private ep1 As New ErrorProvider

    Public Property pVencimientos() As List(Of DatosVencimientoProv)
        Get
            Return Vencimientos
        End Get
        Set(ByVal value As List(Of DatosVencimientoProv))
            Vencimientos = value
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property pSimbolo() As String
        Get
            Return simbolo
        End Get
        Set(ByVal value As String)
            simbolo = value
        End Set
    End Property


    Public Property pTotal() As Double
        Get
            Return Total
        End Get
        Set(ByVal value As Double)
            Total = value
        End Set
    End Property

    Public Property pidFactura() As Integer
        Get
            Return iidFactura
        End Get
        Set(ByVal value As Integer)
            iidFactura = value
        End Set
    End Property

    Public Property pCancelado() As Integer
        Get
            Return cancelado
        End Get
        Set(ByVal value As Integer)
            cancelado = value
        End Set
    End Property

    Private Sub subVencimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        lbMoneda1.Text = simbolo
        lbMoneda2.Text = simbolo
        lbMoneda3.Text = simbolo
        Call Limpiar()
        TotalFactura.Text = FormatNumber(Total, 3)
        NuevosVencimientos = New List(Of DatosVencimientoProv)
        For Each dts As DatosVencimientoProv In Vencimientos
            NuevosVencimientos.Add(dts)
        Next
        Call CargarlvVencimientos()

    End Sub

    Private Sub Limpiar()
        dtpVencimiento.Value = Now.Date
        Importe.Text = 0
        ckCobrado.Checked = False
        ckDevuelto.Checked = False
        indice = -1
        iidVencimiento = 0
        Importe.Text = Restante.Text
    End Sub


    Private Sub CargarlvVencimientos()
        lvVencimientos.Items.Clear()
        NuevosVencimientos.Sort(Function(x, y) x.gVencimiento.CompareTo(y.gVencimiento))
        For Each dts As DatosVencimientoProv In NuevosVencimientos
            nuevaLinealv(dts)
        Next
        Call recalcular()
    End Sub



    Private Sub bMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub GuardarVencimiento()
        If Importe.Text = "" Then Importe.Text = 0

        Dim Resto As Double = RestanteActual(indice)
        Dim validar As Boolean = True
        If Resto > 0 And (Resto - CDbl(Importe.Text)) < -0.01 Then
            validar = False
            ep1.SetError(lbMoneda2, "El importe ha de ser menor o igual que la cantidad restante " & FormatNumber(Resto, 3))
        End If
        If Resto < 0 And (CDbl(Importe.Text) - Resto) < -0.01 Then
            validar = False
            ep1.SetError(lbMoneda2, "El importe ha de ser mayor o igual que la cantidad restante " & FormatNumber(Resto, 3))
        End If
        If indice = -1 And Importe.Text = 0 Then
            validar = False
            ep1.SetError(lbMoneda2, "Debe seleccionar un vencimiento o introducir un importe para uno nuevo")
        End If
        'If (CDbl(Importe.Text) <> 0 Or indice <> -1) And ((Resto >= 0 And CDbl(Importe.Text) <= Resto) Or (Resto < 0 And CDbl(Importe.Text) >= Resto)) Then
        If validar Then
            Dim dts As New DatosVencimientoProv
            dts.gidVencimiento = iidVencimiento
            dts.gidFactura = iidFactura
            dts.gVencimiento = dtpVencimiento.Value
            dts.gImporte = Importe.Text
            dts.gPagado = ckCobrado.Checked
            dts.gDevuelto = ckDevuelto.Checked
            cancelado = True
            If indice = -1 Then
                'Nuevo
                For Each item As ListViewItem In lvVencimientos.Items
                    If CDate(item.SubItems(1).Text) = dtpVencimiento.Value.Date Then
                        indice = item.Index 'Busca si está la fecha
                    End If
                Next
            End If
            If indice = -1 Then
                NuevosVencimientos.Add(dts)
                nuevaLinealv(dts)
            Else

                'Actualizar
                NuevosVencimientos(indice) = funcVE.Clonar(dts)
                ActualizarLinealv(dts)

            End If
            Call recalcular()
            Call Limpiar()
        End If
    End Sub



    Private Function RestanteActual(ByVal indiceExcepto As Integer) As Double
        Dim Resultado As Double = 0
        For i As Integer = 0 To NuevosVencimientos.Count - 1
            If i <> indiceExcepto Then
                Resultado = Resultado + NuevosVencimientos(i).gImporte
            End If
        Next

        Return CDbl(TotalFactura.Text) - Resultado
    End Function

    Private Sub recalcular()
        Dim suma As Double = 0
        For Each item In lvVencimientos.Items
            suma = suma + item.subitems(3).text
        Next
        Restante.Text = FormatNumber(TotalFactura.Text - suma, 3)

    End Sub

    Private Sub nuevaLinealv(ByVal dts As DatosVencimientoProv)
        With lvVencimientos.Items.Add(dts.gidVencimiento)
            .SubItems.Add(dts.gVencimiento)
            .SubItems.Add(FormatNumber(dts.gImporte, 3) & simbolo)
            .SubItems.Add(dts.gImporte)
            If dts.gDevuelto Then
                .ForeColor = Color.Red
                .SubItems.Add("DEVUELTO")
            ElseIf dts.gPagado Then
                .ForeColor = Color.Green
                .SubItems.Add("COBRADO")
            Else
                .ForeColor = Color.Black
                .SubItems.Add("PENDIENTE")
            End If
        End With
    End Sub

    Private Sub ActualizarLinealv(ByVal dts As DatosVencimientoProv)
        If indice <> -1 Then
            With lvVencimientos.Items(indice)
                .SubItems(1).Text = dts.gVencimiento
                .SubItems(2).Text = FormatNumber(dts.gImporte, 3) & simbolo
                .SubItems(3).Text = dts.gImporte

                If dts.gDevuelto Then
                    .ForeColor = Color.Red
                    .SubItems(4).Text = "DEVUELTO"
                ElseIf dts.gPagado Then
                    .ForeColor = Color.Green
                    .SubItems(4).Text = "PAGADO"
                Else
                    .ForeColor = Color.Black
                    .SubItems(4).Text = "PENDIENTE"
                End If
            End With
        End If

    End Sub

    'Private Sub bMenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMenos.Click
    '    If indice <> -1 Then
    '        Vencimientos.RemoveAt(indice)
    '        lvVencimientos.Items.RemoveAt(indice)
    '        Call Limpiar()
    '        Call recalcular()

    '    End If
    'End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If indice <> -1 Then
            NuevosVencimientos.RemoveAt(indice)
            lvVencimientos.Items.RemoveAt(indice)

            Call recalcular()
            Call Limpiar()
        End If
    End Sub





    Private Sub lvVencimientos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVencimientos.Click, lvVencimientos.SelectedIndexChanged
        If lvVencimientos.SelectedItems.Count > 0 Then
            indice = lvVencimientos.SelectedIndices(0)
            iidVencimiento = lvVencimientos.Items(indice).Text
            With lvVencimientos.Items(indice)
                dtpVencimiento.Value = .SubItems(1).Text
                Importe.Text = FormatNumber(.SubItems(3).Text, 3)
                ckCobrado.Checked = (.ForeColor = Color.Green)
                ckDevuelto.Checked = (.ForeColor = Color.Red)
            End With
        End If
    End Sub

    Private Sub Importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Importe.Click
        sender.selectall()
    End Sub






    Private Sub Importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Importe.KeyPress
        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(Importe.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Importe.Text = "" Or Importe.Text = "0" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(Importe.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
        If KeyAscii = Keys.Enter Then
            Call GuardarVencimiento()
        End If

    End Sub


    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        If ListasIguales(Vencimientos, NuevosVencimientos) Then
            cancelado = True
            Me.Close()
        Else
            Select Case MsgBox("¿Guardar los cambios realizados?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Call recalcular()
                    If Restante.Text = "" Then Restante.Text = 0
                    Dim dRestante As Double = Restante.Text
                    If Math.Abs(dRestante) > 0.01 Then
                        MsgBox("El total no coincide con la suma de vencimientos")
                    Else
                        NuevosVencimientos.Sort(Function(x, y) x.gVencimiento.CompareTo(y.gVencimiento))

                        Vencimientos.Clear()
                        For Each dts As DatosVencimientoProv In NuevosVencimientos
                            Vencimientos.Add(dts)
                        Next
                        cancelado = False
                        Me.Close()
                    End If
                Case MsgBoxResult.No
                    cancelado = True
                    Me.Close()
                Case MsgBoxResult.Cancel

            End Select
        End If


    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        ep1.Clear()
        Call GuardarVencimiento()
    End Sub

    Private Function ListasIguales(ByVal Lista1 As List(Of DatosVencimientoProv), ByVal Lista2 As List(Of DatosVencimientoProv)) As Boolean
        Dim iguales = True
        If Lista1 Is Nothing And Lista2 Is Nothing Then Return True
        If Lista1 Is Nothing And Not Lista2 Is Nothing Then
            Return False
        End If
        If Lista2 Is Nothing And Not Lista1 Is Nothing Then
            Return False
        End If
        If Lista1.Count <> Lista2.Count Then
            Return False
        End If
        For i = 0 To Lista1.Count - 1
            iguales = iguales And funcVE.Iguales(Lista1(i), Lista2(i))
        Next
        Return iguales
    End Function




    Private Sub ckDevuelto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDevuelto.CheckedChanged
        If ckDevuelto.Checked Then ckCobrado.Checked = False
    End Sub


    Private Sub ckCobrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCobrado.CheckedChanged
        If ckCobrado.Checked Then ckDevuelto.Checked = False
    End Sub



    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call Limpiar()
    End Sub


End Class

