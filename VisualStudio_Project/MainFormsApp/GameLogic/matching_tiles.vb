Namespace game_logic

    ''' <summary>
    ''' Models a group of matching tiles.
    ''' </summary>
    Public Class matching_tiles

        Inherits HashSet(Of tile)

        Public Sub New(tiles As IEnumerable(Of tile))
            MyBase.New(tiles, New equality_comparer_for_matching_tiles())
            If tiles Is Nothing Then Throw New ArgumentNullException()
        End Sub

        Protected Function undercover_matches(other As matching_tiles) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return First.undercover_matches(other.First)
        End Function

        ''' <summary>
        ''' Makes tiles that do NOT match appear equal.
        ''' </summary>
        Private Class equality_comparer_for_matching_tiles

            Implements IEqualityComparer(Of tile)

            Public Shadows Function Equals(x As tile, y As tile) As Boolean Implements IEqualityComparer(Of tile).Equals
                Return Not x.undercover_matches(y)
            End Function

            Public Shadows Function GetHashCode(obj As tile) As Integer Implements IEqualityComparer(Of tile).GetHashCode
                Return obj.item.id
            End Function

        End Class

    End Class

End Namespace
