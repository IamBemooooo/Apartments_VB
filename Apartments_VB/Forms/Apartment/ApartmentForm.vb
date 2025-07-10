Public Class ApartmentForm

    Private ReadOnly _apartmentService As IApartmentService
    Private pageIndex As Integer = 1
    Private ReadOnly pageSize As Integer = 10
    Private totalCount As Integer = 0

    Public Sub New(apartmentService As IApartmentService)
        InitializeComponent()
        _apartmentService = apartmentService
    End Sub

    Private Sub ApartmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim keyword = txtSearch.Text.Trim()
            Dim list = _apartmentService.GetPagedList(keyword, pageIndex, pageSize)
            totalCount = _apartmentService.GetTotalCount()

            dgvApartments.DataSource = list

            ' Cập nhật label phân trang
            Dim startRecord = ((pageIndex - 1) * pageSize) + 1
            Dim endRecord = Math.Min(startRecord + pageSize - 1, totalCount)
            lblPagingInfo.Text = $"Hiển thị {startRecord}-{endRecord} / Tổng {totalCount} bản ghi"

            ' Cập nhật trạng thái nút
            btnPrev.Enabled = pageIndex > 1
            btnNext.Enabled = (pageIndex * pageSize) < totalCount

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

End Class
