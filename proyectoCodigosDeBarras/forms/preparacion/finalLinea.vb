Imports System.ComponentModel
Imports System.IO
Public Class finalLinea

#Region "VARIABLES"

    Dim funcCB As New funcionesCodigosBarras
    Public linea As String
    Public lineaTitulo As String
    Public codigoBarras As String
    Public procedentePreparacion As Boolean = True

#End Region

#Region "CARGA Y CIERRE"

    Private Sub preparacionPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txSubEquipo.ReadOnly = procedentePreparacion

        If procedentePreparacion Then

        Else

            txSubEquipo.Focus()

        End If

        bImprimir.Visible = False

    End Sub

#End Region

#Region "EVENTOS"

    Private Sub bSalir_Click(sender As Object, e As EventArgs) Handles bSalir.Click

        Close()

        Finalize()
        CleanPDFFromPath()
    End Sub
    ''' <summary>
    ''' Borra el PDF que existe en la ruta de aplicación, este PDF es el que carga en el visor de la etiqueta final.
    ''' Se borra para que no se cargue nada más se abra otro num.serie
    ''' </summary>
    Private Sub CleanPDFFromPath()

        If File.Exists(Directory.GetCurrentDirectory() & "\PDF1.pdf") Then
            File.Delete(Directory.GetCurrentDirectory() & "\PDF1.pdf")
        End If

    End Sub
    'Carga el número de serie del equipo si existe.
    Private Sub txNumSerieEquipo_KeyDown(sender As Object, e As KeyEventArgs) Handles txNumSerieEquipo.KeyDown

        If e.KeyCode = Keys.Enter Then

            txNumSerieEquipo.Text = Replace(txNumSerieEquipo.Text, "C", "")

            txNumSerieEquipo.Text = Replace(txNumSerieEquipo.Text, "c", "")

            If IsNumeric(txNumSerieEquipo.Text) Then

                If funcCB.existeNumSerie(txNumSerieEquipo.Text) Then

                    cargar()

                Else

                    MsgBox("El número de serie no es válido.", MsgBoxStyle.Information)

                End If

            Else

                MsgBox("El código introducido no es válido.", MsgBoxStyle.Information)

            End If

        End If

    End Sub

    Private Sub bLimpiar_Click(sender As Object, e As EventArgs) Handles bLimpiar.Click

        limpiar()

    End Sub

    'Recoge el número de serie introducido en el campo de texto y lo asigna si todo está OK.
    Public Sub boton_codigo(sender As Object, e As KeyEventArgs) Handles txSubEquipo.KeyDown

        Try

            If e.KeyCode = Keys.Enter Then

                funcCB.asignarCodigoBarras(Panel1, txSubEquipo.Text, txNumSerieEquipo.Text)

                txSubEquipo.Text = ""

                cargar()

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'Elimina las celulas del articulo.
    Private Sub ckSinCelula_CheckedChanged(sender As Object, e As EventArgs) Handles ckSinCelula.CheckedChanged

        If txNumSerieEquipo.Text <> "" Then

            cargar()

        End If

    End Sub

    'Imprime la etiqueta
    Private Sub bImprimir_Click(sender As Object, e As EventArgs) Handles bImprimir.Click

        'Dim gg As New imprimirEtiqueta

        'gg.iNumserie = txNumSerieEquipo.Text

        'gg.ShowDialog()

        'gg.Dispose()

        'limpiar()
        LiberarMemoria()

        Dim GG As New ImprimirEtiquetaFinalLinea
        GG.gNumSerie = txNumSerieEquipo.Text
        GG.gReferencia = txEquipo.Text
        GG.ShowDialog()
        GG.Dispose()
    End Sub

#End Region

#Region "FUNCIONES Y PROCEDIMIENTOS"

    Public Sub limpiar()

        bImprimir.Visible = False

        ckSinCelula.Checked = False

        Panel1.Controls.Clear()

        txNumSerieEquipo.ReadOnly = False

        txNumSerieEquipo.Text = ""

        txSubEquipo.ReadOnly = True

        txEquipo.Text = ""

        txNumSerieEquipo.Focus()

        funcCB.numeroCajas = 0

        funcCB.numeroCelulas = 0
        CleanPDFFromPath()

    End Sub

    Public Sub cargar()

        Dim lista As New List(Of datosPreparacionPedidos)

        Dim dts As New datosPreparacionPedidos

        Dim codigo As String = funcCB.codArticulo(txNumSerieEquipo.Text)

        If codigo Is Nothing Then

            MsgBox("Este número de serie no existe.", MsgBoxStyle.Information)

            limpiar()

        Else
            'EQUIPOS

            Dim caja As New List(Of String)

            funcCB.numSerieCaja(txNumSerieEquipo.Text, caja)

            'END EQUIPOS

            'CELULAS

            Dim celula As New List(Of String)

            funcCB.numSerieCelula(txNumSerieEquipo.Text, celula)

            'END CELULAS

            'BOMBAS

            Dim bomba1 As String = funcCB.numSerieBomba1(txNumSerieEquipo.Text)

            Dim bomba2 As String = funcCB.numSerieBomba2(txNumSerieEquipo.Text, bomba1)

            'END BOMBAS

            txEquipo.Text = codigo

            Panel1.Controls.Clear()

            With Panel1.Controls

                'Llenamos las cajas  y bombas

                If funcCB.mostrarIdSubTipoArticulo(codigo) <> 43 And funcCB.mostrarIdSubTipoArticulo(codigo) <> 45 Then

                    For Each item In caja

                        dts = New datosPreparacionPedidos

                        dts.pArticulo = "CAJA"
                        dts.pNumSerieSubProducto = item
                        lista.Add(dts)

                    Next

                    dts = New datosPreparacionPedidos

                    Dim numeroCajas As Integer = totalCajas(codigo)

                    funcCB.numeroCajas = numeroCajas

                    For numCajas = caja.Count + 1 To numeroCajas

                        dts.pArticulo = "CAJA"
                        dts.pNumSerieSubProducto = ""
                        lista.Add(dts)

                    Next

                    'Llenamos las bombas

                    dts = New datosPreparacionPedidos

                    If codigo.Contains("KBPER") Or codigo.Contains("KB5-5") Then

                        If bomba1 = "" Then

                            dts.pArticulo = "BOMBA_1"
                            dts.pNumSerieSubProducto = ""
                            lista.Add(dts)

                        Else

                            dts.pArticulo = "BOMBA_1"
                            dts.pNumSerieSubProducto = bomba1
                            lista.Add(dts)

                        End If

                    End If

                    dts = New datosPreparacionPedidos

                    If codigo.Contains("2XKBPER") Or codigo.Contains("2XKB5-5") Then

                        If bomba2 = "" Then

                            dts.pArticulo = "BOMBA_2"
                            dts.pNumSerieSubProducto = ""
                            lista.Add(dts)

                        Else

                            dts.pArticulo = "BOMBA_2"
                            dts.pNumSerieSubProducto = bomba2
                            lista.Add(dts)

                        End If

                    End If

                End If

                'Llenamos las celulas

                Dim numeroCelulas As Integer = totalCajas(codigo)

                funcCB.numeroCelulas = numeroCelulas

                If ckSinCelula.Checked Or soloCaja(codigo) = False Then

                Else

                    For Each item In celula

                        dts = New datosPreparacionPedidos

                        dts.pArticulo = "CÉLULA"
                        dts.pNumSerieSubProducto = item
                        lista.Add(dts)

                    Next

                    dts = New datosPreparacionPedidos

                    For numCelulas = celula.Count + 1 To numeroCelulas

                        dts.pArticulo = "CÉLULA"
                        dts.pNumSerieSubProducto = ""
                        lista.Add(dts)

                    Next

                End If

            End With

            funcCB.crearBotones(lista, Panel1)

            txNumSerieEquipo.ReadOnly = True

            txSubEquipo.ReadOnly = False

            txSubEquipo.Focus()

            bImprimir.Visible = EquipoCompleto()

            txSubEquipo.ReadOnly = EquipoCompleto()

        End If

    End Sub

    'Total cajas por equipos industrial.
    Public Function totalCajas(ByVal codigo As String) As Integer

        Try

            If codigo.Length < 4 And codigo.Substring(0, 3) <> "HD8" And codigo.Substring(0, 3) <> "HD9" Then

                Return 1

            Else
                'Si el código empieza por HD8 retornar 2 celulas y 2 equipos
                If codigo.Substring(0, 3) = "HD8" Or codigo.Substring(0, 3) = "HD9" Then

                    Return 2

                Else

                    If codigo.Length >= 4 Then

                        Select Case codigo.Substring(0, 4)

                            Case "OX 8"

                                Return 2

                            Case "OX 9"

                                Return 2

                        End Select

                    End If

                    'Si son celulas.
                    If codigo.Length >= 5 Then

                        Select Case codigo.Substring(0, 5)

                            Case "RC250"
                                Return 1

                            Case "RC350"
                                Return 2

                            Case "RC500"
                                Return 2

                            Case "RC750"
                                Return 3

                            Case "RC100"
                                Return 4

                            Case "RC150"
                                Return 6

                        End Select

                    End If

                    If codigo.Length >= 6 Then

                        Select Case codigo.Substring(0, 6)
                            Case "RCB350"

                                Return 2

                            'Si el código empieza por NEO350 retornar 2 celulas y 2 equipos
                            Case "NEO350"

                                Return 2

                                'Si el código empieza por NEO350 retornar 2 celulas y 2 equipos
                            Case "NEO355"

                                Return 2
                            'Si el código empieza por NEO500 retornar 2 celulas y 2 equipos
                            Case "NEO500"

                                Return 2
                            'Si el código empieza por HD8 retornar 2 celulas y 2 equipos
                            Case "SAL350"

                                Return 2
                            'Si el código empieza por SAL500 retornar 2 celulas y 2 equipos
                            Case "SAL500"

                                Return 2
                            'Si el código empieza por NEO750 retornar 3 celulas y 3 equipos
                            Case "NEO750"

                                Return 3
                            'Si el código empieza por SAL750 retornar 3 celulas y 3 equipos
                            Case "SAL750"

                                Return 3
                            'Si el código empieza por NEO100 retornar 4 celulas y 4 equipos
                            Case "NEO100"

                                Return 4

                            'Si el código empieza por SAL100 retornar 4 celulas y 4 equipos
                            Case "SAL100"

                                Return 4
                            'Si el código empieza por NEO150 retornar 6 celulas y 6 equipos
                            Case "NEO150"

                                Return 6

                            'Si el código empieza por SAL150 retornar 6 celulas y 6 equipos
                            Case "SAL150"

                                Return 6

                        End Select

                        If codigo.Length >= 7 Then

                            Select Case codigo.Substring(0, 7)

                         'Si el código empieza por BIO 100 retornar 4 celulas y 4 equipos
                                Case "BIO 100"

                                    Return 4
                         'Si el código empieza por "BIO 150" retornar 6 celulas y 6 equipos
                                Case "BIO 150"

                         'Si el código empieza por BIO 500 retornar 2 celulas y 2 equipos
                                Case "BIO 500"

                                    Return 2
                         'Si el código empieza por BIO 750 retornar 3 celulas y 3 equipos
                                Case "BIO 750"

                                    Return 3
                          'Si el código empieza por BIO 350 retornar 2 celulas y 2 equipos
                                Case "BIO 350"

                                    Return 2

                            End Select

                        End If

                        If codigo.Length >= 10 Then

                            Select Case codigo.Substring(0, 10)
                                 'Si el código empieza por AQR-HC-350 retornar 2 celulas y 2 equipos
                                Case "AQR-HC-350"

                                    Return 2

                            End Select

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

            'MsgBox(ex.Message)

        End Try

        Return 1

    End Function

    'Comprueba si es una caja
    Public Function soloCaja(ByVal codigo As String) As Boolean

        Try

            If codigo.Length < 4 Then

                Return True

            Else

                If codigo.Substring(0, 4) = "CAJA" Then

                    Return False

                End If

                If codigo.Substring(0, 4) = "ST 1" Then

                    Return False

                End If

                If codigo.Substring(0, 3) = "ST1" Then

                    Return False

                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        Return True

    End Function

    'Verifica que el equipo esta completo.
    Public Function EquipoCompleto() As Boolean

        EquipoCompleto = True

        For Each Control In Panel1.Controls

            If Control.BackColor <> Color.Green Then

                EquipoCompleto = False

            End If

        Next

        If EquipoCompleto Then

            funcCB.actualizarFechaPicking(txNumSerieEquipo.Text)

        End If

    End Function

#End Region

End Class