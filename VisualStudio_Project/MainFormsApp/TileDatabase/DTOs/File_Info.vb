Namespace tile_database.DTOs

    Public Class File_Info

        Implements IEquatable(Of File_Info)

        Public Property id As Integer
        Public Property path As String
        Public Property id_Item As Integer
        Public Property id_File_Type As tile_database.file_type

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is File_Info Then
                Return id = other.id
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As File_Info) As Boolean Implements IEquatable(Of File_Info).Equals
            Return other IsNot Nothing AndAlso id = other.id
        End Function

    End Class

End Namespace
