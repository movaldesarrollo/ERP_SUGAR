Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMenu_EntradasUsuario
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal iidUsuario As Integer) As List(Of datosMenu_EntradasUsuario)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Menu_EntradasUsuario.*, Nivel,Nombre,idMenuPadre,Ejecutar,Orden from Menu_EntradasUsuario Left Join Menu_Entradas ON Menu_Entradas.idMenu = Menu_EntradasUsuario.idMenu where idUsuario = " & iidUsuario & " ORDER By Nivel ASC, Orden ASC ", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_EntradasUsuario
                Dim lista As New List(Of datosMenu_EntradasUsuario)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_EntradasUsuario
                        dts.gidMenu = linea("idMenu")
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPErsona"))
                        dts.gidUsuario = If(linea("idUsuario") Is DBNull.Value, 0, linea("idUsuario"))
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
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrarME(ByVal iidUsuario As Integer) As List(Of datosMenu_Entrada)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Menu_EntradasUsuario.*, Nivel,Nombre,idMenuPadre,Ejecutar,Orden from Menu_EntradasUsuario Left Join Menu_Entradas ON Menu_Entradas.idMenu = Menu_EntradasUsuario.idMenu where idUsuario = " & iidUsuario & " ORDER By Nivel ASC, Orden ASC ", con)

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
                        'dts.gidUsuario = If(linea("idUsuario") Is DBNull.Value, 0, linea("idUsuario"))
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
        Finally
            desconectado()
        End Try
    End Function

    Public Function mostrar1(ByVal iidUsuario As Integer, ByVal iidMenu As Integer) As datosMenu_EntradasUsuario
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Menu_EntradasUsuario.*, Nivel,Nombre,idMenuPadre,Ejecutar,Orden from Menu_EntradasUsuario Left Join Menu_Entradas ON Menu_Entradas.idMenu = Menu_EntradasUsuario.idMenu, where idUsuario = " & iidUsuario & " AND idMenu = " & iidMenu & " ORDER By Nivel ASC, Orden ASC ", con)


            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_EntradasUsuario
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts.gidMenu = linea("idMenu")
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPErsona"))
                        dts.gidUsuario = If(linea("idUsuario") Is DBNull.Value, 0, linea("idUsuario"))
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
        Finally
            desconectado()
        End Try
    End Function

    Public Function Literales(ByVal iidPersona As Integer) As List(Of IDComboBox)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select id1 , Nombre3 + case when Nombre3 <>'' and Nombre2 <> '' then ' | ' else '' end + Nombre2 + case when Nombre2 <> '' and Nombre1 <> '' then ' | ' else '' end + Nombre1 as literal "
            sel = sel & " from ( select "
            sel = sel & " case when ME3.Nombre is null or ME3.Nombre = 'Raiz' then '' else ME3.Nombre end as Nombre3,"
            sel = sel & " case when ME2.Nombre = 'Raiz' then '' else ME2.Nombre end as Nombre2,"
            sel = sel & " case when ME1.Nombre = 'Raiz' or ME2.Nombre = 'Raiz' then '' else ME1.Nombre end as Nombre1, ME3.idmenu as id3, ME2.idmenu as id2, ME1.idmenu as id1"

            sel = sel & " from Menu_Entradas as ME1 left join Menu_Entradas as ME2 on ME1.idmenupadre =ME2.idmenu left join Menu_Entradas as ME3 on ME2.idmenupadre=ME3.idmenu "
            'sel = sel & " Union select '' as Nombre3,Nombre as Nombre2,'' as Nombre3 , idMenu as id1, idMenu as id2, idMenu as id3 from Menu_Entradas where idMenuPadre=0 and Nombre <> 'Raiz' "
            sel = sel & ")X where (Nombre1<>'' or Nombre2<>'' or Nombre3<>'') "

            If ExisteUsuario(iidPersona) Then
                sel = sel & " and ( id1 in (select idmenu from Menu_EntradasUsuario where idUsuario = " & iidPersona & ") "
                sel = sel & " or id2 in (select idmenu from Menu_EntradasUsuario where idUsuario = " & iidPersona & ") )"
            Else
                Dim func As New FuncionesPersonal
                sel = sel & " and  ( id1 in (select idmenu from Menu_EntradasPerfil where idPerfil = " & func.campoidPerfil(iidPersona) & ")) "
                'sel = sel & " or id2 in (select idmenu from Menu_EntradasPerfil where idPerfil = " & func.campoidPerfil(iidPersona) & ") ) "
            End If
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of IDComboBox)
            Dim par As IDComboBox
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_Entrada
                Dim linea As DataRow
                For Each linea In dt.Rows
                    par = New IDComboBox
                    par.Name = If(linea("literal") Is DBNull.Value, "", linea("literal"))
                    par.ItemData = If(linea("id1") Is DBNull.Value, 0, linea("id1"))
                    lista.Add(par)
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As datosMenu_EntradasUsuario) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Menu_EntradasUsuario (idUsuario, idMenu,idPersona, Cuando) values (@idUsuario, @idMenu, @idPersona, @Cuando) "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idUsuario", dts.gidUsuario)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Cuando", Now)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                con.Open()

                Return cmd.ExecuteScalar() > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function

    Public Function Existe(ByVal dts As datosMenu_EntradasUsuario) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select idUsuario from Menu_EntradasUsuario  where idUsuario = @idUsuario and idMenu = @idMenu"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idUsuario", dts.gidUsuario)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return CInt(o) = dts.gidUsuario
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function

    Public Function ExisteUsuario(ByVal iidUsuario As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select idUsuario from Menu_EntradasUsuario  where idUsuario = " & iidUsuario

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
               
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return False
                Else
                    Return CInt(o) = iidUsuario
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function

    Public Sub Refrescar(ByVal dts As datosMenu_EntradasUsuario, ByVal Valor As Boolean)
        Dim ExisteEntrada As Boolean = Existe(dts)
        If ExisteEntrada And Valor Then
            Call actualizar(dts)
        End If
        If ExisteEntrada And Not Valor Then
            Call borrar(dts.gidUsuario, dts.gidMenu)
        End If

        If Not ExisteEntrada And Valor Then
            Call insertar(dts)
        End If

        If Not ExisteEntrada And Not Valor Then
            'Perfecto
        End If

    End Sub

    Public Function actualizar(ByVal dts As datosMenu_EntradasUsuario) As Boolean
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = "update Menu_EntradasUsuario set  idPersona = @idPersona,  Cuando = @Cuando  where idMenu = @idMenu and idUsuario= @idUsuario"

            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idUsuario", dts.gidUsuario)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Cuando", Now)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)

                'abrir conexion
                con.Open()

                'ejecutar el sql
                Return cmd.ExecuteNonQuery() > 0
            End Using


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        Finally
            desconectado()
        End Try





    End Function

    Public Function borrar(ByVal iidUsuario As Integer, ByVal iidMenu As Integer) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_EntradasUsuario where idMenu = " & iidMenu & " AND idUsuario = " & iidUsuario

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Return cmd.ExecuteNonQuery() > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using



    End Function

    Public Function borrarUsuario(ByVal iidUsuario As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_EntradasUsuario where idUsuario = " & iidUsuario

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Return cmd.ExecuteNonQuery() > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function

End Class
