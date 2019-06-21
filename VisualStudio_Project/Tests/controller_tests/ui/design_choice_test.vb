Imports MainFormsApp.tile_database
Imports MainFormsApp.controller.ui.game_setup.tile_set_composition

Namespace controller_tests

    <TestClass>
    Public Class design_choice_test

        Private Property _database As i_database

        Private Property _design_combi_choice As design_combination_choice
        Private Property _item_choice As item_choice
        Private Property _num_tiles_choice As num_tiles_per_item_choice
        Private Property _design_choice As design_choice

        Public Sub New()

            _database = New database()
            _database.initialize(database.TEST_PATH)

            _design_combi_choice = New design_combination_choice(_database)

        End Sub

        <TestMethod>
        Public Sub construction_w_valid_arguments()

            _design_combi_choice.choose(design_combination.identical_and_unique_designs_per_item)
            _item_choice = New item_choice(_design_combi_choice)
            _item_choice.choose_randomly(5)
            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)
            _num_tiles_choice.choose(4)
            _design_choice = New design_choice(_num_tiles_choice)

            Dim dummy
            Assert.IsFalse(_design_choice.choice_was_made)
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = _design_choice.chosen_designs)

        End Sub

        <TestMethod>
        Public Sub choose()

            _design_combi_choice.choose(design_combination.identical_and_unique_designs_per_item)
            _item_choice = New item_choice(_design_combi_choice)
            _item_choice.choose_randomly(5)
            _num_tiles_choice = New num_tiles_per_item_choice(_item_choice)
            _num_tiles_choice.choose(4)
            _design_choice = New design_choice(_num_tiles_choice)

            _design_choice.choose_randomly()
            Dim chosen_designs As Dictionary(Of dto.Item, List(Of dto.File_Info))
            chosen_designs = _design_choice.chosen_designs

            Assert.AreEqual(5, chosen_designs.Count)
            Assert.IsTrue(chosen_designs.Values.All(
                          Function(design_list As List(Of dto.File_Info))
                              Return design_list.Count = 4
                          End Function))

        End Sub

        <TestMethod>
        Public Sub unchoose()

        End Sub

    End Class

End Namespace
