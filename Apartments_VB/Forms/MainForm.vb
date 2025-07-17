Public Class MainForm
    Private ReadOnly _currentUser As CurrentUserDto
    Public Sub New(currentUser As CurrentUserDto)
        InitializeComponent()
        _currentUser = currentUser
    End Sub

    ' Khi form load, hiển thị tab căn hộ
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = _currentUser.FullName

        ' Gọi sự kiện click để hiển thị tab Apartment mặc định
        btnApartmentTab.PerformClick()
    End Sub

    Public Sub LoadControl(ctrl As UserControl)
        pnlMainContent.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        pnlMainContent.Controls.Add(ctrl)
    End Sub

    Private Sub SetActiveTabButton(activeButton As Button)
        ' Reset màu cho tất cả
        Dim defaultColor As Color = Color.LightGray
        btnApartmentTab.BackColor = defaultColor
        btnMaintenanceRequestTab.BackColor = defaultColor
        btnResdidentTab.BackColor = defaultColor

        ' Tô màu nổi bật cho nút đang được chọn
        activeButton.BackColor = Color.White
    End Sub


    Private Sub btnApartmentTab_Click(sender As Object, e As EventArgs) Handles btnApartmentTab.Click
        Dim apartmentControl As New ApartmentControl(ServiceProviderLocator.ApartmentService, ServiceProviderLocator.ApartmentTypeService, ServiceProviderLocator.ApartmentResidentService, _currentUser)
        LoadControl(apartmentControl)
        SetActiveTabButton(btnApartmentTab)
    End Sub

    Private Sub btnMaintenanceRequestTab_Click(sender As Object, e As EventArgs) Handles btnMaintenanceRequestTab.Click
        Dim maintenanceControl As New MaintenanceRequestControl()
        LoadControl(maintenanceControl)
        SetActiveTabButton(btnApartmentTab)
    End Sub

    Private Sub btnResdidentTab_Click(sender As Object, e As EventArgs) Handles btnResdidentTab.Click
        ' Truyền delegate để ResidentControl có thể gọi ngược lại LoadControl
        Dim residentControl As New ResidentControl(
            ServiceProviderLocator.ResidentService,
            AddressOf ShowResidentDetail
        )
        LoadControl(residentControl)
        SetActiveTabButton(btnResdidentTab)
    End Sub

    ' Hàm được delegate gọi khi nhấn nút Detail trong ResidentControl
    Private Sub ShowResidentDetail(residentId As Integer)
        Dim detailControl As New ResidentDetailControl(residentId,ServiceProviderLocator.ResidentService,ServiceProviderLocator.ApartmentResidentService)
        LoadControl(detailControl)
    End Sub
End Class