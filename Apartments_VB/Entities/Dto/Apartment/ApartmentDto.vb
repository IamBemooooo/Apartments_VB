''' <summary>
''' Dữ liệu căn hộ được trả về cho UI (View Model)
''' </summary>
Public Class ApartmentDto
    Public Property Id As Integer
    Public Property Name As String
    Public Property Address As String
    Public Property FloorCount As Integer?
    Public Property CreatedDate As DateTime
    Public Property Price As Decimal

    ''' <summary>
    ''' Tên loại căn hộ (ApartmentType.TypeName)
    ''' </summary>
    Public Property ApartmentTypeName As String
End Class
