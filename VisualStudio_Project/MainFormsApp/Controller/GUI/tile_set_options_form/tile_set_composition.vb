Namespace controller.GUI.game_setup

    Public Class tile_set_composition

        Private Property _UI_set_composer As UI.game_setup.tile_set_composition_class

        Public Sub New(UI_set_composer As UI.game_setup.tile_set_composition_class)
            _UI_set_composer = UI_set_composer
        End Sub

        Public Sub list_design_selection_patterns(combo_box As ComboBox)

            combo_box.Items.Clear()
            combo_box.Items.Add(New KeyValuePair(Of UI.game_setup.design_selection_pattern, String)(
                                UI.game_setup.design_selection_pattern.only_identical_designs_per_item,
                                "Only identical tiles per item"))
            combo_box.Items.Add(New KeyValuePair(Of UI.game_setup.design_selection_pattern, String)(
                                UI.game_setup.design_selection_pattern.only_unique_designs_per_item,
                                "Only unique tiles per item"))
            combo_box.Items.Add(New KeyValuePair(Of UI.game_setup.design_selection_pattern, String)(
                                UI.game_setup.design_selection_pattern.identical_and_unique_designs_per_item,
                                "Both identical and different tiles per item"))

            combo_box.DisplayMember = "Value"

        End Sub

        Public Sub combo_box_tile_selection_pattern_SelectedIndexChanged(sender As ComboBox, e As EventArgs)

            Dim sender_form As tile_set_options_form = sender.Parent

            If sender.Text <> "" Then
                sender_form.combo_box_num_tiles_per_item.Enabled = True
                list_possible_num_designs_per_item(sender_form.combo_box_num_tiles_per_item, sender.SelectedItem.Key)
            Else
                sender_form.combo_box_num_tiles_per_item.Enabled = False
            End If


        End Sub

        Public Sub list_possible_num_designs_per_item(combo_box As ComboBox,
                                                      design_selection_pattern As UI.game_setup.design_selection_pattern)

            combo_box.Items.Clear()
            For num As Integer = 2 To _UI_set_composer.max_num_available_tiles_per_item(design_selection_pattern)
                combo_box.Items.Add(num)
            Next

        End Sub

        Public Sub submit_selected_items(ByRef game_setup_form As MainFormsApp.game_setup_form)
            'game_setup_form.setup_data.tile_set
            game_setup_form.refresh_form()
        End Sub

    End Class

End Namespace
