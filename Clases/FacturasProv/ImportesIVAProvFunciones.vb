Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesImportesIVAProv


    Inherits conexion
    Dim cmd As SqlCommand

    Private sel0 As String = " Select II.*, Nombre, numFactura, FA.codMoneda, Simbolo from ImportesIVAFacturasProv as II " _
    & " left join FacturasProv as FA ON FA.idFactura = II.idFactura " _
    & " left join Monedas ON Monedas.codMoneda = FA.codMoneda" _
    & " left join TiposIVA as TI ON TI.idTipoIVA = II.idTipoIVA"

    Public Function Mostrar(ByVal iidFactura As Integer) As List(Of DatosImportesIVAProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idFactura = " & iidFactura & " Order By  Vencimiento ASC "
            sel = sel0 & " WHERE II.idFactura = " & iidFactura & " Order By  TipoIVA DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosImportesIVAProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            CorreoError(ex)
            Return Nothing
        End Try
    End Function


    Private Function CargarLinea(ByVal Linea As DataRow) As DatosImportesIVAProv
        Dim dts As New DatosImportesIVAProv
        dts.gidConcepto = Linea("idConcepto")
        dts.gidFactura = If(Linea("idFactura") Is DBNull.Value, 0, Linea("idFactura"))
        dts.gidTipoIVA = If(Linea("idTipoIVA") Is DBNull.Value, 0, Linea("idTipoIVA"))
        dts.gTipoIVA = If(Linea("TipoIVA") Is DBNull.Value, 0, Linea("TipoIVA"))
        dts.gTipoRecargoEq = If(Linea("TipoRecargoEq") Is DBNull.Value, 0, Linea("TipoRecargoEq"))
        dts.gBase = If(Linea("Base") Is DBNull.Value, 0, Linea("Base"))
        dts.gTotalIVA = If(Linea("TotalIVA") Is DBNull.Value, 0, Linea("TotalIVA"))
        dts.gTotalRE = If(Linea("TotalRE") Is DBNull.Value, 0, Linea("TotalRE"))
        dts.gnumFactura = If(Linea("numFactura") Is DBNull.Value, "", Linea("numFactura"))
        dts.gNombreIVA = If(Linea("Nombre") Is DBNull.Value, "", Linea("Nombre"))
        dts.gcodMoneda = If(Linea("codMoneda") Is DBNull.Value, "EU", Linea("codMoneda"))
        dts.gSimbolo = If(Linea("Simbolo") Is DBNull.Value, "€", Linea("Simbolo"))
        Return dts
    End Function


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosImportesIVAProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idFactura = " & iidFactura & " Order By  Vencimiento ASC "
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By TipoIVA DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosImportesIVAProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            ex.Data.Add("sBusqueda", sBusqueda)
            ex.Data.Add("sOrden", sOrden)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

   

    Public Function MostrarDT(ByVal iidFactura As Integer) As DataTable
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim dt As New DataTable
            sel = sel0 & " WHERE II.idFactura = " & iidFactura & " Order By TipoIVA DESC "
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                con.Close()
            End If
            Return dt
        Catch ex As Exception
            ex.Data.Add("iidFactura", iidFactura)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function

    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosImportesIVAProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idConcepto = " & iidConcepto
            sel = sel0 & " WHERE idConcepto = " & iidConcepto

            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosImportesIVAProv
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            ex.Data.Add("iidConcepto", iidConcepto)
            CorreoError(ex)
            Return Nothing
        End Try
    End Function







    Public Function insertar(ByVal dts As DatosImportesIVAProv) As Integer

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into ImportesIVAFacturasProv (idFactura, idTipoIVA , TipoIVA, TipoRecargoEq, Base, TotalIVA, TotalRE) "
        sel = sel & " values (              @idFactura,@idTipoIVA, @TipoIVA,@TipoRecargoEq,@Base,@TotalIVA,@TotalRE) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEq)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("TotalIVA", dts.gTotalIVA)
                cmd.Parameters.AddWithValue("TotalRE", dts.gTotalRE)
                'cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                'cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                CorreoError(ex)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosImportesIVAProv) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ImportesIVAFacturasProv set idFactura = @idFactura, idTipoIVA = @idTipoIVA, TipoIVA = @TipoIVA, TipoRecargoEq = @TipoRecargoEq, Base = @Base, TotalIVA = @TotalIVA, TotalRE = @TotalRE "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEq)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("TotalIVA", dts.gTotalIVA)
                cmd.Parameters.AddWithValue("TotalRE", dts.gTotalRE)
                'cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                'cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                CorreoError(ex)
                Return False
            End Try

        End Using
    End Function


   


    Public Function borrarFactura(ByVal iidFactura As Integer) As Boolean  ' Borra una cabecera de AbonoProv
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ImportesIVAFacturasProv where idFactura = " & iidFactura
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
                ex.Data.Add("iidFactura", iidFactura)

                CorreoError(ex)
                Return 0

            End Try
        End Using

    End Function

    Public Function borrar(ByVal iidConcepto As Integer) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ImportesIVAFacturasProv where idConcepto = " & iidConcepto
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
                ex.Data.Add("iidConcepto", iidConcepto)

                CorreoError(ex)
                Return 0

            End Try
        End Using

    End Function






End Class
