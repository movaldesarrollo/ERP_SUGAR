Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class funcionesFacturacion
    Inherits conexion
    Private funcCB As New FuncionesCuentasBancarias
    Dim cmd As SqlCommand

    Public Function mostrarCli(ByVal iidCliente As Integer) As datosfacturacion
        Try
            If iidCliente > 0 Then
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String = "select Facturacion.*, Divisa, Simbolo, TipoPago, MedioPago, TipoIVA, TipoRecargoEq, TipoValorado, TiposIVA.Nombre as NombreTipoIVA, TipoRetencion, TiposRetencion.Nombre as NombreTipoRet, SinCuenta, Giro, Transferencia "
                sel = sel & " from facturacion left join TiposPago on TiposPago.idTipoPago= facturacion.idTipoPago"
                sel = sel & " Left Join MediosPago on MediosPAgo.idMedioPago = Facturacion.idMedioPago "
                sel = sel & " left join Monedas ON Monedas.codMoneda = Facturacion.codMoneda "
                sel = sel & " left join TiposIVA ON TiposIVA.idTipoIVA = Facturacion.idTipoIVA "
                sel = sel & " left join TiposRetencion ON TiposRetencion.idTipoRetencion = Facturacion.idTipoRetencion "
                sel = sel & " left join TiposValorado ON TiposValorado.idTipoValorado = Facturacion.idTipoValorado "
                sel = sel & " where idCliente = " & iidCliente

                cmd = New SqlCommand(sel, con)

                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Dim dts As New datosfacturacion
                    Dim linea As DataRow
                    Dim SinCuenta As Boolean
                    Dim Giro As Boolean
                    Dim Transferencia As Boolean
                    For Each linea In dt.Rows
                        dts.gidFacturacion = linea("idFacturacion")
                        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idPRoveedor"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gidMedioPago = If(linea("idMedioPago") Is DBNull.Value, 0, linea("idMedioPago"))
                        dts.gidTipoPago = If(linea("idTipoPago") Is DBNull.Value, 0, linea("idTipoPago"))
                        dts.gDiaPago1 = If(linea("diaPago1") Is DBNull.Value, 0, linea("diaPago1"))
                        dts.gDiaPago2 = If(linea("diaPago2") Is DBNull.Value, 0, linea("diaPago2"))
                        'dts.gAlbaranValorado = If(linea("AlbaranValorado") Is DBNull.Value, False, linea("AlbaranValorado"))
                        dts.gExentoPagosAgosto = If(linea("ExentoPagosAgosto") Is DBNull.Value, False, linea("ExentoPagosAgosto"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.genvioCorreo = If(linea("envioCorreo") Is DBNull.Value, False, linea("envioCorreo"))
                        dts.gmedioEntrega = If(linea("medioEntrega") Is DBNull.Value, "", linea("medioEntrega"))
                        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, 0, linea("Transporte"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, 0, linea("Descuento2"))
                        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
                        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
                        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
                        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, False, linea("RecargoEquivalencia"))
                        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))

                        dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))
                        dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, "", linea("MedioPago"))
                        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "EURO", linea("Divisa"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
                        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
                        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
                        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
                        dts.gNombreTipoRet = If(linea("NombreTipoRet") Is DBNull.Value, "", linea("NombreTipoRet"))
                        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, 0, linea("TipoValorado"))
                        SinCuenta = If(linea("SinCuenta") Is DBNull.Value, False, linea("SinCuenta"))
                        Transferencia = If(linea("Transferencia") Is DBNull.Value, False, linea("Transferencia"))
                        Giro = If(linea("Giro") Is DBNull.Value, False, linea("Giro"))
                        If SinCuenta Then
                            dts.gCuentas = New List(Of DatosCuentaBancaria)
                        ElseIf Transferencia Then
                            dts.gCuentas = funcCB.Mostrar(0, True) 'Cuentas propias
                        ElseIf Giro Then
                            dts.gCuentas = funcCB.Mostrar(dts.gidFacturacion, True, " and CuentasBancarias.activo=1 ")
                        End If


                    Next
                    Return dts
                Else
                    Return Nothing
                    con.Close()
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function mostrarProv(ByVal iidProveedor As Integer) As datosfacturacion
        Try

            If iidProveedor > 0 Then
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String = "select Facturacion.*, Divisa, Simbolo, TipoPago, MedioPago, TipoIVA, TipoRecargoEq, TipoValorado, TiposIVA.Nombre as NombreTipoIVA, TipoRetencion, TiposRetencion.Nombre as NombreTipoRet, SinCuenta, Giro, Transferencia  from facturacion "
                sel = sel & "left join TiposPago on TiposPago.idTipoPago= facturacion.idTipoPago"
                sel = sel & " Left Join MediosPago on MediosPAgo.idMedioPago = Facturacion.idMedioPago "
                sel = sel & " left join Monedas ON Monedas.codMoneda = Facturacion.codMoneda "
                sel = sel & " left join TiposIVA ON TiposIVA.idTipoIVA = Facturacion.idTipoIVA "
                sel = sel & " left join TiposRetencion ON TiposRetencion.idTipoRetencion = Facturacion.idTipoRetencion "
                sel = sel & " left join TiposValorado ON TiposValorado.idTipoValorado = Facturacion.idTipoValorado "
                sel = sel & " where idProveedor = " & iidProveedor
                Dim dts As New datosfacturacion
                cmd = New SqlCommand(sel, con)
                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Dim SinCuenta As Boolean
                    Dim Giro As Boolean
                    Dim Transferencia As Boolean
                    Dim linea As DataRow
                    For Each linea In dt.Rows
                        dts.gidFacturacion = linea("idFacturacion")
                        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idPRoveedor"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gidMedioPago = If(linea("idMedioPago") Is DBNull.Value, 0, linea("idMedioPago"))
                        dts.gidTipoPago = If(linea("idTipoPago") Is DBNull.Value, 0, linea("idTipoPago"))
                        dts.gDiaPago1 = If(linea("diaPago1") Is DBNull.Value, 0, linea("diaPago1"))
                        dts.gDiaPago2 = If(linea("diaPago2") Is DBNull.Value, 0, linea("diaPago2"))
                        'dts.gAlbaranValorado = If(linea("AlbaranValorado") Is DBNull.Value, False, linea("AlbaranValorado"))
                        dts.gExentoPagosAgosto = If(linea("ExentoPagosAgosto") Is DBNull.Value, False, linea("ExentoPagosAgosto"))
                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
                        dts.genvioCorreo = If(linea("envioCorreo") Is DBNull.Value, False, linea("envioCorreo"))
                        dts.gmedioEntrega = If(linea("medioEntrega") Is DBNull.Value, "", linea("medioEntrega"))
                        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, 0, linea("Transporte"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
                        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, 0, linea("Descuento2"))
                        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
                        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
                        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
                        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, False, linea("RecargoEquivalencia"))
                        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))

                        dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))
                        dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, "", linea("MedioPago"))
                        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "EURO", linea("Divisa"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
                        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
                        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
                        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
                        dts.gNombreTipoRet = If(linea("NombreTipoRet") Is DBNull.Value, "EXENTO", linea("NombreTipoRet"))
                        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, 0, linea("TipoValorado"))
                        SinCuenta = If(linea("SinCuenta") Is DBNull.Value, False, linea("SinCuenta"))
                        Transferencia = If(linea("Transferencia") Is DBNull.Value, False, linea("Transferencia"))
                        Giro = If(linea("Giro") Is DBNull.Value, False, linea("Giro"))
                        If SinCuenta Then
                            dts.gCuentas = New List(Of DatosCuentaBancaria)
                        ElseIf Transferencia Then
                            dts.gCuentas = funcCB.Mostrar(dts.gidFacturacion, True)
                        ElseIf Giro Then
                            dts.gCuentas = funcCB.Mostrar(0, True) 'Cuentas propias
                        End If
                    Next
                Else
                    con.Close()
                End If
                Return dts
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
       
        End Try
    End Function

    Public Function insertar(ByRef dts As datosfacturacion) As Integer
        'Pasamos el dts por Referencia para poder recargar los datos de bancos al retornar
        Dim sconexion As String = CadenaConexion()
        Dim sel As String

        sel = "insert into facturacion (idProveedor,idCliente, idMedioPago, idTipoPago, diaPago1, diaPago2, ExentoPagosAgosto,  Observaciones, envioCorreo, medioentrega, Transporte, codMoneda, descuento, Descuento2, ProntoPago, idTipoIVA, idTipoRetencion, RecargoEquivalencia, idTipoValorado, idCreador, Creacion) "
        sel = sel & "values (@idProveedor, @idCliente, @idMedioPago, @idTipoPago, @diaPago1, @diaPago2, @ExentoPagosAgosto,  @Observaciones, @envioCorreo, @medioentrega,@Transporte, @codMoneda, @descuento, @Descuento2, @ProntoPago,@idTipoIVA, @idTipoRetencion, @RecargoEquivalencia, @idTipoValorado, @idCreador, @Creacion) SELECT @@Identity"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("diaPago1", dts.gDiaPago1)
                cmd.Parameters.AddWithValue("diaPago2", dts.gDiaPago2)
                'cmd.Parameters.AddWithValue("AlbaranValorado", dts.gAlbaranValorado)
                cmd.Parameters.AddWithValue("ExentoPagosAgosto", dts.gExentoPagosAgosto)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("EnvioCorreo", dts.genvioCorreo)
                cmd.Parameters.AddWithValue("medioentrega", dts.gmedioEntrega)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteScalar())
                If t > 0 Then
                    dts.gidFacturacion = t
                    For Each dtsB As DatosCuentaBancaria In dts.gCuentas
                        dtsB.gidFacturacion = t
                        funcCB.insertar(dtsB)
                    Next
                End If
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

    Public Function actualizar(ByRef dts As datosfacturacion) As Boolean
        'Pasamos el dts por Referencia para poder recargar los datos de bancos al retornar
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update facturacion set  idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, diaPago1 = @diaPago1, diaPago2 = @diaPago2, "
        sel = sel & " ExentoPagosAgosto = @ExentoPagosAgosto, Observaciones = @Observaciones, envioCorreo = @envioCorreo, medioentrega = @medioentrega, Transporte = @Transporte, "
        sel = sel & " codMoneda = @codMoneda, descuento = @descuento, descuento2 = @descuento2, ProntoPago = @ProntoPago, idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, idTipoValorado = @idTipoValorado, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE idFacturacion = " & dts.gidFacturacion
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idFacturacion", dts.gidFacturacion)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("diaPago1", dts.gDiaPago1)
                cmd.Parameters.AddWithValue("diaPago2", dts.gDiaPago2)
                'cmd.Parameters.AddWithValue("AlbaranValorado", dts.gAlbaranValorado)
                cmd.Parameters.AddWithValue("ExentoPagosAgosto", dts.gExentoPagosAgosto)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("EnvioCorreo", dts.genvioCorreo)
                cmd.Parameters.AddWithValue("medioentrega", dts.gmedioEntrega)
                cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)

                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                'If t <> 0 Then
                '    For Each dtsB As DatosCuentaBancaria In dts.gCuentas
                '        If dtsB.gidCuentaBanco <> 0 Then
                '            'dtsB.gidCuentaBanco = funcCB.insertar(dtsB)
                '        Else
                '            If funcCB.actualizar(dtsB) Then
                '            End If
                '        End If
                '    Next
                '    'Ahora hemos de borrar las cuentas que no están en la lista
                '    'Cargamos la lista completa
                '    Dim listaB As List(Of DatosCuentaBancaria) = funcCB.Mostrar(dts.gidFacturacion, False)
                '    Dim encontrado = False
                '    For Each dtsB As DatosCuentaBancaria In listaB
                '        encontrado = False
                '        For Each dtsBB As DatosCuentaBancaria In dts.gCuentas
                '            If dtsBB.gidCuentaBanco = dtsB.gidCuentaBanco Then
                '                'Buscamos las que deben estar
                '                encontrado = True
                '            End If
                '        Next
                '        'Las que no deben estar las borramos
                '        If Not encontrado Then funcCB.borrar(dtsB.gidCuentaBanco, dtsB.gIBAN)
                '    Next
                'End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function campoTransporte(ByVal iidProveedor As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select Transporte from facturacion  WHERE idProveedor = " & iidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CDbl(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function campoCli(ByVal vCampo As String, ByVal vidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select " & vCampo & " from facturacion WHERE idCliente = " & vidCliente, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
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

    Public Function campoTipoPagoCli(ByVal vidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoPago from facturacion LEFT JOIN TipoPago ON facturacion.idTipoPago = TipoPago.idTipoPago WHERE idCliente = " & vidCliente, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
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

    Public Function campoMedioPagoCli(ByVal vidCliente As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select MedioPago from facturacion LEFT JOIN MedioPago ON facturacion.idMedioPago = MedioPago.idMedioPago WHERE idCliente = " & vidCliente, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
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

    Public Function campoidTipoValorado(ByVal iidCliente As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select idTipoValorado from facturacion o WHERE idCliente = " & iidCliente, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
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

    Public Function camposdiaPago1Cli(ByVal vidCliente As Integer) As Integer()
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoPago.diaPago1 as DiaPago, facturacion.diaPago1 as diaPago11, diaPago2 from facturacion LEFT JOIN TipoPago ON facturacion.idTipoPago = TipoPago.idTipoPago WHERE idCliente = " & vidCliente, con)
            con.Open()

            Dim resultado(2) As Integer
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("diapago") Is DBNull.Value Then
                    Else
                        If linea("diapago") Then
                            resultado(1) = If(linea("diaPago11") Is DBNull.Value, 0, linea("diaPago11"))
                            resultado(2) = If(linea("diaPago2") Is DBNull.Value, 0, linea("diaPago2"))

                        End If
                    End If
                Next

                Return resultado
            Else
                con.Close()
                Return Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function campoProv(ByVal vCampo As String, ByVal vidProveedor As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select " & vCampo & " from facturacion WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
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

    Public Function campoTipoPagoProv(ByVal vidProveedor As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoPago from facturacion LEFT JOIN TipoPago ON facturacion.idTipoPago = TipoPago.idTipoPago WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
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

    Public Function campoMedioPagoProv(ByVal vidProveedor As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select MedioPago from facturacion LEFT JOIN MedioPago ON facturacion.idMedioPago = MedioPago.idMedioPago WHERE idProveedor = " & vidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
            con.Close()
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

    Public Function camposdiaPago1PRov(ByVal vidProveedor As Integer) As Integer()
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("select TipoPago.diaPago1 as DiaPago, facturacion.diaPago1 as diaPago11, diaPago2 from facturacion LEFT JOIN TipoPago ON facturacion.idTipoPago = TipoPago.idTipoPago WHERE idProveedor = " & vidProveedor, con)
            con.Open()

            Dim resultado(2) As Integer
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("diapago") Is DBNull.Value Then
                    Else
                        If linea("diapago") Then
                            resultado(1) = If(linea("diaPago11") Is DBNull.Value, 0, linea("diaPago11"))
                            resultado(2) = If(linea("diaPago2") Is DBNull.Value, 0, linea("diaPago2"))

                        End If
                    End If
                Next

                Return resultado
            Else
                con.Close()
                Return Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function idFacturacion(ByVal iidCliente As Integer, ByVal iidProveedor As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select idFacturacion from facturacion "
            cmd = New SqlCommand(sel, con)
            If iidCliente <> 0 Then
                sel = sel & "WHERE idProveedor = " & iidProveedor
            End If
            If iidProveedor <> 0 Then
                sel = sel & "WHERE idCliente = " & iidCliente
            End If

            con.Open()
            Dim o As Object = cmd.ExecuteScalar()
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

    Public Function borrarCliente(ByVal iidCliente As Integer) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "delete from Facturacion where idCliente = " & iidCliente
        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End Using
    End Function

End Class
