Imports ClosedXML.Excel
Imports System.IO

Public Class ResidentControl
    Private ReadOnly _residentService As IResidentService
    Private ReadOnly _onDetailRequested As Action(Of Integer)
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(residentService As IResidentService, onDetailRequested As Action(Of Integer))
        InitializeComponent()
        _residentService = residentService
        _onDetailRequested = onDetailRequested
    End Sub

    Private Sub ResidentControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Khởi tạo lựa chọn trạng thái
        cbxStatus.Items.Clear()
        cbxStatus.Items.Add("Tất cả trạng thái")   ' index 0 → endDateNullOnly = Nothing
        cbxStatus.Items.Add("Đang ở")   ' index 1 → endDateNullOnly = True
        cbxStatus.Items.Add("Đã rời")   ' index 2 → endDateNullOnly = False
        cbxStatus.SelectedIndex = 0
        ' Sau đó mới load dữ liệu
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim keyword = txtSearch.Text.Trim()
            Dim isStaying As Boolean? = Nothing

            If cbxStatus.SelectedIndex = 1 Then
                isStaying = True
            ElseIf cbxStatus.SelectedIndex = 2 Then
                isStaying = False
            End If

            Dim list = _residentService.GetPagedList(keyword, isStaying, pageIndex, pageSize)
            totalCount = _residentService.GetTotalCount(keyword, isStaying)

            Dim customList = list.Select(Function(r, index) New With {
                r.Id,
                Key .HọTên = r.FullName,
                Key .SĐT = r.Phone,
                Key .Email = r.Email,
                Key .NgàySinh = If(r.DateOfBirth.HasValue, r.DateOfBirth.Value.ToString("dd/MM/yyyy"), "Không rõ"),
                Key .GiớiTính = If(r.Gender = 0, "Nữ", "Nam")
            }).ToList()

            dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvResidents.DataSource = customList

            lblPagingInfo.Text = $"Hiển thị {list.Count} / Tổng {totalCount} bản ghi"

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
        pageIndex = 1
        LoadData()
    End Sub

    Private Sub btnResetSearch_Click(sender As Object, e As EventArgs) Handles btnResetSearch.Click
        txtSearch.Text = ""
        cbxStatus.SelectedIndex = 0
        pageIndex = 1
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvResidents.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một cư dân để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvResidents.SelectedRows(0)
        Dim residentId As Integer = Convert.ToInt32(selectedRow.Cells("Id").Value)

        Dim confirmResult As DialogResult = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa cư dân này?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If confirmResult = DialogResult.Yes Then
            Try
                _residentService.Delete(residentId)
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Catch ex As Exception
                MessageBox.Show("Xóa thất bại: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim form As New ResidentCreateForm(_residentService)
        form.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        If dgvResidents.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một cư dân để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvResidents.SelectedRows(0)
        Dim residentId As Integer = Convert.ToInt32(selectedRow.Cells("Id").Value)

        ' Gọi callback được truyền từ MainForm
        If _onDetailRequested IsNot Nothing Then
            _onDetailRequested(residentId)
        End If
    End Sub
End Class
