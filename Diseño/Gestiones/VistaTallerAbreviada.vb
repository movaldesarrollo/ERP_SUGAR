Public Class VistaTallerAbreviada

    Private funcEQ As New FuncionesEquiposProduccion
    Private funcFE As New FuncionesFestivos
    Private funcSK As New FuncionesStock
    Private funcCA As New FuncionesMovimientosEquiposAcabados
    Private funcES As New FuncionesEstados

    Private Matriz(,) As CeldaVista
    Private EstadoEnCurso As DatosEstado
    Private EstadoEspera As DatosEstado
    Private EstadoCompleto As DatosEstado
    Private ColorReciente As Color = Color.LightBlue
    Private lista As List(Of DatosEquipoProduccion)

    Private lArticulos As List(Of Datos4)



    Public Function Mostrar() As Object
        EstadoCompleto = funcES.EstadoCompleto("EQUIPO")
        EstadoEnCurso = funcES.EstadoEnCurso("EQUIPO")
        EstadoEspera = funcES.EstadoEspera("EQUIPO")
        lista = funcEQ.Mostrar("TALLER")
        Call CargarListaArticulos()
        Matriz = New CeldaVista(lArticulos.Count, 5) {}
        Call InicializarMatriz()
        Call CargarCabeceras()
        Call CargarArticulos()
        Call AcumularCantidades()
        Call CargarColumnaStock()
        Call CargarColumnaAcabados()
        Return Matriz
    End Function


    Private Sub CargarArticulos()
        Dim f As Integer = 1
        For Each Articulo As Datos4 In lArticulos
            Matriz(f, 0).gContenido = f
            Matriz(f, 1).gContenido = Articulo.gDato2
            Matriz(f, 1).gReferencia = Articulo.gid
            Matriz(f, 1).gReferencia2 = Articulo.gDato1
            f = f + 1
        Next
    End Sub

    Private Sub CargarCabeceras()
        Matriz(0, 0).gColorFondo = Color.LightGray
        Matriz(0, 0).gContenido = ""
        Matriz(0, 1).gColorFondo = Color.LightGray
        Matriz(0, 1).gContenido = "ARTÍCULOS"
        Matriz(0, 2).gColorFondo = Color.LightGray
        Matriz(0, 2).gContenido = "PENDIENTES"
        Matriz(0, 3).gColorFondo = Color.LightGray
        Matriz(0, 3).gContenido = "STOCK"
        Matriz(0, 4).gColorFondo = Color.LightGray
        Matriz(0, 4).gContenido = "PREPARADAS"
    End Sub


    Private Sub CargarListaArticulos()
        lArticulos = New List(Of Datos4)

        Dim sArticulo As Datos4
        Dim iidArticuloEquipo As Integer
        Dim NombreArticuloTip As String
        For Each dts As DatosEquipoProduccion In lista
            iidArticuloEquipo = funcEQ.idArticuloEquipo(dts.gidEquipo)
            If iidArticuloEquipo = 0 Then iidArticuloEquipo = dts.gidArticulo
            NombreArticuloTip = dts.gArticulo & If(dts.gcodArticulo = "", "", " (" & dts.gcodArticulo & ") ")
            sArticulo = New Datos4(dts.gidArticulo, NombreArticuloTip, Microsoft.VisualBasic.Left(dts.gArticulo, 50), iidArticuloEquipo)
            If Not lArticulosContiene(sArticulo.gid) Then
                lArticulos.Add(sArticulo)
            End If
        Next
        lArticulos.Sort(AddressOf ComparadorDatos4)
    End Sub

    Private Shared Function ComparadorIdCombobox(ByVal x As IDComboBox, ByVal y As IDComboBox) As Integer
        Return x.ToString.CompareTo(y.ToString)
    End Function

    Private Shared Function ComparadorIdCombobox3(ByVal x As IDComboBox3, ByVal y As IDComboBox3) As Integer
        Return x.Name1.CompareTo(y.Name1)
    End Function

    Private Shared Function ComparadorDatos4(ByVal x As Datos4, ByVal y As Datos4) As Integer
        Return x.gDato1.CompareTo(y.gDato1)
    End Function


    Private Sub AcumularCantidades()
        Dim fila As Integer

        For Each dts As DatosEquipoProduccion In lista
            fila = lArticulosEn(dts.gidArticulo) + 1
            Call ColorearRecientes(fila, dts.gCreacion)

            Call AcumulaCantidadesPendientes(fila, dts.gidEstadoTaller)

        Next
    End Sub



    Private Function EsReciente(ByVal Fecha As Date) As Boolean
        Dim diferenciaHoras As Double
        Dim ayer As Date = Now.Date.AddDays(-1)
        diferenciaHoras = DateDiff(DateInterval.Hour, Fecha, Now)
        Do While funcFE.EsFestivo(ayer) 'Tener en cuenta los festivos
            diferenciaHoras = diferenciaHoras - 24
            ayer = ayer.AddDays(-1)
        Loop
        If diferenciaHoras < 0 Then diferenciaHoras = 0
        Return (diferenciaHoras >= 0 And diferenciaHoras < 24)
    End Function

    Private Sub CargarColumnaStock()
        For f As Integer = 1 To lArticulos.Count
            Matriz(f, 3).gContenido = funcSK.CantidadStockProduccion(Matriz(f, 1).gReferencia) + funcCA.CantidadAcabado(Matriz(f, 1).gReferencia)
            Matriz(f, 3).gReferencia = Matriz(f, 1).gReferencia
        Next
    End Sub

    Private Sub CargarColumnaAcabados()
        Try
            For f As Integer = 1 To lArticulos.Count
                Matriz(f, 4).gContenido = funcEQ.CantidadAcabadaElectronica(lArticulos(f - 1).gid)  'funcCA.CantidadAcabado(Matriz(f, 1).gReferencia)
                Matriz(f, 4).gReferencia = lArticulos(f - 1).gDato3
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub InicializarMatriz()
        Dim Fuente As New Font("Century Gothic", 9, FontStyle.Bold)
        For f As Integer = 0 To Matriz.GetLength(0) - 1
            For c As Integer = 0 To Matriz.GetLength(1) - 1
                Matriz(f, c) = New CeldaVista(f, c, "", Color.Black, Color.White, Fuente, Alineacion(f, c), "", "")
            Next
        Next
    End Sub

    Private Function Alineacion(ByVal f As Integer, ByVal c As Integer) As DataGridViewContentAlignment
        If c = 1 Then
            Return DataGridViewContentAlignment.MiddleRight
        Else
            Return DataGridViewContentAlignment.MiddleCenter
        End If
    End Function

    Private Sub AcumulaCantidadesPedidas(ByVal fila As Integer, ByVal iidEstado As Integer)
        If Matriz(fila, 2).gContenido = "" Then
            Matriz(fila, 2).gContenido = 1
        Else
            Matriz(fila, 2).gContenido = Matriz(fila, 2).gContenido + 1
        End If
    End Sub

    Private Sub AcumulaCantidadesPendientes(ByVal fila As Integer, ByVal iidEstado As Integer)
        If iidEstado = EstadoEnCurso.gidEstado Or iidEstado = EstadoEspera.gidEstado Then
            If Matriz(fila, 2).gContenido = "" Then
                Matriz(fila, 2).gContenido = 1
            Else
                Matriz(fila, 2).gContenido = Matriz(fila, 2).gContenido + 1
            End If
        Else
            If Matriz(fila, 2).gContenido = "" Then Matriz(fila, 2).gContenido = 0
        End If

    End Sub



    Private Sub ColorearRecientes(ByVal fila As Integer, ByVal Fecha As Date)
        If Matriz(fila, 2).gColorFondo <> ColorReciente Then
            If EsReciente(Fecha) Then
                Matriz(fila, 2).gColorFondo = ColorReciente
            End If
        End If
    End Sub


    Public Function DobleClick(ByVal celda As CeldaVista) As Boolean
        'Es llamado al hacer un doble click en una celda de la vista. Devuelve el valor a presentar.
        If celda.gColumna = 3 And celda.gFila > 0 Then
            Dim GG As New subCantidadAcabadaTaller
            GG.pidArticulo = celda.gReferencia
            GG.ShowDialog()
            If GG.DialogResult = DialogResult.OK Then
                celda.gContenido = funcSK.CantidadStockProduccion(celda.gReferencia) + funcCA.CantidadAcabado(celda.gReferencia)
                Return True
            End If
        End If
        Return False
    End Function



    Private Function lArticulosEn(ByVal iidArticulo As Integer) As Integer
        If lArticulos.Count = 0 Then
            Return -1
        Else
            Dim i As Integer = 0
            While i < lArticulos.Count
                If lArticulos(i).gid = iidArticulo Then Return i
                i = i + 1
            End While
            Return -1
        End If
    End Function



    Private Function lArticulosContiene(ByVal iidArticulo As Integer) As Boolean
        If lArticulos.Count = 0 Then
            Return False
        Else
            Dim i As Integer = 0
            While i < lArticulos.Count
                If lArticulos(i).gid = iidArticulo Then Return True
                i = i + 1
            End While
            Return False
        End If
    End Function

End Class
