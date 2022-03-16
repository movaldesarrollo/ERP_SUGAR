Public Class GestionAgrupacionesProduccion

  
    Private iidAgrupacion As Integer
    Private indice As Integer
    Private dts As DatosAgrupacionArticulo
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

    Public Property pidAgrupacion() As Integer
        Get
            Return iidAgrupacion
        End Get
        Set(ByVal value As Integer)
            iidAgrupacion = value
        End Set
    End Property


    Private Sub GestionAgrupacionesProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        Call limpiarEdicion()
        Call IntroducirAgrupacionessArticulo()
    End Sub


    Private Sub limpiarEdicion()
        Agrupacion.Text = ""
        Descripcion.Text = ""
        indice = -1
    End Sub

    Private Sub IntroducirAgrupacionessArticulo()
        lvAgrupaciones.Items.Clear()
        Dim lista As List(Of DatosAgrupacionArticulo) = funcAG.Mostrar(0)
        Dim dts As DatosAgrupacionArticulo
        For Each dts In lista
            Call NuevaLineaAG(dts)
        Next
    End Sub

    Private Sub NuevaLineaAG(ByVal dts As DatosAgrupacionArticulo)
        With lvAgrupaciones.Items.Add(dts.gidAgrupacion)
            .subitems.add(dts.gAgrupacion)
            .subitems.add(dts.gDescripcion)
        End With
    End Sub


    Private Sub ActualizarLineaAG()
        If indice <> -1 Then
            With lvAgrupaciones.Items(indice)
                .SubItems(1).Text = dts.gAgrupacion
                .SubItems(2).Text = dts.gDescripcion
            End With
        End If
    End Sub

    Private Sub lvAgrupaciones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAgrupaciones.Click, lvAgrupaciones.SelectedIndexChanged
        If lvAgrupaciones.SelectedItems.Count > 0 Then
            indice = lvAgrupaciones.SelectedIndices(0)
            iidAgrupacion = lvAgrupaciones.Items(indice).Text
            dts = funcAG.Mostrar1(iidAgrupacion)
            Agrupacion.Text = dts.gAgrupacion
            Descripcion.Text = dts.gDescripcion
        End If
    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If Agrupacion.Text <> "" Then
            dts = New DatosAgrupacionArticulo
            dts.gAgrupacion = Agrupacion.Text
            dts.gDescripcion = Descripcion.Text
            If lvAgrupaciones.SelectedItems.Count > 0 Then
                indice = lvAgrupaciones.SelectedIndices(0)
                iidAgrupacion = lvAgrupaciones.Items(indice).Text
                dts.gidAgrupacion = iidAgrupacion
                funcAG.actualizar(dts)
                Call ActualizarLineaAG()
            Else
                iidAgrupacion = 0
                dts.gidAgrupacion = funcAG.insertar(dts)
                Call NuevaLineaAG(dts)
            End If
        End If
    End Sub


    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click

        funcAG.borrar(iidAgrupacion)
    End Sub


    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub


    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call limpiarEdicion()
    End Sub

End Class