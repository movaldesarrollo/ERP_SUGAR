Public Class BusquedaLiquidaciones

    Private funcLQ As New funcionesLiquidaciones
    Private funcPE As New FuncionesPersonal
    Private funcFA As New FuncionesFacturas
    Private funcMO As New FuncionesMoneda
    Private vsoloLectura As Boolean
    Private VerClientesPropios As Boolean
    Private indice As Integer
    Private GestionaComisiones As Boolean
    Private sBusqueda As String
    Private Orden As String
    Private Direccion As String
    Private CambioFechas As Boolean
    Private columna As Integer
    Private semaforo As Boolean

    Public Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Private Sub BusquedaLiquidaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'PERMISOS 
        VerClientesPropios = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        GestionaComisiones = funcPE.Permiso(Inicio.vIdUsuario, "AsignacionComisiones")
        semaforo = False
        Call IntroducirAños()
        Call IntroducirMeses()
        Call IntroducirResponsables()
        Call IntroducirTrimestres()
        Call limpiar()
        Call Busqueda()
        semaforo = True
    End Sub

#Region "INICIALIZACIÓN"

    Private Sub limpiar()
        semaforo = False
        indice = -1
        If GestionaComisiones Then
            cbResponsable.Text = ""
            cbResponsable.SelectedIndex = -1
        End If

        dtpDesde.Value = CDate("1-1-" & Now.Year)
        dtpHasta.Value = Now.Date

        cbAño.Text = ""
        cbAño.SelectedIndex = -1
        cbMes.Text = ""
        cbMes.SelectedIndex = -1
        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1
        CambioFechas = False
        Orden = ""
        Direccion = "ASC"
        For Each item As ListViewItem In lvDocumentos.SelectedItems
            item.Checked = False
        Next
        Total.Text = ""
        id.Text = ""
        semaforo = True

    End Sub


    Private Sub IntroducirResponsables()
        Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(If(VerClientesPropios, Inicio.vIdUsuario, 0))

        For Each item As IDComboBox In lista
            cbResponsable.Items.Add(item)
        Next
        If VerClientesPropios Then
            cbResponsable.Enabled = False
            If lista.Count = 0 Then
                MsgBox("No está autorizado para visualizar clientes")
                Me.Close()
            Else
                cbResponsable.SelectedIndex = 0
            End If
        Else
            cbResponsable.SelectedIndex = -1
        End If

    End Sub


    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = dtpDesde.Value.Year To dtpHasta.Value.Year
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



#End Region

#Region "CARGAR DATOS"




#End Region

#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Busqueda()

        sBusqueda = ""

        If id.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " LQ.idLiquidacion = " & id.Text
        End If

        If cbResponsable.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " LQ.idComercial = " & cbResponsable.SelectedItem.itemdata
        End If


        If CambioFechas Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), LQ.FechaLiquidacion,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), LQ.FechaLiquidacion,103))  <= '" & dtpHasta.Value.Date & "' "
        End If

        If IsNumeric(cbAño.Text) Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Year(LQ.FechaLiquidacion)= " & cbAño.Text
        End If
        If cbMes.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " Month(LQ.FechaLiquidacion)= " & cbMes.SelectedIndex + 1
        End If

        If cbTrimestre.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & "  Month(LQ.FechaLiquidacion)in "
            Select Case cbTrimestre.SelectedIndex
                Case 0 '1T
                    sBusqueda = sBusqueda & " (1,2,3) "
                Case 1 '2T
                    sBusqueda = sBusqueda & " (4,5,6) "
                Case 2 '3T
                    sBusqueda = sBusqueda & " (7,8,9) "
                Case 3 '4T
                    sBusqueda = sBusqueda & " (10,11,12) "
            End Select
        End If



        Call ActualizarLV()

    End Sub

    Private Sub ActualizarLV()
        lvDocumentos.Items.Clear()
        Dim lista As List(Of DatosLiquidacion) = funcLQ.Busqueda(sBusqueda, Orden)
        Dim suma As Double = 0
        For Each dts As DatosLiquidacion In lista
            Call NuevaLineaLV(dts)
            suma = suma + dts.gImporte
        Next
        Total.Text = FormatNumber(suma, 2)
    End Sub


    Private Sub NuevaLineaLV(ByVal dts As DatosLiquidacion)
        With lvDocumentos.Items.Add(dts.gidLiquidacion)
            .SubItems.Add(dts.gFechaLiquidacion)
            .SubItems.Add(dts.gComercial)
            .SubItems.Add(FormatCurrency(dts.gImporte))
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosLiquidacion)
        With lvDocumentos.Items(indice)
            .SubItems(1).Text = dts.gFechaLiquidacion
            .SubItems(2).Text = dts.gComercial
            .SubItems(3).Text = FormatCurrency(dts.gImporte)
        End With
    End Sub

    Private Function CalcularBaseEU(ByVal iidLiquidacion As Integer) As Double
        Dim lista As List(Of datosFacturaComision) = funcFA.BusquedaLiquidacion(" DOC.idLiquidacion = " & iidLiquidacion, "")
        Dim suma As Double = 0
        Dim Aviso As Boolean = False
        Dim AvisoG As Boolean = False
        Dim FechaCambio As Date = Now.Date
        Dim FechaCambioG As Date = Now.Date
        For Each dts As datosFacturaComision In lista
            If dts.gcodMoneda = "EU" Then
                suma = suma + dts.gBase
            Else
                suma = suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                AvisoG = AvisoG Or Aviso
                If Aviso Then FechaCambioG = FechaCambio
            End If
        Next
        Return suma
    End Function

#End Region

#Region "BOTONES GENERALES"

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Call Imprimir()
    End Sub

    Private Sub Imprimir()
        If lvDocumentos.SelectedItems.Count > 0 Then
            Dim iidLiquidacion As Integer = lvDocumentos.SelectedItems(0).Text
            Dim GG As New InformeListadoLiquidacionComisiones
            GG.verInforme(iidLiquidacion, CalcularBaseEU(iidLiquidacion))
            GG.ShowDialog()
        End If

    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
        Call Busqueda()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub



#End Region

#Region "EVENTOS"

    Private Sub lvDocumentos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDocumentos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If Direccion = "ASC" Then
                Direccion = "DESC"
            Else
                Direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0, 1
                Orden = "DOC.idLiquidacion"
            Case 2
                Orden = "DOC.FechaLiquidacion"
            Case 3
                Orden = "Comercial"
            Case 4
                Orden = "ImporteLiquidacion"

            Case Else

                Orden = ""
        End Select


        columna = e.Column
        If Orden <> "" Then
            Orden = Orden & " " & Direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub Cliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbResponsable.SelectedIndexChanged, cbAño.TextChanged, cbMes.SelectedIndexChanged, cbTrimestre.SelectedIndexChanged, id.TextChanged
        If semaforo Then Call Busqueda()
    End Sub

    Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.DoubleClick
        Call Imprimir()
    End Sub

#Region "CAMBIAR FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub
#End Region

#End Region

End Class