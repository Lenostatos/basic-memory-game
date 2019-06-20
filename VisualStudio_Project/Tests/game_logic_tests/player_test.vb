Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class player_test

        Private name As String = "Maax"

        Private _matching_2_t_1 As New matching_tiles() From {
            New tile(0, New tile_item(0, New tile_item_design(0))),
            New tile(1, New tile_item(0, New tile_item_design(0)))
        }

        Private _matching_2_t_2 As New matching_tiles() From {
            New tile(2, New tile_item(1, New tile_item_design(0))),
            New tile(3, New tile_item(1, New tile_item_design(0)))
        }

        <TestMethod>
        Public Sub test_construction()

            Dim my_player As New player(name)

            Assert.AreEqual(name, my_player.name)

            Assert.ThrowsException(Of ArgumentException)(
                Sub() my_player = New player(""))

        End Sub

        <TestMethod>
        Public Sub test_collecting_tiles()

            Dim my_player As New player(name)

            Assert.ThrowsException(Of ArgumentNullException)(
                Sub() my_player.collect_tiles(Nothing))

            my_player.collect_tiles(_matching_2_t_1)
            Assert.IsTrue(my_player.won_tile_sets.Contains(_matching_2_t_1))

            my_player.collect_tiles(_matching_2_t_2)
            Assert.IsTrue(my_player.won_tile_sets.Contains(_matching_2_t_2))

        End Sub

        <TestMethod>
        Public Sub test_equatability()

            Dim player_1 As New player("a")
            Dim player_2 As New player("a")
            Dim player_3 As New player("b")

            Assert.AreEqual(Of player)(player_1, player_2)
            Assert.AreNotEqual(Of player)(player_1, player_3)

        End Sub

    End Class

End Namespace