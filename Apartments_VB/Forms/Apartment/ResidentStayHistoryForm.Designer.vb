<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResidentStayHistoryForm
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
        Me.dgvResidentStayHistory = New System.Windows.Forms.DataGridView()
        Me.lblPaging = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.cbxStatus = New System.Windows.Forms.ComboBox()
        CType(Me.dgvResidentStayHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvResidentStayHistory
        '
        Me.dgvResidentStayHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResidentStayHistory.Location = New System.Drawing.Point(12, 72)
        Me.dgvResidentStayHistory.Name = "dgvResidentStayHistory"
        Me.dgvResidentStayHistory.RowHeadersWidth = 51
        Me.dgvResidentStayHistory.RowTemplate.Height = 24
        Me.dgvResidentStayHistory.Size = New System.Drawing.Size(638, 223)
        Me.dgvResidentStayHistory.TabIndex = 0
        '
        'lblPaging
        '
        Me.lblPaging.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaging.Location = New System.Drawing.Point(273, 297)
        Me.lblPaging.Name = "lblPaging"
        Me.lblPaging.ReadOnly = True
        Me.lblPaging.Size = New System.Drawing.Size(377, 28)
        Me.lblPaging.TabIndex = 20
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(556, 331)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(94, 33)
        Me.btnNext.TabIndex = 19
        Me.btnNext.Text = "Sau"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(448, 331)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(102, 33)
        Me.btnPrev.TabIndex = 18
        Me.btnPrev.Text = "Trước"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'cbxStatus
        '
        Me.cbxStatus.FormattingEnabled = True
        Me.cbxStatus.Location = New System.Drawing.Point(12, 42)
        Me.cbxStatus.Name = "cbxStatus"
        Me.cbxStatus.Size = New System.Drawing.Size(129, 24)
        Me.cbxStatus.TabIndex = 21
        '
        'ResidentStayHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 376)
        Me.Controls.Add(Me.cbxStatus)
        Me.Controls.Add(Me.lblPaging)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.dgvResidentStayHistory)
        Me.Name = "ResidentStayHistoryForm"
        Me.Text = "ResidentStayHistory"
        CType(Me.dgvResidentStayHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvResidentStayHistory As DataGridView
    Friend WithEvents lblPaging As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents cbxStatus As ComboBox
End Class
