Public Class ValidationError
    Public Property FieldName As String
    Public Property Message As String

    Public Sub New(fieldName As String, message As String)
        Me.FieldName = fieldName
        Me.Message = message
    End Sub
End Class
