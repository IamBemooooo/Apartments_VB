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
            New ComboItem("Hoàn thành", 2)
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
End Class
