<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaPedidoProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaPedidoProveedor))
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpHastaEntrega = New System.Windows.Forms.DateTimePicker
        Me.dtpDesdeEntrega = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpHastaPedido = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtpDesdePedido = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbEstados = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbAño = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbProveedores = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.cbPedidoProveedor = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbPAGADO = New System.Windows.Forms.ComboBox
        Me.bListado = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.lvPedidos = New System.Windows.Forms.ListView
        Me.lvNumPedido = New System.Windows.Forms.ColumnHeader
        Me.lvPedidoProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.LvFechaEntrega = New System.Windows.Forms.ColumnHeader
        Me.lvProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvTotal = New System.Windows.Forms.ColumnHeader
        Me.lvPrecioE = New System.Windows.Forms.ColumnHeader
        Me.BNuevo = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbCambio = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.gb1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb1.Controls.Add(Me.GroupBox2)
        Me.gb1.Controls.Add(Me.GroupBox1)
        Me.gb1.Controls.Add(Me.lbEstados)
        Me.gb1.Controls.Add(Me.Label2)
        Me.gb1.Controls.Add(Me.cbAño)
        Me.gb1.Controls.Add(Me.Label17)
        Me.gb1.Controls.Add(Me.numPedido)
        Me.gb1.Controls.Add(Me.Label8)
        Me.gb1.Controls.Add(Me.cbArticulo)
        Me.gb1.Controls.Add(Me.cbCodArticulo)
        Me.gb1.Controls.Add(Me.Label21)
        Me.gb1.Controls.Add(Me.cbProveedores)
        Me.gb1.Controls.Add(Me.Label1)
        Me.gb1.Controls.Add(Me.cbTipo)
        Me.gb1.Controls.Add(Me.cbPedidoProveedor)
        Me.gb1.Controls.Add(Me.Label9)
        Me.gb1.Controls.Add(Me.Label13)
        Me.gb1.Controls.Add(Me.Label10)
        Me.gb1.Controls.Add(Me.cbPAGADO)
        Me.gb1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.ForeColor = System.Drawing.Color.DarkBlue
        Me.gb1.Location = New System.Drawing.Point(10, 96)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(1069, 167)
        Me.gb1.TabIndex = 0
        Me.gb1.TabStop = False
        Me.gb1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.dtpHastaEntrega)
        Me.GroupBox2.Controls.Add(Me.dtpDesdeEntrega)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(514, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(334, 59)
        Me.GroupBox2.TabIndex = 131
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA ENTREGA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(187, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 17)
        Me.Label16.TabIndex = 124
        Me.Label16.Text = "HASTA"
        '
        'dtpHastaEntrega
        '
        Me.dtpHastaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHastaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHastaEntrega.Location = New System.Drawing.Point(234, 22)
        Me.dtpHastaEntrega.Name = "dtpHastaEntrega"
        Me.dtpHastaEntrega.Size = New System.Drawing.Size(89, 23)
        Me.dtpHastaEntrega.TabIndex = 12
        Me.dtpHastaEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpDesdeEntrega
        '
        Me.dtpDesdeEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesdeEntrega.Location = New System.Drawing.Point(60, 22)
        Me.dtpDesdeEntrega.Name = "dtpDesdeEntrega"
        Me.dtpDesdeEntrega.Size = New System.Drawing.Size(89, 23)
        Me.dtpDesdeEntrega.TabIndex = 11
        Me.dtpDesdeEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(10, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "DESDE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpHastaPedido)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.dtpDesdePedido)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(514, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(334, 59)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FECHA PEDIDO"
        '
        'dtpHastaPedido
        '
        Me.dtpHastaPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHastaPedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHastaPedido.Location = New System.Drawing.Point(234, 23)
        Me.dtpHastaPedido.Name = "dtpHastaPedido"
        Me.dtpHastaPedido.Size = New System.Drawing.Size(89, 23)
        Me.dtpHastaPedido.TabIndex = 6
        Me.dtpHastaPedido.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(10, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 17)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "DESDE"
        '
        'dtpDesdePedido
        '
        Me.dtpDesdePedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdePedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesdePedido.Location = New System.Drawing.Point(60, 23)
        Me.dtpDesdePedido.Name = "dtpDesdePedido"
        Me.dtpDesdePedido.Size = New System.Drawing.Size(89, 23)
        Me.dtpDesdePedido.TabIndex = 5
        Me.dtpDesdePedido.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(187, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 17)
        Me.Label11.TabIndex = 124
        Me.Label11.Text = "HASTA"
        '
        'lbEstados
        '
        Me.lbEstados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbEstados.BackColor = System.Drawing.Color.White
        Me.lbEstados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbEstados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstados.FormattingEnabled = True
        Me.lbEstados.ItemHeight = 17
        Me.lbEstados.Location = New System.Drawing.Point(894, 35)
        Me.lbEstados.Name = "lbEstados"
        Me.lbEstados.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbEstados.Size = New System.Drawing.Size(159, 121)
        Me.lbEstados.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(892, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "ESTADOS"
        '
        'cbAño
        '
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(432, 97)
        Me.cbAño.MaxLength = 15
        Me.cbAño.Name = "cbAño"
        Me.cbAño.Size = New System.Drawing.Size(62, 25)
        Me.cbAño.TabIndex = 2
        Me.cbAño.Text = "2012"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(388, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 17)
        Me.Label17.TabIndex = 127
        Me.Label17.Text = "AÑO"
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numPedido.Location = New System.Drawing.Point(131, 67)
        Me.numPedido.MaxLength = 20
        Me.numPedido.Name = "numPedido"
        Me.numPedido.Size = New System.Drawing.Size(142, 23)
        Me.numPedido.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(9, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 17)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "ARTÍCULO"
        '
        'cbArticulo
        '
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(279, 128)
        Me.cbArticulo.MaxLength = 150
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(215, 25)
        Me.cbArticulo.TabIndex = 10
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(131, 128)
        Me.cbCodArticulo.MaxLength = 15
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(142, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(11, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 17)
        Me.Label21.TabIndex = 114
        Me.Label21.Text = "TIPO PROVEEDOR"
        '
        'cbProveedores
        '
        Me.cbProveedores.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedores.FormattingEnabled = True
        Me.cbProveedores.Location = New System.Drawing.Point(131, 97)
        Me.cbProveedores.Name = "cbProveedores"
        Me.cbProveedores.Size = New System.Drawing.Size(239, 25)
        Me.cbProveedores.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(11, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PROVEEDOR"
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(131, 35)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(142, 25)
        Me.cbTipo.TabIndex = 0
        '
        'cbPedidoProveedor
        '
        Me.cbPedidoProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPedidoProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPedidoProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPedidoProveedor.FormattingEnabled = True
        Me.cbPedidoProveedor.Location = New System.Drawing.Point(367, 35)
        Me.cbPedidoProveedor.Name = "cbPedidoProveedor"
        Me.cbPedidoProveedor.Size = New System.Drawing.Size(127, 25)
        Me.cbPedidoProveedor.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(279, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "REFERENCIA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(11, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 17)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "PEDIDO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Location = New System.Drawing.Point(315, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 17)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "PAGO"
        '
        'cbPAGADO
        '
        Me.cbPAGADO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbPAGADO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPAGADO.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPAGADO.FormattingEnabled = True
        Me.cbPAGADO.Location = New System.Drawing.Point(367, 66)
        Me.cbPAGADO.Name = "cbPAGADO"
        Me.cbPAGADO.Size = New System.Drawing.Size(127, 25)
        Me.cbPAGADO.TabIndex = 4
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bListado.Location = New System.Drawing.Point(654, 24)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(95, 53)
        Me.bListado.TabIndex = 4
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(762, 24)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(95, 53)
        Me.bLimpiar.TabIndex = 5
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(984, 24)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(95, 53)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'lvPedidos
        '
        Me.lvPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPedidos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvNumPedido, Me.lvPedidoProveedor, Me.lvFecha, Me.LvFechaEntrega, Me.lvProveedor, Me.lvEstado, Me.lvTotal, Me.lvPrecioE})
        Me.lvPedidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPedidos.FullRowSelect = True
        Me.lvPedidos.GridLines = True
        Me.lvPedidos.Location = New System.Drawing.Point(10, 271)
        Me.lvPedidos.MultiSelect = False
        Me.lvPedidos.Name = "lvPedidos"
        Me.lvPedidos.Size = New System.Drawing.Size(1070, 469)
        Me.lvPedidos.TabIndex = 1
        Me.lvPedidos.UseCompatibleStateImageBehavior = False
        Me.lvPedidos.View = System.Windows.Forms.View.Details
        '
        'lvNumPedido
        '
        Me.lvNumPedido.Text = "PEDIDO"
        Me.lvNumPedido.Width = 86
        '
        'lvPedidoProveedor
        '
        Me.lvPedidoProveedor.Text = "REF. PROVEEDOR"
        Me.lvPedidoProveedor.Width = 137
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 125
        '
        'LvFechaEntrega
        '
        Me.LvFechaEntrega.Text = "FECHA ENTREGA"
        Me.LvFechaEntrega.Width = 125
        '
        'lvProveedor
        '
        Me.lvProveedor.Text = "PROVEEDOR"
        Me.lvProveedor.Width = 332
        '
        'lvEstado
        '
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 121
        '
        'lvTotal
        '
        Me.lvTotal.Text = "TOTAL"
        Me.lvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotal.Width = 110
        '
        'lvPrecioE
        '
        Me.lvPrecioE.Text = "PrecioE"
        Me.lvPrecioE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecioE.Width = 0
        '
        'BNuevo
        '
        Me.BNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BNuevo.Location = New System.Drawing.Point(873, 24)
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(95, 53)
        Me.BNuevo.TabIndex = 6
        Me.BNuevo.Text = "NUEVO"
        Me.BNuevo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(10, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(183, 749)
        Me.lbCambio.Name = "lbCambio"
        Me.lbCambio.Size = New System.Drawing.Size(60, 17)
        Me.lbCambio.TabIndex = 192
        Me.lbCambio.Text = "CAMBIO"
        Me.lbCambio.Visible = False
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(117, 746)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 2
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(973, 746)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 23)
        Me.Total.TabIndex = 3
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(7, 749)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 17)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "ENCONTRADOS"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(1068, 749)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 17)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "€"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(912, 749)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 191
        Me.Label5.Text = "TOTAL"
        '
        'BusquedaPedidoProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 778)
        Me.Controls.Add(Me.lbCambio)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BNuevo)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.lvPedidos)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.bSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BusquedaPedidoProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA PEDIDOS PROVEEDOR"
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents cbPedidoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbProveedores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lvPedidos As System.Windows.Forms.ListView
    Friend WithEvents lvNumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPedidoProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lvPrecioE As System.Windows.Forms.ColumnHeader
    Friend WithEvents BNuevo As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbCambio As System.Windows.Forms.Label
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbPAGADO As System.Windows.Forms.ComboBox
    Friend WithEvents dtpHastaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHastaPedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesdeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdePedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lbEstados As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LvFechaEntrega As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
