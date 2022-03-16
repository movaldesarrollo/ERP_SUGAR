<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class busquedaReparaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(busquedaReparaciones))
        Me.frdatosgenerales = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txRMA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.OtrosTipos = New System.Windows.Forms.TextBox()
        Me.ckOtros = New System.Windows.Forms.CheckBox()
        Me.ckNoGarantia = New System.Windows.Forms.CheckBox()
        Me.ckGarantia = New System.Windows.Forms.CheckBox()
        Me.ckPlaca = New System.Windows.Forms.CheckBox()
        Me.ckSonda = New System.Windows.Forms.CheckBox()
        Me.ckCaja = New System.Windows.Forms.CheckBox()
        Me.ckCelula = New System.Windows.Forms.CheckBox()
        Me.numSerie = New System.Windows.Forms.TextBox()
        Me.Descripciones = New System.Windows.Forms.TextBox()
        Me.numDoc = New System.Windows.Forms.TextBox()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbEstatus = New System.Windows.Forms.ComboBox()
        Me.cbArticulo = New System.Windows.Forms.ComboBox()
        Me.cbCodArticulo = New System.Windows.Forms.ComboBox()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbPersona = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.bSalir = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.lvDocumentos = New System.Windows.Forms.ListView()
        Me.lvnum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvserie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvEstatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvcodArticulo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvGarantia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPrecioReparacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRMA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bNuevo = New System.Windows.Forms.Button()
        Me.Total = New System.Windows.Forms.TextBox()
        Me.Contador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbCambio = New System.Windows.Forms.Label()
        Me.bListado = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txTotatPreciosReparaciones = New System.Windows.Forms.TextBox()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.frdatosgenerales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frdatosgenerales
        '
        Me.frdatosgenerales.Controls.Add(Me.Label12)
        Me.frdatosgenerales.Controls.Add(Me.txRMA)
        Me.frdatosgenerales.Controls.Add(Me.Label10)
        Me.frdatosgenerales.Controls.Add(Me.OtrosTipos)
        Me.frdatosgenerales.Controls.Add(Me.ckOtros)
        Me.frdatosgenerales.Controls.Add(Me.ckNoGarantia)
        Me.frdatosgenerales.Controls.Add(Me.ckGarantia)
        Me.frdatosgenerales.Controls.Add(Me.ckPlaca)
        Me.frdatosgenerales.Controls.Add(Me.ckSonda)
        Me.frdatosgenerales.Controls.Add(Me.ckCaja)
        Me.frdatosgenerales.Controls.Add(Me.ckCelula)
        Me.frdatosgenerales.Controls.Add(Me.numSerie)
        Me.frdatosgenerales.Controls.Add(Me.Descripciones)
        Me.frdatosgenerales.Controls.Add(Me.numDoc)
        Me.frdatosgenerales.Controls.Add(Me.dtpHasta)
        Me.frdatosgenerales.Controls.Add(Me.Label3)
        Me.frdatosgenerales.Controls.Add(Me.dtpDesde)
        Me.frdatosgenerales.Controls.Add(Me.Label13)
        Me.frdatosgenerales.Controls.Add(Me.Label11)
        Me.frdatosgenerales.Controls.Add(Me.Label1)
        Me.frdatosgenerales.Controls.Add(Me.Label2)
        Me.frdatosgenerales.Controls.Add(Me.Label9)
        Me.frdatosgenerales.Controls.Add(Me.Label4)
        Me.frdatosgenerales.Controls.Add(Me.cbEstado)
        Me.frdatosgenerales.Controls.Add(Me.Label14)
        Me.frdatosgenerales.Controls.Add(Me.cbEstatus)
        Me.frdatosgenerales.Controls.Add(Me.cbArticulo)
        Me.frdatosgenerales.Controls.Add(Me.cbCodArticulo)
        Me.frdatosgenerales.Controls.Add(Me.cbCliente)
        Me.frdatosgenerales.Controls.Add(Me.Label8)
        Me.frdatosgenerales.Controls.Add(Me.cbPersona)
        Me.frdatosgenerales.Controls.Add(Me.Label42)
        Me.frdatosgenerales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frdatosgenerales.Location = New System.Drawing.Point(11, 105)
        Me.frdatosgenerales.Name = "frdatosgenerales"
        Me.frdatosgenerales.Size = New System.Drawing.Size(1228, 205)
        Me.frdatosgenerales.TabIndex = 0
        Me.frdatosgenerales.TabStop = False
        Me.frdatosgenerales.Text = "PARÁMETROS DE BÚSQUEDA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(24, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 17)
        Me.Label12.TabIndex = 155
        Me.Label12.Text = "RMA"
        '
        'txRMA
        '
        Me.txRMA.BackColor = System.Drawing.SystemColors.Window
        Me.txRMA.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txRMA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txRMA.Location = New System.Drawing.Point(159, 88)
        Me.txRMA.MaxLength = 15
        Me.txRMA.Name = "txRMA"
        Me.txRMA.Size = New System.Drawing.Size(334, 23)
        Me.txRMA.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(24, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 17)
        Me.Label10.TabIndex = 153
        Me.Label10.Text = "TIPO REPARACIÓN"
        '
        'OtrosTipos
        '
        Me.OtrosTipos.BackColor = System.Drawing.SystemColors.Window
        Me.OtrosTipos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OtrosTipos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.OtrosTipos.Location = New System.Drawing.Point(580, 177)
        Me.OtrosTipos.MaxLength = 15
        Me.OtrosTipos.Name = "OtrosTipos"
        Me.OtrosTipos.Size = New System.Drawing.Size(257, 23)
        Me.OtrosTipos.TabIndex = 17
        '
        'ckOtros
        '
        Me.ckOtros.AutoSize = True
        Me.ckOtros.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckOtros.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckOtros.Location = New System.Drawing.Point(554, 181)
        Me.ckOtros.Name = "ckOtros"
        Me.ckOtros.Size = New System.Drawing.Size(15, 14)
        Me.ckOtros.TabIndex = 15
        Me.ckOtros.UseVisualStyleBackColor = True
        '
        'ckNoGarantia
        '
        Me.ckNoGarantia.AutoSize = True
        Me.ckNoGarantia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckNoGarantia.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckNoGarantia.Location = New System.Drawing.Point(595, 90)
        Me.ckNoGarantia.Name = "ckNoGarantia"
        Me.ckNoGarantia.Size = New System.Drawing.Size(114, 21)
        Me.ckNoGarantia.TabIndex = 7
        Me.ckNoGarantia.Text = "SIN GARANTÍA"
        Me.ckNoGarantia.UseVisualStyleBackColor = True
        '
        'ckGarantia
        '
        Me.ckGarantia.AutoSize = True
        Me.ckGarantia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGarantia.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckGarantia.Location = New System.Drawing.Point(746, 90)
        Me.ckGarantia.Name = "ckGarantia"
        Me.ckGarantia.Size = New System.Drawing.Size(91, 21)
        Me.ckGarantia.TabIndex = 8
        Me.ckGarantia.Text = "GARANTÍA"
        Me.ckGarantia.UseVisualStyleBackColor = True
        '
        'ckPlaca
        '
        Me.ckPlaca.AutoSize = True
        Me.ckPlaca.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPlaca.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckPlaca.Location = New System.Drawing.Point(450, 178)
        Me.ckPlaca.Name = "ckPlaca"
        Me.ckPlaca.Size = New System.Drawing.Size(70, 21)
        Me.ckPlaca.TabIndex = 16
        Me.ckPlaca.Text = "PLACA"
        Me.ckPlaca.UseVisualStyleBackColor = True
        '
        'ckSonda
        '
        Me.ckSonda.AutoSize = True
        Me.ckSonda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckSonda.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckSonda.Location = New System.Drawing.Point(350, 178)
        Me.ckSonda.Name = "ckSonda"
        Me.ckSonda.Size = New System.Drawing.Size(73, 21)
        Me.ckSonda.TabIndex = 15
        Me.ckSonda.Text = "SONDA"
        Me.ckSonda.UseVisualStyleBackColor = True
        '
        'ckCaja
        '
        Me.ckCaja.AutoSize = True
        Me.ckCaja.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCaja.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCaja.Location = New System.Drawing.Point(160, 178)
        Me.ckCaja.Name = "ckCaja"
        Me.ckCaja.Size = New System.Drawing.Size(62, 21)
        Me.ckCaja.TabIndex = 13
        Me.ckCaja.Text = "CAJA"
        Me.ckCaja.UseVisualStyleBackColor = True
        '
        'ckCelula
        '
        Me.ckCelula.AutoSize = True
        Me.ckCelula.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCelula.ForeColor = System.Drawing.Color.DarkBlue
        Me.ckCelula.Location = New System.Drawing.Point(249, 178)
        Me.ckCelula.Name = "ckCelula"
        Me.ckCelula.Size = New System.Drawing.Size(74, 21)
        Me.ckCelula.TabIndex = 14
        Me.ckCelula.Text = "CÉLULA"
        Me.ckCelula.UseVisualStyleBackColor = True
        '
        'numSerie
        '
        Me.numSerie.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSerie.Location = New System.Drawing.Point(159, 149)
        Me.numSerie.MaxLength = 15
        Me.numSerie.Name = "numSerie"
        Me.numSerie.Size = New System.Drawing.Size(113, 23)
        Me.numSerie.TabIndex = 11
        '
        'Descripciones
        '
        Me.Descripciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Descripciones.Location = New System.Drawing.Point(399, 149)
        Me.Descripciones.MaxLength = 15
        Me.Descripciones.Name = "Descripciones"
        Me.Descripciones.Size = New System.Drawing.Size(438, 23)
        Me.Descripciones.TabIndex = 12
        '
        'numDoc
        '
        Me.numDoc.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDoc.Location = New System.Drawing.Point(160, 25)
        Me.numDoc.MaxLength = 15
        Me.numDoc.Name = "numDoc"
        Me.numDoc.Size = New System.Drawing.Size(112, 23)
        Me.numDoc.TabIndex = 0
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(747, 25)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(90, 23)
        Me.dtpHasta.TabIndex = 3
        Me.dtpHasta.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(701, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "HASTA"
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(595, 25)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(90, 23)
        Me.dtpDesde.TabIndex = 2
        Me.dtpDesde.Value = New Date(2011, 11, 25, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(544, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "DESDE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(277, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 17)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "ESTADO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(540, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 17)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "ESTATUS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(24, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "CLIENTE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(282, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 17)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "DESCRIPCIONES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(24, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "ARTÍCULO"
        '
        'cbEstado
        '
        Me.cbEstado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(335, 24)
        Me.cbEstado.MaxLength = 15
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(158, 25)
        Me.cbEstado.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(843, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 17)
        Me.Label14.TabIndex = 104
        Me.Label14.Text = "RECIBIDO POR"
        Me.Label14.Visible = False
        '
        'cbEstatus
        '
        Me.cbEstatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstatus.FormattingEnabled = True
        Me.cbEstatus.Location = New System.Drawing.Point(595, 57)
        Me.cbEstatus.MaxLength = 15
        Me.cbEstatus.Name = "cbEstatus"
        Me.cbEstatus.Size = New System.Drawing.Size(243, 25)
        Me.cbEstatus.TabIndex = 5
        '
        'cbArticulo
        '
        Me.cbArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(289, 117)
        Me.cbArticulo.MaxLength = 15
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(549, 25)
        Me.cbArticulo.TabIndex = 10
        '
        'cbCodArticulo
        '
        Me.cbCodArticulo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodArticulo.FormattingEnabled = True
        Me.cbCodArticulo.Location = New System.Drawing.Point(159, 117)
        Me.cbCodArticulo.MaxLength = 15
        Me.cbCodArticulo.Name = "cbCodArticulo"
        Me.cbCodArticulo.Size = New System.Drawing.Size(113, 25)
        Me.cbCodArticulo.Sorted = True
        Me.cbCodArticulo.TabIndex = 9
        '
        'cbCliente
        '
        Me.cbCliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(160, 57)
        Me.cbCliente.MaxLength = 15
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(333, 25)
        Me.cbCliente.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(24, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 17)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "NÚMERO DE SERIE"
        '
        'cbPersona
        '
        Me.cbPersona.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPersona.FormattingEnabled = True
        Me.cbPersona.Location = New System.Drawing.Point(948, 25)
        Me.cbPersona.MaxLength = 15
        Me.cbPersona.Name = "cbPersona"
        Me.cbPersona.Size = New System.Drawing.Size(274, 25)
        Me.cbPersona.TabIndex = 154
        Me.cbPersona.Visible = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label42.Location = New System.Drawing.Point(24, 28)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(129, 17)
        Me.Label42.TabIndex = 102
        Me.Label42.Text = "NÚM. REPARACIÓN"
        '
        'bSalir
        '
        Me.bSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSalir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bSalir.Location = New System.Drawing.Point(1155, 15)
        Me.bSalir.Name = "bSalir"
        Me.bSalir.Size = New System.Drawing.Size(85, 50)
        Me.bSalir.TabIndex = 7
        Me.bSalir.Text = "SALIR"
        Me.bSalir.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bLimpiar.Location = New System.Drawing.Point(955, 15)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(85, 50)
        Me.bLimpiar.TabIndex = 5
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
        Me.lvDocumentos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lvnum, Me.lvserie, Me.lvCliente, Me.lvFecha, Me.lvEstado, Me.lvEstatus, Me.lvcodArticulo, Me.lvTotal, Me.lvGarantia, Me.colPrecioReparacion, Me.colRMA})
        Me.lvDocumentos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvDocumentos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDocumentos.FullRowSelect = True
        Me.lvDocumentos.GridLines = True
        Me.lvDocumentos.HideSelection = False
        Me.lvDocumentos.Location = New System.Drawing.Point(11, 316)
        Me.lvDocumentos.Name = "lvDocumentos"
        Me.lvDocumentos.ShowItemToolTips = True
        Me.lvDocumentos.Size = New System.Drawing.Size(1229, 421)
        Me.lvDocumentos.TabIndex = 1
        Me.lvDocumentos.UseCompatibleStateImageBehavior = False
        Me.lvDocumentos.View = System.Windows.Forms.View.Details
        '
        'lvnum
        '
        Me.lvnum.Text = "Nº REPARACIÓN"
        Me.lvnum.Width = 105
        '
        'lvserie
        '
        Me.lvserie.DisplayIndex = 2
        Me.lvserie.Text = "Nº SERIE"
        Me.lvserie.Width = 75
        '
        'lvCliente
        '
        Me.lvCliente.DisplayIndex = 3
        Me.lvCliente.Text = "CLIENTE"
        Me.lvCliente.Width = 233
        '
        'lvFecha
        '
        Me.lvFecha.DisplayIndex = 4
        Me.lvFecha.Text = "FECHA"
        Me.lvFecha.Width = 82
        '
        'lvEstado
        '
        Me.lvEstado.DisplayIndex = 5
        Me.lvEstado.Text = "ESTADO"
        Me.lvEstado.Width = 70
        '
        'lvEstatus
        '
        Me.lvEstatus.DisplayIndex = 6
        Me.lvEstatus.Text = "ESTATUS"
        Me.lvEstatus.Width = 100
        '
        'lvcodArticulo
        '
        Me.lvcodArticulo.DisplayIndex = 7
        Me.lvcodArticulo.Text = "ARTÍCULO"
        Me.lvcodArticulo.Width = 100
        '
        'lvTotal
        '
        Me.lvTotal.DisplayIndex = 8
        Me.lvTotal.Text = "TOTAL"
        Me.lvTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.lvTotal.Width = 70
        '
        'lvGarantia
        '
        Me.lvGarantia.DisplayIndex = 9
        Me.lvGarantia.Text = "GARANTÍA"
        Me.lvGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lvGarantia.Width = 75
        '
        'colPrecioReparacion
        '
        Me.colPrecioReparacion.DisplayIndex = 10
        Me.colPrecioReparacion.Text = "ESTIMADO REPARACIÓN"
        Me.colPrecioReparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colPrecioReparacion.Width = 154
        '
        'colRMA
        '
        Me.colRMA.DisplayIndex = 1
        Me.colRMA.Text = "RMA"
        Me.colRMA.Width = 131
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ERP_SUGAR.My.Resources.Resources.LOGO_SUGAR_1_200
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 71)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'bNuevo
        '
        Me.bNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bNuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.bNuevo.Location = New System.Drawing.Point(1055, 15)
        Me.bNuevo.Name = "bNuevo"
        Me.bNuevo.Size = New System.Drawing.Size(85, 50)
        Me.bNuevo.TabIndex = 6
        Me.bNuevo.Text = "NUEVO"
        Me.bNuevo.UseVisualStyleBackColor = True
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Total.BackColor = System.Drawing.SystemColors.Window
        Me.Total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Total.Location = New System.Drawing.Point(820, 743)
        Me.Total.MaxLength = 15
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Size = New System.Drawing.Size(98, 23)
        Me.Total.TabIndex = 3
        Me.Total.TabStop = False
        Me.Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Contador
        '
        Me.Contador.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Contador.BackColor = System.Drawing.SystemColors.Window
        Me.Contador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Contador.Location = New System.Drawing.Point(122, 743)
        Me.Contador.MaxLength = 15
        Me.Contador.Name = "Contador"
        Me.Contador.ReadOnly = True
        Me.Contador.Size = New System.Drawing.Size(60, 23)
        Me.Contador.TabIndex = 2
        Me.Contador.TabStop = False
        Me.Contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(667, 746)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 17)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "TOTAL COSTE CLIENTES"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(12, 746)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "ENCONTRADOS"
        '
        'lbCambio
        '
        Me.lbCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbCambio.AutoSize = True
        Me.lbCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCambio.ForeColor = System.Drawing.Color.Red
        Me.lbCambio.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCambio.Location = New System.Drawing.Point(188, 746)
        Me.lbCambio.Name = "lbCambio"
        Me.lbCambio.Size = New System.Drawing.Size(60, 17)
        Me.lbCambio.TabIndex = 186
        Me.lbCambio.Text = "CAMBIO"
        Me.lbCambio.Visible = False
        '
        'bListado
        '
        Me.bListado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bListado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bListado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bListado.Location = New System.Drawing.Point(855, 15)
        Me.bListado.Name = "bListado"
        Me.bListado.Size = New System.Drawing.Size(85, 50)
        Me.bListado.TabIndex = 4
        Me.bListado.Text = "LISTADO"
        Me.bListado.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(924, 746)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(211, 17)
        Me.Label7.TabIndex = 187
        Me.Label7.Text = "TOTAL ESTIMADO REPARACIONES"
        '
        'txTotatPreciosReparaciones
        '
        Me.txTotatPreciosReparaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txTotatPreciosReparaciones.BackColor = System.Drawing.SystemColors.Window
        Me.txTotatPreciosReparaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTotatPreciosReparaciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txTotatPreciosReparaciones.Location = New System.Drawing.Point(1141, 743)
        Me.txTotatPreciosReparaciones.MaxLength = 15
        Me.txTotatPreciosReparaciones.Name = "txTotatPreciosReparaciones"
        Me.txTotatPreciosReparaciones.ReadOnly = True
        Me.txTotatPreciosReparaciones.Size = New System.Drawing.Size(98, 23)
        Me.txTotatPreciosReparaciones.TabIndex = 188
        Me.txTotatPreciosReparaciones.TabStop = False
        Me.txTotatPreciosReparaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLog
        '
        Me.btnLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLog.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLog.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLog.Location = New System.Drawing.Point(755, 15)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(85, 50)
        Me.btnLog.TabIndex = 189
        Me.btnLog.Text = "LOG"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.Location = New System.Drawing.Point(654, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(85, 50)
        Me.btnBuscar.TabIndex = 190
        Me.btnBuscar.Text = "BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'busquedaReparaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1251, 778)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnLog)
        Me.Controls.Add(Me.txTotatPreciosReparaciones)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.bListado)
        Me.Controls.Add(Me.lbCambio)
        Me.Controls.Add(Me.Contador)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.bNuevo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lvDocumentos)
        Me.Controls.Add(Me.bSalir)
        Me.Controls.Add(Me.frdatosgenerales)
        Me.Controls.Add(Me.bLimpiar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "busquedaReparaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÚSQUEDA DE REPARACIONES"
        Me.frdatosgenerales.ResumeLayout(False)
        Me.frdatosgenerales.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents frdatosgenerales As System.Windows.Forms.GroupBox
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSalir As System.Windows.Forms.Button
    Friend WithEvents lvDocumentos As System.Windows.Forms.ListView
    Friend WithEvents lvnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvcodArticulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents lvFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents cbCodArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents lvEstatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents bNuevo As System.Windows.Forms.Button
    Friend WithEvents Total As System.Windows.Forms.TextBox
    Friend WithEvents Contador As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbCambio As System.Windows.Forms.Label
    Friend WithEvents bListado As System.Windows.Forms.Button
    Friend WithEvents numDoc As System.Windows.Forms.TextBox
    Friend WithEvents numSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Descripciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lvTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OtrosTipos As System.Windows.Forms.TextBox
    Friend WithEvents ckOtros As System.Windows.Forms.CheckBox
    Friend WithEvents ckPlaca As System.Windows.Forms.CheckBox
    Friend WithEvents ckSonda As System.Windows.Forms.CheckBox
    Friend WithEvents ckCaja As System.Windows.Forms.CheckBox
    Friend WithEvents ckCelula As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lvEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckGarantia As System.Windows.Forms.CheckBox
    Friend WithEvents lvGarantia As System.Windows.Forms.ColumnHeader
    Friend WithEvents ckNoGarantia As System.Windows.Forms.CheckBox
    Friend WithEvents lvserie As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrecioReparacion As ColumnHeader
    Friend WithEvents Label7 As Label
    Friend WithEvents txTotatPreciosReparaciones As TextBox
    Friend WithEvents btnLog As Button
    Friend WithEvents colRMA As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents txRMA As TextBox
    Friend WithEvents btnBuscar As Button
End Class
