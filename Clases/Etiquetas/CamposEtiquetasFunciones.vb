Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO


Public Class FuncionesCamposEtiquetas
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar(ByVal iidEtiqueta As Integer) As List(Of DatosCampoEtiqueta) 'Devuelve los campos de una etiqueta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * from CamposEtiquetas where idEtiqueta = " & iidEtiqueta & " order by idCampo ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosCampoEtiqueta)
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


    Private Function CargarLinea(ByVal linea As DataRow) As DatosCampoEtiqueta
        Dim dts As New DatosCampoEtiqueta
        dts.gidEtiqueta = linea("idEtiqueta")
        dts.gidCampo = If(linea("idCampo") Is DBNull.Value, 0, linea("idCampo"))
        dts.gNombreCampo = If(linea("NombreCampo") Is DBNull.Value, "", linea("NombreCampo"))
        dts.gValorxDefecto = If(linea("ValorxDefecto") Is DBNull.Value, "", linea("ValorxDefecto"))
        dts.gesContador = If(linea("esContador") Is DBNull.Value, False, linea("esContador"))
        dts.gesCodigo = If(linea("esCodigo") Is DBNull.Value, False, linea("esCodigo"))
        dts.gParametroTop = If(linea("ParametroTop") Is DBNull.Value, 0, linea("ParametroTop"))
        dts.gParametroLeft = If(linea("ParametroLeft") Is DBNull.Value, 0, linea("ParametroLeft"))
        dts.gParametroWidth = If(linea("ParametroWidth") Is DBNull.Value, 0, linea("ParametroWidth"))
        dts.gParametroHeight = If(linea("ParametroHeight") Is DBNull.Value, 0, linea("ParametroHeight"))
        dts.gFuente = If(linea("Fuente") Is DBNull.Value, "", linea("Fuente"))
        dts.gParametroSize = If(linea("ParametroSize") Is DBNull.Value, 0, linea("ParametroSize"))
        dts.gNegrita = If(linea("Negrita") Is DBNull.Value, False, linea("Negrita"))
        dts.gItalica = If(linea("Italica") Is DBNull.Value, False, linea("Italica"))
        'dts.gEsLinea = If(linea("EsLinea") Is DBNull.Value, False, linea("EsLinea"))
        dts.gVisible = If(linea("Visible") Is DBNull.Value, True, linea("Visible"))

        Return dts
    End Function



    Public Function Mostrar1(ByVal iidEtiqueta As Integer, ByVal iidCampo As Integer) As DatosCampoEtiqueta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT *  FROM CamposEtiquetas  where idEtiqueta = " & iidEtiqueta & " AND idCampo = " & iidCampo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosCampoEtiqueta
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





    Public Function Etiqueta(ByVal iidEtiqueta As Integer) As String 'Devuelve los datos de una familia como Lista
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT NombreCampo FROM CamposEtiquetas WHERE idEtiqueta = " & iidEtiqueta
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

    Public Function SiguienteContador(ByVal iidEtiqueta As Integer, ByVal iidCampo As Integer) As Integer 'Devuelve el siguiente número
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT ValorxDefecto FROM CamposEtiquetas WHERE idCampo = " & iidCampo & " AND idEtiqueta = " & iidEtiqueta
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 1
            Else
                If IsNumeric(o) Then
                    Return 1 + CInt(o)
                Else
                    Return 1
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function insertar(ByVal dts As DatosCampoEtiqueta) As Integer
        'Insertar una nuevo 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into CamposEtiquetas (idEtiqueta, idCampo, NombreCampo, ValorxDefecto, esContador, esCodigo, ParametroTop, ParametroLeft, ParametroWidth, ParametroHeight, Fuente, ParametroSize, Negrita, Italica,Visible) "
            sel = sel & " values              (@idEtiqueta,@idCampo,@NombreCampo,@ValorxDefecto,@esContador,@esCodigo,@ParametroTop,@ParametroLeft,@ParametroWidth,@ParametroHeight,@Fuente,@ParametroSize,@Negrita,@Italica,@Visible) "
            Using con As New SqlConnection(sconexion)

                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idCampo", dts.gidCampo)
                cmd.Parameters.AddWithValue("NombreCampo", dts.gNombreCampo)
                cmd.Parameters.AddWithValue("ValorxDefecto", dts.gValorxDefecto)
                cmd.Parameters.AddWithValue("esContador", dts.gesContador)
                cmd.Parameters.AddWithValue("esCodigo", dts.gesCodigo)
                cmd.Parameters.AddWithValue("ParametroTop", dts.gParametroTop)
                cmd.Parameters.AddWithValue("ParametroLeft", dts.gParametroLeft)
                cmd.Parameters.AddWithValue("ParametroWidth", dts.gParametroWidth)
                cmd.Parameters.AddWithValue("ParametroHeight", dts.gParametroHeight)
                cmd.Parameters.AddWithValue("Fuente", dts.gFuente)
                cmd.Parameters.AddWithValue("ParametroSize", dts.gParametroSize)
                cmd.Parameters.AddWithValue("Negrita", dts.gNegrita)
                cmd.Parameters.AddWithValue("Italica", dts.gItalica)
                'cmd.Parameters.AddWithValue("EsLinea", dts.gEsLinea)
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


    Public Function actualizar(ByVal dts As DatosCampoEtiqueta) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        If dts.gNombreCampo = "" Then
            sel = "update CamposEtiquetas set ValorxDefecto = @ValorxDefecto WHERE idEtiqueta = @idEtiqueta  AND idCampo = @idCampo"
        Else
            sel = "update CamposEtiquetas set NombreCampo = @NombreCampo, ValorxDefecto = @ValorxDefecto, esContador = @esContador, esCodigo = @esCodigo, "
            sel = sel & " ParametroTop = @ParametroTop, ParametroLeft = @ParametroLeft, ParametroWidth = @ParametroWidth, ParametroHeight = @ParametroHeight, "
            sel = sel & " Fuente = @Fuente, ParametroSize = @ParametroSize, Negrita = @Negrita, Italica = @Italica, Visible = @Visible "
            sel = sel & " WHERE idEtiqueta = @idEtiqueta  AND idCampo = @idCampo"
        End If

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idCampo", dts.gidCampo)
                cmd.Parameters.AddWithValue("NombreCampo", dts.gNombreCampo)
                cmd.Parameters.AddWithValue("ValorxDefecto", dts.gValorxDefecto)
                cmd.Parameters.AddWithValue("esContador", dts.gesContador)
                cmd.Parameters.AddWithValue("esCodigo", dts.gesCodigo)
                cmd.Parameters.AddWithValue("ParametroTop", dts.gParametroTop)
                cmd.Parameters.AddWithValue("ParametroLeft", dts.gParametroLeft)
                cmd.Parameters.AddWithValue("ParametroWidth", dts.gParametroWidth)
                cmd.Parameters.AddWithValue("ParametroHeight", dts.gParametroHeight)
                cmd.Parameters.AddWithValue("Fuente", dts.gFuente)
                cmd.Parameters.AddWithValue("ParametroSize", dts.gParametroSize)
                cmd.Parameters.AddWithValue("Negrita", dts.gNegrita)
                cmd.Parameters.AddWithValue("Italica", dts.gItalica)
                'cmd.Parameters.AddWithValue("EsLinea", dts.gEsLinea)
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
            Dim sel As String = "delete from CamposEtiquetas WHERE idCampo = " & iidCampo & " AND idEtiqueta = " & iidEtiqueta
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
            Dim sel As String = "delete from CamposEtiquetas WHERE idEtiqueta = " & iidEtiqueta
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



