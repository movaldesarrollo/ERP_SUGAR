Public Class GestionSubTiposProduccion

    Private iidTipoArticulo As Integer
    Private iidSubTipoArticulo As Integer
    Private iidAgrupacion As Integer
    Private indiceST As Integer
    Private funcF As New FuncionesTiposArticulo
    Private funcSF As New FuncionessubTiposArticulo
    Private funcAG As New FuncionesAgrupacionesArticulo
    Private vSoloLectura As Boolean

    Public Property soloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property

    Private Sub GestionAgrupacionesProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bGuardar.Enabled = Not vSoloLectura
        Call IntroducirTiposArticulo()
        Call IntroducirAgrupacionessArticulo()
    End Sub

    Private Sub LimpiarEdicion()
        subTipo.Text = ""
        cbAgrupaciones.Text = ""
        cbAgrupaciones.SelectedIndex = -1
        indiceST = -1
        iidAgrupacion = 0

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
            .subitems.add(dts.gDescripcion)
        End With
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
            .subitems.add(dts.gDescripcion)
            .subitems.add(dts.gAgrupacion)
            .subitems.add(dts.gidAgrupacion)
        End With
    End Sub


    Private Sub ActualizarLineaST(ByVal dts As DatosSubTipoArticulo)
        If indiceST > -1 Then
            With lvSubTiposArticulo.Items(indiceST)
                .SubItems(3).Text = dts.gAgrupacion
                .SubItems(4).Text = dts.gidAgrupacion
            End With
        End If
    End Sub


    Private Sub IntroducirAgrupacionessArticulo()
        Dim lista As List(Of DatosAgrupacionArticulo) = funcAG.Mostrar(0)
        cbAgrupaciones.Items.Clear()
        cbAgrupaciones.Items.Add("")
        For Each dts As DatosAgrupacionArticulo In lista
            cbAgrupaciones.Items.Add(dts)
        Next
    End Sub


    Private Sub lvTiposArticulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvTiposArticulo.Click, lvTiposArticulo.SelectedIndexChanged
        If lvTiposArticulo.SelectedItems.Count > 0 Then
            Call LimpiarEdicion()
            iidTipoArticulo = lvTiposArticulo.SelectedItems(0).Text
            Call IntroducirSubTiposArticulo()

        End If
    End Sub


    Private Sub lvSubTiposArticulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSubTiposArticulo.Click
        If lvSubTiposArticulo.SelectedItems.Count > 0 Then
            indiceST = lvSubTiposArticulo.SelectedIndices(0)
            iidSubTipoArticulo = lvSubTiposArticulo.Items(indiceST).Text
            Dim dts As DatosSubTipoArticulo = funcSF.Mostrar1(iidSubTipoArticulo)
            subTipo.Text = dts.gSubTipoArticulo
            cbAgrupaciones.Text = dts.gAgrupacion
        End If

    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If lvSubTiposArticulo.SelectedItems.Count > 0 And cbAgrupaciones.SelectedIndex <> -1 Then
            Dim dts As DatosSubTipoArticulo = funcSF.Mostrar1(iidSubTipoArticulo)
            If cbAgrupaciones.Text = "" Then
                dts.gidAgrupacion = 0
                dts.gAgrupacion = ""
            Else
                dts.gidAgrupacion = cbAgrupaciones.SelectedItem.gidAgrupacion
                dts.gAgrupacion = cbAgrupaciones.SelectedItem.gAgrupacion
            End If
            funcSF.actualizarAgrupacion(dts)
            Call ActualizarLineaST(dts)
            Call LimpiarEdicion()
        End If
    End Sub


    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call LimpiarEdicion()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


   
    Private Sub bAgrupacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAgrupacion.Click
        Dim GG As New GestionAgrupacionesProduccion
        GG.soloLectura = vSoloLectura
        GG.ShowDialog()
        Call IntroducirAgrupacionessArticulo()
        If GG.pidAgrupacion <> 0 Then
            Dim dts As DatosAgrupacionArticulo = funcAG.Mostrar1(GG.pidAgrupacion)
            cbAgrupaciones.Text = dts.gAgrupacion
        End If

    End Sub


End Class