Imports MainFormsApp.tile_database
Imports MainFormsApp.controller.ui.game_setup.tile_set_composition

Namespace controller_tests

    <TestClass>
    Public Class item_choice_test

        Private Property _database As i_database
        Private Property _design_choice As design_combination_choice

        Public Sub New()

            _database = New database()
            _database.initialize(database.TEST_PATH)

            _design_choice = New design_combination_choice(_database)

        End Sub

        <TestMethod>
        Public Sub construction_w_valid_arguments()

            _design_choice.choose(how_to_select_designs.only_identical_designs_per_item)

            Dim my_item_choice As New item_choice(_design_choice)

            Assert.IsFalse(my_item_choice.choice_was_made)

            Dim dummy
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = my_item_choice.candidate_items)

            Assert.ThrowsException(Of ArgumentOutOfRangeException)(
                Sub() my_item_choice.choose_randomly(1))

        End Sub

        <TestMethod>
        Public Sub choose_randomly()

            _design_choice.choose(how_to_select_designs.only_identical_designs_per_item)
            Dim my_item_choice As New item_choice(_design_choice)

            my_item_choice.choose_randomly(2)
            Assert.IsTrue(my_item_choice.choice_was_made)
            Assert.AreEqual(2, my_item_choice.chosen_items.Count)
            Assert.IsTrue(
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 1, .name = "Pine"}) AndAlso
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 2, .name = "Oak"}))

            my_item_choice.choose_randomly(3)
            Assert.IsTrue(my_item_choice.choice_was_made)
            Assert.AreEqual(3, my_item_choice.chosen_items.Count)
            Assert.IsTrue(
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 1, .name = "Pine"}) AndAlso
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 2, .name = "Oak"}) AndAlso
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 4, .name = "Black Alder"}))

            my_item_choice.choose_randomly(4)
            Assert.IsTrue(my_item_choice.choice_was_made)
            Assert.AreEqual(4, my_item_choice.chosen_items.Count)
            Assert.IsTrue(
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 1, .name = "Pine"}) AndAlso
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 2, .name = "Oak"}) AndAlso
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 4, .name = "Black Alder"}) AndAlso
            my_item_choice.chosen_items.Contains(New dto.Item() With {.id = 3, .name = "Spruce"}))

        End Sub

    End Class

End Namespace
