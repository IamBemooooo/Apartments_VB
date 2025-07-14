''' <summary>
''' Vai trò người dùng (ví dụ: Admin, User)
''' </summary>
Public Class Role
    Private _id As Integer
    Private _name As String
    Private _description As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property
End Class
