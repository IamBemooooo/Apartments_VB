<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResidentCreateForm
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
        Me.lblErrorEmail = New System.Windows.Forms.Label()
        Me.lblErrorPhone = New System.Windows.Forms.Label()
        Me.lblErrorDOB = New System.Windows.Forms.Label()
        Me.lblErrorGender = New System.Windows.Forms.Label()
        Me.lblErrorName = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbxGender = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'lblErrorEmail
        '
        Me.lblErrorEmail.AutoSize = True
        Me.lblErrorEmail.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorEmail.Location = New System.Drawing.Point(165, 280)
        Me.lblErrorEmail.Name = "lblErrorEmail"
        Me.lblErrorEmail.Size = New System.Drawing.Size(70, 16)
        Me.lblErrorEmail.TabIndex = 32
        Me.lblErrorEmail.Text = "ErrorEmail"
        '
        'lblErrorPhone
        '
        Me.lblErrorPhone.AutoSize = True
        Me.lblErrorPhone.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorPhone.Location = New System.Drawing.Point(165, 231)
        Me.lblErrorPhone.Name = "lblErrorPhone"
        Me.lblErrorPhone.Size = New System.Drawing.Size(75, 16)
        Me.lblErrorPhone.TabIndex = 31
        Me.lblErrorPhone.Text = "ErrorPhone"
        '
        'lblErrorDOB
        '
        Me.lblErrorDOB.AutoSize = True
        Me.lblErrorDOB.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorDOB.Location = New System.Drawing.Point(165, 173)
        Me.lblErrorDOB.Name = "lblErrorDOB"
        Me.lblErrorDOB.Size = New System.Drawing.Size(65, 16)
        Me.lblErrorDOB.TabIndex = 30
        Me.lblErrorDOB.Text = "ErrorDOB"
        '
        'lblErrorGender
        '
        Me.lblErrorGender.AutoSize = True
        Me.lblErrorGender.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorGender.Location = New System.Drawing.Point(165, 119)
        Me.lblErrorGender.Name = "lblErrorGender"
        Me.lblErrorGender.Size = New System.Drawing.Size(81, 16)
        Me.lblErrorGender.TabIndex = 29
        Me.lblErrorGender.Text = "ErrorGender"
        '
        'lblErrorName
        '
        Me.lblErrorName.AutoSize = True
        Me.lblErrorName.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorName.Location = New System.Drawing.Point(165, 61)
        Me.lblErrorName.Name = "lblErrorName"
        Me.lblErrorName.Size = New System.Drawing.Size(73, 16)
        Me.lblErrorName.TabIndex = 28
        Me.lblErrorName.Text = "ErrorName"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(311, 318)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 36)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Lưu"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cbxGender
        '
        Me.cbxGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxGender.FormattingEnabled = True
        Me.cbxGender.Location = New System.Drawing.Point(165, 83)
        Me.cbxGender.Name = "cbxGender"
        Me.cbxGender.Size = New System.Drawing.Size(332, 28)
        Me.cbxGender.TabIndex = 26
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(165, 250)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(332, 27)
        Me.txtEmail.TabIndex = 24
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(165, 192)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(332, 27)
        Me.txtPhone.TabIndex = 23
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(165, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(332, 27)
        Me.txtName.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Giới tính :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Email :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "SĐT :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Ngày sinh :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Tên cư dân :"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(165, 138)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(332, 27)
        Me.dtpDateOfBirth.TabIndex = 33
        '
        'ResidentCreateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 366)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.lblErrorEmail)
        Me.Controls.Add(Me.lblErrorPhone)
        Me.Controls.Add(Me.lblErrorDOB)
        Me.Controls.Add(Me.lblErrorGender)
        Me.Controls.Add(Me.lblErrorName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbxGender)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ResidentCreateForm"
        Me.Text = "ResidentCreateForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblErrorEmail As Label
    Friend WithEvents lblErrorPhone As Label
    Friend WithEvents lblErrorDOB As Label
    Friend WithEvents lblErrorGender As Label
    Friend WithEvents lblErrorName As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cbxGender As ComboBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDateOfBirth As DateTimePicker
End Class
