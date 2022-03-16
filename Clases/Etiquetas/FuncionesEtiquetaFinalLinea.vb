Imports System.Data.SqlClient

Public Class FuncionesEtiquetaFinalLinea

#Region "Variables"
    Inherits conexion
    Dim cmd As SqlCommand
#End Region

#Region "Funciones"
    Friend Function obtenerDatosEtiquetaFL(numSerie As Integer) As DataTable
        Dim dt As New DataTable
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = ""
        Dim da As SqlDataAdapter
        Try
            con.Open()
            sel = "select * from camposEtiquetasFinalLinea where numserie = " & numSerie & ""
            da = New SqlDataAdapter(sel, con)
            da.Fill(dt)
            con.Close()
        Catch ex As Exception
            MsgBox("Error al recuperar los datos de la etiqueta " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return dt
    End Function
    'Friend Function obtenerImagenEtiquetaCliente(idEtiquetaCliente As Integer) As DataTable
    '    Dim dt As New DataTable
    '    Dim con As New SqlConnection(CadenaConexion)
    '    Dim sel As String = ""
    '    Dim da As SqlDataAdapter
    '    Try
    '        sel = "select imagen from etiquetaLogisticaClienteFinalLinea where idEtiqueta = " & idEtiquetaCliente & ""
    '        da = New SqlDataAdapter(sel, con)
    '        da.Fill(dt)
    '    Catch ex As Exception
    '        MsgBox("Error al recuperar los datos de la etiqueta " & vbCrLf & ex.ToString)
    '    End Try
    '    Return dt
    'End Function
    Friend Function obtenerImagenEtiquetaCliente(idcliente As Integer, codarticulo As String) As Byte()
        Dim dt As New DataTable
        Dim photo() As Byte
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = ""
        Dim da As SqlDataAdapter
        Try
            con.Open()
            sel = "SELECT imagen FROM etiquetaLogisticaClienteFinalLinea WHERE idCliente = " & idcliente & " and codArticulo = '" & codarticulo & "'"
            da = New SqlDataAdapter(sel, con)
            da.Fill(dt)
            photo = dt.Rows(0).Item("imagen")
            con.Close()
        Catch ex As Exception
            MsgBox("Error al recuperar los datos de la etiqueta " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return photo
    End Function

    Public Function GetDataInfo(numSerie As String) As DataTable
        Dim dt As New DataTable
        Dim con As New SqlConnection(CadenaConexion)
        Dim da As SqlDataAdapter
        Dim sel As String = "select 
	cli.NombreComercial, 
	cped.codArticuloCli,
	ep.numSerie,
	cped.numPedido,
    cli.idCliente
    from EquiposProduccion ep
    left join ConceptosProduccion cp on cp.idProduccion = ep.idProduccion
    left join ConceptosPedidos cped on  cped.idConcepto = cp.idConceptoPedido
    left join Pedidos ped on ped.numPedido = cped.numPedido
    left join Clientes cli on cli.idCliente = ped.idCliente
    where ep.numSerie = " & numSerie & ""
        Try
            con.Open()

            da = New SqlDataAdapter(sel, con)
            da.Fill(dt)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function

    Public Function GetDataInfoExists(numSerie As String) As DataTable
        Dim dt As New DataTable
        Dim con As New SqlConnection(CadenaConexion)
        Dim da As SqlDataAdapter
        Dim sel As String = "select
	cli.NombreComercial, 
	cef.refCliente,
	cef.numSerie, 
	cef.PV,
    cli.idCliente,
    cef.idEtiqueta,
cefn.customerPartNumber,
	cefn.ean13
    from camposEtiquetasFinalLinea cef
    left join Pedidos ped on ped.numPedido = cef.PV
	LEFT JOIN camposEtiquetasFinalLinea cefn on cefn.numSerie = cef.numSerie  
    left join Clientes cli on cli.idCliente = ped.idCliente
    where cef.numSerie = " & numSerie & ""
        Try
            con.Open()
            da = New SqlDataAdapter(sel, con)
            da.Fill(dt)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function

    Friend Function updateValuesLogos(dataEtiqueta As CamposEtiquetaFinalLinea) As Boolean
        Dim result As Boolean = True
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = "update camposEtiquetasFinalLinea
    
        set customerPartNumber= '" & dataEtiqueta.gCustomerPartNumber & "',EAN13 = '" & dataEtiqueta.gEAN13 & "',logoCE= " & IIf(dataEtiqueta.gLogoCE, 1, 0) & ",logoCMIN= " & IIf(dataEtiqueta.gLogoCMIN, 1, 0) & ",logoEAC= " & IIf(dataEtiqueta.gLogoEAC, 1, 0) &
        ",logoUKCA= " & IIf(dataEtiqueta.gLogoUKCA, 1, 0) & ",logoLPX3= " & IIf(dataEtiqueta.gLogoLPX3, 1, 0) & ",logoUL=" & IIf(dataEtiqueta.gLogoUL, 1, 0) &
        ",logoWEEE=" & IIf(dataEtiqueta.gLogoWEEE, 1, 0) & ",logoMADEINSPAIN= " & IIf(dataEtiqueta.gLogoMADEINSPAIN, 1, 0) & "
        where numserie = " & dataEtiqueta.gNumSerie & ""
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery = 0 Then
                result = False
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("error al updatear logos " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return result
    End Function

    Friend Function InsertValuesLogos(dataEtiqueta As CamposEtiquetaFinalLinea) As Boolean
        Dim add As Boolean = False
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = "INSERT INTO camposEtiquetasFinalLinea 
(refCliente,customerPartNumber,EAN13, numSerie, cantidad, PV, logoCE,logoCMIN, logoEAC, logoUKCA, logoLPX3, logoUL, logoWEEE, logoMADEINSPAIN)
VALUES(@refCliente,@customerpn,@ean13, @numSerie, @cantidad, @pv, @CE, @CMIN, @EAC, @UKCA, @LPX3, @UL, @WEEE, @madeInSpain);
SELECT SCOPE_IDENTITY()"
        Try
            cmd = New SqlCommand(sel, con)
            With cmd.Parameters
                .AddWithValue("@refCliente", dataEtiqueta.gRefCliente)
                .AddWithValue("@customerpn", dataEtiqueta.gCustomerPartNumber)
                .AddWithValue("@ean13", dataEtiqueta.gEAN13)
                .AddWithValue("@numSerie", dataEtiqueta.gNumSerie)
                .AddWithValue("@cantidad", dataEtiqueta.gCantidad)
                .AddWithValue("@pv", dataEtiqueta.gPV)
                .AddWithValue("@CE", dataEtiqueta.gLogoCE)
                .AddWithValue("@CMIN", dataEtiqueta.gLogoCMIN)
                .AddWithValue("@EAC", dataEtiqueta.gLogoEAC)
                .AddWithValue("@UKCA", dataEtiqueta.gLogoUKCA)
                .AddWithValue("@LPX3", dataEtiqueta.gLogoLPX3)
                .AddWithValue("@UL", dataEtiqueta.gLogoUL)
                .AddWithValue("@WEEE", dataEtiqueta.gLogoWEEE)
                .AddWithValue("@madeInSpain", dataEtiqueta.gLogoMADEINSPAIN )
            End With
            con.Open()
            Dim i As Integer = cmd.ExecuteScalar
            If i > 0 Then
                add = True
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("error al registrar los campos de la etiqueta " & vbCrLf & ex.ToString)
            con.Close()
        End Try
        Return add
    End Function

    Public Function ExistsLabel(numSerie As String) As Boolean
        Dim exists As Boolean = False
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = "select idEtiqueta from camposEtiquetasFinalLinea where numSerie = " & numSerie & ""
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim i As Integer = cmd.ExecuteScalar
            If i > 0 Then
                exists = True
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("error al verificar existencia " & vbCrLf & ex.ToString)
        End Try
        Return exists
    End Function

    Friend Function CheckFileType(idEtiquetaCliente As Integer) As Boolean
        Dim IsPDF As Boolean
        Dim con As New SqlConnection(CadenaConexion)
        Dim sel As String = "select PDF from etiquetaLogisticaClienteFinalLinea where idEtiqueta = " & idEtiquetaCliente & ""
        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            If IsDBNull(cmd.ExecuteScalar) Then
            Else
                Dim i As Integer = cmd.ExecuteScalar
                If i = 0 Then
                    IsPDF = False
                Else
                    IsPDF = True
                End If
            End If
            con.Close()
            Return IsPDF
        Catch ex As Exception
            con.Close()
            MsgBox("Error CheckFileType: " & ex.ToString)
            Return 0
        End Try
    End Function

    Friend Function getIdArticle(codArticulo As String) As Integer
        Dim con As New SqlConnection(CadenaConexion)
        Dim idArticulo As Integer = 0


        Dim sel As String = "Select idarticulo From articulocliente Where CodArticuloCli ='" & codArticulo & "'"

        Try
            cmd = New SqlCommand(sel, con)
            con.Open()
            idArticulo = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox("error al verificar existencia " & vbCrLf & ex.ToString)
        End Try
        Return idArticulo
    End Function

#End Region
End Class
