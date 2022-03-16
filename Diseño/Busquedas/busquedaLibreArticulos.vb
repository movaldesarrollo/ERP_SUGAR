Imports System.Data.SqlClient
Imports System.Data.Sql
Imports Excel = Microsoft.Office.Interop.Excel
Imports office = Microsoft.Office.Core
Imports System.Reflection
Imports System
Imports System.IO
Imports System.Text

'Busqueda libre de artículos es un formulario que permite buscar en los conceptos de los documentos (pedidos, facturas y albaranes) 
'los articulos (cantidad, importe, num documento, id articulo, cliente, código articulo).
'Tambien permite exportar a excel los datos reflejados en el listview (seleccionados, expandidos, todo).
Public Class busquedalibreArticulos

#Region "VARIABLES"
    Dim sBusqueda As String     'Cadena de busqueda SQL
    Dim sOrden As String    'Orden de busqueda del SQL
    Dim funcBLA As New BusquedaLibreArticulosFunciones  'Funciones de busqueda libre articulos
    Dim desktopSize As Size     'Ajuste de pantalla.
    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.
    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.
    Dim indice As Integer   'Se utiliza para cargar el indice del item seleccionado o actual.
    Dim lineasBorradas As Boolean
    Dim contador As Integer = 1
#End Region

#Region "CARGA Y CIERRE"

    Private Sub busquedalibreArticulos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        borrarTemporales()
    End Sub

    'Carga del formulario.
    Private Sub busquedalibreArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Ajustar la altura del form a la pantalla.
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)
        'Limpiar
        Limpiar(Me)
    End Sub
#End Region

#Region "BOTONES"
    'Salir del formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub
    'Listado del formulario.
    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        If lineasBorradas Then
            MsgBox("Se han borrado lineas manualmente, esto no tendrá efecto en el listado.", MsgBoxStyle.Information)
        End If
        listado()
    End Sub
    'Limpiar formulario.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Limpiar(Me)
    End Sub
    'Buscar.
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click
        If cbTipoDoc.SelectedIndex = -1 Then
            MsgBox("Es necesario seleccionar el tipo de documento.", MsgBoxStyle.Information)
            cbTipoDoc.Focus()
        Else
            buscar()
        End If
    End Sub
#End Region

#Region "EVENTOS"
    'Cambio de fechas en datetimepickers.
    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        controlFechas()
    End Sub
    'Si el check está activo permite seleccionar los items del listview.
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckActivarSeleccion.CheckedChanged
        lvBusquedaArticulo.CheckBoxes = ckActivarSeleccion.CheckState
    End Sub
    'Orden de listview
    Private Sub ListView1_ColumnClick(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
            Handles lvBusquedaArticulo.ColumnClick
        If lvBusquedaArticulo.Items.Count <> 0 Then
            'Si columna actual es igual a la última columna seleccionada. Formatea la variable con el orden de búsqueda anterio. 
            If e.Column = numColumna Then
                lvBusquedaArticulo.Sorting = colOrder
            End If
            ' Crear una instancia de la clase que realizará la comparación
            Dim oCompare As New ListViewColumnSort()
            ' Asignar el orden de clasificación
            If lvBusquedaArticulo.Sorting = Windows.Forms.SortOrder.Ascending Then
                oCompare.Sorting = Windows.Forms.SortOrder.Descending
            Else
                oCompare.Sorting = Windows.Forms.SortOrder.Ascending
            End If
            lvBusquedaArticulo.Sorting = oCompare.Sorting
            ' La columna en la que se ha pulsado
            oCompare.ColumnIndex = e.Column
            ' El tipo de datos de la columna en la que se ha pulsado
            Select Case e.Column
                Case 1
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 2
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 3
                    'oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 4
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 5
                    'oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 6
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 7
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
            End Select
            'Elimina los items expandidos.
            ReordenarExpandidos(True, False)
            ' Asignar la clase que implementa IComparer
            ' y que se usará para realizar la comparación de cada elemento
            If e.Column = 0 Or e.Column = 3 Or e.Column = 5 Then
                lvBusquedaArticulo.Sorting = Windows.Forms.SortOrder.None
            Else
                lvBusquedaArticulo.ListViewItemSorter = oCompare
                numColumna = e.Column
                colOrder = oCompare.Sorting
            End If
            'Vuelve a insertar los items expandidos.
            ReordenarExpandidos(False, True)
        End If
    End Sub
    'Al cambiar el valor del combobox
    Private Sub cbTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoDoc.SelectedIndexChanged, ckParcial.CheckedChanged, _
    ckPreparado.CheckedChanged, ckProduccion.CheckedChanged, ckProducido.CheckedChanged, ckProduccion.CheckedChanged, ckServido.CheckedChanged, ckPendiente.CheckedChanged
        'limpia los resultados de la busqueda anterior.
        lvBusquedaArticulo.Items.Clear() 'Limpia los items.
        'Limpia los totalizadores
        txTotalCantidad.Text = ""
        txTotalEncontrados.Text = ""
        txTotalImporte.Text = ""
        'Dependiendo del tipo de documento, cambia el texto de la columna documento.
        Select Case cbTipoDoc.Text
            Case "ALBARANES"
                lvBusquedaArticulo.Columns(3).Text = "Nº ALBARÁN"
                gbCheckbox.Enabled = False
            Case "FACTURAS"
                lvBusquedaArticulo.Columns(3).Text = "Nº FACTURA"
                gbCheckbox.Enabled = False
            Case "PEDIDOS"
                lvBusquedaArticulo.Columns(3).Text = "Nº PEDIDO"
                gbCheckbox.Enabled = True
        End Select
        buscar()
    End Sub
    'Al hacer click con el mouse en el listview.
    Private Sub listView1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lvBusquedaArticulo.MouseClick
        'Si se hace click en la posición del "+" se expande ese item.
        If e.Location.X > lvBusquedaArticulo.Location.X - 10 And e.Location.X < lvBusquedaArticulo.Location.X Then
            expandir()
        Else
            'Si se hace click en el botón derecho aparece el menú contextual
            If lvBusquedaArticulo.Items.Count > 0 Then
                If e.Button = MouseButtons.Right Then
                    If lvBusquedaArticulo.FocusedItem.Bounds.Contains(e.Location) = True Then
                        ContextMenuStrip1.Show(Cursor.Position)
                    End If
                End If
            End If
        End If
    End Sub
    'Al hacer click en expandido.
    Private Sub ExpandidoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandidoToolStripMenuItem.Click
        ExportarExpandido()
    End Sub
    'Al hacer click en  todo.
    Private Sub TodoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TodoToolStripMenuItem.Click
        ExportarTodo()
    End Sub
    'Al hacer click en selección.
    Private Sub SeleccionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SeleccionToolStripMenuItem.Click
        ExportarSeleccion()
    End Sub
    'Borrar lineas seleccionadas
    Private Sub BorraLineasSeleccionadasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorraLineasSeleccionadasToolStripMenuItem.Click
        borrarLineas()
    End Sub
    'Al pulsar teclas de dirección izq (contrae) y der (expande).
    Private Sub lvBusquedaArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvBusquedaArticulo.KeyDown
        If e.KeyCode = Keys.Right Then
            expandir(1)
        ElseIf e.KeyCode = Keys.Left Then
            expandir(2)
        End If
    End Sub
    'Al hacer doble click en el list view
    Private Sub lvBusquedaArticulo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBusquedaArticulo.DoubleClick
        If ckActivarSeleccion.Checked = False Then
            With lvBusquedaArticulo
                indice = .SelectedIndices(0)
                If .SelectedItems.Count = 1 Then
                    If Trim(.Items(indice).SubItems(3).Text) <> "" Then
                        Select Case cbTipoDoc.Text
                            Case "ALBARANES"
                                Dim GG As New GestionAlbaran
                                GG.pnumAlbaran = .Items(indice).SubItems(3).Text
                                GG.Show()
                            Case "FACTURAS"
                                Dim GG As New GestionFactura
                                GG.pnumFactura = .Items(indice).SubItems(3).Text
                                GG.Show()
                            Case "PEDIDOS"
                                Dim GG As New GestionPedido
                                GG.pnumPedido = .Items(indice).SubItems(3).Text
                                GG.Show()
                        End Select
                    Else
                        expandir()
                    End If
                End If
            End With
        End If
    End Sub
#End Region

#Region "FUNCIONES Y METODOS"
    'Control de fechas evita que la fecha desde sea mayo que la de hasta.
    Public Sub controlFechas()
        'Si el dtpdesde es mayor que el dtphasta, cambia el valor de dtphasta al de dtpdesde.
        If dtpDesde.Value > dtpHasta.Value Then
            dtpHasta.Value = dtpDesde.Value
        End If
    End Sub
    'Limpiar 
    Public Sub Limpiar(ByVal c1 As Control)
        'Limpiar controles.
        For Each c As Control In c1.Controls
            If TypeOf c Is TextBox Then
                c.Text = "" ' eliminar el texto
            Else
                Limpiar(c)
            End If
            If TypeOf c Is ComboBox Then
                c.Text = "" ' eliminar el texto
            Else
                Limpiar(c)
            End If
            If (TypeOf (c) Is CheckBox) Then
                CType(c, CheckBox).Checked = False
            Else
                Limpiar(c)
            End If
            If TypeOf c Is DateTimePicker Then
                c.Text = Date.Today ' eliminar el texto
            Else
                Limpiar(c)
            End If
        Next
        cbTipoDoc.SelectedIndex = -1
        dtpDesde.Value = DateSerial(Year(Date.Today), 1, 1) ' formatea el valor de fecha al primer día del año.
        dtpHasta.Value = Date.Today 'formatea el valor de fecha al día de hoy.
        lvBusquedaArticulo.Items.Clear() 'Limpia los items del listview.
        lineasBorradas = False
        cbTipoDoc.Focus()
    End Sub
    'Mostrar listados.
    Public Sub listado()
        'Muestra el listado de los articulos del listview.
        If lvBusquedaArticulo.Items.Count > 0 Then
            Dim GG As New InformeListadoBusquedaLibreArticulos
            GG.verInforme(funcBLA.retornoDoc(cbTipoDoc.Text), sBusqueda)
            GG.ShowDialog()
        End If
    End Sub
    'Búsqueda.
    Public Sub buscar()
        lvBusquedaArticulo.Sorting = Windows.Forms.SortOrder.None 'Desactiva el orden de columna del listview.
        'Dependiendo del item seleccionado en el combobox realiza una busqueda por cada item.
        Select Case cbTipoDoc.Text
            Case "ALBARANES"
                BusquedaLibreAlbaranes()
            Case "FACTURAS"
                BusquedaLibreFacturas()
            Case "PEDIDOS"
                BusquedaLibrePedidos()
        End Select
        lineasBorradas = False
    End Sub
    'Función de búsqueda albaranes
    Public Sub BusquedaLibreAlbaranes()
        Try
            lvBusquedaArticulo.Items.Clear() 'Limpia los items del listview
            criterios() 'Formatea los criterios de busqueda.
            Dim sumaTotalCantidad As Integer = 0 'Variable para el totalizador de cantidad.
            Dim sumaTotalImporte As Double = 0 'Variable para el totalizador de importe.
            Dim totalArticulos As Integer = 0 'Variable para el totalizador de artículos encontrados.
            Dim lista As List(Of BusquedaLibreDatos) = funcBLA.BusquedaAlbaranes(sBusqueda, sOrden) 'Crea una lista con los resultados de la búsqueda.
            For Each dts As BusquedaLibreDatos In lista 'Recorremos la lista .
                With lvBusquedaArticulo.Items.Add("+")
                    .SubItems.Add(dts.gid)
                    .SubItems.Add(If(dts.gcodArticulo = "", " ", dts.gcodArticulo))
                    .SubItems.Add(" ")
                    .SubItems.Add(dts.garticulo)
                    .SubItems.Add(" ")
                    .SubItems.Add(FormatNumber(dts.gCantidad, 0))
                    .SubItems.Add(FormatNumber(dts.gImporte, 2))
                    sumaTotalCantidad = sumaTotalCantidad + dts.gCantidad
                    sumaTotalImporte = sumaTotalImporte + FormatNumber(dts.gImporte, 2)
                    totalArticulos = totalArticulos + 1
                End With
            Next
            txTotalCantidad.Text = FormatNumber(sumaTotalCantidad, 0)
            txTotalEncontrados.Text = FormatNumber(totalArticulos, 0)
            txTotalImporte.Text = FormatNumber(sumaTotalImporte, 2)
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR ALBARANES. " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Función de búsqueda Pedidos
    Public Sub BusquedaLibrePedidos()
        Try
            lvBusquedaArticulo.Items.Clear() 'Limpia los items del listview
            criterios() 'Formatea los criterios de busqueda.
            Dim sumaTotalCantidad As Integer = 0 'Variable para el totalizador de cantidad.
            Dim sumaTotalImporte As Double = 0 'Variable para el totalizador de importe.
            Dim totalArticulos As Integer = 0 'Variable para el totalizador de artículos encontrados.
            Dim lista As List(Of BusquedaLibreDatos) = funcBLA.BusquedaPedidos(sBusqueda, sOrden) 'Crea una lista con los resultados de la búsqueda.
            For Each dts As BusquedaLibreDatos In lista 'Recorremos la lista .
                With lvBusquedaArticulo.Items.Add("+")
                    .SubItems.Add(dts.gid)
                    .SubItems.Add(dts.gcodArticulo)
                    .SubItems.Add(" ")
                    .SubItems.Add(dts.garticulo)
                    .SubItems.Add(" ")
                    .SubItems.Add(FormatNumber(dts.gCantidad, 0))
                    .SubItems.Add(FormatNumber(dts.gImporte, 2))
                    sumaTotalCantidad = sumaTotalCantidad + dts.gCantidad
                    sumaTotalImporte = sumaTotalImporte + FormatNumber(dts.gImporte, 2)
                    totalArticulos = totalArticulos + 1
                End With
            Next
            txTotalCantidad.Text = FormatNumber(sumaTotalCantidad, 0)
            txTotalEncontrados.Text = FormatNumber(totalArticulos, 0)
            txTotalImporte.Text = FormatNumber(sumaTotalImporte, 2)
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR ALBARANES. " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Función de búsqueda Facturas
    Public Sub BusquedaLibreFacturas()
        Try
            lvBusquedaArticulo.Items.Clear() 'Limpia los items del listview
            criterios() 'Formatea los criterios de busqueda.
            Dim sumaTotalCantidad As Integer = 0 'Variable para el totalizador de cantidad.
            Dim sumaTotalImporte As Double = 0 'Variable para el totalizador de importe.
            Dim totalArticulos As Integer = 0 'Variable para el totalizador de artículos encontrados.
            Dim lista As List(Of BusquedaLibreDatos) = funcBLA.BusquedaFacturas(sBusqueda, sOrden) 'Crea una lista con los resultados de la búsqueda.
            For Each dts As BusquedaLibreDatos In lista 'Recorremos la lista .
                With lvBusquedaArticulo.Items.Add("+")
                    .SubItems.Add(dts.gid)
                    .SubItems.Add(dts.gcodArticulo)
                    .SubItems.Add(" ")
                    .SubItems.Add(dts.garticulo)
                    .SubItems.Add(" ")
                    .SubItems.Add(FormatNumber(dts.gCantidad, 0))
                    .SubItems.Add(FormatNumber(dts.gImporte, 2))
                    sumaTotalCantidad = sumaTotalCantidad + dts.gCantidad
                    sumaTotalImporte = sumaTotalImporte + FormatNumber(dts.gImporte, 2)
                    totalArticulos = totalArticulos + 1
                End With
            Next
            txTotalCantidad.Text = FormatNumber(sumaTotalCantidad, 0)
            txTotalEncontrados.Text = FormatNumber(totalArticulos, 0)
            txTotalImporte.Text = FormatNumber(sumaTotalImporte, 2)
        Catch ex As Exception
            MsgBox("ERROR AL BUSCAR ALBARANES. " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Repasa los campos del formulario y edita la cadena de busqueda.
    Public Sub criterios()
        'Llenamos la variable con los campo de código.
        Dim busquedaCodigo As String = If(txCodigo1.Text <> "", " ART.codArticulo like '%" & txCodigo1.Text & "%' and ", "")
        busquedaCodigo = busquedaCodigo & If(txCodigo2.Text <> "", " ART.codArticulo like '%" & txCodigo2.Text & "%' and ", "")
        busquedaCodigo = busquedaCodigo & If(txCodigo3.Text <> "", " ART.codArticulo like '%" & txCodigo3.Text & "%' and ", "")
        busquedaCodigo = busquedaCodigo & If(txCodigo1not.Text <> "", " ART.codArticulo not like '%" & txCodigo1not.Text & "%' and ", "")
        busquedaCodigo = busquedaCodigo & If(txCodigo2not.Text <> "", " ART.codArticulo not like '%" & txCodigo2not.Text & "%' and ", "")
        busquedaCodigo = busquedaCodigo & If(txCodigo3not.Text <> "", " ART.codArticulo not like '%" & txCodigo3not.Text & "%' and ", "")
        'Llenamos la variable con los campo de artículo.
        Dim busquedaArticulo As String = If(txArticulo1.Text <> "", " ART.articulo like '%" & txArticulo1.Text & "%' and ", "")
        busquedaArticulo = busquedaArticulo & If(txArticulo2.Text <> "", " ART.articulo like '%" & txArticulo2.Text & "%' and ", "")
        busquedaArticulo = busquedaArticulo & If(txArticulo3.Text <> "", " ART.articulo like '%" & txArticulo3.Text & "%' and ", "")
        busquedaArticulo = busquedaArticulo & If(txArticulo1not.Text <> "", " ART.articulo not like '%" & txArticulo1not.Text & "%' and ", "")
        busquedaArticulo = busquedaArticulo & If(txArticulo2not.Text <> "", " ART.articulo not like '%" & txArticulo2not.Text & "%' and ", "")
        busquedaArticulo = busquedaArticulo & If(txArticulo3not.Text <> "", " ART.articulo not like '%" & txArticulo3not.Text & "%' and ", "")
        'Llenamos la variable con los campo de ID.
        Dim busquedaID As String = If(txID.Text <> "", " ART.idArticulo = '" & txID.Text & "' and ", "")
        sBusqueda = " where " & busquedaCodigo & busquedaArticulo & busquedaID
        'sBusqueda = sBusqueda & " DOC.FechaEntrega >= '" & dtpDesde.Value.ToString("yyyy-MM-dd") & "' AND DOC.FechaEntrega <= '" & dtpHasta.Value.ToString("yyyy-MM-dd") & "'"

        If cbTipoDoc.Text = "PEDIDOS" Then
            sBusqueda = sBusqueda & " DOC.FechaProduccion >= '" & dtpDesde.Value.ToString("yyyy-MM-dd") & "' AND DOC.FechaProduccion <= '" & dtpHasta.Value.ToString("yyyy-MM-dd") & "'"
            Dim cadenaEstados As String = ""
            If ckProduccion.Checked = True Then
                cadenaEstados = " and ( DOC.idestado=21"
            End If
            If ckProducido.Checked = True Then
                If cadenaEstados = "" Then
                    cadenaEstados = " and ( DOC.idestado=62"
                Else
                    cadenaEstados = cadenaEstados & " or DOC.idestado=62"
                End If
            End If
            If ckParcial.Checked = True Then
                If cadenaEstados = "" Then
                    cadenaEstados = " and ( DOC.idestado=65"
                Else
                    cadenaEstados = cadenaEstados & " or DOC.idestado=65"
                End If
            End If
            If ckPreparado.Checked = True Then
                If cadenaEstados = "" Then
                    cadenaEstados = " and ( DOC.idestado=58"
                Else
                    cadenaEstados = cadenaEstados & " or DOC.idestado=58"
                End If
            End If

            If ckServido.Checked = True Then
                If cadenaEstados = "" Then
                    cadenaEstados = " and ( DOC.idestado=12"
                Else
                    cadenaEstados = cadenaEstados & " or DOC.idestado=12"
                End If
            End If

            If ckPendiente.Checked = True Then
                If cadenaEstados = "" Then
                    cadenaEstados = " and ( DOC.idestado=6"
                Else
                    cadenaEstados = cadenaEstados & " or DOC.idestado=6"
                End If
            End If
            If cadenaEstados <> "" Then
                sBusqueda = sBusqueda & cadenaEstados & " ) "
            End If
        Else
            sBusqueda = sBusqueda & " DOC.FechaEntrega >= '" & dtpDesde.Value.ToString("yyyy-MM-dd") & "' AND DOC.FechaEntrega <= '" & dtpHasta.Value.ToString("yyyy-MM-dd") & "'"
        End If
    End Sub
    'Al pulsar el intro dentro de un control se inicia la busqueda.
    Private Sub intro(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txArticulo1.KeyDown, txArticulo2.KeyDown, _
    txArticulo3.KeyDown, txCodigo1.KeyDown, txCodigo2.KeyDown, txCodigo3.KeyDown, txID.KeyDown, dtpDesde.KeyDown, dtpHasta.KeyDown, cbTipoDoc.KeyDown, dtpDesde.KeyDown, dtpHasta.KeyDown, _
    txCodigo1not.KeyDown, txCodigo2not.KeyDown, txCodigo3not.KeyDown, txArticulo1not.KeyDown, txArticulo2not.KeyDown, txArticulo3not.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpDesde.Value > dtpHasta.Value Then
                controlFechas()
            Else
                buscar()
            End If
        End If
    End Sub
    'Inserta los subItems del item seleccioado.
    Public Sub expandir(Optional ByVal estado As Integer = 0)
        'lvBusquedaArticulo.Sorting = Windows.Forms.SortOrder.None
        If ckActivarSeleccion.Checked = False Then
            With lvBusquedaArticulo
                If .SelectedItems.Count = 1 Then
                    indice = .SelectedIndices(0)
                    Dim idArticulo As Integer = .Items(indice).SubItems(1).Text
                    If .Items(indice).SubItems(0).Text = "+" Then
                        If estado = 0 Or estado = 1 Then
                            .Items(indice).SubItems(0).Text = "-"
                            .Items(indice).BackColor = Color.FromArgb(50, 153, 255)

                            Dim lista As New List(Of BusquedaDocsArticulosDatos)
                            criterios()
                            Select Case cbTipoDoc.Text
                                Case "ALBARANES"
                                    lista = funcBLA.BusquedaDocsAlbaranes(sBusqueda, idArticulo)
                                Case "FACTURAS"
                                    lista = funcBLA.BusquedaDocsFacturas(sBusqueda, idArticulo)
                                Case "PEDIDOS"
                                    lista = funcBLA.BusquedaDocsPedidos(sBusqueda, idArticulo)
                            End Select
                            For Each dts As BusquedaDocsArticulosDatos In lista
                                .Items.Insert(indice + 1, CrearItemDocs(dts))
                            Next
                        End If
                    ElseIf .Items(indice).SubItems(0).Text = "-" Then
                        If estado = 0 Or estado = 2 Then
                            .Items(indice).SubItems(0).Text = "+"
                            .Items(indice).BackColor = Color.White
                            For Each item As ListViewItem In .Items
                                If item.SubItems(1).Text = Format(idArticulo) And item.Text <> "+" Then
                                    .Items.Remove(item)
                                End If
                            Next
                        End If
                    End If
                End If
            End With
        End If
    End Sub
    'Reordena los items expandidos.
    Public Sub ReordenarExpandidos(ByVal antes As Boolean, ByVal despues As Boolean)
        Try
            'Antes True, elimina los items.
            If antes Then
                For Each item In lvBusquedaArticulo.Items
                    If Trim(item.Text) = "" Then
                        item.Remove()
                    End If
                Next
            End If
            Application.DoEvents()
            'Después True, inserta los items.
            If despues Then
                lvBusquedaArticulo.Sorting = Windows.Forms.SortOrder.None
                For Each item In lvBusquedaArticulo.Items
                    indice = item.index
                    If item.SubItems(0).Text = "-" Then
                        item.BackColor = Color.FromArgb(50, 153, 255)
                        Dim lista As New List(Of BusquedaDocsArticulosDatos)
                        criterios()
                        Select Case cbTipoDoc.Text
                            Case "ALBARANES"
                                lista = funcBLA.BusquedaDocsAlbaranes(sBusqueda, item.SubItems(1).Text)
                            Case "FACTURAS"
                                lista = funcBLA.BusquedaDocsFacturas(sBusqueda, item.SubItems(1).Text)
                            Case "PEDIDOS"
                                lista = funcBLA.BusquedaDocsPedidos(sBusqueda, item.SubItems(1).Text)
                        End Select
                        For Each dts As BusquedaDocsArticulosDatos In lista
                            lvBusquedaArticulo.Items.Insert(indice + 1, CrearItemDocs(dts))
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("FALLO AL INSERTAR" & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    'Nueva item Docs.
    Private Function CrearItemDocs(ByVal dts As BusquedaDocsArticulosDatos) As ListViewItem
        Dim item As New ListViewItem
        With item
            .BackColor = Color.Aqua
            .Text = " "
            .SubItems.Add(dts.gid)
            .SubItems.Add(" ")
            .SubItems.Add(dts.numDoc)
            .SubItems.Add(" ")
            .SubItems.Add(dts.cliente)
            .SubItems.Add(FormatNumber(dts.Cantidad, 0))
            .SubItems.Add(FormatNumber(dts.importe, 2))
        End With
        Return item
    End Function
    'Borrar lineas selecionadas
    Private Sub borrarLineas()
        With lvBusquedaArticulo
            For Each item In .SelectedItems
                For Each itemDoc In .Items
                    If itemDoc.Subitems(1).Text = item.Subitems(1).Text Then
                        itemDoc.Remove()
                    End If
                Next
                lineasBorradas = True
            Next
        End With
    End Sub
#End Region

#Region "EXPORTAR A EXCEL"

    Public Sub ExportarTodo()
        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim totalImporte As Double
            Dim totalCantidad As Integer
            Dim i As Integer
            Dim j As Integer
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Rows(1).Interior.Color = ColorTranslator.ToOle(Color.LightGray)
            shWorkSheet.Rows(1).Font.Color = ColorTranslator.ToOle(Color.Black)
            shWorkSheet.Range("A:A").ColumnWidth = 10
            shWorkSheet.Range("A1:G1").Font.Bold = True
            shWorkSheet.Range("A:A").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("B:B").ColumnWidth = 20
            shWorkSheet.Range("C:C").ColumnWidth = 20
            shWorkSheet.Range("C:C").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("D:D").ColumnWidth = 60
            shWorkSheet.Range("E:E").ColumnWidth = 60
            shWorkSheet.Range("F:F").ColumnWidth = 15
            shWorkSheet.Range("F:F").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            shWorkSheet.Range("G:G").ColumnWidth = 15
            shWorkSheet.Range("G:G").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            For i = 1 To lvBusquedaArticulo.Columns.Count - 1
                shWorkSheet.Cells(1, i) = lvBusquedaArticulo.Columns(i).Text
            Next
            For i = 1 To lvBusquedaArticulo.Items.Count
                If lvBusquedaArticulo.Items(i - 1).Text = "+" Then
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Interior.Color = ColorTranslator.ToOle(Color.White)
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Font.Color = ColorTranslator.ToOle(Color.Black)
                    totalCantidad = totalCantidad + lvBusquedaArticulo.Items(i - 1).SubItems(6).Text
                    totalImporte = totalImporte + lvBusquedaArticulo.Items(i - 1).SubItems(7).Text
                ElseIf lvBusquedaArticulo.Items(i - 1).Text = "-" Then
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(50, 153, 255))
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Font.Color = ColorTranslator.ToOle(Color.Black)
                    totalCantidad = totalCantidad + lvBusquedaArticulo.Items(i - 1).SubItems(6).Text
                    totalImporte = totalImporte + lvBusquedaArticulo.Items(i - 1).SubItems(7).Text
                ElseIf lvBusquedaArticulo.Items(i - 1).Text = " " Then
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(0, 255, 255))
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Font.Color = ColorTranslator.ToOle(Color.Black)
                Else
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Interior.Color = ColorTranslator.ToOle(Color.White)
                    shWorkSheet.Rows.Range("A" & i + 1 & ":G" & i + 1).Font.Color = ColorTranslator.ToOle(Color.Black)
                End If
                For j = 1 To lvBusquedaArticulo.Columns.Count - 1
                    'MsgBox(lvBusquedaArticulo.Items(i - 1).SubItems(j).Text)
                    shWorkSheet.Cells(i + 1, j).Value = lvBusquedaArticulo.Items(i - 1).SubItems(j).Text
                Next
            Next
            Dim selection As Excel.Range
            selection = objExcel.Range("A1:G1")
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("A2:G" & i)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThin
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("E" & i + 1 & ":G" & i + 1)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            shWorkSheet.Range("A" & i + 1 & ":G" & i + 1).Font.Bold = True
            shWorkSheet.Cells(i + 1, 5).Value = "TOTALES "
            shWorkSheet.Cells(i + 1, 6).Value = FormatNumber(totalCantidad, 0)
            shWorkSheet.Cells(i + 1, 7).Value = FormatNumber(totalImporte, 2)
            objExcel.UserControl = True
            bkWorkBook.SaveAs(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
            objExcel.Quit()
            Process.Start(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EXCEL" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub ExportarExpandido()
        Try

            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim totalImporte As Double
            Dim totalCantidad As Integer
            Dim i As Integer
            Dim j As Integer
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Rows(1).Interior.Color = ColorTranslator.ToOle(Color.LightGray)
            shWorkSheet.Rows(1).Font.Color = ColorTranslator.ToOle(Color.Black)
            shWorkSheet.Range("A:A").ColumnWidth = 10
            shWorkSheet.Range("A1:G1").Font.Bold = True
            shWorkSheet.Range("A:A").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("B:B").ColumnWidth = 20
            shWorkSheet.Range("C:C").ColumnWidth = 20
            shWorkSheet.Range("C:C").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("D:D").ColumnWidth = 60
            shWorkSheet.Range("E:E").ColumnWidth = 60
            shWorkSheet.Range("F:F").ColumnWidth = 15
            shWorkSheet.Range("F:F").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            shWorkSheet.Range("G:G").ColumnWidth = 15
            shWorkSheet.Range("G:G").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            For i = 1 To lvBusquedaArticulo.Columns.Count - 1
                shWorkSheet.Cells(1, i) = lvBusquedaArticulo.Columns(i).Text
            Next
            Dim ex As Integer = 1
            For i = 1 To lvBusquedaArticulo.Items.Count
                ex = ex + 1
                If ex = 0 Then
                    ex = 2
                End If
                If lvBusquedaArticulo.Items(i - 1).Text = "+" Then
                    ex = ex - 1
                ElseIf lvBusquedaArticulo.Items(i - 1).Text = "-" Then
                    shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(50, 153, 255))
                    shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Font.Color = ColorTranslator.ToOle(Color.Black)
                    totalCantidad = totalCantidad + lvBusquedaArticulo.Items(i - 1).SubItems(6).Text
                    totalImporte = totalImporte + lvBusquedaArticulo.Items(i - 1).SubItems(7).Text
                    For j = 1 To lvBusquedaArticulo.Columns.Count - 1
                        'MsgBox(lvBusquedaArticulo.Items(i - 1).SubItems(j).Text)
                        shWorkSheet.Cells(ex, j).Value = lvBusquedaArticulo.Items(i - 1).SubItems(j).Text
                    Next
                ElseIf lvBusquedaArticulo.Items(i - 1).Text = " " Then
                    shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(0, 255, 255))
                    shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Font.Color = ColorTranslator.ToOle(Color.Black)
                    For j = 1 To lvBusquedaArticulo.Columns.Count - 1
                        'MsgBox(lvBusquedaArticulo.Items(i - 1).SubItems(j).Text)
                        shWorkSheet.Cells(ex, j).Value = lvBusquedaArticulo.Items(i - 1).SubItems(j).Text
                    Next
                End If
            Next
            Dim selection As Excel.Range
            selection = objExcel.Range("A1:G1")
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("A2:G" & ex)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThin
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("E" & ex + 1 & ":G" & ex + 1)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            shWorkSheet.Range("A" & ex + 1 & ":G" & ex + 1).Font.Bold = True
            shWorkSheet.Cells(ex + 1, 5).Value = "TOTALES "
            shWorkSheet.Cells(ex + 1, 6).Value = FormatNumber(totalCantidad, 0)
            shWorkSheet.Cells(ex + 1, 7).Value = FormatNumber(totalImporte, 2)
            objExcel.UserControl = True
            bkWorkBook.SaveAs(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
            objExcel.Quit()
            Process.Start(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EXCEL" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub ExportarSeleccion()

        Try
            Dim totalImporte As Double
            Dim totalCantidad As Integer
            Dim i As Integer
            Dim j As Integer
            Dim objExcel As New Excel.Application()
            Dim bkWorkBook As Excel.Workbook = Nothing
            Dim shWorkSheet As Excel.Worksheet = Nothing
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Rows(1).Interior.Color = ColorTranslator.ToOle(Color.LightGray)
            shWorkSheet.Rows(1).Font.Color = ColorTranslator.ToOle(Color.Black)
            shWorkSheet.Range("A:A").ColumnWidth = 10
            shWorkSheet.Range("A1:G1").Font.Bold = True
            shWorkSheet.Range("A:A").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("B:B").ColumnWidth = 20
            shWorkSheet.Range("C:C").ColumnWidth = 20
            shWorkSheet.Range("C:C").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("D:D").ColumnWidth = 60
            shWorkSheet.Range("E:E").ColumnWidth = 60
            shWorkSheet.Range("F:F").ColumnWidth = 15
            shWorkSheet.Range("F:F").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            shWorkSheet.Range("G:G").ColumnWidth = 15
            shWorkSheet.Range("G:G").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            For i = 1 To lvBusquedaArticulo.Columns.Count - 1
                shWorkSheet.Cells(1, i) = lvBusquedaArticulo.Columns(i).Text
            Next
            Dim ex As Integer = 1
            For i = 1 To lvBusquedaArticulo.Items.Count
                ex = ex + 1
                If ex = 0 Then
                    ex = 2
                End If
                If lvBusquedaArticulo.Items(i - 1).Selected = True Then
                    If lvBusquedaArticulo.Items(i - 1).Text = "+" Then
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Interior.Color = ColorTranslator.ToOle(Color.White)
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Font.Color = ColorTranslator.ToOle(Color.Black)
                        totalCantidad = totalCantidad + lvBusquedaArticulo.Items(i - 1).SubItems(6).Text
                        totalImporte = totalImporte + lvBusquedaArticulo.Items(i - 1).SubItems(7).Text
                    ElseIf lvBusquedaArticulo.Items(i - 1).Text = "-" Then
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(50, 153, 255))
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Font.Color = ColorTranslator.ToOle(Color.Black)
                        totalCantidad = totalCantidad + lvBusquedaArticulo.Items(i - 1).SubItems(6).Text
                        totalImporte = totalImporte + lvBusquedaArticulo.Items(i - 1).SubItems(7).Text
                    ElseIf lvBusquedaArticulo.Items(i - 1).Text = " " Then
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(0, 255, 255))
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Font.Color = ColorTranslator.ToOle(Color.Black)
                    Else
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Interior.Color = ColorTranslator.ToOle(Color.White)
                        shWorkSheet.Rows.Range("A" & ex & ":G" & ex).Font.Color = ColorTranslator.ToOle(Color.Black)
                    End If
                    For j = 1 To lvBusquedaArticulo.Columns.Count - 1
                        shWorkSheet.Cells(ex, j).Value = lvBusquedaArticulo.Items(i - 1).SubItems(j).Text
                    Next
                Else
                    ex = ex - 1
                End If
            Next
            Dim selection As Excel.Range
            selection = objExcel.Range("A1:G1")
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("A2:G" & ex)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThin
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("E" & ex + 1 & ":G" & ex + 1)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            shWorkSheet.Range("A" & ex + 1 & ":G" & ex + 1).Font.Bold = True
            shWorkSheet.Cells(ex + 1, 5).Value = "TOTALES "
            shWorkSheet.Cells(ex + 1, 6).Value = FormatNumber(totalCantidad, 0)
            shWorkSheet.Cells(ex + 1, 7).Value = FormatNumber(totalImporte, 2)
            objExcel.UserControl = True
            bkWorkBook.SaveAs(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
            objExcel.Quit()
            Process.Start(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EXCEL" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region

    'borra los temporales creados de la exportación de los excel.
    Public Sub borrarTemporales()
        For Each fichero As String In Directory.GetFiles(Environ("UserProfile") & "\AppData\Local\Temp", "busquedaLibre_*")
            Try
                File.Delete(fichero)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub lvBusquedaArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBusquedaArticulo.SelectedIndexChanged

    End Sub
End Class
