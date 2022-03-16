Imports System.Data.SqlClient
Imports System.Data.Sql



Public Class FuncionesTiposIVA
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosTipoIVA) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of DatosTipoIVA)
            sel = "SELECT * FROM TiposIVA  "
            sel = sel & If(SoloActivos, " WHERE Activo = 1 ", "") & " ORDER BY TipoIVA ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosTipoIVA
                For Each linea In dt.Rows
                    dts = New DatosTipoIVA
                    dts.gidTipoIVA = linea("idTipoIVA")
                    dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                    dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                    lista.Add(dts)
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

    Public Function Mostrardt(ByVal SoloActivos As Boolean) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dt As New DataTable
            sel = "SELECT * FROM TiposIVA  "
            sel = sel & If(SoloActivos, " WHERE Activo = 1 ", "") & " ORDER BY TipoIVA ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                con.Close()
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Mostrar1(ByVal iidTipoIVA As Integer) As DatosTipoIVA
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim dts As New DatosTipoIVA
            Dim sel As String
            sel = "SELECT * FROM TiposIVA  WHERE idTipoIVA = " & iidTipoIVA
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts.gidTipoIVA = linea("idTipoIVA")
                    dts.gNombre = If(linea("Nombre") Is DBNull.Value, "", linea("Nombre"))
                    dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                    dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
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



    Public Function TipoIVA(ByVal iidTipoIVA As Integer) As Double 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoIVA FROM TiposIVA WHERE idTipoIVA = " & iidTipoIVA
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


    Public Function TipoRecargoEq(ByVal iidTipoIVA As Integer) As Double 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoRecargoEq FROM TiposIVA WHERE idTipoIVA = " & iidTipoIVA
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


    Public Function Nombre(ByVal iidTipoIVA As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Nombre FROM TiposIVA WHERE idTipoIVA = " & iidTipoIVA
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
            sel = "SELECT TipoIVA FROM TiposIVA WHERE Nombre = 'GENERAL'"
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


    Public Function EnUso(ByVal iidTipoIVA As Integer) As Integer

        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String

            sel = " SELECT  count(idTipoIVA) as Contador FROM Facturacion where idTipoIVA = " & iidTipoIVA
            sel = sel & " + (Select count(idTipoIVA) as Contador FROM ConceptosOfertas where idTipoIVA = " & iidTipoIVA & ") "

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


    Public Function insertar(ByVal dts As DatosTipoIVA) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into TiposIVA (TipoIVA,TipoRecargoEq, Nombre, Descripcion, Activo) values ( @TipoIVA, @TipoRecargoEq, @Nombre, @Descripcion, @Activo) select @@identity"
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("Descripcion", dts.gDescripcion)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEq)
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

    Public Function Actualizar(ByVal dts As DatosTipoIVA) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "update TiposIVA  set  Nombre = @Nombre, TipoIVA = @TipoIVA, TipoRecargoEq = @TipoRecargoEq , Descripcion= @Descripcion, Activo = @Activo where idTipoIVA = @idTipoIVA "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEq)
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




    Public Function borrar(ByVal iidTipoIVA As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from TiposIVA where idTipoIVA = " & iidTipoIVA
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



