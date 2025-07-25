<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddResidentToApartment
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
        Me.btnResetSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxApartmentType = New System.Windows.Forms.ComboBox()
        Me.lblPagingInfo = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvApartments = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        CType(Me.dgvApartments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnResetSearch
        '
        Me.btnResetSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnResetSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnResetSearch.Location = New System.Drawing.Point(23, 71)
        Me.btnResetSearch.Name = "btnResetSearch"
        Me.btnResetSearch.Size = New System.Drawing.Size(132, 38)
        Me.btnResetSearch.TabIndex = 37
        Me.btnResetSearch.Text = "Xóa tìm kiếm"
        Me.btnResetSearch.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(573, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Tên căn hộ: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(205, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Loại căn hộ: "
        '
        'cbxApartmentType
        '
        Me.cbxApartmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxApartmentType.FormattingEnabled = True
        Me.cbxApartmentType.Location = New System.Drawing.Point(332, 73)
        Me.cbxApartmentType.Name = "cbxApartmentType"
        Me.cbxApartmentType.Size = New System.Drawing.Size(221, 28)
        Me.cbxApartmentType.TabIndex = 34
        '
        'lblPagingInfo
        '
        Me.lblPagingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagingInfo.Location = New System.Drawing.Point(674, 439)
        Me.lblPagingInfo.Name = "lblPagingInfo"
        Me.lblPagingInfo.ReadOnly = True
        Me.lblPagingInfo.Size = New System.Drawing.Size(377, 28)
        Me.lblPagingInfo.TabIndex = 32
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(694, 73)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(239, 27)
        Me.txtSearch.TabIndex = 31
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Location = New System.Drawing.Point(939, 70)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 38)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "Tìm kiếm"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(957, 473)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 33)
        Me.btnNext.TabIndex = 28
        Me.btnNext.Text = "Sau"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(849, 473)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(102, 33)
        Me.btnPrev.TabIndex = 27
        Me.btnPrev.Text = "Trước"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(23, 427)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 40)
        Me.btnAdd.TabIndex = 25
        Me.btnAdd.Text = "Chuyển vào"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvApartments
        '
        Me.dgvApartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApartments.Location = New System.Drawing.Point(23, 115)
        Me.dgvApartments.Name = "dgvApartments"
        Me.dgvApartments.RowHeadersWidth = 51
        Me.dgvApartments.RowTemplate.Height = 24
        Me.dgvApartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApartments.Size = New System.Drawing.Size(1028, 291)
        Me.dgvApartments.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(336, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(361, 25)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Vui lòng chọn căn hộ muốn chuyển vào!"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBack.Location = New System.Drawing.Point(930, 6)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(121, 32)
        Me.btnBack.TabIndex = 52
        Me.btnBack.Text = "Quay lại"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'AddResidentToApartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnResetSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxApartmentType)
        Me.Controls.Add(Me.lblPagingInfo)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvApartments)
        Me.Name = "AddResidentToApartment"
        Me.Size = New System.Drawing.Size(1071, 575)
        CType(Me.dgvApartments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnResetSearch As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxApartmentType As ComboBox
    Friend WithEvents lblPagingInfo As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents dgvApartments As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBack As Button
End Class
