''' <summary>
''' Service interface xử lý nghiệp vụ liên quan đến yêu cầu bảo trì căn hộ
''' </summary>
Public Interface IMaintenanceRequestService

    ''' <summary>
    ''' Lấy danh sách yêu cầu bảo trì có phân trang và lọc theo trạng thái và căn hộ
    ''' </summary>
    ''' <param name="pageIndex">Trang hiện tại (bắt đầu từ 1)</param>
    ''' <param name="pageSize">Số phần tử mỗi trang</param>
    ''' <param name="status">Trạng thái yêu cầu bảo trì (0: Pending, 1: InProgress, 2: Completed)</param>
    ''' <param name="apartmentId">ID căn hộ muốn lọc, nếu là 0 thì bỏ lọc theo căn hộ</param>
    ''' <returns>Danh sách yêu cầu bảo trì</returns>
    Function GetPagedList(pageIndex As Integer, pageSize As Integer, status As Integer, apartmentId As Integer) As List(Of MaintenanceRequestDto)

    ''' <summary>
    ''' Đếm tổng số yêu cầu bảo trì theo trạng thái và căn hộ (phục vụ phân trang)
    ''' </summary>
    ''' <param name="status">Trạng thái cần đếm</param>
    ''' <param name="apartmentId">ID căn hộ muốn lọc</param>
    ''' <returns>Tổng số yêu cầu bảo trì thỏa điều kiện</returns>
    Function CountByFilter(status As Integer, apartmentId As Integer) As Integer

    ''' <summary>
    ''' Lấy chi tiết yêu cầu bảo trì theo ID
    ''' </summary>
    ''' <param name="id">ID yêu cầu bảo trì</param>
    ''' <returns>Chi tiết yêu cầu bảo trì</returns>
    Function GetById(id As Integer) As MaintenanceRequestDto

    ''' <summary>
    ''' Thêm mới một yêu cầu bảo trì
    ''' </summary>
    ''' <param name="request">Thông tin yêu cầu cần thêm</param>
    ''' <returns>Thông tin yêu cầu sau khi thêm</returns>
    Function Add(request As MaintenanceRequestCreateDto) As MaintenanceRequestDto

    ''' <summary>
    ''' Cập nhật nội dung mô tả hoặc trạng thái của yêu cầu bảo trì
    ''' </summary>
    ''' <param name="request">Dữ liệu cập nhật</param>
    Function Update(request As MaintenanceRequestUpdateDto) As MaintenanceRequestDto

End Interface
