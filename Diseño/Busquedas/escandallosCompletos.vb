Public Class escandallosCompletos

    Public idescandallo As Integer

    Dim funcES As New FuncionesEscandallos

    Dim idActual As Integer

    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.

    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.

    Dim tituloInforme As String = "ESCANDALLO"  'Título que aparece al imprimir el listado de escandallo

    Public totalCoste As Double = 0

    Public exportacionMasiva As Boolean

    Public ruta As String

    Public coste As Boolean

    'Cargamos el formulario.
    Private Sub escandallosCompletos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txIdEscandallo.Text = idescandallo

        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize

        Me.Height = desktopSize.Height - 50

        Me.Location = New Point(Me.Location.X, 20)

        escandallosBucle()

    End Sub

    Public Sub escandallosBucle()

        lvEscandallosySubescandallos.Items.Clear()

        Dim fin As Boolean = False

        Try
            Do While fin = False

                fin = llenarLv(idescandallo)

            Loop

            If exportacionMasiva Then

                imprimir()

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Public Function llenarLv(ByVal id As Integer) As Boolean

        Dim i As Integer = 0

        idActual = id

        Dim lista0 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 0) 'Lista de nivel 0

        If lista0 Is Nothing Then

            Return True

        End If

        Dim lista1 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 1) 'Lista de nivel 1

        Dim lista2 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 2) 'Lista de nivel 2

        Dim lista3 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 3) 'Lista de nivel 3

        Dim lista4 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 4) 'Lista de nivel 4

        Dim lista5 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 5) 'Lista de nivel 5

        Dim lista6 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 6) 'Lista de nivel 6

        Dim color0 As Boolean

        Dim color1 As Boolean

        Dim color2 As Boolean

        Dim color3 As Boolean

        Dim color4 As Boolean

        Dim color5 As Boolean

        Try

            Dim dts0 As DatosEscandallo

            If lista0.Count = 0 Then

                Return True

            Else

                For Each dts0 In lista0 'Introducimos los conceptos de escandallo de nivel 0.

                    If dts0.gLevel = i Then

                        lvEscandallosySubescandallos.ForeColor = Color.Black

                        With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts0.gLevel)

                            .SubItems.Add(dts0.gidArticulo)

                            .SubItems.Add(dts0.gidEscandallo)

                            .SubItems.Add(dts0.gcodArticulo)

                            .SubItems.Add(dts0.gArticulo)

                            .SubItems.Add(dts0.gFamilia)

                            .SubItems.Add(If(dts0.gSubfamilia = "", " ", dts0.gSubfamilia))

                            .SubItems.Add(dts0.gseccion)

                            .SubItems.Add(FormatNumber(dts0.gCantidad, 4))

                            .SubItems.Add(dts0.gTipoUnidad)

                            .SubItems.Add(FormatNumber(dts0.gCoste * dts0.gCantidad, 4))

                            .SubItems.Add(dts0.gSimbolo)

                            .SubItems.Add("MP")

                            .SubItems.Add("White")

                            .SubItems.Add("Black")

                        End With

                        Dim dts1 As DatosEscandallo

                        If lista1.Count = 0 Then

                        Else

                            For Each dts1 In lista1 'Introducimos los conceptos de escandallo de nivel 1.

                                If dts1.gcodArticulo = dts0.gidArticulo Then

                                    Label1.Visible = True

                                    If color0 = False Then

                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkGreen

                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkGreen"

                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

                                        color0 = True

                                    End If

                                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts1.gLevel)

                                        dts1.gCantidad = dts1.gCantidad * dts0.gCantidad

                                        .SubItems.Add(dts1.gidArticulo)

                                        .SubItems.Add(dts1.gidEscandallo)

                                        .SubItems.Add(dts1.gcodArticulo)

                                        .SubItems.Add(dts1.gArticulo)

                                        .SubItems.Add(dts1.gFamilia)

                                        .SubItems.Add(If(dts1.gSubfamilia = "", " ", dts1.gSubfamilia))

                                        .SubItems.Add(dts1.gseccion)

                                        .SubItems.Add(FormatNumber(dts1.gCantidad, 4))

                                        .SubItems.Add(dts1.gTipoUnidad)

                                        .SubItems.Add(FormatNumber(dts1.gCoste * dts1.gCantidad, 4))

                                        .SubItems.Add(dts1.gSimbolo)

                                        .SubItems.Add("MP")

                                        .SubItems.Add("White")

                                        .SubItems.Add("DarkGreen")

                                    End With

                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkGreen

                                    Dim dts2 As DatosEscandallo

                                    If lista2.Count = 0 Then

                                    Else

                                        For Each dts2 In lista2 'Introducimos los conceptos de escandallo de nivel 2.

                                            If dts2.gcodArticulo = dts1.gidArticulo Then

                                                Label2.Visible = True

                                                If color1 = False Then

                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkOrange

                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkOrange"

                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

                                                    color1 = True

                                                End If

                                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts2.gLevel)

                                                    dts2.gCantidad = dts2.gCantidad * dts1.gCantidad

                                                    .SubItems.Add(dts2.gidArticulo)

                                                    .SubItems.Add(dts2.gidEscandallo)

                                                    .SubItems.Add(dts2.gcodArticulo)

                                                    .SubItems.Add(dts2.gArticulo)

                                                    .SubItems.Add(dts2.gFamilia)

                                                    .SubItems.Add(If(dts2.gSubfamilia = "", " ", dts2.gSubfamilia))

                                                    .SubItems.Add(dts2.gseccion)

                                                    .SubItems.Add(FormatNumber(dts2.gCantidad, 4))

                                                    .SubItems.Add(dts2.gTipoUnidad)

                                                    .SubItems.Add(FormatNumber(dts2.gCoste * dts2.gCantidad, 4))

                                                    .SubItems.Add(dts2.gSimbolo)

                                                    .SubItems.Add("MP")

                                                    .SubItems.Add("White")

                                                    .SubItems.Add("DarkOrange")

                                                End With

                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkOrange

                                                Dim dts3 As DatosEscandallo

                                                If lista3.Count = 0 Then

                                                Else

                                                    For Each dts3 In lista3 'Introducimos los conceptos de escandallo de nivel 3.

                                                        If dts3.gcodArticulo = dts2.gidArticulo Then

                                                            Label3.Visible = True

                                                            If color2 = False Then

                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkRed

                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkRed"

                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

                                                                color2 = True

                                                            End If

                                                            With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts3.gLevel)

                                                                dts3.gCantidad = dts3.gCantidad * dts2.gCantidad

                                                                .SubItems.Add(dts3.gidArticulo)

                                                                .SubItems.Add(dts3.gidEscandallo)

                                                                .SubItems.Add(dts3.gcodArticulo)

                                                                .SubItems.Add(dts3.gArticulo)

                                                                .SubItems.Add(dts3.gFamilia)

                                                                .SubItems.Add(If(dts3.gSubfamilia = "", " ", dts3.gSubfamilia))

                                                                .SubItems.Add(dts3.gseccion)

                                                                .SubItems.Add(FormatNumber(dts3.gCantidad, 4))

                                                                .SubItems.Add(dts3.gTipoUnidad)

                                                                .SubItems.Add(FormatNumber(dts3.gCoste * dts3.gCantidad, 4))

                                                                .SubItems.Add(dts3.gSimbolo)

                                                                .SubItems.Add("MP")

                                                                .SubItems.Add("White")

                                                                .SubItems.Add("DarkRed")

                                                            End With

                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkRed

                                                            Dim dts4 As DatosEscandallo

                                                            If lista4.Count = 0 Then

                                                            Else

                                                                For Each dts4 In lista4 'Introducimos los conceptos de escandallo de nivel 4.

                                                                    If dts4.gcodArticulo = dts3.gidArticulo Then

                                                                        Label4.Visible = True

                                                                        If color3 = False Then

                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkBlue

                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkBlue"

                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

                                                                            color3 = True

                                                                        End If

                                                                        With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts4.gLevel)

                                                                            dts4.gCantidad = dts4.gCantidad * dts3.gCantidad

                                                                            .SubItems.Add(dts4.gidArticulo)

                                                                            .SubItems.Add(dts4.gidEscandallo)

                                                                            .SubItems.Add(dts4.gcodArticulo)

                                                                            .SubItems.Add(dts4.gArticulo)

                                                                            .SubItems.Add(dts4.gFamilia)

                                                                            .SubItems.Add(If(dts4.gSubfamilia = "", " ", dts4.gSubfamilia))

                                                                            .SubItems.Add(dts4.gseccion)

                                                                            .SubItems.Add(FormatNumber(dts4.gCantidad, 4))

                                                                            .SubItems.Add(dts4.gTipoUnidad)

                                                                            .SubItems.Add(FormatNumber(dts4.gCoste * dts4.gCantidad, 4))

                                                                            .SubItems.Add(dts4.gSimbolo)

                                                                            .SubItems.Add("MP")

                                                                            .SubItems.Add("White")

                                                                            .SubItems.Add("DarkBlue")

                                                                        End With

                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkBlue

                                                                        Dim dts5 As DatosEscandallo

                                                                        If lista5.Count = 0 Then

                                                                        Else

                                                                            For Each dts5 In lista5 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                If dts5.gcodArticulo = dts4.gidArticulo Then

                                                                                    Label5.Visible = True

                                                                                    If color4 = False Then

                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.Purple

                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "Purple"

                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

                                                                                        color4 = True

                                                                                    End If

                                                                                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts5.gLevel)

                                                                                        dts5.gCantidad = dts5.gCantidad * dts4.gCantidad

                                                                                        .SubItems.Add(dts5.gidArticulo)

                                                                                        .SubItems.Add(dts5.gidEscandallo)

                                                                                        .SubItems.Add(dts5.gcodArticulo)

                                                                                        .SubItems.Add(dts5.gArticulo)

                                                                                        .SubItems.Add(dts5.gFamilia)

                                                                                        .SubItems.Add(If(dts5.gSubfamilia = "", " ", dts5.gSubfamilia))

                                                                                        .SubItems.Add(dts5.gseccion)

                                                                                        .SubItems.Add(FormatNumber(dts5.gCantidad, 4))

                                                                                        .SubItems.Add(dts5.gTipoUnidad)

                                                                                        .SubItems.Add(FormatNumber(dts5.gCoste * dts5.gCantidad, 4))

                                                                                        .SubItems.Add(dts5.gSimbolo)

                                                                                        .SubItems.Add("MP")

                                                                                        .SubItems.Add("White")

                                                                                        .SubItems.Add("Purple")

                                                                                    End With

                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.Purple

                                                                                    Dim dts6 As DatosEscandallo

                                                                                    If lista6.Count = 0 Then

                                                                                    Else

                                                                                        For Each dts6 In lista6 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                            If dts6.gcodArticulo = dts5.gidArticulo Then

                                                                                                Label6.Visible = True

                                                                                                If color5 = False Then

                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.Red

                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "Red"

                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

                                                                                                    color5 = True

                                                                                                End If

                                                                                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts6.gLevel)

                                                                                                    dts6.gCantidad = dts6.gCantidad * dts5.gCantidad

                                                                                                    .SubItems.Add(dts6.gidArticulo)

                                                                                                    .SubItems.Add(dts6.gidEscandallo)

                                                                                                    .SubItems.Add(dts6.gcodArticulo)

                                                                                                    .SubItems.Add(dts6.gArticulo)

                                                                                                    .SubItems.Add(dts6.gFamilia)

                                                                                                    .SubItems.Add(If(dts6.gSubfamilia = "", " ", dts6.gSubfamilia))

                                                                                                    .SubItems.Add(dts6.gseccion)

                                                                                                    .SubItems.Add(FormatNumber(dts6.gCantidad, 4))

                                                                                                    .SubItems.Add(dts6.gTipoUnidad)

                                                                                                    .SubItems.Add(FormatNumber(dts6.gCoste * dts6.gCantidad, 4))

                                                                                                    .SubItems.Add(dts6.gSimbolo)

                                                                                                    .SubItems.Add("MP")

                                                                                                    .SubItems.Add("White")

                                                                                                    .SubItems.Add("Red")

                                                                                                End With

                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.Red

                                                                                            End If

                                                                                        Next

                                                                                        color5 = False

                                                                                    End If

                                                                                End If

                                                                            Next

                                                                            color4 = False

                                                                        End If

                                                                    End If

                                                                Next

                                                                color3 = False

                                                            End If

                                                        End If

                                                    Next

                                                    color2 = False

                                                End If


                                            End If

                                        Next

                                        color1 = False

                                    End If

                                End If

                            Next

                            color0 = False

                        End If

                    End If

                Next

                materiasPrimas()

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return True

        End Try

    End Function

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'Muestra o oculta los articulos con escandallo.
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckMateriasPrimas.CheckedChanged

        materiasPrimas()

        If ckMateriasPrimas.Checked Then

            tituloInforme = "MATERIAS PRIMAS DE ESCANDALLO"

        Else
            tituloInforme = "ESCANDALLO"

            lvEscandallosySubescandallos.Sorting = SortOrder.None

            lvEscandallosySubescandallos.Items.Clear()

            llenarLv(idActual)

        End If

    End Sub

    'Muestra o oculta los articulos con escandallo.
    Public Sub materiasPrimas()

        totalCoste = 0

        If lvEscandallosySubescandallos.Items.Count > 0 Then

            For Each item In lvEscandallosySubescandallos.Items

                If item.text = "" Then

                    If ckMateriasPrimas.Checked Then

                        item.remove()

                    End If

                Else

                    If item.Subitems(12).text <> "MP" Then

                        If ckMateriasPrimas.Checked Then

                            item.remove()

                        End If

                    Else

                        totalCoste = totalCoste + FormatNumber(item.Subitems(10).Text, 4)

                    End If

                End If

            Next

        End If

        txCosteTotal.Text = FormatNumber(totalCoste, 4) & "€"

    End Sub
    'Muestra o oculta los articulos con escandallo.
    Public Sub materiasPrimasCoste()

        totalCoste = 0

        If lvEscandallosySubescandallos.Items.Count > 0 Then

            For Each item In lvEscandallosySubescandallos.Items

                If item.text = "" Then

                    If ckMateriasPrimas.Checked Then

                        item.remove()

                    End If

                Else

                    If item.Subitems(2).text <> "MP" Then

                        If ckMateriasPrimas.Checked Then

                            item.remove()

                        End If

                    Else

                        totalCoste = totalCoste + FormatNumber(item.Subitems(1).Text, 4)

                    End If

                End If

            Next

        End If

        txCosteTotal.Text = FormatNumber(totalCoste, 4) & "€"

    End Sub

    'Orden de columnas
    Private Sub ListView1_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
        Handles lvEscandallosySubescandallos.ColumnClick

        If ckMateriasPrimas.Checked Then

            If lvEscandallosySubescandallos.Items.Count <> 0 Then
                'Si columna actual es igual a la última columna seleccionada. Formatea la variable con el orden de búsqueda anterio. 
                If e.Column = numColumna Then
                    lvEscandallosySubescandallos.Sorting = colOrder
                End If
                ' Crear una instancia de la clase que realizará la comparación
                Dim oCompare As New ListViewColumnSort()
                ' Asignar el orden de clasificación
                If lvEscandallosySubescandallos.Sorting = Windows.Forms.SortOrder.Ascending Then
                    oCompare.Sorting = Windows.Forms.SortOrder.Descending
                Else
                    oCompare.Sorting = Windows.Forms.SortOrder.Ascending
                End If
                lvEscandallosySubescandallos.Sorting = oCompare.Sorting
                ' La columna en la que se ha pulsado
                oCompare.ColumnIndex = e.Column
                ' El tipo de datos de la columna en la que se ha pulsado
                Select Case e.Column
                    Case 0
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 1
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 2
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 3
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 4
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 5
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 6
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 7
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 8
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 9
                        'oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 10
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 11
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 12
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                End Select
                lvEscandallosySubescandallos.ListViewItemSorter = oCompare
                numColumna = e.Column
                colOrder = oCompare.Sorting
            End If

        End If

    End Sub

    'Imprime el listado.
    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click

        imprimir()
        
    End Sub

    Private Sub imprimir()

        Dim ds As New materiasPrimasEscandallos()

        Dim rowDatosEscandallo As materiasPrimasEscandallos.EscandalloDTRow = ds.EscandalloDT.NewEscandalloDTRow()

        rowDatosEscandallo.IdEscandallo = txIdEscandallo.Text
        rowDatosEscandallo.Nombre = txEscandallo.Text
        rowDatosEscandallo.Precio = txCosteTotal.Text
        rowDatosEscandallo.Version = txVersion.Text
        rowDatosEscandallo.Fecha = Now

        ds.EscandalloDT.AddEscandalloDTRow(rowDatosEscandallo)

        For Each item In lvEscandallosySubescandallos.Items

            Dim rowDatosMateriasPrimas As materiasPrimasEscandallos.tablaMateriasPrimasRow = ds.tablaMateriasPrimas.NewtablaMateriasPrimasRow()

            rowDatosMateriasPrimas.Id = item.text
            rowDatosMateriasPrimas.IdArticulo = item.SubItems(1).Text
            rowDatosMateriasPrimas.IdEscandallo = item.SubItems(2).Text
            rowDatosMateriasPrimas.IdSubescandallo = item.SubItems(3).Text
            rowDatosMateriasPrimas.Articulo = item.SubItems(4).Text
            rowDatosMateriasPrimas.Familia = item.SubItems(5).Text
            rowDatosMateriasPrimas.Subfamilia = item.SubItems(6).Text
            rowDatosMateriasPrimas.Seccion = item.SubItems(7).Text
            rowDatosMateriasPrimas.Cantidad = item.SubItems(8).Text
            rowDatosMateriasPrimas.Unidad = item.SubItems(9).Text
            rowDatosMateriasPrimas.Precio = item.SubItems(10).Text
            rowDatosMateriasPrimas.Moneda = item.SubItems(11).Text
            rowDatosMateriasPrimas.ColorFondo = item.SubItems(13).Text
            rowDatosMateriasPrimas.ColorLetra = item.SubItems(14).Text

            ds.tablaMateriasPrimas.AddtablaMateriasPrimasRow(rowDatosMateriasPrimas)

        Next

        Dim gg As New InformeEscandalloMateriasPrimas

        gg.tituloInforme = tituloInforme

        gg.ruta = ruta

        gg.idEscandallo = idescandallo

        gg.exportar = exportacionMasiva

        gg.ocultarCostes = coste

        gg.verInforme(ds)

        If exportacionMasiva = False Then

            gg.ShowDialog()

        End If
    End Sub

    'Muestra la gestion del artículo.
    Private Sub lvEscandallosySubescandallos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvEscandallosySubescandallos.DoubleClick

        If lvEscandallosySubescandallos.SelectedItems.Count > 0 Then

            Dim gg As New GestionArticulo

            With lvEscandallosySubescandallos

                For Each item In .SelectedItems

                    gg.idArticulo.Text = item.SubItems(1).Text

                Next

            End With

            gg.ShowDialog()

        End If


    End Sub

    'Public Function llenarLv2(ByVal id As Integer) As Boolean

    '    Dim i As Integer = 0

    '    idActual = id

    '    Dim lista0 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 0) 'Lista de nivel 0

    '    If lista0 Is Nothing Then

    '        Return True

    '    End If

    '    Dim lista1 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 1) 'Lista de nivel 1

    '    Dim lista2 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 2) 'Lista de nivel 2

    '    Dim lista3 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 3) 'Lista de nivel 3

    '    Dim lista4 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 4) 'Lista de nivel 4

    '    Dim lista5 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 5) 'Lista de nivel 5

    '    Dim lista6 As List(Of DatosEscandallo) = funcES.EscandallosSubescandallos(id, 6) 'Lista de nivel 6

    '    Dim color0 As Boolean

    '    Dim color1 As Boolean

    '    Dim color2 As Boolean

    '    Dim color3 As Boolean

    '    Dim color4 As Boolean

    '    Dim color5 As Boolean

    '    Try

    '        Dim dts0 As DatosEscandallo

    '        If lista0.Count = 0 Then

    '            Return True

    '        Else

    '            For Each dts0 In lista0 'Introducimos los conceptos de escandallo de nivel 0.

    '                If dts0.gLevel = i Then

    '                    lvEscandallosySubescandallos.ForeColor = Color.Black

    '                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts0.gLevel)

    '                        .SubItems.Add(dts0.gidArticulo)

    '                        .SubItems.Add(dts0.gidEscandallo)

    '                        .SubItems.Add(dts0.gcodArticulo)

    '                        .SubItems.Add(dts0.gArticulo)

    '                        .SubItems.Add(dts0.gFamilia)

    '                        .SubItems.Add(If(dts0.gSubfamilia = "", " ", dts0.gSubfamilia))

    '                        .SubItems.Add(dts0.gseccion)

    '                        .SubItems.Add(FormatNumber(dts0.gCantidad, 4))

    '                        .SubItems.Add(dts0.gTipoUnidad)

    '                        .SubItems.Add(FormatNumber(dts0.gCoste * dts0.gCantidad, 4))

    '                        .SubItems.Add(dts0.gSimbolo)

    '                        .SubItems.Add("MP")

    '                        .SubItems.Add("White")

    '                        .SubItems.Add("Black")

    '                    End With

    '                    Dim dts1 As DatosEscandallo

    '                    If lista1.Count = 0 Then

    '                    Else

    '                        For Each dts1 In lista1 'Introducimos los conceptos de escandallo de nivel 1.

    '                            If dts1.gcodArticulo = dts0.gidArticulo Then

    '                                Label1.Visible = True

    '                                If color0 = False Then

    '                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkGreen

    '                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

    '                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

    '                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkGreen"

    '                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

    '                                    color0 = True

    '                                End If

    '                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts1.gLevel)

    '                                    dts1.gCantidad = dts1.gCantidad * dts0.gCantidad

    '                                    .SubItems.Add(dts1.gidArticulo)

    '                                    .SubItems.Add(dts1.gidEscandallo)

    '                                    .SubItems.Add(dts1.gcodArticulo)

    '                                    .SubItems.Add(dts1.gArticulo)

    '                                    .SubItems.Add(dts1.gFamilia)

    '                                    .SubItems.Add(If(dts1.gSubfamilia = "", " ", dts1.gSubfamilia))

    '                                    .SubItems.Add(dts1.gseccion)

    '                                    .SubItems.Add(FormatNumber(dts1.gCantidad, 4))

    '                                    .SubItems.Add(dts1.gTipoUnidad)

    '                                    .SubItems.Add(FormatNumber(dts1.gCoste * dts1.gCantidad, 4))

    '                                    .SubItems.Add(dts1.gSimbolo)

    '                                    .SubItems.Add("MP")

    '                                    .SubItems.Add("White")

    '                                    .SubItems.Add("DarkGreen")

    '                                End With

    '                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkGreen

    '                                Dim dts2 As DatosEscandallo

    '                                If lista2.Count = 0 Then

    '                                Else

    '                                    For Each dts2 In lista2 'Introducimos los conceptos de escandallo de nivel 2.

    '                                        If dts2.gcodArticulo = dts1.gidArticulo Then

    '                                            Label2.Visible = True

    '                                            If color1 = False Then

    '                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkOrange

    '                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

    '                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

    '                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkOrange"

    '                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

    '                                                color1 = True

    '                                            End If

    '                                            With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts2.gLevel)

    '                                                dts2.gCantidad = dts2.gCantidad * dts1.gCantidad

    '                                                .SubItems.Add(dts2.gidArticulo)

    '                                                .SubItems.Add(dts2.gidEscandallo)

    '                                                .SubItems.Add(dts2.gcodArticulo)

    '                                                .SubItems.Add(dts2.gArticulo)

    '                                                .SubItems.Add(dts2.gFamilia)

    '                                                .SubItems.Add(If(dts2.gSubfamilia = "", " ", dts2.gSubfamilia))

    '                                                .SubItems.Add(dts2.gseccion)

    '                                                .SubItems.Add(FormatNumber(dts2.gCantidad, 4))

    '                                                .SubItems.Add(dts2.gTipoUnidad)

    '                                                .SubItems.Add(FormatNumber(dts2.gCoste * dts2.gCantidad, 4))

    '                                                .SubItems.Add(dts2.gSimbolo)

    '                                                .SubItems.Add("MP")

    '                                                .SubItems.Add("White")

    '                                                .SubItems.Add("DarkOrange")

    '                                            End With

    '                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkOrange

    '                                            Dim dts3 As DatosEscandallo

    '                                            If lista3.Count = 0 Then

    '                                            Else

    '                                                For Each dts3 In lista3 'Introducimos los conceptos de escandallo de nivel 3.

    '                                                    If dts3.gcodArticulo = dts2.gidArticulo Then

    '                                                        Label3.Visible = True

    '                                                        If color2 = False Then

    '                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkRed

    '                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

    '                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

    '                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkRed"

    '                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

    '                                                            color2 = True

    '                                                        End If

    '                                                        With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts3.gLevel)

    '                                                            dts3.gCantidad = dts3.gCantidad * dts2.gCantidad

    '                                                            .SubItems.Add(dts3.gidArticulo)

    '                                                            .SubItems.Add(dts3.gidEscandallo)

    '                                                            .SubItems.Add(dts3.gcodArticulo)

    '                                                            .SubItems.Add(dts3.gArticulo)

    '                                                            .SubItems.Add(dts3.gFamilia)

    '                                                            .SubItems.Add(If(dts3.gSubfamilia = "", " ", dts3.gSubfamilia))

    '                                                            .SubItems.Add(dts3.gseccion)

    '                                                            .SubItems.Add(FormatNumber(dts3.gCantidad, 4))

    '                                                            .SubItems.Add(dts3.gTipoUnidad)

    '                                                            .SubItems.Add(FormatNumber(dts3.gCoste * dts3.gCantidad, 4))

    '                                                            .SubItems.Add(dts3.gSimbolo)

    '                                                            .SubItems.Add("MP")

    '                                                            .SubItems.Add("White")

    '                                                            .SubItems.Add("DarkRed")

    '                                                        End With

    '                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkRed

    '                                                        Dim dts4 As DatosEscandallo

    '                                                        If lista4.Count = 0 Then

    '                                                        Else

    '                                                            For Each dts4 In lista4 'Introducimos los conceptos de escandallo de nivel 4.

    '                                                                If dts4.gcodArticulo = dts3.gidArticulo Then

    '                                                                    Label4.Visible = True

    '                                                                    If color3 = False Then

    '                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.DarkBlue

    '                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

    '                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

    '                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "DarkBlue"

    '                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

    '                                                                        color3 = True

    '                                                                    End If

    '                                                                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts4.gLevel)

    '                                                                        dts4.gCantidad = dts4.gCantidad * dts3.gCantidad

    '                                                                        .SubItems.Add(dts4.gidArticulo)

    '                                                                        .SubItems.Add(dts4.gidEscandallo)

    '                                                                        .SubItems.Add(dts4.gcodArticulo)

    '                                                                        .SubItems.Add(dts4.gArticulo)

    '                                                                        .SubItems.Add(dts4.gFamilia)

    '                                                                        .SubItems.Add(If(dts4.gSubfamilia = "", " ", dts4.gSubfamilia))

    '                                                                        .SubItems.Add(dts4.gseccion)

    '                                                                        .SubItems.Add(FormatNumber(dts4.gCantidad, 4))

    '                                                                        .SubItems.Add(dts4.gTipoUnidad)

    '                                                                        .SubItems.Add(FormatNumber(dts4.gCoste * dts4.gCantidad, 4))

    '                                                                        .SubItems.Add(dts4.gSimbolo)

    '                                                                        .SubItems.Add("MP")

    '                                                                        .SubItems.Add("White")

    '                                                                        .SubItems.Add("DarkBlue")

    '                                                                    End With

    '                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkBlue

    '                                                                    Dim dts5 As DatosEscandallo

    '                                                                    If lista5.Count = 0 Then

    '                                                                    Else

    '                                                                        For Each dts5 In lista5 'Introducimos los conceptos de escandallo de nivel 4.

    '                                                                            If dts5.gcodArticulo = dts4.gidArticulo Then

    '                                                                                Label5.Visible = True

    '                                                                                If color4 = False Then

    '                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.Purple

    '                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

    '                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

    '                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "Purple"

    '                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

    '                                                                                    color4 = True

    '                                                                                End If

    '                                                                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts5.gLevel)

    '                                                                                    dts5.gCantidad = dts5.gCantidad * dts4.gCantidad

    '                                                                                    .SubItems.Add(dts5.gidArticulo)

    '                                                                                    .SubItems.Add(dts5.gidEscandallo)

    '                                                                                    .SubItems.Add(dts5.gcodArticulo)

    '                                                                                    .SubItems.Add(dts5.gArticulo)

    '                                                                                    .SubItems.Add(dts5.gFamilia)

    '                                                                                    .SubItems.Add(If(dts5.gSubfamilia = "", " ", dts5.gSubfamilia))

    '                                                                                    .SubItems.Add(dts5.gseccion)

    '                                                                                    .SubItems.Add(FormatNumber(dts5.gCantidad, 4))

    '                                                                                    .SubItems.Add(dts5.gTipoUnidad)

    '                                                                                    .SubItems.Add(FormatNumber(dts5.gCoste * dts5.gCantidad, 4))

    '                                                                                    .SubItems.Add(dts5.gSimbolo)

    '                                                                                    .SubItems.Add("MP")

    '                                                                                    .SubItems.Add("White")

    '                                                                                    .SubItems.Add("Purple")

    '                                                                                End With

    '                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.Purple

    '                                                                                Dim dts6 As DatosEscandallo

    '                                                                                If lista6.Count = 0 Then

    '                                                                                Else

    '                                                                                    For Each dts6 In lista6 'Introducimos los conceptos de escandallo de nivel 4.

    '                                                                                        If dts6.gcodArticulo = dts5.gidArticulo Then

    '                                                                                            Label6.Visible = True

    '                                                                                            If color5 = False Then

    '                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).BackColor = Color.Red

    '                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.White

    '                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(12).Text = "ESC"

    '                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(13).Text = "Red"

    '                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(14).Text = "White"

    '                                                                                                color5 = True

    '                                                                                            End If

    '                                                                                            With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts6.gLevel)

    '                                                                                                dts6.gCantidad = dts6.gCantidad * dts5.gCantidad

    '                                                                                                .SubItems.Add(dts6.gidArticulo)

    '                                                                                                .SubItems.Add(dts6.gidEscandallo)

    '                                                                                                .SubItems.Add(dts6.gcodArticulo)

    '                                                                                                .SubItems.Add(dts6.gArticulo)

    '                                                                                                .SubItems.Add(dts6.gFamilia)

    '                                                                                                .SubItems.Add(If(dts6.gSubfamilia = "", " ", dts6.gSubfamilia))

    '                                                                                                .SubItems.Add(dts6.gseccion)

    '                                                                                                .SubItems.Add(FormatNumber(dts6.gCantidad, 4))

    '                                                                                                .SubItems.Add(dts6.gTipoUnidad)

    '                                                                                                .SubItems.Add(FormatNumber(dts6.gCoste * dts6.gCantidad, 4))

    '                                                                                                .SubItems.Add(dts6.gSimbolo)

    '                                                                                                .SubItems.Add("MP")

    '                                                                                                .SubItems.Add("White")

    '                                                                                                .SubItems.Add("Red")

    '                                                                                            End With

    '                                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.Red

    '                                                                                        End If

    '                                                                                    Next

    '                                                                                    color5 = False

    '                                                                                End If

    '                                                                            End If

    '                                                                        Next

    '                                                                        color4 = False

    '                                                                    End If

    '                                                                End If

    '                                                            Next

    '                                                            color3 = False

    '                                                        End If

    '                                                    End If

    '                                                Next

    '                                                color2 = False

    '                                            End If


    '                                        End If

    '                                    Next

    '                                    color1 = False

    '                                End If

    '                            End If

    '                        Next

    '                        color0 = False

    '                    End If

    '                End If

    '            Next

    '            materiasPrimas()

    '            Return True

    '        End If

    '    Catch ex As Exception

    '        MsgBox(ex.Message)

    '        Return True

    '    End Try

    'End Function

    Public Function calcularCosteArticulo(ByVal id As Integer) As Boolean

        Dim i As Integer = 0

        idActual = id

        Dim lista0 As List(Of DatosEscandallo) = funcES.calcularPrecioTotal(id, 0) 'Lista de nivel 0

        If lista0 Is Nothing Then

            Return True

        End If

        Dim lista1 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 1
        Dim lista2 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 2
        Dim lista3 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 3
        Dim lista4 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 4
        Dim lista5 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 5
        Dim lista6 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 6
        Dim lista7 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 7
        Dim lista8 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 8
        Dim lista9 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 9
        Dim lista10 As List(Of DatosEscandallo) = Nothing 'Lista de nivel 10


        lista1 = funcES.calcularPrecioTotal(id, 1) 'Lista de nivel 1
        
        If lista1 Is Nothing Then
        Else

            lista2 = funcES.calcularPrecioTotal(id, 2) 'Lista de nivel 2

            If lista2 Is Nothing Or lista2.Count = 0 Then
            Else

                lista3 = funcES.calcularPrecioTotal(id, 3) 'Lista de nivel 3

                If lista3 Is Nothing Or lista3.Count = 0 Then
                Else

                    lista4 = funcES.calcularPrecioTotal(id, 4) 'Lista de nivel 4

                    If lista4 Is Nothing Or lista4.Count = 0 Then

                    Else

                        lista5 = funcES.calcularPrecioTotal(id, 5) 'Lista de nivel 5

                        If lista5 Is Nothing Or lista5.Count = 0 Then

                        Else

                            lista6 = funcES.calcularPrecioTotal(id, 6) 'Lista de nivel 5

                            If lista6 Is Nothing Or lista6.Count = 0 Then

                            Else

                                lista7 = funcES.calcularPrecioTotal(id, 7) 'Lista de nivel 5

                                If lista7 Is Nothing Or lista7.Count = 0 Then

                                Else

                                    lista8 = funcES.calcularPrecioTotal(id, 8) 'Lista de nivel 5

                                    If lista8 Is Nothing Or lista8.Count = 0 Then

                                    Else

                                        lista9 = funcES.calcularPrecioTotal(id, 9) 'Lista de nivel 5

                                        If lista9 Is Nothing Or lista9.Count = 0 Then

                                        Else
                                            lista10 = funcES.calcularPrecioTotal(id, 10) 'Lista de nivel 5

                                            If lista10 Is Nothing Or lista10.Count = 0 Then

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End If

        Dim color0 As Boolean

        Dim color1 As Boolean

        Dim color2 As Boolean

        Dim color3 As Boolean

        Dim color4 As Boolean

        Dim color5 As Boolean

        Dim color6 As Boolean

        Dim color7 As Boolean

        Dim color8 As Boolean

        Dim color9 As Boolean

        Try

            Dim dts0 As DatosEscandallo

            If lista0.Count = 0 Then

                Return True

            Else

                For Each dts0 In lista0 'Introducimos los conceptos de escandallo de nivel 0.

                    If dts0.gLevel = i Then

                        lvEscandallosySubescandallos.ForeColor = Color.Black

                        With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts0.gLevel)

                            .SubItems.Add(FormatNumber(dts0.gCoste * dts0.gCantidad, 4))

                            .SubItems.Add("MP")

                            .SubItems.Add("White")

                            .SubItems.Add("Black")

                        End With

                        Dim dts1 As DatosEscandallo

                        If lista1.Count = 0 Then

                        Else

                            For Each dts1 In lista1 'Introducimos los conceptos de escandallo de nivel 1.

                                If dts1.gcodArticulo = dts0.gidArticulo Then

                                    Label1.Visible = True

                                    If color0 = False Then

                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(2).Text = "ESC"

                                        color0 = True

                                    End If

                                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts1.gLevel)

                                        dts1.gCantidad = dts1.gCantidad * dts0.gCantidad

                                        .SubItems.Add(FormatNumber(dts1.gCoste * dts1.gCantidad, 4))

                                        .SubItems.Add("MP")

                                        .SubItems.Add("White")

                                        .SubItems.Add("Black")

                                    End With

                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).ForeColor = Color.DarkGreen

                                    Dim dts2 As DatosEscandallo

                                    If lista2.Count = 0 Then

                                    Else

                                        For Each dts2 In lista2 'Introducimos los conceptos de escandallo de nivel 2.

                                            If dts2.gcodArticulo = dts1.gidArticulo Then

                                                Label2.Visible = True

                                                If color1 = False Then

                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(2).Text = "ESC"

                                                    color1 = True

                                                End If

                                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts2.gLevel)

                                                    dts2.gCantidad = dts2.gCantidad * dts1.gCantidad

                                                    .SubItems.Add(FormatNumber(dts2.gCoste * dts2.gCantidad, 4))

                                                    .SubItems.Add("MP")

                                                    .SubItems.Add("White")

                                                    .SubItems.Add("Black")
                                                End With

                                                Dim dts3 As DatosEscandallo

                                                If lista3.Count = 0 Then

                                                Else

                                                    For Each dts3 In lista3 'Introducimos los conceptos de escandallo de nivel 3.

                                                        If dts3.gcodArticulo = dts2.gidArticulo Then

                                                            Label3.Visible = True

                                                            If color2 = False Then

                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(2).Text = "ESC"

                                                                color2 = True

                                                            End If

                                                            With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts3.gLevel)

                                                                dts3.gCantidad = dts3.gCantidad * dts2.gCantidad

                                                                .SubItems.Add(FormatNumber(dts3.gCoste * dts3.gCantidad, 4))

                                                                .SubItems.Add("MP")

                                                                .SubItems.Add("White")

                                                                .SubItems.Add("Black")

                                                            End With

                                                            Dim dts4 As DatosEscandallo

                                                            If lista4.Count = 0 Then

                                                            Else

                                                                For Each dts4 In lista4 'Introducimos los conceptos de escandallo de nivel 4.

                                                                    If dts4.gcodArticulo = dts3.gidArticulo Then

                                                                        Label4.Visible = True

                                                                        If color3 = False Then

                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(2).Text = "ESC"

                                                                            color3 = True

                                                                        End If

                                                                        With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts4.gLevel)

                                                                            dts4.gCantidad = dts4.gCantidad * dts3.gCantidad

                                                                            .SubItems.Add(FormatNumber(dts4.gCoste * dts4.gCantidad, 4))

                                                                            .SubItems.Add("MP")

                                                                            .SubItems.Add("White")

                                                                            .SubItems.Add("Black")

                                                                        End With

                                                                        Dim dts5 As DatosEscandallo

                                                                        If lista5.Count = 0 Then

                                                                        Else

                                                                            For Each dts5 In lista5 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                If dts5.gcodArticulo = dts4.gidArticulo Then

                                                                                    Label5.Visible = True

                                                                                    If color4 = False Then

                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(3).Text = "ESC"

                                                                                        color4 = True

                                                                                    End If

                                                                                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts5.gLevel)

                                                                                        dts5.gCantidad = dts5.gCantidad * dts4.gCantidad

                                                                                        .SubItems.Add(FormatNumber(dts5.gCoste * dts5.gCantidad, 4))

                                                                                        .SubItems.Add("MP")

                                                                                        .SubItems.Add("White")

                                                                                        .SubItems.Add("Black")

                                                                                    End With

                                                                                    Dim dts6 As DatosEscandallo

                                                                                    If lista6.Count = 0 Then

                                                                                    Else

                                                                                        For Each dts6 In lista6 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                            If dts6.gcodArticulo = dts5.gidArticulo Then

                                                                                                Label6.Visible = True

                                                                                                If color5 = False Then

                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(3).Text = "ESC"

                                                                                                    color5 = True

                                                                                                End If

                                                                                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts6.gLevel)

                                                                                                    dts6.gCantidad = dts6.gCantidad * dts5.gCantidad

                                                                                                    .SubItems.Add(FormatNumber(dts6.gCoste * dts6.gCantidad, 4))

                                                                                                    .SubItems.Add("MP")

                                                                                                    .SubItems.Add("White")

                                                                                                    .SubItems.Add("Black")

                                                                                                End With

                                                                                                Dim dts7 As DatosEscandallo

                                                                                                If lista7.Count = 0 Then

                                                                                                Else

                                                                                                    For Each dts7 In lista7 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                                        If dts7.gcodArticulo = dts6.gidArticulo Then



                                                                                                            If color6 = False Then

                                                                                                                lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(3).Text = "ESC"

                                                                                                                color6 = True

                                                                                                            End If

                                                                                                            With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts7.gLevel)

                                                                                                                dts7.gCantidad = dts7.gCantidad * dts6.gCantidad

                                                                                                                .SubItems.Add(FormatNumber(dts7.gCoste * dts7.gCantidad, 4))

                                                                                                                .SubItems.Add("MP")

                                                                                                                .SubItems.Add("White")

                                                                                                                .SubItems.Add("Black")

                                                                                                            End With

                                                                                                            Dim dts8 As DatosEscandallo

                                                                                                            If lista8.Count = 0 Then

                                                                                                            Else

                                                                                                                For Each dts8 In lista8 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                                                    If dts8.gcodArticulo = dts7.gidArticulo Then



                                                                                                                        If color7 = False Then

                                                                                                                            lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(3).Text = "ESC"

                                                                                                                            color7 = True

                                                                                                                        End If

                                                                                                                        With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts8.gLevel)

                                                                                                                            dts8.gCantidad = dts8.gCantidad * dts7.gCantidad

                                                                                                                            .SubItems.Add(FormatNumber(dts8.gCoste * dts8.gCantidad, 4))

                                                                                                                            .SubItems.Add("MP")

                                                                                                                            .SubItems.Add("White")

                                                                                                                            .SubItems.Add("Black")

                                                                                                                        End With

                                                                                                                        Dim dts9 As DatosEscandallo

                                                                                                                        If lista9.Count = 0 Then

                                                                                                                        Else

                                                                                                                            For Each dts9 In lista9 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                                                                If dts9.gcodArticulo = dts8.gidArticulo Then



                                                                                                                                    If color8 = False Then

                                                                                                                                        lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(3).Text = "ESC"

                                                                                                                                        color8 = True

                                                                                                                                    End If

                                                                                                                                    With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts9.gLevel)

                                                                                                                                        dts9.gCantidad = dts9.gCantidad * dts8.gCantidad

                                                                                                                                        .SubItems.Add(FormatNumber(dts9.gCoste * dts9.gCantidad, 4))

                                                                                                                                        .SubItems.Add("MP")

                                                                                                                                        .SubItems.Add("White")

                                                                                                                                        .SubItems.Add("Black")

                                                                                                                                    End With

                                                                                                                                    Dim dts10 As DatosEscandallo

                                                                                                                                    If lista10.Count = 0 Then

                                                                                                                                    Else

                                                                                                                                        For Each dts10 In lista10 'Introducimos los conceptos de escandallo de nivel 4.

                                                                                                                                            If dts10.gcodArticulo = dts9.gidArticulo Then

                                                                                                                                                If color9 = False Then

                                                                                                                                                    lvEscandallosySubescandallos.Items(lvEscandallosySubescandallos.Items.Count - 1).SubItems(3).Text = "ESC"

                                                                                                                                                    color9 = True

                                                                                                                                                End If

                                                                                                                                                With lvEscandallosySubescandallos.Items.Add(dts0.gidEscandallo & dts6.gLevel)

                                                                                                                                                    dts10.gCantidad = dts10.gCantidad * dts9.gCantidad

                                                                                                                                                    .SubItems.Add(FormatNumber(dts10.gCoste * dts10.gCantidad, 4))

                                                                                                                                                    .SubItems.Add("MP")

                                                                                                                                                    .SubItems.Add("White")

                                                                                                                                                    .SubItems.Add("Black")

                                                                                                                                                End With

                                                                                                                                            End If

                                                                                                                                        Next

                                                                                                                                        color9 = False

                                                                                                                                    End If

                                                                                                                                End If

                                                                                                                            Next

                                                                                                                            color8 = False

                                                                                                                        End If



                                                                                                                    End If

                                                                                                                Next

                                                                                                                color7 = False

                                                                                                            End If

                                                                                                        End If

                                                                                                    Next

                                                                                                    color6 = False

                                                                                                End If

                                                                                            End If

                                                                                        Next

                                                                                        color5 = False

                                                                                    End If

                                                                                End If

                                                                            Next

                                                                            color4 = False

                                                                        End If

                                                                    End If

                                                                Next

                                                                color3 = False

                                                            End If

                                                        End If

                                                    Next

                                                    color2 = False

                                                End If


                                            End If

                                        Next

                                        color1 = False

                                    End If

                                End If

                            Next

                            color0 = False

                        End If

                    End If

                Next

                materiasPrimasCoste()

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return True

        End Try

    End Function

End Class