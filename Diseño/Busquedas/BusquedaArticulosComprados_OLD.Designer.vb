<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaArticulosComprados_old
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lvArticulos = New System.Windows.Forms.ListView
        Me.lvColArtID = New System.Windows.Forms.ColumnHeader
        Me.lvColProv = New System.Windows.Forms.ColumnHeader
        Me.lvColCodArt = New System.Windows.Forms.ColumnHeader
        Me.lvColCodArtProv = New System.Windows.Forms.ColumnHeader
        Me.lvColArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvColCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvPedidos = New System.Windows.Forms.ColumnHeader
        Me.lvColNumPedido = New System.Windows.Forms.ColumnHeader
        Me.bBuscar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbCodArticuloPro = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.lbAño = New System.Windows.Forms.Label
        Me.cbAño = New System.Windows.Forms.ComboBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.txCantidadTotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbCargando = New System.Windows.Forms.Label
        Me.lbCargarArticulos = New System.Windows.Forms.Label
        Me.lbCargarCodArti = New System.Windows.Forms.Label
        Me.lbCargarCodArtiProv = New System.Windows.Forms.Label
        Me.lbLimpiando = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 147
        Me.PictureBox1.TabStop = False
        '
        'lvArticulos
        '
        Me.lvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvColArtID, Me.lvColProv, Me.lvColCodArt, Me.lvColCodArtProv, Me.lvColArticuloProv, Me.lvColCantidad, Me.lvPedidos, Me.lvColNumPedido})
        Me.lvArticulos.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.lvArticulos.FullRowSelect = True
        Me.lvArticulos.GridLines = True
        Me.lvArticulos.Location = New System.Drawing.Point(12, 141)
        Me.lvArticulos.MultiSelect = False
        Me.lvArticulos.Name = "lvArticulos"
        Me.lvArticulos.Size = New System.Drawing.Size(1138, 594)
        Me.lvArticulos.TabIndex = 148
        Me.lvArticulos.UseCompatibleStateImageBehavior = False
        Me.lvArticulos.View = System.Windows.Forms.View.Details
        '
        'lvColArtID
        '
        Me.lvColArtID.Text = "ID DE ARTÍCULO"
        Me.lvColArtID.Width = 0
        '
        'lvColProv
        '
        Me.lvColProv.Text = "PROVEEDOR"
        Me.lvColProv.Width = 163
        '
        'lvColCodArt
        '
        Me.lvColCodArt.Text = "CÓDIGO DE ARTÍCULO"
        Me.lvColCodArt.Width = 170
        '
        'lvColCodArtProv
        '
        Me.lvColCodArtProv.Text = "COD. ART. PROVEEDOR"
        Me.lvColCodArtProv.Width = 181
        '
        'lvColArticuloProv
        '
        Me.lvColArticuloProv.Text = "ARTÍCULO DE PROVEEDOR"
        Me.lvColArticuloProv.Width = 389
        '
        'lvColCantidad
        '
        Me.lvColCantidad.Text = "CANTIDAD"
        Me.lvColCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColCantidad.Width = 88
        '
        'lvPedidos
        '
        Me.lvPedidos.Text = "FECHA"
        Me.lvPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPedidos.Width = 114
        '
        'lvColNumPedido
        '
        Me.lvColNumPedido.Text = "NÚMERO PEDIDO"
        Me.lvColNumPedido.Width = 0
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(883, 12)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(85, 50)
        Me.bBuscar.TabIndex = 152
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1065, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 151
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(1090, 741)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 153
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(980, 744)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "ENCONTRADOS"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(222, 17)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 17)
        Me.Label22.TabIndex = 157
        Me.Label22.Text = "PROVEEDOR"
        '
        'cbProveedor
        '
        Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProveedor.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(388, 13)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(480, 26)
        Me.cbProveedor.TabIndex = 156
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(222, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "ARTÍCULO"
        '
        'cbArticulo
        '
        Me.cbArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(388, 45)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(323, 26)
        Me.cbArticulo.TabIndex = 159
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(222, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(153, 17)
        Me.Label3.TabIndex = 166
        Me.Label3.Text = "COD. ARTÍCULO PROV."
        '
        'cbCodArticuloPro
        '
        Me.cbCodArticuloPro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbCodArticuloPro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCodArticuloPro.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbCodArticuloPro.FormattingEnabled = True
        Me.cbCodArticuloPro.Location = New System.Drawing.Point(388, 109)
        Me.cbCodArticuloPro.Name = "cbCodArticuloPro"
        Me.cbCodArticuloPro.Size = New System.Drawing.Size(323, 26)
        Me.cbCodArticuloPro.TabIndex = 165
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(222, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "COD ARTÍCULO"
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbCodArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(388, 77)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(323, 26)
        Me.cbCodArticulo.TabIndex = 162
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(717, 82)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 17)
        Me.Label30.TabIndex = 169
        Me.Label30.Text = "DESDE"
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(771, 111)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(97, 23)
        Me.dtpHasta.TabIndex = 168
        Me.dtpHasta.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(717, 114)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(46, 17)
        Me.Label31.TabIndex = 170
        Me.Label31.Text = "HASTA"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(771, 79)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(97, 23)
        Me.dtpDesde.TabIndex = 167
        Me.dtpDesde.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'lbAño
        '
        Me.lbAño.AutoSize = True
        Me.lbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbAño.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbAño.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbAño.Location = New System.Drawing.Point(717, 51)
        Me.lbAño.Name = "lbAño"
        Me.lbAño.Size = New System.Drawing.Size(38, 17)
        Me.lbAño.TabIndex = 171
        Me.lbAño.Text = "AÑO"
        '
        'cbAño
        '
        Me.cbAño.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbAño.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(771, 45)
        Me.cbAño.Name = "cbAño"
        Me.cbAño.Size = New System.Drawing.Size(97, 26)
        Me.cbAño.Sorted = True
        Me.cbAño.TabIndex = 172
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(974, 12)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 173
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'txCantidadTotal
        '
        Me.txCantidadTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txCantidadTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txCantidadTotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCantidadTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCantidadTotal.Location = New System.Drawing.Point(821, 741)
        Me.txCantidadTotal.MaxLength = 15
        Me.txCantidadTotal.Name = "txCantidadTotal"
        Me.txCantidadTotal.ReadOnly = True
        Me.txCantidadTotal.Size = New System.Drawing.Size(153, 23)
        Me.txCantidadTotal.TabIndex = 174
        Me.txCantidadTotal.TabStop = False
        Me.txCantidadTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(700, 744)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 17)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "CANTIDAD TOTAL"
        '
        'lbCargando
        '
        Me.lbCargando.AutoSize = True
        Me.lbCargando.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbCargando.ForeColor = System.Drawing.Color.Red
        Me.lbCargando.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCargando.Location = New System.Drawing.Point(385, 17)
        Me.lbCargando.Name = "lbCargando"
        Me.lbCargando.Size = New System.Drawing.Size(91, 17)
        Me.lbCargando.TabIndex = 176
        Me.lbCargando.Text = "CARGANDO "
        Me.lbCargando.Visible = False
        '
        'lbCargarArticulos
        '
        Me.lbCargarArticulos.AutoSize = True
        Me.lbCargarArticulos.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbCargarArticulos.ForeColor = System.Drawing.Color.Red
        Me.lbCargarArticulos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCargarArticulos.Location = New System.Drawing.Point(385, 48)
        Me.lbCargarArticulos.Name = "lbCargarArticulos"
        Me.lbCargarArticulos.Size = New System.Drawing.Size(91, 17)
        Me.lbCargarArticulos.TabIndex = 177
        Me.lbCargarArticulos.Text = "CARGANDO "
        Me.lbCargarArticulos.Visible = False
        '
        'lbCargarCodArti
        '
        Me.lbCargarCodArti.AutoSize = True
        Me.lbCargarCodArti.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbCargarCodArti.ForeColor = System.Drawing.Color.Red
        Me.lbCargarCodArti.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCargarCodArti.Location = New System.Drawing.Point(385, 79)
        Me.lbCargarCodArti.Name = "lbCargarCodArti"
        Me.lbCargarCodArti.Size = New System.Drawing.Size(91, 17)
        Me.lbCargarCodArti.TabIndex = 178
        Me.lbCargarCodArti.Text = "CARGANDO "
        Me.lbCargarCodArti.Visible = False
        '
        'lbCargarCodArtiProv
        '
        Me.lbCargarCodArtiProv.AutoSize = True
        Me.lbCargarCodArtiProv.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbCargarCodArtiProv.ForeColor = System.Drawing.Color.Red
        Me.lbCargarCodArtiProv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCargarCodArtiProv.Location = New System.Drawing.Point(385, 111)
        Me.lbCargarCodArtiProv.Name = "lbCargarCodArtiProv"
        Me.lbCargarCodArtiProv.Size = New System.Drawing.Size(91, 17)
        Me.lbCargarCodArtiProv.TabIndex = 179
        Me.lbCargarCodArtiProv.Text = "CARGANDO "
        Me.lbCargarCodArtiProv.Visible = False
        '
        'lbLimpiando
        '
        Me.lbLimpiando.AutoSize = True
        Me.lbLimpiando.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbLimpiando.ForeColor = System.Drawing.Color.Red
        Me.lbLimpiando.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbLimpiando.Location = New System.Drawing.Point(12, 114)
        Me.lbLimpiando.Name = "lbLimpiando"
        Me.lbLimpiando.Size = New System.Drawing.Size(139, 17)
        Me.lbLimpiando.TabIndex = 180
        Me.lbLimpiando.Text = "LIMPIANDO FORM ... "
        Me.lbLimpiando.Visible = False
        '
        'BusquedaArticulosComprados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 773)
        Me.Controls.Add(Me.lbLimpiando)
        Me.Controls.Add(Me.lbCargarCodArtiProv)
        Me.Controls.Add(Me.lbCargarCodArti)
        Me.Controls.Add(Me.lbCargarArticulos)
        Me.Controls.Add(Me.txCantidadTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.cbAño)
        Me.Controls.Add(Me.lbAño)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbCodArticuloPro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbCodArticulo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbArticulo)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvArticulos)
        Me.Controls.Add(Me.lbCargando)
        Me.Controls.Add(Me.cbProveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "BusquedaArticulosComprados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ARTÍCULOS COMPRADOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvArticulos As System.Windows.Forms.ListView
    Friend WithEvents lvColCodArt As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColArtID As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCodArtProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCodArticuloPro As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbAño As System.Windows.Forms.Label
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents lvPedidos As System.Windows.Forms.ColumnHeader
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents txCantidadTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvColNumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbCargando As System.Windows.Forms.Label
    Friend WithEvents lbCargarArticulos As System.Windows.Forms.Label
    Friend WithEvents lbCargarCodArti As System.Windows.Forms.Label
    Friend WithEvents lbCargarCodArtiProv As System.Windows.Forms.Label
    Friend WithEvents lbLimpiando As System.Windows.Forms.Label
End Class
