Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesConceptosFacturasComisiones
    Inherits conexion
    Dim cmd As SqlCommand



    Dim sel0 As String = " SelectCF.idConcepto as idConceptoFactura,CC.idComercial, FA.idCliente,CC.Porcentaje,CC.Importe,CC.Liquidada, CC.FechaLiquidacion, CF.Cantidad, CF.Cantidad * CF.PrecioNetoUnitario as subTotal, " _
                & " CT.Nombre & ' ' & CT.Apellidos as Comercial, CL.NombreComercial as Cliente, FA.Fecha as FechaFactura, FA.numFactura, AR.codArticulo, AR.Articulo, FA.codMoneda, Simbolo, TipoUnidad " _
                & " From ConceptosFacturas as CF Left Join ComisionesConceptosFacturas as CC ON CF.idConcepto = CC.idConceptoFactura " _
                & " Left Join Facturas as FA ON FA.numFactura = CF.numFactura Left Join Clientes as CL ON CL.idCliente = FA.idCliente " _
                & " left join Personal ON Personal.idPersona = CC.idComercial  Left join Contactos as CT ON CT.idContacto = CC.idContacto" _
                & " left join Articulos as AR ON AR.idArticulo = CF.idArticulo left join Monedas ON Monedas.codMoneda = FA.codMoneda " _
                & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "



    Public Function mostrarCli(ByVal iidCliente As Integer) As List(Of datosConceptoFacturaComision)
        'Muestra todas los Comisiones de un cliente
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CC.idCliente = " & iidCliente & " Order by FechaFactura DESC, idConceptoFactura DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosConceptoFacturaComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConceptoFactura") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
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

    Public Function mostrarComercial(ByVal iidComercial As Integer) As List(Of datosConceptoFacturaComision)
        'Muestra todas los Comisiones de un comercial
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CO.idComercial = " & iidComercial & " Order by FechaFactura DESC, idConceptoFactura DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosConceptoFacturaComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConceptoFactura") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
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

    Public Function mostrarClienteComercial(ByVal iidComercial As Integer, ByVal iidCliente As Integer) As List(Of datosConceptoFacturaComision)
        'Muestra todas los Comisiones de un comercial
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CO.idComercial = " & iidComercial & " AND CO.idCLiente = " & iidCliente & " Order by FechaFactura DESC, idConceptoFactura DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosConceptoFacturaComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConceptoFactura") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
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



    Private Function CargarLinea(ByVal linea As DataRow) As datosConceptoFacturaComision
        Dim dts As New datosConceptoFacturaComision
        dts.gidConceptoFactura = If(linea("idConceptoFactura") Is DBNull.Value, 0, linea("idConceptoFactura"))
        dts.gidComercial = If(linea("idComercial") Is DBNull.Value, 0, linea("idComercial"))
        dts.gidComision = If(linea("idComision") Is DBNull.Value, 0, linea("idComision"))
        dts.gPorcentaje = If(linea("Porcentaje") Is DBNull.Value, 0, linea("Porcentaje"))
        dts.gImporte = If(linea("Importe") Is DBNull.Value, 0, linea("Importe"))
        dts.gLiquidada = If(linea("Liquidada") Is DBNull.Value, "", linea("Liquidada"))
        dts.gFechaLiquidacion = If(linea("FechaLiquidacion") Is DBNull.Value, Now.Date, linea("FechaLiquidacion"))

        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, 0, linea("numFactura"))
        dts.gFechaFactura = If(linea("FechaFactura") Is DBNull.Value, Now.Date, linea("FechaFactura"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        dts.gComercial = If(linea("Comercial") Is DBNull.Value, "", linea("Comercial"))
        dts.gCodArticulo = If(linea("CodArticulo") Is DBNull.Value, "", linea("CodArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gsubTotal = If(linea("subTotal") Is DBNull.Value, 0, linea("subTotal"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        Return dts

    End Function


    Public Function mostrar1(ByVal iidConceptoFactura As Long) As datosConceptoFacturaComision
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where idConceptoFactura = " & iidConceptoFactura
            cmd = New SqlCommand(sel, con)
            Dim dts As New datosConceptoFacturaComision
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConceptoFactura") Is DBNull.Value Then
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


    


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosConceptoFacturaComision)

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & If(sBusqueda = "", "", " AND " & sBusqueda) & If(sOrden = "", " Order by FechaFactura DESC, idConceptoFactura DESC ", sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosConceptoFacturaComision)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idConceptoFactura") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
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





    Public Function insertar(ByVal dts As datosConceptoFacturaComision) As Integer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into ComisionesConceptosFacturas (idConceptoFactura, idComercial,idComision, Porcentaje,Importe,Liquidada FechaLiquidacion, idCreador, Creacion)"
        sel = sel & "         values (@idConceptoFactura,@idComercial,@idComision,@Porcentaje,@Importe,@Liquidada, @FechaLiquidacion,@idCreador @Creacion ) SELECT @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConceptoFactura", dts.gidConceptoFactura)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("idComision", dts.gidComision)
                cmd.Parameters.AddWithValue("Porcentaje", dts.gPorcentaje)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("Liquidada", dts.gLiquidada)
                cmd.Parameters.AddWithValue("FechaLiquidacion", dts.gFechaLiquidacion)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteScalar())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As datosConceptoFacturaComision) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ComisionesConceptosFacturas set idComision= @idComision,Porcentaje = @Porcentaje,Importe = @Importe, Liquidada = @Liquidada, "
        sel = sel & " FechaLiquidacion = @FechaLiquidacion,  idModifica = @idModifica, Modificacion = @Modificacion where idConceptoFactura = @idConceptoFactura AND idComercial = @idComercial "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idConceptoFactura", dts.gidConceptoFactura)
                cmd.Parameters.AddWithValue("idComercial", dts.gidComercial)
                cmd.Parameters.AddWithValue("idComision", dts.gidComision)
                cmd.Parameters.AddWithValue("Porcentaje", dts.gPorcentaje)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("Liquidada", dts.gLiquidada)
                cmd.Parameters.AddWithValue("FechaLiquidacion", dts.gFechaLiquidacion)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function




    Public Function borrar(ByVal iidConceptoFactura As Long) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ComisionesConceptosFacturas where idConceptoFactura = " & iidConceptoFactura
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
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

    Public Function borrarComercial(ByVal iidComercial As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ComisionesConceptosFacturas where idComercial = " & iidComercial
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
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




End Class
