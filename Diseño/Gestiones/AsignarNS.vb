Public Class AsignarNS

    Private listaEquipos As List(Of DatosEquipoProduccion)
    Private vsoloLectura As Boolean
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcCP As New FuncionesConceptosPedidos
    Private funcES As New FuncionesEstados
    Private funcPE As New FuncionesPedidos
    Private funcAR As New FuncionesArticulos
    Private funcMA As New Master
    'Private Cambios As Boolean
    Private AlgunaAsignar As Boolean
    Private indice As Integer
    Private CantidadPreparada As Integer
    Private idEstadoCPPreparado As Integer
    Private idEstadoPEPReparado As Integer
    Private idEstadoPEParcial As Integer
    Private idEstadoEQEspera As Integer
    Private idEstadoEQEnCurso As Integer
    Private idEstadoEQCompleto As Integer
    Private nuevoNS As Integer 'Nuevo número de serie según Master
    Private NSAsignar As Integer 'Siguiente Número de serie a asignar
    Private semaforo As Boolean



    Public Property plistaEquipos() As List(Of DatosEquipoProduccion) 'Cargo la lista de equipos como parámetro desde la Gestión Logística
        Get
            Return listaEquipos
        End Get
        Set(ByVal value As List(Of DatosEquipoProduccion))
            listaEquipos = value
        End Set
    End Property

    Public Property soloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property


    Public Property pCantidadPreparada() As Integer
        Get
            Return CantidadPreparada
        End Get
        Set(ByVal value As Integer)
            CantidadPreparada = value
        End Set
    End Property


    Private Sub AsignarNS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        bGuardar.Enabled = Not vsoloLectura
        ckSeleccion.Location = New Point(lvConceptos.Location.X + 6, lvConceptos.Location.Y + 6) 'Ubicar exactamente el checkbox para que coincida con los del listview
        idEstadoCPPreparado = funcES.EstadoCPedido("PREPARADO").gidEstado
        idEstadoPEPReparado = funcES.EstadoPedido("PREPARADO").gidEstado
        idEstadoPEParcial = funcES.EstadoPedido("PARCIAL").gidEstado
        idEstadoEQCompleto = funcES.EstadoCompleto("EQUIPO").gidEstado
        idEstadoEQEnCurso = funcES.EstadoEnCurso("EQUIPO").gidEstado
        idEstadoEQEspera = funcES.EstadoEspera("EQUIPO").gidEstado
        nuevoNS = funcMA.leernumSerie(Now.Year) + 1
        NSAsignar = nuevoNS
        'If Not listaEquipos Is Nothing Then
        If listaEquipos.Count > 0 Then
            codArticulo.Text = listaEquipos(0).gcodArticulo
            Articulo.Text = listaEquipos(0).gArticulo
            numPedido.Text = listaEquipos(0).gnumPedido
            Cliente.Text = listaEquipos(0).gCliente
            numSerie.Text = ""
            indice = -1
            Call CargarLV()
        End If
        semaforo = True
    End Sub

    Private Sub AsignarNS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
       
        If AlgunaAsignar Then
            If MsgBox("¿Salir sin guardar las asignaciones?", MsgBoxStyle.OkCancel) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub CargarLV()
        Try
            Dim nuevoNS As Integer = funcMA.leernumSerie(Now.Year) + 1 'funcEQ.nuevoNumSerie
            '17-3-2015
            'Presenta todos los equipos de la idProducción
            'En verde oscuro los ya asignados antes
            'En verde los completados de producción estos son los únicos con n/s propuesto (Estado COMPLETO)
            'En naranja los que están en producción pero no acabado (Estado EN CURSO)
            'En negro los pendientes (Estado ESPERA)
            Dim i As Integer = 0

            AlgunaAsignar = False
            For Each dts As DatosEquipoProduccion In listaEquipos
                With lvConceptos.Items.Add(" ")
                    .SubItems.Add(dts.gidEquipo)

                    Select Case dts.gidEstado
                        Case idEstadoEQCompleto

                            .SubItems.Add(Format(dts.gFechaFin, "dd/MM/yyyy HH:mm"))
                            If dts.gconNumSerie Or dts.gconNumSerie2 Then
                                If dts.gnumSerie <> "" And dts.gnumSerie <> "0" Then

                                    .SubItems.Add(dts.gnumSerie)

                                    .ForeColor = Color.Black
                                    .BackColor = Color.PaleGreen
                                Else

                                    .SubItems.Add("")

                                    AlgunaAsignar = True 'Si hay alguno sin asignar, avisaremos al salir
                                    .ForeColor = Color.Green
                                End If

                            Else
                                .SubItems.Add("SIN N/S")
                               
                                If dts.gAsignado Then
                                    .ForeColor = Color.Black
                                    .BackColor = Color.PaleGreen
                                Else
                                    AlgunaAsignar = True 'Si hay alguno sin asignar, avisaremos al salir
                                    .ForeColor = Color.Green
                                End If

                            End If

                        Case idEstadoEQEnCurso
                            .SubItems.Add("PRODUCCIÓN")
                            .SubItems.Add(dts.gnumSerie)

                            .ForeColor = Color.Orange
                        Case idEstadoEQEspera
                            .SubItems.Add("PRODUCCIÓN")
                            .SubItems.Add(dts.gnumSerie)

                            .ForeColor = Color.Black
                        Case Else
                            .SubItems.Add("")
                            .SubItems.Add("")
                    End Select
                End With
            Next
        Catch ex As Exception
            ex.Data.Add("nuevoNS", nuevoNS)
            CorreoError(ex)
        End Try

    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        'BOTÓN ASIGNAR
        If listaEquipos.Count > 0 Then
            Dim N As Integer = lvConceptos.CheckedItems.Count
            Dim dts As DatosEquipoProduccion
            For Each item As ListViewItem In lvConceptos.CheckedItems
                dts = listaEquipos(item.Index)
                'Verificamos que la linea tenga número de serie
                If dts.gnumSerie = "" Or dts.gnumSerie = "0" Then
                    'If item.ForeColor <> Color.Green Then item.Checked = False
                Else
                    item.Checked = False
                End If
            Next
            N = N - lvConceptos.CheckedItems.Count
            If N = 1 Then
                MsgBox("Se ha desactivado un equipo no asignable.")
            End If
            If N > 1 Then
                MsgBox("Se han desactivado " & N & " equipos no asignables.")
            End If
            If lvConceptos.CheckedItems.Count = 0 Then
                If N = 0 Then MsgBox("No hay ningun concepto seleccionado.")
            Else
                Call GuardarLineas()
            End If
        End If

    End Sub

    Private Sub GuardarLineas()

        Dim N As Integer = lvConceptos.CheckedItems.Count

        Dim Realizado As Boolean = False

        Dim NuevoNumSerie As Integer

        Dim conNumeroSerie As Boolean = False

        Dim conNumeroSerie2 As Boolean = False

        Dim Titulo As String = "NÚMEROS DE SERIE "

        If funcEQ.conNumSerie(lvConceptos.CheckedItems(0).SubItems(1).Text) Then

            NuevoNumSerie = funcMA.leernumSerie(Now.Year) + 1

            conNumeroSerie = True

            Titulo = Titulo & "(NORMAL)"

        ElseIf funcEQ.conNumSerie2(lvConceptos.CheckedItems(0).SubItems(1).Text) Then

            NuevoNumSerie = funcMA.leernumSerie2(Now.Year) + 1

            conNumeroSerie2 = True

            Titulo = Titulo & "(REPUESTOS)"

        End If

        If conNumeroSerie Or conNumeroSerie2 Then

            Dim SS As New subSelecionarNumSerie

            SS.pCuantas = N

            SS.pnumSerieDesde = NuevoNumSerie

            SS.pTitulo = Titulo

            SS.ShowDialog()

            If SS.DialogResult = Windows.Forms.DialogResult.OK Then

                If SS.pnumSerieDesde = NuevoNumSerie Then

                    For Each item As ListViewItem In lvConceptos.CheckedItems

                        If conNumeroSerie Then

                            Call GuardarLinea(item, funcMA.incnumSerie(Now.Year))

                        ElseIf conNumeroSerie2 Then

                            Call GuardarLinea(item, funcMA.incnumSerie2(Now.Year))

                        End If

                    Next

                Else

                    NuevoNumSerie = SS.pnumSerieDesde

                    For Each item As ListViewItem In lvConceptos.CheckedItems

                        Call GuardarLinea(item, NuevoNumSerie)

                        NuevoNumSerie = NuevoNumSerie + 1

                    Next

                End If

                Realizado = True

            End If

        Else

            For Each item As ListViewItem In lvConceptos.CheckedItems

                Call GuardarLinea(item, "0")

            Next

            Realizado = True

        End If

        If Realizado Then

            funcCP.CambiarCantidadPreparada(listaEquipos(0).gidConceptoPedido, funcCP.CantidadPreparadaRealmente(listaEquipos(0).gidConceptoPedido)) 'CantidadPreparada)

            If N = 1 Then

                MsgBox("Queda preparado un equipo.")

            Else

                MsgBox("Quedan preparados " & N & " equipos.")

            End If

            AlgunaAsignar = False

        End If

    End Sub

    Private Sub GuardarLinea(ByVal item As ListViewItem, ByVal NuevoNumSerie As Integer)

        'Guardamos el nº propuesto como nº de serie en todas las lineas que no estén en verde. Y modificamos el listview en consecuencia
        If item.ForeColor = Color.Green Then

        End If
        If (funcEQ.AsignarnumSerie(item.SubItems(1).Text, NuevoNumSerie)) Then
            item.SubItems(3).Text = NuevoNumSerie
            item.ForeColor = Color.Black
            item.BackColor = Color.PaleGreen
            CantidadPreparada = CantidadPreparada + 1
            Call CambiarEstados(item.SubItems(1).Text)
            'item.Checked = False  'No quitamos el check que sirve para seleccionar las etiquetas
        Else
            MsgBox("Se ha producido un error en la asignación")
        End If

    End Sub

    Private Sub lvConceptos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvConceptos.Click
        'If lvConceptos.SelectedItems.Count > 0 Then
        '    indice = lvConceptos.SelectedIndices(0)
        '    If lvConceptos.Items(indice).ForeColor <> Color.Green Then
        '        numSerie.Text = lvConceptos.Items(indice).SubItems(3).Text
        '        bGuardar.Text = "GUARDAR LINEA"
        '    End If
        'End If
    End Sub

    Private Sub CambiarEstados(ByVal iidEquipo As Integer)

        'Si el concepto de pedido está completo, lo ponemos en estado PREPARADO
        'Si hay algo preparado para servir, ponemos el pedido en estado PREPARADO

        Dim dtsEQ As DatosEquipoProduccion = funcEQ.Mostrar1(iidEquipo)

        If dtsEQ.gidConceptoPedido > 0 Then
            Dim dtsCP As DatosConceptoPedido = funcCP.Mostrar1(dtsEQ.gidConceptoPedido)
            If funcEQ.ProduccionCompletada(dtsEQ.gidProduccion) Then
                funcCP.CambiarEstado(dtsEQ.gidConceptoPedido, idEstadoCPPreparado)
            End If
            If funcPE.idEstado(dtsEQ.gnumPedido) <> idEstadoPEParcial Then
                'Ponemos el pedido en estado Preparado si no está parcial
                funcPE.actualizaEstado(dtsEQ.gnumPedido, idEstadoPEPReparado)
            End If

        End If

    End Sub

    Private Sub numSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numSerie.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub bEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEtiquetas.Click
        Dim lista As New List(Of Integer)
        Dim N As Integer = lvConceptos.CheckedItems.Count
        For Each item As ListViewItem In lvConceptos.CheckedItems
            If item.BackColor = Color.PaleGreen Then
                If IsNumeric(item.SubItems(3).Text) Then
                    lista.Add(item.SubItems(3).Text)
                Else
                    item.Checked = False
                End If
            Else
                item.Checked = False
            End If
        Next
        N = N - lvConceptos.CheckedItems.Count
        If N = 1 Then
            MsgBox("Se ha desactivado un equipo no asignable.")
        End If
        If N > 1 Then
            MsgBox("Se han desactivado " & N & " equipos no asignables.")
        End If
        If lista.Count = 0 Then
            If N = 0 Then MsgBox("No se han encontrado números de serie.")
        Else
            Dim funcET As New FuncionesEtiquetas
            Dim GG As New GestionEtiquetas
            GG.SoloLectura = vsoloLectura
            GG.pnumSSerie = lista
            GG.pcodArticulo = codArticulo.Text
            GG.pidEtiqueta = funcET.idEtiqueta(listaEquipos(0).gidCliente)
            GG.ShowDialog()

        End If

    End Sub

    Private Sub ckSeleccion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckSeleccion.Click
        'Si marcamos el check arriba, se propaga a todas las lineas. Si es indetermianado no hacemos nada
        If ckSeleccion.CheckState = CheckState.Indeterminate Then
        Else
            semaforo = False
            For Each item As ListViewItem In lvConceptos.Items
                item.Checked = ckSeleccion.Checked
            Next
            semaforo = True
        End If

    End Sub

    Private Sub lvConceptos_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvConceptos.ItemChecked
        If semaforo Then
            Dim cont As Integer = lvConceptos.CheckedIndices.Count
            If cont = 0 Then
                ckSeleccion.CheckState = CheckState.Unchecked
            ElseIf cont = lvConceptos.Items.Count Then
                ckSeleccion.CheckState = CheckState.Checked
            Else
                ckSeleccion.CheckState = CheckState.Indeterminate
            End If
        End If
    End Sub

End Class