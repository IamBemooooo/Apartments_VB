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
    ''' Thêm mới căn hộ và trả về bản ghi vừa thêm
    ''' </summary>
    Function Add(apartment As Apartment) As Apartment

    ''' <summary>
    ''' Cập nhật thông tin căn hộ và trả về bản ghi sau cập nhật
    ''' </summary>
    Function Update(apartment As Apartment) As Apartment

    ''' <summary>
    ''' Xoá căn hộ theo Id
    ''' </summary>
    Sub Delete(id As Integer)

End Interface
