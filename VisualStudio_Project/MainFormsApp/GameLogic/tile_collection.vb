Namespace game_logic

    ''' <summary>
    ''' Models a set of same-sized groups of memory tiles where
    ''' within each group all tiles match with each other.
    ''' </summary>
    Public Class tile_collection

        Inherits HashSet(Of tile_tuple)

        ''' <summary>
        ''' Returns the total number of tiles in the collection.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property count_of_single_tiles As Integer
            Get
                Return First.Count * Count
            End Get
        End Property

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

                    Dim return_tiles As New List(Of tile)(count_of_single_tiles)

                    For Each tile_set As tile_tuple In Me
                        For Each t As tile In tile_set
                            return_tiles.Add(t)
                        Next
                    Next

                    Return return_tiles
                End If

            End Get
        End Property

        Public Sub New(tile_sets As IEnumerable(Of tile_tuple))
            MyBase.New(tile_sets, New filter_for_set_of_tile_tuples())
        End Sub

        ''' <summary>
        ''' Serves as a filter for a set that only takes in
        ''' sets of matching tiles which contain the same amount
        ''' of tiles and do not show the same item.
        ''' </summary>
        ''' <see cref="filter_for_set_of_tile_tuples.Equals(tile_tuple, tile_tuple)"/>
        Private Class filter_for_set_of_tile_tuples

            Implements IEqualityComparer(Of tile_tuple)

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
            Public Shadows Function Equals(x As tile_tuple, y As tile_tuple) As Boolean Implements IEqualityComparer(Of tile_tuple).Equals
                If x Is Nothing OrElse y Is Nothing Then
                    Throw New ArgumentNullException()
                Else
                    Return _equal_by_item.Equals(x, y) OrElse Not _equal_by_number.Equals(x, y)
                End If
            End Function

            Public Shadows Function GetHashCode(obj As tile_tuple) As Integer Implements IEqualityComparer(Of tile_tuple).GetHashCode
                Throw New NotImplementedException()
            End Function

        End Class

    End Class

End Namespace
