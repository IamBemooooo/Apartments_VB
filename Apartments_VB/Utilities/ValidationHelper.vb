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

End Class
