<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionFacturaProv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionFacturaProv))
        Me.gbConceptos = New System.Windows.Forms.GroupBox
        Me.ObservacionesC = New System.Windows.Forms.TextBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bArticuloProveedor = New System.Windows.Forms.Button
        Me.bVerArticulo = New System.Windows.Forms.Button
        Me.bFamilias = New System.Windows.Forms.Button
        Me.BBuscarArticulo = New System.Windows.Forms.Button
        Me.Label39 = New System.Windows.Forms.Label
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvCk = New System.Windows.Forms.ColumnHeader
        Me.lvidconcepto = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloProv = New System.Windows.Forms.ColumnHeader
        Me.lvdescripcion = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvPrecio = New System.Windows.Forms.ColumnHeader
        Me.lvDescuento = New System.Windows.Forms.ColumnHeader
        Me.lvtotal = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.idEstado = New System.Windows.Forms.ColumnHeader
        Me.lvTipoIVA = New System.Windows.Forms.ColumnHeader
        Me.lvAlbaran = New System.Windows.Forms.ColumnHeader
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cbSubFamilia = New System.Windows.Forms.ComboBox
        Me.lbMoneda3 = New System.Windows.Forms.Label
        Me.cbFamilia = New System.Windows.Forms.ComboBox
        Me.lbMoneda2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbcodArticuloProv = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.cbcodArticulo = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbTipoIVA = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.DescuentoC = New System.Windows.Forms.TextBox
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Precio = New System.Windows.Forms.TextBox
        Me.subTotal = New System.Windows.Forms.TextBox
        Me.bBorrar = New System.Windows.Forms.Button
        Me.Total = New System.Windows.Forms.TextBox
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bEmail = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.codFactura = New System.Windows.Forms.TextBox
        Me.lbNumDoc1 = New System.Windows.Forms.Label
        Me.lbNumDoc2 = New System.Windows.Forms.Label
        Me.numDoc1 = New System.Windows.Forms.TextBox
        Me.Referencia = New System.Windows.Forms.TextBox
        Me.numFactura = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbSolicitadoPor = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.tipoIVA = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cbProveedor = New System.Windows.Forms.ComboBox
        Me.cbsolicitadoVia = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.gbCabecera = New System.Windows.Forms.GroupBox
        Me.lvVencimientos = New System.Windows.Forms.ListView
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvImprte = New System.Windows.Forms.ColumnHeader
        Me.Label25 = New System.Windows.Forms.Label
        Me.bVerIVAs = New System.Windows.Forms.Button
        Me.bVencimientos = New System.Windows.Forms.Button
        Me.lbmonedaT = New System.Windows.Forms.Label
        Me.PrecioTransporte = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.cbDireccion = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.bMoneda = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.cbMoneda = New System.Windows.Forms.ComboBox
        Me.cbCodProveedor = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Nota = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbContacto = New System.Windows.Forms.ComboBox
        Me.bVerProveedor = New System.Windows.Forms.Button
        Me.bTiposPago = New System.Windows.Forms.Button
        Me.bBuscarProveedor = New System.Windows.Forms.Button
        Me.bMediosPago = New System.Windows.Forms.Button
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbRetencion = New System.Windows.Forms.ComboBox
        Me.ckRecargoEquivalencia = New System.Windows.Forms.CheckBox
        Me.cbCuenta = New System.Windows.Forms.ComboBox
        Me.cbTipoPago = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbMedioPago = New System.Windows.Forms.ComboBox
        Me.Descuento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.BNuevo = New System.Windows.Forms.Button
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.bPDF = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.lbMoneda7 = New System.Windows.Forms.Label
        Me.TotalRE = New System.Windows.Forms.TextBox
        Me.lbMoneda6 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Retencion = New System.Windows.Forms.TextBox
        Me.lbMoneda5 = New System.Windows.Forms.Label
        Me.lbMoneda4 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.TotalIVA = New System.Windows.Forms.TextBox
        Me.BaseImponible = New System.Windows.Forms.TextBox
        Me.lbMoneda1 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSubirC = New System.Windows.Forms.Button
        Me.bBajarC = New System.Windows.Forms.Button
        Me.gbConceptos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbCabecera.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbConceptos
        '
        resources.ApplyResources(Me.gbConceptos, "gbConceptos")
        Me.gbConceptos.Controls.Add(Me.bSubirC)
        Me.gbConceptos.Controls.Add(Me.bBajarC)
        Me.gbConceptos.Controls.Add(Me.ObservacionesC)
        Me.gbConceptos.Controls.Add(Me.ckSeleccion)
        Me.gbConceptos.Controls.Add(Me.bLimpiar)
        Me.gbConceptos.Controls.Add(Me.bArticuloProveedor)
        Me.gbConceptos.Controls.Add(Me.bVerArticulo)
        Me.gbConceptos.Controls.Add(Me.bFamilias)
        Me.gbConceptos.Controls.Add(Me.BBuscarArticulo)
        Me.gbConceptos.Controls.Add(Me.Label39)
        Me.gbConceptos.Controls.Add(Me.lvConceptos)
        Me.gbConceptos.Controls.Add(Me.Label15)
        Me.gbConceptos.Controls.Add(Me.Label13)
        Me.gbConceptos.Controls.Add(Me.cbSubFamilia)
        Me.gbConceptos.Controls.Add(Me.lbMoneda3)
        Me.gbConceptos.Controls.Add(Me.cbFamilia)
        Me.gbConceptos.Controls.Add(Me.lbMoneda2)
        Me.gbConceptos.Controls.Add(Me.Label9)
        Me.gbConceptos.Controls.Add(Me.Label8)
        Me.gbConceptos.Controls.Add(Me.lbUnidad)
        Me.gbConceptos.Controls.Add(Me.Label12)
        Me.gbConceptos.Controls.Add(Me.cbcodArticuloProv)
        Me.gbConceptos.Controls.Add(Me.Label32)
        Me.gbConceptos.Controls.Add(Me.cbArticulo)
        Me.gbConceptos.Controls.Add(Me.Label38)
        Me.gbConceptos.Controls.Add(Me.cbcodArticulo)
        Me.gbConceptos.Controls.Add(Me.Label17)
        Me.gbConceptos.Controls.Add(Me.Label2)
        Me.gbConceptos.Controls.Add(Me.cbTipoIVA)
        Me.gbConceptos.Controls.Add(Me.Label16)
        Me.gbConceptos.Controls.Add(Me.DescuentoC)
        Me.gbConceptos.Controls.Add(Me.Cantidad)
        Me.gbConceptos.Controls.Add(Me.Label14)
        Me.gbConceptos.Controls.Add(Me.Precio)
        Me.gbConceptos.Controls.Add(Me.subTotal)
        Me.gbConceptos.Name = "gbConceptos"
        Me.gbConceptos.TabStop = False
        '
        'ObservacionesC
        '
        Me.ObservacionesC.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.ObservacionesC, "ObservacionesC")
        Me.ObservacionesC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ObservacionesC.Name = "ObservacionesC"
        Me.ObservacionesC.TabStop = False
        '
        'ckSeleccion
        '
        resources.ApplyResources(Me.ckSeleccion, "ckSeleccion")
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        resources.ApplyResources(Me.bLimpiar, "bLimpiar")
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bArticuloProveedor
        '
        resources.ApplyResources(Me.bArticuloProveedor, "bArticuloProveedor")
        Me.bArticuloProveedor.Name = "bArticuloProveedor"
        Me.bArticuloProveedor.UseVisualStyleBackColor = True
        '
        'bVerArticulo
        '
        resources.ApplyResources(Me.bVerArticulo, "bVerArticulo")
        Me.bVerArticulo.Name = "bVerArticulo"
        Me.bVerArticulo.UseVisualStyleBackColor = True
        '
        'bFamilias
        '
        resources.ApplyResources(Me.bFamilias, "bFamilias")
        Me.bFamilias.Name = "bFamilias"
        Me.bFamilias.UseVisualStyleBackColor = True
        '
        'BBuscarArticulo
        '
        Me.BBuscarArticulo.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.BBuscarArticulo, "BBuscarArticulo")
        Me.BBuscarArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.BBuscarArticulo.Name = "BBuscarArticulo"
        Me.BBuscarArticulo.UseVisualStyleBackColor = True
        '
        'Label39
        '
        resources.ApplyResources(Me.Label39, "Label39")
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.Name = "Label39"
        '
        'lvConceptos
        '
        Me.lvConceptos.AllowColumnReorder = True
        resources.ApplyResources(Me.lvConceptos, "lvConceptos")
        Me.lvConceptos.AutoArrange = False
        Me.lvConceptos.BackgroundImageTiled = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCk, Me.lvidconcepto, Me.lvcodArticulo, Me.lvcodArticuloProv, Me.lvdescripcion, Me.lvCantidad, Me.lvPrecio, Me.lvDescuento, Me.lvtotal, Me.lvidArticulo, Me.idEstado, Me.lvTipoIVA, Me.lvAlbaran})
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvCk
        '
        resources.ApplyResources(Me.lvCk, "lvCk")
        '
        'lvidconcepto
        '
        resources.ApplyResources(Me.lvidconcepto, "lvidconcepto")
        '
        'lvcodArticulo
        '
        resources.ApplyResources(Me.lvcodArticulo, "lvcodArticulo")
        '
        'lvcodArticuloProv
        '
        resources.ApplyResources(Me.lvcodArticuloProv, "lvcodArticuloProv")
        '
        'lvdescripcion
        '
        resources.ApplyResources(Me.lvdescripcion, "lvdescripcion")
        '
        'lvCantidad
        '
        resources.ApplyResources(Me.lvCantidad, "lvCantidad")
        '
        'lvPrecio
        '
        resources.ApplyResources(Me.lvPrecio, "lvPrecio")
        '
        'lvDescuento
        '
        resources.ApplyResources(Me.lvDescuento, "lvDescuento")
        '
        'lvtotal
        '
        resources.ApplyResources(Me.lvtotal, "lvtotal")
        '
        'lvidArticulo
        '
        resources.ApplyResources(Me.lvidArticulo, "lvidArticulo")
        '
        'idEstado
        '
        resources.ApplyResources(Me.idEstado, "idEstado")
        '
        'lvTipoIVA
        '
        resources.ApplyResources(Me.lvTipoIVA, "lvTipoIVA")
        '
        'lvAlbaran
        '
        resources.ApplyResources(Me.lvAlbaran, "lvAlbaran")
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.Name = "Label15"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Name = "Label13"
        '
        'cbSubFamilia
        '
        resources.ApplyResources(Me.cbSubFamilia, "cbSubFamilia")
        Me.cbSubFamilia.FormattingEnabled = True
        Me.cbSubFamilia.Name = "cbSubFamilia"
        '
        'lbMoneda3
        '
        resources.ApplyResources(Me.lbMoneda3, "lbMoneda3")
        Me.lbMoneda3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda3.Name = "lbMoneda3"
        '
        'cbFamilia
        '
        Me.cbFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        resources.ApplyResources(Me.cbFamilia, "cbFamilia")
        Me.cbFamilia.FormattingEnabled = True
        Me.cbFamilia.Name = "cbFamilia"
        '
        'lbMoneda2
        '
        resources.ApplyResources(Me.lbMoneda2, "lbMoneda2")
        Me.lbMoneda2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda2.Name = "lbMoneda2"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Name = "Label8"
        '
        'lbUnidad
        '
        resources.ApplyResources(Me.lbUnidad, "lbUnidad")
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.Name = "lbUnidad"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Name = "Label12"
        '
        'cbcodArticuloProv
        '
        Me.cbcodArticuloProv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticuloProv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbcodArticuloProv, "cbcodArticuloProv")
        Me.cbcodArticuloProv.FormattingEnabled = True
        Me.cbcodArticuloProv.Name = "cbcodArticuloProv"
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label32.Name = "Label32"
        '
        'cbArticulo
        '
        Me.cbArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbArticulo, "cbArticulo")
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Name = "cbArticulo"
        '
        'Label38
        '
        resources.ApplyResources(Me.Label38, "Label38")
        Me.Label38.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label38.Name = "Label38"
        '
        'cbcodArticulo
        '
        Me.cbcodArticulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbcodArticulo, "cbcodArticulo")
        Me.cbcodArticulo.FormattingEnabled = True
        Me.cbcodArticulo.Name = "cbcodArticulo"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Name = "Label17"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Name = "Label2"
        '
        'cbTipoIVA
        '
        Me.cbTipoIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbTipoIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbTipoIVA, "cbTipoIVA")
        Me.cbTipoIVA.FormattingEnabled = True
        Me.cbTipoIVA.Name = "cbTipoIVA"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.Name = "Label16"
        '
        'DescuentoC
        '
        Me.DescuentoC.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.DescuentoC, "DescuentoC")
        Me.DescuentoC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DescuentoC.Name = "DescuentoC"
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.Cantidad, "Cantidad")
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Name = "Cantidad"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.Name = "Label14"
        '
        'Precio
        '
        Me.Precio.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.Precio, "Precio")
        Me.Precio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Precio.Name = "Precio"
        '
        'subTotal
        '
        Me.subTotal.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.subTotal, "subTotal")
        Me.subTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.subTotal.Name = "subTotal"
        Me.subTotal.ReadOnly = True
        '
        'bBorrar
        '
        Me.bBorrar.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.bBorrar, "bBorrar")
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.TabStop = False
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'Total
        '
        resources.ApplyResources(Me.Total, "Total")
        Me.Total.ForeColor = System.Drawing.Color.Black
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'bGuardar
        '
        resources.ApplyResources(Me.bGuardar, "bGuardar")
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        resources.ApplyResources(Me.bImprimir, "bImprimir")
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bEmail
        '
        resources.ApplyResources(Me.bEmail, "bEmail")
        Me.bEmail.Name = "bEmail"
        Me.bEmail.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.codFactura)
        Me.GroupBox1.Controls.Add(Me.lbNumDoc1)
        Me.GroupBox1.Controls.Add(Me.lbNumDoc2)
        Me.GroupBox1.Controls.Add(Me.numDoc1)
        Me.GroupBox1.Controls.Add(Me.Referencia)
        Me.GroupBox1.Controls.Add(Me.numFactura)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbSolicitadoPor)
        Me.GroupBox1.Controls.Add(Me.Label23)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'codFactura
        '
        Me.codFactura.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.codFactura, "codFactura")
        Me.codFactura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.codFactura.Name = "codFactura"
        Me.codFactura.TabStop = False
        '
        'lbNumDoc1
        '
        resources.ApplyResources(Me.lbNumDoc1, "lbNumDoc1")
        Me.lbNumDoc1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc1.Name = "lbNumDoc1"
        '
        'lbNumDoc2
        '
        resources.ApplyResources(Me.lbNumDoc2, "lbNumDoc2")
        Me.lbNumDoc2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbNumDoc2.Name = "lbNumDoc2"
        '
        'numDoc1
        '
        Me.numDoc1.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.numDoc1, "numDoc1")
        Me.numDoc1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numDoc1.Name = "numDoc1"
        Me.numDoc1.ReadOnly = True
        Me.numDoc1.TabStop = False
        '
        'Referencia
        '
        resources.ApplyResources(Me.Referencia, "Referencia")
        Me.Referencia.Name = "Referencia"
        '
        'numFactura
        '
        Me.numFactura.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.numFactura, "numFactura")
        Me.numFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.numFactura.Name = "numFactura"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Name = "Label4"
        '
        'cbSolicitadoPor
        '
        Me.cbSolicitadoPor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbSolicitadoPor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbSolicitadoPor, "cbSolicitadoPor")
        Me.cbSolicitadoPor.FormattingEnabled = True
        Me.cbSolicitadoPor.Name = "cbSolicitadoPor"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.Name = "Label23"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Name = "Label18"
        '
        'cbEstado
        '
        Me.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbEstado, "cbEstado")
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Sorted = True
        '
        'dtpFecha
        '
        resources.ApplyResources(Me.dtpFecha, "dtpFecha")
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Value = New Date(2013, 12, 13, 0, 0, 0, 0)
        '
        'CheckBox2
        '
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tipoIVA
        '
        resources.ApplyResources(Me.tipoIVA, "tipoIVA")
        Me.tipoIVA.ForeColor = System.Drawing.Color.DarkRed
        Me.tipoIVA.Name = "tipoIVA"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.Name = "Label21"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.Name = "Label20"
        '
        'cbProveedor
        '
        Me.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cbProveedor, "cbProveedor")
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Name = "cbProveedor"
        '
        'cbsolicitadoVia
        '
        resources.ApplyResources(Me.cbsolicitadoVia, "cbsolicitadoVia")
        Me.cbsolicitadoVia.FormattingEnabled = True
        Me.cbsolicitadoVia.Name = "cbsolicitadoVia"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.Name = "Label22"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.Name = "Label24"
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.lvVencimientos)
        Me.gbCabecera.Controls.Add(Me.Label25)
        Me.gbCabecera.Controls.Add(Me.bVerIVAs)
        Me.gbCabecera.Controls.Add(Me.bVencimientos)
        Me.gbCabecera.Controls.Add(Me.lbmonedaT)
        Me.gbCabecera.Controls.Add(Me.PrecioTransporte)
        Me.gbCabecera.Controls.Add(Me.Label33)
        Me.gbCabecera.Controls.Add(Me.cbDireccion)
        Me.gbCabecera.Controls.Add(Me.GroupBox5)
        Me.gbCabecera.Controls.Add(Me.Label28)
        Me.gbCabecera.Controls.Add(Me.bMoneda)
        Me.gbCabecera.Controls.Add(Me.Label29)
        Me.gbCabecera.Controls.Add(Me.cbMoneda)
        Me.gbCabecera.Controls.Add(Me.cbCodProveedor)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Controls.Add(Me.Nota)
        Me.gbCabecera.Controls.Add(Me.Label1)
        Me.gbCabecera.Controls.Add(Me.cbContacto)
        Me.gbCabecera.Controls.Add(Me.bVerProveedor)
        Me.gbCabecera.Controls.Add(Me.bTiposPago)
        Me.gbCabecera.Controls.Add(Me.bBuscarProveedor)
        Me.gbCabecera.Controls.Add(Me.bMediosPago)
        Me.gbCabecera.Controls.Add(Me.Label31)
        Me.gbCabecera.Controls.Add(Me.Label36)
        Me.gbCabecera.Controls.Add(Me.Label11)
        Me.gbCabecera.Controls.Add(Me.Label27)
        Me.gbCabecera.Controls.Add(Me.Observaciones)
        Me.gbCabecera.Controls.Add(Me.Label10)
        Me.gbCabecera.Controls.Add(Me.cbRetencion)
        Me.gbCabecera.Controls.Add(Me.GroupBox1)
        Me.gbCabecera.Controls.Add(Me.ckRecargoEquivalencia)
        Me.gbCabecera.Controls.Add(Me.CheckBox2)
        Me.gbCabecera.Controls.Add(Me.Label22)
        Me.gbCabecera.Controls.Add(Me.cbCuenta)
        Me.gbCabecera.Controls.Add(Me.Button1)
        Me.gbCabecera.Controls.Add(Me.cbTipoPago)
        Me.gbCabecera.Controls.Add(Me.Label24)
        Me.gbCabecera.Controls.Add(Me.Label6)
        Me.gbCabecera.Controls.Add(Me.cbMedioPago)
        Me.gbCabecera.Controls.Add(Me.tipoIVA)
        Me.gbCabecera.Controls.Add(Me.cbsolicitadoVia)
        Me.gbCabecera.Controls.Add(Me.Label21)
        Me.gbCabecera.Controls.Add(Me.Label20)
        Me.gbCabecera.Controls.Add(Me.cbProveedor)
        Me.gbCabecera.Controls.Add(Me.Descuento)
        Me.gbCabecera.Controls.Add(Me.Label3)
        resources.ApplyResources(Me.gbCabecera, "gbCabecera")
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.TabStop = False
        '
        'lvVencimientos
        '
        resources.ApplyResources(Me.lvVencimientos, "lvVencimientos")
        Me.lvVencimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvFecha, Me.lvImprte})
        Me.lvVencimientos.FullRowSelect = True
        Me.lvVencimientos.GridLines = True
        Me.lvVencimientos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvVencimientos.MultiSelect = False
        Me.lvVencimientos.Name = "lvVencimientos"
        Me.lvVencimientos.UseCompatibleStateImageBehavior = False
        Me.lvVencimientos.View = System.Windows.Forms.View.Details
        '
        'lvFecha
        '
        resources.ApplyResources(Me.lvFecha, "lvFecha")
        '
        'lvImprte
        '
        resources.ApplyResources(Me.lvImprte, "lvImprte")
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.Name = "Label25"
        '
        'bVerIVAs
        '
        resources.ApplyResources(Me.bVerIVAs, "bVerIVAs")
        Me.bVerIVAs.Name = "bVerIVAs"
        Me.bVerIVAs.UseVisualStyleBackColor = True
        '
        'bVencimientos
        '
        resources.ApplyResources(Me.bVencimientos, "bVencimientos")
        Me.bVencimientos.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVencimientos.Name = "bVencimientos"
        Me.bVencimientos.UseVisualStyleBackColor = True
        '
        'lbmonedaT
        '
        resources.ApplyResources(Me.lbmonedaT, "lbmonedaT")
        Me.lbmonedaT.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbmonedaT.Name = "lbmonedaT"
        '
        'PrecioTransporte
        '
        Me.PrecioTransporte.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.PrecioTransporte, "PrecioTransporte")
        Me.PrecioTransporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioTransporte.Name = "PrecioTransporte"
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label33.Name = "Label33"
        '
        'cbDireccion
        '
        resources.ApplyResources(Me.cbDireccion, "cbDireccion")
        Me.cbDireccion.FormattingEnabled = True
        Me.cbDireccion.Name = "cbDireccion"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label30.Name = "Label30"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label28.Name = "Label28"
        '
        'bMoneda
        '
        resources.ApplyResources(Me.bMoneda, "bMoneda")
        Me.bMoneda.Name = "bMoneda"
        Me.bMoneda.UseVisualStyleBackColor = True
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label29.Name = "Label29"
        '
        'cbMoneda
        '
        resources.ApplyResources(Me.cbMoneda, "cbMoneda")
        Me.cbMoneda.FormattingEnabled = True
        Me.cbMoneda.Name = "cbMoneda"
        '
        'cbCodProveedor
        '
        resources.ApplyResources(Me.cbCodProveedor, "cbCodProveedor")
        Me.cbCodProveedor.FormattingEnabled = True
        Me.cbCodProveedor.Name = "cbCodProveedor"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Name = "Label7"
        '
        'Nota
        '
        resources.ApplyResources(Me.Nota, "Nota")
        Me.Nota.Name = "Nota"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Name = "Label1"
        '
        'cbContacto
        '
        resources.ApplyResources(Me.cbContacto, "cbContacto")
        Me.cbContacto.FormattingEnabled = True
        Me.cbContacto.Name = "cbContacto"
        '
        'bVerProveedor
        '
        resources.ApplyResources(Me.bVerProveedor, "bVerProveedor")
        Me.bVerProveedor.Name = "bVerProveedor"
        Me.bVerProveedor.UseVisualStyleBackColor = True
        '
        'bTiposPago
        '
        resources.ApplyResources(Me.bTiposPago, "bTiposPago")
        Me.bTiposPago.Name = "bTiposPago"
        Me.bTiposPago.UseVisualStyleBackColor = True
        '
        'bBuscarProveedor
        '
        resources.ApplyResources(Me.bBuscarProveedor, "bBuscarProveedor")
        Me.bBuscarProveedor.Name = "bBuscarProveedor"
        Me.bBuscarProveedor.UseVisualStyleBackColor = True
        '
        'bMediosPago
        '
        resources.ApplyResources(Me.bMediosPago, "bMediosPago")
        Me.bMediosPago.Name = "bMediosPago"
        Me.bMediosPago.UseVisualStyleBackColor = True
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.Name = "Label31"
        '
        'Label36
        '
        resources.ApplyResources(Me.Label36, "Label36")
        Me.Label36.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label36.Name = "Label36"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.Name = "Label11"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.Name = "Label27"
        '
        'Observaciones
        '
        resources.ApplyResources(Me.Observaciones, "Observaciones")
        Me.Observaciones.Name = "Observaciones"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.Name = "Label10"
        '
        'cbRetencion
        '
        resources.ApplyResources(Me.cbRetencion, "cbRetencion")
        Me.cbRetencion.FormattingEnabled = True
        Me.cbRetencion.Name = "cbRetencion"
        '
        'ckRecargoEquivalencia
        '
        resources.ApplyResources(Me.ckRecargoEquivalencia, "ckRecargoEquivalencia")
        Me.ckRecargoEquivalencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckRecargoEquivalencia.Name = "ckRecargoEquivalencia"
        Me.ckRecargoEquivalencia.UseVisualStyleBackColor = True
        '
        'cbCuenta
        '
        resources.ApplyResources(Me.cbCuenta, "cbCuenta")
        Me.cbCuenta.FormattingEnabled = True
        Me.cbCuenta.Name = "cbCuenta"
        '
        'cbTipoPago
        '
        resources.ApplyResources(Me.cbTipoPago, "cbTipoPago")
        Me.cbTipoPago.FormattingEnabled = True
        Me.cbTipoPago.Name = "cbTipoPago"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Name = "Label6"
        '
        'cbMedioPago
        '
        resources.ApplyResources(Me.cbMedioPago, "cbMedioPago")
        Me.cbMedioPago.FormattingEnabled = True
        Me.cbMedioPago.Name = "cbMedioPago"
        '
        'Descuento
        '
        Me.Descuento.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.Descuento, "Descuento")
        Me.Descuento.Name = "Descuento"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Name = "Label3"
        '
        'bSalir
        '
        resources.ApplyResources(Me.bSalir, "bSalir")
        Me.bSalir.Name = "bSalir"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'BNuevo
        '
        Me.BNuevo.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.BNuevo, "BNuevo")
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.UseVisualStyleBackColor = True
        '
        'bSubir
        '
        resources.ApplyResources(Me.bSubir, "bSubir")
        Me.bSubir.Name = "bSubir"
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        resources.ApplyResources(Me.bBajar, "bBajar")
        Me.bBajar.Name = "bBajar"
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bPDF
        '
        resources.ApplyResources(Me.bPDF, "bPDF")
        Me.bPDF.Name = "bPDF"
        Me.bPDF.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.lbMoneda7)
        Me.GroupBox2.Controls.Add(Me.TotalRE)
        Me.GroupBox2.Controls.Add(Me.lbMoneda6)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Retencion)
        Me.GroupBox2.Controls.Add(Me.lbMoneda5)
        Me.GroupBox2.Controls.Add(Me.cbEstado)
        Me.GroupBox2.Controls.Add(Me.lbMoneda4)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.TotalIVA)
        Me.GroupBox2.Controls.Add(Me.BaseImponible)
        Me.GroupBox2.Controls.Add(Me.lbMoneda1)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.bSalir)
        Me.GroupBox2.Controls.Add(Me.bSubir)
        Me.GroupBox2.Controls.Add(Me.Total)
        Me.GroupBox2.Controls.Add(Me.gbConceptos)
        Me.GroupBox2.Controls.Add(Me.bPDF)
        Me.GroupBox2.Controls.Add(Me.gbCabecera)
        Me.GroupBox2.Controls.Add(Me.bBajar)
        Me.GroupBox2.Controls.Add(Me.bGuardar)
        Me.GroupBox2.Controls.Add(Me.bEmail)
        Me.GroupBox2.Controls.Add(Me.bImprimir)
        Me.GroupBox2.Controls.Add(Me.BNuevo)
        Me.GroupBox2.Controls.Add(Me.bBorrar)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label40
        '
        resources.ApplyResources(Me.Label40, "Label40")
        Me.Label40.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label40.Name = "Label40"
        '
        'lbMoneda7
        '
        resources.ApplyResources(Me.lbMoneda7, "lbMoneda7")
        Me.lbMoneda7.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda7.Name = "lbMoneda7"
        '
        'TotalRE
        '
        resources.ApplyResources(Me.TotalRE, "TotalRE")
        Me.TotalRE.BackColor = System.Drawing.SystemColors.Control
        Me.TotalRE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalRE.Name = "TotalRE"
        Me.TotalRE.ReadOnly = True
        Me.TotalRE.TabStop = False
        '
        'lbMoneda6
        '
        resources.ApplyResources(Me.lbMoneda6, "lbMoneda6")
        Me.lbMoneda6.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda6.Name = "lbMoneda6"
        '
        'Label37
        '
        resources.ApplyResources(Me.Label37, "Label37")
        Me.Label37.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label37.Name = "Label37"
        '
        'Retencion
        '
        resources.ApplyResources(Me.Retencion, "Retencion")
        Me.Retencion.BackColor = System.Drawing.SystemColors.Control
        Me.Retencion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Retencion.Name = "Retencion"
        Me.Retencion.ReadOnly = True
        Me.Retencion.TabStop = False
        '
        'lbMoneda5
        '
        resources.ApplyResources(Me.lbMoneda5, "lbMoneda5")
        Me.lbMoneda5.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda5.Name = "lbMoneda5"
        '
        'lbMoneda4
        '
        resources.ApplyResources(Me.lbMoneda4, "lbMoneda4")
        Me.lbMoneda4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda4.Name = "lbMoneda4"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label34.Name = "Label34"
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label35.Name = "Label35"
        '
        'TotalIVA
        '
        resources.ApplyResources(Me.TotalIVA, "TotalIVA")
        Me.TotalIVA.BackColor = System.Drawing.SystemColors.Control
        Me.TotalIVA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalIVA.Name = "TotalIVA"
        Me.TotalIVA.ReadOnly = True
        Me.TotalIVA.TabStop = False
        '
        'BaseImponible
        '
        resources.ApplyResources(Me.BaseImponible, "BaseImponible")
        Me.BaseImponible.BackColor = System.Drawing.SystemColors.Control
        Me.BaseImponible.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BaseImponible.Name = "BaseImponible"
        Me.BaseImponible.ReadOnly = True
        Me.BaseImponible.TabStop = False
        '
        'lbMoneda1
        '
        resources.ApplyResources(Me.lbMoneda1, "lbMoneda1")
        Me.lbMoneda1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMoneda1.Name = "lbMoneda1"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.Name = "Label19"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'bSubirC
        '
        resources.ApplyResources(Me.bSubirC, "bSubirC")
        Me.bSubirC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_up
        Me.bSubirC.Name = "bSubirC"
        Me.bSubirC.UseVisualStyleBackColor = True
        '
        'bBajarC
        '
        resources.ApplyResources(Me.bBajarC, "bBajarC")
        Me.bBajarC.Image = Global.ERP_SUGAR.My.Resources.Resources.bullet_arrow_down
        Me.bBajarC.Name = "bBajarC"
        Me.bBajarC.UseVisualStyleBackColor = True
        '
        'GestionFacturaProv
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionFacturaProv"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.gbConceptos.ResumeLayout(False)
        Me.gbConceptos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConceptos As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbcodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidconcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloProv As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvtotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bEmail As System.Windows.Forms.Button
    Friend WithEvents gbCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cbsolicitadoVia As System.Windows.Forms.ComboBox
    Friend WithEvents cbSolicitadoPor As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents numFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents tipoIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents Referencia As System.Windows.Forms.TextBox
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbcodArticuloProv As System.Windows.Forms.ComboBox
    Friend WithEvents BNuevo As System.Windows.Forms.Button
    Friend WithEvents cbTipoIVA As System.Windows.Forms.ComboBox
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents BBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents bVerProveedor As System.Windows.Forms.Button
    Friend WithEvents bBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents bArticuloProveedor As System.Windows.Forms.Button
    Friend WithEvents bVerArticulo As System.Windows.Forms.Button
    Friend WithEvents bFamilias As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents bPDF As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbContacto As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Nota As System.Windows.Forms.TextBox
    Friend WithEvents cbCodProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bMoneda As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbDireccion As System.Windows.Forms.ComboBox
    Friend WithEvents lvDescuento As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda1 As System.Windows.Forms.Label
    Friend WithEvents lbmonedaT As System.Windows.Forms.Label
    Friend WithEvents PrecioTransporte As System.Windows.Forms.TextBox
    Friend WithEvents lbMoneda5 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda4 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TotalIVA As System.Windows.Forms.TextBox
    Friend WithEvents BaseImponible As System.Windows.Forms.TextBox
    Friend WithEvents idEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbMoneda6 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Retencion As System.Windows.Forms.TextBox
    Friend WithEvents codFactura As System.Windows.Forms.TextBox
    Friend WithEvents lbNumDoc1 As System.Windows.Forms.Label
    Friend WithEvents lbNumDoc2 As System.Windows.Forms.Label
    Friend WithEvents numDoc1 As System.Windows.Forms.TextBox
    Friend WithEvents lvCk As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda7 As System.Windows.Forms.Label
    Friend WithEvents TotalRE As System.Windows.Forms.TextBox
    Friend WithEvents lvTipoIVA As System.Windows.Forms.ColumnHeader
    Friend WithEvents ObservacionesC As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvVencimientos As System.Windows.Forms.ListView
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImprte As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents bVencimientos As System.Windows.Forms.Button
    Friend WithEvents lvAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents bTiposPago As System.Windows.Forms.Button
    Friend WithEvents bMediosPago As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents cbMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cbRetencion As System.Windows.Forms.ComboBox
    Friend WithEvents ckRecargoEquivalencia As System.Windows.Forms.CheckBox
    Friend WithEvents lbMoneda3 As System.Windows.Forms.Label
    Friend WithEvents lbMoneda2 As System.Windows.Forms.Label
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DescuentoC As System.Windows.Forms.TextBox
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Precio As System.Windows.Forms.TextBox
    Friend WithEvents subTotal As System.Windows.Forms.TextBox
    Friend WithEvents bVerIVAs As System.Windows.Forms.Button
    Friend WithEvents bSubirC As System.Windows.Forms.Button
    Friend WithEvents bBajarC As System.Windows.Forms.Button
End Class
