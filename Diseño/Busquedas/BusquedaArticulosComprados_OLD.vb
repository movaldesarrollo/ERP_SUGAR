'Este formulario nos muestra los articulos comprados y permite filtrar por algunos campos.
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class BusquedaArticulosComprados_old

#Region "VARIABLES"
    Dim conexiones As New conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = conexiones.CadenaConexion()
    Dim orden As String = " PRV.nombreComercial "
    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.
    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.
    Dim where As String
    Dim proveedor As String
    Dim cambioFechas As Boolean
    Dim cbArticulosFull As New ComboBox
    Dim cbCodArticulosFull As New ComboBox
    Dim cbCodArticulosProFull As New ComboBox
    Dim cbAñosFull As New ComboBox
    Dim cargaInicial As Boolean = True
#End Region

#Region "CARGA Y CIERRE"

    Private Sub BusquedaArticulosComprados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dimensionando form
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 45
        Me.Location = New Point(Me.Location.X, 15)
        dtpDesde.Value = DateSerial(Now.Date.Year, 1, 1)
        dtpHasta.Value = Now
        cambioFechas = False
        cargaInicial = True
    End Sub

    Private Sub BusquedaArticulosComprados_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        llenarProveedores()
        llenarArticulosProv()
        llenarCodArticulo()
        llenarCodArticuloProv()
        llenarAños()
        llenarLvArticulos()
        cargaInicial = False
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

#End Region

#Region "FUNCIONES Y METODOS"

    'Llenar combo proveedor.
    Public Sub llenarProveedores()
        lbCargando.Visible = True
        lbCargando.Text = "CARGANDO PROVEEDORES ..."
        Application.DoEvents()
        cbProveedor.Items.Clear()
        Dim lista As List(Of DatosArticulosComprados) = mostrarProveedores()
        For Each dts As DatosArticulosComprados In lista
            cbProveedor.Items.Add(dts.gproveedor)
        Next
        lbCargando.Visible = False
    End Sub

    'Llenar combo articulo prov
    Public Sub llenarArticulosProv()
        lbCargarArticulos.Visible = True
        lbCargarArticulos.Text = "CARGANDO ARTÍCULOS ..."
        Application.DoEvents()
        cbArticulo.Items.Clear()
        Dim lista As List(Of DatosArticulosComprados) = mostrarArticulosProveedor()
        For Each dts As DatosArticulosComprados In lista
            cbArticulo.Items.Add(dts.gArticuloProv)
            If cargaInicial Then
                cbArticulosFull.Items.Add(dts.gArticuloProv)
            End If
        Next
        lbCargarArticulos.Visible = False
    End Sub

    'Llenar combo codigo articulo
    Public Sub llenarCodArticulo()
        lbCargarCodArti.Visible = True
        lbCargarCodArti.Text = "CARGANDO CÓDIGOS ARTÍCULO ..."
        Application.DoEvents()
        cbCodArticulo.Items.Clear()
        Dim lista As List(Of DatosArticulosComprados) = mostrarCodigoArticulo()
        For Each dts As DatosArticulosComprados In lista
            cbCodArticulo.Items.Add(dts.gCodArticulo)
            If cargaInicial Then
                cbCodArticulosFull.Items.Add(dts.gCodArticulo)
            End If
        Next
        lbCargarCodArti.Visible = False
    End Sub

    'Llenar combo codigo articulo prov
    Public Sub llenarCodArticuloProv()
        lbCargarCodArtiProv.Visible = True
        lbCargarCodArtiProv.Text = "CARGANDO CÓDIGOS ART.PROV. ..."
        Application.DoEvents()
        cbCodArticuloPro.Items.Clear()
        Dim lista As List(Of DatosArticulosComprados) = mostrarCodigoArticuloProv()
        For Each dts As DatosArticulosComprados In lista
            cbCodArticuloPro.Items.Add(dts.gCodArticuloProv)
            If cargaInicial Then
                cbCodArticulosProFull.Items.Add(dts.gCodArticuloProv)
            End If
        Next
        lbCargarCodArtiProv.Visible = False
    End Sub

    'llenar años
    Public Sub llenarAños()
        cbAño.Items.Clear()
        Dim lista As List(Of DatosArticulosComprados) = mostrarAños()
        For Each dts As DatosArticulosComprados In lista
            cbAño.Items.Add(Format(dts.gAño))
            If cargaInicial Then
                cbAñosFull.Items.Add(dts.gAño)
                Application.DoEvents()
            End If
        Next
    End Sub

    'llenar lv articulos
    Public Sub llenarLvArticulos()

        Me.Cursor = Cursors.WaitCursor

        busqueda()

        Dim t As Integer = 0 'Articulos
        Dim c As Integer = 0 'Cantidad

        Contador.Text = ""
        lvArticulos.Sorting = Windows.Forms.SortOrder.None

        lvArticulos.Items.Clear()

        Dim lista As List(Of DatosArticulosComprados) = mostrarArticulos()

        For Each dts As DatosArticulosComprados In lista

            With lvArticulos.Items.Add(dts.gIdArticulo)

                .SubItems.Add(dts.gproveedor) '1
                .SubItems.Add(dts.gCodArticulo) '2
                .SubItems.Add(dts.gCodArticuloProv) '3
                .SubItems.Add(dts.gArticuloProv) '4
                .SubItems.Add(FormatNumber(dts.gCantidad, 2)) '5
                .SubItems.Add(Format(dts.gFecha, "dd-MM-yyyy")) '6
                .SubItems.Add(dts.gNumpedido) '7

            End With

            t = t + 1
            c = c + dts.gCantidad

        Next

        txCantidadTotal.Text = FormatNumber(c, 2)
        Contador.Text = Contador.Text & FormatNumber(t, 0)

        Me.Cursor = Cursors.Default

    End Sub

    'Limpiar
    Public Sub limpiar()

        Me.Cursor = Cursors.WaitCursor
        lbLimpiando.Visible = True
        proveedor = ""
        cbAño.Text = ""
        cbProveedor.Text = ""
        cbArticulo.Text = ""
        cbCodArticulo.Text = ""
        cbCodArticuloPro.Text = ""
        Application.DoEvents()

        dtpDesde.Value = DateSerial(Now.Date.Year, 1, 1)
        dtpHasta.Value = Now
        cambioFechas = False

        cbAño.Items.Clear()
        For Each item As String In cbAñosFull.Items
            cbAño.Items.Add(item)
            Application.DoEvents()
        Next

        cbCodArticulo.Items.Clear()
        For Each item As String In cbCodArticulosFull.Items
            cbCodArticulo.Items.Add(item)
            Application.DoEvents()
        Next

        cbArticulo.Items.Clear()
        For Each item As String In cbArticulosFull.Items
            cbArticulo.Items.Add(item)
            Application.DoEvents()
        Next

        cbCodArticuloPro.Items.Clear()
        For Each item As String In cbCodArticulosProFull.Items
            cbCodArticuloPro.Items.Add(item)
            Application.DoEvents()
        Next

        cbAño.SelectedIndex = -1
        cbProveedor.SelectedIndex = -1
        cbArticulo.SelectedIndex = -1
        cbCodArticulo.SelectedIndex = -1
        cbCodArticuloPro.SelectedIndex = -1
        lbLimpiando.Visible = False
        Application.DoEvents()

        llenarLvArticulos()

        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "SQL"

    Public Sub busqueda()

        where = ""
        'Si se ha seleccionado un proveedor en el combobox.
        If cbProveedor.SelectedIndex <> -1 Then
            where = " and PRV.nombreComercial = '" & Replace(cbProveedor.Text, "'", "' + char(39) + '") & "'"
        End If
        'Si se ha seleccionado un artículo en el combobox.
        If cbArticulo.SelectedIndex <> -1 Then
            where = where & " and  CP.ArticuloProv = '" & cbArticulo.Text & "'"
        End If
        'Si se ha seleccionado un código de articulo en el combobox.
        If cbCodArticulo.SelectedIndex <> -1 Then
            If cbCodArticulo.Text = "SIN CÓDIGO" Then
                where = where & " and (AR.codArticulo = '' or AR.codArticulo is null)"
            Else
                where = where & " and AR.codArticulo = '" & cbCodArticulo.Text & "'"
            End If
        End If
        'Si se ha seleccionado un código de articulo de proveedor en el combobox.
        If cbCodArticuloPro.SelectedIndex <> -1 Then
            If cbCodArticuloPro.Text = "SIN CÓDIGO" Then
                where = where & " and (CP.codArticuloProv = '' or  CP.codArticuloProv is null)"
            Else
                where = where & " and CP.codArticuloProv = '" & cbCodArticuloPro.Text & "'"
            End If

        End If

        If cambioFechas Then

            where = where & " and PE.fechapedido between '" & dtpDesde.Value & "' and  '" & dtpHasta.Value & "' "

        Else
            'Si se ha seleccionado un año en el combobox.
            If cbAño.SelectedIndex <> -1 Then
                where = where & " and year(PE.fechapedido) = '" & cbAño.Text & "'"
            End If

        End If


    End Sub
    'mostrar lista de articulos
    Public Function mostrarArticulos() As List(Of DatosArticulosComprados)

        Dim lista As New List(Of DatosArticulosComprados)

        Try
            Dim sel As String = ""
            sel = sel & "Select AR.idArticulo as 'ID ARTICULO', PRV.nombreComercial as 'PROVEEDOR', CP.codArticuloProv as 'CODIGO ARTICULO PROVEEDOR', "
            sel = sel & " AR.codArticulo as 'CODIGO ARTICULO'  , CP.ArticuloProv as 'ARTICULO PROVEEDOR', sum(CP.cantidad) as 'CANTIDAD', PE.FechaPedido as 'FECHA', CP.numPedido as 'NUMERO PEDIDO'  from ConceptosPedidosProv as CP "
            sel = sel & " left join PedidosProv as PE on PE.numPedido = CP.numPedido "
            sel = sel & " left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor "
            sel = sel & " left join Articulos as AR on AR.idArticulo = CP.idArticulo "
            sel = sel & " where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & where
            sel = sel & "  "
            sel = sel & " group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo, "
            sel = sel & " PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PE.FechaPedido, CP.numPedido "
            sel = sel & " order by " & orden
            '" 'YEAR(PE.FechaPedido)= 2017' &" and
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosArticulosComprados
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID ARTICULO") Is DBNull.Value Then
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

    'mostrar proveedores
    Public Function mostrarProveedores() As List(Of DatosArticulosComprados)

        Dim lista As New List(Of DatosArticulosComprados)

        Try
            Dim sel As String
            sel = "Select distinct PRV.nombreComercial as 'PROVEEDOR' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0     group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PE.FechaPedido "

            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosArticulosComprados
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("PROVEEDOR") Is DBNull.Value Then
                    Else
                        dts = cargarLineaProveedor(linea)
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

    'mostrar articulos prov
    Public Function mostrarArticulosProveedor() As List(Of DatosArticulosComprados)

        Dim lista As New List(Of DatosArticulosComprados)
        Try
            Dim sel As String
            sel = "Select distinct CP.ArticuloProv as 'ARTICULO PROVEEDOR' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PE.FechaPedido  "

            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosArticulosComprados
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ARTICULO PROVEEDOR") Is DBNull.Value Then
                    Else
                        dts = cargarLineaArticuloProveedor(linea)
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

    'mostrar codigo articulo
    Public Function mostrarCodigoArticulo() As List(Of DatosArticulosComprados)
        Dim lista As New List(Of DatosArticulosComprados)
        Try
            Dim sel As String
            sel = "Select distinct AR.codArticulo as 'CODIGO ARTICULO' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PE.FechaPedido  "
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosArticulosComprados
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("CODIGO ARTICULO") Is DBNull.Value Then
                    Else
                        dts = cargarLineaCodArticulo(linea)
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

    'mostrar codigo articulo prov
    Public Function mostrarCodigoArticuloProv() As List(Of DatosArticulosComprados)
        Dim lista As New List(Of DatosArticulosComprados)
        Try
            Dim sel As String
            sel = "Select distinct CP.codArticuloProv as 'CODIGO ARTICULO PROVEEDOR' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PE.FechaPedido  "

            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosArticulosComprados
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("CODIGO ARTICULO PROVEEDOR") Is DBNull.Value Then
                    Else
                        dts = cargarLineaCodArticuloProv(linea)
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

    'mostrar años
    Public Function mostrarAños() As List(Of DatosArticulosComprados)
        Dim lista As New List(Of DatosArticulosComprados)
        Try
            Dim sel As String
            sel = "Select distinct year(PE.FechaPedido) as 'AÑO'  from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PE.FechaPedido  "

            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosArticulosComprados
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("AÑO") Is DBNull.Value Then
                    Else
                        dts = cargarLineaAños(linea)
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

    'Cargar datos.
    Public Function cargarLinea(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gIdArticulo = If(linea("ID ARTICULO") Is DBNull.Value, 0, linea("ID ARTICULO"))
        dts.gCantidad = If(linea("CANTIDAD") Is DBNull.Value, 0, linea("CANTIDAD"))
        dts.gArticuloProv = If(linea("ARTICULO PROVEEDOR") Is DBNull.Value, "", linea("ARTICULO PROVEEDOR"))
        dts.gCodArticuloProv = If(linea("CODIGO ARTICULO PROVEEDOR") Is DBNull.Value, "", linea("CODIGO ARTICULO PROVEEDOR"))
        dts.gproveedor = If(linea("PROVEEDOR") Is DBNull.Value, "", linea("PROVEEDOR"))
        dts.gCodArticulo = If(linea("CODIGO ARTICULO") Is DBNull.Value, "", linea("CODIGO ARTICULO"))
        dts.gFecha = If(linea("FECHA") Is DBNull.Value, "", linea("FECHA"))
        dts.gNumpedido = If(linea("NUMERO PEDIDO") Is DBNull.Value, 0, linea("NUMERO PEDIDO"))

        Return dts

    End Function

    Public Function cargarLineaProveedor(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gproveedor = If(linea("PROVEEDOR") Is DBNull.Value, "", linea("PROVEEDOR"))
        Return dts

    End Function

    Public Function cargarLineaArticuloProveedor(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gArticuloProv = If(linea("ARTICULO PROVEEDOR") Is DBNull.Value, "", linea("ARTICULO PROVEEDOR"))
        Return dts

    End Function

    Public Function cargarLineaCodArticulo(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gCodArticulo = If(linea("CODIGO ARTICULO") Is DBNull.Value Or linea("CODIGO ARTICULO") = "", "SIN CÓDIGO", linea("CODIGO ARTICULO"))
        Return dts

    End Function

    Public Function cargarLineaCodArticuloProv(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gCodArticuloProv = If(linea("CODIGO ARTICULO PROVEEDOR") Is DBNull.Value Or linea("CODIGO ARTICULO PROVEEDOR") = "", "SIN CÓDIGO", linea("CODIGO ARTICULO PROVEEDOR"))
        Return dts

    End Function

    Public Function cargarLineaAños(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gAño = If(linea("AÑO") Is DBNull.Value, "", linea("AÑO"))
        Return dts

    End Function

#End Region

#Region "BOTONES"

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        llenarLvArticulos()

    End Sub

#End Region

#Region "EVENTOS"

    ''Al hacer clic en el item rellena los campos.
    Private Sub lvArticulos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvArticulos.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If lvArticulos.SelectedItems.Count > 0 Then
                For Each item In lvArticulos.SelectedItems
                    cbProveedor.Text = item.Subitems(1).text
                    If item.Subitems(2).text = "" Then
                        cbCodArticulo.Text = "SIN CÓDIGO"
                    Else
                        cbCodArticulo.Text = item.Subitems(2).text
                    End If
                    If item.Subitems(3).text = "" Then
                        cbCodArticuloPro.Text = "SIN CÓDIGO"
                    Else
                        cbCodArticuloPro.Text = item.Subitems(3).text
                    End If
                    cbArticulo.Text = item.Subitems(4).text
                Next
            End If
        End If

    End Sub

    'Orden de coolumna listview
    Private Sub ListView1_ColumnClick(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
            Handles lvArticulos.ColumnClick
        If lvArticulos.Items.Count <> 0 Then
            If e.Column = 13 Then
                lvArticulos.Sorting = Windows.Forms.SortOrder.None
            Else
                'Si columna actual es igual a la última columna seleccionada. Formatea la variable con el orden de búsqueda anterio. 
                If e.Column = numColumna Then
                    lvArticulos.Sorting = colOrder
                End If
                ' Crear una instancia de la clase que realizará la comparación
                Dim oCompare As New ListViewColumnSort()
                ' Asignar el orden de clasificación
                If lvArticulos.Sorting = Windows.Forms.SortOrder.Ascending Then
                    oCompare.Sorting = Windows.Forms.SortOrder.Descending
                Else
                    oCompare.Sorting = Windows.Forms.SortOrder.Ascending
                End If
                lvArticulos.Sorting = oCompare.Sorting
                ' La columna en la que se ha pulsado
                oCompare.ColumnIndex = e.Column
                ' El tipo de datos de la columna en la que se ha pulsado
                Select Case e.Column
                    Case 0
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 1
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 2
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 3
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 4
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                    Case 5
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                    Case 6
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
                End Select
                'Elimina los items expandidos.
                'ReordenarExpandidos(True, False)
                ' Asignar la clase que implementa IComparer
                ' y que se usará para realizar la comparación de cada elemento

                lvArticulos.ListViewItemSorter = oCompare
                numColumna = e.Column
                colOrder = oCompare.Sorting
            End If
            'Vuelve a insertar los items expandidos.
            'ReordenarExpandidos(False, True)
        End If
    End Sub

    'Presionar una tecla en los controles, si es enter efectua la busqueda.
    Private Sub cbProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbProveedor.KeyDown, _
    cbArticulo.KeyDown, cbCodArticulo.KeyDown, cbCodArticuloPro.KeyDown, cbProveedor.KeyDown, cbAño.KeyDown, dtpDesde.KeyDown, dtpHasta.KeyDown

        If e.KeyCode = Keys.Enter Then
            llenarLvArticulos()
        End If

    End Sub

    'Doble clic sobre un item del listview, muestra el pedido
    Private Sub lvArticulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvArticulos.DoubleClick
        If lvArticulos.SelectedItems.Count = 1 Then
            For Each item In lvArticulos.SelectedItems
                Dim gg As New GestionPedidoProveedor
                gg.numPedido.Text = item.SubItems(7).text
                gg.ShowDialog()
            Next


        End If
    End Sub

    Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
        cambioFechas = True
        If dtpDesde.Value > dtpHasta.Value Then
            dtpHasta.Value = dtpDesde.Value
        End If
    End Sub

    Private Sub cbAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAño.SelectedIndexChanged
        cambioFechas = False
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProveedor.SelectedIndexChanged
        If cbProveedor.SelectedIndex <> -1 Then
            proveedor = " and PRV.nombreComercial = '" & Replace(cbProveedor.Text, "'", "' + char(39) + '") & "' "
            llenarArticulosProv()
            llenarCodArticulo()
            llenarAños()
            llenarCodArticuloProv()
            cbAño.Text = ""
            cbArticulo.Text = ""
            cbCodArticulo.Text = ""
            cbCodArticuloPro.Text = ""
            cbAño.SelectedIndex = -1
            cbArticulo.SelectedIndex = -1
            cbCodArticulo.SelectedIndex = -1
            cbCodArticuloPro.SelectedIndex = -1
        Else
            proveedor = ""
        End If
    End Sub
#End Region

End Class