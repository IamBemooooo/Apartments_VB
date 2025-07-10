Imports System.Data.Odbc
Imports System.Configuration

Public Class UserRepository
    Implements IUserRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        ' Lấy connection string từ App.config
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Function Login(username As String, password As String) As User Implements IUserRepository.Login
        Dim user As User = Nothing

        Try
            Using conn As New OdbcConnection(_connectionString)
                conn.Open()

                ' Dùng dấu ? cho ODBC, không có tên tham số
                Dim query As String = SqlQueries.User.LoginQuery

                Using cmd As New OdbcCommand(query, conn)
                    ' Thêm tham số theo thứ tự
                    cmd.Parameters.AddWithValue("Username", username)
                    cmd.Parameters.AddWithValue("PasswordHash", password)

                    Using reader As OdbcDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            user = New User With {
                                .Id = Convert.ToInt32(reader("Id")),
                                .Username = reader("Username").ToString(),
                                .PasswordHash = reader("PasswordHash").ToString(),
                                .FullName = reader("FullName").ToString(),
                                .IsActive = Convert.ToBoolean(reader("IsActive")),
                                .RoleId = Convert.ToInt32(reader("RoleId"))
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Bạn có thể log lỗi hoặc rethrow
            Throw New ApplicationException("Lỗi khi đăng nhập: " & ex.Message)
        End Try

        Return user
    End Function
End Class
