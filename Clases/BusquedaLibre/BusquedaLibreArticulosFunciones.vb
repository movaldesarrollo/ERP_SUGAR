Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class BusquedaLibreArticulosFunciones

    Inherits conexion
    Dim cmd As SqlCommand
    Dim selComun As String = "SELECT ART.idArticulo AS 'ID' , ART.codArticulo AS 'COD.ARTÍCULO', ART.articulo AS 'ARTÍCULO', SUM(cantidad) AS 'CANTIDAD', SUM(Cantidad * PrecioNetoUnitario ) AS 'IMPORTE'  "
    Dim selComunFactura As String = "SELECT ART.idArticulo AS 'ID' , DOC.NUMFACTURA as 'NUMDOC',CLI.NombreComercial AS 'CLIENTE', cantidad AS 'CANTIDAD', (Cantidad * PrecioNetoUnitario ) AS 'IMPORTE'  "
    Dim selComunAlbaran As String = "SELECT ART.idArticulo AS 'ID' , DOC.NUMALBARAN as 'NUMDOC',CLI.NombreComercial AS 'CLIENTE', cantidad AS 'CANTIDAD', (Cantidad * PrecioNetoUnitario ) AS 'IMPORTE'  "
    Dim selComunPedido As String = "SELECT ART.idArticulo AS 'ID' , DOC.NUMPEDIDO as 'NUMDOC',CLI.NombreComercial AS 'CLIENTE', cantidad AS 'CANTIDAD', (Cantidad * PrecioNetoUnitario ) AS 'IMPORTE'  "
    Dim GroupBy As String = "GROUP BY ART.idArticulo ,ART.Articulo, ART.codArticulo "

#Region "ALBARANES ARTICULOS"
    Dim selAlbaranes As String = " FROM ConceptosAlbaranes AS CA  " _
    & " LEFT JOIN albaranes AS DOC ON DOC.numAlbaran = CA.numAlbaran " _
    & " LEFT JOIN Articulos AS ART ON ART.idArticulo = CA.idArticulo " _
    & " LEFT JOIN Clientes As CLI ON CLI.idcliente = DOC.idcliente "

    'BUSQUEDA GENERAL ALBARANES
    Public Function BusquedaAlbaranes(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of BusquedaLibreDatos)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = selComun & selAlbaranes
            sel = sel & " " & sBusqueda
            sel = sel & " " & GroupBy
            sel = sel & " " & " ORDER BY ART.idArticulo"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of BusquedaLibreDatos)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As BusquedaLibreDatos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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
#End Region

#Region "FACTURAS ARTICULOS"

    Dim selFacturas As String = " FROM ConceptosFacturas AS CFA  " _
    & " LEFT JOIN Facturas AS DOC ON DOC.numfactura = CFA.numfactura " _
    & " LEFT JOIN Articulos AS ART ON ART.idArticulo = CFA.idArticulo " _
    & " LEFT JOIN Clientes As CLI ON CLI.idcliente = DOC.idcliente "

    'BUSQUEDA GENERAL FACTURAS
    Public Function BusquedaFacturas(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of BusquedaLibreDatos)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = selComun & selFacturas
            sel = sel & " " & sBusqueda
            sel = sel & " " & GroupBy
            sel = sel & " " & " ORDER BY ART.idArticulo"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of BusquedaLibreDatos)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As BusquedaLibreDatos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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
#End Region

#Region "PEDIDOS ARTICULOS"
    Dim selPedidos As String = " FROM ConceptosPedidos AS CP  " _
    & " LEFT JOIN Pedidos AS DOC ON DOC.numPedido = CP.numPedido " _
    & " LEFT JOIN Articulos AS ART ON ART.idArticulo = CP.idArticulo " _
    & " LEFT JOIN Clientes As CLI ON CLI.idcliente = DOC.idcliente "

    'BUSQUEDA GENERAL PEDIDOS
    Public Function BusquedaPedidos(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of BusquedaLibreDatos)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = selComun & selPedidos
            sel = sel & " " & sBusqueda
            sel = sel & " " & GroupBy
            sel = sel & " " & " ORDER BY ART.idArticulo"
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of BusquedaLibreDatos)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As BusquedaLibreDatos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
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
#End Region

#Region "ALBARANES DOCS"
    'BUSQUEDA GENERAL ALBARANES
    Public Function BusquedaDocsAlbaranes(ByVal sBusqueda As String, ByVal idArticulo As Integer) As List(Of BusquedaDocsArticulosDatos)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = selComunAlbaran & selAlbaranes
            sel = sel & " " & sBusqueda & " and ART.idArticulo=" & idArticulo
            sel = sel & " ORDER BY CLI.NombreComercial "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of BusquedaDocsArticulosDatos)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As BusquedaDocsArticulosDatos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID") Is DBNull.Value Then
                    Else
                        dts = CargarLineaDoc(linea)
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
#End Region

#Region "FACTURAS DOCS"
    'BUSQUEDA GENERAL FACTURAS
    Public Function BusquedaDocsFacturas(ByVal sBusqueda As String, ByVal idArticulo As Integer) As List(Of BusquedaDocsArticulosDatos)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = selComunFactura & selFacturas
            sel = sel & " " & sBusqueda & " and ART.idArticulo=" & idArticulo
            sel = sel & " ORDER BY CLI.NombreComercial "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of BusquedaDocsArticulosDatos)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As BusquedaDocsArticulosDatos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID") Is DBNull.Value Then
                    Else
                        dts = CargarLineaDoc(linea)
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
#End Region

#Region "PEDIDOS DOCS"
    'BUSQUEDA GENERAL PEDIDOS
    Public Function BusquedaDocsPedidos(ByVal sBusqueda As String, ByVal idArticulo As Integer) As List(Of BusquedaDocsArticulosDatos)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = selComunPedido & selPedidos
            sel = sel & " " & sBusqueda & " and ART.idArticulo=" & idArticulo
            sel = sel & " ORDER BY CLI.NombreComercial "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of BusquedaDocsArticulosDatos)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As BusquedaDocsArticulosDatos
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("ID") Is DBNull.Value Then
                    Else
                        dts = CargarLineaDoc(linea)
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
#End Region

    'Llena el DTS con los datos de las lineas de los articulos.
    Private Function CargarLinea(ByVal linea As DataRow) As BusquedaLibreDatos
        Dim dts As New BusquedaLibreDatos
        dts.gid = If(linea("ID") Is DBNull.Value, "0", linea("ID"))
        dts.gcodArticulo = If(linea("COD.ARTÍCULO") Is DBNull.Value, "", linea("COD.ARTÍCULO"))
        dts.garticulo = If(linea("ARTÍCULO") Is DBNull.Value, "", linea("ARTÍCULO"))
        dts.gCantidad = If(linea("CANTIDAD") Is DBNull.Value, "", linea("CANTIDAD"))
        dts.gImporte = If(linea("IMPORTE") Is DBNull.Value, "", linea("IMPORTE"))
        Return dts
    End Function
    'Llena el DTS con los datos de las lineas de los docs
    Private Function CargarLineaDoc(ByVal linea As DataRow) As BusquedaDocsArticulosDatos
        Dim dts As New BusquedaDocsArticulosDatos
        dts.gid = If(linea("ID") Is DBNull.Value, "0", linea("ID"))
        dts.numDoc = If(linea("NUMDOC") Is DBNull.Value, "", linea("NUMDOC"))
        dts.gcliente = If(linea("CLIENTE") Is DBNull.Value, "", linea("CLIENTE"))
        dts.gCantidad = If(linea("CANTIDAD") Is DBNull.Value, "", linea("CANTIDAD"))
        dts.gimporte = If(linea("IMPORTE") Is DBNull.Value, "", linea("IMPORTE"))
        Return dts
    End Function

    Public Function retornoDoc(ByVal doc As String) As String
        Try
            Select Case doc
                Case "ALBARANES"
                    Return selAlbaranes
                Case "PEDIDOS"
                    Return selPedidos
                Case "FACTURAS"
                    Return selFacturas
                Case ""
                    Return selAlbaranes
            End Select
            Return ""
        Catch ex As Exception
            Return selAlbaranes
        End Try
    End Function
End Class