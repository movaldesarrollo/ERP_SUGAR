<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subVerIVAs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subVerIVAs))
        Me.lvIVAs = New System.Windows.Forms.ListView
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvBaseI = New System.Windows.Forms.ColumnHeader
        Me.lvTipoIVAI = New System.Windows.Forms.ColumnHeader
        Me.lvImporteIVA = New System.Windows.Forms.ColumnHeader
        Me.lvTipoRE = New System.Windows.Forms.ColumnHeader
        Me.lvImporteRE = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bCancelar = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvIVAs
        '
        Me.lvIVAs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvIVAs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidConcepto, Me.lvBaseI, Me.lvTipoIVAI, Me.lvImporteIVA, Me.lvTipoRE, Me.lvImporteRE})
        Me.lvIVAs.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lvIVAs.FullRowSelect = True
        Me.lvIVAs.GridLines = True
        Me.lvIVAs.Location = New System.Drawing.Point(21, 83)
        Me.lvIVAs.MultiSelect = False
        Me.lvIVAs.Name = "lvIVAs"
        Me.lvIVAs.Size = New System.Drawing.Size(509, 110)
        Me.lvIVAs.TabIndex = 200
        Me.lvIVAs.UseCompatibleStateImageBehavior = False
        Me.lvIVAs.View = System.Windows.Forms.View.Details
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvBaseI
        '
        Me.lvBaseI.Text = "BASE"
        Me.lvBaseI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvBaseI.Width = 107
        '
        'lvTipoIVAI
        '
        Me.lvTipoIVAI.Text = "TIPOIVA"
        Me.lvTipoIVAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTipoIVAI.Width = 80
        '
        'lvImporteIVA
        '
        Me.lvImporteIVA.Text = "IMPORTE IVA"
        Me.lvImporteIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImporteIVA.Width = 99
        '
        'lvTipoRE
        '
        Me.lvTipoRE.Text = "TIPO RE"
        Me.lvTipoRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTipoRE.Width = 87
        '
        'lvImporteRE
        '
        Me.lvImporteRE.Text = "IMPORTE RE"
        Me.lvImporteRE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImporteRE.Width = 105
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(21, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 202
        Me.PictureBox1.TabStop = False
        '
        'bCancelar
        '
        Me.bCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCancelar.Location = New System.Drawing.Point(442, 12)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(88, 50)
        Me.bCancelar.TabIndex = 201
        Me.bCancelar.Text = "SALIR"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'subVerIVAs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 212)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.lvIVAs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "subVerIVAs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DESGLOSE IVA FACTURA PROVEEDOR"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvIVAs As System.Windows.Forms.ListView
    Friend WithEvents lvBaseI As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipoIVAI As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporteIVA As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvTipoRE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporteRE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bCancelar As System.Windows.Forms.Button
End Class
