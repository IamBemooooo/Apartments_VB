''' <summary>
''' Căn hộ cụ thể trong hệ thống
''' </summary>
Public Class Apartment
    Public Property Id As Integer
    Public Property ApartmentTypeId As Integer
    Public Property Name As String
    Public Property Address As String
    Public Property FloorCount As Integer?
    Public Property CreatedDate As DateTime
    Public Property Price As Decimal

    ' Optional: navigation property
    Public Property ApartmentType As ApartmentType
End Class
