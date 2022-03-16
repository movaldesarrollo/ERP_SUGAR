<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class escandallosCompletos
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
        Me.lvEscandallosySubescandallos = New System.Windows.Forms.ListView
        Me.lvID = New System.Windows.Forms.ColumnHeader
        Me.lvcIdarticulo = New System.Windows.Forms.ColumnHeader
        Me.lvcIdEscandallo = New System.Windows.Forms.ColumnHeader
        Me.lvcSubEscandallo = New System.Windows.Forms.ColumnHeader
        Me.lvcArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSubfamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSeccion = New System.Windows.Forms.ColumnHeader
        Me.lvcCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvUnidad = New System.Windows.Forms.ColumnHeader
        Me.lvCoste = New System.Windows.Forms.ColumnHeader
        Me.lvMoneda = New System.Windows.Forms.ColumnHeader
        Me.lvEscandallo = New System.Windows.Forms.ColumnHeader
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.bSalir = New System.Windows.Forms.Button
        Me.txIdEscandallo = New System.Windows.Forms.TextBox
        Me.lbId = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ckMateriasPrimas = New System.Windows.Forms.CheckBox
        Me.lbCostelTotal = New System.Windows.Forms.Label
        Me.txCosteTotal = New System.Windows.Forms.TextBox
        Me.bImprimir = New System.Windows.Forms.Button
        Me.lbEscandallo = New System.Windows.Forms.Label
        Me.txEscandallo = New System.Windows.Forms.TextBox
        Me.lbVersion = New System.Windows.Forms.Label
        Me.txVersion = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvEscandallosySubescandallos
        '
        Me.lvEscandallosySubescandallos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEscandallosySubescandallos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvID, Me.lvcIdarticulo, Me.lvcIdEscandallo, Me.lvcSubEscandallo, Me.lvcArticulo, Me.lvFamilia, Me.lvSubfamilia, Me.lvSeccion, Me.lvcCantidad, Me.lvUnidad, Me.lvCoste, Me.lvMoneda, Me.lvEscandallo})
        Me.lvEscandallosySubescandallos.FullRowSelect = True
        Me.lvEscandallosySubescandallos.GridLines = True
        Me.lvEscandallosySubescandallos.Location = New System.Drawing.Point(12, 156)
        Me.lvEscandallosySubescandallos.Name = "lvEscandallosySubescandallos"
        Me.lvEscandallosySubescandallos.Size = New System.Drawing.Size(1328, 597)
        Me.lvEscandallosySubescandallos.TabIndex = 0
        Me.lvEscandallosySubescandallos.UseCompatibleStateImageBehavior = False
        Me.lvEscandallosySubescandallos.View = System.Windows.Forms.View.Details
        '
        'lvID
        '
        Me.lvID.Text = "ID"
        Me.lvID.Width = 85
        '
        'lvcIdarticulo
        '
        Me.lvcIdarticulo.Text = "ID ARTÍCULO"
        Me.lvcIdarticulo.Width = 100
        '
        'lvcIdEscandallo
        '
        Me.lvcIdEscandallo.Text = "ID ESCANDALLO"
        Me.lvcIdEscandallo.Width = 0
        '
        'lvcSubEscandallo
        '
        Me.lvcSubEscandallo.Text = "ID SUBESCANDALLO"
        Me.lvcSubEscandallo.Width = 0
        '
        'lvcArticulo
        '
        Me.lvcArticulo.Text = "ARTÍCULO"
        Me.lvcArticulo.Width = 396
        '
        'lvFamilia
        '
        Me.lvFamilia.Text = "FAMILIA"
        Me.lvFamilia.Width = 150
        '
        'lvSubfamilia
        '
        Me.lvSubfamilia.Text = "SUBFAMILIA"
        Me.lvSubfamilia.Width = 150
        '
        'lvSeccion
        '
        Me.lvSeccion.Text = "SECCIÓN"
        Me.lvSeccion.Width = 158
        '
        'lvcCantidad
        '
        Me.lvcCantidad.Text = "CANTIDAD"
        Me.lvcCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvcCantidad.Width = 100
        '
        'lvUnidad
        '
        Me.lvUnidad.Text = ""
        Me.lvUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvUnidad.Width = 30
        '
        'lvCoste
        '
        Me.lvCoste.Text = "COSTE"
        Me.lvCoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCoste.Width = 100
        '
        'lvMoneda
        '
        Me.lvMoneda.Text = ""
        Me.lvMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvMoneda.Width = 30
        '
        'lvEscandallo
        '
        Me.lvEscandallo.Text = "ESCANDALLO"
        Me.lvEscandallo.Width = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkGreen
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "SUBESCANDALLO 1"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DarkOrange
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(132, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "SUBESCANDALLO 2"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DarkRed
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(247, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = " SUBESCANDALLO 3"
        Me.Label3.Visible = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1258, 21)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 17
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'txIdEscandallo
        '
        Me.txIdEscandallo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txIdEscandallo.Location = New System.Drawing.Point(132, 97)
        Me.txIdEscandallo.Name = "txIdEscandallo"
        Me.txIdEscandallo.ReadOnly = True
        Me.txIdEscandallo.Size = New System.Drawing.Size(100, 24)
        Me.txIdEscandallo.TabIndex = 18
        Me.txIdEscandallo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbId
        '
        Me.lbId.AutoSize = True
        Me.lbId.BackColor = System.Drawing.SystemColors.Control
        Me.lbId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbId.ForeColor = System.Drawing.Color.Black
        Me.lbId.Location = New System.Drawing.Point(12, 102)
        Me.lbId.Name = "lbId"
        Me.lbId.Size = New System.Drawing.Size(114, 15)
        Me.lbId.TabIndex = 19
        Me.lbId.Text = "ID ESCANDALLO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(365, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = " SUBESCANDALLO 4"
        Me.Label4.Visible = False
        '
        'ckMateriasPrimas
        '
        Me.ckMateriasPrimas.AutoSize = True
        Me.ckMateriasPrimas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckMateriasPrimas.Location = New System.Drawing.Point(1166, 128)
        Me.ckMateriasPrimas.Name = "ckMateriasPrimas"
        Me.ckMateriasPrimas.Size = New System.Drawing.Size(177, 17)
        Me.ckMateriasPrimas.TabIndex = 21
        Me.ckMateriasPrimas.Text = "SOLO MATERIAS PRIMAS"
        Me.ckMateriasPrimas.UseVisualStyleBackColor = True
        '
        'lbCostelTotal
        '
        Me.lbCostelTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCostelTotal.AutoSize = True
        Me.lbCostelTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lbCostelTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCostelTotal.ForeColor = System.Drawing.Color.Black
        Me.lbCostelTotal.Location = New System.Drawing.Point(1078, 764)
        Me.lbCostelTotal.Name = "lbCostelTotal"
        Me.lbCostelTotal.Size = New System.Drawing.Size(98, 15)
        Me.lbCostelTotal.TabIndex = 23
        Me.lbCostelTotal.Text = "COSTE TOTAL"
        '
        'txCosteTotal
        '
        Me.txCosteTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txCosteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCosteTotal.Location = New System.Drawing.Point(1182, 759)
        Me.txCosteTotal.Name = "txCosteTotal"
        Me.txCosteTotal.ReadOnly = True
        Me.txCosteTotal.Size = New System.Drawing.Size(158, 24)
        Me.txCosteTotal.TabIndex = 22
        Me.txCosteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(1167, 21)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 24
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'lbEscandallo
        '
        Me.lbEscandallo.AutoSize = True
        Me.lbEscandallo.BackColor = System.Drawing.SystemColors.Control
        Me.lbEscandallo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEscandallo.ForeColor = System.Drawing.Color.Black
        Me.lbEscandallo.Location = New System.Drawing.Point(248, 102)
        Me.lbEscandallo.Name = "lbEscandallo"
        Me.lbEscandallo.Size = New System.Drawing.Size(96, 15)
        Me.lbEscandallo.TabIndex = 26
        Me.lbEscandallo.Text = "ESCANDALLO"
        '
        'txEscandallo
        '
        Me.txEscandallo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txEscandallo.Location = New System.Drawing.Point(350, 97)
        Me.txEscandallo.Name = "txEscandallo"
        Me.txEscandallo.ReadOnly = True
        Me.txEscandallo.Size = New System.Drawing.Size(788, 24)
        Me.txEscandallo.TabIndex = 25
        Me.txEscandallo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbVersion
        '
        Me.lbVersion.AutoSize = True
        Me.lbVersion.BackColor = System.Drawing.SystemColors.Control
        Me.lbVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbVersion.ForeColor = System.Drawing.Color.Black
        Me.lbVersion.Location = New System.Drawing.Point(1144, 102)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(67, 15)
        Me.lbVersion.TabIndex = 28
        Me.lbVersion.Text = "VERSIÓN"
        '
        'txVersion
        '
        Me.txVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txVersion.Location = New System.Drawing.Point(1217, 97)
        Me.txVersion.Name = "txVersion"
        Me.txVersion.ReadOnly = True
        Me.txVersion.Size = New System.Drawing.Size(126, 24)
        Me.txVersion.TabIndex = 27
        Me.txVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Purple
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(483, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = " SUBESCANDALLO 5"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Red
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(601, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = " SUBESCANDALLO 6"
        Me.Label6.Visible = False
        '
        'escandallosCompletos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1355, 795)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbVersion)
        Me.Controls.Add(Me.txVersion)
        Me.Controls.Add(Me.lbEscandallo)
        Me.Controls.Add(Me.txEscandallo)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.lbCostelTotal)
        Me.Controls.Add(Me.txCosteTotal)
        Me.Controls.Add(Me.ckMateriasPrimas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbId)
        Me.Controls.Add(Me.txIdEscandallo)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lvEscandallosySubescandallos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "escandallosCompletos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESCANDALOS COMPLETOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvEscandallosySubescandallos As System.Windows.Forms.ListView
    Friend WithEvents lvcIdEscandallo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcSubEscandallo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcIdarticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents txIdEscandallo As System.Windows.Forms.TextBox
    Friend WithEvents lbId As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lvID As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubfamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCoste As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvEscandallo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckMateriasPrimas As System.Windows.Forms.CheckBox
    Friend WithEvents lbCostelTotal As System.Windows.Forms.Label
    Friend WithEvents txCosteTotal As System.Windows.Forms.TextBox
    Friend WithEvents lvUnidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents lbEscandallo As System.Windows.Forms.Label
    Friend WithEvents txEscandallo As System.Windows.Forms.TextBox
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents txVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
