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

            Dim query As New StringBuilder("SELECT a.Id, a.ApartmentName, a.Address, a.FloorCount, a.CreatedDate, a.Price, a.ApartmentTypeId,
            t.Name AS ApartmentTypeName
            FROM Apartment a
            JOIN ApartmentType t ON a.ApartmentTypeId = t.Id ")
            If Not String.IsNullOrWhiteSpace(keyword) Then
                query.Append("WHERE LOWER(ApartmentName) LIKE ? ")
            End If
            query.Append("ORDER BY Id DESC LIMIT ? OFFSET ?")

            Using cmd As New OdbcCommand(query.ToString(), conn)
                If Not String.IsNullOrWhiteSpace(keyword) Then
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

    Public Sub Add(apartment As Apartment) Implements IApartmentRepository.Add
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "
                INSERT INTO Apartment (ApartmentTypeId, ApartmentName, Address, FloorCount, CreatedDate, Price)
                VALUES (?, ?, ?, ?, ?, ?)"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("", apartment.ApartmentTypeId)
                cmd.Parameters.AddWithValue("", apartment.Name)
                cmd.Parameters.AddWithValue("", apartment.Address)
                cmd.Parameters.AddWithValue("", If(apartment.FloorCount.HasValue, apartment.FloorCount.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("", apartment.CreatedDate)
                cmd.Parameters.AddWithValue("", apartment.Price)

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(apartment As Apartment) Implements IApartmentRepository.Update
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "
                UPDATE Apartment SET 
                    ApartmentTypeId = ?, 
                    ApartmentName = ?, 
                    Address = ?, 
                    FloorCount = ?, 
                    CreatedDate = ?, 
                    Price = ?
                WHERE Id = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("", apartment.ApartmentTypeId)
                cmd.Parameters.AddWithValue("", apartment.Name)
                cmd.Parameters.AddWithValue("", apartment.Address)
                cmd.Parameters.AddWithValue("", If(apartment.FloorCount.HasValue, apartment.FloorCount.Value, DBNull.Value))
                cmd.Parameters.AddWithValue("", apartment.CreatedDate)
                cmd.Parameters.AddWithValue("", apartment.Price)
                cmd.Parameters.AddWithValue("", apartment.Id)

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

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

    Private Function MapDto(reader As OdbcDataReader) As ApartmentDto
        Dim dto As New ApartmentDto()

        dto.Id = reader.GetInt32(reader.GetOrdinal("Id"))
        If HasColumn(reader, "ApartmentTypeName") AndAlso Not reader.IsDBNull(reader.GetOrdinal("ApartmentTypeName")) Then
            dto.ApartmentTypeName = reader("ApartmentTypeName").ToString()
        End If
        dto.Name = reader("ApartmentName").ToString()
        dto.Address = reader("Address").ToString()

        Dim floorOrdinal = reader.GetOrdinal("FloorCount")
        dto.FloorCount = If(reader.IsDBNull(floorOrdinal), CType(Nothing, Integer?), reader.GetInt32(floorOrdinal))

        dto.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
        dto.Price = reader.GetDecimal(reader.GetOrdinal("Price"))



        Return dto
    End Function

    Private Function MapEntity(reader As OdbcDataReader) As Apartment
        Dim apartment As New Apartment()

        apartment.Id = reader.GetInt32(reader.GetOrdinal("Id"))
        apartment.ApartmentTypeId = reader.GetInt32(reader.GetOrdinal("ApartmentTypeId"))
        apartment.Name = reader("ApartmentName").ToString()
        apartment.Address = reader("Address").ToString()

        Dim floorOrdinal = reader.GetOrdinal("FloorCount")
        apartment.FloorCount = If(reader.IsDBNull(floorOrdinal), CType(Nothing, Integer?), reader.GetInt32(floorOrdinal))

        apartment.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
        apartment.Price = reader.GetDecimal(reader.GetOrdinal("Price"))


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

End Class
