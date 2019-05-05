Namespace game_logic

    Public Class tile_tuple

        Public ReadOnly Property tiles As System.Collections.Generic.List(Of tile)
            Get
                Return _tiles
            End Get
        End Property

        Private Property _tiles As System.Collections.Generic.List(Of tile)

        Public Sub New(tiles As System.Collections.Generic.List(Of tile))

        End Sub

    End Class

End Namespace
