Public Class ResidentStayHistoryForm
    Private ReadOnly _apartmentId As Integer
    Private ReadOnly _apartmentResidentService As IApartmentResidentService
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0
    Private residentData As List(Of ResidentStayHistoryDto)

    Public Sub New(apartmentId As Integer, apartmentResidentService As IApartmentResidentService)
        InitializeComponent()
        _apartmentId = apartmentId
        _apartmentResidentService = apartmentResidentService
    End Sub

    Private Sub ResidentStayHistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Khởi tạo lựa chọn trạng thái
        cbxStatus.Items.Clear()
        cbxStatus.Items.Add("Tất cả")   ' index 0 → endDateNullOnly = Nothing
        cbxStatus.Items.Add("Đang ở")   ' index 1 → endDateNullOnly = True
        cbxStatus.Items.Add("Đã rời")   ' index 2 → endDateNullOnly = False
        cbxStatus.SelectedIndex = 0

        ' Sau đó mới load dữ liệu
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            ' Xác định trạng thái lọc
            Dim endDateNullOnly As Nullable(Of Boolean) = Nothing
            If cbxStatus.SelectedIndex = 1 Then
                endDateNullOnly = True ' Đang ở
            ElseIf cbxStatus.SelectedIndex = 2 Then
                endDateNullOnly = False ' Đã rời
            End If

            ' Lấy dữ liệu và tổng số
            residentData = _apartmentResidentService.GetResidentStayHistoryByApartmentId(_apartmentId, endDateNullOnly, pageIndex, pageSize)
            totalCount = _apartmentResidentService.CountResidentStayHistoryByApartmentId(_apartmentId, endDateNullOnly)

            ' Nếu không có dữ liệu, hiển thị thông báo
            If residentData Is Nothing OrElse residentData.Count = 0 Then
                dgvResidentStayHistory.DataSource = Nothing
                lblPaging.Text = "Không có dữ liệu"
                btnPrev.Enabled = False
                btnNext.Enabled = False
                Return
            End If

            ' Biến đổi dữ liệu sang custom object
            Dim customList = residentData.Select(Function(r, i) New With {
            Key .STT = (pageIndex - 1) * pageSize + i + 1,
            Key .Họ_Tên = r.FullName,
            Key .SĐT = r.Phone,
            Key .Email = r.Email,
            Key .Ngày_Sinh = If(r.DateOfBirth.HasValue, r.DateOfBirth.Value.ToString("dd/MM/yyyy"), "Không rõ"),
            Key .Giới_Tính = If(r.Gender = 0, "Nữ", "Nam"),
            Key .Bắt_Đầu = r.StartDate.ToString("dd/MM/yyyy"),
            Key .Kết_Thúc = If(r.EndDate.HasValue, r.EndDate.Value.ToString("dd/MM/yyyy"), "Đang ở")
        }).ToList()

            ' Cập nhật DataGridView
            dgvResidentStayHistory.AutoGenerateColumns = True
            dgvResidentStayHistory.DataSource = customList

            ' Cập nhật label và nút
            lblPaging.Text = $"Hiển thị {residentData.Count} / Tổng {totalCount} bản ghi"
            btnPrev.Enabled = pageIndex > 1
            btnNext.Enabled = (pageIndex * pageSize) < totalCount

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải dữ liệu: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If pageIndex > 1 Then
            pageIndex -= 1
            LoadData()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If (pageIndex * pageSize) < totalCount Then
            pageIndex += 1
            LoadData()
        End If
    End Sub

    Private Sub cbxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStatus.SelectedIndexChanged
        pageIndex = 1 ' reset về trang đầu khi lọc
        LoadData()
    End Sub
End Class