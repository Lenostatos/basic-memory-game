Namespace game_logic.test

    Public Class tile_test

        Implements MainFormsApp.test.i_test

        Public Function run() As Boolean Implements MainFormsApp.test.i_test.run

            Dim tile As New tile(New tile_item(0, "fir"))

            If Not tile.covered Then Return False

            tile.uncover()
            If tile.covered Then Return False
            tile.uncover()

            tile.cover()
            If Not tile.covered Then Return False
            tile.cover()

            tile.uncover()
            Dim other_tile As New tile(New tile_item(0, "fir2"), covered:=False)
            If Not tile.matches(other_tile) Then Return False

            other_tile = New tile(New tile_item(1, "pine"), covered:=False)
            If tile.matches(other_tile) Then Return False

            Return True

        End Function

    End Class

End Namespace
