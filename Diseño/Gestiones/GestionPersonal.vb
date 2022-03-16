Public Class GestionPersonal


    Private iidPersona As Integer
    Private semaforo As Boolean = False ' semáforo para detectar los cambios no iniciales
    Private funcU As New FuncionesPersonal
    Private vContrasena As String
    Private vSoloLectura As Boolean
    Private funcDT As New funcionesDepartamentos
    Private funcCT As New funcionesContactos
    Private funcML As New FuncionesMails
    Private ep1 As New ErrorProvider 'Para las validaciones
    Private ep2 As New ErrorProvider  'Para los avisos
    Private ep3 As New ErrorProvider 'Para la contraseña
    Private iidContacto As Integer
    Private G_AGeneral As Char

    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Private Sub GestionTiposMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Inicio.usuario.Text = "ADMON" Then
            Contrasena1.PasswordChar = ""
        End If
        'Inicializar
        bGuardar.Enabled = Not vSoloLectura
        bBorrar.Enabled = Not vSoloLectura
        ep1.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep2.Icon = My.Resources.Resources.info
        ep3.BlinkStyle = ErrorBlinkStyle.NeverBlink
        ep3.Icon = My.Resources.eventlogWarn
        Contrasena2.Enabled = False
        'Contrasena2.TabStop = False
        Call inicializar()
        Call introducirDepartamentos()
        Call IntroducirPersonas()
        Call introducirPerfiles()
    End Sub

    Private Sub inicializar()
        semaforo = False
        Call IntroducirPersonas()
        G_AGeneral = "G"
        codPersonal.Text = ""
        Nombre.Text = ""
        Apellidos.Text = ""
        Usuario.Text = ""
        Contrasena1.Text = ""
        Contrasena2.Text = ""
        Contrasena2.Enabled = False
        Mail.Text = ""
        iidContacto = 0
        iidPersona = 0
        cbPerfil.Text = ""
        cbDepartamento.Text = ""
        ckValida.Checked = False
        ckActivo.Checked = True
        ckResponsable.Checked = False
        ckResponsablePR.Checked = False
        ckRecibeAvisos.Checked = False
        ep1.Clear()
        ep2.Clear()
        semaforo = True
    End Sub

    Private Sub introducirDepartamentos()
        Try
            Dim lista As List(Of datosDepartamento) = funcDT.mostrar
            Dim dts As datosDepartamento
            For Each dts In lista
                cbDepartamento.Items.Add(New IDComboBox(dts.gDepartamento, dts.gidDepartamento))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub introducirPerfiles()
        Try
            cbPerfil.Items.Clear()
            Dim func As New funcionesPerfiles
            Dim lista As List(Of datosPerfiles) = func.mostrar()
            For Each dts As datosPerfiles In lista
                cbPerfil.Items.Add(New IDComboBox(dts.gPerfil, dts.gidPerfil))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub IntroducirPersonas()
        'Rellenar el listview de personal
        Try


            lvPersonas.Items.Clear()
            Dim Lista As List(Of DatosPersonal) = funcU.Mostrar
            Dim dts As DatosPersonal
            For Each dts In Lista
                With lvPersonas.Items.Add(dts.gidPersona)
                    .subitems.add(dts.gcodPersonal)
                    .subitems.add(UCase(dts.gNombre))
                    .subitems.add(UCase(dts.gApellidos))
                    .subitems.add(UCase(dts.gDepartamento))
                    .subitems.add(If(dts.gValidaPedidosProv, "SI", "NO"))
                    If Not dts.gActivo Then
                        .forecolor = Color.Gray
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Private Sub lvPersonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPersonas.Click
        ' Si hacemos click sobre una persona se copia en la zona de edición 
        If lvPersonas.SelectedItems.Count > 0 Then
            iidPersona = lvPersonas.SelectedItems(0).Text
            Dim dts As DatosPersonal = funcU.Mostrar1(iidPersona)
            codPersonal.Text = dts.gcodPersonal
            Nombre.Text = UCase(dts.gNombre)
            Apellidos.Text = UCase(dts.gApellidos)
            cbDepartamento.Text = UCase(dts.gDepartamento)
            ckValida.Checked = dts.gValidaPedidosProv
            Usuario.Text = dts.gUsuario
            vContrasena = dts.gContrasena
            Contrasena1.Text = vContrasena
            Contrasena2.Text = ""
            Contrasena2.Enabled = False
            ckActivo.Checked = dts.gActivo
            ckResponsable.Checked = dts.gResponsableCuenta
            ckResponsablePR.Checked = dts.gResponsableProd
            ckRecibeAvisos.Checked = dts.gRecibeAvisos
            cbPerfil.Text = dts.gPerfil
            Mail.Text = dts.gmail
            iidContacto = dts.gidContacto
            G_AGeneral = "A"
          
        End If



    End Sub



    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        If bGuardar.Enabled Then
            ' If MsgBox("Salir sin guardar los cambios", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Me.Close()
            'End If
        Else
            Me.Close()
        End If
    End Sub


    Private Sub bBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBorrar.Click

        'Dim func As New FuncionesPersonal
        If MsgBox("¿Borrar la persona " & Nombre.Text & " " & Apellidos.Text & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then


            funcU.borrar(iidPersona)
            Call inicializar()
        End If

    End Sub

    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        ep1.Clear()
        ep2.Clear()
        Dim Validar As Boolean = True
        If Nombre.Text = "" Then
            Validar = False
            ep1.SetError(Nombre, "Debe introduzca un nombre")
        End If

        If cbPerfil.SelectedIndex = -1 Then
            Validar = False
            ep1.SetError(cbPerfil, "Debe seleccionar un perfil")
        End If
        If funcU.ExisteUsuario(Usuario.Text, iidPersona) Then
            Validar = False
            ep1.SetError(Usuario, "Ya existe otra persona con ese usuario")
        End If
        If codPersonal.Text = "" Then
            ep2.SetError(codPersonal, "No se ha especificado un código de personal")
        Else
            If funcU.ExistecodPersonal(codPersonal.Text, iidPersona) Then
                ep1.SetError(codPersonal, "Ya existe una pesona con este código")
            End If
        End If
        If Contrasena2.Enabled And Contrasena1.Text <> Contrasena2.Text Then
            Validar = False
            ep1.SetError(Contrasena1, "Las contraseñas son diferentes")
        End If
        If Validar Then
            Dim dts As New DatosPersonal
            dts.gidPersona = iidPersona
            dts.gNombre = ""
            dts.gApellidos = ""
            dts.gidDepartamento = 0
            dts.gValidaPedidosProv = ckValida.Checked
            dts.gActivo = ckActivo.Checked
            dts.gUsuario = Usuario.Text
            dts.gContrasena = Contrasena1.Text
            dts.gidPerfil = cbPerfil.SelectedItem.itemdata
            dts.gmail = ""
            dts.gDepartamento = ""
            dts.gidContacto = iidContacto
            dts.gcodPersonal = codPersonal.Text
            'dts.gGestionaPersonal = ckGestionPErsonal.Checked
            dts.gResponsableCuenta = ckResponsable.Checked
            dts.gResponsableProd = ckResponsablePR.Checked
            dts.gRecibeAvisos = ckRecibeAvisos.Checked
            Dim dtsC As New datosContacto
            dtsC.gidContacto = iidContacto
            dtsC.gapellidos = UCase(Apellidos.Text)
            dtsC.gCargo = ""
            dtsC.gDepartamento = cbDepartamento.Text
            dtsC.gidDepartamento = If(cbDepartamento.SelectedIndex > -1, cbDepartamento.SelectedItem.itemData, 0)
            dtsC.gidProveedor = 0
            dtsC.gidUbicacion = 0
            dtsC.gnombre = UCase(Nombre.Text)
            dtsC.gObservaciones = ""

            If G_AGeneral = "G" Then
                iidContacto = funcCT.insertar(dtsC)
                dts.gidContacto = iidContacto

                iidPersona = funcU.insertar(dts)
                'G_AGeneral = "A"
                'MsgBox("Personal guardado correctamente.")
            Else
                funcCT.actualizar(dtsC)
                funcML.borrarContacto(iidContacto)

                funcU.actualizar(dts)
                'MsgBox("Personal actualizado correctamente.")
            End If

            Dim dtsM As New DatosMail
            dtsM.gidContacto = iidContacto
            dtsM.gidProveedor = 0
            dtsM.gidUbicacion = 0
            'dtsM.gmail = Mail.Text

            Dim TextoCorreo As String = Mail.Text
            Dim coma As Integer
            Dim CorreoAdd As String
            Dim orden As Integer = 1
            Dim validoMail As Boolean = True
            While Len(TextoCorreo) > 0
                dtsM.gOrden = orden
                coma = InStr(TextoCorreo, ";")
                If coma = 0 Then
                    If TextoCorreo <> "" Then
                        dtsM.gidContacto = iidContacto
                        dtsM.gmail = Trim(TextoCorreo)
                        If funcML.insertar(dtsM) = 0 Then validoMail = validoMail = False
                        orden = orden + 1
                    End If
                    TextoCorreo = ""
                Else
                    CorreoAdd = Trim(Microsoft.VisualBasic.Left(TextoCorreo, coma - 1))
                    If CorreoAdd <> "" Then
                        dtsM.gidContacto = iidContacto
                        dtsM.gmail = CorreoAdd
                        If funcML.insertar(dtsM) = 0 Then validoMail = validoMail = False
                        orden = orden + 1
                    End If
                    TextoCorreo = Microsoft.VisualBasic.Right(TextoCorreo, Len(TextoCorreo) - coma)
                End If

            End While

            If G_AGeneral = "G" Then
                G_AGeneral = "A"
                If validoMail Then
                    MsgBox("Personal guardado correctamente.")
                Else
                    MsgBox("Personal guardado (excepto correo no válido).")
                End If

            Else
                If validoMail Then
                    MsgBox("Personal actualizado correctamente.")
                Else
                    MsgBox("Personal actualizado (excepto correo no válido).")
                End If

            End If



            'Dim func As New FuncionesPersonal

            Call inicializar()
        End If

    End Sub

    Private Sub bNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNuevo.Click
        Call inicializar()
    End Sub


    'Private Sub Cambios(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nombre.TextChanged, Apellidos.TextChanged, cbDepartamento.SelectedIndexChanged, Contrasena1.TextChanged, Usuario.TextChanged, ckActivo.CheckedChanged, ckSoloLectura.CheckedChanged, Mail.TextChanged, ckValida.CheckedChanged
    '    If semaforo Then
    '        If Nombre.Text <> "" And Usuario.Text <> "" And cbDepartamento.SelectedIndex <> -1 And cbPerfil.SelectedIndex <> -1 Then
    '            bGuardar.Enabled = Not vSoloLectura
    '        End If
    '    End If
    'End Sub

    'Private Sub CambiaContrasena2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Contrasena2.LostFocus
    '    If Contrasena2.Enabled Then
    '        'If semaforo Then
    '        '    If Nombre.Text <> "" And Usuario.Text <> "" And cbDepartamento.SelectedIndex <> -1 And cbPerfil.SelectedIndex <> -1 Then
    '        '        bGuardar.Enabled = Not vSoloLectura
    '        '    End If
    '        'End If
    '        If Contrasena1.Text = Contrasena2.Text Then
    '            Contrasena2.Enabled = False
    '            Contrasena2.TabStop = False
    '        Else
    '            MsgBox("Las contraseñas no son iguales")
    '            Contrasena1.Focus()
    '            Contrasena1.Text = ""
    '            Contrasena2.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub CambiaContrasena(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Contrasena1.LostFocus
    '    If semaforo Then
    '        If Contrasena1.Text <> vContrasena Then
    '            If MsgBox("Confirmar contraseña", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
    '                Contrasena2.Enabled = True
    '                Contrasena2.Focus()
    '            Else
    '                Contrasena1.Text = vContrasena
    '            End If

    '        End If

    '        'If Nombre.Text <> "" And Usuario.Text <> "" And cbDepartamento.SelectedIndex <> -1 And cbPerfil.SelectedIndex <> -1 Then
    '        '    bGuardar.Enabled = Not vSoloLectura
    '        'End If
    '    End If

    'End Sub

    'Private Sub CambioPerfil(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Al cambiar el perfil, escribir la descripción

    '    If semaforo Then
    '        Dim func As New funcionesPerfiles
    '        Dim dt As DataTable = func.mostrar(cbPerfil.Text)
    '        Dim linea As DataRow
    '        For Each linea In dt.Rows
    '            DescripcionPerfil.Text = If(linea("descripcion") Is DBNull.Value, "", linea("descripcion"))
    '            ckSoloLectura.Checked = If(linea("SoloLectura") Is DBNull.Value, False, linea("SoloLectura"))
    '        Next

    '        If Nombre.Text <> "" And Usuario.Text <> "" And cbDepartamento.SelectedIndex <> -1 And cbPerfil.SelectedIndex <> -1 Then
    '            bGuardar.Enabled = Not vSoloLectura
    '        End If

    '    End If
    'End Sub

    'Private Sub altura_Cambio(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
    '    If semaforo Then
    '        Me.Width = 797
    '        Me.Height = If(Me.Height < 510, 510, Me.Height)
    '        lvPersonas.Height = Me.Height - 210
    '        GroupBox1.Height = Me.Height - 85

    '    End If
    'End Sub
    Private Sub Contrasena1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Contrasena1.TextChanged
        If Contrasena2.Enabled Then
            If Contrasena1.Text = Contrasena2.Text Then
                ep3.Clear()
            Else
                ep3.SetError(Contrasena2, "Contraseñas diferentes")
            End If
        Else
            Contrasena2.Text = ""
            Contrasena2.Enabled = True
        End If
    End Sub




    Private Sub Contrasena2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Contrasena2.TextChanged
        If Contrasena2.Enabled Then
            If Contrasena1.Text = Contrasena2.Text Then
                ep3.Clear()
            Else
                ep3.SetError(Contrasena2, "Contraseñas diferentes")
            End If
        End If
    End Sub

    
End Class