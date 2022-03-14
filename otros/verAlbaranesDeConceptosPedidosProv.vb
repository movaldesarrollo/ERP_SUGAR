Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class verAlbaranesDeConceptosPedidosProv

    Dim conexiones As New conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = conexiones.CadenaConexion()
    Public idconcepto As Integer

    Private Sub verAlbaranesDeConceptosPedidosProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If idconcepto > 0 Then

            llenarLvAlbaranes()

        End If

    End Sub

#Region "FUNCIONES Y METODOS"

    'llenar lv
    Public Sub llenarLvAlbaranes()

        Dim t As Integer = 0

        lvAlbarenesConceptoPedido.Items.Clear()

        Dim lista As List(Of DatosAlbaranesDePedidosProv) = buscarAlbaranes(idconcepto)
        For Each dts As DatosAlbaranesDePedidosProv In lista
            With lvAlbarenesConceptoPedido.Items.Add(dts.gIdAlbaran)
                .SubItems.Add(dts.gNumAlbaran) '1
                .SubItems.Add(dts.gNumFactura) '2
                .SubItems.Add(dts.gFecha) '3
                .SubItems.Add(dts.gReferencia) '4
                .SubItems.Add(dts.gNotas) '5
                .SubItems.Add(dts.gObservaciones) '6
                .SubItems.Add(dts.gEstado) '7
                .SubItems.Add(FormatNumber(dts.gCantidad, 2)) '8
            End With

        Next

    End Sub

#End Region

#Region "SQL"

    Function buscarAlbaranes(ByVal idConcepto As Integer) As List(Of DatosAlbaranesDePedidosProv)

        Try
            Dim lista As New List(Of DatosAlbaranesDePedidosProv)
            Dim sel As String = "select CA.idalbaran ,(select numalbaran from AlbaranesProv where idAlbaran = CA.idAlbaran ) as albaran, "
            sel = sel & "(select numfactura from FacturasProv  where idFactura  = CA.idFactura ) as factura,AL.fecha , AL.Referencia, "
            sel = sel & "AL.Notas, AL.Observaciones, (select Estado from Estados where idEstado = CA.idEstado) as estado, "
            sel = sel & "Cantidad from ConceptosAlbaranesProv as CA  left join AlbaranesProv as AL on AL.idAlbaran = CA.idAlbaran "
            sel = sel & "where CA.idAlbaran in(select idAlbaran  from ConceptosAlbaranesProv where idConceptoPedidoProv = " & idConcepto & ")"

            Dim con As New SqlConnection(sconexion)
            cmd = New SqlCommand(sel, con)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosAlbaranesDePedidosProv
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idalbaran") Is DBNull.Value Then
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

    'Cargar datos de pedidos.
    Public Function cargarLinea(ByVal linea As DataRow) As DatosAlbaranesDePedidosProv

        Dim dts As New DatosAlbaranesDePedidosProv

        dts.gCantidad = If(linea("cantidad") Is DBNull.Value, 0, linea("cantidad"))
        dts.gNumFactura = If(linea("factura") Is DBNull.Value, 0, linea("factura"))
        dts.gIdAlbaran = If(linea("idalbaran") Is DBNull.Value, 0, linea("idalbaran"))
        dts.gNumAlbaran = If(linea("albaran") Is DBNull.Value, 0, linea("albaran"))
        dts.gFecha = If(linea("fecha") Is DBNull.Value, 0, linea("fecha"))
        dts.gNotas = If(linea("notas") Is DBNull.Value, " ", linea("notas"))
        dts.gReferencia = If(linea("referencia") Is DBNull.Value, " ", linea("referencia"))
        dts.gObservaciones = If(linea("observaciones") Is DBNull.Value, " ", linea("observaciones"))
        dts.gEstado = If(linea("ESTADO") Is DBNull.Value, " ", linea("ESTADO"))

        Return dts

    End Function

#End Region

    Private Sub lvAlbarenesConceptoPedido_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAlbarenesConceptoPedido.DoubleClick

        If lvAlbarenesConceptoPedido.SelectedItems.Count > 0 Then

            For Each item In lvAlbarenesConceptoPedido.SelectedItems

                Dim ag As New GestionAlbaranDeProv

                ag.iidAlbaran = item.Text

                ag.ShowDialog()

            Next

        End If

    End Sub

End Class