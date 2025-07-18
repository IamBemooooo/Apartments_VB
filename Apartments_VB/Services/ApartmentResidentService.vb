Public Class ApartmentResidentService
    Implements IApartmentResidentService

    Private ReadOnly _repo As IApartmentResidentRepository

    Public Sub New(repo As IApartmentResidentRepository)
        _repo = repo
    End Sub

    Public Function AssignResident(dto As ApartmentResidentCreateDto) As AssignResidentResultDto Implements IApartmentResidentService.AssignResident
        ' Nếu đang ở đúng phòng, không làm gì cả
        If _repo.IsResidentCurrentlyInApartment(dto.ResidentId, dto.ApartmentId) Then
            Throw New Exception("Cư dân đã ở căn hộ này.")
        End If

        ' Map từ DTO sang Entity
        Dim entity As New ApartmentResident With {
        .ApartmentId = dto.ApartmentId,
        .ResidentId = dto.ResidentId,
        .StartDate = dto.StartDate,
        .Note = dto.Note
        }

        ' Gán resident vào phòng (nếu không đang ở phòng khác)
        Return _repo.AssignResidentToApartment(entity)
    End Function

    Public Function GetResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of ResidentStayHistoryDto) Implements IApartmentResidentService.GetResidentStayHistoryByApartmentId
        ' Gọi trực tiếp repo đã xử lý phân trang
        Return _repo.GetResidentStayHistoryByApartmentId(apartmentId, endDateNullOnly, pageIndex, pageSize)
    End Function

    Public Function GetApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of ApartmentStayHistoryDto) Implements IApartmentResidentService.GetApartmentStayHistoryByResidentId
        ' Gọi trực tiếp repo đã xử lý phân trang
        Return _repo.GetApartmentStayHistoryByResidentId(residentId, endDateNullOnly, pageIndex, pageSize)
    End Function

    Public Function GetCurrentApartmentByResidentId(residentId As Integer) As ApartmentDto Implements IApartmentResidentService.GetCurrentApartmentByResidentId
        Return _repo.GetCurrentApartmentByResidentId(residentId)
    End Function

    Public Sub MarkResidentAsMovedOut(residentId As Integer, moveOutDate As DateTime, note As String) Implements IApartmentResidentService.MarkResidentAsMovedOut
        _repo.MarkResidentAsMovedOut(residentId, moveOutDate, note)
    End Sub

    Public Function IsResidentCurrentlyInApartment(residentId As Integer, apartmentId As Integer) As Boolean Implements IApartmentResidentService.IsResidentCurrentlyInApartment
        Return _repo.IsResidentCurrentlyInApartment(residentId, apartmentId)
    End Function

    Public Function CountResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer Implements IApartmentResidentService.CountResidentStayHistoryByApartmentId
        Return _repo.CountResidentStayHistoryByApartmentId(apartmentId, endDateNullOnly)
    End Function

    Public Function CountApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer Implements IApartmentResidentService.CountApartmentStayHistoryByResidentId
        Return _repo.CountApartmentStayHistoryByResidentId(residentId, endDateNullOnly)
    End Function
End Class
