<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiniCRM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiniCRM))
        Me.cbNombre = New System.Windows.Forms.ComboBox
        Me.bNuevo = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.dtpFechaHora = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbSolicitadoVia = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbContacto = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbDireccion = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Comentario = New System.Windows.Forms.TextBox
        Me.bNuevoCliente = New System.Windows.Forms.Button
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.bBuscarCliente = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cbDestinatario = New System.Windows.Forms.ComboBox
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.ckDestacado = New System.Windows.Forms.CheckBox
        Me.lvComunicaciones = New System.Windows.Forms.ListView
        Me.lvClip = New System.Windows.Forms.ColumnHeader
        Me.lviComunicacion = New System.Windows.Forms.ColumnHeader
        Me.lvidComunicacionPadre = New System.Windows.Forms.ColumnHeader
        Me.lvNombre = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvContacto = New System.Windows.Forms.ColumnHeader
        Me.lvAsunto = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvItems = New System.Windows.Forms.ColumnHeader
        Me.lvDesplegable = New System.Windows.Forms.ColumnHeader
        Me.lvDestinatario = New System.Windows.Forms.ColumnHeader
        Me.bGuardar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbDocumento = New System.Windows.Forms.ComboBox
        Me.bVerFichero = New System.Windows.Forms.Button
        Me.bFichero = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.bVerDocumento = New System.Windows.Forms.Button
        Me.fichero = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Referencia = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.bNuevoContacto = New System.Windows.Forms.Button
        Me.rbProveedor = New System.Windows.Forms.RadioButton
        Me.rbCliente = New System.Windows.Forms.RadioButton
        Me.bListado = New System.Windows.Forms.Button
        Me.bBuscarDocumento = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbNombre
        '
        Me.cbNombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNombre.FormattingEnabled = True
        Me.cbNombre.Location = New System.Drawing.Point(134, 29)
        Me.cbNombre.MaxLength = 15
        Me.cbNombre.Name = "cbNombre"
        Me.cbNombre.Size = New System.Drawing.Size(483, 25)
        Me.cbNombre.TabIndex = 1
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(760, 19)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 6
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(10, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 111
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(956, 19)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bBorrar.Location = New System.Drawing.Point(858, 19)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 7
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'dtpFechaHora
        '
        Me.dtpFechaHora.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHora.Location = New System.Drawing.Point(134, 89)
        Me.dtpFechaHora.Name = "dtpFechaHora"
        Me.dtpFechaHora.Size = New System.Drawing.Size(192, 23)
        Me.dtpFechaHora.TabIndex = 8
        Me.dtpFechaHora.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(31, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 17)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "FECHA-HORA"
        '
        'cbSolicitadoVia
        '
        Me.cbSolicitadoVia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSolicitadoVia.FormattingEnabled = True
        Me.cbSolicitadoVia.Location = New System.Drawing.Point(425, 88)
        Me.cbSolicitadoVia.MaxLength = 30
        Me.cbSolicitadoVia.Name = "cbSolicitadoVia"
        Me.cbSolicitadoVia.Size = New System.Drawing.Size(192, 25)
        Me.cbSolicitadoVia.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(383, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 17)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "VÍA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(651, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 17)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "CONTACTO"
        '
        'cbContacto
        '
        Me.cbContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Location = New System.Drawing.Point(797, 59)
        Me.cbContacto.Name = "cbContacto"
        Me.cbContacto.Size = New System.Drawing.Size(224, 25)
        Me.cbContacto.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(31, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "DIRECCIÓN"
        '
        'cbDireccion
        '
        Me.cbDireccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDireccion.FormattingEnabled = True
        Me.cbDireccion.Location = New System.Drawing.Point(134, 59)
        Me.cbDireccion.Name = "cbDireccion"
        Me.cbDireccion.Size = New System.Drawing.Size(483, 25)
        Me.cbDireccion.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(31, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "ASUNTO"
        '
        'Comentario
        '
        Me.Comentario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comentario.Location = New System.Drawing.Point(134, 147)
        Me.Comentario.Multiline = True
        Me.Comentario.Name = "Comentario"
        Me.Comentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comentario.Size = New System.Drawing.Size(483, 60)
        Me.Comentario.TabIndex = 11
        Me.Comentario.UseSystemPasswordChar = True
        '
        'bNuevoCliente
        '
        Me.bNuevoCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoCliente.Image = CType(resources.GetObject("bNuevoCliente.Image"), System.Drawing.Image)
        Me.bNuevoCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevoCliente.Location = New System.Drawing.Point(101, 29)
        Me.bNuevoCliente.Name = "bNuevoCliente"
        Me.bNuevoCliente.Size = New System.Drawing.Size(27, 25)
        Me.bNuevoCliente.TabIndex = 0
        Me.bNuevoCliente.UseVisualStyleBackColor = True
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = CType(resources.GetObject("bVerCliente.Image"), System.Drawing.Image)
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(671, 29)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 3
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = CType(resources.GetObject("bBuscarCliente.Image"), System.Drawing.Image)
        Me.bBuscarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarCliente.Location = New System.Drawing.Point(639, 29)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarCliente.TabIndex = 2
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(31, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 17)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "DESTINATARIO"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(720, 33)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 17)
        Me.Label34.TabIndex = 148
        Me.Label34.Text = "ESTADO"
        '
        'cbDestinatario
        '
        Me.cbDestinatario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDestinatario.FormattingEnabled = True
        Me.cbDestinatario.Location = New System.Drawing.Point(134, 117)
        Me.cbDestinatario.Name = "cbDestinatario"
        Me.cbDestinatario.Size = New System.Drawing.Size(192, 25)
        Me.cbDestinatario.TabIndex = 10
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(797, 29)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(224, 25)
        Me.cbEstado.TabIndex = 4
        '
        'ckDestacado
        '
        Me.ckDestacado.AutoSize = True
        Me.ckDestacado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDestacado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckDestacado.Location = New System.Drawing.Point(425, 119)
        Me.ckDestacado.Name = "ckDestacado"
        Me.ckDestacado.Size = New System.Drawing.Size(105, 21)
        Me.ckDestacado.TabIndex = 2
        Me.ckDestacado.Text = "DESTACADO"
        Me.ckDestacado.UseVisualStyleBackColor = True
        '
        'lvComunicaciones
        '
        Me.lvComunicaciones.AllowColumnReorder = True
        Me.lvComunicaciones.AllowDrop = True
        Me.lvComunicaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvComunicaciones.BackgroundImageTiled = True
        Me.lvComunicaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvClip, Me.lviComunicacion, Me.lvidComunicacionPadre, Me.lvNombre, Me.lvFecha, Me.lvContacto, Me.lvAsunto, Me.lvEstado, Me.lvItems, Me.lvDesplegable, Me.lvDestinatario})
        Me.lvComunicaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvComunicaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvComunicaciones.FullRowSelect = True
        Me.lvComunicaciones.GridLines = True
        Me.lvComunicaciones.HideSelection = False
        Me.lvComunicaciones.Location = New System.Drawing.Point(10, 346)
        Me.lvComunicaciones.Name = "lvComunicaciones"
        Me.lvComunicaciones.ShowItemToolTips = True
        Me.lvComunicaciones.Size = New System.Drawing.Size(1043, 388)
        Me.lvComunicaciones.TabIndex = 3
        Me.lvComunicaciones.UseCompatibleStateImageBehavior = False
        Me.lvComunicaciones.View = System.Windows.Forms.View.Details
        '
        'lvClip
        '
        Me.lvClip.DisplayIndex = 10
        Me.lvClip.Text = ""
        Me.lvClip.Width = 22
        '
        'lviComunicacion
        '
        Me.lviComunicacion.Text = "IdComunicacion"
        Me.lviComunicacion.Width = 0
        '
        'lvidComunicacionPadre
        '
        Me.lvidComunicacionPadre.Text = "lvidComunicacionPadre"
        Me.lvidComunicacionPadre.Width = 0
        '
        'lvNombre
        '
        Me.lvNombre.Text = "NOMBRE"
        Me.lvNombre.Width = 135
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA-HORA"
        Me.lvFecha.Width = 123
        '
        'lvContacto
        '
        Me.lvContacto.Text = "CONTACTO"
        Me.lvContacto.Width = 113
        '
        'lvAsunto
        '
        Me.lvAsunto.DisplayIndex = 7
        Me.lvAsunto.Text = "ASUNTO"
        Me.lvAsunto.Width = 362
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 8
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 92
        '
        'lvItems
        '
        Me.lvItems.DisplayIndex = 9
        Me.lvItems.Text = "ITEMS"
        Me.lvItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvItems.Width = 45
        '
        'lvDesplegable
        '
        Me.lvDesplegable.DisplayIndex = 0
        Me.lvDesplegable.Text = "+"
        Me.lvDesplegable.Width = 21
        '
        'lvDestinatario
        '
        Me.lvDestinatario.DisplayIndex = 6
        Me.lvDestinatario.Text = "DESTINATARIO"
        Me.lvDestinatario.Width = 102
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bGuardar.Location = New System.Drawing.Point(564, 19)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 4
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbNombre)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.cbDestinatario)
        Me.GroupBox2.Controls.Add(Me.cbDireccion)
        Me.GroupBox2.Controls.Add(Me.cbEstado)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Comentario)
        Me.GroupBox2.Controls.Add(Me.ckDestacado)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.bNuevoContacto)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.bNuevoCliente)
        Me.GroupBox2.Controls.Add(Me.dtpFechaHora)
        Me.GroupBox2.Controls.Add(Me.bBuscarCliente)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.bVerCliente)
        Me.GroupBox2.Controls.Add(Me.cbSolicitadoVia)
        Me.GroupBox2.Controls.Add(Me.cbContacto)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1043, 222)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bBuscarDocumento)
        Me.GroupBox1.Controls.Add(Me.cbDocumento)
        Me.GroupBox1.Controls.Add(Me.bVerFichero)
        Me.GroupBox1.Controls.Add(Me.bFichero)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.bVerDocumento)
        Me.GroupBox1.Controls.Add(Me.fichero)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Referencia)
        Me.GroupBox1.Location = New System.Drawing.Point(638, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 120)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "REFERENCIAS"
        '
        'cbDocumento
        '
        Me.cbDocumento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDocumento.FormattingEnabled = True
        Me.cbDocumento.Location = New System.Drawing.Point(8, 40)
        Me.cbDocumento.MaxLength = 30
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.Size = New System.Drawing.Size(170, 25)
        Me.cbDocumento.Sorted = True
        Me.cbDocumento.TabIndex = 0
        '
        'bVerFichero
        '
        Me.bVerFichero.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerFichero.Image = CType(resources.GetObject("bVerFichero.Image"), System.Drawing.Image)
        Me.bVerFichero.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerFichero.Location = New System.Drawing.Point(356, 87)
        Me.bVerFichero.Name = "bVerFichero"
        Me.bVerFichero.Size = New System.Drawing.Size(27, 25)
        Me.bVerFichero.TabIndex = 6
        Me.bVerFichero.UseVisualStyleBackColor = True
        '
        'bFichero
        '
        Me.bFichero.Cursor = System.Windows.Forms.Cursors.Default
        Me.bFichero.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.bFichero.Image = Global.ERP_SUGAR.My.Resources.Resources.EXPLORER
        Me.bFichero.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bFichero.Location = New System.Drawing.Point(325, 87)
        Me.bFichero.Name = "bFichero"
        Me.bFichero.Size = New System.Drawing.Size(27, 25)
        Me.bFichero.TabIndex = 5
        Me.bFichero.TabStop = False
        Me.bFichero.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(8, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 17)
        Me.Label5.TabIndex = 199
        Me.Label5.Text = "DOCUMENTO"
        '
        'bVerDocumento
        '
        Me.bVerDocumento.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerDocumento.Image = CType(resources.GetObject("bVerDocumento.Image"), System.Drawing.Image)
        Me.bVerDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerDocumento.Location = New System.Drawing.Point(356, 40)
        Me.bVerDocumento.Name = "bVerDocumento"
        Me.bVerDocumento.Size = New System.Drawing.Size(27, 25)
        Me.bVerDocumento.TabIndex = 3
        Me.bVerDocumento.UseVisualStyleBackColor = True
        '
        'fichero
        '
        Me.fichero.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fichero.Location = New System.Drawing.Point(8, 88)
        Me.fichero.MaxLength = 100
        Me.fichero.Name = "fichero"
        Me.fichero.Size = New System.Drawing.Size(298, 23)
        Me.fichero.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.CausesValidation = False
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(8, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 17)
        Me.Label15.TabIndex = 201
        Me.Label15.Text = "FICHERO"
        '
        'Referencia
        '
        Me.Referencia.BackColor = System.Drawing.SystemColors.Window
        Me.Referencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Referencia.Location = New System.Drawing.Point(187, 41)
        Me.Referencia.MaxLength = 50
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Size = New System.Drawing.Size(119, 23)
        Me.Referencia.TabIndex = 1
        Me.Referencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(31, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "NOMBRE"
        '
        'bNuevoContacto
        '
        Me.bNuevoContacto.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoContacto.Image = CType(resources.GetObject("bNuevoContacto.Image"), System.Drawing.Image)
        Me.bNuevoContacto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevoContacto.Location = New System.Drawing.Point(748, 59)
        Me.bNuevoContacto.Name = "bNuevoContacto"
        Me.bNuevoContacto.Size = New System.Drawing.Size(27, 25)
        Me.bNuevoContacto.TabIndex = 6
        Me.bNuevoContacto.UseVisualStyleBackColor = True
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProveedor.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProveedor.Location = New System.Drawing.Point(152, 97)
        Me.rbProveedor.Name = "rbProveedor"
        Me.rbProveedor.Size = New System.Drawing.Size(118, 23)
        Me.rbProveedor.TabIndex = 1
        Me.rbProveedor.TabStop = True
        Me.rbProveedor.Text = "PROVEEDOR"
        Me.rbProveedor.UseVisualStyleBackColor = True
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbCliente.Location = New System.Drawing.Point(24, 98)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(85, 23)
        Me.rbCliente.TabIndex = 0
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "CLIENTE"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bListado.Location = New System.Drawing.Point(662, 19)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 5
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'bBuscarDocumento
        '
        Me.bBuscarDocumento.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarDocumento.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarDocumento.Location = New System.Drawing.Point(325, 40)
        Me.bBuscarDocumento.Name = "bBuscarDocumento"
        Me.bBuscarDocumento.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarDocumento.TabIndex = 2
        Me.bBuscarDocumento.UseVisualStyleBackColor = True
        '
        'MiniCRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 762)
        Me.Controls.Add(Me.rbProveedor)
        Me.Controls.Add(Me.rbCliente)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lvComunicaciones)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bBorrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MiniCRM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COMUNICACIONES"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbNombre As System.Windows.Forms.ComboBox
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbSolicitadoVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Comentario As System.Windows.Forms.TextBox
    Friend WithEvents bNuevoCliente As System.Windows.Forms.Button
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lvComunicaciones As System.Windows.Forms.ListView
    Friend WithEvents lviComunicacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvContacto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAsunto As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckDestacado As System.Windows.Forms.CheckBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDestinatario As System.Windows.Forms.ComboBox
    Friend WithEvents lvDesplegable As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidComunicacionPadre As System.Windows.Forms.ColumnHeader
    Friend WithEvents rbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents bNuevoContacto As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvItems As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVerFichero As System.Windows.Forms.Button
    Friend WithEvents bVerDocumento As System.Windows.Forms.Button
    Friend WithEvents bFichero As System.Windows.Forms.Button
    Friend WithEvents fichero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Referencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents cbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvClip As System.Windows.Forms.ColumnHeader
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents lvDestinatario As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBuscarDocumento As System.Windows.Forms.Button
End Class
