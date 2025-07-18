Public Class VerifyResidence
    Private ReadOnly _residentId As Integer
    Private ReadOnly _apartmentId As Integer
    Private ReadOnly _apartmentResidentService As IApartmentResidentService
    Private ReadOnly _apartmentTypeService As IApartmentTypeService
    Private ReadOnly _residentService As IResidentService
    Private ReadOnly _apartmentService As IApartmentService
    Public Property _LoadControlCallback As Action(Of UserControl)

    Public Sub New(
        residentId As Integer,
        apartmentId As Integer,
        apartmentResidentService As IApartmentResidentService,
        apartmentTypeService As IApartmentTypeService,
        residentService As IResidentService,
        apartmentService As IApartmentService,
        LoadControlCallback As Action(Of UserControl)
    )
        InitializeComponent()
        _residentId = residentId
        _apartmentId = apartmentId
        _apartmentTypeService = apartmentTypeService
        _apartmentResidentService = apartmentResidentService
        _residentService = residentService
        _apartmentService = apartmentService
        _LoadControlCallback = LoadControlCallback
    End Sub
    Private Sub btnConsent_Click(sender As Object, e As EventArgs) Handles btnConsent.Click
        ' Kiểm tra StartDate đã nhập
        Dim startDate As Date
        If Not Date.TryParse(txtStartDate.Text, startDate) Then
            MessageBox.Show("Ngày bắt đầu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim checkResidentInAnotherApartment As ApartmentDto = _apartmentResidentService.GetCurrentApartmentByResidentId(_residentId)
        If checkResidentInAnotherApartment IsNot Nothing Then
            If checkResidentInAnotherApartment.Id <> _apartmentId Then
                MessageBox.Show("Cư dân này đã có căn hộ khác. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
        ' Tạo đối tượng ApartmentResidentDto (tuỳ theo cấu trúc của bạn)
        Dim apartmentResidentDto As New ApartmentResidentCreateDto With {
            .ApartmentId = _apartmentId,
            .ResidentId = _residentId,
            .StartDate = startDate
        }

        Try
            _apartmentResidentService.AssignResident(apartmentResidentDto)
            MessageBox.Show("Thêm cư dân vào căn hộ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _LoadControlCallback?.Invoke(New ResidentDetailControl(_residentId, _residentService, _apartmentResidentService, _LoadControlCallback))
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Đã xảy ra lỗi khi thêm cư dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VerifyResidence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxGender.Items.Clear()
        cbxGender.Items.AddRange(New String() {"Nữ", "Nam"})

        ' Load danh sách loại căn hộ vào combobox
        Dim apartmentTypes = _apartmentTypeService.GetAll()

        cbxApartmentType.DataSource = apartmentTypes
        cbxApartmentType.DisplayMember = "Name"
        cbxApartmentType.ValueMember = "Id"

        ' Lấy thông tin cư dân
        Dim resident = _residentService.GetById(_residentId)
        If resident IsNot Nothing Then
            txtName.Text = resident.FullName
            dtpDateOfBirth.Value = resident.DateOfBirth.Value
            cbxGender.SelectedIndex = resident.Gender
            txtPhone.Text = resident.Phone
            txtEmail.Text = resident.Email
        End If

        ' Lấy thông tin căn hộ
        Dim apartment = _apartmentService.GetById(_apartmentId)
        If apartment IsNot Nothing Then
            txtApartmentName.Text = apartment.Name
            txtAddress.Text = apartment.Address
            cbxApartmentType.SelectedValue = apartment.ApartmentTypeId

            txtFloorCount.Text = apartment.FloorCount.ToString()
            txtPrice.Text = FormatNumber(apartment.Price, 0, TriState.True, TriState.False, TriState.True) ' Ngăn có số âm + có phân cách
        End If

        ' Gán ngày hiện tại cho txtStartDate
        txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd")
    End Sub
End Class