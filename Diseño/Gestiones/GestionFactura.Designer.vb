<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionFactura1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionFactura1))
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbMoneda6 = New System.Windows.Forms.Label
        Me.lbMoneda5 = New System.Windows.Forms.Label
        Me.lbMoneda4 = New System.Windows.Forms.Label
        Me.lbMoneda3 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.lbMoneda2 = New System.Windows.Forms.Label
        Me.lbMoneda1 = New System.Windows.Forms.Label
        Me.gbConceptos = New System.Windows.Forms.GroupBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.numsSerie = New System.Windows.Forms.TextBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bTiposArticulo = New System.Windows.Forms.Button
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.lbMonedaS = New System.Windows.Forms.Label
        Me.lbMonedaN = New System.Windows.Forms.Label
        Me.lbmonedaC = New System.Windows.Forms.Label
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
        Me.bSubirC = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.lbComision3 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.bBajarC = New System.Windows.Forms.Button
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.ComisionLinea = New System.Windows.Forms.TextBox
        Me.lbComision4 = New System.Windows.Forms.Label
        Me.DescuentoC = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.bBuscarArticuloC = New System.Windows.Forms.Button
        Me.subTotal = New System.Windows.Forms.TextBox
        Me.bArticuloCliente = New System.Windows.Forms.Button
        Me.PrecioNeto = New System.Windows.Forms.TextBox
        Me.codArticuloCli = New System.Windows.Forms.TextBox
        Me.PVP = New System.Windows.Forms.TextBox
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.bVerArticuloC = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.rtbNota = New System.Windows.Forms.RichTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbmonedaT = New System.Windows.Forms.Label
        Me.cbPersona = New System.Windows.Forms.ComboBox
        Me.PrecioTransporte = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lvVencimientos = New System.Windows.Forms.ListView
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvImprte = New System.Windows.Forms.ColumnHeader
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.ComisionGeneral = New System.Windows.Forms.TextBox
        Me.DiaPago1 = New System.Windows.Forms.TextBox
        Me.lbComision2 = New System.Windows.Forms.Label
        Me.DiaPago2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbComision1 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.bNuevoCliente = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbNumDoc = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.numDoc = New System.Windows.Forms.TextBox
        Me.lbNumDoc1 = New System.Windows.Forms.Label
        Me.RefCliente = New System.Windows.Forms.TextBox
        Me.numDoc1 = New System.Windows.Forms.TextBox
        Me.bMoneda = New System.Windows.Forms.Button
        Me.bVerNota = New System.Windows.Forms.Button
        Me.bVencimientos = New System.Windows.Forms.Button
        Me.bTiposPago = New System.Windows.Forms.Button
        Me.bMediosPago = New System.Windows.Forms.Button
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.cbTipoPago = New System.Windows.Forms.ComboBox
        Me.cbRetencion = New System.Windows.Forms.ComboBox
        Me.cbMedioPago = New System.Windows.Forms.ComboBox
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox
        Me.cbCuenta = New System.Windows.Forms.ComboBox
        Me.ckRecargoEquivalencia = New System.Windows.Forms.CheckBox
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.cbSolicitadoVia = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TipoRecargoEq = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.ProntoPago = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbContacto = New System.Windows.Forms.ComboBox
        Me.cbDireccion = New System.Windows.Forms.ComboBox
        Me.cbCodCliente = New System.Windows.Forms.ComboBox
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.bBuscarCliente = New System.Windows.Forms.Button
        Me.beMail = New System.Windows.Forms.Button
        Me.bPDF = New System.Windows.Forms.Button
        Me.Retencion = New System.Windows.Forms.TextBox
        Me.TotalRE = New System.Windows.Forms.TextBox
        Me.TotalIVA = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.SumaDescuentos = New System.Windows.Forms.TextBox
        Me.BaseImponible = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbConceptos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSubir
        '
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(470, 23)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(88, 22)
        Me.bSubir.TabIndex = 3
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(470, 51)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(88, 22)
        Me.bBajar.TabIndex = 4
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(763, 23)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 50)
        Me.bImprimir.TabIndex = 7
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
        Me.bSalir.Location = New System.Drawing.Point(1152, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 11
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(666, 23)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(88, 50)
        Me.bNuevo.TabIndex = 6
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(569, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(88, 50)
        Me.bGuardar.TabIndex = 5
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(1055, 23)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(88, 50)
        Me.bBorrar.TabIndex = 10
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbMoneda6)
        Me.GroupBox1.Controls.Add(Me.lbMoneda5)
        Me.GroupBox1.Controls.Add(Me.lbMoneda4)
        Me.GroupBox1.Controls.Add(Me.lbMoneda3)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.lbMoneda2)
        Me.GroupBox1.Controls.Add(Me.lbMoneda1)
        Me.GroupBox1.Controls.Add(Me.gbConceptos)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.bSubir)
        Me.GroupBox1.Controls.Add(Me.beMail)
        Me.GroupBox1.Controls.Add(Me.bBorrar)
        Me.GroupBox1.Controls.Add(Me.bBajar)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.bImprimir)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.bPDF)
        Me.GroupBox1.Controls.Add(Me.Retencion)
        Me.GroupBox1.Controls.Add(Me.TotalRE)
        Me.GroupBox1.Controls.Add(Me.TotalIVA)
        Me.GroupBox1.Controls.Add(Me.Total)
        Me.GroupBox1.Controls.Add(Me.SumaDescuentos)
        Me.GroupBox1.Controls.Add(Me.BaseImponible)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 760)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbMoneda6
        '
        Me.lbMoneda6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda6.AutoSize = True
        Me.lbMoneda6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda6.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda6.Location = New System.Drawing.Point(416, 729)
        Me.lbMoneda6.Name = "lbMoneda6"
        Me.lbMoneda6.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda6.TabIndex = 184
        Me.lbMoneda6.Text = "€"
        '
        'lbMoneda5
        '
        Me.lbMoneda5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda5.AutoSize = True
        Me.lbMoneda5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda5.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda5.Location = New System.Drawing.Point(215, 729)
        Me.lbMoneda5.Name = "lbMoneda5"
        Me.lbMoneda5.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda5.TabIndex = 184
        Me.lbMoneda5.Text = "€"
        '
        'lbMoneda4
        '
        Me.lbMoneda4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda4.AutoSize = True
        Me.lbMoneda4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda4.Location = New System.Drawing.Point(617, 729)
        Me.lbMoneda4.Name = "lbMoneda4"
        Me.lbMoneda4.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda4.TabIndex = 184
        Me.lbMoneda4.Text = "€"
        '
        'lbMoneda3
        '
        Me.lbMoneda3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda3.AutoSize = True
        Me.lbMoneda3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda3.Location = New System.Drawing.Point(819, 729)
        Me.lbMoneda3.Name = "lbMoneda3"
        Me.lbMoneda3.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda3.TabIndex = 184
        Me.lbMoneda3.Text = "€"
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(241, 44)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(127, 26)
        Me.cbEstado.TabIndex = 4
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(172, 48)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(65, 18)
        Me.Label57.TabIndex = 115
        Me.Label57.Text = "ESTADO"
        '
        'lbMoneda2
        '
        Me.lbMoneda2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda2.AutoSize = True
        Me.lbMoneda2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda2.Location = New System.Drawing.Point(1021, 729)
        Me.lbMoneda2.Name = "lbMoneda2"
        Me.lbMoneda2.Size = New System.Drawing.Size(15, 17)
        Me.lbMoneda2.TabIndex = 184
        Me.lbMoneda2.Text = "€"
        '
        'lbMoneda1
        '
        Me.lbMoneda1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMoneda1.AutoSize = True
        Me.lbMoneda1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMoneda1.Location = New System.Drawing.Point(1226, 728)
        Me.lbMoneda1.Name = "lbMoneda1"
        Me.lbMoneda1.Size = New System.Drawing.Size(18, 19)
        Me.lbMoneda1.TabIndex = 184
        Me.lbMoneda1.Text = "€"
        '
        'gbConceptos
        '
        Me.gbConceptos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbConceptos.Controls.Add(Me.Label30)
        Me.gbConceptos.Controls.Add(Me.numsSerie)
        Me.gbConceptos.Controls.Add(Me.ckSeleccion)
        Me.gbConceptos.Controls.Add(Me.bLimpiar)
        Me.gbConceptos.Controls.Add(Me.bTiposArticulo)
        Me.gbConceptos.Controls.Add(Me.lbSubTipo)
        Me.gbConceptos.Controls.Add(Me.Label24)
        Me.gbConceptos.Controls.Add(Me.Label39)
        Me.gbConceptos.Controls.Add(Me.Label23)
        Me.gbConceptos.Controls.Add(Me.lbTipo)
        Me.gbConceptos.Controls.Add(Me.cbSubTipo)
        Me.gbConceptos.Controls.Add(Me.cbTipo)
        Me.gbConceptos.Controls.Add(Me.lbMonedaS)
        Me.gbConceptos.Controls.Add(Me.lbMonedaN)
        Me.gbConceptos.Controls.Add(Me.lbmonedaC)
        Me.gbConceptos.Controls.Add(Me.lbUnidad)
        Me.gbConceptos.Controls.Add(Me.lvConceptos)
        Me.gbConceptos.Controls.Add(Me.bSubirC)
        Me.gbConceptos.Controls.Add(Me.Label22)
        Me.gbConceptos.Controls.Add(Me.lbComision3)
        Me.gbConceptos.Controls.Add(Me.Label38)
        Me.gbConceptos.Controls.Add(Me.bBajarC)
        Me.gbConceptos.Controls.Add(Me.Label27)
        Me.gbConceptos.Controls.Add(Me.Label26)
        Me.gbConceptos.Controls.Add(Me.Label20)
        Me.gbConceptos.Controls.Add(Me.cbArticulo)
        Me.gbConceptos.Controls.Add(Me.ComisionLinea)
        Me.gbConceptos.Controls.Add(Me.lbComision4)
        Me.gbConceptos.Controls.Add(Me.DescuentoC)
        Me.gbConceptos.Controls.Add(Me.Label21)
        Me.gbConceptos.Controls.Add(Me.cbCodArticulo)
        Me.gbConceptos.Controls.Add(Me.bBuscarArticuloC)
        Me.gbConceptos.Controls.Add(Me.subTotal)
        Me.gbConceptos.Controls.Add(Me.bArticuloCliente)
        Me.gbConceptos.Controls.Add(Me.PrecioNeto)
        Me.gbConceptos.Controls.Add(Me.codArticuloCli)
        Me.gbConceptos.Controls.Add(Me.PVP)
        Me.gbConceptos.Controls.Add(Me.Cantidad)
        Me.gbConceptos.Controls.Add(Me.bVerArticuloC)
        Me.gbConceptos.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConceptos.Location = New System.Drawing.Point(12, 331)
        Me.gbConceptos.Name = "gbConceptos"
        Me.gbConceptos.Size = New System.Drawing.Size(1243, 383)
        Me.gbConceptos.TabIndex = 2
        Me.gbConceptos.TabStop = False
        Me.gbConceptos.Text = "CONCEPTOS"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(16, 83)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(57, 17)
        Me.Label30.TabIndex = 186
        Me.Label30.Text = "N. SERIE"
        '
        'numsSerie
        '
        Me.numsSerie.BackColor = System.Drawing.SystemColors.Window
        Me.numsSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numsSerie.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numsSerie.Location = New System.Drawing.Point(82, 80)
        Me.numsSerie.MaxLength = 300
        Me.numsSerie.Name = "numsSerie"
        Me.numsSerie.Size = New System.Drawing.Size(982, 23)
        Me.numsSerie.TabIndex = 15
        Me.numsSerie.TabStop = False
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(13, 115)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 19
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1206, 79)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 18
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bTiposArticulo
        '
        Me.bTiposArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposArticulo.Location = New System.Drawing.Point(260, 21)
        Me.bTiposArticulo.Name = "bTiposArticulo"
        Me.bTiposArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bTiposArticulo.TabIndex = 2
        Me.bTiposArticulo.Text = "...."
        Me.bTiposArticulo.UseVisualStyleBackColor = True
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(16, 55)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(56, 17)
        Me.lbSubTipo.TabIndex = 180
        Me.lbSubTipo.Text = "SUBTIPO"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(492, 25)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 17)
        Me.Label24.TabIndex = 179
        Me.Label24.Text = "ARTICULO/CLI"
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
        Me.Label23.Location = New System.Drawing.Point(290, 25)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 17)
        Me.Label23.TabIndex = 179
        Me.Label23.Text = "CÓDIGO"
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(16, 25)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(35, 17)
        Me.lbTipo.TabIndex = 179
        Me.lbTipo.Text = "TIPO"
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(82, 51)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(164, 25)
        Me.cbSubTipo.TabIndex = 1
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(82, 21)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(164, 25)
        Me.cbTipo.TabIndex = 0
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
        'lbmonedaC
        '
        Me.lbmonedaC.AutoSize = True
        Me.lbmonedaC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmonedaC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbmonedaC.Location = New System.Drawing.Point(1065, 25)
        Me.lbmonedaC.Name = "lbmonedaC"
        Me.lbmonedaC.Size = New System.Drawing.Size(15, 17)
        Me.lbmonedaC.TabIndex = 174
        Me.lbmonedaC.Text = "€"
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
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvck, Me.lvidConcepto, Me.lvcodArticulo, Me.lvcodArticuloCLi, Me.lvArticulo, Me.lvCantidad, Me.lvPVP, Me.lvDescuento, Me.lvPrecioNeto, Me.lvSubTotal})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(6, 109)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(1227, 267)
        Me.lvConceptos.TabIndex = 20
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
        Me.lvArticulo.Width = 461
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
        Me.lvDescuento.Width = 90
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
        'bSubirC
        '
        Me.bSubirC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubirC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubirC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubirC.Location = New System.Drawing.Point(1116, 79)
        Me.bSubirC.Name = "bSubirC"
        Me.bSubirC.Size = New System.Drawing.Size(27, 25)
        Me.bSubirC.TabIndex = 16
        Me.bSubirC.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(800, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 17)
        Me.Label22.TabIndex = 147
        Me.Label22.Text = "DESCUENTO"
        '
        'lbComision3
        '
        Me.lbComision3.AutoSize = True
        Me.lbComision3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbComision3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbComision3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbComision3.Location = New System.Drawing.Point(1082, 25)
        Me.lbComision3.Name = "lbComision3"
        Me.lbComision3.Size = New System.Drawing.Size(74, 17)
        Me.lbComision3.TabIndex = 147
        Me.lbComision3.Text = "COMISIÓN"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(1082, 55)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 17)
        Me.Label38.TabIndex = 147
        Me.Label38.Text = "SUBTOTAL"
        '
        'bBajarC
        '
        Me.bBajarC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajarC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajarC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajarC.Location = New System.Drawing.Point(1149, 79)
        Me.bBajarC.Name = "bBajarC"
        Me.bBajarC.Size = New System.Drawing.Size(27, 25)
        Me.bBajarC.TabIndex = 17
        Me.bBajarC.UseVisualStyleBackColor = True
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
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(952, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 17)
        Me.Label26.TabIndex = 147
        Me.Label26.Text = "PVP"
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
        Me.cbArticulo.TabIndex = 4
        '
        'ComisionLinea
        '
        Me.ComisionLinea.BackColor = System.Drawing.SystemColors.Window
        Me.ComisionLinea.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComisionLinea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComisionLinea.Location = New System.Drawing.Point(1162, 22)
        Me.ComisionLinea.MaxLength = 6
        Me.ComisionLinea.Name = "ComisionLinea"
        Me.ComisionLinea.Size = New System.Drawing.Size(57, 23)
        Me.ComisionLinea.TabIndex = 13
        Me.ComisionLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbComision4
        '
        Me.lbComision4.AutoSize = True
        Me.lbComision4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbComision4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbComision4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbComision4.Location = New System.Drawing.Point(1221, 25)
        Me.lbComision4.Name = "lbComision4"
        Me.lbComision4.Size = New System.Drawing.Size(18, 17)
        Me.lbComision4.TabIndex = 145
        Me.lbComision4.Text = "%"
        '
        'DescuentoC
        '
        Me.DescuentoC.BackColor = System.Drawing.SystemColors.Window
        Me.DescuentoC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescuentoC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DescuentoC.Location = New System.Drawing.Point(883, 22)
        Me.DescuentoC.MaxLength = 6
        Me.DescuentoC.Name = "DescuentoC"
        Me.DescuentoC.Size = New System.Drawing.Size(45, 23)
        Me.DescuentoC.TabIndex = 9
        Me.DescuentoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(930, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(18, 17)
        Me.Label21.TabIndex = 145
        Me.Label21.Text = "%"
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(364, 21)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(124, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 3
        '
        'bBuscarArticuloC
        '
        Me.bBuscarArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticuloC.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
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
        Me.subTotal.TabIndex = 14
        Me.subTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bArticuloCliente
        '
        Me.bArticuloCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bArticuloCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.data_sort
        Me.bArticuloCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bArticuloCliente.Location = New System.Drawing.Point(747, 21)
        Me.bArticuloCliente.Name = "bArticuloCliente"
        Me.bArticuloCliente.Size = New System.Drawing.Size(27, 25)
        Me.bArticuloCliente.TabIndex = 6
        Me.bArticuloCliente.UseVisualStyleBackColor = True
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
        Me.PrecioNeto.TabIndex = 12
        Me.PrecioNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'codArticuloCli
        '
        Me.codArticuloCli.BackColor = System.Drawing.SystemColors.Window
        Me.codArticuloCli.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticuloCli.ForeColor = System.Drawing.SystemColors.WindowText
        Me.codArticuloCli.Location = New System.Drawing.Point(587, 22)
        Me.codArticuloCli.MaxLength = 15
        Me.codArticuloCli.Name = "codArticuloCli"
        Me.codArticuloCli.Size = New System.Drawing.Size(147, 23)
        Me.codArticuloCli.TabIndex = 5
        Me.codArticuloCli.TabStop = False
        '
        'PVP
        '
        Me.PVP.BackColor = System.Drawing.SystemColors.Window
        Me.PVP.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PVP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PVP.Location = New System.Drawing.Point(994, 22)
        Me.PVP.MaxLength = 15
        Me.PVP.Name = "PVP"
        Me.PVP.ReadOnly = True
        Me.PVP.Size = New System.Drawing.Size(70, 23)
        Me.PVP.TabIndex = 11
        Me.PVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Cantidad.TabIndex = 10
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bVerArticuloC
        '
        Me.bVerArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloC.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticuloC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloC.Location = New System.Drawing.Point(777, 51)
        Me.bVerArticuloC.Name = "bVerArticuloC"
        Me.bVerArticuloC.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloC.TabIndex = 8
        Me.bVerArticuloC.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(859, 729)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 17)
        Me.Label18.TabIndex = 147
        Me.Label18.Text = "RETENCIÓN"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(665, 729)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 17)
        Me.Label17.TabIndex = 147
        Me.Label17.Text = "TOTAL R.E."
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(466, 729)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 17)
        Me.Label15.TabIndex = 147
        Me.Label15.Text = "TOTAL IVA"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(1074, 728)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 19)
        Me.Label19.TabIndex = 147
        Me.Label19.Text = "TOTAL"
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(240, 729)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 17)
        Me.Label25.TabIndex = 147
        Me.Label25.Text = " DESCUENTOS"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(22, 729)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 17)
        Me.Label14.TabIndex = 147
        Me.Label14.Text = "BASE IMPONIBLE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.rtbNota)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lbmonedaT)
        Me.GroupBox2.Controls.Add(Me.cbPersona)
        Me.GroupBox2.Controls.Add(Me.PrecioTransporte)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lvVencimientos)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.ComisionGeneral)
        Me.GroupBox2.Controls.Add(Me.DiaPago1)
        Me.GroupBox2.Controls.Add(Me.lbComision2)
        Me.GroupBox2.Controls.Add(Me.DiaPago2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lbComision1)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.bNuevoCliente)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.bMoneda)
        Me.GroupBox2.Controls.Add(Me.bVerNota)
        Me.GroupBox2.Controls.Add(Me.bVencimientos)
        Me.GroupBox2.Controls.Add(Me.bTiposPago)
        Me.GroupBox2.Controls.Add(Me.bMediosPago)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.cbTipoPago)
        Me.GroupBox2.Controls.Add(Me.cbRetencion)
        Me.GroupBox2.Controls.Add(Me.cbMedioPago)
        Me.GroupBox2.Controls.Add(Me.cbTipoIVA)
        Me.GroupBox2.Controls.Add(Me.cbCuenta)
        Me.GroupBox2.Controls.Add(Me.ckRecargoEquivalencia)
        Me.GroupBox2.Controls.Add(Me.cbMoneda)
        Me.GroupBox2.Controls.Add(Me.cbSolicitadoVia)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TipoRecargoEq)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Observaciones)
        Me.GroupBox2.Controls.Add(Me.ProntoPago)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbContacto)
        Me.GroupBox2.Controls.Add(Me.cbDireccion)
        Me.GroupBox2.Controls.Add(Me.cbCodCliente)
        Me.GroupBox2.Controls.Add(Me.cbCliente)
        Me.GroupBox2.Controls.Add(Me.bVerCliente)
        Me.GroupBox2.Controls.Add(Me.bBuscarCliente)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1243, 253)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS GENERALES"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label40.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(14, 129)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(85, 17)
        Me.Label40.TabIndex = 192
        Me.Label40.Text = "COMERCIAL"
        '
        'rtbNota
        '
        Me.rtbNota.Font = New System.Drawing.Font("Gill Sans MT Condensed", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbNota.Location = New System.Drawing.Point(801, 190)
        Me.rtbNota.MaxLength = 2000
        Me.rtbNota.Name = "rtbNota"
        Me.rtbNota.ReadOnly = True
        Me.rtbNota.Size = New System.Drawing.Size(398, 57)
        Me.rtbNota.TabIndex = 26
        Me.rtbNota.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(714, 159)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 17)
        Me.Label12.TabIndex = 191
        Me.Label12.Text = "TRANSPORTE"
        '
        'lbmonedaT
        '
        Me.lbmonedaT.AutoSize = True
        Me.lbmonedaT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmonedaT.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbmonedaT.Location = New System.Drawing.Point(862, 159)
        Me.lbmonedaT.Name = "lbmonedaT"
        Me.lbmonedaT.Size = New System.Drawing.Size(15, 17)
        Me.lbmonedaT.TabIndex = 192
        Me.lbmonedaT.Text = "€"
        '
        'cbPersona
        '
        Me.cbPersona.DropDownWidth = 225
        Me.cbPersona.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPersona.FormattingEnabled = True
        Me.cbPersona.Location = New System.Drawing.Point(124, 125)
        Me.cbPersona.Name = "cbPersona"
        Me.cbPersona.Size = New System.Drawing.Size(123, 25)
        Me.cbPersona.TabIndex = 29
        '
        'PrecioTransporte
        '
        Me.PrecioTransporte.BackColor = System.Drawing.SystemColors.Window
        Me.PrecioTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioTransporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioTransporte.Location = New System.Drawing.Point(800, 156)
        Me.PrecioTransporte.MaxLength = 15
        Me.PrecioTransporte.Name = "PrecioTransporte"
        Me.PrecioTransporte.Size = New System.Drawing.Size(62, 23)
        Me.PrecioTransporte.TabIndex = 22
        Me.PrecioTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(586, 159)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 17)
        Me.Label31.TabIndex = 189
        Me.Label31.Text = "DTO. P.P."
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(737, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 34)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "NOTA IMPRESA"
        '
        'lvVencimientos
        '
        Me.lvVencimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvVencimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvFecha, Me.lvImprte})
        Me.lvVencimientos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvVencimientos.FullRowSelect = True
        Me.lvVencimientos.GridLines = True
        Me.lvVencimientos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvVencimientos.Location = New System.Drawing.Point(1003, 123)
        Me.lvVencimientos.MultiSelect = False
        Me.lvVencimientos.Name = "lvVencimientos"
        Me.lvVencimientos.Size = New System.Drawing.Size(195, 65)
        Me.lvVencimientos.TabIndex = 17
        Me.lvVencimientos.UseCompatibleStateImageBehavior = False
        Me.lvVencimientos.View = System.Windows.Forms.View.Details
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 88
        '
        'lvImprte
        '
        Me.lvImprte.Text = "IMPORTE"
        Me.lvImprte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImprte.Width = 85
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(888, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 17)
        Me.Label11.TabIndex = 187
        Me.Label11.Text = "D. PAGO"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(879, 129)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(31, 17)
        Me.Label32.TabIndex = 146
        Me.Label32.Text = "R.E."
        '
        'ComisionGeneral
        '
        Me.ComisionGeneral.BackColor = System.Drawing.SystemColors.Window
        Me.ComisionGeneral.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComisionGeneral.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComisionGeneral.Location = New System.Drawing.Point(124, 156)
        Me.ComisionGeneral.MaxLength = 6
        Me.ComisionGeneral.Name = "ComisionGeneral"
        Me.ComisionGeneral.ReadOnly = True
        Me.ComisionGeneral.Size = New System.Drawing.Size(90, 23)
        Me.ComisionGeneral.TabIndex = 30
        Me.ComisionGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DiaPago1
        '
        Me.DiaPago1.BackColor = System.Drawing.SystemColors.Control
        Me.DiaPago1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiaPago1.Location = New System.Drawing.Point(953, 156)
        Me.DiaPago1.MaxLength = 4
        Me.DiaPago1.Name = "DiaPago1"
        Me.DiaPago1.ReadOnly = True
        Me.DiaPago1.Size = New System.Drawing.Size(22, 23)
        Me.DiaPago1.TabIndex = 23
        Me.DiaPago1.Text = "31"
        Me.DiaPago1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbComision2
        '
        Me.lbComision2.AutoSize = True
        Me.lbComision2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbComision2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbComision2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbComision2.Location = New System.Drawing.Point(219, 159)
        Me.lbComision2.Name = "lbComision2"
        Me.lbComision2.Size = New System.Drawing.Size(18, 17)
        Me.lbComision2.TabIndex = 145
        Me.lbComision2.Text = "%"
        '
        'DiaPago2
        '
        Me.DiaPago2.BackColor = System.Drawing.SystemColors.Control
        Me.DiaPago2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiaPago2.Location = New System.Drawing.Point(976, 156)
        Me.DiaPago2.MaxLength = 4
        Me.DiaPago2.Name = "DiaPago2"
        Me.DiaPago2.ReadOnly = True
        Me.DiaPago2.Size = New System.Drawing.Size(22, 23)
        Me.DiaPago2.TabIndex = 24
        Me.DiaPago2.Text = "31"
        Me.DiaPago2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(968, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "VTOs"
        '
        'lbComision1
        '
        Me.lbComision1.AutoSize = True
        Me.lbComision1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbComision1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbComision1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbComision1.Location = New System.Drawing.Point(14, 159)
        Me.lbComision1.Name = "lbComision1"
        Me.lbComision1.Size = New System.Drawing.Size(74, 17)
        Me.lbComision1.TabIndex = 147
        Me.lbComision1.Text = "COMISIÓN"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 189)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(241, 46)
        Me.GroupBox5.TabIndex = 31
        Me.GroupBox5.TabStop = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(118, 16)
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
        Me.Label13.Location = New System.Drawing.Point(5, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 17)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "FECHA FACTURA"
        '
        'bNuevoCliente
        '
        Me.bNuevoCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevoCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bNuevoCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevoCliente.Location = New System.Drawing.Point(332, 32)
        Me.bNuevoCliente.Name = "bNuevoCliente"
        Me.bNuevoCliente.Size = New System.Drawing.Size(27, 25)
        Me.bNuevoCliente.TabIndex = 5
        Me.bNuevoCliente.UseVisualStyleBackColor = True
        Me.bNuevoCliente.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbNumDoc)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.numDoc)
        Me.GroupBox4.Controls.Add(Me.lbNumDoc1)
        Me.GroupBox4.Controls.Add(Me.RefCliente)
        Me.GroupBox4.Controls.Add(Me.numDoc1)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(242, 104)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        '
        'lbNumDoc
        '
        Me.lbNumDoc.AutoSize = True
        Me.lbNumDoc.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc.Location = New System.Drawing.Point(13, 19)
        Me.lbNumDoc.Name = "lbNumDoc"
        Me.lbNumDoc.Size = New System.Drawing.Size(101, 19)
        Me.lbNumDoc.TabIndex = 115
        Me.lbNumDoc.Text = "Nº FACTURA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(13, 52)
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
        Me.numDoc.Location = New System.Drawing.Point(121, 16)
        Me.numDoc.MaxLength = 15
        Me.numDoc.Name = "numDoc"
        Me.numDoc.ReadOnly = True
        Me.numDoc.Size = New System.Drawing.Size(90, 27)
        Me.numDoc.TabIndex = 0
        Me.numDoc.TabStop = False
        Me.numDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbNumDoc1
        '
        Me.lbNumDoc1.AutoSize = True
        Me.lbNumDoc1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumDoc1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbNumDoc1.Location = New System.Drawing.Point(13, 83)
        Me.lbNumDoc1.Name = "lbNumDoc1"
        Me.lbNumDoc1.Size = New System.Drawing.Size(85, 17)
        Me.lbNumDoc1.TabIndex = 115
        Me.lbNumDoc1.Text = "Nº ALBARÁN"
        '
        'RefCliente
        '
        Me.RefCliente.BackColor = System.Drawing.SystemColors.Window
        Me.RefCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RefCliente.Location = New System.Drawing.Point(121, 47)
        Me.RefCliente.MaxLength = 20
        Me.RefCliente.Name = "RefCliente"
        Me.RefCliente.Size = New System.Drawing.Size(90, 23)
        Me.RefCliente.TabIndex = 1
        Me.RefCliente.TabStop = False
        Me.RefCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numDoc1
        '
        Me.numDoc1.BackColor = System.Drawing.SystemColors.Control
        Me.numDoc1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numDoc1.Location = New System.Drawing.Point(121, 74)
        Me.numDoc1.MaxLength = 15
        Me.numDoc1.Name = "numDoc1"
        Me.numDoc1.ReadOnly = True
        Me.numDoc1.Size = New System.Drawing.Size(90, 23)
        Me.numDoc1.TabIndex = 2
        Me.numDoc1.TabStop = False
        Me.numDoc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bMoneda
        '
        Me.bMoneda.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMoneda.Location = New System.Drawing.Point(558, 155)
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.Size = New System.Drawing.Size(27, 25)
        Me.bMoneda.TabIndex = 20
        Me.bMoneda.Text = "...."
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'bVerNota
        '
        Me.bVerNota.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerNota.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerNota.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerNota.Location = New System.Drawing.Point(1206, 189)
        Me.bVerNota.Name = "bVerNota"
        Me.bVerNota.Size = New System.Drawing.Size(27, 25)
        Me.bVerNota.TabIndex = 27
        Me.bVerNota.UseVisualStyleBackColor = True
        '
        'bVencimientos
        '
        Me.bVencimientos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVencimientos.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVencimientos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVencimientos.Location = New System.Drawing.Point(1206, 123)
        Me.bVencimientos.Name = "bVencimientos"
        Me.bVencimientos.Size = New System.Drawing.Size(27, 25)
        Me.bVencimientos.TabIndex = 18
        Me.bVencimientos.UseVisualStyleBackColor = True
        '
        'bTiposPago
        '
        Me.bTiposPago.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposPago.Location = New System.Drawing.Point(558, 125)
        Me.bTiposPago.Name = "bTiposPago"
        Me.bTiposPago.Size = New System.Drawing.Size(27, 25)
        Me.bTiposPago.TabIndex = 13
        Me.bTiposPago.Text = "...."
        Me.bTiposPago.UseVisualStyleBackColor = True
        '
        'bMediosPago
        '
        Me.bMediosPago.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMediosPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMediosPago.Location = New System.Drawing.Point(558, 94)
        Me.bMediosPago.Name = "bMediosPago"
        Me.bMediosPago.Size = New System.Drawing.Size(27, 25)
        Me.bMediosPago.TabIndex = 9
        Me.bMediosPago.Text = "...."
        Me.bMediosPago.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(268, 129)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(78, 17)
        Me.Label34.TabIndex = 146
        Me.Label34.Text = "TIPO PAGO"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(893, 98)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 17)
        Me.Label28.TabIndex = 146
        Me.Label28.Text = "RETENCIÓN"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label36.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(589, 98)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(58, 17)
        Me.Label36.TabIndex = 146
        Me.Label36.Text = "CUENTA"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(268, 98)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 17)
        Me.Label33.TabIndex = 147
        Me.Label33.Text = "MEDIO PAGO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(589, 129)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 17)
        Me.Label16.TabIndex = 147
        Me.Label16.Text = "TIPO IVA"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(268, 159)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 17)
        Me.Label29.TabIndex = 147
        Me.Label29.Text = "MONEDA"
        '
        'cbTipoPago
        '
        Me.cbTipoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoPago.FormattingEnabled = True
        Me.cbTipoPago.Location = New System.Drawing.Point(364, 125)
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.Size = New System.Drawing.Size(180, 25)
        Me.cbTipoPago.TabIndex = 12
        '
        'cbRetencion
        '
        Me.cbRetencion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRetencion.FormattingEnabled = True
        Me.cbRetencion.Location = New System.Drawing.Point(1003, 93)
        Me.cbRetencion.Name = "cbRetencion"
        Me.cbRetencion.Size = New System.Drawing.Size(230, 25)
        Me.cbRetencion.TabIndex = 11
        '
        'cbMedioPago
        '
        Me.cbMedioPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMedioPago.FormattingEnabled = True
        Me.cbMedioPago.Location = New System.Drawing.Point(364, 94)
        Me.cbMedioPago.Name = "cbMedioPago"
        Me.cbMedioPago.Size = New System.Drawing.Size(180, 25)
        Me.cbMedioPago.TabIndex = 8
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Location = New System.Drawing.Point(653, 125)
        Me.cbTipoIVA.Name = "cbTipoIVA"
        Me.cbTipoIVA.Size = New System.Drawing.Size(209, 25)
        Me.cbTipoIVA.TabIndex = 14
        '
        'cbCuenta
        '
        Me.cbCuenta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCuenta.FormattingEnabled = True
        Me.cbCuenta.Location = New System.Drawing.Point(653, 94)
        Me.cbCuenta.Name = "cbCuenta"
        Me.cbCuenta.Size = New System.Drawing.Size(209, 25)
        Me.cbCuenta.TabIndex = 10
        '
        'ckRecargoEquivalencia
        '
        Me.ckRecargoEquivalencia.AutoSize = True
        Me.ckRecargoEquivalencia.Enabled = False
        Me.ckRecargoEquivalencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckRecargoEquivalencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRecargoEquivalencia.Location = New System.Drawing.Point(864, 130)
        Me.ckRecargoEquivalencia.Name = "ckRecargoEquivalencia"
        Me.ckRecargoEquivalencia.Size = New System.Drawing.Size(15, 14)
        Me.ckRecargoEquivalencia.TabIndex = 15
        Me.ckRecargoEquivalencia.UseVisualStyleBackColor = True
        Me.ckRecargoEquivalencia.Visible = False
        '
        'cbMoneda
        '
        Me.cbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(364, 155)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(180, 25)
        Me.cbMoneda.TabIndex = 19
        '
        'cbSolicitadoVia
        '
        Me.cbSolicitadoVia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSolicitadoVia.FormattingEnabled = True
        Me.cbSolicitadoVia.Location = New System.Drawing.Point(1002, 32)
        Me.cbSolicitadoVia.MaxLength = 30
        Me.cbSolicitadoVia.Name = "cbSolicitadoVia"
        Me.cbSolicitadoVia.Size = New System.Drawing.Size(231, 25)
        Me.cbSolicitadoVia.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(893, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "SOLICITADO VÍA"
        '
        'TipoRecargoEq
        '
        Me.TipoRecargoEq.BackColor = System.Drawing.SystemColors.Window
        Me.TipoRecargoEq.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoRecargoEq.Location = New System.Drawing.Point(909, 126)
        Me.TipoRecargoEq.MaxLength = 6
        Me.TipoRecargoEq.Name = "TipoRecargoEq"
        Me.TipoRecargoEq.ReadOnly = True
        Me.TipoRecargoEq.Size = New System.Drawing.Size(40, 23)
        Me.TipoRecargoEq.TabIndex = 16
        Me.TipoRecargoEq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(250, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 17)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "OBSERVACIONES"
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(364, 190)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Observaciones.Size = New System.Drawing.Size(369, 57)
        Me.Observaciones.TabIndex = 25
        '
        'ProntoPago
        '
        Me.ProntoPago.BackColor = System.Drawing.SystemColors.Window
        Me.ProntoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProntoPago.Location = New System.Drawing.Point(653, 156)
        Me.ProntoPago.MaxLength = 6
        Me.ProntoPago.Name = "ProntoPago"
        Me.ProntoPago.Size = New System.Drawing.Size(45, 23)
        Me.ProntoPago.TabIndex = 21
        Me.ProntoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(950, 129)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(18, 17)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(697, 159)
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
        Me.Label10.Location = New System.Drawing.Point(893, 68)
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
        Me.Label4.Location = New System.Drawing.Point(268, 67)
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
        Me.Label3.Location = New System.Drawing.Point(268, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "CLIENTE"
        '
        'cbContacto
        '
        Me.cbContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Location = New System.Drawing.Point(1002, 63)
        Me.cbContacto.Name = "cbContacto"
        Me.cbContacto.Size = New System.Drawing.Size(231, 25)
        Me.cbContacto.TabIndex = 7
        '
        'cbDireccion
        '
        Me.cbDireccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDireccion.FormattingEnabled = True
        Me.cbDireccion.Location = New System.Drawing.Point(364, 63)
        Me.cbDireccion.Name = "cbDireccion"
        Me.cbDireccion.Size = New System.Drawing.Size(498, 25)
        Me.cbDireccion.TabIndex = 6
        '
        'cbCodCliente
        '
        Me.cbCodCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodCliente.FormattingEnabled = True
        Me.cbCodCliente.Location = New System.Drawing.Point(364, 32)
        Me.cbCodCliente.Name = "cbCodCliente"
        Me.cbCodCliente.Size = New System.Drawing.Size(73, 25)
        Me.cbCodCliente.TabIndex = 0
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(443, 32)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(361, 25)
        Me.cbCliente.TabIndex = 1
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(854, 32)
        Me.bVerCliente.Name = "bVerCliente"
        Me.bVerCliente.Size = New System.Drawing.Size(27, 25)
        Me.bVerCliente.TabIndex = 3
        Me.bVerCliente.UseVisualStyleBackColor = True
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarCliente.Location = New System.Drawing.Point(823, 32)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarCliente.TabIndex = 2
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'beMail
        '
        Me.beMail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.beMail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.beMail.Location = New System.Drawing.Point(860, 23)
        Me.beMail.Name = "beMail"
        Me.beMail.Size = New System.Drawing.Size(88, 50)
        Me.beMail.TabIndex = 8
        Me.beMail.Text = "E-MAIL"
        Me.beMail.UseVisualStyleBackColor = True
        '
        'bPDF
        '
        Me.bPDF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPDF.Location = New System.Drawing.Point(957, 23)
        Me.bPDF.Name = "bPDF"
        Me.bPDF.Size = New System.Drawing.Size(88, 50)
        Me.bPDF.TabIndex = 7
        Me.bPDF.Text = "PDF"
        Me.bPDF.UseVisualStyleBackColor = True
        '
        'Retencion
        '
        Me.Retencion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Retencion.BackColor = System.Drawing.SystemColors.Control
        Me.Retencion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Retencion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Retencion.Location = New System.Drawing.Point(940, 726)
        Me.Retencion.MaxLength = 15
        Me.Retencion.Name = "Retencion"
        Me.Retencion.ReadOnly = True
        Me.Retencion.Size = New System.Drawing.Size(80, 23)
        Me.Retencion.TabIndex = 6
        Me.Retencion.TabStop = False
        Me.Retencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalRE
        '
        Me.TotalRE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalRE.BackColor = System.Drawing.SystemColors.Control
        Me.TotalRE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalRE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalRE.Location = New System.Drawing.Point(738, 726)
        Me.TotalRE.MaxLength = 15
        Me.TotalRE.Name = "TotalRE"
        Me.TotalRE.ReadOnly = True
        Me.TotalRE.Size = New System.Drawing.Size(80, 23)
        Me.TotalRE.TabIndex = 5
        Me.TotalRE.TabStop = False
        Me.TotalRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalIVA
        '
        Me.TotalIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalIVA.BackColor = System.Drawing.SystemColors.Control
        Me.TotalIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalIVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalIVA.Location = New System.Drawing.Point(536, 726)
        Me.TotalIVA.MaxLength = 15
        Me.TotalIVA.Name = "TotalIVA"
        Me.TotalIVA.ReadOnly = True
        Me.TotalIVA.Size = New System.Drawing.Size(80, 23)
        Me.TotalIVA.TabIndex = 4
        Me.TotalIVA.TabStop = False
        Me.TotalIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Control
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(1132, 724)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 27)
        Me.Total.TabIndex = 7
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SumaDescuentos
        '
        Me.SumaDescuentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SumaDescuentos.BackColor = System.Drawing.SystemColors.Control
        Me.SumaDescuentos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumaDescuentos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SumaDescuentos.Location = New System.Drawing.Point(334, 726)
        Me.SumaDescuentos.MaxLength = 15
        Me.SumaDescuentos.Name = "SumaDescuentos"
        Me.SumaDescuentos.ReadOnly = True
        Me.SumaDescuentos.Size = New System.Drawing.Size(80, 23)
        Me.SumaDescuentos.TabIndex = 3
        Me.SumaDescuentos.TabStop = False
        Me.SumaDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BaseImponible
        '
        Me.BaseImponible.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BaseImponible.BackColor = System.Drawing.SystemColors.Control
        Me.BaseImponible.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BaseImponible.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BaseImponible.Location = New System.Drawing.Point(132, 726)
        Me.BaseImponible.MaxLength = 15
        Me.BaseImponible.Name = "BaseImponible"
        Me.BaseImponible.ReadOnly = True
        Me.BaseImponible.Size = New System.Drawing.Size(80, 23)
        Me.BaseImponible.TabIndex = 3
        Me.BaseImponible.TabStop = False
        Me.BaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GestionFactura1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1273, 762)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionFactura1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUEVA FACTURA"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TotalRE As System.Windows.Forms.TextBox
    Friend WithEvents TotalIVA As System.Windows.Forms.TextBox
    Friend WithEvents BaseImponible As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Retencion As System.Windows.Forms.TextBox
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
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents subTotal As System.Windows.Forms.TextBox
    Friend WithEvents lbMonedaS As System.Windows.Forms.Label
    Friend WithEvents lbMonedaN As System.Windows.Forms.Label
    Friend WithEvents lbmonedaC As System.Windows.Forms.Label
    Friend WithEvents bVerArticuloC As System.Windows.Forms.Button
    Friend WithEvents lvSubTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloCLi As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents SumaDescuentos As System.Windows.Forms.TextBox
    Friend WithEvents beMail As System.Windows.Forms.Button
    Friend WithEvents lbMoneda4 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda3 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda2 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvck As System.Windows.Forms.ColumnHeader
    Friend WithEvents bPDF As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents numsSerie As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda6 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rtbNota As System.Windows.Forms.RichTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbmonedaT As System.Windows.Forms.Label
    Friend WithEvents PrecioTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lvVencimientos As System.Windows.Forms.ListView
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImprte As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DiaPago1 As System.Windows.Forms.TextBox
    Friend WithEvents DiaPago2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bNuevoCliente As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lbNumDoc As System.Windows.Forms.Label
    Friend WithEvents cbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numDoc As System.Windows.Forms.TextBox
    Friend WithEvents lbNumDoc1 As System.Windows.Forms.Label
    Friend WithEvents RefCliente As System.Windows.Forms.TextBox
    Friend WithEvents numDoc1 As System.Windows.Forms.TextBox
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents bVerNota As System.Windows.Forms.Button
    Friend WithEvents bVencimientos As System.Windows.Forms.Button
    Friend WithEvents bTiposPago As System.Windows.Forms.Button
    Friend WithEvents bMediosPago As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents cbRetencion As System.Windows.Forms.ComboBox
    Friend WithEvents cbMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents ckRecargoEquivalencia As System.Windows.Forms.CheckBox
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cbSolicitadoVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TipoRecargoEq As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents ProntoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents cbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ComisionLinea As System.Windows.Forms.TextBox
    Friend WithEvents lbComision4 As System.Windows.Forms.Label
    Friend WithEvents lbComision3 As System.Windows.Forms.Label
    Friend WithEvents ComisionGeneral As System.Windows.Forms.TextBox
    Friend WithEvents lbComision2 As System.Windows.Forms.Label
    Friend WithEvents lbComision1 As System.Windows.Forms.Label
    Friend WithEvents bSubirC As System.Windows.Forms.Button
    Friend WithEvents bBajarC As System.Windows.Forms.Button
End Class
