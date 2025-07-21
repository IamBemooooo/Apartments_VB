Public Class MaintenanceRequestService
    Implements IMaintenanceRequestService

    Private ReadOnly _repository As IMaintenanceRequestRepository

    Public Sub New(repository As IMaintenanceRequestRepository)
        _repository = repository
    End Sub

    ''' <inheritdoc />
    Public Function GetPagedList(pageIndex As Integer, pageSize As Integer, status As Integer, apartmentId As Integer) As List(Of MaintenanceRequestDto) Implements IMaintenanceRequestService.GetPagedList
        Return _repository.GetPagedList(pageIndex, pageSize, status, apartmentId)
    End Function

    ''' <inheritdoc />
    Public Function CountByFilter(status As Integer, apartmentId As Integer) As Integer Implements IMaintenanceRequestService.CountByFilter
        Return _repository.CountByFilter(status, apartmentId)
    End Function

    ''' <inheritdoc />
    Public Function GetById(id As Integer) As MaintenanceRequestDto Implements IMaintenanceRequestService.GetById
        Return _repository.GetById(id)
    End Function

    ''' <inheritdoc />
    Public Function Add(request As MaintenanceRequestCreateDto) As MaintenanceRequestDto Implements IMaintenanceRequestService.Add
        Dim entity As New MaintenanceRequest With {
            .ApartmentId = request.ApartmentId,
            .Description = request.Description
        }
        Return _repository.Add(entity)
    End Function

    ''' <inheritdoc />
    Public Function Update(request As MaintenanceRequestUpdateDto) As MaintenanceRequestDto Implements IMaintenanceRequestService.Update
        Dim entity As New MaintenanceRequest With {
            .Id = request.Id,
            .Description = request.Description,
            .Status = request.Status
        }
        Return _repository.Update(entity)
    End Function

End Class

