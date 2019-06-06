Imports MainFormsApp.game_logic

Namespace game_logic_test

    <TestClass()>
    Public Class game_test

        <TestMethod>
        Public Sub test_construction()

            Dim players As List(Of player)
            Dim tiles As matching_tiles_set

            Dim my_game As New game(players, tiles)

            For Each p As player In players
                Assert.IsTrue(my_game.players.Contains(p))
            Next

        End Sub

    End Class

End Namespace
