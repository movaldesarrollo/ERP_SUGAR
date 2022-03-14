Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports

Public Class EtiquetaEditada


    'A partir de una etiqueta definida de la tabla Etiquetas (que tenga activado el bit EtiquetaEditada,
    'personalizada campo a campo a partir de la tabla Campos. Tanto las etiquetas como los valores seo tratados como campos personalizados en el DataTable
    'El dataTable será el origen de datos para la EtiquetaPlantilla
    'La personalización de cada campo en cuanto a posición, fuente, etc se pasará en el momento 
    'Etiqueta1 ---> Campo ValorxDefecto de la entrada con CamposEtiquetas.NombreCampo = 'Etiqueta1' 
    'Valor1 ---> Campo ValorxDefecto de la entrada con CamposEtiquetas..NombreCampo = 'Valor1', si esContador o esCodigo, tomará el valor 

    'Mediante esta clase, podremos lanzar desde la GestionEtiquetas la etiquetaeditada

    Private iidEtiqueta As Integer
    Private dtEtiqueta As DataTable
    Private dtsE As DatosEtiqueta
    Private funcE As New FuncionesEtiquetas
    Private funcEL As New FuncionesEtiquetaLogo
    Private funcCE As New FuncionesCamposEtiquetas
    Private funcEN As New FuncionesEtiquetaLinea
    Private Campos As List(Of DatosCampoEtiqueta)
    Private Logos As List(Of DatosEtiquetaLogo)
    Private Lineas As List(Of DatosEtiquetaLinea)
    Private informe As New EtiquetaPlantilla
    Private CamposPlantilla As List(Of DatosCampoEtiqueta)
    Private LogosPlantilla As List(Of DatosEtiquetaLogo)
    Private LineasPlantilla As List(Of DatosEtiquetaLinea)
    Private iidEtiquetaPlantilla As Integer = 0

    Public Property pidEtiqueta() As Integer
        Get
            Return iidEtiqueta
        End Get
        Set(ByVal value As Integer)
            iidEtiqueta = value
        End Set
    End Property

    Public Property pCampos() As List(Of DatosCampoEtiqueta)
        Get
            Return Campos
        End Get
        Set(ByVal value As List(Of DatosCampoEtiqueta))
            Campos = value
        End Set
    End Property

    Public Property pLogos() As List(Of DatosEtiquetaLogo)
        Get
            Return Logos
        End Get
        Set(ByVal value As List(Of DatosEtiquetaLogo))
            Logos = value
        End Set
    End Property

    Public Property pLineas() As List(Of DatosEtiquetaLinea)
        Get
            Return Lineas
        End Get
        Set(ByVal value As List(Of DatosEtiquetaLinea))
            Lineas = value
        End Set
    End Property

    Public Sub New(ByVal idEtiqueta As Integer)
        If idEtiqueta = 0 Then
            iidEtiqueta = funcE.idEtiqueta("EtiquetaPlantilla")
        Else
            iidEtiqueta = idEtiqueta
        End If
        dtsE = funcE.Mostrar1(iidEtiqueta)
        Campos = funcCE.Mostrar(iidEtiqueta)
        Logos = funcEL.Mostrar(iidEtiqueta)
        Lineas = funcEN.Mostrar(iidEtiqueta)
        Call CompletarCamposyLogos()
        Call CreardtEtiqueta()
        Call AsignarValoresdtEtiqueta()
    End Sub

    Public Sub New(ByVal dtsET As DatosEtiqueta)
        dtsE = dtsET
        iidEtiqueta = dtsE.gidEtiqueta
        If iidEtiqueta > 0 Then Campos = funcCE.Mostrar(iidEtiqueta)
        If iidEtiqueta > 0 Then Logos = funcEL.Mostrar(iidEtiqueta)
        If iidEtiqueta > 0 Then Lineas = funcEN.Mostrar(iidEtiqueta)
        Call CompletarCamposyLogos()
        Call CreardtEtiqueta()
        Call AsignarValoresdtEtiqueta()
    End Sub

    Public Sub New(ByVal dtsET As DatosEtiqueta, ByVal ListaCampos As List(Of DatosCampoEtiqueta), ByVal ListaLogos As List(Of DatosEtiquetaLogo), ByVal ListaLineas As List(Of DatosEtiquetaLinea))
        dtsE = dtsET
        iidEtiqueta = dtsE.gidEtiqueta
        Campos = ListaCampos
        Logos = ListaLogos
        Lineas = ListaLineas
        Call CompletarCamposyLogos()
        Call CreardtEtiqueta()
        Call AsignarValoresdtEtiqueta()
    End Sub

    Private Sub CompletarCamposyLogos()
        'Añadir los campos y logos que no están en las tablas (cambiando a visible=False)
        If iidEtiquetaPlantilla = 0 Then iidEtiquetaPlantilla = funcE.idEtiqueta("EtiquetaPlantilla")
        CamposPlantilla = funcCE.Mostrar(iidEtiquetaPlantilla)
        For Each dts As DatosCampoEtiqueta In CamposPlantilla
            If IndiceEnCampos(dts.gNombreCampo) = -1 Then
                dts.gVisible = False
                Campos.Add(dts)
            End If
        Next
        LogosPlantilla = funcEL.Mostrar(iidEtiquetaPlantilla)
        For Each dts As DatosEtiquetaLogo In LogosPlantilla
            If IndiceEnLogos(dts.gNombreCampo) = -1 Then
                dts.gVisible = False
                Logos.Add(dts)
            End If
        Next
        LineasPlantilla = funcEN.Mostrar(iidEtiquetaPlantilla)
        For Each dts As DatosEtiquetaLinea In LineasPlantilla
            If IndiceEnLineas(dts.gNombreCampo) = -1 Then
                dts.gVisible = False
                Lineas.Add(dts)
            End If
        Next

    End Sub

    Public Function DataTable() As DataTable
        Return dtEtiqueta
    End Function

    Public Function dts() As DatosEtiqueta
        Return dtsE
    End Function

    Public Function ReportSource() As Object
        Call ActualizarValoresdtEtiqueta()
        informe.SetDataSource(dtEtiqueta)
        For Each dts As DatosCampoEtiqueta In Campos
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Left = dts.gParametroLeft
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Height = dts.gParametroHeight
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Top = dts.gParametroTop
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Width = dts.gParametroWidth
            Call CambioEstilo(dts.gNombreCampo, dts.gParametroSize, dts.gNegrita, dts.gItalica)
        Next
        For Each dts As DatosEtiquetaLogo In Logos
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Left = dts.gParametroLeft
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Height = dts.gParametroHeight
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Top = dts.gParametroTop
            informe.ReportDefinition.ReportObjects(dts.gNombreCampo).Width = dts.gParametroWidth
        Next
        For Each dts As DatosEtiquetaLinea In Lineas
            Call CambioLinea(dts)
        Next
        Return informe
    End Function

    Private Sub CambioEstilo(ByVal NombreCampo As String, ByVal ParametroSize As Single, ByVal Negrita As Boolean, ByVal Italica As Boolean)
        Dim Campo As Object = informe.ReportDefinition.ReportObjects(NombreCampo)
        Dim estilo As System.Drawing.FontStyle = If(Italica, FontStyle.Italic, FontStyle.Regular) Xor If(Negrita, FontStyle.Bold, FontStyle.Regular)
        Dim NuevaFuente As Font = New Font(CStr(Campo.Font.Name), ParametroSize, estilo)
        Campo.ApplyFont(NuevaFuente)
    End Sub

    Private Sub CambioEstilo(ByVal indice As Integer)
        Dim Campo As Object = informe.ReportDefinition.ReportObjects(Campos(indice).gNombreCampo)
        Dim estilo As System.Drawing.FontStyle = If(Campos(indice).gItalica, FontStyle.Italic, FontStyle.Regular) Xor If(Campos(indice).gNegrita, FontStyle.Bold, FontStyle.Regular)
        Dim NuevaFuente As Font = New Font(CStr(Campo.Font.Name), Campos(indice).gParametroSize, estilo)
        Campo.ApplyFont(NuevaFuente)
    End Sub

    Private Sub CambioLinea(ByVal indice As Integer)
        'Esto es incomprensible, pero funciona
        Dim Campo As Object = informe.ReportDefinition.ReportObjects(Lineas(indice).gNombreCampo)
        Campo.Top = Campo.Top
        Campo.Bottom = Campo.Top
        Campo.Left = Lineas(indice).gParametroLeft
        Campo.Right = Lineas(indice).gParametroLeft
        Campo.Top = Lineas(indice).gParametroTop
        Campo.Bottom = Lineas(indice).gParametroTop
        Campo.Right = Lineas(indice).gParametroRight
        Campo.LineStyle = LineStyle.SingleLine
    End Sub

    Private Sub CambioLinea(ByVal dts As DatosEtiquetaLinea)
        'Esto es incomprensible, pero funciona
        Dim Campo As Object = informe.ReportDefinition.ReportObjects(dts.gNombreCampo)
        Campo.Top = Campo.Top
        Campo.Bottom = Campo.Top
        Campo.Left = dts.gParametroLeft
        Campo.Right = dts.gParametroLeft
        Campo.Top = dts.gParametroTop
        Campo.Bottom = dts.gParametroTop
        If dts.gVisible Then Campo.Right = dts.gParametroRight
        Campo.LineStyle = LineStyle.SingleLine
    End Sub

    Public Sub Subir(ByVal ElementoSeleccionado As String, ByVal Incremento As Integer)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice = -1 Then
            indice = IndiceEnLogos(ElementoSeleccionado)
            If indice = -1 Then
                indice = IndiceEnLineas(ElementoSeleccionado)
                If indice <> -1 Then
                    Lineas(indice).gParametroTop = Lineas(indice).gParametroTop - Incremento
                    If Lineas(indice).gParametroTop < 0 Then Lineas(indice).gParametroTop = 0
                    Call CambioLinea(indice)
                End If
            Else
                Logos(indice).gParametroTop = Logos(indice).gParametroTop - Incremento
                If Logos(indice).gParametroTop < 0 Then Logos(indice).gParametroTop = 0
                informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Top = Logos(indice).gParametroTop
            End If
        Else
            Campos(indice).gParametroTop = Campos(indice).gParametroTop - Incremento
            If Campos(indice).gParametroTop < 0 Then Campos(indice).gParametroTop = 0
            informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Top = Campos(indice).gParametroTop
        End If
    End Sub

    Public Sub Bajar(ByVal ElementoSeleccionado As String, ByVal Incremento As Integer)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice = -1 Then
            indice = IndiceEnLogos(ElementoSeleccionado)
            If indice = -1 Then
                indice = IndiceEnLineas(ElementoSeleccionado)
                If indice <> -1 Then
                    Lineas(indice).gParametroTop = Lineas(indice).gParametroTop + Incremento
                    Call CambioLinea(indice)
                End If
            Else
                Logos(indice).gParametroTop = Logos(indice).gParametroTop + Incremento
                informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Top = Logos(indice).gParametroTop
            End If
        Else
            Campos(indice).gParametroTop = Campos(indice).gParametroTop + Incremento
            informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Top = Campos(indice).gParametroTop
        End If
    End Sub

    Public Sub Izquierda(ByVal ElementoSeleccionado As String, ByVal Incremento As Integer)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice = -1 Then
            indice = IndiceEnLogos(ElementoSeleccionado)
            If indice = -1 Then
                indice = IndiceEnLineas(ElementoSeleccionado)
                If indice <> -1 Then
                    Lineas(indice).gParametroLeft = Lineas(indice).gParametroLeft - Incremento
                    If Lineas(indice).gParametroLeft < 0 Then Lineas(indice).gParametroLeft = 0
                    informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Left = Lineas(indice).gParametroLeft
                End If
            Else
                Logos(indice).gParametroLeft = Logos(indice).gParametroLeft - Incremento
                If Logos(indice).gParametroLeft < 0 Then Logos(indice).gParametroLeft = 0
                informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Left = Logos(indice).gParametroLeft
            End If
        Else
            Campos(indice).gParametroLeft = Campos(indice).gParametroLeft - Incremento
            If Campos(indice).gParametroLeft < 0 Then Campos(indice).gParametroLeft = 0
            informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Left = Campos(indice).gParametroLeft
        End If
    End Sub

    Public Sub Derecha(ByVal ElementoSeleccionado As String, ByVal Incremento As Integer)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice = -1 Then
            indice = IndiceEnLogos(ElementoSeleccionado)
            If indice = -1 Then
                indice = IndiceEnLineas(ElementoSeleccionado)
                If indice <> -1 Then
                    Lineas(indice).gParametroLeft = Lineas(indice).gParametroLeft + Incremento
                    Dim kk = Lineas(indice).gParametroLeft
                    informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Left = Lineas(indice).gParametroLeft
                End If
            Else
                Logos(indice).gParametroLeft = Logos(indice).gParametroLeft + Incremento
                informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Left = Logos(indice).gParametroLeft
            End If
        Else
            Campos(indice).gParametroLeft = Campos(indice).gParametroLeft + Incremento
            informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Left = Campos(indice).gParametroLeft
        End If
    End Sub

    Public Sub CambiarTamañoTexto(ByVal ElementoSeleccionado As String, ByVal Incremento As Single)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice <> -1 Then
            Dim NuevoSize As Single = Campos(indice).gParametroSize + Incremento
            If NuevoSize < 2 Then NuevoSize = 2
            Campos(indice).gParametroSize = NuevoSize
            Call CambioEstilo(indice)
        End If
    End Sub

    Public Sub CambiarAncho(ByVal ElementoSeleccionado As String, ByVal Incremento As Integer)
        Dim indice = IndiceEnLogos(ElementoSeleccionado)
        If indice = -1 Then
            indice = IndiceEnCampos(ElementoSeleccionado)
            If indice <> -1 Then
                Dim NuevoAncho As Integer = Campos(indice).gParametroWidth + Incremento
                If NuevoAncho < 0 Then NuevoAncho = 0
                Campos(indice).gParametroWidth = NuevoAncho
                informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Width = Campos(indice).gParametroWidth
            End If
        Else
            Dim NuevoAncho As Integer = Logos(indice).gParametroWidth + Incremento
            If NuevoAncho < 0 Then NuevoAncho = 0
            Logos(indice).gParametroWidth = NuevoAncho
            informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Width = Logos(indice).gParametroWidth
        End If

    End Sub

    Public Sub CambiarAlto(ByVal ElementoSeleccionado As String, ByVal Incremento As Integer)
        Dim indice = IndiceEnLogos(ElementoSeleccionado)
        If indice = -1 Then
            indice = IndiceEnCampos(ElementoSeleccionado)
            If indice <> -1 Then
                Dim NuevoAlto As Integer = Campos(indice).gParametroHeight + Incremento
                If NuevoAlto < 0 Then NuevoAlto = 0
                Campos(indice).gParametroHeight = NuevoAlto
                informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Height = Campos(indice).gParametroHeight
            End If
        Else
            Dim NuevoAlto As Integer = Logos(indice).gParametroHeight + Incremento
            If NuevoAlto < 0 Then NuevoAlto = 0
            Logos(indice).gParametroHeight = NuevoAlto
            informe.ReportDefinition.ReportObjects(ElementoSeleccionado).Height = Logos(indice).gParametroHeight
        End If

    End Sub

    Public Sub CambiarNegrita(ByVal ElementoSeleccionado As String)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice <> -1 Then
            Campos(indice).gNegrita = Not Campos(indice).gNegrita
            Call CambioEstilo(indice)
        End If
    End Sub

    Public Sub CambiarItalica(ByVal ElementoSeleccionado As String)
        Dim indice = IndiceEnCampos(ElementoSeleccionado)
        If indice <> -1 Then
            Campos(indice).gItalica = Not Campos(indice).gItalica
            Call CambioEstilo(indice)
        End If
    End Sub

    Private Sub CreardtEtiqueta()

        dtEtiqueta = New DataTable
        dtEtiqueta.Columns.Add("Etiqueta0", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor0", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta1", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor1", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta2", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor2", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta3", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor3", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta4", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor4", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta5", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor5", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta6", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Valor6", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta7", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Etiqueta8", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Logo1", Type.GetType("System.Byte[]"))
        dtEtiqueta.Columns.Add("Logo2", Type.GetType("System.Byte[]"))
        dtEtiqueta.Columns.Add("Logo3", Type.GetType("System.Byte[]"))
        dtEtiqueta.Columns.Add("Check1", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check2", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check3", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check4", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check5", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check6", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check7", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check8", Type.GetType("System.String"))
        dtEtiqueta.Columns.Add("Check9", Type.GetType("System.String"))
    End Sub

    Private Sub AsignarValoresdtEtiqueta()
        Dim linea As DataRow = dtEtiqueta.NewRow
        For i = 1 To 6
            linea("Etiqueta" & i) = ValorCampo("Etiqueta" & i)
            linea("Valor" & i) = ValorCampo("Valor" & i)
        Next


        For i = 1 To 9
            linea("Check" & i) = ValorCheck("Check" & i)
        Next


        linea("Etiqueta7") = ValorCampo("Etiqueta7")
        linea("Etiqueta8") = ValorCampo("Etiqueta8")
        Dim stream As IO.MemoryStream
        Dim imagen As Image = Logos(0).gLogo
        If Not imagen Is Nothing Then
            stream = New IO.MemoryStream
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
            linea("Logo1") = stream.ToArray
        End If
        imagen = Logos(1).gLogo
        If Not imagen Is Nothing Then
            stream = New IO.MemoryStream
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
            linea("Logo2") = stream.ToArray
        End If
        imagen = Logos(2).gLogo
        If Not imagen Is Nothing Then
            stream = New IO.MemoryStream
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
            linea("Logo3") = stream.ToArray
        End If

        dtEtiqueta.Rows.Add(linea)
    End Sub

    Private Sub ActualizarValoresdtEtiqueta()
        Dim linea As DataRow = dtEtiqueta.Rows(0)
        For i = 0 To 6
            linea("Etiqueta" & i) = ValorCampo("Etiqueta" & i)
            linea("Valor" & i) = ValorCampo("Valor" & i)
        Next

        For i = 1 To 9
            linea("Check" & i) = ValorCheck("Check" & i)
        Next

        linea("Etiqueta7") = ValorCampo("Etiqueta7")
        linea("Etiqueta8") = ValorCampo("Etiqueta8")
        Dim stream As IO.MemoryStream
        Dim indice As Integer = IndiceEnLogos("Logo1")
        Dim imagen As Image = If(Logos(indice).gVisible, Logos(indice).gLogo, Nothing)


        If imagen Is Nothing Then
            linea("Logo1") = Nothing
        Else
            stream = New IO.MemoryStream
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)

            linea("Logo1") = stream.ToArray
        End If
        indice = IndiceEnLogos("Logo2")
        imagen = If(Logos(indice).gVisible, Logos(indice).gLogo, Nothing)
        If imagen Is Nothing Then
            linea("Logo2") = Nothing
        Else
            stream = New IO.MemoryStream
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
            linea("Logo2") = stream.ToArray
        End If
        indice = IndiceEnLogos("Logo3")
        imagen = If(Logos(indice).gVisible, Logos(indice).gLogo, Nothing)
        If imagen Is Nothing Then
            linea("Logo3") = Nothing
        Else
            stream = New IO.MemoryStream
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
            linea("Logo3") = stream.ToArray
        End If

    End Sub

    Private Function ValorCampo(ByVal NombreCampo As String) As String
        NombreCampo = UCase(Trim(NombreCampo))
        Dim i As Integer = 0
        While i < Campos.Count AndAlso UCase(Trim(Campos(i).gNombreCampo)) <> NombreCampo
            i = i + 1
        End While
        If i < Campos.Count Then
            Return If(Campos(i).gVisible, Campos(i).gValorxDefecto, "")
        Else
            Return ""
        End If
    End Function

    Private Function ValorCheck(ByVal NombreCampo As String) As String
        NombreCampo = UCase(Trim(NombreCampo))
        Dim i As Integer = 0
        While i < Campos.Count AndAlso UCase(Trim(Campos(i).gNombreCampo)) <> NombreCampo
            i = i + 1
        End While
        If i < Campos.Count Then
            Return If(Campos(i).gVisible, "chr(111)", "")
        Else
            Return ""
        End If
    End Function

    Private Function Logo(ByVal NombreCampo As String) As Image
        NombreCampo = UCase(Trim(NombreCampo))
        Dim i As Integer = 0
        While i < Logos.Count AndAlso UCase(Trim(Logos(i).gNombreCampo)) <> NombreCampo
            i = i + 1
        End While
        If i < Logos.Count Then
            Return If(Logos(i).gVisible, Logos(i).gLogo, Nothing)
        Else
            Return Nothing
        End If
    End Function

    Private Function IndiceEnCampos(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < Campos.Count AndAlso UCase(Trim(Campos(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < Campos.Count Then
            Return i
        Else
            Return -1
        End If
    End Function

    Private Function IndiceEnLogos(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < Logos.Count AndAlso UCase(Trim(Logos(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < Logos.Count Then
            Return i
        Else
            Return -1
        End If
    End Function

    Private Function IndiceEnLineas(ByVal NombreCampo As String) As Integer
        Dim i As Integer = 0
        While i < Lineas.Count AndAlso UCase(Trim(Lineas(i).gNombreCampo)) <> UCase(Trim(NombreCampo))
            i = i + 1
        End While
        If i < Lineas.Count Then
            Return i
        Else
            Return -1
        End If
    End Function

End Class
