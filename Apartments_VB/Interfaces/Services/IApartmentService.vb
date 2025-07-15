''' <summary>
''' Service xử lý nghiệp vụ liên quan đến Apartment
''' </summary>
Public Interface IApartmentService

    ''' <summary>
    ''' Lấy danh sách căn hộ có phân trang (trả về DTO)
    ''' </summary>
    Function GetPagedList(keyword As String, typeId As Integer, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto)

    ''' <summary>
    ''' Trả về tổng số căn hộ (phục vụ phân trang), có thể lọc theo từ khóa tìm kiếm,loại căn hộ.
    ''' </summary>
    ''' <param name="keyword">Từ khóa tìm kiếm theo tên hoặc địa chỉ căn hộ (tùy chọn).</param>
    Function GetTotalCount(keyword As String, typeId As Integer) As Integer

    ''' <summary>
    ''' Lấy thông tin chi tiết căn hộ theo Id (trả về entity)
    ''' </summary>
    Function GetById(id As Integer) As Apartment

    ''' <summary>
    ''' Thêm căn hộ mới (dùng DTO để truyền dữ liệu đầu vào, trả về entity)
    ''' </summary>
    Function Add(apartment As ApartmentCreateDto) As Apartment

    ''' <summary>
    ''' Cập nhật căn hộ (dùng DTO để truyền dữ liệu đầu vào, trả về entity)
    ''' </summary>
    Function Update(apartment As ApartmentUpdateDto) As Apartment

    ''' <summary>
    ''' Xoá căn hộ
    ''' </summary>
    Sub Delete(id As Integer)


    ''' <summary>
    ''' Lấy tất cả căn hộ theo từ khóa tìm kiếm (trả về danh sách DTO)
    ''' </summary>
    ''' <param name="keyword"></param>
    ''' <returns></returns>
    Function GetAllByKeyword(keyword As String, typeId As Integer) As List(Of ApartmentDto)
End Interface
