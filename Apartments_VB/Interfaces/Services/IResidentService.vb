''' <summary>
''' Giao diện xử lý nghiệp vụ liên quan đến Resident.
''' </summary>
Public Interface IResidentService

    ''' <summary>
    ''' Thêm mới một resident.
    ''' </summary>
    ''' <param name="dto">Thông tin resident cần tạo</param>
    ''' <returns>Resident vừa tạo</returns>
    Function Add(dto As ResidentCreateDto) As Resident

    ''' <summary>
    ''' Cập nhật thông tin resident.
    ''' </summary>
    ''' <param name="dto">Thông tin mới</param>
    ''' <returns>Resident sau khi cập nhật</returns>
    Function Update(dto As ResidentUpdateDto) As Resident

    ''' <summary>
    ''' Xóa mềm một resident (cập nhật IsActive = False).
    ''' </summary>
    ''' <param name="id">ID resident cần xóa</param>
    ''' <returns>Resident vừa bị xóa mềm</returns>
    Function Delete(id As Integer) As Resident

    ''' <summary>
    ''' Lấy danh sách resident có phân trang và tìm kiếm.
    ''' </summary>
    Function GetPagedList(keyword As String, Optional isStaying As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of Resident)

    ''' <summary>
    ''' Lấy tổng số resident đang còn hiệu lực.
    ''' </summary>
    Function GetTotalCount(keyword As String, Optional isStaying As Boolean? = Nothing) As Integer

    ''' <summary>
    ''' Lấy resident theo ID.
    ''' </summary>
    Function GetById(id As Integer) As Resident

End Interface
