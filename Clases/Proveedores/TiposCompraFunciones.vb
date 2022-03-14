
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesTipoCompra
    Inherits conexion
    Dim cmd As SqlCommand

    Public Function Mostrar() As List(Of DatosTipoCompra)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM TiposCompra  order by TipoCompra ASC ", con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim lista As New List(Of DatosTipoCompra)
                Dim dts As DatosTipoCompra
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoCompra") Is DBNull.Value Then
                    Else
                        dts = New DatosTipoCompra
                        dts.gIdTipoCompra = linea("IdTipoCompra")
                        dts.gTipoCompra = If(linea("TipoCompra") Is DBNull.Value, "", linea("TipoCompra"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.gValidacion = If(linea("Validacion") Is DBNull.Value, False, linea("Validacion"))
                        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, False, linea("Transporte"))
                        lista.Add(dts)
                    End If
                Next
                Return lista
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Mostrar1(ByVal viDTipoCompra As Integer) As DatosTipoCompra 'Devuelve los datos de un tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT * FROM TiposCompra WHERE idTipoCompra = " & viDTipoCompra, con)


            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As New DatosTipoCompra
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idTipoCompra") Is DBNull.Value Then
                    Else
                        dts.gIdTipoCompra = linea("IdTipoCompra")
                        dts.gTipoCompra = If(linea("TipoCompra") Is DBNull.Value, "", linea("TipoCompra"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.gValidacion = If(linea("Validacion") Is DBNull.Value, False, linea("Validacion"))
                        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, False, linea("Transporte"))
                    End If
                Next
                Return dts
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
   



    Public Function Campo(ByVal vCampo As String, ByVal vIDTipo As Integer) As Boolean 'Devuelve el valor de un campo booleano 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT " & vCampo & " FROM TiposCompra WHERE IDTipoCompra = " & vIDTipo, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            If O Is DBNull.Value Then
                Return Nothing
            Else
                Return O
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Tipo(ByVal vIDTipoCompra As Integer) As String 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT TipoCompra FROM TiposCompra WHERE IdTipoCompra = " & vIDTipoCompra, con)

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

    Public Function RequiereValidar(ByVal vIDTipoCompra As Integer) As Boolean 'Devuelve el nombre del tipo
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT Validacion FROM TiposCompra WHERE IdTipoCompra = " & vIDTipoCompra, con)

            con.Open()
            Dim O As Object = cmd.ExecuteScalar
            If O Is DBNull.Value Then
                Return False
            Else
                Return CBool(O)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosTipoCompra) As Integer
        'Insertar una nuevo tipo de compra
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into TiposCompra ( TipoCompra, Observaciones, Validacion, Transporte) values ( @TipoCompra, @Observaciones, @Validacion, @Transporte) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("TipoCompra", dts.gTipoCompra)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
               
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try

        End Using
    End Function


    Public Function actualizar(ByVal dts As DatosTipoCompra) As Boolean
        'Actualiza un registro de la tabla TiposCompra con IDTipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update TiposCompra set  TipoCompra = @TipoCompra, Observaciones= @Observaciones, Validacion=@Validacion, Transporte = @Transporte  WHERE IDTipoCompra = " & dts.gIdTipoCompra

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("TipoCompra", dts.gTipoCompra)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Validacion", dts.gValidacion)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)

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

    Public Function borrar(ByVal vIDTipo As Integer) As Boolean
        'Borramos el tipo si no hay ninguna MP que lo tenga

        'Dim funcP As New funcionesProveedores
        'Dim contadorP As Integer = funcP.Contador(" IdTipoCompra = " & vIDTipo)
        'Dim funcE As New FuncionesPedidosProv
        'Dim contadorE As Integer = funcE.Contador(" IdTipoCompra = " & vIDTipo)
        'If contadorP > 0 Or contadorE > 0 Then
        '    Dim texto As String = "Existen" & vbCrLf
        '    texto = If(contadorP > 0, texto & contadorP & " proveedores de este tipo", texto)
        '    texto = If(contadorE > 0, texto & contadorE & " Pedidos a proveedor con este tipo", texto)
        '    texto = texto & vbCrLf & "Por tanto no se puede borrar. En su lugar puede cambiar el nombre del tipo."
        '    MsgBox(texto)
        'Else
        '    Dim sconexion As String = CadenaConexion()
        '    Dim sel As String = "delete from TiposCompra where IDTipoCompra = " & vIDTipo
        '    Using con As New SqlConnection(sconexion)
        '        Try
        '            cmd = New SqlCommand(sel, con)
        '            'abrir conexion
        '            con.Open()

        '            'ejecutar el sql
        '            Dim t As Integer = CInt(cmd.ExecuteNonQuery())
        '            If t = 1 Then
        '                Return True
        '            Else
        '                Return False
        '            End If
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '            Return False
        '        Finally
        '            desconectado()
        '        End Try
        '    End Using
        'End If

    End Function
End Class



