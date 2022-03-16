Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesLineasExportacion

    Inherits conexion
    Dim cmd As SqlCommand

  


    Public Function Mostrar(ByVal inumFactura As Integer) As List(Of DatosLineaExportacion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "Select * from LineasExportacion where numFactura = " & inumFactura
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosLineaExportacion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosLineaExportacion
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idLinea") Is DBNull.Value Then
                    Else
                        dts = New DatosLineaExportacion
                        dts.gidLinea = linea("idLinea")
                        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
                        dts.gTitulo = If(linea("Titulo") Is DBNull.Value, "", linea("Titulo"))
                        dts.gTexto = If(linea("Texto") Is DBNull.Value, "", linea("Texto"))

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






    Public Function Mostrar1(ByVal iidLinea As Integer) As DatosLineaExportacion

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select * from LineasExportacion where idLinea = " & iidLinea
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosLineaExportacion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idLinea") Is DBNull.Value Then
                    Else
                        dts.gidLinea = linea("idLinea")
                        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
                        dts.gTitulo = If(linea("Titulo") Is DBNull.Value, "", linea("Titulo"))
                        dts.gTexto = If(linea("Texto") Is DBNull.Value, "", linea("Texto"))
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


   





   

    


   
   

   







    Public Function insertar(ByVal dts As DatosLineaExportacion) As Integer 'Inserta una nueva Factura y devuelve el nº
       
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into LineasExportacion (numFactura, Titulo, Texto) values (@numFactura, @Titulo, @Texto) select @@identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("Titulo", dts.gTitulo)
                cmd.Parameters.AddWithValue("Texto", dts.gTexto)
               

                con.Open()
                Dim resultado As Long = cmd.ExecuteScalar
                con.Close()
                Return resultado
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosLineaExportacion) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update LineasExportacion set numFactura = @numFactura, Titulo = @Titulo, Texto = @Texto WHERE idLinea = @idLinea"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idLinea", dts.gidLinea)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("Titulo", dts.gTitulo)
                cmd.Parameters.AddWithValue("Texto", dts.gTexto)

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



   

    



    Public Function borrarFactura(ByVal inumFactura As Integer) As Boolean  ' Borra una cabecera de FacturaProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from LineasExportacion where numFactura = " & inumFactura
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                desconectado()
            End Try
        End Using

    End Function

    Public Function borrar(ByVal iidLinea As Integer) As Boolean  ' Borra una cabecera de FacturaProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from LineasExportacion where idLinea = " & iidLinea
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                desconectado()
            End Try
        End Using

    End Function





End Class
