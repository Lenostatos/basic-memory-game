Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class game_test

        Private _m_3_t_1 As New matching_tiles() From {
            New tile(0, New tile_item(0, New tile_item_design())),
            New tile(1, New tile_item(0, New tile_item_design())),
            New tile(2, New tile_item(0, New tile_item_design()))
        }

        Private _m_3_t_2 As New matching_tiles() From {
            New tile(3, New tile_item(1, New tile_item_design())),
            New tile(4, New tile_item(1, New tile_item_design())),
            New tile(5, New tile_item(1, New tile_item_design()))
        }

        Private _m_3_t_3 As New matching_tiles() From {
            New tile(8, New tile_item(2, New tile_item_design())),
            New tile(6, New tile_item(2, New tile_item_design())),
            New tile(7, New tile_item(2, New tile_item_design()))
        }

        Private _m_2_t_1 As New matching_tiles() From {
            New tile(0, New tile_item(0, New tile_item_design())),
            New tile(1, New tile_item(0, New tile_item_design()))
        }

        Private _m_2_t_2 As New matching_tiles() From {
            New tile(3, New tile_item(1, New tile_item_design())),
            New tile(4, New tile_item(1, New tile_item_design()))
        }

        Private _kuba As New player("Kuba")
        Private _hernie As New player("Hernie")

        <TestMethod>
        Public Sub construction_w_valid_arguments()

            Dim players As New List(Of player)() From {_kuba, _hernie}
            Dim tile_set As New matching_tiles_set() From {_m_3_t_1, _m_3_t_2, _m_3_t_3}

            Dim my_game As New game(players, _hernie, tile_set, game_board_layout.dimension.row, 2)

            For Each p As player In players
                Assert.IsTrue(my_game.players.Contains(p))
            Next

            Assert.AreEqual(_hernie, my_game.moving_player)

            For Each t As tile In tile_set.tiles
                Assert.IsTrue(my_game.board.tiles.Contains(t))
            Next

        End Sub

        <TestMethod>
        Public Sub construction_w_invalid_arguments()

            Dim my_game As game

            Dim players As New List(Of player)() From {_kuba, _hernie}
            Dim tile_set As New matching_tiles_set() From {_m_3_t_1, _m_3_t_2, _m_3_t_3}

            Assert.ThrowsException(Of ArgumentNullException)(
                Sub() my_game = New game(Nothing, _kuba, tile_set, game_board_layout.dimension.column, 2))
            Assert.ThrowsException(Of ArgumentNullException)(
                Sub() my_game = New game(players, Nothing, tile_set, game_board_layout.dimension.column, 2))
            Assert.ThrowsException(Of ArgumentNullException)(
                Sub() my_game = New game(players, _kuba, Nothing, game_board_layout.dimension.column, 2))

            Assert.ThrowsException(Of ArgumentException)(
                Sub() my_game = New game(New List(Of player), _kuba, tile_set, game_board_layout.dimension.column, 2),
                game.EXCEPTION_MESSAGE_INITIALIZED_GAME_WITHOUT_PLAYERS)

            Dim new_player As New player("Newbie")
            players = New List(Of player) From {new_player, _kuba}

            Assert.ThrowsException(Of ArgumentException)(
                Sub() my_game = New game(players, _hernie, tile_set, game_board_layout.dimension.column, 2),
                game.EXCEPTION_MESSAGE_STARTING_PLAYER_NOT_AMONG_PLAYERS)

            Dim inv_player As New player("Invalid")
            inv_player.collect_tiles(_m_3_t_1)
            players = New List(Of player) From {inv_player, _kuba}

            Assert.ThrowsException(Of ArgumentException)(
                Sub() my_game = New game(players, _kuba, tile_set, game_board_layout.dimension.column, 2),
                game.EXCEPTION_MESSAGE_INITIALIZED_GAME_WITH_INVALID_PLAYERS)

        End Sub

        <TestMethod>
        Public Sub tile_uncovering()

            Dim first_matched As Boolean = False
            Dim third_matched As Boolean = False
            Dim first_not_matched As Boolean = False
            Dim third_not_matched As Boolean = False

            Dim players As List(Of player)
            Dim tile_set As New matching_tiles_set() From {_m_3_t_1, _m_3_t_2, _m_3_t_3}

            Dim my_game As game
            Dim my_kuba, my_hernie As player

            ' Iterate tests until every scenario has been encountered
            While Not (first_matched AndAlso third_matched AndAlso first_not_matched AndAlso third_not_matched)

                my_kuba = New player("Kuba")
                my_hernie = New player("Hernie")
                players = New List(Of player)() From {my_kuba, my_hernie}

                my_game = New game(players, my_hernie, tile_set, game_board_layout.dimension.row, 2)

                my_game.uncover_tile(0)
                my_game.uncover_tile(1)

                ' If tiles did not match
                If my_game.board(0).covered Then

                    first_matched = True

                    Assert.IsTrue(my_game.board(1).covered)
                    Assert.IsFalse(my_game.board(0).undercover_matches(my_game.board(1)))
                    Assert.AreEqual(my_kuba, my_game.moving_player)

                Else ' If tiles matched

                    first_not_matched = True

                    Assert.IsFalse(my_game.board(1).covered)
                    Assert.IsTrue(my_game.board(0).matches(my_game.board(1)))
                    Assert.AreEqual(my_hernie, my_game.moving_player)

                    Dim tried_tiles As New List(Of tile) From {
                        my_game.board(0), my_game.board(1), my_game.board(2)}

                    my_game.uncover_tile(2)

                    ' If the third tile also matched
                    If my_game.board(0) Is Nothing Then

                        third_matched = True

                        Assert.IsTrue(my_game.board(1) Is Nothing)
                        Assert.IsTrue(my_game.board(2) Is Nothing)
                        Assert.AreEqual(0, my_kuba.won_tile_sets.Count)
                        Assert.AreEqual(1, my_hernie.won_tile_sets.Count)
                        Assert.AreEqual(3, my_hernie.won_tile_sets.count_of_single_tiles)
                        Assert.IsTrue(my_hernie.won_tile_sets.tiles.All(Function(t As tile) tried_tiles.Contains(t)))
                        Assert.AreEqual(my_hernie, my_game.moving_player)

                    Else ' If the third tile did not match

                        third_not_matched = True

                        Assert.IsTrue(my_game.board(0).covered)
                        Assert.IsTrue(my_game.board(1).covered)
                        Assert.IsTrue(my_game.board(2).covered)
                        Assert.AreEqual(0, my_kuba.won_tile_sets.Count)
                        Assert.AreEqual(0, my_hernie.won_tile_sets.Count)
                        Assert.AreEqual(my_kuba, my_game.moving_player)

                    End If

                End If

            End While

        End Sub

        <TestMethod>
        Public Sub play_trough_w_2_tiles_per_item()

            Dim tile_set As New matching_tiles_set() From {_m_2_t_1, _m_2_t_2}

            Dim my_kuba As New player("Kuba")
            Dim my_hernie As New player("Hernie")
            Dim my_jonny As New player("Jonny")
            Dim my_players As New List(Of player)() From {my_kuba, my_hernie, my_jonny}

            Dim my_game As New game(my_players, my_jonny, tile_set, game_board_layout.dimension.row, 2)

            While Not my_game.game_over

                For Each index As Integer In {0, 1, 0, 2, 0, 3}

                    Try
                        my_game.uncover_tile(index)
                    Catch ex As ArgumentOutOfRangeException
                        Assert.AreEqual(New IO.StringReader(ex.Message).ReadLine, game.EXCEPTION_MESSAGE_UNCOVER_AT_EMPTY_POSITION)
                    End Try

                    If my_game.game_over Then Exit For

                Next

            End While

            Assert.IsTrue(my_game.winners.All(Function(p As player) my_players.Contains(p)))

        End Sub

        <TestMethod>
        Public Sub play_trough_w_3_tiles_per_item()

            Dim tile_set As New matching_tiles_set() From {_m_3_t_1, _m_3_t_2}

            Dim my_kuba As New player("Kuba")
            Dim my_hernie As New player("Hernie")
            Dim my_jonny As New player("Jonny")
            Dim my_players As New List(Of player)() From {my_kuba, my_hernie, my_jonny}

            Dim my_game As New game(my_players, my_jonny, tile_set, game_board_layout.dimension.row, 2)

            ' Gets the zero-based index of the first covered tile that is encountered on the board.
            ' Starts the search at starting_at.
            Dim index_of_first_covered_tile As New Func(Of game, Integer, Integer)(
                Function(the_game As game, starting_at As Integer) As Integer

                    If starting_at >= the_game.board.Count Then
                        Throw New ArgumentException()
                    End If

                    For index As Integer = starting_at To the_game.board.Count - 1
                        If the_game.board(index) IsNot Nothing AndAlso the_game.board(index).covered Then Return index
                    Next

                    Throw New Exception()

                End Function)

            Dim second_tile_index_min_increment As Integer
            Dim third_tile_index_min_increment As Integer

            Dim moving_player As player

            Dim tiles_matched As Boolean

            While Not my_game.game_over

                second_tile_index_min_increment = 1
                third_tile_index_min_increment = 1

                Do

                    Do

                        moving_player = my_game.moving_player

                        my_game.uncover_tile(index_of_first_covered_tile(my_game, 0))
                        my_game.uncover_tile(index_of_first_covered_tile(my_game, second_tile_index_min_increment))

                        tiles_matched = True
                        If Not my_game.moving_player.Equals(moving_player) Then
                            tiles_matched = False
                            second_tile_index_min_increment = second_tile_index_min_increment + 1
                        End If

                    Loop While Not tiles_matched

                    my_game.uncover_tile(index_of_first_covered_tile(my_game, third_tile_index_min_increment))

                    tiles_matched = True
                    If Not my_game.moving_player.Equals(moving_player) Then
                        tiles_matched = False
                        third_tile_index_min_increment = third_tile_index_min_increment + 1
                    End If

                Loop While Not tiles_matched

            End While

            Assert.IsTrue(my_game.winners.All(Function(p As player) my_players.Contains(p)))

        End Sub

    End Class

End Namespace
