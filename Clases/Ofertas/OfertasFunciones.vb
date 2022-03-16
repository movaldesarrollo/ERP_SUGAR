Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesOfertas


    Inherits conexion
    Dim cmd As SqlCommand

    Private sel0 As String = " Select DOC.*, Clientes.NombreComercial as Cliente,Clientes.Observaciones as ObservacionesCli,subCliente, Localidad + ', ' + Direccion as Direccion, " _
             & " Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, MedioPago, TipoPago,Bancos.Banco,IBAN,Divisa,Simbolo,TipoIVA, Estado, " _
             & " TiposIVA.Nombre as NombreTipoIVA, TipoRecargoEq, TipoRetencion, TiposRetencion.Nombre as NombreTipoRetencion,  C2.Nombre + ' ' + C2.Apellidos as Persona, " _
             & " (select sum(case when (PrecioNetoUnitario is null or PrecioNetoUnitario = 0) then Cantidad * PVPUnitario * (1- (Descuento/100)) else Cantidad * precioNetoUnitario end ) from ConceptosOfertas where numOferta = DOC.numOferta) as Base" _
             & " from Ofertas as DOC " _
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
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto "

    Private sel00 As String = "Select * from V_Ofertas" 'Prueba con VIEW funciona, habría que quitar los alias en las búsquedas


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String, ByVal simplificada As Boolean) As List(Of DatosOferta)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numOferta DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosOferta)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosOferta
                da.Fill(dt)
                Dim subCliente As String
                For Each linea In dt.Rows
                    If linea("numOferta") Is DBNull.Value Then
                    Else
                        dts = New DatosOferta
                        dts.gnumOferta = linea("NumOferta")
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
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
                        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))

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
                        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
                        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
                        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
                        dts.gNombreTipoRetencion = If(linea("NombreTipoRetencion") Is DBNull.Value, "", linea("NombreTipoRetencion"))
                        dts.gObservacionesCli = If(linea("ObservacionesCli") Is DBNull.Value, "", linea("ObservacionesCli"))
                        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
                        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
                        If Not simplificada Then
                            Call DatosCalculados(dts)
                        End If
                        'dts.gRetencion = dts.gBase * dts.gTipoRetencion
                        'dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
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





    Public Function Mostrar1(ByVal inumOferta As Integer) As DatosOferta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE DOC.numOferta = " & inumOferta
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosOferta
            Dim linea As DataRow
            con.Open()
            Dim subCliente As String
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("numOferta") Is DBNull.Value Then
                    Else
                        dts.gnumOferta = linea("NumOferta")
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
                        dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
                        dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
                        dts.gPortes = If(linea("Portes") Is DBNull.Value, "P", linea("Portes"))

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
                        dts.gTipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
                        dts.gNombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
                        dts.gTipoRecargoEq = If(linea("TipoRecargoEq") Is DBNull.Value, 0, linea("TipoRecargoEq"))
                        dts.gTipoRetencion = If(linea("TipoRetencion") Is DBNull.Value, 0, linea("TipoRetencion"))
                        dts.gNombreTipoRetencion = If(linea("NombreTipoRetencion") Is DBNull.Value, "", linea("NombreTipoRetencion"))
                        dts.gObservacionesCli = If(linea("ObservacionesCli") Is DBNull.Value, "", linea("ObservacionesCli"))
                        dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
                        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))

                        Call DatosCalculados(dts)

                        'dts.gRetencion = dts.gBase * dts.gTipoRetencion
                        'dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
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


    Public Function DatosCalculados(ByRef dts As DatosOferta) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, TipoIVA, TipoRecargoEq from ConceptosOfertas as CO left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " where CO.numOferta = " & dts.gnumOferta
            cmd = New SqlCommand(sel, con)
            'Dim lista As New List(Of DatosPedidoProv)
            Dim linea As DataRow
            Dim numSPedido As New List(Of Integer)
            Dim numSProforma As New List(Of Integer)


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


                    'If linea("numPedido") Is DBNull.Value Then
                    'Else
                    '    num = linea("numPedido")
                    '    If num <> 0 Then
                    '        If Not numSPedido.Contains(num) Then numSPedido.Add(num)
                    '    End If

                    'End If
                    'If linea("numProforma") Is DBNull.Value Then
                    'Else
                    '    num = linea("numProforma")
                    '    If num <> 0 Then
                    '        If Not numSProforma.Contains(num) Then numSProforma.Add(linea("numProforma"))
                    '    End If
                    'End If

                    If linea("numPedido") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSPedido, linea("numPedido"))
                    End If

                    If linea("numProforma") Is DBNull.Value Then
                    Else
                        Call NuevoNumeroEnLista(numSProforma, linea("numProforma"))
                    End If

                Next
                dts.gImporteDescuentos = sumaDescuentos
                dts.gImportePP = sumaDescuentosPP
                If dts.gPortes = "P" Or dts.gPortes = "D" Then
                    dts.gBase = Base  'Antes de descuentos generales
                    dts.gTotalIVA = TotalIVA
                    dts.gTotalRE = TotalRE
                Else
                    dts.gBase = Base + dts.gPrecioTransporte
                    dts.gTotalIVA = TotalIVA + dts.gPrecioTransporte * (dts.gTipoIVA / 100)
                    If dts.gRecargoEquivalencia Then
                        dts.gTotalRE = TotalRE + dts.gPrecioTransporte * (dts.gTipoRecargoEq / 100)
                    Else
                        dts.gTotalRE = TotalRE
                    End If
                End If

                dts.gnumSPedido = numSPedido
                dts.gnumSProforma = numSProforma
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


    Private Sub NuevoNumeroEnLista(ByRef lista As List(Of Integer), ByVal nuevoNumero As Integer)
        If nuevoNumero > 0 Then
            Dim existe As Boolean = False
            For Each n As Integer In lista
                If n = nuevoNumero Then existe = True
            Next
            If Not existe Then lista.Add(nuevoNumero)
        End If
    End Sub





    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla PedidosProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM Ofertas", con)
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

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM Ofertas", con)
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
                sel = "SELECT MAX(numOferta) FROM Ofertas "
            Else
                sel = "SELECT MAX(numOferta) FROM Ofertas where idCliente = " & iidCliente
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
            Dim inumOferta As Integer = buscaUltimoDoc(iidCliente)
            If inumOferta = 0 Then
                Return 0
            Else
                sel = "SELECT PrecioTransporte FROM Ofertas where numOferta = " & inumOferta
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


    Public Function ReferenciaCliente(ByVal inumOferta As Integer) As String ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT ReferenciaCliente FROM Ofertas Where numOferta = " & inumOferta, con)
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


    Public Function idEstado(ByVal inumOferta As Integer) As Integer ' Busca la última fecha dentro de la tabla PedidosProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM Ofertas Where numOferta = " & inumOferta, con)
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


    Public Function idTipoIVA(ByVal inumOferta As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idTipoIVA FROM Ofertas Where numOferta = " & inumOferta, con)
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



    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Ofertas", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM Ofertas WHERE  " & busqueda, con)
            End If
            con.Open()
            Return cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function


    Public Function ExisteNumOferta(ByVal inumOferta As Integer, ByVal iidCliente As Integer) As Integer
        'Nos dice si existe el Oferta, devolviendo el idCliente.
        'Si indicamos el idCliente, devuelve el idCliente si existe el Oferta.
        Try
            If inumOferta = 0 Then
                Return False
            Else
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String
                If iidCliente = 0 Then
                    sel = "SELECT idCliente FROM Ofertas Where numOferta = " & inumOferta
                Else
                    sel = "SELECT idCliente FROM Ofertas Where numOferta = " & inumOferta & " AND idCliente = " & iidCliente
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



    Public Function listaClientes() As List(Of IDComboBox) 'lista de clientes con alguna oferta
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand("SELECT DISTINCT NombreComercial, Ofertas.idCliente from Ofertas left Join Clientes ON Clientes.idCliente = Ofertas.idCliente ", con)
            Dim lista As New List(Of IDComboBox)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("idCliente") Is DBNull.Value Or linea("NombreComercial") Is DBNull.Value Then
                    Else
                        lista.Add(New IDComboBox(linea("NombreComercial"), linea("idCliente")))
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





    Public Function listaNum(ByVal Any As Integer) As List(Of Integer) 'lista de números de pedidos existentes
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim lista As New List(Of Integer)
            If Any = 0 Then
                cmd = New SqlCommand("SELECT numOferta FROM Ofertas ORDER BY numOferta DESC", con)
            Else
                cmd = New SqlCommand("SELECT numOferta FROM Ofertas WHERE YEAR(Fecha) = " & Any & " ORDER BY numOferta DESC", con)
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea As DataRow In dt.Rows
                    If linea("numOferta") Is DBNull.Value Then
                    Else
                        lista.Add(linea("numOferta"))
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







    Public Function insertar(ByVal dts As DatosOferta) As Integer 'Inserta una nueva Oferta y devuelve el nº
        Dim gMaster As New Master()
        dts.gnumOferta = gMaster.incnumOferta(Year(dts.gFecha))
        If dts.gnumOferta = 0 Then
            'MsgBox("Año no válido, consulte al administrador", MsgBoxStyle.OkOnly)
            Return -1
        Else
            Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "insert into Ofertas (numOferta, ReferenciaCliente, idEstado, Fecha, FechaEntrega, idCliente, idUbicacion, idContacto, idMedioPago, idTipoPago, idCuentaBanco, codMoneda, idTipoIVA, idTipoRetencion, RecargoEquivalencia, Descuento, Descuento2, ProntoPago, SolicitadoVia, Notas, Observaciones, idPersona,Portes, PrecioTransporte, idCreador, Creacion, idrazonsocial ) "
            sel = sel & " values (@numOferta, @ReferenciaCliente, @idEstado, @Fecha, @FechaEntrega, @idCliente,@idUbicacion,@idContacto,@idMedioPago,@idTipoPago,@idCuentaBanco,@codMoneda,@idTipoIVA,@idTipoRetencion,@RecargoEquivalencia,@Descuento,@Descuento2,@ProntoPago,@SolicitadoVia,@Notas,@Observaciones, @idPersona,@Portes, @PrecioTransporte, @idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1)  )"
            Using con As New SqlConnection(sconexion)
                Try
                    'conectado()
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
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
                    cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                    cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                    cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)

                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Return dts.gnumOferta
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            End Using
        End If

    End Function

    Public Function actualizar(ByVal dts As DatosOferta) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Ofertas set numOferta = @numOferta, ReferenciaCliente = @ReferenciaCliente, idEstado = @idEstado, Fecha = @Fecha, FechaEntrega = @FechaEntrega, idCliente = @idCliente, idUbicacion = @idUbicacion, idContacto = @idContacto, idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, idCuentaBanco = @idCuentaBanco, codMoneda = @codMoneda, "
        sel = sel & " idTipoIVA = @idTipoIVA, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, Descuento = @Descuento, Descuento2 = @Descuento2, ProntoPago = @ProntoPago, SolicitadoVia = @SolicitadoVia, Notas = @Notas, Observaciones = @Observaciones,idPersona = @idPersona,Portes = @Portes, PrecioTransporte = @PrecioTransporte, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE numOferta = @numOferta"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numOferta", dts.gnumOferta)
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
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("Portes", dts.gPortes)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
                'abrir conexion
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



    Public Function actualizaEstado(ByVal inumOferta As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Ofertas set idEstado = @idEstado where numOferta = @numOferta "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("numOferta", inumOferta)
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

    Public Function actualizaMoneda(ByVal inumOferta As Integer, ByVal scodMoneda As String) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Ofertas set codMoneda = @codMoneda where numOferta = @numOferta "

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", scodMoneda)
                cmd.Parameters.AddWithValue("numOferta", inumOferta)
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




    Public Function borrar(ByVal inumOferta As Integer) As Boolean  ' Borra una cabecera de PedidoProv


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from Ofertas where numOferta = " & inumOferta
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
            Finally
                desconectado()
            End Try
        End Using

    End Function






End Class
