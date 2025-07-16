''' <summary>
''' Kết quả của việc gán resident vào căn hộ.
''' Bao gồm thông tin phòng, thông tin resident và ngày bắt đầu ở.
''' </summary>
Public Class AssignResidentResultDto
    ' Thông tin phòng
    Public Property ApartmentName As String
    Public Property ApartmentAddress As String

    ' Thông tin resident
    Public Property ResidentFullName As String
    Public Property ResidentAge As Integer?
    Public Property ResidentGender As Integer  ' 0: Nam, 1: Nữ, hoặc enum nếu bạn có
    Public Property ResidentPhone As String
    Public Property ResidentEmail As String

    ' Ngày bắt đầu ở
    Public Property StartDate As DateTime
End Class
