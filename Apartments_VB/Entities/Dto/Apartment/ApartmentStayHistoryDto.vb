Public Class ApartmentStayHistoryDto
    Public Property Id As Integer
    Public Property Name As String
    Public Property Address As String
    Public Property FloorCount As Integer?

    ''' <summary>
    ''' Tên loại căn hộ (ApartmentType.TypeName)
    ''' </summary>
    Public Property ApartmentTypeName As String
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime?
End Class
