Public Class EstadisticaProduccion

    Private funcCE As New FuncionesConceptosEquiposProduccion
    Private funcPE As New FuncionesPersonal
    Private sBusqueda As String
    Private columna As Integer
    Private Direccion As String
    Private sOrden As String
    Private semaforo As Boolean

    Private Sub EstadisticaProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        semaforo = False
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        If desktopSize.Height < 900 Then
            Me.Height = desktopSize.Height - 50
        Else
            Me.Height = 850
        End If
        dtpDesde.Value = "1-1-" & Now.Date.Year
        dtpHasta.Value = Now.Date
        sOrden = ""
        Direccion = "ASC"
        columna = 0
        Call CargarTecnicos()
        Call Busqueda()
        semaforo = True
    End Sub

    Private Sub CargarTecnicos()
        cbPersona.Items.Clear()
        Dim lista As List(Of IDComboBox) = funcPE.ListarTecnicos
        For Each item As IDComboBox In lista
            cbPersona.Items.Add(item)
        Next
        cbPersona.Items.Add(New IDComboBox("TODOS", 0))
        cbPersona.Text = "TODOS"
    End Sub

    Private Sub Busqueda()
        sBusqueda = ""
        sBusqueda = sBusqueda & " CONVERT(datetime,CONVERT(Char(10), Finalizacion,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), Finalizacion,103))  <= '" & dtpHasta.Value.Date & "' "
        If cbPersona.SelectedIndex <> -1 And cbPersona.Text <> "TODOS" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CE.idFinalizador = " & cbPersona.SelectedItem.itemdata
        End If
        Call ActualizarLV()
    End Sub

    Private Sub ActualizarLV()
        lvConceptos.Items.Clear()
        Dim lista As List(Of DatosEstadisticaProduccion) = funcCE.Estadistica(sBusqueda, sOrden)
        For Each dts As DatosEstadisticaProduccion In lista
            Call NuevaLineaLV(dts)
        Next
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosEstadisticaProduccion)
        With lvConceptos.Items.Add(dts.gidPersona)
            .SubItems.Add(dts.gPersona)
            .SubItems.Add(dts.gcodArticulo)
            .SubItems.Add(dts.gArticulo)
            .SubItems.Add(dts.gCantidad & dts.gTipoUnidad)
            .SubItems.Add(dts.gidArticulo)
        End With
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        Dim GG As New InformeEstadisticaProduccion
        Dim titulo As String
        If dtpDesde.Value.Date = dtpHasta.Value.Date Then
            titulo = dtpDesde.Value.Date
        Else
            titulo = "DESDE " & dtpDesde.Value.Date & " HASTA " & dtpHasta.Value.Date
        End If
        GG.verInforme(sBusqueda, sOrden, titulo)
        GG.ShowDialog()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub lvConceptos_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvConceptos.ColumnClick

        ' Determinar si la columna en la que se hizo clic ya es la que se está ordenando. 
        If e.Column = columna Then
            If direccion = "ASC" Then
                direccion = "DESC"
            Else
                direccion = "ASC"
            End If
        End If ' Establecer el número de columna que se va a ordenar; 

        Select Case e.Column
            Case 0
                sOrden = "CE.idFinalizador"
            Case 1
                sOrden = "Persona"
            Case 2
                sOrden = "AR.codArticulo"
            Case 3
                sOrden = "AR.Articulo"
            Case 4
                sOrden = "Cantidad"
            Case 5
                sOrden = "CE.idArticulo"

        End Select

        columna = e.Column
        If sOrden <> "" Then
            sOrden = sOrden & " " & Direccion
        End If
        Call ActualizarLV()

    End Sub

    Private Sub cbPersona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPersona.SelectedIndexChanged
        If semaforo Then Call Busqueda()
    End Sub

#Region "CAMBIAR FECHAS"
    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            Call Busqueda()
        End If
    End Sub
#End Region
End Class