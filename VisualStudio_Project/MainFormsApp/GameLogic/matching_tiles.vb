Namespace game_logic

    ''' <summary>
    ''' Models a set of tiles that all match with each other.
    ''' </summary>
    Public Class matching_tiles

        Implements ICollection(Of tile)

        Public Const EXCEPTION_MESSAGE_ADDED_ALREADY_EXISTING_TILE As String =
            "Attempted to add an already existing tile to a set of matching tiles."
        Public Const EXCEPTION_MESSAGE_ADDED_NON_MATCHING_TILE As String =
            "Attempted to add a non matching tile to a set of matching tiles."

        Private Property _tiles As HashSet(Of tile)

        Public Sub New()
            _tiles = New HashSet(Of tile)
        End Sub

        Public Sub New(tiles As IEnumerable(Of tile))

            If tiles Is Nothing Then Throw New ArgumentNullException()

            _tiles = New HashSet(Of tile)

            Dim common_item As i_tile_item = tiles.First().undercover_item

            For Each t As tile In tiles

                If Not common_item.Equals(t.undercover_item) Then
                    Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_NON_MATCHING_TILE)
                ElseIf Not _tiles.Add(t) Then
                    Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_ALREADY_EXISTING_TILE)
                End If

            Next

        End Sub

        ''' <summary>
        ''' Returns the item shared by all tiles of the group or Nothing if the group is empty.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property undercover_common_item As tile_item
            Get
                If Count = 0 Then
                    Return Nothing
                Else
                    Return _tiles.First().undercover_item
                End If
            End Get
        End Property

        Public Function undercover_matches_common_item(other As matching_tiles) As Boolean
            Return undercover_common_item.matches(other.undercover_common_item)
        End Function

        Public ReadOnly Property Count As Integer Implements ICollection(Of tile).Count
            Get
                Return _tiles.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of tile).IsReadOnly
            Get
                Return False
            End Get
        End Property

        Public Sub Add(t As tile) Implements ICollection(Of tile).Add

            If t Is Nothing Then Throw New ArgumentNullException()

            If _tiles.Count = 0 Then
                _tiles.Add(t)
            ElseIf Not _tiles.First().undercover_matches(t) Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_NON_MATCHING_TILE)
            ElseIf Not _tiles.Add(t) Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_ADDED_ALREADY_EXISTING_TILE)
            End If

        End Sub

        Public Sub Clear() Implements ICollection(Of tile).Clear
            _tiles.Clear()
        End Sub

        Public Sub CopyTo(array() As tile, arrayIndex As Integer) Implements ICollection(Of tile).CopyTo
            _tiles.CopyTo(array, arrayIndex)
        End Sub

        Public Function Contains(item As tile) As Boolean Implements ICollection(Of tile).Contains
            Return _tiles.Contains(item)
        End Function

        Public Function Remove(item As tile) As Boolean Implements ICollection(Of tile).Remove
            Return _tiles.Remove(item)
        End Function

        Public Function GetEnumerator() As IEnumerator(Of tile) Implements IEnumerable(Of tile).GetEnumerator
            Return _tiles.GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _tiles.GetEnumerator()
        End Function

    End Class

End Namespace
