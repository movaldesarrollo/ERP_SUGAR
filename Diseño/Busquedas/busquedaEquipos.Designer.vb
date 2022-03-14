<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaEquipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaEquipos))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbEstadosEq = New System.Windows.Forms.ListBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.numSerie2 = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Factura = New System.Windows.Forms.TextBox
        Me.bVerFactura = New System.Windows.Forms.Button
        Me.Version = New System.Windows.Forms.TextBox
        Me.Pedido = New System.Windows.Forms.TextBox
        Me.bverPedido = New System.Windows.Forms.Button
        Me.Albaran = New System.Windows.Forms.TextBox
        Me.bVerAlbaran = New System.Windows.Forms.Button
        Me.numSerie = New System.Windows.Forms.TextBox
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbCodCliente = New System.Windows.Forms.ComboBox
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.lbTipo = New System.Windows.Forms.Label
        Me.lvEquipos = New System.Windows.Forms.ListView
        Me.lvCheck = New System.Windows.Forms.ColumnHeader
        Me.lvidEquipo = New System.Windows.Forms.ColumnHeader
        Me.lvnumSerie = New System.Windows.Forms.ColumnHeader
        Me.lvcoArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvPedido = New System.Windows.Forms.ColumnHeader
        Me.lvAlbaran = New System.Windows.Forms.ColumnHeader
        Me.lvFechaAlbaran = New System.Windows.Forms.ColumnHeader
        Me.lvFactura = New System.Windows.Forms.ColumnHeader
        Me.lvFechaFactura = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.idEquipoHistorico = New System.Windows.Forms.ColumnHeader
        Me.lvVersion = New System.Windows.Forms.ColumnHeader
        Me.lvfechafabricacion = New System.Windows.Forms.ColumnHeader
        Me.Label9 = New System.Windows.Forms.Label
        Me.Encontrados = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.PedidosEncontrados = New System.Windows.Forms.TextBox
        Me.pbCarga = New System.Windows.Forms.ProgressBar
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.bSeleccionar = New System.Windows.Forms.Button
        Me.bimprimirresumen = New System.Windows.Forms.Button
        Me.bCliente = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(15, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1220, 30)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(90, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(981, 30)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(90, 50)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "LISTADO"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1102, 30)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(90, 50)
        Me.bLimpiar.TabIndex = 7
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bCliente)
        Me.GroupBox1.Controls.Add(Me.lbEstadosEq)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.numSerie2)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Observaciones)
        Me.GroupBox1.Controls.Add(Me.Factura)
        Me.GroupBox1.Controls.Add(Me.bVerFactura)
        Me.GroupBox1.Controls.Add(Me.Version)
        Me.GroupBox1.Controls.Add(Me.Pedido)
        Me.GroupBox1.Controls.Add(Me.bverPedido)
        Me.GroupBox1.Controls.Add(Me.Albaran)
        Me.GroupBox1.Controls.Add(Me.bVerAlbaran)
        Me.GroupBox1.Controls.Add(Me.numSerie)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cbCodCliente)
        Me.GroupBox1.Controls.Add(Me.cbCliente)
        Me.GroupBox1.Controls.Add(Me.cbCodArticulo)
        Me.GroupBox1.Controls.Add(Me.cbArticulo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbSubTipo)
        Me.GroupBox1.Controls.Add(Me.lbSubTipo)
        Me.GroupBox1.Controls.Add(Me.cbTipo)
        Me.GroupBox1.Controls.Add(Me.lbTipo)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1300, 204)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'lbEstadosEq
        '
        Me.lbEstadosEq.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbEstadosEq.BackColor = System.Drawing.Color.White
        Me.lbEstadosEq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbEstadosEq.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstadosEq.FormattingEnabled = True
        Me.lbEstadosEq.ItemHeight = 17
        Me.lbEstadosEq.Location = New System.Drawing.Point(1091, 49)
        Me.lbEstadosEq.Name = "lbEstadosEq"
        Me.lbEstadosEq.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbEstadosEq.Size = New System.Drawing.Size(200, 138)
        Me.lbEstadosEq.TabIndex = 200
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(258, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 18)
        Me.Label11.TabIndex = 200
        Me.Label11.Text = "-"
        '
        'numSerie2
        '
        Me.numSerie2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie2.ForeColor = System.Drawing.Color.DarkRed
        Me.numSerie2.Location = New System.Drawing.Point(272, 85)
        Me.numSerie2.Name = "numSerie2"
        Me.numSerie2.Size = New System.Drawing.Size(127, 23)
        Me.numSerie2.TabIndex = 7
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(791, 87)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 17)
        Me.Label42.TabIndex = 198
        Me.Label42.Text = "VERSIÓN"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(13, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 17)
        Me.Label10.TabIndex = 191
        Me.Label10.Text = "OBSERVACIONES"
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(129, 114)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(637, 79)
        Me.Observaciones.TabIndex = 11
        '
        'Factura
        '
        Me.Factura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Factura.ForeColor = System.Drawing.Color.DarkRed
        Me.Factura.Location = New System.Drawing.Point(866, 172)
        Me.Factura.Name = "Factura"
        Me.Factura.Size = New System.Drawing.Size(152, 23)
        Me.Factura.TabIndex = 16
        '
        'bVerFactura
        '
        Me.bVerFactura.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerFactura.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerFactura.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerFactura.Location = New System.Drawing.Point(1041, 171)
        Me.bVerFactura.Name = "bVerFactura"
        Me.bVerFactura.Size = New System.Drawing.Size(27, 25)
        Me.bVerFactura.TabIndex = 17
        Me.bVerFactura.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Version.Location = New System.Drawing.Point(866, 84)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(202, 23)
        Me.Version.TabIndex = 10
        '
        'Pedido
        '
        Me.Pedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pedido.ForeColor = System.Drawing.Color.DarkRed
        Me.Pedido.Location = New System.Drawing.Point(866, 114)
        Me.Pedido.Name = "Pedido"
        Me.Pedido.Size = New System.Drawing.Size(152, 23)
        Me.Pedido.TabIndex = 12
        '
        'bverPedido
        '
        Me.bverPedido.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bverPedido.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bverPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bverPedido.Location = New System.Drawing.Point(1041, 113)
        Me.bverPedido.Name = "bverPedido"
        Me.bverPedido.Size = New System.Drawing.Size(27, 25)
        Me.bverPedido.TabIndex = 13
        Me.bverPedido.UseVisualStyleBackColor = True
        '
        'Albaran
        '
        Me.Albaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Albaran.ForeColor = System.Drawing.Color.DarkRed
        Me.Albaran.Location = New System.Drawing.Point(866, 143)
        Me.Albaran.Name = "Albaran"
        Me.Albaran.Size = New System.Drawing.Size(152, 23)
        Me.Albaran.TabIndex = 14
        '
        'bVerAlbaran
        '
        Me.bVerAlbaran.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerAlbaran.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerAlbaran.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerAlbaran.Location = New System.Drawing.Point(1041, 142)
        Me.bVerAlbaran.Name = "bVerAlbaran"
        Me.bVerAlbaran.Size = New System.Drawing.Size(27, 25)
        Me.bVerAlbaran.TabIndex = 15
        Me.bVerAlbaran.UseVisualStyleBackColor = True
        '
        'numSerie
        '
        Me.numSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie.ForeColor = System.Drawing.Color.Black
        Me.numSerie.Location = New System.Drawing.Point(130, 85)
        Me.numSerie.Name = "numSerie"
        Me.numSerie.Size = New System.Drawing.Size(127, 23)
        Me.numSerie.TabIndex = 6
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(672, 85)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(92, 23)
        Me.dtpHasta.TabIndex = 9
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(15, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "CLIENTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(623, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "HASTA"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(15, 57)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 17)
        Me.Label39.TabIndex = 185
        Me.Label39.Text = "ARTÍCULO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(791, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 17)
        Me.Label7.TabIndex = 161
        Me.Label7.Text = "FACTURA"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(526, 85)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(92, 23)
        Me.dtpDesde.TabIndex = 8
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(791, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "PEDIDO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(791, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 17)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "ALBARÁN"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(410, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 17)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "ENTREGA DESDE"
        '
        'cbCodCliente
        '
        Me.cbCodCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodCliente.FormattingEnabled = True
        Me.cbCodCliente.Location = New System.Drawing.Point(130, 22)
        Me.cbCodCliente.Name = "cbCodCliente"
        Me.cbCodCliente.Size = New System.Drawing.Size(127, 25)
        Me.cbCodCliente.Sorted = True
        Me.cbCodCliente.TabIndex = 0
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(264, 22)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(502, 25)
        Me.cbCliente.TabIndex = 1
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(130, 53)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(127, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 3
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownWidth = 447
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(264, 53)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(502, 25)
        Me.cbArticulo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(15, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 161
        Me.Label5.Text = "Nº SERIE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1088, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "ESTADO"
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(866, 53)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(200, 25)
        Me.cbSubTipo.TabIndex = 5
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(791, 57)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(56, 17)
        Me.lbSubTipo.TabIndex = 128
        Me.lbSubTipo.Text = "SUBTIPO"
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(866, 22)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(200, 25)
        Me.cbTipo.TabIndex = 2
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(791, 26)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(35, 17)
        Me.lbTipo.TabIndex = 129
        Me.lbTipo.Text = "TIPO"
        '
        'lvEquipos
        '
        Me.lvEquipos.AllowColumnReorder = True
        Me.lvEquipos.AllowDrop = True
        Me.lvEquipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEquipos.AutoArrange = False
        Me.lvEquipos.BackgroundImageTiled = True
        Me.lvEquipos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCheck, Me.lvidEquipo, Me.lvnumSerie, Me.lvcoArticulo, Me.lvArticulo, Me.lvCliente, Me.lvPedido, Me.lvAlbaran, Me.lvFechaAlbaran, Me.lvFactura, Me.lvFechaFactura, Me.lvEstado, Me.lvidArticulo, Me.idEquipoHistorico, Me.lvVersion, Me.lvfechafabricacion})
        Me.lvEquipos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvEquipos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEquipos.FullRowSelect = True
        Me.lvEquipos.GridLines = True
        Me.lvEquipos.HideSelection = False
        Me.lvEquipos.Location = New System.Drawing.Point(12, 315)
        Me.lvEquipos.Name = "lvEquipos"
        Me.lvEquipos.ShowItemToolTips = True
        Me.lvEquipos.Size = New System.Drawing.Size(1299, 418)
        Me.lvEquipos.TabIndex = 1
        Me.lvEquipos.UseCompatibleStateImageBehavior = False
        Me.lvEquipos.View = System.Windows.Forms.View.Details
        '
        'lvCheck
        '
        Me.lvCheck.Text = ""
        Me.lvCheck.Width = 22
        '
        'lvidEquipo
        '
        Me.lvidEquipo.Text = "ID"
        Me.lvidEquipo.Width = 58
        '
        'lvnumSerie
        '
        Me.lvnumSerie.Text = "Nº SERIE"
        Me.lvnumSerie.Width = 72
        '
        'lvcoArticulo
        '
        Me.lvcoArticulo.Text = "CÓDIGO"
        Me.lvcoArticulo.Width = 84
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 201
        '
        'lvCliente
        '
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 160
        '
        'lvPedido
        '
        Me.lvPedido.Text = "PEDIDO"
        Me.lvPedido.Width = 72
        '
        'lvAlbaran
        '
        Me.lvAlbaran.Text = "ALBARÁN"
        Me.lvAlbaran.Width = 72
        '
        'lvFechaAlbaran
        '
        Me.lvFechaAlbaran.Text = "SERVIDO"
        Me.lvFechaAlbaran.Width = 78
        '
        'lvFactura
        '
        Me.lvFactura.Text = "FACTURA"
        Me.lvFactura.Width = 72
        '
        'lvFechaFactura
        '
        Me.lvFechaFactura.Text = "F. FACTURA"
        Me.lvFechaFactura.Width = 80
        '
        'lvEstado
        '
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 95
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'idEquipoHistorico
        '
        Me.idEquipoHistorico.Text = "idEquipoHistorico"
        Me.idEquipoHistorico.Width = 0
        '
        'lvVersion
        '
        Me.lvVersion.Text = "VERSIÓN"
        Me.lvVersion.Width = 65
        '
        'lvfechafabricacion
        '
        Me.lvfechafabricacion.Text = "FECHA FABRICACIÓN"
        Me.lvfechafabricacion.Width = 165
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(1182, 742)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 17)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "EQUIPOS"
        '
        'Encontrados
        '
        Me.Encontrados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Encontrados.BackColor = System.Drawing.SystemColors.Window
        Me.Encontrados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Encontrados.ForeColor = System.Drawing.Color.DarkRed
        Me.Encontrados.Location = New System.Drawing.Point(1251, 739)
        Me.Encontrados.Name = "Encontrados"
        Me.Encontrados.ReadOnly = True
        Me.Encontrados.Size = New System.Drawing.Size(60, 23)
        Me.Encontrados.TabIndex = 3
        Me.Encontrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(1015, 742)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 161
        Me.Label6.Text = "PEDIDOS"
        '
        'PedidosEncontrados
        '
        Me.PedidosEncontrados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PedidosEncontrados.BackColor = System.Drawing.SystemColors.Window
        Me.PedidosEncontrados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PedidosEncontrados.ForeColor = System.Drawing.Color.DarkRed
        Me.PedidosEncontrados.Location = New System.Drawing.Point(1082, 739)
        Me.PedidosEncontrados.Name = "PedidosEncontrados"
        Me.PedidosEncontrados.ReadOnly = True
        Me.PedidosEncontrados.Size = New System.Drawing.Size(60, 23)
        Me.PedidosEncontrados.TabIndex = 2
        Me.PedidosEncontrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pbCarga
        '
        Me.pbCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCarga.Location = New System.Drawing.Point(11, 744)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(118, 15)
        Me.pbCarga.TabIndex = 196
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(17, 321)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 199
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'bSeleccionar
        '
        Me.bSeleccionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSeleccionar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSeleccionar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSeleccionar.Location = New System.Drawing.Point(734, 30)
        Me.bSeleccionar.Name = "bSeleccionar"
        Me.bSeleccionar.Size = New System.Drawing.Size(90, 50)
        Me.bSeleccionar.TabIndex = 4
        Me.bSeleccionar.Text = "SELECCIÓN"
        Me.bSeleccionar.UseVisualStyleBackColor = True
        '
        'bimprimirresumen
        '
        Me.bimprimirresumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bimprimirresumen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bimprimirresumen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bimprimirresumen.Location = New System.Drawing.Point(859, 30)
        Me.bimprimirresumen.Name = "bimprimirresumen"
        Me.bimprimirresumen.Size = New System.Drawing.Size(90, 50)
        Me.bimprimirresumen.TabIndex = 5
        Me.bimprimirresumen.Text = "LISTADO RESUMEN"
        Me.bimprimirresumen.UseVisualStyleBackColor = True
        '
        'bCliente
        '
        Me.bCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.bCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCliente.Location = New System.Drawing.Point(54, 171)
        Me.bCliente.Name = "bCliente"
        Me.bCliente.Size = New System.Drawing.Size(72, 21)
        Me.bCliente.TabIndex = 201
        Me.bCliente.Text = "GUARDAR"
        Me.bCliente.UseVisualStyleBackColor = True
        '
        'BusquedaEquipos1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1326, 774)
        Me.Controls.Add(Me.ckSeleccion)
        Me.Controls.Add(Me.pbCarga)
        Me.Controls.Add(Me.PedidosEncontrados)
        Me.Controls.Add(Me.Encontrados)
        Me.Controls.Add(Me.lvEquipos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSeleccionar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bimprimirresumen)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BusquedaEquipos1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE EQUIPOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbCodCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numSerie As System.Windows.Forms.TextBox
    Friend WithEvents lvEquipos As System.Windows.Forms.ListView
    Friend WithEvents lvidEquipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcoArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Encontrados As System.Windows.Forms.TextBox
    Friend WithEvents lvnumSerie As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVerFactura As System.Windows.Forms.Button
    Friend WithEvents bVerAlbaran As System.Windows.Forms.Button
    Friend WithEvents bverPedido As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents Factura As System.Windows.Forms.TextBox
    Friend WithEvents Pedido As System.Windows.Forms.TextBox
    Friend WithEvents Albaran As System.Windows.Forms.TextBox
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PedidosEncontrados As System.Windows.Forms.TextBox
    Friend WithEvents idEquipoHistorico As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents pbCarga As System.Windows.Forms.ProgressBar
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.TextBox
    Friend WithEvents lvVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCheck As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents bSeleccionar As System.Windows.Forms.Button
    Friend WithEvents bimprimirresumen As System.Windows.Forms.Button
    Friend WithEvents lvfechafabricacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numSerie2 As System.Windows.Forms.TextBox
    Friend WithEvents lbEstadosEq As System.Windows.Forms.ListBox
    Friend WithEvents bCliente As System.Windows.Forms.Button
End Class
