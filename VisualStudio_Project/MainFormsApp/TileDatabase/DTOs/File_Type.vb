Namespace tile_database.DTOs

    Public Class File_Type

        Implements IEquatable(Of File_Type)

        Public Property id As Integer
        Public Property interpretation As String

        Private Function is_member_wise_equal_to(other As File_Type) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return id = other.id AndAlso interpretation = other.interpretation
        End Function

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is File_Type Then
                Return is_member_wise_equal_to(other)
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As File_Type) As Boolean Implements IEquatable(Of File_Type).Equals
            Return other IsNot Nothing AndAlso is_member_wise_equal_to(other)
        End Function
    End Class

End Namespace
