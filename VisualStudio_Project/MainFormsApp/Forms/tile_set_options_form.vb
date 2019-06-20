Public Class tile_set_options_form

    Private _UI_tile_set_composer As controller.ui.game_setup.tile_set_composition_class
    Private _GUI_tile_set_composer As controller.gui.game_setup.tile_set_composition

    Private Sub tile_set_options_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _UI_tile_set_composer = New controller.ui.game_setup.tile_set_composition_class(
            game_setup_form.UI_controler_database_selection.database)
        _GUI_tile_set_composer = New controller.gui.game_setup.tile_set_composition(_UI_tile_set_composer)

        _GUI_tile_set_composer.list_design_selection_patterns(combo_box_tile_selection_pattern)

    End Sub

    Private Sub combo_box_tile_selection_pattern_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles combo_box_tile_selection_pattern.SelectedIndexChanged
        _GUI_tile_set_composer.combo_box_tile_selection_pattern_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub combo_box_num_tiles_per_item_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles combo_box_num_tiles_per_item.SelectedIndexChanged
        If sender.Text <> "" Then
            _UI_tile_set_composer.general_tile_choice(combo_box_num_tiles_per_item.Text,
                                                        combo_box_tile_selection_pattern.SelectedItem.Key)
        End If
    End Sub

    Private Sub button_submit_tile_options_Click(sender As Button, e As EventArgs) Handles button_submit_tile_options.Click
        _GUI_tile_set_composer.submit_selected_items(MainFormsApp.game_setup_form)
    End Sub

    Private Sub combo_box_num_tiles_per_item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_box_num_tiles_per_item.SelectedIndexChanged

    End Sub
End Class