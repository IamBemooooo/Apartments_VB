''' <summary>
''' Service xử lý nghiệp vụ liên quan đến Apartment
''' </summary>
Public Interface IApartmentService

    ''' <summary>
    ''' Lấy danh sách căn hộ có phân trang (trả về DTO)
    ''' </summary>
    Function GetPagedList(keyword As String, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto)

    ''' <summary>
    ''' Trả về tổng số căn hộ (phục vụ phân trang)
    ''' </summary>
    Function GetTotalCount() As Integer

    ''' <summary>
    ''' Lấy thông tin chi tiết căn hộ theo Id (trả về entity)
    ''' </summary>
    Function GetById(id As Integer) As Apartment

    ''' <summary>
    ''' Thêm căn hộ mới
    ''' </summary>
    Sub Add(apartment As Apartment)

    ''' <summary>
    ''' Cập nhật căn hộ
    ''' </summary>
    Sub Update(apartment As Apartment)

    ''' <summary>
    ''' Xoá căn hộ
    ''' </summary>
    Sub Delete(id As Integer)

End Interface
