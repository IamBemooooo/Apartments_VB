Public Class MaintenanceRequestUpdateForm
    Private ReadOnly _service As IMaintenanceRequestService
    Private ReadOnly _request As MaintenanceRequestDto
    Private ReadOnly _currentUser As CurrentUserDto

    Public Sub New(service As IMaintenanceRequestService, request As MaintenanceRequestDto, currentUser As CurrentUserDto)
        InitializeComponent()
        _service = service
        _request = request
        _currentUser = currentUser
    End Sub

    Private Sub MaintenanceRequestUpdateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetError()

        ' Load dữ liệu cũ

        txtApartmentName.Text = _request.ApartmentName
        rtxtDescription.Text = _request.Description

        cbxStatus.DataSource = New List(Of ComboItem) From {
            New ComboItem("Chờ xử lý", 0),
            New ComboItem("Đang xử lý", 1),
            New ComboItem("Hoàn thành", 2),
            New ComboItem("Từ chối", 3)
        }
        cbxStatus.DisplayMember = "Text"
        cbxStatus.ValueMember = "Value"
        cbxStatus.SelectedValue = _request.StatusId

        ' Nếu đã hoàn thành thì không cho sửa nữa
        If _request.StatusId = MaintenanceRequestStatus.Completed Or _request.StatusId = MaintenanceRequestStatus.Rejected Then
            rtxtDescription.ReadOnly = True
            cbxStatus.Enabled = False
            btnSave.Enabled = False
            MessageBox.Show("Yêu cầu đã hoàn thành và không thể chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If _currentUser.RoleId <> UserRole.Admin Then
            cbxStatus.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ResetError()
        Dim result As New ValidationResult()

        ' Validate mô tả
        ValidationHelper.ValidateRichTextField(result, rtxtDescription, "mô tả", True, 10, 500)

        ' Validate trạng thái (trong trường hợp SelectedValue bị null)
        If cbxStatus.SelectedValue Is Nothing Then
            lblErrorStatus.Text = "Vui lòng chọn trạng thái."
            Return
        End If

        ' Nếu có lỗi thì hiển thị
        If Not result.IsValid Then
            lblErrorDescription.Text = result.GetErrorByField(rtxtDescription.Name)
            Return
        End If

        ' Không có lỗi -> cập nhật
        Try
            Dim updateDto As New MaintenanceRequestUpdateDto With {
                .Id = _request.Id,
                .Description = rtxtDescription.Text.Trim(),
                .Status = Convert.ToInt32(cbxStatus.SelectedValue)
            }

            _service.Update(updateDto)

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi cập nhật: " & ex.Message)
        End Try
    End Sub

    Private Sub ResetError()
        lblErrorDescription.Text = ""
        lblErrorStatus.Text = ""
    End Sub
End Class
