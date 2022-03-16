<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionAlbaranAProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionAlbaranAProv))
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Bultos = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.PesoBruto = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Volumen = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Medidas = New System.Windows.Forms.TextBox
        Me.PesoNeto = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.lbMoneda1 = New System.Windows.Forms.Label
        Me.gbConceptos = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bTiposArticulo = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cbSubFamilia = New System.Windows.Forms.ComboBox
        Me.cbFamilia = New System.Windows.Forms.ComboBox
        Me.lbMonedaS = New System.Windows.Forms.Label
        Me.lbMonedaN = New System.Windows.Forms.Label
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvck = New System.Windows.Forms.ColumnHeader
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloCLi = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvPVP = New System.Windows.Forms.ColumnHeader
        Me.lvDescuento = New System.Windows.Forms.ColumnHeader
        Me.lvPrecioNeto = New System.Windows.Forms.ColumnHeader
        Me.lvSubTotal = New System.Windows.Forms.ColumnHeader
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.bBuscarArticuloC = New System.Windows.Forms.Button
        Me.subTotal = New System.Windows.Forms.TextBox
        Me.bArticuloProveedor = New System.Windows.Forms.Button
        Me.PrecioNeto = New System.Windows.Forms.TextBox
        Me.numsSerie = New System.Windows.Forms.TextBox
        Me.codArticuloProv = New System.Windows.Forms.TextBox
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.bVerArticuloC = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.cbPersona = New System.Windows.Forms.ComboBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFechaPrevista = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbNumDoc = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.numDoc = New System.Windows.Forms.TextBox
        Me.RefCliente2 = New System.Windows.Forms.TextBox
        Me.RefCliente = New System.Windows.Forms.TextBox
        Me.bMoneda = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbmonedaT = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.cbPortes = New System.Windows.Forms.ComboBox
        Me.cbTransporte = New System.Windows.Forms.ComboBox
        Me.cbValorado = New System.Windows.Forms.ComboBox
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.cbSolicitadoVia = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.PrecioTransporte = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Nota = New System.Windows.Forms.TextBox
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbContacto = New System.Windows.Forms.ComboBox
        Me.cbDireccion = New System.Windows.Forms.ComboBox
        Me.cbCodProveedor = New System.Windows.Forms.ComboBox
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.bVerProveedor = New System.Windows.Forms.Button
        Me.bBuscarProveedor = New System.Windows.Forms.Button
        Me.beMail = New System.Windows.Forms.Button
        Me.bPDF = New System.Windows.Forms.Button
        Me.Total = New System.Windows.Forms.TextBox
        Me.bSubirC = New System.Windows.Forms.Button
        Me.bBajarC = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbConceptos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSubir
        '
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = CType(resources.GetObject("bSubir.Image"), System.Drawing.Image)
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(459, 23)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(90, 22)
        Me.bSubir.TabIndex = 13
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = CType(resources.GetObject("bBajar.Image"), System.Drawing.Image)
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(459, 51)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(90, 22)
        Me.bBajar.TabIndex = 14
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(758, 23)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 50)
        Me.bImprimir.TabIndex = 17
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1146, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 22
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(659, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(90, 50)
        Me.bNuevo.TabIndex = 16
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(560, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(90, 50)
        Me.bGuardar.TabIndex = 15
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(1049, 23)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(88, 50)
        Me.bBorrar.TabIndex = 21
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.lbMoneda1)
        Me.GroupBox1.Controls.Add(Me.gbConceptos)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.bSubir)
        Me.GroupBox1.Controls.Add(Me.beMail)
        Me.GroupBox1.Controls.Add(Me.bBorrar)
        Me.GroupBox1.Controls.Add(Me.bBajar)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.bPDF)
        Me.GroupBox1.Controls.Add(Me.bImprimir)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.Total)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 910)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Bultos)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.PesoBruto)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Volumen)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Medidas)
        Me.GroupBox3.Controls.Add(Me.PesoNeto)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Label48)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 314)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1243, 64)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DATOS DE TRANSPORTE"
        '
        'Bultos
        '
        Me.Bultos.BackColor = System.Drawing.SystemColors.Window
        Me.Bultos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bultos.Location = New System.Drawing.Point(1138, 25)
        Me.Bultos.MaxLength = 5
        Me.Bultos.Name = "Bultos"
        Me.Bultos.Size = New System.Drawing.Size(90, 23)
        Me.Bultos.TabIndex = 4
        Me.Bultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(468, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 17)
        Me.Label17.TabIndex = 188
        Me.Label17.Text = "VOLUMEN"
        '
        'PesoBruto
        '
        Me.PesoBruto.BackColor = System.Drawing.SystemColors.Window
        Me.PesoBruto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PesoBruto.Location = New System.Drawing.Point(946, 25)
        Me.PesoBruto.MaxLength = 15
        Me.PesoBruto.Name = "PesoBruto"
        Me.PesoBruto.Size = New System.Drawing.Size(80, 23)
        Me.PesoBruto.TabIndex = 3
        Me.PesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(665, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 17)
        Me.Label15.TabIndex = 188
        Me.Label15.Text = "PESO NETO"
        '
        'Volumen
        '
        Me.Volumen.BackColor = System.Drawing.SystemColors.Window
        Me.Volumen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Volumen.Location = New System.Drawing.Point(542, 25)
        Me.Volumen.MaxLength = 15
        Me.Volumen.Name = "Volumen"
        Me.Volumen.Size = New System.Drawing.Size(80, 23)
        Me.Volumen.TabIndex = 1
        Me.Volumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(862, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 17)
        Me.Label14.TabIndex = 188
        Me.Label14.Text = "PESO BRUTO"
        '
        'Medidas
        '
        Me.Medidas.BackColor = System.Drawing.SystemColors.Window
        Me.Medidas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Medidas.Location = New System.Drawing.Point(89, 25)
        Me.Medidas.MaxLength = 50
        Me.Medidas.Name = "Medidas"
        Me.Medidas.Size = New System.Drawing.Size(331, 23)
        Me.Medidas.TabIndex = 0
        Me.Medidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PesoNeto
        '
        Me.PesoNeto.BackColor = System.Drawing.SystemColors.Window
        Me.PesoNeto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PesoNeto.Location = New System.Drawing.Point(744, 25)
        Me.PesoNeto.MaxLength = 15
        Me.PesoNeto.Name = "PesoNeto"
        Me.PesoNeto.Size = New System.Drawing.Size(80, 23)
        Me.PesoNeto.TabIndex = 2
        Me.PesoNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(1030, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 17)
        Me.Label11.TabIndex = 147
        Me.Label11.Text = "KG"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(829, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(27, 17)
        Me.Label18.TabIndex = 147
        Me.Label18.Text = "KG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1075, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "BULTOS"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(624, 28)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(21, 17)
        Me.Label30.TabIndex = 147
        Me.Label30.Text = "m"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label48.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(14, 28)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(64, 17)
        Me.Label48.TabIndex = 187
        Me.Label48.Text = "MEDIDAS"
        '
        'Label32
        '
        Me.Label32.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(642, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(12, 13)
        Me.Label32.TabIndex = 147
        Me.Label32.Text = "3"
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(1067, 877)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(55, 19)
        Me.Label42.TabIndex = 185
        Me.Label42.Text = "TOTAL"
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(238, 45)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(127, 26)
        Me.cbEstado.TabIndex = 12
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(169, 49)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(65, 18)
        Me.Label57.TabIndex = 115
        Me.Label57.Text = "ESTADO"
        '
        'lbMoneda1
        '
        Me.lbMoneda1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda1.AutoSize = True
        Me.lbMoneda1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda1.Location = New System.Drawing.Point(1225, 877)
        Me.lbMoneda1.Name = "lbMoneda1"
        Me.lbMoneda1.Size = New System.Drawing.Size(18, 19)
        Me.lbMoneda1.TabIndex = 184
        Me.lbMoneda1.Text = "€"
        '
        'gbConceptos
        '
        Me.gbConceptos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbConceptos.Controls.Add(Me.bSubirC)
        Me.gbConceptos.Controls.Add(Me.Label16)
        Me.gbConceptos.Controls.Add(Me.bBajarC)
        Me.gbConceptos.Controls.Add(Me.Label21)
        Me.gbConceptos.Controls.Add(Me.Label5)
        Me.gbConceptos.Controls.Add(Me.ckSeleccion)
        Me.gbConceptos.Controls.Add(Me.bLimpiar)
        Me.gbConceptos.Controls.Add(Me.bTiposArticulo)
        Me.gbConceptos.Controls.Add(Me.Label25)
        Me.gbConceptos.Controls.Add(Me.Label39)
        Me.gbConceptos.Controls.Add(Me.Label23)
        Me.gbConceptos.Controls.Add(Me.cbSubFamilia)
        Me.gbConceptos.Controls.Add(Me.cbFamilia)
        Me.gbConceptos.Controls.Add(Me.lbMonedaS)
        Me.gbConceptos.Controls.Add(Me.lbMonedaN)
        Me.gbConceptos.Controls.Add(Me.lbUnidad)
        Me.gbConceptos.Controls.Add(Me.lvConceptos)
        Me.gbConceptos.Controls.Add(Me.Label38)
        Me.gbConceptos.Controls.Add(Me.Label27)
        Me.gbConceptos.Controls.Add(Me.Label20)
        Me.gbConceptos.Controls.Add(Me.cbArticulo)
        Me.gbConceptos.Controls.Add(Me.cbCodArticulo)
        Me.gbConceptos.Controls.Add(Me.bBuscarArticuloC)
        Me.gbConceptos.Controls.Add(Me.subTotal)
        Me.gbConceptos.Controls.Add(Me.bArticuloProveedor)
        Me.gbConceptos.Controls.Add(Me.PrecioNeto)
        Me.gbConceptos.Controls.Add(Me.numsSerie)
        Me.gbConceptos.Controls.Add(Me.codArticuloProv)
        Me.gbConceptos.Controls.Add(Me.Cantidad)
        Me.gbConceptos.Controls.Add(Me.bVerArticuloC)
        Me.gbConceptos.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConceptos.Location = New System.Drawing.Point(12, 384)
        Me.gbConceptos.Name = "gbConceptos"
        Me.gbConceptos.Size = New System.Drawing.Size(1243, 486)
        Me.gbConceptos.TabIndex = 2
        Me.gbConceptos.TabStop = False
        Me.gbConceptos.Text = "CONCEPTOS"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(9, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 17)
        Me.Label16.TabIndex = 187
        Me.Label16.Text = "SUBFAMILIA"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(9, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 17)
        Me.Label21.TabIndex = 186
        Me.Label21.Text = "FAMILIA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(490, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 17)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "COD.PROVEEDOR"
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(13, 115)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 16
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = CType(resources.GetObject("bLimpiar.Image"), System.Drawing.Image)
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1201, 22)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 14
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bTiposArticulo
        '
        Me.bTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposArticulo.Location = New System.Drawing.Point(260, 22)
        Me.bTiposArticulo.Name = "bTiposArticulo"
        Me.bTiposArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bTiposArticulo.TabIndex = 1
        Me.bTiposArticulo.Text = "...."
        Me.bTiposArticulo.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(9, 83)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 17)
        Me.Label25.TabIndex = 180
        Me.Label25.Text = "OBSERV."
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(290, 55)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 17)
        Me.Label39.TabIndex = 179
        Me.Label39.Text = "ARTÍCULO"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(290, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 17)
        Me.Label23.TabIndex = 179
        Me.Label23.Text = "CÓDIGO"
        '
        'cbSubFamilia
        '
        Me.cbSubFamilia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubFamilia.FormattingEnabled = True
        Me.cbSubFamilia.Location = New System.Drawing.Point(89, 51)
        Me.cbSubFamilia.Name = "cbSubFamilia"
        Me.cbSubFamilia.Size = New System.Drawing.Size(157, 25)
        Me.cbSubFamilia.TabIndex = 2
        '
        'cbFamilia
        '
        Me.cbFamilia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFamilia.FormattingEnabled = True
        Me.cbFamilia.Location = New System.Drawing.Point(89, 22)
        Me.cbFamilia.Name = "cbFamilia"
        Me.cbFamilia.Size = New System.Drawing.Size(157, 25)
        Me.cbFamilia.TabIndex = 0
        '
        'lbMonedaS
        '
        Me.lbMonedaS.AutoSize = True
        Me.lbMonedaS.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMonedaS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaS.Location = New System.Drawing.Point(1220, 55)
        Me.lbMonedaS.Name = "lbMonedaS"
        Me.lbMonedaS.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaS.TabIndex = 174
        Me.lbMonedaS.Text = "€"
        '
        'lbMonedaN
        '
        Me.lbMonedaN.AutoSize = True
        Me.lbMonedaN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMonedaN.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaN.Location = New System.Drawing.Point(1065, 55)
        Me.lbMonedaN.Name = "lbMonedaN"
        Me.lbMonedaN.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaN.TabIndex = 174
        Me.lbMonedaN.Text = "€"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(930, 55)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 174
        Me.lbUnidad.Text = "U"
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvck, Me.lvidConcepto, Me.lvcodArticulo, Me.lvcodArticuloCLi, Me.lvArticulo, Me.lvCantidad, Me.lvPVP, Me.lvDescuento, Me.lvPrecioNeto, Me.lvSubTotal})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(6, 108)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(1227, 366)
        Me.lvConceptos.TabIndex = 17
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvck
        '
        Me.lvck.Text = ""
        Me.lvck.Width = 22
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 118
        '
        'lvcodArticuloCLi
        '
        Me.lvcodArticuloCLi.Text = "ARTÍCULO/CLI"
        Me.lvcodArticuloCLi.Width = 117
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTICULO"
        Me.lvArticulo.Width = 633
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 80
        '
        'lvPVP
        '
        Me.lvPVP.Text = "PVP"
        Me.lvPVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPVP.Width = 0
        '
        'lvDescuento
        '
        Me.lvDescuento.Text = "DESCUENTO"
        Me.lvDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvDescuento.Width = 0
        '
        'lvPrecioNeto
        '
        Me.lvPrecioNeto.Text = "PRECIO NETO"
        Me.lvPrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecioNeto.Width = 102
        '
        'lvSubTotal
        '
        Me.lvSubTotal.Text = "SUBTOTAL"
        Me.lvSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvSubTotal.Width = 105
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(1085, 55)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 17)
        Me.Label38.TabIndex = 147
        Me.Label38.Text = "SUBTOTAL"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(952, 55)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 17)
        Me.Label27.TabIndex = 147
        Me.Label27.Text = "NETO"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(807, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 147
        Me.Label20.Text = "CANTIDAD"
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownWidth = 447
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(364, 51)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(369, 25)
        Me.cbArticulo.Sorted = True
        Me.cbArticulo.TabIndex = 5
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(364, 22)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(124, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 3
        '
        'bBuscarArticuloC
        '
        Me.bBuscarArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticuloC.Image = CType(resources.GetObject("bBuscarArticuloC.Image"), System.Drawing.Image)
        Me.bBuscarArticuloC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticuloC.Location = New System.Drawing.Point(747, 51)
        Me.bBuscarArticuloC.Name = "bBuscarArticuloC"
        Me.bBuscarArticuloC.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticuloC.TabIndex = 7
        Me.bBuscarArticuloC.UseVisualStyleBackColor = True
        '
        'subTotal
        '
        Me.subTotal.BackColor = System.Drawing.SystemColors.Window
        Me.subTotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.subTotal.Location = New System.Drawing.Point(1149, 52)
        Me.subTotal.MaxLength = 15
        Me.subTotal.Name = "subTotal"
        Me.subTotal.ReadOnly = True
        Me.subTotal.Size = New System.Drawing.Size(70, 23)
        Me.subTotal.TabIndex = 11
        Me.subTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bArticuloProveedor
        '
        Me.bArticuloProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bArticuloProveedor.Image = CType(resources.GetObject("bArticuloProveedor.Image"), System.Drawing.Image)
        Me.bArticuloProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bArticuloProveedor.Location = New System.Drawing.Point(747, 22)
        Me.bArticuloProveedor.Name = "bArticuloProveedor"
        Me.bArticuloProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bArticuloProveedor.TabIndex = 6
        Me.bArticuloProveedor.UseVisualStyleBackColor = True
        '
        'PrecioNeto
        '
        Me.PrecioNeto.BackColor = System.Drawing.SystemColors.Window
        Me.PrecioNeto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioNeto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioNeto.Location = New System.Drawing.Point(994, 52)
        Me.PrecioNeto.MaxLength = 15
        Me.PrecioNeto.Name = "PrecioNeto"
        Me.PrecioNeto.Size = New System.Drawing.Size(70, 23)
        Me.PrecioNeto.TabIndex = 10
        Me.PrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numsSerie
        '
        Me.numsSerie.BackColor = System.Drawing.SystemColors.Window
        Me.numsSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numsSerie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numsSerie.Location = New System.Drawing.Point(89, 80)
        Me.numsSerie.MaxLength = 300
        Me.numsSerie.Name = "numsSerie"
        Me.numsSerie.Size = New System.Drawing.Size(1130, 23)
        Me.numsSerie.TabIndex = 15
        Me.numsSerie.TabStop = False
        '
        'codArticuloProv
        '
        Me.codArticuloProv.BackColor = System.Drawing.SystemColors.Window
        Me.codArticuloProv.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticuloProv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.codArticuloProv.Location = New System.Drawing.Point(603, 23)
        Me.codArticuloProv.MaxLength = 30
        Me.codArticuloProv.Name = "codArticuloProv"
        Me.codArticuloProv.Size = New System.Drawing.Size(130, 23)
        Me.codArticuloProv.TabIndex = 4
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Location = New System.Drawing.Point(883, 52)
        Me.Cantidad.MaxLength = 15
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(45, 23)
        Me.Cantidad.TabIndex = 9
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bVerArticuloC
        '
        Me.bVerArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloC.Image = CType(resources.GetObject("bVerArticuloC.Image"), System.Drawing.Image)
        Me.bVerArticuloC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloC.Location = New System.Drawing.Point(777, 51)
        Me.bVerArticuloC.Name = "bVerArticuloC"
        Me.bVerArticuloC.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloC.TabIndex = 8
        Me.bVerArticuloC.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Controls.Add(Me.cbPersona)
        Me.GroupBox2.Controls.Add(Me.Label47)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.bMoneda)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lbmonedaT)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.cbPortes)
        Me.GroupBox2.Controls.Add(Me.cbTransporte)
        Me.GroupBox2.Controls.Add(Me.cbValorado)
        Me.GroupBox2.Controls.Add(Me.cbMoneda)
        Me.GroupBox2.Controls.Add(Me.cbSolicitadoVia)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.PrecioTransporte)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Nota)
        Me.GroupBox2.Controls.Add(Me.Observaciones)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbContacto)
        Me.GroupBox2.Controls.Add(Me.cbDireccion)
        Me.GroupBox2.Controls.Add(Me.cbCodProveedor)
        Me.GroupBox2.Controls.Add(Me.cbProveedor)
        Me.GroupBox2.Controls.Add(Me.bVerProveedor)
        Me.GroupBox2.Controls.Add(Me.bBuscarProveedor)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1248, 230)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS GENERALES"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label46.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(246, 97)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(95, 17)
        Me.Label46.TabIndex = 192
        Me.Label46.Text = "CREADO POR"
        '
        'cbPersona
        '
        Me.cbPersona.DropDownWidth = 225
        Me.cbPersona.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPersona.FormattingEnabled = True
        Me.cbPersona.Location = New System.Drawing.Point(364, 94)
        Me.cbPersona.Name = "cbPersona"
        Me.cbPersona.Size = New System.Drawing.Size(180, 25)
        Me.cbPersona.TabIndex = 7
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label47.Location = New System.Drawing.Point(748, 158)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(63, 34)
        Me.Label47.TabIndex = 148
        Me.Label47.Text = "NOTA IMPRESA"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.dtpFechaPrevista)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 152)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(241, 65)
        Me.GroupBox5.TabIndex = 28
        Me.GroupBox5.TabStop = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(133, 14)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(90, 23)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(9, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 17)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "FECHA ALBARÁN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(9, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "FECHA SALIDA"
        '
        'dtpFechaPrevista
        '
        Me.dtpFechaPrevista.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevista.Location = New System.Drawing.Point(133, 40)
        Me.dtpFechaPrevista.Name = "dtpFechaPrevista"
        Me.dtpFechaPrevista.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevista.TabIndex = 1
        Me.dtpFechaPrevista.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbNumDoc)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.numDoc)
        Me.GroupBox4.Controls.Add(Me.RefCliente2)
        Me.GroupBox4.Controls.Add(Me.RefCliente)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 15)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(241, 133)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        '
        'lbNumDoc
        '
        Me.lbNumDoc.AutoSize = True
        Me.lbNumDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc.Location = New System.Drawing.Point(8, 17)
        Me.lbNumDoc.Name = "lbNumDoc"
        Me.lbNumDoc.Size = New System.Drawing.Size(104, 19)
        Me.lbNumDoc.TabIndex = 115
        Me.lbNumDoc.Text = "Nº ALBARÁN"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(8, 85)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(105, 17)
        Me.Label45.TabIndex = 115
        Me.Label45.Text = "Nº EXPEDICIÓN"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(8, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 17)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "REF. PROVEEDOR"
        '
        'numDoc
        '
        Me.numDoc.BackColor = System.Drawing.SystemColors.Window
        Me.numDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.numDoc.Location = New System.Drawing.Point(134, 14)
        Me.numDoc.MaxLength = 15
        Me.numDoc.Name = "numDoc"
        Me.numDoc.ReadOnly = True
        Me.numDoc.Size = New System.Drawing.Size(90, 27)
        Me.numDoc.TabIndex = 0
        Me.numDoc.TabStop = False
        Me.numDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RefCliente2
        '
        Me.RefCliente2.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente2.Location = New System.Drawing.Point(134, 82)
        Me.RefCliente2.MaxLength = 50
        Me.RefCliente2.Name = "RefCliente2"
        Me.RefCliente2.Size = New System.Drawing.Size(90, 23)
        Me.RefCliente2.TabIndex = 2
        Me.RefCliente2.TabStop = False
        Me.RefCliente2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RefCliente
        '
        Me.RefCliente.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente.Location = New System.Drawing.Point(134, 50)
        Me.RefCliente.MaxLength = 20
        Me.RefCliente.Name = "RefCliente"
        Me.RefCliente.Size = New System.Drawing.Size(90, 23)
        Me.RefCliente.TabIndex = 1
        Me.RefCliente.TabStop = False
        Me.RefCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bMoneda
        '
        Me.bMoneda.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMoneda.Location = New System.Drawing.Point(558, 128)
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.Size = New System.Drawing.Size(27, 25)
        Me.bMoneda.TabIndex = 10
        Me.bMoneda.Text = "...."
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(907, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 17)
        Me.Label19.TabIndex = 146
        Me.Label19.Text = "DOCUMENTO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(1095, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "PRECIO"
        '
        'lbmonedaT
        '
        Me.lbmonedaT.AutoSize = True
        Me.lbmonedaT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmonedaT.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbmonedaT.Location = New System.Drawing.Point(1217, 131)
        Me.lbmonedaT.Name = "lbmonedaT"
        Me.lbmonedaT.Size = New System.Drawing.Size(15, 17)
        Me.lbmonedaT.TabIndex = 174
        Me.lbmonedaT.Text = "€"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(723, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 17)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "TRANSPORTE"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(250, 133)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 17)
        Me.Label29.TabIndex = 147
        Me.Label29.Text = "MONEDA"
        '
        'cbPortes
        '
        Me.cbPortes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPortes.FormattingEnabled = True
        Me.cbPortes.Location = New System.Drawing.Point(1003, 128)
        Me.cbPortes.Name = "cbPortes"
        Me.cbPortes.Size = New System.Drawing.Size(88, 25)
        Me.cbPortes.TabIndex = 12
        '
        'cbTransporte
        '
        Me.cbTransporte.DropDownWidth = 225
        Me.cbTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTransporte.FormattingEnabled = True
        Me.cbTransporte.Location = New System.Drawing.Point(813, 128)
        Me.cbTransporte.Name = "cbTransporte"
        Me.cbTransporte.Size = New System.Drawing.Size(180, 25)
        Me.cbTransporte.TabIndex = 11
        '
        'cbValorado
        '
        Me.cbValorado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValorado.FormattingEnabled = True
        Me.cbValorado.Location = New System.Drawing.Point(1003, 97)
        Me.cbValorado.Name = "cbValorado"
        Me.cbValorado.Size = New System.Drawing.Size(225, 25)
        Me.cbValorado.TabIndex = 8
        Me.cbValorado.Text = "VALORADO SIN TOTALES"
        '
        'cbMoneda
        '
        Me.cbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(364, 128)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(180, 25)
        Me.cbMoneda.TabIndex = 9
        '
        'cbSolicitadoVia
        '
        Me.cbSolicitadoVia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSolicitadoVia.FormattingEnabled = True
        Me.cbSolicitadoVia.Location = New System.Drawing.Point(1003, 32)
        Me.cbSolicitadoVia.MaxLength = 30
        Me.cbSolicitadoVia.Name = "cbSolicitadoVia"
        Me.cbSolicitadoVia.Size = New System.Drawing.Size(225, 25)
        Me.cbSolicitadoVia.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(895, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "SOLICITADO VIA"
        '
        'PrecioTransporte
        '
        Me.PrecioTransporte.BackColor = System.Drawing.SystemColors.Window
        Me.PrecioTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioTransporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioTransporte.Location = New System.Drawing.Point(1154, 128)
        Me.PrecioTransporte.MaxLength = 15
        Me.PrecioTransporte.Name = "PrecioTransporte"
        Me.PrecioTransporte.Size = New System.Drawing.Size(62, 23)
        Me.PrecioTransporte.TabIndex = 13
        Me.PrecioTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(250, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 17)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "OBSERVACIONES"
        '
        'Nota
        '
        Me.Nota.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nota.Location = New System.Drawing.Point(813, 159)
        Me.Nota.MaxLength = 200
        Me.Nota.Multiline = True
        Me.Nota.Name = "Nota"
        Me.Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Nota.Size = New System.Drawing.Size(415, 57)
        Me.Nota.TabIndex = 15
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(364, 159)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(369, 57)
        Me.Observaciones.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(899, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 17)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "CONTACTO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(250, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "DIRECCIÓN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(250, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "PROVEEDOR"
        '
        'cbContacto
        '
        Me.cbContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Location = New System.Drawing.Point(1003, 63)
        Me.cbContacto.Name = "cbContacto"
        Me.cbContacto.Size = New System.Drawing.Size(225, 25)
        Me.cbContacto.TabIndex = 6
        '
        'cbDireccion
        '
        Me.cbDireccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDireccion.FormattingEnabled = True
        Me.cbDireccion.Location = New System.Drawing.Point(364, 63)
        Me.cbDireccion.Name = "cbDireccion"
        Me.cbDireccion.Size = New System.Drawing.Size(519, 25)
        Me.cbDireccion.TabIndex = 5
        '
        'cbCodProveedor
        '
        Me.cbCodProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodProveedor.FormattingEnabled = True
        Me.cbCodProveedor.Location = New System.Drawing.Point(364, 32)
        Me.cbCodProveedor.Name = "cbCodProveedor"
        Me.cbCodProveedor.Size = New System.Drawing.Size(73, 25)
        Me.cbCodProveedor.TabIndex = 0
        '
        'cbProveedor
        '
        Me.cbProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(443, 32)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(361, 25)
        Me.cbProveedor.TabIndex = 1
        '
        'bVerProveedor
        '
        Me.bVerProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerProveedor.Image = CType(resources.GetObject("bVerProveedor.Image"), System.Drawing.Image)
        Me.bVerProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerProveedor.Location = New System.Drawing.Point(855, 32)
        Me.bVerProveedor.Name = "bVerProveedor"
        Me.bVerProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bVerProveedor.TabIndex = 3
        Me.bVerProveedor.UseVisualStyleBackColor = True
        '
        'bBuscarProveedor
        '
        Me.bBuscarProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarProveedor.Image = CType(resources.GetObject("bBuscarProveedor.Image"), System.Drawing.Image)
        Me.bBuscarProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarProveedor.Location = New System.Drawing.Point(824, 32)
        Me.bBuscarProveedor.Name = "bBuscarProveedor"
        Me.bBuscarProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarProveedor.TabIndex = 2
        Me.bBuscarProveedor.UseVisualStyleBackColor = True
        '
        'beMail
        '
        Me.beMail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.beMail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.beMail.Location = New System.Drawing.Point(952, 23)
        Me.beMail.Name = "beMail"
        Me.beMail.Size = New System.Drawing.Size(88, 50)
        Me.beMail.TabIndex = 19
        Me.beMail.Text = "E-MAIL"
        Me.beMail.UseVisualStyleBackColor = True
        '
        'bPDF
        '
        Me.bPDF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPDF.Location = New System.Drawing.Point(855, 23)
        Me.bPDF.Name = "bPDF"
        Me.bPDF.Size = New System.Drawing.Size(88, 50)
        Me.bPDF.TabIndex = 18
        Me.bPDF.Text = "PDF"
        Me.bPDF.UseVisualStyleBackColor = True
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Control
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(1132, 874)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 27)
        Me.Total.TabIndex = 7
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bSubirC
        '
        Me.bSubirC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubirC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubirC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubirC.Location = New System.Drawing.Point(1115, 22)
        Me.bSubirC.Name = "bSubirC"
        Me.bSubirC.Size = New System.Drawing.Size(27, 25)
        Me.bSubirC.TabIndex = 12
        Me.bSubirC.UseVisualStyleBackColor = True
        '
        'bBajarC
        '
        Me.bBajarC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajarC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajarC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajarC.Location = New System.Drawing.Point(1149, 22)
        Me.bBajarC.Name = "bBajarC"
        Me.bBajarC.Size = New System.Drawing.Size(27, 25)
        Me.bBajarC.TabIndex = 13
        Me.bBajarC.UseVisualStyleBackColor = True
        '
        'GestionAlbaranAProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 912)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionAlbaranAProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUEVO ALBARÁN A PROVEEDOR"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbConceptos.ResumeLayout(False)
        Me.gbConceptos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents numDoc As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbNumDoc As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents RefCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbSolicitadoVia As System.Windows.Forms.ComboBox
    Friend WithEvents bVerProveedor As System.Windows.Forms.Button
    Friend WithEvents Nota As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents gbConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPVP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecioNeto As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarArticuloC As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents codArticuloProv As System.Windows.Forms.TextBox
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents bTiposArticulo As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents PrecioNeto As System.Windows.Forms.TextBox
    Friend WithEvents bArticuloProveedor As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaS As System.Windows.Forms.Label
    Friend WithEvents lbMonedaN As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents bVerArticuloC As System.Windows.Forms.Button
    Friend WithEvents lvSubTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloCLi As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents cbCodProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents beMail As System.Windows.Forms.Button
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvck As System.Windows.Forms.ColumnHeader
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bultos As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Volumen As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbPortes As System.Windows.Forms.ComboBox
    Friend WithEvents cbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents PesoBruto As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PesoNeto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbValorado As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents bPDF As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents numsSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents RefCliente2 As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbmonedaT As System.Windows.Forms.Label
    Friend WithEvents PrecioTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Medidas As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents bSubirC As System.Windows.Forms.Button
    Friend WithEvents bBajarC As System.Windows.Forms.Button
End Class
