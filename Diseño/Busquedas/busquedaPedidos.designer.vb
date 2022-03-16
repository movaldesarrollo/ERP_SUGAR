<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class busquedaPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busquedaPedidos))
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.cbAño = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.numDoc = New System.Windows.Forms.TextBox
        Me.lbEstados = New System.Windows.Forms.ListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.RefCliente = New System.Windows.Forms.TextBox
        Me.dtpHastaEntrega = New System.Windows.Forms.DateTimePicker
        Me.dtpHastaPedido = New System.Windows.Forms.DateTimePicker
        Me.dtpDesdeEntrega = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpDesdePedido = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.cbResponsable = New System.Windows.Forms.ComboBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.lvDocumentos = New System.Windows.Forms.ListView
        Me.lvnum = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvEntrega = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvTotal = New System.Windows.Forms.ColumnHeader
        Me.lvPortes = New System.Windows.Forms.ColumnHeader
        Me.lvRefCliente = New System.Windows.Forms.ColumnHeader
        Me.lvPendienteServir = New System.Windows.Forms.ColumnHeader
        Me.lvServido = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bNuevo = New System.Windows.Forms.Button
        Me.lbCambio = New System.Windows.Forms.Label
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TotalPortes = New System.Windows.Forms.TextBox
        Me.bListado = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TotalPendiente = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TotalServido = New System.Windows.Forms.TextBox
        Me.frdatosgenerales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.frdatosgenerales.Controls.Add(Me.cbAño)
        Me.frdatosgenerales.Controls.Add(Me.Label17)
        Me.frdatosgenerales.Controls.Add(Me.numDoc)
        Me.frdatosgenerales.Controls.Add(Me.lbEstados)
        Me.frdatosgenerales.Controls.Add(Me.Label8)
        Me.frdatosgenerales.Controls.Add(Me.RefCliente)
        Me.frdatosgenerales.Controls.Add(Me.dtpHastaEntrega)
        Me.frdatosgenerales.Controls.Add(Me.dtpHastaPedido)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesdeEntrega)
        Me.frdatosgenerales.Controls.Add(Me.Label3)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesdePedido)
        Me.frdatosgenerales.Controls.Add(Me.Label12)
        Me.frdatosgenerales.Controls.Add(Me.Label11)
        Me.frdatosgenerales.Controls.Add(Me.Label13)
        Me.frdatosgenerales.Controls.Add(Me.Label1)
        Me.frdatosgenerales.Controls.Add(Me.Label2)
        Me.frdatosgenerales.Controls.Add(Me.Label4)
        Me.frdatosgenerales.Controls.Add(Me.Label14)
        Me.frdatosgenerales.Controls.Add(Me.cbArticulo)
        Me.frdatosgenerales.Controls.Add(Me.cbCodArticulo)
        Me.frdatosgenerales.Controls.Add(Me.cbCliente)
        Me.frdatosgenerales.Controls.Add(Me.cbResponsable)
        Me.frdatosgenerales.Controls.Add(Me.Label42)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(11, 97)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(1091, 158)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'cbAño
        '
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(595, 32)
        Me.cbAño.MaxLength = 15
        Me.cbAño.Name = "cbAño"
        Me.cbAño.Size = New System.Drawing.Size(52, 25)
        Me.cbAño.TabIndex = 2
        Me.cbAño.Text = "2012"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(548, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 17)
        Me.Label17.TabIndex = 123
        Me.Label17.Text = "AÑO"
        '
        'numDoc
        '
        Me.numDoc.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc.Location = New System.Drawing.Point(106, 32)
        Me.numDoc.MaxLength = 15
        Me.numDoc.Name = "numDoc"
        Me.numDoc.Size = New System.Drawing.Size(114, 23)
        Me.numDoc.TabIndex = 0
        '
        'lbEstados
        '
        Me.lbEstados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbEstados.BackColor = System.Drawing.Color.White
        Me.lbEstados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbEstados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstados.FormattingEnabled = True
        Me.lbEstados.ItemHeight = 17
        Me.lbEstados.Location = New System.Drawing.Point(917, 32)
        Me.lbEstados.Name = "lbEstados"
        Me.lbEstados.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbEstados.Size = New System.Drawing.Size(159, 121)
        Me.lbEstados.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(261, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 17)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "PEDIDO CLIENTE"
        '
        'RefCliente
        '
        Me.RefCliente.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente.Location = New System.Drawing.Point(377, 32)
        Me.RefCliente.MaxLength = 20
        Me.RefCliente.Name = "RefCliente"
        Me.RefCliente.Size = New System.Drawing.Size(107, 23)
        Me.RefCliente.TabIndex = 1
        Me.RefCliente.TabStop = False
        '
        'dtpHastaEntrega
        '
        Me.dtpHastaEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpHastaEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHastaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHastaEntrega.Location = New System.Drawing.Point(815, 62)
        Me.dtpHastaEntrega.Name = "dtpHastaEntrega"
        Me.dtpHastaEntrega.Size = New System.Drawing.Size(89, 23)
        Me.dtpHastaEntrega.TabIndex = 8
        Me.dtpHastaEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpHastaPedido
        '
        Me.dtpHastaPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpHastaPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHastaPedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHastaPedido.Location = New System.Drawing.Point(721, 62)
        Me.dtpHastaPedido.Name = "dtpHastaPedido"
        Me.dtpHastaPedido.Size = New System.Drawing.Size(89, 23)
        Me.dtpHastaPedido.TabIndex = 7
        Me.dtpHastaPedido.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpDesdeEntrega
        '
        Me.dtpDesdeEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDesdeEntrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesdeEntrega.Location = New System.Drawing.Point(815, 32)
        Me.dtpDesdeEntrega.Name = "dtpDesdeEntrega"
        Me.dtpDesdeEntrega.Size = New System.Drawing.Size(89, 23)
        Me.dtpDesdeEntrega.TabIndex = 4
        Me.dtpDesdeEntrega.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(661, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "HASTA"
        '
        'dtpDesdePedido
        '
        Me.dtpDesdePedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDesdePedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesdePedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesdePedido.Location = New System.Drawing.Point(721, 32)
        Me.dtpDesdePedido.Name = "dtpDesdePedido"
        Me.dtpDesdePedido.Size = New System.Drawing.Size(89, 23)
        Me.dtpDesdePedido.TabIndex = 3
        Me.dtpDesdePedido.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(815, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 17)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "ENTREGA"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(723, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 17)
        Me.Label11.TabIndex = 117
        Me.Label11.Text = "PEDIDO"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(661, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "DESDE"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(915, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "ESTADOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(9, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "CLIENTE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(9, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "ARTÍCULO"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(9, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 17)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "RESPONSABLE"
        '
        'cbArticulo
        '
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(226, 124)
        Me.cbArticulo.MaxLength = 30
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(420, 25)
        Me.cbArticulo.TabIndex = 11
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(106, 124)
        Me.cbCodArticulo.MaxLength = 20
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(115, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 10
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(106, 61)
        Me.cbCliente.MaxLength = 100
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(541, 25)
        Me.cbCliente.TabIndex = 6
        '
        'cbResponsable
        '
        Me.cbResponsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbResponsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbResponsable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbResponsable.FormattingEnabled = True
        Me.cbResponsable.Location = New System.Drawing.Point(106, 92)
        Me.cbResponsable.MaxLength = 30
        Me.cbResponsable.Name = "cbResponsable"
        Me.cbResponsable.Size = New System.Drawing.Size(541, 25)
        Me.cbResponsable.TabIndex = 9
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(9, 35)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(94, 17)
        Me.Label42.TabIndex = 102
        Me.Label42.Text = "NÚM. PEDIDO"
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(1017, 23)
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
        Me.bLimpiar.Location = New System.Drawing.Point(815, 23)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 6
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
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
        Me.lvDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnum, Me.lvCliente, Me.lvFecha, Me.lvEntrega, Me.lvEstado, Me.lvTotal, Me.lvPortes, Me.lvRefCliente, Me.lvPendienteServir, Me.lvServido})
        Me.lvDocumentos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDocumentos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDocumentos.FullRowSelect = True
        Me.lvDocumentos.GridLines = True
        Me.lvDocumentos.HideSelection = False
        Me.lvDocumentos.Location = New System.Drawing.Point(11, 262)
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.ShowItemToolTips = True
        Me.lvDocumentos.Size = New System.Drawing.Size(1094, 469)
        Me.lvDocumentos.TabIndex = 1
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.Text = "NUM.PEDIDO"
        Me.lvnum.Width = 89
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 2
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 276
        '
        'lvFecha
        '
        Me.lvFecha.DisplayIndex = 3
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 78
        '
        'lvEntrega
        '
        Me.lvEntrega.DisplayIndex = 4
        Me.lvEntrega.Text = "ENTREGA"
        Me.lvEntrega.Width = 78
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 5
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 103
        '
        'lvTotal
        '
        Me.lvTotal.DisplayIndex = 6
        Me.lvTotal.Text = "TOTAL"
        Me.lvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotal.Width = 87
        '
        'lvPortes
        '
        Me.lvPortes.DisplayIndex = 7
        Me.lvPortes.Text = "PORTES"
        Me.lvPortes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPortes.Width = 71
        '
        'lvRefCliente
        '
        Me.lvRefCliente.DisplayIndex = 1
        Me.lvRefCliente.Text = "PED. CLIENTE"
        Me.lvRefCliente.Width = 101
        '
        'lvPendienteServir
        '
        Me.lvPendienteServir.Text = "PENDIENTE"
        Me.lvPendienteServir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPendienteServir.Width = 87
        '
        'lvServido
        '
        Me.lvServido.Text = "SERVIDO"
        Me.lvServido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvServido.Width = 87
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(916, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 7
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(186, 743)
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
        Me.Contador.Location = New System.Drawing.Point(122, 740)
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
        Me.Total.Location = New System.Drawing.Point(455, 740)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 23)
        Me.Total.TabIndex = 3
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 743)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 190
        Me.Label6.Text = "ENCONTRADOS"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(550, 743)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 17)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "€"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(335, 743)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 17)
        Me.Label5.TabIndex = 191
        Me.Label5.Text = "TOTAL (Sin Portes)"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(570, 743)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 17)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "PORTES"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(701, 743)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 17)
        Me.Label10.TabIndex = 189
        Me.Label10.Text = "€"
        '
        'TotalPortes
        '
        Me.TotalPortes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalPortes.BackColor = System.Drawing.SystemColors.Window
        Me.TotalPortes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPortes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalPortes.Location = New System.Drawing.Point(627, 740)
        Me.TotalPortes.MaxLength = 15
        Me.TotalPortes.Name = "TotalPortes"
        Me.TotalPortes.ReadOnly = True
        Me.TotalPortes.Size = New System.Drawing.Size(72, 23)
        Me.TotalPortes.TabIndex = 4
        Me.TotalPortes.TabStop = False
        Me.TotalPortes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(714, 23)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 5
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(723, 743)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 17)
        Me.Label15.TabIndex = 191
        Me.Label15.Text = "PENDIENTE"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(895, 743)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 17)
        Me.Label16.TabIndex = 189
        Me.Label16.Text = "€"
        '
        'TotalPendiente
        '
        Me.TotalPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalPendiente.BackColor = System.Drawing.SystemColors.Window
        Me.TotalPendiente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPendiente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalPendiente.Location = New System.Drawing.Point(804, 740)
        Me.TotalPendiente.MaxLength = 15
        Me.TotalPendiente.Name = "TotalPendiente"
        Me.TotalPendiente.ReadOnly = True
        Me.TotalPendiente.Size = New System.Drawing.Size(90, 23)
        Me.TotalPendiente.TabIndex = 4
        Me.TotalPendiente.TabStop = False
        Me.TotalPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(919, 743)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 17)
        Me.Label18.TabIndex = 191
        Me.Label18.Text = "SERVIDO"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(1080, 743)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 17)
        Me.Label19.TabIndex = 189
        Me.Label19.Text = "€"
        '
        'TotalServido
        '
        Me.TotalServido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalServido.BackColor = System.Drawing.SystemColors.Window
        Me.TotalServido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalServido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalServido.Location = New System.Drawing.Point(984, 740)
        Me.TotalServido.MaxLength = 15
        Me.TotalServido.Name = "TotalServido"
        Me.TotalServido.ReadOnly = True
        Me.TotalServido.Size = New System.Drawing.Size(90, 23)
        Me.TotalServido.TabIndex = 4
        Me.TotalServido.TabStop = False
        Me.TotalServido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'busquedaPedidos2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 778)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.lbCambio)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.TotalServido)
        Me.Controls.Add(Me.TotalPendiente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TotalPortes)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.bLimpiar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "busquedaPedidos2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE PEDIDOS"
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDesdePedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpHastaPedido As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents lbCambio As System.Windows.Forms.Label
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvPortes As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRefCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RefCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TotalPortes As System.Windows.Forms.TextBox
    Friend WithEvents dtpHastaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesdeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvEntrega As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents lbEstados As System.Windows.Forms.ListBox
    Friend WithEvents numDoc As System.Windows.Forms.TextBox
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lvPendienteServir As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvServido As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TotalPendiente As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TotalServido As System.Windows.Forms.TextBox
End Class
