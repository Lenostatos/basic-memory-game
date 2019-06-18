Imports MainFormsApp.game_logic
Imports MainFormsApp.controller

Public Class game_setup_form

    Private Property _setup_data As setup_new_game_data
    Private Property _UI_control_add_player As UI.game_setup.add_player
    Private Property _GUI_control_add_player As GUI.game_setup_form.add_player

    Private Sub game_setup_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _setup_data = New setup_new_game_data()
        _UI_control_add_player = New UI.game_setup.add_player(_setup_data)
        _GUI_control_add_player = New GUI.game_setup_form.add_player(_UI_control_add_player)

    End Sub

    Public ReadOnly Property setup_data As setup_new_game_data
        Get
            Return _setup_data
        End Get
    End Property

    Public ReadOnly Property UI_control_add_player As UI.game_setup.add_player
        Get
            Return _UI_control_add_player
        End Get
    End Property

    Private Sub text_box_add_player_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles text_box_add_player.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub text_box_add_player_KeyDown(sender As Object, e As KeyEventArgs) Handles text_box_add_player.KeyDown
        If e.KeyCode = Keys.Enter Then
            _GUI_control_add_player.add_player(Me)
        End If
    End Sub
End Class