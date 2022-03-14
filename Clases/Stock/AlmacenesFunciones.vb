Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesAlmacenes
    Inherits conexion
    Dim cmd As SqlCommand
    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosAlmacen)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT  Almacenes.*, Localidad + ' - ' + Direccion as Ubicacion, TipoAlmacen  "
            sel = sel & "FROM Almacenes left join TiposAlmacen ON TiposAlmacen.idTipoAlmacen = Almacenes.idTipoAlmacen "
            sel = sel & " LEFT JOIN Ubicaciones ON Ubicaciones.idUbicacion = Almacenes.idUbicacion "
            sel = sel & If(SoloActivos, " WHERE Almacenes.Activo = 1 ", "") & " Order By Almacen "

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosAlmacen)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosAlmacen
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idAlmacen") Is DBNull.Value Then
                    Else
                        dts = New DatosAlmacen
                        dts.gidAlmacen = linea("idAlmacen")
                        dts.gAlmacen = If(linea("Almacen") Is DBNull.Value, "", linea("Almacen"))
                        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
                        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gidTipoAlmacen = If(linea("idTipoAlmacen") Is DBNull.Value, 0, linea("idTipoAlmacen"))
                        dts.gUbicacion = If(linea("Ubicacion") Is DBNull.Value, "", linea("Ubicacion"))
                        dts.gTipoAlmacen = If(linea("TipoAlmacen") Is DBNull.Value, "", linea("TipoAlmacen"))
                        lista.Add(dts)
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

    Public Function Mostrar1(ByVal iidAlmacen As Integer) As DatosAlmacen
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  Almacenes.*, Localidad + ' - ' + Direccion as Ubicacion, TipoAlmacen  "
            sel = sel & "FROM Almacenes left join TiposAlmacen ON TiposAlmacen.idTipoAlmacen = Almacenes.idTipoAlmacen "
            sel = sel & " LEFT JOIN Ubicaciones ON Ubicaciones.idUbicacion = Almacenes.idUbicacion "
            sel = sel & " WHERE idAlmacen = " & iidAlmacen
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosAlmacen
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idAlmacen") Is DBNull.Value Then
                    Else
                        dts.gidAlmacen = linea("idAlmacen")
                        dts.gAlmacen = If(linea("Almacen") Is DBNull.Value, "", linea("Almacen"))
                        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
                        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                        dts.gidTipoAlmacen = If(linea("idTipoAlmacen") Is DBNull.Value, 0, linea("idTipoAlmacen"))
                        dts.gUbicacion = If(linea("Ubicacion") Is DBNull.Value, "", linea("Ubicacion"))
                        dts.gTipoAlmacen = If(linea("TipoAlmacen") Is DBNull.Value, "", linea("TipoAlmacen"))

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

    Public Function Almacen(ByVal iidAlmacen As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidAlmacen <> 0 Then
                Dim sel As String = " SELECT Almacen FROM Almacenes WHERE  idAlmacen = " & iidAlmacen
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
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

    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Almacenes", con)
            Else

                cmd = New SqlCommand(" SELECT COUNT(*) FROM Almacenes WHERE  " & busqueda, con)

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

    Public Function EstaEnUso(ByVal iidAlmacen As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = " SELECT  count(idStock) as Contador FROM Stock where idAlmacen = " & iidAlmacen
            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function codAlmacenExiste(ByVal iidAlmacen As Integer, ByVal scodAlmacen As String) As Boolean
        'Nos dice si existe una entrada el la tabla Almacenes con ese código
        If scodAlmacen = "" Or iidAlmacen = 0 Then
            Return False
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = " SELECT idAlmacen FROM Almacenes WHERE  codAlmacen ='" & scodAlmacen & If(iidAlmacen = 0, "' ", "' and idAlmacen <> " & iidAlmacen)
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    Dim resultado As String = cmd.ExecuteScalar
                    con.Close()
                    Return (resultado = iidAlmacen)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing

                End Try
            End Using
        End If

    End Function

    Public Function insertar(ByVal dts As DatosAlmacen) As Integer
        'Insertar un nuevo producto, si no existe ya el código 


        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Using con As New SqlConnection(sconexion)
            Try
                sel = "insert into Almacenes (Almacen, idUbicacion, Descripcion, FechaAlta, FechaBaja, Activo, idTipoAlmacen, idCreador, Creacion) "
                sel = sel & " values (@Almacen, @idUbicacion, @Descripcion, @FechaAlta, @FechaBaja, @Activo, @idTipoAlmacen, @idCreador, @Creacion) Select @@Identity "
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Almacen", dts.gAlmacen)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idTipoAlmacen", dts.gidTipoAlmacen)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosAlmacen) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Almacenes set Almacen = @Almacen, idUbicacion = @idUbicacion, Descripcion = @Descripcion, FechaAlta = @FechaAlta, FechaBaja = @FechaBaja,"
        sel = sel & " Activo = @Activo, idTipoAlmacen = @idTipoAlmacen, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " WHERE idAlmacen = @idAlmacen "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idAlmacen", dts.gidAlmacen)
                cmd.Parameters.AddWithValue("Almacen", dts.gAlmacen)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idTipoAlmacen", dts.gidTipoAlmacen)
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
            Finally
                desconectado()
            End Try

        End Using

    End Function

    Public Function PrimerAño() As Integer
        'Devuelve el valor del primer año de las Articulos
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT MIN(FechaAlta) FROM Almacenes ", con)
            con.Open()
            Dim Resultado As Object = cmd.ExecuteScalar
            con.Close()
            If Resultado Is DBNull.Value Then
                Return 0
            Else
                Return Year(Resultado)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PrimeraFecha() As Date
        'Devuelve el valor del primer año de las Articulos
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT MIN(FechaAlta) FROM Almacenes ", con)
            con.Open()
            Dim Resultado As Object = cmd.ExecuteScalar
            con.Close()
            If Resultado Is DBNull.Value Then
                Return Nothing
            Else
                Return Resultado
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Borrar(ByVal iidAlmacen As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)
                con.Open()
                sel = "delete from Almacenes where idAlmacen = " & iidAlmacen
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

    Public Function Baja(ByVal iidAlmacen As Integer) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Articulos set  Activo = 0  WHERE idAlmacen = " & iidAlmacen

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
End Class
