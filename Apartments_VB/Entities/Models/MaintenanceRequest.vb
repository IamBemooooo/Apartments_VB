''' <summary>
''' Yêu cầu bảo trì căn hộ
''' </summary>
Public Class MaintenanceRequest
    Public Property Id As Integer
    Public Property ApartmentId As Integer
    Public Property RequestDate As DateTime
    Public Property Description As String
    Public Property Status As String ' (Pending, InProgress, Completed)
End Class
