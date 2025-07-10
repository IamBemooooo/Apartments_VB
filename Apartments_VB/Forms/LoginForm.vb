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
            Dim username As String = txtUserName.Text.Trim()
            Dim password As String = txtPassword.Text

            ' Kiểm tra đầu vào
            If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Gọi service để đăng nhập
            Dim user = _userService.Login(username, password)

            If user IsNot Nothing Then
                MessageBox.Show("Đăng nhập thành công! Xin chào: " & user.FullName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Ẩn hoặc đóng LoginForm
                Dim apartmentService As IApartmentService = New ApartmentService(New ApartmentRepository())
                Dim apartmentForm As New ApartmentForm(apartmentService)

                Me.Hide()
                apartmentForm.ShowDialog()

                Me.Close()


            Else
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
