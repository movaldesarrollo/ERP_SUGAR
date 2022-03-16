Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class EditorEtiquetas

#Region ""
    Private informe As New EtiquetaPlantilla
    Private funcE As New FuncionesEtiquetas
    Private funcEL As New FuncionesEtiquetaLogo
    Private funcCE As New FuncionesCamposEtiquetas
    Private funcCL As New funcionesclientes
    Private funcEN As New FuncionesEtiquetaLinea
    Private dtsE As DatosEtiqueta
    Private Campos As List(Of DatosCampoEtiqueta)
    Private Logos As List(Of DatosEtiquetaLogo)
    Private Lineas As List(Of DatosEtiquetaLinea)
    Private iidEtiqueta As Integer
    Private vSoloLectura As Boolean
    Private ElementoSeleccionado As String
    Private ObjetoSeleccionado As Object
    Private IndiceCampoSeleccionado As Integer
    Private IndiceLogoSeleccionado As Integer
    Private Semaforo As Boolean
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private Retardo As New System.Windows.Forms.Timer()
    Private ActualizarAhora As Boolean
    Private EtiquetaEnProceso As EtiquetaEditada
    Private Cambios As Boolean
    Private idEtiquetaPlantilla As Integer
#End Region
    
#Region ""
    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
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

    Private Sub EditorEtiquetas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            bGuardar.Enabled = Not vSoloLectura
            bBorrar.Enabled = Not vSoloLectura
            Semaforo = False
            ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
            ep2.Icon = My.Resources.Resources.info
            ActualizarAhora = False
            hsIncremento.Maximum = 200
            hsIncremento.Value = 50
            Cambios = False
            If CargaridEtiquetaPlantilla() Then

                Call introducirClientes()
                Dim cmenu1 As New ContextMenu

                cmenu1.MenuItems.Add("Pegar imagen", New System.EventHandler(AddressOf Me.Logo1_OnClickPress))
                cmenu1.MenuItems.Add("Borrar imagen", New System.EventHandler(AddressOf Me.Logo1_OnClickPress))

                Logo1.ContextMenu = cmenu1

                Dim cmenu2 As New ContextMenu
                cmenu2.MenuItems.Add("Pegar imagen", New System.EventHandler(AddressOf Me.Logo2_OnClickPress))
                cmenu2.MenuItems.Add("Borrar imagen", New System.EventHandler(AddressOf Me.Logo2_OnClickPress))
                Logo2.ContextMenu = cmenu2

                Dim cmenu3 As New ContextMenu
                cmenu3.MenuItems.Add("Pegar imagen", New System.EventHandler(AddressOf Me.Logo3_OnClickPress))
                cmenu3.MenuItems.Add("Borrar imagen", New System.EventHandler(AddressOf Me.Logo3_OnClickPress))
                Logo3.ContextMenu = cmenu3


                'lbaviso1.BringToFront()
                AddHandler Retardo.Tick, AddressOf ActualizacionRetardada
                Retardo.Interval = 1500
                Retardo.Enabled = False

                EtiquetaEnProceso = New EtiquetaEditada(iidEtiqueta)

                Call CargarEtiqueta()

                CRV.ReportSource = EtiquetaEnProceso.ReportSource

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

                Nombre.Focus()

                Semaforo = True

            Else

                Me.Close()

            End If

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub

    Private Sub EditorEtiquetas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Cambios Then
            If iidEtiqueta = 0 Then
                e.Cancel = (MsgBox("Se perderán los datos introducidos", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            Else
                e.Cancel = (MsgBox("Se perderán los cambios realizados", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
            End If
        End If

    End Sub


#End Region

#Region "INICIALIZACIÓN"

    Private Function CargaridEtiquetaPlantilla() As Boolean
        idEtiquetaPlantilla = funcE.idEtiqueta("EtiquetaPlantilla")
        If idEtiquetaPlantilla = 0 Then
            MsgBox("No se ha encontrado la Etiqueta Plantilla en la base de datos. " & vbCrLf & "Póngase en contacto con el departamento de desarrollo de MOVALNET.")
            Return False
        End If
        Return True
    End Function

    Private Sub Limpiar()
        Semaforo = False
        Etiqueta0.Text = ""
        ckEtiqueta0.Checked = False
        Valor0.Text = ""
        Etiqueta1.Text = ""
        ckEtiqueta1.Checked = False
        Valor1.Text = ""
        Etiqueta2.Text = ""
        ckEtiqueta2.Checked = False
        Valor2.Text = ""
        Etiqueta3.Text = ""
        ckEtiqueta3.Checked = False
        Valor3.Text = ""
        Etiqueta4.Text = ""
        ckEtiqueta4.Checked = False
        Valor4.Text = ""
        Etiqueta5.Text = ""
        ckEtiqueta5.Checked = False
        Valor5.Text = ""
        Etiqueta6.Text = ""
        ckEtiqueta6.Checked = False
        Valor6.Text = ""
        Etiqueta7.Text = ""
        ckEtiqueta7.Checked = False
        Etiqueta8.Text = ""
        ckEtiqueta8.Checked = False
        ckLinea1.Checked = False
        ckLinea2.Checked = False
        ckLogo1.Checked = False
        Logo1.Image = Nothing
        lbaviso1.Visible = True
        ckLogo2.Checked = False
        Logo2.Image = Nothing
        lbAviso2.Visible = True
        ckLogo3.Checked = False
        Logo3.Image = Nothing
        lbAviso3.Visible = True
        cbCliente.Text = "GENÉRICO"
        Nombre.Text = ""
        Observaciones.Text = ""
        ckActivo.Checked = True
        Cambios = False
        iidEtiqueta = 0

        'NUEVO CAMPO
        Check1.Text = ""
        Check2.Text = ""
        Check3.Text = ""
        Check4.Text = ""
        Check5.Text = ""
        Check6.Text = ""
        Check7.Text = ""
        Check8.Text = ""
        Check9.Text = ""

        Semaforo = True
    End Sub

    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        cbCliente.Items.Add("GENÉRICO")
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrecomercial, dts.gidCliente))
        Next
    End Sub

    Private Sub DesmarcarCampos()
        Etiqueta0.BackColor = SystemColors.Window
        Valor0.BackColor = SystemColors.Window
        Etiqueta1.BackColor = SystemColors.Window
        Valor1.BackColor = SystemColors.Window
        Etiqueta2.BackColor = SystemColors.Window
        Valor2.BackColor = SystemColors.Window
        Etiqueta3.BackColor = SystemColors.Window
        Valor3.BackColor = SystemColors.Window
        Etiqueta4.BackColor = SystemColors.Window
        Valor4.BackColor = SystemColors.Window
        Etiqueta5.BackColor = SystemColors.Window
        Valor5.BackColor = SystemColors.Window
        Etiqueta6.BackColor = SystemColors.Window
        Valor6.BackColor = SystemColors.Window
        Etiqueta7.BackColor = SystemColors.Window
        Etiqueta8.BackColor = SystemColors.Window
        Rectangulo1.BorderColor = SystemColors.ControlText
        Rectangulo2.BorderColor = SystemColors.ControlText
        Rectangulo3.BorderColor = SystemColors.ControlText
        Linea1.BorderColor = SystemColors.ControlText
        Linea2.BorderColor = SystemColors.ControlText
        Check1.BackColor = SystemColors.Window
        Check2.BackColor = SystemColors.Window
        Check3.BackColor = SystemColors.Window
        Check4.BackColor = SystemColors.Window
        Check5.BackColor = SystemColors.Window
        Check6.BackColor = SystemColors.Window
        Check7.BackColor = SystemColors.Window
        Check8.BackColor = SystemColors.Window
        Check9.BackColor = SystemColors.Window
    End Sub

#End Region

#Region "CARGAR DATOS"

    Private Sub CargarEtiqueta()

        Semaforo = False

        dtsE = EtiquetaEnProceso.dts

        Campos = EtiquetaEnProceso.pCampos

        Logos = EtiquetaEnProceso.pLogos

        Lineas = EtiquetaEnProceso.pLineas

        If iidEtiqueta = 0 Then
            Nombre.Text = ""
        Else
            Nombre.Text = dtsE.gNombre
        End If

        If dtsE.gidCliente = 0 Then
            cbCliente.Text = "GENÉRICO"
        Else
            cbCliente.Text = dtsE.gCliente
        End If
        Observaciones.Text = dtsE.gObservaciones
        ckActivo.Checked = dtsE.gActivo
        If Campos Is Nothing Then
        Else
            For Each dtsC As DatosCampoEtiqueta In Campos
                Call CargarCamposEtiqueta(dtsC)
            Next
        End If
        If Logos Is Nothing Then
        Else
            For Each dtsL As DatosEtiquetaLogo In Logos
                Call CargarLogosEtiqueta(dtsL)
            Next
        End If
        If Lineas Is Nothing Then
        Else
            For Each dtsN As DatosEtiquetaLinea In Lineas
                Select Case dtsN.gidCampo
                    Case 1
                        ckLinea1.Checked = dtsN.gVisible
                    Case 2

                        ckLinea2.Checked = dtsN.gVisible
                End Select
            Next
        End If
        Semaforo = True
    End Sub


    Private Sub CargarCamposEtiqueta(ByVal dtsC As DatosCampoEtiqueta)
        Select Case dtsC.gNombreCampo
            Case "ETIQUETA0"
                Etiqueta0.Text = dtsC.gValorxDefecto
                ckEtiqueta0.Checked = dtsC.gVisible
            Case "VALOR0"
                Valor0.Text = dtsC.gValorxDefecto
                ckEtiqueta0.Checked = dtsC.gVisible
            Case "ETIQUETA1"
                Etiqueta1.Text = dtsC.gValorxDefecto
                ckEtiqueta1.Checked = dtsC.gVisible
            Case "VALOR1"
                Valor1.Text = dtsC.gValorxDefecto
                ckEtiqueta1.Checked = dtsC.gVisible
            Case "ETIQUETA2"
                Etiqueta2.Text = dtsC.gValorxDefecto
                ckEtiqueta2.Checked = dtsC.gVisible
            Case "VALOR2"
                Valor2.Text = dtsC.gValorxDefecto
                ckEtiqueta2.Checked = dtsC.gVisible
            Case "ETIQUETA3"
                Etiqueta3.Text = dtsC.gValorxDefecto
                ckEtiqueta3.Checked = dtsC.gVisible
            Case "VALOR3"
                Valor3.Text = dtsC.gValorxDefecto
                ckEtiqueta3.Checked = dtsC.gVisible
            Case "ETIQUETA4"
                Etiqueta4.Text = dtsC.gValorxDefecto
                ckEtiqueta4.Checked = dtsC.gVisible
            Case "VALOR4"
                Valor4.Text = dtsC.gValorxDefecto
                ckEtiqueta4.Checked = dtsC.gVisible
            Case "ETIQUETA5"
                Etiqueta5.Text = dtsC.gValorxDefecto
                ckEtiqueta5.Checked = dtsC.gVisible
            Case "VALOR5"
                Valor5.Text = dtsC.gValorxDefecto
                ckEtiqueta5.Checked = dtsC.gVisible
            Case "ETIQUETA6"
                Etiqueta6.Text = dtsC.gValorxDefecto
                ckEtiqueta6.Checked = dtsC.gVisible
            Case "VALOR6"
                Valor6.Text = dtsC.gValorxDefecto
                ckEtiqueta6.Checked = dtsC.gVisible
            Case "ETIQUETA7"
                Etiqueta7.Text = dtsC.gValorxDefecto
                ckEtiqueta7.Checked = dtsC.gVisible
            Case "ETIQUETA8"
                Etiqueta8.Text = dtsC.gValorxDefecto
                ckEtiqueta8.Checked = dtsC.gVisible

                'NUEVO CAMPO
            Case "CHECK1"
                Check1.Text = dtsC.gValorxDefecto
                ckCheck1.Checked = dtsC.gVisible
            Case "CHECK2"
                Check2.Text = dtsC.gValorxDefecto
                ckCheck2.Checked = dtsC.gVisible
            Case "CHECK3"
                Check3.Text = dtsC.gValorxDefecto
                ckCheck3.Checked = dtsC.gVisible
            Case "CHECK4"
                Check4.Text = dtsC.gValorxDefecto
                ckCheck4.Checked = dtsC.gVisible
            Case "CHECK5"
                Check5.Text = dtsC.gValorxDefecto
                ckCheck5.Checked = dtsC.gVisible
            Case "CHECK6"
                Check6.Text = dtsC.gValorxDefecto
                ckCheck6.Checked = dtsC.gVisible
            Case "CHECK7"
                Check7.Text = dtsC.gValorxDefecto
                ckCheck7.Checked = dtsC.gVisible
            Case "CHECK8"
                Check8.Text = dtsC.gValorxDefecto
                ckCheck8.Checked = dtsC.gVisible
            Case "CHECK9"
                Check9.Text = dtsC.gValorxDefecto
                ckCheck9.Checked = dtsC.gVisible

        End Select
    End Sub

    Private Sub CargarLogosEtiqueta(ByVal dtsL As DatosEtiquetaLogo)
        Select Case dtsL.gNombreCampo
            Case "Logo1"
                Logo1.Image = dtsL.gLogo
                ckLogo1.Checked = dtsL.gVisible
            Case "Logo2"
                Logo2.Image = dtsL.gLogo
                ckLogo2.Checked = dtsL.gVisible
            Case "Logo3"
                Logo3.Image = dtsL.gLogo
                ckLogo3.Checked = dtsL.gVisible
        End Select
        lbaviso1.Visible = (Logo1.Image Is Nothing)
        lbAviso2.Visible = (Logo2.Image Is Nothing)
        lbAviso3.Visible = (Logo3.Image Is Nothing)

    End Sub

    Private Sub Nuevo()

        Dim GG As New subElegirEtiqueta

        GG.ShowDialog()

        If GG.DialogResult = Windows.Forms.DialogResult.OK Then

            Call Limpiar()

            iidEtiqueta = 0

            Dim dts As DatosEtiqueta = funcE.Mostrar1(GG.pidEtiqueta)

            dts.gidEtiqueta = 0

            dts.gidCliente = 0

            dts.gCliente = ""

            dts.gNombre = ""

            dts.gObservaciones = ""

            Campos = funcCE.Mostrar(GG.pidEtiqueta)

            For Each dtsC As DatosCampoEtiqueta In Campos

                dts.gidEtiqueta = 0

            Next

            Logos = funcEL.Mostrar(GG.pidEtiqueta)

            For Each dtsL As DatosEtiquetaLogo In Logos

                dtsL.gidEtiqueta = 0

            Next

            Lineas = funcEN.Mostrar(GG.pidEtiqueta)

            For Each dtsN As DatosEtiquetaLinea In Lineas

                dtsN.gidEtiqueta = 0

            Next

            EtiquetaEnProceso = New EtiquetaEditada(dts, Campos, Logos, Lineas)

            Call CargarEtiqueta()

        End If

    End Sub

#End Region

#Region "BOTONES GENERALES"

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        ep1.Clear()

        ep2.Clear()

        Dim validar As Boolean = True

        If Nombre.Text = "" Then

            validar = False

            ep1.SetError(Nombre, "Se ha de indicar un nombre para la etiqueta")

        ElseIf funcE.ExisteEtiqueta(Nombre.Text, iidEtiqueta) Then

            validar = False

            ep1.SetError(Nombre, "Este nombre de etiqueta ya está en uso")

        End If

        If cbCliente.SelectedIndex = -1 Then

            validar = False

            ep1.SetError(cbCliente, "Se ha de seleccionar un cliente o GENÉRICO")

        End If

        If validar Then

            Call Guardar()

            Cambios = False

        End If

        CRV.RefreshReport()

    End Sub

    Private Sub Guardar()

        Try
            dtsE.gNombre = Nombre.Text
            If cbCliente.Text = "GENÉRICO" Then
                dtsE.gCliente = ""
                dtsE.gidCliente = 0
            Else
                dtsE.gCliente = cbCliente.Text
                dtsE.gidCliente = cbCliente.SelectedItem.itemdata
            End If

            dtsE.gObservaciones = Observaciones.Text

            dtsE.gEtiquetaEditada = True

            dtsE.gActivo = ckActivo.Checked

            dtsE.gFichero = ""

            If iidEtiqueta = 0 Or iidEtiqueta = idEtiquetaPlantilla Then

                iidEtiqueta = funcE.insertar(dtsE)
                dtsE.gidEtiqueta = iidEtiqueta

            Else

                funcE.actualizar(dtsE)
                funcCE.borrarEtiqueta(iidEtiqueta)
                funcEL.borrarEtiqueta(iidEtiqueta)
                funcEN.borrarEtiqueta(iidEtiqueta)

            End If

            Dim iidCampo As Integer = 1

            For Each dts As DatosCampoEtiqueta In Campos

                If dts.gVisible Then

                    dts.gidEtiqueta = iidEtiqueta

                    dts.gidCampo = iidCampo

                    funcCE.insertar(dts)

                    iidCampo = iidCampo + 1

                End If

            Next

            iidCampo = 1

            For Each dts As DatosEtiquetaLogo In Logos

                If dts.gVisible Then

                    dts.gidEtiqueta = iidEtiqueta

                    dts.gidLogo = iidCampo

                    funcEL.insertar(dts)

                    iidCampo = iidCampo + 1

                End If

            Next

            iidCampo = 1

            For Each dts As DatosEtiquetaLinea In Lineas

                If dts.gVisible Then

                    dts.gidEtiqueta = iidEtiqueta

                    dts.gidCampo = iidCampo

                    funcEN.insertar(dts)

                    iidCampo = iidCampo + 1

                End If

            Next

        Catch ex As Exception

            ex.Data.Add("iidEtiqueta", iidEtiqueta)

            CorreoError(ex)

        End Try
    End Sub

    Private Sub bGstion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGestion.Click
        If iidEtiqueta <> idEtiquetaPlantilla Then
            Dim GG As New GestionEtiquetas
            GG.pidEtiqueta = iidEtiqueta
            GG.ShowDialog()
            EtiquetaEnProceso = New EtiquetaEditada(iidEtiqueta)
            Call CargarEtiqueta()
        End If
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call Nuevo()
    End Sub

    Private Sub bIzquierda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bIzquierda.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.Izquierda(ElementoSeleccionado, hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub bDerecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDerecha.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.Derecha(ElementoSeleccionado, hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub bSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSubir.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.Subir(ElementoSeleccionado, hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub bBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBajar.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.Bajar(ElementoSeleccionado, hsIncremento.Value)

            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbFuenteInc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbFuenteInc.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarTamañoTexto(ElementoSeleccionado, 0.2)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbFuenteDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbFuenteDec.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarTamañoTexto(ElementoSeleccionado, -0.2)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbNegrita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNegrita.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarNegrita(ElementoSeleccionado)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbItalica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbItalica.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarItalica(ElementoSeleccionado)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbAnchoDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAnchoDec.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarAncho(ElementoSeleccionado, -hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbAnchoInc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAnchoInc.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarAncho(ElementoSeleccionado, hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbAltoDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAltoDec.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarAlto(ElementoSeleccionado, -hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Sub lbAltoInc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAltoInc.Click
        If ElementoSeleccionado <> "" Then
            EtiquetaEnProceso.CambiarAlto(ElementoSeleccionado, hsIncremento.Value)
            CRV.RefreshReport()
        End If
    End Sub

    Private Function IndiceEnCampos(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < Campos.Count AndAlso UCase(Trim(Campos(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < Campos.Count Then
            Return i
        Else
            Return -1
        End If
    End Function

    Private Function IndiceEnLogos(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < Logos.Count AndAlso UCase(Trim(Logos(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < Logos.Count Then
            Return i
        Else
            Return -1
        End If
    End Function

    Private Function IndiceEnLineas(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < Lineas.Count AndAlso UCase(Trim(Lineas(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < Lineas.Count Then
            Return i
        Else
            Return -1
        End If
    End Function


#End Region

#Region "EVENTOS"

    Private Sub Etiqueta2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Etiqueta1.GotFocus, Valor1.GotFocus, Etiqueta2.GotFocus, Valor2.GotFocus, Etiqueta3.GotFocus, _
    Valor3.GotFocus, Etiqueta4.GotFocus, Valor4.GotFocus, Etiqueta5.GotFocus, Valor5.GotFocus, Etiqueta6.GotFocus, Valor6.GotFocus, Etiqueta7.GotFocus, Etiqueta8.GotFocus, Etiqueta0.GotFocus, Valor0.GotFocus, Valor0.GotFocus, Check1.GotFocus, _
    Check2.GotFocus, Check3.GotFocus, Check4.GotFocus, Check5.GotFocus, Check6.GotFocus, Check7.GotFocus, Check8.GotFocus, Check9.GotFocus
        If Semaforo And ElementoSeleccionado <> sender.name Then
            Semaforo = False
            Call DesmarcarCampos()
            sender.BackColor = SystemColors.MenuHighlight
            ObjetoSeleccionado = sender
            ElementoSeleccionado = sender.name
            Semaforo = True
        End If
    End Sub

    Private Sub Nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nombre.GotFocus, cbCliente.GotFocus, Observaciones.GotFocus, ckActivo.GotFocus

        If Semaforo Then
            Call DesmarcarCampos()
            ElementoSeleccionado = ""
            ObjetoSeleccionado = sender
        End If

    End Sub

    Private Sub LineaInferior_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Linea2.GotFocus, Linea1.GotFocus

        If Semaforo Then
            Call DesmarcarCampos()
            sender.BorderColor = SystemColors.MenuHighlight
            ElementoSeleccionado = sender.name
            ObjetoSeleccionado = sender
        End If

    End Sub

    Private Sub Logo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Logo1.Click, Logo2.Click, Logo3.Click
        If Semaforo Then
            Call DesmarcarCampos()
            If sender.name = "Logo1" Then
                Rectangulo1.BorderColor = SystemColors.MenuHighlight
            End If
            If sender.name = "Logo2" Then
                Rectangulo2.BorderColor = SystemColors.MenuHighlight
            End If
            If sender.name = "Logo3" Then
                Rectangulo3.BorderColor = SystemColors.MenuHighlight
            End If
            ElementoSeleccionado = sender.name
            ObjetoSeleccionado = sender
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        Dim bHandled As Boolean = False
        If ElementoSeleccionado <> "" Then
            Select Case keyData
                Case Keys.Up
                    EtiquetaEnProceso.Subir(ElementoSeleccionado, 10)
                    CRV.RefreshReport()
                    bHandled = True
                Case Keys.Down
                    EtiquetaEnProceso.Bajar(ElementoSeleccionado, 10)
                    CRV.RefreshReport()
                    bHandled = True
                Case Keys.Left
                    EtiquetaEnProceso.Izquierda(ElementoSeleccionado, 10)
                    CRV.RefreshReport()
                    bHandled = True
                Case Keys.Right
                    EtiquetaEnProceso.Derecha(ElementoSeleccionado, 10)
                    CRV.RefreshReport()
                    bHandled = True
            End Select

        End If

        Return bHandled

    End Function

    Private Sub Etiqueta1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Etiqueta1.TextChanged, Etiqueta8.TextChanged, Etiqueta6.TextChanged, _
       Valor5.TextChanged, Etiqueta5.TextChanged, Valor4.TextChanged, Valor6.TextChanged, Etiqueta4.TextChanged, Valor3.TextChanged, Etiqueta3.TextChanged, Valor2.TextChanged, Etiqueta2.TextChanged, Etiqueta7.TextChanged, Etiqueta0.TextChanged, Valor1.TextChanged, Valor0.TextChanged
        If Semaforo Then
            Semaforo = False
            ElementoSeleccionado = sender.name
            ObjetoSeleccionado = sender
            If ElementoSeleccionado <> "" Then
                Call ActualizacionCRV()
                ObjetoSeleccionado.focus()
            End If

            Semaforo = True
        End If
    End Sub

    Private Sub ActualizacionRetardada()
        If ActualizarAhora Then
            ActualizarAhora = False
            Retardo.Enabled = False
            CRV.ReportSource = EtiquetaEnProceso.ReportSource
            CRV.RefreshReport()
            ObjetoSeleccionado.focus()
        End If
    End Sub

    Private Sub ActualizacionCRV()
        Dim indice As Integer = IndiceEnCampos(ElementoSeleccionado)
        If indice <> -1 Then
            Campos(indice).gValorxDefecto = ObjetoSeleccionado.text
        End If
        ActualizarAhora = True
        Retardo.Enabled = True

        'CRV.ReportSource = EtiquetaEnProceso.ReportSource
        'CRV.RefreshReport()

    End Sub

    Private Sub Logo1_OnClickPress(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case sender.text
            Case "Borrar imagen"
                Logo1.Image = Nothing
                lbaviso1.Visible = True
            Case "Pegar imagen"
                If Clipboard.ContainsImage Then
                    Logo1.Image = CType(Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap), Bitmap)
                ElseIf Clipboard.ContainsFileDropList = True Then
                    MsgBox("Copie y pegue una imagen seleccionada, no un fichero de imagen")
                    'Logo1.Load(Clipboard.GetFileDropList(0))

                End If
                lbaviso1.Visible = False
        End Select
        ObjetoSeleccionado = Logo1
        ElementoSeleccionado = ObjetoSeleccionado.Name

        Dim indice As Integer = IndiceEnLogos(ElementoSeleccionado)
        If indice <> -1 Then
            Logos(indice).gLogo = Logo1.Image
        End If
        CRV.ReportSource = EtiquetaEnProceso.ReportSource
        CRV.RefreshReport()
    End Sub

    Private Sub Logo2_OnClickPress(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case sender.text
            Case "Borrar imagen"
                Logo2.Image = Nothing
                lbAviso2.Visible = True
            Case "Pegar imagen"
                If Clipboard.ContainsImage Then
                    Logo2.Image = CType(Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap), Bitmap)
                ElseIf Clipboard.ContainsFileDropList = True Then
                    MsgBox("Copie y pegue una imagen seleccionada, no un fichero de imagen")
                    'Logo2.Load(Clipboard.GetFileDropList(0))
                End If
                lbAviso2.Visible = False
        End Select
        ObjetoSeleccionado = Logo2
        ElementoSeleccionado = ObjetoSeleccionado.Name
        Dim indice As Integer = IndiceEnLogos(ElementoSeleccionado)
        If indice <> -1 Then
            Logos(indice).gLogo = Logo2.Image
        End If
        CRV.ReportSource = EtiquetaEnProceso.ReportSource
        CRV.RefreshReport()
    End Sub

    Private Sub Logo3_OnClickPress(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case sender.text
            Case "Borrar imagen"
                Logo3.Image = Nothing
                lbAviso3.Visible = True
            Case "Pegar imagen"
                If Clipboard.ContainsImage Then
                    Logo3.Image = CType(Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap), Bitmap)
                ElseIf Clipboard.ContainsFileDropList = True Then
                    MsgBox("Copie y pegue una imagen seleccionada, no un fichero de imagen")
                    'Logo3.Load(Clipboard.GetFileDropList(0))
                End If
                ObjetoSeleccionado = Logo3
                ElementoSeleccionado = ObjetoSeleccionado.Name

                lbAviso3.Visible = False
        End Select
        Dim indice As Integer = IndiceEnLogos(ElementoSeleccionado)
        If indice <> -1 Then
            Logos(indice).gLogo = Logo3.Image
        End If
        CRV.ReportSource = EtiquetaEnProceso.ReportSource
        CRV.RefreshReport()
    End Sub

#End Region

    Private Sub ckEtiqueta1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckEtiqueta1.CheckedChanged, ckLogo3.CheckedChanged, ckLogo2.CheckedChanged, _
    ckEtiqueta2.CheckedChanged, ckEtiqueta8.CheckedChanged, ckEtiqueta7.CheckedChanged, ckEtiqueta0.CheckedChanged, ckEtiqueta6.CheckedChanged, ckLinea1.CheckedChanged, ckEtiqueta5.CheckedChanged, _
    ckEtiqueta4.CheckedChanged, ckEtiqueta3.CheckedChanged, ckLogo1.CheckedChanged, ckLinea2.CheckedChanged, ckCheck1.CheckedChanged, _
    ckCheck2.CheckedChanged, ckCheck3.CheckedChanged, ckCheck4.CheckedChanged, ckCheck5.CheckedChanged, ckCheck6.CheckedChanged, _
    ckCheck7.CheckedChanged, ckCheck8.CheckedChanged, ckCheck9.CheckedChanged

        If Semaforo Then
            ElementoSeleccionado = sender.name
            ObjetoSeleccionado = sender
            If ElementoSeleccionado <> "" Then
                Call Visibilidad()
                CRV.ReportSource = EtiquetaEnProceso.ReportSource
                CRV.RefreshReport()
            End If
        End If
    End Sub

    Private Sub Visibilidad()
        Dim indice As Integer
        Select Case ElementoSeleccionado
            Case "ckEtiqueta0"
                indice = IndiceEnCampos("Etiqueta0")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta0.Checked
                indice = IndiceEnCampos("Valor0")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta0.Checked
            Case "ckEtiqueta1"
                indice = IndiceEnCampos("Etiqueta1")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta1.Checked
                indice = IndiceEnCampos("Valor1")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta1.Checked
            Case "ckEtiqueta2"
                indice = IndiceEnCampos("Etiqueta2")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta2.Checked
                indice = IndiceEnCampos("Valor2")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta2.Checked
            Case "ckEtiqueta3"
                indice = IndiceEnCampos("Etiqueta3")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta3.Checked
                indice = IndiceEnCampos("Valor3")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta3.Checked
            Case "ckEtiqueta4"
                indice = IndiceEnCampos("Etiqueta4")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta4.Checked
                indice = IndiceEnCampos("Valor4")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta4.Checked
            Case "ckEtiqueta5"
                indice = IndiceEnCampos("Etiqueta5")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta5.Checked
                indice = IndiceEnCampos("Valor5")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta5.Checked
            Case "ckEtiqueta6"
                indice = IndiceEnCampos("Etiqueta6")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta6.Checked
                indice = IndiceEnCampos("Valor6")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta6.Checked
            Case "ckEtiqueta7"
                indice = IndiceEnCampos("Etiqueta7")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta7.Checked
            Case "ckEtiqueta8"
                indice = IndiceEnCampos("Etiqueta8")
                If indice <> -1 Then Campos(indice).gVisible = ckEtiqueta8.Checked
            Case "ckLogo1"
                indice = IndiceEnLogos("Logo1")
                If indice <> -1 Then Logos(indice).gVisible = ckLogo1.Checked
            Case "ckLogo2"
                indice = IndiceEnLogos("Logo2")
                If indice <> -1 Then Logos(indice).gVisible = ckLogo2.Checked
            Case "ckLogo3"
                indice = IndiceEnLogos("Logo3")
                If indice <> -1 Then Logos(indice).gVisible = ckLogo3.Checked
            Case "ckLinea1"
                indice = IndiceEnLineas("Linea1")
                If indice <> -1 Then Lineas(indice).gVisible = ckLinea1.Checked
            Case "ckLinea2"
                indice = IndiceEnLineas("Linea2")
                If indice <> -1 Then Lineas(indice).gVisible = ckLinea2.Checked

            Case "ckCheck1"
                indice = IndiceEnCampos("Check1")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck1.Checked
            Case "ckCheck2"
                indice = IndiceEnCampos("Check2")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck2.Checked
            Case "ckCheck3"
                indice = IndiceEnCampos("Check3")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck3.Checked
            Case "ckCheck4"
                indice = IndiceEnCampos("Check4")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck4.Checked
            Case "ckCheck5"
                indice = IndiceEnCampos("Check5")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck5.Checked
            Case "ckCheck6"
                indice = IndiceEnCampos("Check6")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck6.Checked
            Case "ckCheck7"
                indice = IndiceEnCampos("Check7")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck7.Checked
            Case "ckCheck8"
                indice = IndiceEnCampos("Check8")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck8.Checked
            Case "ckCheck9"
                indice = IndiceEnCampos("Check8")
                If indice <> -1 Then Campos(indice).gVisible = ckCheck9.Checked

        End Select
    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If iidEtiqueta = 0 Then
            If Cambios Then
                If MsgBox("¿Eliminar los datos introducidos?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Call Nuevo()
                End If
            Else
                Call Nuevo()
            End If
        Else
            If MsgBox("¿Eliminar la etiqueta?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcEN.borrarEtiqueta(iidEtiqueta)
                funcEL.borrarEtiqueta(iidEtiqueta)
                funcCE.borrarEtiqueta(iidEtiqueta)
                funcE.borrar(iidEtiqueta)
                Call Limpiar()
                EtiquetaEnProceso = New EtiquetaEditada(iidEtiqueta)
                Call CargarEtiqueta()
                CRV.ReportSource = EtiquetaEnProceso.ReportSource
            End If
        End If
    End Sub

End Class