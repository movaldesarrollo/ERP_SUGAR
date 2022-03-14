Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesVencimientos

    Inherits conexion
    Dim cmd As SqlCommand

    Private sel0 As String = " select VE.*, IBAN,FA.idCliente, NombreFiscal as Cliente,CB.idBanco, Bancos.Banco,FA.codMoneda, simbolo  from Vencimientos as VE " _
    & " left join Facturas as FA ON FA.numFactura = VE.numFactura " _
    & " left Join Clientes ON Clientes.idCliente = FA.idCliente" _
    & " left join MediosPago as MP ON MP.idMedioPago = FA.idMedioPago" _
    & " left join CuentasBancarias as CB ON CB.idCuentaBanco = FA.idCuentaBanco" _
    & " left Join Bancos ON Bancos.idBanco = CB.idBanco " _
    & " left join Monedas ON Monedas.codMoneda = FA.codMoneda"

    Public Function Mostrar(ByVal inumFactura As Integer) As List(Of DatosVencimiento)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE VE.numFactura = " & inumFactura & " Order By  Vencimiento ASC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosVencimiento)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosVencimiento
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idVencimiento") Is DBNull.Value Then
                    Else
                        dts = New DatosVencimiento
                        dts.gidVencimiento = linea("idVencimiento")
                        dts.gnumFactura = If(linea("NumFactura") Is DBNull.Value, 0, linea("numFactura"))
                        dts.gVencimiento = If(linea("Vencimiento") Is DBNull.Value, Now.Date, linea("Vencimiento"))
                        dts.gImporte = If(linea("Importe") Is DBNull.Value, 0, linea("Importe"))
                        dts.gCobrado = If(linea("Cobrado") Is DBNull.Value, False, linea("Cobrado"))
                        dts.gRemesado = If(linea("Remesado") Is DBNull.Value, False, linea("Remesado"))
                        dts.gDevuelto = If(linea("Devuelto") Is DBNull.Value, False, linea("Devuelto"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gidBanco = If(linea("idBanco") Is DBNull.Value, 0, linea("idBanco"))
                        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
                        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))

                        lista.Add(dts)
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

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosVencimiento)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE numFactura = " & inumFactura & " Order By  Vencimiento ASC "
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By Vencimiento ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosVencimiento)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosVencimiento
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idVencimiento") Is DBNull.Value Then
                    Else
                        dts = New DatosVencimiento
                        dts.gidVencimiento = linea("idVencimiento")
                        dts.gnumFactura = If(linea("NumFactura") Is DBNull.Value, 0, linea("numFactura"))
                        dts.gVencimiento = If(linea("Vencimiento") Is DBNull.Value, Now.Date, linea("Vencimiento"))
                        dts.gImporte = If(linea("Importe") Is DBNull.Value, 0, linea("Importe"))
                        dts.gCobrado = If(linea("Cobrado") Is DBNull.Value, False, linea("Cobrado"))
                        dts.gRemesado = If(linea("Remesado") Is DBNull.Value, False, linea("Remesado"))
                        dts.gDevuelto = If(linea("Devuelto") Is DBNull.Value, False, linea("Devuelto"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gidBanco = If(linea("idBanco") Is DBNull.Value, 0, linea("idBanco"))
                        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
                        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))

                        lista.Add(dts)
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

    Public Function Mostrar1(ByVal iidVencimiento As Integer) As DatosVencimiento
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            'sel = " select * from vencimientos WHERE idVencimiento = " & iidVencimiento
            sel = sel0 & " WHERE idVencimiento = " & iidVencimiento

            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosVencimiento
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
                        dts.gidVencimiento = linea("idVencimiento")
                        dts.gnumFactura = If(linea("NumFactura") Is DBNull.Value, 0, linea("numFactura"))
                        dts.gVencimiento = If(linea("Vencimiento") Is DBNull.Value, Now.Date, linea("Vencimiento"))
                        dts.gImporte = If(linea("Importe") Is DBNull.Value, 0, linea("Importe"))
                        dts.gCobrado = If(linea("Cobrado") Is DBNull.Value, False, linea("Cobrado"))
                        dts.gRemesado = If(linea("Remesado") Is DBNull.Value, False, linea("Remesado"))
                        dts.gDevuelto = If(linea("Devuelto") Is DBNull.Value, False, linea("Devuelto"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gidBanco = If(linea("idBanco") Is DBNull.Value, 0, linea("idBanco"))
                        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
                        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
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

    Public Function insertar(ByVal dts As DatosVencimiento) As Integer 'Inserta una nueva Factura y devuelve el nº

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into Vencimientos (numFactura, Vencimiento, Importe, Cobrado,Remesado, Devuelto, idCreador, Creacion) "
        sel = sel & " values (@numFactura, @Vencimiento, @Importe, @Cobrado, @Remesado, @Devuelto, @idCreador, @Creacion) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("Vencimiento", dts.gVencimiento)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("Cobrado", dts.gCobrado)
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

    Public Function actualizar(ByVal dts As DatosVencimiento) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Vencimientos set numFactura = @numFactura, Vencimiento = @Vencimiento, Importe = @Importe, Cobrado = @Cobrado, Remesado = @Remesado, Devuelto = @Devuelto, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " WHERE idVencimiento = @idVencimiento"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idVencimiento", dts.gidVencimiento)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("Vencimiento", dts.gVencimiento)
                cmd.Parameters.AddWithValue("Importe", dts.gImporte)
                cmd.Parameters.AddWithValue("Cobrado", dts.gCobrado)
                cmd.Parameters.AddWithValue("Remesado", dts.gRemesado)
                cmd.Parameters.AddWithValue("Devuelto", dts.gDevuelto)
                cmd.Parameters.AddWithValue("idModifica", dts.gidUsuario)
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

    Public Function Cobrado(ByVal iidVencimiento As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update Vencimientos set Cobrado = 1, idModifica = @idModifica, Modificacion = @Modificacion  where idVencimiento = @idVencimiento "
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
        Dim sel As String = "Update Vencimientos set Remesado = 1, idModifica = @idModifica, Modificacion = @Modificacion  where idVencimiento = @idVencimiento "
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
        Dim sel As String = "Update Vencimientos set Devuelto = 1, idModifica = @idModifica, Modificacion = @Modificacion  where idVencimiento = @idVencimiento "
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

    Public Function buscaPrimerDiaVencimientoPendiente(ByVal iidCliente As Integer) As Date  ' Busca la primera fecha dentro de la tabla Facturas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MIN(Vencimiento) FROM Facturas left join Vencimientos ON Vencimientos.numFactura = Facturas.numFactura Where Cobrado = 0 Or Devuelto = 1 "
            Else
                sel = "SELECT MIN(Vencimiento) FROM Facturas left join Vencimientos ON Vencimientos.numFactura = Facturas.numFactura  where (Cobrado = 0 Or Devuelto = 1) AND  idCliente = " & iidCliente
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

    Public Function buscaUltimoDiaVencimientoPendiente(ByVal iidCliente As Integer) As Date  ' Busca la primera fecha dentro de la tabla Facturas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT Max(Vencimiento) FROM Facturas left join Vencimientos ON Vencimientos.numFactura = Facturas.numFactura Where Cobrado = 0 Or Devuelto = 1 "
            Else
                sel = "SELECT Max(Vencimiento) FROM Facturas left join Vencimientos ON Vencimientos.numFactura = Facturas.numFactura  where (Cobrado = 0 Or Devuelto = 1) AND  idCliente = " & iidCliente
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

    Public Function VencimientosCaducados(ByVal numFactura As Integer) As Integer
        'Devuelve el número de vencimientos no cobrados o devueltos a fecha de ayer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "select COUNT(idVencimiento) from Vencimientos where numFactura = " & numFactura & " and   Vencimiento < GETdate() and (Cobrado = 0 or Devuelto = 1)  "
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

    Public Function PrimerVencimientoNoPagado(ByVal numFactura As Integer) As Date
        'Devuelve el número de vencimientos no cobrados o devueltos a fecha de ayer
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = " Select MIN(Vencimiento) from Vencimientos where numFactura = " & numFactura & " and (Cobrado=0 or Devuelto=1) "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Then
                    Return CDate("1-1-1900")
                Else
                    Return CDate(o)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try
        End Using

    End Function

    Public Function borrarFactura(ByVal inumFactura As Integer) As Boolean  ' Borra una cabecera de AbonoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Vencimientos where numFactura = " & inumFactura
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
        Dim sel As String = "delete from Vencimientos where idVencimiento = " & iidVencimiento
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

    Public Function Clonar(ByVal dts As DatosVencimiento) As DatosVencimiento
        Dim dtsN As New DatosVencimiento
        dtsN.gidVencimiento = dts.gidVencimiento
        dtsN.gnumFactura = dts.gnumFactura
        dtsN.gVencimiento = dts.gVencimiento
        dtsN.gImporte = dts.gImporte
        dtsN.gCobrado = dts.gCobrado
        dtsN.gRemesado = dts.gRemesado
        dtsN.gDevuelto = dts.gDevuelto
        dtsN.gidCliente = dts.gidCliente
        dtsN.gCliente = dts.gCliente
        dtsN.gidBanco = dts.gidBanco
        dtsN.gBanco = dts.gBanco
        dtsN.gIBAN = dts.gIBAN
        dtsN.gcodMoneda = dts.gcodMoneda
        dtsN.gSimbolo = dts.gSimbolo
        Return dtsN
    End Function

    Public Function Iguales(ByVal dts1 As DatosVencimiento, ByVal dts2 As DatosVencimiento) As Boolean
        Iguales = (dts1.gnumFactura = dts2.gnumFactura) And (dts1.gVencimiento = dts2.gVencimiento) And (dts1.gImporte = dts2.gImporte) And (dts1.gCobrado = dts2.gCobrado) And (dts1.gDevuelto = dts2.gDevuelto) And (dts1.gRemesado = dts2.gRemesado)
    End Function
End Class
