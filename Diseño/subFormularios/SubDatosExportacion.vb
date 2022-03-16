Public Class SubDatosExportacion

    'Private funcL As New FuncionesLineasExportacion
    Private Nota As String
    Private inumFactura As Integer
    Private funcF As New FuncionesFacturas
    Private funcUB As New funcionesUbicaciones
    Private dtsF As DatosFactura
    Private dtsUB As datosUbicacion
    Private Negrita As Boolean
    Private Italica As Boolean
    Private Subrayado As Boolean
    Private fuente As Font
    Private fuenteNegrita As Font
    Private fuenteNormal As Font
    Private cambios As Boolean
    Private NotaOriginal As New RichTextBox

    Public Property pnumFactura() As Integer
        Get
            Return inumFactura
        End Get
        Set(ByVal value As Integer)
            inumFactura = value
        End Set
    End Property

    Public Property pNota() As String
        Get
            Return rtbNota.Rtf
        End Get
        Set(ByVal value As String)
            rtbNota.Rtf = value
        End Set
    End Property


    Private Sub SubDatosExportacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If NotaOriginal.Rtf = rtbNota.Rtf Then
            e.Cancel = False
        Else
            If MsgBox("¿Salir sin guardar los cambios?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                rtbNota.Rtf = NotaOriginal.Rtf
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub SubDatosExportacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If inumFactura > 0 Then
            dtsF = funcF.Mostrar1(inumFactura)
            fuente = rtbNota.Font
            fuenteNegrita = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Bold)
            fuenteNormal = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Regular)
            Dim tabs(3) As Integer
            tabs(0) = 170
            tabs(1) = 270
            tabs(2) = 370
            tabs(3) = 470
            rtbNota.SelectionTabs = tabs
            NotaOriginal.Rtf = rtbNota.Rtf
            'If dtsF.gidUbicacion > 0 Then
            '    dtsUB = funcUB.mostrar1(dtsF.gidUbicacion)
            '    If dtsUB.gExportacion Or (dtsUB.gidPais = 1 And dtsF.gTipoIVA = 0) Then
            '        rtbNota.Rtf = dtsF.gNotas
            '        If rtbNota.TextLength < 2 Then
            '            NotaOriginal = ""
            '            rtbNota.Clear()
            '            Call CargarNueva()

            '        End If
            '    Else
            '        rtbNota.Rtf = dtsF.gNotas
            '        NotaOriginal = dtsF.gNotas
            '    End If
            'End If
        End If

    End Sub

    Private Sub CargarNueva()
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Currency " & dtsF.gDivisa & ": ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText(FormatNumber(dtsF.gTotal, 2) & dtsF.gSimbolo & vbTab) '& vbTab & vbTab & vbTab)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Delivery condition: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText("Exfactory" & vbCrLf)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Statistical item: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText("84212100" & vbTab)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Invoice Nº: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText(dtsF.gnumFactura & vbCrLf)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Adress delivery: ")
        rtbNota.SelectionFont = fuenteNormal
        Dim direccion As String = dtsUB.gdireccion & " - " & dtsUB.gcodpostal & " " & dtsUB.glocalidad & " (" & dtsUB.gprovincia & ") " & dtsUB.gPais
        direccion = Replace(Replace(direccion, Chr(10), " "), Chr(13), " ")
        rtbNota.AppendText(direccion & vbCrLf)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Nomenclature number: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText("84212100" & vbTab)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Packages: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText(" palets" & vbCrLf)

        rtbNota.AppendText("All material Originary from Spain (Cee) " & vbTab) '& vbTab)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Gross weight: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText(" Kg" & vbCrLf)

        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Exporter: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText("SUGAR VALLEY,S.L.  C/ BOTÁNICA,127-129 POL.IND. PEDROSA 08908 L'HOSPITALET DE LLOBREGAT" & vbCrLf) '& vbTab & vbTab & vbTab)
        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Exporter condition: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText("Manufacturer" & vbTab) '& vbTab & vbTab)

        rtbNota.SelectionFont = fuenteNegrita
        rtbNota.AppendText("Measures: ")
        rtbNota.SelectionFont = fuenteNormal
        rtbNota.AppendText(" cm" & vbCrLf)

    End Sub



#Region "PROCEDIMIENTOS Y FUNCIONES"

    Private Sub Atributos()
        'Cambia los atributos de texto del texto q

        fuente = rtbNota.SelectionFont

        If Not Negrita And Not Italica And Not Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Regular)
        End If
        If Not Negrita And Not Italica And Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Underline)
        End If
        If Not Negrita And Italica And Not Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Italic)
        End If
        If Not Negrita And Italica And Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Italic Or FontStyle.Underline)
        End If
        If Negrita And Not Italica And Not Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Bold)
        End If
        If Negrita And Not Italica And Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Bold Or FontStyle.Underline)
        End If
        If Negrita And Italica And Not Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Bold Or FontStyle.Italic)
        End If
        If Negrita And Italica And Subrayado Then
            fuente = New Font(fuente.FontFamily, fuente.SizeInPoints, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
        End If

        rtbNota.SelectionFont = fuente


    End Sub

#End Region


#Region "EVENTOS"

    Private Sub lbNegrita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNegrita.Click
        If rtbNota.Focused Then
            If lbNegrita.BackColor = gbNotas.BackColor Then
                Negrita = True
                lbNegrita.BackColor = Color.Wheat
            Else
                lbNegrita.BackColor = gbNotas.BackColor
                Negrita = False
            End If
            Call Atributos()
        End If
    End Sub


    Private Sub lbItalica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbItalica.Click
        If rtbNota.Focused Then
            If lbItalica.BackColor = gbNotas.BackColor Then
                Italica = True
                lbItalica.BackColor = Color.Wheat
            Else
                lbItalica.BackColor = gbNotas.BackColor
                Italica = False
            End If
            Call Atributos()
        End If
    End Sub


    Private Sub lbSubrayado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSubrayado.Click
        If rtbNota.Focused Then
            If lbSubrayado.BackColor = gbNotas.BackColor Then
                Subrayado = True
                lbSubrayado.BackColor = Color.Wheat
            Else
                lbSubrayado.BackColor = gbNotas.BackColor
                Subrayado = False
            End If
            Call Atributos()
        End If
    End Sub

    Private Sub lbFuenteInc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbFuenteInc.Click

        If rtbNota.Focused Then
            fuente = rtbNota.SelectionFont
            If fuente.SizeInPoints < 50 Then
                fuente = New Font(fuente.FontFamily, fuente.SizeInPoints + 1, fuente.Style)
                rtbNota.SelectionFont = fuente
            End If
        End If

    End Sub

    Private Sub lbFuenteDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbFuenteDec.Click


        If rtbNota.Focused Then
            fuente = rtbNota.SelectionFont
            If fuente.SizeInPoints > 7 Then
                fuente = New Font(fuente.FontFamily, fuente.SizeInPoints - 1, fuente.Style)
                rtbNota.SelectionFont = fuente
            End If
        End If

    End Sub




    'Private Sub tbTextos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbTextos.LostFocus, tbPercepcion.LostFocus, tbSeguimiento.LostFocus
    '    lbSubrayado.BackColor = gbNotas.BackColor
    '    lbItalica.BackColor = gbNotas.BackColor
    '    lbNegrita.BackColor = gbNotas.BackColor
    'End Sub



#End Region




    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click

        Me.Close()
    End Sub


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        If rtbNota.Rtf.Length > 1999 Then
            MsgBox("La nota es demasiado larga. Ajuste el contenido y vuelva a guardar.")

        Else
            funcF.actualizaNota(dtsF.gnumFactura, rtbNota.Rtf)
            NotaOriginal.Rtf = rtbNota.Rtf

            Me.Close()
        End If

    End Sub


End Class