Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Imports System.Text.RegularExpressions

Public Class FuncionesTelefonos
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function MostrarProveedor(ByVal iidProveedor As Integer) As List(Of DatosTelefono)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Telefonos.*, TipoTelefono FROM Telefonos Left Join TiposTelefono ON TiposTelefono.idTipoTelefono = Telefonos.idTipoTelefono WHERE idProveedor = " & iidProveedor & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTelefono
                Dim lista As New List(Of DatosTelefono)
                For Each linea In dt.Rows
                    dts = New DatosTelefono
                    dts.gidProveedor = linea("idProveedor")
                    dts.gidUbicacion = 0
                    dts.gidContacto = 0
                    dts.gidCliente = 0
                    dts.gidTipoTelefono = If(linea("idTipoTelefono") Is DBNull.Value, 0, linea("idTipoTelefono"))
                    dts.gTipoTelefono = If(linea("TipoTelefono") Is DBNull.Value, "", linea("TipoTelefono"))
                    dts.gTelefono = If(linea("Telefono") Is DBNull.Value, "", linea("Telefono"))
                    dts.gOrden = If(linea("Orden") Is DBNull.Value, 1, linea("Orden"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function MostrarProveedorStr(ByVal iidProveedor As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Telefonos WHERE idProveedor = " & iidProveedor & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim Resultado As String = ""
                For Each linea In dt.Rows
                    If Resultado <> "" Then Resultado = Resultado & ", "
                    Resultado = Resultado & If(linea("Telefono") Is DBNull.Value, "", linea("Telefono"))
                Next
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function MostrarUbicacion(ByVal iidUbicacion As Integer) As List(Of DatosTelefono) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Telefonos.*, TipoTelefono FROM Telefonos Left Join TiposTelefono ON TiposTelefono.idTipoTelefono = Telefonos.idTipoTelefono WHERE idUbicacion = " & iidUbicacion & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTelefono
                Dim lista As New List(Of DatosTelefono)
                For Each linea In dt.Rows
                    dts = New DatosTelefono
                    dts.gidProveedor = 0
                    dts.gidUbicacion = linea("idUbicacion")
                    dts.gidContacto = 0
                    dts.gidCliente = 0
                    dts.gidTipoTelefono = If(linea("idTipoTelefono") Is DBNull.Value, 0, linea("idTipoTelefono"))
                    dts.gTipoTelefono = If(linea("TipoTelefono") Is DBNull.Value, "", linea("TipoTelefono"))
                    dts.gTelefono = If(linea("Telefono") Is DBNull.Value, "", linea("Telefono"))
                    dts.gOrden = If(linea("Orden") Is DBNull.Value, 1, linea("Orden"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function MostrarUbicacionStr(ByVal iidUbicacion As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Telefonos WHERE idUbicacion = " & iidUbicacion & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim Resultado As String = ""
                For Each linea In dt.Rows
                    If Resultado <> "" Then Resultado = Resultado & "; "
                    Resultado = Resultado & If(linea("Telefono") Is DBNull.Value, "", linea("Telefono"))
                Next
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Mostrar1(ByVal iidUbicacion As Integer, ByVal iidContacto As Integer, ByVal iidTipoTelefono As Integer, ByVal Orden As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Telefono FROM Telefonos "
            If iidContacto <> 0 Then
                sel = sel & " WHERE idContacto = " & iidContacto & " AND  idTipoTelefono = " & iidTipoTelefono & " AND  Orden = " & Orden
            ElseIf iidUbicacion <> 0 Then
                sel = sel & " WHERE idUbicacion = " & iidUbicacion & " AND  idTipoTelefono = " & iidTipoTelefono & " AND  Orden = " & Orden
            End If

            cmd = New SqlCommand(sel, con)
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
        End Try
    End Function

    Public Function MostrarContacto(ByVal iidContacto As Integer) As List(Of DatosTelefono) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Telefonos.*, TipoTelefono FROM Telefonos Left Join TiposTelefono ON TiposTelefono.idTipoTelefono = Telefonos.idTipoTelefono WHERE idContacto = " & iidContacto & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTelefono
                Dim lista As New List(Of DatosTelefono)
                For Each linea In dt.Rows
                    dts = New DatosTelefono
                    dts.gidProveedor = 0
                    dts.gidUbicacion = 0
                    dts.gidContacto = linea("idContacto")
                    dts.gidCliente = 0
                    dts.gidTipoTelefono = If(linea("idTipoTelefono") Is DBNull.Value, 0, linea("idTipoTelefono"))
                    dts.gTipoTelefono = If(linea("TipoTelefono") Is DBNull.Value, "", linea("TipoTelefono"))
                    dts.gTelefono = If(linea("Telefono") Is DBNull.Value, "", linea("Telefono"))
                    dts.gOrden = If(linea("Orden") Is DBNull.Value, 1, linea("Orden"))
                    lista.Add(dts)
                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function MostrarContactoStr(ByVal iidContacto As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Telefonos WHERE idContacto = " & iidContacto & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim Resultado As String = ""
                For Each linea In dt.Rows
                    If Resultado <> "" Then Resultado = Resultado & "; "
                    Resultado = Resultado & If(linea("Telefono") Is DBNull.Value, "", linea("Telefono"))
                Next
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

   
   





    Public Function insertar(ByVal dts As DatosTelefono) As Integer
        'Insertar una nuevo tipo de caducidad
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Telefonos (idProveedor, idUbicacion, idContacto, idCliente, idTipoTelefono, Telefono, Orden) values "
            sel = sel & " ( @idProveedor, @idUbicacion, @idContacto,@idCliente, @idTipoTelefono, @Telefono, @Orden) "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)

                cmd.Parameters.AddWithValue("idTipoTelefono", dts.gidTipoTelefono)
                cmd.Parameters.AddWithValue("Telefono", dts.gTelefono)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                con.Open()
                Dim o As Object = cmd.ExecuteNonQuery()
                con.Close()
                If o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If
            End Using
           

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function




    Public Function borrarUbicacion(ByVal iidUbicacion As Integer) As Boolean
        'Borramos los mails de un Ubicacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Telefonos where idUbicacion = " & iidUbicacion
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrarContacto(ByVal iidContacto As Integer) As Boolean
        'Borramos los mails de un Contacto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Telefonos where idContacto = " & iidContacto
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrarProveedor(ByVal iidProveedor As Integer) As Boolean
        'Borramos los mails de un Contacto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Telefonos where idProveedor = " & iidProveedor
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean
        'Borramos los mails de un Contacto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Telefonos where idCliente = " & iidCliente
            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

End Class



