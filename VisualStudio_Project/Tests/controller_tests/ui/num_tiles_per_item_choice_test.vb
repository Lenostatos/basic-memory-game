Imports MainFormsApp.tile_database
Imports MainFormsApp.controller.ui.game_setup.tile_set_composition

Namespace controller_tests

    <TestClass>
    Public Class num_tiles_per_item_choice_test

        Private Property _database As i_database
        Private Property _design_choice As design_combination_choice
        Private Property _item_choice As item_choice
        Private Property _num_tiles_choice As num_tiles_per_item_choice

        Public Sub New()

            _database = New database()
            _database.initialize(database.TEST_PATH)

            _design_choice = New design_combination_choice(_database)

        End Sub

        <TestMethod>
        Public Sub construction_w_valid_arguments()

            _design_choice.choose(design_combination.only_identical_designs_per_item)
            _item_choice = New item_choice(_design_choice)
            _item_choice.choose_randomly(3)

            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)

            Assert.IsFalse(_num_tiles_choice.choice_was_made)
            Assert.IsTrue(_num_tiles_choice.available_choices.Min() = 2 AndAlso
                          _num_tiles_choice.available_choices.Max() = 5 AndAlso
                          _num_tiles_choice.available_choices.Count = 4)
            Dim dummy
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = _num_tiles_choice.chosen_number)

            _design_choice.choose(design_combination.identical_and_unique_designs_per_item)
            _item_choice = New item_choice(_design_choice)
            _item_choice.choose_randomly(2)

            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)

            Assert.IsFalse(_num_tiles_choice.choice_was_made)
            Assert.IsTrue(_num_tiles_choice.available_choices.Min() = 2 AndAlso
                          _num_tiles_choice.available_choices.Max() = 5 AndAlso
                          _num_tiles_choice.available_choices.Count = 4)

            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = _num_tiles_choice.chosen_number)

            _design_choice.choose(design_combination.only_unique_designs_per_item)
            _item_choice = New item_choice(_design_choice)
            _item_choice.choose_randomly(3)

            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)

            Assert.IsFalse(_num_tiles_choice.choice_was_made)
            Assert.IsTrue(_num_tiles_choice.available_choices.Min() = 2 AndAlso
                          _num_tiles_choice.available_choices.Max() = 3 AndAlso
                          _num_tiles_choice.available_choices.Count = 2)

            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = _num_tiles_choice.chosen_number)

            _design_choice.choose(design_combination.only_unique_designs_per_item)
            _item_choice = New item_choice(_design_choice)
            _item_choice.choose_randomly(4)

            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)

            Assert.IsFalse(_num_tiles_choice.choice_was_made)
            Assert.IsTrue(_num_tiles_choice.available_choices.Min() = 2 AndAlso
                          _num_tiles_choice.available_choices.Max() = 2 AndAlso
                          _num_tiles_choice.available_choices.Count = 1)

            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = _num_tiles_choice.chosen_number)

            _design_choice.choose(design_combination.only_unique_designs_per_item)
            _item_choice = New item_choice(_design_choice)
            _item_choice.choose_randomly(2)

            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)

            Assert.IsFalse(_num_tiles_choice.choice_was_made)
            Assert.IsTrue(_num_tiles_choice.available_choices.Min() = 2 AndAlso
                          _num_tiles_choice.available_choices.Max() = 4 AndAlso
                          _num_tiles_choice.available_choices.Count = 3)

            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = _num_tiles_choice.chosen_number)

        End Sub

    End Class

End Namespace
