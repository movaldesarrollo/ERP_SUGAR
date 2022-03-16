<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaLiquidaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaLiquidaciones))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox
        Me.id = New System.Windows.Forms.TextBox
        Me.cbMes = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cbTrimestre = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbResponsable = New System.Windows.Forms.ComboBox
        Me.cbAño = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.lvDocumentos = New System.Windows.Forms.ListView
        Me.lvidLiquidacion = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvComercial = New System.Windows.Forms.ColumnHeader
        Me.lvImporte = New System.Windows.Forms.ColumnHeader
        Me.Total = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frdatosgenerales.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 203
        Me.PictureBox1.TabStop = False
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.id)
        Me.frdatosgenerales.Controls.Add(Me.cbMes)
        Me.frdatosgenerales.Controls.Add(Me.Label19)
        Me.frdatosgenerales.Controls.Add(Me.cbTrimestre)
        Me.frdatosgenerales.Controls.Add(Me.Label14)
        Me.frdatosgenerales.Controls.Add(Me.Label8)
        Me.frdatosgenerales.Controls.Add(Me.cbResponsable)
        Me.frdatosgenerales.Controls.Add(Me.cbAño)
        Me.frdatosgenerales.Controls.Add(Me.Label3)
        Me.frdatosgenerales.Controls.Add(Me.Label4)
        Me.frdatosgenerales.Controls.Add(Me.dtpHasta)
        Me.frdatosgenerales.Controls.Add(Me.Label13)
        Me.frdatosgenerales.Controls.Add(Me.Label9)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesde)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(11, 98)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(575, 131)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARAMETROS DE BÚSQUEDA"
        '
        'id
        '
        Me.id.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.Location = New System.Drawing.Point(53, 30)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(81, 23)
        Me.id.TabIndex = 0
        '
        'cbMes
        '
        Me.cbMes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(437, 61)
        Me.cbMes.MaxLength = 15
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(110, 25)
        Me.cbMes.TabIndex = 4
        Me.cbMes.Text = "NOVIEMBRE"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(6, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(21, 17)
        Me.Label19.TabIndex = 104
        Me.Label19.Text = "ID"
        '
        'cbTrimestre
        '
        Me.cbTrimestre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTrimestre.FormattingEnabled = True
        Me.cbTrimestre.Location = New System.Drawing.Point(248, 61)
        Me.cbTrimestre.MaxLength = 15
        Me.cbTrimestre.Name = "cbTrimestre"
        Me.cbTrimestre.Size = New System.Drawing.Size(110, 25)
        Me.cbTrimestre.TabIndex = 3
        Me.cbTrimestre.Text = "TRIMESTRE 1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(161, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 17)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "COMERCIAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(384, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 17)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "MES"
        '
        'cbResponsable
        '
        Me.cbResponsable.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbResponsable.FormattingEnabled = True
        Me.cbResponsable.Location = New System.Drawing.Point(248, 29)
        Me.cbResponsable.MaxLength = 15
        Me.cbResponsable.Name = "cbResponsable"
        Me.cbResponsable.Size = New System.Drawing.Size(299, 25)
        Me.cbResponsable.TabIndex = 1
        '
        'cbAño
        '
        Me.cbAño.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAño.FormattingEnabled = True
        Me.cbAño.Location = New System.Drawing.Point(52, 61)
        Me.cbAño.MaxLength = 15
        Me.cbAño.Name = "cbAño"
        Me.cbAño.Size = New System.Drawing.Size(82, 25)
        Me.cbAño.TabIndex = 2
        Me.cbAño.Text = "2012"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(384, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "HASTA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(8, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 17)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "AÑO"
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(436, 94)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(111, 23)
        Me.dtpHasta.TabIndex = 6
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(161, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "DESDE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(161, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 17)
        Me.Label9.TabIndex = 117
        Me.Label9.Text = "TRIMESTRE"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(248, 94)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(111, 23)
        Me.dtpDesde.TabIndex = 5
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bImprimir.Location = New System.Drawing.Point(289, 21)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 3
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(499, 21)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 5
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(394, 21)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 4
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'lvDocumentos
        '
        Me.lvDocumentos.AllowColumnReorder = True
        Me.lvDocumentos.AllowDrop = True
        Me.lvDocumentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDocumentos.AutoArrange = False
        Me.lvDocumentos.BackgroundImageTiled = True
        Me.lvDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidLiquidacion, Me.lvFecha, Me.lvComercial, Me.lvImporte})
        Me.lvDocumentos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDocumentos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDocumentos.FullRowSelect = True
        Me.lvDocumentos.GridLines = True
        Me.lvDocumentos.HideSelection = False
        Me.lvDocumentos.Location = New System.Drawing.Point(12, 235)
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.ShowItemToolTips = True
        Me.lvDocumentos.Size = New System.Drawing.Size(583, 453)
        Me.lvDocumentos.TabIndex = 1
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'lvidLiquidacion
        '
        Me.lvidLiquidacion.Text = "ID"
        Me.lvidLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvidLiquidacion.Width = 63
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 104
        '
        'lvComercial
        '
        Me.lvComercial.Text = "COMERCIAL"
        Me.lvComercial.Width = 261
        '
        'lvImporte
        '
        Me.lvImporte.Text = "IMPORTE"
        Me.lvImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvImporte.Width = 104
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(488, 694)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(90, 23)
        Me.Total.TabIndex = 2
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(580, 697)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 17)
        Me.Label7.TabIndex = 209
        Me.Label7.Text = "€"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(432, 697)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "TOTAL"
        '
        'BusquedaLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 723)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BusquedaLiquidaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE LIQUIDACIONES DE COMISIONES"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents id As System.Windows.Forms.TextBox
    Friend WithEvents cbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbTrimestre As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents cbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents lvidLiquidacion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvComercial As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvImporte As System.Windows.Forms.ColumnHeader
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
