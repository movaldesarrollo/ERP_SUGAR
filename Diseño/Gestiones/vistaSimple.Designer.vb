<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class vistaSimple
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vistaSimple))
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.lvproduccion = New System.Windows.Forms.ListView()
        Me.lvColId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColFechaVolcado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColFechaPrevista = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColFechaPedido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColCelulas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColDomestico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColIndustrial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColRecambios = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColNotaImpresa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColRecambio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvcolPrioridad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColPDF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColFechaProduccion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColPedidosAX = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvColRoturaStock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvlColDomesticos2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalPedidos = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRIORIDADToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FUENTEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PARCIALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PENDIENTEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PREPARADOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCCIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCIDOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SERVIDOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarFechaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarFechaProducciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoturaDeStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NOToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PREPARARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LINEAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DOMÉSTICO2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecambiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndustrialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerNúmeroDeSerieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadoPedidosAXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ckVerTodos = New System.Windows.Forms.CheckBox()
        Me.tRefresco = New System.Windows.Forms.Timer(Me.components)
        Me.tConteo = New System.Windows.Forms.Timer(Me.components)
        Me.pbActualizacion = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.txPedidoAx = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bCalcular = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbClientes = New System.Windows.Forms.ComboBox()
        Me.ckIndustrial = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.ckParcial = New System.Windows.Forms.CheckBox()
        Me.ckPendiente = New System.Windows.Forms.CheckBox()
        Me.ckPreparado = New System.Windows.Forms.CheckBox()
        Me.ckProduccion = New System.Windows.Forms.CheckBox()
        Me.ckProducido = New System.Windows.Forms.CheckBox()
        Me.ckServido = New System.Windows.Forms.CheckBox()
        Me.txNumPedido = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbIndustriales = New System.Windows.Forms.Label()
        Me.lbDomesticos = New System.Windows.Forms.Label()
        Me.lbRecambios = New System.Windows.Forms.Label()
        Me.lbCelulas = New System.Windows.Forms.Label()
        Me.lbDomesticos2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscar.Image = Global.ERP_SUGAR.My.Resources.Resources.update
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(1339, 77)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(28, 22)
        Me.bBuscar.TabIndex = 145
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 143
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1282, 21)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 16
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'lvproduccion
        '
        Me.lvproduccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvproduccion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvColId, Me.lvColFechaPrevista, Me.lvColFechaPedido, Me.lvColCliente, Me.lvColCantidad, Me.lvColCelulas, Me.lvColDomestico, Me.lvColIndustrial, Me.lvColRecambios, Me.lvColNotaImpresa, Me.lvColRecambio, Me.lvcolPrioridad, Me.lvColEstado, Me.lvColPDF, Me.lvColFechaProduccion, Me.lvColPedidosAX, Me.lvColRoturaStock, Me.lvlColDomesticos2, Me.lvColFechaVolcado})
        Me.lvproduccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvproduccion.FullRowSelect = True
        Me.lvproduccion.GridLines = True
        Me.lvproduccion.HideSelection = False
        Me.lvproduccion.Location = New System.Drawing.Point(12, 109)
        Me.lvproduccion.MultiSelect = False
        Me.lvproduccion.Name = "lvproduccion"
        Me.lvproduccion.Size = New System.Drawing.Size(1579, 511)
        Me.lvproduccion.TabIndex = 146
        Me.lvproduccion.UseCompatibleStateImageBehavior = False
        Me.lvproduccion.View = System.Windows.Forms.View.Details
        '
        'lvColId
        '
        Me.lvColId.Text = "PEDIDO"
        Me.lvColId.Width = 83
        '
        'lvColFechaVolcado
        '
        Me.lvColFechaVolcado.DisplayIndex = 2
        Me.lvColFechaVolcado.Text = "F. VOLCADO"
        Me.lvColFechaVolcado.Width = 100
        '
        'lvColFechaPrevista
        '
        Me.lvColFechaPrevista.DisplayIndex = 3
        Me.lvColFechaPrevista.Text = "F.PREVISTA"
        Me.lvColFechaPrevista.Width = 101
        '
        'lvColFechaPedido
        '
        Me.lvColFechaPedido.DisplayIndex = 5
        Me.lvColFechaPedido.Text = "F.PEDIDO"
        Me.lvColFechaPedido.Width = 106
        '
        'lvColCliente
        '
        Me.lvColCliente.DisplayIndex = 6
        Me.lvColCliente.Text = "CLIENTE"
        Me.lvColCliente.Width = 155
        '
        'lvColCantidad
        '
        Me.lvColCantidad.DisplayIndex = 7
        Me.lvColCantidad.Text = "QTY."
        Me.lvColCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColCantidad.Width = 0
        '
        'lvColCelulas
        '
        Me.lvColCelulas.DisplayIndex = 8
        Me.lvColCelulas.Text = "CÉLULAS"
        Me.lvColCelulas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColCelulas.Width = 90
        '
        'lvColDomestico
        '
        Me.lvColDomestico.DisplayIndex = 10
        Me.lvColDomestico.Text = "DOMÉSTICO"
        Me.lvColDomestico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColDomestico.Width = 90
        '
        'lvColIndustrial
        '
        Me.lvColIndustrial.DisplayIndex = 11
        Me.lvColIndustrial.Text = "INDUSTRIAL"
        Me.lvColIndustrial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColIndustrial.Width = 83
        '
        'lvColRecambios
        '
        Me.lvColRecambios.DisplayIndex = 12
        Me.lvColRecambios.Text = "RECAMBIOS"
        Me.lvColRecambios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColRecambios.Width = 87
        '
        'lvColNotaImpresa
        '
        Me.lvColNotaImpresa.DisplayIndex = 13
        Me.lvColNotaImpresa.Text = "NOTA "
        Me.lvColNotaImpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvColNotaImpresa.Width = 57
        '
        'lvColRecambio
        '
        Me.lvColRecambio.DisplayIndex = 14
        Me.lvColRecambio.Text = "RECAMBIO"
        Me.lvColRecambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvColRecambio.Width = 0
        '
        'lvcolPrioridad
        '
        Me.lvcolPrioridad.DisplayIndex = 15
        Me.lvcolPrioridad.Text = "PRIORIDAD"
        Me.lvcolPrioridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvcolPrioridad.Width = 0
        '
        'lvColEstado
        '
        Me.lvColEstado.DisplayIndex = 16
        Me.lvColEstado.Text = "ESTADO"
        Me.lvColEstado.Width = 113
        '
        'lvColPDF
        '
        Me.lvColPDF.DisplayIndex = 17
        Me.lvColPDF.Text = "PDF"
        Me.lvColPDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvColPDF.Width = 45
        '
        'lvColFechaProduccion
        '
        Me.lvColFechaProduccion.DisplayIndex = 4
        Me.lvColFechaProduccion.Text = "F.  PRODUCCIÓN"
        Me.lvColFechaProduccion.Width = 125
        '
        'lvColPedidosAX
        '
        Me.lvColPedidosAX.DisplayIndex = 1
        Me.lvColPedidosAX.Text = "PEDIDO AX"
        Me.lvColPedidosAX.Width = 100
        '
        'lvColRoturaStock
        '
        Me.lvColRoturaStock.DisplayIndex = 18
        Me.lvColRoturaStock.Width = 0
        '
        'lvlColDomesticos2
        '
        Me.lvlColDomesticos2.DisplayIndex = 9
        Me.lvlColDomesticos2.Text = "DOMESTICOS 2"
        Me.lvlColDomesticos2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvlColDomesticos2.Width = 112
        '
        'totalPedidos
        '
        Me.totalPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.totalPedidos.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.totalPedidos.Location = New System.Drawing.Point(8, 632)
        Me.totalPedidos.Name = "totalPedidos"
        Me.totalPedidos.Size = New System.Drawing.Size(221, 22)
        Me.totalPedidos.TabIndex = 147
        Me.totalPedidos.Text = "TOTAL PEDIDOS: "
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Century Gothic", 14.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizaciónToolStripMenuItem, Me.PRIORIDADToolStripMenuItem, Me.FUENTEToolStripMenuItem, Me.EstadoToolStripMenuItem, Me.CambiarFechaToolStripMenuItem, Me.CambiarFechaProducciónToolStripMenuItem, Me.RoturaDeStockToolStripMenuItem, Me.PREPARARToolStripMenuItem, Me.VerNúmeroDeSerieToolStripMenuItem, Me.ListadoPedidosAXToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(334, 264)
        '
        'ActualizaciónToolStripMenuItem
        '
        Me.ActualizaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoToolStripMenuItem, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10})
        Me.ActualizaciónToolStripMenuItem.Name = "ActualizaciónToolStripMenuItem"
        Me.ActualizaciónToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.ActualizaciónToolStripMenuItem.Text = "Actualización"
        '
        'NoToolStripMenuItem
        '
        Me.NoToolStripMenuItem.Name = "NoToolStripMenuItem"
        Me.NoToolStripMenuItem.Size = New System.Drawing.Size(134, 26)
        Me.NoToolStripMenuItem.Text = "No"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(134, 26)
        Me.ToolStripMenuItem8.Text = "1min"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(134, 26)
        Me.ToolStripMenuItem9.Text = "5min"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(134, 26)
        Me.ToolStripMenuItem10.Text = "10min"
        '
        'PRIORIDADToolStripMenuItem
        '
        Me.PRIORIDADToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.PRIORIDADToolStripMenuItem.Name = "PRIORIDADToolStripMenuItem"
        Me.PRIORIDADToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.PRIORIDADToolStripMenuItem.Text = "Prioridad"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(91, 26)
        Me.ToolStripMenuItem2.Text = "1"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(91, 26)
        Me.ToolStripMenuItem3.Text = "2"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(91, 26)
        Me.ToolStripMenuItem4.Text = "3"
        '
        'FUENTEToolStripMenuItem
        '
        Me.FUENTEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7})
        Me.FUENTEToolStripMenuItem.Name = "FUENTEToolStripMenuItem"
        Me.FUENTEToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.FUENTEToolStripMenuItem.Text = "Zoom"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(128, 26)
        Me.ToolStripMenuItem5.Text = "100%"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(128, 26)
        Me.ToolStripMenuItem6.Text = "150%"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(128, 26)
        Me.ToolStripMenuItem7.Text = "200%"
        '
        'EstadoToolStripMenuItem
        '
        Me.EstadoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PARCIALToolStripMenuItem, Me.PENDIENTEToolStripMenuItem, Me.PREPARADOToolStripMenuItem, Me.PRODUCCIONToolStripMenuItem, Me.PRODUCIDOToolStripMenuItem, Me.SERVIDOToolStripMenuItem})
        Me.EstadoToolStripMenuItem.Name = "EstadoToolStripMenuItem"
        Me.EstadoToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.EstadoToolStripMenuItem.Text = "Estado"
        '
        'PARCIALToolStripMenuItem
        '
        Me.PARCIALToolStripMenuItem.Name = "PARCIALToolStripMenuItem"
        Me.PARCIALToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PARCIALToolStripMenuItem.Text = "PARCIAL"
        '
        'PENDIENTEToolStripMenuItem
        '
        Me.PENDIENTEToolStripMenuItem.Name = "PENDIENTEToolStripMenuItem"
        Me.PENDIENTEToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PENDIENTEToolStripMenuItem.Text = "PENDIENTE"
        '
        'PREPARADOToolStripMenuItem
        '
        Me.PREPARADOToolStripMenuItem.Name = "PREPARADOToolStripMenuItem"
        Me.PREPARADOToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PREPARADOToolStripMenuItem.Text = "PREPARADO"
        '
        'PRODUCCIONToolStripMenuItem
        '
        Me.PRODUCCIONToolStripMenuItem.Name = "PRODUCCIONToolStripMenuItem"
        Me.PRODUCCIONToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PRODUCCIONToolStripMenuItem.Text = "PRODUCCIÓN"
        '
        'PRODUCIDOToolStripMenuItem
        '
        Me.PRODUCIDOToolStripMenuItem.Name = "PRODUCIDOToolStripMenuItem"
        Me.PRODUCIDOToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.PRODUCIDOToolStripMenuItem.Text = "PRODUCIDO"
        '
        'SERVIDOToolStripMenuItem
        '
        Me.SERVIDOToolStripMenuItem.Name = "SERVIDOToolStripMenuItem"
        Me.SERVIDOToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.SERVIDOToolStripMenuItem.Text = "SERVIDO"
        '
        'CambiarFechaToolStripMenuItem
        '
        Me.CambiarFechaToolStripMenuItem.Name = "CambiarFechaToolStripMenuItem"
        Me.CambiarFechaToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.CambiarFechaToolStripMenuItem.Text = "Cambiar Fecha Prevista"
        '
        'CambiarFechaProducciónToolStripMenuItem
        '
        Me.CambiarFechaProducciónToolStripMenuItem.Name = "CambiarFechaProducciónToolStripMenuItem"
        Me.CambiarFechaProducciónToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.CambiarFechaProducciónToolStripMenuItem.Text = "Cambiar Fecha Producción"
        '
        'RoturaDeStockToolStripMenuItem
        '
        Me.RoturaDeStockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SIToolStripMenuItem, Me.NOToolStripMenuItem1})
        Me.RoturaDeStockToolStripMenuItem.Name = "RoturaDeStockToolStripMenuItem"
        Me.RoturaDeStockToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.RoturaDeStockToolStripMenuItem.Text = "Rotura de Stock"
        '
        'SIToolStripMenuItem
        '
        Me.SIToolStripMenuItem.Name = "SIToolStripMenuItem"
        Me.SIToolStripMenuItem.Size = New System.Drawing.Size(111, 26)
        Me.SIToolStripMenuItem.Text = "SI"
        '
        'NOToolStripMenuItem1
        '
        Me.NOToolStripMenuItem1.Name = "NOToolStripMenuItem1"
        Me.NOToolStripMenuItem1.Size = New System.Drawing.Size(111, 26)
        Me.NOToolStripMenuItem1.Text = "NO"
        '
        'PREPARARToolStripMenuItem
        '
        Me.PREPARARToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LINEAToolStripMenuItem, Me.DOMÉSTICO2ToolStripMenuItem, Me.RecambiosToolStripMenuItem, Me.IndustrialToolStripMenuItem})
        Me.PREPARARToolStripMenuItem.Name = "PREPARARToolStripMenuItem"
        Me.PREPARARToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.PREPARARToolStripMenuItem.Text = "Preparar pedido"
        '
        'LINEAToolStripMenuItem
        '
        Me.LINEAToolStripMenuItem.Name = "LINEAToolStripMenuItem"
        Me.LINEAToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.LINEAToolStripMenuItem.Text = "Doméstico"
        '
        'DOMÉSTICO2ToolStripMenuItem
        '
        Me.DOMÉSTICO2ToolStripMenuItem.Name = "DOMÉSTICO2ToolStripMenuItem"
        Me.DOMÉSTICO2ToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.DOMÉSTICO2ToolStripMenuItem.Text = "Doméstico2"
        '
        'RecambiosToolStripMenuItem
        '
        Me.RecambiosToolStripMenuItem.Name = "RecambiosToolStripMenuItem"
        Me.RecambiosToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.RecambiosToolStripMenuItem.Text = "Individual"
        '
        'IndustrialToolStripMenuItem
        '
        Me.IndustrialToolStripMenuItem.Name = "IndustrialToolStripMenuItem"
        Me.IndustrialToolStripMenuItem.Size = New System.Drawing.Size(187, 26)
        Me.IndustrialToolStripMenuItem.Text = "Industrial"
        '
        'VerNúmeroDeSerieToolStripMenuItem
        '
        Me.VerNúmeroDeSerieToolStripMenuItem.Name = "VerNúmeroDeSerieToolStripMenuItem"
        Me.VerNúmeroDeSerieToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.VerNúmeroDeSerieToolStripMenuItem.Text = "Ver números de serie"
        '
        'ListadoPedidosAXToolStripMenuItem
        '
        Me.ListadoPedidosAXToolStripMenuItem.Name = "ListadoPedidosAXToolStripMenuItem"
        Me.ListadoPedidosAXToolStripMenuItem.Size = New System.Drawing.Size(333, 26)
        Me.ListadoPedidosAXToolStripMenuItem.Text = "Listado pedidos AX"
        '
        'ckVerTodos
        '
        Me.ckVerTodos.AutoSize = True
        Me.ckVerTodos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerTodos.Location = New System.Drawing.Point(700, 78)
        Me.ckVerTodos.Name = "ckVerTodos"
        Me.ckVerTodos.Size = New System.Drawing.Size(98, 21)
        Me.ckVerTodos.TabIndex = 12
        Me.ckVerTodos.Text = "VER TODOS"
        Me.ckVerTodos.UseVisualStyleBackColor = True
        '
        'tRefresco
        '
        '
        'tConteo
        '
        Me.tConteo.Interval = 1000
        '
        'pbActualizacion
        '
        Me.pbActualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbActualizacion.Location = New System.Drawing.Point(1191, 83)
        Me.pbActualizacion.Maximum = 60
        Me.pbActualizacion.Name = "pbActualizacion"
        Me.pbActualizacion.Size = New System.Drawing.Size(142, 10)
        Me.pbActualizacion.Step = 1
        Me.pbActualizacion.TabIndex = 149
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.bBuscar)
        Me.GroupBox1.Controls.Add(Me.txPedidoAx)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.bCalcular)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbClientes)
        Me.GroupBox1.Controls.Add(Me.ckIndustrial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.bLimpiar)
        Me.GroupBox1.Controls.Add(Me.ckParcial)
        Me.GroupBox1.Controls.Add(Me.ckPendiente)
        Me.GroupBox1.Controls.Add(Me.ckPreparado)
        Me.GroupBox1.Controls.Add(Me.ckProduccion)
        Me.GroupBox1.Controls.Add(Me.ckVerTodos)
        Me.GroupBox1.Controls.Add(Me.ckProducido)
        Me.GroupBox1.Controls.Add(Me.ckServido)
        Me.GroupBox1.Controls.Add(Me.txNumPedido)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.pbActualizacion)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 14.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(218, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1373, 105)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExcel.Location = New System.Drawing.Point(1009, 21)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(85, 50)
        Me.btnExcel.TabIndex = 13
        Me.btnExcel.Text = "EXCEL"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'txPedidoAx
        '
        Me.txPedidoAx.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPedidoAx.Location = New System.Drawing.Point(299, 35)
        Me.txPedidoAx.MaxLength = 20
        Me.txPedidoAx.Name = "txPedidoAx"
        Me.txPedidoAx.Size = New System.Drawing.Size(95, 23)
        Me.txPedidoAx.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(211, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 17)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "PEDIDO AX:"
        '
        'bCalcular
        '
        Me.bCalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCalcular.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCalcular.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCalcular.Location = New System.Drawing.Point(1100, 21)
        Me.bCalcular.Name = "bCalcular"
        Me.bCalcular.Size = New System.Drawing.Size(85, 50)
        Me.bCalcular.TabIndex = 14
        Me.bCalcular.Text = "CALCULAR FECHA"
        Me.bCalcular.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(400, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "CLIENTE:"
        '
        'cbClientes
        '
        Me.cbClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbClientes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbClientes.FormattingEnabled = True
        Me.cbClientes.Location = New System.Drawing.Point(467, 34)
        Me.cbClientes.Name = "cbClientes"
        Me.cbClientes.Size = New System.Drawing.Size(428, 25)
        Me.cbClientes.TabIndex = 3
        '
        'ckIndustrial
        '
        Me.ckIndustrial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckIndustrial.AutoSize = True
        Me.ckIndustrial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckIndustrial.Location = New System.Drawing.Point(901, 38)
        Me.ckIndustrial.Name = "ckIndustrial"
        Me.ckIndustrial.Size = New System.Drawing.Size(95, 21)
        Me.ckIndustrial.TabIndex = 4
        Me.ckIndustrial.Text = "INDUSTRIAL"
        Me.ckIndustrial.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ESTADOS:"
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1191, 21)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 15
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'ckParcial
        '
        Me.ckParcial.AutoSize = True
        Me.ckParcial.Checked = True
        Me.ckParcial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckParcial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckParcial.Location = New System.Drawing.Point(78, 78)
        Me.ckParcial.Name = "ckParcial"
        Me.ckParcial.Size = New System.Drawing.Size(81, 21)
        Me.ckParcial.TabIndex = 6
        Me.ckParcial.Text = "PARCIAL"
        Me.ckParcial.UseVisualStyleBackColor = True
        '
        'ckPendiente
        '
        Me.ckPendiente.AutoSize = True
        Me.ckPendiente.Checked = True
        Me.ckPendiente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckPendiente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPendiente.Location = New System.Drawing.Point(165, 78)
        Me.ckPendiente.Name = "ckPendiente"
        Me.ckPendiente.Size = New System.Drawing.Size(94, 21)
        Me.ckPendiente.TabIndex = 7
        Me.ckPendiente.Text = "PENDIENTE"
        Me.ckPendiente.UseVisualStyleBackColor = True
        '
        'ckPreparado
        '
        Me.ckPreparado.AutoSize = True
        Me.ckPreparado.Checked = True
        Me.ckPreparado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckPreparado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPreparado.Location = New System.Drawing.Point(265, 78)
        Me.ckPreparado.Name = "ckPreparado"
        Me.ckPreparado.Size = New System.Drawing.Size(105, 21)
        Me.ckPreparado.TabIndex = 8
        Me.ckPreparado.Text = "PREPARADO"
        Me.ckPreparado.UseVisualStyleBackColor = True
        '
        'ckProduccion
        '
        Me.ckProduccion.AutoSize = True
        Me.ckProduccion.Checked = True
        Me.ckProduccion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckProduccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckProduccion.Location = New System.Drawing.Point(376, 78)
        Me.ckProduccion.Name = "ckProduccion"
        Me.ckProduccion.Size = New System.Drawing.Size(118, 21)
        Me.ckProduccion.TabIndex = 9
        Me.ckProduccion.Text = "PRODUCCIÓN"
        Me.ckProduccion.UseVisualStyleBackColor = True
        '
        'ckProducido
        '
        Me.ckProducido.AutoSize = True
        Me.ckProducido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckProducido.Location = New System.Drawing.Point(500, 78)
        Me.ckProducido.Name = "ckProducido"
        Me.ckProducido.Size = New System.Drawing.Size(107, 21)
        Me.ckProducido.TabIndex = 10
        Me.ckProducido.Text = "PRODUCIDO"
        Me.ckProducido.UseVisualStyleBackColor = True
        '
        'ckServido
        '
        Me.ckServido.AutoSize = True
        Me.ckServido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckServido.Location = New System.Drawing.Point(613, 78)
        Me.ckServido.Name = "ckServido"
        Me.ckServido.Size = New System.Drawing.Size(81, 21)
        Me.ckServido.TabIndex = 11
        Me.ckServido.Text = "SERVIDO"
        Me.ckServido.UseVisualStyleBackColor = True
        '
        'txNumPedido
        '
        Me.txNumPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNumPedido.Location = New System.Drawing.Point(110, 35)
        Me.txNumPedido.MaxLength = 8
        Me.txNumPedido.Name = "txNumPedido"
        Me.txNumPedido.Size = New System.Drawing.Size(95, 23)
        Me.txNumPedido.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NUM. PEDIDO:"
        '
        'lbIndustriales
        '
        Me.lbIndustriales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbIndustriales.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.lbIndustriales.Location = New System.Drawing.Point(1294, 632)
        Me.lbIndustriales.Name = "lbIndustriales"
        Me.lbIndustriales.Size = New System.Drawing.Size(291, 22)
        Me.lbIndustriales.TabIndex = 152
        Me.lbIndustriales.Text = "TOTAL INDUSTRIALES: "
        '
        'lbDomesticos
        '
        Me.lbDomesticos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbDomesticos.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.lbDomesticos.Location = New System.Drawing.Point(714, 632)
        Me.lbDomesticos.Name = "lbDomesticos"
        Me.lbDomesticos.Size = New System.Drawing.Size(277, 22)
        Me.lbDomesticos.TabIndex = 153
        Me.lbDomesticos.Text = "TOTAL DOMÉSTICOS: "
        '
        'lbRecambios
        '
        Me.lbRecambios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbRecambios.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.lbRecambios.Location = New System.Drawing.Point(235, 632)
        Me.lbRecambios.Name = "lbRecambios"
        Me.lbRecambios.Size = New System.Drawing.Size(216, 22)
        Me.lbRecambios.TabIndex = 154
        Me.lbRecambios.Text = "TOTAL RECAMBIOS: "
        '
        'lbCelulas
        '
        Me.lbCelulas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCelulas.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.lbCelulas.Location = New System.Drawing.Point(479, 632)
        Me.lbCelulas.Name = "lbCelulas"
        Me.lbCelulas.Size = New System.Drawing.Size(229, 22)
        Me.lbCelulas.TabIndex = 155
        Me.lbCelulas.Text = "TOTAL CÉLULAS:"
        '
        'lbDomesticos2
        '
        Me.lbDomesticos2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbDomesticos2.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.lbDomesticos2.Location = New System.Drawing.Point(1011, 632)
        Me.lbDomesticos2.Name = "lbDomesticos2"
        Me.lbDomesticos2.Size = New System.Drawing.Size(277, 22)
        Me.lbDomesticos2.TabIndex = 156
        Me.lbDomesticos2.Text = "TOTAL DOMÉSTICOS 2: "
        '
        'vistaSimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1603, 663)
        Me.Controls.Add(Me.lbDomesticos2)
        Me.Controls.Add(Me.lbCelulas)
        Me.Controls.Add(Me.lbRecambios)
        Me.Controls.Add(Me.lbDomesticos)
        Me.Controls.Add(Me.lbIndustriales)
        Me.Controls.Add(Me.totalPedidos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvproduccion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "vistaSimple"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VISTA SIMPLE  - GESTIÓN DE PEDIDOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvproduccion As System.Windows.Forms.ListView
    Friend WithEvents lvColId As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColFechaPrevista As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColFechaPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCelulas As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColDomestico As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColNotaImpresa As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColRecambio As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcolPrioridad As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalPedidos As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PRIORIDADToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvColEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckVerTodos As System.Windows.Forms.CheckBox
    Friend WithEvents lvColPDF As System.Windows.Forms.ColumnHeader
    Friend WithEvents tRefresco As System.Windows.Forms.Timer
    Friend WithEvents tConteo As System.Windows.Forms.Timer
    Friend WithEvents pbActualizacion As System.Windows.Forms.ProgressBar
    Friend WithEvents FUENTEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvColRecambios As System.Windows.Forms.ColumnHeader
    Friend WithEvents EstadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PREPARADOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SERVIDOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PENDIENTEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PARCIALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRODUCCIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRODUCIDOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txNumPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckServido As System.Windows.Forms.CheckBox
    Friend WithEvents ckParcial As System.Windows.Forms.CheckBox
    Friend WithEvents ckPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents ckPreparado As System.Windows.Forms.CheckBox
    Friend WithEvents ckProduccion As System.Windows.Forms.CheckBox
    Friend WithEvents ckProducido As System.Windows.Forms.CheckBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents lvColIndustrial As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ckIndustrial As System.Windows.Forms.CheckBox
    Friend WithEvents lbIndustriales As System.Windows.Forms.Label
    Friend WithEvents lbDomesticos As System.Windows.Forms.Label
    Friend WithEvents lbRecambios As System.Windows.Forms.Label
    Friend WithEvents lbCelulas As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents CambiarFechaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvColFechaProduccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents CambiarFechaProducciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RoturaDeStockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bCalcular As System.Windows.Forms.Button
    Friend WithEvents lvColPedidosAX As System.Windows.Forms.ColumnHeader
    Friend WithEvents txPedidoAx As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PREPARARToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LINEAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecambiosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IndustrialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerNúmeroDeSerieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadoPedidosAXToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lbDomesticos2 As Label
    Friend WithEvents lvColRoturaStock As ColumnHeader
    Friend WithEvents lvlColDomesticos2 As ColumnHeader
    Friend WithEvents DOMÉSTICO2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnExcel As Button
    Friend WithEvents lvColFechaVolcado As ColumnHeader
End Class
