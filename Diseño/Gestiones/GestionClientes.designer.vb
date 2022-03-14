<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionClientes))
        Me.gbClientes = New System.Windows.Forms.GroupBox
        Me.bListado = New System.Windows.Forms.Button
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.gbCabecera = New System.Windows.Forms.GroupBox
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker
        Me.Label71 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ObservacionesProd = New System.Windows.Forms.TextBox
        Me.observaciones = New System.Windows.Forms.TextBox
        Me.lbBaja = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.web = New System.Windows.Forms.TextBox
        Me.nif = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.codCli = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.codContable = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.nombrecomercial = New System.Windows.Forms.TextBox
        Me.nombrefiscal = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbResponsable = New System.Windows.Forms.ComboBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.tbdatos = New System.Windows.Forms.TabControl
        Me.tbUbicaciones = New System.Windows.Forms.TabPage
        Me.bVerPais = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbPortes = New System.Windows.Forms.ComboBox
        Me.cbTransporte = New System.Windows.Forms.ComboBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.ckNoMostrarCliente = New System.Windows.Forms.CheckBox
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
        Me.subCliente = New System.Windows.Forms.TextBox
        Me.emailU = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
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
        Me.cbValorado = New System.Windows.Forms.ComboBox
        Me.bTiposIVA = New System.Windows.Forms.Button
        Me.bTiposRetencion = New System.Windows.Forms.Button
        Me.bMoneda = New System.Windows.Forms.Button
        Me.bTiposPago = New System.Windows.Forms.Button
        Me.bMediosPago = New System.Windows.Forms.Button
        Me.ProntoPago = New System.Windows.Forms.TextBox
        Me.Descuento2 = New System.Windows.Forms.TextBox
        Me.Descuento = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbRetencion = New System.Windows.Forms.ComboBox
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox
        Me.gbBancos = New System.Windows.Forms.GroupBox
        Me.ckActivoB = New System.Windows.Forms.CheckBox
        Me.bMenosBancos = New System.Windows.Forms.Button
        Me.bLimpiaBanco = New System.Windows.Forms.Button
        Me.bMasBanco = New System.Windows.Forms.Button
        Me.bBancos = New System.Windows.Forms.Button
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
        Me.Label58 = New System.Windows.Forms.Label
        Me.lbRecargoEq = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.cbDiaPago2 = New System.Windows.Forms.ComboBox
        Me.cbDiaPago1 = New System.Windows.Forms.ComboBox
        Me.ObservacionesF = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbTipoPago = New System.Windows.Forms.ComboBox
        Me.tbArticulosVendidos = New System.Windows.Forms.TabPage
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
        Me.lvArticulosVendidos = New System.Windows.Forms.ListView
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCodAArticuloCli = New System.Windows.Forms.ColumnHeader
        Me.lvArticuloCli = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvPrecio = New System.Windows.Forms.ColumnHeader
        Me.lvDocumento = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.dtpArticulosVendidosHasta = New System.Windows.Forms.DateTimePicker
        Me.Label61 = New System.Windows.Forms.Label
        Me.dtpArticulosVendidosDesde = New System.Windows.Forms.DateTimePicker
        Me.Label62 = New System.Windows.Forms.Label
        Me.tbOFertas = New System.Windows.Forms.TabPage
        Me.ContadorOfertas = New System.Windows.Forms.TextBox
        Me.Label76 = New System.Windows.Forms.Label
        Me.lbCambioOferta = New System.Windows.Forms.Label
        Me.TotalOfertas = New System.Windows.Forms.TextBox
        Me.Label72 = New System.Windows.Forms.Label
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label74 = New System.Windows.Forms.Label
        Me.Label75 = New System.Windows.Forms.Label
        Me.cbAnyoOferta = New System.Windows.Forms.ComboBox
        Me.cbEstadoOferta = New System.Windows.Forms.ComboBox
        Me.lvOfertas = New System.Windows.Forms.ListView
        Me.lvnumOferta = New System.Windows.Forms.ColumnHeader
        Me.lvRefClienteOF = New System.Windows.Forms.ColumnHeader
        Me.lvFechaOF = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoOF = New System.Windows.Forms.ColumnHeader
        Me.lvTotalOF = New System.Windows.Forms.ColumnHeader
        Me.tbProformas = New System.Windows.Forms.TabPage
        Me.ContadorProformas = New System.Windows.Forms.TextBox
        Me.Label70 = New System.Windows.Forms.Label
        Me.lbCambioProforma = New System.Windows.Forms.Label
        Me.TotalProformas = New System.Windows.Forms.TextBox
        Me.Label77 = New System.Windows.Forms.Label
        Me.Label78 = New System.Windows.Forms.Label
        Me.Label79 = New System.Windows.Forms.Label
        Me.Label80 = New System.Windows.Forms.Label
        Me.cbAnyoProforma = New System.Windows.Forms.ComboBox
        Me.cbEstadoProforma = New System.Windows.Forms.ComboBox
        Me.lvProformas = New System.Windows.Forms.ListView
        Me.lvnumProforma = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.tbPedidos = New System.Windows.Forms.TabPage
        Me.TotalServido = New System.Windows.Forms.TextBox
        Me.TotalPendiente = New System.Windows.Forms.TextBox
        Me.Label107 = New System.Windows.Forms.Label
        Me.Label108 = New System.Windows.Forms.Label
        Me.Label109 = New System.Windows.Forms.Label
        Me.Label110 = New System.Windows.Forms.Label
        Me.ContadorPedidos = New System.Windows.Forms.TextBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.lbCambioPedido = New System.Windows.Forms.Label
        Me.PortesPedido = New System.Windows.Forms.TextBox
        Me.TotalPedidos = New System.Windows.Forms.TextBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.Label63 = New System.Windows.Forms.Label
        Me.cbAnyoPedido = New System.Windows.Forms.ComboBox
        Me.cbEstadoPedido = New System.Windows.Forms.ComboBox
        Me.lvPedidos = New System.Windows.Forms.ListView
        Me.lvnumPedido = New System.Windows.Forms.ColumnHeader
        Me.lvRefClientePE = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPE = New System.Windows.Forms.ColumnHeader
        Me.lvEntregaPE = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoPE = New System.Windows.Forms.ColumnHeader
        Me.lvTotalPE = New System.Windows.Forms.ColumnHeader
        Me.lvPortesPE = New System.Windows.Forms.ColumnHeader
        Me.lvPendioentePE = New System.Windows.Forms.ColumnHeader
        Me.lvServido = New System.Windows.Forms.ColumnHeader
        Me.tbAlbaranes = New System.Windows.Forms.TabPage
        Me.lvAlbaranes = New System.Windows.Forms.ListView
        Me.lvNumAlbaran = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ContadorAlbaranes = New System.Windows.Forms.TextBox
        Me.Label90 = New System.Windows.Forms.Label
        Me.lbCambioAlbaran = New System.Windows.Forms.Label
        Me.TotalAlbaranes = New System.Windows.Forms.TextBox
        Me.Label86 = New System.Windows.Forms.Label
        Me.Label87 = New System.Windows.Forms.Label
        Me.Label88 = New System.Windows.Forms.Label
        Me.Label89 = New System.Windows.Forms.Label
        Me.cbAnyoAlbaran = New System.Windows.Forms.ComboBox
        Me.cbEstadoAlbaran = New System.Windows.Forms.ComboBox
        Me.tbFacturas = New System.Windows.Forms.TabPage
        Me.Base = New System.Windows.Forms.TextBox
        Me.IVA = New System.Windows.Forms.TextBox
        Me.Label81 = New System.Windows.Forms.Label
        Me.Label82 = New System.Windows.Forms.Label
        Me.Label83 = New System.Windows.Forms.Label
        Me.Label84 = New System.Windows.Forms.Label
        Me.LvFacturas = New System.Windows.Forms.ListView
        Me.lvnumFactura = New System.Windows.Forms.ColumnHeader
        Me.RefCliente = New System.Windows.Forms.ColumnHeader
        Me.lvFechaFactura = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoF = New System.Windows.Forms.ColumnHeader
        Me.lvTotalF = New System.Windows.Forms.ColumnHeader
        Me.lvIVA = New System.Windows.Forms.ColumnHeader
        Me.lvBase = New System.Windows.Forms.ColumnHeader
        Me.ContadorFacturas = New System.Windows.Forms.TextBox
        Me.Label97 = New System.Windows.Forms.Label
        Me.lbCambioFactura = New System.Windows.Forms.Label
        Me.TotalFacturas = New System.Windows.Forms.TextBox
        Me.Label93 = New System.Windows.Forms.Label
        Me.Label94 = New System.Windows.Forms.Label
        Me.Label95 = New System.Windows.Forms.Label
        Me.Label96 = New System.Windows.Forms.Label
        Me.cbAnyoFactura = New System.Windows.Forms.ComboBox
        Me.cbEstadoFactura = New System.Windows.Forms.ComboBox
        Me.tbComisiones = New System.Windows.Forms.TabPage
        Me.ObservacionesC = New System.Windows.Forms.TextBox
        Me.Label103 = New System.Windows.Forms.Label
        Me.ckLiquidados = New System.Windows.Forms.CheckBox
        Me.TotalBase = New System.Windows.Forms.TextBox
        Me.Label106 = New System.Windows.Forms.Label
        Me.TotalComisiones = New System.Windows.Forms.TextBox
        Me.Label104 = New System.Windows.Forms.Label
        Me.Label101 = New System.Windows.Forms.Label
        Me.Label102 = New System.Windows.Forms.Label
        Me.dtpComisionesHasta = New System.Windows.Forms.DateTimePicker
        Me.Label99 = New System.Windows.Forms.Label
        Me.dtpComisionesDesde = New System.Windows.Forms.DateTimePicker
        Me.Label100 = New System.Windows.Forms.Label
        Me.Comision = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label105 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lvCambiosComisiones = New System.Windows.Forms.ListView
        Me.lvidHistoricoCambio = New System.Windows.Forms.ColumnHeader
        Me.lvComercalCC = New System.Windows.Forms.ColumnHeader
        Me.lvFechaCC = New System.Windows.Forms.ColumnHeader
        Me.lvComisionAnt = New System.Windows.Forms.ColumnHeader
        Me.lvNuevaCom = New System.Windows.Forms.ColumnHeader
        Me.lvComisiones = New System.Windows.Forms.ListView
        Me.lvFacturaC = New System.Windows.Forms.ColumnHeader
        Me.lvFechaFacturaC = New System.Windows.Forms.ColumnHeader
        Me.lvImporteFactura = New System.Windows.Forms.ColumnHeader
        Me.lvComercial = New System.Windows.Forms.ColumnHeader
        Me.lvPorcentajeC = New System.Windows.Forms.ColumnHeader
        Me.lvImporteComision = New System.Windows.Forms.ColumnHeader
        Me.lvFechaLiquidacion = New System.Windows.Forms.ColumnHeader
        Me.lvidLiquidacion = New System.Windows.Forms.ColumnHeader
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.gbClientes.SuspendLayout()
        Me.gbCabecera.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbdatos.SuspendLayout()
        Me.tbUbicaciones.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbcontactos.SuspendLayout()
        Me.tbfacturacion.SuspendLayout()
        Me.gbBancos.SuspendLayout()
        Me.tbArticulosVendidos.SuspendLayout()
        Me.tbOFertas.SuspendLayout()
        Me.tbProformas.SuspendLayout()
        Me.tbPedidos.SuspendLayout()
        Me.tbAlbaranes.SuspendLayout()
        Me.tbFacturas.SuspendLayout()
        Me.tbComisiones.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbClientes
        '
        Me.gbClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbClientes.Controls.Add(Me.bListado)
        Me.gbClientes.Controls.Add(Me.bSubir)
        Me.gbClientes.Controls.Add(Me.bBajar)
        Me.gbClientes.Controls.Add(Me.gbCabecera)
        Me.gbClientes.Controls.Add(Me.PictureBox1)
        Me.gbClientes.Controls.Add(Me.bSalir)
        Me.gbClientes.Controls.Add(Me.tbdatos)
        Me.gbClientes.Controls.Add(Me.bNuevo)
        Me.gbClientes.Controls.Add(Me.bBorrar)
        Me.gbClientes.Controls.Add(Me.bGuardar)
        Me.gbClientes.Location = New System.Drawing.Point(3, 0)
        Me.gbClientes.Name = "gbClientes"
        Me.gbClientes.Size = New System.Drawing.Size(1008, 760)
        Me.gbClientes.TabIndex = 0
        Me.gbClientes.TabStop = False
        '
        'bListado
        '
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bListado.Location = New System.Drawing.Point(688, 24)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 6
        Me.bListado.Text = "IMPRIMIR"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'bSubir
        '
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(377, 24)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(85, 22)
        Me.bSubir.TabIndex = 2
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(377, 52)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(85, 22)
        Me.bBajar.TabIndex = 3
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.ckActivo)
        Me.gbCabecera.Controls.Add(Me.dtpFechaBaja)
        Me.gbCabecera.Controls.Add(Me.dtpFechaAlta)
        Me.gbCabecera.Controls.Add(Me.Label71)
        Me.gbCabecera.Controls.Add(Me.Label2)
        Me.gbCabecera.Controls.Add(Me.ObservacionesProd)
        Me.gbCabecera.Controls.Add(Me.observaciones)
        Me.gbCabecera.Controls.Add(Me.lbBaja)
        Me.gbCabecera.Controls.Add(Me.Label12)
        Me.gbCabecera.Controls.Add(Me.Label41)
        Me.gbCabecera.Controls.Add(Me.Label14)
        Me.gbCabecera.Controls.Add(Me.Label45)
        Me.gbCabecera.Controls.Add(Me.web)
        Me.gbCabecera.Controls.Add(Me.nif)
        Me.gbCabecera.Controls.Add(Me.Label42)
        Me.gbCabecera.Controls.Add(Me.codCli)
        Me.gbCabecera.Controls.Add(Me.Label5)
        Me.gbCabecera.Controls.Add(Me.codContable)
        Me.gbCabecera.Controls.Add(Me.Label6)
        Me.gbCabecera.Controls.Add(Me.nombrecomercial)
        Me.gbCabecera.Controls.Add(Me.nombrefiscal)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Controls.Add(Me.cbResponsable)
        Me.gbCabecera.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCabecera.Location = New System.Drawing.Point(12, 80)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(972, 185)
        Me.gbCabecera.TabIndex = 0
        Me.gbCabecera.TabStop = False
        Me.gbCabecera.Text = "DATOS GENERALES"
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(695, 28)
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
        Me.dtpFechaBaja.Location = New System.Drawing.Point(862, 27)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaBaja.TabIndex = 4
        Me.dtpFechaBaja.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAlta.Location = New System.Drawing.Point(579, 27)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaAlta.TabIndex = 2
        Me.dtpFechaAlta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label71.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label71.Location = New System.Drawing.Point(463, 116)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(113, 36)
        Me.Label71.TabIndex = 119
        Me.Label71.Text = "OBSERVACIONES PRODUCCIÓN"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(6, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 39)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "OBSERVACIONES VENTAS"
        '
        'ObservacionesProd
        '
        Me.ObservacionesProd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesProd.Location = New System.Drawing.Point(577, 115)
        Me.ObservacionesProd.MaxLength = 200
        Me.ObservacionesProd.Multiline = True
        Me.ObservacionesProd.Name = "ObservacionesProd"
        Me.ObservacionesProd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservacionesProd.Size = New System.Drawing.Size(379, 56)
        Me.ObservacionesProd.TabIndex = 11
        '
        'observaciones
        '
        Me.observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observaciones.Location = New System.Drawing.Point(139, 114)
        Me.observaciones.MaxLength = 200
        Me.observaciones.Multiline = True
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observaciones.Size = New System.Drawing.Size(321, 56)
        Me.observaciones.TabIndex = 10
        '
        'lbBaja
        '
        Me.lbBaja.AutoSize = True
        Me.lbBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbBaja.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbBaja.Location = New System.Drawing.Point(774, 30)
        Me.lbBaja.Name = "lbBaja"
        Me.lbBaja.Size = New System.Drawing.Size(85, 17)
        Me.lbBaja.TabIndex = 4
        Me.lbBaja.Text = "FECHA BAJA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(212, 30)
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
        Me.Label41.Location = New System.Drawing.Point(463, 30)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(83, 17)
        Me.Label41.TabIndex = 99
        Me.Label41.Text = "FECHA ALTA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(680, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 17)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "COMERCIAL"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label45.Location = New System.Drawing.Point(6, 59)
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
        Me.web.Size = New System.Drawing.Size(345, 23)
        Me.web.TabIndex = 8
        '
        'nif
        '
        Me.nif.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nif.Location = New System.Drawing.Point(139, 88)
        Me.nif.MaxLength = 15
        Me.nif.Name = "nif"
        Me.nif.Size = New System.Drawing.Size(116, 23)
        Me.nif.TabIndex = 7
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(6, 30)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(97, 17)
        Me.Label42.TabIndex = 98
        Me.Label42.Text = "CÓD. CLIENTE"
        '
        'codCli
        '
        Me.codCli.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codCli.ForeColor = System.Drawing.Color.DarkRed
        Me.codCli.Location = New System.Drawing.Point(139, 27)
        Me.codCli.Name = "codCli"
        Me.codCli.Size = New System.Drawing.Size(67, 23)
        Me.codCli.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(6, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 17)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "NIF / CIF"
        '
        'codContable
        '
        Me.codContable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codContable.ForeColor = System.Drawing.Color.DarkRed
        Me.codContable.Location = New System.Drawing.Point(329, 27)
        Me.codContable.Name = "codContable"
        Me.codContable.Size = New System.Drawing.Size(131, 23)
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
        Me.nombrecomercial.Location = New System.Drawing.Point(139, 56)
        Me.nombrecomercial.MaxLength = 50
        Me.nombrecomercial.Name = "nombrecomercial"
        Me.nombrecomercial.Size = New System.Drawing.Size(321, 23)
        Me.nombrecomercial.TabIndex = 5
        '
        'nombrefiscal
        '
        Me.nombrefiscal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombrefiscal.Location = New System.Drawing.Point(579, 56)
        Me.nombrefiscal.MaxLength = 50
        Me.nombrefiscal.Name = "nombrefiscal"
        Me.nombrefiscal.Size = New System.Drawing.Size(377, 23)
        Me.nombrefiscal.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(463, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 17)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "NOMBRE FISCAL"
        '
        'cbResponsable
        '
        Me.cbResponsable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbResponsable.FormattingEnabled = True
        Me.cbResponsable.Location = New System.Drawing.Point(768, 84)
        Me.cbResponsable.MaxLength = 15
        Me.cbResponsable.Name = "cbResponsable"
        Me.cbResponsable.Size = New System.Drawing.Size(188, 25)
        Me.cbResponsable.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
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
        Me.bSalir.Location = New System.Drawing.Point(898, 24)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
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
        Me.tbdatos.Controls.Add(Me.tbArticulosVendidos)
        Me.tbdatos.Controls.Add(Me.tbOFertas)
        Me.tbdatos.Controls.Add(Me.tbProformas)
        Me.tbdatos.Controls.Add(Me.tbPedidos)
        Me.tbdatos.Controls.Add(Me.tbAlbaranes)
        Me.tbdatos.Controls.Add(Me.tbFacturas)
        Me.tbdatos.Controls.Add(Me.tbComisiones)
        Me.tbdatos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbdatos.HotTrack = True
        Me.tbdatos.Location = New System.Drawing.Point(12, 279)
        Me.tbdatos.Name = "tbdatos"
        Me.tbdatos.SelectedIndex = 0
        Me.tbdatos.Size = New System.Drawing.Size(990, 471)
        Me.tbdatos.TabIndex = 1
        '
        'tbUbicaciones
        '
        Me.tbUbicaciones.BackColor = System.Drawing.Color.White
        Me.tbUbicaciones.Controls.Add(Me.bVerPais)
        Me.tbUbicaciones.Controls.Add(Me.GroupBox3)
        Me.tbUbicaciones.Controls.Add(Me.ckNoMostrarCliente)
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
        Me.tbUbicaciones.Controls.Add(Me.subCliente)
        Me.tbUbicaciones.Controls.Add(Me.emailU)
        Me.tbUbicaciones.Controls.Add(Me.Label43)
        Me.tbUbicaciones.Controls.Add(Me.Label27)
        Me.tbUbicaciones.Controls.Add(Me.Label30)
        Me.tbUbicaciones.Controls.Add(Me.Label29)
        Me.tbUbicaciones.Location = New System.Drawing.Point(4, 26)
        Me.tbUbicaciones.Name = "tbUbicaciones"
        Me.tbUbicaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbUbicaciones.Size = New System.Drawing.Size(982, 441)
        Me.tbUbicaciones.TabIndex = 9
        Me.tbUbicaciones.Text = "DIRECCIONES"
        Me.tbUbicaciones.UseVisualStyleBackColor = True
        '
        'bVerPais
        '
        Me.bVerPais.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerPais.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerPais.Location = New System.Drawing.Point(311, 145)
        Me.bVerPais.Name = "bVerPais"
        Me.bVerPais.Size = New System.Drawing.Size(27, 25)
        Me.bVerPais.TabIndex = 10
        Me.bVerPais.Text = "...."
        Me.bVerPais.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbPortes)
        Me.GroupBox3.Controls.Add(Me.cbTransporte)
        Me.GroupBox3.Controls.Add(Me.Label60)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(720, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(213, 89)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TRANSPORTE"
        '
        'cbPortes
        '
        Me.cbPortes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPortes.FormattingEnabled = True
        Me.cbPortes.Location = New System.Drawing.Point(85, 23)
        Me.cbPortes.Name = "cbPortes"
        Me.cbPortes.Size = New System.Drawing.Size(118, 25)
        Me.cbPortes.Sorted = True
        Me.cbPortes.TabIndex = 0
        '
        'cbTransporte
        '
        Me.cbTransporte.DropDownWidth = 150
        Me.cbTransporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTransporte.FormattingEnabled = True
        Me.cbTransporte.Location = New System.Drawing.Point(85, 56)
        Me.cbTransporte.Name = "cbTransporte"
        Me.cbTransporte.Size = New System.Drawing.Size(118, 25)
        Me.cbTransporte.TabIndex = 1
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label60.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label60.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label60.Location = New System.Drawing.Point(6, 26)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(53, 17)
        Me.Label60.TabIndex = 138
        Me.Label60.Text = "PORTES"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label47.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label47.Location = New System.Drawing.Point(4, 59)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(68, 17)
        Me.Label47.TabIndex = 138
        Me.Label47.Text = "AGENCIA"
        '
        'ckNoMostrarCliente
        '
        Me.ckNoMostrarCliente.AutoSize = True
        Me.ckNoMostrarCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckNoMostrarCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckNoMostrarCliente.Location = New System.Drawing.Point(487, 73)
        Me.ckNoMostrarCliente.Name = "ckNoMostrarCliente"
        Me.ckNoMostrarCliente.Size = New System.Drawing.Size(163, 21)
        Me.ckNoMostrarCliente.TabIndex = 6
        Me.ckNoMostrarCliente.Text = "NO MOSTRAR CLIENTE"
        Me.ckNoMostrarCliente.UseVisualStyleBackColor = True
        '
        'ckActivoU
        '
        Me.ckActivoU.AutoSize = True
        Me.ckActivoU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckActivoU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoU.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoU.Location = New System.Drawing.Point(426, 17)
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
        Me.Label38.Location = New System.Drawing.Point(721, 117)
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
        Me.cbIdioma.Location = New System.Drawing.Point(807, 113)
        Me.cbIdioma.Name = "cbIdioma"
        Me.cbIdioma.Size = New System.Drawing.Size(118, 25)
        Me.cbIdioma.TabIndex = 8
        '
        'cbPaisU
        '
        Me.cbPaisU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPaisU.FormattingEnabled = True
        Me.cbPaisU.Location = New System.Drawing.Point(135, 145)
        Me.cbPaisU.Name = "cbPaisU"
        Me.cbPaisU.Size = New System.Drawing.Size(160, 25)
        Me.cbPaisU.TabIndex = 9
        Me.cbPaisU.Text = "ESPAÑA"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(7, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 17)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "TIPO DIRECCIÓN"
        '
        'dtpFechaBajaU
        '
        Me.dtpFechaBajaU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBajaU.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBajaU.Location = New System.Drawing.Point(554, 44)
        Me.dtpFechaBajaU.Name = "dtpFechaBajaU"
        Me.dtpFechaBajaU.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaBajaU.TabIndex = 3
        Me.dtpFechaBajaU.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFechaAltaU
        '
        Me.dtpFechaAltaU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAltaU.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAltaU.Location = New System.Drawing.Point(554, 14)
        Me.dtpFechaAltaU.Name = "dtpFechaAltaU"
        Me.dtpFechaAltaU.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaAltaU.TabIndex = 2
        Me.dtpFechaAltaU.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'TelefonoU2
        '
        Me.TelefonoU2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonoU2.Location = New System.Drawing.Point(807, 177)
        Me.TelefonoU2.MaxLength = 20
        Me.TelefonoU2.Name = "TelefonoU2"
        Me.TelefonoU2.Size = New System.Drawing.Size(117, 23)
        Me.TelefonoU2.TabIndex = 15
        '
        'TelefonoU1
        '
        Me.TelefonoU1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonoU1.Location = New System.Drawing.Point(808, 146)
        Me.TelefonoU1.MaxLength = 20
        Me.TelefonoU1.Name = "TelefonoU1"
        Me.TelefonoU1.Size = New System.Drawing.Size(117, 23)
        Me.TelefonoU1.TabIndex = 12
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
        Me.Label44.Location = New System.Drawing.Point(721, 180)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(82, 17)
        Me.Label44.TabIndex = 53
        Me.Label44.Text = "TELÉFONO 2"
        '
        'Direccion
        '
        Me.Direccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Direccion.Location = New System.Drawing.Point(135, 100)
        Me.Direccion.MaxLength = 150
        Me.Direccion.Multiline = True
        Me.Direccion.Name = "Direccion"
        Me.Direccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Direccion.Size = New System.Drawing.Size(513, 40)
        Me.Direccion.TabIndex = 7
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(721, 149)
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
        Me.cbLocalidad.Location = New System.Drawing.Point(135, 176)
        Me.cbLocalidad.Name = "cbLocalidad"
        Me.cbLocalidad.Size = New System.Drawing.Size(276, 25)
        Me.cbLocalidad.TabIndex = 13
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
        Me.cbProvincia.TabIndex = 11
        '
        'cbTipoU
        '
        Me.cbTipoU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoU.FormattingEnabled = True
        Me.cbTipoU.Location = New System.Drawing.Point(135, 14)
        Me.cbTipoU.MaxLength = 15
        Me.cbTipoU.Name = "cbTipoU"
        Me.cbTipoU.Size = New System.Drawing.Size(268, 25)
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
        Me.lvDirecciones.Size = New System.Drawing.Size(939, 147)
        Me.lvDirecciones.TabIndex = 20
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
        Me.lvtipo.Text = "SUBCLIENTE"
        Me.lvtipo.Width = 150
        '
        'lvdireccion
        '
        Me.lvdireccion.Text = "DIRECCIÓN"
        Me.lvdireccion.Width = 400
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
        Me.lbBajaU.Location = New System.Drawing.Point(509, 48)
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
        Me.Label23.Location = New System.Drawing.Point(511, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 17)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "ALTA"
        '
        'faxU
        '
        Me.faxU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faxU.Location = New System.Drawing.Point(808, 208)
        Me.faxU.MaxLength = 20
        Me.faxU.Name = "faxU"
        Me.faxU.Size = New System.Drawing.Size(117, 23)
        Me.faxU.TabIndex = 17
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
        Me.Label25.Text = "CÓD. POSTAL"
        '
        'observacioneU
        '
        Me.observacioneU.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observacioneU.Location = New System.Drawing.Point(135, 236)
        Me.observacioneU.MaxLength = 200
        Me.observacioneU.Multiline = True
        Me.observacioneU.Name = "observacioneU"
        Me.observacioneU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observacioneU.Size = New System.Drawing.Size(424, 40)
        Me.observacioneU.TabIndex = 18
        '
        'HorarioU
        '
        Me.HorarioU.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HorarioU.Location = New System.Drawing.Point(720, 237)
        Me.HorarioU.MaxLength = 100
        Me.HorarioU.Multiline = True
        Me.HorarioU.Name = "HorarioU"
        Me.HorarioU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.HorarioU.Size = New System.Drawing.Size(205, 40)
        Me.HorarioU.TabIndex = 19
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(721, 211)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(31, 17)
        Me.Label31.TabIndex = 54
        Me.Label31.Text = "FAX"
        '
        'codPostal
        '
        Me.codPostal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codPostal.Location = New System.Drawing.Point(531, 177)
        Me.codPostal.MaxLength = 10
        Me.codPostal.Name = "codPostal"
        Me.codPostal.Size = New System.Drawing.Size(117, 23)
        Me.codPostal.TabIndex = 14
        '
        'subCliente
        '
        Me.subCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subCliente.Location = New System.Drawing.Point(135, 71)
        Me.subCliente.MaxLength = 150
        Me.subCliente.Name = "subCliente"
        Me.subCliente.Size = New System.Drawing.Size(334, 23)
        Me.subCliente.TabIndex = 5
        '
        'emailU
        '
        Me.emailU.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailU.Location = New System.Drawing.Point(135, 207)
        Me.emailU.MaxLength = 150
        Me.emailU.Name = "emailU"
        Me.emailU.Size = New System.Drawing.Size(513, 23)
        Me.emailU.TabIndex = 16
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label43.Location = New System.Drawing.Point(7, 74)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(118, 17)
        Me.Label43.TabIndex = 55
        Me.Label43.Text = "CLIENTE ENTREGA"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(341, 148)
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
        Me.Label29.Location = New System.Drawing.Point(643, 239)
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
        Me.tbcontactos.Size = New System.Drawing.Size(982, 441)
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
        Me.apellidoscontacto.Size = New System.Drawing.Size(540, 23)
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
        Me.Label36.Location = New System.Drawing.Point(329, 50)
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
        Me.nombrecontacto.Location = New System.Drawing.Point(135, 46)
        Me.nombrecontacto.MaxLength = 50
        Me.nombrecontacto.Name = "nombrecontacto"
        Me.nombrecontacto.Size = New System.Drawing.Size(171, 23)
        Me.nombrecontacto.TabIndex = 1
        '
        'emailContacto
        '
        Me.emailContacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailContacto.Location = New System.Drawing.Point(135, 107)
        Me.emailContacto.MaxLength = 50
        Me.emailContacto.Name = "emailContacto"
        Me.emailContacto.Size = New System.Drawing.Size(445, 23)
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
        Me.lvContactos.Size = New System.Drawing.Size(939, 231)
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
        Me.lvtelefonos.Width = 175
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
        Me.lvemail.Text = "E-MAIL"
        Me.lvemail.Width = 211
        '
        'cbDirecciones
        '
        Me.cbDirecciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDirecciones.FormattingEnabled = True
        Me.cbDirecciones.Location = New System.Drawing.Point(135, 14)
        Me.cbDirecciones.MaxLength = 6
        Me.cbDirecciones.Name = "cbDirecciones"
        Me.cbDirecciones.Size = New System.Drawing.Size(814, 25)
        Me.cbDirecciones.Sorted = True
        Me.cbDirecciones.TabIndex = 0
        '
        'cbDepartamento
        '
        Me.cbDepartamento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartamento.FormattingEnabled = True
        Me.cbDepartamento.Location = New System.Drawing.Point(135, 76)
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
        Me.ObservacionesContacto.Location = New System.Drawing.Point(135, 137)
        Me.ObservacionesContacto.MaxLength = 100
        Me.ObservacionesContacto.Multiline = True
        Me.ObservacionesContacto.Name = "ObservacionesContacto"
        Me.ObservacionesContacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservacionesContacto.Size = New System.Drawing.Size(814, 40)
        Me.ObservacionesContacto.TabIndex = 8
        '
        'cargocontacto
        '
        Me.cargocontacto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cargocontacto.Location = New System.Drawing.Point(705, 107)
        Me.cargocontacto.MaxLength = 20
        Me.cargocontacto.Name = "cargocontacto"
        Me.cargocontacto.Size = New System.Drawing.Size(244, 23)
        Me.cargocontacto.TabIndex = 7
        '
        'tbfacturacion
        '
        Me.tbfacturacion.BackColor = System.Drawing.Color.White
        Me.tbfacturacion.Controls.Add(Me.cbValorado)
        Me.tbfacturacion.Controls.Add(Me.bTiposIVA)
        Me.tbfacturacion.Controls.Add(Me.bTiposRetencion)
        Me.tbfacturacion.Controls.Add(Me.bMoneda)
        Me.tbfacturacion.Controls.Add(Me.bTiposPago)
        Me.tbfacturacion.Controls.Add(Me.bMediosPago)
        Me.tbfacturacion.Controls.Add(Me.ProntoPago)
        Me.tbfacturacion.Controls.Add(Me.Descuento2)
        Me.tbfacturacion.Controls.Add(Me.Descuento)
        Me.tbfacturacion.Controls.Add(Me.Label28)
        Me.tbfacturacion.Controls.Add(Me.Label16)
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
        Me.tbfacturacion.Controls.Add(Me.Label58)
        Me.tbfacturacion.Controls.Add(Me.lbRecargoEq)
        Me.tbfacturacion.Controls.Add(Me.Label55)
        Me.tbfacturacion.Controls.Add(Me.Label53)
        Me.tbfacturacion.Controls.Add(Me.Label48)
        Me.tbfacturacion.Controls.Add(Me.Label59)
        Me.tbfacturacion.Controls.Add(Me.Label24)
        Me.tbfacturacion.Controls.Add(Me.cbDiaPago2)
        Me.tbfacturacion.Controls.Add(Me.cbDiaPago1)
        Me.tbfacturacion.Controls.Add(Me.ObservacionesF)
        Me.tbfacturacion.Controls.Add(Me.Label10)
        Me.tbfacturacion.Controls.Add(Me.cbTipoPago)
        Me.tbfacturacion.Location = New System.Drawing.Point(4, 26)
        Me.tbfacturacion.Name = "tbfacturacion"
        Me.tbfacturacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbfacturacion.Size = New System.Drawing.Size(982, 441)
        Me.tbfacturacion.TabIndex = 2
        Me.tbfacturacion.Text = "DATOS FACTURACIÓN"
        Me.tbfacturacion.UseVisualStyleBackColor = True
        '
        'cbValorado
        '
        Me.cbValorado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValorado.FormattingEnabled = True
        Me.cbValorado.Location = New System.Drawing.Point(517, 46)
        Me.cbValorado.Name = "cbValorado"
        Me.cbValorado.Size = New System.Drawing.Size(183, 25)
        Me.cbValorado.TabIndex = 6
        '
        'bTiposIVA
        '
        Me.bTiposIVA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposIVA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposIVA.Location = New System.Drawing.Point(289, 110)
        Me.bTiposIVA.Name = "bTiposIVA"
        Me.bTiposIVA.Size = New System.Drawing.Size(27, 25)
        Me.bTiposIVA.TabIndex = 14
        Me.bTiposIVA.Text = "...."
        Me.bTiposIVA.UseVisualStyleBackColor = True
        '
        'bTiposRetencion
        '
        Me.bTiposRetencion.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposRetencion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposRetencion.Location = New System.Drawing.Point(847, 109)
        Me.bTiposRetencion.Name = "bTiposRetencion"
        Me.bTiposRetencion.Size = New System.Drawing.Size(27, 25)
        Me.bTiposRetencion.TabIndex = 18
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
        Me.bMoneda.TabIndex = 1
        Me.bMoneda.Text = "...."
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'bTiposPago
        '
        Me.bTiposPago.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTiposPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTiposPago.Location = New System.Drawing.Point(410, 78)
        Me.bTiposPago.Name = "bTiposPago"
        Me.bTiposPago.Size = New System.Drawing.Size(27, 25)
        Me.bTiposPago.TabIndex = 9
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
        Me.bMediosPago.TabIndex = 5
        Me.bMediosPago.Text = "...."
        Me.bMediosPago.UseVisualStyleBackColor = True
        '
        'ProntoPago
        '
        Me.ProntoPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProntoPago.Location = New System.Drawing.Point(811, 47)
        Me.ProntoPago.MaxLength = 4
        Me.ProntoPago.Name = "ProntoPago"
        Me.ProntoPago.Size = New System.Drawing.Size(40, 23)
        Me.ProntoPago.TabIndex = 7
        '
        'Descuento2
        '
        Me.Descuento2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento2.Location = New System.Drawing.Point(811, 15)
        Me.Descuento2.MaxLength = 4
        Me.Descuento2.Name = "Descuento2"
        Me.Descuento2.Size = New System.Drawing.Size(40, 23)
        Me.Descuento2.TabIndex = 3
        '
        'Descuento
        '
        Me.Descuento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descuento.Location = New System.Drawing.Point(517, 15)
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
        Me.Label28.Location = New System.Drawing.Point(576, 114)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 17)
        Me.Label28.TabIndex = 140
        Me.Label28.Text = "RETENCIÓN"
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
        Me.cbRetencion.TabIndex = 17
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Location = New System.Drawing.Point(135, 110)
        Me.cbTipoIVA.Name = "cbTipoIVA"
        Me.cbTipoIVA.Size = New System.Drawing.Size(142, 25)
        Me.cbTipoIVA.TabIndex = 13
        '
        'gbBancos
        '
        Me.gbBancos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBancos.Controls.Add(Me.ckActivoB)
        Me.gbBancos.Controls.Add(Me.bMenosBancos)
        Me.gbBancos.Controls.Add(Me.bLimpiaBanco)
        Me.gbBancos.Controls.Add(Me.bMasBanco)
        Me.gbBancos.Controls.Add(Me.bBancos)
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
        Me.gbBancos.Location = New System.Drawing.Point(9, 188)
        Me.gbBancos.Name = "gbBancos"
        Me.gbBancos.Size = New System.Drawing.Size(967, 242)
        Me.gbBancos.TabIndex = 20
        Me.gbBancos.TabStop = False
        Me.gbBancos.Text = "CUENTAS BANCARIAS"
        '
        'ckActivoB
        '
        Me.ckActivoB.AutoSize = True
        Me.ckActivoB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoB.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoB.Location = New System.Drawing.Point(423, 26)
        Me.ckActivoB.Name = "ckActivoB"
        Me.ckActivoB.Size = New System.Drawing.Size(75, 21)
        Me.ckActivoB.TabIndex = 2
        Me.ckActivoB.Text = "ACTIVO"
        Me.ckActivoB.UseVisualStyleBackColor = True
        '
        'bMenosBancos
        '
        Me.bMenosBancos.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMenosBancos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bMenosBancos.Location = New System.Drawing.Point(840, 41)
        Me.bMenosBancos.Name = "bMenosBancos"
        Me.bMenosBancos.Size = New System.Drawing.Size(23, 23)
        Me.bMenosBancos.TabIndex = 11
        Me.bMenosBancos.Text = "-"
        Me.bMenosBancos.UseVisualStyleBackColor = True
        '
        'bLimpiaBanco
        '
        Me.bLimpiaBanco.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiaBanco.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiaBanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiaBanco.Location = New System.Drawing.Point(840, 67)
        Me.bLimpiaBanco.Name = "bLimpiaBanco"
        Me.bLimpiaBanco.Size = New System.Drawing.Size(23, 23)
        Me.bLimpiaBanco.TabIndex = 12
        Me.bLimpiaBanco.UseVisualStyleBackColor = True
        '
        'bMasBanco
        '
        Me.bMasBanco.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMasBanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bMasBanco.Location = New System.Drawing.Point(840, 15)
        Me.bMasBanco.Name = "bMasBanco"
        Me.bMasBanco.Size = New System.Drawing.Size(23, 23)
        Me.bMasBanco.TabIndex = 10
        Me.bMasBanco.Text = "+"
        Me.bMasBanco.UseVisualStyleBackColor = True
        '
        'bBancos
        '
        Me.bBancos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBancos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBancos.Location = New System.Drawing.Point(368, 24)
        Me.bBancos.Name = "bBancos"
        Me.bBancos.Size = New System.Drawing.Size(27, 25)
        Me.bBancos.TabIndex = 1
        Me.bBancos.Text = "...."
        Me.bBancos.UseVisualStyleBackColor = True
        '
        'IBAN
        '
        Me.IBAN.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IBAN.Location = New System.Drawing.Point(543, 25)
        Me.IBAN.MaxLength = 34
        Me.IBAN.Name = "IBAN"
        Me.IBAN.Size = New System.Drawing.Size(276, 23)
        Me.IBAN.TabIndex = 3
        '
        'SWIFT_BIC
        '
        Me.SWIFT_BIC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SWIFT_BIC.Location = New System.Drawing.Point(126, 52)
        Me.SWIFT_BIC.MaxLength = 11
        Me.SWIFT_BIC.Name = "SWIFT_BIC"
        Me.SWIFT_BIC.Size = New System.Drawing.Size(118, 23)
        Me.SWIFT_BIC.TabIndex = 4
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
        Me.lvBancos.Size = New System.Drawing.Size(931, 129)
        Me.lvBancos.TabIndex = 13
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
        Me.codigocuenta.TabIndex = 9
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
        Me.codigodc.TabIndex = 8
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
        Me.Label57.Location = New System.Drawing.Point(502, 28)
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
        Me.codigoEU.TabIndex = 5
        Me.codigoEU.Text = "ES"
        '
        'codigobanco
        '
        Me.codigobanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigobanco.Location = New System.Drawing.Point(423, 55)
        Me.codigobanco.MaxLength = 4
        Me.codigobanco.Name = "codigobanco"
        Me.codigobanco.Size = New System.Drawing.Size(45, 23)
        Me.codigobanco.TabIndex = 6
        '
        'codigooficina
        '
        Me.codigooficina.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codigooficina.Location = New System.Drawing.Point(543, 55)
        Me.codigooficina.MaxLength = 4
        Me.codigooficina.Name = "codigooficina"
        Me.codigooficina.Size = New System.Drawing.Size(45, 23)
        Me.codigooficina.TabIndex = 7
        '
        'cbBanco
        '
        Me.cbBanco.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(126, 24)
        Me.cbBanco.MaxLength = 15
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(229, 25)
        Me.cbBanco.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(7, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 17)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "BANCO"
        '
        'cbMoneda
        '
        Me.cbMoneda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Location = New System.Drawing.Point(135, 14)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(142, 25)
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
        Me.ckRecargoEquivalencia.TabIndex = 15
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
        Me.RecargoEq.TabIndex = 16
        '
        'ckExentoPagosAgosto
        '
        Me.ckExentoPagosAgosto.AutoSize = True
        Me.ckExentoPagosAgosto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckExentoPagosAgosto.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckExentoPagosAgosto.Location = New System.Drawing.Point(718, 80)
        Me.ckExentoPagosAgosto.Name = "ckExentoPagosAgosto"
        Me.ckExentoPagosAgosto.Size = New System.Drawing.Size(181, 21)
        Me.ckExentoPagosAgosto.TabIndex = 12
        Me.ckExentoPagosAgosto.Text = "EXENTO PAGOS AGOSTO"
        Me.ckExentoPagosAgosto.UseVisualStyleBackColor = True
        '
        'cbMedioPago
        '
        Me.cbMedioPago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMedioPago.FormattingEnabled = True
        Me.cbMedioPago.Location = New System.Drawing.Point(135, 46)
        Me.cbMedioPago.MaxLength = 15
        Me.cbMedioPago.Name = "cbMedioPago"
        Me.cbMedioPago.Size = New System.Drawing.Size(259, 25)
        Me.cbMedioPago.TabIndex = 4
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
        Me.Label50.Location = New System.Drawing.Point(704, 50)
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
        Me.Label54.Location = New System.Drawing.Point(853, 50)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(18, 17)
        Me.Label54.TabIndex = 86
        Me.Label54.Text = "%"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label58.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label58.Location = New System.Drawing.Point(853, 18)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(18, 17)
        Me.Label58.TabIndex = 86
        Me.Label58.Text = "%"
        '
        'lbRecargoEq
        '
        Me.lbRecargoEq.AutoSize = True
        Me.lbRecargoEq.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRecargoEq.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbRecargoEq.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbRecargoEq.Location = New System.Drawing.Point(558, 114)
        Me.lbRecargoEq.Name = "lbRecargoEq"
        Me.lbRecargoEq.Size = New System.Drawing.Size(18, 17)
        Me.lbRecargoEq.TabIndex = 86
        Me.lbRecargoEq.Text = "%"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label55.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label55.Location = New System.Drawing.Point(607, 18)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(199, 17)
        Me.Label55.TabIndex = 86
        Me.Label55.Text = "DESCUENTO TARIFA INDUSTRIAL"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label53.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label53.Location = New System.Drawing.Point(558, 18)
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
        Me.Label48.Location = New System.Drawing.Point(347, 18)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(162, 17)
        Me.Label48.TabIndex = 86
        Me.Label48.Text = "DESCUENTO DOMÉSTICO"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label59.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label59.Location = New System.Drawing.Point(444, 50)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(66, 17)
        Me.Label59.TabIndex = 86
        Me.Label59.Text = "ALBARÁN"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(438, 82)
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
        Me.cbDiaPago2.TabIndex = 11
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
        Me.cbDiaPago1.TabIndex = 10
        '
        'ObservacionesF
        '
        Me.ObservacionesF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesF.Location = New System.Drawing.Point(135, 142)
        Me.ObservacionesF.MaxLength = 100
        Me.ObservacionesF.Multiline = True
        Me.ObservacionesF.Name = "ObservacionesF"
        Me.ObservacionesF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ObservacionesF.Size = New System.Drawing.Size(738, 40)
        Me.ObservacionesF.TabIndex = 19
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
        Me.cbTipoPago.Location = New System.Drawing.Point(135, 78)
        Me.cbTipoPago.MaxLength = 15
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.Size = New System.Drawing.Size(259, 25)
        Me.cbTipoPago.TabIndex = 8
        '
        'tbArticulosVendidos
        '
        Me.tbArticulosVendidos.Controls.Add(Me.ContadorVendidos)
        Me.tbArticulosVendidos.Controls.Add(Me.Label98)
        Me.tbArticulosVendidos.Controls.Add(Me.lbCambioVendidos)
        Me.tbArticulosVendidos.Controls.Add(Me.CantidadVendidos)
        Me.tbArticulosVendidos.Controls.Add(Me.TotalVendidos)
        Me.tbArticulosVendidos.Controls.Add(Me.Label92)
        Me.tbArticulosVendidos.Controls.Add(Me.Label85)
        Me.tbArticulosVendidos.Controls.Add(Me.Label91)
        Me.tbArticulosVendidos.Controls.Add(Me.lbSubTipo)
        Me.tbArticulosVendidos.Controls.Add(Me.lbTipo)
        Me.tbArticulosVendidos.Controls.Add(Me.cbSubTipo)
        Me.tbArticulosVendidos.Controls.Add(Me.cbTipo)
        Me.tbArticulosVendidos.Controls.Add(Me.lvArticulosVendidos)
        Me.tbArticulosVendidos.Controls.Add(Me.dtpArticulosVendidosHasta)
        Me.tbArticulosVendidos.Controls.Add(Me.Label61)
        Me.tbArticulosVendidos.Controls.Add(Me.dtpArticulosVendidosDesde)
        Me.tbArticulosVendidos.Controls.Add(Me.Label62)
        Me.tbArticulosVendidos.Location = New System.Drawing.Point(4, 26)
        Me.tbArticulosVendidos.Name = "tbArticulosVendidos"
        Me.tbArticulosVendidos.Size = New System.Drawing.Size(982, 441)
        Me.tbArticulosVendidos.TabIndex = 10
        Me.tbArticulosVendidos.Text = "ARTÍCULOS VENDIDOS"
        Me.tbArticulosVendidos.UseVisualStyleBackColor = True
        '
        'ContadorVendidos
        '
        Me.ContadorVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorVendidos.Location = New System.Drawing.Point(122, 408)
        Me.ContadorVendidos.MaxLength = 15
        Me.ContadorVendidos.Name = "ContadorVendidos"
        Me.ContadorVendidos.ReadOnly = True
        Me.ContadorVendidos.Size = New System.Drawing.Size(60, 23)
        Me.ContadorVendidos.TabIndex = 214
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
        Me.Label98.Location = New System.Drawing.Point(12, 411)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(106, 17)
        Me.Label98.TabIndex = 216
        Me.Label98.Text = "ENCONTRADOS"
        '
        'lbCambioVendidos
        '
        Me.lbCambioVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioVendidos.AutoSize = True
        Me.lbCambioVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioVendidos.ForeColor = System.Drawing.Color.Red
        Me.lbCambioVendidos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioVendidos.Location = New System.Drawing.Point(338, 410)
        Me.lbCambioVendidos.Name = "lbCambioVendidos"
        Me.lbCambioVendidos.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioVendidos.TabIndex = 215
        Me.lbCambioVendidos.Text = "CAMBIO"
        Me.lbCambioVendidos.Visible = False
        '
        'CantidadVendidos
        '
        Me.CantidadVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CantidadVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.CantidadVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CantidadVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CantidadVendidos.Location = New System.Drawing.Point(651, 408)
        Me.CantidadVendidos.MaxLength = 15
        Me.CantidadVendidos.Name = "CantidadVendidos"
        Me.CantidadVendidos.ReadOnly = True
        Me.CantidadVendidos.Size = New System.Drawing.Size(90, 23)
        Me.CantidadVendidos.TabIndex = 211
        Me.CantidadVendidos.TabStop = False
        Me.CantidadVendidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalVendidos
        '
        Me.TotalVendidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalVendidos.BackColor = System.Drawing.SystemColors.Window
        Me.TotalVendidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVendidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalVendidos.Location = New System.Drawing.Point(836, 408)
        Me.TotalVendidos.MaxLength = 15
        Me.TotalVendidos.Name = "TotalVendidos"
        Me.TotalVendidos.ReadOnly = True
        Me.TotalVendidos.Size = New System.Drawing.Size(90, 23)
        Me.TotalVendidos.TabIndex = 211
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
        Me.Label92.Location = New System.Drawing.Point(564, 411)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(75, 17)
        Me.Label92.TabIndex = 213
        Me.Label92.Text = "CANTIDAD"
        '
        'Label85
        '
        Me.Label85.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label85.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label85.Location = New System.Drawing.Point(929, 410)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(15, 17)
        Me.Label85.TabIndex = 212
        Me.Label85.Text = "€"
        '
        'Label91
        '
        Me.Label91.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label91.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label91.Location = New System.Drawing.Point(781, 410)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(44, 17)
        Me.Label91.TabIndex = 213
        Me.Label91.Text = "TOTAL"
        '
        'lbSubTipo
        '
        Me.lbSubTipo.AutoSize = True
        Me.lbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbSubTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbSubTipo.Location = New System.Drawing.Point(682, 13)
        Me.lbSubTipo.Name = "lbSubTipo"
        Me.lbSubTipo.Size = New System.Drawing.Size(109, 17)
        Me.lbSubTipo.TabIndex = 184
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
        Me.lbTipo.TabIndex = 183
        Me.lbTipo.Text = "TIPO/FAMILIA"
        '
        'cbSubTipo
        '
        Me.cbSubTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubTipo.FormattingEnabled = True
        Me.cbSubTipo.Location = New System.Drawing.Point(804, 10)
        Me.cbSubTipo.Name = "cbSubTipo"
        Me.cbSubTipo.Size = New System.Drawing.Size(164, 25)
        Me.cbSubTipo.TabIndex = 182
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(509, 10)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(164, 25)
        Me.cbTipo.TabIndex = 181
        '
        'lvArticulosVendidos
        '
        Me.lvArticulosVendidos.AllowColumnReorder = True
        Me.lvArticulosVendidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvArticulosVendidos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidArticulo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCodAArticuloCli, Me.lvArticuloCli, Me.lvCantidad, Me.lvPrecio, Me.lvDocumento, Me.lvFecha})
        Me.lvArticulosVendidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvArticulosVendidos.FullRowSelect = True
        Me.lvArticulosVendidos.GridLines = True
        Me.lvArticulosVendidos.HideSelection = False
        Me.lvArticulosVendidos.Location = New System.Drawing.Point(9, 41)
        Me.lvArticulosVendidos.MultiSelect = False
        Me.lvArticulosVendidos.Name = "lvArticulosVendidos"
        Me.lvArticulosVendidos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lvArticulosVendidos.ShowItemToolTips = True
        Me.lvArticulosVendidos.Size = New System.Drawing.Size(959, 358)
        Me.lvArticulosVendidos.TabIndex = 2
        Me.lvArticulosVendidos.UseCompatibleStateImageBehavior = False
        Me.lvArticulosVendidos.View = System.Windows.Forms.View.Details
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
        Me.lvCodAArticuloCli.Text = "CÓDIGO CLI"
        Me.lvCodAArticuloCli.Width = 104
        '
        'lvArticuloCli
        '
        Me.lvArticuloCli.Text = "ARTICULO CLIENTE"
        Me.lvArticuloCli.Width = 210
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 76
        '
        'lvPrecio
        '
        Me.lvPrecio.Text = "ÚLT.PRECIO"
        Me.lvPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecio.Width = 80
        '
        'lvDocumento
        '
        Me.lvDocumento.Text = "ÚLT.FACTURA"
        Me.lvDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvDocumento.Width = 88
        '
        'lvFecha
        '
        Me.lvFecha.Text = "ÚLT.FECHA"
        Me.lvFecha.Width = 79
        '
        'dtpArticulosVendidosHasta
        '
        Me.dtpArticulosVendidosHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArticulosVendidosHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArticulosVendidosHasta.Location = New System.Drawing.Point(293, 10)
        Me.dtpArticulosVendidosHasta.Name = "dtpArticulosVendidosHasta"
        Me.dtpArticulosVendidosHasta.Size = New System.Drawing.Size(116, 23)
        Me.dtpArticulosVendidosHasta.TabIndex = 1
        Me.dtpArticulosVendidosHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label61.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label61.Location = New System.Drawing.Point(241, 13)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(46, 17)
        Me.Label61.TabIndex = 121
        Me.Label61.Text = "HASTA"
        '
        'dtpArticulosVendidosDesde
        '
        Me.dtpArticulosVendidosDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpArticulosVendidosDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpArticulosVendidosDesde.Location = New System.Drawing.Point(109, 10)
        Me.dtpArticulosVendidosDesde.Name = "dtpArticulosVendidosDesde"
        Me.dtpArticulosVendidosDesde.Size = New System.Drawing.Size(116, 23)
        Me.dtpArticulosVendidosDesde.TabIndex = 0
        Me.dtpArticulosVendidosDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label62.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label62.Location = New System.Drawing.Point(55, 13)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(48, 17)
        Me.Label62.TabIndex = 120
        Me.Label62.Text = "DESDE"
        '
        'tbOFertas
        '
        Me.tbOFertas.Controls.Add(Me.ContadorOfertas)
        Me.tbOFertas.Controls.Add(Me.Label76)
        Me.tbOFertas.Controls.Add(Me.lbCambioOferta)
        Me.tbOFertas.Controls.Add(Me.TotalOfertas)
        Me.tbOFertas.Controls.Add(Me.Label72)
        Me.tbOFertas.Controls.Add(Me.Label73)
        Me.tbOFertas.Controls.Add(Me.Label74)
        Me.tbOFertas.Controls.Add(Me.Label75)
        Me.tbOFertas.Controls.Add(Me.cbAnyoOferta)
        Me.tbOFertas.Controls.Add(Me.cbEstadoOferta)
        Me.tbOFertas.Controls.Add(Me.lvOfertas)
        Me.tbOFertas.Location = New System.Drawing.Point(4, 26)
        Me.tbOFertas.Name = "tbOFertas"
        Me.tbOFertas.Size = New System.Drawing.Size(982, 441)
        Me.tbOFertas.TabIndex = 12
        Me.tbOFertas.Text = "OFERTAS"
        Me.tbOFertas.UseVisualStyleBackColor = True
        '
        'ContadorOfertas
        '
        Me.ContadorOfertas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorOfertas.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorOfertas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorOfertas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorOfertas.Location = New System.Drawing.Point(122, 408)
        Me.ContadorOfertas.MaxLength = 15
        Me.ContadorOfertas.Name = "ContadorOfertas"
        Me.ContadorOfertas.ReadOnly = True
        Me.ContadorOfertas.Size = New System.Drawing.Size(60, 23)
        Me.ContadorOfertas.TabIndex = 3
        Me.ContadorOfertas.TabStop = False
        Me.ContadorOfertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label76
        '
        Me.Label76.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label76.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label76.Location = New System.Drawing.Point(12, 411)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(106, 17)
        Me.Label76.TabIndex = 213
        Me.Label76.Text = "ENCONTRADOS"
        '
        'lbCambioOferta
        '
        Me.lbCambioOferta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioOferta.AutoSize = True
        Me.lbCambioOferta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioOferta.ForeColor = System.Drawing.Color.Red
        Me.lbCambioOferta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioOferta.Location = New System.Drawing.Point(338, 410)
        Me.lbCambioOferta.Name = "lbCambioOferta"
        Me.lbCambioOferta.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioOferta.TabIndex = 211
        Me.lbCambioOferta.Text = "CAMBIO"
        Me.lbCambioOferta.Visible = False
        '
        'TotalOfertas
        '
        Me.TotalOfertas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalOfertas.BackColor = System.Drawing.SystemColors.Window
        Me.TotalOfertas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalOfertas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalOfertas.Location = New System.Drawing.Point(553, 407)
        Me.TotalOfertas.MaxLength = 15
        Me.TotalOfertas.Name = "TotalOfertas"
        Me.TotalOfertas.ReadOnly = True
        Me.TotalOfertas.Size = New System.Drawing.Size(100, 23)
        Me.TotalOfertas.TabIndex = 4
        Me.TotalOfertas.TabStop = False
        Me.TotalOfertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label72
        '
        Me.Label72.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label72.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label72.Location = New System.Drawing.Point(658, 410)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(15, 17)
        Me.Label72.TabIndex = 207
        Me.Label72.Text = "€"
        '
        'Label73
        '
        Me.Label73.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label73.Location = New System.Drawing.Point(488, 410)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(44, 17)
        Me.Label73.TabIndex = 210
        Me.Label73.Text = "TOTAL"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label74.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label74.Location = New System.Drawing.Point(51, 15)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(38, 17)
        Me.Label74.TabIndex = 204
        Me.Label74.Text = "AÑO"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label75.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label75.Location = New System.Drawing.Point(254, 14)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(56, 17)
        Me.Label75.TabIndex = 203
        Me.Label75.Text = "ESTADO"
        '
        'cbAnyoOferta
        '
        Me.cbAnyoOferta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnyoOferta.FormattingEnabled = True
        Me.cbAnyoOferta.Location = New System.Drawing.Point(135, 10)
        Me.cbAnyoOferta.MaxLength = 15
        Me.cbAnyoOferta.Name = "cbAnyoOferta"
        Me.cbAnyoOferta.Size = New System.Drawing.Size(67, 25)
        Me.cbAnyoOferta.TabIndex = 0
        '
        'cbEstadoOferta
        '
        Me.cbEstadoOferta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstadoOferta.FormattingEnabled = True
        Me.cbEstadoOferta.Location = New System.Drawing.Point(325, 10)
        Me.cbEstadoOferta.MaxLength = 15
        Me.cbEstadoOferta.Name = "cbEstadoOferta"
        Me.cbEstadoOferta.Size = New System.Drawing.Size(171, 25)
        Me.cbEstadoOferta.TabIndex = 1
        '
        'lvOfertas
        '
        Me.lvOfertas.AllowColumnReorder = True
        Me.lvOfertas.AllowDrop = True
        Me.lvOfertas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvOfertas.AutoArrange = False
        Me.lvOfertas.BackgroundImageTiled = True
        Me.lvOfertas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnumOferta, Me.lvRefClienteOF, Me.lvFechaOF, Me.lvEstadoOF, Me.lvTotalOF})
        Me.lvOfertas.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvOfertas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvOfertas.FullRowSelect = True
        Me.lvOfertas.GridLines = True
        Me.lvOfertas.HideSelection = False
        Me.lvOfertas.Location = New System.Drawing.Point(9, 41)
        Me.lvOfertas.Name = "lvOfertas"
        Me.lvOfertas.ShowItemToolTips = True
        Me.lvOfertas.Size = New System.Drawing.Size(963, 358)
        Me.lvOfertas.TabIndex = 2
        Me.lvOfertas.UseCompatibleStateImageBehavior = False
        Me.lvOfertas.View = System.Windows.Forms.View.Details
        '
        'lvnumOferta
        '
        Me.lvnumOferta.Text = "NÚM.OFERTA"
        Me.lvnumOferta.Width = 117
        '
        'lvRefClienteOF
        '
        Me.lvRefClienteOF.Text = "REF. CLIENTE"
        Me.lvRefClienteOF.Width = 167
        '
        'lvFechaOF
        '
        Me.lvFechaOF.Text = "FECHA"
        Me.lvFechaOF.Width = 95
        '
        'lvEstadoOF
        '
        Me.lvEstadoOF.Text = "ESTADO"
        Me.lvEstadoOF.Width = 180
        '
        'lvTotalOF
        '
        Me.lvTotalOF.Text = "TOTAL"
        Me.lvTotalOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotalOF.Width = 101
        '
        'tbProformas
        '
        Me.tbProformas.Controls.Add(Me.ContadorProformas)
        Me.tbProformas.Controls.Add(Me.Label70)
        Me.tbProformas.Controls.Add(Me.lbCambioProforma)
        Me.tbProformas.Controls.Add(Me.TotalProformas)
        Me.tbProformas.Controls.Add(Me.Label77)
        Me.tbProformas.Controls.Add(Me.Label78)
        Me.tbProformas.Controls.Add(Me.Label79)
        Me.tbProformas.Controls.Add(Me.Label80)
        Me.tbProformas.Controls.Add(Me.cbAnyoProforma)
        Me.tbProformas.Controls.Add(Me.cbEstadoProforma)
        Me.tbProformas.Controls.Add(Me.lvProformas)
        Me.tbProformas.Location = New System.Drawing.Point(4, 26)
        Me.tbProformas.Name = "tbProformas"
        Me.tbProformas.Size = New System.Drawing.Size(982, 441)
        Me.tbProformas.TabIndex = 13
        Me.tbProformas.Text = "PROFORMAS"
        Me.tbProformas.UseVisualStyleBackColor = True
        '
        'ContadorProformas
        '
        Me.ContadorProformas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorProformas.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorProformas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorProformas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorProformas.Location = New System.Drawing.Point(122, 408)
        Me.ContadorProformas.MaxLength = 15
        Me.ContadorProformas.Name = "ContadorProformas"
        Me.ContadorProformas.ReadOnly = True
        Me.ContadorProformas.Size = New System.Drawing.Size(60, 23)
        Me.ContadorProformas.TabIndex = 3
        Me.ContadorProformas.TabStop = False
        Me.ContadorProformas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label70
        '
        Me.Label70.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label70.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label70.Location = New System.Drawing.Point(12, 411)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(106, 17)
        Me.Label70.TabIndex = 224
        Me.Label70.Text = "ENCONTRADOS"
        '
        'lbCambioProforma
        '
        Me.lbCambioProforma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioProforma.AutoSize = True
        Me.lbCambioProforma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioProforma.ForeColor = System.Drawing.Color.Red
        Me.lbCambioProforma.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioProforma.Location = New System.Drawing.Point(338, 410)
        Me.lbCambioProforma.Name = "lbCambioProforma"
        Me.lbCambioProforma.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioProforma.TabIndex = 222
        Me.lbCambioProforma.Text = "CAMBIO"
        Me.lbCambioProforma.Visible = False
        '
        'TotalProformas
        '
        Me.TotalProformas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalProformas.BackColor = System.Drawing.SystemColors.Window
        Me.TotalProformas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalProformas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalProformas.Location = New System.Drawing.Point(553, 407)
        Me.TotalProformas.MaxLength = 15
        Me.TotalProformas.Name = "TotalProformas"
        Me.TotalProformas.ReadOnly = True
        Me.TotalProformas.Size = New System.Drawing.Size(100, 23)
        Me.TotalProformas.TabIndex = 4
        Me.TotalProformas.TabStop = False
        Me.TotalProformas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label77
        '
        Me.Label77.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label77.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label77.Location = New System.Drawing.Point(658, 410)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(15, 17)
        Me.Label77.TabIndex = 220
        Me.Label77.Text = "€"
        '
        'Label78
        '
        Me.Label78.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label78.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label78.Location = New System.Drawing.Point(488, 410)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(44, 17)
        Me.Label78.TabIndex = 221
        Me.Label78.Text = "TOTAL"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label79.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label79.Location = New System.Drawing.Point(51, 15)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(38, 17)
        Me.Label79.TabIndex = 218
        Me.Label79.Text = "AÑO"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label80.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label80.Location = New System.Drawing.Point(254, 14)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(56, 17)
        Me.Label80.TabIndex = 217
        Me.Label80.Text = "ESTADO"
        '
        'cbAnyoProforma
        '
        Me.cbAnyoProforma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnyoProforma.FormattingEnabled = True
        Me.cbAnyoProforma.Location = New System.Drawing.Point(135, 10)
        Me.cbAnyoProforma.MaxLength = 15
        Me.cbAnyoProforma.Name = "cbAnyoProforma"
        Me.cbAnyoProforma.Size = New System.Drawing.Size(67, 25)
        Me.cbAnyoProforma.TabIndex = 0
        '
        'cbEstadoProforma
        '
        Me.cbEstadoProforma.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstadoProforma.FormattingEnabled = True
        Me.cbEstadoProforma.Location = New System.Drawing.Point(325, 10)
        Me.cbEstadoProforma.MaxLength = 15
        Me.cbEstadoProforma.Name = "cbEstadoProforma"
        Me.cbEstadoProforma.Size = New System.Drawing.Size(171, 25)
        Me.cbEstadoProforma.TabIndex = 1
        '
        'lvProformas
        '
        Me.lvProformas.AllowColumnReorder = True
        Me.lvProformas.AllowDrop = True
        Me.lvProformas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvProformas.AutoArrange = False
        Me.lvProformas.BackgroundImageTiled = True
        Me.lvProformas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnumProforma, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvProformas.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvProformas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProformas.FullRowSelect = True
        Me.lvProformas.GridLines = True
        Me.lvProformas.HideSelection = False
        Me.lvProformas.Location = New System.Drawing.Point(9, 41)
        Me.lvProformas.Name = "lvProformas"
        Me.lvProformas.ShowItemToolTips = True
        Me.lvProformas.Size = New System.Drawing.Size(963, 358)
        Me.lvProformas.TabIndex = 2
        Me.lvProformas.UseCompatibleStateImageBehavior = False
        Me.lvProformas.View = System.Windows.Forms.View.Details
        '
        'lvnumProforma
        '
        Me.lvnumProforma.Text = "NÚM.PROFORMA"
        Me.lvnumProforma.Width = 117
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "REF. CLIENTE"
        Me.ColumnHeader7.Width = 167
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "FECHA"
        Me.ColumnHeader8.Width = 95
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "ESTADO"
        Me.ColumnHeader9.Width = 180
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "TOTAL"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader10.Width = 101
        '
        'tbPedidos
        '
        Me.tbPedidos.Controls.Add(Me.TotalServido)
        Me.tbPedidos.Controls.Add(Me.TotalPendiente)
        Me.tbPedidos.Controls.Add(Me.Label107)
        Me.tbPedidos.Controls.Add(Me.Label108)
        Me.tbPedidos.Controls.Add(Me.Label109)
        Me.tbPedidos.Controls.Add(Me.Label110)
        Me.tbPedidos.Controls.Add(Me.ContadorPedidos)
        Me.tbPedidos.Controls.Add(Me.Label69)
        Me.tbPedidos.Controls.Add(Me.lbCambioPedido)
        Me.tbPedidos.Controls.Add(Me.PortesPedido)
        Me.tbPedidos.Controls.Add(Me.TotalPedidos)
        Me.tbPedidos.Controls.Add(Me.Label64)
        Me.tbPedidos.Controls.Add(Me.Label65)
        Me.tbPedidos.Controls.Add(Me.Label66)
        Me.tbPedidos.Controls.Add(Me.Label67)
        Me.tbPedidos.Controls.Add(Me.Label68)
        Me.tbPedidos.Controls.Add(Me.Label63)
        Me.tbPedidos.Controls.Add(Me.cbAnyoPedido)
        Me.tbPedidos.Controls.Add(Me.cbEstadoPedido)
        Me.tbPedidos.Controls.Add(Me.lvPedidos)
        Me.tbPedidos.Location = New System.Drawing.Point(4, 26)
        Me.tbPedidos.Name = "tbPedidos"
        Me.tbPedidos.Size = New System.Drawing.Size(982, 441)
        Me.tbPedidos.TabIndex = 11
        Me.tbPedidos.Text = "PEDIDOS"
        Me.tbPedidos.UseVisualStyleBackColor = True
        '
        'TotalServido
        '
        Me.TotalServido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalServido.BackColor = System.Drawing.SystemColors.Window
        Me.TotalServido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalServido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalServido.Location = New System.Drawing.Point(858, 408)
        Me.TotalServido.MaxLength = 15
        Me.TotalServido.Name = "TotalServido"
        Me.TotalServido.ReadOnly = True
        Me.TotalServido.Size = New System.Drawing.Size(90, 23)
        Me.TotalServido.TabIndex = 203
        Me.TotalServido.TabStop = False
        Me.TotalServido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalPendiente
        '
        Me.TotalPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalPendiente.BackColor = System.Drawing.SystemColors.Window
        Me.TotalPendiente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPendiente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalPendiente.Location = New System.Drawing.Point(674, 408)
        Me.TotalPendiente.MaxLength = 15
        Me.TotalPendiente.Name = "TotalPendiente"
        Me.TotalPendiente.ReadOnly = True
        Me.TotalPendiente.Size = New System.Drawing.Size(90, 23)
        Me.TotalPendiente.TabIndex = 202
        Me.TotalPendiente.TabStop = False
        Me.TotalPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label107
        '
        Me.Label107.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label107.AutoSize = True
        Me.Label107.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label107.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label107.Location = New System.Drawing.Point(954, 411)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(15, 17)
        Me.Label107.TabIndex = 205
        Me.Label107.Text = "€"
        '
        'Label108
        '
        Me.Label108.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label108.AutoSize = True
        Me.Label108.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label108.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label108.Location = New System.Drawing.Point(765, 411)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(15, 17)
        Me.Label108.TabIndex = 204
        Me.Label108.Text = "€"
        '
        'Label109
        '
        Me.Label109.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label109.AutoSize = True
        Me.Label109.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label109.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label109.Location = New System.Drawing.Point(793, 411)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(62, 17)
        Me.Label109.TabIndex = 207
        Me.Label109.Text = "SERVIDO"
        '
        'Label110
        '
        Me.Label110.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label110.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label110.Location = New System.Drawing.Point(593, 411)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(75, 17)
        Me.Label110.TabIndex = 206
        Me.Label110.Text = "PENDIENTE"
        '
        'ContadorPedidos
        '
        Me.ContadorPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorPedidos.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorPedidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorPedidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorPedidos.Location = New System.Drawing.Point(121, 408)
        Me.ContadorPedidos.MaxLength = 15
        Me.ContadorPedidos.Name = "ContadorPedidos"
        Me.ContadorPedidos.ReadOnly = True
        Me.ContadorPedidos.Size = New System.Drawing.Size(60, 23)
        Me.ContadorPedidos.TabIndex = 3
        Me.ContadorPedidos.TabStop = False
        Me.ContadorPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label69
        '
        Me.Label69.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label69.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label69.Location = New System.Drawing.Point(12, 411)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(106, 17)
        Me.Label69.TabIndex = 201
        Me.Label69.Text = "ENCONTRADOS"
        '
        'lbCambioPedido
        '
        Me.lbCambioPedido.AutoSize = True
        Me.lbCambioPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioPedido.ForeColor = System.Drawing.Color.Red
        Me.lbCambioPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioPedido.Location = New System.Drawing.Point(770, 14)
        Me.lbCambioPedido.Name = "lbCambioPedido"
        Me.lbCambioPedido.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioPedido.TabIndex = 199
        Me.lbCambioPedido.Text = "CAMBIO"
        Me.lbCambioPedido.Visible = False
        '
        'PortesPedido
        '
        Me.PortesPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PortesPedido.BackColor = System.Drawing.SystemColors.Window
        Me.PortesPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PortesPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PortesPedido.Location = New System.Drawing.Point(488, 408)
        Me.PortesPedido.MaxLength = 15
        Me.PortesPedido.Name = "PortesPedido"
        Me.PortesPedido.ReadOnly = True
        Me.PortesPedido.Size = New System.Drawing.Size(68, 23)
        Me.PortesPedido.TabIndex = 5
        Me.PortesPedido.TabStop = False
        Me.PortesPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TotalPedidos
        '
        Me.TotalPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalPedidos.BackColor = System.Drawing.SystemColors.Window
        Me.TotalPedidos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPedidos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalPedidos.Location = New System.Drawing.Point(313, 408)
        Me.TotalPedidos.MaxLength = 15
        Me.TotalPedidos.Name = "TotalPedidos"
        Me.TotalPedidos.ReadOnly = True
        Me.TotalPedidos.Size = New System.Drawing.Size(90, 23)
        Me.TotalPedidos.TabIndex = 4
        Me.TotalPedidos.TabStop = False
        Me.TotalPedidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label64.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label64.Location = New System.Drawing.Point(560, 411)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(15, 17)
        Me.Label64.TabIndex = 196
        Me.Label64.Text = "€"
        '
        'Label65
        '
        Me.Label65.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label65.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label65.Location = New System.Drawing.Point(432, 411)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(53, 17)
        Me.Label65.TabIndex = 197
        Me.Label65.Text = "PORTES"
        '
        'Label66
        '
        Me.Label66.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label66.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label66.Location = New System.Drawing.Point(408, 411)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(15, 17)
        Me.Label66.TabIndex = 195
        Me.Label66.Text = "€"
        '
        'Label67
        '
        Me.Label67.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label67.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label67.Location = New System.Drawing.Point(193, 411)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(117, 17)
        Me.Label67.TabIndex = 198
        Me.Label67.Text = "TOTAL (Sin Portes)"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label68.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label68.Location = New System.Drawing.Point(51, 14)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(38, 17)
        Me.Label68.TabIndex = 106
        Me.Label68.Text = "AÑO"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label63.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label63.Location = New System.Drawing.Point(254, 14)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(56, 17)
        Me.Label63.TabIndex = 106
        Me.Label63.Text = "ESTADO"
        '
        'cbAnyoPedido
        '
        Me.cbAnyoPedido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbAnyoPedido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAnyoPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnyoPedido.FormattingEnabled = True
        Me.cbAnyoPedido.Location = New System.Drawing.Point(137, 10)
        Me.cbAnyoPedido.MaxLength = 15
        Me.cbAnyoPedido.Name = "cbAnyoPedido"
        Me.cbAnyoPedido.Size = New System.Drawing.Size(67, 25)
        Me.cbAnyoPedido.TabIndex = 0
        '
        'cbEstadoPedido
        '
        Me.cbEstadoPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstadoPedido.FormattingEnabled = True
        Me.cbEstadoPedido.Location = New System.Drawing.Point(325, 10)
        Me.cbEstadoPedido.MaxLength = 15
        Me.cbEstadoPedido.Name = "cbEstadoPedido"
        Me.cbEstadoPedido.Size = New System.Drawing.Size(171, 25)
        Me.cbEstadoPedido.TabIndex = 1
        '
        'lvPedidos
        '
        Me.lvPedidos.AllowColumnReorder = True
        Me.lvPedidos.AllowDrop = True
        Me.lvPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPedidos.AutoArrange = False
        Me.lvPedidos.BackgroundImageTiled = True
        Me.lvPedidos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnumPedido, Me.lvRefClientePE, Me.lvFechaPE, Me.lvEntregaPE, Me.lvEstadoPE, Me.lvTotalPE, Me.lvPortesPE, Me.lvPendioentePE, Me.lvServido})
        Me.lvPedidos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvPedidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPedidos.FullRowSelect = True
        Me.lvPedidos.GridLines = True
        Me.lvPedidos.HideSelection = False
        Me.lvPedidos.Location = New System.Drawing.Point(9, 41)
        Me.lvPedidos.Name = "lvPedidos"
        Me.lvPedidos.ShowItemToolTips = True
        Me.lvPedidos.Size = New System.Drawing.Size(963, 358)
        Me.lvPedidos.TabIndex = 2
        Me.lvPedidos.UseCompatibleStateImageBehavior = False
        Me.lvPedidos.View = System.Windows.Forms.View.Details
        '
        'lvnumPedido
        '
        Me.lvnumPedido.Text = "NÚM.PEDIDO"
        Me.lvnumPedido.Width = 97
        '
        'lvRefClientePE
        '
        Me.lvRefClientePE.Text = "PED. CLIENTE"
        Me.lvRefClientePE.Width = 167
        '
        'lvFechaPE
        '
        Me.lvFechaPE.Text = "FECHA"
        Me.lvFechaPE.Width = 80
        '
        'lvEntregaPE
        '
        Me.lvEntregaPE.Text = "ENTREGA"
        Me.lvEntregaPE.Width = 80
        '
        'lvEstadoPE
        '
        Me.lvEstadoPE.Text = "ESTADO"
        Me.lvEstadoPE.Width = 114
        '
        'lvTotalPE
        '
        Me.lvTotalPE.Text = "TOTAL"
        Me.lvTotalPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotalPE.Width = 101
        '
        'lvPortesPE
        '
        Me.lvPortesPE.Text = "PORTES"
        Me.lvPortesPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPortesPE.Width = 87
        '
        'lvPendioentePE
        '
        Me.lvPendioentePE.Text = "PENDIENTE"
        Me.lvPendioentePE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPendioentePE.Width = 101
        '
        'lvServido
        '
        Me.lvServido.Text = "SERVIDO"
        Me.lvServido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvServido.Width = 101
        '
        'tbAlbaranes
        '
        Me.tbAlbaranes.Controls.Add(Me.lvAlbaranes)
        Me.tbAlbaranes.Controls.Add(Me.ContadorAlbaranes)
        Me.tbAlbaranes.Controls.Add(Me.Label90)
        Me.tbAlbaranes.Controls.Add(Me.lbCambioAlbaran)
        Me.tbAlbaranes.Controls.Add(Me.TotalAlbaranes)
        Me.tbAlbaranes.Controls.Add(Me.Label86)
        Me.tbAlbaranes.Controls.Add(Me.Label87)
        Me.tbAlbaranes.Controls.Add(Me.Label88)
        Me.tbAlbaranes.Controls.Add(Me.Label89)
        Me.tbAlbaranes.Controls.Add(Me.cbAnyoAlbaran)
        Me.tbAlbaranes.Controls.Add(Me.cbEstadoAlbaran)
        Me.tbAlbaranes.Location = New System.Drawing.Point(4, 26)
        Me.tbAlbaranes.Name = "tbAlbaranes"
        Me.tbAlbaranes.Size = New System.Drawing.Size(982, 441)
        Me.tbAlbaranes.TabIndex = 14
        Me.tbAlbaranes.Text = "ALBARANES"
        Me.tbAlbaranes.UseVisualStyleBackColor = True
        '
        'lvAlbaranes
        '
        Me.lvAlbaranes.AllowColumnReorder = True
        Me.lvAlbaranes.AllowDrop = True
        Me.lvAlbaranes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvAlbaranes.AutoArrange = False
        Me.lvAlbaranes.BackgroundImageTiled = True
        Me.lvAlbaranes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvNumAlbaran, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19})
        Me.lvAlbaranes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvAlbaranes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAlbaranes.FullRowSelect = True
        Me.lvAlbaranes.GridLines = True
        Me.lvAlbaranes.HideSelection = False
        Me.lvAlbaranes.Location = New System.Drawing.Point(9, 41)
        Me.lvAlbaranes.Name = "lvAlbaranes"
        Me.lvAlbaranes.ShowItemToolTips = True
        Me.lvAlbaranes.Size = New System.Drawing.Size(963, 358)
        Me.lvAlbaranes.TabIndex = 2
        Me.lvAlbaranes.UseCompatibleStateImageBehavior = False
        Me.lvAlbaranes.View = System.Windows.Forms.View.Details
        '
        'lvNumAlbaran
        '
        Me.lvNumAlbaran.Text = "NÚM.ALBARÁN"
        Me.lvNumAlbaran.Width = 117
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "REF. CLIENTE"
        Me.ColumnHeader16.Width = 167
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "FECHA"
        Me.ColumnHeader17.Width = 95
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "ESTADO"
        Me.ColumnHeader18.Width = 180
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "TOTAL"
        Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader19.Width = 101
        '
        'ContadorAlbaranes
        '
        Me.ContadorAlbaranes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorAlbaranes.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorAlbaranes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorAlbaranes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorAlbaranes.Location = New System.Drawing.Point(122, 408)
        Me.ContadorAlbaranes.MaxLength = 15
        Me.ContadorAlbaranes.Name = "ContadorAlbaranes"
        Me.ContadorAlbaranes.ReadOnly = True
        Me.ContadorAlbaranes.Size = New System.Drawing.Size(60, 23)
        Me.ContadorAlbaranes.TabIndex = 3
        Me.ContadorAlbaranes.TabStop = False
        Me.ContadorAlbaranes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label90
        '
        Me.Label90.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label90.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label90.Location = New System.Drawing.Point(12, 411)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(106, 17)
        Me.Label90.TabIndex = 213
        Me.Label90.Text = "ENCONTRADOS"
        '
        'lbCambioAlbaran
        '
        Me.lbCambioAlbaran.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioAlbaran.AutoSize = True
        Me.lbCambioAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioAlbaran.ForeColor = System.Drawing.Color.Red
        Me.lbCambioAlbaran.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioAlbaran.Location = New System.Drawing.Point(338, 410)
        Me.lbCambioAlbaran.Name = "lbCambioAlbaran"
        Me.lbCambioAlbaran.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioAlbaran.TabIndex = 211
        Me.lbCambioAlbaran.Text = "CAMBIO"
        Me.lbCambioAlbaran.Visible = False
        '
        'TotalAlbaranes
        '
        Me.TotalAlbaranes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalAlbaranes.BackColor = System.Drawing.SystemColors.Window
        Me.TotalAlbaranes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalAlbaranes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalAlbaranes.Location = New System.Drawing.Point(553, 407)
        Me.TotalAlbaranes.MaxLength = 15
        Me.TotalAlbaranes.Name = "TotalAlbaranes"
        Me.TotalAlbaranes.ReadOnly = True
        Me.TotalAlbaranes.Size = New System.Drawing.Size(103, 23)
        Me.TotalAlbaranes.TabIndex = 4
        Me.TotalAlbaranes.TabStop = False
        Me.TotalAlbaranes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label86
        '
        Me.Label86.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label86.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label86.Location = New System.Drawing.Point(658, 410)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(15, 17)
        Me.Label86.TabIndex = 207
        Me.Label86.Text = "€"
        '
        'Label87
        '
        Me.Label87.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label87.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label87.Location = New System.Drawing.Point(488, 410)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(44, 17)
        Me.Label87.TabIndex = 210
        Me.Label87.Text = "TOTAL"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label88.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label88.Location = New System.Drawing.Point(51, 15)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(38, 17)
        Me.Label88.TabIndex = 204
        Me.Label88.Text = "AÑO"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label89.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label89.Location = New System.Drawing.Point(254, 14)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(56, 17)
        Me.Label89.TabIndex = 203
        Me.Label89.Text = "ESTADO"
        '
        'cbAnyoAlbaran
        '
        Me.cbAnyoAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnyoAlbaran.FormattingEnabled = True
        Me.cbAnyoAlbaran.Location = New System.Drawing.Point(137, 10)
        Me.cbAnyoAlbaran.MaxLength = 15
        Me.cbAnyoAlbaran.Name = "cbAnyoAlbaran"
        Me.cbAnyoAlbaran.Size = New System.Drawing.Size(67, 25)
        Me.cbAnyoAlbaran.TabIndex = 0
        '
        'cbEstadoAlbaran
        '
        Me.cbEstadoAlbaran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstadoAlbaran.FormattingEnabled = True
        Me.cbEstadoAlbaran.Location = New System.Drawing.Point(325, 10)
        Me.cbEstadoAlbaran.MaxLength = 15
        Me.cbEstadoAlbaran.Name = "cbEstadoAlbaran"
        Me.cbEstadoAlbaran.Size = New System.Drawing.Size(171, 25)
        Me.cbEstadoAlbaran.TabIndex = 1
        '
        'tbFacturas
        '
        Me.tbFacturas.Controls.Add(Me.Base)
        Me.tbFacturas.Controls.Add(Me.IVA)
        Me.tbFacturas.Controls.Add(Me.Label81)
        Me.tbFacturas.Controls.Add(Me.Label82)
        Me.tbFacturas.Controls.Add(Me.Label83)
        Me.tbFacturas.Controls.Add(Me.Label84)
        Me.tbFacturas.Controls.Add(Me.LvFacturas)
        Me.tbFacturas.Controls.Add(Me.ContadorFacturas)
        Me.tbFacturas.Controls.Add(Me.Label97)
        Me.tbFacturas.Controls.Add(Me.lbCambioFactura)
        Me.tbFacturas.Controls.Add(Me.TotalFacturas)
        Me.tbFacturas.Controls.Add(Me.Label93)
        Me.tbFacturas.Controls.Add(Me.Label94)
        Me.tbFacturas.Controls.Add(Me.Label95)
        Me.tbFacturas.Controls.Add(Me.Label96)
        Me.tbFacturas.Controls.Add(Me.cbAnyoFactura)
        Me.tbFacturas.Controls.Add(Me.cbEstadoFactura)
        Me.tbFacturas.Location = New System.Drawing.Point(4, 26)
        Me.tbFacturas.Name = "tbFacturas"
        Me.tbFacturas.Size = New System.Drawing.Size(982, 441)
        Me.tbFacturas.TabIndex = 15
        Me.tbFacturas.Text = "FACTURAS"
        Me.tbFacturas.UseVisualStyleBackColor = True
        '
        'Base
        '
        Me.Base.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Base.BackColor = System.Drawing.SystemColors.Window
        Me.Base.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Base.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Base.Location = New System.Drawing.Point(237, 408)
        Me.Base.MaxLength = 15
        Me.Base.Name = "Base"
        Me.Base.ReadOnly = True
        Me.Base.Size = New System.Drawing.Size(90, 23)
        Me.Base.TabIndex = 215
        Me.Base.TabStop = False
        Me.Base.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IVA
        '
        Me.IVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IVA.BackColor = System.Drawing.SystemColors.Window
        Me.IVA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IVA.Location = New System.Drawing.Point(395, 408)
        Me.IVA.MaxLength = 15
        Me.IVA.Name = "IVA"
        Me.IVA.ReadOnly = True
        Me.IVA.Size = New System.Drawing.Size(90, 23)
        Me.IVA.TabIndex = 214
        Me.IVA.TabStop = False
        Me.IVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label81
        '
        Me.Label81.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label81.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label81.Location = New System.Drawing.Point(328, 411)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(15, 17)
        Me.Label81.TabIndex = 217
        Me.Label81.Text = "€"
        '
        'Label82
        '
        Me.Label82.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label82.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label82.Location = New System.Drawing.Point(486, 411)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(15, 17)
        Me.Label82.TabIndex = 216
        Me.Label82.Text = "€"
        '
        'Label83
        '
        Me.Label83.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label83.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label83.Location = New System.Drawing.Point(195, 411)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(37, 17)
        Me.Label83.TabIndex = 219
        Me.Label83.Text = "BASE"
        '
        'Label84
        '
        Me.Label84.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label84.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label84.Location = New System.Drawing.Point(362, 411)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(29, 17)
        Me.Label84.TabIndex = 218
        Me.Label84.Text = "IVA"
        '
        'LvFacturas
        '
        Me.LvFacturas.AllowColumnReorder = True
        Me.LvFacturas.AllowDrop = True
        Me.LvFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvFacturas.AutoArrange = False
        Me.LvFacturas.BackgroundImageTiled = True
        Me.LvFacturas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnumFactura, Me.RefCliente, Me.lvFechaFactura, Me.lvEstadoF, Me.lvTotalF, Me.lvIVA, Me.lvBase})
        Me.LvFacturas.Cursor = System.Windows.Forms.Cursors.Default
        Me.LvFacturas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvFacturas.FullRowSelect = True
        Me.LvFacturas.GridLines = True
        Me.LvFacturas.HideSelection = False
        Me.LvFacturas.Location = New System.Drawing.Point(9, 41)
        Me.LvFacturas.Name = "LvFacturas"
        Me.LvFacturas.ShowItemToolTips = True
        Me.LvFacturas.Size = New System.Drawing.Size(963, 358)
        Me.LvFacturas.TabIndex = 2
        Me.LvFacturas.UseCompatibleStateImageBehavior = False
        Me.LvFacturas.View = System.Windows.Forms.View.Details
        '
        'lvnumFactura
        '
        Me.lvnumFactura.Text = "NÚM.FACTURA"
        Me.lvnumFactura.Width = 117
        '
        'RefCliente
        '
        Me.RefCliente.DisplayIndex = 2
        Me.RefCliente.Text = "REF. CLIENTE"
        Me.RefCliente.Width = 127
        '
        'lvFechaFactura
        '
        Me.lvFechaFactura.DisplayIndex = 1
        Me.lvFechaFactura.Text = "FECHA"
        Me.lvFechaFactura.Width = 95
        '
        'lvEstadoF
        '
        Me.lvEstadoF.DisplayIndex = 6
        Me.lvEstadoF.Text = "ESTADO"
        Me.lvEstadoF.Width = 180
        '
        'lvTotalF
        '
        Me.lvTotalF.DisplayIndex = 5
        Me.lvTotalF.Text = "TOTAL"
        Me.lvTotalF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotalF.Width = 101
        '
        'lvIVA
        '
        Me.lvIVA.DisplayIndex = 4
        Me.lvIVA.Text = "IVA"
        Me.lvIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvIVA.Width = 104
        '
        'lvBase
        '
        Me.lvBase.DisplayIndex = 3
        Me.lvBase.Text = "BASE"
        Me.lvBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvBase.Width = 108
        '
        'ContadorFacturas
        '
        Me.ContadorFacturas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ContadorFacturas.BackColor = System.Drawing.SystemColors.Window
        Me.ContadorFacturas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContadorFacturas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ContadorFacturas.Location = New System.Drawing.Point(122, 408)
        Me.ContadorFacturas.MaxLength = 15
        Me.ContadorFacturas.Name = "ContadorFacturas"
        Me.ContadorFacturas.ReadOnly = True
        Me.ContadorFacturas.Size = New System.Drawing.Size(60, 23)
        Me.ContadorFacturas.TabIndex = 3
        Me.ContadorFacturas.TabStop = False
        Me.ContadorFacturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label97
        '
        Me.Label97.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label97.AutoSize = True
        Me.Label97.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label97.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label97.Location = New System.Drawing.Point(12, 411)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(106, 17)
        Me.Label97.TabIndex = 213
        Me.Label97.Text = "ENCONTRADOS"
        '
        'lbCambioFactura
        '
        Me.lbCambioFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambioFactura.AutoSize = True
        Me.lbCambioFactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambioFactura.ForeColor = System.Drawing.Color.Red
        Me.lbCambioFactura.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambioFactura.Location = New System.Drawing.Point(536, 13)
        Me.lbCambioFactura.Name = "lbCambioFactura"
        Me.lbCambioFactura.Size = New System.Drawing.Size(60, 17)
        Me.lbCambioFactura.TabIndex = 211
        Me.lbCambioFactura.Text = "CAMBIO"
        Me.lbCambioFactura.Visible = False
        '
        'TotalFacturas
        '
        Me.TotalFacturas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalFacturas.BackColor = System.Drawing.SystemColors.Window
        Me.TotalFacturas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalFacturas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalFacturas.Location = New System.Drawing.Point(562, 407)
        Me.TotalFacturas.MaxLength = 15
        Me.TotalFacturas.Name = "TotalFacturas"
        Me.TotalFacturas.ReadOnly = True
        Me.TotalFacturas.Size = New System.Drawing.Size(101, 23)
        Me.TotalFacturas.TabIndex = 4
        Me.TotalFacturas.TabStop = False
        Me.TotalFacturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label93
        '
        Me.Label93.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label93.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label93.Location = New System.Drawing.Point(667, 410)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(15, 17)
        Me.Label93.TabIndex = 207
        Me.Label93.Text = "€"
        '
        'Label94
        '
        Me.Label94.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label94.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label94.Location = New System.Drawing.Point(516, 410)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(44, 17)
        Me.Label94.TabIndex = 210
        Me.Label94.Text = "TOTAL"
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label95.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label95.Location = New System.Drawing.Point(51, 15)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(38, 17)
        Me.Label95.TabIndex = 204
        Me.Label95.Text = "AÑO"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label96.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label96.Location = New System.Drawing.Point(254, 14)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(56, 17)
        Me.Label96.TabIndex = 203
        Me.Label96.Text = "ESTADO"
        '
        'cbAnyoFactura
        '
        Me.cbAnyoFactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnyoFactura.FormattingEnabled = True
        Me.cbAnyoFactura.Location = New System.Drawing.Point(137, 10)
        Me.cbAnyoFactura.MaxLength = 15
        Me.cbAnyoFactura.Name = "cbAnyoFactura"
        Me.cbAnyoFactura.Size = New System.Drawing.Size(67, 25)
        Me.cbAnyoFactura.TabIndex = 0
        '
        'cbEstadoFactura
        '
        Me.cbEstadoFactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstadoFactura.FormattingEnabled = True
        Me.cbEstadoFactura.Location = New System.Drawing.Point(325, 10)
        Me.cbEstadoFactura.MaxLength = 15
        Me.cbEstadoFactura.Name = "cbEstadoFactura"
        Me.cbEstadoFactura.Size = New System.Drawing.Size(171, 25)
        Me.cbEstadoFactura.TabIndex = 1
        '
        'tbComisiones
        '
        Me.tbComisiones.Controls.Add(Me.ObservacionesC)
        Me.tbComisiones.Controls.Add(Me.Label103)
        Me.tbComisiones.Controls.Add(Me.ckLiquidados)
        Me.tbComisiones.Controls.Add(Me.TotalBase)
        Me.tbComisiones.Controls.Add(Me.Label106)
        Me.tbComisiones.Controls.Add(Me.TotalComisiones)
        Me.tbComisiones.Controls.Add(Me.Label104)
        Me.tbComisiones.Controls.Add(Me.Label101)
        Me.tbComisiones.Controls.Add(Me.Label102)
        Me.tbComisiones.Controls.Add(Me.dtpComisionesHasta)
        Me.tbComisiones.Controls.Add(Me.Label99)
        Me.tbComisiones.Controls.Add(Me.dtpComisionesDesde)
        Me.tbComisiones.Controls.Add(Me.Label100)
        Me.tbComisiones.Controls.Add(Me.Comision)
        Me.tbComisiones.Controls.Add(Me.Label1)
        Me.tbComisiones.Controls.Add(Me.Label105)
        Me.tbComisiones.Controls.Add(Me.Label15)
        Me.tbComisiones.Controls.Add(Me.lvCambiosComisiones)
        Me.tbComisiones.Controls.Add(Me.lvComisiones)
        Me.tbComisiones.Location = New System.Drawing.Point(4, 26)
        Me.tbComisiones.Name = "tbComisiones"
        Me.tbComisiones.Size = New System.Drawing.Size(982, 441)
        Me.tbComisiones.TabIndex = 16
        Me.tbComisiones.Text = "COMERCIAL"
        Me.tbComisiones.UseVisualStyleBackColor = True
        '
        'ObservacionesC
        '
        Me.ObservacionesC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesC.Location = New System.Drawing.Point(135, 50)
        Me.ObservacionesC.MaxLength = 300
        Me.ObservacionesC.Name = "ObservacionesC"
        Me.ObservacionesC.Size = New System.Drawing.Size(478, 23)
        Me.ObservacionesC.TabIndex = 1
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label103.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label103.Location = New System.Drawing.Point(17, 53)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(113, 17)
        Me.Label103.TabIndex = 218
        Me.Label103.Text = "OBSERVACIONES"
        '
        'ckLiquidados
        '
        Me.ckLiquidados.AutoSize = True
        Me.ckLiquidados.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLiquidados.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckLiquidados.Location = New System.Drawing.Point(481, 92)
        Me.ckLiquidados.Name = "ckLiquidados"
        Me.ckLiquidados.Size = New System.Drawing.Size(132, 21)
        Me.ckLiquidados.TabIndex = 4
        Me.ckLiquidados.Text = "VER LIQUIDADOS"
        Me.ckLiquidados.UseVisualStyleBackColor = True
        '
        'TotalBase
        '
        Me.TotalBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalBase.BackColor = System.Drawing.SystemColors.Window
        Me.TotalBase.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalBase.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalBase.Location = New System.Drawing.Point(233, 408)
        Me.TotalBase.MaxLength = 15
        Me.TotalBase.Name = "TotalBase"
        Me.TotalBase.ReadOnly = True
        Me.TotalBase.Size = New System.Drawing.Size(92, 23)
        Me.TotalBase.TabIndex = 7
        Me.TotalBase.TabStop = False
        Me.TotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label106
        '
        Me.Label106.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label106.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label106.Location = New System.Drawing.Point(329, 411)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(15, 17)
        Me.Label106.TabIndex = 215
        Me.Label106.Text = "€"
        '
        'TotalComisiones
        '
        Me.TotalComisiones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalComisiones.BackColor = System.Drawing.SystemColors.Window
        Me.TotalComisiones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalComisiones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalComisiones.Location = New System.Drawing.Point(838, 408)
        Me.TotalComisiones.MaxLength = 15
        Me.TotalComisiones.Name = "TotalComisiones"
        Me.TotalComisiones.ReadOnly = True
        Me.TotalComisiones.Size = New System.Drawing.Size(92, 23)
        Me.TotalComisiones.TabIndex = 8
        Me.TotalComisiones.TabStop = False
        Me.TotalComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label104
        '
        Me.Label104.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label104.AutoSize = True
        Me.Label104.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label104.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label104.Location = New System.Drawing.Point(151, 411)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(77, 17)
        Me.Label104.TabIndex = 216
        Me.Label104.Text = "TOTAL BASE"
        '
        'Label101
        '
        Me.Label101.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label101.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label101.Location = New System.Drawing.Point(934, 411)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(15, 17)
        Me.Label101.TabIndex = 215
        Me.Label101.Text = "€"
        '
        'Label102
        '
        Me.Label102.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label102.AutoSize = True
        Me.Label102.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label102.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label102.Location = New System.Drawing.Point(707, 411)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(127, 17)
        Me.Label102.TabIndex = 216
        Me.Label102.Text = "TOTAL COMISIONES"
        '
        'dtpComisionesHasta
        '
        Me.dtpComisionesHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpComisionesHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpComisionesHasta.Location = New System.Drawing.Point(335, 91)
        Me.dtpComisionesHasta.Name = "dtpComisionesHasta"
        Me.dtpComisionesHasta.Size = New System.Drawing.Size(116, 23)
        Me.dtpComisionesHasta.TabIndex = 3
        Me.dtpComisionesHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label99.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label99.Location = New System.Drawing.Point(275, 94)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(46, 17)
        Me.Label99.TabIndex = 178
        Me.Label99.Text = "HASTA"
        '
        'dtpComisionesDesde
        '
        Me.dtpComisionesDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpComisionesDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpComisionesDesde.Location = New System.Drawing.Point(135, 91)
        Me.dtpComisionesDesde.Name = "dtpComisionesDesde"
        Me.dtpComisionesDesde.Size = New System.Drawing.Size(116, 23)
        Me.dtpComisionesDesde.TabIndex = 2
        Me.dtpComisionesDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label100.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label100.Location = New System.Drawing.Point(68, 94)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(48, 17)
        Me.Label100.TabIndex = 177
        Me.Label100.Text = "DESDE"
        '
        'Comision
        '
        Me.Comision.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comision.Location = New System.Drawing.Point(135, 21)
        Me.Comision.MaxLength = 100
        Me.Comision.Name = "Comision"
        Me.Comision.Size = New System.Drawing.Size(49, 23)
        Me.Comision.TabIndex = 0
        Me.Comision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(188, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 17)
        Me.Label1.TabIndex = 174
        Me.Label1.Text = "%"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label105.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label105.Location = New System.Drawing.Point(620, 7)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(220, 17)
        Me.Label105.TabIndex = 173
        Me.Label105.Text = "HISTÓRICO CAMBIOS COMISIONES"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(17, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 17)
        Me.Label15.TabIndex = 173
        Me.Label15.Text = "COMISIÓN"
        '
        'lvCambiosComisiones
        '
        Me.lvCambiosComisiones.AllowColumnReorder = True
        Me.lvCambiosComisiones.AllowDrop = True
        Me.lvCambiosComisiones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCambiosComisiones.AutoArrange = False
        Me.lvCambiosComisiones.BackgroundImageTiled = True
        Me.lvCambiosComisiones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidHistoricoCambio, Me.lvComercalCC, Me.lvFechaCC, Me.lvComisionAnt, Me.lvNuevaCom})
        Me.lvCambiosComisiones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvCambiosComisiones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCambiosComisiones.FullRowSelect = True
        Me.lvCambiosComisiones.GridLines = True
        Me.lvCambiosComisiones.HideSelection = False
        Me.lvCambiosComisiones.Location = New System.Drawing.Point(619, 28)
        Me.lvCambiosComisiones.Name = "lvCambiosComisiones"
        Me.lvCambiosComisiones.ShowItemToolTips = True
        Me.lvCambiosComisiones.Size = New System.Drawing.Size(354, 90)
        Me.lvCambiosComisiones.TabIndex = 5
        Me.lvCambiosComisiones.UseCompatibleStateImageBehavior = False
        Me.lvCambiosComisiones.View = System.Windows.Forms.View.Details
        '
        'lvidHistoricoCambio
        '
        Me.lvidHistoricoCambio.DisplayIndex = 1
        Me.lvidHistoricoCambio.Text = "idHistoricoCambio"
        Me.lvidHistoricoCambio.Width = 0
        '
        'lvComercalCC
        '
        Me.lvComercalCC.DisplayIndex = 0
        Me.lvComercalCC.Text = "COMERCIAL"
        Me.lvComercalCC.Width = 113
        '
        'lvFechaCC
        '
        Me.lvFechaCC.Text = "FECHA"
        Me.lvFechaCC.Width = 79
        '
        'lvComisionAnt
        '
        Me.lvComisionAnt.Text = "ANTERIOR"
        Me.lvComisionAnt.Width = 73
        '
        'lvNuevaCom
        '
        Me.lvNuevaCom.Text = "NUEVA"
        Me.lvNuevaCom.Width = 64
        '
        'lvComisiones
        '
        Me.lvComisiones.AllowColumnReorder = True
        Me.lvComisiones.AllowDrop = True
        Me.lvComisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvComisiones.AutoArrange = False
        Me.lvComisiones.BackgroundImageTiled = True
        Me.lvComisiones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvFacturaC, Me.lvFechaFacturaC, Me.lvImporteFactura, Me.lvComercial, Me.lvPorcentajeC, Me.lvImporteComision, Me.lvFechaLiquidacion, Me.lvidLiquidacion})
        Me.lvComisiones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvComisiones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvComisiones.FullRowSelect = True
        Me.lvComisiones.GridLines = True
        Me.lvComisiones.HideSelection = False
        Me.lvComisiones.Location = New System.Drawing.Point(10, 123)
        Me.lvComisiones.Name = "lvComisiones"
        Me.lvComisiones.ShowItemToolTips = True
        Me.lvComisiones.Size = New System.Drawing.Size(963, 280)
        Me.lvComisiones.TabIndex = 6
        Me.lvComisiones.UseCompatibleStateImageBehavior = False
        Me.lvComisiones.View = System.Windows.Forms.View.Details
        '
        'lvFacturaC
        '
        Me.lvFacturaC.Text = "NUM. FACTURA"
        Me.lvFacturaC.Width = 114
        '
        'lvFechaFacturaC
        '
        Me.lvFechaFacturaC.Text = "FECHA"
        Me.lvFechaFacturaC.Width = 107
        '
        'lvImporteFactura
        '
        Me.lvImporteFactura.Text = "BASE"
        Me.lvImporteFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImporteFactura.Width = 98
        '
        'lvComercial
        '
        Me.lvComercial.Text = "COMERCIAL"
        Me.lvComercial.Width = 176
        '
        'lvPorcentajeC
        '
        Me.lvPorcentajeC.Text = "COMISIONES"
        Me.lvPorcentajeC.Width = 125
        '
        'lvImporteComision
        '
        Me.lvImporteComision.DisplayIndex = 7
        Me.lvImporteComision.Text = "IMPORTE"
        Me.lvImporteComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImporteComision.Width = 108
        '
        'lvFechaLiquidacion
        '
        Me.lvFechaLiquidacion.DisplayIndex = 5
        Me.lvFechaLiquidacion.Text = "FECHA LIQUIDACIÓN"
        Me.lvFechaLiquidacion.Width = 136
        '
        'lvidLiquidacion
        '
        Me.lvidLiquidacion.DisplayIndex = 6
        Me.lvidLiquidacion.Text = "ID"
        Me.lvidLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bNuevo
        '
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(583, 24)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 5
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(793, 24)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 7
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(478, 24)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 4
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "NUM.OFERTA"
        Me.ColumnHeader1.Width = 99
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "REF. CLIENTE"
        Me.ColumnHeader2.Width = 167
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "FECHA"
        Me.ColumnHeader3.Width = 95
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ESTADO"
        Me.ColumnHeader4.Width = 180
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "TOTAL"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 101
        '
        'GestionClientes
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 762)
        Me.Controls.Add(Me.gbClientes)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE CLIENTES"
        Me.gbClientes.ResumeLayout(False)
        Me.gbClientes.PerformLayout()
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
        Me.tbArticulosVendidos.ResumeLayout(False)
        Me.tbArticulosVendidos.PerformLayout()
        Me.tbOFertas.ResumeLayout(False)
        Me.tbOFertas.PerformLayout()
        Me.tbProformas.ResumeLayout(False)
        Me.tbProformas.PerformLayout()
        Me.tbPedidos.ResumeLayout(False)
        Me.tbPedidos.PerformLayout()
        Me.tbAlbaranes.ResumeLayout(False)
        Me.tbAlbaranes.PerformLayout()
        Me.tbFacturas.ResumeLayout(False)
        Me.tbFacturas.PerformLayout()
        Me.tbComisiones.ResumeLayout(False)
        Me.tbComisiones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbClientes As System.Windows.Forms.GroupBox
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
    Friend WithEvents codCli As System.Windows.Forms.TextBox
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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbResponsable As System.Windows.Forms.ComboBox
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents ckRecargoEquivalencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbRetencion As System.Windows.Forms.ComboBox
    Friend WithEvents subCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TelefonoU2 As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cbTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents ckNoMostrarCliente As System.Windows.Forms.CheckBox
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
    Friend WithEvents Descuento2 As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents bTiposPago As System.Windows.Forms.Button
    Friend WithEvents bMediosPago As System.Windows.Forms.Button
    Friend WithEvents bTiposRetencion As System.Windows.Forms.Button
    Friend WithEvents bTiposIVA As System.Windows.Forms.Button
    Friend WithEvents cbValorado As System.Windows.Forms.ComboBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents bBancos As System.Windows.Forms.Button
    Friend WithEvents cbPortes As System.Windows.Forms.ComboBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents bVerPais As System.Windows.Forms.Button
    Friend WithEvents tbArticulosVendidos As System.Windows.Forms.TabPage
    Friend WithEvents tbPedidos As System.Windows.Forms.TabPage
    Friend WithEvents dtpArticulosVendidosHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents dtpArticulosVendidosDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents lvArticulosVendidos As System.Windows.Forms.ListView
    Friend WithEvents lvIdProdCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodAArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloCli As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbOFertas As System.Windows.Forms.TabPage
    Friend WithEvents tbProformas As System.Windows.Forms.TabPage
    Friend WithEvents tbAlbaranes As System.Windows.Forms.TabPage
    Friend WithEvents tbFacturas As System.Windows.Forms.TabPage
    Friend WithEvents lvPedidos As System.Windows.Forms.ListView
    Friend WithEvents lvnumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEntregaPE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoPE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotalPE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPortesPE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRefClientePE As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents cbEstadoPedido As System.Windows.Forms.ComboBox
    Friend WithEvents lbCambioPedido As System.Windows.Forms.Label
    Friend WithEvents PortesPedido As System.Windows.Forms.TextBox
    Friend WithEvents TotalPedidos As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents cbAnyoPedido As System.Windows.Forms.ComboBox
    Friend WithEvents lbCambioOferta As System.Windows.Forms.Label
    Friend WithEvents TotalOfertas As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents cbAnyoOferta As System.Windows.Forms.ComboBox
    Friend WithEvents cbEstadoOferta As System.Windows.Forms.ComboBox
    Friend WithEvents lvOfertas As System.Windows.Forms.ListView
    Friend WithEvents lvnumOferta As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaOF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoOF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotalOF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRefClienteOF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbCambioAlbaran As System.Windows.Forms.Label
    Friend WithEvents TotalAlbaranes As System.Windows.Forms.TextBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents cbAnyoAlbaran As System.Windows.Forms.ComboBox
    Friend WithEvents cbEstadoAlbaran As System.Windows.Forms.ComboBox
    Friend WithEvents lbCambioFactura As System.Windows.Forms.Label
    Friend WithEvents TotalFacturas As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents cbAnyoFactura As System.Windows.Forms.ComboBox
    Friend WithEvents cbEstadoFactura As System.Windows.Forms.ComboBox
    Friend WithEvents ContadorOfertas As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents ContadorPedidos As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents ContadorAlbaranes As System.Windows.Forms.TextBox
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents ContadorFacturas As System.Windows.Forms.TextBox
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContadorProformas As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents lbCambioProforma As System.Windows.Forms.Label
    Friend WithEvents TotalProformas As System.Windows.Forms.TextBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents cbAnyoProforma As System.Windows.Forms.ComboBox
    Friend WithEvents cbEstadoProforma As System.Windows.Forms.ComboBox
    Friend WithEvents lvProformas As System.Windows.Forms.ListView
    Friend WithEvents lvnumProforma As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LvFacturas As System.Windows.Forms.ListView
    Friend WithEvents lvnumFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents RefCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotalF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAlbaranes As System.Windows.Forms.ListView
    Friend WithEvents lvNumAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents ObservacionesProd As System.Windows.Forms.TextBox
    Friend WithEvents Base As System.Windows.Forms.TextBox
    Friend WithEvents IVA As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents lvIVA As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvBase As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbSubTipo As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbSubTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ContadorVendidos As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents lbCambioVendidos As System.Windows.Forms.Label
    Friend WithEvents CantidadVendidos As System.Windows.Forms.TextBox
    Friend WithEvents TotalVendidos As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbComisiones As System.Windows.Forms.TabPage
    Friend WithEvents lvComisiones As System.Windows.Forms.ListView
    Friend WithEvents Comision As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvCambiosComisiones As System.Windows.Forms.ListView
    Friend WithEvents lvFechaCC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvComisionAnt As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNuevaCom As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvComercial As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPorcentajeC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporteComision As System.Windows.Forms.ColumnHeader
    Friend WithEvents TotalComisiones As System.Windows.Forms.TextBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents dtpComisionesHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents dtpComisionesDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents lvFacturaC As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents lvidHistoricoCambio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvComercalCC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaLiquidacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckLiquidados As System.Windows.Forms.CheckBox
    Friend WithEvents lvFechaFacturaC As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporteFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents ObservacionesC As System.Windows.Forms.TextBox
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents TotalBase As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents lvidLiquidacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPendioentePE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvServido As System.Windows.Forms.ColumnHeader
    Friend WithEvents TotalServido As System.Windows.Forms.TextBox
    Friend WithEvents TotalPendiente As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
End Class
