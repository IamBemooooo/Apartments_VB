Public Class ApartmentService
    Implements IApartmentService

    Private ReadOnly _repository As IApartmentRepository

    Public Sub New(repository As IApartmentRepository)
        _repository = repository
    End Sub

    Public Function GetPagedList(keyword As String, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto) Implements IApartmentService.GetPagedList
        Return _repository.GetPagedListWithKeyword(keyword, pageIndex, pageSize)
    End Function

    Public Function GetTotalCount() As Integer Implements IApartmentService.GetTotalCount
        Return _repository.GetTotalCount()
    End Function

    Public Function GetById(id As Integer) As Apartment Implements IApartmentService.GetById
        Return _repository.GetById(id)
    End Function

    Public Sub Add(apartment As Apartment) Implements IApartmentService.Add
        ' Logic xử lý trước khi lưu
        apartment.CreatedDate = DateTime.Now
        _repository.Add(apartment)
    End Sub

    Public Sub Update(apartment As Apartment) Implements IApartmentService.Update
        _repository.Update(apartment)
    End Sub

    Public Sub Delete(id As Integer) Implements IApartmentService.Delete
        _repository.Delete(id)
    End Sub

End Class
