Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class GestionEtiquetas

#Region "VARIABLES"

    Private funcET As New FuncionesEtiquetas
    Private funcCE As New FuncionesCamposEtiquetas
    Private funcEI As New FuncionesEtiquetasImpresoras
    Private Valor1, Valor2, Valor3, Valor4, Valor5, Valor6, Valor7, Valor8, Valor9, Valor10 As String
    Private Campos As Integer
    Private informe As Object
    Private vSoloLectura As Boolean
    Private listaCE As List(Of DatosCampoEtiqueta)
    Private iidEtiquetaImp As Integer
    Private numsSerie As List(Of Integer)
    Private numSerieLista As Boolean 'Nos dice si hemos de tomar los numserie de la lista pasada por parámetro
    Private indice As Integer
    Private iidEtiqueta As Integer
    Private codArticulo As String
    Private dtsEE As DatosEtiqueta
    Private esEtiquetaEditada As Boolean = False
    Private UltimaEtiquetaPresentada As Integer = 0
    Private UltimoCampoPresentado As Integer = 0
    Private EtiquetaEnCurso As EtiquetaEditada

#End Region

#Region "PROPIEDADES"
    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Public Property pnumSSerie() As List(Of Integer)
        Get
            Return numsSerie
        End Get
        Set(ByVal value As List(Of Integer))
            numsSerie = value
        End Set
    End Property

    Public Property pcodArticulo() As String
        Get
            Return codArticulo
        End Get
        Set(ByVal value As String)
            codArticulo = value
        End Set
    End Property

    Public Property pidEtiqueta() As Integer
        Get
            Return iidEtiqueta
        End Get
        Set(ByVal value As Integer)
            iidEtiqueta = value
        End Set
    End Property
#End Region

#Region "CARGA Y CIERRE"

    Private Sub GestionEtiquetas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
            If desktopSize.Height < 950 Then
                Me.Height = desktopSize.Height - 50
            Else
                Me.Height = 900
            End If

            Call inicializar()
            Call CargarEtiquetas()
            Call CargarImpresoras()
            If numsSerie Is Nothing Then
                numSerieLista = False

            Else
                If numsSerie.Count > 0 Then
                    numSerieLista = True
                    numsSerie.Sort()
                    Impresiones.Text = numsSerie.Count
                    Impresiones.Enabled = False
                Else
                    numSerieLista = False
                End If
            End If
            If iidEtiqueta > 0 Then
                dtsEE = funcET.Mostrar1(iidEtiqueta)
                Call CargarEtiqueta()

            End If

        Catch ex As Exception
            ex.Data.Add("iidEtiqueta", iidEtiqueta)
            CorreoError(ex)
        End Try
    End Sub

#End Region
   
#Region "FUNCIONES Y PROCEDIMIENTOS"

    Private Sub inicializar()
        Copias.Text = 2
        If Not numSerieLista Then Impresiones.Text = 1
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
        Campo1.Visible = False
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
        iidEtiquetaImp = 0
        indice = 0
    End Sub

    Private Sub CargarEtiquetas()

        cbEtiquetas.Items.Clear()

        Dim lista As List(Of DatosEtiqueta) = funcET.Mostrar(True)

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

    Private Sub VistaPrevia()
        Try
            If cbEtiquetas.SelectedIndex <> -1 Then
                If Not vSoloLectura Then
                    iidEtiqueta = cbEtiquetas.SelectedItem.gidEtiqueta

                    Dim dtsEI As New DatosEtiquetaImpresora
                    dtsEI.gidEtiquetaImp = iidEtiquetaImp
                    dtsEI.gidEtiqueta = iidEtiqueta
                    dtsEI.gImpresora = Microsoft.VisualBasic.Left(Trim(cbImpresoras.Text), 50)
                    dtsEI.gMargenIzq = If(IsNumeric(MargenIzq.Text), CInt(MargenIzq.Text), 0)
                    dtsEI.gMargenDer = If(IsNumeric(MargenDer.Text), CInt(MargenDer.Text), 0)
                    dtsEI.gMargenSup = If(IsNumeric(MargenSup.Text), CInt(MargenSup.Text), 0)
                    dtsEI.gMargenInf = If(IsNumeric(MargenInf.Text), CInt(MargenInf.Text), 0)
                    If iidEtiquetaImp > 0 Then
                        funcEI.actualizar(dtsEI)
                    Else
                        iidEtiquetaImp = funcEI.insertar(dtsEI)
                    End If
                    Call ActualizarCampos()
                End If
                iidEtiqueta = cbEtiquetas.SelectedItem.gidEtiqueta
                If esEtiquetaEditada Then
                    informe = EtiquetaEnCurso.ReportSource

                    '  codArticulo = Campo1.Text

                Else
                    Call AsignarInformesExistentes()
                End If
                If Not informe Is Nothing Then
                    informe.PrintOptions.PrinterName = cbImpresoras.Text
                    CRV.ReportSource = informe
                End If
                'Esto es para que no se vea la etiqueta "Informe Principal"
                For Each c1 As Control In CRV.Controls
                    If c1.GetType Is GetType(CrystalDecisions.Windows.Forms.PageView) Then
                        Dim pv As CrystalDecisions.Windows.Forms.PageView = c1
                        For Each c2 As Control In pv.Controls
                            If c2.GetType Is GetType(TabControl) Then
                                Dim tc As TabControl = c2
                                tc.ItemSize = New Size(0, 1)
                                tc.SizeMode = TabSizeMode.Fixed
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    Private Sub bVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVistaPrevia.Click
        Call VistaPrevia()
    End Sub

    Private Sub bImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImprimir.Click
        If cbImpresoras.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar una impresora")
        Else
            If informe Is Nothing Then
                Call VistaPrevia()
            End If
            If Not informe Is Nothing Then
                informe.PrintOptions.PrinterName = cbImpresoras.Text
                Dim Margenes As CrystalDecisions.Shared.PageMargins
                Margenes = informe.PrintOptions.PageMargins
                Margenes.bottomMargin = MargenInf.Text
                Margenes.leftMargin = MargenIzq.Text
                Margenes.rightMargin = MargenDer.Text
                Margenes.topMargin = MargenSup.Text

                informe.PrintOptions.ApplyPageMargins(Margenes)

                If Impresiones.Text = "" Then Impresiones.Text = 1
                If Not esEtiquetaEditada Then listaCE = funcCE.Mostrar(cbEtiquetas.SelectedItem.gidEtiqueta)
                indice = 0

                For x As Integer = 1 To Impresiones.Text
                    If Copias.Text = "" Then Copias.Text = 1
                    informe.PrintOptions.ApplyPageMargins(Margenes)
                    informe.PrintToPrinter(Copias.Text, False, 1, 1)
                    indice = indice + 1
                    If x < Impresiones.Text Then

                        Campos = listaCE.Count
                        If cbEtiquetas.SelectedIndex <> -1 And Campos > 0 Then
                            If esEtiquetaEditada Then
                                Call CargarListaCamposEtiquetaEditada(x)
                            Else
                                Call CargarListaCamposEtiquetaExistente(x)
                            End If
                            Call VistaPrevia()
                        End If

                    End If
                Next
            End If
        End If
    End Sub

    Private Sub Copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Copias.KeyPress, Impresiones.KeyPress, MargenIzq.KeyPress, MargenDer.KeyPress, MargenSup.KeyPress, MargenInf.KeyPress, Cliente.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbImpresoras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImpresoras.SelectionChangeCommitted
        If cbImpresoras.SelectedIndex <> -1 And cbEtiquetas.SelectedIndex <> -1 Then
            Dim dtsEI As DatosEtiquetaImpresora = funcEI.Mostrar1(cbEtiquetas.SelectedItem.gidEtiqueta, cbImpresoras.Text)
            If dtsEI.gidEtiquetaImp = 0 Then
                MargenIzq.Text = 0
                MargenDer.Text = 0
                MargenInf.Text = 0
                MargenSup.Text = 0
            Else
                iidEtiquetaImp = dtsEI.gidEtiquetaImp
                MargenIzq.Text = dtsEI.gMargenIzq
                MargenDer.Text = dtsEI.gMargenDer
                MargenInf.Text = dtsEI.gMargenInf
                MargenSup.Text = dtsEI.gMargenSup

            End If
        End If

    End Sub

    Private Sub cbImpresoras_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImpresoras.SelectedIndexChanged

        Call VistaPrevia()

    End Sub

    Private Sub Campo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Campo1.TextChanged

        Call VistaPrevia()

        Campo1.Focus()

    End Sub

#End Region

    Private Sub ActualizarCampos()

        If esEtiquetaEditada Then

            Call ActualizarCamposEtiquetaEditada()

        Else

            Call ActualizarCamposEtiquetaExistente()

        End If

    End Sub

    Private Sub ActualizarCamposEtiquetaExistente()
        Dim dts As New DatosCampoEtiqueta
        dts.gidEtiqueta = iidEtiqueta
        If Campos > 0 Then
            dts.gidCampo = 1
            dts.gValorxDefecto = Campo1.Text
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
    End Sub

    Private Sub ActualizarCamposEtiquetaEditada()
        Dim UltimoIndice As Integer = -1
        If Campo1.Visible Then
            Call EncontrarYActualizarCampo(Campo1.Text, UltimoIndice)
        End If
        If Campo2.Visible Then
            Call EncontrarYActualizarCampo(Campo2.Text, UltimoIndice)
        End If
        If Campo3.Visible Then
            Call EncontrarYActualizarCampo(Campo3.Text, UltimoIndice)
        End If
        If Campo4.Visible Then
            Call EncontrarYActualizarCampo(Campo4.Text, UltimoIndice)
        End If
        If Campo5.Visible Then
            Call EncontrarYActualizarCampo(Campo5.Text, UltimoIndice)
        End If
        If Campo6.Visible Then
            Call EncontrarYActualizarCampo(Campo6.Text, UltimoIndice)
        End If
        If Campo7.Visible Then
            Call EncontrarYActualizarCampo(Campo7.Text, UltimoIndice)
        End If
        If Campo8.Visible Then
            Call EncontrarYActualizarCampo(Campo8.Text, UltimoIndice)
        End If
        If Campo9.Visible Then
            Call EncontrarYActualizarCampo(Campo9.Text, UltimoIndice)
        End If
        If Campo10.Visible Then
            Call EncontrarYActualizarCampo(Campo10.Text, UltimoIndice)
        End If

    End Sub

    Private Function SiguienteIndiceDeCampo(ByVal i As Integer) As Integer
        For c As Integer = i + 1 To listaCE.Count - 1
            If listaCE(c).gNombreCampo.Substring(0, 1) = "V" Then
                Return c
            End If
        Next
        Return -1
    End Function

    Private Sub EncontrarYActualizarCampo(ByVal Valor As String, ByRef UltimoIndice As Integer)
        Dim NuevoIndice As Integer = SiguienteIndiceDeCampo(UltimoIndice)
        If NuevoIndice <> -1 Then
            If listaCE(NuevoIndice).gValorxDefecto <> Valor Then
                listaCE(NuevoIndice).gValorxDefecto = Valor
                If listaCE(NuevoIndice).gesCodigo And Valor <> codArticulo Then
                    codArticulo = Valor
                End If
                funcCE.actualizar(listaCE(NuevoIndice))
            End If
            UltimoIndice = NuevoIndice
        End If
    End Sub

    Private Function IndiceEnCampos(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < listaCE.Count AndAlso UCase(Trim(listaCE(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < listaCE.Count Then
            Return i
        Else
            Return -1
        End If
    End Function

    Private Sub AsignarInformesExistentes()
        Dim settings As ConnectionStringSettings
        settings = ConfigurationManager.ConnectionStrings(1)
        Dim csb As New SqlConnectionStringBuilder
        csb.ConnectionString = settings.ConnectionString
        Select Case iidEtiqueta

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
            Case 53
                informe = New Serialx5
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
            Case 25
                informe = New AquaRite
                informe.SetDatabaseLogon(csb.UserID, csb.Password)
                CRV.ReportSource = informe
            Case 26
                informe = New HidroChlor
                informe.SetDatabaseLogon(csb.UserID, csb.Password)
                CRV.ReportSource = informe
            Case 27
                informe = New AquaSolar
                informe.SetDatabaseLogon(csb.UserID, csb.Password)
                CRV.ReportSource = informe
        End Select
    End Sub

    Private Sub cbEtiquetas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEtiquetas.SelectionChangeCommitted

        Call inicializar()
        If cbEtiquetas.SelectedIndex <> -1 Then
            iidEtiqueta = cbEtiquetas.SelectedItem.gidEtiqueta
            dtsEE = funcET.Mostrar1(iidEtiqueta)
            Call CargarEtiqueta()
        End If

    End Sub

    Private Sub CargarEtiqueta()

        Observaciones.Text = dtsEE.gObservaciones
        esEtiquetaEditada = dtsEE.gEtiquetaEditada

        If dtsEE.gidEtiqueta > 0 Then
            cbEtiquetas.Text = dtsEE.gNombre
        End If
        If esEtiquetaEditada Then
            EtiquetaEnCurso = New EtiquetaEditada(iidEtiqueta)
            If dtsEE.gidCliente = 0 Then
                Cliente.Text = "GENÉRICO"
            Else
                Cliente.Text = dtsEE.gCliente
            End If
        Else
            Cliente.Text = ""
        End If
        Dim dtsEI As DatosEtiquetaImpresora
        'Si tenemos seleccionada la impresora, buscaremos los parámetros para ella.
        If cbImpresoras.SelectedIndex = -1 Then
            dtsEI = funcEI.Mostrar1(iidEtiqueta, "")
            iidEtiquetaImp = dtsEI.gidEtiquetaImp
            cbImpresoras.Text = dtsEI.gImpresora
            If cbImpresoras.SelectedIndex = -1 Then
                cbImpresoras.Text = ""
                MargenIzq.Text = 0
                MargenDer.Text = 0
                MargenInf.Text = 0
                MargenSup.Text = 0
            Else
                MargenIzq.Text = dtsEI.gMargenIzq
                MargenDer.Text = dtsEI.gMargenDer
                MargenInf.Text = dtsEI.gMargenInf
                MargenSup.Text = dtsEI.gMargenSup
            End If
        Else

            dtsEI = funcEI.Mostrar1(iidEtiqueta, cbImpresoras.Text)
            iidEtiquetaImp = dtsEI.gidEtiquetaImp
            If iidEtiquetaImp = 0 Then 'Tenemos una impresora seleccionada pero no hemos encontrado datos
                'Busacamos si hay otra impresora para esa etiqueta
                dtsEI = funcEI.Mostrar1(cbEtiquetas.SelectedItem.gidEtiqueta, "")
                If dtsEI.gidEtiquetaImp = 0 Then
                    MargenIzq.Text = 0
                    MargenDer.Text = 0
                    MargenInf.Text = 0
                    MargenSup.Text = 0
                Else
                    'Hemos encontrado datos de otra impresora para esta etiqueta
                    'Miramos si está en lista, si es así la sustituimos
                    Dim i As Integer = cbImpresoras.SelectedIndex
                    cbImpresoras.Text = dtsEI.gImpresora
                    If cbImpresoras.SelectedIndex = -1 Then
                        cbImpresoras.SelectedIndex = i
                        MargenIzq.Text = 0
                        MargenDer.Text = 0
                        MargenInf.Text = 0
                        MargenSup.Text = 0
                    Else
                        iidEtiquetaImp = dtsEI.gidEtiquetaImp
                        MargenIzq.Text = dtsEI.gMargenIzq
                        MargenDer.Text = dtsEI.gMargenDer
                        MargenInf.Text = dtsEI.gMargenInf
                        MargenSup.Text = dtsEI.gMargenSup
                    End If
                End If
            Else
                MargenIzq.Text = dtsEI.gMargenIzq
                MargenDer.Text = dtsEI.gMargenDer
                MargenInf.Text = dtsEI.gMargenInf
                MargenSup.Text = dtsEI.gMargenSup
            End If
        End If
        If esEtiquetaEditada Then
            listaCE = EtiquetaEnCurso.pCampos
        Else
            listaCE = funcCE.Mostrar(cbEtiquetas.SelectedItem.gidEtiqueta)
        End If
        Call CargarListaCampos()

    End Sub

    Private Sub CargarListaCampos()

        Campos = listaCE.Count
        If Campos > 0 Then
            If esEtiquetaEditada Then
                Call CargarListaCamposEtiquetaEditada(0)
            Else
                Call CargarListaCamposEtiquetaExistente(0)
            End If
        End If
    End Sub

    Private Sub CargarListaCamposEtiquetaEditada(ByVal orden As Integer)
        UltimaEtiquetaPresentada = 0
        UltimoCampoPresentado = 0
        For Each dts As DatosCampoEtiqueta In listaCE
            If dts.gVisible Then
                If dts.gNombreCampo.Substring(0, 1) = "E" Then 'EtiquetaX"
                    If dts.gNombreCampo <> "ETIQUETA7" And dts.gNombreCampo <> "ETIQUETA8" Then
                        CargarTextoControlLabel(dts.gValorxDefecto)
                    End If
                End If
                If dts.gNombreCampo.Substring(0, 1) = "V" Then 'ValorX'
                    Dim Texto As String = ""
                    If dts.gesContador And numSerieLista Then
                        Texto = numsSerie(indice)
                    ElseIf dts.gesContador And IsNumeric(dts.gValorxDefecto) Then
                        Texto = funcCE.SiguienteContador(dts.gidEtiqueta, dts.gidCampo)
                    ElseIf dts.gesCodigo And orden = 0 Then
                        Texto = codArticulo
                    Else
                        Texto = dts.gValorxDefecto
                    End If
                    CargarTextoControlCampo(Texto)
                End If
            End If
        Next
    End Sub

    Private Function CargarTextoControlLabel(ByVal texto As String) As Boolean
        'Asigna el texto (y hace visible) a la siguiente etiqueta
        Dim Nombre As String = "Label" & UltimaEtiquetaPresentada + 1
        Dim ControlFormulario As Control = EncontrarControl(Me, Nombre)
        If ControlFormulario Is Nothing Then
            Return False
        Else
            ControlFormulario.Visible = True
            ControlFormulario.Text = texto
            UltimaEtiquetaPresentada = UltimaEtiquetaPresentada + 1
            Return True
        End If

        Return False
    End Function

    Private Function EncontrarControl(ByVal ControlEx As Control, ByVal Nombre As String) As Control
        Dim Resultado As Control = Nothing
        For Each ControlInt As Control In ControlEx.Controls
            If ControlInt.Name = Nombre Then
                Resultado = ControlInt
                Return ControlInt
            End If
            If Resultado Is Nothing Then Resultado = EncontrarControl(ControlInt, Nombre)
        Next

        Return Resultado
    End Function

    Private Function CargarTextoControlCampo(ByVal texto As String) As Boolean
        'Asigna el texto (y hace visible) al siguiente campo
        Dim Nombre As String = "Campo" & UltimoCampoPresentado + 1
        Dim ControlFormulario As Control = EncontrarControl(Me, Nombre)
        If ControlFormulario Is Nothing Then
            Return False
        Else
            ControlFormulario.Visible = True
            ControlFormulario.Text = texto
            UltimoCampoPresentado = UltimoCampoPresentado + 1
            Return True
        End If

        Return False
    End Function

    Private Sub CargarListaCamposEtiquetaExistente(ByVal orden As Integer)
        If orden = 0 Then
            Call CargarListaCamposEtiquetaExistentePrimero()
        Else
            Call CargarListaCamposEtiquetaExistenteSiguientes()
        End If
    End Sub

    Private Sub CargarListaCamposEtiquetaExistentePrimero()

        Label1.Text = listaCE(0).gNombreCampo
        Label1.Visible = True
        Campo1.Visible = True
        If listaCE(0).gesContador And numSerieLista Then
            Campo1.Text = numsSerie(indice)
        ElseIf listaCE(0).gesContador And IsNumeric(listaCE(0).gValorxDefecto) Then
            Campo1.Text = funcCE.SiguienteContador(listaCE(0).gidEtiqueta, listaCE(0).gidCampo)
        ElseIf listaCE(0).gesCodigo Then
            Campo1.Text = codArticulo
        Else
            Campo1.Text = listaCE(0).gValorxDefecto
        End If

        If Campos > 1 Then
            Label2.Text = listaCE(1).gNombreCampo
            Label2.Visible = True
            Campo2.Visible = True

            If listaCE(1).gesContador And numSerieLista Then
                Campo2.Text = numsSerie(indice)
            ElseIf listaCE(1).gesContador And IsNumeric(listaCE(1).gValorxDefecto) Then
                Campo2.Text = funcCE.SiguienteContador(listaCE(1).gidEtiqueta, listaCE(1).gidCampo)
            ElseIf listaCE(1).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                Campo2.Text = codArticulo
            Else
                Campo2.Text = listaCE(1).gValorxDefecto
            End If
            If Campos > 2 Then
                Label3.Text = listaCE(2).gNombreCampo
                Label3.Visible = True
                Campo3.Visible = True
                If listaCE(2).gesContador And numSerieLista Then
                    Campo3.Text = numsSerie(indice)
                ElseIf listaCE(2).gesContador And IsNumeric(listaCE(2).gValorxDefecto) Then
                    Campo3.Text = funcCE.SiguienteContador(listaCE(2).gidEtiqueta, listaCE(2).gidCampo)
                ElseIf listaCE(2).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                    Campo3.Text = codArticulo
                Else
                    Campo3.Text = listaCE(2).gValorxDefecto
                End If
                If Campos > 3 Then
                    Label4.Text = listaCE(3).gNombreCampo
                    Label4.Visible = True
                    Campo4.Visible = True
                    If listaCE(3).gesContador And numSerieLista Then
                        Campo4.Text = numsSerie(indice)
                    ElseIf listaCE(3).gesContador And IsNumeric(listaCE(3).gValorxDefecto) Then
                        Campo4.Text = funcCE.SiguienteContador(listaCE(3).gidEtiqueta, listaCE(3).gidCampo)
                    ElseIf listaCE(3).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                        Campo4.Text = codArticulo
                    Else
                        Campo4.Text = listaCE(3).gValorxDefecto
                    End If
                    If Campos > 4 Then
                        Label5.Text = listaCE(4).gNombreCampo
                        Label5.Visible = True
                        Campo5.Visible = True
                        If listaCE(4).gesContador And numSerieLista Then
                            Campo5.Text = numsSerie(indice)
                        ElseIf listaCE(4).gesContador And IsNumeric(listaCE(4).gValorxDefecto) Then
                            Campo5.Text = funcCE.SiguienteContador(listaCE(4).gidEtiqueta, listaCE(4).gidCampo)
                        ElseIf listaCE(4).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                            Campo5.Text = codArticulo
                        Else
                            Campo5.Text = listaCE(4).gValorxDefecto
                        End If
                        If Campos > 5 Then
                            Label6.Text = listaCE(5).gNombreCampo
                            Label6.Visible = True
                            Campo6.Visible = True
                            If listaCE(5).gesContador And numSerieLista Then
                                Campo6.Text = numsSerie(indice)
                            ElseIf listaCE(5).gesContador And IsNumeric(listaCE(5).gValorxDefecto) Then
                                Campo6.Text = funcCE.SiguienteContador(listaCE(5).gidEtiqueta, listaCE(5).gidCampo)
                            ElseIf listaCE(5).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                                Campo6.Text = codArticulo
                            Else
                                Campo6.Text = listaCE(5).gValorxDefecto
                            End If
                            If Campos > 6 Then
                                Label7.Text = listaCE(6).gNombreCampo
                                Label7.Visible = True
                                Campo7.Visible = True
                                If listaCE(6).gesContador And numSerieLista Then
                                    Campo7.Text = numsSerie(indice)
                                ElseIf listaCE(6).gesContador And IsNumeric(listaCE(6).gValorxDefecto) Then
                                    Campo7.Text = funcCE.SiguienteContador(listaCE(6).gidEtiqueta, listaCE(6).gidCampo)
                                ElseIf listaCE(6).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                                    Campo7.Text = codArticulo
                                Else
                                    Campo7.Text = listaCE(6).gValorxDefecto
                                End If
                                If Campos > 7 Then
                                    Label8.Text = listaCE(7).gNombreCampo
                                    Label8.Visible = True
                                    Campo8.Visible = True
                                    If listaCE(7).gesContador And numSerieLista Then
                                        Campo8.Text = numsSerie(indice)
                                    ElseIf listaCE(7).gesContador And IsNumeric(listaCE(7).gValorxDefecto) Then
                                        Campo8.Text = funcCE.SiguienteContador(listaCE(7).gidEtiqueta, listaCE(7).gidCampo)
                                    ElseIf listaCE(7).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                                        Campo8.Text = codArticulo
                                    Else
                                        Campo8.Text = listaCE(7).gValorxDefecto
                                    End If
                                    If Campos > 8 Then
                                        Label9.Text = listaCE(8).gNombreCampo
                                        Label9.Visible = True
                                        Campo9.Visible = True
                                        If listaCE(8).gesContador And numSerieLista Then
                                            Campo9.Text = numsSerie(indice)
                                        ElseIf listaCE(8).gesContador And IsNumeric(listaCE(8).gValorxDefecto) Then
                                            Campo9.Text = funcCE.SiguienteContador(listaCE(8).gidEtiqueta, listaCE(8).gidCampo)
                                        ElseIf listaCE(8).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                                            Campo9.Text = codArticulo
                                        Else
                                            Campo9.Text = listaCE(8).gValorxDefecto
                                        End If
                                        If Campos > 9 Then
                                            Label10.Text = listaCE(9).gNombreCampo
                                            Label10.Visible = True
                                            Campo10.Visible = True
                                            If listaCE(9).gesContador And numSerieLista Then
                                                Campo10.Text = numsSerie(indice)
                                            ElseIf listaCE(9).gesContador And IsNumeric(listaCE(9).gValorxDefecto) Then
                                                Campo10.Text = funcCE.SiguienteContador(listaCE(9).gidEtiqueta, listaCE(9).gidCampo)
                                            ElseIf listaCE(9).gesCodigo And listaCE(0).gValorxDefecto = "" Then
                                                Campo10.Text = codArticulo
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

    End Sub

    Private Sub CargarListaCamposEtiquetaExistenteSiguientes()

        If listaCE(0).gesContador And numSerieLista Then
            Campo1.Text = numsSerie(indice)
        ElseIf listaCE(0).gesContador And IsNumeric(listaCE(0).gValorxDefecto) Then
            Campo1.Text = funcCE.SiguienteContador(listaCE(0).gidEtiqueta, listaCE(0).gidCampo)
        End If
        If Campos > 1 Then
            If listaCE(1).gesContador And numSerieLista Then
                Campo2.Text = numsSerie(indice)
            ElseIf listaCE(1).gesContador And IsNumeric(listaCE(1).gValorxDefecto) Then
                Campo2.Text = funcCE.SiguienteContador(listaCE(1).gidEtiqueta, listaCE(1).gidCampo)
            End If
            If Campos > 2 Then
                If listaCE(2).gesContador And numSerieLista Then
                    Campo3.Text = numsSerie(indice)
                ElseIf listaCE(2).gesContador And IsNumeric(listaCE(2).gValorxDefecto) Then
                    Campo3.Text = funcCE.SiguienteContador(listaCE(2).gidEtiqueta, listaCE(2).gidCampo)
                End If
                If Campos > 3 Then
                    If listaCE(3).gesContador And numSerieLista Then
                        Campo4.Text = numsSerie(indice)
                    ElseIf listaCE(3).gesContador And IsNumeric(listaCE(3).gValorxDefecto) Then
                        Campo4.Text = funcCE.SiguienteContador(listaCE(3).gidEtiqueta, listaCE(3).gidCampo)
                    End If
                    If Campos > 4 Then
                        If listaCE(4).gesContador And numSerieLista Then
                            Campo5.Text = numsSerie(indice)
                        ElseIf listaCE(4).gesContador And IsNumeric(listaCE(4).gValorxDefecto) Then
                            Campo5.Text = funcCE.SiguienteContador(listaCE(4).gidEtiqueta, listaCE(4).gidCampo)
                        End If
                        If Campos > 5 Then
                            If listaCE(5).gesContador And numSerieLista Then
                                Campo6.Text = numsSerie(indice)
                            ElseIf listaCE(5).gesContador And IsNumeric(listaCE(5).gValorxDefecto) Then
                                Campo6.Text = funcCE.SiguienteContador(listaCE(5).gidEtiqueta, listaCE(5).gidCampo)
                            End If
                            If Campos > 6 Then
                                If listaCE(6).gesContador And numSerieLista Then
                                    Campo7.Text = numsSerie(indice)
                                ElseIf listaCE(6).gesContador And IsNumeric(listaCE(6).gValorxDefecto) Then
                                    Campo7.Text = funcCE.SiguienteContador(listaCE(6).gidEtiqueta, listaCE(6).gidCampo)
                                End If
                                If Campos > 7 Then
                                    If listaCE(7).gesContador And numSerieLista Then
                                        Campo8.Text = numsSerie(indice)
                                    ElseIf listaCE(7).gesContador And IsNumeric(listaCE(7).gValorxDefecto) Then
                                        Campo8.Text = funcCE.SiguienteContador(listaCE(7).gidEtiqueta, listaCE(7).gidCampo)
                                    End If
                                    If Campos > 8 Then
                                        If listaCE(8).gesContador And numSerieLista Then
                                            Campo9.Text = numsSerie(indice)
                                        ElseIf listaCE(8).gesContador And IsNumeric(listaCE(8).gValorxDefecto) Then
                                            Campo9.Text = funcCE.SiguienteContador(listaCE(8).gidEtiqueta, listaCE(8).gidCampo)
                                        End If
                                        If Campos > 9 Then
                                            If listaCE(9).gesContador And numSerieLista Then
                                                Campo10.Text = numsSerie(indice)
                                            ElseIf listaCE(9).gesContador And IsNumeric(listaCE(9).gValorxDefecto) Then
                                                Campo10.Text = funcCE.SiguienteContador(listaCE(9).gidEtiqueta, listaCE(9).gidCampo)
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

End Class