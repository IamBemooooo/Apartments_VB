''' <summary>
''' Xử lý nghiệp vụ liên quan đến người dùng.
''' </summary>
Public Interface IUserService
    ''' <summary>
    ''' Xác thực đăng nhập và trả về User nếu hợp lệ.
    ''' </summary>
    Function Login(username As String, password As String) As User
End Interface
