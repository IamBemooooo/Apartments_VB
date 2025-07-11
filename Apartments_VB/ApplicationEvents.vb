Imports System.Configuration
Imports System.Data.Odbc

Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' 1. Đọc chuỗi kết nối
            Dim connSetting = ConfigurationManager.ConnectionStrings("DefaultConnection")

            If connSetting Is Nothing Then
                MessageBox.Show("Không tìm thấy 'DefaultConnection' trong App.config!", "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If

            Dim connStr As String = connSetting.ConnectionString


            Try
                Using conn As New OdbcConnection(connStr)
                    conn.Open()
                    conn.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu." & vbCrLf & ex.Message,
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End Try

            ' 2. Tạo và gán service
            Dim userRepo As New UserRepository()
            Dim userService As New UserService(userRepo)

            Dim apartmentRepo As New ApartmentRepository()
            Dim apartmentService As New ApartmentService(apartmentRepo)

            Dim typeRepo As New ApartmentTypeRepository()
            Dim typeService As New ApartmentTypeService(typeRepo)

            ServiceProviderLocator.UserService = userService
            ServiceProviderLocator.ApartmentService = apartmentService
            ServiceProviderLocator.ApartmentTypeService = typeService

            ' 3. Gán form khởi động
            Me.MainForm = New LoginForm(userService)
        End Sub

    End Class
End Namespace
