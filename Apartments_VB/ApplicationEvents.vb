Imports Microsoft.Extensions.DependencyInjection
Imports System.Configuration
Imports System.Data.Odbc
Imports System.Windows.Forms

Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' 1. Đọc chuỗi kết nối từ App.config
            Dim connStr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

            ' 2. Kiểm tra kết nối DB
            Try
                Using conn As New OdbcConnection(connStr)
                    conn.Open()
                    ' Nếu mở được thì OK, không làm gì
                    conn.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu." & vbCrLf & ex.Message,
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Thoát ứng dụng luôn nếu không kết nối được
                End
            End Try

            ' 3. Tạo DI container
            Dim services As New ServiceCollection()
            services.AddScoped(Of IUserRepository, UserRepository)()
            services.AddScoped(Of IUserService, UserService)()
            services.AddScoped(Of IApartmentRepository, ApartmentRepository)()
            services.AddScoped(Of IApartmentService, ApartmentService)()

            services.AddScoped(Of LoginForm)()

            ' 4. Build provider
            Dim provider As IServiceProvider = services.BuildServiceProvider()

            ' 5. Gán form khởi động
            Me.MainForm = provider.GetService(Of LoginForm)()
        End Sub

    End Class
End Namespace
