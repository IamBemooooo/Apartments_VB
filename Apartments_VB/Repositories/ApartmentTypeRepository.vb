Imports System.Configuration
Imports System.Data.Odbc

Public Class ApartmentTypeRepository
    Implements IApartmentTypeRepository

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    ''' <summary>
    ''' Lấy toàn bộ danh sách loại căn hộ từ bảng ApartmentType
    ''' </summary>
    Public Function GetAll() As List(Of ApartmentTypeDto) Implements IApartmentTypeRepository.GetAll
        Dim result As New List(Of ApartmentTypeDto)

        Using conn As New OdbcConnection(_connectionString)
            conn.Open()

            Dim query As String = "SELECT Id, Name FROM ApartmentType"

            Using cmd As New OdbcCommand(query, conn)
                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim apartmentType As New ApartmentTypeDto With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .Name = reader("Name").ToString()
                        }
                        result.Add(apartmentType)
                    End While
                End Using
            End Using
        End Using

        Return result
    End Function

End Class
