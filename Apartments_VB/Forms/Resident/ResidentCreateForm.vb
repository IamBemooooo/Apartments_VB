Imports System.Data.SqlClient

Public Class ResidentCreateForm
    Private ReadOnly _residentService As IResidentService

    Public Sub New(residentService As IResidentService)
        InitializeComponent()
        _residentService = residentService
    End Sub

    Private Sub ResidentCreateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetErrorLabels()
        cbxGender.Items.AddRange(New Object() {"Nam", "Nữ"})
        cbxGender.SelectedIndex = 0
        dtpDateOfBirth.MaxDate = DateTime.Today
    End Sub

    Private Sub resetErrorLabels()
        lblErrorName.Text = ""
        lblErrorPhone.Text = ""
        lblErrorEmail.Text = ""
        lblErrorGender.Text = ""
        lblErrorDOB.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            resetErrorLabels()
            Dim result As New ValidationResult()

            Dim fullName = txtName.Text.Trim()
            Dim phone = txtPhone.Text.Trim()
            Dim email = txtEmail.Text.Trim()
            Dim dateOfBirth = dtpDateOfBirth.Value.Date
            Dim gender = Convert.ToBoolean(If(cbxGender.SelectedIndex = 0, 1, 0)) ' 1 = Nam, 0 = Nữ

            ' Áp dụng kiểm tra mới
            ValidationHelper.ValidateTextField(result, txtName, "họ và tên")
            ValidationHelper.ValidatePhoneField(result, txtPhone, "số điện thoại")
            ValidationHelper.ValidateEmailField(result, txtEmail, "email")
            ValidationHelper.ValidateComboBox(result, cbxGender, "giới tính")
            ValidationHelper.ValidateDateOfBirth(result, dtpDateOfBirth, "ngày sinh", True)

            ' Hiển thị lỗi
            lblErrorName.Text = result.GetErrorByField(txtName.Name)
            lblErrorPhone.Text = result.GetErrorByField(txtPhone.Name)
            lblErrorEmail.Text = result.GetErrorByField(txtEmail.Name)
            lblErrorGender.Text = result.GetErrorByField(cbxGender.Name)
            lblErrorDOB.Text = result.GetErrorByField(dtpDateOfBirth.Name)

            If Not result.IsValid Then Return

            Dim dto As New ResidentCreateDto With {
                .FullName = fullName,
                .Phone = phone,
                .Email = email,
                .DateOfBirth = dateOfBirth,
                .Gender = gender
            }

            Dim createdResident = _residentService.Add(dto)

            MessageBox.Show(
                $"Thêm cư dân thành công!" & Environment.NewLine &
                $"Họ tên: {createdResident.FullName}" & Environment.NewLine &
                $"Mã ID: {createdResident.Id}",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information
            )

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm cư dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
