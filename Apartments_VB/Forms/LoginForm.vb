Public Class LoginForm
    Private ReadOnly _userService As IUserService

    Public Sub New()
    End Sub

    ' Constructor nhận DI
    Public Sub New(userService As IUserService)
        InitializeComponent()
        _userService = userService
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            ' Reset lỗi trước mỗi lần validate
            lblErrorUserName.Text = ""
            lblErrorPassword.Text = ""

            Dim result As New ValidationResult()

            ' Gọi validation cho các trường
            ValidationHelper.ValidateTextField(result, txtUserName, "Tên đăng nhập", True)
            ValidationHelper.ValidateTextField(result, txtPassword, "Mật khẩu", True)

            lblErrorUserName.Text = result.GetErrorByField(txtUserName.Name)
            lblErrorPassword.Text = result.GetErrorByField(txtPassword.Name)

            ' Nếu có lỗi thì không tiếp tục
            If Not result.IsValid Then Return

            Dim username As String = txtUserName.Text.Trim()
            Dim password As String = txtPassword.Text

            Dim user = _userService.Login(username, password)

            If user IsNot Nothing Then
                MessageBox.Show("Đăng nhập thành công! Xin chào: " & user.FullName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim mainForm As New MainForm(user)
                Me.Hide()
                mainForm.ShowDialog()
            Else
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Reset lỗi trước mỗi lần validate
        lblErrorUserName.Text = ""
        lblErrorPassword.Text = ""
    End Sub
End Class
