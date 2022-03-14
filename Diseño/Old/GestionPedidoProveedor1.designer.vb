<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionPedidoProveedor1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionPedidoProveedor1))
        Me.gbConceptos = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.DescuentoC = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.dtpFechaPrevistaC = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bArticuloProveedor = New System.Windows.Forms.Button
        Me.bVerArticulo = New System.Windows.Forms.Button
        Me.bFamilias = New System.Windows.Forms.Button
        Me.BBuscarProducto = New System.Windows.Forms.Button
        Me.lbMoneda2 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.lbMoneda1 = New System.Windows.Forms.Label
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvidconcepto = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPrevista = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvRecibidas = New System.Windows.Forms.ColumnHeader
        Me.lvPrecio = New System.Windows.Forms.ColumnHeader
        Me.lvDescuento = New System.Windows.Forms.ColumnHeader
        Me.lvtotal = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.idEstado = New System.Windows.Forms.ColumnHeader
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbSubFamilia = New System.Windows.Forms.ComboBox
        Me.cbFamilia = New System.Windows.Forms.ComboBox
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cbcodArticuloProv = New System.Windows.Forms.ComboBox
        Me.cbNombre = New System.Windows.Forms.ComboBox
        Me.cbcodArticulo = New System.Windows.Forms.ComboBox
        Me.totalConcepto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Precio = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox
        Me.bBorrarConcepto = New System.Windows.Forms.Button
        Me.TotalPedido = New System.Windows.Forms.TextBox
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bEmail = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pedidoProveedor = New System.Windows.Forms.TextBox
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaPedido = New System.Windows.Forms.DateTimePicker
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.HorarioEntrega = New System.Windows.Forms.TextBox
        Me.tipoIVA = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.cbsolicitadoVia = New System.Windows.Forms.ComboBox
        Me.cbSolicitadoPor = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.gbCabecera = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lbmonedaT = New System.Windows.Forms.Label
        Me.PrecioTransporte = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.ckPagado = New System.Windows.Forms.CheckBox
        Me.cbDireccion = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.cbPortes = New System.Windows.Forms.ComboBox
        Me.cbTransporte = New System.Windows.Forms.ComboBox
        Me.cbValorado = New System.Windows.Forms.ComboBox
        Me.bMoneda = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.cbCodProveedor = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Nota = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbContacto = New System.Windows.Forms.ComboBox
        Me.bVerProveedor = New System.Windows.Forms.Button
        Me.bBuscarProveedor = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Descuento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.BNuevo = New System.Windows.Forms.Button
        Me.bRecepcion = New System.Windows.Forms.Button
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.bPDF = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbMoneda6 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Retencion = New System.Windows.Forms.TextBox
        Me.lbMoneda5 = New System.Windows.Forms.Label
        Me.lbMoneda4 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.TotalIVA = New System.Windows.Forms.TextBox
        Me.BaseImponible = New System.Windows.Forms.TextBox
        Me.lbMoneda3 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSubirC = New System.Windows.Forms.Button
        Me.bBajarC = New System.Windows.Forms.Button
        Me.gbConceptos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbCabecera.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbConceptos
        '
        resources.ApplyResources(Me.gbConceptos, "gbConceptos")
        Me.gbConceptos.Controls.Add(Me.bSubirC)
        Me.gbConceptos.Controls.Add(Me.bBajarC)
        Me.gbConceptos.Controls.Add(Me.Label17)
        Me.gbConceptos.Controls.Add(Me.DescuentoC)
        Me.gbConceptos.Controls.Add(Me.Label32)
        Me.gbConceptos.Controls.Add(Me.dtpFechaPrevistaC)
        Me.gbConceptos.Controls.Add(Me.Label25)
        Me.gbConceptos.Controls.Add(Me.bLimpiar)
        Me.gbConceptos.Controls.Add(Me.bArticuloProveedor)
        Me.gbConceptos.Controls.Add(Me.bVerArticulo)
        Me.gbConceptos.Controls.Add(Me.bFamilias)
        Me.gbConceptos.Controls.Add(Me.BBuscarProducto)
        Me.gbConceptos.Controls.Add(Me.lbMoneda2)
        Me.gbConceptos.Controls.Add(Me.Label39)
        Me.gbConceptos.Controls.Add(Me.lbMoneda1)
        Me.gbConceptos.Controls.Add(Me.lvConceptos)
        Me.gbConceptos.Controls.Add(Me.Label13)
        Me.gbConceptos.Controls.Add(Me.cbSubFamilia)
        Me.gbConceptos.Controls.Add(Me.cbFamilia)
        Me.gbConceptos.Controls.Add(Me.lbUnidad)
        Me.gbConceptos.Controls.Add(Me.Label9)
        Me.gbConceptos.Controls.Add(Me.Label8)
        Me.gbConceptos.Controls.Add(Me.Label12)
        Me.gbConceptos.Controls.Add(Me.Label26)
        Me.gbConceptos.Controls.Add(Me.cbcodArticuloProv)
        Me.gbConceptos.Controls.Add(Me.cbNombre)
        Me.gbConceptos.Controls.Add(Me.cbcodArticulo)
        Me.gbConceptos.Controls.Add(Me.totalConcepto)
        Me.gbConceptos.Controls.Add(Me.Label2)
        Me.gbConceptos.Controls.Add(Me.Precio)
        Me.gbConceptos.Controls.Add(Me.Label16)
        Me.gbConceptos.Controls.Add(Me.Label14)
        Me.gbConceptos.Controls.Add(Me.Cantidad)
        Me.gbConceptos.Controls.Add(Me.cbTipoIVA)
        Me.gbConceptos.Name = "gbConceptos"
        Me.gbConceptos.TabStop = False
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Name = "Label17"
        '
        'DescuentoC
        '
        Me.DescuentoC.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.DescuentoC, "DescuentoC")
        Me.DescuentoC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DescuentoC.Name = "DescuentoC"
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.Name = "Label32"
        '
        'dtpFechaPrevistaC
        '
        resources.ApplyResources(Me.dtpFechaPrevistaC, "dtpFechaPrevistaC")
        Me.dtpFechaPrevistaC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevistaC.Name = "dtpFechaPrevistaC"
        Me.dtpFechaPrevistaC.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.Name = "Label25"
        '
        'bLimpiar
        '
        resources.ApplyResources(Me.bLimpiar, "bLimpiar")
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bArticuloProveedor
        '
        resources.ApplyResources(Me.bArticuloProveedor, "bArticuloProveedor")
        Me.bArticuloProveedor.Name = "bArticuloProveedor"
        Me.bArticuloProveedor.UseVisualStyleBackColor = True
        '
        'bVerArticulo
        '
        resources.ApplyResources(Me.bVerArticulo, "bVerArticulo")
        Me.bVerArticulo.Name = "bVerArticulo"
        Me.bVerArticulo.UseVisualStyleBackColor = True
        '
        'bFamilias
        '
        resources.ApplyResources(Me.bFamilias, "bFamilias")
        Me.bFamilias.Name = "bFamilias"
        Me.bFamilias.UseVisualStyleBackColor = True
        '
        'BBuscarProducto
        '
        Me.BBuscarProducto.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.BBuscarProducto, "BBuscarProducto")
        Me.BBuscarProducto.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.BBuscarProducto.Name = "BBuscarProducto"
        Me.BBuscarProducto.TabStop = False
        Me.BBuscarProducto.UseVisualStyleBackColor = True
        '
        'lbMoneda2
        '
        resources.ApplyResources(Me.lbMoneda2, "lbMoneda2")
        Me.lbMoneda2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda2.Name = "lbMoneda2"
        '
        'Label39
        '
        resources.ApplyResources(Me.Label39, "Label39")
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.Name = "Label39"
        '
        'lbMoneda1
        '
        resources.ApplyResources(Me.lbMoneda1, "lbMoneda1")
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.Name = "lbMoneda1"
        '
        'lvConceptos
        '
        Me.lvConceptos.AllowColumnReorder = True
        resources.ApplyResources(Me.lvConceptos, "lvConceptos")
        Me.lvConceptos.AutoArrange = False
        Me.lvConceptos.BackgroundImageTiled = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidconcepto, Me.lvcodArticulo, Me.lvcodArticuloProv, Me.lvdescripcion, Me.lvFechaPrevista, Me.lvCantidad, Me.lvRecibidas, Me.lvPrecio, Me.lvDescuento, Me.lvtotal, Me.lvidArticulo, Me.idEstado})
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidconcepto
        '
        resources.ApplyResources(Me.lvidconcepto, "lvidconcepto")
        '
        'lvcodArticulo
        '
        resources.ApplyResources(Me.lvcodArticulo, "lvcodArticulo")
        '
        'lvcodArticuloProv
        '
        resources.ApplyResources(Me.lvcodArticuloProv, "lvcodArticuloProv")
        '
        'lvdescripcion
        '
        resources.ApplyResources(Me.lvdescripcion, "lvdescripcion")
        '
        'lvFechaPrevista
        '
        resources.ApplyResources(Me.lvFechaPrevista, "lvFechaPrevista")
        '
        'lvCantidad
        '
        resources.ApplyResources(Me.lvCantidad, "lvCantidad")
        '
        'lvRecibidas
        '
        resources.ApplyResources(Me.lvRecibidas, "lvRecibidas")
        '
        'lvPrecio
        '
        resources.ApplyResources(Me.lvPrecio, "lvPrecio")
        '
        'lvDescuento
        '
        resources.ApplyResources(Me.lvDescuento, "lvDescuento")
        '
        'lvtotal
        '
        resources.ApplyResources(Me.lvtotal, "lvtotal")
        '
        'lvidArticulo
        '
        resources.ApplyResources(Me.lvidArticulo, "lvidArticulo")
        '
        'idEstado
        '
        resources.ApplyResources(Me.idEstado, "idEstado")
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Name = "Label13"
        '
        'cbSubFamilia
        '
        resources.ApplyResources(Me.cbSubFamilia, "cbSubFamilia")
        Me.cbSubFamilia.FormattingEnabled = True
        Me.cbSubFamilia.Name = "cbSubFamilia"
        '
        'cbFamilia
        '
        Me.cbFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        resources.ApplyResources(Me.cbFamilia, "cbFamilia")
        Me.cbFamilia.FormattingEnabled = True
        Me.cbFamilia.Name = "cbFamilia"
        '
        'lbUnidad
        '
        resources.ApplyResources(Me.lbUnidad, "lbUnidad")
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.Name = "lbUnidad"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Name = "Label8"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Name = "Label12"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.Name = "Label26"
        '
        'cbcodArticuloProv
        '
        Me.cbcodArticuloProv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticuloProv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbcodArticuloProv, "cbcodArticuloProv")
        Me.cbcodArticuloProv.FormattingEnabled = True
        Me.cbcodArticuloProv.Name = "cbcodArticuloProv"
        '
        'cbNombre
        '
        Me.cbNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbNombre, "cbNombre")
        Me.cbNombre.FormattingEnabled = True
        Me.cbNombre.Name = "cbNombre"
        '
        'cbcodArticulo
        '
        Me.cbcodArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbcodArticulo, "cbcodArticulo")
        Me.cbcodArticulo.FormattingEnabled = True
        Me.cbcodArticulo.Name = "cbcodArticulo"
        '
        'totalConcepto
        '
        Me.totalConcepto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.totalConcepto, "totalConcepto")
        Me.totalConcepto.ForeColor = System.Drawing.Color.Black
        Me.totalConcepto.Name = "totalConcepto"
        Me.totalConcepto.ReadOnly = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Name = "Label2"
        '
        'Precio
        '
        resources.ApplyResources(Me.Precio, "Precio")
        Me.Precio.ForeColor = System.Drawing.Color.Black
        Me.Precio.Name = "Precio"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.Name = "Label16"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.Name = "Label14"
        '
        'Cantidad
        '
        resources.ApplyResources(Me.Cantidad, "Cantidad")
        Me.Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Cantidad.Name = "Cantidad"
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbTipoIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbTipoIVA, "cbTipoIVA")
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Name = "cbTipoIVA"
        '
        'bBorrarConcepto
        '
        Me.bBorrarConcepto.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.bBorrarConcepto, "bBorrarConcepto")
        Me.bBorrarConcepto.Name = "bBorrarConcepto"
        Me.bBorrarConcepto.TabStop = False
        Me.bBorrarConcepto.UseVisualStyleBackColor = True
        '
        'TotalPedido
        '
        resources.ApplyResources(Me.TotalPedido, "TotalPedido")
        Me.TotalPedido.ForeColor = System.Drawing.Color.Black
        Me.TotalPedido.Name = "TotalPedido"
        Me.TotalPedido.ReadOnly = True
        '
        'bGuardar
        '
        resources.ApplyResources(Me.bGuardar, "bGuardar")
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        resources.ApplyResources(Me.bImprimir, "bImprimir")
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bEmail
        '
        resources.ApplyResources(Me.bEmail, "bEmail")
        Me.bEmail.Name = "bEmail"
        Me.bEmail.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pedidoProveedor)
        Me.GroupBox1.Controls.Add(Me.numPedido)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'pedidoProveedor
        '
        resources.ApplyResources(Me.pedidoProveedor, "pedidoProveedor")
        Me.pedidoProveedor.Name = "pedidoProveedor"
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.numPedido, "numPedido")
        Me.numPedido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.numPedido.Name = "numPedido"
        Me.numPedido.ReadOnly = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Name = "Label4"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Name = "Label18"
        '
        'cbEstado
        '
        Me.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbEstado, "cbEstado")
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Sorted = True
        '
        'dtpFechaEntrega
        '
        resources.ApplyResources(Me.dtpFechaEntrega, "dtpFechaEntrega")
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'dtpFechaPedido
        '
        resources.ApplyResources(Me.dtpFechaPedido, "dtpFechaPedido")
        Me.dtpFechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPedido.Name = "dtpFechaPedido"
        Me.dtpFechaPedido.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'CheckBox2
        '
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'HorarioEntrega
        '
        resources.ApplyResources(Me.HorarioEntrega, "HorarioEntrega")
        Me.HorarioEntrega.Name = "HorarioEntrega"
        '
        'tipoIVA
        '
        resources.ApplyResources(Me.tipoIVA, "tipoIVA")
        Me.tipoIVA.ForeColor = System.Drawing.Color.DarkRed
        Me.tipoIVA.Name = "tipoIVA"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.Name = "Label15"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.Name = "Label21"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.Name = "Label20"
        '
        'cbProveedor
        '
        Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbProveedor, "cbProveedor")
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Name = "cbProveedor"
        '
        'cbsolicitadoVia
        '
        resources.ApplyResources(Me.cbsolicitadoVia, "cbsolicitadoVia")
        Me.cbsolicitadoVia.FormattingEnabled = True
        Me.cbsolicitadoVia.Name = "cbsolicitadoVia"
        '
        'cbSolicitadoPor
        '
        Me.cbSolicitadoPor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSolicitadoPor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbSolicitadoPor, "cbSolicitadoPor")
        Me.cbSolicitadoPor.FormattingEnabled = True
        Me.cbSolicitadoPor.Name = "cbSolicitadoPor"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.Name = "Label22"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.Name = "Label24"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.Name = "Label23"
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.Label10)
        Me.gbCabecera.Controls.Add(Me.lbmonedaT)
        Me.gbCabecera.Controls.Add(Me.PrecioTransporte)
        Me.gbCabecera.Controls.Add(Me.Label33)
        Me.gbCabecera.Controls.Add(Me.ckPagado)
        Me.gbCabecera.Controls.Add(Me.cbDireccion)
        Me.gbCabecera.Controls.Add(Me.GroupBox5)
        Me.gbCabecera.Controls.Add(Me.Label27)
        Me.gbCabecera.Controls.Add(Me.Label28)
        Me.gbCabecera.Controls.Add(Me.cbPortes)
        Me.gbCabecera.Controls.Add(Me.cbTransporte)
        Me.gbCabecera.Controls.Add(Me.cbValorado)
        Me.gbCabecera.Controls.Add(Me.bMoneda)
        Me.gbCabecera.Controls.Add(Me.Label29)
        Me.gbCabecera.Controls.Add(Me.cbMoneda)
        Me.gbCabecera.Controls.Add(Me.cbCodProveedor)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Controls.Add(Me.Nota)
        Me.gbCabecera.Controls.Add(Me.Label1)
        Me.gbCabecera.Controls.Add(Me.cbContacto)
        Me.gbCabecera.Controls.Add(Me.bVerProveedor)
        Me.gbCabecera.Controls.Add(Me.bBuscarProveedor)
        Me.gbCabecera.Controls.Add(Me.Label11)
        Me.gbCabecera.Controls.Add(Me.Observaciones)
        Me.gbCabecera.Controls.Add(Me.GroupBox1)
        Me.gbCabecera.Controls.Add(Me.CheckBox2)
        Me.gbCabecera.Controls.Add(Me.Label22)
        Me.gbCabecera.Controls.Add(Me.Button1)
        Me.gbCabecera.Controls.Add(Me.Label24)
        Me.gbCabecera.Controls.Add(Me.Label15)
        Me.gbCabecera.Controls.Add(Me.HorarioEntrega)
        Me.gbCabecera.Controls.Add(Me.Label6)
        Me.gbCabecera.Controls.Add(Me.tipoIVA)
        Me.gbCabecera.Controls.Add(Me.cbsolicitadoVia)
        Me.gbCabecera.Controls.Add(Me.Label21)
        Me.gbCabecera.Controls.Add(Me.Label20)
        Me.gbCabecera.Controls.Add(Me.cbProveedor)
        Me.gbCabecera.Controls.Add(Me.Descuento)
        Me.gbCabecera.Controls.Add(Me.Label3)
        resources.ApplyResources(Me.gbCabecera, "gbCabecera")
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.TabStop = False
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Name = "Label10"
        '
        'lbmonedaT
        '
        resources.ApplyResources(Me.lbmonedaT, "lbmonedaT")
        Me.lbmonedaT.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaT.Name = "lbmonedaT"
        '
        'PrecioTransporte
        '
        Me.PrecioTransporte.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.PrecioTransporte, "PrecioTransporte")
        Me.PrecioTransporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioTransporte.Name = "PrecioTransporte"
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.Name = "Label33"
        '
        'ckPagado
        '
        resources.ApplyResources(Me.ckPagado, "ckPagado")
        Me.ckPagado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckPagado.Name = "ckPagado"
        Me.ckPagado.UseVisualStyleBackColor = True
        '
        'cbDireccion
        '
        resources.ApplyResources(Me.cbDireccion, "cbDireccion")
        Me.cbDireccion.FormattingEnabled = True
        Me.cbDireccion.Name = "cbDireccion"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.dtpFechaEntrega)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.dtpFechaPedido)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.Name = "Label30"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.Name = "Label31"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.Name = "Label27"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.Name = "Label28"
        '
        'cbPortes
        '
        Me.cbPortes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbPortes, "cbPortes")
        Me.cbPortes.FormattingEnabled = True
        Me.cbPortes.Name = "cbPortes"
        '
        'cbTransporte
        '
        Me.cbTransporte.DropDownWidth = 225
        resources.ApplyResources(Me.cbTransporte, "cbTransporte")
        Me.cbTransporte.FormattingEnabled = True
        Me.cbTransporte.Name = "cbTransporte"
        '
        'cbValorado
        '
        resources.ApplyResources(Me.cbValorado, "cbValorado")
        Me.cbValorado.FormattingEnabled = True
        Me.cbValorado.Name = "cbValorado"
        '
        'bMoneda
        '
        resources.ApplyResources(Me.bMoneda, "bMoneda")
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.Name = "Label29"
        '
        'cbMoneda
        '
        Me.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbMoneda, "cbMoneda")
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Name = "cbMoneda"
        '
        'cbCodProveedor
        '
        resources.ApplyResources(Me.cbCodProveedor, "cbCodProveedor")
        Me.cbCodProveedor.FormattingEnabled = True
        Me.cbCodProveedor.Name = "cbCodProveedor"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Name = "Label7"
        '
        'Nota
        '
        resources.ApplyResources(Me.Nota, "Nota")
        Me.Nota.Name = "Nota"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Name = "Label1"
        '
        'cbContacto
        '
        resources.ApplyResources(Me.cbContacto, "cbContacto")
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Name = "cbContacto"
        '
        'bVerProveedor
        '
        resources.ApplyResources(Me.bVerProveedor, "bVerProveedor")
        Me.bVerProveedor.Name = "bVerProveedor"
        Me.bVerProveedor.UseVisualStyleBackColor = True
        '
        'bBuscarProveedor
        '
        resources.ApplyResources(Me.bBuscarProveedor, "bBuscarProveedor")
        Me.bBuscarProveedor.Name = "bBuscarProveedor"
        Me.bBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.Name = "Label11"
        '
        'Observaciones
        '
        resources.ApplyResources(Me.Observaciones, "Observaciones")
        Me.Observaciones.Name = "Observaciones"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Name = "Label6"
        '
        'Descuento
        '
        Me.Descuento.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.Descuento, "Descuento")
        Me.Descuento.Name = "Descuento"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Name = "Label3"
        '
        'bSalir
        '
        resources.ApplyResources(Me.bSalir, "bSalir")
        Me.bSalir.Name = "bSalir"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'BNuevo
        '
        Me.BNuevo.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.BNuevo, "BNuevo")
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.UseVisualStyleBackColor = True
        '
        'bRecepcion
        '
        Me.bRecepcion.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.bRecepcion, "bRecepcion")
        Me.bRecepcion.Name = "bRecepcion"
        Me.bRecepcion.TabStop = False
        Me.bRecepcion.UseVisualStyleBackColor = True
        '
        'bSubir
        '
        resources.ApplyResources(Me.bSubir, "bSubir")
        Me.bSubir.Name = "bSubir"
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        resources.ApplyResources(Me.bBajar, "bBajar")
        Me.bBajar.Name = "bBajar"
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bPDF
        '
        resources.ApplyResources(Me.bPDF, "bPDF")
        Me.bPDF.Name = "bPDF"
        Me.bPDF.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.lbMoneda6)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Retencion)
        Me.GroupBox2.Controls.Add(Me.lbMoneda5)
        Me.GroupBox2.Controls.Add(Me.lbMoneda4)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.TotalIVA)
        Me.GroupBox2.Controls.Add(Me.BaseImponible)
        Me.GroupBox2.Controls.Add(Me.lbMoneda3)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.bSalir)
        Me.GroupBox2.Controls.Add(Me.bSubir)
        Me.GroupBox2.Controls.Add(Me.TotalPedido)
        Me.GroupBox2.Controls.Add(Me.gbConceptos)
        Me.GroupBox2.Controls.Add(Me.bPDF)
        Me.GroupBox2.Controls.Add(Me.gbCabecera)
        Me.GroupBox2.Controls.Add(Me.bBajar)
        Me.GroupBox2.Controls.Add(Me.bGuardar)
        Me.GroupBox2.Controls.Add(Me.bEmail)
        Me.GroupBox2.Controls.Add(Me.bImprimir)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.cbSolicitadoPor)
        Me.GroupBox2.Controls.Add(Me.bRecepcion)
        Me.GroupBox2.Controls.Add(Me.BNuevo)
        Me.GroupBox2.Controls.Add(Me.bBorrarConcepto)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'lbMoneda6
        '
        resources.ApplyResources(Me.lbMoneda6, "lbMoneda6")
        Me.lbMoneda6.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda6.Name = "lbMoneda6"
        '
        'Label37
        '
        resources.ApplyResources(Me.Label37, "Label37")
        Me.Label37.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label37.Name = "Label37"
        '
        'Retencion
        '
        resources.ApplyResources(Me.Retencion, "Retencion")
        Me.Retencion.BackColor = System.Drawing.SystemColors.Control
        Me.Retencion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Retencion.Name = "Retencion"
        Me.Retencion.ReadOnly = True
        Me.Retencion.TabStop = False
        '
        'lbMoneda5
        '
        resources.ApplyResources(Me.lbMoneda5, "lbMoneda5")
        Me.lbMoneda5.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda5.Name = "lbMoneda5"
        '
        'lbMoneda4
        '
        resources.ApplyResources(Me.lbMoneda4, "lbMoneda4")
        Me.lbMoneda4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda4.Name = "lbMoneda4"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.Name = "Label34"
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label35.Name = "Label35"
        '
        'TotalIVA
        '
        resources.ApplyResources(Me.TotalIVA, "TotalIVA")
        Me.TotalIVA.BackColor = System.Drawing.SystemColors.Control
        Me.TotalIVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalIVA.Name = "TotalIVA"
        Me.TotalIVA.ReadOnly = True
        Me.TotalIVA.TabStop = False
        '
        'BaseImponible
        '
        resources.ApplyResources(Me.BaseImponible, "BaseImponible")
        Me.BaseImponible.BackColor = System.Drawing.SystemColors.Control
        Me.BaseImponible.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BaseImponible.Name = "BaseImponible"
        Me.BaseImponible.ReadOnly = True
        Me.BaseImponible.TabStop = False
        '
        'lbMoneda3
        '
        resources.ApplyResources(Me.lbMoneda3, "lbMoneda3")
        Me.lbMoneda3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda3.Name = "lbMoneda3"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Name = "Label19"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'bSubirC
        '
        resources.ApplyResources(Me.bSubirC, "bSubirC")
        Me.bSubirC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubirC.Name = "bSubirC"
        Me.bSubirC.UseVisualStyleBackColor = True
        '
        'bBajarC
        '
        resources.ApplyResources(Me.bBajarC, "bBajarC")
        Me.bBajarC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajarC.Name = "bBajarC"
        Me.bBajarC.UseVisualStyleBackColor = True
        '
        'GestionPedidoProveedor1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionPedidoProveedor1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.gbConceptos.ResumeLayout(False)
        Me.gbConceptos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbcodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents totalConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Precio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidconcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bEmail As System.Windows.Forms.Button
    Friend WithEvents gbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cbsolicitadoVia As System.Windows.Forms.ComboBox
    Friend WithEvents cbSolicitadoPor As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaPedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents TotalPedido As System.Windows.Forms.TextBox
    Friend WithEvents tipoIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents bBorrarConcepto As System.Windows.Forms.Button
    Friend WithEvents pedidoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbcodArticuloProv As System.Windows.Forms.ComboBox
    Friend WithEvents BNuevo As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents HorarioEntrega As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda2 As System.Windows.Forms.Label
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents BBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents bRecepcion As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbNombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents bVerProveedor As System.Windows.Forms.Button
    Friend WithEvents bBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents bArticuloProveedor As System.Windows.Forms.Button
    Friend WithEvents bVerArticulo As System.Windows.Forms.Button
    Friend WithEvents bFamilias As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents bPDF As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Nota As System.Windows.Forms.TextBox
    Friend WithEvents cbCodProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbPortes As System.Windows.Forms.ComboBox
    Friend WithEvents cbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents cbValorado As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPrevistaC As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ckPagado As System.Windows.Forms.CheckBox
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DescuentoC As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents lvRecibidas As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPrevista As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbmonedaT As System.Windows.Forms.Label
    Friend WithEvents PrecioTransporte As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda5 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda4 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TotalIVA As System.Windows.Forms.TextBox
    Friend WithEvents BaseImponible As System.Windows.Forms.TextBox
    Friend WithEvents idEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbMoneda6 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Retencion As System.Windows.Forms.TextBox
    Friend WithEvents bSubirC As System.Windows.Forms.Button
    Friend WithEvents bBajarC As System.Windows.Forms.Button
End Class
