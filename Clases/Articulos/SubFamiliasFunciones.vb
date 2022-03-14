Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionessubFamilias
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal iidFamilia As Integer, ByVal iidSubFamilia As Integer, ByVal SoloActivos As Boolean) As List(Of DatosSubFamilia) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            If iidSubFamilia = 0 Then
                sel = "SELECT * FROM subFamilias Where idFamilia = " & iidFamilia & If(SoloActivos, " AND Activo = 1 ", "") & " order by subfamilia"
            Else
                sel = "SELECT * FROM subFamilias WHERE idFamilia = " & iidFamilia & " AND idSubFamilia = " & iidSubFamilia & If(SoloActivos, " AND Activo = 1 ", "") & " order by subfamilia"
            End If
            Dim lista As New List(Of DatosSubFamilia)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosSubFamilia

                For Each linea In dt.Rows
                    If linea("idSubFamilia") Is DBNull.Value Then
                    Else
                        dts = New DatosSubFamilia
                        dts.gidSubFamilia = linea("idSubFamilia")
                        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))
                        dts.gSubFamilia = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gValidacion = If(linea("Validacion") Is DBNull.Value, False, linea("Validacion"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
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

    Public Function Listar(ByVal SoloActivos As Boolean) As List(Of String) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT distinct subFamilia FROM subFamilias " & If(SoloActivos, " WHERE Activo = 1 ", "") & " order by subfamilia"

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
                    If linea("SubFamilia") Is DBNull.Value Then
                    Else
                        lista.Add(linea("SubFamilia"))
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

    Public Function Campo(ByVal vCampo As String, ByVal iidSubFamilia As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM subFamilias WHERE idSubFamilia = " & iidSubFamilia, con)

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

    Public Function SubFamilia(ByVal iidSubFamilia As Integer) As String  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select SubFamilia from subFamilias WHERE idSubFamilia = " & iidSubFamilia, con)
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


    Public Function idSubFamilia(ByVal iidFamilia As Integer, ByVal SubFamilia As String) As Integer  'Devuelve el id de la familia
        Try
            If iidFamilia = 0 Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("select idSubFamilia from SubFamilias WHERE idFamilia = " & iidFamilia & " AND SubFamilia = '" & SubFamilia & "' ", con)
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
        Finally
            desconectado()
        End Try
    End Function

    Public Function Descripcion(ByVal iidSubFamilia As Integer) As String  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from subFamilias WHERE idSubFamilia = " & iidSubFamilia, con)
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

    Public Function Validacion(ByVal iidSubFamilia As Integer) As Boolean  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Validacion from subFamilias WHERE idSubFamilia = " & iidSubFamilia, con)
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

    Public Function Activo(ByVal iidSubFamilia As Integer) As Boolean  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Activo from subFamilias WHERE idSubFamilia = " & iidSubFamilia, con)
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



    Public Function insertar(ByVal dts As DatosSubFamilia) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into subFamilias ( SubFamilia, Descripcion, Activo, Validacion, idFamilia) values ( @SubFamilia, @Descripcion, @Activo, @Validacion, @idFamilia) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("SubFamilia", dts.gSubFamilia)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("idFamilia", dts.gidFamilia)
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
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosSubFamilia) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update subFamilias set  SubFamilia = @SubFamilia, Descripcion = @Descripcion, Activo = @Activo, Validacion = @Validacion  WHERE idSubFamilia = @idSubFamilia "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idSubFamilia", dts.gidSubFamilia)
                cmd.Parameters.AddWithValue("SubFamilia", dts.gSubFamilia)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("idFamilia", dts.gidFamilia)
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

    Public Function borrar(ByVal iidSubFamilia As Integer) As Boolean
        'Borramos la familia si no hay ningun producto que lo tenga

        Dim func As New FuncionesArticulos
        Dim contador As Integer
        'contador = func.ContadorSub(" idSubFamilia = " & iidSubFamilia)
        If contador > 0 Then
            MsgBox("Existen " & contador & " productos de esta subfamilia, por tanto no se puede borrar. En su lugar puede cambiar el nombre de la subfamilia.")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from subFamilias where idSubFamilia = " & iidSubFamilia
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

    Public Function borrarFamilia(ByVal iidFamilia As Integer) As Boolean
        'Borramos todas las subfamilias de la familia 

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from subFamilias where idFamilia = " & iidFamilia
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



