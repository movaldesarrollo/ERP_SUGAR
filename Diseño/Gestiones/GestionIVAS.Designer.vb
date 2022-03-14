<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionIVAs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionIVAs))
        Me.bListado = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.cbTrimestre = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbMes = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbAño = New System.Windows.Forms.ComboBox
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.tpSoportado = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lvTotalesSoportado = New System.Windows.Forms.ListView
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lvIVAsSoportado = New System.Windows.Forms.ListView
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.lbCambioSoportado = New System.Windows.Forms.Label
        Me.ContadorSoportado = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lvSoportado = New System.Windows.Forms.ListView
        Me.lvidFactura = New System.Windows.Forms.ColumnHeader
        Me.lvFechaFP = New System.Windows.Forms.ColumnHeader
        Me.lvnumFacturaProv = New System.Windows.Forms.ColumnHeader
        Me.lvProveedor = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoFP = New System.Windows.Forms.ColumnHeader
        Me.lvBaseFP = New System.Windows.Forms.ColumnHeader
        Me.lvCuotaIVAFP = New System.Windows.Forms.ColumnHeader
        Me.lvCuotaREFP = New System.Windows.Forms.ColumnHeader
        Me.lvRetencionFP = New System.Windows.Forms.ColumnHeader
        Me.lvTotalFP = New System.Windows.Forms.ColumnHeader
        Me.tpLiquidacion = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Diferencia = New System.Windows.Forms.TextBox
        Me.TotalCuotaRepercutido = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TotalCuotaSoportado = New System.Windows.Forms.TextBox
        Me.tvLiquidacion = New System.Windows.Forms.TreeView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpRepercutido = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lvIVAsRepercutido = New System.Windows.Forms.ListView
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.lvBaseR = New System.Windows.Forms.ColumnHeader
        Me.lvIVARER = New System.Windows.Forms.ColumnHeader
        Me.lvTipoR = New System.Windows.Forms.ColumnHeader
        Me.lvCuotaR = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lvTotalesRepercutido = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.lbCambioRepercutido = New System.Windows.Forms.Label
        Me.ContadorRepercutido = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lvRepercutido = New System.Windows.Forms.ListView
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvBase = New System.Windows.Forms.ColumnHeader
        Me.lvCuota = New System.Windows.Forms.ColumnHeader
        Me.lvCuotaRE = New System.Windows.Forms.ColumnHeader
        Me.lvRetencionFC = New System.Windows.Forms.ColumnHeader
        Me.lvTotal = New System.Windows.Forms.ColumnHeader
        Me.pbCarga = New System.Windows.Forms.ProgressBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frdatosgenerales.SuspendLayout()
        Me.tpSoportado.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tpLiquidacion.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpRepercutido.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(770, 22)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 2
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
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
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(988, 22)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(879, 22)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 3
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'cbTrimestre
        '
        Me.cbTrimestre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTrimestre.FormattingEnabled = True
        Me.cbTrimestre.Location = New System.Drawing.Point(317, 33)
        Me.cbTrimestre.MaxLength = 15
        Me.cbTrimestre.Name = "cbTrimestre"
        Me.cbTrimestre.Size = New System.Drawing.Size(115, 25)
        Me.cbTrimestre.TabIndex = 1
        Me.cbTrimestre.Text = "TRIMESTRE 1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(243, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 17)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "TRIMESTRE"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(480, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 17)
        Me.Label8.TabIndex = 207
        Me.Label8.Text = "MES"
        '
        'cbMes
        '
        Me.cbMes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(518, 33)
        Me.cbMes.MaxLength = 15
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(115, 25)
        Me.cbMes.TabIndex = 2
        Me.cbMes.Text = "NOVIEMBRE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(42, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 17)
        Me.Label4.TabIndex = 205
        Me.Label4.Text = "AÑO"
        '
        'cbAño
        '
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(104, 33)
        Me.cbAño.MaxLength = 15
        Me.cbAño.Name = "cbAño"
        Me.cbAño.Size = New System.Drawing.Size(98, 25)
        Me.cbAño.TabIndex = 0
        Me.cbAño.Text = "2012"
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.cbAño)
        Me.frdatosgenerales.Controls.Add(Me.Label4)
        Me.frdatosgenerales.Controls.Add(Me.cbMes)
        Me.frdatosgenerales.Controls.Add(Me.Label8)
        Me.frdatosgenerales.Controls.Add(Me.Label9)
        Me.frdatosgenerales.Controls.Add(Me.cbTrimestre)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(10, 89)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(1063, 72)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARAMETROS DE BÚSQUEDA"
        '
        'tpSoportado
        '
        Me.tpSoportado.Controls.Add(Me.GroupBox5)
        Me.tpSoportado.Controls.Add(Me.GroupBox4)
        Me.tpSoportado.Controls.Add(Me.lbCambioSoportado)
        Me.tpSoportado.Controls.Add(Me.ContadorSoportado)
        Me.tpSoportado.Controls.Add(Me.Label6)
        Me.tpSoportado.Controls.Add(Me.lvSoportado)
        Me.tpSoportado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpSoportado.Location = New System.Drawing.Point(4, 26)
        Me.tpSoportado.Name = "tpSoportado"
        Me.tpSoportado.Size = New System.Drawing.Size(1055, 537)
        Me.tpSoportado.TabIndex = 2
        Me.tpSoportado.Text = "SOPORTADO"
        Me.tpSoportado.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.lvTotalesSoportado)
        Me.GroupBox5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(528, 365)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(519, 60)
        Me.GroupBox5.TabIndex = 212
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "TOTALES"
        '
        'lvTotalesSoportado
        '
        Me.lvTotalesSoportado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTotalesSoportado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.lvTotalesSoportado.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lvTotalesSoportado.FullRowSelect = True
        Me.lvTotalesSoportado.GridLines = True
        Me.lvTotalesSoportado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvTotalesSoportado.Location = New System.Drawing.Point(15, 19)
        Me.lvTotalesSoportado.MultiSelect = False
        Me.lvTotalesSoportado.Name = "lvTotalesSoportado"
        Me.lvTotalesSoportado.Size = New System.Drawing.Size(486, 27)
        Me.lvTotalesSoportado.TabIndex = 206
        Me.lvTotalesSoportado.UseCompatibleStateImageBehavior = False
        Me.lvTotalesSoportado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = ""
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = ""
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = ""
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 95
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = ""
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader10.Width = 90
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = ""
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader17.Width = 90
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "TOTALES"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader18.Width = 105
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.lvIVAsSoportado)
        Me.GroupBox4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(10, 365)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(485, 160)
        Me.GroupBox4.TabIndex = 211
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DESGLOSE IVA/RE"
        '
        'lvIVAsSoportado
        '
        Me.lvIVAsSoportado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16})
        Me.lvIVAsSoportado.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lvIVAsSoportado.FullRowSelect = True
        Me.lvIVAsSoportado.GridLines = True
        Me.lvIVAsSoportado.Location = New System.Drawing.Point(22, 18)
        Me.lvIVAsSoportado.MultiSelect = False
        Me.lvIVAsSoportado.Name = "lvIVAsSoportado"
        Me.lvIVAsSoportado.Size = New System.Drawing.Size(439, 135)
        Me.lvIVAsSoportado.TabIndex = 202
        Me.lvIVAsSoportado.UseCompatibleStateImageBehavior = False
        Me.lvIVAsSoportado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "BASE"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 121
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "IVA/RE"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader14.Width = 68
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "TIPO"
        Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader15.Width = 86
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "CUOTA"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 126
        '
        'lbCambioSoportado
        '
        Me.lbCambioSoportado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioSoportado.AutoSize = True
        Me.lbCambioSoportado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioSoportado.ForeColor = System.Drawing.Color.Red
        Me.lbCambioSoportado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioSoportado.Location = New System.Drawing.Point(544, 489)
        Me.lbCambioSoportado.Name = "lbCambioSoportado"
        Me.lbCambioSoportado.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioSoportado.TabIndex = 207
        Me.lbCambioSoportado.Text = "CAMBIO"
        Me.lbCambioSoportado.Visible = False
        '
        'ContadorSoportado
        '
        Me.ContadorSoportado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorSoportado.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorSoportado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorSoportado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorSoportado.Location = New System.Drawing.Point(967, 484)
        Me.ContadorSoportado.MaxLength = 15
        Me.ContadorSoportado.Name = "ContadorSoportado"
        Me.ContadorSoportado.ReadOnly = True
        Me.ContadorSoportado.Size = New System.Drawing.Size(60, 23)
        Me.ContadorSoportado.TabIndex = 202
        Me.ContadorSoportado.TabStop = False
        Me.ContadorSoportado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(894, 487)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 17)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "FACTURAS"
        '
        'lvSoportado
        '
        Me.lvSoportado.AllowColumnReorder = True
        Me.lvSoportado.AllowDrop = True
        Me.lvSoportado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSoportado.AutoArrange = False
        Me.lvSoportado.BackgroundImageTiled = True
        Me.lvSoportado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidFactura, Me.lvFechaFP, Me.lvnumFacturaProv, Me.lvProveedor, Me.lvEstadoFP, Me.lvBaseFP, Me.lvCuotaIVAFP, Me.lvCuotaREFP, Me.lvRetencionFP, Me.lvTotalFP})
        Me.lvSoportado.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvSoportado.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSoportado.FullRowSelect = True
        Me.lvSoportado.GridLines = True
        Me.lvSoportado.HideSelection = False
        Me.lvSoportado.Location = New System.Drawing.Point(10, 23)
        Me.lvSoportado.Name = "lvSoportado"
        Me.lvSoportado.ShowItemToolTips = True
        Me.lvSoportado.Size = New System.Drawing.Size(1035, 333)
        Me.lvSoportado.TabIndex = 20
        Me.lvSoportado.UseCompatibleStateImageBehavior = False
        Me.lvSoportado.View = System.Windows.Forms.View.Details
        '
        'lvidFactura
        '
        Me.lvidFactura.Text = "idFactura"
        Me.lvidFactura.Width = 0
        '
        'lvFechaFP
        '
        Me.lvFechaFP.Text = "FECHA"
        Me.lvFechaFP.Width = 79
        '
        'lvnumFacturaProv
        '
        Me.lvnumFacturaProv.Text = "FACTURA"
        Me.lvnumFacturaProv.Width = 107
        '
        'lvProveedor
        '
        Me.lvProveedor.Text = "PROVEEDOR"
        Me.lvProveedor.Width = 262
        '
        'lvEstadoFP
        '
        Me.lvEstadoFP.Text = "ESTADO"
        Me.lvEstadoFP.Width = 85
        '
        'lvBaseFP
        '
        Me.lvBaseFP.Text = "BASE"
        Me.lvBaseFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvBaseFP.Width = 100
        '
        'lvCuotaIVAFP
        '
        Me.lvCuotaIVAFP.Text = "CUOTA IVA"
        Me.lvCuotaIVAFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCuotaIVAFP.Width = 95
        '
        'lvCuotaREFP
        '
        Me.lvCuotaREFP.Text = "CUOTA RE"
        Me.lvCuotaREFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCuotaREFP.Width = 90
        '
        'lvRetencionFP
        '
        Me.lvRetencionFP.Text = "RETENCIÓN"
        Me.lvRetencionFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvRetencionFP.Width = 90
        '
        'lvTotalFP
        '
        Me.lvTotalFP.Text = "TOTAL"
        Me.lvTotalFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotalFP.Width = 105
        '
        'tpLiquidacion
        '
        Me.tpLiquidacion.Controls.Add(Me.pbCarga)
        Me.tpLiquidacion.Controls.Add(Me.GroupBox2)
        Me.tpLiquidacion.Controls.Add(Me.tvLiquidacion)
        Me.tpLiquidacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpLiquidacion.Location = New System.Drawing.Point(4, 26)
        Me.tpLiquidacion.Name = "tpLiquidacion"
        Me.tpLiquidacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLiquidacion.Size = New System.Drawing.Size(1055, 537)
        Me.tpLiquidacion.TabIndex = 0
        Me.tpLiquidacion.Text = "LIQUIDACIÓN"
        Me.tpLiquidacion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Diferencia)
        Me.GroupBox2.Controls.Add(Me.TotalCuotaRepercutido)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TotalCuotaSoportado)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 365)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 137)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RESUMEN"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(32, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(213, 18)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "TOTAL  CUOTA REPERCUTIDO"
        '
        'Diferencia
        '
        Me.Diferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Diferencia.BackColor = System.Drawing.SystemColors.Window
        Me.Diferencia.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Diferencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Diferencia.Location = New System.Drawing.Point(253, 92)
        Me.Diferencia.MaxLength = 15
        Me.Diferencia.Name = "Diferencia"
        Me.Diferencia.ReadOnly = True
        Me.Diferencia.Size = New System.Drawing.Size(146, 26)
        Me.Diferencia.TabIndex = 204
        Me.Diferencia.TabStop = False
        Me.Diferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalCuotaRepercutido
        '
        Me.TotalCuotaRepercutido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalCuotaRepercutido.BackColor = System.Drawing.SystemColors.Window
        Me.TotalCuotaRepercutido.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalCuotaRepercutido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalCuotaRepercutido.Location = New System.Drawing.Point(253, 28)
        Me.TotalCuotaRepercutido.MaxLength = 15
        Me.TotalCuotaRepercutido.Name = "TotalCuotaRepercutido"
        Me.TotalCuotaRepercutido.ReadOnly = True
        Me.TotalCuotaRepercutido.Size = New System.Drawing.Size(146, 26)
        Me.TotalCuotaRepercutido.TabIndex = 204
        Me.TotalCuotaRepercutido.TabStop = False
        Me.TotalCuotaRepercutido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(32, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 18)
        Me.Label5.TabIndex = 205
        Me.Label5.Text = "DIFERENCIA"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(32, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 18)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "TOTAL  CUOTA SOPORTADO"
        '
        'TotalCuotaSoportado
        '
        Me.TotalCuotaSoportado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalCuotaSoportado.BackColor = System.Drawing.SystemColors.Window
        Me.TotalCuotaSoportado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalCuotaSoportado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalCuotaSoportado.Location = New System.Drawing.Point(253, 60)
        Me.TotalCuotaSoportado.MaxLength = 15
        Me.TotalCuotaSoportado.Name = "TotalCuotaSoportado"
        Me.TotalCuotaSoportado.ReadOnly = True
        Me.TotalCuotaSoportado.Size = New System.Drawing.Size(146, 26)
        Me.TotalCuotaSoportado.TabIndex = 204
        Me.TotalCuotaSoportado.TabStop = False
        Me.TotalCuotaSoportado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tvLiquidacion
        '
        Me.tvLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvLiquidacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvLiquidacion.Location = New System.Drawing.Point(10, 23)
        Me.tvLiquidacion.Name = "tvLiquidacion"
        Me.tvLiquidacion.Size = New System.Drawing.Size(1035, 336)
        Me.tvLiquidacion.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpLiquidacion)
        Me.TabControl1.Controls.Add(Me.tpRepercutido)
        Me.TabControl1.Controls.Add(Me.tpSoportado)
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(10, 167)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1063, 567)
        Me.TabControl1.TabIndex = 1
        '
        'tpRepercutido
        '
        Me.tpRepercutido.Controls.Add(Me.GroupBox3)
        Me.tpRepercutido.Controls.Add(Me.GroupBox1)
        Me.tpRepercutido.Controls.Add(Me.lbCambioRepercutido)
        Me.tpRepercutido.Controls.Add(Me.ContadorRepercutido)
        Me.tpRepercutido.Controls.Add(Me.Label1)
        Me.tpRepercutido.Controls.Add(Me.lvRepercutido)
        Me.tpRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpRepercutido.Location = New System.Drawing.Point(4, 26)
        Me.tpRepercutido.Name = "tpRepercutido"
        Me.tpRepercutido.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRepercutido.Size = New System.Drawing.Size(1055, 537)
        Me.tpRepercutido.TabIndex = 1
        Me.tpRepercutido.Text = "REPERCUTIDO"
        Me.tpRepercutido.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lvIVAsRepercutido)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 365)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(485, 160)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DESGLOSE IVA/RE"
        '
        'lvIVAsRepercutido
        '
        Me.lvIVAsRepercutido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.lvBaseR, Me.lvIVARER, Me.lvTipoR, Me.lvCuotaR})
        Me.lvIVAsRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lvIVAsRepercutido.FullRowSelect = True
        Me.lvIVAsRepercutido.GridLines = True
        Me.lvIVAsRepercutido.Location = New System.Drawing.Point(22, 18)
        Me.lvIVAsRepercutido.MultiSelect = False
        Me.lvIVAsRepercutido.Name = "lvIVAsRepercutido"
        Me.lvIVAsRepercutido.Size = New System.Drawing.Size(439, 135)
        Me.lvIVAsRepercutido.TabIndex = 202
        Me.lvIVAsRepercutido.UseCompatibleStateImageBehavior = False
        Me.lvIVAsRepercutido.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Width = 0
        '
        'lvBaseR
        '
        Me.lvBaseR.Text = "BASE"
        Me.lvBaseR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvBaseR.Width = 121
        '
        'lvIVARER
        '
        Me.lvIVARER.Text = "IVA/RE"
        Me.lvIVARER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvIVARER.Width = 68
        '
        'lvTipoR
        '
        Me.lvTipoR.Text = "TIPO"
        Me.lvTipoR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTipoR.Width = 86
        '
        'lvCuotaR
        '
        Me.lvCuotaR.Text = "CUOTA"
        Me.lvCuotaR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCuotaR.Width = 126
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lvTotalesRepercutido)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(528, 365)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 60)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TOTALES"
        '
        'lvTotalesRepercutido
        '
        Me.lvTotalesRepercutido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTotalesRepercutido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvTotalesRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lvTotalesRepercutido.FullRowSelect = True
        Me.lvTotalesRepercutido.GridLines = True
        Me.lvTotalesRepercutido.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvTotalesRepercutido.Location = New System.Drawing.Point(15, 19)
        Me.lvTotalesRepercutido.MultiSelect = False
        Me.lvTotalesRepercutido.Name = "lvTotalesRepercutido"
        Me.lvTotalesRepercutido.Size = New System.Drawing.Size(486, 27)
        Me.lvTotalesRepercutido.TabIndex = 205
        Me.lvTotalesRepercutido.UseCompatibleStateImageBehavior = False
        Me.lvTotalesRepercutido.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = ""
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 95
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "TOTALES"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 105
        '
        'lbCambioRepercutido
        '
        Me.lbCambioRepercutido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioRepercutido.AutoSize = True
        Me.lbCambioRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioRepercutido.ForeColor = System.Drawing.Color.Red
        Me.lbCambioRepercutido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioRepercutido.Location = New System.Drawing.Point(544, 489)
        Me.lbCambioRepercutido.Name = "lbCambioRepercutido"
        Me.lbCambioRepercutido.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioRepercutido.TabIndex = 2
        Me.lbCambioRepercutido.Text = "CAMBIO"
        Me.lbCambioRepercutido.Visible = False
        '
        'ContadorRepercutido
        '
        Me.ContadorRepercutido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContadorRepercutido.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorRepercutido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorRepercutido.Location = New System.Drawing.Point(967, 484)
        Me.ContadorRepercutido.MaxLength = 15
        Me.ContadorRepercutido.Name = "ContadorRepercutido"
        Me.ContadorRepercutido.ReadOnly = True
        Me.ContadorRepercutido.Size = New System.Drawing.Size(60, 23)
        Me.ContadorRepercutido.TabIndex = 3
        Me.ContadorRepercutido.TabStop = False
        Me.ContadorRepercutido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(894, 487)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 17)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "FACTURAS"
        '
        'lvRepercutido
        '
        Me.lvRepercutido.AllowColumnReorder = True
        Me.lvRepercutido.AllowDrop = True
        Me.lvRepercutido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvRepercutido.AutoArrange = False
        Me.lvRepercutido.BackgroundImageTiled = True
        Me.lvRepercutido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnum, Me.lvFecha, Me.lvCliente, Me.lvEstado, Me.lvBase, Me.lvCuota, Me.lvCuotaRE, Me.lvRetencionFC, Me.lvTotal})
        Me.lvRepercutido.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvRepercutido.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRepercutido.FullRowSelect = True
        Me.lvRepercutido.GridLines = True
        Me.lvRepercutido.HideSelection = False
        Me.lvRepercutido.LabelEdit = True
        Me.lvRepercutido.Location = New System.Drawing.Point(10, 23)
        Me.lvRepercutido.Name = "lvRepercutido"
        Me.lvRepercutido.ShowItemToolTips = True
        Me.lvRepercutido.Size = New System.Drawing.Size(1035, 333)
        Me.lvRepercutido.TabIndex = 19
        Me.lvRepercutido.UseCompatibleStateImageBehavior = False
        Me.lvRepercutido.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.DisplayIndex = 1
        Me.lvnum.Text = "FACTURA"
        Me.lvnum.Width = 107
        '
        'lvFecha
        '
        Me.lvFecha.DisplayIndex = 0
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 79
        '
        'lvCliente
        '
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 262
        '
        'lvEstado
        '
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 85
        '
        'lvBase
        '
        Me.lvBase.Text = "BASE"
        Me.lvBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvBase.Width = 100
        '
        'lvCuota
        '
        Me.lvCuota.Text = "CUOTA IVA"
        Me.lvCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCuota.Width = 95
        '
        'lvCuotaRE
        '
        Me.lvCuotaRE.Text = "CUOTA RE"
        Me.lvCuotaRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCuotaRE.Width = 90
        '
        'lvRetencionFC
        '
        Me.lvRetencionFC.Text = "RETENCIÓN"
        Me.lvRetencionFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvRetencionFC.Width = 90
        '
        'lvTotal
        '
        Me.lvTotal.Text = "TOTAL"
        Me.lvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotal.Width = 105
        '
        'pbCarga
        '
        Me.pbCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCarga.Location = New System.Drawing.Point(927, 507)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(118, 15)
        Me.pbCarga.TabIndex = 207
        '
        'GestionIVAs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 746)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bLimpiar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionIVAs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN IVA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        Me.tpSoportado.ResumeLayout(False)
        Me.tpSoportado.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.tpLiquidacion.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpRepercutido.ResumeLayout(False)
        Me.tpRepercutido.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents cbTrimestre As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents tpSoportado As System.Windows.Forms.TabPage
    Friend WithEvents ContadorSoportado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvSoportado As System.Windows.Forms.ListView
    Friend WithEvents lvidFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumFacturaProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBaseFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCuotaIVAFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCuotaREFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRetencionFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotalFP As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpLiquidacion As System.Windows.Forms.TabPage
    Friend WithEvents tvLiquidacion As System.Windows.Forms.TreeView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpRepercutido As System.Windows.Forms.TabPage
    Friend WithEvents lvTotalesRepercutido As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContadorRepercutido As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvIVAsRepercutido As System.Windows.Forms.ListView
    Friend WithEvents lvIVARER As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBaseR As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipoR As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCuotaR As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRepercutido As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBase As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCuota As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCuotaRE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRetencionFC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotalesSoportado As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbCambioSoportado As System.Windows.Forms.Label
    Friend WithEvents lbCambioRepercutido As System.Windows.Forms.Label
    Friend WithEvents Diferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TotalCuotaSoportado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TotalCuotaRepercutido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lvIVAsSoportado As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pbCarga As System.Windows.Forms.ProgressBar
End Class
