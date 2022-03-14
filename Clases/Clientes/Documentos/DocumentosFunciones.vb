

Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesDocumentos
    Inherits conexion
    Dim cmd As SqlCommand


    Public Function Mostrar(ByVal vcodDocumento As Integer) As DataTable 'Devuelve el registro del documento
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If vcodDocumento = 0 Then
                sel = " SELECT * FROM Documentos"
            Else
                sel = "SELECT * FROM Documentos WHERE codDocumento = " & vcodDocumento
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function BuscaDoc(ByVal dts As DatosDocumento) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT  codDocumento FROM Documentos WHERE Nombre = '" & dts.gNombre & "' AND Ruta = '" & dts.gRuta & "' AND IdTipo = " & dts.gIdTipo, con)
            con.Open()
            Dim Resultado As Integer = cmd.ExecuteScalar

            Return Resultado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function insertar(ByVal dts As DatosDocumento) As Integer
        ' Inserta un documento si no existe ya
        Dim resultado As Object = BuscaDoc(dts)
        If resultado = 0 Then
            'Si no existe lo inserta
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Documentos (Nombre, Ruta, Extension, IdTipo) values (@Nombre, @Ruta, @Extension, @IdTipo) SELECT @@identity "
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                    cmd.Parameters.AddWithValue("Ruta", dts.gRuta)
                    cmd.Parameters.AddWithValue("Extension", dts.gExtension)
                    cmd.Parameters.AddWithValue("IdTipo", dts.gIdTipo)
                    con.Open()
                    'Dim x As Integer = CInt(cmd.ExecuteNonQuery())
                    Return cmd.ExecuteScalar  'devuelve el valor del codDocumento autoincrementado (identity)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                Finally
                    desconectado()
                End Try
            End Using
        Else
            'Si ya estaba, devuelve el código correspondiente
            Return resultado

        End If

    End Function

    Public Function actualizar(ByVal dts As DatosDocumento) As Boolean   'Actualiza un registro de la tabla Documentos dado un codDocumento
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Documentos set Nombre = @Nombre, Ruta = @Ruta, Extension = @Extension, IdTipo = @IdTipo WHERE codDocumento = " & dts.gcodDocumento

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Nombre", dts.gNombre)
                cmd.Parameters.AddWithValue("Ruta", dts.gRuta)
                cmd.Parameters.AddWithValue("Extension", dts.gExtension)
                cmd.Parameters.AddWithValue("IdTipo", dts.gIdTipo)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
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


    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Documentos", con)
            Else
                cmd = New SqlCommand("SELECT COUNT(*) FROM Documentos WHERE " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Private Function borrado(ByVal vcodDocumento As Integer) As Boolean
        ' Borra un documento de la tabla 

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Documentos where codDocumento = " & vcodDocumento
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
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

    Public Function borrar(ByVal vcodDocumento As Integer) As Boolean

        'Si no existen más relaciones de este documento, lo borra de la tabla de documentos
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "SELECT codDocumento from Prod_Documentos WHERE codDocumento = " & vcodDocumento & " UNION SELECT codDocumento from FORM_Documentos WHERE codDocumento = " & vcodDocumento & "UNION SELECT codDocumento from MP_Documentos WHERE codDocumento = " & vcodDocumento & "UNION SELECT codDocumento from CLI_Documentos WHERE codDocumento = " & vcodDocumento & "UNION SELECT codDocumento from PROSP_Documentos WHERE codDocumento = " & vcodDocumento
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                If CInt(cmd.ExecuteScalar()) = 0 Then
                    Dim func As New FuncionesDocumentos
                    borrado(vcodDocumento)
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
