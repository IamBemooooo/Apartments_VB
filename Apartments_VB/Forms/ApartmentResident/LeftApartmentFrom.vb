Public Class LeftApartmentFrom
    Private ReadOnly _residentId As Integer
    Private ReadOnly _apartmentResidentService As IApartmentResidentService

    Sub New(residentId As Integer, apartmentResidentService As IApartmentResidentService)
        InitializeComponent()
        _residentId = residentId
        _apartmentResidentService = apartmentResidentService
    End Sub

    Private Sub LeftApartmentFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEndDate.Text = DateTime.Today
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        Try
            Dim endDate As DateTime = txtEndDate.Text
            Dim note As String = rtxtNote.Text.Trim()

            ' Gọi hàm service để cập nhật
            _apartmentResidentService.MarkResidentAsMovedOut(_residentId, endDate, note)

            MessageBox.Show("Đã đánh dấu cư dân là 'đã rời đi'.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi đánh dấu cư dân rời đi: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class