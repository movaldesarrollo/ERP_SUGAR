Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.IO

Public Class FuncionesCuadreStock
    Inherits conexion

#Region "VARIABLES"

    Dim con As New SqlConnection(CadenaConexion)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Dim sel As String
    Dim from As String
    Dim par As String
    Dim where As String
    Dim union As String
    Dim unionDom As String = "(select cel.idArticulo, e.numserie, e.fechaPicking, cel.celNumSerie as 'NUM SERIE HIJO', cel.fechaFabricacion
                              from EquiposProduccion e
                              inner join celulas cel  on  cel.numserie = e.numserie )
                              union
                              (select eq.idArticulo, e.numserie, e.fechaPicking, eq.EquNumSerie as 'NUM SERIE HIJO', eq.fechaFabricacion
                              from EquiposProduccion e
                              inner join Equipos eq on eq.numserie = e.numserie )"

    Dim unionIn As String = "(select eqi.idArticulo, e.numserie, e.fechaPicking, eqi.EquIndNumSerie as 'NUM SERIE HIJO', eqi.fechaFabricacion
                            from EquiposProduccion e 
                            inner join EquiposIndustriales eqi on eqi.numserie = e.numserie )
                            union
                            (select celi.idArticulo, e.numserie, e.fechaPicking, celi.celIndNumSerie as 'NUM SERIE HIJO', celi.fechaFabricacion
                            from EquiposProduccion e  
                            inner join celulasIndustriales celi on celi.numserie = e.numserie )"

    Dim unionBomba As String = "union (select b.idArticulo, e.numserie, e.fechaPicking, b.bomNumSerie 'NUM SERIE HIJO', b.fechaPreparacion
                                from EquiposProduccion e left join bombas b on b.numserie = e.numserie )"

#End Region

#Region "Llenar combo"

    Public Sub llenarCombo(ByVal combo As ComboBox, ByVal fecha As Date, ByVal hora As String, ByVal horaNext As String, ByVal domEq As Boolean, ByVal domCel As Boolean, ByVal inEq As Boolean, ByVal inCel As Boolean)
        dt = New DataTable
        Try
            Dim fechaHasta As Date

            If domEq Then
                from = "from Equipos"
            ElseIf domCel Then
                from = "from Celulas"
            ElseIf inEq Then
                from = "from EquiposIndustriales"
            ElseIf inCel Then
                from = "from celulasIndustriales"
            End If

            If hora = "" Then

                fechaHasta = DateAdd(DateInterval.Day, 1, fecha)

                where = "where e.fechaFabricacion between '" & fecha.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

            Else

                where = "where e.fechaFabricacion between '" & fecha.ToShortDateString & " " & hora & "' and '" & fecha.ToShortDateString & " " & horaNext & "'"

            End If

            sel = "select distinct( art.codArticulo ), e.idArticulo " & from & " e left join Articulos art on art.idArticulo = e.idArticulo " + where

            cmd = New SqlCommand(sel, con)
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)

            combo.DataSource = dt

            combo.DisplayMember = "codArticulo"
            combo.ValueMember = "idArticulo"
            combo.SelectedIndex = -1

        Catch ex As Exception

        End Try

    End Sub


    Public Sub llenarComboLogistica(ByVal combo As ComboBox, ByVal fecha As Date, ByVal hora As String, ByVal horaNext As String, ByVal cbDom As Boolean, ByVal cbInd As Boolean)
        dt = New DataTable
        Try
            Dim fechaHasta As Date

            If hora = "" Then

                fechaHasta = DateAdd(DateInterval.Day, 1, fecha)

                where = "where t.fechaPicking between '" & fecha.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

            Else

                where = "where t.fechaPicking between '" & fecha.ToShortDateString & " " & hora & "' and '" & fecha.ToShortDateString & " " & horaNext & "'"

            End If

            If cbDom And cbInd = False Then

                union = unionDom

            ElseIf cbInd And cbDom = False Then

                union = unionIn

            ElseIf cbDom And cbInd Then

                union = unionDom + " union " + unionIn

            End If

            sel = "select distinct(art.codArticulo),t.idArticulo from (" + union + ") t left join Articulos art on art.idArticulo = t.idArticulo " + where


            cmd = New SqlCommand(sel, con)
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)

            combo.DataSource = dt

            combo.DisplayMember = "codArticulo"
            combo.ValueMember = "idArticulo"
            combo.SelectedIndex = -1

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Llenar ListView"

    Public Sub llenarLv(ByVal lista As ListView, ByVal fechaDesde As Date, ByVal hasta As Date, ByVal hora As String, ByVal horaNext As String, ByVal idArticulo As Integer, ByVal domEq As Boolean, ByVal domCel As Boolean, ByVal inEq As Boolean, ByVal inCel As Boolean, ByVal rango As Boolean)

        dt = New DataTable()

        Try
            Dim fechaHasta As Date

            If domEq Then

                par = "EquNumSerie"

                from = "from Equipos e "

            ElseIf domCel Then

                par = "celNumSerie"

                from = "from Celulas e "

            ElseIf inEq Then

                par = "EquIndNumSerie"

                from = "from EquiposIndustriales e "

            ElseIf inCel Then

                par = "celIndNumSerie"

                from = "from celulasIndustriales e"

            End If

            If rango Then

                fechaHasta = DateAdd(DateInterval.Day, 1, hasta)

                where = "where e.fechaFabricacion between '" & fechaDesde.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"
            Else

                If hora = "" And idArticulo = 0 Then

                    fechaHasta = DateAdd(DateInterval.Day, 1, fechaDesde)

                    where = "where e.fechaFabricacion between '" & fechaDesde.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

                ElseIf idArticulo = 0 Then

                    where = "where e.fechaFabricacion between '" & fechaDesde.ToShortDateString & " " & hora & "' and '" & fechaDesde.ToShortDateString & " " & horaNext & "'"

                ElseIf hora = "" Then

                    fechaHasta = DateAdd(DateInterval.Day, 1, fechaDesde)

                    where = "where e.idArticulo='" & idArticulo & "' and e.fechaFabricacion between '" & fechaDesde.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

                Else

                    where = "where e.idArticulo='" & idArticulo & "' and e.fechaFabricacion between '" & fechaDesde.ToShortDateString & " " & hora & "' and '" & fechaDesde.ToShortDateString & " " & horaNext & "'"

                End If

            End If


            sel = "select e.idArticulo, art.codArticulo , e.numserie, e.fechaFabricacion, e." & par & " " & from &
                   " left join Articulos art on art.idArticulo = e.idArticulo " + where + " order by e.fechaFabricacion"

            cmd = New SqlCommand(sel, con)
            cmd.CommandTimeout = 100

            da = New SqlDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    With lista.Items.Add(row("idArticulo"))
                        .subitems.Add(row("codArticulo"))
                        .subitems.add(row("numserie"))
                        .subitems.add(row("fechaFabricacion"))
                        .subitems.add(row(par))
                    End With
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Public Sub llenarLvLogistica(ByVal lista As ListView, ByVal fecha As Date, ByVal hasta As Date, ByVal hora As String, ByVal horaNext As String, ByVal idArticulo As Integer, ByVal cbDom As Boolean, ByVal cbInd As Boolean, ByVal rango As Boolean)

        dt = New DataTable()

        Dim fechaHasta As Date

        Try

            If rango Then

                fechaHasta = DateAdd(DateInterval.Day, 1, hasta)

                where = "where t.fechaPicking between '" & fecha.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

            Else

                If hora = "" And idArticulo = 0 Then

                    fechaHasta = DateAdd(DateInterval.Day, 1, fecha)

                    where = "where t.fechaPicking between '" & fecha.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

                ElseIf idArticulo = 0 Then

                    where = "where t.fechaPicking between '" & fecha.ToShortDateString & " " & hora & "' and '" & fecha.ToShortDateString & " " & horaNext & "'"

                ElseIf hora = "" Then

                    fechaHasta = DateAdd(DateInterval.Day, 1, fecha)

                    where = "where t.idArticulo='" & idArticulo & "' and t.fechaPicking between '" & fecha.ToShortDateString & "' and '" & fechaHasta.ToShortDateString & "'"

                Else

                    where = "where t.idArticulo='" & idArticulo & "' and t.fechaPicking between '" & fecha.ToShortDateString & " " & hora & "' and '" & fecha.ToShortDateString & " " & horaNext & "'"

                End If
            End If


            If cbDom And cbInd = False Then

                union = unionDom

            ElseIf cbInd And cbDom = False Then

                union = unionIn

            ElseIf cbDom And cbInd Then

                union = unionDom + " union " + unionIn

            End If

            sel = "select t.idArticulo, case when art.codArticulo IS NULL then  'BOMBA' else  art.codArticulo end 'codArticulo', t.numSerie, t.[NUM SERIE HIJO], t.fechaFabricacion ,t.fechaPicking from (" + union + unionBomba + ")
                    t left join Articulos art on art.idArticulo = t.idArticulo " + where + "and numserie != 0  and t.idArticulo is not null order by t.fechaPicking"

            cmd = New SqlCommand(sel, con)
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    With lista.Items.Add(row("idArticulo"))
                        .subitems.Add(row("codArticulo"))
                        .subitems.add(row("numserie"))
                        .subitems.add(row("fechaFabricacion"))
                        .subitems.add(row("NUM SERIE HIJO"))
                        .subitems.add(If(row("fechaPicking") Is DBNull.Value, "", row("fechaPicking")))
                    End With
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

#Region "EXCEL"
    Public Sub crearExcel(ByVal lv As ListView, ByVal fecha As Date, ByVal hora As String, ByVal prbCargarExcel As ProgressBar)
        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer

            objExcel = New Excel.Application

            bkWorkBook = objExcel.Workbooks.Add

            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Range("A1:E1").Merge(True)
            shWorkSheet.Cells(1, 1).Value = "CUADRE DE STOCK"
            'shWorkSheet.Cells(2, 1).NumberFormat = "mm/dd/yyyy;@"
            shWorkSheet.Cells(2, 1).Value = DateTime.Parse(fecha.ToShortDateString + " " + hora)
            shWorkSheet.Range("A:E").ColumnWidth = 20
            shWorkSheet.Range("A:E").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            'shWorkSheet.Columns("C:C").NumberFormat = "mm/dd/yyyy hh:mm;@"
            'shWorkSheet.Columns("E:E").NumberFormat = "mm/dd/yyyy hh:mm;@"
            shWorkSheet.Rows(1).font.Color = Color.Black
            shWorkSheet.Rows(1).font.size = 15
            shWorkSheet.Rows(1).font.bold = True
            shWorkSheet.Rows(1).font.size = 15
            shWorkSheet.Rows(1).font.bold = True
            shWorkSheet.Rows(3).font.Color = Color.Black

            For i = 1 To lv.Columns.Count - 1

                shWorkSheet.Cells(3, i) = lv.Columns(i).Text

            Next

            For i = 1 To lv.Items.Count

                For j = 1 To lv.Columns.Count - 1


                    If j = 5 Or j = 3 Then

                        shWorkSheet.Cells(i + 3, j).Value = DateTime.Parse(lv.Items(i - 1).SubItems(j).Text)

                    Else

                        shWorkSheet.Cells(i + 3, j).Value = lv.Items(i - 1).SubItems(j).Text

                    End If


                    If prbCargarExcel.Value < prbCargarExcel.Maximum Then

                        prbCargarExcel.Value = prbCargarExcel.Value + 1

                    End If

                    Application.DoEvents()

                Next

            Next

            prbCargarExcel.Visible = False

            Dim sd As New SaveFileDialog

            sd.Filter = "XLSX | *.xlsx"

            If sd.ShowDialog = DialogResult.OK Then

                shWorkSheet.SaveAs(sd.FileName)

            End If

            bkWorkBook.Close()

        Catch ex As Exception

            prbCargarExcel.Visible = False

            MsgBox(ex.Message)

        End Try

    End Sub

#End Region

End Class
