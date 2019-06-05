Namespace game_logic

    ''' <summary>
    ''' Models a set of same-sized groups of matching memory tiles.
    ''' Within each group all tiles match each other but
    ''' in between them no two groups share a common item.
    ''' Also no two tiles within the whole set are equal.
    ''' </summary>
    Public Class matching_tiles_set

        Implements Collections.Generic.ICollection(Of matching_tiles)

        Public Const EXCEPTION_MESSAGE_ADDED_WRONG_NUMBER_OF_MATCHING_TILES As String =
            "Attempted to add a set of matching tiles of the wrong size."
        Public Const EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_ITEM As String =
            "Attempted to add a set of matching tiles with an item that was already included in the set."
        Public Const EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_TILE As String =
            "Attempted to add a tile that was already included in the set."

        Private _matching_tiles As HashSet(Of matching_tiles)
        Private _size_of_matching_tile_groups As Integer

        Public Sub New()
            _matching_tiles = New HashSet(Of matching_tiles)
            _size_of_matching_tile_groups = 0
        End Sub

        ''' <summary>
        ''' Returns all tiles contained within the set or
        ''' nothing if there are no tiles.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property tiles As IEnumerable(Of tile)
            Get

                If Count = 0 Then

                    Return Nothing

                Else

                    Dim tile_list = New List(Of tile)(Count * size_of_matching_tile_groups)

                    For Each matching_t As matching_tiles In _matching_tiles
                        tile_list.AddRange(matching_t.tiles)
                    Next

                    Return tile_list

                End If

            End Get
        End Property

        ''' <summary>
        ''' Returns the number of tiles that match each other within the set.
        ''' Returns 0 if there are no tiles.
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

        ''' <summary>
        ''' Returns the total number of tiles in the set.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property count_of_single_tiles As Integer
            Get
                Return Count * size_of_matching_tile_groups
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of matching_tiles).IsReadOnly
            Get
                Return False
            End Get
        End Property

        ''' <summary>
        ''' Adds a set of matching tiles to the set.
        ''' </summary>
        ''' <param name="new_tiles"></param>
        ''' <exception cref="ArgumentException">Thrown if there is not the same number of
        ''' <paramref name="new_tiles"/> as size_of_matching_tile_groups.</exception>
        Public Sub Add(new_tiles As matching_tiles) Implements ICollection(Of matching_tiles).Add

            If new_tiles Is Nothing Then Throw New ArgumentNullException()
            If new_tiles.Count = 0 Then Exit Sub

            If Count = 0 Then

                _size_of_matching_tile_groups = new_tiles.Count

            Else

                If new_tiles.Count <> size_of_matching_tile_groups Then
                    Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_WRONG_NUMBER_OF_MATCHING_TILES)
                End If

                If _matching_tiles.Contains(new_tiles) Then
                    Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_ITEM)
                End If

                For Each t As tile In new_tiles.tiles
                    If tiles.Contains(t) Then
                        Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_TILE)
                    End If
                Next

            End If

            _matching_tiles.Add(new_tiles)

        End Sub

        Public Sub Clear() Implements ICollection(Of matching_tiles).Clear
            _matching_tiles.Clear()
            _size_of_matching_tile_groups = 0
        End Sub

        Public Sub CopyTo(array() As matching_tiles, arrayIndex As Integer) Implements ICollection(Of matching_tiles).CopyTo
            _matching_tiles.CopyTo(array, arrayIndex)
        End Sub

        Public Function Contains(item As matching_tiles) As Boolean Implements ICollection(Of matching_tiles).Contains
            Return _matching_tiles.Contains(item)
        End Function

        Public Function Remove(item As matching_tiles) As Boolean Implements ICollection(Of matching_tiles).Remove

            Dim remove_result As Boolean = _matching_tiles.Remove(item)

            If Count = 0 Then
                _size_of_matching_tile_groups = 0
            End If

            Return remove_result

        End Function

        Public Function GetEnumerator() As IEnumerator(Of matching_tiles) Implements IEnumerable(Of matching_tiles).GetEnumerator
            Return _matching_tiles.GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _matching_tiles.GetEnumerator()
        End Function

    End Class

End Namespace
