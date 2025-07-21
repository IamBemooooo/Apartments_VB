Public Class ComboItem
    Public Property Text As String
    Public Property Value As Integer

    Public Sub New(text As String, value As Integer)
        Me.Text = text
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class
