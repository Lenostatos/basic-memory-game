Namespace tile_database.dto

    Public Class File_Info

        Implements IEquatable(Of File_Info)

        Public Property id As Integer
        Public Property path As String
        Public Property id_Item As Integer
        Public Property id_File_Type As tile_database.file_type

        Private Function is_member_wise_equal_to(other As File_Info) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return id = other.id AndAlso
                path = other.path AndAlso
                id_Item = other.id_Item AndAlso
                id_File_Type = other.id_File_Type
        End Function

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is File_Info Then
                Return is_member_wise_equal_to(other)
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As File_Info) As Boolean Implements IEquatable(Of File_Info).Equals
            Return other IsNot Nothing AndAlso is_member_wise_equal_to(other)
        End Function

    End Class

End Namespace
