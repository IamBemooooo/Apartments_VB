Imports System.Data.Odbc
Imports System.Configuration

Public Class UserRepository
    Implements IUserRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        ' Lấy connection string từ App.config
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Function Login(username As String, password As String) As CurrentUserDto Implements IUserRepository.Login
        Dim user As CurrentUserDto = Nothing

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "
            SELECT Id, FullName, RoleId 
            FROM User 
            WHERE Username = ? AND PasswordHash = ? AND IsActive = 1"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("Username", username)
                cmd.Parameters.AddWithValue("PasswordHash", password)

                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        user = New CurrentUserDto With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .FullName = reader("FullName").ToString(),
                            .RoleId = Convert.ToInt32(reader("RoleId"))
                        }
                    End If
                End Using
            End Using
        End Using

        Return user
    End Function

End Class
