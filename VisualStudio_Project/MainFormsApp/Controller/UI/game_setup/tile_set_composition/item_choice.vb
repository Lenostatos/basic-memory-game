Namespace controller.ui.game_setup.tile_set_composition

    Public Class item_choice

        Private Property _database As tile_database.i_database

        Private ReadOnly Property _chosen_design_combination As design_combination

        Private Property _items_available_by_design_combination As List(Of tile_database.dto.Item)
        Private Property _choice_was_made As Boolean

        Private Property _chosen_items As List(Of tile_database.dto.Item)

        Public Sub New(previous_choice As design_combination_choice)

            If Not previous_choice.choice_was_made Then Throw New ArgumentException()

            _database = previous_choice.database

            _chosen_design_combination = previous_choice.chosen_combination
            _items_available_by_design_combination = previous_choice.items_available_with_chosen_combination

            _choice_was_made = False
            _chosen_items = Nothing

        End Sub

        ''' <summary>
        ''' Randomly chooses <paramref name="num_items"/> items from the list
        ''' of those that are available for the previously chosen design
        ''' selection pattern.
        ''' </summary>
        ''' <param name="num_items"></param>
        Public Sub choose_randomly(num_items As Integer)

            unchoose()

            Select Case num_items
                Case < 2
                    Throw New ArgumentOutOfRangeException("num_items", num_items)
                Case > _items_available_by_design_combination.Count
                    Throw New ArgumentOutOfRangeException("num_items", num_items)
                Case = _items_available_by_design_combination.Count
                    _chosen_items = _items_available_by_design_combination
                    _choice_was_made = True
                Case Else

                    Dim max_possible_num_designs As Integer =
                        _database.get_shared_num_files_among_num_items_items_with_highest_file_count(num_items)

                    _chosen_items = utility.functions.sample_enumerable(Of tile_database.dto.Item)(
                        _database.items_with_at_least_num_files(max_possible_num_designs),
                        size:=num_items, replace:=False)

                    _choice_was_made = True
            End Select

        End Sub

        Public Sub choose_manually(items As IEnumerable(Of tile_database.dto.Item))

            unchoose()

            If Not items.All(Function(i As tile_database.dto.Item) items_available_by_design_combination.Contains(i)) Then
                Throw New ArgumentException()
            End If

            _chosen_items = items
            _choice_was_made = True

        End Sub

        Public Sub unchoose()
            _choice_was_made = False
            _chosen_items = Nothing
        End Sub

        Public ReadOnly Property database As tile_database.i_database
            Get
                Return _database
            End Get
        End Property

        ''' <summary>
        ''' Returns the items that can be selected, based on the
        ''' previously chosen design combination.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property items_available_by_design_combination As IEnumerable(Of tile_database.dto.Item)
            Get
                Return _items_available_by_design_combination
            End Get
        End Property

        Public ReadOnly Property choice_was_made As Boolean
            Get
                Return _choice_was_made
            End Get
        End Property

        Public ReadOnly Property chosen_design_combination As design_combination
            Get
                Return _chosen_design_combination
            End Get
        End Property

        Public ReadOnly Property chosen_items As IEnumerable(Of tile_database.dto.Item)
            Get
                If Not choice_was_made Then Throw New InvalidOperationException()
                Return _chosen_items
            End Get
        End Property

    End Class

End Namespace
