Public Class ApartmentService
    Implements IApartmentService

    Private ReadOnly _repository As IApartmentRepository

    Public Sub New(repository As IApartmentRepository)
        _repository = repository
    End Sub

    Public Function GetById(id As Integer) As Apartment Implements IApartmentService.GetById
        Return _repository.GetById(id)
    End Function

    ''' <summary>
    ''' Cập nhật căn hộ từ ApartmentUpdateDto, trả về entity đã cập nhật
    ''' </summary>
    Public Function Update(apartment As ApartmentUpdateDto) As Apartment Implements IApartmentService.Update
        ' Có thể kiểm tra xem ID tồn tại hay không
        Dim existing = _repository.GetById(apartment.Id)
        If existing Is Nothing Then
            Throw New ArgumentException($"Không tìm thấy căn hộ với ID = {apartment.Id}")
        End If

        existing.ApartmentTypeId = apartment.ApartmentTypeId
        existing.Name = apartment.Name
        existing.Address = apartment.Address
        existing.FloorCount = apartment.FloorCount
        existing.Price = apartment.Price

        Return _repository.Update(existing)
    End Function

    ''' <summary>
    ''' Thêm căn hộ mới từ ApartmentCreateDto, trả về entity vừa tạo
    ''' </summary>
    Public Function Add(apartment As ApartmentCreateDto) As Apartment Implements IApartmentService.Add
        Dim entity As New Apartment With {
        .ApartmentTypeId = apartment.ApartmentTypeId,
        .Name = apartment.Name,
        .Address = apartment.Address,
        .FloorCount = apartment.FloorCount,
        .Price = apartment.Price,
        .CreatedDate = DateTime.Now ' Gán ngày tạo
    }

        Return _repository.Add(entity)
    End Function

    Public Sub Delete(id As Integer) Implements IApartmentService.Delete
        _repository.Delete(id)
    End Sub

    Public Function GetPagedList(keyword As String, typeId As Integer, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto) Implements IApartmentService.GetPagedList
        Return _repository.GetPagedListWithKeyword(keyword, typeId, pageIndex, pageSize)
    End Function

    Public Function GetTotalCount(keyword As String, typeId As Integer) As Integer Implements IApartmentService.GetTotalCount
        Return _repository.GetTotalCount(keyword, typeId)
    End Function

    Public Function GetAllByKeyword(keyword As String, typeId As Integer) As List(Of ApartmentDto) Implements IApartmentService.GetAllByKeyword
        Return _repository.GetAllByKeyword(keyword, typeId)
    End Function
End Class
