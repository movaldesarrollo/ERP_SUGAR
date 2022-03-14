Imports Microsoft.Office.Interop
Imports System.Net.Mail
Imports System.Net

Module FuncionesCorreo

    Private DI As New DatosIniciales

    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    '**** Funciones de correo directo


    Function correo(ByVal Asunto As String, ByVal Texto As String, ByVal Remitente As String, ByVal Destinatario As String, ByVal Adjunto As String) As Boolean
        Try
            If Destinatario = "" Then
                MsgBox("Dirección de e-mail del destinatario no definida.")
                Return False
            ElseIf InStr(Destinatario, "@") = 0 Then  'Mínima comprobación del correo: que tenga @ y "."
                MsgBox("Dirección de e-mail del destinatario incorrecta")
                Return False
            ElseIf InStr(Destinatario, ".") = 0 Then
                MsgBox("Dirección de e-mail del destinatario incorrecta")
                Return False
            ElseIf DI.SMTPUsuario = "" Or DI.SMTPServidor = "" Then
                MsgBox("Configuración de correo no válida. Configure los datos de correo en los Datos Inciales.")
                Return False
            Else
                Dim coma As Integer
                Dim DestinatarioAdd As String
                Dim func As New Master
                Dim mm As New Net.Mail.MailMessage

                Texto = Texto & vbCrLf & vbCrLf & vbCrLf & "Este mensaje se ha generado automáticamente desde la aplicación ERP_SUGAR."

                mm.IsBodyHtml = False
                mm.Body = Texto
                mm.Subject = Asunto
                mm.From = New Net.Mail.MailAddress(DI.SMTPUsuario)
                While Len(Destinatario) > 0
                    coma = InStr(Destinatario, ";")
                    If coma = 0 Then
                        mm.To.Add(Trim(Destinatario))
                        Destinatario = ""
                    Else
                        DestinatarioAdd = Left(Destinatario, coma - 1)
                        mm.To.Add(Trim(DestinatarioAdd))
                        Destinatario = Microsoft.VisualBasic.Right(Destinatario, Len(Destinatario) - coma)
                    End If

                End While
                Dim client As New Net.Mail.SmtpClient(DI.SMTPServidor, DI.SMTPPuerto)
                client.UseDefaultCredentials = Not DI.SMTPAutenticado
                client.Credentials = New Net.NetworkCredential(DI.SMTPUsuario, DI.SMTPPassword)
                client.EnableSsl = DI.SMTPSSL
                If Adjunto <> "" Then
                    mm.Attachments.Add(New Net.Mail.Attachment(Adjunto))
                End If
                client.Send(mm)
                Return True
            End If

        Catch ex As Exception
            ex.Data.Add("Asunto", Asunto)
            ex.Data.Add("Remitente", Remitente)
            ex.Data.Add("Destinatario", Destinatario)
            CorreoError(ex)
            Return False
        End Try
    End Function


    
    Function CorreoEvento(ByVal Asunto As String, ByVal Texto As String, ByVal iidPersona As Integer, ByVal iidEvento As Integer, ByVal Adjunto As String) As Boolean
        'Realiza el envio de un correo asociado a un evento a los destinatarios adecuados
        'Dim Creador As String = ""
        'Dim funcE As New FuncionesEventosCorreo
        'Dim Destinatarios As String = funcE.Destinatarios(iidEvento)
        'If funcE.CampoAviso(iidEvento) Then
        '    Dim funcP As New FuncionesPersonal
        '    Creador = funcP.campoCorreo(iidPersona)
        '    If Destinatarios = "" Then
        '        Destinatarios = Creador
        '    Else
        '        Destinatarios = Creador & "; " & Destinatarios
        '    End If
        'End If
        'Call correo(Asunto, Texto, "", Destinatarios, Adjunto)

    End Function

    Public Function CorreoOutlook(ByVal Documento As String, ByVal Remitente As String, ByVal Destinatario As String, ByVal Adjunto As String, ByVal Contacto As String, ByVal numDocumento As String, ByVal Fecha As Date, ByVal FechaEntrega As Date, ByVal iidIdioma As Integer) As Boolean
        Dim funcTM As New FuncionesTextosMails
        Dim dtsTM As DatosTextoMail = funcTM.Mostrar1(Documento, iidIdioma)
        If dtsTM.gidTexto = 0 Then
            Dim funcI As New funcionesIdiomas
            MsgBox("No existe texto de e-mail prefijado para " & Documento & " en idioma " & funcI.Idioma(iidIdioma))
        End If
        Dim Texto As String = dtsTM.gTexto
        Texto = Replace(Texto, "<DOCUMENTO>", numDocumento)
        Texto = Replace(Texto, "<CONTACTO>", Contacto)
        Texto = Replace(Texto, "<FECHA>", Format(Fecha, "dd/MM/yyyy"))
        Texto = Replace(Texto, "<FECHA_ENTREGA>", Format(FechaEntrega, "dd/MM/yyyy"))
        Texto = Replace(Texto, vbCrLf, "<br/>")
        Dim Asunto As String = dtsTM.gAsunto
        Asunto = Replace(Asunto, "<DOCUMENTO>", numDocumento)
        Asunto = Replace(Asunto, "<CONTACTO>", Contacto)
        Asunto = Replace(Asunto, "<FECHA>", Format(Fecha, "dd/MM/yyyy"))
        Asunto = Replace(Asunto, "<FECHA_ENTREGA>", Format(FechaEntrega, "dd/MM/yyyy"))
        Return CorreoOutlook(Asunto, Texto, Remitente, Destinatario, Adjunto)
    End Function

    
    '*****Funciones de correo Outlook
    Function CorreoOutlook(ByVal Asunto As String, ByVal Texto As String, ByVal Remitente As String, ByVal Destinatario As String, ByVal Adjunto As String) As Boolean

        Try
            If SaberOutlook() Then

                Dim oApp As New Outlook.Application
                Dim Mensaje As Outlook.MailItem
                Mensaje = oApp.CreateItem(Outlook.OlItemType.olMailItem)
                Mensaje.Display()
                Dim TextoConFirma As String = Mensaje.HTMLBody 'Extraemos el texto HTML con la firma
                Mensaje.Close(Outlook.OlInspectorClose.olDiscard)

                Mensaje.To = ""
                Mensaje.Subject = ""
                If Adjunto <> "" Then
                    Mensaje.Attachments.Add(Adjunto, Outlook.OlAttachmentType.olByValue)
                End If

                Mensaje.HTMLBody = Replace(TextoConFirma, "<div class=WordSection1><p class=MsoNormal><o:p>", "<div class=WordSection1><p class=MsoNormal><o:p>" & "<p class=MsoNormal><span style='color:#1F497D;mso-fareast-language:ES'>" & Texto & "<o:p></o:p></span></p>") '& Texto) '"<strong style='color: red; font-size:22pt ' >Hola<span  style='color: blue; font-size:28pt ' > que tal</Span></Strong>  ") ' 

                'Mensaje = oApp.CreateItem(Outlook.OlItemType.olMailItem)
                Mensaje.Subject = Asunto
                'Mensaje.Body = Texto
                Mensaje.To = Destinatario
                Mensaje.Display()
            Else
                MsgBox("Para enviar un email debe tener abierto el Outlook." & vbCrLf & "Por favor, abra el Outlook para continuar.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If
        Catch ex As Exception
            ex.Data.Add("Asunto", Asunto)
            ex.Data.Add("Remitente", Remitente)
            ex.Data.Add("Destinatario", Destinatario)
            CorreoError(ex)
            Return False
        End Try
        Return True

    End Function


    Function SaberOutlook() As Boolean
        Dim procesos() As Process = Process.GetProcesses()
        Dim proceso As Process
        Dim nombre As String = ""
        For Each proceso In procesos
            nombre = UCase(proceso.ProcessName)
            If nombre = "OUTLOOK.EXE" Or nombre = "OUTLOOK" Then
                Return True
            End If
        Next
        Process.Start("outlook.exe")
        procesos = Process.GetProcesses()
        For Each proceso In procesos
            nombre = UCase(proceso.ProcessName)
            If nombre = "OUTLOOK.EXE" Or nombre = "OUTLOOK" Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function CorreoError(ByVal Ex As Exception)
        If MsgBox("Se ha producido un error: " & vbCrLf & Ex.Message & vbCrLf & " ¿Enviar automáticamente información sobre este error al departamento de desarrollo de MOVALNET?", MsgBoxStyle.YesNo) = MsgBoxResult.Ok Then
            Dim texto As String = Now & " - Se ha producido un error en el programa ERP_SUGAR versión " & Inicio.vversion & vbCrLf & vbCrLf
            texto = texto & "USUARIO: " & Inicio.usuario.Text & vbCrLf & "EQUIPO: " & My.Computer.Name & vbCrLf & " SISTEMA: " & My.Computer.Info.OSFullName & vbCrLf
            texto = texto & " IP: " & Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString() & vbCrLf & vbCrLf
            texto = texto & "MENSAJE DE ERROR: " & vbCrLf & Ex.Message & vbCrLf & vbCrLf
            If Not Ex.InnerException Is Nothing Then texto = texto & "EXCEPCION PREVIA: " & Ex.InnerException.Message & vbCrLf & vbCrLf
            texto = texto & "ORIGEN: " & Ex.Source & vbCrLf & vbCrLf
            texto = texto & "SEGUIMIENTO DE PILA: " & vbCrLf & Ex.StackTrace & vbCrLf & vbCrLf
            If Ex.Data.Count > 0 Then
                texto = texto & "DATOS ADICIONALES: " & vbCrLf
                For Each dato In Ex.Data
                    texto = texto & dato.key & " = " & dato.Value & vbCrLf
                Next
                texto = texto & vbCrLf
            End If
            Return correo("Error ERP_SUGAR", texto, "desarrollo@movalnet.es", "desarrollo@movalnet.es", "")
        Else
            Return Nothing
        End If
    End Function

End Module
