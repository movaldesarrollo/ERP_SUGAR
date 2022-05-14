Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMenu_EntradasPerfil
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal iidPerfil As Integer) As List(Of datosMenu_EntradasPerfil)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Menu_EntradasPerfil.* from Menu_EntradasPerfil Left Join Menu_Entradas ON Menu_Entradas.idMenu = Menu_EntradasPerfil.idMenu where idPerfil = " & iidPerfil & " ORDER By Nivel ASC, Orden ASC ", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_EntradasPerfil
                Dim lista As New List(Of datosMenu_EntradasPerfil)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_EntradasPerfil
                        dts.gidMenu = linea("idMenu")
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPErsona"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
                        dts.gCuando = If(linea("Cuando") Is DBNull.Value, Now, linea("Cuando"))
                        dts.gNivel = If(linea("Nivel") Is DBNull.Value, 0, linea("Nivel"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gidMenuPadre = If(linea("idMenuPadre") Is DBNull.Value, 0, linea("idMenuPadre"))
                        dts.gEjecutar = If(linea("Ejecutar") Is DBNull.Value, "", linea("Ejecutar"))

                        lista.Add(dts)
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function

    Public Function mostrarME(ByVal iidPerfil As Integer) As List(Of datosMenu_Entrada)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select me.idMenu, me.Nivel, me.Nombre, me.idMenuPadre, me.Ejecutar from Menu_EntradasPerfil meperf Left Join Menu_Entradas me ON me.idMenu = meperf.idMenu where meperf.idPerfil = " & iidPerfil & " ORDER By meperf.Nivel ASC, me.Orden ASC ", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_Entrada
                Dim lista As New List(Of datosMenu_Entrada)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_Entrada
                        dts.gidMenu = linea("idMenu")
                        'dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPErsona"))
                        'dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
                        'dts.gCuando = If(linea("Cuando") Is DBNull.Value, Now, linea("Cuando"))
                        dts.gNivel = If(linea("Nivel") Is DBNull.Value, 0, linea("Nivel"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gidMenuPadre = If(linea("idMenuPadre") Is DBNull.Value, 0, linea("idMenuPadre"))
                        dts.gEjecutar = If(linea("Ejecutar") Is DBNull.Value, "", linea("Ejecutar"))

                        lista.Add(dts)
                    End If
                Next
                Return lista
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
      
        End Try
    End Function

    Public Function mostrar1(ByVal iidPerfil As Integer, ByVal iidMenu As Integer) As datosMenu_EntradasPerfil
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Menu_EntradasPerfil.*, Nivel,Nombre,idMenuPadre,Ejecutar,Orden from Menu_EntradasPerfil Left Join Menu_Entradas ON Menu_Entradas.idMenu = Menu_EntradasPerfil.idMenu, where idPerfil = " & iidPerfil & " AND idMenu = " & iidMenu & " ORDER By Nivel ASC, Orden ASC ", con)


            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_EntradasPerfil
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts.gidMenu = linea("idMenu")
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPErsona"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
                        dts.gCuando = If(linea("Cuando") Is DBNull.Value, Now, linea("Cuando"))
                        dts.gNivel = If(linea("Nivel") Is DBNull.Value, 0, linea("Nivel"))
                        dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                        dts.gidMenuPadre = If(linea("idMenuPadre") Is DBNull.Value, 0, linea("idMenuPadre"))
                        dts.gEjecutar = If(linea("Ejecutar") Is DBNull.Value, "", linea("Ejecutar"))
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

    Public Function insertar(ByVal dts As datosMenu_EntradasPerfil) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Menu_EntradasPerfil (idPerfil, idMenu,idPersona, Cuando) values (@idPerfil, @idMenu, @idPersona, @Cuando) "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idPerfil", dts.gidPerfil)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Cuando", Now)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
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

    Public Function actualizar(ByVal dts As datosMenu_EntradasPerfil) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Menu_EntradasPerfil set idPerfil = @idPerfil, idPersona = @idPersona, idMenu = @idMenu, Cuando = @Cuando  where idMenu = @idMenu and idPersona = @idPersona"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idPerfil", dts.gidPerfil)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Cuando", Now)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)

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

    'Public Function borrar(ByVal iidPerfil As Integer, ByVal iidMenu As Integer) As Boolean
    '    Dim sconexion As String = CadenaConexion()
    '    Dim sel As String

    '    sel = "delete from Menu_EntradasPerfil where idMenu = " & iidMenu & " AND idPerfil = " & iidPerfil

    '    Using con As New SqlConnection(sconexion)
    '        Try
    '            'conectado()
    '            cmd = New SqlCommand(sel, con)
    '            'abrir conexion
    '            con.Open()
    '            Dim t As Integer = cmd.ExecuteNonQuery()
    '            con.Close()
    '            Return t > 0

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Return False

    '        End Try
    '    End Using
    'End Function

    Public Function borrar(ByVal iidPerfil As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_EntradasPerfil where idPerfil = " & iidPerfil

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
    End Function

    Public Function Permiso(ByVal iidPerfil As Integer, ByVal sEjecutar As String) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idPerfil from Menu_EntradasPerfil as MEP left join Menu_Entradas On Menu_Entradas.idMenu = MEP.idMenu where Ejecutar = '" & sEjecutar & "' AND idPerfil = " & iidPerfil, con)
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

End Class
