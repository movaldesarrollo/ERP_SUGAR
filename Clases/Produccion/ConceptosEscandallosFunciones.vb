Imports System.Data.SqlClient

Imports System.Data.Sql

Public Class FuncionesConceptosEscandallos

    Inherits conexion

    Dim cmd As SqlCommand

    Private funcAP As New FuncionesArticuloPrecio

    'Mostrar ID Escandallo
    Public Function Mostrar(ByVal idEscandallo As Integer, ByVal SoloActivos As Boolean, ByVal iidArticuloBase As Integer) As List(Of DatosConceptoEscandallo)
        Try
            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT  CE.*, Articulo, codArticulo, ArticuloEN, AR.Descripcion,DescripcionEN, Composicion, codEscandallo, Escandallos.Escandallo, AR.idFamilia, AR.idsubFamilia, Familia, subFamilia, Seccion, TipoUnidad, "
            sel = sel & " (SELECT max(idEscandallo) FROM Escandallos WHERE  Activo = 1 and idArticulo = CE.idArticulo) as ExisteEscandallo "
            sel = sel & "FROM ConceptosEscandallos  as CE LEFT JOIN Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
            sel = sel & " Left Join TiposEscandallo ON TiposEscandallo.idTipoEscandallo = Escandallos.idTipoEscandallo "
            sel = sel & " Left join TiposUnidad ON TiposUnidad.idTipoUnidad = CE.idTipoUnidad "
            sel = sel & " LEFT JOIN Secciones ON Secciones.idSeccion = CE.idSeccion "
            sel = sel & " Left join Articulos as AR ON AR.idArticulo = CE.idArticulo "
            sel = sel & " LEFT JOIN Familias ON Familias.idFamilia = AR.idFamilia "
            sel = sel & " Left outer join subFamilias ON SubFamilias.idsubFamilia = AR.idsubFamilia "
            sel = sel & " WHERE CE.idEscandallo = " & idEscandallo & If(SoloActivos, " AND CE.Activo = 1 ", "") & If(iidArticuloBase = 0, "", " AND CE.idArticulo <> " & iidArticuloBase)
            sel = sel & " Order By Orden ASC"

            cmd = New SqlCommand(sel, con)

            Dim lista As New List(Of DatosConceptoEscandallo)

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim dts As DatosConceptoEscandallo

                Dim dtsAP As DatosArticuloPrecio

                Dim Composicion As Boolean

                Dim linea As DataRow

                For Each linea In dt.Rows

                    If linea("idConcepto") Is DBNull.Value Then


                    Else

                        dts = New DatosConceptoEscandallo

                        dts.gidConcepto = linea("idConcepto")

                        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))

                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))

                        dts.gcodConcepto = If(linea("codConcepto") Is DBNull.Value, "", linea("codConcepto"))

                        dts.gConcepto = If(linea("Concepto") Is DBNull.Value, "", linea("Concepto"))

                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))

                        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))

                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))

                        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

                        dts.gidTipoUnidad = If(linea("idTipoUnidad") Is DBNull.Value, 0, linea("idTipoUnidad"))

                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))

                        dts.gcodEscandallo = If(linea("codEscandallo") Is DBNull.Value, "", linea("codEscandallo"))

                        dts.gEscandallo = If(linea("Escandallo") Is DBNull.Value, "", linea("Escandallo"))

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))

                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))

                        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))

                        dts.gsubFamilia = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))

                        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))

                        dts.gidsubFamilia = If(linea("idsubFamilia") Is DBNull.Value, 0, linea("idsubFamilia"))

                        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))

                        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))

                        dts.gExisteEscandallo = If(linea("ExisteEscandallo") Is DBNull.Value, 0, linea("ExisteEscandallo"))

                        dts.gArticuloEN = If(linea("ArticuloEN") Is DBNull.Value, "", linea("ArticuloEN"))

                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

                        dts.gDescripcionEN = If(linea("DescripcionEN") Is DBNull.Value, "", linea("DescripcionEN"))

                        'If Composicion Then

                        '    If funcAP.Precio0(dts.gidArticulo, "O") Then 'Si no hay un precio espcífico de opción, tomamos el precio de venta.

                        '        dtsAP = funcAP.Precio(dts.gidArticulo, "O")

                        '    Else

                        '        dtsAP = funcAP.Precio(dts.gidArticulo, "V")

                        '    End If

                        '    dts.gPrecioOpcion = dtsAP.gPrecio

                        '    dts.gCodMonedaV = dtsAP.gcodMoneda

                        '    dts.gSimboloV = dtsAP.gSimbolo

                        'Else



                        'End If

                        dtsAP = funcAP.Precio(dts.gidArticulo, "C")

                        dts.gPrecioOpcion = 0

                        dts.gCodMonedaV = dts.gcodMoneda

                        dts.gsimbolo = dts.gsimbolo


                        dts.gCoste = dtsAP.gPrecio

                        dts.gcodMoneda = dtsAP.gcodMoneda

                        dts.gsimbolo = dtsAP.gSimbolo

                        dts.gFechaCoste = dtsAP.gFechaPrecio

                        Composicion = If(linea("Composicion") Is DBNull.Value, False, linea("Composicion"))



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


    'Public Function Mostrar(ByVal idEscandallo As Integer, ByVal SoloActivos As Boolean, ByVal iidArticuloBase As Integer) As List(Of DatosConceptoEscandallo)
    '    Try
    '        Dim sconexion As String = CadenaConexion()

    '        Dim con As New SqlConnection(sconexion)

    '        Dim sel As String

    '        sel = "SELECT  CE.*, Articulo, codArticulo, ArticuloEN, AR.Descripcion,DescripcionEN, Composicion, codEscandallo, Escandallos.Escandallo, AR.idFamilia, AR.idsubFamilia, Familia, subFamilia, Seccion, TipoUnidad, "
    '        sel = sel & " (SELECT max(idEscandallo) FROM Escandallos WHERE  Activo = 1 and idArticulo = CE.idArticulo) as ExisteEscandallo "
    '        sel = sel & "FROM ConceptosEscandallos  as CE LEFT JOIN Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
    '        sel = sel & " Left Join TiposEscandallo ON TiposEscandallo.idTipoEscandallo = Escandallos.idTipoEscandallo "
    '        sel = sel & " Left join TiposUnidad ON TiposUnidad.idTipoUnidad = CE.idTipoUnidad "
    '        sel = sel & " LEFT JOIN Secciones ON Secciones.idSeccion = CE.idSeccion "
    '        sel = sel & " Left join Articulos as AR ON AR.idArticulo = CE.idArticulo "
    '        sel = sel & " LEFT JOIN Familias ON Familias.idFamilia = AR.idFamilia "
    '        sel = sel & " Left outer join subFamilias ON SubFamilias.idsubFamilia = AR.idsubFamilia "
    '        sel = sel & " WHERE CE.idEscandallo = " & idEscandallo & If(SoloActivos, " AND CE.Activo = 1 ", "") & If(iidArticuloBase = 0, "", " AND CE.idArticulo <> " & iidArticuloBase)
    '        sel = sel & " Order By Orden ASC"

    '        cmd = New SqlCommand(sel, con)

    '        Dim lista As New List(Of DatosConceptoEscandallo)

    '        con.Open()

    '        If cmd.ExecuteNonQuery Then

    '            con.Close()

    '            Dim dt As New DataTable

    '            Dim da As New SqlDataAdapter(cmd)

    '            da.Fill(dt)

    '            Dim dts As DatosConceptoEscandallo

    '            Dim dtsAP As DatosArticuloPrecio

    '            Dim Composicion As Boolean

    '            Dim linea As DataRow

    '            For Each linea In dt.Rows

    '                If linea("idConcepto") Is DBNull.Value Then


    '                Else

    '                    dts = New DatosConceptoEscandallo

    '                    dts.gidConcepto = linea("idConcepto")

    '                    dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))

    '                    dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))

    '                    dts.gcodConcepto = If(linea("codConcepto") Is DBNull.Value, "", linea("codConcepto"))

    '                    dts.gConcepto = If(linea("Concepto") Is DBNull.Value, "", linea("Concepto"))

    '                    dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))

    '                    dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))

    '                    dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))

    '                    dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

    '                    dts.gidTipoUnidad = If(linea("idTipoUnidad") Is DBNull.Value, 0, linea("idTipoUnidad"))

    '                    dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))

    '                    dts.gcodEscandallo = If(linea("codEscandallo") Is DBNull.Value, "", linea("codEscandallo"))

    '                    dts.gEscandallo = If(linea("Escandallo") Is DBNull.Value, "", linea("Escandallo"))

    '                    dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))

    '                    dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))

    '                    dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))

    '                    dts.gsubFamilia = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))

    '                    dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))

    '                    dts.gidsubFamilia = If(linea("idsubFamilia") Is DBNull.Value, 0, linea("idsubFamilia"))

    '                    dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))

    '                    dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))

    '                    dts.gExisteEscandallo = If(linea("ExisteEscandallo") Is DBNull.Value, 0, linea("ExisteEscandallo"))

    '                    dts.gArticuloEN = If(linea("ArticuloEN") Is DBNull.Value, "", linea("ArticuloEN"))

    '                    dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

    '                    dts.gDescripcionEN = If(linea("DescripcionEN") Is DBNull.Value, "", linea("DescripcionEN"))

    '                    dtsAP = funcAP.Precio(dts.gidArticulo, "C")

    '                    dts.gCoste = dtsAP.gPrecio

    '                    dts.gcodMoneda = dtsAP.gcodMoneda

    '                    dts.gsimbolo = dtsAP.gSimbolo

    '                    dts.gFechaCoste = dtsAP.gFechaPrecio

    '                    Composicion = If(linea("Composicion") Is DBNull.Value, False, linea("Composicion"))

    '                    If Composicion Then

    '                        dtsAP = funcAP.Precio(dts.gidArticulo, "O")

    '                        dts.gPrecioOpcion = dtsAP.gPrecio

    '                        dts.gCodMonedaV = dtsAP.gcodMoneda

    '                        dts.gSimboloV = dtsAP.gSimbolo

    '                        If dtsAP.gPrecio = 0 Then 'Si no hay un precio espcífico de opción, tomamos el precio de venta.

    '                            dtsAP = funcAP.Precio(dts.gidArticulo, "V")

    '                            dts.gPrecioOpcion = dtsAP.gPrecio

    '                            dts.gCodMonedaV = dtsAP.gcodMoneda

    '                            dts.gSimboloV = dtsAP.gSimbolo

    '                        End If

    '                    Else

    '                        dts.gPrecioOpcion = 0

    '                        dts.gCodMonedaV = dts.gcodMoneda

    '                        dts.gsimbolo = dts.gsimbolo

    '                    End If

    '                    lista.Add(dts)

    '                End If

    '            Next

    '        Else

    '            con.Close()

    '        End If

    '        Return lista

    '    Catch ex As Exception

    '        MsgBox(ex.Message)

    '        Return Nothing

    '    End Try

    'End Function

    Public Function Mostrar1(ByVal iidConcepto As Integer) As DatosConceptoEscandallo

        'Devuelve el registro del Producto con idArticulo, todos los registros si el parámetro es ""
        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            Dim sel As String

            sel = "SELECT  CE.*, Articulo, codArticulo, ArticuloEN, AR.Descripcion,DescripcionEN, Composicion, codEscandallo, Escandallos.Escandallo, AR.idFamilia, AR.idsubFamilia, Familia, subFamilia, Seccion, TipoUnidad, "
            sel = sel & " (SELECT max(idEscandallo) FROM Escandallos WHERE  Activo = 1 and idArticulo = CE.idArticulo) as ExisteEscandallo "
            sel = sel & "FROM ConceptosEscandallos  as CE LEFT JOIN Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
            sel = sel & " Left Join TiposEscandallo ON TiposEscandallo.idTipoEscandallo = Escandallos.idTipoEscandallo "
            sel = sel & " Left join TiposUnidad ON TiposUnidad.idTipoUnidad = CE.idTipoUnidad "
            sel = sel & " LEFT JOIN Secciones ON Secciones.idSeccion = CE.idSeccion "
            sel = sel & " Left join Articulos as AR ON AR.idArticulo = CE.idArticulo "
            sel = sel & " LEFT JOIN Familias ON Familias.idFamilia = AR.idFamilia "
            sel = sel & " Left outer join subFamilias ON SubFamilias.idsubFamilia = AR.idsubFamilia "
            sel = sel & " WHERE idConcepto = " & iidConcepto

            cmd = New SqlCommand(sel, con)

            Dim dts As New DatosConceptoEscandallo

            Dim dtsAP As DatosArticuloPrecio

            con.Open()

            If cmd.ExecuteNonQuery Then

                con.Close()

                Dim dt As New DataTable

                Dim da As New SqlDataAdapter(cmd)

                da.Fill(dt)

                Dim linea As DataRow

                Dim composicion As Boolean

                For Each linea In dt.Rows

                    If linea("idConcepto") Is DBNull.Value Then

                    Else

                        dts.gidConcepto = linea("idConcepto")

                        dts.gidEscandallo = If(linea("idEscandallo") Is DBNull.Value, 0, linea("idEscandallo"))

                        dts.gidArticulo = If(linea("idArticulo") Is DBNull.Value, 0, linea("idArticulo"))

                        dts.gcodConcepto = If(linea("codConcepto") Is DBNull.Value, "", linea("codConcepto"))

                        dts.gConcepto = If(linea("Concepto") Is DBNull.Value, "", linea("Concepto"))

                        dts.gCantidad = If(linea("Cantidad") Is DBNull.Value, 0, linea("Cantidad"))

                        dts.gidSeccion = If(linea("idSeccion") Is DBNull.Value, 0, linea("idSeccion"))

                        dts.gObservaciones = If(linea("Observaciones") Is DBNull.Value, "", linea("Observaciones"))

                        dts.gOrden = If(linea("Orden") Is DBNull.Value, 0, linea("Orden"))

                        dts.gidTipoUnidad = If(linea("idTipoUnidad") Is DBNull.Value, 0, linea("idTipoUnidad"))

                        dts.gActivo = If(linea("Activo") Is DBNull.Value, True, linea("Activo"))

                        dts.gcodEscandallo = If(linea("codEscandallo") Is DBNull.Value, "", linea("codEscandallo"))

                        dts.gEscandallo = If(linea("Escandallo") Is DBNull.Value, "", linea("Escandallo"))

                        dts.gcodArticulo = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))

                        dts.gArticulo = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))

                        dts.gFamilia = If(linea("Familia") Is DBNull.Value, "", linea("Familia"))

                        dts.gsubFamilia = If(linea("subFamilia") Is DBNull.Value, "", linea("subFamilia"))

                        dts.gidFamilia = If(linea("idFamilia") Is DBNull.Value, 0, linea("idFamilia"))

                        dts.gidsubFamilia = If(linea("idsubFamilia") Is DBNull.Value, 0, linea("idsubFamilia"))

                        dts.gSeccion = If(linea("Seccion") Is DBNull.Value, "", linea("Seccion"))

                        dts.gTipoUnidad = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))

                        dts.gExisteEscandallo = If(linea("ExisteEscandallo") Is DBNull.Value, 0, linea("ExisteEscandallo"))

                        dts.gArticuloEN = If(linea("ArticuloEN") Is DBNull.Value, "", linea("ArticuloEN"))

                        dts.gDescripcion = If(linea("Descripcion") Is DBNull.Value, "", linea("Descripcion"))

                        dts.gDescripcionEN = If(linea("DescripcionEN") Is DBNull.Value, "", linea("DescripcionEN"))

                        dtsAP = funcAP.Precio(dts.gidArticulo, "C")

                        dts.gCoste = dtsAP.gPrecio

                        dts.gcodMoneda = dtsAP.gcodMoneda

                        dts.gsimbolo = dtsAP.gSimbolo

                        dts.gFechaCoste = dtsAP.gFechaPrecio

                        composicion = If(linea("Composicion") Is DBNull.Value, False, linea("Composicion"))

                        If composicion Then

                            dtsAP = funcAP.Precio(dts.gidArticulo, "O")

                            dts.gPrecioOpcion = dtsAP.gPrecio

                            dts.gCodMonedaV = dtsAP.gcodMoneda

                            dts.gSimboloV = dtsAP.gSimbolo

                            If dtsAP.gPrecio = 0 Then 'Si no hay un precio espcífico de opción, tomamos el precio de venta.

                                dtsAP = funcAP.Precio(dts.gidArticulo, "V")

                                dts.gPrecioOpcion = dtsAP.gPrecio

                                dts.gCodMonedaV = dtsAP.gcodMoneda

                                dts.gSimboloV = dtsAP.gSimbolo

                            End If

                        Else

                            dts.gPrecioOpcion = 0

                            dts.gCodMonedaV = dts.gcodMoneda

                            dts.gsimbolo = dts.gsimbolo

                        End If

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

    'Busca si pertenece a escandallos.
    Public Function PerteneceEscandallo(ByVal iidEscandallo As Integer) As Boolean

        Try

            Dim sconexion As String = CadenaConexion()

            Dim con As New SqlConnection(sconexion)

            If iidEscandallo <> 0 Then

                Dim sel As String = " SELECT count(*) FROM ConceptosEscandallos WHERE  idEscandallo = " & iidEscandallo

                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim i As Integer = cmd.ExecuteScalar

                con.Close()

                If i = 0 Then

                    Return True

                Else

                    Return False

                End If

            Else

                Return False

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

    End Function




    Public Function Contador(ByVal busqueda As String) As Integer
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)
            If busqueda = "" Then
                cmd = New SqlCommand("SELECT COUNT(*) FROM ConceptosEscandallos", con)
            Else

                cmd = New SqlCommand(" SELECT COUNT(*) FROM ConceptosEscandallos WHERE  " & busqueda, con)

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

    Public Function VistaTaller(ByVal iidArticulo As Integer) As Boolean
        'Nos dice si un artículo tiene en su desglose de material secciones de la vista taller
        Try
            Dim sconexion As String = CadenaConexion()
            Dim con As New SqlConnection(sconexion)

            Dim sel As String = "Select count(idConcepto) from ConceptosEscandallos as CE left join Escandallos ON Escandallos.idEscandallo = CE.idEscandallo "
            sel = sel & " left join Secciones ON CE.idSeccion = Secciones.idSeccion where Vista = 'TALLER' AND Escandallos.idArticulo = " & iidArticulo
            cmd = New SqlCommand(sel, con)

            con.Open()
            Dim o As Object = cmd.ExecuteScalar
            con.Close()
            If o Is DBNull.Value Or o Is Nothing Then
                Return False
            Else
                Return CInt(o) > 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function



    Public Function insertar(ByVal dts As DatosConceptoEscandallo) As Integer
        'Insertar un nuevo producto, si no existe ya el código 

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Using con As New SqlConnection(sconexion)
            Try
                sel = "insert into ConceptosEscandallos (idEscandallo, idArticulo, codConcepto, Concepto, Cantidad, idSeccion,  Observaciones, Orden,idTipoUnidad,  Activo, idCreador, Creacion) "
                sel = sel & " values (@idEscandallo, @idArticulo, @codConcepto, @Concepto, @Cantidad, @idSeccion,  @Observaciones, @Orden, @idTipoUnidad, @Activo, @idCreador, @Creacion) Select @@Identity "

                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("codConcepto", dts.gcodConcepto)
                cmd.Parameters.AddWithValue("Concepto", dts.gConcepto)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idTipoUnidad", dts.gidTipoUnidad)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idCreador", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Creacion", Now)
                con.Open()
                Dim t As Integer = cmd.ExecuteScalar()
                con.Close()
                Return t
            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally
                desconectado()
            End Try
        End Using
    End Function



    Public Function actualizar(ByVal dts As DatosConceptoEscandallo) As Boolean
        'Actualiza un registro de la tabla Articulos dado un idArticulo

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ConceptosEscandallos set idEscandallo = @idEscandallo, idArticulo = @idArticulo, codConcepto = @codConcepto,  Concepto = @Concepto, Cantidad = @Cantidad,"
        sel = sel & "   idSeccion = @idSeccion, Observaciones = @Observaciones, Orden = @Orden, idTipoUnidad = @idTipoUnidad, Activo = @Activo, idModifica = @idModifica, Modificacion = @Modificacion "
        sel = sel & " WHERE idConcepto = @idConcepto "

        Using con As New SqlConnection(sconexion)
            Try
                dts.gcodConcepto = ""
                cmd = New SqlCommand(sel, con)
                cmd.Parameters.AddWithValue("idConcepto", dts.gidConcepto)
                cmd.Parameters.AddWithValue("idEscandallo", dts.gidEscandallo)
                cmd.Parameters.AddWithValue("idArticulo", dts.gidArticulo)
                cmd.Parameters.AddWithValue("codConcepto", dts.gcodConcepto)
                cmd.Parameters.AddWithValue("Concepto", dts.gConcepto)
                cmd.Parameters.AddWithValue("Cantidad", dts.gCantidad)
                cmd.Parameters.AddWithValue("idSeccion", dts.gidSeccion)
                cmd.Parameters.AddWithValue("Observaciones", dts.gObservaciones)
                cmd.Parameters.AddWithValue("Orden", dts.gOrden)
                cmd.Parameters.AddWithValue("idTipoUnidad", dts.gidTipoUnidad)
                cmd.Parameters.AddWithValue("Activo", dts.gActivo)
                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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

    Public Function busquedaSeccion(ByVal seccion As String) As Integer

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "Select idseccion from secciones where seccion = '" & seccion & "'"

        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                con.Open()

                Dim t As Integer = CInt(cmd.ExecuteScalar())

                con.Close()

                Return t

            Catch ex As Exception
                MsgBox("Error al registrar seccion" & ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try

        End Using

    End Function

    Public Function CambiarCantidad(ByVal iidEscandallo As Integer, ByVal iidArticulo As Integer, ByVal Diferencia As Double) As Boolean
        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        sel = "update ConceptosEscandallos set  Cantidad = Cantidad + @Diferencia, idModifica = @idModifica, Modificacion = @Modificacion  WHERE idArticulo = @idArticulo AND idEscandallo = @idEscandallo "
        Using con As New SqlConnection(sconexion)
            Try
                cmd = New SqlCommand(sel, con)

                cmd.Parameters.AddWithValue("idEscandallo", iidEscandallo)
                cmd.Parameters.AddWithValue("idArticulo", iidArticulo)
                cmd.Parameters.AddWithValue("Diferencia", Diferencia)

                cmd.Parameters.AddWithValue("idModifica", Inicio.vIdUsuario)
                cmd.Parameters.AddWithValue("Modificacion", Now)
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



    Public Function BorrarComponente(ByVal iidEscandallo As Integer, ByVal iidArticulo As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean
            Using con As New SqlConnection(sconexion)

                sel = "delete from ConceptosEscandallos where idEscandallo = " & iidEscandallo & " AND idArticulo = " & iidArticulo
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

    End Function




    Public Function Borrar(ByVal iidConcepto As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from ConceptosEscandallos where idConcepto = " & iidConcepto
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

    End Function


    Public Function BorrarEscandallo(ByVal iidEscandallo As Integer) As Boolean

        Dim sconexion As String = CadenaConexion()
        Dim sel As String
        Try
            Dim Resultado As Boolean

            'Después la cabecera
            Using con As New SqlConnection(sconexion)

                sel = "delete from ConceptosEscandallos where idEscandallo = " & iidEscandallo
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

    End Function





End Class
