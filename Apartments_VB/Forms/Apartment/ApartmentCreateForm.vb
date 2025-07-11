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

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải loại căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ' Khi bấm lưu, lấy dữ liệu từ form và thêm mới căn hộ
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Lấy dữ liệu từ form
            Dim name = txtName.Text.Trim()
            Dim address = txtAddress.Text.Trim()
            Dim floorCount As Integer
            Dim price As Decimal

            ' Kiểm tra ràng buộc đơn giản
            If String.IsNullOrEmpty(name) OrElse String.IsNullOrEmpty(address) Then
                MessageBox.Show("Vui lòng nhập đầy đủ tên và địa chỉ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not Integer.TryParse(txtFloorCount.Text.Trim(), floorCount) Then
                MessageBox.Show("Số tầng phải là số nguyên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFloorCount.Focus()
                Return
            End If

            If Not Decimal.TryParse(txtPrice.Text.Trim(), price) Then
                MessageBox.Show("Giá phải là số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPrice.Focus()
                Return
            End If

            ' Chuẩn bị DTO
            Dim dto As New ApartmentCreateDto With {
                .Name = name,
                .Address = address,
                .FloorCount = floorCount,
                .Price = price,
                .ApartmentTypeId = Convert.ToInt32(cbxApartmentType.SelectedValue)
            }

            ' Gọi service để thêm mới và nhận lại entity
            Dim createdApartment = _apartmentService.Add(dto)

            ' Hiển thị thông tin căn hộ vừa thêm
            MessageBox.Show(
                $"Thêm căn hộ thành công!" & Environment.NewLine &
                $"Tên: {createdApartment.Name}" & Environment.NewLine &
                $"Ngày tạo: {createdApartment.CreatedDate}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information
            )

            ' Đóng form
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm căn hộ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
