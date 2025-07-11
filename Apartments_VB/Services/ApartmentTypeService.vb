Public Class ApartmentTypeService
    Implements IApartmentTypeService

    Private ReadOnly _repository As IApartmentTypeRepository

    Public Sub New(repository As IApartmentTypeRepository)
        _repository = repository
    End Sub

    ''' <summary>
    ''' Gọi repository để lấy danh sách loại căn hộ
    ''' </summary>
    Public Function GetAll() As List(Of ApartmentTypeDto) Implements IApartmentTypeService.GetAll
        Return _repository.GetAll()
    End Function

End Class
