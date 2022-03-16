Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMenu_ParametrosUsuario
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal iidMenu As Integer, ByVal iidUsuario As Integer) As List(Of datosMenu_ParametrosUsuario)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_ParametrosUsuario Where idMenu = " & iidMenu & " AND idUsuario = " & iidUsuario, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_ParametrosUsuario
                Dim lista As New List(Of datosMenu_ParametrosUsuario)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_ParametrosUsuario
                        dts.gidMenu = linea("idMenu")
                        dts.gParametro = If(linea("Parametro") Is DBNull.Value, "", linea("Parametro"))
                        dts.gValor = If(linea("Valor") Is DBNull.Value, False, linea("Valor"))
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gidUsuario = If(linea("idUsuario") Is DBNull.Value, 0, linea("idUsuario"))
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

    Public Function mostrar1(ByVal iidMenu As Integer, ByVal iidUsuario As Integer, ByVal sParametro As String) As datosMenu_ParametrosUsuario
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_ParametrosUsuario Where idMenu = " & iidMenu & " AND idUsuario = " & iidUsuario & " AND Parametro = " & sParametro, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_ParametrosUsuario
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts.gidMenu = linea("idMenu")
                        dts.gParametro = If(linea("Parametro") Is DBNull.Value, "", linea("Parametro"))
                        dts.gValor = If(linea("Valor") Is DBNull.Value, False, linea("Valor"))
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gidUsuario = If(linea("idUsuario") Is DBNull.Value, 0, linea("idUsuario"))
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

    Public Function Parametro(ByVal iidUsuario As Integer, ByVal iidMenu As Integer, ByVal bParametro As String) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select Valor from Menu_ParametrosUsuario where idMenu = " & iidMenu & " AND idUsuario = " & iidUsuario & " and Parametro ='" & bParametro & "' ", con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function Parametro(ByVal iidPersona As Integer, ByVal sEjecutar As String, ByVal sParametro As String) As Boolean 'Nos dice si el formulario para el usuario es de solo lectura
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = "select Valor from Menu_ParametrosUsuario as MU left join Menu_Entradas ON Menu_Entradas.idMenu = MU.idMenu where Ejecutar = '" & sEjecutar & "' and MU.idUsuario = " & iidPersona & " AND Parametro = '" & sParametro & "' "

            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Dim funcPE As New FuncionesPersonal
                Dim iidPerfil As Integer = funcPE.campoidPerfil(iidPersona)
                Dim funcPP As New funcionesMenu_ParametrosPerfil
                Return funcPP.Parametro(iidPerfil, sEjecutar, sParametro)
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As datosMenu_ParametrosUsuario) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Menu_ParametrosUsuario (idUsuario, idMenu, Parametro, Valor, idPersona, Cuando) values (@idUsuario, @idMenu, @Parametro, @Valor, @idPersona, @Cuando) "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idUsuario", dts.gidUsuario)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                cmd.Parameters.AddWithValue("Parametro", dts.gParametro)
                cmd.Parameters.AddWithValue("Valor", dts.gValor)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Cuando", Now)
                con.Open()

                Return cmd.ExecuteScalar() > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using

    End Function

    Public Function Existe(ByVal dts As datosMenu_ParametrosUsuario) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "select idUsuario from Menu_ParametrosUsuario  where idUsuario = @idUsuario and idMenu = @idMenu AND Parametro = @Parametro"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idUsuario", dts.gidUsuario)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                cmd.Parameters.AddWithValue("Parametro", dts.gParametro)
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

    Public Sub Refrescar(ByVal dts As datosMenu_ParametrosUsuario)
        Dim ExisteEntrada As Boolean = Existe(dts)
        If ExisteEntrada And dts.gValor Then
            Call actualizar(dts)
        End If
        If ExisteEntrada And Not dts.gValor Then
            Call borrar(dts.gidUsuario, dts.gidMenu)
        End If

        If Not ExisteEntrada And dts.gValor Then
            Call insertar(dts)
        End If

        If Not ExisteEntrada And Not dts.gValor Then
            'Perfecto
        End If

    End Sub

    Public Function actualizar(ByVal dts As datosMenu_ParametrosUsuario) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Menu_ParametrosUsuario set Valor = @Valor  where idUsuario = @idUsuario AND idMenu = @idMenu AND Parametro = @Parametro "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idUsuario", dts.gidUsuario)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                cmd.Parameters.AddWithValue("Parametro", dts.gParametro)
                cmd.Parameters.AddWithValue("Valor", dts.gValor)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Cuando", Now)
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

    Public Function borrar(ByVal iidUsuario As Integer, ByVal iidMenu As Integer) As Boolean
        'Borra todos los parámetros de la entrada de menú del usuario
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_ParametrosUsuario where idUsuario = " & iidUsuario & " AND idMenu = " & iidMenu

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

    Public Function borrar(ByVal iidUsuario As Integer) As Boolean
        'Borra todos los parámetros del usuario
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_ParametrosUsuario where idUsuario = " & iidUsuario

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
