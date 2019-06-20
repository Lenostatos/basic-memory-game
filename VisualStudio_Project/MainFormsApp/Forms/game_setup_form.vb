Imports MainFormsApp.game_logic
Imports MainFormsApp.controller

Public Class game_setup_form

    Private Property _setup_data As setup_new_game_data
    Private Property _UI_control_add_player As ui.game_setup.player_selection
    Private Property _GUI_control_add_player As gui.game_setup_form.player_selection

    Private Property _UI_control_choose_database As ui.game_setup.database_selection
    Private Property _GUI_control_choose_database As gui.game_setup_form.database_selection

    Private Sub game_setup_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _setup_data = New setup_new_game_data()
        _UI_control_add_player = New ui.game_setup.player_selection(_setup_data)
        _GUI_control_add_player = New gui.game_setup_form.player_selection(_UI_control_add_player)

        _UI_control_choose_database = New ui.game_setup.database_selection()
        _GUI_control_choose_database = New gui.game_setup_form.database_selection(_UI_control_choose_database)

        _GUI_control_choose_database.change_database_file(
            _UI_control_choose_database.default_database_path, label_database_file_path)

    End Sub

    Public ReadOnly Property setup_data As setup_new_game_data
        Get
            Return _setup_data
        End Get
    End Property

    Public ReadOnly Property UI_controler_database_selection As controller.ui.game_setup.database_selection
        Get
            Return _UI_control_choose_database
        End Get
    End Property

    Public ReadOnly Property UI_controler_add_player As controller.ui.game_setup.player_selection
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
            refresh_form()
        End If
    End Sub

    Private Sub button_display_database_choosing_help_Click(sender As Object, e As EventArgs) Handles button_display_database_choosing_help.Click
        choose_database_help_form.Show()
    End Sub

    Private Sub button_choose_tile_set_Click(sender As Object, e As EventArgs) Handles button_choose_tile_set.Click
        _GUI_control_choose_database.choose_database_file(label_database_file_path)
        refresh_form()
    End Sub

    Public Sub refresh_form()
        button_start_game.Enabled = _setup_data.ready_to_go
    End Sub

    Private Sub button_tile_set_options_Click(sender As Object, e As EventArgs) Handles button_tile_set_options.Click
        tile_set_options_form.Show()
    End Sub

    Private Sub button_start_game_Click(sender As Object, e As EventArgs) Handles button_start_game.Click
        Me.Hide()
        MainFormsApp.game_form.Show()
    End Sub
End Class