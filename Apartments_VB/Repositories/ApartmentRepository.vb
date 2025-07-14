Imports System.Configuration
Imports System.Data.Odbc
Imports System.Text

Public Class ApartmentRepository
    Implements IApartmentRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Function GetPagedListWithKeyword(keyword As String, pageIndex As Integer, pageSize As Integer) As List(Of ApartmentDto) Implements IApartmentRepository.GetPagedListWithKeyword
        Dim result As New List(Of ApartmentDto)
        Dim offset As Integer = (Math.Max(pageIndex, 1) - 1) * pageSize

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As New StringBuilder("SELECT a.Id, a.ApartmentName, a.Address, a.FloorCount, a.CreatedDate, a.Price, a.ApartmentTypeId, t.Name AS ApartmentTypeName FROM Apartment a JOIN ApartmentType t ON a.ApartmentTypeId = t.Id ")
            If Not String.IsNullOrEmpty(keyword) AndAlso keyword.Trim().Length > 0 Then
                query.Append("WHERE LOWER(a.ApartmentName) LIKE ? ")
            End If

            query.Append("ORDER BY a.Id DESC LIMIT ? OFFSET ?")

            Using cmd As New OdbcCommand(query.ToString(), conn)
                If Not String.IsNullOrEmpty(keyword) AndAlso keyword.Trim().Length > 0 Then
                    cmd.Parameters.AddWithValue("", "%" & keyword.ToLower() & "%")
                End If
                cmd.Parameters.AddWithValue("", pageSize)
                cmd.Parameters.AddWithValue("", offset)

                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        result.Add(MapDto(reader))
                    End While
                End Using
            End Using
        End Using

        Return result
    End Function

    Public Function GetTotalCount() As Integer Implements IApartmentRepository.GetTotalCount
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Using cmd As New OdbcCommand("SELECT COUNT(*) FROM Apartment", conn)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Function GetById(id As Integer) As Apartment Implements IApartmentRepository.GetById
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "SELECT * FROM Apartment WHERE Id = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("", id)

                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return MapEntity(reader)
                    End If
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function Add(apartment As Apartment) As Apartment Implements IApartmentRepository.Add
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            ' 1. INSERT
            Dim insertQuery As String = "INSERT INTO Apartment (ApartmentTypeId, ApartmentName, Address, FloorCount, CreatedDate, Price) VALUES (?, ?, ?, ?, ?, ?)"
            Using insertCmd As New OdbcCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("", apartment.ApartmentTypeId)
                insertCmd.Parameters.AddWithValue("", apartment.Name)
                insertCmd.Parameters.AddWithValue("", apartment.Address)
                insertCmd.Parameters.AddWithValue("", If(apartment.FloorCount.HasValue, apartment.FloorCount.Value, DBNull.Value))
                insertCmd.Parameters.AddWithValue("", apartment.CreatedDate)
                insertCmd.Parameters.AddWithValue("", apartment.Price)
                insertCmd.ExecuteNonQuery()
            End Using

            ' 2. SELECT LAST_INSERT_ID()
            Dim idQuery As String = "SELECT LAST_INSERT_ID()"
            Using idCmd As New OdbcCommand(idQuery, conn)
                Dim id = Convert.ToInt32(idCmd.ExecuteScalar())

                ' 3. Trả về bản ghi vừa thêm
                Return GetById(id)
            End Using
        End Using
    End Function



    Public Function Update(apartment As Apartment) As Apartment Implements IApartmentRepository.Update
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "UPDATE Apartment SET ApartmentTypeId = ?, ApartmentName = ?, Address = ?, FloorCount = ?, Price = ? WHERE Id = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("", apartment.ApartmentTypeId)
                cmd.Parameters.AddWithValue("", apartment.Name)
                cmd.Parameters.AddWithValue("", apartment.Address)
                cmd.Parameters.AddWithValue("", If(apartment.FloorCount.HasValue, apartment.FloorCount.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("", apartment.Price)
                cmd.Parameters.AddWithValue("", apartment.Id)

                ' Kiểm tra có dòng nào bị ảnh hưởng không
                Dim affectedRows = cmd.ExecuteNonQuery()
                If affectedRows = 0 Then
                    Throw New ArgumentException($"Không có trường nào được thay đổi!")
                End If

                ' Trả về bản ghi sau cập nhật
                Return GetById(apartment.Id)
            End Using
        End Using
    End Function



    Public Sub Delete(id As Integer) Implements IApartmentRepository.Delete
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "DELETE FROM Apartment WHERE Id = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' =====================
    ' MAPPING FUNCTIONS
    ' =====================
    Private Function MapDto(reader As OdbcDataReader) As ApartmentDto
        Dim dto As New ApartmentDto()

        dto.Id = SafeGetInt(reader, "Id")
        dto.Name = SafeGetString(reader, "ApartmentName")
        dto.Address = SafeGetString(reader, "Address")
        dto.FloorCount = SafeGetNullableInt(reader, "FloorCount")
        dto.CreatedDate = SafeGetDate(reader, "CreatedDate")
        dto.Price = SafeGetDecimal(reader, "Price")

        If HasColumn(reader, "ApartmentTypeName") Then
            dto.ApartmentTypeName = SafeGetString(reader, "ApartmentTypeName")
        End If

        Return dto
    End Function

    Private Function MapEntity(reader As OdbcDataReader) As Apartment
        Dim apartment As New Apartment()

        apartment.Id = SafeGetInt(reader, "Id")
        apartment.ApartmentTypeId = SafeGetInt(reader, "ApartmentTypeId")
        apartment.Name = SafeGetString(reader, "ApartmentName")
        apartment.Address = SafeGetString(reader, "Address")
        apartment.FloorCount = SafeGetNullableInt(reader, "FloorCount")
        apartment.CreatedDate = SafeGetDate(reader, "CreatedDate")
        apartment.Price = SafeGetDecimal(reader, "Price")

        Return apartment
    End Function

    Private Function HasColumn(reader As OdbcDataReader, columnName As String) As Boolean
        For i As Integer = 0 To reader.FieldCount - 1
            If reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function

    ' =====================
    ' HÀM HỖ TRỢ ĐỌC DỮ LIỆU AN TOÀN
    ' =====================

    ''' <summary>
    ''' Lấy kiểu Integer từ cột, nếu NULL thì trả về 0
    ''' </summary>
    Private Function SafeGetInt(reader As OdbcDataReader, column As String) As Integer
        Dim ordinal = reader.GetOrdinal(column)
        Return If(reader.IsDBNull(ordinal), 0, reader.GetInt32(ordinal))
    End Function

    ''' <summary>
    ''' Lấy kiểu Integer nullable, nếu NULL thì trả về Nothing
    ''' </summary>
    Private Function SafeGetNullableInt(reader As OdbcDataReader, column As String) As Integer?
        Dim ordinal = reader.GetOrdinal(column)
        Return If(reader.IsDBNull(ordinal), CType(Nothing, Integer?), reader.GetInt32(ordinal))
    End Function

    ''' <summary>
    ''' Lấy chuỗi từ cột, xử lý cả trường hợp có dấu và NULL an toàn
    ''' </summary>
    Private Function SafeGetString(reader As OdbcDataReader, column As String) As String
        Dim ordinal = reader.GetOrdinal(column)
        If reader.IsDBNull(ordinal) Then Return Nothing

        ' Dùng GetValue().ToString() thay vì GetString() để tránh lỗi ODBC với ký tự Unicode
        Return reader.GetValue(ordinal).ToString()
    End Function

    ''' <summary>
    ''' Lấy kiểu DateTime từ cột, nếu NULL thì trả về Date.MinValue
    ''' </summary>
    Private Function SafeGetDate(reader As OdbcDataReader, column As String) As DateTime
        Dim ordinal = reader.GetOrdinal(column)
        Return If(reader.IsDBNull(ordinal), Date.MinValue, reader.GetDateTime(ordinal))
    End Function

    ''' <summary>
    ''' Lấy kiểu Decimal từ cột, nếu NULL thì trả về 0
    ''' </summary>
    Private Function SafeGetDecimal(reader As OdbcDataReader, column As String) As Decimal
        Dim ordinal = reader.GetOrdinal(column)
        Return If(reader.IsDBNull(ordinal), 0D, reader.GetDecimal(ordinal))
    End Function


End Class
