Namespace game_logic

    ''' <summary>
    ''' Requires tile items to have an identifier and the ability to match themselves against other tile items.
    ''' </summary>
    Public Interface i_tile_item

        ReadOnly Property id As Integer
        ReadOnly Property design As i_tile_item_design

        Function matches(other As i_tile_item) As Boolean

    End Interface

End Namespace
