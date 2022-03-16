
Imports System.Data.SqlClient
Imports System.Data.Sql
'Imports System.Transactions

Public Class FuncionesTiposAlmacenes

    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar() As List(Of DatosTipoAlmacen)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  * FROM TiposAlmacen Order By TipoAlmacen ASC"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTipoAlmacen)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosTipoAlmacen
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoAlmacen") Is DBNull.Value Then
                    Else
                        dts = New DatosTipoAlmacen
                        dts.gidTipoAlmacen = linea("idTipoAlmacen")
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




    Public Function Mostrar1(ByVal iidTipoAlmacen As Integer) As DatosTipoAlmacen
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  * FROM TiposAlmacen WHERE idTipoAlmacen = " & iidTipoAlmacen & " Order By TipoAlmacen ASC"
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoAlmacen
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
                        dts.gidTipoAlmacen = linea("idTipoAlmacen")
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



    Public Function TipoAlmacen(ByVal iidTipoAlmacen As Integer) As String
        'Devuelve el nombre del producto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidTipoAlmacen <> 0 Then
                Dim sel As String = " SELECT TipoAlmacen FROM TiposAlmacen WHERE  idTipoAlmacen = " & iidTipoAlmacen
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






    Public Function insertar(ByVal dts As DatosTipoAlmacen) As Integer
        'Insertar un nuevo producto, si no existe ya el código 
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Using con As New SqlConnection(sconexion)
            Try
                sel = "insert into TiposAlmacen (TipoAlmacen) "
                sel = sel & " values (@TipoAlmacen) Select @@Identity "
                con.Open()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("TipoAlmacen", dts.gTipoAlmacen)
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



    Public Function actualizar(ByVal dts As DatosTipoAlmacen) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TipoAlmacen = @TipoAlmacen WHERE idTipoAlmacen = @idTipoAlmacen "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoAlmacen", dts.gidTipoAlmacen)
                cmd.Parameters.AddWithValue("TipoAlmacen", dts.gTipoAlmacen)

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





    Public Function Borrar(ByVal iidTipoAlmacen As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from TiposAlmacen where idTipoAlmacen = " & iidTipoAlmacen
                cmd = New SqlCommand(sel, con)
                con.Open()
                Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                con.Close()
            End Using

            Return Resultado

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try

    End Function




End Class
