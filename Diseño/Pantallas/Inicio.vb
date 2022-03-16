Public Class Inicio
    Private funcU As New FuncionesPersonal
    Public vIdUsuario As Integer = 0
    Public scontraseña As String = ""
    Public vIntentos As Integer
    Public vversion As String = "V" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision  'Muesta la versión del programa.
    'Public vversion As String = "v4.1.0.0"
    'Version 4.1.0.0
    'Se cambia la etiqueta de final de línea

    'Version 4.0.6
    'Se añade codigo de barras de referencia en etiquetas de equipos.

    'Version 4.0.5
    'Se modifica consulta de búsqueda pedido y pedidoAX en vista simple para agilizar el proceso. 

    'Version 4.0.4
    'Se modifica logo y color de formularios de hayward.
    'Se añaden estados de produccion en conceptos de pedidos de vista simple.

    'Version 4.0.3
    'Se modifica el formulario de etiquetas para que muestre las australianas

    'Version 4.0.2
    'Se modifica el reporte de etiquetas de equipos para que no se deforme el logo.

    'Version 4.0.1
    'Se añaden celulas de recambios en preparacion de pedidos.

    'Version 4.0 
    'Es la nueva versión optimizada para visual studio 2017 y crystal report 13.0.22.268
    'Se añaden mejoras en la gestión de códigos de barras y impresión de etiquetas.

    Property pIdUsuario() As Integer
        Get
            Return vIdUsuario
        End Get
        Set(ByVal value As Integer)
            vIdUsuario = value
        End Set
    End Property

    Private Sub Inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bEntrar.Enabled = False
        usuario.Text = ""
        contrasena.Text = ""
        vIntentos = 0
        lbVersion.Text = vversion
    End Sub

    Private Sub Contrasena_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contrasena.TextChanged
        If usuario.Text <> "" Then  'La contraseña puede estar en blanco
            bEntrar.Enabled = True
        End If
    End Sub

    Private Sub usuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usuario.TextChanged
        If usuario.Text <> "" Then  'La contraseña puede estar en blanco
            vIntentos = 0
            bEntrar.Enabled = True
        End If
    End Sub

    Private Sub bEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bEntrar.Click
        Call Entrar()
    End Sub

    Private Sub usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles usuario.KeyPress, contrasena.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            Call Entrar()
        End If
    End Sub

    Private Sub Entrar()
        If usuario.Text <> "" Then
            vIdUsuario = funcU.InicioSesion(usuario.Text, contrasena.Text)

            If vIdUsuario = -1 Or vIntentos >= 3 Then
                If vIntentos > 3 Then
                    MsgBox("Se han superado los 3 intentos. La cuenta de usuario queda desactivada. Consulte al administrador.", MsgBoxStyle.Critical)
                    funcU.Inactiva(usuario.Text)
                Else
                    'MsgBox("Usuario o contraseña no válido", MsgBoxStyle.Exclamation)
                    vIntentos = vIntentos + 1
                    contrasena.Text = ""
                End If
            Else
                Me.Visible = False

                Select Case usuario.Text

                    Case "LINEA"

                        Dim gg As New menuProduccion

                        gg.formPadre = True

                        gg.ShowDialog()

                        Me.Close()

                    Case "FINAL"

                        Dim gg As New finalLinea

                        gg.ShowDialog()

                        gg.Dispose()

                        Me.Close()

                    Case "CD"

                        Dim gg As New fabricacionCelulas

                        gg.ShowDialog()

                        Me.Close()

                    Case "ED"

                        Dim gg As New fabricacionEquipos

                        gg.ShowDialog()

                        Me.Close()

                    Case Else

                        PantallaGeneral.Show()

                End Select

            End If
        End If
    End Sub

    Private Sub bCambioContrasena_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCambioContrasena.Click

        'Cambiar Contraseña

        If usuario.Text <> "" Then

            Dim CC As New CambiarContrasena

            CC.pUsuario = usuario.Text

            CC.ShowDialog()

            contrasena.Text = CC.pContrasena

        End If

    End Sub

End Class