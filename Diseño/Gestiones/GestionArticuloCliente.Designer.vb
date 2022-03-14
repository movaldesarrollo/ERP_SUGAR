<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionArticuloCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionArticuloCliente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbCambio = New System.Windows.Forms.Label
        Me.lvProductos = New System.Windows.Forms.ListView
        Me.lvIdProdCli = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCodAArticuloCli = New System.Windows.Forms.ColumnHeader
        Me.lvArticuloCli = New System.Windows.Forms.ColumnHeader
        Me.lvDescuento = New System.Windows.Forms.ColumnHeader
        Me.lvPrecio = New System.Windows.Forms.ColumnHeader
        Me.lvDocumento = New System.Windows.Forms.ColumnHeader
        Me.Encontrados = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ckHistorico = New System.Windows.Forms.CheckBox
        Me.lbMoneda2 = New System.Windows.Forms.Label
        Me.lbMoneda = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.PVP = New System.Windows.Forms.TextBox
        Me.PrecioNeto = New System.Windows.Forms.TextBox
        Me.Descuento = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.subTipo = New System.Windows.Forms.TextBox
        Me.Tipo = New System.Windows.Forms.TextBox
        Me.CodArticuloCli = New System.Windows.Forms.TextBox
        Me.ArticuloCli = New System.Windows.Forms.TextBox
        Me.bBuscarCliente = New System.Windows.Forms.Button
        Me.bBuscarArticulo = New System.Windows.Forms.Button
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.bverArticulo = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.cbcodCliente = New System.Windows.Forms.ComboBox
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker
        Me.Label41 = New System.Windows.Forms.Label
        Me.lbFechaBaja = New System.Windows.Forms.Label
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbCambio)
        Me.GroupBox1.Controls.Add(Me.lvProductos)
        Me.GroupBox1.Controls.Add(Me.Encontrados)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.bBorrar)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(963, 760)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(534, 726)
        Me.lbCambio.Name = "lbCambio"
        Me.lbCambio.Size = New System.Drawing.Size(176, 17)
        Me.lbCambio.TabIndex = 190
        Me.lbCambio.Text = "CAMBIO NO ACTUALIZADO"
        Me.lbCambio.Visible = False
        '
        'lvProductos
        '
        Me.lvProductos.AllowColumnReorder = True
        Me.lvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProductos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvIdProdCli, Me.lvidArticulo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCodAArticuloCli, Me.lvArticuloCli, Me.lvDescuento, Me.lvPrecio, Me.lvDocumento})
        Me.lvProductos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProductos.FullRowSelect = True
        Me.lvProductos.GridLines = True
        Me.lvProductos.HideSelection = False
        Me.lvProductos.Location = New System.Drawing.Point(12, 276)
        Me.lvProductos.MultiSelect = False
        Me.lvProductos.Name = "lvProductos"
        Me.lvProductos.ShowItemToolTips = True
        Me.lvProductos.Size = New System.Drawing.Size(945, 434)
        Me.lvProductos.TabIndex = 1
        Me.lvProductos.UseCompatibleStateImageBehavior = False
        Me.lvProductos.View = System.Windows.Forms.View.Details
        '
        'lvIdProdCli
        '
        Me.lvIdProdCli.Text = "IDProdCli"
        Me.lvIdProdCli.Width = 0
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 100
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 191
        '
        'lvCodAArticuloCli
        '
        Me.lvCodAArticuloCli.Text = "CÓDIGO CLI"
        Me.lvCodAArticuloCli.Width = 104
        '
        'lvArticuloCli
        '
        Me.lvArticuloCli.Text = "ARTÍCULO CLIENTE"
        Me.lvArticuloCli.Width = 210
        '
        'lvDescuento
        '
        Me.lvDescuento.Text = "DTO."
        Me.lvDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvDescuento.Width = 56
        '
        'lvPrecio
        '
        Me.lvPrecio.Text = "PRECIO"
        Me.lvPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecio.Width = 84
        '
        'lvDocumento
        '
        Me.lvDocumento.Text = "ÚLTIMO DOC."
        Me.lvDocumento.Width = 151
        '
        'Encontrados
        '
        Me.Encontrados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Encontrados.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Encontrados.ForeColor = System.Drawing.Color.Black
        Me.Encontrados.Location = New System.Drawing.Point(904, 723)
        Me.Encontrados.MaxLength = 20
        Me.Encontrados.Name = "Encontrados"
        Me.Encontrados.ReadOnly = True
        Me.Encontrados.Size = New System.Drawing.Size(53, 23)
        Me.Encontrados.TabIndex = 2
        Me.Encontrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(794, 726)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 188
        Me.Label6.Text = "ENCONTRADOS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckHistorico)
        Me.GroupBox2.Controls.Add(Me.lbMoneda2)
        Me.GroupBox2.Controls.Add(Me.lbMoneda)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.PVP)
        Me.GroupBox2.Controls.Add(Me.PrecioNeto)
        Me.GroupBox2.Controls.Add(Me.Descuento)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.subTipo)
        Me.GroupBox2.Controls.Add(Me.Tipo)
        Me.GroupBox2.Controls.Add(Me.CodArticuloCli)
        Me.GroupBox2.Controls.Add(Me.ArticuloCli)
        Me.GroupBox2.Controls.Add(Me.bBuscarCliente)
        Me.GroupBox2.Controls.Add(Me.bBuscarArticulo)
        Me.GroupBox2.Controls.Add(Me.bVerCliente)
        Me.GroupBox2.Controls.Add(Me.bverArticulo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbCliente)
        Me.GroupBox2.Controls.Add(Me.cbcodCliente)
        Me.GroupBox2.Controls.Add(Me.cbArticulo)
        Me.GroupBox2.Controls.Add(Me.cbCodArticulo)
        Me.GroupBox2.Controls.Add(Me.dtpFechaBaja)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.lbFechaBaja)
        Me.GroupBox2.Controls.Add(Me.dtpFechaAlta)
        Me.GroupBox2.Controls.Add(Me.ckActivo)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(945, 180)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'ckHistorico
        '
        Me.ckHistorico.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ckHistorico.AutoSize = True
        Me.ckHistorico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckHistorico.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckHistorico.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckHistorico.Location = New System.Drawing.Point(4, 25)
        Me.ckHistorico.Name = "ckHistorico"
        Me.ckHistorico.Size = New System.Drawing.Size(122, 21)
        Me.ckHistorico.TabIndex = 0
        Me.ckHistorico.Text = "VER HISTÓRICO"
        Me.ckHistorico.UseVisualStyleBackColor = True
        '
        'lbMoneda2
        '
        Me.lbMoneda2.AutoSize = True
        Me.lbMoneda2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMoneda2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda2.Location = New System.Drawing.Point(576, 149)
        Me.lbMoneda2.Name = "lbMoneda2"
        Me.lbMoneda2.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda2.TabIndex = 142
        Me.lbMoneda2.Text = "€"
        '
        'lbMoneda
        '
        Me.lbMoneda.AutoSize = True
        Me.lbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMoneda.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda.Location = New System.Drawing.Point(775, 149)
        Me.lbMoneda.Name = "lbMoneda"
        Me.lbMoneda.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda.TabIndex = 142
        Me.lbMoneda.Text = "€"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(899, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 17)
        Me.Label7.TabIndex = 142
        Me.Label7.Text = "%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(464, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "PVP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(603, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 17)
        Me.Label8.TabIndex = 143
        Me.Label8.Text = "PRECIO NETO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(803, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 17)
        Me.Label10.TabIndex = 143
        Me.Label10.Text = "DTO."
        '
        'PVP
        '
        Me.PVP.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.PVP.ForeColor = System.Drawing.Color.Black
        Me.PVP.Location = New System.Drawing.Point(499, 146)
        Me.PVP.MaxLength = 20
        Me.PVP.Name = "PVP"
        Me.PVP.ReadOnly = True
        Me.PVP.Size = New System.Drawing.Size(75, 23)
        Me.PVP.TabIndex = 16
        Me.PVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrecioNeto
        '
        Me.PrecioNeto.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.PrecioNeto.ForeColor = System.Drawing.Color.Black
        Me.PrecioNeto.Location = New System.Drawing.Point(698, 146)
        Me.PrecioNeto.MaxLength = 20
        Me.PrecioNeto.Name = "PrecioNeto"
        Me.PrecioNeto.Size = New System.Drawing.Size(75, 23)
        Me.PrecioNeto.TabIndex = 17
        Me.PrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Descuento
        '
        Me.Descuento.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Descuento.ForeColor = System.Drawing.Color.Black
        Me.Descuento.Location = New System.Drawing.Point(843, 146)
        Me.Descuento.MaxLength = 20
        Me.Descuento.Name = "Descuento"
        Me.Descuento.Size = New System.Drawing.Size(53, 23)
        Me.Descuento.TabIndex = 18
        Me.Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(9, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 17)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "ARTÍCULO/CLI"
        '
        'subTipo
        '
        Me.subTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.subTipo.ForeColor = System.Drawing.Color.Black
        Me.subTipo.Location = New System.Drawing.Point(330, 146)
        Me.subTipo.MaxLength = 15
        Me.subTipo.Name = "subTipo"
        Me.subTipo.ReadOnly = True
        Me.subTipo.Size = New System.Drawing.Size(130, 23)
        Me.subTipo.TabIndex = 15
        '
        'Tipo
        '
        Me.Tipo.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Tipo.ForeColor = System.Drawing.Color.Black
        Me.Tipo.Location = New System.Drawing.Point(111, 146)
        Me.Tipo.MaxLength = 15
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Size = New System.Drawing.Size(155, 23)
        Me.Tipo.TabIndex = 14
        '
        'CodArticuloCli
        '
        Me.CodArticuloCli.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CodArticuloCli.ForeColor = System.Drawing.Color.Black
        Me.CodArticuloCli.Location = New System.Drawing.Point(111, 118)
        Me.CodArticuloCli.MaxLength = 30
        Me.CodArticuloCli.Name = "CodArticuloCli"
        Me.CodArticuloCli.Size = New System.Drawing.Size(155, 23)
        Me.CodArticuloCli.TabIndex = 12
        '
        'ArticuloCli
        '
        Me.ArticuloCli.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ArticuloCli.ForeColor = System.Drawing.Color.Black
        Me.ArticuloCli.Location = New System.Drawing.Point(330, 118)
        Me.ArticuloCli.MaxLength = 300
        Me.ArticuloCli.Name = "ArticuloCli"
        Me.ArticuloCli.Size = New System.Drawing.Size(566, 23)
        Me.ArticuloCli.TabIndex = 13
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarCliente.Location = New System.Drawing.Point(293, 56)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarCliente.TabIndex = 5
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticulo.Location = New System.Drawing.Point(293, 87)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticulo.TabIndex = 9
        Me.bBuscarArticulo.UseVisualStyleBackColor = True
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(910, 56)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 7
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'bverArticulo
        '
        Me.bverArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bverArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bverArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bverArticulo.Location = New System.Drawing.Point(910, 87)
        Me.bverArticulo.Name = "bverArticulo"
        Me.bverArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bverArticulo.TabIndex = 11
        Me.bverArticulo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(266, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 17)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "NOMBRE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(270, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "SUBTIPO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(9, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 17)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "TIPO ARTÍCULO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(9, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "CLIENTE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(9, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "ARTÍCULO"
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(330, 56)
        Me.cbCliente.MaxLength = 200
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(566, 25)
        Me.cbCliente.TabIndex = 6
        '
        'cbcodCliente
        '
        Me.cbcodCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodCliente.FormattingEnabled = True
        Me.cbcodCliente.Location = New System.Drawing.Point(111, 56)
        Me.cbcodCliente.MaxLength = 15
        Me.cbcodCliente.Name = "cbcodCliente"
        Me.cbcodCliente.Size = New System.Drawing.Size(155, 25)
        Me.cbcodCliente.TabIndex = 4
        '
        'cbArticulo
        '
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(330, 87)
        Me.cbArticulo.MaxLength = 200
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(566, 25)
        Me.cbArticulo.TabIndex = 10
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(111, 87)
        Me.cbCodArticulo.MaxLength = 15
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(155, 25)
        Me.cbCodArticulo.TabIndex = 8
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBaja.Location = New System.Drawing.Point(846, 26)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaBaja.TabIndex = 3
        Me.dtpFechaBaja.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(440, 29)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(83, 17)
        Me.Label41.TabIndex = 104
        Me.Label41.Text = "FECHA ALTA"
        '
        'lbFechaBaja
        '
        Me.lbFechaBaja.AutoSize = True
        Me.lbFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaBaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFechaBaja.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFechaBaja.Location = New System.Drawing.Point(745, 29)
        Me.lbFechaBaja.Name = "lbFechaBaja"
        Me.lbFechaBaja.Size = New System.Drawing.Size(85, 17)
        Me.lbFechaBaja.TabIndex = 102
        Me.lbFechaBaja.Text = "FECHA BAJA"
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAlta.Location = New System.Drawing.Point(525, 26)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaAlta.TabIndex = 1
        Me.dtpFechaAlta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(632, 27)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 2
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(862, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(762, 23)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 6
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(662, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 4
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(562, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'GestionArticuloCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 762)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionArticuloCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN ARTÍCULO-CLIENTE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents bverArticulo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaBaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lbFechaBaja As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbcodCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CodArticuloCli As System.Windows.Forms.TextBox
    Friend WithEvents ArticuloCli As System.Windows.Forms.TextBox
    Friend WithEvents lvProductos As System.Windows.Forms.ListView
    Friend WithEvents lvIdProdCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodAArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents Encontrados As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ckHistorico As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents subTipo As System.Windows.Forms.TextBox
    Friend WithEvents Tipo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PrecioNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PVP As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbCambio As System.Windows.Forms.Label
End Class
