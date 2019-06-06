Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class matching_tiles_set_test

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

        Private _m_3_t_4 As New matching_tiles() From {
            New tile(0, New tile_item(2, New tile_item_design())),
            New tile(6, New tile_item(2, New tile_item_design())),
            New tile(7, New tile_item(2, New tile_item_design()))
        }

        Private _m_3_t_5 As New matching_tiles() From {
            New tile(8, New tile_item(0, New tile_item_design())),
            New tile(9, New tile_item(0, New tile_item_design())),
            New tile(10, New tile_item(0, New tile_item_design()))
        }

        Private _m_2_t_1 As New matching_tiles() From {
            New tile(11, New tile_item(3, New tile_item_design())),
            New tile(12, New tile_item(3, New tile_item_design()))
        }

        <TestMethod>
        Public Sub test_constructor()

            Dim test As New matching_tiles_set()

            Assert.AreEqual(0, test.size_of_matching_tile_groups)
            Assert.AreEqual(0, test.Count)

        End Sub

        <TestMethod>
        Public Sub test_add()

            Dim test As New matching_tiles_set()

            test.Add(_m_3_t_1)
            test.Add(_m_3_t_2)

            Assert.ThrowsException(Of ArgumentException)(
                Sub() test.Add(_m_2_t_1), matching_tiles_set.EXCEPTION_MESSAGE_ADDED_WRONG_NUMBER_OF_MATCHING_TILES)

            Assert.ThrowsException(Of ArgumentException)(
                Sub() test.Add(_m_3_t_4), matching_tiles_set.EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_TILE)

            Assert.ThrowsException(Of ArgumentException)(
                Sub() test.Add(_m_3_t_5), matching_tiles_set.EXCEPTION_MESSAGE_ADDED_ALREADY_INCLUDED_ITEM)

        End Sub

        <TestMethod>
        Public Sub test_size_of_matching_tiles_field()

            Dim test As New matching_tiles_set()

            Assert.AreEqual(0, test.size_of_matching_tile_groups)

            test.Add(_m_3_t_1)

            Assert.AreEqual(3, test.size_of_matching_tile_groups)

            test.Remove(_m_3_t_1)

            Assert.AreEqual(0, test.size_of_matching_tile_groups)

            test.Add(_m_3_t_1)
            test.Clear()

            Assert.AreEqual(0, test.size_of_matching_tile_groups)

            test.Add(_m_2_t_1)

            Assert.AreEqual(2, test.size_of_matching_tile_groups)

        End Sub

        <TestMethod>
        Public Sub test_remove()
            'TODO
            Dim test As New matching_tiles_set()

            test.Add(_m_3_t_1)
            test.Add(_m_3_t_2)

            Assert.AreEqual(2, test.Count)

            test.Remove(_m_3_t_1)

            Assert.AreEqual(1, test.Count)
            Assert.IsFalse(test.Remove(_m_3_t_1))

            test.Remove(_m_3_t_2)

            Assert.AreEqual(0, test.Count)
            Assert.AreEqual(0, test.size_of_matching_tile_groups)

        End Sub

    End Class

End Namespace
