Namespace game_logic

    ''' <summary>
    ''' Models a game of memory.
    ''' </summary>
    ''' <TODO>Create a constructor for any kind of game in any state
    ''' and an extra function for initializing a new game.</TODO>
    Public Class game

        Public Const EXCEPTION_MESSAGE_INITIALIZED_GAME_WITHOUT_PLAYERS As String =
            "Attempted to initialize a game without any players."
        Public Const EXCEPTION_MESSAGE_INITIALIZED_GAME_WITH_INVALID_PLAYERS As String =
            "Attempted to initialize a game with players that already had tiles."
        Public Const EXCEPTION_MESSAGE_STARTING_PLAYER_NOT_AMONG_PLAYERS As String =
            "Attempted to initialize a game with a starting player that was not contained in the list of players."
        Public Const EXCEPTION_MESSAGE_UNCOVER_AT_EMPTY_POSITION As String =
            "Attempted to uncover a tile at at position where there was no tile."
        Public Const EXCEPTION_MESSAGE_DUPLICATE_PLAYERS As String =
            "Attempted to initialize a game with at least one duplicate player."
        Public Const EXCEPTION_MESSAGE_GET_WINNERS_BEFORE_GAME_OVER As String =
            "Attempted to get winners before the game was over."
        Public Const EXCEPTION_MESSAGE_UNCOVER_ALREADY_UNCOVERED_TILE As String =
            "Attempted to uncover a tile that was already uncovered."

        Private Property _players As List(Of player)
        Private Property _moving_player As player
        Private Property _board As game_board
        Private Property _game_over As Boolean
        Private Property _uncovered_positions As List(Of Integer)
        Private Property _cover_before_next_uncover As Boolean

        ''' <summary>
        ''' The order of the players is given by their order in the
        ''' passed list.
        ''' </summary>
        ''' <param name="players"></param>
        ''' <param name="starting_player"></param>
        ''' <param name="tiles"></param>
        Public Sub New(players As List(Of player),
                       starting_player As player,
                       tiles As matching_tiles_set)

            If players Is Nothing Then Throw New ArgumentNullException()
            If starting_player Is Nothing Then Throw New ArgumentNullException()
            If tiles Is Nothing Then Throw New ArgumentNullException()

            If players.Count < 1 Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_INITIALIZED_GAME_WITHOUT_PLAYERS)
            End If

            If Not players.Contains(starting_player) Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_STARTING_PLAYER_NOT_AMONG_PLAYERS)
            End If

            If players.Any(Function(p As player) p.won_tile_sets.Count > 0) Then
                Throw New ArgumentException(EXCEPTION_MESSAGE_INITIALIZED_GAME_WITH_INVALID_PLAYERS)
            End If

            _players = New List(Of player)

            For Each p As player In players
                If _players.Contains(p) Then
                    Throw New ArgumentException(EXCEPTION_MESSAGE_DUPLICATE_PLAYERS)
                Else
                    _players.Add(p)
                End If
            Next

            _moving_player = starting_player
            _board = New game_board(tiles)

            _board.cover_tiles()
            _board.shuffle_positions()

            _uncovered_positions = New List(Of Integer)
            _cover_before_next_uncover = False

        End Sub

        Public Sub New(game_setup_data As setup_new_game_data)

            Me.New(game_setup_data.players, game_setup_data.starting_player, game_setup_data.tile_set)

        End Sub

        Public ReadOnly Property moving_player As player
            Get
                Return _moving_player
            End Get
        End Property

        Public ReadOnly Property players As IReadOnlyList(Of player)
            Get
                Return _players
            End Get
        End Property

        Public ReadOnly Property board As game_board
            Get
                Return _board
            End Get
        End Property

        Public ReadOnly Property cover_before_next_uncover As Boolean
            Get
                Return _cover_before_next_uncover
            End Get
        End Property

        Public ReadOnly Property game_over As Boolean
            Get
                Return _game_over
            End Get
        End Property

        ''' <summary>
        ''' Returns all players that have won the biggest number of tile sets.
        ''' </summary>
        ''' <returns></returns>
        ''' <exception cref="InvalidOperationException">Thrown if the game is not over.</exception>
        Public ReadOnly Property winners As IEnumerable(Of player)
            Get
                If Not game_over Then
                    Throw New InvalidOperationException(EXCEPTION_MESSAGE_GET_WINNERS_BEFORE_GAME_OVER)
                Else

                    Dim max_number_of_won_tile_sets As Integer =
                        _players.Max(Function(p As player) p.won_tile_sets.Count)

                    Return _players.Where(
                        Function(p As player) p.won_tile_sets.Count = max_number_of_won_tile_sets)

                End If
            End Get
        End Property

        ''' <summary>
        ''' Makes the moving player uncover the tile at the zero-based
        ''' <paramref name="index"/>.
        ''' </summary>
        ''' <param name="index">A zero-based index for a position on the game's board.</param>
        Public Sub uncover_tile(index As Integer)

            If board(index) Is Nothing Then
                Throw New ArgumentOutOfRangeException("index", index, EXCEPTION_MESSAGE_UNCOVER_AT_EMPTY_POSITION)
            End If

            If _cover_before_next_uncover Then
                board.cover_tiles()
                _uncovered_positions.Clear()
                _cover_before_next_uncover = False
            End If

            If Not board(index).covered Then
                Throw New InvalidOperationException(EXCEPTION_MESSAGE_UNCOVER_ALREADY_UNCOVERED_TILE)
            End If

            board(index).uncover()
            apply_rules(index)

        End Sub

        Private Sub apply_rules(uncovered_position As Integer)

            ' If there was no other uncovered tile
            If _uncovered_positions.Count = 0 Then
                _uncovered_positions.Add(uncovered_position)
            Else ' If there was already another uncovered tile

                ' If the uncovered tiles match
                If board(uncovered_position).matches(board(_uncovered_positions(0))) Then

                    _uncovered_positions.Add(uncovered_position)

                    ' If the number of uncovered tiles is equal to the number of
                    ' tiles that form a matching set on the current board
                    If _uncovered_positions.Count = board.size_of_matching_tile_groups Then

                        moving_player.collect_tiles(board.remove_matching_tiles(_uncovered_positions))
                        _uncovered_positions.Clear()

                        ' If no tiles are left
                        If board.All(Function(t As tile) t Is Nothing) Then
                            _game_over = True
                        End If

                    End If

                Else ' If the uncovered tiles don't match

                    _cover_before_next_uncover = True
                    switch_to_next_player()

                End If

            End If

        End Sub

        Private Sub switch_to_next_player()

            Dim index_of_moving_player As Integer = _players.IndexOf(moving_player)
            If index_of_moving_player = _players.Count - 1 Then
                _moving_player = _players(0)
            Else
                _moving_player = _players(index_of_moving_player + 1)
            End If

        End Sub

    End Class

End Namespace
