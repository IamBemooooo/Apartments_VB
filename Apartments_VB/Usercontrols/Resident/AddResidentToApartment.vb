Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class AddResidentToApartment
    Private ReadOnly _residentId As Integer
    Private ReadOnly _apartmentService As IApartmentService
    Private ReadOnly _apartmentTypeService As IApartmentTypeService
    Private ReadOnly _apartmentResidentService As IApartmentResidentService
    Public Property _LoadControlCallback As Action(Of UserControl)
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(residentId As Integer, apartmentService As IApartmentService, apartmentTypeService As IApartmentTypeService, apartmentResidentService As IApartmentResidentService, LoadControlCallback As Action(Of UserControl))
        InitializeComponent()
        _residentId = residentId
        _apartmentService = apartmentService
        _apartmentTypeService = apartmentTypeService
        _apartmentResidentService = apartmentResidentService
        _LoadControlCallback = LoadControlCallback
    End Sub

    Private Sub AddResidentToApartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If dgvApartments.CurrentRow Is Nothing Then
            MessageBox.Show("Vui lòng chọn một căn hộ để thêm cư dân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim apartmentId As Integer = Convert.ToInt32(dgvApartments.CurrentRow.Cells("Id").Value)
        Dim verifyForm As New VerifyResidence(_residentId, apartmentId, _apartmentResidentService, ServiceProviderLocator.ApartmentTypeService, ServiceProviderLocator.ResidentService, _apartmentService, _LoadControlCallback)
        verifyForm.ShowDialog()
    End Sub
End Class
