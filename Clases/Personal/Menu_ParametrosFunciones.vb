Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesMenu_Parametros
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar(ByVal iidMenu As Integer) As List(Of datosMenu_Parametro)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_Parametros Where idMenu = " & iidMenu, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosMenu_Parametro
                Dim lista As New List(Of datosMenu_Parametro)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts = New datosMenu_Parametro
                        dts.gidMenu = linea("idMenu")
                        dts.gParametro = If(linea("Parametro") Is DBNull.Value, "", linea("Parametro"))
                        dts.gValor = If(linea("Valor") Is DBNull.Value, False, linea("Valor"))
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

    Public Function mostrar1(ByVal iidMenu As Integer, ByVal sParametro As String) As datosMenu_Parametro
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("select * from Menu_Entradas Where idMenu = " & iidMenu & " AND Parametro = " & sParametro, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New datosMenu_Parametro
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idMenu") Is DBNull.Value Then
                    Else
                        dts.gidMenu = linea("idMenu")
                        dts.gParametro = If(linea("Parametro") Is DBNull.Value, "", linea("Parametro"))
                        dts.gValor = If(linea("Valor") Is DBNull.Value, False, linea("Valor"))
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

    Public Function insertar(ByVal dts As datosMenu_Parametro) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Menu_Parametros (idMenu, Parametro, Valor) values (@idMenu, @Parametro, @Valor) "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idMenu", dts.gidMenu)
                cmd.Parameters.AddWithValue("Parametro", dts.gParametro)
                cmd.Parameters.AddWithValue("Valor", dts.gValor)
                con.Open()

                Return cmd.ExecuteScalar() > 0

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosMenu_Parametro) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Menu_Parametros set Valor = @Valor  where idMenu = @idMenu AND Parametro = @Parametro "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idMEnu", dts.gidMenu)
                cmd.Parameters.AddWithValue("Parametro", dts.gParametro)
                cmd.Parameters.AddWithValue("Valor", dts.gValor)
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

    Public Function CampoValor(ByVal sEjecutar As String, ByVal sParamentro As String) As Boolean
        'Obtiene el valor por defecto de un parámetro
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select Valor from Menu_Parametros left join Menu_Entradas ON Menu_Entradas.idMenu = Menu_Parametros.idMenu where ejecutar = '" & sEjecutar & "' AND Parametro = '" & sParamentro & "' "
            'Using con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

            'End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function borrar(ByVal iidMenu As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Menu_Parametros where idmenu = " & iidMenu

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
