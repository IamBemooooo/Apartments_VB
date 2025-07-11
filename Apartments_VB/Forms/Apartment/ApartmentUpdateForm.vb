Public Class ApartmentUpdateForm
    Private ReadOnly _apartmentId As Integer
    Private ReadOnly _apartmentService As IApartmentService
    Private ReadOnly _apartmentTypeService As IApartmentTypeService

    Public Sub New(apartmentId As Integer,
                   apartmentService As IApartmentService,
                   apartmentTypeService As IApartmentTypeService)

        InitializeComponent()
        _apartmentId = apartmentId
        _apartmentService = apartmentService
        _apartmentTypeService = apartmentTypeService
    End Sub

    Private Sub ApartmentUpdateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Load danh sách loại căn hộ vào combobox
            Dim apartmentTypes = _apartmentTypeService.GetAll()

            cbxApartmentType.DataSource = apartmentTypes
            cbxApartmentType.DisplayMember = "Name"
            cbxApartmentType.ValueMember = "Id"

            ' Load thông tin căn hộ đang chọn
            Dim apartment = _apartmentService.GetById(_apartmentId)
            If apartment IsNot Nothing Then
                txtName.Text = apartment.Name
                txtAddress.Text = apartment.Address
                txtPrice.Text = apartment.Price.ToString()
                txtFloorCount.Text = apartment.FloorCount.ToString()

                ' Đảm bảo gán giá trị đúng vào combobox
                If apartmentTypes.Any(Function(t) t.Id = apartment.ApartmentTypeId) Then
                    cbxApartmentType.SelectedValue = apartment.ApartmentTypeId
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Không thể tải dữ liệu căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close() ' Đóng form vì không thể làm gì tiếp nếu lỗi load
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Lấy dữ liệu từ form
            Dim name = txtName.Text.Trim()
            Dim address = txtAddress.Text.Trim()
            Dim floorCount As Integer = Convert.ToInt32(txtFloorCount.Text)
            Dim price As Decimal = Convert.ToDecimal(txtPrice.Text)
            Dim typeId As Integer = Convert.ToInt32(cbxApartmentType.SelectedValue)

            ' Kiểm tra ràng buộc đơn giản
            If String.IsNullOrEmpty(name) OrElse String.IsNullOrEmpty(address) Then
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Tạo DTO
            Dim apartmentDto As New ApartmentUpdateDto With {
                .Id = _apartmentId,
                .Name = name,
                .Address = address,
                .FloorCount = floorCount,
                .Price = price,
                .ApartmentTypeId = typeId
            }

            ' Gọi service để cập nhật
            _apartmentService.Update(apartmentDto)

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch formatEx As FormatException
            MessageBox.Show("Giá hoặc số tầng không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi cập nhật: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
