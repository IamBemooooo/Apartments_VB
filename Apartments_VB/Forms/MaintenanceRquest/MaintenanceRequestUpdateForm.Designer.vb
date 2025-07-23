<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceRequestUpdateForm
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
        Me.rtxtDescription = New System.Windows.Forms.RichTextBox()
        Me.lblErrorDescription = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtApartmentName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        Me.lblErrorStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'rtxtDescription
        '
        Me.rtxtDescription.Location = New System.Drawing.Point(154, 169)
        Me.rtxtDescription.Name = "rtxtDescription"
        Me.rtxtDescription.Size = New System.Drawing.Size(248, 96)
        Me.rtxtDescription.TabIndex = 23
        Me.rtxtDescription.Text = ""
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.AutoSize = True
        Me.lblErrorDescription.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorDescription.Location = New System.Drawing.Point(151, 268)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.Size = New System.Drawing.Size(104, 16)
        Me.lblErrorDescription.TabIndex = 22
        Me.lblErrorDescription.Text = "ErrorDescription"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(320, 307)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 36)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Lưu"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Tên chung cư :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Mô tả :"
        '
        'txtApartmentName
        '
        Me.txtApartmentName.Location = New System.Drawing.Point(152, 50)
        Me.txtApartmentName.Name = "txtApartmentName"
        Me.txtApartmentName.ReadOnly = True
        Me.txtApartmentName.Size = New System.Drawing.Size(248, 22)
        Me.txtApartmentName.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Trạng thái :"
        '
        'cbxStatus
        '
        Me.cbxStatus.FormattingEnabled = True
        Me.cbxStatus.Location = New System.Drawing.Point(152, 101)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(248, 24)
        Me.cbxStatus.TabIndex = 26
        '
        'lblErrorStatus
        '
        Me.lblErrorStatus.AutoSize = True
        Me.lblErrorStatus.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorStatus.Location = New System.Drawing.Point(151, 128)
        Me.lblErrorStatus.Name = "lblErrorStatus"
        Me.lblErrorStatus.Size = New System.Drawing.Size(73, 16)
        Me.lblErrorStatus.TabIndex = 27
        Me.lblErrorStatus.Text = "ErrorStatus"
        '
        'MaintenanceRequestUpdateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 372)
        Me.Controls.Add(Me.lblErrorStatus)
        Me.Controls.Add(Me.cbxStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtApartmentName)
        Me.Controls.Add(Me.rtxtDescription)
        Me.Controls.Add(Me.lblErrorDescription)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MaintenanceRequestUpdateForm"
        Me.Text = "MaintenanceRequestUpdateForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtxtDescription As RichTextBox
    Friend WithEvents lblErrorDescription As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtApartmentName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxStatus As ComboBox
    Friend WithEvents lblErrorStatus As Label
End Class
