'Formulario para imprimir etiquetas de equipos.
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports Microsoft.Office.Interop

Public Class funcionesCodigosBarras

#Region "VARIABLES"

    Inherits conexion

    Dim cmd As SqlCommand

    Dim da As SqlDataAdapter

    Dim sel As String

    Public imagenLogo As Image

    Public imagen As Image

    Public idImagen As Integer

    Dim iTotalImagenes As Integer = 0

    Public numeroCajas As Integer

    Public numeroCelulas As Integer

#End Region

#Region "PROPIEDADES"

    Property pImage() As Image

        Get

            Return imagen

        End Get

        Set(value As Image)

            imagen = value

        End Set

    End Property

    Property pIdImage() As Integer

        Get

            Return idImagen

        End Get

        Set(value As Integer)

            idImagen = value

        End Set

    End Property

    Property pTotalImagenes() As Integer

        Get

            Return iTotalImagenes

        End Get

        Set(value As Integer)

            iTotalImagenes = value

        End Set

    End Property

#End Region

#Region "CELULAS"

    'Inserta las imagenes temporales Celulas.
    Public Function guardarImagenesCelulas(ByVal imagen As Image, ByVal texto As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into imgTempCel (imagen, texto) values (@imagen, @texto)"

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image)

            cmd.Parameters.AddWithValue("@texto", texto)

            Dim MS = New System.IO.MemoryStream()

            imagen.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)

            cmd.Parameters("@imagen").Value = MS.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL CREAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    Public Function guardarImagenesCelulasCable(ByVal imagen As Image, ByVal texto As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into imgTempCelCable (imagen, texto) values (@imagen, @texto)"

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image)

            cmd.Parameters.AddWithValue("@texto", texto)

            Dim MS = New System.IO.MemoryStream()

            imagen.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)

            cmd.Parameters("@imagen").Value = MS.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL CREAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Borra las imagenes temporales Celulas.
    Public Function borrarImagenesCelulas()

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete imgTempCel"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL BORRAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    Public Function borrarImagenesCelulasCable()

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete imgTempCelCable"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL BORRAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Buscar codigos celulas
    Public Sub buscarCelulas(ByVal combo As ComboBox)

        Try
            Dim con As New SqlConnection(CadenaConexion())

            sel = "select idArticulo as IDARTICULO ,  codArticulo + ' - ' + Articulo  as ARTICULO   from articulos where idSubtipoArticulo = 43"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            combo.DataSource = dt

            combo.DisplayMember = "ARTICULO"

            combo.ValueMember = "IDARTICULO"

            combo.SelectedIndex = -1

            combo.Text = "SELECCIONE UNA CÉLULA."

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Friend Function recuperarReferencia(numSerie As String) As String
        Dim result As String = ""
        Dim con As New SqlConnection(CadenaConexion)
        Try
            If (numSerie.Substring(0, 2).Equals("EI")) Then
                sel = "select codarticulo from articulos where idarticulo =  (SELECT idarticulo from EquiposIndustriales where equIndnumserie = '" & numSerie & "')"

            Else
                sel = "select codarticulo from articulos where idarticulo =  (SELECT idarticulo from equipos where equnumserie = '" & numSerie & "')"

            End If

            cmd = New SqlCommand(sel, con)

            con.Open()

            result = cmd.ExecuteScalar()

            con.Close()

            Return result
        Catch ex As Exception
            con.Close()

            MsgBox(ex.Message)
        End Try
        Return result
    End Function

    'Buscar celulas
    Public Function llenarLvCelulas(ByVal lv As ListView, ByVal fecha As Date, Optional ByVal id As Integer = 0) As Boolean

        Try

            Dim con As New SqlConnection(CadenaConexion())

            Dim sID As String = ""

            If id <> 0 Then

                sID = " and CEL.idArticulo = " & id

            End If

            sel = "select CEL.*, codArticulo + ' - ' + articulo as ARTICULO from celulas as CEL left join articulos as ART on ART.idArticulo = CEL.idArticulo              
            where convert (date, CEL.fechaFabricacion) = convert (date, getdate()) " & sID & "  order by CEL.idCelula desc"

            'sel = "select CEL.*, codArticulo + ' - ' + articulo as ARTICULO from celulas as CEL left join articulos as ART on ART.idArticulo = CEL.idArticulo              
            'where convert (date, CEL.fechaFabricacion) = convert (date, getdate()-2) " & sID & "  order by CEL.idCelula desc"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                For Each rows In dt.Rows

                    With lv.Items.Add(rows("idCelula")) '0

                        .subItems.Add(rows("celNumSerie")) '1
                        .subItems.Add(rows("ARTICULO")) '2
                        .subItems.Add(rows("fechaFabricacion")) '3
                        .subItems.Add(rows("idArticulo")) '4
                        .subItems.Add(rows("numserie")) '5

                        'Está asignado a un pedido.
                        If rows("numserie") <> 0 Then

                            .forecolor = Color.White
                            .backColor = Color.Green

                        End If

                    End With

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        Return True

    End Function

    'Insertar celulas
    Public Function insertarCelula(ByVal codigo As String, ByVal idArticulo As Integer)

        insertarCelula = False

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "INSERT INTO celulas (numserie ,idArticulo ,fechaFabricacion ,idCreador ,celNumSerie)
     VALUES (0 ," & idArticulo & " ,'" & Now & "' ," & Inicio.vIdUsuario & " ,'" & "CD" & codigo & "')"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            insertarCelula = True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

    End Function

    Friend Function recuperarMonoSku(iNumserie As Integer) As String
        Dim result As String
        Dim con As New SqlConnection(CadenaConexion())


        sel = "declare @numSerie varchar(max); set @numSerie = '" & iNumserie & "'
select EES.monosku
 from ConceptosPedidos CP
left join Pedidos PE on PE.numPedido = CP.numPedido
left join Clientes CLI on CLI.idCliente  = PE.idcliente
left join Articulos ART on ART.idArticulo = CP.idArticulo
left join [DB_Escandallos].dbo.Articulos EART on EART.Referencia  = ART.codArticulo
left join [DB_Escandallos].dbo.Escandallos  EES on EES.IdArticulo = EART.IdArticulo
where idConcepto = (select idConceptoPedido from ConceptosProduccion
where idproduccion = (select idProduccion from EquiposProduccion where numSerie = @numSerie))"
        Dim cmd As New SqlCommand(sel, con)
        Try
            con.Open()
            result = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
        Return result
    End Function

    'Existe Codigo celula
    Public Function existeCodigoCelula(ByVal codigo As String, Optional ByVal whereNumSerie As String = "") As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from celulas where celNumSerie = '" & codigo & "' " & whereNumSerie

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Si el Codigo celula se ha impreso.
    Public Function codigoImpresoCelula(ByVal codigo As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim numeracion As Integer

            codigo = Replace(codigo, "CD", "")

            If codigo.Length = 9 Then

                If IsNumeric(codigo) Then

                    numeracion = codigo.Substring(0, 4)

                    Dim i As Integer

                    sel = "select celNumSerie from master where numeracion = '" & numeracion & "'"

                    cmd = New SqlCommand(sel, con)

                    con.Open()

                    i = cmd.ExecuteScalar()

                    con.Close()

                    If i > 0 And Replace(i, numeracion, "") >= Replace(codigo, numeracion, "") Then

                        Return False

                    End If

                Else

                    Return True

                End If

            Else

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return True

    End Function

    Friend Function recuperarValorHoraTestEquipos(idequipo As String) As Integer
        Dim Result As Integer = 0
        Dim reader As SqlDataReader

        Dim con As New SqlConnection(CadenaConexion())
        Try
            sel = "select HoraTest from equipos where idEquipo = " + idequipo + ""

            cmd = New SqlCommand(sel, con)

            con.Open()

            reader = cmd.ExecuteReader()

            While (reader.Read)

                Result = reader.GetInt32(0)

            End While

            con.Close()
        Catch ex As Exception
            Result = 0

            MessageBox.Show("Error al recojer el valor horatest: " + ex.Message)
        End Try

        con.Close()

        Return Result

    End Function

    Friend Function updateHoraTestEquipos(horaTest As Integer, idEquipo As Integer) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "update equipos set HoraTest =" & horaTest & " where idEquipo = " & idEquipo

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return horaTest

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return 0

        End Try

    End Function

    'Borrar Celulas
    Public Function borrarCelulas(ByVal id As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete celulas where idcelula = " & id

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Devuelve el numero de serie de la celula de una Equipo domestico.
    Public Function numSerieCelula(ByVal numserie As Integer, ByVal lista As List(Of String)) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select celNumSerie from celulas where numserie = " & numserie & " UNION select celIndNumSerie from celulasIndustriales where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            con.Open()

            da.Fill(dt)

            con.Close()

            If dt.Rows.Count > 0 Then

                For Each row In dt.Rows

                    lista.Add(row("celNumSerie"))

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

        End Try

        Return True

    End Function

    Public Function desvicularDePedidos(ByVal idproducto As Integer, ByVal numSerie As String) As Boolean

        Dim sProducto As String = ""

        Dim sIdProducto As String = ""

        Select Case numSerie.Substring(0, 2)
            Case "CD"
                sProducto = "celulas"
                sIdProducto = "idCelula"
            Case "CI"
                sProducto = "celulasIndustriales"
                sIdProducto = "idCelula"
            Case "ED"
                sProducto = "equipos"
                sIdProducto = "idequipo"
            Case "EI"
                sProducto = "equiposIndustriales"
                sIdProducto = "idequipo"
            Case Else
                Return False

        End Select

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update " & sProducto & " set numserie = 0 where " & sIdProducto & " = " & idproducto

            cmd = New SqlCommand(sel, con)

            con.Open()

            Return cmd.ExecuteNonQuery

            con.Close()

        Catch ex As Exception

            con.Close()

        End Try

        Return False

    End Function


#End Region

#Region "CELULAS INDUSTRIALES"

    'Inserta las imagenes temporales Celulas Industriales.
    Public Function guardarImagenesCelulasIndustriales(ByVal imagen As Image, ByVal texto As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into imgTempCelInd (imagen, texto) values (@imagen, @texto)"

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image)

            cmd.Parameters.AddWithValue("@texto", texto)

            Dim MS = New System.IO.MemoryStream()

            imagen.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)

            cmd.Parameters("@imagen").Value = MS.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL CREAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Borra las imagenes temporales Celulas.
    Public Function borrarImagenesCelulasIndustriales()

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "delete imgTempCelInd"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL BORRAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Buscar codigos celulas
    Public Sub buscarCelulasIndustriales(ByVal combo As ComboBox)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select idArticulo as IDARTICULO ,  codArticulo + ' - ' + Articulo  as ARTICULO   from articulos where idSubtipoArticulo = 45 and articulo like 'CELULA%'"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            combo.DataSource = dt

            combo.DisplayMember = "ARTICULO"

            combo.ValueMember = "IDARTICULO"

            combo.SelectedIndex = -1

            combo.Text = "SELECCIONE UNA CÉLULA."

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

    End Sub

    'Buscar celulas
    Public Function llenarLvCelulasIndustriales(ByVal lv As ListView, ByVal fecha As Date, Optional ByVal id As Integer = 0) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim sID As String = ""

            If id <> 0 Then

                sID = " and CEL.idArticulo = " & id

            End If

            sel = "select CEL.*, codArticulo + ' - ' + articulo as ARTICULO from celulasIndustriales as CEL left join articulos as ART on ART.idArticulo = CEL.idArticulo              
            where  convert (date, CEL.fechaFabricacion) = convert (date, getdate()) " & sID & "  order by CEL.idCelula desc"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                For Each rows In dt.Rows

                    With lv.Items.Add(rows("idCelula")) '0

                        .subItems.Add(rows("celIndNumSerie")) '1
                        .subItems.Add(rows("ARTICULO")) '2
                        .subItems.Add(rows("fechaFabricacion")) '3
                        .subItems.Add(rows("idArticulo")) '4
                        .subItems.Add(rows("numserie")) '5

                        'Está asignado a un pedido.
                        If rows("numserie") <> 0 Then

                            .forecolor = Color.White
                            .backColor = Color.Green

                        End If

                    End With

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        Return True

    End Function

    'Insertar celulas
    Public Function insertarCelulaIndustrial(ByVal codigo As String, ByVal idArticulo As Integer)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "INSERT INTO celulasIndustriales (numserie ,idArticulo ,fechaFabricacion ,idCreador ,celIndNumSerie)
     VALUES (0 ," & idArticulo & " ,'" & Now & "' ," & Inicio.vIdUsuario & " ,'CI" & codigo & "')"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Existe Codigo celula
    Public Function existeCodigoCelulaIndustrial(ByVal codigo As String, Optional ByVal whereNumSerie As String = "") As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from celulasIndustriales where celIndNumSerie = 'CI" & codigo & "' " & whereNumSerie

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Si el Codigo celula se ha impreso.
    Public Function codigoImpresoCelulaIndustrial(ByVal codigo As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim numeracion As Integer

            codigo = Replace(codigo, "CI", "")

            If codigo.Length = 9 Then

                If IsNumeric(codigo) Then

                    numeracion = codigo.Substring(0, 4)

                    Dim i As Integer

                    sel = "select celIndNumSerie from master where numeracion = '" & numeracion & "'"

                    cmd = New SqlCommand(sel, con)

                    con.Open()

                    i = cmd.ExecuteScalar()

                    con.Close()

                    If i > 0 And Replace(i, numeracion, "") >= Replace(codigo, numeracion, "") Then

                        Return False

                    End If

                Else

                    Return True

                End If

            Else

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return True

    End Function

    'Borrar Celulas
    Public Function borrarCelulasIndustriales(ByVal id As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete celulasIndustriales where idcelula = " & id

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Devuelve el numero de serie de la celula de una Equipo Industrial.
    Public Function numSerieCelulaIndustrial(ByVal numserie As Integer) As String

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select celNumSerieInd from celulasIndustriales where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            numSerieCelulaIndustrial = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

#End Region

#Region "EQUIPOS"

    'Inserta las imagenes temporales Equipos.
    Public Function guardarImagenesEquipos(ByVal imagen As Image, ByVal texto As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into imgTempEqu (imagen, texto) values (@imagen, @texto)"

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image)

            cmd.Parameters.AddWithValue("@texto", texto)

            Dim MS = New System.IO.MemoryStream()

            imagen.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)

            cmd.Parameters("@imagen").Value = MS.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL CREAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Borra las imagenes temporales Equipos.
    Public Function borrarImagenesEquipos()

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete imgTempEqu"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL BORRAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Buscar codigos Equipos
    Public Sub buscarEquipos(ByVal combo As ComboBox)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim where As String = combo.Text

            sel = "select idArticulo as IDARTICULO ,  codArticulo + ' - ' + Articulo as ARTICULO   from articulos where 
idSubTipoArticulo = 44"

            If Trim(where) <> "" Then

                sel = sel & " and codArticulo like '" & where & "%'"

            End If


            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            combo.DataSource = dt

            combo.DisplayMember = "ARTICULO"

            combo.ValueMember = "IDARTICULO"

            If where = "" Then

                combo.SelectedIndex = -1

                combo.Text = "SELECCIONE UN EQUIPO."

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

    End Sub

    'Buscar Equipos
    Public Function llenarLvEquipos(ByVal lv As ListView, ByVal fecha As Date, Optional ByVal id As Integer = 0) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim sID As String = ""

            If id <> 0 Then

                sID = " and EQ.idArticulo = " & id

            End If

            '            sel = "select EQ.*, codArticulo + ' - ' + articulo as ARTICULO from equipos as EQ left join articulos as ART on ART.idArticulo = EQ.idArticulo              
            'where EQ.fechaFabricacion between '" & Format(fecha, "yyyy-MM-dd") & " 00:00:00.000" & "' and '" & Format(DateAdd(DateInterval.Day, 1, fecha), "yyyy-MM-dd") & " 00:00:00.000" & "' " & sID & "  order by EQ.idEquipo desc"

            sel = "select EQ.*, codArticulo + ' - ' + articulo as ARTICULO from equipos as EQ left join articulos as ART on ART.idArticulo = EQ.idArticulo              
            where convert (date, EQ.fechaFabricacion) = convert (date, getdate()) " & sID & " order by EQ.idEquipo desc"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                For Each rows In dt.Rows

                    With lv.Items.Add(rows("idEquipo")) '0

                        .subItems.Add(rows("EquNumSerie")) '1
                        .subItems.Add(rows("ARTICULO")) '2
                        .subItems.Add(rows("fechaFabricacion")) '3
                        .subItems.Add(rows("idArticulo")) '4
                        .subItems.Add(rows("numserie")) '5

                        'Está asignado a un pedido.
                        If rows("numserie") <> 0 Then

                            .forecolor = Color.White
                            .backColor = Color.Green

                        End If

                    End With

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        Return True

    End Function

    'Insertar Equipo
    Public Function insertarEquipo(ByVal codigo As String, ByVal idArticulo As Integer)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "INSERT INTO equipos (numserie ,idArticulo ,fechaFabricacion ,idCreador ,EquNumSerie)
     VALUES (0 ," & idArticulo & " ,'" & Now & "' ," & Inicio.vIdUsuario & " ,'ED" & codigo & "')"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Existe Codigo equipo
    Public Function existeCodigoEquipo(ByVal codigo As String, Optional ByVal whereNumSerie As String = "") As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim i As Integer

            sel = "select count(*) from equipos where EquNumSerie = '" & codigo & "' " & whereNumSerie

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Si el Codigo equipo se ha impreso.
    Public Function codigoImpresoEquipo(ByVal codigo As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim numeracion As Integer

            codigo = Replace(codigo, "ED", "")

            If codigo.Length = 9 Then

                If IsNumeric(codigo) Then

                    numeracion = codigo.Substring(0, 4)

                    Dim i As Integer

                    sel = "select EquNumSerie from master where numeracion = '" & numeracion & "'"

                    cmd = New SqlCommand(sel, con)

                    con.Open()

                    i = cmd.ExecuteScalar()

                    con.Close()

                    If i > 0 And Replace(i, numeracion, "") >= Replace(codigo, numeracion, "") Then

                        Return False

                    End If

                Else

                    Return True

                End If

            Else

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return True

    End Function

    'Borrar Equipos
    Public Function borrarEquipo(ByVal id As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "delete equipos where idequipo = " & id

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Devuelve el numero de serie de la caja de un Equipo domestico.
    Public Function numSerieCaja(ByVal numserie As Integer, ByVal lista As List(Of String)) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select EquNumSerie from equipos where numserie = " & numserie & " union select EquIndNumSerie  from equiposIndustriales where numserie = " & numserie

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            con.Open()

            da.Fill(dt)

            con.Close()

            If dt.Rows.Count > 0 Then

                For Each row In dt.Rows

                    lista.Add(row("EquNumSerie"))

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

        End Try

        Return True

    End Function

#End Region

#Region "EQUIPOS INDUSTRIALES"

    'Inserta las imagenes temporales Equipos.
    Public Function guardarImagenesEquiposIndustriales(ByVal imagen As Image, ByVal texto As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into imgTempEquInd (imagen, texto) values (@imagen, @texto)"

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Add("@imagen", System.Data.SqlDbType.Image)

            cmd.Parameters.AddWithValue("@texto", texto)

            Dim MS = New System.IO.MemoryStream()

            imagen.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)

            cmd.Parameters("@imagen").Value = MS.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL CREAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Borra las imagenes temporales Equipos.
    Public Function borrarImagenesEquiposIndustriales()

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete imgTempEquInd"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox("ERROR AL BORRAR LAS IMAGENES" & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return False

    End Function

    'Buscar codigos Equipos
    Public Sub buscarEquiposIndustriales(ByVal combo As ComboBox)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim where As String = combo.Text

            sel = "select idArticulo as IDARTICULO ,  codArticulo + ' - ' + Articulo as ARTICULO   from articulos where idSubTipoArticulo = 45  and articulo like 'EQUIPO%' "

            If Trim(where) <> "" Then

                sel = sel & " and codArticulo like '" & where & "%'"

            End If

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            combo.DataSource = dt

            combo.DisplayMember = "ARTICULO"

            combo.ValueMember = "IDARTICULO"

            If where = "" Then

                combo.SelectedIndex = -1

                combo.Text = "SELECCIONE UN EQUIPO."

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'Buscar Equipos
    Public Function llenarLvEquiposIndustriales(ByVal lv As ListView, ByVal fecha As Date, Optional ByVal id As Integer = 0) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim sID As String = ""

            If id <> 0 Then

                sID = " and EQ.idArticulo = " & id

            End If

            '            sel = "select EQ.*, codArticulo + ' - ' + articulo as ARTICULO from equiposIndustriales as EQ left join articulos as ART on ART.idArticulo = EQ.idArticulo              
            'where EQ.fechaFabricacion between '" & Format(fecha, "yyyy-MM-dd") & " 00:00:00.000" & "' and '" & Format(DateAdd(DateInterval.Day, 1, fecha), "yyyy-MM-dd") & " 00:00:00.000" & "' " & sID & "  order by EQ.idEquipo desc"

            sel = "select EQ.*, codArticulo + ' - ' + articulo as ARTICULO from equiposIndustriales as EQ left join articulos as ART on ART.idArticulo = EQ.idArticulo              
where convert (date, EQ.fechaFabricacion) = convert (date, getdate())  " & sID & "  order by EQ.idEquipo desc"


            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                For Each rows In dt.Rows

                    With lv.Items.Add(rows("idEquipo")) '0

                        .subItems.Add(rows("equIndNumSerie")) '1
                        .subItems.Add(rows("articulo")) '2
                        .subItems.Add(rows("fechaFabricacion")) '3
                        .subItems.Add(rows("idArticulo")) '4
                        .subItems.Add(rows("numserie")) '5

                        'Está asignado a un pedido.
                        If rows("numserie") <> 0 Then

                            .forecolor = Color.White
                            .backColor = Color.Green

                        End If

                    End With

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        End Try

        Return True

    End Function

    'Insertar Equipo
    Public Function insertarEquipoIndustrial(ByVal codigo As String, ByVal idArticulo As Integer)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "INSERT INTO equiposIndustriales (numserie ,idArticulo ,fechaFabricacion ,idCreador ,EquIndNumSerie)
     VALUES (0 ," & idArticulo & " ,'" & Now & "' ," & Inicio.vIdUsuario & " ,'EI" & codigo & "')"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Existe Codigo equipo
    Public Function existeCodigoEquipoIndustrial(ByVal codigo As String, Optional ByVal whereNumSerie As String = "") As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim i As Integer

            sel = "select count(*) from equiposIndustriales where EquIndNumSerie = '" & codigo & "'" & whereNumSerie

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Si el Codigo equipo se ha impreso.
    Public Function codigoImpresoEquipoIndustrial(ByVal codigo As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim numeracion As Integer

            codigo = Replace(codigo, "EI", "")

            If codigo.Length = 9 Then

                If IsNumeric(codigo) Then

                    numeracion = codigo.Substring(0, 4)

                    Dim i As Integer

                    sel = "select EquIndNumSerie from master where numeracion = '" & numeracion & "'"

                    cmd = New SqlCommand(sel, con)

                    con.Open()

                    i = cmd.ExecuteScalar()

                    con.Close()

                    If i > 0 And Replace(i, numeracion, "") >= Replace(codigo, numeracion, "") Then

                        Return False

                    End If

                Else

                    Return True

                End If

            Else

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return True

    End Function

    'Borrar Equipos
    Public Function borrarEquipoIndustrial(ByVal id As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "delete equiposIndustriales where idequipo = " & id

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Devuelve el numero de serie de la caja de un Equipo industrial.
    Public Function numSerieCajaIndustrial(ByVal numserie As Integer) As String

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select EquNumSerieInd from equiposIndustriales where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            numSerieCajaIndustrial = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

#End Region

#Region "BOMBAS"

    'Existe Codigo bomba
    Public Function existeCodigoBomba(ByVal codigo As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from bombas where BomNumSerie = '" & codigo & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return False

            Else

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Devuelve el numero de serie de la primera bomba de un Equipo.
    Public Function numSerieBomba1(ByVal numserie As Integer) As String

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select top(1) bomNumSerie from bombas where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            numSerieBomba1 = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

    'Devuelve el numero de serie de la segunda bomba de un Equipo.
    Public Function numSerieBomba2(ByVal numserie As Integer, ByVal numserieBomba1 As String) As String

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select top(2) bomNumSerie from bombas where numserie = " & numserie & " and bomNumSerie <> '" & numserieBomba1 & "' order by idBomba desc"

            cmd = New SqlCommand(sel, con)

            con.Open()

            numSerieBomba2 = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

#End Region

#Region "PREPARACION PEDIDOS"

    'buscar Equipo Produccion del pedido 
    Public Function EquipoProduccionPedido(ByVal numPedido As Integer, ByVal where As String, ByVal linea As String) As List(Of datosPreparacionPedidos)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Select Case linea

                Case "DOMESTICO2"
                    where = where & " and (cpe.domesticos2 = 1 or art.domesticos2 = 1) "

                Case Else
                    where = where & " and (cpe.domesticos2 = 0 or cpe.domesticos2 is null )  and (art.domesticos2 =0 or art.domesticos2 is null) "
            End Select


            Dim lista As New List(Of datosPreparacionPedidos)

            sel = "select  distinct EPP.idEquipo, ART.codArticulo , EPP.numserie, EPP.etiquetaImpresa, EPP.etiquetaFinalImpresa 
            From ConceptosPedidos  CPE
            Left Join ConceptosProduccion  CPR on CPR.idConceptoPedido  = CPE.idConcepto 
            Left Join EquiposProduccion EPP on EPP.idProduccion = CPR.idProduccion 
            Left Join ConceptosEquiposProduccion CEP on CEP.idEquipo = EPP.idEquipo
            Left Join articulos ART on ART.idArticulo = CPE.idArticulo
            Left Join SubTiposArticulo STA on STA.idSubtipoArticulo = ART.idSubtipoArticulo
            where  CPE.numpedido = " & numPedido & where & " And EPP.idEquipo Is Not null And (EPP.numSerie <> 0 
			Or STA.idSubTipoArticulo = '43' or STA.idSubTipoArticulo = '45' or ART.idsubFamilia = '106'  ) order by EPP.etiquetaImpresa asc"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            con.Open()

            da.Fill(dt)

            con.Close()

            If dt Is Nothing Then
            Else

                For Each row In dt.Rows

                    Dim dts As New datosPreparacionPedidos

                    dts.pArticulo = If(row("codArticulo") Is DBNull.Value, "", row("codArticulo"))

                    dts.pNumSerie = If(row("numSerie") = 0, asignarNumSerieEquipoProduccion(Year(Now) & row("idEquipo"), row("idEquipo")), row("numSerie"))

                    dts.pEtiquetaImpresa = If(row("etiquetaImpresa") Is DBNull.Value, 0, row("etiquetaImpresa"))

                    dts.pEtiquetaFinalImpresa = If(row("etiquetaFinalImpresa") Is DBNull.Value, 0, row("etiquetaFinalImpresa"))

                    lista.Add(dts)

                Next

            End If

            Return lista

        Catch ex As Exception

            MsgBox("ERROR 1002 EN LA CARGA DEL PEDIDO = " & numPedido & vbCrLf & ex.Message, MsgBoxStyle.Critical)

        End Try

        con.Close()

        Return Nothing

    End Function

    'Existe numSerie 
    Public Function existeNumSerie(ByVal numserie As Double) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select count(*) from equiposProduccion where numserie =" & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            If cmd.ExecuteScalar > 0 Then

                con.Close()

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Asignar Numserie
    Public Function asignarNumSerieEquipoProduccion(ByVal numSerie As Double, ByVal idEquipo As Double) As Double

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update equiposProduccion set numserie =" & numSerie & " where idEquipo = " & idEquipo

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return numSerie

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return 0

        End Try

    End Function

    'llenar el combo de articulos
    Public Function llenarComboArticulos(ByVal cbArticulos As ComboBox, ByVal numpedido As Integer, ByVal linea As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim where As String

            Select Case linea

                Case "DOMESTICO2"
                    where = " and (cpe.domesticos2 = 1 or art.domesticos2 = 1) "

                Case Else
                    where = " and ((cpe.domesticos2 = 0 or cpe.domesticos2 is null) and ( art.domesticos2 = 0  or art.domesticos2 is null)) "
            End Select


            sel = "select  distinct  ART.idArticulo , ART.CodArticulo
from ConceptosPedidos  CPE
left join ConceptosProduccion  CPR on CPR.idConceptoPedido  = CPE.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CPR.idProduccion 
left join ConceptosEquiposProduccion CEP on CEP.idEquipo = EP.idEquipo
left join articulos ART on ART.idArticulo = CPE.idArticulo
left join SubTiposArticulo STA on STA.idSubtipoArticulo = ART.idSubtipoArticulo
where CPE.numpedido = " & numpedido & where & " and EP.idEquipo is not null And  (EP.numSerie <> 0 
			or STA.idSubTipoArticulo = '43' )"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            con.Open()

            da.Fill(dt)

            con.Close()

            If dt Is Nothing Then
            Else

                With cbArticulos

                    .DataSource = dt

                    .ValueMember = "idarticulo"

                    .DisplayMember = "CodArticulo"

                    .SelectedIndex = -1

                End With

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return True

    End Function

    Public Function numpedidoActivo(ByVal linea As String) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim numpedido As Integer

            sel = "select numpedido from preparacionPedido where activo = 1 
and idlinea = (Select idlinea from lineasProduccion where linea ='" & linea & "')"

            cmd = New SqlCommand(sel, con)

            con.Open()

            numpedido = cmd.ExecuteScalar()

            con.Close()

            Return numpedido

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return 0

    End Function

    'Preparar pedido desde vista simple.
    Public Sub prepararPedido(ByVal numPedido As Integer, ByVal linea As String)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "Update preparacionPedido set fechaFin = getdate() where Activo = 1 and idlinea = (Select idlinea from lineasProduccion where linea ='" & linea & "');
                   Update preparacionPedido set Activo = 0 where idlinea = (Select idlinea from lineasProduccion where linea ='" & linea & "');
                   insert into preparacionPedido (numpedido, fechaInicio, fechaFin, idLanzador, activo, idLinea) values (" & numPedido & ", getdate(),getdate()," & Inicio.pIdUsuario & ",1, (Select idlinea from lineasProduccion where linea ='" & linea & "'));"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

    End Sub

    Public Sub desvincularPedido(ByVal numPedido As Integer, ByVal linea As String)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "Update preparacionPedido set fechaFin = getdate() where Activo = 1 and idlinea = (Select idlinea from lineasProduccion where linea ='" & linea & "');
                   Update preparacionPedido set Activo = 0 where idlinea = (Select idlinea from lineasProduccion where linea ='" & linea & "');"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

    End Sub

    Public Function buscarLinea(ByVal numPedido As Integer) As List(Of String)

        Dim con As New SqlConnection(CadenaConexion())
        Dim reader As SqlDataReader
        Dim listLinea As New List(Of String)

        Try

            sel = "Select LP.linea from preparacionPedido PP
                   left join lineasProduccion LP on LP.idLinea = PP.idLinea
                   where numpedido = " & numPedido & " and activo = 1"

            cmd = New SqlCommand(sel, con)

            con.Open()

            reader = cmd.ExecuteReader()

            While reader.Read()

                listLinea.Add(reader.Item(0))

            End While

            reader.Close()

            Return listLinea

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return Nothing

        End Try

    End Function

    'Esta en linea el equipos
    Public Function EnLinea(ByVal numPedido As Integer, ByVal sender As String) As String

        Dim con As New SqlConnection(CadenaConexion())

        Dim dt As New DataTable

        Try
            'RAMOS
            sel = "Select LP.linea from preparacionPedido PP
                   left join lineasProduccion LP on LP.idLinea = PP.idLinea
                   where numpedido = " & numPedido & " and activo = 1"

            da = New SqlDataAdapter(sel, con)

            con.Open()

            da.Fill(dt)

            con.Close()

            Dim i As Integer = dt.Rows.Count

            If i > 0 Then

                If i = 1 Then

                    For Each row In dt.Rows

                        Select Case row(0)
                            Case "INDUSTRIAL"

                                Return Nothing

                            Case "INDIVIDUAL"

                                Return Nothing

                            Case Else

                                If sender = "Individual" Or sender = "Industrial" Then

                                    Return Nothing

                                Else

                                    If sender = row(0) Then

                                        Return Nothing

                                    Else

                                        Return sender

                                    End If

                                End If

                        End Select

                    Next

                Else

                    Return Nothing

                End If

            Else

                Return sender

            End If


        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

        Return ""

    End Function

    'Items equipos
    Public Sub crearBotonesEquipos(ByVal lista As List(Of datosPreparacionPedidos), ByVal Panel As Panel)

        borrarBotones(Panel)

        Dim x As Integer = 15

        Dim y As Integer = 10

        For Each dts As datosPreparacionPedidos In lista

            Dim boton As New Button

            boton.Width = 200

            boton.Height = 150

            If x + 15 + boton.Width <= Panel.Width Then

                boton.Left = x

                boton.Top = y

                x = x + boton.Width + 15

            Else

                x = 15

                y = y + boton.Height + 20

                boton.Left = x

                boton.Top = y

                x = x + boton.Width + 15

            End If

            boton.Name = dts.pNumSerie

            If dts.pEtiquetaImpresa And dts.pEtiquetaFinalImpresa = False Then

                boton.ForeColor = Color.White

                boton.BackColor = Color.Blue

            ElseIf dts.pEtiquetaFinalImpresa Then

                boton.ForeColor = Color.White

                boton.BackColor = Color.Green

            Else

                If subEquipoAsignado(dts.pNumSerie, dts.pArticulo) Then

                    boton.ForeColor = Color.White

                    boton.BackColor = Color.DarkOrange

                Else

                    boton.ForeColor = Color.Black

                    boton.BackColor = SystemColors.Control
                End If

            End If

            boton.Text = dts.pArticulo & vbCrLf & "SN: " & dts.pNumSerie

            boton.Font = New Font("Century Gothic", 12.0F, FontStyle.Bold)

            Panel.Controls.Add(boton)

            AddHandler boton.Click, AddressOf botonNuevo

        Next

    End Sub

    'ACTUALIZAR BOTONES
    Public Sub actualizarBotonesEquipos(ByVal lista As List(Of datosPreparacionPedidos), ByVal Panel As Panel, ByVal contador As TextBox)

        Dim total As Integer = 0

        Dim preparados As Integer = 0

        For Each dts As datosPreparacionPedidos In lista

            total = total + 1

            If dts.pEtiquetaImpresa Then


                preparados = preparados + 1

            End If

            For Each boton In Panel.Controls

                If boton.Name = dts.pNumSerie Then

                    If dts.pEtiquetaImpresa And dts.pEtiquetaFinalImpresa = False Then

                        boton.ForeColor = Color.White

                        boton.BackColor = Color.Blue

                    ElseIf dts.pEtiquetaFinalImpresa Then

                        boton.ForeColor = Color.White

                        boton.BackColor = Color.Green

                    Else

                        If subEquipoAsignado(dts.pNumSerie, dts.pArticulo) Then

                            boton.ForeColor = Color.White

                            boton.BackColor = Color.DarkOrange

                        Else

                            boton.ForeColor = Color.Black

                            boton.BackColor = SystemColors.Control
                        End If

                    End If
                End If
            Next

        Next

        contador.Text = preparados & " / " & total

    End Sub


    'Asignado
    Public Function subEquipoAsignado(ByVal numSerieSubEquipo As String, ByVal articulo As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "select
(select count(*) from celulas where numSerie = @numSerieSubEquipo) + 
(select count(*) from celulasIndustriales  where numSerie = @numSerieSubEquipo) +
(select count(*) from Equipos  where numSerie  = @numSerieSubEquipo) + 
(select count(*) from EquiposIndustriales  where numSerie  = @numSerieSubEquipo)"

            cmd = New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("@numSerieSubEquipo", numSerieSubEquipo)

            con.Open()

            If cmd.ExecuteScalar = finalLinea.totalCajas(articulo) Then

                con.Close()

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Items subEquipos
    Public Sub crearBotones(ByVal lista As List(Of datosPreparacionPedidos), ByVal Panel As Panel)

        borrarBotones(Panel)

        Dim x As Integer = 15

        Dim y As Integer = 10

        For Each dts As datosPreparacionPedidos In lista

            Dim boton As New Button

            boton.Width = 200

            boton.Height = 150

            If x + 15 + boton.Width <= Panel.Width Then

                boton.Left = x

                boton.Top = y

                x = x + boton.Width + 15

            Else

                x = 15

                y = y + boton.Height + 20

                boton.Left = x

                boton.Top = y

                x = x + boton.Width + 15

            End If

            'boton.Name = dts.pNumSerie

            boton.Name = dts.pNumSerieSubProducto

            boton.Text = dts.pArticulo & vbCrLf & "SN: " & dts.pNumSerieSubProducto

            If dts.pNumSerieSubProducto <> "" Then

                boton.ForeColor = Color.White

                boton.BackColor = Color.Green

            End If

            boton.Font = New Font("Century Gothic", 12.0F, FontStyle.Bold)

            Panel.Controls.Add(boton)

            AddHandler boton.Click, AddressOf mostrarArticulo

        Next

    End Sub

    Public Sub mostrarArticulo(sender As Object, e As EventArgs)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            If sender.name = "" Then
            Else

                Dim tipo As String = sender.name.subString(0, 2)

                sel = ""

                Select Case tipo

                    Case "ED"
                        sel = "Select  AR.Articulo + ' - ' + convert( varchar(10), fechaFabricacion,103)  from equipos  EQ
Left Join articulos AR on AR.idArticulo = EQ.idArticulo where EquNumSerie = '" & sender.name & "'"

                    Case "CD"
                        sel = "Select AR.Articulo + ' - ' + convert( varchar(10), fechaFabricacion,103)  from celulas CEL
Left Join articulos AR on AR.idArticulo = cel.idArticulo where celNumSerie = '" & sender.name & "'"
                    Case "EI"
                        sel = "Select  AR.Articulo + ' - ' + convert( varchar(10), fechaFabricacion,103)  from EquiposIndustriales   EQ
Left Join articulos AR on AR.idArticulo = EQ.idArticulo where EquIndNumSerie = '" & sender.name & "'"
                    Case "CI"
                        sel = " Select  AR.Articulo + ' - ' + convert( varchar(10), fechaFabricacion,103)  from celulasIndustriales  CEL
Left Join articulos AR on AR.idArticulo = cel.idArticulo where celIndNumSerie = '" & sender.name & "'"
                End Select

                If sel <> "" Then

                    cmd = New SqlCommand(sel, con)

                    con.Open()

                    MsgBox(cmd.ExecuteScalar)

                    con.Close()

                End If

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

    End Sub

    Public Sub crearEtiqueta(ByVal botonnNumSerie As Button)

        If botonnNumSerie.Name = 0 Then

        Else

            Dim gg As New imprimirEtiqueta

            gg.inicioPreparacion = True

            gg.iNumserie = botonnNumSerie.Name

            gg.BbarcodeReferencia = True

            gg.ShowDialog()

            botonnNumSerie.BackColor = gg.colorBoton

        End If

    End Sub

    Public Sub botonNuevo(sender As Object, e As EventArgs)

        sender.parent.parent.parent.Timer1.stop()

        If sender.backcolor = Color.Blue Or sender.backcolor = Color.Green And sender.backcolor <> Color.Orange Then

            If MsgBox("Esta etiqueta ya ha sido impresa, ¿Desea volver a imprimirla?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                crearEtiqueta(sender)

            End If

        ElseIf sender.backcolor = Color.DarkOrange Then

            MsgBox("La célula ya está asignada.")

        Else

            If sender.name.length >= 9 Then

                Dim gg As New finalLinea

                gg.txNumSerieEquipo.Text = sender.name

                gg.procedentePreparacion = False

                gg.cargar()

                gg.txNumSerieEquipo.Focus()

                gg.ShowDialog()

            Else

                crearEtiqueta(sender)

                If sender.backcolor = Color.Blue Then

                    Dim dt As New DataTable

                    dt.Columns.Add("id")
                    dt.Columns.Add("x")
                    dt.Columns.Add("y")

                    Dim empiezaARegistrar As Boolean

                    Dim finalX As Double

                    Dim finaly As Double

                    For Each control In sender.parent.controls

                        Dim InicialX As Double = control.location.x

                        Dim InicialY As Double = control.location.y

                        If empiezaARegistrar Then

                            control.Location = New Point(finalX, finaly)

                        End If

                        If control.name = sender.name Then

                            empiezaARegistrar = True

                        End If

                        'Almacena la posicion del control.
                        finalX = InicialX

                        finaly = InicialY

                    Next

                    sender.Location = New Point(finalX, finaly)

                End If

            End If

        End If

        For Each form In Application.OpenForms

            If form.name = "preparacionPedidos" Then

                Dim where As String = ""

                If form.cbArticulos.SelectedIndex <> -1 Then

                    where = " and ART.idArticulo = " & form.cbArticulos.SelectedValue

                End If


                actualizarBotonesEquipos(EquipoProduccionPedido(form.lbNumpedido.text, where, form.linea), form.Panel, form.txTotalizador)

            ElseIf form.name = "finallinea" Then

                form.cargar()

            End If

        Next

        sender.parent.parent.parent.Timer1.start()

    End Sub

    Public Sub borrarBotones(ByVal Panel As Panel)

        'While Panel.Controls.Count > 0

        '    For Each Controles In Panel.Controls

        '        Panel.Controls.Remove(Controles)

        '    Next

        'End While

        Panel.Controls.Clear()

    End Sub

#End Region

#Region "IMAGENES"

    'Llenar picturesbox
    Public Sub llenarPb(ByVal wForm As gestionLogosClientes)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            With wForm

                If existeLogosClientes(.iIdCliente, .iIdArticulo) = False Then

                    .iIdCliente = 0

                End If

                sel = "select LE.idLogo  , LC.logo LogoCliente, LC.idlogo idLogoCliente,LCL.logo LogoClienteLeft,
LCL.idlogo idLogoClienteLeft,LCR.logo LogoClienteRight, LCR.idlogo idLogoClienteRight from logosEtiquetas LE
left join logosClientes LC on LC.idlogo = LE.idlogoCliente
left join logosClientes LCL on LCL.idlogo = LE.idlogoBottonLeft
left join logosClientes LCR on LCR.idlogo = LE.idlogoBottonRight  where LE.idCliente = " & .iIdCliente & " and LE.idArticulo =" & .iIdArticulo

                da = New SqlDataAdapter(sel, con)

                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    Dim bA As Byte()

                    Dim MS As MemoryStream

                    For Each row In dt.Rows

                        bA = row("logoCliente")

                        .iIdLogoCliente = row("idlogoCliente")

                        MS = New MemoryStream(bA)

                        .pbLogoCliente.Image = New Bitmap(Image.FromStream(MS))

                        bA = row("LogoClienteLeft")

                        .iIdLogoIzquierdo = row("idLogoClienteLeft")

                        MS = New MemoryStream(bA)

                        .pbIzquierdo.Image = New Bitmap(Image.FromStream(MS))

                        bA = row("LogoClienteRight")

                        .iIdLogoDerecho = row("idLogoClienteRight")

                        MS = New MemoryStream(bA)

                        .pbDerecho.Image = New Bitmap(Image.FromStream(MS))

                    Next

                Else

                    .pbLogoCliente.Image = Nothing
                    .pbIzquierdo.Image = Nothing
                    .pbDerecho.Image = Nothing

                End If

            End With

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'cargar picturesbox
    Public Sub llenarPb(ByVal pb As PictureBox, ByVal idlogo As Integer)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "select logo from  logosClientes where idlogo = " & idlogo

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                Dim bA As Byte()

                Dim MS As MemoryStream

                For Each row In dt.Rows

                    bA = row("logo")

                    MS = New MemoryStream(bA)

                    pb.Image = New Bitmap(Image.FromStream(MS))

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'Existe el logo clientes
    Public Function existeLogosClientes(ByVal idCliente As Integer, ByVal idArticulo As Integer)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from logosEtiquetas where idcliente = " & idCliente & " and idarticulo = " & idArticulo

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return True

        End Try

    End Function

    'Llena el panel con las imagenes que hay en la base de datos.
    Public Sub llenarImagenes(ByVal panelImagenes As Panel)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            panelImagenes.Controls.Clear()

            Dim listaImagenes As New List(Of String)

            Dim dt As New DataTable

            sel = "select * from logosClientes order by idLogo desc"

            da = New SqlDataAdapter(sel, con)

            da.Fill(dt)

            Dim pic As PictureBox = Nothing

            Dim top As Integer = 10

            Dim left As Integer = 10

            Dim mS As MemoryStream

            If dt Is Nothing Then

            Else

                For Each rows In dt.Rows

                    If rows("logo") Is DBNull.Value Then

                    Else

                        Dim sImagen As String = System.Text.Encoding.Unicode.GetString(rows("logo"))

                        Dim crear As Boolean = True

                        If listaImagenes Is Nothing Then

                        Else
                            'For Each item In listaImagenes

                            '    If item = sImagen Then

                            '        crear = False

                            '    End If

                            'Next


                        End If

                        If crear Then

                            pic = New PictureBox

                            pic.Height = 150

                            pic.Width = 450

                            pic.Top = top

                            pic.Left = left

                            pic.BorderStyle = BorderStyle.Fixed3D

                            pic.SizeMode = PictureBoxSizeMode.CenterImage

                            pic.BackColor = Color.Black

                            pic.Name = rows("idLogo")

                            Dim bA() As Byte

                            bA = rows("logo")

                            mS = New MemoryStream(bA)

                            panelImagenes.Controls.Add(pic)

                            pic.Image = New Bitmap(Image.FromStream(mS), New Size(Round(rows("parametroWidth") / 10), Round(rows("parametroHeight") / 10)))

                            'top = pic.Top + pic.Height + 10

                            AddHandler pic.DoubleClick, AddressOf selectImagen_DoubleClick

                            listaImagenes.Add(sImagen)

                            pTotalImagenes = pTotalImagenes + 1

                            left = pic.Left + 460

                            If left + 500 > panelImagenes.Width Then

                                left = 10

                                top = top + 160

                            End If

                        End If

                    End If

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'Evento doble click sobre una imagen.
    Private Sub selectImagen_DoubleClick(sender As Object, e As EventArgs)

        pImage = sender.image

        pIdImage = sender.name

        For Each control In sender.parent.controls

            control.backcolor = Color.Black

        Next

        sender.backcolor = Color.Green

    End Sub

    'Guardar logo en base de datos
    Public Function guardarLogo(ByVal imagen As Image) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into logosClientes (logo, parametroWidth, parametroHeight) values (@logo, 
" & imagen.Width * 10 & ", " & imagen.Height * 10 & ")"

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Clear()

            cmd.Parameters.Add(New SqlParameter("@logo", SqlDbType.VarBinary))

            Dim ms As New System.IO.MemoryStream()

            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

            cmd.Parameters("@logo").Value = ms.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

        Return False

    End Function

    'Guardar logo en base de datos
    Public Function ActualizarLogo(ByVal imagen As Image, ByVal idLogo As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update logosClientes set  logo = @logo, 
parametroWidth = " & imagen.Width * 10 & ", parametroHeight = " & imagen.Height * 10 & " where idlogo = " & idLogo

            cmd = New SqlCommand(sel, con)

            cmd.Parameters.Clear()

            cmd.Parameters.Add(New SqlParameter("@logo", SqlDbType.VarBinary))

            Dim ms As New System.IO.MemoryStream()

            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png)

            cmd.Parameters("@logo").Value = ms.GetBuffer()

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

        Return False

    End Function

    Public Function guardarLogosClientes(ByVal idLogoCliente As Integer, ByVal idLogoIzquierdo As Integer, ByVal idLogoDerecho As Integer, ByVal idCliente As Integer, ByVal idArticulo As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            If existeLogosClientes(idCliente, idArticulo) Then

                sel = "Update logosEtiquetas Set [idlogoCliente] = " & idLogoCliente & If(idLogoIzquierdo <> 0, ", [idlogobottonLeft] = " & idLogoIzquierdo, "") & If(idLogoDerecho <> 0, ", [idlogobottonRight] = " & idLogoDerecho, "") & " where [idCliente] = " & idCliente & " and idarticulo = " & idArticulo

            Else

                sel = "Insert into logosEtiquetas ([idlogoCliente],[idlogobottonLeft], [idlogoBottonRight] ,[idCliente], [idArticulo] ) Values (" & idLogoCliente & "," & idLogoIzquierdo & ", " & idLogoDerecho & ", " & idCliente & ", " & idArticulo & " )"

            End If

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

    'Borrar logo de la base de datos.
    Public Function borrarLogo(ByVal idLogo As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim resultado As Boolean

            sel = "delete logosClientes where (select count(*) from logosEtiquetas where idlogoCliente = " & idLogo & "
) = 0 and (select count(*) from logosEtiquetas where idlogoBottonLeft = " & idLogo & "
) = 0 and (select count(*) from logosEtiquetas where idlogoBottonRight = " & idLogo & "
) = 0 and idlogo = " & idLogo

            cmd = New SqlCommand(sel, con)

            con.Open()

            resultado = cmd.ExecuteNonQuery()

            con.Close()

            Return resultado

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return False

        End Try

    End Function

#End Region

#Region "IMPRESORAS"

    'Busca la impresora predeterminada en un equipo.
    Public Function impresorapredeterminada(ByVal TipoImpresora As Integer) As String

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "Select nombreImpresora from impresorasEtiquetasPorEquipo where equipo = '" & My.Computer.Name & "' and tipoImpresora = '" & TipoImpresora & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            impresorapredeterminada = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return ""

        End Try

    End Function
    'Borrar impresoras predeterminadas
    Public Sub borrarImpresoraPredeterminada()

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "Delete from impresorasEtiquetasPorEquipo where equipo = '" & My.Computer.Name & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Information)

        End Try

        con.Close()

    End Sub

    'Guarda la impresora predeterminada de un equipo.
    Public Function guardarImpresoraPredeterminada(ByVal TipoImpresora As Integer, ByVal nombreImpresora As String)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into impresorasEtiquetasPorEquipo (equipo, tipoimpresora, nombreImpresora) values ('" & My.Computer.Name & "','" & TipoImpresora & "', '" & nombreImpresora & "')"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return False

        End Try

    End Function


    'Guarda la impresora predeterminada de un equipo.
    Public Function actualizarImpresoraPredeterminada(ByVal TipoImpresora As Integer, ByVal nombreImpresora As String)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update impresorasEtiquetasPorEquipo set  nombreImpresora= '" & nombreImpresora & "' where Equipo = '" & My.Computer.Name & "' and tipoImpresora = '" & TipoImpresora & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return False

        End Try

    End Function

#End Region

#Region "GENERALES"

    'Llena combobox clientes
    Public Sub llenarCbClientes(ByVal cbClientes As ComboBox)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select idcliente, nombrecomercial from clientes where activo = 'true' order by nombreComercial asc"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt Is Nothing Then
            Else

                With cbClientes

                    .DataSource = dt

                    .DisplayMember = "nombreComercial"

                    .ValueMember = "idCliente"

                    .SelectedIndex = -1

                End With

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    'Devuelve el codigo del artículo de un equipo de produccion.
    Public Function codArticulo(ByVal numserie As Integer) As String

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select ART.codArticulo, ART.idSubtipoArticulo  from EquiposProduccion EP
left join Articulos ART on ART.idArticulo = EP.idArticulo 
where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            codArticulo = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

    'Devuelve el codigo del artículo de un equipo de produccion.
    Public Function mostrarIdSubTipoArticulo(ByVal codArticulo As String) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select idSubtipoArticulo from Articulos where codArticulo = '" & codArticulo & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            mostrarIdSubTipoArticulo = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

            Return Nothing

        End Try

    End Function

    'Elimina los acentos a un texto.
    Public Function TextoSinAcentos(ByVal Texto As String) As String

        Dim lngTexto As Long

        Dim i As Long

        Dim strCaracter As String

        TextoSinAcentos = ""

        lngTexto = Len(Texto)

        If lngTexto = 0 Then

            Exit Function

        End If

        For i = 1 To lngTexto

            strCaracter = Mid(Texto, i, 1)

            Select Case strCaracter

                Case "Á", "À", "Â", "Ä", "Ã"

                    strCaracter = "A"

                Case "á", "à", "â", "ä", "ã"

                    strCaracter = "a"

                Case "É", "È", "Ê", "Ë"

                    strCaracter = "E"

                Case "é", "è", "ê", "ë"

                    strCaracter = "e"

                Case "Í", "Ì", "Î", "Ï"

                    strCaracter = "I"

                Case "í", "ì", "î", "ï"

                    strCaracter = "i"

                Case "Ó", "Ò", "Ô", "Ö", "Õ"

                    strCaracter = "O"

                Case "ó", "ò", "ô", "ö", "õ"

                    strCaracter = "o"

                Case "Ú", "Ù", "Û", "Ü"

                    strCaracter = "U"

                Case "ú", "ù", "û", "ü"

                    strCaracter = "u"

                Case "Ý"

                    strCaracter = "Y"

                Case "ý", "ÿ"

                    strCaracter = "y"

            End Select

            TextoSinAcentos = TextoSinAcentos & strCaracter

        Next i

    End Function

#End Region

#Region "ETIQUETAS EQUIPOS"

    'Llenar campos Etiqueta

    Public Function ExisteEtiqueta(ByVal dts As datosEtiquetasEquipos, ByVal numSerie As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select PE.idcliente, CPE.idArticulo,  ARTC.codArticuloCli ArticuloCliente  , ART.codArticulo Articulo ,  CLI.NombreComercial Cliente, 
LC.logo LogoCliente, LCL.logo LogoClienteLeft, LCR.logo LogoClienteRight , INOU.* , CEE.*,  INOU.web as WEBINOU  from EquiposProduccion EP
Left join ConceptosProduccion CP on CP.idProduccion = EP.idProduccion 
left join conceptosPedidos CPE on CPE.idconcepto = CP.idConceptoPedido
left join pedidos PE on PE.numPedido = CPE.numPedido  
left join articulos ART on ART.idArticulo = CPE.idArticulo 
left join articuloCliente ARTC on ARTC.idArticulo = CPE.idArticulo and ARTC.idCliente = PE.idcliente 
left join clientes CLI on CLI.idcliente = PE.idcliente
left join logosEtiquetas LE on LE.idCliente  = CLI.idCliente and le.idArticulo = art.idArticulo
left join logosClientes LC on LC.idlogo = LE.idlogoCliente 
left join logosClientes LCL on LCL.idlogo = LE.idlogoBottonLeft
left join logosClientes LCR on LCR.idlogo = LE.idlogoBottonRight
left join InputsOutputs INOU on INOU.idArticulo = ART.idArticulo and INOU.idCliente = PE.idCliente 
left join camposEtiquetasEquipos CEE on CEE.idArticulo = ART.idArticulo and CEE.idCliente = PE.idCliente
    where EP.numSerie = " & numSerie

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt Is Nothing Then

                Return False

            Else
                'REPASAR ESTOS DATOS
                If dt.Rows.Count > 0 Then

                    For Each row In dt.Rows

                        dts.pArticuloCliente = If(row("ArticuloCliente") Is DBNull.Value, row("Articulo"), row("ArticuloCliente"))

                        dts.pArticulo = row("Articulo")

                        dts.pCliente = row("Cliente")

                        dts.pIdArticulo = row("idArticulo")

                        dts.pIdCliente = row("idCliente")

                        If row("idInOut") Is DBNull.Value Then

                            sel = "Select top(1)* from inputsoutputs where idarticulo = " & row("idarticulo") & " order by idInOut desc "

                            Dim da2 As New SqlDataAdapter(sel, con)

                            Dim dt2 As New DataTable

                            con.Open()

                            da2.Fill(dt2)

                            con.Close()

                            If dt2.Rows.Count > 0 Then

                                For Each row2 In dt2.Rows

                                    dts.pInputText = If(row2("inputText") Is DBNull.Value, "", row2("inputText"))

                                    dts.pOutputText = If(row2("outputText") Is DBNull.Value, "", row2("outputText"))

                                    dts.pWeb = If(row2("web") Is DBNull.Value, "", row2("web"))

                                    dts.pCampoWeb = If(row2("campoWeb") Is DBNull.Value, False, row2("campoWeb"))

                                Next

                            Else

                                dts.pInputText = ""

                                dts.pOutputText = ""

                                dts.pWeb = ""

                            End If

                        Else

                            dts.pInputText = If(row("inputText") Is DBNull.Value, "", row("inputText"))

                            dts.pOutputText = If(row("outputText") Is DBNull.Value, "", row("outputText"))

                            dts.pWeb = If(row("WEBINOU") Is DBNull.Value, "", row("WEBINOU"))

                            dts.pCampoWeb = If(row("campoWeb") Is DBNull.Value, False, row("campoWeb"))

                        End If

                        dts.pIdCamposEtiquetasPedidos = If(row("idEtiquetaEquipos") Is DBNull.Value, False, True)

                        If dts.pIdCamposEtiquetasPedidos Then

                            dts.pEti0 = row("eti0")
                            dts.pEti1 = row("eti1")
                            dts.pEti2 = row("eti2")
                            dts.pEti3 = row("eti3")
                            dts.pEti4 = row("eti4")
                            dts.pEti5 = row("eti5")
                            dts.pEti6 = row("eti6")
                            dts.pVal0 = row("val0")
                            dts.pVal1 = row("val1")
                            dts.pVal2 = row("val2")
                            dts.pVal3 = row("val3")
                            dts.pVal4 = row("val4")
                            dts.pVal5 = row("val5")
                            dts.pId0 = row("id0")
                            dts.pId1 = row("id1")
                            dts.pId2 = row("id2")
                            dts.pId3 = row("id3")
                            dts.pId4 = row("id4")
                            dts.pId5 = row("id5")

                        End If

                        'imagenes
                        Dim ms As New MemoryStream

                        If row("logoCliente") Is DBNull.Value Then

                            dts.pLogoCliente = Nothing

                        Else

                            Dim barrImg As Byte() = DirectCast(row("logoCliente"), Byte())
                            ms = New MemoryStream(barrImg)
                            dts.pLogoCliente = Image.FromStream(ms)

                        End If

                        If row("logoClienteLeft") Is DBNull.Value Then

                            dts.pLogoBottonLeft = Nothing

                        Else

                            Dim barrImg1 As Byte() = DirectCast(row("logoClienteLeft"), Byte())
                            ms = New MemoryStream(barrImg1)
                            dts.pLogoBottonLeft = Image.FromStream(ms)

                        End If

                        If row("logoClienteRight") Is DBNull.Value Then

                            dts.pLogoBottonRight = Nothing

                        Else

                            Dim barrImg2 As Byte() = DirectCast(row("logoClienteRight"), Byte())
                            ms = New MemoryStream(barrImg2)
                            dts.pLogoBottonRight = Image.FromStream(ms)

                        End If
                        If (row("logoCE") Is DBNull.Value) Then
                            dts.pLogoCE = False
                        ElseIf (row("logoCE") = True) Then
                            dts.pLogoCE = True
                        Else
                            dts.pLogoCE = False
                        End If
                        If (row("logoCMIN") Is DBNull.Value) Then
                            dts.pLogoCMIN = False
                        ElseIf (row("logoCMIN") = True) Then
                            dts.pLogoCMIN = True
                        Else
                            dts.pLogoCMIN = False
                        End If
                        If (row("logoEAC") Is DBNull.Value) Then
                            dts.pLogoEAC = False
                        ElseIf (row("logoEAC") = True) Then
                            dts.pLogoEAC = True
                        Else
                            dts.pLogoEAC = False
                        End If
                        If (row("logoUKCA") Is DBNull.Value) Then
                            dts.pLogoUKCA = False
                        ElseIf (row("logoUKCA") = True) Then
                            dts.pLogoUKCA = True
                        Else
                            dts.pLogoUKCA = False
                        End If
                        If (row("logoLPX3") Is DBNull.Value) Then
                            dts.pLogoLPX3 = False
                        ElseIf (row("logoLPX3") = True) Then
                            dts.pLogoLPX3 = True
                        Else
                            dts.pLogoLPX3 = False
                        End If
                        If (row("logoUL") Is DBNull.Value) Then
                            dts.pLogoUL = False
                        ElseIf (row("logoUL") = True) Then
                            dts.pLogoUL = True
                        Else
                            dts.pLogoUL = False
                        End If
                        If (row("logoWEEE") Is DBNull.Value) Then
                            dts.pLogoWEEEE = False
                        ElseIf (row("logoWEEE") = True) Then
                            dts.pLogoWEEEE = True
                        Else
                            dts.pLogoWEEEE = False
                        End If
                        If (row("logoMADEINSPAIN") Is DBNull.Value) Then
                            dts.pMadeInSpain = False
                        ElseIf (row("logoMADEINSPAIN") = True) Then
                            dts.pMadeInSpain = True
                        Else
                            dts.pMadeInSpain = False
                        End If

                    Next

                    Return True

                Else

                    Return False

                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return Nothing

    End Function

    'Llenar campos Etiqueta offline
    Public Function ExisteEtiquetaOffline(ByVal dts As datosEtiquetasEquipos, ByVal idArticulo As Integer, ByVal idCliente As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            '            sel = "select ARTC.CodArticuloCli ArticuloCliente, ART.codArticulo Articulo, CLI.NombreComercial  CLIENTE , CEE.idarticulo IdArticulo ,  
            'LC.logo LogoCliente, LCL.logo LogoClienteLeft, LCR .logo LogoClienteRight, *, INOUT.web as WEBINOU  from camposEtiquetasEquipos CEE
            'left join clientes CLI on CLI.idcliente = CEE.idcliente
            'left join articulos ART on ART.idArticulo = CEE.idarticulo 
            'left join ArticuloCliente ARTC on ARTC.idArticulo  = ART.idArticulo  and ARTC.idcliente = CEE.idCliente
            'left join InputsOutputs INOUT on INOUT.idCliente = CEE.idcliente and INOUT.idArticulo = CEE.idArticulo 
            'left join LogosEtiquetas LE on LE.idCliente = CEE.idcliente and LE.idArticulo = CEE.idArticulo
            'left join LogosClientes LC on LC .idlogo =  LE.idlogoCliente 
            'left join LogosClientes LCL on LCL .idlogo =  LE.idlogobottonLeft 
            'left join LogosClientes LCR on LCR .idlogo =  LE.idlogoBottonRight 
            'where CEE.idcliente = " & idCliente & "  and CEE.idArticulo = " & idArticulo

            sel = "declare @idArticulo int;
declare @idCliente int;
set @idArticulo =" & idArticulo & " ;
set @idCliente = " & idCliente & ";
select  ARTC.CodArticuloCli ArticuloCliente, ART.codArticulo Articulo, CLI.NombreComercial  CLIENTE , CEE.idarticulo IdArticulo ,  
LC.logo LogoCliente, LCL.logo LogoClienteLeft, LCR .logo LogoClienteRight, *, INOUT.web as WEBINOU  from camposEtiquetasEquipos CEE
left join clientes CLI on CLI.idcliente = CEE.idcliente
left join articulos ART on ART.idArticulo = CEE.idarticulo 
left join ArticuloCliente ARTC on ARTC.idArticulo  = ART.idArticulo  and ARTC.idcliente = CEE.idCliente
left join InputsOutputs INOUT on INOUT.idCliente = CEE.idcliente and INOUT.idArticulo = CEE.idArticulo 
left join LogosEtiquetas LE on LE.idLogo = (select top(1) idlogo from logosEtiquetas where idCliente = CEE.idcliente and (idArticulo = @idArticulo or LE.idarticulo is null) order by idLogo desc)
left join LogosClientes LC on LC .idlogo =  LE.idlogoCliente 
left join LogosClientes LCL on LCL .idlogo =  LE.idlogobottonLeft 
left join LogosClientes LCR on LCR .idlogo =  LE.idlogoBottonRight 
where CEE.idcliente = @idCliente and  CEE.idArticulo = @idArticulo order by LE.idLogo desc"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt Is Nothing Then

                Return False

            Else

                If dt.Rows.Count > 0 Then

                    For Each row In dt.Rows

                        dts.pArticuloCliente = If(row("ArticuloCliente") Is DBNull.Value, row("Articulo"), row("ArticuloCliente"))

                        dts.pArticulo = row("Articulo")

                        dts.pCliente = row("Cliente")

                        dts.pIdArticulo = row("idArticulo")

                        dts.pIdCliente = row("idCliente")

                        If row("idInOut") Is DBNull.Value Then

                            sel = "Select * from inputsoutputs where idarticulo = " & row("idarticulo")

                            Dim da2 As New SqlDataAdapter(sel, con)

                            Dim dt2 As New DataTable

                            con.Open()

                            da2.Fill(dt2)

                            con.Close()

                            If dt2.Rows.Count > 0 Then

                                For Each row2 In dt2.Rows

                                    dts.pInputText = If(row2("inputText") Is DBNull.Value, "", row2("inputText"))

                                    dts.pOutputText = If(row2("outputText") Is DBNull.Value, "", row2("outputText"))

                                    dts.pWeb = If(row2("web") Is DBNull.Value, "", row2("web"))

                                    dts.pCampoWeb = If(row2("campoWeb") Is DBNull.Value, False, row2("campoWeb"))

                                Next

                            Else

                                dts.pInputText = ""

                                dts.pOutputText = ""

                                dts.pWeb = ""

                            End If

                        Else

                            dts.pInputText = If(row("inputText") Is DBNull.Value, "", row("inputText"))

                            dts.pOutputText = If(row("outputText") Is DBNull.Value, "", row("outputText"))

                            dts.pWeb = If(row("WEBINOU") Is DBNull.Value, "", row("WEBINOU"))

                            dts.pCampoWeb = If(row("campoWeb") Is DBNull.Value, False, row("campoWeb"))

                        End If

                        dts.pIdCamposEtiquetasPedidos = If(row("idEtiquetaEquipos") Is DBNull.Value, False, True)

                        If dts.pIdCamposEtiquetasPedidos Then

                            dts.pEti0 = row("eti0")
                            dts.pEti1 = row("eti1")
                            dts.pEti2 = row("eti2")
                            dts.pEti3 = row("eti3")
                            dts.pEti4 = row("eti4")
                            dts.pEti5 = row("eti5")
                            dts.pEti6 = row("eti6")
                            dts.pVal0 = row("val0")
                            dts.pVal1 = row("val1")
                            dts.pVal2 = row("val2")
                            dts.pVal3 = row("val3")
                            dts.pVal4 = row("val4")
                            dts.pVal5 = row("val5")
                            dts.pId0 = row("id0")
                            dts.pId1 = row("id1")
                            dts.pId2 = row("id2")
                            dts.pId3 = row("id3")
                            dts.pId4 = row("id4")
                            dts.pId5 = row("id5")

                        End If

                        'imagenes
                        Dim ms As New MemoryStream

                        If row("logoCliente") Is DBNull.Value Then

                            dts.pLogoCliente = Nothing

                        Else

                            Dim barrImg As Byte() = DirectCast(row("logoCliente"), Byte())
                            ms = New MemoryStream(barrImg)
                            dts.pLogoCliente = Image.FromStream(ms)

                        End If

                        If row("logoClienteLeft") Is DBNull.Value Then

                            dts.pLogoBottonLeft = Nothing

                        Else

                            Dim barrImg1 As Byte() = DirectCast(row("logoClienteLeft"), Byte())
                            ms = New MemoryStream(barrImg1)
                            dts.pLogoBottonLeft = Image.FromStream(ms)

                        End If

                        If row("logoClienteRight") Is DBNull.Value Then

                            dts.pLogoBottonRight = Nothing

                        Else

                            Dim barrImg2 As Byte() = DirectCast(row("logoClienteRight"), Byte())
                            ms = New MemoryStream(barrImg2)
                            dts.pLogoBottonRight = Image.FromStream(ms)

                        End If
                        If (row("logoCE") Is DBNull.Value) Then
                            dts.pLogoCE = False
                        ElseIf (row("logoCE") = True) Then
                            dts.pLogoCE = True
                        Else
                            dts.pLogoCE = False
                        End If
                        If (row("logoCMIN") Is DBNull.Value) Then
                            dts.pLogoCMIN = False
                        ElseIf (row("logoCMIN") = True) Then
                            dts.pLogoCMIN = True
                        Else
                            dts.pLogoCMIN = False
                        End If
                        If (row("logoEAC") Is DBNull.Value) Then
                            dts.pLogoEAC = False
                        ElseIf (row("logoEAC") = True) Then
                            dts.pLogoEAC = True
                        Else
                            dts.pLogoEAC = False
                        End If
                        If (row("logoUKCA") Is DBNull.Value) Then
                            dts.pLogoUKCA = False
                        ElseIf (row("logoUKCA") = True) Then
                            dts.pLogoUKCA = True
                        Else
                            dts.pLogoUKCA = False
                        End If
                        If (row("logoLPX3") Is DBNull.Value) Then
                            dts.pLogoLPX3 = False
                        ElseIf (row("logoLPX3") = True) Then
                            dts.pLogoLPX3 = True
                        Else
                            dts.pLogoLPX3 = False
                        End If
                        If (row("logoUL") Is DBNull.Value) Then
                            dts.pLogoUL = False
                        ElseIf (row("logoUL") = True) Then
                            dts.pLogoUL = True
                        Else
                            dts.pLogoUL = False
                        End If
                        If (row("logoWEEE") Is DBNull.Value) Then
                            dts.pLogoWEEEE = False
                        ElseIf (row("logoWEEE") = True) Then
                            dts.pLogoWEEEE = True
                        Else
                            dts.pLogoWEEEE = False
                        End If
                        If (row("logoMADEINSPAIN") Is DBNull.Value) Then
                            dts.pMadeInSpain = False
                        ElseIf (row("logoMADEINSPAIN") = True) Then
                            dts.pMadeInSpain = True
                        Else
                            dts.pMadeInSpain = False
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        Return False
    End Function

    'Guardar input output y valores etiqueta.
    Public Function guardarInputOutput(ByVal wForm As imprimirEtiqueta) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        With wForm

            If existeInputOutputCliente(.idArticulo, .idCliente) Then

                sel = "update InputsOutputs set inputText = '" & .txInput.Text & "' , outputText = '" & .txOutPut.Text & "', web = '""', campoWeb = " & 0 & ",logoCE = " & If(.cbCE.Checked, 1, 0) & ",logoCMIN = " & If(.cbCMIN.Checked, 1, 0) & ",logoEAC = " & If(.cbEAC.Checked, 1, 0) & ",logoUKCA = " & If(.cbUKCA.Checked, 1, 0) & ",logoLPX3 = " & If(.cbLPX3.Checked, 1, 0) & ",logoUL = " & If(.cbUL.Checked, 1, 0) & ",logoWEEE = " & If(.cbWEEEE.Checked, 1, 0) & ",logoMADEINSPAIN = " & If(.cbMadeInSpain.Checked, 1, 0) & "  where idarticulo = " & .idArticulo & " and idCliente = " & .idCliente & " ;"
                sel = sel & " delete camposEtiquetasEquipos where idarticulo = " & .idArticulo & " and idCliente = " & .idCliente & ";"
                sel = sel & "INSERT INTO camposEtiquetasEquipos
([idCliente],[idArticulo],[eti0],[eti1],[eti2],[eti3],[eti4],[eti5],[eti6],[val0],[val1],[val2],[val3],[val4],[val5],[val6],[id0] ,[id1],[id2],[id3],[id4],[id5],[id6]) VALUES
('" & .idCliente & "','" & .idArticulo & "','" & .txEtiqueta0.Text & "','" & .txEtiqueta1.Text & "','" & .txEtiqueta2.Text & "','" & .txEtiqueta3.Text & "','" & .txEtiqueta4.Text & "','" & .txEtiqueta5.Text & "','""',
'" & .valorCombo(.cbValor0) & "','" & .valorCombo(.cbValor1) & "','" & .valorCombo(.cbValor2) & "','" & .valorCombo(.cbValor3) & "','" & .valorCombo(.cbValor4) & "','" & .valorCombo(.cbValor5) & "'," & .iNumserie & ",'" & If(.cbValor0.SelectedIndex > -1, .cbValor0.SelectedValue, 0) & "',
 '" & If(.cbValor1.SelectedIndex > -1, .cbValor1.SelectedValue, 0) & "',  '" & If(.cbValor2.SelectedIndex > -1, .cbValor2.SelectedValue, 0) & "',  '" & If(.cbValor3.SelectedIndex > -1, .cbValor3.SelectedValue, 0) & "',
  '" & If(.cbValor4.SelectedIndex > -1, .cbValor4.SelectedValue, 0) & "', '" & If(.cbValor5.SelectedIndex > -1, .cbValor5.SelectedValue, 0) & "',0)"

            Else

                sel = "insert into InputsOutputs (inputText,outputText,web,idarticulo, pieEtiqueta, idCliente, campoWeb,logoCE,logoCMIN,logoEAC,logoUKCA,logoLPX3,logoUL,logoWEEE,logoMADEINSPAIN) values ('" & .txInput.Text & "' ,'" & .txOutPut.Text & "','""', " & .idArticulo & ", '', " & .idCliente & ", " & 0 & ");
INSERT INTO camposEtiquetasEquipos
([idCliente],[idArticulo],[eti0],[eti1],[eti2],[eti3],[eti4],[eti5],[eti6],[val0],[val1],[val2]
,[val3],[val4],[val5],[val6],[id0] ,[id1],[id2],[id3],[id4],[id5],[id6]) VALUES
('" & .idCliente & "','" & .idArticulo & "','" & .txEtiqueta0.Text & "','" & .txEtiqueta1.Text & "',
'" & .txEtiqueta2.Text & "','" & .txEtiqueta3.Text & "','" & .txEtiqueta4.Text & "','" & .txEtiqueta5.Text & "','""','" & .valorCombo(.cbValor0) & "','" & .valorCombo(.cbValor1) & "','" & .valorCombo(.cbValor2) & "',
'" & .valorCombo(.cbValor3) & "','" & .valorCombo(.cbValor4) & "','" & .valorCombo(.cbValor5) & "','','" & If(.cbValor0.SelectedIndex > -1, .cbValor0.SelectedValue, 0) & "',
 '" & If(.cbValor1.SelectedIndex > -1, .cbValor1.SelectedValue, 0) & "',  '" & If(.cbValor2.SelectedIndex > -1, .cbValor2.SelectedValue, 0) & "',  '" & If(.cbValor3.SelectedIndex > -1, .cbValor3.SelectedValue, 0) & "',
  '" & If(.cbValor4.SelectedIndex > -1, .cbValor4.SelectedValue, 0) & "', '" & If(.cbValor5.SelectedIndex > -1, .cbValor5.SelectedValue, 0) & "',0," & If(.cbCE.Checked, 1, 0) & "," & If(.cbCMIN.Checked, 1, 0) & "," & If(.cbEAC.Checked, 1, 0) & "," & If(.cbUKCA.Checked, 1, 0) & "," & If(.cbLPX3.Checked, 1, 0) & "," & If(.cbUL.Checked, 1, 0) & "," & If(.cbWEEEE.Checked, 1, 0) & "," & If(.cbMadeInSpain.Checked, 1, 0) & ")"

            End If

            Try
                cmd = New SqlCommand(sel, con)

                con.Open()

                guardarInputOutput = cmd.ExecuteNonQuery()

                con.Close()

                Return True

            Catch ex As Exception

                con.Close()

                MsgBox(ex.Message)

                Return False

            End Try

        End With

    End Function

    'Guardar input output y valores etiqueta offline.
    Public Function guardarInputOutputOffline(ByVal wForm As EditorEtiqueta) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        With wForm

            Dim web As String

            web = .txWeb.Text

            If existeInputOutputCliente(.idArticulo, .idCliente) Then

                sel = "update InputsOutputs set inputText = '" & .txInput.Text & "' , outputText = '" & .txOutPut.Text & "', web = '" & web & "', campoWeb = '" & .ckWeb.Checked & "'  where idarticulo = " & .idArticulo & " and idCliente = " & .idCliente & " ;"
                sel = sel & " delete camposEtiquetasEquipos where idarticulo = " & .idArticulo & " and idCliente = " & .idCliente & ";"
                sel = sel & "INSERT INTO camposEtiquetasEquipos
([idCliente],[idArticulo],[eti0],[eti1],[eti2],[eti3],[eti4],[eti5],[eti6],[val0],[val1],[val2],[val3],[val4],[val5],[val6],[id0] ,[id1],[id2],[id3],[id4],[id5],[id6]) VALUES
('" & .idCliente & "','" & .idArticulo & "','" & .txEtiqueta0.Text & "','" & .txEtiqueta1.Text & "','" & .txEtiqueta2.Text & "','" & .txEtiqueta3.Text & "','" & .txEtiqueta4.Text & "','" & .txEtiqueta5.Text & "','" & .txEtiqueta6.Text & "',
'" & .valorCombo(.cbValor0) & "','" & .valorCombo(.cbValor1) & "','" & .valorCombo(.cbValor2) & "','" & .valorCombo(.cbValor3) & "','" & .valorCombo(.cbValor4) & "','" & .valorCombo(.cbValor5) & "','','" & If(.cbValor0.SelectedIndex > -1, .cbValor0.SelectedValue, 0) & "',
 '" & If(.cbValor1.SelectedIndex > -1, .cbValor1.SelectedValue, 0) & "',  '" & If(.cbValor2.SelectedIndex > -1, .cbValor2.SelectedValue, 0) & "',  '" & If(.cbValor3.SelectedIndex > -1, .cbValor3.SelectedValue, 0) & "',
  '" & If(.cbValor4.SelectedIndex > -1, .cbValor4.SelectedValue, 0) & "', '" & If(.cbValor5.SelectedIndex > -1, .cbValor5.SelectedValue, 0) & "',0)"

            Else

                sel = "insert into InputsOutputs (inputText,outputText,web,idarticulo, pieEtiqueta, idCliente, campoWeb) values ('" & .txInput.Text & "' ,'" & .txOutPut.Text & "','" & web & "', " & .idArticulo & ", '', " & .idCliente & ", '" & .ckWeb.Checked & "');
INSERT INTO camposEtiquetasEquipos
([idCliente],[idArticulo],[eti0],[eti1],[eti2],[eti3],[eti4],[eti5],[eti6],[val0],[val1],[val2]
,[val3],[val4],[val5],[val6],[id0] ,[id1],[id2],[id3],[id4],[id5],[id6]) VALUES
('" & .idCliente & "','" & .idArticulo & "','" & .txEtiqueta0.Text & "','" & .txEtiqueta1.Text & "',
'" & .txEtiqueta2.Text & "','" & .txEtiqueta3.Text & "','" & .txEtiqueta4.Text & "','" & .txEtiqueta5.Text & "','" & .txEtiqueta6.Text & "','" & .valorCombo(.cbValor0) & "','" & .valorCombo(.cbValor1) & "','" & .valorCombo(.cbValor2) & "',
'" & .valorCombo(.cbValor3) & "','" & .valorCombo(.cbValor4) & "','" & .valorCombo(.cbValor5) & "','','" & If(.cbValor0.SelectedIndex > -1, .cbValor0.SelectedValue, 0) & "',
 '" & If(.cbValor1.SelectedIndex > -1, .cbValor1.SelectedValue, 0) & "',  '" & If(.cbValor2.SelectedIndex > -1, .cbValor2.SelectedValue, 0) & "',  '" & If(.cbValor3.SelectedIndex > -1, .cbValor3.SelectedValue, 0) & "',
  '" & If(.cbValor4.SelectedIndex > -1, .cbValor4.SelectedValue, 0) & "', '" & If(.cbValor5.SelectedIndex > -1, .cbValor5.SelectedValue, 0) & "',0)"

            End If

            Try
                cmd = New SqlCommand(sel, con)

                con.Open()

                guardarInputOutputOffline = cmd.ExecuteNonQuery()

                con.Close()

                Return True

            Catch ex As Exception

                con.Close()

                MsgBox(ex.Message)

                Return False

            End Try

        End With

    End Function

    'existe Logos Cliente Articulo
    Public Function existenLogosClienteArticulo(ByVal idCliente As Integer, ByVal idArticulo As Integer) As Boolean
        Dim resultado As Boolean
        Dim con As New SqlConnection(CadenaConexion)
        Try
            Dim consulta As String = "select count(*) from LogosEtiquetas where idcliente = " & idCliente & " and idarticulo = " & idArticulo
            Dim cmd As New SqlCommand(consulta, con)
            con.Open()
            Dim i As Integer = cmd.ExecuteScalar()
            If i > 0 Then
                resultado = True
            Else
                resultado = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resultado
    End Function

    'existe Logos Cliente 
    Public Function existenLogosCliente(ByVal idCliente As Integer, ByVal idArticulo As Integer) As Boolean
        Dim resultado As Boolean
        Dim con As New SqlConnection(CadenaConexion)
        Try
            Dim consulta As String = "declare @idArticulo int;
declare @idCliente int;
set @idArticulo = " & idArticulo & " ;
set @idCliente =  " & idCliente & " ;
if EXISTS (select top(1) idlogo from LogosEtiquetas where idcliente = @idCliente and idarticulo is null)
begin
 insert into LogosEtiquetas (idcliente, idlogobottonLeft , idlogoBottonRight , idlogoCliente ,idArticulo )  select idCliente , idlogobottonLeft , idlogoBottonRight , idlogoCliente ,  @idArticulo  from logosEtiquetas where idlogo = (select top(1) idlogo from LogosEtiquetas where idcliente = @idCliente and idarticulo is null) ;
end "
            Dim cmd As New SqlCommand(consulta, con)
            con.Open()
            Dim i As Integer = cmd.ExecuteScalar()
            If i = 1 Then
                resultado = True
            Else
                resultado = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return resultado
    End Function

    'Existe input output
    Public Function existeInputOutput(ByVal idArticulo As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from InputsOutputs where idArticulo = " & idArticulo

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

        Return False

    End Function

    'Existe input output de cliente
    Public Function existeInputOutputCliente(ByVal idArticulo As Integer, ByVal idCliente As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from InputsOutputs where idArticulo = " & idArticulo & " and idCliente = " & idCliente

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

        End Try

        Return False

    End Function

    'Etiqueta impresa
    Public Function etiquetaImpresa(ByVal numserie As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update equiposProduccion set etiquetaImpresa = 1 where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

        End Try

        Return False

    End Function

    'Etiqueta final impresa
    Public Function etiquetaFinalImpresa(ByVal numserie As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update equiposProduccion set etiquetaFinalImpresa = 1 where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

        End Try

        Return False

    End Function

    Public Function actualizarFechaPicking(ByVal numserie As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "update equiposProduccion set fechaPicking = getDate() where numserie = " & numserie & " and fechaPicking is null "

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            con.Close()

        End Try

        Return False

    End Function

#End Region

#Region "ASIGNAR SUB EQUIPOS"

    Public Function asignarCodigoBarras(ByVal panel1 As Panel, ByVal codigoBarras As String, ByVal txNumserie As Integer) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim asignar As Boolean

            If codigoBarras.Contains("CD") And celulasAsignadas(txNumserie) < numeroCelulas Then

                If existeCodigoCelula(codigoBarras, " and  numserie = 0") Then

                    sel = " update celulas set numserie = " & txNumserie & " where celNumSerie = '" & codigoBarras & "';"

                    asignar = True

                Else

                    MsgBox("La célula ya está asignada o no existe.")

                End If

            ElseIf codigoBarras.Contains("CI") And celulasAsignadas(txNumserie) < numeroCelulas Then

                If existeCodigoCelulaIndustrial(codigoBarras, " and numserie = 0") Then

                    sel = "update CelulasIndustriales set numserie = " & txNumserie & " where celIndNumSerie = '" & codigoBarras & "';"

                    asignar = True

                Else

                    MsgBox("El equipo ya está asignado o no existe.")

                End If

            ElseIf codigoBarras.Contains("ED") And equiposAsignados(txNumserie) < numeroCajas Then

                If existeCodigoEquipo(codigoBarras, " and numserie = 0") Then

                    sel = "update Equipos set numserie = " & txNumserie & " where EquNumSerie = '" & codigoBarras & "';"

                    asignar = True

                Else

                    MsgBox("El equipo ya está asignado o no existe.")

                End If

            ElseIf codigoBarras.Contains("EI") And equiposAsignados(txNumserie) < numeroCelulas Then

                If existeCodigoEquipoIndustrial(codigoBarras, " and numserie = 0") Then

                    sel = "update EquiposIndustriales set numserie = " & txNumserie & " where EquIndNumSerie = '" & codigoBarras & "';"

                    asignar = True

                Else

                    MsgBox("El equipo ya está asignado o no existe.")

                End If

            Else

                If codigoBarras.Length > 6 And produccionSugar(codigoBarras) = False Then

                    If existeCodigoBomba(codigoBarras) And bombasAsignados(txNumserie) < 3 Then

                        sel = " insert into bombas ( numserie,idArticulo,FechaPreparacion,idCreador,bomNumSerie )
values (" & txNumserie & ",0,getdate()," & Inicio.pIdUsuario & ", '" & codigoBarras & "');"

                        asignar = True

                    Else

                        MsgBox("La bomba ya está asignada o ya se han asignado todas las bombas al equipo.")

                    End If

                End If

            End If

            If asignar Then

                cmd = New SqlCommand(sel, con)

                con.Open()

                cmd.ExecuteNonQuery()

                con.Close()

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    'Muestra si es un equipo o celula de produccion sugar.
    Public Function produccionSugar(ByVal codigo As String) As Boolean

        Dim prefijo As String = codigo.Substring(0, 2)

        Select Case prefijo
            Case "CD"
                Return True
            Case "ED"
                Return True
            Case "EI"
                Return True
            Case "CI"
                Return True
        End Select

        Return False

    End Function

    'Cuantas Celulas tiene asignada un equipo.
    Public Function celulasAsignadas(ByVal numserie As Integer) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select (select count(*) from celulas where numserie = " & numserie & ") + (select count(*) from celulasIndustriales where numserie = " & numserie & ")"

            cmd = New SqlCommand(sel, con)

            con.Open()

            celulasAsignadas = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return 100

        End Try

    End Function

    'Cuantas equipos tiene asignada un equipo.
    Public Function equiposAsignados(ByVal numserie As Integer) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select (select count(*) from equipos where numserie = " & numserie & ") + (select count(*) from equiposIndustriales where numserie = " & numserie & ")"

            cmd = New SqlCommand(sel, con)

            con.Open()

            equiposAsignados = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return 100

        End Try

    End Function

    'Cuantas bombas tiene asignada un equipo.
    Public Function bombasAsignados(ByVal numserie As Integer) As Integer

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "select count(*) from equipos where numserie = " & numserie

            cmd = New SqlCommand(sel, con)

            con.Open()

            bombasAsignados = cmd.ExecuteScalar()

            con.Close()

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message)

            Return 100

        End Try

    End Function

#End Region

#Region "PERMISOS"

    Public Function permisosBusqueda() As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim i As Integer

            sel = "SELECT count(*) FROM Menu_EntradasUsuario where idusuario = " & Inicio.pIdUsuario & " and idmenu = 126"

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

#End Region

#Region "INVENTARIO"

    'Buscar células en stock.
    Public Function buscarStock(ByVal tipoProducto As String, ByVal idArticulo As Integer) As List(Of datosProductosStock)

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim tipoNumserie As String = "" 'Almacena el tipo de num serie (celNumserie, EquNumSerie, ...)
            Dim tipoId As String = "" 'Almacena el tipo de ID (idCelulas y idEquipos)
            Dim whereIDArticulo As String = "" 'Almacena la busqueda por articulo

            'Si se busca por articulo 
            If idArticulo <> 0 Then

                whereIDArticulo = " and PRO.idArticulo = " & idArticulo

            End If

            'Segun el tipo de producto.
            Select Case tipoProducto
                Case "CELULAS"
                    tipoNumserie = "celNumSerie"
                    tipoId = "idCelula"
                Case "EQUIPOS"
                    tipoNumserie = "EquNumSerie"
                    tipoId = "idEquipo"
                Case = "CELULAS INDUSTRIALES"
                    tipoProducto = "celulasIndustriales"
                    tipoNumserie = "celIndNumSerie"
                    tipoId = "idCelula"
                Case "EQUIPOS INDUSTRIALES"
                    tipoProducto = "EquiposIndustriales"
                    tipoNumserie = "EquIndNumSerie"
                    tipoId = "idEquipo"
            End Select

            Dim lista As New List(Of datosProductosStock)

            sel = "select PRO.*, ART.articulo,ART.codArticulo from " & tipoProducto & " PRO 
left join articulos ART on ART.idArticulo = PRO.idArticulo 
where PRO.numserie = 0 " & whereIDArticulo

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                For Each row In dt.Rows

                    Dim dts As New datosProductosStock

                    dts.pIdProducto = row(tipoId)
                    dts.pIdArticulo = row("idArticulo")
                    dts.pCodProducto = row("codArticulo")
                    dts.pProducto = row("Articulo")
                    dts.pFecha = row("fechaFabricacion")
                    dts.pnumserie = row(tipoNumserie)

                    lista.Add(dts)

                Next

                Return lista

            End If

        Catch ex As Exception

            MsgBox(ex.Message & ". Error ")

        End Try

        Return Nothing

    End Function

    Public Function llenarCombox(ByVal tipoProducto As String, ByVal comboProductos As ComboBox) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim tipoNumserie As String = "" 'Almacena el tipo de num serie (celNumserie, EquNumSerie, ...)
            Dim tipoId As String = "" 'Almacena el tipo de ID (idCelulas y idEquipos)
            Dim whereIDArticulo As String = "" 'Almacena la busqueda por articulo

            'Segun el tipo de producto.
            Select Case tipoProducto
                Case "CELULAS"
                    tipoNumserie = "celNumSerie"
                    tipoId = "idCelula"
                Case "EQUIPOS"
                    tipoNumserie = "EquNumSerie"
                    tipoId = "idEquipo"
                Case = "CELULAS INDUSTRIALES"
                    tipoProducto = "celulasIndustriales"
                    tipoNumserie = "celIndNumSerie"
                    tipoId = "idCelula"
                Case "EQUIPOS INDUSTRIALES"
                    tipoProducto = "EquiposIndustriales"
                    tipoNumserie = "EquIndNumSerie"
                    tipoId = "idEquipo"
            End Select

            sel = "select  distinct ART.idArticulo,ART.articulo,ART.codArticulo from " & tipoProducto & " PRO 
left join articulos ART on ART.idArticulo = PRO.idArticulo 
where PRO.numserie = 0"

            da = New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            dt = New DataTable

            da.Fill(dt)

            comboProductos.DataSource = dt

            comboProductos.ValueMember = "idArticulo"

            comboProductos.DisplayMember = "codArticulo"

            comboProductos.SelectedIndex = -1

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        Return False

    End Function

    Public Function copiarNoInventariado(ByVal item As ListViewItem) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            sel = "insert into productosFueraDeInventario (fechaInventario, idArticulo, fechaFabricacion, numSerieProducto, idPersona) 
values (getdate(), " & item.SubItems(1).Text & ", '" & item.SubItems(5).Text & "','" & item.SubItems(4).Text & "', " & Inicio.vIdUsuario & "  ) "

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    Public Function borrarNoInventariado(ByVal codigo As String)

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim prefijo As String = codigo.Substring(0, 2)

            Select Case prefijo
                Case "CD"
                    sel = "delete celulas where celNumSerie = '" & codigo & "'"
                Case "ED"
                    sel = "delete equipos where EquNumSerie = '" & codigo & "'"
                Case "EI"
                    sel = "delete equiposIndustriales where EquIndNumSerie = '" & codigo & "'"
                Case "CI"
                    sel = "delete celulasIndustriales where celIndNumSerie = '" & codigo & "'"
            End Select

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        con.Close()

        Return False

    End Function

    Public Function comprobarNumSerieStock(ByVal query As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Dim i As Integer

        Try
            cmd = New SqlCommand(query, con)

            con.Open()

            i = cmd.ExecuteScalar

            con.Close()

            If i = 0 Then 'Si no encuentra ningun registro devuelve true

                Return True

            End If

        Catch ex As Exception

            con.Close()

            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try

        Return False

    End Function

    Public Function comprobarNumSerieOutStock(ByVal form As recuperarEquiposBorrados) As Boolean

        With form

            Dim con As New SqlConnection(CadenaConexion())

            Try
                sel = "select PFI.*, AR.codArticulo from productosFueraDeInventario PFI
                        left join articulos AR on AR.idArticulo = PFI.idArticulo 
                        where numSerieProducto ='" & .txCodigoBarras.Text & "'"

                da = New SqlDataAdapter(sel, con)

                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    For Each row In dt.Rows

                        With .lvEquipos.Items.Add(row("idArticulo"))

                            .subItems.Add(row("codArticulo"))
                            .subItems.Add(row("fechaFabricacion"))
                            .subItems.Add(row("idPersona"))
                            .subItems.Add(row("numSerieProducto"))

                        End With

                    Next

                    .txTotal.Text = FormatNumber(.lvEquipos.Items.Count, 0)

                    Return True

                Else

                    Return False

                End If

            Catch ex As Exception

                con.Close()

                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

            Return False

        End With

    End Function

    Public Function RestaurarNúmSerie(ByVal insert As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            cmd = New SqlCommand(insert, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            con.Close()

        End Try

        Return False

    End Function

    Public Function BorrarNumSerieFueraInventario(ByVal numserie As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            sel = "delete productosFueraDeInventario where numSerieProducto = '" & numserie & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

            con.Close()

        End Try

        Return False

    End Function

    Public Function llenarLvEquiposEliminados(ByVal form As recuperarEquiposBorrados) As Boolean

        With form

            .lvEquipos.Items.Clear()

            Dim con As New SqlConnection(CadenaConexion())

            Try

                sel = "select PFI.*, AR.codArticulo from productosFueraDeInventario PFI
left join articulos AR on AR.idArticulo = PFI.idArticulo
where  convert(date,PFI.fechaInventario) = convert(date,'" & .dtpFechaInventario.Value & "')"

                da = New SqlDataAdapter(sel, con)

                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count > 0 Then

                    For Each row In dt.Rows

                        With .lvEquipos.Items.Add(row("idArticulo"))

                            .subItems.Add(row("codArticulo"))
                            .subItems.Add(row("fechaFabricacion"))
                            .subItems.Add(row("idPersona"))
                            .subItems.Add(row("numSerieProducto"))

                        End With

                    Next

                End If

                .txTotal.Text = FormatNumber(.lvEquipos.Items.Count, 0)

                Return True

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

            Return False

        End With

    End Function

#End Region

#Region "EXCEL"

    Public Function ExportarListviewAExcel(ByVal lv As ListView, ByVal titulo As String, ByVal pbr As ProgressBar) As Boolean

        Try
            Dim objExcel As New Excel.Application
            Dim bkWorkBook As Excel.Workbook
            Dim shWorkSheet As Excel.Worksheet
            Dim i As Integer
            Dim j As Integer

            objExcel = New Excel.Application

            bkWorkBook = objExcel.Workbooks.Add

            shWorkSheet = CType(bkWorkBook.ActiveSheet, Excel.Worksheet)
            shWorkSheet.Range("A1:E1").Merge(True)
            shWorkSheet.Cells(1, 1).Value = titulo

            shWorkSheet.Range("A:E").ColumnWidth = 20
            shWorkSheet.Range("A:E").HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft

            shWorkSheet.Columns("E:E").NumberFormat = "mm/dd/yyyy;@"
            shWorkSheet.Rows.Range("A1:E1").Interior.Color = Color.Red
            shWorkSheet.Rows.Range("A3:E3").Interior.Color = Color.Black
            shWorkSheet.Rows(1).font.Color = Color.White
            shWorkSheet.Rows(1).font.size = 15
            shWorkSheet.Rows(1).font.bold = True
            shWorkSheet.Rows(1).font.size = 15
            shWorkSheet.Rows(1).font.bold = True
            shWorkSheet.Rows(3).font.Color = Color.White

            For i = 1 To lv.Columns.Count - 1

                shWorkSheet.Cells(3, i) = lv.Columns(i).Text

            Next

            For i = 1 To lv.Items.Count

                For j = 1 To lv.Columns.Count - 1

                    shWorkSheet.Cells(i + 3, j).Value = lv.Items(i - 1).SubItems(j).Text

                    If lv.Items(i - 1).BackColor = Color.Yellow Then

                        shWorkSheet.Cells(i + 3, j).Interior.Color = lv.Items(i - 1).BackColor

                    End If

                    If pbr.Value < pbr.Maximum Then

                        pbr.Value = pbr.Value + 1

                    End If

                    Application.DoEvents()

                Next

            Next

            pbr.Visible = False

            objExcel.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

#End Region

#Region "RESTAURAR EQUIPOS"

    Public Function restaurarEquipo(ByVal item As ListViewItem) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try

            Dim insert As String = ""

            Dim fecha As DateTime = Format(item.SubItems(2).Text)

            insert = "
insert into Equipos (numserie, idArticulo, fechaFabricacion, idCreador, EquNumSerie) values
( 0, " & item.SubItems(1).Text & ",'" & fecha & "'," & item.SubItems(3).Text & ",'" & item.SubItems(4).Text & "')"

            cmd = New SqlCommand(insert, con)

            con.Open()

            cmd.ExecuteNonQuery()

            con.Close()

            Return True

        Catch ex As Exception

        End Try

        Return False

    End Function

    Public Function existeEquipo(ByVal numserie As String) As Boolean

        Dim con As New SqlConnection(CadenaConexion())

        Try
            Dim i As Integer

            sel = "select count(*) from equipos where EquNumSerie = '" & numserie & "'"

            cmd = New SqlCommand(sel, con)

            con.Open()

            i = cmd.ExecuteScalar()

            con.Close()

            If i > 0 Then

                Return False

            End If

            Return True

        Catch ex As Exception

        End Try

        Return False

    End Function

#End Region

    Public Function mostrarNumerosSerie(ByVal numPedido As Integer) As String

        Try
            Dim con As New SqlConnection(CadenaConexion())
            sel = "select  case when ART.codArticulo is null then DOC.codArticuloCli else ART.codArticulo end , DOC.RefCliente  , EP.numSerie  from conceptospedidos DOC
left join articulos ART on ART.idArticulo = DOC.idArticulo 
left join ConceptosProduccion CP on CP.idConceptoPedido = DOC.idConcepto 
left join EquiposProduccion EP on EP.idProduccion = CP.idProduccion  
where numPedido = " & numPedido & " and CP.idProduccion is not null and EP.numSerie <> 0"

            Dim da As New SqlDataAdapter(sel, con)

            Dim dt As New DataTable

            Dim resultado As String = ""

            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                For Each row In dt.Rows

                    resultado = resultado & vbCrLf & " - " & If(Trim(row(1)) = "", row(0), row(1)) & " = " & row(2)

                Next

                Return resultado

            End If

            Return ""

        Catch ex As Exception

            Return "Error al cargar los numeros de serie."

        End Try

    End Function

End Class

