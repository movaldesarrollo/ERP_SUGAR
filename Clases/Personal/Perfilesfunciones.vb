Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesPerfiles
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As List(Of datosPerfiles)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Perfiles ", con)
            Dim lista As New List(Of datosPerfiles)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As datosPerfiles
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idPerfil") Is DBNull.Value Then
                    Else
                        dts = New datosPerfiles
                        dts.gidPerfil = linea("idPerfil")
                        dts.gPerfil = If(linea("Perfil") Is DBNull.Value, "", linea("Perfil"))
                        dts.gdescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gSoloLectura = If(linea("SoloLectura") Is DBNull.Value, False, linea("SoloLectura"))
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

    Public Function mostrar1(ByVal iidPerfil As Integer) As datosPerfiles
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Perfiles where idPerfil = '" & iidPerfil & "' ", con)
            Dim dts As New datosPerfiles
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idPerfil") Is DBNull.Value Then
                    Else
                        dts.gidPerfil = linea("idPerfil")
                        dts.gPerfil = If(linea("Perfil") Is DBNull.Value, "", linea("Perfil"))
                        dts.gdescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gSoloLectura = If(linea("SoloLectura") Is DBNull.Value, False, linea("SoloLectura"))
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


    Public Function Pantallas() As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select * from Pantallas ", con)
            Dim dt As New DataTable
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                con.Close()
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
     
        End Try
    End Function


    Public Function Campo(ByVal vCampo As String, ByVal vPerfil As String) As String
        Try
            If vCampo <> "" And vPerfil <> "" Then
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("select " & vCampo & "  from Perfiles where Perfil = '" & vPerfil & "' ", con)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Then
                    Return ""
                Else
                    Return CStr(o)
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Perfil(ByVal iidPerfil As String) As String
        Try

            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Perfil  from Perfiles where idPerfil = " & iidPerfil, con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return ""
            Else
                Return CStr(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As datosPerfiles) As Integer
        If PerfilExiste(dts.gPerfil) Then
            MsgBox("Ya existe el perfil " & dts.gPerfil)
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = "insert into perfiles (Perfil, descripcion) values (@Perfil, @descripcion) select @@identity "

            Using con As New SqlConnection(sconexion)
                Try

                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("Perfil", dts.gPerfil)
                    cmd.Parameters.AddWithValue("descripcion", dts.gdescripcion)
                    con.Open()
                    Dim t As Integer = cmd.ExecuteScalar()
                    con.Close()
                    Return t

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
              
                End Try

            End Using
        End If


    End Function

    Public Function PerfilExiste(ByVal vPerfil As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "Select Perfil From Perfiles where Perfil = '" & vPerfil & "' "

        Using con As New SqlConnection(sconexion)

            Try

                con.Open()

                Dim resultado As String = cmd.ExecuteScalar()

                con.Close()

                Return (resultado = vPerfil)

            Catch ex As Exception

                Return False

            End Try

        End Using

    End Function

    Public Function actualizar(ByVal dts As datosPerfiles) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Perfiles set descripcion = @descripcion, Perfil = @Perfil where idPerfil = " & dts.gidPerfil & " "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("descripcion", dts.gdescripcion)
                cmd.Parameters.AddWithValue("Perfil", dts.gPerfil)



                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
        
            End Try

        End Using
    End Function



    Public Function borrar(ByVal iidPerfil As Integer) As Boolean
        Dim func As New FuncionesPersonal
        If func.ExistePerfil(iidPerfil) Then
            MsgBox("Existen usuarios en este perfil. No se puede borrar.")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = "delete from Perfiles where idPerfil = " & iidPerfil

            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    Dim t As Integer = cmd.ExecuteNonQuery()
                    con.Close()
                    Return t > 0

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
              
                End Try

            End Using
        End If

    End Function

End Class
