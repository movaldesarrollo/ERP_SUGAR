Imports System.Data.SqlClient
Imports System.Data.Sql


Public Class FuncionesConceptosEquiposProduccion


    Inherits conexion
    Dim cmd As SqlCommand
    Private funcES As New FuncionesEstados


    Dim sel0 As String = " Select CEP.*,EP.idProduccion, Etiquetas.nombre as Etiqueta, AR.codArticulo, AR.Articulo, esTA.Estado as EstadoTaller, esEL.Estado as EstadoElectronica, Estados.Estado as Estado," _
             & " EP.Observaciones, EP.numSerie, EP.idArticulo, EP.idEscandallo as idEscandalloEquipo, " _
             & " esTA.Anulado as esTAanulado, esTA.EnCurso as esTAEnCurso, esTA.Espera as esTAEspera, esTA.Completo as esTACompleto, esEL.Anulado as esELanulado, esEL.EnCurso as esELEnCurso, esEL.Espera as esELEspera,  esEL.Completo as esELCompleto " _
             & " FROM ConceptosEquiposProduccion as CEP left join EquiposProduccion as EP ON EP.idEquipo = CEP.idEquipo " _
             & " Left Join Articulos as AR ON AR.idArticulo = CEP.idArticulo " _
             & " Left join Estados ON Estados.idEstado = CEP.idEstado " _
             & " Left join Estados as esTA ON esTA.idEstado = CEP.idEstadoTaller " _
             & " Left join Estados as esEL ON esEL.idEstado = CEP.idEstadoElectronica " _
             & " left join Etiquetas ON Etiquetas.idEtiqueta = EP.idEtiqueta"


    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosConceptoEquipoProduccion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda) & If(sOrden.Length = 0, " Order By idEquipo ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoEquipoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else

                        lista.Add(CargarLinea(linea))

                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Function CargarLinea(ByVal linea As DataRow) As DatosConceptoEquipoProduccion
        Dim dts As New DatosConceptoEquipoProduccion
        dts.gidConcepto = linea("idConcepto")
        dts.gidEquipo = If(linea("idEquipo") Is DBNull.Value, 0, linea("idEquipo"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gidEstadoTaller = If(linea("idEstadoTaller") Is DBNull.Value, 0, linea("idEstadoTaller"))
        dts.gidEstadoElectronica = If(linea("idEstadoElectronica") Is DBNull.Value, 0, linea("idEstadoElectronica"))
        dts.gidEstado = If(linea("idEstado") Is DBNull.Value, 0, linea("idEstado"))
        dts.gidEtiqueta = If(linea("idEtiqueta") Is DBNull.Value, 0, linea("idEtiqueta"))
        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))
        dts.gVersion = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
        'Datos de otras tablas
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gidProduccion = If(linea("idProduccion") Is DBNull.Value, 0, linea("idProduccion"))
        dts.gnumSerie = If(linea("numSerie") Is DBNull.Value, "", linea("numSerie"))
        dts.gidEscandalloEquipo = If(linea("idEscandalloEquipo") Is DBNull.Value, 0, linea("idEscandalloEquipo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gEstado = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
        dts.gEstadoTaller = If(linea("EstadoTaller") Is DBNull.Value, "", linea("EstadoTaller"))
        dts.gEstadoElectronica = If(linea("EstadoElectronica") Is DBNull.Value, "", linea("EstadoElectronica"))
        dts.gEtiqueta = If(linea("Etiqueta") Is DBNull.Value, "", linea("Etiqueta"))
        Return dts
    End Function


   
    Public Function MostrarVista(ByVal Vista As String) As List(Of DatosConceptoEquipoProduccion)
        'Equipos de una o varias secciones
        Try
            If Vista = "TALLER" Or Vista = "ELECTRÓNICA" Or Vista = "TODAS" Then
                Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String = ""
                If Vista = "TALLER" Then
                    sel = sel0 & " WHERE (esTA.Espera = 1 or esTA.EnCurso = 1)"
                End If
                If Vista = "ELECTRÓNICA" Then
                    sel = sel0 & " WHERE (esEL.Espera = 1 or esEL.EnCurso = 1)"
                End If
                If Vista = "TODAS" Then
                    sel = sel0 & " WHERE (esTA.Espera = 1 or esTA.EnCurso = 1 or esEL.Espera = 1 or esEL.EnCurso = 1)"
                End If
                sel = sel & " Order By FechaPedido ASC, FechaEntrega ASC, prioridad asc"
                cmd = New SqlCommand(sel, con)
                Dim lista As New List(Of DatosConceptoEquipoProduccion)
                Dim linea As DataRow
                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    For Each linea In dt.Rows
                        If linea("idConcepto") Is DBNull.Value Then
                        Else
                            lista.Add(CargarLinea(linea))
                        End If
                    Next
                Else
                    con.Close()
                End If
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function Mostrar(ByVal iidEquipo As Integer) As List(Of DatosConceptoEquipoProduccion)
        'Equipos de una o varias secciones
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE EP.idEquipo = " & iidEquipo
            sel = sel & " Order By Articulo "
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosConceptoEquipoProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



   




    Public Function Estadistica(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosEstadisticaProduccion)
        'Estadística de producción
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select count(idConcepto) as Cantidad,CE.idFinalizador as idPersona,CE.idArticulo, AR.codArticulo,TU.TipoUnidad, AR.Articulo, Nombre + ' ' + Apellidos as Persona "
            sel = sel & " from ConceptosEquiposProduccion as CE "
            sel = sel & " left join Articulos as AR on AR.idArticulo = CE.idArticulo"
            sel = sel & " left join TiposUnidad as TU ON TU.idTipoUnidad = AR.idUnidad"
            sel = sel & " left join EquiposProduccion as EQ ON EQ.idEquipo = CE.idEquipo"
            sel = sel & " left join Personal ON Personal.idPersona = CE.idFinalizador"
            sel = sel & " left join Contactos ON Contactos.idContacto = Personal.idContacto "
            sel = sel & If(sBusqueda.Length = 0, "", " WHERE " & sBusqueda)
            sel = sel & " group by CE.idFinalizador,CE.idArticulo,AR.Articulo,AR.codArticulo,TU.TipoUnidad,Nombre,Apellidos"
            sel = sel & If(sOrden.Length = 0, " Order By Persona ASC ", " Order By " & sOrden)
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEstadisticaProduccion)
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                Dim dts As DatosEstadisticaProduccion
                da.Fill(dt)

                For Each linea In dt.Rows
                    If linea("idPersona") Is DBNull.Value Then
                    Else
                        dts = New DatosEstadisticaProduccion
                        dts.gidPersona = linea("idPersona")
                        dts.gPersona = If(linea("Persona") Is DBNull.Value, "", linea("Persona"))
                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
                      
                        lista.Add(dts)
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    




    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoEquipoProduccion
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = sel0 & " WHERE EP.idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosConceptoEquipoProduccion
            Dim linea As DataRow
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim esTAAnulado As Boolean = False
                Dim esTAEnCurso As Boolean = False
                Dim esTAEspera As Boolean = False
                Dim esTACompleto As Boolean = False
                Dim esESAnulado As Boolean = False
                Dim esESEnCurso As Boolean = False
                Dim esESEspera As Boolean = False
                Dim esESCompleto As Boolean = False

                For Each linea In dt.Rows
                    If linea("idConcepto") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea)
                    End If
                Next
            Else
                con.Close()
            End If
            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    

    Public Function Columnas(ByVal SoloInacabados As Boolean) As Integer
        'Devuelve el número de numPedidos/prioridad diferentes (serán las columnas de la vistaProduccion)
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select  count(numPedido) from ConceptosEquiposProduccion as CP  left outer join ConceptosPedidos as C1 ON C1.idConcepto = CP.idConceptoPedido group by numPedido,Prioridad"
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function EquiposSecciones(ByVal iidProduccion As Long) As List(Of ParSeccionUnidades)
        'Cuenta los equipos en producción correspondientes a un Concepto de producción en cada seccion 
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = " select idSeccion,(select sum(idEquipo) from ConceptosEquiposProduccion where idProduccion = " & iidProduccion & " AND idSeccion = SE.idSeccion) as Unidades "
            sel = sel & " from secciones as SE "
            Dim lista As New List(Of ParSeccionUnidades)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim par As ParSeccionUnidades
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each linea In dt.Rows
                    If linea("idSeccion") Is DBNull.Value Then
                    Else
                        par = New ParSeccionUnidades
                        par.gidSeccion = linea("idSeccion")
                        par.gUnidades = If(linea("Unidades") Is DBNull.Value, 0, linea("Unidades"))
                        lista.Add(par)
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    

   
    Public Function idArticulo(ByVal iidConcepto As Long) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idArticulo from ConceptosEquiposProduccion  where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function idEstado(ByVal iidConcepto As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstado from ConceptosEquiposProduccion  where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function





    Public Function idEstadoTaller(ByVal iidConcepto As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstadoTaller from ConceptosEquiposProduccion  where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function idEstadoElectronica(ByVal iidConcepto As Long) As Integer
        'Informa si todas las lineas ya han sido traspasada
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select idEstadoElectronica from ConceptosEquiposProduccion  where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 0
            Else
                Return CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Public Function insertar(ByVal dts As DatosConceptoEquipoProduccion) As Integer 'Inserta una nueva Pedido y devuelve el nº

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "insert into ConceptosEquiposProduccion (idEquipo, idArticulo, Cantidad, idEstadoElectronica, idEstadoTaller,idEstado, idEtiqueta, idEscandallo, VersionEscandallo) "
        sel = sel & " values (@idEquipo,  @idArticulo,@Cantidad, @idEstadoElectronica, @idEstadoTaller, @idEstado, @idEtiqueta, @idEscandallo, @VersionEscandallo) Select @@Identity"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idEquipo", dts.gidEquipo)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idEstadoElectronica", dts.gidEstadoElectronica)
                cmd.Parameters.AddWithValue("idEstadoTaller", dts.gidEstadoTaller)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End Using


    End Function

    Public Function actualizar(ByVal dts As DatosConceptoEquipoProduccion) As Boolean   '
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ConceptosEquiposProduccion set idEquipo = @idEquipo, idArticulo = @idArticulo, Cantidad = @Cantidad, idEstadoElectronica = @idEstadoElectronica, idEstadoTaller = @idEstadoTaller, idEstado = @idEstado, idEtiqueta = @idEtiqueta, idEscandallo = @idEscandalolo, VersionEscandallo = @VersionEscandallo "
        sel = sel & " WHERE idConcepto = @idConcepto"

        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idEquipo", dts.gidEquipo)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idEstadoElectronica", dts.gidEstadoElectronica)
                cmd.Parameters.AddWithValue("idEstadoTaller", dts.gidEstadoTaller)
                cmd.Parameters.AddWithValue("idEstado", dts.gidEstado)
                cmd.Parameters.AddWithValue("idEtiqueta", dts.gidEtiqueta)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersion)

                'abrir conexion
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Using
    End Function

    Public Function CambiarEstado(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosEquiposProduccion set idEstado = @idEstado where idConcepto = @idConcepto"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)

                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function

    Public Function CambiaridEquipo(ByVal iidConcepto As Integer, ByVal iidEquipo As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosEquiposProduccion set idEquipo = @idEquipo where idConcepto = @idConcepto"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idEquipo", iidEquipo)

                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function

    Public Function Finalizar(ByVal iidConcepto As Integer) As Boolean
        'Carga los campos de quien y cuando ha finalizado el concepto de equipo
        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosEquiposProduccion set idFinalizador = @idFinalizador, Finalizacion = @Finalizacion where idConcepto = @idConcepto"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idFinalizador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Finalizacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function

   


    Public Function CambiarEstadoTaller(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosEquiposProduccion set idEstadoTaller = @idEstado where idConcepto = @idConcepto"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function

    Public Function CambiarEstadoElectronica(ByVal iidConcepto As Integer, ByVal iidEstado As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "Update ConceptosEquiposProduccion set idEstadoElectronica = @idEstado where idConcepto = @idConcepto"
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", iidConcepto)
                cmd.Parameters.AddWithValue("idEstado", iidEstado)
               
                con.Open()
                Dim t As Integer = cmd.ExecuteNonQuery()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try
        End Using
    End Function

    Public Function CalculaEstado(ByVal iidConcepto As Integer) As Integer
        'Calcula y actualiza el estado segun los estados de taller y electrónica
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "Select esTA.Anulado as esTAAnulado, esTA.EnCurso as esTAEnCurso, esTA.Espera as esTAEspera, esTA.Completo as esTACompleto, "
            sel = sel & " esEL.Anulado as esELAnulado, esEL.EnCurso as esELEnCurso, esEL.Espera as esELEspera, esEL.Completo as esELCompleto, EP.idEstado "
            sel = sel & " from ConceptosEquiposProduccion as EP left Join Estados as esTA on esTA.idEstado = EP.idEstadoTaller "
            sel = sel & " left join Estados as esEL on esEL.idEstado = EP.idEstadoElectronica where idConcepto = " & iidConcepto
            cmd = New SqlCommand(sel, con)
            Dim idEstado As Integer
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim esTAAnulado, esTAEnCurso, esTAEspera, esTACompleto As Boolean
                Dim esELAnulado, esELEnCurso, esELEspera, esELCompleto As Boolean
                For Each linea In dt.Rows
                    esTAAnulado = If(linea("esTAAnulado") Is DBNull.Value, False, linea("esTAAnulado"))
                    esTAEnCurso = If(linea("esTAEnCurso") Is DBNull.Value, False, linea("esTAEnCurso"))
                    esTAEspera = If(linea("esTAEspera") Is DBNull.Value, False, linea("esTAEspera"))
                    esTACompleto = If(linea("esTACompleto") Is DBNull.Value, False, linea("esTACompleto"))
                    esELAnulado = If(linea("esELAnulado") Is DBNull.Value, False, linea("esELAnulado"))
                    esELEnCurso = If(linea("esELEnCurso") Is DBNull.Value, False, linea("esELEnCurso"))
                    esELEspera = If(linea("esELEspera") Is DBNull.Value, False, linea("esELEspera"))
                    esELCompleto = If(linea("esELCompleto") Is DBNull.Value, False, linea("esELCompleto"))
                    If esTAAnulado And esELEspera Or esTAEspera And esELAnulado Or esTAEspera Or esELEspera Then
                        idEstado = funcES.EstadoEspera("EQUIPO").gidEstado
                    ElseIf esTAEspera And esELCompleto Or esTACompleto And esELEspera Then
                        idEstado = funcES.EstadoEnCurso("EQUIPO").gidEstado
                    ElseIf esTAAnulado And esELCompleto Or esTACompleto And esTAAnulado Or esTACompleto And esTACompleto Then
                        idEstado = funcES.EstadoCompleto("EQUIPO").gidEstado
                    Else
                        idEstado = funcES.EstadoAnulado("EQUIPO").gidEstado
                    End If
                    If linea("idEstado") Is DBNull.Value Then
                        CambiarEstado(iidConcepto, idEstado)
                    Else
                        If idEstado <> linea("idEstado") Then
                            CambiarEstado(iidConcepto, idEstado)
                        End If
                    End If
                Next
            Else
                con.Close()
            End If
            Return idEstado
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function




    Public Function borrarEquipo(ByVal iidEquipo As Long) As Boolean  ' Borra un equipo


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ConceptosEquiposProduccion where idEquipo = " & iidEquipo
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function

    Public Function borrar(ByVal iidConcepto As Long) As Boolean


        Dim sconexion As String = CadenaConexion()
        Dim sel As String = "delete from ConceptosEquiposProduccion where idConcepto = " & iidConcepto
        Using con As New SqlConnection(sconexion)
            Try
                'conectado()
                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()

                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                Return 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0

            End Try
        End Using

    End Function





End Class
