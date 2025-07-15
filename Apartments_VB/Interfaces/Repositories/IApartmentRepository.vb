''' <summary>
''' Repository interface thao tác với bảng Apartment
''' </summary>
Public Interface IApartmentRepository

    ''' <summary>
    ''' Lấy danh sách căn hộ có phân trang, theo keyword và loại căn hộ
    ''' </summary>
    Function GetPagedListWithKeyword(keyword As String, typeId As Integer, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto)

    ''' <summary>
    ''' Trả về tổng số căn hộ theo từ khóa và loại căn hộ (phục vụ phân trang)
    ''' </summary>
    Function GetTotalCount(ByVal keyword As String, ByVal typeId As Integer) As Integer

    ''' <summary>
    ''' Lấy tất cả căn hộ theo từ khóa và loại căn hộ
    ''' </summary>
    Function GetAllByKeyword(keyword As String, typeId As Integer) As List(Of ApartmentDto)

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
