''' <summary>
''' DTO (Data Transfer Object) dùng để nhận dữ liệu khi tạo mới căn hộ
''' </summary>
Public Class ApartmentCreateDto

    ''' <summary>
    ''' ID loại căn hộ (liên kết đến bảng ApartmentType)
    ''' </summary>
    Public Property ApartmentTypeId As Integer

    ''' <summary>
    ''' Tên căn hộ
    ''' </summary>
    Public Property Name As String

    ''' <summary>
    ''' Địa chỉ căn hộ
    ''' </summary>
    Public Property Address As String

    ''' <summary>
    ''' Số tầng (có thể null nếu chưa rõ)
    ''' </summary>
    Public Property FloorCount As Integer?

    ''' <summary>
    ''' Giá tiền căn hộ
    ''' </summary>
    Public Property Price As Decimal

End Class

