''' <summary>
''' Tài khoản người dùng trong hệ thống
''' </summary>
Public Class User
    Private _id As Integer
    Private _username As String
    Private _passwordHash As String
    Private _fullName As String
    Private _isActive As Boolean
    Private _roleId As Integer

    ' Navigation property (tuỳ chọn)
    Private _role As Role

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property PasswordHash As String
        Get
            Return _passwordHash
        End Get
        Set(value As String)
            _passwordHash = value
        End Set
    End Property

    Public Property FullName As String
        Get
            Return _fullName
        End Get
        Set(value As String)
            _fullName = value
        End Set
    End Property

    Public Property IsActive As Boolean
        Get
            Return _isActive
        End Get
        Set(value As Boolean)
            _isActive = value
        End Set
    End Property

    Public Property RoleId As Integer
        Get
            Return _roleId
        End Get
        Set(value As Integer)
            _roleId = value
        End Set
    End Property

    Public Property Role As Role
        Get
            Return _role
        End Get
        Set(value As Role)
            _role = value
        End Set
    End Property
End Class
