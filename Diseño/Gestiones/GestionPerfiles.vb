Public Class GestionPerfiles

    Dim semaforo As Boolean = False ' semáforo para detectar los cambios no iniciales
    Dim FuncP As New funcionesPerfiles
    Dim vSoloLectura As Boolean
    Dim iidPerfil As Integer

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Private Sub GestionTiposMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Inicializar
        semaforo = False

        'Call IntroducirPantallas()
        Call inicializar()

    End Sub

    Private Sub inicializar()
        semaforo = False

        Call IntroducirPerfiles()
        bGuardar.Text = "GUARDAR"
        bGuardar.Enabled = False
        bNuevo.Enabled = False
        bBorrar.Enabled = False
        iidPerfil = 0
        Perfil.Text = ""
        Descripcion.Text = ""
        'cbPantalla.Text = ""
        'ckSoloLectura.Checked = False
        semaforo = True
    End Sub



   

    Private Sub IntroducirPerfiles()
        lvPerfiles.Items.Clear()
        Dim lista As List(Of datosPerfiles) = FuncP.mostrar()
        For Each dts As datosPerfiles In lista
            With lvPerfiles.Items.Add(dts.gidPerfil)
                .SubItems.Add(dts.gPerfil)
                .SubItems.Add(dts.gdescripcion)
            End With
        Next

    End Sub

    'Private Sub IntroducirPantallas()
    '    cbPantalla.Items.Clear()
    '    Dim dt As DataTable = FuncP.Pantallas()
    '    Dim linea As DataRow
    '    For Each linea In dt.Rows
    '        If linea("Pantalla") Is DBNull.Value Then
    '        Else
    '            cbPantalla.Items.Add(linea("Pantalla"))
    '        End If
    '    Next

    'End Sub



    Private Sub lvPerfiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPerfiles.Click
        ' Si hacemos click sobre un tipo de caducidad se copia en la zona de edición 
        If lvPerfiles.SelectedItems.Count > 0 Then

            With lvPerfiles.SelectedItems.Item(0)
                iidPerfil = .SubItems(0).Text
                Perfil.Text = .SubItems(1).Text
                Descripcion.Text = .SubItems(2).Text
                'cbPantalla.Text = .SubItems(2).Text
                'ckSoloLectura.Checked = .ForeColor = Color.Orange
            End With
            bGuardar.Enabled = False
            bNuevo.Enabled = True
            bBorrar.Enabled = Not vSoloLectura
            bGuardar.Text = "ACTUALIZAR"

        End If

    End Sub



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        If bGuardar.Enabled Then
            If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub


    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click

        If iidPerfil > 0 Then
            If MsgBox("¿Borrar el perfil " & Perfil.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                FuncP.borrar(iidPerfil)
                Call inicializar()
            End If

        End If



    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click

        Dim dts As New datosPerfiles
        dts.gidPerfil = iidPerfil
        dts.gPerfil = UCase(Perfil.Text)
        dts.gDescripcion = Descripcion.Text
       
        If bGuardar.Text = "GUARDAR" Then
            FuncP.insertar(dts)
            bGuardar.Text = "ACTUALIZAR"
        Else
            FuncP.actualizar(dts)
        End If
        Call inicializar()


    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call inicializar()
    End Sub


    Private Sub Cambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Perfil.TextChanged, Descripcion.TextChanged
        bGuardar.Enabled = semaforo And Not vSoloLectura
    End Sub

    Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If semaforo Then
            Me.Width = 813
            ' Me.Height = If(Me.Height < 510, 510, Me.Height)
            ' lvPerfiles.Height = Me.Height - 241
            ' GroupBox1.Height = Me.Height - 85

        End If
    End Sub



End Class