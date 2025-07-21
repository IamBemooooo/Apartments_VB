<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaintenanceRequestControl
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
        Me.cbxApartment = New System.Windows.Forms.ComboBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblPagingInfo = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvRequests = New System.Windows.Forms.DataGridView()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnResetSearch
        '
        Me.btnResetSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnResetSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnResetSearch.Location = New System.Drawing.Point(22, 73)
        Me.btnResetSearch.Name = "btnResetSearch"
        Me.btnResetSearch.Size = New System.Drawing.Size(132, 38)
        Me.btnResetSearch.TabIndex = 34
        Me.btnResetSearch.Text = "Xóa tìm kiếm"
        Me.btnResetSearch.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(572, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Trạng thái: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 20)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Tên căn hộ: "
        '
        'cbxApartment
        '
        Me.cbxApartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxApartment.FormattingEnabled = True
        Me.cbxApartment.Location = New System.Drawing.Point(331, 33)
        Me.cbxApartment.Name = "cbxApartment"
        Me.cbxApartment.Size = New System.Drawing.Size(221, 28)
        Me.cbxApartment.TabIndex = 31
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.SteelBlue
        Me.btnExport.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnExport.Location = New System.Drawing.Point(938, 74)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(112, 38)
        Me.btnExport.TabIndex = 30
        Me.btnExport.Text = "Export Excel"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'lblPagingInfo
        '
        Me.lblPagingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagingInfo.Location = New System.Drawing.Point(673, 441)
        Me.lblPagingInfo.Name = "lblPagingInfo"
        Me.lblPagingInfo.ReadOnly = True
        Me.lblPagingInfo.Size = New System.Drawing.Size(377, 28)
        Me.lblPagingInfo.TabIndex = 29
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Location = New System.Drawing.Point(938, 30)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 38)
        Me.btnSearch.TabIndex = 28
        Me.btnSearch.Text = "Tìm kiếm"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(956, 475)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 33)
        Me.btnNext.TabIndex = 27
        Me.btnNext.Text = "Sau"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(848, 475)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(102, 33)
        Me.btnPrev.TabIndex = 26
        Me.btnPrev.Text = "Trước"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(148, 447)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 40)
        Me.btnUpdate.TabIndex = 25
        Me.btnUpdate.Text = "Cập nhật"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(20, 447)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 40)
        Me.btnAdd.TabIndex = 24
        Me.btnAdd.Text = "Thêm"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvRequests
        '
        Me.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequests.Location = New System.Drawing.Point(22, 117)
        Me.dgvRequests.Name = "dgvRequests"
        Me.dgvRequests.RowHeadersWidth = 51
        Me.dgvRequests.RowTemplate.Height = 24
        Me.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequests.Size = New System.Drawing.Size(1028, 291)
        Me.dgvRequests.TabIndex = 23
        '
        'cbxStatus
        '
        Me.cbxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxStatus.FormattingEnabled = True
        Me.cbxStatus.Location = New System.Drawing.Point(672, 33)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(221, 28)
        Me.cbxStatus.TabIndex = 35
        '
        'MaintenanceRequestControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbxStatus)
        Me.Controls.Add(Me.btnResetSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxApartment)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lblPagingInfo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvRequests)
        Me.Name = "MaintenanceRequestControl"
        Me.Size = New System.Drawing.Size(1071, 575)
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnResetSearch As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxApartment As ComboBox
    Friend WithEvents btnExport As Button
    Friend WithEvents lblPagingInfo As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents dgvRequests As DataGridView
    Friend WithEvents cbxStatus As ComboBox
End Class
