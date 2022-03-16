Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesFacturasProv

    Inherits conexion
    Dim cmd As SqlCommand

    Private funcVE As New FuncionesVencimientosProv
    Private funcII As New FuncionesImportesIVAProv
    Private funcTI As New FuncionesTiposIVA

    Dim sel0 As String = " Select DOC.*, Contactos.Nombre + ' ' + Contactos.Apellidos as Contacto, PR.NombreFiscal as Proveedor, PR.Observaciones as ObservacionesProv, Estado, " _
             & " MedioPago, TipoPago,Bancos.Banco,IBAN,Divisa,Simbolo,  Estado, Localidad + ', ' + Direccion as Direccion, " _
             & " TiposRetencion.TipoRetencion as TipoRetencionTabla, TiposRetencion.Nombre as NombreTipoRetencion, C2.Nombre + ' ' + C2.Apellidos as Persona, " _
             & " (select SUM(Importe) From VencimientosProv Where VencimientosProv.idFactura = DOC.idFactura and (Pagado=0 or Devuelto= 1)) as Pendiente, " _
             & " (Select MIN(Vencimiento) from VencimientosProv where idFactura = DOC.idFactura and (Pagado=0 or Devuelto=1)) as PrimerVencimientoNoPagado " _
             & " from FacturasProv as DOC " _
             & " left join Proveedores as PR ON PR.idProveedor = DOC.idProveedor " _
             & " left join Ubicaciones ON Ubicaciones.idUbicacion = DOC.idUbicacion " _
             & " Left Join Contactos ON Contactos.idContacto = DOC.idContacto " _
             & " Left Join Estados ON Estados.idEstado = DOC.idEstado " _
             & " Left Outer Join MediosPago ON MediosPago.idMedioPago = DOC.idMedioPago " _
             & " Left Outer Join TiposPago ON TiposPago.idTipoPago = DOC.idTipoPago " _
             & " Left Outer Join CuentasBancarias as CB ON CB.idCuentaBanco = DOC.idCuentaBanco " _
             & " Left Join Bancos ON Bancos.idBanco = CB.idBanco " _
             & " Left outer join Personal on Personal.idPersona = DOC.idPersona " _
             & " Left join Contactos AS C2 on C2.idContacto = Personal.idContacto " _
             & " Left Join Monedas ON Monedas.codMoneda = DOC.codMoneda " _
             & " Left outer Join TiposRetencion ON TiposRetencion.idTipoRetencion = DOC.idTipoRetencion "


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosFacturaProv)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By numFactura DESC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosFacturaProv)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosFacturaProv
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("numFactura") Is DBNull.Value Then
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



    Private Function CargarLinea(ByVal linea As DataRow) As DatosFacturaProv
        Try

            Dim dts As New DatosFacturaProv
            dts.gidFactura = If(linea("idFactura") Is DBNull.Value, 0, linea("idFactura"))
            dts.gnumFactura = If(linea("numFactura") Is DBNull.Value, "", linea("numFactura"))
            dts.gidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
            dts.gidUbicacion = If(linea("idUbicacion") Is DBNull.Value, 0, linea("idUbicacion"))
            dts.gReferencia = If(linea("Referencia") Is DBNull.Value, "", linea("Referencia"))
            dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
            dts.gFecha = If(linea("Fecha") Is DBNull.Value, Now.Date, linea("Fecha"))
            dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
            dts.gNotas = If(linea("Notas") Is DBNull.Value, "", linea("Notas"))
            dts.gidContacto = If(linea("idContacto") Is DBNull.Value, 0, linea("idContacto"))
            dts.gidMedioPago = If(linea("idMedioPago") Is DBNull.Value, 0, linea("idMedioPago"))
            dts.gidTipoPago = If(linea("idTipoPago") Is DBNull.Value, 0, linea("idTipoPago"))
            dts.gidCuentaBanco = If(linea("idCuentaBanco") Is DBNull.Value, 0, linea("idCuentaBanco"))
            dts.gcodMoneda = If(linea("codMoneda") Is DBNull.Value, "EU", linea("codMoneda"))
            dts.gidTipoRetencion = If(linea("idTipoRetencion") Is DBNull.Value, 0, linea("idTipoRetencion"))
            dts.gRecargoEquivalencia = If(linea("RecargoEquivalencia") Is DBNull.Value, False, linea("RecargoEquivalencia"))
            dts.gProntoPago = If(linea("ProntoPago") Is DBNull.Value, 0, linea("ProntoPago"))
            dts.gTipoRetencionFac = If(linea("TipoRetencion") Is DBNull.Value, "EU", linea("TipoRetencion"))
           
            dts.gPrecioTransporte = If(linea("PrecioTransporte") Is DBNull.Value, 0, linea("PrecioTransporte"))
            dts.gImportePP = If(linea("ImportePP") Is DBNull.Value, 0, linea("ImportePP"))
            dts.gBase = If(linea("Base") Is DBNull.Value, 0, linea("Base"))
            dts.gTotalIVA = If(linea("TotalIVA") Is DBNull.Value, 0, linea("TotalIVA"))
            dts.gTotalRE = If(linea("TotalRE") Is DBNull.Value, 0, linea("TotalRE"))
            dts.gRetencion = If(linea("Retencion") Is DBNull.Value, 0, linea("Retencion"))
            dts.gTotal = If(linea("Total") Is DBNull.Value, 0, linea("Total"))
            dts.gcodFactura = If(linea("codFactura") Is DBNull.Value, "", linea("codFactura"))
            dts.gidPersona = If(linea("idPersona") Is DBNull.Value, 0, linea("idPersona"))
            dts.gidTipoIVATransporte = If(linea("idTipoIVATransporte") Is DBNull.Value, 0, linea("idTipoIVATransporte"))
            dts.gTipoIVATransporte = If(linea("TipoIVATransporte") Is DBNull.Value, 0, linea("TipoIVATransporte"))
            dts.gTipoRecargoEqTransporte = If(linea("TipoRecargoEqTransporte") Is DBNull.Value, 0, linea("TipoRecargoEqTransporte"))
            'Datos de otras tablas
            dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
            dts.gProveedor = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
            dts.gDireccion = If(linea("Direccion") Is DBNull.Value, "", linea("Direccion"))
            dts.gContacto = If(linea("Contacto") Is DBNull.Value, "", linea("Contacto"))
            dts.gObservacionesProv = If(linea("ObservacionesProv") Is DBNull.Value, "", linea("ObservacionesProv"))
            dts.gMedioPago = If(linea("MedioPago") Is DBNull.Value, 0, linea("MedioPago"))
            dts.gTipoPago = If(linea("TipoPago") Is DBNull.Value, 0, linea("TipoPago"))
            dts.gBanco = If(linea("Banco") Is DBNull.Value, "", linea("Banco"))
            dts.gIBAN = If(linea("IBAN") Is DBNull.Value, "", linea("IBAN"))
            dts.gDivisa = If(linea("Divisa") Is DBNull.Value, 0, linea("Divisa"))
            dts.gSimbolo = If(linea("Simbolo") Is DBNull.Value, 0, linea("Simbolo"))
            dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
            dts.gTipoRetencion = If(linea("TipoRetencionTabla") Is DBNull.Value, 0, linea("TipoRetencionTabla"))
            dts.gNombreTipoRetencion = If(linea("NombreTipoRetencion") Is DBNull.Value, "", linea("NombreTipoRetencion"))
            dts.gPendiente = If(linea("Pendiente") Is DBNull.Value, 0, linea("Pendiente"))
            dts.gPrimerVencimientoNoPagado = If(linea("PrimerVencimientoNoPagado") Is DBNull.Value, CDate("1-1-1900"), linea("PrimerVencimientoNoPagado"))
            dts.gVencimientos = funcVE.Mostrar(dts.gidFactura)

            Call DatosCalculados(dts)


            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExisteFactura(ByVal numFactura As String, ByVal iidProveedor As Integer, ByVal iidFactura As Integer) As Boolean
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            numFactura = UCase(Trim(numFactura))
            Dim sel As String = "SELECT count(idFactura) FROM FacturasProv Where idProveedor = " & iidProveedor & " AND numFactura = '" & numFactura & "' AND idFactura <> " & iidFactura
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

    Public Function ExistecodFactura(ByVal codFactura As String, ByVal iidFactura As Integer) As Boolean
        Try
            If codFactura = "" Then Return False
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            codFactura = UCase(Trim(codFactura))
            Dim sel As String
            sel = "SELECT count(idFactura) FROM FacturasProv Where  codFactura = '" & codFactura & "' AND idFactura <> " & iidFactura
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

    Public Function DatosCalculados(ByRef dts As DatosFacturaProv) As Boolean
        'Incorpora los datos globales que se extraen de los conceptos. Pasamos los datos en el mismo dts por Referencia.
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " Select CO.*, numAlbaran, C1.idAlbaran,TiposIVA.Nombre as NombreTipoIVA  from ConceptosFacturasProv as CO  "
            sel = sel & " left outer join ConceptosAlbaranesProv as C1 ON C1.idConcepto= CO.idConceptoAlbaranProv "
            sel = sel & " left join AlbaranesProv ON AlbaranesProv.idAlbaran = C1.idAlbaran "
            sel = sel & " left join TiposIVA ON TiposIVA.idTipoIVA = CO.idTipoIVA "
            sel = sel & " where CO.idFactura = " & dts.gidFactura
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            Dim Albaranes As New List(Of IDComboBox)

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
            Dim NombreTipoIVA As String = ""
            Dim idTipoIVA As Integer = 0
            Dim subTotalIVA As Double = 0
            Dim subTotalRE As Double = 0
            Dim listaImportesIVA As New List(Of DatosImportesIVAProv)
            Dim dtsI As DatosImportesIVAProv
            Dim indice As Integer
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


                    If linea("numAlbaran") Is DBNull.Value OrElse linea("idAlbaran") Is DBNull.Value Then
                    Else
                        If Not Contiene(Albaranes, New IDComboBox(linea("numAlbaran"), linea("idAlbaran"))) Then
                            Albaranes.Add(New IDComboBox(linea("numAlbaran"), linea("idAlbaran")))
                        End If
                    End If

                    subTotalPP = subTotal * (1 - (dts.gProntoPago / 100))
                    Base = Base + subTotalPP
                    idTipoIVA = If(linea("idTipoIVA") Is DBNull.Value, 0, CDbl(linea("idTipoIVA")))
                    TipoIVA = If(linea("TipoIVA") Is DBNull.Value, 0, CDbl(linea("TipoIVA")))
                    TipoRE = If(linea("TipoRecargoEq") Is DBNull.Value, 0, CDbl(linea("TipoRecargoEq")))
                    NombreTipoIVA = If(linea("NombreTipoIVA") Is DBNull.Value, "", linea("NombreTipoIVA"))
                    subTotalIVA = subTotalPP * (TipoIVA / 100)
                    TotalIVA = TotalIVA + subTotalIVA 'El IVA se calcula sobre el importe neto con todos los descuentos
                    If dts.gRecargoEquivalencia Then
                        subTotalRE = subTotalPP * (TipoRE / 100)
                        TotalRE = TotalRE + subTotalRE
                    End If
                    'Recalcular los IVA
                    indice = ContieneIVA(listaImportesIVA, idTipoIVA)

                    If indice = -1 Then
                        dtsI = New DatosImportesIVAProv
                        dtsI.gidConcepto = 0
                        dtsI.gidFactura = dts.gidFactura
                        dtsI.gidTipoIVA = idTipoIVA
                        dtsI.gcodMoneda = dts.gcodMoneda
                        dtsI.gSimbolo = dts.gSimbolo
                        dtsI.gTipoIVA = TipoIVA
                        dtsI.gNombreIVA = NombreTipoIVA
                        If dts.gRecargoEquivalencia Then
                            dtsI.gTipoRecargoEq = TipoRE
                            dtsI.gTotalRE = subTotalRE
                        Else
                            dtsI.gTipoRecargoEq = 0
                            dtsI.gTotalRE = 0
                        End If
                        dtsI.gBase = subTotalPP
                        dtsI.gTotalIVA = subTotalIVA
                        listaImportesIVA.Add(dtsI)
                    Else
                        If dts.gRecargoEquivalencia Then
                            listaImportesIVA(indice).gTotalRE = listaImportesIVA(indice).gTotalRE + subTotalRE
                        End If
                        listaImportesIVA(indice).gBase = listaImportesIVA(indice).gBase + subTotalPP
                        listaImportesIVA(indice).gTotalIVA = listaImportesIVA(indice).gTotalIVA + subTotalIVA

                    End If

                    sumaDescuentosPP = sumaDescuentosPP + subTotal * (dts.gProntoPago / 100)

                Next
                'dts.gImporteDescuentos = sumaDescuentos
                indice = ContieneIVA(listaImportesIVA, dts.gidTipoIVATransporte)
                subTotalRE = dts.gPrecioTransporte * (dts.gTipoRecargoEqTransporte / 100)
                subTotalIVA = dts.gPrecioTransporte * (dts.gTipoIVATransporte / 100)
                If indice = -1 Then
                    dtsI = New DatosImportesIVAProv
                    dtsI.gidConcepto = 0
                    dtsI.gidFactura = dts.gidFactura
                    dtsI.gidTipoIVA = dts.gidTipoIVATransporte
                    dtsI.gcodMoneda = dts.gcodMoneda
                    dtsI.gSimbolo = dts.gSimbolo
                    dtsI.gTipoIVA = dts.gTipoIVATransporte
                    dtsI.gNombreIVA = funcTI.Nombre(dts.gidTipoIVATransporte)
                    If dts.gRecargoEquivalencia Then
                        dtsI.gTipoRecargoEq = dts.gTipoRecargoEqTransporte
                        dtsI.gTotalRE = subTotalRE
                    Else
                        dtsI.gTipoRecargoEq = 0
                        dtsI.gTotalRE = 0
                    End If
                    dtsI.gBase = dts.gPrecioTransporte
                    dtsI.gTotalIVA = subTotalIVA
                    listaImportesIVA.Add(dtsI)
                Else
                    If dts.gRecargoEquivalencia Then
                        listaImportesIVA(indice).gTotalRE = listaImportesIVA(indice).gTotalRE + subTotalRE
                    End If
                    listaImportesIVA(indice).gBase = listaImportesIVA(indice).gBase + dts.gPrecioTransporte
                    listaImportesIVA(indice).gTotalIVA = listaImportesIVA(indice).gTotalIVA + subTotalIVA

                End If



                dts.gImportePP = sumaDescuentosPP

                'Dim funcFA As New funcionesFacturacion
                'Dim dtsFA As datosfacturacion = funcFA.mostrarProv(dts.gidProveedor)
                dts.gBase = Base + dts.gPrecioTransporte
                dts.gTotalIVA = TotalIVA + dts.gPrecioTransporte * (dts.gTipoIVATransporte / 100)

                If dts.gRecargoEquivalencia Then
                    dts.gTotalRE = TotalRE + dts.gPrecioTransporte * (dts.gTipoRecargoEqTransporte / 100)
                Else
                    dts.gTotalRE = TotalRE
                End If

                dts.gAlbaranes = Albaranes

                dts.gRetencion = dts.gBase * (dts.gTipoRetencion / 100)
                dts.gTotal = dts.gBase + dts.gTotalIVA + dts.gTotalRE - dts.gRetencion
                dts.gImportesIVA = listaImportesIVA

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

    Private Function ContieneIVA(ByVal lista As List(Of DatosImportesIVAProv), ByVal iidTipoIVA As Integer) As Integer
        If lista Is Nothing OrElse lista.Count = 0 Then Return -1
        Dim i As Integer = 0
        For i = 0 To lista.Count - 1
            If lista(i).gidTipoIVA = iidTipoIVA Then Return i
        Next
        Return -1
    End Function



    Public Function Mostrar1(ByVal idFactura As Integer) As DatosFacturaProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE DOC.idFactura = " & idFactura
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosFacturaProv
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idFactura") Is DBNull.Value Then
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







    Public Function buscaPrimerDia() As Date  ' Busca la primera fecha dentro de la tabla FacturasProv

        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MIN(Fecha) FROM FacturasProv", con)
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

    Public Function buscaUltimoDia() As Date ' Busca la última fecha dentro de la tabla FacturasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim fecha As Date
            cmd = New SqlCommand("SELECT MAX(Fecha) FROM FacturasProv", con)
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





    Public Function Referencia(ByVal iidFactura As Integer) As String ' Busca la última fecha dentro de la tabla FacturasProv
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT Referencia FROM FacturasProv Where idFactura = " & iidFactura, con)
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

    Public Function idEstado(ByVal iidFactura As Integer) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idEstado FROM FacturasProv Where idFactura = " & iidFactura, con)
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

    Public Function idFactura(ByVal numFactura As String, ByVal iidProveedor As Integer) As String
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT idFactura FROM FacturasProv Prov Where numFactura = '" & numFactura & "' AND idProveedor = " & iidProveedor, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CStr(o)
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
                cmd = New SqlCommand("SELECT COUNT(*) FROM FacturasProv", con)
            Else
                cmd = New SqlCommand(" SELECT COUNT(*) FROM FacturasProv WHERE  " & busqueda, con)
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
            cmd = New SqlCommand("SELECT DISTINCT NombreComercial, AP.idProveedor from FacturasProv as AP left Join Proveedores ON Proveedores.idProveedor = AP.idProveedor ", con)
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




    Public Function insertar(ByVal dts As DatosFacturaProv) As Integer

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into FacturasProv (numFactura, idProveedor, idUbicacion, Referencia, idEstado, Fecha, idContacto, Observaciones,Notas, idMedioPago, idTipoPago, idCuentaBanco, codMoneda, idTipoRetencion, "
        sel = sel & "  RecargoEquivalencia, ProntoPago, TipoRetencion, PrecioTransporte, ImportePP, Base, TotalIVA, TotalRE, Retencion, Total, codFactura, idPersona, idTipoIVATransporte, TipoIVATransporte, TipoRecargoEqTransporte, idCreador, Creacion, idrazonsocial ) "
        sel = sel & " values           (@numFactura,@idProveedor,@idUbicacion,@Referencia,@idEstado,@Fecha,@idContacto,@Observaciones,@Notas,@idMedioPago,@idTipoPago,@idCuentaBanco,@codMoneda,@idTipoRetencion, "
        sel = sel & " @RecargoEquivalencia,@ProntoPago,@TipoRetencion,@PrecioTransporte,@ImportePP,@Base,@TotalIVA,@TotalRE,@Retencion,@Total, @codFactura,@idPersona,@idTipoIVATransporte,@TipoIVATransporte,@TipoRecargoEqTransporte, @idCreador,@Creacion, (select idrazonsocial from razonsocial where activa= 1)  ) select @@identity"
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("Referencia", dts.gReferencia)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                cmd.Parameters.AddWithValue("ImportePP", dts.gImportePP)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("TotalIVA", dts.gTotalIVA)
                cmd.Parameters.AddWithValue("TotalRE", dts.gTotalRE)
                cmd.Parameters.AddWithValue("Retencion", dts.gRetencion)
                cmd.Parameters.AddWithValue("Total", dts.gTotal)
                cmd.Parameters.AddWithValue("codFactura", dts.gcodFactura)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("idTipoIVATransporte", dts.gidTipoIVATransporte)
                cmd.Parameters.AddWithValue("TipoIVATransporte", dts.gTipoIVATransporte)
                cmd.Parameters.AddWithValue("TipoRecargoEqTransporte", dts.gTipoRecargoEqTransporte)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)

                con.Open()
                dts.gidFactura = cmd.ExecuteScalar()
                con.Close()
                Return dts.gidFactura
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using

    End Function

    Public Function actualizar(ByVal dts As DatosFacturaProv) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update FacturasProv set numFactura = @numFactura, idProveedor = @idProveedor, idUbicacion = @idUbicacion, Referencia = @Referencia, idEstado = @idEstado, Fecha = @Fecha, "
        sel = sel & "idContacto = @idContacto, Observaciones = @Observaciones,Notas = @Notas, idMedioPago = @idMedioPago, idTipoPago = @idTipoPago, idCuentaBanco = @idCuentaBanco, "
        sel = sel & " codMoneda = @codMoneda, idTipoRetencion = @idTipoRetencion, RecargoEquivalencia = @RecargoEquivalencia, ProntoPago = @ProntoPago,"
        sel = sel & " TipoRetencion = @TipoRetencion, PrecioTransporte = @PrecioTransporte, ImportePP = @ImportePP, Base = @Base, TotalIVA = @TotalIVA, TotalRE = @TotalRE, "
        sel = sel & " Retencion = @Retencion, Total = @Total,codFactura = @codFactura, idPersona = @idPersona, idTipoIVATransporte = @idTipoIVATransporte,  "
        sel = sel & " TipoIVATransporte = @TipoIVATransporte, TipoRecargoEqTransporte= @TipoRecargoEqTransporte, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE idFactura = @idFactura"

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
                cmd.Parameters.AddWithValue("numFactura", dts.gnumFactura)
                cmd.Parameters.AddWithValue("idProveedor", dts.gidProveedor)
                cmd.Parameters.AddWithValue("idUbicacion", dts.gidUbicacion)
                cmd.Parameters.AddWithValue("Referencia", dts.gReferencia)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("Fecha", dts.gFecha)
                cmd.Parameters.AddWithValue("idContacto", dts.gidContacto)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Notas", dts.gNotas)
                cmd.Parameters.AddWithValue("idMedioPago", dts.gidMedioPago)
                cmd.Parameters.AddWithValue("idTipoPago", dts.gidTipoPago)
                cmd.Parameters.AddWithValue("idCuentaBanco", dts.gidCuentaBanco)
                cmd.Parameters.AddWithValue("codMoneda", dts.gcodMoneda)
                cmd.Parameters.AddWithValue("idTipoRetencion", dts.gidTipoRetencion)
                cmd.Parameters.AddWithValue("RecargoEquivalencia", dts.gRecargoEquivalencia)
                cmd.Parameters.AddWithValue("ProntoPago", dts.gProntoPago)
                cmd.Parameters.AddWithValue("TipoRetencion", dts.gTipoRetencionFac)
                cmd.Parameters.AddWithValue("PrecioTransporte", dts.gPrecioTransporte)
                cmd.Parameters.AddWithValue("ImportePP", dts.gImportePP)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("TotalIVA", dts.gTotalIVA)
                cmd.Parameters.AddWithValue("TotalRE", dts.gTotalRE)
                cmd.Parameters.AddWithValue("Retencion", dts.gRetencion)
                cmd.Parameters.AddWithValue("Total", dts.gTotal)
                cmd.Parameters.AddWithValue("codFactura", dts.gcodFactura)
                cmd.Parameters.AddWithValue("idPersona", dts.gidPersona)
                cmd.Parameters.AddWithValue("idTipoIVATransporte", dts.gidTipoIVATransporte)
                cmd.Parameters.AddWithValue("TipoIVATransporte", dts.gTipoIVATransporte)
                cmd.Parameters.AddWithValue("TipoRecargoEqTransporte", dts.gTipoRecargoEqTransporte)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)

                con.Open()
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    'Reescribir los vencimientos
                    funcVE.borrarFactura(dts.gidFactura)
                    If Not dts.gVencimientos Is Nothing Then
                        For Each dtsVE As DatosVencimientoProv In dts.gVencimientos
                            funcVE.insertar(dtsVE)
                        Next
                    End If

                    Return True
                Else
                    Return False
                End If

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


    Public Function actualizarTotales(ByVal dts As DatosFacturaProv) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update FacturasProv set ImportePP = @ImportePP, Base = @Base, TotalIVA = @TotalIVA, TotalRE = @TotalRE, "
        sel = sel & " Retencion = @Retencion, Total = @Total, idModifica = @idModifica, Modificacion = @Modificacion  "
        sel = sel & " WHERE idFactura = @idFactura  "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idFactura", dts.gidFactura)
               
                cmd.Parameters.AddWithValue("ImportePP", dts.gImportePP)
                cmd.Parameters.AddWithValue("Base", dts.gBase)
                cmd.Parameters.AddWithValue("TotalIVA", dts.gTotalIVA)
                cmd.Parameters.AddWithValue("TotalRE", dts.gTotalRE)
                cmd.Parameters.AddWithValue("Retencion", dts.gRetencion)
                cmd.Parameters.AddWithValue("Total", dts.gTotal)
               
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


    Public Function actualizarVencimientos(ByVal dts As DatosFacturaProv) As Boolean   '
        Try
            'Reescribir los vencimientos
            funcVE.borrarFactura(dts.gidFactura)
            If Not dts.gVencimientos Is Nothing Then
                For Each dtsVE As DatosVencimientoProv In dts.gVencimientos
                    funcVE.insertar(dtsVE)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


    End Function

    Public Function actualizaEstado(ByVal iidFactura As Integer, ByVal iidEstado As Integer) As Boolean   'Actualiza el estado
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update FacturasProv set idEstado = @idEstado where idFactura = @idFactura "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                cmd.Parameters.AddWithValue("idFactura", iidFactura)
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


    Public Function actualizaMoneda(ByVal iidFactura As Integer, ByVal codMoneda As String) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update FacturasProv set codMoneda = @codMoneda where idFactura = @idFactura "

        Using con As New SqlConnection(sconexion)
            Try

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("codMoneda", codMoneda)
                cmd.Parameters.AddWithValue("idFactura", iidFactura)
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

    Public Function borrar(ByVal iidFactura As Integer) As Boolean  ' Borra una cabecera de AlbaranProv

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from FacturasProv where idFactura = " & iidFactura
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
