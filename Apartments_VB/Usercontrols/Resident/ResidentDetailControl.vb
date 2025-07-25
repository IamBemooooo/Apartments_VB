Public Class ResidentDetailControl
    Private ReadOnly _residentId As Integer
    Private ReadOnly _residentService As IResidentService
    Private ReadOnly _apartmentResidentService As IApartmentResidentService
    Public Property _LoadControlCallback As Action(Of UserControl) ' <- Thêm dòng này
    Private currentPageIndex As Integer = 1
    Private pageSize As Integer = 10
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 1

    ' Constructor có tham số
    Public Sub New(residentId As Integer, residentService As IResidentService, apartmentResidentService As IApartmentResidentService, LoadControlCallback As Action(Of UserControl))
        InitializeComponent()
        cbxGender.Items.Clear()
        cbxGender.Items.AddRange(New String() {"Nữ", "Nam"})

        cbxStatus.Items.Clear()
        cbxStatus.Items.AddRange(New String() {"Tất cả", "Cư trú hiện tại", "Đã rời đi"})
        _residentId = residentId
        _residentService = residentService
        _apartmentResidentService = apartmentResidentService
        _LoadControlCallback = LoadControlCallback
        cbxStatus.SelectedIndex = 0 ' Mặc định là Tất cả
    End Sub

    Private Sub ResidentDetailControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetErrorLabels()
        LoadResidentData()
        LoadStayHistory()
    End Sub

    Private Sub resetErrorLabels()
        lblErrorName.Text = ""
        lblErrorPhone.Text = ""
        lblErrorEmail.Text = ""
        lblErrorGender.Text = ""
        lblErrorDOB.Text = ""
    End Sub

    Private Sub LoadResidentData()
        Dim resident As Resident = _residentService.GetById(_residentId)

        If resident IsNot Nothing Then
            txtName.Text = resident.FullName
            txtPhone.Text = resident.Phone
            txtEmail.Text = resident.Email

            If resident.DateOfBirth.HasValue Then
                dtpDateOfBirth.Value = resident.DateOfBirth.Value
            Else
                dtpDateOfBirth.Value = DateTime.Today
            End If

            If resident.Gender >= 0 AndAlso resident.Gender < cbxGender.Items.Count Then
                cbxGender.SelectedIndex = resident.Gender
            Else
                cbxGender.SelectedIndex = -1
            End If
        End If
    End Sub


    Private Sub LoadStayHistory()
        Try
            Dim status As Boolean?
            If cbxStatus.SelectedIndex = 0 Then
                status = Nothing ' T
            End If
            If cbxStatus.SelectedIndex = 1 Then
                status = True ' Cư trú hiện tại
            End If
            If cbxStatus.SelectedIndex = 2 Then
                status = False ' Đã rời đi
            End If
            ' Gọi service lấy danh sách phân trang
            Dim histories = _apartmentResidentService.GetApartmentStayHistoryByResidentId(_residentId, status, currentPageIndex, pageSize)

            ' Lấy tổng số bản ghi
            totalRecords = _apartmentResidentService.CountApartmentStayHistoryByResidentId(_residentId)

            ' Nếu không có dữ liệu, hiển thị thông báo
            If histories Is Nothing OrElse histories.Count = 0 Then
                dgvStayHistory.DataSource = Nothing
                lblPagingInfo.Text = "Không có dữ liệu"
                btnPrev.Enabled = False
                btnNext.Enabled = False
                btnLeft.Enabled = False
                Return
            End If

            ' Bind data
            Dim customList = histories.Select(Function(h, index) New With {
            Key .STT = (currentPageIndex - 1) * pageSize + index + 1,
            Key .MãCănHộ = h.Id,
            Key .TênCănHộ = h.Name,
            Key .LoạiCănHộ = h.ApartmentTypeName,
            Key .SốTầng = h.FloorCount,
            Key .TừNgày = h.StartDate.ToString("dd/MM/yyyy"),
            Key .ĐếnNgày = If(h.EndDate.HasValue, h.EndDate.Value.ToString("dd/MM/yyyy"), "Hiện tại"),
            Key .GhiChú = If(String.IsNullOrEmpty(h.Note), "Không có", h.Note)
        }).ToList()

            dgvStayHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvStayHistory.DataSource = customList

            ' Cập nhật label phân trang (kiểu số bản ghi)
            lblPagingInfo.Text = $"Hiển thị {customList.Count} / Tổng {totalRecords} bản ghi"

            ' Cập nhật trạng thái nút
            btnPrev.Enabled = currentPageIndex > 1
            btnNext.Enabled = (currentPageIndex * pageSize) < totalRecords

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải lịch sử cư trú: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If currentPageIndex > 1 Then
            currentPageIndex -= 1
            LoadStayHistory()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPageIndex < totalPages Then
            currentPageIndex += 1
            LoadStayHistory()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            resetErrorLabels()

            Dim result As New ValidationResult()

            ' Lấy dữ liệu từ form
            Dim fullName = txtName.Text.Trim()
            Dim phone = txtPhone.Text.Trim()
            Dim email = txtEmail.Text.Trim()
            Dim dateOfBirth As Date = dtpDateOfBirth.Value
            Dim genderIndex As Integer = cbxGender.SelectedIndex

            ' Kiểm tra hợp lệ
            ValidationHelper.ValidateTextField(result, txtName, "họ tên")
            ValidationHelper.ValidatePhoneField(result, txtPhone, "số điện thoại")
            ValidationHelper.ValidateEmailField(result, txtEmail, "email")
            ValidationHelper.ValidateComboBox(result, cbxGender, "giới tính")

            ' Hiển thị lỗi nếu có
            lblErrorName.Text = result.GetErrorByField(txtName.Name)
            lblErrorPhone.Text = result.GetErrorByField(txtPhone.Name)
            lblErrorEmail.Text = result.GetErrorByField(txtEmail.Name)
            lblErrorGender.Text = result.GetErrorByField(cbxGender.Name)

            If Not result.IsValid Then Return

            ' Tạo DTO
            Dim residentDto As New ResidentUpdateDto With {
                .Id = _residentId,
                .FullName = fullName,
                .Phone = phone,
                .Email = email,
                .DateOfBirth = dateOfBirth,
                .Gender = genderIndex
            }

            ' Gọi service cập nhật
            _residentService.Update(residentDto)

            MessageBox.Show("Cập nhật thông tin cư dân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch formatEx As FormatException
            MessageBox.Show("Dữ liệu nhập không đúng định dạng. Vui lòng kiểm tra lại.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi cập nhật cư dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStatus.SelectedIndexChanged
        currentPageIndex = 1
        LoadStayHistory()
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        Dim leftForm As New LeftApartmentFrom(_residentId, _apartmentResidentService)
        leftForm.ShowDialog()

        LoadStayHistory()
    End Sub

    Private Sub dgvStayHistory_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStayHistory.SelectionChanged
        If dgvStayHistory.SelectedRows.Count = 0 Then
            btnLeft.Enabled = False
            Return
        End If

        Dim selectedRow = dgvStayHistory.SelectedRows(0).DataBoundItem
        Dim endDateStr As String = dgvStayHistory.SelectedRows(0).Cells("ĐếnNgày").Value.ToString()
        If endDateStr = "Hiện tại" Then
            btnLeft.Enabled = True
        Else
            btnLeft.Enabled = False
        End If
    End Sub

    Private Sub btnAddResidentToApartment_Click(sender As Object, e As EventArgs) Handles btnAddResidentToApartment.Click
        _LoadControlCallback?.Invoke(New AddResidentToApartment(_residentId, ServiceProviderLocator.ApartmentService, ServiceProviderLocator.ApartmentTypeService, _apartmentResidentService, _LoadControlCallback))
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If _LoadControlCallback IsNot Nothing Then
            _LoadControlCallback.Invoke(New ResidentControl(_residentService, _LoadControlCallback))
        End If
    End Sub
End Class
