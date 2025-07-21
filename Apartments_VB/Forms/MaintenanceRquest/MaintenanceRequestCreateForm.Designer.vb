<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceRequestCreateForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbxApartment = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblErrorApartment = New System.Windows.Forms.Label()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.rtxtDescription = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'cbxApartment
        '
        Me.cbxApartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxApartment.FormattingEnabled = True
        Me.cbxApartment.Location = New System.Drawing.Point(168, 41)
        Me.cbxApartment.Name = "cbxApartment"
        Me.cbxApartment.Size = New System.Drawing.Size(248, 28)
        Me.cbxApartment.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Tên chung cư :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Tên chung cư :"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(334, 258)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 36)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Lưu"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblErrorApartment
        '
        Me.lblErrorApartment.AutoSize = True
        Me.lblErrorApartment.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorApartment.Location = New System.Drawing.Point(165, 72)
        Me.lblErrorApartment.Name = "lblErrorApartment"
        Me.lblErrorApartment.Size = New System.Drawing.Size(97, 16)
        Me.lblErrorApartment.TabIndex = 17
        Me.lblErrorApartment.Text = "ErrorApartment"
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.AutoSize = True
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorDescription.Location = New System.Drawing.Point(165, 219)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.Size = New System.Drawing.Size(104, 16)
        Me.lblErrorDescription.TabIndex = 16
        Me.lblErrorDescription.Text = "ErrorDescription"
        '
        'rtxtDescription
        '
        Me.rtxtDescription.Location = New System.Drawing.Point(168, 120)
        Me.rtxtDescription.Name = "rtxtDescription"
        Me.rtxtDescription.Size = New System.Drawing.Size(248, 96)
        Me.rtxtDescription.TabIndex = 18
        Me.rtxtDescription.Text = ""
        '
        'MaintenanceRequestCreateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 306)
        Me.Controls.Add(Me.rtxtDescription)
        Me.Controls.Add(Me.lblErrorApartment)
        Me.Controls.Add(Me.lblErrorDescription)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbxApartment)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MaintenanceRequestCreateForm"
        Me.Text = "MaintenanceRequestCreateForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxApartment As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblErrorApartment As Label
    Friend WithEvents lblErrorDescription As Label
    Friend WithEvents rtxtDescription As RichTextBox
End Class
