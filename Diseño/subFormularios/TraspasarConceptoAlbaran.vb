Public Class TraspasarConceptoAlbaran

    
    Private dtsC As DatosConceptoAlbaran
    Private dtsNC As DatosConceptoAlbaran
    Private dtsA As DatosAlbaran
    Private dtsNA As DatosAlbaran
    Private funcCA As New FuncionesConceptosAlbaranes
    Private funcAL As New FuncionesAlbaranes
    Private funcES As New FuncionesEstados
    Private funcCP As New FuncionesConceptosPedidos
    Private NuevoAlbaran As Integer
    Private idEstadoALCabecera As Integer
    Private idEstadoALServido As Integer
    Private idEstadoALAnulado As Integer
    Private idEstadoALFacturado As Integer
    Private idEstadoALPreparado As Integer
    Private idEstadoCATraspasado As Integer
    Private ep1 As New ErrorProvider
    Private Diferencia As Double
    Private vSoloLectura As Boolean
    Private localizacion As Point

    Public Property pLocalizacion() As Point
        Get
            Return localizacion
        End Get
        Set(ByVal value As Point)
            localizacion = value
        End Set
    End Property

    Public Property pDts() As DatosConceptoAlbaran
        Get
            Return dtsC
        End Get
        Set(ByVal value As DatosConceptoAlbaran)
            dtsC = value
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


    Private Sub TraspasarConceptoAlbaran_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call PresentarDatos()
        Call CargarAlbaranes()
        idEstadoALAnulado = funcES.EstadoAnulado("ALBARAN").gidEstado
        idEstadoALCabecera = funcES.EstadoCabecera("ALBARAN").gidEstado
        idEstadoALServido = funcES.EstadoEntregado("ALBARAN").gidEstado
        idEstadoALFacturado = funcES.EstadoTraspasado("ALBARAN").gidEstado
        idEstadoALPreparado = funcES.EstadoEnCurso("ALBARAN").gidEstado
        idEstadoCATraspasado = funcES.EstadoTraspasado("C.ALBARAN").gidEstado
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
    End Sub


    Private Sub PresentarDatos()
        dtsA = funcAL.Mostrar1(dtsC.gnumAlbaran)
        dtpFecha.Value = dtsA.gFecha
        dtpFechaEntrega.Value = dtsA.gFechaEntrega
        ReferenciaCliente.Text = dtsA.gReferenciaCliente
        RefCliente2.Text = dtsA.gReferenciaCliente2
        Articulo.Text = dtsC.gArticulo
        codArticulo.Text = dtsC.gcodArticulo
        Cantidad.Text = FormatNumber(dtsC.gCantidad, 2)
        lbUnidad.Text = dtsC.gTipoUnidad
    End Sub


    Private Sub CargarAlbaranes()
        Dim lista As List(Of DatosAlbaran) = funcAL.Busqueda(" Bloqueado=0 AND Clientes.idCliente = " & dtsA.gidCliente & " AND DOC.numAlbaran <> " & dtsC.gnumAlbaran, " numAlbaran ASC ", True)
        For Each dtsH As DatosAlbaran In lista
            With lvConceptos.Items.Add(dtsH.gnumAlbaran)
                .SubItems.Add(dtsH.gReferenciaCliente)
                .SubItems.Add(dtsH.gFecha)
                .SubItems.Add(dtsH.gEstado)
                .SubItems.Add(0)
            End With
        Next
    End Sub


    Private Function ComprobarCantidad() As Boolean
        If Not IsNumeric(Cantidad.Text) Then Cantidad.Text = 0
        Diferencia = dtsC.gCantidad - Cantidad.Text
        If (dtsC.gCantidad < 0 And Diferencia <= 0) Or (dtsC.gCantidad >= 0 And Diferencia >= 0) Then
            Return True
        Else
            ep1.SetIconAlignment(Cantidad, ErrorIconAlignment.MiddleLeft)
            ep1.SetError(Cantidad, "Cantidad no válida")
            Return False
        End If
    End Function


    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        If MsgBox("¿Crear un nuevo albarán con el concepto traspasado?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            If ComprobarCantidad() Then
                Call CrearAlbaran()
                Call RealizarProceso()
            End If
        End If
    End Sub

    Private Sub bAnadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAnadir.Click
        If lvConceptos.SelectedItems.Count = 0 Then
            MsgBox("No se ha seleccionado un albarán para agregar los conceptos")
        ElseIf ComprobarCantidad() Then
            dtsNA = funcAL.Mostrar1(lvConceptos.SelectedItems(0).Text)
            Call RealizarProceso()
        End If

    End Sub

    Private Sub RealizarProceso()
        If Diferencia = 0 Then
            funcCA.CambiarNum(dtsC.gidConcepto, dtsNA.gnumAlbaran, "ALBARAN")
            funcCP.CambiarNum(dtsC.gidConceptoPedido, dtsNA.gnumAlbaran, "ALBARAN")
        Else
            dtsNC = dtsC.Clonar
            dtsC.gCantidad = Diferencia
            Call funcCA.actualizar(dtsC)
            Call AgregarLinea()
        End If
        Call RevisarEstado(dtsNA)
        Call RevisarEstado(dtsA)
        Dim GG As New GestionAlbaran
        GG.SoloLectura = vSoloLectura
        GG.pLocation = New Point(localizacion.X + 15, localizacion.Y + 15)
        GG.pnumAlbaran = dtsNA.gnumAlbaran
        GG.ShowDialog()
        bNuevo.Enabled = False
        bAnadir.Enabled = False
        Me.Close()
    End Sub

    Private Sub CrearAlbaran()
        dtsNA = dtsA.Clonar
        dtsNA.gidEstado = idEstadoALCabecera
        dtsNA.gBultos = 0
        dtsNA.gKilosBrutos = 0
        dtsNA.gKilosNetos = 0
        dtsNA.gVolumen = 0
        dtsNA.gMedidas = 0
        dtsNA.gFecha = dtpFecha.Value.Date
        dtsNA.gFechaEntrega = dtpFechaEntrega.Value.Date
        dtsNA.gReferenciaCliente = ReferenciaCliente.Text
        dtsNA.gReferenciaCliente2 = RefCliente2.Text
        dtsNA.gnumAlbaran = funcAL.insertar(dtsNA)
        NuevoAlbaran = dtsNA.gnumAlbaran
    End Sub

    Private Sub AgregarLinea()
        dtsNC.gnumAlbaran = NuevoAlbaran
        dtsNC.gCantidad = Cantidad.Text
        dtsNC.gOrden = funcCA.UltimoOrden(NuevoAlbaran) + 1
        dtsNC.gidConcepto = funcCA.insertar(dtsNC)
    End Sub

    Private Sub RevisarEstado(ByVal dtsALB As DatosAlbaran)
        Dim lista As List(Of DatosConceptoAlbaran) = funcCA.Mostrar(dtsALB.gnumAlbaran)
        If dtsALB.gidEstado = idEstadoALAnulado Then
            'si está anulado, lo dejamos
        ElseIf lista.Count = 0 Then
            'Si no tiene conceptos, mod cabecera
            funcAL.actualizaEstado(dtsALB.gnumAlbaran, idEstadoALCabecera)
        Else
            Dim TodosTraspasados As Boolean = True
            For Each dts As DatosConceptoAlbaran In lista
                If dts.gidEstado = idEstadoCATraspasado And dts.gnumFactura <> 0 Then
                Else
                    TodosTraspasados = False
                End If
            Next
            'Si todos los conceptos están facturados, ponemos modo facturado
            If TodosTraspasados Then
                funcAL.actualizaEstado(dtsALB.gnumAlbaran, idEstadoALFacturado)
            ElseIf dtsALB.gidEstado <> idEstadoALServido And dtsALB.gidEstado <> idEstadoALPreparado Then
                'Si no está preparado ni servido, lo ponemos preparado
                funcAL.actualizaEstado(dtsALB.gnumAlbaran, idEstadoALPreparado)
            End If
        End If
    End Sub

    Private Sub Cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidad.KeyPress

        'Admite números negativos y decimales
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If KeyAscii = Asc(".") Then
            e.KeyChar = ","
        End If
        If Microsoft.VisualBasic.Left(Cantidad.Text, 1) = "-" Then
            KeyAscii = CShort(SoloNumeros(KeyAscii))
        Else
            If Cantidad.Text = "" Or Cantidad.Text = "0" Then
                KeyAscii = CShort(SoloNumerosConGuiones(KeyAscii))
            Else
                If InStr(Cantidad.Text, ",") Then
                    KeyAscii = CShort(SoloNumeros(KeyAscii))
                Else
                    KeyAscii = CShort(SoloNumerosConDecimales(KeyAscii))
                End If
            End If
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

End Class