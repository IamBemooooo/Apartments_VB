Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class ValidationHelper

    Public Shared Sub ValidateTextField(
        result As ValidationResult,
        textBox As TextBox,
        fieldLabel As String,
        Optional required As Boolean = True,
        Optional minLength As Integer = -1,
        Optional maxLength As Integer = -1)

        Dim text = textBox.Text.Trim()
        Dim fieldName = textBox.Name

        If required AndAlso String.IsNullOrEmpty(text) Then
            result.Add(fieldName, $"Vui lòng nhập {fieldLabel}.")
            Exit Sub
        End If

        If minLength >= 0 AndAlso text.Length < minLength Then
            result.Add(fieldName, $"{fieldLabel} phải có ít nhất {minLength} ký tự.")
        End If

        If maxLength >= 0 AndAlso text.Length > maxLength Then
            result.Add(fieldName, $"{fieldLabel} không được vượt quá {maxLength} ký tự.")
        End If
    End Sub

    Public Shared Sub ValidateIntegerField(
        result As ValidationResult,
        textBox As TextBox,
        fieldLabel As String,
        Optional required As Boolean = True,
        Optional minValue As Integer = Integer.MinValue,
        Optional maxValue As Integer = Integer.MaxValue)

        Dim text = textBox.Text.Trim()
        Dim fieldName = textBox.Name

        If required AndAlso String.IsNullOrEmpty(text) Then
            result.Add(fieldName, $"Vui lòng nhập {fieldLabel}.")
            Exit Sub
        End If

        Dim value As Integer
        If Not Integer.TryParse(text, value) Then
            result.Add(fieldName, $"{fieldLabel} phải là số nguyên.")
            Exit Sub
        End If

        If value < minValue Then
            result.Add(fieldName, $"{fieldLabel} phải ≥ {minValue}.")
        End If

        If value > maxValue Then
            result.Add(fieldName, $"{fieldLabel} phải ≤ {maxValue}.")
        End If
    End Sub

    Public Shared Sub ValidateDecimalField(
        result As ValidationResult,
        textBox As TextBox,
        fieldLabel As String,
        Optional required As Boolean = True,
        Optional minValue As Decimal = Decimal.MinValue,
        Optional maxValue As Decimal = Decimal.MaxValue)

        Dim text = textBox.Text.Trim()
        Dim fieldName = textBox.Name

        If required AndAlso String.IsNullOrEmpty(text) Then
            result.Add(fieldName, $"Vui lòng nhập {fieldLabel}.")
            Exit Sub
        End If

        Dim value As Decimal
        If Not Decimal.TryParse(text, value) Then
            result.Add(fieldName, $"{fieldLabel} phải là số.")
            Exit Sub
        End If

        If value < minValue Then
            result.Add(fieldName, $"{fieldLabel} phải ≥ {minValue}.")
        End If

        If value > maxValue Then
            result.Add(fieldName, $"{fieldLabel} phải ≤ {maxValue}.")
        End If
    End Sub

    Public Shared Sub ValidateEmailField(
        result As ValidationResult,
        textBox As TextBox,
        fieldLabel As String,
        Optional required As Boolean = True)

        Dim email = textBox.Text.Trim()
        Dim fieldName = textBox.Name

        If required AndAlso String.IsNullOrEmpty(email) Then
            result.Add(fieldName, $"Vui lòng nhập {fieldLabel}.")
            Exit Sub
        End If

        Dim pattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        If Not Regex.IsMatch(email, pattern) Then
            result.Add(fieldName, $"{fieldLabel} không đúng định dạng email.")
        End If
    End Sub

    Public Shared Sub ValidateComboBox(
        result As ValidationResult,
        comboBox As ComboBox,
        fieldLabel As String)

        Dim fieldName = comboBox.Name

        If comboBox.SelectedIndex < 0 Then
            result.Add(fieldName, $"Vui lòng chọn {fieldLabel}.")
        End If
    End Sub

    Public Shared Sub ValidateRichTextField(
    result As ValidationResult,
    richTextBox As RichTextBox,
    fieldLabel As String,
    Optional required As Boolean = True,
    Optional minLength As Integer = -1,
    Optional maxLength As Integer = -1)

        Dim text = richTextBox.Text.Trim()
        Dim fieldName = richTextBox.Name

        If required AndAlso String.IsNullOrEmpty(text) Then
            result.Add(fieldName, $"Vui lòng nhập {fieldLabel}.")
            Exit Sub
        End If

        If minLength >= 0 AndAlso text.Length < minLength Then
            result.Add(fieldName, $"{fieldLabel} phải có ít nhất {minLength} ký tự.")
        End If

        If maxLength >= 0 AndAlso text.Length > maxLength Then
            result.Add(fieldName, $"{fieldLabel} không được vượt quá {maxLength} ký tự.")
        End If
    End Sub

    Public Shared Sub ValidatePhoneField(
        result As ValidationResult,
        textBox As TextBox,
        fieldLabel As String,
        Optional required As Boolean = True)

        Dim phone = textBox.Text.Trim()
        Dim fieldName = textBox.Name

        If required AndAlso String.IsNullOrEmpty(phone) Then
            result.Add(fieldName, $"Vui lòng nhập {fieldLabel}.")
            Exit Sub
        End If

        ' Kiểm tra chỉ chứa số, bắt đầu bằng 0 và có 10-11 chữ số
        Dim pattern As String = "^0\d{9,10}$"
        If Not Regex.IsMatch(phone, pattern) Then
            result.Add(fieldName, $"{fieldLabel} phải bắt đầu bằng 0, gồm 10–11 chữ số.")
        End If
    End Sub

    Public Shared Sub ValidateDateOfBirth(
        result As ValidationResult,
        datePicker As DateTimePicker,
        fieldLabel As String,
        Optional required As Boolean = True,
        Optional minAge As Integer = 0)

        Dim fieldName = datePicker.Name
        Dim selectedDate = datePicker.Value.Date
        Dim today = DateTime.Today

        If required AndAlso selectedDate > today Then
            result.Add(fieldName, $"{fieldLabel} không được lớn hơn ngày hiện tại.")
            Exit Sub
        End If

        If minAge > 0 Then
            Dim age = today.Year - selectedDate.Year
            If selectedDate > today.AddYears(-age) Then age -= 1

            If age < minAge Then
                result.Add(fieldName, $"{fieldLabel} phải từ {minAge} tuổi trở lên.")
            End If
        End If
    End Sub

End Class
