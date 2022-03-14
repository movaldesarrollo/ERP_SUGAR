<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busquedaNumSerie
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
        Me.components = New System.ComponentModel.Container()
        Me.lvProductos = New System.Windows.Forms.ListView()
        Me.colIDCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumSerieCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsDesvincular = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DESVINCULARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bBorrar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbAmbos = New System.Windows.Forms.RadioButton()
        Me.rbNoAsignados = New System.Windows.Forms.RadioButton()
        Me.rbAsignados = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbProducto = New System.Windows.Forms.ComboBox()
        Me.txCode = New System.Windows.Forms.TextBox()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.gbLapsoTiempo = New System.Windows.Forms.GroupBox()
        Me.rbEntreFechas = New System.Windows.Forms.RadioButton()
        Me.rbMesAño = New System.Windows.Forms.RadioButton()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAños = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMeses = New System.Windows.Forms.ComboBox()
        Me.cmsDesvincular.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbLapsoTiempo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvProductos
        '
        Me.lvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProductos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIDCelula, Me.colNumSerieCelula, Me.colFecha, Me.colArticulo, Me.colNumSerie})
        Me.lvProductos.ContextMenuStrip = Me.cmsDesvincular
        Me.lvProductos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProductos.FullRowSelect = True
        Me.lvProductos.GridLines = True
        Me.lvProductos.Location = New System.Drawing.Point(14, 213)
        Me.lvProductos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvProductos.Name = "lvProductos"
        Me.lvProductos.Size = New System.Drawing.Size(1234, 422)
        Me.lvProductos.TabIndex = 2
        Me.lvProductos.TabStop = False
        Me.lvProductos.UseCompatibleStateImageBehavior = False
        Me.lvProductos.View = System.Windows.Forms.View.Details
        '
        'colIDCelula
        '
        Me.colIDCelula.Text = "IDCELULA"
        Me.colIDCelula.Width = 0
        '
        'colNumSerieCelula
        '
        Me.colNumSerieCelula.Text = "NºSERIE"
        Me.colNumSerieCelula.Width = 264
        '
        'colFecha
        '
        Me.colFecha.Text = "FECHA FABRICACIÓN"
        Me.colFecha.Width = 253
        '
        'colArticulo
        '
        Me.colArticulo.Text = "CÓDIGO - ARTÍCULO"
        Me.colArticulo.Width = 555
        '
        'colNumSerie
        '
        Me.colNumSerie.Text = "NÚMERO SERIE"
        Me.colNumSerie.Width = 132
        '
        'cmsDesvincular
        '
        Me.cmsDesvincular.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DESVINCULARToolStripMenuItem})
        Me.cmsDesvincular.Name = "cmsDesvincular"
        Me.cmsDesvincular.Size = New System.Drawing.Size(151, 26)
        '
        'DESVINCULARToolStripMenuItem
        '
        Me.DESVINCULARToolStripMenuItem.Name = "DESVINCULARToolStripMenuItem"
        Me.DESVINCULARToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.DESVINCULARToolStripMenuItem.Text = "DESVINCULAR"
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(630, 13)
        Me.bGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(150, 71)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(786, 13)
        Me.bBorrar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(150, 71)
        Me.bBorrar.TabIndex = 4
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 180
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1098, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(150, 71)
        Me.bSalir.TabIndex = 6
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbAmbos)
        Me.GroupBox1.Controls.Add(Me.rbNoAsignados)
        Me.GroupBox1.Controls.Add(Me.rbAsignados)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbProducto)
        Me.GroupBox1.Controls.Add(Me.txCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 92)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(720, 113)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARAMETROS DE BÚSQUEDA"
        '
        'rbAmbos
        '
        Me.rbAmbos.AutoSize = True
        Me.rbAmbos.Checked = True
        Me.rbAmbos.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.rbAmbos.Location = New System.Drawing.Point(292, 74)
        Me.rbAmbos.Name = "rbAmbos"
        Me.rbAmbos.Size = New System.Drawing.Size(87, 25)
        Me.rbAmbos.TabIndex = 4
        Me.rbAmbos.TabStop = True
        Me.rbAmbos.Text = "AMBOS"
        Me.rbAmbos.UseVisualStyleBackColor = True
        '
        'rbNoAsignados
        '
        Me.rbNoAsignados.AutoSize = True
        Me.rbNoAsignados.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.rbNoAsignados.Location = New System.Drawing.Point(137, 74)
        Me.rbNoAsignados.Name = "rbNoAsignados"
        Me.rbNoAsignados.Size = New System.Drawing.Size(157, 25)
        Me.rbNoAsignados.TabIndex = 3
        Me.rbNoAsignados.Text = "NO ASIGNADOS"
        Me.rbNoAsignados.UseVisualStyleBackColor = True
        '
        'rbAsignados
        '
        Me.rbAsignados.AutoSize = True
        Me.rbAsignados.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.rbAsignados.Location = New System.Drawing.Point(11, 74)
        Me.rbAsignados.Name = "rbAsignados"
        Me.rbAsignados.Size = New System.Drawing.Size(127, 25)
        Me.rbAsignados.TabIndex = 2
        Me.rbAsignados.Text = "ASIGNADOS"
        Me.rbAsignados.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "NºSERIE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(261, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "CÓDIGO - ARTÍCULO"
        '
        'cbProducto
        '
        Me.cbProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProducto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProducto.FormattingEnabled = True
        Me.cbProducto.Location = New System.Drawing.Point(443, 31)
        Me.cbProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbProducto.Name = "cbProducto"
        Me.cbProducto.Size = New System.Drawing.Size(258, 29)
        Me.cbProducto.TabIndex = 1
        '
        'txCode
        '
        Me.txCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txCode.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCode.Location = New System.Drawing.Point(82, 34)
        Me.txCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txCode.MaxLength = 11
        Me.txCode.Name = "txCode"
        Me.txCode.Size = New System.Drawing.Size(173, 27)
        Me.txCode.TabIndex = 0
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(942, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(150, 71)
        Me.bLimpiar.TabIndex = 5
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1072, 645)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 21)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "TOTAL"
        '
        'txTotal
        '
        Me.txTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txTotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotal.Location = New System.Drawing.Point(1138, 642)
        Me.txTotal.Name = "txTotal"
        Me.txTotal.Size = New System.Drawing.Size(110, 27)
        Me.txTotal.TabIndex = 184
        Me.txTotal.TabStop = False
        Me.txTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 639)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(384, 19)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "ASIGNADOS A UN PEDIDO, NO SE PUEDEN BORRAR"
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(474, 13)
        Me.bBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(150, 71)
        Me.bBuscar.TabIndex = 2
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'gbLapsoTiempo
        '
        Me.gbLapsoTiempo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbLapsoTiempo.Controls.Add(Me.rbEntreFechas)
        Me.gbLapsoTiempo.Controls.Add(Me.rbMesAño)
        Me.gbLapsoTiempo.Controls.Add(Me.dtpHasta)
        Me.gbLapsoTiempo.Controls.Add(Me.Label8)
        Me.gbLapsoTiempo.Controls.Add(Me.Label7)
        Me.gbLapsoTiempo.Controls.Add(Me.dtpDesde)
        Me.gbLapsoTiempo.Controls.Add(Me.Label6)
        Me.gbLapsoTiempo.Controls.Add(Me.cbAños)
        Me.gbLapsoTiempo.Controls.Add(Me.Label3)
        Me.gbLapsoTiempo.Controls.Add(Me.cbMeses)
        Me.gbLapsoTiempo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLapsoTiempo.Location = New System.Drawing.Point(740, 92)
        Me.gbLapsoTiempo.Name = "gbLapsoTiempo"
        Me.gbLapsoTiempo.Size = New System.Drawing.Size(508, 113)
        Me.gbLapsoTiempo.TabIndex = 1
        Me.gbLapsoTiempo.TabStop = False
        Me.gbLapsoTiempo.Text = "LAPSO DE TIEMPO"
        '
        'rbEntreFechas
        '
        Me.rbEntreFechas.AutoSize = True
        Me.rbEntreFechas.Location = New System.Drawing.Point(17, 74)
        Me.rbEntreFechas.Name = "rbEntreFechas"
        Me.rbEntreFechas.Size = New System.Drawing.Size(14, 13)
        Me.rbEntreFechas.TabIndex = 3
        Me.rbEntreFechas.UseVisualStyleBackColor = True
        '
        'rbMesAño
        '
        Me.rbMesAño.AutoSize = True
        Me.rbMesAño.Checked = True
        Me.rbMesAño.Location = New System.Drawing.Point(17, 40)
        Me.rbMesAño.Name = "rbMesAño"
        Me.rbMesAño.Size = New System.Drawing.Size(14, 13)
        Me.rbMesAño.TabIndex = 0
        Me.rbMesAño.TabStop = True
        Me.rbMesAño.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(349, 67)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(144, 27)
        Me.dtpHasta.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(265, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 21)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "HASTA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 21)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "DESDE"
        '
        'dtpDesde
        '
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(115, 67)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(144, 27)
        Me.dtpDesde.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(265, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 21)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "AÑO"
        '
        'cbAños
        '
        Me.cbAños.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAños.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAños.FormattingEnabled = True
        Me.cbAños.Location = New System.Drawing.Point(349, 31)
        Me.cbAños.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbAños.Name = "cbAños"
        Me.cbAños.Size = New System.Drawing.Size(144, 29)
        Me.cbAños.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 21)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "MES"
        '
        'cbMeses
        '
        Me.cbMeses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMeses.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMeses.FormattingEnabled = True
        Me.cbMeses.Location = New System.Drawing.Point(115, 31)
        Me.cbMeses.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbMeses.Name = "cbMeses"
        Me.cbMeses.Size = New System.Drawing.Size(144, 29)
        Me.cbMeses.TabIndex = 1
        '
        'busquedaNumSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 677)
        Me.Controls.Add(Me.gbLapsoTiempo)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvProductos)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bLimpiar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimizeBox = False
        Me.Name = "busquedaNumSerie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE NÚMEROS DE SERIE ASIGNADOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.cmsDesvincular.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbLapsoTiempo.ResumeLayout(False)
        Me.gbLapsoTiempo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvProductos As ListView
    Friend WithEvents colIDCelula As ColumnHeader
    Friend WithEvents colNumSerieCelula As ColumnHeader
    Friend WithEvents colArticulo As ColumnHeader
    Friend WithEvents colFecha As ColumnHeader
    Friend WithEvents bGuardar As Button
    Friend WithEvents bBorrar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents bSalir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbProducto As ComboBox
    Friend WithEvents txCode As TextBox
    Friend WithEvents bLimpiar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txTotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents bBuscar As Button
    Friend WithEvents colNumSerie As ColumnHeader
    Friend WithEvents rbAmbos As RadioButton
    Friend WithEvents rbNoAsignados As RadioButton
    Friend WithEvents rbAsignados As RadioButton
    Friend WithEvents gbLapsoTiempo As GroupBox
    Friend WithEvents rbEntreFechas As RadioButton
    Friend WithEvents rbMesAño As RadioButton
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents cbAños As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbMeses As ComboBox
    Friend WithEvents cmsDesvincular As ContextMenuStrip
    Friend WithEvents DESVINCULARToolStripMenuItem As ToolStripMenuItem
End Class
