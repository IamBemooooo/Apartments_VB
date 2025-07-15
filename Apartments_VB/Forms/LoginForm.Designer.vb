<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblErrorUserName = New System.Windows.Forms.Label()
        Me.lblErrorPassword = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tài khoản: "
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(144, 59)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(226, 27)
        Me.txtUserName.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(144, 123)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(226, 27)
        Me.txtPassword.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mật khẩu: "
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLogin.Location = New System.Drawing.Point(234, 188)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(136, 39)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Đăng nhập"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lblErrorUserName
        '
        Me.lblErrorUserName.AutoSize = True
        Me.lblErrorUserName.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorUserName.Location = New System.Drawing.Point(144, 93)
        Me.lblErrorUserName.Name = "lblErrorUserName"
        Me.lblErrorUserName.Size = New System.Drawing.Size(141, 16)
        Me.lblErrorUserName.TabIndex = 6
        Me.lblErrorUserName.Text = "thông báo lỗi tài khoản"
        '
        'lblErrorPassword
        '
        Me.lblErrorPassword.AutoSize = True
        Me.lblErrorPassword.ForeColor = System.Drawing.Color.IndianRed
        Me.lblErrorPassword.Location = New System.Drawing.Point(144, 162)
        Me.lblErrorPassword.Name = "lblErrorPassword"
        Me.lblErrorPassword.Size = New System.Drawing.Size(141, 16)
        Me.lblErrorPassword.TabIndex = 7
        Me.lblErrorPassword.Text = "thông báo lỗi mật khẩu"
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 239)
        Me.Controls.Add(Me.lblErrorPassword)
        Me.Controls.Add(Me.lblErrorUserName)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "LoginForm"
        Me.Text = "Đăng nhập"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblErrorUserName As Label
    Friend WithEvents lblErrorPassword As Label
End Class
