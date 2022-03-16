<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gestionInventarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gestionInventarios))
        Me.bSalir = New System.Windows.Forms.Button
        Me.bImportar = New System.Windows.Forms.Button
        Me.bExportar = New System.Windows.Forms.Button
        Me.lvArticulos = New System.Windows.Forms.ListView
        Me.lvColIdArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvColCodArticulos = New System.Windows.Forms.ColumnHeader
        Me.lvColArticulo = New System.Windows.Forms.ColumnHeader
        Me.lvColStock = New System.Windows.Forms.ColumnHeader
        Me.lvcolUnidad = New System.Windows.Forms.ColumnHeader
        Me.lvColInventariado = New System.Windows.Forms.ColumnHeader
        Me.lvColSeccion = New System.Windows.Forms.ColumnHeader
        Me.lvColColor = New System.Windows.Forms.ColumnHeader
        Me.lvColPrecioUnitario = New System.Windows.Forms.ColumnHeader
        Me.lvColTotal = New System.Windows.Forms.ColumnHeader
        Me.bBuscar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Contador = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.rbTodos = New System.Windows.Forms.RadioButton
        Me.rbComprable = New System.Windows.Forms.RadioButton
        Me.rbVendible = New System.Windows.Forms.RadioButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.txIdArticulo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txArticulo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txCodigo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ckActivos = New System.Windows.Forms.CheckBox
        Me.cbSecciones = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txTotalPrecio = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1334, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(99, 62)
        Me.bSalir.TabIndex = 4
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bImportar
        '
        Me.bImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImportar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImportar.Location = New System.Drawing.Point(1227, 13)
        Me.bImportar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bImportar.Name = "bImportar"
        Me.bImportar.Size = New System.Drawing.Size(99, 62)
        Me.bImportar.TabIndex = 3
        Me.bImportar.Text = "IMPORTAR STOCK"
        Me.bImportar.UseVisualStyleBackColor = True
        '
        'bExportar
        '
        Me.bExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bExportar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bExportar.Location = New System.Drawing.Point(1121, 13)
        Me.bExportar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bExportar.Name = "bExportar"
        Me.bExportar.Size = New System.Drawing.Size(99, 62)
        Me.bExportar.TabIndex = 2
        Me.bExportar.Text = "EXPORTAR STOCK"
        Me.bExportar.UseVisualStyleBackColor = True
        '
        'lvArticulos
        '
        Me.lvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvColIdArticulo, Me.lvColCodArticulos, Me.lvColArticulo, Me.lvColStock, Me.lvcolUnidad, Me.lvColInventariado, Me.lvColSeccion, Me.lvColColor, Me.lvColPrecioUnitario, Me.lvColTotal})
        Me.lvArticulos.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lvArticulos.FullRowSelect = True
        Me.lvArticulos.GridLines = True
        Me.lvArticulos.Location = New System.Drawing.Point(12, 155)
        Me.lvArticulos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvArticulos.Name = "lvArticulos"
        Me.lvArticulos.Size = New System.Drawing.Size(1421, 730)
        Me.lvArticulos.TabIndex = 16
        Me.lvArticulos.TabStop = False
        Me.lvArticulos.UseCompatibleStateImageBehavior = False
        Me.lvArticulos.View = System.Windows.Forms.View.Details
        '
        'lvColIdArticulo
        '
        Me.lvColIdArticulo.Text = "ARTICULO ID"
        Me.lvColIdArticulo.Width = 0
        '
        'lvColCodArticulos
        '
        Me.lvColCodArticulos.Text = "CODIGO"
        Me.lvColCodArticulos.Width = 150
        '
        'lvColArticulo
        '
        Me.lvColArticulo.Text = "ARTICULO"
        Me.lvColArticulo.Width = 509
        '
        'lvColStock
        '
        Me.lvColStock.Text = "STOCK"
        Me.lvColStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColStock.Width = 100
        '
        'lvcolUnidad
        '
        Me.lvcolUnidad.Text = "UNIDAD"
        Me.lvcolUnidad.Width = 100
        '
        'lvColInventariado
        '
        Me.lvColInventariado.Text = "INVENTARIADO"
        Me.lvColInventariado.Width = 93
        '
        'lvColSeccion
        '
        Me.lvColSeccion.Text = "SECCION"
        Me.lvColSeccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColSeccion.Width = 100
        '
        'lvColColor
        '
        Me.lvColColor.Text = "ACTIVO"
        Me.lvColColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColColor.Width = 100
        '
        'lvColPrecioUnitario
        '
        Me.lvColPrecioUnitario.Text = "PRECIO"
        Me.lvColPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColPrecioUnitario.Width = 100
        '
        'lvColTotal
        '
        Me.lvColTotal.Text = "TOTAL"
        Me.lvColTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColTotal.Width = 100
        '
        'bBuscar
        '
        Me.bBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscar.Location = New System.Drawing.Point(909, 13)
        Me.bBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(99, 62)
        Me.bBuscar.TabIndex = 0
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(121, 896)
        Me.Contador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(86, 23)
        Me.Contador.TabIndex = 109
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(9, 900)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "ENCONTRADOS"
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Checked = True
        Me.rbTodos.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.rbTodos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbTodos.Location = New System.Drawing.Point(148, 112)
        Me.rbTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(69, 21)
        Me.rbTodos.TabIndex = 5
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "TODOS"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbComprable
        '
        Me.rbComprable.AutoSize = True
        Me.rbComprable.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.rbComprable.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbComprable.Location = New System.Drawing.Point(223, 112)
        Me.rbComprable.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbComprable.Name = "rbComprable"
        Me.rbComprable.Size = New System.Drawing.Size(104, 21)
        Me.rbComprable.TabIndex = 6
        Me.rbComprable.Text = "COMPRABLE"
        Me.rbComprable.UseVisualStyleBackColor = True
        '
        'rbVendible
        '
        Me.rbVendible.AutoSize = True
        Me.rbVendible.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.rbVendible.ForeColor = System.Drawing.Color.DarkBlue
        Me.rbVendible.Location = New System.Drawing.Point(333, 112)
        Me.rbVendible.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbVendible.Name = "rbVendible"
        Me.rbVendible.Size = New System.Drawing.Size(85, 21)
        Me.rbVendible.TabIndex = 7
        Me.rbVendible.Text = "VENDIBLE"
        Me.rbVendible.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txIdArticulo
        '
        Me.txIdArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txIdArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txIdArticulo.Location = New System.Drawing.Point(148, 22)
        Me.txIdArticulo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txIdArticulo.Name = "txIdArticulo"
        Me.txIdArticulo.Size = New System.Drawing.Size(95, 21)
        Me.txIdArticulo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "ID ARTÍCULO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(16, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "ARTÍCULO"
        '
        'txArticulo
        '
        Me.txArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.txArticulo.Location = New System.Drawing.Point(148, 51)
        Me.txArticulo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txArticulo.Name = "txArticulo"
        Me.txArticulo.Size = New System.Drawing.Size(517, 21)
        Me.txArticulo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(249, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "CÓDIGO"
        '
        'txCodigo
        '
        Me.txCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txCodigo.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.txCodigo.Location = New System.Drawing.Point(332, 22)
        Me.txCodigo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txCodigo.Name = "txCodigo"
        Me.txCodigo.Size = New System.Drawing.Size(333, 21)
        Me.txCodigo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(16, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 17)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "TIPO DE ARTÍCULO"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(1015, 13)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 62)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "LIMPIAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckActivos)
        Me.GroupBox1.Controls.Add(Me.cbSecciones)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.rbVendible)
        Me.GroupBox1.Controls.Add(Me.rbTodos)
        Me.GroupBox1.Controls.Add(Me.rbComprable)
        Me.GroupBox1.Controls.Add(Me.txIdArticulo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txArticulo)
        Me.GroupBox1.Controls.Add(Me.txCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(218, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(681, 141)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'ckActivos
        '
        Me.ckActivos.AutoSize = True
        Me.ckActivos.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ckActivos.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivos.Location = New System.Drawing.Point(509, 112)
        Me.ckActivos.Name = "ckActivos"
        Me.ckActivos.Size = New System.Drawing.Size(156, 21)
        Me.ckActivos.TabIndex = 8
        Me.ckActivos.Text = "MOSTRAR INACTIVOS"
        Me.ckActivos.UseVisualStyleBackColor = True
        '
        'cbSecciones
        '
        Me.cbSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSecciones.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.cbSecciones.FormattingEnabled = True
        Me.cbSecciones.Location = New System.Drawing.Point(148, 80)
        Me.cbSecciones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbSecciones.Name = "cbSecciones"
        Me.cbSecciones.Size = New System.Drawing.Size(223, 24)
        Me.cbSecciones.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(16, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 17)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "SECCION"
        '
        'txTotalPrecio
        '
        Me.txTotalPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txTotalPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.txTotalPrecio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotalPrecio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txTotalPrecio.Location = New System.Drawing.Point(1269, 893)
        Me.txTotalPrecio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txTotalPrecio.MaxLength = 15
        Me.txTotalPrecio.Name = "txTotalPrecio"
        Me.txTotalPrecio.ReadOnly = True
        Me.txTotalPrecio.Size = New System.Drawing.Size(164, 23)
        Me.txTotalPrecio.TabIndex = 111
        Me.txTotalPrecio.TabStop = False
        Me.txTotalPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(1140, 896)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 17)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "TOTAL INVENTARIO"
        '
        'gestionInventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1445, 926)
        Me.Controls.Add(Me.txTotalPrecio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.lvArticulos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bImportar)
        Me.Controls.Add(Me.bExportar)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "gestionInventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GESTIÓN INVENTARIOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bImportar As System.Windows.Forms.Button
    Friend WithEvents bExportar As System.Windows.Forms.Button
    Friend WithEvents lvArticulos As System.Windows.Forms.ListView
    Friend WithEvents lvColIdArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColStock As System.Windows.Forms.ColumnHeader
    Friend WithEvents bBuscar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lvColCodArticulos As System.Windows.Forms.ColumnHeader
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbComprable As System.Windows.Forms.RadioButton
    Friend WithEvents rbVendible As System.Windows.Forms.RadioButton
    Friend WithEvents lvcolUnidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txIdArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvColInventariado As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvColSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbSecciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ckActivos As System.Windows.Forms.CheckBox
    Friend WithEvents lvColPrecioUnitario As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents txTotalPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
