<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImprimirEtiquetaFinalLinea
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbEAN13 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txArticuloCliente = New System.Windows.Forms.TextBox()
        Me.lbCliente = New System.Windows.Forms.Label()
        Me.cbImpresoras = New System.Windows.Forms.ComboBox()
        Me.txCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txArticulo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txPedidoVenta = New System.Windows.Forms.TextBox()
        Me.txNumSerie = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbUL = New System.Windows.Forms.CheckBox()
        Me.cbMadeInSpain = New System.Windows.Forms.CheckBox()
        Me.cbWEEEE = New System.Windows.Forms.CheckBox()
        Me.cbLPX3 = New System.Windows.Forms.CheckBox()
        Me.cbUKCA = New System.Windows.Forms.CheckBox()
        Me.cbEAC = New System.Windows.Forms.CheckBox()
        Me.cbCMIN = New System.Windows.Forms.CheckBox()
        Me.cbCE = New System.Windows.Forms.CheckBox()
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pbLogoERP = New System.Windows.Forms.PictureBox()
        Me.bLogosClientes = New System.Windows.Forms.Button()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bImprimir = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbLogoERP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tbEAN13)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txArticuloCliente)
        Me.GroupBox2.Controls.Add(Me.lbCliente)
        Me.GroupBox2.Controls.Add(Me.cbImpresoras)
        Me.GroupBox2.Controls.Add(Me.txCliente)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txArticulo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txPedidoVenta)
        Me.GroupBox2.Controls.Add(Me.txNumSerie)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(492, 309)
        Me.GroupBox2.TabIndex = 338
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DATOS DE LA ETIQUETA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 274)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 21)
        Me.Label2.TabIndex = 329
        Me.Label2.Text = "EAN13"
        '
        'tbEAN13
        '
        Me.tbEAN13.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEAN13.Location = New System.Drawing.Point(130, 271)
        Me.tbEAN13.Name = "tbEAN13"
        Me.tbEAN13.Size = New System.Drawing.Size(353, 27)
        Me.tbEAN13.TabIndex = 330
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 21)
        Me.Label1.TabIndex = 327
        Me.Label1.Text = "ARTÍCULO CL"
        '
        'txArticuloCliente
        '
        Me.txArticuloCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticuloCliente.Location = New System.Drawing.Point(130, 160)
        Me.txArticuloCliente.Name = "txArticuloCliente"
        Me.txArticuloCliente.Size = New System.Drawing.Size(353, 27)
        Me.txArticuloCliente.TabIndex = 328
        '
        'lbCliente
        '
        Me.lbCliente.AutoSize = True
        Me.lbCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCliente.Location = New System.Drawing.Point(6, 79)
        Me.lbCliente.Name = "lbCliente"
        Me.lbCliente.Size = New System.Drawing.Size(73, 21)
        Me.lbCliente.TabIndex = 310
        Me.lbCliente.Text = "CLIENTE"
        '
        'cbImpresoras
        '
        Me.cbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImpresoras.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImpresoras.FormattingEnabled = True
        Me.cbImpresoras.Location = New System.Drawing.Point(130, 32)
        Me.cbImpresoras.Name = "cbImpresoras"
        Me.cbImpresoras.Size = New System.Drawing.Size(353, 30)
        Me.cbImpresoras.TabIndex = 325
        '
        'txCliente
        '
        Me.txCliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCliente.Location = New System.Drawing.Point(130, 76)
        Me.txCliente.Name = "txCliente"
        Me.txCliente.ReadOnly = True
        Me.txCliente.Size = New System.Drawing.Size(353, 27)
        Me.txCliente.TabIndex = 311
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 21)
        Me.Label6.TabIndex = 326
        Me.Label6.Text = "IMPRESORA"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 122)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 21)
        Me.Label20.TabIndex = 312
        Me.Label20.Text = "ARTÍCULO"
        '
        'txArticulo
        '
        Me.txArticulo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txArticulo.Location = New System.Drawing.Point(130, 119)
        Me.txArticulo.Name = "txArticulo"
        Me.txArticulo.ReadOnly = True
        Me.txArticulo.Size = New System.Drawing.Size(353, 27)
        Me.txArticulo.TabIndex = 313
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 21)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "PV"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 21)
        Me.Label5.TabIndex = 319
        Me.Label5.Text = "NUM. SERIE"
        '
        'txPedidoVenta
        '
        Me.txPedidoVenta.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPedidoVenta.Location = New System.Drawing.Point(130, 234)
        Me.txPedidoVenta.Name = "txPedidoVenta"
        Me.txPedidoVenta.ReadOnly = True
        Me.txPedidoVenta.Size = New System.Drawing.Size(353, 27)
        Me.txPedidoVenta.TabIndex = 321
        '
        'txNumSerie
        '
        Me.txNumSerie.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNumSerie.Location = New System.Drawing.Point(130, 198)
        Me.txNumSerie.Name = "txNumSerie"
        Me.txNumSerie.ReadOnly = True
        Me.txNumSerie.Size = New System.Drawing.Size(353, 27)
        Me.txNumSerie.TabIndex = 320
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbUL)
        Me.GroupBox1.Controls.Add(Me.cbMadeInSpain)
        Me.GroupBox1.Controls.Add(Me.cbWEEEE)
        Me.GroupBox1.Controls.Add(Me.cbLPX3)
        Me.GroupBox1.Controls.Add(Me.cbUKCA)
        Me.GroupBox1.Controls.Add(Me.cbEAC)
        Me.GroupBox1.Controls.Add(Me.cbCMIN)
        Me.GroupBox1.Controls.Add(Me.cbCE)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 405)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 82)
        Me.GroupBox1.TabIndex = 337
        Me.GroupBox1.TabStop = False
        '
        'cbUL
        '
        Me.cbUL.AutoSize = True
        Me.cbUL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbUL.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUL.Location = New System.Drawing.Point(115, 50)
        Me.cbUL.Name = "cbUL"
        Me.cbUL.Size = New System.Drawing.Size(51, 25)
        Me.cbUL.TabIndex = 325
        Me.cbUL.Text = "UL "
        Me.cbUL.UseVisualStyleBackColor = True
        '
        'cbMadeInSpain
        '
        Me.cbMadeInSpain.AutoSize = True
        Me.cbMadeInSpain.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbMadeInSpain.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMadeInSpain.Location = New System.Drawing.Point(312, 50)
        Me.cbMadeInSpain.Name = "cbMadeInSpain"
        Me.cbMadeInSpain.Size = New System.Drawing.Size(150, 25)
        Me.cbMadeInSpain.TabIndex = 323
        Me.cbMadeInSpain.Text = "MADE IN SPAIN"
        Me.cbMadeInSpain.UseVisualStyleBackColor = True
        '
        'cbWEEEE
        '
        Me.cbWEEEE.AutoSize = True
        Me.cbWEEEE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbWEEEE.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbWEEEE.Location = New System.Drawing.Point(201, 19)
        Me.cbWEEEE.Name = "cbWEEEE"
        Me.cbWEEEE.Size = New System.Drawing.Size(75, 25)
        Me.cbWEEEE.TabIndex = 321
        Me.cbWEEEE.Text = "WEEE "
        Me.cbWEEEE.UseVisualStyleBackColor = True
        '
        'cbLPX3
        '
        Me.cbLPX3.AutoSize = True
        Me.cbLPX3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLPX3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLPX3.Location = New System.Drawing.Point(10, 50)
        Me.cbLPX3.Name = "cbLPX3"
        Me.cbLPX3.Size = New System.Drawing.Size(61, 25)
        Me.cbLPX3.TabIndex = 319
        Me.cbLPX3.Text = "IPX3"
        Me.cbLPX3.UseVisualStyleBackColor = True
        '
        'cbUKCA
        '
        Me.cbUKCA.AutoSize = True
        Me.cbUKCA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbUKCA.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUKCA.Location = New System.Drawing.Point(312, 19)
        Me.cbUKCA.Name = "cbUKCA"
        Me.cbUKCA.Size = New System.Drawing.Size(75, 25)
        Me.cbUKCA.TabIndex = 317
        Me.cbUKCA.Text = "UKCA"
        Me.cbUKCA.UseVisualStyleBackColor = True
        '
        'cbEAC
        '
        Me.cbEAC.AutoSize = True
        Me.cbEAC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbEAC.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEAC.Location = New System.Drawing.Point(10, 19)
        Me.cbEAC.Name = "cbEAC"
        Me.cbEAC.Size = New System.Drawing.Size(64, 25)
        Me.cbEAC.TabIndex = 315
        Me.cbEAC.Text = "EAC"
        Me.cbEAC.UseVisualStyleBackColor = True
        '
        'cbCMIN
        '
        Me.cbCMIN.AutoSize = True
        Me.cbCMIN.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbCMIN.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCMIN.Location = New System.Drawing.Point(201, 50)
        Me.cbCMIN.Name = "cbCMIN"
        Me.cbCMIN.Size = New System.Drawing.Size(74, 25)
        Me.cbCMIN.TabIndex = 313
        Me.cbCMIN.Text = "CMIN"
        Me.cbCMIN.UseVisualStyleBackColor = True
        '
        'cbCE
        '
        Me.cbCE.AutoSize = True
        Me.cbCE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbCE.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCE.Location = New System.Drawing.Point(115, 19)
        Me.cbCE.Name = "cbCE"
        Me.cbCE.Size = New System.Drawing.Size(51, 25)
        Me.cbCE.TabIndex = 311
        Me.cbCE.Text = "CE"
        Me.cbCE.UseVisualStyleBackColor = True
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crViewer.DisplayBackgroundEdge = False
        Me.crViewer.DisplayStatusBar = False
        Me.crViewer.EnableToolTips = False
        Me.crViewer.Location = New System.Drawing.Point(510, 97)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.ShowCloseButton = False
        Me.crViewer.ShowCopyButton = False
        Me.crViewer.ShowExportButton = False
        Me.crViewer.ShowGotoPageButton = False
        Me.crViewer.ShowGroupTreeButton = False
        Me.crViewer.ShowLogo = False
        Me.crViewer.ShowPageNavigateButtons = False
        Me.crViewer.ShowParameterPanelButton = False
        Me.crViewer.ShowPrintButton = False
        Me.crViewer.ShowRefreshButton = False
        Me.crViewer.ShowTextSearchButton = False
        Me.crViewer.ShowZoomButton = False
        Me.crViewer.Size = New System.Drawing.Size(436, 392)
        Me.crViewer.TabIndex = 331
        Me.crViewer.TabStop = False
        Me.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'pbLogoERP
        '
        Me.pbLogoERP.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.pbLogoERP.Location = New System.Drawing.Point(12, 13)
        Me.pbLogoERP.Name = "pbLogoERP"
        Me.pbLogoERP.Size = New System.Drawing.Size(200, 71)
        Me.pbLogoERP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbLogoERP.TabIndex = 336
        Me.pbLogoERP.TabStop = False
        '
        'bLogosClientes
        '
        Me.bLogosClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLogosClientes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLogosClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLogosClientes.Location = New System.Drawing.Point(556, 13)
        Me.bLogosClientes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLogosClientes.Name = "bLogosClientes"
        Me.bLogosClientes.Size = New System.Drawing.Size(126, 77)
        Me.bLogosClientes.TabIndex = 333
        Me.bLogosClientes.Text = "LOGOS LOGÍSTICA CLIENTES"
        Me.bLogosClientes.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(424, 13)
        Me.bGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(126, 77)
        Me.bGuardar.TabIndex = 332
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(688, 13)
        Me.bImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(126, 77)
        Me.bImprimir.TabIndex = 334
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(820, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(126, 77)
        Me.bSalir.TabIndex = 335
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'ImprimirEtiquetaFinalLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 499)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.crViewer)
        Me.Controls.Add(Me.pbLogoERP)
        Me.Controls.Add(Me.bLogosClientes)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bSalir)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImprimirEtiquetaFinalLinea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR ETIQUETA FINAL"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbLogoERP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbCliente As Label
    Friend WithEvents cbImpresoras As ComboBox
    Friend WithEvents txCliente As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txArticulo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txPedidoVenta As TextBox
    Friend WithEvents txNumSerie As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbUL As CheckBox
    Friend WithEvents cbMadeInSpain As CheckBox
    Friend WithEvents cbWEEEE As CheckBox
    Friend WithEvents cbLPX3 As CheckBox
    Friend WithEvents cbUKCA As CheckBox
    Friend WithEvents cbEAC As CheckBox
    Friend WithEvents cbCMIN As CheckBox
    Friend WithEvents cbCE As CheckBox
    Friend WithEvents pbLogoERP As PictureBox
    Friend WithEvents bLogosClientes As Button
    Friend WithEvents bGuardar As Button
    Friend WithEvents bImprimir As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txArticuloCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbEAN13 As TextBox
    Private WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
