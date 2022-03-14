<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecepcionPedidoProv1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecepcionPedidoProv1))
        Me.gbConceptos = New System.Windows.Forms.GroupBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.codArticuloProv = New System.Windows.Forms.TextBox
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.Check = New System.Windows.Forms.ColumnHeader
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCodArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvPendiente = New System.Windows.Forms.ColumnHeader
        Me.lvCantidadRecibida = New System.Windows.Forms.ColumnHeader
        Me.lvUnidadMedida = New System.Windows.Forms.ColumnHeader
        Me.lvFechaRecibido = New System.Windows.Forms.ColumnHeader
        Me.lvAceptado = New System.Windows.Forms.ColumnHeader
        Me.lvRecibido = New System.Windows.Forms.ColumnHeader
        Me.lvAlbaran = New System.Windows.Forms.ColumnHeader
        Me.lvCodMoneda = New System.Windows.Forms.ColumnHeader
        Me.lbMoneda3 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Nombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbUnidades2 = New System.Windows.Forms.Label
        Me.lbUnidades1 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.CantidadRecibida = New System.Windows.Forms.TextBox
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbAlmacen = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpFechaRecepcion = New System.Windows.Forms.DateTimePicker
        Me.bGuardarConcepto = New System.Windows.Forms.Button
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.bRecepcion = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.Proveedor = New System.Windows.Forms.TextBox
        Me.Estado = New System.Windows.Forms.TextBox
        Me.FechaPedido = New System.Windows.Forms.TextBox
        Me.bVerAlbaran = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.numAlbaran = New System.Windows.Forms.TextBox
        Me.bDetalle = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox
        Me.lvIVA = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Nota = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.gbConceptos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConceptos
        '
        Me.gbConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbConceptos.Controls.Add(Me.Label4)
        Me.gbConceptos.Controls.Add(Me.cbTipoIVA)
        Me.gbConceptos.Controls.Add(Me.ckSeleccion)
        Me.gbConceptos.Controls.Add(Me.codArticuloProv)
        Me.gbConceptos.Controls.Add(Me.codArticulo)
        Me.gbConceptos.Controls.Add(Me.lvConceptos)
        Me.gbConceptos.Controls.Add(Me.lbMoneda3)
        Me.gbConceptos.Controls.Add(Me.Label34)
        Me.gbConceptos.Controls.Add(Me.Nombre)
        Me.gbConceptos.Controls.Add(Me.Label9)
        Me.gbConceptos.Controls.Add(Me.Label8)
        Me.gbConceptos.Controls.Add(Me.Label1)
        Me.gbConceptos.Controls.Add(Me.lbUnidades2)
        Me.gbConceptos.Controls.Add(Me.lbUnidades1)
        Me.gbConceptos.Controls.Add(Me.Label26)
        Me.gbConceptos.Controls.Add(Me.CantidadRecibida)
        Me.gbConceptos.Controls.Add(Me.Cantidad)
        Me.gbConceptos.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.gbConceptos.Location = New System.Drawing.Point(7, 307)
        Me.gbConceptos.Name = "gbConceptos"
        Me.gbConceptos.Size = New System.Drawing.Size(1143, 503)
        Me.gbConceptos.TabIndex = 8
        Me.gbConceptos.TabStop = False
        Me.gbConceptos.Text = "CONCEPTOS"
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(18, 82)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 5
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'codArticuloProv
        '
        Me.codArticuloProv.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticuloProv.Location = New System.Drawing.Point(149, 42)
        Me.codArticuloProv.MaxLength = 100
        Me.codArticuloProv.Name = "codArticuloProv"
        Me.codArticuloProv.ReadOnly = True
        Me.codArticuloProv.Size = New System.Drawing.Size(126, 23)
        Me.codArticuloProv.TabIndex = 1
        '
        'codArticulo
        '
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(11, 42)
        Me.codArticulo.MaxLength = 100
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(131, 23)
        Me.codArticulo.TabIndex = 0
        '
        'lvConceptos
        '
        Me.lvConceptos.AllowColumnReorder = True
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.AutoArrange = False
        Me.lvConceptos.BackgroundImageTiled = True
        Me.lvConceptos.CheckBoxes = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Check, Me.lvidConcepto, Me.lvcodArticulo, Me.lvCodArticuloProv, Me.lvdescripcion, Me.lvCantidad, Me.lvPendiente, Me.lvCantidadRecibida, Me.lvUnidadMedida, Me.lvFechaRecibido, Me.lvAceptado, Me.lvRecibido, Me.lvAlbaran, Me.lvCodMoneda, Me.lvIVA})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(11, 75)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.Size = New System.Drawing.Size(1121, 407)
        Me.lvConceptos.TabIndex = 6
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'Check
        '
        Me.Check.Text = ""
        Me.Check.Width = 22
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "CONCEPTO"
        Me.lvidConcepto.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 103
        '
        'lvCodArticuloProv
        '
        Me.lvCodArticuloProv.Text = "CÓD. PROV."
        Me.lvCodArticuloProv.Width = 115
        '
        'lvdescripcion
        '
        Me.lvdescripcion.Text = "DESCRIPCIÓN"
        Me.lvdescripcion.Width = 276
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 78
        '
        'lvPendiente
        '
        Me.lvPendiente.Text = "PENDIENTE"
        Me.lvPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPendiente.Width = 84
        '
        'lvCantidadRecibida
        '
        Me.lvCantidadRecibida.Text = "RECIBIDO"
        Me.lvCantidadRecibida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidadRecibida.Width = 91
        '
        'lvUnidadMedida
        '
        Me.lvUnidadMedida.Text = "UnidadMedida"
        Me.lvUnidadMedida.Width = 0
        '
        'lvFechaRecibido
        '
        Me.lvFechaRecibido.Text = "FECHA RECIBIDO"
        Me.lvFechaRecibido.Width = 110
        '
        'lvAceptado
        '
        Me.lvAceptado.Text = "CONFORME"
        Me.lvAceptado.Width = 0
        '
        'lvRecibido
        '
        Me.lvRecibido.Text = "RECIBIDO"
        Me.lvRecibido.Width = 0
        '
        'lvAlbaran
        '
        Me.lvAlbaran.Text = "ALBARÁN"
        Me.lvAlbaran.Width = 94
        '
        'lvCodMoneda
        '
        Me.lvCodMoneda.Text = "codMoneda"
        Me.lvCodMoneda.Width = 0
        '
        'lbMoneda3
        '
        Me.lbMoneda3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbMoneda3.AutoSize = True
        Me.lbMoneda3.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.lbMoneda3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda3.Location = New System.Drawing.Point(1161, 449)
        Me.lbMoneda3.Name = "lbMoneda3"
        Me.lbMoneda3.Size = New System.Drawing.Size(17, 20)
        Me.lbMoneda3.TabIndex = 98
        Me.lbMoneda3.Text = "€"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(284, 21)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(96, 17)
        Me.Label34.TabIndex = 38
        Me.Label34.Text = "DESCRIPCIÓN"
        '
        'Nombre
        '
        Me.Nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.Location = New System.Drawing.Point(281, 42)
        Me.Nombre.MaxLength = 100
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Size = New System.Drawing.Size(358, 23)
        Me.Nombre.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(151, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 17)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "CÓD. PROVEEDOR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(15, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "CÓDIGO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(969, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "RECIBIDO AHORA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbUnidades2
        '
        Me.lbUnidades2.AutoSize = True
        Me.lbUnidades2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidades2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidades2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidades2.Location = New System.Drawing.Point(1066, 45)
        Me.lbUnidades2.Name = "lbUnidades2"
        Me.lbUnidades2.Size = New System.Drawing.Size(20, 17)
        Me.lbUnidades2.TabIndex = 7
        Me.lbUnidades2.Text = "u."
        Me.lbUnidades2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbUnidades1
        '
        Me.lbUnidades1.AutoSize = True
        Me.lbUnidades1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidades1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidades1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidades1.Location = New System.Drawing.Point(918, 45)
        Me.lbUnidades1.Name = "lbUnidades1"
        Me.lbUnidades1.Size = New System.Drawing.Size(20, 17)
        Me.lbUnidades1.TabIndex = 7
        Me.lbUnidades1.Text = "u."
        Me.lbUnidades1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(843, 21)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(75, 17)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "PENDIENTE"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CantidadRecibida
        '
        Me.CantidadRecibida.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadRecibida.ForeColor = System.Drawing.Color.Black
        Me.CantidadRecibida.Location = New System.Drawing.Point(989, 42)
        Me.CantidadRecibida.Name = "CantidadRecibida"
        Me.CantidadRecibida.Size = New System.Drawing.Size(77, 23)
        Me.CantidadRecibida.TabIndex = 4
        Me.CantidadRecibida.Text = "0"
        Me.CantidadRecibida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cantidad
        '
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.Color.Black
        Me.Cantidad.Location = New System.Drawing.Point(841, 42)
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Size = New System.Drawing.Size(77, 23)
        Me.Cantidad.TabIndex = 3
        Me.Cantidad.Text = "0"
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(792, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 17)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "ALMACÉN"
        '
        'cbAlmacen
        '
        Me.cbAlmacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(869, 70)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(161, 25)
        Me.cbAlmacen.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(14, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 17)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "FECHA RECEPCIÓN"
        '
        'dtpFechaRecepcion
        '
        Me.dtpFechaRecepcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaRecepcion.Location = New System.Drawing.Point(149, 171)
        Me.dtpFechaRecepcion.Name = "dtpFechaRecepcion"
        Me.dtpFechaRecepcion.Size = New System.Drawing.Size(99, 23)
        Me.dtpFechaRecepcion.TabIndex = 4
        Me.dtpFechaRecepcion.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'bGuardarConcepto
        '
        Me.bGuardarConcepto.Cursor = System.Windows.Forms.Cursors.Default
        Me.bGuardarConcepto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardarConcepto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardarConcepto.Location = New System.Drawing.Point(713, 14)
        Me.bGuardarConcepto.Name = "bGuardarConcepto"
        Me.bGuardarConcepto.Size = New System.Drawing.Size(110, 50)
        Me.bGuardarConcepto.TabIndex = 10
        Me.bGuardarConcepto.Text = "GUARDAR"
        Me.bGuardarConcepto.UseVisualStyleBackColor = True
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.numPedido.Location = New System.Drawing.Point(149, 67)
        Me.numPedido.Name = "numPedido"
        Me.numPedido.ReadOnly = True
        Me.numPedido.Size = New System.Drawing.Size(99, 27)
        Me.numPedido.TabIndex = 0
        Me.numPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(14, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 18)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "NÚMERO PEDIDO"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(269, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 17)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "PROVEEDOR"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(14, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "FECHA PEDIDO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(304, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 18)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "ESTADO"
        '
        'bRecepcion
        '
        Me.bRecepcion.Cursor = System.Windows.Forms.Cursors.Default
        Me.bRecepcion.Enabled = False
        Me.bRecepcion.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bRecepcion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bRecepcion.Location = New System.Drawing.Point(835, 14)
        Me.bRecepcion.Name = "bRecepcion"
        Me.bRecepcion.Size = New System.Drawing.Size(110, 50)
        Me.bRecepcion.TabIndex = 11
        Me.bRecepcion.Text = "RECEPCIÓN"
        Me.bRecepcion.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(957, 14)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(110, 50)
        Me.bSalir.TabIndex = 12
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Proveedor
        '
        Me.Proveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Proveedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Proveedor.Location = New System.Drawing.Point(374, 65)
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Size = New System.Drawing.Size(320, 23)
        Me.Proveedor.TabIndex = 2
        '
        'Estado
        '
        Me.Estado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Estado.Location = New System.Drawing.Point(381, 28)
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Size = New System.Drawing.Size(161, 23)
        Me.Estado.TabIndex = 3
        '
        'FechaPedido
        '
        Me.FechaPedido.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold)
        Me.FechaPedido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FechaPedido.Location = New System.Drawing.Point(149, 139)
        Me.FechaPedido.Name = "FechaPedido"
        Me.FechaPedido.ReadOnly = True
        Me.FechaPedido.Size = New System.Drawing.Size(99, 26)
        Me.FechaPedido.TabIndex = 1
        Me.FechaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bVerAlbaran
        '
        Me.bVerAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerAlbaran.Image = CType(resources.GetObject("bVerAlbaran.Image"), System.Drawing.Image)
        Me.bVerAlbaran.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerAlbaran.Location = New System.Drawing.Point(261, 108)
        Me.bVerAlbaran.Name = "bVerAlbaran"
        Me.bVerAlbaran.Size = New System.Drawing.Size(27, 25)
        Me.bVerAlbaran.TabIndex = 6
        Me.bVerAlbaran.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(37, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 17)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "ALBARÁN PROV."
        '
        'numAlbaran
        '
        Me.numAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAlbaran.ForeColor = System.Drawing.Color.Black
        Me.numAlbaran.Location = New System.Drawing.Point(149, 110)
        Me.numAlbaran.Name = "numAlbaran"
        Me.numAlbaran.Size = New System.Drawing.Size(106, 23)
        Me.numAlbaran.TabIndex = 5
        '
        'bDetalle
        '
        Me.bDetalle.Cursor = System.Windows.Forms.Cursors.Default
        Me.bDetalle.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bDetalle.Location = New System.Drawing.Point(591, 14)
        Me.bDetalle.Name = "bDetalle"
        Me.bDetalle.Size = New System.Drawing.Size(110, 50)
        Me.bDetalle.TabIndex = 9
        Me.bDetalle.Text = "VER DETALLE RECEPCIONES"
        Me.bDetalle.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 116
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(655, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "TIPO IVA"
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbTipoIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTipoIVA.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Location = New System.Drawing.Point(653, 41)
        Me.cbTipoIVA.Name = "cbTipoIVA"
        Me.cbTipoIVA.Size = New System.Drawing.Size(163, 25)
        Me.cbTipoIVA.TabIndex = 99
        '
        'lvIVA
        '
        Me.lvIVA.Text = "TIPO IVA"
        Me.lvIVA.Width = 112
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Proveedor)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.bVerAlbaran)
        Me.GroupBox1.Controls.Add(Me.dtpFechaRecepcion)
        Me.GroupBox1.Controls.Add(Me.cbAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.numAlbaran)
        Me.GroupBox1.Controls.Add(Me.numPedido)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.FechaPedido)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Observaciones)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Nota)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1143, 200)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS GENERALES"
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Observaciones.Location = New System.Drawing.Point(374, 113)
        Me.Observaciones.MaxLength = 250
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(293, 62)
        Me.Observaciones.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(267, 116)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 17)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "OBSERVACIONES"
        '
        'Nota
        '
        Me.Nota.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Nota.Location = New System.Drawing.Point(744, 116)
        Me.Nota.MaxLength = 200
        Me.Nota.Multiline = True
        Me.Nota.Name = "Nota"
        Me.Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Nota.Size = New System.Drawing.Size(377, 62)
        Me.Nota.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(673, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 38)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = "NOTA IMPRESA"
        '
        'RecepcionPedidoProv1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 823)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bRecepcion)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(Me.bDetalle)
        Me.Controls.Add(Me.bGuardarConcepto)
        Me.Controls.Add(Me.gbConceptos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecepcionPedidoProv1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECEPCIÓN PEDIDO PROVEEDOR"
        Me.gbConceptos.ResumeLayout(False)
        Me.gbConceptos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents lbMoneda3 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents bGuardarConcepto As System.Windows.Forms.Button
    Friend WithEvents Nombre As System.Windows.Forms.TextBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPendiente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaRecibido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAceptado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRecibido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents lvCantidadRecibida As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CantidadRecibida As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents codArticuloProv As System.Windows.Forms.TextBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lbUnidades1 As System.Windows.Forms.Label
    Friend WithEvents lbUnidades2 As System.Windows.Forms.Label
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents bRecepcion As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Estado As System.Windows.Forms.TextBox
    Friend WithEvents FechaPedido As System.Windows.Forms.TextBox
    Friend WithEvents Check As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvUnidadMedida As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lvAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVerAlbaran As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numAlbaran As System.Windows.Forms.TextBox
    Friend WithEvents bDetalle As System.Windows.Forms.Button
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents lvIVA As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Nota As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
