Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionessubTiposArticulo
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar(ByVal iidTipoArticulo As Integer, ByVal iidSubTipoArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosSubTipoArticulo) 'Devuelve los datos de una TipoArticulo como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of DatosSubTipoArticulo)
            Dim sel As String = "Select * from subTiposArticulo left join AgrupacionesArticulo ON subTiposArticulo.idAgrupacion = AgrupacionesArticulo.idAgrupacion "

            If iidSubTipoArticulo = 0 And iidTipoArticulo = 0 Then
                sel = sel & If(SoloActivos, " where Activo = 1 ", "") & " order by subTipoArticulo"
            Else
                If iidSubTipoArticulo = 0 Then
                    sel = sel & " Where idTipoArticulo = " & iidTipoArticulo & If(SoloActivos, " AND Activo = 1 ", "") & " order by subTipoArticulo"
                Else
                    sel = sel & " WHERE idTipoArticulo = " & iidTipoArticulo & " AND idSubTipoArticulo = " & iidSubTipoArticulo & If(SoloActivos, " AND Activo = 1 ", "") & " order by subTipoArticulo"
                End If
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosSubTipoArticulo
                For Each linea In dt.Rows
                    If linea("idSubTipoArticulo") Is DBNull.Value Then
                    Else
                        dts = New DatosSubTipoArticulo
                        dts.gidSubTipoArticulo = linea("idSubTipoArticulo")
                        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
                        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gValidacion = If(linea("Validacion") Is DBNull.Value, False, linea("Validacion"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gidAgrupacion = If(linea("idAgrupacion") Is DBNull.Value, 0, linea("idAgrupacion"))
                        dts.gAgrupacion = If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion"))
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

    Public Function Mostrar1(ByVal iidSubTipoArticulo As Integer) As DatosSubTipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim dts As New DatosSubTipoArticulo
            Dim sel As String = "Select * from subTiposArticulo left join AgrupacionesArticulo ON subTiposArticulo.idAgrupacion = AgrupacionesArticulo.idAgrupacion "
            sel = sel & " Where idsubTipoArticulo = " & iidSubTipoArticulo
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idSubTipoArticulo") Is DBNull.Value Then
                    Else
                        dts.gidSubTipoArticulo = linea("idSubTipoArticulo")
                        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
                        dts.gSubTipoArticulo = If(linea("subTipoArticulo") Is DBNull.Value, "", linea("subTipoArticulo"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gValidacion = If(linea("Validacion") Is DBNull.Value, False, linea("Validacion"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
                        dts.gidAgrupacion = If(linea("idAgrupacion") Is DBNull.Value, 0, linea("idAgrupacion"))
                        dts.gAgrupacion = If(linea("Agrupacion") Is DBNull.Value, "", linea("Agrupacion"))
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


    Public Function Listar(ByVal SoloActivos As Boolean) As List(Of String) 'Devuelve los datos de una TipoArticulo como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
          
            sel = "SELECT distinct subTipoArticulo FROM subTiposArticulo " & If(SoloActivos, " WHERE Activo = 1 ", "") & " order by subTipoArticulo"
            Dim lista As New List(Of String)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("SubTipoArticulo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("SubTipoArticulo"))
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

    Public Function Campo(ByVal vCampo As String, ByVal iidSubTipoArticulo As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM subTiposArticulo WHERE idSubTipoArticulo = " & iidSubTipoArticulo, con)

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

    Public Function SubTipoArticulo(ByVal iidSubTipoArticulo As Integer) As String  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select SubTipoArticulo from subTiposArticulo WHERE idSubTipoArticulo = " & iidSubTipoArticulo, con)
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


    Public Function idSubTipoArticulo(ByVal iidTipoArticulo As Integer, ByVal SubTipoArticulo As String) As Integer  'Devuelve el id de la TipoArticulo
        Try
            If iidTipoArticulo = 0 Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("select idSubTipoArticulo from SubTiposArticulo WHERE idTipoArticulo = " & iidTipoArticulo & " AND SubTipoArticulo = '" & SubTipoArticulo & "' ", con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar()
                con.Close()
                If ob Is Nothing Then
                    Return 0
                Else
                    Return CInt(ob)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Descripcion(ByVal iidSubTipoArticulo As Integer) As String  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from subTiposArticulo WHERE idSubTipoArticulo = " & iidSubTipoArticulo, con)
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
        End Try
    End Function

    Public Function Validacion(ByVal iidSubTipoArticulo As Integer) As Boolean  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Validacion from subTiposArticulo WHERE idSubTipoArticulo = " & iidSubTipoArticulo, con)
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
        End Try
    End Function

    Public Function Activo(ByVal iidSubTipoArticulo As Integer) As Boolean  'Devuelve el nombre de la TipoArticulo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Activo from subTiposArticulo WHERE idSubTipoArticulo = " & iidSubTipoArticulo, con)
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
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosSubTipoArticulo) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into subTiposArticulo ( SubTipoArticulo, Descripcion, Activo, Validacion, idTipoArticulo, idAgrupacion) values ( @SubTipoArticulo, @Descripcion, @Activo, @Validacion, @idTipoArticulo, @idAgrupacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("SubTipoArticulo", dts.gSubTipoArticulo)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("idTipoArticulo", dts.gidTipoArticulo)
                cmd.Parameters.AddWithValue("idAgrupacion", 0)
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

    Public Function actualizar(ByVal dts As DatosSubTipoArticulo) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update subTiposArticulo set  SubTipoArticulo = @SubTipoArticulo, Descripcion = @Descripcion, Activo = @Activo, Validacion = @Validacion  WHERE idSubTipoArticulo = @idSubTipoArticulo "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idSubTipoArticulo", dts.gidSubTipoArticulo)
                cmd.Parameters.AddWithValue("SubTipoArticulo", dts.gSubTipoArticulo)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("idTipoArticulo", dts.gidTipoArticulo)
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


    Public Function actualizarAgrupacion(ByVal dts As DatosSubTipoArticulo) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update subTiposArticulo set idAgrupacion = @idAgrupacion  WHERE idSubTipoArticulo = @idSubTipoArticulo "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idSubTipoArticulo", dts.gidSubTipoArticulo)
                cmd.Parameters.AddWithValue("idAgrupacion", dts.gidAgrupacion)
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


    Public Function borrar(ByVal iidSubTipoArticulo As Integer) As Boolean
        'Borramos la TipoArticulo si no hay ningun producto que lo tenga

        Dim func As New FuncionesArticulos
        Dim contador As Integer
        'contador = func.ContadorSub(" idSubTipoArticulo = " & iidSubTipoArticulo)
        If contador > 0 Then
            MsgBox("Existen " & contador & " productos de esta subTipoArticulo, por tanto no se puede borrar. En su lugar puede cambiar el nombre de la subTipoArticulo.")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from subTiposArticulo where idSubTipoArticulo = " & iidSubTipoArticulo
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    'abrir conexion
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
        End If

    End Function

    Public Function borrarTipoArticulo(ByVal iidTipoArticulo As Integer) As Boolean
        'Borramos todas las subTiposArticulo de la TipoArticulo 

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from subTiposArticulo where idTipoArticulo = " & iidTipoArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
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

End Class



