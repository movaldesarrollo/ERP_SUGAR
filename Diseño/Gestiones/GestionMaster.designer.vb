<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionMaster
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionMaster))
        Me.bSalir = New System.Windows.Forms.Button()
        Me.cbRetencion = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BBajar = New System.Windows.Forms.Button()
        Me.TxPorcentaje = New System.Windows.Forms.TextBox()
        Me.BSubir = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tbDomesticos2 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.numAlbaran = New System.Windows.Forms.TextBox()
        Me.numPedido = New System.Windows.Forms.TextBox()
        Me.numOferta = New System.Windows.Forms.TextBox()
        Me.bNuevoAño = New System.Windows.Forms.Button()
        Me.numProforma = New System.Windows.Forms.TextBox()
        Me.numReparacion = New System.Windows.Forms.TextBox()
        Me.numSerie2 = New System.Windows.Forms.TextBox()
        Me.numSerie = New System.Windows.Forms.TextBox()
        Me.numFactura = New System.Windows.Forms.TextBox()
        Me.cbAño = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.EquiposIndustriales = New System.Windows.Forms.TextBox()
        Me.EquiposDomesticos = New System.Windows.Forms.TextBox()
        Me.numPedidoProv = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbValorado = New System.Windows.Forms.ComboBox()
        Me.cbOpcion = New System.Windows.Forms.ComboBox()
        Me.cbIdioma = New System.Windows.Forms.ComboBox()
        Me.cbPortes = New System.Windows.Forms.ComboBox()
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox()
        Me.Descuento2 = New System.Windows.Forms.TextBox()
        Me.DiasAviso3 = New System.Windows.Forms.TextBox()
        Me.DiasAviso2 = New System.Windows.Forms.TextBox()
        Me.DiasAviso1 = New System.Windows.Forms.TextBox()
        Me.Descuento1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ProntoPago = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ckSSL = New System.Windows.Forms.CheckBox()
        Me.ckAutenticado = New System.Windows.Forms.CheckBox()
        Me.SMTPPassword = New System.Windows.Forms.TextBox()
        Me.SMTPUsuario = New System.Windows.Forms.TextBox()
        Me.bPrueba = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SMTPPuerto = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.SMTPServidor = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbRecambios = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(703, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 2
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'cbRetencion
        '
        Me.cbRetencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRetencion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRetencion.FormattingEnabled = True
        Me.cbRetencion.Location = New System.Drawing.Point(197, 147)
        Me.cbRetencion.Name = "cbRetencion"
        Me.cbRetencion.Size = New System.Drawing.Size(153, 25)
        Me.cbRetencion.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 618)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BBajar)
        Me.GroupBox5.Controls.Add(Me.TxPorcentaje)
        Me.GroupBox5.Controls.Add(Me.BSubir)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(18, 518)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(350, 94)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "CAMBIO MASIVO P.V.P"
        '
        'BBajar
        '
        Me.BBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BBajar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BBajar.Location = New System.Drawing.Point(234, 53)
        Me.BBajar.Name = "BBajar"
        Me.BBajar.Size = New System.Drawing.Size(100, 28)
        Me.BBajar.TabIndex = 9
        Me.BBajar.Text = "BAJAR"
        Me.BBajar.UseVisualStyleBackColor = True
        '
        'TxPorcentaje
        '
        Me.TxPorcentaje.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxPorcentaje.Location = New System.Drawing.Point(234, 24)
        Me.TxPorcentaje.Name = "TxPorcentaje"
        Me.TxPorcentaje.Size = New System.Drawing.Size(100, 23)
        Me.TxPorcentaje.TabIndex = 5
        Me.TxPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BSubir
        '
        Me.BSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSubir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BSubir.Location = New System.Drawing.Point(128, 53)
        Me.BSubir.Name = "BSubir"
        Me.BSubir.Size = New System.Drawing.Size(100, 28)
        Me.BSubir.TabIndex = 6
        Me.BSubir.Text = "SUBIR"
        Me.BSubir.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(14, 27)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(94, 17)
        Me.Label29.TabIndex = 8
        Me.Label29.Text = "PORCENTAJE "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tbRecambios)
        Me.GroupBox4.Controls.Add(Me.Label31)
        Me.GroupBox4.Controls.Add(Me.tbDomesticos2)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.numAlbaran)
        Me.GroupBox4.Controls.Add(Me.numPedido)
        Me.GroupBox4.Controls.Add(Me.numOferta)
        Me.GroupBox4.Controls.Add(Me.bNuevoAño)
        Me.GroupBox4.Controls.Add(Me.numProforma)
        Me.GroupBox4.Controls.Add(Me.numReparacion)
        Me.GroupBox4.Controls.Add(Me.numSerie2)
        Me.GroupBox4.Controls.Add(Me.numSerie)
        Me.GroupBox4.Controls.Add(Me.numFactura)
        Me.GroupBox4.Controls.Add(Me.cbAño)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.EquiposIndustriales)
        Me.GroupBox4.Controls.Add(Me.EquiposDomesticos)
        Me.GroupBox4.Controls.Add(Me.numPedidoProv)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(18, 22)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(350, 490)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DATOS ANUALIZADOS"
        '
        'tbDomesticos2
        '
        Me.tbDomesticos2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDomesticos2.Location = New System.Drawing.Point(234, 398)
        Me.tbDomesticos2.Name = "tbDomesticos2"
        Me.tbDomesticos2.Size = New System.Drawing.Size(100, 23)
        Me.tbDomesticos2.TabIndex = 12
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(13, 401)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(215, 17)
        Me.Label30.TabIndex = 13
        Me.Label30.Text = "EQUIPOS DOMÉSTICOS 2 POR DÍA"
        '
        'numAlbaran
        '
        Me.numAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAlbaran.Location = New System.Drawing.Point(234, 155)
        Me.numAlbaran.Name = "numAlbaran"
        Me.numAlbaran.Size = New System.Drawing.Size(100, 23)
        Me.numAlbaran.TabIndex = 4
        '
        'numPedido
        '
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.Location = New System.Drawing.Point(234, 124)
        Me.numPedido.Name = "numPedido"
        Me.numPedido.Size = New System.Drawing.Size(100, 23)
        Me.numPedido.TabIndex = 3
        '
        'numOferta
        '
        Me.numOferta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numOferta.Location = New System.Drawing.Point(234, 62)
        Me.numOferta.Name = "numOferta"
        Me.numOferta.Size = New System.Drawing.Size(100, 23)
        Me.numOferta.TabIndex = 1
        '
        'bNuevoAño
        '
        Me.bNuevoAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoAño.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bNuevoAño.Location = New System.Drawing.Point(234, 456)
        Me.bNuevoAño.Name = "bNuevoAño"
        Me.bNuevoAño.Size = New System.Drawing.Size(100, 28)
        Me.bNuevoAño.TabIndex = 13
        Me.bNuevoAño.Text = "NUEVO AÑO"
        Me.bNuevoAño.UseVisualStyleBackColor = True
        '
        'numProforma
        '
        Me.numProforma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numProforma.Location = New System.Drawing.Point(234, 93)
        Me.numProforma.Name = "numProforma"
        Me.numProforma.Size = New System.Drawing.Size(100, 23)
        Me.numProforma.TabIndex = 2
        '
        'numReparacion
        '
        Me.numReparacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numReparacion.Location = New System.Drawing.Point(234, 310)
        Me.numReparacion.Name = "numReparacion"
        Me.numReparacion.Size = New System.Drawing.Size(100, 23)
        Me.numReparacion.TabIndex = 9
        '
        'numSerie2
        '
        Me.numSerie2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie2.Location = New System.Drawing.Point(234, 279)
        Me.numSerie2.Name = "numSerie2"
        Me.numSerie2.Size = New System.Drawing.Size(100, 23)
        Me.numSerie2.TabIndex = 8
        '
        'numSerie
        '
        Me.numSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie.Location = New System.Drawing.Point(234, 248)
        Me.numSerie.Name = "numSerie"
        Me.numSerie.Size = New System.Drawing.Size(100, 23)
        Me.numSerie.TabIndex = 7
        '
        'numFactura
        '
        Me.numFactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numFactura.Location = New System.Drawing.Point(234, 186)
        Me.numFactura.Name = "numFactura"
        Me.numFactura.Size = New System.Drawing.Size(100, 23)
        Me.numFactura.TabIndex = 5
        '
        'cbAño
        '
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(234, 28)
        Me.cbAño.Name = "cbAño"
        Me.cbAño.Size = New System.Drawing.Size(100, 27)
        Me.cbAño.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(13, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(138, 17)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "PRIMERA PROFORMA"
        '
        'EquiposIndustriales
        '
        Me.EquiposIndustriales.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EquiposIndustriales.Location = New System.Drawing.Point(234, 369)
        Me.EquiposIndustriales.Name = "EquiposIndustriales"
        Me.EquiposIndustriales.Size = New System.Drawing.Size(100, 23)
        Me.EquiposIndustriales.TabIndex = 11
        '
        'EquiposDomesticos
        '
        Me.EquiposDomesticos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EquiposDomesticos.Location = New System.Drawing.Point(234, 339)
        Me.EquiposDomesticos.Name = "EquiposDomesticos"
        Me.EquiposDomesticos.Size = New System.Drawing.Size(100, 23)
        Me.EquiposDomesticos.TabIndex = 10
        '
        'numPedidoProv
        '
        Me.numPedidoProv.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedidoProv.Location = New System.Drawing.Point(234, 217)
        Me.numPedidoProv.Name = "numPedidoProv"
        Me.numPedidoProv.Size = New System.Drawing.Size(100, 23)
        Me.numPedidoProv.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(13, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 17)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "PRIMERA OFERTA"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(13, 313)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(178, 17)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "PRIMER NÚM. REPARACIÓN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(13, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "PRIMER PEDIDO"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(13, 282)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(195, 17)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "PRIMER NÚM. SERIE REPUESTOS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(13, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "PRIMER ALBARÁN"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(13, 251)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(168, 17)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "PRIMER NÚMERO DE SERIE"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(13, 374)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(204, 17)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "EQUIPOS INDUSTRIALES POR DÍA"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(13, 189)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 17)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "PRIMERA FACTURA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(13, 341)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(204, 17)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "EQUIPOS DOMÉSTICOS POR DÍA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(13, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 21)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "AÑO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(13, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(189, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "PRIMER PEDIDO PROVEEDOR"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbValorado)
        Me.GroupBox3.Controls.Add(Me.cbOpcion)
        Me.GroupBox3.Controls.Add(Me.cbIdioma)
        Me.GroupBox3.Controls.Add(Me.cbPortes)
        Me.GroupBox3.Controls.Add(Me.cbRetencion)
        Me.GroupBox3.Controls.Add(Me.cbTipoIVA)
        Me.GroupBox3.Controls.Add(Me.Descuento2)
        Me.GroupBox3.Controls.Add(Me.DiasAviso3)
        Me.GroupBox3.Controls.Add(Me.DiasAviso2)
        Me.GroupBox3.Controls.Add(Me.DiasAviso1)
        Me.GroupBox3.Controls.Add(Me.Descuento1)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ProntoPago)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(390, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(380, 331)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DATOS POR DEFECTO"
        '
        'cbValorado
        '
        Me.cbValorado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbValorado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValorado.FormattingEnabled = True
        Me.cbValorado.Location = New System.Drawing.Point(354, 214)
        Me.cbValorado.Name = "cbValorado"
        Me.cbValorado.Size = New System.Drawing.Size(24, 25)
        Me.cbValorado.TabIndex = 8
        Me.cbValorado.Visible = False
        '
        'cbOpcion
        '
        Me.cbOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOpcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOpcion.FormattingEnabled = True
        Me.cbOpcion.Location = New System.Drawing.Point(197, 243)
        Me.cbOpcion.Name = "cbOpcion"
        Me.cbOpcion.Size = New System.Drawing.Size(153, 25)
        Me.cbOpcion.TabIndex = 7
        '
        'cbIdioma
        '
        Me.cbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIdioma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIdioma.FormattingEnabled = True
        Me.cbIdioma.Location = New System.Drawing.Point(197, 211)
        Me.cbIdioma.Name = "cbIdioma"
        Me.cbIdioma.Size = New System.Drawing.Size(153, 25)
        Me.cbIdioma.TabIndex = 6
        '
        'cbPortes
        '
        Me.cbPortes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPortes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPortes.FormattingEnabled = True
        Me.cbPortes.Location = New System.Drawing.Point(197, 179)
        Me.cbPortes.Name = "cbPortes"
        Me.cbPortes.Size = New System.Drawing.Size(153, 25)
        Me.cbPortes.TabIndex = 5
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Location = New System.Drawing.Point(197, 115)
        Me.cbTipoIVA.Name = "cbTipoIVA"
        Me.cbTipoIVA.Size = New System.Drawing.Size(153, 25)
        Me.cbTipoIVA.TabIndex = 3
        '
        'Descuento2
        '
        Me.Descuento2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento2.Location = New System.Drawing.Point(244, 86)
        Me.Descuento2.Name = "Descuento2"
        Me.Descuento2.Size = New System.Drawing.Size(82, 23)
        Me.Descuento2.TabIndex = 2
        '
        'DiasAviso3
        '
        Me.DiasAviso3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasAviso3.Location = New System.Drawing.Point(311, 287)
        Me.DiasAviso3.Name = "DiasAviso3"
        Me.DiasAviso3.Size = New System.Drawing.Size(31, 23)
        Me.DiasAviso3.TabIndex = 11
        '
        'DiasAviso2
        '
        Me.DiasAviso2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DiasAviso2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasAviso2.Location = New System.Drawing.Point(261, 287)
        Me.DiasAviso2.Name = "DiasAviso2"
        Me.DiasAviso2.Size = New System.Drawing.Size(31, 23)
        Me.DiasAviso2.TabIndex = 10
        '
        'DiasAviso1
        '
        Me.DiasAviso1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.DiasAviso1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiasAviso1.Location = New System.Drawing.Point(214, 287)
        Me.DiasAviso1.Name = "DiasAviso1"
        Me.DiasAviso1.Size = New System.Drawing.Size(31, 23)
        Me.DiasAviso1.TabIndex = 9
        '
        'Descuento1
        '
        Me.Descuento1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento1.Location = New System.Drawing.Point(244, 58)
        Me.Descuento1.Name = "Descuento1"
        Me.Descuento1.Size = New System.Drawing.Size(82, 23)
        Me.Descuento1.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(23, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 17)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "DESCUENTO INDUSTRIAL"
        '
        'ProntoPago
        '
        Me.ProntoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProntoPago.Location = New System.Drawing.Point(244, 30)
        Me.ProntoPago.Name = "ProntoPago"
        Me.ProntoPago.Size = New System.Drawing.Size(82, 23)
        Me.ProntoPago.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(23, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(162, 17)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "DESCUENTO DOMÉSTICO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(23, 290)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(185, 17)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "DIAS AVISO FECHA ENTREGA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(23, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "PRONTO PAGO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(23, 247)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 17)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "OPCIÓN ARTÍCULO BASE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(330, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(23, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 17)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "IDIOMA DIRECCIÓN"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(330, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 17)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(23, 183)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 17)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "PORTES"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(330, 62)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(18, 17)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "%"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(23, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "TIPO RETENCIÓN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(23, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "TIPO IVA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ckSSL)
        Me.GroupBox2.Controls.Add(Me.ckAutenticado)
        Me.GroupBox2.Controls.Add(Me.SMTPPassword)
        Me.GroupBox2.Controls.Add(Me.SMTPUsuario)
        Me.GroupBox2.Controls.Add(Me.bPrueba)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.SMTPPuerto)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.SMTPServidor)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(390, 359)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 253)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS CORREO"
        '
        'ckSSL
        '
        Me.ckSSL.AutoSize = True
        Me.ckSSL.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSSL.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSSL.Location = New System.Drawing.Point(297, 57)
        Me.ckSSL.Name = "ckSSL"
        Me.ckSSL.Size = New System.Drawing.Size(45, 21)
        Me.ckSSL.TabIndex = 3
        Me.ckSSL.Text = "SSL"
        Me.ckSSL.UseVisualStyleBackColor = True
        '
        'ckAutenticado
        '
        Me.ckAutenticado.AutoSize = True
        Me.ckAutenticado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckAutenticado.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckAutenticado.Location = New System.Drawing.Point(181, 57)
        Me.ckAutenticado.Name = "ckAutenticado"
        Me.ckAutenticado.Size = New System.Drawing.Size(115, 21)
        Me.ckAutenticado.TabIndex = 2
        Me.ckAutenticado.Text = "AUTENTICADO"
        Me.ckAutenticado.UseVisualStyleBackColor = True
        '
        'SMTPPassword
        '
        Me.SMTPPassword.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SMTPPassword.Location = New System.Drawing.Point(124, 114)
        Me.SMTPPassword.Name = "SMTPPassword"
        Me.SMTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.SMTPPassword.Size = New System.Drawing.Size(219, 23)
        Me.SMTPPassword.TabIndex = 5
        '
        'SMTPUsuario
        '
        Me.SMTPUsuario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SMTPUsuario.Location = New System.Drawing.Point(124, 84)
        Me.SMTPUsuario.Name = "SMTPUsuario"
        Me.SMTPUsuario.Size = New System.Drawing.Size(219, 23)
        Me.SMTPUsuario.TabIndex = 4
        '
        'bPrueba
        '
        Me.bPrueba.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPrueba.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bPrueba.Location = New System.Drawing.Point(257, 190)
        Me.bPrueba.Name = "bPrueba"
        Me.bPrueba.Size = New System.Drawing.Size(85, 50)
        Me.bPrueba.TabIndex = 6
        Me.bPrueba.Text = "PRUEBA"
        Me.bPrueba.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(19, 117)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(94, 17)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "CONTRASEÑA"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(19, 87)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(61, 17)
        Me.Label27.TabIndex = 8
        Me.Label27.Text = "USUARIO"
        '
        'SMTPPuerto
        '
        Me.SMTPPuerto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SMTPPuerto.Location = New System.Drawing.Point(124, 54)
        Me.SMTPPuerto.Name = "SMTPPuerto"
        Me.SMTPPuerto.Size = New System.Drawing.Size(49, 23)
        Me.SMTPPuerto.TabIndex = 1
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(19, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 17)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "PUERTO SMTP"
        '
        'SMTPServidor
        '
        Me.SMTPServidor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SMTPServidor.Location = New System.Drawing.Point(124, 24)
        Me.SMTPServidor.Name = "SMTPServidor"
        Me.SMTPServidor.Size = New System.Drawing.Size(219, 23)
        Me.SMTPServidor.TabIndex = 0
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(19, 27)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 17)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "SERVIDOR SMTP"
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bGuardar.Location = New System.Drawing.Point(612, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 1
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'tbRecambios
        '
        Me.tbRecambios.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRecambios.Location = New System.Drawing.Point(234, 427)
        Me.tbRecambios.Name = "tbRecambios"
        Me.tbRecambios.Size = New System.Drawing.Size(100, 23)
        Me.tbRecambios.TabIndex = 14
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(13, 430)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(138, 17)
        Me.Label31.TabIndex = 15
        Me.Label31.Text = "RECAMBIOS POR DÍA"
        '
        'GestionMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 706)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DATOS INICIALES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents cbRetencion As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents Descuento2 As System.Windows.Forms.TextBox
    Friend WithEvents Descuento1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ProntoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbOpcion As System.Windows.Forms.ComboBox
    Friend WithEvents cbIdioma As System.Windows.Forms.ComboBox
    Friend WithEvents cbPortes As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents numAlbaran As System.Windows.Forms.TextBox
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents numOferta As System.Windows.Forms.TextBox
    Friend WithEvents bNuevoAño As System.Windows.Forms.Button
    Friend WithEvents numProforma As System.Windows.Forms.TextBox
    Friend WithEvents numFactura As System.Windows.Forms.TextBox
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents numPedidoProv As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ckSSL As System.Windows.Forms.CheckBox
    Friend WithEvents ckAutenticado As System.Windows.Forms.CheckBox
    Friend WithEvents SMTPPassword As System.Windows.Forms.TextBox
    Friend WithEvents SMTPUsuario As System.Windows.Forms.TextBox
    Friend WithEvents bPrueba As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents SMTPPuerto As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents SMTPServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents EquiposIndustriales As System.Windows.Forms.TextBox
    Friend WithEvents EquiposDomesticos As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbValorado As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents numSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents numSerie2 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents numReparacion As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DiasAviso3 As System.Windows.Forms.TextBox
    Friend WithEvents DiasAviso2 As System.Windows.Forms.TextBox
    Friend WithEvents DiasAviso1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents BBajar As Button
    Friend WithEvents TxPorcentaje As TextBox
    Friend WithEvents BSubir As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents tbDomesticos2 As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents tbRecambios As TextBox
    Friend WithEvents Label31 As Label
End Class
