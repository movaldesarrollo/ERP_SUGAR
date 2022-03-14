Public Class GestionIVAs

    Private funcFC As New FuncionesFacturas
    Private funcFP As New FuncionesFacturasProv
    Private funcMO As New FuncionesMoneda
    Private funcII As New FuncionesImportesIVA
    Private sBusquedaFC As String
    Private sBusquedaFP As String
    Private ColumnaFC As Integer
    Private OrdenFC As String
    Private DireccionFC As String
    Private ColumnaFP As Integer
    Private OrdenFP As String
    Private DireccionFP As String
    Private listaIVAsRepercutido As List(Of DatosImportesIVA)
    Private listaIVAsSoportado As List(Of DatosImportesIVA)
    Private desktopSize As Size
    Private lvOrdenaIVAsRepercutido As OrdenarLV
    Private lvOrdenaIVAsSoportado As OrdenarLV
    Private vSoloLectura As Boolean
    Private dt As New DataTable
    Private SumaBaseR As Double = 0
    Private SumaCuotaIVAR As Double
    Private SumaCuotaRER As Double
    Private SumaRetencionR As Double
    Private SumaTotalR As Double
    Private SumaBaseS As Double
    Private SumaCuotaIVAS As Double
    Private SumaCuotaRES As Double
    Private SumaRetencionS As Double
    Private SumaTotalS As Double
    Private idTemporal As Integer
    Dim ep1 As New ErrorProvider
    Dim incremento As Integer


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Private Sub GestionIVAS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pbCarga.Visible = True
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        If desktopSize.Height > 900 Then
            Me.Height = 850
        End If
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        'Me.Height = desktopSize.Height - 15
        'Me.Location = New Point(Me.Location.X, 0)



    End Sub


    Private Sub GestionIVAs_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        pbCarga.Visible = True
        pbCarga.Maximum = 100
        Call IntroducirAños()
        Call IntroducirMeses()
        Call IntroducirTrimestres()
        Call Limpiar()
        pbCarga.Increment(10)
        pbCarga.Value = 0
        Call Busqueda()
        Call CargarLiquidacion()
        pbCarga.Visible = False
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = Math.Min(funcFC.buscaPrimerDia(0).Year, funcFP.buscaPrimerDia().Year) To Now.Year
            cbAño.Items.Add(Año)
        Next
    End Sub

    Private Sub IntroducirTrimestres()
        cbTrimestre.Items.Clear()
        cbTrimestre.Items.Add("TRIMESTRE 1")
        cbTrimestre.Items.Add("TRIMESTRE 2")
        cbTrimestre.Items.Add("TRIMESTRE 3")
        cbTrimestre.Items.Add("TRIMESTRE 4")
        cbTrimestre.SelectedIndex = -1

    End Sub

    Private Sub IntroducirMeses()
        cbMes.Items.Clear()
        For Mes = 1 To 12
            cbMes.Items.Add(UCase(MonthName(Mes)))
        Next
        cbMes.SelectedIndex = -1
    End Sub

    Private Sub Limpiar()
        cbAño.Text = Now.Year
        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1
        cbMes.Text = ""
        cbMes.SelectedIndex = -1
        OrdenFC = " DOC.Fecha ASC, DOC.numFactura"
        DireccionFC = "ASC"
        ColumnaFC = 0
        OrdenFP = "DOC.Fecha ASC, DOC.numFactura"
        DireccionFP = "ASC"
        ColumnaFP = 0
    End Sub

#End Region



#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Busqueda()
        ep1.Clear
        If cbAño.SelectedIndex = -1 Then
            ep1.SetError(cbAño, "Se ha de seleccionar un año concreto")
        Else
            If Not listaIVAsRepercutido Is Nothing Then listaIVAsRepercutido.Clear()
            If Not listaIVAsSoportado Is Nothing Then listaIVAsSoportado.Clear()
            sBusquedaFC = ""
            sBusquedaFP = ""
            If IsNumeric(cbAño.Text) Then
                sBusquedaFC = sBusquedaFC & IIf(sBusquedaFC = "", "", " AND ")
                sBusquedaFC = sBusquedaFC & " Year(DOC.Fecha)= " & cbAño.Text
            End If
            If cbMes.SelectedIndex <> -1 Then
                sBusquedaFC = sBusquedaFC & IIf(sBusquedaFC = "", "", " AND ")
                sBusquedaFC = sBusquedaFC & "  Month(DOC.Fecha)= " & cbMes.SelectedIndex + 1
            End If

            If cbTrimestre.SelectedIndex <> -1 Then
                sBusquedaFC = sBusquedaFC & IIf(sBusquedaFC = "", "", " AND ")
                sBusquedaFC = sBusquedaFC & " Month(DOC.Fecha) in "
                Select Case cbTrimestre.SelectedIndex
                    Case 0 '1T
                        sBusquedaFC = sBusquedaFC & " (1,2,3) "
                    Case 1 '2T
                        sBusquedaFC = sBusquedaFC & " (4,5,6) "
                    Case 2 '3T
                        sBusquedaFC = sBusquedaFC & " (7,8,9) "
                    Case 3 '4T
                        sBusquedaFC = sBusquedaFC & " (10,11,12) "
                End Select
            End If
            sBusquedaFP = sBusquedaFC
            Call CargarLVRepercutido()
            Call CargarLVSoportado()
        End If
    End Sub



#End Region


#Region "REPERCUTIDO"

    Private Sub CargarLVRepercutido()
        Dim lista As List(Of DatosFactura) = funcFC.Busqueda(sBusquedaFC, OrdenFC, False)
        incremento = (lista.Count / 100) / 3
        SumaBaseR = 0
        SumaCuotaIVAR = 0
        SumaCuotaRER = 0
        SumaRetencionR = 0
        SumaTotalR = 0
        Dim FechaCambio As Date
        Dim FechaCambioG As Date
        Dim Aviso As Boolean
        Dim AvisoG As Boolean
        Dim TipoIVA As Double = -1
        Call LimpiezaRepercutido()
        For Each dts As DatosFactura In lista
            Call NuevaLineaLVRepercutido(dts)
            Call AcumularIVARepercutido(dts)
            SumaBaseR = SumaBaseR + If(dts.gcodMoneda = "EU", dts.gBase, funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio))
            SumaCuotaIVAR = SumaCuotaIVAR + If(dts.gcodMoneda = "EU", dts.gTotalIVA, funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio))
            SumaCuotaRER = SumaCuotaRER + If(dts.gcodMoneda = "EU", dts.gTotalRE, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio))
            SumaRetencionR = SumaRetencionR + If(dts.gcodMoneda = "EU", dts.gRetencion, funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio))
            SumaTotalR = SumaTotalR + If(dts.gcodMoneda = "EU", dts.gTotal, funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio))
            pbCarga.Increment(incremento)
        Next
        lvOrdenaIVAsRepercutido = New OrdenarLV()
        lvIVAsRepercutido.ListViewItemSorter = lvOrdenaIVAsRepercutido
        lvOrdenaIVAsRepercutido.SortColumn = 0
        lvOrdenaIVAsRepercutido.Order = SortOrder.Descending
        lvIVAsRepercutido.Sort()
        ContadorRepercutido.Text = lvRepercutido.Items.Count
        With lvTotalesRepercutido.Items.Add("")
            .SubItems.Add(FormatCurrency(SumaBaseR, 2))
            .SubItems.Add(FormatCurrency(SumaCuotaIVAR, 2))
            .SubItems.Add(FormatCurrency(SumaCuotaRER, 2))
            .SubItems.Add(FormatCurrency(SumaRetencionR, 2))
            .SubItems.Add(FormatCurrency(SumaTotalR, 2))
        End With
        AvisoG = AvisoG Or Aviso
        If Aviso Then FechaCambioG = FechaCambio
        lbCambioRepercutido.Text = "CAMBIO " & FechaCambioG
        lbCambioRepercutido.Visible = AvisoG

    End Sub


    Private Sub LimpiezaRepercutido()
        lvRepercutido.Items.Clear()
        lvIVAsRepercutido.ListViewItemSorter = Nothing
        lvIVAsRepercutido.Items.Clear()
        If Not listaIVAsRepercutido Is Nothing Then listaIVAsRepercutido.Clear()
        lvTotalesRepercutido.Items.Clear()
        ContadorRepercutido.Text = ""
    End Sub



    Private Sub AcumularIVARepercutido(ByVal dts As DatosFactura)
        If listaIVAsRepercutido Is Nothing Then
            listaIVAsRepercutido = New List(Of DatosImportesIVA)
        End If
        If listaIVAsRepercutido.Count = 0 Then
            NuevaLineaLVIVARepercutido(dts, "IVA")
            If dts.gRecargoEquivalencia And dts.gTotalRE <> 0 Then NuevaLineaLVIVARepercutido(dts, "RE")
        Else
            Dim indice As Integer = TipoIVARepercutidoEn(dts.gTipoIVAFac, "IVA", dts.gcodMoneda)
            If indice = -1 Then
                Call NuevaLineaLVIVARepercutido(dts, "IVA")
            Else
                Call AcumulaImportesLVRepercutido(dts.gBase, dts.gTotalIVA, dts.gSimbolo, indice)
            End If
            If dts.gRecargoEquivalencia And dts.gTotalRE <> 0 Then
                indice = TipoIVARepercutidoEn(dts.gTipoRecargoEqFac, "RE", dts.gcodMoneda)
                If indice = -1 Then
                    Call NuevaLineaLVIVARepercutido(dts, "RE")
                Else
                    Call AcumulaImportesLVRepercutido(dts.gBase, dts.gTotalRE, dts.gSimbolo, indice)
                End If
            End If
        End If
    End Sub


    Private Sub AcumulaImportesLVRepercutido(ByVal Base As Double, ByVal Cuota As Double, ByVal Simbolo As String, ByVal indice As Integer)
        listaIVAsRepercutido(indice).gBase = listaIVAsRepercutido(indice).gBase + Base
        listaIVAsRepercutido(indice).gCuota = listaIVAsRepercutido(indice).gCuota + Cuota
        With lvIVAsRepercutido.Items(indice)
            .SubItems(1).Text = FormatNumber(listaIVAsRepercutido(indice).gBase, 2) & Simbolo
            .SubItems(4).Text = FormatNumber(listaIVAsRepercutido(indice).gCuota, 2) & Simbolo
        End With
    End Sub


    Private Sub NuevaLineaLVIVARepercutido(ByVal dts As DatosFactura, ByVal IVAoRE As String)
        Dim dtsIVA As New DatosImportesIVA
        dtsIVA.gidConcepto = 0
        dtsIVA.gidFactura = 0
        dtsIVA.gnumFactura = ""
        dtsIVA.gBase = dts.gBase
        dtsIVA.gIVAoRE = IVAoRE
        If IVAoRE = "IVA" Then
            dtsIVA.gTipo = dts.gTipoIVAFac
            dtsIVA.gCuota = dts.gTotalIVA
        ElseIf dts.gRecargoEquivalencia Then
            dtsIVA.gTipo = dts.gTipoRecargoEqFac
            dtsIVA.gCuota = dts.gTotalRE
        Else
            dtsIVA.gTipo = 0
            dtsIVA.gCuota = 0
        End If

        dtsIVA.gcodMoneda = dts.gcodMoneda
        dtsIVA.gSimbolo = dts.gSimbolo
        dtsIVA.gNombreIVA = dts.gNombreTipoIVA

        listaIVAsRepercutido.Add(dtsIVA)
        With lvIVAsRepercutido.Items.Add(If(IVAoRE = "IVA", 100 + dts.gTipoIVAFac, dts.gTipoRecargoEqFac)) 'Este campo es para ordenar
            .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
            .SubItems.Add(IVAoRE)
            If IVAoRE = "IVA" Then
                .SubItems.Add(FormatNumber(dts.gTipoIVAFac, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
            ElseIf dts.gRecargoEquivalencia Then
                .SubItems.Add(FormatNumber(dts.gTipoRecargoEqFac, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gTotalRE, 2) & dts.gSimbolo)
            Else
                .SubItems.Add("")
                .SubItems.Add("")
            End If
        End With
    End Sub


    Private Function TipoIVARepercutidoEn(ByVal Tipo As Double, ByVal IVAoRE As String, ByVal codMoneda As String) As Integer
        If listaIVAsRepercutido Is Nothing Then
            listaIVAsRepercutido = New List(Of DatosImportesIVA)
        End If
        If listaIVAsRepercutido.Count > 0 Then
            Dim i As Integer = 0
            While i < listaIVAsRepercutido.Count AndAlso (listaIVAsRepercutido(i).gTipo <> Tipo Or listaIVAsRepercutido(i).gIVAoRE <> IVAoRE Or listaIVAsRepercutido(i).gcodMoneda <> codMoneda)
                i = i + 1
            End While
            If i < listaIVAsRepercutido.Count Then
                Return i
            End If
        End If
        Return -1
    End Function



    Private Sub NuevaLineaLVRepercutido(ByVal dts As DatosFactura)
        With lvRepercutido.Items.Add(dts.gnumFactura)
            .SubItems.Add(dts.gFecha)
            .SubItems.Add(dts.gCliente)
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
            If dts.gTotalRE = 0 Then
                .SubItems.Add("")
            Else
                .SubItems.Add(FormatNumber(dts.gTotalRE, 2) & dts.gSimbolo)
            End If
            If dts.gRetencion = 0 Then
                .SubItems.Add("")
            Else
                .SubItems.Add(FormatNumber(dts.gRetencion, 2) & dts.gSimbolo)
            End If

            .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
        End With
    End Sub



    Private Sub lvIVAsRepercutido_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvIVAsRepercutido.ColumnClick
        If (e.Column = lvOrdenaIVAsRepercutido.SortColumn) Then
            If (lvOrdenaIVAsRepercutido.Order = SortOrder.Ascending) Then
                lvOrdenaIVAsRepercutido.Order = SortOrder.Descending
            Else
                lvOrdenaIVAsRepercutido.Order = SortOrder.Ascending
            End If
        Else
            lvOrdenaIVAsRepercutido.SortColumn = e.Column
            lvOrdenaIVAsRepercutido.Order = SortOrder.Ascending
        End If
        lvIVAsRepercutido.Sort()
    End Sub


#End Region


#Region "SOPORTADO"

    Private Sub CargarLVSoportado()
        Try
            Dim lista As List(Of DatosFacturaProv) = funcFP.Busqueda(sBusquedaFP, OrdenFP)

            SumaBaseS = 0
            SumaCuotaIVAS = 0
            SumaCuotaRES = 0
            SumaRetencionS = 0
            SumaTotalS = 0
            Dim FechaCambio As Date
            Dim FechaCambioG As Date
            Dim Aviso As Boolean
            Dim AvisoG As Boolean
            Call LimpiezaSoportado()
            For Each dts As DatosFacturaProv In lista
                Call NuevaLineaLVSoportado(dts)
                Call AcumularIVASoportado(dts.gImportesIVA)
                SumaBaseS = SumaBaseS + If(dts.gcodMoneda = "EU", dts.gBase, funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio))
                SumaCuotaIVAS = SumaCuotaIVAS + If(dts.gcodMoneda = "EU", dts.gTotalIVA, funcMO.Cambio(dts.gTotalIVA, dts.gcodMoneda, "EU", Aviso, FechaCambio))
                SumaCuotaRES = SumaCuotaRES + If(dts.gcodMoneda = "EU", dts.gTotalRE, funcMO.Cambio(dts.gTotalRE, dts.gcodMoneda, "EU", Aviso, FechaCambio))
                SumaRetencionS = SumaRetencionS + If(dts.gcodMoneda = "EU", dts.gRetencion, funcMO.Cambio(dts.gRetencion, dts.gcodMoneda, "EU", Aviso, FechaCambio))
                SumaTotalS = SumaTotalS + If(dts.gcodMoneda = "EU", dts.gTotal, funcMO.Cambio(dts.gTotal, dts.gcodMoneda, "EU", Aviso, FechaCambio))
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
                pbCarga.Increment(1)
            Next
            lvOrdenaIVAsSoportado = New OrdenarLV()
            lvIVAsSoportado.ListViewItemSorter = lvOrdenaIVAsSoportado
            lvOrdenaIVAsSoportado.SortColumn = 0
            lvOrdenaIVAsSoportado.Order = SortOrder.Descending
            lvIVAsSoportado.Sort()
            ContadorSoportado.Text = lvSoportado.Items.Count
            With lvTotalesSoportado.Items.Add("")
                .SubItems.Add(FormatCurrency(SumaBaseS, 2))
                .SubItems.Add(FormatCurrency(SumaCuotaIVAS, 2))
                .SubItems.Add(FormatCurrency(SumaCuotaRES, 2))
                .SubItems.Add(FormatCurrency(SumaRetencionS, 2))
                .SubItems.Add(FormatCurrency(SumaTotalS, 2))
            End With
            lbCambioSoportado.Text = "CAMBIO " & FechaCambioG
            lbCambioSoportado.Visible = AvisoG
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub LimpiezaSoportado()
        lvSoportado.Items.Clear()
        lvIVAsSoportado.ListViewItemSorter = Nothing
        lvIVAsSoportado.Items.Clear()
        If Not listaIVAsSoportado Is Nothing Then listaIVAsSoportado.Clear()
        lvTotalesSoportado.Items.Clear()
        ContadorSoportado.Text = ""
    End Sub




    Private Sub AcumularIVASoportado(ByVal lista As List(Of DatosImportesIVAProv))
        Try
            If listaIVAsSoportado Is Nothing Then
                listaIVAsSoportado = New List(Of DatosImportesIVA)
            End If
            For Each dts As DatosImportesIVAProv In lista
                If listaIVAsSoportado.Count = 0 Then
                    NuevaLineaLVIVASoportado(dts, "IVA")
                    If dts.gTotalRE <> 0 Then NuevaLineaLVIVASoportado(dts, "RE")
                Else
                    Dim indice As Integer = TipoIVASoportadoEn(dts.gTipoIVA, "IVA", dts.gcodMoneda)
                    If indice = -1 Then
                        Call NuevaLineaLVIVASoportado(dts, "IVA")
                    Else
                        Call AcumularImportesLVSoportado(dts.gBase, dts.gTotalIVA, dts.gSimbolo, indice)
                    End If
                    If dts.gTotalRE <> 0 Then
                        indice = TipoIVASoportadoEn(dts.gTipoRecargoEq, "RE", dts.gcodMoneda)
                        If indice = -1 Then
                            Call NuevaLineaLVIVASoportado(dts, "RE")
                        Else
                            Call AcumularImportesLVSoportado(dts.gBase, dts.gTotalRE, dts.gSimbolo, indice)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Private Sub AcumularImportesLVSoportado(ByVal Base As Double, ByVal Cuota As Double, ByVal Simbolo As String, ByVal indice As Integer)
        listaIVAsSoportado(indice).gBase = listaIVAsSoportado(indice).gBase + Base
        listaIVAsSoportado(indice).gCuota = listaIVAsSoportado(indice).gCuota + Cuota
        With lvIVAsSoportado.Items(indice)
            .SubItems(1).Text = FormatNumber(listaIVAsSoportado(indice).gBase, 2) & Simbolo
            .SubItems(4).Text = FormatNumber(listaIVAsSoportado(indice).gCuota, 2) & Simbolo
        End With
    End Sub

 


    Private Sub NuevaLineaLVIVASoportado(ByVal dts As DatosImportesIVAProv, ByVal IVAoRE As String)
        Dim dtsIVA As New DatosImportesIVA
        dtsIVA.gidConcepto = 0
        dtsIVA.gidFactura = 0
        dtsIVA.gnumFactura = ""
        dtsIVA.gBase = dts.gBase
        dtsIVA.gIVAoRE = IVAoRE
        If IVAoRE = "IVA" Then
            dtsIVA.gTipo = dts.gTipoIVA
            dtsIVA.gCuota = dts.gTotalIVA
        ElseIf dts.gTotalRE <> 0 Then
            dtsIVA.gTipo = dts.gTipoRecargoEq
            dtsIVA.gCuota = dts.gTotalRE
        Else
            dtsIVA.gTipo = 0
            dtsIVA.gCuota = 0
        End If
        dtsIVA.gcodMoneda = dts.gcodMoneda
        dtsIVA.gSimbolo = dts.gSimbolo
        dtsIVA.gNombreIVA = dts.gNombreIVA
        listaIVAsSoportado.Add(dtsIVA)
        With lvIVAsSoportado.Items.Add(If(IVAoRE = "IVA", 100 + dts.gTipoIVA, dts.gTipoRecargoEq)) 'Este campo es para ordenar
            .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
            .SubItems.Add(IVAoRE)
            If IVAoRE = "IVA" Then
                .SubItems.Add(FormatNumber(dts.gTipoIVA, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
            ElseIf dts.gTotalRE <> 0 Then
                .SubItems.Add(FormatNumber(dts.gTipoRecargoEq, 2) & "%")
                .SubItems.Add(FormatNumber(dts.gTotalRE, 2) & dts.gSimbolo)
            Else
                .SubItems.Add("")
                .SubItems.Add("")
            End If
        End With
    End Sub





    Private Function TipoIVASoportadoEn(ByVal Tipo As Double, ByVal IVAoRE As String, ByVal codMoneda As String) As Integer
        If listaIVAsSoportado Is Nothing Then
            listaIVAsSoportado = New List(Of DatosImportesIVA)
        End If
        If listaIVAsSoportado.Count > 0 Then
            Dim i As Integer = 0
            While i < listaIVAsSoportado.Count AndAlso (listaIVAsSoportado(i).gTipo <> Tipo Or listaIVAsSoportado(i).gIVAoRE <> IVAoRE Or listaIVAsSoportado(i).gcodMoneda <> codMoneda)
                i = i + 1
            End While
            If i < listaIVAsSoportado.Count Then
                Return i
            End If
        End If
        Return -1
    End Function



    Private Sub NuevaLineaLVSoportado(ByVal dts As DatosFacturaProv)
        With lvSoportado.Items.Add(dts.gidFactura)
            .SubItems.Add(dts.gFecha)
            .SubItems.Add(dts.gnumFactura)
            .SubItems.Add(dts.gProveedor)
            .SubItems.Add(dts.gEstado)
            .SubItems.Add(FormatNumber(dts.gBase, 2) & dts.gSimbolo)
            .SubItems.Add(FormatNumber(dts.gTotalIVA, 2) & dts.gSimbolo)
            If dts.gTotalRE = 0 Then
                .SubItems.Add("")
            Else
                .SubItems.Add(FormatNumber(dts.gTotalRE, 2) & dts.gSimbolo)
            End If
            If dts.gRetencion = 0 Then
                .SubItems.Add("")
            Else
                .SubItems.Add(FormatNumber(dts.gRetencion, 2) & dts.gSimbolo)
            End If
            .SubItems.Add(FormatNumber(dts.gTotal, 2) & dts.gSimbolo)
        End With
    End Sub


    Private Sub lvIVAsSoportado_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvIVAsSoportado.ColumnClick
        If (e.Column = lvOrdenaIVAsSoportado.SortColumn) Then
            If (lvOrdenaIVAsSoportado.Order = SortOrder.Ascending) Then
                lvOrdenaIVAsSoportado.Order = SortOrder.Descending
            Else
                lvOrdenaIVAsSoportado.Order = SortOrder.Ascending
            End If
        Else
            lvOrdenaIVAsSoportado.SortColumn = e.Column
            lvOrdenaIVAsSoportado.Order = SortOrder.Ascending
        End If
        lvIVAsSoportado.Sort()
    End Sub

#End Region


#Region "LIQUIDACIÓN"

    Private Sub CargarLiquidacion()
        tvLiquidacion.Nodes.Clear()
        Dim NodoRepercutido As New TreeNode
        Dim TotalRepercutido As Double = 0
        For Each dtsI As DatosImportesIVA In listaIVAsRepercutido
            TotalRepercutido = TotalRepercutido + dtsI.gCuota
        Next

        NodoRepercutido.Text = "CUOTA IVA REPERCUTIDO:  " & FormatCurrency(TotalRepercutido, 2) & "   "

        Dim Fuente0 As Font = New Font(tvLiquidacion.Font.FontFamily, tvLiquidacion.Font.Size, FontStyle.Bold)
        NodoRepercutido.NodeFont = Fuente0
        Dim dts As DatosImportesIVA
        For Each dts In listaIVAsRepercutido
            If dts.gCuota <> 0 Then
                NodoRepercutido.Nodes.Add(dts.gIVAoRE & " " & dts.gNombreIVA & ":  BASE: " & FormatNumber(dts.gBase, 2) & dts.gSimbolo & "  TIPO: " & dts.gTipo & "%" & "  CUOTA: " & FormatNumber(dts.gCuota, 2) & dts.gSimbolo)
            End If
        Next
        tvLiquidacion.Nodes.Add(NodoRepercutido)
        Dim NodoSoportado As New TreeNode
        NodoSoportado.NodeFont = Fuente0
        Dim TotalSoportado As Double = 0
        For Each dtsI As DatosImportesIVA In listaIVAsSoportado
            TotalSoportado = TotalSoportado + dtsI.gCuota
        Next

        NodoSoportado.Text = "CUOTA IVA SOPORTADO:  " & FormatCurrency(TotalSoportado, 2) & "   "

        For Each dts In listaIVAsSoportado
            If dts.gCuota <> 0 Then
                NodoSoportado.Nodes.Add(dts.gIVAoRE & " " & dts.gNombreIVA & ":  BASE: " & FormatNumber(dts.gBase, 2) & dts.gSimbolo & "  TIPO: " & dts.gTipo & "%" & "  CUOTA: " & FormatNumber(dts.gCuota, 2) & dts.gSimbolo)
            End If
            pbCarga.Increment(incremento)
        Next
        tvLiquidacion.Nodes.Add(NodoSoportado)
        tvLiquidacion.ExpandAll()
        TotalCuotaRepercutido.Text = FormatCurrency(TotalRepercutido, 2)
        TotalCuotaSoportado.Text = FormatCurrency(TotalSoportado, 2)
        Diferencia.Text = FormatCurrency(TotalRepercutido - TotalSoportado, 2)
    End Sub



#End Region


#Region "BOTONES GENERALES"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call Limpiar()
        Call Busqueda()
        Call CargarLiquidacion()
    End Sub

    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        If cbAño.SelectedIndex <> -1 Then
            Call CargarTablaTemporal()
            Dim GG As New ImprimirLiquidacionIVA
            GG.pLiquidacion = True
            GG.pRepercutido = False
            GG.pSoportado = False
            GG.ShowDialog()
            If GG.pValidar Then
                Dim Periodo As String = ""
                If IsNumeric(cbAño.Text) Then Periodo = cbAño.Text & "  "
                If cbTrimestre.SelectedIndex <> -1 Then Periodo = Periodo & cbTrimestre.Text & "  "
                If cbMes.SelectedIndex <> -1 Then Periodo = Periodo & cbMes.Text
                Periodo = Trim(Periodo)
                Dim IL As New InformeListadoLiquidacionIVA
                IL.verInforme(Periodo, sBusquedaFC, OrdenFC, sBusquedaFP, OrdenFP, GG.pLiquidacion, GG.pRepercutido, GG.pSoportado, idTemporal, SumaBaseR, SumaCuotaIVAR, SumaCuotaRER, SumaRetencionR, SumaTotalR, SumaBaseS, SumaCuotaIVAS, SumaCuotaRES, SumaRetencionS, SumaTotalS)
                IL.ShowDialog()
                funcII.borrar(idTemporal)
            End If

        End If

    End Sub



#End Region


#Region "EVENTOS"

    Private Sub cbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMes.SelectionChangeCommitted, cbTrimestre.SelectionChangeCommitted, cbAño.SelectionChangeCommitted
        Call Busqueda()
        Call CargarLiquidacion()
    End Sub

    Private Sub lvRepercutido_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRepercutido.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaFC Then
            If DireccionFC = "ASC" Then
                DireccionFC = "DESC"
            Else
                DireccionFC = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 
        Select Case e.Column
            Case 0
                OrdenFC = "DOC.numFactura"
            Case 1
                OrdenFC = "DOC.Fecha"
            Case 2
                OrdenFC = "Cliente"
            Case 3
                OrdenFC = "Estados.Estado"
            Case 4
                OrdenFC = "Base"
            Case 5
                OrdenFC = "Base"
            Case 6
                OrdenFC = "Base"
            Case 7
                OrdenFC = "Base"
            Case 8
                OrdenFC = "Base"
        End Select
        ColumnaFC = e.Column
        If OrdenFC <> "" Then
            OrdenFC = OrdenFC & " " & DireccionFC
        End If
        Call CargarLVRepercutido()
    End Sub

    Private Sub lvSoportado_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvSoportado.ColumnClick
        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = ColumnaFP Then
            If DireccionFP = "ASC" Then
                DireccionFP = "DESC"
            Else
                DireccionFP = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 
        Select Case e.Column
            Case 0
                OrdenFP = "DOC.idFactura"
            Case 1
                OrdenFP = "DOC.Fecha"
            Case 2
                OrdenFP = "DOC.numFactura"
            Case 3
                OrdenFP = "Proveedor"
            Case 4
                OrdenFP = "Estados.Estado"
            Case 5
                OrdenFP = "Base"
            Case 6
                OrdenFP = "TotalIVA"
            Case 7
                OrdenFP = "TotalRE"
            Case 8
                OrdenFP = "Retencion"
            Case 9
                OrdenFP = "Total"
        End Select
        ColumnaFP = e.Column
        If OrdenFP <> "" Then
            OrdenFP = OrdenFP & " " & DireccionFP
        End If
        Call CargarLVSoportado()
    End Sub


    Private Sub lvRepercutido_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRepercutido.DoubleClick
        If lvRepercutido.SelectedItems.Count > 0 Then
            Dim GG As New GestionFactura1
            GG.SoloLectura = vSoloLectura
            GG.pnumFactura = lvRepercutido.SelectedItems(0).Text
            GG.ShowDialog()
        End If
    End Sub



    Private Sub lvSoportado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSoportado.DoubleClick
        If lvSoportado.SelectedItems.Count > 0 Then
            Dim GG As New GestionFacturaProv
            GG.SoloLectura = vSoloLectura
            GG.pidFactura = lvSoportado.SelectedItems(0).Text
            GG.ShowDialog()
        End If
    End Sub


#End Region


    Private Sub CrearDataTable()
        dt = New DataTable
        dt.Columns.Add("REPoSOP", Type.GetType("System.String"))
        dt.Columns.Add("idFactura", Type.GetType("System.Int32"))
        dt.Columns.Add("idTipoIVA", Type.GetType("System.Int16"))
        dt.Columns.Add("Tipo", Type.GetType("System.Double"))
        dt.Columns.Add("Base", Type.GetType("System.Double"))
        dt.Columns.Add("Cuota", Type.GetType("System.Double"))
        dt.Columns.Add("IVAoRE", Type.GetType("System.String"))
        dt.Columns.Add("numFactura", Type.GetType("System.String"))
        dt.Columns.Add("NombreIVA", Type.GetType("System.String"))
        dt.Columns.Add("codMoneda", Type.GetType("System.String"))
        dt.Columns.Add("Simbolo", Type.GetType("System.String"))
        'Dim dtImportesIVARepercutido As DataTable = dt.Clone
        'Dim dtImportesIVASoportado As DataTable = dt.Clone
        'dsIVA.Clear()
        'dsIVA.Tables.Add(dtImportesIVARepercutido)
        'dsIVA.Tables.Add(dtImportesIVASoportado)

        For Each dts As DatosImportesIVA In listaIVAsRepercutido
            Dim linea As DataRow = dt.NewRow
            linea("REPoSOP") = "REP"
            Call NuevaLineaDT(dts, linea)
            dt.Rows.Add(linea)
        Next
        For Each dts As DatosImportesIVA In listaIVAsSoportado
            Dim linea As DataRow = dt.NewRow
            linea("REPoSOP") = "SOP"
            Call NuevaLineaDT(dts, linea)
            dt.Rows.Add(linea)
        Next

    End Sub

    Private Sub CargarTablaTemporal()
        idTemporal = funcII.SiguienteidConcepto
        For Each dts As DatosImportesIVA In listaIVAsRepercutido
            dts.gREPoSOP = "REP"
            dts.gidConcepto = idTemporal
            funcII.insertar(dts)
        Next
        For Each dts As DatosImportesIVA In listaIVAsSoportado
            dts.gREPoSOP = "SOP"
            dts.gidConcepto = idTemporal
            funcII.insertar(dts)
        Next
    End Sub



    Private Sub NuevaLineaDT(ByVal dts As DatosImportesIVA, ByRef linea As DataRow)
        linea("idFactura") = dts.gidFactura
        linea("Tipo") = dts.gTipo
        linea("Base") = dts.gBase
        linea("Cuota") = dts.gCuota
        linea("IVAoRE") = dts.gIVAoRE
        linea("numFactura") = dts.gnumFactura
        linea("NombreIVA") = dts.gNombreIVA
        linea("codMoneda") = dts.gcodMoneda
        linea("Simbolo") = dts.gSimbolo
    End Sub

   



  
End Class