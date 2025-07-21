Public Class MaintenanceRequestCreateForm
    Private ReadOnly _service As IMaintenanceRequestService
    Private ReadOnly _apartmentService As IApartmentService

    Public Sub New(service As IMaintenanceRequestService, apartmentService As IApartmentService)
        InitializeComponent()
        _service = service
        _apartmentService = apartmentService
    End Sub

    Private Sub MaintenanceRequestCreateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetError()
        LoadApartmentsToComboBox()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ResetError()

        Dim result As New ValidationResult()

        ' Validate ComboBox căn hộ
        If cbxApartment.SelectedValue Is Nothing OrElse Convert.ToInt32(cbxApartment.SelectedValue) = -1 Then
            lblErrorApartment.Text = "Vui lòng chọn căn hộ."
            Return
        End If


        ' Validate mô tả
        ValidationHelper.ValidateRichTextField(result, rtxtDescription, "mô tả", required:=True, minLength:=10, maxLength:=500)

        ' Nếu có lỗi thì hiển thị lên UI
        If Not result.IsValid Then
            lblErrorDescription.Text = result.GetErrorByField(rtxtDescription.Name)
            Return
        End If

        ' Nếu không có lỗi thì tạo mới yêu cầu
        Try
            Dim request As New MaintenanceRequestCreateDto With {
            .ApartmentId = Convert.ToInt32(cbxApartment.SelectedValue),
            .Description = rtxtDescription.Text.Trim()
        }

            _service.Add(request)
            MessageBox.Show("Tạo yêu cầu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tạo yêu cầu: " & ex.Message)
        End Try
    End Sub


    Sub ResetError()
        lblErrorDescription.Text = String.Empty
        lblErrorApartment.Text = String.Empty
    End Sub


    Private Sub LoadApartmentsToComboBox()
        Try
            Dim list = _apartmentService.GetPagedList(Nothing, -1, 1, 100)

            ' THÊM căn hộ "Tất cả"
            list.Insert(0, New ApartmentDto With {
                .Id = -1,
                .Name = "Chọn căn hộ"
            })

            cbxApartment.DataSource = list
            cbxApartment.DisplayMember = "Name" ' Bắt buộc đúng tên thuộc tính
            cbxApartment.ValueMember = "Id"
            cbxApartment.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải danh sách căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
