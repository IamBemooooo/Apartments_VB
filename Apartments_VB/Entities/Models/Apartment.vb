''' <summary>
''' Căn hộ cụ thể trong hệ thống
''' </summary>
Public Class Apartment
    Private _id As Integer
    Private _apartmentTypeId As Integer
    Private _name As String
    Private _address As String
    Private _floorCount As Integer?
    Private _createdDate As DateTime
    Private _price As Decimal
    Private _apartmentType As ApartmentType

    Public Sub New()
        _createdDate = DateTime.Now
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property ApartmentTypeId As Integer
        Get
            Return _apartmentTypeId
        End Get
        Set(value As Integer)
            _apartmentTypeId = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Address As String
        Get
            Return _address
        End Get
        Set(value As String)
            _address = value
        End Set
    End Property

    Public Property FloorCount As Integer?
        Get
            Return _floorCount
        End Get
        Set(value As Integer?)
            _floorCount = value
        End Set
    End Property

    Public Property CreatedDate As DateTime
        Get
            Return _createdDate
        End Get
        Set(value As DateTime)
            _createdDate = value
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return _price
        End Get
        Set(value As Decimal)
            _price = value
        End Set
    End Property

    ' Navigation Property (tuỳ chọn)
    Public Property ApartmentType As ApartmentType
        Get
            Return _apartmentType
        End Get
        Set(value As ApartmentType)
            _apartmentType = value
        End Set
    End Property
End Class
