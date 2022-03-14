Imports System.Data.SqlClient

Public Class FuncionesEtiquetaCliente
#Region "Variables"
    Inherits conexion
    Dim cmd As SqlCommand
#End Region

#Region "Funciones"
    Public Function GetTradename(idCliente As Integer) As String
        Dim nomComercial As String = ""
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = "select NombreComercial from Clientes where idCliente = " & idCliente
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            nomComercial = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("Error al recuperar el nombre del cliente " & vbCrLf & ex.ToString)
        End Try
        Return nomComercial
    End Function

    Public Function InsertCustomerTag(data As DatosEtiquetaLogisticaCliente) As Integer
        Dim idEtiqueta As Integer = 0
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String
        If data.gPathPDF <> "" Then
            sel = "insert into etiquetaLogisticaClienteFinalLinea 
(idCliente, idEtiquetaFinal, imagen , width, height,codArticulo,idArticulo,PDF, pathPDF) values (@idCliente, @idEtiquetaFinal, @imagen, @width, @height, @codArticulo,@idArticulo,1,@pathPDF);SELECT SCOPE_IDENTITY()"
        Else
            sel = "insert into etiquetaLogisticaClienteFinalLinea 
(idCliente, idEtiquetaFinal, imagen , width, height,codArticulo,idArticulo,PDF,pathPDF) values (@idCliente, @idEtiquetaFinal, @imagen, @width, @height, @codArticulo,@idArticulo,0,@pathPDF);SELECT SCOPE_IDENTITY()"
        End If
        Try
            cmd = New SqlCommand(sel, con)
            With cmd.Parameters
                .AddWithValue("@idCliente", data.IdCliente1)
                .AddWithValue("@idEtiquetaFinal", data.IdEtiquetaFinal1)
                .AddWithValue("@imagen", SqlDbType.Image).Value = IIf(data.Imagen1 Is Nothing, SqlTypes.SqlBinary.Null, data.Imagen1)
                .AddWithValue("@width", data.Width1)
                .AddWithValue("@height", data.Height1)
                .AddWithValue("@codArticulo", data.CodArticulo1)
                .AddWithValue("@pathPDF", data.gPathPDF)
                .AddWithValue("@idArticulo", data.gIdArticulo)
            End With
            con.Open()
            idEtiqueta = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MsgBox("Error al guardar la etiqueta del cliente " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return idEtiqueta
    End Function

    Public Function UpdateCustomerTag(img As Byte(), idEtiqueta As Integer, width As Integer, height As Integer, rutaPDF As String) As Boolean
        Dim updated As Boolean = False
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String
        If Not rutaPDF.Equals("") Then
            sel = "update etiquetaLogisticaClienteFinalLinea set imagen = @image, width = @width, height = @height, PDF = 1 where idEtiqueta = @idEtiqueta"
        Else
            sel = "update etiquetaLogisticaClienteFinalLinea set imagen = @image, width = @width, height = @height, PDF = 0 where idEtiqueta = @idEtiqueta"
        End If
        Try
            cmd = New SqlCommand(sel, con)
            With cmd.Parameters
                .AddWithValue("@image", SqlDbType.Image).Value = IIf(img Is Nothing, SqlTypes.SqlBinary.Null, img)
                .AddWithValue("@width", width)
                .AddWithValue("@height", height)
                .AddWithValue("@idEtiqueta", idEtiqueta)

            End With
            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                updated = True
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error al modificar la etiqueta del cliente " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return updated
    End Function

    Public Function DeleteCustomerTag(idEtiqueta As Integer) As Boolean
        Dim del As Boolean = False
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = "delete etiquetaLogisticaClienteFinalLinea where idEtiqueta = " & idEtiqueta
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                del = True
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error al borrar la etiqueta del cliente " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return del
    End Function

    Public Function ExistsCustomerTag(idCliente As Integer, idEtiquetaFinal As Integer) As Integer
        Dim con As New SqlConnection(CadenaConexion)
        Dim idEtiqueta As Integer
        Dim sel As String = "SELECT * FROM etiquetaLogisticaClienteFinalLinea WHERE idCliente = " & idCliente & " AND idEtiquetaFinal = " & idEtiquetaFinal
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            idEtiqueta = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MsgBox("Error al obtener la etiqueta del cliente " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return idEtiqueta
    End Function

    Public Function GetCustomerTag(idCliente As Integer, idEtiquetaFinal As Integer, codArticulo As String) As DatosEtiquetaLogisticaCliente
        Dim con As New SqlConnection(CadenaConexion)
        Dim data As DatosEtiquetaLogisticaCliente = Nothing
        Dim sel As String = "SELECT * FROM etiquetaLogisticaClienteFinalLinea WHERE idCliente = " & idCliente & " and codArticulo = '" & codArticulo & "'"
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader
            data = ReaderData(reader)
            con.Close()
        Catch ex As Exception
            MsgBox("Error al obtener la etiqueta del cliente " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return data
    End Function

    Private Function ReaderData(reader As SqlDataReader) As DatosEtiquetaLogisticaCliente
        Dim data As New DatosEtiquetaLogisticaCliente
        Dim imgVacia() As Byte
        If reader.HasRows Then
            While reader.Read
                With data
                    .IdEtiqueta1 = reader(0)
                    .IdCliente1 = reader(1)
                    .IdEtiquetaFinal1 = reader(2)
                    .Imagen1 = IIf(reader(3).Equals(DBNull.Value), imgVacia, reader(3))
                    .Width1 = reader(4)
                    .Height1 = reader(5)
                    .CodArticulo1 = reader(6)
                    .gIsPDF = reader(7)
                    .gIdArticulo = reader(8)
                    Dim pathpdf As String = reader(9)
                    .gPathPDF = IIf(pathpdf.Equals(""), "", My.Application.Info.DirectoryPath() & reader(9))
                End With
            End While
        Else
            data = Nothing
        End If
        reader.Close()
        Return data
    End Function

    Friend Sub updatePathPDF(rutaPDF As String, idEtiquetaCliente As Integer)

        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String
        sel = "update etiquetaLogisticaClienteFinalLinea set pathPDF= '" & rutaPDF & "' ,PDF = 1 where idEtiqueta = " & idEtiquetaCliente & ""

        Try
            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("Error al modificar la ruta del pdf cliente " & vbCrLf & ex.ToString)
            con.Close()
        End Try

    End Sub
#End Region
End Class
