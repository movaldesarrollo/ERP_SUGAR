'Muestra una vista de los conceptos de un pedido.
'Depliega los conceptos de pedidos de produccion.
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class vistaSimpleConceptos

#Region "VARIABLES"

    Dim conexiones As New conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = conexiones.CadenaConexion()

    Public numeroPedido As Integer
    Public fuente As Font
    Dim orden As String = " ARTICULO "
    Dim colOrder As SortOrder = SortOrder.Ascending 'Sentido del orden del listview.
    Dim numColumna As Integer   'Número de columna seleccionada para el orden del listview.


#End Region

#Region "CARGA Y CIERRE"

    'Carga formulario
    Private Sub vistaSimpleConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = Me.Text & numeroPedido 'Cambiamos título al formulario

        'Dimensionando form
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 45
        Me.Location = New Point(Me.Location.X, 15)

        'Fuentes predeterminadas del form vistasimple.
        lvproduccionConceptos.Font = fuente
        lbTotalConceptos.Font = fuente '
        Label1.Font = fuente

        'Llenamos el listview
        llenarlv()

    End Sub

#End Region

#Region "FUNCIONES Y METODOS"

    'Llenar listview con conceptos.
    Private Sub llenarlv()

        Dim t As Integer = 0
        lbTotalConceptos.Text = "TOTAL PEDIDOS: "

        lvproduccionConceptos.Items.Clear()

        Dim lista As List(Of DatosPedidosProdConceptos) = mostrarPedidosEnProdConceptos(orden)
        For Each dts As DatosPedidosProdConceptos In lista
            With lvproduccionConceptos.Items.Add(dts.gconceptoPedido)
                .SubItems.Add(dts.gIdArticulo) '1
                .SubItems.Add(dts.gCodArticulo) '2
                .SubItems.Add(dts.gArticulo) '3
                .SubItems.Add(dts.gVersion) '4
                .SubItems.Add(dts.gEstado) '5
                .SubItems.Add(dts.gcantidad) '6

                Try
                    'Colorea en azul los recambios.
                    If dts.grecambio = True Then
                        .ForeColor = Color.Blue
                    End If

                    'Elimina de la lista los servidos
                    'If dts.gEstado = "SERVIDO" Or dts.gEstado = "PREPARADO" Then
                    '    '.Remove()
                    'End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End With

            t = t + 1
        Next

        lbTotalConceptos.Text = lbTotalConceptos.Text & FormatNumber(t, 0)

    End Sub

    'Orden de listview
    Private Sub ListView1_ColumnClick(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
            Handles lvproduccionConceptos.ColumnClick
        If lvproduccionConceptos.Items.Count <> 0 Then
            
            'Si columna actual es igual a la última columna seleccionada. Formatea la variable con el orden de búsqueda anterio. 
            If e.Column = numColumna Then
                lvproduccionConceptos.Sorting = colOrder
            End If
            ' Crear una instancia de la clase que realizará la comparación
            Dim oCompare As New ListViewColumnSort()
            ' Asignar el orden de clasificación
            If lvproduccionConceptos.Sorting = Windows.Forms.SortOrder.Ascending Then
                oCompare.Sorting = Windows.Forms.SortOrder.Descending
            Else
                oCompare.Sorting = Windows.Forms.SortOrder.Ascending
            End If
            lvproduccionConceptos.Sorting = oCompare.Sorting
            ' La columna en la que se ha pulsado
            oCompare.ColumnIndex = e.Column
            ' El tipo de datos de la columna en la que se ha pulsado
            Select Case e.Column
                Case 0
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 1
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 2
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 3
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 4
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
                Case 5
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
                Case 6
                    oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero

            End Select
            'Elimina los items expandidos.
            'ReordenarExpandidos(True, False)
            ' Asignar la clase que implementa IComparer
            ' y que se usará para realizar la comparación de cada elemento

            lvproduccionConceptos.ListViewItemSorter = oCompare
            numColumna = e.Column
            colOrder = oCompare.Sorting
        End If
        'Vuelve a insertar los items expandidos.
        'ReordenarExpandidos(False, True)
    End Sub
#End Region

#Region "SQL"

    'Busqueda de conceptos de pedido.
    Private Function mostrarPedidosEnProdConceptos(ByVal orden As String) As List(Of DatosPedidosProdConceptos)

        Try
            Dim lista As New List(Of DatosPedidosProdConceptos)
            Dim sel As String = "select CP.idConcepto as 'IDCONCEPTO' ,CP.idArticulo as 'IDARTICULO', "
            sel = sel & "(select codArticulo from Articulos where idArticulo = CP.idArticulo ) as 'CODARTICULO', "
            sel = sel & "(select Articulo from Articulos where idArticulo = CP.idArticulo ) as 'ARTICULO', "
            sel = sel & "CP.VersionEscandallo as 'VERSION', "
            sel = sel & "(select Estado from Estados where idEstado = CP.idestado)as 'ESTADO', "
            sel = sel & "CP.Cantidad as 'CANTIDAD', "
            sel = sel & "(select ConNumSerie2 from Articulos where idArticulo = CP.idarticulo) as 'RECAMBIO' "
            sel = sel & "from ConceptosPedidos as CP "
            sel = sel & " where(numPedido = " & numeroPedido & ") "
            sel = sel & "order by " & orden
            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosPedidosProdConceptos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("IDCONCEPTO") Is DBNull.Value Then
                    Else
                        dts = cargarLineaConceptos(linea)
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

    'Cargar datos de pedidos.
    Public Function cargarLineaConceptos(ByVal linea As DataRow) As DatosPedidosProdConceptos

        Dim dts As New DatosPedidosProdConceptos

        dts.gcantidad = If(linea("CANTIDAD") Is DBNull.Value, 0, linea("CANTIDAD"))
        dts.gArticulo = If(linea("ARTICULO") Is DBNull.Value, 0, linea("ARTICULO"))
        dts.gIdArticulo = If(linea("IDARTICULO") Is DBNull.Value, 0, linea("IDARTICULO"))
        dts.gconceptoPedido = If(linea("IDCONCEPTO") Is DBNull.Value, 0, linea("IDCONCEPTO"))
        dts.gEstado = If(linea("ESTADO") Is DBNull.Value, 0, linea("ESTADO"))
        dts.grecambio = If(linea("RECAMBIO") Is DBNull.Value, 0, linea("RECAMBIO"))
        dts.gCodArticulo = If(linea("CODARTICULO") Is DBNull.Value, " ", linea("CODARTICULO"))
        dts.gVersion = If(linea("VERSION") Is DBNull.Value, " ", linea("VERSION"))

        Return dts

    End Function

#End Region

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub
End Class