Namespace game_logic

    ''' <summary>
    ''' Models a player that can find matching tiles.
    ''' </summary>
    Public Class player

        Public ReadOnly Property name As String
            Get
                Return _name
            End Get
        End Property

        Private Property _name As String
        Private Property _won_tiles As HashSet(Of matching_tiles)

        Public Sub New(name As String)

            If name Is Nothing Then Throw New ArgumentNullException()

            _name = name
            _won_tiles = New HashSet(Of matching_tiles)

        End Sub

        Public Sub find_match(tiles As tile_tuple)
            If tiles Is Nothing Then Throw New ArgumentNullException()
            _won_tiles.Add(tiles)
        End Sub

    End Class

End Namespace
