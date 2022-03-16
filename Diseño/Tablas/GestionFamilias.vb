Public Class GestionFamilias


    Dim iidFamilia As Integer
    Dim iidSubFamilia As Integer
    Dim semaforo As Boolean = False ' semáforo para detectar los cambios no iniciales
    Dim vSoloLectura As Boolean = False
    Dim vidUsuario As Integer
    Dim funcF As New FuncionesFamilias
    Dim funcSF As New FuncionessubFamilias
    Dim funcAR As New FuncionesArticulos
    Dim iIndiceF As Integer
    Dim iIndiceSF As Integer
    Dim G_AFamilia As Char
    Dim G_ASubFamilia As Char


    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionFamilias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        semaforo = True
        'Inicializar
        'Si le hemos pasado por Property que es sólo lectura, tiene prioridad, sino lo mira según el usuario
        vidUsuario = Inicio.vIdUsuario
        'If Not vSoloLectura Then
        'Dim func As New FuncionesPersonal
        'vSoloLectura = func.EsSoloLectura(vidUsuario)
        ' End If
        gbSubFamilias.Enabled = False
        Call inicializarF()
        Call IntroducirFamilias()
        Call inicializarSF()

    End Sub




#Region "FAMILIAS"

    Private Sub inicializarF()
        semaforo = False
        bGuardar.Text = "GUARDAR"
        G_AFamilia = "G"
        bGuardar.Enabled = False
        bNuevo.Enabled = False
        bBorrar.Enabled = False
        Familia.Text = ""
        Descripcion.Text = ""
        ckActivo.Checked = True
        ckValidacion.Checked = False
        semaforo = True
    End Sub

  

    Private Sub IntroducirFamilias()
        lvFamilias.Items.Clear()
        Dim lista As List(Of DatosFamilia) = funcF.Mostrar(0, False)
        Dim dts As DatosFamilia

        For Each dts In lista
            Call NuevaLineaF(dts)
        Next

    End Sub

    Private Sub NuevaLineaF(ByVal dts As DatosFamilia)
        With lvFamilias.Items.Add(dts.gidFamilia)
            .subitems.add(dts.gFamilia)
            .subitems.add(If(dts.gValidacion, "SI", "NO"))
            .subitems.add(dts.gDescripcion)
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub

    Private Sub ActualizaLineaF(ByVal dts As DatosFamilia)
        'Actualizar la linea del indice global iIndiceF
        With lvFamilias.Items(iIndiceF)
            .SubItems(0).Text = dts.gidFamilia
            .SubItems(1).Text = dts.gFamilia
            .SubItems(2).Text = If(dts.gValidacion, "SI", "NO")
            .SubItems(3).Text = dts.gDescripcion
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub

    Private Sub lvFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFamilias.Click
        ' Si hacemos click sobre una familia se copia en la zona de edición 

        If lvFamilias.SelectedItems.Count > 0 Then
            semaforo = False
            iIndiceF = lvFamilias.SelectedIndices(0)
            With lvFamilias.SelectedItems.Item(0)
                iidFamilia = .SubItems(0).Text
                Familia.Text = .SubItems(1).Text
                ckValidacion.Checked = (.SubItems(2).Text = "SI")
                Descripcion.Text = .SubItems(3).Text
                ckActivo.Checked = .ForeColor <> Color.Gray
            End With
            bGuardar.Enabled = False
            bNuevo.Enabled = True
            bBorrar.Enabled = Not vSoloLectura
            G_AFamilia = "A"
            'bGuardar.Text = "GUARDAR"
            ' Y activamos las subfamilias
            gbSubFamilias.Enabled = True
            Call IntroducirSubFamilias()
            semaforo = True
        End If

    End Sub

    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click


        If MsgBox("¿Borrar la familia " & Familia.Text & " y todas las subfamilias? ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim Contador As Integer = funcAR.Contador(" idFamilia = " & iidFamilia)
            If Contador = 0 Then
                funcSF.borrarFamilia(iidFamilia)
                funcF.borrar(iidFamilia)
                lvFamilias.Items.RemoveAt(iIndiceF)
                Call inicializarF()
                lvSubFamilias.Items.Clear()
                Call inicializarSF()
                gbSubFamilias.Enabled = False
            Else
                MsgBox("No se puede eliminar porque existen " & Contador & " artículos con esta familia")
            End If

        End If

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If Familia.Text <> "" Then



            Dim dts As New DatosFamilia
            dts.gidFamilia = iidFamilia
            dts.gFamilia = UCase(Familia.Text)
            dts.gActivo = ckActivo.Checked
            dts.gDescripcion = Descripcion.Text
            dts.gValidacion = ckValidacion.Checked
            If G_AFamilia = "G" Then
                If funcF.idFamilia(Familia.Text) = 0 Then 'Si no existe ya esta familia
                    iidFamilia = funcF.insertar(dts)
                    'NuevaLineaF(dts)
                    bGuardar.Text = "GUARDAR"
                    ' MsgBox("Familia introducida correctamente. Ahora puede definir las subfamilias correspondientes")
                    lvSubFamilias.Items.Clear()
                    Call inicializarSF()
                    Call IntroducirFamilias()
                    gbSubFamilias.Enabled = True
                End If


            Else
                If MsgBox("¿Desea cambiar la familia?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    funcF.actualizar(dts)
                    ActualizaLineaF(dts)
                End If

            End If
            Call inicializarF()
        End If

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click


        Call inicializarF()
        iidFamilia = -1
        lvSubFamilias.Items.Clear()
        Call inicializarSF()
        gbSubFamilias.Enabled = False


    End Sub

    Private Sub Cambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Familia.TextChanged, ckActivo.CheckedChanged, Descripcion.TextChanged, ckValidacion.CheckedChanged
        bGuardar.Enabled = (semaforo And Not vSoloLectura And Familia.Text <> "")
    End Sub

#End Region



#Region "SUBFAMILIAS"

    Private Sub inicializarSF()
        semaforo = False
        bGuardarSF.Text = "GUARDAR"
        G_ASubFamilia = "G"
        bGuardarSF.Enabled = False
        bNuevoSF.Enabled = False
        bBorrar.Enabled = False
        SubFamilia.Text = ""
        DescripcionSF.Text = ""
        ckActivoSF.Checked = True
        ckValidacionSF.Checked = ckValidacion.Checked
        semaforo = True
    End Sub

   

    Private Sub IntroducirSubFamilias()
        lvSubFamilias.Items.Clear()
        Dim lista As List(Of DatosSubFamilia) = funcSF.Mostrar(iidFamilia, 0, False)
        Dim dts As DatosSubFamilia

        For Each dts In lista
            Call NuevaLineaSF(dts)
        Next

    End Sub

    Private Sub NuevaLineaSF(ByVal dts As DatosSubFamilia)
        With lvSubFamilias.Items.Add(dts.gidSubFamilia)
            .subitems.add(dts.gSubFamilia)
            .subitems.add(If(dts.gValidacion, "SI", "NO"))
            .subitems.add(dts.gDescripcion)
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub

    Private Sub ActualizaLineaSF(ByVal dts As DatosSubFamilia)
        'Actualizar la linea del indice global iIndiceF
        With lvSubFamilias.Items(iIndiceSF)
            .SubItems(0).Text = dts.gidSubFamilia
            .SubItems(1).Text = dts.gSubFamilia
            .SubItems(2).Text = If(dts.gValidacion, "SI", "NO")
            .SubItems(3).Text = dts.gDescripcion
            .ForeColor = (If(dts.gActivo, Color.Black, Color.Gray))
        End With
    End Sub


    Private Sub lvSubFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSubFamilias.Click
        ' Si hacemos click sobre una subfamilia se copia en la zona de edición 
        If lvSubFamilias.SelectedItems.Count > 0 Then
            semaforo = False
            iIndiceSF = lvSubFamilias.SelectedIndices(0)
            With lvSubFamilias.SelectedItems.Item(0)
                iidSubFamilia = .SubItems(0).Text
                SubFamilia.Text = .SubItems(1).Text
                ckValidacionSF.Checked = (.SubItems(2).Text = "SI")
                DescripcionSF.Text = .SubItems(3).Text
                ckActivoSF.Checked = .ForeColor <> Color.Gray
            End With
            bGuardarSF.Enabled = False
            bNuevoSF.Enabled = True
            bBorrarSF.Enabled = Not vSoloLectura
            'bGuardarSF.Text = "GUARDAR"
            G_ASubFamilia = "A"
            semaforo = True
        End If

    End Sub

    Private Sub bBorrarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrarSF.Click

        If MsgBox("¿Borrar la subfamilia " & SubFamilia.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            Dim Contador As Integer = funcAR.Contador(" idSubFamilia = " & iidSubFamilia)
            If Contador = 0 Then
                funcSF.borrar(iidSubFamilia)
                lvSubFamilias.Items.RemoveAt(iIndiceSF)
                Call inicializarSF()
            Else
                MsgBox("No se puede eliminar porque existen " & Contador & " artículos con esta subfamilia")
            End If

        End If

    End Sub

    Private Sub bGuardarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardarSF.Click
        If SubFamilia.Text <> "" Then
            Dim dts As New DatosSubFamilia
            dts.gidFamilia = iidFamilia
            dts.gidSubFamilia = iidSubFamilia
            dts.gSubFamilia = UCase(SubFamilia.Text)
            dts.gActivo = ckActivoSF.Checked
            dts.gValidacion = ckValidacionSF.Checked
            dts.gDescripcion = DescripcionSF.Text

            If G_ASubFamilia = "G" Then
                If funcSF.idSubFamilia(iidFamilia, SubFamilia.Text) = 0 Then 'Si no existe esta subfamilia
                    iidSubFamilia = funcSF.insertar(dts)
                    'Call NuevaLineaSF(dts)
                    Call IntroducirSubFamilias()
                End If

            Else
                funcSF.actualizar(dts)
                Call ActualizaLineaSF(dts)
            End If
            Call inicializarSF()
        End If


    End Sub

    Private Sub bNuevoSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevoSF.Click
        iidSubFamilia = -1
        Call inicializarSF()
    End Sub

    Private Sub CambiosSF(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubFamilia.TextChanged, ckActivoSF.CheckedChanged, DescripcionSF.TextChanged, ckValidacionSF.CheckedChanged
        bGuardarSF.Enabled = (semaforo And Not vSoloLectura And SubFamilia.Text <> "")
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