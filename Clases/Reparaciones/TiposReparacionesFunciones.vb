Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesTiposReparacion
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosTipoReparacion) 'Devuelve los datos de una TipoReparacion como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposReparacion " & If(SoloActivos, " where Activo = 1 ", "") & " ORDER BY TipoReparacion ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosTipoReparacion)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTipoReparacion

                For Each linea In dt.Rows
                    If linea("idTipoReparacion") Is DBNull.Value Then
                    Else
                        dts = New DatosTipoReparacion
                        dts.gidTipoReparacion = linea("idTipoReparacion")
                        dts.gTipoReparacion = If(linea("TipoReparacion") Is DBNull.Value, "", linea("TipoReparacion"))
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



    Public Function Mostrar1(ByVal iidTipoReparacion As Integer) As DatosTipoReparacion 'Devuelve los datos de una TipoReparacion como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposReparacion WHERE idTipoReparacion = " & iidTipoReparacion
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoReparacion

            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

                For Each linea In dt.Rows
                    If linea("idTipoReparacion") Is DBNull.Value Then
                    Else
                        dts.gidTipoReparacion = linea("idTipoReparacion")
                        dts.gTipoReparacion = If(linea("TipoReparacion") Is DBNull.Value, "", linea("TipoReparacion"))
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




    Public Function Campo(ByVal vCampo As String, ByVal iidTipoReparacion As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM TiposReparacion WHERE idTipoReparacion = " & iidTipoReparacion, con)

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

    Public Function TipoReparacion(ByVal iidTipoReparacion As Integer) As String  'Devuelve el nombre de la TipoReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoReparacion from TiposReparacion WHERE idTipoReparacion = " & iidTipoReparacion, con)
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

    Public Function EnUso(ByVal iidTipoReparacion As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select count(numReparacion) from Reparaciones WHERE idTipoReparacion = " & iidTipoReparacion, con)
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


    Public Function idTipoReparacion(ByVal TipoReparacion As String) As Integer  'Devuelve el id de la TipoReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idTipoReparacion from TiposReparacion WHERE TipoReparacion = '" & TipoReparacion & "' ", con)
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



    Public Function Descripcion(ByVal iidTipoReparacion As Integer) As String  'Devuelve el nombre de la TipoReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Descripcion from TiposReparacion WHERE idTipoReparacion = " & iidTipoReparacion, con)
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

 

    Public Function Activo(ByVal iidTipoReparacion As Integer) As Boolean  'Devuelve el nombre de la TipoReparacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Activo from TiposReparacion WHERE idTipoReparacion = " & iidTipoReparacion, con)
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



    Public Function insertar(ByVal dts As DatosTipoReparacion) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into TiposReparacion ( TipoReparacion, Descripcion, Activo) values ( @TipoReparacion, @Descripcion, @Activo) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoReparacion", dts.gTipoReparacion)
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

    Public Function actualizar(ByVal dts As DatosTipoReparacion) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TiposReparacion set  TipoReparacion = @TipoReparacion, Descripcion = @Descripcion, Activo = @Activo  WHERE idTipoReparacion = " & dts.gidTipoReparacion

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoReparacion", dts.gTipoReparacion)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
               
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

    Public Function borrar(ByVal iidTipoReparacion As Integer) As Boolean
        'Borramos la TipoReparacion si no hay ningun producto que lo tenga
        Dim func As New FuncionesReparaciones
        Dim contador As Integer = func.Contador(" idTipoReparacion = " & iidTipoReparacion)
        If contador > 0 Then
            MsgBox("Existen " & contador & " Reparaciones de este Tipo, por tanto no se puede borrar. En su lugar puede cambiar el nombre del Tipo .")
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from TiposReparacion where idTipoReparacion = " & iidTipoReparacion
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



