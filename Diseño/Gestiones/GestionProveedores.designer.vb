<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionProveedores))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.gbCabecera = New System.Windows.Forms.GroupBox
        Me.bTiposProveedor = New System.Windows.Forms.Button
        Me.cbTipoProveedor = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.observaciones = New System.Windows.Forms.TextBox
        Me.lbBaja = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.web = New System.Windows.Forms.TextBox
        Me.nif = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.codProveedor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.suCliente = New System.Windows.Forms.TextBox
        Me.codContable = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.nombrecomercial = New System.Windows.Forms.TextBox
        Me.nombrefiscal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.tbdatos = New System.Windows.Forms.TabControl
        Me.tbUbicaciones = New System.Windows.Forms.TabPage
        Me.bVerPais = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbPortes = New System.Windows.Forms.ComboBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.cbTransporte = New System.Windows.Forms.ComboBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.ckActivoU = New System.Windows.Forms.CheckBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.cbIdioma = New System.Windows.Forms.ComboBox
        Me.cbPaisU = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.dtpFechaBajaU = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaAltaU = New System.Windows.Forms.DateTimePicker
        Me.TelefonoU2 = New System.Windows.Forms.TextBox
        Me.TelefonoU1 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Direccion = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.cbLocalidad = New System.Windows.Forms.ComboBox
        Me.cbProvincia = New System.Windows.Forms.ComboBox
        Me.cbTipoU = New System.Windows.Forms.ComboBox
        Me.lvDirecciones = New System.Windows.Forms.ListView
        Me.lvidUbicacion = New System.Windows.Forms.ColumnHeader
        Me.lvtipo = New System.Windows.Forms.ColumnHeader
        Me.lvdireccion = New System.Windows.Forms.ColumnHeader
        Me.lvcodpostal = New System.Windows.Forms.ColumnHeader
        Me.lvlocalidad = New System.Windows.Forms.ColumnHeader
        Me.lvprovincia = New System.Windows.Forms.ColumnHeader
        Me.lvPais = New System.Windows.Forms.ColumnHeader
        Me.lbBajaU = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.faxU = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.observacioneU = New System.Windows.Forms.TextBox
        Me.HorarioU = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.codPostal = New System.Windows.Forms.TextBox
        Me.emailU = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.tbcontactos = New System.Windows.Forms.TabPage
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.apellidoscontacto = New System.Windows.Forms.TextBox
        Me.MovilContacto = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.TelefonoContacto = New System.Windows.Forms.TextBox
        Me.nombrecontacto = New System.Windows.Forms.TextBox
        Me.emailContacto = New System.Windows.Forms.TextBox
        Me.lvContactos = New System.Windows.Forms.ListView
        Me.lvid = New System.Windows.Forms.ColumnHeader
        Me.lvnombre = New System.Windows.Forms.ColumnHeader
        Me.lvapellidos = New System.Windows.Forms.ColumnHeader
        Me.lvtelefonos = New System.Windows.Forms.ColumnHeader
        Me.lvdepartamento = New System.Windows.Forms.ColumnHeader
        Me.lvcargo = New System.Windows.Forms.ColumnHeader
        Me.lvemail = New System.Windows.Forms.ColumnHeader
        Me.cbDirecciones = New System.Windows.Forms.ComboBox
        Me.cbDepartamento = New System.Windows.Forms.ComboBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.ObservacionesContacto = New System.Windows.Forms.TextBox
        Me.cargocontacto = New System.Windows.Forms.TextBox
        Me.tbfacturacion = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.bTiposIVA = New System.Windows.Forms.Button
        Me.bTiposRetencion = New System.Windows.Forms.Button
        Me.bMoneda = New System.Windows.Forms.Button
        Me.bTiposPago = New System.Windows.Forms.Button
        Me.bMediosPago = New System.Windows.Forms.Button
        Me.ProntoPago = New System.Windows.Forms.TextBox
        Me.Descuento = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbRetencion = New System.Windows.Forms.ComboBox
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox
        Me.gbBancos = New System.Windows.Forms.GroupBox
        Me.ckActivoB = New System.Windows.Forms.CheckBox
        Me.bBancos = New System.Windows.Forms.Button
        Me.bMenosBancos = New System.Windows.Forms.Button
        Me.bLimpiaBanco = New System.Windows.Forms.Button
        Me.bMasBanco = New System.Windows.Forms.Button
        Me.IBAN = New System.Windows.Forms.TextBox
        Me.SWIFT_BIC = New System.Windows.Forms.TextBox
        Me.lvBancos = New System.Windows.Forms.ListView
        Me.lvidCuentaBanco = New System.Windows.Forms.ColumnHeader
        Me.lvBanco = New System.Windows.Forms.ColumnHeader
        Me.lvIBAN = New System.Windows.Forms.ColumnHeader
        Me.lvidBanco = New System.Windows.Forms.ColumnHeader
        Me.lvCodEU = New System.Windows.Forms.ColumnHeader
        Me.lvCodBanco = New System.Windows.Forms.ColumnHeader
        Me.lvcodOficina = New System.Windows.Forms.ColumnHeader
        Me.lvDC = New System.Windows.Forms.ColumnHeader
        Me.lvCuenta = New System.Windows.Forms.ColumnHeader
        Me.lvBIC = New System.Windows.Forms.ColumnHeader
        Me.codigocuenta = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.codigodc = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.codigoEU = New System.Windows.Forms.TextBox
        Me.codigobanco = New System.Windows.Forms.TextBox
        Me.codigooficina = New System.Windows.Forms.TextBox
        Me.cbBanco = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.ckRecargoEquivalencia = New System.Windows.Forms.CheckBox
        Me.RecargoEq = New System.Windows.Forms.TextBox
        Me.ckExentoPagosAgosto = New System.Windows.Forms.CheckBox
        Me.cbMedioPago = New System.Windows.Forms.ComboBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.lbRecargoEq = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.cbDiaPago2 = New System.Windows.Forms.ComboBox
        Me.cbDiaPago1 = New System.Windows.Forms.ComboBox
        Me.ObservacionesF = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbTipoPago = New System.Windows.Forms.ComboBox
        Me.tbArticulos = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbArticuloComprados = New System.Windows.Forms.ComboBox
        Me.ContadorVendidos = New System.Windows.Forms.TextBox
        Me.Label98 = New System.Windows.Forms.Label
        Me.lbCambioVendidos = New System.Windows.Forms.Label
        Me.CantidadVendidos = New System.Windows.Forms.TextBox
        Me.TotalVendidos = New System.Windows.Forms.TextBox
        Me.Label92 = New System.Windows.Forms.Label
        Me.Label85 = New System.Windows.Forms.Label
        Me.Label91 = New System.Windows.Forms.Label
        Me.lbSubTipo = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.cbSubTipo = New System.Windows.Forms.ComboBox
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.lvArticulosComprados = New System.Windows.Forms.ListView
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCodAArticuloCli = New System.Windows.Forms.ColumnHeader
        Me.lvArticuloCli = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.lvDocumento = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.dtpArticulosCompradosHasta = New System.Windows.Forms.DateTimePicker
        Me.dtpArticulosCompradosDesde = New System.Windows.Forms.DateTimePicker
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.gbCabecera.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbdatos.SuspendLayout()
        Me.tbUbicaciones.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbcontactos.SuspendLayout()
        Me.tbfacturacion.SuspendLayout()
        Me.gbBancos.SuspendLayout()
        Me.tbArticulos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.bSubir)
        Me.GroupBox1.Controls.Add(Me.bBajar)
        Me.GroupBox1.Controls.Add(Me.gbCabecera)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.tbdatos)
        Me.GroupBox1.Controls.Add(Me.bNuevo)
        Me.GroupBox1.Controls.Add(Me.bImprimir)
        Me.GroupBox1.Controls.Add(Me.bBorrar)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Location = New System.Drawing.Point(9, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1008, 760)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'bSubir
        '
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = CType(resources.GetObject("bSubir.Image"), System.Drawing.Image)
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(379, 24)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(85, 22)
        Me.bSubir.TabIndex = 2
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = CType(resources.GetObject("bBajar.Image"), System.Drawing.Image)
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(379, 52)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(85, 22)
        Me.bBajar.TabIndex = 3
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.bTiposProveedor)
        Me.gbCabecera.Controls.Add(Me.cbTipoProveedor)
        Me.gbCabecera.Controls.Add(Me.Label1)
        Me.gbCabecera.Controls.Add(Me.ckActivo)
        Me.gbCabecera.Controls.Add(Me.dtpFechaBaja)
        Me.gbCabecera.Controls.Add(Me.dtpFechaAlta)
        Me.gbCabecera.Controls.Add(Me.Label2)
        Me.gbCabecera.Controls.Add(Me.observaciones)
        Me.gbCabecera.Controls.Add(Me.lbBaja)
        Me.gbCabecera.Controls.Add(Me.Label14)
        Me.gbCabecera.Controls.Add(Me.Label12)
        Me.gbCabecera.Controls.Add(Me.Label41)
        Me.gbCabecera.Controls.Add(Me.Label45)
        Me.gbCabecera.Controls.Add(Me.web)
        Me.gbCabecera.Controls.Add(Me.nif)
        Me.gbCabecera.Controls.Add(Me.Label42)
        Me.gbCabecera.Controls.Add(Me.codProveedor)
        Me.gbCabecera.Controls.Add(Me.Label5)
        Me.gbCabecera.Controls.Add(Me.suCliente)
        Me.gbCabecera.Controls.Add(Me.codContable)
        Me.gbCabecera.Controls.Add(Me.Label6)
        Me.gbCabecera.Controls.Add(Me.nombrecomercial)
        Me.gbCabecera.Controls.Add(Me.nombrefiscal)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCabecera.Location = New System.Drawing.Point(12, 80)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(986, 208)
        Me.gbCabecera.TabIndex = 0
        Me.gbCabecera.TabStop = False
        Me.gbCabecera.Text = "DATOS GENERALES"
        '
        'bTiposProveedor
        '
        Me.bTiposProveedor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposProveedor.Location = New System.Drawing.Point(502, 175)
        Me.bTiposProveedor.Name = "bTiposProveedor"
        Me.bTiposProveedor.Size = New System.Drawing.Size(27, 25)
        Me.bTiposProveedor.TabIndex = 11
        Me.bTiposProveedor.Text = "...."
        Me.bTiposProveedor.UseVisualStyleBackColor = True
        '
        'cbTipoProveedor
        '
        Me.cbTipoProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbTipoProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbTipoProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoProveedor.FormattingEnabled = True
        Me.cbTipoProveedor.Location = New System.Drawing.Point(131, 175)
        Me.cbTipoProveedor.Name = "cbTipoProveedor"
        Me.cbTipoProveedor.Size = New System.Drawing.Size(348, 25)
        Me.cbTipoProveedor.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(2, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 17)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "TIPO PROVEEDOR"
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(695, 27)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 3
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBaja.Location = New System.Drawing.Point(863, 27)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaBaja.TabIndex = 4
        Me.dtpFechaBaja.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAlta.Location = New System.Drawing.Point(594, 25)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaAlta.TabIndex = 2
        Me.dtpFechaAlta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(2, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "OBSERVACIONES"
        '
        'observaciones
        '
        Me.observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observaciones.Location = New System.Drawing.Point(131, 114)
        Me.observaciones.MaxLength = 200
        Me.observaciones.Multiline = True
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observaciones.Size = New System.Drawing.Size(827, 56)
        Me.observaciones.TabIndex = 9
        '
        'lbBaja
        '
        Me.lbBaja.AutoSize = True
        Me.lbBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbBaja.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbBaja.Location = New System.Drawing.Point(776, 29)
        Me.lbBaja.Name = "lbBaja"
        Me.lbBaja.Size = New System.Drawing.Size(85, 17)
        Me.lbBaja.TabIndex = 4
        Me.lbBaja.Text = "FECHA BAJA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(785, 179)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 17)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "SU CLIENTE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(216, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 17)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "CÓD.CONTABLE"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(499, 29)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(83, 17)
        Me.Label41.TabIndex = 99
        Me.Label41.Text = "FECHA ALTA"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(2, 59)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(131, 17)
        Me.Label45.TabIndex = 90
        Me.Label45.Text = "NOMBRE COMERCIAL"
        '
        'web
        '
        Me.web.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.web.Location = New System.Drawing.Point(329, 85)
        Me.web.MaxLength = 80
        Me.web.Name = "web"
        Me.web.Size = New System.Drawing.Size(629, 23)
        Me.web.TabIndex = 8
        '
        'nif
        '
        Me.nif.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif.Location = New System.Drawing.Point(131, 85)
        Me.nif.MaxLength = 15
        Me.nif.Name = "nif"
        Me.nif.Size = New System.Drawing.Size(124, 23)
        Me.nif.TabIndex = 7
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(2, 29)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(127, 17)
        Me.Label42.TabIndex = 98
        Me.Label42.Text = "CÓD. PROVEEDOR"
        '
        'codProveedor
        '
        Me.codProveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codProveedor.ForeColor = System.Drawing.Color.DarkRed
        Me.codProveedor.Location = New System.Drawing.Point(131, 27)
        Me.codProveedor.Name = "codProveedor"
        Me.codProveedor.Size = New System.Drawing.Size(67, 23)
        Me.codProveedor.TabIndex = 0
        Me.codProveedor.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(2, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 17)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "NIF / CIF"
        '
        'suCliente
        '
        Me.suCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suCliente.ForeColor = System.Drawing.Color.DarkRed
        Me.suCliente.Location = New System.Drawing.Point(863, 177)
        Me.suCliente.Name = "suCliente"
        Me.suCliente.Size = New System.Drawing.Size(95, 23)
        Me.suCliente.TabIndex = 12
        '
        'codContable
        '
        Me.codContable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codContable.ForeColor = System.Drawing.Color.DarkRed
        Me.codContable.Location = New System.Drawing.Point(329, 26)
        Me.codContable.Name = "codContable"
        Me.codContable.Size = New System.Drawing.Size(150, 23)
        Me.codContable.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(278, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "WEB"
        '
        'nombrecomercial
        '
        Me.nombrecomercial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrecomercial.Location = New System.Drawing.Point(131, 56)
        Me.nombrecomercial.MaxLength = 50
        Me.nombrecomercial.Name = "nombrecomercial"
        Me.nombrecomercial.Size = New System.Drawing.Size(348, 23)
        Me.nombrecomercial.TabIndex = 5
        '
        'nombrefiscal
        '
        Me.nombrefiscal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrefiscal.Location = New System.Drawing.Point(594, 56)
        Me.nombrefiscal.MaxLength = 50
        Me.nombrefiscal.Name = "nombrefiscal"
        Me.nombrefiscal.Size = New System.Drawing.Size(364, 23)
        Me.nombrefiscal.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(485, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 17)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "NOMBRE FISCAL"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(903, 24)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(95, 50)
        Me.bSalir.TabIndex = 8
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'tbdatos
        '
        Me.tbdatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbdatos.CausesValidation = False
        Me.tbdatos.Controls.Add(Me.tbUbicaciones)
        Me.tbdatos.Controls.Add(Me.tbcontactos)
        Me.tbdatos.Controls.Add(Me.tbfacturacion)
        Me.tbdatos.Controls.Add(Me.tbArticulos)
        Me.tbdatos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbdatos.HotTrack = True
        Me.tbdatos.Location = New System.Drawing.Point(12, 293)
        Me.tbdatos.Name = "tbdatos"
        Me.tbdatos.SelectedIndex = 0
        Me.tbdatos.Size = New System.Drawing.Size(990, 457)
        Me.tbdatos.TabIndex = 1
        '
        'tbUbicaciones
        '
        Me.tbUbicaciones.BackColor = System.Drawing.Color.White
        Me.tbUbicaciones.Controls.Add(Me.bVerPais)
        Me.tbUbicaciones.Controls.Add(Me.GroupBox3)
        Me.tbUbicaciones.Controls.Add(Me.ckActivoU)
        Me.tbUbicaciones.Controls.Add(Me.Label38)
        Me.tbUbicaciones.Controls.Add(Me.Label52)
        Me.tbUbicaciones.Controls.Add(Me.cbIdioma)
        Me.tbUbicaciones.Controls.Add(Me.cbPaisU)
        Me.tbUbicaciones.Controls.Add(Me.Label21)
        Me.tbUbicaciones.Controls.Add(Me.dtpFechaBajaU)
        Me.tbUbicaciones.Controls.Add(Me.dtpFechaAltaU)
        Me.tbUbicaciones.Controls.Add(Me.TelefonoU2)
        Me.tbUbicaciones.Controls.Add(Me.TelefonoU1)
        Me.tbUbicaciones.Controls.Add(Me.Label19)
        Me.tbUbicaciones.Controls.Add(Me.Label37)
        Me.tbUbicaciones.Controls.Add(Me.Label44)
        Me.tbUbicaciones.Controls.Add(Me.Direccion)
        Me.tbUbicaciones.Controls.Add(Me.Label33)
        Me.tbUbicaciones.Controls.Add(Me.cbLocalidad)
        Me.tbUbicaciones.Controls.Add(Me.cbProvincia)
        Me.tbUbicaciones.Controls.Add(Me.cbTipoU)
        Me.tbUbicaciones.Controls.Add(Me.lvDirecciones)
        Me.tbUbicaciones.Controls.Add(Me.lbBajaU)
        Me.tbUbicaciones.Controls.Add(Me.Label32)
        Me.tbUbicaciones.Controls.Add(Me.Label23)
        Me.tbUbicaciones.Controls.Add(Me.faxU)
        Me.tbUbicaciones.Controls.Add(Me.Label25)
        Me.tbUbicaciones.Controls.Add(Me.observacioneU)
        Me.tbUbicaciones.Controls.Add(Me.HorarioU)
        Me.tbUbicaciones.Controls.Add(Me.Label31)
        Me.tbUbicaciones.Controls.Add(Me.codPostal)
        Me.tbUbicaciones.Controls.Add(Me.emailU)
        Me.tbUbicaciones.Controls.Add(Me.Label27)
        Me.tbUbicaciones.Controls.Add(Me.Label30)
        Me.tbUbicaciones.Controls.Add(Me.Label29)
        Me.tbUbicaciones.Location = New System.Drawing.Point(4, 26)
        Me.tbUbicaciones.Name = "tbUbicaciones"
        Me.tbUbicaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbUbicaciones.Size = New System.Drawing.Size(982, 427)
        Me.tbUbicaciones.TabIndex = 9
        Me.tbUbicaciones.Text = "DIRECCIONES"
        Me.tbUbicaciones.UseVisualStyleBackColor = True
        '
        'bVerPais
        '
        Me.bVerPais.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerPais.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerPais.Location = New System.Drawing.Point(312, 144)
        Me.bVerPais.Name = "bVerPais"
        Me.bVerPais.Size = New System.Drawing.Size(27, 25)
        Me.bVerPais.TabIndex = 8
        Me.bVerPais.Text = "...."
        Me.bVerPais.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbPortes)
        Me.GroupBox3.Controls.Add(Me.Label60)
        Me.GroupBox3.Controls.Add(Me.cbTransporte)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(712, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(213, 89)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TRANSPORTE"
        '
        'cbPortes
        '
        Me.cbPortes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPortes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPortes.FormattingEnabled = True
        Me.cbPortes.Location = New System.Drawing.Point(85, 20)
        Me.cbPortes.Name = "cbPortes"
        Me.cbPortes.Size = New System.Drawing.Size(118, 25)
        Me.cbPortes.TabIndex = 190
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label60.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label60.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label60.Location = New System.Drawing.Point(7, 23)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(53, 17)
        Me.Label60.TabIndex = 189
        Me.Label60.Text = "PORTES"
        '
        'cbTransporte
        '
        Me.cbTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTransporte.FormattingEnabled = True
        Me.cbTransporte.Location = New System.Drawing.Point(85, 52)
        Me.cbTransporte.Name = "cbTransporte"
        Me.cbTransporte.Size = New System.Drawing.Size(118, 25)
        Me.cbTransporte.TabIndex = 2
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label47.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label47.Location = New System.Drawing.Point(4, 55)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(68, 17)
        Me.Label47.TabIndex = 138
        Me.Label47.Text = "AGENCIA"
        '
        'ckActivoU
        '
        Me.ckActivoU.AutoSize = True
        Me.ckActivoU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivoU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoU.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoU.Location = New System.Drawing.Point(426, 39)
        Me.ckActivoU.Name = "ckActivoU"
        Me.ckActivoU.Size = New System.Drawing.Size(75, 21)
        Me.ckActivoU.TabIndex = 1
        Me.ckActivoU.Text = "ACTIVO"
        Me.ckActivoU.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(713, 117)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 17)
        Me.Label38.TabIndex = 138
        Me.Label38.Text = "IDIOMA"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label52.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label52.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label52.Location = New System.Drawing.Point(7, 149)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(34, 17)
        Me.Label52.TabIndex = 138
        Me.Label52.Text = "PAÍS"
        '
        'cbIdioma
        '
        Me.cbIdioma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIdioma.FormattingEnabled = True
        Me.cbIdioma.Location = New System.Drawing.Point(799, 113)
        Me.cbIdioma.Name = "cbIdioma"
        Me.cbIdioma.Size = New System.Drawing.Size(118, 25)
        Me.cbIdioma.TabIndex = 6
        '
        'cbPaisU
        '
        Me.cbPaisU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaisU.FormattingEnabled = True
        Me.cbPaisU.Location = New System.Drawing.Point(127, 145)
        Me.cbPaisU.Name = "cbPaisU"
        Me.cbPaisU.Size = New System.Drawing.Size(168, 25)
        Me.cbPaisU.TabIndex = 7
        Me.cbPaisU.Text = "ESPAÑA"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(7, 40)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 17)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "TIPO DIRECCIÓN"
        '
        'dtpFechaBajaU
        '
        Me.dtpFechaBajaU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBajaU.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBajaU.Location = New System.Drawing.Point(554, 66)
        Me.dtpFechaBajaU.Name = "dtpFechaBajaU"
        Me.dtpFechaBajaU.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaBajaU.TabIndex = 3
        Me.dtpFechaBajaU.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFechaAltaU
        '
        Me.dtpFechaAltaU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAltaU.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAltaU.Location = New System.Drawing.Point(554, 36)
        Me.dtpFechaAltaU.Name = "dtpFechaAltaU"
        Me.dtpFechaAltaU.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaAltaU.TabIndex = 2
        Me.dtpFechaAltaU.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'TelefonoU2
        '
        Me.TelefonoU2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonoU2.Location = New System.Drawing.Point(799, 177)
        Me.TelefonoU2.MaxLength = 20
        Me.TelefonoU2.Name = "TelefonoU2"
        Me.TelefonoU2.Size = New System.Drawing.Size(117, 23)
        Me.TelefonoU2.TabIndex = 13
        '
        'TelefonoU1
        '
        Me.TelefonoU1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonoU1.Location = New System.Drawing.Point(800, 146)
        Me.TelefonoU1.MaxLength = 20
        Me.TelefonoU1.Name = "TelefonoU1"
        Me.TelefonoU1.Size = New System.Drawing.Size(117, 23)
        Me.TelefonoU1.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(7, 103)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 17)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "DIRECCIÓN"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label37.Location = New System.Drawing.Point(7, 180)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(83, 17)
        Me.Label37.TabIndex = 52
        Me.Label37.Text = "LOCALIDAD"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label44.Location = New System.Drawing.Point(713, 180)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(82, 17)
        Me.Label44.TabIndex = 53
        Me.Label44.Text = "TELÉFONO 2"
        '
        'Direccion
        '
        Me.Direccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Direccion.Location = New System.Drawing.Point(129, 100)
        Me.Direccion.MaxLength = 150
        Me.Direccion.Multiline = True
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Direccion.Size = New System.Drawing.Size(519, 40)
        Me.Direccion.TabIndex = 5
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(713, 149)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(82, 17)
        Me.Label33.TabIndex = 53
        Me.Label33.Text = "TELÉFONO 1"
        '
        'cbLocalidad
        '
        Me.cbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbLocalidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLocalidad.FormattingEnabled = True
        Me.cbLocalidad.Location = New System.Drawing.Point(127, 176)
        Me.cbLocalidad.Name = "cbLocalidad"
        Me.cbLocalidad.Size = New System.Drawing.Size(284, 25)
        Me.cbLocalidad.TabIndex = 11
        '
        'cbProvincia
        '
        Me.cbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProvincia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProvincia.FormattingEnabled = True
        Me.cbProvincia.Location = New System.Drawing.Point(427, 145)
        Me.cbProvincia.Name = "cbProvincia"
        Me.cbProvincia.Size = New System.Drawing.Size(221, 25)
        Me.cbProvincia.TabIndex = 9
        '
        'cbTipoU
        '
        Me.cbTipoU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoU.FormattingEnabled = True
        Me.cbTipoU.Location = New System.Drawing.Point(129, 36)
        Me.cbTipoU.MaxLength = 15
        Me.cbTipoU.Name = "cbTipoU"
        Me.cbTipoU.Size = New System.Drawing.Size(274, 25)
        Me.cbTipoU.TabIndex = 0
        '
        'lvDirecciones
        '
        Me.lvDirecciones.AllowColumnReorder = True
        Me.lvDirecciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirecciones.AutoArrange = False
        Me.lvDirecciones.BackgroundImageTiled = True
        Me.lvDirecciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidUbicacion, Me.lvtipo, Me.lvdireccion, Me.lvcodpostal, Me.lvlocalidad, Me.lvprovincia, Me.lvPais})
        Me.lvDirecciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDirecciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDirecciones.FullRowSelect = True
        Me.lvDirecciones.GridLines = True
        Me.lvDirecciones.HideSelection = False
        Me.lvDirecciones.Location = New System.Drawing.Point(13, 286)
        Me.lvDirecciones.MultiSelect = False
        Me.lvDirecciones.Name = "lvDirecciones"
        Me.lvDirecciones.Size = New System.Drawing.Size(941, 133)
        Me.lvDirecciones.TabIndex = 18
        Me.lvDirecciones.TabStop = False
        Me.lvDirecciones.UseCompatibleStateImageBehavior = False
        Me.lvDirecciones.View = System.Windows.Forms.View.Details
        '
        'lvidUbicacion
        '
        Me.lvidUbicacion.Text = "idUbicacion"
        Me.lvidUbicacion.Width = 0
        '
        'lvtipo
        '
        Me.lvtipo.Text = "TIPO"
        Me.lvtipo.Width = 150
        '
        'lvdireccion
        '
        Me.lvdireccion.Text = "DIRECCION"
        Me.lvdireccion.Width = 409
        '
        'lvcodpostal
        '
        Me.lvcodpostal.Text = "C. POSTAL"
        Me.lvcodpostal.Width = 76
        '
        'lvlocalidad
        '
        Me.lvlocalidad.Text = "LOCALIDAD"
        Me.lvlocalidad.Width = 137
        '
        'lvprovincia
        '
        Me.lvprovincia.Text = "PROVINCIA"
        Me.lvprovincia.Width = 129
        '
        'lvPais
        '
        Me.lvPais.Text = "PAIS"
        Me.lvPais.Width = 0
        '
        'lbBajaU
        '
        Me.lbBajaU.AutoSize = True
        Me.lbBajaU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBajaU.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbBajaU.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbBajaU.Location = New System.Drawing.Point(509, 70)
        Me.lbBajaU.Name = "lbBajaU"
        Me.lbBajaU.Size = New System.Drawing.Size(39, 17)
        Me.lbBajaU.TabIndex = 37
        Me.lbBajaU.Text = "BAJA"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label32.Location = New System.Drawing.Point(7, 239)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(113, 17)
        Me.Label32.TabIndex = 51
        Me.Label32.Text = "OBSERVACIONES"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(511, 41)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 17)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "ALTA"
        '
        'faxU
        '
        Me.faxU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faxU.Location = New System.Drawing.Point(800, 208)
        Me.faxU.MaxLength = 20
        Me.faxU.Name = "faxU"
        Me.faxU.Size = New System.Drawing.Size(117, 23)
        Me.faxU.TabIndex = 15
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(430, 180)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 17)
        Me.Label25.TabIndex = 40
        Me.Label25.Text = "COD. POSTAL"
        '
        'observacioneU
        '
        Me.observacioneU.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observacioneU.Location = New System.Drawing.Point(128, 236)
        Me.observacioneU.MaxLength = 200
        Me.observacioneU.Multiline = True
        Me.observacioneU.Name = "observacioneU"
        Me.observacioneU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observacioneU.Size = New System.Drawing.Size(431, 40)
        Me.observacioneU.TabIndex = 16
        '
        'HorarioU
        '
        Me.HorarioU.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HorarioU.Location = New System.Drawing.Point(712, 237)
        Me.HorarioU.MaxLength = 100
        Me.HorarioU.Multiline = True
        Me.HorarioU.Name = "HorarioU"
        Me.HorarioU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.HorarioU.Size = New System.Drawing.Size(205, 40)
        Me.HorarioU.TabIndex = 17
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(713, 211)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(31, 17)
        Me.Label31.TabIndex = 54
        Me.Label31.Text = "FAX"
        '
        'codPostal
        '
        Me.codPostal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codPostal.Location = New System.Drawing.Point(531, 177)
        Me.codPostal.MaxLength = 5
        Me.codPostal.Name = "codPostal"
        Me.codPostal.Size = New System.Drawing.Size(117, 23)
        Me.codPostal.TabIndex = 12
        '
        'emailU
        '
        Me.emailU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailU.Location = New System.Drawing.Point(128, 207)
        Me.emailU.MaxLength = 150
        Me.emailU.Name = "emailU"
        Me.emailU.Size = New System.Drawing.Size(520, 23)
        Me.emailU.TabIndex = 14
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(344, 148)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(80, 17)
        Me.Label27.TabIndex = 44
        Me.Label27.Text = "PROVINCIA"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label30.Location = New System.Drawing.Point(7, 211)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 17)
        Me.Label30.TabIndex = 55
        Me.Label30.Text = "E-MAIL"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label29.Location = New System.Drawing.Point(638, 240)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 17)
        Me.Label29.TabIndex = 48
        Me.Label29.Text = "HORARIO"
        '
        'tbcontactos
        '
        Me.tbcontactos.BackColor = System.Drawing.Color.White
        Me.tbcontactos.Controls.Add(Me.Label17)
        Me.tbcontactos.Controls.Add(Me.Label4)
        Me.tbcontactos.Controls.Add(Me.Label46)
        Me.tbcontactos.Controls.Add(Me.Label39)
        Me.tbcontactos.Controls.Add(Me.Label8)
        Me.tbcontactos.Controls.Add(Me.apellidoscontacto)
        Me.tbcontactos.Controls.Add(Me.MovilContacto)
        Me.tbcontactos.Controls.Add(Me.Label36)
        Me.tbcontactos.Controls.Add(Me.TelefonoContacto)
        Me.tbcontactos.Controls.Add(Me.nombrecontacto)
        Me.tbcontactos.Controls.Add(Me.emailContacto)
        Me.tbcontactos.Controls.Add(Me.lvContactos)
        Me.tbcontactos.Controls.Add(Me.cbDirecciones)
        Me.tbcontactos.Controls.Add(Me.cbDepartamento)
        Me.tbcontactos.Controls.Add(Me.Label40)
        Me.tbcontactos.Controls.Add(Me.Label35)
        Me.tbcontactos.Controls.Add(Me.Label49)
        Me.tbcontactos.Controls.Add(Me.ObservacionesContacto)
        Me.tbcontactos.Controls.Add(Me.cargocontacto)
        Me.tbcontactos.Location = New System.Drawing.Point(4, 26)
        Me.tbcontactos.Name = "tbcontactos"
        Me.tbcontactos.Size = New System.Drawing.Size(982, 427)
        Me.tbcontactos.TabIndex = 3
        Me.tbcontactos.Text = "CONTACTOS"
        Me.tbcontactos.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(325, 80)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 17)
        Me.Label17.TabIndex = 152
        Me.Label17.Text = "TELÉFONO 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(618, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "TELÉFONO 2"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label46.Location = New System.Drawing.Point(12, 16)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(82, 17)
        Me.Label46.TabIndex = 97
        Me.Label46.Text = "DIRECCIÓN"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(10, 80)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 17)
        Me.Label39.TabIndex = 97
        Me.Label39.Text = "DEPARTAMENTO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(12, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 17)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "E-MAIL"
        '
        'apellidoscontacto
        '
        Me.apellidoscontacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.apellidoscontacto.Location = New System.Drawing.Point(409, 47)
        Me.apellidoscontacto.MaxLength = 60
        Me.apellidoscontacto.Name = "apellidoscontacto"
        Me.apellidoscontacto.Size = New System.Drawing.Size(545, 23)
        Me.apellidoscontacto.TabIndex = 2
        '
        'MovilContacto
        '
        Me.MovilContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MovilContacto.Location = New System.Drawing.Point(705, 77)
        Me.MovilContacto.MaxLength = 15
        Me.MovilContacto.Name = "MovilContacto"
        Me.MovilContacto.Size = New System.Drawing.Size(171, 23)
        Me.MovilContacto.TabIndex = 5
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(329, 47)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(74, 17)
        Me.Label36.TabIndex = 94
        Me.Label36.Text = "APELLIDOS"
        '
        'TelefonoContacto
        '
        Me.TelefonoContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonoContacto.Location = New System.Drawing.Point(409, 77)
        Me.TelefonoContacto.MaxLength = 15
        Me.TelefonoContacto.Name = "TelefonoContacto"
        Me.TelefonoContacto.Size = New System.Drawing.Size(171, 23)
        Me.TelefonoContacto.TabIndex = 4
        '
        'nombrecontacto
        '
        Me.nombrecontacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrecontacto.Location = New System.Drawing.Point(127, 46)
        Me.nombrecontacto.MaxLength = 50
        Me.nombrecontacto.Name = "nombrecontacto"
        Me.nombrecontacto.Size = New System.Drawing.Size(171, 23)
        Me.nombrecontacto.TabIndex = 1
        '
        'emailContacto
        '
        Me.emailContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailContacto.Location = New System.Drawing.Point(127, 107)
        Me.emailContacto.MaxLength = 50
        Me.emailContacto.Name = "emailContacto"
        Me.emailContacto.Size = New System.Drawing.Size(453, 23)
        Me.emailContacto.TabIndex = 6
        '
        'lvContactos
        '
        Me.lvContactos.AllowColumnReorder = True
        Me.lvContactos.AllowDrop = True
        Me.lvContactos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvContactos.AutoArrange = False
        Me.lvContactos.BackgroundImageTiled = True
        Me.lvContactos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvid, Me.lvnombre, Me.lvapellidos, Me.lvtelefonos, Me.lvdepartamento, Me.lvcargo, Me.lvemail})
        Me.lvContactos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvContactos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvContactos.FullRowSelect = True
        Me.lvContactos.GridLines = True
        Me.lvContactos.HideSelection = False
        Me.lvContactos.Location = New System.Drawing.Point(10, 195)
        Me.lvContactos.Name = "lvContactos"
        Me.lvContactos.ShowItemToolTips = True
        Me.lvContactos.Size = New System.Drawing.Size(944, 217)
        Me.lvContactos.TabIndex = 9
        Me.lvContactos.UseCompatibleStateImageBehavior = False
        Me.lvContactos.View = System.Windows.Forms.View.Details
        '
        'lvid
        '
        Me.lvid.Text = "CODIGO"
        Me.lvid.Width = 0
        '
        'lvnombre
        '
        Me.lvnombre.Text = "NOMBRE"
        Me.lvnombre.Width = 93
        '
        'lvapellidos
        '
        Me.lvapellidos.Text = "APELLIDOS"
        Me.lvapellidos.Width = 171
        '
        'lvtelefonos
        '
        Me.lvtelefonos.Text = "TELEFONOS"
        Me.lvtelefonos.Width = 194
        '
        'lvdepartamento
        '
        Me.lvdepartamento.Text = "DEPARTAMENTO"
        Me.lvdepartamento.Width = 120
        '
        'lvcargo
        '
        Me.lvcargo.Text = "CARGO"
        Me.lvcargo.Width = 130
        '
        'lvemail
        '
        Me.lvemail.Text = "E_MAIL"
        Me.lvemail.Width = 204
        '
        'cbDirecciones
        '
        Me.cbDirecciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDirecciones.FormattingEnabled = True
        Me.cbDirecciones.Location = New System.Drawing.Point(127, 14)
        Me.cbDirecciones.MaxLength = 6
        Me.cbDirecciones.Name = "cbDirecciones"
        Me.cbDirecciones.Size = New System.Drawing.Size(827, 25)
        Me.cbDirecciones.TabIndex = 0
        '
        'cbDepartamento
        '
        Me.cbDepartamento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(127, 76)
        Me.cbDepartamento.MaxLength = 6
        Me.cbDepartamento.Name = "cbDepartamento"
        Me.cbDepartamento.Size = New System.Drawing.Size(171, 25)
        Me.cbDepartamento.TabIndex = 3
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label40.Location = New System.Drawing.Point(640, 110)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(58, 17)
        Me.Label40.TabIndex = 98
        Me.Label40.Text = "CARGO"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label35.Location = New System.Drawing.Point(12, 49)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(62, 17)
        Me.Label35.TabIndex = 93
        Me.Label35.Text = "NOMBRE"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label49.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label49.Location = New System.Drawing.Point(12, 140)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(113, 17)
        Me.Label49.TabIndex = 98
        Me.Label49.Text = "OBSERVACIONES"
        '
        'ObservacionesContacto
        '
        Me.ObservacionesContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesContacto.Location = New System.Drawing.Point(127, 137)
        Me.ObservacionesContacto.MaxLength = 100
        Me.ObservacionesContacto.Multiline = True
        Me.ObservacionesContacto.Name = "ObservacionesContacto"
        Me.ObservacionesContacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservacionesContacto.Size = New System.Drawing.Size(827, 40)
        Me.ObservacionesContacto.TabIndex = 8
        '
        'cargocontacto
        '
        Me.cargocontacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cargocontacto.Location = New System.Drawing.Point(705, 107)
        Me.cargocontacto.MaxLength = 20
        Me.cargocontacto.Name = "cargocontacto"
        Me.cargocontacto.Size = New System.Drawing.Size(249, 23)
        Me.cargocontacto.TabIndex = 7
        '
        'tbfacturacion
        '
        Me.tbfacturacion.BackColor = System.Drawing.Color.White
        Me.tbfacturacion.Controls.Add(Me.Label16)
        Me.tbfacturacion.Controls.Add(Me.bTiposIVA)
        Me.tbfacturacion.Controls.Add(Me.bTiposRetencion)
        Me.tbfacturacion.Controls.Add(Me.bMoneda)
        Me.tbfacturacion.Controls.Add(Me.bTiposPago)
        Me.tbfacturacion.Controls.Add(Me.bMediosPago)
        Me.tbfacturacion.Controls.Add(Me.ProntoPago)
        Me.tbfacturacion.Controls.Add(Me.Descuento)
        Me.tbfacturacion.Controls.Add(Me.Label28)
        Me.tbfacturacion.Controls.Add(Me.Label18)
        Me.tbfacturacion.Controls.Add(Me.cbRetencion)
        Me.tbfacturacion.Controls.Add(Me.cbTipoIVA)
        Me.tbfacturacion.Controls.Add(Me.gbBancos)
        Me.tbfacturacion.Controls.Add(Me.cbMoneda)
        Me.tbfacturacion.Controls.Add(Me.ckRecargoEquivalencia)
        Me.tbfacturacion.Controls.Add(Me.RecargoEq)
        Me.tbfacturacion.Controls.Add(Me.ckExentoPagosAgosto)
        Me.tbfacturacion.Controls.Add(Me.cbMedioPago)
        Me.tbfacturacion.Controls.Add(Me.Label51)
        Me.tbfacturacion.Controls.Add(Me.Label13)
        Me.tbfacturacion.Controls.Add(Me.Label50)
        Me.tbfacturacion.Controls.Add(Me.Label11)
        Me.tbfacturacion.Controls.Add(Me.Label54)
        Me.tbfacturacion.Controls.Add(Me.lbRecargoEq)
        Me.tbfacturacion.Controls.Add(Me.Label53)
        Me.tbfacturacion.Controls.Add(Me.Label48)
        Me.tbfacturacion.Controls.Add(Me.Label24)
        Me.tbfacturacion.Controls.Add(Me.cbDiaPago2)
        Me.tbfacturacion.Controls.Add(Me.cbDiaPago1)
        Me.tbfacturacion.Controls.Add(Me.ObservacionesF)
        Me.tbfacturacion.Controls.Add(Me.Label10)
        Me.tbfacturacion.Controls.Add(Me.cbTipoPago)
        Me.tbfacturacion.Location = New System.Drawing.Point(4, 26)
        Me.tbfacturacion.Name = "tbfacturacion"
        Me.tbfacturacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbfacturacion.Size = New System.Drawing.Size(982, 427)
        Me.tbfacturacion.TabIndex = 2
        Me.tbfacturacion.Text = "DATOS FACTURACION"
        Me.tbfacturacion.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(10, 114)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 17)
        Me.Label16.TabIndex = 140
        Me.Label16.Text = "TIPO IVA"
        '
        'bTiposIVA
        '
        Me.bTiposIVA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposIVA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposIVA.Location = New System.Drawing.Point(293, 108)
        Me.bTiposIVA.Name = "bTiposIVA"
        Me.bTiposIVA.Size = New System.Drawing.Size(27, 25)
        Me.bTiposIVA.TabIndex = 150
        Me.bTiposIVA.Text = "...."
        Me.bTiposIVA.UseVisualStyleBackColor = True
        '
        'bTiposRetencion
        '
        Me.bTiposRetencion.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposRetencion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposRetencion.Location = New System.Drawing.Point(848, 109)
        Me.bTiposRetencion.Name = "bTiposRetencion"
        Me.bTiposRetencion.Size = New System.Drawing.Size(27, 25)
        Me.bTiposRetencion.TabIndex = 149
        Me.bTiposRetencion.Text = "...."
        Me.bTiposRetencion.UseVisualStyleBackColor = True
        '
        'bMoneda
        '
        Me.bMoneda.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMoneda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMoneda.Location = New System.Drawing.Point(293, 14)
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.Size = New System.Drawing.Size(27, 25)
        Me.bMoneda.TabIndex = 148
        Me.bMoneda.Text = "...."
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'bTiposPago
        '
        Me.bTiposPago.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposPago.Location = New System.Drawing.Point(410, 76)
        Me.bTiposPago.Name = "bTiposPago"
        Me.bTiposPago.Size = New System.Drawing.Size(27, 25)
        Me.bTiposPago.TabIndex = 147
        Me.bTiposPago.Text = "...."
        Me.bTiposPago.UseVisualStyleBackColor = True
        '
        'bMediosPago
        '
        Me.bMediosPago.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMediosPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMediosPago.Location = New System.Drawing.Point(410, 46)
        Me.bMediosPago.Name = "bMediosPago"
        Me.bMediosPago.Size = New System.Drawing.Size(27, 25)
        Me.bMediosPago.TabIndex = 146
        Me.bMediosPago.Text = "...."
        Me.bMediosPago.UseVisualStyleBackColor = True
        '
        'ProntoPago
        '
        Me.ProntoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProntoPago.Location = New System.Drawing.Point(660, 46)
        Me.ProntoPago.MaxLength = 4
        Me.ProntoPago.Name = "ProntoPago"
        Me.ProntoPago.Size = New System.Drawing.Size(40, 23)
        Me.ProntoPago.TabIndex = 1
        '
        'Descuento
        '
        Me.Descuento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento.Location = New System.Drawing.Point(659, 15)
        Me.Descuento.MaxLength = 4
        Me.Descuento.Name = "Descuento"
        Me.Descuento.Size = New System.Drawing.Size(40, 23)
        Me.Descuento.TabIndex = 2
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label28.Location = New System.Drawing.Point(574, 114)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 17)
        Me.Label28.TabIndex = 140
        Me.Label28.Text = "RETENCIÓN"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(10, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 17)
        Me.Label18.TabIndex = 138
        Me.Label18.Text = "MONEDA"
        '
        'cbRetencion
        '
        Me.cbRetencion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRetencion.FormattingEnabled = True
        Me.cbRetencion.Location = New System.Drawing.Point(660, 110)
        Me.cbRetencion.Name = "cbRetencion"
        Me.cbRetencion.Size = New System.Drawing.Size(182, 25)
        Me.cbRetencion.TabIndex = 12
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Location = New System.Drawing.Point(127, 110)
        Me.cbTipoIVA.Name = "cbTipoIVA"
        Me.cbTipoIVA.Size = New System.Drawing.Size(150, 25)
        Me.cbTipoIVA.TabIndex = 9
        '
        'gbBancos
        '
        Me.gbBancos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBancos.Controls.Add(Me.ckActivoB)
        Me.gbBancos.Controls.Add(Me.bBancos)
        Me.gbBancos.Controls.Add(Me.bMenosBancos)
        Me.gbBancos.Controls.Add(Me.bLimpiaBanco)
        Me.gbBancos.Controls.Add(Me.bMasBanco)
        Me.gbBancos.Controls.Add(Me.IBAN)
        Me.gbBancos.Controls.Add(Me.SWIFT_BIC)
        Me.gbBancos.Controls.Add(Me.lvBancos)
        Me.gbBancos.Controls.Add(Me.codigocuenta)
        Me.gbBancos.Controls.Add(Me.Label26)
        Me.gbBancos.Controls.Add(Me.Label9)
        Me.gbBancos.Controls.Add(Me.codigodc)
        Me.gbBancos.Controls.Add(Me.Label34)
        Me.gbBancos.Controls.Add(Me.Label57)
        Me.gbBancos.Controls.Add(Me.Label3)
        Me.gbBancos.Controls.Add(Me.Label56)
        Me.gbBancos.Controls.Add(Me.Label22)
        Me.gbBancos.Controls.Add(Me.codigoEU)
        Me.gbBancos.Controls.Add(Me.codigobanco)
        Me.gbBancos.Controls.Add(Me.codigooficina)
        Me.gbBancos.Controls.Add(Me.cbBanco)
        Me.gbBancos.Controls.Add(Me.Label20)
        Me.gbBancos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBancos.Location = New System.Drawing.Point(9, 183)
        Me.gbBancos.Name = "gbBancos"
        Me.gbBancos.Size = New System.Drawing.Size(945, 228)
        Me.gbBancos.TabIndex = 14
        Me.gbBancos.TabStop = False
        Me.gbBancos.Text = "BANCOS"
        '
        'ckActivoB
        '
        Me.ckActivoB.AutoSize = True
        Me.ckActivoB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivoB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoB.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoB.Location = New System.Drawing.Point(405, 24)
        Me.ckActivoB.Name = "ckActivoB"
        Me.ckActivoB.Size = New System.Drawing.Size(75, 21)
        Me.ckActivoB.TabIndex = 142
        Me.ckActivoB.Text = "ACTIVO"
        Me.ckActivoB.UseVisualStyleBackColor = True
        '
        'bBancos
        '
        Me.bBancos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBancos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBancos.Location = New System.Drawing.Point(372, 22)
        Me.bBancos.Name = "bBancos"
        Me.bBancos.Size = New System.Drawing.Size(27, 25)
        Me.bBancos.TabIndex = 149
        Me.bBancos.Text = "...."
        Me.bBancos.UseVisualStyleBackColor = True
        '
        'bMenosBancos
        '
        Me.bMenosBancos.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMenosBancos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bMenosBancos.Location = New System.Drawing.Point(840, 41)
        Me.bMenosBancos.Name = "bMenosBancos"
        Me.bMenosBancos.Size = New System.Drawing.Size(23, 23)
        Me.bMenosBancos.TabIndex = 9
        Me.bMenosBancos.Text = "-"
        Me.bMenosBancos.UseVisualStyleBackColor = True
        '
        'bLimpiaBanco
        '
        Me.bLimpiaBanco.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiaBanco.Image = CType(resources.GetObject("bLimpiaBanco.Image"), System.Drawing.Image)
        Me.bLimpiaBanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiaBanco.Location = New System.Drawing.Point(840, 67)
        Me.bLimpiaBanco.Name = "bLimpiaBanco"
        Me.bLimpiaBanco.Size = New System.Drawing.Size(23, 23)
        Me.bLimpiaBanco.TabIndex = 10
        Me.bLimpiaBanco.UseVisualStyleBackColor = True
        '
        'bMasBanco
        '
        Me.bMasBanco.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMasBanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bMasBanco.Location = New System.Drawing.Point(840, 15)
        Me.bMasBanco.Name = "bMasBanco"
        Me.bMasBanco.Size = New System.Drawing.Size(23, 23)
        Me.bMasBanco.TabIndex = 8
        Me.bMasBanco.Text = "+"
        Me.bMasBanco.UseVisualStyleBackColor = True
        '
        'IBAN
        '
        Me.IBAN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IBAN.Location = New System.Drawing.Point(543, 21)
        Me.IBAN.MaxLength = 34
        Me.IBAN.Name = "IBAN"
        Me.IBAN.Size = New System.Drawing.Size(276, 23)
        Me.IBAN.TabIndex = 1
        '
        'SWIFT_BIC
        '
        Me.SWIFT_BIC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SWIFT_BIC.Location = New System.Drawing.Point(118, 55)
        Me.SWIFT_BIC.MaxLength = 11
        Me.SWIFT_BIC.Name = "SWIFT_BIC"
        Me.SWIFT_BIC.Size = New System.Drawing.Size(118, 23)
        Me.SWIFT_BIC.TabIndex = 2
        '
        'lvBancos
        '
        Me.lvBancos.AllowColumnReorder = True
        Me.lvBancos.AllowDrop = True
        Me.lvBancos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBancos.AutoArrange = False
        Me.lvBancos.BackgroundImageTiled = True
        Me.lvBancos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidCuentaBanco, Me.lvBanco, Me.lvIBAN, Me.lvidBanco, Me.lvCodEU, Me.lvCodBanco, Me.lvcodOficina, Me.lvDC, Me.lvCuenta, Me.lvBIC})
        Me.lvBancos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvBancos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBancos.FullRowSelect = True
        Me.lvBancos.GridLines = True
        Me.lvBancos.HideSelection = False
        Me.lvBancos.Location = New System.Drawing.Point(10, 94)
        Me.lvBancos.Name = "lvBancos"
        Me.lvBancos.ShowItemToolTips = True
        Me.lvBancos.Size = New System.Drawing.Size(909, 115)
        Me.lvBancos.TabIndex = 11
        Me.lvBancos.UseCompatibleStateImageBehavior = False
        Me.lvBancos.View = System.Windows.Forms.View.Details
        '
        'lvidCuentaBanco
        '
        Me.lvidCuentaBanco.Text = "idCuentaBanco"
        Me.lvidCuentaBanco.Width = 0
        '
        'lvBanco
        '
        Me.lvBanco.Text = "BANCO"
        Me.lvBanco.Width = 410
        '
        'lvIBAN
        '
        Me.lvIBAN.Text = "IBAN"
        Me.lvIBAN.Width = 378
        '
        'lvidBanco
        '
        Me.lvidBanco.Text = "idBanco"
        Me.lvidBanco.Width = 0
        '
        'lvCodEU
        '
        Me.lvCodEU.Text = "CodigoEU"
        Me.lvCodEU.Width = 0
        '
        'lvCodBanco
        '
        Me.lvCodBanco.Text = "codBanco"
        Me.lvCodBanco.Width = 0
        '
        'lvcodOficina
        '
        Me.lvcodOficina.Text = "codOficina"
        Me.lvcodOficina.Width = 0
        '
        'lvDC
        '
        Me.lvDC.Text = "DC"
        Me.lvDC.Width = 0
        '
        'lvCuenta
        '
        Me.lvCuenta.Text = "Cuenta"
        Me.lvCuenta.Width = 0
        '
        'lvBIC
        '
        Me.lvBIC.Text = "BIC"
        Me.lvBIC.Width = 0
        '
        'codigocuenta
        '
        Me.codigocuenta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigocuenta.Location = New System.Drawing.Point(722, 55)
        Me.codigocuenta.MaxLength = 10
        Me.codigocuenta.Name = "codigocuenta"
        Me.codigocuenta.Size = New System.Drawing.Size(97, 23)
        Me.codigocuenta.TabIndex = 7
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(593, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(29, 17)
        Me.Label26.TabIndex = 91
        Me.Label26.Text = "DC"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(360, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "BANCO"
        '
        'codigodc
        '
        Me.codigodc.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigodc.Location = New System.Drawing.Point(628, 55)
        Me.codigodc.MaxLength = 2
        Me.codigodc.Name = "codigodc"
        Me.codigodc.Size = New System.Drawing.Size(29, 23)
        Me.codigodc.TabIndex = 6
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label34.Location = New System.Drawing.Point(661, 58)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 17)
        Me.Label34.TabIndex = 92
        Me.Label34.Text = "CUENTA"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(485, 25)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(37, 17)
        Me.Label57.TabIndex = 89
        Me.Label57.Text = "IBAN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(266, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "IBAN"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label56.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label56.Location = New System.Drawing.Point(7, 58)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(68, 17)
        Me.Label56.TabIndex = 90
        Me.Label56.Text = "SWIFT/BIC"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(480, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 17)
        Me.Label22.TabIndex = 90
        Me.Label22.Text = "OFICINA"
        '
        'codigoEU
        '
        Me.codigoEU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigoEU.Location = New System.Drawing.Point(310, 55)
        Me.codigoEU.MaxLength = 4
        Me.codigoEU.Name = "codigoEU"
        Me.codigoEU.Size = New System.Drawing.Size(45, 23)
        Me.codigoEU.TabIndex = 3
        Me.codigoEU.Text = "ES"
        '
        'codigobanco
        '
        Me.codigobanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigobanco.Location = New System.Drawing.Point(422, 55)
        Me.codigobanco.MaxLength = 4
        Me.codigobanco.Name = "codigobanco"
        Me.codigobanco.Size = New System.Drawing.Size(45, 23)
        Me.codigobanco.TabIndex = 4
        '
        'codigooficina
        '
        Me.codigooficina.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigooficina.Location = New System.Drawing.Point(543, 55)
        Me.codigooficina.MaxLength = 4
        Me.codigooficina.Name = "codigooficina"
        Me.codigooficina.Size = New System.Drawing.Size(45, 23)
        Me.codigooficina.TabIndex = 5
        '
        'cbBanco
        '
        Me.cbBanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(118, 22)
        Me.cbBanco.MaxLength = 15
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(237, 25)
        Me.cbBanco.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(7, 30)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 17)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "BANCO"
        '
        'cbMoneda
        '
        Me.cbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(127, 14)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(150, 25)
        Me.cbMoneda.TabIndex = 0
        '
        'ckRecargoEquivalencia
        '
        Me.ckRecargoEquivalencia.AutoSize = True
        Me.ckRecargoEquivalencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckRecargoEquivalencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRecargoEquivalencia.Location = New System.Drawing.Point(328, 112)
        Me.ckRecargoEquivalencia.Name = "ckRecargoEquivalencia"
        Me.ckRecargoEquivalencia.Size = New System.Drawing.Size(189, 21)
        Me.ckRecargoEquivalencia.TabIndex = 10
        Me.ckRecargoEquivalencia.Text = "RECARGO EQUIVALENCIA"
        Me.ckRecargoEquivalencia.UseVisualStyleBackColor = True
        '
        'RecargoEq
        '
        Me.RecargoEq.BackColor = System.Drawing.SystemColors.Window
        Me.RecargoEq.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecargoEq.Location = New System.Drawing.Point(517, 111)
        Me.RecargoEq.MaxLength = 4
        Me.RecargoEq.Name = "RecargoEq"
        Me.RecargoEq.ReadOnly = True
        Me.RecargoEq.Size = New System.Drawing.Size(40, 23)
        Me.RecargoEq.TabIndex = 11
        '
        'ckExentoPagosAgosto
        '
        Me.ckExentoPagosAgosto.AutoSize = True
        Me.ckExentoPagosAgosto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckExentoPagosAgosto.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckExentoPagosAgosto.Location = New System.Drawing.Point(718, 80)
        Me.ckExentoPagosAgosto.Name = "ckExentoPagosAgosto"
        Me.ckExentoPagosAgosto.Size = New System.Drawing.Size(181, 21)
        Me.ckExentoPagosAgosto.TabIndex = 8
        Me.ckExentoPagosAgosto.Text = "EXENTO PAGOS AGOSTO"
        Me.ckExentoPagosAgosto.UseVisualStyleBackColor = True
        '
        'cbMedioPago
        '
        Me.cbMedioPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMedioPago.FormattingEnabled = True
        Me.cbMedioPago.Location = New System.Drawing.Point(127, 46)
        Me.cbMedioPago.MaxLength = 15
        Me.cbMedioPago.Name = "cbMedioPago"
        Me.cbMedioPago.Size = New System.Drawing.Size(267, 25)
        Me.cbMedioPago.TabIndex = 3
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label51.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label51.Location = New System.Drawing.Point(10, 146)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(113, 17)
        Me.Label51.TabIndex = 123
        Me.Label51.Text = "OBSERVACIONES"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(10, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 17)
        Me.Label13.TabIndex = 123
        Me.Label13.Text = "MEDIO DE PAGO"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label50.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label50.Location = New System.Drawing.Point(553, 49)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(104, 17)
        Me.Label50.TabIndex = 86
        Me.Label50.Text = "PRONTO PAGO"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(574, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 17)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "DIA PAGO 2"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label54.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label54.Location = New System.Drawing.Point(702, 48)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(18, 17)
        Me.Label54.TabIndex = 86
        Me.Label54.Text = "%"
        '
        'lbRecargoEq
        '
        Me.lbRecargoEq.AutoSize = True
        Me.lbRecargoEq.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRecargoEq.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbRecargoEq.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbRecargoEq.Location = New System.Drawing.Point(557, 114)
        Me.lbRecargoEq.Name = "lbRecargoEq"
        Me.lbRecargoEq.Size = New System.Drawing.Size(18, 17)
        Me.lbRecargoEq.TabIndex = 86
        Me.lbRecargoEq.Text = "%"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label53.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label53.Location = New System.Drawing.Point(702, 18)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(18, 17)
        Me.Label53.TabIndex = 86
        Me.Label53.Text = "%"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label48.Location = New System.Drawing.Point(553, 18)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(83, 17)
        Me.Label48.TabIndex = 86
        Me.Label48.Text = "DESCUENTO"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(441, 82)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(73, 17)
        Me.Label24.TabIndex = 86
        Me.Label24.Text = "DIA PAGO"
        '
        'cbDiaPago2
        '
        Me.cbDiaPago2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDiaPago2.FormattingEnabled = True
        Me.cbDiaPago2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cbDiaPago2.Location = New System.Drawing.Point(660, 78)
        Me.cbDiaPago2.MaxLength = 15
        Me.cbDiaPago2.Name = "cbDiaPago2"
        Me.cbDiaPago2.Size = New System.Drawing.Size(40, 25)
        Me.cbDiaPago2.TabIndex = 7
        '
        'cbDiaPago1
        '
        Me.cbDiaPago1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDiaPago1.FormattingEnabled = True
        Me.cbDiaPago1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cbDiaPago1.Location = New System.Drawing.Point(517, 78)
        Me.cbDiaPago1.MaxLength = 15
        Me.cbDiaPago1.Name = "cbDiaPago1"
        Me.cbDiaPago1.Size = New System.Drawing.Size(40, 25)
        Me.cbDiaPago1.TabIndex = 6
        '
        'ObservacionesF
        '
        Me.ObservacionesF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesF.Location = New System.Drawing.Point(127, 142)
        Me.ObservacionesF.MaxLength = 100
        Me.ObservacionesF.Multiline = True
        Me.ObservacionesF.Name = "ObservacionesF"
        Me.ObservacionesF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservacionesF.Size = New System.Drawing.Size(746, 40)
        Me.ObservacionesF.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(10, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 17)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "TIPO DE PAGO"
        '
        'cbTipoPago
        '
        Me.cbTipoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoPago.FormattingEnabled = True
        Me.cbTipoPago.Location = New System.Drawing.Point(127, 78)
        Me.cbTipoPago.MaxLength = 15
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.Size = New System.Drawing.Size(267, 25)
        Me.cbTipoPago.TabIndex = 5
        '
        'tbArticulos
        '
        Me.tbArticulos.Controls.Add(Me.Label15)
        Me.tbArticulos.Controls.Add(Me.cbArticuloComprados)
        Me.tbArticulos.Controls.Add(Me.ContadorVendidos)
        Me.tbArticulos.Controls.Add(Me.Label98)
        Me.tbArticulos.Controls.Add(Me.lbCambioVendidos)
        Me.tbArticulos.Controls.Add(Me.CantidadVendidos)
        Me.tbArticulos.Controls.Add(Me.TotalVendidos)
        Me.tbArticulos.Controls.Add(Me.Label92)
        Me.tbArticulos.Controls.Add(Me.Label85)
        Me.tbArticulos.Controls.Add(Me.Label91)
        Me.tbArticulos.Controls.Add(Me.lbSubTipo)
        Me.tbArticulos.Controls.Add(Me.lbTipo)
        Me.tbArticulos.Controls.Add(Me.cbSubTipo)
        Me.tbArticulos.Controls.Add(Me.cbTipo)
        Me.tbArticulos.Controls.Add(Me.Label61)
        Me.tbArticulos.Controls.Add(Me.Label62)
        Me.tbArticulos.Controls.Add(Me.lvArticulosComprados)
        Me.tbArticulos.Controls.Add(Me.dtpArticulosCompradosHasta)
        Me.tbArticulos.Controls.Add(Me.dtpArticulosCompradosDesde)
        Me.tbArticulos.Location = New System.Drawing.Point(4, 26)
        Me.tbArticulos.Name = "tbArticulos"
        Me.tbArticulos.Size = New System.Drawing.Size(982, 427)
        Me.tbArticulos.TabIndex = 10
        Me.tbArticulos.Text = "ARTÍCULOS COMPRADOS"
        Me.tbArticulos.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(12, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(152, 17)
        Me.Label15.TabIndex = 226
        Me.Label15.Text = "ARTÍCULO PROVEEDOR"
        '
        'cbArticuloComprados
        '
        Me.cbArticuloComprados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticuloComprados.FormattingEnabled = True
        Me.cbArticuloComprados.Location = New System.Drawing.Point(182, 40)
        Me.cbArticuloComprados.Name = "cbArticuloComprados"
        Me.cbArticuloComprados.Size = New System.Drawing.Size(784, 25)
        Me.cbArticuloComprados.TabIndex = 225
        '
        'ContadorVendidos
        '
        Me.ContadorVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorVendidos.Location = New System.Drawing.Point(122, 395)
        Me.ContadorVendidos.MaxLength = 15
        Me.ContadorVendidos.Name = "ContadorVendidos"
        Me.ContadorVendidos.ReadOnly = True
        Me.ContadorVendidos.Size = New System.Drawing.Size(60, 23)
        Me.ContadorVendidos.TabIndex = 222
        Me.ContadorVendidos.TabStop = False
        Me.ContadorVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label98
        '
        Me.Label98.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label98.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label98.Location = New System.Drawing.Point(12, 398)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(106, 17)
        Me.Label98.TabIndex = 224
        Me.Label98.Text = "ENCONTRADOS"
        '
        'lbCambioVendidos
        '
        Me.lbCambioVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioVendidos.AutoSize = True
        Me.lbCambioVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioVendidos.ForeColor = System.Drawing.Color.Red
        Me.lbCambioVendidos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioVendidos.Location = New System.Drawing.Point(338, 397)
        Me.lbCambioVendidos.Name = "lbCambioVendidos"
        Me.lbCambioVendidos.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioVendidos.TabIndex = 223
        Me.lbCambioVendidos.Text = "CAMBIO"
        Me.lbCambioVendidos.Visible = False
        '
        'CantidadVendidos
        '
        Me.CantidadVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CantidadVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.CantidadVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CantidadVendidos.Location = New System.Drawing.Point(653, 395)
        Me.CantidadVendidos.MaxLength = 15
        Me.CantidadVendidos.Name = "CantidadVendidos"
        Me.CantidadVendidos.ReadOnly = True
        Me.CantidadVendidos.Size = New System.Drawing.Size(90, 23)
        Me.CantidadVendidos.TabIndex = 218
        Me.CantidadVendidos.TabStop = False
        Me.CantidadVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalVendidos
        '
        Me.TotalVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.TotalVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalVendidos.Location = New System.Drawing.Point(838, 395)
        Me.TotalVendidos.MaxLength = 15
        Me.TotalVendidos.Name = "TotalVendidos"
        Me.TotalVendidos.ReadOnly = True
        Me.TotalVendidos.Size = New System.Drawing.Size(90, 23)
        Me.TotalVendidos.TabIndex = 217
        Me.TotalVendidos.TabStop = False
        Me.TotalVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label92
        '
        Me.Label92.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label92.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label92.Location = New System.Drawing.Point(566, 398)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(75, 17)
        Me.Label92.TabIndex = 220
        Me.Label92.Text = "CANTIDAD"
        '
        'Label85
        '
        Me.Label85.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label85.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label85.Location = New System.Drawing.Point(931, 397)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(15, 17)
        Me.Label85.TabIndex = 219
        Me.Label85.Text = "€"
        '
        'Label91
        '
        Me.Label91.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label91.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label91.Location = New System.Drawing.Point(783, 397)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(44, 17)
        Me.Label91.TabIndex = 221
        Me.Label91.Text = "TOTAL"
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(682, 14)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(109, 17)
        Me.lbSubTipo.TabIndex = 190
        Me.lbSubTipo.Text = "SUBTIPO/FAMILIA"
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(418, 13)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(88, 17)
        Me.lbTipo.TabIndex = 189
        Me.lbTipo.Text = "TIPO/FAMILIA"
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(801, 10)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(164, 25)
        Me.cbSubTipo.TabIndex = 3
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(512, 10)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(164, 25)
        Me.cbTipo.TabIndex = 2
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label61.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label61.Location = New System.Drawing.Point(191, 13)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(46, 17)
        Me.Label61.TabIndex = 186
        Me.Label61.Text = "HASTA"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label62.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label62.Location = New System.Drawing.Point(12, 13)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(48, 17)
        Me.Label62.TabIndex = 185
        Me.Label62.Text = "DESDE"
        '
        'lvArticulosComprados
        '
        Me.lvArticulosComprados.AllowColumnReorder = True
        Me.lvArticulosComprados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvArticulosComprados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidArticulo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCodAArticuloCli, Me.lvArticuloCli, Me.lvCantidad, Me.ColumnHeader3, Me.lvDocumento, Me.lvFecha})
        Me.lvArticulosComprados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvArticulosComprados.FullRowSelect = True
        Me.lvArticulosComprados.GridLines = True
        Me.lvArticulosComprados.HideSelection = False
        Me.lvArticulosComprados.Location = New System.Drawing.Point(9, 73)
        Me.lvArticulosComprados.MultiSelect = False
        Me.lvArticulosComprados.Name = "lvArticulosComprados"
        Me.lvArticulosComprados.ShowItemToolTips = True
        Me.lvArticulosComprados.Size = New System.Drawing.Size(957, 313)
        Me.lvArticulosComprados.TabIndex = 0
        Me.lvArticulosComprados.UseCompatibleStateImageBehavior = False
        Me.lvArticulosComprados.View = System.Windows.Forms.View.Details
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 100
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 191
        '
        'lvCodAArticuloCli
        '
        Me.lvCodAArticuloCli.Text = "CÓDIGO PROV"
        Me.lvCodAArticuloCli.Width = 104
        '
        'lvArticuloCli
        '
        Me.lvArticuloCli.Text = "ARTÍCULO PROVEEDOR"
        Me.lvArticuloCli.Width = 210
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 76
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ÚLT.PRECIO"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 80
        '
        'lvDocumento
        '
        Me.lvDocumento.Text = "ÚLT.PEDIDO"
        Me.lvDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvDocumento.Width = 93
        '
        'lvFecha
        '
        Me.lvFecha.Text = "ÚLT.FECHA"
        Me.lvFecha.Width = 81
        '
        'dtpArticulosCompradosHasta
        '
        Me.dtpArticulosCompradosHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArticulosCompradosHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArticulosCompradosHasta.Location = New System.Drawing.Point(250, 10)
        Me.dtpArticulosCompradosHasta.Name = "dtpArticulosCompradosHasta"
        Me.dtpArticulosCompradosHasta.Size = New System.Drawing.Size(116, 23)
        Me.dtpArticulosCompradosHasta.TabIndex = 1
        Me.dtpArticulosCompradosHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpArticulosCompradosDesde
        '
        Me.dtpArticulosCompradosDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArticulosCompradosDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArticulosCompradosDesde.Location = New System.Drawing.Point(68, 10)
        Me.dtpArticulosCompradosDesde.Name = "dtpArticulosCompradosDesde"
        Me.dtpArticulosCompradosDesde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpArticulosCompradosDesde.RightToLeftLayout = True
        Me.dtpArticulosCompradosDesde.Size = New System.Drawing.Size(116, 23)
        Me.dtpArticulosCompradosDesde.TabIndex = 0
        Me.dtpArticulosCompradosDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(585, 24)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(95, 50)
        Me.bNuevo.TabIndex = 5
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(691, 24)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(95, 50)
        Me.bImprimir.TabIndex = 6
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(797, 24)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(95, 50)
        Me.bBorrar.TabIndex = 7
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(479, 24)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(95, 50)
        Me.bGuardar.TabIndex = 4
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'GestionProveedores
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 762)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE PROVEEDORES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbdatos.ResumeLayout(False)
        Me.tbUbicaciones.ResumeLayout(False)
        Me.tbUbicaciones.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tbcontactos.ResumeLayout(False)
        Me.tbcontactos.PerformLayout()
        Me.tbfacturacion.ResumeLayout(False)
        Me.tbfacturacion.PerformLayout()
        Me.gbBancos.ResumeLayout(False)
        Me.gbBancos.PerformLayout()
        Me.tbArticulos.ResumeLayout(False)
        Me.tbArticulos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents tbdatos As System.Windows.Forms.TabControl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents observaciones As System.Windows.Forms.TextBox
    Friend WithEvents web As System.Windows.Forms.TextBox
    Friend WithEvents nombrecomercial As System.Windows.Forms.TextBox
    Friend WithEvents nif As System.Windows.Forms.TextBox
    Friend WithEvents codContable As System.Windows.Forms.TextBox
    Friend WithEvents codProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nombrefiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbUbicaciones As System.Windows.Forms.TabPage
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cbPaisU As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaAltaU As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Direccion As System.Windows.Forms.TextBox
    Friend WithEvents cbLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents cbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents lvDirecciones As System.Windows.Forms.ListView
    Friend WithEvents lvidUbicacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvtipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdireccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodpostal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvlocalidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvprovincia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPais As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents HorarioU As System.Windows.Forms.TextBox
    Friend WithEvents codPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents emailU As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents observacioneU As System.Windows.Forms.TextBox
    Friend WithEvents faxU As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cbTipoU As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TelefonoU1 As System.Windows.Forms.TextBox
    Friend WithEvents tbfacturacion As System.Windows.Forms.TabPage
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cbMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbDiaPago1 As System.Windows.Forms.ComboBox
    Friend WithEvents codigocuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents codigodc As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ObservacionesF As System.Windows.Forms.TextBox
    Friend WithEvents codigoEU As System.Windows.Forms.TextBox
    Friend WithEvents codigobanco As System.Windows.Forms.TextBox
    Friend WithEvents codigooficina As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbcontactos As System.Windows.Forms.TabPage
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents MovilContacto As System.Windows.Forms.TextBox
    Friend WithEvents TelefonoContacto As System.Windows.Forms.TextBox
    Friend WithEvents emailContacto As System.Windows.Forms.TextBox
    Friend WithEvents cbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ObservacionesContacto As System.Windows.Forms.TextBox
    Friend WithEvents cargocontacto As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lvContactos As System.Windows.Forms.ListView
    Friend WithEvents lvid As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvapellidos As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvtelefonos As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdepartamento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcargo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvemail As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombrecontacto As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents apellidoscontacto As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaBaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbBaja As System.Windows.Forms.Label
    Friend WithEvents ckActivoU As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaBajaU As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbBajaU As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cbDirecciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbDiaPago2 As System.Windows.Forms.ComboBox
    Friend WithEvents lvBancos As System.Windows.Forms.ListView
    Friend WithEvents lvBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvIBAN As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckExentoPagosAgosto As System.Windows.Forms.CheckBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cbIdioma As System.Windows.Forms.ComboBox
    Friend WithEvents gbBancos As System.Windows.Forms.GroupBox
    Friend WithEvents cbTipoProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents ckRecargoEquivalencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbRetencion As System.Windows.Forms.ComboBox
    Friend WithEvents TelefonoU2 As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RecargoEq As System.Windows.Forms.TextBox
    Friend WithEvents Descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents ProntoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lbRecargoEq As System.Windows.Forms.Label
    Friend WithEvents lvidCuentaBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents SWIFT_BIC As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents IBAN As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents bMasBanco As System.Windows.Forms.Button
    Friend WithEvents bMenosBancos As System.Windows.Forms.Button
    Friend WithEvents bLimpiaBanco As System.Windows.Forms.Button
    Friend WithEvents lvidBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodOficina As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBIC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodEU As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckActivoB As System.Windows.Forms.CheckBox
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents bTiposProveedor As System.Windows.Forms.Button
    Friend WithEvents bTiposIVA As System.Windows.Forms.Button
    Friend WithEvents bTiposRetencion As System.Windows.Forms.Button
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents bTiposPago As System.Windows.Forms.Button
    Friend WithEvents bMediosPago As System.Windows.Forms.Button
    Friend WithEvents bBancos As System.Windows.Forms.Button
    Friend WithEvents cbPortes As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents bVerPais As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents suCliente As System.Windows.Forms.TextBox
    Friend WithEvents tbArticulos As System.Windows.Forms.TabPage
    Friend WithEvents lvArticulosComprados As System.Windows.Forms.ListView
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodAArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpArticulosCompradosHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpArticulosCompradosDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents ContadorVendidos As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents lbCambioVendidos As System.Windows.Forms.Label
    Friend WithEvents CantidadVendidos As System.Windows.Forms.TextBox
    Friend WithEvents TotalVendidos As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbArticuloComprados As System.Windows.Forms.ComboBox
End Class
