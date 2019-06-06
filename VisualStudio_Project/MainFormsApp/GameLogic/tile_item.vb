Namespace game_logic

    Public Class tile_item

        Implements i_tile_item
        Implements IEquatable(Of i_tile_item)

        Private Property _id As Integer
        Private Property _design As i_tile_item_design

        Public Sub New(id As Integer, design As i_tile_item_design)

            If design Is Nothing Then Throw New ArgumentNullException()

            _id = id
            _design = design

        End Sub

        Public ReadOnly Property id As Integer Implements i_tile_item.id
            Get
                Return _id
            End Get
        End Property

        Public ReadOnly Property design As i_tile_item_design Implements i_tile_item.design
            Get
                Return _design
            End Get
        End Property

        Public Function matches(other As i_tile_item) As Boolean Implements i_tile_item.matches
            Return id.Equals(other.id)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return id
        End Function

        Public Shadows Function Equals(other As i_tile_item) As Boolean Implements IEquatable(Of i_tile_item).Equals
            Return matches(other)
        End Function
    End Class

End Namespace
