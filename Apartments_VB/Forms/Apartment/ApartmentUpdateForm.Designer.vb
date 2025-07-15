<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApartmentUpdateForm
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblErrorAddress = New System.Windows.Forms.Label()
        Me.lblErrorFloorCount = New System.Windows.Forms.Label()
        Me.lblErrorPrice = New System.Windows.Forms.Label()
        Me.lblErrorApartmentType = New System.Windows.Forms.Label()
        Me.lblErrorApartmentName = New System.Windows.Forms.Label()
        Me.cbxApartmentType = New System.Windows.Forms.ComboBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtFloorCount = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(298, 308)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 36)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Lưu"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lblErrorAddress
        '
        Me.lblErrorAddress.AutoSize = True
        Me.lblErrorAddress.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorAddress.Location = New System.Drawing.Point(152, 281)
        Me.lblErrorAddress.Name = "lblErrorAddress"
        Me.lblErrorAddress.Size = New System.Drawing.Size(87, 16)
        Me.lblErrorAddress.TabIndex = 37
        Me.lblErrorAddress.Text = "ErrorAddress"
        '
        'lblErrorFloorCount
        '
        Me.lblErrorFloorCount.AutoSize = True
        Me.lblErrorFloorCount.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorFloorCount.Location = New System.Drawing.Point(152, 232)
        Me.lblErrorFloorCount.Name = "lblErrorFloorCount"
        Me.lblErrorFloorCount.Size = New System.Drawing.Size(101, 16)
        Me.lblErrorFloorCount.TabIndex = 36
        Me.lblErrorFloorCount.Text = "ErrorFloorCount"
        '
        'lblErrorPrice
        '
        Me.lblErrorPrice.AutoSize = True
        Me.lblErrorPrice.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorPrice.Location = New System.Drawing.Point(152, 174)
        Me.lblErrorPrice.Name = "lblErrorPrice"
        Me.lblErrorPrice.Size = New System.Drawing.Size(67, 16)
        Me.lblErrorPrice.TabIndex = 35
        Me.lblErrorPrice.Text = "ErrorPrice"
        '
        'lblErrorApartmentType
        '
        Me.lblErrorApartmentType.AutoSize = True
        Me.lblErrorApartmentType.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorApartmentType.Location = New System.Drawing.Point(152, 120)
        Me.lblErrorApartmentType.Name = "lblErrorApartmentType"
        Me.lblErrorApartmentType.Size = New System.Drawing.Size(129, 16)
        Me.lblErrorApartmentType.TabIndex = 34
        Me.lblErrorApartmentType.Text = "ErrorApartmentType"
        '
        'lblErrorApartmentName
        '
        Me.lblErrorApartmentName.AutoSize = True
        Me.lblErrorApartmentName.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorApartmentName.Location = New System.Drawing.Point(152, 62)
        Me.lblErrorApartmentName.Name = "lblErrorApartmentName"
        Me.lblErrorApartmentName.Size = New System.Drawing.Size(134, 16)
        Me.lblErrorApartmentName.TabIndex = 33
        Me.lblErrorApartmentName.Text = "ErrorApartmentName"
        '
        'cbxApartmentType
        '
        Me.cbxApartmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxApartmentType.FormattingEnabled = True
        Me.cbxApartmentType.Location = New System.Drawing.Point(152, 84)
        Me.cbxApartmentType.Name = "cbxApartmentType"
        Me.cbxApartmentType.Size = New System.Drawing.Size(248, 28)
        Me.cbxApartmentType.TabIndex = 32
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(152, 139)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(248, 27)
        Me.txtPrice.TabIndex = 31
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(152, 251)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(248, 27)
        Me.txtAddress.TabIndex = 30
        '
        'txtFloorCount
        '
        Me.txtFloorCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFloorCount.Location = New System.Drawing.Point(152, 193)
        Me.txtFloorCount.Name = "txtFloorCount"
        Me.txtFloorCount.Size = New System.Drawing.Size(248, 27)
        Me.txtFloorCount.TabIndex = 29
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(152, 27)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(248, 27)
        Me.txtName.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Loại chung cư :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 253)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Địa chỉ :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Số tầng :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Giá :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Tên chung cư :"
        '
        'ApartmentUpdateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 356)
        Me.Controls.Add(Me.lblErrorAddress)
        Me.Controls.Add(Me.lblErrorFloorCount)
        Me.Controls.Add(Me.lblErrorPrice)
        Me.Controls.Add(Me.lblErrorApartmentType)
        Me.Controls.Add(Me.lblErrorApartmentName)
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
        Me.Controls.Add(Me.btnSave)
        Me.Name = "ApartmentUpdateForm"
        Me.Text = "ApartmentUpdateForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents lblErrorAddress As Label
    Friend WithEvents lblErrorFloorCount As Label
    Friend WithEvents lblErrorPrice As Label
    Friend WithEvents lblErrorApartmentType As Label
    Friend WithEvents lblErrorApartmentName As Label
    Friend WithEvents cbxApartmentType As ComboBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtFloorCount As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
