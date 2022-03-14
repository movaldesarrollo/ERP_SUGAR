Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO

Public Class gestionInventarios
    'Variables generales.
    Dim conexion As New conexion
    Dim cmd As SqlCommand
    Dim parametros As String
    Dim falloBusqueda As Boolean
    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.
    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.

    Dim difWidth As Double

    'Carga del formulario.
    Private Sub gestionInventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize

        difWidth = (Me.Width - 1455)

        Me.Height = desktopSize.Height - 45

        lvColArticulo.Width = lvColArticulo.Width + difWidth

        Me.Location = New Point(Me.Location.X, 15)

        lvArticulos.Columns(5).Width = 0

        Contador.Text = 0

        llenarComboxSecciones()

        cbSecciones.Text = "TODOS"

    End Sub

#Region "EVENTOS DE BOTONES"
    'BUSCAR---
    'Cuando pulsamos el boton llama al metodo buscar.
    Private Sub bBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBuscar.Click

        If bBuscar.Text = "BUSCAR" Then

            buscar()

        ElseIf bBuscar.Text = "VOLCAR" Then

            volcar()

        End If

    End Sub

    'Cuando presionamos enter al estar el foco encima del boton buscar se ejecuta el metodo buscar.
    Private Sub bBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles bBuscar.KeyDown, txArticulo.KeyDown _
, txCodigo.KeyDown, txIdArticulo.KeyDown

        If e.KeyCode = Keys.Enter Then

            buscar()

        End If

    End Sub

    'EXPORTAR
    Private Sub bExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bExportar.Click

        If lvArticulos.Items.Count > 0 Then

            Me.Cursor = Cursors.WaitCursor

            exportar()

        Else

            MsgBox("No hay datos que exportar.", MsgBoxStyle.Information)

        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Exportar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles bExportar.KeyDown

        If e.KeyCode = Keys.Enter Then

            exportar()

        End If

    End Sub

    'SALIR---
    'Cerrar formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    'IMPORTAR---
    Private Sub importarCSV(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImportar.Click

        fImportarCSV()

    End Sub

    Private Sub Importar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles bImportar.KeyDown

        If e.KeyCode = Keys.Enter Then

            fImportarCSV()

        End If

    End Sub

    Public Sub volcarDatos()

        If MsgBox("¿Desea volcar los datos en la base de datos?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            volcar()

        Else

            bBuscar.Text = "VOLCAR"

            bExportar.Enabled = False

            bImportar.Enabled = False

            GroupBox1.Enabled = False

        End If

    End Sub

    Public Sub volcar()

        Cargando.tipo = "VOLCANDO"
        Cargando.Show()
        Application.DoEvents()
        Cursor = Cursors.WaitCursor

        For Each item In lvArticulos.Items

            If IsNumeric(item.text) Then

                If item.Subitems(6).Text = "" Or Not IsNumeric(item.Subitems(6).Text) Then
                    item.Subitems(6).Text = item.Subitems(4).Text
                End If

                fVolcar(item.Text, item.Subitems(5).Text, item.Subitems(4).Text)

            End If

        Next

        Application.DoEvents()
        Cursor = Cursors.Default

        MsgBox("Volcado finalizado.", MsgBoxStyle.Information)

        limpiar()

    End Sub

    'Boton Limpiar
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        limpiar()

    End Sub

    'limpiar campos
    Public Sub limpiar()

        lvArticulos.Columns(5).Width = 0
        txArticulo.Text = ""
        txCodigo.Text = ""
        txIdArticulo.Text = ""
        cbSecciones.Text = "TODOS"
        rbTodos.Checked = True
        Contador.Text = 0
        lvArticulos.Items.Clear()
        bBuscar.Text = "BUSCAR"
        GroupBox1.Enabled = True
        bExportar.Enabled = True
        bImportar.Enabled = True
        txIdArticulo.Focus()

    End Sub

#End Region

#Region "METODOS"
    'Orden de columnas
    Private Sub lvArticulos_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
        Handles lvArticulos.ColumnClick

        If lvArticulos.Items.Count <> 0 Then
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
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 4
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 5
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 6
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 7
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 8
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 9
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero

            End Select
            lvArticulos.ListViewItemSorter = oCompare
            numColumna = e.Column
            colOrder = oCompare.Sorting
        End If

    End Sub

    'Ejecuta la busqueda.
    Public Sub buscar()

        lvArticulos.Sorting = Windows.Forms.SortOrder.None

        bBuscar.Text = "EN CURSO" 'Cambia el texto del boton.

        bBuscar.Enabled = False 'Desactiva el boton buscar.

        If parametrosBusqueda() Then

            llenarLv() 'Llama al metodo llenarLv.

        End If

        bBuscar.Text = "BUSCAR" 'Cambia el texto del boton.

        bBuscar.Enabled = True 'Activa el boton buscar.

    End Sub

    'Llenamos el listview de articulos.
    Public Sub llenarLv()

        lvArticulos.Items.Clear()

        Dim dTotal As Double

        Contador.Text = 0

        Dim lista As List(Of DatosInventario) = MostrarInventario()

        If falloBusqueda Then

            MsgBox("El proceso de busqueda ha fallado.", MsgBoxStyle.Critical)

            falloBusqueda = False

        Else

            Dim dts As DatosInventario

            For Each dts In lista

                With lvArticulos.Items.Add(dts.gidArticulo) '0
                    .SubItems.Add(dts.gcodArticulo) '1
                    .SubItems.Add(dts.gArticulo) '2
                    .SubItems.Add(FormatNumber(dts.gStock, 2)) '3
                    .SubItems.Add(dts.gUnidad) '4
                    .SubItems.Add(" ") '5
                    .SubItems.Add(dts.gSeccion) '6
                    .SubItems.Add(dts.gSuprimir) '7
                    .SubItems.Add(FormatNumber(dts.gPrecioActual, 2)) '8
                    .SubItems.Add(FormatNumber(dts.gPrecioActual * dts.gStock, 2)) '9

                    If dts.gSuprimir = "NO" Then
                        .ForeColor = Color.Gray
                    End If

                    dTotal = dTotal + (dts.gPrecioActual * dts.gStock)

                End With

            Next

            txTotalPrecio.Text = FormatNumber(dTotal, 2) & "€"
            Contador.Text = lvArticulos.Items.Count

        End If

    End Sub

    'Exportar CSV inventario.
    Public Sub exportar()

        Dim dlGuardar As New SaveFileDialog 'Abre la ventana de busqueda del archivo CSV 

        dlGuardar.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*" 'Filtra los archivos CSV
        dlGuardar.FilterIndex = 1
        dlGuardar.DefaultExt = "csv" 'Selecciona el tipo de extension.
        dlGuardar.FileName = "INVENTARIO_" & tituloArchivo() & Format(Now, "dd-mm-yyyy") 'Establece el nombre del archivo.
        dlGuardar.OverwritePrompt = True 'Preguntar si existe el archivo.
        dlGuardar.Title = "GUARDAR INVENTARIO " & tituloArchivo() & Format(Now, "dd-mm-yyyy") 'Titulo de la ventana de dialogo.
        If dlGuardar.ShowDialog = Windows.Forms.DialogResult.OK Then 'Si se ha seleccionado un archivo con el resultado OK.

            If exportarListViewCSV(lvArticulos, dlGuardar.FileName) Then 'Exportamos el archivo.

                MsgBox("Archivo exportado correctamente.", MsgBoxStyle.Information)

            Else

                MsgBox("ERROR AL EXPORTAR EL ARCHIVO.", MsgBoxStyle.Critical) 'Si ha surgido algun error.

            End If

        End If

    End Sub

    'Formato del titulo del archivo a exportar
    Public Function tituloArchivo() As String

        Dim titulo As String = ""

        Try

            If txArticulo.Text <> "" Then
                titulo = titulo & "_ART." & txArticulo.Text
            End If

            If txCodigo.Text <> "" Then
                titulo = titulo & "_COD." & txCodigo.Text
            End If

            If txIdArticulo.Text <> "" Then
                titulo = titulo & "_ID." & txIdArticulo.Text
            End If

            If rbTodos.Checked Then

                titulo = titulo & "_COMPRABLE Y VENDIBLE"

            ElseIf rbComprable.Checked Then

                titulo = titulo & "_COMPRABLE"

            ElseIf rbVendible.Checked Then

                titulo = titulo & "_VENDIBLE"

            End If

            Return titulo

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    'Importar CSV a listview.
    Sub importarCSV(ByVal ofd As OpenFileDialog)

        ofd.Filter = "CSV files (*.csv)|*.CSV"
        ofd.FilterIndex = 2
        ofd.RestoreDirectory = True
        ofd.Title = "SELECCIONAR ARCHIVO CSV A IMPORTAR"
        ofd.FileName = " "

        If ofd.ShowDialog = Windows.Forms.DialogResult.OK AndAlso ofd.FileName <> "" Then

            Try
                lvArticulos.Items.Clear()

                Using reader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ofd.FileName)

                    reader.TextFieldType = FileIO.FieldType.Delimited

                    reader.SetDelimiters(";")

                    While Not reader.EndOfData

                        Dim Fields() As String = reader.ReadFields

                        Dim item As New ListViewItem

                        item.Text = Fields(0)

                        For x = 1 To UBound(Fields)

                            item.SubItems.Add(Fields(x))

                        Next

                        If item.Text <> "" Then

                            lvArticulos.Items.Add(item)

                        Else

                        End If

                    End While

                    lvArticulos.Items(0).Remove()

                End Using

                lvArticulos.Columns(5).Width = 100

                Contador.Text = lvArticulos.Items.Count

                volcarDatos()

            Catch ex As Exception

                MsgBox("Archivo Inexistente.", MsgBoxStyle.Information, "CSV Inexistente")

            End Try

        End If

    End Sub

    'Llena el combobox de secciones
    Public Sub llenarComboxSecciones()

        Dim sconexion As String = conexion.CadenaConexion()
        Dim con As New SqlConnection(sconexion)
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "select * from secciones where activo=1 order by seccion asc"
            .Connection = con
        End With
        Da.SelectCommand = Cmd
        Dt = New DataTable
        Da.Fill(Dt)
        Dt.Rows.Add(99, "DESCONOCIDO") 'Añade un item para los que no tienen seccion
        Dt.Rows.Add(0, "TODOS") 'Añade un item para seleccionar todos los secciones
        With cbSecciones
            .DataSource = Dt
            .DisplayMember = "seccion"
            .ValueMember = "idseccion"
        End With
    End Sub

#End Region

#Region "FUNCIONES Y DATOS"
    'Busqueda en la base de datos.
    Public Function MostrarInventario() As List(Of DatosInventario)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = conexion.CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = "Select AR.idArticulo as 'ID', AR.codArticulo AS 'CÓDIGO', SEC.Seccion as 'SECCIÓN', case when SUM(STK.cantidad) IS null then 0 else SUM(STK.cantidad)"
            sel = sel & " end AS 'STOCK', AR.Articulo AS 'ARTÍCULO', UN.TipoUnidad as 'UNIDAD', case when (select top(1) Precio from Articulos_Precios "
            sel = sel & " where idArticulo = AR.idArticulo and Activo = 1  and TipoPrecio = 'C' order by FechaPrecio desc) "
            sel = sel & " IS null then 0 else (select top(1) Precio from Articulos_Precios  where idArticulo = AR.idArticulo and Activo = 1 and TipoPrecio = 'C' "
            sel = sel & " order by FechaPrecio desc) end as 'PRECIO_ACTUAL', AR.Activo as 'ACTIVO' from articulos as AR "
            sel = sel & " left join Stock as STK on STK.idArticulo = AR.idArticulo left join TiposUnidad  as UN on UN.idTipoUnidad = STK.idUnidad "
            sel = sel & " left join Secciones  as SEC on SEC.idSeccion = AR.idseccion where  " & parametros
            sel = sel & " group by AR.idArticulo,  SEC.Seccion, AR.codArticulo, AR.Articulo, UN.TipoUnidad, AR.Activo "
            sel = sel & " oRDER BY AR.Articulo ASC "

            'sel = "SELECT (select  Seccion from Secciones where idSeccion = articulos.idSeccion) as 'SECCIÓN' , articulos.idArticulo AS 'ID', codArticulo AS 'CÓDIGO', Articulo AS 'ARTÍCULO',"
            'sel = sel & "case when SUM(cantidad) IS null then 0 else SUM(cantidad) end AS 'STOCK' , UN.TipoUnidad as 'UNIDAD', articulos.Activo as 'ACTIVO' "
            'sel = sel & ", case when (select top(1) Precio from Articulos_Precios where idArticulo = Articulos .idArticulo and Activo = 1 "
            'sel = sel & " and TipoPrecio = 'C' order by FechaPrecio desc) IS null then 0 else (select top(1) Precio from Articulos_Precios "
            'sel = sel & " where idArticulo = Articulos .idArticulo and Activo = 1 and TipoPrecio = 'C' order by FechaPrecio desc) end as 'PRECIO_ACTUAL' "
            'sel = sel & " from Articulos  "
            'sel = sel & " left join Stock as STK on STK.idArticulo = articulos.idArticulo  left join TiposUnidad  as UN on UN.idTipoUnidad = STK.idUnidad "
            'sel = sel & " left join Articulos_Precios  as AP on AP.idArticulo = Articulos.idArticulo "
            'sel = sel & " where " & parametros
            'sel = sel & " group by articulo , articulos.idArticulo, codArticulo, UN.TipoUnidad, Articulos.idSeccion, articulos.Activo    "

            'sel = sel & " ORDER BY ARTÍCULO ASC "



            cmd = New SqlCommand(sel, con)
            con.Open()
            Cargando.tipo = "CARGANDO"
            Cargando.Show()
            Application.DoEvents()
            Cursor = Cursors.WaitCursor
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosInventario
                Dim lista As New List(Of DatosInventario)
                Dim linea As DataRow
                For Each linea In dt.Rows

                    If linea("ID") Is DBNull.Value Then

                    Else
                        dts = CargarLineaInventario(linea)

                        lista.Add(dts)

                    End If

                Next

                Cursor = Cursors.Default

                Cargando.fin = True

                Return lista

            Else
                con.Close()

                Cargando.fin = True

                Return Nothing

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Cursor = Cursors.Default

            Cargando.fin = True

            falloBusqueda = True

            Return Nothing

        Finally
            conexion.desconectado()
        End Try
    End Function

    'Cargar datos
    Private Function CargarLineaInventario(ByVal linea As DataRow) As DatosInventario

        Dim dts As New DatosInventario

        dts.gidArticulo = linea("ID")
        dts.gcodArticulo = If(linea("CÓDIGO") Is DBNull.Value, "", linea("CÓDIGO"))
        dts.gArticulo = Replace(Replace(Replace(If(linea("ARTÍCULO") Is DBNull.Value, "", linea("ARTÍCULO")), Chr(10), " "), Chr(13), " "), ";", "/") 'Elimina los saltos de linea.
        dts.gPrecioActual = If(linea("PRECIO_ACTUAL") Is DBNull.Value, 0, linea("PRECIO_ACTUAL"))
        dts.gStock = If(linea("STOCK") Is DBNull.Value, 0, linea("STOCK"))
        dts.gUnidad = If(linea("UNIDAD") Is DBNull.Value, "", linea("UNIDAD"))
        dts.gSuprimir = If(linea("ACTIVO") Is DBNull.Value Or linea("ACTIVO") = 0, "NO", "SI")
        dts.gSeccion = If(linea("SECCIÓN") Is DBNull.Value, "", linea("SECCIÓN"))

        Return dts

    End Function

    'Volcar datos
    Public Function fVolcar(ByVal idarticulo As Integer, ByVal cantidad As Double, ByVal unidad As String) As Boolean

        Dim cantidadInicial As Double  'Establecemos la variable de cantidad inicial
        'Creamos los parametros de conexion.
        Dim sconexion As String = conexion.CadenaConexion()
        Dim con As New SqlConnection(sconexion)
        'Creamos la variable de cadena de busqueda de la cantidad.
        'Iniciamos la busqueda.
        Try
            'Comprobamos que cantidad sea un numero.
            If IsNumeric(cantidad) Then

                Dim selCantidad As String

                'Creamos las variable de busqueda de unidad.
                Dim sUnidad As String = ""
                Dim sUnidadNull As String = ""

                'Si la unidad esta vacia.
                If unidad = "" Then

                    sUnidad = " NULL "
                    sUnidadNull = " (idUnidad is null or idUnidad = 0)"

                Else

                    sUnidad = "( select idTipoUnidad  from TiposUnidad  where TipoUnidad  = '" & unidad & "')"
                    sUnidadNull = " idUnidad =(select idTipoUnidad  from TiposUnidad  where TipoUnidad  = '" & unidad & "')"

                End If

                selCantidad = "Select sum(cantidad) from stock where idarticulo = " & idarticulo & "  and  " & sUnidadNull

                cmd = New SqlCommand(selCantidad, con)

                con.Open()

                Dim obj As Object = cmd.ExecuteScalar()

                If obj Is DBNull.Value Then

                    cantidadInicial = 0

                Else

                    cantidadInicial = obj.ToString

                End If

                con.Close()

                If cantidadInicial <> cantidad Then

                    Dim cCantidad As String = cantidad - cantidadInicial
                    cCantidad = cCantidad.Replace(",", ".")

                    Dim sel As String

                    sel = "INSERT INTO Stock (idArticulo , idAlmacen, Cantidad, idUnidad, idLote, idArticuloProv, idPersona1, Movimiento, Fecha, Precio, codMoneda) "
                    sel = sel & " VALUES (" & idarticulo & ",1, " & cCantidad & " ," & sUnidad & ", 0, 0," & Inicio.vIdUsuario & ", 'INVENTARIO', getdate(), '0', 'EU') "

                    cmd = New SqlCommand(sel, con)

                    con.Open()

                    cmd.ExecuteNonQuery()

                    con.Close()

                End If


            End If

            ''Si la seccion existe entonces
            'If seccion <> "" And existeSeccion(seccion) Then

            '    seccion = " idSeccion = (select SE.idseccion from secciones as SE  where SE.Seccion = '" & seccion & "') "

            'Else

            '    seccion = ""

            'End If

            'If activo <> "SI" Then

            '    If seccion = "" Then

            '        activo = " articulos.Activo = 0 "

            '    Else

            '        activo = " ,articulos.Activo = 0 "

            '    End If

            'Else

            '    activo = ""

            'End If

            ''Si activo esta vacio o seccion esta vacio
            'If activo = "" And seccion = "" Then
            'Else
            '    Dim selUpdate As String
            '    selUpdate = "update Articulos "
            '    selUpdate = selUpdate & " set " & seccion & activo
            '    selUpdate = selUpdate & " where(idarticulo = " & idarticulo & ")"

            '    cmd = New SqlCommand(selUpdate, con)

            '    con.Open()

            '    cmd.ExecuteNonQuery()

            '    con.Close()

            'End If

            Return True

        Catch ex As Exception

            Cursor = Cursors.Default

            Cargando.fin = True

            MsgBox("Error en el volcado." & vbCrLf & cantidad & vbCrLf & cantidadInicial & vbCrLf & idarticulo & ex.Message, MsgBoxStyle.Critical)

            Return False

        End Try

    End Function

    'Comprueba si existe la
    Public Function existeSeccion(ByVal seccion As String) As Boolean
        Try
            'Creamos los parametros de conexion.
            Dim sconexion As String = conexion.CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim i As Integer
            'Creamos la variable de cadena de busqueda de la cantidad.
            Dim sel As String = "select count(*) from secciones as SE  where SE.Seccion = '" & seccion & "'"
            cmd = New SqlCommand(sel, con)
            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    'Exportar contenido ListView a formato CSV para abrir con Microsoft Office Excel, OppenOffice Calc o con 
    Private Function exportarListViewCSV(ByVal lstview As ListView, ByVal ficheroCSV As String) As Boolean

        Try
            Dim lineasCSV As New System.Text.StringBuilder
            Dim lineaActual As String = String.Empty

            'Escribir nombre de columnas y encabezados en la variable temporal
            For columnIndex As Int32 = 0 To lstview.Columns.Count - 1
                lineaActual &= (String.Format("{0};", lstview.Columns(columnIndex).Text))
            Next

            'Quitar la coma final
            lineasCSV.AppendLine(lineaActual.Substring(0, lineaActual.Length - 1))
            lineaActual = String.Empty

            'Escribir los datos del ListView en la variable temporal
            For Each item As ListViewItem In lstview.Items
                For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                    lineaActual &= (String.Format("{0};", subItem.Text))
                Next
                'Quitar coma final
                lineasCSV.AppendLine(lineaActual.Substring(0, lineaActual.Length - 1))
                lineaActual = String.Empty
            Next
            'Guardar datos variable temporal a fichero CSV
            Dim Sys As New System.IO.StreamWriter(ficheroCSV)
            Sys.WriteLine(lineasCSV.ToString)
            Sys.Flush()
            Sys.Dispose()

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Importar
    Private Function fImportarCSV() As Boolean

        Try
            importarCSV(OpenFileDialog1)

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    'Reune los parametros para realizar la busqueda.
    Public Function parametrosBusqueda() As Boolean


        'Vaciamos la variable de busqueda parametros.
        parametros = ""

        If ckActivos.Checked Then

            parametros = parametros & " (AR.Activo = 1 or AR.Activo = 0)"

        Else

            parametros = parametros & " AR.Activo = 1 "

        End If

        'Comprobamos radio button
        If rbVendible.Checked Then

            parametros = parametros & " and AR.vendible = 1 "

        ElseIf rbComprable.Checked Then

            parametros = parametros & " and AR.comprable = 1 "

        End If

        'Comprobamos campo ID
        If IsNumeric(txIdArticulo.Text) Then

            parametros = parametros & " and AR.idarticulo = " & txIdArticulo.Text

        ElseIf Trim(txIdArticulo.Text) = "" Then


        Else

            MsgBox("No se ha introducido una ID de artículo válida.")

            txIdArticulo.Focus()

            Return False

        End If

        'Comprobamos el campo codigo de articulo
        If Trim(txCodigo.Text) <> "" Then

            parametros = parametros & " and AR.codarticulo like '" & txCodigo.Text & "%'"

        End If

        'comprobamos el campo articulo
        If Trim(txArticulo.Text) <> "" Then

            parametros = parametros & " and AR.articulo like '%" & txArticulo.Text & "%'"

        End If

        ''Seleccion de almacen
        'If ComboBox1.Text = "TODOS" Then

        'ElseIf ComboBox1.Text = "DESCONOCIDO" Then

        '    parametros = parametros & " and (STK.idalmacen is null or STK.idalmacen =  0) "

        'Else

        '    parametros = parametros & " and ALM.idalmacen = " & ComboBox1.SelectedValue

        'End If

        If cbSecciones.Text = "TODOS" Then

        ElseIf cbSecciones.Text = "DESCONOCIDO" Then

            parametros = parametros & " and (AR.idSeccion is null or AR.idSeccion  =  0) "

        Else

            parametros = parametros & " and AR.idSeccion  = " & cbSecciones.SelectedValue

        End If

        Return True

    End Function


#End Region

    Private Sub lvArticulos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvArticulos.DoubleClick

        If lvArticulos.SelectedItems.Count = 1 Then

            For Each item In lvArticulos.SelectedItems

                GestionArticulo.idArticulo.Text = item.Text

                GestionArticulo.Show()

            Next

        End If

    End Sub


End Class