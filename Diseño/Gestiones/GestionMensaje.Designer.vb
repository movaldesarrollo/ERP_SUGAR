<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionMensaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionMensaje))
        Me.lvComunicaciones = New System.Windows.Forms.ListView
        Me.lvClip = New System.Windows.Forms.ColumnHeader
        Me.lviComunicacion = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvContacto = New System.Windows.Forms.ColumnHeader
        Me.lvRespondidoPor = New System.Windows.Forms.ColumnHeader
        Me.lvAsunto = New System.Windows.Forms.ColumnHeader
        Me.gbMensaje = New System.Windows.Forms.GroupBox
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.ckDestacado = New System.Windows.Forms.CheckBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.bVerFicheroM = New System.Windows.Forms.Button
        Me.bVerDocumentoM = New System.Windows.Forms.Button
        Me.ReferenciaM = New System.Windows.Forms.TextBox
        Me.DocumentoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.FicheroM = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ContactoM = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Asunto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Direccion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.TextBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbContacto = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpFechaHora = New System.Windows.Forms.DateTimePicker
        Me.bVerFichero = New System.Windows.Forms.Button
        Me.bVerDocumento = New System.Windows.Forms.Button
        Me.bFichero = New System.Windows.Forms.Button
        Me.fichero = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Referencia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbDocumento = New System.Windows.Forms.ComboBox
        Me.Respuesta = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.bListado = New System.Windows.Forms.Button
        Me.bBuscarDocumento = New System.Windows.Forms.Button
        Me.gbMensaje.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvComunicaciones
        '
        Me.lvComunicaciones.AllowColumnReorder = True
        Me.lvComunicaciones.AllowDrop = True
        Me.lvComunicaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvComunicaciones.BackgroundImageTiled = True
        Me.lvComunicaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvClip, Me.lviComunicacion, Me.lvFecha, Me.lvContacto, Me.lvRespondidoPor, Me.lvAsunto})
        Me.lvComunicaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvComunicaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvComunicaciones.FullRowSelect = True
        Me.lvComunicaciones.GridLines = True
        Me.lvComunicaciones.HideSelection = False
        Me.lvComunicaciones.Location = New System.Drawing.Point(22, 421)
        Me.lvComunicaciones.Name = "lvComunicaciones"
        Me.lvComunicaciones.ShowItemToolTips = True
        Me.lvComunicaciones.Size = New System.Drawing.Size(935, 282)
        Me.lvComunicaciones.TabIndex = 2
        Me.lvComunicaciones.UseCompatibleStateImageBehavior = False
        Me.lvComunicaciones.View = System.Windows.Forms.View.Details
        '
        'lvClip
        '
        Me.lvClip.DisplayIndex = 5
        Me.lvClip.Text = ""
        Me.lvClip.Width = 20
        '
        'lviComunicacion
        '
        Me.lviComunicacion.DisplayIndex = 0
        Me.lviComunicacion.Text = "IdComunicacion"
        Me.lviComunicacion.Width = 0
        '
        'lvFecha
        '
        Me.lvFecha.DisplayIndex = 1
        Me.lvFecha.Text = "FECHA-HORA"
        Me.lvFecha.Width = 123
        '
        'lvContacto
        '
        Me.lvContacto.DisplayIndex = 2
        Me.lvContacto.Text = "CONTACTO"
        Me.lvContacto.Width = 113
        '
        'lvRespondidoPor
        '
        Me.lvRespondidoPor.DisplayIndex = 3
        Me.lvRespondidoPor.Text = "RESPONDIDO POR"
        Me.lvRespondidoPor.Width = 120
        '
        'lvAsunto
        '
        Me.lvAsunto.DisplayIndex = 4
        Me.lvAsunto.Text = "RESPUESTA"
        Me.lvAsunto.Width = 519
        '
        'gbMensaje
        '
        Me.gbMensaje.Controls.Add(Me.bVerCliente)
        Me.gbMensaje.Controls.Add(Me.ckDestacado)
        Me.gbMensaje.Controls.Add(Me.Label34)
        Me.gbMensaje.Controls.Add(Me.cbEstado)
        Me.gbMensaje.Controls.Add(Me.bVerFicheroM)
        Me.gbMensaje.Controls.Add(Me.bVerDocumentoM)
        Me.gbMensaje.Controls.Add(Me.ReferenciaM)
        Me.gbMensaje.Controls.Add(Me.DocumentoM)
        Me.gbMensaje.Controls.Add(Me.Label7)
        Me.gbMensaje.Controls.Add(Me.FicheroM)
        Me.gbMensaje.Controls.Add(Me.Label8)
        Me.gbMensaje.Controls.Add(Me.ContactoM)
        Me.gbMensaje.Controls.Add(Me.Label2)
        Me.gbMensaje.Controls.Add(Me.Asunto)
        Me.gbMensaje.Controls.Add(Me.Label3)
        Me.gbMensaje.Controls.Add(Me.Direccion)
        Me.gbMensaje.Controls.Add(Me.Label1)
        Me.gbMensaje.Controls.Add(Me.Nombre)
        Me.gbMensaje.Controls.Add(Me.Label48)
        Me.gbMensaje.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMensaje.Location = New System.Drawing.Point(22, 90)
        Me.gbMensaje.Name = "gbMensaje"
        Me.gbMensaje.Size = New System.Drawing.Size(935, 159)
        Me.gbMensaje.TabIndex = 0
        Me.gbMensaje.TabStop = False
        Me.gbMensaje.Text = "MENSAJE"
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = CType(resources.GetObject("bVerCliente.Image"), System.Drawing.Image)
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(489, 20)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 192
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'ckDestacado
        '
        Me.ckDestacado.AutoSize = True
        Me.ckDestacado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckDestacado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckDestacado.Location = New System.Drawing.Point(563, 23)
        Me.ckDestacado.Name = "ckDestacado"
        Me.ckDestacado.Size = New System.Drawing.Size(105, 21)
        Me.ckDestacado.TabIndex = 1
        Me.ckDestacado.Text = "DESTACADO"
        Me.ckDestacado.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(700, 25)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 17)
        Me.Label34.TabIndex = 191
        Me.Label34.Text = "ESTADO"
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(775, 20)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(125, 26)
        Me.cbEstado.TabIndex = 2
        '
        'bVerFicheroM
        '
        Me.bVerFicheroM.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerFicheroM.Image = CType(resources.GetObject("bVerFicheroM.Image"), System.Drawing.Image)
        Me.bVerFicheroM.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerFicheroM.Location = New System.Drawing.Point(903, 117)
        Me.bVerFicheroM.Name = "bVerFicheroM"
        Me.bVerFicheroM.Size = New System.Drawing.Size(27, 25)
        Me.bVerFicheroM.TabIndex = 10
        Me.bVerFicheroM.UseVisualStyleBackColor = True
        '
        'bVerDocumentoM
        '
        Me.bVerDocumentoM.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerDocumentoM.Image = CType(resources.GetObject("bVerDocumentoM.Image"), System.Drawing.Image)
        Me.bVerDocumentoM.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerDocumentoM.Location = New System.Drawing.Point(903, 82)
        Me.bVerDocumentoM.Name = "bVerDocumentoM"
        Me.bVerDocumentoM.Size = New System.Drawing.Size(27, 25)
        Me.bVerDocumentoM.TabIndex = 8
        Me.bVerDocumentoM.UseVisualStyleBackColor = True
        '
        'ReferenciaM
        '
        Me.ReferenciaM.BackColor = System.Drawing.SystemColors.Control
        Me.ReferenciaM.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferenciaM.Location = New System.Drawing.Point(775, 83)
        Me.ReferenciaM.MaxLength = 50
        Me.ReferenciaM.Name = "ReferenciaM"
        Me.ReferenciaM.ReadOnly = True
        Me.ReferenciaM.Size = New System.Drawing.Size(125, 23)
        Me.ReferenciaM.TabIndex = 7
        '
        'DocumentoM
        '
        Me.DocumentoM.BackColor = System.Drawing.SystemColors.Control
        Me.DocumentoM.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DocumentoM.Location = New System.Drawing.Point(617, 83)
        Me.DocumentoM.MaxLength = 50
        Me.DocumentoM.Name = "DocumentoM"
        Me.DocumentoM.ReadOnly = True
        Me.DocumentoM.Size = New System.Drawing.Size(147, 23)
        Me.DocumentoM.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(524, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 17)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "DOCUMENTO"
        '
        'FicheroM
        '
        Me.FicheroM.BackColor = System.Drawing.SystemColors.Control
        Me.FicheroM.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FicheroM.Location = New System.Drawing.Point(617, 118)
        Me.FicheroM.MaxLength = 50
        Me.FicheroM.Name = "FicheroM"
        Me.FicheroM.ReadOnly = True
        Me.FicheroM.Size = New System.Drawing.Size(283, 23)
        Me.FicheroM.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(524, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 17)
        Me.Label8.TabIndex = 189
        Me.Label8.Text = "FICHERO"
        '
        'ContactoM
        '
        Me.ContactoM.BackColor = System.Drawing.SystemColors.Control
        Me.ContactoM.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactoM.Location = New System.Drawing.Point(617, 52)
        Me.ContactoM.MaxLength = 50
        Me.ContactoM.Name = "ContactoM"
        Me.ContactoM.ReadOnly = True
        Me.ContactoM.Size = New System.Drawing.Size(283, 23)
        Me.ContactoM.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(524, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "CONTACTO"
        '
        'Asunto
        '
        Me.Asunto.BackColor = System.Drawing.SystemColors.Control
        Me.Asunto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Asunto.Location = New System.Drawing.Point(101, 81)
        Me.Asunto.MaxLength = 50
        Me.Asunto.Multiline = True
        Me.Asunto.Name = "Asunto"
        Me.Asunto.ReadOnly = True
        Me.Asunto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Asunto.Size = New System.Drawing.Size(414, 60)
        Me.Asunto.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(7, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 189
        Me.Label3.Text = "ASUNTO"
        '
        'Direccion
        '
        Me.Direccion.BackColor = System.Drawing.SystemColors.Control
        Me.Direccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Direccion.Location = New System.Drawing.Point(101, 52)
        Me.Direccion.MaxLength = 50
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ReadOnly = True
        Me.Direccion.Size = New System.Drawing.Size(414, 23)
        Me.Direccion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(7, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "DIRECCIÓN"
        '
        'Nombre
        '
        Me.Nombre.BackColor = System.Drawing.SystemColors.Control
        Me.Nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(101, 22)
        Me.Nombre.MaxLength = 50
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Size = New System.Drawing.Size(381, 23)
        Me.Nombre.TabIndex = 0
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label48.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(7, 25)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(62, 17)
        Me.Label48.TabIndex = 189
        Me.Label48.Text = "NOMBRE"
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bGuardar.Location = New System.Drawing.Point(484, 21)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(674, 21)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 5
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 117
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(864, 21)
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
        Me.bBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bBorrar.Location = New System.Drawing.Point(769, 21)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 6
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bBuscarDocumento)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cbContacto)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtpFechaHora)
        Me.GroupBox2.Controls.Add(Me.bVerFichero)
        Me.GroupBox2.Controls.Add(Me.bVerDocumento)
        Me.GroupBox2.Controls.Add(Me.bFichero)
        Me.GroupBox2.Controls.Add(Me.fichero)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Referencia)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbDocumento)
        Me.GroupBox2.Controls.Add(Me.Respuesta)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(22, 253)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(935, 162)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RESPUESTA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(533, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 17)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "CONTACTO"
        '
        'cbContacto
        '
        Me.cbContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Location = New System.Drawing.Point(617, 24)
        Me.cbContacto.Name = "cbContacto"
        Me.cbContacto.Size = New System.Drawing.Size(283, 25)
        Me.cbContacto.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(7, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 17)
        Me.Label13.TabIndex = 199
        Me.Label13.Text = "FECHA-HORA"
        '
        'dtpFechaHora
        '
        Me.dtpFechaHora.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHora.Location = New System.Drawing.Point(101, 25)
        Me.dtpFechaHora.Name = "dtpFechaHora"
        Me.dtpFechaHora.Size = New System.Drawing.Size(192, 23)
        Me.dtpFechaHora.TabIndex = 0
        Me.dtpFechaHora.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'bVerFichero
        '
        Me.bVerFichero.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerFichero.Image = CType(resources.GetObject("bVerFichero.Image"), System.Drawing.Image)
        Me.bVerFichero.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerFichero.Location = New System.Drawing.Point(903, 124)
        Me.bVerFichero.Name = "bVerFichero"
        Me.bVerFichero.Size = New System.Drawing.Size(27, 25)
        Me.bVerFichero.TabIndex = 9
        Me.bVerFichero.UseVisualStyleBackColor = True
        '
        'bVerDocumento
        '
        Me.bVerDocumento.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerDocumento.Image = CType(resources.GetObject("bVerDocumento.Image"), System.Drawing.Image)
        Me.bVerDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerDocumento.Location = New System.Drawing.Point(508, 124)
        Me.bVerDocumento.Name = "bVerDocumento"
        Me.bVerDocumento.Size = New System.Drawing.Size(27, 25)
        Me.bVerDocumento.TabIndex = 6
        Me.bVerDocumento.UseVisualStyleBackColor = True
        '
        'bFichero
        '
        Me.bFichero.Cursor = System.Windows.Forms.Cursors.Default
        Me.bFichero.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.bFichero.Image = Global.ERP_SUGAR.My.Resources.Resources.EXPLORER
        Me.bFichero.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bFichero.Location = New System.Drawing.Point(870, 124)
        Me.bFichero.Name = "bFichero"
        Me.bFichero.Size = New System.Drawing.Size(27, 25)
        Me.bFichero.TabIndex = 8
        Me.bFichero.TabStop = False
        Me.bFichero.UseVisualStyleBackColor = True
        '
        'fichero
        '
        Me.fichero.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fichero.Location = New System.Drawing.Point(617, 125)
        Me.fichero.MaxLength = 100
        Me.fichero.Name = "fichero"
        Me.fichero.Size = New System.Drawing.Size(238, 23)
        Me.fichero.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.CausesValidation = False
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(544, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 17)
        Me.Label15.TabIndex = 194
        Me.Label15.Text = "FICHERO"
        '
        'Referencia
        '
        Me.Referencia.BackColor = System.Drawing.SystemColors.Window
        Me.Referencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Referencia.Location = New System.Drawing.Point(296, 125)
        Me.Referencia.MaxLength = 50
        Me.Referencia.Name = "Referencia"
        Me.Referencia.Size = New System.Drawing.Size(157, 23)
        Me.Referencia.TabIndex = 4
        Me.Referencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(7, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 17)
        Me.Label5.TabIndex = 191
        Me.Label5.Text = "DOCUMENTO"
        '
        'cbDocumento
        '
        Me.cbDocumento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDocumento.FormattingEnabled = True
        Me.cbDocumento.Location = New System.Drawing.Point(101, 124)
        Me.cbDocumento.MaxLength = 30
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.Size = New System.Drawing.Size(192, 25)
        Me.cbDocumento.Sorted = True
        Me.cbDocumento.TabIndex = 3
        '
        'Respuesta
        '
        Me.Respuesta.BackColor = System.Drawing.SystemColors.Window
        Me.Respuesta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Respuesta.Location = New System.Drawing.Point(101, 55)
        Me.Respuesta.MaxLength = 1000
        Me.Respuesta.Multiline = True
        Me.Respuesta.Name = "Respuesta"
        Me.Respuesta.Size = New System.Drawing.Size(799, 60)
        Me.Respuesta.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(7, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 17)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "TEXTO"
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bListado.Location = New System.Drawing.Point(579, 21)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 4
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'bBuscarDocumento
        '
        Me.bBuscarDocumento.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarDocumento.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarDocumento.Location = New System.Drawing.Point(475, 124)
        Me.bBuscarDocumento.Name = "bBuscarDocumento"
        Me.bBuscarDocumento.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarDocumento.TabIndex = 5
        Me.bBuscarDocumento.UseVisualStyleBackColor = True
        '
        'GestionMensaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 724)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.gbMensaje)
        Me.Controls.Add(Me.lvComunicaciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionMensaje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENSAJE"
        Me.gbMensaje.ResumeLayout(False)
        Me.gbMensaje.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvComunicaciones As System.Windows.Forms.ListView
    Friend WithEvents lviComunicacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvContacto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAsunto As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbMensaje As System.Windows.Forms.GroupBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents ContactoM As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Asunto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Respuesta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Referencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents cbDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents fichero As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents bFichero As System.Windows.Forms.Button
    Friend WithEvents lvClip As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVerDocumento As System.Windows.Forms.Button
    Friend WithEvents bVerFichero As System.Windows.Forms.Button
    Friend WithEvents ReferenciaM As System.Windows.Forms.TextBox
    Friend WithEvents DocumentoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FicheroM As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bVerFicheroM As System.Windows.Forms.Button
    Friend WithEvents bVerDocumentoM As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents lvRespondidoPor As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ckDestacado As System.Windows.Forms.CheckBox
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents bBuscarDocumento As System.Windows.Forms.Button
End Class
