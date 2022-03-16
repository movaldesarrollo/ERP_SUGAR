<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioEquipos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambioEquipos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txPedidoOrigen = New System.Windows.Forms.TextBox()
        Me.txPedidoDestino = New System.Windows.Forms.TextBox()
        Me.btnBuscarPedidoOrigen = New System.Windows.Forms.Button()
        Me.btnBuscarPedidoDestino = New System.Windows.Forms.Button()
        Me.dgwPedidoOrigen = New System.Windows.Forms.DataGridView()
        Me.dgwPedidoDestino = New System.Windows.Forms.DataGridView()
        Me.btnTraspasar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        CType(Me.dgwPedidoOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwPedidoDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PEDIDO ORIGEN"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(469, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PEDIDO DESTINO"
        '
        'txPedidoOrigen
        '
        Me.txPedidoOrigen.Location = New System.Drawing.Point(119, 10)
        Me.txPedidoOrigen.Name = "txPedidoOrigen"
        Me.txPedidoOrigen.Size = New System.Drawing.Size(215, 22)
        Me.txPedidoOrigen.TabIndex = 2
        '
        'txPedidoDestino
        '
        Me.txPedidoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txPedidoDestino.Location = New System.Drawing.Point(579, 10)
        Me.txPedidoDestino.Name = "txPedidoDestino"
        Me.txPedidoDestino.Size = New System.Drawing.Size(215, 22)
        Me.txPedidoDestino.TabIndex = 3
        '
        'btnBuscarPedidoOrigen
        '
        Me.btnBuscarPedidoOrigen.Image = Global.ERP_SUGAR.My.Resources.Resources.search24
        Me.btnBuscarPedidoOrigen.Location = New System.Drawing.Point(340, 4)
        Me.btnBuscarPedidoOrigen.Name = "btnBuscarPedidoOrigen"
        Me.btnBuscarPedidoOrigen.Size = New System.Drawing.Size(34, 35)
        Me.btnBuscarPedidoOrigen.TabIndex = 4
        Me.btnBuscarPedidoOrigen.UseVisualStyleBackColor = True
        '
        'btnBuscarPedidoDestino
        '
        Me.btnBuscarPedidoDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarPedidoDestino.Image = Global.ERP_SUGAR.My.Resources.Resources.search24
        Me.btnBuscarPedidoDestino.Location = New System.Drawing.Point(800, 4)
        Me.btnBuscarPedidoDestino.Name = "btnBuscarPedidoDestino"
        Me.btnBuscarPedidoDestino.Size = New System.Drawing.Size(34, 35)
        Me.btnBuscarPedidoDestino.TabIndex = 5
        Me.btnBuscarPedidoDestino.UseVisualStyleBackColor = True
        '
        'dgwPedidoOrigen
        '
        Me.dgwPedidoOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgwPedidoOrigen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwPedidoOrigen.Location = New System.Drawing.Point(13, 45)
        Me.dgwPedidoOrigen.Name = "dgwPedidoOrigen"
        Me.dgwPedidoOrigen.Size = New System.Drawing.Size(361, 531)
        Me.dgwPedidoOrigen.TabIndex = 8
        '
        'dgwPedidoDestino
        '
        Me.dgwPedidoDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwPedidoDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwPedidoDestino.Location = New System.Drawing.Point(471, 45)
        Me.dgwPedidoDestino.Name = "dgwPedidoDestino"
        Me.dgwPedidoDestino.Size = New System.Drawing.Size(363, 531)
        Me.dgwPedidoDestino.TabIndex = 9
        '
        'btnTraspasar
        '
        Me.btnTraspasar.Location = New System.Drawing.Point(380, 45)
        Me.btnTraspasar.Name = "btnTraspasar"
        Me.btnTraspasar.Size = New System.Drawing.Size(84, 74)
        Me.btnTraspasar.TabIndex = 10
        Me.btnTraspasar.Text = "TRASPASAR"
        Me.btnTraspasar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(380, 125)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 74)
        Me.btnLimpiar.TabIndex = 11
        Me.btnLimpiar.Text = "LIMPIAR"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(380, 503)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(84, 73)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'CambioEquipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 588)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnTraspasar)
        Me.Controls.Add(Me.dgwPedidoDestino)
        Me.Controls.Add(Me.dgwPedidoOrigen)
        Me.Controls.Add(Me.btnBuscarPedidoDestino)
        Me.Controls.Add(Me.btnBuscarPedidoOrigen)
        Me.Controls.Add(Me.txPedidoDestino)
        Me.Controls.Add(Me.txPedidoOrigen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "CambioEquipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAMBIO DE EQUIPOS"
        CType(Me.dgwPedidoOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwPedidoDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txPedidoOrigen As TextBox
    Friend WithEvents txPedidoDestino As TextBox
    Friend WithEvents btnBuscarPedidoOrigen As Button
    Friend WithEvents btnBuscarPedidoDestino As Button
    Friend WithEvents dgwPedidoOrigen As DataGridView
    Friend WithEvents dgwPedidoDestino As DataGridView
    Friend WithEvents btnTraspasar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnSalir As Button
End Class
