Namespace tile_database.DTOs

    Public Class Representation_Count

        Implements IEquatable(Of Representation_Count)

        Public Property id_item As Integer
        Public Property count As Integer

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is Representation_Count Then
                Return id_item = other.id_item AndAlso count = other.count
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As Representation_Count) As Boolean Implements IEquatable(Of Representation_Count).Equals
            Return other IsNot Nothing AndAlso id_item = other.id_item AndAlso count = other.count
        End Function

    End Class

End Namespace
