Public Class ValidationResult
    Public Property Errors As New List(Of ValidationError)

    Public ReadOnly Property IsValid As Boolean
        Get
            Return Errors.Count = 0
        End Get
    End Property

    Public Sub Add(fieldName As String, errorMessage As String)
        Errors.Add(New ValidationError(fieldName, errorMessage))
    End Sub

    Public Function GetErrorByField(fieldName As String) As String
        Dim err = Errors.FirstOrDefault(Function(e) e.FieldName = fieldName)
        If err IsNot Nothing Then Return err.Message
        Return ""
    End Function
End Class
