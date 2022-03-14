Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesAlbaranesProv

    Inherits conexion
    Dim cmd As SqlCommand

    'Dim sel0 As String = " Select DOC.*, Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, PR.NombreComercial as Proveedor, PR.Observaciones as ObservacionesProv, Estado, Simbolo, Nombre & ' ' & Apellidos as Persona, " _
    '         & " (select sum( CantidadRecibida * precioNetoUnitario * (1- (Descuento/100)))  from ConceptosAlbaranesProv where idAlbaran = DOC.idAlbaran) as Base" _
    '         & " from AlbaranesProv as DOC " _
    '         & " left join Proveedores as PR ON PR.idProveedor = DOC.idProveedor " _
    '         & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
    '         & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
    '         & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
    '         & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
    '         & " LEft join Personal ON Personal.idPersona = DOC.idPersona " _
    '         & " Left join Contactos ON Contactos.idProveedor = DOC.idProveedor " _
    '         & " Left Join TiposValorado ON TiposValorado.idTipoValorado = DOC.idTipovalorado "
           
    Dim sel0 As String = " Select DOC.*, PR.NombreComercial as Proveedor,PR.codProveedor,PR.Observaciones as ObservacionesProv, Localidad + ', ' + Direccion as Direccion, " _
              & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, Divisa, Simbolo, Estado, AT.nombreComercial as AgenciaTransporte, " _
              & " TiposRetencion.TipoRetencion, C2.Nombre + ' ' + C2.Apellidos as Persona, TipoValorado " _
              & " from AlbaranesProv as DOC " _
              & " Left join Proveedores as PR ON PR.idProveedor = DOC.idProveedor " _
              & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
              & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
              & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
              & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
              & " Left Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
              & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
              & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto " _
              & " Left join TiposValorado ON TiposValorado.idTipoValorado = DOC.idTipoValorado" _
              & " left outer join Proveedores AS AT ON AT.idProveedor = DOC.idTransporte "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosAlbaranProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numAlbaran DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosAlbaranProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosAlbaranProv
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idAlbaran") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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



    Private Function CargarLinea(ByVal linea As DataRow) As DatosAlbaranProv
        Dim dts As New DatosAlbaranProv
        dts.gidAlbaran = linea("idAlbaran")
        dts.gnumAlbaran = If(linea("NumAlbaran") Is DBNull.Value, "", linea("NumAlbaran"))
        dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
        dts.gidFactura = If(linea("idFactura") Is DBNull.Value, 0, linea("idFactura"))
        dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
        dts.gReferencia = If(linea("Referencia") Is DBNull.Value, "", linea("Referencia"))
        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))
        dts.gidTipoValorado = If(linea("idTipoValorado") Is DBNull.Value, 0, linea("idTipoValorado"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, False, linea("RecargoEquivalencia"))
        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))
        dts.gBultos = If(linea("Bultos") Is DBNull.Value, 0, linea("Bultos"))
        dts.gidTransporte = If(linea("idTransporte") Is DBNull.Value, 0, linea("idTransporte"))
        dts.gTransporte = If(linea("Transporte") Is DBNull.Value, "", linea("Transporte"))
        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))

        'Datos de otras tablas
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
        dts.gObservacionesProv = If(linea("ObservacionesProv") Is DBNull.Value, "", linea("ObservacionesProv"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
        dts.gTipoValorado = If(linea("TipoValorado") Is DBNull.Value, "", linea("TipoValorado"))
        dts.gAgenciaTransporte = If(linea("AgenciaTransporte") Is DBNull.Value, "", linea("AgenciaTransporte"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))
        'dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        Call DatosCalculados(dts)

        Return dts

    End Function


   


    Public Function Mostrar(ByVal iidFactura As Integer) As List(Of DatosAlbaranProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE idFactura = " & iidFactura & " Order By numAlbaran DESC "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosAlbaranProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosAlbaranProv
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idAlbaran") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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



    Public Function Mostrar1(ByVal idAlbaran As Integer) As DatosAlbaranProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE DOC.idAlbaran = " & idAlbaran
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosAlbaranProv
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idAlbaran") Is DBNull.Value Then
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


    Public Function DatosCalculados(ByRef dts As DatosAlbaranProv) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, TiposIVA.TipoIVA, TiposIVA.TipoRecargoEq, numPedido, numFactura from ConceptosAlbaranesProv as CO "
            sel = sel & " left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " Left join ConceptosPedidosProv as CP on CP.idConcepto = CO.idConceptoPedidoProv "
            sel = sel & " Left join FacturasProv ON FacturasProv.idFactura = CO.idFactura "
            sel = sel & " where CO.idAlbaran = " & dts.gidAlbaran
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosPedidoProv)
            Dim linea As DataRow
            Dim numSPedido As New List(Of Integer)
            Dim Facturas As New List(Of IDComboBox)


            Dim Base As Double = 0 'Suma de precios con todos los descuentos
            Dim TotalIVA As Double = 0
            Dim TotalRE As Double = 0
            Dim subTotal As Double = 0
            Dim subTotalPP As Double = 0
            Dim descuento As Double = 0 'Descuento de linea
            'Dim descuentoG As Double = (1 - (dts.gProntoPago / 100)) * (1 - (dts.gDescuento / 100)) * (1 - (dts.gDescuento2 / 100))
            Dim DescuentoC As Double = 0

            Dim sumaDescuentos As Double = 0
            Dim sumaDescuentosPP As Double = 0
            Dim precioNetoUnitario As Double = 0
            Dim TipoIVA As Double = 0
            Dim TipoRE As Double = 0

            Dim PVP As Double = 0
            Dim cantidad As Double
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    'Hay que acumular los descuentos totales
                    descuento = If(linea("descuento") Is DBNull.Value, 0, linea("descuento"))

                    PVP = If(linea("PVPUnitario") Is DBNull.Value, 0, linea("PVPUnitario"))
                    precioNetoUnitario = If(linea("PrecioNetoUnitario") Is DBNull.Value, 0, linea("PrecioNetoUnitario"))
                    cantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
                    If descuento <> 0 Then
                        subTotal = cantidad * precioNetoUnitario * (1 - (descuento / 100))
                        sumaDescuentos = sumaDescuentos + (precioNetoUnitario * (descuento / 100))
                    Else
                        If precioNetoUnitario > 0 Then
                            subTotal = cantidad * precioNetoUnitario
                        Else
                            subTotal = cantidad * precioNetoUnitario
                        End If
                    End If


                    If linea("numFactura") Is DBNull.Value OrElse linea("idFactura") Is DBNull.Value Then
                    Else
                        If Not Contiene(Facturas, New IDComboBox(linea("numFactura"), linea("idFactura"))) Then
                            Facturas.Add(New IDComboBox(linea("numFactura"), linea("idFactura")))
                        End If

                    End If
                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        If linea("numPedido") <> 0 And (numSPedido.Count = 0 OrElse Not numSPedido.Contains(linea("numPedido"))) Then
                            numSPedido.Add(linea("numPedido"))
                        End If
                    End If

                    subTotalPP = subTotal * (1 - (dts.gProntoPago / 100))
                    Base = Base + subTotalPP
                    TipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, CDbl(linea("TipoIVA")))
                    TipoRE = If(linea("TipoRecargoEq") Is DBNull.Value, 0, CDbl(linea("TipoRecargoEq")))
                    TotalIVA = TotalIVA + (subTotalPP * (TipoIVA / 100))  'El IVA se calcula sobre el importe neto con todos los descuentos
                    If dts.gRecargoEquivalencia Then
                        TotalRE = TotalRE + subTotalPP * (TipoRE / 100)
                    End If
                    sumaDescuentosPP = sumaDescuentosPP + subTotal * (dts.gProntoPago / 100)
                Next
                'dts.gImporteDescuentos = sumaDescuentos
                dts.gImportePP = sumaDescuentosPP


                If dts.gPortes = "P" Or dts.gPortes = "D" Then
                    dts.gBase = Base  'Antes de descuentos generales
                    dts.gTotalIVA = TotalIVA
                    dts.gTotalRE = TotalRE
                Else
                    Dim funcFA As New funcionesFacturacion
                    Dim dtsFA As datosfacturacion = funcFA.mostrarProv(dts.gidProveedor)
                    dts.gBase = Base + dts.gPrecioTransporte
                    dts.gTotalIVA = TotalIVA + dts.gPrecioTransporte * (dtsFA.gTipoIVA / 100)
                    If dts.gRecargoEquivalencia Then
                        dts.gTotalRE = TotalRE + dts.gPrecioTransporte * (dtsFA.gTipoRecargoEq / 100)
                    Else
                        dts.gTotalRE = TotalRE
                    End If
                End If

                dts.gnumSPedido = numSPedido
                dts.gFacturas = Facturas

                dts.gRetencion = dts.gBase * (dts.gTipoRetencion / 100)
                dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
                Return True
            Else
                con.Close()
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Private Function Contiene(ByVal lista As List(Of IDComboBox), ByVal elemento As IDComboBox) As Boolean
        If lista Is Nothing OrElse lista.Count = 0 Then Return False
        For Each item As IDComboBox In lista
            If item.ItemData = elemento.ItemData And item.Name = elemento.Name Then Return True
        Next
        Return False
    End Function


    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla AlbaranesProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM AlbaranesProv", con)
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

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla AlbaranesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM AlbaranesProv", con)
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





    Public Function Referencia(ByVal idAlbaran As Integer) As String ' Busca la última fecha dentro de la tabla AlbaranesProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT Referencia FROM AlbaranesProv Where idAlbaran = " & idAlbaran, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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


    Public Function ExisteAlbaran(ByVal numAlbaran As String, ByVal iidProveedor As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            numAlbaran = UCase(Trim(numAlbaran))
            Dim sel As String = "SELECT count(idAlbaran) FROM AlbaranesProv Where idProveedor = " & iidProveedor & " AND numAlbaran = '" & numAlbaran & "' "
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return (CInt(o) > 0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function



    Public Function idEstado(ByVal idAlbaran As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM AlbaranesProv Where idAlbaran = " & idAlbaran, con)
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

    Public Function idAlbaran(ByVal numAlbaran As String, ByVal iidProveedor As Integer) As String
        Try
            If iidProveedor = 0 Or numAlbaran = "0" Or numAlbaran = "" Then
                Return 0
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)

                cmd = New SqlCommand("SELECT idAlbaran FROM AlbaranesProv Prov Where numAlbaran = '" & numAlbaran & "' AND idProveedor = " & iidProveedor, con)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CStr(o)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function



    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM AlbaranesProv", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM AlbaranesProv WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function listaProv() As List(Of IDComboBox)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreComercial, AP.idProveedor from AlbaranesProv as AP left Join Proveedores ON Proveedores.idProveedor = AP.idProveedor ", con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idProveedor") Is DBNull.Value Or linea("NombreComercial") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(linea("NombreComercial"), linea("idProveedor")))
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



    Public Function insertar(ByVal dts As DatosAlbaranProv) As Integer

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into AlbaranesProv (numAlbaran, idProveedor, idUbicacion, idFactura, Fecha, Referencia, SolicitadoVia, idContacto, Observaciones, Notas, idTipoValorado, idEstado, RecargoEquivalencia, ProntoPago, codMoneda, idPersona, PrecioTransporte, Portes, Bultos, idTransporte, Transporte, idCreador, Creacion, idrazonsocial ) "
        sel = sel & " values            (@numAlbaran,@idProveedor,@idUbicacion,@idFactura,@Fecha,@Referencia,@SolicitadoVia,@idContacto,@Observaciones,@Notas,@idTipoValorado,@idEstado,@RecargoEquivalencia,@ProntoPago,@codMoneda,@idPersona,@PrecioTransporte,@Portes,@Bultos,@idTransporte,@Transporte,@idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1)  ) select @@identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = Parametros(dts, New SqlCommand(sel, con))
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                dts.gidAlbaran = cmd.ExecuteScalar()
                con.Close()
                Return dts.gidAlbaran
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using

    End Function

    Private Function Parametros(ByVal dts As DatosAlbaranProv, ByVal cmd As SqlCommand) As SqlCommand
        cmd.Parameters.AddWithValue("numAlbaran", dts.gnumAlbaran)
        cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
        cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
        cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
        cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
        cmd.Parameters.AddWithValue("Referencia", dts.gReferencia)
        cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
        cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
        cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
        cmd.Parameters.AddWithValue("Notas", dts.gNotas)
        cmd.Parameters.AddWithValue("idTipoValorado", dts.gidTipoValorado)
        cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
        cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
        cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
        cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
        cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
        cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
        cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
        cmd.Parameters.AddWithValue("Portes", dts.gPortes)
        cmd.Parameters.AddWithValue("Bultos", dts.gBultos)
        cmd.Parameters.AddWithValue("idTransporte", dts.gidTransporte)
        cmd.Parameters.AddWithValue("Transporte", dts.gTransporte)

        Return cmd
    End Function

    Public Function actualizar(ByVal dts As DatosAlbaranProv) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update AlbaranesProv set numAlbaran = @numAlbaran, idProveedor = @idProveedor, idUbicacion = @idUbicacion, idFactura = @idFactura, Fecha = @Fecha,Referencia = @Referencia,SolicitadoVia = @SolicitadoVia,   "
        sel = sel & " idContacto = @idContacto, Observaciones = @Observaciones,Notas =@Notas, idTipoValorado = @idTipoValorado,idEstado = @idEstado, idTipoRetencion = @idTipoRetencion,RecargoEquivalencia = @RecargoEquivalencia, "
        sel = sel & " ProntoPago = @ProntoPago, codMoneda = @codmoneda, idPersona = @idPersona, PrecioTransporte = @PrecioTransporte, Portes = @Portes, Bultos = @Bultos, idTransporte = @idTransporte, Transporte = @Transporte,  idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE idAlbaran = @idAlbaran"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = Parametros(dts, New SqlCommand(sel, con))
                cmd.Parameters.AddWithValue("idAlbaran", dts.gidAlbaran)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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



    Public Function actualizaEstado(ByVal iidAlbaran As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update AlbaranesProv set idEstado = @idEstado where idAlbaran = @idAlbaran "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("idAlbaran", iidAlbaran)
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



    Public Function actualizaMoneda(ByVal iidAlbaran As Integer, ByVal codMoneda As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update AlbaranesProv set codMoneda = @codMoneda where idAlbaran = @idAlbaran "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", codMoneda)
                cmd.Parameters.AddWithValue("idAlbaran", iidAlbaran)
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


    Public Function actualizaidFactura(ByVal iidAlbaran As Integer, ByVal iidFactura As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update AlbaranesProv set idFactura = @idFactura where idAlbaran = @idAlbaran "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idFactura", iidFactura)
                cmd.Parameters.AddWithValue("idAlbaran", iidAlbaran)
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





    Public Function borrar(ByVal iidAlbaran As Integer) As Boolean  ' Borra una cabecera de AlbaranProv

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from AlbaranesProv where idAlbaran = " & iidAlbaran
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            End Try
        End Using

    End Function






End Class
