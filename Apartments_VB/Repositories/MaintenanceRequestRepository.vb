Imports System.Configuration
Imports System.Data.Odbc
Imports System.Text

Public Class MaintenanceRequestRepository
    Implements IMaintenanceRequestRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Function GetPagedList(pageIndex As Integer, pageSize As Integer, status As Integer, apartmentId As Integer) As List(Of MaintenanceRequestDto) Implements IMaintenanceRequestRepository.GetPagedList
        Dim result As New List(Of MaintenanceRequestDto)
        Dim offset As Integer = (Math.Max(pageIndex, 1) - 1) * pageSize

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            ' Xây dựng query
            Dim query As New StringBuilder("SELECT mr.Id, a.ApartmentName, mr.RequestDate, mr.Description, mr.Status " &
                                       "FROM MaintenanceRequest mr " &
                                       "JOIN Apartment a ON mr.ApartmentId = a.Id " &
                                       "WHERE 1=1 ")

            If status <> -1 Then
                query.Append("AND mr.Status = " & status & " ")
            End If

            If apartmentId <> -1 Then
                query.Append("AND mr.ApartmentId = " & apartmentId & " ")
            End If

            query.Append("ORDER BY mr.RequestDate DESC ")
            query.Append("LIMIT " & pageSize & " OFFSET " & offset)

            Using cmd As New OdbcCommand(query.ToString(), conn)
                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        result.Add(New MaintenanceRequestDto With {
                        .Id = Convert.ToInt32(reader("Id")),
                        .ApartmentName = reader("ApartmentName").ToString(),
                        .RequestDate = Convert.ToDateTime(reader("RequestDate")),
                        .Description = reader("Description").ToString(),
                        .Status = reader("Status").ToString()
                    })
                    End While
                End Using
            End Using
        End Using

        Return result
    End Function




    Function CountByFilter(status As Integer, apartmentId As Integer) As Integer Implements IMaintenanceRequestRepository.CountByFilter
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim sql As New Text.StringBuilder("SELECT COUNT(*) FROM MaintenanceRequest WHERE 1=1 ")
            Dim cmd As New OdbcCommand()
            cmd.Connection = conn

            If status <> -1 Then
                sql.Append(" AND Status = ?")
                cmd.Parameters.AddWithValue("@Status", status)
            End If

            If apartmentId <> -1 Then
                sql.Append(" AND ApartmentId = ?")
                cmd.Parameters.AddWithValue("@ApartmentId", apartmentId)
            End If

            cmd.CommandText = sql.ToString()
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function




    Public Function GetById(id As Integer) As MaintenanceRequestDto Implements IMaintenanceRequestRepository.GetById
        Dim result As MaintenanceRequestDto = Nothing
        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim query As String = "" &
                "SELECT mr.Id, a.Name AS ApartmentName, mr.RequestDate, mr.Description, mr.Status " &
                "FROM MaintenanceRequest mr " &
                "JOIN Apartment a ON mr.ApartmentId = a.Id " &
                "WHERE mr.Id = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)
                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        result = New MaintenanceRequestDto With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .ApartmentName = reader("ApartmentName").ToString(),
                            .RequestDate = Convert.ToDateTime(reader("RequestDate")),
                            .Description = reader("Description").ToString(),
                            .Status = reader("Status").ToString()
                        }
                    End If
                End Using
            End Using
        End Using
        Return result
    End Function

    Public Function Add(request As MaintenanceRequest) As MaintenanceRequestDto Implements IMaintenanceRequestRepository.Add
        Dim insertedId As Integer = 0
        Dim result As MaintenanceRequestDto = Nothing

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()
            Dim insertQuery As String = "INSERT INTO MaintenanceRequest (ApartmentId, Description, RequestDate, Status) VALUES (?, ?, ?, 0)"
            Using cmd As New OdbcCommand(insertQuery, conn)
                cmd.Parameters.AddWithValue("@apartmentId", request.ApartmentId)
                cmd.Parameters.AddWithValue("@description", request.Description)
                cmd.Parameters.AddWithValue("@requestDate", DateTime.Now)
                cmd.ExecuteNonQuery()
            End Using

            ' Lấy bản ghi mới nhất theo thời gian và ApartmentId
            Dim selectQuery As String = "" &
                "SELECT mr.Id, a.ApartmentName, mr.RequestDate, mr.Description, mr.Status " &
                "FROM MaintenanceRequest mr " &
                "JOIN Apartment a ON mr.ApartmentId = a.Id " &
                "WHERE mr.ApartmentId = ? ORDER BY mr.RequestDate DESC LIMIT 1"

            Using cmd As New OdbcCommand(selectQuery, conn)
                cmd.Parameters.AddWithValue("@apartmentId", request.ApartmentId)
                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        result = New MaintenanceRequestDto With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .ApartmentName = reader("ApartmentName").ToString(),
                            .RequestDate = Convert.ToDateTime(reader("RequestDate")),
                            .Description = reader("Description").ToString(),
                            .Status = reader("Status").ToString()
                        }
                    End If
                End Using
            End Using
        End Using

        Return result
    End Function

    Public Function Update(request As MaintenanceRequest) As MaintenanceRequestDto Implements IMaintenanceRequestRepository.Update
        Dim result As MaintenanceRequestDto = Nothing

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            ' Cập nhật thông tin
            Dim updateQuery As String = "UPDATE MaintenanceRequest SET Description = ?, Status = ? WHERE Id = ?"
            Using cmd As New OdbcCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@description", request.Description)
                cmd.Parameters.AddWithValue("@status", request.Status)
                cmd.Parameters.AddWithValue("@id", request.Id)
                cmd.ExecuteNonQuery()
            End Using

            ' Truy vấn bản ghi vừa cập nhật kèm ApartmentName
            Dim selectQuery As String = "" &
                "SELECT mr.Id, a.Name AS ApartmentName, mr.RequestDate, mr.Description, mr.Status " &
                "FROM MaintenanceRequest mr " &
                "JOIN Apartment a ON mr.ApartmentId = a.Id " &
                "WHERE mr.Id = ?"

            Using cmd As New OdbcCommand(selectQuery, conn)
                cmd.Parameters.AddWithValue("@id", request.Id)
                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        result = New MaintenanceRequestDto With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .ApartmentName = reader("ApartmentName").ToString(),
                            .RequestDate = Convert.ToDateTime(reader("RequestDate")),
                            .Description = reader("Description").ToString(),
                            .Status = reader("Status").ToString()
                        }
                    End If
                End Using
            End Using
        End Using

        Return result
    End Function
End Class
