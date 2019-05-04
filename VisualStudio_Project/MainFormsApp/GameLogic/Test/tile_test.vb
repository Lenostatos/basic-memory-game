Namespace game_logic.test

    Public Class tile_test

        Implements i_test

        Public Function run() As Boolean Implements i_test.run

            Dim tile As New game_logic.tile(New tile_item(0, "fir"))

            If Not tile.covered Then Return False

            Return True

        End Function

    End Class

End Namespace
