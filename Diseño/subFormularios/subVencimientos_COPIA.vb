Public Class subVencimientos1

#Region "VARIABLES"

    Private Vencimientos As List(Of DatosVencimiento)
    Private NuevosVencimientos As List(Of DatosVencimiento)
    Private vSoloLectura As Boolean
    Private simbolo As String
    Private indice As Integer
    Private Total As Double
    Private iidVencimiento As Long
    Private inumFactura As Integer
    Private cancelado As Boolean
    Private funcVE As New FuncionesVencimientos
    Private ep1 As New ErrorProvider
    Public EstadoGuardado As Boolean
    Public funcFact1 As New GestionFactura1

#End Region

    'PROPIEDADES

#Region "PROPIEDADES"
    Public Property pVencimientos() As List(Of DatosVencimiento)
        Get
            Return Vencimientos
        End Get
        Set(ByVal value As List(Of DatosVencimiento))
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

    Public Property pnumFactura() As Integer
        Get
            Return inumFactura
        End Get
        Set(ByVal value As Integer)
            inumFactura = value
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
#End Region

    'PROCESOS GENERALES 

#Region "PROCESOS GENERALES"

    'CERRAR FORMULARIO
    Private Sub subVencimientos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If EstadoGuardado = True Then 'Si hay cambios que guardar pregunta
            If MsgBox("No se han guardado los cambios, ¿Desea continuar sin guardar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    'CARGAR FORMULARIO
    Private Sub subVencimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EstadoGuardado = False
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        bGuardar.Enabled = Not vSoloLectura
        lbMoneda1.Text = simbolo
        lbMoneda2.Text = simbolo
        lbMoneda3.Text = simbolo
        TotalFactura.Text = FormatNumber(Total, 3)
        reload()
    End Sub

    'RECARGAR FORMULARIO
    Public Sub reload()
        NuevosVencimientos = funcVE.Mostrar(pnumFactura)
        Call CargarlvVencimientos()
        Limpiar()
    End Sub

    'LIMPIAR FORMULARIO
    Private Sub Limpiar()
        dtpVencimiento.Value = Now.Date
        Importe.Text = 0
        ckCobrado.Checked = False
        ckDevuelto.Checked = False
        indice = -1
        iidVencimiento = 0
        EstadoGuardado = False
        bGuardar.Text = "GUARDAR"
        ep1.Clear()
    End Sub

#End Region

    'PROCESOS LVVENCIMIENTOS

#Region "LV VENCIMIENTOS"

    'CARGA LOS VENCIMIENTOS EN EL LISTVIEW.
    Private Sub CargarlvVencimientos()
        lvVencimientos.Items.Clear()
        NuevosVencimientos.Sort(Function(x, y) x.gVencimiento.CompareTo(y.gVencimiento))
        For Each dts As DatosVencimiento In NuevosVencimientos
            nuevaLinealv(dts)
        Next
        Call recalcular()
    End Sub

    'CREA UNA NUEVA LINEA.
    Private Sub nuevaLinealv(ByVal dts As DatosVencimiento)
        With lvVencimientos.Items.Add(dts.gidVencimiento)
            .SubItems.Add(dts.gVencimiento)
            .SubItems.Add(FormatNumber(dts.gImporte, 2) & simbolo)
            .SubItems.Add(dts.gImporte)
            If dts.gDevuelto Then
                .ForeColor = Color.Red
                .SubItems.Add("DEVUELTO")
            ElseIf dts.gCobrado Then
                .ForeColor = Color.Green
                .SubItems.Add("COBRADO")
            Else
                .ForeColor = Color.Black
                .SubItems.Add("PENDIENTE")
            End If
        End With
    End Sub

    'ACTUALIZA LA LINEA.
    Private Sub ActualizarLinealv(ByVal dts As DatosVencimiento)
        If indice <> -1 Then
            With lvVencimientos.Items(indice)
                .SubItems(1).Text = dts.gVencimiento
                .SubItems(2).Text = FormatNumber(dts.gImporte, 2) & simbolo
                .SubItems(3).Text = dts.gImporte
                If dts.gDevuelto Then
                    .ForeColor = Color.Red
                    .SubItems(4).Text = "DEVUELTO"
                ElseIf dts.gCobrado Then
                    .ForeColor = Color.Green
                    .SubItems(4).Text = "COBRADO"
                Else
                    .ForeColor = Color.Black
                    .SubItems(4).Text = "PENDIENTE"
                End If
            End With
        End If
    End Sub

    'CARGA LOS DATOS DE LA LINEA EN LOS CAMPOS. UPDATE:04/05/2017
    Private Sub lvVencimientos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvVencimientos.Click, lvVencimientos.SelectedIndexChanged
        'Al hacer click en el listview, si hay algun item seleccionado
        If lvVencimientos.SelectedItems.Count > 0 Then
            'Cambia el texto del boton guardar.
            bGuardar.Text = "ACTUALIZAR"
            'Guarda el indice del Item seleccionado.
            indice = lvVencimientos.SelectedIndices(0)
            'Guarda la id del vencimiento.
            iidVencimiento = lvVencimientos.Items(indice).Text
            'Actualiza los valores fecha y importe de la linea en el listview. También cambia el color de la fuente si está cobrado o devuelto.
            With lvVencimientos.Items(indice)
                dtpVencimiento.Value = .SubItems(1).Text
                Importe.Text = FormatNumber(.SubItems(3).Text, 2)
                ckCobrado.Checked = (.ForeColor = Color.Green)
                ckDevuelto.Checked = (.ForeColor = Color.Red)
            End With
            'Si no cambia el texto del boton a guardar.
        Else
            Limpiar()
        End If
    End Sub
#End Region

    'Guarda o actualiza los vencimientos. UPDATE 04-05-2017
    Private Sub GuardarVencimiento()
        Dim totalFact As Double = FormatNumber(TotalFactura.Text, 3) 'Variable double total Factura.
        Dim totalRestante As Double = FormatNumber(Restante.Text, 3) 'Variable double total restante.
        Dim totalImporte As Double = FormatNumber(Importe.Text, 3) 'Variable double importe.
        Dim validar As Boolean = True 'Variable para validar campos.
        Dim dts As New DatosVencimiento 'DTS de datos de vencimiento
        dts.gidUsuario = Inicio.vIdUsuario 'Usuario que modifica el vencimiento.
        dts.gImporte = Importe.Text 'Importe del vencimiento.
        dts.gnumFactura = inumFactura 'Numero de factura.
        dts.gVencimiento = dtpVencimiento.Value 'Fecha del vencimiento.
        dts.gCobrado = ckCobrado.Checked 'Estado cobrado.
        dts.gDevuelto = ckDevuelto.Checked 'Estado devuelto.
        'Si la id del vencimiento es 0 esto será para crear vencimiento.
        If iidVencimiento = 0 Then
            'Si el importe es mayor que el totalrestante informa al usuario que se va a crear un vencimiento menor al introducido.
            Dim restanteCalculado As Double = contarRestante()
            If totalImporte + contarRestante() <= totalFact Then
                funcVE.insertar(dts)
                reload()
            Else
                If MsgBox("El importe final es superior al de la factura, ¿ajustar el importe automaticamente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    dts.gImporte = totalFact - contarRestante()
                    funcVE.insertar(dts)
                    reload()
                Else
                    validar = False
                    ep1.SetError(lbMoneda2, "El importe ha de ser menor o igual que la cantidad restante " & totalRestante)
                End If
            End If
            'Si no será una actualización.
        Else
            dts.gidVencimiento = iidVencimiento 'Id del vencimiento.
            'Actualizar
            If ckCobrado.Checked = True Then
                funcVE.Cobrado(dts.gidVencimiento)
                dts.gCobrado = True
                NuevosVencimientos(indice).gCobrado = True
                NuevosVencimientos(indice).gDevuelto = False
            Else
                If ckDevuelto.Checked = True Then
                    funcVE.Devuelto(dts.gidVencimiento)
                    dts.gDevuelto = True
                    NuevosVencimientos(indice).gDevuelto = True
                End If
            End If
            funcVE.actualizar(dts)
            ActualizarLinealv(dts)
        End If

        If validar Then
            cancelado = True
            Call recalcular()
            Call Limpiar()
        End If

    End Sub

    'Private Sub GuardarVencimiento()
    '    'Formatea el campo de importe a cero si este esta vacio
    '    If Importe.Text = "" Then Importe.Text = 0
    '    'Cuenta el total restante sumando los items y restando el del total de la factura
    '    Dim Resto As Double = RestanteActual(indice)

    '    Dim validar As Boolean = True
    '    If Resto > 0 And (Resto - CDbl(Importe.Text)) < -0.01 Then
    '        validar = False
    '        ep1.SetError(lbMoneda2, "El importe ha de ser menor o igual que la cantidad restante " & FormatNumber(Resto, 3))
    '    End If

    '    If Resto < 0 And (CDbl(Importe.Text) - Resto) < -0.01 Then
    '        validar = False
    '        ep1.SetError(lbMoneda2, "El importe ha de ser mayor o igual que la cantidad restante " & FormatNumber(Resto, 3))
    '    End If

    '    If indice = -1 And Importe.Text = 0 Then
    '        validar = False
    '        ep1.SetError(lbMoneda2, "Debe seleccionar un vencimiento o introducir un importe para uno nuevo")
    '    End If

    '    If validar Then
    '        Dim dts As New DatosVencimiento
    '        dts.gidVencimiento = iidVencimiento
    '        dts.gnumFactura = inumFactura
    '        dts.gVencimiento = dtpVencimiento.Value
    '        dts.gImporte = Importe.Text
    '        dts.gCobrado = ckCobrado.Checked
    '        dts.gDevuelto = ckDevuelto.Checked
    '        dts.gidUsuario = Inicio.vIdUsuario
    '        cancelado = True
    '        If indice = -1 Then
    '            'For Each item As ListViewItem In lvVencimientos.Items
    '            '    If CDate(item.SubItems(1).Text) = dtpVencimiento.Value.Date Then
    '            '        indice = item.Index 'Busca si está la fecha
    '            '    End If
    '            'Next
    '            'funcVE.insertar(dts)
    '            'NuevosVencimientos.Add(dts)
    '            'nuevaLinealv(dts)
    '        Else
    '            'Actualizar
    '            If ckCobrado.Checked = True Then
    '                funcVE.Cobrado(dts.gidVencimiento)
    '                dts.gCobrado = True
    '                NuevosVencimientos(indice).gCobrado = True
    '                NuevosVencimientos(indice).gDevuelto = False
    '            End If
    '            If ckDevuelto.Checked = True Then
    '                funcVE.Devuelto(dts.gidVencimiento)
    '                dts.gDevuelto = True
    '                NuevosVencimientos(indice).gDevuelto = True
    '            End If
    '            'NuevosVencimientos(indice) = funcVE.Clonar(dts)
    '            funcVE.actualizar(dts)
    '            ActualizarLinealv(dts)
    '        End If
    '        Call recalcular()
    '        Call Limpiar()
    '    End If
    'End Sub

    'MODIFICADO POR LUIS

    'Private Function RestanteActual(ByVal indiceExcepto As Integer) As Double
    '    Dim Resultado As Double = 0
    '    For i As Integer = 0 To NuevosVencimientos.Count - 1
    '        If i <> indiceExcepto And NuevosVencimientos(i).gCobrado = True Then
    '            Resultado = Resultado + NuevosVencimientos(i).gImporte
    '        End If
    '    Next
    '    Return CDbl(TotalFactura.Text) - Resultado
    'End Function

    'SUMA EL IMPORTE DE LOS VENCIMIENTOS

    Private Function contarRestante() As Double
        Dim Suma As Double = 0
        For Each item In lvVencimientos.Items
            Suma = Suma + item.subitems(3).text
        Next
        Return Suma
    End Function

    'RECALCULA LOS TOTALES
    Private Sub recalcular()
        Dim suma As Double = 0
        Dim resta As Double = 0
        For Each item In lvVencimientos.Items
            If item.subitems(4).text = "COBRADO" Then
                suma = suma + item.subitems(3).text
            End If
        Next
        Restante.Text = FormatNumber(TotalFactura.Text - suma, 3)
    End Sub

    'SELECCIONA LO QUE ES INTRODUCE EN EL CAMPO DE TEXTO
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

#Region "BOTONES"

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If lvVencimientos.SelectedItems.Count > 0 Then
            If ckCobrado.Checked = True Then
                MsgBox("Este vencimiento figura como cobrado.", MsgBoxStyle.Information)
            Else
                If MsgBox("¿Está seguro que quiere borrar este vencimiento?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If indice <> -1 Then
                        funcVE.borrar(lvVencimientos.Items.Item(indice).SubItems(0).Text)
                        NuevosVencimientos.RemoveAt(indice)
                        lvVencimientos.Items.RemoveAt(indice)
                        Call recalcular()
                        Call Limpiar()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    'Botón guardar o actualizar. UPDATE: 04-05-2017
    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        'Borra las advertencias.
        ep1.Clear()
        'Si todos los vencimientos están pagados y no es un devolución, informa al usuario que todo esta cobrado.
        If Restante.Text = 0 And bGuardar.Text <> "ACTUALIZAR" And ckDevuelto.Checked = False Then
            MsgBox("Los vencimiento están todos cobrados. ")
        Else
            'Llama a guardar vencimiento.
            Call GuardarVencimiento()
        End If
    End Sub

    Private Sub blimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        'If TotalFactura.Text = contarRestante() Then
        '    MsgBox("Debe reducir el importe de otro vencimiento para poder crear uno nuevo.", MsgBoxStyle.Information)
        'Else
        '    GuardarVencimiento()
        Call Limpiar()
        'End If

    End Sub

#End Region

    Private Function ListasIguales(ByVal Lista1 As List(Of DatosVencimiento), ByVal Lista2 As List(Of DatosVencimiento)) As Boolean
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
        EstadoGuardado = True
    End Sub

    Private Sub ckCobrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckCobrado.CheckedChanged
        If ckCobrado.Checked Then ckDevuelto.Checked = False
        EstadoGuardado = True
    End Sub

#Region "CODIGO_SOBRANTE"

    'Private Sub GuardarVencimiento()

    '    If Importe.Text = "" Then Importe.Text = 0

    '    Dim Resto As Double = RestanteActual(indice)

    '    Dim validar As Boolean = True
    '    If Resto > 0 And (Resto - CDbl(Importe.Text)) < -0.01 Then
    '        validar = False
    '        ep1.SetError(lbMoneda2, "El importe ha de ser menor o igual que la cantidad restante " & FormatNumber(Resto, 3))
    '    End If

    '    If Resto < 0 And (CDbl(Importe.Text) - Resto) < -0.01 Then
    '        validar = False
    '        ep1.SetError(lbMoneda2, "El importe ha de ser mayor o igual que la cantidad restante " & FormatNumber(Resto, 3))
    '    End If

    '    If indice = -1 And Importe.Text = 0 Then
    '        validar = False
    '        ep1.SetError(lbMoneda2, "Debe seleccionar un vencimiento o introducir un importe para uno nuevo")
    '    End If

    '    If validar Then
    '        Dim dts As New DatosVencimiento
    '        dts.gidVencimiento = iidVencimiento
    '        dts.gnumFactura = inumFactura
    '        dts.gVencimiento = dtpVencimiento.Value
    '        dts.gImporte = Importe.Text
    '        dts.gCobrado = ckCobrado.Checked
    '        dts.gDevuelto = ckDevuelto.Checked
    '        cancelado = True
    '        If indice = -1 Then
    '            For Each item As ListViewItem In lvVencimientos.Items
    '                If CDate(item.SubItems(1).Text) = dtpVencimiento.Value.Date Then
    '                    indice = item.Index 'Busca si está la fecha
    '                End If
    '            Next
    '            NuevosVencimientos.Add(dts)
    '            nuevaLinealv(dts)
    '        Else
    '            'Actualizar
    '            If ckCobrado.Checked = True Then
    '                funcVE.Cobrado(dts.gidVencimiento)
    '                dts.gCobrado = True
    '            End If
    '            If ckDevuelto.Checked = True Then
    '                funcVE.Devuelto(dts.gidVencimiento)
    '                dts.gDevuelto = True
    '            End If
    '            'NuevosVencimientos(indice) = funcVE.Clonar(dts)
    '            ActualizarLinealv(dts)
    '        End If
    '        Call recalcular()
    '        Call Limpiar()
    '    End If
    'End Sub



    'Private Sub Importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Importe.Click
    '    sender.selectall()
    'End Sub


    'If ListasIguales(Vencimientos, NuevosVencimientos) Then
    '    cancelado = True
    '    Me.Close()
    'Else
    '    Select MsgBox("¿Guardar los cambios realizados?", MsgBoxStyle.YesNoCancel)
    '        Case MsgBoxResult.Yes
    '            Call recalcular()
    '            If Restante.Text = "" Then Restante.Text = 0
    '            Dim dRestante As Double = Restante.Text
    '            If Math.Abs(dRestante) > 0.01 Then
    '                MsgBox("El total no coincide con la suma de vencimientos")
    '            Else
    '                NuevosVencimientos.Sort(Function(x, y) x.gVencimiento.CompareTo(y.gVencimiento))

    '                Vencimientos.Clear()
    '                For Each dts As DatosVencimiento In NuevosVencimientos
    '                    Vencimientos.Add(dts)
    '                Next
    '                cancelado = False
    '                Me.Close()
    '            End If
    '        Case MsgBoxResult.No
    '            cancelado = True
    '            Me.Close()
    '        Case MsgBoxResult.Cancel

    '    End Select
    'End If

    'Private Sub bMenos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bMenos.Click
    '    If indice <> -1 Then
    '        Vencimientos.RemoveAt(indice)
    '        lvVencimientos.Items.RemoveAt(indice)
    '        Call Limpiar()
    '        Call recalcular()

    '    End If
    'End Sub
#End Region

End Class

