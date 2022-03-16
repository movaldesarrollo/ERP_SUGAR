


Imports System.Data.SqlClient
Imports System.Data.Sql
'Imports System.Transactions

Public Class FuncionesArticulosProv


    Inherits conexion
    Dim cmd As SqlCommand

    Dim sel0 As String = "SELECT  AP.*, Monedas.Simbolo, Articulos.Articulo, Articulos.codArticulo, Proveedores.NombreComercial as Proveedor, Familia, subFamilia, TipoUnidad, " _
            & " (SELECT max(numPedido) FROM ConceptosPedidosProv  WHERE  idArticuloProv = AP.idArticuloProv)as UltimoPedido, Articulos.idSeccion, Seccion " _
            & " FROM Articulos_Proveedor AS AP LEFT JOIN Articulos ON Articulos.idArticulo = AP.idArticulo LEFT JOIN Monedas ON Monedas.codMoneda = AP.codMoneda LEFT JOIN Proveedores On Proveedores.idProveedor = AP.idProveedor " _
            & " left join Familias ON Familias.idFamilia = Articulos.idFamilia left outer join SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia " _
            & " left outer join TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad " _
            & " left outer join Secciones ON Secciones.idSeccion = Articulos.idSeccion"

    Dim sel1 As String = "Select  sum(CP.Cantidad) as cantidadPedida, sum(CP.CantidadRecibida) as CantidadRecibida " _
            & "from ConceptosPedidosProv as CP left join PedidosProv as DOC ON DOC.numPedido = CP.numPedido " _
            & "left join Articulos as AR ON AR.idArticulo =CP.idArticulo " _
            & "left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
            & "Left join Proveedores ON Proveedores.idProveedor = DOC.idProveedor "


    Public Function Mostrar(ByVal iidProveedor As Integer, ByVal iidArticulo As Integer, ByVal iidFamilia As Integer, ByVal iidsubFamilia As Integer, ByVal Orden As String, ByVal SoloActivos As Boolean) As List(Of DatosArticuloProveedor)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0
            Dim consulta As String = If(iidProveedor = 0, "", " idProveedor = " & iidProveedor)
            consulta = consulta & If(iidArticulo = 0, "", " idArticulo = " & iidArticulo)

            Dim parametro As String = ""
            If iidArticulo <> 0 Then
                parametro = " AP.idArticulo = " & iidArticulo
            End If

            If iidProveedor <> 0 Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " AP.idProveedor = " & iidProveedor
              
            End If
          
            If iidFamilia <> 0 Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " Articulos.idFamilia = " & iidFamilia
            End If
            If iidsubFamilia <> 0 Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " Articulos.idsubFamilia = " & iidsubFamilia
            End If

            If SoloActivos Then
                parametro = If(parametro = "", "", parametro & " AND ")
                parametro = parametro & " Articulos.Activo = 1 "
            End If
            sel = sel & If(parametro = "", "", " WHERE " & parametro)
            sel = sel & If(Orden = "", " Order By AP.Nombre ASC ", " Order By " & Orden)
            Dim lista As New List(Of DatosArticuloProveedor)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticuloProv") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosArticuloProveedor
        Dim dts As New DatosArticuloProveedor
        dts.gidArticuloProv = linea("idArticuloProv")
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
        dts.gPrecio = If(linea("Precio") Is DBNull.Value, 0, linea("Precio"))
        dts.gPrecioUnitario = If(linea("PrecioUnitario") Is DBNull.Value, 0, linea("PrecioUnitario"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gFechaPrecio = If(linea("FechaPrecio") Is DBNull.Value, Now.Date, linea("FechaPrecio"))
        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
        dts.gcodArticuloProv = If(linea("codArticuloProv") Is DBNull.Value, "", linea("codArticuloProv"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gSubFamilia = If(linea("SubFamilia") Is DBNull.Value, "", linea("SubFamilia"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gUltimoPedido = If(linea("UltimoPedido") Is DBNull.Value, 0, linea("UltimoPedido"))
        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))
        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))
        Return dts
    End Function

    'Total cantidades pedidas, recibidas y pendientes ----------------LUIS
    Public Function totalesCantidadesPedidosProv(ByVal idproveedor As Integer, ByVal idArticulo As Integer) As List(Of DatosArticuloProveedor)
        Dim lista1 As New List(Of DatosArticuloProveedor)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel1 & " WHERE  Proveedores.idProveedor = " & idproveedor & "  AND  CP.idArticulo =  " & idArticulo & ""
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt1 As New DataTable
                Dim da1 As New SqlDataAdapter(cmd)
                da1.Fill(dt1)
                Dim linea1 As DataRow
                For Each linea1 In dt1.Rows
                    lista1.Add(CargarLinea1(linea1))
                Next
            Else
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return lista1
    End Function

    Private Function CargarLinea1(ByVal linea1 As DataRow) As DatosArticuloProveedor
        Dim dts1 As New DatosArticuloProveedor
        dts1.gCantidadPedida = If(linea1("cantidadPedida") Is DBNull.Value, 0, linea1("cantidadPedida"))
        dts1.gCantidadRecibida = If(linea1("CantidadRecibida") Is DBNull.Value, 0, linea1("CantidadRecibida"))
        Return dts1
    End Function


    Public Function Mostrar(ByVal iidProveedor As Integer, ByVal BusquedaLibre As String, ByVal Orden As String, ByVal SoloActivos As Boolean) As List(Of DatosArticuloProveedor)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = sel0 & " WHERE AP.idproveedor = @idProveedor "
            sel = sel & If(BusquedaLibre = "", "", " AND (Articulos.Articulo Like @NombreLibre OR AP.Nombre like @NombreLibre or codArticulo like @CodigoLibre or codArticuloProv like @CodigoLibre) ")
            sel = sel & If(SoloActivos, " AND Articulos.Activo = 1 ", "")
            sel = sel & If(Orden = "", "", " Order By " & Orden)

            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("NombreLibre", "%" & BusquedaLibre & "%")
            cmd.Parameters.AddWithValue("CodigoLibre", BusquedaLibre & "%")
            cmd.Parameters.AddWithValue("idProveedor", iidProveedor)
            Dim lista As New List(Of DatosArticuloProveedor)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticuloProv") Is DBNull.Value Then
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

    Public Function Mostrar1(ByVal iidArticuloProv As Integer) As DatosArticuloProveedor
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloProveedor
            sel = sel0 & " WHERE  idArticuloProv = " & iidArticuloProv
            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticuloProv") Is DBNull.Value Then
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


    Public Function Mostrar1(ByVal iidArticulo As Integer, ByVal iidProveedor As Integer) As DatosArticuloProveedor
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dts As New DatosArticuloProveedor

            sel = sel0 & " WHERE AP.Activo = 1 AND AP.idArticulo = " & iidArticulo & " AND AP.idProveedor = " & iidProveedor
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticuloProv") Is DBNull.Value Then
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



    Public Function Nombre(ByVal iidArticulo As Integer, ByVal iidProveedor As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""
            If iidArticulo <> "" Then
                If iidProveedor > 0 Then
                    sel = " SELECT Nombre FROM Articulos_Proveedor WHERE  idArticulo = " & iidArticulo & " AND idProveedor = " & iidProveedor & "  and Activo = 1 "
                Else
                    sel = " SELECT Articulo FROM Articulos WHERE  idArticulo = " & iidArticulo & " and Activo = 1 "

                End If
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function UltimoPedido(ByVal iidArticuloProv As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = ""

            sel = " SELECT max(numPedido) FROM ConceptosPedidosProv  WHERE  idArticuloProv = " & iidArticuloProv

            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar
            con.Close()
            If ob Is DBNull.Value Or ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function





    Public Function Proveedor(ByVal iidArticuloProv As Integer) As String
        'Devuelve el proveedor del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticuloProv <> "" Then
                Dim sel As String = " SELECT nombreComercial FROM Proveedores Left JOIN Articulos_Proveedor AS AP ON AP.idProveedor = Proveedores.idProveedor WHERE   AP.Activo = 1 AND idArticuloProv = " & iidArticuloProv
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function




    Public Function Precio(ByVal iidArticuloProv As Integer) As Double
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticuloProv <> 0 Then
                Dim sel As String = " SELECT Precio FROM Articulos_Proveedor WHERE  Activo = 1 AND idArticuloProv = " & iidArticuloProv
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return 0
                Else
                    Return CDbl(ob)
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function PrecioUnitario(ByVal iidArticuloProv As Integer) As Double
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticuloProv <> 0 Then
                Dim sel As String = " SELECT PrecioUnitario FROM Articulos_Proveedor WHERE  Activo = 1 AND idArticuloProv = " & iidArticuloProv
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return 0
                Else
                    Return CDbl(ob)
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function




    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Articulos_Proveedor ", con)
            Else

                cmd = New SqlCommand(" SELECT COUNT(*) FROM Articulos_Proveedor WHERE  " & busqueda, con)

            End If
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


    Public Function ProductoExiste(ByVal iidArticulo As Integer) As Boolean
        'Nos dice si existe una entrada el la tabla Articulos con ese código

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT idArticuloProv FROM Articulos WHERE idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim resultado As String = cmd.ExecuteScalar
                con.Close()
                Return (resultado = iidArticulo)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function ArticuloExiste(ByVal iidArticulo As Integer, ByVal iidProveedor As Integer) As Integer
        'Nos dice si existe una entrada el la tabla Articulos con ese código
        If iidArticulo = 0 Or iidProveedor = 0 Then
            Return False
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = " SELECT idArticuloProv FROM Articulos_Proveedor WHERE Activo = 1 and idProveedor = " & iidProveedor & " and idArticulo = " & iidArticulo
            Using con As New SqlConnection(sconexion)
                Try
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
            End Using
        End If

    End Function



    Public Function Guardar(ByVal dts As DatosArticuloProveedor) As Long
        'Insertar un nuevo producto, si no existe ya el código 
        If dts.gidArticuloProv > 0 Then
            dts.gidArticuloProv = ArticuloExiste(dts.gidArticulo, dts.gidProveedor)
            Call actualizarSiCambia(dts)
            Return dts.gidArticuloProv
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            Using con As New SqlConnection(sconexion)
                Try
                    'Comando de inserción del nuevo ensayo
                    sel = "insert into Articulos_Proveedor ( idArticulo, idProveedor, Nombre, Precio, codMoneda, FechaPrecio, Activo, codArticuloProv, PrecioUnitario) "
                    sel = sel & " values ( @idArticulo, @idProveedor, @Nombre, @Precio, @codMoneda, @FechaPrecio, @Activo, @codArticuloProv, @PrecioUnitario) select @@identity "
                    'conectado()

                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                    cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                    cmd.Parameters.AddWithValue("PrecioUnitario", dts.gPrecioUnitario)

                    cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                    cmd.Parameters.AddWithValue("FechaPrecio", dts.gFechaPrecio)
                    cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                    cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                    con.Open()
                    Dim t As Long = cmd.ExecuteScalar
                    con.Close()
                    Return t

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing

                End Try
            End Using
        End If





    End Function




    Public Function actualizar(ByVal dts As DatosArticuloProveedor) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
       
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos_Proveedor set  idArticulo = @idArticulo, idProveedor = @idProveedor, Nombre = @Nombre, Precio = @Precio,  codMoneda = @codMoneda, "
        sel = sel & " FechaPrecio = @FechaPrecio, Activo = @Activo, codArticuloProv = @codArticuloProv, PrecioUnitario =@PrecioUnitario  WHERE idArticuloProv = @idArticuloProv "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("PrecioUnitario", dts.gPrecioUnitario)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("FechaPrecio", dts.gFechaPrecio)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)

                con.Open()

                'ejecutar el sql
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



    Public Function actualizarSiCambia(ByVal dts As DatosArticuloProveedor) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
        Dim dts1 As DatosArticuloProveedor = Mostrar1(dts.gidArticuloProv)
        If dts1.gPrecio <> dts.gPrecio Or dts1.gNombre <> dts.gNombre Or dts1.gcodArticuloProv <> dts.gcodArticuloProv Then
            'Solo si hay un cambio real (no solo de fecha)
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "update Articulos_Proveedor set  idArticulo = @idArticulo, idProveedor = @idProveedor, Nombre = @Nombre, Precio = @Precio,  codMoneda = @codMoneda, "
            sel = sel & " FechaPrecio = @FechaPrecio, Activo = @Activo, codArticuloProv = @codArticuloProv, PrecioUnitario = @PrecioUnitario  WHERE idArticuloProv = @idArticuloProv "
            Using con As New SqlConnection(sconexion)
                Try

                    cmd = New SqlCommand(sel, con)

                    cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                    cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                    cmd.Parameters.AddWithValue("PrecioUnitario", dts.gPrecioUnitario)
                    cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                    cmd.Parameters.AddWithValue("FechaPrecio", dts.gFechaPrecio)
                    cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                    cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)

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

        End If


    End Function


    Public Function Baja(ByVal iidArticulo As Integer) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos_Proveedor set   Activo = 0  WHERE idArticulo = " & iidArticulo

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos

                con.Open()

                'ejecutar el sql
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
            Finally
                desconectado()
            End Try

        End Using

    End Function

    Public Function Borrar(ByVal iidArticuloProv As Integer) As Boolean
        'Borrar un Producto

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)
                con.Open()
                sel = "delete from Articulos_Proveedor where idArticuloProv = " & iidArticuloProv
                cmd = New SqlCommand(sel, con)
                Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                con.Close()
            End Using

            Return Resultado


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try

    End Function


  


    
  


End Class
