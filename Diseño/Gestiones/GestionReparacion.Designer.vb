<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionReparacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionReparacion))
        Me.bSubir = New System.Windows.Forms.Button()
        Me.bBajar = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bNuevo = New System.Windows.Forms.Button()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bBorrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbMoneda5 = New System.Windows.Forms.Label()
        Me.lbMoneda4 = New System.Windows.Forms.Label()
        Me.lbMoneda3 = New System.Windows.Forms.Label()
        Me.lbMoneda2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Retencion = New System.Windows.Forms.TextBox()
        Me.TotalRE = New System.Windows.Forms.TextBox()
        Me.TotalIVA = New System.Windows.Forms.TextBox()
        Me.BaseImponible = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpDatos = New System.Windows.Forms.TabPage()
        Me.cbArticuloR = New System.Windows.Forms.ComboBox()
        Me.bVerArticuloR = New System.Windows.Forms.Button()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.dtpFechaFabricacion = New System.Windows.Forms.DateTimePicker()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.bBuscarEquipo = New System.Windows.Forms.Button()
        Me.bBuscarArticuloR = New System.Windows.Forms.Button()
        Me.cbcodArticuloR = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TrabajoARealizar = New System.Windows.Forms.TextBox()
        Me.Inspeccion = New System.Windows.Forms.TextBox()
        Me.Descripcion = New System.Windows.Forms.TextBox()
        Me.OtrosTipos = New System.Windows.Forms.TextBox()
        Me.ckOtros = New System.Windows.Forms.CheckBox()
        Me.numSerie = New System.Windows.Forms.TextBox()
        Me.FechaServido = New System.Windows.Forms.TextBox()
        Me.ckPlaca = New System.Windows.Forms.CheckBox()
        Me.ckSonda = New System.Windows.Forms.CheckBox()
        Me.ckCaja = New System.Windows.Forms.CheckBox()
        Me.ckCelula = New System.Windows.Forms.CheckBox()
        Me.ckGarantia = New System.Windows.Forms.CheckBox()
        Me.tpProceso = New System.Windows.Forms.TabPage()
        Me.ckSeleccion = New System.Windows.Forms.CheckBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TrabajoRealizado = New System.Windows.Forms.TextBox()
        Me.dtpFechaTrabajo = New System.Windows.Forms.DateTimePicker()
        Me.cbRealizadoPor = New System.Windows.Forms.ComboBox()
        Me.cbArticulo = New System.Windows.Forms.ComboBox()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bVerArticuloC = New System.Windows.Forms.Button()
        Me.bTiposArticulo = New System.Windows.Forms.Button()
        Me.Cantidad = New System.Windows.Forms.TextBox()
        Me.lbSubTipo = New System.Windows.Forms.Label()
        Me.PVP = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.codArticuloCli = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.PrecioNeto = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.bArticuloCliente = New System.Windows.Forms.Button()
        Me.lbTipo = New System.Windows.Forms.Label()
        Me.subTotal = New System.Windows.Forms.TextBox()
        Me.cbSubTipo = New System.Windows.Forms.ComboBox()
        Me.bBuscarArticuloC = New System.Windows.Forms.Button()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox()
        Me.lbMonedaS = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lbMonedaN = New System.Windows.Forms.Label()
        Me.DescuentoC = New System.Windows.Forms.TextBox()
        Me.Horas = New System.Windows.Forms.TextBox()
        Me.lbmonedaC = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbUnidad = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lvConceptos = New System.Windows.Forms.ListView()
        Me.lvck = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvidConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvcodArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvcodArticuloCLi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPVP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvDescuento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPrecioNeto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvSubTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.bPDF = New System.Windows.Forms.Button()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lbMoneda1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFechaPrevista = New System.Windows.Forms.DateTimePicker()
        Me.txPrecioTotalReparacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbValorado = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbTransporte = New System.Windows.Forms.ComboBox()
        Me.bEstatus = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbPersona = New System.Windows.Forms.ComboBox()
        Me.bNuevoCliente = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbNumDoc = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numDoc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbNumDoc1 = New System.Windows.Forms.Label()
        Me.RefCliente = New System.Windows.Forms.TextBox()
        Me.numOferta = New System.Windows.Forms.TextBox()
        Me.numProforma = New System.Windows.Forms.TextBox()
        Me.numPedido = New System.Windows.Forms.TextBox()
        Me.bMoneda = New System.Windows.Forms.Button()
        Me.cbEstatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lbmonedaT = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cbMoneda = New System.Windows.Forms.ComboBox()
        Me.cbPortes = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Nota = New System.Windows.Forms.TextBox()
        Me.Observaciones = New System.Windows.Forms.TextBox()
        Me.ProntoPago = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrecioTransporte = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbContacto = New System.Windows.Forms.ComboBox()
        Me.cbDireccion = New System.Windows.Forms.ComboBox()
        Me.cbCodCliente = New System.Windows.Forms.ComboBox()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.bVerCliente = New System.Windows.Forms.Button()
        Me.bBuscarCliente = New System.Windows.Forms.Button()
        Me.bTraspasar = New System.Windows.Forms.Button()
        Me.beMail = New System.Windows.Forms.Button()
        Me.Total = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txRMA = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpDatos.SuspendLayout()
        Me.tpProceso.SuspendLayout()
        Me.gbGeneral.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSubir
        '
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(383, 23)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(88, 22)
        Me.bSubir.TabIndex = 9
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(383, 51)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(88, 22)
        Me.bBajar.TabIndex = 10
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(670, 23)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 50)
        Me.bImprimir.TabIndex = 13
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
        Me.bSalir.Location = New System.Drawing.Point(1150, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 18
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(574, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(88, 50)
        Me.bNuevo.TabIndex = 12
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(478, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 11
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(1054, 23)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(88, 50)
        Me.bBorrar.TabIndex = 17
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbMoneda5)
        Me.GroupBox1.Controls.Add(Me.lbMoneda4)
        Me.GroupBox1.Controls.Add(Me.lbMoneda3)
        Me.GroupBox1.Controls.Add(Me.lbMoneda2)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Retencion)
        Me.GroupBox1.Controls.Add(Me.TotalRE)
        Me.GroupBox1.Controls.Add(Me.TotalIVA)
        Me.GroupBox1.Controls.Add(Me.BaseImponible)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.bPDF)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.lbMoneda1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.gbGeneral)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.bSubir)
        Me.GroupBox1.Controls.Add(Me.bTraspasar)
        Me.GroupBox1.Controls.Add(Me.beMail)
        Me.GroupBox1.Controls.Add(Me.bBorrar)
        Me.GroupBox1.Controls.Add(Me.bBajar)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.bImprimir)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.Total)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 760)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbMoneda5
        '
        Me.lbMoneda5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda5.AutoSize = True
        Me.lbMoneda5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda5.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda5.Location = New System.Drawing.Point(242, 730)
        Me.lbMoneda5.Name = "lbMoneda5"
        Me.lbMoneda5.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda5.TabIndex = 194
        Me.lbMoneda5.Text = "€"
        '
        'lbMoneda4
        '
        Me.lbMoneda4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda4.AutoSize = True
        Me.lbMoneda4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda4.Location = New System.Drawing.Point(490, 730)
        Me.lbMoneda4.Name = "lbMoneda4"
        Me.lbMoneda4.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda4.TabIndex = 193
        Me.lbMoneda4.Text = "€"
        '
        'lbMoneda3
        '
        Me.lbMoneda3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda3.AutoSize = True
        Me.lbMoneda3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda3.Location = New System.Drawing.Point(728, 730)
        Me.lbMoneda3.Name = "lbMoneda3"
        Me.lbMoneda3.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda3.TabIndex = 196
        Me.lbMoneda3.Text = "€"
        '
        'lbMoneda2
        '
        Me.lbMoneda2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda2.AutoSize = True
        Me.lbMoneda2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda2.Location = New System.Drawing.Point(978, 730)
        Me.lbMoneda2.Name = "lbMoneda2"
        Me.lbMoneda2.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda2.TabIndex = 195
        Me.lbMoneda2.Text = "€"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(816, 730)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 17)
        Me.Label18.TabIndex = 191
        Me.Label18.Text = "RETENCIÓN"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(574, 730)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 17)
        Me.Label17.TabIndex = 192
        Me.Label17.Text = "TOTAL R.E."
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(339, 730)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(69, 17)
        Me.Label25.TabIndex = 189
        Me.Label25.Text = "TOTAL IVA"
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(49, 730)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(107, 17)
        Me.Label28.TabIndex = 190
        Me.Label28.Text = "BASE IMPONIBLE"
        '
        'Retencion
        '
        Me.Retencion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Retencion.BackColor = System.Drawing.SystemColors.Control
        Me.Retencion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Retencion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Retencion.Location = New System.Drawing.Point(897, 727)
        Me.Retencion.MaxLength = 15
        Me.Retencion.Name = "Retencion"
        Me.Retencion.ReadOnly = True
        Me.Retencion.Size = New System.Drawing.Size(80, 23)
        Me.Retencion.TabIndex = 5
        Me.Retencion.TabStop = False
        Me.Retencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalRE
        '
        Me.TotalRE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalRE.BackColor = System.Drawing.SystemColors.Control
        Me.TotalRE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalRE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalRE.Location = New System.Drawing.Point(647, 727)
        Me.TotalRE.MaxLength = 15
        Me.TotalRE.Name = "TotalRE"
        Me.TotalRE.ReadOnly = True
        Me.TotalRE.Size = New System.Drawing.Size(80, 23)
        Me.TotalRE.TabIndex = 4
        Me.TotalRE.TabStop = False
        Me.TotalRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalIVA
        '
        Me.TotalIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalIVA.BackColor = System.Drawing.SystemColors.Control
        Me.TotalIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalIVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalIVA.Location = New System.Drawing.Point(409, 727)
        Me.TotalIVA.MaxLength = 15
        Me.TotalIVA.Name = "TotalIVA"
        Me.TotalIVA.ReadOnly = True
        Me.TotalIVA.Size = New System.Drawing.Size(80, 23)
        Me.TotalIVA.TabIndex = 3
        Me.TotalIVA.TabStop = False
        Me.TotalIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BaseImponible
        '
        Me.BaseImponible.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BaseImponible.BackColor = System.Drawing.SystemColors.Control
        Me.BaseImponible.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BaseImponible.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BaseImponible.Location = New System.Drawing.Point(159, 727)
        Me.BaseImponible.MaxLength = 15
        Me.BaseImponible.Name = "BaseImponible"
        Me.BaseImponible.ReadOnly = True
        Me.BaseImponible.Size = New System.Drawing.Size(80, 23)
        Me.BaseImponible.TabIndex = 2
        Me.BaseImponible.TabStop = False
        Me.BaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpDatos)
        Me.TabControl1.Controls.Add(Me.tpProceso)
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(9, 342)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1243, 375)
        Me.TabControl1.TabIndex = 1
        '
        'tpDatos
        '
        Me.tpDatos.Controls.Add(Me.cbArticuloR)
        Me.tpDatos.Controls.Add(Me.bVerArticuloR)
        Me.tpDatos.Controls.Add(Me.Label47)
        Me.tpDatos.Controls.Add(Me.dtpFechaFabricacion)
        Me.tpDatos.Controls.Add(Me.Label35)
        Me.tpDatos.Controls.Add(Me.bBuscarEquipo)
        Me.tpDatos.Controls.Add(Me.bBuscarArticuloR)
        Me.tpDatos.Controls.Add(Me.cbcodArticuloR)
        Me.tpDatos.Controls.Add(Me.Label43)
        Me.tpDatos.Controls.Add(Me.Label33)
        Me.tpDatos.Controls.Add(Me.Label32)
        Me.tpDatos.Controls.Add(Me.Label42)
        Me.tpDatos.Controls.Add(Me.Label12)
        Me.tpDatos.Controls.Add(Me.Label41)
        Me.tpDatos.Controls.Add(Me.Label46)
        Me.tpDatos.Controls.Add(Me.TrabajoARealizar)
        Me.tpDatos.Controls.Add(Me.Inspeccion)
        Me.tpDatos.Controls.Add(Me.Descripcion)
        Me.tpDatos.Controls.Add(Me.OtrosTipos)
        Me.tpDatos.Controls.Add(Me.ckOtros)
        Me.tpDatos.Controls.Add(Me.numSerie)
        Me.tpDatos.Controls.Add(Me.FechaServido)
        Me.tpDatos.Controls.Add(Me.ckPlaca)
        Me.tpDatos.Controls.Add(Me.ckSonda)
        Me.tpDatos.Controls.Add(Me.ckCaja)
        Me.tpDatos.Controls.Add(Me.ckCelula)
        Me.tpDatos.Controls.Add(Me.ckGarantia)
        Me.tpDatos.Location = New System.Drawing.Point(4, 26)
        Me.tpDatos.Name = "tpDatos"
        Me.tpDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDatos.Size = New System.Drawing.Size(1235, 345)
        Me.tpDatos.TabIndex = 0
        Me.tpDatos.Text = "DATOS REPARACIÓN"
        Me.tpDatos.UseVisualStyleBackColor = True
        '
        'cbArticuloR
        '
        Me.cbArticuloR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbArticuloR.DropDownWidth = 447
        Me.cbArticuloR.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticuloR.FormattingEnabled = True
        Me.cbArticuloR.Location = New System.Drawing.Point(361, 42)
        Me.cbArticuloR.Name = "cbArticuloR"
        Me.cbArticuloR.Size = New System.Drawing.Size(425, 25)
        Me.cbArticuloR.Sorted = True
        Me.cbArticuloR.TabIndex = 9
        '
        'bVerArticuloR
        '
        Me.bVerArticuloR.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloR.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticuloR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloR.Location = New System.Drawing.Point(839, 42)
        Me.bVerArticuloR.Name = "bVerArticuloR"
        Me.bVerArticuloR.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloR.TabIndex = 11
        Me.bVerArticuloR.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label47.Location = New System.Drawing.Point(18, 46)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(65, 17)
        Me.Label47.TabIndex = 184
        Me.Label47.Text = "CÓDIGO"
        '
        'dtpFechaFabricacion
        '
        Me.dtpFechaFabricacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFabricacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFabricacion.Location = New System.Drawing.Point(983, 12)
        Me.dtpFechaFabricacion.Name = "dtpFechaFabricacion"
        Me.dtpFechaFabricacion.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaFabricacion.TabIndex = 6
        Me.dtpFechaFabricacion.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(280, 46)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(69, 17)
        Me.Label35.TabIndex = 184
        Me.Label35.Text = "ARTÍCULO"
        '
        'bBuscarEquipo
        '
        Me.bBuscarEquipo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarEquipo.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarEquipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarEquipo.Location = New System.Drawing.Point(1198, 42)
        Me.bBuscarEquipo.Name = "bBuscarEquipo"
        Me.bBuscarEquipo.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarEquipo.TabIndex = 14
        Me.bBuscarEquipo.UseVisualStyleBackColor = True
        '
        'bBuscarArticuloR
        '
        Me.bBuscarArticuloR.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticuloR.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticuloR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticuloR.Location = New System.Drawing.Point(806, 42)
        Me.bBuscarArticuloR.Name = "bBuscarArticuloR"
        Me.bBuscarArticuloR.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticuloR.TabIndex = 10
        Me.bBuscarArticuloR.UseVisualStyleBackColor = True
        '
        'cbcodArticuloR
        '
        Me.cbcodArticuloR.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodArticuloR.FormattingEnabled = True
        Me.cbcodArticuloR.Location = New System.Drawing.Point(143, 42)
        Me.cbcodArticuloR.Name = "cbcodArticuloR"
        Me.cbcodArticuloR.Size = New System.Drawing.Size(125, 25)
        Me.cbcodArticuloR.Sorted = True
        Me.cbcodArticuloR.TabIndex = 8
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(18, 266)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(88, 42)
        Me.Label43.TabIndex = 125
        Me.Label43.Text = "TRABAJO A REALIZAR"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(18, 171)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 17)
        Me.Label33.TabIndex = 125
        Me.Label33.Text = "INSPECCIÓN"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(18, 77)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(96, 17)
        Me.Label32.TabIndex = 125
        Me.Label32.Text = "DESCRIPCIÓN"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(18, 15)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(127, 17)
        Me.Label42.TabIndex = 146
        Me.Label42.Text = "TIPO REPARACIÓN:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(835, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 17)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "FECHA FABRICACIÓN"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label41.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(1080, 46)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(30, 17)
        Me.Label41.TabIndex = 146
        Me.Label41.Text = "N/S"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label46.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(869, 46)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(108, 17)
        Me.Label46.TabIndex = 146
        Me.Label46.Text = "FECHA SERVIDO"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrabajoARealizar
        '
        Me.TrabajoARealizar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrabajoARealizar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrabajoARealizar.Location = New System.Drawing.Point(143, 264)
        Me.TrabajoARealizar.MaxLength = 2000
        Me.TrabajoARealizar.Multiline = True
        Me.TrabajoARealizar.Name = "TrabajoARealizar"
        Me.TrabajoARealizar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TrabajoARealizar.Size = New System.Drawing.Size(1083, 42)
        Me.TrabajoARealizar.TabIndex = 17
        '
        'Inspeccion
        '
        Me.Inspeccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Inspeccion.Location = New System.Drawing.Point(143, 169)
        Me.Inspeccion.MaxLength = 1500
        Me.Inspeccion.Multiline = True
        Me.Inspeccion.Name = "Inspeccion"
        Me.Inspeccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Inspeccion.Size = New System.Drawing.Size(1083, 80)
        Me.Inspeccion.TabIndex = 16
        '
        'Descripcion
        '
        Me.Descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripcion.Location = New System.Drawing.Point(143, 75)
        Me.Descripcion.MaxLength = 1500
        Me.Descripcion.Multiline = True
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Descripcion.Size = New System.Drawing.Size(1083, 80)
        Me.Descripcion.TabIndex = 15
        '
        'OtrosTipos
        '
        Me.OtrosTipos.BackColor = System.Drawing.SystemColors.Window
        Me.OtrosTipos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OtrosTipos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OtrosTipos.Location = New System.Drawing.Point(465, 12)
        Me.OtrosTipos.MaxLength = 15
        Me.OtrosTipos.Name = "OtrosTipos"
        Me.OtrosTipos.Size = New System.Drawing.Size(321, 23)
        Me.OtrosTipos.TabIndex = 5
        '
        'ckOtros
        '
        Me.ckOtros.AutoSize = True
        Me.ckOtros.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckOtros.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckOtros.Location = New System.Drawing.Point(441, 16)
        Me.ckOtros.Name = "ckOtros"
        Me.ckOtros.Size = New System.Drawing.Size(15, 14)
        Me.ckOtros.TabIndex = 4
        Me.ckOtros.UseVisualStyleBackColor = True
        '
        'numSerie
        '
        Me.numSerie.BackColor = System.Drawing.SystemColors.Window
        Me.numSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numSerie.Location = New System.Drawing.Point(1116, 43)
        Me.numSerie.MaxLength = 15
        Me.numSerie.Name = "numSerie"
        Me.numSerie.Size = New System.Drawing.Size(76, 23)
        Me.numSerie.TabIndex = 13
        Me.numSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FechaServido
        '
        Me.FechaServido.BackColor = System.Drawing.SystemColors.Window
        Me.FechaServido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaServido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FechaServido.Location = New System.Drawing.Point(983, 43)
        Me.FechaServido.MaxLength = 15
        Me.FechaServido.Name = "FechaServido"
        Me.FechaServido.ReadOnly = True
        Me.FechaServido.Size = New System.Drawing.Size(90, 23)
        Me.FechaServido.TabIndex = 12
        '
        'ckPlaca
        '
        Me.ckPlaca.AutoSize = True
        Me.ckPlaca.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPlaca.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckPlaca.Location = New System.Drawing.Point(365, 13)
        Me.ckPlaca.Name = "ckPlaca"
        Me.ckPlaca.Size = New System.Drawing.Size(70, 21)
        Me.ckPlaca.TabIndex = 3
        Me.ckPlaca.Text = "PLACA"
        Me.ckPlaca.UseVisualStyleBackColor = True
        '
        'ckSonda
        '
        Me.ckSonda.AutoSize = True
        Me.ckSonda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSonda.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSonda.Location = New System.Drawing.Point(288, 13)
        Me.ckSonda.Name = "ckSonda"
        Me.ckSonda.Size = New System.Drawing.Size(73, 21)
        Me.ckSonda.TabIndex = 2
        Me.ckSonda.Text = "SONDA"
        Me.ckSonda.UseVisualStyleBackColor = True
        '
        'ckCaja
        '
        Me.ckCaja.AutoSize = True
        Me.ckCaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCaja.Location = New System.Drawing.Point(146, 13)
        Me.ckCaja.Name = "ckCaja"
        Me.ckCaja.Size = New System.Drawing.Size(62, 21)
        Me.ckCaja.TabIndex = 0
        Me.ckCaja.Text = "CAJA"
        Me.ckCaja.UseVisualStyleBackColor = True
        '
        'ckCelula
        '
        Me.ckCelula.AutoSize = True
        Me.ckCelula.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCelula.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCelula.Location = New System.Drawing.Point(211, 13)
        Me.ckCelula.Name = "ckCelula"
        Me.ckCelula.Size = New System.Drawing.Size(74, 21)
        Me.ckCelula.TabIndex = 1
        Me.ckCelula.Text = "CÉLULA"
        Me.ckCelula.UseVisualStyleBackColor = True
        '
        'ckGarantia
        '
        Me.ckGarantia.AutoSize = True
        Me.ckGarantia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGarantia.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckGarantia.Location = New System.Drawing.Point(1119, 13)
        Me.ckGarantia.Name = "ckGarantia"
        Me.ckGarantia.Size = New System.Drawing.Size(91, 21)
        Me.ckGarantia.TabIndex = 7
        Me.ckGarantia.Text = "GARANTÍA"
        Me.ckGarantia.UseVisualStyleBackColor = True
        '
        'tpProceso
        '
        Me.tpProceso.Controls.Add(Me.ckSeleccion)
        Me.tpProceso.Controls.Add(Me.Label48)
        Me.tpProceso.Controls.Add(Me.Label34)
        Me.tpProceso.Controls.Add(Me.TrabajoRealizado)
        Me.tpProceso.Controls.Add(Me.dtpFechaTrabajo)
        Me.tpProceso.Controls.Add(Me.cbRealizadoPor)
        Me.tpProceso.Controls.Add(Me.cbArticulo)
        Me.tpProceso.Controls.Add(Me.bLimpiar)
        Me.tpProceso.Controls.Add(Me.bVerArticuloC)
        Me.tpProceso.Controls.Add(Me.bTiposArticulo)
        Me.tpProceso.Controls.Add(Me.Cantidad)
        Me.tpProceso.Controls.Add(Me.lbSubTipo)
        Me.tpProceso.Controls.Add(Me.PVP)
        Me.tpProceso.Controls.Add(Me.Label24)
        Me.tpProceso.Controls.Add(Me.Label45)
        Me.tpProceso.Controls.Add(Me.Label36)
        Me.tpProceso.Controls.Add(Me.codArticuloCli)
        Me.tpProceso.Controls.Add(Me.Label39)
        Me.tpProceso.Controls.Add(Me.PrecioNeto)
        Me.tpProceso.Controls.Add(Me.Label23)
        Me.tpProceso.Controls.Add(Me.bArticuloCliente)
        Me.tpProceso.Controls.Add(Me.lbTipo)
        Me.tpProceso.Controls.Add(Me.subTotal)
        Me.tpProceso.Controls.Add(Me.cbSubTipo)
        Me.tpProceso.Controls.Add(Me.bBuscarArticuloC)
        Me.tpProceso.Controls.Add(Me.cbTipo)
        Me.tpProceso.Controls.Add(Me.cbCodArticulo)
        Me.tpProceso.Controls.Add(Me.lbMonedaS)
        Me.tpProceso.Controls.Add(Me.Label21)
        Me.tpProceso.Controls.Add(Me.lbMonedaN)
        Me.tpProceso.Controls.Add(Me.DescuentoC)
        Me.tpProceso.Controls.Add(Me.Horas)
        Me.tpProceso.Controls.Add(Me.lbmonedaC)
        Me.tpProceso.Controls.Add(Me.Label20)
        Me.tpProceso.Controls.Add(Me.lbUnidad)
        Me.tpProceso.Controls.Add(Me.Label26)
        Me.tpProceso.Controls.Add(Me.lvConceptos)
        Me.tpProceso.Controls.Add(Me.Label27)
        Me.tpProceso.Controls.Add(Me.Label22)
        Me.tpProceso.Controls.Add(Me.Label38)
        Me.tpProceso.Location = New System.Drawing.Point(4, 26)
        Me.tpProceso.Name = "tpProceso"
        Me.tpProceso.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProceso.Size = New System.Drawing.Size(1235, 345)
        Me.tpProceso.TabIndex = 1
        Me.tpProceso.Text = "PROCESO"
        Me.tpProceso.UseVisualStyleBackColor = True
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(14, 222)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 194
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label48.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(248, 23)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(108, 17)
        Me.Label48.TabIndex = 192
        Me.Label48.Text = "REALIZADO POR"
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(5, 57)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 42)
        Me.Label34.TabIndex = 193
        Me.Label34.Text = "TRABAJO REALIZADO"
        '
        'TrabajoRealizado
        '
        Me.TrabajoRealizado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrabajoRealizado.Location = New System.Drawing.Point(89, 55)
        Me.TrabajoRealizado.MaxLength = 2000
        Me.TrabajoRealizado.Multiline = True
        Me.TrabajoRealizado.Name = "TrabajoRealizado"
        Me.TrabajoRealizado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TrabajoRealizado.Size = New System.Drawing.Size(1131, 80)
        Me.TrabajoRealizado.TabIndex = 4
        '
        'dtpFechaTrabajo
        '
        Me.dtpFechaTrabajo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaTrabajo.Location = New System.Drawing.Point(143, 20)
        Me.dtpFechaTrabajo.Name = "dtpFechaTrabajo"
        Me.dtpFechaTrabajo.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaTrabajo.TabIndex = 0
        Me.dtpFechaTrabajo.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'cbRealizadoPor
        '
        Me.cbRealizadoPor.DropDownWidth = 225
        Me.cbRealizadoPor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRealizadoPor.FormattingEnabled = True
        Me.cbRealizadoPor.Location = New System.Drawing.Point(363, 19)
        Me.cbRealizadoPor.Name = "cbRealizadoPor"
        Me.cbRealizadoPor.Size = New System.Drawing.Size(180, 25)
        Me.cbRealizadoPor.TabIndex = 1
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownWidth = 447
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(361, 185)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(369, 25)
        Me.cbArticulo.Sorted = True
        Me.cbArticulo.TabIndex = 9
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1193, 154)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 19
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bVerArticuloC
        '
        Me.bVerArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloC.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticuloC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloC.Location = New System.Drawing.Point(774, 185)
        Me.bVerArticuloC.Name = "bVerArticuloC"
        Me.bVerArticuloC.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloC.TabIndex = 13
        Me.bVerArticuloC.UseVisualStyleBackColor = True
        '
        'bTiposArticulo
        '
        Me.bTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposArticulo.Location = New System.Drawing.Point(253, 155)
        Me.bTiposArticulo.Name = "bTiposArticulo"
        Me.bTiposArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bTiposArticulo.TabIndex = 7
        Me.bTiposArticulo.Text = "...."
        Me.bTiposArticulo.UseVisualStyleBackColor = True
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Location = New System.Drawing.Point(880, 186)
        Me.Cantidad.MaxLength = 15
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(45, 23)
        Me.Cantidad.TabIndex = 15
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(13, 189)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(56, 17)
        Me.lbSubTipo.TabIndex = 180
        Me.lbSubTipo.Text = "SUBTIPO"
        '
        'PVP
        '
        Me.PVP.BackColor = System.Drawing.SystemColors.Window
        Me.PVP.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PVP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PVP.Location = New System.Drawing.Point(991, 156)
        Me.PVP.MaxLength = 15
        Me.PVP.Name = "PVP"
        Me.PVP.ReadOnly = True
        Me.PVP.Size = New System.Drawing.Size(65, 23)
        Me.PVP.TabIndex = 16
        Me.PVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(487, 159)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 17)
        Me.Label24.TabIndex = 179
        Me.Label24.Text = "ARTICULO/CLI"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label45.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(611, 23)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(51, 17)
        Me.Label45.TabIndex = 147
        Me.Label45.Text = "HORAS"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label36.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(8, 23)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(109, 17)
        Me.Label36.TabIndex = 147
        Me.Label36.Text = "FECHA TRABAJO"
        '
        'codArticuloCli
        '
        Me.codArticuloCli.BackColor = System.Drawing.SystemColors.Window
        Me.codArticuloCli.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticuloCli.ForeColor = System.Drawing.SystemColors.WindowText
        Me.codArticuloCli.Location = New System.Drawing.Point(583, 156)
        Me.codArticuloCli.MaxLength = 15
        Me.codArticuloCli.Name = "codArticuloCli"
        Me.codArticuloCli.Size = New System.Drawing.Size(147, 23)
        Me.codArticuloCli.TabIndex = 10
        Me.codArticuloCli.TabStop = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(287, 189)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 17)
        Me.Label39.TabIndex = 179
        Me.Label39.Text = "ARTÍCULO"
        '
        'PrecioNeto
        '
        Me.PrecioNeto.BackColor = System.Drawing.SystemColors.Window
        Me.PrecioNeto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioNeto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioNeto.Location = New System.Drawing.Point(991, 186)
        Me.PrecioNeto.MaxLength = 15
        Me.PrecioNeto.Name = "PrecioNeto"
        Me.PrecioNeto.Size = New System.Drawing.Size(65, 23)
        Me.PrecioNeto.TabIndex = 17
        Me.PrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(287, 159)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 17)
        Me.Label23.TabIndex = 179
        Me.Label23.Text = "CÓDIGO"
        '
        'bArticuloCliente
        '
        Me.bArticuloCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bArticuloCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.data_sort
        Me.bArticuloCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bArticuloCliente.Location = New System.Drawing.Point(744, 155)
        Me.bArticuloCliente.Name = "bArticuloCliente"
        Me.bArticuloCliente.Size = New System.Drawing.Size(27, 25)
        Me.bArticuloCliente.TabIndex = 11
        Me.bArticuloCliente.UseVisualStyleBackColor = True
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(13, 159)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(35, 17)
        Me.lbTipo.TabIndex = 179
        Me.lbTipo.Text = "TIPO"
        '
        'subTotal
        '
        Me.subTotal.BackColor = System.Drawing.SystemColors.Window
        Me.subTotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.subTotal.Location = New System.Drawing.Point(1141, 186)
        Me.subTotal.MaxLength = 15
        Me.subTotal.Name = "subTotal"
        Me.subTotal.ReadOnly = True
        Me.subTotal.Size = New System.Drawing.Size(65, 23)
        Me.subTotal.TabIndex = 18
        Me.subTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(89, 185)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(144, 25)
        Me.cbSubTipo.TabIndex = 6
        '
        'bBuscarArticuloC
        '
        Me.bBuscarArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticuloC.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticuloC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticuloC.Location = New System.Drawing.Point(744, 185)
        Me.bBuscarArticuloC.Name = "bBuscarArticuloC"
        Me.bBuscarArticuloC.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticuloC.TabIndex = 12
        Me.bBuscarArticuloC.UseVisualStyleBackColor = True
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(89, 155)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(144, 25)
        Me.cbTipo.TabIndex = 5
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(361, 155)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(124, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 8
        '
        'lbMonedaS
        '
        Me.lbMonedaS.AutoSize = True
        Me.lbMonedaS.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMonedaS.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaS.Location = New System.Drawing.Point(1207, 189)
        Me.lbMonedaS.Name = "lbMonedaS"
        Me.lbMonedaS.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaS.TabIndex = 174
        Me.lbMonedaS.Text = "€"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(927, 159)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(18, 17)
        Me.Label21.TabIndex = 145
        Me.Label21.Text = "%"
        '
        'lbMonedaN
        '
        Me.lbMonedaN.AutoSize = True
        Me.lbMonedaN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMonedaN.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaN.Location = New System.Drawing.Point(1057, 189)
        Me.lbMonedaN.Name = "lbMonedaN"
        Me.lbMonedaN.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaN.TabIndex = 174
        Me.lbMonedaN.Text = "€"
        '
        'DescuentoC
        '
        Me.DescuentoC.BackColor = System.Drawing.SystemColors.Window
        Me.DescuentoC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescuentoC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DescuentoC.Location = New System.Drawing.Point(880, 156)
        Me.DescuentoC.MaxLength = 6
        Me.DescuentoC.Name = "DescuentoC"
        Me.DescuentoC.Size = New System.Drawing.Size(45, 23)
        Me.DescuentoC.TabIndex = 14
        Me.DescuentoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Horas
        '
        Me.Horas.BackColor = System.Drawing.SystemColors.Window
        Me.Horas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Horas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Horas.Location = New System.Drawing.Point(665, 20)
        Me.Horas.MaxLength = 15
        Me.Horas.Name = "Horas"
        Me.Horas.Size = New System.Drawing.Size(65, 23)
        Me.Horas.TabIndex = 2
        Me.Horas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbmonedaC
        '
        Me.lbmonedaC.AutoSize = True
        Me.lbmonedaC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmonedaC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbmonedaC.Location = New System.Drawing.Point(1057, 159)
        Me.lbmonedaC.Name = "lbmonedaC"
        Me.lbmonedaC.Size = New System.Drawing.Size(15, 17)
        Me.lbmonedaC.TabIndex = 174
        Me.lbmonedaC.Text = "€"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(804, 189)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 147
        Me.Label20.Text = "CANTIDAD"
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(927, 189)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 174
        Me.lbUnidad.Text = "U"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(949, 159)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 17)
        Me.Label26.TabIndex = 147
        Me.Label26.Text = "PVP"
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvck, Me.lvidConcepto, Me.lvcodArticulo, Me.lvcodArticuloCLi, Me.lvArticulo, Me.lvCantidad, Me.lvPVP, Me.lvDescuento, Me.lvPrecioNeto, Me.lvSubTotal})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(9, 216)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(1214, 103)
        Me.lvConceptos.TabIndex = 21
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
        Me.lvcodArticuloCLi.Width = 128
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTICULO"
        Me.lvArticulo.Width = 475
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
        Me.lvPVP.Width = 94
        '
        'lvDescuento
        '
        Me.lvDescuento.Text = "DESCUENTO"
        Me.lvDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvDescuento.Width = 84
        '
        'lvPrecioNeto
        '
        Me.lvPrecioNeto.Text = "PRECIO NETO"
        Me.lvPrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecioNeto.Width = 94
        '
        'lvSubTotal
        '
        Me.lvSubTotal.Text = "SUBTOTAL"
        Me.lvSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvSubTotal.Width = 89
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(949, 189)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 17)
        Me.Label27.TabIndex = 147
        Me.Label27.Text = "NETO"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(797, 159)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 17)
        Me.Label22.TabIndex = 147
        Me.Label22.Text = "DESCUENTO"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(1077, 189)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 17)
        Me.Label38.TabIndex = 147
        Me.Label38.Text = "SUBTOTAL"
        '
        'bPDF
        '
        Me.bPDF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPDF.Location = New System.Drawing.Point(766, 23)
        Me.bPDF.Name = "bPDF"
        Me.bPDF.Size = New System.Drawing.Size(88, 50)
        Me.bPDF.TabIndex = 14
        Me.bPDF.Text = "PDF"
        Me.bPDF.UseVisualStyleBackColor = True
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(234, 46)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(135, 26)
        Me.cbEstado.TabIndex = 8
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(165, 50)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(65, 18)
        Me.Label57.TabIndex = 115
        Me.Label57.Text = "ESTADO"
        '
        'lbMoneda1
        '
        Me.lbMoneda1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda1.AutoSize = True
        Me.lbMoneda1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda1.Location = New System.Drawing.Point(1231, 727)
        Me.lbMoneda1.Name = "lbMoneda1"
        Me.lbMoneda1.Size = New System.Drawing.Size(16, 18)
        Me.lbMoneda1.TabIndex = 184
        Me.lbMoneda1.Text = "€"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(1083, 727)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 18)
        Me.Label19.TabIndex = 147
        Me.Label19.Text = "TOTAL"
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.Label44)
        Me.gbGeneral.Controls.Add(Me.txRMA)
        Me.gbGeneral.Controls.Add(Me.dtpFecha)
        Me.gbGeneral.Controls.Add(Me.Label30)
        Me.gbGeneral.Controls.Add(Me.Label13)
        Me.gbGeneral.Controls.Add(Me.Label2)
        Me.gbGeneral.Controls.Add(Me.Label37)
        Me.gbGeneral.Controls.Add(Me.dtpFechaPrevista)
        Me.gbGeneral.Controls.Add(Me.txPrecioTotalReparacion)
        Me.gbGeneral.Controls.Add(Me.Label14)
        Me.gbGeneral.Controls.Add(Me.cbValorado)
        Me.gbGeneral.Controls.Add(Me.Label8)
        Me.gbGeneral.Controls.Add(Me.cbTransporte)
        Me.gbGeneral.Controls.Add(Me.bEstatus)
        Me.gbGeneral.Controls.Add(Me.Label40)
        Me.gbGeneral.Controls.Add(Me.Label49)
        Me.gbGeneral.Controls.Add(Me.Label9)
        Me.gbGeneral.Controls.Add(Me.cbPersona)
        Me.gbGeneral.Controls.Add(Me.bNuevoCliente)
        Me.gbGeneral.Controls.Add(Me.GroupBox4)
        Me.gbGeneral.Controls.Add(Me.bMoneda)
        Me.gbGeneral.Controls.Add(Me.cbEstatus)
        Me.gbGeneral.Controls.Add(Me.Label1)
        Me.gbGeneral.Controls.Add(Me.Label16)
        Me.gbGeneral.Controls.Add(Me.lbmonedaT)
        Me.gbGeneral.Controls.Add(Me.Label29)
        Me.gbGeneral.Controls.Add(Me.cbTipoIVA)
        Me.gbGeneral.Controls.Add(Me.Label31)
        Me.gbGeneral.Controls.Add(Me.cbMoneda)
        Me.gbGeneral.Controls.Add(Me.cbPortes)
        Me.gbGeneral.Controls.Add(Me.Label6)
        Me.gbGeneral.Controls.Add(Me.Nota)
        Me.gbGeneral.Controls.Add(Me.Observaciones)
        Me.gbGeneral.Controls.Add(Me.ProntoPago)
        Me.gbGeneral.Controls.Add(Me.Label5)
        Me.gbGeneral.Controls.Add(Me.Label10)
        Me.gbGeneral.Controls.Add(Me.Label4)
        Me.gbGeneral.Controls.Add(Me.PrecioTransporte)
        Me.gbGeneral.Controls.Add(Me.Label3)
        Me.gbGeneral.Controls.Add(Me.cbContacto)
        Me.gbGeneral.Controls.Add(Me.cbDireccion)
        Me.gbGeneral.Controls.Add(Me.cbCodCliente)
        Me.gbGeneral.Controls.Add(Me.cbCliente)
        Me.gbGeneral.Controls.Add(Me.bVerCliente)
        Me.gbGeneral.Controls.Add(Me.bBuscarCliente)
        Me.gbGeneral.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGeneral.Location = New System.Drawing.Point(12, 78)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(1243, 258)
        Me.gbGeneral.TabIndex = 0
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "DATOS GENERALES"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(144, 192)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(90, 23)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(939, 224)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(210, 17)
        Me.Label30.TabIndex = 200
        Me.Label30.Text = "PRECIO ESTIMADO REPARACIÓN"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(12, 197)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 17)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "FECHA ENTRADA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "FECHA PREVISTA"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(1222, 224)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(15, 17)
        Me.Label37.TabIndex = 201
        Me.Label37.Text = "€"
        '
        'dtpFechaPrevista
        '
        Me.dtpFechaPrevista.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevista.Location = New System.Drawing.Point(144, 221)
        Me.dtpFechaPrevista.Name = "dtpFechaPrevista"
        Me.dtpFechaPrevista.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevista.TabIndex = 1
        Me.dtpFechaPrevista.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'txPrecioTotalReparacion
        '
        Me.txPrecioTotalReparacion.BackColor = System.Drawing.SystemColors.Window
        Me.txPrecioTotalReparacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPrecioTotalReparacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txPrecioTotalReparacion.Location = New System.Drawing.Point(1155, 221)
        Me.txPrecioTotalReparacion.MaxLength = 15
        Me.txPrecioTotalReparacion.Name = "txPrecioTotalReparacion"
        Me.txPrecioTotalReparacion.Size = New System.Drawing.Size(62, 23)
        Me.txPrecioTotalReparacion.TabIndex = 199
        Me.txPrecioTotalReparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(882, 98)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 17)
        Me.Label14.TabIndex = 198
        Me.Label14.Text = "DOCUMENTO"
        '
        'cbValorado
        '
        Me.cbValorado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValorado.FormattingEnabled = True
        Me.cbValorado.Location = New System.Drawing.Point(976, 94)
        Me.cbValorado.Name = "cbValorado"
        Me.cbValorado.Size = New System.Drawing.Size(250, 25)
        Me.cbValorado.TabIndex = 11
        Me.cbValorado.Text = "VALORADO SIN TOTALES"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(725, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 17)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "TRANSPORTE"
        '
        'cbTransporte
        '
        Me.cbTransporte.DropDownWidth = 225
        Me.cbTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTransporte.FormattingEnabled = True
        Me.cbTransporte.Location = New System.Drawing.Point(813, 124)
        Me.cbTransporte.Name = "cbTransporte"
        Me.cbTransporte.Size = New System.Drawing.Size(180, 25)
        Me.cbTransporte.TabIndex = 15
        '
        'bEstatus
        '
        Me.bEstatus.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEstatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bEstatus.Location = New System.Drawing.Point(1199, 31)
        Me.bEstatus.Name = "bEstatus"
        Me.bEstatus.Size = New System.Drawing.Size(27, 25)
        Me.bEstatus.TabIndex = 6
        Me.bEstatus.Text = "...."
        Me.bEstatus.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label40.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(251, 98)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(99, 17)
        Me.Label40.TabIndex = 192
        Me.Label40.Text = "RECIBIDO POR"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label49.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label49.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label49.Location = New System.Drawing.Point(882, 35)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(54, 17)
        Me.Label49.TabIndex = 192
        Me.Label49.Text = "ESTATUS"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(739, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 34)
        Me.Label9.TabIndex = 186
        Me.Label9.Text = "NOTA IMPRESA"
        '
        'cbPersona
        '
        Me.cbPersona.DropDownWidth = 225
        Me.cbPersona.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPersona.FormattingEnabled = True
        Me.cbPersona.Location = New System.Drawing.Point(364, 94)
        Me.cbPersona.Name = "cbPersona"
        Me.cbPersona.Size = New System.Drawing.Size(180, 25)
        Me.cbPersona.TabIndex = 9
        '
        'bNuevoCliente
        '
        Me.bNuevoCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bNuevoCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevoCliente.Location = New System.Drawing.Point(332, 31)
        Me.bNuevoCliente.Name = "bNuevoCliente"
        Me.bNuevoCliente.Size = New System.Drawing.Size(27, 25)
        Me.bNuevoCliente.TabIndex = 0
        Me.bNuevoCliente.UseVisualStyleBackColor = True
        Me.bNuevoCliente.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbNumDoc)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.numDoc)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.lbNumDoc1)
        Me.GroupBox4.Controls.Add(Me.RefCliente)
        Me.GroupBox4.Controls.Add(Me.numOferta)
        Me.GroupBox4.Controls.Add(Me.numProforma)
        Me.GroupBox4.Controls.Add(Me.numPedido)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.GroupBox4.Size = New System.Drawing.Size(241, 167)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'lbNumDoc
        '
        Me.lbNumDoc.AutoSize = True
        Me.lbNumDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc.Location = New System.Drawing.Point(5, 22)
        Me.lbNumDoc.Name = "lbNumDoc"
        Me.lbNumDoc.Size = New System.Drawing.Size(131, 19)
        Me.lbNumDoc.TabIndex = 115
        Me.lbNumDoc.Text = "Nº REPARACIÓN"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(5, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 17)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "REF. CLIENTE"
        '
        'numDoc
        '
        Me.numDoc.BackColor = System.Drawing.SystemColors.Window
        Me.numDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.numDoc.Location = New System.Drawing.Point(138, 18)
        Me.numDoc.MaxLength = 15
        Me.numDoc.Name = "numDoc"
        Me.numDoc.ReadOnly = True
        Me.numDoc.Size = New System.Drawing.Size(90, 27)
        Me.numDoc.TabIndex = 0
        Me.numDoc.TabStop = False
        Me.numDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(5, 141)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 17)
        Me.Label15.TabIndex = 115
        Me.Label15.Text = "Nº OFERTA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(5, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 17)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Nº PROFORMA"
        '
        'lbNumDoc1
        '
        Me.lbNumDoc1.AutoSize = True
        Me.lbNumDoc1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc1.Location = New System.Drawing.Point(5, 83)
        Me.lbNumDoc1.Name = "lbNumDoc1"
        Me.lbNumDoc1.Size = New System.Drawing.Size(76, 17)
        Me.lbNumDoc1.TabIndex = 115
        Me.lbNumDoc1.Text = "Nº PEDIDO"
        '
        'RefCliente
        '
        Me.RefCliente.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente.Location = New System.Drawing.Point(138, 51)
        Me.RefCliente.MaxLength = 20
        Me.RefCliente.Name = "RefCliente"
        Me.RefCliente.Size = New System.Drawing.Size(90, 23)
        Me.RefCliente.TabIndex = 1
        Me.RefCliente.TabStop = False
        Me.RefCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numOferta
        '
        Me.numOferta.BackColor = System.Drawing.SystemColors.Window
        Me.numOferta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numOferta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numOferta.Location = New System.Drawing.Point(138, 138)
        Me.numOferta.MaxLength = 15
        Me.numOferta.Name = "numOferta"
        Me.numOferta.ReadOnly = True
        Me.numOferta.Size = New System.Drawing.Size(90, 23)
        Me.numOferta.TabIndex = 4
        Me.numOferta.TabStop = False
        Me.numOferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numProforma
        '
        Me.numProforma.BackColor = System.Drawing.SystemColors.Window
        Me.numProforma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numProforma.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numProforma.Location = New System.Drawing.Point(138, 109)
        Me.numProforma.MaxLength = 15
        Me.numProforma.Name = "numProforma"
        Me.numProforma.ReadOnly = True
        Me.numProforma.Size = New System.Drawing.Size(90, 23)
        Me.numProforma.TabIndex = 3
        Me.numProforma.TabStop = False
        Me.numProforma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numPedido.Location = New System.Drawing.Point(138, 80)
        Me.numPedido.MaxLength = 15
        Me.numPedido.Name = "numPedido"
        Me.numPedido.ReadOnly = True
        Me.numPedido.Size = New System.Drawing.Size(90, 23)
        Me.numPedido.TabIndex = 2
        Me.numPedido.TabStop = False
        Me.numPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bMoneda
        '
        Me.bMoneda.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMoneda.Location = New System.Drawing.Point(558, 124)
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.Size = New System.Drawing.Size(27, 25)
        Me.bMoneda.TabIndex = 13
        Me.bMoneda.Text = "...."
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'cbEstatus
        '
        Me.cbEstatus.DropDownWidth = 225
        Me.cbEstatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstatus.FormattingEnabled = True
        Me.cbEstatus.Location = New System.Drawing.Point(976, 31)
        Me.cbEstatus.Name = "cbEstatus"
        Me.cbEstatus.Size = New System.Drawing.Size(204, 25)
        Me.cbEstatus.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1096, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "PRECIO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(589, 98)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 17)
        Me.Label16.TabIndex = 147
        Me.Label16.Text = "TIPO IVA"
        '
        'lbmonedaT
        '
        Me.lbmonedaT.AutoSize = True
        Me.lbmonedaT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmonedaT.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbmonedaT.Location = New System.Drawing.Point(1218, 128)
        Me.lbmonedaT.Name = "lbmonedaT"
        Me.lbmonedaT.Size = New System.Drawing.Size(15, 17)
        Me.lbmonedaT.TabIndex = 174
        Me.lbmonedaT.Text = "€"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(250, 128)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 17)
        Me.Label29.TabIndex = 147
        Me.Label29.Text = "MONEDA"
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Location = New System.Drawing.Point(655, 94)
        Me.cbTipoIVA.Name = "cbTipoIVA"
        Me.cbTipoIVA.Size = New System.Drawing.Size(224, 25)
        Me.cbTipoIVA.TabIndex = 10
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(590, 128)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 17)
        Me.Label31.TabIndex = 147
        Me.Label31.Text = "DTO. P.P."
        '
        'cbMoneda
        '
        Me.cbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(364, 124)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(180, 25)
        Me.cbMoneda.TabIndex = 12
        '
        'cbPortes
        '
        Me.cbPortes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPortes.FormattingEnabled = True
        Me.cbPortes.Location = New System.Drawing.Point(1003, 124)
        Me.cbPortes.Name = "cbPortes"
        Me.cbPortes.Size = New System.Drawing.Size(88, 25)
        Me.cbPortes.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(250, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 17)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "OBSERVACIONES"
        '
        'Nota
        '
        Me.Nota.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nota.Location = New System.Drawing.Point(813, 154)
        Me.Nota.MaxLength = 200
        Me.Nota.Multiline = True
        Me.Nota.Name = "Nota"
        Me.Nota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Nota.Size = New System.Drawing.Size(413, 57)
        Me.Nota.TabIndex = 19
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(364, 154)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(367, 61)
        Me.Observaciones.TabIndex = 18
        '
        'ProntoPago
        '
        Me.ProntoPago.BackColor = System.Drawing.SystemColors.Window
        Me.ProntoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProntoPago.Location = New System.Drawing.Point(656, 125)
        Me.ProntoPago.MaxLength = 6
        Me.ProntoPago.Name = "ProntoPago"
        Me.ProntoPago.Size = New System.Drawing.Size(45, 23)
        Me.ProntoPago.TabIndex = 14
        Me.ProntoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(706, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 17)
        Me.Label5.TabIndex = 145
        Me.Label5.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(882, 68)
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
        'PrecioTransporte
        '
        Me.PrecioTransporte.BackColor = System.Drawing.SystemColors.Window
        Me.PrecioTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioTransporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioTransporte.Location = New System.Drawing.Point(1155, 125)
        Me.PrecioTransporte.MaxLength = 15
        Me.PrecioTransporte.Name = "PrecioTransporte"
        Me.PrecioTransporte.Size = New System.Drawing.Size(62, 23)
        Me.PrecioTransporte.TabIndex = 17
        Me.PrecioTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(250, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "CLIENTE"
        '
        'cbContacto
        '
        Me.cbContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Location = New System.Drawing.Point(976, 63)
        Me.cbContacto.Name = "cbContacto"
        Me.cbContacto.Size = New System.Drawing.Size(251, 25)
        Me.cbContacto.TabIndex = 8
        '
        'cbDireccion
        '
        Me.cbDireccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDireccion.FormattingEnabled = True
        Me.cbDireccion.Location = New System.Drawing.Point(364, 63)
        Me.cbDireccion.Name = "cbDireccion"
        Me.cbDireccion.Size = New System.Drawing.Size(515, 25)
        Me.cbDireccion.TabIndex = 7
        '
        'cbCodCliente
        '
        Me.cbCodCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodCliente.FormattingEnabled = True
        Me.cbCodCliente.Location = New System.Drawing.Point(364, 31)
        Me.cbCodCliente.Name = "cbCodCliente"
        Me.cbCodCliente.Size = New System.Drawing.Size(73, 25)
        Me.cbCodCliente.TabIndex = 1
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(443, 31)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(361, 25)
        Me.cbCliente.TabIndex = 2
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(851, 31)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 4
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarCliente.Location = New System.Drawing.Point(820, 31)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarCliente.TabIndex = 3
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'bTraspasar
        '
        Me.bTraspasar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTraspasar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTraspasar.Location = New System.Drawing.Point(958, 23)
        Me.bTraspasar.Name = "bTraspasar"
        Me.bTraspasar.Size = New System.Drawing.Size(88, 50)
        Me.bTraspasar.TabIndex = 16
        Me.bTraspasar.Text = "CONVERTIR"
        Me.bTraspasar.UseVisualStyleBackColor = True
        '
        'beMail
        '
        Me.beMail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.beMail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.beMail.Location = New System.Drawing.Point(862, 23)
        Me.beMail.Name = "beMail"
        Me.beMail.Size = New System.Drawing.Size(88, 50)
        Me.beMail.TabIndex = 15
        Me.beMail.Text = "E-MAIL"
        Me.beMail.UseVisualStyleBackColor = True
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Control
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(1139, 723)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 26)
        Me.Total.TabIndex = 6
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label44.Location = New System.Drawing.Point(250, 225)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(44, 19)
        Me.Label44.TabIndex = 203
        Me.Label44.Text = "RMA"
        '
        'txRMA
        '
        Me.txRMA.BackColor = System.Drawing.SystemColors.Window
        Me.txRMA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txRMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txRMA.Location = New System.Drawing.Point(364, 223)
        Me.txRMA.MaxLength = 20
        Me.txRMA.Name = "txRMA"
        Me.txRMA.Size = New System.Drawing.Size(367, 23)
        Me.txRMA.TabIndex = 202
        Me.txRMA.TabStop = False
        Me.txRMA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GestionReparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 762)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionReparacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUEVA REPARACIÓN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpDatos.ResumeLayout(False)
        Me.tpDatos.PerformLayout()
        Me.tpProceso.ResumeLayout(False)
        Me.tpProceso.PerformLayout()
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
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
    Friend WithEvents gbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents numDoc As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbNumDoc As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents RefCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents Nota As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents lbNumDoc1 As System.Windows.Forms.Label
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDescuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPVP As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecioNeto As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarArticuloC As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents codArticuloCli As System.Windows.Forms.TextBox
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DescuentoC As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents bTiposArticulo As System.Windows.Forms.Button
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PrecioNeto As System.Windows.Forms.TextBox
    Friend WithEvents PVP As System.Windows.Forms.TextBox
    Friend WithEvents bArticuloCliente As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaS As System.Windows.Forms.Label
    Friend WithEvents lbMonedaN As System.Windows.Forms.Label
    Friend WithEvents lbmonedaC As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents bVerArticuloC As System.Windows.Forms.Button
    Friend WithEvents lvSubTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloCLi As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents cbCodCliente As System.Windows.Forms.ComboBox
    Friend WithEvents ProntoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents bTraspasar As System.Windows.Forms.Button
    Friend WithEvents beMail As System.Windows.Forms.Button
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lvck As System.Windows.Forms.ColumnHeader
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents bNuevoCliente As System.Windows.Forms.Button
    Friend WithEvents bPDF As System.Windows.Forms.Button
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents cbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbmonedaT As System.Windows.Forms.Label
    Friend WithEvents cbPortes As System.Windows.Forms.ComboBox
    Friend WithEvents PrecioTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numProforma As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpDatos As System.Windows.Forms.TabPage
    Friend WithEvents tpProceso As System.Windows.Forms.TabPage
    Friend WithEvents cbArticuloR As System.Windows.Forms.ComboBox
    Friend WithEvents bVerArticuloR As System.Windows.Forms.Button
    Friend WithEvents bBuscarArticuloR As System.Windows.Forms.Button
    Friend WithEvents cbcodArticuloR As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Inspeccion As System.Windows.Forms.TextBox
    Friend WithEvents Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents numSerie As System.Windows.Forms.TextBox
    Friend WithEvents ckGarantia As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TrabajoARealizar As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TrabajoRealizado As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Horas As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents FechaServido As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents cbRealizadoPor As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarEquipo As System.Windows.Forms.Button
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents cbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents bEstatus As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents OtrosTipos As System.Windows.Forms.TextBox
    Friend WithEvents ckOtros As System.Windows.Forms.CheckBox
    Friend WithEvents ckSonda As System.Windows.Forms.CheckBox
    Friend WithEvents ckCaja As System.Windows.Forms.CheckBox
    Friend WithEvents ckCelula As System.Windows.Forms.CheckBox
    Friend WithEvents ckPlaca As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFabricacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbValorado As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numOferta As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda5 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda4 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda3 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Retencion As System.Windows.Forms.TextBox
    Friend WithEvents TotalRE As System.Windows.Forms.TextBox
    Friend WithEvents TotalIVA As System.Windows.Forms.TextBox
    Friend WithEvents BaseImponible As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txPrecioTotalReparacion As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents txRMA As TextBox
End Class
