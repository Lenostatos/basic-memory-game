Imports MainFormsApp.game_logic

Namespace controller.UI.game_setup

    Public Class add_player

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

        Public Sub add_player(p As player)
            _setup_data.add_player(p)
        End Sub

    End Class

End Namespace
