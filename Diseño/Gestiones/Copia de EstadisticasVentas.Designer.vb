<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadisticasVentas1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstadisticasVentas1))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("SUBTIPOS", System.Windows.Forms.HorizontalAlignment.Left)
        Me.bListado = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lvDocumentos = New System.Windows.Forms.ListView
        Me.bSalir = New System.Windows.Forms.Button
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.ckSubTipos = New System.Windows.Forms.CheckBox
        Me.ckInformeComerciales = New System.Windows.Forms.CheckBox
        Me.ckInformeTipos = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbMes = New System.Windows.Forms.ComboBox
        Me.cbTrimestre = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbAño = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbComercial = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.cbProvincia = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbAutonomia = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbPais = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.bVerArticulo = New System.Windows.Forms.Button
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.lbCambio = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.ayudaBusqueda = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frdatosgenerales.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(1045, 36)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 6
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'lvDocumentos
        '
        Me.lvDocumentos.AllowColumnReorder = True
        Me.lvDocumentos.AllowDrop = True
        Me.lvDocumentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDocumentos.AutoArrange = False
        Me.lvDocumentos.BackgroundImageTiled = True
        Me.lvDocumentos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDocumentos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDocumentos.FullRowSelect = True
        Me.lvDocumentos.GridLines = True
        ListViewGroup1.Header = "SUBTIPOS"
        ListViewGroup1.Name = "SUBTIPOS"
        Me.lvDocumentos.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1})
        Me.lvDocumentos.HideSelection = False
        Me.lvDocumentos.Location = New System.Drawing.Point(11, 334)
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.ShowItemToolTips = True
        Me.lvDocumentos.Size = New System.Drawing.Size(1323, 419)
        Me.lvDocumentos.TabIndex = 1
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(1249, 36)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.ckSubTipos)
        Me.frdatosgenerales.Controls.Add(Me.ckInformeComerciales)
        Me.frdatosgenerales.Controls.Add(Me.ckInformeTipos)
        Me.frdatosgenerales.Controls.Add(Me.GroupBox1)
        Me.frdatosgenerales.Controls.Add(Me.GroupBox2)
        Me.frdatosgenerales.Controls.Add(Me.GroupBox3)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.frdatosgenerales.Location = New System.Drawing.Point(11, 105)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(1323, 223)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARAMETROS DE BÚSQUEDA"
        '
        'ckSubTipos
        '
        Me.ckSubTipos.AutoSize = True
        Me.ckSubTipos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSubTipos.Location = New System.Drawing.Point(988, 189)
        Me.ckSubTipos.Name = "ckSubTipos"
        Me.ckSubTipos.Size = New System.Drawing.Size(164, 20)
        Me.ckSubTipos.TabIndex = 137
        Me.ckSubTipos.Text = "INFORME POR SUBTIPOS"
        Me.ckSubTipos.UseVisualStyleBackColor = True
        '
        'ckInformeComerciales
        '
        Me.ckInformeComerciales.AutoSize = True
        Me.ckInformeComerciales.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckInformeComerciales.Location = New System.Drawing.Point(394, 189)
        Me.ckInformeComerciales.Name = "ckInformeComerciales"
        Me.ckInformeComerciales.Size = New System.Drawing.Size(192, 20)
        Me.ckInformeComerciales.TabIndex = 136
        Me.ckInformeComerciales.Text = "INFORME POR COMERCIALES"
        Me.ckInformeComerciales.UseVisualStyleBackColor = True
        '
        'ckInformeTipos
        '
        Me.ckInformeTipos.AutoSize = True
        Me.ckInformeTipos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckInformeTipos.Location = New System.Drawing.Point(839, 189)
        Me.ckInformeTipos.Name = "ckInformeTipos"
        Me.ckInformeTipos.Size = New System.Drawing.Size(143, 20)
        Me.ckInformeTipos.TabIndex = 135
        Me.ckInformeTipos.Text = "INFORME POR TIPOS"
        Me.ckInformeTipos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbMes)
        Me.GroupBox1.Controls.Add(Me.cbTrimestre)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbAño)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbComercial)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.dtpDesde)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpHasta)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(389, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 160)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FACTURACION"
        '
        'cbMes
        '
        Me.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(332, 89)
        Me.cbMes.MaxLength = 15
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(104, 25)
        Me.cbMes.TabIndex = 6
        '
        'cbTrimestre
        '
        Me.cbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTrimestre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTrimestre.FormattingEnabled = True
        Me.cbTrimestre.Location = New System.Drawing.Point(332, 56)
        Me.cbTrimestre.MaxLength = 15
        Me.cbTrimestre.Name = "cbTrimestre"
        Me.cbTrimestre.Size = New System.Drawing.Size(104, 25)
        Me.cbTrimestre.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(286, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 17)
        Me.Label8.TabIndex = 123
        Me.Label8.Text = "MES"
        '
        'cbAño
        '
        Me.cbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(332, 25)
        Me.cbAño.MaxLength = 15
        Me.cbAño.Name = "cbAño"
        Me.cbAño.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbAño.Size = New System.Drawing.Size(104, 25)
        Me.cbAño.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(280, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 17)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "AÑO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(250, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 17)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "TRIMESTRE"
        '
        'cbComercial
        '
        Me.cbComercial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbComercial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbComercial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbComercial.FormattingEnabled = True
        Me.cbComercial.Location = New System.Drawing.Point(91, 56)
        Me.cbComercial.MaxLength = 20
        Me.cbComercial.Name = "cbComercial"
        Me.cbComercial.Size = New System.Drawing.Size(151, 25)
        Me.cbComercial.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(2, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 17)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "COMERCIAL"
        '
        'cbEstado
        '
        Me.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(91, 25)
        Me.cbEstado.MaxLength = 20
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(151, 25)
        Me.cbEstado.TabIndex = 0
        Me.cbEstado.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(31, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "ESTADO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(39, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "DESDE"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(93, 87)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(149, 23)
        Me.dtpDesde.TabIndex = 2
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(41, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "HASTA"
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(91, 116)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(151, 23)
        Me.dtpHasta.TabIndex = 3
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bVerCliente)
        Me.GroupBox2.Controls.Add(Me.cbProvincia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbAutonomia)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cbCliente)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbPais)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 23)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(375, 160)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CLIENTE"
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = CType(resources.GetObject("bVerCliente.Image"), System.Drawing.Image)
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(336, 27)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 4
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'cbProvincia
        '
        Me.cbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProvincia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProvincia.FormattingEnabled = True
        Me.cbProvincia.Location = New System.Drawing.Point(110, 120)
        Me.cbProvincia.Name = "cbProvincia"
        Me.cbProvincia.Size = New System.Drawing.Size(220, 25)
        Me.cbProvincia.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(20, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 180
        Me.Label5.Text = "PROVINCIA"
        '
        'cbAutonomia
        '
        Me.cbAutonomia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbAutonomia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAutonomia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAutonomia.FormattingEnabled = True
        Me.cbAutonomia.Location = New System.Drawing.Point(110, 89)
        Me.cbAutonomia.Name = "cbAutonomia"
        Me.cbAutonomia.Size = New System.Drawing.Size(220, 25)
        Me.cbAutonomia.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(3, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 17)
        Me.Label9.TabIndex = 179
        Me.Label9.Text = "C.AUTÓNOMA"
        '
        'cbCliente
        '
        Me.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(110, 27)
        Me.cbCliente.MaxLength = 100
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(220, 25)
        Me.cbCliente.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(43, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "CLIENTE"
        '
        'cbPais
        '
        Me.cbPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbPais.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPais.FormattingEnabled = True
        Me.cbPais.Location = New System.Drawing.Point(110, 58)
        Me.cbPais.Name = "cbPais"
        Me.cbPais.Size = New System.Drawing.Size(220, 25)
        Me.cbPais.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(66, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "PAIS"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.bVerArticulo)
        Me.GroupBox3.Controls.Add(Me.cbSubTipo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.lbTipo)
        Me.GroupBox3.Controls.Add(Me.lbSubTipo)
        Me.GroupBox3.Controls.Add(Me.cbArticulo)
        Me.GroupBox3.Controls.Add(Me.cbCodArticulo)
        Me.GroupBox3.Controls.Add(Me.cbTipo)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(839, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(478, 158)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ARTÍCULO"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(12, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 134
        Me.Label17.Text = "DESCRIPCIÓN"
        '
        'bVerArticulo
        '
        Me.bVerArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticulo.Image = CType(resources.GetObject("bVerArticulo.Image"), System.Drawing.Image)
        Me.bVerArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticulo.Location = New System.Drawing.Point(442, 116)
        Me.bVerArticulo.Name = "bVerArticulo"
        Me.bVerArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticulo.TabIndex = 4
        Me.bVerArticulo.UseVisualStyleBackColor = True
        '
        'cbSubTipo
        '
        Me.cbSubTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbSubTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(114, 55)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(322, 25)
        Me.cbSubTipo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(39, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "ARTÍCULO"
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(73, 28)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(35, 17)
        Me.lbTipo.TabIndex = 133
        Me.lbTipo.Text = "TIPO"
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(52, 58)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(56, 17)
        Me.lbSubTipo.TabIndex = 132
        Me.lbSubTipo.Text = "SUBTIPO"
        '
        'cbArticulo
        '
        Me.cbArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(114, 117)
        Me.cbArticulo.MaxLength = 30
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(322, 25)
        Me.cbArticulo.TabIndex = 3
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbCodArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(114, 86)
        Me.cbCodArticulo.MaxLength = 20
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(322, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 2
        '
        'cbTipo
        '
        Me.cbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(114, 24)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(322, 25)
        Me.cbTipo.TabIndex = 0
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(1147, 36)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 7
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(191, 766)
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
        Me.Contador.Location = New System.Drawing.Point(122, 763)
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
        Me.Total.Location = New System.Drawing.Point(1224, 763)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 23)
        Me.Total.TabIndex = 4
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(12, 766)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 17)
        Me.Label11.TabIndex = 190
        Me.Label11.Text = "ENCONTRADOS"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(1320, 766)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 17)
        Me.Label12.TabIndex = 189
        Me.Label12.Text = "€"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(1178, 766)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 17)
        Me.Label14.TabIndex = 191
        Me.Label14.Text = "TOTAL"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(1004, 766)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 17)
        Me.Label15.TabIndex = 191
        Me.Label15.Text = "CANTIDAD"
        '
        'Cantidad
        '
        Me.Cantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Location = New System.Drawing.Point(1081, 763)
        Me.Cantidad.MaxLength = 15
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Size = New System.Drawing.Size(85, 23)
        Me.Cantidad.TabIndex = 3
        Me.Cantidad.TabStop = False
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(941, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 50)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "INFORME 2014-16"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ayudaBusqueda
        '
        Me.ayudaBusqueda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ayudaBusqueda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ayudaBusqueda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ayudaBusqueda.Location = New System.Drawing.Point(837, 36)
        Me.ayudaBusqueda.Name = "ayudaBusqueda"
        Me.ayudaBusqueda.Size = New System.Drawing.Size(85, 50)
        Me.ayudaBusqueda.TabIndex = 193
        Me.ayudaBusqueda.Text = "AYUDA BUSQUEDA"
        Me.ayudaBusqueda.UseVisualStyleBackColor = True
        '
        'EstadisticasVentas1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1341, 795)
        Me.Controls.Add(Me.ayudaBusqueda)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbCambio)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Cantidad)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.bLimpiar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EstadisticasVentas1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESTADÍSTICAS DE VENTAS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbAutonomia As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbPais As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents bVerArticulo As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cbTrimestre As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbCambio As System.Windows.Forms.Label
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Private WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents cbComercial As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ckInformeTipos As System.Windows.Forms.CheckBox
    Friend WithEvents ckInformeComerciales As System.Windows.Forms.CheckBox
    Friend WithEvents ayudaBusqueda As System.Windows.Forms.Button
    Friend WithEvents ckSubTipos As System.Windows.Forms.CheckBox
End Class
