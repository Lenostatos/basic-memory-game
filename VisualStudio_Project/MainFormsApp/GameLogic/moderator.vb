Namespace game_logic

    ''' <summary>
    ''' Models an entity that tracks the state of the game.
    ''' </summary>
    Public Class moderator

        '''' <summary>
        '''' The player whose turn it is.
        '''' </summary>
        '''' <returns></returns>
        'Public ReadOnly Property turner As player
        '    Get
        '        Return _turner
        '    End Get
        'End Property

        'Private Property _turner As player
        'Private Property _uncovered_tiles As List(Of tile)
        'Private Property _game_board As board

        'Public Sub New(starts As player, game_board As board)

        '    If starts Is Nothing Then Throw New ArgumentNullException()
        '    _turner = starts

        '    If game_board Is Nothing Then Throw New ArgumentNullException()
        '    _game_board = game_board

        'End Sub

    End Class

End Namespace
