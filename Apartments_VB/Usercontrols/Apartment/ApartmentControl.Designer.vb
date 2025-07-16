<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApartmentControl
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
        Me.lblPagingInfo = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvApartments = New System.Windows.Forms.DataGridView()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cbxApartmentType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnResetSearch = New System.Windows.Forms.Button()
        Me.btnApartmentResident = New System.Windows.Forms.Button()
        CType(Me.dgvApartments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPagingInfo
        '
        Me.lblPagingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagingInfo.Location = New System.Drawing.Point(673, 440)
        Me.lblPagingInfo.Name = "lblPagingInfo"
        Me.lblPagingInfo.ReadOnly = True
        Me.lblPagingInfo.Size = New System.Drawing.Size(377, 28)
        Me.lblPagingInfo.TabIndex = 17
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(693, 32)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(239, 27)
        Me.txtSearch.TabIndex = 16
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Location = New System.Drawing.Point(938, 29)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 38)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Tìm kiếm"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(280, 446)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(111, 40)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Xóa"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(956, 474)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 33)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = "Sau"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(848, 474)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(102, 33)
        Me.btnPrev.TabIndex = 12
        Me.btnPrev.Text = "Trước"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(148, 446)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 40)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "Sửa"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(20, 446)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 40)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Thêm"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvApartments
        '
        Me.dgvApartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApartments.Location = New System.Drawing.Point(22, 116)
        Me.dgvApartments.Name = "dgvApartments"
        Me.dgvApartments.RowHeadersWidth = 51
        Me.dgvApartments.RowTemplate.Height = 24
        Me.dgvApartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApartments.Size = New System.Drawing.Size(1028, 291)
        Me.dgvApartments.TabIndex = 9
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.SteelBlue
        Me.btnExport.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnExport.Location = New System.Drawing.Point(938, 73)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(112, 38)
        Me.btnExport.TabIndex = 18
        Me.btnExport.Text = "Export Excel"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'cbxApartmentType
        '
        Me.cbxApartmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxApartmentType.FormattingEnabled = True
        Me.cbxApartmentType.Location = New System.Drawing.Point(331, 32)
        Me.cbxApartmentType.Name = "cbxApartmentType"
        Me.cbxApartmentType.Size = New System.Drawing.Size(221, 28)
        Me.cbxApartmentType.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Loại căn hộ: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(572, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Tên căn hộ: "
        '
        'btnResetSearch
        '
        Me.btnResetSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnResetSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnResetSearch.Location = New System.Drawing.Point(22, 72)
        Me.btnResetSearch.Name = "btnResetSearch"
        Me.btnResetSearch.Size = New System.Drawing.Size(132, 38)
        Me.btnResetSearch.TabIndex = 22
        Me.btnResetSearch.Text = "Xóa tìm kiếm"
        Me.btnResetSearch.UseVisualStyleBackColor = False
        '
        'btnApartmentResident
        '
        Me.btnApartmentResident.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnApartmentResident.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApartmentResident.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnApartmentResident.Location = New System.Drawing.Point(775, 73)
        Me.btnApartmentResident.Name = "btnApartmentResident"
        Me.btnApartmentResident.Size = New System.Drawing.Size(157, 38)
        Me.btnApartmentResident.TabIndex = 23
        Me.btnApartmentResident.Text = "Lịch sử cư trú"
        Me.btnApartmentResident.UseVisualStyleBackColor = False
        '
        'ApartmentControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnApartmentResident)
        Me.Controls.Add(Me.btnResetSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxApartmentType)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lblPagingInfo)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvApartments)
        Me.Name = "ApartmentControl"
        Me.Size = New System.Drawing.Size(1071, 575)
        CType(Me.dgvApartments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPagingInfo As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents dgvApartments As DataGridView
    Friend WithEvents btnExport As Button
    Friend WithEvents cbxApartmentType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnResetSearch As Button
    Friend WithEvents btnApartmentResident As Button
End Class
