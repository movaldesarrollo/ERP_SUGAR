<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionArticulo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionArticulo))
        Me.gbCabecera = New System.Windows.Forms.GroupBox()
        Me.ckRecambio = New System.Windows.Forms.CheckBox()
        Me.ckConNumSerie2 = New System.Windows.Forms.CheckBox()
        Me.ckConNumSerie = New System.Windows.Forms.CheckBox()
        Me.ckProduccionSeparada = New System.Windows.Forms.CheckBox()
        Me.ckMateriaPrima = New System.Windows.Forms.CheckBox()
        Me.gbVenta = New System.Windows.Forms.GroupBox()
        Me.PrecioUnitarioV = New System.Windows.Forms.TextBox()
        Me.lbMonedaV = New System.Windows.Forms.Label()
        Me.dtpFechaPrecioV = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PrecioOpcion = New System.Windows.Forms.TextBox()
        Me.ckOpcion = New System.Windows.Forms.CheckBox()
        Me.lbMonedaO = New System.Windows.Forms.Label()
        Me.gbCoste = New System.Windows.Forms.GroupBox()
        Me.PrecioUnitarioC = New System.Windows.Forms.TextBox()
        Me.lbMonedaC = New System.Windows.Forms.Label()
        Me.dtpFechaPrecioC = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bVerProveedor = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bBuscarProveedor = New System.Windows.Forms.Button()
        Me.bTipos = New System.Windows.Forms.Button()
        Me.lbSubTipo = New System.Windows.Forms.Label()
        Me.lbTipo = New System.Windows.Forms.Label()
        Me.cbSubTipo = New System.Windows.Forms.ComboBox()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.cbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.observaciones = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ckVersiones = New System.Windows.Forms.CheckBox()
        Me.ckEscandallo = New System.Windows.Forms.CheckBox()
        Me.ckSubEnsamblado = New System.Windows.Forms.CheckBox()
        Me.cbSeccion = New System.Windows.Forms.ComboBox()
        Me.cbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ckComprable = New System.Windows.Forms.CheckBox()
        Me.lbVentaIndependiente = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ckActivo = New System.Windows.Forms.CheckBox()
        Me.ckVendible = New System.Windows.Forms.CheckBox()
        Me.bUnidades = New System.Windows.Forms.Button()
        Me.StockInicial = New System.Windows.Forms.TextBox()
        Me.StockMinimo = New System.Windows.Forms.TextBox()
        Me.lbStockInicial = New System.Windows.Forms.Label()
        Me.bSecciones = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bAlmacen = New System.Windows.Forms.Button()
        Me.lbUnidadMedida2 = New System.Windows.Forms.Label()
        Me.Descripcion = New System.Windows.Forms.TextBox()
        Me.lbUnidadMedida = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbFechaBaja = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.codArticulo = New System.Windows.Forms.TextBox()
        Me.Articulo = New System.Windows.Forms.TextBox()
        Me.idArticulo = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Volumen = New System.Windows.Forms.TextBox()
        Me.KilosNetos = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.bVerEscandallo = New System.Windows.Forms.Button()
        Me.DescripcionEN = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ArticuloEN = New System.Windows.Forms.TextBox()
        Me.StockAlmacen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bNuevo = New System.Windows.Forms.Button()
        Me.bBorrar = New System.Windows.Forms.Button()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bSubir = New System.Windows.Forms.Button()
        Me.bBajar = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.tbdatos = New System.Windows.Forms.TabControl()
        Me.tpTraducciones = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Bultos = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Alto = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Fondo = New System.Windows.Forms.TextBox()
        Me.Ancho = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.KilosBrutos = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tpProveedores = New System.Windows.Forms.TabPage()
        Me.listaProv = New System.Windows.Forms.ListBox()
        Me.txCantidadPendiente = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txCantidadTotalRecibida = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txCantidadTotalPedida = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lvArticuloProv = New System.Windows.Forms.ListView()
        Me.lvidArticuloProv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvidProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCodArticuloProv = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tpVentas = New System.Windows.Forms.TabPage()
        Me.ContadorVendidos = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.lbCambioVendidos = New System.Windows.Forms.Label()
        Me.CantidadVendidos = New System.Windows.Forms.TextBox()
        Me.TotalVendidos = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.lvArticulosVendidos = New System.Windows.Forms.ListView()
        Me.lvidCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvClienteA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCodAArticuloCli = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvArticuloCli = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpArticulosVendidosHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.dtpArticulosVendidosDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lbUnidadMedida4 = New System.Windows.Forms.Label()
        Me.tpPreciosXcantidad = New System.Windows.Forms.TabPage()
        Me.cbProveedorPC = New System.Windows.Forms.ComboBox()
        Me.Desde = New System.Windows.Forms.TextBox()
        Me.dtpFechaPC = New System.Windows.Forms.DateTimePicker()
        Me.Hasta = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.PrecioPC = New System.Windows.Forms.TextBox()
        Me.lbMonedaPC = New System.Windows.Forms.Label()
        Me.lvPreciosXCantidad = New System.Windows.Forms.ListView()
        Me.lvidPrecioRango = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvProveedorPR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvRango = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPrecioPR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFechaPR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lbUnidadMedida3 = New System.Windows.Forms.Label()
        Me.tpStock = New System.Windows.Forms.TabPage()
        Me.lvStock = New System.Windows.Forms.ListView()
        Me.lvidAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCantidadA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbUnidadMedida1 = New System.Windows.Forms.Label()
        Me.tpEsacandallos = New System.Windows.Forms.TabPage()
        Me.lvEscandallos = New System.Windows.Forms.ListView()
        Me.lvidEscandallo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvcodArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCantidadE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tpDesglose = New System.Windows.Forms.TabPage()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cbVersion = New System.Windows.Forms.ComboBox()
        Me.lvConceptos = New System.Windows.Forms.ListView()
        Me.lvidConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvSeccion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.codConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCoste = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvObservaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvidArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bNuevaComposicion = New System.Windows.Forms.Button()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ckDomesticos2 = New System.Windows.Forms.CheckBox()
        Me.gbCabecera.SuspendLayout()
        Me.gbVenta.SuspendLayout()
        Me.gbCoste.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbdatos.SuspendLayout()
        Me.tpTraducciones.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tpProveedores.SuspendLayout()
        Me.tpVentas.SuspendLayout()
        Me.tpPreciosXcantidad.SuspendLayout()
        Me.tpStock.SuspendLayout()
        Me.tpEsacandallos.SuspendLayout()
        Me.tpDesglose.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.ckDomesticos2)
        Me.gbCabecera.Controls.Add(Me.ckRecambio)
        Me.gbCabecera.Controls.Add(Me.ckConNumSerie2)
        Me.gbCabecera.Controls.Add(Me.ckConNumSerie)
        Me.gbCabecera.Controls.Add(Me.ckProduccionSeparada)
        Me.gbCabecera.Controls.Add(Me.ckMateriaPrima)
        Me.gbCabecera.Controls.Add(Me.gbVenta)
        Me.gbCabecera.Controls.Add(Me.gbCoste)
        Me.gbCabecera.Controls.Add(Me.bTipos)
        Me.gbCabecera.Controls.Add(Me.lbSubTipo)
        Me.gbCabecera.Controls.Add(Me.lbTipo)
        Me.gbCabecera.Controls.Add(Me.cbSubTipo)
        Me.gbCabecera.Controls.Add(Me.cbTipo)
        Me.gbCabecera.Controls.Add(Me.cbUnidadMedida)
        Me.gbCabecera.Controls.Add(Me.observaciones)
        Me.gbCabecera.Controls.Add(Me.Label5)
        Me.gbCabecera.Controls.Add(Me.ckVersiones)
        Me.gbCabecera.Controls.Add(Me.ckEscandallo)
        Me.gbCabecera.Controls.Add(Me.ckSubEnsamblado)
        Me.gbCabecera.Controls.Add(Me.cbSeccion)
        Me.gbCabecera.Controls.Add(Me.cbAlmacen)
        Me.gbCabecera.Controls.Add(Me.Label12)
        Me.gbCabecera.Controls.Add(Me.ckComprable)
        Me.gbCabecera.Controls.Add(Me.lbVentaIndependiente)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Controls.Add(Me.ckActivo)
        Me.gbCabecera.Controls.Add(Me.ckVendible)
        Me.gbCabecera.Controls.Add(Me.bUnidades)
        Me.gbCabecera.Controls.Add(Me.StockInicial)
        Me.gbCabecera.Controls.Add(Me.StockMinimo)
        Me.gbCabecera.Controls.Add(Me.lbStockInicial)
        Me.gbCabecera.Controls.Add(Me.bSecciones)
        Me.gbCabecera.Controls.Add(Me.Label8)
        Me.gbCabecera.Controls.Add(Me.bAlmacen)
        Me.gbCabecera.Controls.Add(Me.lbUnidadMedida2)
        Me.gbCabecera.Controls.Add(Me.Descripcion)
        Me.gbCabecera.Controls.Add(Me.lbUnidadMedida)
        Me.gbCabecera.Controls.Add(Me.Label9)
        Me.gbCabecera.Controls.Add(Me.lbFechaBaja)
        Me.gbCabecera.Controls.Add(Me.Label41)
        Me.gbCabecera.Controls.Add(Me.dtpFechaBaja)
        Me.gbCabecera.Controls.Add(Me.dtpFechaAlta)
        Me.gbCabecera.Controls.Add(Me.Label3)
        Me.gbCabecera.Controls.Add(Me.Label17)
        Me.gbCabecera.Controls.Add(Me.Label6)
        Me.gbCabecera.Controls.Add(Me.Label2)
        Me.gbCabecera.Controls.Add(Me.codArticulo)
        Me.gbCabecera.Controls.Add(Me.Articulo)
        Me.gbCabecera.Controls.Add(Me.idArticulo)
        Me.gbCabecera.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCabecera.Location = New System.Drawing.Point(10, 78)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(923, 398)
        Me.gbCabecera.TabIndex = 0
        Me.gbCabecera.TabStop = False
        Me.gbCabecera.Text = "DATOS GENERALES"
        '
        'ckRecambio
        '
        Me.ckRecambio.AutoSize = True
        Me.ckRecambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckRecambio.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRecambio.Location = New System.Drawing.Point(816, 149)
        Me.ckRecambio.Name = "ckRecambio"
        Me.ckRecambio.Size = New System.Drawing.Size(94, 21)
        Me.ckRecambio.TabIndex = 176
        Me.ckRecambio.Text = "RECAMBIO"
        Me.ckRecambio.UseVisualStyleBackColor = True
        '
        'ckConNumSerie2
        '
        Me.ckConNumSerie2.AutoSize = True
        Me.ckConNumSerie2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckConNumSerie2.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckConNumSerie2.Location = New System.Drawing.Point(816, 172)
        Me.ckConNumSerie2.Name = "ckConNumSerie2"
        Me.ckConNumSerie2.Size = New System.Drawing.Size(87, 21)
        Me.ckConNumSerie2.TabIndex = 18
        Me.ckConNumSerie2.Text = "REPUESTO"
        Me.ckConNumSerie2.UseVisualStyleBackColor = True
        Me.ckConNumSerie2.Visible = False
        '
        'ckConNumSerie
        '
        Me.ckConNumSerie.AutoSize = True
        Me.ckConNumSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckConNumSerie.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckConNumSerie.Location = New System.Drawing.Point(722, 172)
        Me.ckConNumSerie.Name = "ckConNumSerie"
        Me.ckConNumSerie.Size = New System.Drawing.Size(82, 21)
        Me.ckConNumSerie.TabIndex = 17
        Me.ckConNumSerie.Text = "NORMAL"
        Me.ckConNumSerie.UseVisualStyleBackColor = True
        '
        'ckProduccionSeparada
        '
        Me.ckProduccionSeparada.AutoSize = True
        Me.ckProduccionSeparada.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckProduccionSeparada.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckProduccionSeparada.Location = New System.Drawing.Point(272, 172)
        Me.ckProduccionSeparada.Name = "ckProduccionSeparada"
        Me.ckProduccionSeparada.Size = New System.Drawing.Size(188, 21)
        Me.ckProduccionSeparada.TabIndex = 15
        Me.ckProduccionSeparada.Text = "PRODUCCIÓN SEPARADA"
        Me.ckProduccionSeparada.UseVisualStyleBackColor = True
        '
        'ckMateriaPrima
        '
        Me.ckMateriaPrima.AutoSize = True
        Me.ckMateriaPrima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckMateriaPrima.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckMateriaPrima.Location = New System.Drawing.Point(272, 149)
        Me.ckMateriaPrima.Name = "ckMateriaPrima"
        Me.ckMateriaPrima.Size = New System.Drawing.Size(122, 21)
        Me.ckMateriaPrima.TabIndex = 12
        Me.ckMateriaPrima.Text = "MATERIA PRIMA"
        Me.ckMateriaPrima.UseVisualStyleBackColor = True
        '
        'gbVenta
        '
        Me.gbVenta.Controls.Add(Me.PrecioUnitarioV)
        Me.gbVenta.Controls.Add(Me.lbMonedaV)
        Me.gbVenta.Controls.Add(Me.dtpFechaPrecioV)
        Me.gbVenta.Controls.Add(Me.Label11)
        Me.gbVenta.Controls.Add(Me.Label19)
        Me.gbVenta.Controls.Add(Me.PrecioOpcion)
        Me.gbVenta.Controls.Add(Me.ckOpcion)
        Me.gbVenta.Controls.Add(Me.lbMonedaO)
        Me.gbVenta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVenta.Location = New System.Drawing.Point(139, 237)
        Me.gbVenta.Name = "gbVenta"
        Me.gbVenta.Size = New System.Drawing.Size(311, 76)
        Me.gbVenta.TabIndex = 22
        Me.gbVenta.TabStop = False
        Me.gbVenta.Text = "VENTA"
        '
        'PrecioUnitarioV
        '
        Me.PrecioUnitarioV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioUnitarioV.Location = New System.Drawing.Point(217, 19)
        Me.PrecioUnitarioV.MaxLength = 15
        Me.PrecioUnitarioV.Name = "PrecioUnitarioV"
        Me.PrecioUnitarioV.Size = New System.Drawing.Size(70, 23)
        Me.PrecioUnitarioV.TabIndex = 1
        Me.PrecioUnitarioV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbMonedaV
        '
        Me.lbMonedaV.AutoSize = True
        Me.lbMonedaV.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMonedaV.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaV.Location = New System.Drawing.Point(288, 22)
        Me.lbMonedaV.Name = "lbMonedaV"
        Me.lbMonedaV.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaV.TabIndex = 170
        Me.lbMonedaV.Text = "€"
        '
        'dtpFechaPrecioV
        '
        Me.dtpFechaPrecioV.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrecioV.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrecioV.Location = New System.Drawing.Point(60, 19)
        Me.dtpFechaPrecioV.Name = "dtpFechaPrecioV"
        Me.dtpFechaPrecioV.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrecioV.TabIndex = 0
        Me.dtpFechaPrecioV.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(167, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 17)
        Me.Label11.TabIndex = 111
        Me.Label11.Text = "PVP"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(6, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 17)
        Me.Label19.TabIndex = 111
        Me.Label19.Text = "FECHA"
        '
        'PrecioOpcion
        '
        Me.PrecioOpcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioOpcion.Location = New System.Drawing.Point(217, 48)
        Me.PrecioOpcion.MaxLength = 15
        Me.PrecioOpcion.Name = "PrecioOpcion"
        Me.PrecioOpcion.Size = New System.Drawing.Size(70, 23)
        Me.PrecioOpcion.TabIndex = 3
        Me.PrecioOpcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ckOpcion
        '
        Me.ckOpcion.AutoSize = True
        Me.ckOpcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckOpcion.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckOpcion.Location = New System.Drawing.Point(137, 50)
        Me.ckOpcion.Name = "ckOpcion"
        Me.ckOpcion.Size = New System.Drawing.Size(81, 21)
        Me.ckOpcion.TabIndex = 2
        Me.ckOpcion.Text = "OPCIÓN"
        Me.ckOpcion.UseVisualStyleBackColor = True
        '
        'lbMonedaO
        '
        Me.lbMonedaO.AutoSize = True
        Me.lbMonedaO.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMonedaO.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaO.Location = New System.Drawing.Point(288, 51)
        Me.lbMonedaO.Name = "lbMonedaO"
        Me.lbMonedaO.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaO.TabIndex = 170
        Me.lbMonedaO.Text = "€"
        '
        'gbCoste
        '
        Me.gbCoste.Controls.Add(Me.PrecioUnitarioC)
        Me.gbCoste.Controls.Add(Me.lbMonedaC)
        Me.gbCoste.Controls.Add(Me.dtpFechaPrecioC)
        Me.gbCoste.Controls.Add(Me.Label1)
        Me.gbCoste.Controls.Add(Me.bVerProveedor)
        Me.gbCoste.Controls.Add(Me.Label13)
        Me.gbCoste.Controls.Add(Me.cbProveedor)
        Me.gbCoste.Controls.Add(Me.Label10)
        Me.gbCoste.Controls.Add(Me.bBuscarProveedor)
        Me.gbCoste.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCoste.Location = New System.Drawing.Point(139, 189)
        Me.gbCoste.Name = "gbCoste"
        Me.gbCoste.Size = New System.Drawing.Size(768, 48)
        Me.gbCoste.TabIndex = 20
        Me.gbCoste.TabStop = False
        Me.gbCoste.Text = "COMPRA"
        '
        'PrecioUnitarioC
        '
        Me.PrecioUnitarioC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioUnitarioC.Location = New System.Drawing.Point(216, 19)
        Me.PrecioUnitarioC.MaxLength = 15
        Me.PrecioUnitarioC.Name = "PrecioUnitarioC"
        Me.PrecioUnitarioC.Size = New System.Drawing.Size(70, 23)
        Me.PrecioUnitarioC.TabIndex = 1
        Me.PrecioUnitarioC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbMonedaC
        '
        Me.lbMonedaC.AutoSize = True
        Me.lbMonedaC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMonedaC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaC.Location = New System.Drawing.Point(288, 22)
        Me.lbMonedaC.Name = "lbMonedaC"
        Me.lbMonedaC.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaC.TabIndex = 170
        Me.lbMonedaC.Text = "€"
        '
        'dtpFechaPrecioC
        '
        Me.dtpFechaPrecioC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrecioC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrecioC.Location = New System.Drawing.Point(60, 19)
        Me.dtpFechaPrecioC.Name = "dtpFechaPrecioC"
        Me.dtpFechaPrecioC.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrecioC.TabIndex = 0
        Me.dtpFechaPrecioC.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(167, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "COSTE"
        '
        'bVerProveedor
        '
        Me.bVerProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerProveedor.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerProveedor.Location = New System.Drawing.Point(730, 18)
        Me.bVerProveedor.Name = "bVerProveedor"
        Me.bVerProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bVerProveedor.TabIndex = 4
        Me.bVerProveedor.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(6, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 17)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "FECHA"
        '
        'cbProveedor
        '
        Me.cbProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(489, 18)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(196, 25)
        Me.cbProveedor.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(336, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 17)
        Me.Label10.TabIndex = 130
        Me.Label10.Text = "PROVEEDOR HABITUAL"
        '
        'bBuscarProveedor
        '
        Me.bBuscarProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarProveedor.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarProveedor.Location = New System.Drawing.Point(699, 18)
        Me.bBuscarProveedor.Name = "bBuscarProveedor"
        Me.bBuscarProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarProveedor.TabIndex = 3
        Me.bBuscarProveedor.UseVisualStyleBackColor = True
        '
        'bTipos
        '
        Me.bTipos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTipos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTipos.Location = New System.Drawing.Point(869, 251)
        Me.bTipos.Name = "bTipos"
        Me.bTipos.Size = New System.Drawing.Size(27, 25)
        Me.bTipos.TabIndex = 21
        Me.bTipos.Text = "...."
        Me.bTipos.UseVisualStyleBackColor = True
        '
        'lbSubTipo
        '
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(545, 282)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(80, 20)
        Me.lbSubTipo.TabIndex = 175
        Me.lbSubTipo.Text = "SUBTIPO"
        Me.lbSubTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTipo
        '
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(548, 253)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(77, 20)
        Me.lbTipo.TabIndex = 174
        Me.lbTipo.Text = "TIPO"
        Me.lbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(628, 280)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(222, 25)
        Me.cbSubTipo.TabIndex = 22
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(629, 251)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(222, 25)
        Me.cbTipo.TabIndex = 20
        '
        'cbUnidadMedida
        '
        Me.cbUnidadMedida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnidadMedida.FormattingEnabled = True
        Me.cbUnidadMedida.Location = New System.Drawing.Point(139, 122)
        Me.cbUnidadMedida.Name = "cbUnidadMedida"
        Me.cbUnidadMedida.Size = New System.Drawing.Size(70, 25)
        Me.cbUnidadMedida.TabIndex = 7
        '
        'observaciones
        '
        Me.observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observaciones.Location = New System.Drawing.Point(139, 346)
        Me.observaciones.MaxLength = 300
        Me.observaciones.Multiline = True
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observaciones.Size = New System.Drawing.Size(712, 43)
        Me.observaciones.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(21, 346)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 17)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "OBSERVACIONES"
        '
        'ckVersiones
        '
        Me.ckVersiones.AutoSize = True
        Me.ckVersiones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVersiones.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVersiones.Location = New System.Drawing.Point(722, 149)
        Me.ckVersiones.Name = "ckVersiones"
        Me.ckVersiones.Size = New System.Drawing.Size(94, 21)
        Me.ckVersiones.TabIndex = 14
        Me.ckVersiones.Text = "VERSIONES"
        Me.ckVersiones.UseVisualStyleBackColor = True
        '
        'ckEscandallo
        '
        Me.ckEscandallo.AutoSize = True
        Me.ckEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckEscandallo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckEscandallo.Location = New System.Drawing.Point(478, 149)
        Me.ckEscandallo.Name = "ckEscandallo"
        Me.ckEscandallo.Size = New System.Drawing.Size(112, 21)
        Me.ckEscandallo.TabIndex = 13
        Me.ckEscandallo.Text = "ESCANDALLO"
        Me.ckEscandallo.UseVisualStyleBackColor = True
        '
        'ckSubEnsamblado
        '
        Me.ckSubEnsamblado.AutoSize = True
        Me.ckSubEnsamblado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSubEnsamblado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSubEnsamblado.Location = New System.Drawing.Point(272, 126)
        Me.ckSubEnsamblado.Name = "ckSubEnsamblado"
        Me.ckSubEnsamblado.Size = New System.Drawing.Size(107, 21)
        Me.ckSubEnsamblado.TabIndex = 9
        Me.ckSubEnsamblado.Text = "SUBMONTAJE"
        Me.ckSubEnsamblado.UseVisualStyleBackColor = True
        '
        'cbSeccion
        '
        Me.cbSeccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeccion.FormattingEnabled = True
        Me.cbSeccion.Location = New System.Drawing.Point(139, 316)
        Me.cbSeccion.Name = "cbSeccion"
        Me.cbSeccion.Size = New System.Drawing.Size(222, 25)
        Me.cbSeccion.TabIndex = 23
        '
        'cbAlmacen
        '
        Me.cbAlmacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(628, 316)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(222, 25)
        Me.cbAlmacen.TabIndex = 25
        Me.cbAlmacen.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(21, 320)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "SECCIÓN"
        '
        'ckComprable
        '
        Me.ckComprable.AutoSize = True
        Me.ckComprable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckComprable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckComprable.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckComprable.Location = New System.Drawing.Point(18, 209)
        Me.ckComprable.Name = "ckComprable"
        Me.ckComprable.Size = New System.Drawing.Size(105, 21)
        Me.ckComprable.TabIndex = 19
        Me.ckComprable.Text = "COMPRABLE"
        Me.ckComprable.UseVisualStyleBackColor = True
        '
        'lbVentaIndependiente
        '
        Me.lbVentaIndependiente.AutoSize = True
        Me.lbVentaIndependiente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVentaIndependiente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbVentaIndependiente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbVentaIndependiente.Location = New System.Drawing.Point(475, 174)
        Me.lbVentaIndependiente.Name = "lbVentaIndependiente"
        Me.lbVentaIndependiente.Size = New System.Drawing.Size(242, 17)
        Me.lbVentaIndependiente.TabIndex = 16
        Me.lbVentaIndependiente.Text = "NUM.SERIE EN VENTA INDEPENDIENTE:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(494, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 17)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "ALMACÉN HABITUAL"
        Me.Label7.Visible = False
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(622, 28)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 3
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'ckVendible
        '
        Me.ckVendible.AutoSize = True
        Me.ckVendible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckVendible.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVendible.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVendible.Location = New System.Drawing.Point(37, 257)
        Me.ckVendible.Name = "ckVendible"
        Me.ckVendible.Size = New System.Drawing.Size(86, 21)
        Me.ckVendible.TabIndex = 21
        Me.ckVendible.Text = "VENDIBLE"
        Me.ckVendible.UseVisualStyleBackColor = True
        '
        'bUnidades
        '
        Me.bUnidades.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bUnidades.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bUnidades.Location = New System.Drawing.Point(228, 122)
        Me.bUnidades.Name = "bUnidades"
        Me.bUnidades.Size = New System.Drawing.Size(27, 25)
        Me.bUnidades.TabIndex = 8
        Me.bUnidades.Text = "...."
        Me.bUnidades.UseVisualStyleBackColor = True
        '
        'StockInicial
        '
        Me.StockInicial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockInicial.Location = New System.Drawing.Point(721, 123)
        Me.StockInicial.MaxLength = 15
        Me.StockInicial.Name = "StockInicial"
        Me.StockInicial.Size = New System.Drawing.Size(66, 23)
        Me.StockInicial.TabIndex = 11
        Me.StockInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'StockMinimo
        '
        Me.StockMinimo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockMinimo.Location = New System.Drawing.Point(528, 123)
        Me.StockMinimo.MaxLength = 15
        Me.StockMinimo.Name = "StockMinimo"
        Me.StockMinimo.Size = New System.Drawing.Size(66, 23)
        Me.StockMinimo.TabIndex = 10
        Me.StockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbStockInicial
        '
        Me.lbStockInicial.AutoSize = True
        Me.lbStockInicial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStockInicial.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbStockInicial.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbStockInicial.Location = New System.Drawing.Point(621, 126)
        Me.lbStockInicial.Name = "lbStockInicial"
        Me.lbStockInicial.Size = New System.Drawing.Size(98, 17)
        Me.lbStockInicial.TabIndex = 126
        Me.lbStockInicial.Text = "STOCK INICIAL"
        '
        'bSecciones
        '
        Me.bSecciones.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSecciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSecciones.Location = New System.Drawing.Point(377, 316)
        Me.bSecciones.Name = "bSecciones"
        Me.bSecciones.Size = New System.Drawing.Size(27, 25)
        Me.bSecciones.TabIndex = 24
        Me.bSecciones.Text = "...."
        Me.bSecciones.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(425, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 17)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "STOCK MÍNIMO"
        '
        'bAlmacen
        '
        Me.bAlmacen.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAlmacen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAlmacen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAlmacen.Location = New System.Drawing.Point(869, 316)
        Me.bAlmacen.Name = "bAlmacen"
        Me.bAlmacen.Size = New System.Drawing.Size(27, 25)
        Me.bAlmacen.TabIndex = 26
        Me.bAlmacen.Text = "...."
        Me.bAlmacen.UseVisualStyleBackColor = True
        Me.bAlmacen.Visible = False
        '
        'lbUnidadMedida2
        '
        Me.lbUnidadMedida2.AutoSize = True
        Me.lbUnidadMedida2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidadMedida2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidadMedida2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidadMedida2.Location = New System.Drawing.Point(790, 126)
        Me.lbUnidadMedida2.Name = "lbUnidadMedida2"
        Me.lbUnidadMedida2.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidadMedida2.TabIndex = 128
        Me.lbUnidadMedida2.Text = "U"
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(139, 79)
        Me.Descripcion.MaxLength = 300
        Me.Descripcion.Multiline = True
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Descripcion.Size = New System.Drawing.Size(753, 40)
        Me.Descripcion.TabIndex = 6
        '
        'lbUnidadMedida
        '
        Me.lbUnidadMedida.AutoSize = True
        Me.lbUnidadMedida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidadMedida.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidadMedida.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidadMedida.Location = New System.Drawing.Point(596, 126)
        Me.lbUnidadMedida.Name = "lbUnidadMedida"
        Me.lbUnidadMedida.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidadMedida.TabIndex = 128
        Me.lbUnidadMedida.Text = "U"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(21, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 17)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "UNIDAD MEDIDA"
        '
        'lbFechaBaja
        '
        Me.lbFechaBaja.AutoSize = True
        Me.lbFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaBaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFechaBaja.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFechaBaja.Location = New System.Drawing.Point(707, 30)
        Me.lbFechaBaja.Name = "lbFechaBaja"
        Me.lbFechaBaja.Size = New System.Drawing.Size(85, 17)
        Me.lbFechaBaja.TabIndex = 4
        Me.lbFechaBaja.Text = "FECHA BAJA"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(432, 30)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(83, 17)
        Me.Label41.TabIndex = 111
        Me.Label41.Text = "FECHA ALTA"
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBaja.Location = New System.Drawing.Point(801, 27)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaBaja.TabIndex = 4
        Me.dtpFechaBaja.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAlta.Location = New System.Drawing.Point(528, 27)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaAlta.TabIndex = 2
        Me.dtpFechaAlta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(215, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "CÓDIGO"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(21, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 109
        Me.Label17.Text = "DESCRIPCIÓN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(21, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 17)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "NOMBRE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(21, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "ID ARTÍCULO"
        '
        'codArticulo
        '
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(287, 27)
        Me.codArticulo.MaxLength = 30
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.Size = New System.Drawing.Size(139, 23)
        Me.codArticulo.TabIndex = 1
        '
        'Articulo
        '
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(139, 53)
        Me.Articulo.MaxLength = 200
        Me.Articulo.Name = "Articulo"
        Me.Articulo.Size = New System.Drawing.Size(753, 23)
        Me.Articulo.TabIndex = 5
        '
        'idArticulo
        '
        Me.idArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.idArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idArticulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.idArticulo.Location = New System.Drawing.Point(139, 27)
        Me.idArticulo.MaxLength = 15
        Me.idArticulo.Name = "idArticulo"
        Me.idArticulo.ReadOnly = True
        Me.idArticulo.Size = New System.Drawing.Size(71, 23)
        Me.idArticulo.TabIndex = 0
        Me.idArticulo.TabStop = False
        Me.idArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(850, 50)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(14, 16)
        Me.Label32.TabIndex = 177
        Me.Label32.Text = "3"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(837, 57)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(19, 17)
        Me.Label30.TabIndex = 176
        Me.Label30.Text = "M"
        '
        'Volumen
        '
        Me.Volumen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Volumen.Location = New System.Drawing.Point(769, 54)
        Me.Volumen.MaxLength = 15
        Me.Volumen.Name = "Volumen"
        Me.Volumen.Size = New System.Drawing.Size(66, 23)
        Me.Volumen.TabIndex = 6
        Me.Volumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'KilosNetos
        '
        Me.KilosNetos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KilosNetos.Location = New System.Drawing.Point(340, 23)
        Me.KilosNetos.MaxLength = 15
        Me.KilosNetos.Name = "KilosNetos"
        Me.KilosNetos.Size = New System.Drawing.Size(65, 23)
        Me.KilosNetos.TabIndex = 1
        Me.KilosNetos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(692, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 17)
        Me.Label21.TabIndex = 126
        Me.Label21.Text = "VOLUMEN"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(408, 26)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(25, 17)
        Me.Label22.TabIndex = 126
        Me.Label22.Text = "Kg"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(255, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 17)
        Me.Label20.TabIndex = 126
        Me.Label20.Text = "PESO NETO"
        '
        'bVerEscandallo
        '
        Me.bVerEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerEscandallo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerEscandallo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerEscandallo.Location = New System.Drawing.Point(717, 8)
        Me.bVerEscandallo.Name = "bVerEscandallo"
        Me.bVerEscandallo.Size = New System.Drawing.Size(27, 25)
        Me.bVerEscandallo.TabIndex = 3
        Me.bVerEscandallo.UseVisualStyleBackColor = True
        '
        'DescripcionEN
        '
        Me.DescripcionEN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescripcionEN.Location = New System.Drawing.Point(123, 52)
        Me.DescripcionEN.MaxLength = 300
        Me.DescripcionEN.Multiline = True
        Me.DescripcionEN.Name = "DescripcionEN"
        Me.DescripcionEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DescripcionEN.Size = New System.Drawing.Size(753, 40)
        Me.DescripcionEN.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(5, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 17)
        Me.Label18.TabIndex = 109
        Me.Label18.Text = "DESCRIPTION"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(5, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 17)
        Me.Label14.TabIndex = 109
        Me.Label14.Text = "NAME"
        '
        'ArticuloEN
        '
        Me.ArticuloEN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticuloEN.Location = New System.Drawing.Point(122, 21)
        Me.ArticuloEN.MaxLength = 200
        Me.ArticuloEN.Name = "ArticuloEN"
        Me.ArticuloEN.Size = New System.Drawing.Size(753, 23)
        Me.ArticuloEN.TabIndex = 0
        '
        'StockAlmacen
        '
        Me.StockAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StockAlmacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockAlmacen.Location = New System.Drawing.Point(804, 277)
        Me.StockAlmacen.MaxLength = 15
        Me.StockAlmacen.Name = "StockAlmacen"
        Me.StockAlmacen.Size = New System.Drawing.Size(78, 23)
        Me.StockAlmacen.TabIndex = 8
        Me.StockAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(678, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 17)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "STOCK DISPONIBLE"
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(840, 22)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(567, 22)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 5
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(749, 22)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 7
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(476, 22)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 4
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.bSubir)
        Me.GroupBox2.Controls.Add(Me.bBajar)
        Me.GroupBox2.Controls.Add(Me.bImprimir)
        Me.GroupBox2.Controls.Add(Me.tbdatos)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.bSalir)
        Me.GroupBox2.Controls.Add(Me.bNuevaComposicion)
        Me.GroupBox2.Controls.Add(Me.bNuevo)
        Me.GroupBox2.Controls.Add(Me.gbCabecera)
        Me.GroupBox2.Controls.Add(Me.bGuardar)
        Me.GroupBox2.Controls.Add(Me.bBorrar)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(941, 822)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'bSubir
        '
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(294, 22)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(85, 22)
        Me.bSubir.TabIndex = 2
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(294, 50)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(85, 22)
        Me.bBajar.TabIndex = 3
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Enabled = False
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(658, 22)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'tbdatos
        '
        Me.tbdatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbdatos.CausesValidation = False
        Me.tbdatos.Controls.Add(Me.tpTraducciones)
        Me.tbdatos.Controls.Add(Me.tpProveedores)
        Me.tbdatos.Controls.Add(Me.tpVentas)
        Me.tbdatos.Controls.Add(Me.tpPreciosXcantidad)
        Me.tbdatos.Controls.Add(Me.tpStock)
        Me.tbdatos.Controls.Add(Me.tpEsacandallos)
        Me.tbdatos.Controls.Add(Me.tpDesglose)
        Me.tbdatos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbdatos.HotTrack = True
        Me.tbdatos.Location = New System.Drawing.Point(10, 482)
        Me.tbdatos.Name = "tbdatos"
        Me.tbdatos.SelectedIndex = 0
        Me.tbdatos.Size = New System.Drawing.Size(923, 333)
        Me.tbdatos.TabIndex = 1
        '
        'tpTraducciones
        '
        Me.tpTraducciones.Controls.Add(Me.GroupBox4)
        Me.tpTraducciones.Controls.Add(Me.GroupBox3)
        Me.tpTraducciones.Location = New System.Drawing.Point(4, 26)
        Me.tpTraducciones.Name = "tpTraducciones"
        Me.tpTraducciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTraducciones.Size = New System.Drawing.Size(915, 303)
        Me.tpTraducciones.TabIndex = 3
        Me.tpTraducciones.Text = "OTROS DATOS"
        Me.tpTraducciones.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Volumen)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Label32)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.Bultos)
        Me.GroupBox4.Controls.Add(Me.Label33)
        Me.GroupBox4.Controls.Add(Me.Alto)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label31)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Fondo)
        Me.GroupBox4.Controls.Add(Me.Ancho)
        Me.GroupBox4.Controls.Add(Me.KilosNetos)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.KilosBrutos)
        Me.GroupBox4.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(887, 85)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "MEDIDAS"
        '
        'Bultos
        '
        Me.Bultos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bultos.Location = New System.Drawing.Point(123, 23)
        Me.Bultos.MaxLength = 15
        Me.Bultos.Name = "Bultos"
        Me.Bultos.Size = New System.Drawing.Size(65, 23)
        Me.Bultos.TabIndex = 0
        Me.Bultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(63, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(51, 17)
        Me.Label33.TabIndex = 126
        Me.Label33.Text = "BULTOS"
        '
        'Alto
        '
        Me.Alto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alto.Location = New System.Drawing.Point(123, 54)
        Me.Alto.MaxLength = 15
        Me.Alto.Name = "Alto"
        Me.Alto.Size = New System.Drawing.Size(65, 23)
        Me.Alto.TabIndex = 3
        Me.Alto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(77, 57)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 17)
        Me.Label25.TabIndex = 126
        Me.Label25.Text = "ALTO"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(500, 57)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 17)
        Me.Label31.TabIndex = 126
        Me.Label31.Text = "FONDO"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(271, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 17)
        Me.Label27.TabIndex = 126
        Me.Label27.Text = "ANCHO"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(192, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(29, 17)
        Me.Label26.TabIndex = 126
        Me.Label26.Text = "cm"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(639, 57)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(29, 17)
        Me.Label29.TabIndex = 126
        Me.Label29.Text = "cm"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(408, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(29, 17)
        Me.Label28.TabIndex = 126
        Me.Label28.Text = "cm"
        '
        'Fondo
        '
        Me.Fondo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fondo.Location = New System.Drawing.Point(569, 54)
        Me.Fondo.MaxLength = 15
        Me.Fondo.Name = "Fondo"
        Me.Fondo.Size = New System.Drawing.Size(65, 23)
        Me.Fondo.TabIndex = 5
        Me.Fondo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Ancho
        '
        Me.Ancho.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ancho.Location = New System.Drawing.Point(339, 54)
        Me.Ancho.MaxLength = 15
        Me.Ancho.Name = "Ancho"
        Me.Ancho.Size = New System.Drawing.Size(65, 23)
        Me.Ancho.TabIndex = 4
        Me.Ancho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(480, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 17)
        Me.Label23.TabIndex = 126
        Me.Label23.Text = "PESO BRUTO"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(639, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(25, 17)
        Me.Label24.TabIndex = 126
        Me.Label24.Text = "Kg"
        '
        'KilosBrutos
        '
        Me.KilosBrutos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KilosBrutos.Location = New System.Drawing.Point(569, 23)
        Me.KilosBrutos.MaxLength = 15
        Me.KilosBrutos.Name = "KilosBrutos"
        Me.KilosBrutos.Size = New System.Drawing.Size(66, 23)
        Me.KilosBrutos.TabIndex = 2
        Me.KilosBrutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DescripcionEN)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.ArticuloEN)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(887, 99)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TRADUCCIÓN"
        '
        'tpProveedores
        '
        Me.tpProveedores.Controls.Add(Me.listaProv)
        Me.tpProveedores.Controls.Add(Me.txCantidadPendiente)
        Me.tpProveedores.Controls.Add(Me.Label43)
        Me.tpProveedores.Controls.Add(Me.txCantidadTotalRecibida)
        Me.tpProveedores.Controls.Add(Me.Label39)
        Me.tpProveedores.Controls.Add(Me.txCantidadTotalPedida)
        Me.tpProveedores.Controls.Add(Me.Label40)
        Me.tpProveedores.Controls.Add(Me.lvArticuloProv)
        Me.tpProveedores.Location = New System.Drawing.Point(4, 26)
        Me.tpProveedores.Name = "tpProveedores"
        Me.tpProveedores.Size = New System.Drawing.Size(915, 303)
        Me.tpProveedores.TabIndex = 0
        Me.tpProveedores.Text = "PROVEEDORES"
        Me.tpProveedores.UseVisualStyleBackColor = True
        '
        'listaProv
        '
        Me.listaProv.FormattingEnabled = True
        Me.listaProv.ItemHeight = 17
        Me.listaProv.Location = New System.Drawing.Point(10, 274)
        Me.listaProv.Name = "listaProv"
        Me.listaProv.Size = New System.Drawing.Size(120, 21)
        Me.listaProv.TabIndex = 229
        Me.listaProv.Visible = False
        '
        'txCantidadPendiente
        '
        Me.txCantidadPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txCantidadPendiente.BackColor = System.Drawing.SystemColors.Window
        Me.txCantidadPendiente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCantidadPendiente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCantidadPendiente.Location = New System.Drawing.Point(811, 271)
        Me.txCantidadPendiente.MaxLength = 15
        Me.txCantidadPendiente.Name = "txCantidadPendiente"
        Me.txCantidadPendiente.ReadOnly = True
        Me.txCantidadPendiente.Size = New System.Drawing.Size(90, 23)
        Me.txCantidadPendiente.TabIndex = 227
        Me.txCantidadPendiente.TabStop = False
        Me.txCantidadPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(699, 274)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(115, 17)
        Me.Label43.TabIndex = 228
        Me.Label43.Text = "TOTAL PENDIENTE"
        '
        'txCantidadTotalRecibida
        '
        Me.txCantidadTotalRecibida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txCantidadTotalRecibida.BackColor = System.Drawing.SystemColors.Window
        Me.txCantidadTotalRecibida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCantidadTotalRecibida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCantidadTotalRecibida.Location = New System.Drawing.Point(603, 271)
        Me.txCantidadTotalRecibida.MaxLength = 15
        Me.txCantidadTotalRecibida.Name = "txCantidadTotalRecibida"
        Me.txCantidadTotalRecibida.ReadOnly = True
        Me.txCantidadTotalRecibida.Size = New System.Drawing.Size(90, 23)
        Me.txCantidadTotalRecibida.TabIndex = 225
        Me.txCantidadTotalRecibida.TabStop = False
        Me.txCantidadTotalRecibida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(491, 274)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(106, 17)
        Me.Label39.TabIndex = 226
        Me.Label39.Text = "TOTAL RECIBIDA"
        '
        'txCantidadTotalPedida
        '
        Me.txCantidadTotalPedida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txCantidadTotalPedida.BackColor = System.Drawing.SystemColors.Window
        Me.txCantidadTotalPedida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCantidadTotalPedida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCantidadTotalPedida.Location = New System.Drawing.Point(396, 271)
        Me.txCantidadTotalPedida.MaxLength = 15
        Me.txCantidadTotalPedida.Name = "txCantidadTotalPedida"
        Me.txCantidadTotalPedida.ReadOnly = True
        Me.txCantidadTotalPedida.Size = New System.Drawing.Size(90, 23)
        Me.txCantidadTotalPedida.TabIndex = 222
        Me.txCantidadTotalPedida.TabStop = False
        Me.txCantidadTotalPedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(297, 274)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(95, 17)
        Me.Label40.TabIndex = 224
        Me.Label40.Text = "TOTAL PEDIDA"
        '
        'lvArticuloProv
        '
        Me.lvArticuloProv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvArticuloProv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidArticuloProv, Me.lvidProveedor, Me.lvProveedor, Me.lvFecha, Me.lvCodArticuloProv, Me.lvNombre, Me.lvPrecio})
        Me.lvArticuloProv.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvArticuloProv.FullRowSelect = True
        Me.lvArticuloProv.GridLines = True
        Me.lvArticuloProv.Location = New System.Drawing.Point(14, 16)
        Me.lvArticuloProv.Name = "lvArticuloProv"
        Me.lvArticuloProv.Size = New System.Drawing.Size(887, 249)
        Me.lvArticuloProv.TabIndex = 0
        Me.lvArticuloProv.UseCompatibleStateImageBehavior = False
        Me.lvArticuloProv.View = System.Windows.Forms.View.Details
        '
        'lvidArticuloProv
        '
        Me.lvidArticuloProv.Text = "idArticuloProv"
        Me.lvidArticuloProv.Width = 0
        '
        'lvidProveedor
        '
        Me.lvidProveedor.Text = "idProveedor"
        Me.lvidProveedor.Width = 0
        '
        'lvProveedor
        '
        Me.lvProveedor.Text = "PROVEEDOR"
        Me.lvProveedor.Width = 300
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 80
        '
        'lvCodArticuloProv
        '
        Me.lvCodArticuloProv.Text = "CÓD.PROV."
        Me.lvCodArticuloProv.Width = 100
        '
        'lvNombre
        '
        Me.lvNombre.Text = "PRODUCTO"
        Me.lvNombre.Width = 300
        '
        'lvPrecio
        '
        Me.lvPrecio.Text = "PRECIO"
        Me.lvPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecio.Width = 100
        '
        'tpVentas
        '
        Me.tpVentas.Controls.Add(Me.ContadorVendidos)
        Me.tpVentas.Controls.Add(Me.Label98)
        Me.tpVentas.Controls.Add(Me.lbCambioVendidos)
        Me.tpVentas.Controls.Add(Me.CantidadVendidos)
        Me.tpVentas.Controls.Add(Me.TotalVendidos)
        Me.tpVentas.Controls.Add(Me.Label92)
        Me.tpVentas.Controls.Add(Me.Label85)
        Me.tpVentas.Controls.Add(Me.Label91)
        Me.tpVentas.Controls.Add(Me.lvArticulosVendidos)
        Me.tpVentas.Controls.Add(Me.dtpArticulosVendidosHasta)
        Me.tpVentas.Controls.Add(Me.Label61)
        Me.tpVentas.Controls.Add(Me.dtpArticulosVendidosDesde)
        Me.tpVentas.Controls.Add(Me.Label62)
        Me.tpVentas.Controls.Add(Me.lbUnidadMedida4)
        Me.tpVentas.Location = New System.Drawing.Point(4, 26)
        Me.tpVentas.Name = "tpVentas"
        Me.tpVentas.Size = New System.Drawing.Size(915, 303)
        Me.tpVentas.TabIndex = 6
        Me.tpVentas.Text = "CLIENTES"
        Me.tpVentas.UseVisualStyleBackColor = True
        '
        'ContadorVendidos
        '
        Me.ContadorVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorVendidos.Location = New System.Drawing.Point(132, 261)
        Me.ContadorVendidos.MaxLength = 15
        Me.ContadorVendidos.Name = "ContadorVendidos"
        Me.ContadorVendidos.ReadOnly = True
        Me.ContadorVendidos.Size = New System.Drawing.Size(60, 23)
        Me.ContadorVendidos.TabIndex = 222
        Me.ContadorVendidos.TabStop = False
        Me.ContadorVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label98
        '
        Me.Label98.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label98.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label98.Location = New System.Drawing.Point(22, 264)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(106, 17)
        Me.Label98.TabIndex = 224
        Me.Label98.Text = "ENCONTRADOS"
        '
        'lbCambioVendidos
        '
        Me.lbCambioVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioVendidos.AutoSize = True
        Me.lbCambioVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioVendidos.ForeColor = System.Drawing.Color.Red
        Me.lbCambioVendidos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioVendidos.Location = New System.Drawing.Point(207, 263)
        Me.lbCambioVendidos.Name = "lbCambioVendidos"
        Me.lbCambioVendidos.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioVendidos.TabIndex = 223
        Me.lbCambioVendidos.Text = "CAMBIO"
        Me.lbCambioVendidos.Visible = False
        '
        'CantidadVendidos
        '
        Me.CantidadVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CantidadVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.CantidadVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CantidadVendidos.Location = New System.Drawing.Point(628, 261)
        Me.CantidadVendidos.MaxLength = 15
        Me.CantidadVendidos.Name = "CantidadVendidos"
        Me.CantidadVendidos.ReadOnly = True
        Me.CantidadVendidos.Size = New System.Drawing.Size(71, 23)
        Me.CantidadVendidos.TabIndex = 218
        Me.CantidadVendidos.TabStop = False
        Me.CantidadVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalVendidos
        '
        Me.TotalVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.TotalVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalVendidos.Location = New System.Drawing.Point(774, 261)
        Me.TotalVendidos.MaxLength = 15
        Me.TotalVendidos.Name = "TotalVendidos"
        Me.TotalVendidos.ReadOnly = True
        Me.TotalVendidos.Size = New System.Drawing.Size(90, 23)
        Me.TotalVendidos.TabIndex = 217
        Me.TotalVendidos.TabStop = False
        Me.TotalVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label92
        '
        Me.Label92.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label92.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label92.Location = New System.Drawing.Point(547, 264)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(75, 17)
        Me.Label92.TabIndex = 220
        Me.Label92.Text = "CANTIDAD"
        '
        'Label85
        '
        Me.Label85.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label85.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label85.Location = New System.Drawing.Point(867, 263)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(15, 17)
        Me.Label85.TabIndex = 219
        Me.Label85.Text = "€"
        '
        'Label91
        '
        Me.Label91.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label91.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label91.Location = New System.Drawing.Point(727, 263)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(44, 17)
        Me.Label91.TabIndex = 221
        Me.Label91.Text = "TOTAL"
        '
        'lvArticulosVendidos
        '
        Me.lvArticulosVendidos.AllowColumnReorder = True
        Me.lvArticulosVendidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvArticulosVendidos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidCliente, Me.lvClienteA, Me.lvCodAArticuloCli, Me.lvArticuloCli, Me.ColumnHeader8, Me.ColumnHeader9, Me.lvDocumento, Me.ColumnHeader10, Me.ColumnHeader5})
        Me.lvArticulosVendidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvArticulosVendidos.FullRowSelect = True
        Me.lvArticulosVendidos.GridLines = True
        Me.lvArticulosVendidos.HideSelection = False
        Me.lvArticulosVendidos.Location = New System.Drawing.Point(21, 47)
        Me.lvArticulosVendidos.MultiSelect = False
        Me.lvArticulosVendidos.Name = "lvArticulosVendidos"
        Me.lvArticulosVendidos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lvArticulosVendidos.ShowItemToolTips = True
        Me.lvArticulosVendidos.Size = New System.Drawing.Size(862, 208)
        Me.lvArticulosVendidos.TabIndex = 124
        Me.lvArticulosVendidos.UseCompatibleStateImageBehavior = False
        Me.lvArticulosVendidos.View = System.Windows.Forms.View.Details
        '
        'lvidCliente
        '
        Me.lvidCliente.Text = "idCliente"
        Me.lvidCliente.Width = 0
        '
        'lvClienteA
        '
        Me.lvClienteA.Text = "CLIENTE"
        Me.lvClienteA.Width = 181
        '
        'lvCodAArticuloCli
        '
        Me.lvCodAArticuloCli.Text = "CÓDIGO CLI"
        Me.lvCodAArticuloCli.Width = 88
        '
        'lvArticuloCli
        '
        Me.lvArticuloCli.Text = "ARTICULO CLIENTE"
        Me.lvArticuloCli.Width = 165
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DisplayIndex = 6
        Me.ColumnHeader8.Text = "CANTIDAD"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 74
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DisplayIndex = 7
        Me.ColumnHeader9.Text = "ÚLT.PRECIO"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 80
        '
        'lvDocumento
        '
        Me.lvDocumento.DisplayIndex = 4
        Me.lvDocumento.Text = "ÚLT.FACTURA"
        Me.lvDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvDocumento.Width = 88
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DisplayIndex = 5
        Me.ColumnHeader10.Text = "ÚLT.FECHA"
        Me.ColumnHeader10.Width = 79
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "TOTAL"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 81
        '
        'dtpArticulosVendidosHasta
        '
        Me.dtpArticulosVendidosHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArticulosVendidosHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArticulosVendidosHasta.Location = New System.Drawing.Point(257, 11)
        Me.dtpArticulosVendidosHasta.Name = "dtpArticulosVendidosHasta"
        Me.dtpArticulosVendidosHasta.Size = New System.Drawing.Size(116, 23)
        Me.dtpArticulosVendidosHasta.TabIndex = 123
        Me.dtpArticulosVendidosHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label61.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label61.Location = New System.Drawing.Point(205, 14)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(46, 17)
        Me.Label61.TabIndex = 126
        Me.Label61.Text = "HASTA"
        '
        'dtpArticulosVendidosDesde
        '
        Me.dtpArticulosVendidosDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArticulosVendidosDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArticulosVendidosDesde.Location = New System.Drawing.Point(73, 11)
        Me.dtpArticulosVendidosDesde.Name = "dtpArticulosVendidosDesde"
        Me.dtpArticulosVendidosDesde.Size = New System.Drawing.Size(116, 23)
        Me.dtpArticulosVendidosDesde.TabIndex = 122
        Me.dtpArticulosVendidosDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label62.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label62.Location = New System.Drawing.Point(19, 14)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(48, 17)
        Me.Label62.TabIndex = 125
        Me.Label62.Text = "DESDE"
        '
        'lbUnidadMedida4
        '
        Me.lbUnidadMedida4.AutoSize = True
        Me.lbUnidadMedida4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidadMedida4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidadMedida4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidadMedida4.Location = New System.Drawing.Point(701, 264)
        Me.lbUnidadMedida4.Name = "lbUnidadMedida4"
        Me.lbUnidadMedida4.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidadMedida4.TabIndex = 128
        Me.lbUnidadMedida4.Text = "U"
        '
        'tpPreciosXcantidad
        '
        Me.tpPreciosXcantidad.Controls.Add(Me.cbProveedorPC)
        Me.tpPreciosXcantidad.Controls.Add(Me.Desde)
        Me.tpPreciosXcantidad.Controls.Add(Me.dtpFechaPC)
        Me.tpPreciosXcantidad.Controls.Add(Me.Hasta)
        Me.tpPreciosXcantidad.Controls.Add(Me.Label35)
        Me.tpPreciosXcantidad.Controls.Add(Me.PrecioPC)
        Me.tpPreciosXcantidad.Controls.Add(Me.lbMonedaPC)
        Me.tpPreciosXcantidad.Controls.Add(Me.lvPreciosXCantidad)
        Me.tpPreciosXcantidad.Controls.Add(Me.Label38)
        Me.tpPreciosXcantidad.Controls.Add(Me.Label37)
        Me.tpPreciosXcantidad.Controls.Add(Me.Label34)
        Me.tpPreciosXcantidad.Controls.Add(Me.Label36)
        Me.tpPreciosXcantidad.Controls.Add(Me.lbUnidadMedida3)
        Me.tpPreciosXcantidad.Location = New System.Drawing.Point(4, 26)
        Me.tpPreciosXcantidad.Name = "tpPreciosXcantidad"
        Me.tpPreciosXcantidad.Size = New System.Drawing.Size(915, 303)
        Me.tpPreciosXcantidad.TabIndex = 5
        Me.tpPreciosXcantidad.Text = "PRECIOS POR CANTIDAD"
        Me.tpPreciosXcantidad.UseVisualStyleBackColor = True
        '
        'cbProveedorPC
        '
        Me.cbProveedorPC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedorPC.FormattingEnabled = True
        Me.cbProveedorPC.Location = New System.Drawing.Point(102, 14)
        Me.cbProveedorPC.Name = "cbProveedorPC"
        Me.cbProveedorPC.Size = New System.Drawing.Size(196, 25)
        Me.cbProveedorPC.TabIndex = 0
        '
        'Desde
        '
        Me.Desde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Desde.Location = New System.Drawing.Point(384, 15)
        Me.Desde.MaxLength = 15
        Me.Desde.Name = "Desde"
        Me.Desde.Size = New System.Drawing.Size(63, 23)
        Me.Desde.TabIndex = 1
        Me.Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaPC
        '
        Me.dtpFechaPC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPC.Location = New System.Drawing.Point(793, 15)
        Me.dtpFechaPC.Name = "dtpFechaPC"
        Me.dtpFechaPC.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPC.TabIndex = 4
        Me.dtpFechaPC.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Hasta
        '
        Me.Hasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hasta.Location = New System.Drawing.Point(470, 15)
        Me.Hasta.MaxLength = 15
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Size = New System.Drawing.Size(63, 23)
        Me.Hasta.TabIndex = 2
        Me.Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(741, 18)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(50, 17)
        Me.Label35.TabIndex = 111
        Me.Label35.Text = "FECHA"
        '
        'PrecioPC
        '
        Me.PrecioPC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioPC.Location = New System.Drawing.Point(620, 15)
        Me.PrecioPC.MaxLength = 15
        Me.PrecioPC.Name = "PrecioPC"
        Me.PrecioPC.Size = New System.Drawing.Size(90, 23)
        Me.PrecioPC.TabIndex = 3
        Me.PrecioPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbMonedaPC
        '
        Me.lbMonedaPC.AutoSize = True
        Me.lbMonedaPC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMonedaPC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaPC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaPC.Location = New System.Drawing.Point(713, 18)
        Me.lbMonedaPC.Name = "lbMonedaPC"
        Me.lbMonedaPC.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaPC.TabIndex = 170
        Me.lbMonedaPC.Text = "€"
        '
        'lvPreciosXCantidad
        '
        Me.lvPreciosXCantidad.AllowColumnReorder = True
        Me.lvPreciosXCantidad.AllowDrop = True
        Me.lvPreciosXCantidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPreciosXCantidad.AutoArrange = False
        Me.lvPreciosXCantidad.BackgroundImageTiled = True
        Me.lvPreciosXCantidad.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidPrecioRango, Me.lvProveedorPR, Me.lvRango, Me.lvPrecioPR, Me.lvFechaPR})
        Me.lvPreciosXCantidad.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvPreciosXCantidad.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPreciosXCantidad.FullRowSelect = True
        Me.lvPreciosXCantidad.GridLines = True
        Me.lvPreciosXCantidad.HideSelection = False
        Me.lvPreciosXCantidad.Location = New System.Drawing.Point(21, 47)
        Me.lvPreciosXCantidad.Name = "lvPreciosXCantidad"
        Me.lvPreciosXCantidad.ShowItemToolTips = True
        Me.lvPreciosXCantidad.Size = New System.Drawing.Size(862, 228)
        Me.lvPreciosXCantidad.TabIndex = 5
        Me.lvPreciosXCantidad.UseCompatibleStateImageBehavior = False
        Me.lvPreciosXCantidad.View = System.Windows.Forms.View.Details
        '
        'lvidPrecioRango
        '
        Me.lvidPrecioRango.Text = "idPrecioRango"
        Me.lvidPrecioRango.Width = 0
        '
        'lvProveedorPR
        '
        Me.lvProveedorPR.Text = "PROVEEDOR"
        Me.lvProveedorPR.Width = 443
        '
        'lvRango
        '
        Me.lvRango.Text = "RANGO"
        Me.lvRango.Width = 170
        '
        'lvPrecioPR
        '
        Me.lvPrecioPR.Text = "PRECIO"
        Me.lvPrecioPR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecioPR.Width = 120
        '
        'lvFechaPR
        '
        Me.lvFechaPR.Text = "FECHA"
        Me.lvFechaPR.Width = 99
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(450, 18)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(17, 17)
        Me.Label38.TabIndex = 111
        Me.Label38.Text = "A"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(303, 18)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(78, 17)
        Me.Label37.TabIndex = 111
        Me.Label37.Text = "RANGO DE"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(563, 18)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 17)
        Me.Label34.TabIndex = 111
        Me.Label34.Text = "PRECIO"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(11, 18)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(87, 17)
        Me.Label36.TabIndex = 109
        Me.Label36.Text = "PROVEEDOR"
        '
        'lbUnidadMedida3
        '
        Me.lbUnidadMedida3.AutoSize = True
        Me.lbUnidadMedida3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidadMedida3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidadMedida3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidadMedida3.Location = New System.Drawing.Point(535, 18)
        Me.lbUnidadMedida3.Name = "lbUnidadMedida3"
        Me.lbUnidadMedida3.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidadMedida3.TabIndex = 128
        Me.lbUnidadMedida3.Text = "U"
        '
        'tpStock
        '
        Me.tpStock.Controls.Add(Me.lvStock)
        Me.tpStock.Controls.Add(Me.StockAlmacen)
        Me.tpStock.Controls.Add(Me.lbUnidadMedida1)
        Me.tpStock.Controls.Add(Me.Label4)
        Me.tpStock.Location = New System.Drawing.Point(4, 26)
        Me.tpStock.Name = "tpStock"
        Me.tpStock.Size = New System.Drawing.Size(915, 303)
        Me.tpStock.TabIndex = 2
        Me.tpStock.Text = "STOCK"
        Me.tpStock.UseVisualStyleBackColor = True
        '
        'lvStock
        '
        Me.lvStock.AllowColumnReorder = True
        Me.lvStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvStock.AutoArrange = False
        Me.lvStock.BackgroundImageTiled = True
        Me.lvStock.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidAlmacen, Me.lvAlmacen, Me.lvCantidadA})
        Me.lvStock.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lvStock.FullRowSelect = True
        Me.lvStock.GridLines = True
        Me.lvStock.HideSelection = False
        Me.lvStock.Location = New System.Drawing.Point(14, 14)
        Me.lvStock.MultiSelect = False
        Me.lvStock.Name = "lvStock"
        Me.lvStock.ShowItemToolTips = True
        Me.lvStock.Size = New System.Drawing.Size(889, 257)
        Me.lvStock.TabIndex = 129
        Me.lvStock.UseCompatibleStateImageBehavior = False
        Me.lvStock.View = System.Windows.Forms.View.Details
        '
        'lvidAlmacen
        '
        Me.lvidAlmacen.Text = "idAlmacen"
        Me.lvidAlmacen.Width = 0
        '
        'lvAlmacen
        '
        Me.lvAlmacen.Text = "ALMACÉN"
        Me.lvAlmacen.Width = 742
        '
        'lvCantidadA
        '
        Me.lvCantidadA.Text = "CANTIDAD"
        Me.lvCantidadA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidadA.Width = 121
        '
        'lbUnidadMedida1
        '
        Me.lbUnidadMedida1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbUnidadMedida1.AutoSize = True
        Me.lbUnidadMedida1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidadMedida1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidadMedida1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidadMedida1.Location = New System.Drawing.Point(889, 279)
        Me.lbUnidadMedida1.Name = "lbUnidadMedida1"
        Me.lbUnidadMedida1.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidadMedida1.TabIndex = 128
        Me.lbUnidadMedida1.Text = "U"
        '
        'tpEsacandallos
        '
        Me.tpEsacandallos.Controls.Add(Me.lvEscandallos)
        Me.tpEsacandallos.Controls.Add(Me.Label15)
        Me.tpEsacandallos.Location = New System.Drawing.Point(4, 26)
        Me.tpEsacandallos.Name = "tpEsacandallos"
        Me.tpEsacandallos.Size = New System.Drawing.Size(915, 303)
        Me.tpEsacandallos.TabIndex = 1
        Me.tpEsacandallos.Text = "ESCANDALLOS"
        Me.tpEsacandallos.UseVisualStyleBackColor = True
        '
        'lvEscandallos
        '
        Me.lvEscandallos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEscandallos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidEscandallo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCantidadE})
        Me.lvEscandallos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEscandallos.FullRowSelect = True
        Me.lvEscandallos.GridLines = True
        Me.lvEscandallos.Location = New System.Drawing.Point(20, 41)
        Me.lvEscandallos.MultiSelect = False
        Me.lvEscandallos.Name = "lvEscandallos"
        Me.lvEscandallos.Size = New System.Drawing.Size(862, 213)
        Me.lvEscandallos.TabIndex = 172
        Me.lvEscandallos.UseCompatibleStateImageBehavior = False
        Me.lvEscandallos.View = System.Windows.Forms.View.Details
        '
        'lvidEscandallo
        '
        Me.lvidEscandallo.Text = "ID"
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 118
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 528
        '
        'lvCantidadE
        '
        Me.lvCantidadE.Text = "CANTIDAD"
        Me.lvCantidadE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidadE.Width = 107
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(20, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(400, 17)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "Artículos que incluyen la manteria prima como componente"
        '
        'tpDesglose
        '
        Me.tpDesglose.Controls.Add(Me.Label42)
        Me.tpDesglose.Controls.Add(Me.cbVersion)
        Me.tpDesglose.Controls.Add(Me.lvConceptos)
        Me.tpDesglose.Controls.Add(Me.Label16)
        Me.tpDesglose.Controls.Add(Me.bVerEscandallo)
        Me.tpDesglose.Location = New System.Drawing.Point(4, 26)
        Me.tpDesglose.Name = "tpDesglose"
        Me.tpDesglose.Size = New System.Drawing.Size(915, 303)
        Me.tpDesglose.TabIndex = 4
        Me.tpDesglose.Text = "DESGLOSE"
        Me.tpDesglose.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(544, 12)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 17)
        Me.Label42.TabIndex = 184
        Me.Label42.Text = "VERSIÓN"
        '
        'cbVersion
        '
        Me.cbVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbVersion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVersion.FormattingEnabled = True
        Me.cbVersion.Location = New System.Drawing.Point(624, 8)
        Me.cbVersion.Name = "cbVersion"
        Me.cbVersion.Size = New System.Drawing.Size(66, 25)
        Me.cbVersion.Sorted = True
        Me.cbVersion.TabIndex = 183
        '
        'lvConceptos
        '
        Me.lvConceptos.AllowColumnReorder = True
        Me.lvConceptos.AllowDrop = True
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.AutoArrange = False
        Me.lvConceptos.BackgroundImageTiled = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidConcepto, Me.lvSeccion, Me.codConcepto, Me.lvConcepto, Me.lvCantidad, Me.lvCoste, Me.lvObservaciones, Me.lvidArticulo})
        Me.lvConceptos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(20, 41)
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(862, 228)
        Me.lvConceptos.TabIndex = 174
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvSeccion
        '
        Me.lvSeccion.Text = "SECCIÓN"
        Me.lvSeccion.Width = 112
        '
        'codConcepto
        '
        Me.codConcepto.Text = "CÓDIGO"
        Me.codConcepto.Width = 93
        '
        'lvConcepto
        '
        Me.lvConcepto.Text = "MATERIA PRIMA"
        Me.lvConcepto.Width = 253
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 74
        '
        'lvCoste
        '
        Me.lvCoste.Text = "COSTE U."
        Me.lvCoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCoste.Width = 89
        '
        'lvObservaciones
        '
        Me.lvObservaciones.Text = "OBSERVACIONES"
        Me.lvObservaciones.Width = 202
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(20, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(257, 17)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Artículos que componen el escandallo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'bNuevaComposicion
        '
        Me.bNuevaComposicion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevaComposicion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevaComposicion.Location = New System.Drawing.Point(385, 22)
        Me.bNuevaComposicion.Name = "bNuevaComposicion"
        Me.bNuevaComposicion.Size = New System.Drawing.Size(85, 50)
        Me.bNuevaComposicion.TabIndex = 5
        Me.bNuevaComposicion.Text = "NUEVA OPCIÓN"
        Me.bNuevaComposicion.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "CÓDIGO"
        Me.ColumnHeader2.Width = 118
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ARTICULO"
        Me.ColumnHeader3.Width = 528
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "CANTIDAD"
        Me.ColumnHeader4.Width = 107
        '
        'ckDomesticos2
        '
        Me.ckDomesticos2.AutoSize = True
        Me.ckDomesticos2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckDomesticos2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDomesticos2.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckDomesticos2.Location = New System.Drawing.Point(4, 287)
        Me.ckDomesticos2.Name = "ckDomesticos2"
        Me.ckDomesticos2.Size = New System.Drawing.Size(119, 21)
        Me.ckDomesticos2.TabIndex = 177
        Me.ckDomesticos2.Text = "DOMESTICOS 2"
        Me.ckDomesticos2.UseVisualStyleBackColor = True
        '
        'GestionArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bAlmacen
        Me.ClientSize = New System.Drawing.Size(956, 835)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EDITAR ARTÍCULO"
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        Me.gbVenta.ResumeLayout(False)
        Me.gbVenta.PerformLayout()
        Me.gbCoste.ResumeLayout(False)
        Me.gbCoste.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbdatos.ResumeLayout(False)
        Me.tpTraducciones.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tpProveedores.ResumeLayout(False)
        Me.tpProveedores.PerformLayout()
        Me.tpVentas.ResumeLayout(False)
        Me.tpVentas.PerformLayout()
        Me.tpPreciosXcantidad.ResumeLayout(False)
        Me.tpPreciosXcantidad.PerformLayout()
        Me.tpStock.ResumeLayout(False)
        Me.tpStock.PerformLayout()
        Me.tpEsacandallos.ResumeLayout(False)
        Me.tpEsacandallos.PerformLayout()
        Me.tpDesglose.ResumeLayout(False)
        Me.tpDesglose.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents idArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbUnidadMedida As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents StockAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents StockMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PrecioUnitarioC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbFechaBaja As System.Windows.Forms.Label
    Friend WithEvents dtpFechaBaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPrecioC As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbdatos As System.Windows.Forms.TabControl
    Friend WithEvents tpProveedores As System.Windows.Forms.TabPage
    Friend WithEvents tpEsacandallos As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents tpStock As System.Windows.Forms.TabPage
    Friend WithEvents lvArticuloProv As System.Windows.Forms.ListView
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvStock As System.Windows.Forms.ListView
    Friend WithEvents lvEscandallos As System.Windows.Forms.ListView
    Friend WithEvents lvidEscandallo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidadE As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bUnidades As System.Windows.Forms.Button
    Friend WithEvents lbMonedaC As System.Windows.Forms.Label
    Friend WithEvents bBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents bAlmacen As System.Windows.Forms.Button
    Friend WithEvents StockInicial As System.Windows.Forms.TextBox
    Friend WithEvents lbStockInicial As System.Windows.Forms.Label
    Friend WithEvents lbUnidadMedida2 As System.Windows.Forms.Label
    Friend WithEvents ckVendible As System.Windows.Forms.CheckBox
    Friend WithEvents ckComprable As System.Windows.Forms.CheckBox
    Friend WithEvents bTipos As System.Windows.Forms.Button
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ArticuloEN As System.Windows.Forms.TextBox
    Friend WithEvents DescripcionEN As System.Windows.Forms.TextBox
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbMonedaV As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPrecioV As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PrecioUnitarioV As System.Windows.Forms.TextBox
    Friend WithEvents ckOpcion As System.Windows.Forms.CheckBox
    Friend WithEvents PrecioOpcion As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaO As System.Windows.Forms.Label
    Friend WithEvents gbCoste As System.Windows.Forms.GroupBox
    Friend WithEvents gbVenta As System.Windows.Forms.GroupBox
    Friend WithEvents ckSubEnsamblado As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvidAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidadA As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpTraducciones As System.Windows.Forms.TabPage
    Friend WithEvents cbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bSecciones As System.Windows.Forms.Button
    Friend WithEvents ckEscandallo As System.Windows.Forms.CheckBox
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents ckMateriaPrima As System.Windows.Forms.CheckBox
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents tpDesglose As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents codConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCoste As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVerEscandallo As System.Windows.Forms.Button
    Friend WithEvents bNuevaComposicion As System.Windows.Forms.Button
    Friend WithEvents Volumen As System.Windows.Forms.TextBox
    Friend WithEvents KilosNetos As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents KilosBrutos As System.Windows.Forms.TextBox
    Friend WithEvents Ancho As System.Windows.Forms.TextBox
    Friend WithEvents Alto As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Bultos As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Fondo As System.Windows.Forms.TextBox
    Friend WithEvents ckProduccionSeparada As System.Windows.Forms.CheckBox
    Friend WithEvents bVerProveedor As System.Windows.Forms.Button
    Friend WithEvents ckConNumSerie As System.Windows.Forms.CheckBox
    Friend WithEvents ckConNumSerie2 As System.Windows.Forms.CheckBox
    Friend WithEvents lbVentaIndependiente As System.Windows.Forms.Label
    Friend WithEvents tpPreciosXcantidad As System.Windows.Forms.TabPage
    Friend WithEvents lvPreciosXCantidad As System.Windows.Forms.ListView
    Friend WithEvents lvidPrecioRango As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProveedorPR As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRango As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecioPR As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbProveedorPC As System.Windows.Forms.ComboBox
    Friend WithEvents Desde As System.Windows.Forms.TextBox
    Friend WithEvents Hasta As System.Windows.Forms.TextBox
    Friend WithEvents PrecioPC As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaPC As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lbUnidadMedida3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lvFechaPR As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbVersion As System.Windows.Forms.ComboBox
    Friend WithEvents tpVentas As System.Windows.Forms.TabPage
    Friend WithEvents lvArticulosVendidos As System.Windows.Forms.ListView
    Friend WithEvents lvClienteA As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodAArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpArticulosVendidosHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents dtpArticulosVendidosDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents ContadorVendidos As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents lbCambioVendidos As System.Windows.Forms.Label
    Friend WithEvents CantidadVendidos As System.Windows.Forms.TextBox
    Friend WithEvents TotalVendidos As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents lvidCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbUnidadMedida4 As System.Windows.Forms.Label
    Friend WithEvents ckVersiones As System.Windows.Forms.CheckBox
    Friend WithEvents txCantidadTotalPedida As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txCantidadTotalRecibida As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txCantidadPendiente As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents listaProv As System.Windows.Forms.ListBox
    Friend WithEvents lbUnidadMedida1 As System.Windows.Forms.Label
    Friend WithEvents ckRecambio As System.Windows.Forms.CheckBox
    Friend WithEvents ckDomesticos2 As CheckBox
End Class
