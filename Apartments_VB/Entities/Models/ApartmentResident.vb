Public Class ApartmentResident
    Private _id As Integer
    Private _residentId As Integer
    Private _apartmentId As Integer
    Private _startDate As DateTime
    Private _endDate As DateTime?
    Private _note As String

    Public Sub New()
        _startDate = DateTime.Now
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property ResidentId As Integer
        Get
            Return _residentId
        End Get
        Set(value As Integer)
            _residentId = value
        End Set
    End Property

    Public Property ApartmentId As Integer
        Get
            Return _apartmentId
        End Get
        Set(value As Integer)
            _apartmentId = value
        End Set
    End Property

    Public Property StartDate As DateTime
        Get
            Return _startDate
        End Get
        Set(value As DateTime)
            _startDate = value
        End Set
    End Property

    Public Property EndDate As DateTime?
        Get
            Return _endDate
        End Get
        Set(value As DateTime?)
            _endDate = value
        End Set
    End Property

    Public Property Note As String
        Get
            Return _note
        End Get
        Set(value As String)
            _note = value
        End Set
    End Property
End Class
