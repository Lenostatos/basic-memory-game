Namespace tile_database.DTOs

    Public Class File_Type

        Implements IEquatable(Of File_Type)

        Public Property id As Integer
        Public Property interpretation As String

        Public Overrides Function Equals(other As Object) As Boolean

            If other Is Nothing Then
                Return False
            ElseIf TypeOf other Is File_Type Then
                Return id = other.id
            Else
                Return MyBase.Equals(other)
            End If

        End Function

        Public Overloads Function Equals(other As File_Type) As Boolean Implements IEquatable(Of File_Type).Equals
            Return other IsNot Nothing AndAlso id = other.id
        End Function
    End Class

End Namespace
