<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busquedaVencimientosProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busquedaVencimientosProv))
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.numFactura = New System.Windows.Forms.TextBox
        Me.ckVerPagados = New System.Windows.Forms.CheckBox
        Me.ckVerRemesados = New System.Windows.Forms.CheckBox
        Me.cbBanco = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbMedioPago = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.lvVencimientos = New System.Windows.Forms.ListView
        Me.lvCK = New System.Windows.Forms.ColumnHeader
        Me.lvidVencimiento = New System.Windows.Forms.ColumnHeader
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvVencimiento = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvTotal = New System.Windows.Forms.ColumnHeader
        Me.lvImporte = New System.Windows.Forms.ColumnHeader
        Me.lvcodMoneda = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lbCambio = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.lbEncontrados = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lbTotal = New System.Windows.Forms.Label
        Me.bListado = New System.Windows.Forms.Button
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.bRemesa = New System.Windows.Forms.Button
        Me.lvidFactura = New System.Windows.Forms.ColumnHeader
        Me.frdatosgenerales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.numFactura)
        Me.frdatosgenerales.Controls.Add(Me.ckVerPagados)
        Me.frdatosgenerales.Controls.Add(Me.ckVerRemesados)
        Me.frdatosgenerales.Controls.Add(Me.cbBanco)
        Me.frdatosgenerales.Controls.Add(Me.Label20)
        Me.frdatosgenerales.Controls.Add(Me.cbMedioPago)
        Me.frdatosgenerales.Controls.Add(Me.Label4)
        Me.frdatosgenerales.Controls.Add(Me.dtpHasta)
        Me.frdatosgenerales.Controls.Add(Me.Label3)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesde)
        Me.frdatosgenerales.Controls.Add(Me.Label13)
        Me.frdatosgenerales.Controls.Add(Me.Label1)
        Me.frdatosgenerales.Controls.Add(Me.Label2)
        Me.frdatosgenerales.Controls.Add(Me.cbEstado)
        Me.frdatosgenerales.Controls.Add(Me.cbProveedor)
        Me.frdatosgenerales.Controls.Add(Me.Label42)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(11, 105)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(795, 122)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARAMETROS DE BÚSQUEDA"
        '
        'numFactura
        '
        Me.numFactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numFactura.Location = New System.Drawing.Point(131, 27)
        Me.numFactura.Name = "numFactura"
        Me.numFactura.Size = New System.Drawing.Size(91, 23)
        Me.numFactura.TabIndex = 0
        '
        'ckVerPagados
        '
        Me.ckVerPagados.AutoSize = True
        Me.ckVerPagados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerPagados.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVerPagados.Location = New System.Drawing.Point(654, 91)
        Me.ckVerPagados.Name = "ckVerPagados"
        Me.ckVerPagados.Size = New System.Drawing.Size(119, 21)
        Me.ckVerPagados.TabIndex = 8
        Me.ckVerPagados.Text = "VER PAGADOS"
        Me.ckVerPagados.UseVisualStyleBackColor = True
        '
        'ckVerRemesados
        '
        Me.ckVerRemesados.AutoSize = True
        Me.ckVerRemesados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerRemesados.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVerRemesados.Location = New System.Drawing.Point(497, 91)
        Me.ckVerRemesados.Name = "ckVerRemesados"
        Me.ckVerRemesados.Size = New System.Drawing.Size(130, 21)
        Me.ckVerRemesados.TabIndex = 7
        Me.ckVerRemesados.Text = "VER REMESADOS"
        Me.ckVerRemesados.UseVisualStyleBackColor = True
        Me.ckVerRemesados.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(547, 56)
        Me.cbBanco.MaxLength = 15
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(238, 25)
        Me.cbBanco.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(490, 60)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 17)
        Me.Label20.TabIndex = 127
        Me.Label20.Text = "BANCO"
        '
        'cbMedioPago
        '
        Me.cbMedioPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMedioPago.FormattingEnabled = True
        Me.cbMedioPago.Location = New System.Drawing.Point(131, 89)
        Me.cbMedioPago.MaxLength = 15
        Me.cbMedioPago.Name = "cbMedioPago"
        Me.cbMedioPago.Size = New System.Drawing.Size(257, 25)
        Me.cbMedioPago.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(14, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 17)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "MEDIO DE PAGO"
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(695, 27)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(90, 23)
        Me.dtpHasta.TabIndex = 3
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(643, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "HASTA"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(547, 27)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(90, 23)
        Me.dtpDesde.TabIndex = 2
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(490, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "DESDE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(230, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 17)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "ESTADO FACTURA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(14, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "PROVEEDOR"
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(348, 26)
        Me.cbEstado.MaxLength = 15
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(138, 25)
        Me.cbEstado.TabIndex = 1
        '
        'cbProveedor
        '
        Me.cbProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(131, 56)
        Me.cbProveedor.MaxLength = 15
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(355, 25)
        Me.cbProveedor.TabIndex = 4
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(14, 30)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(101, 17)
        Me.Label42.TabIndex = 102
        Me.Label42.Text = "NÚM. FACTURA"
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(715, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(614, 23)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 7
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'lvVencimientos
        '
        Me.lvVencimientos.AllowColumnReorder = True
        Me.lvVencimientos.AllowDrop = True
        Me.lvVencimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvVencimientos.AutoArrange = False
        Me.lvVencimientos.BackgroundImageTiled = True
        Me.lvVencimientos.CheckBoxes = True
        Me.lvVencimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCK, Me.lvidVencimiento, Me.lvnum, Me.lvProveedor, Me.lvVencimiento, Me.lvEstado, Me.lvTotal, Me.lvImporte, Me.lvcodMoneda, Me.lvidFactura})
        Me.lvVencimientos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvVencimientos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvVencimientos.FullRowSelect = True
        Me.lvVencimientos.GridLines = True
        Me.lvVencimientos.HideSelection = False
        Me.lvVencimientos.Location = New System.Drawing.Point(11, 239)
        Me.lvVencimientos.Name = "lvVencimientos"
        Me.lvVencimientos.ShowItemToolTips = True
        Me.lvVencimientos.Size = New System.Drawing.Size(795, 490)
        Me.lvVencimientos.TabIndex = 2
        Me.lvVencimientos.UseCompatibleStateImageBehavior = False
        Me.lvVencimientos.View = System.Windows.Forms.View.Details
        '
        'lvCK
        '
        Me.lvCK.DisplayIndex = 1
        Me.lvCK.Text = ""
        Me.lvCK.Width = 22
        '
        'lvidVencimiento
        '
        Me.lvidVencimiento.DisplayIndex = 0
        Me.lvidVencimiento.Text = "idVencimiento"
        Me.lvidVencimiento.Width = 0
        '
        'lvnum
        '
        Me.lvnum.Text = "NÚM.FACTURA"
        Me.lvnum.Width = 98
        '
        'lvProveedor
        '
        Me.lvProveedor.Text = "PROVEEDOR"
        Me.lvProveedor.Width = 290
        '
        'lvVencimiento
        '
        Me.lvVencimiento.Text = "VENCIMIENTO"
        Me.lvVencimiento.Width = 105
        '
        'lvEstado
        '
        Me.lvEstado.Text = "SITUACIÓN"
        Me.lvEstado.Width = 127
        '
        'lvTotal
        '
        Me.lvTotal.Text = "IMPORTE"
        Me.lvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotal.Width = 106
        '
        'lvImporte
        '
        Me.lvImporte.Text = "Importe"
        Me.lvImporte.Width = 0
        '
        'lvcodMoneda
        '
        Me.lvcodMoneda.Text = "codMoneda"
        Me.lvcodMoneda.Width = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(251, 743)
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
        Me.Contador.Location = New System.Drawing.Point(127, 740)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 3
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(657, 740)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(102, 23)
        Me.Total.TabIndex = 4
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbEncontrados
        '
        Me.lbEncontrados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbEncontrados.AutoSize = True
        Me.lbEncontrados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEncontrados.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbEncontrados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbEncontrados.Location = New System.Drawing.Point(12, 743)
        Me.lbEncontrados.Name = "lbEncontrados"
        Me.lbEncontrados.Size = New System.Drawing.Size(106, 17)
        Me.lbEncontrados.TabIndex = 190
        Me.lbEncontrados.Text = "ENCONTRADOS"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(764, 743)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 17)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "€"
        '
        'lbTotal
        '
        Me.lbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbTotal.AutoSize = True
        Me.lbTotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTotal.Location = New System.Drawing.Point(498, 743)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(146, 17)
        Me.lbTotal.TabIndex = 191
        Me.lbTotal.Text = "TOTAL ENCONTRADOS"
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(513, 23)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 6
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(15, 245)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 1
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'bRemesa
        '
        Me.bRemesa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bRemesa.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bRemesa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bRemesa.Location = New System.Drawing.Point(412, 23)
        Me.bRemesa.Name = "bRemesa"
        Me.bRemesa.Size = New System.Drawing.Size(85, 50)
        Me.bRemesa.TabIndex = 5
        Me.bRemesa.Text = "REMESA"
        Me.bRemesa.UseVisualStyleBackColor = True
        Me.bRemesa.Visible = False
        '
        'lvidFactura
        '
        Me.lvidFactura.Text = "idFactura"
        Me.lvidFactura.Width = 0
        '
        'busquedaVencimientosProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 778)
        Me.Controls.Add(Me.ckSeleccion)
        Me.Controls.Add(Me.bRemesa)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.lbCambio)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.lbEncontrados)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbTotal)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvVencimientos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.bLimpiar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "busquedaVencimientosProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VENCIMIENTOS DE FACTURAS DE PROVEEDORES"
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvVencimientos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbCambio As System.Windows.Forms.Label
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents lbEncontrados As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbTotal As System.Windows.Forms.Label
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents cbMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ckVerPagados As System.Windows.Forms.CheckBox
    Friend WithEvents ckVerRemesados As System.Windows.Forms.CheckBox
    Friend WithEvents lvVencimiento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCK As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvidVencimiento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporte As System.Windows.Forms.ColumnHeader
    Friend WithEvents bRemesa As System.Windows.Forms.Button
    Friend WithEvents numFactura As System.Windows.Forms.TextBox
    Friend WithEvents lvidFactura As System.Windows.Forms.ColumnHeader
End Class
