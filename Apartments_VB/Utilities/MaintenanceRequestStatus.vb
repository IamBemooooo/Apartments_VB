''' <summary>
''' Enum biểu diễn trạng thái của yêu cầu bảo trì
''' </summary>
Public Enum MaintenanceRequestStatus
    ''' <summary>
    ''' Yêu cầu đang chờ xử lý
    ''' </summary>
    Pending = 0

    ''' <summary>
    ''' Yêu cầu đang được thực hiện
    ''' </summary>
    InProgress = 1

    ''' <summary>
    ''' Yêu cầu đã hoàn thành
    ''' </summary>
    Completed = 2
End Enum
