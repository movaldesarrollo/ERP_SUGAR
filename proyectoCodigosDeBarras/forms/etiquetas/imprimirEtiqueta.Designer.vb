<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class imprimirEtiqueta
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
        Me.bLogosClientes = New System.Windows.Forms.Button()
        Me.bRecargar = New System.Windows.Forms.Button()
        Me.gbParametros = New System.Windows.Forms.GroupBox()
        Me.cbUL = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbWEEEE = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbLPX3 = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbUKCA = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbEAC = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbCMIN = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbCE = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbMadeInSpain = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txOutPut = New System.Windows.Forms.TextBox()
        Me.txArticuloCliente = New System.Windows.Forms.TextBox()
        Me.txArticulo = New System.Windows.Forms.TextBox()
        Me.lbOutPut = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txInput = New System.Windows.Forms.TextBox()
        Me.txCliente = New System.Windows.Forms.TextBox()
        Me.lbInput = New System.Windows.Forms.Label()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.txEtiqueta5 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta4 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta3 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta2 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta1 = New System.Windows.Forms.TextBox()
        Me.txEtiqueta0 = New System.Windows.Forms.TextBox()
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.cbImpresoras = New System.Windows.Forms.ComboBox()
        Me.pbLogoERP = New System.Windows.Forms.PictureBox()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.pnCrystalReport = New System.Windows.Forms.Panel()
        Me.crPrv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gbParametros.SuspendLayout()
        CType(Me.pbLogoERP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnCrystalReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'bLogosClientes
        '
        Me.bLogosClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLogosClientes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLogosClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLogosClientes.Location = New System.Drawing.Point(738, 31)
        Me.bLogosClientes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLogosClientes.Name = "bLogosClientes"
        Me.bLogosClientes.Size = New System.Drawing.Size(126, 70)
        Me.bLogosClientes.TabIndex = 230
        Me.bLogosClientes.Text = "LOGOS CLIENTES"
        Me.bLogosClientes.UseVisualStyleBackColor = True
        '
        'bRecargar
        '
        Me.bRecargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bRecargar.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bRecargar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bRecargar.Location = New System.Drawing.Point(606, 31)
        Me.bRecargar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bRecargar.Name = "bRecargar"
        Me.bRecargar.Size = New System.Drawing.Size(126, 70)
        Me.bRecargar.TabIndex = 229
        Me.bRecargar.Text = "GUARDAR"
        Me.bRecargar.UseVisualStyleBackColor = True
        '
        'gbParametros
        '
        Me.gbParametros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbParametros.Controls.Add(Me.cbUL)
        Me.gbParametros.Controls.Add(Me.Label1)
        Me.gbParametros.Controls.Add(Me.cbWEEEE)
        Me.gbParametros.Controls.Add(Me.Label21)
        Me.gbParametros.Controls.Add(Me.cbLPX3)
        Me.gbParametros.Controls.Add(Me.Label22)
        Me.gbParametros.Controls.Add(Me.cbUKCA)
        Me.gbParametros.Controls.Add(Me.Label23)
        Me.gbParametros.Controls.Add(Me.cbEAC)
        Me.gbParametros.Controls.Add(Me.Label17)
        Me.gbParametros.Controls.Add(Me.cbCMIN)
        Me.gbParametros.Controls.Add(Me.Label18)
        Me.gbParametros.Controls.Add(Me.cbCE)
        Me.gbParametros.Controls.Add(Me.Label16)
        Me.gbParametros.Controls.Add(Me.cbMadeInSpain)
        Me.gbParametros.Controls.Add(Me.Label8)
        Me.gbParametros.Controls.Add(Me.txOutPut)
        Me.gbParametros.Controls.Add(Me.txArticuloCliente)
        Me.gbParametros.Controls.Add(Me.txArticulo)
        Me.gbParametros.Controls.Add(Me.lbOutPut)
        Me.gbParametros.Controls.Add(Me.Label19)
        Me.gbParametros.Controls.Add(Me.Label20)
        Me.gbParametros.Controls.Add(Me.txInput)
        Me.gbParametros.Controls.Add(Me.txCliente)
        Me.gbParametros.Controls.Add(Me.lbInput)
        Me.gbParametros.Controls.Add(Me.lbCliente)
        Me.gbParametros.Controls.Add(Me.txEtiqueta5)
        Me.gbParametros.Controls.Add(Me.txEtiqueta4)
        Me.gbParametros.Controls.Add(Me.txEtiqueta3)
        Me.gbParametros.Controls.Add(Me.txEtiqueta2)
        Me.gbParametros.Controls.Add(Me.txEtiqueta1)
        Me.gbParametros.Controls.Add(Me.txEtiqueta0)
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
        Me.gbParametros.Controls.Add(Me.ComboBox1)
        Me.gbParametros.Controls.Add(Me.ComboBox2)
        Me.gbParametros.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbParametros.Location = New System.Drawing.Point(13, 107)
        Me.gbParametros.Name = "gbParametros"
        Me.gbParametros.Size = New System.Drawing.Size(718, 438)
        Me.gbParametros.TabIndex = 227
        Me.gbParametros.TabStop = False
        Me.gbParametros.Text = "PARÁMETROS"
        '
        'cbUL
        '
        Me.cbUL.AutoSize = True
        Me.cbUL.Location = New System.Drawing.Point(553, 404)
        Me.cbUL.Name = "cbUL"
        Me.cbUL.Size = New System.Drawing.Size(15, 14)
        Me.cbUL.TabIndex = 289
        Me.cbUL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(509, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 21)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "UL"
        '
        'cbWEEEE
        '
        Me.cbWEEEE.AutoSize = True
        Me.cbWEEEE.Location = New System.Drawing.Point(445, 405)
        Me.cbWEEEE.Name = "cbWEEEE"
        Me.cbWEEEE.Size = New System.Drawing.Size(15, 14)
        Me.cbWEEEE.TabIndex = 287
        Me.cbWEEEE.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(377, 400)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 21)
        Me.Label21.TabIndex = 286
        Me.Label21.Text = "WEEEE"
        '
        'cbLPX3
        '
        Me.cbLPX3.AutoSize = True
        Me.cbLPX3.Location = New System.Drawing.Point(552, 375)
        Me.cbLPX3.Name = "cbLPX3"
        Me.cbLPX3.Size = New System.Drawing.Size(15, 14)
        Me.cbLPX3.TabIndex = 285
        Me.cbLPX3.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(493, 370)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 21)
        Me.Label22.TabIndex = 284
        Me.Label22.Text = "IPX3"
        '
        'cbUKCA
        '
        Me.cbUKCA.AutoSize = True
        Me.cbUKCA.Location = New System.Drawing.Point(444, 374)
        Me.cbUKCA.Name = "cbUKCA"
        Me.cbUKCA.Size = New System.Drawing.Size(15, 14)
        Me.cbUKCA.TabIndex = 283
        Me.cbUKCA.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(381, 370)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 21)
        Me.Label23.TabIndex = 282
        Me.Label23.Text = "UKCA"
        '
        'cbEAC
        '
        Me.cbEAC.AutoSize = True
        Me.cbEAC.Location = New System.Drawing.Point(237, 405)
        Me.cbEAC.Name = "cbEAC"
        Me.cbEAC.Size = New System.Drawing.Size(15, 14)
        Me.cbEAC.TabIndex = 281
        Me.cbEAC.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(180, 400)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 21)
        Me.Label17.TabIndex = 280
        Me.Label17.Text = "EAC"
        '
        'cbCMIN
        '
        Me.cbCMIN.AutoSize = True
        Me.cbCMIN.Location = New System.Drawing.Point(72, 405)
        Me.cbCMIN.Name = "cbCMIN"
        Me.cbCMIN.Size = New System.Drawing.Size(15, 14)
        Me.cbCMIN.TabIndex = 279
        Me.cbCMIN.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 399)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 21)
        Me.Label18.TabIndex = 278
        Me.Label18.Text = "Cmin"
        '
        'cbCE
        '
        Me.cbCE.AutoSize = True
        Me.cbCE.Location = New System.Drawing.Point(236, 376)
        Me.cbCE.Name = "cbCE"
        Me.cbCE.Size = New System.Drawing.Size(15, 14)
        Me.cbCE.TabIndex = 273
        Me.cbCE.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(192, 371)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 21)
        Me.Label16.TabIndex = 272
        Me.Label16.Text = "CE"
        '
        'cbMadeInSpain
        '
        Me.cbMadeInSpain.AutoSize = True
        Me.cbMadeInSpain.Location = New System.Drawing.Point(145, 374)
        Me.cbMadeInSpain.Name = "cbMadeInSpain"
        Me.cbMadeInSpain.Size = New System.Drawing.Size(15, 14)
        Me.cbMadeInSpain.TabIndex = 271
        Me.cbMadeInSpain.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 369)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 21)
        Me.Label8.TabIndex = 270
        Me.Label8.Text = "MADE IN SPAIN"
        '
        'txOutPut
        '
        Me.txOutPut.Location = New System.Drawing.Point(463, 101)
        Me.txOutPut.MaxLength = 100
        Me.txOutPut.Name = "txOutPut"
        Me.txOutPut.Size = New System.Drawing.Size(249, 31)
        Me.txOutPut.TabIndex = 258
        '
        'txArticuloCliente
        '
        Me.txArticuloCliente.Location = New System.Drawing.Point(463, 65)
        Me.txArticuloCliente.MaxLength = 100
        Me.txArticuloCliente.Name = "txArticuloCliente"
        Me.txArticuloCliente.ReadOnly = True
        Me.txArticuloCliente.Size = New System.Drawing.Size(249, 31)
        Me.txArticuloCliente.TabIndex = 257
        '
        'txArticulo
        '
        Me.txArticulo.Location = New System.Drawing.Point(463, 30)
        Me.txArticulo.Name = "txArticulo"
        Me.txArticulo.ReadOnly = True
        Me.txArticulo.Size = New System.Drawing.Size(249, 31)
        Me.txArticulo.TabIndex = 256
        '
        'lbOutPut
        '
        Me.lbOutPut.AutoSize = True
        Me.lbOutPut.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOutPut.Location = New System.Drawing.Point(357, 106)
        Me.lbOutPut.Name = "lbOutPut"
        Me.lbOutPut.Size = New System.Drawing.Size(71, 21)
        Me.lbOutPut.TabIndex = 255
        Me.lbOutPut.Text = "OUTPUT"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(357, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 21)
        Me.Label19.TabIndex = 254
        Me.Label19.Text = "ART. CLI."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(357, 34)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 21)
        Me.Label20.TabIndex = 253
        Me.Label20.Text = "ARTÍCULO"
        '
        'txInput
        '
        Me.txInput.Location = New System.Drawing.Point(117, 72)
        Me.txInput.MaxLength = 100
        Me.txInput.Name = "txInput"
        Me.txInput.Size = New System.Drawing.Size(227, 31)
        Me.txInput.TabIndex = 252
        '
        'txCliente
        '
        Me.txCliente.Location = New System.Drawing.Point(117, 30)
        Me.txCliente.Name = "txCliente"
        Me.txCliente.ReadOnly = True
        Me.txCliente.Size = New System.Drawing.Size(227, 31)
        Me.txCliente.TabIndex = 250
        '
        'lbInput
        '
        Me.lbInput.AutoSize = True
        Me.lbInput.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInput.Location = New System.Drawing.Point(11, 77)
        Me.lbInput.Name = "lbInput"
        Me.lbInput.Size = New System.Drawing.Size(55, 21)
        Me.lbInput.TabIndex = 249
        Me.lbInput.Text = "INPUT"
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.Location = New System.Drawing.Point(11, 34)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(73, 21)
        Me.lbCliente.TabIndex = 247
        Me.lbCliente.Text = "CLIENTE"
        '
        'txEtiqueta5
        '
        Me.txEtiqueta5.Location = New System.Drawing.Point(117, 324)
        Me.txEtiqueta5.MaxLength = 100
        Me.txEtiqueta5.Name = "txEtiqueta5"
        Me.txEtiqueta5.Size = New System.Drawing.Size(227, 31)
        Me.txEtiqueta5.TabIndex = 245
        '
        'txEtiqueta4
        '
        Me.txEtiqueta4.Location = New System.Drawing.Point(117, 280)
        Me.txEtiqueta4.MaxLength = 100
        Me.txEtiqueta4.Name = "txEtiqueta4"
        Me.txEtiqueta4.Size = New System.Drawing.Size(227, 31)
        Me.txEtiqueta4.TabIndex = 244
        '
        'txEtiqueta3
        '
        Me.txEtiqueta3.Location = New System.Drawing.Point(117, 239)
        Me.txEtiqueta3.MaxLength = 100
        Me.txEtiqueta3.Name = "txEtiqueta3"
        Me.txEtiqueta3.Size = New System.Drawing.Size(227, 31)
        Me.txEtiqueta3.TabIndex = 243
        '
        'txEtiqueta2
        '
        Me.txEtiqueta2.Location = New System.Drawing.Point(117, 196)
        Me.txEtiqueta2.MaxLength = 100
        Me.txEtiqueta2.Name = "txEtiqueta2"
        Me.txEtiqueta2.Size = New System.Drawing.Size(227, 31)
        Me.txEtiqueta2.TabIndex = 242
        '
        'txEtiqueta1
        '
        Me.txEtiqueta1.Location = New System.Drawing.Point(117, 156)
        Me.txEtiqueta1.MaxLength = 100
        Me.txEtiqueta1.Name = "txEtiqueta1"
        Me.txEtiqueta1.Size = New System.Drawing.Size(227, 31)
        Me.txEtiqueta1.TabIndex = 241
        '
        'txEtiqueta0
        '
        Me.txEtiqueta0.Location = New System.Drawing.Point(117, 113)
        Me.txEtiqueta0.MaxLength = 100
        Me.txEtiqueta0.Name = "txEtiqueta0"
        Me.txEtiqueta0.Size = New System.Drawing.Size(227, 31)
        Me.txEtiqueta0.TabIndex = 240
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 21)
        Me.Label7.TabIndex = 238
        Me.Label7.Text = "ETIQUETA 5"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 21)
        Me.Label11.TabIndex = 237
        Me.Label11.Text = "ETIQUETA 4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 244)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 21)
        Me.Label12.TabIndex = 236
        Me.Label12.Text = "ETIQUETA 3"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 21)
        Me.Label13.TabIndex = 235
        Me.Label13.Text = "ETIQUETA 2"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 21)
        Me.Label14.TabIndex = 234
        Me.Label14.Text = "ETIQUETA 1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 21)
        Me.Label15.TabIndex = 233
        Me.Label15.Text = "ETIQUETA 0"
        '
        'cbValor1
        '
        Me.cbValor1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor1.FormattingEnabled = True
        Me.cbValor1.Location = New System.Drawing.Point(443, 181)
        Me.cbValor1.MaxLength = 100
        Me.cbValor1.Name = "cbValor1"
        Me.cbValor1.Size = New System.Drawing.Size(269, 30)
        Me.cbValor1.TabIndex = 231
        '
        'cbValor2
        '
        Me.cbValor2.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor2.FormattingEnabled = True
        Me.cbValor2.Location = New System.Drawing.Point(443, 217)
        Me.cbValor2.MaxLength = 100
        Me.cbValor2.Name = "cbValor2"
        Me.cbValor2.Size = New System.Drawing.Size(269, 30)
        Me.cbValor2.TabIndex = 230
        '
        'cbValor3
        '
        Me.cbValor3.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor3.FormattingEnabled = True
        Me.cbValor3.Location = New System.Drawing.Point(443, 253)
        Me.cbValor3.MaxLength = 100
        Me.cbValor3.Name = "cbValor3"
        Me.cbValor3.Size = New System.Drawing.Size(269, 30)
        Me.cbValor3.TabIndex = 229
        '
        'cbValor4
        '
        Me.cbValor4.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor4.FormattingEnabled = True
        Me.cbValor4.Location = New System.Drawing.Point(443, 289)
        Me.cbValor4.MaxLength = 100
        Me.cbValor4.Name = "cbValor4"
        Me.cbValor4.Size = New System.Drawing.Size(269, 30)
        Me.cbValor4.TabIndex = 228
        '
        'cbValor5
        '
        Me.cbValor5.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor5.FormattingEnabled = True
        Me.cbValor5.Location = New System.Drawing.Point(443, 325)
        Me.cbValor5.MaxLength = 100
        Me.cbValor5.Name = "cbValor5"
        Me.cbValor5.Size = New System.Drawing.Size(269, 30)
        Me.cbValor5.TabIndex = 227
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(359, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 21)
        Me.Label9.TabIndex = 225
        Me.Label9.Text = "VALOR 5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(359, 293)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 21)
        Me.Label10.TabIndex = 224
        Me.Label10.Text = "VALOR 4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(359, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 21)
        Me.Label5.TabIndex = 223
        Me.Label5.Text = "VALOR 3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(359, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 21)
        Me.Label6.TabIndex = 222
        Me.Label6.Text = "VALOR 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(359, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 21)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "VALOR 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(359, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 21)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "VALOR 0"
        '
        'cbValor0
        '
        Me.cbValor0.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbValor0.FormattingEnabled = True
        Me.cbValor0.Location = New System.Drawing.Point(443, 145)
        Me.cbValor0.MaxLength = 100
        Me.cbValor0.Name = "cbValor0"
        Me.cbValor0.Size = New System.Drawing.Size(269, 30)
        Me.cbValor0.TabIndex = 218
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(117, 30)
        Me.ComboBox1.MaxLength = 100
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(227, 31)
        Me.ComboBox1.TabIndex = 259
        Me.ComboBox1.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(463, 30)
        Me.ComboBox2.MaxLength = 100
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(249, 31)
        Me.ComboBox2.TabIndex = 260
        Me.ComboBox2.Visible = False
        '
        'cbImpresoras
        '
        Me.cbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpresoras.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresoras.FormattingEnabled = True
        Me.cbImpresoras.Location = New System.Drawing.Point(358, 71)
        Me.cbImpresoras.Name = "cbImpresoras"
        Me.cbImpresoras.Size = New System.Drawing.Size(232, 30)
        Me.cbImpresoras.TabIndex = 228
        '
        'pbLogoERP
        '
        Me.pbLogoERP.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.pbLogoERP.Location = New System.Drawing.Point(12, 31)
        Me.pbLogoERP.Name = "pbLogoERP"
        Me.pbLogoERP.Size = New System.Drawing.Size(200, 71)
        Me.pbLogoERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbLogoERP.TabIndex = 234
        Me.pbLogoERP.TabStop = False
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(870, 31)
        Me.bImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(126, 70)
        Me.bImprimir.TabIndex = 231
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(249, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 21)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "IMPRESORA"
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1002, 31)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 70)
        Me.bSalir.TabIndex = 232
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'pnCrystalReport
        '
        Me.pnCrystalReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnCrystalReport.Controls.Add(Me.crPrv)
        Me.pnCrystalReport.Location = New System.Drawing.Point(738, 120)
        Me.pnCrystalReport.Name = "pnCrystalReport"
        Me.pnCrystalReport.Size = New System.Drawing.Size(390, 425)
        Me.pnCrystalReport.TabIndex = 233
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
        Me.crPrv.Location = New System.Drawing.Point(0, 0)
        Me.crPrv.Name = "crPrv"
        Me.crPrv.ShowGroupTreeButton = False
        Me.crPrv.Size = New System.Drawing.Size(390, 422)
        Me.crPrv.TabIndex = 0
        Me.crPrv.TabStop = False
        Me.crPrv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'imprimirEtiqueta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 591)
        Me.Controls.Add(Me.bLogosClientes)
        Me.Controls.Add(Me.bRecargar)
        Me.Controls.Add(Me.gbParametros)
        Me.Controls.Add(Me.cbImpresoras)
        Me.Controls.Add(Me.pbLogoERP)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.pnCrystalReport)
        Me.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "imprimirEtiqueta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Etiqueta"
        Me.gbParametros.ResumeLayout(False)
        Me.gbParametros.PerformLayout()
        CType(Me.pbLogoERP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnCrystalReport.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bLogosClientes As Button
    Friend WithEvents bRecargar As Button
    Friend WithEvents gbParametros As GroupBox
    Friend WithEvents cbUL As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbWEEEE As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cbLPX3 As CheckBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cbUKCA As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cbEAC As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cbCMIN As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cbCE As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbMadeInSpain As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txOutPut As TextBox
    Friend WithEvents txArticuloCliente As TextBox
    Friend WithEvents txArticulo As TextBox
    Friend WithEvents lbOutPut As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txInput As TextBox
    Friend WithEvents txCliente As TextBox
    Friend WithEvents lbInput As Label
    Friend WithEvents lbCliente As Label
    Friend WithEvents txEtiqueta5 As TextBox
    Friend WithEvents txEtiqueta4 As TextBox
    Friend WithEvents txEtiqueta3 As TextBox
    Friend WithEvents txEtiqueta2 As TextBox
    Friend WithEvents txEtiqueta1 As TextBox
    Friend WithEvents txEtiqueta0 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
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
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents cbImpresoras As ComboBox
    Friend WithEvents pbLogoERP As PictureBox
    Friend WithEvents bImprimir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents bSalir As Button
    Friend WithEvents pnCrystalReport As Panel
    Friend WithEvents crPrv As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
