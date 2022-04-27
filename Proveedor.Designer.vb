<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proveedor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CLVPROV = New System.Windows.Forms.ComboBox()
        Me.NOMDIST = New System.Windows.Forms.TextBox()
        Me.TEL = New System.Windows.Forms.TextBox()
        Me.DIREC = New System.Windows.Forms.TextBox()
        Me.NOMPROV = New System.Windows.Forms.TextBox()
        Me.CIUDAD = New System.Windows.Forms.TextBox()
        Me.CP = New System.Windows.Forms.TextBox()
        Me.insertar = New System.Windows.Forms.Button()
        Me.eliminar = New System.Windows.Forms.Button()
        Me.modificar = New System.Windows.Forms.Button()
        Me.consultar = New System.Windows.Forms.Button()
        Me.salir = New System.Windows.Forms.Button()
        Me.EMAIL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(66, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre Proveedor:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(66, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre Distribuidor:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(66, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Telefono:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(66, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Direccion:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(66, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 26)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Codigo Postal:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(66, 279)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Ciudad:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(66, 307)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 24)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Clave:"
        '
        'CLVPROV
        '
        Me.CLVPROV.FormattingEnabled = True
        Me.CLVPROV.Location = New System.Drawing.Point(260, 309)
        Me.CLVPROV.Name = "CLVPROV"
        Me.CLVPROV.Size = New System.Drawing.Size(121, 21)
        Me.CLVPROV.TabIndex = 7
        '
        'NOMDIST
        '
        Me.NOMDIST.Location = New System.Drawing.Point(260, 134)
        Me.NOMDIST.Name = "NOMDIST"
        Me.NOMDIST.Size = New System.Drawing.Size(237, 20)
        Me.NOMDIST.TabIndex = 8
        '
        'TEL
        '
        Me.TEL.Location = New System.Drawing.Point(260, 165)
        Me.TEL.Name = "TEL"
        Me.TEL.Size = New System.Drawing.Size(237, 20)
        Me.TEL.TabIndex = 9
        '
        'DIREC
        '
        Me.DIREC.Location = New System.Drawing.Point(260, 217)
        Me.DIREC.Name = "DIREC"
        Me.DIREC.Size = New System.Drawing.Size(237, 20)
        Me.DIREC.TabIndex = 10
        '
        'NOMPROV
        '
        Me.NOMPROV.Location = New System.Drawing.Point(260, 101)
        Me.NOMPROV.Name = "NOMPROV"
        Me.NOMPROV.Size = New System.Drawing.Size(237, 20)
        Me.NOMPROV.TabIndex = 11
        '
        'CIUDAD
        '
        Me.CIUDAD.Location = New System.Drawing.Point(260, 279)
        Me.CIUDAD.Name = "CIUDAD"
        Me.CIUDAD.Size = New System.Drawing.Size(237, 20)
        Me.CIUDAD.TabIndex = 12
        '
        'CP
        '
        Me.CP.Location = New System.Drawing.Point(260, 247)
        Me.CP.Name = "CP"
        Me.CP.Size = New System.Drawing.Size(237, 20)
        Me.CP.TabIndex = 13
        '
        'insertar
        '
        Me.insertar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.insertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.insertar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insertar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.insertar.Location = New System.Drawing.Point(661, 101)
        Me.insertar.Name = "insertar"
        Me.insertar.Size = New System.Drawing.Size(81, 23)
        Me.insertar.TabIndex = 14
        Me.insertar.Text = "INSERTAR"
        Me.insertar.UseVisualStyleBackColor = False
        '
        'eliminar
        '
        Me.eliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.eliminar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.eliminar.Location = New System.Drawing.Point(661, 153)
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Size = New System.Drawing.Size(82, 23)
        Me.eliminar.TabIndex = 15
        Me.eliminar.Text = "ELIMINAR"
        Me.eliminar.UseVisualStyleBackColor = False
        '
        'modificar
        '
        Me.modificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modificar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.modificar.Location = New System.Drawing.Point(661, 201)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(94, 23)
        Me.modificar.TabIndex = 16
        Me.modificar.Text = "MODIFICAR"
        Me.modificar.UseVisualStyleBackColor = False
        '
        'consultar
        '
        Me.consultar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.consultar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consultar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.consultar.Location = New System.Drawing.Point(661, 258)
        Me.consultar.Name = "consultar"
        Me.consultar.Size = New System.Drawing.Size(94, 23)
        Me.consultar.TabIndex = 17
        Me.consultar.Text = "CONSULTAR"
        Me.consultar.UseVisualStyleBackColor = False
        '
        'salir
        '
        Me.salir.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.salir.BackgroundImage = Global.AbarrotesToro2021.My.Resources.Resources.flecha_abarrotes
        Me.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.salir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salir.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.salir.Location = New System.Drawing.Point(12, 2)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(90, 52)
        Me.salir.TabIndex = 18
        Me.salir.UseVisualStyleBackColor = False
        '
        'EMAIL
        '
        Me.EMAIL.Location = New System.Drawing.Point(260, 189)
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.Size = New System.Drawing.Size(237, 20)
        Me.EMAIL.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(66, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 23)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Email:"
        '
        'Proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowText
        Me.BackgroundImage = Global.AbarrotesToro2021.My.Resources.Resources.Diapositiva1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(811, 450)
        Me.Controls.Add(Me.EMAIL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.salir)
        Me.Controls.Add(Me.consultar)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.eliminar)
        Me.Controls.Add(Me.insertar)
        Me.Controls.Add(Me.CP)
        Me.Controls.Add(Me.CIUDAD)
        Me.Controls.Add(Me.NOMPROV)
        Me.Controls.Add(Me.DIREC)
        Me.Controls.Add(Me.TEL)
        Me.Controls.Add(Me.NOMDIST)
        Me.Controls.Add(Me.CLVPROV)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "Proveedor"
        Me.Text = "Datos de los proveedores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CLVPROV As ComboBox
    Friend WithEvents NOMDIST As TextBox
    Friend WithEvents TEL As TextBox
    Friend WithEvents DIREC As TextBox
    Friend WithEvents NOMPROV As TextBox
    Friend WithEvents CIUDAD As TextBox
    Friend WithEvents CP As TextBox
    Friend WithEvents insertar As Button
    Friend WithEvents eliminar As Button
    Friend WithEvents modificar As Button
    Friend WithEvents consultar As Button
    Friend WithEvents salir As Button
    Friend WithEvents EMAIL As TextBox
    Friend WithEvents Label8 As Label
End Class
