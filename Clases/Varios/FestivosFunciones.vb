
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesFestivos
    Inherits conexion
    Dim cmd As SqlCommand
    Private ListaFestivos As List(Of Date) = Nothing

    Public Function Mostrar(ByVal Anyo As Integer) As List(Of DatosFestivo)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM Festivos Where year(Fecha) = " & Anyo & " ORDER BY Fecha ASC", con)
            Dim lista As New List(Of DatosFestivo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosFestivo
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("Fecha") Is DBNull.Value Then
                    Else
                        dts = New DatosFestivo
                        dts.gFecha = linea("Fecha")
                        dts.gFestividad = If(linea("Festividad") Is DBNull.Value, "", linea("Festividad"))
                        dts.gRepetir = If(linea("Repetir") Is DBNull.Value, False, linea("Repetir"))
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


    Public Function Busqueda(ByVal sBusqueda As String) As List(Of DatosFestivo)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM Festivos Where " & sBusqueda, con)
            Dim lista As New List(Of DatosFestivo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosFestivo
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("Fecha") Is DBNull.Value Then
                    Else
                        dts = New DatosFestivo
                        dts.gFecha = linea("Fecha")
                        dts.gFestividad = If(linea("Festividad") Is DBNull.Value, "", linea("Festividad"))
                        dts.gRepetir = If(linea("Repetir") Is DBNull.Value, False, linea("Repetir"))
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




    Public Function Mostrar1(ByVal Fecha As Date) As DatosFestivo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM Festivos where Fecha =  @Fecha", con)
            Dim dts As New DatosFestivo
            cmd.Parameters.AddWithValue("Fecha", Fecha)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("Fecha") Is DBNull.Value Then
                    Else
                        dts = New DatosFestivo
                        dts.gFecha = linea("Fecha")
                        dts.gFestividad = If(linea("Festividad") Is DBNull.Value, "", linea("Festividad"))
                        dts.gRepetir = If(linea("Repetir") Is DBNull.Value, "", linea("Repetir"))
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



    Public Function Festividad(ByVal Fecha As Date) As String 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Festividad FROM Festivos WHERE Fecha = @Fecha ", con)
            cmd.Parameters.AddWithValue("Fecha", Fecha)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return Nothing
            Else
                Return CStr(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function EsFestividad(ByVal Fecha As Date) As Boolean
        Try
            If ListaFestivos Is Nothing Then
                Call CargarListaFestivos()
            End If
            Return ListaFestivos.Contains(Fecha)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Private Sub CargarListaFestivos()
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            ListaFestivos = New List(Of Date)
            cmd = New SqlCommand("SELECT Top 100 Fecha FROM Festivos Where Fecha >= getdate()", con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("Fecha") Is DBNull.Value Then
                    Else
                        ListaFestivos.Add(CDate(linea("Fecha")))
                    End If
                Next
            Else
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Public Function PrimerFestivoRepetido(ByVal Anyo As Integer) As Date 'Devuelve el primer festivo repetido del año
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Top 1 Fecha FROM Festivos WHERE Repetir = 1 and Year(Fecha) = " & Anyo, con)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
            If O Is DBNull.Value Or O Is Nothing Then
                Return Nothing
            Else
                Return CDate(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function EsFestivo(ByVal Fecha As Date) As Boolean
        If Fecha.DayOfWeek = DayOfWeek.Sunday OrElse Fecha.DayOfWeek = DayOfWeek.Saturday Then
            Return True
        Else
            Return EsFestividad(Fecha) '(Not (Festividad(Fecha) Is Nothing)) 
        End If
    End Function


    Public Function insertar(ByVal dts As DatosFestivo) As Integer
        'Insertar una nueva Festividad por defecto
        If Festividad(dts.gFecha) Is Nothing Then 'Verificamos que no existe la fecha
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Festivos (Fecha, Festividad, Repetir) values ( @Fecha, @Festividad, @Repetir) "
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                    cmd.Parameters.AddWithValue("Festividad", dts.gFestividad)
                    cmd.Parameters.AddWithValue("Repetir", dts.gRepetir)
                    con.Open()
                    Dim o As Object = cmd.ExecuteScalar
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
            End Using
        Else
            Return -1
        End If
    End Function


    Public Function actualizar(ByVal dts As DatosFestivo) As Boolean
        'Actualiza un registro de la tabla TiposCompra con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Festivos set  Festividad = @Festividad, Repetir = @Repetir  WHERE Fecha = @Fecha "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("Repetir", dts.gRepetir)
                cmd.Parameters.AddWithValue("Festividad", dts.gFestividad)
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



    Public Function Borrar(ByVal Fecha As Date) As String 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("  Delete Festivos WHERE Fecha = @Fecha ", con)
            cmd.Parameters.AddWithValue("Fecha", fecha)
            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            If O Is DBNull.Value Then
                Return Nothing
            Else
                Return CStr(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

End Class



