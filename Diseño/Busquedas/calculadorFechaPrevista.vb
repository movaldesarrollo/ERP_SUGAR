Public Class calculadorFechaPrevista

#Region "VARIABLES"

    Dim funcCP As New FuncionesConceptosPedidos
    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.
    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.
    Dim industrialesPosteriorFecha As Integer
    Dim domesticosPosteriorFecha As Integer
    Dim domesticos2PosteriorFecha As Integer
    Dim RecambiosPosteriorFecha As Integer

#End Region

#Region "CARGA Y CIERRE"

    Private Sub calculadorFechaPrevista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sizePantalla As New Size
        sizePantalla = Screen.PrimaryScreen.WorkingArea.Size
        Me.Height = sizePantalla.Height - 50
        Location = New Point(Location.X, 10)
        llenarlv()

    End Sub

#End Region

#Region "EVENTO"

    'Calcular fecha y días.
    Private Sub bCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCalcular.Click
        calcular()
    End Sub

    'Bloquear solo numerico.
    Private Sub tbDomesticos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDomesticos.KeyPress, tbIndustriales.KeyPress, tbDomestico2.KeyPress

        If IsNumeric(e.KeyChar) Then
        Else
            Select Case e.KeyChar

                Case ChrW(Keys.Enter)
                    calcular()
                Case ChrW(Keys.Back)

                Case Else
                    e.Handled = True
            End Select

        End If

    End Sub

    Private Sub tbDomesticos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDomesticos.TextChanged, tbIndustriales.TextChanged

        If IsNumeric(sender.Text) Then
        Else
            If sender.Name = "tbDomesticos" Then
                tbDomesticos.Text = ""
            ElseIf sender.Name = "tbIndustriales" Then
                tbIndustriales.Text = ""
            End If
        End If

    End Sub

    'Bloqueo solo read only.
    Private Sub tbReadOnly_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbDias.KeyPress, tbFecha.KeyPress

        e.Handled = True

    End Sub

    'Limpiar formulario.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        limpiar()
    End Sub

    'Salir del formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Close()
    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Sub limpiar()
        tbDomesticos.Text = ""
        tbDomestico2.Text = ""
        tbIndustriales.Text = ""
        tbDias.Text = ""
        tbFecha.Text = ""
        llenarlv()
    End Sub

    Function llenarlv() As Boolean

        lvPedidosProduccion.Items.Clear()

        lvPedidosProduccion.Sorting = SortOrder.None

        Dim domesticos As Integer
        Dim industriales As Integer
        Dim domesticos2 As Integer
        Dim Recambios As Integer
        Dim fecha As String = ""
        Dim i As Integer

        tbMaxDomesticos.Text = FormatNumber(funcCP.maxDomesticosDia(), 0)
        tbMaxIndustriales.Text = FormatNumber(funcCP.maxIndustrialesDia(), 0)
        tbMaxDomesticos2.Text = FormatNumber(funcCP.maxDomesticos2Dia(), 0)
        txMaxRecambios.Text = FormatNumber(funcCP.maxRecambiosXDia(), 0)

        Dim MaxDomesticos As Integer = tbMaxDomesticos.Text
        Dim MaxIndustriales As Integer = tbMaxIndustriales.Text
        Dim MaxDom2 As Integer = tbMaxDomesticos2.Text

        industrialesPosteriorFecha = 0
        domesticosPosteriorFecha = 0
        domesticos2PosteriorFecha = 0
        RecambiosPosteriorFecha = 0

        Try
            Dim dt As DataTable = funcCP.MostrarCalculadora()

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If fecha = Format(row("F.PRODUCCION"), "dd-MM-yyyy") Then
                        With lvPedidosProduccion.Items(i - 1)
                            Dim dom As Integer = .SubItems(4).Text
                            Dim dom2 As Integer = .SubItems(5).Text
                            Dim ind As Integer = .SubItems(6).Text
                            Dim rec As Integer = .SubItems(7).Text

                            Dim domSup As Integer = (FormatNumber(If(row("DOMESTICO") Is DBNull.Value, 0, row("DOMESTICO")), 0))
                            Dim dom2Sup As Integer = (FormatNumber(If(row("DOMESTICOS 2") Is DBNull.Value, 0, row("DOMESTICOS 2")), 0))
                            Dim indSup As Integer = (FormatNumber(If(row("INDUSTRIAL") Is DBNull.Value, 0, row("INDUSTRIAL")), 0))
                            Dim recamSup As Integer = (FormatNumber(If(row("RECAMBIOS") Is DBNull.Value, 0, row("RECAMBIOS")), 0))
                            .SubItems(1).Text = ""
                            .SubItems(2).Text = ""
                            .SubItems(3).Text = ""
                            .SubItems(4).Text = dom + domSup
                            .SubItems(5).Text = dom2 + dom2Sup
                            .SubItems(6).Text = ind + indSup
                            .SubItems(7).Text = rec + recamSup
                            .SubItems(8).Text = "" 'Recambios calculados

                            domesticos = domesticos + domSup
                            domesticos2 = domesticos2 + dom2Sup
                            industriales = industriales + indSup
                            Recambios = Recambios + recamSup

                            If lvPedidosProduccion.Items(i - 1).Text > Now Then
                                domesticosPosteriorFecha = domesticosPosteriorFecha + domSup
                                domesticos2PosteriorFecha = domesticos2PosteriorFecha + dom2Sup
                                industrialesPosteriorFecha = industrialesPosteriorFecha + indSup
                                RecambiosPosteriorFecha = RecambiosPosteriorFecha + recamSup
                            End If

                            If domSup > MaxDomesticos Or indSup > MaxIndustriales Or dom2Sup > MaxDom2 Then
                                .ForeColor = Color.Red
                            Else
                                .ForeColor = Color.Black
                            End If
                        End With
                    Else
                        i = i + 1
                        fecha = Format(row("F.PRODUCCION"), "dd-MM-yyyy")

                        With lvPedidosProduccion.Items.Add(row("F.PRODUCCION"))
                            Dim domSup As Integer = FormatNumber(If(row("DOMESTICO") Is DBNull.Value, 0, row("DOMESTICO")), 0)
                            Dim indSup As Integer = FormatNumber(If(row("INDUSTRIAL") Is DBNull.Value, 0, row("INDUSTRIAL")), 0)
                            Dim dom2Sup As Integer = FormatNumber(If(row("DOMESTICOS 2") Is DBNull.Value, 0, row("DOMESTICOS 2")), 0)
                            Dim recamSup As Integer = FormatNumber(If(row("RECAMBIOS") Is DBNull.Value, 0, row("RECAMBIOS")), 0)

                            .SubItems.Add("")
                            .SubItems.Add("")
                            .SubItems.Add("")
                            .SubItems.Add(domSup)
                            .SubItems.Add(dom2Sup)
                            .SubItems.Add(indSup)
                            .SubItems.Add(recamSup)
                            .SubItems.Add("")

                            domesticos = domesticos + domSup
                            industriales = industriales + indSup
                            domesticos2 = domesticos2 + dom2Sup
                            If fecha > Now Then
                                domesticosPosteriorFecha = domesticosPosteriorFecha + domSup
                                industrialesPosteriorFecha = industrialesPosteriorFecha + indSup
                                domesticos2PosteriorFecha = domesticos2PosteriorFecha + dom2Sup
                                RecambiosPosteriorFecha = RecambiosPosteriorFecha + recamSup
                            End If

                            If domSup > MaxDomesticos Or indSup > MaxIndustriales Or dom2Sup > MaxDom2 Then
                                .ForeColor = Color.Red
                            Else
                                .ForeColor = Color.Black
                            End If

                        End With
                    End If

                Next
            End If
            tbTotalDomesticos.Text = FormatNumber(domesticos, 0)
            tbTotalIndustriales.Text = FormatNumber(industriales, 0)
            tbTotalDom2.Text = FormatNumber(domesticos2, 0)
            tbTotalRecambios.Text = FormatNumber(Recambios, 0)
        Catch ex As Exception
            MsgBox("Error al llenar." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function
    Sub calcular()
        llenarlv()
        Dim d As Integer 'Domesticos
        Dim d2 As Integer 'Domesticos 2
        Dim i As Integer 'Industriales
        Dim r As Integer 'Recambios
        Dim lab As Integer 'Laborables
        Dim totalDias As Integer 'Totaldias
        Dim domDia As Integer = funcCP.maxDomesticosDia()
        Dim indDia As Integer = funcCP.maxIndustrialesDia()
        Dim dom2Dia As Integer = funcCP.maxDomesticos2Dia()
        Dim recambiosDia As Integer = funcCP.maxRecambiosXDia()
        If ckSabados.Checked Then
            lab = 6
        Else
            lab = 5
        End If
        d = If(tbDomesticos.Text = "", 0, tbDomesticos.Text)
        Dim calcD As Integer = d
        For Each item In lvPedidosProduccion.Items
            Dim int As Integer = item.SubItems(5).text
            Dim fechaProduccion As Date = item.text
            If fechaProduccion > Now Then
                If int < domDia And calcD > 0 Then
                    int = domDia - int
                    If int >= calcD Then
                        item.SubItems(1).text = calcD
                        calcD = 0
                    Else
                        item.SubItems(1).text = calcD - (calcD - int)
                        calcD = calcD - item.SubItems(1).text
                    End If
                End If
            End If
        Next
        d2 = If(tbDomestico2.Text = "", 0, tbDomestico2.Text)
        Dim calcD2 As Integer = d2
        For Each item In lvPedidosProduccion.Items
            Dim int As Integer = item.SubItems(6).text

            Dim fechaProduccion As Date = item.text

            If fechaProduccion > Now Then

                If int < dom2Dia And calcD2 > 0 Then
                    int = dom2Dia - int
                    If int >= calcD2 Then
                        item.SubItems(2).text = calcD2
                        calcD2 = 0
                    Else
                        item.SubItems(2).text = calcD2 - (calcD2 - int)
                        calcD2 = calcD2 - item.SubItems(2).text
                    End If
                End If
            End If
        Next
        i = If(tbIndustriales.Text = "", 0, tbIndustriales.Text)
        Dim calcI As Integer = i
        For Each item In lvPedidosProduccion.Items
            Dim fechaProduccion As Date = item.text
            If fechaProduccion > Now Then
                Dim int As Integer = If(item.SubItems(7).text = "", 0, item.SubItems(7).text)
                If int < indDia And calcI > 0 Then
                    int = indDia - int
                    If int >= calcI Then
                        item.SubItems(3).text = calcI
                        calcI = 0
                    Else
                        item.SubItems(3).text = calcI - (calcI - int)
                        calcI = calcI - item.SubItems(3).text
                    End If
                End If
            End If
        Next
        r = If(tbRecambios.Text = "", 0, tbRecambios.Text)
        Dim calcR As Integer = r
        For Each item In lvPedidosProduccion.Items
            Dim fechaProduccion As Date = item.text
            If fechaProduccion > Now Then
                Dim int As Integer = If(item.SubItems(8).text = "", 0, item.SubItems(8).text)
                If int < recambiosDia And calcR > 0 Then
                    int = indDia - int
                    If int >= calcR Then
                        item.SubItems(4).text = calcI
                        calcR = 0
                    Else
                        item.SubItems(4).text = calcI - (calcI - int)
                        calcR = calcR - item.SubItems(4).text
                    End If
                End If
            End If
        Next


        totalDias = funcCP.calculadoraEquipos(domesticosPosteriorFecha + d, industrialesPosteriorFecha + i, domesticos2PosteriorFecha + d2, RecambiosPosteriorFecha + r)

        tbDias.Text = totalDias

        Dim incremento As Double = totalDias / lab

        incremento = Math.Round(incremento * 7)

        Dim fecha As Date = DateAdd(DateInterval.Day, incremento, Now())

        Select Case fecha.DayOfWeek

            Case 6

                incremento = incremento + 2

            Case 7

                incremento = incremento + 1

        End Select

        tbFecha.Text = Format(DateAdd(DateInterval.Day, incremento, Now()), "dddd, dd/MM/yyyy")

    End Sub

    'Orden de listview
    Private Sub ListView1_ColumnClick(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
            Handles lvPedidosProduccion.ColumnClick
        If lvPedidosProduccion.Items.Count <> 0 Then
            If e.Column = 13 Then
                lvPedidosProduccion.Sorting = Windows.Forms.SortOrder.None
            Else
                'Si columna actual es igual a la última columna seleccionada. Formatea la variable con el orden de búsqueda anterio. 
                If e.Column = numColumna Then
                    lvPedidosProduccion.Sorting = colOrder
                End If
                ' Crear una instancia de la clase que realizará la comparación
                Dim oCompare As New ListViewColumnSort()
                ' Asignar el orden de clasificación
                If lvPedidosProduccion.Sorting = Windows.Forms.SortOrder.Ascending Then
                    oCompare.Sorting = Windows.Forms.SortOrder.Descending
                Else
                    oCompare.Sorting = Windows.Forms.SortOrder.Ascending
                End If
                lvPedidosProduccion.Sorting = oCompare.Sorting
                ' La columna en la que se ha pulsado
                oCompare.ColumnIndex = e.Column
                ' El tipo de datos de la columna en la que se ha pulsado
                Select Case e.Column
                    Case 0
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                    Case 1
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 2
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 3
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 4
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 5
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 6
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 7
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 8
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                End Select
                'Elimina los items expandidos.
                'ReordenarExpandidos(True, False)
                ' Asignar la clase que implementa IComparer
                ' y que se usará para realizar la comparación de cada elemento

                lvPedidosProduccion.ListViewItemSorter = oCompare
                numColumna = e.Column
                colOrder = oCompare.Sorting
            End If
            'Vuelve a insertar los items expandidos.
            'ReordenarExpandidos(False, True)
        End If
    End Sub



#End Region

End Class