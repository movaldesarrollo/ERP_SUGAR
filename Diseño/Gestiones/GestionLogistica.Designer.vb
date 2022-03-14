<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionLogistica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionLogistica))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ckVerAcabados = New System.Windows.Forms.CheckBox
        Me.bServir = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.bLimpiaFiltro = New System.Windows.Forms.Button
        Me.dtpFechaPedidoHasta = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaPrevistaHasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvCK = New System.Windows.Forms.ColumnHeader
        Me.lvidProduccion = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvAcabados = New System.Windows.Forms.ColumnHeader
        Me.lvPreparados = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedido = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPedido = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPrevista = New System.Windows.Forms.ColumnHeader
        Me.lvPrioridad = New System.Windows.Forms.ColumnHeader
        Me.lvStock = New System.Windows.Forms.ColumnHeader
        Me.lvidConceptoPedido = New System.Windows.Forms.ColumnHeader
        Me.lvServidos = New System.Windows.Forms.ColumnHeader
        Me.lvVersion = New System.Windows.Forms.ColumnHeader
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.NumSerieHasta = New System.Windows.Forms.TextBox
        Me.Preparados = New System.Windows.Forms.TextBox
        Me.numSerieDesde = New System.Windows.Forms.TextBox
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbArticulo = New System.Windows.Forms.Label
        Me.dtpFechaPedidoDesde = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaPrevistaDesde = New System.Windows.Forms.DateTimePicker
        Me.EnMasSemanas = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbFiltro3 = New System.Windows.Forms.RadioButton
        Me.lbNumDoc = New System.Windows.Forms.Label
        Me.rbFiltro2 = New System.Windows.Forms.RadioButton
        Me.rbTodos = New System.Windows.Forms.RadioButton
        Me.rbFiltro1 = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbnumPedido = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbCodCliente = New System.Windows.Forms.ComboBox
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.bVerArticulo = New System.Windows.Forms.Button
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.bBuscarCliente = New System.Windows.Forms.Button
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.bBuscarArticulo = New System.Windows.Forms.Button
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.SemanaProxima = New System.Windows.Forms.TextBox
        Me.En2Semanas = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.EstaSemana = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ckVerAcabados)
        Me.GroupBox1.Controls.Add(Me.bServir)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.bLimpiaFiltro)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPedidoHasta)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPrevistaHasta)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPedidoDesde)
        Me.GroupBox1.Controls.Add(Me.dtpFechaPrevistaDesde)
        Me.GroupBox1.Controls.Add(Me.EnMasSemanas)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.SemanaProxima)
        Me.GroupBox1.Controls.Add(Me.En2Semanas)
        Me.GroupBox1.Controls.Add(Me.Total)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.EstaSemana)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 791)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ckVerAcabados
        '
        Me.ckVerAcabados.AutoSize = True
        Me.ckVerAcabados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerAcabados.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVerAcabados.Location = New System.Drawing.Point(755, 55)
        Me.ckVerAcabados.Name = "ckVerAcabados"
        Me.ckVerAcabados.Size = New System.Drawing.Size(141, 21)
        Me.ckVerAcabados.TabIndex = 19
        Me.ckVerAcabados.Text = "VER PRODUCIDOS"
        Me.ckVerAcabados.UseVisualStyleBackColor = True
        Me.ckVerAcabados.Visible = False
        '
        'bServir
        '
        Me.bServir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bServir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bServir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bServir.Location = New System.Drawing.Point(944, 23)
        Me.bServir.Name = "bServir"
        Me.bServir.Size = New System.Drawing.Size(88, 50)
        Me.bServir.TabIndex = 2
        Me.bServir.Text = "SERVIR"
        Me.bServir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(327, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 17)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "FECHA ENTREGA ENTRE"
        Me.Label2.Visible = False
        '
        'bLimpiaFiltro
        '
        Me.bLimpiaFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiaFiltro.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiaFiltro.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiaFiltro.Location = New System.Drawing.Point(1049, 23)
        Me.bLimpiaFiltro.Name = "bLimpiaFiltro"
        Me.bLimpiaFiltro.Size = New System.Drawing.Size(88, 50)
        Me.bLimpiaFiltro.TabIndex = 3
        Me.bLimpiaFiltro.Text = "LIMPIAR"
        Me.bLimpiaFiltro.UseVisualStyleBackColor = True
        '
        'dtpFechaPedidoHasta
        '
        Me.dtpFechaPedidoHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPedidoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPedidoHasta.Location = New System.Drawing.Point(588, 19)
        Me.dtpFechaPedidoHasta.Name = "dtpFechaPedidoHasta"
        Me.dtpFechaPedidoHasta.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPedidoHasta.TabIndex = 14
        Me.dtpFechaPedidoHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        Me.dtpFechaPedidoHasta.Visible = False
        '
        'dtpFechaPrevistaHasta
        '
        Me.dtpFechaPrevistaHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevistaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevistaHasta.Location = New System.Drawing.Point(604, 46)
        Me.dtpFechaPrevistaHasta.Name = "dtpFechaPrevistaHasta"
        Me.dtpFechaPrevistaHasta.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevistaHasta.TabIndex = 17
        Me.dtpFechaPrevistaHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        Me.dtpFechaPrevistaHasta.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ckSeleccion)
        Me.GroupBox3.Controls.Add(Me.lvConceptos)
        Me.GroupBox3.Controls.Add(Me.bLimpiar)
        Me.GroupBox3.Controls.Add(Me.Articulo)
        Me.GroupBox3.Controls.Add(Me.NumSerieHasta)
        Me.GroupBox3.Controls.Add(Me.Preparados)
        Me.GroupBox3.Controls.Add(Me.numSerieDesde)
        Me.GroupBox3.Controls.Add(Me.codArticulo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lbArticulo)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 214)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1243, 566)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(16, 25)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 191
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.CheckBoxes = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCK, Me.lvidProduccion, Me.lvidArticulo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCantidad, Me.lvAcabados, Me.lvPreparados, Me.lvEstado, Me.lvCliente, Me.lvnumPedido, Me.lvFechaPedido, Me.lvFechaPrevista, Me.lvPrioridad, Me.lvStock, Me.lvidConceptoPedido, Me.lvServidos, Me.lvVersion})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(11, 18)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(1220, 532)
        Me.lvConceptos.TabIndex = 1
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvCK
        '
        Me.lvCK.Text = ""
        Me.lvCK.Width = 22
        '
        'lvidProduccion
        '
        Me.lvidProduccion.Text = "idProduccion"
        Me.lvidProduccion.Width = 0
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 105
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 195
        '
        'lvCantidad
        '
        Me.lvCantidad.DisplayIndex = 6
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvCantidad.Width = 75
        '
        'lvAcabados
        '
        Me.lvAcabados.DisplayIndex = 8
        Me.lvAcabados.Text = "FABRICADOS"
        Me.lvAcabados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvAcabados.Width = 92
        '
        'lvPreparados
        '
        Me.lvPreparados.DisplayIndex = 9
        Me.lvPreparados.Text = "PREPARADOS"
        Me.lvPreparados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvPreparados.Width = 92
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 10
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 94
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 11
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 103
        '
        'lvnumPedido
        '
        Me.lvnumPedido.DisplayIndex = 12
        Me.lvnumPedido.Text = "PEDIDO"
        Me.lvnumPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvnumPedido.Width = 68
        '
        'lvFechaPedido
        '
        Me.lvFechaPedido.DisplayIndex = 13
        Me.lvFechaPedido.Text = "F. PEDIDO"
        Me.lvFechaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvFechaPedido.Width = 80
        '
        'lvFechaPrevista
        '
        Me.lvFechaPrevista.DisplayIndex = 14
        Me.lvFechaPrevista.Text = "F. ENTREGA"
        Me.lvFechaPrevista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvFechaPrevista.Width = 80
        '
        'lvPrioridad
        '
        Me.lvPrioridad.DisplayIndex = 15
        Me.lvPrioridad.Text = "PR."
        Me.lvPrioridad.Width = 29
        '
        'lvStock
        '
        Me.lvStock.DisplayIndex = 16
        Me.lvStock.Text = "STOCK"
        Me.lvStock.Width = 50
        '
        'lvidConceptoPedido
        '
        Me.lvidConceptoPedido.DisplayIndex = 17
        Me.lvidConceptoPedido.Text = "idConcepto"
        Me.lvidConceptoPedido.Width = 0
        '
        'lvServidos
        '
        Me.lvServidos.DisplayIndex = 7
        Me.lvServidos.Text = "SERVIDOS"
        Me.lvServidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvServidos.Width = 71
        '
        'lvVersion
        '
        Me.lvVersion.DisplayIndex = 5
        Me.lvVersion.Text = "VER."
        Me.lvVersion.Width = 51
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1204, 18)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 190
        Me.bLimpiar.UseVisualStyleBackColor = True
        Me.bLimpiar.Visible = False
        '
        'Articulo
        '
        Me.Articulo.BackColor = System.Drawing.SystemColors.Window
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(253, 19)
        Me.Articulo.MaxLength = 150
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Size = New System.Drawing.Size(369, 23)
        Me.Articulo.TabIndex = 181
        '
        'NumSerieHasta
        '
        Me.NumSerieHasta.BackColor = System.Drawing.SystemColors.Window
        Me.NumSerieHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumSerieHasta.Location = New System.Drawing.Point(1110, 19)
        Me.NumSerieHasta.MaxLength = 150
        Me.NumSerieHasta.Name = "NumSerieHasta"
        Me.NumSerieHasta.Size = New System.Drawing.Size(88, 23)
        Me.NumSerieHasta.TabIndex = 182
        Me.NumSerieHasta.Visible = False
        '
        'Preparados
        '
        Me.Preparados.BackColor = System.Drawing.SystemColors.Window
        Me.Preparados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preparados.Location = New System.Drawing.Point(815, 19)
        Me.Preparados.MaxLength = 150
        Me.Preparados.Name = "Preparados"
        Me.Preparados.ReadOnly = True
        Me.Preparados.Size = New System.Drawing.Size(69, 23)
        Me.Preparados.TabIndex = 182
        Me.Preparados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numSerieDesde
        '
        Me.numSerieDesde.BackColor = System.Drawing.SystemColors.Window
        Me.numSerieDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerieDesde.Location = New System.Drawing.Point(1003, 19)
        Me.numSerieDesde.MaxLength = 150
        Me.numSerieDesde.Name = "numSerieDesde"
        Me.numSerieDesde.Size = New System.Drawing.Size(88, 23)
        Me.numSerieDesde.TabIndex = 182
        Me.numSerieDesde.Visible = False
        '
        'codArticulo
        '
        Me.codArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(121, 19)
        Me.codArticulo.MaxLength = 150
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(127, 23)
        Me.codArticulo.TabIndex = 180
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(1095, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 17)
        Me.Label4.TabIndex = 184
        Me.Label4.Text = "-"
        Me.Label4.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(635, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(175, 17)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "PREPARADOS PARA SERVIR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(940, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Nº SERIE"
        Me.Label1.Visible = False
        '
        'lbArticulo
        '
        Me.lbArticulo.AutoSize = True
        Me.lbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArticulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbArticulo.Location = New System.Drawing.Point(16, 22)
        Me.lbArticulo.Name = "lbArticulo"
        Me.lbArticulo.Size = New System.Drawing.Size(69, 17)
        Me.lbArticulo.TabIndex = 0
        Me.lbArticulo.Text = "ARTÍCULO"
        '
        'dtpFechaPedidoDesde
        '
        Me.dtpFechaPedidoDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPedidoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPedidoDesde.Location = New System.Drawing.Point(467, 19)
        Me.dtpFechaPedidoDesde.Name = "dtpFechaPedidoDesde"
        Me.dtpFechaPedidoDesde.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPedidoDesde.TabIndex = 13
        Me.dtpFechaPedidoDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        Me.dtpFechaPedidoDesde.Visible = False
        '
        'dtpFechaPrevistaDesde
        '
        Me.dtpFechaPrevistaDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevistaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevistaDesde.Location = New System.Drawing.Point(483, 46)
        Me.dtpFechaPrevistaDesde.Name = "dtpFechaPrevistaDesde"
        Me.dtpFechaPrevistaDesde.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevistaDesde.TabIndex = 16
        Me.dtpFechaPrevistaDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        Me.dtpFechaPrevistaDesde.Visible = False
        '
        'EnMasSemanas
        '
        Me.EnMasSemanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EnMasSemanas.BackColor = System.Drawing.SystemColors.Window
        Me.EnMasSemanas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnMasSemanas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EnMasSemanas.Location = New System.Drawing.Point(913, 757)
        Me.EnMasSemanas.MaxLength = 15
        Me.EnMasSemanas.Name = "EnMasSemanas"
        Me.EnMasSemanas.Size = New System.Drawing.Size(81, 23)
        Me.EnMasSemanas.TabIndex = 16
        Me.EnMasSemanas.TabStop = False
        Me.EnMasSemanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EnMasSemanas.Visible = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(781, 760)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 17)
        Me.Label22.TabIndex = 187
        Me.Label22.Text = "MAS DE 2 SEMANAS"
        Me.Label22.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rbFiltro3)
        Me.GroupBox2.Controls.Add(Me.lbNumDoc)
        Me.GroupBox2.Controls.Add(Me.rbFiltro2)
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbFiltro1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbnumPedido)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.cbCodCliente)
        Me.GroupBox2.Controls.Add(Me.cbCliente)
        Me.GroupBox2.Controls.Add(Me.bVerArticulo)
        Me.GroupBox2.Controls.Add(Me.bVerCliente)
        Me.GroupBox2.Controls.Add(Me.bBuscarCliente)
        Me.GroupBox2.Controls.Add(Me.cbCodArticulo)
        Me.GroupBox2.Controls.Add(Me.bBuscarArticulo)
        Me.GroupBox2.Controls.Add(Me.cbArticulo)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1243, 130)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'rbFiltro3
        '
        Me.rbFiltro3.AutoSize = True
        Me.rbFiltro3.BackColor = System.Drawing.Color.LightGreen
        Me.rbFiltro3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltro3.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbFiltro3.Location = New System.Drawing.Point(882, 63)
        Me.rbFiltro3.Name = "rbFiltro3"
        Me.rbFiltro3.Size = New System.Drawing.Size(33, 21)
        Me.rbFiltro3.TabIndex = 7
        Me.rbFiltro3.TabStop = True
        Me.rbFiltro3.Text = "3"
        Me.rbFiltro3.UseVisualStyleBackColor = False
        '
        'lbNumDoc
        '
        Me.lbNumDoc.AutoSize = True
        Me.lbNumDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc.Location = New System.Drawing.Point(19, 32)
        Me.lbNumDoc.Name = "lbNumDoc"
        Me.lbNumDoc.Size = New System.Drawing.Size(87, 19)
        Me.lbNumDoc.TabIndex = 189
        Me.lbNumDoc.Text = "Nº PEDIDO"
        '
        'rbFiltro2
        '
        Me.rbFiltro2.AutoSize = True
        Me.rbFiltro2.BackColor = System.Drawing.Color.NavajoWhite
        Me.rbFiltro2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltro2.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbFiltro2.Location = New System.Drawing.Point(849, 63)
        Me.rbFiltro2.Name = "rbFiltro2"
        Me.rbFiltro2.Size = New System.Drawing.Size(33, 21)
        Me.rbFiltro2.TabIndex = 6
        Me.rbFiltro2.TabStop = True
        Me.rbFiltro2.Text = "2"
        Me.rbFiltro2.UseVisualStyleBackColor = False
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.rbTodos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbTodos.Location = New System.Drawing.Point(915, 63)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(67, 21)
        Me.rbTodos.TabIndex = 8
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "TODAS"
        Me.rbTodos.UseVisualStyleBackColor = False
        '
        'rbFiltro1
        '
        Me.rbFiltro1.AutoSize = True
        Me.rbFiltro1.BackColor = System.Drawing.Color.Pink
        Me.rbFiltro1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltro1.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbFiltro1.Location = New System.Drawing.Point(820, 63)
        Me.rbFiltro1.Name = "rbFiltro1"
        Me.rbFiltro1.Size = New System.Drawing.Size(33, 21)
        Me.rbFiltro1.TabIndex = 5
        Me.rbFiltro1.TabStop = True
        Me.rbFiltro1.Text = "1"
        Me.rbFiltro1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(718, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 17)
        Me.Label6.TabIndex = 179
        Me.Label6.Text = "PRIORIDAD"
        '
        'cbnumPedido
        '
        Me.cbnumPedido.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbnumPedido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cbnumPedido.FormattingEnabled = True
        Me.cbnumPedido.Location = New System.Drawing.Point(121, 28)
        Me.cbnumPedido.Name = "cbnumPedido"
        Me.cbnumPedido.Size = New System.Drawing.Size(127, 27)
        Me.cbnumPedido.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(19, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "CLIENTE"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(19, 97)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 17)
        Me.Label39.TabIndex = 179
        Me.Label39.Text = "ARTÍCULO"
        '
        'cbCodCliente
        '
        Me.cbCodCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodCliente.FormattingEnabled = True
        Me.cbCodCliente.Location = New System.Drawing.Point(121, 61)
        Me.cbCodCliente.Name = "cbCodCliente"
        Me.cbCodCliente.Size = New System.Drawing.Size(127, 25)
        Me.cbCodCliente.TabIndex = 1
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(282, 61)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(340, 25)
        Me.cbCliente.TabIndex = 3
        '
        'bVerArticulo
        '
        Me.bVerArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticulo.Location = New System.Drawing.Point(639, 92)
        Me.bVerArticulo.Name = "bVerArticulo"
        Me.bVerArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticulo.TabIndex = 12
        Me.bVerArticulo.UseVisualStyleBackColor = True
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(639, 61)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 4
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarCliente.Location = New System.Drawing.Point(253, 61)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarCliente.TabIndex = 2
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(121, 92)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(127, 25)
        Me.cbCodArticulo.TabIndex = 9
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticulo.Location = New System.Drawing.Point(253, 92)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticulo.TabIndex = 10
        Me.bBuscarArticulo.UseVisualStyleBackColor = True
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownWidth = 447
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(282, 92)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(340, 25)
        Me.cbArticulo.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(582, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 17)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Y"
        Me.Label9.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(311, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 17)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "FECHA PEDIDO ENTRE"
        Me.Label13.Visible = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(551, 760)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 17)
        Me.Label16.TabIndex = 186
        Me.Label16.Text = "EN 2 SEMANAS"
        Me.Label16.Visible = False
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(728, 22)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(56, 17)
        Me.Label57.TabIndex = 115
        Me.Label57.Text = "ESTADO"
        Me.Label57.Visible = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(297, 760)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 17)
        Me.Label17.TabIndex = 185
        Me.Label17.Text = "SEMANA PRÓXIMA"
        Me.Label17.Visible = False
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(266, 760)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 17)
        Me.Label21.TabIndex = 184
        Me.Label21.Text = "U"
        Me.Label21.Visible = False
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(784, 19)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(102, 25)
        Me.cbEstado.Sorted = True
        Me.cbEstado.TabIndex = 8
        Me.cbEstado.Visible = False
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(509, 760)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 17)
        Me.Label18.TabIndex = 184
        Me.Label18.Text = "U"
        Me.Label18.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(566, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Y"
        Me.Label8.Visible = False
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(997, 760)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 17)
        Me.Label23.TabIndex = 184
        Me.Label23.Text = "U"
        Me.Label23.Visible = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(738, 760)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 17)
        Me.Label15.TabIndex = 184
        Me.Label15.Text = "U"
        Me.Label15.Visible = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1154, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(22, 760)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(158, 17)
        Me.Label19.TabIndex = 183
        Me.Label19.Text = "ENTREGAS ESTA SEMANA"
        Me.Label19.Visible = False
        '
        'SemanaProxima
        '
        Me.SemanaProxima.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SemanaProxima.BackColor = System.Drawing.SystemColors.Window
        Me.SemanaProxima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SemanaProxima.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SemanaProxima.Location = New System.Drawing.Point(422, 757)
        Me.SemanaProxima.MaxLength = 15
        Me.SemanaProxima.Name = "SemanaProxima"
        Me.SemanaProxima.Size = New System.Drawing.Size(81, 23)
        Me.SemanaProxima.TabIndex = 14
        Me.SemanaProxima.TabStop = False
        Me.SemanaProxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SemanaProxima.Visible = False
        '
        'En2Semanas
        '
        Me.En2Semanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.En2Semanas.BackColor = System.Drawing.SystemColors.Window
        Me.En2Semanas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.En2Semanas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.En2Semanas.Location = New System.Drawing.Point(654, 757)
        Me.En2Semanas.MaxLength = 15
        Me.En2Semanas.Name = "En2Semanas"
        Me.En2Semanas.Size = New System.Drawing.Size(81, 23)
        Me.En2Semanas.TabIndex = 15
        Me.En2Semanas.TabStop = False
        Me.En2Semanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.En2Semanas.Visible = False
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(1143, 757)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(81, 23)
        Me.Total.TabIndex = 17
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Total.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(1095, 760)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "TOTAL"
        Me.Label5.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(1227, 760)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 17)
        Me.Label11.TabIndex = 174
        Me.Label11.Text = "U"
        Me.Label11.Visible = False
        '
        'EstaSemana
        '
        Me.EstaSemana.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EstaSemana.BackColor = System.Drawing.SystemColors.Window
        Me.EstaSemana.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstaSemana.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstaSemana.Location = New System.Drawing.Point(182, 757)
        Me.EstaSemana.MaxLength = 15
        Me.EstaSemana.Name = "EstaSemana"
        Me.EstaSemana.Size = New System.Drawing.Size(81, 23)
        Me.EstaSemana.TabIndex = 13
        Me.EstaSemana.TabStop = False
        Me.EstaSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EstaSemana.Visible = False
        '
        'GestionLogistica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 793)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionLogistica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN LOGÍSTICA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents EnMasSemanas As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckVerAcabados As System.Windows.Forms.CheckBox
    Friend WithEvents rbFiltro3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPedidoHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbFiltro2 As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaPedidoDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaPrevistaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltro1 As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaPrevistaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbnumPedido As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbCodCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents bVerArticulo As System.Windows.Forms.Button
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents EstaSemana As System.Windows.Forms.TextBox
    Friend WithEvents SemanaProxima As System.Windows.Forms.TextBox
    Friend WithEvents En2Semanas As System.Windows.Forms.TextBox
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidProduccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAcabados As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPrevista As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrioridad As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiaFiltro As System.Windows.Forms.Button
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents NumSerieHasta As System.Windows.Forms.TextBox
    Friend WithEvents numSerieDesde As System.Windows.Forms.TextBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbArticulo As System.Windows.Forms.Label
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Preparados As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lvPreparados As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidConceptoPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbNumDoc As System.Windows.Forms.Label
    Friend WithEvents bServir As System.Windows.Forms.Button
    Friend WithEvents lvCK As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvServidos As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvVersion As System.Windows.Forms.ColumnHeader
End Class
