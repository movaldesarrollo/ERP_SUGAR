Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class GestionEtiquetas



    'Private crApp As New CRAXDDRT.Application
    'Private crReport As New CRAXDDRT.Report
    Private funcET As New FuncionesEtiquetas
    Private funcCE As New FuncionesCamposEtiquetas
    Private Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10 As String
    Private Campos As Integer
    Private informe As Object
    Private vSoloLectura As Boolean
    Private listaCE As List(Of DatosCampoEtiqueta)

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Copias.Text = 1
        Impresiones.Text = 1
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        campo1.Visible = False
        Campo2.Visible = False
        Campo3.Visible = False
        Campo4.Visible = False
        Campo5.Visible = False
        Campo6.Visible = False
        Campo7.Visible = False
        Campo8.Visible = False
        Campo9.Visible = False
        Campo10.Visible = False
        Valor1 = ""
        Valor2 = ""
        Valor3 = ""
        Valor4 = ""
        Valor5 = ""
        Valor6 = ""
        Valor7 = ""
        Valor8 = ""
        Valor9 = ""
        Valor10 = ""
        MargenDer.Text = 0
        MargenIzq.Text = 0
        MargenSup.Text = 0
        MargenInf.Text = 0
        Call CargarEtiquetas()
        Call CargarImpresoras()
    End Sub



    Private Sub CargarEtiquetas()
        cbEtiquetas.Items.Clear()
        Dim lista As List(Of DatosEtiqueta) = funcET.Mostrar
        For Each dts As DatosEtiqueta In lista
            cbEtiquetas.Items.Add(dts)
        Next

    End Sub

    Private Sub CargarImpresoras()
        cbImpresoras.Items.Clear()
        For Each Impresora As String In PrinterSettings.InstalledPrinters
            cbImpresoras.Items.Add(Impresora)
        Next
        cbImpresoras.SelectedIndex = cbImpresoras.FindString("Intermec")
        'If cbImpresoras.SelectedIndex = -1 Then
        '    cbImpresoras.SelectedIndex = cbImpresoras.FindString("EPSON")
        '    If cbImpresoras.SelectedIndex = -1 Then
        '        cbImpresoras.SelectedIndex = cbImpresoras.FindString("BIXOLON")
        '    End If
        'End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub bVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVistaPrevia.Click
        Call VistaPrevia()
       
    End Sub


    Private Sub VistaPrevia()
        Try
            If cbEtiquetas.SelectedIndex <> -1 Then
                'crApp = New CRAXDDRT.Application
                'crReport = New GrandeVACIA 'crApp.OpenReport("C:\PROYECTO ERP_SUGAR\ERP_SUGAR\ERP_SUGAR\InformesRPT\" & "GrandeVacia.RPT")

                Dim settings As ConnectionStringSettings
                settings = ConfigurationManager.ConnectionStrings(1)
                Dim csb As New SqlConnectionStringBuilder
                csb.ConnectionString = settings.ConnectionString

                'Dim informe As New CRAXDDRT.Report
                ''  Dim informe As New GrandeVACIA 'crApp.OpenReport("C:\PROYECTO ERP_SUGAR\ERP_SUGAR\ERP_SUGAR\InformesRPT\GrandeVacia.RPT", 1)
                '' informe.SetDatabaseLogon(csb.UserID, csb.Password)
                ' informe.SetParameterValue("inumPedido", 1)

                '' CRV.ReportSource = informe
                If Not vSoloLectura Then
                    Dim dts As New DatosCampoEtiqueta
                    dts.gidEtiqueta = cbEtiquetas.SelectedItem.gidEtiqueta
                    If Campos > 0 Then
                        dts.gidCampo = 1
                        dts.gValorxDefecto = campo1.Text
                        funcCE.actualizar(dts)
                        If Campos > 1 Then
                            dts.gidCampo = 2
                            dts.gValorxDefecto = Campo2.Text
                            funcCE.actualizar(dts)
                            If Campos > 2 Then
                                dts.gidCampo = 3
                                dts.gValorxDefecto = Campo3.Text
                                funcCE.actualizar(dts)
                                If Campos > 3 Then
                                    dts.gidCampo = 4
                                    dts.gValorxDefecto = Campo4.Text
                                    funcCE.actualizar(dts)
                                    If Campos > 4 Then
                                        dts.gidCampo = 5
                                        dts.gValorxDefecto = Campo5.Text
                                        funcCE.actualizar(dts)
                                        If Campos > 5 Then
                                            dts.gidCampo = 6
                                            dts.gValorxDefecto = Campo6.Text
                                            funcCE.actualizar(dts)
                                            If Campos > 6 Then
                                                dts.gidCampo = 7
                                                dts.gValorxDefecto = Campo7.Text
                                                funcCE.actualizar(dts)
                                                If Campos > 7 Then
                                                    dts.gidCampo = 8
                                                    dts.gValorxDefecto = Campo8.Text
                                                    funcCE.actualizar(dts)
                                                    If Campos > 8 Then
                                                        dts.gidCampo = 9
                                                        dts.gValorxDefecto = Campo9.Text
                                                        funcCE.actualizar(dts)
                                                        If Campos > 9 Then
                                                            dts.gidCampo = 10
                                                            dts.gValorxDefecto = Campo10.Text
                                                            funcCE.actualizar(dts)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                Select Case cbEtiquetas.SelectedItem.gidEtiqueta
                    Case 1

                    Case 2
                        informe = New AccesoriosSondas

                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 3
                        informe = New BayrolPro
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 4
                        informe = New Bayrol
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 5
                        informe = New Cajas
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 6
                        informe = New Conectores
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 7
                        informe = New ETIG
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 8


                    Case 9
                        informe = New EtiquetaEstastes
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 10
                        informe = New EtiquetasPlaca
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 11
                        informe = New FUS
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 12
                        informe = New GrandeVACIA
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 13
                        informe = New Klinwass
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 14
                        informe = New MedianaDoble
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 15
                        informe = New MedianaTimer
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 16
                        informe = New NModems
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                        informe.PrintOptions.PrinterName = cbImpresoras.Text
                    Case 17
                        informe = New FUS2
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 18
                        informe = New ModeloBrilix
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 19
                        informe = New SanaPool
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 20
                        informe = New Serial
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 21
                        informe = New Sondas
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 22
                        informe = New ModeloSugar
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 23
                        informe = New CompassPools
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                    Case 24
                        informe = New PoolBoy
                        informe.SetDatabaseLogon(csb.UserID, csb.Password)
                        CRV.ReportSource = informe
                End Select
                If Not informe Is Nothing Then
                    informe.PrintOptions.PrinterName = cbImpresoras.Text
                    CRV.ReportSource = informe
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbEtiquetas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEtiquetas.SelectedIndexChanged
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        campo1.Visible = False
        Campo2.Visible = False
        Campo3.Visible = False
        Campo4.Visible = False
        Campo5.Visible = False
        Campo6.Visible = False
        Campo7.Visible = False
        Campo8.Visible = False
        Campo9.Visible = False
        Campo10.Visible = False
        Copias.Text = 1
        Impresiones.Text = 1
        If cbEtiquetas.SelectedIndex <> -1 Then
            listaCE = funcCE.Mostrar(cbEtiquetas.SelectedItem.gidEtiqueta)
            Campos = listaCE.Count
            If Campos > 0 Then
                Label1.Text = listaCE(0).gNombreCampo
                Label1.Visible = True
                campo1.Visible = True
                If listaCE(0).gesContador And IsNumeric(listaCE(0).gValorxDefecto) Then
                    campo1.Text = funcCE.SiguienteContador(listaCE(0).gidEtiqueta, listaCE(0).gidCampo)
                Else
                    campo1.Text = listaCE(0).gValorxDefecto
                End If
                If Campos > 1 Then
                    Label2.Text = listaCE(1).gNombreCampo
                    Label2.Visible = True
                    Campo2.Visible = True
                    If listaCE(1).gesContador And IsNumeric(listaCE(1).gValorxDefecto) Then
                        Campo2.Text = funcCE.SiguienteContador(listaCE(1).gidEtiqueta, listaCE(1).gidCampo)
                    Else
                        Campo2.Text = listaCE(1).gValorxDefecto
                    End If
                    If Campos > 2 Then
                        Label3.Text = listaCE(2).gNombreCampo
                        Label3.Visible = True
                        Campo3.Visible = True
                        If listaCE(2).gesContador And IsNumeric(listaCE(2).gValorxDefecto) Then
                            Campo3.Text = funcCE.SiguienteContador(listaCE(2).gidEtiqueta, listaCE(2).gidCampo)
                        Else
                            Campo3.Text = listaCE(2).gValorxDefecto
                        End If
                        If Campos > 3 Then
                            Label4.Text = listaCE(3).gNombreCampo
                            Label4.Visible = True
                            Campo4.Visible = True
                            If listaCE(3).gesContador And IsNumeric(listaCE(3).gValorxDefecto) Then
                                Campo4.Text = funcCE.SiguienteContador(listaCE(3).gidEtiqueta, listaCE(3).gidCampo)
                            Else
                                Campo4.Text = listaCE(3).gValorxDefecto
                            End If
                            If Campos > 4 Then
                                Label5.Text = listaCE(4).gNombreCampo
                                Label5.Visible = True
                                Campo5.Visible = True
                                If listaCE(4).gesContador And IsNumeric(listaCE(4).gValorxDefecto) Then
                                    Campo5.Text = funcCE.SiguienteContador(listaCE(4).gidEtiqueta, listaCE(4).gidCampo)
                                Else
                                    Campo5.Text = listaCE(4).gValorxDefecto
                                End If
                                If Campos > 5 Then
                                    Label6.Text = listaCE(5).gNombreCampo
                                    Label6.Visible = True
                                    Campo6.Visible = True
                                    If listaCE(5).gesContador And IsNumeric(listaCE(5).gValorxDefecto) Then
                                        Campo6.Text = funcCE.SiguienteContador(listaCE(5).gidEtiqueta, listaCE(5).gidCampo)
                                    Else
                                        Campo6.Text = listaCE(5).gValorxDefecto
                                    End If
                                    If Campos > 6 Then
                                        Label7.Text = listaCE(6).gNombreCampo
                                        Label7.Visible = True
                                        Campo7.Visible = True
                                        If listaCE(6).gesContador And IsNumeric(listaCE(6).gValorxDefecto) Then
                                            Campo7.Text = funcCE.SiguienteContador(listaCE(6).gidEtiqueta, listaCE(6).gidCampo)
                                        Else
                                            Campo7.Text = listaCE(6).gValorxDefecto
                                        End If
                                        If Campos > 7 Then
                                            Label8.Text = listaCE(7).gNombreCampo
                                            Label8.Visible = True
                                            Campo8.Visible = True
                                            If listaCE(7).gesContador And IsNumeric(listaCE(7).gValorxDefecto) Then
                                                Campo8.Text = funcCE.SiguienteContador(listaCE(7).gidEtiqueta, listaCE(7).gidCampo)
                                            Else
                                                Campo8.Text = listaCE(7).gValorxDefecto
                                            End If
                                            If Campos > 8 Then
                                                Label9.Text = listaCE(8).gNombreCampo
                                                Label9.Visible = True
                                                Campo9.Visible = True
                                                If listaCE(8).gesContador And IsNumeric(listaCE(8).gValorxDefecto) Then
                                                    Campo9.Text = funcCE.SiguienteContador(listaCE(8).gidEtiqueta, listaCE(8).gidCampo)
                                                Else
                                                    Campo9.Text = listaCE(8).gValorxDefecto
                                                End If
                                                If Campos > 9 Then
                                                    Label10.Text = listaCE(9).gNombreCampo
                                                    Label10.Visible = True
                                                    Campo10.Visible = True
                                                    If listaCE(9).gesContador And IsNumeric(listaCE(9).gValorxDefecto) Then
                                                        Campo10.Text = funcCE.SiguienteContador(listaCE(9).gidEtiqueta, listaCE(9).gidCampo)
                                                    Else
                                                        Campo10.Text = listaCE(9).gValorxDefecto
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub


    
    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If cbImpresoras.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una impresora")
        Else
            If informe Is Nothing Then
                Call VistaPrevia()
            End If
            informe.PrintOptions.PrinterName = cbImpresoras.Text
            'Dim x As New PoolBoy
            Dim Margenes As CrystalDecisions.Shared.PageMargins
            Margenes = informe.PrintOptions.PageMargins
            Margenes.bottomMargin = MargenInf.Text
            Margenes.leftMargin = MargenIzq.Text
            Margenes.rightMargin = MargenDer.Text
            Margenes.topMargin = MargenSup.Text

            informe.PrintOptions.ApplyPageMargins(Margenes)

            'Dim x As FUS
            Dim PP As CrystalDecisions.Shared.PaperSize



            ' x.PrintOptions.PaperSize=
            If Impresiones.Text = "" Then Impresiones.Text = 1
            listaCE = funcCE.Mostrar(cbEtiquetas.SelectedItem.gidEtiqueta)
            For x As Integer = 1 To Impresiones.Text
                If Copias.Text = "" Then Copias.Text = 1
                informe.PrintToPrinter(Copias.Text, False, 1, 1)
                If x < Impresiones.Text Then
                    If cbEtiquetas.SelectedIndex <> -1 Then
                        Campos = listaCE.Count
                        If Campos > 0 Then
                            Label1.Text = listaCE(0).gNombreCampo
                            Label1.Visible = True
                            campo1.Visible = True
                            If listaCE(0).gesContador And IsNumeric(listaCE(0).gValorxDefecto) Then
                                campo1.Text = funcCE.SiguienteContador(listaCE(0).gidEtiqueta, listaCE(0).gidCampo)
                            Else
                                campo1.Text = listaCE(0).gValorxDefecto
                            End If
                            If Campos > 1 Then
                                Label2.Text = listaCE(1).gNombreCampo
                                Label2.Visible = True
                                Campo2.Visible = True
                                If listaCE(1).gesContador And IsNumeric(listaCE(1).gValorxDefecto) Then
                                    Campo2.Text = funcCE.SiguienteContador(listaCE(1).gidEtiqueta, listaCE(1).gidCampo)
                                Else
                                    Campo2.Text = listaCE(1).gValorxDefecto
                                End If
                                If Campos > 2 Then
                                    Label3.Text = listaCE(2).gNombreCampo
                                    Label3.Visible = True
                                    Campo3.Visible = True
                                    If listaCE(2).gesContador And IsNumeric(listaCE(2).gValorxDefecto) Then
                                        Campo3.Text = funcCE.SiguienteContador(listaCE(2).gidEtiqueta, listaCE(2).gidCampo)
                                    Else
                                        Campo3.Text = listaCE(2).gValorxDefecto
                                    End If
                                    If Campos > 3 Then
                                        Label4.Text = listaCE(3).gNombreCampo
                                        Label4.Visible = True
                                        Campo4.Visible = True
                                        If listaCE(3).gesContador And IsNumeric(listaCE(3).gValorxDefecto) Then
                                            Campo4.Text = funcCE.SiguienteContador(listaCE(3).gidEtiqueta, listaCE(3).gidCampo)
                                        Else
                                            Campo4.Text = listaCE(3).gValorxDefecto
                                        End If
                                        If Campos > 4 Then
                                            Label5.Text = listaCE(4).gNombreCampo
                                            Label5.Visible = True
                                            Campo5.Visible = True
                                            If listaCE(4).gesContador And IsNumeric(listaCE(4).gValorxDefecto) Then
                                                Campo5.Text = funcCE.SiguienteContador(listaCE(4).gidEtiqueta, listaCE(4).gidCampo)
                                            Else
                                                Campo5.Text = listaCE(4).gValorxDefecto
                                            End If
                                            If Campos > 5 Then
                                                Label6.Text = listaCE(5).gNombreCampo
                                                Label6.Visible = True
                                                Campo6.Visible = True
                                                If listaCE(5).gesContador And IsNumeric(listaCE(5).gValorxDefecto) Then
                                                    Campo6.Text = funcCE.SiguienteContador(listaCE(5).gidEtiqueta, listaCE(5).gidCampo)
                                                Else
                                                    Campo6.Text = listaCE(5).gValorxDefecto
                                                End If
                                                If Campos > 6 Then
                                                    Label7.Text = listaCE(6).gNombreCampo
                                                    Label7.Visible = True
                                                    Campo7.Visible = True
                                                    If listaCE(6).gesContador And IsNumeric(listaCE(6).gValorxDefecto) Then
                                                        Campo7.Text = funcCE.SiguienteContador(listaCE(6).gidEtiqueta, listaCE(6).gidCampo)
                                                    Else
                                                        Campo7.Text = listaCE(6).gValorxDefecto
                                                    End If
                                                    If Campos > 7 Then
                                                        Label8.Text = listaCE(7).gNombreCampo
                                                        Label8.Visible = True
                                                        Campo8.Visible = True
                                                        If listaCE(7).gesContador And IsNumeric(listaCE(7).gValorxDefecto) Then
                                                            Campo8.Text = funcCE.SiguienteContador(listaCE(7).gidEtiqueta, listaCE(7).gidCampo)
                                                        Else
                                                            Campo8.Text = listaCE(7).gValorxDefecto
                                                        End If
                                                        If Campos > 8 Then
                                                            Label9.Text = listaCE(8).gNombreCampo
                                                            Label9.Visible = True
                                                            Campo9.Visible = True
                                                            If listaCE(8).gesContador And IsNumeric(listaCE(8).gValorxDefecto) Then
                                                                Campo9.Text = funcCE.SiguienteContador(listaCE(8).gidEtiqueta, listaCE(8).gidCampo)
                                                            Else
                                                                Campo9.Text = listaCE(8).gValorxDefecto
                                                            End If
                                                            If Campos > 9 Then
                                                                Label10.Text = listaCE(9).gNombreCampo
                                                                Label10.Visible = True
                                                                Campo10.Visible = True
                                                                If listaCE(9).gesContador And IsNumeric(listaCE(9).gValorxDefecto) Then
                                                                    Campo10.Text = funcCE.SiguienteContador(listaCE(9).gidEtiqueta, listaCE(9).gidCampo)
                                                                Else
                                                                    Campo10.Text = listaCE(9).gValorxDefecto
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    Call VistaPrevia()
                End If
            Next

        End If
    End Sub

    Private Sub Copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Copias.KeyPress, Impresiones.KeyPress, MargenIzq.KeyPress, MargenDer.KeyPress, MargenSup.KeyPress, MargenInf.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


End Class