<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionStock))
        Me.bSalir = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.cbNombre = New System.Windows.Forms.ComboBox
        Me.cbcodArticulo = New System.Windows.Forms.ComboBox
        Me.gbArticulo2 = New System.Windows.Forms.GroupBox
        Me.PrecioUnitario = New System.Windows.Forms.TextBox
        Me.lbMonedaC = New System.Windows.Forms.Label
        Me.rbRegularizacion = New System.Windows.Forms.RadioButton
        Me.rbMovimiento = New System.Windows.Forms.RadioButton
        Me.cbAlmacen = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.bAlmacen = New System.Windows.Forms.Button
        Me.lbPrecio = New System.Windows.Forms.Label
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Movimiento = New System.Windows.Forms.TextBox
        Me.StockMinimo = New System.Windows.Forms.TextBox
        Me.CantidadTotal = New System.Windows.Forms.TextBox
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.lbUnidad3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbUnidad2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lvMovimientosArticulo = New System.Windows.Forms.ListView
        Me.lvidStock = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvMovimiento = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedidoProv = New System.Windows.Forms.ColumnHeader
        Me.lvnumAlbaran = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedido = New System.Windows.Forms.ColumnHeader
        Me.lvCant = New System.Windows.Forms.ColumnHeader
        Me.lvProveedorA = New System.Windows.Forms.ColumnHeader
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbUnidades = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.bGuardarConcepto = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.rbArticulo = New System.Windows.Forms.RadioButton
        Me.rvFecha = New System.Windows.Forms.RadioButton
        Me.gbArticulo1 = New System.Windows.Forms.GroupBox
        Me.bBuscarArticulo = New System.Windows.Forms.Button
        Me.cbProveedorA = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.bLimpiarBusqueda = New System.Windows.Forms.Button
        Me.cbMovimientoA = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbFecha1 = New System.Windows.Forms.GroupBox
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.cbPRoveedor = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbMovimientoF = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.gbFecha2 = New System.Windows.Forms.GroupBox
        Me.lvMovimientosFecha = New System.Windows.Forms.ListView
        Me.lvidstockF = New System.Windows.Forms.ColumnHeader
        Me.lvCodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvFechaF = New System.Windows.Forms.ColumnHeader
        Me.lvCantidadF = New System.Windows.Forms.ColumnHeader
        Me.lvMovimientoF = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedidoProvF = New System.Windows.Forms.ColumnHeader
        Me.lvnumAlbaranF = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedidoF = New System.Windows.Forms.ColumnHeader
        Me.lvCantF = New System.Windows.Forms.ColumnHeader
        Me.lvProveedor = New System.Windows.Forms.ColumnHeader
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bLimpiarTodo = New System.Windows.Forms.Button
        Me.gbArticulo2.SuspendLayout()
        Me.gbArticulo1.SuspendLayout()
        Me.gbFecha1.SuspendLayout()
        Me.gbFecha2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(829, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(715, 23)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'cbNombre
        '
        Me.cbNombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNombre.FormattingEnabled = True
        Me.cbNombre.Location = New System.Drawing.Point(96, 54)
        Me.cbNombre.Name = "cbNombre"
        Me.cbNombre.Size = New System.Drawing.Size(459, 25)
        Me.cbNombre.TabIndex = 2
        '
        'cbcodArticulo
        '
        Me.cbcodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodArticulo.FormattingEnabled = True
        Me.cbcodArticulo.Location = New System.Drawing.Point(96, 25)
        Me.cbcodArticulo.Name = "cbcodArticulo"
        Me.cbcodArticulo.Size = New System.Drawing.Size(138, 25)
        Me.cbcodArticulo.Sorted = True
        Me.cbcodArticulo.TabIndex = 0
        '
        'gbArticulo2
        '
        Me.gbArticulo2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbArticulo2.Controls.Add(Me.PrecioUnitario)
        Me.gbArticulo2.Controls.Add(Me.lbMonedaC)
        Me.gbArticulo2.Controls.Add(Me.rbRegularizacion)
        Me.gbArticulo2.Controls.Add(Me.rbMovimiento)
        Me.gbArticulo2.Controls.Add(Me.cbAlmacen)
        Me.gbArticulo2.Controls.Add(Me.Label11)
        Me.gbArticulo2.Controls.Add(Me.bAlmacen)
        Me.gbArticulo2.Controls.Add(Me.lbPrecio)
        Me.gbArticulo2.Controls.Add(Me.bLimpiar)
        Me.gbArticulo2.Controls.Add(Me.Label3)
        Me.gbArticulo2.Controls.Add(Me.dtpFecha)
        Me.gbArticulo2.Controls.Add(Me.Movimiento)
        Me.gbArticulo2.Controls.Add(Me.StockMinimo)
        Me.gbArticulo2.Controls.Add(Me.CantidadTotal)
        Me.gbArticulo2.Controls.Add(Me.Cantidad)
        Me.gbArticulo2.Controls.Add(Me.lbUnidad3)
        Me.gbArticulo2.Controls.Add(Me.Label5)
        Me.gbArticulo2.Controls.Add(Me.lbUnidad2)
        Me.gbArticulo2.Controls.Add(Me.Label7)
        Me.gbArticulo2.Controls.Add(Me.lvMovimientosArticulo)
        Me.gbArticulo2.Controls.Add(Me.Label6)
        Me.gbArticulo2.Controls.Add(Me.lbUnidades)
        Me.gbArticulo2.Controls.Add(Me.Label2)
        Me.gbArticulo2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArticulo2.Location = New System.Drawing.Point(6, 541)
        Me.gbArticulo2.Name = "gbArticulo2"
        Me.gbArticulo2.Size = New System.Drawing.Size(921, 225)
        Me.gbArticulo2.TabIndex = 5
        Me.gbArticulo2.TabStop = False
        Me.gbArticulo2.Text = "INSERTAR"
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioUnitario.Location = New System.Drawing.Point(472, 48)
        Me.PrecioUnitario.MaxLength = 15
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.Size = New System.Drawing.Size(83, 23)
        Me.PrecioUnitario.TabIndex = 3
        Me.PrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbMonedaC
        '
        Me.lbMonedaC.AutoSize = True
        Me.lbMonedaC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMonedaC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaC.Location = New System.Drawing.Point(558, 51)
        Me.lbMonedaC.Name = "lbMonedaC"
        Me.lbMonedaC.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaC.TabIndex = 172
        Me.lbMonedaC.Text = "€"
        '
        'rbRegularizacion
        '
        Me.rbRegularizacion.AutoSize = True
        Me.rbRegularizacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRegularizacion.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbRegularizacion.Location = New System.Drawing.Point(724, 22)
        Me.rbRegularizacion.Name = "rbRegularizacion"
        Me.rbRegularizacion.Size = New System.Drawing.Size(136, 21)
        Me.rbRegularizacion.TabIndex = 5
        Me.rbRegularizacion.TabStop = True
        Me.rbRegularizacion.Text = "REGULARIZACIÓN"
        Me.rbRegularizacion.UseVisualStyleBackColor = True
        '
        'rbMovimiento
        '
        Me.rbMovimiento.AutoSize = True
        Me.rbMovimiento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMovimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbMovimiento.Location = New System.Drawing.Point(612, 22)
        Me.rbMovimiento.Name = "rbMovimiento"
        Me.rbMovimiento.Size = New System.Drawing.Size(107, 21)
        Me.rbMovimiento.TabIndex = 4
        Me.rbMovimiento.TabStop = True
        Me.rbMovimiento.Text = "MOVIMIENTO"
        Me.rbMovimiento.UseVisualStyleBackColor = True
        '
        'cbAlmacen
        '
        Me.cbAlmacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(660, 47)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(200, 25)
        Me.cbAlmacen.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(589, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 171
        Me.Label11.Text = "ALMACÉN"
        '
        'bAlmacen
        '
        Me.bAlmacen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAlmacen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAlmacen.Location = New System.Drawing.Point(881, 47)
        Me.bAlmacen.Name = "bAlmacen"
        Me.bAlmacen.Size = New System.Drawing.Size(27, 25)
        Me.bAlmacen.TabIndex = 8
        Me.bAlmacen.Text = "...."
        Me.bAlmacen.UseVisualStyleBackColor = True
        '
        'lbPrecio
        '
        Me.lbPrecio.AutoSize = True
        Me.lbPrecio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrecio.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbPrecio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbPrecio.Location = New System.Drawing.Point(397, 51)
        Me.lbPrecio.Name = "lbPrecio"
        Me.lbPrecio.Size = New System.Drawing.Size(56, 17)
        Me.lbPrecio.TabIndex = 164
        Me.lbPrecio.Text = "PRECIO"
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(881, 20)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 7
        Me.bLimpiar.UseVisualStyleBackColor = True
        Me.bLimpiar.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 17)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "FECHA"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(96, 21)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(110, 23)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'Movimiento
        '
        Me.Movimiento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Movimiento.Location = New System.Drawing.Point(96, 48)
        Me.Movimiento.MaxLength = 50
        Me.Movimiento.Name = "Movimiento"
        Me.Movimiento.Size = New System.Drawing.Size(300, 23)
        Me.Movimiento.TabIndex = 1
        '
        'StockMinimo
        '
        Me.StockMinimo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StockMinimo.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.StockMinimo.Location = New System.Drawing.Point(502, 184)
        Me.StockMinimo.MaxLength = 50
        Me.StockMinimo.Name = "StockMinimo"
        Me.StockMinimo.ReadOnly = True
        Me.StockMinimo.Size = New System.Drawing.Size(87, 22)
        Me.StockMinimo.TabIndex = 0
        Me.StockMinimo.TabStop = False
        Me.StockMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CantidadTotal
        '
        Me.CantidadTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CantidadTotal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadTotal.Location = New System.Drawing.Point(787, 184)
        Me.CantidadTotal.MaxLength = 50
        Me.CantidadTotal.Name = "CantidadTotal"
        Me.CantidadTotal.ReadOnly = True
        Me.CantidadTotal.Size = New System.Drawing.Size(87, 22)
        Me.CantidadTotal.TabIndex = 21
        Me.CantidadTotal.TabStop = False
        Me.CantidadTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cantidad
        '
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.Location = New System.Drawing.Point(472, 21)
        Me.Cantidad.MaxLength = 50
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(83, 23)
        Me.Cantidad.TabIndex = 2
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbUnidad3
        '
        Me.lbUnidad3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbUnidad3.AutoSize = True
        Me.lbUnidad3.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lbUnidad3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad3.Location = New System.Drawing.Point(592, 187)
        Me.lbUnidad3.Name = "lbUnidad3"
        Me.lbUnidad3.Size = New System.Drawing.Size(19, 17)
        Me.lbUnidad3.TabIndex = 161
        Me.lbUnidad3.Text = "u."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(6, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "MOVIMIENTO"
        '
        'lbUnidad2
        '
        Me.lbUnidad2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbUnidad2.AutoSize = True
        Me.lbUnidad2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lbUnidad2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad2.Location = New System.Drawing.Point(877, 187)
        Me.lbUnidad2.Name = "lbUnidad2"
        Me.lbUnidad2.Size = New System.Drawing.Size(19, 17)
        Me.lbUnidad2.TabIndex = 161
        Me.lbUnidad2.Text = "u."
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(401, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 17)
        Me.Label7.TabIndex = 161
        Me.Label7.Text = "STOCK MÍNIMO"
        '
        'lvMovimientosArticulo
        '
        Me.lvMovimientosArticulo.AllowColumnReorder = True
        Me.lvMovimientosArticulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMovimientosArticulo.AutoArrange = False
        Me.lvMovimientosArticulo.BackgroundImageTiled = True
        Me.lvMovimientosArticulo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidStock, Me.lvFecha, Me.lvCantidad, Me.lvMovimiento, Me.lvnumPedidoProv, Me.lvnumAlbaran, Me.lvnumPedido, Me.lvCant, Me.lvProveedorA})
        Me.lvMovimientosArticulo.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lvMovimientosArticulo.FullRowSelect = True
        Me.lvMovimientosArticulo.GridLines = True
        Me.lvMovimientosArticulo.HideSelection = False
        Me.lvMovimientosArticulo.Location = New System.Drawing.Point(6, 79)
        Me.lvMovimientosArticulo.MultiSelect = False
        Me.lvMovimientosArticulo.Name = "lvMovimientosArticulo"
        Me.lvMovimientosArticulo.ShowItemToolTips = True
        Me.lvMovimientosArticulo.Size = New System.Drawing.Size(903, 96)
        Me.lvMovimientosArticulo.TabIndex = 9
        Me.lvMovimientosArticulo.UseCompatibleStateImageBehavior = False
        Me.lvMovimientosArticulo.View = System.Windows.Forms.View.Details
        '
        'lvidStock
        '
        Me.lvidStock.Text = "idStock"
        Me.lvidStock.Width = 0
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 140
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 100
        '
        'lvMovimiento
        '
        Me.lvMovimiento.Text = "MOVIMIENTO"
        Me.lvMovimiento.Width = 490
        '
        'lvnumPedidoProv
        '
        Me.lvnumPedidoProv.Text = "PEDIDO PROV"
        Me.lvnumPedidoProv.Width = 0
        '
        'lvnumAlbaran
        '
        Me.lvnumAlbaran.Text = "ALBARÁN"
        Me.lvnumAlbaran.Width = 0
        '
        'lvnumPedido
        '
        Me.lvnumPedido.Text = "PEDIDO"
        Me.lvnumPedido.Width = 0
        '
        'lvCant
        '
        Me.lvCant.Text = "CANTIDAD"
        Me.lvCant.Width = 0
        '
        'lvProveedorA
        '
        Me.lvProveedorA.Text = "PROVEEDOR"
        Me.lvProveedorA.Width = 140
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(673, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 17)
        Me.Label6.TabIndex = 161
        Me.Label6.Text = "CANTIDAD TOTAL"
        '
        'lbUnidades
        '
        Me.lbUnidades.AutoSize = True
        Me.lbUnidades.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lbUnidades.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidades.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidades.Location = New System.Drawing.Point(558, 24)
        Me.lbUnidades.Name = "lbUnidades"
        Me.lbUnidades.Size = New System.Drawing.Size(19, 17)
        Me.lbUnidades.TabIndex = 161
        Me.lbUnidades.Text = "u."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(383, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "CANTIDAD"
        '
        'bGuardarConcepto
        '
        Me.bGuardarConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardarConcepto.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardarConcepto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardarConcepto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardarConcepto.Location = New System.Drawing.Point(494, 23)
        Me.bGuardarConcepto.Name = "bGuardarConcepto"
        Me.bGuardarConcepto.Size = New System.Drawing.Size(85, 50)
        Me.bGuardarConcepto.TabIndex = 4
        Me.bGuardarConcepto.Text = "GUARDAR"
        Me.bGuardarConcepto.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(26, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "CÓDIGO"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(13, 27)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(48, 17)
        Me.Label41.TabIndex = 164
        Me.Label41.Text = "DESDE"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(67, 24)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(107, 23)
        Me.dtpDesde.TabIndex = 0
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'rbArticulo
        '
        Me.rbArticulo.AutoSize = True
        Me.rbArticulo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbArticulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbArticulo.Location = New System.Drawing.Point(21, 113)
        Me.rbArticulo.Name = "rbArticulo"
        Me.rbArticulo.Size = New System.Drawing.Size(135, 24)
        Me.rbArticulo.TabIndex = 0
        Me.rbArticulo.TabStop = True
        Me.rbArticulo.Text = "POR ARTÍCULO"
        Me.rbArticulo.UseVisualStyleBackColor = True
        '
        'rvFecha
        '
        Me.rvFecha.AutoSize = True
        Me.rvFecha.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rvFecha.ForeColor = System.Drawing.Color.DarkBlue
        Me.rvFecha.Location = New System.Drawing.Point(176, 113)
        Me.rvFecha.Name = "rvFecha"
        Me.rvFecha.Size = New System.Drawing.Size(110, 24)
        Me.rvFecha.TabIndex = 1
        Me.rvFecha.TabStop = True
        Me.rvFecha.Text = "POR FECHA"
        Me.rvFecha.UseVisualStyleBackColor = True
        '
        'gbArticulo1
        '
        Me.gbArticulo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbArticulo1.Controls.Add(Me.bBuscarArticulo)
        Me.gbArticulo1.Controls.Add(Me.cbProveedorA)
        Me.gbArticulo1.Controls.Add(Me.Label14)
        Me.gbArticulo1.Controls.Add(Me.bLimpiarBusqueda)
        Me.gbArticulo1.Controls.Add(Me.cbMovimientoA)
        Me.gbArticulo1.Controls.Add(Me.cbcodArticulo)
        Me.gbArticulo1.Controls.Add(Me.Label10)
        Me.gbArticulo1.Controls.Add(Me.Label4)
        Me.gbArticulo1.Controls.Add(Me.cbNombre)
        Me.gbArticulo1.Controls.Add(Me.Label1)
        Me.gbArticulo1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArticulo1.Location = New System.Drawing.Point(6, 426)
        Me.gbArticulo1.Name = "gbArticulo1"
        Me.gbArticulo1.Size = New System.Drawing.Size(921, 91)
        Me.gbArticulo1.TabIndex = 4
        Me.gbArticulo1.TabStop = False
        Me.gbArticulo1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticulo.Location = New System.Drawing.Point(247, 25)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticulo.TabIndex = 1
        Me.bBuscarArticulo.UseVisualStyleBackColor = True
        '
        'cbProveedorA
        '
        Me.cbProveedorA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbProveedorA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedorA.FormattingEnabled = True
        Me.cbProveedorA.Location = New System.Drawing.Point(660, 54)
        Me.cbProveedorA.Name = "cbProveedorA"
        Me.cbProveedorA.Size = New System.Drawing.Size(200, 25)
        Me.cbProveedorA.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(572, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 17)
        Me.Label14.TabIndex = 164
        Me.Label14.Text = "PROVEEDOR"
        '
        'bLimpiarBusqueda
        '
        Me.bLimpiarBusqueda.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiarBusqueda.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiarBusqueda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiarBusqueda.Location = New System.Drawing.Point(881, 25)
        Me.bLimpiarBusqueda.Name = "bLimpiarBusqueda"
        Me.bLimpiarBusqueda.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiarBusqueda.TabIndex = 5
        Me.bLimpiarBusqueda.UseVisualStyleBackColor = True
        Me.bLimpiarBusqueda.Visible = False
        '
        'cbMovimientoA
        '
        Me.cbMovimientoA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbMovimientoA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovimientoA.FormattingEnabled = True
        Me.cbMovimientoA.Location = New System.Drawing.Point(660, 26)
        Me.cbMovimientoA.Name = "cbMovimientoA"
        Me.cbMovimientoA.Size = New System.Drawing.Size(200, 25)
        Me.cbMovimientoA.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(569, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 17)
        Me.Label10.TabIndex = 164
        Me.Label10.Text = "MOVIMIENTO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(7, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "DESCRIPCIÓN"
        '
        'gbFecha1
        '
        Me.gbFecha1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFecha1.Controls.Add(Me.dtpHasta)
        Me.gbFecha1.Controls.Add(Me.cbPRoveedor)
        Me.gbFecha1.Controls.Add(Me.Label13)
        Me.gbFecha1.Controls.Add(Me.cbMovimientoF)
        Me.gbFecha1.Controls.Add(Me.Label9)
        Me.gbFecha1.Controls.Add(Me.Label8)
        Me.gbFecha1.Controls.Add(Me.dtpDesde)
        Me.gbFecha1.Controls.Add(Me.Label41)
        Me.gbFecha1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFecha1.Location = New System.Drawing.Point(6, 150)
        Me.gbFecha1.Name = "gbFecha1"
        Me.gbFecha1.Size = New System.Drawing.Size(921, 57)
        Me.gbFecha1.TabIndex = 2
        Me.gbFecha1.TabStop = False
        Me.gbFecha1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(231, 24)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(107, 23)
        Me.dtpHasta.TabIndex = 1
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'cbPRoveedor
        '
        Me.cbPRoveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbPRoveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPRoveedor.FormattingEnabled = True
        Me.cbPRoveedor.Location = New System.Drawing.Point(684, 23)
        Me.cbPRoveedor.Name = "cbPRoveedor"
        Me.cbPRoveedor.Size = New System.Drawing.Size(224, 25)
        Me.cbPRoveedor.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(596, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 17)
        Me.Label13.TabIndex = 164
        Me.Label13.Text = "PROVEEDOR"
        '
        'cbMovimientoF
        '
        Me.cbMovimientoF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbMovimientoF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMovimientoF.FormattingEnabled = True
        Me.cbMovimientoF.Location = New System.Drawing.Point(436, 23)
        Me.cbMovimientoF.Name = "cbMovimientoF"
        Me.cbMovimientoF.Size = New System.Drawing.Size(158, 25)
        Me.cbMovimientoF.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(346, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 17)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "MOVIMIENTO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(181, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 17)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "HASTA"
        '
        'gbFecha2
        '
        Me.gbFecha2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFecha2.Controls.Add(Me.lvMovimientosFecha)
        Me.gbFecha2.Controls.Add(Me.Contador)
        Me.gbFecha2.Controls.Add(Me.Label12)
        Me.gbFecha2.Location = New System.Drawing.Point(6, 207)
        Me.gbFecha2.Name = "gbFecha2"
        Me.gbFecha2.Size = New System.Drawing.Size(921, 201)
        Me.gbFecha2.TabIndex = 3
        Me.gbFecha2.TabStop = False
        '
        'lvMovimientosFecha
        '
        Me.lvMovimientosFecha.AllowColumnReorder = True
        Me.lvMovimientosFecha.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMovimientosFecha.AutoArrange = False
        Me.lvMovimientosFecha.BackgroundImageTiled = True
        Me.lvMovimientosFecha.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidstockF, Me.lvCodArticulo, Me.lvArticulo, Me.lvFechaF, Me.lvCantidadF, Me.lvMovimientoF, Me.lvnumPedidoProvF, Me.lvnumAlbaranF, Me.lvnumPedidoF, Me.lvCantF, Me.lvProveedor})
        Me.lvMovimientosFecha.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lvMovimientosFecha.FullRowSelect = True
        Me.lvMovimientosFecha.GridLines = True
        Me.lvMovimientosFecha.HideSelection = False
        Me.lvMovimientosFecha.Location = New System.Drawing.Point(6, 19)
        Me.lvMovimientosFecha.MultiSelect = False
        Me.lvMovimientosFecha.Name = "lvMovimientosFecha"
        Me.lvMovimientosFecha.ShowItemToolTips = True
        Me.lvMovimientosFecha.Size = New System.Drawing.Size(904, 138)
        Me.lvMovimientosFecha.TabIndex = 0
        Me.lvMovimientosFecha.UseCompatibleStateImageBehavior = False
        Me.lvMovimientosFecha.View = System.Windows.Forms.View.Details
        '
        'lvidstockF
        '
        Me.lvidstockF.Text = "idStock"
        Me.lvidstockF.Width = 0
        '
        'lvCodArticulo
        '
        Me.lvCodArticulo.Text = "CÓDIGO"
        Me.lvCodArticulo.Width = 73
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 237
        '
        'lvFechaF
        '
        Me.lvFechaF.Text = "FECHA"
        Me.lvFechaF.Width = 140
        '
        'lvCantidadF
        '
        Me.lvCantidadF.Text = "CANTIDAD"
        Me.lvCantidadF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidadF.Width = 81
        '
        'lvMovimientoF
        '
        Me.lvMovimientoF.Text = "MOVIMIENTO"
        Me.lvMovimientoF.Width = 214
        '
        'lvnumPedidoProvF
        '
        Me.lvnumPedidoProvF.Text = "PEDIDO PROV"
        Me.lvnumPedidoProvF.Width = 0
        '
        'lvnumAlbaranF
        '
        Me.lvnumAlbaranF.Text = "ALBARÁN"
        Me.lvnumAlbaranF.Width = 0
        '
        'lvnumPedidoF
        '
        Me.lvnumPedidoF.Text = "PEDIDO"
        Me.lvnumPedidoF.Width = 0
        '
        'lvCantF
        '
        Me.lvCantF.Text = "CANTIDAD"
        Me.lvCantF.Width = 0
        '
        'lvProveedor
        '
        Me.lvProveedor.Text = "PROVEEDOR"
        Me.lvProveedor.Width = 123
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.Location = New System.Drawing.Point(757, 166)
        Me.Contador.MaxLength = 50
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(87, 22)
        Me.Contador.TabIndex = 21
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(657, 170)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 17)
        Me.Label12.TabIndex = 161
        Me.Label12.Text = "MOVIMIENTOS"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'bLimpiarTodo
        '
        Me.bLimpiarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiarTodo.Cursor = System.Windows.Forms.Cursors.Default
        Me.bLimpiarTodo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiarTodo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiarTodo.Location = New System.Drawing.Point(605, 23)
        Me.bLimpiarTodo.Name = "bLimpiarTodo"
        Me.bLimpiarTodo.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiarTodo.TabIndex = 4
        Me.bLimpiarTodo.Text = "LIMPIAR"
        Me.bLimpiarTodo.UseVisualStyleBackColor = True
        '
        'GestionStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 778)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbFecha2)
        Me.Controls.Add(Me.gbArticulo2)
        Me.Controls.Add(Me.bLimpiarTodo)
        Me.Controls.Add(Me.bGuardarConcepto)
        Me.Controls.Add(Me.gbFecha1)
        Me.Controls.Add(Me.gbArticulo1)
        Me.Controls.Add(Me.rvFecha)
        Me.Controls.Add(Me.rbArticulo)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bImprimir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE STOCK"
        Me.gbArticulo2.ResumeLayout(False)
        Me.gbArticulo2.PerformLayout()
        Me.gbArticulo1.ResumeLayout(False)
        Me.gbArticulo1.PerformLayout()
        Me.gbFecha1.ResumeLayout(False)
        Me.gbFecha1.PerformLayout()
        Me.gbFecha2.ResumeLayout(False)
        Me.gbFecha2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents cbNombre As System.Windows.Forms.ComboBox
    Friend WithEvents cbcodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents gbArticulo2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvMovimientosArticulo As System.Windows.Forms.ListView
    Friend WithEvents lvidStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMovimiento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedidoProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bGuardarConcepto As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Movimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbUnidades As System.Windows.Forms.Label
    Friend WithEvents CantidadTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbUnidad2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StockMinimo As System.Windows.Forms.TextBox
    Friend WithEvents lbUnidad3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents rvFecha As System.Windows.Forms.RadioButton
    Friend WithEvents gbArticulo1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbFecha1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbFecha2 As System.Windows.Forms.GroupBox
    Friend WithEvents lvMovimientosFecha As System.Windows.Forms.ListView
    Friend WithEvents lvidstockF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidadF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMovimientoF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedidoProvF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbMovimientoF As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbMovimientoA As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvCodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumAlbaranF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedidoF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCant As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantF As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents cbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents bAlmacen As System.Windows.Forms.Button
    Friend WithEvents bBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PrecioUnitario As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaC As System.Windows.Forms.Label
    Friend WithEvents lbPrecio As System.Windows.Forms.Label
    Friend WithEvents bLimpiarBusqueda As System.Windows.Forms.Button
    Friend WithEvents rbRegularizacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbMovimiento As System.Windows.Forms.RadioButton
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lvProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProveedorA As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbPRoveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbProveedorA As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bLimpiarTodo As System.Windows.Forms.Button
End Class
