Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesEstatusReparacion
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosEstatusReparacion) 'Devuelve los datos de una Estatus como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT * FROM EstatusReparaciones " & If(SoloActivos, " where Activo = 1 ", "") & " ORDER BY Estatus ASC "

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEstatusReparacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosEstatusReparacion

                For Each linea In dt.Rows
                    If linea("idEstatus") Is DBNull.Value Then
                    Else
                        dts = New DatosEstatusReparacion
                        dts.gidEstatus = linea("idEstatus")
                        dts.gEstatus = If(linea("Estatus") Is DBNull.Value, "", linea("Estatus"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
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

    Public Function Mostrar1(ByVal iidEstatus As Integer) As DatosEstatusReparacion 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "SELECT * FROM EstatusReparaciones WHERE idEstatus = " & iidEstatus
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEstatusReparacion

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idEstatus") Is DBNull.Value Then
                    Else
                        dts.gidEstatus = linea("idEstatus")
                        dts.gEstatus = If(linea("Estatus") Is DBNull.Value, "", linea("Estatus"))
                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                        dts.gActivo = If(linea("Activo") Is DBNull.Value, False, linea("Activo"))
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


    Public Function Campo(ByVal vCampo As String, ByVal iidEstatus As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM EstatusReparaciones WHERE idEstatus = " & iidEstatus, con)

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

    Public Function Estatus(ByVal iidEstatus As Integer) As String  'Devuelve el nombre de la Estatus
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Estatus from EstatusReparaciones WHERE idEstatus = " & iidEstatus, con)
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

    Public Function idEstatus(ByVal Estatus As String) As Integer  'Devuelve el id de la Estatus
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idEstatus from EstatusReparaciones WHERE Estatus = '" & Estatus & "' ", con)
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

    Public Function EnUso(ByVal iidEstatus As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select count(numReparacion) from Reparaciones WHERE idEstatus = " & iidEstatus, con)
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
        End Try
    End Function


    Public Function Descripcion(ByVal iidEstatus As Integer) As String  'Devuelve el nombre de la Estatus
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from EstatusReparaciones WHERE idEstatus = " & iidEstatus, con)
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



    Public Function Activo(ByVal iidEstatus As Integer) As Boolean  'Devuelve el nombre de la Estatus
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Activo from EstatusReparaciones WHERE idEstatus = " & iidEstatus, con)
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



    Public Function insertar(ByVal dts As DatosEstatusReparacion) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into EstatusReparaciones ( Estatus, Descripcion, Activo) values ( @Estatus, @Descripcion, @Activo) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Estatus", dts.gEstatus)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)

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

    Public Function actualizar(ByVal dts As DatosEstatusReparacion) As Boolean
        'Actualiza un registro de la tabla MP_Tipos con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update EstatusReparaciones set  Estatus = @Estatus, Descripcion = @Descripcion, Activo = @Activo  WHERE idEstatus = " & dts.gidEstatus

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("Estatus", dts.gEstatus)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)

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

    Public Function borrar(ByVal iidEstatus As Integer) As Boolean
        'Borramos la Estatus si no hay ningun producto que lo tenga

        Dim func As New FuncionesReparaciones
        Dim contador As Integer = func.Contador(" idEstatus = " & iidEstatus)
        If contador > 0 Then
            MsgBox("Existen " & contador & " productos de este Tipo, por tanto no se puede borrar. En su lugar puede cambiar el nombre del Tipo .")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from EstatusReparacion where idEstatus = " & iidEstatus
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



