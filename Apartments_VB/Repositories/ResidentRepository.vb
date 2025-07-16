Imports System.Configuration
Imports System.Data.Odbc

Public Class ResidentRepository
    Implements IResidentRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Function Add(resident As Resident) As Resident Implements IResidentRepository.Add
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            ' 1. Thêm bản ghi
            Dim insertSql As String = "
            INSERT INTO Resident (FullName, Phone, Email, DateOfBirth, Gender, IsActive, CreatedDate)
            VALUES (?, ?, ?, ?, ?, 1, CURRENT_TIMESTAMP);"

            Using insertCmd As New OdbcCommand(insertSql, conn)
                insertCmd.Parameters.AddWithValue("@FullName", resident.FullName)
                insertCmd.Parameters.AddWithValue("@Phone", resident.Phone)
                insertCmd.Parameters.AddWithValue("@Email", resident.Email)
                insertCmd.Parameters.AddWithValue("@DateOfBirth", If(resident.DateOfBirth.HasValue, resident.DateOfBirth.Value, DBNull.Value))

                ' 👇 Cách sửa đúng cho Gender
                Dim genderParam As New OdbcParameter("@Gender", OdbcType.Bit)
                genderParam.Value = If(resident.Gender, 1, 0)
                insertCmd.Parameters.Add(genderParam)

                insertCmd.ExecuteNonQuery()
            End Using


            ' 2. Lấy Id mới
            Dim idCmd As New OdbcCommand("SELECT LAST_INSERT_ID();", conn)
            resident.Id = Convert.ToInt32(idCmd.ExecuteScalar())
        End Using

        Return resident
    End Function

    Public Function Update(resident As Resident) As Resident Implements IResidentRepository.Update
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim sql As String = "
                UPDATE Resident SET 
                    FullName = ?, 
                    Phone = ?, 
                    Email = ?, 
                    DateOfBirth = ?, 
                    Gender = ?
                WHERE Id = ? AND IsActive = 1"

            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FullName", resident.FullName)
                cmd.Parameters.AddWithValue("@Phone", resident.Phone)
                cmd.Parameters.AddWithValue("@Email", resident.Email)
                cmd.Parameters.AddWithValue("@DateOfBirth", If(resident.DateOfBirth.HasValue, resident.DateOfBirth.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("@Gender", resident.Gender)
                cmd.Parameters.AddWithValue("@Id", resident.Id)

                cmd.ExecuteNonQuery()
            End Using
        End Using

        Return resident
    End Function

    Public Function Delete(id As Integer) As Resident Implements IResidentRepository.Delete
        Dim existing = GetById(id)
        If existing Is Nothing Then Return Nothing

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim sql As String = "UPDATE Resident SET IsActive = 0 WHERE Id = ?"

            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        existing.IsActive = False
        Return existing
    End Function

    Public Function GetById(id As Integer) As Resident Implements IResidentRepository.GetById
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim sql As String = "SELECT * FROM Resident WHERE Id = ? AND IsActive = 1"

            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Id", id)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return MapResident(reader)
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Public Function GetPagedList(keyword As String, Optional isStaying As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of Resident) Implements IResidentRepository.GetPagedList
        Dim result As New List(Of Resident)
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As String = "
                SELECT r.*
                FROM Resident r
                WHERE r.IsActive = 1
                    AND (r.FullName LIKE ? OR r.Phone LIKE ? OR r.Email LIKE ?)"
            If isStaying.HasValue Then
                sql &= If(isStaying.Value,
                    " AND EXISTS (SELECT 1 FROM ApartmentResident ar WHERE ar.ResidentId = r.Id AND ar.EndDate IS NULL)",
                    " AND NOT EXISTS (SELECT 1 FROM ApartmentResident ar WHERE ar.ResidentId = r.Id AND ar.EndDate IS NULL)")
            End If
            sql &= " ORDER BY r.CreatedDate DESC LIMIT ? OFFSET ?"

            Using cmd As New OdbcCommand(sql, conn)
                Dim kw = "%" & keyword & "%"
                cmd.Parameters.AddWithValue("@kw1", kw)
                cmd.Parameters.AddWithValue("@kw2", kw)
                cmd.Parameters.AddWithValue("@kw3", kw)
                cmd.Parameters.AddWithValue("@limit", pageSize)
                cmd.Parameters.AddWithValue("@offset", (pageIndex - 1) * pageSize)

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        result.Add(MapResident(reader))
                    End While
                End Using
            End Using
        End Using
        Return result
    End Function

    Public Function GetTotalCount(keyword As String, Optional isStaying As Boolean? = Nothing) As Integer Implements IResidentRepository.GetTotalCount
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim sql As String = "
                SELECT COUNT(*)
                FROM Resident r
                WHERE r.IsActive = 1
                    AND (r.FullName LIKE ? OR r.Phone LIKE ? OR r.Email LIKE ?)"
            If isStaying.HasValue Then
                sql &= If(isStaying.Value,
                    " AND EXISTS (SELECT 1 FROM ApartmentResident ar WHERE ar.ResidentId = r.Id AND ar.EndDate IS NULL)",
                    " AND NOT EXISTS (SELECT 1 FROM ApartmentResident ar WHERE ar.ResidentId = r.Id AND ar.EndDate IS NULL)")
            End If

            Using cmd As New OdbcCommand(sql, conn)
                Dim kw = "%" & keyword & "%"
                cmd.Parameters.AddWithValue("@kw1", kw)
                cmd.Parameters.AddWithValue("@kw2", kw)
                cmd.Parameters.AddWithValue("@kw3", kw)

                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Private Function MapResident(reader As OdbcDataReader) As Resident
        Return New Resident With {
            .Id = Convert.ToInt32(reader("Id")),
            .FullName = reader("FullName").ToString(),
            .Phone = reader("Phone").ToString(),
            .Email = reader("Email").ToString(),
            .DateOfBirth = If(IsDBNull(reader("DateOfBirth")), Nothing, CType(reader("DateOfBirth"), DateTime?)),
            .Gender = Convert.ToInt32(reader("Gender")),
            .IsActive = Convert.ToBoolean(reader("IsActive")),
            .CreatedDate = Convert.ToDateTime(reader("CreatedDate"))
        }
    End Function

    ''' <summary>
    ''' Truy vấn resident theo số điện thoại.
    ''' </summary>
    ''' <param name="phone">Số điện thoại cần tìm</param>
    ''' <returns>Đối tượng Resident nếu tìm thấy; ngược lại trả về Nothing</returns>
    Public Function GetByPhone(phone As String) As Resident Implements IResidentRepository.GetByPhone
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim cmd As New OdbcCommand("SELECT * FROM Resident WHERE Phone = ? LIMIT 1", conn)
            cmd.Parameters.AddWithValue("@Phone", phone)

            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return New Resident With {
                    .Id = Convert.ToInt32(reader("Id")),
                    .FullName = reader("FullName").ToString(),
                    .Phone = reader("Phone").ToString(),
                    .Email = reader("Email").ToString(),
                    .DateOfBirth = If(IsDBNull(reader("DateOfBirth")), Nothing, CType(reader("DateOfBirth"), DateTime?)),
                    .Gender = Convert.ToBoolean(reader("Gender")),
                    .IsActive = Convert.ToBoolean(reader("IsActive"))
                }
                End If
            End Using
        End Using

        Return Nothing
    End Function

    ''' <summary>
    ''' Khôi phục trạng thái IsActive = True và cập nhật thông tin resident.
    ''' </summary>
    ''' <param name="resident">Đối tượng resident cần khôi phục</param>
    ''' <returns>Resident sau khi được cập nhật lại</returns>
    Public Function RestoreAndUpdate(resident As Resident) As Resident Implements IResidentRepository.RestoreAndUpdate
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As String = "
            UPDATE Resident
            SET FullName = ?, Email = ?, DateOfBirth = ?, Gender = ?, IsActive = 1
            WHERE Id = ?"

            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("@FullName", resident.FullName)
                cmd.Parameters.AddWithValue("@Email", resident.Email)
                cmd.Parameters.AddWithValue("@DateOfBirth", If(resident.DateOfBirth.HasValue, resident.DateOfBirth.Value, DBNull.Value))

                ' Gender là kiểu Bit
                Dim genderParam As New OdbcParameter("@Gender", OdbcType.Bit)
                genderParam.Value = If(resident.Gender, 1, 0)
                cmd.Parameters.Add(genderParam)

                cmd.Parameters.AddWithValue("@Id", resident.Id)

                cmd.ExecuteNonQuery()
            End Using
        End Using

        resident.IsActive = True
        Return resident
    End Function


End Class
