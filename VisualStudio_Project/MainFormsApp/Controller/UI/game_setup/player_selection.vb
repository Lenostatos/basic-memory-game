Imports MainFormsApp.game_logic

Namespace controller.ui.game_setup

    ''' <summary>
    ''' Models the user interface for creating players for a game.
    ''' </summary>
    Public Class player_selection

        Private Property _setup_data As setup_new_game_data

        Public Sub New(ByRef setup_data As setup_new_game_data)

            If setup_data Is Nothing Then Throw New ArgumentNullException()
            _setup_data = setup_data

        End Sub

        Public ReadOnly Property set_up_players As IReadOnlyList(Of player)
            Get
                Return _setup_data.players()
            End Get
        End Property

        ''' <summary>
        ''' Adds player <paramref name="p"/> to the players list.
        ''' </summary>
        ''' <param name="p"></param>
        Public Sub add_player(p As player)
            _setup_data.add_player(p)
            If _setup_data.players.Count = 1 Then
                set_starting_player()
            End If
        End Sub

        ''' <summary>
        ''' Removes player <paramref name="p"/> from the players list.
        ''' </summary>
        ''' <param name="p"></param>
        ''' <returns></returns>
        Public Function remove_player(p As player) As Boolean

            If p Is Nothing Then Throw New ArgumentNullException()

            Dim removed As Boolean = _setup_data.remove_player(p)
            If removed Then
                If _setup_data.players.Count = 0 Then
                    _setup_data.starting_player = Nothing
                Else
                    set_starting_player()
                End If
            End If

            Return removed

        End Function

        ''' <summary>
        ''' Sets the starting_player to the first player in the players list.
        ''' </summary>
        Private Sub set_starting_player()

            If _setup_data.players.Count = 0 Then
                Throw New InvalidOperationException()
            Else
                _setup_data.starting_player = _setup_data.players(0)
            End If


        End Sub

    End Class

End Namespace
