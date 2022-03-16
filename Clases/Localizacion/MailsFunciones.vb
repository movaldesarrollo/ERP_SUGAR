Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Imports System.Text.RegularExpressions

Public Class FuncionesMails
    Inherits conexion
    Dim cmd As SqlCommand


   

    Public Function MostrarProveedor(ByVal iidProveedor As Integer) As List(Of DatosMail) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Mails WHERE idProveedor = " & iidProveedor & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosMail
                Dim lista As New List(Of DatosMail)
                For Each linea In dt.Rows
                    dts = New DatosMail
                    dts.gidProveedor = linea("idProveedor")
                    dts.gidUbicacion = 0
                    dts.gidContacto = 0
                    dts.gidTipoCompra = 0
                    dts.gmail = If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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
            sel = "SELECT * FROM Mails WHERE idProveedor = " & iidProveedor & " order by Orden ASC "
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
                    Resultado = Resultado & If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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

    Public Function MostrarUbicacion(ByVal iidUbicacion As Integer) As List(Of DatosMail) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Mails WHERE idUbicacion = " & iidUbicacion & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosMail
                Dim lista As New List(Of DatosMail)
                For Each linea In dt.Rows
                    dts = New DatosMail
                    dts.gidProveedor = 0
                    dts.gidUbicacion = linea("idUbicacion")
                    dts.gidContacto = 0
                    dts.gidTipoCompra = 0
                    dts.gmail = If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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

    Public Function MostrarUbicacionStr(ByVal iidUbicacion As Integer, ByVal noContacto As Boolean) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Mails WHERE idUbicacion = " & iidUbicacion & If(noContacto, " AND idContacto = 0 ", "") & " order by Orden ASC "
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
                    Resultado = Resultado & If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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

    Public Function MostrarContacto(ByVal iidContacto As Integer) As List(Of DatosMail) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Mails WHERE idContacto = " & iidContacto & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosMail
                Dim lista As New List(Of DatosMail)
                For Each linea In dt.Rows
                    dts = New DatosMail
                    dts.gidProveedor = 0
                    dts.gidUbicacion = 0
                    dts.gidContacto = linea("idContacto")
                    dts.gidTipoCompra = 0
                    dts.gmail = If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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
            sel = "SELECT * FROM Mails WHERE idContacto = " & iidContacto & " order by Orden ASC "
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
                    Resultado = Resultado & If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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

    Public Function MostrarTipoCompra(ByVal iidTipoCompra As Integer) As List(Of DatosMail) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Mails WHERE idTipoCompra = " & iidTipoCompra & " order by Orden ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosMail
                Dim lista As New List(Of DatosMail)
                For Each linea In dt.Rows
                    dts = New DatosMail
                    dts.gidProveedor = 0
                    dts.gidUbicacion = 0
                    dts.gidContacto = 0
                    dts.gidTipoCompra = linea("idTipoCompra")
                    dts.gmail = If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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

    Public Function MostrarTipoCompraStr(ByVal iidTipoCompra As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM Mails WHERE idTipoCompra = " & iidTipoCompra & " order by Orden ASC "
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
                    Resultado = Resultado & If(linea("Mail") Is DBNull.Value, "", linea("Mail"))
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

  
    Public Function Valida(ByVal Mail As String) As Boolean
        ' validación de una dirección de mail
        'Return Regex.Match(Mail, "^[a-z0-9._-]+@[a-z0-9.-]+\.[a-z]{2,3,4}$").Success()
        Return Regex.Match(Mail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,6})$").Success()

    End Function

  



    Public Function insertar(ByVal dts As DatosMail) As Integer
        'Insertar una nuevo tipo de caducidad
        Try
            If Valida(dts.gmail) Then
                Dim sconexion As String = CadenaConexion()
                Dim sel As String
                sel = "insert into Mails ( idProveedor, idUbicacion, idContacto,idTipoCompra, idCliente, Mail, Orden) values ( @idProveedor, @idUbicacion, @idContacto,@idTipoCompra, @idCliente, @Mail, @Orden) "
                Using con As New SqlConnection(sconexion)

                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                    cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                    cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                    cmd.Parameters.AddWithValue("idTipoCompra", dts.gidTipoCompra)
                    cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                    cmd.Parameters.AddWithValue("Mail", dts.gmail)
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
            Else
                MsgBox("Dirección de mail " & dts.gmail & " no válida.")
                Return 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

  


    Public Function borrarUbicacion(ByVal iidUbicacion As Integer) As Boolean
        'Borramos los mails de un Ubicacion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Mails where idUbicacion = " & iidUbicacion
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
            Dim sel As String = "delete from Mails where idContacto = " & iidContacto
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
            Dim sel As String = "delete from Mails where idProveedor = " & iidProveedor
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
            Dim sel As String = "delete from Mails where idCliente = " & iidCliente
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

    Public Function borrarTipoCompra(ByVal iidTipoCompra As Integer) As Boolean
        'Borramos los mails de un TipoCompra
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Mails where idTipoCompra = " & iidTipoCompra
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



