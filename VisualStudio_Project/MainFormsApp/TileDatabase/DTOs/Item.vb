Namespace tile_database.DTOs

    Public Class Item

        Implements IEquatable(Of Item)

        Public Property id As Integer
        Public Property name As String

        Private Function is_member_wise_equal_to(other As Item) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return id = other.id AndAlso name = other.name
        End Function

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is Item Then
                Return is_member_wise_equal_to(other)
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As Item) As Boolean Implements IEquatable(Of Item).Equals
            Return other IsNot Nothing AndAlso is_member_wise_equal_to(other)
        End Function
    End Class

End Namespace
