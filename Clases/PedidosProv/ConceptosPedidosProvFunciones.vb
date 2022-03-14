Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesConceptosPedidosProv

    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()

    Dim sel0 As String = "select CP.*, TipoUnidad,codMoneda, Familia, SubFamilia, Articulo, codArticulo, Articulos.idUnidad, TipoUnidad, TiposIVA.TipoIVA as TipoIVATabla, Estado, " _
            & " Cantidad * PrecioNetoUnitario * (1-(CP.Descuento/100)) as TotalConcepto, Seccion " _
            & " from ConceptosPedidosProv AS CP left join PedidosProv as PP ON PP.numPedido = CP.numPedido " _
            & " left join Articulos ON Articulos.idArticulo = CP.idArticulo " _
            & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = Articulos.idUnidad " _
            & " left join Estados ON Estados.idEstado = CP.idEstado " _
            & " left join TiposIVA ON TiposIVA.idTipoIVA = CP.idTipoIVA " _
            & " left join Familias ON Familias.idFamilia = Articulos.idFamilia " _
            & " left outer JOIN SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia " _
            & " left outer JOIN Secciones ON Secciones.idSeccion = CP.idSeccion "


    Public Function mostrar(ByVal inumPedido As Integer, Optional ByVal sconceptos As String = "") As List(Of DatosConceptoPedidoProv)
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CP.numPedido = " & inumPedido & sConceptos & "  Order By CP.Orden ASC"
            Dim lista As New List(Of DatosConceptoPedidoProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                lista.Clear()
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
    'luiss
    Public Function mostrarparcial(ByVal inumPedido As Integer, ByVal estadorb As Boolean) As List(Of DatosConceptoPedidoProv)
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado

        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CP.numPedido = " & inumPedido & " and cantidadrecibida < cantidad Order By CP.Orden ASC"
            Dim lista As New List(Of DatosConceptoPedidoProv)

            Dim linea As DataRow


            lista.Clear()
            cmd = New SqlCommand(sel, con)
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
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    'luiss



    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoPedidoProv
        Dim dts As New DatosConceptoPedidoProv
        dts.gidConcepto = linea("idConcepto")
        dts.gnumPedido = If(linea("numPedido") Is DBNull.Value, 0, linea("numPedido"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gidArticuloProv = If(linea("idArticuloProv") Is DBNull.Value, 0, linea("idArticuloProv"))
        dts.gArticuloProv = If(linea("ArticuloProv") Is DBNull.Value, "", linea("ArticuloProv"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gPrecioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
        dts.gAceptado = If(linea("Aceptado") Is DBNull.Value, True, linea("Aceptado"))
        dts.gRecibido = If(linea("Recibido") Is DBNull.Value, False, linea("Recibido"))
        dts.gFechaRecibido = If(linea("FechaRecibido") Is DBNull.Value, Now.Date, linea("FechaRecibido"))
        dts.gcodArticuloProv = If(linea("codArticuloProv") Is DBNull.Value, "", linea("codArticuloProv"))
        dts.gCantidadRecibida = If(linea("CantidadRecibida") Is DBNull.Value, 0, linea("CantidadRecibida"))
        dts.gFechaPrevista = If(linea("FechaPrevista") Is DBNull.Value, Now.Date, linea("FechaPrevista"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gTipoIVAFac = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gPVPUnitario = If(linea("PVPUnitario") Is DBNull.Value, 0, linea("PVPUnitario"))
        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))
        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))

        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        dts.gsubFamilia = If(linea("SubFamilia") Is DBNull.Value, "", linea("SubFamilia"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gidUnidad = If(linea("idUnidad") Is DBNull.Value, 0, linea("idUnidad"))
        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
        dts.gTipoIVA = If(linea("TipoIVATabla") Is DBNull.Value, 0, linea("TipoIVATabla"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))

        dts.gTotalConcepto = If(linea("TotalConcepto") Is DBNull.Value, 0, linea("TotalConcepto"))

        Return dts
    End Function


    Public Function mostrar1(ByVal iidConcepto As Integer) As DatosConceptoPedidoProv
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sel0 & "  where CP.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoPedidoProv
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


    Public Function PrimeraFechaRecibido(ByVal inumPedido As Integer) As Date
        ' a partir de un numPedido, devuelve una DataTable con la lista de conceptos del numPedido indicado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select min(FechaRecibido) from ConceptosPedidosProv as CP left join Estados ON Estados.idEstado = CP.idEstado Where Entregado = 1 and CP.numPedido = " & inumPedido
            Dim lista As New List(Of DatosConceptoPedidoProv)
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                Return CDate(o)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    
    Public Function ExisteAlgunPedidoArticulo(ByVal iidArticulo As Integer) As Boolean
        ' Devuelve el concepto de pedidoProv en una linea de una DataTable a partir de un idConcepto
        Try
            If iidArticulo = 0 Then Return False
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select count(idConcepto) a from ConceptosPedidosProv  where idArticulo = " & iidArticulo, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function




    Public Function buscarConceptoPedidoProv(ByVal iidConcepto As Integer) As DataTable
        ' Devuelve el concepto de pedidoProv en una linea de una DataTable a partir de un idConcepto
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select ConceptosPedidosProv.*, PedidosProv.codMoneda from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido =ConceptosPedidosProv.numPedido where idConcepto = " & iidConcepto, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function


    Public Function ContieneArticuloNoServido(ByVal inumPedido As Integer, ByVal iidArticulo As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select count(idConcepto) from ConceptosPedidosProv as CPP left join Estados ON Estados.idEstado= CPP.idEstado where numPedido = " & inumPedido & " AND Espera = 1 AND idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function


    Public Function idAlbaran(ByVal iidConcepto As Long) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select idAlbaran from ConceptosPedidosProv WHERE idConcepto= " & iidConcepto
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


    Public Function numPedido(ByVal iidConcepto As Long) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select numPedido from ConceptosPedidosProv WHERE idConcepto= " & iidConcepto
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



    Public Function insertar(ByVal dts As DatosConceptoPedidoProv) As Integer 'me devuelve el idConcepto generado
        ' Inserta un nuevo concepto de PEdidoProv en la tabla
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Dim resultado As Integer
        sel = "insert into ConceptosPedidosProv (numPedido, idArticulo, idArticuloProv,ArticuloProv, Cantidad, Descuento,PrecioNetoUnitario, Recibido, Aceptado, FechaRecibido,codArticuloProv,CantidadRecibida,FechaPrevista,idEstado,idTipoIVA, TipoIVA,PVPUnitario,idSeccion, idCreador, Creacion ) "
        sel = sel & "values (@numPedido,  @idArticulo, @idArticuloProv, @ArticuloProv, @Cantidad, @Descuento, @PrecioNetoUnitario, @Recibido, @Aceptado,@FechaRecibido, @codArticuloProv,@CantidadRecibida,@FechaPrevista,@idEstado,@idTipoIVA, @TipoIVA, @PVPUnitario,@idSeccion,@idCreador, @Creacion ) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("ArticuloProv", dts.gArticuloProv)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Recibido", dts.gRecibido)
                cmd.Parameters.AddWithValue("Aceptado", dts.gAceptado)
                cmd.Parameters.AddWithValue("FechaRecibido", dts.gFechaRecibido)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                cmd.Parameters.AddWithValue("CantidadRecibida", dts.gCantidadRecibida)
                cmd.Parameters.AddWithValue("FechaPrevista", dts.gFechaPrevista)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("Orden", UltimoOrden(dts.gnumPedido) + 1)
                cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                resultado = cmd.ExecuteScalar()
                con.Close()
                Return resultado
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizar(ByVal dts As DatosConceptoPedidoProv) As Boolean
        ' Actualiza un concepto de PedidosProv concreto con nuevos datos, a partir del idConcepto, devuelve False si hay error
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosProv set numPedido = @numPedido, idArticulo = @idArticulo,idArticuloProv = @idArticuloProv,ArticuloProv = @ArticuloProv, Cantidad = @Cantidad,  "
        sel = sel & "  Descuento = @Descuento,PrecioNetoUnitario = @PrecioNetoUnitario, Recibido = @Recibido, Aceptado = @Aceptado, FechaRecibido = @FechaRecibido,FechaPrevista = @FechaPrevista, "
        sel = sel & " idEstado = @idEstado, idTipoIVA = @idTipoIVA,TipoIVA = @TipoIVA,  PVPUnitario = @PVPUnitario,idSeccion = @idSeccion, idModifica = @idModifica, Modificacion = @Modificacion where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("idArticuloProv", dts.gidArticuloProv)
                cmd.Parameters.AddWithValue("ArticuloProv", dts.gArticuloProv)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("Recibido", dts.gRecibido)
                cmd.Parameters.AddWithValue("Aceptado", dts.gAceptado)
                cmd.Parameters.AddWithValue("FechaRecibido", dts.gFechaRecibido)
                cmd.Parameters.AddWithValue("codArticuloProv", dts.gcodArticuloProv)
                cmd.Parameters.AddWithValue("CantidadRecibida", dts.gCantidadRecibida)
                cmd.Parameters.AddWithValue("FechaPrevista", dts.gFechaPrevista)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)

                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                'ejecutar el sql
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
          
            End Try

        End Using
    End Function

    Public Function PropagarFechaEntrega(ByVal inumPedido As Integer, ByVal FechaEntrega As Date) As Integer
        ' Actualiza el precio unitario y total de un concepto del Pedido concreto, a partir del idConcepto, devuelve False si hay error
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosProv set FechaEntrega = @FechaEntrega  where numPedido = @numPedido "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("FechaEntrega", FechaEntrega)
                cmd.Parameters.AddWithValue("numPedido", inumPedido)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function actualizarPrecio(ByVal dts As DatosConceptoPedidoProv) As Boolean
        ' Actualiza el precio unitario y total de un concepto del Pedido concreto, a partir del idConcepto, devuelve False si hay error
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosProv set PrecioNetoUnitario = @PrecioNetoUnitario, PVPUnitario = @PVPUnitario, Descuento = @Descuento  where idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                'insertarcampos
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("PrecioNetoUnitario", dts.gPrecioNetoUnitario)
                cmd.Parameters.AddWithValue("PVPUnitario", dts.gPVPUnitario)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                'abrir conexion
                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
           
            End Try

        End Using
    End Function

    Public Function CambiarPrecio(ByVal iidConcepto As Integer, ByVal PVPUnitario As Double, ByVal PrecioNetoUnitario As Double) As Boolean
        'Tendremos que hacer esto en caso de cambio de moneda
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidosProv set PVPUnitario = @PVPUnitario, PrecioNetoUnitario = @PrecioNetoUnitario where idConcepto = @idConcepto "
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


    Public Function CambiarCantidad(ByVal iidConcepto As Integer, ByVal Cantidad As Double) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidosProv set Cantidad = @Cantidad where idConcepto = @idConcepto "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Cantidad", Cantidad)
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

    Public Function CambiarIVA(ByVal dts As DatosPedidoProv) As Boolean
        'Actualizar los datos de iva en los conceptos igual que la cabecera
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosPedidosProv set idTipoIVA = @idTipoIVA, TipoIVA = @TipoIVA  where numPedido = @numPedido"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVA)
                cmd.Parameters.AddWithValue("numPedido", dts.gnumPedido)
                'abrir conexion
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

    Public Function actualizarRecepcion(ByVal dts As DatosConceptoPedidoProv) As Boolean
        ' Actualiza un concepto de PedidosProv concreto con los datos de recepción y el estado, a partir del idConcepto, devuelve False si hay error
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "update ConceptosPedidosProv set  Recibido = @Recibido, Aceptado = @Aceptado, FechaRecibido = @FechaRecibido, CantidadRecibida = @CantidadRecibida, idEstado = @idEstado where idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("Recibido", dts.gRecibido)
                cmd.Parameters.AddWithValue("Aceptado", dts.gAceptado)
                cmd.Parameters.AddWithValue("FechaRecibido", dts.gFechaRecibido)
                cmd.Parameters.AddWithValue("CantidadRecibida", dts.gCantidadRecibida)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                'cmd.Parameters.AddWithValue("idAlbaran", dts.gidAlbaran)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function



    Public Function borrar(ByVal iidConcepto As Integer) As Boolean
        ' Elimina de la tabla el concepto de PedidoProv indicado.
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ConceptosPedidosProv where idConcepto = " & iidConcepto

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

    Public Function borrarPedidoProv(ByVal inumPedido As Integer) As Boolean
        ' Elimina de la tabla todos los conceptos del PedidoProv indicado.
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "delete from ConceptosPedidosProv where numPedido = " & inumPedido

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
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

            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select max(Orden) from ConceptosPedidosProv where numPedido = " & inumDoc
            Dim cmd As New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
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

        Dim sel As String = "Update ConceptosPedidosProv set Orden = Orden + 1 where idConcepto = " & iidConcepto
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

        Dim sel As String = "Update ConceptosPedidosProv set Orden = Orden - 1 where idConcepto = " & iidConcepto
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


    Public Sub RenumerarSiEsNecesario(ByVal inumPedido As Integer)
        If OrdenacionErronea(inumPedido) Then RenumerarConceptos(inumPedido, "")
    End Sub

    Private Function OrdenacionErronea(ByVal inumDoc As Integer) As Boolean
        'Detecta Orden = 0 y repeticiones de Orden
        Try
            Dim sel As String = "select (select count(idConcepto) from ConceptosPedidosProv where numPedido = @numPedido and Orden = 0) + "
            sel = sel & " (select distinct Top 1 count(idConcepto) from ConceptosPedidosProv where numPedido = @numPedido Group by Orden order by count(idConcepto) desc)"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("numPedido", inumDoc)
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
            sel = "Select idConcepto from ConceptosPedidosProv where numPedido = " & inumDoc & " Order by " & If(Orden = "", "idConcepto ASC", Orden)
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
        Dim sel As String = "Update ConceptosPedidosProv set ORden = @Orden where idConcepto = @idConcepto "
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
