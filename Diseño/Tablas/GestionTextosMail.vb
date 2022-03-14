Public Class GestionTextosMail

    Private sBusqueda As String
    Private vSoloLectura As Boolean
    Private funcID As New funcionesIdiomas
    Private funcTM As New FuncionesTextosMails
    Private indice As Integer
    Private ep1 As New ErrorProvider
    Private ep2 As New ErrorProvider
    Private DI As New DatosIniciales
    Private semaforo As Boolean
    Private UltimoEnfocado As Control

    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Private Sub GestiónTextosMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        semaforo = False
        Call IntroducirDocumentos()
        Call introducirIdiomas()
        semaforo = True
        Call Inicializar()
        Call CargarLV()
    End Sub



#Region "INICIALIZACIÓN"

    Private Sub Inicializar()
        semaforo = False
        cbDocumento.Text = ""
        cbIdioma.Text = "CASTELLANO"
        Texto.Text = ""
        indice = -1
        ep1.Clear()
        ep2.Clear()
        lvDocumentos.SelectedItems.Clear()
        semaforo = True
    End Sub


    Private Sub IntroducirDocumentos()
        cbDocumento.Items.Clear()
        cbDocumento.Text = ""
        cbDocumento.Items.Add("PEDIDO CLIENTE") '
        cbDocumento.Items.Add("PEDIDO (FECHA_PREVISTA)") '
        cbDocumento.Items.Add("PEDIDO PROVEEDOR")
        cbDocumento.Items.Add("ALBARÁN DE PROVEEDOR") '
        cbDocumento.Items.Add("ALBARÁN A PROVEEDOR") '
        cbDocumento.Items.Add("ALBARÁN CLIENTE") '
        cbDocumento.Items.Add("FACTURA CLIENTE") '
        cbDocumento.Items.Add("FACTURA PROVEEDOR")
        cbDocumento.Items.Add("OFERTA CLIENTE") '
        cbDocumento.Items.Add("PROFORMA CLIENTE") '
        cbDocumento.Items.Add("REPARACIÓN") '
    End Sub


    Private Sub introducirIdiomas()
        Try
            cbIdioma.Items.Clear()
            Dim lista As List(Of datosIdioma) = funcID.mostrar()
            For Each dts As datosIdioma In lista
                cbIdioma.Items.Add(New IDComboBox(dts.gIdioma, dts.gidIdioma))
            Next
            cbIdioma.Text = DI.Idioma.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region




#Region "PROCEDIMIENTOS Y FUNCIONES"


    Private Sub Buscar()
        If cbDocumento.SelectedIndex <> -1 And cbIdioma.SelectedIndex <> -1 Then
            Dim dts As New DatosTextoMail
            dts.gDocumento = cbDocumento.Text
            dts.gidIdioma = cbIdioma.SelectedItem.itemData
            dts.gidTexto = funcTM.TextoExiste(dts)
            If dts.gidTexto > 0 Then
                For Each item As ListViewItem In lvDocumentos.Items
                    If item.Text = dts.gidTexto Then item.Selected = True
                Next
                dts = funcTM.Mostrar1(dts.gidTexto)
                Texto.Text = dts.gTexto
                Asunto.Text = dts.gAsunto
            End If
        End If
    End Sub


    Private Sub CargarLV()
        lvDocumentos.Items.Clear()
        Dim lista As List(Of DatosTextoMail) = funcTM.Mostrar()
        For Each dts As DatosTextoMail In lista
            Call NuevaLineaLV(dts)
        Next
    End Sub

    Private Sub NuevaLineaLV(ByVal dts As DatosTextoMail)
        With lvDocumentos.Items.Add(dts.gidTexto)
            .SubItems.Add(dts.gDocumento)
            .SubItems.Add(dts.gIdioma)
            .SubItems.Add(dts.gAsunto)
            .SubItems.Add(dts.gTexto)
        End With
    End Sub

    Private Sub ActualizarLineaLV(ByVal dts As DatosTextoMail)
        With lvDocumentos.Items(indice)
            .SubItems(1).Text = dts.gDocumento
            .SubItems(2).Text = dts.gIdioma
            .SubItems(3).Text = dts.gAsunto
            .SubItems(4).Text = dts.gTexto
        End With
    End Sub



#End Region




#Region "BOTONES GENERALES"


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Dim validar As Boolean = True
        If cbDocumento.SelectedIndex = -1 Then
            ep1.SetError(cbDocumento, "Se ha de seleccionar un documento.")
            validar = False
        End If
        If cbIdioma.SelectedIndex = -1 Then
            ep1.SetError(cbIdioma, "Se ha de seleccionar un idioma.")
            validar = False
        End If
        If Texto.Text = "" Then
            ep2.SetError(Texto, "No se ha introducido texto.")
        End If
        If Asunto.Text = "" Then
            ep1.SetError(Asunto, "No se ha introducido Asunto.")
            validar = False
        End If
        If validar Then
            Dim dts As New DatosTextoMail
            dts.gDocumento = cbDocumento.Text
            dts.gidIdioma = cbIdioma.SelectedItem.itemdata
            dts.gIdioma = cbIdioma.Text
            dts.gTexto = Texto.Text
            dts.gAsunto = Asunto.Text
            dts.gidTexto = 0
            Dim iidTextoExistente As Integer = 0
            If lvDocumentos.SelectedItems.Count > 0 Then
                'Detectamos si ya existe un texto para ese documento e idioma, si es así lo modificamos
                indice = lvDocumentos.SelectedIndices(0)
                dts.gidTexto = lvDocumentos.Items(indice).Text
                iidTextoExistente = funcTM.TextoExiste(dts)
            Else
                iidTextoExistente = funcTM.TextoExiste(dts)
            End If
            If iidTextoExistente <> dts.gidTexto Then
                dts.gidTexto = iidTextoExistente
                indice = -1
            End If
            If dts.gidTexto > 0 Then
                funcTM.actualizar(dts)
            Else
                dts.gidTexto = funcTM.insertar(dts)
            End If
            If indice = -1 Then
                Call CargarLV()
            Else
                Call ActualizarLineaLV(dts)
            End If
            Call Inicializar()
        End If
    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call Inicializar()
    End Sub


    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            Dim iidTexto As Integer = lvDocumentos.Items(indice).Text
            If MsgBox("¿Desea borrar el texto preestablecido para " & cbDocumento.Text & "?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                funcTM.borrar(iidTexto)
                lvDocumentos.Items.RemoveAt(indice)
            End If
        End If
    End Sub


    Private Sub bIncrustarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bIncrustarContacto.Click
        Call Incrustar("CONTACTO")
    End Sub


    Private Sub bIncrustarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bIncrustarDocumento.Click
        Call Incrustar("DOCUMENTO")
    End Sub

    Private Sub bIncrustarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bIncrustarFecha.Click
        Call Incrustar("FECHA")
    End Sub

    Private Sub bIncrustarFechaEntrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bIncrustarFechaEntrega.Click
        Call Incrustar("FECHA_ENTREGA")
    End Sub


    Private Sub Incrustar(ByVal Literal As String)
        Dim InsertarEn As Integer

        'If Asunto.SelectionStart > 0 Then
        If UltimoEnfocado.Name = "Asunto" Then
            InsertarEn = Asunto.SelectionStart
            Asunto.Text = Asunto.Text.Insert(InsertarEn, "<" & Literal & ">")
        ElseIf UltimoEnfocado.Name = "Texto" Then
            InsertarEn = Texto.SelectionStart
            Texto.Text = Texto.Text.Insert(InsertarEn, "<" & Literal & ">")
        End If
    End Sub


#End Region


#Region "EVENTOS"

    Private Sub lvDocumentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDocumentos.Click
        If lvDocumentos.SelectedItems.Count > 0 Then
            indice = lvDocumentos.SelectedIndices(0)
            Dim iidTexto As Integer = lvDocumentos.Items(indice).Text
            Dim dts As DatosTextoMail = funcTM.Mostrar1(iidTexto)
            cbDocumento.Text = dts.gDocumento
            cbIdioma.Text = dts.gIdioma
            Texto.Text = dts.gTexto
            Asunto.Text = dts.gAsunto
        End If
    End Sub


    Private Sub cbIdioma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIdioma.SelectedIndexChanged, cbDocumento.SelectedIndexChanged
        If semaforo Then Call Buscar()
    End Sub

#End Region



    Private Sub Asunto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Asunto.TextChanged, Texto.TextChanged, lvDocumentos.SelectedIndexChanged
        If semaforo Then UltimoEnfocado = sender
    End Sub

 

End Class