''' <summary>
''' Bản ánh xạ giữa Role và Permission
''' </summary>
Public Class RolePermission
    Private _roleId As Integer
    Private _permissionId As Integer

    ' Navigation properties (tuỳ chọn)
    Private _role As Role
    Private _permission As Permission

    Public Property RoleId As Integer
        Get
            Return _roleId
        End Get
        Set(value As Integer)
            _roleId = value
        End Set
    End Property

    Public Property PermissionId As Integer
        Get
            Return _permissionId
        End Get
        Set(value As Integer)
            _permissionId = value
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

    Public Property Permission As Permission
        Get
            Return _permission
        End Get
        Set(value As Permission)
            _permission = value
        End Set
    End Property
End Class
