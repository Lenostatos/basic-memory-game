Namespace game_logic

    ''' <summary>
    ''' Models a set of memory tiles that can be used for a game.
    ''' It contains a set of same-sized groups of memory tiles where
    ''' within each group all tiles match each other but
    ''' between them no two groups share a common item.
    ''' Also no two tiles within the whole set are equal.
    ''' </summary>
    Public Class tile_game_set

        Implements Collections.Generic.ICollection(Of matching_tiles)

        Public Const EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_ITEM As String =
            "Attempted to add a set of matching tiles with an item that was already included in the set."

        Public Const EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_TILE As String =
            "Attempted to add a tile that was already included in the set."

        Private _matching_tiles As HashSet(Of matching_tiles)
        Private _size_of_matching_tile_groups As Integer

        Public Sub New(size_of_matching_tile_groups)
            _matching_tiles = New HashSet(Of matching_tiles)
            _size_of_matching_tile_groups = size_of_matching_tile_groups
        End Sub

        ''' <summary>
        ''' Returns all tiles contained within the set.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property tiles As IEnumerable(Of tile)
            Get

                Dim tile_list = New List(Of tile)(Count * size_of_matching_tile_groups)

                For Each matching_t As matching_tiles In _matching_tiles
                    tile_list.Add(matching_t.tiles)
                Next

                Return tile_list

            End Get
        End Property

        ''' <summary>
        ''' Returns the number of tiles that match each other within the set.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property size_of_matching_tile_groups As Integer
            Get
                Return _size_of_matching_tile_groups
            End Get
        End Property

        Public ReadOnly Property Count As Integer Implements ICollection(Of matching_tiles).Count
            Get
                Return _matching_tiles.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of matching_tiles).IsReadOnly
            Get
                Return False
            End Get
        End Property

        Public Sub Add(item As matching_tiles) Implements ICollection(Of matching_tiles).Add

            If item Is Nothing Then Throw New ArgumentNullException()
            If item.Count = 0 Then Throw New ArgumentException()

            For Each t As tile In item.tiles
                If tiles.Contains(t) Then Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_TILE)
            Next

            If Not _matching_tiles.Add(item) Then Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_ITEM)

        End Sub

        Public Sub Clear() Implements ICollection(Of matching_tiles).Clear
            _matching_tiles.Clear()
        End Sub

        Public Sub CopyTo(array() As matching_tiles, arrayIndex As Integer) Implements ICollection(Of matching_tiles).CopyTo
            _matching_tiles.CopyTo(array, arrayIndex)
        End Sub

        Public Function Contains(item As matching_tiles) As Boolean Implements ICollection(Of matching_tiles).Contains
            Return _matching_tiles.Contains(item)
        End Function

        Public Function Remove(item As matching_tiles) As Boolean Implements ICollection(Of matching_tiles).Remove
            Return _matching_tiles.Remove(item)
        End Function

        Public Function GetEnumerator() As IEnumerator(Of matching_tiles) Implements IEnumerable(Of matching_tiles).GetEnumerator
            Return _matching_tiles.GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _matching_tiles.GetEnumerator()
        End Function

        'Inherits HashSet(Of tile_tuple)

        '''' <summary>
        '''' Returns the total number of tiles in the collection.
        '''' </summary>
        '''' <returns></returns>
        'Public ReadOnly Property count_of_single_tiles As Integer
        '    Get
        '        Return First.Count * Count
        '    End Get
        'End Property

        '''' <summary>
        '''' Returns all tiles in the collection as a list or
        '''' Nothing if there are no tiles.
        '''' </summary>
        '''' <returns></returns>
        'Public ReadOnly Property tiles As List(Of tile)
        '    Get

        '        If Count = 0 Then
        '            Return Nothing
        '        Else

        '            Dim return_tiles As New List(Of tile)(count_of_single_tiles)

        '            For Each tile_t As tile_tuple In Me
        '                return_tiles.AddRange(tile_t)
        '            Next

        '            Return return_tiles
        '        End If

        '    End Get
        'End Property

        'Public Sub New(tile_sets As IEnumerable(Of tile_tuple))
        '    MyBase.New(tile_sets, New filter_for_set_of_tile_tuples())
        'End Sub

        '''' <summary>
        '''' Serves as a filter for a set that only takes in
        '''' sets of matching tiles which contain the same amount
        '''' of tiles and do not show the same item.
        '''' </summary>
        '''' <see cref="filter_for_set_of_tile_tuples.Equals(tile_tuple, tile_tuple)"/>
        'Private Class filter_for_set_of_tile_tuples

        '    Implements IEqualityComparer(Of tile_tuple)

        '    Private _equal_by_number As New equality_comparer_of_matching_tiles_by_count_of_tiles()
        '    Private _equal_by_item As New equality_comparer_of_matching_tiles_by_tile_item()

        '    ''' <summary>
        '    ''' Sets of matching tiles are equal, i.e. they are not
        '    ''' added to a set, if their tiles show the same item or
        '    ''' they contain a different number of tiles.
        '    ''' </summary>
        '    ''' <param name="x"></param>
        '    ''' <param name="y"></param>
        '    ''' <returns></returns>
        '    Public Shadows Function Equals(x As tile_tuple, y As tile_tuple) As Boolean Implements IEqualityComparer(Of tile_tuple).Equals
        '        If x Is Nothing OrElse y Is Nothing Then
        '            Throw New ArgumentNullException()
        '        Else
        '            Return _equal_by_item.Equals(x, y) OrElse Not _equal_by_number.Equals(x, y)
        '        End If
        '    End Function

        '    Public Shadows Function GetHashCode(obj As tile_tuple) As Integer Implements IEqualityComparer(Of tile_tuple).GetHashCode
        '        Throw New NotImplementedException()
        '    End Function

        'End Class

    End Class

End Namespace
