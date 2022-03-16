Imports System.IO
Imports System.Text.RegularExpressions

Public Class ImportarAlbaranesProv

    Private funcPP As New FuncionesPedidosProv
    Private funcAP As New FuncionesAlbaranesProv
    Private funcCA As New FuncionesConceptosAlbaranesProv
    Private funcES As New FuncionesEstados
    Private funcCP As New FuncionesConceptosPedidosProv
    Private funcFP As New FuncionesFacturasProv
    Private funcVT As New FuncionesVencimientosProv
    Private funcFA As New funcionesFacturacion
    Private funcII As New FuncionesImportesIVAProv
    Private funcU As New funcionesUbicaciones
    Private funcCF As New FuncionesConceptosFacturasProv
    Private funcTI As New FuncionesTiposIVA
    Private funcMP As New funcionesMediosPago
    Private funcCB As New FuncionesCuentasBancarias
    Dim estadoStock As DatosEstado
    Dim estadoStockParcial As DatosEstado
    Dim estadoAlbaranRecibido As DatosEstado
    Dim estadoAlbaranFacturado As DatosEstado
    Dim estadoFacturaPendiente As DatosEstado
    Dim estadoFacturaCobrada As DatosEstado
    Dim EstadoCPEspera As DatosEstado
    Dim EstadoCARecibido As DatosEstado
    Dim EstadoCATraspasado As DatosEstado
    Dim EstadoCFEspera As DatosEstado

    Private Sub ImportarAlbaranesProv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        estadoStock = funcES.EstadoPedidoProv("STOCK")
        estadoStockParcial = funcES.EstadoPedidoProv("STOCK PARCIAL")
        estadoAlbaranRecibido = funcES.EstadoAlbaranProv("RECIBIDO")
        estadoAlbaranFacturado = funcES.EstadoTraspasado("ALBARANPROV")
        estadoFacturaCobrada = funcES.EstadoCompleto("FACTURAPROV")
        estadoFacturaPendiente = funcES.EstadoEspera("FACTURAPROV")
        EstadoCPEspera = funcES.EstadoEspera("C.PEDIDOPROV")
        EstadoCARecibido = funcES.EstadoEntregado("C.ALBARANPROV")
        EstadoCATraspasado = funcES.EstadoTraspasado("C.ALBARANPROV")
        EstadoCFEspera = funcES.EstadoEspera("C.FACTURAPROV")
    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click


        Dim lista As List(Of DatosPedidoProv) = funcPP.Mostrar()

        For Each dts As DatosPedidoProv In lista
            If dts.gidEstado = estadoStock.gidEstado Or dts.gidEstado = estadoStockParcial.gidEstado Then
                Observaciones.Text = importarPedido(dts) & vbCrLf & Observaciones.Text
                Application.DoEvents()
            End If
        Next
        Observaciones.Text = "IMPORTACIÓN FINALIZADA" & vbCrLf & vbCrLf & Observaciones.Text
        Application.DoEvents()

    End Sub


    Private Function importarPedido(ByVal dts As DatosPedidoProv) As String
        Dim encuentro As Match
        Dim nAlbaran As String = ""
        Dim nFechaAlbaran As String = ""
        Dim nFactura As String = ""
        Dim nVencimiento As String = ""
        Dim FechaVencimiento As Date

        If dts.gObservaciones.Contains("ALBARAN:") Then
            encuentro = Regex.Match(dts.gObservaciones, "ALBARAN:?\s*(?<numAlbaran>[.:a-zA-Z0-9\s\/\-]+)\s*\(")

            If encuentro.Success Then
            Else
                encuentro = Regex.Match(dts.gObservaciones, "ALBARAN:?\s*(?<numAlbaran>[.:a-zA-Z0-9\s\/\-]+)\s+FACTURA")
            End If
            If encuentro.Success Then nAlbaran = encuentro.Groups("numAlbaran").Value
            encuentro = Regex.Match(dts.gObservaciones, "ALBARAN:\s+[a-zA-Z0-9\/\-]+\s+\((?<fechaAlbaran>\d\d?[\/\-]\d\d?)")
            If encuentro.Success Then nFechaAlbaran = encuentro.Groups("fechaAlbaran").Value

            encuentro = Regex.Match(dts.gObservaciones, "FACTURA\s?:(?<numFactura>[a-zA-Z0-9\/\-\.\s]+)\s+VTO")
            If encuentro.Success Then
            Else
                encuentro = Regex.Match(dts.gObservaciones, "FACTURA\s?:(?<numFactura>[a-zA-Z0-9\/\-\.\s]+)")
            End If

         
            If encuentro.Success Then nFactura = encuentro.Groups("numFactura").Value
            If nFactura.Contains("VTO") Then nFactura = ""

            nFactura = Microsoft.VisualBasic.Left(nFactura, 30)
            nFactura = Trim(nFactura)
            encuentro = Regex.Match(nFactura, "[0-9]+")
            If encuentro.Success Then
            Else
                nFactura = ""
            End If
            'If nFactura.Length < 3 Then nFactura = ""

            encuentro = Regex.Match(dts.gObservaciones, "VTO:?\s*(?<Vencimiento>[0-9\/\-]+)")
            If encuentro.Success Then nVencimiento = encuentro.Groups("Vencimiento").Value
        End If
        Dim dtsAP As New DatosAlbaranProv
        Dim listaCP As List(Of DatosConceptoPedidoProv)
        nAlbaran = Trim(nAlbaran)
        If Len(nAlbaran) <= 1 Then nAlbaran = ""
        If nAlbaran = "" And nFactura <> "" Then nAlbaran = "NO INDICADO"
        If nAlbaran <> "" Then
            nAlbaran = UCase(Microsoft.VisualBasic.Left(nAlbaran, 49))

            dtsAP.gnumAlbaran = nAlbaran
            dtsAP.gidUbicacion = funcU.mostrar1ProvR(dts.gidProveedor).gidUbicacion
            dtsAP.gidProveedor = dts.gidProveedor
            dtsAP.gReferencia = "PEDIDO " & dts.gnumPedido
            dtsAP.gObservaciones = dts.gObservaciones
            dtsAP.gidContacto = 0
            dtsAP.gidFactura = 0
            dtsAP.gcodMoneda = "EU"
            If nFechaAlbaran.Contains("-") Then nFechaAlbaran = nFechaAlbaran & "-2015"
            If nFechaAlbaran.Contains("/") Then nFechaAlbaran = nFechaAlbaran & "/2015"
            If IsDate(nFechaAlbaran) Then
                dtsAP.gFecha = CDate(nFechaAlbaran)
            Else
                dtsAP.gFecha = funcCP.PrimeraFechaRecibido(dts.gnumPedido)
            End If
            If nFactura = "" Then
                dtsAP.gidEstado = estadoAlbaranRecibido.gidEstado
            Else
                dtsAP.gidEstado = estadoAlbaranFacturado.gidEstado
            End If
            dtsAP.gSolicitadoVia = ""
            dtsAP.gidContacto = 0
            dts.gNotas = ""
            Dim dtsFA As datosfacturacion = funcFA.mostrarProv(dts.gidProveedor)
            dtsAP.gidTipoValorado = dtsFA.gidTipoValorado
            dtsAP.gidTipoRetencion = dtsFA.gidTipoRetencion
            dtsAP.gRecargoEquivalencia = dtsFA.gRecargoEquivalencia
            dtsAP.gProntoPago = 0
            dtsAP.gcodMoneda = dtsFA.gcodMoneda
            dtsAP.gidPersona = 0
            dtsAP.gPrecioTransporte = dts.gPrecioTransporte
            dtsAP.gPortes = dts.gPortes
            dtsAP.gBultos = 0
            dtsAP.gidTransporte = dts.gidTransporte
            dtsAP.gTransporte = dts.gTransporte

            dtsAP.gidAlbaran = funcAP.insertar(dtsAP)
            Dim dtsCA As DatosConceptoAlbaranProv
            listaCP = funcCP.mostrar(dts.gnumPedido)
            Dim n = 1
            For Each dtsCP As DatosConceptoPedidoProv In listaCP
                dtsCA = New DatosConceptoAlbaranProv
                dtsCA.gidAlbaran = dtsAP.gidAlbaran
                dtsCA.gCantidad = dtsCP.gCantidadRecibida
                dtsCA.gidConceptoPedidoProv = dtsCP.gidConcepto
                dtsCA.gDescuento = dtsCP.gDescuento
                dtsCA.gPrecioNetoUnitario = dtsCP.gPrecioNetoUnitario
                dtsCA.gcodArticuloProv = dtsCP.gcodArticuloProv
                dtsCA.gArticuloProv = dtsCP.gArticulo
                dtsCA.gidArticulo = dtsCP.gidArticulo
                dtsCA.gPVPUnitario = dtsCP.gPVPUnitario
                dtsCA.gidTipoIVA = dtsCP.gidTipoIVA
                dtsCA.gOrden = n
                dtsCA.gObservaciones = ""
                n = n + 1
                If nFactura = "" Then
                    dtsCA.gidEstado = EstadoCARecibido.gidEstado
                Else
                    dtsCA.gidEstado = EstadoCATraspasado.gidEstado
                End If

                If dtsCP.gCantidadRecibida <> 0 Then funcCA.insertar(dtsCA)
                'If dtsCP.gidEstado <> EstadoCPEspera.gidEstado Then
                '    dtsCP.gidAlbaran = dtsAP.gidAlbaran
                '    funcCP.actualizarRecepcion(dtsCP)
                'End If
            Next

        End If

        If nFactura <> "" Then
            nFactura = UCase(nFactura)
            funcPP.DatosCalculados(dts)
            Dim dtsFP As New DatosFacturaProv
            Dim dtsII As New DatosImportesIVAProv
            dtsFP.gidFactura = funcFP.idFactura(nFactura, dts.gidProveedor)
            If dtsFP.gidFactura = 0 Then
                dtsFP.gnumFactura = nFactura
                dtsFP.gidProveedor = dts.gidProveedor
                dtsFP.gidUbicacion = funcU.mostrar1ProvF(dts.gidProveedor).gidUbicacion
                Dim dtsFA As datosfacturacion = funcFA.mostrarProv(dts.gidProveedor)
                If IsDate(nFechaAlbaran) Then
                    dtsFP.gFecha = CDate(nFechaAlbaran)
                Else
                    dtsFP.gFecha = funcCP.PrimeraFechaRecibido(dts.gnumPedido)
                End If
                ' If nAlbaran = "" Then
                'dtsFP.gReferencia = "SIN ALBARAN"
                'Else
                dtsFP.gReferencia = "ALBARAN " & nAlbaran
                'End If
                dtsFP.gReferencia = Microsoft.VisualBasic.Left(dtsFP.gReferencia, 50)
                dtsFP.gObservaciones = dts.gObservaciones
                dtsFP.gidContacto = 0
                dtsFP.gcodFactura = ""
                dtsFP.gidMedioPago = dtsFA.gidMedioPago
                dtsFP.gidTipoPago = dtsFA.gidTipoPago
                If funcMP.RequiereBanco(dtsFA.gidMedioPago) Then
                    Dim listaC As List(Of DatosCuentaBancaria) = funcCB.Mostrar(dtsFA.gidFacturacion, True)
                    If listaC Is Nothing OrElse listaC.Count = 0 Then
                        dtsFP.gidCuentaBanco = 0
                    Else
                        dtsFP.gidCuentaBanco = listaC(0).gidCuentaBanco
                    End If
                Else
                    dtsFP.gidCuentaBanco = 0
                End If

                dtsFP.gcodMoneda = dts.gcodMoneda

                dtsFP.gidTipoRetencion = dts.gidTipoRetencion
                dtsFP.gRecargoEquivalencia = dtsFA.gRecargoEquivalencia
                dtsFP.gProntoPago = dtsFA.gProntoPago
                dtsFP.gTipoRetencionFac = dts.gTipoRetencionFac
                dtsFP.gidTipoIVATransporte = dtsFA.gidTipoIVA
                dtsFP.gTipoIVATransporte = dtsFA.gTipoIVA
                dtsFP.gTipoRecargoEqTransporte = dtsFA.gTipoRecargoEq
                dtsFP.gTipoRetencionFac = dts.gTipoRetencionFac
                If IsDate(nVencimiento) Then
                    FechaVencimiento = CDate(nVencimiento)
                    'If FechaVencimiento < Now.Date Then dtsFP.gidEstado = estadoFacturaCobrada.gidEstado
                End If
                If dts.gPagado Then
                    dtsFP.gidEstado = estadoFacturaCobrada.gidEstado
                Else
                    dtsFP.gidEstado = estadoFacturaPendiente.gidEstado
                End If
                dtsFP.gPrecioTransporte = dts.gPrecioTransporte
                dtsFP.gImportePP = dts.gImporteDescuentoGeneral
                dtsFP.gBase = dts.gBase
                dtsFP.gTotalIVA = dts.gTotalIVA
                dtsFP.gTotalRE = 0
                dtsFP.gRetencion = 0
                dtsFP.gTotal = dts.gTotal
                dtsFP.gidFactura = funcFP.insertar(dtsFP)

                Dim dtsV As New DatosVencimientoProv
                dtsV.gidFactura = dtsFP.gidFactura
                dtsV.gImporte = dtsFP.gTotal
                If dtsFP.gidEstado = estadoFacturaCobrada.gidEstado Then
                    dtsV.gPagado = True
                Else
                    dtsV.gPagado = False
                End If
                dtsV.gRemesado = False
                dtsV.gDevuelto = False
                If IsDate(nVencimiento) Then
                    dtsV.gVencimiento = FechaVencimiento
                Else
                    dtsV.gVencimiento = dtsFP.gFecha
                End If
                funcVT.insertar(dtsV)
                dtsII.gidFactura = dtsFP.gidFactura
                dtsII.gidTipoIVA = dts.gidTipoIVA
                dtsII.gTipoIVA = dtsFA.gTipoIVA
                If dtsFA.gRecargoEquivalencia Then
                    dtsII.gTipoRecargoEq = dtsFA.gTipoRecargoEq
                Else
                    dtsII.gTipoRecargoEq = 0
                End If
                dtsII.gBase = dtsFP.gBase
                dtsII.gTotalIVA = dtsFP.gTotalIVA
                dtsII.gTotalRE = dtsFP.gTotalRE
                dtsII.gidConcepto = funcII.insertar(dtsII)

            Else

                dtsFP = funcFP.Mostrar1(dtsFP.gidFactura)
                dtsFP.gReferencia = Replace(dtsFP.gReferencia, "ALBARAN ", "ALB.")
                dtsFP.gReferencia = dtsFP.gReferencia & ", " & nAlbaran
                If dtsFP.gReferencia.Length > 50 Then
                    dtsFP.gReferencia = Microsoft.VisualBasic.Left(dtsFP.gReferencia, 46) & "..."
                End If
                dtsFP.gPrecioTransporte = dtsFP.gPrecioTransporte + dts.gPrecioTransporte
                dtsFP.gImportePP = dtsFP.gImportePP + dts.gImporteDescuentoGeneral
                dtsFP.gBase = dtsFP.gBase * dts.gBase
                dtsFP.gTotalIVA = dtsFP.gTotalIVA + dts.gTotalIVA
                dtsFP.gTotalRE = 0
                dtsFP.gRetencion = 0
                dtsFP.gTotal = dtsFP.gTotal + dts.gTotal
                funcFP.actualizar(dtsFP)

                Dim listaV As List(Of DatosVencimientoProv) = funcVT.Mostrar(dtsFP.gidFactura)
                If listaV.Count > 0 Then
                    listaV(0).gImporte = dtsFP.gTotal
                    funcVT.actualizar(listaV(0))
                End If

                Dim listaI As List(Of DatosImportesIVAProv) = funcII.Mostrar(dtsFP.gidFactura)
                If listaI.Count > 0 Then
                    listaI(0).gBase = dtsFP.gBase
                    listaI(0).gTotalIVA = dtsFP.gTotalIVA
                    listaI(0).gTotalRE = dtsFP.gTotalRE
                    funcII.actualizar(listaI(0))
                End If


            End If


            Dim listaCA As List(Of DatosConceptoAlbaranProv) = funcCA.mostrar(dtsAP.gidAlbaran)
            Dim n = 1
            Dim dtsCF As DatosConceptoFacturaProv
            Dim dtsTI As DatosTipoIVA
            For Each dtsCP As DatosConceptoAlbaranProv In listaCA
                dtsCF = New DatosConceptoFacturaProv
                dtsCF.gidFactura = dtsFP.gidFactura
                dtsCF.gidAlbaran = dtsAP.gidAlbaran
                dtsCF.gCantidad = dtsCP.gCantidad
                dtsCF.gidconceptoAlbaranProv = dtsCP.gidConcepto
                dtsCF.gDescuento = dtsCP.gDescuento
                dtsCF.gPrecioNetoUnitario = dtsCP.gPrecioNetoUnitario
                dtsCF.gcodArticuloProv = dtsCP.gcodArticuloProv
                dtsCF.gArticuloProv = dtsCP.gArticulo
                dtsCF.gidArticulo = dtsCP.gidArticulo
                dtsCF.gPVPUnitario = dtsCP.gPVPUnitario
                dtsCF.gidTipoIVA = dtsCP.gidTipoIVA
                dtsTI = funcTI.Mostrar1(dtsCP.gidTipoIVA)
                dtsCF.gTipoIVAFac = dtsTI.gTipoIVA
                'If dtsFP.gRecargoEquivalencia Then
                dtsCF.gTipoRecargoEqFac = dtsTI.gTipoRecargoEq
                'Else
                'dtsCF.gTipoRecargoEqFac = 0
                'End If
                dtsCF.gOrden = n
                dtsCF.gObservaciones = ""
                n = n + 1
                dtsCF.gidEstado = EstadoCFEspera.gidEstado
                dtsCF.gidConcepto = funcCF.insertar(dtsCF)
                dtsCP.gidFactura = dtsFP.gidFactura
                funcCA.actualizar(dtsCP)
            Next

            If nAlbaran <> "" Then
                dtsAP.gidFactura = dtsFP.gidFactura
                funcAP.actualizaidFactura(dtsAP.gidAlbaran, dtsFP.gidFactura)
            End If

        End If

        Return "ALBARAN: " & nAlbaran & "  FACTURA: " & nFactura

    End Function


End Class