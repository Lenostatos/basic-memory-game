Namespace game_logic.test

    Public Class tile_item
        Inherits a_tile_item

        Public ReadOnly Property name As String
            Get
                Return _name
            End Get
        End Property

        Private Property _name As String

        Public Overrides ReadOnly Property design As i_tile_item_design
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public Sub New(id As Integer, name As String)

            _id = id
            _name = name

        End Sub

    End Class

End Namespace
