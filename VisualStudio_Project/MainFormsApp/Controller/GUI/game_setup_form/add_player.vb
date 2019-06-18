Imports System.Windows
Imports MainFormsApp.game_logic

Namespace controller.GUI.game_setup_form

    Public Class add_player

        Public Const MESSAGE_MISSING_PLAYER_NAME As String =
            "Please give a name for the player you want to add."
        Public Const MESSAGE_ALREADY_EXISTING_PLAYER_NAME As String =
            "There is already a player with that name." & vbNewLine &
            "Please choose another name."

        Private Property _UI_add_player_control As UI.game_setup.add_player

        Public Sub New(ByRef UI_add_player_controller As UI.game_setup.add_player)
            If UI_add_player_controller Is Nothing Then Throw New ArgumentNullException()
            _UI_add_player_control = UI_add_player_controller
        End Sub

        Public Sub add_player(ByRef setup_form As MainFormsApp.game_setup_form)

            If setup_form.text_box_add_player.Text = "" Then

                MsgBox(MESSAGE_MISSING_PLAYER_NAME)

            ElseIf _UI_add_player_control.set_up_players.Contains(
                New player(setup_form.text_box_add_player.Text)) Then

                MsgBox(MESSAGE_ALREADY_EXISTING_PLAYER_NAME)

            Else

                _UI_add_player_control.add_player(New player(setup_form.text_box_add_player.Text))

                setup_form.table_layout_panel_added_players.Controls.Clear()
                setup_form.table_layout_panel_added_players.RowCount =
                    _UI_add_player_control.set_up_players.Count

                Dim label_new_player As Forms.Label
                Dim button_delete_player As Forms.Button

                For row_index As Integer = 0 To _UI_add_player_control.set_up_players.Count - 1

                    label_new_player = New Label() With {
                        .Text = _UI_add_player_control.set_up_players(row_index).name,
                        .Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right,
                        .TextAlign = ContentAlignment.MiddleLeft,
                        .Padding = Padding.Empty
                    }

                    button_delete_player = New Button() With {
                        .Text = "X",
                        .Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
                    }

                    setup_form.table_layout_panel_added_players.Controls.Add(label_new_player, 0, row_index)
                    setup_form.table_layout_panel_added_players.Controls.Add(button_delete_player, 1, row_index)

                Next

            End If

        End Sub

    End Class

End Namespace
