Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesTiposArticulo
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar(ByVal iidTipoArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosTipoArticulo) 'Devuelve los datos de una TipoArticulo como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidTipoArticulo = 0 Then
                sel = "SELECT * FROM TiposArticulo " & If(SoloActivos, " where Activo = 1 ", "") & " ORDER BY TipoArticulo ASC "
            Else
                sel = "SELECT * FROM TiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo & If(SoloActivos, " AND Activo = 1 ", "")
            End If
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTipoArticulo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTipoArticulo

                For Each linea In dt.Rows
                    If linea("idTipoArticulo") Is DBNull.Value Then
                    Else
                        dts = New DatosTipoArticulo
                        dts.gidTipoArticulo = linea("idTipoArticulo")
                        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gValidacion = If(linea("Validacion") Is DBNull.Value, False, linea("Validacion"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gDescuento1 = If(linea("Descuento1") Is DBNull.Value, False, linea("Descuento1"))
                        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, False, linea("Descuento2"))
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

    Public Function Campo(ByVal vCampo As String, ByVal iidTipoArticulo As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM TiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo, con)
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

    Public Function TipoArticulo(ByVal iidTipoArticulo As Integer) As String  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoArticulo from TiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function idTipoArticulo(ByVal TipoArticulo As String) As Integer  'Devuelve el id de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idTipoArticulo from TiposArticulo WHERE TipoArticulo = '" & TipoArticulo & "' ", con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return 0
            Else
                Return CInt(ob)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Descripcion(ByVal iidTipoArticulo As Integer) As String  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from TiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return ""
            Else
                Return CStr(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Validacion(ByVal iidTipoArticulo As Integer) As Boolean  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Validacion from TiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return False
            Else
                Return CBool(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Activo(ByVal iidTipoArticulo As Integer) As Boolean  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Activo from TiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar()
            con.Close()
            If ob Is Nothing Then
                Return False
            Else
                Return CBool(ob)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As DatosTipoArticulo) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into TiposArticulo ( TipoArticulo, Descripcion, Activo, Validacion, Descuento1, Descuento2) values ( @TipoArticulo, @Descripcion, @Activo, @Validacion, @Descuento1, @Descuento2) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoArticulo", dts.gTipoArticulo)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("Descuento1", dts.gDescuento1)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
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

    Public Function actualizar(ByVal dts As DatosTipoArticulo) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TiposArticulo set  TipoArticulo = @TipoArticulo, Descripcion = @Descripcion, Activo = @Activo, Validacion = @Validacion, Descuento1 = @Descuento1, Descuento2 = @Descuento2  WHERE idTipoArticulo = " & dts.gidTipoArticulo

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("TipoArticulo", dts.gTipoArticulo)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("Descuento1", dts.gDescuento1)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
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

    Public Function borrar(ByVal iidTipoArticulo As Integer) As Boolean
        'Borramos la TipoArticulo si no hay ningun producto que lo tenga

        Dim func As New FuncionesArticulos
        Dim contador As Integer = func.Contador(" idTipoArticulo = " & iidTipoArticulo)
        If contador > 0 Then
            MsgBox("Existen " & contador & " productos de esta TipoArticulo, por tanto no se puede borrar. En su lugar puede cambiar el nombre de la TipoArticulo.")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from TiposArticulo where idTipoArticulo = " & iidTipoArticulo
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
        End If

    End Function
End Class



