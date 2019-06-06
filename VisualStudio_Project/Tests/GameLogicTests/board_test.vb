Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class board_test

        Private t_1 As New tile(0, New tile_item(0, New tile_item_design()))
        Private t_2 As New tile(1, New tile_item(1, New tile_item_design()))
        Private t_3 As New tile(2, New tile_item(2, New tile_item_design()))

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

        Private _tiles As New matching_tiles_set() From {
                _m_3_t_1, _m_3_t_2, _m_3_t_3
        }

        <TestMethod>
        Public Sub test_lists_and_nothings()

            Dim test_list As New List(Of tile)(3)

            test_list.Add(Nothing)
            Assert.IsTrue(test_list(0) Is Nothing)

            test_list.Add(t_1)
            Assert.IsTrue(test_list(0) Is Nothing)
            Assert.IsTrue(test_list(1) IsNot Nothing)

        End Sub

        <TestMethod>
        Public Sub test_contruction()

            Dim my_tiles As matching_tiles_set = _tiles

            Dim my_board As New board(my_tiles)

            Assert.AreEqual(0, my_board(0).undercover_item.id)
            Assert.AreEqual(0, my_board(1).undercover_item.id)
            Assert.AreEqual(0, my_board(2).undercover_item.id)

            Assert.AreEqual(0, my_board(0).id)
            Assert.AreEqual(1, my_board(1).id)
            Assert.AreEqual(2, my_board(2).id)

            my_tiles = New matching_tiles_set() From {
                _m_3_t_1
            }

            Assert.ThrowsException(Of ArgumentException)(
                Sub() my_board = New board(my_tiles), board.EXCEPTION_MESSAGE_NOT_ENOUGH_DIFFERENT_ITEMS)

            my_tiles = New matching_tiles_set() From {
                New matching_tiles() From {t_1},
                New matching_tiles() From {t_2},
                New matching_tiles() From {t_3}
            }

            Assert.ThrowsException(Of ArgumentException)(
                Sub() my_board = New board(my_tiles), board.EXCEPTION_MESSAGE_NOT_ENOUGH_MATCHING_TILES)

        End Sub

        <TestMethod>
        Public Sub test_tile_removal()

            Dim my_board As New board(_tiles)

            Dim removed_tiles As matching_tiles =
                my_board.remove_matching_tiles({0, 1, 2})

            Assert.AreEqual(0, removed_tiles.undercover_common_item.id)

            Assert.IsNull(my_board(0))
            Assert.IsNull(my_board(1))
            Assert.IsNull(my_board(2))

        End Sub

        <TestMethod>
        Public Sub test_filtering_existing_tiles()

            Dim my_board As New board(_tiles)

            Dim removed_tiles As matching_tiles =
                my_board.remove_matching_tiles({0, 1, 2})

            Dim remaining_tiles As New List(Of tile)(my_board.tiles)
            Assert.AreEqual(6, remaining_tiles.Count)

            Dim m_3_t_tiles As New List(Of tile)(_m_3_t_2.tiles)
            Assert.IsTrue(remaining_tiles.Contains(m_3_t_tiles(0)))
            Assert.IsTrue(remaining_tiles.Contains(m_3_t_tiles(1)))
            Assert.IsTrue(remaining_tiles.Contains(m_3_t_tiles(2)))

            m_3_t_tiles = New List(Of tile)(_m_3_t_3.tiles)
            Assert.IsTrue(remaining_tiles.Contains(m_3_t_tiles(0)))
            Assert.IsTrue(remaining_tiles.Contains(m_3_t_tiles(1)))
            Assert.IsTrue(remaining_tiles.Contains(m_3_t_tiles(2)))

        End Sub

        <TestMethod>
        Public Sub test_shuffeling()

            Dim my_tiles As matching_tiles_set = _tiles

            Dim my_board As New board(my_tiles)

            my_board.shuffle_positions()

            For Each t As tile In my_tiles.tiles
                Assert.IsTrue(my_board.Contains(t))
            Next

            my_board.shuffle_tiles()

            For Each t As tile In my_tiles.tiles
                Assert.IsTrue(my_board.Contains(t))
            Next

            my_board = New board(my_tiles)
            my_board.remove_matching_tiles({0, 1, 2})

            my_board.shuffle_tiles()

            Assert.IsNull(my_board(0))
            Assert.IsNull(my_board(1))
            Assert.IsNull(my_board(2))

            my_board = New board(my_tiles)
            my_board.remove_matching_tiles({3, 4, 5})

            my_board.shuffle_tiles()

            Assert.IsNull(my_board(3))
            Assert.IsNull(my_board(4))
            Assert.IsNull(my_board(5))

        End Sub

    End Class

End Namespace
