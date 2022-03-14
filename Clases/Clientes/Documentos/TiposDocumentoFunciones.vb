

Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesTiposDocumento
    Inherits conexion
    Dim cmd As SqlCommand



    Public Function Mostrar(ByVal vIDTipo As Integer) As DataTable 'Devuelve el registro del tipo de documento con IDTipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If vIDTipo = 0 Then
                cmd = New SqlCommand("SELECT  * FROM TiposDocumento WHERE Activo = 1", con)
            Else
                cmd = New SqlCommand("SELECT  * FROM TiposDocumento WHERE Activo = 1 AND IdTipo =  " & vIDTipo, con)
            End If
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

    Public Function Mostrar() As DataTable 'Devuelve el registro del tipo de documento con IDTipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT  * FROM TiposDocumento WHERE Activo = 1", con)
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



    Public Function insertar(ByVal dts As DatosTiposDocumento) As Integer
        'Insertar una nuevo tipo de caducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into TiposDocumento (TipoDoc, Observaciones, Activo ) values ( @TipoDoc, @Observaciones, @Activo ) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoDoc", dts.gTipoDoc)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                con.Open()

                Return cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosTiposDocumento) As Boolean
        'Actualiza un registro de la tabla TiposCaducidad con IDCaducidad
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TiposDocumento set  TipoDoc = @TipoDoc, Observaciones = @Observaciones, Activo = @Activo  WHERE IDTipo = " & dts.gIDTipo

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos

                cmd.Parameters.AddWithValue("TipoDoc", dts.gTipoDoc)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
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



    Public Function borrar(ByVal vIDTipo As String) As Boolean
        'El borrado en realidad es pasar el campo Activo a False
        Dim sel As String
        Dim sconexion As String = CadenaConexion()
        Dim func As New FuncionesDocumentos
        Dim contador As Integer = func.Contador(" IdTipo = " & vIDTipo)
        If contador > 0 Then
            'MsgBox("Existen " & contador & " documentos de este tipo, por tanto no se puede borrar. En su lugar puede cambiar el nombre del tipo.")
            sel = "UPDATE TiposDocumento SET  activo = 0  WHERE IDTipo = " & vIDTipo
        Else
            sel = "DELETE FROM TiposDocumento WHERE IDTipo = " & vIDTipo
        End If
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

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
End Class
