''' <summary>
''' Yêu cầu bảo trì căn hộ
''' </summary>
Public Class MaintenanceRequest
    Private _id As Integer
    Private _apartmentId As Integer
    Private _requestDate As DateTime
    Private _description As String
    Private _status As String ' (Pending, InProgress, Completed)

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
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

    Public Property RequestDate As DateTime
        Get
            Return _requestDate
        End Get
        Set(value As DateTime)
            _requestDate = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property
End Class
