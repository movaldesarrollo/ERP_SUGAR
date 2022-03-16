Public Class GestionTiposArticulo


    Dim iidTipoArticulo As Integer
    Dim iidSubTipoArticulo As Integer
    Dim semaforo As Boolean = False ' semáforo para detectar los cambios no iniciales
    Dim vSoloLectura As Boolean = False
    Dim vidUsuario As Integer
    Dim funcF As New FuncionesTiposArticulo
    Dim funcSF As New FuncionessubTiposArticulo
    Dim funcAR As New FuncionesArticulos
    Dim iIndiceF As Integer
    Dim iIndiceSF As Integer
    Dim G_ATipoArticulo As Char
    Dim G_ASubTipoArticulo As Char


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionTiposArticulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        semaforo = True
        'Inicializar
        'Si le hemos pasado por Property que es sólo lectura, tiene prioridad, sino lo mira según el usuario
        vidUsuario = Inicio.vIdUsuario
        'If Not vSoloLectura Then
        'Dim func As New FuncionesPersonal
        'vSoloLectura = func.EsSoloLectura(vidUsuario)
        ' End If
        gbSubTiposArticulo.Enabled = False
        Call inicializarF()
        Call IntroducirTiposArticulo()
        Call inicializarSF()

    End Sub

#Region "TiposArticulo"

    Private Sub inicializarF()
        semaforo = False
        bGuardar.Text = "GUARDAR"
        G_ATipoArticulo = "G"
        bGuardar.Enabled = False
        bNuevo.Enabled = False
        bBorrar.Enabled = False
        TipoArticulo.Text = ""
        Descripcion.Text = ""
        ckActivo.Checked = True
        ckValidacion.Checked = False
        rbDomestico.Checked = False
        rbIndustrial.Checked = True
        semaforo = True
    End Sub



    Private Sub IntroducirTiposArticulo()
        lvTiposArticulo.Items.Clear()
        Dim lista As List(Of DatosTipoArticulo) = funcF.Mostrar(0, False)
        Dim dts As DatosTipoArticulo

        For Each dts In lista
            Call NuevaLineaF(dts)
        Next

    End Sub

    Private Sub NuevaLineaF(ByVal dts As DatosTipoArticulo)
        With lvTiposArticulo.Items.Add(dts.gidTipoArticulo)
            .subitems.add(dts.gTipoArticulo)
            .subitems.add(If(dts.gValidacion, "SI", "NO"))
            .subitems.add(dts.gDescripcion)
            .subitems.add(If(dts.gDescuento1, "DOMÉSTICO", "INDUSTRIAL"))
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub

    Private Sub ActualizaLineaF(ByVal dts As DatosTipoArticulo)
        'Actualizar la linea del indice global iIndiceF
        With lvTiposArticulo.Items(iIndiceF)
            .SubItems(0).Text = dts.gidTipoArticulo
            .SubItems(1).Text = dts.gTipoArticulo
            .SubItems(2).Text = If(dts.gValidacion, "SI", "NO")
            .SubItems(3).Text = dts.gDescripcion
            .SubItems(4).Text = If(dts.gDescuento1, "DOMÉSTICO", "INDUSTRIAL")
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub

    Private Sub lvTiposArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvTiposArticulo.Click
        ' Si hacemos click sobre una TipoArticulo se copia en la zona de edición 

        If lvTiposArticulo.SelectedItems.Count > 0 Then
            semaforo = False
            iIndiceF = lvTiposArticulo.SelectedIndices(0)
            With lvTiposArticulo.SelectedItems.Item(0)
                iidTipoArticulo = .SubItems(0).Text
                TipoArticulo.Text = .SubItems(1).Text
                ckValidacion.Checked = (.SubItems(2).Text = "SI")
                Descripcion.Text = .SubItems(3).Text
                ckActivo.Checked = .ForeColor <> Color.Gray
                rbDomestico.Checked = (.SubItems(4).Text = "DOMÉSTICO")
                rbIndustrial.Checked = (.SubItems(4).Text = "INDUSTRIAL")
            End With
            bGuardar.Enabled = False
            bNuevo.Enabled = True
            bBorrar.Enabled = Not vSoloLectura
            G_ATipoArticulo = "A"
            'bGuardar.Text = "GUARDAR"
            ' Y activamos las subTiposArticulo
            gbSubTiposArticulo.Enabled = True
            Call IntroducirSubTiposArticulo()
            semaforo = True
        End If

    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click


        If MsgBox("¿Borrar la TipoArticulo " & TipoArticulo.Text & " y todas las subTiposArticulo? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim Contador As Integer = funcAR.Contador(" idTipoArticulo = " & iidTipoArticulo)
            If Contador = 0 Then
                funcSF.borrarTipoArticulo(iidTipoArticulo)
                funcF.borrar(iidTipoArticulo)
                lvTiposArticulo.Items.RemoveAt(iIndiceF)
                Call inicializarF()
                lvSubTiposArticulo.Items.Clear()
                Call inicializarSF()
                gbSubTiposArticulo.Enabled = False
            Else
                MsgBox("No se puede eliminar porque existen " & Contador & " artículos con esta TipoArticulo")
            End If

        End If

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If TipoArticulo.Text <> "" Then



            Dim dts As New DatosTipoArticulo
            dts.gidTipoArticulo = iidTipoArticulo
            dts.gTipoArticulo = UCase(TipoArticulo.Text)
            dts.gActivo = ckActivo.Checked
            dts.gDescripcion = Descripcion.Text
            dts.gValidacion = ckValidacion.Checked
            dts.gDescuento1 = rbDomestico.Checked
            dts.gDescuento2 = rbIndustrial.Checked
            If G_ATipoArticulo = "G" Then
                If funcF.idTipoArticulo(TipoArticulo.Text) = 0 Then 'Si no existe ya esta TipoArticulo
                    iidTipoArticulo = funcF.insertar(dts)
                    'NuevaLineaF(dts)
                    bGuardar.Text = "GUARDAR"
                    ' MsgBox("TipoArticulo introducida correctamente. Ahora puede definir las subTiposArticulo correspondientes")
                    lvSubTiposArticulo.Items.Clear()
                    Call inicializarSF()
                    Call IntroducirTiposArticulo()
                    gbSubTiposArticulo.Enabled = True
                End If


            Else
                If MsgBox("¿Desea cambiar la TipoArticulo?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    funcF.actualizar(dts)
                    ActualizaLineaF(dts)
                End If

            End If
            Call inicializarF()
        End If

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click


        Call inicializarF()
        iidTipoArticulo = -1
        lvSubTiposArticulo.Items.Clear()
        Call inicializarSF()
        gbSubTiposArticulo.Enabled = False


    End Sub

    Private Sub Cambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoArticulo.TextChanged, ckActivo.CheckedChanged, Descripcion.TextChanged, ckValidacion.CheckedChanged, rbDomestico.CheckedChanged, rbIndustrial.CheckedChanged
        bGuardar.Enabled = (semaforo And Not vSoloLectura And TipoArticulo.Text <> "")
    End Sub

#End Region

#Region "SUBTiposArticulo"

    Private Sub inicializarSF()
        semaforo = False
        bGuardarSF.Text = "GUARDAR"
        G_ASubTipoArticulo = "G"
        bGuardarSF.Enabled = False
        bNuevoSF.Enabled = False
        bBorrar.Enabled = False
        SubTipoArticulo.Text = ""
        DescripcionSF.Text = ""
        ckActivoSF.Checked = True
        ckValidacionSF.Checked = ckValidacion.Checked
        semaforo = True
    End Sub



    Private Sub IntroducirSubTiposArticulo()
        lvSubTiposArticulo.Items.Clear()
        Dim lista As List(Of DatosSubTipoArticulo) = funcSF.Mostrar(iidTipoArticulo, 0, False)
        Dim dts As DatosSubTipoArticulo

        For Each dts In lista
            Call NuevaLineaSF(dts)
        Next

    End Sub

    Private Sub NuevaLineaSF(ByVal dts As DatosSubTipoArticulo)
        With lvSubTiposArticulo.Items.Add(dts.gidSubTipoArticulo)
            .subitems.add(dts.gSubTipoArticulo)
            .subitems.add(If(dts.gValidacion, "SI", "NO"))
            .subitems.add(dts.gDescripcion)
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub

    Private Sub ActualizaLineaSF(ByVal dts As DatosSubTipoArticulo)
        'Actualizar la linea del indice global iIndiceF
        With lvSubTiposArticulo.Items(iIndiceSF)
            .SubItems(0).Text = dts.gidSubTipoArticulo
            .SubItems(1).Text = dts.gSubTipoArticulo
            .SubItems(2).Text = If(dts.gValidacion, "SI", "NO")
            .SubItems(3).Text = dts.gDescripcion
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub


    Private Sub lvSubTiposArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSubTiposArticulo.Click
        ' Si hacemos click sobre una subTipoArticulo se copia en la zona de edición 
        If lvSubTiposArticulo.SelectedItems.Count > 0 Then
            semaforo = False
            iIndiceSF = lvSubTiposArticulo.SelectedIndices(0)
            With lvSubTiposArticulo.SelectedItems.Item(0)
                iidSubTipoArticulo = .SubItems(0).Text
                SubTipoArticulo.Text = .SubItems(1).Text
                ckValidacionSF.Checked = (.SubItems(2).Text = "SI")
                DescripcionSF.Text = .SubItems(3).Text
                ckActivoSF.Checked = .ForeColor <> Color.Gray
            End With
            bGuardarSF.Enabled = False
            bNuevoSF.Enabled = True
            bBorrarSF.Enabled = Not vSoloLectura
            'bGuardarSF.Text = "GUARDAR"
            G_ASubTipoArticulo = "A"
            semaforo = True
        End If

    End Sub

    Private Sub bBorrarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrarSF.Click

        If MsgBox("¿Borrar la subTipoArticulo " & SubTipoArticulo.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            Dim Contador As Integer = funcAR.Contador(" idSubTipoArticulo = " & iidSubTipoArticulo)
            If Contador = 0 Then
                funcSF.borrar(iidSubTipoArticulo)
                lvSubTiposArticulo.Items.RemoveAt(iIndiceSF)
                Call inicializarSF()
            Else
                MsgBox("No se puede eliminar porque existen " & Contador & " artículos con esta subTipoArticulo")
            End If

        End If

    End Sub

    Private Sub bGuardarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarSF.Click
        If SubTipoArticulo.Text <> "" Then
            Dim dts As New DatosSubTipoArticulo
            dts.gidTipoArticulo = iidTipoArticulo
            dts.gidSubTipoArticulo = iidSubTipoArticulo
            dts.gSubTipoArticulo = UCase(SubTipoArticulo.Text)
            dts.gActivo = ckActivoSF.Checked
            dts.gValidacion = ckValidacionSF.Checked
            dts.gDescripcion = DescripcionSF.Text

            If G_ASubTipoArticulo = "G" Then
                If funcSF.idSubTipoArticulo(iidTipoArticulo, SubTipoArticulo.Text) = 0 Then 'Si no existe esta subTipoArticulo
                    iidSubTipoArticulo = funcSF.insertar(dts)
                    'Call NuevaLineaSF(dts)
                    Call IntroducirSubTiposArticulo()
                End If

            Else
                funcSF.actualizar(dts)
                Call ActualizaLineaSF(dts)
            End If
            Call inicializarSF()
        End If


    End Sub

    Private Sub bNuevoSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoSF.Click
        iidSubTipoArticulo = -1
        Call inicializarSF()
    End Sub

    Private Sub CambiosSF(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubTipoArticulo.TextChanged, ckActivoSF.CheckedChanged, DescripcionSF.TextChanged, ckValidacionSF.CheckedChanged
        bGuardarSF.Enabled = (semaforo And Not vSoloLectura And SubTipoArticulo.Text <> "")
    End Sub

#End Region

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        If bGuardar.Enabled Or bGuardarSF.Enabled Then
            If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If semaforo Then
            Me.Width = 668
            'Me.Height = If(Me.Height < 510, 510, Me.Height)

        End If
    End Sub

End Class