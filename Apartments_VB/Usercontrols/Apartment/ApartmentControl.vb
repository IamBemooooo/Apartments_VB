Imports ClosedXML.Excel
Imports System.IO
Public Class ApartmentControl


    Private ReadOnly _apartmentService As IApartmentService
    Private ReadOnly _apartmentTypeService As IApartmentTypeService
    Private ReadOnly _currentUser As CurrentUserDto
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(apartmentService As IApartmentService, apartmentTypeService As IApartmentTypeService, currentUser As CurrentUserDto)
        InitializeComponent()
        _apartmentService = apartmentService
        _currentUser = currentUser
        _apartmentTypeService = apartmentTypeService
    End Sub

    Private Sub ApartmentControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim types = _apartmentTypeService.GetAll()

        If types Is Nothing OrElse types.Count = 0 Then
            MessageBox.Show("Không có loại căn hộ nào để chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        cbxApartmentType.DisplayMember = "Name"
        cbxApartmentType.ValueMember = "Id"

        ' Thêm dòng đầu là "Vui lòng chọn"
        types.Insert(0, New ApartmentTypeDto With {
            .Id = -1,
            .Name = "--- Vui lòng chọn ---"
        })
        cbxApartmentType.DataSource = types
        LoadData()
        If _currentUser.RoleId <> UserRole.Admin Then
            btnDelete.Visible = False
            btnUpdate.Visible = False
        End If
    End Sub

    Private Sub LoadData()
        Try
            Dim keyword = txtSearch.Text.Trim()
            Dim typeId As Integer = Convert.ToInt32(cbxApartmentType.SelectedValue)

            ' Gọi hàm lấy danh sách có lọc theo loại căn hộ
            Dim list = _apartmentService.GetPagedList(keyword, typeId, pageIndex, pageSize)
            totalCount = _apartmentService.GetTotalCount(keyword, typeId)

            Dim customList = list.Select(Function(a) New With {
                a.Id,
                Key .Tên = a.Name,
                Key .LoạiCănHộ = If(a.ApartmentTypeName, "Chưa xác định"),
                Key .ĐịaChỉ = a.Address,
                Key .SốTầng = a.FloorCount,
                Key .NgàyTạo = a.CreatedDate.ToString("dd/MM/yyyy"),
                Key .Giá = FormatNumber(a.Price, 0, TriState.True, TriState.False, TriState.True) ' Ngăn có số âm + có phân cách
            }).ToList()


            dgvApartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvApartments.DataSource = customList


            ' Cập nhật label phân trang
            lblPagingInfo.Text = $"Hiển thị {list.Count} / Tổng {totalCount} bản ghi"


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

    Private Sub ExportListToExcel(data As List(Of ApartmentDto), keyword As String, typeId As Integer)

        Try
            Dim selectedTypeName As String = ""

            If typeId <> -1 Then
                ' Tìm tên loại căn hộ từ ComboBox
                Dim selectedItem = TryCast(cbxApartmentType.SelectedItem, ApartmentTypeDto)
                If selectedItem IsNot Nothing Then
                    selectedTypeName = selectedItem.Name
                End If
            End If

            ' === 1. TẠO TÊN FILE ===
            Dim fileNameKeyword As String = If(String.IsNullOrEmpty(keyword), "All", keyword.Replace(" ", "_"))
            Dim typeKeyword As String = If(typeId = -1, "AllTypes", selectedTypeName.Replace(" ", "_"))
            Dim fileName As String = $"Apartments_{fileNameKeyword}_{typeKeyword}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"


            ' === 2. SAVE FILE DIALOG ===
            Using sfd As New SaveFileDialog()
                sfd.FileName = fileName
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Using wb As New XLWorkbook()
                        Dim ws = wb.Worksheets.Add("Apartments")

                        ' === 3. TIÊU ĐỀ (DÒNG 1) ===
                        Dim headers = New String() {"STT", "Tên", "Loại căn hộ", "Số tầng", "Địa chỉ", "Giá", "Ngày tạo"}

                        Dim titleText As String = "DANH SÁCH CĂN HỘ"
                        If Not String.IsNullOrEmpty(keyword) Then
                            titleText &= $" - Từ khóa: '{keyword}'"
                        End If


                        If Not String.IsNullOrEmpty(selectedTypeName) Then
                            titleText &= $" - Loại căn hộ: '{selectedTypeName}'"
                        End If

                        ws.Cell(1, 1).Value = titleText
                        ws.Range(1, 1, 1, headers.Length).Merge()
                        With ws.Cell(1, 1).Style
                            .Font.Bold = True
                            .Font.FontSize = 14
                            .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                        End With

                        ' === 4. HEADER (DÒNG 2) ===
                        For i = 0 To headers.Length - 1
                            With ws.Cell(2, i + 1)
                                .Value = headers(i)
                                .Style.Font.Bold = True
                                .Style.Fill.BackgroundColor = XLColor.LightGray
                                .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                            End With
                        Next

                        ' === 5. GHI DỮ LIỆU (TỪ DÒNG 3) ===
                        Dim rowIndex As Integer = 3
                        For Each item In data
                            ws.Cell(rowIndex, 1).Value = rowIndex - 2 ' STT
                            ws.Cell(rowIndex, 2).Value = item.Name
                            ws.Cell(rowIndex, 3).Value = item.ApartmentTypeName
                            ws.Cell(rowIndex, 4).Value = item.FloorCount
                            ws.Cell(rowIndex, 5).Value = item.Address
                            ws.Cell(rowIndex, 6).Value = item.Price
                            ws.Cell(rowIndex, 6).Style.NumberFormat.Format = "#,##0"
                            ws.Cell(rowIndex, 7).Value = "'" & item.CreatedDate.ToString("dd/MM/yyyy")
                            ws.Cell(rowIndex, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                            rowIndex += 1
                        Next

                        ' === 6. ĐÓNG KHUNG TOÀN BỘ BẢNG ===
                        Dim dataRange = ws.Range(2, 1, rowIndex - 1, headers.Length)
                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin

                        ' === 7. CĂN CỘT VỪA NỘI DUNG ===
                        ws.Columns().AdjustToContents()

                        ' === 8. LƯU FILE ===
                        wb.SaveAs(sfd.FileName)
                    End Using

                    MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Lỗi khi xuất Excel: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function Quote(value As Object) As String
        If value Is Nothing Then Return "" ' Xử lý giá trị null
        Dim s = value.ToString()
        If s.Contains(",") OrElse s.Contains("""") OrElse s.Contains(vbCrLf) Then
            s = """" & s.Replace("""", """""") & """"
        End If
        Return s
    End Function


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            Dim keyword = txtSearch.Text.Trim()
            Dim typeId As Integer = Convert.ToInt32(cbxApartmentType.SelectedValue)

            Dim allData = _apartmentService.GetAllByKeyword(keyword, typeId)
            ExportListToExcel(allData, keyword, typeId)
        Catch ex As Exception
            MessageBox.Show("Lỗi khi xuất Excel: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetSearch_Click(sender As Object, e As EventArgs) Handles btnResetSearch.Click
        Try
            ' Xóa ô tìm kiếm
            txtSearch.Text = ""

            ' Reset ComboBox về dòng đầu tiên ("--- Vui lòng chọn ---")
            cbxApartmentType.SelectedIndex = 0

            ' Reset trang
            pageIndex = 1

            ' Tải lại dữ liệu đầy đủ
            LoadData()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi reset tìm kiếm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
