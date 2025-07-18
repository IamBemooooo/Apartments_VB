<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResidentDetailControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPagingInfo = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.dgvStayHistory = New System.Windows.Forms.DataGridView()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.cbxGender = New System.Windows.Forms.ComboBox()
        Me.lblErrorEmail = New System.Windows.Forms.Label()
        Me.lblErrorPhone = New System.Windows.Forms.Label()
        Me.lblErrorDOB = New System.Windows.Forms.Label()
        Me.lblErrorGender = New System.Windows.Forms.Label()
        Me.lblErrorName = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAddResidentToApartment = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        Me.btnLeft = New System.Windows.Forms.Button()
        CType(Me.dgvStayHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(98, 65)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(226, 27)
        Me.txtName.TabIndex = 0
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(98, 133)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(226, 27)
        Me.txtPhone.TabIndex = 1
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(473, 65)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(226, 27)
        Me.txtEmail.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tên :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "SĐT :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(374, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Email :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(374, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ngày sinh :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(739, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Giới tính :"
        '
        'lblPagingInfo
        '
        Me.lblPagingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagingInfo.Location = New System.Drawing.Point(675, 429)
        Me.lblPagingInfo.Name = "lblPagingInfo"
        Me.lblPagingInfo.ReadOnly = True
        Me.lblPagingInfo.Size = New System.Drawing.Size(377, 28)
        Me.lblPagingInfo.TabIndex = 36
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(958, 463)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 33)
        Me.btnNext.TabIndex = 35
        Me.btnNext.Text = "Sau"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(850, 463)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(102, 33)
        Me.btnPrev.TabIndex = 34
        Me.btnPrev.Text = "Trước"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'dgvStayHistory
        '
        Me.dgvStayHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStayHistory.Location = New System.Drawing.Point(24, 233)
        Me.dgvStayHistory.Name = "dgvStayHistory"
        Me.dgvStayHistory.RowHeadersWidth = 51
        Me.dgvStayHistory.RowTemplate.Height = 24
        Me.dgvStayHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStayHistory.Size = New System.Drawing.Size(1028, 190)
        Me.dgvStayHistory.TabIndex = 33
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(473, 131)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(347, 27)
        Me.dtpDateOfBirth.TabIndex = 37
        '
        'cbxGender
        '
        Me.cbxGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxGender.FormattingEnabled = True
        Me.cbxGender.Location = New System.Drawing.Point(826, 64)
        Me.cbxGender.Name = "cbxGender"
        Me.cbxGender.Size = New System.Drawing.Size(226, 28)
        Me.cbxGender.TabIndex = 38
        '
        'lblErrorEmail
        '
        Me.lblErrorEmail.AutoSize = True
        Me.lblErrorEmail.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorEmail.Location = New System.Drawing.Point(470, 96)
        Me.lblErrorEmail.Name = "lblErrorEmail"
        Me.lblErrorEmail.Size = New System.Drawing.Size(70, 16)
        Me.lblErrorEmail.TabIndex = 43
        Me.lblErrorEmail.Text = "ErrorEmail"
        '
        'lblErrorPhone
        '
        Me.lblErrorPhone.AutoSize = True
        Me.lblErrorPhone.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorPhone.Location = New System.Drawing.Point(95, 163)
        Me.lblErrorPhone.Name = "lblErrorPhone"
        Me.lblErrorPhone.Size = New System.Drawing.Size(75, 16)
        Me.lblErrorPhone.TabIndex = 42
        Me.lblErrorPhone.Text = "ErrorPhone"
        '
        'lblErrorDOB
        '
        Me.lblErrorDOB.AutoSize = True
        Me.lblErrorDOB.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorDOB.Location = New System.Drawing.Point(470, 161)
        Me.lblErrorDOB.Name = "lblErrorDOB"
        Me.lblErrorDOB.Size = New System.Drawing.Size(65, 16)
        Me.lblErrorDOB.TabIndex = 41
        Me.lblErrorDOB.Text = "ErrorDOB"
        '
        'lblErrorGender
        '
        Me.lblErrorGender.AutoSize = True
        Me.lblErrorGender.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorGender.Location = New System.Drawing.Point(823, 95)
        Me.lblErrorGender.Name = "lblErrorGender"
        Me.lblErrorGender.Size = New System.Drawing.Size(81, 16)
        Me.lblErrorGender.TabIndex = 40
        Me.lblErrorGender.Text = "ErrorGender"
        '
        'lblErrorName
        '
        Me.lblErrorName.AutoSize = True
        Me.lblErrorName.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorName.Location = New System.Drawing.Point(95, 95)
        Me.lblErrorName.Name = "lblErrorName"
        Me.lblErrorName.Size = New System.Drawing.Size(73, 16)
        Me.lblErrorName.TabIndex = 39
        Me.lblErrorName.Text = "ErrorName"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Goldenrod
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(931, 130)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(121, 32)
        Me.btnUpdate.TabIndex = 44
        Me.btnUpdate.Text = "Cập nhật"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnAddResidentToApartment
        '
        Me.btnAddResidentToApartment.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAddResidentToApartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddResidentToApartment.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnAddResidentToApartment.Location = New System.Drawing.Point(931, 194)
        Me.btnAddResidentToApartment.Name = "btnAddResidentToApartment"
        Me.btnAddResidentToApartment.Size = New System.Drawing.Size(121, 32)
        Me.btnAddResidentToApartment.TabIndex = 45
        Me.btnAddResidentToApartment.Text = "Chuyển cư trú"
        Me.btnAddResidentToApartment.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(29, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 20)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "LỊCH SỬ CƯ TRÚ :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.SlateGray
        Me.Label7.Location = New System.Drawing.Point(30, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(205, 20)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "THÔNG TIN CHI TIẾT :"
        '
        'cbxStatus
        '
        Me.cbxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxStatus.FormattingEnabled = True
        Me.cbxStatus.Location = New System.Drawing.Point(224, 194)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(144, 28)
        Me.cbxStatus.TabIndex = 49
        '
        'btnLeft
        '
        Me.btnLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeft.Location = New System.Drawing.Point(24, 429)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(121, 32)
        Me.btnLeft.TabIndex = 50
        Me.btnLeft.Text = "Rời đi"
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'ResidentDetailControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnLeft)
        Me.Controls.Add(Me.cbxStatus)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnAddResidentToApartment)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lblErrorEmail)
        Me.Controls.Add(Me.lblErrorPhone)
        Me.Controls.Add(Me.lblErrorDOB)
        Me.Controls.Add(Me.lblErrorGender)
        Me.Controls.Add(Me.lblErrorName)
        Me.Controls.Add(Me.cbxGender)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.lblPagingInfo)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.dgvStayHistory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtName)
        Me.Name = "ResidentDetailControl"
        Me.Size = New System.Drawing.Size(1071, 575)
        CType(Me.dgvStayHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPagingInfo As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents dgvStayHistory As DataGridView
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Friend WithEvents cbxGender As ComboBox
    Friend WithEvents lblErrorEmail As Label
    Friend WithEvents lblErrorPhone As Label
    Friend WithEvents lblErrorDOB As Label
    Friend WithEvents lblErrorGender As Label
    Friend WithEvents lblErrorName As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAddResidentToApartment As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbxStatus As ComboBox
    Friend WithEvents btnLeft As Button
End Class
