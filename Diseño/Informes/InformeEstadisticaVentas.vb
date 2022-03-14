Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeEstadisticaVentas
    Public Function verInforme(ByVal sBusqueda As String, ByVal Orden As String, ByVal iidCliente As Integer, ByVal Titulo As String) As Boolean
        Dim informe As Object
        If iidCliente = 0 Then
            'informe = New EstadisticaVentasXclienteH
            informe = New EstadisticaVentasXclienteCruzadas
        Else
            informe = New EstadisticaVentas
        End If
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        Dim sParametro As String = ""
        If iidCliente > 0 Then
            sParametro = " WHERE FA.idCliente = " & iidCliente
            If sBusqueda <> "" Then sParametro = sParametro & " AND " & sBusqueda
        ElseIf sBusqueda <> "" Then
            sParametro = "WHERE " & sBusqueda
        End If

        If Orden = "" Then
            Orden = " Order By NombreComercial ASC "
        Else
            Orden = " Order By " & Orden
        End If

        informe.SetParameterValue("sOrden", Orden)
        'informe.SetParameterValue("sParametros", sParametro)
        informe.SetParameterValue("sParametro", sParametro)
        informe.setParameterValue("VerTotal", iidCliente = 0)
        informe.setParameterValue("Titulo", Titulo)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True
    End Function

    Public Function verInformeRaizCliente(ByVal sBusqueda As String, ByVal Orden As String, ByVal iidCliente As Integer, ByVal Titulo As String) As Boolean
        Dim informe As Object
        If iidCliente = 0 Then
            informe = New EstadisticaVentasXclienteH
        Else
            informe = New EstadisticaVentas
        End If
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        Dim sParametro As String = ""
        If iidCliente > 0 Then
            sParametro = " WHERE FA.idCliente = " & iidCliente
            If sBusqueda <> "" Then sParametro = sParametro & " AND " & sBusqueda
        ElseIf sBusqueda <> "" Then
            sParametro = "WHERE " & sBusqueda
        End If
        If Orden = "" Then
            Orden = " Order By NombreComercial ASC "
        Else
            Orden = " Order By " & Orden
        End If
        informe.SetParameterValue("sParametro", sParametro)
        informe.SetParameterValue("sOrden", Orden)
        informe.setParameterValue("VerTotal", iidCliente = 0)
        informe.setParameterValue("Titulo", Titulo)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True
    End Function

    Public Function verInformeAños(ByVal parametros As String, ByVal busqueda As String, ByVal tipoInforme As String) As Boolean
        Dim informe As Object
        informe = New EstadisticaVentasComparativasAños
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetParameterValue("parametros", parametros)
        informe.SetParameterValue("busqueda", busqueda)
        informe.setParameterValue("tipoinforme", tipoInforme)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True
    End Function

    Public Function verInformeAñosRaiz(ByVal parametros As String, ByVal busqueda As String, ByVal tipoInforme As String, ByVal cRaices As String) As Boolean
        Dim informe As Object
        informe = New EstadisticaVentasComparativasAñosRaices
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetParameterValue("parametros", parametros)
        informe.SetParameterValue("busqueda", busqueda)
        informe.setParameterValue("tipoinforme", tipoInforme)
        informe.setParameterValue("ColumnasRaiz", cRaices)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True
    End Function

    Public Function verInformeAñosPais(ByVal parametros As String, ByVal busqueda As String, ByVal tipoInforme As String) As Boolean
        Dim informe As Object
        informe = New EstadisticaVentasComparativasAñosPais
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        informe.SetParameterValue("parametros", parametros)
        informe.SetParameterValue("busqueda", busqueda)
        informe.setParameterValue("tipoinforme", tipoInforme)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRVPedido.ReportSource = informe
        Return True
    End Function

    Private Sub InformeEstadisticaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class