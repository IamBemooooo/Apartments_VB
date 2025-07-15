<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnResdidentTab = New System.Windows.Forms.Button()
        Me.btnMaintenanceRequestTab = New System.Windows.Forms.Button()
        Me.btnApartmentTab = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlMainContent = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Controls.Add(Me.lblUserName)
        Me.Panel1.Controls.Add(Me.btnResdidentTab)
        Me.Panel1.Controls.Add(Me.btnMaintenanceRequestTab)
        Me.Panel1.Controls.Add(Me.btnApartmentTab)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 524)
        Me.Panel1.TabIndex = 0
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(12, 11)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(89, 20)
        Me.lblUserName.TabIndex = 5
        Me.lblUserName.Text = "UserName"
        '
        'btnResdidentTab
        '
        Me.btnResdidentTab.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnResdidentTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResdidentTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnResdidentTab.Location = New System.Drawing.Point(4, 141)
        Me.btnResdidentTab.Name = "btnResdidentTab"
        Me.btnResdidentTab.Size = New System.Drawing.Size(193, 44)
        Me.btnResdidentTab.TabIndex = 4
        Me.btnResdidentTab.Text = "Cư Dân và Cư Trú"
        Me.btnResdidentTab.UseVisualStyleBackColor = False
        '
        'btnMaintenanceRequestTab
        '
        Me.btnMaintenanceRequestTab.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnMaintenanceRequestTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaintenanceRequestTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnMaintenanceRequestTab.Location = New System.Drawing.Point(3, 91)
        Me.btnMaintenanceRequestTab.Name = "btnMaintenanceRequestTab"
        Me.btnMaintenanceRequestTab.Size = New System.Drawing.Size(193, 44)
        Me.btnMaintenanceRequestTab.TabIndex = 3
        Me.btnMaintenanceRequestTab.Text = "Yêu Cầu Bảo Trì"
        Me.btnMaintenanceRequestTab.UseVisualStyleBackColor = False
        '
        'btnApartmentTab
        '
        Me.btnApartmentTab.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnApartmentTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApartmentTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnApartmentTab.Location = New System.Drawing.Point(4, 41)
        Me.btnApartmentTab.Name = "btnApartmentTab"
        Me.btnApartmentTab.Size = New System.Drawing.Size(193, 44)
        Me.btnApartmentTab.TabIndex = 2
        Me.btnApartmentTab.Text = "Căn Hộ"
        Me.btnApartmentTab.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(206, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1034, 524)
        Me.Panel2.TabIndex = 1
        '
        'pnlMainContent
        '
        Me.pnlMainContent.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlMainContent.Location = New System.Drawing.Point(207, 2)
        Me.pnlMainContent.Name = "pnlMainContent"
        Me.pnlMainContent.Size = New System.Drawing.Size(1067, 524)
        Me.pnlMainContent.TabIndex = 2
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1286, 528)
        Me.Controls.Add(Me.pnlMainContent)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents btnResdidentTab As Button
    Friend WithEvents btnMaintenanceRequestTab As Button
    Friend WithEvents btnApartmentTab As Button
    Friend WithEvents lblUserName As Label
End Class
