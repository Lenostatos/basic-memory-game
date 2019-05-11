Namespace game_logic

    ''' <summary>
    ''' Models a collection of memory tiles within which every
    ''' tile has the same number of matching "partner" tiles.
    ''' </summary>
    Public Class tile_collection

        Inherits HashSet(Of matching_tiles)

        ''' <summary>
        ''' Returns all tiles in the collection as a list or
        ''' Nothing if there are no tiles.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property tiles As List(Of tile)
            Get

                If Count = 0 Then
                    Return Nothing
                Else

                    Dim return_tiles As New List(Of tile)(First.tiles.Count * Count)

                    For Each tile_set As matching_tiles In Me
                        For Each t As tile In tile_set.tiles
                            return_tiles.Add(t)
                        Next
                    Next

                    Return return_tiles
                End If

            End Get
        End Property

        Public Sub New(tile_sets As IEnumerable(Of matching_tiles))
            MyBase.New(tile_sets, New filter_for_set_of_matching_tiles())
        End Sub

        ''' <summary>
        ''' Serves as a filter for a set that only takes in
        ''' sets of matching tiles which contain the same amount
        ''' of tiles and do not show the same item.
        ''' </summary>
        ''' <see cref="filter_for_set_of_matching_tiles.Equals(matching_tiles, matching_tiles)"/>
        Private Class filter_for_set_of_matching_tiles

            Implements IEqualityComparer(Of matching_tiles)

            Private _equal_by_number As New equality_comparer_of_matching_tiles_by_count_of_tiles()
            Private _equal_by_item As New equality_comparer_of_matching_tiles_by_tile_item()

            ''' <summary>
            ''' Sets of matching tiles are equal, i.e. they are not
            ''' added to a set, if their tiles show the same item or
            ''' they contain a different number of tiles.
            ''' </summary>
            ''' <param name="x"></param>
            ''' <param name="y"></param>
            ''' <returns></returns>
            Public Shadows Function Equals(x As matching_tiles, y As matching_tiles) As Boolean Implements IEqualityComparer(Of matching_tiles).Equals
                If x Is Nothing OrElse y Is Nothing Then
                    Throw New ArgumentNullException()
                Else
                    Return _equal_by_item.Equals(x, y) OrElse Not _equal_by_number.Equals(x, y)
                End If
            End Function

            Public Shadows Function GetHashCode(obj As matching_tiles) As Integer Implements IEqualityComparer(Of matching_tiles).GetHashCode
                Throw New NotImplementedException()
            End Function

        End Class

    End Class

End Namespace
