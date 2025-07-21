Public Interface IMaintenanceRequestRepository
    ''' <summary>
    ''' Lấy danh sách yêu cầu bảo trì có phân trang và lọc theo trạng thái và căn hộ
    ''' </summary>
    ''' <param name="pageIndex">Trang hiện tại (bắt đầu từ 1)</param>
    ''' <param name="pageSize">Số phần tử mỗi trang</param>
    ''' <param name="status">Trạng thái yêu cầu bảo trì (0: Pending, 1: InProgress, 2: Completed)</param>
    ''' <param name="apartmentId">ID của căn hộ</param>
    ''' <returns>Danh sách yêu cầu bảo trì</returns>
    Function GetPagedList(pageIndex As Integer, pageSize As Integer, status As Integer, apartmentId As Integer) As List(Of MaintenanceRequestDto)

    ''' <summary>
    ''' Đếm tổng số yêu cầu bảo trì theo trạng thái và căn hộ (phục vụ phân trang)
    ''' </summary>
    ''' <param name="status">Trạng thái lọc</param>
    ''' <param name="apartmentId">ID căn hộ</param>
    ''' <returns>Tổng số bản ghi phù hợp</returns>
    Function CountByFilter(status As Integer, apartmentId As Integer) As Integer

    ''' <summary>
    ''' Lấy chi tiết 1 yêu cầu bảo trì theo ID
    ''' </summary>
    Function GetById(id As Integer) As MaintenanceRequestDto

    ''' <summary>
    ''' Tạo mới yêu cầu bảo trì
    ''' </summary>
    ''' <param name="request">Entity chứa dữ liệu yêu cầu bảo trì</param>
    ''' <returns>DTO của yêu cầu bảo trì sau khi thêm thành công</returns>
    Function Add(request As MaintenanceRequest) As MaintenanceRequestDto

    ''' <summary>
    ''' Cập nhật mô tả và trạng thái của yêu cầu bảo trì
    ''' </summary>
    ''' <param name="request">Entity chứa thông tin cần cập nhật</param>
    ''' <returns>DTO của yêu cầu sau khi cập nhật</returns>
    Function Update(request As MaintenanceRequest) As MaintenanceRequestDto


End Interface
