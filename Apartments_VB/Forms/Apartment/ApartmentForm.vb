Public Class ApartmentForm

    Private ReadOnly _apartmentService As IApartmentService
    Private ReadOnly _currentUser As CurrentUserDto
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(apartmentService As IApartmentService, currentUser As CurrentUserDto)
        InitializeComponent()
        _apartmentService = apartmentService
        _currentUser = currentUser
    End Sub

    Private Sub ApartmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        If _currentUser.RoleId <> UserRole.Admin Then
            btnDelete.Visible = False
            btnUpdate.Visible = False
        End If
    End Sub

    Private Sub LoadData()
        Try
            Dim keyword = txtSearch.Text.Trim()
            Dim list = _apartmentService.GetPagedList(keyword, pageIndex, pageSize)
            totalCount = _apartmentService.GetTotalCount()

            dgvApartments.DataSource = list

            ' Cập nhật label phân trang
            Dim startRecord = ((pageIndex - 1) * pageSize) + 1
            Dim endRecord = Math.Min(startRecord + pageSize - 1, totalCount)
            lblPagingInfo.Text = $"Hiển thị {startRecord}-{endRecord} / Tổng {totalCount} bản ghi"

            ' Cập nhật trạng thái nút
            btnPrev.Enabled = pageIndex > 1
            btnNext.Enabled = (pageIndex * pageSize) < totalCount

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        pageIndex = 1 ' reset về trang đầu khi tìm kiếm
        LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Lấy service trực tiếp từ ServiceProvider
        Dim apartmentTypeService = ServiceProviderLocator.ApartmentTypeService
        Dim addForm As New ApartmentCreateForm(_apartmentService, apartmentTypeService)

        ' Hiển thị form thêm mới dạng modal
        addForm.ShowDialog()

        ' Reload lại danh sách
        LoadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Kiểm tra xem người dùng đã chọn dòng nào chưa
        If dgvApartments.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một căn hộ để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Lấy ID từ dòng được chọn (giả sử cột đầu tiên là ID)
        Dim selectedRow As DataGridViewRow = dgvApartments.SelectedRows(0)
        Dim apartmentId As Integer = Convert.ToInt32(selectedRow.Cells("Id").Value)

        ' Lấy service
        Dim apartmentTypeService = ServiceProviderLocator.ApartmentTypeService

        ' Truyền apartmentId vào form cập nhật

        Dim updateForm As New ApartmentUpdateForm(apartmentId, _apartmentService, apartmentTypeService)
        ' Hiển thị form cập nhật dạng modal
        updateForm.ShowDialog()

        ' Reload lại danh sách
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Kiểm tra xem có dòng nào được chọn không
        If dgvApartments.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một căn hộ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Lấy ID của căn hộ được chọn (giả sử cột tên "Id")
        Dim selectedRow As DataGridViewRow = dgvApartments.SelectedRows(0)
        Dim apartmentId As Integer = Convert.ToInt32(selectedRow.Cells("Id").Value)

        ' Hiển thị hộp thoại xác nhận
        Dim confirmResult As DialogResult = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa căn hộ này?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If confirmResult = DialogResult.Yes Then
            Try
                ' Gọi service để xóa
                _apartmentService.Delete(apartmentId)

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Reload danh sách
                LoadData()
            Catch ex As Exception
                MessageBox.Show("Xóa thất bại: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class
