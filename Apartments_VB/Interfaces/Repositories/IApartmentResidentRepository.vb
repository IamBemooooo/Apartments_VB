''' <summary>
''' Giao diện xử lý dữ liệu liên quan đến quan hệ giữa Resident và Apartment.
''' </summary>
Public Interface IApartmentResidentRepository

    ''' <summary>
    ''' Lấy danh sách tất cả các lần cư trú của resident trong một căn hộ cụ thể.
    ''' Có thể lọc theo trạng thái đang ở hay đã rời đi. Có hỗ trợ phân trang.
    ''' </summary>
    ''' <param name="apartmentId">ID của căn hộ cần truy vấn</param>
    ''' <param name="endDateNullOnly">
    '''     - True: chỉ lấy resident đang ở (EndDate IS NULL)
    '''     - False: chỉ lấy resident đã rời đi (EndDate IS NOT NULL)
    '''     - Nothing: lấy tất cả
    ''' </param>
    ''' <param name="pageIndex">Trang cần lấy (bắt đầu từ 1)</param>
    ''' <param name="pageSize">Số dòng mỗi trang</param>
    ''' <returns>Danh sách các lần cư trú của resident tại căn hộ</returns>
    Function GetResidentStayHistoryByApartmentId(
        apartmentId As Integer,
        Optional endDateNullOnly As Boolean? = Nothing,
        Optional pageIndex As Integer = 1,
        Optional pageSize As Integer = 10
    ) As List(Of ResidentStayHistoryDto)

    ''' <summary>
    ''' Lấy danh sách tất cả các căn hộ mà một resident đã từng ở.
    ''' Có thể lọc theo trạng thái đang ở hay đã rời đi. Có hỗ trợ phân trang.
    ''' </summary>
    ''' <param name="residentId">ID của resident cần truy vấn</param>
    ''' <param name="endDateNullOnly">
    '''     - True: chỉ lấy căn hộ hiện tại (EndDate IS NULL)
    '''     - False: chỉ lấy căn hộ đã rời (EndDate IS NOT NULL)
    '''     - Nothing: lấy tất cả
    ''' </param>
    ''' <param name="pageIndex">Trang cần lấy (bắt đầu từ 1)</param>
    ''' <param name="pageSize">Số dòng mỗi trang</param>
    ''' <returns>Danh sách căn hộ resident đã hoặc đang ở</returns>
    Function GetApartmentStayHistoryByResidentId(
        residentId As Integer,
        Optional endDateNullOnly As Boolean? = Nothing,
        Optional pageIndex As Integer = 1,
        Optional pageSize As Integer = 10
    ) As List(Of ApartmentStayHistoryDto)

    ''' <summary>
    ''' Gán một resident vào một căn hộ, tương ứng với việc tạo mới bản ghi cư trú.
    ''' Nếu resident đang ở phòng khác thì tự động cập nhật ngày rời khỏi cũ.
    ''' Nếu đã ở đúng phòng thì không làm gì.
    ''' Trả về thông tin sau khi gán thành công.
    ''' </summary>
    Function AssignResidentToApartment(entity As ApartmentResident) As AssignResidentResultDto
    ''' <summary>
    ''' Kiểm tra xem resident hiện đang ở đúng căn hộ được chỉ định hay không.
    ''' </summary>
    Function IsResidentCurrentlyInApartment(residentId As Integer, apartmentId As Integer) As Boolean

    ''' <summary>
    ''' Lấy thông tin căn hộ mà resident hiện đang cư trú (nếu có).
    ''' </summary>
    Function GetCurrentApartmentByResidentId(residentId As Integer) As ApartmentDto

    ''' <summary>
    ''' Cập nhật ngày rời khỏi (EndDate) cho bản ghi cư trú hiện tại của resident.
    ''' </summary>
    Sub MarkResidentAsMovedOut(residentId As Integer, moveOutDate As DateTime)

    ''' <summary>
    ''' Đếm tổng số resident đã từng ở trong một căn hộ cụ thể (có thể lọc theo trạng thái).
    ''' </summary>
    Function CountResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer

    ''' <summary>
    ''' Đếm tổng số căn hộ mà resident đã từng ở (có thể lọc theo trạng thái).
    ''' </summary>
    Function CountApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer

End Interface
