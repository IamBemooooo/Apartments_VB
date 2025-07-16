<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResidentControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btnResetSearch = New System.Windows.Forms.Button()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblPagingInfo = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnDetail = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvResidents = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.dgvResidents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnResetSearch
        '
        Me.btnResetSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnResetSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnResetSearch.Location = New System.Drawing.Point(22, 18)
        Me.btnResetSearch.Name = "btnResetSearch"
        Me.btnResetSearch.Size = New System.Drawing.Size(132, 38)
        Me.btnResetSearch.TabIndex = 36
        Me.btnResetSearch.Text = "Xóa tìm kiếm"
        Me.btnResetSearch.UseVisualStyleBackColor = False
        '
        'cbxStatus
        '
        Me.cbxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxStatus.FormattingEnabled = True
        Me.cbxStatus.Location = New System.Drawing.Point(22, 62)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(221, 28)
        Me.cbxStatus.TabIndex = 34
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.SteelBlue
        Me.btnExport.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnExport.Location = New System.Drawing.Point(938, 51)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(112, 38)
        Me.btnExport.TabIndex = 33
        Me.btnExport.Text = "Export Excel"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'lblPagingInfo
        '
        Me.lblPagingInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagingInfo.Location = New System.Drawing.Point(673, 430)
        Me.lblPagingInfo.Name = "lblPagingInfo"
        Me.lblPagingInfo.ReadOnly = True
        Me.lblPagingInfo.Size = New System.Drawing.Size(377, 28)
        Me.lblPagingInfo.TabIndex = 32
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSearch.Location = New System.Drawing.Point(539, 55)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 38)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "Tìm kiếm"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(280, 436)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(111, 40)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Xóa"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(956, 464)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 33)
        Me.btnNext.TabIndex = 28
        Me.btnNext.Text = "Sau"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(848, 464)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(102, 33)
        Me.btnPrev.TabIndex = 27
        Me.btnPrev.Text = "Trước"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(148, 436)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(111, 40)
        Me.btnDetail.TabIndex = 26
        Me.btnDetail.Text = "Chi tiết"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(20, 436)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 40)
        Me.btnAdd.TabIndex = 25
        Me.btnAdd.Text = "Thêm"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvResidents
        '
        Me.dgvResidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResidents.Location = New System.Drawing.Point(22, 106)
        Me.dgvResidents.Name = "dgvResidents"
        Me.dgvResidents.RowHeadersWidth = 51
        Me.dgvResidents.RowTemplate.Height = 24
        Me.dgvResidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResidents.Size = New System.Drawing.Size(1028, 291)
        Me.dgvResidents.TabIndex = 24
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(269, 62)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(239, 27)
        Me.txtSearch.TabIndex = 38
        '
        'ResidentControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnResetSearch)
        Me.Controls.Add(Me.cbxStatus)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.lblPagingInfo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvResidents)
        Me.Name = "ResidentControl"
        Me.Size = New System.Drawing.Size(1071, 575)
        CType(Me.dgvResidents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnResetSearch As Button
    Friend WithEvents cbxStatus As ComboBox
    Friend WithEvents btnExport As Button
    Friend WithEvents lblPagingInfo As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnDetail As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents dgvResidents As DataGridView
    Friend WithEvents txtSearch As TextBox
End Class
