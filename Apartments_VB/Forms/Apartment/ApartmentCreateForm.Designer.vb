<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApartmentCreateForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtFloorCount = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.cbxApartmentType = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblErrorApartmentType = New System.Windows.Forms.Label()
        Me.lblErrorPrice = New System.Windows.Forms.Label()
        Me.lblErrorFloorCount = New System.Windows.Forms.Label()
        Me.lblErrorApartmentName = New System.Windows.Forms.Label()
        Me.lblErrorAddress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên chung cư :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Giá :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Số tầng :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Địa chỉ :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Loại chung cư :"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(175, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(248, 27)
        Me.txtName.TabIndex = 5
        '
        'txtFloorCount
        '
        Me.txtFloorCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFloorCount.Location = New System.Drawing.Point(175, 192)
        Me.txtFloorCount.Name = "txtFloorCount"
        Me.txtFloorCount.Size = New System.Drawing.Size(248, 27)
        Me.txtFloorCount.TabIndex = 7
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(175, 250)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(248, 27)
        Me.txtAddress.TabIndex = 8
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(175, 138)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(248, 27)
        Me.txtPrice.TabIndex = 9
        '
        'cbxApartmentType
        '
        Me.cbxApartmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxApartmentType.FormattingEnabled = True
        Me.cbxApartmentType.Location = New System.Drawing.Point(175, 83)
        Me.cbxApartmentType.Name = "cbxApartmentType"
        Me.cbxApartmentType.Size = New System.Drawing.Size(248, 28)
        Me.cbxApartmentType.TabIndex = 10
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(321, 318)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 36)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Lưu"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblErrorApartmentType
        '
        Me.lblErrorApartmentType.AutoSize = True
        Me.lblErrorApartmentType.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorApartmentType.Location = New System.Drawing.Point(175, 119)
        Me.lblErrorApartmentType.Name = "lblErrorApartmentType"
        Me.lblErrorApartmentType.Size = New System.Drawing.Size(129, 16)
        Me.lblErrorApartmentType.TabIndex = 13
        Me.lblErrorApartmentType.Text = "ErrorApartmentType"
        '
        'lblErrorPrice
        '
        Me.lblErrorPrice.AutoSize = True
        Me.lblErrorPrice.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorPrice.Location = New System.Drawing.Point(175, 173)
        Me.lblErrorPrice.Name = "lblErrorPrice"
        Me.lblErrorPrice.Size = New System.Drawing.Size(67, 16)
        Me.lblErrorPrice.TabIndex = 14
        Me.lblErrorPrice.Text = "ErrorPrice"
        '
        'lblErrorFloorCount
        '
        Me.lblErrorFloorCount.AutoSize = True
        Me.lblErrorFloorCount.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorFloorCount.Location = New System.Drawing.Point(175, 231)
        Me.lblErrorFloorCount.Name = "lblErrorFloorCount"
        Me.lblErrorFloorCount.Size = New System.Drawing.Size(101, 16)
        Me.lblErrorFloorCount.TabIndex = 15
        Me.lblErrorFloorCount.Text = "ErrorFloorCount"
        '
        'lblErrorApartmentName
        '
        Me.lblErrorApartmentName.AutoSize = True
        Me.lblErrorApartmentName.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorApartmentName.Location = New System.Drawing.Point(175, 61)
        Me.lblErrorApartmentName.Name = "lblErrorApartmentName"
        Me.lblErrorApartmentName.Size = New System.Drawing.Size(134, 16)
        Me.lblErrorApartmentName.TabIndex = 12
        Me.lblErrorApartmentName.Text = "ErrorApartmentName"
        '
        'lblErrorAddress
        '
        Me.lblErrorAddress.AutoSize = True
        Me.lblErrorAddress.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorAddress.Location = New System.Drawing.Point(175, 280)
        Me.lblErrorAddress.Name = "lblErrorAddress"
        Me.lblErrorAddress.Size = New System.Drawing.Size(87, 16)
        Me.lblErrorAddress.TabIndex = 16
        Me.lblErrorAddress.Text = "ErrorAddress"
        '
        'ApartmentCreateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 366)
        Me.Controls.Add(Me.lblErrorAddress)
        Me.Controls.Add(Me.lblErrorFloorCount)
        Me.Controls.Add(Me.lblErrorPrice)
        Me.Controls.Add(Me.lblErrorApartmentType)
        Me.Controls.Add(Me.lblErrorApartmentName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbxApartmentType)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtFloorCount)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ApartmentCreateForm"
        Me.Text = "AddApartmentForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtFloorCount As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents cbxApartmentType As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lblErrorApartmentType As Label
    Friend WithEvents lblErrorPrice As Label
    Friend WithEvents lblErrorFloorCount As Label
    Friend WithEvents lblErrorApartmentName As Label
    Friend WithEvents lblErrorAddress As Label
End Class
