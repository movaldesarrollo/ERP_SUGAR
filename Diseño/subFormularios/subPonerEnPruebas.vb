Public Class subPonerEnPruebas

    Private inumPedido As Integer
    Private ep1 As New ErrorProvider
    Private funcPE As New FuncionesPedidos
    Private funcEQ As New FuncionesEquiposProduccion
    Private dts As DatosPedido
    Private vSoloLectura As Boolean

    Public Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property


    Public Property pnumPedido() As Integer
        Get
            Return inumPedido
        End Get
        Set(ByVal value As Integer)
            inumPedido = value
        End Set
    End Property


    Public Property pEnPruebas() As Boolean
        Get
            If dts Is Nothing Then
                Return False
            Else
                Return dts.gEnPruebas
            End If
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property


    Private Sub subCambioFechaEntrega_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        bPruebas.Visible = Not vSoloLectura
        NotaPruebas.ReadOnly = vSoloLectura
        If inumPedido > 0 Then
            Me.Text = "ESTADO PEDIDO " & inumPedido
            dts = funcPE.Mostrar1(inumPedido)
            If dts.gEnPruebas Then
                bPruebas.Text = "DESMARCAR PRUEBAS"
                lbPrueba.Visible = True
            Else
                bPruebas.Text = "MARCAR PRUEBAS"
                lbPrueba.Visible = False
            End If
            lbCerrar.Visible = dts.gAcabando
            Call PresentarEstadoTaller()
            Call PresentarEstadoElectronica()
            Call PresentarFechaFin()
            If dts.gFechaInicioPruebas = CDate("1-1-1900") Then
            Else
                FechaInicioPruebas.Text = dts.gFechaInicioPruebas
                NotaPruebas.Text = dts.gNotaPruebas
            End If

        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub


    Private Sub PresentarEstadoTaller()
        Dim CuantosEquiposTaller As Integer = funcEQ.CuantosEquiposTaller(inumPedido)
        Dim CuantosAcabadosTaller As Integer = funcEQ.CuantosAcabadosTaller(inumPedido)
        If CuantosEquiposTaller = 0 Then
            EstadoTaller.Text = "NO PROCEDE"
        ElseIf CuantosAcabadosTaller = 0 Then
            If funcEQ.CuantosEnCursoTaller(inumPedido) > 0 Then
                EstadoTaller.Text = "EN CURSO"
            Else
                EstadoTaller.Text = "NO COMENZADO"
            End If
        ElseIf CuantosAcabadosTaller < CuantosEquiposTaller Then
            EstadoTaller.Text = "ACABADOS " & CuantosAcabadosTaller & " DE " & CuantosEquiposTaller
        Else

            EstadoTaller.Text = "TODOS ACABADOS "
        End If

    End Sub


    Private Sub PresentarEstadoElectronica()
        Dim CuantosEquiposElectronica As Integer = funcEQ.CuantosEquiposElectronica(inumPedido)
        Dim CuantosAcabadosElectronica As Integer = funcEQ.CuantosAcabadosElectronica(inumPedido)
        If CuantosEquiposElectronica = 0 Then
            EstadoElectronica.Text = "NO PROCEDE"
        ElseIf CuantosAcabadosElectronica = 0 Then
            If funcEQ.CuantosEnCursoElectronica(inumPedido) > 0 Then
                EstadoElectronica.Text = "EN CURSO"
            Else
                EstadoElectronica.Text = "NO COMENZADO"
            End If
        ElseIf CuantosAcabadosElectronica < CuantosEquiposElectronica Then
            EstadoElectronica.Text = "ACABADOS " & CuantosAcabadosElectronica & " DE " & CuantosEquiposElectronica
        Else
            EstadoElectronica.Text = "TODOS ACABADOS "
        End If
    End Sub

    Private Sub PresentarFechaFin()
        If funcEQ.TodosPedidoAcabados(inumPedido) Then
            Dim FF As Date = funcEQ.FechaAcabado(inumPedido)
            If FF <> CDate("1-1-1900") Then
                FechaFin.Text = FF
            End If
        End If
    End Sub


    Private Sub bPruebas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPruebas.Click
        If dts.gEnPruebas = True Then
            Call QuitarEnPruebas()
            Call SalirOK()
        Else
            If dts.gFechaInicioPruebas = CDate("1-1-1900") Then
                If MsgBox("¿Confirma que hoy empieza el periodo de pruebas?. Esta fecha no se podrá cambiar.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call PonerEnPruebas()
                    dts.gFechaInicioPruebas = funcPE.CambiaFechaInicioPruebas(inumPedido, Now)
                    FechaInicioPruebas.Text = dts.gFechaInicioPruebas
                    Call SalirOK()
                End If
            Else
                Call PonerEnPruebas()
                Call SalirOK()
            End If
        End If
    End Sub

    Private Sub PonerEnPruebas()
        dts.gEnPruebas = funcPE.CambiaEnPruebas(inumPedido)
        If dts.gEnPruebas Then
            bPruebas.Text = "DESMARCAR PRUEBAS"
            lbPrueba.Visible = True
        End If
    End Sub

    Private Sub QuitarEnPruebas()
        dts.gEnPruebas = funcPE.CambiaEnPruebas(inumPedido)
        If dts.gEnPruebas = False Then
            bPruebas.Text = "MARCAR PRUEBAS"
            lbPrueba.Visible = False
        End If
    End Sub

    Private Sub SalirOK()
        If NotaPruebas.Text <> dts.gNotaPruebas Then funcPE.CambiaNotaPruebas(inumPedido, NotaPruebas.Text)
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    
    
    
  
End Class