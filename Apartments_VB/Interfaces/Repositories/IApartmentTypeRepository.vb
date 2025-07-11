''' <summary>
''' Repository interface thao tác với bảng ApartmentType
''' </summary>
Public Interface IApartmentTypeRepository

    ''' <summary>
    ''' Lấy toàn bộ danh sách loại căn hộ
    ''' </summary>
    Function GetAll() As List(Of ApartmentTypeDto)

End Interface
