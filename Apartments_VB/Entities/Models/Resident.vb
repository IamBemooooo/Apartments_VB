Public Class Resident
    Private _id As Integer
    Private _fullName As String
    Private _phone As String
    Private _email As String
    Private _dateOfBirth As DateTime?
    Private _gender As Integer
    Private _isActive As Boolean
    Private _createdDate As DateTime

    Public Sub New()
        _createdDate = DateTime.Now
        _isActive = True
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
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

    Public Property Phone As String
        Get
            Return _phone
        End Get
        Set(value As String)
            _phone = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property DateOfBirth As DateTime?
        Get
            Return _dateOfBirth
        End Get
        Set(value As DateTime?)
            _dateOfBirth = value
        End Set
    End Property

    Public Property Gender As Integer
        Get
            Return _gender
        End Get
        Set(value As Integer)
            _gender = value
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

    Public Property CreatedDate As DateTime
        Get
            Return _createdDate
        End Get
        Set(value As DateTime)
            _createdDate = value
        End Set
    End Property
End Class
