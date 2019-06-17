Namespace game_logic

    Public Class tile_item_design

        Implements i_tile_item_design

        Private Property _id As Integer

        Public Sub New(id As Integer)
            _id = id
        End Sub

        Public ReadOnly Property id As Integer Implements i_tile_item_design.id
            Get
                Return _id
            End Get
        End Property
    End Class

End Namespace
