Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesEtiquetaLinea
    Inherits conexion
    Dim cmd As SqlCommand




    Public Function Mostrar(ByVal iidEtiqueta As Integer) As List(Of DatosEtiquetaLinea) 'Devuelve los campos de una etiqueta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * from EtiquetasLineas where idEtiqueta = " & iidEtiqueta & " order by idCampo ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEtiquetaLinea)
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


    Private Function CargarLinea(ByVal linea As DataRow) As DatosEtiquetaLinea
        Dim dts As New DatosEtiquetaLinea
        dts.gidEtiqueta = linea("idEtiqueta")
        dts.gidCampo = If(linea("idCampo") Is DBNull.Value, 0, linea("idCampo"))
        dts.gNombreCampo = If(linea("NombreCampo") Is DBNull.Value, "", linea("NombreCampo"))
        dts.gParametroTop = If(linea("ParametroTop") Is DBNull.Value, 0, linea("ParametroTop"))
        dts.gParametroLeft = If(linea("ParametroLeft") Is DBNull.Value, 0, linea("ParametroLeft"))
        dts.gParametroRight = If(linea("ParametroRight") Is DBNull.Value, 0, linea("ParametroRight"))
        dts.gParametroThickness = If(linea("ParametroThickness") Is DBNull.Value, 0, linea("ParametroThickness"))
        dts.gVisible = If(linea("Visible") Is DBNull.Value, True, linea("Visible"))
        Return dts
    End Function



    Public Function Mostrar1(ByVal iidEtiqueta As Integer, ByVal iidCampo As Integer) As DatosEtiquetaLinea
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT *  FROM EtiquetasLineas  where idEtiqueta = " & iidEtiqueta & " AND idCampo = " & iidCampo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEtiquetaLinea
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idCampoEtiqueta") Is DBNull.Value Then
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




    Public Function Linea(ByVal iidEtiqueta As Integer, ByVal iidCampo As Integer) As Image
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT NombreCampo FROM EtiquetasLineas WHERE idEtiqueta = " & iidEtiqueta & " AND idCampo = " & iidCampo
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




    Public Function insertar(ByVal dts As DatosEtiquetaLinea) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into EtiquetasLineas (idEtiqueta, idCampo, NombreCampo, ParametroTop, ParametroLeft, ParametroRight, ParametroThickness,Visible) "
            sel = sel & " values             (@idEtiqueta,@idCampo,@NombreCampo,@ParametroTop,@ParametroLeft,@ParametroRight,@ParametroThickness,@Visible)"
            Using con As New SqlConnection(sconexion)
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idCampo", dts.gidCampo)
                cmd.Parameters.AddWithValue("NombreCampo", dts.gNombreCampo)
                cmd.Parameters.AddWithValue("ParametroTop", dts.gParametroTop)
                cmd.Parameters.AddWithValue("ParametroLeft", dts.gParametroLeft)
                cmd.Parameters.AddWithValue("ParametroRight", dts.gParametroRight)
                cmd.Parameters.AddWithValue("ParametroThickness", dts.gParametroThickness)
                cmd.Parameters.AddWithValue("Visible", dts.gVisible)
               
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


    Public Function actualizar(ByVal dts As DatosEtiquetaLinea) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update EtiquetasLineas set NombreCampo = @NombreCampo, ParametroTop = @ParametroTop, ParametroLeft = @ParametroLeft, ParametroRight = @ParametroRight, ParametroThickness = @ParametroThickness,Visible = @Visible "
        sel = sel & " WHERE idEtiqueta = @idEtiqueta  AND idCampo = @idCampo"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idCampo", dts.gidCampo)
                cmd.Parameters.AddWithValue("NombreCampo", dts.gNombreCampo)
                cmd.Parameters.AddWithValue("ParametroTop", dts.gParametroTop)
                cmd.Parameters.AddWithValue("ParametroLeft", dts.gParametroLeft)
                cmd.Parameters.AddWithValue("ParametroRight", dts.gParametroRight)
                cmd.Parameters.AddWithValue("ParametroThickness", dts.gParametroThickness)
                cmd.Parameters.AddWithValue("Visible", dts.gVisible)
               
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


    Public Function borrar(ByVal iidEtiqueta As Integer, ByVal iidCampo As Integer) As Boolean
        'Borramos 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String = "delete from EtiquetasLineas WHERE idCampo = " & iidCampo & " AND idEtiqueta = " & iidEtiqueta
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
            Dim sel As String = "delete from EtiquetasLineas WHERE idEtiqueta = " & iidEtiqueta
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



