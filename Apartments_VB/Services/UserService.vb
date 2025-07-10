Public Class UserService
    Implements IUserService

    Private ReadOnly _userRepository As IUserRepository

    Public Sub New(userRepository As IUserRepository)
        _userRepository = userRepository
    End Sub

    Public Function Login(username As String, password As String) As User Implements IUserService.Login
        ' Bạn có thể thêm hash password ở đây nếu cần
        Return _userRepository.Login(username, password)
    End Function
End Class
