Public Class subUltimoPedidoArticulo


    Private funcPR As New funcionesProveedores
    Private funcPE As New FuncionesPersonal
    Private funcAR As New FuncionesArticulos
    Private iidProveedor As Integer
    Private iidArticulo As Integer
    Private vsoloLectura As Boolean

    Public Property pidArticulo() As Integer
        Get
            Return iidArticulo
        End Get
        Set(ByVal value As Integer)
            iidArticulo = value
        End Set
    End Property

    Public Property pidProveedor() As Integer
        Get
            Return iidProveedor
        End Get
        Set(ByVal value As Integer)
            iidProveedor = value
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return vsoloLectura
        End Get
        Set(ByVal value As Boolean)
            vsoloLectura = value
        End Set
    End Property

    Public Property VerBotonPedido() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            bPedido.Visible = value
        End Set
    End Property



    Private Sub subUltimoPedidoArticulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bPedido.Enabled = funcPE.Permiso(Inicio.vIdUsuario, "NuevoPedidoProv")
        bVerPedidoProveedor.Enabled = funcPE.Permiso(Inicio.vIdUsuario, "BusquedaPedidoProveedor")
        lbEstado.Text = ""
        If iidArticulo > 0 Then
            iidProveedor = PresentarDatos(iidProveedor) 'Primero buscamos pedidos del proveedor indicado, si no hay buscamos de cualquier proveedor.
            If Articulo.Text = "" And iidArticulo > 0 Then
                codArticulo.Text = funcAR.codArticulo(iidArticulo)
                Articulo.Text = funcAR.Articulo(iidArticulo)
            End If
            If Proveedor.Text = "" And iidProveedor > 0 Then
                Proveedor.Text = funcPR.campoProveedor(iidProveedor)
            End If
            If iidProveedor > 0 And numPedido.Text = "" Then
                iidProveedor = PresentarDatos(0)
            End If

        End If

    End Sub

    Private Function PresentarDatos(ByVal iidProveedor) As Integer

        Dim sel As String
        sel = "select distinct CP.idArticulo, codArticulo, Articulo,ArticuloProv, codArticuloProv, PP.codMoneda, NombreComercial as Proveedor, TipoUnidad,PP.idProveedor, "
        sel = sel & "case when CP.idArticulo=0 then  PrecioNetoUnitario else "
        sel = sel & "(select TOP 1 PrecioNetoUnitario from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC,idConcepto DESC) end as UltimoPrecioNeto,   "
        sel = sel & "case when CP.idArticulo=0 then  CP.numPedido else "
        sel = sel & "(select TOP 1 PedidosProv.numPedido from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC) end as UltimoPedido, "
        sel = sel & "case when CP.idArticulo=0 then  CP.Cantidad else "
        sel = sel & "(select TOP 1 ConceptosPedidosProv.Cantidad from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC) end as UltimaCantidad, "
        sel = sel & "case when CP.idArticulo=0 then  Estados.Estado else "
        sel = sel & "(select TOP 1 Estado from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido left join Estados ON Estados.idEstado = PedidosProv.idEstado where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC) end as Estado, "
        sel = sel & "case when CP.idArticulo=0 then  PP.FechaPedido else "
        sel = sel & "(select TOP 1 PedidosProv.FechaPedido from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido where idArticulo<>0 and idArticulo = CP.idArticulo and PedidosProv.idProveedor = PP.idProveedor order by PedidosProv.numPedido DESC) end as UltimaFecha, "
        sel = sel & "(select Top 1 Simbolo from ConceptosPedidosProv left join PedidosProv ON PedidosProv.numPedido = ConceptosPedidosProv.numPedido left join Monedas ON Monedas.codMoneda = PedidosProv.codMoneda where PedidosProv.numPedido = CP.numPedido) as Simbolo  "
        sel = sel & " from ConceptosPedidosProv as CP"
        sel = sel & " left Join PedidosProv as PP ON PP.numPedido = CP.numPedido "
        sel = sel & " left join Articulos as AR ON AR.idArticulo = CP.idArticulo "
        sel = sel & " left join Proveedores ON Proveedores.idProveedor = PP.idProveedor "
        sel = sel & " left join TiposUnidad ON TiposUnidad.idTipoUnidad = AR.idUnidad "
        sel = sel & " left join Estados ON Estados.idEstado = PP.idEstado "
        sel = sel & " Where CP.idArticulo = " & iidArticulo
        If iidProveedor > 0 Then sel = sel & " AND PP.idProveedor = " & iidProveedor
        Dim dt As DataTable = funcPR.BusquedaSQL(sel)
        If dt.Rows.Count = 0 And iidProveedor = 0 Then
            MsgBox("No se han encontrado pedidos de este artículo.")
        Else
            For Each linea As DataRow In dt.Rows
                If linea("idArticulo") Is DBNull.Value Then
                Else
                    codArticulo.Text = If(linea("codArticulo") Is DBNull.Value, "", linea("codArticulo"))
                    Articulo.Text = If(linea("Articulo") Is DBNull.Value, "", linea("Articulo"))
                    Proveedor.Text = If(linea("Proveedor") Is DBNull.Value, "", linea("Proveedor"))
                    Precio.Text = FormatNumber(If(linea("UltimoPrecioNeto") Is DBNull.Value, 0, linea("UltimoPrecioNeto")), 2)
                    lbMoneda.Text = If(linea("Simbolo") Is DBNull.Value, "€", linea("Simbolo"))
                    numPedido.Text = If(linea("UltimoPedido") Is DBNull.Value, "", linea("UltimoPedido"))
                    Fecha.Text = If(linea("UltimaFecha") Is DBNull.Value, "", linea("UltimaFecha"))
                    Cantidad.Text = FormatNumber(If(linea("UltimaCantidad") Is DBNull.Value, 0, linea("UltimaCantidad")), 2)
                    lbUnidadMedida.Text = If(linea("TipoUnidad") Is DBNull.Value, "u.", linea("TipoUnidad"))
                    iidProveedor = If(linea("idProveedor") Is DBNull.Value, 0, linea("idProveedor"))
                    lbEstado.Text = If(linea("Estado") Is DBNull.Value, "", linea("Estado"))
                End If
            Next

        End If
        Return iidProveedor

    End Function


    Private Sub bPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPedido.Click
        Dim GG As New subPedidoProvDirecto
        GG.pidArticulo = iidArticulo
        GG.pidProveedor = iidProveedor
        GG.SoloLectura = vSoloLectura
        GG.pCantidad = 0
        GG.ShowDialog()
        Me.DialogResult = GG.DialogResult

    End Sub

   
    Private Sub bCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub

    Private Sub bVerProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerPedidoProveedor.Click
        If IsNumeric(numPedido.Text) Then
            Dim GG As New GestionPedidoProveedor
            GG.SoloLectura = vsoloLectura
            GG.pnumPedido = numPedido.Text
            GG.ShowDialog()
        End If
    End Sub

End Class