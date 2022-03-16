

Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesPaises
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function mostrar() As List(Of datosPais)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of datosPais)
            cmd = New SqlCommand("select Paises.*, Divisa from Paises LEFT JOIN Monedas ON Monedas.codMoneda = Paises.codMoneda order by Pais ASC ", con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As datosPais
                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts = New datosPais
                    dts.gidPais = linea("idPais")
                    dts.gPais = If(linea("pais") Is DBNull.Value, "", linea("Pais"))
                    dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                    dts.gNIFObligatorio = If(linea("NIFObligatorio") Is DBNull.Value, False, linea("NIFObligatorio"))
                    dts.gcodPais = If(linea("codPais") Is DBNull.Value, "", linea("codPais"))
                    dts.gExportacion = If(linea("Exportacion") Is DBNull.Value, False, linea("Exportacion"))
                    dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))
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


    Public Function mostrar1(ByVal iidPais As Integer) As datosPais

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim dts As New datosPais
            cmd = New SqlCommand("select Paises.*, Divisa from Paises LEFT JOIN Monedas ON Monedas.codMoneda = Paises.codMoneda Where idPais = " & iidPais & " order by Pais ASC ", con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                Dim linea As DataRow
                For Each linea In dt.Rows
                    dts.gidPais = linea("idPais")
                    dts.gPais = If(linea("pais") Is DBNull.Value, "", linea("Pais"))
                    dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                    dts.gNIFObligatorio = If(linea("NIFObligatorio") Is DBNull.Value, False, linea("NIFObligatorio"))
                    dts.gcodPais = If(linea("codPais") Is DBNull.Value, "", linea("codPais"))
                    dts.gExportacion = If(linea("Exportacion") Is DBNull.Value, False, linea("Exportacion"))
                    dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))

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



    Public Function encuentraPais(ByVal idPais As Integer) As String

        Try
            If idPais = 0 Then
                Return "ESPAÑA"
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim resultado As String = ""
                cmd = New SqlCommand("select Pais from Paises where idPais = " & idPais, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return ""
                Else
                    Return CStr(o)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function idPais(ByVal sPais As String) As Integer

        Try
            sPais = Trim(UCase(sPais))
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim resultado As String = ""
            cmd = New SqlCommand("select idPais from Paises where upper(Pais) = '" & sPais & "' ", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function NIFObligatorio(ByVal iidPais As Integer) As Boolean

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim resultado As String = ""
            cmd = New SqlCommand("select NIFObligatorio from Paises where idPais = " & iidPais, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CBool(o)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function CampoDivisa(ByVal idPais As Integer) As String

        Try
            If idPais = 0 Then
                Return "ESPAÑA"
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim resultado As String = ""
                cmd = New SqlCommand("select Divisa from Paises left join Monedas ON Monedas.codMoneda = Paises.codMoneda where idPais = " & idPais, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar()
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return ""
                Else
                    Return CStr(o)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function insertar(ByVal dts As datosPais) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Paises (Pais, codMoneda, NIFObligatorio, codPais, Exportacion) values (@Pais, @codMoneda, @NIFObligatorio, @codPais, @Exportacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Pais", dts.gPais)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("NIFObligatorio", dts.gNIFObligatorio)
                cmd.Parameters.AddWithValue("codPais", dts.gcodPais)
                cmd.Parameters.AddWithValue("Exportacion", dts.gExportacion)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosPais) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update Paises set Pais = @Pais,codMoneda = @codMoneda, NIFObligatorio = @NIFObligatorio, codPais = @codPais, Exportacion = @Exportacion where idPais = @idPais "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idPais", dts.gidPais)
                cmd.Parameters.AddWithValue("Pais", dts.gPais)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("NIFObligatorio", dts.gNIFObligatorio)
                cmd.Parameters.AddWithValue("codPais", dts.gcodPais)
                cmd.Parameters.AddWithValue("Exportacion", dts.gExportacion)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
         
            End Try

        End Using
    End Function

    Public Function borrar(ByVal iidPais As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from Paises where idPais = " & iidPais

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            Finally
                desconectado()
            End Try

        End Using
    End Function




End Class
