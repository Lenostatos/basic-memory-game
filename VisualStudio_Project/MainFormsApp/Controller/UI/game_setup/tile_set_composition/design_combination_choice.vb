Namespace controller.ui.game_setup.tile_set_composition

    Public Class design_combination_choice

        Private _database As tile_database.i_database
        Private _available_combinations As List(Of design_combination)

        Private _choice_was_made As Boolean
        Private _choice As design_combination

        Private _items_available_with_chosen_combination As List(Of tile_database.dto.Item)

        Public Sub New(tile_database As tile_database.i_database)

            If tile_database Is Nothing Then Throw New ArgumentNullException()
            _database = tile_database

            _available_combinations = New List(Of design_combination)

            _choice_was_made = False
            _choice = design_combination.None

            determine_available_combinations()

        End Sub

        ''' <summary>
        ''' Chooses a design combination pattern and presents a list of items that
        ''' have enough designs to be used with such a pattern.
        ''' </summary>
        ''' <param name="pattern"></param>
        Public Sub choose(pattern As design_combination)

            unchoose()

            If Not available_combinations.Contains(pattern) Then
                Throw New ArgumentException()
            End If

            _choice = pattern

            Select Case _choice
                Case design_combination.only_identical_designs_per_item,
                     design_combination.identical_and_unique_designs_per_item
                    _items_available_with_chosen_combination = _database.items_with_at_least_num_files(1)
                Case design_combination.only_unique_designs_per_item
                    _items_available_with_chosen_combination = _database.items_with_at_least_num_files(2)
            End Select

            _choice_was_made = True

        End Sub

        Public Sub unchoose()

            _items_available_with_chosen_combination = Nothing

            _choice = design_combination.None
            _choice_was_made = False

        End Sub

        Public ReadOnly Property database As tile_database.i_database
            Get
                Return _database
            End Get
        End Property

        ''' <summary>
        ''' Returns the design combination patterns that are available based
        ''' on the content of the database.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property available_combinations As IReadOnlyList(Of design_combination)
            Get
                Return _available_combinations
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        ''' <summary>
        ''' Returns the design combination pattern that was chosen.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property chosen_combination As design_combination
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _choice
            End Get
        End Property

        ''' <summary>
        ''' Returns the items that can be used with the chosen design
        ''' combination pattern.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property items_available_with_chosen_combination As List(Of tile_database.dto.Item)
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _items_available_with_chosen_combination
            End Get
        End Property

        Private Sub determine_available_combinations()

            _available_combinations.Clear()

            If _database.count_items_with_at_least_num_files(1) > 1 Then
                _available_combinations.Add(design_combination.only_identical_designs_per_item)
                _available_combinations.Add(design_combination.identical_and_unique_designs_per_item)
            End If

            If _database.count_items_with_at_least_num_files(2) > 1 Then
                _available_combinations.Add(design_combination.only_unique_designs_per_item)
            End If

        End Sub

    End Class

End Namespace
