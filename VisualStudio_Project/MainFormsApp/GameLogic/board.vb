Namespace game_logic

    ''' <summary>
    ''' Models a board of memory tiles as a simple list.
    ''' Every tile on the board has the same number
    ''' of matching tiles which is at least one.
    ''' There are also at least two different items
    ''' on the tiles.
    ''' </summary>
    Public Class board

        Implements IReadOnlyList(Of tile)

        Public Const EXCEPTION_MESSAGE_NOT_ENOUGH_MATCHING_TILES As String =
            "Attempted to use sets of matching tiles with less than two tiles each."
        Public Const EXCEPTION_MESSAGE_NOT_ENOUGH_DIFFERENT_ITEMS As String =
            "Attempted to use sets of matching tiles with overall less than two different items."

        Private _mapping As List(Of tile)

        ''' <summary>
        ''' Places all the tiles on the board.
        ''' </summary>
        ''' <param name="tiles"></param>
        Public Sub New(tiles As matching_tiles_set)

            If tiles Is Nothing Then Throw New ArgumentNullException()

            If tiles.Count < 2 Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_NOT_ENOUGH_DIFFERENT_ITEMS)
            End If

            If tiles.size_of_matching_tile_groups < 2 Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_NOT_ENOUGH_MATCHING_TILES)
            End If

            _mapping = tiles.tiles

        End Sub

        ''' <summary>
        ''' Returns all tiles that are left on the board.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property tiles As IEnumerable(Of tile)
            Get

                Return _mapping.Where(Function(t As tile) t IsNot Nothing)

            End Get
        End Property

        ''' <summary>
        ''' Returns all positions on the board, i.e. a tile
        ''' or Nothing for each position.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property positions As List(Of tile)
            Get
                Return _mapping
            End Get
        End Property

        Default Public ReadOnly Property Item(index As Integer) As tile Implements IReadOnlyList(Of tile).Item
            Get
                Return _mapping(index)
            End Get
        End Property

        ''' <summary>
        ''' Returns the number of positions on the board.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Count As Integer Implements IReadOnlyCollection(Of tile).Count
            Get
                Return _mapping.Count
            End Get
        End Property

        ''' <summary>
        ''' Shuffles the tiles on the board.
        ''' Empty positions are left as is.
        ''' </summary>
        Public Sub shuffle_tiles()

            Dim shuffled_tiles As List(Of tile) =
                utility.functions.shuffle_collection(tiles)

            Dim index_shuffled As Integer = 0
            For Each t As tile In _mapping
                If t IsNot Nothing Then
                    t = shuffled_tiles(index_shuffled)
                    index_shuffled = index_shuffled + 1
                End If
            Next

        End Sub

        ''' <summary>
        ''' Shuffles the positions on the board.
        ''' </summary>
        Public Sub shuffle_positions()

            _mapping = utility.functions.shuffle_collection(Of tile)(_mapping)

        End Sub

        ''' <summary>
        ''' Covers all tiles on the board.
        ''' </summary>
        Public Sub cover_tiles()
            For Each t As tile In tiles
                t.cover()
            Next
        End Sub

        ''' <summary>
        ''' Remove tiles from the board at the zero-based
        ''' <paramref name="positions"/> by setting them to Nothing.
        ''' </summary>
        ''' <param name="positions"></param>
        ''' <returns>The removed tiles.</returns>
        Public Function remove_matching_tiles(positions As IEnumerable(Of Integer)) As matching_tiles

            Dim removal_candidates As New List(Of tile)(positions.Count)

            ' Collect all the candidates for removal
            For Each index As Integer In positions
                removal_candidates.Add(_mapping(index))
            Next

            ' Try to put them into a set of matching tiles
            Dim to_be_removed As matching_tiles
            Try
                to_be_removed = New matching_tiles(removal_candidates)
            Catch ex As Exception
                ' If doesn't work rethrow the risen exception.
                Throw
            End Try

            ' If it worked, set the removed tiles on the board
            ' to Nothing.
            For Each index As Integer In positions
                _mapping(index) = Nothing
            Next

            Return to_be_removed

        End Function

        Public Function GetEnumerator() As IEnumerator(Of tile) Implements IEnumerable(Of tile).GetEnumerator
            Return _mapping.GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _mapping.GetEnumerator()
        End Function
    End Class

End Namespace
