Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Text.RegularExpressions


Public Class ImportarReparaciones

    Private funcAR As New FuncionesArticulos
    Private funcRE As New FuncionesReparaciones
    Private funcCL As New funcionesclientes
    Private funcUB As New funcionesUbicaciones
    Private funcEST As New FuncionesEstatusReparacion
    Private funcES As New FuncionesEstados
    Private funcPR As New funcionesProveedores
    Private funcEQ As New FuncionesEquiposProduccion
    Private funcCP As New FuncionesConceptosPedidos
    Private funcTR As New FuncionesTrabajosReparaciones
    Private funcCR As New FuncionesConceptosReparaciones
    Private funcAL As New FuncionesAlbaranes
    Private funcEH As New FuncionesEquiposHistorico


    Public Sub Importar()

        Dim sConexion As String = CadenaConexion()

        Dim sel As String = "Select * from Reparaciones "
        sel = sel & " ORDER BY idRep ASC"
        Dim adaptador As New OleDbDataAdapter(sel, sConexion)
        Dim tablaDatos As New DataTable
        Dim linea As DataRow
        Dim resultado As String = -1
        Try
            adaptador.Fill(tablaDatos)
            Dim k As Integer = 0
            For Each linea In tablaDatos.Rows
                If linea("N") Is DBNull.Value OrElse Not IsNumeric(linea("N")) Then
                Else
                    If funcRE.Mostrar1(linea("N")).gnumReparacion > 0 Then
                        Observaciones.Text.Insert(0, linea("N") & " REPETIDO")
                    Else

                        Dim dts As DatosReparacion = CargarLineaReparacion(linea)
                        funcRE.insertarNumLibre(dts)
                        funcTR.insertar(CargarLineaTrabajoARealizar(linea))
                        Dim dtsCR As DatosConceptoReparacion = CargarConceptoTrabajo(linea)
                        'funcCR.insertar(dtsCR)
                        Materiales(dts, dtsCR.gnumPedido)
                        funcTR.insertar(CargarLineaTrabajoRealizado(linea))
                        Observaciones.Text = linea("N") & vbCrLf & Observaciones.Text
                        k = k + 1
                        If k = 100 Then
                            Application.DoEvents()
                            k = 0
                        End If

                        End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ActualizarMalImportados()

        Dim sConexion As String = CadenaConexion()

        Dim sel As String = "Select * from Reparaciones "
        sel = sel & " ORDER BY idRep ASC"
        Dim adaptador As New OleDbDataAdapter(sel, sConexion)
        Dim tablaDatos As New DataTable
        Dim linea As DataRow
        Dim resultado As String = -1

        Try
            adaptador.Fill(tablaDatos)
            For Each linea In tablaDatos.Rows
                If linea("N") Is DBNull.Value OrElse Not IsNumeric(linea("N")) Then
                Else
                    Dim dts As DatosReparacion = funcRE.Mostrar1(linea("N"))
                    If dts.gnumReparacion > 0 And dts.gidCliente = 0 Then
                        Dim dtsR As DatosReparacion = CargarLineaReparacion(linea)

                        funcRE.actualizar(dtsR)

                        Observaciones.Text = linea("N") & " Actualizado" & vbCrLf & Observaciones.Text
                        Application.DoEvents()
                    End If
                    If dts.gidEquipo = 0 Then
                        funcRE.actualizaidEquipoHistorico(dts.gnumReparacion, funcEH.idEquipoHistorico(dts.gnumSerie))
                    Else
                        funcRE.actualizaidEquipoHistorico(dts.gnumReparacion, 0)
                    End If

                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub






    Public Sub ImportarEquipos()

        Dim sConexion As String = CadenaConexion()

        Dim sel As String = "Select * from Fabricacion "
        sel = sel & " ORDER BY idFab ASC"
        Dim adaptador As New OleDbDataAdapter(sel, sConexion)
        Dim tablaDatos As New DataTable
        Dim linea As DataRow
        Dim resultado As String = -1
        Try
            adaptador.Fill(tablaDatos)
            For Each linea In tablaDatos.Rows
                If linea("NSerie") Is DBNull.Value Then
                Else
                    Dim iidEquipo As Integer = funcEQ.idEquipo(linea("NSerie"))
                    If iidEquipo = 0 Then 'solo importamos lis numSerie no existentes
                        Dim dts As DatosEquipoHistorico = CargarLineaEquipo(linea)
                        funcEH.insertar(dts)
                        Observaciones.Text = dts.gnumSerie & "  " & dts.gModelo & "  " & dts.gidArticulo & "  " & dts.gidCliente & vbCrLf & Observaciones.Text
                        Application.DoEvents()
                    End If

                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function CargarLineaEquipo(ByVal linea As DataRow) As DatosEquipoHistorico
        Try
            Dim dts As New DatosEquipoHistorico
            Dim numSerie As String = If(linea("NSerie") Is DBNull.Value, "", linea("NSerie"))
            numSerie = UCase(Trim(numSerie))


            Dim Modelo As String = If(linea("Modelo") Is DBNull.Value, "", linea("Modelo"))
            Modelo = Trim(UCase(Modelo))
            Modelo = Modelo.Replace("'", "''")
            Dim NombreCliente As String = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
            NombreCliente = UCase(Trim(NombreCliente))
            Dim nAlbaran As String = If(linea("NAlbaran") Is DBNull.Value, "", linea("NAlbaran"))
            nAlbaran = UCase(Trim(nAlbaran))
            Dim FechaFab As String = If(linea("FechaFab") Is DBNull.Value, "", linea("FechaFab"))
            If IsDate(FechaFab) AndAlso (Year(FechaFab) > 1900) Then
                dts.gFechaFab = CDate(FechaFab)
            Else
                dts.gFechaFab = CDate("1-1-1900")
            End If
            Dim FechaSal As String = If(linea("FechaSal") Is DBNull.Value, "", linea("FechaSal"))
            If IsDate(FechaSal) AndAlso (Year(FechaSal) > 1900) Then
                dts.gFechaSal = CDate(FechaSal)
            Else
                dts.gFechaSal = CDate("1-1-1900")
            End If
            dts.gnumSerie = numSerie
            dts.gBomba = Microsoft.VisualBasic.Left(If(linea("Bomba") Is DBNull.Value, "", linea("Bomba")), 50)
            dts.gTransporte = Microsoft.VisualBasic.Left(If(linea("Transporte") Is DBNull.Value, "", linea("Transporte")), 50)
            dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
            dts.gNombreCliente = Microsoft.VisualBasic.Left(NombreCliente, 50)
            dts.gNombreCliente = dts.gNombreCliente.Replace("'", "''")
            dts.gModelo = Modelo
            dts.gNAlbaran = nAlbaran
            dts.gnumAlbaran = 0
            dts.gnumPedido = 0
            dts.gnumFactura = 0
            If IsNumeric(nAlbaran) AndAlso (nAlbaran > 20000000 And nAlbaran < 30000000) Then
                dts.gnumAlbaran = nAlbaran
                dts.gidCliente = funcAL.idCliente(nAlbaran)
                Dim lista As List(Of Integer) = funcAL.NumsFactura(nAlbaran)
                dts.gnumFactura = If(lista.Count = 1, lista(0), 0)
                lista.Clear()
                lista = funcAL.NumsPedido(nAlbaran)
                dts.gnumPedido = If(lista.Count = 1, lista(0), 0)
            ElseIf funcCL.Contador(" Upper(NombreComercial) like '" & dts.gNombreCliente & "%' ") = 1 Then
                dts.gidCliente = funcCL.campoidCliente(dts.gNombreCliente)
            Else
                dts.gidCliente = funcCL.campoidCliente2(dts.gNombreCliente)
                If dts.gidCliente = 0 Then
                    Dim scliente As String = dts.gNombreCliente
                    If scliente.Contains("PISCINAS") Then
                        scliente = Replace(scliente, "PISCINAS", "PISCINES")
                    ElseIf scliente.Contains("PISCINES") Then
                        scliente = Replace(scliente, "PISCINES", "PISCINAS")
                    End If

                    dts.gidCliente = funcCL.campoidCliente2(scliente)
                    If dts.gidCliente = 0 Then
                        dts.gObservaciones = "CLIENTE = " & dts.gNombreCliente & vbCrLf & dts.gObservaciones
                        dts.gidCliente = 1289
                    End If
                End If
            End If
            If Modelo <> "" Then
                dts.gidArticulo = funcAR.idArticulo(Modelo)
            Else
                dts.gidArticulo = 0
            End If
            If dts.gidArticulo = 0 Then
                'Intentar detectar el código cambiando el orden de las opciones
                dts.gidArticulo = DetectarArticuloConOpciones(Modelo)
            End If
            dts.gObservaciones = Microsoft.VisualBasic.Left(dts.gObservaciones,300)
            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function DetectarArticuloConOpciones(ByVal codArticulo As String) As Integer
        Try
            Dim encuentro As Match
            Dim codArticuloBase As String = ""
            Dim Opciones As String = ""
            If codArticulo.Contains("-") Then Return 0
            Dim iidArticulo As Integer = 0
            encuentro = Regex.Match(codArticulo, "(?<codArticuloBase>(SAL|BIO|UV|OX|HD|AQ|ST)\s?[1-9][0-9]{0,2})\s?(?<Opciones>[A-Z\s]{0,10})")
            If encuentro.Success Then
                codArticuloBase = encuentro.Groups("codArticuloBase").Value

                If encuentro.Groups("Opciones").Value Is Nothing Then
                Else
                    Opciones = CStr(encuentro.Groups("Opciones").Value)

                    Opciones = Replace(Opciones, "A", "")
                    Opciones = Replace(Opciones, "PH", "B")
                    If Not Opciones Is Nothing AndAlso Not Opciones.Contains("BE") Then Opciones = Replace(Opciones, "E", "BE")
                    Opciones = Replace(Opciones, " ", "")
                End If
            End If
            If Opciones Is Nothing Then Opciones = ""
            If Opciones.Length < 6 Then
                iidArticulo = funcAR.idArticulo(codArticuloBase & Opciones)
                If Opciones = "" And iidArticulo = 0 Then
                    iidArticulo = funcAR.idArticulo(codArticuloBase)
                ElseIf Opciones.Length >= 2 Then
                    Dim listaCombinaciones As List(Of String) = Combinaciones(Opciones)
                    Dim i As Integer = 0
                    While i < listaCombinaciones.Count - 1 And iidArticulo = 0
                        iidArticulo = funcAR.idArticulo(codArticuloBase & listaCombinaciones(i))
                        i = i + 1
                    End While
                End If
            End If
            Return iidArticulo
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function

    Private Function Combinaciones(ByVal literal As String) As List(Of String)
        Dim lista As New List(Of String)
        If literal.Length = 2 Then
            lista.Add(literal)
            lista.Add(StrReverse(literal))
        Else
            For Each Letra As Char In literal
                Dim listaI As List(Of String) = Combinaciones(literal.Replace(Letra, ""))
                For Each subLiteral As String In listaI
                    lista.Add(Letra & subLiteral)
                Next
            Next
        End If
        Return lista
    End Function


    Private Sub Materiales(ByVal dtsR As DatosReparacion, ByVal numPedido As Integer)

        Dim sConexion As String = CadenaConexion()

        Dim sel As String = "Select * from Materiales where idRep = " & dtsR.gnumReparacion
        sel = sel & " ORDER BY idMat ASC"
        Dim adaptador As New OleDbDataAdapter(sel, sConexion)
        Dim tablaDatos As New DataTable
        Dim linea As DataRow

        Dim dts As DatosConceptoReparacion
        Dim resultado As String = -1
        Dim estadoTraspasadoR As Integer = funcES.EstadoTraspasado("REPARACION").gidEstado
        Dim estadoTraspasadoCR As Integer = funcES.EstadoTraspasado("C.REPARACION").gidEstado
        Dim estadoEsperaCR As Integer = funcES.EstadoEspera("C.REPARACION").gidEstado
        Try
            adaptador.Fill(tablaDatos)
            For Each linea In tablaDatos.Rows

                dts = New DatosConceptoReparacion
                dts.gnumReparacion = dtsR.gnumReparacion
                dts.gArticulo = If(linea("RefMat") Is DBNull.Value, "", linea("RefMat")) & If(linea("Descripcion") Is DBNull.Value, "", " " & linea("Descripcion"))
                dts.gArticuloCli = dts.gArticulo
                dts.gcodArticulo = ""
                dts.gcodArticuloCli = ""
                dts.gCantidad = If(linea("Unidades") Is DBNull.Value OrElse Not IsNumeric(linea("Unidades")), 0, linea("Unidades"))
                dts.gDescuento = 0
                dts.gidEstado = If(dts.gidEstado = estadoTraspasadoR, estadoTraspasadoCR, estadoEsperaCR)
                dts.gidArtCli = 0
                dts.gidArticulo = 0
                dts.gidTipoIVA = dtsR.gidTipoIVA
                dts.gidUnidad = 1
                dts.gnumProforma = 0
                dts.gnumOferta = 0
                dts.gnumPedido = numPedido
                dts.gPrecioNetoUnitario = If(linea("Precio") Is DBNull.Value OrElse Not IsNumeric(linea("Precio")), 0, linea("Precio"))
                dts.gPVPUnitario = dts.gPrecioNetoUnitario
                funcCR.insertar(dts)
            Next

        Catch ex As Exception

            MsgBox(ex.StackTrace)

        End Try

    End Sub




    Private Function CargarLineaReparacion(ByVal linea As DataRow) As DatosReparacion
        Dim dts As New DatosReparacion
        dts.gnumReparacion = linea("N")

        dts.gFecha = If(linea("Fecha") Is DBNull.Value OrElse Not IsDate(linea("Fecha")), Now.Date, linea("Fecha"))
        If dts.gFecha.Year = 0 Then dts.gFecha = Now.Date
        dts.gnumSerie = If(linea("NSerie") Is DBNull.Value, "", linea("NSerie"))
        Dim tipo As String = UCase(If(linea("Tipo") Is DBNull.Value, "", linea("Tipo")))
        dts.gCaja = tipo.Contains("CAJA")
        dts.gCelula = tipo.Contains("CELULA") Or tipo.Contains("CÉLULA")
        dts.gSonda = tipo.Contains("SONDA")
        dts.gPlaca = tipo.Contains("PLACA")
        tipo = tipo.Replace("CAJA", "")
        tipo = tipo.Replace("CELULA", "")
        tipo = tipo.Replace("CÉLULA", "")
        tipo = tipo.Replace("SONDAS", "")
        tipo = tipo.Replace("SONDA", "")
        tipo = tipo.Replace("PLACA", "")
        tipo = tipo.Replace("+", " ")
        tipo = Trim(tipo)
        If tipo.Length > 0 Then
            dts.gOtros = True
            dts.gOtrosTipos = tipo
        Else
            dts.gOtros = False
            dts.gOtrosTipos = ""
        End If
        Dim modelo As String = If(linea("Modelo") Is DBNull.Value, "", linea("Modelo"))
        Dim modelo0 As String = modelo
        modelo = Trim(modelo)
        modelo = modelo.Replace("'", "''")
        modelo = modelo.Replace(" ", "%")

        dts.gObservaciones = ""
        dts.gidArticulo = funcAR.idArticulo(modelo)
        If dts.gidArticulo = 0 Then
            If Microsoft.VisualBasic.Right(modelo, 1) = "A" Then
                modelo = Microsoft.VisualBasic.Left(modelo, Len(modelo) - 1)
                dts.gidArticulo = funcAR.idArticulo(modelo)
            End If
        End If
        If dts.gidArticulo = 0 Then
            'dts.gObservaciones = "MODELO: " & modelo0 & vbCrLf
            dts.gcodArticuloCli = modelo0
        Else
            dts.gcodArticuloCli = funcAR.codArticulo(dts.gidArticulo)
        End If
        dts.gCliente = If(linea("Cliente") Is DBNull.Value, "", linea("Cliente"))
        Dim nAlbaran As String = If(linea("NAlbaran") Is DBNull.Value, "", linea("NAlbaran"))
        If funcCL.Contador(" Upper(NombreComercial) like '" & dts.gCliente & "%' ") <> 1 Then
            If IsNumeric(nAlbaran) Then
                dts.gidCliente = funcAL.idCliente(nAlbaran)
            End If
            If dts.gidCliente = 0 Then
                dts.gidCliente = funcCL.campoidCliente2(dts.gCliente)
                If dts.gidCliente > 0 Then
                    Dim lista0 As List(Of datosUbicacion) = funcUB.mostrarCli(dts.gidCliente, True, False, True, False, False, True, False)
                    If lista0.Count = 1 Then
                        dts.gidUbicacion = lista0(0).gidUbicacion
                    Else
                        dts.gidUbicacion = 0
                    End If
                Else
                    Dim scliente As String = UCase(Trim(dts.gCliente))
                    If scliente.Contains("PISCINAS") Then Replace(scliente, "PISCINAS", "PISCINES")
                    If scliente.Contains("PISCINES") Then Replace(scliente, "PISCINES", "PISCINAS")
                    dts.gidCliente = funcCL.campoidCliente2(scliente)
                    If dts.gidCliente > 0 Then
                        Dim lista0 As List(Of datosUbicacion) = funcUB.mostrarCli(dts.gidCliente, True, False, True, False, False, True, False)
                        If lista0.Count = 1 Then
                            dts.gidUbicacion = lista0(0).gidUbicacion
                        Else
                            dts.gidUbicacion = 0
                        End If
                    Else

                        If dts.gObservaciones <> "" Then dts.gObservaciones = dts.gObservaciones & vbCrLf
                        dts.gObservaciones = dts.gObservaciones & "CLIENTE = " & dts.gCliente
                        dts.gidCliente = 1289
                        dts.gidUbicacion = 1296

                    End If
                End If
            Else
                dts.gidUbicacion = funcAL.idUbicacion(nAlbaran)
            End If

            'Observaciones.Text = "CLIENTE = " & dts.gCliente & "No encontrado" & vbCrLf & Observaciones.Text

        Else
            dts.gidCliente = funcCL.campoidCliente(dts.gCliente)
            Dim lista0 As List(Of datosUbicacion) = funcUB.mostrarCli(dts.gidCliente, True, False, True, False, False, True, False)
            If lista0.Count = 1 Then
                dts.gidUbicacion = lista0(0).gidUbicacion
            Else
                dts.gidUbicacion = 0
            End If
        End If

        If IsNumeric(nAlbaran) Then
            dts.gnumPedido = funcCP.numPedidoDelAlbaran(nAlbaran)
        Else
            dts.gnumPedido = 0
        End If
        dts.gnumProforma = 0
        dts.gnumOferta = 0
        dts.gReferenciaCliente = If(linea("RefCliente") Is DBNull.Value, "", linea("RefCliente"))
        If dts.gReferenciaCliente.Length > 20 Then
            If dts.gObservaciones <> "" Then dts.gObservaciones = dts.gObservaciones & vbCrLf
            dts.gObservaciones = dts.gObservaciones & "REF.CLIENTE = " & dts.gReferenciaCliente
        End If
        dts.gReferenciaCliente = Microsoft.VisualBasic.Left(dts.gReferenciaCliente, 20)

        dts.gEstatus = If(linea("Status") Is DBNull.Value, "", linea("Status"))

        If dts.gEstatus = "Pte. Revisión" Then dts.gEstatus = "PENDIENTE REVISIÓN"
        If dts.gEstatus = "Presup.Pte.Cliente" Then dts.gEstatus = "PRESUPUESTO PENDIENTE CLIENTE"
        If dts.gEstatus = "Presup. Aprobado" Then dts.gEstatus = "PRESUPUESTO APROBADO"
        dts.gEstatus = UCase(dts.gEstatus)
        If dts.gEstatus = "GARANTÍA" Or dts.gEstatus = "GARANTIA" Then
            dts.gGarantia = True

            dts.gEstatus = "EFECTUADA"
        Else
            dts.gGarantia = False
        End If
        dts.gEstatus = UCase(dts.gEstatus)
        dts.gidEstatus = funcEST.idEstatus(dts.gEstatus)
        If dts.gidEstatus = 0 Then
            If dts.gObservaciones <> "" Then dts.gObservaciones = dts.gObservaciones & vbCrLf
            dts.gObservaciones = dts.gObservaciones & "ESTATUS = " & dts.gEstatus
        End If

        If IsNumeric(nAlbaran) Then
            dts.gidEstado = funcES.EstadoTraspasado("REPARACION").gidEstado
        ElseIf Trim(nAlbaran) <> "" And (dts.gEstatus = "ENVIADA" Or dts.gEstatus = "DESTRUIR MATERIAL") Then
            dts.gidEstado = funcES.EstadoCompleto("REPARACION").gidEstado
        Else
            dts.gidEstado = funcES.EstadoEnCurso("REPARACION").gidEstado
        End If
        dts.gFechaEntrega = If(linea("FechaEnvio") Is DBNull.Value OrElse Not IsDate(linea("FechaEnvio")), dts.gFecha, linea("FechaEnvio"))
        If dts.gFechaEntrega.Year = 0 Then dts.gFechaEntrega = Now.Date
        dts.gidContacto = 0
        dts.gcodMoneda = "EU"
        dts.gSolicitadoVia = ""
        dts.gNotas = ""
        dts.gidPersona = 2 'Inicio.vIdUsuario
        dts.gidTipoValorado = 1

        Dim PrecioTransporte As String = If(linea("Transporte") Is DBNull.Value, 0, linea("Transporte"))
        If IsNumeric(PrecioTransporte) Then
            dts.gPrecioTransporte = PrecioTransporte
        Else
            dts.gPrecioTransporte = 0
        End If


        Dim SusPortes As String = UCase(If(linea("SusPortes") Is DBNull.Value, "", linea("SusPortes")))
        dts.gPortes = "P"
        If SusPortes.Contains("PAGADOS") Then dts.gPortes = "P"
        If SusPortes.Contains("DEBIDOS") Then dts.gPortes = "D"
        SusPortes = SusPortes.Replace("PAGADOS", "")
        SusPortes = SusPortes.Replace("DEBIDOS", "")
        SusPortes = SusPortes.Replace("()", "")

        Dim lista1 As List(Of datosProveedor) = funcPR.Busqueda(" WHERE NombreComercial like '" & SusPortes & "%' ", "")
        If lista1.Count = 1 Then
            dts.gidTransporte = lista1(0).gidProveedor
            dts.gTransporte = ""
        Else
            dts.gidTransporte = 0
            dts.gTransporte = SusPortes
        End If
        dts.gidTipoIVA = 2
        dts.gidTipoRetencion = 1
        dts.gRecargoEquivalencia = False
        dts.gProntoPago = 0

        If dts.gnumSerie = "" Then
            dts.gidEquipo = 0
        Else
            dts.gidEquipo = funcEQ.idEquipo(dts.gnumSerie)
            If dts.gidEquipo = 0 Then
                dts.gidEquipoHistorico = funcEH.idEquipoHistorico(dts.gnumSerie)
            End If
        End If
        dts.gFechaFabricacionRep = If(linea("FechaFab") Is DBNull.Value OrElse Not IsDate(linea("FechaFab")), Now.Date, linea("FechaFab"))
        If dts.gFechaFabricacionRep.Year < 1900 Then dts.gFechaFabricacionRep = Now.Date
        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))
        dts.gInspeccion = If(linea("Inspeccion") Is DBNull.Value, "", linea("Inspeccion"))


        Return dts
    End Function

    Private Function CargarLineaTrabajoARealizar(ByVal linea As DataRow) As DatosTrabajoReparacion
        Dim dts As New DatosTrabajoReparacion
        dts.gTrabajo = If(linea("Trabajos") Is DBNull.Value, "", linea("Trabajos"))
        dts.gFechaTrabajo = If(linea("Fecha") Is DBNull.Value OrElse Not IsDate(linea("Fecha")), Now.Date, linea("Fecha"))
        If dts.gFechaTrabajo.Year = 0 Then dts.gFechaTrabajo = Now.Date
        dts.gnumReparacion = linea("N")
        dts.gidPersona = 2 'Inicio.vIdUsuario
        dts.gHoras = 0
        dts.gidTrabajo = 0
        dts.gOrden = 0
        Return dts
    End Function

    Private Function CargarLineaTrabajoRealizado(ByVal linea As DataRow) As DatosTrabajoReparacion
        Dim dts As New DatosTrabajoReparacion
        dts.gTrabajo = ""
        dts.gFechaTrabajo = If(linea("Fecha") Is DBNull.Value OrElse Not IsDate(linea("Fecha")), Now.Date, linea("Fecha"))
        If dts.gFechaTrabajo.Year = 0 Then dts.gFechaTrabajo = Now.Date
        dts.gnumReparacion = linea("N")
        dts.gidPersona = 2 'Inicio.vIdUsuario
        dts.gHoras = 0
        dts.gidTrabajo = 0
        dts.gOrden = 1
        Return dts
    End Function

    Private Function CargarConceptoTrabajo(ByVal linea As DataRow) As DatosConceptoReparacion
        Dim dts As New DatosConceptoReparacion
        dts.gTipoIVA = 0 'If(linea("TipoIVA") Is DBNull.Value, 0, linea("TipoIVA"))
        dts.gRefCliente = ""
        Dim nAlbaran As String = If(linea("NAlbaran") Is DBNull.Value, "", linea("NAlbaran"))
        Dim estadoTraspasado As Integer = funcES.EstadoTraspasado("C.REPARACION").gidEstado
        If IsNumeric(nAlbaran) Then
            dts.gnumPedido = funcCP.numPedidoDelAlbaran(nAlbaran)
            If dts.gnumPedido = 0 Then
                dts = cargarConceptoCreado(linea)
            Else
                Dim lista As List(Of DatosConceptoPedido) = funcCP.Mostrar(dts.gnumPedido)
                For Each dtsCP As DatosConceptoPedido In lista
                    If dtsCP.gcodArticuloCli.Contains("REPARAC") Then
                        dts.gArticulo = dtsCP.gArticulo
                        dts.gcodArticulo = dtsCP.gcodArticulo
                        dts.gcodArticuloCli = dtsCP.gcodArticuloCli
                        dts.gArticuloCli = dtsCP.gArticuloCli
                        dts.gCantidad = dtsCP.gCantidad
                        dts.gDescuento = dtsCP.gDescuento
                        dts.gPrecioNetoUnitario = dtsCP.gPrecioNetoUnitario
                        dts.gidTipoIVA = dtsCP.gidTipoIVA
                        dts.gTipoIVA = dtsCP.gTipoIVA
                        dts.gidEstado = estadoTraspasado
                    End If
                Next
                If dts.gArticulo = "" Then dts = cargarConceptoCreado(linea)
            End If
        Else
            dts = cargarConceptoCreado(linea)
        End If
        dts.gnumReparacion = linea("N")
        Return dts
    End Function

    Private Function cargarConceptoCreado(ByVal linea As DataRow) As DatosConceptoReparacion
        Dim dts As New DatosConceptoReparacion
        dts.gArticulo = "Reparación"
        dts.gcodArticulo = ""
        dts.gcodArticuloCli = ""
        dts.gArticuloCli = "Reparación"
        dts.gCantidad = 1
        dts.gDescuento = 0
        dts.gPrecioNetoUnitario = If(linea("TotalNeto") Is DBNull.Value OrElse Not IsNumeric(linea("TotalNeto")), 0, linea("TotalNeto"))
        dts.gidTipoIVA = 2
        dts.gnumProforma = 0
        dts.gnumPedido = 0
        dts.gPVPUnitario = dts.gPrecioNetoUnitario
        dts.gidEstado = funcES.EstadoEspera("C.REPARACION").gidEstado
        Return dts
    End Function

    Public Function CadenaConexion() As String

        Return "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & datos.Text & ";Persist Security Info=False" & ";Jet OLEDB:Database Password=;"

    End Function


    Private Sub bGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGuardar.Click
        Call Importar()
    End Sub


    Private Sub ImportarReparaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        datos.Text = "C:\PROYECTO ERP_SUGAR\GestionV2Win7\GestionStocks\gestion.mdb"
    End Sub

    Private Sub bImportarEquipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImportarEquipos.Click
        Call ImportarEquipos()


    End Sub


    Private Sub bImportarReparacionesCliente0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bImportarReparacionesCliente0.Click
        Call ActualizarMalImportados()
    End Sub
End Class