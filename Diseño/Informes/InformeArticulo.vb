Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient

Public Class InformeArticulos
    Private informe As Object
    Private Sub CRV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRV.Load
        Copias.Text = 1
    End Sub

    Public Function verInforme(ByVal IdArticulo As String, ByVal codigo As String, ByVal fechaAlta As Date, ByVal fechaBaja As Date, _
        ByVal activo As Boolean, ByVal Nombre As String, ByVal descripcion As String, ByVal unidadMedida As String, ByVal submontaje As Boolean, _
        ByVal vendible As Boolean, ByVal stock As String, ByVal proveedorHabitual As String, ByVal familia As String, ByVal subfamilia As String, _
        ByVal almacenHabitual As String, ByVal seccion As String, ByVal observaciones As String) As Boolean
        informe = New imformeArticulos
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        Dim stFechabaja As String
        Dim stActivo As String
        Dim stVendible As String
        Dim stSubmontaje As String
        If activo = True Then
            stActivo = "ACTIVO"
        Else
            stActivo = "INACTIVO"
        End If
        If submontaje = True Then
            stSubmontaje = "SI"
        Else
            stSubmontaje = "NO"
        End If
        If vendible = True Then
            stVendible = "SI"
        Else
            stVendible = "NO"
        End If
        If fechaBaja = fechaAlta Then
            stFechabaja = ""
        Else
            stFechabaja = fechaBaja
        End If
        csb.ConnectionString = settings.ConnectionString
        informe.SetParameterValue("$idArticulo", IdArticulo)
        informe.SetParameterValue("$codigo", codigo)
        informe.setParameterValue("$fechaAlta", fechaAlta)
        informe.SetParameterValue("$fechaBaja", stFechabaja)
        informe.SetParameterValue("$activo", stActivo)
        informe.SetParameterValue("$nombre", Nombre)
        informe.SetParameterValue("$descripcion", descripcion)
        informe.SetParameterValue("$unidad", unidadMedida)
        informe.SetParameterValue("$submontaje", stSubmontaje)
        informe.SetParameterValue("$vendible", stVendible)
        informe.SetParameterValue("$stock", stock)
        informe.SetParameterValue("$proveedorHabitual", proveedorHabitual)
        informe.SetParameterValue("$familia", familia)
        informe.SetParameterValue("$subfamilia", subfamilia)
        informe.SetParameterValue("$almacenHabitual", almacenHabitual)
        informe.SetParameterValue("$seccion", seccion)
        informe.SetParameterValue("$observaciones", observaciones)
        informe.SetDatabaseLogon(csb.UserID, csb.Password)
        CRV.ReportSource = informe
        Return True
    End Function

    Private Sub Copias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Copias.Click
        sender.selectall()
    End Sub

    Private Sub Copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Copias.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If Not informe Is Nothing Then
            If Copias.Text = "" Or Copias.Text = "0" Then Copias.Text = 1
            informe.PrintToPrinter(Copias.Text, False, 1, 999)
        End If
    End Sub
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub
End Class