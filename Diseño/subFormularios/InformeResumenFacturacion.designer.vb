<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeResumenFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeResumenFacturacion))
        Me.CRV = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.Label31 = New System.Windows.Forms.Label
        Me.cbAnyo = New System.Windows.Forms.ComboBox
        Me.cbMes = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.bPDF = New System.Windows.Forms.Button
        Me.bMail = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CRV
        '
        Me.CRV.ActiveViewIndex = -1
        Me.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CRV.DisplayGroupTree = False
        Me.CRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRV.Location = New System.Drawing.Point(0, 0)
        Me.CRV.Name = "CRV"
        Me.CRV.SelectionFormula = ""
        Me.CRV.ShowGroupTreeButton = False
        Me.CRV.ShowRefreshButton = False
        Me.CRV.Size = New System.Drawing.Size(1193, 778)
        Me.CRV.TabIndex = 0
        Me.CRV.ViewTimeSelectionFormula = ""
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(797, 12)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(88, 30)
        Me.bImprimir.TabIndex = 2
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1091, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 30)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label31.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label31.Location = New System.Drawing.Point(506, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(32, 17)
        Me.Label31.TabIndex = 161
        Me.Label31.Text = "MES"
        '
        'cbAnyo
        '
        Me.cbAnyo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAnyo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAnyo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAnyo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAnyo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnyo.FormattingEnabled = True
        Me.cbAnyo.Location = New System.Drawing.Point(700, 15)
        Me.cbAnyo.Name = "cbAnyo"
        Me.cbAnyo.Size = New System.Drawing.Size(58, 25)
        Me.cbAnyo.TabIndex = 1
        '
        'cbMes
        '
        Me.cbMes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(544, 15)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(95, 25)
        Me.cbMes.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(658, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "AÑO"
        '
        'bPDF
        '
        Me.bPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bPDF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPDF.Location = New System.Drawing.Point(895, 12)
        Me.bPDF.Name = "bPDF"
        Me.bPDF.Size = New System.Drawing.Size(88, 30)
        Me.bPDF.TabIndex = 3
        Me.bPDF.Text = "PDF"
        Me.bPDF.UseVisualStyleBackColor = True
        '
        'bMail
        '
        Me.bMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bMail.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bMail.Location = New System.Drawing.Point(993, 12)
        Me.bMail.Name = "bMail"
        Me.bMail.Size = New System.Drawing.Size(88, 30)
        Me.bMail.TabIndex = 4
        Me.bMail.Text = "E-MAIL"
        Me.bMail.UseVisualStyleBackColor = True
        '
        'InformeResumenFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 778)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.cbAnyo)
        Me.Controls.Add(Me.bMail)
        Me.Controls.Add(Me.bPDF)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.CRV)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InformeResumenFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME RESUMEN FACTURACIÓN"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRV As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cbAnyo As System.Windows.Forms.ComboBox
    Friend WithEvents cbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bPDF As System.Windows.Forms.Button
    Friend WithEvents bMail As System.Windows.Forms.Button
End Class
