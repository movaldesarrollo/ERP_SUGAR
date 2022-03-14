
Imports System.Data.SqlClient
Imports System.Data.Sql
'Imports System.Transactions

Public Class FuncionesEscandallos

    Inherits conexion
    Dim cmd As SqlCommand
    Dim sconexion As String = CadenaConexion()

    Dim funcCE As New FuncionesConceptosEscandallos
    Dim funcMO As New FuncionesMoneda
    Dim funcTI As New FuncionesTiemposEscandallos

    Private Function sentenciaSQL(ByVal CosteCalculado As Boolean) As String
        'Dim sel As String = "SELECT  Distinct ES.*, Articulo, codArticulo, TipoEscandallo,Composicion,Articulos.idTipoArticulo, Articulos.idSubTipoArticulo, TipoArticulo, subTipoArticulo,Familia,subFamilia, ESb.VersionEscandallo as VersionBase, "
        'sel = sel & " (Select Count(idConcepto) From ConceptosEscandallos where ConceptosEscandallos.idEscandallo = ES.idEscandallo) as numComponentes "
        'If Not CosteCalculado Then
        '    sel = sel & ", (Select sum(Precio * Cantidad) From ConceptosEscandallos AS CC  left Join Articulos_Precios as AP ON AP.idArticulo = CC.idArticulo where CC.idEscandallo = ES.idEscandallo and CC.Activo = 1 and AP.TipoPrecio='C' and AP.Activo=1) as Coste "
        'End If
        Dim sel As String = "SELECT  Distinct ES.*, 0 Versionbase, Articulo, codArticulo, TipoEscandallo,Composicion,Articulos.idTipoArticulo, Articulos.idSubTipoArticulo, TipoArticulo, subTipoArticulo,Familia,subFamilia, "
        sel = sel & " (Select Count(idConcepto) From ConceptosEscandallos where ConceptosEscandallos.idEscandallo = ES.idEscandallo) as numComponentes "
        If Not CosteCalculado Then
            sel = sel & ", (Select sum(Precio * Cantidad) From ConceptosEscandallos AS CC  left Join Articulos_Precios as AP ON AP.idArticulo = CC.idArticulo where CC.idEscandallo = ES.idEscandallo and CC.Activo = 1 and AP.TipoPrecio='C' and AP.Activo=1) as Coste "
        End If
        sel = sel & " FROM Escandallos as ES LEFT JOIN Articulos ON Articulos.idArticulo = ES.idArticulo "
        sel = sel & " LEFT JOIN TiposEscandallo ON TiposEscandallo.idTipoEscandallo = ES.idTipoEscandallo "
        sel = sel & " LEFT JOIN TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
        sel = sel & " LEFT JOIN SubTiposArticulo ON SubTiposArticulo.idSubTipoArticulo = Articulos.idSubTipoArticulo "
        sel = sel & " LEFT JOIN Familias ON Familias.idFamilia = Articulos.idFamilia "
        sel = sel & " LEFT JOIN SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia "
        sel = sel & " LEFT JOIN Escandallos as ESb ON ESb.idArticulo = ES.idArticuloBase AND ES.idArticuloBase <> 0 "
        Return sel
    End Function

    Public Function Mostrar(ByVal SoloActivos As Boolean) As List(Of DatosEscandallo)
        Try

            Dim con As New SqlConnection(sconexion)

            Dim sel As String = sentenciaSQL(True) & If(SoloActivos, " WHERE ES.Activo = 1 ", "") & " Order By Escandallo "

            cmd = New SqlCommand(sel, con)

            Dim lista As New List(Of DatosEscandallo)

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("idEscandallo") Is DBNull.Value Then

                    Else

                        lista.Add(CargarLinea(linea, True))

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

    Private Function CargarLinea(ByVal linea As DataRow, ByVal CosteCalculado As Boolean) As DatosEscandallo
        Dim dts As New DatosEscandallo
        Dim iidEscandallo As Integer = linea("idEscandallo")
        dts.gidEscandallo = iidEscandallo
        dts.gcodEscandallo = If(linea("codEscandallo") Is DBNull.Value, "", linea("codEscandallo"))
        dts.gidTipoEscandallo = If(linea("idTipoEscandallo") Is DBNull.Value, 0, linea("idTipoEscandallo"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
        dts.gEscandallo = If(linea("Escandallo") Is DBNull.Value, "", linea("Escandallo"))
        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))
        dts.gFechaAlta = If(linea("FechaAlta") Is DBNull.Value, Now.Date, linea("FechaAlta"))
        dts.gFechaBaja = If(linea("FechaBaja") Is DBNull.Value, Now.Date, linea("FechaBaja"))
        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))
        dts.gVersionEscandallo = If(linea("VersionEscandallo") Is DBNull.Value, 0, linea("VersionEscandallo"))
        If dts.gVersionEscandallo = 0 Then dts.gVersionEscandallo = If(linea("VersionBase") Is DBNull.Value, 0, linea("VersionBase"))
        'dts.gVersionBase = If(linea("VersionBase") Is DBNull.Value, 0, linea("VersionBase"))
        dts.gnumComponentes = If(linea("numComponentes") Is DBNull.Value, 0, linea("numComponentes"))
        If CosteCalculado Then
            dts.gCoste = CosteEU(iidEscandallo, True, Now.Date) + funcTI.TotalCoste(iidEscandallo, True)
        Else
            dts.gCoste = If(linea("Coste") Is DBNull.Value, 0, linea("Coste"))
        End If
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gTipoEscandallo = If(linea("TipoEscandallo") Is DBNull.Value, "", linea("TipoEscandallo"))
        dts.gidArticuloBase = If(linea("idArticuloBase") Is DBNull.Value, 0, linea("idArticuloBase"))
        dts.gComposicion = If(linea("Composicion") Is DBNull.Value, False, linea("Composicion"))
        dts.gidTipoArticulo = If(linea("idTipoArticulo") Is DBNull.Value, 0, linea("idTipoArticulo"))
        dts.gTipoArticulo = If(linea("TipoArticulo") Is DBNull.Value, "", linea("TipoArticulo"))
        dts.gidSubTipoArticulo = If(linea("idSubTipoArticulo") Is DBNull.Value, 0, linea("idSubTipoArticulo"))
        dts.gSubTipoArticulo = If(linea("SubTipoArticulo") Is DBNull.Value, "", linea("SubTipoArticulo"))
        If dts.gTipoArticulo = "" Then dts.gTipoArticulo = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))
        If dts.gSubTipoArticulo = "" Then dts.gSubTipoArticulo = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))
        Return dts

    End Function

    Public Function MostraEscandallos(ByVal iidArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosEscandallo)
        'Escandallos de los que el artículo es componente
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String
            sel = "SELECT  ES.*, Articulo, CE.Cantidad, codArticulo, TipoEscandallo,Composicion,Articulos.idTipoArticulo, Articulos.idSubTipoArticulo, TipoArticulo, subTipoArticulo,ESb.VersionEscandallo as VersionBase, Familia, subFamilia, "
            sel = sel & " (Select Count(idConcepto) From ConceptosEscandallos where ConceptosEscandallos.idEscandallo = ES.idEscandallo) as numComponentes "
            sel = sel & " FROM ConceptosEscandallos as CE "
            sel = sel & " Left Join Escandallos as ES ON ES.idEscandallo = CE.idEscandallo "
            sel = sel & " LEFT JOIN Articulos ON Articulos.idArticulo = ES.idArticulo "
            sel = sel & " LEFT JOIN TiposEscandallo ON TiposEscandallo.idTipoEscandallo = ES.idTipoEscandallo "
            sel = sel & " LEFT JOIN TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " LEFT JOIN SubTiposArticulo ON SubTiposArticulo.idSubTipoArticulo = Articulos.idSubTipoArticulo "
            sel = sel & " LEFT JOIN Familias ON Familias.idFamilia = Articulos.idFamilia "
            sel = sel & " LEFT JOIN SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia "
            sel = sel & " LEFT JOIN Escandallos as ESb ON ESb.idArticulo = ES.idArticuloBase AND ES.idArticuloBase <> 0 AND ESb.Activo = 1 "
            sel = sel & " WHERE CE.idArticulo = " & iidArticulo
            sel = sel & If(SoloActivos, " AND ES.Activo = 1 ", "") & " Order By Escandallo "

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEscandallo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosEscandallo
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea, True)
                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
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


    'Mostrar lista de escandallos gestion articulo
    Public Function MostraEscandallosGestionArticulo(ByVal iidArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosEscandallo)
        'Escandallos de los que el artículo es componente
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "SELECT  ES.*, Articulo, CE.Cantidad, codArticulo, TipoEscandallo,Composicion,Articulos.idTipoArticulo, Articulos.idSubTipoArticulo, TipoArticulo, subTipoArticulo,ESb.VersionEscandallo as VersionBase, Familia, subFamilia, "
            sel = sel & " (Select Count(idConcepto) From ConceptosEscandallos where ConceptosEscandallos.idEscandallo = ES.idEscandallo) as numComponentes "
            sel = sel & " FROM ConceptosEscandallos as CE "
            sel = sel & " Left Join Escandallos as ES ON ES.idEscandallo = CE.idEscandallo "
            sel = sel & " LEFT JOIN Articulos ON Articulos.idArticulo = ES.idArticulo "
            sel = sel & " LEFT JOIN TiposEscandallo ON TiposEscandallo.idTipoEscandallo = ES.idTipoEscandallo "
            sel = sel & " LEFT JOIN TiposArticulo ON TiposArticulo.idTipoArticulo = Articulos.idTipoArticulo "
            sel = sel & " LEFT JOIN SubTiposArticulo ON SubTiposArticulo.idSubTipoArticulo = Articulos.idSubTipoArticulo "
            sel = sel & " LEFT JOIN Familias ON Familias.idFamilia = Articulos.idFamilia "
            sel = sel & " LEFT JOIN SubFamilias ON SubFamilias.idSubFamilia = Articulos.idSubFamilia "
            sel = sel & " LEFT JOIN Escandallos as ESb ON ESb.idArticulo = ES.idArticuloBase AND ES.idArticuloBase <> 0 AND ESb.Activo = 1 "
            sel = sel & " WHERE CE.idArticulo = " & iidArticulo
            sel = sel & If(SoloActivos, " AND ES.Activo = 1 ", "") & " Order By Escandallo "

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of DatosEscandallo)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim dts As DatosEscandallo
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        dts = CargarLineaEscandallosGestionArticulos(linea)
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

    Private Function CargarLineaEscandallosGestionArticulos(ByVal linea As DataRow) As DatosEscandallo

        Dim dts As New DatosEscandallo

        dts.gidEscandallo = linea("idEscandallo")
        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))
        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))
       
        Return dts

    End Function

    Public Function MostrarArticulo(ByVal iidArticulo As Integer, ByVal SoloActivos As Boolean) As List(Of DatosEscandallo)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = sentenciaSQL(True) & " WHERE idArticulo = " & iidArticulo & If(SoloActivos, " AND Escandallos.Activo = 1 ", "") & " Order By Escandallo "

            Dim lista As New List(Of DatosEscandallo)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea, True))
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

    Public Function Mostrar1(ByVal iidEscandallo As Integer) As DatosEscandallo
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = sentenciaSQL(True) & " WHERE ES.idEscandallo = " & iidEscandallo
            cmd = New SqlCommand(sel, con)
            Dim dts As New DatosEscandallo
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        dts = CargarLinea(linea, True)
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

    Public Function FechaActualizacion(ByVal iidEscandallo As Integer) As Date
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String

            sel = " select idEscandallo, Creacion, Modificacion, idModifica from Escandallos WHERE idEscandallo = " & iidEscandallo
            cmd = New SqlCommand(sel, con)
            Dim fecha As Date = Now.Date
            Dim idModifica As Integer
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        idModifica = If(linea("idModifica") Is DBNull.Value, 0, linea("idModifica"))
                        If idModifica > 0 Then
                            fecha = If(linea("Modificacion") Is DBNull.Value, Now.Date, linea("Modificacion"))
                        Else
                            fecha = If(linea("Creacion") Is DBNull.Value, Now.Date, linea("Creacion"))
                        End If
                    End If
                Next
            Else
                con.Close()
            End If
            Return fecha
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
    End Function

    Public Function CosteEU(ByVal iidEscandallo As Integer, ByRef Aviso As Boolean, ByRef FechaCambio As Date) As Double
        'Devuelve por referencia el aviso si el cambio no es de hoy
        Dim listaC As List(Of DatosConceptoEscandallo) = funcCE.Mostrar(iidEscandallo, True, 0)
        Dim suma As Double = 0
        Aviso = False
        FechaCambio = Now.Date
        For Each dts As DatosConceptoEscandallo In listaC
            If dts.gActivo Then
                If dts.gcodMoneda = "EU" Then
                    suma = suma + dts.gCantidad * dts.gCoste
                Else
                    suma = suma + dts.gCantidad * funcMO.Cambio(dts.gCoste, dts.gcodMoneda, "EU", Aviso, FechaCambio)
                    'If funcMO.CampoFecha(dts.gcodMoneda) <> Now.Date Then Aviso = True
                End If
            End If
        Next
        Return suma
    End Function

    Public Function contarRegistros(ByVal sBusqueda As String, ByVal sOrden As String) As Integer
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sentenciaSQL(False) & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden)
            Dim i As Integer
            cmd = New SqlCommand(sel, con)
            con.Open()
            i = cmd.ExecuteScalar()
            con.Close()
            Return i
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Busqueda(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of DatosEscandallo)
        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = sentenciaSQL(False) & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden)
            Dim lista As New List(Of DatosEscandallo)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLinea(linea, False))
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

    Public Function BusquedaLista(ByVal sBusqueda As String, ByVal sOrden As String) As List(Of Integer)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select idEscandallo from Escandallos "
            sel = sel & If(sBusqueda = "", "", " WHERE " & sBusqueda) & If(sOrden = "", "", " ORDER BY " & sOrden)
            Dim lista As New List(Of Integer)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("idEscandallo"))
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

    Public Function ListaVersiones() As List(Of Integer)
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String
            sel = "select distinct versionEscandallo from Escandallos"
            Dim lista As New List(Of Integer)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("versionEscandallo") Is DBNull.Value Then
                    Else
                        If linea("versionEscandallo") <> 0 Then lista.Add(linea("versionEscandallo"))
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

    Public Function Comprobar(ByVal iidArticuloBase As Integer, ByVal listaOpciones As List(Of Integer), ByVal listaCantidades As List(Of Int16)) As Integer
        'Pasamos una lista de idArticulo que son las opciones de una composición. Devuelve la idEscandallo con la misma composicion o 0 si no hay ninguna
        Try
            Dim Contador As Integer = listaOpciones.Count + 1 ' articulo base + opciones
            Dim iidEscandallo As Integer = 0
            If Contador > 0 Then
                'Creamos una lista con todas las idEscandallo tipo composición con el artículo base y el mismo nº de opciones
                'Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String

                sel = "select  CE.idEscandallo,Count(idConcepto) from ConceptosEscandallos as CE left join Escandallos ON Escandallos.idEscandallo = CE.idEscandallo"
                sel = sel & " where idArticuloBase = " & iidArticuloBase
                sel = sel & "group by CE.idEscandallo having(Count(idConcepto) = " & Contador & ")"

                cmd = New SqlCommand(sel, con)
                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Dim linea As DataRow
                    Dim listaC As List(Of DatosConceptoEscandallo)
                    For Each linea In dt.Rows
                        If iidEscandallo = 0 Then
                            If linea("idEscandallo") Is DBNull.Value Then
                                iidEscandallo = 0
                            Else
                                iidEscandallo = linea("idEscandallo")
                                listaC = funcCE.Mostrar(iidEscandallo, True, iidArticuloBase)
                                Dim contiene As Boolean = True
                                Dim indice As Integer
                                For Each dts As DatosConceptoEscandallo In listaC
                                    indice = listaOpciones.IndexOf(dts.gidArticulo)
                                    'If listaOpciones.Contains(dts.gidArticulo) Then
                                    If indice = -1 Then
                                        contiene = False
                                    Else
                                        If listaCantidades(indice) <> dts.gCantidad Then
                                            contiene = False
                                        End If
                                    End If
                                Next
                                If Not contiene Or listaC.Count = 0 Then iidEscandallo = 0
                            End If
                        End If
                    Next
                Else
                    con.Close()
                End If

            End If
            Return iidEscandallo

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function NuevoidEscandallo() As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim cmd As SqlCommand = New SqlCommand("SELECT max(idEscandallo) FROM Escandallos", con)
            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return 1
            Else
                Return 1 + CInt(o)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try


    End Function

    Public Function EnUso(ByVal iidEscandallo As Integer) As Boolean
        'Nos dice si el Escandallo está en uso en Fabricación
        Return False
        'Dim sconexion As String = CadenaConexion()
        'Dim sel As String = "Select idCliente from Fabricacion  where idCliente = @idCliente union "
        'sel = "Select idCliente from PedidosProv  where idCliente = @idCliente  "
        'sel = sel & "Select idCliente from FacturasClientes  where idCliente = @idCliente union "
        'sel = sel & "Select idCliente from MateriasPrimas  where idCliente = @idCliente union "

        'sel = sel & "Select idCliente from Previsiones  where idCliente = @idCliente union "
        'sel = sel & "Select idCliente from Productos  where idCliente = @idCliente  "

        'Using con As New SqlConnection(sconexion)
        '    Try
        '        cmd = New SqlCommand(sel, con)
        '        con.Open()
        '        cmd.Parameters.AddWithValue("idCliente", iidCliente)

        '        Dim o As Object = cmd.ExecuteScalar
        '        con.Close()
        '        If o Is DBNull.Value Or o Is Nothing Then
        '            Return False
        '        Else
        '            Return CInt(o) = iidCliente
        '        End If

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        Return Nothing
        '    Finally
        '        desconectado()
        '    End Try

        'End Using

    End Function

    Public Function ExisteEscandallo(ByVal iidArticulo As Integer) As Integer
        'Devuelve el idEscandallo si existe
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo = 0 Then
                Return 0
            Else
                Dim sel As String = " SELECT idEscandallo FROM Escandallos WHERE  Activo = 1 and idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return 0
                Else
                    Return CInt(ob)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ExisteEscandallo(ByVal iidArticulo As Integer, ByVal Version As Integer) As Integer
        'Devuelve el idEscandallo si existe
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo = 0 Then
                Return 0
            Else
                Dim sel As String = " SELECT Top 1 idEscandallo FROM Escandallos WHERE  VersionEscandallo  = " & Version & "  and idArticulo = " & iidArticulo & " Order By idEscandallo DESC"
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Or ob Is Nothing Then
                    Return 0
                Else
                    Return CInt(ob)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function ExisteEscandalloVersionUltima(ByVal iidArticulo As Integer, ByVal Version As Integer) As Integer
        'Devuelve el idEscandallo si existe
        Try
            Dim iidEscandallo As Integer
            If iidArticulo = 0 Then
                iidEscandallo = 0
            ElseIf Version = 0 Then
                iidEscandallo = ExisteEscandalloVersion0(iidArticulo)
            Else
                'Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                Dim sel As String = " SELECT  idEscandallo FROM Escandallos WHERE  VersionEscandallo  <= " & Version & "  and idArticulo = " & iidArticulo & " Order By VersionEscandallo ASC"
                cmd = New SqlCommand(sel, con)

                con.Open()
                If cmd.ExecuteNonQuery Then
                    con.Close()
                    Dim dt As New DataTable
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    Dim linea As DataRow

                    For Each linea In dt.Rows
                        If linea("idEscandallo") Is DBNull.Value Then
                        Else
                            iidEscandallo = linea("idEscandallo")
                        End If
                    Next
                Else
                    con.Close()
                End If
            End If
            Return iidEscandallo
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExisteEscandalloVersion0(ByVal iidArticulo As Integer) As Integer
        'Devuelve el idEscandallo si existe
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo = 0 Then
                Return 0
            Else
                Dim sel As String = " SELECT Top 1 idEscandallo FROM Escandallos WHERE  idArticulo = " & iidArticulo & " Order By VersionEscandallo DESC"
                cmd = New SqlCommand(sel, con)

                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Return 0
                Else
                    Return CInt(o)
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ExisteEscandalloRealmente(ByVal iidArticulo As Integer) As Boolean
        'Devuelve si existen escandallo con componentes
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidArticulo = 0 Then
                Return 0
            Else
                Dim sel As String = " SELECT count(idConcepto) FROM ConceptosEscandallos as CE left join Escandallos ON Escandallos.idEscandallo = CE.idEscandallo WHERE  Escandallos.Activo = 1 and Escandallos.idArticulo = " & iidArticulo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return False
                Else
                    Return CInt(ob) > 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Escandallo(ByVal iidEscandallo As Integer) As String
        'Devuelve el nombre del producto
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidEscandallo <> 0 Then
                Dim sel As String = " SELECT Escandallo FROM Escandallos WHERE  idEscandallo = " & iidEscandallo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Articulo(ByVal iidEscandallo As Integer) As String
        'Devuelve el nombre del producto
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If iidEscandallo <> 0 Then
                Dim sel As String = " SELECT Articulo FROM Escandallos left join Articulos ON Articulos.idArticulo = Escandallos.idArticulo WHERE idEscandallo = " & iidEscandallo
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim ob As Object = cmd.ExecuteScalar
                con.Close()
                If ob Is DBNull.Value Then
                    Return ""
                Else
                    Return CStr(ob)
                End If

            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM Escandallos", con)
            Else

                cmd = New SqlCommand(" SELECT COUNT(*) FROM Escandallos WHERE  " & busqueda, con)

            End If
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

    Public Function codEscandalloExiste(ByVal iidEscandallo As Integer, ByVal scodEscandallo As String) As Boolean
        'Nos dice si existe una entrada el la tabla Escandallos con ese código
        If scodEscandallo = "" Then 'Or iidEscandallo = 0 Then
            Return False
        Else
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String = " SELECT idEscandallo FROM Escandallos WHERE  codEscandallo ='" & scodEscandallo & If(iidEscandallo = 0, "' ", "' and idEscandallo <> " & iidEscandallo)
            Using con As New SqlConnection(sconexion)
                Try
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    Dim o As Object = cmd.ExecuteScalar
                    con.Close()
                    If o Is DBNull.Value Or o Is Nothing Then
                        Return False
                    Else
                        Return (CInt(o) = iidEscandallo)
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing

                End Try
            End Using
        End If
    End Function

    Public Function idArticuloBase(ByVal iidEscandallo As Integer) As Integer

        ' Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT idArticuloBase FROM Escandallos WHERE  idEscandallo = " & iidEscandallo
        Using con As New SqlConnection(sconexion)
            Try
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
        End Using
    End Function

    Public Function idArticulo(ByVal iidEscandallo As Integer) As Integer

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT idArticulo FROM Escandallos WHERE  idEscandallo = " & iidEscandallo
        Using con As New SqlConnection(sconexion)
            Try
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
        End Using
    End Function

    Public Function VersionEscandallo(ByVal iidEscandallo As Integer) As Integer

        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT VersionEscandallo FROM Escandallos WHERE  idEscandallo = " & iidEscandallo
        Using con As New SqlConnection(sconexion)
            Try
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
        End Using
    End Function

    Public Function idArticuloBaseArticulo(ByVal iidArticulo As Integer) As Integer
        If iidArticulo = 0 Then Return 0
        Dim sel As String = " SELECT TOP 1 idArticuloBase FROM Escandallos  WHERE  idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
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
        End Using
    End Function

    Public Function VistaTaller(ByVal iidArticulo As Integer) As Boolean
        'Si es un artículo con producción separada se devuelve taller si es la vista de su sección 
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT Vista FROM Articulos left join Secciones ON Secciones.idSeccion = Articulos.idSeccion  WHERE ProduccionSeparada = 1 AND  idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Dim iidarticuloBase As Integer = idArticuloBaseArticulo(iidArticulo)
                    If iidarticuloBase > 0 Then
                        Return VistaTaller(iidarticuloBase)
                    Else
                        Return VistaTallerRecursiva(iidArticulo).Count > 0
                    End If
                Else
                    If CStr(o) = "TALLER" Then
                        Return True
                    Else
                        Dim iidarticuloBase As Integer = idArticuloBaseArticulo(iidArticulo)
                        If iidarticuloBase > 0 Then
                            Return VistaTaller(iidarticuloBase)
                        Else
                            Return VistaTallerRecursiva(iidArticulo).Count > 0
                        End If
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try
        End Using
    End Function

    Private Function VistaTallerRecursiva(ByVal iidArticulo As Integer) As List(Of Integer)
        'Nos dice si un artículo tiene en su desglose de material secciones de la vista taller
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = "Select CE.idArticulo, Vista from ConceptosEscandallos as CE left join Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
            sel = sel & " left join Secciones ON CE.idSeccion = Secciones.idSeccion left join Articulos ON Articulos.idArticulo = CE.idArticulo where Articulos.ProduccionSeparada = 1 AND Escandallos.idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Integer)
            Dim Encontrado As Boolean = False
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("idArticulo"))
                        If linea("Vista") Is DBNull.Value Then
                        Else
                            Encontrado = Encontrado Or linea("Vista") = "TALLER"
                        End If
                    End If
                Next
            Else
                con.Close()
            End If
            If Encontrado Then
                Return lista
            Else
                For Each iid As Integer In lista
                    Dim listaInt As List(Of Integer) = VistaTallerRecursiva(iid)
                    If listaInt.Count > 0 Then Return listaInt
                Next
            End If
            'Si llegamos hasta aqui, es que no hemos encontrado nada
            Return New List(Of Integer)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function VistaElectronica(ByVal iidArticulo As Integer) As Boolean
        'Si es un artículo con producción separada se devuelve electronica si es la vista de su sección 
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String = " SELECT Vista FROM Articulos left join Secciones ON Secciones.idSeccion = Articulos.idSeccion  WHERE ProduccionSeparada = 1 AND  idArticulo = " & iidArticulo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
                Dim o As Object = cmd.ExecuteScalar
                con.Close()
                If o Is DBNull.Value Or o Is Nothing Then
                    Dim iidarticuloBase As Integer = idArticuloBaseArticulo(iidArticulo)
                    If iidarticuloBase > 0 Then
                        Return VistaElectronica(iidarticuloBase)
                    Else
                        Return VistaElectronicaRecursiva(iidArticulo).Count > 0
                    End If
                Else
                    If CStr(o) = "ELECTRÓNICA" Then
                        Return True
                    Else
                        Dim iidarticuloBase As Integer = idArticuloBaseArticulo(iidArticulo)
                        If iidarticuloBase > 0 Then
                            Return VistaElectronica(iidarticuloBase)
                        Else
                            Return VistaElectronicaRecursiva(iidArticulo).Count > 0
                        End If
                    End If

                End If


            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing

            End Try
        End Using
    End Function

    Private Function VistaElectronicaRecursiva(ByVal iidArticulo As Integer) As List(Of Integer)
        'Nos dice si un artículo tiene en su desglose de material secciones de la vista taller
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = "Select CE.idArticulo, Vista from ConceptosEscandallos as CE left join Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
            sel = sel & " left join Secciones ON CE.idSeccion = Secciones.idSeccion left join Articulos ON Articulos.idArticulo = CE.idArticulo where Articulos.ProduccionSeparada = 1 AND Escandallos.idArticulo = " & iidArticulo

            cmd = New SqlCommand(sel, con)
            Dim lista As New List(Of Integer)
            Dim Encontrado As Boolean = False
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idArticulo") Is DBNull.Value Then
                    Else
                        lista.Add(linea("idArticulo"))
                        If linea("Vista") Is DBNull.Value Then
                        Else
                            Encontrado = Encontrado Or linea("Vista") = "ELECTRÓNICA"
                        End If
                    End If
                Next
            Else
                con.Close()
            End If
            If Encontrado Then
                Return lista
            Else
                For Each iid As Integer In lista
                    Dim listaInt As List(Of Integer) = VistaElectronicaRecursiva(iid)
                    If listaInt.Count > 0 Then Return listaInt
                Next
            End If
            'Si llegamos hasta aqui, es que no hemos encontrado nada
            Return New List(Of Integer)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function insertar(ByVal dts As DatosEscandallo) As Integer
        'Insertar un nuevo producto, si no existe ya el código 

        If codEscandalloExiste(dts.gidEscandallo, dts.gcodEscandallo) Then
            MsgBox("Ya existe una Escandallo con el código " & dts.gcodEscandallo)
        Else
            dts.gidEscandallo = NuevoidEscandallo()
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String
            Using con As New SqlConnection(sconexion)
                Try
                    sel = "insert into Escandallos (idEscandallo, codEscandallo, idTipoEscandallo,idArticulo, Escandallo, Observaciones, FechaAlta, FechaBaja, Activo,idArticuloBase,VersionEscandallo, idCreador, Creacion) "
                    sel = sel & " values (@idEscandallo, @codEscandallo, @idTipoEscandallo,@idArticulo, @Escandallo, @Observaciones, @FechaAlta, @FechaBaja, @Activo,@idArticuloBase,@VersionEscandallo, @idCreador, @Creacion) "
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                    cmd.Parameters.AddWithValue("codEscandallo", dts.gcodEscandallo)
                    cmd.Parameters.AddWithValue("idTipoEscandallo", dts.gidTipoEscandallo)
                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("Escandallo", dts.gEscandallo)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                    cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                    cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                    cmd.Parameters.AddWithValue("idArticuloBase", dts.gidArticuloBase)
                    cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersionEscandallo)
                    cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Creacion", Now)
                    con.Open()
                    Dim resultado As Integer = cmd.ExecuteNonQuery
                    con.Close()
                    If resultado > 0 Then
                        Return dts.gidEscandallo
                    Else
                        Return -1
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing

                End Try
            End Using
        End If
    End Function

    Public Function actualizar(ByVal dts As DatosEscandallo) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo
        If codEscandalloExiste(dts.gidEscandallo, dts.gcodEscandallo) Then
            MsgBox("Ya existe un Escandallo con el código " & dts.gcodEscandallo)
        Else
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String
            sel = "update Escandallos set  codEscandallo = @codEscandallo, idTipoEscandallo = @idTipoEscandallo,idArticulo = @idArticulo, Escandallo = @Escandallo,Observaciones = @Observaciones, "
            sel = sel & " FechaAlta = @FechaAlta, FechaBaja = @FechaBaja, Activo = @Activo, idArticuloBase = @idArticuloBase,VersionEscandallo = @VersionEscandallo, idModifica = @idModifica, Modificacion = @Modificacion "
            sel = sel & " WHERE idEscandallo = @idEscandallo "

            Using con As New SqlConnection(sconexion)
                Try
                    dts.gVersionBase = 2016
                    cmd = New SqlCommand(sel, con)
                    cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                    cmd.Parameters.AddWithValue("codEscandallo", dts.gcodEscandallo)
                    cmd.Parameters.AddWithValue("idTipoEscandallo", dts.gidTipoEscandallo)
                    cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                    cmd.Parameters.AddWithValue("Escandallo", dts.gEscandallo)
                    cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                    cmd.Parameters.AddWithValue("FechaAlta", dts.gFechaAlta)
                    cmd.Parameters.AddWithValue("FechaBaja", dts.gFechaBaja)
                    cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                    cmd.Parameters.AddWithValue("idArticuloBase", dts.gidArticuloBase)
                    cmd.Parameters.AddWithValue("VersionEscandallo", dts.gVersionEscandallo)
                    cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                    cmd.Parameters.AddWithValue("Modificacion", Now)
                    cmd.Parameters.AddWithValue("versionBase", dts.gVersionBase)
                    con.Open()
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
        End If
    End Function

    Public Function PrimerAño() As Integer
        'Devuelve el valor del primer año de las Articulos
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT MIN(FechaAlta) FROM Escandallos ", con)
            con.Open()
            Dim Resultado As Object = cmd.ExecuteScalar
            con.Close()
            If Resultado Is DBNull.Value Then
                Return 0
            Else
                Return Year(Resultado)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function PrimeraFecha() As Date
        'Devuelve el valor del primer año de las Articulos
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT MIN(FechaAlta) FROM Escandallos ", con)
            con.Open()
            Dim Resultado As Object = cmd.ExecuteScalar
            con.Close()
            If Resultado Is DBNull.Value Then
                Return Nothing
            Else
                Return Resultado
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Borrar(ByVal iidEscandallo As Integer) As Boolean
        If EnUso(iidEscandallo) Then
            MsgBox("El escandallo es utilizado en producción, no se puede borrar. Alternativamente, puede darlo de baja.")
            Return False
        Else
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String
            Try
                Dim Resultado As Boolean
                funcCE.BorrarEscandallo(iidEscandallo)

                'Después la cabecera
                Using con As New SqlConnection(sconexion)
                    sel = "delete from Escandallos where idEscandallo = " & iidEscandallo
                    cmd = New SqlCommand(sel, con)
                    con.Open()
                    Resultado = (CInt(cmd.ExecuteNonQuery()) = 1)
                    con.Close()
                End Using

                Return Resultado


            Catch ex As Exception
                MsgBox(ex.Message)
                Return False

            End Try

        End If

    End Function

    Public Function Baja(ByVal iidEscandallo As Integer) As Boolean
        'Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update Escandallos set   Activo = 0  WHERE idEscandallo = " & iidEscandallo
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)
                con.Open()
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

    Public Function Documentos(ByVal iidArticulo As Integer) As DataTable
        'Devuelve la lista de documentos asociados a la idArticulo
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            cmd = New SqlCommand("SELECT Prod_Documentos.codDocumento, Documentos.*, TiposDocumento.TipoDoc FROM (Prod_Documentos LEFT JOIN Documentos ON Documentos.codDocumento = Prod_Documentos.codDocumento) LEFT JOIN TiposDocumento ON TiposDocumento.IDTipo = Documentos.IdTipo WHERE idArticulo =  '" & iidArticulo, con)

            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                con.Close()
                Return dt
            Else
                con.Close()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function DocExiste(ByVal iidArticulo As Integer, ByVal vcodDocumento As Integer) As Boolean
        ' Indica si existe la relación 
        Try
            'Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = " Select codDocumento FROM Prod_Documentos WHERE (idArticulo = " & iidArticulo & "' AND codDocumento = " & vcodDocumento & ")"

            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteScalar = 0 Then
                con.Close()
                Return False
            Else
                con.Close()
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function BorrarDoc(ByVal iidArticulo As Integer, ByVal vcodDocumento As Integer) As Boolean
        'Borra la relación de la Producto con un documento y si no quedan relaciones, borra el documento de la tabla Documentos
        Try
            Dim resultado As Boolean
            'Dim sconexion As String = CadenaConexion()
            Dim sel As String
            If vcodDocumento = 0 Then
                sel = "delete from Prod_Documentos WHERE idArticulo = " & iidArticulo & "' "
            Else
                sel = "delete from Prod_Documentos WHERE (idArticulo = " & iidArticulo & "' AND codDocumento = " & vcodDocumento & ")"
            End If

            Using con As New SqlConnection(sconexion)

                cmd = New SqlCommand(sel, con)
                'abrir conexion
                con.Open()
                'ejecutar el sql
                Dim t As Integer = CInt(cmd.ExecuteNonQuery())
                con.Close()
                If t = 1 Then
                    resultado = True
                Else
                    resultado = False
                End If

            End Using

            'Si no existen más relaciones de este documento, se borrará de la tabla de documentos

            'Dim func As New FuncionesDocumentos
            'func.borrar(vcodDocumento)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function NuevoDoc(ByVal iidArticulo As Integer, ByVal vcodDocumento As Integer) As Integer
        ' Añadir una entrada a la tabla de relación Prod_Documento si no existia ya
        Try
            If DocExiste(iidArticulo, vcodDocumento) Then
                Return 0
            Else
                'Dim sconexion As String = CadenaConexion()
                Dim con As New SqlConnection(sconexion)
                cmd = New SqlCommand("INSERT INTO Prod_Documentos (codDocumento,idArticulo) Values (@codDocumento, @idArticulo)", con)
                cmd.Parameters.AddWithValue("codDocumento", vcodDocumento)
                cmd.Parameters.AddWithValue("idArticulo", iidArticulo)
                con.Open()
                Return cmd.ExecuteNonQuery
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function EscandallosSubescandallos(ByVal idEscandallo As Integer, ByVal level As Integer) As List(Of DatosEscandallo)

        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "WITH DirectReports (Familia, subfamilia, CodigoEscandallo, idescandallo, idarticulo, concepto, cantidad, observaciones_CE , fechaAlta, observaciones_ES,"
            sel = sel & " precio, seccion, simbolo, cambio, TipoUnidad, idSubArticulo,  Level) AS ( "
            sel = sel & " SELECT FA.Familia, SFA.SubFamilia , ES.codEscandallo, CE.idescandallo, CE.idarticulo, AR.articulo, CE.cantidad, CE.Observaciones, ES.FechaAlta, ES.Observaciones,"
            sel = sel & " AP.Precio, SEC.Seccion, MO.Simbolo, MO.CAMBIO, TU.TipoUnidad, 0 AS 'idSubArticulo',"
            sel = sel & " 0 AS Level"
            sel = sel & " FROM ConceptosEscandallos AS CE"
            sel = sel & " INNER JOIN Escandallos as ES on ES.idEscandallo = CE.idEscandallo "
            sel = sel & " INNER JOIN Articulos as AR on AR.idArticulo = CE.idArticulo "
            sel = sel & " INNER JOIN Familias as FA on FA.idFamilia = (case when AR.idFamilia = ''  then 15 else AR.idFamilia end) "
            sel = sel & " INNER JOIN SubFamilias as SFA on SFA . idSubFamilia = (case when AR.idsubFamilia  = ''  then 105 else AR.idsubFamilia end)"
            sel = sel & " INNER JOIN Secciones as SEC ON SEC.idseccion = case when CE.idSeccion  = 0 then 14 else CE.idSeccion end "
            sel = sel & " INNER JOIN  Articulos_Precios as AP on AP.idArticulo = CE.idArticulo and AP.Activo=1 and AP.TipoPrecio='C' "
            sel = sel & " INNER JOIN monedas as MO ON MO.codMoneda = AP.codMoneda "
            sel = sel & " INNER JOIN TiposUnidad as TU ON TU.idTipoUnidad = case when CE.idTipoUnidad = 0 then 1 else CE.idTipoUnidad end "
            sel = sel & " WHERE(CE.idescandallo = " & idEscandallo & " ) "
            sel = sel & " UNION ALL"
            sel = sel & " SELECT FA.Familia, SFA.SubFamilia, ES.codEscandallo, CE.idescandallo, CE.idarticulo , AR.articulo, CE.cantidad, CE.Observaciones, ES.FechaAlta, ES.Observaciones, "
            sel = sel & " AP.Precio, SEC.Seccion,MO.Simbolo, MO.CAMBIO, TU.TipoUnidad, ES.idArticulo as 'idSubArticulo', "
            sel = sel & " level +1"
            sel = sel & " FROM ConceptosEscandallos AS CE"
            sel = sel & " INNER JOIN Escandallos as ES on ES.idEscandallo = CE.idEscandallo"
            sel = sel & " INNER JOIN Articulos as AR on AR.idArticulo = CE.idArticulo "
            sel = sel & " INNER JOIN Familias as FA on FA.idFamilia = (case when AR.idFamilia = ''  then 15 else AR.idFamilia end) "
            sel = sel & " INNER JOIN SubFamilias as SFA on SFA . idSubFamilia = (case when AR.idsubFamilia  = ''  then 105 else AR.idsubFamilia end) "
            sel = sel & " INNER JOIN Secciones as SEC ON SEC.idseccion = case when CE.idSeccion  = 0 then 14 else CE.idSeccion end "
            sel = sel & " INNER JOIN  Articulos_Precios as AP on AP.idArticulo = CE.idArticulo and AP.Activo=1 and AP.TipoPrecio='C' "
            sel = sel & " INNER JOIN monedas as MO ON MO.codMoneda = AP.codMoneda "
            sel = sel & " INNER JOIN TiposUnidad as TU ON TU.idTipoUnidad = case when CE.idTipoUnidad = 0 then 1 else CE.idTipoUnidad end"
            sel = sel & " INNER JOIN DirectReports AS DR ON (select idEscandallo  from Escandallos where idArticulo = DR.idArticulo and Activo = 1) = CE.idescandallo)"
            sel = sel & " SELECT distinct Familia, subfamilia, CodigoEscandallo, idescandallo, idarticulo , concepto, cantidad, observaciones_CE , fechaAlta, observaciones_ES, "
            sel = sel & " precio, seccion, simbolo, cambio, TipoUnidad, idSubArticulo, level"
            sel = sel & " FROM DirectReports where level = " & level
            sel = sel & " order by concepto asc "
            Dim lista As New List(Of DatosEscandallo)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        lista.Add(CargarLineaSubEscandallos(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception

            MsgBox("Existen varias versiones de escandallo activas.", MsgBoxStyle.Information)

            Return Nothing

        End Try

    End Function

    Private Function CargarLineaSubEscandallos(ByVal linea As DataRow) As DatosEscandallo
        Dim dts As New DatosEscandallo
        Dim iidEscandallo As Integer = linea("idEscandallo")
        dts.gidEscandallo = iidEscandallo
        dts.gArticulo = If(linea("Concepto") Is DBNull.Value, "", linea("Concepto"))
        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, "0", linea("Cantidad"))
        dts.gidArticulo = If(linea("idarticulo") Is DBNull.Value, "", linea("idarticulo"))
        dts.gcodArticulo = If(linea("idSubArticulo") Is DBNull.Value, "", linea("idSubArticulo"))
        dts.gLevel = If(linea("level") Is DBNull.Value, "", linea("level"))
        dts.gseccion = If(linea("seccion") Is DBNull.Value, "", linea("seccion"))
        dts.gCoste = If(linea("precio") Is DBNull.Value, "0", linea("precio"))
        dts.gFamilia = If(linea("familia") Is DBNull.Value, "", linea("familia"))
        dts.gSubfamilia = If(linea("subfamilia") Is DBNull.Value, "", linea("subfamilia"))
        dts.gSimbolo = If(linea("simbolo") Is DBNull.Value, "", linea("simbolo"))
        dts.gTipoUnidad = If(linea("tipounidad") Is DBNull.Value, "", linea("tipounidad"))
        Return dts
    End Function

#Region "calculo de precios"

    Public Function calcularPrecioTotal(ByVal idArticulo As Integer, ByVal level As Integer) As List(Of DatosEscandallo)

        Try
            Dim con As New SqlConnection(sconexion)
            Dim sel As String = "WITH DirectReports ( idescandallo, idarticulo, cantidad, precio, idSubArticulo, Level) AS ( "
            sel = sel & " SELECT CE.idescandallo, CE.idarticulo, CE.cantidad, AP.Precio, 0 AS 'idSubArticulo', 0 AS Level"
            sel = sel & " FROM ConceptosEscandallos AS CE"
            sel = sel & " INNER JOIN Escandallos as ES on ES.idEscandallo = CE.idEscandallo "
            sel = sel & " INNER JOIN Articulos as AR on AR.idArticulo = CE.idArticulo "
            sel = sel & " INNER JOIN  Articulos_Precios as AP on AP.idArticulo = CE.idArticulo and AP.Activo=1 and AP.TipoPrecio='C' "
            sel = sel & " WHERE(CE.idescandallo = (select idEscandallo from escandallos where idArticulo = " & idArticulo & " and Activo = 1)) "
            sel = sel & " UNION ALL"
            sel = sel & " SELECT CE.idescandallo, CE.idarticulo , CE.cantidad, AP.Precio, ES.idArticulo as 'idSubArticulo', level +1"
            sel = sel & " FROM ConceptosEscandallos AS CE"
            sel = sel & " INNER JOIN Escandallos as ES on ES.idEscandallo = CE.idEscandallo"
            sel = sel & " INNER JOIN Articulos as AR on AR.idArticulo = CE.idArticulo "
            sel = sel & " INNER JOIN  Articulos_Precios as AP on AP.idArticulo = CE.idArticulo and AP.Activo=1 and AP.TipoPrecio='C' "
            sel = sel & " INNER JOIN DirectReports AS DR ON (select idEscandallo  from Escandallos where idArticulo = DR.idArticulo and Activo = 1) = CE.idescandallo)"
            sel = sel & " SELECT distinct  idescandallo, idarticulo, cantidad,  precio, idSubArticulo, level"
            sel = sel & " FROM DirectReports where level = " & level
            Dim lista As New List(Of DatosEscandallo)
            cmd = New SqlCommand(sel, con)
            con.Open()
            If cmd.ExecuteNonQuery Then
                con.Close()
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim linea As DataRow
                For Each linea In dt.Rows
                    If linea("idEscandallo") Is DBNull.Value Then
                    Else
                        lista.Add(CargarlineaPrecioTotal(linea))
                    End If
                Next
            Else
                con.Close()
            End If
            Return lista

        Catch ex As Exception

            MsgBox("Existen varias versiones de escandallo activas.", MsgBoxStyle.Information)

            Return Nothing

        End Try

    End Function

    Private Function CargarlineaPrecioTotal(ByVal linea As DataRow) As DatosEscandallo
        Try

            Dim dts As New DatosEscandallo
            dts.gidEscandallo = linea("idEscandallo")
            dts.gidArticulo = If(linea("idarticulo") Is DBNull.Value, "", linea("idarticulo"))
            dts.gcodArticulo = If(linea("idSubArticulo") Is DBNull.Value, "", linea("idSubArticulo"))
            dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, "0", linea("Cantidad"))
            dts.gCoste = If(linea("precio") Is DBNull.Value, "0", linea("precio"))
            dts.gLevel = If(linea("level") Is DBNull.Value, "", linea("level"))

            Return dts
        Catch ex As Exception
            MsgBox(ex.Message)

            Return Nothing
        End Try

    End Function


#End Region


End Class
