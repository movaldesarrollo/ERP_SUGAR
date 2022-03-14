
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesRutas
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar() As List(Of DatosRuta)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM Rutas ", con)
            Dim lista As New List(Of DatosRuta)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosRuta
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idAplicacion") Is DBNull.Value Then
                    Else
                        dts = New DatosRuta
                        dts.gIdAplicacion = linea("idAplicacion")
                        dts.gRuta = If(linea("Ruta") Is DBNull.Value, "", linea("Ruta"))
                        dts.gAplicacion = If(linea("Aplicacion") Is DBNull.Value, "", linea("Aplicacion"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
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

    Public Function Mostrar1(ByVal iidAplicacion As Integer) As DatosRuta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM Rutas where idAplicacion = " & iidAplicacion, con)
            Dim dts As New DatosRuta
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idAplicacion") Is DBNull.Value Then
                    Else
                        dts = New DatosRuta
                        dts.gIdAplicacion = linea("idAplicacion")
                        dts.gRuta = If(linea("Ruta") Is DBNull.Value, "", linea("Ruta"))
                        dts.gAplicacion = If(linea("Aplicacion") Is DBNull.Value, "", linea("Aplicacion"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
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





    Public Function Aplicacion(ByVal vIdAplicacion As Integer) As String 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Aplicacion FROM Rutas WHERE IdAplicacion = " & vIdAplicacion, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            con.Close()
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

    Public Function Ruta(ByVal vIDAplicacion As Integer) As String 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Ruta FROM Rutas WHERE IdAplicacion = " & vIDAplicacion, con)

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


    Public Function RutaAp(ByVal sAplicacion As String) As String 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Ruta FROM Rutas WHERE Aplicacion = '" & sAplicacion & "' ", con)

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


    Public Function insertar(ByVal dts As DatosRuta) As Integer
        'Insertar una nueva ruta por defecto
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into Rutas ( Aplicacion, Observaciones, Ruta) values ( @Aplicacion, @Observaciones, @Ruta) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("Aplicacion", dts.gAplicacion)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Ruta", dts.gRuta)

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
    End Function

    Public Function actualizar(ByVal dts As DatosRuta) As Boolean
        'Actualiza un registro de la tabla TiposCompra con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Rutas set Aplicacion = @Aplicacion, Observaciones= @Observaciones, Ruta = @Ruta  WHERE IDAplicacion = @IdAplicacion "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("IdAplicacion", dts.gIdAplicacion)
                cmd.Parameters.AddWithValue("Aplicacion", dts.gAplicacion)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Ruta", dts.gRuta)
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


End Class



