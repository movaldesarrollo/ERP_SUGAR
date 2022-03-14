<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CAMBIAREQUIPOS
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
        Me.bCambiar = New System.Windows.Forms.Button()
        Me.lvPedidos = New System.Windows.Forms.ListView()
        Me.colNumPedido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNSerie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIDArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIDEquipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txNumserie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txNumPedido = New System.Windows.Forms.TextBox()
        Me.bBuscar = New System.Windows.Forms.Button()
        Me.txNumSerieHasta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txContador = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bCambiar
        '
        Me.bCambiar.Location = New System.Drawing.Point(777, 13)
        Me.bCambiar.Margin = New System.Windows.Forms.Padding(4)
        Me.bCambiar.Name = "bCambiar"
        Me.bCambiar.Size = New System.Drawing.Size(113, 65)
        Me.bCambiar.TabIndex = 4
        Me.bCambiar.Text = "CAMBIAR"
        Me.bCambiar.UseVisualStyleBackColor = True
        '
        'lvPedidos
        '
        Me.lvPedidos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNumPedido, Me.colNSerie, Me.colArticulo, Me.colIDArticulo, Me.colIDEquipo})
        Me.lvPedidos.FullRowSelect = True
        Me.lvPedidos.GridLines = True
        Me.lvPedidos.Location = New System.Drawing.Point(13, 144)
        Me.lvPedidos.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPedidos.Name = "lvPedidos"
        Me.lvPedidos.Size = New System.Drawing.Size(1119, 605)
        Me.lvPedidos.TabIndex = 2
        Me.lvPedidos.UseCompatibleStateImageBehavior = False
        Me.lvPedidos.View = System.Windows.Forms.View.Details
        '
        'colNumPedido
        '
        Me.colNumPedido.Text = "Nº PEDIDO"
        Me.colNumPedido.Width = 218
        '
        'colNSerie
        '
        Me.colNSerie.Text = "Nº SERIE"
        Me.colNSerie.Width = 266
        '
        'colArticulo
        '
        Me.colArticulo.Text = "ARTÍCULO"
        Me.colArticulo.Width = 631
        '
        'colIDArticulo
        '
        Me.colIDArticulo.Text = "ID ARTÍCULO"
        Me.colIDArticulo.Width = 0
        '
        'colIDEquipo
        '
        Me.colIDEquipo.Text = "ID EQUIPO"
        Me.colIDEquipo.Width = 0
        '
        'bSalir
        '
        Me.bSalir.Location = New System.Drawing.Point(1019, 13)
        Me.bSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(113, 65)
        Me.bSalir.TabIndex = 6
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Location = New System.Drawing.Point(898, 13)
        Me.bLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(113, 65)
        Me.bLimpiar.TabIndex = 5
        Me.bLimpiar.Text = "LIMPIAR"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 163
        Me.PictureBox1.TabStop = False
        '
        'txNumserie
        '
        Me.txNumserie.Location = New System.Drawing.Point(72, 105)
        Me.txNumserie.Name = "txNumserie"
        Me.txNumserie.Size = New System.Drawing.Size(100, 23)
        Me.txNumserie.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "NºSERIE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(309, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "PEDIDO"
        '
        'txNumPedido
        '
        Me.txNumPedido.Location = New System.Drawing.Point(372, 105)
        Me.txNumPedido.Name = "txNumPedido"
        Me.txNumPedido.Size = New System.Drawing.Size(146, 23)
        Me.txNumPedido.TabIndex = 1
        '
        'bBuscar
        '
        Me.bBuscar.Location = New System.Drawing.Point(656, 13)
        Me.bBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.bBuscar.Name = "bBuscar"
        Me.bBuscar.Size = New System.Drawing.Size(113, 65)
        Me.bBuscar.TabIndex = 169
        Me.bBuscar.Text = "BUSCAR"
        Me.bBuscar.UseVisualStyleBackColor = True
        '
        'txNumSerieHasta
        '
        Me.txNumSerieHasta.Location = New System.Drawing.Point(196, 105)
        Me.txNumSerieHasta.Name = "txNumSerieHasta"
        Me.txNumSerieHasta.Size = New System.Drawing.Size(100, 23)
        Me.txNumSerieHasta.TabIndex = 170
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 17)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "-"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(959, 759)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 17)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "TOTAL"
        '
        'txContador
        '
        Me.txContador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txContador.Location = New System.Drawing.Point(1009, 756)
        Me.txContador.Name = "txContador"
        Me.txContador.Size = New System.Drawing.Size(123, 23)
        Me.txContador.TabIndex = 172
        '
        'CAMBIAREQUIPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 791)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txContador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txNumSerieHasta)
        Me.Controls.Add(Me.bBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txNumPedido)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txNumserie)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.lvPedidos)
        Me.Controls.Add(Me.bCambiar)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CAMBIAREQUIPOS"
        Me.Text = "CAMBIAREQUIPOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bCambiar As Button
    Friend WithEvents lvPedidos As ListView
    Friend WithEvents bSalir As Button
    Friend WithEvents bLimpiar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents colNumPedido As ColumnHeader
    Friend WithEvents colNSerie As ColumnHeader
    Friend WithEvents colArticulo As ColumnHeader
    Friend WithEvents txNumserie As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txNumPedido As TextBox
    Friend WithEvents colIDArticulo As ColumnHeader
    Friend WithEvents colIDEquipo As ColumnHeader
    Friend WithEvents bBuscar As Button
    Friend WithEvents txNumSerieHasta As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txContador As TextBox
End Class
