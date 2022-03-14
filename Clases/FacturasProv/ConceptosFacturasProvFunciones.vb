Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesConceptosFacturasProv

    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()

    Dim sel0 As String = "select CF.*, TipoUnidad,FP.codMoneda, Simbolo, AR.idUnidad, TipoUnidad, Estado, Familia, subFamilia,Articulo,codArticulo,AR.idFamilia, AR.idsubFamilia, " _
            & " CF.Cantidad * CF.PrecioNetoUnitario * (1-(CF.Descuento/100)) as subTotal, FP.numFactura as numFacturaProv, CA.idAlbaran, AP.numAlbaran, AP.Fecha as FechaRecibido, " _
            & " TI.TipoIVA as TipoIVATabla, TI.TipoRecargoEq as TipoRecargoEqTabla, TI.Nombre as NombreTipoIVA " _
            & " from ConceptosFacturasProv AS CF left join FacturasProv as FP ON FP.idFactura = CF.idFactura " _
            & " left join ConceptosAlbaranesProv as CA ON CA.idConcepto = CF.idConceptoAlbaranProv " _
            & " left join AlbaranesProv as AP ON AP.idAlbaran = CA.idAlbaran " _
            & " left join Articulos AS AR ON AR.idArticulo = CF.idArticulo " _
            & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad " _
            & " left join Monedas ON Monedas.codMoneda = FP.codMoneda " _
            & " left join Estados ON Estados.idEstado = CF.idEstado " _
            & " left join Familias ON Familias.idFamilia = AR.idFamilia " _
            & " left join subFamilias ON subFamilias.idSubFamilia = AR.idSubFamilia " _
            & " left join TiposIVA as TI ON TI.idTipoIVA = CF.idTipoIVA "


    Public Function mostrar(ByVal iidFactura As Integer) As List(Of DatosConceptoFacturaProv)
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CF.idFactura = " & iidFactura & " order By Orden ASC"
            Dim lista As New List(Of DatosConceptoFacturaProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function mostrarCP(ByVal iidConceptoAlbaranProv As Long) As List(Of DatosConceptoFacturaProv)
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & " where CF.idConceptoAlbaranProv = " & iidConceptoAlbaranProv
            Dim lista As New List(Of DatosConceptoFacturaProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoFacturaProv
        Dim dts As New DatosConceptoFacturaProv
        dts.gidConcepto = linea("idConcepto")
        dts.gidFactura = If(linea("idFactura") Is DBNull.Value, 0, linea("idFactura"))
        dts.gcodArticuloProv = If(linea("codArticuloProv") Is DBNull.Value, "", linea("codArticuloProv"))
        dts.gArticuloProv = If(linea("ArticuloProv") Is DBNull.Value, "", linea("ArticuloProv"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gPVPUnitario = If(linea("PVPUnitario") Is DBNull.Value, 0, linea("PVPUnitario"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidArticuloProv = If(linea("idArticuloProv") Is DBNull.Value, 0, linea("idArticuloProv"))
        dts.gidconceptoAlbaranProv = If(linea("idConceptoAlbaranProv") Is DBNull.Value, 0, linea("idConceptoAlbaranProv"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))

        dts.gidAlbaran = If(linea("idAlbaran") Is DBNull.Value, 0, linea("idAlbaran"))
        dts.gnumAlbaran = If(linea("numAlbaran") Is DBNull.Value, 0, linea("numAlbaran"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        'dts.gnumAlbaranProv = If(linea("numAlbaranProv") Is DBNull.Value, "", linea("numAlbaranProv"))
        dts.gFechaRecibido = If(linea("FechaRecibido") Is DBNull.Value, Now.Date, linea("FechaRecibido"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))
        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gidSubFamilia = If(linea("idsubFamilia") Is DBNull.Value, 0, linea("idsubFamilia"))
        dts.gSubFamilia = If(linea("SubFamilia") Is DBNull.Value, "", linea("SubFamilia"))
        dts.gTipoIVA = If(linea("TipoIVATabla") Is DBNull.Value, 0, linea("TipoIVATabla"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEqTabla") Is DBNull.Value, 0, linea("TipoRecargoEqTabla"))
        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
        dts.gTipoIVAFac = If(linea("TipoIVA") Is DBNull.Value, dts.gTipoIVA, linea("TipoIVA"))
        dts.gTipoRecargoEqFac = If(linea("TipoRecargoEq") Is DBNull.Value, dts.gTipoRecargoEq, linea("TipoRecargoEq"))

        dts.gsubTotal = If(linea("subTotal") Is DBNull.Value, 0, linea("subTotal"))

        Return dts
    End Function

    Public Function mostrar1(ByVal iidConcepto As Long) As DatosConceptoFacturaProv
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CF.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoFacturaProv
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow

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
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosFacturasProv set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("PVPUnitario", PVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", PrecioNetoUnitario)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)

                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using

    End Function



    Public Function idFactura(ByVal iidConcepto As Long) As Integer
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select idFactura from ConceptosFacturasProv WHERE idConcepto= " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Then
                Return 0
            Else
                Return CInt(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Cantidad(ByVal iidConcepto As Long) As Double
        Try

            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select Cantidad from ConceptosFacturasProv WHERE idConcepto= " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Then
                Return 0
            Else
                Return CDbl(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function insertar(ByVal dts As DatosConceptoFacturaProv) As Integer

        Dim sconexion As String = CadenaConexion()

        Dim sel As String
        Dim resultado As Integer
        sel = "insert into ConceptosFacturasProv ( idFactura, codArticuloProv, ArticuloProv, idArticulo, Cantidad, PVPUnitario, idTipoIVA, Descuento, PrecioNetoUnitario, Orden, idEstado, idArticuloProv, idConceptoAlbaranProv, Observaciones, TipoIVA, TipoRecargoEq ) "
        sel = sel & " values                     (@idFactura,@codArticuloProv,@ArticuloProv,@idArticulo,@Cantidad,@PVPUnitario,@idTipoIVA,@Descuento,@PrecioNetoUnitario,@Orden,@idEstado,@idArticuloProv,@idConceptoAlbaranProv,@Observaciones,@TipoIVA,@TipoRecargoEq ) SELECT @@Identity"
        Using con2 As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con2)

                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                cmd.Parameters.AddWithValue("ArticuloProv", dts.gArticuloProv)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gidFactura) + 1) 'dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("idConceptoAlbaranProv", dts.gidconceptoAlbaranProv)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)


                con2.Open()
                resultado = cmd.ExecuteScalar()
                con2.Close()
                Return resultado
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosConceptoFacturaProv) As Boolean
        ' Actualiza un concepto de PedidosProv concreto con nuevos datos, a partir del idConcepto, devuelve False si hay error

        Dim sel As String

        sel = "update ConceptosFacturasProv set  idFactura = @idFactura, codArticuloProv = @codArticuloProv, ArticuloProv = @ArticuloProv, idArticulo = @idArticulo, Cantidad = @Cantidad, PVPUnitario = @PVPUnitario, "
        sel = sel & " idTipoIVA = @idTipoIVA, Descuento = @Descuento, PrecioNetoUnitario = @PrecioNetoUnitario,  idEstado = @idEstado, idArticuloProv = @idArticuloProv, idConceptoAlbaranProv = @idConceptoAlbaranProv, "
        sel = sel & " Observaciones = @Observaciones,  TipoIVA = @TipoIVA, TipoRecargoEq = @TipoRecargoEq  "
        sel = sel & " where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                cmd.Parameters.AddWithValue("ArticuloProv", dts.gArticuloProv)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                'cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("idConceptoAlbaranProv", dts.gidConceptoAlbaranProv)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function



    Public Function actualizarPrecio(ByVal dts As DatosConceptoFacturaProv) As Boolean
        ' Actualiza el precio unitario y total de un concepto del Pedido concreto, a partir del idConcepto, devuelve False si hay error

        Dim sel As String

        sel = "update ConceptosFacturasProv set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario, Descuento = @Descuento  where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double, ByVal Descuento As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda

        Dim sel As String = "Update ConceptosFacturasProv set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario, Descuento = @Descuento where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("PVPUnitario", PVPUnitario)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", PrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Descuento", Descuento)

                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using

    End Function


   
    Public Function borrar(ByVal iidConcepto As Integer) As Boolean
        ' Elimina de la tabla el concepto de PedidoProv indicado.

        Dim sel As String

        sel = "delete from ConceptosFacturasProv where idConcepto = " & iidConcepto

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function borrarAlbaranProv(ByVal iidFactura As Integer) As Boolean
        ' Elimina de la tabla todos los conceptos del PedidoProv indicado.

        Dim sel As String

        sel = "delete from ConceptosFacturasProv where idFactura = " & iidFactura

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function


#Region "ORDEN"


    Public Function UltimoOrden(ByVal inumDoc As Integer) As Integer
        Try

            Dim con1 As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosFacturasProv where idFactura = " & inumDoc
            Dim cmd As SqlCommand = New SqlCommand(sel, con1)
            con1.Open()
            Dim o As Object = cmd.ExecuteScalar
            con1.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function MoverConceptos(ByVal iidConceptoSube As Long, ByVal iidConceptoBaja As Long) As Boolean
        If DisminuirOrden(iidConceptoSube) Then
            Return AumentarOrden(iidConceptoBaja)
        End If
    End Function

    Public Function AumentarOrden(ByVal iidConcepto As Integer) As Boolean

        Dim sel As String = "Update ConceptosFacturasProv set Orden = Orden + 1 where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function

    Public Function DisminuirOrden(ByVal iidConcepto As Integer) As Boolean

        Dim sel As String = "Update ConceptosFacturasProv set Orden = Orden - 1 where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Using

    End Function


    Public Sub RenumerarSiEsNecesario(ByVal iidFactura As Integer)
        If OrdenacionErronea(iidFactura) Then RenumerarConceptos(iidFactura, "")
    End Sub

    Private Function OrdenacionErronea(ByVal inumDoc As Integer) As Boolean
        'Detecta Orden = 0 y repeticiones de Orden
        Try
            Dim sel As String = "select (select count(idConcepto) from ConceptosFacturasProv where idFactura = @idFactura and Orden = 0) + "
            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosFacturasProv where idFactura = @idFactura Group by Orden order by count(idConcepto) desc)"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("idFactura", inumDoc)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 1
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub RenumerarConceptos(ByVal inumDoc As Integer, ByVal Orden As String)
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idConcepto from ConceptosFacturasProv where idFactura = " & inumDoc & " Order by " & If(Orden = "", "idConcepto ASC", Orden)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim NOrden As Short = 1
                For Each linea As DataRow In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        CambiarOrden(linea("idConcepto"), NOrden)
                        NOrden = NOrden + 1
                    End If
                Next
            Else
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub




    Public Function CambiarOrden(ByVal iidConcepto As Long, ByVal Orden As Short) As Boolean
        Dim sel As String = "Update ConceptosFacturasProv set ORden = @Orden where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Orden", Orden)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function



#End Region




End Class
