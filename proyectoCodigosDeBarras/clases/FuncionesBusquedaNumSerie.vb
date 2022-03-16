Imports System.Data.SqlClient
Public Class FuncionesBusquedaNumSerie

    Inherits conexion

#Region "VARIABLES"

    Dim con As New SqlConnection(CadenaConexion)
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Dim sel As String
    Dim idProducto As String = ""
    Dim producto As String = ""
    Dim productoNumSerie As String = ""

#End Region

#Region "FUNCIONES Y PROCEDIMIENTO"

    'Llena el listview
    Public Function llenarLV(ByVal form As busquedaNumSerie, ByVal sender As String) As Boolean

        Dim where As String = ""

        With form

            Select Case .tipoBusqueda

                Case "CD"
                    idProducto = "idCelula"
                    producto = "celulas"
                    productoNumSerie = "celNumserie"

                Case "CI"
                    idProducto = "idCelula"
                    producto = "celulasIndustriales"
                    productoNumSerie = "celIndNumserie"

                Case "ED"
                    idProducto = "idEquipo"
                    producto = "equipos"
                    productoNumSerie = "equNumserie"

                Case "EI"
                    idProducto = "idEquipo"
                    producto = "equiposIndustriales"
                    productoNumSerie = "equIndNumserie"

            End Select

            .lvProductos.Items.Clear()

            Try

                sel = "Select *,  codArticulo + ' - ' + Articulo  as ARTICULOS from " & producto & " PRO Left join articulos ART on ART.idArticulo = PRO.idArticulo "

                Select Case sender
                'Si es una busqueda de un código.
                    Case "txCode"

                        where = " where PRO." & productoNumSerie & " = '" & form.txCode.Text & "'"
                  'Si es una busqueda global.
                    Case "bBuscar"

                        If .cbProducto.SelectedIndex <> -1 Then

                            where = " where PRO.idArticulo = " & .cbProducto.SelectedValue

                        End If

                        If .rbEntreFechas.Checked Then

                            If where = "" Then

                                where = " where PRO.fechaFabricacion  between  '" & Format(.dtpDesde.Value, "dd/MM/yyyy") & "' and '" & Format(.dtpHasta.Value, "dd/MM/yyyy") & "' "

                            Else

                                where = where & " and  PRO.fechaFabricacion  between  '" & Format(.dtpDesde.Value, "dd/MM/yyyy") & "' and '" & Format(.dtpHasta.Value, "dd/MM/yyyy") & "' "

                            End If

                        Else

                            If .cbMeses.Text <> "" Then

                                If where = "" Then

                                    where = " where  DATENAME (MONTH, fechaFabricacion ) = '" & .cbMeses.SelectedItem & "' "

                                Else

                                    where = where & " and   DATENAME (MONTH, fechaFabricacion ) = '" & .cbMeses.SelectedItem & "' "

                                End If

                            End If

                            If .cbAños.Text <> "" Then

                                If where = "" Then

                                    where = " where  year(PRO.fechaFabricacion) = " & .cbAños.SelectedItem

                                Else

                                    where = where & " and  year(PRO.fechaFabricacion) = " & .cbAños.SelectedItem

                                End If

                            End If


                        End If

                        If .rbAsignados.Checked Then

                            If where = "" Then

                                where = " where numserie <> 0 "

                            Else

                                where = where & " and numserie <> 0 "

                            End If

                        ElseIf .rbNoAsignados.Checked Then

                            If where = "" Then

                                where = " where numserie = 0 "

                            Else

                                where = where & " and  numserie = 0 "

                            End If

                        End If

                        If .txCode.Text <> "" Then

                            If where = "" Then

                                where = " where  PRO." & productoNumSerie & " = '" & form.txCode.Text & "'"

                            Else

                                where = where & " and  PRO." & productoNumSerie & " = '" & form.txCode.Text & "'"

                            End If

                        End If

                End Select

                sel = sel & where

                dt = New DataTable

                da = New SqlDataAdapter(sel, con)

                con.Open()

                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    For Each row In dt.Rows

                        With .lvProductos.Items.Add(row(idProducto))

                            .Subitems.Add(row(productoNumSerie))
                            .Subitems.Add(row("fechaFabricacion"))
                            .SubItems.Add(row("ARTICULOS"))
                            .SubItems.Add(row("numSerie"))
                            If row("numSerie") <> 0 Then

                                .backcolor = Color.Green
                                .forecolor = Color.White

                            End If

                        End With

                    Next

                    form.iIdProducto = 0
                    form.numSerie = "0"
                    form.codigo = ""

                End If

                Dim total As Integer = .lvProductos.Items.Count

                .txTotal.Text = If(total = 0, "", (FormatNumber(total, 0)))

                con.Close()

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

            con.Close()

            Return False

        End With

    End Function

    'Llena el combo de meses
    Public Sub llenarComboMeses(ByVal form As busquedaNumSerie)

        Dim mes As Integer

        For mes = 1 To 12

            Dim fecha As DateTime = Convert.ToDateTime("16/" & mes & "/2010")

            form.cbMeses.Items.Add(UCase(MonthName(fecha.Month)))

        Next

    End Sub

    'Llena el combo de Años.
    Public Sub llenarComboAños(ByVal form As busquedaNumSerie, ByVal sProducto As String)

        Try
            sel = "Select distinct year(fechaFabricacion) AÑO from " & sProducto

            da = New SqlDataAdapter(sel, con)

            dt = New DataTable

            con.Open()

            da.Fill(dt)

            con.Close()

            If dt.Rows.Count > 0 Then

                For Each row In dt.Rows

                    form.cbAños.Items.Add(row("AÑO"))

                Next

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

    End Sub

    'Llena el combo de productos
    Public Function LlenarCombo(ByVal form As busquedaNumSerie) As Boolean

        Dim funCB As New funcionesCodigosBarras

        With form

            Try
                Select Case .tipoBusqueda

                    Case "CD"

                        funCB.buscarCelulas(.cbProducto)

                    Case "CI"

                        funCB.buscarCelulasIndustriales(.cbProducto)

                    Case "ED"

                        funCB.buscarEquipos(.cbProducto)

                    Case "EI"

                        funCB.buscarEquiposIndustriales(.cbProducto)

                End Select

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

        End With

        Return False

    End Function

    'Guardar 
    Public Function guardar(ByVal form As busquedaNumSerie) As Boolean

        With form

            Dim idProducto As String = ""
            Dim producto As String = ""
            Dim productoNumSerie As String = ""

            Select Case .tipoBusqueda

                Case "CD"
                    idProducto = "idCelula"
                    producto = "celulas"
                    productoNumSerie = "celNumserie"

                Case "CI"
                    idProducto = "idCelula"
                    producto = "celulasIndustriales"
                    productoNumSerie = "celIndNumserie"

                Case "ED"
                    idProducto = "idEquipo"
                    producto = "equipos"
                    productoNumSerie = "equNumserie"

                Case "EI"
                    idProducto = "idEquipo"
                    producto = "equiposIndustriales"
                    productoNumSerie = "equIndNumserie"

            End Select

            Try
                sel = "UPDATE " & producto & " SET idArticulo = " & .cbProducto.SelectedValue & " where " & idProducto & " = " & .iIdProducto

                cmd = New SqlCommand(sel, con)

                con.Open()

                cmd.ExecuteNonQuery()

                con.Close()

                Return True

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

            con.Close()

            Return False

        End With

    End Function

    'Borrar
    Public Function borrar(ByVal form As busquedaNumSerie) As Boolean

        Try

            Dim idProducto As String = ""
            Dim producto As String = ""
            Dim productoNumSerie As String = ""

            Select Case form.tipoBusqueda

                Case "CD"
                    idProducto = "idCelula"
                    producto = "celulas"
                    productoNumSerie = "celNumserie"

                Case "CI"
                    idProducto = "idCelula"
                    producto = "celulasIndustriales"
                    productoNumSerie = "celIndNumserie"

                Case "ED"
                    idProducto = "idEquipo"
                    producto = "equipos"
                    productoNumSerie = "equNumserie"

                Case "EI"
                    idProducto = "idEquipo"
                    producto = "equiposIndustriales"
                    productoNumSerie = "equIndNumserie"

            End Select

            sel = "delete " & producto & " where " & idProducto & " = " & form.iIdProducto

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

#End Region

End Class
