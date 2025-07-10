''' <summary>
''' Interface định nghĩa các thao tác với bảng User.
''' </summary>
Public Interface IUserRepository
    ''' <summary>
    ''' Xác thực tài khoản và trả về đối tượng User nếu hợp lệ.
    ''' </summary>
    ''' <param name="username">Tên đăng nhập</param>
    ''' <param name="password">Mật khẩu dạng plaintext hoặc hash</param>
    Function Login(username As String, password As String) As User
End Interface
