Imports System.Data.SqlClient
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.InkML

Public Class ApartmentCreateForm

    Private ReadOnly _apartmentService As IApartmentService
    Private ReadOnly _apartmentTypeService As IApartmentTypeService

    ' Constructor nhận DI từ ApartmentForm
    Public Sub New(apartmentService As IApartmentService, apartmentTypeService As IApartmentTypeService)
        InitializeComponent()
        _apartmentService = apartmentService
        _apartmentTypeService = apartmentTypeService
    End Sub

    ' Khi form load, đổ dữ liệu loại căn hộ vào ComboBox
    Private Sub ApartmentCreateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim types = _apartmentTypeService.GetAll()

            If types Is Nothing OrElse types.Count = 0 Then
                MessageBox.Show("Không có loại căn hộ nào để chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If

            cbxApartmentType.DisplayMember = "Name"
            cbxApartmentType.ValueMember = "Id"
            cbxApartmentType.DataSource = types

            resetErrorLabels()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải loại căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub resetErrorLabels()
        ' Reset tất cả nhãn lỗi về rỗng
        lblErrorApartmentName.Text = ""
        lblErrorApartmentType.Text = ""
        lblErrorAddress.Text = ""
        lblErrorFloorCount.Text = ""
        lblErrorPrice.Text = ""
    End Sub

    ' Khi bấm lưu, lấy dữ liệu từ form và thêm mới căn hộ
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            resetErrorLabels()

            Dim result As New ValidationResult()

            ' 1. Lấy dữ liệu text
            Dim name As String = txtName.Text.Trim()
            Dim address As String = txtAddress.Text.Trim()

            ' 2. Gọi các hàm kiểm tra từ ValidationHelper
            ValidationHelper.ValidateTextField(result, txtName, "tên căn hộ")
            ValidationHelper.ValidateTextField(result, txtAddress, "địa chỉ")
            ValidationHelper.ValidateIntegerField(result, txtFloorCount, "số tầng", True, 1)
            ValidationHelper.ValidateDecimalField(result, txtPrice, "giá", True, 0)
            ValidationHelper.ValidateComboBox(result, cbxApartmentType, "loại căn hộ")

            ' 3. Gán lỗi lên giao diện
            lblErrorApartmentName.Text = result.GetErrorByField(txtName.Name)
            lblErrorApartmentType.Text = result.GetErrorByField(cbxApartmentType.Name)
            lblErrorAddress.Text = result.GetErrorByField(txtAddress.Name)
            lblErrorFloorCount.Text = result.GetErrorByField(txtFloorCount.Name)
            lblErrorPrice.Text = result.GetErrorByField(txtPrice.Name)

            ' 4. Nếu có lỗi thì dừng lại
            If Not result.IsValid Then Return

            ' 5. Parse sau khi chắc chắn dữ liệu hợp lệ
            Dim floorCount As Integer = Convert.ToInt32(txtFloorCount.Text.Trim())
            Dim price As Decimal = Convert.ToDecimal(txtPrice.Text.Trim())
            Dim apartmentTypeId As Integer = Convert.ToInt32(cbxApartmentType.SelectedValue)

            ' 6. Tạo DTO
            Dim dto As New ApartmentCreateDto With {
                .Name = name,
                .Address = address,
                .FloorCount = floorCount,
                .Price = price,
                .ApartmentTypeId = apartmentTypeId
            }

            ' 7. Gọi service
            Dim createdApartment = _apartmentService.Add(dto)

            ' 8. Thông báo và đóng form
            MessageBox.Show(
                $"Thêm căn hộ thành công!" & Environment.NewLine &
                $"Tên: {createdApartment.Name}" & Environment.NewLine &
                $"Ngày tạo: {createdApartment.CreatedDate}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information
            )

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
