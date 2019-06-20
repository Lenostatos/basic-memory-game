Imports MainFormsApp.controller.gui.game_setup
Imports MainFormsApp.controller.ui.game_setup

Public Class tile_set_options_form

    Private Property _gui_tile_set_compositor As tile_set_composition

    Private Sub tile_set_options_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Get database from the setup form.
        _gui_tile_set_compositor =
            New tile_set_composition(
            MainFormsApp.game_setup_form.UI_controler_database_selection.database)

        _gui_tile_set_compositor.list_design_selection_patterns(combo_box_tile_selection_pattern)
        _gui_tile_set_compositor.list_available_num_tiles(combo_box_num_random_items)
        _gui_tile_set_compositor.list_available_num_items_for_random_selection(combo_box_num_tiles_per_item)

        combo_box_num_random_items.Enabled = False
        combo_box_num_tiles_per_item.Enabled = False

    End Sub

    Private Sub combo_box_tile_selection_pattern_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles combo_box_tile_selection_pattern.SelectedIndexChanged

        If sender.Text <> "" Then
            _gui_tile_set_compositor.choose_design_selection_pattern(sender.SelectedItem)
            _gui_tile_set_compositor.list_available_num_items_for_random_selection(combo_box_num_random_items)
        End If

        combo_box_num_tiles_per_item.Enabled = False

    End Sub

    Private Sub combo_box_num_random_items_SelectedIndexChanged(sender As ComboBox, e As EventArgs) Handles combo_box_num_random_items.SelectedIndexChanged

        If sender.Text <> "" Then
            _gui_tile_set_compositor.choose_num_items_for_random_selection(sender.Text)
            _gui_tile_set_compositor.list_available_num_tiles(combo_box_num_tiles_per_item)
        End If

    End Sub

    Private Sub combo_box_num_tiles_per_item_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_box_num_tiles_per_item.SelectedIndexChanged

        If sender.Text <> "" Then
            _gui_tile_set_compositor.choose_num_tiles_per_item(sender.Text)
            _gui_tile_set_compositor.choose_designs_for_tiles_randomly()
        End If

    End Sub

    Private Sub button_submit_tile_options_Click(sender As Object, e As EventArgs) Handles button_submit_tile_options.Click
        MainFormsApp.game_setup_form.setup_data.tile_set = tile_set_builder.build(_gui_tile_set_compositor.selection_result)
        If MainFormsApp.game_setup_form.setup_data.ready_to_go Then
            MainFormsApp.game_setup_form.button_start_game.Enabled = True
        End If
        Me.Hide()
    End Sub
End Class