Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesEtiquetaLogo
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal iidEtiqueta As Integer) As List(Of DatosEtiquetaLogo) 'Devuelve los campos de una etiqueta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * from EtiquetasLogos where idEtiqueta = " & iidEtiqueta & " order by idLogo ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEtiquetaLogo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    lista.Add(CargarLinea(linea))
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


    Private Function CargarLinea(ByVal linea As DataRow) As DatosEtiquetaLogo
        Dim dts As New DatosEtiquetaLogo
        Dim stream As IO.MemoryStream
        dts.gidEtiqueta = linea("idEtiqueta")
        dts.gidLogo = If(linea("idLogo") Is DBNull.Value, 0, linea("idLogo"))
        dts.gNombreCampo = If(linea("NombreCampo") Is DBNull.Value, "", linea("NombreCampo"))
        If linea("Logo") Is DBNull.Value Then
        Else
            stream = New IO.MemoryStream
            Dim x() As Byte
            x = linea("Logo")
            stream.Write(x, 0, x.GetUpperBound(0) + 1)
            dts.gLogo = Image.FromStream(stream)
        End If
        dts.gParametroTop = If(linea("ParametroTop") Is DBNull.Value, 0, linea("ParametroTop"))
        dts.gParametroLeft = If(linea("ParametroLeft") Is DBNull.Value, 0, linea("ParametroLeft"))
        dts.gParametroWidth = If(linea("ParametroWidth") Is DBNull.Value, 0, linea("ParametroWidth"))
        dts.gParametroHeight = If(linea("ParametroHeight") Is DBNull.Value, 0, linea("ParametroHeight"))
        dts.gVisible = If(linea("Visible") Is DBNull.Value, True, linea("Visible"))
        Return dts
    End Function



    Public Function Mostrar1(ByVal iidEtiqueta As Integer, ByVal iidLogo As Integer) As DatosEtiquetaLogo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT *  FROM EtiquetasLogos  where idEtiqueta = " & iidEtiqueta & " AND idLogo = " & iidLogo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEtiquetaLogo
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idLogoEtiqueta") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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




    Public Function Logo(ByVal iidEtiqueta As Integer, ByVal iidLogo As Integer) As Image
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT NombreCampo FROM EtiquetasLogos WHERE idEtiqueta = " & iidEtiqueta & " AND idLogo = " & iidLogo
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim ob As Object = cmd.ExecuteScalar
            con.Close()
            Dim imagen As Image = Nothing
            Dim stream As IO.MemoryStream
            If ob Is DBNull.Value Then
            Else
                stream = New IO.MemoryStream
                Dim x() As Byte
                x = ob
                stream.Write(x, 0, x.GetUpperBound(0) + 1)
                imagen = Image.FromStream(stream)
            End If
            Return imagen
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function




    Public Function insertar(ByVal dts As DatosEtiquetaLogo) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into EtiquetasLogos (idEtiqueta, idLogo, NombreCampo, ParametroTop, ParametroLeft, ParametroWidth, ParametroHeight,Visible, Logo) "
            sel = sel & " values             (@idEtiqueta,@idLogo,@NombreCampo,@ParametroTop,@ParametroLeft,@ParametroWidth,@ParametroHeight,@Visible,@Logo)"
            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idLogo", dts.gidLogo)
                cmd.Parameters.AddWithValue("NombreCampo", dts.gNombreCampo)
                cmd.Parameters.AddWithValue("ParametroTop", dts.gParametroTop)
                cmd.Parameters.AddWithValue("ParametroLeft", dts.gParametroLeft)
                cmd.Parameters.AddWithValue("ParametroWidth", dts.gParametroWidth)
                cmd.Parameters.AddWithValue("ParametroHeight", dts.gParametroHeight)
                cmd.Parameters.AddWithValue("Visible", dts.gVisible)
                Using stream As New IO.MemoryStream
                    dts.gLogo.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
                    cmd.Parameters.AddWithValue("Logo", stream.GetBuffer)
                End Using
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


    Public Function actualizar(ByVal dts As DatosEtiquetaLogo) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
       
        sel = "update EtiquetasLogos set NombreCampo = @NombreCampo, ParametroTop = @ParametroTop, ParametroLeft = @ParametroLeft, ParametroWidth = @ParametroWidth, ParametroHeight = @ParametroHeight,Visible = @Visible, "
        sel = sel & " Logo = @Logo WHERE idEtiqueta = @idEtiqueta  AND idLogo = @idLogo"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idLogo", dts.gidLogo)
                cmd.Parameters.AddWithValue("NombreCampo", dts.gNombreCampo)
                cmd.Parameters.AddWithValue("ParametroTop", dts.gParametroTop)
                cmd.Parameters.AddWithValue("ParametroLeft", dts.gParametroLeft)
                cmd.Parameters.AddWithValue("ParametroWidth", dts.gParametroWidth)
                cmd.Parameters.AddWithValue("ParametroHeight", dts.gParametroHeight)
                cmd.Parameters.AddWithValue("Visible", dts.gVisible)
                Using stream As New IO.MemoryStream
                    dts.gLogo.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
                    cmd.Parameters.AddWithValue("Logo", stream.GetBuffer)
                End Using
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


    Public Function borrar(ByVal iidEtiqueta As Integer, ByVal iidLogo As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from EtiquetasLogos WHERE idLogo = " & iidLogo & " AND idEtiqueta = " & iidEtiqueta
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


    Public Function borrarEtiqueta(ByVal iidEtiqueta As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from EtiquetasLogos WHERE idEtiqueta = " & iidEtiqueta
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



