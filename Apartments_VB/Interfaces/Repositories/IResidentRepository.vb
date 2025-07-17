''' <summary>
''' Giao diện thao tác dữ liệu bảng Resident.
''' </summary>
Public Interface IResidentRepository

    ''' <summary>
    ''' Thêm mới một resident.
    ''' </summary>
    ''' <param name="resident">Thông tin resident</param>
    ''' <returns>Resident vừa được thêm (bao gồm Id)</returns>
    Function Add(resident As Resident) As Resident

    ''' <summary>
    ''' Cập nhật thông tin resident.
    ''' </summary>
    ''' <param name="resident">Thông tin cần cập nhật</param>
    ''' <returns>Resident sau khi cập nhật</returns>
    Function Update(resident As Resident) As Resident

    ''' <summary>
    ''' Xóa mềm một resident (cập nhật IsActive = False).
    ''' </summary>
    ''' <param name="id">ID resident cần xóa</param>
    ''' <returns>Resident vừa được đánh dấu đã xóa. Trả về Nothing nếu không tìm thấy.</returns>
    Function Delete(id As Integer) As Resident

    ''' <summary>
    ''' Lấy danh sách resident có phân trang và tìm kiếm.
    ''' </summary>
    ''' <param name="keyword">Từ khóa tìm kiếm theo tên, số điện thoại, email</param>
    ''' <param name="isStaying">
    '''     - True: chỉ lấy resident đang ở
    '''     - False: chỉ lấy resident đã rời khỏi tất cả căn hộ
    '''     - Nothing: lấy tất cả
    ''' </param>
    ''' <param name="pageIndex">Trang cần lấy (bắt đầu từ 1)</param>
    ''' <param name="pageSize">Số dòng mỗi trang</param>
    ''' <returns>Danh sách resident thỏa mãn</returns>
    Function GetPagedList(keyword As String, Optional isStaying As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of Resident)

    ''' <summary>
    ''' Lấy tổng số resident đang còn hiệu lực (IsActive = True), có áp dụng bộ lọc.
    ''' </summary>
    ''' <param name="keyword">Từ khóa tìm kiếm</param>
    ''' <param name="isStaying">Lọc theo trạng thái cư trú</param>
    Function GetTotalCount(keyword As String, Optional isStaying As Boolean? = Nothing) As Integer

    ''' <summary>
    ''' Lấy resident theo ID (chỉ lấy khi IsActive = True).
    ''' </summary>
    Function GetById(id As Integer) As Resident

    ''' <summary>
    ''' Lấy thông tin resident theo số điện thoại.
    ''' </summary>
    ''' <param name="phone">Số điện thoại cần tìm</param>
    ''' <returns>Resident nếu tìm thấy, ngược lại trả về Nothing</returns>
    Function GetByPhone(phone As String) As Resident

    ''' <summary>
    ''' Khôi phục trạng thái IsActive = True và cập nhật lại thông tin resident.
    ''' Dùng khi resident đã tồn tại trước đó nhưng bị xóa mềm.
    ''' </summary>
    ''' <param name="resident">Thông tin cần cập nhật</param>
    ''' <returns>Resident sau khi được khôi phục và cập nhật</returns>
    Function RestoreAndUpdate(resident As Resident) As Resident

    ''' <summary>
    ''' Kiểm tra xem số điện thoại đã được sử dụng bởi cư dân khác hay chưa (trừ cư dân đang cập nhật).
    ''' </summary>
    ''' <param name="phone">Số điện thoại cần kiểm tra.</param>
    ''' <param name="excludedResidentId">ID cư dân đang cập nhật để loại trừ khỏi kiểm tra.</param>
    ''' <returns>True nếu số điện thoại đã tồn tại ở cư dân khác, False nếu không.</returns>
    Function ExistsPhone(phone As String, excludedResidentId As Integer) As Boolean

End Interface
