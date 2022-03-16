<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionEquiposProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEquiposProduccion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbSeleccionados = New System.Windows.Forms.Label
        Me.PBCarga = New System.Windows.Forms.ProgressBar
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpGlobal = New System.Windows.Forms.TabPage
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.codArticulo = New System.Windows.Forms.TextBox
        Me.ckSeleccion = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lbArticulo = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lvEquipos = New System.Windows.Forms.ListView
        Me.lvCK = New System.Windows.Forms.ColumnHeader
        Me.lvidEquipo = New System.Windows.Forms.ColumnHeader
        Me.lvnumSerie = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoTaller = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoElectronica = New System.Windows.Forms.ColumnHeader
        Me.lvCliente = New System.Windows.Forms.ColumnHeader
        Me.lvnumPedido = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPedido = New System.Windows.Forms.ColumnHeader
        Me.lvFechaPrevista = New System.Windows.Forms.ColumnHeader
        Me.lvDias = New System.Windows.Forms.ColumnHeader
        Me.lvPrioridad = New System.Windows.Forms.ColumnHeader
        Me.lvEtiqueta = New System.Windows.Forms.ColumnHeader
        Me.lvidEstado = New System.Windows.Forms.ColumnHeader
        Me.lvidEstadoGT = New System.Windows.Forms.ColumnHeader
        Me.lvidEstadoGE = New System.Windows.Forms.ColumnHeader
        Me.lvSeleccionado = New System.Windows.Forms.ColumnHeader
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.EstaSemana = New System.Windows.Forms.TextBox
        Me.Articulo = New System.Windows.Forms.TextBox
        Me.SemanaProxima = New System.Windows.Forms.TextBox
        Me.En2Semanas = New System.Windows.Forms.TextBox
        Me.EnMasSemanas = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Total = New System.Windows.Forms.TextBox
        Me.tpTaller = New System.Windows.Forms.TabPage
        Me.ckSeleccionTaller = New System.Windows.Forms.CheckBox
        Me.lvTaller = New System.Windows.Forms.ListView
        Me.lvckT = New System.Windows.Forms.ColumnHeader
        Me.lvidConceptoT = New System.Windows.Forms.ColumnHeader
        Me.lvidEquipoT = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloT = New System.Windows.Forms.ColumnHeader
        Me.lvArticuloT = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoT = New System.Windows.Forms.ColumnHeader
        Me.lvClienteT = New System.Windows.Forms.ColumnHeader
        Me.lvPedidoT = New System.Windows.Forms.ColumnHeader
        Me.lvFechaT = New System.Windows.Forms.ColumnHeader
        Me.lvEntregaT = New System.Windows.Forms.ColumnHeader
        Me.lvDiasT = New System.Windows.Forms.ColumnHeader
        Me.lvPrioridadT = New System.Windows.Forms.ColumnHeader
        Me.lvEtiquetaT = New System.Windows.Forms.ColumnHeader
        Me.lvidEstadoT = New System.Windows.Forms.ColumnHeader
        Me.TotalT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.EstaSemanaT = New System.Windows.Forms.TextBox
        Me.SemanaProximaT = New System.Windows.Forms.TextBox
        Me.En2SemanasT = New System.Windows.Forms.TextBox
        Me.EnMasSemanasT = New System.Windows.Forms.TextBox
        Me.tpElectronica = New System.Windows.Forms.TabPage
        Me.ckSeleccionElectronica = New System.Windows.Forms.CheckBox
        Me.lvElectronica = New System.Windows.Forms.ListView
        Me.lvckE = New System.Windows.Forms.ColumnHeader
        Me.ividConceptoE = New System.Windows.Forms.ColumnHeader
        Me.lvidEquipoE = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticuloE = New System.Windows.Forms.ColumnHeader
        Me.lvArticuloE = New System.Windows.Forms.ColumnHeader
        Me.lvEstadoEE = New System.Windows.Forms.ColumnHeader
        Me.lvClienteE = New System.Windows.Forms.ColumnHeader
        Me.lvPedidoE = New System.Windows.Forms.ColumnHeader
        Me.lvFechaE = New System.Windows.Forms.ColumnHeader
        Me.lvEntregaE = New System.Windows.Forms.ColumnHeader
        Me.lvDiasE = New System.Windows.Forms.ColumnHeader
        Me.lvPrioridadE = New System.Windows.Forms.ColumnHeader
        Me.lvEtiquetaE = New System.Windows.Forms.ColumnHeader
        Me.lvidEstadoE = New System.Windows.Forms.ColumnHeader
        Me.TotalE = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.EstaSemanaE = New System.Windows.Forms.TextBox
        Me.SemanaProximaE = New System.Windows.Forms.TextBox
        Me.En2SemanasE = New System.Windows.Forms.TextBox
        Me.EnMasSemanasE = New System.Windows.Forms.TextBox
        Me.bAcabadoElectronica = New System.Windows.Forms.Button
        Me.bAcabadoTaller = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lvVersion = New System.Windows.Forms.ColumnHeader
        Me.lvVersionT = New System.Windows.Forms.ColumnHeader
        Me.lvVersionE = New System.Windows.Forms.ColumnHeader
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpGlobal.SuspendLayout()
        Me.tpTaller.SuspendLayout()
        Me.tpElectronica.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbSeleccionados)
        Me.GroupBox1.Controls.Add(Me.PBCarga)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.bAcabadoElectronica)
        Me.GroupBox1.Controls.Add(Me.bAcabadoTaller)
        Me.GroupBox1.Controls.Add(Me.bGuardar)
        Me.GroupBox1.Controls.Add(Me.bSalir)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1219, 905)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbSeleccionados
        '
        Me.lbSeleccionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbSeleccionados.AutoSize = True
        Me.lbSeleccionados.BackColor = System.Drawing.SystemColors.Control
        Me.lbSeleccionados.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSeleccionados.Location = New System.Drawing.Point(12, 876)
        Me.lbSeleccionados.Name = "lbSeleccionados"
        Me.lbSeleccionados.Size = New System.Drawing.Size(137, 19)
        Me.lbSeleccionados.TabIndex = 95
        Me.lbSeleccionados.Text = "SELECCIONADOS"
        Me.lbSeleccionados.Visible = False
        '
        'PBCarga
        '
        Me.PBCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBCarga.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PBCarga.Location = New System.Drawing.Point(12, 82)
        Me.PBCarga.Name = "PBCarga"
        Me.PBCarga.Size = New System.Drawing.Size(1201, 18)
        Me.PBCarga.TabIndex = 94
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpGlobal)
        Me.TabControl1.Controls.Add(Me.tpTaller)
        Me.TabControl1.Controls.Add(Me.tpElectronica)
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 103)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1201, 770)
        Me.TabControl1.TabIndex = 0
        '
        'tpGlobal
        '
        Me.tpGlobal.Controls.Add(Me.bLimpiar)
        Me.tpGlobal.Controls.Add(Me.codArticulo)
        Me.tpGlobal.Controls.Add(Me.ckSeleccion)
        Me.tpGlobal.Controls.Add(Me.Label14)
        Me.tpGlobal.Controls.Add(Me.Label21)
        Me.tpGlobal.Controls.Add(Me.lbArticulo)
        Me.tpGlobal.Controls.Add(Me.Label18)
        Me.tpGlobal.Controls.Add(Me.Label23)
        Me.tpGlobal.Controls.Add(Me.Label15)
        Me.tpGlobal.Controls.Add(Me.lvEquipos)
        Me.tpGlobal.Controls.Add(Me.Label16)
        Me.tpGlobal.Controls.Add(Me.Label11)
        Me.tpGlobal.Controls.Add(Me.Label17)
        Me.tpGlobal.Controls.Add(Me.Observaciones)
        Me.tpGlobal.Controls.Add(Me.Label19)
        Me.tpGlobal.Controls.Add(Me.EstaSemana)
        Me.tpGlobal.Controls.Add(Me.Articulo)
        Me.tpGlobal.Controls.Add(Me.SemanaProxima)
        Me.tpGlobal.Controls.Add(Me.En2Semanas)
        Me.tpGlobal.Controls.Add(Me.EnMasSemanas)
        Me.tpGlobal.Controls.Add(Me.Label22)
        Me.tpGlobal.Controls.Add(Me.Label5)
        Me.tpGlobal.Controls.Add(Me.Total)
        Me.tpGlobal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpGlobal.Location = New System.Drawing.Point(4, 26)
        Me.tpGlobal.Name = "tpGlobal"
        Me.tpGlobal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGlobal.Size = New System.Drawing.Size(1193, 740)
        Me.tpGlobal.TabIndex = 0
        Me.tpGlobal.Text = "GLOBAL"
        Me.tpGlobal.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = Global.ERP_SUGAR.My.Resources.Resources.page_white
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1143, 18)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 2
        Me.bLimpiar.UseVisualStyleBackColor = True
        Me.bLimpiar.Visible = False
        '
        'codArticulo
        '
        Me.codArticulo.BackColor = System.Drawing.SystemColors.Window
        Me.codArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codArticulo.Location = New System.Drawing.Point(127, 18)
        Me.codArticulo.MaxLength = 150
        Me.codArticulo.Name = "codArticulo"
        Me.codArticulo.ReadOnly = True
        Me.codArticulo.Size = New System.Drawing.Size(221, 23)
        Me.codArticulo.TabIndex = 0
        '
        'ckSeleccion
        '
        Me.ckSeleccion.AutoSize = True
        Me.ckSeleccion.Location = New System.Drawing.Point(19, 95)
        Me.ckSeleccion.Name = "ckSeleccion"
        Me.ckSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccion.TabIndex = 4
        Me.ckSeleccion.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(13, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 17)
        Me.Label14.TabIndex = 179
        Me.Label14.Text = "OBSERVACIONES"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(245, 912)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 17)
        Me.Label21.TabIndex = 184
        Me.Label21.Text = "U"
        '
        'lbArticulo
        '
        Me.lbArticulo.AutoSize = True
        Me.lbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArticulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbArticulo.Location = New System.Drawing.Point(13, 21)
        Me.lbArticulo.Name = "lbArticulo"
        Me.lbArticulo.Size = New System.Drawing.Size(69, 17)
        Me.lbArticulo.TabIndex = 179
        Me.lbArticulo.Text = "ARTÍCULO"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(474, 912)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 17)
        Me.Label18.TabIndex = 184
        Me.Label18.Text = "U"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(929, 912)
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
        Me.Label15.Location = New System.Drawing.Point(687, 912)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 17)
        Me.Label15.TabIndex = 184
        Me.Label15.Text = "U"
        '
        'lvEquipos
        '
        Me.lvEquipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEquipos.CheckBoxes = True
        Me.lvEquipos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvCK, Me.lvidEquipo, Me.lvnumSerie, Me.lvcodArticulo, Me.lvArticulo, Me.lvEstadoTaller, Me.lvEstadoElectronica, Me.lvCliente, Me.lvnumPedido, Me.lvFechaPedido, Me.lvFechaPrevista, Me.lvDias, Me.lvPrioridad, Me.lvEtiqueta, Me.lvidEstado, Me.lvidEstadoGT, Me.lvidEstadoGE, Me.lvSeleccionado, Me.lvVersion})
        Me.lvEquipos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEquipos.FullRowSelect = True
        Me.lvEquipos.GridLines = True
        Me.lvEquipos.HideSelection = False
        Me.lvEquipos.Location = New System.Drawing.Point(12, 87)
        Me.lvEquipos.Name = "lvEquipos"
        Me.lvEquipos.ShowItemToolTips = True
        Me.lvEquipos.Size = New System.Drawing.Size(1171, 633)
        Me.lvEquipos.TabIndex = 5
        Me.lvEquipos.UseCompatibleStateImageBehavior = False
        Me.lvEquipos.View = System.Windows.Forms.View.Details
        '
        'lvCK
        '
        Me.lvCK.Text = ""
        Me.lvCK.Width = 22
        '
        'lvidEquipo
        '
        Me.lvidEquipo.Text = "ID"
        Me.lvidEquipo.Width = 50
        '
        'lvnumSerie
        '
        Me.lvnumSerie.Text = "Nº SERIE"
        Me.lvnumSerie.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 142
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTICULO"
        Me.lvArticulo.Width = 266
        '
        'lvEstadoTaller
        '
        Me.lvEstadoTaller.DisplayIndex = 6
        Me.lvEstadoTaller.Text = "TALLER"
        Me.lvEstadoTaller.Width = 103
        '
        'lvEstadoElectronica
        '
        Me.lvEstadoElectronica.DisplayIndex = 7
        Me.lvEstadoElectronica.Text = "ELECTRÓNICA"
        Me.lvEstadoElectronica.Width = 94
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 8
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 65
        '
        'lvnumPedido
        '
        Me.lvnumPedido.DisplayIndex = 9
        Me.lvnumPedido.Text = "PEDIDO"
        Me.lvnumPedido.Width = 68
        '
        'lvFechaPedido
        '
        Me.lvFechaPedido.DisplayIndex = 10
        Me.lvFechaPedido.Text = "FECHA PEDIDO"
        Me.lvFechaPedido.Width = 100
        '
        'lvFechaPrevista
        '
        Me.lvFechaPrevista.DisplayIndex = 11
        Me.lvFechaPrevista.Text = "FECHA ENTREGA"
        Me.lvFechaPrevista.Width = 0
        '
        'lvDias
        '
        Me.lvDias.DisplayIndex = 12
        Me.lvDias.Text = "DÍAS"
        Me.lvDias.Width = 40
        '
        'lvPrioridad
        '
        Me.lvPrioridad.DisplayIndex = 13
        Me.lvPrioridad.Text = "PR."
        Me.lvPrioridad.Width = 29
        '
        'lvEtiqueta
        '
        Me.lvEtiqueta.DisplayIndex = 14
        Me.lvEtiqueta.Text = "ETIQUETA"
        Me.lvEtiqueta.Width = 101
        '
        'lvidEstado
        '
        Me.lvidEstado.DisplayIndex = 15
        Me.lvidEstado.Text = "idEstado"
        Me.lvidEstado.Width = 0
        '
        'lvidEstadoGT
        '
        Me.lvidEstadoGT.DisplayIndex = 16
        Me.lvidEstadoGT.Text = "idEstadoT"
        Me.lvidEstadoGT.Width = 0
        '
        'lvidEstadoGE
        '
        Me.lvidEstadoGE.DisplayIndex = 17
        Me.lvidEstadoGE.Text = "idEstadoE"
        Me.lvidEstadoGE.Width = 0
        '
        'lvSeleccionado
        '
        Me.lvSeleccionado.DisplayIndex = 18
        Me.lvSeleccionado.Text = ""
        Me.lvSeleccionado.Width = 0
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(515, 703)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 17)
        Me.Label16.TabIndex = 183
        Me.Label16.Text = "EN 2 SEMANAS"
        Me.Label16.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(1134, 703)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 17)
        Me.Label11.TabIndex = 174
        Me.Label11.Text = "U"
        Me.Label11.Visible = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(282, 703)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 17)
        Me.Label17.TabIndex = 183
        Me.Label17.Text = "SEMANA PRÓXIMA"
        Me.Label17.Visible = False
        '
        'Observaciones
        '
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.Location = New System.Drawing.Point(127, 52)
        Me.Observaciones.MaxLength = 150
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(1004, 23)
        Me.Observaciones.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(20, 703)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(158, 17)
        Me.Label19.TabIndex = 183
        Me.Label19.Text = "ENTREGAS ESTA SEMANA"
        Me.Label19.Visible = False
        '
        'EstaSemana
        '
        Me.EstaSemana.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EstaSemana.BackColor = System.Drawing.SystemColors.Window
        Me.EstaSemana.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstaSemana.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstaSemana.Location = New System.Drawing.Point(184, 700)
        Me.EstaSemana.MaxLength = 15
        Me.EstaSemana.Name = "EstaSemana"
        Me.EstaSemana.Size = New System.Drawing.Size(70, 23)
        Me.EstaSemana.TabIndex = 5
        Me.EstaSemana.TabStop = False
        Me.EstaSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EstaSemana.Visible = False
        '
        'Articulo
        '
        Me.Articulo.BackColor = System.Drawing.SystemColors.Window
        Me.Articulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Articulo.Location = New System.Drawing.Point(360, 18)
        Me.Articulo.MaxLength = 150
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Size = New System.Drawing.Size(771, 23)
        Me.Articulo.TabIndex = 1
        '
        'SemanaProxima
        '
        Me.SemanaProxima.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SemanaProxima.BackColor = System.Drawing.SystemColors.Window
        Me.SemanaProxima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SemanaProxima.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SemanaProxima.Location = New System.Drawing.Point(411, 700)
        Me.SemanaProxima.MaxLength = 15
        Me.SemanaProxima.Name = "SemanaProxima"
        Me.SemanaProxima.Size = New System.Drawing.Size(70, 23)
        Me.SemanaProxima.TabIndex = 6
        Me.SemanaProxima.TabStop = False
        Me.SemanaProxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.SemanaProxima.Visible = False
        '
        'En2Semanas
        '
        Me.En2Semanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.En2Semanas.BackColor = System.Drawing.SystemColors.Window
        Me.En2Semanas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.En2Semanas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.En2Semanas.Location = New System.Drawing.Point(622, 700)
        Me.En2Semanas.MaxLength = 15
        Me.En2Semanas.Name = "En2Semanas"
        Me.En2Semanas.Size = New System.Drawing.Size(70, 23)
        Me.En2Semanas.TabIndex = 7
        Me.En2Semanas.TabStop = False
        Me.En2Semanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.En2Semanas.Visible = False
        '
        'EnMasSemanas
        '
        Me.EnMasSemanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EnMasSemanas.BackColor = System.Drawing.SystemColors.Window
        Me.EnMasSemanas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnMasSemanas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EnMasSemanas.Location = New System.Drawing.Point(870, 700)
        Me.EnMasSemanas.MaxLength = 15
        Me.EnMasSemanas.Name = "EnMasSemanas"
        Me.EnMasSemanas.Size = New System.Drawing.Size(70, 23)
        Me.EnMasSemanas.TabIndex = 8
        Me.EnMasSemanas.TabStop = False
        Me.EnMasSemanas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EnMasSemanas.Visible = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(736, 703)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(128, 17)
        Me.Label22.TabIndex = 183
        Me.Label22.Text = "MAS DE 2 SEMANAS"
        Me.Label22.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(1009, 703)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "TOTAL"
        Me.Label5.Visible = False
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(1058, 700)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(70, 23)
        Me.Total.TabIndex = 9
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Total.Visible = False
        '
        'tpTaller
        '
        Me.tpTaller.Controls.Add(Me.ckSeleccionTaller)
        Me.tpTaller.Controls.Add(Me.lvTaller)
        Me.tpTaller.Controls.Add(Me.TotalT)
        Me.tpTaller.Controls.Add(Me.Label1)
        Me.tpTaller.Controls.Add(Me.Label2)
        Me.tpTaller.Controls.Add(Me.Label3)
        Me.tpTaller.Controls.Add(Me.Label4)
        Me.tpTaller.Controls.Add(Me.Label6)
        Me.tpTaller.Controls.Add(Me.Label7)
        Me.tpTaller.Controls.Add(Me.EstaSemanaT)
        Me.tpTaller.Controls.Add(Me.SemanaProximaT)
        Me.tpTaller.Controls.Add(Me.En2SemanasT)
        Me.tpTaller.Controls.Add(Me.EnMasSemanasT)
        Me.tpTaller.Location = New System.Drawing.Point(4, 26)
        Me.tpTaller.Name = "tpTaller"
        Me.tpTaller.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTaller.Size = New System.Drawing.Size(1193, 740)
        Me.tpTaller.TabIndex = 1
        Me.tpTaller.Text = "TALLER"
        Me.tpTaller.UseVisualStyleBackColor = True
        '
        'ckSeleccionTaller
        '
        Me.ckSeleccionTaller.AutoSize = True
        Me.ckSeleccionTaller.Location = New System.Drawing.Point(17, 25)
        Me.ckSeleccionTaller.Name = "ckSeleccionTaller"
        Me.ckSeleccionTaller.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccionTaller.TabIndex = 0
        Me.ckSeleccionTaller.UseVisualStyleBackColor = True
        '
        'lvTaller
        '
        Me.lvTaller.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTaller.CheckBoxes = True
        Me.lvTaller.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvckT, Me.lvidConceptoT, Me.lvidEquipoT, Me.lvcodArticuloT, Me.lvArticuloT, Me.lvEstadoT, Me.lvClienteT, Me.lvPedidoT, Me.lvFechaT, Me.lvEntregaT, Me.lvDiasT, Me.lvPrioridadT, Me.lvEtiquetaT, Me.lvidEstadoT, Me.lvVersionT})
        Me.lvTaller.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTaller.FullRowSelect = True
        Me.lvTaller.GridLines = True
        Me.lvTaller.HideSelection = False
        Me.lvTaller.Location = New System.Drawing.Point(11, 19)
        Me.lvTaller.Name = "lvTaller"
        Me.lvTaller.ShowItemToolTips = True
        Me.lvTaller.Size = New System.Drawing.Size(1171, 697)
        Me.lvTaller.TabIndex = 1
        Me.lvTaller.UseCompatibleStateImageBehavior = False
        Me.lvTaller.View = System.Windows.Forms.View.Details
        '
        'lvckT
        '
        Me.lvckT.Text = ""
        Me.lvckT.Width = 22
        '
        'lvidConceptoT
        '
        Me.lvidConceptoT.Text = "idConcepto"
        Me.lvidConceptoT.Width = 0
        '
        'lvidEquipoT
        '
        Me.lvidEquipoT.Text = "ID"
        Me.lvidEquipoT.Width = 50
        '
        'lvcodArticuloT
        '
        Me.lvcodArticuloT.Text = "CÓDIGO"
        Me.lvcodArticuloT.Width = 142
        '
        'lvArticuloT
        '
        Me.lvArticuloT.Text = "ARTICULO"
        Me.lvArticuloT.Width = 347
        '
        'lvEstadoT
        '
        Me.lvEstadoT.DisplayIndex = 6
        Me.lvEstadoT.Text = "ESTADO"
        Me.lvEstadoT.Width = 110
        '
        'lvClienteT
        '
        Me.lvClienteT.DisplayIndex = 7
        Me.lvClienteT.Text = "CLIENTE"
        Me.lvClienteT.Width = 70
        '
        'lvPedidoT
        '
        Me.lvPedidoT.DisplayIndex = 8
        Me.lvPedidoT.Text = "PEDIDO"
        Me.lvPedidoT.Width = 79
        '
        'lvFechaT
        '
        Me.lvFechaT.DisplayIndex = 9
        Me.lvFechaT.Text = "FECHA PEDIDO"
        Me.lvFechaT.Width = 100
        '
        'lvEntregaT
        '
        Me.lvEntregaT.DisplayIndex = 10
        Me.lvEntregaT.Text = "FECHA ENTREGA"
        Me.lvEntregaT.Width = 0
        '
        'lvDiasT
        '
        Me.lvDiasT.DisplayIndex = 11
        Me.lvDiasT.Text = "DÍAS"
        Me.lvDiasT.Width = 40
        '
        'lvPrioridadT
        '
        Me.lvPrioridadT.DisplayIndex = 12
        Me.lvPrioridadT.Text = "PR."
        Me.lvPrioridadT.Width = 29
        '
        'lvEtiquetaT
        '
        Me.lvEtiquetaT.DisplayIndex = 13
        Me.lvEtiquetaT.Text = "ETIQUETA"
        Me.lvEtiquetaT.Width = 91
        '
        'lvidEstadoT
        '
        Me.lvidEstadoT.DisplayIndex = 14
        Me.lvidEstadoT.Text = "idEstadoT"
        Me.lvidEstadoT.Width = 0
        '
        'TotalT
        '
        Me.TotalT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalT.BackColor = System.Drawing.SystemColors.Window
        Me.TotalT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalT.Location = New System.Drawing.Point(1058, 568)
        Me.TotalT.MaxLength = 15
        Me.TotalT.Name = "TotalT"
        Me.TotalT.Size = New System.Drawing.Size(70, 23)
        Me.TotalT.TabIndex = 194
        Me.TotalT.TabStop = False
        Me.TotalT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1009, 571)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "TOTAL"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(736, 571)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 17)
        Me.Label2.TabIndex = 198
        Me.Label2.Text = "MAS DE 2 SEMANAS"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(515, 571)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "EN 2 SEMANAS"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(1134, 571)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 17)
        Me.Label4.TabIndex = 196
        Me.Label4.Text = "U"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(282, 571)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 17)
        Me.Label6.TabIndex = 197
        Me.Label6.Text = "SEMANA PRÓXIMA"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(20, 571)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(158, 17)
        Me.Label7.TabIndex = 199
        Me.Label7.Text = "ENTREGAS ESTA SEMANA"
        '
        'EstaSemanaT
        '
        Me.EstaSemanaT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EstaSemanaT.BackColor = System.Drawing.SystemColors.Window
        Me.EstaSemanaT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstaSemanaT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstaSemanaT.Location = New System.Drawing.Point(184, 568)
        Me.EstaSemanaT.MaxLength = 15
        Me.EstaSemanaT.Name = "EstaSemanaT"
        Me.EstaSemanaT.Size = New System.Drawing.Size(70, 23)
        Me.EstaSemanaT.TabIndex = 190
        Me.EstaSemanaT.TabStop = False
        Me.EstaSemanaT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SemanaProximaT
        '
        Me.SemanaProximaT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SemanaProximaT.BackColor = System.Drawing.SystemColors.Window
        Me.SemanaProximaT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SemanaProximaT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SemanaProximaT.Location = New System.Drawing.Point(411, 568)
        Me.SemanaProximaT.MaxLength = 15
        Me.SemanaProximaT.Name = "SemanaProximaT"
        Me.SemanaProximaT.Size = New System.Drawing.Size(70, 23)
        Me.SemanaProximaT.TabIndex = 191
        Me.SemanaProximaT.TabStop = False
        Me.SemanaProximaT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'En2SemanasT
        '
        Me.En2SemanasT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.En2SemanasT.BackColor = System.Drawing.SystemColors.Window
        Me.En2SemanasT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.En2SemanasT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.En2SemanasT.Location = New System.Drawing.Point(622, 568)
        Me.En2SemanasT.MaxLength = 15
        Me.En2SemanasT.Name = "En2SemanasT"
        Me.En2SemanasT.Size = New System.Drawing.Size(70, 23)
        Me.En2SemanasT.TabIndex = 192
        Me.En2SemanasT.TabStop = False
        Me.En2SemanasT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EnMasSemanasT
        '
        Me.EnMasSemanasT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EnMasSemanasT.BackColor = System.Drawing.SystemColors.Window
        Me.EnMasSemanasT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnMasSemanasT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EnMasSemanasT.Location = New System.Drawing.Point(870, 568)
        Me.EnMasSemanasT.MaxLength = 15
        Me.EnMasSemanasT.Name = "EnMasSemanasT"
        Me.EnMasSemanasT.Size = New System.Drawing.Size(70, 23)
        Me.EnMasSemanasT.TabIndex = 193
        Me.EnMasSemanasT.TabStop = False
        Me.EnMasSemanasT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tpElectronica
        '
        Me.tpElectronica.Controls.Add(Me.ckSeleccionElectronica)
        Me.tpElectronica.Controls.Add(Me.lvElectronica)
        Me.tpElectronica.Controls.Add(Me.TotalE)
        Me.tpElectronica.Controls.Add(Me.Label8)
        Me.tpElectronica.Controls.Add(Me.Label9)
        Me.tpElectronica.Controls.Add(Me.Label10)
        Me.tpElectronica.Controls.Add(Me.Label12)
        Me.tpElectronica.Controls.Add(Me.Label13)
        Me.tpElectronica.Controls.Add(Me.Label20)
        Me.tpElectronica.Controls.Add(Me.EstaSemanaE)
        Me.tpElectronica.Controls.Add(Me.SemanaProximaE)
        Me.tpElectronica.Controls.Add(Me.En2SemanasE)
        Me.tpElectronica.Controls.Add(Me.EnMasSemanasE)
        Me.tpElectronica.Location = New System.Drawing.Point(4, 26)
        Me.tpElectronica.Name = "tpElectronica"
        Me.tpElectronica.Size = New System.Drawing.Size(1193, 740)
        Me.tpElectronica.TabIndex = 2
        Me.tpElectronica.Text = "ELECTRÓNICA"
        Me.tpElectronica.UseVisualStyleBackColor = True
        '
        'ckSeleccionElectronica
        '
        Me.ckSeleccionElectronica.AutoSize = True
        Me.ckSeleccionElectronica.Location = New System.Drawing.Point(17, 25)
        Me.ckSeleccionElectronica.Name = "ckSeleccionElectronica"
        Me.ckSeleccionElectronica.Size = New System.Drawing.Size(15, 14)
        Me.ckSeleccionElectronica.TabIndex = 0
        Me.ckSeleccionElectronica.UseVisualStyleBackColor = True
        '
        'lvElectronica
        '
        Me.lvElectronica.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvElectronica.CheckBoxes = True
        Me.lvElectronica.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvckE, Me.ividConceptoE, Me.lvidEquipoE, Me.lvcodArticuloE, Me.lvArticuloE, Me.lvEstadoEE, Me.lvClienteE, Me.lvPedidoE, Me.lvFechaE, Me.lvEntregaE, Me.lvDiasE, Me.lvPrioridadE, Me.lvEtiquetaE, Me.lvidEstadoE, Me.lvVersionE})
        Me.lvElectronica.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvElectronica.FullRowSelect = True
        Me.lvElectronica.GridLines = True
        Me.lvElectronica.HideSelection = False
        Me.lvElectronica.Location = New System.Drawing.Point(11, 19)
        Me.lvElectronica.Name = "lvElectronica"
        Me.lvElectronica.ShowItemToolTips = True
        Me.lvElectronica.Size = New System.Drawing.Size(1171, 721)
        Me.lvElectronica.TabIndex = 1
        Me.lvElectronica.UseCompatibleStateImageBehavior = False
        Me.lvElectronica.View = System.Windows.Forms.View.Details
        '
        'lvckE
        '
        Me.lvckE.Text = ""
        Me.lvckE.Width = 22
        '
        'ividConceptoE
        '
        Me.ividConceptoE.Text = "idConcepto"
        Me.ividConceptoE.Width = 0
        '
        'lvidEquipoE
        '
        Me.lvidEquipoE.Text = "ID"
        Me.lvidEquipoE.Width = 50
        '
        'lvcodArticuloE
        '
        Me.lvcodArticuloE.Text = "CÓDIGO"
        Me.lvcodArticuloE.Width = 142
        '
        'lvArticuloE
        '
        Me.lvArticuloE.Text = "ARTICULO"
        Me.lvArticuloE.Width = 352
        '
        'lvEstadoEE
        '
        Me.lvEstadoEE.DisplayIndex = 6
        Me.lvEstadoEE.Text = "ESTADO"
        Me.lvEstadoEE.Width = 110
        '
        'lvClienteE
        '
        Me.lvClienteE.DisplayIndex = 7
        Me.lvClienteE.Text = "CLIENTE"
        Me.lvClienteE.Width = 70
        '
        'lvPedidoE
        '
        Me.lvPedidoE.DisplayIndex = 8
        Me.lvPedidoE.Text = "PEDIDO"
        Me.lvPedidoE.Width = 79
        '
        'lvFechaE
        '
        Me.lvFechaE.DisplayIndex = 9
        Me.lvFechaE.Text = "FECHA PEDIDO"
        Me.lvFechaE.Width = 100
        '
        'lvEntregaE
        '
        Me.lvEntregaE.DisplayIndex = 10
        Me.lvEntregaE.Text = "FECHA ENTREGA"
        Me.lvEntregaE.Width = 0
        '
        'lvDiasE
        '
        Me.lvDiasE.DisplayIndex = 11
        Me.lvDiasE.Text = "DÍAS"
        Me.lvDiasE.Width = 40
        '
        'lvPrioridadE
        '
        Me.lvPrioridadE.DisplayIndex = 12
        Me.lvPrioridadE.Text = "PR."
        Me.lvPrioridadE.Width = 29
        '
        'lvEtiquetaE
        '
        Me.lvEtiquetaE.DisplayIndex = 13
        Me.lvEtiquetaE.Text = "ETIQUETA"
        Me.lvEtiquetaE.Width = 88
        '
        'lvidEstadoE
        '
        Me.lvidEstadoE.DisplayIndex = 14
        Me.lvidEstadoE.Text = "idEstadoE"
        Me.lvidEstadoE.Width = 0
        '
        'TotalE
        '
        Me.TotalE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalE.BackColor = System.Drawing.SystemColors.Window
        Me.TotalE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalE.Location = New System.Drawing.Point(1058, 702)
        Me.TotalE.MaxLength = 15
        Me.TotalE.Name = "TotalE"
        Me.TotalE.Size = New System.Drawing.Size(70, 23)
        Me.TotalE.TabIndex = 205
        Me.TotalE.TabStop = False
        Me.TotalE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(1009, 705)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 17)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "TOTAL"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(736, 705)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 17)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = "MAS DE 2 SEMANAS"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(515, 705)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 17)
        Me.Label10.TabIndex = 211
        Me.Label10.Text = "EN 2 SEMANAS"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(1134, 705)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 17)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = "U"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(282, 705)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 17)
        Me.Label13.TabIndex = 208
        Me.Label13.Text = "SEMANA PRÓXIMA"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(20, 705)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(158, 17)
        Me.Label20.TabIndex = 210
        Me.Label20.Text = "ENTREGAS ESTA SEMANA"
        '
        'EstaSemanaE
        '
        Me.EstaSemanaE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EstaSemanaE.BackColor = System.Drawing.SystemColors.Window
        Me.EstaSemanaE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstaSemanaE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EstaSemanaE.Location = New System.Drawing.Point(184, 702)
        Me.EstaSemanaE.MaxLength = 15
        Me.EstaSemanaE.Name = "EstaSemanaE"
        Me.EstaSemanaE.Size = New System.Drawing.Size(70, 23)
        Me.EstaSemanaE.TabIndex = 201
        Me.EstaSemanaE.TabStop = False
        Me.EstaSemanaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SemanaProximaE
        '
        Me.SemanaProximaE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SemanaProximaE.BackColor = System.Drawing.SystemColors.Window
        Me.SemanaProximaE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SemanaProximaE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SemanaProximaE.Location = New System.Drawing.Point(411, 702)
        Me.SemanaProximaE.MaxLength = 15
        Me.SemanaProximaE.Name = "SemanaProximaE"
        Me.SemanaProximaE.Size = New System.Drawing.Size(70, 23)
        Me.SemanaProximaE.TabIndex = 202
        Me.SemanaProximaE.TabStop = False
        Me.SemanaProximaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'En2SemanasE
        '
        Me.En2SemanasE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.En2SemanasE.BackColor = System.Drawing.SystemColors.Window
        Me.En2SemanasE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.En2SemanasE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.En2SemanasE.Location = New System.Drawing.Point(622, 702)
        Me.En2SemanasE.MaxLength = 15
        Me.En2SemanasE.Name = "En2SemanasE"
        Me.En2SemanasE.Size = New System.Drawing.Size(70, 23)
        Me.En2SemanasE.TabIndex = 203
        Me.En2SemanasE.TabStop = False
        Me.En2SemanasE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EnMasSemanasE
        '
        Me.EnMasSemanasE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EnMasSemanasE.BackColor = System.Drawing.SystemColors.Window
        Me.EnMasSemanasE.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnMasSemanasE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EnMasSemanasE.Location = New System.Drawing.Point(870, 704)
        Me.EnMasSemanasE.MaxLength = 15
        Me.EnMasSemanasE.Name = "EnMasSemanasE"
        Me.EnMasSemanasE.Size = New System.Drawing.Size(70, 23)
        Me.EnMasSemanasE.TabIndex = 204
        Me.EnMasSemanasE.TabStop = False
        Me.EnMasSemanasE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bAcabadoElectronica
        '
        Me.bAcabadoElectronica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bAcabadoElectronica.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAcabadoElectronica.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAcabadoElectronica.Location = New System.Drawing.Point(824, 17)
        Me.bAcabadoElectronica.Name = "bAcabadoElectronica"
        Me.bAcabadoElectronica.Size = New System.Drawing.Size(107, 61)
        Me.bAcabadoElectronica.TabIndex = 2
        Me.bAcabadoElectronica.Text = "PROCESO ELECTRÓNICA FINALIZADO"
        Me.bAcabadoElectronica.UseVisualStyleBackColor = True
        '
        'bAcabadoTaller
        '
        Me.bAcabadoTaller.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bAcabadoTaller.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAcabadoTaller.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bAcabadoTaller.Location = New System.Drawing.Point(690, 17)
        Me.bAcabadoTaller.Name = "bAcabadoTaller"
        Me.bAcabadoTaller.Size = New System.Drawing.Size(107, 61)
        Me.bAcabadoTaller.TabIndex = 1
        Me.bAcabadoTaller.Text = "PROCESO TALLER FINALIZADO"
        Me.bAcabadoTaller.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(958, 17)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(107, 61)
        Me.bGuardar.TabIndex = 3
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1092, 17)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(107, 61)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'lvVersion
        '
        Me.lvVersion.DisplayIndex = 5
        Me.lvVersion.Text = "VERSIÓN"
        Me.lvVersion.Width = 67
        '
        'lvVersionT
        '
        Me.lvVersionT.DisplayIndex = 5
        Me.lvVersionT.Text = "VERSIÓN"
        Me.lvVersionT.Width = 65
        '
        'lvVersionE
        '
        Me.lvVersionE.DisplayIndex = 5
        Me.lvVersionE.Text = "VERSIÓN"
        Me.lvVersionE.Width = 66
        '
        'GestionEquiposProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 912)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionEquiposProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN DE EQUIPOS EN PRODUCCIÓN"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpGlobal.ResumeLayout(False)
        Me.tpGlobal.PerformLayout()
        Me.tpTaller.ResumeLayout(False)
        Me.tpTaller.PerformLayout()
        Me.tpElectronica.ResumeLayout(False)
        Me.tpElectronica.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvEquipos As System.Windows.Forms.ListView
    Friend WithEvents lvidEquipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvnumPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPedido As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaPrevista As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoTaller As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents lvPrioridad As System.Windows.Forms.ColumnHeader
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents EstaSemana As System.Windows.Forms.TextBox
    Friend WithEvents SemanaProxima As System.Windows.Forms.TextBox
    Friend WithEvents En2Semanas As System.Windows.Forms.TextBox
    Friend WithEvents lvnumSerie As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEtiqueta As System.Windows.Forms.ColumnHeader
    Friend WithEvents Articulo As System.Windows.Forms.TextBox
    Friend WithEvents codArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lbArticulo As System.Windows.Forms.Label
    Friend WithEvents lvDias As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents EnMasSemanas As System.Windows.Forms.TextBox
    Friend WithEvents lvCK As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents lvEstadoElectronica As System.Windows.Forms.ColumnHeader
    Friend WithEvents bAcabadoElectronica As System.Windows.Forms.Button
    Friend WithEvents bAcabadoTaller As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpGlobal As System.Windows.Forms.TabPage
    Friend WithEvents tpTaller As System.Windows.Forms.TabPage
    Friend WithEvents tpElectronica As System.Windows.Forms.TabPage
    Friend WithEvents lvTaller As System.Windows.Forms.ListView
    Friend WithEvents lvckT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEquipoT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvClienteT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPedidoT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEntregaT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDiasT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrioridadT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEtiquetaT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSeleccionTaller As System.Windows.Forms.CheckBox
    Friend WithEvents ckSeleccionElectronica As System.Windows.Forms.CheckBox
    Friend WithEvents lvElectronica As System.Windows.Forms.ListView
    Friend WithEvents lvckE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEquipoE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticuloE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticuloE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoEE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvClienteE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPedidoE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEntregaE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDiasE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrioridadE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEtiquetaE As System.Windows.Forms.ColumnHeader
    Friend WithEvents TotalT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EstaSemanaT As System.Windows.Forms.TextBox
    Friend WithEvents SemanaProximaT As System.Windows.Forms.TextBox
    Friend WithEvents En2SemanasT As System.Windows.Forms.TextBox
    Friend WithEvents EnMasSemanasT As System.Windows.Forms.TextBox
    Friend WithEvents TotalE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents EstaSemanaE As System.Windows.Forms.TextBox
    Friend WithEvents SemanaProximaE As System.Windows.Forms.TextBox
    Friend WithEvents En2SemanasE As System.Windows.Forms.TextBox
    Friend WithEvents EnMasSemanasE As System.Windows.Forms.TextBox
    Friend WithEvents lvidConceptoT As System.Windows.Forms.ColumnHeader
    Friend WithEvents ividConceptoE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEstadoGT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEstadoGE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEstadoT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidEstadoE As System.Windows.Forms.ColumnHeader
    Friend WithEvents PBCarga As System.Windows.Forms.ProgressBar
    Friend WithEvents lbSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lvSeleccionado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvVersionT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvVersionE As System.Windows.Forms.ColumnHeader
End Class
