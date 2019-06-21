Imports MainFormsApp.tile_database
Imports MainFormsApp.controller.ui.game_setup.tile_set_composition

Namespace controller_tests

    <TestClass>
    Public Class design_combination_choice_test

        Private Property _database As i_database
        Private Property _test_items As List(Of dto.Item)

        Public Sub New()

            _database = New database()
            _database.initialize(database.TEST_PATH)

            _test_items = New List(Of dto.Item)(6)
            _test_items.AddRange({
                New dto.Item() With {.id = 1, .name = "Pine"},
                New dto.Item() With {.id = 2, .name = "Oak"},
                New dto.Item() With {.id = 3, .name = "Spruce"},
                New dto.Item() With {.id = 4, .name = "Black Alder"},
                New dto.Item() With {.id = 5, .name = "Birch"},
                New dto.Item() With {.id = 6, .name = "Beech"}
            })

        End Sub

        <TestMethod>
        Public Sub construct_w_valid_arguments()

            Dim my_choice As design_combination_choice
            my_choice = New design_combination_choice(_database)

            Assert.AreSame(_database, my_choice.database)
            Assert.IsFalse(my_choice.choice_was_made)

            Dim dummy
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = my_choice.chosen_combination)
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = my_choice.items_available_with_chosen_combination)

            Assert.IsTrue(my_choice.available_combinations.Contains(
                          design_combination.only_identical_designs_per_item))
            Assert.IsTrue(my_choice.available_combinations.Contains(
                          design_combination.identical_and_unique_designs_per_item))
            Assert.IsTrue(my_choice.available_combinations.Contains(
                          design_combination.only_unique_designs_per_item))

        End Sub

        <TestMethod>
        Public Sub choose_identical_or_both()

            Dim my_choice As New design_combination_choice(_database)

            my_choice.choose(design_combination.only_identical_designs_per_item)
            Assert.IsTrue(my_choice.choice_was_made)
            Assert.AreEqual(design_combination.only_identical_designs_per_item, my_choice.chosen_combination)

            Dim expected_candidate_items As IEnumerable(Of dto.Item) =
                _test_items.Where(Function(i As dto.Item) i.id <> 6)

            Assert.AreEqual(expected_candidate_items.Count, my_choice.items_available_with_chosen_combination.Count)

            Assert.IsTrue(expected_candidate_items.All(
                          Function(i As dto.Item) my_choice.items_available_with_chosen_combination.Contains(i)))

            Assert.IsFalse(my_choice.items_available_with_chosen_combination.Contains(
                           New dto.Item() With {.id = 6, .name = "Pine"}))

        End Sub

        <TestMethod>
        Public Sub choose_identical_and_unique()

            Dim my_choice As New design_combination_choice(_database)

            my_choice.choose(design_combination.identical_and_unique_designs_per_item)
            Assert.IsTrue(my_choice.choice_was_made)
            Assert.AreEqual(design_combination.identical_and_unique_designs_per_item, my_choice.chosen_combination)

            Dim expected_candidate_items As IEnumerable(Of dto.Item) =
                _test_items.Where(Function(i As dto.Item) i.id <> 6)

            expected_candidate_items = _test_items.Where(Function(i As dto.Item) i.id <> 6)

            Assert.AreEqual(expected_candidate_items.Count, my_choice.items_available_with_chosen_combination.Count)

            Assert.IsTrue(expected_candidate_items.All(
                          Function(i As dto.Item) my_choice.items_available_with_chosen_combination.Contains(i)))

            Assert.IsFalse(my_choice.items_available_with_chosen_combination.Contains(
                           New dto.Item() With {.id = 6, .name = "Pine"}))

        End Sub

        <TestMethod>
        Public Sub choose_unique()

            Dim my_choice As New design_combination_choice(_database)

            my_choice.choose(design_combination.only_unique_designs_per_item)
            Assert.IsTrue(my_choice.choice_was_made)
            Assert.AreEqual(design_combination.only_unique_designs_per_item, my_choice.chosen_combination)

            Dim expected_candidate_items As IEnumerable(Of dto.Item) =
                _test_items.Where(Function(i As dto.Item) i.id <> 5 AndAlso i.id <> 6)

            Assert.AreEqual(expected_candidate_items.Count, my_choice.items_available_with_chosen_combination.Count)

            Assert.IsTrue(expected_candidate_items.All(
                          Function(i As dto.Item) my_choice.items_available_with_chosen_combination.Contains(i)))

            Assert.IsFalse(my_choice.items_available_with_chosen_combination.Contains(
                           New dto.Item() With {.id = 6, .name = "Pine"}))
            Assert.IsFalse(my_choice.items_available_with_chosen_combination.Contains(
                           New dto.Item() With {.id = 5, .name = "Birch"}))

        End Sub

        <TestMethod>
        Public Sub unchoose()

            Dim my_choice As New design_combination_choice(_database)
            my_choice.choose(design_combination.only_unique_designs_per_item)
            my_choice.unchoose()

            Assert.IsFalse(my_choice.choice_was_made)

            Dim dummy
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = my_choice.chosen_combination)
            Assert.ThrowsException(Of InvalidOperationException)(
                Sub() dummy = my_choice.items_available_with_chosen_combination)

        End Sub

    End Class

End Namespace
