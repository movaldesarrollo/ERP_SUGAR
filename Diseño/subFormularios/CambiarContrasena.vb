Public Class CambiarContrasena

    Dim vUsuario As String = ""

    Private Sub CambiarContrasena_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Contrasena1.Text = ""
        Contrasena2.Text = ""
    End Sub
    Property pContrasena()
        Get
            If Contrasena1.Text = Contrasena2.Text Then
                Return Contrasena1.Text
            Else
                Return ""
            End If
        End Get
        Set(ByVal value)
            ContrasenaA.Text = value
        End Set
    End Property
    Property pUsuario()
        Get
            Return vUsuario
        End Get
        Set(ByVal value)
            vUsuario = value
        End Set
    End Property

    Private Sub usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Contrasena2.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            Call Guardar()
        End If
    End Sub

    Private Sub bEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEntrar.Click
        Call Guardar()
    End Sub

    Private Sub Guardar()
        Dim func As New FuncionesPersonal
        Dim vIdPersona As Integer = func.InicioSesion(vUsuario, ContrasenaA.Text)
        If vIdPersona = -1 Then
            MsgBox("Usuario o contraseña no válido")
        Else
            If Contrasena1.Text <> Contrasena2.Text Then
                MsgBox("Las contraseñas introducidas son diferentes")
            Else
                func.actualizarContrasena(vIdPersona, Contrasena1.Text)
                Me.Close()
            End If
        End If

    End Sub

End Class