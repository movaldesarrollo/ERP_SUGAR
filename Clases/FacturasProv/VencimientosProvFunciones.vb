Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesVencimientosProv


    Inherits conexion
    Dim cmd As SqlCommand

    Private sel0 As String = " select VE.*, IBAN,FA.idProveedor, NombreFiscal as Proveedor,CB.idBanco, Bancos.Banco,FA.codMoneda, simbolo, numFactura  from VencimientosProv as VE " _
    & " left join FacturasProv as FA ON FA.idFactura = VE.idFactura " _
    & " left Join Proveedores ON Proveedores.idProveedor = FA.idProveedor" _
    & " left join MediosPago as MP ON MP.idMedioPago = FA.idMedioPago" _
    & " left join CuentasBancarias as CB ON CB.idCuentaBanco = FA.idCuentaBanco" _
    & " left Join Bancos ON Bancos.idBanco = CB.idBanco " _
    & " left join Monedas ON Monedas.codMoneda = FA.codMoneda"

    Public Function Mostrar(ByVal iidFactura As Integer) As List(Of DatosVencimientoProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idFactura = " & iidFactura & " Order By  Vencimiento ASC "
            sel = sel0 & " WHERE VE.idFactura = " & iidFactura & " Order By  Vencimiento ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosVencimientoProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idVencimiento") Is DBNull.Value Then
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


    Private Function CargarLinea(ByVal Linea As DataRow) As DatosVencimientoProv
        Dim dts As New DatosVencimientoProv
        dts.gidVencimiento = Linea("idVencimiento")
        dts.gidFactura = If(Linea("idFactura") Is DBNull.Value, 0, Linea("idFactura"))
        dts.gVencimiento = If(Linea("Vencimiento") Is DBNull.Value, Now.Date, Linea("Vencimiento"))
        dts.gImporte = If(Linea("Importe") Is DBNull.Value, 0, Linea("Importe"))
        dts.gPagado = If(Linea("Pagado") Is DBNull.Value, False, Linea("Pagado"))
        dts.gRemesado = If(Linea("Remesado") Is DBNull.Value, False, Linea("Remesado"))
        dts.gDevuelto = If(Linea("Devuelto") Is DBNull.Value, False, Linea("Devuelto"))
        dts.gidProveedor = If(Linea("idProveedor") Is DBNull.Value, 0, Linea("idProveedor"))
        dts.gProveedor = If(Linea("Proveedor") Is DBNull.Value, "", Linea("Proveedor"))
        dts.gidBanco = If(Linea("idBanco") Is DBNull.Value, 0, Linea("idBanco"))
        dts.gBanco = If(Linea("Banco") Is DBNull.Value, "", Linea("Banco"))
        dts.gIBAN = If(Linea("IBAN") Is DBNull.Value, "", Linea("IBAN"))
        dts.gcodMoneda = If(Linea("codMoneda") Is DBNull.Value, "EU", Linea("codMoneda"))
        dts.gSimbolo = If(Linea("Simbolo") Is DBNull.Value, "€", Linea("Simbolo"))
        dts.gnumFactura = If(Linea("numFactura") Is DBNull.Value, "", Linea("numFactura"))

        Return dts
    End Function

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosVencimientoProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idFactura = " & iidFactura & " Order By  Vencimiento ASC "
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By Vencimiento ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosVencimientoProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idVencimiento") Is DBNull.Value Then
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




    Public Function Mostrar1(ByVal iidVencimiento As Integer) As DatosVencimientoProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idVencimiento = " & iidVencimiento
            sel = sel0 & " WHERE idVencimiento = " & iidVencimiento

            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosVencimientoProv
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idVencimiento") Is DBNull.Value Then
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







    Public Function insertar(ByVal dts As DatosVencimientoProv) As Integer 'Inserta una nueva Factura y devuelve el nº

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into VencimientosProv (idFactura, Vencimiento, Importe, Pagado,Remesado, Devuelto, idCreador, Creacion) "
        sel = sel & " values (@idFactura, @Vencimiento, @Importe, @Pagado, @Remesado, @Devuelto, @idCreador, @Creacion) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("Vencimiento", dts.gVencimiento)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("Pagado", dts.gPagado)
                cmd.Parameters.AddWithValue("Remesado", dts.gRemesado)
                cmd.Parameters.AddWithValue("Devuelto", dts.gDevuelto)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosVencimientoProv) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update VencimientosProv set idFactura = @idFactura, Vencimiento = @Vencimiento, Importe = @Importe, Pagado = @Pagado, Remesado = @Remesado, Devuelto = @Devuelto, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " WHERE idVencimiento = @idVencimiento"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idVencimiento", dts.gidVencimiento)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("Vencimiento", dts.gVencimiento)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("Pagado", dts.gPagado)
                cmd.Parameters.AddWithValue("Remesado", dts.gRemesado)
                cmd.Parameters.AddWithValue("Devuelto", dts.gDevuelto)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function Pagado(ByVal iidVencimiento As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update VencimientosProv set Pagado = 1, idModifica = @idModifica, Modificacion = @Modificacion  where idVencimiento = @idVencimiento "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idVencimiento", iidVencimiento)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function Remesado(ByVal iidVencimiento As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update VencimientosProv set Remesado = 1, idModifica = @idModifica, Modificacion = @Modificacion  where idVencimiento = @idVencimiento "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idVencimiento", iidVencimiento)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function Devuelto(ByVal iidVencimiento As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update VencimientosProv set Devuelto = 1, idModifica = @idModifica, Modificacion = @Modificacion  where idVencimiento = @idVencimiento "
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idVencimiento", iidVencimiento)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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


    Public Function buscaPrimerDiaVencimientoPendiente(ByVal iidProveedor As Integer) As Date  ' Busca la primera fecha dentro de la tabla Facturas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidProveedor = 0 Then
                sel = "SELECT MIN(Vencimiento) FROM FacturasProv as FA left join VencimientosProv as VE ON VE.idFactura = FA.idFactura Where Pagado = 0 Or Devuelto = 1 "
            Else
                sel = "SELECT MIN(Vencimiento) FROM FacturasProv as FA left join VencimientosProv as VE ON VE.idFactura = FA.idFactura  where (Pagado = 0 Or Devuelto = 1) AND  idProveedor = " & iidProveedor
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()

            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                If Date.TryParse(o, fecha) Then
                    con.Close()
                    Return fecha
                Else
                    con.Close()
                    Return Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function buscaUltimoDiaVencimientoPendiente(ByVal iidProveedor As Integer) As Date  ' Busca la primera fecha dentro de la tabla Facturas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidProveedor = 0 Then
                sel = "SELECT Max(Vencimiento) FROM FacturasProv as FA left join VencimientosProv as VE ON VE.idFactura = FA.idFactura Where Pagado = 0 Or Devuelto = 1 "
            Else
                sel = "SELECT Max(Vencimiento) FROM FacturasProv as FA left join VencimientosProv as VE ON VE.idFactura = FA.idFactura  where (Pagado = 0 Or Devuelto = 1) AND  idProveedor = " & iidProveedor
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()

            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return Now.Date
            Else
                If Date.TryParse(o, fecha) Then
                    con.Close()
                    Return fecha
                Else
                    con.Close()
                    Return Nothing
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function VencimientosCaducados(ByVal iidFactura As Integer) As Integer
        'Devuelve el número de vencimientos no pagados o devueltos a fecha de ayer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "select COUNT(idVencimiento) from VencimientosProv where idFactura = " & iidFactura & " and   Vencimiento < GETdate() and (Pagado = 0 or Devuelto = 1)  "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try
        End Using

    End Function


    Public Function borrarFactura(ByVal iidFactura As Integer) As Boolean  ' Borra una cabecera de AbonoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from VencimientosProv where idFactura = " & iidFactura
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
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function

    Public Function borrar(ByVal iidVencimiento As Integer) As Boolean  ' Borra una cabecera de AbonoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from VencimientosProv where idVencimiento = " & iidVencimiento
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
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function


    Public Function Clonar(ByVal dts As DatosVencimientoProv) As DatosVencimientoProv
        Dim dtsN As New DatosVencimientoProv
        dtsN.gidVencimiento = dts.gidVencimiento
        dtsN.gidFactura = dts.gidFactura
        dtsN.gVencimiento = dts.gVencimiento
        dtsN.gImporte = dts.gImporte
        dtsN.gPagado = dts.gPagado
        dtsN.gRemesado = dts.gRemesado
        dtsN.gDevuelto = dts.gDevuelto
        dtsN.gidProveedor = dts.gidProveedor
        dtsN.gProveedor = dts.gProveedor
        dtsN.gidBanco = dts.gidBanco
        dtsN.gBanco = dts.gBanco
        dtsN.gIBAN = dts.gIBAN
        dtsN.gcodMoneda = dts.gcodMoneda
        dtsN.gSimbolo = dts.gSimbolo
        dtsN.gnumFactura = dts.gnumFactura
        Return dtsN
    End Function


    Public Function Iguales(ByVal dts1 As DatosVencimientoProv, ByVal dts2 As DatosVencimientoProv) As Boolean
        Iguales = (dts1.gidFactura = dts2.gidFactura) And (dts1.gVencimiento = dts2.gVencimiento) And (dts1.gImporte = dts2.gImporte) And (dts1.gPagado = dts2.gPagado) And (dts1.gDevuelto = dts2.gDevuelto) And (dts1.gRemesado = dts2.gRemesado)
    End Function


End Class
