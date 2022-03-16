<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaPeticionInternaMaterial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BusquedaPeticionInternaMaterial))
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.cbSubFamilia = New System.Windows.Forms.ComboBox
        Me.cbFamilia = New System.Windows.Forms.ComboBox
        Me.cbArticulo = New System.Windows.Forms.ComboBox
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox
        Me.Observaciones = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.bSalir = New System.Windows.Forms.Button
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvck = New System.Windows.Forms.ColumnHeader
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvcodArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvFecha = New System.Windows.Forms.ColumnHeader
        Me.lvPersona = New System.Windows.Forms.ColumnHeader
        Me.lvEstado = New System.Windows.Forms.ColumnHeader
        Me.lvObservaciones = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbEstado = New System.Windows.Forms.ComboBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(16, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 17)
        Me.Label16.TabIndex = 198
        Me.Label16.Text = "SUBFAMILIA"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(16, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 17)
        Me.Label21.TabIndex = 197
        Me.Label21.Text = "FAMILIA"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(16, 88)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(113, 17)
        Me.Label25.TabIndex = 196
        Me.Label25.Text = "OBSERVACIONES"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(293, 60)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 17)
        Me.Label39.TabIndex = 195
        Me.Label39.Text = "ARTÍCULO"
        '
        'cbSubFamilia
        '
        Me.cbSubFamilia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubFamilia.FormattingEnabled = True
        Me.cbSubFamilia.Location = New System.Drawing.Point(133, 56)
        Me.cbSubFamilia.Name = "cbSubFamilia"
        Me.cbSubFamilia.Size = New System.Drawing.Size(157, 25)
        Me.cbSubFamilia.TabIndex = 1
        '
        'cbFamilia
        '
        Me.cbFamilia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFamilia.FormattingEnabled = True
        Me.cbFamilia.Location = New System.Drawing.Point(133, 27)
        Me.cbFamilia.Name = "cbFamilia"
        Me.cbFamilia.Size = New System.Drawing.Size(157, 25)
        Me.cbFamilia.TabIndex = 0
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownWidth = 447
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(367, 56)
        Me.cbArticulo.MaxLength = 300
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(436, 25)
        Me.cbArticulo.Sorted = True
        Me.cbArticulo.TabIndex = 3
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(367, 27)
        Me.cbCodArticulo.MaxLength = 30
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(141, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 2
        '
        'Observaciones
        '
        Me.Observaciones.BackColor = System.Drawing.SystemColors.Window
        Me.Observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observaciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Observaciones.Location = New System.Drawing.Point(133, 85)
        Me.Observaciones.MaxLength = 300
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(670, 23)
        Me.Observaciones.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_150
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 199
        Me.PictureBox1.TabStop = False
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(747, 15)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(88, 50)
        Me.bSalir.TabIndex = 3
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'lvConceptos
        '
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvck, Me.lvidConcepto, Me.lvcodArticulo, Me.lvArticulo, Me.lvCantidad, Me.lvFecha, Me.lvPersona, Me.lvEstado, Me.lvObservaciones})
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(10, 118)
        Me.lvConceptos.MultiSelect = False
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(819, 399)
        Me.lvConceptos.TabIndex = 6
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvck
        '
        Me.lvck.Text = ""
        Me.lvck.Width = 0
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.Text = "CÓDIGO"
        Me.lvcodArticulo.Width = 96
        '
        'lvArticulo
        '
        Me.lvArticulo.Text = "ARTÍCULO"
        Me.lvArticulo.Width = 233
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 75
        '
        'lvFecha
        '
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 82
        '
        'lvPersona
        '
        Me.lvPersona.Text = "PEDIDO POR"
        Me.lvPersona.Width = 86
        '
        'lvEstado
        '
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 97
        '
        'lvObservaciones
        '
        Me.lvObservaciones.Text = "OBSERVACIONES"
        Me.lvObservaciones.Width = 120
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(292, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "CÓDIGO"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Contador)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cbEstado)
        Me.GroupBox1.Controls.Add(Me.lvConceptos)
        Me.GroupBox1.Controls.Add(Me.Observaciones)
        Me.GroupBox1.Controls.Add(Me.cbCodArticulo)
        Me.GroupBox1.Controls.Add(Me.cbArticulo)
        Me.GroupBox1.Controls.Add(Me.cbFamilia)
        Me.GroupBox1.Controls.Add(Me.cbSubFamilia)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(839, 558)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(769, 523)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 7
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(659, 526)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 209
        Me.Label6.Text = "ENCONTRADOS"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(560, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 17)
        Me.Label18.TabIndex = 207
        Me.Label18.Text = "ESTADO"
        '
        'cbEstado
        '
        Me.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(637, 28)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(166, 25)
        Me.cbEstado.Sorted = True
        Me.cbEstado.TabIndex = 4
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(530, 15)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(88, 50)
        Me.bLimpiar.TabIndex = 1
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(640, 15)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 2
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'BusquedaPeticionInternaMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 649)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BusquedaPeticionInternaMaterial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE PETICIONES INTERNAS DE MATERIAL"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbSubFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvck As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents lvPersona As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bNuevo As System.Windows.Forms.Button
End Class
