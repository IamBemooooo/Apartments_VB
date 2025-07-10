''' <summary>
''' Bản ánh xạ giữa Role và Permission
''' </summary>
Public Class RolePermission
    Public Property RoleId As Integer
    Public Property PermissionId As Integer

    ' Optional: navigation
    Public Property Role As Role
    Public Property Permission As Permission
End Class
