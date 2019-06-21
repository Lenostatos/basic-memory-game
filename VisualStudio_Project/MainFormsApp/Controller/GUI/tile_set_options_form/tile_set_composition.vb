Imports MainFormsApp.controller.ui.game_setup.tile_set_composition

Namespace controller.gui.game_setup

    Public Class tile_set_composition

        Public Const DEFAULT_DESIGN_SELECTION_PATTERN As design_combination =
            design_combination.only_identical_designs_per_item
        Public Const DEFAULT_NUM_RANDOM_ITEMS As Integer = 2
        Public Const DEFAULT_NUM_TILES_PER_ITEM As Integer = 2

        Private Property _ui_design_combi_choice As design_combination_choice
        Private Property _ui_item_choice As item_choice
        Private Property _ui_num_tiles_per_item_choice As num_tiles_per_item_choice
        Private Property _ui_design_choice As design_choice

        ''' <summary>
        ''' Chooses a default tile setup.
        ''' </summary>
        ''' <param name="database"></param>
        Public Sub New(database As tile_database.i_database)

            If database Is Nothing Then Throw New ArgumentNullException()

            _ui_design_combi_choice = New design_combination_choice(database)
            _ui_design_combi_choice.choose(DEFAULT_DESIGN_SELECTION_PATTERN)

            _ui_item_choice = New item_choice(_ui_design_combi_choice)
            _ui_item_choice.choose_randomly(DEFAULT_NUM_RANDOM_ITEMS)

            _ui_num_tiles_per_item_choice = New num_tiles_per_item_choice(_ui_item_choice)
            _ui_num_tiles_per_item_choice.choose(DEFAULT_NUM_TILES_PER_ITEM)

            _ui_design_choice = New design_choice(_ui_num_tiles_per_item_choice)
            _ui_design_choice.choose_randomly()

        End Sub

        ''' <summary>
        ''' Displays the available options for the selection of design
        ''' combination patterns in a combobox. The combo box is cleared
        ''' before that. Also enables the combo box.
        ''' </summary>
        ''' <param name="combo_box"></param>
        Public Sub list_design_combination_patterns(combo_box As ComboBox)

            combo_box.Enabled = True
            combo_box.Items.Clear()

            For Each combination As design_combination In _ui_design_combi_choice.available_combinations

                Select Case combination
                    Case design_combination.only_identical_designs_per_item
                        combo_box.Items.Add(New KeyValuePair(Of design_combination, String)(
                                combination, "Only identical tiles per item"))
                    Case design_combination.identical_and_unique_designs_per_item
                        combo_box.Items.Add(New KeyValuePair(Of design_combination, String)(
                                combination, "Both identical and different tiles per item"))
                    Case design_combination.only_unique_designs_per_item
                        combo_box.Items.Add(New KeyValuePair(Of design_combination, String)(
                                combination, "Only unique tiles per item"))
                End Select

            Next

            combo_box.DisplayMember = "Value"

        End Sub

        ''' <summary>
        ''' Chooses a new design combination pattern.
        ''' </summary>
        ''' <param name="combo_box_obj">An object from a combo
        ''' box that has been filled by this controller before.</param>
        Public Sub choose_design_selection_pattern(combo_box_obj As Object)

            _ui_design_combi_choice.choose(combo_box_obj.Key)
            _ui_item_choice = New item_choice(_ui_design_combi_choice)

            _ui_num_tiles_per_item_choice.unchoose()
            _ui_design_choice.unchoose()

        End Sub

        ''' <summary>
        ''' Fills a combo box with the numbers of items that are available
        ''' to be chosen with a random selection.
        ''' Also Enables The combo box.
        ''' </summary>
        ''' <param name="combo_box"></param>
        Public Sub list_available_num_items_for_random_selection(combo_box As ComboBox)

            combo_box.Enabled = True
            combo_box.Items.Clear()

            For num As Integer = 2 To _ui_design_combi_choice.items_available_with_chosen_combination.Count
                combo_box.Items.Add(num)
            Next

        End Sub

        ''' <summary>
        ''' Chooses <paramref name="num_items"/> items from the candidates given
        ''' by the previous design combination choice
        ''' </summary>
        ''' <param name="num_items"></param>
        Public Sub choose_num_items_items_randomly(num_items As Integer)

            _ui_item_choice.choose_randomly(num_items)
            _ui_num_tiles_per_item_choice = New num_tiles_per_item_choice(_ui_item_choice)

            _ui_design_choice.unchoose()

        End Sub

        ''' <summary>
        ''' Fills a combo box with the possible numbers of tiles per#
        ''' item based on the chosen design combination and items.
        ''' Also enables the combo box.
        ''' </summary>
        ''' <param name="combo_box"></param>
        Public Sub list_available_num_tiles(combo_box As ComboBox)

            combo_box.Enabled = True
            combo_box.Items.Clear()

            For Each num As Integer In _ui_num_tiles_per_item_choice.available_choices
                combo_box.Items.Add(num)
            Next

        End Sub

        Public Sub choose_num_tiles_per_item(num_tiles As Integer)
            _ui_num_tiles_per_item_choice.choose(num_tiles)
            _ui_design_choice = New design_choice(_ui_num_tiles_per_item_choice)
        End Sub

        Public Sub choose_designs_for_tiles_randomly()
            _ui_design_choice.choose_randomly()
        End Sub

        Public ReadOnly Property selection_result As Dictionary(Of tile_database.dto.Item, List(Of tile_database.dto.File_Info))
            Get
                If Not _ui_design_choice.choice_was_made Then Throw New InvalidOperationException()
                Return _ui_design_choice.chosen_designs
            End Get
        End Property

    End Class

End Namespace
