''' <summary>
''' Repository interface thao tác với bảng Apartment
''' </summary>
Public Interface IApartmentRepository

    ''' <summary>
    ''' Lấy danh sách căn hộ có phân trang
    ''' </summary>
    Function GetPagedListWithKeyword(keyword As String, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto)

    ''' <summary>
    ''' Trả về tổng số căn hộ trong bảng (phục vụ phân trang)
    ''' </summary>
    Function GetTotalCount() As Integer

    ''' <summary>
    ''' Lấy chi tiết căn hộ theo Id
    ''' </summary>
    Function GetById(id As Integer) As Apartment

    ''' <summary>
    ''' Thêm mới căn hộ
    ''' </summary>
    Sub Add(apartment As Apartment)

    ''' <summary>
    ''' Cập nhật thông tin căn hộ
    ''' </summary>
    Sub Update(apartment As Apartment)

    ''' <summary>
    ''' Xoá căn hộ theo Id
    ''' </summary>
    Sub Delete(id As Integer)

End Interface
