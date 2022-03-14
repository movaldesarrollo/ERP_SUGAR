Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesPreciosPorCantidad
    Inherits conexion
    Dim cmd As SqlCommand


    Dim sel0 As String = "SELECT PC.*, Articulo, codArticulo, NombreComercial as Proveedor, TipoUnidad, PR.codMoneda,Simbolo " _
     & "  FROM PreciosPorCantidad as PC left join Articulos as AR ON AR.idArticulo = PC.idArticulo " _
     & " Left Join Proveedores as PR ON PR.idProveedor = PC.idProveedor " _
     & " Left Join Monedas ON Monedas.codMoneda = PR.codMoneda " _
     & " Left Join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "

    Public Function Mostrar(ByVal iidArticulo As Integer, ByVal iidProveedor As Integer) As List(Of DatosPrecioPorCantidad) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            If iidArticulo = 0 And iidProveedor = 0 Then
                sel = sel0
            ElseIf iidArticulo = 0 Then
                sel = sel0 & " WHERE PC.idProveedor = " & iidProveedor
            ElseIf iidProveedor = 0 Then
                sel = sel0 & " WHERE PC.idArticulo = " & iidArticulo
            Else
                sel = sel0 & " WHERE PC.idArticulo = " & iidArticulo & " AND PC.idProveedor = " & iidProveedor
            End If
            sel = sel & " Order By Proveedor"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPrecioPorCantidad)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idRangoPrecio") Is DBNull.Value Then
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosPrecioPorCantidad
        Dim dts As New DatosPrecioPorCantidad
        dts.gidRangoPrecio = linea("idRangoPrecio")
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gDesde = If(linea("Desde") Is DBNull.Value, 0, linea("Desde"))
        dts.gHasta = If(linea("Hasta") Is DBNull.Value, 0, linea("Hasta"))
        dts.gPrecio = If(linea("Precio") Is DBNull.Value, 0, linea("Precio"))
        dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        dts.gCodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        Return dts
    End Function



    Public Function Mostrar1(ByVal iidRangoPrecio As Integer) As DatosPrecioPorCantidad
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE idRangoPrecio = " & iidRangoPrecio
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosPrecioPorCantidad
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idRangoPrecio") Is DBNull.Value Then
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


    Public Function ExisteRangoPrecio(ByVal dts As DatosPrecioPorCantidad) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select count(idRangoPrecio) from PreciosPorCantidad where idArticulo = @idArticulo AND idProveedor = @idProveedor AND idRangoPrecio <> @idRangoPrecio AND ((@Desde > Desde AND @Desde < Hasta ) OR (@Hasta >= Desde AND @Hasta <= Hasta) OR (Hasta = 0 AND Desde = 0) )  "
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("idRangoPrecio", dts.gidRangoPrecio)
            cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
            cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
            cmd.Parameters.AddWithValue("Desde", dts.gDesde)
            cmd.Parameters.AddWithValue("Hasta", dts.gHasta)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

   

    Public Function insertar(ByVal dts As DatosPrecioPorCantidad) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into PreciosPorCantidad ( idArticulo, idProveedor, Desde, Hasta, Precio,Fecha, idCreador, Creacion) values ( @idArticulo, @idProveedor, @Desde, @Hasta, @Precio,@Fecha, @idCreador, @Creacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("Desde", dts.gDesde)
                cmd.Parameters.AddWithValue("Hasta", dts.gHasta)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosPrecioPorCantidad) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update PreciosPorCantidad set  idArticulo = @idArticulo, idProveedor = @idProveedor,Desde = @Desde,Hasta = @Hasta, Precio = @Precio, idModifica = @idModifica, Modificacion = @Modificacion  WHERE idRangoPrecio = @idRangoPrecio"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idRangoPrecio", dts.gidRangoPrecio)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("Desde", dts.gDesde)
                cmd.Parameters.AddWithValue("Hasta", dts.gHasta)
                cmd.Parameters.AddWithValue("Precio", dts.gPrecio)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function borrar(ByVal iidRangoPrecio As Integer) As Boolean
        Return borrar(" idRangoPrecio = " & iidRangoPrecio)
    End Function

    Public Function borrarProveedor(ByVal iidProveedor As Integer) As Boolean
        Return borrar(" idProveedor = " & iidProveedor)
    End Function

    Public Function borrarArticulo(ByVal iidArticulo As Integer) As Boolean
        Return borrar(" idArticulo = " & iidArticulo)
    End Function

    Private Function borrar(ByVal sBusqueda As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from PreciosPorCantidad where " & sBusqueda
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




End Class



