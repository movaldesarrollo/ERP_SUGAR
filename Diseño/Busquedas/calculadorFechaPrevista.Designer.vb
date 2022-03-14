<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class calculadorFechaPrevista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(calculadorFechaPrevista))
        Me.bCalcular = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbDomesticos = New System.Windows.Forms.Label()
        Me.lbIndustriales = New System.Windows.Forms.Label()
        Me.tbDomesticos = New System.Windows.Forms.TextBox()
        Me.tbIndustriales = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.lbTotalDias = New System.Windows.Forms.Label()
        Me.tbDias = New System.Windows.Forms.TextBox()
        Me.tbFecha = New System.Windows.Forms.TextBox()
        Me.ckSabados = New System.Windows.Forms.CheckBox()
        Me.lvPedidosProduccion = New System.Windows.Forms.ListView()
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDomCalculados = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDom2Calculados = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIndCalculados = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDomesticos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDomesticos2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIndustriales = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbTotalIndustriales = New System.Windows.Forms.TextBox()
        Me.tbTotalDomesticos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMaxIndustriales = New System.Windows.Forms.TextBox()
        Me.tbMaxDomesticos = New System.Windows.Forms.TextBox()
        Me.tbDomestico2 = New System.Windows.Forms.TextBox()
        Me.lblDomestico2 = New System.Windows.Forms.Label()
        Me.tbMaxDomesticos2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbTotalDom2 = New System.Windows.Forms.TextBox()
        Me.txMaxRecambios = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbTotalRecambios = New System.Windows.Forms.TextBox()
        Me.colRecambios = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbRecambios = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.colRecambiosCalculados = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bCalcular
        '
        Me.bCalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCalcular.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCalcular.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCalcular.Location = New System.Drawing.Point(970, 12)
        Me.bCalcular.Name = "bCalcular"
        Me.bCalcular.Size = New System.Drawing.Size(88, 50)
        Me.bCalcular.TabIndex = 3
        Me.bCalcular.Text = "CALCULAR"
        Me.bCalcular.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1158, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'lbDomesticos
        '
        Me.lbDomesticos.AutoSize = True
        Me.lbDomesticos.Location = New System.Drawing.Point(9, 82)
        Me.lbDomesticos.Name = "lbDomesticos"
        Me.lbDomesticos.Size = New System.Drawing.Size(139, 17)
        Me.lbDomesticos.TabIndex = 18
        Me.lbDomesticos.Text = "EQUIPOS DOMÉSTICOS"
        '
        'lbIndustriales
        '
        Me.lbIndustriales.AutoSize = True
        Me.lbIndustriales.Location = New System.Drawing.Point(9, 110)
        Me.lbIndustriales.Name = "lbIndustriales"
        Me.lbIndustriales.Size = New System.Drawing.Size(141, 17)
        Me.lbIndustriales.TabIndex = 19
        Me.lbIndustriales.Text = "EQUIPOS INDUSTRIALES"
        '
        'tbDomesticos
        '
        Me.tbDomesticos.Location = New System.Drawing.Point(156, 79)
        Me.tbDomesticos.Name = "tbDomesticos"
        Me.tbDomesticos.Size = New System.Drawing.Size(74, 22)
        Me.tbDomesticos.TabIndex = 0
        '
        'tbIndustriales
        '
        Me.tbIndustriales.Location = New System.Drawing.Point(156, 107)
        Me.tbIndustriales.Name = "tbIndustriales"
        Me.tbIndustriales.Size = New System.Drawing.Size(74, 22)
        Me.tbIndustriales.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(526, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "FECHA PREVISTA"
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1064, 12)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 50)
        Me.bLimpiar.TabIndex = 4
        Me.bLimpiar.Text = "LIMPAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'lbTotalDias
        '
        Me.lbTotalDias.AutoSize = True
        Me.lbTotalDias.Location = New System.Drawing.Point(526, 110)
        Me.lbTotalDias.Name = "lbTotalDias"
        Me.lbTotalDias.Size = New System.Drawing.Size(151, 17)
        Me.lbTotalDias.TabIndex = 25
        Me.lbTotalDias.Text = "TOTAL DÍAS LABORABLES"
        '
        'tbDias
        '
        Me.tbDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDias.Location = New System.Drawing.Point(828, 107)
        Me.tbDias.Name = "tbDias"
        Me.tbDias.Size = New System.Drawing.Size(88, 23)
        Me.tbDias.TabIndex = 26
        Me.tbDias.TabStop = False
        Me.tbDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbFecha
        '
        Me.tbFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFecha.Location = New System.Drawing.Point(701, 79)
        Me.tbFecha.Name = "tbFecha"
        Me.tbFecha.Size = New System.Drawing.Size(215, 23)
        Me.tbFecha.TabIndex = 27
        Me.tbFecha.TabStop = False
        Me.tbFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ckSabados
        '
        Me.ckSabados.AutoSize = True
        Me.ckSabados.Location = New System.Drawing.Point(969, 80)
        Me.ckSabados.Name = "ckSabados"
        Me.ckSabados.Size = New System.Drawing.Size(133, 21)
        Me.ckSabados.TabIndex = 3
        Me.ckSabados.Text = "INCLUIR SÁBADOS"
        Me.ckSabados.UseVisualStyleBackColor = True
        '
        'lvPedidosProduccion
        '
        Me.lvPedidosProduccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPedidosProduccion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFecha, Me.colDomCalculados, Me.colDom2Calculados, Me.colIndCalculados, Me.colDomesticos, Me.colDomesticos2, Me.colIndustriales, Me.colRecambios, Me.colRecambiosCalculados})
        Me.lvPedidosProduccion.FullRowSelect = True
        Me.lvPedidosProduccion.GridLines = True
        Me.lvPedidosProduccion.HideSelection = False
        Me.lvPedidosProduccion.Location = New System.Drawing.Point(12, 136)
        Me.lvPedidosProduccion.Name = "lvPedidosProduccion"
        Me.lvPedidosProduccion.Size = New System.Drawing.Size(1234, 677)
        Me.lvPedidosProduccion.TabIndex = 28
        Me.lvPedidosProduccion.UseCompatibleStateImageBehavior = False
        Me.lvPedidosProduccion.View = System.Windows.Forms.View.Details
        '
        'colFecha
        '
        Me.colFecha.Text = "FECHA PRODUCCIÓN"
        Me.colFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colFecha.Width = 200
        '
        'colDomCalculados
        '
        Me.colDomCalculados.Text = "DOM. CALCULADOS"
        Me.colDomCalculados.Width = 150
        '
        'colDom2Calculados
        '
        Me.colDom2Calculados.Text = "DOM2. CALCULADOS"
        Me.colDom2Calculados.Width = 150
        '
        'colIndCalculados
        '
        Me.colIndCalculados.Text = "IND.CALCULADOS"
        Me.colIndCalculados.Width = 150
        '
        'colDomesticos
        '
        Me.colDomesticos.DisplayIndex = 5
        Me.colDomesticos.Text = "DOMÉSTICOS"
        Me.colDomesticos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colDomesticos.Width = 100
        '
        'colDomesticos2
        '
        Me.colDomesticos2.DisplayIndex = 6
        Me.colDomesticos2.Text = "DOMÉSTICOS 2"
        Me.colDomesticos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colDomesticos2.Width = 100
        '
        'colIndustriales
        '
        Me.colIndustriales.DisplayIndex = 7
        Me.colIndustriales.Text = "INDUSTRIALES"
        Me.colIndustriales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colIndustriales.Width = 100
        '
        'tbTotalIndustriales
        '
        Me.tbTotalIndustriales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTotalIndustriales.BackColor = System.Drawing.Color.White
        Me.tbTotalIndustriales.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalIndustriales.Location = New System.Drawing.Point(1029, 819)
        Me.tbTotalIndustriales.Name = "tbTotalIndustriales"
        Me.tbTotalIndustriales.ReadOnly = True
        Me.tbTotalIndustriales.Size = New System.Drawing.Size(73, 23)
        Me.tbTotalIndustriales.TabIndex = 29
        Me.tbTotalIndustriales.TabStop = False
        Me.tbTotalIndustriales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbTotalDomesticos
        '
        Me.tbTotalDomesticos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTotalDomesticos.BackColor = System.Drawing.Color.White
        Me.tbTotalDomesticos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalDomesticos.Location = New System.Drawing.Point(829, 819)
        Me.tbTotalDomesticos.Name = "tbTotalDomesticos"
        Me.tbTotalDomesticos.ReadOnly = True
        Me.tbTotalDomesticos.Size = New System.Drawing.Size(73, 23)
        Me.tbTotalDomesticos.TabIndex = 31
        Me.tbTotalDomesticos.TabStop = False
        Me.tbTotalDomesticos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(745, 822)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "TOTALES"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 822)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 17)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "MAX. DOMÉSTICOS"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(370, 822)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 17)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "MAX. INDUSTRIALES"
        '
        'tbMaxIndustriales
        '
        Me.tbMaxIndustriales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbMaxIndustriales.BackColor = System.Drawing.Color.White
        Me.tbMaxIndustriales.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaxIndustriales.Location = New System.Drawing.Point(496, 819)
        Me.tbMaxIndustriales.Name = "tbMaxIndustriales"
        Me.tbMaxIndustriales.ReadOnly = True
        Me.tbMaxIndustriales.Size = New System.Drawing.Size(44, 23)
        Me.tbMaxIndustriales.TabIndex = 35
        Me.tbMaxIndustriales.TabStop = False
        Me.tbMaxIndustriales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbMaxDomesticos
        '
        Me.tbMaxDomesticos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbMaxDomesticos.BackColor = System.Drawing.Color.White
        Me.tbMaxDomesticos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaxDomesticos.Location = New System.Drawing.Point(136, 819)
        Me.tbMaxDomesticos.Name = "tbMaxDomesticos"
        Me.tbMaxDomesticos.ReadOnly = True
        Me.tbMaxDomesticos.Size = New System.Drawing.Size(44, 23)
        Me.tbMaxDomesticos.TabIndex = 36
        Me.tbMaxDomesticos.TabStop = False
        Me.tbMaxDomesticos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbDomestico2
        '
        Me.tbDomestico2.Location = New System.Drawing.Point(397, 79)
        Me.tbDomestico2.Name = "tbDomestico2"
        Me.tbDomestico2.Size = New System.Drawing.Size(74, 22)
        Me.tbDomestico2.TabIndex = 1
        '
        'lblDomestico2
        '
        Me.lblDomestico2.AutoSize = True
        Me.lblDomestico2.Location = New System.Drawing.Point(242, 82)
        Me.lblDomestico2.Name = "lblDomestico2"
        Me.lblDomestico2.Size = New System.Drawing.Size(149, 17)
        Me.lblDomestico2.TabIndex = 38
        Me.lblDomestico2.Text = "EQUIPOS DOMÉSTICOS 2"
        '
        'tbMaxDomesticos2
        '
        Me.tbMaxDomesticos2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbMaxDomesticos2.BackColor = System.Drawing.Color.White
        Me.tbMaxDomesticos2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMaxDomesticos2.Location = New System.Drawing.Point(320, 819)
        Me.tbMaxDomesticos2.Name = "tbMaxDomesticos2"
        Me.tbMaxDomesticos2.ReadOnly = True
        Me.tbMaxDomesticos2.Size = New System.Drawing.Size(44, 23)
        Me.tbMaxDomesticos2.TabIndex = 40
        Me.tbMaxDomesticos2.TabStop = False
        Me.tbMaxDomesticos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(186, 822)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 17)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "MAX. DOMÉSTICOS 2"
        '
        'tbTotalDom2
        '
        Me.tbTotalDom2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTotalDom2.BackColor = System.Drawing.Color.White
        Me.tbTotalDom2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalDom2.Location = New System.Drawing.Point(929, 819)
        Me.tbTotalDom2.Name = "tbTotalDom2"
        Me.tbTotalDom2.ReadOnly = True
        Me.tbTotalDom2.Size = New System.Drawing.Size(73, 23)
        Me.tbTotalDom2.TabIndex = 41
        Me.tbTotalDom2.TabStop = False
        Me.tbTotalDom2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txMaxRecambios
        '
        Me.txMaxRecambios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txMaxRecambios.BackColor = System.Drawing.Color.White
        Me.txMaxRecambios.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txMaxRecambios.Location = New System.Drawing.Point(662, 819)
        Me.txMaxRecambios.Name = "txMaxRecambios"
        Me.txMaxRecambios.ReadOnly = True
        Me.txMaxRecambios.Size = New System.Drawing.Size(44, 23)
        Me.txMaxRecambios.TabIndex = 43
        Me.txMaxRecambios.TabStop = False
        Me.txMaxRecambios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(551, 822)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 17)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "MAX. RECAMBIOS"
        '
        'tbTotalRecambios
        '
        Me.tbTotalRecambios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTotalRecambios.BackColor = System.Drawing.Color.White
        Me.tbTotalRecambios.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotalRecambios.Location = New System.Drawing.Point(1129, 819)
        Me.tbTotalRecambios.Name = "tbTotalRecambios"
        Me.tbTotalRecambios.ReadOnly = True
        Me.tbTotalRecambios.Size = New System.Drawing.Size(73, 23)
        Me.tbTotalRecambios.TabIndex = 44
        Me.tbTotalRecambios.TabStop = False
        Me.tbTotalRecambios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'colRecambios
        '
        Me.colRecambios.DisplayIndex = 8
        Me.colRecambios.Text = "RECAMBIOS"
        Me.colRecambios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colRecambios.Width = 100
        '
        'tbRecambios
        '
        Me.tbRecambios.Location = New System.Drawing.Point(397, 107)
        Me.tbRecambios.Name = "tbRecambios"
        Me.tbRecambios.Size = New System.Drawing.Size(74, 22)
        Me.tbRecambios.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(242, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 17)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "EQUIPOS RECAMBIOS"
        '
        'colRecambiosCalculados
        '
        Me.colRecambiosCalculados.DisplayIndex = 4
        Me.colRecambiosCalculados.Text = "RECAM. CALCULADOS"
        Me.colRecambiosCalculados.Width = 150
        '
        'calculadorFechaPrevista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1258, 854)
        Me.Controls.Add(Me.tbRecambios)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbTotalRecambios)
        Me.Controls.Add(Me.txMaxRecambios)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbTotalDom2)
        Me.Controls.Add(Me.tbMaxDomesticos2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbDomestico2)
        Me.Controls.Add(Me.lblDomestico2)
        Me.Controls.Add(Me.tbMaxDomesticos)
        Me.Controls.Add(Me.tbMaxIndustriales)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbTotalDomesticos)
        Me.Controls.Add(Me.tbTotalIndustriales)
        Me.Controls.Add(Me.lvPedidosProduccion)
        Me.Controls.Add(Me.ckSabados)
        Me.Controls.Add(Me.tbFecha)
        Me.Controls.Add(Me.tbDias)
        Me.Controls.Add(Me.lbTotalDias)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbIndustriales)
        Me.Controls.Add(Me.tbDomesticos)
        Me.Controls.Add(Me.lbIndustriales)
        Me.Controls.Add(Me.lbDomesticos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bCalcular)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "calculadorFechaPrevista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CALCULADORA DE FECHA PREVISTA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bCalcular As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbDomesticos As System.Windows.Forms.Label
    Friend WithEvents lbIndustriales As System.Windows.Forms.Label
    Friend WithEvents tbDomesticos As System.Windows.Forms.TextBox
    Friend WithEvents tbIndustriales As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents lbTotalDias As System.Windows.Forms.Label
    Friend WithEvents tbDias As System.Windows.Forms.TextBox
    Friend WithEvents tbFecha As System.Windows.Forms.TextBox
    Friend WithEvents ckSabados As System.Windows.Forms.CheckBox
    Friend WithEvents lvPedidosProduccion As System.Windows.Forms.ListView
    Friend WithEvents tbTotalIndustriales As System.Windows.Forms.TextBox
    Friend WithEvents colFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDomesticos As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIndustriales As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbTotalDomesticos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbMaxIndustriales As System.Windows.Forms.TextBox
    Friend WithEvents tbMaxDomesticos As System.Windows.Forms.TextBox
    Friend WithEvents colDomCalculados As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIndCalculados As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbDomestico2 As TextBox
    Friend WithEvents lblDomestico2 As Label
    Friend WithEvents colDomesticos2 As ColumnHeader
    Friend WithEvents colDom2Calculados As ColumnHeader
    Friend WithEvents tbMaxDomesticos2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbTotalDom2 As TextBox
    Friend WithEvents colRecambios As ColumnHeader
    Friend WithEvents txMaxRecambios As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbTotalRecambios As TextBox
    Friend WithEvents tbRecambios As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents colRecambiosCalculados As ColumnHeader
End Class
