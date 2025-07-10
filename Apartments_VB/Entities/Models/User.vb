''' <summary>
''' Tài khoản người dùng trong hệ thống
''' </summary>
Public Class User
    Public Property Id As Integer
    Public Property Username As String
    Public Property PasswordHash As String
    Public Property FullName As String
    Public Property IsActive As Boolean
    Public Property RoleId As Integer

    ' Optional: navigation
    Public Property Role As Role
End Class
