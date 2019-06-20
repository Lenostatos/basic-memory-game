Imports System.Windows
Imports MainFormsApp.game_logic

Namespace controller.gui.game_setup_form

    Public Class player_selection

        Public Const MESSAGE_MISSING_PLAYER_NAME As String =
            "Please give a name for the player you want to add."
        Public Const MESSAGE_ALREADY_EXISTING_PLAYER_NAME As String =
            "There is already a player with that name." & vbNewLine &
            "Please choose another name."
        Public Const MESSAGE_COULD_NOT_REMOVE_PLAYER As String =
            "Could not remove that player."

        Private Property _UI_add_player_control As ui.game_setup.player_selection

        Public Sub New(ByRef UI_add_player_controller As ui.game_setup.player_selection)
            If UI_add_player_controller Is Nothing Then Throw New ArgumentNullException()
            _UI_add_player_control = UI_add_player_controller
        End Sub

        Public Sub refresh_player_list(ByRef player_list_layout_panel As Forms.TableLayoutPanel)

            If player_list_layout_panel Is Nothing Then Throw New ArgumentNullException()

            player_list_layout_panel.Controls.Clear()
            player_list_layout_panel.RowCount =
                _UI_add_player_control.set_up_players.Count

            Dim label_new_player As Forms.Label
            Dim button_delete_player As Forms.Button

            For row_index As Integer = 0 To _UI_add_player_control.set_up_players.Count - 1

                label_new_player = New Label() With {
                    .Text = _UI_add_player_control.set_up_players(row_index).name,
                    .Anchor = System.Windows.Forms.AnchorStyles.Top Or
                    System.Windows.Forms.AnchorStyles.Bottom Or
                    System.Windows.Forms.AnchorStyles.Left Or
                    System.Windows.Forms.AnchorStyles.Right,
                    .TextAlign = ContentAlignment.MiddleLeft,
                    .Padding = Padding.Empty
                }

                button_delete_player = New Button() With {
                    .Text = "X",
                    .Anchor = System.Windows.Forms.AnchorStyles.Top Or
                    System.Windows.Forms.AnchorStyles.Bottom Or
                    System.Windows.Forms.AnchorStyles.Left Or
                    System.Windows.Forms.AnchorStyles.Right
                }
                AddHandler button_delete_player.Click, AddressOf remove_button_click

                player_list_layout_panel.Controls.Add(label_new_player, 0, row_index)
                player_list_layout_panel.Controls.Add(button_delete_player, 1, row_index)

            Next

        End Sub

        Public Sub add_player(ByRef setup_form As MainFormsApp.game_setup_form)

            If setup_form.text_box_add_player.Text = "" Then

                MsgBox(MESSAGE_MISSING_PLAYER_NAME)

            ElseIf _UI_add_player_control.set_up_players.Contains(
                New player(setup_form.text_box_add_player.Text)) Then

                MsgBox(MESSAGE_ALREADY_EXISTING_PLAYER_NAME)

            Else

                _UI_add_player_control.add_player(New player(setup_form.text_box_add_player.Text))
                refresh_player_list(setup_form.table_layout_panel_added_players)

            End If

            setup_form.text_box_add_player.Text = ""

        End Sub

        Private Sub remove_button_click(sender As Button, e As EventArgs)

            Dim player_table As TableLayoutPanel = sender.Parent
            Dim player_label As Label = player_table.GetControlFromPosition(0, player_table.GetRow(sender))

            Dim to_be_removed_player As New player(player_label.Text)

            If Not _UI_add_player_control.remove_player(to_be_removed_player) Then
                MsgBox(MESSAGE_COULD_NOT_REMOVE_PLAYER)
            Else
                refresh_player_list(player_table)
            End If

        End Sub

    End Class

End Namespace
