Imports System.IO
Imports System.Runtime.Remoting
Imports ClosedXML.Excel

Public Class ResidentControl
    Private ReadOnly _residentService As IResidentService
    Private ReadOnly _onDetailRequested As Action(Of UserControl)
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(residentService As IResidentService, onDetailRequested As Action(Of UserControl))
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
        Try
            ' 1. Lấy điều kiện lọc hiện tại
            Dim keyword As String = txtSearch.Text.Trim()
            Dim isStaying As Nullable(Of Boolean) = Nothing
            Dim statusText As String = "Tất cả trạng thái"

            If cbxStatus.SelectedIndex = 1 Then
                isStaying = True
                statusText = "Đang ở"
            ElseIf cbxStatus.SelectedIndex = 2 Then
                isStaying = False
                statusText = "Đã rời"
            End If

            ' 2. Lấy toàn bộ danh sách cư dân phù hợp
            Dim list As List(Of Resident) = _residentService.GetPagedList(keyword, isStaying, 1, Integer.MaxValue)
            If list Is Nothing OrElse list.Count = 0 Then
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' 3. Tạo Excel
            Dim wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add("DanhSachCuDan")

            ' 4. Ghi tiêu đề bộ lọc
            Dim filterTitle As String = "BỘ LỌC: "
            If keyword = "" Then
                filterTitle &= "Từ khóa: Tất cả; "
            Else
                filterTitle &= "Từ khóa: " & keyword & "; "
            End If
            filterTitle &= "Trạng thái: " & statusText

            ws.Cell("A1").Value = filterTitle
            ws.Range("A1:F1").Merge()
            ws.Range("A1:F1").Style.Font.SetBold()
            ws.Range("A1:F1").Style.Font.FontSize = 12
            ws.Row(1).Height = 20

            ' 5. Ghi tiêu đề cột
            ws.Cell("A2").Value = "ID"
            ws.Cell("B2").Value = "Họ tên"
            ws.Cell("C2").Value = "SĐT"
            ws.Cell("D2").Value = "Email"
            ws.Cell("E2").Value = "Ngày sinh"
            ws.Cell("F2").Value = "Giới tính"
            ws.Range("A2:F2").Style.Font.SetBold()
            ws.Range("A2:F2").Style.Fill.SetBackgroundColor(XLColor.LightGray)

            ' 6. Ghi dữ liệu
            Dim row As Integer = 3
            For Each r As Resident In list
                ws.Cell(row, 1).Value = r.Id
                ws.Cell(row, 2).Value = r.FullName
                ws.Cell(row, 3).Value = r.Phone
                ws.Cell(row, 4).Value = r.Email
                If r.DateOfBirth.HasValue Then
                    ws.Cell(row, 5).Value = r.DateOfBirth.Value.ToString("dd/MM/yyyy")
                Else
                    ws.Cell(row, 5).Value = "Không rõ"
                End If
                ws.Cell(row, 6).Value = If(r.Gender = 0, "Nữ", "Nam")
                row += 1
            Next

            ' 7. Định dạng bảng
            Dim dataRange = ws.Range("A2:F" & (row - 1).ToString())
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin
            dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
            ws.Columns().AdjustToContents()

            ' 8. Tạo tên file mặc định
            Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm")
            Dim defaultFileName As String = "DanhSachCuDan_" & timestamp & ".xlsx"

            ' 9. Dialog lưu file
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Excel Workbook|*.xlsx"
            sfd.FileName = defaultFileName

            If sfd.ShowDialog() = DialogResult.OK Then
                wb.SaveAs(sfd.FileName)
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Lỗi khi xuất Excel: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDetail_Click(sender As Object, e As EventArgs) Handles btnDetail.Click
        If dgvResidents.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một cư dân để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvResidents.SelectedRows(0)
        Dim residentId As Integer = Convert.ToInt32(selectedRow.Cells("Id").Value)

        _onDetailRequested.Invoke(New ResidentDetailControl(residentId, _residentService, ServiceProviderLocator.ApartmentResidentService, _onDetailRequested))
    End Sub
End Class
