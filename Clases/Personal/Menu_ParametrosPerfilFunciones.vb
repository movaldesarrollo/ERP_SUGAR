Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMenu_ParametrosPerfil
    Inherits conexion
    Dim cmd As SqlCommand
    'Public Function fvercostes(ByVal iidMenu As Integer, ByVal iidPerfil As Integer) As Boolean
    '    Try
    '        Dim sconexion As String = CadenaConexion()
    '        Dim con As New SqlConnection(sconexion)
    '        Dim sel As String
    '        sel = "select * from Menu_ParametrosPerfil Where idMenu = 119 AND idPerfil = " & iidPerfil

    '    Catch ex As Exception

    '    End Try
    'End Function

    Public Function mostrar(ByVal iidMenu As Integer, ByVal iidPerfil As Integer) As List(Of datosMenu_ParametrosPerfil)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidMenu = 0 Then
                sel = "select * from Menu_ParametrosPerfil Where idPerfil = " & iidPerfil
            Else
                sel = "select * from Menu_ParametrosPerfil Where idMenu = " & iidMenu & " AND idPerfil = " & iidPerfil
            End If
            cmd = New SqlCommand(sel, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_ParametrosPerfil
                Dim lista As New List(Of datosMenu_ParametrosPerfil)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_ParametrosPerfil
                        dts.gidMenu = linea("idMenu")
                        dts.gParametro = If(linea("Parametro") Is DBNull.Value, "", linea("Parametro"))
                        dts.gValor = If(linea("Valor") Is DBNull.Value, False, linea("Valor"))
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
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

    Public Function mostrar1(ByVal iidMenu As Integer, ByVal iidPerfil As Integer, ByVal sParametro As String) As datosMenu_ParametrosPerfil
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_ParametrosPerfil Where idMenu = " & iidMenu & " AND idPerfil = " & iidPerfil & " AND Parametro = " & sParametro, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_ParametrosPerfil
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts.gidMenu = linea("idMenu")
                        dts.gParametro = If(linea("Parametro") Is DBNull.Value, "", linea("Parametro"))
                        dts.gValor = If(linea("Valor") Is DBNull.Value, False, linea("Valor"))
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gidPerfil = If(linea("idPerfil") Is DBNull.Value, 0, linea("idPerfil"))
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



    Public Function Parametro(ByVal iidPerfil As Integer, ByVal sEjecutar As String, ByVal bParametro As String) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Valor from Menu_ParametrosPerfil as MPU left join Menu_Entradas On Menu_Entradas.idMenu = MPU.idMenu where Ejecutar = '" & sEjecutar & "' AND idPerfil = " & iidPerfil & " and Parametro ='" & bParametro & "' ", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                'Si no le encontramos, devolvemos el valor por defecto del parámetro
                Dim func As New funcionesMenu_Parametros
                Return func.CampoValor(sEjecutar, bParametro)
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




    Public Function insertar(ByVal dts As datosMenu_ParametrosPerfil) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Menu_ParametrosPerfil (idPerfil, idMenu, Parametro, Valor, idPersona, Cuando) values (@idPerfil, @idMenu, @Parametro, @Valor, @idPersona, @Cuando) "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idPerfil", dts.gidPerfil)
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



    Public Function actualizar(ByVal dts As datosMenu_ParametrosPerfil) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Menu_ParametrosPerfil set Valor = @Valor  where idPerfil = @idPerfil AND idMenu = @idMenu AND Parametro = @Parametro "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idPerfil", dts.gidPerfil)
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


    Public Function borrar(ByVal iidPerfil As Integer, ByVal iidMenu As Integer) As Boolean
        'Borra todos los parámetros de la entrada de menú del usuario
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_ParametrosPerfil where idPerfil = " & iidPerfil & " AND idMenu = " & iidMenu

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


    Public Function borrar(ByVal iidPerfil As Integer) As Boolean
        'Borra todos los parámetros del usuario
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_ParametrosPerfil where idPerfil = " & iidPerfil

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
