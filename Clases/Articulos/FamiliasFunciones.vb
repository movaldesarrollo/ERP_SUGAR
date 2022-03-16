Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesFamilias
    Inherits conexion
    Dim cmd As SqlCommand

   
   

    Public Function Mostrar(ByVal iidFamilia As Integer, ByVal SoloActivos As Boolean) As List(Of DatosFamilia) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidFamilia = 0 Then
                sel = "SELECT * FROM Familias " & If(SoloActivos, " where Activo = 1 ", "") & " ORDER BY Familia ASC "
            Else
                sel = "SELECT * FROM Familias WHERE idFamilia = " & iidFamilia & If(SoloActivos, " AND Activo = 1 ", "")
            End If
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosFamilia)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosFamilia
                For Each linea In dt.Rows
                    If linea("idFamilia") Is DBNull.Value Then
                    Else
                        dts = New DatosFamilia
                        dts.gidFamilia = linea("idFamilia")
                        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
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



    Public Function Campo(ByVal vCampo As String, ByVal iidFamilia As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM Familias WHERE idFamilia = " & iidFamilia, con)

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

    Public Function Familia(ByVal iidFamilia As Integer) As String  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Familia from Familias WHERE idFamilia = " & iidFamilia, con)
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

    Public Function idFamilia(ByVal Familia As String) As Integer  'Devuelve el id de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idFamilia from Familias WHERE Familia = '" & Familia & "' ", con)
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



    Public Function Descripcion(ByVal iidFamilia As Integer) As String  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from Familias WHERE idFamilia = " & iidFamilia, con)
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

    Public Function Validacion(ByVal iidFamilia As Integer) As Boolean  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Validacion from Familias WHERE idFamilia = " & iidFamilia, con)
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

    Public Function Activo(ByVal iidFamilia As Integer) As Boolean  'Devuelve el nombre de la familia
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Activo from Familias WHERE idFamilia = " & iidFamilia, con)
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



    Public Function insertar(ByVal dts As DatosFamilia) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Familias ( Familia, Descripcion, Activo, Validacion) values ( @Familia, @Descripcion, @Activo, @Validacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Familia", dts.gFamilia)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
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

    Public Function actualizar(ByVal dts As DatosFamilia) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Familias set  Familia = @Familia, Descripcion = @Descripcion, Activo = @Activo, Validacion = @Validacion  WHERE idFamilia = " & dts.gidFamilia

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("Familia", dts.gFamilia)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
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

    Public Function borrar(ByVal iidFamilia As Integer) As Boolean
        'Borramos la familia si no hay ningun producto que lo tenga

        Dim func As New FuncionesArticulos
        Dim contador As Integer = func.Contador(" idFamilia = " & iidFamilia)
        If contador > 0 Then
            MsgBox("Existen " & contador & " productos de esta familia, por tanto no se puede borrar. En su lugar puede cambiar el nombre de la familia.")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Familias where idFamilia = " & iidFamilia
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


End Class



