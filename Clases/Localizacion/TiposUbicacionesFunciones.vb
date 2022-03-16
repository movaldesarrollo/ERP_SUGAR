Imports System.Data.SqlClient
Imports System.Data.Sql



Public Class FuncionesTiposUbicacion
    Inherits conexion
    Dim cmd As SqlCommand





    Public Function MostrarTU() As List(Of DatosTipoUbicaciones)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposUbicacion order by TipoUbicacion ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim lista As New List(Of DatosTipoUbicaciones)
                Dim dts As DatosTipoUbicaciones
                For Each linea In dt.Rows
                    dts = New DatosTipoUbicaciones
                    dts.gidTipoUbicacion = linea("idTipoUbicacion")
                    dts.gTipoUbicacion = If(linea("TipoUbicacion") Is DBNull.Value, "", linea("TipoUbicacion"))
                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                    dts.gFiscal = If(linea("Fiscal") Is DBNull.Value, False, linea("Fiscal"))
                    dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, False, linea("Proveedor"))
                    dts.gCliente = If(linea("Cliente") Is DBNull.Value, False, linea("Cliente"))
                    dts.gPostal = If(linea("Postal") Is DBNull.Value, False, linea("Postal"))
                    dts.gRecogida = If(linea("Recogida") Is DBNull.Value, False, linea("Recogida"))
                    dts.gEntrega = If(linea("Entrega") Is DBNull.Value, False, linea("Entrega"))
                    dts.gInterna = If(linea("Interna") Is DBNull.Value, False, linea("Interna"))
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

    Public Function MostrarTU(ByVal Fiscal As Boolean, ByVal Cliente As Boolean, ByVal Proveedor As Boolean, ByVal Postal As Boolean, ByVal Recogida As Boolean, ByVal Entrega As Boolean, ByVal Interna As Boolean) As List(Of DatosTipoUbicaciones)
        'Muestra los tipos de ubicación según el tipo especificado. Sólo tiene en cuenta los parámetros true.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim cond As String
            cond = If(Fiscal, "  Fiscal = 1 ", "")
            cond = cond & If(Cliente, If(cond = "", "", " AND ") & " Cliente = 1 ", "")
            cond = cond & If(Proveedor, If(cond = "", "", " AND ") & " Proveedor = 1 ", "")
            cond = cond & If(Postal, If(cond = "", "", " AND ") & " Postal = 1 ", "")
            cond = cond & If(Recogida, If(cond = "", "", " AND ") & " Recogida = 1 ", "")
            cond = cond & If(Entrega, If(cond = "", "", " AND ") & " Entrega = 1 ", "")
            cond = cond & If(Interna, If(cond = "", "", " AND ") & " Interna = 1 ", "")

            cond = If(cond = "", "", " WHERE ") & cond
            Dim sel As String
            sel = "SELECT * FROM TiposUbicacion " & cond & " order by TipoUbicacion ASC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim lista As New List(Of DatosTipoUbicaciones)
                Dim dts As DatosTipoUbicaciones
                For Each linea In dt.Rows
                    dts = New DatosTipoUbicaciones
                    dts.gidTipoUbicacion = linea("idTipoUbicacion")
                    dts.gTipoUbicacion = If(linea("TipoUbicacion") Is DBNull.Value, "", linea("TipoUbicacion"))
                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                    dts.gFiscal = If(linea("Fiscal") Is DBNull.Value, False, linea("Fiscal"))
                    dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, False, linea("Proveedor"))
                    dts.gCliente = If(linea("Cliente") Is DBNull.Value, False, linea("Cliente"))
                    dts.gPostal = If(linea("Postal") Is DBNull.Value, False, linea("Postal"))
                    dts.gRecogida = If(linea("Recogida") Is DBNull.Value, False, linea("Recogida"))
                    dts.gEntrega = If(linea("Entrega") Is DBNull.Value, False, linea("Entrega"))
                    dts.gInterna = If(linea("Interna") Is DBNull.Value, False, linea("Interna"))
                    lista.Add(dts)
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

    Public Function Mostrar1TU(ByVal iidTipoUbicacion As Integer) As DatosTipoUbicaciones
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT * FROM TiposUbicacion where idTipoUbicacion = " & iidTipoUbicacion
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                Dim dts As New DatosTipoUbicaciones
                For Each linea In dt.Rows
                    dts.gidTipoUbicacion = linea("idTipoUbicacion")
                    dts.gTipoUbicacion = If(linea("TipoUbicacion") Is DBNull.Value, "", linea("TipoUbicacion"))
                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
                    dts.gFiscal = If(linea("Fiscal") Is DBNull.Value, False, linea("Fiscal"))
                    dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, False, linea("Proveedor"))
                    dts.gCliente = If(linea("Cliente") Is DBNull.Value, False, linea("Cliente"))
                    dts.gPostal = If(linea("Postal") Is DBNull.Value, False, linea("Postal"))
                    dts.gRecogida = If(linea("Recogida") Is DBNull.Value, False, linea("Recogida"))
                    dts.gEntrega = If(linea("Entrega") Is DBNull.Value, False, linea("Entrega"))
                    dts.gInterna = If(linea("Interna") Is DBNull.Value, False, linea("Interna"))
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




    Public Function EsFiscal(ByVal iidTipoUbicacion As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Fiscal FROM TiposUbicacion where idTipoUbicacion = " & iidTipoUbicacion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function EsInterna(ByVal iidTipoUbicacion As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT Interna FROM TiposUbicacion where idTipoUbicacion = " & iidTipoUbicacion
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CBool(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function PorDefectoCli() As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoUbicacion FROM TiposUbicacion where Fiscal = 1 and Cliente = 1 and Entrega = 1 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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

    Public Function PorDefectoProv() As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT TipoUbicacion FROM TiposUbicacion where Fiscal = 1 and Proveedor = 1 and Recogida = 1 "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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


End Class



