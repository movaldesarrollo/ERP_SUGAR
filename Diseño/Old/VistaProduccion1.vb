

Public Class VistaProduccion1

    Private funcEQ As New FuncionesEquiposProduccion
    Private funcFE As New FuncionesFestivos
    Private funcSK As New FuncionesStock
    Private funcCA As New FuncionesMovimientosEquiposAcabados
    Private funcCL As New funcionesclientes
    Private funcES As New FuncionesEstados
    Private funcPE As New FuncionesPedidos

    Private Matriz(,) As CeldaVista

    Private lista As List(Of DatosEquipoProduccion)
    Private lArticulos As List(Of Datos4)

    Private lPrioridades, lFechasPedido, lnumSPedidoAbrev, lClientes, lidClientes As List(Of String)
    Private lnumSPedido As List(Of Integer)
    Private lidSProduccion As List(Of Long)
    'Private lEstados As List(Of String)
    Private lDias, lTotales, lTotalesBarra, lEstaSemana, lSemanaProxima, lEn2Semanas, lEnMasSemanas As List(Of String)
    'Private lineasArticulos As List(Of String()) 'Lista de unidades de artículo

    'Private lineasColorArticulos As List(Of Color)
    Private Vista As String = "ELECTRÓNICA"
    Private vSoloLectura As Boolean

    Private ColorReciente As Color = Color.LightBlue
    Private ColorEnCurso As Color = Color.DarkOrange
    Private ColorEmpezadoOtro As Color = Color.DarkViolet
    Private ColorAcabado As Color = Color.Green
    Private ColorPruebas As Color = Color.Orange
    Private ColorAcabando As Color = Color.LightGreen


    Private EstadoEnCurso As DatosEstado = funcES.EstadoEnCurso("EQUIPO")
    Private EstadoEspera As DatosEstado = funcES.EstadoEspera("EQUIPO")
    Private EstadoCompleto As DatosEstado = funcES.EstadoCompleto("EQUIPO")

    Private ColumnasFijasIzquierda As Integer = 4
    Private ColumnaVersion As Integer = 2
    Private ColumnaPendientes As Integer = 3
    Private FilasFijasArriba As Integer = 4
    Private FilasFijasAbajo As Integer = 2
    Private DiasAvisoRojo As Integer = 2
    Private filaTotales As Integer
    Private colorVerdePalido As Color = Color.FromArgb(1, 0, 100, 0)
    Private colorVerdeGrisaceo As Color = Color.FromArgb(1, 100, 100, 0)
    Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property


    Public Property pVista() As String
        Get
            Return Vista
        End Get
        Set(ByVal value As String)
            Vista = value
            If Vista = "TALLER" Then ColumnasFijasIzquierda = 5
        End Set
    End Property

    Public Function Mostrar() As Object
        lista = funcEQ.Mostrar(Vista)
        'colorVerdePalido = Color.FromArgb(0, 0, 100, 0)
        'colorVerdeGrisaceo = Color.FromArgb(10, 100, 100, 0)
        Call inicializarListas()
        Call CargarListas()
        Matriz = New CeldaVista(lArticulos.Count + FilasFijasArriba + FilasFijasAbajo - 1, lnumSPedido.Count) {}
        Call InicializarMatriz()
        Call CargarColumnasIzquierdaMatriz()
        Call CargarFilasSuperioresMatriz()
        Call CargarMatriz()
        Call TotalesXPedido()
        Call DiasLaborables()
        Call TotalPdidos()

        Return Matriz
    End Function


    Private Sub CargarColumnasIzquierdaMatriz()

        Dim f As Integer = FilasFijasArriba
        For Each Articulo As Datos4 In lArticulos
            Matriz(f, 0).gContenido = f - FilasFijasArriba + 1
            Matriz(f, 1).gContenido = Articulo.gDato2
            Matriz(f, 1).gReferencia = Articulo.gid
            Matriz(f, 1).gReferencia2 = Articulo.gDato1
            Matriz(f, ColumnaVersion).gContenido = If(Articulo.gDato3 = "0", "", Articulo.gDato3)
            Matriz(f, ColumnaPendientes).gReferencia = Articulo.gid

            If ColumnasFijasIzquierda > 4 Then
                Matriz(f, 4).gContenido = funcSK.CantidadStockProduccion(Articulo.gid) + funcCA.CantidadAcabado(Articulo.gid)
            End If
            f = f + 1
        Next
    End Sub



    Private Sub CargarFilasSuperioresMatriz()
        Dim iNumPedido As Integer = 0
        For C As Integer = 0 To lnumSPedido.Count - 1
            Matriz(0, C).gContenido = lPrioridades(C)
            iNumPedido = lnumSPedido(C)
            If C >= ColumnasFijasIzquierda Then
                If lPrioridades(C) = 1 Then
                    Matriz(0, C).gColorFondo = Color.Red
                    Matriz(0, C).gColorLetra = Color.White
                End If
                If iNumPedido > 0 Then
                    If funcPE.Acabando(iNumPedido) Then Matriz(1, C).gColorFondo = ColorAcabando
                    If funcPE.EnPruebas(iNumPedido) Then Matriz(2, C).gColorFondo = ColorPruebas
                End If
            End If
            Matriz(1, C).gContenido = lFechasPedido(C)
            Matriz(1, C).gReferencia = iNumPedido
            Matriz(2, C).gContenido = lnumSPedidoAbrev(C)
            Matriz(2, C).gReferencia = iNumPedido
            Matriz(3, C).gContenido = lClientes(C)
            Matriz(3, C).gReferencia = lidClientes(C)

        Next
    End Sub

    Private Sub inicializarListas()
        lPrioridades = New List(Of String)
        lPrioridades.Add("")
        lPrioridades.Add("PRIORIDAD")
        lPrioridades.Add("")
        lPrioridades.Add("")
        lFechasPedido = New List(Of String)
        lFechasPedido.Add("")
        lFechasPedido.Add("FECHA PEDIDO")
        lFechasPedido.Add("")
        lFechasPedido.Add("")
        lnumSPedidoAbrev = New List(Of String)
        lnumSPedidoAbrev.Add("")
        lnumSPedidoAbrev.Add("NºPEDIDO")
        lnumSPedidoAbrev.Add("")
        lnumSPedidoAbrev.Add("")
        lnumSPedido = New List(Of Integer)
        lnumSPedido.Add(0)
        lnumSPedido.Add(0)
        lnumSPedido.Add(0)
        lnumSPedido.Add(0)
        lidSProduccion = New List(Of Long)
        lidSProduccion.Add(0)
        lidSProduccion.Add(0)
        lidSProduccion.Add(0)
        lidSProduccion.Add(0)
        lClientes = New List(Of String)
        lClientes.Add("")
        lClientes.Add("CLIENTES")
        lClientes.Add("VERSIÓN")
        lClientes.Add("PENDIENTES")
        lidClientes = New List(Of String)
        lidClientes.Add(0)
        lidClientes.Add(0)
        lidClientes.Add(0)
        lidClientes.Add(0)
        lTotales = New List(Of String)
        lTotales.Add("")
        lTotales.Add("")
        lTotales.Add("TOTALES POR PEDIDO")
        lTotales.Add("0")
        lTotalesBarra = New List(Of String)
        lTotalesBarra.Add("")
        lTotalesBarra.Add("")
        lTotalesBarra.Add("TOTALES POR PEDIDO")
        lTotalesBarra.Add("0")
        lDias = New List(Of String)
        lDias.Add("")
        lDias.Add("")
        lDias.Add("DIAS LABORABLES")
        lDias.Add("")

        If ColumnasFijasIzquierda > 4 Then
            lPrioridades.Add("")
            lFechasPedido.Add("")
            lnumSPedido.Add(0)
            lClientes.Add("STOCK")
            lidClientes.Add(0)
            lnumSPedidoAbrev.Add("")
            lidSProduccion.Add(0)
            lTotales.Add("")
            lTotalesBarra.Add("")
            lDias.Add("")
        End If

    End Sub


    Private Sub CargarMatriz()
        Try

            Dim indice As Integer = 0

            'Ahora repasamos otra vez la lista de equipos para calcular las cantidades 

            Dim Prioridad As Integer = 0
            Dim TotalPedido As Integer = 0
            Dim numPedido As Integer = -1
            Dim iidArticulo As Integer = 0
            Dim iidArticuloPed As Integer = 0
            Dim TotalEquipos As Integer = 0
            Dim FechaPrevista As Date = CDate("1-1-1900")
            Dim Version As Integer = 99999
            Dim fila As Integer
            Dim columna As Integer
            For Each dts As DatosEquipoProduccion In lista
                fila = lArticulosEn(dts.gidArticulo, dts.gVersion) + FilasFijasArriba
                If dts.gnumPedido = 0 Then
                    columna = lidSProduccion.IndexOf(dts.gidProduccion)
                Else
                    columna = lnumSPedido.IndexOf(dts.gnumPedido)
                End If

                If columna > ColumnasFijasIzquierda - 1 Then
                    'Cargar los idProducción relacionados como referencia
                    If Matriz(fila, columna).gReferencia.Contains(dts.gidProduccion) Then
                    Else
                        If Matriz(fila, columna).gReferencia = "" Then
                            Matriz(fila, columna).gReferencia = dts.gidProduccion
                        Else
                            Matriz(fila, columna).gReferencia = Matriz(fila, columna).gReferencia & ", " & dts.gidProduccion
                        End If
                    End If
                    'Detectamos el cambio de artículo

                    If Vista = "TALLER" Then
                        If dts.gidArticulo <> iidArticulo Or dts.gnumPedido <> numPedido Or dts.gVersion <> Version Then
                            iidArticulo = dts.gidArticulo
                            TotalEquipos = 0
                            numPedido = dts.gnumPedido
                            Version = dts.gVersion
                        End If
                    Else
                        Dim idAP As Integer = funcEQ.idArticuloPedido(dts.gidEquipo)
                        If idAP <> iidArticuloPed Or dts.gnumPedido <> numPedido Or dts.gVersion <> Version Then
                            iidArticuloPed = idAP
                            TotalEquipos = 0
                            numPedido = dts.gnumPedido
                            Version = dts.gVersion
                        End If
                    End If

                    'Si ya había algo, vamos sumando unidades
                    If (Vista = "ELECTRÓNICA" And dts.gidEstadoElectronica = EstadoCompleto.gidEstado) Or _
                        (Vista = "TALLER" And dts.gidEstadoTaller = EstadoCompleto.gidEstado) Then
                        Matriz(fila, columna).gNum1 = Matriz(fila, columna).gNum1 + 1
                    End If

                    TotalEquipos = TotalEquipos + 1
                    Matriz(fila, columna).gNum2 = TotalEquipos
                    Matriz(fila, columna).gContenido = CStr(Matriz(fila, columna).gNum1) & "/" & CStr(TotalEquipos)

                    'Colorear los contenidos de las celdas centrales
                    If Matriz(fila, columna).gContenido <> "-" Then
                        If dts.gidEstado = EstadoEnCurso.gidEstado And Matriz(fila, columna).gColorLetra <> ColorEnCurso Then
                            Matriz(fila, columna).gColorLetra = ColorEmpezadoOtro
                        End If
                        If Vista = "ELECTRÓNICA" And dts.gidEstadoElectronica = EstadoEnCurso.gidEstado Then
                            Matriz(fila, columna).gColorLetra = ColorEnCurso
                        End If

                        If Matriz(fila, columna).gNum1 > 0 Or Matriz(fila, columna).gColorLetra = ColorEnCurso Then
                            Matriz(fila, columna).gColorLetra = ColorEnCurso
                        End If

                        If Matriz(fila, columna).gNum1 = TotalEquipos Then
                            Matriz(fila, columna).gColorLetra = ColorAcabado
                        End If
                    End If
                    'Acumular en la columna Pendientes
                    If Matriz(fila, ColumnaPendientes).gContenido = "" Then Matriz(fila, ColumnaPendientes).gContenido = 0
                    Matriz(fila, ColumnaPendientes).gContenido = CInt(Matriz(fila, ColumnaPendientes).gContenido) + 1

                    'Ahora restamos lo completado en la columna pendientes
                    If Vista = "ELECTRÓNICA" And dts.gidEstadoElectronica = EstadoCompleto.gidEstado Then
                        Matriz(fila, ColumnaPendientes).gContenido = CInt(Matriz(fila, ColumnaPendientes).gContenido) - 1
                    End If
                    If Vista = "TALLER" And dts.gidEstadoTaller = EstadoCompleto.gidEstado Then
                        Matriz(fila, ColumnaPendientes).gContenido = CInt(Matriz(fila, ColumnaPendientes).gContenido) - 1
                    End If
                    'Ahora detectamos los cambios de hoy para ponerlo en azul
                    Call ColorearRecientesTotalizadores(fila, dts.gCreacion)
                    Call ColorearRecientesPedido(columna, dts.gCreacion)

                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TotalesXPedido()
        filaTotales = Matriz.GetLength(0) - 2
        Matriz(filaTotales, 1).gContenido = "TOTALES POR PEDIDO"
        Dim suma1 As Integer = 0
        Dim suma2 As Integer = 0
        For C = ColumnasFijasIzquierda To Matriz.GetLength(1) - 1
            For f As Integer = 4 To filaTotales - 1
                Matriz(filaTotales, C).gNum1 = Matriz(filaTotales, C).gNum1 + Matriz(f, C).gNum1
                Matriz(filaTotales, C).gNum2 = Matriz(filaTotales, C).gNum2 + Matriz(f, C).gNum2
            Next
            Matriz(filaTotales, C).gContenido = CStr(Matriz(filaTotales, C).gNum1) & "/" & CStr(Matriz(filaTotales, C).gNum2)
            'If Matriz(filaTotales, C).gNum1() = Matriz(filaTotales, C).gNum2 Then
            '    Call ColorearColumna(C)
            'End If
            suma1 = suma1 + Matriz(filaTotales, C).gNum1
            suma2 = suma2 + Matriz(filaTotales, C).gNum2

        Next
        Matriz(filaTotales, ColumnaPendientes).gNum1 = suma1
        Matriz(filaTotales, ColumnaPendientes).gNum2 = suma2
        Matriz(filaTotales, ColumnaPendientes).gContenido = suma1 & "/" & suma2

    End Sub

    Private Sub ColorearColumna(ByVal C As Integer)
        For f = FilasFijasArriba To filaTotales - FilasFijasAbajo
            If C Mod 2 = 0 Then
                Matriz(f, C).gColorFondo = colorVerdePalido
            Else
                Matriz(f, C).gColorFondo = colorVerdeGrisaceo
            End If
        Next
    End Sub

    Private Sub DiasLaborables()
        Dim filaDias As Integer = Matriz.GetLength(0) - 1
        Matriz(filaDias, 1).gContenido = "DÍAS LABORABLES"
        For C = ColumnasFijasIzquierda To lDias.Count - 1
            Matriz(filaDias, C).gContenido = lDias(C)
            If lDias(C) <= DiasAvisoRojo Then Matriz(filaDias, C).gColorLetra = Color.Red
        Next
    End Sub

    Private Sub TotalPdidos()
        Matriz(1, ColumnaPendientes).gContenido = lnumSPedido.Count - ColumnasFijasIzquierda
        Matriz(1, ColumnaPendientes).gColorLetra = Color.Red
        Dim Fuente As New Font("Century Gothic", 14, FontStyle.Bold)
        Matriz(1, ColumnaPendientes).gFuente = Fuente
    End Sub



    Private Function DiasPrevistos(ByVal Fecha As Date) As Integer
        'Devuelve los dias laborables previstos desde hoy a la fecha prevista
        Dim dia As Date = Now.Date
        Dim contador As Integer = 0
        Do While dia < Fecha
            If funcFE.EsFestivo(dia) Then
            Else
                contador = contador + 1
            End If
            dia = dia.AddDays(1)
        Loop
        Return contador
    End Function




    Private Sub CargarListas()
        Dim codCli As String = "-"
        Dim codArticulo As String = "-"
        Dim stock As Double = 0
        Dim Cantidad As Double = 0
        Dim FechaPrevista As Date = Now.Date
        Dim Dias As Integer
        lArticulos = New List(Of Datos4)
        Dim indice As Integer = 0

        'En una primera pasada, creamos la lista de pedidos, que nos dará el nº de columnas
        Dim Prioridad As Short = 0 'Inicializamos con valores imposibles para que siempre se detecte el cambio la primera vez
        Dim numPedido As Integer = -1
        Dim FechaPedido As Date = CDate("1-1-1900")
        Dim sArticulo As Datos4
        Dim NombreArticuloTip As String
        For Each dts As DatosEquipoProduccion In lista
            NombreArticuloTip = dts.gArticulo & If(dts.gcodArticulo = "", "", " (" & dts.gcodArticulo & ") ")
            If Vista = "TALLER" Then
                sArticulo = New Datos4(dts.gidArticulo, NombreArticuloTip, Microsoft.VisualBasic.Left(dts.gArticulo, 50), dts.gVersion)
            Else
                sArticulo = New Datos4(dts.gidArticulo, NombreArticuloTip, If(dts.gcodArticulo = "", Microsoft.VisualBasic.Left(dts.gArticulo, 50), dts.gcodArticulo), dts.gVersion)
            End If


            If Not lArticulosContiene(sArticulo) Then
                lArticulos.Add(sArticulo)

            End If
            If dts.gPrioridad <> Prioridad Or dts.gnumPedido <> numPedido Or dts.gFechaPrevista <> FechaPrevista Then 'Identificamos un cambio de pedido
                Prioridad = dts.gPrioridad
                lPrioridades.Add(Prioridad)
                numPedido = dts.gnumPedido

                lnumSPedido.Add(numPedido)
                lidSProduccion.Add(If(numPedido = 0, dts.gidProduccion, 0))
                lnumSPedidoAbrev.Add(If(numPedido = 0, "MAN", Microsoft.VisualBasic.Right(CStr(numPedido), 4)))
                lFechasPedido.Add(UCase(Format(dts.gFechaPedido, "dd-MMM")))
                lClientes.Add(dts.gcodCli & If(funcCL.ObservacionesProd(dts.gidCliente) = "", "", "*"))
                lidClientes.Add(dts.gidCliente)
                FechaPrevista = dts.gFechaPrevista
                Dias = DiasPrevistos(FechaPrevista)
                lDias.Add(Dias)
                'lTotales.Add(0)
                ' lTotalesBarra.Add(0)
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
        Dim cadena1 As String = x.gDato1 & x.gDato3
        Dim cadena2 As String = y.gDato1 & y.gDato3
        Return cadena1.CompareTo(cadena2)
    End Function

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




    Private Sub InicializarMatriz()
        Dim Fuente As New Font("Century Gothic", 9, FontStyle.Bold)
        For f As Integer = 0 To Matriz.GetLength(0) - 1
            For c As Integer = 0 To Matriz.GetLength(1) - 1
                If c >= ColumnasFijasIzquierda And f >= FilasFijasArriba And f <= Matriz.GetLength(0) - FilasFijasAbajo Then
                    Matriz(f, c) = New CeldaVista(f, c, "-", ColorLetra(f, c), ColorFondo(f, c), Fuente, Alineacion(f, c), "", "")
                Else
                    Matriz(f, c) = New CeldaVista(f, c, "", ColorLetra(f, c), ColorFondo(f, c), Fuente, Alineacion(f, c), "", "")
                End If
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


    Private Function ColorFondo(ByVal f As Integer, ByVal c As Integer) As Color
        filaTotales = Matriz.GetLength(0) - 2
        Select Case f
            Case 0
                If c >= ColumnasFijasIzquierda Then
                    Return Color.Yellow
                Else
                    Return Color.White
                End If
            Case 1
                If c >= ColumnasFijasIzquierda Then
                    Return Color.LightSalmon
                Else
                    Return Color.White
                End If
            Case 2
                If c >= ColumnasFijasIzquierda Then
                    Return Color.Yellow
                Else
                    Return Color.White
                End If
            Case 3
                If c >= ColumnasFijasIzquierda Then
                    Return Color.LightGray
                Else
                    Return Color.White
                End If
            Case Matriz.GetLength(0) - 2
                Return Color.Black
            Case Matriz.GetLength(0) - 1
                Return Color.Black
            Case Else
                If c = ColumnaPendientes Then
                    Return Color.Yellow
                ElseIf c >= ColumnasFijasIzquierda Then
                    If c Mod 2 = 0 Then
                        Return Color.LightGray
                    Else
                        Return Color.White
                    End If
                Else
                    Return Color.White
                End If
        End Select
    End Function


    Private Function ColorLetra(ByVal f As Integer, ByVal c As Integer) As Color
        Select Case f
            Case Matriz.GetLength(0) - 2
                Return Color.White
            Case Matriz.GetLength(0) - 1
                Return Color.White
            Case 0, 1, 2, 3
                If c = 1 Then
                    Return Color.DarkGreen
                Else
                    Return Color.Black
                End If
            Case Else

        End Select
    End Function





    Private Sub ColorearRecientesTotalizadores(ByVal fila As Integer, ByVal Fecha As Date)
        Try
            If Matriz(fila, ColumnaPendientes).gColorFondo <> ColorReciente Then
                If EsReciente(Fecha) Then
                    Matriz(fila, ColumnaPendientes).gColorFondo = ColorReciente
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ColorearRecientesPedido(ByVal columna As Integer, ByVal Fecha As Date)
        Try
            If Matriz(2, columna).gColorFondo <> ColorReciente Then
                If EsReciente(Fecha) Then
                    Matriz(2, columna).gColorFondo = ColorReciente
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub BotonDerecho(ByVal celda As CeldaVista)
        If celda.gColumna >= ColumnasFijasIzquierda Then
            Select Case celda.gFila
                Case 1
                    Call BotonDerechoFecha(celda)
                Case 2
                    Call BotonDerechoPedido(celda)

            End Select
        End If

    End Sub

    Private Sub BotonDerechoFecha(ByVal celda As CeldaVista)
        If IsNumeric(celda.gReferencia) Then
            Dim GG As New subCambioFechaEntrega
            GG.pnumPedido = celda.gReferencia
            GG.ShowDialog()
        End If

    End Sub

    Private Sub BotonDerechoPedido(ByVal celda As CeldaVista)
        If IsNumeric(celda.gReferencia) Then
            Dim GG As New InformePedido
            GG.verInforme(celda.gReferencia, 1, True, False, True)
            GG.ShowDialog()
        End If
    End Sub


    Public Function DobleClick(ByVal celda As CeldaVista) As Boolean
        Dim Resultado As Boolean = True
        If celda.gColumna = 1 AndAlso celda.gFila = 0 Then
            'Call OrdenarPorFechaPrevista()
            Resultado = False
        ElseIf celda.gColumna = 1 AndAlso celda.gFila = 1 Then
            'Call OrdenarPorFechaPedido()
            Resultado = False
        ElseIf celda.gColumna = 1 AndAlso celda.gFila = 2 Then
            'Call OrdenarPorNumPedido()
            Resultado = False
        ElseIf celda.gColumna = 1 AndAlso celda.gFila = 3 Then
            'Call OrdenarPorCliente()
            Resultado = False
        ElseIf celda.gColumna >= ColumnasFijasIzquierda Then
            Select Case celda.gFila
                Case 1
                    Call DobleClickFecha(celda)
                Case 2
                    Call DobleClickPedido(celda)
                Case 3
                    Call DobleClickCliente(celda)
                Case Is < Matriz.GetLength(0) - 2
                    Call DobleClickCelda(celda)
                Case Else
                    Resultado = False
            End Select
        ElseIf celda.gColumna = 2 And celda.gFila >= FilasFijasArriba And celda.gFila < Matriz.GetLength(0) - 2 Then
            Call DobleClickCelda(celda)
        Else
            Resultado = False
        End If
        Return Resultado
    End Function


    Private Sub OrdenarPorFechaPrevista()

    End Sub

    Private Sub OrdenarPorFechaPedido()

    End Sub

    Private Sub OrdenarPorNumPedido()
        'Ordenar la lista lnumSPedido y arrastrar las otras listas
      

    End Sub

    Private Sub OrdenarPorCliente()

    End Sub





    Private Sub DobleClickFecha(ByVal celda As CeldaVista)
        Dim texto As String
        If funcPE.Acabando(celda.gReferencia) Then
            texto = "¿Desmarcar el pedido " & celda.gReferencia & " como en Fase de Cerrar?"
        Else
            texto = "¿Marcar el pedido " & celda.gReferencia & " como en Fase de Cerrar?"
        End If
        If MsgBox(texto, MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            If funcPE.CambiaAcabando(celda.gReferencia) Then
                celda.gColorFondo = ColorAcabando
            Else
                celda.gColorFondo = Color.LightSalmon
            End If
        End If
    End Sub

    Private Sub DobleClickPedido(ByVal celda As CeldaVista)

        Dim GG As New subPonerEnPruebas
        GG.pnumPedido = celda.gReferencia
        GG.ShowDialog()
        If GG.DialogResult = Windows.Forms.DialogResult.OK Then
            If GG.pEnPruebas Then
                celda.gColorFondo = ColorPruebas
            Else
                celda.gColorFondo = Color.Yellow
            End If
        End If

    End Sub

    Private Sub DobleClickCliente(ByVal celda As CeldaVista)
        Dim GG As New subClienteProd
        Dim dtsCL As datoscliente = funcCL.mostrar1(celda.gReferencia)
        GG.pCliente = dtsCL.gnombrecomercial
        GG.pObservaciones = dtsCL.gObservacionesProd
        GG.ShowDialog()
    End Sub

    Private Sub DobleClickCelda(ByVal celda As CeldaVista)
        If celda.gReferencia <> "" Then
            Dim GG As New GestionEquiposProduccion 'Vemos la linea de producción
            If celda.gColumna = 2 Then
                GG.pidArticulo = celda.gReferencia
            Else
                GG.pidSProduccion = celda.gReferencia
            End If
            GG.SoloLectura = vSoloLectura
            GG.pVista = Vista
            GG.ShowDialog()
        End If
    End Sub

    Private Function lArticulosEn(ByVal iidArticulo As Integer, ByVal Version As Integer) As Integer
        If lArticulos.Count = 0 Then
            Return -1
        Else
            Dim i As Integer = 0
            While i < lArticulos.Count
                If lArticulos(i).gid = iidArticulo And lArticulos(i).gDato3 = Version Then Return i
                i = i + 1
            End While
            Return -1
        End If
    End Function

    'Private Function PedidoManualEn(ByVal iidArticulo As Integer) As Integer
    '    If lArticulos.Count = 0 Then
    '        Return -1
    '    Else
    '        Dim i As Integer = 0
    '        While i < lArticulos.Count
    '            If lArticulos(i).ItemData = iidArticulo Then Return i
    '            i = i + 1
    '        End While
    '        Return -1
    '    End If
    'End Function



    Private Function lArticulosContiene(ByVal sArticulo As Datos4) As Boolean
        If lArticulos.Count = 0 Then
            Return False
        Else
            Dim i As Integer = 0
            While i < lArticulos.Count
                If lArticulos(i).gid = sArticulo.gid And lArticulos(i).gDato3 = sArticulo.gDato3 Then Return True
                i = i + 1
            End While
            Return False
        End If
    End Function

End Class
