Imports System.Configuration
Imports System.Data.Odbc

Public Class ApartmentResidentRepository
    Implements IApartmentResidentRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Function GetResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of ResidentStayHistoryDto) Implements IApartmentResidentRepository.GetResidentStayHistoryByApartmentId
        Dim result As New List(Of ResidentStayHistoryDto)
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As String = "
            SELECT r.Id, r.FullName, r.Phone, r.Email, r.DateOfBirth, r.Gender, ar.StartDate, ar.EndDate
            FROM ApartmentResident ar 
            JOIN Resident r ON ar.ResidentId = r.Id 
            WHERE ar.ApartmentId = ?"
            If endDateNullOnly.HasValue Then
                sql &= If(endDateNullOnly.Value, " AND ar.EndDate IS NULL", " AND ar.EndDate IS NOT NULL")
            End If
            sql &= " ORDER BY ar.StartDate LIMIT ? OFFSET ?"

            Dim cmd As New OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ApartmentId", apartmentId)
            cmd.Parameters.AddWithValue("@Limit", pageSize)
            cmd.Parameters.AddWithValue("@Offset", (pageIndex - 1) * pageSize)

            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    result.Add(New ResidentStayHistoryDto With {
                    .Id = Convert.ToInt32(reader("Id")),
                    .FullName = reader("FullName").ToString(),
                    .Phone = reader("Phone").ToString(),
                    .Email = reader("Email").ToString(),
                    .DateOfBirth = If(IsDBNull(reader("DateOfBirth")), Nothing, CType(reader("DateOfBirth"), DateTime?)),
                    .Gender = Convert.ToInt32(reader("Gender")),
                    .StartDate = Convert.ToDateTime(reader("StartDate")),
                    .EndDate = If(IsDBNull(reader("EndDate")), Nothing, CType(reader("EndDate"), DateTime?))
                })
                End While
            End Using
        End Using
        Return result
    End Function

    Public Function GetApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing, Optional pageIndex As Integer = 1, Optional pageSize As Integer = 10) As List(Of ApartmentStayHistoryDto) Implements IApartmentResidentRepository.GetApartmentStayHistoryByResidentId
        Dim result As New List(Of ApartmentStayHistoryDto)
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As String = "
            SELECT a.Id, a.Name, a.Address, a.FloorCount, at.TypeName AS ApartmentTypeName, ar.StartDate, ar.EndDate
            FROM ApartmentResident ar
            JOIN Apartment a ON ar.ApartmentId = a.Id
            JOIN ApartmentType at ON a.ApartmentTypeId = at.Id
            WHERE ar.ResidentId = ?"
            If endDateNullOnly.HasValue Then
                sql &= If(endDateNullOnly.Value, " AND ar.EndDate IS NULL", " AND ar.EndDate IS NOT NULL")
            End If
            sql &= " ORDER BY ar.StartDate LIMIT ? OFFSET ?"

            Dim cmd As New OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ResidentId", residentId)
            cmd.Parameters.AddWithValue("@Limit", pageSize)
            cmd.Parameters.AddWithValue("@Offset", (pageIndex - 1) * pageSize)

            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    result.Add(New ApartmentStayHistoryDto With {
                    .Id = Convert.ToInt32(reader("Id")),
                    .Name = reader("Name").ToString(),
                    .Address = reader("Address").ToString(),
                    .FloorCount = If(IsDBNull(reader("FloorCount")), Nothing, CType(reader("FloorCount"), Integer?)),
                    .ApartmentTypeName = reader("ApartmentTypeName").ToString(),
                    .StartDate = Convert.ToDateTime(reader("StartDate")),
                    .EndDate = If(IsDBNull(reader("EndDate")), Nothing, CType(reader("EndDate"), DateTime?))
                })
                End While
            End Using
        End Using
        Return result
    End Function


    Public Function AssignResidentToApartment(entity As ApartmentResident) As AssignResidentResultDto Implements IApartmentResidentRepository.AssignResidentToApartment
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            ' Nếu đang ở phòng khác → cập nhật ngày rời đi
            Dim oldIdCmd As New OdbcCommand("
            SELECT Id 
            FROM ApartmentResident 
            WHERE ResidentId = ? AND EndDate IS NULL", conn)
            oldIdCmd.Parameters.AddWithValue("@ResidentId", entity.ResidentId)
            Dim oldId = oldIdCmd.ExecuteScalar()

            If oldId IsNot Nothing AndAlso Not DBNull.Value.Equals(oldId) Then
                Dim updateCmd As New OdbcCommand("
                UPDATE ApartmentResident 
                SET EndDate = ? 
                WHERE Id = ?", conn)
                updateCmd.Parameters.AddWithValue("@EndDate", entity.StartDate)
                updateCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(oldId))
                updateCmd.ExecuteNonQuery()
            End If

            ' Insert bản ghi mới
            Dim insertCmd As New OdbcCommand("
            INSERT INTO ApartmentResident (ResidentId, ApartmentId, StartDate, EndDate, Note)
            VALUES (?, ?, ?, NULL, ?)", conn)
            insertCmd.Parameters.AddWithValue("@ResidentId", entity.ResidentId)
            insertCmd.Parameters.AddWithValue("@ApartmentId", entity.ApartmentId)
            insertCmd.Parameters.AddWithValue("@StartDate", entity.StartDate)
            insertCmd.Parameters.AddWithValue("@Note", If(entity.Note, String.Empty))
            insertCmd.ExecuteNonQuery()

            ' Trả về kết quả chi tiết
            Return GetAssignResultDto(conn, entity)
        End Using
    End Function



    Private Function GetAssignResultDto(conn As OdbcConnection, entity As ApartmentResident) As AssignResidentResultDto
        Dim cmd As New OdbcCommand("
        SELECT TOP 1 a.Name AS ApartmentName, a.Address,
                     r.FullName, r.DateOfBirth, r.Gender, r.Phone, r.Email,
                     ar.StartDate
        FROM ApartmentResident ar
        JOIN Apartment a ON ar.ApartmentId = a.Id
        JOIN Resident r ON ar.ResidentId = r.Id
        WHERE ar.ApartmentId = ? AND ar.ResidentId = ?
        ORDER BY ar.StartDate DESC", conn)
        cmd.Parameters.AddWithValue("@ApartmentId", entity.ApartmentId)
        cmd.Parameters.AddWithValue("@ResidentId", entity.ResidentId)

        Using reader As OdbcDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim age As Integer? = Nothing
                If Not IsDBNull(reader("DateOfBirth")) Then
                    Dim birthDate As DateTime = Convert.ToDateTime(reader("DateOfBirth"))
                    age = DateTime.Now.Year - birthDate.Year
                    If birthDate > DateTime.Now.AddYears(-age.Value) Then age -= 1
                End If

                Return New AssignResidentResultDto With {
                .ApartmentName = reader("ApartmentName").ToString(),
                .ApartmentAddress = reader("Address").ToString(),
                .ResidentFullName = reader("FullName").ToString(),
                .ResidentAge = age,
                .ResidentGender = Convert.ToInt32(reader("Gender")),
                .ResidentPhone = reader("Phone").ToString(),
                .ResidentEmail = reader("Email").ToString(),
                .StartDate = Convert.ToDateTime(reader("StartDate"))
            }
            End If
        End Using

        Throw New Exception("Không thể truy xuất thông tin vừa gán.")
    End Function



    Public Function IsResidentCurrentlyInApartment(residentId As Integer, apartmentId As Integer) As Boolean Implements IApartmentResidentRepository.IsResidentCurrentlyInApartment
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim cmd As New OdbcCommand("SELECT COUNT(*) FROM ApartmentResident WHERE ResidentId = ? AND ApartmentId = ? AND EndDate IS NULL", conn)
            cmd.Parameters.AddWithValue("@ResidentId", residentId)
            cmd.Parameters.AddWithValue("@ApartmentId", apartmentId)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Public Function GetCurrentApartmentByResidentId(residentId As Integer) As ApartmentDto Implements IApartmentResidentRepository.GetCurrentApartmentByResidentId
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim cmd As New OdbcCommand("SELECT a.Id, a.Name, a.Address, a.FloorCount, a.ApartmentTypeId FROM Apartment a JOIN ApartmentResident ar ON ar.ApartmentId = a.Id WHERE ar.ResidentId = ? AND ar.EndDate IS NULL", conn)
            cmd.Parameters.AddWithValue("@ResidentId", residentId)
            Using reader As OdbcDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return New ApartmentDto With {
                        .Id = Convert.ToInt32(reader("Id")),
                        .Name = reader("Name").ToString(),
                        .Address = reader("Address").ToString(),
                        .FloorCount = If(IsDBNull(reader("FloorCount")), Nothing, CType(reader("FloorCount"), Integer?)),
                        .ApartmentTypeName = Convert.ToInt32(reader("ApartmentTypeName"))
                    }
                End If
            End Using
        End Using
        Return Nothing
    End Function

    Public Sub MarkResidentAsMovedOut(residentId As Integer, moveOutDate As DateTime) Implements IApartmentResidentRepository.MarkResidentAsMovedOut
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim cmd As New OdbcCommand("UPDATE ApartmentResident SET EndDate = ? WHERE ResidentId = ? AND EndDate IS NULL", conn)
            cmd.Parameters.AddWithValue("@EndDate", moveOutDate)
            cmd.Parameters.AddWithValue("@ResidentId", residentId)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function CountResidentStayHistoryByApartmentId(apartmentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer Implements IApartmentResidentRepository.CountResidentStayHistoryByApartmentId
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As String = "SELECT COUNT(*) FROM ApartmentResident WHERE ApartmentId = ?"
            If endDateNullOnly.HasValue Then
                sql &= If(endDateNullOnly.Value, " AND EndDate IS NULL", " AND EndDate IS NOT NULL")
            End If

            Dim cmd As New OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ApartmentId", apartmentId)

            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function


    Public Function CountApartmentStayHistoryByResidentId(residentId As Integer, Optional endDateNullOnly As Boolean? = Nothing) As Integer Implements IApartmentResidentRepository.CountApartmentStayHistoryByResidentId
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As String = "SELECT COUNT(*) FROM ApartmentResident WHERE ResidentId = ?"
            If endDateNullOnly.HasValue Then
                sql &= If(endDateNullOnly.Value, " AND EndDate IS NULL", " AND EndDate IS NOT NULL")
            End If

            Dim cmd As New OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ResidentId", residentId)

            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

End Class
