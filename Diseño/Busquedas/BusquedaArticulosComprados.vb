'Este formulario nos muestra los articulos comprados y permite filtrar por algunos campos.
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System
Imports System.IO
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports office = Microsoft.Office.Core

Public Class BusquedaArticulosComprados

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
    'Carga load.
    Private Sub BusquedaArticulosComprados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dimensionando form
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 45
        Me.Location = New Point(Me.Location.X, 15)
        dtpDesde.Value = DateSerial(Now.Date.Year, 1, 1)
        dtpHasta.Value = Now
        cargaInicial = True
    End Sub

    'Carga despues del load.
    Private Sub BusquedaArticulosComprados_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Cursor = Cursors.WaitCursor
        llenarProveedores()
        llenarArticulosProv()
        llenarCodArticulo()
        llenarCodArticuloProv()
        llenarAños()
        llenarLvArticulos()
        cargaInicial = False
        cambioFechas = True
        Me.Cursor = Cursors.Default
    End Sub

    'Salir del form.
    Private Sub BusquedaArticulosComprados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        borrarTemporales()
    End Sub

    'Boton salir
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
                .SubItems.Add(dts.gNumpedido) '6
                .SubItems.Add(FormatNumber(dts.gPrecio, 2)) '6


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
        cambioFechas = True
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
            'where = where & " and   CP.idArticuloProv = (select idArticuloProv  from Articulos_Proveedor where nombre = '" & cbArticulo.Text & "' )"
            where = where & " and   CP.ArticuloProv = '" & cbArticulo.Text & "' "
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
            'sel = sel & "Select AR.idArticulo as 'ID ARTICULO', PRV.nombreComercial as 'PROVEEDOR', CP.codArticuloProv as 'CODIGO ARTICULO PROVEEDOR', "
            'sel = sel & " AR.codArticulo as 'CODIGO ARTICULO'  , CP.ArticuloProv as 'ARTICULO PROVEEDOR', sum(CP.cantidad) as 'CANTIDAD', count(PE.numPedido) as 'NUMERO PEDIDOS', (select top(1)AP.Precio from Articulos_Proveedor as AP where AP.idArticulo =AR.idArticulo and AP.idProveedor = PRV.idProveedor and AP.Activo =1 order by AP.FechaPrecio desc) as 'PRECIO'   from ConceptosPedidosProv as CP "
            'sel = sel & " left join PedidosProv as PE on PE.numPedido = CP.numPedido "
            'sel = sel & " left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor "
            'sel = sel & " left join Articulos as AR on AR.idArticulo = CP.idArticulo "
            'sel = sel & " where  CP.idArticulo <> 0  and PE.idEstado <> 53 " & where
            'sel = sel & " group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo, "
            'sel = sel & " PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PRV.idproveedor "
            sel = sel & "Select  case when ARP.idArticuloProv IS null then 0 else ARP.idArticuloProv end  as 'ID ARTICULO', PRV.nombreComercial as 'PROVEEDOR', CP.codArticuloProv as 'CODIGO ARTICULO PROVEEDOR', "
            sel = sel & " AR.codArticulo as 'CODIGO ARTICULO', CP.ArticuloProv as 'ARTICULO PROVEEDOR', sum(CP.cantidad) as 'CANTIDAD', count(PE.numPedido) as 'NUMERO PEDIDOS', "
            sel = sel & " case when ARP.idArticulo <> 783 then (select top(1)AP.Precio from Articulos_Proveedor as AP where AP.idArticuloProv  = ARP.idArticuloProv and AP.idProveedor = PRV.idProveedor and AP.Activo =1 "
            sel = sel & " order by AP.FechaPrecio desc) else (select top(1)PrecioNetoUnitario from ConceptosPedidosProv where ArticuloProv  = CP.ArticuloProv  order by numPedido desc) end as 'PRECIO'   "
            sel = sel & " from ConceptosPedidosProv as CP left join PedidosProv as PE on PE.numPedido = CP.numPedido left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  "
            sel = sel & " left join Articulos as AR on AR.idArticulo = CP.idArticulo left join Articulos_Proveedor  as ARP on ARP.idArticuloProv = CP.idArticuloProv  "
            sel = sel & " where CP.idArticulo <> 0  and PE.idEstado <> 53 " & where
            sel = sel & " group by ARP.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo, PRV.idproveedor, ARP.idArticuloProv "
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
            sel = "Select distinct PRV.nombreComercial as 'PROVEEDOR' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo "

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
            sel = "Select distinct CP.ArticuloProv as 'ARTICULO PROVEEDOR' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo "

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
            sel = "Select distinct AR.codArticulo as 'CODIGO ARTICULO' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo  "
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
            sel = "Select distinct CP.codArticuloProv as 'CODIGO ARTICULO PROVEEDOR' from ConceptosPedidosProv as CP  left join PedidosProv as PE on PE.numPedido = CP.numPedido  left join Proveedores as PRV on PRV.idProveedor = PE.idProveedor  left join Articulos as AR on AR.idArticulo = CP.idArticulo  where  CP.idArticulo <> 0 and PE.idEstado <> 53 " & proveedor & "  group by AR.idarticulo, CP.ArticuloProv , CP.idArticulo,  PRV.nombreComercial , CP.codArticuloProv, AR.codArticulo  "

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

    'Cargar datos articulos en lv.
    Public Function cargarLinea(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gIdArticulo = If(linea("ID ARTICULO") Is DBNull.Value, 0, linea("ID ARTICULO"))
        dts.gCantidad = If(linea("CANTIDAD") Is DBNull.Value, 0, linea("CANTIDAD"))
        dts.gArticuloProv = If(linea("ARTICULO PROVEEDOR") Is DBNull.Value, "", linea("ARTICULO PROVEEDOR"))
        dts.gCodArticuloProv = If(linea("CODIGO ARTICULO PROVEEDOR") Is DBNull.Value, "", linea("CODIGO ARTICULO PROVEEDOR"))
        dts.gproveedor = If(linea("PROVEEDOR") Is DBNull.Value, "", linea("PROVEEDOR"))
        dts.gCodArticulo = If(linea("CODIGO ARTICULO") Is DBNull.Value, "", linea("CODIGO ARTICULO"))
        dts.gNumpedido = If(linea("NUMERO PEDIDOS") Is DBNull.Value, "", linea("NUMERO PEDIDOS"))
        dts.gPrecio = If(linea("PRECIO") Is DBNull.Value, 0, linea("PRECIO"))

        Return dts

    End Function

    'Cargar datos proveedor en combobox.
    Public Function cargarLineaProveedor(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gproveedor = If(linea("PROVEEDOR") Is DBNull.Value, "", linea("PROVEEDOR"))
        Return dts

    End Function

    'Cargar datos articulo proveedor en combobox.
    Public Function cargarLineaArticuloProveedor(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gArticuloProv = If(linea("ARTICULO PROVEEDOR") Is DBNull.Value, "", linea("ARTICULO PROVEEDOR"))
        Return dts

    End Function

    'Cargar datos cod articulo en combobox.
    Public Function cargarLineaCodArticulo(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gCodArticulo = If(linea("CODIGO ARTICULO") Is DBNull.Value Or linea("CODIGO ARTICULO") = "", "SIN CÓDIGO", linea("CODIGO ARTICULO"))
        Return dts

    End Function

    'Cargar datos cod articulo proveedor en combobox.
    Public Function cargarLineaCodArticuloProv(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gCodArticuloProv = If(linea("CODIGO ARTICULO PROVEEDOR") Is DBNull.Value Or linea("CODIGO ARTICULO PROVEEDOR") = "", "SIN CÓDIGO", linea("CODIGO ARTICULO PROVEEDOR"))
        Return dts

    End Function

    'Cargar datos años en combobox.
    Public Function cargarLineaAños(ByVal linea As DataRow) As DatosArticulosComprados

        Dim dts As New DatosArticulosComprados
        dts.gAño = If(linea("AÑO") Is DBNull.Value, "", linea("AÑO"))
        Return dts

    End Function

    'Exporta el listview a un excel temporal.
    Public Function ExportarTodo() As Boolean
        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Range("A1:H1").Interior.Color = ColorTranslator.ToOle(Color.LightGray)
            shWorkSheet.Rows(1).Font.Color = ColorTranslator.ToOle(Color.Black)
            shWorkSheet.Range("A:A").ColumnWidth = 20
            shWorkSheet.Range("A1:H1").Font.Bold = True
            shWorkSheet.Range("A:A").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("B:B").ColumnWidth = 80
            shWorkSheet.Range("B:B").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("C:C").ColumnWidth = 25
            shWorkSheet.Range("C:C").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("D:D").ColumnWidth = 25
            shWorkSheet.Range("D:D").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("E:E").ColumnWidth = 80
            shWorkSheet.Range("E:E").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft
            shWorkSheet.Range("F:F").ColumnWidth = 15
            shWorkSheet.Range("F:F").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            shWorkSheet.Range("G:G").ColumnWidth = 15
            shWorkSheet.Range("G:G").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            shWorkSheet.Range("H:H").ColumnWidth = 15
            shWorkSheet.Range("H:H").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight
            For i = 0 To lvArticulos.Columns.Count - 1
                shWorkSheet.Cells(1, i + 1) = lvArticulos.Columns(i).Text
            Next
            For i = 0 To lvArticulos.Items.Count - 1
                shWorkSheet.Rows.Range("A" & i + 2 & ":H" & i + 2).Interior.Color = ColorTranslator.ToOle(Color.White)
                shWorkSheet.Rows.Range("A" & i + 2 & ":H" & i + 2).Font.Color = ColorTranslator.ToOle(Color.Black)
                For j = 0 To lvArticulos.Columns.Count - 1
                    shWorkSheet.Cells(i + 2, j + 1).Value = lvArticulos.Items(i).SubItems(j).Text
                Next
            Next
            Dim selection As Excel.Range
            selection = objExcel.Range("A1:H1")
            selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("A2:H" & i + 1)
            selection.Borders.Weight = Excel.XlBorderWeight.xlThin
            selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            selection = objExcel.Range("E" & i + 1 & ":H" & i + 1)
            'selection.Borders.Weight = Excel.XlBorderWeight.xlThick
            'selection.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            'shWorkSheet.Range("A" & i + 1 & ":G" & i + 1).Font.Bold = True
            'shWorkSheet.Cells(i + 1, 5).Value = "TOTALES "
            'shWorkSheet.Cells(i + 1, 6).Value = FormatNumber(totalCantidad, 0)
            'shWorkSheet.Cells(i + 1, 7).Value = FormatNumber(totalImporte, 2)
            objExcel.UserControl = True
            bkWorkBook.SaveAs(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
            objExcel.Quit()
            Process.Start(Environ("UserProfile") & "\AppData\Local\Temp\busquedaLibre_" & Format(Now, "dd-MM-yyy_H-mm-ss") & ".xlsx")
            Return True
        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EXCEL" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    'borra los temporales creados de la exportación de los excel.
    Public Sub borrarTemporales()
        For Each fichero As String In Directory.GetFiles(Environ("UserProfile") & "\AppData\Local\Temp", "busquedaLibre_*")
            Try
                File.Delete(fichero)
            Catch ex As Exception
            End Try
        Next
    End Sub

#End Region

#Region "BOTONES"

    'Boton limpiar
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    'Boton buscar
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        llenarLvArticulos()

    End Sub

    'Boton exportar
    Private Sub bExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bExportar.Click
        If lvArticulos.Items.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            ExportarTodo()
            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

#Region "EVENTOS"

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
                    Case 6
                        oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
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

    'Si la fecha introducida en desde es menos que la de hasta modifica la fecha hasta al valor de desde
    Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged, dtpHasta.ValueChanged
        cambioFechas = True
        If dtpDesde.Value > dtpHasta.Value Then
            dtpHasta.Value = dtpDesde.Value
        End If
    End Sub

    'Si se selecciona un año se desactiva el control de fechas.
    Private Sub cbAño_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAño.SelectedIndexChanged

        If sender.text = "" Then
            cambioFechas = True
        Else
            cambioFechas = False
        End If

    End Sub

    'Al seleccionar un proveedor se cargan los articulos de este en el combobox.
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

    'Al presionar la opcion ver pedidos en el menu contextual se muestran los pedidos donde aparece ese articulo. 
    'Si no tiene ID no pregunta si queremos mostrar todos los pedidos con esos parametros de busqueda.
    Private Sub VERPEDIDOSToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VERPEDIDOSToolStripMenuItem.Click
        If lvArticulos.Items.Count Then
            For Each item In lvArticulos.SelectedItems
                If item.text = 0 Then
                    If MsgBox("Este producto no estaba creado cuando se realizo el pedido y no tiene ID de Artículo válida. ¿Quiere ver los pedidos de todos modos?.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim gg As New BusquedaPedidoProveedor
                        gg.bFormArticulosComprados = True
                        gg.sProveedor = item.SubItems(1).Text
                        gg.sArticulo = ""
                        gg.sCodArticulo = ""
                        If cambioFechas Then
                            gg.bEntreFechas = True
                            gg.dFechaDesde = dtpDesde.Value
                            gg.dFechaHasta = dtpHasta.Value
                        Else
                            gg.bEntreFechas = False
                            gg.sAños = cbAño.Text
                            gg.dFechaDesde = Now
                            gg.dFechaHasta = Now
                        End If
                        gg.ShowDialog()
                    End If
                Else
                    Dim gg As New BusquedaPedidoProveedor
                    gg.bFormArticulosComprados = True
                    gg.sProveedor = item.SubItems(1).Text
                    gg.sArticulo = item.SubItems(4).Text
                    gg.sCodArticulo = item.subitems(2).Text
                    If cambioFechas Then
                        gg.bEntreFechas = True
                        gg.dFechaDesde = dtpDesde.Value
                        gg.dFechaHasta = dtpHasta.Value
                    Else
                        gg.bEntreFechas = False
                        gg.sAños = cbAño.Text
                        gg.dFechaDesde = Now
                        gg.dFechaHasta = Now
                    End If
                    gg.ShowDialog()

                End If
            Next
        End If
    End Sub

#End Region

End Class


