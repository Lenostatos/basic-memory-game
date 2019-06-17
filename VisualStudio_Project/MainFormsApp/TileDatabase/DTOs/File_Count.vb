Namespace tile_database.DTOs

    Public Class File_Count

        Implements IEquatable(Of File_Count)

        Public Property id_Item As Integer
        Public Property count As Integer

        Private Function is_member_wise_equal_to(other As File_Count) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return id_Item = other.id_Item AndAlso count = other.count
        End Function

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is File_Count Then
                Return is_member_wise_equal_to(other)
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As File_Count) As Boolean Implements IEquatable(Of File_Count).Equals
            Return other IsNot Nothing AndAlso is_member_wise_equal_to(other)
        End Function

    End Class

End Namespace
