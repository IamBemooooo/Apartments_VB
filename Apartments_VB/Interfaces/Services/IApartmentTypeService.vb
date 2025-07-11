''' <summary>
''' Service xử lý nghiệp vụ liên quan đến ApartmentType
''' </summary>
Public Interface IApartmentTypeService

    ''' <summary>
    ''' Lấy toàn bộ danh sách loại căn hộ
    ''' </summary>
    Function GetAll() As List(Of ApartmentTypeDto)

End Interface
