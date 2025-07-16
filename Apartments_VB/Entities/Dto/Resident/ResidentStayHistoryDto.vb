''' <summary>
''' DTO chứa thông tin Resident kèm thời gian ở trong một Apartment cụ thể
''' </summary>
Public Class ResidentStayHistoryDto
    Public Property Id As Integer
    Public Property FullName As String
    Public Property Phone As String
    Public Property Email As String
    Public Property DateOfBirth As DateTime?
    Public Property Gender As Integer
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime?
End Class
