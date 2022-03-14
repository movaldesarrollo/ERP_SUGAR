Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Public Class FuncionesBancos
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosBanco) 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Bancos.*, Pais FROM Bancos left join Paises on Paises.idPais = Bancos.idPais  " & If(SoloActivos, " WHERE Activo = 1 ", "") & "order by Banco ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosBanco)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As DatosBanco
                For Each linea In dt.Rows
                    dts = New DatosBanco
                    dts.gidBanco = linea("idBanco")
                    dts.gcodigoBanco = If(linea("codigoBanco") Is DBNull.Value, "0000", linea("codigoBanco"))
                    dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
                    dts.gSWIFT_BIC = If(linea("SWIFT_BIC") Is DBNull.Value, "", linea("SWIFT_BIC"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                    dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                    dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
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

    Public Function Mostrar1(ByVal iidBanco As Integer) As DatosBanco
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Bancos.*, Pais FROM Bancos left join Paises on Paises.idPais = Bancos.idPais where idBanco = " & iidBanco & " order by Banco ASC "
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosBanco
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New DatosBanco
                    dts.gidBanco = linea("idBanco")
                    dts.gcodigoBanco = If(linea("codigoBanco") Is DBNull.Value, "0000", linea("codigoBanco"))
                    dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
                    dts.gSWIFT_BIC = If(linea("SWIFT_BIC") Is DBNull.Value, "", linea("SWIFT_BIC"))
                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
                    dts.gidPais = If(linea("idPais") Is DBNull.Value, 0, linea("idPais"))
                    dts.gPais = If(linea("Pais") Is DBNull.Value, "", linea("Pais"))
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

    Public Function Banco(ByVal iidBanco As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Banco FROM Bancos WHERE idBanco = " & iidBanco
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

    Public Function Espanyol(ByVal iidBanco As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Pais FROM Bancos left join paises on Paises.idPais = Bancos.idPais WHERE idBanco = " & iidBanco
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CStr(0) = "ESPAÑA" Or CStr(0) = "ESPANYA"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function VerificarIBAN(ByVal iidBanco As Integer) As Boolean
        'Nos devuelve False si el pais no requiere NIF o está marcado como Exportación
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT case when Exportacion = 1 or NIFObligatorio = 0 then 0 else 1 end as VerificarIBAN FROM Bancos left join paises on Paises.idPais = Bancos.idPais WHERE idBanco = " & iidBanco
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SWIFT_BIC(ByVal iidBanco As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT SWIFT_BIC FROM Bancos WHERE idBanco = " & iidBanco
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CStr(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function codigoBanco(ByVal iidBanco As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT codigoBanco FROM Bancos WHERE idBanco = " & iidBanco
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

    Public Function insertar(ByVal dts As DatosBanco) As Integer
        'Insertar una nuevo 
        Try

            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Bancos (Banco, codigoBanco, SWIFT_BIC, Activo, idPais ) values (@Banco, @codigoBanco, @SWIFT_BIC, @Activo, @idPais) select @@identity "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Banco", dts.gBanco)
                cmd.Parameters.AddWithValue("codigoBanco", dts.gcodigoBanco)
                cmd.Parameters.AddWithValue("SWIFT_BIC", dts.gSWIFT_BIC)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idPais", dts.gidPais)

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

    Public Function actualizar(ByVal dts As DatosBanco) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Bancos set Banco = @Banco, codigoBanco = @CodigoBanco, SWIFT_BIC = @SWIFT_BIC, Activo = @Activo, idPais = @idPais WHERE idBanco = " & dts.gidBanco

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idBanco", dts.gidBanco)
                cmd.Parameters.AddWithValue("Banco", dts.gBanco)
                cmd.Parameters.AddWithValue("codigoBanco", dts.gcodigoBanco)
                cmd.Parameters.AddWithValue("SWIFT_BIC", dts.gSWIFT_BIC)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idPais", dts.gidPais)


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
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidBanco As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from Bancos where idBanco = " & iidBanco
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



