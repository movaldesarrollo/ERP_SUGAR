<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionEscandallos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionEscandallos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pbCarga = New System.Windows.Forms.ProgressBar
        Me.bBuscarArticulo = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbActualizandoPrecios = New System.Windows.Forms.Label
        Me.CosteTotalTiempo = New System.Windows.Forms.TextBox
        Me.bTipo = New System.Windows.Forms.Button
        Me.txEscandallo = New System.Windows.Forms.TextBox
        Me.lbActualizacion = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.observaciones = New System.Windows.Forms.TextBox
        Me.CosteTotal = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.tbdatos = New System.Windows.Forms.TabControl
        Me.tbDesglose = New System.Windows.Forms.TabPage
        Me.Label27 = New System.Windows.Forms.Label
        Me.txSeccion = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txSubFamila = New System.Windows.Forms.TextBox
        Me.txFamilia = New System.Windows.Forms.TextBox
        Me.txMateriaPrima = New System.Windows.Forms.TextBox
        Me.txCodMateriaPrima = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.ckSubEscandallos = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbMonedaC = New System.Windows.Forms.Label
        Me.bArticuloC = New System.Windows.Forms.Button
        Me.ObservacionesC = New System.Windows.Forms.TextBox
        Me.bLimpiar = New System.Windows.Forms.Button
        Me.Cantidad = New System.Windows.Forms.TextBox
        Me.Coste = New System.Windows.Forms.TextBox
        Me.lbCambio = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbUnidad = New System.Windows.Forms.Label
        Me.ckActivoC = New System.Windows.Forms.CheckBox
        Me.bBuscarMP = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lvConceptos = New System.Windows.Forms.ListView
        Me.lvidConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvSeccion = New System.Windows.Forms.ColumnHeader
        Me.codConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvFamilia = New System.Windows.Forms.ColumnHeader
        Me.lvSubFamiila = New System.Windows.Forms.ColumnHeader
        Me.lvConcepto = New System.Windows.Forms.ColumnHeader
        Me.lvCantidad = New System.Windows.Forms.ColumnHeader
        Me.lvCosteU = New System.Windows.Forms.ColumnHeader
        Me.lvCoste = New System.Windows.Forms.ColumnHeader
        Me.lvObservaciones = New System.Windows.Forms.ColumnHeader
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.tbTiempos = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.ObservacionesT = New System.Windows.Forms.TextBox
        Me.bLimpiarTiempo = New System.Windows.Forms.Button
        Me.Horas = New System.Windows.Forms.TextBox
        Me.bSeccionesT = New System.Windows.Forms.Button
        Me.PrecioHora = New System.Windows.Forms.TextBox
        Me.cbSeccionT = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lvTiempos = New System.Windows.Forms.ListView
        Me.lvidTiempo = New System.Windows.Forms.ColumnHeader
        Me.lvSeccionT = New System.Windows.Forms.ColumnHeader
        Me.lvHoras = New System.Windows.Forms.ColumnHeader
        Me.lvPrecioHora = New System.Windows.Forms.ColumnHeader
        Me.lvObservacionesT = New System.Windows.Forms.ColumnHeader
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cbTipoEscandallo = New System.Windows.Forms.ComboBox
        Me.CosteTotalMaterial = New System.Windows.Forms.TextBox
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbFechaBaja = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker
        Me.Label42 = New System.Windows.Forms.Label
        Me.ckActivo = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.idEscandallo = New System.Windows.Forms.TextBox
        Me.Version = New System.Windows.Forms.TextBox
        Me.bEscandalloCompleto = New System.Windows.Forms.Button
        Me.bPropagar = New System.Windows.Forms.Button
        Me.bSubir = New System.Windows.Forms.Button
        Me.bBajar = New System.Windows.Forms.Button
        Me.bSalir = New System.Windows.Forms.Button
        Me.bImprimir = New System.Windows.Forms.Button
        Me.bBorrar = New System.Windows.Forms.Button
        Me.bCopiar = New System.Windows.Forms.Button
        Me.bNuevo = New System.Windows.Forms.Button
        Me.bGuardar = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        Me.tbdatos.SuspendLayout()
        Me.tbDesglose.SuspendLayout()
        Me.tbTiempos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pbCarga)
        Me.GroupBox1.Controls.Add(Me.bBuscarArticulo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lbActualizandoPrecios)
        Me.GroupBox1.Controls.Add(Me.CosteTotalTiempo)
        Me.GroupBox1.Controls.Add(Me.bTipo)
        Me.GroupBox1.Controls.Add(Me.txEscandallo)
        Me.GroupBox1.Controls.Add(Me.lbActualizacion)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.observaciones)
        Me.GroupBox1.Controls.Add(Me.CosteTotal)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.tbdatos)
        Me.GroupBox1.Controls.Add(Me.cbTipoEscandallo)
        Me.GroupBox1.Controls.Add(Me.CosteTotalMaterial)
        Me.GroupBox1.Controls.Add(Me.dtpFechaBaja)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbFechaBaja)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpFechaAlta)
        Me.GroupBox1.Controls.Add(Me.Label42)
        Me.GroupBox1.Controls.Add(Me.ckActivo)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.idEscandallo)
        Me.GroupBox1.Controls.Add(Me.Version)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1457, 846)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'pbCarga
        '
        Me.pbCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbCarga.Location = New System.Drawing.Point(15, 816)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(118, 15)
        Me.pbCarga.TabIndex = 0
        '
        'bBuscarArticulo
        '
        Me.bBuscarArticulo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarArticulo.Image = CType(resources.GetObject("bBuscarArticulo.Image"), System.Drawing.Image)
        Me.bBuscarArticulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarArticulo.Location = New System.Drawing.Point(741, 19)
        Me.bBuscarArticulo.Name = "bBuscarArticulo"
        Me.bBuscarArticulo.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarArticulo.TabIndex = 7
        Me.bBuscarArticulo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(219, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 17)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "ESCANDALLO"
        '
        'lbActualizandoPrecios
        '
        Me.lbActualizandoPrecios.AutoSize = True
        Me.lbActualizandoPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbActualizandoPrecios.ForeColor = System.Drawing.Color.Red
        Me.lbActualizandoPrecios.Location = New System.Drawing.Point(1142, 71)
        Me.lbActualizandoPrecios.Name = "lbActualizandoPrecios"
        Me.lbActualizandoPrecios.Size = New System.Drawing.Size(296, 13)
        Me.lbActualizandoPrecios.TabIndex = 194
        Me.lbActualizandoPrecios.Text = "ACTUALIZANDO PRECIOS, ESPERE POR FAVOR."
        Me.lbActualizandoPrecios.Visible = False
        '
        'CosteTotalTiempo
        '
        Me.CosteTotalTiempo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CosteTotalTiempo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CosteTotalTiempo.ForeColor = System.Drawing.Color.DarkRed
        Me.CosteTotalTiempo.Location = New System.Drawing.Point(1136, 813)
        Me.CosteTotalTiempo.Name = "CosteTotalTiempo"
        Me.CosteTotalTiempo.ReadOnly = True
        Me.CosteTotalTiempo.Size = New System.Drawing.Size(71, 23)
        Me.CosteTotalTiempo.TabIndex = 3
        Me.CosteTotalTiempo.TabStop = False
        Me.CosteTotalTiempo.Text = "0,00"
        Me.CosteTotalTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bTipo
        '
        Me.bTipo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bTipo.Location = New System.Drawing.Point(1048, 50)
        Me.bTipo.Name = "bTipo"
        Me.bTipo.Size = New System.Drawing.Size(27, 25)
        Me.bTipo.TabIndex = 2
        Me.bTipo.Text = "...."
        Me.bTipo.UseVisualStyleBackColor = True
        '
        'txEscandallo
        '
        Me.txEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txEscandallo.ForeColor = System.Drawing.Color.DarkRed
        Me.txEscandallo.Location = New System.Drawing.Point(318, 19)
        Me.txEscandallo.Name = "txEscandallo"
        Me.txEscandallo.ReadOnly = True
        Me.txEscandallo.Size = New System.Drawing.Size(417, 23)
        Me.txEscandallo.TabIndex = 195
        Me.txEscandallo.TabStop = False
        '
        'lbActualizacion
        '
        Me.lbActualizacion.AutoSize = True
        Me.lbActualizacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lbActualizacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbActualizacion.Location = New System.Drawing.Point(1210, 54)
        Me.lbActualizacion.Name = "lbActualizacion"
        Me.lbActualizacion.Size = New System.Drawing.Size(227, 17)
        Me.lbActualizacion.TabIndex = 12
        Me.lbActualizacion.Text = "ÚLTIMA ACTUALIZACIÓN 22/12/2015"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(942, 815)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(193, 17)
        Me.Label19.TabIndex = 198
        Me.Label19.Text = "COSTE TOTAL MANO DE OBRA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "OBSERVACIONES"
        '
        'observaciones
        '
        Me.observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observaciones.Location = New System.Drawing.Point(137, 53)
        Me.observaciones.MaxLength = 300
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.observaciones.Size = New System.Drawing.Size(631, 23)
        Me.observaciones.TabIndex = 10
        '
        'CosteTotal
        '
        Me.CosteTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CosteTotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CosteTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.CosteTotal.Location = New System.Drawing.Point(1356, 812)
        Me.CosteTotal.Name = "CosteTotal"
        Me.CosteTotal.ReadOnly = True
        Me.CosteTotal.Size = New System.Drawing.Size(71, 23)
        Me.CosteTotal.TabIndex = 4
        Me.CosteTotal.TabStop = False
        Me.CosteTotal.Text = "0,00"
        Me.CosteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(1210, 816)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(15, 17)
        Me.Label20.TabIndex = 197
        Me.Label20.Text = "€"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label39.Location = New System.Drawing.Point(778, 55)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(35, 17)
        Me.Label39.TabIndex = 110
        Me.Label39.Text = "TIPO"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(1256, 815)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 17)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "COSTE TOTAL"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(1430, 815)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(15, 17)
        Me.Label22.TabIndex = 110
        Me.Label22.Text = "€"
        '
        'tbdatos
        '
        Me.tbdatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbdatos.CausesValidation = False
        Me.tbdatos.Controls.Add(Me.tbDesglose)
        Me.tbdatos.Controls.Add(Me.tbTiempos)
        Me.tbdatos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbdatos.HotTrack = True
        Me.tbdatos.Location = New System.Drawing.Point(12, 82)
        Me.tbdatos.Name = "tbdatos"
        Me.tbdatos.SelectedIndex = 0
        Me.tbdatos.Size = New System.Drawing.Size(1439, 728)
        Me.tbdatos.TabIndex = 1
        '
        'tbDesglose
        '
        Me.tbDesglose.Controls.Add(Me.Label27)
        Me.tbDesglose.Controls.Add(Me.txSeccion)
        Me.tbDesglose.Controls.Add(Me.Label26)
        Me.tbDesglose.Controls.Add(Me.txSubFamila)
        Me.tbDesglose.Controls.Add(Me.txFamilia)
        Me.tbDesglose.Controls.Add(Me.txMateriaPrima)
        Me.tbDesglose.Controls.Add(Me.txCodMateriaPrima)
        Me.tbDesglose.Controls.Add(Me.Label25)
        Me.tbDesglose.Controls.Add(Me.Label24)
        Me.tbDesglose.Controls.Add(Me.ckSubEscandallos)
        Me.tbDesglose.Controls.Add(Me.Label11)
        Me.tbDesglose.Controls.Add(Me.lbMonedaC)
        Me.tbDesglose.Controls.Add(Me.bArticuloC)
        Me.tbDesglose.Controls.Add(Me.ObservacionesC)
        Me.tbDesglose.Controls.Add(Me.bLimpiar)
        Me.tbDesglose.Controls.Add(Me.Cantidad)
        Me.tbDesglose.Controls.Add(Me.Coste)
        Me.tbDesglose.Controls.Add(Me.lbCambio)
        Me.tbDesglose.Controls.Add(Me.Label4)
        Me.tbDesglose.Controls.Add(Me.Label16)
        Me.tbDesglose.Controls.Add(Me.Label9)
        Me.tbDesglose.Controls.Add(Me.lbUnidad)
        Me.tbDesglose.Controls.Add(Me.ckActivoC)
        Me.tbDesglose.Controls.Add(Me.bBuscarMP)
        Me.tbDesglose.Controls.Add(Me.Label2)
        Me.tbDesglose.Controls.Add(Me.lvConceptos)
        Me.tbDesglose.Controls.Add(Me.Label5)
        Me.tbDesglose.Controls.Add(Me.Label10)
        Me.tbDesglose.Location = New System.Drawing.Point(4, 26)
        Me.tbDesglose.Name = "tbDesglose"
        Me.tbDesglose.Size = New System.Drawing.Size(1431, 698)
        Me.tbDesglose.TabIndex = 0
        Me.tbDesglose.Text = "DESGLOSE"
        Me.tbDesglose.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label27.Location = New System.Drawing.Point(705, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 17)
        Me.Label27.TabIndex = 193
        Me.Label27.Text = "SECCIÓN"
        '
        'txSeccion
        '
        Me.txSeccion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txSeccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txSeccion.Location = New System.Drawing.Point(778, 71)
        Me.txSeccion.MaxLength = 100
        Me.txSeccion.Name = "txSeccion"
        Me.txSeccion.Size = New System.Drawing.Size(237, 23)
        Me.txSeccion.TabIndex = 192
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label26.Location = New System.Drawing.Point(380, 74)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 17)
        Me.Label26.TabIndex = 191
        Me.Label26.Text = "SUBFAMILIA"
        '
        'txSubFamila
        '
        Me.txSubFamila.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txSubFamila.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txSubFamila.Location = New System.Drawing.Point(462, 71)
        Me.txSubFamila.MaxLength = 100
        Me.txSubFamila.Name = "txSubFamila"
        Me.txSubFamila.Size = New System.Drawing.Size(237, 23)
        Me.txSubFamila.TabIndex = 190
        '
        'txFamilia
        '
        Me.txFamilia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txFamilia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txFamilia.Location = New System.Drawing.Point(137, 71)
        Me.txFamilia.MaxLength = 100
        Me.txFamilia.Name = "txFamilia"
        Me.txFamilia.Size = New System.Drawing.Size(237, 23)
        Me.txFamilia.TabIndex = 189
        '
        'txMateriaPrima
        '
        Me.txMateriaPrima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txMateriaPrima.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txMateriaPrima.Location = New System.Drawing.Point(380, 13)
        Me.txMateriaPrima.MaxLength = 100
        Me.txMateriaPrima.Name = "txMateriaPrima"
        Me.txMateriaPrima.Size = New System.Drawing.Size(526, 23)
        Me.txMateriaPrima.TabIndex = 188
        '
        'txCodMateriaPrima
        '
        Me.txCodMateriaPrima.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txCodMateriaPrima.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txCodMateriaPrima.Location = New System.Drawing.Point(137, 13)
        Me.txCodMateriaPrima.MaxLength = 100
        Me.txCodMateriaPrima.Name = "txCodMateriaPrima"
        Me.txCodMateriaPrima.Size = New System.Drawing.Size(237, 23)
        Me.txCodMateriaPrima.TabIndex = 187
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(260, 673)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(106, 17)
        Me.Label25.TabIndex = 186
        Me.Label25.Text = "SubEscandallos"
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.LightBlue
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(242, 673)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(12, 17)
        Me.Label24.TabIndex = 185
        Me.Label24.Text = " "
        '
        'ckSubEscandallos
        '
        Me.ckSubEscandallos.AutoSize = True
        Me.ckSubEscandallos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSubEscandallos.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSubEscandallos.Location = New System.Drawing.Point(1247, 72)
        Me.ckSubEscandallos.Name = "ckSubEscandallos"
        Me.ckSubEscandallos.Size = New System.Drawing.Size(139, 21)
        Me.ckSubEscandallos.TabIndex = 184
        Me.ckSubEscandallos.Text = "SUBESCANDALLOS"
        Me.ckSubEscandallos.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Green
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(16, 673)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 17)
        Me.Label11.TabIndex = 108
        Me.Label11.Text = " "
        '
        'lbMonedaC
        '
        Me.lbMonedaC.AutoSize = True
        Me.lbMonedaC.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.lbMonedaC.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbMonedaC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbMonedaC.Location = New System.Drawing.Point(1121, 16)
        Me.lbMonedaC.Name = "lbMonedaC"
        Me.lbMonedaC.Size = New System.Drawing.Size(15, 17)
        Me.lbMonedaC.TabIndex = 183
        Me.lbMonedaC.Text = "€"
        '
        'bArticuloC
        '
        Me.bArticuloC.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bArticuloC.Image = CType(resources.GetObject("bArticuloC.Image"), System.Drawing.Image)
        Me.bArticuloC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bArticuloC.Location = New System.Drawing.Point(945, 12)
        Me.bArticuloC.Name = "bArticuloC"
        Me.bArticuloC.Size = New System.Drawing.Size(27, 25)
        Me.bArticuloC.TabIndex = 9
        Me.bArticuloC.UseVisualStyleBackColor = True
        '
        'ObservacionesC
        '
        Me.ObservacionesC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ObservacionesC.Location = New System.Drawing.Point(138, 42)
        Me.ObservacionesC.MaxLength = 100
        Me.ObservacionesC.Name = "ObservacionesC"
        Me.ObservacionesC.Size = New System.Drawing.Size(1283, 23)
        Me.ObservacionesC.TabIndex = 11
        '
        'bLimpiar
        '
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.Image = CType(resources.GetObject("bLimpiar.Image"), System.Drawing.Image)
        Me.bLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiar.Location = New System.Drawing.Point(1394, 70)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiar.TabIndex = 182
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'Cantidad
        '
        Me.Cantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cantidad.ForeColor = System.Drawing.Color.DarkRed
        Me.Cantidad.Location = New System.Drawing.Point(1233, 13)
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(60, 23)
        Me.Cantidad.TabIndex = 12
        Me.Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Coste
        '
        Me.Coste.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Coste.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Coste.Location = New System.Drawing.Point(1055, 13)
        Me.Coste.Name = "Coste"
        Me.Coste.ReadOnly = True
        Me.Coste.Size = New System.Drawing.Size(56, 23)
        Me.Coste.TabIndex = 12
        Me.Coste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(1245, 665)
        Me.lbCambio.Name = "lbCambio"
        Me.lbCambio.Size = New System.Drawing.Size(176, 17)
        Me.lbCambio.TabIndex = 108
        Me.lbCambio.Text = "CAMBIO NO ACTUALIZADO"
        Me.lbCambio.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(1142, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "CANTIDAD"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(13, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 17)
        Me.Label16.TabIndex = 179
        Me.Label16.Text = "FAMILIA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(978, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 17)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "COSTE U."
        '
        'lbUnidad
        '
        Me.lbUnidad.AutoSize = True
        Me.lbUnidad.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbUnidad.Location = New System.Drawing.Point(1299, 16)
        Me.lbUnidad.Name = "lbUnidad"
        Me.lbUnidad.Size = New System.Drawing.Size(20, 17)
        Me.lbUnidad.TabIndex = 110
        Me.lbUnidad.Text = "u."
        '
        'ckActivoC
        '
        Me.ckActivoC.AutoSize = True
        Me.ckActivoC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivoC.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivoC.Location = New System.Drawing.Point(1345, 14)
        Me.ckActivoC.Name = "ckActivoC"
        Me.ckActivoC.Size = New System.Drawing.Size(75, 21)
        Me.ckActivoC.TabIndex = 5
        Me.ckActivoC.Text = "ACTIVO"
        Me.ckActivoC.UseVisualStyleBackColor = True
        '
        'bBuscarMP
        '
        Me.bBuscarMP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBuscarMP.Image = CType(resources.GetObject("bBuscarMP.Image"), System.Drawing.Image)
        Me.bBuscarMP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBuscarMP.Location = New System.Drawing.Point(912, 12)
        Me.bBuscarMP.Name = "bBuscarMP"
        Me.bBuscarMP.Size = New System.Drawing.Size(27, 25)
        Me.bBuscarMP.TabIndex = 7
        Me.bBuscarMP.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(13, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "MATERIA PRIMA"
        '
        'lvConceptos
        '
        Me.lvConceptos.AllowColumnReorder = True
        Me.lvConceptos.AllowDrop = True
        Me.lvConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvConceptos.AutoArrange = False
        Me.lvConceptos.BackgroundImageTiled = True
        Me.lvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidConcepto, Me.lvSeccion, Me.codConcepto, Me.lvFamilia, Me.lvSubFamiila, Me.lvConcepto, Me.lvCantidad, Me.lvCosteU, Me.lvCoste, Me.lvObservaciones})
        Me.lvConceptos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvConceptos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvConceptos.FullRowSelect = True
        Me.lvConceptos.GridLines = True
        Me.lvConceptos.HideSelection = False
        Me.lvConceptos.Location = New System.Drawing.Point(13, 102)
        Me.lvConceptos.Name = "lvConceptos"
        Me.lvConceptos.ShowItemToolTips = True
        Me.lvConceptos.Size = New System.Drawing.Size(1409, 560)
        Me.lvConceptos.TabIndex = 13
        Me.lvConceptos.UseCompatibleStateImageBehavior = False
        Me.lvConceptos.View = System.Windows.Forms.View.Details
        '
        'lvidConcepto
        '
        Me.lvidConcepto.Text = "idConcepto"
        Me.lvidConcepto.Width = 0
        '
        'lvSeccion
        '
        Me.lvSeccion.Text = "SECCIÓN"
        Me.lvSeccion.Width = 100
        '
        'codConcepto
        '
        Me.codConcepto.Text = "CÓDIGO"
        Me.codConcepto.Width = 100
        '
        'lvFamilia
        '
        Me.lvFamilia.Text = "FAMILIA"
        Me.lvFamilia.Width = 100
        '
        'lvSubFamiila
        '
        Me.lvSubFamiila.Text = "SUBFAMILIA"
        Me.lvSubFamiila.Width = 100
        '
        'lvConcepto
        '
        Me.lvConcepto.Text = "MATERIA PRIMA"
        Me.lvConcepto.Width = 210
        '
        'lvCantidad
        '
        Me.lvCantidad.Text = "CANTIDAD"
        Me.lvCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCantidad.Width = 75
        '
        'lvCosteU
        '
        Me.lvCosteU.Text = "COSTE U."
        Me.lvCosteU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCosteU.Width = 75
        '
        'lvCoste
        '
        Me.lvCoste.Text = "COSTE"
        Me.lvCoste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvCoste.Width = 75
        '
        'lvObservaciones
        '
        Me.lvObservaciones.Text = "OBSERVACIONES"
        Me.lvObservaciones.Width = 550
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(13, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 17)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "OBSERVACIONES"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(33, 673)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(203, 17)
        Me.Label10.TabIndex = 108
        Me.Label10.Text = "Materia prima con escandallo"
        '
        'tbTiempos
        '
        Me.tbTiempos.Controls.Add(Me.Label13)
        Me.tbTiempos.Controls.Add(Me.ObservacionesT)
        Me.tbTiempos.Controls.Add(Me.bLimpiarTiempo)
        Me.tbTiempos.Controls.Add(Me.Horas)
        Me.tbTiempos.Controls.Add(Me.bSeccionesT)
        Me.tbTiempos.Controls.Add(Me.PrecioHora)
        Me.tbTiempos.Controls.Add(Me.cbSeccionT)
        Me.tbTiempos.Controls.Add(Me.Label14)
        Me.tbTiempos.Controls.Add(Me.Label15)
        Me.tbTiempos.Controls.Add(Me.lvTiempos)
        Me.tbTiempos.Controls.Add(Me.Label18)
        Me.tbTiempos.Controls.Add(Me.Label23)
        Me.tbTiempos.Location = New System.Drawing.Point(4, 26)
        Me.tbTiempos.Name = "tbTiempos"
        Me.tbTiempos.Size = New System.Drawing.Size(1431, 698)
        Me.tbTiempos.TabIndex = 1
        Me.tbTiempos.Text = "TIEMPO"
        Me.tbTiempos.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(544, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 17)
        Me.Label13.TabIndex = 196
        Me.Label13.Text = "€"
        '
        'ObservacionesT
        '
        Me.ObservacionesT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ObservacionesT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ObservacionesT.Location = New System.Drawing.Point(130, 42)
        Me.ObservacionesT.MaxLength = 100
        Me.ObservacionesT.Name = "ObservacionesT"
        Me.ObservacionesT.Size = New System.Drawing.Size(947, 23)
        Me.ObservacionesT.TabIndex = 3
        '
        'bLimpiarTiempo
        '
        Me.bLimpiarTiempo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiarTiempo.Image = CType(resources.GetObject("bLimpiarTiempo.Image"), System.Drawing.Image)
        Me.bLimpiarTiempo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bLimpiarTiempo.Location = New System.Drawing.Point(708, 8)
        Me.bLimpiarTiempo.Name = "bLimpiarTiempo"
        Me.bLimpiarTiempo.Size = New System.Drawing.Size(27, 25)
        Me.bLimpiarTiempo.TabIndex = 5
        Me.bLimpiarTiempo.UseVisualStyleBackColor = True
        '
        'Horas
        '
        Me.Horas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Horas.ForeColor = System.Drawing.Color.DarkRed
        Me.Horas.Location = New System.Drawing.Point(618, 9)
        Me.Horas.Name = "Horas"
        Me.Horas.Size = New System.Drawing.Size(84, 23)
        Me.Horas.TabIndex = 4
        Me.Horas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bSeccionesT
        '
        Me.bSeccionesT.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSeccionesT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSeccionesT.Location = New System.Drawing.Point(321, 8)
        Me.bSeccionesT.Name = "bSeccionesT"
        Me.bSeccionesT.Size = New System.Drawing.Size(27, 25)
        Me.bSeccionesT.TabIndex = 1
        Me.bSeccionesT.Text = "...."
        Me.bSeccionesT.UseVisualStyleBackColor = True
        '
        'PrecioHora
        '
        Me.PrecioHora.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioHora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PrecioHora.Location = New System.Drawing.Point(458, 10)
        Me.PrecioHora.Name = "PrecioHora"
        Me.PrecioHora.ReadOnly = True
        Me.PrecioHora.Size = New System.Drawing.Size(84, 23)
        Me.PrecioHora.TabIndex = 2
        Me.PrecioHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbSeccionT
        '
        Me.cbSeccionT.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeccionT.FormattingEnabled = True
        Me.cbSeccionT.Location = New System.Drawing.Point(130, 9)
        Me.cbSeccionT.MaxLength = 6
        Me.cbSeccionT.Name = "cbSeccionT"
        Me.cbSeccionT.Size = New System.Drawing.Size(185, 25)
        Me.cbSeccionT.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(561, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 17)
        Me.Label14.TabIndex = 194
        Me.Label14.Text = "HORAS"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(354, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 17)
        Me.Label15.TabIndex = 192
        Me.Label15.Text = "PRECIO/HORA"
        '
        'lvTiempos
        '
        Me.lvTiempos.AllowColumnReorder = True
        Me.lvTiempos.AllowDrop = True
        Me.lvTiempos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTiempos.AutoArrange = False
        Me.lvTiempos.BackgroundImageTiled = True
        Me.lvTiempos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvidTiempo, Me.lvSeccionT, Me.lvHoras, Me.lvPrecioHora, Me.lvObservacionesT})
        Me.lvTiempos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvTiempos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvTiempos.FullRowSelect = True
        Me.lvTiempos.GridLines = True
        Me.lvTiempos.HideSelection = False
        Me.lvTiempos.Location = New System.Drawing.Point(13, 71)
        Me.lvTiempos.Name = "lvTiempos"
        Me.lvTiempos.ShowItemToolTips = True
        Me.lvTiempos.Size = New System.Drawing.Size(1064, 529)
        Me.lvTiempos.TabIndex = 189
        Me.lvTiempos.UseCompatibleStateImageBehavior = False
        Me.lvTiempos.View = System.Windows.Forms.View.Details
        '
        'lvidTiempo
        '
        Me.lvidTiempo.Text = "idTiempo"
        Me.lvidTiempo.Width = 0
        '
        'lvSeccionT
        '
        Me.lvSeccionT.Text = "SECCIÓN"
        Me.lvSeccionT.Width = 132
        '
        'lvHoras
        '
        Me.lvHoras.Text = "HORAS"
        Me.lvHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvHoras.Width = 93
        '
        'lvPrecioHora
        '
        Me.lvPrecioHora.Text = "COSTE"
        Me.lvPrecioHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvPrecioHora.Width = 125
        '
        'lvObservacionesT
        '
        Me.lvObservacionesT.Text = "OBSERVACIONES"
        Me.lvObservacionesT.Width = 710
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(10, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 17)
        Me.Label18.TabIndex = 191
        Me.Label18.Text = "SECCIÓN"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(10, 45)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 17)
        Me.Label23.TabIndex = 193
        Me.Label23.Text = "OBSERVACIONES"
        '
        'cbTipoEscandallo
        '
        Me.cbTipoEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoEscandallo.FormattingEnabled = True
        Me.cbTipoEscandallo.Location = New System.Drawing.Point(842, 50)
        Me.cbTipoEscandallo.MaxLength = 6
        Me.cbTipoEscandallo.Name = "cbTipoEscandallo"
        Me.cbTipoEscandallo.Size = New System.Drawing.Size(200, 25)
        Me.cbTipoEscandallo.TabIndex = 1
        '
        'CosteTotalMaterial
        '
        Me.CosteTotalMaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CosteTotalMaterial.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CosteTotalMaterial.ForeColor = System.Drawing.Color.DarkRed
        Me.CosteTotalMaterial.Location = New System.Drawing.Point(840, 812)
        Me.CosteTotalMaterial.Name = "CosteTotalMaterial"
        Me.CosteTotalMaterial.ReadOnly = True
        Me.CosteTotalMaterial.Size = New System.Drawing.Size(71, 23)
        Me.CosteTotalMaterial.TabIndex = 2
        Me.CosteTotalMaterial.TabStop = False
        Me.CosteTotalMaterial.Text = "0,00"
        Me.CosteTotalMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBaja.Location = New System.Drawing.Point(1328, 19)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(110, 23)
        Me.dtpFechaBaja.TabIndex = 5
        Me.dtpFechaBaja.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label41.Location = New System.Drawing.Point(1032, 22)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(83, 17)
        Me.Label41.TabIndex = 104
        Me.Label41.Text = "FECHA ALTA"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(688, 815)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 17)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "COSTE TOTAL MATERIAL"
        '
        'lbFechaBaja
        '
        Me.lbFechaBaja.AutoSize = True
        Me.lbFechaBaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaBaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.lbFechaBaja.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbFechaBaja.Location = New System.Drawing.Point(1237, 22)
        Me.lbFechaBaja.Name = "lbFechaBaja"
        Me.lbFechaBaja.Size = New System.Drawing.Size(85, 17)
        Me.lbFechaBaja.TabIndex = 102
        Me.lbFechaBaja.Text = "FECHA BAJA"
        Me.lbFechaBaja.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(914, 815)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 17)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "€"
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAlta.Location = New System.Drawing.Point(1121, 19)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(110, 23)
        Me.dtpFechaAlta.TabIndex = 3
        Me.dtpFechaAlta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(15, 22)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(110, 17)
        Me.Label42.TabIndex = 108
        Me.Label42.Text = "ID ESCANDALLO"
        '
        'ckActivo
        '
        Me.ckActivo.AutoSize = True
        Me.ckActivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckActivo.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckActivo.Location = New System.Drawing.Point(935, 20)
        Me.ckActivo.Name = "ckActivo"
        Me.ckActivo.Size = New System.Drawing.Size(75, 21)
        Me.ckActivo.TabIndex = 4
        Me.ckActivo.Text = "ACTIVO"
        Me.ckActivo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label17.Location = New System.Drawing.Point(774, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 17)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "VERSIÓN"
        '
        'idEscandallo
        '
        Me.idEscandallo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idEscandallo.ForeColor = System.Drawing.Color.DarkRed
        Me.idEscandallo.Location = New System.Drawing.Point(137, 19)
        Me.idEscandallo.Name = "idEscandallo"
        Me.idEscandallo.ReadOnly = True
        Me.idEscandallo.Size = New System.Drawing.Size(76, 23)
        Me.idEscandallo.TabIndex = 0
        Me.idEscandallo.TabStop = False
        '
        'Version
        '
        Me.Version.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.DarkRed
        Me.Version.Location = New System.Drawing.Point(842, 19)
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.Size = New System.Drawing.Size(73, 23)
        Me.Version.TabIndex = 11
        Me.Version.TabStop = False
        '
        'bEscandalloCompleto
        '
        Me.bEscandalloCompleto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bEscandalloCompleto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEscandalloCompleto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bEscandalloCompleto.Location = New System.Drawing.Point(904, 12)
        Me.bEscandalloCompleto.Name = "bEscandalloCompleto"
        Me.bEscandalloCompleto.Size = New System.Drawing.Size(101, 50)
        Me.bEscandalloCompleto.TabIndex = 200
        Me.bEscandalloCompleto.Text = "ESCANDALLO COMPLETO"
        Me.bEscandalloCompleto.UseVisualStyleBackColor = True
        '
        'bPropagar
        '
        Me.bPropagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bPropagar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bPropagar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bPropagar.Location = New System.Drawing.Point(599, 12)
        Me.bPropagar.Name = "bPropagar"
        Me.bPropagar.Size = New System.Drawing.Size(101, 50)
        Me.bPropagar.TabIndex = 199
        Me.bPropagar.Text = "PROPAGAR CAMBIOS"
        Me.bPropagar.UseVisualStyleBackColor = True
        '
        'bSubir
        '
        Me.bSubir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSubir.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bSubir.Image = CType(resources.GetObject("bSubir.Image"), System.Drawing.Image)
        Me.bSubir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSubir.Location = New System.Drawing.Point(813, 12)
        Me.bSubir.Name = "bSubir"
        Me.bSubir.Size = New System.Drawing.Size(85, 22)
        Me.bSubir.TabIndex = 6
        Me.bSubir.UseVisualStyleBackColor = True
        '
        'bBajar
        '
        Me.bBajar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBajar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.bBajar.Image = CType(resources.GetObject("bBajar.Image"), System.Drawing.Image)
        Me.bBajar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBajar.Location = New System.Drawing.Point(813, 40)
        Me.bBajar.Name = "bBajar"
        Me.bBajar.Size = New System.Drawing.Size(85, 22)
        Me.bBajar.TabIndex = 7
        Me.bBajar.UseVisualStyleBackColor = True
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bSalir.Location = New System.Drawing.Point(1375, 12)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 12
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bImprimir
        '
        Me.bImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bImprimir.Location = New System.Drawing.Point(1193, 12)
        Me.bImprimir.Name = "bImprimir"
        Me.bImprimir.Size = New System.Drawing.Size(85, 50)
        Me.bImprimir.TabIndex = 10
        Me.bImprimir.Text = "IMPRIMIR"
        Me.bImprimir.UseVisualStyleBackColor = True
        '
        'bBorrar
        '
        Me.bBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bBorrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBorrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bBorrar.Location = New System.Drawing.Point(1284, 12)
        Me.bBorrar.Name = "bBorrar"
        Me.bBorrar.Size = New System.Drawing.Size(85, 50)
        Me.bBorrar.TabIndex = 11
        Me.bBorrar.Text = "BORRAR"
        Me.bBorrar.UseVisualStyleBackColor = True
        '
        'bCopiar
        '
        Me.bCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCopiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCopiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bCopiar.Location = New System.Drawing.Point(706, 12)
        Me.bCopiar.Name = "bCopiar"
        Me.bCopiar.Size = New System.Drawing.Size(101, 50)
        Me.bCopiar.TabIndex = 5
        Me.bCopiar.Text = "COPIAR ESCANDALLO"
        Me.bCopiar.UseVisualStyleBackColor = True
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(1102, 12)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 9
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bGuardar.Location = New System.Drawing.Point(1011, 12)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(85, 50)
        Me.bGuardar.TabIndex = 8
        Me.bGuardar.Text = "GUARDAR"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'GestionEscandallos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1472, 941)
        Me.Controls.Add(Me.bEscandalloCompleto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.bPropagar)
        Me.Controls.Add(Me.bGuardar)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.bCopiar)
        Me.Controls.Add(Me.bBorrar)
        Me.Controls.Add(Me.bImprimir)
        Me.Controls.Add(Me.bBajar)
        Me.Controls.Add(Me.bSubir)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GestionEscandallos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ESCANDALLO DE ARTÍCULO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbdatos.ResumeLayout(False)
        Me.tbDesglose.ResumeLayout(False)
        Me.tbDesglose.PerformLayout()
        Me.tbTiempos.ResumeLayout(False)
        Me.tbTiempos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents bImprimir As System.Windows.Forms.Button
    Friend WithEvents bBorrar As System.Windows.Forms.Button
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents lvConceptos As System.Windows.Forms.ListView
    Friend WithEvents lvidConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents codConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvConcepto As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckActivo As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaBaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents idEscandallo As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cbTipoEscandallo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents observaciones As System.Windows.Forms.TextBox
    Friend WithEvents lvObservaciones As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbUnidad As System.Windows.Forms.Label
    Friend WithEvents ObservacionesC As System.Windows.Forms.TextBox
    Friend WithEvents ckActivoC As System.Windows.Forms.CheckBox
    Friend WithEvents lvSeccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents bBuscarMP As System.Windows.Forms.Button
    Friend WithEvents bBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents bTipo As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSubir As System.Windows.Forms.Button
    Friend WithEvents bBajar As System.Windows.Forms.Button
    Friend WithEvents lvCosteU As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CosteTotalMaterial As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bArticuloC As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbMonedaC As System.Windows.Forms.Label
    Friend WithEvents lbCambio As System.Windows.Forms.Label
    Friend WithEvents Coste As System.Windows.Forms.TextBox
    Friend WithEvents bCopiar As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbdatos As System.Windows.Forms.TabControl
    Friend WithEvents tbDesglose As System.Windows.Forms.TabPage
    Friend WithEvents CosteTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CosteTotalTiempo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbTiempos As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ObservacionesT As System.Windows.Forms.TextBox
    Friend WithEvents bLimpiarTiempo As System.Windows.Forms.Button
    Friend WithEvents Horas As System.Windows.Forms.TextBox
    Friend WithEvents bSeccionesT As System.Windows.Forms.Button
    Friend WithEvents PrecioHora As System.Windows.Forms.TextBox
    Friend WithEvents cbSeccionT As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lvTiempos As System.Windows.Forms.ListView
    Friend WithEvents lvidTiempo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSeccionT As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvHoras As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPrecioHora As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvObservacionesT As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lbFechaBaja As System.Windows.Forms.Label
    Friend WithEvents lbActualizacion As System.Windows.Forms.Label
    Friend WithEvents lvCoste As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Version As System.Windows.Forms.TextBox
    Friend WithEvents bPropagar As System.Windows.Forms.Button
    Friend WithEvents pbCarga As System.Windows.Forms.ProgressBar
    Friend WithEvents lvFamilia As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvSubFamiila As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckSubEscandallos As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents bEscandalloCompleto As System.Windows.Forms.Button
    Friend WithEvents txMateriaPrima As System.Windows.Forms.TextBox
    Friend WithEvents txCodMateriaPrima As System.Windows.Forms.TextBox
    Friend WithEvents txFamilia As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txSeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txSubFamila As System.Windows.Forms.TextBox
    Friend WithEvents lbActualizandoPrecios As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txEscandallo As System.Windows.Forms.TextBox
End Class
