Public Class MainForm
    Private ReadOnly _currentUser As CurrentUserDto

    Public Sub New(currentUser As CurrentUserDto)
        InitializeComponent()
        _currentUser = currentUser
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = _currentUser.FullName
        btnApartmentTab.PerformClick() ' Load tab mặc định
    End Sub

    ' Hàm LoadControl chính
    Public Sub LoadControl(ctrl As UserControl)
        pnlMainContent.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        pnlMainContent.Controls.Add(ctrl)
    End Sub

    ' Reset màu + đánh dấu tab đang được chọn
    Private Sub SetActiveTabButton(activeButton As Button)
        Dim defaultColor As Color = Color.LightGray
        btnApartmentTab.BackColor = defaultColor
        btnMaintenanceRequestTab.BackColor = defaultColor
        btnResdidentTab.BackColor = defaultColor

        activeButton.BackColor = Color.White
    End Sub

    ' ================== Tab Buttons =======================

    Private Sub btnApartmentTab_Click(sender As Object, e As EventArgs) Handles btnApartmentTab.Click
        Dim apartmentControl As New ApartmentControl(
            ServiceProviderLocator.ApartmentService,
            ServiceProviderLocator.ApartmentTypeService,
            ServiceProviderLocator.ApartmentResidentService,
            _currentUser
        )
        LoadControl(apartmentControl)
        SetActiveTabButton(btnApartmentTab)
    End Sub

    Private Sub btnMaintenanceRequestTab_Click(sender As Object, e As EventArgs) Handles btnMaintenanceRequestTab.Click
        Dim maintenanceControl As New MaintenanceRequestControl()
        LoadControl(maintenanceControl)
        SetActiveTabButton(btnMaintenanceRequestTab)
    End Sub

    Private Sub btnResdidentTab_Click(sender As Object, e As EventArgs) Handles btnResdidentTab.Click
        ' Truyền delegate để ResidentControl gọi ShowResidentDetail
        Dim residentControl As New ResidentControl(
            ServiceProviderLocator.ResidentService,
            AddressOf ShowResidentDetail
        )
        LoadControl(residentControl)
        SetActiveTabButton(btnResdidentTab)
    End Sub

    ' ================== Callback: Hiển thị ResidentDetail =======================

    Private Sub ShowResidentDetail(residentId As Integer)
        ' Tạo ResidentDetailControl và truyền tiếp cả delegate LoadControl
        Dim detailControl As New ResidentDetailControl(
            residentId,
            ServiceProviderLocator.ResidentService,
            ServiceProviderLocator.ApartmentResidentService,
            AddressOf LoadControl
        )

        ' Gán callback để từ DetailControl có thể mở control khác
        detailControl._LoadControlCallback = AddressOf LoadControl

        LoadControl(detailControl)
    End Sub
End Class
