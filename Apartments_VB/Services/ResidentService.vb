Public Class ResidentService
    Implements IResidentService

    Private ReadOnly _repository As IResidentRepository

    Public Sub New(repository As IResidentRepository)
        _repository = repository
    End Sub

    Public Function Add(dto As ResidentCreateDto) As Resident Implements IResidentService.Add
        Dim existing = _repository.GetByPhone(dto.Phone)

        If existing IsNot Nothing Then
            If existing.IsActive Then
                Throw New Exception("Số điện thoại đã được đăng ký.")
            Else
                If existing.FullName.Trim().ToLower() = dto.FullName.Trim().ToLower() Then
                    ' Khôi phục và cập nhật lại
                    existing.Email = dto.Email
                    existing.DateOfBirth = dto.DateOfBirth
                    existing.Gender = dto.Gender
                    existing.IsActive = True

                    Return _repository.RestoreAndUpdate(existing)
                Else
                    Throw New Exception("Số điện thoại đã được đăng ký.")
                End If
            End If
        End If

        ' Nếu chưa tồn tại
        Dim entity As New Resident With {
        .FullName = dto.FullName,
        .Phone = dto.Phone,
        .Email = dto.Email,
        .DateOfBirth = dto.DateOfBirth,
        .Gender = dto.Gender,
        .IsActive = True
        }

        Return _repository.Add(entity)
    End Function


    Public Function Update(dto As ResidentUpdateDto) As Resident Implements IResidentService.Update
        Dim existing = _repository.GetById(dto.Id)
        If existing Is Nothing Then
            Throw New Exception("Không tìm thấy resident với ID = " & dto.Id)
        End If
        Dim existingByPhone = _repository.ExistsPhone(dto.Phone, dto.Id)
        If existingByPhone Then
            Throw New Exception("Số điện thoại đã được đăng ký.")
        End If

        existing.FullName = dto.FullName
        existing.Phone = dto.Phone
        existing.Email = dto.Email
        existing.DateOfBirth = dto.DateOfBirth
        existing.Gender = dto.Gender

        Return _repository.Update(existing)
    End Function

    Public Function Delete(id As Integer) As Resident Implements IResidentService.Delete
        Return _repository.Delete(id)
    End Function

    Public Function GetPagedList(keyword As String, Optional isStaying As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of Resident) Implements IResidentService.GetPagedList
        Return _repository.GetPagedList(keyword, isStaying, pageIndex, pageSize)
    End Function

    Public Function GetTotalCount(keyword As String, Optional isStaying As Boolean? = Nothing) As Integer Implements IResidentService.GetTotalCount
        Return _repository.GetTotalCount(keyword, isStaying)
    End Function

    Public Function GetById(id As Integer) As Resident Implements IResidentService.GetById
        Return _repository.GetById(id)
    End Function
End Class
