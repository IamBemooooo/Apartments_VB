Public Class SqlQueries
    Public Class [User]
        Public Shared ReadOnly LoginQuery As String =
            "SELECT * FROM User WHERE Username = ? AND PasswordHash = ? AND IsActive = 1"
    End Class

    Public Class Apartment
        Public Shared ReadOnly GetPagedList As String =
            "SELECT a.*, t.Name AS ApartmentTypeName " &
                      "FROM Apartment a " &
                      "JOIN ApartmentType t ON a.ApartmentTypeId = t.Id " &
                      "ORDER BY a.Id LIMIT ? , ?"

        Public Shared ReadOnly GetTotalCount As String =
            "SELECT COUNT(*) FROM Apartment"

        Public Shared ReadOnly GetById As String =
            "SELECT * FROM Apartment WHERE Id = ?"

        Public Shared ReadOnly Add As String =
            "INSERT INTO Apartment (ApartmentTypeId, Name, Address, FloorCount, CreatedDate, Price) " &
            "VALUES (?, ?, ?, ?, ?, ?)"

        Public Shared ReadOnly Update As String =
            "UPDATE Apartment SET " &
            "ApartmentTypeId = ?, Name = ?, Address = ?, " &
            "FloorCount = ?, CreatedDate = ?, Price = ? " &
            "WHERE Id = ?"

        Public Shared ReadOnly Delete As String =
            "DELETE FROM Apartment WHERE Id = ?"
    End Class
End Class