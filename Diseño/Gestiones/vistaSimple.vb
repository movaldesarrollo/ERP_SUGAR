'Muestra una vista de los pedido de produccion.
'Depliega los conceptos de pedidos de produccion.
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Data.Sql
Imports System.IO

Public Class vistaSimple

#Region "VARIABLES"

    Dim conexiones As New conexion

    Dim cmd As SqlCommand

    Dim sconexion As String = conexiones.CadenaConexion()

    Dim sinGuardar As Boolean

    Dim tamañoForm As Double

    Dim tamañoLv As Double

    Dim orden As String = " PE.Prioridad asc , PE.FechaEntrega asc "

    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.

    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.

    Dim vertodos As Boolean

    Dim tiempoUpdate As Boolean

    Public fuente As Font

    Public noBuscar As Boolean = True

    Public textoPedidosAx As String

#End Region

#Region "CARGA Y CIERRE"

    'Carga de formulario.
    Private Sub vistaSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dimensionando form
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize

        Me.Height = desktopSize.Height - 45

        Me.Width = desktopSize.Width - 45

        Me.Location = New Point(15, 15)

        If lvproduccion.Width > 1236 Then

            lvColCliente.Width = lvColCliente.Width + (lvproduccion.Width - 1500)

        End If

        FUENTEToolStripMenuItem.Visible = False

        fuente = New System.Drawing.Font("Century Gothic", 10)

        cambiarFuente()

        llenarClientes()

        tRefresco.Interval = 60000

        tConteo.Start()

        tRefresco.Start()

        noBuscar = False

        refresco()
        OrdenIndicesLV()
    End Sub

    Private Sub OrdenIndicesLV()


    End Sub

    'Cierre de formulario
    Private Sub vistaSimple_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If sinGuardar Then 'Si hay cambios sin guardar no pregunta antes de salir.

            If MsgBox("Desea salir sin guardar los cambios?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then

                e.Cancel = True

            End If

        End If

    End Sub

#End Region

#Region "BOTONES"

    'Buscar pedidos de produccion.
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        If tRefresco.Interval = 0 Then

            llenarLvproduccion()

        Else

            refresco()

        End If

    End Sub

    'Boton salir
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'Boton calcular
    Private Sub bCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCalcular.Click
        Dim gg As New calculadorFechaPrevista
        gg.ShowDialog()
    End Sub

#End Region

#Region "FUNCIONES Y METODOS"

    'Cambiar fecha prevista.
    Public Function cambiarFP() As Boolean
        Try
            For Each item In lvproduccion.SelectedItems

                Dim cfp As New CambiarFechaPrevista

                cfp.dtpFecha.Value = item.SubItems(1).text
                cfp.fechaInicial = item.SubItems(1).text
                cfp.numpedido = item.text
                cfp.ShowDialog()

                If cfp.sinCambio Then
                    Dim sel As String = "update pedidos set fechaEntrega = '" & cfp.dtpFecha.Value & "' where numpedido = " & item.text
                    Dim con As New SqlConnection(sconexion)
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    item.SubItems(1).Text = cfp.dtpFecha.Value
                End If

                Return True
            Next
        Catch ex As Exception
            MsgBox("No se ha podido cambiar la fecha prevista.", MsgBoxStyle.Critical, "ERROR")
        End Try
        Return False
    End Function

    Public Function cambiarFPRO() As Boolean

        Dim con As New SqlConnection(sconexion)
        Try
            For Each item In lvproduccion.SelectedItems

                Dim cfp As New CambiarFechaPrevista

                cfp.dtpFecha.Value = item.SubItems(14).text
                cfp.fechaInicial = item.SubItems(14).text
                cfp.numpedido = item.text
                cfp.ShowDialog()

                If cfp.sinCambio Then
                    Dim sel As String = "update pedidos set fechaProduccion = '" & cfp.dtpFecha.Value & "' where numpedido = " & item.text

                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    item.SubItems(14).Text = cfp.dtpFecha.Value
                End If
                con.Close()
                Return True
            Next
        Catch ex As Exception
            MsgBox("No se ha podido cambiar la fecha de produccion.", MsgBoxStyle.Critical, "ERROR")
        End Try
        con.Close()
        Return False
    End Function

    'llenarCombo Clientes
    Public Sub llenarClientes()

        Dim dt As New DataTable

        dt = cargarClientes()

        cbClientes.ValueMember = "idcliente"

        cbClientes.DisplayMember = "nombreComercial"

        cbClientes.DataSource = dt

        cbClientes.SelectedIndex = -1

    End Sub

    'llenar lv
    Public Sub llenarLvproduccion()

        textoPedidosAx = ""
        Dim t As Integer = 0 'Pedidos
        Dim c As Integer = 0 'Celulas
        Dim i As Integer = 0 'Industriales
        Dim d As Integer = 0 'Domesticos
        Dim d2 As Integer = 0 'Domesticos2
        Dim r As Integer = 0 'Recambios

        totalPedidos.Text = "TOTAL PEDIDOS:  "
        lbCelulas.Text = "TOTAL CÉLULAS:  "
        lbDomesticos.Text = "TOTAL DOMÉSTICOS: "
        lbDomesticos2.Text = "TOTAL DOMÉSTICOS 2:  " 'RAMOS
        lbIndustriales.Text = "TOTAL INDUSTRIALES:  "
        lbRecambios.Text = "TOTAL RECAMBIOS:  "

        lvproduccion.Sorting = Windows.Forms.SortOrder.None

        lvproduccion.Items.Clear()

        Dim totalcontDom As Integer = 0
        Dim totalcontDom2 As Integer = 0
        Dim totalcontCel As Integer = 0
        Dim totalcontInd As Integer = 0

        Dim lista As List(Of DatosPedidosProd) = mostrarPedidosEnProd(orden)
        For Each dts As DatosPedidosProd In lista

            With lvproduccion.Items.Add(dts.gnumpedido)
                .SubItems.Add(dts.gfechaEntrega) '1
                .SubItems.Add(dts.gfecha) '2
                .SubItems.Add(dts.gcliente) '3
                .SubItems.Add(dts.gRoturaStock)  '4
                .SubItems.Add(dts.gCelulasAcabadas.ToString & " / " & dts.gcantidadCelulas.ToString) '5 /
                .SubItems.Add(dts.gDomesticosAcabados.ToString & " / " & dts.gDomestico.ToString) '6 /
                .SubItems.Add(dts.gIndustrialesAcabados.ToString & " / " & dts.gIndustrial.ToString) '7 /
                .SubItems.Add(dts.gRecambios.ToString) '8 /
                .SubItems.Add(dts.gNotaImpresa) '9
                .SubItems.Add(If(dts.gRecambios > 0, "X", " ")) '10
                .SubItems.Add(dts.gPrioridad) '11

                If dts.gEstado = "PREPARADO" Then

                    .SubItems.Add("PRODUCCIÓN") '12

                Else

                    .SubItems.Add(dts.gEstado) '12

                End If

                .SubItems.Add("PDF") '13
                .SubItems.Add(dts.gFechaProduccion) '14
                .SubItems.Add(dts.gPedidoAX) '15
                .SubItems.Add(dts.gRoturaStock) '16
                .SubItems.Add(dts.gDomesticos2Acabados.ToString & " / " & dts.gDomesticos2.ToString) 'RAMOS 17 /
                .SubItems.Add(dts.gFechaVolcado) '18

                c = c + dts.gcantidadCelulas.ToString
                d = d + dts.gDomestico.ToString
                i = i + dts.gIndustrial.ToString
                r = r + dts.gRecambios.ToString
                d2 = d2 + dts.gDomesticos2.ToString

                totalcontDom2 = totalcontDom2 + dts.gDomesticos2Acabados
                totalcontDom = totalcontDom + dts.gDomesticosAcabados
                totalcontCel = totalcontCel + dts.gCelulasAcabadas
                totalcontInd = totalcontInd + dts.gIndustrialesAcabados

                If dts.gPedidoAX <> "" Then

                    textoPedidosAx = textoPedidosAx & dts.gPedidoAX & ";" & dts.gFechaProduccion & vbCrLf

                End If

                If dts.gEstado = "PRODUCIDO" Then

                    .ForeColor = Color.Green

                Else
                    Select Case dts.gPrioridad
                        Case 1
                            .ForeColor = Color.Red
                        Case 2
                            .ForeColor = Color.Black
                            'Case 3
                            '.ForeColor = Color.orange
                    End Select
                End If

                If dts.gReparacion = True Then

                    .ForeColor = Color.Blue

                End If

                If dts.gRoturaStock Then

                    .ForeColor = Color.Orange

                End If

                If dts.gDomesticos2 Then

                    .ForeColor = Color.BlueViolet


                End If

            End With

            t = t + 1
        Next

        totalPedidos.Text = totalPedidos.Text & FormatNumber(t, 0)
        lbCelulas.Text = lbCelulas.Text & FormatNumber(totalcontCel, 0) & " / " & FormatNumber(c, 0)
        lbDomesticos.Text = lbDomesticos.Text & FormatNumber(totalcontDom, 0) & " / " & FormatNumber(d, 0)
        lbDomesticos2.Text = lbDomesticos2.Text & FormatNumber(totalcontDom2, 0) & " / " & FormatNumber(d2, 0) 'RAMOS
        lbIndustriales.Text = lbIndustriales.Text & FormatNumber(totalcontInd, 0) & " / " & FormatNumber(i, 0)
        lbRecambios.Text = lbRecambios.Text & FormatNumber(r, 0)

    End Sub

    'Orden de listview
    Private Sub ListView1_ColumnClick(ByVal sender As Object,
            ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
            Handles lvproduccion.ColumnClick
        If lvproduccion.Items.Count <> 0 Then
            If e.Column = 15 Or e.Column = 16 Then
                lvproduccion.Sorting = Windows.Forms.SortOrder.None
            Else
                'Si columna actual es igual a la última columna seleccionada. Formatea la variable con el orden de búsqueda anterio. 
                If e.Column = numColumna Then
                    lvproduccion.Sorting = colOrder
                End If
                ' Crear una instancia de la clase que realizará la comparación
                Dim oCompare As New ListViewColumnSort()
                ' Asignar el orden de clasificación
                If lvproduccion.Sorting = Windows.Forms.SortOrder.Ascending Then
                    oCompare.Sorting = Windows.Forms.SortOrder.Descending
                Else
                    oCompare.Sorting = Windows.Forms.SortOrder.Ascending
                End If
                lvproduccion.Sorting = oCompare.Sorting
                ' La columna en la que se ha pulsado
                oCompare.ColumnIndex = e.Column
                ' El tipo de datos de la columna en la que se ha pulsado
                Select Case e.Column

                    Case 0
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 1
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                    Case 2
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                    Case 3
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 4
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 5
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 6
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 7
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 8
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 9
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 10
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 11
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 12
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 13
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 14
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                    Case 17
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 18
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                End Select
                'Select Case e.Column

                '    Case 0
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                '    Case 1
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                '    Case 2
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                '    Case 3
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 4
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 5
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 6
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 7
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 8
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                '    Case 9
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 10
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 11
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                '    Case 12
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 13
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                '    Case 14
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                '    Case 17
                '        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena

                'End Select
                'Elimina los items expandidos.
                'ReordenarExpandidos(True, False)
                ' Asignar la clase que implementa IComparer
                ' y que se usará para realizar la comparación de cada elemento

                lvproduccion.ListViewItemSorter = oCompare
                numColumna = e.Column
                colOrder = oCompare.Sorting
            End If
            'Vuelve a insertar los items expandidos.
            'ReordenarExpandidos(False, True)
        End If
    End Sub

    'Activa el check del menu contextual.
    Public Sub checksMenu()

        Select Case tRefresco.Interval

            Case 1
                NoToolStripMenuItem.Checked = True
                ToolStripMenuItem8.Checked = False
                ToolStripMenuItem9.Checked = False
                ToolStripMenuItem10.Checked = False
            Case 60000
                NoToolStripMenuItem.Checked = False
                ToolStripMenuItem9.Checked = False
                ToolStripMenuItem10.Checked = False
                ToolStripMenuItem8.Checked = True
            Case 300000
                NoToolStripMenuItem.Checked = False
                ToolStripMenuItem8.Checked = False
                ToolStripMenuItem10.Checked = False
                ToolStripMenuItem9.Checked = True
            Case 600000
                NoToolStripMenuItem.Checked = False
                ToolStripMenuItem8.Checked = False
                ToolStripMenuItem9.Checked = False
                ToolStripMenuItem10.Checked = True
        End Select

        Select Case fuente.Size
            Case 10
                ToolStripMenuItem5.Checked = True
                ToolStripMenuItem6.Checked = False
                ToolStripMenuItem7.Checked = False
            Case 12
                ToolStripMenuItem5.Checked = False
                ToolStripMenuItem6.Checked = True
                ToolStripMenuItem7.Checked = False
            Case 14
                ToolStripMenuItem5.Checked = False
                ToolStripMenuItem6.Checked = False
                ToolStripMenuItem7.Checked = True
        End Select

        If cambiarPermisos(Inicio.vIdUsuario) Then
            EstadoToolStripMenuItem.Visible = True
        Else
            EstadoToolStripMenuItem.Visible = False
        End If

    End Sub

    Public Function cambiarPermisos(ByVal idusuario As Integer) As Boolean
        Try
            Dim sel As String = "select * from Menu_EntradasUsuario  where idMenu = 124 and idusuario = " & idusuario
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteScalar = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Refresco
    Public Sub refresco()

        If noBuscar Then

        Else

            tConteo.Stop()

            pbActualizacion.Value = 0

            llenarLvproduccion()

            tConteo.Start()

        End If

    End Sub

    'cambiar fuente
    Public Sub cambiarFuente()

        lvproduccion.Font = fuente
        ContextMenuStrip1.Font = fuente
        totalPedidos.Font = fuente
        lbCelulas.Font = fuente
        lbDomesticos.Font = fuente
        lbDomesticos2.Font = fuente
        lbIndustriales.Font = fuente
        lbRecambios.Font = fuente
        ckVerTodos.Font = fuente
        GroupBox1.Font = fuente

    End Sub

    Public Function comprobarCheckEstados()

        Dim n As String = ""

        Try

            If ckVerTodos.Checked = False Then

                If ckParcial.Checked Then
                    If n = "" Then
                        n = "65"
                    Else
                        n = n & ",65"
                    End If
                End If

                If ckPendiente.Checked Then
                    If n = "" Then
                        n = "6"
                    Else
                        n = n & ",6"
                    End If
                End If
                If ckPreparado.Checked Then
                    If n = "" Then
                        n = "58"
                    Else
                        n = n & ",58"
                    End If
                End If
                If ckProducido.Checked Then
                    If n = "" Then
                        n = "62"
                    Else
                        n = n & ",62"
                    End If
                End If
                If ckProduccion.Checked Then
                    If n = "" Then
                        n = "21"
                    Else
                        n = n & ",21"
                    End If
                End If
                If ckServido.Checked Then
                    If n = "" Then
                        n = "12"
                    Else
                        n = n & ",12"
                    End If
                End If

                If n <> "" Then
                    n = " PE.idEstado in (" & n & " ) and "
                Else
                    n = " PE.idEstado in (99999) and "

                End If

            End If

            Return n
        Catch ex As Exception

            Return " "
        End Try

    End Function

    'Limpiar
    Public Sub limpiar()

        noBuscar = True

        txNumPedido.Text = ""
        txPedidoAx.Text = ""
        ckVerTodos.Checked = False
        ckParcial.Checked = True
        ckPendiente.Checked = True
        ckProduccion.Checked = True
        ckPreparado.Checked = True
        ckProducido.Checked = False
        ckIndustrial.Checked = False
        ckServido.Checked = False
        cbClientes.SelectedIndex = -1

        noBuscar = False

        If tRefresco.Interval = 0 Then

            llenarLvproduccion()

        Else

            refresco()

        End If

    End Sub

#End Region

#Region "SQL"

    Public Function articulosAcabadosDomesticos2(ByVal numPedido As String) As Integer

        Dim con As New SqlConnection(sconexion)
        Dim cont As Integer = 0

        Try

            Dim sql As String = "select COUNT(*) from conceptospedidos DOC
left join Articulos art on art.idArticulo = doc.idArticulo
left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
LEFT join SubTiposArticulo st on st.idSubTipoArticulo = art.idSubTipoArticulo
left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
where numPedido = " & numPedido & " and CP.idProduccion is not null and EP.numSerie <> 0 
and ep.EtiquetaFinalImpresa = 1 and (doc.domesticos2 = 1 OR art.domesticos2 = 1) and ta.TipoArticulo = 'DOMESTICO' "

            cmd = New SqlCommand(sql, con)

            con.Open()

            cont = cmd.ExecuteScalar

            con.Close()

            Return cont

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return 0

        End Try

    End Function

    Public Function articulosAcabadosDomesticos(ByVal numPedido As String) As Integer

        Dim con As New SqlConnection(sconexion)
        Dim cont As Integer = 0

        Try

            Dim sql As String = "select COUNT(*) from conceptospedidos DOC
left join Articulos art on art.idArticulo = doc.idArticulo
left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
LEFT join SubTiposArticulo st on st.idSubTipoArticulo = art.idSubTipoArticulo
left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
where numPedido = " & numPedido & " and CP.idProduccion is not null and EP.numSerie <> 0 and ep.EtiquetaFinalImpresa = 1 
and (doc.domesticos2 = 0 or doc.domesticos2 is null) and (art.domesticos2 = 0 or art.domesticos2 is null) and ta.TipoArticulo = 'DOMESTICO'  "
            cmd = New SqlCommand(sql, con)

            con.Open()

            cont = cmd.ExecuteScalar

            con.Close()

            Return cont

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return 0

        End Try

    End Function

    Public Function articulosAcabadosCelulas(ByVal numPedido As String) As Integer

        Dim con As New SqlConnection(sconexion)

        Dim cont As Integer = 0

        Try

            Dim sql As String = "select  count(*)
from ConceptosPedidos as C 
left join ConceptosProduccion CP on CP.idConceptoPedido = c.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion 
left join Articulos as AR2 on AR2.idArticulo = cp.idArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where (AR2.Articulo like 'CELULA%' or STA.SubTipoArticulo = 'EQUIPO') and C.numPedido = " & numPedido & " and ep.EtiquetaFinalImpresa = 1"

            cmd = New SqlCommand(sql, con)

            con.Open()

            cont = cmd.ExecuteScalar

            con.Close()

            Return cont

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return cont

        End Try

    End Function

    Public Function articulosAcabadosIndustrial(ByVal numPedido As String) As Integer

        Dim con As New SqlConnection(sconexion)
        Dim cont As Integer = 0

        Try

            Dim sql As String = "select count(*)
from ConceptosPedidos as C 
 left join ConceptosProduccion CP on CP.idConceptoPedido = c.idConcepto 
 left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion 
 left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
 left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
 left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
 where AR2.Articulo not like 'CELULA%' 
 and C.numPedido = " & numPedido & " and TA.TipoArticulo = 'INDUSTRIAL' 
 and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
 and (AR2.recambio = 0 or AR2.recambio is null) and ep.EtiquetaFinalImpresa = 1 "
            cmd = New SqlCommand(sql, con)

            con.Open()

            cont = cmd.ExecuteScalar

            con.Close()

            Return cont
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)

            Return cont
        End Try
    End Function

    Public Function articulosAcabadosEnLineaConcepto(ByVal idConcepto As String) As Integer
        Dim con As New SqlConnection(sconexion)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim cont As Integer = 0

        Try

            Dim sql As String = "select (case when  doc.domesticos2 = 1  or art.domesticos2 = 1 then 'DOMESTICO2' ELSE ta.TipoArticulo end ) AS TipoArticulo ,ep.numSerie, ep.etiquetaImpresa, ep.EtiquetaFinalImpresa, ep.fechaPicking from conceptospedidos DOC
left join Articulos art on art.idArticulo = doc.idArticulo
left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
where CP.idProduccion is not null and EP.numSerie <> 0 and (ep.EtiquetaFinalImpresa = 1 or ep.fechaPicking is not null) and doc.idConcepto = " & idConcepto
            da = New SqlDataAdapter(sql, con)

            con.Open()

            da.Fill(dt)

            con.Close()

            cont = dt.Rows.Count

            Return cont
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)

            Return cont
        End Try
    End Function

    'Busqueda pedidos en produccion.
    Public Function mostrarPedidosEnProd(ByVal orden As String) As List(Of DatosPedidosProd)

        Dim filtroNumPedido As String = ""

        Dim sVertodos As String

        Dim sTipos As String

        If ckIndustrial.Checked Then

            sTipos = " And "
            sTipos = sTipos & "(select sum(C.Cantidad )from ConceptosPedidos As C "
            sTipos = sTipos & "left join Articulos As AR2 On AR2.idArticulo = C.idArticulo left join TiposArticulo As TA On TA.idTipoArticulo = AR2.idTipoArticulo "
            sTipos = sTipos & "left join SubTiposArticulo As STA On STA.idSubTipoArticulo = AR2.idSubTipoArticulo "
            sTipos = sTipos & "where AR2.Articulo Not Like 'CELULA%' and C.numPedido = PE.numPedido and TA.TipoArticulo = 'INDUSTRIAL' and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') "
            sTipos = sTipos & "and (AR2.recambio = 0 or AR2.recambio is null) ) > 0 "

        Else

            sTipos = " "

        End If

        sVertodos = comprobarCheckEstados()

        If IsNumeric(txNumPedido.Text) Then

            filtroNumPedido = " and PE.numpedido =" & txNumPedido.Text

        End If

        If txPedidoAx.Text <> String.Empty Then

            filtroNumPedido = " and PE.referenciaCliente = '" & txPedidoAx.Text & "'"

        End If


        If Trim(cbClientes.Text) <> "" Then

            If cbClientes.SelectedIndex <> -1 Then

                filtroNumPedido = " and PE.idcliente = " & cbClientes.SelectedValue

            Else

                filtroNumPedido = " and CLI.nombreComercial like '" & cbClientes.Text & "%'"

            End If

        End If

        Try
            Dim lista As New List(Of DatosPedidosProd)
            Dim sel As String = "select PE.referenciaCliente, PE.numPedido as 'PID', PE.RoturaStock , PE.FechaEntrega as 'F.PREVISTA', PE.fechaProduccion as 'F.PRODUCCION', PE.Fecha as 'F.PEDIDO', CLI.NombreComercial as 'CLIENTE', 
 SUM (CP.Cantidad ) As 'QTY' , case when PE.Notas = '' then 0 else 1 end as 'NOTA', PE.Prioridad as 'PRIORIDAD'
 , (select Estado from Estados where idEstado = PE.idEstado) as 'ESTADO' , (select sum(C.Cantidad )from ConceptosPedidos as C 
 left join Articulos as AR2 on AR2.idArticulo = C.idArticulo left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo
 where(AR2.Articulo Like 'CELULA%' or STA.SubTipoArticulo = 'EQUIPO') and C.numPedido = PE.numPedido) as 'CELULAS' 
 , (select sum(C.Cantidad )from ConceptosPedidos as C left join Articulos as AR2 on AR2.idArticulo = C.idArticulo left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo Not Like 'CELULA%' and C.numPedido = PE.numPedido and TA.TipoArticulo = 'DOMESTICO'  and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
and (AR2.recambio = 0 or AR2.recambio is null) and (c.domesticos2=0 or c.domesticos2 is null)) as 'DOMESTICO' , (select sum(C.Cantidad ) from ConceptosPedidos as C 
Left Join Articulos as AR2 on AR2.idArticulo = C.idArticulo left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
Left Join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo Not Like 'CELULA%' and C.numPedido = PE.numPedido and TA.TipoArticulo = 'DOMESTICO'  and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
and (AR2.recambio = 0 or AR2.recambio is null) and C.domesticos2 = 1) as 'DOMESTICOS2' , (select sum(C.Cantidad )from ConceptosPedidos as C 
left join Articulos as AR2 on AR2.idArticulo = C.idArticulo left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where AR2.Articulo not like 'CELULA%' and C.numPedido = PE.numPedido and TA.TipoArticulo = 'INDUSTRIAL' and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
and (AR2.recambio = 0 or AR2.recambio is null) ) as 'INDUSTRIAL' 
, case when (select COUNT(*) from ConceptosPedidos  as CP left join ConceptosProformas as CPF on CPF.idConcepto = CP.idConceptoProforma 
where CP.numpedido = PE.numpedido and ((select COUNT(*) from Reparaciones as REP where REP.numPedido = PE.numpedido) > 0 or 
(Select COUNT(*) From conceptosPedidos 
left join ConceptosProformas on conceptosProformas.idConcepto = ConceptosPedidos.idConceptoProforma
where ConceptosPedidos.numPedido = PE.numpedido and (select COUNT(*) from Reparaciones where Reparaciones.numProforma  = ConceptosProformas.numProforma ) > 0 ) > 0)) = 0 then 0 else 1 end as 'REPARACION'
, (select sum(C.Cantidad )from ConceptosPedidos as C left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
where AR2.Articulo not like 'CELULA%' and C.numPedido = PE.numPedido and AR2.recambio = 1) as 'RECAMBIOS' , 
(select count(*)
from ConceptosPedidos as C 
 left join ConceptosProduccion CP on CP.idConceptoPedido = c.idConcepto 
 left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion 
 left join Articulos as AR2 on AR2.idArticulo = C.idArticulo 
 left join TiposArticulo as TA on TA.idTipoArticulo = AR2.idTipoArticulo 
 left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
 where AR2.Articulo not like 'CELULA%' 
 and C.numPedido = PE.numpedido  and TA.TipoArticulo = 'INDUSTRIAL' 
 and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA') 
 and (AR2.recambio = 0 or AR2.recambio is null) and fechaPicking is not null and (STA.SubTipoArticulo  = 'EQUIPO' or STA.SubTipoArticulo  = 'CAJA')) INDUSTRIALES_ACABADOS,
 (select  count(*)
from ConceptosPedidos as C 
left join ConceptosProduccion CP on CP.idConceptoPedido = c.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion 
left join Articulos as AR2 on AR2.idArticulo = cp.idArticulo 
left join SubTiposArticulo as STA on STA.idSubTipoArticulo = AR2.idSubTipoArticulo 
where (AR2.Articulo like 'CELULA%' or STA.SubTipoArticulo = 'EQUIPO') and C.numPedido =PE.numpedido and fechaPicking is not null) CELULAS_ACABADAS,
(select COUNT(*) from conceptospedidos DOC
left join Articulos art on art.idArticulo = doc.idArticulo
left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
LEFT join SubTiposArticulo st on st.idSubTipoArticulo = art.idSubTipoArticulo
left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
where numPedido =PE.numpedido and CP.idProduccion is not null and EP.numSerie <> 0 and fechaPicking is not null 
and (doc.domesticos2 = 0 or doc.domesticos2 is null) and (art.domesticos2 = 0 or art.domesticos2 is null) and ta.TipoArticulo = 'DOMESTICO' and (ST.SubTipoArticulo  = 'EQUIPO' or ST.SubTipoArticulo  = 'CAJA')) DOMESTICOS_ACABADOS,
(select COUNT(*) from conceptospedidos DOC
left join Articulos art on art.idArticulo = doc.idArticulo
left join TiposArticulo ta on ta.idTipoArticulo = art.idTipoArticulo
LEFT join SubTiposArticulo st on st.idSubTipoArticulo = art.idSubTipoArticulo
left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
where numPedido = PE.numpedido and CP.idProduccion is not null and EP.numSerie <> 0 
and fechaPicking is not null and (doc.domesticos2 = 1 OR art.domesticos2 = 1) and ta.TipoArticulo = 'DOMESTICO' and (ST.SubTipoArticulo  = 'EQUIPO' or ST.SubTipoArticulo  = 'CAJA')) DOMESTICOS2_ACABADOS,FECHAVOLCADO
from pedidos as PE 
Left Join ConceptosPedidos as CP on CP.numPedido = PE.numPedido 
LEFT JOIN Clientes as CLI on CLI.idCliente = PE.idCliente 
where " & sVertodos & " PE.Banulado = 0 " & filtroNumPedido & sTipos & " And (select COUNT(*) from ConceptosPedidos as CP2
left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo 
left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo 
 where CP2.numPedido = PE.numpedido and (ART2.codArticulo = 'REPARACION' or ART2.codArticulo is null)) < (select COUNT(*) from 
ConceptosPedidos as CP2 left join Articulos as ART2 on ART2.idarticulo = CP2.idArticulo   left join TiposArticulo as TA2 on TA2.idTipoArticulo  = ART2.idTipoArticulo  
where CP2.numPedido = PE.numpedido )
group by PE.numPedido, PE.FechaEntrega, PE.Fecha, CLI.NombreComercial, PE.Notas, PE.Prioridad, PE.idEstado, PE.fechaProduccion, PE.RoturaStock, PE.referenciaCliente,PE.FECHAVOLCADO 
order by " & orden
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosPedidosProd
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("PID") Is DBNull.Value Then

                    ElseIf linea("fechavolcado") Is DBNull.Value Then
                        linea("fechavolcado") = DBNull.Value
                        dts = cargarLinea(linea)
                        lista.Add(dts)
                    Else
                        dts = cargarLinea(linea)
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

    'Mostrar clientes.
    Public Function cargarClientes() As DataTable
        Try
            Dim sel As String = "Select idcliente, nombrecomercial from clientes order by nombrecomercial asc"
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                con.Close()
                Return Nothing
            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return Nothing

        End Try

    End Function

    'Cargar datos de pedidos.
    Public Function cargarLinea(ByVal linea As DataRow) As DatosPedidosProd

        Dim dts As New DatosPedidosProd

        dts.gcantidad = If(linea("QTY") Is DBNull.Value, 0, linea("QTY"))
        dts.gcantidadCelulas = If(linea("CELULAS") Is DBNull.Value, 0, linea("CELULAS"))
        dts.gcliente = If(linea("CLIENTE") Is DBNull.Value, 0, linea("CLIENTE"))
        dts.gfecha = If(linea("F.PEDIDO") Is DBNull.Value, 0, linea("F.PEDIDO"))
        dts.gfechaEntrega = If(linea("F.PREVISTA") Is DBNull.Value, 0, linea("F.PREVISTA"))
        dts.gnumpedido = If(linea("PID") Is DBNull.Value, 0, linea("PID"))
        dts.gNotaImpresa = If(linea("NOTA") = 0, " ", "SI")
        dts.gPrioridad = If(linea("PRIORIDAD") Is DBNull.Value, " ", linea("PRIORIDAD"))
        dts.gEstado = If(linea("ESTADO") Is DBNull.Value, " ", linea("ESTADO"))
        dts.gDomestico = If(linea("DOMESTICO") Is DBNull.Value, 0, linea("DOMESTICO"))
        dts.gIndustrial = If(linea("INDUSTRIAL") Is DBNull.Value, 0, linea("INDUSTRIAL"))
        dts.gRecambios = If(linea("RECAMBIOS") Is DBNull.Value, 0, linea("RECAMBIOS"))
        dts.gReparacion = linea("REPARACION")
        dts.gFechaProduccion = linea("F.PRODUCCION")
        dts.gRoturaStock = If(linea("roturaStock") Is DBNull.Value, False, linea("roturaStock"))
        dts.gPedidoAX = If(linea("ReferenciaCliente") Is DBNull.Value, " ", linea("ReferenciaCliente"))
        dts.gDomesticos2 = If(linea("DOMESTICOS2") Is DBNull.Value, 0, linea("DOMESTICOS2"))

        dts.gDomesticosAcabados = If(linea("DOMESTICOS_ACABADOS") Is DBNull.Value, 0, linea("DOMESTICOS_ACABADOS"))
        dts.gDomesticos2Acabados = If(linea("DOMESTICOS2_ACABADOS") Is DBNull.Value, 0, linea("DOMESTICOS2_ACABADOS"))
        dts.gIndustrialesAcabados = If(linea("INDUSTRIALES_ACABADOS") Is DBNull.Value, 0, linea("INDUSTRIALES_ACABADOS"))
        dts.gCelulasAcabadas = If(linea("CELULAS_ACABADAS") Is DBNull.Value, 0, linea("CELULAS_ACABADAS"))
        dts.gFechaVolcado = If(linea("FECHAVOLCADO") Is DBNull.Value, "", linea("FECHAVOLCADO"))
        Return dts

    End Function

    'Ver nota de pedido.
    Public Function verNota(ByVal numpedido As String) As String

        Try
            Dim nota As String
            Dim sel As String = "select notas from pedidos where numpedido= " & numpedido
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            con.Open()
            nota = cmd.ExecuteScalar()
            con.Close()
            Return nota

        Catch ex As Exception

            MsgBox(ex.Message)

            Return ""

        End Try

    End Function

    'Ver estado de pedido.
    Public Function VerEstado(ByVal numpedido As String) As String

        Try

            Dim nota As String

            Dim sel As String = "select ES.Estado from pedidos as PE left join Estados as ES on ES.idestado = PE.idestado where PE.numpedido= " & numpedido

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand(sel, con)

            con.Open()

            nota = cmd.ExecuteScalar()

            con.Close()

            Return nota

        Catch ex As Exception

            MsgBox(ex.Message)

            Return ""

        End Try

    End Function

    'Actualizar la prioridad.
    Public Function ActualizarPrioridad(ByVal numpedido As String, ByVal prioridad As Integer) As Boolean

        Try
            Dim sel As String = "update pedidos set prioridad = " & prioridad & " where numpedido= " & numpedido

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Actualizar el estado.
    Public Function ActualizarEstado(ByVal numpedido As String, ByVal estado As String) As Boolean

        Try

            Dim sel As String = "update pedidos set idestado = (select idestado from estados where estado = '" & estado & "' and aplicacion = 'pedido') where numpedido= " & numpedido

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

#End Region

    Public Sub EsRoturaStock(ByVal st As String)

        For Each item In lvproduccion.SelectedItems

            Dim i As Integer

            With item

                If st = "NO" Then

                    i = 0

                    If .subItems(12).Text = "PRODUCIDO" Then

                        .ForeColor = Color.Green

                    Else

                        Select Case .subItems(11).Text

                            Case 1

                                .ForeColor = Color.Red

                            Case 2

                                .ForeColor = Color.Black

                        End Select

                    End If

                    If .subItems(8).Text = "SI" Then

                        .ForeColor = Color.Blue

                    End If

                Else

                    i = 1

                    .ForeColor = Color.Orange

                End If

            End With

            Dim sel As String = "update pedidos set roturaStock = " & i & "  where numpedido= " & item.Text

            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

        Next

    End Sub

#Region "EVENTOS"

    'Doble click en listview carga los conceptos de pedido.
    Private Sub lvproduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvproduccion.DoubleClick

        For Each item In lvproduccion.SelectedItems

            Dim gg As New GestionPedidoVistaSimple

            gg.pnumPedido = FormatNumber(item.Text, 0)

            gg.ShowDialog()

            Dim estado As String = VerEstado(item.Text)

            If estado = "PREPARADO" Then

                item.SubItems(12).Text = "PRODUCCIÓN"

            Else

                item.SubItems(12).Text = estado

            End If

        Next

    End Sub

    'Menu contextual 
    Private Sub lvProduccion_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvproduccion.MouseDown

        'boton derecho del raton.
        If e.Button = Windows.Forms.MouseButtons.Right Then

            checksMenu()

            If lvproduccion.GetItemAt(e.X, e.Y) IsNot Nothing Then

                lvproduccion.GetItemAt(e.X, e.Y).Selected = True

                ContextMenuStrip1.Show(lvproduccion, New Point(e.X, e.Y))

            End If

        End If

        'boton izquierdo del raton.
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim info As ListViewHitTestInfo = lvproduccion.HitTest(e.X, e.Y)

            If Not IsNothing(info.SubItem) Then

                If info.SubItem.Text() = "SI" Then

                    MsgBox(verNota(info.Item.Text()), MsgBoxStyle.Information, "NOTA P:" & info.Item.Text())

                ElseIf info.SubItem.Text() = "PDF" Then

                    Dim ggPDF As New InformePedido

                    ggPDF.GeneraPDFSimple(info.Item.Text())
                    ggPDF.Show()

                End If

            End If

        End If

    End Sub

    'Menu contextual prioridad 
    Private Sub PRIORIDADToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click, ToolStripMenuItem3.Click, ToolStripMenuItem4.Click

        For Each item In lvproduccion.SelectedItems

            If item.SubItems(9).text <> sender.ToString Then

                ActualizarPrioridad(item.text, sender.ToString)

                If tRefresco.Interval = 0 Then

                    llenarLvproduccion()

                Else

                    refresco()

                End If

            End If

        Next

    End Sub

    Private Sub ckVerTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckVerTodos.CheckedChanged

        If ckVerTodos.Checked Then

            ckParcial.Checked = True

            ckPendiente.Checked = True

            ckPreparado.Checked = True

            ckProduccion.Checked = True

            ckProducido.Checked = True

            ckServido.Checked = True

            ckParcial.Enabled = False

            ckPendiente.Enabled = False

            ckPreparado.Enabled = False

            ckProduccion.Enabled = False

            ckProducido.Enabled = False

            ckServido.Enabled = False

            If tRefresco.Interval = 0 Then

                llenarLvproduccion()

            Else

                refresco()

            End If

        Else

            ckParcial.Enabled = True

            ckPendiente.Enabled = True

            ckPreparado.Enabled = True

            ckProduccion.Enabled = True

            ckServido.Checked = False

            ckProducido.Checked = False

            ckProducido.Enabled = True

            ckServido.Enabled = True

        End If

    End Sub

    'timer de refresco lv
    Private Sub tRefresco_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tRefresco.Tick

        refresco()

    End Sub

    'Incremento de conteo.
    Private Sub tconteo_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tConteo.Tick

        If pbActualizacion.Value = pbActualizacion.Maximum Then

            pbActualizacion.Value = 0

        Else

            pbActualizacion.Value = pbActualizacion.Value + 1

        End If

    End Sub

    'Menu contextual tamaño fuente.
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click, ToolStripMenuItem6.Click, ToolStripMenuItem7.Click

        Select Case sender.ToString

            Case "100%"

                fuente = New System.Drawing.Font("Century Gothic", 10)

                cambiarFuente()

            Case "150%"

                fuente = New System.Drawing.Font("Century Gothic", 12)

                cambiarFuente()

            Case "200%"

                fuente = New System.Drawing.Font("Century Gothic", 14)

                cambiarFuente()

        End Select

    End Sub

    'Menu contextual actualizar.
    Private Sub NoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoToolStripMenuItem.Click, ToolStripMenuItem8.Click, ToolStripMenuItem9.Click,
    ToolStripMenuItem10.Click

        Select Case sender.ToString

            Case "No"

                tConteo.Stop()

                tRefresco.Stop()

                pbActualizacion.Visible = False

                tRefresco.Interval = 1

                pbActualizacion.Value = 0

            Case "1min"

                pbActualizacion.Visible = True

                pbActualizacion.Value = 0

                pbActualizacion.Maximum = 59

                tRefresco.Interval = 60000

                tConteo.Start()

                tRefresco.Start()

            Case "5min"

                pbActualizacion.Visible = True

                pbActualizacion.Value = 0

                pbActualizacion.Maximum = 299

                tRefresco.Interval = 300000

                tConteo.Start()

                tRefresco.Start()

            Case "10min"

                pbActualizacion.Visible = True

                pbActualizacion.Value = 0

                pbActualizacion.Maximum = 599

                tRefresco.Interval = 600000

                tConteo.Start()

                tRefresco.Start()

        End Select

    End Sub

    Private Sub txNumPedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txNumPedido.KeyDown, Me.KeyDown, cbClientes.KeyDown, txPedidoAx.KeyDown

        If e.KeyCode = Keys.Enter Then

            refresco()

        End If

    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    Private Sub ckboxes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckParcial.CheckedChanged, ckPendiente.CheckedChanged, ckPreparado.CheckedChanged, ckProduccion.CheckedChanged, ckProducido.CheckedChanged, ckServido.CheckedChanged

        If ckVerTodos.Checked Or noBuscar Then

        Else

            If tRefresco.Interval = 0 Then

                llenarLvproduccion()

            Else

                refresco()

            End If

        End If

    End Sub

    Private Sub ckIndustrial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckIndustrial.CheckedChanged

        If noBuscar Then

        Else

            If tRefresco.Interval = 0 Then

                llenarLvproduccion()

            Else

                refresco()

            End If

        End If

    End Sub

    Private Sub CambiarFechaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarFechaToolStripMenuItem.Click

        cambiarFP()

    End Sub

    Private Sub CambiarFechaProducciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarFechaProducciónToolStripMenuItem.Click

        cambiarFPRO()

    End Sub

    Private Sub cbClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClientes.TextChanged

        refresco()

    End Sub

    Private Sub SIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SIToolStripMenuItem.Click

        EsRoturaStock(sender.Text)

    End Sub

    Private Sub NOToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NOToolStripMenuItem1.Click

        EsRoturaStock(sender.Text)

    End Sub

#End Region

    'SOLO ADMON
    Private Sub PARCIALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARCIALToolStripMenuItem.Click, SERVIDOToolStripMenuItem.Click, PRODUCCIONToolStripMenuItem.Click, PRODUCIDOToolStripMenuItem.Click, PENDIENTEToolStripMenuItem.Click, PREPARADOToolStripMenuItem.Click, SERVIDOToolStripMenuItem.Click

        For Each item In lvproduccion.SelectedItems

            ActualizarEstado(item.Text, sender.ToString)

            If tRefresco.Interval = 0 Then

                llenarLvproduccion()

            Else

                refresco()

            End If

        Next

    End Sub

    Private Sub LINEAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LINEAToolStripMenuItem.Click, RecambiosToolStripMenuItem.Click, IndustrialToolStripMenuItem.Click, DOMÉSTICO2ToolStripMenuItem.Click

        Dim funcCB As New funcionesCodigosBarras

        For Each item In lvproduccion.SelectedItems


            Dim sLinea As String = funcCB.EnLinea(item.Text, sender.Text)

            sender.text = funcCB.TextoSinAcentos(sender.text)

            Dim list As New List(Of String)

            list = funcCB.buscarLinea(item.text)

            If list.Contains(sender.text.toUpper()) Then

                MsgBox("El pedido ya está asignado a la linea " & sender.text, MsgBoxStyle.Information)

            Else


                If sLinea <> "" Then

                    funcCB.prepararPedido(item.Text, sender.text)

                Else

                    MsgBox("El pedido ya está asignado")

                End If

            End If

        Next

    End Sub

    Private Sub VerNúmeroDeSerieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerNúmeroDeSerieToolStripMenuItem.Click

        Try

            Dim funcCB As New funcionesCodigosBarras

            Dim numeroPedido As Integer = lvproduccion.SelectedItems.Item(0).Text

            Dim resultado As String = funcCB.mostrarNumerosSerie(numeroPedido)

            If resultado <> "" Then

                Dim gg As New mostrarNumeroSerie

                gg.txtNumerosSerie.Text = resultado

                gg.Text = "NÚMEROS DE SERIE DEL PEDIDO " & numeroPedido

                gg.ShowDialog()

                'Dim ruta As String

                'Dim osd As New SaveFileDialog

                'osd.Filter = "txt | *.txt"

                'osd.FileName = "Numeros de serie pedido " & lvproduccion.SelectedItems.Item(0).Text

                'If osd.ShowDialog() = DialogResult.OK Then

                '    If osd.FileName <> "" Then

                '        ruta = osd.FileName

                '        osd.Dispose()

                '        Dim txt As StreamWriter

                '        txt = File.CreateText(ruta)

                '        txt.Write(resultado)

                '        txt.Flush()

                '        txt.Close()

                '        Process.Start(ruta)

                '    End If

                'End If

            Else

                MsgBox("Este pedido no contiene números de serie.", MsgBoxStyle.Information)

            End If

        Catch ex As Exception

            MsgBox("No se puedo exportar el archivo de números de serie, contacte con el administador de la aplicación.", MsgBoxStyle.Information)

        End Try

    End Sub

    Private Sub ListadoPedidosAXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoPedidosAXToolStripMenuItem.Click

        Dim gg As New textListadoPedidosAX

        gg.txListado.Text = textoPedidosAx

        gg.ShowDialog()

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        Dim funcCP As New FuncionesConceptosPedidos

        Dim lista As New ListView

        For Each item In lvproduccion.Items

            funcCP.conceptosPedidosDesglose(lista, item.text, Replace(item.Subitems(15).text, "'", "''"), item.Subitems(1).text, item.Subitems(14).text, Replace(item.Subitems(3).text, "'", "''"))

        Next

        crearExcel(lista)

    End Sub

    Public Sub crearExcel(ByVal lista As ListView)

        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer

            objExcel = New Excel.Application

            bkWorkBook = objExcel.Workbooks.Add

            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)

            For i = 0 To lista.Columns.Count - 1

                'shWorkSheet.Cells(3, i + 1) = lista.Columns(i).Text

                shWorkSheet.Cells(1, i + 1).Value = lista.Columns(i).Text

            Next

            For i = 1 To lista.Items.Count

                For j = 0 To lista.Columns.Count - 1

                    Try

                        shWorkSheet.Cells(i + 1, j + 1).Value = lista.Items(i - 1).SubItems(j).Text

                    Catch ex As Exception

                        MsgBox(ex.Message)

                    End Try

                Next

            Next

            Dim sd As New SaveFileDialog

            sd.Filter = "XLSX | *.xlsx"

            Dim guardado As Boolean

            If sd.ShowDialog = DialogResult.OK Then

                shWorkSheet.SaveAs(sd.FileName)

                guardado = True

            End If

            bkWorkBook.Close(False)

            If guardado Then

                Process.Start(sd.FileName)

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub


End Class