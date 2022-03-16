<System.Serializable()> Public Class EstadisticasVentas

    'VARIABLES GENERALES--------------------------------------------------------------------------
#Region "VARIABLES"
    Private funcCF As New FuncionesConceptosFacturas
    Private funcSP As New FuncionessubTiposArticulo
    Private funcPE As New FuncionesPersonal
    Private funcCL As New funcionesclientes
    Private funcAR As New FuncionesArticulos
    Private funcMO As New FuncionesMoneda
    Private funcPA As New funcionesPaises
    Private funcFA As New FuncionesFacturas
    Private iidTipoArticulo As Integer
    Private CambioFechas As Boolean
    Private Orden As String
    Private Direccion As String
    Private Columna As Integer
    Private sBusqueda As String
    Private Semaforo As Boolean
    Private vSoloLectura As Boolean
    Private VerClientesPropios As Boolean
    Private PaisPorDefecto As datosPais
    Dim bloqueoSubTipos As Boolean
    Dim checkActivado As Boolean
    Dim checkTodos As Boolean
    Dim vNumColumnas As Integer = 0
    Dim vTipoInforme As Integer = 0
    Dim sqlwhere As String
    Dim sbusquedaAños As String
    Dim sbusquedaRaiz As String
    Dim cRaices As String = ""
    Dim ordenColumna As Boolean

#End Region


    'PROPIEDADES----------------------------------------------------------------------------------
#Region "PROPIEDADES"
    Public Property SoloLectura() As Boolean
        Get
            Return vSoloLectura
        End Get
        Set(ByVal value As Boolean)
            vSoloLectura = value
        End Set
    End Property
#End Region


    'INICIALIZACIÓN DE PARAMETROS-----------------------------------------------------------------
#Region "INICIALIZACIÓN"
    'Validamos permisos.
    Private Sub Inicializar()
        'PERMISOS 
        VerClientesPropios = funcPE.Parametro(Inicio.vIdUsuario, "ConsultaCliente", "SOLO CLIENTES PROPIOS")
        PaisPorDefecto = funcPA.mostrar1(1)
    End Sub

#Region "LLENAR COMBOBOX"
    'Introducimos comerciales en el combobox.
    Private Sub IntroducirResponsables()
        Dim func As New funcionesclientes
        Dim lista As List(Of IDComboBox) = funcPE.ListarResponsables(If(VerClientesPropios, Inicio.vIdUsuario, 0))
        For Each item As IDComboBox In lista
            cbComercial.Items.Add(item)
        Next
        cbComercial.Items.Add("TODOS")
        If VerClientesPropios Then
            cbComercial.Enabled = False
            If lista.Count = 0 Then
                MsgBox("No está autorizado para visualizar clientes")
                Me.Close()
            Else
                cbComercial.SelectedIndex = 0
            End If
        Else
            cbComercial.SelectedIndex = -1
        End If
        cbComercial.Text = "TODOS"
    End Sub

    'Introducimos años en el combobox.
    Private Sub IntroducirAños()
        cbAño.Items.Clear()
        For Año = funcFA.buscaPrimerDia(0).Year To Now.Year
            cbAño.Items.Add(Año)
            lbxAños.Items.Add(Año)
        Next
        cbAño.Items.Add("TODOS")
        cbAño.Text = Now.Year
    End Sub

    'Introducimos los trimestres en el combobox.
    Private Sub IntroducirTrimestres()
        cbTrimestre.Items.Clear()
        cbTrimestre.Items.Add("TRIMESTRE 1")
        cbTrimestre.Items.Add("TRIMESTRE 2")
        cbTrimestre.Items.Add("TRIMESTRE 3")
        cbTrimestre.Items.Add("TRIMESTRE 4")
        cbTrimestre.SelectedIndex = -1
    End Sub

    'Introducimos los meses en el combobox.
    Private Sub IntroducirMeses()
        cbMes.Items.Clear()
        For Mes = 1 To 12
            cbMes.Items.Add(UCase(MonthName(Mes)))
        Next
        cbMes.SelectedIndex = -1
    End Sub

    'Introducimos los clientes en el combobox.
    Private Sub introducirClientes()
        cbCliente.Items.Clear()
        Dim lista As List(Of datoscliente) = funcCL.mostrar(True)
        cbCliente.Items.Add("TODOS")
        For Each dts As datoscliente In lista
            cbCliente.Items.Add(New IDComboBox(dts.gnombrefiscal, dts.gidCliente))
        Next
    End Sub

    'Introducimos los estados en el combobox.
    Private Sub introducirEstados()
        Dim funcES As New FuncionesEstados
        cbEstado.Items.Clear()
        Dim lista As List(Of DatosEstado) = funcES.Mostrar("Factura")
        For Each dts As DatosEstado In lista
            cbEstado.Items.Add(dts)
        Next
        cbEstado.Items.Add("TODOS")
        cbEstado.Text = "TODOS"
    End Sub

    'Introducimos los articulos en el combobox.
    Private Sub IntroducirArticulosC()
        cbCodArticulo.Items.Clear()
        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1
        cbArticulo.Items.Clear()
        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1
        Dim lista As List(Of IDComboBox3) = funcAR.Listar("VENDIBLE")
        For Each dts As IDComboBox3 In lista
            cbArticulo.Items.Add(dts)
            If dts.Name1 <> "" Then cbCodArticulo.Items.Add(New IDComboBox(dts.Name1, dts.ItemData))
        Next
    End Sub

    'Introducimos los tipo de articulos en el combobox.
    Private Sub IntroducirTiposArticulo()
        Dim funcTI As New FuncionesTiposArticulo
        cbTipo.Items.Clear()
        cbTipo.Text = ""
        cbSubTipo.Items.Clear()
        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1
        Dim lista As List(Of DatosTipoArticulo) = funcTI.Mostrar(0, True)
        Dim dts As DatosTipoArticulo
        For Each dts In lista
            cbTipo.Items.Add(New IDComboBox(dts.gTipoArticulo, dts.gidTipoArticulo))
        Next
        cbTipo.Items.Add(New IDComboBox("SIN TIPO", 0))
    End Sub

    'Introducimos los paises en el combobox.
    Private Sub introducirPaises()
        Try
            Dim lista As List(Of datosPais) = funcPA.mostrar
            Dim dts As datosPais
            cbPais.Items.Add("TODOS")
            For Each dts In lista
                cbPais.Items.Add(dts)
            Next
            cbPais.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Introducimos las provincias en el combobox.
    Private Sub introducirProvincias()
        Try
            cbProvincia.Items.Clear()
            Dim iidPais As Integer = If(cbPais.SelectedIndex = -1 Or cbPais.SelectedIndex = 0, 1, cbPais.SelectedItem.gidPais)
            Dim func As New funcionesProvincia
            Dim lista As List(Of datosProvincia) = func.mostrar(iidPais, cbAutonomia.Text)
            Dim dts As datosProvincia
            For Each dts In lista
                cbProvincia.Items.Add(dts)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Introducimos las autonomias en el combobox.
    Private Sub introducirAutonomias()
        cbAutonomia.Items.Clear()
        Dim iidPais As Integer = If(cbPais.SelectedIndex = -1, 1, cbPais.SelectedItem.gidPais)
        Dim funcAU As New funcionesAutonomias
        Dim lista As List(Of datosAutonomia) = funcAU.mostrar(iidPais)
        For Each dts As datosAutonomia In lista
            cbAutonomia.Items.Add(dts)
        Next
    End Sub

    'Llena el combobox de subtiposarticulos
    Private Sub IntroducirSubTiposArticulo()
        iidTipoArticulo = cbTipo.SelectedItem.itemdata
        If iidTipoArticulo > 0 Then
            cbSubTipo.Text = ""
            cbSubTipo.Items.Clear()
            Dim lista As List(Of DatosSubTipoArticulo) = funcSP.Mostrar(iidTipoArticulo, 0, True)
            Dim dts As DatosSubTipoArticulo
            For Each dts In lista
                cbSubTipo.Items.Add(New IDComboBox(dts.gSubTipoArticulo, dts.gidSubTipoArticulo))
            Next
        End If
    End Sub
#End Region

#End Region


    'CARGA DEL FORMULARIO Y CIERRE----------------------------------------------------------------
#Region "CARGA Y CIERRE"

    'Cargamos el formulario con los valores iniciales.
    Private Sub EstadisticasVentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Semaforo = False

        cbAutonomia.Enabled = False 'Desactivamos el combobox
        cbProvincia.Enabled = False 'Desactivamos el combobox

        'Configuraciones de pantalla de RAFA.
        Dim desktopSize As Size = System.Windows.Forms.SystemInformation.PrimaryMonitorMaximizedWindowSize
        Me.Height = desktopSize.Height - 15
        Me.Location = New Point(Me.Location.X, 0)

        Call Inicializar() 'Llamamos al procedimiento de inicializar.

        Call Limpiar() 'Limpiamos el formulario.

        Semaforo = False

        configurarLvRaices() 'Configuramos el listview raices.

        'Call formatLvEstadisticas() 'Formateamos el listview estadisticas.

        'Introducimos los datos en los controles
        Call introducirClientes()
        Call IntroducirAños()
        Call IntroducirTrimestres()
        Call IntroducirMeses()
        Call IntroducirResponsables()
        Call introducirEstados()
        Call IntroducirTiposArticulo()
        Call IntroducirArticulosC()
        Call introducirPaises()


        Call Busqueda() 'Iniciamos la busqueda con los valores iniciales.

        Semaforo = True
    End Sub

#End Region


    'FUNCIONES Y PROCEDIMIENTOS-------------------------------------------------------------------
#Region "LIMPIAR FORMULARIOS"

    'Limpiamos el formulario de los valores.
    Public Sub Limpiar()

        Semaforo = False

        cbAutonomia.Text = ""
        cbAutonomia.SelectedIndex = -1

        cbProvincia.Text = ""
        cbProvincia.SelectedIndex = -1

        cbCliente.Text = "TODOS"

        cbPais.Text = ""
        cbPais.SelectedIndex = -1

        cbTipo.SelectedIndex = -1

        cbSubTipo.Text = ""
        cbSubTipo.SelectedIndex = -1

        cbCodArticulo.Text = ""
        cbCodArticulo.SelectedIndex = -1

        cbArticulo.Text = ""
        cbArticulo.SelectedIndex = -1

        cbEstado.SelectedIndex = -1
        cbEstado.Text = "TODOS"

        cbAño.Text = Now.Year

        cbMes.Text = ""
        cbMes.SelectedIndex = -1

        cbTrimestre.Text = ""
        cbTrimestre.SelectedIndex = -1

        ckRaiz.Checked = False
        ckAños.Checked = False
        ckTodo.Checked = False
        gbxRaices.Visible = False 'Ocultamos el groupbox raices.
        gbxAños.Enabled = False 'Desactivamos groupbox años
        gbxMeses.Enabled = False 'Desactivamos groupbox meses

        CambioFechas = False
        dtpDesde.Value = CDate("1-1-" & Now.Year)
        dtpHasta.Value = Now.Date

        If Not VerClientesPropios Then
            cbComercial.SelectedIndex = -1
            cbComercial.Text = "TODOS"
        End If

        CambioFechas = False
        Orden = "Cliente"
        Direccion = "ASC"
        Columna = 0
        ckInformeComerciales.Checked = False
        ckInformeTipos.Checked = False
        Semaforo = True
    End Sub

#End Region


    'FORMATEAMOS EL LISTVIEW DE ESTADISTICAS------------------------------------------------------
#Region "FORMATEAR LISTVIEW ESTADÍSTICAS"
    'FORMATEAR LISTVIEW ESTADISTICAS BASE---------------------------------------------------------
    Public Sub formatLvEstadisticas()
        With lvEstadisticas
            .Clear()
            .GridLines = True
            .Columns.Add("") 'Campo ID
            .Columns.Add("") 'Campo Nombre
            If ckRaiz.Checked = False Then
                .Columns(0).Width = 0
                .Columns(1).Width = 350
            End If

        End With
        formatColumslvEstadisticas()
    End Sub
    'FORMATEAMOS EL TÍTULOS DE LAS COLUMNAS-------------------------------------------------------
    Public Sub formatColumslvEstadisticas()
        With lvEstadisticas
            If ckRaiz.Checked = True Then 'Si el checkbox de raices está activa
                '.Columns(0).Text = "RAIZ"
                '.Columns(1).Text = "CODIGO"
                lvEstadisticasRaiz()
            Else
                If ckInformeComerciales.Checked Then 'Si el checkbox infomes comerciales está activo.
                    .Columns(0).Text = "ID COMERCIAL"
                    .Columns(1).Text = "COMERCIAL"
                Else
                    If ckInformeTipos.Checked Then
                        If ckSubTipos.Checked Then 'Si los checkbox tipos y subtipos están activos.
                            .Columns(0).Text = "ID TIPO"
                            .Columns(1).Text = "TIPO DE ARTÍCULO  / SUBTIPO DE ARTICULO"
                        Else
                            .Columns(0).Text = "ID TIPO"
                            .Columns(1).Text = "TIPO DE ARTÍCULO"
                        End If
                    Else
                        If cbPais.Text = "TODOS" Then 'Si el texto de combobox País es igual a TODOS
                            .Columns(0).Text = "ID PAÍS"
                            .Columns(1).Text = "PAÍS"
                        Else
                            .Columns(0).Text = "ID CLIENTE"
                            .Columns(1).Text = "CLIENTE"
                        End If
                    End If
                End If
            End If

            If ckAños.Checked = False And ckRaiz.Checked = False Then 'Si el check años o el check raiz están inactivos
                .Columns.Add("") 'Campo cantidad
                .Columns.Add("") 'Campo Base
                .Columns.Add("") 'Campo Coste
                .Columns(2).Width = 150
                .Columns(2).TextAlign = HorizontalAlignment.Right
                .Columns(2).Text = "CANTIDAD"
                .Columns(3).Width = 150
                .Columns(3).TextAlign = HorizontalAlignment.Right
                .Columns(3).Text = "TOTAL BASE"
                .Columns(4).Width = 150
                .Columns(4).TextAlign = HorizontalAlignment.Right
                .Columns(4).Text = "TOTAL COSTE"
            End If
        End With
        Dim numColumnas As Integer = 1
        vNumColumnas = 0
        lvTotales.Clear()
        lvTotales.Columns.Add("TOTALES")
        lvTotales.Columns(0).Width = 350
        'For Each item In cbAño.Items
        For Each item In lbxAños.SelectedItems
            lvTotales.Columns.Add(item)
            lvTotales.Columns(numColumnas).TextAlign = HorizontalAlignment.Right
            lvTotales.Columns(numColumnas).Width = 150
            numColumnas = numColumnas + 1
            vNumColumnas = vNumColumnas + 1
        Next
    End Sub
    'FORMATEAMOS EL LISTVIEV ESTADISTICAS POR RAIZ------------------------------------------------
    Public Sub lvEstadisticasRaiz()
        Try
            Dim numColumnas As Integer = 1
            vNumColumnas = 0
            With lvEstadisticas
                lvTotales.Clear()
                'Si años esta activo
                If ckRaiz.Checked = True Then
                    .Clear()
                    .Columns.Add("RAÍZ")
                    .Columns(0).Width = 350
                    lvTotales.Columns.Add("TOTALES")
                    lvTotales.Columns(0).Width = 350
                    'For Each item In cbAño.Items
                    For Each item In lbxAños.SelectedItems
                        If item.ToString <> "TODOS" Then
                            .Columns.Add(item)
                            .Columns(numColumnas).TextAlign = HorizontalAlignment.Right
                            .Columns(numColumnas).Width = 150
                            lvTotales.Columns.Add(item)
                            lvTotales.Columns(numColumnas).TextAlign = HorizontalAlignment.Right
                            lvTotales.Columns(numColumnas).Width = 150
                            numColumnas = numColumnas + 1
                        End If
                        vNumColumnas = vNumColumnas + 1
                    Next
                End If
            End With
            comprobarListviewItems()
        Catch ex As Exception
            MsgBox("lvEstadisticasRaizAños  -- " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region


    'LLENAR LISTVIEW------------------------------------------------------------------------------
#Region "LLENAR LISTVIEW"

    'ACTUALIZAR EL LISTVIEW-----------------------------------------------------------------------
    Private Sub ActualizarLV()
        Try
            lvEstadisticas.Items.Clear()
            Dim Suma As Double = 0
            Dim Aviso As Boolean = False
            Dim AvisoG As Boolean = False
            Dim FechaCambioG As Date = Now.Date
            Dim FechaCambio As Date = Now.Date
            Dim SumaCantidad As Double = 0
            Dim lista As List(Of DatosEstadisticaVentas)
            Dim listaSub As List(Of DatosEstadisticaVentasSub)
            Dim vSeleccion As String
            Dim restaTipos As Integer = 0

            'Parametros de búsqueda libre.
           
            If ckInformeComerciales.Checked = True Or ckInformeTipos.Checked = True Then
                If ckInformeComerciales.Checked = True Then

                    If ordenColumna Then

                        'Se ordena por el orden de columna.

                    Else

                        Orden = "usuario"

                        ordenColumna = False

                    End If

                    vSeleccion = "idpersona"

                Else

                    If ckRaiz.Checked Then

                        If ordenColumna Then

                            'Se ordena por el orden de columna.

                        Else

                            Orden = "codarticulo"

                            ordenColumna = False

                        End If

                        vSeleccion = "idarticulo"

                    Else

                        If ordenColumna Then

                            'Se ordena por el orden de columna.

                        Else

                            Orden = "tipoarticulo"

                            ordenColumna = False

                        End If

                        vSeleccion = "idtipoarticulo"

                    End If

                End If

            Else

                If cbPais.Text = "TODOS" Then

                    If ordenColumna Then

                        'Se ordena por el orden de columna.

                    Else

                        Orden = "pais"

                        ordenColumna = False

                    End If

                    vSeleccion = "idpais"

                Else

                    If ordenColumna Then

                        'Se ordena por el orden de columna.

                    Else

                        Orden = "cliente"

                        ordenColumna = False

                    End If

                    vSeleccion = "idcliente"

                End If

            End If

                'Busqueda libre
                Try
                    If ckAños.Checked = True Then
                        Dim numColumnasAños As Integer = 2
                        For Each item In lbxAños.SelectedItems
                            lista = funcCF.BusquedaLibre(sBusqueda, Orden & " " & Direccion, vSeleccion, item)
                            lvEstadisticas.Columns.Add(item)
                            lvEstadisticas.Columns(numColumnasAños).Width = 150
                            lvEstadisticas.Columns(numColumnasAños).TextAlign = HorizontalAlignment.Right
                            Dim i As Integer = 0
                            For Each dts As DatosEstadisticaVentas In lista
                                NuevaLineaLVAños(dts, i, numColumnasAños)
                                i = i + 1
                            Next
                            numColumnasAños = numColumnasAños + 1
                        Next

                        Dim sTotalBaseColumna As String = 0
                        Dim vTotalBaseAños As Double = 0
                        lvTotales.Items.Add(" ")
                        For vColumna As Integer = 1 To vNumColumnas + 1
                            If vColumna < 2 Then
                            Else
                                Dim vTotalCantidadColumna As Double = 0
                                Dim vTotalBaseColumna As Double = 0
                                Dim i As Integer
                                For i = 0 To lvEstadisticas.Items.Count - 1
                                    vTotalBaseColumna = vTotalBaseColumna + FormatNumber(Replace(lvEstadisticas.Items(i).SubItems(vColumna).Text, "€", ""), 2)
                                Next
                                If vTotalBaseColumna = 0 Then
                                    sTotalBaseColumna = "0"
                                Else
                                    sTotalBaseColumna = vTotalBaseColumna
                                End If
                                lvTotales.Items(0).SubItems.Add(FormatNumber(sTotalBaseColumna, 2) & "€")
                            End If
                            vTotalBaseAños = vTotalBaseAños + FormatNumber(sTotalBaseColumna, 2)
                        Next
                        Total.Text = FormatNumber(vTotalBaseAños, 2)
                    Else
                        lista = funcCF.BusquedaLibre(sBusqueda, Orden & " " & Direccion, vSeleccion)
                        For Each dts As DatosEstadisticaVentas In lista
                            restaTipos = restaTipos + 1
                            Call NuevaLineaLV(dts)
                            SumaCantidad = SumaCantidad + dts.gCantidad
                            If dts.gcodMoneda = "EU" Then
                                Suma = Suma + dts.gBase
                            Else
                                Suma = Suma + funcMO.Cambio(dts.gBase, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                                AvisoG = AvisoG Or Aviso
                                If Aviso Then FechaCambioG = FechaCambio
                            End If

                            If ckSubTipos.Checked = True Then
                                'Llenamos el dtsSubTipos desde busquedaSubtipos.
                            Dim dtsSub As New DatosEstadisticaVentasSub
                                listaSub = funcCF.BusquedaLibreSub(sBusqueda & " AND TA.tipoarticulo = '" & dts.gColumna_1 & "'", Orden & " " & Direccion)
                                For Each dtsSub In listaSub
                                    Call NuevaLineaLVSub(dtsSub)
                                Next
                            dtsSub.gColumna_0 = "0"
                            Call NuevaLineaLVSub(dtsSub)
                            End If
                        Next
                        Total.Text = FormatNumber(Suma, 2)
                        Cantidad.Text = FormatNumber(SumaCantidad, 0)
                        lbCambio.Text = "CAMBIO " & FechaCambioG
                        lbCambio.Visible = AvisoG
                    End If
                    If ckSubTipos.Checked Then
                        restaTipos = restaTipos * 2
                    Else
                        restaTipos = 0
                    End If
                    Contador.Text = lvEstadisticas.Items.Count - (restaTipos)
                    comprobarListviewItems()
                Catch ex As Exception
                    MsgBox("Fallo en busqueda libre." & ex.Message, MsgBoxStyle.Critical)
                End Try

                llenarTablaAños()

        Catch ex As Exception
            CorreoError(ex)
        End Try
    End Sub
    'NUEVA LINEA EN EL LISTVIEW-------------------------------------------------------------------
    Private Sub NuevaLineaLV(ByVal dts As DatosEstadisticaVentas)
        With lvEstadisticas.Items.Add(dts.gColumna_0)
            .SubItems.Add(dts.gColumna_1)
            .SubItems.Add(FormatNumber(dts.gCantidad, 0))
            .SubItems.Add(FormatNumber(dts.gBase, 2) & "€")
            .SubItems.Add(FormatNumber(dts.gCoste, 2) & "€")
        End With
        If ckRaiz.Checked = False Then
            With lvEstadisticas
                .Columns(0).Width = 0
                .Columns(1).TextAlign = HorizontalAlignment.Left
            End With
        End If

    End Sub
    'NUEVA LINEA EN EN LISTVIEW-------------------------------------------------------------------
    Private Sub NuevaLineaLVSub(ByVal dtsSub As DatosEstadisticaVentasSub)
        With lvEstadisticas.Items.Add(dtsSub.gColumna_0)
            If dtsSub.gColumna_0 = "0" Then
                .SubItems.Add(" - ")
            Else
                .SubItems.Add(" / " & dtsSub.gColumna_1)
                .SubItems.Add(FormatNumber(dtsSub.gCantidad, 0))
                .SubItems.Add(FormatNumber(dtsSub.gBase, 2) & dtsSub.gSimbolo)
                .SubItems.Add(FormatNumber(dtsSub.gCoste, 2) & dtsSub.gSimbolo)
                .ForeColor = Color.Gray
            End If
        End With
    End Sub
    'NUEVA LINEA AÑOS  LISTVIEW-------------------------------------------------------------------
    Private Sub NuevaLineaLVAños(ByVal dts As DatosEstadisticaVentas, ByVal i As Integer, ByVal nColumna As Integer)

        If nColumna = 2 Then
            With lvEstadisticas.Items.Add(dts.gColumna_0)
                .SubItems.Add(dts.gColumna_1)
                .SubItems.Add(FormatNumber(dts.gBaseAño, 2) & "€")
            End With
            With lvEstadisticas
                .Columns(0).Width = 0
                .Columns(1).TextAlign = HorizontalAlignment.Left
            End With
        Else
            With lvEstadisticas.Items(i)
                .SubItems.Add(FormatNumber(dts.gBaseAño, 2) & "€")
            End With
        End If

    End Sub

#End Region


    'TODO RESPECTO AL APARTADO DE RAICES----------------------------------------------------------
#Region "RAICES"
    'INICIALIZAMOS EL LISTBOX RAICES
    Public Sub configurarLvRaices()
        lbxRaices.Items.Clear()
        llenarlbxRaices()
    End Sub
    'LLENAMOS LAS RAICES
    Public Sub llenarlbxRaices()
        Dim lista As List(Of DatosRaices)
        lista = funcCF.busquedaRaices()
        For Each dts As DatosRaices In lista
            lbxRaices.Items.Add(dts.gColumna_1)
        Next
    End Sub

#End Region


    'BUSQUEDAS------------------------------------------------------------------------------------
#Region "BUSQUEDA"

    'BUSQUEDA GENERAL-----------------------------------------------------------------------------
    Private Sub Busqueda()
        formatLvEstadisticas()
        'Si el combobox Año es igual a todos deja en blanco la variable.
        Dim vAño As String = cbAño.Text
        If vAño = "TODOS" Then
            vAño = ""
        Else
            vAño = cbAño.Text
        End If

        'Si el combobox Cliente es igual a todos deja en blanco la variable.
        Dim vClientes As String = cbCliente.Text
        If vClientes = "TODOS" Then
            vClientes = ""
        Else
            vClientes = cbCliente.Text
        End If
        If ckAños.Checked Then
            sqlWhereBusqueda()
        Else
            sqlwhere = ""
        End If

        'Vacia la variable busqueda.
        sBusqueda = ""

        'Si está vacio el campo busca todos los clientes.
        If vClientes <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " CL.NombreComercial like '%" & Replace(vClientes, "'", "''") & "%' "
        End If

        If cbComercial.SelectedIndex <> -1 And cbComercial.Text <> "TODOS" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idPersona = " & cbComercial.SelectedItem.itemdata
        End If
        If cbEstado.SelectedIndex <> -1 And cbEstado.Text <> "TODOS" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " FA.idEstado = " & cbEstado.SelectedItem.gidestado
        End If
        If cbPais.SelectedIndex <> -1 Then
            Dim st As String = ""
            If cbPais.SelectedItem.ToString = "TODOS" Or cbPais.SelectedItem.ToString = "" Then
                st = "FA.idUbicacion is not null"
            Else
                st = " UB.idPais = " & cbPais.SelectedItem.gidPais
            End If
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & st
        End If
        If cbProvincia.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " PR.Provincia like '" & cbProvincia.Text & "%' "
        End If

        If cbAutonomia.SelectedIndex <> -1 Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AU.idAutonomia = " & cbAutonomia.SelectedItem.gidAutonomia
        End If

        If ckAños.Checked = False Then
            If CambioFechas Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & "  CONVERT(datetime,CONVERT(Char(10), FA.Fecha,103))  >= '" & dtpDesde.Value.Date & "' AND  CONVERT(datetime,CONVERT(Char(10), FA.Fecha,103))  <= '" & dtpHasta.Value.Date & "' "
                'CambioFechas = False
            Else
                If IsNumeric(cbAño.Text) Then
                    sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                    sBusqueda = sBusqueda & "  Year(FA.Fecha)= " & vAño
                End If
                If cbMes.SelectedIndex <> -1 Then
                    sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                    sBusqueda = sBusqueda & "  Month(FA.Fecha)= " & cbMes.SelectedIndex + 1
                End If

                If cbTrimestre.SelectedIndex <> -1 Then
                    sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                    sBusqueda = sBusqueda & "  Month(FA.Fecha)in "
                    Select Case cbTrimestre.SelectedIndex
                        Case 0 '1T
                            sBusqueda = sBusqueda & " (1,2,3) "
                        Case 1 '2T
                            sBusqueda = sBusqueda & " (4,5,6) "
                        Case 2 '3T
                            sBusqueda = sBusqueda & " (7,8,9) "
                        Case 3 '4T
                            sBusqueda = sBusqueda & " (10,11,12) "
                    End Select
                End If
            End If
        Else
            sbusquedaAños = ""
            Dim primeraVez As Boolean = True

            If sBusqueda = "" Then
                sbusquedaAños = "("
            Else
                sbusquedaAños = sBusqueda & " and ("
            End If
            For Each item As Double In lbxAños.SelectedItems
                If primeraVez = True Then
                    sbusquedaAños = sbusquedaAños & " year(FA.fecha)= " & item & " "
                    primeraVez = False
                Else
                    sbusquedaAños = sbusquedaAños & " or year(FA.fecha)= " & item & " "
                End If
            Next
            sbusquedaAños = sbusquedaAños & ") "
            sBusqueda = sbusquedaAños
        End If

        If cbCodArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.codArticulo like '" & cbCodArticulo.Text & "%' "
        End If

        If cbArticulo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " AR.Articulo like '" & cbArticulo.Text & "%' "
        End If

        If cbTipo.SelectedIndex <> -1 Then
            If cbTipo.Text = "SIN TIPO" Then
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " (AR.idTipoArticulo = " & cbTipo.SelectedItem.itemData & " or AR.idTipoArticulo is null)"
            Else
                sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
                sBusqueda = sBusqueda & " AR.idTipoArticulo = " & cbTipo.SelectedItem.itemData
            End If
        End If

        If cbSubTipo.Text <> "" Then
            sBusqueda = sBusqueda & IIf(sBusqueda = "", "", " AND ")
            sBusqueda = sBusqueda & " SubTipoArticulo = '" & cbSubTipo.Text & "' "
        End If

        If sBusqueda = "" Then
            If sqlwhere = "" Then
                sBusqueda = "CL.NombreComercial like '%%' "
            Else
                sBusqueda = Replace(sqlwhere, "and", "")
            End If
        Else
            sBusqueda = sBusqueda & sqlwhere
        End If

        Call ActualizarLV()

    End Sub

    'BUSQUEDA DE RAICES---------------------------------------------------------------------------
    Public Sub busquedaRaiz()
        lvEstadisticasRaiz()
        sqlWhereBusqueda()
        Dim sRaices As String = ""
        Dim sAños As String = ""
        If ckRaiz.Checked = True Then
            Total.Text = "0"
            Cantidad.Text = "0"
            Dim totalCantidad As Double = 0
            Dim totalbase As Double = 0
            If lbxRaices.SelectedItems.Count > 0 And ckRaiz.Checked = True Then
                For Each item In lbxRaices.SelectedItems
                    'llena el campo de busqueda de raices para el reporte.
                    If sRaices = "" Then
                        sRaices = " and ( AR.codArticulo like '" & item & "%' "
                        cRaices = " ,case when codArticulo like '%" & item & "%' then '" & item & "' "
                    Else
                        sRaices = sRaices & "or AR.codArticulo like '" & item & "%' "
                        cRaices = cRaices & " when codArticulo like '%" & item & "%' then '" & item & "' "
                    End If

                    With lvEstadisticas.Items.Add(item)
                        For Each itemAño In lbxAños.SelectedItems
                            'llena el campo de busqueda de años para el reporte.
                            If sAños = "" Then
                                sAños = " and ( YEAR(fecha) = " & itemAño
                            Else
                                sAños = sAños & " or  YEAR(fecha) = " & itemAño
                            End If

                            If itemAño.ToString <> "TODOS" Then
                                totalCantidad = totalCantidad + funcCF.CargarDatosRaizCantidad(itemAño, item, sqlwhere)
                                totalbase = FormatNumber((totalbase + funcCF.CargarDatosRaizBase(itemAño, item, sqlwhere) + 2))
                                .SubItems.Add(FormatNumber(funcCF.CargarDatosRaizCantidad(itemAño, item, sqlwhere), 0) & " / " & FormatNumber(funcCF.CargarDatosRaizBase(itemAño, item, sqlwhere), 2) & "€")
                            End If
                        Next
                    End With
                Next
                cRaices = cRaices & " else '' end as raiz "
                If lbxAños.SelectedItems.Count > 0 Then
                    sAños = sAños & ")"
                Else
                    sAños = ""
                End If

                If lbxRaices.SelectedItems.Count > 0 Then
                    sRaices = sRaices & ")"
                Else
                    sRaices = ""
                End If
                sbusquedaRaiz = sbusquedaRaiz & sqlwhere & sRaices

                Dim sTotalBaseColumna As String = ""
                Dim vTotalBaseAños As Double = 0
                Dim sTotalCantidadColumna As String
                lvTotales.Items.Add(" ")
                For vColumna As Integer = 1 To vNumColumnas
                    If vColumna = 0 Then
                    Else
                        totalbase = 0
                        Dim vTotalCantidadColumna As Double = 0
                        Dim vTotalBaseColumna As Double = 0
                        Dim i As Integer
                        For i = 0 To lvEstadisticas.Items.Count - 1
                            Dim seccionList As String = Replace(lvEstadisticas.Items(i).SubItems(vColumna).Text, "€", "")
                            Dim seccionItem(2) As String
                            seccionItem = seccionList.Split("/"c)
                            vTotalCantidadColumna = vTotalCantidadColumna + CDbl(Trim(seccionItem(0)))
                            vTotalBaseColumna = vTotalBaseColumna + CDbl(Trim(seccionItem(1)))
                        Next
                        If vTotalCantidadColumna = 0 Then
                            sTotalCantidadColumna = "0"
                        Else
                            sTotalCantidadColumna = vTotalCantidadColumna
                        End If

                        If vTotalBaseColumna = 0 Then
                            sTotalBaseColumna = "0"
                        Else
                            sTotalBaseColumna = vTotalBaseColumna
                        End If
                        lvTotales.Items(0).SubItems.Add((FormatNumber(sTotalCantidadColumna, 2)) & " / " & (FormatNumber(sTotalBaseColumna, 2)) & "€")
                    End If
                    vTotalBaseAños = vTotalBaseAños + FormatNumber(sTotalBaseColumna, 2)
                Next
                Total.Text = FormatNumber(vTotalBaseAños, 2)
                Cantidad.Text = FormatNumber(totalCantidad, 0)
                comprobarListviewItems()
            End If
        End If
    End Sub

    'SQLWHERE DETERMINA LA BUSQUEDA 
    Public Sub sqlWhereBusqueda()
        sbusquedaRaiz = ""
        sqlwhere = ""
        For Each item In lbxMeses.SelectedItems
            If sqlwhere = "" Then
                sqlwhere = sqlwhere & " and (datename(m, fecha)= '" & item & "'"
                sbusquedaRaiz = "and (datename(m, fecha)= '" & item & "'"
            Else
                sqlwhere = sqlwhere & " or datename(m, fecha)= '" & item & "'"
                sbusquedaRaiz = sbusquedaRaiz & " or datename(m, fecha)= '" & item & "'"
            End If
        Next
        'Si el combobox Cliente es igual a todos deja en blanco la variable.
        Dim vClientes As String = cbCliente.Text
        If vClientes = "TODOS" Then
            vClientes = ""
        Else
            vClientes = cbCliente.Text
        End If

        If sqlwhere <> "" Then
            sqlwhere = sqlwhere & " ) and CL.NombreComercial like '%" & Replace(vClientes, "'", "''") & "%' "
            sbusquedaRaiz = sbusquedaRaiz & " )"
        Else
            sqlwhere = " and datename(m, fecha)= '' and CL.NombreComercial like '%" & Replace(vClientes, "'", "''") & "%' "
        End If
    End Sub
#End Region

    'ACCIONES AL CAMBIAR EL ESTADO DE LOS CHECKBOX------------------------------------------------
#Region "CHECKBOX"
    'CUANDO ACTIVAMOS EL CHECKBOX DE RAIZ--------------------------------------------------------------------
    Private Sub ckRaiz_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckRaiz.CheckedChanged

        If ckRaiz.Checked Then

            Semaforo = False
            vTipoInforme = 2
            'Si el check está activado
            'Muestra el listview raices y los controles relaccionados.
            ckInformeComerciales.Checked = False
            ckAños.Checked = False
            ckInformeTipos.Checked = False
            gbxRaices.Visible = True
            LblMas.Visible = True
            lblMenos.Visible = True
            cbAño.Text = "TODOS"
            cbPais.Text = ""
            cbAño.Enabled = False
            GroupBox3.Enabled = False
            gbFacturacion.Enabled = False
            gbClientes.Enabled = True
            lvEstadisticas.Height = lvEstadisticas.Height - 47
            lvTotales.Visible = True
            gbxAños.Enabled = True
            gbxMeses.Enabled = True
            lbEncontrados.Visible = False
            Contador.Visible = False
            Contador.Text = ""
            ckAños.Enabled = False
            cbPais.Enabled = False
            Semaforo = True
            busquedaRaiz()

        Else
            vTipoInforme = 0
            'Si el check está activado
            'Oculta el listview raices y los controles relaccionados.
            gbxRaices.Visible = False
            LblMas.Visible = False
            lblMenos.Visible = False
            cbAño.Enabled = True
            lbxRaices.ClearSelected()
            lbxMeses.ClearSelected()
            lbxAños.ClearSelected()
            Semaforo = False
            ckTodosAños.Checked = False
            ckTodosMeses.Checked = False
            Semaforo = True
            lbEncontrados.Visible = True
            Contador.Visible = True
            GroupBox3.Enabled = True
            gbFacturacion.Enabled = True
            gbClientes.Enabled = True
            lvTotales.Visible = False
            lvEstadisticas.Height = lvEstadisticas.Height + 47
            gbxAños.Enabled = False
            gbxMeses.Enabled = False
            bListado.Enabled = False
            ckAños.Enabled = True
            cbPais.Enabled = True
            Limpiar()
            Busqueda()
        End If
    End Sub
    'CUANDO ACTIVAMOS EL CHECKBOX AÑOS-----------------------------------------------------------------------
    Private Sub ckAños_CheckedChanged_(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckAños.CheckedChanged
        If ckAños.Checked Then 'Si el check box esta activo
            cbPais.SelectedIndex = -1
            vTipoInforme = 1
            gbxAños.Enabled = True
            gbxMeses.Enabled = True
            cbAño.SelectedIndex = -1
            cbAño.Enabled = False
            cbMes.Enabled = False
            dtpDesde.Enabled = False
            dtpHasta.Enabled = False
            cbTrimestre.Enabled = False
            Contador.Text = ""
            lvEstadisticas.Height = lvEstadisticas.Height - 47
            lvTotales.Visible = True
            Cantidad.Visible = False
            Label15.Visible = False
        Else
            vTipoInforme = 0
            gbxAños.Enabled = False
            gbxMeses.Enabled = False
            cbAño.Enabled = True
            cbMes.Enabled = True
            dtpDesde.Enabled = True
            dtpHasta.Enabled = True
            cbTrimestre.Enabled = True
            cbAño.Text = Year(Now)
            Contador.Text = ""
            ckTodosAños.Checked = False
            ckTodosMeses.Checked = False
            limpiarLbxAñosYMeses()
            lvTotales.Visible = False
            lvEstadisticas.Height = lvEstadisticas.Height + 47
            Cantidad.Visible = True
            Label15.Visible = True
        End If
        Busqueda()
    End Sub
    'CUANDO ACTIVAMOS EL CHECKBOX TODO SE ACTIVA O DESACTIVAN TODAS LAS RAICES.------------------------------
    Private Sub ckTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodo.CheckedChanged
        checkTodos = True
        If ckTodo.Checked = True Then
            For i = 0 To lbxRaices.Items.Count - 1
                lbxRaices.SetSelected(i, True)
            Next
        Else
            For i = 0 To lbxRaices.Items.Count - 1
                lbxRaices.SetSelected(i, False)
            Next
        End If
        checkTodos = False
        busquedaRaiz()
    End Sub
    'CUANDO ACTIVAMOS EL CHECKBOX TODO SE ACTIVA O DESACTIVAN TODAS LAS AÑOS.--------------------------------
    Private Sub ckTodosAños_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodosAños.CheckedChanged
        If Semaforo = True Then
            checkTodos = True
            If ckTodosAños.Checked = True Then
                For i = 0 To lbxAños.Items.Count - 1
                    lbxAños.SetSelected(i, True)
                Next
            Else
                For i = 0 To lbxAños.Items.Count - 1
                    lbxAños.SetSelected(i, False)
                Next
            End If
            checkTodos = False
            If ckAños.Checked Then
                Busqueda()
            Else
                busquedaRaiz()
            End If

            If lbxAños.SelectedItems.Count = lbxAños.Items.Count Then
                ckTodosAños.Checked = True
                ckTodosAños.Text = "DESMARCAR TODAS"
            Else
                ckTodosAños.Text = "MARCAR TODAS"
            End If
        End If
    End Sub
    'CUANDO ACTIVAMOS EL CHECKBOX TODO SE ACTIVA O DESACTIVAN TODAS LAS MESES.--------------------------------
    Private Sub ckTodosMeses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckTodosMeses.CheckedChanged
        If Semaforo = True Then
            checkTodos = True
            If ckTodosMeses.Checked = True Then
                For i = 0 To lbxMeses.Items.Count - 1
                    lbxMeses.SetSelected(i, True)
                Next
            Else
                For i = 0 To lbxMeses.Items.Count - 1
                    lbxMeses.SetSelected(i, False)
                Next
            End If
            checkTodos = False
            If ckAños.Checked Then
                Busqueda()
            Else
                busquedaRaiz()
            End If

            If lbxMeses.SelectedItems.Count = lbxMeses.Items.Count Then
                ckTodosMeses.Checked = True
                ckTodosMeses.Text = "DESMARCAR TODAS"
            Else
                ckTodosMeses.Text = "MARCAR TODAS"
            End If
        End If
    End Sub
    'CUANDO ACTIVAMOS EL CHECKBOX COMERCIALES.---------------------------------------------------------------
    Private Sub ckInformeComerciales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckInformeComerciales.CheckedChanged
        If checkActivado = False Then
            If ckInformeComerciales.Checked = True Then
                vTipoInforme = 3
                checkActivado = True
                ckInformeTipos.Checked = False
                ckSubTipos.Checked = False
                ckInformeTipos.Enabled = False
                ckSubTipos.Enabled = False
                checkActivado = False
                cbComercial.Text = "TODOS"
                cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
            Else
                vTipoInforme = 0
                ckInformeTipos.Enabled = True
                cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
            End If
        End If
    End Sub
    'CUANDO ACTIVAMOS EL CHECKBOX SUBTIPOS-------------------------------------------------------------------
    Private Sub ckSubTipos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
    End Sub
    'SI CAMBIA EL CHECKBOX TIPOS
    Private Sub ckInformeTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckInformeTipos.CheckedChanged
        If checkActivado = False Then
            If ckInformeTipos.Checked = True Then
                ckSubTipos.Enabled = True
                checkActivado = True
                ckInformeComerciales.Checked = False
                checkActivado = False
                cbTipo.Text = ""
                cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
                If ckRaiz.Checked = False Then
                    formatColumslvEstadisticas()
                End If
            Else
                ckInformeComerciales.Enabled = True
                cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
                If ckRaiz.Checked = False Then
                    formatColumslvEstadisticas()
                End If
                ckSubTipos.Enabled = False
                ckSubTipos.Checked = False
            End If
        End If
    End Sub
    'SI CAMBIA EL CHECKBOX SUBTIPOS
    Private Sub ckSubTipos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckSubTipos.CheckedChanged
        If ckSubTipos.Checked = True Then
            ckInformeTipos.Enabled = False
        Else
            ckInformeTipos.Enabled = True
        End If

        Busqueda()
    End Sub
#End Region


    'CUANDO CAMBIAN LAS FECHAS--------------------------------------------------------------------
#Region "CAMBIO DE FECHAS"

    Private Sub dtpHasta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpHasta.KeyUp, dtpDesde.KeyUp
        If Semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub

    Private Sub dtpDesde_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDesde.CloseUp, dtpHasta.CloseUp
        If Semaforo Then
            If dtpHasta.Value < dtpDesde.Value Then dtpHasta.Value = dtpDesde.Value
            CambioFechas = True
            Call Busqueda()
        End If
    End Sub

#End Region


    'EVENTOS AL HACER CLICK EN UN BOTÓN O UN CONTROL CON FUNCIONES DE BOTÓN-----------------------
#Region "BOTONES GENERALES"
    'Al pulsar el boton salir cierra el formulario.
    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Me.Close()
    End Sub

    'Al pulsar el boton de limpiar, primero limpia y luego realiza la busqueda con los valores inicales.
    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call Limpiar()
        cbCliente.Text = "TODOS"
        Call Busqueda()
    End Sub

    'Muestra la ficha del cliente seleccionado en el comobobox.
    Private Sub bVerCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerCliente.Click
        If cbCliente.SelectedIndex <> -1 Then
            Dim iidCliente As Integer = cbCliente.SelectedItem.itemdata
            Dim GG As New GestionClientes
            GG.SoloLectura = vSoloLectura
            GG.pidCliente = iidCliente
            GG.ShowDialog()
        End If
    End Sub

    'Muestra la ficha del articulo seleccionado en el combobox.
    Private Sub bVerArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerArticulo.Click
        If cbArticulo.SelectedIndex <> -1 Then
            Dim iidArticulo As Integer = cbArticulo.SelectedItem.itemdata
            Dim GG As New GestionArticulo
            GG.SoloLectura = vSoloLectura
            GG.pidArticulo = iidArticulo
            GG.pModo = "DOC"
            GG.ShowDialog()
        End If
    End Sub

    'Al hacer clic sobre el label llama al formulario para crear una nueva raíz.
    Private Sub LblMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblMas.Click
        Dim formGG As New CrearRaicesArticulos
        formGG.ShowDialog()
        configurarLvRaices()
    End Sub

    'Al hacer clic sobre el label elimina la raíces seleccionadas.
    Private Sub lblMenosClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMenos.Click

        If lbxRaices.SelectedItems.Count > 0 Then
            If MsgBox("¿Borrar raices seleccionadas?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For Each items In lbxRaices.SelectedItems
                    funcCF.borrarRaiz(items)
                Next
                configurarLvRaices()
                MsgBox("Registros borrados correctamente.", MsgBoxStyle.Information)
            End If
        End If
    End Sub



    'SI SELECCIONAMOS UN ITEM DE LIST BOX---------------------------------------------------------
    Private Sub lbxRaices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxRaices.SelectedIndexChanged
        If checkTodos = False Then
            If lbxRaices.SelectedItems.Count = lbxRaices.Items.Count Then
                ckTodo.Checked = True
                ckTodo.Text = "DESMARCAR TODAS"
            Else
                If lbxRaices.SelectedItems.Count = 0 Then
                    ckTodo.Text = "MARCAR TODAS"
                    ckTodo.Checked = False
                End If
            End If
            busquedaRaiz()
        End If

    End Sub

    'SI CAMBIA EL INDICE EN EL LISTBOX AÑOS-------------------------------------------------------
    Private Sub lbxAños_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxAños.SelectedIndexChanged
        If checkTodos = False Then
            If lbxAños.SelectedItems.Count = lbxAños.Items.Count Then
                ckTodosAños.Checked = True
                ckTodosAños.Text = "DESMARCAR TODAS"
            Else
                If lbxAños.SelectedItems.Count = 0 Then
                    ckTodosAños.Text = "MARCAR TODAS"
                    ckTodosAños.Checked = False
                End If
            End If
            If ckAños.Checked = True Then
                Busqueda()
            Else
                busquedaRaiz()
            End If
        End If
    End Sub

    'SI CAMBIA EL INDICE EN EL LISTBOX MESES------------------------------------------------------
    Private Sub lbxMeses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxMeses.SelectedIndexChanged
        If checkTodos = False Then
            If lbxMeses.SelectedItems.Count = lbxMeses.Items.Count Then
                ckTodosMeses.Checked = True
                ckTodosMeses.Text = "DESMARCAR TODAS"
            Else
                If lbxMeses.SelectedItems.Count = 0 Then
                    ckTodosMeses.Text = "MARCAR TODAS"
                    ckTodosMeses.Checked = False
                End If
            End If
            If ckAños.Checked = True Then
                Busqueda()
            Else
                busquedaRaiz()
            End If
        End If

    End Sub
#End Region


    'EVENTOS AL  CAMBIAR EL INDICE O EL TEXTO DE UN COMBOBOX--------------------------------------
#Region "SELECCION COMBOBOX"
    'Al seleccionar un articulo en el combobox
    Private Sub cbArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbArticulo.SelectedIndexChanged
        If cbArticulo.SelectedIndex <> -1 Then
            Semaforo = False
            Dim iidArticulo As Integer = cbArticulo.SelectedItem.itemdata
            cbCodArticulo.Text = funcAR.codArticulo(iidArticulo)
            Semaforo = True
            Call Busqueda()
        End If
    End Sub

    'Al seleccionar un codigo de articulo en el combobox
    Private Sub cbCodArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodArticulo.SelectedIndexChanged
        If cbCodArticulo.SelectedIndex <> -1 Then
            Semaforo = False
            Dim iidArticulo As Integer = cbCodArticulo.SelectedItem.itemdata
            cbArticulo.Text = funcAR.Articulo(iidArticulo)
            Semaforo = True
            Call Busqueda()
        End If
    End Sub

    'Al seleccionar un mes en el combox elimina el indice de TRIMESTRE
    Private Sub cambio_cbMes(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMes.SelectedIndexChanged
        If cbMes.SelectedIndex <> -1 Then
            cbTrimestre.SelectedIndex = -1
        End If
        cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
    End Sub

    'Al seleccionar un trimestre en el combox elimina el indice de MES
    Private Sub cambio_cbTrimestre(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTrimestre.SelectedIndexChanged
        If cbTrimestre.SelectedIndex <> -1 Then
            cbMes.SelectedIndex = -1
        End If
        cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
    End Sub

    'Si el combobox de tipo articulo tiene indice se desbloquea el combobox de subtipoarticulo.
    Private Sub cbTipoArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.TextChanged, cbSubTipo.TextChanged
        Dim vTipo As String = Trim(cbTipo.Text)
        Dim vSubTipo As String = Trim(cbSubTipo.Text)
        If vTipo = "" Then
            cbTipo.SelectedIndex = -1
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Enabled = False
            cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
        End If
        If vSubTipo = "" Then
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Text = ""
        End If
    End Sub

    Private Sub cambioIndices_o_Texto_subTipo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedIndexChanged
        bloqueoSubTipos = True
        cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
    End Sub

    Private Sub cambiaIndiceAutonomia(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutonomia.SelectedIndexChanged, cbPais.SelectedIndexChanged
        '    cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
        cargaComboxProvincias()
        If Semaforo = True Then
            If cbPais.Text = "ESPAÑA" And cbAutonomia.SelectedIndex = -1 Then
                Call introducirAutonomias() 'Cargamos las autonomias en el combobox que solo se activa si es España
            End If
        End If
    End Sub

    'CAMBIAN DE INDICE LOS COMBOS
    Private Sub cambioIndices(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        cbPais.SelectedIndexChanged, cbAño.SelectedIndexChanged, cbComercial.SelectedIndexChanged, _
        cbEstado.SelectedIndexChanged, cbArticulo.SelectedIndexChanged, cbCodArticulo.SelectedIndexChanged, cbSubTipo.SelectedIndexChanged, _
        cbCliente.SelectedIndexChanged, cbAutonomia.SelectedIndexChanged, cbProvincia.SelectedIndexChanged
        If Semaforo = True Then
            CambioFechas = False
            cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
        Else
            If ckAños.Checked = True Then
                lvEstadisticas.Clear()
            End If
        End If
    End Sub


    'Al cambiar texto en los  combos País, Autonomia, Provincia y  Cliente, ejecuta el cambio de controles.
    Private Sub cambioTexto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        cbPais.TextChanged, cbAutonomia.TextChanged, cbProvincia.TextChanged, cbCliente.TextChanged
        If Semaforo = True Then
            If Me.ActiveControl.Text = "" Then
                cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
            End If
        End If
        If cbAutonomia.Text = "" Then
            cbProvincia.Items.Clear()
            cbProvincia.Text = " "
        End If
    End Sub

    'Al introducir texto en los controles País, Comercial, Estado, Articulo, Subtipo, tipo , Cliente, provincia y autonomia, cambia el texto a maysculas.
    Private Sub cb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    cbPais.KeyPress, cbComercial.KeyPress, _
    cbEstado.KeyPress, cbCodArticulo.KeyPress, _
    cbSubTipo.KeyPress, cbCliente.KeyPress, _
    cbProvincia.KeyPress, cbAutonomia.KeyPress, cbTipo.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub
#End Region


    'PROCEDIMIENTOS Y FUNCIONES 
#Region "PROCEDIMIENTOS Y FUNCIONES"
    'PROCEDIMIENTO ACTIVACIÓN COMBOBOX------------------------------------------------------------
    Public Sub cargaComboxProvincias()
        If cbPais.Text = "ESPAÑA" Then
            cbAutonomia.Enabled = True
            If cbAutonomia.SelectedIndex <> -1 Then
                cbProvincia.SelectedIndex = -1
                introducirProvincias()
                cbProvincia.Enabled = True
            Else
                cbProvincia.SelectedIndex = -1
                cbProvincia.Enabled = False
            End If
        Else
            cbAutonomia.SelectedIndex = -1
            cbAutonomia.Enabled = False
            cbProvincia.SelectedIndex = -1
            cbProvincia.Enabled = False
        End If
    End Sub

    'PROCEDIMIENTO AL CAMBIAR DE ESTADO LOS CONTROLES DE BUSQUEDA---------------------------------
    Public Sub cambiosControles()
        If Semaforo Then
            If ckRaiz.Checked = False Then
                Call Busqueda()
            Else
                Call busquedaRaiz()
            End If
        End If
        'SI EL INDICE DEL COMBO TIPO ES -1 Y EL TEXTO ES DIFERENTE A TODOS ACTIVA EL COMBO SUBTIPO
        If cbTipo.SelectedIndex <> -1 And cbTipo.Text <> "TODOS" Then
            cbSubTipo.Enabled = True
            If bloqueoSubTipos = True Then
                iidTipoArticulo = cbTipo.SelectedItem.itemdata
                Call IntroducirSubTiposArticulo()
                bloqueoSubTipos = False
            End If
        Else
            cbSubTipo.SelectedIndex = -1
            cbSubTipo.Enabled = False
        End If
        'SI EL COMBO AÑOS ES IGUAL A TODOS DESACTIVA LOS COMBOS MES Y TRIMESTRE.
        If cbAño.Text = "TODOS" Then
            cbMes.SelectedIndex = -1
            cbTrimestre.SelectedIndex = -1
            cbTrimestre.Enabled = False
            cbMes.Enabled = False
        Else
            cbTrimestre.Enabled = True
            cbMes.Enabled = True
        End If
        comprobarListviewItems()

    End Sub

    'COMPRUEBA SI HAY UN ITEM EN EL LISTVIEW Y ACTIVA EL BOTON INFORME.
    Public Sub comprobarListviewItems()
        If ckRaiz.Checked = True Then
            If lvEstadisticas.Items.Count > 0 Then
                Try
                    Dim i As String = lvEstadisticas.Items(0).SubItems(1).Text
                    bListado.Enabled = True
                Catch ex As Exception
                    bListado.Enabled = False
                End Try
            Else
                bListado.Enabled = False
            End If
        Else
            If lvEstadisticas.Items.Count <> 0 Then
                bListado.Enabled = True
            Else
                bListado.Enabled = False
            End If
        End If
        
    End Sub

    'PROCEDIMIENTO DE VACIADO DE LOS LISTBOX AÑOS Y MESES-----------------------------------------
    Public Sub limpiarLbxAñosYMeses()
        For i = 0 To lbxAños.Items.Count - 1
            lbxAños.SetSelected(i, False)
        Next
        gbxAños.Enabled = False
        For i = 0 To lbxMeses.Items.Count - 1
            lbxMeses.SetSelected(i, False)
        Next
    End Sub
#End Region


    'INFORMES-------------------------------------------------------------------------------------
#Region "INFORMES"

    'MUESTRA EL REPORTE SEGÚN LA BUSQUEDA
    Private Sub bListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bListado.Click
        vTipoInforme = 999
        If ckInformeComerciales.Checked = False Then
            If ckInformeTipos.Checked = True Then
                vTipoInforme = 5
            Else
                If cbPais.Text = "TODOS" Then
                    If ckAños.Checked = True Then
                        vTipoInforme = 6
                    Else
                        vTipoInforme = 4
                    End If

                Else
                    If ckAños.Checked = True Then
                        vTipoInforme = 1
                    Else
                        If ckRaiz.Checked = True Then
                            vTipoInforme = 2
                        Else
                            vTipoInforme = 0
                        End If
                    End If

                End If
            End If
        Else
            vTipoInforme = 3
        End If


        Select Case vTipoInforme
            Case 0
                Dim GG As New InformeEstadisticaVentas
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            Case 1
                Dim GG As New InformeEstadisticaVentas
                GG.verInformeAños(PonerTitulo(True), " where " & sbusquedaAños, "CLIENTE")
                GG.ShowDialog()
            Case 2
                Dim GG As New InformeEstadisticaVentas
                GG.verInformeAñosRaiz(PonerTituloRaiz, sbusquedaRaiz, "RAÍZ", cRaices)
                GG.ShowDialog()
            Case 3
                Dim GG As New InformeEstadisticaVentasComerciales
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            Case 4
                Dim GG As New InformeEstadisticaVentasPaises
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            Case 5
                Dim GG As New InformeEstadisticaVentasTipo
                GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
                GG.ShowDialog()
            Case 6
                Dim GG As New InformeEstadisticaVentas
                GG.verInformeAñosPais(PonerTitulo(True), " where " & sbusquedaAños, "PAÍS")
                GG.ShowDialog()

        End Select
    End Sub
    'Formatea la cadena que se muestra en el titulo del informe.
    Private Function PonerTitulo(ByVal ConCliente As Boolean) As String
        Dim Titulo As String = ""
        Dim ponerCRLF As Boolean = False
        If ConCliente Then
            If cbCliente.Text <> "" Then
                Titulo = "CLIENTE: " & cbCliente.Text & "  "
                ponerCRLF = True
            End If
            If ponerCRLF Then Titulo = Titulo & "  "
        End If
        ponerCRLF = False

        If cbPais.SelectedIndex <> -1 Then
            Titulo = "PAIS: " & cbPais.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbAutonomia.SelectedIndex <> -1 Then
            Titulo = Titulo & "C.AUTONOMA: " & cbAutonomia.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbProvincia.SelectedIndex <> -1 Then
            Titulo = Titulo & "PROVINCIA: " & cbProvincia.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbTipo.SelectedIndex <> -1 Then
            Titulo = Titulo & "TIPO: " & cbTipo.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbSubTipo.SelectedIndex <> -1 Then
            Titulo = Titulo & "SUBTIPO: " & cbSubTipo.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbCodArticulo.Text <> "" Or cbArticulo.Text <> "" Then
            Titulo = Titulo & "ARTÍCULO: " & cbCodArticulo.Text & " - " & cbArticulo.Text
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbEstado.SelectedIndex <> -1 Then
            Titulo = Titulo & "ESTADO: " & cbEstado.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If cbComercial.SelectedIndex <> -1 Then
            Titulo = Titulo & "COMERCIAL: " & cbComercial.Text & "  "
            ponerCRLF = True
        End If
        If ponerCRLF Then Titulo = Titulo & "  "
        ponerCRLF = False

        If CambioFechas Then
            Titulo = Titulo & "(DESDE: " & dtpDesde.Value.Date & ", HASTA: " & dtpHasta.Value.Date & ")"
        Else
            If cbAño.SelectedIndex <> -1 Then
                Titulo = Titulo & "AÑO: " & cbAño.Text & "  "
                ponerCRLF = True
            End If
            If ponerCRLF Then Titulo = Titulo & "  "
            ponerCRLF = False

            If cbTrimestre.SelectedIndex <> -1 Then
                Titulo = Titulo & cbTrimestre.Text & "  "
                ponerCRLF = True
            End If
            If ponerCRLF Then Titulo = Titulo & "  "
            ponerCRLF = False

            If cbMes.SelectedIndex <> -1 Then
                Titulo = Titulo & "MES: " & cbMes.Text & "  "
                ponerCRLF = True
            End If
        End If
        Return UCase(Titulo)
    End Function

    Private Function PonerTituloRaiz() As String
        Try
            Dim sMeses As String = ""
            Dim sAños As String = ""
            Dim sRaiz As String = ""
            Dim sCliente As String = ""
            'Añadimos los meses seleccionados al tiulo

            If lbxMeses.SelectedItems.Count <> 0 Then

                For Each item In lbxMeses.SelectedItems
                    sMeses = sMeses & " - " & item
                Next
                sMeses = sMeses.Remove(0, 3)
                sMeses = "MESES ( " & sMeses & " )"
            End If
            'Añadimos los años seleccionados al tiulo
            If lbxAños.SelectedItems.Count <> 0 Then
                For Each item In lbxAños.SelectedItems
                    sAños = sAños & " - " & item
                Next
                sAños = sAños.Remove(0, 3)
                sAños = "AÑOS ( " & sAños & " )"
            End If
            'Añadimos las raices seleccionados al tiulo
            If lbxRaices.SelectedItems.Count <> 0 Then
                For Each item In lbxRaices.SelectedItems
                    sRaiz = sRaiz & " - " & item
                Next
                sRaiz = sRaiz.Remove(0, 3)
                sRaiz = "RAÍCES ( " & sRaiz & " )"
            End If
            'Clientes

            If cbCliente.Text = "TODOS" Or cbCliente.Text = "" Then
                sCliente = "CLIENTES: TODOS"
            Else
                sCliente = "CLIENTE: " & cbCliente.Text
            End If
            Return sRaiz & vbCrLf & vbCrLf & sAños & vbCrLf & vbCrLf & sMeses & vbCrLf & vbCrLf & sCliente
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

    'LLenar tabla Años
    Public Sub llenarTablaAños()
        Dim dtAños As New DataTable
        dtAños.Columns.Clear()
        dtAños.Clear()
        Dim workRow As DataRow
        Try
            If lvEstadisticas.Items.Count > -1 Then
                For Each columnas In lvEstadisticas.Columns
                    dtAños.Columns.Add(columnas.text)
                Next
                For u = 0 To lvEstadisticas.Columns.Count - 1
                    For Each item As ListViewItem In lvEstadisticas.Items
                        workRow = dtAños.NewRow()
                        workRow(u) = item.Text
                        dtAños.Rows.Add(workRow)
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR LA TABLA" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Orden_columnas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvEstadisticas.ColumnClick

        If e.Column = Columna Then

            If Direccion = "ASC" Then

                Direccion = "DESC"

            Else

                Direccion = "ASC"

            End If

        End If

        If ckAños.Checked Or ckRaiz.Checked Then

            'Si estan chequeados alguna de estas opciones no se realiza el orden.

        Else


            Select Case e.Column

                Case 0

                    If ckInformeComerciales.Checked Then

                        Orden = "idpersona"

                    Else

                        If ckInformeTipos.Checked Then

                            Orden = "idtipoarticulo"

                        Else

                            If cbPais.Text = "TODOS" Then

                                Orden = "idpais"

                            Else

                                Orden = "idcliente"

                            End If


                        End If


                    End If

                Case 1

                    If ckInformeComerciales.Checked Then

                        Orden = "usuario"

                    Else

                        If ckInformeTipos.Checked Then

                            Orden = "tipoarticulo"

                        Else

                            If cbPais.Text = "TODOS" Then

                                Orden = "pais"

                            Else

                                Orden = "cliente"

                            End If

                        End If

                    End If

                Case 2

                    Orden = "Cantidad"

                Case 3

                    Orden = "base"

            End Select

            ordenColumna = True

            Columna = e.Column

            Call ActualizarLV()

        End If

    End Sub


End Class




































''Cuando hacemos doble clic en el listview.
'Private Sub lvDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvEstadisticas.DoubleClick


'    If ckRaiz.Checked = True Then
'        For Each item In lvEstadisticas.SelectedItems
'            If lvEstadisticas.SelectedItems.Count = 1 Then
'                Dim GG As New InformeEstadisticaVentas
'                GG.verInformeRaizCliente(sBusqueda and , Orden, "", PonerTitulo(False))
'                GG.ShowDialog()
'            End If
'        Next

'        'If lvEstadisticas.SelectedItems.Count > 0 Then
'        '    Dim iidCliente As Integer = lvEstadisticas.SelectedItems(0).Text
'        '    Dim GG As New InformeEstadisticaVentas
'        '    GG.verInformeAñosRaiz(sBusqueda, Orden, lvEstadisticas.SelectedItems.Item.text, PonerTitulo(False))
'        '    GG.ShowDialog()
'        'End If
'    End If

'End Sub

'Cuando hacemos clic en la cabecera columna se ordena la columna seleccionada








''LUIS: crea la busqueda de las años seleccionadas.
'Public Sub busquedaPorAños()
'    Dim sqlwhere As String = ""
'    For Each item In lbxMeses.SelectedItems
'        If sqlwhere = "" Then
'            sqlwhere = sqlwhere & " and (datename(m, fecha)= '" & item & "'"
'        Else
'            sqlwhere = sqlwhere & " or datename(m, fecha)= '" & item & "'"
'        End If
'    Next
'    If sqlwhere <> "" Then
'        sqlwhere = sqlwhere & ")"
'    Else
'        sqlwhere = "and datename(m, fecha)= ''"
'    End If
'    Try
'        Busqueda()
'    Catch ex As Exception
'        MsgBox("FALLO AL CARGAR DATOS AÑOS", MsgBoxStyle.Information)
'    End Try
'End Sub






'If ckInformeComerciales.Checked = True Or ckInformeTipos.Checked = True Then
'    If ckInformeComerciales.Checked Then
'        Dim GG As New InformeEstadisticaVentasComerciales
'        GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
'        GG.ShowDialog()
'    Else
'        Dim GG As New InformeEstadisticaVentasTipo
'        GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
'        GG.ShowDialog()
'    End If
'Else
'    If cbPais.SelectedIndex <> 0 Then
'        Dim GG As New InformeEstadisticaVentas
'        GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
'        GG.ShowDialog()
'    ElseIf cbPais.SelectedItem.ToString = "TODOS" Then
'        Dim GG As New InformeEstadisticaVentasPaises
'        GG.verInforme(sBusqueda, Orden & " " & Direccion, 0, PonerTitulo(True))
'        GG.ShowDialog()
'    End If
'End If






'Muestra una ayuda de busqueda.
'Private Sub ayudaBusqueda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ayudaBusqueda.Click
'    MsgBox("Para realizar una BÚSQUEDA DE TODOS LOS CLIENTES tiene que estar vacío el campo país e inactivos los check de informe por tipos y por comerciales." _
'            & vbLf & vbLf & "Para realizar una BÚSQUEDA DE TODOS LOS PAÍSES tiene que seleccionar 'TODOS' en el campo país e inactivos los check de informe por tipos y por comerciales. " _
'            & vbLf & vbLf & "Para realizar una BÚSQUEDA POR COMERCIALES tiene que estar activo el check informe por comerciales." _
'            & vbLf & vbLf & "Para realizar una BÚSQUEDA POR TIPO tiene que estar activo el check informe por tipos.", MsgBoxStyle.Information)

'End Sub

''Abre el formulario provisional
'Private Sub informeProvisional(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'    ArcticulosPersonalizado.Show()
'End Sub

''Informe Tipo
'Private Sub ckInformeTipo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    If checkActivado = False Then
'        If ckInformeTipos.Checked = True Then
'            ckSubTipos.Enabled = True
'            checkActivado = True
'            ckInformeComerciales.Checked = False
'            checkActivado = False
'            cbTipo.Text = ""
'            cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
'        Else
'            ckInformeComerciales.Enabled = True
'            cambiosControles() 'Llama a cambio de controles para iniciar la busqueda
'            ckSubTipos.Enabled = False
'            ckSubTipos.Checked = False
'        End If
'    End If
'End Sub




''Formatea las columnas del listview para Raiz.
'Public Sub lvEstadisticasRaizAños()

'    Dim numColumnas As Integer = 1

'    vNumColumnas = 0

'    With lvEstadisticas
'        .Clear()
'        lvTotales.Clear()
'        If ckRaiz.Checked = True Or ckAños.Checked Then
'            'Si años esta activo
'            If ckAños.Checked = True Then
'                If cbPais.Text = "TODOS" Then
'                    .Columns.Add("IDPAIS")
'                    .Columns.Add("PAIS")
'                Else
'                    .Columns.Add("IDCLIENTE")
'                    .Columns.Add("CLIENTE")
'                End If
'                .Columns(0).Width = 0
'                .Columns(1).Width = 350
'            Else
'                .Columns.Add("RAÍZ")
'                .Columns(0).Width = 380
'                lvTotales.Columns.Add("TOTALES")
'                lvTotales.Columns(0).Width = 200
'                'For Each item In cbAño.Items
'                For Each item In lbxAños.SelectedItems
'                    If item.ToString <> "TODOS" Then
'                        .Columns.Add(item)
'                        .Columns(numColumnas).TextAlign = HorizontalAlignment.Right
'                        .Columns(numColumnas).Width = 150
'                        lvTotales.Columns.Add(item)
'                        lvTotales.Columns(numColumnas).TextAlign = HorizontalAlignment.Right
'                        lvTotales.Columns(numColumnas).Width = 150
'                        numColumnas = numColumnas + 1
'                    End If
'                    vNumColumnas = vNumColumnas + 1
'                Next
'            End If
'        Else
'            formatLvEstadisticas()
'        End If
'    End With
'End Sub