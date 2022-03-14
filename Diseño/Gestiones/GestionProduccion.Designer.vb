<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionProduccion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbConceptos = New System.Windows.Forms.TabControl
        Me.tpDetalle = New System.Windows.Forms.TabPage
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.rbProd3 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.bLimpiarProv = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.rbProd2 = New System.Windows.Forms.RadioButton
        Me.cbcodArticuloProd = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbArticuloProd = New System.Windows.Forms.ComboBox
        Me.rbProd1 = New System.Windows.Forms.RadioButton
        Me.bBuscarArticuloProd = New System.Windows.Forms.Button
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.bVerArticuloProv = New System.Windows.Forms.Button
        Me.dtpFechaPrevista = New System.Windows.Forms.DateTimePicker
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvidProduccion = New System.Windows.Forms.ColumnHeader
        Me.lvidArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvAcabados = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedido = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPedido = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPrevista = New System.Windows.Forms.ColumnHeader
        Me.lvPrioridad = New System.Windows.Forms.ColumnHeader
        Me.Label20 = New System.Windows.Forms.Label
        Me.tpGlobal = New System.Windows.Forms.TabPage
        Me.lvConceptosGlobal = New System.Windows.Forms.ListView
        Me.lvidArticuloB = New System.Windows.Forms.ColumnHeader
        Me.lvTipoB = New System.Windows.Forms.ColumnHeader
        Me.lvCodigoB = New System.Windows.Forms.ColumnHeader
        Me.lvArticuloB = New System.Windows.Forms.ColumnHeader
        Me.lvCantidadB = New System.Windows.Forms.ColumnHeader
        Me.lvEstaSemana = New System.Windows.Forms.ColumnHeader
        Me.lvSemanaProxima = New System.Windows.Forms.ColumnHeader
        Me.lvEn2Semanas = New System.Windows.Forms.ColumnHeader
        Me.lvMas2Semanas = New System.Windows.Forms.ColumnHeader
        Me.EnMasSemanas = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.numPedido = New System.Windows.Forms.TextBox
        Me.BusquedaLibre = New System.Windows.Forms.TextBox
        Me.bTipos = New System.Windows.Forms.Button
        Me.ckVerInactivos = New System.Windows.Forms.CheckBox
        Me.rbFiltro3 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFechaPedidoHasta = New System.Windows.Forms.DateTimePicker
        Me.rbFiltro2 = New System.Windows.Forms.RadioButton
        Me.dtpFechaPedidoDesde = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaPrevistaHasta = New System.Windows.Forms.DateTimePicker
        Me.rbTodos = New System.Windows.Forms.RadioButton
        Me.rbFiltro1 = New System.Windows.Forms.RadioButton
        Me.dtpFechaPrevistaDesde = New System.Windows.Forms.DateTimePicker
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.cbTipo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbCodCliente = New System.Windows.Forms.ComboBox
        Me.cbCliente = New System.Windows.Forms.ComboBox
        Me.bVerArticulo = New System.Windows.Forms.Button
        Me.bVerCliente = New System.Windows.Forms.Button
        Me.bBuscarCliente = New System.Windows.Forms.Button
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.bBuscarArticulo = New System.Windows.Forms.Button
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.bBorrar = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bLimpiaFiltro = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.bVistaTaller = New System.Windows.Forms.Button
        Me.bVistaElectronica = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.EstaSemana = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SemanaProxima = New System.Windows.Forms.TextBox
        Me.En2Semanas = New System.Windows.Forms.TextBox
        Me.Total = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lvVersion = New System.Windows.Forms.ColumnHeader
        Me.Label42 = New System.Windows.Forms.Label
        Me.cbVersion = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.tbConceptos.SuspendLayout()
        Me.tpDetalle.SuspendLayout()
        Me.tpGlobal.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tbConceptos)
        Me.GroupBox1.Controls.Add(Me.EnMasSemanas)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.bBorrar)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.bImprimir)
        Me.GroupBox1.Controls.Add(Me.bLimpiaFiltro)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.bVistaTaller)
        Me.GroupBox1.Controls.Add(Me.bVistaElectronica)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.EstaSemana)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.SemanaProxima)
        Me.GroupBox1.Controls.Add(Me.En2Semanas)
        Me.GroupBox1.Controls.Add(Me.Total)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 776)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tbConceptos
        '
        Me.tbConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbConceptos.Controls.Add(Me.tpDetalle)
        Me.tbConceptos.Controls.Add(Me.tpGlobal)
        Me.tbConceptos.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbConceptos.Location = New System.Drawing.Point(12, 209)
        Me.tbConceptos.Name = "tbConceptos"
        Me.tbConceptos.SelectedIndex = 0
        Me.tbConceptos.Size = New System.Drawing.Size(1243, 516)
        Me.tbConceptos.TabIndex = 1
        '
        'tpDetalle
        '
        Me.tpDetalle.Controls.Add(Me.Label42)
        Me.tpDetalle.Controls.Add(Me.cbVersion)
        Me.tpDetalle.Controls.Add(Me.Observaciones)
        Me.tpDetalle.Controls.Add(Me.Label4)
        Me.tpDetalle.Controls.Add(Me.rbProd3)
        Me.tpDetalle.Controls.Add(Me.Label1)
        Me.tpDetalle.Controls.Add(Me.bLimpiarProv)
        Me.tpDetalle.Controls.Add(Me.Label14)
        Me.tpDetalle.Controls.Add(Me.rbProd2)
        Me.tpDetalle.Controls.Add(Me.cbcodArticuloProd)
        Me.tpDetalle.Controls.Add(Me.Label10)
        Me.tpDetalle.Controls.Add(Me.cbArticuloProd)
        Me.tpDetalle.Controls.Add(Me.rbProd1)
        Me.tpDetalle.Controls.Add(Me.bBuscarArticuloProd)
        Me.tpDetalle.Controls.Add(Me.lbUnidad)
        Me.tpDetalle.Controls.Add(Me.bVerArticuloProv)
        Me.tpDetalle.Controls.Add(Me.dtpFechaPrevista)
        Me.tpDetalle.Controls.Add(Me.Cantidad)
        Me.tpDetalle.Controls.Add(Me.lvConceptos)
        Me.tpDetalle.Controls.Add(Me.Label20)
        Me.tpDetalle.Location = New System.Drawing.Point(4, 27)
        Me.tpDetalle.Name = "tpDetalle"
        Me.tpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tpDetalle.Size = New System.Drawing.Size(1235, 485)
        Me.tpDetalle.TabIndex = 0
        Me.tpDetalle.Text = "DETALLE"
        Me.tpDetalle.UseVisualStyleBackColor = True
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(121, 45)
        Me.Observaciones.MaxLength = 200
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(1055, 23)
        Me.Observaciones.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(672, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "PRIORIDAD"
        '
        'rbProd3
        '
        Me.rbProd3.AutoSize = True
        Me.rbProd3.BackColor = System.Drawing.Color.LightGreen
        Me.rbProd3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProd3.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProd3.Location = New System.Drawing.Point(814, 16)
        Me.rbProd3.Name = "rbProd3"
        Me.rbProd3.Size = New System.Drawing.Size(33, 21)
        Me.rbProd3.TabIndex = 6
        Me.rbProd3.TabStop = True
        Me.rbProd3.Text = "3"
        Me.rbProd3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(21, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "ARTÍCULO"
        '
        'bLimpiarProv
        '
        Me.bLimpiarProv.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiarProv.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiarProv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiarProv.Location = New System.Drawing.Point(1200, 14)
        Me.bLimpiarProv.Name = "bLimpiarProv"
        Me.bLimpiarProv.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiarProv.TabIndex = 9
        Me.bLimpiarProv.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(5, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 17)
        Me.Label14.TabIndex = 179
        Me.Label14.Text = "OBSERVACIONES"
        '
        'rbProd2
        '
        Me.rbProd2.AutoSize = True
        Me.rbProd2.BackColor = System.Drawing.Color.NavajoWhite
        Me.rbProd2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProd2.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProd2.Location = New System.Drawing.Point(781, 16)
        Me.rbProd2.Name = "rbProd2"
        Me.rbProd2.Size = New System.Drawing.Size(33, 21)
        Me.rbProd2.TabIndex = 5
        Me.rbProd2.TabStop = True
        Me.rbProd2.Text = "2"
        Me.rbProd2.UseVisualStyleBackColor = False
        '
        'cbcodArticuloProd
        '
        Me.cbcodArticuloProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbcodArticuloProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbcodArticuloProd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbcodArticuloProd.FormattingEnabled = True
        Me.cbcodArticuloProd.Location = New System.Drawing.Point(121, 14)
        Me.cbcodArticuloProd.Name = "cbcodArticuloProd"
        Me.cbcodArticuloProd.Size = New System.Drawing.Size(127, 25)
        Me.cbcodArticuloProd.Sorted = True
        Me.cbcodArticuloProd.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(854, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 17)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "FECHA PREVISTA"
        '
        'cbArticuloProd
        '
        Me.cbArticuloProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbArticuloProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbArticuloProd.DropDownWidth = 447
        Me.cbArticuloProd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticuloProd.FormattingEnabled = True
        Me.cbArticuloProd.Location = New System.Drawing.Point(282, 14)
        Me.cbArticuloProd.Name = "cbArticuloProd"
        Me.cbArticuloProd.Size = New System.Drawing.Size(273, 25)
        Me.cbArticuloProd.TabIndex = 2
        '
        'rbProd1
        '
        Me.rbProd1.AutoSize = True
        Me.rbProd1.BackColor = System.Drawing.Color.Pink
        Me.rbProd1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProd1.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbProd1.Location = New System.Drawing.Point(751, 16)
        Me.rbProd1.Name = "rbProd1"
        Me.rbProd1.Size = New System.Drawing.Size(33, 21)
        Me.rbProd1.TabIndex = 4
        Me.rbProd1.TabStop = True
        Me.rbProd1.Text = "1"
        Me.rbProd1.UseVisualStyleBackColor = False
        '
        'bBuscarArticuloProd
        '
        Me.bBuscarArticuloProd.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticuloProd.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticuloProd.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticuloProd.Location = New System.Drawing.Point(252, 14)
        Me.bBuscarArticuloProd.Name = "bBuscarArticuloProd"
        Me.bBuscarArticuloProd.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticuloProd.TabIndex = 1
        Me.bBuscarArticuloProd.UseVisualStyleBackColor = True
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(1179, 18)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(16, 17)
        Me.lbUnidad.TabIndex = 174
        Me.lbUnidad.Text = "U"
        '
        'bVerArticuloProv
        '
        Me.bVerArticuloProv.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticuloProv.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticuloProv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticuloProv.Location = New System.Drawing.Point(639, 14)
        Me.bVerArticuloProv.Name = "bVerArticuloProv"
        Me.bVerArticuloProv.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticuloProv.TabIndex = 3
        Me.bVerArticuloProv.UseVisualStyleBackColor = True
        '
        'dtpFechaPrevista
        '
        Me.dtpFechaPrevista.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevista.Location = New System.Drawing.Point(966, 15)
        Me.dtpFechaPrevista.Name = "dtpFechaPrevista"
        Me.dtpFechaPrevista.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevista.TabIndex = 7
        Me.dtpFechaPrevista.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Cantidad
        '
        Me.Cantidad.BackColor = System.Drawing.SystemColors.Window
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Cantidad.Location = New System.Drawing.Point(1136, 15)
        Me.Cantidad.MaxLength = 15
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(41, 23)
        Me.Cantidad.TabIndex = 8
        Me.Cantidad.TabStop = False
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidProduccion, Me.lvidArticulo, Me.lvcodArticulo, Me.lvArticulo, Me.lvCantidad, Me.lvAcabados, Me.lvEstado, Me.lvCliente, Me.lvnumPedido, Me.lvFechaPedido, Me.lvFechaPrevista, Me.lvPrioridad, Me.lvVersion})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(7, 80)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(1220, 392)
        Me.lvConceptos.TabIndex = 12
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidProduccion
        '
        Me.lvidProduccion.Text = "idProduccion"
        Me.lvidProduccion.Width = 0
        '
        'lvidArticulo
        '
        Me.lvidArticulo.Text = "idArticulo"
        Me.lvidArticulo.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.DisplayIndex = 4
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 105
        '
        'lvArticulo
        '
        Me.lvArticulo.DisplayIndex = 5
        Me.lvArticulo.Text = "ARTICULO"
        Me.lvArticulo.Width = 282
        '
        'lvCantidad
        '
        Me.lvCantidad.DisplayIndex = 7
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvCantidad.Width = 81
        '
        'lvAcabados
        '
        Me.lvAcabados.DisplayIndex = 8
        Me.lvAcabados.Text = "ACABADOS"
        Me.lvAcabados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvAcabados.Width = 85
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 9
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 95
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 10
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 182
        '
        'lvnumPedido
        '
        Me.lvnumPedido.DisplayIndex = 2
        Me.lvnumPedido.Text = "PEDIDO"
        Me.lvnumPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvnumPedido.Width = 75
        '
        'lvFechaPedido
        '
        Me.lvFechaPedido.DisplayIndex = 3
        Me.lvFechaPedido.Text = "FECHA PEDIDO"
        Me.lvFechaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvFechaPedido.Width = 98
        '
        'lvFechaPrevista
        '
        Me.lvFechaPrevista.DisplayIndex = 11
        Me.lvFechaPrevista.Text = "FECHA ENTREGA"
        Me.lvFechaPrevista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvFechaPrevista.Width = 105
        '
        'lvPrioridad
        '
        Me.lvPrioridad.DisplayIndex = 12
        Me.lvPrioridad.Text = "PR."
        Me.lvPrioridad.Width = 29
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(1059, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 147
        Me.Label20.Text = "CANTIDAD"
        '
        'tpGlobal
        '
        Me.tpGlobal.Controls.Add(Me.lvConceptosGlobal)
        Me.tpGlobal.Location = New System.Drawing.Point(4, 27)
        Me.tpGlobal.Name = "tpGlobal"
        Me.tpGlobal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGlobal.Size = New System.Drawing.Size(1235, 485)
        Me.tpGlobal.TabIndex = 1
        Me.tpGlobal.Text = "GLOBAL"
        Me.tpGlobal.UseVisualStyleBackColor = True
        '
        'lvConceptosGlobal
        '
        Me.lvConceptosGlobal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptosGlobal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidArticuloB, Me.lvTipoB, Me.lvCodigoB, Me.lvArticuloB, Me.lvCantidadB, Me.lvEstaSemana, Me.lvSemanaProxima, Me.lvEn2Semanas, Me.lvMas2Semanas})
        Me.lvConceptosGlobal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptosGlobal.FullRowSelect = True
        Me.lvConceptosGlobal.GridLines = True
        Me.lvConceptosGlobal.HideSelection = False
        Me.lvConceptosGlobal.Location = New System.Drawing.Point(7, 26)
        Me.lvConceptosGlobal.MultiSelect = False
        Me.lvConceptosGlobal.Name = "lvConceptosGlobal"
        Me.lvConceptosGlobal.ShowItemToolTips = True
        Me.lvConceptosGlobal.Size = New System.Drawing.Size(1220, 500)
        Me.lvConceptosGlobal.TabIndex = 13
        Me.lvConceptosGlobal.UseCompatibleStateImageBehavior = False
        Me.lvConceptosGlobal.View = System.Windows.Forms.View.Details
        '
        'lvidArticuloB
        '
        Me.lvidArticuloB.Text = "idArticulo"
        Me.lvidArticuloB.Width = 0
        '
        'lvTipoB
        '
        Me.lvTipoB.Text = "TIPO"
        Me.lvTipoB.Width = 137
        '
        'lvCodigoB
        '
        Me.lvCodigoB.Text = "CÓDIGO"
        Me.lvCodigoB.Width = 158
        '
        'lvArticuloB
        '
        Me.lvArticuloB.Text = "ARTICULO"
        Me.lvArticuloB.Width = 295
        '
        'lvCantidadB
        '
        Me.lvCantidadB.Text = "CANTIDAD"
        Me.lvCantidadB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvCantidadB.Width = 80
        '
        'lvEstaSemana
        '
        Me.lvEstaSemana.Text = "ESTA SEMANA"
        Me.lvEstaSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvEstaSemana.Width = 95
        '
        'lvSemanaProxima
        '
        Me.lvSemanaProxima.Text = "SEMANA PROXIMA"
        Me.lvSemanaProxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvSemanaProxima.Width = 122
        '
        'lvEn2Semanas
        '
        Me.lvEn2Semanas.Text = "EN 2 SEMANAS"
        Me.lvEn2Semanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvEn2Semanas.Width = 104
        '
        'lvMas2Semanas
        '
        Me.lvMas2Semanas.Text = "MAS DE 2 SEMANAS"
        Me.lvMas2Semanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvMas2Semanas.Width = 137
        '
        'EnMasSemanas
        '
        Me.EnMasSemanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EnMasSemanas.BackColor = System.Drawing.SystemColors.Window
        Me.EnMasSemanas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnMasSemanas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EnMasSemanas.Location = New System.Drawing.Point(913, 742)
        Me.EnMasSemanas.MaxLength = 15
        Me.EnMasSemanas.Name = "EnMasSemanas"
        Me.EnMasSemanas.Size = New System.Drawing.Size(81, 23)
        Me.EnMasSemanas.TabIndex = 5
        Me.EnMasSemanas.TabStop = False
        Me.EnMasSemanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(781, 745)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 17)
        Me.Label22.TabIndex = 187
        Me.Label22.Text = "MAS DE 2 SEMANAS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.numPedido)
        Me.GroupBox2.Controls.Add(Me.BusquedaLibre)
        Me.GroupBox2.Controls.Add(Me.bTipos)
        Me.GroupBox2.Controls.Add(Me.ckVerInactivos)
        Me.GroupBox2.Controls.Add(Me.rbFiltro3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpFechaPedidoHasta)
        Me.GroupBox2.Controls.Add(Me.rbFiltro2)
        Me.GroupBox2.Controls.Add(Me.dtpFechaPedidoDesde)
        Me.GroupBox2.Controls.Add(Me.dtpFechaPrevistaHasta)
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbFiltro1)
        Me.GroupBox2.Controls.Add(Me.dtpFechaPrevistaDesde)
        Me.GroupBox2.Controls.Add(Me.cbEstado)
        Me.GroupBox2.Controls.Add(Me.Label57)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lbTipo)
        Me.GroupBox2.Controls.Add(Me.cbTipo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.cbCodCliente)
        Me.GroupBox2.Controls.Add(Me.cbCliente)
        Me.GroupBox2.Controls.Add(Me.bVerArticulo)
        Me.GroupBox2.Controls.Add(Me.bVerCliente)
        Me.GroupBox2.Controls.Add(Me.bBuscarCliente)
        Me.GroupBox2.Controls.Add(Me.cbCodArticulo)
        Me.GroupBox2.Controls.Add(Me.bBuscarArticulo)
        Me.GroupBox2.Controls.Add(Me.cbArticulo)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1243, 125)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'numPedido
        '
        Me.numPedido.BackColor = System.Drawing.SystemColors.Window
        Me.numPedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPedido.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numPedido.Location = New System.Drawing.Point(103, 90)
        Me.numPedido.MaxLength = 20
        Me.numPedido.Name = "numPedido"
        Me.numPedido.Size = New System.Drawing.Size(127, 23)
        Me.numPedido.TabIndex = 15
        '
        'BusquedaLibre
        '
        Me.BusquedaLibre.BackColor = System.Drawing.SystemColors.Window
        Me.BusquedaLibre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BusquedaLibre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BusquedaLibre.Location = New System.Drawing.Point(323, 90)
        Me.BusquedaLibre.MaxLength = 20
        Me.BusquedaLibre.Name = "BusquedaLibre"
        Me.BusquedaLibre.Size = New System.Drawing.Size(148, 23)
        Me.BusquedaLibre.TabIndex = 16
        '
        'bTipos
        '
        Me.bTipos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTipos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTipos.Location = New System.Drawing.Point(673, 89)
        Me.bTipos.Name = "bTipos"
        Me.bTipos.Size = New System.Drawing.Size(27, 25)
        Me.bTipos.TabIndex = 18
        Me.bTipos.Text = "...."
        Me.bTipos.UseVisualStyleBackColor = True
        '
        'ckVerInactivos
        '
        Me.ckVerInactivos.AutoSize = True
        Me.ckVerInactivos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerInactivos.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckVerInactivos.Location = New System.Drawing.Point(717, 91)
        Me.ckVerInactivos.Name = "ckVerInactivos"
        Me.ckVerInactivos.Size = New System.Drawing.Size(141, 21)
        Me.ckVerInactivos.TabIndex = 19
        Me.ckVerInactivos.Text = "VER PRODUCIDOS"
        Me.ckVerInactivos.UseVisualStyleBackColor = True
        '
        'rbFiltro3
        '
        Me.rbFiltro3.AutoSize = True
        Me.rbFiltro3.BackColor = System.Drawing.Color.LightGreen
        Me.rbFiltro3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltro3.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbFiltro3.Location = New System.Drawing.Point(856, 29)
        Me.rbFiltro3.Name = "rbFiltro3"
        Me.rbFiltro3.Size = New System.Drawing.Size(33, 21)
        Me.rbFiltro3.TabIndex = 6
        Me.rbFiltro3.TabStop = True
        Me.rbFiltro3.Text = "3"
        Me.rbFiltro3.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(866, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 17)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "FECHA ENTREGA ENTRE"
        '
        'dtpFechaPedidoHasta
        '
        Me.dtpFechaPedidoHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPedidoHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPedidoHasta.Location = New System.Drawing.Point(1143, 59)
        Me.dtpFechaPedidoHasta.Name = "dtpFechaPedidoHasta"
        Me.dtpFechaPedidoHasta.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPedidoHasta.TabIndex = 14
        Me.dtpFechaPedidoHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'rbFiltro2
        '
        Me.rbFiltro2.AutoSize = True
        Me.rbFiltro2.BackColor = System.Drawing.Color.NavajoWhite
        Me.rbFiltro2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltro2.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbFiltro2.Location = New System.Drawing.Point(823, 29)
        Me.rbFiltro2.Name = "rbFiltro2"
        Me.rbFiltro2.Size = New System.Drawing.Size(33, 21)
        Me.rbFiltro2.TabIndex = 5
        Me.rbFiltro2.TabStop = True
        Me.rbFiltro2.Text = "2"
        Me.rbFiltro2.UseVisualStyleBackColor = False
        '
        'dtpFechaPedidoDesde
        '
        Me.dtpFechaPedidoDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPedidoDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPedidoDesde.Location = New System.Drawing.Point(1022, 59)
        Me.dtpFechaPedidoDesde.Name = "dtpFechaPedidoDesde"
        Me.dtpFechaPedidoDesde.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPedidoDesde.TabIndex = 13
        Me.dtpFechaPedidoDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'dtpFechaPrevistaHasta
        '
        Me.dtpFechaPrevistaHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevistaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevistaHasta.Location = New System.Drawing.Point(1143, 90)
        Me.dtpFechaPrevistaHasta.Name = "dtpFechaPrevistaHasta"
        Me.dtpFechaPrevistaHasta.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevistaHasta.TabIndex = 21
        Me.dtpFechaPrevistaHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.rbTodos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbTodos.Location = New System.Drawing.Point(889, 29)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(67, 21)
        Me.rbTodos.TabIndex = 7
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "TODAS"
        Me.rbTodos.UseVisualStyleBackColor = False
        '
        'rbFiltro1
        '
        Me.rbFiltro1.AutoSize = True
        Me.rbFiltro1.BackColor = System.Drawing.Color.Pink
        Me.rbFiltro1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltro1.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbFiltro1.Location = New System.Drawing.Point(794, 29)
        Me.rbFiltro1.Name = "rbFiltro1"
        Me.rbFiltro1.Size = New System.Drawing.Size(33, 21)
        Me.rbFiltro1.TabIndex = 4
        Me.rbFiltro1.TabStop = True
        Me.rbFiltro1.Text = "1"
        Me.rbFiltro1.UseVisualStyleBackColor = False
        '
        'dtpFechaPrevistaDesde
        '
        Me.dtpFechaPrevistaDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPrevistaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPrevistaDesde.Location = New System.Drawing.Point(1022, 90)
        Me.dtpFechaPrevistaDesde.Name = "dtpFechaPrevistaDesde"
        Me.dtpFechaPrevistaDesde.Size = New System.Drawing.Size(90, 23)
        Me.dtpFechaPrevistaDesde.TabIndex = 20
        Me.dtpFechaPrevistaDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(1062, 27)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(171, 25)
        Me.cbEstado.TabIndex = 8
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label57.Location = New System.Drawing.Point(1000, 31)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(56, 17)
        Me.Label57.TabIndex = 115
        Me.Label57.Text = "ESTADO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(866, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 17)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "FECHA PEDIDO ENTRE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(714, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 17)
        Me.Label6.TabIndex = 179
        Me.Label6.Text = "PRIORIDAD"
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbTipo.Location = New System.Drawing.Point(477, 93)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(35, 17)
        Me.lbTipo.TabIndex = 179
        Me.lbTipo.Text = "TIPO"
        '
        'cbTipo
        '
        Me.cbTipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(516, 89)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(140, 25)
        Me.cbTipo.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(1121, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 17)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Y"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(1121, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 17)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Y"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(243, 93)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 17)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "BÚSQUEDA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(19, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 17)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "Nº PEDIDO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(19, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "CLIENTE"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(19, 63)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 17)
        Me.Label39.TabIndex = 179
        Me.Label39.Text = "ARTÍCULO"
        '
        'cbCodCliente
        '
        Me.cbCodCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodCliente.FormattingEnabled = True
        Me.cbCodCliente.Location = New System.Drawing.Point(103, 27)
        Me.cbCodCliente.Name = "cbCodCliente"
        Me.cbCodCliente.Size = New System.Drawing.Size(127, 25)
        Me.cbCodCliente.Sorted = True
        Me.cbCodCliente.TabIndex = 0
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(269, 27)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(387, 25)
        Me.cbCliente.TabIndex = 2
        '
        'bVerArticulo
        '
        Me.bVerArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerArticulo.Location = New System.Drawing.Point(673, 58)
        Me.bVerArticulo.Name = "bVerArticulo"
        Me.bVerArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bVerArticulo.TabIndex = 12
        Me.bVerArticulo.UseVisualStyleBackColor = True
        '
        'bVerCliente
        '
        Me.bVerCliente.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVerCliente.Image = Global.ERP_SUGAR.My.Resources.Resources.formulario
        Me.bVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVerCliente.Location = New System.Drawing.Point(673, 27)
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
        Me.bBuscarCliente.Location = New System.Drawing.Point(236, 27)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarCliente.TabIndex = 1
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(103, 58)
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(127, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 9
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticulo.Image = Global.ERP_SUGAR.My.Resources.Resources.search16
        Me.bBuscarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticulo.Location = New System.Drawing.Point(236, 58)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticulo.TabIndex = 10
        Me.bBuscarArticulo.UseVisualStyleBackColor = True
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownWidth = 447
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(269, 58)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(387, 25)
        Me.cbArticulo.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(551, 745)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 17)
        Me.Label16.TabIndex = 186
        Me.Label16.Text = "EN 2 SEMANAS"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(297, 745)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 17)
        Me.Label17.TabIndex = 185
        Me.Label17.Text = "SEMANA PRÓXIMA"
        '
        'bBorrar
        '
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(760, 23)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(104, 50)
        Me.bBorrar.TabIndex = 10
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(266, 745)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 17)
        Me.Label21.TabIndex = 184
        Me.Label21.Text = "U"
        '
        'bImprimir
        '
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(635, 23)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(104, 50)
        Me.bImprimir.TabIndex = 9
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bLimpiaFiltro
        '
        Me.bLimpiaFiltro.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiaFiltro.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiaFiltro.Location = New System.Drawing.Point(510, 23)
        Me.bLimpiaFiltro.Name = "bLimpiaFiltro"
        Me.bLimpiaFiltro.Size = New System.Drawing.Size(104, 50)
        Me.bLimpiaFiltro.TabIndex = 8
        Me.bLimpiaFiltro.Text = "LIMPIAR"
        Me.bLimpiaFiltro.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(509, 745)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 17)
        Me.Label18.TabIndex = 184
        Me.Label18.Text = "U"
        '
        'bVistaTaller
        '
        Me.bVistaTaller.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVistaTaller.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVistaTaller.Location = New System.Drawing.Point(885, 23)
        Me.bVistaTaller.Name = "bVistaTaller"
        Me.bVistaTaller.Size = New System.Drawing.Size(104, 50)
        Me.bVistaTaller.TabIndex = 11
        Me.bVistaTaller.Text = "VISTA TALLER"
        Me.bVistaTaller.UseVisualStyleBackColor = True
        '
        'bVistaElectronica
        '
        Me.bVistaElectronica.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVistaElectronica.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bVistaElectronica.Location = New System.Drawing.Point(1010, 23)
        Me.bVistaElectronica.Name = "bVistaElectronica"
        Me.bVistaElectronica.Size = New System.Drawing.Size(104, 50)
        Me.bVistaElectronica.TabIndex = 12
        Me.bVistaElectronica.Text = "VISTA ELECTRÓNICA"
        Me.bVistaElectronica.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(385, 23)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(104, 50)
        Me.bGuardar.TabIndex = 7
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(997, 745)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 17)
        Me.Label23.TabIndex = 184
        Me.Label23.Text = "U"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(738, 745)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 17)
        Me.Label15.TabIndex = 184
        Me.Label15.Text = "U"
        '
        'bSalir
        '
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1135, 23)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(104, 50)
        Me.bSalir.TabIndex = 13
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(22, 745)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(158, 17)
        Me.Label19.TabIndex = 183
        Me.Label19.Text = "ENTREGAS ESTA SEMANA"
        '
        'EstaSemana
        '
        Me.EstaSemana.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EstaSemana.BackColor = System.Drawing.SystemColors.Window
        Me.EstaSemana.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstaSemana.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstaSemana.Location = New System.Drawing.Point(182, 742)
        Me.EstaSemana.MaxLength = 15
        Me.EstaSemana.Name = "EstaSemana"
        Me.EstaSemana.Size = New System.Drawing.Size(81, 23)
        Me.EstaSemana.TabIndex = 2
        Me.EstaSemana.TabStop = False
        Me.EstaSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'SemanaProxima
        '
        Me.SemanaProxima.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SemanaProxima.BackColor = System.Drawing.SystemColors.Window
        Me.SemanaProxima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SemanaProxima.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SemanaProxima.Location = New System.Drawing.Point(422, 742)
        Me.SemanaProxima.MaxLength = 15
        Me.SemanaProxima.Name = "SemanaProxima"
        Me.SemanaProxima.Size = New System.Drawing.Size(81, 23)
        Me.SemanaProxima.TabIndex = 3
        Me.SemanaProxima.TabStop = False
        Me.SemanaProxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'En2Semanas
        '
        Me.En2Semanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.En2Semanas.BackColor = System.Drawing.SystemColors.Window
        Me.En2Semanas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.En2Semanas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.En2Semanas.Location = New System.Drawing.Point(654, 742)
        Me.En2Semanas.MaxLength = 15
        Me.En2Semanas.Name = "En2Semanas"
        Me.En2Semanas.Size = New System.Drawing.Size(81, 23)
        Me.En2Semanas.TabIndex = 4
        Me.En2Semanas.TabStop = False
        Me.En2Semanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(1143, 742)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(81, 23)
        Me.Total.TabIndex = 6
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(1095, 745)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "TOTAL"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(1227, 745)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 17)
        Me.Label11.TabIndex = 174
        Me.Label11.Text = "U"
        '
        'lvVersion
        '
        Me.lvVersion.DisplayIndex = 6
        Me.lvVersion.Text = "VERSIÓN"
        Me.lvVersion.Width = 64
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(559, 18)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(21, 17)
        Me.Label42.TabIndex = 184
        Me.Label42.Text = "V."
        '
        'cbVersion
        '
        Me.cbVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbVersion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVersion.FormattingEnabled = True
        Me.cbVersion.Location = New System.Drawing.Point(581, 14)
        Me.cbVersion.Name = "cbVersion"
        Me.cbVersion.Size = New System.Drawing.Size(52, 25)
        Me.cbVersion.Sorted = True
        Me.cbVersion.TabIndex = 183
        '
        'GestionProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 778)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE PRODUCCIÓN"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbConceptos.ResumeLayout(False)
        Me.tpDetalle.ResumeLayout(False)
        Me.tpDetalle.PerformLayout()
        Me.tpGlobal.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bLimpiarProv As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidProduccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPrevista As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents bBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents bVerArticuloProv As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaPedidoDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPrevistaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCodCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents bVerCliente As System.Windows.Forms.Button
    Friend WithEvents bBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents bBuscarArticuloProd As System.Windows.Forms.Button
    Friend WithEvents dtpFechaPedidoHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaPrevistaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents bVerArticulo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bLimpiaFiltro As System.Windows.Forms.Button
    Friend WithEvents rbProd3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbProd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbProd1 As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbArticuloProd As System.Windows.Forms.ComboBox
    Friend WithEvents cbcodArticuloProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbFiltro3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltro2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltro1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents lvPrioridad As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckVerInactivos As System.Windows.Forms.CheckBox
    Friend WithEvents bTipos As System.Windows.Forms.Button
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents EstaSemana As System.Windows.Forms.TextBox
    Friend WithEvents SemanaProxima As System.Windows.Forms.TextBox
    Friend WithEvents En2Semanas As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents EnMasSemanas As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lvidArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAcabados As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConceptosGlobal As System.Windows.Forms.ListView
    Friend WithEvents lvidArticuloB As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCodigoB As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloB As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidadB As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstaSemana As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSemanaProxima As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEn2Semanas As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMas2Semanas As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbConceptos As System.Windows.Forms.TabControl
    Friend WithEvents tpDetalle As System.Windows.Forms.TabPage
    Friend WithEvents tpGlobal As System.Windows.Forms.TabPage
    Friend WithEvents lvTipoB As System.Windows.Forms.ColumnHeader
    Friend WithEvents bVistaTaller As System.Windows.Forms.Button
    Friend WithEvents bVistaElectronica As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents BusquedaLibre As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numPedido As System.Windows.Forms.TextBox
    Friend WithEvents lvVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbVersion As System.Windows.Forms.ComboBox
End Class
