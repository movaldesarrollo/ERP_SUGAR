<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PantallaGeneral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PantallaGeneral))
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.msGeneral = New System.Windows.Forms.MenuStrip()
        Me.Logotipo = New System.Windows.Forms.PictureBox()
        Me.lvPedidosPreparados = New System.Windows.Forms.ListView()
        Me.lvnum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEntrega = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPortes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvRefCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbPedidosPreparados = New System.Windows.Forms.GroupBox()
        Me.gbAlbaranes = New System.Windows.Forms.GroupBox()
        Me.lvAlbaranes = New System.Windows.Forms.ListView()
        Me.lvTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvnumAlbaran = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFechaAlbaran = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAgencia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbComunicaciones = New System.Windows.Forms.GroupBox()
        Me.lvComunicaciones = New System.Windows.Forms.ListView()
        Me.lvClip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lviComunicacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFechaHoraM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvContacto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvAsunto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbPedidosFechaPrevista = New System.Windows.Forms.GroupBox()
        Me.lbDias3 = New System.Windows.Forms.Label()
        Me.lbDias2 = New System.Windows.Forms.Label()
        Me.lbDias1 = New System.Windows.Forms.Label()
        Me.lvPedidosFechaPrevista = New System.Windows.Forms.ListView()
        Me.lvNumPedidoF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvPedClienteF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvClienteF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFechaF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEntregaF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEstadoF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.Logotipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPedidosPreparados.SuspendLayout()
        Me.gbAlbaranes.SuspendLayout()
        Me.gbComunicaciones.SuspendLayout()
        Me.gbPedidosFechaPrevista.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbVersion
        '
        Me.lbVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbVersion.AutoSize = True
        Me.lbVersion.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lbVersion.Location = New System.Drawing.Point(1228, 730)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(40, 16)
        Me.lbVersion.TabIndex = 38
        Me.lbVersion.Text = "v2.0.0"
        '
        'msGeneral
        '
        Me.msGeneral.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msGeneral.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.msGeneral.Location = New System.Drawing.Point(0, 0)
        Me.msGeneral.Name = "msGeneral"
        Me.msGeneral.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.msGeneral.Size = New System.Drawing.Size(1276, 4)
        Me.msGeneral.Stretch = False
        Me.msGeneral.TabIndex = 39
        Me.msGeneral.Text = "MenuStrip1"
        '
        'Logotipo
        '
        Me.Logotipo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Logotipo.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_600
        Me.Logotipo.Location = New System.Drawing.Point(331, 248)
        Me.Logotipo.Name = "Logotipo"
        Me.Logotipo.Size = New System.Drawing.Size(604, 218)
        Me.Logotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Logotipo.TabIndex = 49
        Me.Logotipo.TabStop = False
        '
        'lvPedidosPreparados
        '
        Me.lvPedidosPreparados.AllowColumnReorder = True
        Me.lvPedidosPreparados.AllowDrop = True
        Me.lvPedidosPreparados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvPedidosPreparados.AutoArrange = False
        Me.lvPedidosPreparados.BackgroundImageTiled = True
        Me.lvPedidosPreparados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnum, Me.lvCliente, Me.lvFecha, Me.lvEntrega, Me.lvEstado, Me.lvTotal, Me.lvPortes, Me.lvRefCliente})
        Me.lvPedidosPreparados.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvPedidosPreparados.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPedidosPreparados.FullRowSelect = True
        Me.lvPedidosPreparados.GridLines = True
        Me.lvPedidosPreparados.HideSelection = False
        Me.lvPedidosPreparados.Location = New System.Drawing.Point(12, 25)
        Me.lvPedidosPreparados.Name = "lvPedidosPreparados"
        Me.lvPedidosPreparados.ShowItemToolTips = True
        Me.lvPedidosPreparados.Size = New System.Drawing.Size(594, 190)
        Me.lvPedidosPreparados.TabIndex = 50
        Me.lvPedidosPreparados.UseCompatibleStateImageBehavior = False
        Me.lvPedidosPreparados.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.Text = "NUM.PEDIDO"
        Me.lvnum.Width = 89
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 2
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 217
        '
        'lvFecha
        '
        Me.lvFecha.DisplayIndex = 3
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 78
        '
        'lvEntrega
        '
        Me.lvEntrega.DisplayIndex = 4
        Me.lvEntrega.Text = "ENTREGA"
        Me.lvEntrega.Width = 79
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 5
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 0
        '
        'lvTotal
        '
        Me.lvTotal.DisplayIndex = 6
        Me.lvTotal.Text = "TOTAL"
        Me.lvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotal.Width = 0
        '
        'lvPortes
        '
        Me.lvPortes.DisplayIndex = 7
        Me.lvPortes.Text = "PORTES"
        Me.lvPortes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPortes.Width = 0
        '
        'lvRefCliente
        '
        Me.lvRefCliente.DisplayIndex = 1
        Me.lvRefCliente.Text = "PED. CLIENTE"
        Me.lvRefCliente.Width = 101
        '
        'gbPedidosPreparados
        '
        Me.gbPedidosPreparados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbPedidosPreparados.Controls.Add(Me.lvPedidosPreparados)
        Me.gbPedidosPreparados.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPedidosPreparados.Location = New System.Drawing.Point(12, 486)
        Me.gbPedidosPreparados.Name = "gbPedidosPreparados"
        Me.gbPedidosPreparados.Size = New System.Drawing.Size(615, 238)
        Me.gbPedidosPreparados.TabIndex = 51
        Me.gbPedidosPreparados.TabStop = False
        Me.gbPedidosPreparados.Text = "PEDIDOS DE CLIENTE CON ARTÍCULOS PREPARADOS"
        Me.gbPedidosPreparados.Visible = False
        '
        'gbAlbaranes
        '
        Me.gbAlbaranes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbAlbaranes.Controls.Add(Me.lvAlbaranes)
        Me.gbAlbaranes.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAlbaranes.Location = New System.Drawing.Point(12, 145)
        Me.gbAlbaranes.Name = "gbAlbaranes"
        Me.gbAlbaranes.Size = New System.Drawing.Size(615, 238)
        Me.gbAlbaranes.TabIndex = 52
        Me.gbAlbaranes.TabStop = False
        Me.gbAlbaranes.Text = "ALBARANES PREPARADOS - MATERIAL PREPARADO"
        Me.gbAlbaranes.Visible = False
        '
        'lvAlbaranes
        '
        Me.lvAlbaranes.AllowColumnReorder = True
        Me.lvAlbaranes.AllowDrop = True
        Me.lvAlbaranes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvAlbaranes.AutoArrange = False
        Me.lvAlbaranes.BackgroundImageTiled = True
        Me.lvAlbaranes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvTipo, Me.lvnumAlbaran, Me.Cliente, Me.lvFechaAlbaran, Me.lvAgencia})
        Me.lvAlbaranes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvAlbaranes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAlbaranes.FullRowSelect = True
        Me.lvAlbaranes.GridLines = True
        Me.lvAlbaranes.HideSelection = False
        Me.lvAlbaranes.Location = New System.Drawing.Point(12, 25)
        Me.lvAlbaranes.Name = "lvAlbaranes"
        Me.lvAlbaranes.ShowItemToolTips = True
        Me.lvAlbaranes.Size = New System.Drawing.Size(594, 190)
        Me.lvAlbaranes.TabIndex = 50
        Me.lvAlbaranes.UseCompatibleStateImageBehavior = False
        Me.lvAlbaranes.View = System.Windows.Forms.View.Details
        '
        'lvTipo
        '
        Me.lvTipo.Text = "TIPO"
        Me.lvTipo.Width = 75
        '
        'lvnumAlbaran
        '
        Me.lvnumAlbaran.Text = "NÚMERO"
        Me.lvnumAlbaran.Width = 70
        '
        'Cliente
        '
        Me.Cliente.Text = "CLIENTE"
        Me.Cliente.Width = 231
        '
        'lvFechaAlbaran
        '
        Me.lvFechaAlbaran.Text = "FECHA"
        Me.lvFechaAlbaran.Width = 78
        '
        'lvAgencia
        '
        Me.lvAgencia.Text = "AGENCIA"
        Me.lvAgencia.Width = 113
        '
        'gbComunicaciones
        '
        Me.gbComunicaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbComunicaciones.Controls.Add(Me.lvComunicaciones)
        Me.gbComunicaciones.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbComunicaciones.Location = New System.Drawing.Point(644, 486)
        Me.gbComunicaciones.Name = "gbComunicaciones"
        Me.gbComunicaciones.Size = New System.Drawing.Size(615, 238)
        Me.gbComunicaciones.TabIndex = 53
        Me.gbComunicaciones.TabStop = False
        Me.gbComunicaciones.Text = "COMUNICACIONES"
        Me.gbComunicaciones.Visible = False
        '
        'lvComunicaciones
        '
        Me.lvComunicaciones.AllowColumnReorder = True
        Me.lvComunicaciones.AllowDrop = True
        Me.lvComunicaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvComunicaciones.BackgroundImageTiled = True
        Me.lvComunicaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvClip, Me.lviComunicacion, Me.lvFechaHoraM, Me.lvNombre, Me.lvContacto, Me.lvAsunto})
        Me.lvComunicaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvComunicaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvComunicaciones.FullRowSelect = True
        Me.lvComunicaciones.GridLines = True
        Me.lvComunicaciones.HideSelection = False
        Me.lvComunicaciones.Location = New System.Drawing.Point(12, 25)
        Me.lvComunicaciones.Name = "lvComunicaciones"
        Me.lvComunicaciones.ShowItemToolTips = True
        Me.lvComunicaciones.Size = New System.Drawing.Size(594, 196)
        Me.lvComunicaciones.TabIndex = 3
        Me.lvComunicaciones.UseCompatibleStateImageBehavior = False
        Me.lvComunicaciones.View = System.Windows.Forms.View.Details
        '
        'lvClip
        '
        Me.lvClip.DisplayIndex = 5
        Me.lvClip.Text = ""
        Me.lvClip.Width = 20
        '
        'lviComunicacion
        '
        Me.lviComunicacion.DisplayIndex = 0
        Me.lviComunicacion.Text = "IdComunicacion"
        Me.lviComunicacion.Width = 0
        '
        'lvFechaHoraM
        '
        Me.lvFechaHoraM.DisplayIndex = 1
        Me.lvFechaHoraM.Text = "FECHA-HORA"
        Me.lvFechaHoraM.Width = 123
        '
        'lvNombre
        '
        Me.lvNombre.DisplayIndex = 2
        Me.lvNombre.Text = "NOMBRE"
        Me.lvNombre.Width = 142
        '
        'lvContacto
        '
        Me.lvContacto.DisplayIndex = 3
        Me.lvContacto.Text = "CONTACTO"
        Me.lvContacto.Width = 81
        '
        'lvAsunto
        '
        Me.lvAsunto.DisplayIndex = 4
        Me.lvAsunto.Text = "ASUNTO"
        Me.lvAsunto.Width = 210
        '
        'gbPedidosFechaPrevista
        '
        Me.gbPedidosFechaPrevista.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPedidosFechaPrevista.Controls.Add(Me.lbDias3)
        Me.gbPedidosFechaPrevista.Controls.Add(Me.lbDias2)
        Me.gbPedidosFechaPrevista.Controls.Add(Me.lbDias1)
        Me.gbPedidosFechaPrevista.Controls.Add(Me.lvPedidosFechaPrevista)
        Me.gbPedidosFechaPrevista.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPedidosFechaPrevista.Location = New System.Drawing.Point(644, 145)
        Me.gbPedidosFechaPrevista.Name = "gbPedidosFechaPrevista"
        Me.gbPedidosFechaPrevista.Size = New System.Drawing.Size(615, 238)
        Me.gbPedidosFechaPrevista.TabIndex = 52
        Me.gbPedidosFechaPrevista.TabStop = False
        Me.gbPedidosFechaPrevista.Text = "PEDIDOS CON FECHA PREVISTA"
        Me.gbPedidosFechaPrevista.Visible = False
        '
        'lbDias3
        '
        Me.lbDias3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDias3.AutoSize = True
        Me.lbDias3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDias3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbDias3.Location = New System.Drawing.Point(469, 203)
        Me.lbDias3.Name = "lbDias3"
        Me.lbDias3.Size = New System.Drawing.Size(135, 17)
        Me.lbDias3.TabIndex = 51
        Me.lbDias3.Text = "DESDE 10 DIAS ANTES "
        Me.lbDias3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbDias2
        '
        Me.lbDias2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbDias2.AutoSize = True
        Me.lbDias2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDias2.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbDias2.Location = New System.Drawing.Point(237, 203)
        Me.lbDias2.Name = "lbDias2"
        Me.lbDias2.Size = New System.Drawing.Size(140, 17)
        Me.lbDias2.TabIndex = 51
        Me.lbDias2.Text = " 2  LABORABLES ANTES "
        Me.lbDias2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDias1
        '
        Me.lbDias1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbDias1.AutoSize = True
        Me.lbDias1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDias1.ForeColor = System.Drawing.Color.Red
        Me.lbDias1.Location = New System.Drawing.Point(16, 203)
        Me.lbDias1.Name = "lbDias1"
        Me.lbDias1.Size = New System.Drawing.Size(134, 17)
        Me.lbDias1.TabIndex = 51
        Me.lbDias1.Text = "2 LABORABLES ANTES "
        Me.lbDias1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvPedidosFechaPrevista
        '
        Me.lvPedidosFechaPrevista.AllowColumnReorder = True
        Me.lvPedidosFechaPrevista.AllowDrop = True
        Me.lvPedidosFechaPrevista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPedidosFechaPrevista.AutoArrange = False
        Me.lvPedidosFechaPrevista.BackgroundImageTiled = True
        Me.lvPedidosFechaPrevista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvNumPedidoF, Me.lvPedClienteF, Me.lvClienteF, Me.lvFechaF, Me.lvEntregaF, Me.lvEstadoF})
        Me.lvPedidosFechaPrevista.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvPedidosFechaPrevista.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPedidosFechaPrevista.FullRowSelect = True
        Me.lvPedidosFechaPrevista.GridLines = True
        Me.lvPedidosFechaPrevista.HideSelection = False
        Me.lvPedidosFechaPrevista.Location = New System.Drawing.Point(12, 25)
        Me.lvPedidosFechaPrevista.Name = "lvPedidosFechaPrevista"
        Me.lvPedidosFechaPrevista.ShowItemToolTips = True
        Me.lvPedidosFechaPrevista.Size = New System.Drawing.Size(594, 172)
        Me.lvPedidosFechaPrevista.TabIndex = 50
        Me.lvPedidosFechaPrevista.UseCompatibleStateImageBehavior = False
        Me.lvPedidosFechaPrevista.View = System.Windows.Forms.View.Details
        '
        'lvNumPedidoF
        '
        Me.lvNumPedidoF.Text = "PEDIDO"
        Me.lvNumPedidoF.Width = 72
        '
        'lvPedClienteF
        '
        Me.lvPedClienteF.Text = "PED. CLIENTE"
        Me.lvPedClienteF.Width = 93
        '
        'lvClienteF
        '
        Me.lvClienteF.Text = "CLIENTE"
        Me.lvClienteF.Width = 163
        '
        'lvFechaF
        '
        Me.lvFechaF.Text = "FECHA"
        Me.lvFechaF.Width = 78
        '
        'lvEntregaF
        '
        Me.lvEntregaF.Text = "ENTREGA"
        Me.lvEntregaF.Width = 79
        '
        'lvEstadoF
        '
        Me.lvEstadoF.Text = "ESTADO"
        Me.lvEstadoF.Width = 82
        '
        'PantallaGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1276, 749)
        Me.Controls.Add(Me.gbComunicaciones)
        Me.Controls.Add(Me.gbPedidosFechaPrevista)
        Me.Controls.Add(Me.gbAlbaranes)
        Me.Controls.Add(Me.gbPedidosPreparados)
        Me.Controls.Add(Me.Logotipo)
        Me.Controls.Add(Me.msGeneral)
        Me.Controls.Add(Me.lbVersion)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PantallaGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ERP SUGAR VALLEY "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Logotipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPedidosPreparados.ResumeLayout(False)
        Me.gbAlbaranes.ResumeLayout(False)
        Me.gbComunicaciones.ResumeLayout(False)
        Me.gbPedidosFechaPrevista.ResumeLayout(False)
        Me.gbPedidosFechaPrevista.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents msGeneral As System.Windows.Forms.MenuStrip
    Friend WithEvents Logotipo As System.Windows.Forms.PictureBox
    Friend WithEvents lvPedidosPreparados As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEntrega As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPortes As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvRefCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbPedidosPreparados As System.Windows.Forms.GroupBox
    Friend WithEvents gbAlbaranes As System.Windows.Forms.GroupBox
    Friend WithEvents lvAlbaranes As System.Windows.Forms.ListView
    Friend WithEvents lvnumAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAgencia As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbComunicaciones As System.Windows.Forms.GroupBox
    Friend WithEvents lvComunicaciones As System.Windows.Forms.ListView
    Friend WithEvents lvClip As System.Windows.Forms.ColumnHeader
    Friend WithEvents lviComunicacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaHoraM As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvContacto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvAsunto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbPedidosFechaPrevista As System.Windows.Forms.GroupBox
    Friend WithEvents lvPedidosFechaPrevista As System.Windows.Forms.ListView
    Friend WithEvents lvNumPedidoF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvClienteF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFechaF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEntregaF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPedClienteF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEstadoF As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbDias1 As System.Windows.Forms.Label
    Friend WithEvents lbDias2 As System.Windows.Forms.Label
    Friend WithEvents lbDias3 As System.Windows.Forms.Label
End Class
