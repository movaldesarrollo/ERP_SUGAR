Imports System.Data.SqlClient
Imports System.Data.Sql



Public Class FuncionesTiposRetencion
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosTipoRetencion) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposRetencion  "
            sel = sel & If(SoloActivos, " WHERE Activo = 1 ", "") & " order by TipoRetencion ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTipoRetencion
                Dim lista As New List(Of DatosTipoRetencion)
                For Each linea In dt.Rows
                    dts = New DatosTipoRetencion
                    dts.gidTipoRetencion = linea("idTipoRetencion")
                    dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, "", linea("TipoRetencion"))
                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
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



    Public Function Mostrar1(ByVal iidTipoRetencion As Integer) As DatosTipoRetencion 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposRetencion  "
            sel = sel & " WHERE idTipoRetencion = " & iidTipoRetencion
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosTipoRetencion
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New DatosTipoRetencion
                    dts.gidTipoRetencion = linea("idTipoRetencion")
                    dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, "", linea("TipoRetencion"))
                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
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




    Public Function TipoRetencion(ByVal iidTipoRetencion As Integer) As Double 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoRetencion FROM TiposRetencion WHERE idTipoRetencion = " & iidTipoRetencion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CDbl(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Nombre(ByVal iidTipoRetencion As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Nombre FROM TiposRetencion WHERE idTipoRetencion = " & iidTipoRetencion
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

    Public Function General() As String 'Devuelve el tipo general
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoRetencion FROM TiposRetencion WHERE Nombre = 'GENERAL'"
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


    Public Function EnUso(ByVal iidTipoRetencion As Integer) As Integer

        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = " SELECT  count(idTipoRetencion) as Contador FROM Facturacion where idTipoRetencion = " & iidTipoRetencion
            sel = sel & " + (Select count(idTipoIVA) as Contador FROM Ofertas where idTipoRetencion = " & iidTipoRetencion & ") "

            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
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


    Public Function insertar(ByVal dts As DatosTipoRetencion) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into TiposRetencion (TipoRetencion, Nombre, Descripcion, Activo) values ( @TipoRetencion, @Nombre, @Descripcion, @Activo) select @@identity"
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencion)
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
            End Using


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Actualizar(ByVal dts As DatosTipoRetencion) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "Update TiposRetencion  set TipoRetencion = @TipoRetencion, Nombre = @Nombre, Descripcion = @Descripcion, Activo = @Activo where idTipoRetencion = @idTipoRetencion "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencion)
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
            End Using


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function borrar(ByVal iidTipoRetencion As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from TiposRetencion where idTipoRetencion = " & iidTipoRetencion
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



