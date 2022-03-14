<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class recuperarEquiposBorrados
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
        Me.lvEquipos = New System.Windows.Forms.ListView()
        Me.colIdArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFechaFabricacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCreador = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEqNumSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bEjecutar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.txTotal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txCodigoBarras = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ckActivarFecha = New System.Windows.Forms.CheckBox()
        Me.dtpFechaInventario = New System.Windows.Forms.DateTimePicker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvEquipos
        '
        Me.lvEquipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEquipos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdArticulo, Me.colArticulo, Me.colFechaFabricacion, Me.colCreador, Me.colEqNumSerie})
        Me.lvEquipos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEquipos.FullRowSelect = True
        Me.lvEquipos.GridLines = True
        Me.lvEquipos.Location = New System.Drawing.Point(12, 126)
        Me.lvEquipos.Name = "lvEquipos"
        Me.lvEquipos.Size = New System.Drawing.Size(962, 462)
        Me.lvEquipos.TabIndex = 0
        Me.lvEquipos.TabStop = False
        Me.lvEquipos.UseCompatibleStateImageBehavior = False
        Me.lvEquipos.View = System.Windows.Forms.View.Details
        '
        'colIdArticulo
        '
        Me.colIdArticulo.Text = "ID ARTICULO"
        Me.colIdArticulo.Width = 0
        '
        'colArticulo
        '
        Me.colArticulo.Text = "ARTÍCULO"
        Me.colArticulo.Width = 311
        '
        'colFechaFabricacion
        '
        Me.colFechaFabricacion.Text = "FECHA FABRICACION"
        Me.colFechaFabricacion.Width = 158
        '
        'colCreador
        '
        Me.colCreador.Text = "ID CREADOR"
        Me.colCreador.Width = 108
        '
        'colEqNumSerie
        '
        Me.colEqNumSerie.Text = "EQUIPO NUM. SERIE"
        Me.colEqNumSerie.Width = 351
        '
        'bEjecutar
        '
        Me.bEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEjecutar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEjecutar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bEjecutar.Location = New System.Drawing.Point(512, 13)
        Me.bEjecutar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bEjecutar.Name = "bEjecutar"
        Me.bEjecutar.Size = New System.Drawing.Size(150, 71)
        Me.bEjecutar.TabIndex = 1
        Me.bEjecutar.Text = "EJECUTAR"
        Me.bEjecutar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(824, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(150, 71)
        Me.bSalir.TabIndex = 3
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(668, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(150, 71)
        Me.bLimpiar.TabIndex = 2
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'txTotal
        '
        Me.txTotal.Location = New System.Drawing.Point(874, 594)
        Me.txTotal.Name = "txTotal"
        Me.txTotal.Size = New System.Drawing.Size(100, 21)
        Me.txTotal.TabIndex = 12
        Me.txTotal.TabStop = False
        Me.txTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(821, 597)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "TOTAL"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox2.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 170
        Me.PictureBox2.TabStop = False
        '
        'txCodigoBarras
        '
        Me.txCodigoBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txCodigoBarras.Location = New System.Drawing.Point(91, 100)
        Me.txCodigoBarras.Name = "txCodigoBarras"
        Me.txCodigoBarras.Size = New System.Drawing.Size(293, 21)
        Me.txCodigoBarras.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "NÚM. SERIE"
        '
        'ckActivarFecha
        '
        Me.ckActivarFecha.AutoSize = True
        Me.ckActivarFecha.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckActivarFecha.Location = New System.Drawing.Point(399, 100)
        Me.ckActivarFecha.Name = "ckActivarFecha"
        Me.ckActivarFecha.Size = New System.Drawing.Size(127, 21)
        Me.ckActivarFecha.TabIndex = 178
        Me.ckActivarFecha.Text = "ACTIVAR FECHA"
        Me.ckActivarFecha.UseVisualStyleBackColor = True
        '
        'dtpFechaInventario
        '
        Me.dtpFechaInventario.CalendarFont = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.dtpFechaInventario.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInventario.Location = New System.Drawing.Point(541, 98)
        Me.dtpFechaInventario.Name = "dtpFechaInventario"
        Me.dtpFechaInventario.Size = New System.Drawing.Size(97, 21)
        Me.dtpFechaInventario.TabIndex = 179
        Me.dtpFechaInventario.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(668, 98)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(306, 21)
        Me.ProgressBar1.TabIndex = 180
        Me.ProgressBar1.Visible = False
        '
        'recuperarEquiposBorrados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.dtpFechaInventario)
        Me.Controls.Add(Me.ckActivarFecha)
        Me.Controls.Add(Me.txCodigoBarras)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txTotal)
        Me.Controls.Add(Me.bEjecutar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.lvEquipos)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "recuperarEquiposBorrados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECUPERAR ARCHIVOS ELIMINADOS DE STOCK"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvEquipos As ListView
    Friend WithEvents colIdArticulo As ColumnHeader
    Friend WithEvents colFechaFabricacion As ColumnHeader
    Friend WithEvents colCreador As ColumnHeader
    Friend WithEvents colEqNumSerie As ColumnHeader
    Friend WithEvents bEjecutar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents bLimpiar As Button
    Friend WithEvents txTotal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txCodigoBarras As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents colArticulo As ColumnHeader
    Friend WithEvents ckActivarFecha As CheckBox
    Friend WithEvents dtpFechaInventario As DateTimePicker
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
