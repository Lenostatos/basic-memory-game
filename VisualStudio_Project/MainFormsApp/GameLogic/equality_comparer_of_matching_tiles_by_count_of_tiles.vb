Namespace game_logic

    Public Class equality_comparer_of_matching_tiles_by_count_of_tiles

        Implements IEqualityComparer(Of matching_tiles)

        Public Shadows Function Equals(x As matching_tiles, y As matching_tiles) As Boolean Implements IEqualityComparer(Of matching_tiles).Equals
            If x Is Nothing OrElse y Is Nothing Then
                Return False
            Else
                Return GetHashCode(x).Equals(GetHashCode(y))
            End If
        End Function

        Public Shadows Function GetHashCode(obj As matching_tiles) As Integer Implements IEqualityComparer(Of matching_tiles).GetHashCode
            If obj Is Nothing Then
                Throw New ArgumentNullException()
            Else
                Return obj.Count
            End If
        End Function
    End Class

End Namespace
