Imports System.Runtime.Serialization

Namespace game_logic

    ''' <summary>
    ''' Models a group of matching tiles as a set that can only contain tiles with matching items.
    ''' </summary>
    Public Class matching_tiles

        Inherits HashSet(Of tile)

        Implements IEquatable(Of matching_tiles)

        Public Sub New()
            MyBase.New(New set_filter_for_matching_individual_tiles())
        End Sub

        Public Sub New(tiles As IEnumerable(Of tile))

            MyBase.New(tiles, New set_filter_for_matching_individual_tiles())

            If tiles Is Nothing Then Throw New ArgumentNullException()
            For Each t As tile In tiles
                If t Is Nothing Then Throw New ArgumentNullException()
            Next

        End Sub

        ''' <summary>
        ''' Returns the item shared by all tiles of the group or Nothing if the group is empty.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property undercover_item As i_tile_item
            Get
                If Count = 0 Then
                    Return Nothing
                Else
                    Return First().undercover_item
                End If
            End Get
        End Property

        Public Function undercover_matches(other As matching_tiles) As Boolean
            If other Is Nothing Then Throw New ArgumentNullException()
            Return undercover_item.matches(other.undercover_item)
        End Function

        Public Shadows Function Equals(other As matching_tiles) As Boolean Implements IEquatable(Of matching_tiles).Equals
            If other Is Nothing Then
                Return False
            Else
                Return undercover_matches(other)
            End If
        End Function

        ''' <summary>
        ''' An equality comparer that makes tiles that do NOT match in their items,
        ''' have the same id or are nothing appear equal.
        ''' Intended for sets that should only contain individual matching
        ''' tiles which are also not nothing.
        ''' </summary>
        ''' <remarks>Does NOT give a meaningful hash code!</remarks>
        Private Class set_filter_for_matching_individual_tiles

            Implements IEqualityComparer(Of tile)

            Public Shadows Function Equals(x As tile, y As tile) As Boolean Implements IEqualityComparer(Of tile).Equals
                If x Is Nothing OrElse y Is Nothing Then
                    Return True
                Else
                    Return x.Equals(y) OrElse Not x.undercover_matches(y)
                End If
            End Function

            Public Shadows Function GetHashCode(obj As tile) As Integer Implements IEqualityComparer(Of tile).GetHashCode
                Return 0
            End Function

        End Class

    End Class

End Namespace
