Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesStock
    Inherits conexion
    Dim cmd As SqlCommand
    Dim funcPE As New FuncionesPersonal

    Dim sel0 As String = " Stock.*, C1.numPedido, C2.numPedido as numPedido2, CP.numPedido as numPedidoProv, CA.numAlbaran, Articulo, Articulos.codArticulo, TipoUnidad, simbolo, A1.Almacen as Almacen,  Contactos.Nombre + ' ' + Apellidos as Persona1, Proveedores.NombreComercial as Proveedor " _
             & " FROM Stock left join Articulos ON Articulos.idArticulo = Stock.idArticulo " _
             & " Left join TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad " _
             & " Left Join Almacenes as A1 ON A1.idAlmacen = Stock.idAlmacen " _
             & " Left join Monedas on Monedas.codMoneda = Stock.codMoneda " _
             & " Left join Personal ON Personal.idPersona = Stock.idPersona1 " _
             & " Left join Contactos ON Personal.idContacto = Contactos.idContacto " _
             & " Left outer join ConceptosPedidosProv as CP ON CP.idConcepto = Stock.idConceptoProv " _
             & " Left outer join ConceptosAlbaranes as CA ON CA.idConcepto = STock.idConceptoAlbaran " _
             & " Left outer join ConceptosProduccion as CR ON CR.idProduccion = Stock.idProduccion " _
             & " Left outer join ConceptosPedidos as C1 ON C1.idConcepto = CR.idConceptoPedido " _
             & " Left outer join ConceptosPedidos as C2 ON C2.idConcepto = Stock.idConceptoPedido " _
             & " Left join PedidosProv ON PedidosProv.numPedido = CP.numPedido " _
             & " LEft join Proveedores ON PRoveedores.idProveedor = PedidosProv.idProveedor "

    Public Function Mostrar(ByVal iidArticulo As Integer, ByVal Movimiento As String, ByVal Maximo As Integer) As List(Of DatosStock) 'Devuelve los movimientos de un artículo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If Maximo = 0 Then
                sel = "SELECT " & sel0
            Else
                sel = "SELECT TOP " & Maximo & sel0
            End If
            sel = sel & " WHERE Stock.idArticulo = " & iidArticulo
            Select Case Movimiento
                Case "TODOS"
                Case ""
                Case "RECEPCIÓN"
                    sel = sel & " AND idConceptoProv > 0 "
                Case "ENTREGA"
                    sel = sel & " AND idConceptoAlbaran > 0 "
                Case Else
                    sel = sel & " AND Movimiento like '%" & Movimiento & "%' "
            End Select
            sel = sel & " ORDER By Fecha Desc, idStock DESC "
            Dim lista As New List(Of DatosStock)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idStock") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosStock
        Dim dts As New DatosStock
        dts.gidStock = linea("idStock")
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gidAlmacen = If(linea("idAlmacen") Is DBNull.Value, 0, linea("idAlmacen"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gidLote = If(linea("idLote") Is DBNull.Value, 0, linea("idLote"))
        dts.gidArticuloProv = If(linea("idArticuloProv") Is DBNull.Value, 0, linea("idArticuloProv"))
        dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
        dts.gPrecio = If(linea("Precio") Is DBNull.Value, 0, linea("Precio"))
        dts.gcodMoneda = If(linea("codmoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gidConceptoProv = If(linea("idConceptoProv") Is DBNull.Value, 0, linea("idConceptoProv"))
        dts.gidConceptoAlbaran = If(linea("idConceptoAlbaran") Is DBNull.Value, 0, linea("idConceptoAlbaran"))
        dts.gidProduccion = If(linea("idProduccion") Is DBNull.Value, 0, linea("idProduccion"))
        dts.gMovimiento = If(linea("Movimiento") Is DBNull.Value, "", linea("Movimiento"))
        dts.gidPersona1 = If(linea("idPersona1") Is DBNull.Value, 0, linea("idPersona1"))
        dts.gidPersona2 = If(linea("idPersona2") Is DBNull.Value, 0, linea("idPersona2"))
        dts.gidConceptoPedido = If(linea("idConceptoPedido") Is DBNull.Value, 0, linea("idConceptoPedido"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gPersona1 = If(linea("Persona1") Is DBNull.Value, "", linea("Persona1"))
        dts.gPersona2 = ""
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gnumPedidoProv = If(linea("numPedidoProv") Is DBNull.Value, 0, linea("numPedidoProv"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        If dts.gidProduccion > 0 Then
            dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
        ElseIf dts.gidConceptoPedido > 0 Then
            dts.gnumPedido = If(linea("numPedido2") Is DBNull.Value, 0, linea("numPedido2"))
        Else
            dts.gnumPedido = 0
        End If
        dts.gAlmacen = If(linea("Almacen") Is DBNull.Value, "", linea("Almacen"))
        If dts.gMovimiento = "" Then
            If dts.gnumAlbaran > 0 Then
                dts.gMovimiento = " ALBARÁN " & dts.gnumAlbaran
            End If
            If dts.gnumPedidoProv > 0 Then
                dts.gMovimiento = " PEDIDO PROVEEDOR " & dts.gnumPedidoProv
            End If
            If dts.gidConceptoPedido > 0 Then
                dts.gMovimiento = "PRODUCCIÓN PEDIDO " & dts.gnumPedido
            End If
            If dts.gidProduccion > 0 Then
                If dts.gnumPedido > 0 Then
                    dts.gMovimiento = "PRODUCCIÓN PEDIDO " & dts.gnumPedido
                Else
                    dts.gMovimiento = "PRODUCCIÓN NO ASIGNADO"
                End If
            End If
            If dts.gidPersona2 > 0 Then
                dts.gMovimiento = "ENTREGA DE " & dts.gPersona1 & " A " & UCase(funcPE.campoNombreyApellidos(dts.gidPersona2))
            End If
        End If
        Return dts
    End Function

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosStock) 'Devuelve los movimientos de un artículo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT " & sel0 & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", " Order By Fecha Desc, idStock desc ", " Order By " & sOrden)

            Dim lista As New List(Of DatosStock)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idStock") Is DBNull.Value Then
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

    Public Function MostrarFecha(ByVal Desde As Date, ByVal Hasta As Date, ByVal Movimiento As String) As List(Of DatosStock) 'Devuelve los movimientos de un artículo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT " & sel0 & " WHERE Fecha >= @Desde AND Fecha <= @Hasta "
            Select Case Movimiento
                Case "TODOS"
                Case ""
                Case "RECEPCIÓN"
                    sel = sel & " AND numPedidoProv > 0 "
                Case "ENTREGA"
                    sel = sel & " AND idPersona2 > 0 "
                Case Else
                    sel = sel & " AND Movimiento like '%" & Movimiento & "%' "
            End Select
            sel = sel & " ORDER By Articulo ,Fecha Desc, idStock DESC "
            Dim lista As New List(Of DatosStock)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("Desde", Desde)
            cmd.Parameters.AddWithValue("Hasta", Hasta)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idStock") Is DBNull.Value Then
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

    Public Function Mostrar1(ByVal iidStock As Integer) As DatosStock 'Devuelve los datos de un movimiento de stock
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT " & sel0 & " WHERE idStock = " & iidStock

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As New DatosStock
                For Each linea In dt.Rows
                    If linea("idStock") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
                Return dts
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Campo(ByVal vCampo As String, ByVal iidStock As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM Stock WHERE idStock = " & iidStock, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Then
                Return Nothing
            Else
                Return O
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CantidadStockProduccion(ByVal iidArticulo As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = " Select  case when Escandallo = 1 then (Select count(EQ.idEquipo) From ConceptosEquiposProduccion as CEQ  left join EquiposProduccion as EQ ON EQ.idEquipo = CEQ.idEquipo left join ConceptosProduccion as CR ON CR.idProduccion = EQ.idProduccion Where EQ.idArticulo = ARticulos.idArticulo and idConceptoPedido = 0 ) "
            sel = sel & " else (Select sum(Cantidad) From Stock Where Stock.idArticulo = Articulos.idArticulo) end as CantidadStock From Articulos where idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Then
                Return 0
            Else
                Return CDbl(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Cantidad(ByVal iidStock As Integer, ByVal iidArticulo As Integer, ByVal iidAlmacen As Integer) As Double
        'Devuelve la cantidad de un articulo o de una entrada de stock o de un almacen. Si se especifica artículo y almacen=-1 lista el almacen 0
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidStock > 0 Then
                sel = "select Cantidad from Stock WHERE idStock = " & iidStock

            Else
                If iidArticulo = 0 And iidAlmacen <> 0 Then
                    sel = "Select sum(Cantidad) from stock WHERE idAlmacen = " & iidAlmacen
                End If
                If iidArticulo <> 0 And iidAlmacen = 0 Then
                    sel = "Select sum(Cantidad) from stock WHERE idArticulo = " & iidArticulo
                End If
                If iidArticulo <> 0 And iidAlmacen <> 0 Then
                    If iidAlmacen = -1 Then
                        sel = "Select sum(Cantidad) from stock WHERE idArticulo = " & iidArticulo & " AND (idAlmacen = 0 or idAlmacen is null )"
                    Else
                        sel = "Select sum(Cantidad) from stock WHERE idArticulo = " & iidArticulo & " AND idAlmacen = " & iidAlmacen
                    End If
                End If
            End If
            If sel = "" Then
                Return 0
            Else
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar()
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return 0
                Else
                    Return CDbl(ob)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CantidadConceptoAlbaran(ByVal iidConceptoAlbaran As Integer) As Double
        'Devuelve la cantidad de un concepto de albarán
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select sum(Cantidad) from stock WHERE idConceptoAlbaran = " & iidConceptoAlbaran
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return 0
            Else
                Return CDbl(ob)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function CantidadStock(ByVal iidArticulo As Integer) As Double
        'Devuelve la cantidad de un concepto de albarán
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select sum(Cantidad) from stock WHERE idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return 0
            Else
                Return CDbl(ob)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function StockComponentes(ByVal iidArticulo As Integer) As Double
        'Devuelve la cantidad del artículo indicado que se puede montar con el stock de componentes existente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select CE.idArticulo,CE.codConcepto,Concepto, case when CE.Cantidad = 0 then 0 else sum(Stock.cantidad)/CE.Cantidad end as Cuantos from Stock "
            sel = sel & " left Join ConceptosEscandallos as CE ON CE.idArticulo = Stock.idArticulo "
            sel = sel & " left Join Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
            sel = sel & " where Escandallos.idArticulo = " & iidArticulo
            sel = sel & " group by CE.idArticulo,CE.Cantidad,CE.codConcepto,Concepto"
            Dim minimo As Double = 0
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("Cuantos") Is DBNull.Value Then
                    Else
                        If CDbl(linea("Cuantos")) < minimo Then minimo = linea("Cuantos")
                    End If
                Next
            Else
                con.Close()
            End If
            Return minimo
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function EliminarItemDelStock(ByVal iidConcepto As Long, ByVal iidProduccion As Long, ByVal CantidadInicial As Integer, ByVal Diferencia As Integer) As Integer
        ' regularizar stock al eliminar varias unidades de equipos de produccion

        If CantidadInicial = 0 Or iidProduccion = 0 Or Diferencia = 0 Then Return False

        Dim lista As List(Of Integer) = ListaArticulosProduccion(iidProduccion)
       
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = ""
        sel = sel & "Insert into Stock (idArticulo, idAlmacen, Cantidad,                                               idUnidad, idLote, idArticuloProv, Fecha,    Precio, codMoneda, idConceptoProv,idConceptoAlbaran, idProduccion,     Movimiento,            idPersona1,              idPersona2,           idConceptoPedido) "
        sel = sel & "           select idArticulo, idAlmacen, -Cantidad * @Diferencia / @CantidadInicial  as Cantidad, idUnidad, idLote, idArticuloProv, GETDATE(),Precio, codMoneda, idConceptoProv,idConceptoAlbaran,0 as idProduccion, 'Modificación pedido', @idPersona as idPersona1,idPersona2, @idConcepto as idConceptoPedido "
        sel = sel & " from Stock where idProduccion= " & iidProduccion

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idPErsona", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Diferencia", Diferencia)
                cmd.Parameters.AddWithValue("CantidadInicial", CantidadInicial)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 0 Then
                    Return 0
                Else
                    For Each iidArticulo As Integer In lista
                        Call actualizarStockArticulo(iidArticulo)
                    Next
                    Return lista.Count
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return -1
            End Try

        End Using
    End Function

    Public Function ListaArticulosProduccion(ByVal iidProduccion As Long) As List(Of Integer)
        'Devuelve la lista de artículos afectados por una idProducción en el stock
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select idArticulo from Stock where idProduccion = " & iidProduccion
            Dim lista As New List(Of Integer)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("idArticulo"))
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

    Public Function insertar(ByVal dts As DatosStock) As Integer

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Stock ( idArticulo, idAlmacen, Cantidad, idUnidad, idLote, idArticuloProv, Fecha, Precio, codMoneda, idConceptoProv,idConceptoAlbaran, idProduccion, Movimiento, idPersona1, idPersona2, idConceptoPedido) "
        sel = sel & " values ( @idArticulo,  @idAlmacen, @Cantidad, @idUnidad, @idLote, @idArticuloProv, @Fecha, @Precio, @codMoneda, @idConceptoProv,@idConceptoAlbaran, @idProduccion, @Movimiento, @idPersona1, @idPersona2, @idConceptoPedido) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idAlmacen", dts.gidAlmacen)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idUnidad", dts.gidUnidad)
                cmd.Parameters.AddWithValue("idLote", dts.gidLote)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idConceptoProv", dts.gidConceptoProv)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", dts.gidConceptoAlbaran)
                cmd.Parameters.AddWithValue("idProduccion", dts.gidProduccion)
                cmd.Parameters.AddWithValue("Movimiento", dts.gMovimiento)
                cmd.Parameters.AddWithValue("idPersona1", dts.gidPersona1)
                cmd.Parameters.AddWithValue("idPersona2", dts.gidPersona2)
                cmd.Parameters.AddWithValue("idConceptoPedido", dts.gidConceptoPedido)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is Nothing Then
                    Return 0
                Else
                    Call actualizarStockArticulo(dts.gidArticulo)
                    Return CInt(o)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Using
    End Function

    Public Function actualizarStockArticulo(ByVal iidArticulo As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos set Stock = (Select sum(Cantidad) from stock WHERE idArticulo = Articulos.idArticulo) where idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
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

    Public Function actualizar(ByVal dts As DatosStock) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Stock set  idArticulo = @idArticulo, idAlmacen = @idAlmacen, Cantidad = @Cantidad, idUnidad = @idUnidad, idLote = @idLote, idArticuloProv = @idArticuloProv, "
        sel = sel & " Fecha = @Fecha, Precio = @Precio, codMoneda = @codMoneda, idConceptoProv = @idConceptoProv, idConceptoAlbaran = @idConceptoAlbaran, idProduccion = @idProduccion, Movimiento = @Movimiento, idPersona1 = @idPersona1, idPersona2 = @idPersona2, idConceptoPedido = @idConceptoPedido  WHERE idStock = @idStock "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idStock", dts.gidStock)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idAlmacen", dts.gidAlmacen)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idUnidad", dts.gidUnidad)
                cmd.Parameters.AddWithValue("idLote", dts.gidLote)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idConceptoProv", dts.gidConceptoProv)
                cmd.Parameters.AddWithValue("idConceptoAlbaran", dts.gidConceptoAlbaran)
                cmd.Parameters.AddWithValue("idProduccion", dts.gidProduccion)
                cmd.Parameters.AddWithValue("Movimiento", dts.gMovimiento)
                cmd.Parameters.AddWithValue("idPersona1", dts.gidPersona1)
                cmd.Parameters.AddWithValue("idPersona2", dts.gidPersona2)
                cmd.Parameters.AddWithValue("idConceptoPedido", dts.gidConceptoPedido)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Call actualizarStockArticulo(dts.gidArticulo)
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


    'Public Function borrar(ByVal iidStock As Integer) As Boolean
    '    'Borramos una entrada de stock
    '    Dim sconexion As String = CadenaConexion()
    '    Dim sel As String = "delete from Stock where idStock = " & iidStock
    '    Using con As New SqlConnection(sconexion)
    '        Try
    '            cmd = New SqlCommand(sel, con)
    '            'abrir conexion
    '            con.Open()
    '            'ejecutar el sql
    '            Dim t As Integer = CInt(cmd.ExecuteNonQuery())
    '            con.Close()
    '            If t = 1 Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Return False
    '        End Try
    '    End Using
    'End Function


    Public Function borrarArticulo(ByVal iidArticulo As Integer) As Boolean
        'Borramos un artículo completo del stock
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Stock where idArticulo= " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Call actualizarStockArticulo(iidArticulo)
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


    Public Function borrarProduccion(ByVal iidProduccion As Long) As Boolean
        'Borramos una produccion completa
        Dim sconexion As String = CadenaConexion()

        Dim lista As List(Of Integer) = ListaArticulosProduccion(iidProduccion)
        Dim sel As String = "delete from Stock where idProduccion= " & iidProduccion
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t > 0 Then
                    For Each iidArticulo As Integer In lista
                        Call actualizarStockArticulo(iidArticulo)
                    Next
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



End Class



