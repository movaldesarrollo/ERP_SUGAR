Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class FuncionesFacturas

    Inherits conexion
    Dim cmd As SqlCommand

    Dim funcVE As New FuncionesVencimientos

    Dim sel0 As String = " Select DOC.*, Clientes.NombreFiscal as Cliente,Clientes.Observaciones as ObservacionesCli,subCliente, Localidad + ', ' + Direccion as Direccion, Liquidaciones.FechaLiquidacion, " _
             & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, MedioPago, TipoPago,Bancos.Banco,IBAN,Divisa,Simbolo, TiposIVA.TipoIVA as TipoIVATabla, Estado, " _
             & " TiposIVA.Nombre as NombreTipoIVA, TiposIVA.TipoRecargoEq as TipoRecargoEqTabla, TiposRetencion.TipoRetencion as TipoRetencionTabla, TiposRetencion.Nombre as NombreTipoRetencion, C2.Nombre + ' ' + C2.Apellidos as Persona, " _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosFacturas where numFactura = DOC.numFactura) as Base, " _
             & " (select SUM(Importe) From Vencimientos Where Vencimientos.numFactura = DOC.numFactura and (Cobrado=0 or Devuelto= 1)) as Pendiente, " _
             & " (Select MIN(Vencimiento) from Vencimientos where numFactura = DOC.numFactura and (Cobrado=0 or Devuelto=1)) as PrimerVencimientoNoCobrado " _
             & " from Facturas as DOC " _
             & " Left join Clientes ON Clientes.idCliente = DOC.idCliente " _
             & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
             & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
             & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
             & " Left Outer Join MediosPago ON MediosPago.idMedioPago = DOC.idMedioPago " _
             & " Left Outer Join TiposPago ON TiposPago.idTipoPago = DOC.idTipoPago " _
             & " Left Outer Join CuentasBancarias as CB ON CB.idCuentaBanco = DOC.idCuentaBanco " _
             & " Left Join Bancos ON Bancos.idBanco = CB.idBanco " _
             & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
             & " Left Join TiposIVA ON TiposIVA.idTipoIVA = DOC.idTipoIVA " _
             & " Left outer Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion " _
             & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto " _
             & " Left Join Liquidaciones ON Liquidaciones.idLiquidacion = DOC.idLiquidacion"

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosFactura)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numFactura DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosFactura)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosFactura
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        If Not simplificada Then
                            Call DatosCalculados(dts)
                            dts.gVencimientos = funcVE.Mostrar(dts.gnumFactura)
                        End If

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

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal conDatosCalculados As Boolean, ByVal ConVencimientos As Boolean) As List(Of DatosFactura)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numFactura DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosFactura)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosFactura
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        If conDatosCalculados Then
                            Call DatosCalculados(dts)
                        ElseIf ConVencimientos Then
                            dts.gVencimientos = funcVE.Mostrar(dts.gnumFactura)
                        End If
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

    Public Function Mostrar1FacturaComision(ByVal inumFactura As Integer) As datosFacturaComision
        Dim lista As List(Of datosFacturaComision) = BusquedaLiquidacion(" DOC.numFactura = " & inumFactura, "")
        If Not lista Is Nothing AndAlso lista.Count > 0 Then
            Return lista(0)
        Else
            Return New datosFacturaComision
        End If
    End Function

    Public Function BusquedaLiquidacion(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of datosFacturaComision)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select DOC.*, Clientes.NombreComercial as Cliente, Estado, C2.Nombre + ' ' + C2.Apellidos as Comercial, DOC.codMoneda, Simbolo, Liquidaciones.FechaLiquidacion, "
            sel = sel & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosFacturas where numFactura = DOC.numFactura) as Base, "
            sel = sel & " (select sum(ImporteComision) from ConceptosFacturas where ConceptosFacturas.numFactura = DOC.numFactura) as ImporteComision "
            sel = sel & " from Facturas as DOC "
            sel = sel & " Left join Clientes ON Clientes.idCliente = DOC.idCliente "
            sel = sel & " Left Join Estados ON Estados.idEstado = DOC.idEstado "
            sel = sel & " Left outer join Personal on Personal.idPersona = DOC.idPersona "
            sel = sel & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto "
            sel = sel & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda "
            sel = sel & " Left Join Liquidaciones ON Liquidaciones.idLiquidacion = DOC.idLiquidacion "
            sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numFactura DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of datosFacturaComision)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As datosFacturaComision
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        dts = New datosFacturaComision
                        dts.gnumFactura = linea("numFactura")
                        dts.gFechaFactura = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
                        dts.gidComercial = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
                        dts.gImporteComision = If(linea("ImporteComision") Is DBNull.Value, 0, linea("ImporteComision"))
                        dts.gFechaLiquidacion = If(linea("FechaLiquidacion") Is DBNull.Value, Now.Date, linea("FechaLiquidacion"))
                        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
                        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
                        dts.gComercial = If(linea("Comercial") Is DBNull.Value, "", linea("Comercial"))
                        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
                        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
                        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
                        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
                        dts.gidLiquidacion = If(linea("idLiquidacion") Is DBNull.Value, 0, linea("idLiquidacion"))
                        dts.gLiquidada = dts.gidLiquidacion > 0
                        dts.gComisiones = Comisiones(dts.gnumFactura)
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

    Private Function CargarLinea(ByVal linea As DataRow) As DatosFactura
        Dim dts As New DatosFactura
        Dim subCliente As String
        dts.gnumFactura = linea("NumFactura")
        dts.gReferenciaCliente = If(linea("ReferenciaCliente") Is DBNull.Value, "", linea("ReferenciaCliente"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
        dts.gFechaEntrega = If(linea("FechaEntrega") Is DBNull.Value, Now.Date, linea("FechaEntrega"))
        dts.gidCliente = If(linea("idCliente") Is DBNull.Value, 0, linea("idCliente"))
        dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
        dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
        dts.gidMedioPago = If(linea("idMedioPago") Is DBNull.Value, 0, linea("idMedioPago"))
        dts.gidTipoPago = If(linea("idTipoPago") Is DBNull.Value, 0, linea("idTipoPago"))
        dts.gidCuentaBanco = If(linea("idCuentaBanco") Is DBNull.Value, 0, linea("idCuentaBanco"))
        dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
        dts.gidTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, linea("idTipoIVA"))
        dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
        dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, "", linea("RecargoEquivalencia"))
        dts.gDescuento = If(linea("Descuento") Is DBNull.Value, 0, linea("Descuento"))
        dts.gDescuento2 = If(linea("Descuento2") Is DBNull.Value, 0, linea("Descuento2"))
        dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
        dts.gSolicitadoVia = If(linea("SolicitadoVia") Is DBNull.Value, "", linea("SolicitadoVia"))
        dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gTipoRetencionFac = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
        dts.gTipoIVAFac = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gTipoRecargoEqFac = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
        dts.gidLiquidacion = If(linea("idLiquidacion") Is DBNull.Value, 0, linea("idLiquidacion"))
        dts.gLiquidadaComision = dts.gidLiquidacion > 0
        dts.gFechaLiquidacion = If(linea("FechaLiquidacion") Is DBNull.Value, Now.Date, linea("FechaLiquidacion"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        subCliente = If(linea("subCliente") Is DBNull.Value, "", linea("subCliente"))
        dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
        dts.gDireccion = If(subCliente = "", dts.gDireccion, subCliente & ": " & dts.gDireccion)
        dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
        dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, "", linea("MedioPago"))
        dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, "", linea("TipoPago"))
        dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
        dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
        dts.gDivisa = If(linea("Divisa") Is DBNull.Value, "", linea("Divisa"))
        dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, dts.gcodMoneda, linea("Simbolo"))
        dts.gTipoIVA = If(linea("TipoIVATabla") Is DBNull.Value, 0, linea("TipoIVATabla"))
        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
        dts.gTipoRecargoEq = If(linea("TipoRecargoEqTabla") Is DBNull.Value, 0, linea("TipoRecargoEqTabla"))
        dts.gTipoRetencion = If(linea("TipoRetencionTabla") Is DBNull.Value, 0, linea("TipoRetencionTabla"))
        dts.gNombreTipoRetencion = If(linea("NombreTipoRetencion") Is DBNull.Value, "", linea("NombreTipoRetencion"))
        dts.gObservacionesCli = If(linea("ObservacionesCli") Is DBNull.Value, "", linea("ObservacionesCli"))
        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
        dts.gPendiente = If(linea("Pendiente") Is DBNull.Value, 0, linea("Pendiente"))
        dts.gPrimerVencimientoNoCobrado = If(linea("PrimerVencimientoNoCobrado") Is DBNull.Value, CDate("1-1-1900"), linea("PrimerVencimientoNoCobrado"))
        Return dts
    End Function

    Public Function Mostrar1(ByVal inumFactura As Integer) As DatosFactura
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = sel0 & " WHERE numFactura = " & inumFactura
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosFactura
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                        Call DatosCalculados(dts)
                        dts.gVencimientos = funcVE.Mostrar(dts.gnumFactura)
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

    Public Function DatosCalculados(ByRef dts As DatosFactura) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, C1.numAlbaran  from ConceptosFacturas as CO  "
            sel = sel & " left outer join ConceptosAlbaranes as C1 ON C1.idConcepto= CO.idConceptoAlbaran "
            sel = sel & " where CO.numFactura = " & dts.gnumFactura
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim numSAbono As New List(Of Integer)
            Dim numSAlbaran As New List(Of Integer)


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
                        subTotal = cantidad * PVP * (1 - (descuento / 100))
                        sumaDescuentos = sumaDescuentos + (PVP * (descuento / 100))
                    Else
                        If precioNetoUnitario > 0 Then
                            subTotal = cantidad * precioNetoUnitario
                        Else
                            subTotal = cantidad * PVP
                        End If
                    End If
                    subTotalPP = subTotal * (1 - (dts.gProntoPago / 100))
                    Base = Base + subTotalPP
                    TotalIVA = TotalIVA + (subTotalPP * (If(linea("TipoIVA") Is DBNull.Value, 0, CDbl(linea("TipoIVA")) / 100)))  'El IVA se calcula sobre el importe neto con todos los descuentos
                    If dts.gRecargoEquivalencia Then
                        TotalRE = TotalRE + subTotalPP * (If(linea("TipoRecargoEq") Is DBNull.Value, 0, CDbl(linea("TipoRecargoEq")) / 100))
                    End If
                    sumaDescuentosPP = sumaDescuentosPP + subTotal * (dts.gProntoPago / 100)


                    'If linea("numAbono") Is DBNull.Value Then
                    'Else
                    '    If linea("numAbono") <> 0 Then numSAbono.Add(linea("numAbono"))
                    'End If
                    'If linea("numAlbaran") Is DBNull.Value Then
                    'Else
                    '    numSAlbaran.Add(linea("numAlbaran"))
                    'End If

                    If linea("numAlbaran") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSAlbaran, linea("numAlbaran"))
                    End If

                Next
                dts.gImporteDescuentos = sumaDescuentos
                dts.gImportePP = sumaDescuentosPP
                dts.gBase = Base + dts.gPrecioTransporte
                dts.gTotalIVA = TotalIVA + dts.gPrecioTransporte * (dts.gTipoIVAFac / 100)
                If dts.gRecargoEquivalencia Then
                    dts.gTotalRE = TotalRE + dts.gPrecioTransporte * (dts.gTipoRecargoEqFac / 100)
                Else
                    dts.gTotalRE = TotalRE
                End If

                dts.gnumSAbono = numSAbono
                dts.gnumsAlbaran = numSAlbaran

                dts.gRetencion = dts.gBase * (dts.gTipoRetencionFac / 100)
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

    Private Sub NuevoNumeroEnLista(ByRef lista As List(Of Integer), ByVal nuevoNumero As Integer)
        If nuevoNumero > 0 Then
            Dim existe As Boolean = False
            For Each n As Integer In lista
                If n = nuevoNumero Then existe = True
            Next
            If Not existe Then lista.Add(nuevoNumero)
        End If
    End Sub

    Public Function buscaPrimerDia(ByVal iidCliente As Integer) As Date  ' Busca la primera fecha dentro de la tabla Facturas
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MIN(Fecha) FROM Facturas"
            Else
                sel = "SELECT MIN(Fecha) FROM Facturas where idCliente = " & iidCliente
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

    Public Function buscaUltimoDia(ByVal iidCliente As Integer) As Date ' Busca la última fecha dentro de la tabla FacturasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MAX(Fecha) FROM Facturas"
            Else
                sel = "SELECT MAX(Fecha) FROM Facturas where idCliente = " & iidCliente
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

    Public Function buscaUltimoDoc(ByVal iidCliente As Integer) As Integer ' Busca el último documento de un cliente dado
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If iidCliente = 0 Then
                sel = "SELECT MAX(numFactura) FROM Facturas "
            Else
                sel = "SELECT MAX(numFactura) FROM Facturas where idCliente = " & iidCliente
            End If
            cmd = New SqlCommand(sel, con)
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

    Public Function UltimoPrecioTransporte(ByVal iidCliente As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim inumFactura As Integer = buscaUltimoDoc(iidCliente)
            If inumFactura = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM Facturas where numFactura = " & inumFactura
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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

    Public Function codMoneda(ByVal inumFactura As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If inumFactura = 0 Then
                Return "EU"
            Else
                sel = "SELECT codMoneda FROM Facturas where numFactura = " & inumFactura
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return "EU"
            Else
                Return CStr(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function idComercial(ByVal inumFactura As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If inumFactura = 0 Then
                Return 0
            Else
                sel = "SELECT idComercial FROM Facturas where numFactura = " & inumFactura
            End If
            cmd = New SqlCommand(sel, con)
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

    Public Function ImporteComisiones(ByVal inumFactura As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            If inumFactura = 0 Then
                Return 0
            Else
                sel = "SELECT sum(ImporteComision) FROM ConceptosFacturas where numFactura = " & inumFactura
            End If
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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

    Public Function ListaComisiones(ByVal inumFactura As Integer) As List(Of Double)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            Dim lista As New List(Of Double)
            If inumFactura > 0 Then
                sel = "SELECT Distinct PorcentajeComision FROM ConceptosFacturas where numFactura = " & inumFactura & " Order by PorcentajeComision DESC "

                cmd = New SqlCommand(sel, con)

                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    For Each linea In dt.Rows
                        If linea("PorcentajeComision") Is DBNull.Value OrElse linea("PorcentajeComision") = 0 Then
                        Else
                            lista.Add(linea("PorcentajeComision"))
                        End If
                    Next
                Else
                    con.Close()
                End If
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Comisiones(ByVal inumFactura) As String
        Dim lista As List(Of Double) = ListaComisiones(inumFactura)
        Dim cadena As String = ""
        For Each P As Double In lista
            If cadena <> "" Then cadena = cadena & "; "
            cadena = cadena & FormatNumber(P, 2) & "%"
        Next
        Return cadena
    End Function

    Public Function ReferenciaCliente(ByVal inumFactura As Integer) As String ' Busca la última fecha dentro de la tabla FacturasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT ReferenciaCliente FROM Facturas Where numFactura = " & inumFactura, con)
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

    Public Function idEstado(ByVal inumFactura As Integer) As Integer ' Busca la última fecha dentro de la tabla FacturasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM Facturas Where numFactura = " & inumFactura, con)
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

    Public Function LiquidadaComision(ByVal inumFactura As Integer) As Boolean
        If inumFactura = 0 Then Return 0
        Return idLiquidacion(inumFactura) > 0

    End Function

    Public Function idTipoIVA(ByVal inumFactura As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idTipoIVA FROM Facturas Where numFactura = " & inumFactura, con)
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

    Public Function idLiquidacion(ByVal inumFactura As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idLiquidacion FROM Facturas Where numFactura = " & inumFactura, con)
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

    Public Function TipoIVA(ByVal inumFactura As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT TipoIVA FROM Facturas Where numFactura = " & inumFactura, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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

    Public Function TipoRecargoEq(ByVal inumFactura As Integer) As Double
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT TipoRecargoEq FROM Facturas Where numFactura = " & inumFactura, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
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

    Public Function ExisteNumFactura(ByVal inumFactura As Integer, ByVal iidCliente As Integer) As Integer
        'Nos dice si existe el Factura, devolviendo el idCliente.
        'Si indicamos el idCliente, devuelve el idCliente si existe el Factura.
        Try
            If inumFactura = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidCliente = 0 Then
                    sel = "SELECT idCliente FROM Facturas Where numFactura = " & inumFactura
                Else
                    sel = "SELECT idCliente FROM Facturas Where numFactura = " & inumFactura & " AND idCliente = " & iidCliente
                End If

                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
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
                cmd = New SqlCommand("SELECT COUNT(*) FROM Facturas", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Facturas WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function listaClientes() As List(Of IDComboBox) 'lista de clientes con alguna Factura
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreFiscal, Facturas.idCliente from Facturas left Join Clientes ON Clientes.idCliente = Facturas.idCliente ", con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idCliente") Is DBNull.Value Or linea("NombreFiscal") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(linea("NombreFiscal"), linea("idCliente")))
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

    Public Function listaNum(ByVal Any As Integer) As List(Of Integer) 'lista de números de Facturas existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If Any = 0 Then
                cmd = New SqlCommand("SELECT numFactura FROM Facturas ORDER BY numFactura DESC", con)
            Else
                cmd = New SqlCommand("SELECT numFactura FROM Facturas WHERE YEAR(Fecha) = " & Any & " ORDER BY numFactura DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numFactura"))
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

    Public Function insertar(ByVal dts As DatosFactura) As Integer 'Inserta una nueva Factura y devuelve el nº
        Dim gMaster As New Master()
        dts.gnumFactura = gMaster.incnumFactura(Year(dts.gFecha))
        If dts.gnumFactura = 0 Then
            'MsgBox("Año no válido, consulte al administrador", MsgBoxStyle.OkOnly)
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Facturas (numFactura, ReferenciaCliente, idEstado, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, idMedioPago, idTipoPago, idCuentaBanco, codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia, Descuento, Descuento2, ProntoPago, SolicitadoVia, Notas, Observaciones,TipoRetencion,TipoIVA, TipoRecargoEq,idPersona,PrecioTransporte, idLiquidacion, idCreador, Creacion, idrazonsocial ) "
            sel = sel & " values (@numFactura, @ReferenciaCliente, @idEstado, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto,@idMedioPago,@idTipoPago,@idCuentaBanco,@codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@Descuento,@Descuento2,@ProntoPago,@SolicitadoVia,@Notas,@Observaciones,@TipoRetencion,@TipoIVA, @TipoRecargoEq, @idPersona, @PrecioTransporte,@idLiquidacion, @idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1)  )"
            '
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                    cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
                    cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                    cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                    cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
                    cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                    cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                    cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                    cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                    cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                    cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                    cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                    cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                    cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                    cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                    cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                    cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                    cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                    cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
                    cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                    cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                    cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                    cmd.Parameters.AddWithValue("idLiquidacion", dts.gidLiquidacion)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    'Insertar los vencimientos
                    If Not dts.gVencimientos Is Nothing Then
                        For Each dtsVE As DatosVencimiento In dts.gVencimientos
                            dtsVE.gnumFactura = dts.gnumFactura
                            funcVE.insertar(dtsVE)
                        Next
                    End If
                    Return dts.gnumFactura
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        End If
    End Function

    Public Function actualizar(ByVal dts As DatosFactura) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Facturas set numFactura = @numFactura, ReferenciaCliente = @ReferenciaCliente, idEstado = @idEstado, Fecha = @Fecha, FechaEntrega = @FechaEntrega, "
        sel = sel & " idCliente = @idCliente, idUbicacion = @idUbicacion, idContacto = @idContacto, idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, "
        sel = sel & " idCuentaBanco = @idCuentaBanco, codMoneda = @codMoneda, idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia,"
        sel = sel & " Descuento = @Descuento, Descuento2 = @Descuento2, ProntoPago = @ProntoPago, SolicitadoVia = @SolicitadoVia, Notas = @Notas, Observaciones = @Observaciones, "
        sel = sel & " TipoRetencion = @TipoRetencion, TipoIVA = @TipoIVA, TipoRecargoEq =@TipoRecargoEq, idPersona = @idPersona,PrecioTransporte = @PrecioTransporte, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numFactura = @numFactura"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("ReferenciaCliente", dts.gReferenciaCliente)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("FechaEntrega", dts.gFechaEntrega)
                cmd.Parameters.AddWithValue("idCliente", dts.gidCliente)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                cmd.Parameters.AddWithValue("Descuento", dts.gDescuento)
                cmd.Parameters.AddWithValue("Descuento2", dts.gDescuento2)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("SolicitadoVia", dts.gSolicitadoVia)
                cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    'Reescribir los vencimientos
                    funcVE.borrarFactura(dts.gnumFactura)
                    If Not dts.gVencimientos Is Nothing Then
                        For Each dtsVE As DatosVencimiento In dts.gVencimientos
                            funcVE.insertar(dtsVE)
                        Next
                    End If

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

    Public Function actualizarIVA(ByVal dts As DatosFactura) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Facturas set idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia,"
        sel = sel & " TipoRetencion = @TipoRetencion, TipoIVA = @TipoIVA, TipoRecargoEq =@TipoRecargoEq, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numFactura = @numFactura"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)

                cmd.Parameters.AddWithValue("idTipoIVA", dts.gidTipoIVA)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)

                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                cmd.Parameters.AddWithValue("TipoIVA", dts.gTipoIVAFac)
                cmd.Parameters.AddWithValue("TipoRecargoEq", dts.gTipoRecargoEqFac)

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

    Public Function LiquidarComisiones(ByVal inumFactura As Integer, ByVal idLiquidacion As Integer) As Integer   'Asignar idLiquidacion

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Facturas set idLiquidacion = @idLiquidacion, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numFactura = @numFactura"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", inumFactura)
                cmd.Parameters.AddWithValue("idLiquidacion", idLiquidacion)

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

    Public Function actualizarVencimientos(ByVal dts As DatosFactura) As Boolean   '
        Try
            'Reescribir los vencimientos
            funcVE.borrarFactura(dts.gnumFactura)
            If Not dts.gVencimientos Is Nothing Then
                For Each dtsVE As DatosVencimiento In dts.gVencimientos
                    funcVE.insertar(dtsVE)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


    End Function

    Public Function actualizaEstado(ByVal inumFactura As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Facturas set idEstado = @idEstado where numFactura = @numFactura "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("numFactura", inumFactura)
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

    Public Function actualizaNota(ByVal inumFactura As Integer, ByVal sNota As String) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Facturas set Notas = @Notas where numFactura = @numFactura "

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("Notas", sNota)
                cmd.Parameters.AddWithValue("numFactura", inumFactura)
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

    Public Function actualizaMoneda(ByVal inumFactura As Integer, ByVal scodMoneda As String) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Facturas set codMoneda = @codMoneda where numFactura = @numFactura "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("numFactura", inumFactura)
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

    Public Function borrar(ByVal inumFactura As Integer) As Boolean  ' Borra una cabecera de FacturaProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Facturas where numFactura = " & inumFactura
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function

    Public Function transporteprecio(ByVal inumFactura As Integer) As Double
        Try
            Dim sel As String = "select distinct PE.preciotransporte as precio, PE.notas as notas from conceptosfacturas as CF "
            sel = sel & " left join conceptosalbaranes as CA on CA.numfactura = CF.numfactura"
            sel = sel & " left join conceptospedidos as CP on CP.idconcepto = CA.idconceptopedido"
            sel = sel & " left join pedidos as PE on PE.numpedido = CP.numpedido"
            sel = sel & " where CF.numfactura = " & inumFactura & " and PE.preciotransporte is not null"
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim precio As Decimal = 0
            Dim dr As SqlDataReader
            con.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read()
                    precio = precio + dr(0)
                Loop
            End If
            con.Close()
            sel = "update facturas  set preciotransporte=" & precio.ToString.Replace(",", ".") & " where numfactura=" & inumFactura
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Return precio
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function notasfactura(ByVal inumFactura As Integer) As String
        Try
            Dim rtf As New RichTextBox
            Dim nota As String = ""
            Dim dr As SqlDataReader
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "select distinct PE.preciotransporte as precio, PE.notas as notas from conceptosfacturas as CF"
            sel = sel & " left join conceptosalbaranes as CA on CA.numfactura = CF.numfactura"
            sel = sel & " left join conceptospedidos as CP on CP.idconcepto = CA.idconceptopedido"
            sel = sel & " left join pedidos as PE on PE.numpedido = CP.numpedido"
            sel = sel & " where CF.numfactura = " & inumFactura & " and PE.notas is not null"
            cmd = New SqlCommand(sel, con)
            con.Open()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read()
                    If nota = "" Then
                        nota = dr(1)
                    Else
                        nota = nota + vbLf + dr(1)
                    End If
                Loop
            End If
            sel = "select distinct  notas from facturas "
            sel = sel & " where numfactura = " & inumFactura
            cmd = New SqlCommand(sel, con)
            con.Close()
            Dim rtfPedido As New RichTextBox
            rtfPedido.Text = nota
            Dim rtfFactura As New RichTextBox
            con.Open()
            rtfFactura.Rtf = cmd.ExecuteScalar()
            rtf.Rtf = rtfFactura.Rtf
            con.Close()
            Return rtf.Rtf
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function cambiarEstado(ByVal numfactura As Integer) As Boolean
        Try
            Dim sel As String = "update facturas set idestado=29 where numfactura=" & numfactura
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            MsgBox("ERROR DE CAMBIO DE ESTADO FACTURA")
            Return False
        End Try

    End Function


    Public Function cambiarEstadoParcial(ByVal numfactura As Integer) As Boolean
        Try
            Dim sel As String = "update facturas set idestado=28 where numfactura=" & numfactura
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            MsgBox("ERROR DE CAMBIO DE ESTADO FACTURA")
            Return False
        End Try

    End Function

    Public Function cambiarEstadoPendiente(ByVal numfactura As Integer) As Boolean
        Try
            Dim sel As String = "update facturas set idestado=27 where numfactura=" & numfactura
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            MsgBox("ERROR DE CAMBIO DE ESTADO FACTURA")
            Return False
        End Try

    End Function

    Public Function cambiarEstadoDevuelta(ByVal numfactura As Integer) As Boolean
        Try
            Dim sel As String = "update facturas set idestado=64 where numfactura=" & numfactura
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Return True
        Catch ex As Exception
            MsgBox("ERROR DE CAMBIO DE ESTADO FACTURA")
            Return False
        End Try

    End Function

End Class
