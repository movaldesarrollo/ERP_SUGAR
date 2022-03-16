Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesConceptosAlbaranesProv

    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()

    Dim sel0 As String = "select CA.*, TipoUnidad,AP.codMoneda, Simbolo, AR.idUnidad, TipoUnidad, Estado, Familia, subFamilia,Articulo,codArticulo,AR.idFamilia, AR.idsubFamilia, " _
            & " CA.Cantidad * CA.PrecioNetoUnitario * (1-(CA.Descuento/100)) as TotalConcepto, AP.numAlbaran, CP.numPedido, AP.Fecha as FechaRecibido, TiposIVA.TipoIVA, TiposIVA.TipoRecargoEQ, TiposIVA.Nombre as NombreTipoIVA " _
            & " from ConceptosAlbaranesProv AS CA left join AlbaranesProv as AP ON AP.idAlbaran = CA.idAlbaran " _
            & " left join ConceptosPedidosProv as CP ON CP.idConcepto = CA.idConceptoPedidoProv " _
            & " left join Articulos AS AR ON AR.idArticulo = CA.idArticulo " _
            & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
            & " left join Monedas ON Monedas.codMoneda = AP.codMoneda " _
            & " left join Estados ON Estados.idEstado = CA.idEstado " _
            & " left join Familias ON Familias.idFamilia = AR.idFamilia " _
            & " left join subFamilias ON subFamilias.idSubFamilia = AR.idSubFamilia " _
            & " left join TiposIVA ON TiposIVA.idTipoIVA = CA.idTipoIVA "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoAlbaranProv)
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numAlbaran, idConcepto ", " Order By " & sOrden)
            Dim lista As New List(Of DatosConceptoAlbaranProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function mostrar(ByVal iidAlbaran As Integer) As List(Of DatosConceptoAlbaranProv)
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CA.idAlbaran = " & iidAlbaran & " ORder By CA.Orden ASC "
            Dim lista As New List(Of DatosConceptoAlbaranProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function mostrarCP(ByVal iidConceptoPedidoProv As Long) As List(Of DatosConceptoAlbaranProv)
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CA.idConceptoPedidoProv = " & iidConceptoPedidoProv
            Dim lista As New List(Of DatosConceptoAlbaranProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Traspasada(ByVal iidConcepto As Long) As Boolean
        'Informa si la linea ya ha sido traspasada
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Traspasado from ConceptosAlbaranesProv left join estados on Estados.idEstado = ConceptosAlbaranesProv.idEstado where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function TodosTraspasados(ByVal iidAlbaran As Integer) As Boolean
        'Informa si todas las lineas ya han sido traspasada
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idConcepto) from ConceptosAlbaranesProv left join estados on Estados.idEstado = ConceptosAlbaranesProv.idEstado where Traspasado = 0 and idAlbaran = " & iidAlbaran
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return True
            Else
                Return (CInt(o) = 0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function





    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoAlbaranProv
        Dim dts As New DatosConceptoAlbaranProv
        dts.gidConcepto = linea("idConcepto")
        dts.gidAlbaran = If(linea("idAlbaran") Is DBNull.Value, 0, linea("idAlbaran"))
        dts.gidFactura = If(linea("idFactura") Is DBNull.Value, 0, linea("idFactura"))
        dts.gcodArticuloProv = If(linea("codArticuloProv") Is DBNull.Value, "", linea("codArticuloProv"))
        dts.gArticuloProv = If(linea("ArticuloProv") Is DBNull.Value, "", linea("ArticuloProv"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gPVPUnitario = If(linea("PVPUnitario") Is DBNull.Value, 0, linea("PVPUnitario"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidArticuloProv = If(linea("idArticuloProv") Is DBNull.Value, 0, linea("idArticuloProv"))
        dts.gidConceptoPedidoProv = If(linea("idConceptoPedidoProv") Is DBNull.Value, 0, linea("idConceptoPedidoProv"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))


        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, "", linea("numAlbaran"))
        dts.gFechaRecibido = If(linea("FechaRecibido") Is DBNull.Value, Now.Date, linea("FechaRecibido"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))
        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gidSubFamilia = If(linea("idsubFamilia") Is DBNull.Value, 0, linea("idsubFamilia"))
        dts.gSubFamilia = If(linea("SubFamilia") Is DBNull.Value, "", linea("SubFamilia"))
        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
        dts.gTotalConcepto = If(linea("TotalConcepto") Is DBNull.Value, 0, linea("TotalConcepto"))
        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
        Return dts
    End Function

    Public Function mostrar1(ByVal iidConcepto As Long) As DatosConceptoAlbaranProv
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CA.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoAlbaranProv
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosAlbaranes set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("PVPUnitario", PVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", PrecioNetoUnitario)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)

                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using

    End Function

    Public Function CambiarEstado(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean


        Dim sel As String = "Update ConceptosAlbaranesProv set idEstado = " & iidEstado & " where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using

    End Function

    Public Function idAlbaran(ByVal iidConcepto As Long) As Integer
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select idAlbaran from ConceptosAlbaranesProv WHERE idConcepto= " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Then
                Return 0
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idConceptoPedido(ByVal iidConcepto As Long) As Integer
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select idConceptoPedidoProv from ConceptosAlbaranesProv WHERE idConcepto= " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Then
                Return 0
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




    Public Function Cantidad(ByVal iidConcepto As Long) As Double
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Cantidad from ConceptosAlbaranesProv WHERE idConcepto= " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Then
                Return 0
            Else
                Return CDbl(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

   
    Public Function CantidarRecibidaAlb(ByVal iidConceptoPedidoProv As Long) As Double
        'Cantidad recibida obtenida de los albaranes de proveedor
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select sum(Cantidad) from ConceptosAlbaranesProv do Where idConceptoPedidoProv = " & iidConceptoPedidoProv
            Dim lista As New List(Of DatosConceptoPedidoProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CDbl(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosConceptoAlbaranProv) As Integer


        Dim sel As String
        Dim resultado As Integer
        sel = "insert into ConceptosAlbaranesProv (idAlbaran, idFactura, codArticuloProv, ArticuloProv, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArticuloProv, idConceptoPedidoProv, Observaciones) "
        sel = sel & " values                     (@idAlbaran,@idFactura,@codArticuloProv,@ArticuloProv,@idArticulo,@Cantidad,@PVPUnitario,@idTipoIVA,@Descuento,@PrecioNetoUnitario,@Orden,@idEstado,@idArticuloProv,@idConceptoPedidoProv,@Observaciones ) SELECT @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idAlbaran", dts.gidAlbaran)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                cmd.Parameters.AddWithValue("ArticuloProv", dts.gArticuloProv)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gidAlbaran) + 1) 'dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("idConceptoPedidoProv", dts.gidConceptoPedidoProv)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)

                con.Open()
                resultado = cmd.ExecuteScalar()
                con.Close()
                Return resultado
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosConceptoAlbaranProv) As Boolean
        ' Actualiza un concepto de PedidosProv concreto con nuevos datos, a partir del idConcepto, devuelve False si hay error

        Dim sel As String

        sel = "update ConceptosAlbaranesProv set idAlbaran = @idAlbaran, idFactura = @idFactura, codArticuloProv = @codArticuloProv, ArticuloProv = @ArticuloProv, idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, "
        sel = sel & " idTipoIVA = @idTipoIVA, Descuento = @Descuento, PrecioNetoUnitario = @PrecioNetoUnitario, idEstado = @idEstado, idArticuloProv = @idArticuloProv, idConceptoPedidoProv = @idConceptoPedidoProv, Observaciones = @Observaciones  "
        sel = sel & " where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idAlbaran", dts.gidAlbaran)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                cmd.Parameters.AddWithValue("ArticuloProv", dts.gArticuloProv)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                'cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("idConceptoPedidoProv", dts.gidConceptoPedidoProv)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function



    Public Function actualizarPrecio(ByVal dts As DatosConceptoAlbaranProv) As Boolean
        ' Actualiza el precio unitario y total de un concepto del Pedido concreto, a partir del idConcepto, devuelve False si hay error

        Dim sel As String

        sel = "update ConceptosAlbaranesProv set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario, Descuento = @Descuento  where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double, ByVal Descuento As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosAlbaranesProv set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario, Descuento = @Descuento where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("PVPUnitario", PVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", PrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Descuento", Descuento)

                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using

    End Function




    Public Function borrar(ByVal iidConcepto As Integer, ByVal iidAlbaran As Integer) As Boolean
        Dim sel As String
        sel = "delete from ConceptosAlbaranesProv where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t > 0 Then
                    If OrdenacionErronea(iidAlbaran) Then
                        RenumerarConceptos(iidAlbaran, "")
                    Else
                        RenumerarConceptos(iidAlbaran, "Orden ASC")
                    End If
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function


    Public Function CambiarIdFactura(ByVal iidConcepto As Integer, ByVal iidFactura As Integer) As Boolean


        Dim sel As String = ""
        sel = "Update ConceptosAlbaranesProv set idFactura = " & iidFactura & " where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using

    End Function

    Public Function borrarAlbaranProv(ByVal iidAlbaran As Integer) As Boolean
        ' Elimina de la tabla todos los conceptos del PedidoProv indicado.

        Dim sel As String

        sel = "delete from ConceptosAlbaranesProv where idAlbaran = " & iidAlbaran

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function




#Region "ORDEN"

    Public Function UltimoOrden(ByVal iidAlbaran As Integer) As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosAlbaranesProv where idAlbaran = " & iidAlbaran
            Dim cmd As New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function MoverConceptos(ByVal iidConceptoSube As Long, ByVal iidConceptoBaja As Long) As Boolean
        If DisminuirOrden(iidConceptoSube) Then
            Return AumentarOrden(iidConceptoBaja)
        End If
    End Function

    Public Function AumentarOrden(ByVal iidConcepto As Integer) As Boolean

        Dim sel As String = "Update ConceptosAlbaranesProv set Orden = Orden + 1 where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function

    Public Function DisminuirOrden(ByVal iidConcepto As Integer) As Boolean

        Dim sel As String = "Update ConceptosAlbaranesProv set Orden = Orden - 1 where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function


    Public Sub RenumerarSiEsNecesario(ByVal iidAlbaran As Integer)
        If OrdenacionErronea(iidAlbaran) Then RenumerarConceptos(iidAlbaran, "")
    End Sub

    Private Function OrdenacionErronea(ByVal iidAlbaran As Integer) As Boolean
        'Detecta Orden = 0 y repeticiones de Orden
        Try
            Dim sel As String = "select (select count(idConcepto) from ConceptosAlbaranesProv where idAlbaran = @idAlbaran and Orden = 0) + "
            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosAlbaranesProv where idAlbaran = @idAlbaran Group by Orden order by count(idConcepto) desc)"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("idAlbaran", iidAlbaran)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub RenumerarConceptos(ByVal iidAlbaran As Integer, ByVal Orden As String)
        'Renumeramos según el idConcepto cuando la numeración por campo Orden no es válida
        'Si es válida renumeramos para eliminar saltos y normalizar
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idConcepto from ConceptosAlbaranesProv where idAlbaran = " & iidAlbaran & " Order by " & If(Orden = "", "idConcepto ASC", Orden)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim NOrden As Short = 1
                For Each linea As DataRow In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        CambiarOrden(linea("idConcepto"), NOrden)
                        NOrden = NOrden + 1
                    End If
                Next
            Else
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Public Function CambiarOrden(ByVal iidConcepto As Long, ByVal Orden As Short) As Boolean
        Dim sel As String = "Update ConceptosAlbaranesProv set ORden = @Orden where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Orden", Orden)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function

    Public Function Orden(ByVal iidConcepto As Long) As Integer
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Orden from ConceptosAlbaranesProv where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



#End Region





End Class
