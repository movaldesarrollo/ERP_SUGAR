<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorEtiqueta
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
        Me.crPrv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.pnCrystalReport = New System.Windows.Forms.Panel()
        Me.cbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbLogoERP = New System.Windows.Forms.PictureBox()
        Me.gbParametros = New System.Windows.Forms.GroupBox()
        Me.txOutPut = New System.Windows.Forms.TextBox()
        Me.txArticuloCliente = New System.Windows.Forms.TextBox()
        Me.lbOutPut = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txInput = New System.Windows.Forms.TextBox()
        Me.txWeb = New System.Windows.Forms.TextBox()
        Me.lbInput = New System.Windows.Forms.Label()
        Me.lbWeb = New System.Windows.Forms.Label()
        Me.txEtiqueta6 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta5 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta4 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta3 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta2 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta1 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta0 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbValor1 = New System.Windows.Forms.ComboBox()
        Me.cbValor2 = New System.Windows.Forms.ComboBox()
        Me.cbValor3 = New System.Windows.Forms.ComboBox()
        Me.cbValor4 = New System.Windows.Forms.ComboBox()
        Me.cbValor5 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbValor0 = New System.Windows.Forms.ComboBox()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bLogosClientes = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.bBuscarCliente = New System.Windows.Forms.Button()
        Me.bBuscarArticulo = New System.Windows.Forms.Button()
        Me.txCliente = New System.Windows.Forms.TextBox()
        Me.txArticulo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.ckWeb = New System.Windows.Forms.CheckBox()
        Me.pnCrystalReport.SuspendLayout()
        CType(Me.pbLogoERP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbParametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'crPrv
        '
        Me.crPrv.ActiveViewIndex = -1
        Me.crPrv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.crPrv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crPrv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crPrv.DisplayBackgroundEdge = False
        Me.crPrv.DisplayStatusBar = False
        Me.crPrv.EnableToolTips = False
        Me.crPrv.Location = New System.Drawing.Point(-1, 0)
        Me.crPrv.Name = "crPrv"
        Me.crPrv.ShowGroupTreeButton = False
        Me.crPrv.Size = New System.Drawing.Size(390, 410)
        Me.crPrv.TabIndex = 0
        Me.crPrv.TabStop = False
        Me.crPrv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1002, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 70)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'pnCrystalReport
        '
        Me.pnCrystalReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnCrystalReport.Controls.Add(Me.crPrv)
        Me.pnCrystalReport.Location = New System.Drawing.Point(739, 151)
        Me.pnCrystalReport.Name = "pnCrystalReport"
        Me.pnCrystalReport.Size = New System.Drawing.Size(390, 410)
        Me.pnCrystalReport.TabIndex = 193
        '
        'cbImpresoras
        '
        Me.cbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpresoras.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresoras.FormattingEnabled = True
        Me.cbImpresoras.Location = New System.Drawing.Point(850, 103)
        Me.cbImpresoras.Name = "cbImpresoras"
        Me.cbImpresoras.Size = New System.Drawing.Size(278, 30)
        Me.cbImpresoras.TabIndex = 0
        Me.cbImpresoras.TabStop = False
        Me.cbImpresoras.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(741, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 21)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "IMPRESORA"
        Me.Label2.Visible = False
        '
        'pbLogoERP
        '
        Me.pbLogoERP.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.pbLogoERP.Location = New System.Drawing.Point(12, 13)
        Me.pbLogoERP.Name = "pbLogoERP"
        Me.pbLogoERP.Size = New System.Drawing.Size(200, 71)
        Me.pbLogoERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbLogoERP.TabIndex = 194
        Me.pbLogoERP.TabStop = False
        '
        'gbParametros
        '
        Me.gbParametros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbParametros.Controls.Add(Me.ckWeb)
        Me.gbParametros.Controls.Add(Me.txOutPut)
        Me.gbParametros.Controls.Add(Me.txArticuloCliente)
        Me.gbParametros.Controls.Add(Me.lbOutPut)
        Me.gbParametros.Controls.Add(Me.Label19)
        Me.gbParametros.Controls.Add(Me.txInput)
        Me.gbParametros.Controls.Add(Me.txWeb)
        Me.gbParametros.Controls.Add(Me.lbInput)
        Me.gbParametros.Controls.Add(Me.lbWeb)
        Me.gbParametros.Controls.Add(Me.txEtiqueta6)
        Me.gbParametros.Controls.Add(Me.txEtiqueta5)
        Me.gbParametros.Controls.Add(Me.txEtiqueta4)
        Me.gbParametros.Controls.Add(Me.txEtiqueta3)
        Me.gbParametros.Controls.Add(Me.txEtiqueta2)
        Me.gbParametros.Controls.Add(Me.txEtiqueta1)
        Me.gbParametros.Controls.Add(Me.txEtiqueta0)
        Me.gbParametros.Controls.Add(Me.Label1)
        Me.gbParametros.Controls.Add(Me.Label7)
        Me.gbParametros.Controls.Add(Me.Label11)
        Me.gbParametros.Controls.Add(Me.Label12)
        Me.gbParametros.Controls.Add(Me.Label13)
        Me.gbParametros.Controls.Add(Me.Label14)
        Me.gbParametros.Controls.Add(Me.Label15)
        Me.gbParametros.Controls.Add(Me.cbValor1)
        Me.gbParametros.Controls.Add(Me.cbValor2)
        Me.gbParametros.Controls.Add(Me.cbValor3)
        Me.gbParametros.Controls.Add(Me.cbValor4)
        Me.gbParametros.Controls.Add(Me.cbValor5)
        Me.gbParametros.Controls.Add(Me.Label9)
        Me.gbParametros.Controls.Add(Me.Label10)
        Me.gbParametros.Controls.Add(Me.Label5)
        Me.gbParametros.Controls.Add(Me.Label6)
        Me.gbParametros.Controls.Add(Me.Label4)
        Me.gbParametros.Controls.Add(Me.Label3)
        Me.gbParametros.Controls.Add(Me.cbValor0)
        Me.gbParametros.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbParametros.Location = New System.Drawing.Point(14, 140)
        Me.gbParametros.Name = "gbParametros"
        Me.gbParametros.Size = New System.Drawing.Size(718, 421)
        Me.gbParametros.TabIndex = 2
        Me.gbParametros.TabStop = False
        Me.gbParametros.Text = "PARÁMETROS"
        '
        'txOutPut
        '
        Me.txOutPut.Location = New System.Drawing.Point(461, 65)
        Me.txOutPut.MaxLength = 100
        Me.txOutPut.Name = "txOutPut"
        Me.txOutPut.Size = New System.Drawing.Size(249, 27)
        Me.txOutPut.TabIndex = 3
        '
        'txArticuloCliente
        '
        Me.txArticuloCliente.Location = New System.Drawing.Point(461, 29)
        Me.txArticuloCliente.MaxLength = 100
        Me.txArticuloCliente.Name = "txArticuloCliente"
        Me.txArticuloCliente.ReadOnly = True
        Me.txArticuloCliente.Size = New System.Drawing.Size(249, 27)
        Me.txArticuloCliente.TabIndex = 1
        '
        'lbOutPut
        '
        Me.lbOutPut.AutoSize = True
        Me.lbOutPut.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOutPut.Location = New System.Drawing.Point(355, 70)
        Me.lbOutPut.Name = "lbOutPut"
        Me.lbOutPut.Size = New System.Drawing.Size(71, 21)
        Me.lbOutPut.TabIndex = 255
        Me.lbOutPut.Text = "OUTPUT"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(355, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 21)
        Me.Label19.TabIndex = 254
        Me.Label19.Text = "ART. CLI."
        '
        'txInput
        '
        Me.txInput.Location = New System.Drawing.Point(115, 65)
        Me.txInput.MaxLength = 100
        Me.txInput.Name = "txInput"
        Me.txInput.Size = New System.Drawing.Size(227, 27)
        Me.txInput.TabIndex = 2
        '
        'txWeb
        '
        Me.txWeb.Location = New System.Drawing.Point(115, 29)
        Me.txWeb.MaxLength = 100
        Me.txWeb.Name = "txWeb"
        Me.txWeb.Size = New System.Drawing.Size(206, 27)
        Me.txWeb.TabIndex = 0
        '
        'lbInput
        '
        Me.lbInput.AutoSize = True
        Me.lbInput.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInput.Location = New System.Drawing.Point(9, 70)
        Me.lbInput.Name = "lbInput"
        Me.lbInput.Size = New System.Drawing.Size(55, 21)
        Me.lbInput.TabIndex = 249
        Me.lbInput.Text = "INPUT"
        '
        'lbWeb
        '
        Me.lbWeb.AutoSize = True
        Me.lbWeb.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbWeb.Location = New System.Drawing.Point(9, 34)
        Me.lbWeb.Name = "lbWeb"
        Me.lbWeb.Size = New System.Drawing.Size(43, 21)
        Me.lbWeb.TabIndex = 248
        Me.lbWeb.Text = "WEB"
        '
        'txEtiqueta6
        '
        Me.txEtiqueta6.Location = New System.Drawing.Point(115, 316)
        Me.txEtiqueta6.MaxLength = 500
        Me.txEtiqueta6.Multiline = True
        Me.txEtiqueta6.Name = "txEtiqueta6"
        Me.txEtiqueta6.Size = New System.Drawing.Size(595, 92)
        Me.txEtiqueta6.TabIndex = 16
        '
        'txEtiqueta5
        '
        Me.txEtiqueta5.Location = New System.Drawing.Point(115, 281)
        Me.txEtiqueta5.MaxLength = 100
        Me.txEtiqueta5.Name = "txEtiqueta5"
        Me.txEtiqueta5.Size = New System.Drawing.Size(227, 27)
        Me.txEtiqueta5.TabIndex = 14
        '
        'txEtiqueta4
        '
        Me.txEtiqueta4.Location = New System.Drawing.Point(115, 245)
        Me.txEtiqueta4.MaxLength = 100
        Me.txEtiqueta4.Name = "txEtiqueta4"
        Me.txEtiqueta4.Size = New System.Drawing.Size(227, 27)
        Me.txEtiqueta4.TabIndex = 12
        '
        'txEtiqueta3
        '
        Me.txEtiqueta3.Location = New System.Drawing.Point(115, 209)
        Me.txEtiqueta3.MaxLength = 100
        Me.txEtiqueta3.Name = "txEtiqueta3"
        Me.txEtiqueta3.Size = New System.Drawing.Size(227, 27)
        Me.txEtiqueta3.TabIndex = 10
        '
        'txEtiqueta2
        '
        Me.txEtiqueta2.Location = New System.Drawing.Point(115, 174)
        Me.txEtiqueta2.MaxLength = 100
        Me.txEtiqueta2.Name = "txEtiqueta2"
        Me.txEtiqueta2.Size = New System.Drawing.Size(227, 27)
        Me.txEtiqueta2.TabIndex = 8
        '
        'txEtiqueta1
        '
        Me.txEtiqueta1.Location = New System.Drawing.Point(115, 137)
        Me.txEtiqueta1.MaxLength = 100
        Me.txEtiqueta1.Name = "txEtiqueta1"
        Me.txEtiqueta1.Size = New System.Drawing.Size(227, 27)
        Me.txEtiqueta1.TabIndex = 6
        '
        'txEtiqueta0
        '
        Me.txEtiqueta0.Location = New System.Drawing.Point(115, 102)
        Me.txEtiqueta0.MaxLength = 100
        Me.txEtiqueta0.Name = "txEtiqueta0"
        Me.txEtiqueta0.Size = New System.Drawing.Size(227, 27)
        Me.txEtiqueta0.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 321)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 21)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "ETIQUETA 6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 21)
        Me.Label7.TabIndex = 238
        Me.Label7.Text = "ETIQUETA 5"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 21)
        Me.Label11.TabIndex = 237
        Me.Label11.Text = "ETIQUETA 4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 21)
        Me.Label12.TabIndex = 236
        Me.Label12.Text = "ETIQUETA 3"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 21)
        Me.Label13.TabIndex = 235
        Me.Label13.Text = "ETIQUETA 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(9, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 21)
        Me.Label14.TabIndex = 234
        Me.Label14.Text = "ETIQUETA 1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 21)
        Me.Label15.TabIndex = 233
        Me.Label15.Text = "ETIQUETA 0"
        '
        'cbValor1
        '
        Me.cbValor1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor1.FormattingEnabled = True
        Me.cbValor1.Location = New System.Drawing.Point(461, 138)
        Me.cbValor1.MaxLength = 100
        Me.cbValor1.Name = "cbValor1"
        Me.cbValor1.Size = New System.Drawing.Size(249, 30)
        Me.cbValor1.TabIndex = 7
        '
        'cbValor2
        '
        Me.cbValor2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor2.FormattingEnabled = True
        Me.cbValor2.Location = New System.Drawing.Point(461, 174)
        Me.cbValor2.MaxLength = 100
        Me.cbValor2.Name = "cbValor2"
        Me.cbValor2.Size = New System.Drawing.Size(249, 30)
        Me.cbValor2.TabIndex = 9
        '
        'cbValor3
        '
        Me.cbValor3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor3.FormattingEnabled = True
        Me.cbValor3.Location = New System.Drawing.Point(461, 210)
        Me.cbValor3.MaxLength = 100
        Me.cbValor3.Name = "cbValor3"
        Me.cbValor3.Size = New System.Drawing.Size(249, 30)
        Me.cbValor3.TabIndex = 11
        '
        'cbValor4
        '
        Me.cbValor4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor4.FormattingEnabled = True
        Me.cbValor4.Location = New System.Drawing.Point(461, 246)
        Me.cbValor4.MaxLength = 100
        Me.cbValor4.Name = "cbValor4"
        Me.cbValor4.Size = New System.Drawing.Size(249, 30)
        Me.cbValor4.TabIndex = 13
        '
        'cbValor5
        '
        Me.cbValor5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor5.FormattingEnabled = True
        Me.cbValor5.Location = New System.Drawing.Point(461, 282)
        Me.cbValor5.MaxLength = 100
        Me.cbValor5.Name = "cbValor5"
        Me.cbValor5.Size = New System.Drawing.Size(249, 30)
        Me.cbValor5.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(357, 286)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 21)
        Me.Label9.TabIndex = 225
        Me.Label9.Text = "VALOR 5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(357, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 21)
        Me.Label10.TabIndex = 224
        Me.Label10.Text = "VALOR 4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(357, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 21)
        Me.Label5.TabIndex = 223
        Me.Label5.Text = "VALOR 3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(357, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 21)
        Me.Label6.TabIndex = 222
        Me.Label6.Text = "VALOR 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(357, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 21)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "VALOR 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(357, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 21)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "VALOR 0"
        '
        'cbValor0
        '
        Me.cbValor0.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor0.FormattingEnabled = True
        Me.cbValor0.Location = New System.Drawing.Point(461, 102)
        Me.cbValor0.MaxLength = 100
        Me.cbValor0.Name = "cbValor0"
        Me.cbValor0.Size = New System.Drawing.Size(249, 30)
        Me.cbValor0.TabIndex = 5
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(606, 13)
        Me.bGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(126, 70)
        Me.bGuardar.TabIndex = 4
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bLogosClientes
        '
        Me.bLogosClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLogosClientes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLogosClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLogosClientes.Location = New System.Drawing.Point(738, 13)
        Me.bLogosClientes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLogosClientes.Name = "bLogosClientes"
        Me.bLogosClientes.Size = New System.Drawing.Size(126, 70)
        Me.bLogosClientes.TabIndex = 5
        Me.bLogosClientes.Text = "LOGOS CLIENTES"
        Me.bLogosClientes.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(870, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(126, 70)
        Me.bLimpiar.TabIndex = 6
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(474, 13)
        Me.bBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(126, 70)
        Me.bBuscar.TabIndex = 3
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'bBuscarCliente
        '
        Me.bBuscarCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscarCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bBuscarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarCliente.Location = New System.Drawing.Point(327, 102)
        Me.bBuscarCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBuscarCliente.Name = "bBuscarCliente"
        Me.bBuscarCliente.Size = New System.Drawing.Size(31, 31)
        Me.bBuscarCliente.TabIndex = 0
        Me.bBuscarCliente.Text = "..."
        Me.bBuscarCliente.UseVisualStyleBackColor = True
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bBuscarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticulo.Location = New System.Drawing.Point(693, 102)
        Me.bBuscarArticulo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(31, 31)
        Me.bBuscarArticulo.TabIndex = 1
        Me.bBuscarArticulo.Text = "..."
        Me.bBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txCliente
        '
        Me.txCliente.Location = New System.Drawing.Point(129, 102)
        Me.txCliente.MaxLength = 100
        Me.txCliente.Name = "txCliente"
        Me.txCliente.ReadOnly = True
        Me.txCliente.Size = New System.Drawing.Size(190, 31)
        Me.txCliente.TabIndex = 267
        '
        'txArticulo
        '
        Me.txArticulo.Location = New System.Drawing.Point(475, 102)
        Me.txArticulo.MaxLength = 100
        Me.txArticulo.Name = "txArticulo"
        Me.txArticulo.ReadOnly = True
        Me.txArticulo.Size = New System.Drawing.Size(212, 31)
        Me.txArticulo.TabIndex = 266
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(368, 107)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 19)
        Me.Label20.TabIndex = 265
        Me.Label20.Text = "ARTÍCULO"
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.Location = New System.Drawing.Point(22, 107)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(67, 19)
        Me.lbCliente.TabIndex = 264
        Me.lbCliente.Text = "CLIENTE"
        '
        'ckWeb
        '
        Me.ckWeb.AutoSize = True
        Me.ckWeb.Location = New System.Drawing.Point(327, 35)
        Me.ckWeb.Name = "ckWeb"
        Me.ckWeb.Size = New System.Drawing.Size(15, 14)
        Me.ckWeb.TabIndex = 256
        Me.ckWeb.UseVisualStyleBackColor = True
        '
        'EditorEtiqueta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 573)
        Me.Controls.Add(Me.bBuscarCliente)
        Me.Controls.Add(Me.cbImpresoras)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bBuscarArticulo)
        Me.Controls.Add(Me.txCliente)
        Me.Controls.Add(Me.txArticulo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lbCliente)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bLogosClientes)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.gbParametros)
        Me.Controls.Add(Me.pbLogoERP)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.pnCrystalReport)
        Me.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditorEtiqueta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EDITOR ETIQUETAS OFFLINE"
        Me.pnCrystalReport.ResumeLayout(False)
        CType(Me.pbLogoERP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbParametros.ResumeLayout(False)
        Me.gbParametros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents crPrv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bSalir As Button
    Friend WithEvents pnCrystalReport As Panel
    Friend WithEvents pbLogoERP As PictureBox
    Friend WithEvents gbParametros As GroupBox
    Friend WithEvents bGuardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cbImpresoras As ComboBox
    Friend WithEvents bLogosClientes As Button
    Friend WithEvents cbValor1 As ComboBox
    Friend WithEvents cbValor2 As ComboBox
    Friend WithEvents cbValor3 As ComboBox
    Friend WithEvents cbValor4 As ComboBox
    Friend WithEvents cbValor5 As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbValor0 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txEtiqueta6 As TextBox
    Friend WithEvents txEtiqueta5 As TextBox
    Friend WithEvents txEtiqueta4 As TextBox
    Friend WithEvents txEtiqueta3 As TextBox
    Friend WithEvents txEtiqueta2 As TextBox
    Friend WithEvents txEtiqueta1 As TextBox
    Friend WithEvents txEtiqueta0 As TextBox
    Friend WithEvents txOutPut As TextBox
    Friend WithEvents txArticuloCliente As TextBox
    Friend WithEvents lbOutPut As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txInput As TextBox
    Friend WithEvents txWeb As TextBox
    Friend WithEvents lbInput As Label
    Friend WithEvents lbWeb As Label
    Friend WithEvents bLimpiar As Button
    Friend WithEvents bBuscar As Button
    Friend WithEvents bBuscarCliente As Button
    Friend WithEvents bBuscarArticulo As Button
    Friend WithEvents txCliente As TextBox
    Friend WithEvents txArticulo As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents lbCliente As Label
    Friend WithEvents ckWeb As CheckBox
End Class
