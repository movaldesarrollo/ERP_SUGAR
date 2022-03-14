<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fabricacionCelulas
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
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bEtiquetas = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cbCelulas = New System.Windows.Forms.ComboBox()
        Me.txCode = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lvCelulas = New System.Windows.Forms.ListView()
        Me.colIDCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumSerieCelula = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bBorrarCelula = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txTotalCelulas = New System.Windows.Forms.TextBox()
        Me.bBusquedaCelula = New System.Windows.Forms.Button()
        Me.btnSeleccionImp = New System.Windows.Forms.Button()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1098, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(150, 71)
        Me.bLimpiar.TabIndex = 6
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1254, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(150, 71)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bEtiquetas
        '
        Me.bEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEtiquetas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bEtiquetas.Location = New System.Drawing.Point(474, 13)
        Me.bEtiquetas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bEtiquetas.Name = "bEtiquetas"
        Me.bEtiquetas.Size = New System.Drawing.Size(150, 71)
        Me.bEtiquetas.TabIndex = 2
        Me.bEtiquetas.Text = "IMPRIMIR ETIQUETAS"
        Me.bEtiquetas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.cbCelulas)
        Me.GroupBox1.Controls.Add(Me.txCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 89)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1392, 68)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETALLES FABRICACIÓN DE CÉLULAS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "NºSERIE CÉLULA"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "CÓDIGO - ARTÍCULO"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1053, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "FECHA FABRICACIÓN"
        Me.Label3.Visible = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(1242, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(138, 27)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.Visible = False
        '
        'cbCelulas
        '
        Me.cbCelulas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCelulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCelulas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCelulas.FormattingEnabled = True
        Me.cbCelulas.Location = New System.Drawing.Point(188, 25)
        Me.cbCelulas.Name = "cbCelulas"
        Me.cbCelulas.Size = New System.Drawing.Size(859, 29)
        Me.cbCelulas.TabIndex = 0
        '
        'txCode
        '
        Me.txCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txCode.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCode.Location = New System.Drawing.Point(145, 26)
        Me.txCode.MaxLength = 11
        Me.txCode.Name = "txCode"
        Me.txCode.Size = New System.Drawing.Size(121, 27)
        Me.txCode.TabIndex = 0
        Me.txCode.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 155
        Me.PictureBox1.TabStop = False
        '
        'lvCelulas
        '
        Me.lvCelulas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCelulas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIDCelula, Me.colNumSerieCelula, Me.colArticulo, Me.colFecha})
        Me.lvCelulas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCelulas.FullRowSelect = True
        Me.lvCelulas.GridLines = True
        Me.lvCelulas.HideSelection = False
        Me.lvCelulas.Location = New System.Drawing.Point(12, 163)
        Me.lvCelulas.Name = "lvCelulas"
        Me.lvCelulas.Size = New System.Drawing.Size(1392, 465)
        Me.lvCelulas.TabIndex = 7
        Me.lvCelulas.UseCompatibleStateImageBehavior = False
        Me.lvCelulas.View = System.Windows.Forms.View.Details
        '
        'colIDCelula
        '
        Me.colIDCelula.Text = "IDCELULA"
        Me.colIDCelula.Width = 0
        '
        'colNumSerieCelula
        '
        Me.colNumSerieCelula.Text = "NºSERIE CÉLULA"
        Me.colNumSerieCelula.Width = 247
        '
        'colArticulo
        '
        Me.colArticulo.DisplayIndex = 3
        Me.colArticulo.Text = "CÓDIGO - ARTÍCULO"
        Me.colArticulo.Width = 698
        '
        'colFecha
        '
        Me.colFecha.DisplayIndex = 2
        Me.colFecha.Text = "FECHA FABRICACIÓN"
        Me.colFecha.Width = 256
        '
        'bBorrarCelula
        '
        Me.bBorrarCelula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrarCelula.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrarCelula.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrarCelula.Location = New System.Drawing.Point(942, 13)
        Me.bBorrarCelula.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBorrarCelula.Name = "bBorrarCelula"
        Me.bBorrarCelula.Size = New System.Drawing.Size(150, 71)
        Me.bBorrarCelula.TabIndex = 5
        Me.bBorrarCelula.Text = "BORRAR CELULA"
        Me.bBorrarCelula.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Green
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 631)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(451, 19)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "CÉLULAS ASIGNADAS A UN PEDIDO, NO SE PUEDEN BORRAR"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1156, 637)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 21)
        Me.Label5.TabIndex = 167
        Me.Label5.Text = "TOTAL CÉLULAS"
        '
        'txTotalCelulas
        '
        Me.txTotalCelulas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalCelulas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txTotalCelulas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotalCelulas.Location = New System.Drawing.Point(1294, 634)
        Me.txTotalCelulas.Name = "txTotalCelulas"
        Me.txTotalCelulas.Size = New System.Drawing.Size(110, 27)
        Me.txTotalCelulas.TabIndex = 8
        Me.txTotalCelulas.TabStop = False
        Me.txTotalCelulas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bBusquedaCelula
        '
        Me.bBusquedaCelula.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBusquedaCelula.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBusquedaCelula.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBusquedaCelula.Location = New System.Drawing.Point(318, 13)
        Me.bBusquedaCelula.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBusquedaCelula.Name = "bBusquedaCelula"
        Me.bBusquedaCelula.Size = New System.Drawing.Size(150, 71)
        Me.bBusquedaCelula.TabIndex = 1
        Me.bBusquedaCelula.Text = "BÚSQUEDA CÉLULA"
        Me.bBusquedaCelula.UseVisualStyleBackColor = True
        '
        'btnSeleccionImp
        '
        Me.btnSeleccionImp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSeleccionImp.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionImp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSeleccionImp.Location = New System.Drawing.Point(786, 13)
        Me.btnSeleccionImp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSeleccionImp.Name = "btnSeleccionImp"
        Me.btnSeleccionImp.Size = New System.Drawing.Size(150, 71)
        Me.btnSeleccionImp.TabIndex = 4
        Me.btnSeleccionImp.Text = "RESET IMPRESORAS"
        Me.btnSeleccionImp.UseVisualStyleBackColor = True
        '
        'btnReimprimir
        '
        Me.btnReimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReimprimir.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReimprimir.Location = New System.Drawing.Point(630, 13)
        Me.btnReimprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(150, 71)
        Me.btnReimprimir.TabIndex = 3
        Me.btnReimprimir.Text = "REIMPRIMIR ETIQUETAS"
        Me.btnReimprimir.UseVisualStyleBackColor = True
        '
        'fabricacionCelulas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1416, 677)
        Me.Controls.Add(Me.btnReimprimir)
        Me.Controls.Add(Me.btnSeleccionImp)
        Me.Controls.Add(Me.bBusquedaCelula)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txTotalCelulas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bBorrarCelula)
        Me.Controls.Add(Me.lvCelulas)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bEtiquetas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "fabricacionCelulas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FABRICACIÓN DE CÉLULAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bLimpiar As Button
    Friend WithEvents bSalir As Button
    Friend WithEvents bEtiquetas As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lvCelulas As ListView
    Friend WithEvents colIDCelula As ColumnHeader
    Friend WithEvents colNumSerieCelula As ColumnHeader
    Friend WithEvents colArticulo As ColumnHeader
    Friend WithEvents colFecha As ColumnHeader
    Friend WithEvents txCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cbCelulas As ComboBox
    Friend WithEvents bBorrarCelula As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txTotalCelulas As TextBox
    Friend WithEvents bBusquedaCelula As Button
    Friend WithEvents btnSeleccionImp As Button
    Friend WithEvents btnReimprimir As Button
End Class
