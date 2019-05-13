Namespace game_logic

    Public Class game

        Private Property _the_board As board
        Private Property _players As List(Of player)
        Private Property _turner As player
        Private Property _uncovered_tiles As List(Of tile)

        ''' <summary>
        ''' Initializes the game.
        ''' Sets the starting player to the first player in <paramref name="players"/>.
        ''' </summary>
        ''' <param name="players"></param>
        ''' <param name="board_width"></param>
        ''' <param name="tile_tuples"></param>
        Public Sub New(players As List(Of player),
                       board_width As Integer,
                       tile_tuples As tile_collection)

            If players Is Nothing Then Throw New ArgumentNullException()
            If tile_tuples Is Nothing Then Throw New ArgumentNullException()

            If players.Count = 0 Then Throw New ArgumentException()
            If tile_tuples.Count < 2 Then Throw New ArgumentException()

            _the_board = New board(board_width, tile_tuples)
            _players = players
            _turner = players.First()
            _uncovered_tiles = New List(Of tile)(tile_tuples.First().Count)

        End Sub

        Public Sub uncover_at(index As Integer)

            Dim t As tile = _the_board.tile_at(index)

            t.uncover()

            Dim matches_other_uncovered_tiles As Boolean = True

            For Each uncv_t As tile In _uncovered_tiles
                If Not uncv_t.matches(t) Then
                    matches_other_uncovered_tiles = False
                    Exit For
                End If
            Next

            If matches_other_uncovered_tiles Then
                _uncovered_tiles.Add(t)
            Else
                t.cover()
            End If

            If _uncovered_tiles.Count = _the_board.tile_tuple_size Then
                ' TODO: Look for a more satisfying solution.
                _turner.find_match(New tile_tuple(_uncovered_tiles))
            End If

            switch_to_next_player()
        End Sub

        Private Sub switch_to_next_player()

            ' Cover all previously uncovered tiles.
            If _uncovered_tiles.Count > 0 Then

                For Each uncv_t In _uncovered_tiles
                    uncv_t.cover()
                Next

                _uncovered_tiles.RemoveRange(0, _uncovered_tiles.Count)

            End If

            'Switch to next player
            If _players.IndexOf(_turner) = _players.Count - 1 Then
                _turner = _players(0)
            Else
                _turner = _players(_players.IndexOf(_turner) + 1)
            End If

        End Sub

    End Class

End Namespace
