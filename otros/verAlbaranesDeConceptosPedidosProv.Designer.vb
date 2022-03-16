<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class verAlbaranesDeConceptosPedidosProv
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
        Me.lvAlbarenesConceptoPedido = New System.Windows.Forms.ListView
        Me.lvColIdConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvIdAlbaran = New System.Windows.Forms.ColumnHeader
        Me.lvColNumFactura = New System.Windows.Forms.ColumnHeader
        Me.lvColFecha = New System.Windows.Forms.ColumnHeader
        Me.lvColRef = New System.Windows.Forms.ColumnHeader
        Me.lvColNotas = New System.Windows.Forms.ColumnHeader
        Me.lvColObser = New System.Windows.Forms.ColumnHeader
        Me.lvColEstado = New System.Windows.Forms.ColumnHeader
        Me.lvColCantidad = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'lvAlbarenesConceptoPedido
        '
        Me.lvAlbarenesConceptoPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvAlbarenesConceptoPedido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvColIdConcepto, Me.lvIdAlbaran, Me.lvColNumFactura, Me.lvColFecha, Me.lvColRef, Me.lvColNotas, Me.lvColObser, Me.lvColEstado, Me.lvColCantidad})
        Me.lvAlbarenesConceptoPedido.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lvAlbarenesConceptoPedido.FullRowSelect = True
        Me.lvAlbarenesConceptoPedido.GridLines = True
        Me.lvAlbarenesConceptoPedido.Location = New System.Drawing.Point(12, 12)
        Me.lvAlbarenesConceptoPedido.Name = "lvAlbarenesConceptoPedido"
        Me.lvAlbarenesConceptoPedido.Size = New System.Drawing.Size(1385, 551)
        Me.lvAlbarenesConceptoPedido.TabIndex = 0
        Me.lvAlbarenesConceptoPedido.UseCompatibleStateImageBehavior = False
        Me.lvAlbarenesConceptoPedido.View = System.Windows.Forms.View.Details
        '
        'lvColIdConcepto
        '
        Me.lvColIdConcepto.Text = "IDCONCEPTO"
        Me.lvColIdConcepto.Width = 100
        '
        'lvIdAlbaran
        '
        Me.lvIdAlbaran.Text = "Nº ALBARAN"
        Me.lvIdAlbaran.Width = 100
        '
        'lvColNumFactura
        '
        Me.lvColNumFactura.Text = "Nº FACTURA"
        Me.lvColNumFactura.Width = 100
        '
        'lvColFecha
        '
        Me.lvColFecha.Text = "FECHA"
        Me.lvColFecha.Width = 100
        '
        'lvColRef
        '
        Me.lvColRef.Text = "FEFERENCIA"
        Me.lvColRef.Width = 100
        '
        'lvColNotas
        '
        Me.lvColNotas.Text = "NOTAS"
        Me.lvColNotas.Width = 300
        '
        'lvColObser
        '
        Me.lvColObser.Text = "OBSERVACIONES"
        Me.lvColObser.Width = 300
        '
        'lvColEstado
        '
        Me.lvColEstado.Text = "ESTADO"
        Me.lvColEstado.Width = 100
        '
        'lvColCantidad
        '
        Me.lvColCantidad.Text = "CANTIDAD"
        Me.lvColCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvColCantidad.Width = 150
        '
        'verAlbaranesDeConceptosPedidosProv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1409, 575)
        Me.Controls.Add(Me.lvAlbarenesConceptoPedido)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "verAlbaranesDeConceptosPedidosProv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALBARANES DE CONCEPTO DE PEDIDO PROVEEDOR"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvAlbarenesConceptoPedido As System.Windows.Forms.ListView
    Friend WithEvents lvColIdConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvIdAlbaran As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColNumFactura As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColRef As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColNotas As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColObser As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvColEstado As System.Windows.Forms.ColumnHeader
End Class
