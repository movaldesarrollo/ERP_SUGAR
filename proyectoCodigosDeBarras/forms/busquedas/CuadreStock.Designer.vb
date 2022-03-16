<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuadreStock
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbEqDomestico = New System.Windows.Forms.RadioButton()
        Me.rbCelDomestico = New System.Windows.Forms.RadioButton()
        Me.rbCelInsdustriales = New System.Windows.Forms.RadioButton()
        Me.rbEqIndustriales = New System.Windows.Forms.RadioButton()
        Me.dtFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbHora = New System.Windows.Forms.Label()
        Me.cbArticulo = New System.Windows.Forms.ComboBox()
        Me.lbArticulo = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.cbHora = New System.Windows.Forms.ComboBox()
        Me.lvCuadreStock = New System.Windows.Forms.ListView()
        Me.colIdArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFechaFabricacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEquNumSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gbParBusqueda = New System.Windows.Forms.GroupBox()
        Me.cbRangoFecha = New System.Windows.Forms.CheckBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lbFechaHasta = New System.Windows.Forms.Label()
        Me.chbIndustriales = New System.Windows.Forms.CheckBox()
        Me.chbDomesticos = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.prbCargaExcel = New System.Windows.Forms.ProgressBar()
        Me.txTotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.gbParBusqueda.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(15, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DOMESTICOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(15, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "INDUSTRIALES"
        '
        'rbEqDomestico
        '
        Me.rbEqDomestico.AutoSize = True
        Me.rbEqDomestico.Location = New System.Drawing.Point(112, 33)
        Me.rbEqDomestico.Name = "rbEqDomestico"
        Me.rbEqDomestico.Size = New System.Drawing.Size(70, 21)
        Me.rbEqDomestico.TabIndex = 1
        Me.rbEqDomestico.TabStop = True
        Me.rbEqDomestico.Text = "EQUIPO"
        Me.rbEqDomestico.UseVisualStyleBackColor = True
        '
        'rbCelDomestico
        '
        Me.rbCelDomestico.AutoSize = True
        Me.rbCelDomestico.Location = New System.Drawing.Point(188, 33)
        Me.rbCelDomestico.Name = "rbCelDomestico"
        Me.rbCelDomestico.Size = New System.Drawing.Size(70, 21)
        Me.rbCelDomestico.TabIndex = 2
        Me.rbCelDomestico.TabStop = True
        Me.rbCelDomestico.Text = "CÉLULA"
        Me.rbCelDomestico.UseVisualStyleBackColor = True
        '
        'rbCelInsdustriales
        '
        Me.rbCelInsdustriales.AutoSize = True
        Me.rbCelInsdustriales.Location = New System.Drawing.Point(188, 62)
        Me.rbCelInsdustriales.Name = "rbCelInsdustriales"
        Me.rbCelInsdustriales.Size = New System.Drawing.Size(70, 21)
        Me.rbCelInsdustriales.TabIndex = 4
        Me.rbCelInsdustriales.TabStop = True
        Me.rbCelInsdustriales.Text = "CÉLULA"
        Me.rbCelInsdustriales.UseVisualStyleBackColor = True
        '
        'rbEqIndustriales
        '
        Me.rbEqIndustriales.AutoSize = True
        Me.rbEqIndustriales.Location = New System.Drawing.Point(112, 62)
        Me.rbEqIndustriales.Name = "rbEqIndustriales"
        Me.rbEqIndustriales.Size = New System.Drawing.Size(70, 21)
        Me.rbEqIndustriales.TabIndex = 3
        Me.rbEqIndustriales.TabStop = True
        Me.rbEqIndustriales.Text = "EQUIPO"
        Me.rbEqIndustriales.UseVisualStyleBackColor = True
        '
        'dtFechaDesde
        '
        Me.dtFechaDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaDesde.Location = New System.Drawing.Point(640, 32)
        Me.dtFechaDesde.Name = "dtFechaDesde"
        Me.dtFechaDesde.Size = New System.Drawing.Size(197, 22)
        Me.dtFechaDesde.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(552, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "FECHA DESDE"
        '
        'lbHora
        '
        Me.lbHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbHora.AutoSize = True
        Me.lbHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbHora.Location = New System.Drawing.Point(553, 93)
        Me.lbHora.Name = "lbHora"
        Me.lbHora.Size = New System.Drawing.Size(38, 13)
        Me.lbHora.TabIndex = 13
        Me.lbHora.Text = "HORA"
        '
        'cbArticulo
        '
        Me.cbArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(641, 119)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(197, 25)
        Me.cbArticulo.TabIndex = 7
        '
        'lbArticulo
        '
        Me.lbArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbArticulo.AutoSize = True
        Me.lbArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbArticulo.Location = New System.Drawing.Point(553, 124)
        Me.lbArticulo.Name = "lbArticulo"
        Me.lbArticulo.Size = New System.Drawing.Size(61, 13)
        Me.lbArticulo.TabIndex = 15
        Me.lbArticulo.Text = "ARTICULO"
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.Location = New System.Drawing.Point(494, 12)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(150, 71)
        Me.btnExcel.TabIndex = 3
        Me.btnExcel.Text = "EXCEL"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'cbHora
        '
        Me.cbHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbHora.FormattingEnabled = True
        Me.cbHora.Location = New System.Drawing.Point(641, 88)
        Me.cbHora.Name = "cbHora"
        Me.cbHora.Size = New System.Drawing.Size(197, 25)
        Me.cbHora.TabIndex = 6
        '
        'lvCuadreStock
        '
        Me.lvCuadreStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCuadreStock.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdArticulo, Me.colArticulo, Me.colNumSerie, Me.colFechaFabricacion, Me.colEquNumSerie})
        Me.lvCuadreStock.HideSelection = False
        Me.lvCuadreStock.Location = New System.Drawing.Point(12, 250)
        Me.lvCuadreStock.Name = "lvCuadreStock"
        Me.lvCuadreStock.Size = New System.Drawing.Size(942, 452)
        Me.lvCuadreStock.TabIndex = 1
        Me.lvCuadreStock.TabStop = False
        Me.lvCuadreStock.UseCompatibleStateImageBehavior = False
        Me.lvCuadreStock.View = System.Windows.Forms.View.Details
        '
        'colIdArticulo
        '
        Me.colIdArticulo.Text = "IdArticulo"
        Me.colIdArticulo.Width = 0
        '
        'colArticulo
        '
        Me.colArticulo.Text = "ARTICULO"
        Me.colArticulo.Width = 250
        '
        'colNumSerie
        '
        Me.colNumSerie.Text = "N. SERIE PADRE"
        Me.colNumSerie.Width = 155
        '
        'colFechaFabricacion
        '
        Me.colFechaFabricacion.Text = "FECHA FABRICACIÓN"
        Me.colFechaFabricacion.Width = 150
        '
        'colEquNumSerie
        '
        Me.colEquNumSerie.Text = "NUM SERIE"
        Me.colEquNumSerie.Width = 200
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(338, 12)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(150, 71)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'gbParBusqueda
        '
        Me.gbParBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbParBusqueda.Controls.Add(Me.cbRangoFecha)
        Me.gbParBusqueda.Controls.Add(Me.dtpFechaHasta)
        Me.gbParBusqueda.Controls.Add(Me.lbFechaHasta)
        Me.gbParBusqueda.Controls.Add(Me.chbIndustriales)
        Me.gbParBusqueda.Controls.Add(Me.chbDomesticos)
        Me.gbParBusqueda.Controls.Add(Me.Label7)
        Me.gbParBusqueda.Controls.Add(Me.Label1)
        Me.gbParBusqueda.Controls.Add(Me.Label2)
        Me.gbParBusqueda.Controls.Add(Me.rbEqDomestico)
        Me.gbParBusqueda.Controls.Add(Me.cbHora)
        Me.gbParBusqueda.Controls.Add(Me.rbCelDomestico)
        Me.gbParBusqueda.Controls.Add(Me.rbEqIndustriales)
        Me.gbParBusqueda.Controls.Add(Me.lbArticulo)
        Me.gbParBusqueda.Controls.Add(Me.rbCelInsdustriales)
        Me.gbParBusqueda.Controls.Add(Me.cbArticulo)
        Me.gbParBusqueda.Controls.Add(Me.dtFechaDesde)
        Me.gbParBusqueda.Controls.Add(Me.lbHora)
        Me.gbParBusqueda.Controls.Add(Me.Label3)
        Me.gbParBusqueda.Location = New System.Drawing.Point(10, 89)
        Me.gbParBusqueda.Name = "gbParBusqueda"
        Me.gbParBusqueda.Size = New System.Drawing.Size(944, 155)
        Me.gbParBusqueda.TabIndex = 0
        Me.gbParBusqueda.TabStop = False
        Me.gbParBusqueda.Text = "PARAMETROS DE BUSQUEDA"
        '
        'cbRangoFecha
        '
        Me.cbRangoFecha.AutoSize = True
        Me.cbRangoFecha.Location = New System.Drawing.Point(18, 126)
        Me.cbRangoFecha.Name = "cbRangoFecha"
        Me.cbRangoFecha.Size = New System.Drawing.Size(138, 21)
        Me.cbRangoFecha.TabIndex = 21
        Me.cbRangoFecha.Text = "RANGO DE FECHAS"
        Me.cbRangoFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(641, 61)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(197, 22)
        Me.dtpFechaHasta.TabIndex = 19
        '
        'lbFechaHasta
        '
        Me.lbFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFechaHasta.AutoSize = True
        Me.lbFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbFechaHasta.Location = New System.Drawing.Point(553, 66)
        Me.lbFechaHasta.Name = "lbFechaHasta"
        Me.lbFechaHasta.Size = New System.Drawing.Size(81, 13)
        Me.lbFechaHasta.TabIndex = 20
        Me.lbFechaHasta.Text = "FECHA HASTA"
        '
        'chbIndustriales
        '
        Me.chbIndustriales.AutoSize = True
        Me.chbIndustriales.Location = New System.Drawing.Point(222, 93)
        Me.chbIndustriales.Name = "chbIndustriales"
        Me.chbIndustriales.Size = New System.Drawing.Size(106, 21)
        Me.chbIndustriales.TabIndex = 18
        Me.chbIndustriales.Text = "INDUSTRIALES"
        Me.chbIndustriales.UseVisualStyleBackColor = True
        '
        'chbDomesticos
        '
        Me.chbDomesticos.AutoSize = True
        Me.chbDomesticos.Location = New System.Drawing.Point(112, 93)
        Me.chbDomesticos.Name = "chbDomesticos"
        Me.chbDomesticos.Size = New System.Drawing.Size(104, 21)
        Me.chbDomesticos.TabIndex = 17
        Me.chbDomesticos.Text = "DOMESTICOS"
        Me.chbDomesticos.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(15, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "LOGISTICA"
        '
        'prbCargaExcel
        '
        Me.prbCargaExcel.Location = New System.Drawing.Point(12, 708)
        Me.prbCargaExcel.Name = "prbCargaExcel"
        Me.prbCargaExcel.Size = New System.Drawing.Size(409, 23)
        Me.prbCargaExcel.TabIndex = 0
        Me.prbCargaExcel.Visible = False
        '
        'txTotal
        '
        Me.txTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotal.Location = New System.Drawing.Point(878, 708)
        Me.txTotal.Name = "txTotal"
        Me.txTotal.ReadOnly = True
        Me.txTotal.Size = New System.Drawing.Size(78, 22)
        Me.txTotal.TabIndex = 0
        Me.txTotal.TabStop = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(830, 713)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "TOTAL"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 170
        Me.PictureBox1.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Location = New System.Drawing.Point(650, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(150, 71)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(806, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(150, 71)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'CuadreStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 738)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.prbCargaExcel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txTotal)
        Me.Controls.Add(Me.gbParBusqueda)
        Me.Controls.Add(Me.lvCuadreStock)
        Me.Controls.Add(Me.btnExcel)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CuadreStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CUADRE STOCK"
        Me.gbParBusqueda.ResumeLayout(False)
        Me.gbParBusqueda.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rbEqDomestico As RadioButton
    Friend WithEvents rbCelDomestico As RadioButton
    Friend WithEvents rbCelInsdustriales As RadioButton
    Friend WithEvents rbEqIndustriales As RadioButton
    Friend WithEvents dtFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents lbHora As Label
    Friend WithEvents cbArticulo As ComboBox
    Friend WithEvents lbArticulo As Label
    Friend WithEvents btnExcel As Button
    Friend WithEvents cbHora As ComboBox
    Friend WithEvents lvCuadreStock As ListView
    Friend WithEvents colArticulo As ColumnHeader
    Friend WithEvents colNumSerie As ColumnHeader
    Friend WithEvents colFechaFabricacion As ColumnHeader
    Friend WithEvents colEquNumSerie As ColumnHeader
    Friend WithEvents colIdArticulo As ColumnHeader
    Friend WithEvents btnBuscar As Button
    Friend WithEvents gbParBusqueda As GroupBox
    Friend WithEvents txTotal As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents prbCargaExcel As ProgressBar
    Friend WithEvents chbIndustriales As CheckBox
    Friend WithEvents chbDomesticos As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents lbFechaHasta As Label
    Friend WithEvents cbRangoFecha As CheckBox
End Class
