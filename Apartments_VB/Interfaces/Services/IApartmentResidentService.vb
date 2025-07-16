''' <summary>
''' Giao diện service xử lý logic nghiệp vụ giữa Resident và Apartment.
''' </summary>
Public Interface IApartmentResidentService

    ''' <summary>
    ''' Gán một resident vào một căn hộ. Logic sẽ kiểm tra xem resident có đang ở phòng khác hay không và tự động xử lý.
    ''' </summary>
    ''' <param name="dto">Thông tin tạo mới (ResidentId, ApartmentId, StartDate, Note)</param>
    ''' <returns>Thông tin kết quả gồm tên phòng, tên resident, ngày bắt đầu ở,...</returns>
    Function AssignResident(dto As ApartmentResidentCreateDto) As AssignResidentResultDto

    ''' <summary>
    ''' Lấy danh sách các lần ở của resident trong một căn hộ (có thể lọc theo trạng thái đang ở).
    ''' </summary>
    Function GetResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of ResidentStayHistoryDto)

    ''' <summary>
    ''' Lấy danh sách các căn hộ mà resident từng ở (có thể lọc theo trạng thái đang ở).
    ''' </summary>
    Function GetApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of ApartmentStayHistoryDto)

    ''' <summary>
    ''' Lấy thông tin căn hộ hiện tại resident đang ở.
    ''' </summary>
    Function GetCurrentApartmentByResidentId(residentId As Integer) As ApartmentDto

    ''' <summary>
    ''' Đánh dấu resident đã rời khỏi căn hộ hiện tại.
    ''' </summary>
    Sub MarkResidentAsMovedOut(residentId As Integer, moveOutDate As DateTime)

    ''' <summary>
    ''' Kiểm tra resident có đang ở đúng căn hộ này không.
    ''' </summary>
    Function IsResidentCurrentlyInApartment(residentId As Integer, apartmentId As Integer) As Boolean

    ''' <summary>
    ''' Đếm tổng số lần cư trú của resident trong một căn hộ cụ thể (có thể lọc theo đang ở/đã rời).
    ''' </summary>
    Function CountResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer

    ''' <summary>
    ''' Đếm tổng số căn hộ mà resident từng ở (có thể lọc theo đang ở/đã rời).
    ''' </summary>
    Function CountApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer

End Interface
