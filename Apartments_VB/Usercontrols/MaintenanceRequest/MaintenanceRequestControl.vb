Imports ClosedXML.Excel
Imports System.IO

Public Class MaintenanceRequestControl

    Private ReadOnly _service As IMaintenanceRequestService
    Private ReadOnly _apartmentService As IApartmentService
    Private ReadOnly _currentUser As CurrentUserDto
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(service As IMaintenanceRequestService, apartmentService As IApartmentService, currentUser As CurrentUserDto)
        InitializeComponent()
        _service = service
        _apartmentService = apartmentService
        _currentUser = currentUser
    End Sub

    Private Sub MaintenanceRequestControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStatusComboBox()
        LoadApartmentsToComboBox()
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim status As Integer = -1
            If cbxStatus.SelectedValue IsNot Nothing Then
                status = Convert.ToInt32(cbxStatus.SelectedValue)
            End If

            Dim apartmentId As Integer = -1
            If cbxApartment.SelectedValue IsNot Nothing Then
                apartmentId = Convert.ToInt32(cbxApartment.SelectedValue)
            End If

            Dim list = _service.GetPagedList(pageIndex, pageSize, status, apartmentId)
            If list Is Nothing Then list = New List(Of MaintenanceRequestDto)()
            totalCount = _service.CountByFilter(status, apartmentId)

            Dim customList = list.Select(Function(r) New With {
                r.Id,
                Key .CănHộ = r.ApartmentName,
                Key .MôTả = r.Description,
                Key .NgàyYêuCầu = r.RequestDate.ToString("dd/MM/yyyy HH:mm"),
                Key .TrạngThái = GetStatusString(r.Status)
            }).ToList()

            dgvRequests.DataSource = customList
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            lblPagingInfo.Text = $"Hiển thị {list.Count} / Tổng {totalCount} bản ghi"
            btnPrev.Enabled = pageIndex > 1
            btnNext.Enabled = (pageIndex * pageSize) < totalCount

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetStatusString(status As Integer) As String
        Select Case status
            Case 0 : Return "Chờ xử lý"
            Case 1 : Return "Đang xử lý"
            Case 2 : Return "Hoàn thành"
            Case 3 : Return "Từ chối"
            Case Else : Return "Không xác định"
        End Select
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        pageIndex = 1
        LoadData()
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

    Private Sub LoadStatusComboBox()
        cbxStatus.DataSource = New List(Of ComboItem) From {
            New ComboItem("Tất cả", -1),
            New ComboItem("Chờ xử lý", 0),
            New ComboItem("Đang xử lý", 1),
            New ComboItem("Hoàn thành", 2),
            New ComboItem("Từ chối", 3)
        }
        cbxStatus.DisplayMember = "Text"
        cbxStatus.ValueMember = "Value"
        cbxStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadApartmentsToComboBox()
        Try
            Dim list = _apartmentService.GetPagedList(Nothing, -1, 1, 100)

            ' THÊM căn hộ "Tất cả"
            list.Insert(0, New ApartmentDto With {
                .Id = -1,
                .Name = "Tất cả"
            })

            cbxApartment.DataSource = list
            cbxApartment.DisplayMember = "Name" ' Bắt buộc đúng tên thuộc tính
            cbxApartment.ValueMember = "Id"
            cbxApartment.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải danh sách căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim form As New MaintenanceRequestCreateForm(_service, ServiceProviderLocator.ApartmentService)
        form.ShowDialog()

        LoadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvRequests.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một yêu cầu cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Lấy ID từ dòng đang chọn
        Dim selectedId As Integer = Convert.ToInt32(dgvRequests.CurrentRow.Cells("Id").Value)

        ' Lấy chi tiết yêu cầu từ service
        Dim request = _service.GetById(selectedId)
        If request Is Nothing Then
            MessageBox.Show("Không tìm thấy yêu cầu bảo trì này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Hiển thị form cập nhật
        Dim form As New MaintenanceRequestUpdateForm(_service, request, _currentUser)
        form.ShowDialog()

        ' Reload lại dữ liệu sau khi đóng form
        LoadData()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            ' Lấy điều kiện lọc hiện tại
            Dim status As Integer = -1
            If cbxStatus.SelectedValue IsNot Nothing Then
                status = Convert.ToInt32(cbxStatus.SelectedValue)
            End If

            Dim apartmentId As Integer = -1
            If cbxApartment.SelectedValue IsNot Nothing Then
                apartmentId = Convert.ToInt32(cbxApartment.SelectedValue)
            End If

            ' Lấy toàn bộ dữ liệu phù hợp (không phân trang)
            Dim list = _service.GetPagedList(1, Integer.MaxValue, status, apartmentId)
            If list Is Nothing OrElse list.Count = 0 Then
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Tạo file Excel
            Dim wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add("YêuCầuBảoTrì")

            ' Ghi phần tiêu đề lọc
            Dim filterTitle As String = $"BỘ LỌC: "
            If status = -1 Then
                filterTitle &= "Trạng thái: Tất cả; "
            Else
                filterTitle &= $"Trạng thái: {GetStatusString(status)}; "
            End If

            If apartmentId = -1 Then
                filterTitle &= "Căn hộ: Tất cả"
            Else
                Dim selectedApartment = cbxApartment.Text
                filterTitle &= $"Căn hộ: {selectedApartment}"
            End If

            ws.Cell("A1").Value = filterTitle
            ws.Range("A1:E1").Merge().Style.Font.SetBold().Font.FontSize = 12
            ws.Row(1).Height = 20

            ' Ghi tiêu đề cột
            ws.Cell("A2").Value = "ID"
            ws.Cell("B2").Value = "Căn hộ"
            ws.Cell("C2").Value = "Mô tả"
            ws.Cell("D2").Value = "Ngày yêu cầu"
            ws.Cell("E2").Value = "Trạng thái"

            ws.Range("A2:E2").Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.LightGray)

            ' Ghi dữ liệu
            Dim row = 3
            For Each r In list
                ws.Cell(row, 1).Value = r.Id
                ws.Cell(row, 2).Value = r.ApartmentName
                ws.Cell(row, 3).Value = r.Description
                ws.Cell(row, 4).Value = r.RequestDate.ToString("dd/MM/yyyy HH:mm")
                ws.Cell(row, 5).Value = GetStatusString(r.Status)
                row += 1
            Next

            ' Căn chỉnh và thêm viền
            Dim dataRange = ws.Range("A2:E" & (row - 1))
            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin
            dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left

            ws.Columns().AdjustToContents()

            ' Tạo tên file với thời gian thực
            Dim now = DateTime.Now
            Dim timestamp = now.ToString("yyyy-MM-dd_HH-mm")
            Dim defaultFileName = $"YeuCauBaoTri_{timestamp}.xlsx"

            ' Chọn nơi lưu file
            Dim sfd As New SaveFileDialog With {
            .Filter = "Excel Workbook|*.xlsx",
            .FileName = defaultFileName
        }

            If sfd.ShowDialog() = DialogResult.OK Then
                wb.SaveAs(sfd.FileName)
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Lỗi khi xuất Excel: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetSearch_Click(sender As Object, e As EventArgs) Handles btnResetSearch.Click
        Try
            ' Xóa ô tìm kiếm nếu có (nếu có textbox tìm kiếm)
            ' Nếu không có thì bỏ qua dòng này
            ' txtSearch.Text = ""

            ' Reset ComboBox trạng thái về "Tất cả"
            cbxStatus.SelectedIndex = 0

            ' Reset ComboBox căn hộ về "Tất cả"
            cbxApartment.SelectedIndex = 0

            ' Reset trang
            pageIndex = 1

            ' Tải lại dữ liệu đầy đủ
            LoadData()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi reset tìm kiếm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStatus.SelectedIndexChanged

    End Sub
End Class
