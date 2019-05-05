Namespace game_logic

    ''' <summary>
    ''' Implements the matches method.
    ''' </summary>
    Public MustInherit Class a_tile_item

        Implements i_tile_item

        Public ReadOnly Property id As Integer Implements i_tile_item.id
            Get
                Return _id
            End Get
        End Property

        Protected Property _id As Integer

        Public MustOverride ReadOnly Property design As i_tile_item_design Implements i_tile_item.design

        Public Function matches(other As i_tile_item) As Boolean Implements i_tile_item.matches
            Return id = other.id
        End Function

    End Class

End Namespace
