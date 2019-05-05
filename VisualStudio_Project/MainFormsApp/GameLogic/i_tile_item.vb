Namespace game_logic

    ''' <summary>
    ''' Defines an interface for tile items.
    ''' </summary>
    Public Interface i_tile_item

        ReadOnly Property id As Integer
        ReadOnly Property design As i_tile_item_design

        Function matches(other As i_tile_item) As Boolean

    End Interface

End Namespace
